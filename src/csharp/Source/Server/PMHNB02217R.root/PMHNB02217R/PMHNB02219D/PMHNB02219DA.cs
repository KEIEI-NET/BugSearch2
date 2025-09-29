//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi���R�ꗗ�\���o�����N���X���[�N
// �v���O�����T�v   : �ԕi���R�ꗗ�\���o�����N���X���[�N�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OrderSetMasListParaWork
    /// <summary>
    ///                      �ԕi���R�ꗗ�\���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ԕi���R�ꗗ�\���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2009/04/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RetGoodsReasonReportParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�����^�@���z�񍀖�</remarks>
        private string[] _sectionCodes;

        /// <summary>�Ώ۔N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _salesDate;

        /// <summary>�O���������</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _prevTotalDay;

        /// <summary>�����������</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _currentTotalDay;

        /// <summary>�N�x�J�n��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _startYearDate;

        /// <summary>�N�x�I����</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _endYearDate;

        /// <summary>����</summary>
        private Int32 _changePageDiv;

        /// <summary>�o�͏�</summary>
        private Int32 _printType;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private string _customerCodeSt;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private string _customerCodeEd;

        /// <summary>�J�n�ԕi���R�R�[�h</summary>
        private string _retGoodsReasonDivSt;

        /// <summary>�I���ԕi���R�R�[�h</summary>
        private string _retGoodsReasonDivEd;

        /// <summary>�J�n�S���҃R�[�h</summary>
        private string _salesEmployeeCdRFSt;

        /// <summary>�I���S���҃R�[�h</summary>
        private string _salesEmployeeCdRFEd;

        /// <summary>�J�n�󒍎҃R�[�h</summary>
        private string _frontEmployeeCdRFSt;

        /// <summary>�I���󒍎҃R�[�h</summary>
        private string _frontEmployeeCdRFEd;

        /// <summary>�J�n���s�҃R�[�h</summary>
        private string _salesInputCdRFSt;

        /// <summary>�I�����s�҃R�[�h</summary>
        private string _salesInputCdRFEd;

        /// <summary>�`�[���</summary>
        private Int32 _slipKindCd;

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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^�@���z�񍀖�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>�Ώ۔N��</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώ۔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  PrevTotalDay
        /// <summary>�O���������</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O����������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PrevTotalDay
        {
            get { return _prevTotalDay; }
            set { _prevTotalDay = value; }
        }

        /// public propaty name  :  EndYearDate
        /// <summary>�N�x�I����</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N�x�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EndYearDate
        {
            get { return _endYearDate; }
            set { _endYearDate = value; }
        }

        /// public propaty name  :  CurrentTotalDay
        /// <summary>�����������</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CurrentTotalDay
        {
            get { return _currentTotalDay; }
            set { _currentTotalDay = value; }
        }

        /// public propaty name  :  StartYearDate
        /// <summary>�N�x�J�n��</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N�x�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StartYearDate
        {
            get { return _startYearDate; }
            set { _startYearDate = value; }
        }

        /// public propaty name  :  ChangePageDiv
        /// <summary>����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChangePageDiv
        {
            get { return _changePageDiv; }
            set { _changePageDiv = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>���s�^�C�v</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  RetGoodsReasonDivSt
        /// <summary>�J�n�ԕi���R�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�ԕi���R�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RetGoodsReasonDivSt
        {
            get { return _retGoodsReasonDivSt; }
            set { _retGoodsReasonDivSt = value; }
        }

        /// public propaty name  :  RetGoodsReasonDivSt
        /// <summary>�I���ԕi���R�R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���ԕi���R�R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RetGoodsReasonDivEd
        {
            get { return _retGoodsReasonDivEd; }
            set { _retGoodsReasonDivEd = value; }
        }

        /// public propaty name  :  SalesEmployeeCdRFSt
        /// <summary>�J�n�S���҃R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�S���҃R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCdRFSt
        {
            get { return _salesEmployeeCdRFSt; }
            set { _salesEmployeeCdRFSt = value; }
        }

        /// public propaty name  :  SalesEmployeeCdRFEd
        /// <summary>�I���S���҃R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���S���҃R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCdRFEd
        {
            get { return _salesEmployeeCdRFEd; }
            set { _salesEmployeeCdRFEd = value; }
        }

        /// public propaty name  :  FrontEmployeeCdRFSt
        /// <summary>�J�n�󒍎҃R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�󒍎҃R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCdRFSt
        {
            get { return _frontEmployeeCdRFSt; }
            set { _frontEmployeeCdRFSt = value; }
        }

        /// public propaty name  :  FrontEmployeeCdRFEd
        /// <summary>�I���󒍎҃R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���󒍎҃R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCdRFEd
        {
            get { return _frontEmployeeCdRFEd; }
            set { _frontEmployeeCdRFEd = value; }
        }

        /// public propaty name  :  SalesInputCdRFSt
        /// <summary>�J�n���s�҃R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���s�҃R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCdRFSt
        {
            get { return _salesInputCdRFSt; }
            set { _salesInputCdRFSt = value; }
        }

        /// public propaty name  :  SalesInputCdRFEd
        /// <summary>�I�����s�҃R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����s�҃R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCdRFEd
        {
            get { return _salesInputCdRFEd; }
            set { _salesInputCdRFEd = value; }
        }


        /// public propaty name  :  SlipKindCd
        /// <summary>���s�^�C�v</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipKindCd
        {
            get { return _slipKindCd; }
            set { _slipKindCd = value; }
        }

        /// <summary>
        /// �ԕi���R�ꗗ�\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RetGoodsReasonReportParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RetGoodsReasonReportParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RetGoodsReasonReportParaWork()
        {
        }
    }
}
