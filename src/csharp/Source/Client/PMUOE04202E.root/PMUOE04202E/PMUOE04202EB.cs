using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOEAnswerLedgerOrderCndtn
    /// <summary>
    ///                      UOE�񓚕\��(�����^�C�v)���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE�񓚕\��(�����^�C�v)���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOEAnswerLedgerOrderCndtn
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

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        // --- �蓮���� ----------------------------->>>>>
        /// <summary>�V�X�e���敪����</summary>
        private string _systemDivName = "";

        /// <summary>UOE�����於��</summary>
        private string _uoeSupplierName = "";

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";
        // ------------------------------------------<<<<<

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

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        // --- �蓮���� ----------------------------------------------------------->>>>>
        /// public propaty name  :  SystemDivName
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   �蓮����</br>
        /// </remarks>
        public string SystemDivName
        {
            get { return _systemDivName; }
            set { _systemDivName = value; }
        }
        /// public propaty name  :  UOESupplierName
        /// <summary>UOE�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����於�̃v���p�e�B</br>
        /// <br>Programer        :   �蓮����</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uoeSupplierName; }
            set { _uoeSupplierName = value; }
        }
        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   �蓮����</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        // ------------------------------------------------------------------------<<<<<

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn()
        {
        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="systemDivCd">�V�X�e���敪(0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[�@-1:�S��)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="st_ReceiveDate">�J�n��M���t(YYYYMMDD)</param>
        /// <param name="ed_ReceiveDate">�I����M���t(YYYYMMDD)</param>
        /// <param name="st_ReceiveTime">�J�n��M����(YYYYMMDD)</param>
        /// <param name="ed_ReceiveTime">�I����M����(YYYYMMDD)</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h(�˗��҃R�[�h)</param>
        /// <param name="uOEDeliGoodsDiv">UOE�[�i�敪</param>
        /// <param name="followDeliGoodsDiv">�t�H���[�[�i�敪</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="uOESalesOrderNo">UOE�����ԍ�</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
        /// <param name="uOEKind">UOE���(0:UOE 1:�����d����M)</param>
        /// <param name="st_InputDay">���͓�(�J�n)(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="ed_InputDay">���͓�(�I��)(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn(string enterpriseCode, Int32 systemDivCd, string sectionCode, Int32 uOESupplierCd, Int32 customerCode, DateTime st_ReceiveDate, DateTime ed_ReceiveDate, DateTime st_ReceiveTime, DateTime ed_ReceiveTime, string employeeCode, string uOEDeliGoodsDiv, string followDeliGoodsDiv, Int32 supplierSlipNo, Int32 uOESalesOrderNo, string uoeRemark1, string uoeRemark2, Int32 uOEKind, DateTime st_InputDay, DateTime ed_InputDay, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._systemDivCd = systemDivCd;
            this._sectionCode = sectionCode;
            this._uOESupplierCd = uOESupplierCd;
            this._customerCode = customerCode;
            this._st_ReceiveDate = st_ReceiveDate;
            this._ed_ReceiveDate = ed_ReceiveDate;
            this._st_ReceiveTime = st_ReceiveTime;
            this._ed_ReceiveTime = ed_ReceiveTime;
            this._employeeCode = employeeCode;
            this._uOEDeliGoodsDiv = uOEDeliGoodsDiv;
            this._followDeliGoodsDiv = followDeliGoodsDiv;
            this._supplierSlipNo = supplierSlipNo;
            this._uOESalesOrderNo = uOESalesOrderNo;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._uOEKind = uOEKind;
            this._st_InputDay = st_InputDay;
            this._ed_InputDay = ed_InputDay;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��������
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn Clone()
        {
            return new UOEAnswerLedgerOrderCndtn(this._enterpriseCode, this._systemDivCd, this._sectionCode, this._uOESupplierCd, this._customerCode, this._st_ReceiveDate, this._ed_ReceiveDate, this._st_ReceiveTime, this._ed_ReceiveTime, this._employeeCode, this._uOEDeliGoodsDiv, this._followDeliGoodsDiv, this._supplierSlipNo, this._uOESalesOrderNo, this._uoeRemark1, this._uoeRemark2, this._uOEKind, this._st_InputDay, this._ed_InputDay, this._enterpriseName);
        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UOEAnswerLedgerOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.SectionCode == target.SectionCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.St_ReceiveDate == target.St_ReceiveDate)
                 && (this.Ed_ReceiveDate == target.Ed_ReceiveDate)
                 && (this.St_ReceiveTime == target.St_ReceiveTime)
                 && (this.Ed_ReceiveTime == target.Ed_ReceiveTime)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.UOEDeliGoodsDiv == target.UOEDeliGoodsDiv)
                 && (this.FollowDeliGoodsDiv == target.FollowDeliGoodsDiv)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.UOESalesOrderNo == target.UOESalesOrderNo)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.UOEKind == target.UOEKind)
                 && (this.St_InputDay == target.St_InputDay)
                 && (this.Ed_InputDay == target.Ed_InputDay)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��r����
        /// </summary>
        /// <param name="uOEAnswerLedgerOrderCndtn1">
        ///                    ��r����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="uOEAnswerLedgerOrderCndtn2">��r����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn1, UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn2)
        {
            return ((uOEAnswerLedgerOrderCndtn1.EnterpriseCode == uOEAnswerLedgerOrderCndtn2.EnterpriseCode)
                 && (uOEAnswerLedgerOrderCndtn1.SystemDivCd == uOEAnswerLedgerOrderCndtn2.SystemDivCd)
                 && (uOEAnswerLedgerOrderCndtn1.SectionCode == uOEAnswerLedgerOrderCndtn2.SectionCode)
                 && (uOEAnswerLedgerOrderCndtn1.UOESupplierCd == uOEAnswerLedgerOrderCndtn2.UOESupplierCd)
                 && (uOEAnswerLedgerOrderCndtn1.CustomerCode == uOEAnswerLedgerOrderCndtn2.CustomerCode)
                 && (uOEAnswerLedgerOrderCndtn1.St_ReceiveDate == uOEAnswerLedgerOrderCndtn2.St_ReceiveDate)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveDate == uOEAnswerLedgerOrderCndtn2.Ed_ReceiveDate)
                 && (uOEAnswerLedgerOrderCndtn1.St_ReceiveTime == uOEAnswerLedgerOrderCndtn2.St_ReceiveTime)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveTime == uOEAnswerLedgerOrderCndtn2.Ed_ReceiveTime)
                 && (uOEAnswerLedgerOrderCndtn1.EmployeeCode == uOEAnswerLedgerOrderCndtn2.EmployeeCode)
                 && (uOEAnswerLedgerOrderCndtn1.UOEDeliGoodsDiv == uOEAnswerLedgerOrderCndtn2.UOEDeliGoodsDiv)
                 && (uOEAnswerLedgerOrderCndtn1.FollowDeliGoodsDiv == uOEAnswerLedgerOrderCndtn2.FollowDeliGoodsDiv)
                 && (uOEAnswerLedgerOrderCndtn1.SupplierSlipNo == uOEAnswerLedgerOrderCndtn2.SupplierSlipNo)
                 && (uOEAnswerLedgerOrderCndtn1.UOESalesOrderNo == uOEAnswerLedgerOrderCndtn2.UOESalesOrderNo)
                 && (uOEAnswerLedgerOrderCndtn1.UoeRemark1 == uOEAnswerLedgerOrderCndtn2.UoeRemark1)
                 && (uOEAnswerLedgerOrderCndtn1.UoeRemark2 == uOEAnswerLedgerOrderCndtn2.UoeRemark2)
                 && (uOEAnswerLedgerOrderCndtn1.UOEKind == uOEAnswerLedgerOrderCndtn2.UOEKind)
                 && (uOEAnswerLedgerOrderCndtn1.St_InputDay == uOEAnswerLedgerOrderCndtn2.St_InputDay)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_InputDay == uOEAnswerLedgerOrderCndtn2.Ed_InputDay)
                 && (uOEAnswerLedgerOrderCndtn1.EnterpriseName == uOEAnswerLedgerOrderCndtn2.EnterpriseName));
        }
        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UOEAnswerLedgerOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.St_ReceiveDate != target.St_ReceiveDate) resList.Add("St_ReceiveDate");
            if (this.Ed_ReceiveDate != target.Ed_ReceiveDate) resList.Add("Ed_ReceiveDate");
            if (this.St_ReceiveTime != target.St_ReceiveTime) resList.Add("St_ReceiveTime");
            if (this.Ed_ReceiveTime != target.Ed_ReceiveTime) resList.Add("Ed_ReceiveTime");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.UOEDeliGoodsDiv != target.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (this.FollowDeliGoodsDiv != target.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.UOESalesOrderNo != target.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.UOEKind != target.UOEKind) resList.Add("UOEKind");
            if (this.St_InputDay != target.St_InputDay) resList.Add("St_InputDay");
            if (this.Ed_InputDay != target.Ed_InputDay) resList.Add("Ed_InputDay");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��r����
        /// </summary>
        /// <param name="uOEAnswerLedgerOrderCndtn1">��r����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <param name="uOEAnswerLedgerOrderCndtn2">��r����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn1, UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (uOEAnswerLedgerOrderCndtn1.EnterpriseCode != uOEAnswerLedgerOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOEAnswerLedgerOrderCndtn1.SystemDivCd != uOEAnswerLedgerOrderCndtn2.SystemDivCd) resList.Add("SystemDivCd");
            if (uOEAnswerLedgerOrderCndtn1.SectionCode != uOEAnswerLedgerOrderCndtn2.SectionCode) resList.Add("SectionCode");
            if (uOEAnswerLedgerOrderCndtn1.UOESupplierCd != uOEAnswerLedgerOrderCndtn2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOEAnswerLedgerOrderCndtn1.CustomerCode != uOEAnswerLedgerOrderCndtn2.CustomerCode) resList.Add("CustomerCode");
            if (uOEAnswerLedgerOrderCndtn1.St_ReceiveDate != uOEAnswerLedgerOrderCndtn2.St_ReceiveDate) resList.Add("St_ReceiveDate");
            if (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveDate != uOEAnswerLedgerOrderCndtn2.Ed_ReceiveDate) resList.Add("Ed_ReceiveDate");
            if (uOEAnswerLedgerOrderCndtn1.St_ReceiveTime != uOEAnswerLedgerOrderCndtn2.St_ReceiveTime) resList.Add("St_ReceiveTime");
            if (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveTime != uOEAnswerLedgerOrderCndtn2.Ed_ReceiveTime) resList.Add("Ed_ReceiveTime");
            if (uOEAnswerLedgerOrderCndtn1.EmployeeCode != uOEAnswerLedgerOrderCndtn2.EmployeeCode) resList.Add("EmployeeCode");
            if (uOEAnswerLedgerOrderCndtn1.UOEDeliGoodsDiv != uOEAnswerLedgerOrderCndtn2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (uOEAnswerLedgerOrderCndtn1.FollowDeliGoodsDiv != uOEAnswerLedgerOrderCndtn2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (uOEAnswerLedgerOrderCndtn1.SupplierSlipNo != uOEAnswerLedgerOrderCndtn2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (uOEAnswerLedgerOrderCndtn1.UOESalesOrderNo != uOEAnswerLedgerOrderCndtn2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (uOEAnswerLedgerOrderCndtn1.UoeRemark1 != uOEAnswerLedgerOrderCndtn2.UoeRemark1) resList.Add("UoeRemark1");
            if (uOEAnswerLedgerOrderCndtn1.UoeRemark2 != uOEAnswerLedgerOrderCndtn2.UoeRemark2) resList.Add("UoeRemark2");
            if (uOEAnswerLedgerOrderCndtn1.UOEKind != uOEAnswerLedgerOrderCndtn2.UOEKind) resList.Add("UOEKind");
            if (uOEAnswerLedgerOrderCndtn1.St_InputDay != uOEAnswerLedgerOrderCndtn2.St_InputDay) resList.Add("St_InputDay");
            if (uOEAnswerLedgerOrderCndtn1.Ed_InputDay != uOEAnswerLedgerOrderCndtn2.Ed_InputDay) resList.Add("Ed_InputDay");
            if (uOEAnswerLedgerOrderCndtn1.EnterpriseName != uOEAnswerLedgerOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}

/*
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOEAnswerLedgerOrderCndtn
    /// <summary>
    ///                      UOE�񓚕\��(�����^�C�v)���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE�񓚕\��(�����^�C�v)���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOEAnswerLedgerOrderCndtn
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
        private Int32 _st_ReceiveTime;

        /// <summary>�I����M����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _ed_ReceiveTime;

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>�˗��҃R�[�h</remarks>
        private string _employeeCode = "";

        /// <summary>�[�i�敪</summary>
        private Int32 _deliveredGoodsDiv;

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

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        // --- �蓮���� ----------------------------->>>>>
        /// <summary>�V�X�e���敪����</summary>
        private string _systemDivName = "";

        /// <summary>UOE�����於��</summary>
        private string _uoeSupplierName = "";

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";
        // ------------------------------------------<<<<<

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
        public Int32 St_ReceiveTime
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
        public Int32 Ed_ReceiveTime
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

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
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

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        // --- �蓮���� ----------------------------------------------------------->>>>>
        /// public propaty name  :  SystemDivName
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   �蓮����</br>
        /// </remarks>
        public string SystemDivName
        {
            get { return _systemDivName; }
            set { _systemDivName = value; }
        }
        /// public propaty name  :  UOESupplierName
        /// <summary>UOE�����於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE�����於�̃v���p�e�B</br>
        /// <br>Programer        :   �蓮����</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uoeSupplierName; }
            set { _uoeSupplierName = value; }
        }
        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   �蓮����</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        // ------------------------------------------------------------------------<<<<<

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn()
        {
        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="systemDivCd">�V�X�e���敪(0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[�@-1:�S��)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="uOESupplierCd">UOE������R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="st_ReceiveDate">�J�n��M���t(YYYYMMDD)</param>
        /// <param name="ed_ReceiveDate">�I����M���t(YYYYMMDD)</param>
        /// <param name="st_ReceiveTime">�J�n��M����(YYYYMMDD)</param>
        /// <param name="ed_ReceiveTime">�I����M����(YYYYMMDD)</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h(�˗��҃R�[�h)</param>
        /// <param name="deliveredGoodsDiv">�[�i�敪</param>
        /// <param name="followDeliGoodsDiv">�t�H���[�[�i�敪</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="uOESalesOrderNo">UOE�����ԍ�</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <returns>UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn(string enterpriseCode, Int32 systemDivCd, string sectionCode, Int32 uOESupplierCd, Int32 customerCode, DateTime st_ReceiveDate, DateTime ed_ReceiveDate, Int32 st_ReceiveTime, Int32 ed_ReceiveTime, string employeeCode, Int32 deliveredGoodsDiv, string followDeliGoodsDiv, Int32 supplierSlipNo, Int32 uOESalesOrderNo, string uoeRemark1, string uoeRemark2, string enterpriseName)
        {
            this._enterpriseCode = enterpriseCode;
            this._systemDivCd = systemDivCd;
            this._sectionCode = sectionCode;
            this._uOESupplierCd = uOESupplierCd;
            this._customerCode = customerCode;
            this._st_ReceiveDate = st_ReceiveDate;
            this._ed_ReceiveDate = ed_ReceiveDate;
            this._st_ReceiveTime = st_ReceiveTime;
            this._ed_ReceiveTime = ed_ReceiveTime;
            this._employeeCode = employeeCode;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._followDeliGoodsDiv = followDeliGoodsDiv;
            this._supplierSlipNo = supplierSlipNo;
            this._uOESalesOrderNo = uOESalesOrderNo;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��������
        /// </summary>
        /// <returns>UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOEAnswerLedgerOrderCndtn Clone()
        {
            return new UOEAnswerLedgerOrderCndtn(this._enterpriseCode, this._systemDivCd, this._sectionCode, this._uOESupplierCd, this._customerCode, this._st_ReceiveDate, this._ed_ReceiveDate, this._st_ReceiveTime, this._ed_ReceiveTime, this._employeeCode, this._deliveredGoodsDiv, this._followDeliGoodsDiv, this._supplierSlipNo, this._uOESalesOrderNo, this._uoeRemark1, this._uoeRemark2, this._enterpriseName);
        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UOEAnswerLedgerOrderCndtn target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.SectionCode == target.SectionCode)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.St_ReceiveDate == target.St_ReceiveDate)
                 && (this.Ed_ReceiveDate == target.Ed_ReceiveDate)
                 && (this.St_ReceiveTime == target.St_ReceiveTime)
                 && (this.Ed_ReceiveTime == target.Ed_ReceiveTime)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.FollowDeliGoodsDiv == target.FollowDeliGoodsDiv)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.UOESalesOrderNo == target.UOESalesOrderNo)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��r����
        /// </summary>
        /// <param name="uOEAnswerLedgerOrderCndtn1">
        ///                    ��r����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="uOEAnswerLedgerOrderCndtn2">��r����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn1, UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn2)
        {
            return ((uOEAnswerLedgerOrderCndtn1.EnterpriseCode == uOEAnswerLedgerOrderCndtn2.EnterpriseCode)
                 && (uOEAnswerLedgerOrderCndtn1.SystemDivCd == uOEAnswerLedgerOrderCndtn2.SystemDivCd)
                 && (uOEAnswerLedgerOrderCndtn1.SectionCode == uOEAnswerLedgerOrderCndtn2.SectionCode)
                 && (uOEAnswerLedgerOrderCndtn1.UOESupplierCd == uOEAnswerLedgerOrderCndtn2.UOESupplierCd)
                 && (uOEAnswerLedgerOrderCndtn1.CustomerCode == uOEAnswerLedgerOrderCndtn2.CustomerCode)
                 && (uOEAnswerLedgerOrderCndtn1.St_ReceiveDate == uOEAnswerLedgerOrderCndtn2.St_ReceiveDate)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveDate == uOEAnswerLedgerOrderCndtn2.Ed_ReceiveDate)
                 && (uOEAnswerLedgerOrderCndtn1.St_ReceiveTime == uOEAnswerLedgerOrderCndtn2.St_ReceiveTime)
                 && (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveTime == uOEAnswerLedgerOrderCndtn2.Ed_ReceiveTime)
                 && (uOEAnswerLedgerOrderCndtn1.EmployeeCode == uOEAnswerLedgerOrderCndtn2.EmployeeCode)
                 && (uOEAnswerLedgerOrderCndtn1.DeliveredGoodsDiv == uOEAnswerLedgerOrderCndtn2.DeliveredGoodsDiv)
                 && (uOEAnswerLedgerOrderCndtn1.FollowDeliGoodsDiv == uOEAnswerLedgerOrderCndtn2.FollowDeliGoodsDiv)
                 && (uOEAnswerLedgerOrderCndtn1.SupplierSlipNo == uOEAnswerLedgerOrderCndtn2.SupplierSlipNo)
                 && (uOEAnswerLedgerOrderCndtn1.UOESalesOrderNo == uOEAnswerLedgerOrderCndtn2.UOESalesOrderNo)
                 && (uOEAnswerLedgerOrderCndtn1.UoeRemark1 == uOEAnswerLedgerOrderCndtn2.UoeRemark1)
                 && (uOEAnswerLedgerOrderCndtn1.UoeRemark2 == uOEAnswerLedgerOrderCndtn2.UoeRemark2)
                 && (uOEAnswerLedgerOrderCndtn1.EnterpriseName == uOEAnswerLedgerOrderCndtn2.EnterpriseName));
        }
        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UOEAnswerLedgerOrderCndtn target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.St_ReceiveDate != target.St_ReceiveDate) resList.Add("St_ReceiveDate");
            if (this.Ed_ReceiveDate != target.Ed_ReceiveDate) resList.Add("Ed_ReceiveDate");
            if (this.St_ReceiveTime != target.St_ReceiveTime) resList.Add("St_ReceiveTime");
            if (this.Ed_ReceiveTime != target.Ed_ReceiveTime) resList.Add("Ed_ReceiveTime");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.FollowDeliGoodsDiv != target.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.UOESalesOrderNo != target.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }

        /// <summary>
        /// UOE�񓚕\��(�����^�C�v)���o�����N���X��r����
        /// </summary>
        /// <param name="uOEAnswerLedgerOrderCndtn1">��r����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <param name="uOEAnswerLedgerOrderCndtn2">��r����UOEAnswerLedgerOrderCndtn�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOEAnswerLedgerOrderCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn1, UOEAnswerLedgerOrderCndtn uOEAnswerLedgerOrderCndtn2)
        {
            ArrayList resList = new ArrayList();
            if (uOEAnswerLedgerOrderCndtn1.EnterpriseCode != uOEAnswerLedgerOrderCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOEAnswerLedgerOrderCndtn1.SystemDivCd != uOEAnswerLedgerOrderCndtn2.SystemDivCd) resList.Add("SystemDivCd");
            if (uOEAnswerLedgerOrderCndtn1.SectionCode != uOEAnswerLedgerOrderCndtn2.SectionCode) resList.Add("SectionCode");
            if (uOEAnswerLedgerOrderCndtn1.UOESupplierCd != uOEAnswerLedgerOrderCndtn2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOEAnswerLedgerOrderCndtn1.CustomerCode != uOEAnswerLedgerOrderCndtn2.CustomerCode) resList.Add("CustomerCode");
            if (uOEAnswerLedgerOrderCndtn1.St_ReceiveDate != uOEAnswerLedgerOrderCndtn2.St_ReceiveDate) resList.Add("St_ReceiveDate");
            if (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveDate != uOEAnswerLedgerOrderCndtn2.Ed_ReceiveDate) resList.Add("Ed_ReceiveDate");
            if (uOEAnswerLedgerOrderCndtn1.St_ReceiveTime != uOEAnswerLedgerOrderCndtn2.St_ReceiveTime) resList.Add("St_ReceiveTime");
            if (uOEAnswerLedgerOrderCndtn1.Ed_ReceiveTime != uOEAnswerLedgerOrderCndtn2.Ed_ReceiveTime) resList.Add("Ed_ReceiveTime");
            if (uOEAnswerLedgerOrderCndtn1.EmployeeCode != uOEAnswerLedgerOrderCndtn2.EmployeeCode) resList.Add("EmployeeCode");
            if (uOEAnswerLedgerOrderCndtn1.DeliveredGoodsDiv != uOEAnswerLedgerOrderCndtn2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (uOEAnswerLedgerOrderCndtn1.FollowDeliGoodsDiv != uOEAnswerLedgerOrderCndtn2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (uOEAnswerLedgerOrderCndtn1.SupplierSlipNo != uOEAnswerLedgerOrderCndtn2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (uOEAnswerLedgerOrderCndtn1.UOESalesOrderNo != uOEAnswerLedgerOrderCndtn2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (uOEAnswerLedgerOrderCndtn1.UoeRemark1 != uOEAnswerLedgerOrderCndtn2.UoeRemark1) resList.Add("UoeRemark1");
            if (uOEAnswerLedgerOrderCndtn1.UoeRemark2 != uOEAnswerLedgerOrderCndtn2.UoeRemark2) resList.Add("UoeRemark2");
            if (uOEAnswerLedgerOrderCndtn1.EnterpriseName != uOEAnswerLedgerOrderCndtn2.EnterpriseName) resList.Add("EnterpriseName");

            return resList;
        }
    }
}
*/