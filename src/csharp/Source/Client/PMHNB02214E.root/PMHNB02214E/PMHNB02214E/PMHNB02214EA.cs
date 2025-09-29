//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �ԕi���R�ꗗ�\ ���o�N���X
//                  :   PMHNB02214E.DLL
// Name Space       :   Broadleaf.Application.UIData
// Programmer       :   ������
// Date             :   2009.05.11
//----------------------------------------------------------------------
// Update Note      :   2013/01/25 cheq
// �Ǘ��ԍ�  		:   10806793-00 2013/03/13�z�M��                    
//                      Redmine#34098 �r���󎚐���̒ǉ��Ή�        
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
	/// <summary>
    /// �ԕi���R�ꗗ�\���o�����N���X
	/// </summary>
	/// <remarks>
    /// <br>note             :   �ԕi���R�ꗗ�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/03/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2013/01/25 cheq</br>
    /// <br>�Ǘ��ԍ�         :   10806793-00 2013/03/13�z�M��</br>
    /// <br>                     Redmine#34098 �r���󎚐���̒ǉ��Ή�</br>
	/// </remarks>
    public class HenbiRiyuListReport
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�����^�@���z�񍀖�</remarks>
        private string[] _sectionCodes;

        /// <summary>
        /// ���_�I�v�V�����敪
        /// </summary>
        private bool _isOptSection = false;

        /// <summary>
        /// �S���_�I���敪
        /// </summary>
        private bool _isSelectAllSection = false;

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
        private string  _customerCodeSt;

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

        //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
        /// <summary>�r����</summary>
        private Int32 _linePrintDiv;
        //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<

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
        /// ���_�I�v�V�����敪�v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// �S���_�I���敪�v���p�e�B
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        //----- ADD 2013/01/25 cheq Redmine#34098 ----->>>>>
        /// public propaty name  :  LinePrintDiv
        /// <summary>�r����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���󎚃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LinePrintDiv
        {
            get { return _linePrintDiv; }
            set { _linePrintDiv = value; }
        }
        //----- ADD 2013/01/25 cheq Redmine#34098 -----<<<<<

    }
}
