using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalTrgtPrintResultWork
    /// <summary>
    ///                      ����ڕW�ݒ������o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����ڕW�ݒ������o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalTrgtPrintResultWork 
    {
        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

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
        /// <remarks>���Е��ރR�[�h</remarks>
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


        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

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
        /// <value>���Е��ރR�[�h</value>
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
        /// ����ڕW�ݒ������o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalTrgtPrintResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalTrgtPrintResultWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalTrgtPrintResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalTrgtPrintResultWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalTrgtPrintResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalTrgtPrintResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalTrgtPrintResultWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalTrgtPrintResultWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalTrgtPrintResultWork || graph is ArrayList || graph is SalTrgtPrintResultWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalTrgtPrintResultWork).FullName));

            if (graph != null && graph is SalTrgtPrintResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalTrgtPrintResultWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalTrgtPrintResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalTrgtPrintResultWork[])graph).Length;
            }
            else if (graph is SalTrgtPrintResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //���喼��
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //�S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeCd
            //�S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //SalesEmployeeNm
            //�󒍎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeCd
            //�󒍎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //FrontEmployeeNm
            //���s�҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputCode
            //���s�Җ���
            serInfo.MemberInfo.Add(typeof(string)); //SalesInputName
            //�̔��敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //�̔��敪����
            serInfo.MemberInfo.Add(typeof(string)); //SalesCodeName
            //���i�敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //���i�敪����
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreCodeName
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�Ǝ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�Ǝ햼��
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeCodeName
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�̔��G���A����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaCodeName
            //����ڕW���z�P
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney1
            //����ڕW���z�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney2
            //����ڕW���z�R
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney3
            //����ڕW���z�S
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney4
            //����ڕW���z�T
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney5
            //����ڕW���z�U
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney6
            //����ڕW���z�V
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney7
            //����ڕW���z�W
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney8
            //����ڕW���z�X
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney9
            //����ڕW���z�P�O
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney10
            //����ڕW���z�P�P
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney11
            //����ڕW���z�P�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetMoney12
            //����ڕW�e���z�P
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit1
            //����ڕW�e���z�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit2
            //����ڕW�e���z�R
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit3
            //����ڕW�e���z�S
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit4
            //����ڕW�e���z�T
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit5
            //����ڕW�e���z�U
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit6
            //����ڕW�e���z�V
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit7
            //����ڕW�e���z�W
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit8
            //����ڕW�e���z�X
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit9
            //����ڕW�e���z�P�O
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit10
            //����ڕW�e���z�P�P
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit11
            //����ڕW�e���z�P�Q
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTargetProfit12


            serInfo.Serialize(writer, serInfo);
            if (graph is SalTrgtPrintResultWork)
            {
                SalTrgtPrintResultWork temp = (SalTrgtPrintResultWork)graph;

                SetSalTrgtPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalTrgtPrintResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalTrgtPrintResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalTrgtPrintResultWork temp in lst)
                {
                    SetSalTrgtPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalTrgtPrintResultWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 45;

        /// <summary>
        ///  SalTrgtPrintResultWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalTrgtPrintResultWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSalTrgtPrintResultWork(System.IO.BinaryWriter writer, SalTrgtPrintResultWork temp)
        {
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideSnm);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //���喼��
            writer.Write(temp.SubSectionName);
            //�S���҃R�[�h
            writer.Write(temp.SalesEmployeeCd);
            //�S���Җ���
            writer.Write(temp.SalesEmployeeNm);
            //�󒍎҃R�[�h
            writer.Write(temp.FrontEmployeeCd);
            //�󒍎Җ���
            writer.Write(temp.FrontEmployeeNm);
            //���s�҃R�[�h
            writer.Write(temp.SalesInputCode);
            //���s�Җ���
            writer.Write(temp.SalesInputName);
            //�̔��敪�R�[�h
            writer.Write(temp.SalesCode);
            //�̔��敪����
            writer.Write(temp.SalesCodeName);
            //���i�敪�R�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //���i�敪����
            writer.Write(temp.EnterpriseGanreCodeName);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�Ǝ�R�[�h
            writer.Write(temp.BusinessTypeCode);
            //�Ǝ햼��
            writer.Write(temp.BusinessTypeCodeName);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�̔��G���A����
            writer.Write(temp.SalesAreaCodeName);
            //����ڕW���z�P
            writer.Write(temp.SalesTargetMoney1);
            //����ڕW���z�Q
            writer.Write(temp.SalesTargetMoney2);
            //����ڕW���z�R
            writer.Write(temp.SalesTargetMoney3);
            //����ڕW���z�S
            writer.Write(temp.SalesTargetMoney4);
            //����ڕW���z�T
            writer.Write(temp.SalesTargetMoney5);
            //����ڕW���z�U
            writer.Write(temp.SalesTargetMoney6);
            //����ڕW���z�V
            writer.Write(temp.SalesTargetMoney7);
            //����ڕW���z�W
            writer.Write(temp.SalesTargetMoney8);
            //����ڕW���z�X
            writer.Write(temp.SalesTargetMoney9);
            //����ڕW���z�P�O
            writer.Write(temp.SalesTargetMoney10);
            //����ڕW���z�P�P
            writer.Write(temp.SalesTargetMoney11);
            //����ڕW���z�P�Q
            writer.Write(temp.SalesTargetMoney12);
            //����ڕW�e���z�P
            writer.Write(temp.SalesTargetProfit1);
            //����ڕW�e���z�Q
            writer.Write(temp.SalesTargetProfit2);
            //����ڕW�e���z�R
            writer.Write(temp.SalesTargetProfit3);
            //����ڕW�e���z�S
            writer.Write(temp.SalesTargetProfit4);
            //����ڕW�e���z�T
            writer.Write(temp.SalesTargetProfit5);
            //����ڕW�e���z�U
            writer.Write(temp.SalesTargetProfit6);
            //����ڕW�e���z�V
            writer.Write(temp.SalesTargetProfit7);
            //����ڕW�e���z�W
            writer.Write(temp.SalesTargetProfit8);
            //����ڕW�e���z�X
            writer.Write(temp.SalesTargetProfit9);
            //����ڕW�e���z�P�O
            writer.Write(temp.SalesTargetProfit10);
            //����ڕW�e���z�P�P
            writer.Write(temp.SalesTargetProfit11);
            //����ڕW�e���z�P�Q
            writer.Write(temp.SalesTargetProfit12);

        }

        /// <summary>
        ///  SalTrgtPrintResultWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalTrgtPrintResultWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalTrgtPrintResultWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SalTrgtPrintResultWork GetSalTrgtPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalTrgtPrintResultWork temp = new SalTrgtPrintResultWork();

            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideSnm = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //���喼��
            temp.SubSectionName = reader.ReadString();
            //�S���҃R�[�h
            temp.SalesEmployeeCd = reader.ReadString();
            //�S���Җ���
            temp.SalesEmployeeNm = reader.ReadString();
            //�󒍎҃R�[�h
            temp.FrontEmployeeCd = reader.ReadString();
            //�󒍎Җ���
            temp.FrontEmployeeNm = reader.ReadString();
            //���s�҃R�[�h
            temp.SalesInputCode = reader.ReadString();
            //���s�Җ���
            temp.SalesInputName = reader.ReadString();
            //�̔��敪�R�[�h
            temp.SalesCode = reader.ReadInt32();
            //�̔��敪����
            temp.SalesCodeName = reader.ReadString();
            //���i�敪�R�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //���i�敪����
            temp.EnterpriseGanreCodeName = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�Ǝ�R�[�h
            temp.BusinessTypeCode = reader.ReadInt32();
            //�Ǝ햼��
            temp.BusinessTypeCodeName = reader.ReadString();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�̔��G���A����
            temp.SalesAreaCodeName = reader.ReadString();
            //����ڕW���z�P
            temp.SalesTargetMoney1 = reader.ReadInt64();
            //����ڕW���z�Q
            temp.SalesTargetMoney2 = reader.ReadInt64();
            //����ڕW���z�R
            temp.SalesTargetMoney3 = reader.ReadInt64();
            //����ڕW���z�S
            temp.SalesTargetMoney4 = reader.ReadInt64();
            //����ڕW���z�T
            temp.SalesTargetMoney5 = reader.ReadInt64();
            //����ڕW���z�U
            temp.SalesTargetMoney6 = reader.ReadInt64();
            //����ڕW���z�V
            temp.SalesTargetMoney7 = reader.ReadInt64();
            //����ڕW���z�W
            temp.SalesTargetMoney8 = reader.ReadInt64();
            //����ڕW���z�X
            temp.SalesTargetMoney9 = reader.ReadInt64();
            //����ڕW���z�P�O
            temp.SalesTargetMoney10 = reader.ReadInt64();
            //����ڕW���z�P�P
            temp.SalesTargetMoney11 = reader.ReadInt64();
            //����ڕW���z�P�Q
            temp.SalesTargetMoney12 = reader.ReadInt64();
            //����ڕW�e���z�P
            temp.SalesTargetProfit1 = reader.ReadInt64();
            //����ڕW�e���z�Q
            temp.SalesTargetProfit2 = reader.ReadInt64();
            //����ڕW�e���z�R
            temp.SalesTargetProfit3 = reader.ReadInt64();
            //����ڕW�e���z�S
            temp.SalesTargetProfit4 = reader.ReadInt64();
            //����ڕW�e���z�T
            temp.SalesTargetProfit5 = reader.ReadInt64();
            //����ڕW�e���z�U
            temp.SalesTargetProfit6 = reader.ReadInt64();
            //����ڕW�e���z�V
            temp.SalesTargetProfit7 = reader.ReadInt64();
            //����ڕW�e���z�W
            temp.SalesTargetProfit8 = reader.ReadInt64();
            //����ڕW�e���z�X
            temp.SalesTargetProfit9 = reader.ReadInt64();
            //����ڕW�e���z�P�O
            temp.SalesTargetProfit10 = reader.ReadInt64();
            //����ڕW�e���z�P�P
            temp.SalesTargetProfit11 = reader.ReadInt64();
            //����ڕW�e���z�P�Q
            temp.SalesTargetProfit12 = reader.ReadInt64();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SalTrgtPrintResultWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalTrgtPrintResultWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalTrgtPrintResultWork temp = GetSalTrgtPrintResultWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SalTrgtPrintResultWork[])lst.ToArray(typeof(SalTrgtPrintResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
