//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^�i����j
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�}�X�^�Őݒ肵�����e���ꗗ�o�͂�
//                    �m�F����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignTargetSet
    /// <summary>
    ///                      �L�����y�[���ڕW�ݒ�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���ڕW�ݒ�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class CampaignTargetSet 
    {
        /// <summary>�L�����y�[���R�[�h</summary>
        private string _campaignCode = "";

        /// <summary>�L�����y�[���R�[�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _campaignCodeName = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>�a�k�R�[�h</summary>
        private Int32 _blGoodsCode;

        /// <summary>�a�k�R�[�h����</summary>
        private string _blGoodsCodeName = "";

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

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _blGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _blGroupCodeName = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        private string _salesAreaCodeName = "";

        /// <summary>���㌎�ԖڕW���z</summary>
        private Int64 _monthlySalesTarget;

        /// <summary>������ԖڕW���z</summary>
        private Int64 _termSalesTarget;

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

        /// <summary>���㌎�ԖڕW�e���z</summary>
        private Int64 _monthlySalesTargetProfit;

        /// <summary>������ԖڕW�e���z</summary>
        private Int64 _termSalesTargetProfit;

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

        /// <summary>���㌎�ԖڕW����</summary>
        private Int64 _monthlySalesTargetCount;

        /// <summary>������ԖڕW����</summary>
        private Int64 _termSalesTargetCount;

        /// <summary>����ڕW�e���z�P</summary>
        private Int64 _salesTargetCount1;

        /// <summary>����ڕW�e���z�Q</summary>
        private Int64 _salesTargetCount2;

        /// <summary>����ڕW�e���z�R</summary>
        private Int64 _salesTargetCount3;

        /// <summary>����ڕW�e���z�S</summary>
        private Int64 _salesTargetCount4;

        /// <summary>����ڕW�e���z�T</summary>
        private Int64 _salesTargetCount5;

        /// <summary>����ڕW�e���z�U</summary>
        private Int64 _salesTargetCount6;

        /// <summary>����ڕW�e���z�V</summary>
        private Int64 _salesTargetCount7;

        /// <summary>����ڕW�e���z�W</summary>
        private Int64 _salesTargetCount8;

        /// <summary>����ڕW�e���z�X</summary>
        private Int64 _salesTargetCount9;

        /// <summary>����ڕW�e���z�P�O</summary>
        private Int64 _salesTargetCount10;

        /// <summary>����ڕW�e���z�P�P</summary>
        private Int64 _salesTargetCount11;

        /// <summary>����ڕW�e���z�P�Q</summary>
        private Int64 _salesTargetCount12;

        /// <summary>�J�n�N��</summary>
        private Int32 _targetDivideCodeSt;

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _applyEndDate;


        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  SectionGuideSnm
        /// <summary>�L�����y�[���R�[�h���̃v���p�e�B</summary>
        /// <value>���[�󎚗p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CampaignCodeName
        {
            get { return _campaignCodeName; }
            set { _campaignCodeName = value; }
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
        /// <summary>�a�k�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  SubSectionName
        /// <summary>�a�k�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BlGoodsCodeName
        {
            get { return _blGoodsCodeName; }
            set { _blGoodsCodeName = value; }
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

        /// public propaty name  :  BlGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGroupCode
        {
            get { return _blGroupCode; }
            set { _blGroupCode = value; }
        }

        /// public propaty name  :  BlGroupCodeName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BlGroupCodeName
        {
            get { return _blGroupCodeName; }
            set { _blGroupCodeName = value; }
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

        /// public propaty name  :  MonthlySalesTarget
        /// <summary>���㌎�ԖڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTarget
        {
            get { return _monthlySalesTarget; }
            set { _monthlySalesTarget = value; }
        }

        /// public propaty name  :  TermSalesTarget
        /// <summary>������ԖڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTarget
        {
            get { return _termSalesTarget; }
            set { _termSalesTarget = value; }
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

        /// public propaty name  :  MonthlySalesTargetProfit
        /// <summary>���㌎�ԖڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit
        {
            get { return _monthlySalesTargetProfit; }
            set { _monthlySalesTargetProfit = value; }
        }

        /// public propaty name  :  TermSalesTargetProfit
        /// <summary>������ԖڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit
        {
            get { return _termSalesTargetProfit; }
            set { _termSalesTargetProfit = value; }
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

        /// public propaty name  :  MonthlySalesTargetCount
        /// <summary>���㌎�ԖڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTargetCount
        {
            get { return _monthlySalesTargetCount; }
            set { _monthlySalesTargetCount = value; }
        }

        /// public propaty name  :  TermSalesTargetCount
        /// <summary>������ԖڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTargetCount
        {
            get { return _termSalesTargetCount; }
            set { _termSalesTargetCount = value; }
        }

        /// public propaty name  :  SalesTargetCount1
        /// <summary>����ڕW���ʂP�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂP�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount1
        {
            get { return _salesTargetCount1; }
            set { _salesTargetCount1 = value; }
        }

        /// public propaty name  :  SalesTargetCount2
        /// <summary>����ڕW���ʂQ�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂQ�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount2
        {
            get { return _salesTargetCount2; }
            set { _salesTargetCount2 = value; }
        }

        /// public propaty name  :  SalesTargetCount3
        /// <summary>����ڕW���ʂR�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂR�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount3
        {
            get { return _salesTargetCount3; }
            set { _salesTargetCount3 = value; }
        }

        /// public propaty name  :  SalesTargetCount4
        /// <summary>����ڕW���ʂS�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂS�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount4
        {
            get { return _salesTargetCount4; }
            set { _salesTargetCount4 = value; }
        }

        /// public propaty name  :  SalesTargetCount5
        /// <summary>����ڕW���ʂT�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂT�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount5
        {
            get { return _salesTargetCount5; }
            set { _salesTargetCount5 = value; }
        }

        /// public propaty name  :  SalesTargetCount6
        /// <summary>����ڕW���ʂU�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂU�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount6
        {
            get { return _salesTargetCount6; }
            set { _salesTargetCount6 = value; }
        }

        /// public propaty name  :  SalesTargetCount7
        /// <summary>����ڕW���ʂV�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂV�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount7
        {
            get { return _salesTargetCount7; }
            set { _salesTargetCount7 = value; }
        }

        /// public propaty name  :  SalesTargetCount8
        /// <summary>����ڕW���ʂW�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂW�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount8
        {
            get { return _salesTargetCount8; }
            set { _salesTargetCount8 = value; }
        }

        /// public propaty name  :  SalesTargetCount9
        /// <summary>����ڕW���ʂX�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂX�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount9
        {
            get { return _salesTargetCount9; }
            set { _salesTargetCount9 = value; }
        }

        /// public propaty name  :  SalesTargetCount10
        /// <summary>����ڕW���ʂP�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂP�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount10
        {
            get { return _salesTargetCount10; }
            set { _salesTargetCount10 = value; }
        }

        /// public propaty name  :  SalesTargetCount11
        /// <summary>����ڕW���ʂP�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂP�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount11
        {
            get { return _salesTargetCount11; }
            set { _salesTargetCount11 = value; }
        }

        /// public propaty name  :  SalesTargetCount12
        /// <summary>����ڕW���ʂP�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʂP�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetCount12
        {
            get { return _salesTargetCount12; }
            set { _salesTargetCount12 = value; }
        }

        /// public propaty name  :  TargetDivideCodeSt
        /// <summary>�J�n�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetDivideCodeSt
        {
            get { return _targetDivideCodeSt; }
            set { _targetDivideCodeSt = value; }
        }


        /// public propaty name  :  UpdateDateTime
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// <value>�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// <value>�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }


        /// <summary>
        /// �L�����y�[���ڕW�ݒ�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SalesTargetSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesTargetSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignTargetSet Clone()
        {
            return new CampaignTargetSet(this._campaignCode, this._campaignCodeName, this._sectionCode, this._sectionGuideSnm, this._blGoodsCode, this._blGoodsCodeName, this._salesEmployeeCd, this._salesEmployeeNm, this._frontEmployeeCd, this._frontEmployeeNm, this._salesInputCode, this._salesInputName, this._salesCode, this._salesCodeName, this._blGroupCode, this._blGroupCodeName, this._customerCode, this._customerSnm, this._salesAreaCode, this._salesAreaCodeName, this._monthlySalesTarget, this._termSalesTarget, this._salesTargetMoney1, this._salesTargetMoney2, this._salesTargetMoney3, this._salesTargetMoney4, this._salesTargetMoney5, this._salesTargetMoney6, this._salesTargetMoney7, this._salesTargetMoney8, this._salesTargetMoney9, this._salesTargetMoney10, this._salesTargetMoney11, this._salesTargetMoney12, this._monthlySalesTargetProfit, this._termSalesTargetProfit, this._salesTargetProfit1, this._salesTargetProfit2, this._salesTargetProfit3, this._salesTargetProfit4, this._salesTargetProfit5, this._salesTargetProfit6, this._salesTargetProfit7, this._salesTargetProfit8, this._salesTargetProfit9, this._salesTargetProfit10, this._salesTargetProfit11, this._salesTargetProfit12, this._monthlySalesTargetCount, this._termSalesTargetCount, this._salesTargetCount1, this._salesTargetCount2, this._salesTargetCount3, this._salesTargetCount4, this._salesTargetCount5, this._salesTargetCount6, this._salesTargetCount7, this._salesTargetCount8, this._salesTargetCount9, this._salesTargetCount10, this._salesTargetCount11, this._salesTargetCount12, this._targetDivideCodeSt, this._applyStaDate, this._applyEndDate);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
        /// <returns>SalesTargetSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesTargetSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CampaignTargetSet()
		{
		}

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="CampaignCode"></param>
        /// <param name="CampaignCodeName"></param>
        /// <param name="SectionCode"></param>
        /// <param name="SectionGuideSnm"></param>
        /// <param name="BlGoodsCode"></param>
        /// <param name="BlGoodsCodeName"></param>
        /// <param name="SalesEmployeeCd"></param>
        /// <param name="SalesEmployeeNm"></param>
        /// <param name="FrontEmployeeCd"></param>
        /// <param name="FrontEmployeeNm"></param>
        /// <param name="SalesInputCode"></param>
        /// <param name="SalesInputName"></param>
        /// <param name="SalesCode"></param>
        /// <param name="SalesCodeName"></param>
        /// <param name="BlGroupCode"></param>
        /// <param name="BlGroupCodeName"></param>
        /// <param name="CustomerCode"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="SalesAreaCode"></param>
        /// <param name="SalesAreaCodeName"></param>
        /// <param name="MonthlySalesTarget"></param>
        /// <param name="TermSalesTarget"></param>
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
        /// <param name="MonthlySalesTargetProfit"></param>
        /// <param name="TermSalesTargetProfit"></param>
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
        /// <param name="MonthlySalesTargetCount"></param>
        /// <param name="TermSalesTargetCount"></param>
        /// <param name="SalesTargetCount1"></param>
        /// <param name="SalesTargetCount2"></param>
        /// <param name="SalesTargetCount3"></param>
        /// <param name="SalesTargetCount4"></param>
        /// <param name="SalesTargetCount5"></param>
        /// <param name="SalesTargetCount6"></param>
        /// <param name="SalesTargetCount7"></param>
        /// <param name="SalesTargetCount8"></param>
        /// <param name="SalesTargetCount9"></param>
        /// <param name="SalesTargetCount10"></param>
        /// <param name="SalesTargetCount11"></param>
        /// <param name="SalesTargetCount12"></param>
        /// <param name="TargetDivideCodeSt"></param>
        /// <param name="ApplyStaDate"></param>
        /// <param name="ApplyEndDate"></param>
        public CampaignTargetSet(string CampaignCode, string CampaignCodeName, string SectionCode, string SectionGuideSnm, Int32 BlGoodsCode, string BlGoodsCodeName, string SalesEmployeeCd, string SalesEmployeeNm, string FrontEmployeeCd, string FrontEmployeeNm, string SalesInputCode, string SalesInputName, Int32 SalesCode, string SalesCodeName, Int32 BlGroupCode, string BlGroupCodeName, Int32 CustomerCode, string CustomerSnm, Int32 SalesAreaCode, string SalesAreaCodeName, Int64 MonthlySalesTarget, Int64 TermSalesTarget, Int64 SalesTargetMoney1, Int64 SalesTargetMoney2, Int64 SalesTargetMoney3, Int64 SalesTargetMoney4, Int64 SalesTargetMoney5, Int64 SalesTargetMoney6, Int64 SalesTargetMoney7, Int64 SalesTargetMoney8, Int64 SalesTargetMoney9, Int64 SalesTargetMoney10, Int64 SalesTargetMoney11, Int64 SalesTargetMoney12, Int64 MonthlySalesTargetProfit, Int64 TermSalesTargetProfit, Int64 SalesTargetProfit1, Int64 SalesTargetProfit2, Int64 SalesTargetProfit3, Int64 SalesTargetProfit4, Int64 SalesTargetProfit5, Int64 SalesTargetProfit6, Int64 SalesTargetProfit7, Int64 SalesTargetProfit8, Int64 SalesTargetProfit9, Int64 SalesTargetProfit10, Int64 SalesTargetProfit11, Int64 SalesTargetProfit12, Int64 MonthlySalesTargetCount, Int64 TermSalesTargetCount, Int64 SalesTargetCount1, Int64 SalesTargetCount2, Int64 SalesTargetCount3, Int64 SalesTargetCount4, Int64 SalesTargetCount5, Int64 SalesTargetCount6, Int64 SalesTargetCount7, Int64 SalesTargetCount8, Int64 SalesTargetCount9, Int64 SalesTargetCount10, Int64 SalesTargetCount11, Int64 SalesTargetCount12, Int32 TargetDivideCodeSt, DateTime ApplyStaDate, DateTime ApplyEndDate)
        {
            this._campaignCode = CampaignCode;
            this._campaignCodeName = CampaignCodeName;
            this._sectionCode = SectionCode;
            this._sectionGuideSnm = SectionGuideSnm;
            this._blGoodsCode = BlGoodsCode;
            this._blGoodsCodeName = BlGoodsCodeName;
            this._salesEmployeeCd = SalesEmployeeCd;
            this._salesEmployeeNm = SalesEmployeeNm;
            this._frontEmployeeCd = FrontEmployeeCd;
            this._frontEmployeeNm = FrontEmployeeNm;
            this._salesInputCode = SalesInputCode;
            this._salesInputName = SalesInputName;
            this._salesCode = SalesCode;
            this._salesCodeName = SalesCodeName;
            this._blGroupCode = BlGroupCode;
            this._blGroupCodeName = BlGroupCodeName;
            this._customerCode = CustomerCode;
            this._customerSnm = CustomerSnm;
            this._salesAreaCode = SalesAreaCode;
            this._salesAreaCodeName = SalesAreaCodeName;
            this._monthlySalesTarget = MonthlySalesTarget;
            this._termSalesTarget = TermSalesTarget;
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
            this._monthlySalesTargetProfit = MonthlySalesTargetProfit;
            this._termSalesTargetProfit = TermSalesTargetProfit;
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
            this._monthlySalesTargetCount = MonthlySalesTargetCount;
            this._termSalesTargetCount = TermSalesTargetCount;
            this._salesTargetCount1 = SalesTargetCount1;
            this._salesTargetCount2 = SalesTargetCount2;
            this._salesTargetCount3 = SalesTargetCount3;
            this._salesTargetCount4 = SalesTargetCount4;
            this._salesTargetCount5 = SalesTargetCount5;
            this._salesTargetCount6 = SalesTargetCount6;
            this._salesTargetCount7 = SalesTargetCount7;
            this._salesTargetCount8 = SalesTargetCount8;
            this._salesTargetCount9 = SalesTargetCount9;
            this._salesTargetCount10 = SalesTargetCount10;
            this._salesTargetCount11 = SalesTargetCount11;
            this._salesTargetCount12 = SalesTargetCount12;
            this._targetDivideCodeSt = TargetDivideCodeSt;
            this._applyStaDate = ApplyStaDate;
            this._applyEndDate = ApplyEndDate;
        }
    }
}
