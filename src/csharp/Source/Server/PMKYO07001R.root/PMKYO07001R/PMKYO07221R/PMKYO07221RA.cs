//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��M����f�[�^�W�v�����[�g
// �v���O�����T�v   : ����f�[�^��M���u���㌎���W�v�f�[�^�A
//                    ���i�ʔ��㌎���W�v�f�[�^�v���W�v����
//                    ����f�[�^��M���ɍ݌Ƀ}�X�^�̍X�V���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Č���
// �� �� ��  2011/08/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Č���
// �C �� ��  2011/09/07   �C�����e : redmine#24343
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/09/21   �C�����e : redmine#25379
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ��M����f�[�^�W�v�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
    /// <br>Note       : ��M����f�[�^�W�v������s���N���X�ł��B</br>
	/// <br>Programmer : �Č���</br>
	/// <br>Date       : 2011.8.5</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class APTotalizeSalesSlip : RemoteDB
    {
        #region [�萔��`]
        /// <summary>
        /// �N���X����
        /// </summary>
        private const string ctCLASS_NAME = "APTotalizeSalesSlip";

        /// <summary>
        /// �S�Ћ��_�R�[�h
        /// </summary>
        private const string ctSECTIONCODE_00 = "00";
        #endregion [�萔��`]
        #region [�v���p�e�B�[��`]
        private APSalesInfoConverter _salesInfoConverter = null;
        /// <summary>
        /// �����񃏁[�N�R���o�[�^�[
        /// </summary>
        private APSalesInfoConverter SalesInfoConverter
        {
            get
            {
                if (null == _salesInfoConverter)
                    _salesInfoConverter = new APSalesInfoConverter();
                return _salesInfoConverter;
            }
        }

        private SalesSlipDB _salesSlipDB = null;
        /// <summary>
        /// ����f�[�^DB�����[�g�I�u�W�F�N�g
        /// </summary>
        private SalesSlipDB SalesSlipDB
        {
            get
            {
                if (null == _salesSlipDB)
                    _salesSlipDB = new SalesSlipDB();
                return _salesSlipDB;
            }
        }

        private MonthlyTtlSalesUpdDB _monthlyTtlSalesUpdDB = null;
        /// <summary>
        /// ���㌎���W�v�f�[�^�X�V�����[�g�I�u�W�F�N�g
        /// </summary>
        private MonthlyTtlSalesUpdDB MonthlyTtlSalesUpdDB
        {
            get
            {
                if (null == _monthlyTtlSalesUpdDB)
                    _monthlyTtlSalesUpdDB = new MonthlyTtlSalesUpdDB();
                return _monthlyTtlSalesUpdDB;
            }
        }

        private IOWriteMAHNBStockUpdateDB _stockUpdateDB = null;
        /// <summary>
        /// �݌ɍX�V�����[�g�I�u�W�F�N�g
        /// </summary>
        private IOWriteMAHNBStockUpdateDB StockUpdateDB
        {
            get
            {
                if (null == this._stockUpdateDB)
                {
                    IOWriteCtrlOptWork ctrlOptWork = new IOWriteCtrlOptWork();
                    ctrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;
                    this._stockUpdateDB = new IOWriteMAHNBStockUpdateDB(ctrlOptWork);
                }
                return this._stockUpdateDB;
            }
        }
        #endregion [�v���p�e�B�[��`]

        #region [�p�u���b�N���@]
        /// <summary>
		/// ��M����f�[�^�W�v�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɂȂ�</br>
		/// <br>Programmer : �Č���</br>
		/// <br>Date       : 2011.8.5</br>
		/// </remarks>
        public APTotalizeSalesSlip()
		{
		}

        /// <summary>
        /// �����M�X�V����
        /// </summary>
        /// <param name="enterpriseCode">��M���_���̊�ƃR�[�h</param>
        /// <param name="paramSalesSlipList">��M��������f�[�^���X�g</param>
        /// <param name="paramSalesDetailList">��M�������㖾�׃f�[�^���X�g</param>
        /// <param name="salesSlipRecvDiv">����f�[�^�̎�M�敪</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        public int TotalizeReceivedSalesSlip(string enterpriseCode, ArrayList paramSalesSlipList, ArrayList paramSalesDetailList, int salesSlipRecvDiv, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // �p�����[�^�`�F�b�N
            if (!CheckParam(paramSalesSlipList, paramSalesDetailList))
                return status;

            // ��ƃR�[�h���o�b�N�A�b�v
            string enterpriseCodeBak = ((APSalesSlipWork)paramSalesSlipList[0]).EnterpriseCode;
            try
            {
                // ��M���_���̊�ƃR�[�h���Z�b�g
                SetEnterpriseCodeToWorkList(enterpriseCode, paramSalesSlipList);
                SetEnterpriseCodeToWorkList(enterpriseCode, paramSalesDetailList);
                // �����M�X�V����
                status = TotalizeReceivedSalesSlipProc(paramSalesSlipList, paramSalesDetailList, salesSlipRecvDiv, sqlConnection, sqlTransaction);
            }
            finally
            {
                // ��ƃR�[�h�����X�g�A
                SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramSalesSlipList);
                SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramSalesDetailList);
            }
            return status;
        }
        
        /// <summary>
        /// �����M�X�V����
        /// </summary>
        /// <param name="paramSalesSlipList">��M��������f�[�^���X�g</param>
        /// <param name="paramSalesDetailList">��M�������㖾�׃f�[�^���X�g</param>
        /// <param name="salesSlipRecvDiv">����f�[�^�̎�M�敪</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        private int TotalizeReceivedSalesSlipProc(ArrayList paramSalesSlipList, ArrayList paramSalesDetailList, int salesSlipRecvDiv, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // �p�����[�^�𗘗p���āA�����񃏁[�N���X�g���擾(��̏����ɓ��Y���X�g���g�p)
            List<APSalesInfoWork> salesInfoList = GetAPSalesInfoList(paramSalesSlipList, paramSalesDetailList);
            if (salesInfoList.Count == 0)
                return status;

            // ��M�������㖾�ׂ̃f�B�N�V���i���[���擾
            Dictionary<string, APSalesDetailWork> salesDetailDic = GetSalesDetailDic(paramSalesDetailList);
            Dictionary<string, SalesTtlStWork> salesTtlStDic = null;
            if (2 == salesSlipRecvDiv)
            {
                // ����S�̐ݒ�}�X�^�̃f�B�N�V���i���[���擾
                status = GetSalesTtlStWorkDic(((APSalesSlipWork)paramSalesSlipList[0]).EnterpriseCode, out salesTtlStDic);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;
            }

            SqlEncryptInfo sqlEncryptInfo = null;
            bool isHaveSalesSlip = false;
            string sectionCodeKey = ctSECTIONCODE_00; // ����S�̐ݒ�}�X�^�擾�p�̋��_�R�[�h
            foreach (APSalesInfoWork salesInfoWork in salesInfoList)
            {
                SalesSlipWork recvdSalesSlipWork = null;
                ArrayList recvdSalesDetailList = null;
                SalesSlipWork secSalesSlipWork = null;
                ArrayList secSalesDetailList = null;
                // ��M��������Ɣ��㖾�׃f�[�^�Ǝ�M���_������Ɣ��㖾�׃f�[�^���擾
                status = GetSecSalesInfo(salesInfoWork, out recvdSalesSlipWork, out recvdSalesDetailList, out secSalesSlipWork, out secSalesDetailList, sqlConnection, sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    // �G���[������
                    return status;

                isHaveSalesSlip = (null != secSalesSlipWork); // ���_�����゠�肩

                if (isHaveSalesSlip && recvdSalesSlipWork.DebitNoteDiv == 0 && secSalesSlipWork.DebitNoteDiv == 2) // ADD 2011/08/30 qijh #24209
                    // 2:���� -> 0:���`�̏ꍇ�A�W�v�݌ɑΏۊO
                    continue;

                // �W�v�݌ɍX�V�O�ɏ���(�o�׍������Ȃǂ̐ݒ�)
                TotalizeInitial(recvdSalesSlipWork, recvdSalesDetailList, secSalesDetailList);
                
                if (IsTtlObj(recvdSalesSlipWork, secSalesSlipWork, isHaveSalesSlip))
                {
                    // �W�v����
                    status = TotalizeProc(salesInfoWork, recvdSalesSlipWork, recvdSalesDetailList, secSalesSlipWork, secSalesDetailList, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;
                }
                if (2 != salesSlipRecvDiv)
                    continue;
                
                // �݌ɍX�V����̏ꍇ
                // �݌Ƀ}�X�^�A�݌Ɏ󕥗����f�[�^���X�V --------------------------------------------->
                if (salesTtlStDic.ContainsKey(recvdSalesSlipWork.SectionCode.Trim()))
                    sectionCodeKey = recvdSalesSlipWork.SectionCode.Trim();
                else if (salesTtlStDic.ContainsKey(ctSECTIONCODE_00))
                    sectionCodeKey = ctSECTIONCODE_00;
                else
                    // �v��c�敪���擾�ł��Ȃ��ꍇ�A�s���̌��ʂɂȂ�\��������̂ŁA�I���ɂ���
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // ����S�̐ݒ�}�X�^���v��c�敪��ݒ�
                StockUpdateDB.IOWriteCtrlOptWork.EstimateAddUpRemDiv = salesTtlStDic[sectionCodeKey].EstmateAddUpRemDiv; // ���σf�[�^�v��c�敪
                StockUpdateDB.IOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = salesTtlStDic[sectionCodeKey].AcpOdrrAddUpRemDiv; // �󒍃f�[�^�v��c�敪
                StockUpdateDB.IOWriteCtrlOptWork.ShipmAddUpRemDiv = salesTtlStDic[sectionCodeKey].ShipmAddUpRemDiv; // �o�׃f�[�^�v��c�敪
                StockUpdateDB.IOWriteCtrlOptWork.RetGoodsStockEtyDiv = salesTtlStDic[sectionCodeKey].RetGoodsStockEtyDiv;// �ԕi���݌ɓo�^�敪
                StockUpdateDB.IOWriteCtrlOptWork.SupplierSlipDelDiv = salesTtlStDic[sectionCodeKey].SupplierSlipDelDiv;// �d���`�[�폜�敪

                CustomSerializeArrayList cstSecList = new CustomSerializeArrayList();
                cstSecList.Add(secSalesSlipWork);
                cstSecList.Add(secSalesDetailList);

                CustomSerializeArrayList cstRecvdList = new CustomSerializeArrayList();
                cstRecvdList.Add(recvdSalesSlipWork);
                cstRecvdList.Add(recvdSalesDetailList);
                cstRecvdList.Add(GetAddUpOrgDetailList(salesDetailDic, recvdSalesDetailList)); // �v�㌳���׃��X�g���擾
                cstRecvdList.Add(GetSlipDetailAddInfoList(recvdSalesSlipWork, recvdSalesDetailList, isHaveSalesSlip, salesDetailDic)); // ���㖾�גǉ����̎擾

                object freeParam = null;
                string retMsg = null;
                string retItemInfo = null;

                //add zhujc 20110916 ------>>>>>>
                // �ݏo�`�[�A�_���폜�A�o�׃f�[�^�v��c���Ȃ��A��M�����݂��Ȃ�
                int logicDelFlg = salesInfoWork.SalesSlipWork.LogicalDeleteCode;

                if (40 == recvdSalesSlipWork.AcptAnOdrStatus && 1 == recvdSalesSlipWork.LogicalDeleteCode && 1 == salesTtlStDic[sectionCodeKey].ShipmAddUpRemDiv && !isHaveSalesSlip)
                {
                    ArrayList salesDetailList = null;
                    if(null != cstRecvdList && cstRecvdList.Count > 2)
                    {
                        salesDetailList = (ArrayList)cstRecvdList[1];
                    }

                    int i = 0;
                    int logicDeleteCode = 0;//ADD 2011/09/21 sundx #25379
                    foreach (APSalesDetailWork salesDetailWork in salesInfoWork.SalesDetailWorkList)
                    {
                        // �v�㌳���ׂł�
                        //if (IsAddUpOrgData(salesDetailWork, paramSalesDetailList))//DEL 2011/09/21 sundx #25379
                        if (IsAddUpOrgData(salesDetailWork, paramSalesDetailList, out logicDeleteCode) && logicDeleteCode == 0)//ADD 2011/09/21 sundx #25379
                        {
                            logicDelFlg = 0;

                            ((SalesSlipWork)cstRecvdList[0]).LogicalDeleteCode = 0;

                            ((SalesDetailWork)salesDetailList[i]).AcptAnOdrRemainCnt = ((SalesDetailWork)salesDetailList[i]).ShipmentCnt;
                        }
                        i++;
                    }
                    cstRecvdList[1] = salesDetailList;

                    TotalizeInitial((SalesSlipWork)cstRecvdList[0], (ArrayList)cstRecvdList[1], secSalesDetailList);
                }
                //add zhujc 20110916 ------<<<<<<

                //if (0 == salesInfoWork.SalesSlipWork.LogicalDeleteCode)  //del zhujc 20110916
                if (0 == logicDelFlg)  //add zhujc 20110916
                {
                    // �݌Ƀ}�X�^�X�V�O�����������s��
                    status = StockUpdateDB.WriteInitial(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;

                    // �݌Ƀ}�X�^�X�V�������s��
                    status = StockUpdateDB.Write(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;

                }
                else
                {
                    if (isHaveSalesSlip && 0 == secSalesSlipWork.LogicalDeleteCode)
                    {
                        // ����폜����ǉ�
                        cstRecvdList.Add(GetSalesSlipDeleteWork(secSalesSlipWork));  // ADD 2011/08/30 qijh #24175 #24209

                        // ��M�����v�㌳���׃f�[�^���A���_���̌v�㌳���㖾�׃f�[�^�̎󒍎c����ݒ�
                        SetAcptAnOdrRemainCntForAddUpOrgDetail(secSalesDetailList, recvdSalesDetailList); // ADD 2011/09/07 qijh #24343

                        // �݌Ƀ}�X�^�X�V�O�����������s��
                        status = StockUpdateDB.DeleteInitial(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            return status;

                        // �݌Ƀ}�X�^�X�V�������s��
                        status = StockUpdateDB.Delete(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            return status;
                    }
                }
                // �݌Ƀ}�X�^�A�݌Ɏ󕥗����f�[�^���X�V ---------------------------------------------<
            }
            return status;
        }
        #endregion [�p�u���b�N���@]

        #region [�v���C�x�[�g���@]
        // ------------------------- ADD 2011/09/07 qijh #24343 ----------------------- >>>>>
        /// <summary>
        /// ��M�����v�㌳���׃f�[�^���A���_���̌v�㌳���㖾�׃f�[�^�̎󒍎c����ݒ�
        /// </summary>
        /// <param name="secSalesDetailList">���_���̔��㖾�׃��X�g</param>
        /// <param name="recvdSalesDetailList">��M�������׃��X�g</param>
        private void SetAcptAnOdrRemainCntForAddUpOrgDetail(ArrayList secSalesDetailList, ArrayList recvdSalesDetailList)
        {
            // �v�㌳���ׂ��폜����ꍇ�A��M�����󒍎c���𗘗p���č݌ɍ폜���s���ׂɁA���Y�������s��(�G���g�����܂˂�)
            foreach (SalesDetailWork oldDtlWork in secSalesDetailList)
            {
                if (oldDtlWork.AcptAnOdrStatus != 40)
                    continue;
                foreach (SalesDetailWork newDtlWork in recvdSalesDetailList)
                {
                    if (newDtlWork.SalesSlipDtlNum == oldDtlWork.SalesSlipDtlNum && newDtlWork.AcptAnOdrStatus == oldDtlWork.AcptAnOdrStatus)
                    {
                        oldDtlWork.AcptAnOdrRemainCnt = newDtlWork.AcptAnOdrRemainCnt;
                        break;
                    }
                }
            }
        }
        // ------------------------- ADD 2011/09/07 qijh #24343 ----------------------- <<<<<

        // ------------------------- ADD 2011/08/30 qijh #24175 #24209 ----------------------- >>>>>
        /// <summary>
        /// ����폜�����擾
        /// </summary>
        /// <param name="paramSalesSlipWork">����`�[�f�[�^</param>
        /// <returns>����폜���</returns>
        private SalesSlipDeleteWork GetSalesSlipDeleteWork(SalesSlipWork paramSalesSlipWork)
        {
            // ����폜�����쐬
            SalesSlipDeleteWork salesSlipDeleteWork = new SalesSlipDeleteWork();
            salesSlipDeleteWork.AcptAnOdrStatus = paramSalesSlipWork.AcptAnOdrStatus;
            salesSlipDeleteWork.DebitNoteDiv = paramSalesSlipWork.DebitNoteDiv;
            salesSlipDeleteWork.EnterpriseCode = paramSalesSlipWork.EnterpriseCode;
            salesSlipDeleteWork.SalesSlipNum = paramSalesSlipWork.SalesSlipNum;
            salesSlipDeleteWork.UpdateDateTime = paramSalesSlipWork.UpdateDateTime;
            return salesSlipDeleteWork;
        }
        // ------------------------- ADD 2011/08/30 qijh #24175 #24209 ----------------------- <<<<<

        /// <summary>
        /// ����W�v�݌ɍX�V�̏����������s��
        /// </summary>
        /// <param name="recvdSalesSlipWork">��M��������f�[�^</param>
        /// <param name="recvdSalesDetailList">��M�������㖾�׃��X�g</param>
        /// <param name="secSalesDetailList">���_���̔��㖾�׃��X�g</param>
        private void TotalizeInitial(SalesSlipWork recvdSalesSlipWork, ArrayList recvdSalesDetailList, ArrayList secSalesDetailList)
        {
            if (recvdSalesSlipWork.LogicalDeleteCode == 0)
            {
                // �V�K�X�V�̏ꍇ
                foreach (SalesDetailWork newDtlWork in recvdSalesDetailList)
                {
                    // �o�׍������A�󒍎c���A�c���X�V���̏����l��ݒ�
                    newDtlWork.ShipmCntDifference = newDtlWork.ShipmentCnt;
                    newDtlWork.AcptAnOdrRemainCnt = newDtlWork.ShipmentCnt;
                    newDtlWork.RemainCntUpdDate = DateTime.Now;

                    if (recvdSalesSlipWork.DebitNoteDiv == 1 || null == secSalesDetailList || 0 == secSalesDetailList.Count)
                        // �ԓ`���͋��_���̔��㖾�ב��݂��Ȃ�
                        continue;
                    foreach (SalesDetailWork oldDtlWork in secSalesDetailList)
                    {

                        // ���ꖾ�ׂ̔��f�ɕi�ԁA���[�J�[���ǉ�
                        if (newDtlWork.EnterpriseCode == oldDtlWork.EnterpriseCode
                            && newDtlWork.AcptAnOdrStatus == oldDtlWork.AcptAnOdrStatus
                            && newDtlWork.SalesSlipDtlNum == oldDtlWork.SalesSlipDtlNum
                            && newDtlWork.GoodsNo == oldDtlWork.GoodsNo
                            && newDtlWork.GoodsMakerCd == oldDtlWork.GoodsMakerCd)
                        {
                            // �o�׍������̐ݒ�
                            newDtlWork.ShipmCntDifference = newDtlWork.ShipmentCnt - oldDtlWork.ShipmentCnt;

                            // �󒍎c���̐ݒ� (�X�V�O�󒍎c���{�X�V��o�׍�����)
                            newDtlWork.AcptAnOdrRemainCnt = oldDtlWork.AcptAnOdrRemainCnt + newDtlWork.ShipmCntDifference;

                            // �o�׍������� 0 �̏ꍇ�A�X�V�O�̎c���X�V����ݒ肷��
                            if (newDtlWork.ShipmCntDifference == 0)
                                newDtlWork.RemainCntUpdDate = oldDtlWork.RemainCntUpdDate;

                            break;
                        }
                    }
                }
            }
            else
            {
                // �폜�̏ꍇ
                if (null != secSalesDetailList && secSalesDetailList.Count > 0)
                    foreach (SalesDetailWork oldDtlWork in secSalesDetailList)
                        oldDtlWork.ShipmCntDifference = oldDtlWork.ShipmentCnt;
            }
        }

        /// <summary>
        /// ���㖾�גǉ���񃊃X�g���쐬
        /// </summary>
        /// <param name="recvdSalesSlipWork">��M��������f�[�^</param>
        /// <param name="recvdSalesDetailList">��M�������㖾�׃��X�g</param>
        /// <param name="isHaveSalesSlip">���_���ɔ���f�[�^�����邩</param>
        /// <param name="dic">��M�������㖾�ׂ̃f�B�N�V���i���[</param>
        /// <returns></returns>
        private ArrayList GetSlipDetailAddInfoList(SalesSlipWork recvdSalesSlipWork, ArrayList recvdSalesDetailList, bool isHaveSalesSlip, Dictionary<string, APSalesDetailWork> dic)
        {
            ArrayList retAddInfoList = new ArrayList();
            foreach (SalesDetailWork rvdDetailWk in recvdSalesDetailList)
            {
                SlipDetailAddInfoWork addInfoWk = new SlipDetailAddInfoWork();
                retAddInfoList.Add(addInfoWk);
                // �֘AGuid��ݒ�
                rvdDetailWk.DtlRelationGuid = rvdDetailWk.FileHeaderGuid;
                addInfoWk.DtlRelationGuid = rvdDetailWk.DtlRelationGuid;
                // �v��c�敪��ݒ� -------------------------------------->
                addInfoWk.AddUpRemDiv = 0;
                if (recvdSalesSlipWork.LogicalDeleteCode == 0 && isHaveSalesSlip == false 
                    && rvdDetailWk.AcptAnOdrStatusSrc == 20 
                    && dic.ContainsKey(GetSalesDetailKey(rvdDetailWk.AcptAnOdrStatusSrc, rvdDetailWk.SalesSlipDtlNumSrc)))
                {
                    // �V�K�̔���`�[�̏ꍇ�ŁA���_���̃f�[�^���Ȃ��̏ꍇ��
                    // ��M��������`�[�̌v�㌳�`�[������̏ꍇ�A�v��c���c��
                    addInfoWk.AddUpRemDiv = 1;     // �󒍃f�[�^�v��c�敪�@0:�`�[�ǉ����Q��,1:�c��,2:�c���Ȃ�
                }   
                // TODO:UOE�`�[�ɂ���(#23475)
                // �v��c�敪��ݒ� --------------------------------------<
            }
            return retAddInfoList;
        }

        /// <summary>
        /// �p�����[�^���`�F�b�N
        /// </summary>
        /// <param name="paramSalesSlipList">����`�[���X�g</param>
        /// <param name="paramSalesDetailList">���㖾�׃��X�g</param>
        /// <returns>true:�`�F�b�NOK�Afalse:�`�F�b�NNG</returns>
        private bool CheckParam(ArrayList paramSalesSlipList, ArrayList paramSalesDetailList)
        {
            if (null == paramSalesSlipList || null == paramSalesDetailList || paramSalesSlipList.Count == 0 || paramSalesDetailList.Count == 0)
                return false;
            return true;
        }
        
        /// <summary>
        /// ��ƃR�[�h�����[�N���X�g�ɃZ�b�g
        /// </summary>
        /// <param name="code">��ƃR�[�h</param>
        /// <param name="paramWkList">���[�N���X�g</param>
        private void SetEnterpriseCodeToWorkList(string code, ArrayList paramWkList)
        {
            if (null == paramWkList || paramWkList.Count == 0)
                return;
            foreach (Broadleaf.Library.Data.IFileHeader header in paramWkList)
                header.EnterpriseCode = code;
        }

        /// <summary>
        /// �v�㌳���׃��X�g���擾
        /// </summary>
        /// <param name="dic">���㖾�ׂ̃f�B�N�V���i���[</param>
        /// <param name="recvdSalesDetailList">��M�������㖾�׃f�[�^���X�g</param>
        /// <returns>�v�㌳���׃��X�g</returns>
        private ArrayList GetAddUpOrgDetailList(Dictionary<string, APSalesDetailWork> dic, ArrayList recvdSalesDetailList)
        {
            ArrayList addUpOrgList = new ArrayList();
            if (null == recvdSalesDetailList || recvdSalesDetailList.Count == 0)
                return addUpOrgList;

            foreach (SalesDetailWork detailwk in recvdSalesDetailList)
            {
                if (detailwk.AcptAnOdrStatusSrc > 0 && detailwk.SalesSlipDtlNumSrc > 0)
                {
                    string key = GetSalesDetailKey(detailwk.AcptAnOdrStatusSrc, detailwk.SalesSlipDtlNumSrc);
                    if (dic.ContainsKey(key))
                    {
                        // �v�㌳���ׂ���
                        APSalesDetailWork addUpOrgwk = dic[key];
                        if (null != addUpOrgwk)
                        {
                            AddUpOrgSalesDetailWork addUpOrgSalesDetailWork = SalesInfoConverter.GetAddUpOrgSalesDetailWork(addUpOrgwk);
                            // ���׊֘A�t��GUID��ݒ�
                            detailwk.DtlRelationGuid = detailwk.FileHeaderGuid;
                            addUpOrgSalesDetailWork.DtlRelationGuid = detailwk.FileHeaderGuid;
                            if (addUpOrgSalesDetailWork.AcptAnOdrStatus == 40)
                                addUpOrgSalesDetailWork.LogicalDeleteCode = 0; // add qijh 2011/09/07 #24343 �G���g�����ɍ݌ɍX�V���Ɍv�㌳���L���ŁA�݌ɍX�V��Ōv�㌳���폜
                            addUpOrgList.Add(addUpOrgSalesDetailWork);
                        }
                    }
                }
            }
            return addUpOrgList;
        }

        /// <summary>
        /// ���㖾�ׂ̃L�[���쐬
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipDtlNum">���㖾�גʔ�</param>
        /// <returns>���㖾�ׂ̃L�[</returns>
        private String GetSalesDetailKey(int acptAnOdrStatus, long salesSlipDtlNum)
        {
            StringBuilder sbKey = new StringBuilder();
            sbKey.Append(acptAnOdrStatus.ToString().PadLeft(2, '0'));
            sbKey.Append(salesSlipDtlNum.ToString().PadLeft(12, '0'));
            return sbKey.ToString();
        }

        /// <summary>
        /// ��M�������㖾�ׂ̃f�B�N�V���i���[���擾
        /// </summary>
        /// <param name="paramSalesDetailList">��M�������㖾�׃f�[�^���X�g</param>
        /// <returns>�f�B�N�V���i���[</returns>
        private Dictionary<string, APSalesDetailWork> GetSalesDetailDic(ArrayList paramSalesDetailList)
        {
            Dictionary<string, APSalesDetailWork> dic = new Dictionary<string, APSalesDetailWork>();
            string key = string.Empty;
            foreach (APSalesDetailWork detailwk in paramSalesDetailList)
            {
                key = GetSalesDetailKey(detailwk.AcptAnOdrStatus, detailwk.SalesSlipDtlNum);
                if (!dic.ContainsKey(key))
                    dic.Add(key, detailwk);
            }
            return dic;
        }

        /// <summary>
        /// �W�v�Ώۂ𔻒f����
        /// </summary>
        /// <param name="recvdSalesSlipWork">��M��������f�[�^</param>
        /// <param name="secSalesSlipWork">���_���̔���f�[�^</param>
        /// <param name="isHaveSalesSlip">���_���̔���f�[�^���肩�ǂ���</param>
        /// <returns>true:�W�v�Ώ� false:�W�v�ΏۂłȂ�</returns>
        private bool IsTtlObj(SalesSlipWork recvdSalesSlipWork, SalesSlipWork secSalesSlipWork, bool isHaveSalesSlip)
        {
            bool doTotalFlg = false;
            // �W�v�Ώۂ��𔻒f
            if (recvdSalesSlipWork.LogicalDeleteCode == 0)
            {
                // �V�K���͍X�V�̏ꍇ
                if (recvdSalesSlipWork.DebitNoteDiv == 1)
                {
                    // 1:�ԓ`
                    if (!isHaveSalesSlip)
                        doTotalFlg = true;
                }
                else if (recvdSalesSlipWork.DebitNoteDiv == 2)
                {
                    // 2:����
                    if (!isHaveSalesSlip)
                        doTotalFlg = true;
                }
                else
                {
                    // 0:���`
                    if (isHaveSalesSlip == false || 
                        (isHaveSalesSlip && secSalesSlipWork.DebitNoteDiv != 2))
                        doTotalFlg = true;
                }
            }
            else
            {
                // �`�[�폜�̏ꍇ
                if (isHaveSalesSlip && secSalesSlipWork.LogicalDeleteCode == 0)
                    doTotalFlg = true;
            }
            return doTotalFlg;
        }

        /// <summary>
        /// ��M��������Ɣ��㖾�׃f�[�^��
        /// ��M���_������Ɣ��㖾�׃f�[�^���擾
        /// </summary>
        /// <param name="paramSalesInfoWork">��M����������</param>
        /// <param name="recvdSalesSlipWork">�]��������M�̔���</param>
        /// <param name="recvdSalesDetailList">�]��������M�̔��㖾�׃��X�g</param>
        /// <param name="secSalesSlipWork">���_�̔���</param>
        /// <param name="secSalesDetailList">���_�̔��㖾�׃��X�g</param>
        /// <param name="sqlConnection">DB�̐ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetSecSalesInfo(APSalesInfoWork paramSalesInfoWork, out SalesSlipWork recvdSalesSlipWork, out ArrayList recvdSalesDetailList,
            out SalesSlipWork secSalesSlipWork, out ArrayList secSalesDetailList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            secSalesSlipWork = null;
            secSalesDetailList = new ArrayList();

            recvdSalesSlipWork = SalesInfoConverter.GetSecSalesSlipWork(paramSalesInfoWork.SalesSlipWork); // ��M��������f�[�^
            recvdSalesDetailList = new ArrayList(); // ��M�������㖾�׃f�[�^���X�g
            foreach (APSalesDetailWork apDetailWork in paramSalesInfoWork.SalesDetailWorkList)
            {
                // ��M�������㖾�׃��X�g���W�v�p�̃p�����[�^���X�g�ɃZ�b�g
                recvdSalesDetailList.Add(SalesInfoConverter.GetSecSalesDetailWork(apDetailWork));
            }

            // ��M���_��������擾
            SalesSlipReadWork salesSlipReadWork = GetSalesSlipReadWork(paramSalesInfoWork.SalesSlipWork);
            status = SalesSlipDB.ReadSalesSlipWorkIgnoreDel(out secSalesSlipWork, salesSlipReadWork, sqlConnection, sqlTransaction);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                // �G���[������
                return status;

            // ��M���_���ɓ`�[���Ȃ�
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                secSalesSlipWork = null;
                return status;
            }

            // ��M���_�̖��׃f�[�^���X�g���擾
            status = SalesSlipDB.ReadSalesDetailWorkIgnoreDel(out secSalesDetailList, salesSlipReadWork, sqlConnection, sqlTransaction);
            return status;
        }


        /// <summary>
        /// �W�v�������s��
        /// </summary>
        /// <param name="paramSalesInfoWork">��M����������</param>
        /// <param name="recvdSalesSlipWork">��M��������f�[�^</param>
        /// <param name="recvdSalesDetailList">��M�������㖾�׃��X�g</param>
        /// <param name="secSalesSlipWork">���_����f�[�^</param>
        /// <param name="secSalesDetailList">���_���㖾�׃��X�g</param>
        /// <param name="sqlConnection">DB�ڑ�</param>
        /// <param name="sqlTransaction">DB�g�����U�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        private int TotalizeProc(APSalesInfoWork paramSalesInfoWork, SalesSlipWork recvdSalesSlipWork, ArrayList recvdSalesDetailList,
            SalesSlipWork secSalesSlipWork, ArrayList secSalesDetailList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �W�v�p�̃p�����[�^���쐬
            ArrayList newSlipList = new ArrayList(); // ��M�������ナ�X�g
            ArrayList newItemList = new ArrayList();
            newSlipList.Add(newItemList);
            if (recvdSalesSlipWork.LogicalDeleteCode == 0)
                newItemList.Add(recvdSalesSlipWork);
            newItemList.Add(recvdSalesDetailList);

            ArrayList oldSlipList = new ArrayList(); // ���_�̔��ナ�X�g
            ArrayList oldItemList = new ArrayList();
            oldSlipList.Add(oldItemList);
            oldItemList.Add(secSalesSlipWork);
            oldItemList.Add(secSalesDetailList);

            // �W�v�����[�g���R�[��
            status = MonthlyTtlSalesUpdDB.Write(GetMTtlSalesUpdParaWork(paramSalesInfoWork.SalesSlipWork), newSlipList, oldSlipList, sqlConnection, sqlTransaction);
            return status;
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^�X�V�p�����[�^���擾����
        /// </summary>
        /// <param name="paramSalesSlipWork">��M��������f�[�^</param>
        /// <returns>���㌎���W�v�X�V�p�����[�^</returns>
        private MTtlSalesUpdParaWork GetMTtlSalesUpdParaWork(APSalesSlipWork paramSalesSlipWork)
        {
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork = new MTtlSalesUpdParaWork();
            mTtlSalesUpdParaWork.EnterpriseCode = paramSalesSlipWork.EnterpriseCode;  // ��ƃR�[�h
            // TODO:���_�R�[�h���͎��ьv�㋒�_�R�[�h��ݒ�H
            mTtlSalesUpdParaWork.AddUpSecCode = paramSalesSlipWork.SectionCode;       // �v�㋒�_�R�[�h(���_�R�[�h)
            mTtlSalesUpdParaWork.AddUpYearMonthSt = 0;                                // �v��N��(�J�n) 0:���w��
            mTtlSalesUpdParaWork.AddUpYearMonthEd = 0;                                // �v��N��(�I��) 0:���w��
            if (0 == paramSalesSlipWork.LogicalDeleteCode)
                mTtlSalesUpdParaWork.SlipRegDiv = 1;                                  // �`�[�o�^�敪 1:�o�^
            else
                mTtlSalesUpdParaWork.SlipRegDiv = 0;                                  // �`�[�o�^�敪 0:�폜
            mTtlSalesUpdParaWork.MTtlSalesPrcFlg = 1;                                 // ���㌎���W�v�f�[�^�����Ώۃt���O 1:�Ώ�
            mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg = 1;                               // ���i�ʔ��㌎���W�v�f�[�^�����Ώۃt���O 1:�Ώ�
            return mTtlSalesUpdParaWork;            
        }

        /// <summary>
        /// ���㌟���������[�N���擾
        /// </summary>
        /// <param name="paramSalesSlipWork">��M��������f�[�^</param>
        /// <returns>����f�[�^�ǂݍ��݃��[�N</returns>
        private SalesSlipReadWork GetSalesSlipReadWork(APSalesSlipWork paramSalesSlipWork)
        {
            SalesSlipReadWork salesSlipReadWork = new SalesSlipReadWork();
            salesSlipReadWork.EnterpriseCode = paramSalesSlipWork.EnterpriseCode;
            salesSlipReadWork.AcptAnOdrStatus = paramSalesSlipWork.AcptAnOdrStatus;
            salesSlipReadWork.SalesSlipNum = paramSalesSlipWork.SalesSlipNum;
            return salesSlipReadWork;
        }

        /// <summary>
        /// �v�㌳���ׂ��ǂ����𔻒f����
        /// </summary>
        /// <param name="paramSalesDetailWork">��M�������㖾�׃f�[�^</param>
        /// <param name="paramSalesDetailList">��M�������㖾�׃f�[�^���X�g</param>
        /// <returns>true : �v�㌳���ׂ� false:�v�㌳���ׂłȂ�</returns>
        private bool IsAddUpOrgData(APSalesDetailWork paramSalesDetailWork, ArrayList paramSalesDetailList)
        {
            bool isOrgFlg = false;
            for (int i = 0; i < paramSalesDetailList.Count; i++)
            {
                APSalesDetailWork salesDetailWork = (APSalesDetailWork)paramSalesDetailList[i];

                if (paramSalesDetailWork.AcptAnOdrStatus == salesDetailWork.AcptAnOdrStatusSrc
                    && paramSalesDetailWork.SalesSlipDtlNum == salesDetailWork.SalesSlipDtlNumSrc)
                {
                    isOrgFlg = true;
                    return isOrgFlg;
                }
            }
            return isOrgFlg;
        }

        /// <summary>
        /// �v�㌳���ׂ��ǂ����𔻒f����
        /// </summary>
        /// <param name="paramSalesDetailWork">��M�������㖾�׃f�[�^</param>
        /// <param name="paramSalesDetailList">��M�������㖾�׃f�[�^���X�g</param>
        /// <param name="logicDeleteCode">�_���폜�t���O</param>
        /// <returns>true : �v�㌳���ׂ� false:�v�㌳���ׂłȂ�</returns>
        private bool IsAddUpOrgData(APSalesDetailWork paramSalesDetailWork, ArrayList paramSalesDetailList, out int logicDeleteCode)
        {
            bool isOrgFlg = false;
            logicDeleteCode = 0;
            for (int i = 0; i < paramSalesDetailList.Count; i++)
            {
                APSalesDetailWork salesDetailWork = (APSalesDetailWork)paramSalesDetailList[i];

                if (paramSalesDetailWork.AcptAnOdrStatus == salesDetailWork.AcptAnOdrStatusSrc
                    && paramSalesDetailWork.SalesSlipDtlNum == salesDetailWork.SalesSlipDtlNumSrc)
                {
                    isOrgFlg = true;
                    logicDeleteCode = salesDetailWork.LogicalDeleteCode;
                    return isOrgFlg;
                }
            }
            return isOrgFlg;
        }

        /// <summary>
        /// ��M�����������g�ݍ��킹��
        /// </summary>
        /// <param name="paramSalesSlipList">��M��������f�[�^���X�g</param>
        /// <param name="paramSalesDetailList">��M�������㖾�׃f�[�^���X�g</param>
        /// <returns>�g�ݍ��킹�̔�����</returns>
        private List<APSalesInfoWork> GetAPSalesInfoList(ArrayList paramSalesSlipList, ArrayList paramSalesDetailList)
        {
            List<APSalesInfoWork> salesInfoList = new List<APSalesInfoWork>();

            if (null == paramSalesSlipList || null == paramSalesDetailList
                || paramSalesSlipList.Count == 0 || paramSalesDetailList.Count == 0)
                return salesInfoList;

            for (int i = 0; i < paramSalesSlipList.Count; i++)
            {
                // �����񃏁[�N���쐬
                APSalesInfoWork salesInfoWork = new APSalesInfoWork();

                APSalesSlipWork salesSlipWork = (APSalesSlipWork)paramSalesSlipList[i];
                // ����f�[�^��ǉ�
                salesInfoWork.SalesSlipWork = salesSlipWork;

                for (int j = 0; j < paramSalesDetailList.Count; j++)
                {
                    APSalesDetailWork salesDetailWork = (APSalesDetailWork)paramSalesDetailList[j];
                    if (salesSlipWork.EnterpriseCode == salesDetailWork.EnterpriseCode
                        && salesSlipWork.AcptAnOdrStatus == salesDetailWork.AcptAnOdrStatus
                        && salesSlipWork.SalesSlipNum == salesDetailWork.SalesSlipNum)
                        // ���㖾�׃f�[�^��ǉ�
                        salesInfoWork.SalesDetailWorkList.Add(salesDetailWork);
                }

                if (salesInfoWork.SalesDetailWorkList.Count > 0)
                    // ���㖾�ׂ��Ȃ������ΏۊO�Ƃ���
                    salesInfoList.Add(salesInfoWork);
            }
            return salesInfoList;
        }

        /// <summary>
        /// ����S�̐ݒ�}�X�^���擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="dic">�߂�l�̔���S�̐ݒ�}�X�^</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetSalesTtlStWorkDic(string enterpriseCode, out Dictionary<string, SalesTtlStWork> dic)
        {
            dic = new Dictionary<string, SalesTtlStWork>();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object salesTtlStWorkList = null;
            SalesTtlStWork paraSalesTtlStWork = new SalesTtlStWork();
            paraSalesTtlStWork.EnterpriseCode = enterpriseCode;

            // ����S�̐ݒ�}�X�^�̃����[�g
            status = new SalesTtlStDB().Search(out salesTtlStWorkList, (object)paraSalesTtlStWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                return status;

            ArrayList retSalesTtlStWorkList = salesTtlStWorkList as ArrayList;
            foreach (SalesTtlStWork item in retSalesTtlStWorkList)
            {
                string key = item.SectionCode.Trim();
                if (dic.ContainsKey(key))
                    continue;
                dic[key] = item;
            }
            return status;
        }
        #endregion [�v���C�x�[�g���@]
    }
}
