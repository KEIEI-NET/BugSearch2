//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d�t�n�d�����f�[�^�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d�t�n�d�����f�[�^�A�N�Z�X���s��
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
	/// �t�n�d�����f�[�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d�����f�[�^�A�N�Z�X�N���X</br>
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
        # region �t�n�d�����f�[�^�쐬�i�f�[�^���X�g���f�[�^�[�e�[�u���j
        /// <summary>
        /// �t�n�d�����f�[�^�쐬�i�f�[�^���X�g���f�[�^�[�e�[�u���j
        /// </summary>
        /// <param name="uOEOrderDtlWork">�t�n�d�����f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int ToDataTableFromUOEOrderDtlList(List<UOEOrderDtlWork> list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                UOEOrderDtlSchema.SettingDataSet(ref _uoeJnlDataSet);

                foreach (UOEOrderDtlWork rst in list)
                {
                    //����M�i�m�k�̕ۑ�
                    DataRow dr = UOEOrderDtlTable.NewRow();
                    CreateUOEOrderDtlSchema(ref dr, rst);
                    UOEOrderDtlTable.Rows.Add(dr);
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

        # region �t�n�d�����f�[�^�X�V�i�f�[�^���X�g���f�[�^�[�e�[�u���j
        /// <summary>
        /// �t�n�d�����f�[�^�X�V�i�f�[�^���X�g���f�[�^�[�e�[�u���j
        /// </summary>
        /// <param name="uOEOrderDtlWork">�t�n�d�����f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromUOEOrderDtlList(List<UOEOrderDtlWork> list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (UOEOrderDtlWork rst in list)
                {
                    // �t�n�d����DataTable��FIND����
                    object[] findUOEOrderDtl = new object[3];
                    findUOEOrderDtl[0] = rst.UOESupplierCd;
                    findUOEOrderDtl[1] = rst.UOESalesOrderNo;
                    findUOEOrderDtl[2] = rst.UOESalesOrderRowNo;
                    DataRow uOEOrderDtlRow = UOEOrderDtlTable.Rows.Find(findUOEOrderDtl);

                    //�t�n�d����DataTable�̍X�V
                    if (uOEOrderDtlRow != null)
                    {
                        CreateUOEOrderDtlSchema(ref uOEOrderDtlRow, rst);
                    }
                    //�t�n�d����DataTable�̒ǉ�
                    else
                    {
                        DataRow dr = UOEOrderDtlTable.NewRow();
                        CreateUOEOrderDtlSchema(ref dr, rst);
                        UOEOrderDtlTable.Rows.Add(dr);
                    }
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

        # region �t�n�d�����f�[�^��DataRow �� �N���X���쐬
        /// <summary>
        /// �t�n�d�����f�[�^��DataRow �� �N���X���쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">�t�n�d�����f�[�^</param>
        public UOEOrderDtlWork CreateUOEOrderDtlWorkFromSchema(ref DataRow dr)
        {
            return (CreateUOEOrderDtlWorkFromSchemaProc(ref dr));
        }
        # endregion

        # endregion

        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �t�n�d�����f�[�^�e�[�u��Row�쐬
        /// <summary>
        /// �t�n�d�����f�[�^�e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">�t�n�d�����f�[�^�N���X</param>
        private void CreateUOEOrderDtlSchema(ref DataRow dr, UOEOrderDtlWork rst)
        {
            dr[UOEOrderDtlSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// �쐬����
            dr[UOEOrderDtlSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// �X�V����
            dr[UOEOrderDtlSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// ��ƃR�[�h
            dr[UOEOrderDtlSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            dr[UOEOrderDtlSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// �X�V�]�ƈ��R�[�h
            dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// �X�V�A�Z���u��ID1
            dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// �X�V�A�Z���u��ID2
            dr[UOEOrderDtlSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// �_���폜�敪
            dr[UOEOrderDtlSchema.ct_Col_SystemDivCd] = rst.SystemDivCd;	// �V�X�e���敪
            dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderNo] = rst.UOESalesOrderNo;	// UOE�����ԍ�
            dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderRowNo] = rst.UOESalesOrderRowNo;	// UOE�����s�ԍ�
            dr[UOEOrderDtlSchema.ct_Col_SendTerminalNo] = rst.SendTerminalNo;	// ���M�[���ԍ�
            dr[UOEOrderDtlSchema.ct_Col_UOESupplierCd] = rst.UOESupplierCd;	// UOE������R�[�h
            dr[UOEOrderDtlSchema.ct_Col_UOESupplierName] = rst.UOESupplierName;	// UOE�����於��
            dr[UOEOrderDtlSchema.ct_Col_CommAssemblyId] = rst.CommAssemblyId;	// �ʐM�A�Z���u��ID
            dr[UOEOrderDtlSchema.ct_Col_OnlineNo] = rst.OnlineNo;	// �I�����C���ԍ�
            dr[UOEOrderDtlSchema.ct_Col_OnlineRowNo] = rst.OnlineRowNo;	// �I�����C���s�ԍ�
            dr[UOEOrderDtlSchema.ct_Col_SalesDate] = rst.SalesDate;	// ������t
            dr[UOEOrderDtlSchema.ct_Col_InputDay] = rst.InputDay;	// ���͓�
            dr[UOEOrderDtlSchema.ct_Col_DataUpdateDateTime] = rst.DataUpdateDateTime;	// �f�[�^�X�V����
            dr[UOEOrderDtlSchema.ct_Col_UOEKind] = rst.UOEKind;	// UOE���
            dr[UOEOrderDtlSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum;	// ����`�[�ԍ�
            dr[UOEOrderDtlSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus;	// �󒍃X�e�[�^�X
            dr[UOEOrderDtlSchema.ct_Col_SalesSlipDtlNum] = rst.SalesSlipDtlNum;	// ���㖾�גʔ�
            dr[UOEOrderDtlSchema.ct_Col_SectionCode] = rst.SectionCode;	// ���_�R�[�h
            dr[UOEOrderDtlSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// ����R�[�h
            dr[UOEOrderDtlSchema.ct_Col_CustomerCode] = rst.CustomerCode;	// ���Ӑ�R�[�h
            dr[UOEOrderDtlSchema.ct_Col_CustomerSnm] = rst.CustomerSnm;	// ���Ӑ旪��
            dr[UOEOrderDtlSchema.ct_Col_CashRegisterNo] = rst.CashRegisterNo;	// ���W�ԍ�
            dr[UOEOrderDtlSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo;	// ���ʒʔ�
            dr[UOEOrderDtlSchema.ct_Col_SupplierFormal] = rst.SupplierFormal;	// �d���`��
            dr[UOEOrderDtlSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo;	// �d���`�[�ԍ�
            dr[UOEOrderDtlSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum;	// �d�����גʔ�
            dr[UOEOrderDtlSchema.ct_Col_BoCode] = rst.BoCode;	// BO�敪
            dr[UOEOrderDtlSchema.ct_Col_UOEDeliGoodsDiv] = rst.UOEDeliGoodsDiv;	// �[�i�敪
            dr[UOEOrderDtlSchema.ct_Col_DeliveredGoodsDivNm] = rst.DeliveredGoodsDivNm;	// �[�i�敪����
            dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDiv] = rst.FollowDeliGoodsDiv;	// �t�H���[�[�i�敪
            dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDivNm] = rst.FollowDeliGoodsDivNm;	// �t�H���[�[�i�敪����
            dr[UOEOrderDtlSchema.ct_Col_UOEResvdSection] = rst.UOEResvdSection;	// UOE�w�苒�_
            dr[UOEOrderDtlSchema.ct_Col_UOEResvdSectionNm] = rst.UOEResvdSectionNm;	// UOE�w�苒�_����
            dr[UOEOrderDtlSchema.ct_Col_EmployeeCode] = rst.EmployeeCode;	// �]�ƈ��R�[�h
            dr[UOEOrderDtlSchema.ct_Col_EmployeeName] = rst.EmployeeName;	// �]�ƈ�����
            dr[UOEOrderDtlSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd;	// ���i���[�J�[�R�[�h
            dr[UOEOrderDtlSchema.ct_Col_MakerName] = rst.MakerName;	// ���[�J�[����
            dr[UOEOrderDtlSchema.ct_Col_GoodsNo] = rst.GoodsNo;	// ���i�ԍ�
            dr[UOEOrderDtlSchema.ct_Col_GoodsNoNoneHyphen] = rst.GoodsNoNoneHyphen;	// �n�C�t�������i�ԍ�
            dr[UOEOrderDtlSchema.ct_Col_GoodsName] = rst.GoodsName;	// ���i����
            dr[UOEOrderDtlSchema.ct_Col_WarehouseCode] = rst.WarehouseCode;	// �q�ɃR�[�h
            dr[UOEOrderDtlSchema.ct_Col_WarehouseName] = rst.WarehouseName;	// �q�ɖ���
            dr[UOEOrderDtlSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo;	// �q�ɒI��
            dr[UOEOrderDtlSchema.ct_Col_AcceptAnOrderCnt] = rst.AcceptAnOrderCnt;	// �󒍐���
            dr[UOEOrderDtlSchema.ct_Col_ListPrice] = rst.ListPrice;	// �艿�i�����j
            dr[UOEOrderDtlSchema.ct_Col_SalesUnitCost] = rst.SalesUnitCost;	// �����P��
            dr[UOEOrderDtlSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// �d����R�[�h
            dr[UOEOrderDtlSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// �d���旪��
            dr[UOEOrderDtlSchema.ct_Col_UoeRemark1] = rst.UoeRemark1;	// �t�n�d���}�[�N�P
            dr[UOEOrderDtlSchema.ct_Col_UoeRemark2] = rst.UoeRemark2;	// �t�n�d���}�[�N�Q
            dr[UOEOrderDtlSchema.ct_Col_ReceiveDate] = rst.ReceiveDate;	// ��M���t
            dr[UOEOrderDtlSchema.ct_Col_ReceiveTime] = rst.ReceiveTime;	// ��M����
            dr[UOEOrderDtlSchema.ct_Col_AnswerMakerCd] = rst.AnswerMakerCd;	// �񓚃��[�J�[�R�[�h
            dr[UOEOrderDtlSchema.ct_Col_AnswerPartsNo] = rst.AnswerPartsNo;	// �񓚕i��
            dr[UOEOrderDtlSchema.ct_Col_AnswerPartsName] = rst.AnswerPartsName;	// �񓚕i��
            dr[UOEOrderDtlSchema.ct_Col_SubstPartsNo] = rst.SubstPartsNo;	// ��֕i��
            dr[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt] = rst.UOESectOutGoodsCnt;	// UOE���_�o�ɐ�
            dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1] = rst.BOShipmentCnt1;	// BO�o�ɐ�1
            dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2] = rst.BOShipmentCnt2;	// BO�o�ɐ�2
            dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3] = rst.BOShipmentCnt3;	// BO�o�ɐ�3
            dr[UOEOrderDtlSchema.ct_Col_MakerFollowCnt] = rst.MakerFollowCnt;	// ���[�J�[�t�H���[��
            dr[UOEOrderDtlSchema.ct_Col_NonShipmentCnt] = rst.NonShipmentCnt;	// ���o�ɐ�
            dr[UOEOrderDtlSchema.ct_Col_UOESectStockCnt] = rst.UOESectStockCnt;	// UOE���_�݌ɐ�
            dr[UOEOrderDtlSchema.ct_Col_BOStockCount1] = rst.BOStockCount1;	// BO�݌ɐ�1
            dr[UOEOrderDtlSchema.ct_Col_BOStockCount2] = rst.BOStockCount2;	// BO�݌ɐ�2
            dr[UOEOrderDtlSchema.ct_Col_BOStockCount3] = rst.BOStockCount3;	// BO�݌ɐ�3
            dr[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo] = rst.UOESectionSlipNo;	// UOE���_�`�[�ԍ�
            dr[UOEOrderDtlSchema.ct_Col_BOSlipNo1] = rst.BOSlipNo1;	// BO�`�[�ԍ��P
            dr[UOEOrderDtlSchema.ct_Col_BOSlipNo2] = rst.BOSlipNo2;	// BO�`�[�ԍ��Q
            dr[UOEOrderDtlSchema.ct_Col_BOSlipNo3] = rst.BOSlipNo3;	// BO�`�[�ԍ��R
            dr[UOEOrderDtlSchema.ct_Col_EOAlwcCount] = rst.EOAlwcCount;	// EO������
            dr[UOEOrderDtlSchema.ct_Col_BOManagementNo] = rst.BOManagementNo;	// BO�Ǘ��ԍ�
            dr[UOEOrderDtlSchema.ct_Col_AnswerListPrice] = rst.AnswerListPrice;	// �񓚒艿
            dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost] = rst.AnswerSalesUnitCost;	// �񓚌����P��
            dr[UOEOrderDtlSchema.ct_Col_UOESubstMark] = rst.UOESubstMark;	// UOE��փ}�[�N
            dr[UOEOrderDtlSchema.ct_Col_UOEStockMark] = rst.UOEStockMark;	// UOE�݌Ƀ}�[�N
            dr[UOEOrderDtlSchema.ct_Col_PartsLayerCd] = rst.PartsLayerCd;	// �w�ʃR�[�h
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1] = rst.MazdaUOEShipSectCd1;	// UOE�o�׋��_�R�[�h�P�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2] = rst.MazdaUOEShipSectCd2;	// UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3] = rst.MazdaUOEShipSectCd3;	// UOE�o�׋��_�R�[�h�R�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1] = rst.MazdaUOESectCd1;	// UOE���_�R�[�h�P�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2] = rst.MazdaUOESectCd2;	// UOE���_�R�[�h�Q�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3] = rst.MazdaUOESectCd3;	// UOE���_�R�[�h�R�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4] = rst.MazdaUOESectCd4;	// UOE���_�R�[�h�S�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5] = rst.MazdaUOESectCd5;	// UOE���_�R�[�h�T�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6] = rst.MazdaUOESectCd6;	// UOE���_�R�[�h�U�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7] = rst.MazdaUOESectCd7;	// UOE���_�R�[�h�V�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1] = rst.MazdaUOEStockCnt1;	// UOE�݌ɐ��P�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2] = rst.MazdaUOEStockCnt2;	// UOE�݌ɐ��Q�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3] = rst.MazdaUOEStockCnt3;	// UOE�݌ɐ��R�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4] = rst.MazdaUOEStockCnt4;	// UOE�݌ɐ��S�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5] = rst.MazdaUOEStockCnt5;	// UOE�݌ɐ��T�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6] = rst.MazdaUOEStockCnt6;	// UOE�݌ɐ��U�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7] = rst.MazdaUOEStockCnt7;	// UOE�݌ɐ��V�i�}�c�_�j
            dr[UOEOrderDtlSchema.ct_Col_UOEDistributionCd] = rst.UOEDistributionCd;	// UOE���R�[�h
            dr[UOEOrderDtlSchema.ct_Col_UOEOtherCd] = rst.UOEOtherCd;	// UOE���R�[�h
            dr[UOEOrderDtlSchema.ct_Col_UOEHMCd] = rst.UOEHMCd;	// UOE�g�l�R�[�h
            dr[UOEOrderDtlSchema.ct_Col_BOCount] = rst.BOCount;	// �a�n��
            dr[UOEOrderDtlSchema.ct_Col_UOEMarkCode] = rst.UOEMarkCode;	// UOE�}�[�N�R�[�h
            dr[UOEOrderDtlSchema.ct_Col_SourceShipment] = rst.SourceShipment;	// �o�׌�
            dr[UOEOrderDtlSchema.ct_Col_ItemCode] = rst.ItemCode;	// �A�C�e���R�[�h
            dr[UOEOrderDtlSchema.ct_Col_UOECheckCode] = rst.UOECheckCode;	// UOE�`�F�b�N�R�[�h
            dr[UOEOrderDtlSchema.ct_Col_HeadErrorMassage] = rst.HeadErrorMassage;	// �w�b�h�G���[���b�Z�[�W
            dr[UOEOrderDtlSchema.ct_Col_LineErrorMassage] = rst.LineErrorMassage;	// ���C���G���[���b�Z�[�W
            dr[UOEOrderDtlSchema.ct_Col_DataSendCode] = rst.DataSendCode;	// �f�[�^���M�敪
            dr[UOEOrderDtlSchema.ct_Col_DataRecoverDiv] = rst.DataRecoverDiv;	// �f�[�^�����敪
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec] = rst.EnterUpdDivSec;	// ���ɍX�V�敪�i���_�j
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1] = rst.EnterUpdDivBO1;	// ���ɍX�V�敪�iBO1�j
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2] = rst.EnterUpdDivBO2;	// ���ɍX�V�敪�iBO2�j
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3] = rst.EnterUpdDivBO3;	// ���ɍX�V�敪�iBO3�j
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker] = rst.EnterUpdDivMaker;	// ���ɍX�V�敪�iҰ���j
            dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO] = rst.EnterUpdDivEO;	// ���ɍX�V�敪�iEO�j
            dr[UOEOrderDtlSchema.ct_Col_DtlRelationGuid] = rst.DtlRelationGuid;	// ���׊֘A�t��GUID
        }
        # endregion

   		# region �t�n�d�����f�[�^��DataRow �� �N���X���쐬
		/// <summary>
		/// �t�n�d�����f�[�^��DataRow �� �N���X���쐬
		/// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">�t�n�d�����f�[�^</param>
        private UOEOrderDtlWork CreateUOEOrderDtlWorkFromSchemaProc(ref DataRow dr)
        {
            UOEOrderDtlWork rst = new UOEOrderDtlWork();

            try
            {
                rst.CreateDateTime = (DateTime)dr[UOEOrderDtlSchema.ct_Col_CreateDateTime];	// �쐬����
                rst.UpdateDateTime = (DateTime)dr[UOEOrderDtlSchema.ct_Col_UpdateDateTime];	// �X�V����
                rst.EnterpriseCode = (string)dr[UOEOrderDtlSchema.ct_Col_EnterpriseCode];	// ��ƃR�[�h
                rst.FileHeaderGuid = (Guid)dr[UOEOrderDtlSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[UOEOrderDtlSchema.ct_Col_UpdEmployeeCode];	// �X�V�]�ƈ��R�[�h
                rst.UpdAssemblyId1 = (string)dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId1];	// �X�V�A�Z���u��ID1
                rst.UpdAssemblyId2 = (string)dr[UOEOrderDtlSchema.ct_Col_UpdAssemblyId2];	// �X�V�A�Z���u��ID2
                rst.LogicalDeleteCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_LogicalDeleteCode];	// �_���폜�敪
                rst.SystemDivCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_SystemDivCd];	// �V�X�e���敪
                rst.UOESalesOrderNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderNo];	// UOE�����ԍ�
                rst.UOESalesOrderRowNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESalesOrderRowNo];	// UOE�����s�ԍ�
                rst.SendTerminalNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_SendTerminalNo];	// ���M�[���ԍ�
                rst.UOESupplierCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESupplierCd];	// UOE������R�[�h
                rst.UOESupplierName = (string)dr[UOEOrderDtlSchema.ct_Col_UOESupplierName];	// UOE�����於��
                rst.CommAssemblyId = (string)dr[UOEOrderDtlSchema.ct_Col_CommAssemblyId];	// �ʐM�A�Z���u��ID
                rst.OnlineNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_OnlineNo];	// �I�����C���ԍ�
                rst.OnlineRowNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_OnlineRowNo];	// �I�����C���s�ԍ�
                rst.SalesDate = (DateTime)dr[UOEOrderDtlSchema.ct_Col_SalesDate];	// ������t
                rst.InputDay = (DateTime)dr[UOEOrderDtlSchema.ct_Col_InputDay];	// ���͓�
                rst.DataUpdateDateTime = (DateTime)dr[UOEOrderDtlSchema.ct_Col_DataUpdateDateTime];	// �f�[�^�X�V����
                rst.UOEKind = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOEKind];	// UOE���
                rst.SalesSlipNum = (string)dr[UOEOrderDtlSchema.ct_Col_SalesSlipNum];	// ����`�[�ԍ�
                rst.AcptAnOdrStatus = (Int32)dr[UOEOrderDtlSchema.ct_Col_AcptAnOdrStatus];	// �󒍃X�e�[�^�X
                rst.SalesSlipDtlNum = (Int64)dr[UOEOrderDtlSchema.ct_Col_SalesSlipDtlNum];	// ���㖾�גʔ�
                rst.SectionCode = (string)dr[UOEOrderDtlSchema.ct_Col_SectionCode];	// ���_�R�[�h
                rst.SubSectionCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_SubSectionCode];	// ����R�[�h
                rst.CustomerCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_CustomerCode];	// ���Ӑ�R�[�h
                rst.CustomerSnm = (string)dr[UOEOrderDtlSchema.ct_Col_CustomerSnm];	// ���Ӑ旪��
                rst.CashRegisterNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_CashRegisterNo];	// ���W�ԍ�
                rst.CommonSeqNo = (Int64)dr[UOEOrderDtlSchema.ct_Col_CommonSeqNo];	// ���ʒʔ�
                rst.SupplierFormal = (Int32)dr[UOEOrderDtlSchema.ct_Col_SupplierFormal];	// �d���`��
                rst.SupplierSlipNo = (Int32)dr[UOEOrderDtlSchema.ct_Col_SupplierSlipNo];	// �d���`�[�ԍ�
                rst.StockSlipDtlNum = (Int64)dr[UOEOrderDtlSchema.ct_Col_StockSlipDtlNum];	// �d�����גʔ�
                rst.BoCode = (string)dr[UOEOrderDtlSchema.ct_Col_BoCode];	// BO�敪
                rst.UOEDeliGoodsDiv = (string)dr[UOEOrderDtlSchema.ct_Col_UOEDeliGoodsDiv];	// �[�i�敪
                rst.DeliveredGoodsDivNm = (string)dr[UOEOrderDtlSchema.ct_Col_DeliveredGoodsDivNm];	// �[�i�敪����
                rst.FollowDeliGoodsDiv = (string)dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDiv];	// �t�H���[�[�i�敪
                rst.FollowDeliGoodsDivNm = (string)dr[UOEOrderDtlSchema.ct_Col_FollowDeliGoodsDivNm];	// �t�H���[�[�i�敪����
                rst.UOEResvdSection = (string)dr[UOEOrderDtlSchema.ct_Col_UOEResvdSection];	// UOE�w�苒�_
                rst.UOEResvdSectionNm = (string)dr[UOEOrderDtlSchema.ct_Col_UOEResvdSectionNm];	// UOE�w�苒�_����
                rst.EmployeeCode = (string)dr[UOEOrderDtlSchema.ct_Col_EmployeeCode];	// �]�ƈ��R�[�h
                rst.EmployeeName = (string)dr[UOEOrderDtlSchema.ct_Col_EmployeeName];	// �]�ƈ�����
                rst.GoodsMakerCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_GoodsMakerCd];	// ���i���[�J�[�R�[�h
                rst.MakerName = (string)dr[UOEOrderDtlSchema.ct_Col_MakerName];	// ���[�J�[����
                rst.GoodsNo = (string)dr[UOEOrderDtlSchema.ct_Col_GoodsNo];	// ���i�ԍ�
                rst.GoodsNoNoneHyphen = (string)dr[UOEOrderDtlSchema.ct_Col_GoodsNoNoneHyphen];	// �n�C�t�������i�ԍ�
                rst.GoodsName = (string)dr[UOEOrderDtlSchema.ct_Col_GoodsName];	// ���i����
                rst.WarehouseCode = (string)dr[UOEOrderDtlSchema.ct_Col_WarehouseCode];	// �q�ɃR�[�h
                rst.WarehouseName = (string)dr[UOEOrderDtlSchema.ct_Col_WarehouseName];	// �q�ɖ���
                rst.WarehouseShelfNo = (string)dr[UOEOrderDtlSchema.ct_Col_WarehouseShelfNo];	// �q�ɒI��
                rst.AcceptAnOrderCnt = (Double)dr[UOEOrderDtlSchema.ct_Col_AcceptAnOrderCnt];	// �󒍐���
                rst.ListPrice = (Double)dr[UOEOrderDtlSchema.ct_Col_ListPrice];	// �艿�i�����j
                rst.SalesUnitCost = (Double)dr[UOEOrderDtlSchema.ct_Col_SalesUnitCost];	// �����P��
                rst.SupplierCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_SupplierCd];	// �d����R�[�h
                rst.SupplierSnm = (string)dr[UOEOrderDtlSchema.ct_Col_SupplierSnm];	// �d���旪��
                rst.UoeRemark1 = (string)dr[UOEOrderDtlSchema.ct_Col_UoeRemark1];	// �t�n�d���}�[�N�P
                rst.UoeRemark2 = (string)dr[UOEOrderDtlSchema.ct_Col_UoeRemark2];	// �t�n�d���}�[�N�Q
                rst.ReceiveDate = (DateTime)dr[UOEOrderDtlSchema.ct_Col_ReceiveDate];	// ��M���t
                rst.ReceiveTime = (Int32)dr[UOEOrderDtlSchema.ct_Col_ReceiveTime];	// ��M����
                rst.AnswerMakerCd = (Int32)dr[UOEOrderDtlSchema.ct_Col_AnswerMakerCd];	// �񓚃��[�J�[�R�[�h
                rst.AnswerPartsNo = (string)dr[UOEOrderDtlSchema.ct_Col_AnswerPartsNo];	// �񓚕i��
                rst.AnswerPartsName = (string)dr[UOEOrderDtlSchema.ct_Col_AnswerPartsName];	// �񓚕i��
                rst.SubstPartsNo = (string)dr[UOEOrderDtlSchema.ct_Col_SubstPartsNo];	// ��֕i��
                rst.UOESectOutGoodsCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESectOutGoodsCnt];	// UOE���_�o�ɐ�
                rst.BOShipmentCnt1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt1];	// BO�o�ɐ�1
                rst.BOShipmentCnt2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt2];	// BO�o�ɐ�2
                rst.BOShipmentCnt3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOShipmentCnt3];	// BO�o�ɐ�3
                rst.MakerFollowCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_MakerFollowCnt];	// ���[�J�[�t�H���[��
                rst.NonShipmentCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_NonShipmentCnt];	// ���o�ɐ�
                rst.UOESectStockCnt = (Int32)dr[UOEOrderDtlSchema.ct_Col_UOESectStockCnt];	// UOE���_�݌ɐ�
                rst.BOStockCount1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOStockCount1];	// BO�݌ɐ�1
                rst.BOStockCount2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOStockCount2];	// BO�݌ɐ�2
                rst.BOStockCount3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOStockCount3];	// BO�݌ɐ�3
                rst.UOESectionSlipNo = (string)dr[UOEOrderDtlSchema.ct_Col_UOESectionSlipNo];	// UOE���_�`�[�ԍ�
                rst.BOSlipNo1 = (string)dr[UOEOrderDtlSchema.ct_Col_BOSlipNo1];	// BO�`�[�ԍ��P
                rst.BOSlipNo2 = (string)dr[UOEOrderDtlSchema.ct_Col_BOSlipNo2];	// BO�`�[�ԍ��Q
                rst.BOSlipNo3 = (string)dr[UOEOrderDtlSchema.ct_Col_BOSlipNo3];	// BO�`�[�ԍ��R
                rst.EOAlwcCount = (Int32)dr[UOEOrderDtlSchema.ct_Col_EOAlwcCount];	// EO������
                rst.BOManagementNo = (string)dr[UOEOrderDtlSchema.ct_Col_BOManagementNo];	// BO�Ǘ��ԍ�
                rst.AnswerListPrice = (Double)dr[UOEOrderDtlSchema.ct_Col_AnswerListPrice];	// �񓚒艿
                rst.AnswerSalesUnitCost = (Double)dr[UOEOrderDtlSchema.ct_Col_AnswerSalesUnitCost];	// �񓚌����P��
                rst.UOESubstMark = (string)dr[UOEOrderDtlSchema.ct_Col_UOESubstMark];	// UOE��փ}�[�N
                rst.UOEStockMark = (string)dr[UOEOrderDtlSchema.ct_Col_UOEStockMark];	// UOE�݌Ƀ}�[�N
                rst.PartsLayerCd = (string)dr[UOEOrderDtlSchema.ct_Col_PartsLayerCd];	// �w�ʃR�[�h
                rst.MazdaUOEShipSectCd1 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd1];	// UOE�o�׋��_�R�[�h�P�i�}�c�_�j
                rst.MazdaUOEShipSectCd2 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd2];	// UOE�o�׋��_�R�[�h�Q�i�}�c�_�j
                rst.MazdaUOEShipSectCd3 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEShipSectCd3];	// UOE�o�׋��_�R�[�h�R�i�}�c�_�j
                rst.MazdaUOESectCd1 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd1];	// UOE���_�R�[�h�P�i�}�c�_�j
                rst.MazdaUOESectCd2 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd2];	// UOE���_�R�[�h�Q�i�}�c�_�j
                rst.MazdaUOESectCd3 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd3];	// UOE���_�R�[�h�R�i�}�c�_�j
                rst.MazdaUOESectCd4 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd4];	// UOE���_�R�[�h�S�i�}�c�_�j
                rst.MazdaUOESectCd5 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd5];	// UOE���_�R�[�h�T�i�}�c�_�j
                rst.MazdaUOESectCd6 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd6];	// UOE���_�R�[�h�U�i�}�c�_�j
                rst.MazdaUOESectCd7 = (string)dr[UOEOrderDtlSchema.ct_Col_MazdaUOESectCd7];	// UOE���_�R�[�h�V�i�}�c�_�j
                rst.MazdaUOEStockCnt1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt1];	// UOE�݌ɐ��P�i�}�c�_�j
                rst.MazdaUOEStockCnt2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt2];	// UOE�݌ɐ��Q�i�}�c�_�j
                rst.MazdaUOEStockCnt3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt3];	// UOE�݌ɐ��R�i�}�c�_�j
                rst.MazdaUOEStockCnt4 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt4];	// UOE�݌ɐ��S�i�}�c�_�j
                rst.MazdaUOEStockCnt5 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt5];	// UOE�݌ɐ��T�i�}�c�_�j
                rst.MazdaUOEStockCnt6 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt6];	// UOE�݌ɐ��U�i�}�c�_�j
                rst.MazdaUOEStockCnt7 = (Int32)dr[UOEOrderDtlSchema.ct_Col_MazdaUOEStockCnt7];	// UOE�݌ɐ��V�i�}�c�_�j
                rst.UOEDistributionCd = (string)dr[UOEOrderDtlSchema.ct_Col_UOEDistributionCd];	// UOE���R�[�h
                rst.UOEOtherCd = (string)dr[UOEOrderDtlSchema.ct_Col_UOEOtherCd];	// UOE���R�[�h
                rst.UOEHMCd = (string)dr[UOEOrderDtlSchema.ct_Col_UOEHMCd];	// UOE�g�l�R�[�h
                rst.BOCount = (Int32)dr[UOEOrderDtlSchema.ct_Col_BOCount];	// �a�n��
                rst.UOEMarkCode = (string)dr[UOEOrderDtlSchema.ct_Col_UOEMarkCode];	// UOE�}�[�N�R�[�h
                rst.SourceShipment = (string)dr[UOEOrderDtlSchema.ct_Col_SourceShipment];	// �o�׌�
                rst.ItemCode = (string)dr[UOEOrderDtlSchema.ct_Col_ItemCode];	// �A�C�e���R�[�h
                rst.UOECheckCode = (string)dr[UOEOrderDtlSchema.ct_Col_UOECheckCode];	// UOE�`�F�b�N�R�[�h
                rst.HeadErrorMassage = (string)dr[UOEOrderDtlSchema.ct_Col_HeadErrorMassage];	// �w�b�h�G���[���b�Z�[�W
                rst.LineErrorMassage = (string)dr[UOEOrderDtlSchema.ct_Col_LineErrorMassage];	// ���C���G���[���b�Z�[�W
                rst.DataSendCode = (Int32)dr[UOEOrderDtlSchema.ct_Col_DataSendCode];	// �f�[�^���M�敪
                rst.DataRecoverDiv = (Int32)dr[UOEOrderDtlSchema.ct_Col_DataRecoverDiv];	// �f�[�^�����敪
                rst.EnterUpdDivSec = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivSec];	// ���ɍX�V�敪�i���_�j
                rst.EnterUpdDivBO1 = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO1];	// ���ɍX�V�敪�iBO1�j
                rst.EnterUpdDivBO2 = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO2];	// ���ɍX�V�敪�iBO2�j
                rst.EnterUpdDivBO3 = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivBO3];	// ���ɍX�V�敪�iBO3�j
                rst.EnterUpdDivMaker = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivMaker];	// ���ɍX�V�敪�iҰ���j
                rst.EnterUpdDivEO = (Int32)dr[UOEOrderDtlSchema.ct_Col_EnterUpdDivEO];	// ���ɍX�V�敪�iEO�j
                rst.DtlRelationGuid = (Guid)dr[UOEOrderDtlSchema.ct_Col_DtlRelationGuid];	// ���׊֘A�t��GUID
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
