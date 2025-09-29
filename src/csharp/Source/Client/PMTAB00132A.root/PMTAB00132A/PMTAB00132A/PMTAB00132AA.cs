//****************************************************************************//
// �V�X�e��         : PMTAB �����񓚏���(���Ӑ���)                          //
// �v���O��������   : PMTAB �����񓚏���(���Ӑ���)View                      //
// �v���O�����T�v   :                                                         //
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : wangl2                                    //
// �� �� ��  2013/05/29  �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PMTAB �����񓚏���(���Ӑ���)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB �����񓚏���(���Ӑ���)�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/05/29</br>
    /// <br>Update Note: �\�[�X�`�F�b�N�m�F�����ꗗNO.8�̑Ή�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/10</br>
    /// <br>Update Note: �\�[�X�`�F�b�N�m�F�����ꗗNO.9,NO.11�̑Ή�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/11</br>
    /// <br>Update Note: Redmine#37231 FOR �^�u���b�g���O�Ή�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/25</br>
    /// <br>Update Note: �������ԒZ�k�ׁ̈A���O�o�͍폜</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : �g��</br>
    /// <br>Date       : 2013/07/29</br>
    /// <br>Update Note: ���O������</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : �g��</br>
    /// <br>Date       : 2013/07/29</br>
    /// <br>Update Note: Redmine#39755</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/08/08</br>
    /// <br>Update Note: Redmine#39923 ��������擾</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2013/08/13</br>
    /// </remarks>
    public class TabSCMCustomerAcs
    {
        #region [Private Members]
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ICustomerSearchDB _iCustomerSearchDB = null;

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        //private IPmTabCustomerTmpDB _iPmTabCustomerTmpDB = null;// DEL 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.8�̑Ή�
        private IPmTabCustTmpDB _iPmTabCustomerTmpDB = null;// ADD 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.8�̑Ή�

        // �^�u���b�g���O�Ή��@--------------------------------->>>>>
        private const string CLASS_NAME = "TabSCMCustomerAcs";
        // �^�u���b�g���O�Ή��@---------------------------------<<<<<

        /// <summary>
        /// PMTAB�S�̐ݒ�}�X�^�����[�g
        /// </summary>
        private IPmTabTtlStCustDB _iPmTabTtlStCustDB;// ADD 2013/08/08 wangl2 for Redmine#39755
        #endregion

        /// <summary>
        /// PMTAB �����񓚏���(���Ӑ���)�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PMTAB �����񓚏���(���Ӑ���)�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
        /// <br></br>
        /// </remarks>
        public TabSCMCustomerAcs()
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // �R���X�g���N�^�Ń��O�o�͗p�f�B���N�g�����쐬
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            const string methodName = "TabSCMCustomerAcs";
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iCustomerSearchDB = (ICustomerSearchDB)MediationCustomerSearchDB.GetCustomerSearchDB();
                //this._iPmTabCustomerTmpDB = (IPmTabCustomerTmpDB)MediationPmTabCustomerTmpDB.GetPmTabCustomerTmpDB();// DEL 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.8�̑Ή�
                this._iPmTabCustomerTmpDB = (IPmTabCustTmpDB)MediationPmTabCustTmpDB.GetPmTabCustTmpDB();// ADD 2013/06/10 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.8�̑Ή�
                this._iPmTabTtlStCustDB = (IPmTabTtlStCustDB)MediationPmTabTtlStCustDB.GetPmTabTtlStCustDB();// ADD 2013/08/08 wangl2 for Redmine#39755
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // catch (Exception)
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                //�I�t���C������null���Z�b�g
                this._iCustomerSearchDB = null;
                this._iPmTabCustomerTmpDB = null;
            }
        }

        #region Public Methods
        #region Public Methods
        /// <summary>
        /// PMTAB���Ӑ挟������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="kana">�J�i</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="mngSectionCode">�Ǘ����_</param>
        /// <param name="kanaSearchType">���Ӑ�J�i�����^�C�v</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PMTAB���Ӑ挟���������s���܂��B</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        public int SearchCustomerDataForTablet(string enterpriseCode, string sectionCode, string businessSessionId, string kana, int customerCode, string mngSectionCode, int kanaSearchType, out string errMsg)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "SearchCustomerDataForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(���Ӑ���)�@�J�n����������");
            EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(���Ӑ���)�@�J�n��");
            // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMsg = string.Empty;
            // �������ʃ��X�g
            ArrayList pmTabCustomerTmpWorkList = new ArrayList();
            // �����p�����[�^�[
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            // ��ƃR�[�h
            customerSearchPara.EnterpriseCode = enterpriseCode;
            // �Ǘ����_�R�[�h
            customerSearchPara.MngSectionCode = mngSectionCode;
            // ���Ӑ�J�i
            customerSearchPara.Kana = kana;
            // ���Ӑ�R�[�h
            customerSearchPara.CustomerCode = customerCode;
            // ���Ӑ�J�i�����^�C�v
            customerSearchPara.KanaSearchType = kanaSearchType;
            if (!string.IsNullOrEmpty(businessSessionId))
            {
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "�����񓚏����i���Ӑ���j��������"
                    + "�@��ƃR�[�h�F" + enterpriseCode
                    + "  ���_�R�[�h�F" + sectionCode
                    + "  �Ɩ��Z�b�V����ID�F" + businessSessionId
                    + "  ���Ӑ於�J�i�F" + kana
                    + "  ���Ӑ�R�[�h�F" + customerCode
                    + "  �Ǘ����_�F" + mngSectionCode
                    + "  �Ŗ������敪�F" + kanaSearchType.ToString()
                    );
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                // PMTAB���Ӑ��񌟍�(PM_USER_DB)
                status = this.SearchForTablet(out pmTabCustomerTmpWorkList, customerSearchPara, businessSessionId, sectionCode, ConstantManagement.LogicalMode.GetData0, out errMsg);
                // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "�����Ӑ�}�X�^�ݒ��񌟍��@status�F" + status.ToString());
                // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                    int cnt = 0;
                    if (pmTabCustomerTmpWorkList != null)
                    {
                        cnt = pmTabCustomerTmpWorkList.Count;
                    }
                    EasyLogger.Write(CLASS_NAME, methodName, "�����ݑΏی����F" + cnt.ToString());
                    // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                    if (pmTabCustomerTmpWorkList != null && pmTabCustomerTmpWorkList.Count > 0)
                    {
                        // ���Ӑ�f�[�^�̓o�^����(PM_SCM_DB)
                        status = this.WriteForTablet(ref pmTabCustomerTmpWorkList, out errMsg);
                        // �^�u���b�g���O�Ή��@--------------------------------->>>>>
                        EasyLogger.Write(CLASS_NAME, methodName, "�����Ӑ�}�X�^�ݒ��񏑍��݁@status�F" + status.ToString());
                        // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                    }
                    else
                    {
                        errMsg = "�Y���f�[�^�����݂��܂���B";
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            else 
            {
                errMsg = "PMTAB���Ӑ��񌟍��Ɏ��s���܂����B";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "���������������񓚏���(���Ӑ���)�@�J�n����������");
            EasyLogger.Write(CLASS_NAME, methodName, "�������񓚏���(���Ӑ���)�@�J�n��");
            // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return status;

        }
        #endregion

        
        #endregion

        #region Private Methods

        /// <summary>
        /// PMTAB���Ӑ��񌟍�
        /// </summary>
        /// <param name="pmTabCustomerTmpWorkList">�������ʃ��X�g</param>
        /// <param name="customerSearchPara">���������f�[�^</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: PMTAB���Ӑ��񌟍����s���܂��B</br>
        /// <br>Programmer	: wangl2</br>
        /// <br>Date		: 2013/05/29</br>
        /// </remarks>
        private int SearchForTablet(out ArrayList pmTabCustomerTmpWorkList, CustomerSearchPara customerSearchPara, string businessSessionId, string sectionCode, ConstantManagement.LogicalMode logicalMode, out String errMsg)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "SearchForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            pmTabCustomerTmpWorkList = new ArrayList();
            // �����������[�N
            CustomerSearchParaWork customerSearchParaWork = new CustomerSearchParaWork();
            // ���Ӑ挟�������N���X�˓��Ӑ挟�����[�N�N���X
            customerSearchParaWork = CopyToParamDataFromUIData(customerSearchPara);
            // ���������I�u�W�F�N�g
            object paraObj = customerSearchParaWork;
            // �������ʃI�u�W�F�N�g
            object retObj;
            errMsg = "";
            try
            {
                // ���Ӑ挟�� 
                status = this._iCustomerSearchDB.SearchForTablet(out retObj, ref paraObj, logicalMode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            ArrayList customerWorkList = retObj as ArrayList;
                            if (customerWorkList != null && customerWorkList.Count > 0)
                            {
                                // ���Ӑ挟�������N���X��PMTAB���Ӑ挟�����ʃf�[�^
                                pmTabCustomerTmpWorkList = CopyToCustomerDataToUIData(customerWorkList, customerSearchParaWork, businessSessionId, sectionCode);
                            }
                            break;
                        }
                    default:
                        {
                            errMsg = "PMTAB���Ӑ��񌟍��Ɏ��s���܂����B";
                            break;
                        }
                }
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // catch (Exception)
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = "PMTAB���Ӑ��񌟍��Ɏ��s���܂����B";
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return status;

        }

        /// <summary>
        /// ���Ӑ���S���o�^����
        /// </summary>
        /// <param name="pmTabCustomerTmpList">���Ӑ�f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: ���Ӑ�f�[�^�̓o�^�������s���܂��B</br>
        /// <br>Programmer	: wangl2</br>
        /// <br>Date		: 2013/05/29</br>
        /// </remarks>
        private int WriteForTablet(ref ArrayList pmTabCustomerTmpList, out string errMsg)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "WriteForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMsg = string.Empty;
            bool msgDiv;// ADD 2013/06/11 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.9,NO.11�̑Ή�
            try
            {
                // ���Ӑ�I�u�W�F�N�g
                object pmTabCustomerTmpWorkobj = pmTabCustomerTmpList;

                // ���Ӑ�f�[�^�̓o�^����
                //status = this._iPmTabCustomerTmpDB.WriteForTablet(ref pmTabCustomerTmpWorkobj);// DEL 2013/06/11 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.9,NO.11�̑Ή�
                status = this._iPmTabCustomerTmpDB.WriteForTablet(ref pmTabCustomerTmpWorkobj, out  msgDiv, out  errMsg);// ADD 2013/06/11 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.9,NO.11�̑Ή�
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    default:
                        {
                            errMsg = "PMTAB���Ӑ���o�^�Ɏ��s���܂����B";
                            break;
                        }
                }
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            // catch (Exception)
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMsg = "PMTAB���Ӑ���o�^�Ɏ��s���܂����B";
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return status;

        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���Ӑ挟�������N���X�˓��Ӑ挟�����[�N�N���X�j
        /// </summary>
        /// <param name="customerSearchPara">���Ӑ挟�������N���X</param>
        /// <returns>���Ӑ挟�����[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ挟�������N���X���瓾�Ӑ挟�����[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private CustomerSearchParaWork CopyToParamDataFromUIData(CustomerSearchPara customerSearchPara)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "CopyToParamDataFromUIData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            CustomerSearchParaWork customerSearchParaWork = new CustomerSearchParaWork();

            customerSearchParaWork.EnterpriseCode = customerSearchPara.EnterpriseCode;
            customerSearchParaWork.CustomerCode = customerSearchPara.CustomerCode;
            customerSearchParaWork.CustomerSubCode = customerSearchPara.CustomerSubCode;
            customerSearchParaWork.Kana = customerSearchPara.Kana;
            customerSearchParaWork.SearchTelNo = customerSearchPara.SearchTelNo;
            customerSearchParaWork.CustomerSubCodeSearchType = customerSearchPara.CustomerSubCodeSearchType;
            customerSearchParaWork.KanaSearchType = customerSearchPara.KanaSearchType;
            customerSearchParaWork.CustAnalysCode1 = customerSearchPara.CustAnalysCode1;
            customerSearchParaWork.CustAnalysCode2 = customerSearchPara.CustAnalysCode2;
            customerSearchParaWork.CustAnalysCode3 = customerSearchPara.CustAnalysCode3;
            customerSearchParaWork.CustAnalysCode4 = customerSearchPara.CustAnalysCode4;
            customerSearchParaWork.CustAnalysCode5 = customerSearchPara.CustAnalysCode5;
            customerSearchParaWork.CustAnalysCode6 = customerSearchPara.CustAnalysCode6;
            customerSearchParaWork.CustomerAgentCd = customerSearchPara.CustomerAgentCd;
            customerSearchParaWork.BillCollecterCd = customerSearchPara.BillCollecterCd;
            customerSearchParaWork.AcceptWholeSale = customerSearchPara.AcceptWholeSale;
            customerSearchParaWork.MngSectionCode = customerSearchPara.MngSectionCode;
            customerSearchParaWork.Name = customerSearchPara.Name;
            customerSearchParaWork.NameSearchType = customerSearchPara.NameSearchType;
            customerSearchParaWork.TelNum = customerSearchPara.TelNum;
            customerSearchParaWork.TelNumSearchType = customerSearchPara.TelNumSearchType;
            customerSearchParaWork.PccuoeMode = customerSearchPara.PccuoeMode;
            customerSearchParaWork.CustomerSnm = customerSearchPara.CustomerSnm;
            customerSearchParaWork.CustomerSnmSearchType = customerSearchPara.CustomerSnmSearchType;

            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return customerSearchParaWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���Ӑ挟�������N���X��PMTAB���Ӑ挟�����ʃf�[�^�i�ꎞ�j���[�N�N���X�j
        /// </summary>
        /// <param name="customerWorkList">���Ӑ挟�����ʃ��X�g</param>
        /// <param name="customerSearchParaWork">���Ӑ挟�������N���X</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���Ӑ挟�����[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ挟�������N���X����PMTAB���Ӑ挟�����ʃf�[�^�i�ꎞ�j�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        private ArrayList CopyToCustomerDataToUIData(ArrayList customerWorkList, CustomerSearchParaWork customerSearchParaWork, string businessSessionId,string sectionCode)
        {
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            const string methodName = "CopyToCustomerDataToUIData";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            ArrayList pmTabCustomerTmpList = new ArrayList();
            DateTime dateTime = System.DateTime.Now.AddDays(7);
            int i = 1;
            // -------------- ADD 2013/08/08 wangl2 Redmine#39755 ----------- >>>>>
            // BLP���M�敪�擾
            object objRetList;
            ArrayList resultList = null;
            PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();
            pmTabTtlStCustWork.EnterpriseCode = customerSearchParaWork.EnterpriseCode;
            object objSearchCond = pmTabTtlStCustWork;
            int status = this._iPmTabTtlStCustDB.Search(out objRetList, objSearchCond, 0, ConstantManagement.LogicalMode.GetData0);
            if (status == 0)
            {
                resultList = objRetList as ArrayList;
            }
            bool Flag = false;
            // -------------- ADD 2013/08/08 wangl2 Redmine#39755 ----------- <<<<<
            // ADD 2013/08/13 Redmine#39923 ��������擾 ------------------------>>>>>
            CustomerInfoAcs customerDB = new CustomerInfoAcs();
            // ADD 2013/08/13 Redmine#39923 ��������擾 ------------------------<<<<<
            foreach (CustomerWork customerWork in customerWorkList)
            {
                PmTabCustTmpWork pmTabCustTmp = new PmTabCustTmpWork();
                #region
                pmTabCustTmp.CreateDateTime = customerWork.CreateDateTime;
                pmTabCustTmp.UpdateDateTime = customerWork.UpdateDateTime;
                pmTabCustTmp.EnterpriseCode = customerWork.EnterpriseCode;
                pmTabCustTmp.FileHeaderGuid = customerWork.FileHeaderGuid;
                pmTabCustTmp.UpdEmployeeCode = customerWork.UpdEmployeeCode;
                pmTabCustTmp.UpdAssemblyId1 = customerWork.UpdAssemblyId1;
                pmTabCustTmp.UpdAssemblyId2 = customerWork.UpdAssemblyId2;
                pmTabCustTmp.LogicalDeleteCode = customerWork.LogicalDeleteCode;
                pmTabCustTmp.CustomerCode = customerWork.CustomerCode;
                pmTabCustTmp.CustomerSubCode = customerWork.CustomerSubCode;
                pmTabCustTmp.Name = customerWork.Name;
                pmTabCustTmp.Name2 = customerWork.Name2;
                pmTabCustTmp.HonorificTitle = customerWork.HonorificTitle;
                pmTabCustTmp.Kana = customerWork.Kana;
                pmTabCustTmp.CustomerSnm = customerWork.CustomerSnm;
                pmTabCustTmp.OutputNameCode = customerWork.OutputNameCode;
                pmTabCustTmp.OutputName = customerWork.OutputName;
                pmTabCustTmp.CorporateDivCode = customerWork.CorporateDivCode;
                pmTabCustTmp.CustomerAttributeDiv = customerWork.CustomerAttributeDiv;
                pmTabCustTmp.JobTypeCode = customerWork.JobTypeCode;
                pmTabCustTmp.BusinessTypeCode = customerWork.BusinessTypeCode;
                pmTabCustTmp.SalesAreaCode = customerWork.SalesAreaCode;
                pmTabCustTmp.PostNo = customerWork.PostNo;
                pmTabCustTmp.Address1 = customerWork.Address1;
                pmTabCustTmp.Address3 = customerWork.Address3;
                pmTabCustTmp.Address4 = customerWork.Address4;
                pmTabCustTmp.HomeTelNo = customerWork.HomeTelNo;
                pmTabCustTmp.OfficeTelNo = customerWork.OfficeTelNo;
                pmTabCustTmp.PortableTelNo = customerWork.PortableTelNo;
                pmTabCustTmp.HomeFaxNo = customerWork.HomeFaxNo;
                pmTabCustTmp.OfficeFaxNo = customerWork.OfficeFaxNo;
                pmTabCustTmp.OthersTelNo = customerWork.OthersTelNo;
                pmTabCustTmp.MainContactCode = customerWork.MainContactCode;
                pmTabCustTmp.SearchTelNo = customerWork.SearchTelNo;
                pmTabCustTmp.MngSectionCode = customerWork.MngSectionCode;
                pmTabCustTmp.InpSectionCode = customerWork.InpSectionCode;
                pmTabCustTmp.CustAnalysCode1 = customerWork.CustAnalysCode1;
                pmTabCustTmp.CustAnalysCode2 = customerWork.CustAnalysCode2;
                pmTabCustTmp.CustAnalysCode3 = customerWork.CustAnalysCode3;
                pmTabCustTmp.CustAnalysCode4 = customerWork.CustAnalysCode4;
                pmTabCustTmp.CustAnalysCode5 = customerWork.CustAnalysCode5;
                pmTabCustTmp.CustAnalysCode6 = customerWork.CustAnalysCode6;
                pmTabCustTmp.BillOutputCode = customerWork.BillOutputCode;
                pmTabCustTmp.BillOutputName = customerWork.BillOutputName;
                pmTabCustTmp.TotalDay = customerWork.TotalDay;
                pmTabCustTmp.CollectMoneyCode = customerWork.CollectMoneyCode;
                pmTabCustTmp.CollectMoneyName = customerWork.CollectMoneyName;
                pmTabCustTmp.CollectMoneyDay = customerWork.CollectMoneyDay;
                pmTabCustTmp.CollectCond = customerWork.CollectCond;
                pmTabCustTmp.CollectSight = customerWork.CollectSight;
                pmTabCustTmp.ClaimCode = customerWork.ClaimCode;
                pmTabCustTmp.TransStopDate = customerWork.TransStopDate;
                pmTabCustTmp.DmOutCode = customerWork.DmOutCode;
                pmTabCustTmp.DmOutName = customerWork.DmOutName;
                pmTabCustTmp.MainSendMailAddrCd = customerWork.MainSendMailAddrCd;
                pmTabCustTmp.MailAddrKindCode1 = customerWork.MailAddrKindCode1;
                pmTabCustTmp.MailAddrKindName1 = customerWork.MailAddrKindName1;
                pmTabCustTmp.MailAddress1 = customerWork.MailAddress1;
                pmTabCustTmp.MailSendCode1 = customerWork.MailSendCode1;
                pmTabCustTmp.MailSendName1 = customerWork.MailSendName1;
                pmTabCustTmp.MailAddrKindCode2 = customerWork.MailAddrKindCode2;
                pmTabCustTmp.MailAddrKindName2 = customerWork.MailAddrKindName2;
                pmTabCustTmp.MailAddress2 = customerWork.MailAddress2;
                pmTabCustTmp.MailSendCode2 = customerWork.MailSendCode2;
                pmTabCustTmp.MailSendName2 = customerWork.MailSendName2;
                pmTabCustTmp.CustomerAgentCd = customerWork.CustomerAgentCd;
                pmTabCustTmp.BillCollecterCd = customerWork.BillCollecterCd;
                pmTabCustTmp.OldCustomerAgentCd = customerWork.OldCustomerAgentCd;
                pmTabCustTmp.CustAgentChgDate = customerWork.CustAgentChgDate;
                pmTabCustTmp.AcceptWholeSale = customerWork.AcceptWholeSale;
                pmTabCustTmp.CreditMngCode = customerWork.CreditMngCode;
                pmTabCustTmp.DepoDelCode = customerWork.DepoDelCode;
                pmTabCustTmp.AccRecDivCd = customerWork.AccRecDivCd;
                pmTabCustTmp.CustSlipNoMngCd = customerWork.CustSlipNoMngCd;
                pmTabCustTmp.PureCode = customerWork.PureCode;
                // DEL 2013/08/13 Redmine#39923 ��������擾 ------------------------>>>>>
                //pmTabCustTmp.CustCTaXLayRefCd = customerWork.CustCTaXLayRefCd;
                //pmTabCustTmp.ConsTaxLayMethod = customerWork.ConsTaxLayMethod;
                // DEL 2013/08/13 Redmine#39923 ��������擾 ------------------------<<<<<
                pmTabCustTmp.TotalAmountDispWayCd = customerWork.TotalAmountDispWayCd;
                pmTabCustTmp.TotalAmntDspWayRef = customerWork.TotalAmntDspWayRef;
                pmTabCustTmp.AccountNoInfo1 = customerWork.AccountNoInfo1;
                pmTabCustTmp.AccountNoInfo2 = customerWork.AccountNoInfo2;
                pmTabCustTmp.AccountNoInfo3 = customerWork.AccountNoInfo3;
                pmTabCustTmp.SalesUnPrcFrcProcCd = customerWork.SalesUnPrcFrcProcCd;
                pmTabCustTmp.SalesMoneyFrcProcCd = customerWork.SalesMoneyFrcProcCd;
                // DEL 2013/08/13 Redmine#39923 ��������擾 ------------------------>>>>>
                //pmTabCustTmp.SalesCnsTaxFrcProcCd = customerWork.SalesCnsTaxFrcProcCd;
                // DEL 2013/08/13 Redmine#39923 ��������擾 ------------------------<<<<<
                pmTabCustTmp.CustomerSlipNoDiv = customerWork.CustomerSlipNoDiv;
                pmTabCustTmp.NTimeCalcStDate = customerWork.NTimeCalcStDate;
                pmTabCustTmp.CustomerAgent = customerWork.CustomerAgent;
                pmTabCustTmp.ClaimSectionCode = customerWork.ClaimSectionCode;
                pmTabCustTmp.CarMngDivCd = customerWork.CarMngDivCd;
                pmTabCustTmp.BillPartsNoPrtCd = customerWork.BillPartsNoPrtCd;
                pmTabCustTmp.DeliPartsNoPrtCd = customerWork.DeliPartsNoPrtCd;
                pmTabCustTmp.DefSalesSlipCd = customerWork.DefSalesSlipCd;
                pmTabCustTmp.LavorRateRank = customerWork.LavorRateRank;
                pmTabCustTmp.SlipTtlPrn = customerWork.SlipTtlPrn;
                pmTabCustTmp.DepoBankCode = customerWork.DepoBankCode;
                pmTabCustTmp.CustWarehouseCd = customerWork.CustWarehouseCd;
                pmTabCustTmp.QrcodePrtCd = customerWork.QrcodePrtCd;
                pmTabCustTmp.DeliHonorificTtl = customerWork.DeliHonorificTtl;
                pmTabCustTmp.BillHonorificTtl = customerWork.BillHonorificTtl;
                pmTabCustTmp.EstmHonorificTtl = customerWork.EstmHonorificTtl;
                pmTabCustTmp.RectHonorificTtl = customerWork.RectHonorificTtl;
                pmTabCustTmp.DeliHonorTtlPrtDiv = customerWork.DeliHonorTtlPrtDiv;
                pmTabCustTmp.BillHonorTtlPrtDiv = customerWork.BillHonorTtlPrtDiv;
                pmTabCustTmp.EstmHonorTtlPrtDiv = customerWork.EstmHonorTtlPrtDiv;
                pmTabCustTmp.RectHonorTtlPrtDiv = customerWork.RectHonorTtlPrtDiv;
                pmTabCustTmp.Note1 = customerWork.Note1;
                pmTabCustTmp.Note2 = customerWork.Note2;
                pmTabCustTmp.Note3 = customerWork.Note3;
                pmTabCustTmp.Note4 = customerWork.Note4;
                pmTabCustTmp.Note5 = customerWork.Note5;
                pmTabCustTmp.Note6 = customerWork.Note6;
                pmTabCustTmp.Note7 = customerWork.Note7;
                pmTabCustTmp.Note8 = customerWork.Note8;
                pmTabCustTmp.Note9 = customerWork.Note9;
                pmTabCustTmp.Note10 = customerWork.Note10;
                pmTabCustTmp.SalesSlipPrtDiv = customerWork.SalesSlipPrtDiv;
                pmTabCustTmp.ShipmSlipPrtDiv = customerWork.ShipmSlipPrtDiv;
                pmTabCustTmp.AcpOdrrSlipPrtDiv = customerWork.AcpOdrrSlipPrtDiv;
                pmTabCustTmp.EstimatePrtDiv = customerWork.EstimatePrtDiv;
                pmTabCustTmp.UOESlipPrtDiv = customerWork.UOESlipPrtDiv;
                pmTabCustTmp.ReceiptOutputCode = customerWork.ReceiptOutputCode;
                pmTabCustTmp.CustomerEpCode = customerWork.CustomerEpCode;
                pmTabCustTmp.CustomerSecCode = customerWork.CustomerSecCode;
                pmTabCustTmp.OnlineKindDiv = customerWork.OnlineKindDiv;
                pmTabCustTmp.TotalBillOutputDiv = customerWork.TotalBillOutputDiv;
                pmTabCustTmp.DetailBillOutputCode = customerWork.DetailBillOutputCode;
                pmTabCustTmp.SlipTtlBillOutputDiv = customerWork.SlipTtlBillOutputDiv;
                pmTabCustTmp.SimplInqAcntAcntGrId = customerWork.SimplInqAcntAcntGrId;
                pmTabCustTmp.SearchSectionCode = sectionCode;
                pmTabCustTmp.DataDeleteDate = dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day;
                pmTabCustTmp.BusinessSessionId = businessSessionId;
                pmTabCustTmp.PmTabSearchRowNum = i;
                i++;
                // -------------- ADD 2013/08/08 wangl2 Redmine#39755 ----------- >>>>>
                Flag = false;
                if (resultList != null && resultList.Count > 0)
                {
                    // ���Ӑ�R�[�h�����Ӑ�}�X�^�̓��Ӑ�R�[�h�ꍇ
                    foreach (PmTabTtlStCustWork pmTabTtlStCust in resultList)
                    {
                        if (pmTabTtlStCust.CustomerCode == pmTabCustTmp.CustomerCode)
                        {
                            pmTabCustTmp.BlpSendDiv = pmTabTtlStCust.BlpSendDiv;
                            Flag = true;
                            break;
                        }
                    }
                    // ���Ӑ�R�[�h���[���ꍇ
                    if (!Flag)
                    {
                        foreach (PmTabTtlStCustWork pmTabTtlStCust in resultList)
                        {
                            if (pmTabTtlStCust.CustomerCode == 0)
                            {
                                pmTabCustTmp.BlpSendDiv = pmTabTtlStCust.BlpSendDiv;
                                Flag = true;
                                break;
                            }
                        }
                    }
                    // ������̏ꍇ�ł��f�[�^���擾�ł��Ȃ�������
                    if (!Flag)
                    {
                        pmTabCustTmp.BlpSendDiv = 1;
                    }
                }
                // ������̏ꍇ�ł��f�[�^���擾�ł��Ȃ�������
                else 
                {
                    pmTabCustTmp.BlpSendDiv = 1;
                }
                // -------------- ADD 2013/08/08 wangl2 Redmine#39755 ----------- <<<<<
                // ADD 2013/08/13 Redmine#39923 ��������擾 ------------------------>>>>>
                // ���Ӑ�R�[�h�i�q�j�̎��͏���Ŋ֘A���͐�������Z�b�g����
                if (pmTabCustTmp.CustomerCode != pmTabCustTmp.ClaimCode)
                {
                    // ��������擾
                    CustomerInfo claimInfo = new CustomerInfo();
                    customerDB.ReadDBData(pmTabCustTmp.EnterpriseCode, pmTabCustTmp.ClaimCode, out claimInfo);
                    if (claimInfo != null && claimInfo.CustomerCode != 0)
                    {
                        pmTabCustTmp.CustCTaXLayRefCd = claimInfo.CustCTaXLayRefCd;         // ���Ӑ����œ]�ŕ����Q�Ƌ敪
                        pmTabCustTmp.ConsTaxLayMethod = claimInfo.ConsTaxLayMethod;         // ����œ]�ŕ���
                        pmTabCustTmp.SalesCnsTaxFrcProcCd = claimInfo.SalesCnsTaxFrcProcCd; // �������Œ[�������R�[�h
                    }
                }
                else
                {
                    pmTabCustTmp.CustCTaXLayRefCd = customerWork.CustCTaXLayRefCd;          // ���Ӑ����œ]�ŕ����Q�Ƌ敪
                    pmTabCustTmp.ConsTaxLayMethod = customerWork.ConsTaxLayMethod;          // ����œ]�ŕ���
                    pmTabCustTmp.SalesCnsTaxFrcProcCd = customerWork.SalesCnsTaxFrcProcCd;  // �������Œ[�������R�[�h
                }
                // ADD 2013/08/13 Redmine#39923 ��������擾 ------------------------<<<<<

                #endregion
                pmTabCustomerTmpList.Add(pmTabCustTmp);
                // DEL 2013/07/29 �g�� �������ԒZ�k�ׁ̈A���O�o�͍폜 --------->>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //// �^�u���b�g���O�Ή��@--------------------------------->>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, "�������ʁi�����ݓ��e�j"
                //    + "�@��ƃR�[�h�F" + pmTabCustTmp.EnterpriseCode
                //    + "�@�������_�R�[�h�F" + pmTabCustTmp.SearchSectionCode
                //    + "�@�Ɩ��Z�b�V����ID�F" + pmTabCustTmp.BusinessSessionId
                //    + "�@PMTAB�����s�ԍ��F" + pmTabCustTmp.PmTabSearchRowNum.ToString()
                //    + "�@���Ӑ�R�[�h�F" + pmTabCustTmp.CustomerCode.ToString()
                //    + "�@���Ӑ於�F" + pmTabCustTmp.Name
                //    );
                //// �^�u���b�g���O�Ή��@---------------------------------<<<<<
                #endregion
                // DEL 2013/07/29 �g�� �������ԒZ�k�ׁ̈A���O�o�͍폜 ---------<<<<<<<<<<<<<<<<<<
            }
            // �^�u���b�g���O�Ή��@--------------------------------->>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // �^�u���b�g���O�Ή��@---------------------------------<<<<<
            return pmTabCustomerTmpList;
        }
        #endregion
    }
}
