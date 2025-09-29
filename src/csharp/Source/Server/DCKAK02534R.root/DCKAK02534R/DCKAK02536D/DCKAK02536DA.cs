using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PaymentSlpCndtnWork
    /// <summary>
    ///                      �x���m�F�\���o�������[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x���m�F�\���o�������[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/07/07  �c��</br>
    /// <br>                 :   Partsman.NS�Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PaymentSlpCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�I�v�V���������敪</summary>
        /// <remarks>true:�S�БI���@false:�e���_�I��</remarks>
        private Boolean _isOptSection;

        /// <summary>�{�Ћ@�\</summary>
        /// <remarks>�����g�p</remarks>
        private Boolean _isMainOfficeFunc;

        /// <summary>�I���x���v�㋒�_�R�[�h</summary>
        private string[] _paymentAddupSecCodeList;

        /// <summary>�J�n�x���v���</summary>
        private DateTime _st_AddUpADate;

        /// <summary>�I���x���v���</summary>
        private DateTime _ed_AddUpADate;

        /// <summary>�J�n�x�����͓�</summary>
        private DateTime _st_InputDate;

        /// <summary>�I���x�����͓�</summary>
        private DateTime _ed_InputDate;

        /// <summary>���[�^�C�v�敪</summary>
        /// <remarks>1:�����v,2:�Ȉ�,3:����ʏW�v</remarks>
        private Int32 _printDiv;

        /// <summary>���[�^�C�v�敪����</summary>
        /// <remarks>�����g�p</remarks>
        private string _printDivName = "";

        /// <summary>���v�敪</summary>
        /// <remarks>0�F���v�A1�F�x����v�A2�F����v�A3�F�x���ԍ��@�����g�p</remarks>
        private Int32 _sumDivState;

        /// <summary>���v�敪�����y�[�W</summary>
        /// <remarks>�����g�p</remarks>
        private Boolean _sumDiv;

        /// <summary>�J�n�x����R�[�h</summary>
        private Int32 _st_PayeeCode;

        /// <summary>�I���x����R�[�h</summary>
        private Int32 _ed_PayeeCode;

        /// <summary>�J�n�x����J�i</summary>
        private string _st_PayeeKana = "";

        /// <summary>�I���x����J�i</summary>
        private string _ed_PayeeKana = "";

        /// <summary>�S���ҋ敪</summary>
        /// <remarks>0:�x���S�� 1:���͒S��</remarks>
        private Int32 _employeeKindDiv;

        /// <summary>�J�n�S���҃R�[�h</summary>
        private string _st_EmployeeCode = "";

        /// <summary>�I���S���҃R�[�h</summary>
        private string _ed_EmployeeCode = "";

        /// <summary>�J�n�x���ԍ�</summary>
        private Int32 _st_PaymentSlipNo;

        /// <summary>�I���x���ԍ�</summary>
        private Int32 _ed_PaymentSlipNo;

        /// <summary>�x������</summary>
        /// <remarks>Key:����R�[�h,Value:���햼��</remarks>
        private ArrayList _paymentKind;


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

        /// public propaty name  :  IsOptSection
        /// <summary>���_�I�v�V���������敪�v���p�e�B</summary>
        /// <value>true:�S�БI���@false:�e���_�I��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�I�v�V���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        /// <value>�����g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�Ћ@�\�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  PaymentAddupSecCodeList
        /// <summary>�I���x���v�㋒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���x���v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] PaymentAddupSecCodeList
        {
            get { return _paymentAddupSecCodeList; }
            set { _paymentAddupSecCodeList = value; }
        }

        /// public propaty name  :  St_AddUpADate
        /// <summary>�J�n�x���v����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�x���v����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_AddUpADate
        {
            get { return _st_AddUpADate; }
            set { _st_AddUpADate = value; }
        }

        /// public propaty name  :  Ed_AddUpADate
        /// <summary>�I���x���v����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���x���v����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_AddUpADate
        {
            get { return _ed_AddUpADate; }
            set { _ed_AddUpADate = value; }
        }

        /// public propaty name  :  St_InputDate
        /// <summary>�J�n�x�����͓��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�x�����͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_InputDate
        {
            get { return _st_InputDate; }
            set { _st_InputDate = value; }
        }

        /// public propaty name  :  Ed_InputDate
        /// <summary>�I���x�����͓��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���x�����͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_InputDate
        {
            get { return _ed_InputDate; }
            set { _ed_InputDate = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>���[�^�C�v�敪�v���p�e�B</summary>
        /// <value>1:�����v,2:�Ȉ�,3:����ʏW�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  PrintDivName
        /// <summary>���[�^�C�v�敪���̃v���p�e�B</summary>
        /// <value>�����g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrintDivName
        {
            get { return _printDivName; }
            set { _printDivName = value; }
        }

        /// public propaty name  :  SumDivState
        /// <summary>���v�敪�v���p�e�B</summary>
        /// <value>0�F���v�A1�F�x����v�A2�F����v�A3�F�x���ԍ��@�����g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SumDivState
        {
            get { return _sumDivState; }
            set { _sumDivState = value; }
        }

        /// public propaty name  :  SumDiv
        /// <summary>���v�敪�����y�[�W�v���p�e�B</summary>
        /// <value>�����g�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�敪�����y�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean SumDiv
        {
            get { return _sumDiv; }
            set { _sumDiv = value; }
        }

        /// public propaty name  :  St_PayeeCode
        /// <summary>�J�n�x����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_PayeeCode
        {
            get { return _st_PayeeCode; }
            set { _st_PayeeCode = value; }
        }

        /// public propaty name  :  Ed_PayeeCode
        /// <summary>�I���x����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_PayeeCode
        {
            get { return _ed_PayeeCode; }
            set { _ed_PayeeCode = value; }
        }

        /// public propaty name  :  St_PayeeKana
        /// <summary>�J�n�x����J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�x����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_PayeeKana
        {
            get { return _st_PayeeKana; }
            set { _st_PayeeKana = value; }
        }

        /// public propaty name  :  Ed_PayeeKana
        /// <summary>�I���x����J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���x����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_PayeeKana
        {
            get { return _ed_PayeeKana; }
            set { _ed_PayeeKana = value; }
        }

        /// public propaty name  :  EmployeeKindDiv
        /// <summary>�S���ҋ敪�v���p�e�B</summary>
        /// <value>0:�x���S�� 1:���͒S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���ҋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployeeKindDiv
        {
            get { return _employeeKindDiv; }
            set { _employeeKindDiv = value; }
        }

        /// public propaty name  :  St_EmployeeCode
        /// <summary>�J�n�S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// public propaty name  :  Ed_EmployeeCode
        /// <summary>�I���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// public propaty name  :  St_PaymentSlipNo
        /// <summary>�J�n�x���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�x���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_PaymentSlipNo
        {
            get { return _st_PaymentSlipNo; }
            set { _st_PaymentSlipNo = value; }
        }

        /// public propaty name  :  Ed_PaymentSlipNo
        /// <summary>�I���x���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���x���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_PaymentSlipNo
        {
            get { return _ed_PaymentSlipNo; }
            set { _ed_PaymentSlipNo = value; }
        }

        /// public propaty name  :  PaymentKind
        /// <summary>�x������v���p�e�B</summary>
        /// <value>Key:����R�[�h,Value:���햼��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList PaymentKind
        {
            get { return _paymentKind; }
            set { _paymentKind = value; }
        }


        /// <summary>
        /// �x���m�F�\���o�������[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PaymentSlpCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentSlpCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PaymentSlpCndtnWork()
        {
        }

    }
}
