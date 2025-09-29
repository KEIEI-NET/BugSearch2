using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SalesTargetSet
    /// <summary>
    ///                      ����ڕW�ݒ�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����ڕW�ݒ�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class SalesTargetSet 
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>���喼��</summary>
        private string _subSectionName = "";

        /// <summary>�S���҃R�[�h</summary>
        private string _salesEmployeeCd = "";

        /// <summary>�S���Җ���</summary>
        private string _salesEmployeeNm = "";

        /// <summary>�󒍎҃R�[�h</summary>
        private string _frontEmployeeCd = "";

        /// <summary>�󒍎Җ���</summary>
        private string _frontEmployeeNm = "";

        /// <summary>���s�҃R�[�h</summary>
        private string _salesInputCode = "";

        /// <summary>���s�Җ���</summary>
        private string _salesInputName = "";

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _salesCode;

        /// <summary>�̔��敪����</summary>
        private string _salesCodeName = "";

        /// <summary>���i�敪�R�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>���i�敪����</summary>
        private string _enterpriseGanreCodeName = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeCodeName = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        private string _salesAreaCodeName = "";

        /// <summary>����ڕW���z�P</summary>
        private Int64 _salesTargetMoney1;

        /// <summary>����ڕW���z�Q</summary>
        private Int64 _salesTargetMoney2;

        /// <summary>����ڕW���z�R</summary>
        private Int64 _salesTargetMoney3;

        /// <summary>����ڕW���z�S</summary>
        private Int64 _salesTargetMoney4;

        /// <summary>����ڕW���z�T</summary>
        private Int64 _salesTargetMoney5;

        /// <summary>����ڕW���z�U</summary>
        private Int64 _salesTargetMoney6;

        /// <summary>����ڕW���z�V</summary>
        private Int64 _salesTargetMoney7;

        /// <summary>����ڕW���z�W</summary>
        private Int64 _salesTargetMoney8;

        /// <summary>����ڕW���z�X</summary>
        private Int64 _salesTargetMoney9;

        /// <summary>����ڕW���z�P�O</summary>
        private Int64 _salesTargetMoney10;

        /// <summary>����ڕW���z�P�P</summary>
        private Int64 _salesTargetMoney11;

        /// <summary>����ڕW���z�P�Q</summary>
        private Int64 _salesTargetMoney12;

        /// <summary>����ڕW�e���z�P</summary>
        private Int64 _salesTargetProfit1;

        /// <summary>����ڕW�e���z�Q</summary>
        private Int64 _salesTargetProfit2;

        /// <summary>����ڕW�e���z�R</summary>
        private Int64 _salesTargetProfit3;

        /// <summary>����ڕW�e���z�S</summary>
        private Int64 _salesTargetProfit4;

        /// <summary>����ڕW�e���z�T</summary>
        private Int64 _salesTargetProfit5;

        /// <summary>����ڕW�e���z�U</summary>
        private Int64 _salesTargetProfit6;

        /// <summary>����ڕW�e���z�V</summary>
        private Int64 _salesTargetProfit7;

        /// <summary>����ڕW�e���z�W</summary>
        private Int64 _salesTargetProfit8;

        /// <summary>����ڕW�e���z�X</summary>
        private Int64 _salesTargetProfit9;

        /// <summary>����ڕW�e���z�P�O</summary>
        private Int64 _salesTargetProfit10;

        /// <summary>����ڕW�e���z�P�P</summary>
        private Int64 _salesTargetProfit11;

        /// <summary>����ڕW�e���z�P�Q</summary>
        private Int64 _salesTargetProfit12;


        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>���喼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���喼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SubSectionName
        {
            get { return _subSectionName; }
            set { _subSectionName = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>�󒍎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>�󒍎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>���s�҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>���s�Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCodeName
        /// <summary>�̔��敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesCodeName
        {
            get { return _salesCodeName; }
            set { _salesCodeName = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���i�敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCodeName
        /// <summary>���i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreCodeName
        {
            get { return _enterpriseGanreCodeName; }
            set { _enterpriseGanreCodeName = value; }
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

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeCodeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeCodeName
        {
            get { return _businessTypeCodeName; }
            set { _businessTypeCodeName = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaCodeName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaCodeName
        {
            get { return _salesAreaCodeName; }
            set { _salesAreaCodeName = value; }
        }

        /// public propaty name  :  SalesTargetMoney1
        /// <summary>����ڕW���z�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney1
        {
            get { return _salesTargetMoney1; }
            set { _salesTargetMoney1 = value; }
        }

        /// public propaty name  :  SalesTargetMoney2
        /// <summary>����ڕW���z�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney2
        {
            get { return _salesTargetMoney2; }
            set { _salesTargetMoney2 = value; }
        }

        /// public propaty name  :  SalesTargetMoney3
        /// <summary>����ڕW���z�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney3
        {
            get { return _salesTargetMoney3; }
            set { _salesTargetMoney3 = value; }
        }

        /// public propaty name  :  SalesTargetMoney4
        /// <summary>����ڕW���z�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney4
        {
            get { return _salesTargetMoney4; }
            set { _salesTargetMoney4 = value; }
        }

        /// public propaty name  :  SalesTargetMoney5
        /// <summary>����ڕW���z�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney5
        {
            get { return _salesTargetMoney5; }
            set { _salesTargetMoney5 = value; }
        }

        /// public propaty name  :  SalesTargetMoney6
        /// <summary>����ڕW���z�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney6
        {
            get { return _salesTargetMoney6; }
            set { _salesTargetMoney6 = value; }
        }

        /// public propaty name  :  SalesTargetMoney7
        /// <summary>����ڕW���z�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney7
        {
            get { return _salesTargetMoney7; }
            set { _salesTargetMoney7 = value; }
        }

        /// public propaty name  :  SalesTargetMoney8
        /// <summary>����ڕW���z�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney8
        {
            get { return _salesTargetMoney8; }
            set { _salesTargetMoney8 = value; }
        }

        /// public propaty name  :  SalesTargetMoney9
        /// <summary>����ڕW���z�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney9
        {
            get { return _salesTargetMoney9; }
            set { _salesTargetMoney9 = value; }
        }

        /// public propaty name  :  SalesTargetMoney10
        /// <summary>����ڕW���z�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney10
        {
            get { return _salesTargetMoney10; }
            set { _salesTargetMoney10 = value; }
        }

        /// public propaty name  :  SalesTargetMoney11
        /// <summary>����ڕW���z�P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney11
        {
            get { return _salesTargetMoney11; }
            set { _salesTargetMoney11 = value; }
        }

        /// public propaty name  :  SalesTargetMoney12
        /// <summary>����ڕW���z�P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney12
        {
            get { return _salesTargetMoney12; }
            set { _salesTargetMoney12 = value; }
        }

        /// public propaty name  :  SalesTargetProfit1
        /// <summary>����ڕW�e���z�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit1
        {
            get { return _salesTargetProfit1; }
            set { _salesTargetProfit1 = value; }
        }

        /// public propaty name  :  SalesTargetProfit2
        /// <summary>����ڕW�e���z�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit2
        {
            get { return _salesTargetProfit2; }
            set { _salesTargetProfit2 = value; }
        }

        /// public propaty name  :  SalesTargetProfit3
        /// <summary>����ڕW�e���z�R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit3
        {
            get { return _salesTargetProfit3; }
            set { _salesTargetProfit3 = value; }
        }

        /// public propaty name  :  SalesTargetProfit4
        /// <summary>����ڕW�e���z�S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit4
        {
            get { return _salesTargetProfit4; }
            set { _salesTargetProfit4 = value; }
        }

        /// public propaty name  :  SalesTargetProfit5
        /// <summary>����ڕW�e���z�T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit5
        {
            get { return _salesTargetProfit5; }
            set { _salesTargetProfit5 = value; }
        }

        /// public propaty name  :  SalesTargetProfit6
        /// <summary>����ڕW�e���z�U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit6
        {
            get { return _salesTargetProfit6; }
            set { _salesTargetProfit6 = value; }
        }

        /// public propaty name  :  SalesTargetProfit7
        /// <summary>����ڕW�e���z�V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit7
        {
            get { return _salesTargetProfit7; }
            set { _salesTargetProfit7 = value; }
        }

        /// public propaty name  :  SalesTargetProfit8
        /// <summary>����ڕW�e���z�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit8
        {
            get { return _salesTargetProfit8; }
            set { _salesTargetProfit8 = value; }
        }

        /// public propaty name  :  SalesTargetProfit9
        /// <summary>����ڕW�e���z�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit9
        {
            get { return _salesTargetProfit9; }
            set { _salesTargetProfit9 = value; }
        }

        /// public propaty name  :  SalesTargetProfit10
        /// <summary>����ڕW�e���z�P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit10
        {
            get { return _salesTargetProfit10; }
            set { _salesTargetProfit10 = value; }
        }

        /// public propaty name  :  SalesTargetProfit11
        /// <summary>����ڕW�e���z�P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit11
        {
            get { return _salesTargetProfit11; }
            set { _salesTargetProfit11 = value; }
        }

        /// public propaty name  :  SalesTargetProfit12
        /// <summary>����ڕW�e���z�P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit12
        {
            get { return _salesTargetProfit12; }
            set { _salesTargetProfit12 = value; }
        }

        /// <summary>
        /// ����ڕW�ݒ�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SalesTargetSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesTargetSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalesTargetSet Clone()
        {
            return new SalesTargetSet(this._sectionCode, this._sectionGuideSnm, this._subSectionCode, this._subSectionName, this._salesEmployeeCd, this._salesEmployeeNm, this._frontEmployeeCd, this._frontEmployeeNm, this._salesInputCode, this._salesInputName, this._salesCode, this._salesCodeName, this._enterpriseGanreCode, this._enterpriseGanreCodeName, this._customerCode, this._customerSnm, this._businessTypeCode, this._businessTypeCodeName, this._salesAreaCode, this._salesAreaCodeName, this._salesTargetMoney1, this._salesTargetMoney2, this._salesTargetMoney3, this._salesTargetMoney4, this._salesTargetMoney5, this._salesTargetMoney6, this._salesTargetMoney7, this._salesTargetMoney8, this._salesTargetMoney9, this._salesTargetMoney10, this._salesTargetMoney11, this._salesTargetMoney12, this._salesTargetProfit1, this._salesTargetProfit2, this._salesTargetProfit3, this._salesTargetProfit4, this._salesTargetProfit5, this._salesTargetProfit6, this._salesTargetProfit7, this._salesTargetProfit8, this._salesTargetProfit9, this._salesTargetProfit10, this._salesTargetProfit11, this._salesTargetProfit12);
        }

        /// <summary>
		/// ����ڕW�ݒ�i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
        /// <returns>SalesTargetSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTargetSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesTargetSet()
		{
		}

        /// <summary>
        /// ����ڕW�ݒ�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="SectionCode"></param>
        /// <param name="SectionGuideSnm"></param>
        /// <param name="SubSectionCode"></param>
        /// <param name="SubSectionName"></param>
        /// <param name="SalesEmployeeCd"></param>
        /// <param name="SalesEmployeeNm"></param>
        /// <param name="FrontEmployeeCd"></param>
        /// <param name="FrontEmployeeNm"></param>
        /// <param name="SalesInputCode"></param>
        /// <param name="SalesInputName"></param>
        /// <param name="SalesCode"></param>
        /// <param name="SalesCodeName"></param>
        /// <param name="EnterpriseGanreCode"></param>
        /// <param name="EnterpriseGanreCodeName"></param>
        /// <param name="CustomerCode"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="BusinessTypeCode"></param>
        /// <param name="BusinessTypeCodeName"></param>
        /// <param name="SalesAreaCode"></param>
        /// <param name="SalesAreaCodeName"></param>
        /// <param name="SalesTargetMoney1"></param>
        /// <param name="SalesTargetMoney2"></param>
        /// <param name="SalesTargetMoney3"></param>
        /// <param name="SalesTargetMoney4"></param>
        /// <param name="SalesTargetMoney5"></param>
        /// <param name="SalesTargetMoney6"></param>
        /// <param name="SalesTargetMoney7"></param>
        /// <param name="SalesTargetMoney8"></param>
        /// <param name="SalesTargetMoney9"></param>
        /// <param name="SalesTargetMoney10"></param>
        /// <param name="SalesTargetMoney11"></param>
        /// <param name="SalesTargetMoney12"></param>
        /// <param name="SalesTargetProfit1"></param>
        /// <param name="SalesTargetProfit2"></param>
        /// <param name="SalesTargetProfit3"></param>
        /// <param name="SalesTargetProfit4"></param>
        /// <param name="SalesTargetProfit5"></param>
        /// <param name="SalesTargetProfit6"></param>
        /// <param name="SalesTargetProfit7"></param>
        /// <param name="SalesTargetProfit8"></param>
        /// <param name="SalesTargetProfit9"></param>
        /// <param name="SalesTargetProfit10"></param>
        /// <param name="SalesTargetProfit11"></param>
        /// <param name="SalesTargetProfit12"></param>
        public SalesTargetSet(string SectionCode, string SectionGuideSnm, Int32 SubSectionCode, string SubSectionName, string SalesEmployeeCd, string SalesEmployeeNm, string FrontEmployeeCd, string FrontEmployeeNm, string SalesInputCode, string SalesInputName, Int32 SalesCode, string SalesCodeName, Int32 EnterpriseGanreCode, string EnterpriseGanreCodeName, Int32 CustomerCode, string CustomerSnm, Int32 BusinessTypeCode, string BusinessTypeCodeName, Int32 SalesAreaCode, string SalesAreaCodeName, Int64 SalesTargetMoney1, Int64 SalesTargetMoney2, Int64 SalesTargetMoney3, Int64 SalesTargetMoney4, Int64 SalesTargetMoney5, Int64 SalesTargetMoney6, Int64 SalesTargetMoney7, Int64 SalesTargetMoney8, Int64 SalesTargetMoney9, Int64 SalesTargetMoney10, Int64 SalesTargetMoney11, Int64 SalesTargetMoney12, Int64 SalesTargetProfit1, Int64 SalesTargetProfit2, Int64 SalesTargetProfit3, Int64 SalesTargetProfit4, Int64 SalesTargetProfit5, Int64 SalesTargetProfit6, Int64 SalesTargetProfit7, Int64 SalesTargetProfit8, Int64 SalesTargetProfit9, Int64 SalesTargetProfit10, Int64 SalesTargetProfit11, Int64 SalesTargetProfit12)
        {

            this._sectionCode = SectionCode;
            this._sectionGuideSnm = SectionGuideSnm;
            this._subSectionCode = SubSectionCode;
            this._subSectionName = SubSectionName;
            this._salesEmployeeCd = SalesEmployeeCd;
            this._salesEmployeeNm = SalesEmployeeNm;
            this._frontEmployeeCd = FrontEmployeeCd;
            this._frontEmployeeNm = FrontEmployeeNm;
            this._salesInputCode = SalesInputCode;
            this._salesInputName = SalesInputName;
            this._salesCode = SalesCode;
            this._salesCodeName = SalesCodeName;
            this._enterpriseGanreCode = EnterpriseGanreCode;
            this._enterpriseGanreCodeName = EnterpriseGanreCodeName;
            this._customerCode = CustomerCode;
            this._customerSnm = CustomerSnm;
            this._businessTypeCode = BusinessTypeCode;
            this._businessTypeCodeName = BusinessTypeCodeName;
            this._salesAreaCode = SalesAreaCode;
            this._salesAreaCodeName = SalesAreaCodeName;
            this._salesTargetMoney1 = SalesTargetMoney1;
            this._salesTargetMoney2 = SalesTargetMoney2;
            this._salesTargetMoney3 = SalesTargetMoney3;
            this._salesTargetMoney4 = SalesTargetMoney4;
            this._salesTargetMoney5 = SalesTargetMoney5;
            this._salesTargetMoney6 = SalesTargetMoney6;
            this._salesTargetMoney7 = SalesTargetMoney7;
            this._salesTargetMoney8 = SalesTargetMoney8;
            this._salesTargetMoney9 = SalesTargetMoney9;
            this._salesTargetMoney10 = SalesTargetMoney10;
            this._salesTargetMoney11 = SalesTargetMoney11;
            this._salesTargetMoney12 = SalesTargetMoney12;
            this._salesTargetProfit1 = SalesTargetProfit1;
            this._salesTargetProfit2 = SalesTargetProfit2;
            this._salesTargetProfit3 = SalesTargetProfit3;
            this._salesTargetProfit4 = SalesTargetProfit4;
            this._salesTargetProfit5 = SalesTargetProfit5;
            this._salesTargetProfit6 = SalesTargetProfit6;
            this._salesTargetProfit7 = SalesTargetProfit7;
            this._salesTargetProfit8 = SalesTargetProfit8;
            this._salesTargetProfit9 = SalesTargetProfit9;
            this._salesTargetProfit10 = SalesTargetProfit10;
            this._salesTargetProfit11 = SalesTargetProfit11;
            this._salesTargetProfit12 = SalesTargetProfit12;
        }
    }
}
