//**********************************************************************//
// �V�X�e��         �FPM.NS                                             //
// �v���O��������   �F���Ӑ�d�q�����f�[�^�擾�A�N�Z�X�N���X            //
// �v���O�����T�v   �F���Ӑ�d�q�����f�[�^�擾�A�N�Z�X�N���X            //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����                                                                 //
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                //
// �� �� ��  2013/05/29  �쐬���e : �V�K�쐬                            //
//----------------------------------------------------------------------//
// �C�����e  #37126�̑Ή�               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                   
// �� �� ��  2013/06/24  �쐬���e : ���Ӑ�`�[������� �`�[�敪�u�S�āv�ɂ���ƕ\������Ȃ�
//----------------------------------------------------------------------//
// �C�����e  #37231�̑Ή�               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                   
// �� �� ��  2013/06/24  �쐬���e : �^�u���b�g���O�Ή�
//----------------------------------------------------------------------//
// �C�����e  #37133�̑Ή�               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                   
// �� �� ��  2013/06/29  �쐬���e : �����������S�X�`�[�����\������Ȃ�
//----------------------------------------------------------------------//
// �C�����e  #37693�̑Ή�               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                   
// �� �� ��  2013/07/02  �쐬���e : ����ɓ��삵�Ȃ��ꍇ������
//----------------------------------------------------------------------//
// �C�����e  #37785�̑Ή�               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                   
// �� �� ��  2013/07/09  �쐬���e : ����50�����L���ɂȂ�܂���
//----------------------------------------------------------------------//
// �C�����e  #38047�̑Ή�               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                   
// �� �� ��  2013/07/09  �쐬���e : �����`�[�̖��ו\����PMNS�ƈقȂ�
//----------------------------------------------------------------------//
// �C�����e  #38182�̑Ή�               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                   
// �� �� ��  2013/07/11  �쐬���e : �y�����񓚏���(���Ӑ�d�q����)�z�\�[�g
//----------------------------------------------------------------------//
// �C�����e  #38220�̑Ή�               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                   
// �� �� ��  2013/07/11  �쐬���e : �s�K�v�ȃ��O�o�͂̍폜
//----------------------------------------------------------------------//
// �C�����e  #38430�̑Ή�               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : wangl2                                   
// �� �� ��  2013/07/16  �쐬���e : ���Ӑ�`�[�����@�\�����̕ύX
//----------------------------------------------------------------------//
// �C�����e  �w�E�E�m�F�����ꗗ_�Г��m�F�p��385
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/07/22  �쐬���e : ���������̋��_�@���O�C�����_���p�����[�^�̋��_
//----------------------------------------------------------------------//
// �C�����e  Redmine#38877
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �A����
// �� �� ��  2013/07/23  �쐬���e : �^�u���b�g ���Ӑ�d�q�����̔�����͎Җ��̂��J�b�g
//----------------------------------------------------------------------//
// �C�����e  ���O������
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/07/29  �쐬���e : ���O������
//----------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���Ӑ�d�q�����f�[�^�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�d�q�����f�[�^�擾�A�N�Z�X�N���X</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/05/29</br>
    /// <br>Update Note: �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/06/11</br>
    /// <br>Update Note: #37126�̑Ή��A���Ӑ�`�[������� �`�[�敪�u�S�āv�ɂ���ƕ\������Ȃ�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/06/24</br>
    /// <br>Update Note: Redmine#37231 FOR �^�u���b�g���O�Ή�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/06/25</br>
    /// <br>Update Note: Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/06/29</br>
    /// <br>Update Note: Redmine#37693 FOR ����ɓ��삵�Ȃ��ꍇ������</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/02</br>
    /// <br>Update Note: Redmine#37785 FOR ����50�����L���ɂȂ�܂���</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/09</br>
    /// <br>Update Note: Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/09</br>
    /// <br>Update Note: Redmine#38182 FOR �y�����񓚏���(���Ӑ�d�q����)�z�\�[�g</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/11</br>
    /// <br>Update Note: Redmine#38220 FOR �s�K�v�ȃ��O�o�͂̍폜</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : 2013/07/11</br>
    /// </remarks>
    public class CustPrtSlipTabSearchAcs
    {
        #region �� Private Members

        private ICustPrtPprWorkDB _iCustPrtPprWorkDB;  //���Ӑ�d�q���������[�g
        private IPmTabPrtPprRsltDB _iPmTabPrtPprRsltDB; //PMTAB���Ӑ�d�q���������[�g

        // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
        private const string CLASS_NAME = "CustPrtSlipTabSearchAcs";
        // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
       
        #endregion �� Private Members
        /// <summary>
        /// �풓�����ɂ��m�点��ׂ̕ϐ�
        /// </summary>
        public event NotifyTabletByPublishEventHandler notifyTabletByPublish;
        /// <summary>
        /// �풓�����ɂ��m�点��ׂ̃��\�b�h
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        /// <param name="pmTabSearchGuid"></param>
        public delegate void NotifyTabletByPublishEventHandler(int status, string msg, string pmTabSearchGuid); 

        #region �� Constructor
        /// <summary>
        /// ���Ӑ�d�q�����f�[�^�擾�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�d�q�����f�[�^�擾�A�N�Z�X�N���X</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        public CustPrtSlipTabSearchAcs()
        {
            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
            // �R���X�g���N�^�Ń��O�o�͗p�f�B���N�g�����쐬
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
            try
            {
                // �����[�g�C���X�^���X�擾
                this._iCustPrtPprWorkDB = MediationCustPrtPprWorkDB.GetCustPrtPprWorkDB();
                this._iPmTabPrtPprRsltDB = MediationPmTabPrtPprRsltDB.GetPmTabPrtPprRsltDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCustPrtPprWorkDB = null;
            }
        }
        #endregion �� Constructor

        #region �� Public Methods

        #region ��������

        #region ��������(���Ӑ�d�q����PM_USER_DB)
        /// <summary>
        /// ��������(���Ӑ�d�q����PM_USER_DB)
        /// </summary>
        /// <param name="enterpriseCode">���Ӑ�d�q�������X�g</param>
        /// <param name="sectionCode">���Ӑ�d�q������������</param>
        /// <param name="custPrtPprWork"></param>
        /// <param name="pmTabSearchGuid"></param>
        /// <param name="callCount"></param>
        /// <param name="msg"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�d�q�����}�X�^���������܂��B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/05/29</br>
        /// <br>Update Note: �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/11</br>
        /// <br>Update Note: #37126�̑Ή��A���Ӑ�`�[������� �`�[�敪�u�S�āv�ɂ���ƕ\������Ȃ�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/24</br>
        /// <br>Update Note: Redmine#37231 FOR �^�u���b�g���O�Ή�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/25</br>
        /// <br>Update Note: Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/29</br>
        /// <br>Update Note: Redmine#37693 FOR ����ɓ��삵�Ȃ��ꍇ������</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/02</br>
        /// <br>Update Note: Redmine#37785 FOR ����50�����L���ɂȂ�܂���</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        /// <br>Update Note: Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        /// <br>Update Note: Redmine#38182 FOR �y�����񓚏���(���Ӑ�d�q����)�z�\�[�g</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/11</br>
        /// </remarks>
        public int SearchPmToScm(string enterpriseCode, string sectionCode, CustPrtPprWork custPrtPprWork, string pmTabSearchGuid, int callCount, out string msg)
        {
            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
            const string methodName = "SearchPmToScm";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(���Ӑ�d�q����)�����@�J�n����������");
            EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(���Ӑ�d�q����)�����@�J�n��");
            // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName,
                "���������@��ƃR�[�h�F" + enterpriseCode
                + "  ���_�R�[�h�F" + sectionCode
                + "  AcptAnOdrStatus�F" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.AcptAnOdrStatus)
                + "  St_SalesDate�F" + custPrtPprWork.St_SalesDate.ToString()
                + "  Ed_SalesDate�F" + custPrtPprWork.Ed_SalesDate.ToString()
                + "  SectionCode�F" + string.Join(",", custPrtPprWork.SectionCode)
                + "  SalesSlipCd�F" + EasyLogger.LogUtlIntAryToCsv(custPrtPprWork.SalesSlipCd)
                + "  SearchType�F" + custPrtPprWork.SearchType.ToString()
                + "  PMTAB����GUID�F" + pmTabSearchGuid
                + "  �ʒm�����F" + callCount.ToString()
                );
            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
            ArrayList pmTabPrtPprRsltWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            msg = string.Empty;
            bool msgDiv = false;// ADD  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�

            try
            {
                if (!string.IsNullOrEmpty(pmTabSearchGuid))
                {
                    // �c���Ɖ�ɕ\������̂łP���̂�
                    CustPrtPprBlDspRsltWork custPrtPprBlDspRsltWork = new CustPrtPprBlDspRsltWork();
                    object custPrtPprBlDspRsltWorkObj = (object)custPrtPprBlDspRsltWork;

                    // ���ׂȂ̂�recordCount�����z��ŋA���Ă���
                    CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork = new CustPrtPprSalTblRsltWork();
                    object custPrtPprSalTblRsltWorkObj = (object)custPrtPprSalTblRsltWork;

                    // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��385 ------------>>>>>>>>>>>>
                    // this.SetSearchCondition(ref custPrtPprWork, enterpriseCode, sectionCode);
                    this.SetSearchCondition(ref custPrtPprWork, enterpriseCode, custPrtPprWork.SectionCode[0]);
                    // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��385 ------------<<<<<<<<<<<<

                    long counter = 0;

                    // ��������
                    // �폜�����܂܂Ȃ��ꍇ��GetData0���w��(�폜�t���O=0�̃f�[�^��Ԃ�)
                    status = this._iCustPrtPprWorkDB.SearchRef(ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData0);

                    //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) //DEL licb 2013/06/24 ���i�������ɋ󔒃��b�Z�[�W���\�������@#37126�̑Ή�
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)//ADD licb 2013/06/24 ���i�������ɋ󔒃��b�Z�[�W���\�������@#37126�̑Ή�
                    {
                        // �p�����[�^���n���ė��Ă��邩�m�F
                        ArrayList retList = custPrtPprSalTblRsltWorkObj as ArrayList;
                        if (retList == null)
                        {
                            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
                            // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(���Ӑ�d�q����)�����@�I������������");
                            EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(���Ӑ�d�q����)�����@�I����");
                            // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@status�F" + status.ToString() + " ���Ӑ�d�q�����������ʂ����݂��܂���");
                            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
                            return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                        }

                        if (counter == 0)
                        {
                            msg = "�Y������f�[�^������܂���B";
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
                            // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(���Ӑ�d�q����)�����@�I������������");
                            EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(���Ӑ�d�q����)�����@�I����");
                            // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@status�F" + status.ToString() + " " + msg);
                            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
                            return status;

                        }
                        // --------------- DEL START 2013/06/29 licb  Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�------>>>>
                        #region DEL
                        //// �f�[�^�ϊ�
                        //if (counter <= callCount)
                        //{

                        //    for (int i = 0; i < retList.Count; i++)
                        //    {
                        //        CustPrtPprSalTblRsltWork tempCustPrtPprSalTblRsltWork = retList[i] as CustPrtPprSalTblRsltWork;
                        //        int rowNo = i; //PMTAB�����s��
                        //        // �N���X�����o�R�s�[����
                        //        pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt(tempCustPrtPprSalTblRsltWork, pmTabSearchGuid, rowNo, sectionCode, enterpriseCode));
 
                        //    }

                        //    // status = this.Write(pmTabPrtPprRsltWorkList, out msg);// DEL  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                        //    status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);// ADD  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        msg = "�����������܂����B";
                        //    }

                        //}
                        //else
                        //{
                        //    //�ʒm����������ꍇ
                        //    if (callCount != 0 && callCount != -1)
                        //    {�@�@//��
                        //        long tempCnt = counter / callCount;
                        //        int tempCnt2 = 1;
                        //        for (int temp = 1; temp <= tempCnt; temp++)
                        //        {

                        //            for (int i = callCount * (tempCnt2 - 1); i < callCount * temp; i++)
                        //            {
                        //                //�N���X�����o�R�s�[����
                        //                pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt((CustPrtPprSalTblRsltWork)retList[i], pmTabSearchGuid, i, sectionCode, enterpriseCode));
                        //            }
                        //            //status = this.Write(pmTabPrtPprRsltWorkList, out msg);// DEL  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                        //            status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);// ADD  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                        //            pmTabPrtPprRsltWorkList.Clear();
                        //            string strCount = Convert.ToString(callCount);
                        //            if (!((counter == tempCnt * callCount) && (temp == tempCnt)))
                        //            {
                        //                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //                {
                        //                    msg = strCount + "���������܂����B";
                        //                }
                        //                notifyTabletByPublish(status, msg, pmTabSearchGuid);
                        //            }
                        //            else
                        //            {
                        //                msg = "�����������܂����B";
                        //            }
                        //            tempCnt2 = tempCnt2 + 1;
                        //        }
                        //        if (counter > tempCnt * callCount)
                        //        {
                        //            pmTabPrtPprRsltWorkList.Clear();

                        //            for (int j = Convert.ToInt32(tempCnt * callCount); j < counter; j++)
                        //            {
                        //                //�N���X�����o�R�s�[����
                        //                pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt((CustPrtPprSalTblRsltWork)retList[j], pmTabSearchGuid, j, sectionCode, enterpriseCode));

                        //            }
                        //            //status = this.Write(pmTabPrtPprRsltWorkList, out msg);// DEL  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                        //            status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);// ADD  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                        //            pmTabPrtPprRsltWorkList.Clear();
                        //            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //            {
                        //                msg = "�����������܂����B";
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        foreach (CustPrtPprSalTblRsltWork tempCustPrtPprSalTblRsltWork in retList)
                        //        {
                        //            int rowNo = 0; //PMTAB�����s��
                        //            // �N���X�����o�R�s�[����
                        //            pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt(tempCustPrtPprSalTblRsltWork, pmTabSearchGuid, rowNo, sectionCode, enterpriseCode));
                        //        }

                        //        //status = this.Write(pmTabPrtPprRsltWorkList, out msg);// DEL  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                        //        status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);// ADD  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //        {
                        //            msg = "�����������܂����B";
                        //        }

                        //    }

                        //}
                        #endregion DEL
                        // --------------- DEL END 2013/06/29 licb  Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�------<<<<
                        // --------------- ADD START 2013/06/29 licb  Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�------>>>>
                        Dictionary<string, List<CustPrtPprSalTblRsltWork>> RsltWorkDic = new Dictionary<string, List<CustPrtPprSalTblRsltWork>>();


                        // --------------- ADD START 2013/07/11 licb  Redmine#38182 FOR �y�����񓚏���(���Ӑ�d�q����)�z�\�[�g------>>>>
                        List<CustPrtPprSalTblRsltWork> sortWk = new List<CustPrtPprSalTblRsltWork>((CustPrtPprSalTblRsltWork[])retList.ToArray(typeof(CustPrtPprSalTblRsltWork)));
                        sortWk.Sort(delegate(CustPrtPprSalTblRsltWork x, CustPrtPprSalTblRsltWork y)
                        {
                            int st = 0;
                            //st = x.SalesDate.CompareTo(y.SalesDate);// DEL 2013/07/16 wangl2  Redmine#38430
                            st = (-1) * x.SalesDate.CompareTo(y.SalesDate);// ADD 2013/07/16 wangl2  Redmine#38430
                            if (st != 0) return st;
                            st = x.DataDiv.CompareTo(y.DataDiv);
                            if (st != 0) return st;
                            //st = x.SalesSlipNum.CompareTo(y.SalesSlipNum);// DEL 2013/07/16 wangl2  Redmine#38430
                            st = (-1) * x.SalesSlipNum.CompareTo(y.SalesSlipNum);// ADD 2013/07/16 wangl2  Redmine#38430
                            if (st != 0) return st;
                            st = x.AcptAnOdrStatus.CompareTo(y.AcptAnOdrStatus);
                            if (st != 0) return st;
                            st = x.SalesSlipCd.CompareTo(y.SalesSlipCd);
                            if (st != 0) return st;
                            st = x.SalesRowNo.CompareTo(y.SalesRowNo);
                            return st;
                        });
                        retList = new ArrayList();
                        retList.AddRange(sortWk);
                        // --------------- ADD START 2013/07/11 licb  Redmine#38182 FOR �y�����񓚏���(���Ӑ�d�q����)�z�\�[�g------<<<<

                         // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------>>>>
                        // �`�[�P�ʂ́A�u�`�[�ԍ��v�y�сu�󒍃X�e�[�^�X�v������̂��̂��ЂƂ̂�����Ƃ��Ĕ��肷��
                        CustPrtPprSalTblRsltWork prevRsltTempWork = null; // 1�O�̌�������
                        List<CustPrtPprSalTblRsltWork> listWk = null;
                        // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------<<<<
                        foreach (CustPrtPprSalTblRsltWork rsltTempWork in retList)
                        {
                             // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------>>>>
                            listWk = new List<CustPrtPprSalTblRsltWork>();
                            if (rsltTempWork.DataDiv == 1 && string.IsNullOrEmpty(rsltTempWork.GoodsName))
                            {
                                // �������� �萔���A�l�����݂̂̏ꍇ
                                listWk = AddFeeAndDiscountRow(rsltTempWork);
                            }
                            else
                            {
                                listWk.Add(rsltTempWork);
                            }
                            // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------<<<<

                             // --------------- DEL START 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------>>>>
                            # region ���\�[�X
                            //string key = rsltTempWork.SalesSlipNum;//DEL 2013/07/02 licb  Redmine#37693 FOR ����ɓ��삵�Ȃ��ꍇ������
                            //string key = rsltTempWork.SalesSlipNum + rsltTempWork.AcptAnOdrStatus;//ADD 2013/07/02 licb  Redmine#37693 FOR ����ɓ��삵�Ȃ��ꍇ������
                            //if (RsltWorkDic.ContainsKey(key))
                            //{
                            //    RsltWorkDic[key].Add(rsltTempWork);
                            //}
                            //else
                            //{
                            //    List<CustPrtPprSalTblRsltWork> list = new List<CustPrtPprSalTblRsltWork>();
                            //    list.Add(rsltTempWork);
                            //    RsltWorkDic.Add(key, list);
                            //}
                            #endregion
                            // --------------- DEL END 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------<<<<

                             // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------>>>>
                            // �o�^�����p�f�B�N�V���i���쐬
                            MakeRsltWorkDic(ref RsltWorkDic, listWk);
                            // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------<<<<

                             // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------>>>>
                            // 1�O�̓`�[�������̏ꍇ��prevRsltTempWork���쐬����Ă���
                            if (prevRsltTempWork != null)
                            {
                                // 1�O�̌������ʂƓ`�[���ς�����ꍇ
                                if ((!rsltTempWork.SalesSlipNum.Equals(prevRsltTempWork.SalesSlipNum) || rsltTempWork.AcptAnOdrStatus != prevRsltTempWork.AcptAnOdrStatus))
                                {
                                    listWk = null;
                                    // �萔���A�l�����̃f�[�^�𐶐����A�f�B�N�V���i���ɒǉ�
                                    listWk = AddFeeAndDiscountRow(prevRsltTempWork);
                                    MakeRsltWorkDic(ref RsltWorkDic, listWk);

                                    prevRsltTempWork = null;
                                }
                            }

                            // �����̏ꍇ�A�萔���A�l�����̖��ׂ͓`�[���ς�����^�C�~���O�Ő�������̂ŁA�ۊǂ���
                            // �A���A�萔���A�l�����݂̂̏ꍇ�͑ΏۊO
                            if (prevRsltTempWork == null && rsltTempWork.DataDiv == 1 && !string.IsNullOrEmpty(rsltTempWork.GoodsName))
                            {
                                prevRsltTempWork = rsltTempWork;
                            }
                            // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------<<<<
                        }
                         // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------>>>>
                        // �Ō�̂̓`�[�������̏ꍇ��prevRsltTempWork���쐬����Ă���
                        if (prevRsltTempWork != null)
                        {
                            listWk = null;
                            // �萔���A�l�����̃f�[�^�𐶐����A�f�B�N�V���i���ɒǉ�
                            listWk = AddFeeAndDiscountRow(prevRsltTempWork);
                            MakeRsltWorkDic(ref RsltWorkDic, listWk);

                            prevRsltTempWork = null;
                        }
                        // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------<<<<
                        int salesSlipCount = RsltWorkDic.Count; //�`�[����;

                        callCount = callCount * 2;//ADD 2013/07/09 licb  Redmine#37785 FOR ����50�����L���ɂȂ�܂���

                        #region �o�^����
                        // �f�[�^�ϊ�
                        if (salesSlipCount <= callCount)//�ʒm�������`�[�����͏������ꍇ
                        {

                            int rowNo = 0; //PMTAB�����s��

                            foreach (KeyValuePair<string, List<CustPrtPprSalTblRsltWork>> tempKeyValue in RsltWorkDic)
                            {

                                List<CustPrtPprSalTblRsltWork> custPrtPprSalTblRsltWorkList = tempKeyValue.Value;

                                for (int listCount = 0; listCount < custPrtPprSalTblRsltWorkList.Count; listCount++)
                                {
                                    // �N���X�����o�R�s�[����
                                    pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt(custPrtPprSalTblRsltWorkList[listCount], pmTabSearchGuid, rowNo, sectionCode, enterpriseCode));
                                }
                                ++rowNo;

                            }

                            status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                msg = "�����������܂����B";
                            }

                        }
                        else//�ʒm�������`�[�����͑傫���ꍇ
                        {
                            //�ʒm����������ꍇ
                            if (callCount > 0)
                            {
                                int rowNo = 0;//PMTAB�����s�ԍ�
                                int keyCount = 0;//���O����
                                foreach (KeyValuePair<string, List<CustPrtPprSalTblRsltWork>> tempKeyValue in RsltWorkDic)
                                {
                                    List<CustPrtPprSalTblRsltWork> custPrtPprSalTblRsltWorkList = tempKeyValue.Value;

                                    if (keyCount == callCount)
                                    {
                                        status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            if (rowNo == salesSlipCount)
                                            {
                                                msg = "�����������܂����B";
                                            }
                                            else
                                            {
                                                msg = callCount.ToString() + "���������܂����B";

                                                notifyTabletByPublish(status, msg, pmTabSearchGuid);
                                                pmTabPrtPprRsltWorkList.Clear();
                                            }
                                        }

                                        keyCount = 0;//���O����
                                    }

                                    for (int listCount = 0; listCount < custPrtPprSalTblRsltWorkList.Count; listCount++)
                                    {
                                        // �N���X�����o�R�s�[����
                                        pmTabPrtPprRsltWorkList.Add(CopyToPmTabPrtFromCustPrt(custPrtPprSalTblRsltWorkList[listCount], pmTabSearchGuid, rowNo, sectionCode, enterpriseCode));
                                    }

                                    ++rowNo;
                                    ++keyCount;
                                }

                                if (pmTabPrtPprRsltWorkList.Count > 0)
                                {
                                    status = this.Write(pmTabPrtPprRsltWorkList, out msgDiv, out msg);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        msg = "�����������܂����B";
                                    }

                                }


                            }

                        }

                        #endregion�@�o�^����

                        // --------------- ADD END 2013/06/29 licb  Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�------<<<<

                    }�@

                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    msg = "���Ӑ�d�q�����������s���܂���";
 
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
               // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
               // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
            }

            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
            // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(���Ӑ�d�q����)�����@�I������������");
            EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(���Ӑ�d�q����)�����@�I����");
            // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@status�F" + status.ToString() + " " + msg);
            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<

            return (status);
        }

        // --------------- ADD START 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------>>>>

        /// <summary>
        /// �o�^�����p�f�B�N�V���i���쐬
        /// </summary>
        /// <param name="RsltWorkDic">�o�^�����p�f�B�N�V���i��</param>
        /// <param name="listWk">�o�^�Ώۓ��Ӑ�d�q�����f�[�^���X�g</param>
        /// <br>Note       : �o�^�����p�f�B�N�V���i���쐬�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        private void MakeRsltWorkDic(ref Dictionary<string, List<CustPrtPprSalTblRsltWork>> RsltWorkDic, List<CustPrtPprSalTblRsltWork> listWk)
        {
            if (listWk.Count <= 0) return;

            string key = listWk[0].SalesSlipNum + listWk[0].AcptAnOdrStatus;
            if (RsltWorkDic.ContainsKey(key))
            {
                foreach (CustPrtPprSalTblRsltWork wk in listWk)
                {
                    RsltWorkDic[key].Add(wk);
                }
            }
            else
            {
                RsltWorkDic.Add(key, listWk);
            }
        }

        /// <summary>
        /// �萔���A�l���� �ǉ�����
        /// </summary>
        /// <param name="data"></param>
        /// <br>Note       : �萔���A�l���� �ǉ������B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        private List<CustPrtPprSalTblRsltWork> AddFeeAndDiscountRow(CustPrtPprSalTblRsltWork data)
        {
            List<CustPrtPprSalTblRsltWork> listTemp = new List<CustPrtPprSalTblRsltWork>();

            // �萔�����גǉ�
            if (data.FeeDeposit != 0)
            {
                CustPrtPprSalTblRsltWork wk = new CustPrtPprSalTblRsltWork();
                #region �萔���p���׍쐬
                wk.DataDiv = data.DataDiv;
                wk.SalesDate = data.SalesDate;
                wk.SalesSlipNum = data.SalesSlipNum;
                wk.SalesRowNo = 1000;
                wk.AcptAnOdrStatus = data.AcptAnOdrStatus;
                wk.SalesEmployeeNm = data.SalesEmployeeNm;
                wk.SalesSlipCd = data.SalesSlipCd;
                wk.SalesTotalTaxExc = data.SalesTotalTaxExc;
                wk.GoodsName = "�萔��";
                wk.GoodsNo = data.GoodsNo;
                wk.BLGoodsCode = data.BLGoodsCode;
                wk.BLGroupCode = data.BLGroupCode;
                wk.SalesMoneyTaxExc = data.FeeDeposit;
                wk.SlipNote = data.SlipNote;
                wk.SlipNote2 = data.SlipNote2;
                wk.SlipNote3 = data.SlipNote3;
                wk.FrontEmployeeNm = data.FrontEmployeeNm;
                wk.SalesInputName = data.SalesInputName;
                wk.CustomerCode = data.CustomerCode;
                wk.CustomerSnm = data.CustomerSnm;
                wk.GuideName = data.GuideName;
                wk.DtlNote = this.GetValidityTerm(data.DtlNote); // ���ה��l���L���������Z�b�g
                if (data.AddUpADate != DateTime.MinValue)
                {
                    wk.AddUpADate = data.AddUpADate;
                }
                wk.DebitNoteDiv = data.DebitNoteDiv;
                // ���͓�
                if (data.InputDay != DateTime.MinValue)
                {
                    wk.InputDay = data.InputDay;
                }
                #endregion
                listTemp.Add(wk);
            }

            if (data.DiscountDeposit != 0)
            {
                CustPrtPprSalTblRsltWork wk = new CustPrtPprSalTblRsltWork();
                #region �l���p���׍쐬
                wk.DataDiv = data.DataDiv;
                wk.SalesDate = data.SalesDate;
                wk.SalesSlipNum = data.SalesSlipNum;
                wk.SalesRowNo = 1001;
                wk.AcptAnOdrStatus = data.AcptAnOdrStatus;
                wk.SalesEmployeeNm = data.SalesEmployeeNm;
                wk.SalesSlipCd = data.SalesSlipCd;
                wk.SalesTotalTaxExc = data.SalesTotalTaxExc;
                wk.GoodsName = "�l��";
                wk.GoodsNo = data.GoodsNo;
                wk.BLGoodsCode = data.BLGoodsCode;
                wk.BLGroupCode = data.BLGroupCode;
                wk.SalesMoneyTaxExc = data.DiscountDeposit;
                wk.SlipNote = data.SlipNote;
                wk.SlipNote2 = data.SlipNote2;
                wk.SlipNote3 = data.SlipNote3;
                wk.FrontEmployeeNm = data.FrontEmployeeNm;
                wk.SalesInputName = data.SalesInputName;
                wk.CustomerCode = data.CustomerCode;
                wk.CustomerSnm = data.CustomerSnm;
                wk.GuideName = data.GuideName;
                wk.DtlNote = this.GetValidityTerm(data.DtlNote); // ���ה��l���L���������Z�b�g
                if (data.AddUpADate != DateTime.MinValue)
                {
                    wk.AddUpADate = data.AddUpADate;
                }
                wk.DebitNoteDiv = data.DebitNoteDiv;
                // ���͓�
                if (data.InputDay != DateTime.MinValue)
                {
                    wk.InputDay = data.InputDay;
                }
                #endregion
                listTemp.Add(wk);
            }

            return listTemp;
        }
        /// <summary>
        /// �L�������擾����
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        /// <br>Note       : �L�������擾�����B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        private string GetValidityTerm(string originText)
        {
            int validityTerm = 0;
            DateTime date;
            try
            {
                validityTerm = Int32.Parse(originText);
                date = GetDateTimeFromLongDate(validityTerm);
            }
            catch
            {
                date = DateTime.MinValue;
            }

            if (date == DateTime.MinValue)
            {
                // �󔒂ɂ���
                return string.Empty;
            }
            else
            {
                // yyyy/mm/dd�ŃZ�b�g
                return date.ToString("yyyy/MM/dd");
            }
        }
        /// <summary>
        /// ���t�擾�����iint��DateTime�ϊ��j
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        /// <br>Note       : ���t�擾�����iint��DateTime�ϊ��j�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/09</br>
        private DateTime GetDateTimeFromLongDate(int longDate)
        {
            try
            {
                return new DateTime((longDate / 10000), ((longDate / 100) % 100), (longDate % 100));
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        // --------------- ADD END 2013/07/09 licb  Redmine#38047 FOR �����`�[�̖��ו\����PMNS�ƈقȂ�------<<<<

        #endregion ��������(���Ӑ�d�q����PM_USER_DB)

        #endregion
        #endregion�� Public Methods

        #region�� �o�^����(���Ӑ�d�q����)
        /// <summary>
        /// �X�V����(���Ӑ�d�q����)
        /// </summary>
        /// <param name="pmTabPrtPprRsltWorkList">���Ӑ�d�q�������X�g</param>
        /// <param name="msg"></param>
        /// <param name="msgDiv">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�d�q�����}�X�^���X�V���܂��B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/05/29</br>
        /// <br>Update Note: �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/11</br>
        /// <br>Update Note: Redmine#37231 FOR �^�u���b�g���O�Ή�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/25</br>
        /// </remarks>
        //private int Write(ArrayList pmTabPrtPprRsltWorkList, out string msg)// DEL  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
        private int Write(ArrayList pmTabPrtPprRsltWorkList, out bool msgDiv, out string msg)// ADD  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
        {
            // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
            const string methodName = "Write";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = string.Empty;
            msgDiv = false;// ADD  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
            object paraPmTabPrtPprRsltObj = (object)pmTabPrtPprRsltWorkList;
            try
            {
                  // �X�V����
                //status = this._iPmTabPrtPprRsltDB.Write(ref paraPmTabPrtPprRsltObj);// DEL  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                status = this._iPmTabPrtPprRsltDB.Write(ref paraPmTabPrtPprRsltObj, out msgDiv, out msg);// ADD  2013/06/11 licb FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.9�̑Ή�
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �p�����[�^���n���ė��Ă��邩�m�F
                        ArrayList retList = paraPmTabPrtPprRsltObj as ArrayList;
                        if (retList == null)
                        {
                           // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
                            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ConstantManagement.DB_Status.ctDB_ERROR");
                           // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
                            return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                        } 
                   }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
               // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
               // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
            }

           // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
           // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
            return status;
        }
        #endregion     
               
        #region �� Private Methods

        #region �N���X�����o�R�s�[����
        /// <summary>
        /// �N���X�����o�R�s�[����
        /// </summary>
        /// <param name="custPrtPprSalTblRsltWork">���Ӑ�d�q�����}�X�^</param>
        /// <param name="pmTabSearchGuid"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="rowNo"></param>
        /// <param name="sectionCode"></param>
        /// <returns>���Ӑ�d�q�����}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/05/29</br>
        /// <br>Update Note: Redmine#37231 FOR �^�u���b�g���O�Ή�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/25</br>
        /// <br>Update Note: Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/29</br>
        /// <br>Update Note: Redmine#38220 FOR �s�K�v�ȃ��O�o�͂̍폜</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/07/11</br>
        /// </remarks>
        private PmTabPrtPprRsltWork CopyToPmTabPrtFromCustPrt(CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork, string pmTabSearchGuid, int rowNo, string sectionCode, string enterpriseCode)
        {
            // --------------- DEL START 2013/07/11 licb  Redmine#38220 FOR �s�K�v�ȃ��O�o�͂̍폜----->>>>
           //// --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
           // const string methodName = "CopyToPmTabPrtFromCustPrt";
           // EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
           //// --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
            // --------------- DEL END 2013/07/11 licb  Redmine#38220 FOR �s�K�v�ȃ��O�o�͂̍폜------<<<<
            PmTabPrtPprRsltWork pmTabPrtPprRsltWork = new PmTabPrtPprRsltWork();

            pmTabPrtPprRsltWork.UpdateDateTime = new DateTime(custPrtPprSalTblRsltWork.UpdateDateTime);//�X�V����
            pmTabPrtPprRsltWork.EnterpriseCode = enterpriseCode;
            pmTabPrtPprRsltWork.SearchSectionCode = sectionCode;	//�������_�R�[�h	
            pmTabPrtPprRsltWork.PmTabSearchGuid = pmTabSearchGuid;	//PMTAB����GUID	
            // --------------- ADD START 2013/06/29 licb  Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�------>>>>
            pmTabPrtPprRsltWork.PmTabSearchSlipNum = rowNo + 1;
            // --------------- ADD END 2013/06/29 licb  Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�------<<<<
            //pmTabPrtPprRsltWork.PmTabSearchRowNum = rowNo + 1;	//PMTAB�����s�ԍ�//DEL 2013/06/29 licb  Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�	
            pmTabPrtPprRsltWork.PmTabSearchRowNum = custPrtPprSalTblRsltWork.SalesRowNo; //PMTAB�����s�ԍ�//ADD 2013/06/29 licb  Redmine#37133 FOR �����������S�X�`�[�����\������Ȃ�
            pmTabPrtPprRsltWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));//�f�[�^�폜�\���	
	        pmTabPrtPprRsltWork.SalesDepoDiv = custPrtPprSalTblRsltWork.DataDiv;	//��������敪	
            pmTabPrtPprRsltWork.SalesDate = Convert.ToInt32(custPrtPprSalTblRsltWork.SalesDate.ToString("yyyyMMdd"));	//������t	
	        pmTabPrtPprRsltWork.SalesSlipNum = custPrtPprSalTblRsltWork.SalesSlipNum;	//����`�[�ԍ�	
	        pmTabPrtPprRsltWork.SalesRowNo = custPrtPprSalTblRsltWork.SalesRowNo;	//����s�ԍ�	
	        pmTabPrtPprRsltWork.AcptAnOdrStatus = custPrtPprSalTblRsltWork.AcptAnOdrStatus;//�󒍃X�e�[�^�X	
	        pmTabPrtPprRsltWork.SalesSlipCd = custPrtPprSalTblRsltWork.SalesSlipCd;//����`�[�敪	
	        pmTabPrtPprRsltWork.SalesEmployeeNm = custPrtPprSalTblRsltWork.SalesEmployeeNm;//�̔��]�ƈ�����	
	        pmTabPrtPprRsltWork.SalesTotalTaxExc = custPrtPprSalTblRsltWork.SalesTotalTaxExc;	//����`�[���v�i�Ŕ����j	
	        pmTabPrtPprRsltWork.GoodsName = custPrtPprSalTblRsltWork.GoodsName;	//���i����	
	        pmTabPrtPprRsltWork.GoodsNo = custPrtPprSalTblRsltWork.GoodsNo;	//���i�ԍ�	
	        pmTabPrtPprRsltWork.BLGoodsCode = custPrtPprSalTblRsltWork.BLGoodsCode;	//BL���i�R�[�h	
	        pmTabPrtPprRsltWork.BlGroupCode = custPrtPprSalTblRsltWork.BLGroupCode;	//BL�O���[�v�R�[�h	
	        pmTabPrtPprRsltWork.ShipmentCnt = custPrtPprSalTblRsltWork.ShipmentCnt;	//�o�א�	
	        pmTabPrtPprRsltWork.ListPriceTaxExcFl = custPrtPprSalTblRsltWork.ListPriceTaxExcFl;	//�艿�i�Ŕ��C�����j	
	        pmTabPrtPprRsltWork.CostRate = custPrtPprSalTblRsltWork.CostRate;	//������	
	        pmTabPrtPprRsltWork.SalesRate = custPrtPprSalTblRsltWork.SalesRate;	//������	
	        pmTabPrtPprRsltWork.OpenPriceDiv = custPrtPprSalTblRsltWork.OpenPriceDiv;	//�I�[�v�����i�敪	
	        pmTabPrtPprRsltWork.SalesUnPrcTaxExcFl = custPrtPprSalTblRsltWork.SalesUnPrcTaxExcFl;	//����P���i�Ŕ��C�����j	
	        pmTabPrtPprRsltWork.SalesUnitCost = custPrtPprSalTblRsltWork.SalesUnitCost;	//�����P��	
	        pmTabPrtPprRsltWork.SalesMoneyTaxExc = custPrtPprSalTblRsltWork.SalesMoneyTaxExc;	//������z�i�Ŕ����j	
	        pmTabPrtPprRsltWork.ConsTaxLayMethod = custPrtPprSalTblRsltWork.ConsTaxLayMethod;	//����œ]�ŕ���	
	        pmTabPrtPprRsltWork.SalesTotalTaxInc = custPrtPprSalTblRsltWork.SalesTotalTaxInc;	//����`�[���v�i�ō��݁j	
	        pmTabPrtPprRsltWork.SalesPriceConsTax = custPrtPprSalTblRsltWork.SalesPriceConsTax;	//������z����Ŋz	
	        pmTabPrtPprRsltWork.TotalCost = custPrtPprSalTblRsltWork.TotalCost;	//�������z�v	
	        pmTabPrtPprRsltWork.ModelDesignationNo = custPrtPprSalTblRsltWork.ModelDesignationNo;	//�^���w��ԍ�	
	        pmTabPrtPprRsltWork.CategoryNo = custPrtPprSalTblRsltWork.CategoryNo;	//�ޕʔԍ�	
	        pmTabPrtPprRsltWork.ModelFullName = custPrtPprSalTblRsltWork.ModelFullName;	//�Ԏ�S�p����	
	        pmTabPrtPprRsltWork.FirstEntryDate = custPrtPprSalTblRsltWork.FirstEntryDate;	//���N�x	
	        pmTabPrtPprRsltWork.PmFrameNo = custPrtPprSalTblRsltWork.SearchFrameNo;	//PM�ԑ�ԍ�	
	        pmTabPrtPprRsltWork.FullModel = custPrtPprSalTblRsltWork.FullModel;	//�^���i�t���^�j	
	        pmTabPrtPprRsltWork.SlipNote = custPrtPprSalTblRsltWork.SlipNote;	//�`�[���l	
	        pmTabPrtPprRsltWork.SlipNote2 = custPrtPprSalTblRsltWork.SlipNote2;	//�`�[���l�Q	
	        pmTabPrtPprRsltWork.SlipNote3 = custPrtPprSalTblRsltWork.SlipNote3;	//�`�[���l�R	
	        pmTabPrtPprRsltWork.FrontEmployeeNm = custPrtPprSalTblRsltWork.FrontEmployeeNm;	//��t�]�ƈ�����	
            //pmTabPrtPprRsltWork.SalesInputName = custPrtPprSalTblRsltWork.SalesInputName;	//������͎Җ���	// DEL �A���� 2013/07/23 Redmine#38877 �^�u���b�g ���Ӑ�d�q�����̔�����͎Җ��̂��J�b�g
            // ----- �A���� 2013/07/23 Redmine#38877 �^�u���b�g ���Ӑ�d�q�����̔�����͎Җ��̂��J�b�g----->>>>>
            if (custPrtPprSalTblRsltWork.SalesInputName.Length > 16)
            {
                pmTabPrtPprRsltWork.SalesInputName = custPrtPprSalTblRsltWork.SalesInputName.Substring(0,16);	//������͎Җ���	
            }
            else
            {
                pmTabPrtPprRsltWork.SalesInputName = custPrtPprSalTblRsltWork.SalesInputName;	//������͎Җ���	
            }
            // -----ADD �A���� 2013/07/23 Redmine#38877 �^�u���b�g ���Ӑ�d�q�����̔�����͎Җ��̂��J�b�g-----<<<<<
	        pmTabPrtPprRsltWork.CustomerCode = custPrtPprSalTblRsltWork.CustomerCode;	//���Ӑ�R�[�h	
	        pmTabPrtPprRsltWork.CustomerSnm = custPrtPprSalTblRsltWork.CustomerSnm;	//���Ӑ旪��	
	        pmTabPrtPprRsltWork.SupplierCd = custPrtPprSalTblRsltWork.SupplierCd;	//�d����R�[�h	
	        pmTabPrtPprRsltWork.SupplierSnm = custPrtPprSalTblRsltWork.SupplierSnm;	//�d���旪��	
	        pmTabPrtPprRsltWork.PartySaleSlipNum = custPrtPprSalTblRsltWork.PartySaleSlipNum;	//�����`�[�ԍ�	
	        pmTabPrtPprRsltWork.CarMngCode = custPrtPprSalTblRsltWork.CarMngCode;	//�ԗ��Ǘ��R�[�h	
	        pmTabPrtPprRsltWork.AcceptAnOrderNo = custPrtPprSalTblRsltWork.AcceptAnOrderNo;	//�󒍔ԍ�	
	        pmTabPrtPprRsltWork.ShipmSalesSlipNum = custPrtPprSalTblRsltWork.ShipmSalesSlipNum;	//�v�㌳�o�ד`�[�ԍ�	
	        pmTabPrtPprRsltWork.SrcSaleSlipNum = custPrtPprSalTblRsltWork.SrcSalesSlipNum;	//������`�[�ԍ�	
            pmTabPrtPprRsltWork.SalesOrderDivCd = custPrtPprSalTblRsltWork.SalesOrderDivCd;	//����݌Ɏ�񂹋敪	
	        pmTabPrtPprRsltWork.WarehouseName = custPrtPprSalTblRsltWork.WarehouseName;	//�q�ɖ���	
	        pmTabPrtPprRsltWork.SupplierSlipNo = custPrtPprSalTblRsltWork.SupplierSlipNo;	//�d���`�[�ԍ�	
	        pmTabPrtPprRsltWork.UOESupplierCd = custPrtPprSalTblRsltWork.UOESupplierCd;	//UOE������R�[�h	
	        pmTabPrtPprRsltWork.UOESupplierName = custPrtPprSalTblRsltWork.UOESupplierSnm;	//UOE�����於��	
	        pmTabPrtPprRsltWork.UoeRemark1 = custPrtPprSalTblRsltWork.UoeRemark1;	//�t�n�d���}�[�N�P	
	        pmTabPrtPprRsltWork.UoeRemark2 = custPrtPprSalTblRsltWork.UoeRemark2;	//�t�n�d���}�[�N�Q	
	        pmTabPrtPprRsltWork.GuideName = custPrtPprSalTblRsltWork.GuideName;	//�K�C�h����	
	        pmTabPrtPprRsltWork.SectionGuideNm = custPrtPprSalTblRsltWork.SectionGuideNm;	//���_�K�C�h����	
	        pmTabPrtPprRsltWork.DtlNote = custPrtPprSalTblRsltWork.DtlNote;	//���ה��l	
	        pmTabPrtPprRsltWork.ColorName1 = custPrtPprSalTblRsltWork.ColorName1;	//�J���[����1	
	        pmTabPrtPprRsltWork.TrimName = custPrtPprSalTblRsltWork.TrimName;	//�g��������	
	        pmTabPrtPprRsltWork.StdUnPrcLPrice = custPrtPprSalTblRsltWork.StdUnPrcLPrice;	//��P���i�艿�j	
	        pmTabPrtPprRsltWork.StdUnPrcSalUnPrc = custPrtPprSalTblRsltWork.StdUnPrcSalUnPrc;	//��P���i����P���j	
	        pmTabPrtPprRsltWork.StdUnPrcUnCst = custPrtPprSalTblRsltWork.StdUnPrcUnCst;	//��P���i�����P���j	
	        pmTabPrtPprRsltWork.BfSalesUnitPrice = custPrtPprSalTblRsltWork.BfSalesUnitPrice;	//�ύX�O����	
	        pmTabPrtPprRsltWork.BfUnitCost = custPrtPprSalTblRsltWork.BfUnitCost;	//�ύX�O����	
	        pmTabPrtPprRsltWork.BfListPrice = custPrtPprSalTblRsltWork.BfListPrice;	//�ύX�O�艿	
	        pmTabPrtPprRsltWork.GoodsMakerCd = custPrtPprSalTblRsltWork.GoodsMakerCd;	//���i���[�J�[�R�[�h	
	        pmTabPrtPprRsltWork.MakerName = custPrtPprSalTblRsltWork.MakerName;	//���[�J�[����	
	        pmTabPrtPprRsltWork.Cost = custPrtPprSalTblRsltWork.Cost;	//����	
	        pmTabPrtPprRsltWork.CustSlipNo = custPrtPprSalTblRsltWork.CustSlipNo;	//���Ӑ�`�[�ԍ�	
	        pmTabPrtPprRsltWork.AddUpADate = Convert.ToInt32(custPrtPprSalTblRsltWork.AddUpADate.ToString("yyyyMMdd"));	//�v����t	
	        pmTabPrtPprRsltWork.AccRecDivCd = custPrtPprSalTblRsltWork.AccRecDivCd;	//���|�敪	
	        pmTabPrtPprRsltWork.DebitNoteDiv = custPrtPprSalTblRsltWork.DebitNoteDiv;	//�ԓ`�敪	
	        pmTabPrtPprRsltWork.SectionCode = custPrtPprSalTblRsltWork.SectionCode;	//���_�R�[�h	
	        pmTabPrtPprRsltWork.WarehouseCode = custPrtPprSalTblRsltWork.WarehouseCode;	//�q�ɃR�[�h	
	        pmTabPrtPprRsltWork.TotalAmountDispWayCd = custPrtPprSalTblRsltWork.TotalAmountDispWayCd;	//���z�\�����@�敪	
	        pmTabPrtPprRsltWork.TaxationDivCd = custPrtPprSalTblRsltWork.TaxationDivCd;//�ېŋ敪	
            pmTabPrtPprRsltWork.StockPartySaleSlipNum = custPrtPprSalTblRsltWork.StockPartySaleSlipNum;	//�d����`�[�ԍ�	
	        pmTabPrtPprRsltWork.AddresseeCode = custPrtPprSalTblRsltWork.AddresseeCode;	//�[�i��R�[�h	
	        pmTabPrtPprRsltWork.AddresseeName = custPrtPprSalTblRsltWork.AddresseeName;	//�[�i�於��	
	        pmTabPrtPprRsltWork.AddresseeName2 = custPrtPprSalTblRsltWork.AddresseeName2;	//�[�i�於��2	
	        pmTabPrtPprRsltWork.FrameNo = custPrtPprSalTblRsltWork.FrameNo;	//�ԑ�ԍ�	
	        pmTabPrtPprRsltWork.AcptAnOdrRemainCnt = custPrtPprSalTblRsltWork.AcptAnOdrRemainCnt;	//�󒍎c��	
	        pmTabPrtPprRsltWork.EnterpriseGanreCode = custPrtPprSalTblRsltWork.EnterpriseGanreCode;	//���Е��ރR�[�h	
	        pmTabPrtPprRsltWork.FeeDeposit = custPrtPprSalTblRsltWork.FeeDeposit;	//�萔�������z	
	        pmTabPrtPprRsltWork.DiscountDeposit = custPrtPprSalTblRsltWork.DiscountDeposit;	//�l�������z	
	        pmTabPrtPprRsltWork.InputDay = Convert.ToInt32(custPrtPprSalTblRsltWork.InputDay.ToString(("yyyyMMdd")));	//���͓�	
	        pmTabPrtPprRsltWork.GoodsKindCode = custPrtPprSalTblRsltWork.GoodsKindCode;	//���i����	
	        pmTabPrtPprRsltWork.GoodsLGroup = custPrtPprSalTblRsltWork.GoodsLGroup;	//���i�啪�ރR�[�h	
	        pmTabPrtPprRsltWork.GoodsMGroup = custPrtPprSalTblRsltWork.GoodsMGroup;	//���i�����ރR�[�h	
	        pmTabPrtPprRsltWork.WarehouseShelfNo = custPrtPprSalTblRsltWork.WarehouseShelfNo;	//�q�ɒI��	
	        pmTabPrtPprRsltWork.SalesSlipCdDtl = custPrtPprSalTblRsltWork.SalesSlipCdDtl;	//����`�[�敪�i���ׁj	
	        pmTabPrtPprRsltWork.GoodsLGroupName = custPrtPprSalTblRsltWork.GoodsLGroupName;	//���i�啪�ޖ���	
	        pmTabPrtPprRsltWork.GoodsMGroupName = custPrtPprSalTblRsltWork.GoodsMGroupName;	//���i�����ޖ���	
	        pmTabPrtPprRsltWork.CarMngNo = custPrtPprSalTblRsltWork.CarMngNo;	//�ԗ��Ǘ��ԍ�	
	        pmTabPrtPprRsltWork.MakerCode = custPrtPprSalTblRsltWork.MakerCode;	//���[�J�[�R�[�h	
	        pmTabPrtPprRsltWork.ModelCode = custPrtPprSalTblRsltWork.ModelCode;	//�Ԏ�R�[�h	
	        pmTabPrtPprRsltWork.ModelSubCode = custPrtPprSalTblRsltWork.ModelSubCode;	//�Ԏ�T�u�R�[�h	
	        pmTabPrtPprRsltWork.EngineModelNm = custPrtPprSalTblRsltWork.EngineModelNm;	//�G���W���^������	
	        pmTabPrtPprRsltWork.ColorCode = custPrtPprSalTblRsltWork.ColorCode;	//�J���[�R�[�h	
	        pmTabPrtPprRsltWork.TrimCode = custPrtPprSalTblRsltWork.TrimCode;	//�g�����R�[�h	
	        pmTabPrtPprRsltWork.DeliveredGoodsDiv = custPrtPprSalTblRsltWork.DeliveredGoodsDiv;	//�[�i�敪	
	        pmTabPrtPprRsltWork.SalesInputCode = custPrtPprSalTblRsltWork.SalesInputCode;	//������͎҃R�[�h	
	        pmTabPrtPprRsltWork.FrontEmployeeCd = custPrtPprSalTblRsltWork.FrontEmployeeCd;	//��t�]�ƈ��R�[�h	
	        pmTabPrtPprRsltWork.HistoryDiv = custPrtPprSalTblRsltWork.HistoryDiv;	//�����敪	
	        pmTabPrtPprRsltWork.Mileage = custPrtPprSalTblRsltWork.Mileage;	//�ԗ����s����	
	        pmTabPrtPprRsltWork.CarNote = custPrtPprSalTblRsltWork.CarNote;	//���q���l	
	        pmTabPrtPprRsltWork.RetUpperCnt = custPrtPprSalTblRsltWork.Retuppercnt;	//�ԕi�����	
	        pmTabPrtPprRsltWork.RetupperCntDiv = custPrtPprSalTblRsltWork.RetuppercntDiv;	//�ԕi��������݃t���O	
	        pmTabPrtPprRsltWork.HisDtlSlipNum = custPrtPprSalTblRsltWork.HisDtlSlipNum;	//����`�[�ԍ�(����)	
	        pmTabPrtPprRsltWork.AcptAnOdrStatusSrc = custPrtPprSalTblRsltWork.AcptAnOdrStatusSrc;	//�󒍃X�e�[�^�X�i���j	
	        pmTabPrtPprRsltWork.AutoAnswerDivSCM = custPrtPprSalTblRsltWork.AutoAnswerDivSCM;	//�����񓚋敪(SCM)	
            pmTabPrtPprRsltWork.InquiryNumber = custPrtPprSalTblRsltWork.InquiryNumber;	//�⍇���ԍ�	

            // --------------- DEL START 2013/07/11 licb  Redmine#38220 FOR �s�K�v�ȃ��O�o�͂̍폜----->>>>
           //// --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
           // EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
           //// --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
            // --------------- DEL END 2013/07/11 licb  Redmine#38220 FOR �s�K�v�ȃ��O�o�͂̍폜------<<<<
            return pmTabPrtPprRsltWork;
        }
     
        #endregion �N���X�����o�R�s�[����

        /// <summary>
        /// ���o�������Z�b�g
        /// </summary>
        /// <param name="custPrtPprWork">���o����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���o�������Z�b�g�B</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/18</br>
        /// <br>Update Note: Redmine#37231 FOR �^�u���b�g���O�Ή�</br>
        /// <br>�Ǘ��ԍ�   : 10902622-01</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : 2013/06/25</br>
        /// </remarks>
        private void SetSearchCondition(ref CustPrtPprWork custPrtPprWork, string enterpriseCode, string sectionCode)
        {
           // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
            const string methodName = "SetSearchCondition";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
           // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
            custPrtPprWork.EnterpriseCode = enterpriseCode;
            custPrtPprWork.SectionCode = new string[] { sectionCode };
            custPrtPprWork.SalesOrderDivCd = -1;
            custPrtPprWork.SearchCnt = 20001;
            custPrtPprWork.WarehouseCode = string.Empty;
            custPrtPprWork.SupplierSlipNo = string.Empty;
            custPrtPprWork.GoodsKindCode = -1;
            custPrtPprWork.FrameNo = string.Empty;
�@          custPrtPprWork.GoodsKindCode = -1;
          // --------------- ADD START 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------>>>>
           EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
          // --------------- ADD END 2013/06/25 licb  Redmine#37231 FOR �^�u���b�g���O�Ή�------<<<<
        }
               
        #endregion �� Private Methods
    }
}
