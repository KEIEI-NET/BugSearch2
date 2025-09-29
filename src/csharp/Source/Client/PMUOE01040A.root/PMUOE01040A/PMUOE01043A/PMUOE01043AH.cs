//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �d�����׃A�N�Z�X�N���X
// �v���O�����T�v   : �d�����׃A�N�Z�X���s��
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
	/// �d�����׃A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d�����׃A�N�Z�X�N���X</br>
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
        # region �d�����ׂ̒ǉ���StockDetailWork���f�[�^�[�e�[�u����
        /// <summary>
        /// �d�����ׂ̒ǉ���StockDetailWork���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="stockDetailWork">�d�����׃f�[�^</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="commonSlipRowNo">���ʓ`�[�s�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int InsertTableFromStockDetailWork(DataTable tbl, StockDetailWork stockDetailWork, string commonSlipNo, Int32 commonSlipRowNo, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow dr = tbl.NewRow();
                CreateStockDetailSchema(ref dr, stockDetailWork, commonSlipNo, commonSlipRowNo);
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

        # region �d�����ׂ̍X�V���d�����ׁ��f�[�^�[�e�[�u����
        /// <summary>
        /// �d�����׍X�V���d�����ׁ��f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�[�e�[�u��</param>
        /// <param name="stockDetailWork">�d������</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromStockDetailWork(DataTable tbl, StockDetailWork stockDetailWork, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow stockDetailRow = FindStockDetailDataTable(tbl, stockDetailWork.SupplierFormal, stockDetailWork.DtlRelationGuid, out message);

                //�d�����׍X�V�̍X�V
                if (stockDetailRow != null)
                {
                    CreateStockDetailSchema(ref stockDetailRow, stockDetailWork);
                }
                else
                {
                    message = "�Y���̎d�����ׂ����݂��܂���B";
                    status = -1;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }

        /// <summary>
        /// �d�����ׂ̍X�V��StockDetailWork���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="stockDetailWork">�d�����׃f�[�^</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="commonSlipRowNo">���ʓ`�[�s�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromStockDetailWork(DataTable tbl, StockDetailWork stockDetailWork, string commonSlipNo, Int32 commonSlipRowNo, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow stockDetailRow = FindStockDetailDataTable(tbl, stockDetailWork.SupplierFormal, stockDetailWork.DtlRelationGuid, out message);

                //�d�����׍X�V�̍X�V
                if (stockDetailRow != null)
                {
                    CreateStockDetailSchema(ref stockDetailRow, stockDetailWork, commonSlipNo, commonSlipRowNo);
                }
                else
                {
                    status = InsertTableFromStockDetailWork(tbl, stockDetailWork, commonSlipNo, commonSlipRowNo, out message);
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

        # region �d�����ׂ̍X�V�����ʓ`�[�ԍ��E���ʓ`�[�s�ԍ���
        /// <summary>
        /// �d�����ׂ̍X�V�����ʓ`�[�ԍ��E���ʓ`�[�s�ԍ���
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="stockDetailWork">�d�����׃f�[�^</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="commonSlipRowNo">���ʓ`�[�s�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromStockDetailWork(DataTable tbl, Int32 supplierFormal, Guid dtlRelationGuid, string commonSlipNo, Int32 commonSlipRowNo, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow stockDetailRow = FindStockDetailDataTable(tbl, supplierFormal, dtlRelationGuid, out message);

                //�d�����׍X�V�̍X�V
                if (stockDetailRow != null)
                {
                    CreateStockDetailSchema(ref stockDetailRow, commonSlipNo, commonSlipRowNo);
                }
                else
                {
                    message = "�Y���̎d�����ׂ����݂��܂���B";
                    status = -1;
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

        # region �d�����׃��X�g�̍X�V��List<StockDetailWork>���f�[�^�[�e�[�u����
        /// <summary>
        /// �d�����׃��X�g�̍X�V��List<StockDetailWork>���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="list">�d�����׃f�[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromStockDetailList(DataTable tbl, List<StockDetailWork> list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (StockDetailWork stockDetailWork in list)
                {
                    status = UpdateTableFromStockDetailWork(tbl, stockDetailWork, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
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

        # region �d�����׃��X�g�̍X�V��ArrayList���f�[�^�[�e�[�u����
        /// <summary>
        /// �d�����׃��X�g�̍X�V��ArrayList���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="list">�d�����׃f�[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromStockDetailList(DataTable tbl, ArrayList list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (StockDetailWork stockDetailWork in list)
                {
                    status = UpdateTableFromStockDetailWork(tbl, stockDetailWork, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
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

        # region �d�����ׂ̓Ǎ�
        /// <summary>
        /// �d�����ׂ̓Ǎ�
        /// </summary>
        /// <param name="tbl">�f�[�^�[�e�[�u��</param>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="dtlRelationGuid">���׊֘A�t��GUID</param>
        /// <param name="stockDetailWork">�d�����׃I�u�W�F�N�g</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public  int ReadStockDetailWork(DataTable tbl, int supplierFormal, Guid dtlRelationGuid, out StockDetailWork stockDetailWork, out string commonSlipNo, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            stockDetailWork = null;
            commonSlipNo = "";

            try
            {
                DataRow stockDetailRow = FindStockDetailDataTable(tbl, supplierFormal, dtlRelationGuid, out message);
                stockDetailWork = CreateStockDetailWorkFromSchemaProc(stockDetailRow);
                commonSlipNo = (string)stockDetailRow[StockDetailSchema.ct_Col_CommonSlipNo];
            }
            catch (Exception ex)
            {
                stockDetailWork = null;
                commonSlipNo = "";
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region �d�����ׁ�DataRow �� �N���X���쐬
        /// <summary>
        /// �d�����ׁ�DataRow �� �N���X���쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <returns>�d������</returns>
        public StockDetailWork CreateStockDetailWorkFromSchema(DataRow dr)
        {
            return(CreateStockDetailWorkFromSchemaProc(dr));
        }
        # endregion

        # region �d�����׃��X�g�̎擾�FArrayList<StockDetailWork>
        /// <summary>
        /// �d�����׃��X�g�̎擾�FArrayList<StockDetailWork>
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="commonSlipNo">�d���`�[�ԍ�</param>
        /// <returns>�d�����׃��X�g</returns>
        public ArrayList SearchStockDetailDataTable(DataTable tbl, Int32 supplierFormal, string commonSlipNo)
        {
            ArrayList returnStockDetailAry = new ArrayList();
            try
            {
                string rowFilterText = string.Format("{0} = {1} AND {2} = '{3}'",
                                                StockDetailSchema.ct_Col_SupplierFormal, supplierFormal,
                                                StockDetailSchema.ct_Col_CommonSlipNo, commonSlipNo);

                string sortText = string.Format("{0}, {1}, {2}, {3}",
                    StockDetailSchema.ct_Col_EnterpriseCode,
                    StockDetailSchema.ct_Col_SupplierFormal,
                    StockDetailSchema.ct_Col_CommonSlipNo,
                    StockDetailSchema.ct_Col_CommonSlipRowNo);

                DataView viewStockDetail = new DataView(tbl);
                viewStockDetail.Sort = sortText;
                viewStockDetail.RowFilter = rowFilterText;

                if (viewStockDetail.Count > 0)
                {
                    foreach (DataRowView rowStockDetail in viewStockDetail)
                    {
                        StockDetailWork stockDetailWork = CreateStockDetailWorkFromSchema(rowStockDetail.Row);
                        returnStockDetailAry.Add(stockDetailWork);
                    }
                }
            }
            catch (Exception)
            {
                returnStockDetailAry = null;
            }
            return (returnStockDetailAry);
        }
        # endregion

        # region �d�����ׂɍs�ԍ���ݒ�
        /// <summary>
        /// �d�����ׂɍs�ԍ���ݒ�
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="commonSlipNo">�d���`�[�ԍ�</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int SetRowNoFromStockDetail(DataTable tbl, Int32 supplierFormal, string commonSlipNo, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //DataView�̍쐬
                string rowFilterText = string.Format("{0} = {1} AND {2} = '{3}'",
                                                StockDetailSchema.ct_Col_SupplierFormal, supplierFormal,
                                                StockDetailSchema.ct_Col_CommonSlipNo, commonSlipNo);

                string sortText = string.Format("{0}, {1}, {2}, {3}",
                    StockDetailSchema.ct_Col_EnterpriseCode,
                    StockDetailSchema.ct_Col_SupplierFormal,
                    StockDetailSchema.ct_Col_CommonSlipNo,
                    StockDetailSchema.ct_Col_CommonSlipRowNo);

                DataView viewStockDetail = new DataView(tbl);
                viewStockDetail.Sort = sortText;
                viewStockDetail.RowFilter = rowFilterText;

                if (viewStockDetail.Count == 0) return (status);


                Int32 stockRowNo = 0;
                foreach (DataRowView rowStockDetail in viewStockDetail)
                {
                    stockRowNo++;
                    rowStockDetail[StockDetailSchema.ct_Col_StockRowNo] = stockRowNo;
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

        # endregion

        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region �d�����ׂ̌���
        /// <summary>
        /// �d�����ׂ̌���
        /// </summary>
        /// <param name="tbl">�f�[�^�[�e�[�u��</param>
        /// <param name="supplierFormal">�d���`��</param>
        /// <param name="dtlRelationGuid">���׊֘A�t��GUID</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>DataRow</returns>
        private DataRow FindStockDetailDataTable(DataTable tbl, int supplierFormal, Guid dtlRelationGuid, out string message)
        {
            //�ϐ��̏�����
            DataRow stockDetailRow = null;
            message = "";

            try
            {
                //Find�p�����[�^�ݒ�
                object[] findStockDetail = new object[2];
                findStockDetail[0] = supplierFormal;
                findStockDetail[1] = dtlRelationGuid;
                stockDetailRow = tbl.Rows.Find(findStockDetail);
            }
            catch (Exception ex)
            {
                stockDetailRow = null;
                message = ex.Message;
            }

            return (stockDetailRow);
        }
        # endregion

        # region �d�����׃e�[�u��Row�쐬
        /// <summary>
        /// �d�����׃e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">�d�����׃N���X</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="commonSlipRowNo">���ʓ`�[�s�ԍ�</param>
        private void CreateStockDetailSchema(ref DataRow dr, StockDetailWork rst, string commonSlipNo, Int32 commonSlipRowNo)
        {
            CreateStockDetailSchema(ref dr, rst);
            CreateStockDetailSchema(ref dr, commonSlipNo, commonSlipRowNo);
        }

        /// <summary>
        /// �d�����׃e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="commonSlipNo">���ʓ`�[�ԍ�</param>
        /// <param name="commonSlipRowNo">���ʓ`�[�s�ԍ�</param>
        private void CreateStockDetailSchema(ref DataRow dr, string commonSlipNo, Int32 commonSlipRowNo)
        {
            dr[StockDetailSchema.ct_Col_CommonSlipNo] = commonSlipNo;
            dr[StockDetailSchema.ct_Col_CommonSlipRowNo] = commonSlipRowNo;
        }

        /// <summary>
        /// �d�����׃e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">�d�����׃N���X</param>
        private void CreateStockDetailSchema(ref DataRow dr, StockDetailWork rst)
        {
            dr[StockDetailSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// �쐬����
            dr[StockDetailSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// �X�V����
            dr[StockDetailSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// ��ƃR�[�h
            dr[StockDetailSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            dr[StockDetailSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// �X�V�]�ƈ��R�[�h
            dr[StockDetailSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// �X�V�A�Z���u��ID1
            dr[StockDetailSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// �X�V�A�Z���u��ID2
            dr[StockDetailSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// �_���폜�敪
            dr[StockDetailSchema.ct_Col_AcceptAnOrderNo] = rst.AcceptAnOrderNo;	// �󒍔ԍ�
            dr[StockDetailSchema.ct_Col_SupplierFormal] = rst.SupplierFormal;	// �d���`��
            dr[StockDetailSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo;	// �d���`�[�ԍ�
            dr[StockDetailSchema.ct_Col_StockRowNo] = rst.StockRowNo;	// �d���s�ԍ�
            dr[StockDetailSchema.ct_Col_SectionCode] = rst.SectionCode;	// ���_�R�[�h
            dr[StockDetailSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// ����R�[�h
            dr[StockDetailSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo;	// ���ʒʔ�
            dr[StockDetailSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum;	// �d�����גʔ�
            dr[StockDetailSchema.ct_Col_SupplierFormalSrc] = rst.SupplierFormalSrc;	// �d���`���i���j
            dr[StockDetailSchema.ct_Col_StockSlipDtlNumSrc] = rst.StockSlipDtlNumSrc;	// �d�����גʔԁi���j
            dr[StockDetailSchema.ct_Col_AcptAnOdrStatusSync] = rst.AcptAnOdrStatusSync;	// �󒍃X�e�[�^�X�i�����j
            dr[StockDetailSchema.ct_Col_SalesSlipDtlNumSync] = rst.SalesSlipDtlNumSync;	// ���㖾�גʔԁi�����j
            dr[StockDetailSchema.ct_Col_StockSlipCdDtl] = rst.StockSlipCdDtl;	// �d���`�[�敪�i���ׁj
            dr[StockDetailSchema.ct_Col_StockInputCode] = rst.StockInputCode;	// �d�����͎҃R�[�h
            dr[StockDetailSchema.ct_Col_StockInputName] = rst.StockInputName;	// �d�����͎Җ���
            dr[StockDetailSchema.ct_Col_StockAgentCode] = rst.StockAgentCode;	// �d���S���҃R�[�h
            dr[StockDetailSchema.ct_Col_StockAgentName] = rst.StockAgentName;	// �d���S���Җ���
            dr[StockDetailSchema.ct_Col_GoodsKindCode] = rst.GoodsKindCode;	// ���i����
            dr[StockDetailSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd;	// ���i���[�J�[�R�[�h
            dr[StockDetailSchema.ct_Col_MakerName] = rst.MakerName;	// ���[�J�[����
            dr[StockDetailSchema.ct_Col_MakerKanaName] = rst.MakerKanaName;	// ���[�J�[�J�i����
            dr[StockDetailSchema.ct_Col_CmpltMakerKanaName] = rst.CmpltMakerKanaName;	// ���[�J�[�J�i���́i�ꎮ�j
            dr[StockDetailSchema.ct_Col_GoodsNo] = rst.GoodsNo;	// ���i�ԍ�
            dr[StockDetailSchema.ct_Col_GoodsName] = rst.GoodsName;	// ���i����
            dr[StockDetailSchema.ct_Col_GoodsNameKana] = rst.GoodsNameKana;	// ���i���̃J�i
            dr[StockDetailSchema.ct_Col_GoodsLGroup] = rst.GoodsLGroup;	// ���i�啪�ރR�[�h
            dr[StockDetailSchema.ct_Col_GoodsLGroupName] = rst.GoodsLGroupName;	// ���i�啪�ޖ���
            dr[StockDetailSchema.ct_Col_GoodsMGroup] = rst.GoodsMGroup;	// ���i�����ރR�[�h
            dr[StockDetailSchema.ct_Col_GoodsMGroupName] = rst.GoodsMGroupName;	// ���i�����ޖ���
            dr[StockDetailSchema.ct_Col_BLGroupCode] = rst.BLGroupCode;	// BL�O���[�v�R�[�h
            dr[StockDetailSchema.ct_Col_BLGroupName] = rst.BLGroupName;	// BL�O���[�v�R�[�h����
            dr[StockDetailSchema.ct_Col_BLGoodsCode] = rst.BLGoodsCode;	// BL���i�R�[�h
            dr[StockDetailSchema.ct_Col_BLGoodsFullName] = rst.BLGoodsFullName;	// BL���i�R�[�h���́i�S�p�j
            dr[StockDetailSchema.ct_Col_EnterpriseGanreCode] = rst.EnterpriseGanreCode;	// ���Е��ރR�[�h
            dr[StockDetailSchema.ct_Col_EnterpriseGanreName] = rst.EnterpriseGanreName;	// ���Е��ޖ���
            dr[StockDetailSchema.ct_Col_WarehouseCode] = rst.WarehouseCode;	// �q�ɃR�[�h
            dr[StockDetailSchema.ct_Col_WarehouseName] = rst.WarehouseName;	// �q�ɖ���
            dr[StockDetailSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo;	// �q�ɒI��
            dr[StockDetailSchema.ct_Col_StockOrderDivCd] = rst.StockOrderDivCd;	// �d���݌Ɏ�񂹋敪
            dr[StockDetailSchema.ct_Col_OpenPriceDiv] = rst.OpenPriceDiv;	// �I�[�v�����i�敪
            dr[StockDetailSchema.ct_Col_GoodsRateRank] = rst.GoodsRateRank;	// ���i�|�������N
            dr[StockDetailSchema.ct_Col_CustRateGrpCode] = rst.CustRateGrpCode;	// ���Ӑ�|���O���[�v�R�[�h
            dr[StockDetailSchema.ct_Col_SuppRateGrpCode] = rst.SuppRateGrpCode;	// �d����|���O���[�v�R�[�h
            dr[StockDetailSchema.ct_Col_ListPriceTaxExcFl] = rst.ListPriceTaxExcFl;	// �艿�i�Ŕ��C�����j
            dr[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = rst.ListPriceTaxIncFl;	// �艿�i�ō��C�����j
            dr[StockDetailSchema.ct_Col_StockRate] = rst.StockRate;	// �d����
            dr[StockDetailSchema.ct_Col_RateSectStckUnPrc] = rst.RateSectStckUnPrc;	// �|���ݒ苒�_�i�d���P���j
            dr[StockDetailSchema.ct_Col_RateDivStckUnPrc] = rst.RateDivStckUnPrc;	// �|���ݒ�敪�i�d���P���j
            dr[StockDetailSchema.ct_Col_UnPrcCalcCdStckUnPrc] = rst.UnPrcCalcCdStckUnPrc;	// �P���Z�o�敪�i�d���P���j
            dr[StockDetailSchema.ct_Col_PriceCdStckUnPrc] = rst.PriceCdStckUnPrc;	// ���i�敪�i�d���P���j
            dr[StockDetailSchema.ct_Col_StdUnPrcStckUnPrc] = rst.StdUnPrcStckUnPrc;	// ��P���i�d���P���j
            dr[StockDetailSchema.ct_Col_FracProcUnitStcUnPrc] = rst.FracProcUnitStcUnPrc;	// �[�������P�ʁi�d���P���j
            dr[StockDetailSchema.ct_Col_FracProcStckUnPrc] = rst.FracProcStckUnPrc;	// �[�������i�d���P���j
            dr[StockDetailSchema.ct_Col_StockUnitPriceFl] = rst.StockUnitPriceFl;	// �d���P���i�Ŕ��C�����j
            dr[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = rst.StockUnitTaxPriceFl;	// �d���P���i�ō��C�����j
            dr[StockDetailSchema.ct_Col_StockUnitChngDiv] = rst.StockUnitChngDiv;	// �d���P���ύX�敪
            dr[StockDetailSchema.ct_Col_BfStockUnitPriceFl] = rst.BfStockUnitPriceFl;	// �ύX�O�d���P���i�����j
            dr[StockDetailSchema.ct_Col_BfListPrice] = rst.BfListPrice;	// �ύX�O�艿
            dr[StockDetailSchema.ct_Col_RateBLGoodsCode] = rst.RateBLGoodsCode;	// BL���i�R�[�h�i�|���j
            dr[StockDetailSchema.ct_Col_RateBLGoodsName] = rst.RateBLGoodsName;	// BL���i�R�[�h���́i�|���j
            dr[StockDetailSchema.ct_Col_RateGoodsRateGrpCd] = rst.RateGoodsRateGrpCd;	// ���i�|���O���[�v�R�[�h�i�|���j
            dr[StockDetailSchema.ct_Col_RateGoodsRateGrpNm] = rst.RateGoodsRateGrpNm;	// ���i�|���O���[�v���́i�|���j
            dr[StockDetailSchema.ct_Col_RateBLGroupCode] = rst.RateBLGroupCode;	// BL�O���[�v�R�[�h�i�|���j
            dr[StockDetailSchema.ct_Col_RateBLGroupName] = rst.RateBLGroupName;	// BL�O���[�v���́i�|���j
            dr[StockDetailSchema.ct_Col_StockCount] = rst.StockCount;	// �d����
            dr[StockDetailSchema.ct_Col_OrderCnt] = rst.OrderCnt;	// ��������
            dr[StockDetailSchema.ct_Col_OrderAdjustCnt] = rst.OrderAdjustCnt;	// ����������
            dr[StockDetailSchema.ct_Col_OrderRemainCnt] = rst.OrderRemainCnt;	// �����c��
            dr[StockDetailSchema.ct_Col_RemainCntUpdDate] = rst.RemainCntUpdDate;	// �c���X�V��
            dr[StockDetailSchema.ct_Col_StockPriceTaxExc] = rst.StockPriceTaxExc;	// �d�����z�i�Ŕ����j
            dr[StockDetailSchema.ct_Col_StockPriceTaxInc] = rst.StockPriceTaxInc;	// �d�����z�i�ō��݁j
            dr[StockDetailSchema.ct_Col_StockGoodsCd] = rst.StockGoodsCd;	// �d�����i�敪
            dr[StockDetailSchema.ct_Col_StockPriceConsTax] = rst.StockPriceConsTax;	// �d�����z����Ŋz
            dr[StockDetailSchema.ct_Col_TaxationCode] = rst.TaxationCode;	// �ېŋ敪
            dr[StockDetailSchema.ct_Col_StockDtiSlipNote1] = rst.StockDtiSlipNote1;	// �d���`�[���ה��l1
            dr[StockDetailSchema.ct_Col_SalesCustomerCode] = rst.SalesCustomerCode;	// �̔���R�[�h
            dr[StockDetailSchema.ct_Col_SalesCustomerSnm] = rst.SalesCustomerSnm;	// �̔��旪��
            dr[StockDetailSchema.ct_Col_SlipMemo1] = rst.SlipMemo1;	// �`�[�����P
            dr[StockDetailSchema.ct_Col_SlipMemo2] = rst.SlipMemo2;	// �`�[�����Q
            dr[StockDetailSchema.ct_Col_SlipMemo3] = rst.SlipMemo3;	// �`�[�����R
            dr[StockDetailSchema.ct_Col_InsideMemo1] = rst.InsideMemo1;	// �Г������P
            dr[StockDetailSchema.ct_Col_InsideMemo2] = rst.InsideMemo2;	// �Г������Q
            dr[StockDetailSchema.ct_Col_InsideMemo3] = rst.InsideMemo3;	// �Г������R
            dr[StockDetailSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// �d����R�[�h
            dr[StockDetailSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// �d���旪��
            dr[StockDetailSchema.ct_Col_AddresseeCode] = rst.AddresseeCode;	// �[�i��R�[�h
            dr[StockDetailSchema.ct_Col_AddresseeName] = rst.AddresseeName;	// �[�i�於��
            dr[StockDetailSchema.ct_Col_DirectSendingCd] = rst.DirectSendingCd;	// �����敪
            dr[StockDetailSchema.ct_Col_OrderNumber] = rst.OrderNumber;	// �����ԍ�
            dr[StockDetailSchema.ct_Col_WayToOrder] = rst.WayToOrder;	// �������@
            dr[StockDetailSchema.ct_Col_DeliGdsCmpltDueDate] = rst.DeliGdsCmpltDueDate;	// �[�i�����\���
            dr[StockDetailSchema.ct_Col_ExpectDeliveryDate] = rst.ExpectDeliveryDate;	// ��]�[��
            dr[StockDetailSchema.ct_Col_OrderDataCreateDiv] = rst.OrderDataCreateDiv;	// �����f�[�^�쐬�敪
            dr[StockDetailSchema.ct_Col_OrderDataCreateDate] = rst.OrderDataCreateDate;	// �����f�[�^�쐬��
            dr[StockDetailSchema.ct_Col_OrderFormIssuedDiv] = rst.OrderFormIssuedDiv;	// ���������s�ϋ敪
            dr[StockDetailSchema.ct_Col_StockCountDifference] = rst.StockCountDifference;	// �d��������
            dr[StockDetailSchema.ct_Col_DtlRelationGuid] = rst.DtlRelationGuid;	// ���׊֘A�t��GUID
        }
        # endregion

        # region �d�����ׁ�DataRow �� �N���X���쐬
        /// <summary>
        /// �d�����ׁ�DataRow �� �N���X���쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <returns>�d������</returns>
        private StockDetailWork CreateStockDetailWorkFromSchemaProc(DataRow dr)
        {
            StockDetailWork rst = new StockDetailWork();

            try
            {
                rst.CreateDateTime = (DateTime)dr[StockDetailSchema.ct_Col_CreateDateTime];	// �쐬����
                rst.UpdateDateTime = (DateTime)dr[StockDetailSchema.ct_Col_UpdateDateTime];	// �X�V����
                rst.EnterpriseCode = (string)dr[StockDetailSchema.ct_Col_EnterpriseCode];	// ��ƃR�[�h
                rst.FileHeaderGuid = (Guid)dr[StockDetailSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[StockDetailSchema.ct_Col_UpdEmployeeCode];	// �X�V�]�ƈ��R�[�h
                rst.UpdAssemblyId1 = (string)dr[StockDetailSchema.ct_Col_UpdAssemblyId1];	// �X�V�A�Z���u��ID1
                rst.UpdAssemblyId2 = (string)dr[StockDetailSchema.ct_Col_UpdAssemblyId2];	// �X�V�A�Z���u��ID2
                rst.LogicalDeleteCode = (Int32)dr[StockDetailSchema.ct_Col_LogicalDeleteCode];	// �_���폜�敪
                rst.AcceptAnOrderNo = (Int32)dr[StockDetailSchema.ct_Col_AcceptAnOrderNo];	// �󒍔ԍ�
                rst.SupplierFormal = (Int32)dr[StockDetailSchema.ct_Col_SupplierFormal];	// �d���`��
                rst.SupplierSlipNo = (Int32)dr[StockDetailSchema.ct_Col_SupplierSlipNo];	// �d���`�[�ԍ�
                rst.StockRowNo = (Int32)dr[StockDetailSchema.ct_Col_StockRowNo];	// �d���s�ԍ�
                rst.SectionCode = (string)dr[StockDetailSchema.ct_Col_SectionCode];	// ���_�R�[�h
                rst.SubSectionCode = (Int32)dr[StockDetailSchema.ct_Col_SubSectionCode];	// ����R�[�h
                rst.CommonSeqNo = (Int64)dr[StockDetailSchema.ct_Col_CommonSeqNo];	// ���ʒʔ�
                rst.StockSlipDtlNum = (Int64)dr[StockDetailSchema.ct_Col_StockSlipDtlNum];	// �d�����גʔ�
                rst.SupplierFormalSrc = (Int32)dr[StockDetailSchema.ct_Col_SupplierFormalSrc];	// �d���`���i���j
                rst.StockSlipDtlNumSrc = (Int64)dr[StockDetailSchema.ct_Col_StockSlipDtlNumSrc];	// �d�����גʔԁi���j
                rst.AcptAnOdrStatusSync = (Int32)dr[StockDetailSchema.ct_Col_AcptAnOdrStatusSync];	// �󒍃X�e�[�^�X�i�����j
                rst.SalesSlipDtlNumSync = (Int64)dr[StockDetailSchema.ct_Col_SalesSlipDtlNumSync];	// ���㖾�גʔԁi�����j
                rst.StockSlipCdDtl = (Int32)dr[StockDetailSchema.ct_Col_StockSlipCdDtl];	// �d���`�[�敪�i���ׁj
                rst.StockInputCode = (string)dr[StockDetailSchema.ct_Col_StockInputCode];	// �d�����͎҃R�[�h
                rst.StockInputName = (string)dr[StockDetailSchema.ct_Col_StockInputName];	// �d�����͎Җ���
                rst.StockAgentCode = (string)dr[StockDetailSchema.ct_Col_StockAgentCode];	// �d���S���҃R�[�h
                rst.StockAgentName = (string)dr[StockDetailSchema.ct_Col_StockAgentName];	// �d���S���Җ���
                rst.GoodsKindCode = (Int32)dr[StockDetailSchema.ct_Col_GoodsKindCode];	// ���i����
                rst.GoodsMakerCd = (Int32)dr[StockDetailSchema.ct_Col_GoodsMakerCd];	// ���i���[�J�[�R�[�h
                rst.MakerName = (string)dr[StockDetailSchema.ct_Col_MakerName];	// ���[�J�[����
                rst.MakerKanaName = (string)dr[StockDetailSchema.ct_Col_MakerKanaName];	// ���[�J�[�J�i����
                rst.CmpltMakerKanaName = (string)dr[StockDetailSchema.ct_Col_CmpltMakerKanaName];	// ���[�J�[�J�i���́i�ꎮ�j
                rst.GoodsNo = (string)dr[StockDetailSchema.ct_Col_GoodsNo];	// ���i�ԍ�
                rst.GoodsName = (string)dr[StockDetailSchema.ct_Col_GoodsName];	// ���i����
                rst.GoodsNameKana = (string)dr[StockDetailSchema.ct_Col_GoodsNameKana];	// ���i���̃J�i
                rst.GoodsLGroup = (Int32)dr[StockDetailSchema.ct_Col_GoodsLGroup];	// ���i�啪�ރR�[�h
                rst.GoodsLGroupName = (string)dr[StockDetailSchema.ct_Col_GoodsLGroupName];	// ���i�啪�ޖ���
                rst.GoodsMGroup = (Int32)dr[StockDetailSchema.ct_Col_GoodsMGroup];	// ���i�����ރR�[�h
                rst.GoodsMGroupName = (string)dr[StockDetailSchema.ct_Col_GoodsMGroupName];	// ���i�����ޖ���
                rst.BLGroupCode = (Int32)dr[StockDetailSchema.ct_Col_BLGroupCode];	// BL�O���[�v�R�[�h
                rst.BLGroupName = (string)dr[StockDetailSchema.ct_Col_BLGroupName];	// BL�O���[�v�R�[�h����
                rst.BLGoodsCode = (Int32)dr[StockDetailSchema.ct_Col_BLGoodsCode];	// BL���i�R�[�h
                rst.BLGoodsFullName = (string)dr[StockDetailSchema.ct_Col_BLGoodsFullName];	// BL���i�R�[�h���́i�S�p�j
                rst.EnterpriseGanreCode = (Int32)dr[StockDetailSchema.ct_Col_EnterpriseGanreCode];	// ���Е��ރR�[�h
                rst.EnterpriseGanreName = (string)dr[StockDetailSchema.ct_Col_EnterpriseGanreName];	// ���Е��ޖ���
                rst.WarehouseCode = (string)dr[StockDetailSchema.ct_Col_WarehouseCode];	// �q�ɃR�[�h
                rst.WarehouseName = (string)dr[StockDetailSchema.ct_Col_WarehouseName];	// �q�ɖ���
                rst.WarehouseShelfNo = (string)dr[StockDetailSchema.ct_Col_WarehouseShelfNo];	// �q�ɒI��
                rst.StockOrderDivCd = (Int32)dr[StockDetailSchema.ct_Col_StockOrderDivCd];	// �d���݌Ɏ�񂹋敪
                rst.OpenPriceDiv = (Int32)dr[StockDetailSchema.ct_Col_OpenPriceDiv];	// �I�[�v�����i�敪
                rst.GoodsRateRank = (string)dr[StockDetailSchema.ct_Col_GoodsRateRank];	// ���i�|�������N
                rst.CustRateGrpCode = (Int32)dr[StockDetailSchema.ct_Col_CustRateGrpCode];	// ���Ӑ�|���O���[�v�R�[�h
                rst.SuppRateGrpCode = (Int32)dr[StockDetailSchema.ct_Col_SuppRateGrpCode];	// �d����|���O���[�v�R�[�h
                rst.ListPriceTaxExcFl = (Double)dr[StockDetailSchema.ct_Col_ListPriceTaxExcFl];	// �艿�i�Ŕ��C�����j
                rst.ListPriceTaxIncFl = (Double)dr[StockDetailSchema.ct_Col_ListPriceTaxIncFl];	// �艿�i�ō��C�����j
                rst.StockRate = (Double)dr[StockDetailSchema.ct_Col_StockRate];	// �d����
                rst.RateSectStckUnPrc = (string)dr[StockDetailSchema.ct_Col_RateSectStckUnPrc];	// �|���ݒ苒�_�i�d���P���j
                rst.RateDivStckUnPrc = (string)dr[StockDetailSchema.ct_Col_RateDivStckUnPrc];	// �|���ݒ�敪�i�d���P���j
                rst.UnPrcCalcCdStckUnPrc = (Int32)dr[StockDetailSchema.ct_Col_UnPrcCalcCdStckUnPrc];	// �P���Z�o�敪�i�d���P���j
                rst.PriceCdStckUnPrc = (Int32)dr[StockDetailSchema.ct_Col_PriceCdStckUnPrc];	// ���i�敪�i�d���P���j
                rst.StdUnPrcStckUnPrc = (Double)dr[StockDetailSchema.ct_Col_StdUnPrcStckUnPrc];	// ��P���i�d���P���j
                rst.FracProcUnitStcUnPrc = (Double)dr[StockDetailSchema.ct_Col_FracProcUnitStcUnPrc];	// �[�������P�ʁi�d���P���j
                rst.FracProcStckUnPrc = (Int32)dr[StockDetailSchema.ct_Col_FracProcStckUnPrc];	// �[�������i�d���P���j
                rst.StockUnitPriceFl = (Double)dr[StockDetailSchema.ct_Col_StockUnitPriceFl];	// �d���P���i�Ŕ��C�����j
                rst.StockUnitTaxPriceFl = (Double)dr[StockDetailSchema.ct_Col_StockUnitTaxPriceFl];	// �d���P���i�ō��C�����j
                rst.StockUnitChngDiv = (Int32)dr[StockDetailSchema.ct_Col_StockUnitChngDiv];	// �d���P���ύX�敪
                rst.BfStockUnitPriceFl = (Double)dr[StockDetailSchema.ct_Col_BfStockUnitPriceFl];	// �ύX�O�d���P���i�����j
                rst.BfListPrice = (Double)dr[StockDetailSchema.ct_Col_BfListPrice];	// �ύX�O�艿
                rst.RateBLGoodsCode = (Int32)dr[StockDetailSchema.ct_Col_RateBLGoodsCode];	// BL���i�R�[�h�i�|���j
                rst.RateBLGoodsName = (string)dr[StockDetailSchema.ct_Col_RateBLGoodsName];	// BL���i�R�[�h���́i�|���j
                rst.RateGoodsRateGrpCd = (Int32)dr[StockDetailSchema.ct_Col_RateGoodsRateGrpCd];	// ���i�|���O���[�v�R�[�h�i�|���j
                rst.RateGoodsRateGrpNm = (string)dr[StockDetailSchema.ct_Col_RateGoodsRateGrpNm];	// ���i�|���O���[�v���́i�|���j
                rst.RateBLGroupCode = (Int32)dr[StockDetailSchema.ct_Col_RateBLGroupCode];	// BL�O���[�v�R�[�h�i�|���j
                rst.RateBLGroupName = (string)dr[StockDetailSchema.ct_Col_RateBLGroupName];	// BL�O���[�v���́i�|���j
                rst.StockCount = (Double)dr[StockDetailSchema.ct_Col_StockCount];	// �d����
                rst.OrderCnt = (Double)dr[StockDetailSchema.ct_Col_OrderCnt];	// ��������
                rst.OrderAdjustCnt = (Double)dr[StockDetailSchema.ct_Col_OrderAdjustCnt];	// ����������
                rst.OrderRemainCnt = (Double)dr[StockDetailSchema.ct_Col_OrderRemainCnt];	// �����c��
                rst.RemainCntUpdDate = (DateTime)dr[StockDetailSchema.ct_Col_RemainCntUpdDate];	// �c���X�V��
                rst.StockPriceTaxExc = (Int64)dr[StockDetailSchema.ct_Col_StockPriceTaxExc];	// �d�����z�i�Ŕ����j
                rst.StockPriceTaxInc = (Int64)dr[StockDetailSchema.ct_Col_StockPriceTaxInc];	// �d�����z�i�ō��݁j
                rst.StockGoodsCd = (Int32)dr[StockDetailSchema.ct_Col_StockGoodsCd];	// �d�����i�敪
                rst.StockPriceConsTax = (Int64)dr[StockDetailSchema.ct_Col_StockPriceConsTax];	// �d�����z����Ŋz
                rst.TaxationCode = (Int32)dr[StockDetailSchema.ct_Col_TaxationCode];	// �ېŋ敪
                rst.StockDtiSlipNote1 = (string)dr[StockDetailSchema.ct_Col_StockDtiSlipNote1];	// �d���`�[���ה��l1
                rst.SalesCustomerCode = (Int32)dr[StockDetailSchema.ct_Col_SalesCustomerCode];	// �̔���R�[�h
                rst.SalesCustomerSnm = (string)dr[StockDetailSchema.ct_Col_SalesCustomerSnm];	// �̔��旪��
                rst.SlipMemo1 = (string)dr[StockDetailSchema.ct_Col_SlipMemo1];	// �`�[�����P
                rst.SlipMemo2 = (string)dr[StockDetailSchema.ct_Col_SlipMemo2];	// �`�[�����Q
                rst.SlipMemo3 = (string)dr[StockDetailSchema.ct_Col_SlipMemo3];	// �`�[�����R
                rst.InsideMemo1 = (string)dr[StockDetailSchema.ct_Col_InsideMemo1];	// �Г������P
                rst.InsideMemo2 = (string)dr[StockDetailSchema.ct_Col_InsideMemo2];	// �Г������Q
                rst.InsideMemo3 = (string)dr[StockDetailSchema.ct_Col_InsideMemo3];	// �Г������R
                rst.SupplierCd = (Int32)dr[StockDetailSchema.ct_Col_SupplierCd];	// �d����R�[�h
                rst.SupplierSnm = (string)dr[StockDetailSchema.ct_Col_SupplierSnm];	// �d���旪��
                rst.AddresseeCode = (Int32)dr[StockDetailSchema.ct_Col_AddresseeCode];	// �[�i��R�[�h
                rst.AddresseeName = (string)dr[StockDetailSchema.ct_Col_AddresseeName];	// �[�i�於��
                rst.DirectSendingCd = (Int32)dr[StockDetailSchema.ct_Col_DirectSendingCd];	// �����敪
                rst.OrderNumber = (string)dr[StockDetailSchema.ct_Col_OrderNumber];	// �����ԍ�
                rst.WayToOrder = (Int32)dr[StockDetailSchema.ct_Col_WayToOrder];	// �������@
                rst.DeliGdsCmpltDueDate = (DateTime)dr[StockDetailSchema.ct_Col_DeliGdsCmpltDueDate];	// �[�i�����\���
                rst.ExpectDeliveryDate = (DateTime)dr[StockDetailSchema.ct_Col_ExpectDeliveryDate];	// ��]�[��
                rst.OrderDataCreateDiv = (Int32)dr[StockDetailSchema.ct_Col_OrderDataCreateDiv];	// �����f�[�^�쐬�敪
                rst.OrderDataCreateDate = (DateTime)dr[StockDetailSchema.ct_Col_OrderDataCreateDate];	// �����f�[�^�쐬��
                rst.OrderFormIssuedDiv = (Int32)dr[StockDetailSchema.ct_Col_OrderFormIssuedDiv];	// ���������s�ϋ敪
                rst.StockCountDifference = (Double)dr[StockDetailSchema.ct_Col_StockCountDifference];	// �d��������
                rst.DtlRelationGuid = (Guid)dr[StockDetailSchema.ct_Col_DtlRelationGuid];	// ���׊֘A�t��GUID
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
