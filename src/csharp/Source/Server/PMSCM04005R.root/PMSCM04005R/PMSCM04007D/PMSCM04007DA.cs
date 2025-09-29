using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMInquiryOrderWork
    /// <summary>
    ///                      SCM�₢���킹�ꗗ���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM�₢���킹�ꗗ���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/18  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note: ���o�������ڒǉ�(�J�n�X�V�N����(St_UpdateDate),�I���X�V�N����(Ed_UpdateDate))</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2011/06/13</br>
    /// <br>Update Note: Readmine 26534 �󔭒���ʂ�ǉ����APCCforNS��BL�p�[�c�I�[�_�[�V�X�e���̔��f���\�Ƃ���</br>
    /// <br>Programmer : ������</br>    
    /// <br>Date       : 2011/11/12</br>    
    /// <br>Update Note: SCM��Q��10384�Ή� ���o�������ڒǉ��i�J�n���ɗ\���, �I�����ɗ\����j(</br>
    /// <br>Programmer : 30744 ���� ����q</br>    
    /// <br>Date       : 2013/05/09</br>    
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMInquiryOrderWork
    {
        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�J�n�⍇���ԍ�</summary>
        private Int64 _st_InquiryNumber;

        /// <summary>�I���⍇���ԍ�</summary>
        private Int64 _ed_InquiryNumber;

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>�X�V����</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _updateTime;

        /// <summary>�⍇���E�������</summary>
        /// <remarks>1:�⍇�� 2:����</remarks>
        private Int32[] _inqOrdDivCd;

        /// <summary>�񓚋敪</summary>
        /// <remarks>0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
        private Int32[] _answerDivCd;

        /// <summary>�m���</summary>
        /// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
        private Int32 _judgementDate;

        /// <summary>�⍇���E�������l</summary>
        private string _inqOrdNote = "";

        /// <summary>�⍇���]�ƈ��R�[�h</summary>
        /// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
        private string _inqEmployeeCd = "";

        /// <summary>�⍇���]�ƈ�����</summary>
        /// <remarks>�⍇�������]�ƈ�����</remarks>
        private string _inqEmployeeNm = "";

        /// <summary>�񓚏]�ƈ��R�[�h</summary>
        private string _ansEmployeeCd = "";

        /// <summary>�񓚏]�ƈ�����</summary>
        private string _ansEmployeeNm = "";

        /// <summary>�J�n�⍇����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_InquiryDate;

        /// <summary>�I���⍇����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_InquiryDate;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _st_CustomerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>�J�n����`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _st_SalesSlipNum = "";

        /// <summary>�I������`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private string _ed_SalesSlipNum = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32[] _acptAnOdrStatus;

        /// <summary>�񓚕��@</summary>
        private Int32[] _awnserMethod;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>����`�[���v�i�ō��݁j</summary>
        /// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
        private Int64 _salesTotalTaxInc;

        // --- ADD m.suzuki 2011/06/13 ---------->>>>>
        /// <summary>�J�n�X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_UpdateDate;

        /// <summary>�I���X�V�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_UpdateDate;
        // --- ADD m.suzuki 2011/06/13 ----------<<<<<

        // --- ADD gezh 2011/11/12 ---------->>>>>  
        /// <summary>�A�g�Ώۋ敪</summary>        
        private Int16[] _cooperationOptionDiv;  
        // --- ADD gezh 2011/11/12 ----------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        /// <summary>�J�n���ɗ\���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _st_ExpectedCeDate;

        /// <summary>�I�����ɗ\���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_ExpectedCeDate;
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  St_InquiryNumber
        /// <summary>�J�n�⍇���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 St_InquiryNumber
        {
            get { return _st_InquiryNumber; }
            set { _st_InquiryNumber = value; }
        }

        /// public propaty name  :  Ed_InquiryNumber
        /// <summary>�I���⍇���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���⍇���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Ed_InquiryNumber
        {
            get { return _ed_InquiryNumber; }
            set { _ed_InquiryNumber = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  UpdateTime
        /// <summary>�X�V���ԃv���p�e�B</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateTime
        {
            get { return _updateTime; }
            set { _updateTime = value; }
        }

        /// public propaty name  :  InqOrdDivCd
        /// <summary>�⍇���E������ʃv���p�e�B</summary>
        /// <value>1:�⍇�� 2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E������ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] InqOrdDivCd
        {
            get { return _inqOrdDivCd; }
            set { _inqOrdDivCd = value; }
        }

        /// public propaty name  :  AnswerDivCd
        /// <summary>�񓚋敪�v���p�e�B</summary>
        /// <value>0:�A�N�V�����Ȃ� 1:�񓚒� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] AnswerDivCd
        {
            get { return _answerDivCd; }
            set { _answerDivCd = value; }
        }

        /// public propaty name  :  JudgementDate
        /// <summary>�m����v���p�e�B</summary>
        /// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �m����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JudgementDate
        {
            get { return _judgementDate; }
            set { _judgementDate = value; }
        }

        /// public propaty name  :  InqOrdNote
        /// <summary>�⍇���E�������l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���E�������l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOrdNote
        {
            get { return _inqOrdNote; }
            set { _inqOrdNote = value; }
        }

        /// public propaty name  :  InqEmployeeCd
        /// <summary>�⍇���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�⍇�������]�ƈ��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqEmployeeCd
        {
            get { return _inqEmployeeCd; }
            set { _inqEmployeeCd = value; }
        }

        /// public propaty name  :  InqEmployeeNm
        /// <summary>�⍇���]�ƈ����̃v���p�e�B</summary>
        /// <value>�⍇�������]�ƈ�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqEmployeeNm
        {
            get { return _inqEmployeeNm; }
            set { _inqEmployeeNm = value; }
        }

        /// public propaty name  :  AnsEmployeeCd
        /// <summary>�񓚏]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚏]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsEmployeeCd
        {
            get { return _ansEmployeeCd; }
            set { _ansEmployeeCd = value; }
        }

        /// public propaty name  :  AnsEmployeeNm
        /// <summary>�񓚏]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚏]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AnsEmployeeNm
        {
            get { return _ansEmployeeNm; }
            set { _ansEmployeeNm = value; }
        }

        /// public propaty name  :  St_InquiryDate
        /// <summary>�J�n�⍇�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�⍇�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_InquiryDate
        {
            get { return _st_InquiryDate; }
            set { _st_InquiryDate = value; }
        }

        /// public propaty name  :  Ed_InquiryDate
        /// <summary>�I���⍇�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���⍇�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_InquiryDate
        {
            get { return _ed_InquiryDate; }
            set { _ed_InquiryDate = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  St_SalesSlipNum
        /// <summary>�J�n����`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_SalesSlipNum
        {
            get { return _st_SalesSlipNum; }
            set { _st_SalesSlipNum = value; }
        }

        /// public propaty name  :  Ed_SalesSlipNum
        /// <summary>�I������`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_SalesSlipNum
        {
            get { return _ed_SalesSlipNum; }
            set { _ed_SalesSlipNum = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  AwnserMethod
        /// <summary>�񓚕��@�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񓚕��@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] AwnserMethod
        {
            get { return _awnserMethod; }
            set { _awnserMethod = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
        /// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        // --- ADD m.suzuki 2011/06/13 ---------->>>>>
        /// public propaty name  :  St_UpdateDate
        /// <summary>�J�n�X�V�N����</summary>
        /// <value>YYYYMMDD</value>
        public Int32 St_UpdateDate
        {
            get { return _st_UpdateDate; }
            set { _st_UpdateDate = value; }
        }
        /// public propaty name  :  Ed_UpdateDate
        /// <summary>�I���X�V�N����</summary>
        /// <value>YYYYMMDD</value>
        public Int32 Ed_UpdateDate
        {
            get { return _ed_UpdateDate; }
            set { _ed_UpdateDate = value; }
        }
        // --- ADD m.suzuki 2011/06/13 ----------<<<<<

        // --- ADD gezh 2011/11/12 ---------->>>>> 
        /// public propaty name  :  CooperationOptionDiv        
        /// <summary>�A�g�Ώۋ敪�v���p�e�B</summary>        
        public Int16[] CooperationOptionDiv
        {
            get { return _cooperationOptionDiv; }
            set { _cooperationOptionDiv = value; }
        }        
        // --- ADD gezh 2011/11/12 ----------<<<<<

        // ADD 2013/05/09 SCM��Q��10384�Ή� ----------------------------------->>>>>
        /// public propaty name  :  St_ExpectedCeDate
        /// <summary>�J�n���ɗ\���</summary>
        /// <value>YYYYMMDD</value>
        public Int32 St_ExpectedCeDate
        {
            get { return _st_ExpectedCeDate; }
            set { _st_ExpectedCeDate = value; }
        }
        /// public propaty name  :  Ed_ExpectedCeDate
        /// <summary>�I�����ɗ\���</summary>
        /// <value>YYYYMMDD</value>
        public Int32 Ed_ExpectedCeDate
        {
            get { return _ed_ExpectedCeDate; }
            set { _ed_ExpectedCeDate = value; }
        }
        // ADD 2013/05/09 SCM��Q��10384�Ή� -----------------------------------<<<<<
        
        /// <summary>
        /// SCM�₢���킹�ꗗ���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SCMInquiryOrderWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMInquiryOrderWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMInquiryOrderWork()
        {
        }

    }
}




