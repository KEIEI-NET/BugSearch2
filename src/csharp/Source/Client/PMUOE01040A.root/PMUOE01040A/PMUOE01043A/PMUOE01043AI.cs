//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���㖾�׃A�N�Z�X�N���X
// �v���O�����T�v   : ���㖾�׃A�N�Z�X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2011/01/19  �C�����e : Mantis.16772 SCM���ڂ����M�����Ŕ���f�[�^�ɃZ�b�g����Ȃ����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2011/07/28  �C�����e : �����񓚋敪�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/01/16  �C�����e : SCM���ǁE���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/12/06  �C�����e : SCM��Q��10447�Ή�
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
	/// ���㖾�׃A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���㖾�׃A�N�Z�X�N���X</br>
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

        # region �����㖾��
        # region ���㖾�׍쐬���f�[�^���X�g���f�[�^�[�e�[�u����
        /// <summary>
        /// ���㖾�ׁ��f�[�^���X�g���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="list">���㖾�׃f�[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int ToDataTableFromSalesDetailWork(DataTable tbl, List<SalesDetailWork> list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                tbl.Clear();

                foreach (SalesDetailWork rst in list)
                {
                    //����M�i�m�k�̕ۑ�
                    DataRow dr = tbl.NewRow();
                    CreateSalesDetailSchema(ref dr, rst);
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

        # region ���㖾�׍X�V��ArrayList���f�[�^�[�e�[�u����
        /// <summary>
        /// ���㖾�׍X�V��ArrayList���f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="list">���㖾�׃f�[�^���X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromSalesDetailList(DataTable tbl, ArrayList list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (SalesDetailWork rst in list)
                {
                    status = UpdateTableFromSalesDetailWork(tbl, rst, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
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

        # region ���㖾�׍X�V�����㖾�ׁ��f�[�^�[�e�[�u����
        /// <summary>
        /// ���㖾�׍X�V�����㖾�ׁ��f�[�^�[�e�[�u����
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="salesDetailWork">���㖾��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int UpdateTableFromSalesDetailWork(DataTable tbl, SalesDetailWork salesDetailWork, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //Find�p�����[�^�ݒ�
                object[] findSalesDetail = new object[2];
                findSalesDetail[0] = salesDetailWork.AcptAnOdrStatus;
                findSalesDetail[1] = salesDetailWork.DtlRelationGuid;

                DataRow salesDetailRow = tbl.Rows.Find(findSalesDetail);

                //���㖾�׍X�V�̍X�V
                if (salesDetailRow != null)
                {
                    CreateSalesDetailSchema(ref salesDetailRow, salesDetailWork);
                }
                //���㖾�׍X�V�̒ǉ�
                else
                {
                    DataRow dr = tbl.NewRow();
                    CreateSalesDetailSchema(ref dr, salesDetailWork);
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

        # region ����`�[�ԍ��i���j�̎擾
        /// <summary>
        /// ����`�[�ԍ��i���j�̎擾
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="salesDetailWork">���㖾��</param>
        /// <returns>����`�[�ԍ��i���j</returns>
        public string GetTempSalesSlipNumFromSalesDetailWork(DataTable tbl, SalesDetailWork salesDetailWork)
        {
            //�ϐ��̏�����
            string tempSalesSlipNum = String.Empty;

            try
            {
                //Find�p�����[�^�ݒ�
                object[] findSalesDetail = new object[2];
                findSalesDetail[0] = salesDetailWork.AcptAnOdrStatus;
                findSalesDetail[1] = salesDetailWork.DtlRelationGuid;
                DataRow salesDetailRow = tbl.Rows.Find(findSalesDetail);

                tempSalesSlipNum = (string)salesDetailRow[SalesDetailSchema.ct_Col_TempSalesSlipNum];

            }
            catch (Exception)
            {
                tempSalesSlipNum = String.Empty;
            }

            return (tempSalesSlipNum);
        }
        # endregion

        # region ���㖾�ׁ�DataRow �� �N���X���쐬
        /// <summary>
        /// ���㖾�ׁ�DataRow �� �N���X���쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <returns>���㖾��</returns>
        public SalesDetailWork CreateSalesDetailWorkFromSchema(DataRow dr)
        {
            return(CreateSalesDetailWorkFromSchemaProc(dr));
        }

        # endregion

        # region ���㖾�׌�����DataRow �� ArrayList<SalesDetailWork>��
        /// <summary>
        /// ���㖾�׌�����DataRow �� ArrayList<SalesDetailWork>��
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="acptAnOdrStatus">����`��</param>
        /// <param name="tempSalesSlipNum">����`�[�ԍ�</param>
        /// <param name="chkCount">0:�S�� 1:�o�א����P�ȏ�</param>
        /// <returns>���㖾��</returns>
        public ArrayList SearchSalesDetailDataTable(DataTable tbl, Int32 acptAnOdrStatus, string tempSalesSlipNum, Int32 chkCount)
        {
            ArrayList returnSalesDetailAry = new ArrayList();
            try
            {
                DataView viewSalesDetail = SearchSalesDetailCreateView(tbl, acptAnOdrStatus, tempSalesSlipNum, chkCount);

                if (viewSalesDetail.Count > 0)
                {
                    foreach (DataRowView rowSalesDetail in viewSalesDetail)
                    {
                        SalesDetailWork salesDetailWork = CreateSalesDetailWorkFromSchema(rowSalesDetail.Row);
                        returnSalesDetailAry.Add(salesDetailWork);
                    }
                }
            }
            catch (Exception)
            {
                returnSalesDetailAry = null;
            }
            return (returnSalesDetailAry);
        }
        # endregion

        # region ���㖾�ׂɍs�ԍ���ݒ�
        /// <summary>
        /// ���㖾�ׂɍs�ԍ���ݒ�
        /// </summary>
        /// <param name="acptAnOdrStatus">����`��</param>
        /// <param name="tempSalesSlipNum">����`�[�ԍ�</param>
        /// <param name="chkCount">0:�S�� 1:�o�א����P�ȏ�</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SetRowNoFromSalesDetail(Int32 acptAnOdrStatus, string tempSalesSlipNum, Int32 chkCount, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataView viewSalesDetail = SearchSalesDetailCreateView(SalesDetailTable, acptAnOdrStatus, tempSalesSlipNum, chkCount);
                status = SetRowNoFromSalesDetail(viewSalesDetail, out message);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }

        /// <summary>
        /// ���㖾�ׂɍs�ԍ���ݒ�
        /// </summary>
        /// <param name="viewSalesDetail">(DataView)���㖾��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SetRowNoFromSalesDetail(DataView viewSalesDetail, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                if (viewSalesDetail == null) return (status);
                if (viewSalesDetail.Count == 0) return (status);

                Int32 salesRowNo = 0;
                foreach (DataRowView rowSalesDetail in viewSalesDetail)
                {
                    salesRowNo++;
                    rowSalesDetail[SalesDetailSchema.ct_Col_SalesRowNo] = salesRowNo;
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

        # region ���㖾�׌�����DataRow �� List<UoeSalesDetail>��
        /// <summary>
        /// ���㖾�׌�����DataRow �� List<SalesDetailWork>��
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="acptAnOdrStatus">����`��</param>
        /// <param name="tempSalesSlipNum">����`�[�ԍ�</param>
        /// <param name="chkCount">0:�S�� 1:�o�א����P�ȏ�</param>
        /// <returns>���㖾��</returns>
        public List<UoeSalesDetail> SearchUoeSalesDetailDataTable(DataTable tbl, Int32 acptAnOdrStatus, string tempSalesSlipNum, Int32 chkCount)
        {
            List<UoeSalesDetail> uoeSalesDetailList = new List<UoeSalesDetail>();
            try
            {
                DataView viewSalesDetail = SearchSalesDetailCreateView(tbl, acptAnOdrStatus, tempSalesSlipNum, chkCount);

                if (viewSalesDetail.Count > 0)
                {
                    foreach (DataRowView rowSalesDetail in viewSalesDetail)
                    {
                        UoeSalesDetail uoeSalesDetail = new UoeSalesDetail();
                        uoeSalesDetail.salesDetailWork = CreateSalesDetailWorkFromSchemaProc(rowSalesDetail.Row);
                        uoeSalesDetail.prtSalesDetail = CreatePrtSalesDetailFromSchemaProc(rowSalesDetail.Row);
                         
                        uoeSalesDetailList.Add(uoeSalesDetail);
                    }
                }
            }
            catch (Exception)
            {
                uoeSalesDetailList = null;
            }
            return (uoeSalesDetailList);
        }
        # endregion

        # region ���㖾�גǉ���SalesDetailWork��AcptDetailTable��
        /// <summary>
        /// ���㖾�גǉ���SalesDetailWork��AcptDetailTable��
        /// </summary>
        /// <param name="salesDetailWork">���㖾��</param>
        /// <param name="tempSalesSlipNum">����`�[�ԍ��i���j</param>
        /// <param name="tempSalesSlipDtlNum">���㖾�גʔԁi���j</param>
        /// <param name="prtSalesDetail"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int InsertSalesDetailDataTable(SalesDetailWork salesDetailWork, string tempSalesSlipNum, Int64 tempSalesSlipDtlNum, PrtSalesDetail prtSalesDetail, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow dr = SalesDetailTable.NewRow();
                CreateSalesDetailSchema(ref dr, salesDetailWork, tempSalesSlipNum, tempSalesSlipDtlNum, prtSalesDetail);
                SalesDetailTable.Rows.Add(dr);
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

        # region ���󒍖���
        # region �󒍖��׃��X�g�ǉ���ArrayList��AcptDetailTable��
        /// <summary>
        /// �󒍖��׃��X�g�ǉ���ArrayList��AcptDetailTable��
        /// </summary>
        /// <param name="list">�󒍖��׃��X�g</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int InsertAcptDtlTblFromSalesDetailAry(ArrayList list, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (SalesDetailWork salesDetailWork in list)
                {
                    status = InsertAcptDtlTblFromSalesDetailWork(salesDetailWork, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
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

        # region �󒍖��גǉ���SalesDetailWork��AcptDetailTable��
        /// <summary>
        /// �󒍖��גǉ���SalesDetailWork��AcptDetailTable��
        /// </summary>
        /// <param name="salesDetailWork">�󒍖���</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int InsertAcptDtlTblFromSalesDetailWork(SalesDetailWork salesDetailWork, out string message)
        {
            //�ϐ��̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow dr = AcptDetailTable.NewRow();
                CreateSalesDetailSchema(ref dr, salesDetailWork);
                AcptDetailTable.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region �󒍖��ׂq�d�`�c
        /// <summary>
        /// �󒍖��ׂq�d�`�c
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipDtlNum">���㖾�גʔ�</param>
        /// <returns>���㖾�׃N���X</returns>
        public SalesDetailWork ReadSalesDetailDataTable(Int32 acptAnOdrStatus, Int64 salesSlipDtlNum)
        {
            SalesDetailWork salesDetail = null;

            try
            {
                object[] findSalesDetail = new object[2];
                findSalesDetail[0] = acptAnOdrStatus;
                findSalesDetail[1] = salesSlipDtlNum;
                DataRow salesDetailRow = AcptDetailTable.Rows.Find(findSalesDetail);
                salesDetail = CreateSalesDetailWorkFromSchemaProc(salesDetailRow);
            }
            catch (Exception)
            {
                salesDetail = null;
            }

            return (salesDetail);
        }
        # endregion
        # endregion

        # endregion

        // ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods
        # region ���㖾�׌���DataView�쐬
        /// <summary>
        /// ���㖾�׌���DataView�쐬
        /// </summary>
        /// <param name="tbl">�f�[�^�e�[�u��</param>
        /// <param name="acptAnOdrStatus">����`��</param>
        /// <param name="tempSalesSlipNum">����`�[�ԍ�</param>
        /// <param name="chkCount">0:�S�� 1:�o�א����P�ȏ�</param>
        /// <returns>���㖾�׌���DataView</returns>
        public DataView SearchSalesDetailCreateView(DataTable tbl, Int32 acptAnOdrStatus, string tempSalesSlipNum, int chkCount)
        {
            DataView viewSalesDetail = new DataView(tbl);
            try
            {
                string rowFilterText = String.Empty;


                if (chkCount != 0)
                {
                    rowFilterText = string.Format("{0} = {1} AND {2} = '{3}' AND {4} <> {5}",
                                                    SalesDetailSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                    SalesDetailSchema.ct_Col_TempSalesSlipNum, tempSalesSlipNum,
                                                    SalesDetailSchema.ct_Col_PrtShipmentCnt, 0);
                }
                else
                {
                    rowFilterText = string.Format("{0} = {1} AND {2} = '{3}'",
                                                    SalesDetailSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                    SalesDetailSchema.ct_Col_TempSalesSlipNum, tempSalesSlipNum);
                }

                string sortText = string.Format("{0}, {1}, {2}, {3}",
                    SalesDetailSchema.ct_Col_EnterpriseCode,
                    SalesDetailSchema.ct_Col_AcptAnOdrStatus,
                    SalesDetailSchema.ct_Col_TempSalesSlipNum,
                    SalesDetailSchema.ct_Col_TempSalesSlipDtlNum);

                viewSalesDetail.Sort = sortText;
                viewSalesDetail.RowFilter = rowFilterText;

            }
            catch (Exception)
            {
                viewSalesDetail = null;
            }
            return (viewSalesDetail);
        }
        # endregion

        # region ���㖾�׃e�[�u��Row�쐬
        /// <summary>
        /// ���㖾�׃e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">���㖾�׃N���X</param>
        private void CreateSalesDetailSchema(ref DataRow dr, SalesDetailWork rst, string tempSalesSlipNum, Int64 tempSalesSlipDtlNum, PrtSalesDetail prtSalesDetail)
        {
            CreateSalesDetailSchema(ref dr, rst);

            dr[SalesDetailSchema.ct_Col_TempSalesSlipNum] = tempSalesSlipNum;	                        // ����`�[�ԍ��i���j
            dr[SalesDetailSchema.ct_Col_TempSalesSlipDtlNum] = tempSalesSlipDtlNum;	                    // ���㖾�גʔԁi���j


            dr[SalesDetailSchema.ct_Col_PrtReceiveTime] = prtSalesDetail.prtReceiveTime;                    // (����p)��M����
            dr[SalesDetailSchema.ct_Col_PrtBoCode] = prtSalesDetail.prtBoCode;                              // (����p)BO�敪
            dr[SalesDetailSchema.ct_Col_PrtUOEDeliGoodsDiv] = prtSalesDetail.prtUOEDeliGoodsDiv;            // (����p)UOE�[�i�敪
            dr[SalesDetailSchema.ct_Col_PrtDeliveredGoodsDivNm] = prtSalesDetail.prtDeliveredGoodsDivNm;    // (����p)�[�i�敪����
            dr[SalesDetailSchema.ct_Col_PrtFollowDeliGoodsDiv] = prtSalesDetail.prtFollowDeliGoodsDiv;      // (����p)�t�H���[�[�i�敪
            dr[SalesDetailSchema.ct_Col_PrtFollowDeliGoodsDivNm] = prtSalesDetail.prtFollowDeliGoodsDivNm;  // (����p)�t�H���[�[�i�敪����
            dr[SalesDetailSchema.ct_Col_PrtAcceptAnOrderCnt] = prtSalesDetail.prtAcceptAnOrderCnt;	        // (����p)�󒍐�
            dr[SalesDetailSchema.ct_Col_PrtShipmentCnt] = prtSalesDetail.prtShipmentCnt;	                // (����p)�o�ɐ�
            dr[SalesDetailSchema.ct_Col_PrtUOESectOutGoodsCnt] = prtSalesDetail.prtUOESectOutGoodsCnt;	    // (����p)���_�o�ɐ�
            dr[SalesDetailSchema.ct_Col_PrtBOShipmentCnt] = prtSalesDetail.prtBOShipmentCnt;	            // (����p)BO�o�ɐ�
            dr[SalesDetailSchema.ct_Col_DetailCd] = prtSalesDetail.detailCd;	                            // ���׎��
        }

        /// <summary>
        /// ���㖾�׃e�[�u��Row�쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <param name="rst">���㖾�׃N���X</param>
        private void CreateSalesDetailSchema(ref DataRow dr, SalesDetailWork rst)
        {
            //dr[SalesDetailSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// �쐬����
            //dr[SalesDetailSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// �X�V����
            dr[SalesDetailSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// ��ƃR�[�h
            //dr[SalesDetailSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            //dr[SalesDetailSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// �X�V�]�ƈ��R�[�h
            //dr[SalesDetailSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// �X�V�A�Z���u��ID1
            //dr[SalesDetailSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// �X�V�A�Z���u��ID2
            dr[SalesDetailSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// �_���폜�敪
            dr[SalesDetailSchema.ct_Col_AcceptAnOrderNo] = rst.AcceptAnOrderNo;	// �󒍔ԍ�
            dr[SalesDetailSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus;	// �󒍃X�e�[�^�X
            dr[SalesDetailSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum;	// ����`�[�ԍ�
            dr[SalesDetailSchema.ct_Col_SalesRowNo] = rst.SalesRowNo;	// ����s�ԍ�
            dr[SalesDetailSchema.ct_Col_SalesRowDerivNo] = rst.SalesRowDerivNo;	// ����s�ԍ��}��
            dr[SalesDetailSchema.ct_Col_SectionCode] = rst.SectionCode;	// ���_�R�[�h
            dr[SalesDetailSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// ����R�[�h
            dr[SalesDetailSchema.ct_Col_SalesDate] = rst.SalesDate;	// ������t
            dr[SalesDetailSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo;	// ���ʒʔ�
            dr[SalesDetailSchema.ct_Col_SalesSlipDtlNum] = rst.SalesSlipDtlNum;	// ���㖾�גʔ�
            dr[SalesDetailSchema.ct_Col_AcptAnOdrStatusSrc] = rst.AcptAnOdrStatusSrc;	// �󒍃X�e�[�^�X�i���j
            dr[SalesDetailSchema.ct_Col_SalesSlipDtlNumSrc] = rst.SalesSlipDtlNumSrc;	// ���㖾�גʔԁi���j
            dr[SalesDetailSchema.ct_Col_SupplierFormalSync] = rst.SupplierFormalSync;	// �d���`���i�����j
            dr[SalesDetailSchema.ct_Col_StockSlipDtlNumSync] = rst.StockSlipDtlNumSync;	// �d�����גʔԁi�����j
            dr[SalesDetailSchema.ct_Col_SalesSlipCdDtl] = rst.SalesSlipCdDtl;	// ����`�[�敪�i���ׁj
            dr[SalesDetailSchema.ct_Col_DeliGdsCmpltDueDate] = rst.DeliGdsCmpltDueDate;	// �[�i�����\���
            dr[SalesDetailSchema.ct_Col_GoodsKindCode] = rst.GoodsKindCode;	// ���i����
            dr[SalesDetailSchema.ct_Col_GoodsSearchDivCd] = rst.GoodsSearchDivCd;	// ���i�����敪
            dr[SalesDetailSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd;	// ���i���[�J�[�R�[�h
            dr[SalesDetailSchema.ct_Col_MakerName] = rst.MakerName;	// ���[�J�[����
            dr[SalesDetailSchema.ct_Col_MakerKanaName] = rst.MakerKanaName;	// ���[�J�[�J�i����
            dr[SalesDetailSchema.ct_Col_GoodsNo] = rst.GoodsNo;	// ���i�ԍ�
            dr[SalesDetailSchema.ct_Col_GoodsName] = rst.GoodsName;	// ���i����
            dr[SalesDetailSchema.ct_Col_GoodsNameKana] = rst.GoodsNameKana;	// ���i���̃J�i
            dr[SalesDetailSchema.ct_Col_GoodsLGroup] = rst.GoodsLGroup;	// ���i�啪�ރR�[�h
            dr[SalesDetailSchema.ct_Col_GoodsLGroupName] = rst.GoodsLGroupName;	// ���i�啪�ޖ���
            dr[SalesDetailSchema.ct_Col_GoodsMGroup] = rst.GoodsMGroup;	// ���i�����ރR�[�h
            dr[SalesDetailSchema.ct_Col_GoodsMGroupName] = rst.GoodsMGroupName;	// ���i�����ޖ���
            dr[SalesDetailSchema.ct_Col_BLGroupCode] = rst.BLGroupCode;	// BL�O���[�v�R�[�h
            dr[SalesDetailSchema.ct_Col_BLGroupName] = rst.BLGroupName;	// BL�O���[�v�R�[�h����
            dr[SalesDetailSchema.ct_Col_BLGoodsCode] = rst.BLGoodsCode;	// BL���i�R�[�h
            dr[SalesDetailSchema.ct_Col_BLGoodsFullName] = rst.BLGoodsFullName;	// BL���i�R�[�h���́i�S�p�j
            dr[SalesDetailSchema.ct_Col_EnterpriseGanreCode] = rst.EnterpriseGanreCode;	// ���Е��ރR�[�h
            dr[SalesDetailSchema.ct_Col_EnterpriseGanreName] = rst.EnterpriseGanreName;	// ���Е��ޖ���
            dr[SalesDetailSchema.ct_Col_WarehouseCode] = rst.WarehouseCode;	// �q�ɃR�[�h
            dr[SalesDetailSchema.ct_Col_WarehouseName] = rst.WarehouseName;	// �q�ɖ���
            dr[SalesDetailSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo;	// �q�ɒI��
            dr[SalesDetailSchema.ct_Col_SalesOrderDivCd] = rst.SalesOrderDivCd;	// ����݌Ɏ�񂹋敪
            dr[SalesDetailSchema.ct_Col_OpenPriceDiv] = rst.OpenPriceDiv;	// �I�[�v�����i�敪
            dr[SalesDetailSchema.ct_Col_GoodsRateRank] = rst.GoodsRateRank;	// ���i�|�������N
            dr[SalesDetailSchema.ct_Col_CustRateGrpCode] = rst.CustRateGrpCode;	// ���Ӑ�|���O���[�v�R�[�h
            dr[SalesDetailSchema.ct_Col_ListPriceRate] = rst.ListPriceRate;	// �艿��
            dr[SalesDetailSchema.ct_Col_RateSectPriceUnPrc] = rst.RateSectPriceUnPrc;	// �|���ݒ苒�_�i�艿�j
            dr[SalesDetailSchema.ct_Col_RateDivLPrice] = rst.RateDivLPrice;	// �|���ݒ�敪�i�艿�j
            dr[SalesDetailSchema.ct_Col_UnPrcCalcCdLPrice] = rst.UnPrcCalcCdLPrice;	// �P���Z�o�敪�i�艿�j
            dr[SalesDetailSchema.ct_Col_PriceCdLPrice] = rst.PriceCdLPrice;	// ���i�敪�i�艿�j
            dr[SalesDetailSchema.ct_Col_StdUnPrcLPrice] = rst.StdUnPrcLPrice;	// ��P���i�艿�j
            dr[SalesDetailSchema.ct_Col_FracProcUnitLPrice] = rst.FracProcUnitLPrice;	// �[�������P�ʁi�艿�j
            dr[SalesDetailSchema.ct_Col_FracProcLPrice] = rst.FracProcLPrice;	// �[�������i�艿�j
            dr[SalesDetailSchema.ct_Col_ListPriceTaxIncFl] = rst.ListPriceTaxIncFl;	// �艿�i�ō��C�����j
            dr[SalesDetailSchema.ct_Col_ListPriceTaxExcFl] = rst.ListPriceTaxExcFl;	// �艿�i�Ŕ��C�����j
            dr[SalesDetailSchema.ct_Col_ListPriceChngCd] = rst.ListPriceChngCd;	// �艿�ύX�敪
            dr[SalesDetailSchema.ct_Col_SalesRate] = rst.SalesRate;	// ������
            dr[SalesDetailSchema.ct_Col_RateSectSalUnPrc] = rst.RateSectSalUnPrc;	// �|���ݒ苒�_�i����P���j
            dr[SalesDetailSchema.ct_Col_RateDivSalUnPrc] = rst.RateDivSalUnPrc;	// �|���ݒ�敪�i����P���j
            dr[SalesDetailSchema.ct_Col_UnPrcCalcCdSalUnPrc] = rst.UnPrcCalcCdSalUnPrc;	// �P���Z�o�敪�i����P���j
            dr[SalesDetailSchema.ct_Col_PriceCdSalUnPrc] = rst.PriceCdSalUnPrc;	// ���i�敪�i����P���j
            dr[SalesDetailSchema.ct_Col_StdUnPrcSalUnPrc] = rst.StdUnPrcSalUnPrc;	// ��P���i����P���j
            dr[SalesDetailSchema.ct_Col_FracProcUnitSalUnPrc] = rst.FracProcUnitSalUnPrc;	// �[�������P�ʁi����P���j
            dr[SalesDetailSchema.ct_Col_FracProcSalUnPrc] = rst.FracProcSalUnPrc;	// �[�������i����P���j
            dr[SalesDetailSchema.ct_Col_SalesUnPrcTaxIncFl] = rst.SalesUnPrcTaxIncFl;	// ����P���i�ō��C�����j
            dr[SalesDetailSchema.ct_Col_SalesUnPrcTaxExcFl] = rst.SalesUnPrcTaxExcFl;	// ����P���i�Ŕ��C�����j
            dr[SalesDetailSchema.ct_Col_SalesUnPrcChngCd] = rst.SalesUnPrcChngCd;	// ����P���ύX�敪
            dr[SalesDetailSchema.ct_Col_CostRate] = rst.CostRate;	// ������
            dr[SalesDetailSchema.ct_Col_RateSectCstUnPrc] = rst.RateSectCstUnPrc;	// �|���ݒ苒�_�i�����P���j
            dr[SalesDetailSchema.ct_Col_RateDivUnCst] = rst.RateDivUnCst;	// �|���ݒ�敪�i�����P���j
            dr[SalesDetailSchema.ct_Col_UnPrcCalcCdUnCst] = rst.UnPrcCalcCdUnCst;	// �P���Z�o�敪�i�����P���j
            dr[SalesDetailSchema.ct_Col_PriceCdUnCst] = rst.PriceCdUnCst;	// ���i�敪�i�����P���j
            dr[SalesDetailSchema.ct_Col_StdUnPrcUnCst] = rst.StdUnPrcUnCst;	// ��P���i�����P���j
            dr[SalesDetailSchema.ct_Col_FracProcUnitUnCst] = rst.FracProcUnitUnCst;	// �[�������P�ʁi�����P���j
            dr[SalesDetailSchema.ct_Col_FracProcUnCst] = rst.FracProcUnCst;	// �[�������i�����P���j
            dr[SalesDetailSchema.ct_Col_SalesUnitCost] = rst.SalesUnitCost;	// �����P��
            dr[SalesDetailSchema.ct_Col_SalesUnitCostChngDiv] = rst.SalesUnitCostChngDiv;	// �����P���ύX�敪
            dr[SalesDetailSchema.ct_Col_RateBLGoodsCode] = rst.RateBLGoodsCode;	// BL���i�R�[�h�i�|���j
            dr[SalesDetailSchema.ct_Col_RateBLGoodsName] = rst.RateBLGoodsName;	// BL���i�R�[�h���́i�|���j
            dr[SalesDetailSchema.ct_Col_RateGoodsRateGrpCd] = rst.RateGoodsRateGrpCd;	// ���i�|���O���[�v�R�[�h�i�|���j
            dr[SalesDetailSchema.ct_Col_RateGoodsRateGrpNm] = rst.RateGoodsRateGrpNm;	// ���i�|���O���[�v���́i�|���j
            dr[SalesDetailSchema.ct_Col_RateBLGroupCode] = rst.RateBLGroupCode;	// BL�O���[�v�R�[�h�i�|���j
            dr[SalesDetailSchema.ct_Col_RateBLGroupName] = rst.RateBLGroupName;	// BL�O���[�v���́i�|���j
            dr[SalesDetailSchema.ct_Col_PrtBLGoodsCode] = rst.PrtBLGoodsCode;	// BL���i�R�[�h�i����j
            dr[SalesDetailSchema.ct_Col_PrtBLGoodsName] = rst.PrtBLGoodsName;	// BL���i�R�[�h���́i����j
            dr[SalesDetailSchema.ct_Col_SalesCode] = rst.SalesCode;	// �̔��敪�R�[�h
            dr[SalesDetailSchema.ct_Col_SalesCdNm] = rst.SalesCdNm;	// �̔��敪����
            dr[SalesDetailSchema.ct_Col_WorkManHour] = rst.WorkManHour;	// ��ƍH��
            dr[SalesDetailSchema.ct_Col_ShipmentCnt] = rst.ShipmentCnt;	// �o�א�
            dr[SalesDetailSchema.ct_Col_AcceptAnOrderCnt] = rst.AcceptAnOrderCnt;	// �󒍐���
            dr[SalesDetailSchema.ct_Col_AcptAnOdrAdjustCnt] = rst.AcptAnOdrAdjustCnt;	// �󒍒�����
            dr[SalesDetailSchema.ct_Col_AcptAnOdrRemainCnt] = rst.AcptAnOdrRemainCnt;	// �󒍎c��
            dr[SalesDetailSchema.ct_Col_RemainCntUpdDate] = rst.RemainCntUpdDate;	// �c���X�V��
            dr[SalesDetailSchema.ct_Col_SalesMoneyTaxInc] = rst.SalesMoneyTaxInc;	// ������z�i�ō��݁j
            dr[SalesDetailSchema.ct_Col_SalesMoneyTaxExc] = rst.SalesMoneyTaxExc;	// ������z�i�Ŕ����j
            dr[SalesDetailSchema.ct_Col_Cost] = rst.Cost;	// ����
            dr[SalesDetailSchema.ct_Col_GrsProfitChkDiv] = rst.GrsProfitChkDiv;	// �e���`�F�b�N�敪
            dr[SalesDetailSchema.ct_Col_SalesGoodsCd] = rst.SalesGoodsCd;	// ���㏤�i�敪
            dr[SalesDetailSchema.ct_Col_SalesPriceConsTax] = rst.SalesPriceConsTax;	// ������z����Ŋz
            dr[SalesDetailSchema.ct_Col_TaxationDivCd] = rst.TaxationDivCd;	// �ېŋ敪
            dr[SalesDetailSchema.ct_Col_PartySlipNumDtl] = rst.PartySlipNumDtl;	// �����`�[�ԍ��i���ׁj
            dr[SalesDetailSchema.ct_Col_DtlNote] = rst.DtlNote;	// ���ה��l
            dr[SalesDetailSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// �d����R�[�h
            dr[SalesDetailSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// �d���旪��
            dr[SalesDetailSchema.ct_Col_OrderNumber] = rst.OrderNumber;	// �����ԍ�
            dr[SalesDetailSchema.ct_Col_WayToOrder] = rst.WayToOrder;	// �������@
            dr[SalesDetailSchema.ct_Col_SlipMemo1] = rst.SlipMemo1;	// �`�[�����P
            dr[SalesDetailSchema.ct_Col_SlipMemo2] = rst.SlipMemo2;	// �`�[�����Q
            dr[SalesDetailSchema.ct_Col_SlipMemo3] = rst.SlipMemo3;	// �`�[�����R
            dr[SalesDetailSchema.ct_Col_InsideMemo1] = rst.InsideMemo1;	// �Г������P
            dr[SalesDetailSchema.ct_Col_InsideMemo2] = rst.InsideMemo2;	// �Г������Q
            dr[SalesDetailSchema.ct_Col_InsideMemo3] = rst.InsideMemo3;	// �Г������R
            dr[SalesDetailSchema.ct_Col_BfListPrice] = rst.BfListPrice;	// �ύX�O�艿
            dr[SalesDetailSchema.ct_Col_BfSalesUnitPrice] = rst.BfSalesUnitPrice;	// �ύX�O����
            dr[SalesDetailSchema.ct_Col_BfUnitCost] = rst.BfUnitCost;	// �ύX�O����
            dr[SalesDetailSchema.ct_Col_CmpltSalesRowNo] = rst.CmpltSalesRowNo;	// �ꎮ���הԍ�
            dr[SalesDetailSchema.ct_Col_CmpltGoodsMakerCd] = rst.CmpltGoodsMakerCd;	// ���[�J�[�R�[�h�i�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltMakerName] = rst.CmpltMakerName;	// ���[�J�[���́i�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltMakerKanaName] = rst.CmpltMakerKanaName;	// ���[�J�[�J�i���́i�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltGoodsName] = rst.CmpltGoodsName;	// ���i���́i�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltShipmentCnt] = rst.CmpltShipmentCnt;	// ���ʁi�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltSalesUnPrcFl] = rst.CmpltSalesUnPrcFl;	// ����P���i�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltSalesMoney] = rst.CmpltSalesMoney;	// ������z�i�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltSalesUnitCost] = rst.CmpltSalesUnitCost;	// �����P���i�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltCost] = rst.CmpltCost;	// �������z�i�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltPartySalSlNum] = rst.CmpltPartySalSlNum;	// �����`�[�ԍ��i�ꎮ�j
            dr[SalesDetailSchema.ct_Col_CmpltNote] = rst.CmpltNote;	// �ꎮ���l
            dr[SalesDetailSchema.ct_Col_PrtGoodsNo] = rst.PrtGoodsNo;	// ����p�i��
            dr[SalesDetailSchema.ct_Col_PrtMakerCode] = rst.PrtMakerCode;	// ����p���[�J�[�R�[�h
            dr[SalesDetailSchema.ct_Col_PrtMakerName] = rst.PrtMakerName;	// ����p���[�J�[����
            dr[SalesDetailSchema.ct_Col_ShipmCntDifference] = rst.ShipmCntDifference;	// �o�׍�����
            dr[SalesDetailSchema.ct_Col_DtlRelationGuid] = rst.DtlRelationGuid;	// ���׊֘A�t��GUID

            // 2011/01/19 Add >>>
            dr[SalesDetailSchema.ct_Col_CampaignCode] = rst.CampaignCode;   // �L�����y�[���R�[�h
            dr[SalesDetailSchema.ct_Col_CampaignName] = rst.CampaignName;   // �L�����y�[������
            dr[SalesDetailSchema.ct_Col_GoodsDivCd] = rst.GoodsDivCd;   // ���i���
            dr[SalesDetailSchema.ct_Col_AnswerDelivDate] = rst.AnswerDelivDate; // �񓚔[��
            dr[SalesDetailSchema.ct_Col_RecycleDiv] = rst.RecycleDiv;   // ���T�C�N���敪
            dr[SalesDetailSchema.ct_Col_RecycleDivNm] = rst.RecycleDivNm;   // ���T�C�N���敪����
            dr[SalesDetailSchema.ct_Col_WayToAcptOdr] = rst.WayToAcptOdr;   // �󒍕��@
            // 2011/01/19 Add <<<
            dr[SalesDetailSchema.ct_Col_AutoAnswerDivSCM] = rst.AutoAnswerDivSCM;   // �����񓚋敪//add 2011/07/28

            // 2012/01/16 Add >>>
            dr[SalesDetailSchema.ct_Col_GoodsSpecialNote] = rst.GoodsSpecialNote;
            // 2012/01/16 Add <<<

            // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� ----------------------------------->>>>>
            dr[SalesDetailSchema.ct_Col_AcceptOrOrderKind] = rst.AcceptOrOrderKind;
            // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� -----------------------------------<<<<<

        }
        # endregion

        # region (����p)UOE���㖾�׃N���X�̎擾��DataRow �� �N���X���쐬
        /// <summary>
        /// (����p)UOE���㖾�׃N���X�̎擾��DataRow �� �N���X���쐬
        /// </summary>
        /// <param name="dr">�e�[�u��</param>
        /// <returns>���㖾��(���)</returns>
        private PrtSalesDetail CreatePrtSalesDetailFromSchemaProc(DataRow dr)
        {
            PrtSalesDetail rst = new PrtSalesDetail();

            try
            {
                rst.prtReceiveTime = (Int32)dr[SalesDetailSchema.ct_Col_PrtReceiveTime];                    //(����p)��M����
                rst.prtBoCode = (string)dr[SalesDetailSchema.ct_Col_PrtBoCode];                             //(����p)BO�敪
                rst.prtUOEDeliGoodsDiv = (string)dr[SalesDetailSchema.ct_Col_PrtUOEDeliGoodsDiv];           //(����p)UOE�[�i�敪
                rst.prtDeliveredGoodsDivNm = (string)dr[SalesDetailSchema.ct_Col_PrtDeliveredGoodsDivNm];   //(����p)�[�i�敪����
                rst.prtFollowDeliGoodsDiv = (string)dr[SalesDetailSchema.ct_Col_PrtFollowDeliGoodsDiv];     //(����p)�t�H���[�[�i�敪
                rst.prtFollowDeliGoodsDivNm = (string)dr[SalesDetailSchema.ct_Col_PrtFollowDeliGoodsDivNm]; //(����p)�t�H���[�[�i�敪����
                rst.prtAcceptAnOrderCnt = (double)dr[SalesDetailSchema.ct_Col_PrtAcceptAnOrderCnt];         //(����p)�󒍐�
                rst.prtShipmentCnt = (Int32)dr[SalesDetailSchema.ct_Col_PrtShipmentCnt];                    //(����p)�o�ɐ�
                rst.prtUOESectOutGoodsCnt = (Int32)dr[SalesDetailSchema.ct_Col_PrtUOESectOutGoodsCnt];      //(����p)���_�o�ɐ�
                rst.prtBOShipmentCnt = (Int32)dr[SalesDetailSchema.ct_Col_PrtBOShipmentCnt];                //(����p)BO�o�ɐ�
                rst.detailCd = (Int32)dr[SalesDetailSchema.ct_Col_DetailCd];                                //���׎��
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion

        # region ���㖾�ׁ�DataRow �� �N���X���쐬
        /// <summary>
        /// ���㖾�ׁ�DataRow �� �N���X���쐬
        /// </summary>
        /// <param name="dr">�e�[�u��Row</param>
        /// <returns>���㖾��</returns>
        private SalesDetailWork CreateSalesDetailWorkFromSchemaProc(DataRow dr)
        {
            SalesDetailWork rst = new SalesDetailWork();

            try
            {
                //rst.CreateDateTime = (Int64)dr[SalesDetailSchema.ct_Col_CreateDateTime];	// �쐬����
                //rst.UpdateDateTime = (Int64)dr[SalesDetailSchema.ct_Col_UpdateDateTime];	// �X�V����
                rst.EnterpriseCode = (string)dr[SalesDetailSchema.ct_Col_EnterpriseCode];	// ��ƃR�[�h
                rst.FileHeaderGuid = (Guid)dr[SalesDetailSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[SalesDetailSchema.ct_Col_UpdEmployeeCode];	// �X�V�]�ƈ��R�[�h
                rst.UpdAssemblyId1 = (string)dr[SalesDetailSchema.ct_Col_UpdAssemblyId1];	// �X�V�A�Z���u��ID1
                rst.UpdAssemblyId2 = (string)dr[SalesDetailSchema.ct_Col_UpdAssemblyId2];	// �X�V�A�Z���u��ID2
                rst.LogicalDeleteCode = (Int32)dr[SalesDetailSchema.ct_Col_LogicalDeleteCode];	// �_���폜�敪
                rst.AcceptAnOrderNo = (Int32)dr[SalesDetailSchema.ct_Col_AcceptAnOrderNo];	// �󒍔ԍ�
                rst.AcptAnOdrStatus = (Int32)dr[SalesDetailSchema.ct_Col_AcptAnOdrStatus];	// �󒍃X�e�[�^�X
                rst.SalesSlipNum = (string)dr[SalesDetailSchema.ct_Col_SalesSlipNum];	// ����`�[�ԍ�
                rst.SalesRowNo = (Int32)dr[SalesDetailSchema.ct_Col_SalesRowNo];	// ����s�ԍ�
                rst.SalesRowDerivNo = (Int32)dr[SalesDetailSchema.ct_Col_SalesRowDerivNo];	// ����s�ԍ��}��
                rst.SectionCode = (string)dr[SalesDetailSchema.ct_Col_SectionCode];	// ���_�R�[�h
                rst.SubSectionCode = (Int32)dr[SalesDetailSchema.ct_Col_SubSectionCode];	// ����R�[�h
                rst.SalesDate = (DateTime)dr[SalesDetailSchema.ct_Col_SalesDate];	// ������t
                rst.CommonSeqNo = (Int64)dr[SalesDetailSchema.ct_Col_CommonSeqNo];	// ���ʒʔ�
                rst.SalesSlipDtlNum = (Int64)dr[SalesDetailSchema.ct_Col_SalesSlipDtlNum];	// ���㖾�גʔ�
                rst.AcptAnOdrStatusSrc = (Int32)dr[SalesDetailSchema.ct_Col_AcptAnOdrStatusSrc];	// �󒍃X�e�[�^�X�i���j
                rst.SalesSlipDtlNumSrc = (Int64)dr[SalesDetailSchema.ct_Col_SalesSlipDtlNumSrc];	// ���㖾�גʔԁi���j
                rst.SupplierFormalSync = (Int32)dr[SalesDetailSchema.ct_Col_SupplierFormalSync];	// �d���`���i�����j
                rst.StockSlipDtlNumSync = (Int64)dr[SalesDetailSchema.ct_Col_StockSlipDtlNumSync];	// �d�����גʔԁi�����j
                rst.SalesSlipCdDtl = (Int32)dr[SalesDetailSchema.ct_Col_SalesSlipCdDtl];	// ����`�[�敪�i���ׁj
                rst.DeliGdsCmpltDueDate = (DateTime)dr[SalesDetailSchema.ct_Col_DeliGdsCmpltDueDate];	// �[�i�����\���
                rst.GoodsKindCode = (Int32)dr[SalesDetailSchema.ct_Col_GoodsKindCode];	// ���i����
                rst.GoodsSearchDivCd = (Int32)dr[SalesDetailSchema.ct_Col_GoodsSearchDivCd];	// ���i�����敪
                rst.GoodsMakerCd = (Int32)dr[SalesDetailSchema.ct_Col_GoodsMakerCd];	// ���i���[�J�[�R�[�h
                rst.MakerName = (string)dr[SalesDetailSchema.ct_Col_MakerName];	// ���[�J�[����
                rst.MakerKanaName = (string)dr[SalesDetailSchema.ct_Col_MakerKanaName];	// ���[�J�[�J�i����
                rst.GoodsNo = (string)dr[SalesDetailSchema.ct_Col_GoodsNo];	// ���i�ԍ�
                rst.GoodsName = (string)dr[SalesDetailSchema.ct_Col_GoodsName];	// ���i����
                rst.GoodsNameKana = (string)dr[SalesDetailSchema.ct_Col_GoodsNameKana];	// ���i���̃J�i
                rst.GoodsLGroup = (Int32)dr[SalesDetailSchema.ct_Col_GoodsLGroup];	// ���i�啪�ރR�[�h
                rst.GoodsLGroupName = (string)dr[SalesDetailSchema.ct_Col_GoodsLGroupName];	// ���i�啪�ޖ���
                rst.GoodsMGroup = (Int32)dr[SalesDetailSchema.ct_Col_GoodsMGroup];	// ���i�����ރR�[�h
                rst.GoodsMGroupName = (string)dr[SalesDetailSchema.ct_Col_GoodsMGroupName];	// ���i�����ޖ���
                rst.BLGroupCode = (Int32)dr[SalesDetailSchema.ct_Col_BLGroupCode];	// BL�O���[�v�R�[�h
                rst.BLGroupName = (string)dr[SalesDetailSchema.ct_Col_BLGroupName];	// BL�O���[�v�R�[�h����
                rst.BLGoodsCode = (Int32)dr[SalesDetailSchema.ct_Col_BLGoodsCode];	// BL���i�R�[�h
                rst.BLGoodsFullName = (string)dr[SalesDetailSchema.ct_Col_BLGoodsFullName];	// BL���i�R�[�h���́i�S�p�j
                rst.EnterpriseGanreCode = (Int32)dr[SalesDetailSchema.ct_Col_EnterpriseGanreCode];	// ���Е��ރR�[�h
                rst.EnterpriseGanreName = (string)dr[SalesDetailSchema.ct_Col_EnterpriseGanreName];	// ���Е��ޖ���
                rst.WarehouseCode = (string)dr[SalesDetailSchema.ct_Col_WarehouseCode];	// �q�ɃR�[�h
                rst.WarehouseName = (string)dr[SalesDetailSchema.ct_Col_WarehouseName];	// �q�ɖ���
                rst.WarehouseShelfNo = (string)dr[SalesDetailSchema.ct_Col_WarehouseShelfNo];	// �q�ɒI��
                rst.SalesOrderDivCd = (Int32)dr[SalesDetailSchema.ct_Col_SalesOrderDivCd];	// ����݌Ɏ�񂹋敪
                rst.OpenPriceDiv = (Int32)dr[SalesDetailSchema.ct_Col_OpenPriceDiv];	// �I�[�v�����i�敪
                rst.GoodsRateRank = (string)dr[SalesDetailSchema.ct_Col_GoodsRateRank];	// ���i�|�������N
                rst.CustRateGrpCode = (Int32)dr[SalesDetailSchema.ct_Col_CustRateGrpCode];	// ���Ӑ�|���O���[�v�R�[�h
                rst.ListPriceRate = (Double)dr[SalesDetailSchema.ct_Col_ListPriceRate];	// �艿��
                rst.RateSectPriceUnPrc = (string)dr[SalesDetailSchema.ct_Col_RateSectPriceUnPrc];	// �|���ݒ苒�_�i�艿�j
                rst.RateDivLPrice = (string)dr[SalesDetailSchema.ct_Col_RateDivLPrice];	// �|���ݒ�敪�i�艿�j
                rst.UnPrcCalcCdLPrice = (Int32)dr[SalesDetailSchema.ct_Col_UnPrcCalcCdLPrice];	// �P���Z�o�敪�i�艿�j
                rst.PriceCdLPrice = (Int32)dr[SalesDetailSchema.ct_Col_PriceCdLPrice];	// ���i�敪�i�艿�j
                rst.StdUnPrcLPrice = (Double)dr[SalesDetailSchema.ct_Col_StdUnPrcLPrice];	// ��P���i�艿�j
                rst.FracProcUnitLPrice = (Double)dr[SalesDetailSchema.ct_Col_FracProcUnitLPrice];	// �[�������P�ʁi�艿�j
                rst.FracProcLPrice = (Int32)dr[SalesDetailSchema.ct_Col_FracProcLPrice];	// �[�������i�艿�j
                rst.ListPriceTaxIncFl = (Double)dr[SalesDetailSchema.ct_Col_ListPriceTaxIncFl];	// �艿�i�ō��C�����j
                rst.ListPriceTaxExcFl = (Double)dr[SalesDetailSchema.ct_Col_ListPriceTaxExcFl];	// �艿�i�Ŕ��C�����j
                rst.ListPriceChngCd = (Int32)dr[SalesDetailSchema.ct_Col_ListPriceChngCd];	// �艿�ύX�敪
                rst.SalesRate = (Double)dr[SalesDetailSchema.ct_Col_SalesRate];	// ������
                rst.RateSectSalUnPrc = (string)dr[SalesDetailSchema.ct_Col_RateSectSalUnPrc];	// �|���ݒ苒�_�i����P���j
                rst.RateDivSalUnPrc = (string)dr[SalesDetailSchema.ct_Col_RateDivSalUnPrc];	// �|���ݒ�敪�i����P���j
                rst.UnPrcCalcCdSalUnPrc = (Int32)dr[SalesDetailSchema.ct_Col_UnPrcCalcCdSalUnPrc];	// �P���Z�o�敪�i����P���j
                rst.PriceCdSalUnPrc = (Int32)dr[SalesDetailSchema.ct_Col_PriceCdSalUnPrc];	// ���i�敪�i����P���j
                rst.StdUnPrcSalUnPrc = (Double)dr[SalesDetailSchema.ct_Col_StdUnPrcSalUnPrc];	// ��P���i����P���j
                rst.FracProcUnitSalUnPrc = (Double)dr[SalesDetailSchema.ct_Col_FracProcUnitSalUnPrc];	// �[�������P�ʁi����P���j
                rst.FracProcSalUnPrc = (Int32)dr[SalesDetailSchema.ct_Col_FracProcSalUnPrc];	// �[�������i����P���j
                rst.SalesUnPrcTaxIncFl = (Double)dr[SalesDetailSchema.ct_Col_SalesUnPrcTaxIncFl];	// ����P���i�ō��C�����j
                rst.SalesUnPrcTaxExcFl = (Double)dr[SalesDetailSchema.ct_Col_SalesUnPrcTaxExcFl];	// ����P���i�Ŕ��C�����j
                rst.SalesUnPrcChngCd = (Int32)dr[SalesDetailSchema.ct_Col_SalesUnPrcChngCd];	// ����P���ύX�敪
                rst.CostRate = (Double)dr[SalesDetailSchema.ct_Col_CostRate];	// ������
                rst.RateSectCstUnPrc = (string)dr[SalesDetailSchema.ct_Col_RateSectCstUnPrc];	// �|���ݒ苒�_�i�����P���j
                rst.RateDivUnCst = (string)dr[SalesDetailSchema.ct_Col_RateDivUnCst];	// �|���ݒ�敪�i�����P���j
                rst.UnPrcCalcCdUnCst = (Int32)dr[SalesDetailSchema.ct_Col_UnPrcCalcCdUnCst];	// �P���Z�o�敪�i�����P���j
                rst.PriceCdUnCst = (Int32)dr[SalesDetailSchema.ct_Col_PriceCdUnCst];	// ���i�敪�i�����P���j
                rst.StdUnPrcUnCst = (Double)dr[SalesDetailSchema.ct_Col_StdUnPrcUnCst];	// ��P���i�����P���j
                rst.FracProcUnitUnCst = (Double)dr[SalesDetailSchema.ct_Col_FracProcUnitUnCst];	// �[�������P�ʁi�����P���j
                rst.FracProcUnCst = (Int32)dr[SalesDetailSchema.ct_Col_FracProcUnCst];	// �[�������i�����P���j
                rst.SalesUnitCost = (Double)dr[SalesDetailSchema.ct_Col_SalesUnitCost];	// �����P��
                rst.SalesUnitCostChngDiv = (Int32)dr[SalesDetailSchema.ct_Col_SalesUnitCostChngDiv];	// �����P���ύX�敪
                rst.RateBLGoodsCode = (Int32)dr[SalesDetailSchema.ct_Col_RateBLGoodsCode];	// BL���i�R�[�h�i�|���j
                rst.RateBLGoodsName = (string)dr[SalesDetailSchema.ct_Col_RateBLGoodsName];	// BL���i�R�[�h���́i�|���j
                rst.RateGoodsRateGrpCd = (Int32)dr[SalesDetailSchema.ct_Col_RateGoodsRateGrpCd];	// ���i�|���O���[�v�R�[�h�i�|���j
                rst.RateGoodsRateGrpNm = (string)dr[SalesDetailSchema.ct_Col_RateGoodsRateGrpNm];	// ���i�|���O���[�v���́i�|���j
                rst.RateBLGroupCode = (Int32)dr[SalesDetailSchema.ct_Col_RateBLGroupCode];	// BL�O���[�v�R�[�h�i�|���j
                rst.RateBLGroupName = (string)dr[SalesDetailSchema.ct_Col_RateBLGroupName];	// BL�O���[�v���́i�|���j
                rst.PrtBLGoodsCode = (Int32)dr[SalesDetailSchema.ct_Col_PrtBLGoodsCode];	// BL���i�R�[�h�i����j
                rst.PrtBLGoodsName = (string)dr[SalesDetailSchema.ct_Col_PrtBLGoodsName];	// BL���i�R�[�h���́i����j
                rst.SalesCode = (Int32)dr[SalesDetailSchema.ct_Col_SalesCode];	// �̔��敪�R�[�h
                rst.SalesCdNm = (string)dr[SalesDetailSchema.ct_Col_SalesCdNm];	// �̔��敪����
                rst.WorkManHour = (Double)dr[SalesDetailSchema.ct_Col_WorkManHour];	// ��ƍH��
                rst.ShipmentCnt = (Double)dr[SalesDetailSchema.ct_Col_ShipmentCnt];	// �o�א�
                rst.AcceptAnOrderCnt = (Double)dr[SalesDetailSchema.ct_Col_AcceptAnOrderCnt];	// �󒍐���
                rst.AcptAnOdrAdjustCnt = (Double)dr[SalesDetailSchema.ct_Col_AcptAnOdrAdjustCnt];	// �󒍒�����
                rst.AcptAnOdrRemainCnt = (Double)dr[SalesDetailSchema.ct_Col_AcptAnOdrRemainCnt];	// �󒍎c��
                rst.RemainCntUpdDate = (DateTime)dr[SalesDetailSchema.ct_Col_RemainCntUpdDate];	// �c���X�V��
                rst.SalesMoneyTaxInc = (Int64)dr[SalesDetailSchema.ct_Col_SalesMoneyTaxInc];	// ������z�i�ō��݁j
                rst.SalesMoneyTaxExc = (Int64)dr[SalesDetailSchema.ct_Col_SalesMoneyTaxExc];	// ������z�i�Ŕ����j
                rst.Cost = (Int64)dr[SalesDetailSchema.ct_Col_Cost];	// ����
                rst.GrsProfitChkDiv = (Int32)dr[SalesDetailSchema.ct_Col_GrsProfitChkDiv];	// �e���`�F�b�N�敪
                rst.SalesGoodsCd = (Int32)dr[SalesDetailSchema.ct_Col_SalesGoodsCd];	// ���㏤�i�敪
                rst.SalesPriceConsTax = (Int64)dr[SalesDetailSchema.ct_Col_SalesPriceConsTax];	// ������z����Ŋz
                rst.TaxationDivCd = (Int32)dr[SalesDetailSchema.ct_Col_TaxationDivCd];	// �ېŋ敪
                rst.PartySlipNumDtl = (string)dr[SalesDetailSchema.ct_Col_PartySlipNumDtl];	// �����`�[�ԍ��i���ׁj
                rst.DtlNote = (string)dr[SalesDetailSchema.ct_Col_DtlNote];	// ���ה��l
                rst.SupplierCd = (Int32)dr[SalesDetailSchema.ct_Col_SupplierCd];	// �d����R�[�h
                rst.SupplierSnm = (string)dr[SalesDetailSchema.ct_Col_SupplierSnm];	// �d���旪��
                rst.OrderNumber = (string)dr[SalesDetailSchema.ct_Col_OrderNumber];	// �����ԍ�
                rst.WayToOrder = (Int32)dr[SalesDetailSchema.ct_Col_WayToOrder];	// �������@
                rst.SlipMemo1 = (string)dr[SalesDetailSchema.ct_Col_SlipMemo1];	// �`�[�����P
                rst.SlipMemo2 = (string)dr[SalesDetailSchema.ct_Col_SlipMemo2];	// �`�[�����Q
                rst.SlipMemo3 = (string)dr[SalesDetailSchema.ct_Col_SlipMemo3];	// �`�[�����R
                rst.InsideMemo1 = (string)dr[SalesDetailSchema.ct_Col_InsideMemo1];	// �Г������P
                rst.InsideMemo2 = (string)dr[SalesDetailSchema.ct_Col_InsideMemo2];	// �Г������Q
                rst.InsideMemo3 = (string)dr[SalesDetailSchema.ct_Col_InsideMemo3];	// �Г������R
                rst.BfListPrice = (Double)dr[SalesDetailSchema.ct_Col_BfListPrice];	// �ύX�O�艿
                rst.BfSalesUnitPrice = (Double)dr[SalesDetailSchema.ct_Col_BfSalesUnitPrice];	// �ύX�O����
                rst.BfUnitCost = (Double)dr[SalesDetailSchema.ct_Col_BfUnitCost];	// �ύX�O����
                rst.CmpltSalesRowNo = (Int32)dr[SalesDetailSchema.ct_Col_CmpltSalesRowNo];	// �ꎮ���הԍ�
                rst.CmpltGoodsMakerCd = (Int32)dr[SalesDetailSchema.ct_Col_CmpltGoodsMakerCd];	// ���[�J�[�R�[�h�i�ꎮ�j
                rst.CmpltMakerName = (string)dr[SalesDetailSchema.ct_Col_CmpltMakerName];	// ���[�J�[���́i�ꎮ�j
                rst.CmpltMakerKanaName = (string)dr[SalesDetailSchema.ct_Col_CmpltMakerKanaName];	// ���[�J�[�J�i���́i�ꎮ�j
                rst.CmpltGoodsName = (string)dr[SalesDetailSchema.ct_Col_CmpltGoodsName];	// ���i���́i�ꎮ�j
                rst.CmpltShipmentCnt = (Double)dr[SalesDetailSchema.ct_Col_CmpltShipmentCnt];	// ���ʁi�ꎮ�j
                rst.CmpltSalesUnPrcFl = (Double)dr[SalesDetailSchema.ct_Col_CmpltSalesUnPrcFl];	// ����P���i�ꎮ�j
                rst.CmpltSalesMoney = (Int64)dr[SalesDetailSchema.ct_Col_CmpltSalesMoney];	// ������z�i�ꎮ�j
                rst.CmpltSalesUnitCost = (Double)dr[SalesDetailSchema.ct_Col_CmpltSalesUnitCost];	// �����P���i�ꎮ�j
                rst.CmpltCost = (Int64)dr[SalesDetailSchema.ct_Col_CmpltCost];	// �������z�i�ꎮ�j
                rst.CmpltPartySalSlNum = (string)dr[SalesDetailSchema.ct_Col_CmpltPartySalSlNum];	// �����`�[�ԍ��i�ꎮ�j
                rst.CmpltNote = (string)dr[SalesDetailSchema.ct_Col_CmpltNote];	// �ꎮ���l
                rst.PrtGoodsNo = (string)dr[SalesDetailSchema.ct_Col_PrtGoodsNo];	// ����p�i��
                rst.PrtMakerCode = (Int32)dr[SalesDetailSchema.ct_Col_PrtMakerCode];	// ����p���[�J�[�R�[�h
                rst.PrtMakerName = (string)dr[SalesDetailSchema.ct_Col_PrtMakerName];	// ����p���[�J�[����
                rst.ShipmCntDifference = (Double)dr[SalesDetailSchema.ct_Col_ShipmCntDifference];	// �o�׍�����
                rst.DtlRelationGuid = (Guid)dr[SalesDetailSchema.ct_Col_DtlRelationGuid];	// ���׊֘A�t��GUID
                // 2011/01/19 Add >>>
                rst.CampaignCode = (Int32)dr[SalesDetailSchema.ct_Col_CampaignCode];   // �L�����y�[���R�[�h
                rst.CampaignName = (string)dr[SalesDetailSchema.ct_Col_CampaignName];   // �L�����y�[������
                rst.GoodsDivCd = (Int32)dr[SalesDetailSchema.ct_Col_GoodsDivCd];   // ���i���
                rst.AnswerDelivDate = (string)dr[SalesDetailSchema.ct_Col_AnswerDelivDate]; // �񓚔[��
                rst.RecycleDiv = (Int32)dr[SalesDetailSchema.ct_Col_RecycleDiv];   // ���T�C�N���敪
                rst.RecycleDivNm = (string)dr[SalesDetailSchema.ct_Col_RecycleDivNm];   // ���T�C�N���敪����
                rst.WayToAcptOdr = (Int32)dr[SalesDetailSchema.ct_Col_WayToAcptOdr];   // �󒍕��@
                // 2011/01/19 Add <<<
                rst.AutoAnswerDivSCM = (Int32)dr[SalesDetailSchema.ct_Col_AutoAnswerDivSCM];   // �����񓚋敪//add 2011/07/28
                // 2012/01/16 Add >>>
                rst.GoodsSpecialNote = (string)dr[SalesDetailSchema.ct_Col_GoodsSpecialNote];   // ���L����
                // 2012/01/16 Add <<<

                // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� ----------------------------------->>>>>
                rst.AcceptOrOrderKind = (short)dr[SalesDetailSchema.ct_Col_AcceptOrOrderKind];  // �󔭒����
                // ADD 2012/12/06 2012/12/12�z�M�\�� SCM��Q��10447�Ή� -----------------------------------<<<<<

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
