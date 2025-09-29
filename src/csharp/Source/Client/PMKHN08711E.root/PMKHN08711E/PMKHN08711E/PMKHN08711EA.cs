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
    /// public class name:   CampaignTargetPrintWork
    /// <summary>
    ///                      �L�����y�[���ڕW�ݒ�}�X�^�}�X�^�i����j�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���ڕW�ݒ�}�X�^�}�X�^�i����j�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignTargetPrintWork
    {
        # region �� private field ��
        /// <summary>����p�^�[��</summary>
        /// <remarks>0:���_ 1:���_-���Ӑ� 2:���_-�S���� 3:���_-�󒍎� 4:���_-���s�� 5:���_-�n�� 6:���_-�O���[�v�R�[�h 7:���_-�a�k�R�[�h 8:���_-�̔��敪 </remarks>
        private Int32 _printType;

        /// <summary>�J�n�L�����y�[���R�[�h</summary>
        private Int32 _campaignCodeSt;

        /// <summary>�I���L�����y�[���R�[�h</summary>
        private Int32 _campaignCodeEd;

        /// <summary>�J�n���_�R�[�h</summary>
        private string _sectionCodeSt = "";

        /// <summary>�I�����_�R�[�h</summary>
        private string _sectionCodeEd = "";

        /// <summary>�J�n�a�k�R�[�h</summary>
        private Int32 _blGoodsCdSt;

        /// <summary>�I���a�k�R�[�h</summary>
        private Int32 _blGoodsCdEd;

        /// <summary>�J�n�]�ƈ��R�[�h</summary>
        private string _employeeCodeSt = "";

        /// <summary>�I���]�ƈ��R�[�h</summary>
        private string _employeeCodeEd = "";

        /// <summary>�J�n�̔��敪�R�[�h</summary>
        private Int32 _salesCodeSt;

        /// <summary>�I���̔��敪�R�[�h</summary>
        private Int32 _salesCodeEd;

        /// <summary>�J�n�O���[�v�R�[�h</summary>
        /// <remarks>���Е��ރR�[�h</remarks>
        private Int32 _blGroupCodeSt;

        /// <summary>�I���O���[�v�R�[�h</summary>
        /// <remarks>���Е��ރR�[�h</remarks>
        private Int32 _blGroupCodeEd;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _customerCodeSt;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _customerCodeEd;

        /// <summary>�J�n�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCodeSt;

        /// <summary>�I���̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCodeEd;

        /// <summary>�폜�w��敪</summary>
        /// <remarks>0:�L��,1:�_���폜</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�J�n�폜���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeSt;

        /// <summary>�I���폜���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeEd;

        /// <summary>�]�ƈ��敪</summary>
        /// <remarks>10:�̔��S���� 20:��t�S���� 30:���͒S����</remarks>
        private Int32 _employeeDivCd;

        /// <summary>����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _startMonth;

        # endregion  �� private field ��

        # region �� public propaty ��
        /// public propaty name  :  PrintType
        /// <summary>����p�^�[���v���p�e�B</summary>
        /// <value>0:���_ 1:���_-���� 2:���_-�S���� 3:���_-�󒍎� 4:���_-���s�� 5:���_-�̔��敪 6:���_-���i�敪 7:���_-���Ӑ� 8:���_-�Ǝ� 9:���_-�n��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�^�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  SectionCodeSt
        /// <summary>�J�n���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  BlGoodsCdSt
        /// <summary>�J�n�a�k�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�a�k�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGoodsCdSt
        {
            get { return _blGoodsCdSt; }
            set { _blGoodsCdSt = value; }
        }

        /// public propaty name  :  BlGoodsCdEd
        /// <summary>�I���a�k�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���a�k�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGoodsCdEd
        {
            get { return _blGoodsCdEd; }
            set { _blGoodsCdEd = value; }
        }

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>�J�n�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>�I���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  SalesCodeSt
        /// <summary>�J�n�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCodeSt
        {
            get { return _salesCodeSt; }
            set { _salesCodeSt = value; }
        }

        /// public propaty name  :  SalesCodeEd
        /// <summary>�I���̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCodeEd
        {
            get { return _salesCodeEd; }
            set { _salesCodeEd = value; }
        }

        /// public propaty name  :  BlGroupCodeSt
        /// <summary>�J�n�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���Е��ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGroupCodeSt
        {
            get { return _blGroupCodeSt; }
            set { _blGroupCodeSt = value; }
        }

        /// public propaty name  :  BlGroupCodeEd
        /// <summary>�I���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���Е��ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGroupCodeEd
        {
            get { return _blGroupCodeEd; }
            set { _blGroupCodeEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeSt
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
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }


        /// public propaty name  :  SalesAreaCodeSt
        /// <summary>�J�n�̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCodeSt
        {
            get { return _salesAreaCodeSt; }
            set { _salesAreaCodeSt = value; }
        }

        /// public propaty name  :  SalesAreaCodeEd
        /// <summary>�I���̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCodeEd
        {
            get { return _salesAreaCodeEd; }
            set { _salesAreaCodeEd = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�폜�w��敪�v���p�e�B</summary>
        /// <value>0:�L��,1:�_���폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �폜�w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DeleteDateTimeSt
        /// <summary>�J�n�폜���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�폜���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeleteDateTimeSt
        {
            get { return _deleteDateTimeSt; }
            set { _deleteDateTimeSt = value; }
        }

        /// public propaty name  :  DeleteDateTimeEd
        /// <summary>�I���폜���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���폜���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }


        /// public propaty name  :  EmployeeDivCd
        /// <summary>�]�ƈ��敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployeeDivCd
        {
            get { return _employeeDivCd; }
            set { _employeeDivCd = value; }
        }


        /// public propaty name  :  CampaignCodeSt
        /// <summary>�J�n�L�����y�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCodeSt
        {
            get { return _campaignCodeSt; }
            set { _campaignCodeSt = value; }
        }

        /// public propaty name  :  CampaignCodeEd
        /// <summary>�I���L�����y�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCodeEd
        {
            get { return _campaignCodeEd; }
            set { _campaignCodeEd = value; }
        }

        /// public propaty name  :  StartMonth
        /// <summary>���񌎃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񌎃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StartMonth
        {
            get { return _startMonth; }
            set { _startMonth = value; }
        }
        # endregion �� public propaty ��

        # region �� Constructor ��
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignTargetPrintWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignTargetPrintWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignTargetPrintWork()
        {
        }
        # endregion �� Constructor ��
    }
}
