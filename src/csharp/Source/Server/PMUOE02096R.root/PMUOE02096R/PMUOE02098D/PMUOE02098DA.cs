using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UOEAnswerLedgerOrderCndtnWork
    /// <summary>
    ///                      UOE�񓚕\��(�����^�C�v)���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE�񓚕\��(�����^�C�v)���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOEAnswerLedgerOrderCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�V�X�e���敪</summary>
        /// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[�@-1:�S��</remarks>
        private Int32 _systemDivCd;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>UOE������R�[�h</summary>
        private Int32 _uOESupplierCd;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�J�n��M���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_ReceiveDate;

        /// <summary>�I����M���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_ReceiveDate;

        /// <summary>�J�n��M����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_ReceiveTime;

        /// <summary>�I����M����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_ReceiveTime;

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>�˗��҃R�[�h</remarks>
        private string _employeeCode = "";

        /// <summary>UOE�[�i�敪</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>�t�H���[�[�i�敪</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;

        /// <summary>UOE�����ԍ�</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>�t�n�d���}�[�N�P</summary>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>UOE���</summary>
        /// <remarks>0:UOE 1:�����d����M</remarks>
        private Int32 _uOEKind;

        /// <summary>���͓�(�J�n)</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _st_InputDay;

        /// <summary>���͓�(�I��)</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _ed_InputDay;


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

        /// public propaty name  :  SystemDivCd
        /// <summary>�V�X�e���敪�v���p�e�B</summary>
        /// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[�@-1:�S��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�X�e���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
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

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
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

        /// public propaty name  :  St_ReceiveDate
        /// <summary>�J�n��M���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n��M���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_ReceiveDate
        {
            get { return _st_ReceiveDate; }
            set { _st_ReceiveDate = value; }
        }

        /// public propaty name  :  Ed_ReceiveDate
        /// <summary>�I����M���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I����M���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_ReceiveDate
        {
            get { return _ed_ReceiveDate; }
            set { _ed_ReceiveDate = value; }
        }

        /// public propaty name  :  St_ReceiveTime
        /// <summary>�J�n��M�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n��M�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_ReceiveTime
        {
            get { return _st_ReceiveTime; }
            set { _st_ReceiveTime = value; }
        }

        /// public propaty name  :  Ed_ReceiveTime
        /// <summary>�I����M�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I����M�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_ReceiveTime
        {
            get { return _ed_ReceiveTime; }
            set { _ed_ReceiveTime = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�˗��҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>UOE�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>�t�H���[�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  UOESalesOrderNo
        /// <summary>UOE�����ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  UOEKind
        /// <summary>UOE��ʃv���p�e�B</summary>
        /// <value>0:UOE 1:�����d����M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOEKind
        {
            get { return _uOEKind; }
            set { _uOEKind = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>���͓�(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>���͓�(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }


        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtnWork()
        {
        }

    }
}




