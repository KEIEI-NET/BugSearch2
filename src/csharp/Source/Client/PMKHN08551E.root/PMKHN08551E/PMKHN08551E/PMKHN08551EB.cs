using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomerSet
    /// <summary>
    ///                      ���Ӑ�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class CustomerSet 
    {
        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�J�i</summary>
        private string _kana = "";

        /// <summary>�d�b�ԍ��i�Ζ���j</summary>
        private string _officeTelNo = "";

        /// <summary>�d�b�ԍ��i�g�сj</summary>
        private string _portableTelNo = "";

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        private string _officeFaxNo = "";

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>�W�����敪����</summary>
        /// <remarks>����,����,���X��</remarks>
        private string _collectMoneyName = "";

        /// <summary>�W����</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        /// <remarks>�����^</remarks>
        private string _customerAgentCd = "";

        /// <summary>�ڋq�S���]�ƈ�����</summary>
        private string _customerAgentName = "";

        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCode;

        /// <summary>�̔��G���A����</summary>
        private string _salesAreaName = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";

        /// <summary>�������_�R�[�h</summary>
        private string _claimSectionCode = "";

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�W���S���]�ƈ��R�[�h</summary>
        private string _billCollecterCd = "";

        /// <summary>�X�֔ԍ�</summary>
        private string _postNo = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _address1 = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        private string _address3 = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        private string _address4 = "";

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>���[�󎚗p</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>���Ӑ�D��q�ɃR�[�h</summary>
        private string _custWarehouseCd;

        /// <summary>����</summary>
        private string _name = "";

        /// <summary>����2</summary>
        private string _name2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�����A1:�D��</remarks>
        private Int32 _pureCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>��)�����敪=�u0:�����v�̏ꍇ�Ɏg�p 00:����ALL�A01�`25:�J�[���[�J�[</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;


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

        /// public propaty name  :  Kana
        /// <summary>�J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>�W�����敪���̃v���p�e�B</summary>
        /// <value>����,����,���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
        }

        /// public propaty name  :  CollectMoneyDay
        /// <summary>�W�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>�ڋq�S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�����^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  CustomerAgentName
        /// <summary>�ڋq�S���]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerAgentName
        {
            get { return _customerAgentName; }
            set { _customerAgentName = value; }
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

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
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

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  ClaimSectionCode
        /// <summary>�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>�W���S���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W���S���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
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

        /// public propaty name  :  CustWarehouseCd
        /// <summary>���Ӑ�D��q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�D��q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustWarehouseCd
        {
            get { return _custWarehouseCd; }
            set { _custWarehouseCd = value; }
        }

        /// public propaty name  :  Name
        /// <summary>���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
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

        /// public propaty name  :  PureCode
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����A1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PureCode
        {
            get { return _pureCode; }
            set { _pureCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>��)�����敪=�u0:�����v�̏ꍇ�Ɏg�p 00:����ALL�A01�`25:�J�[���[�J�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
        }			

        /// <summary>
        /// ���Ӑ�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerSet Clone()
        {
            return new CustomerSet(this._customerCode, this._kana, this._officeTelNo, this._portableTelNo, this._officeFaxNo, this._totalDay, this._collectMoneyName, this._collectMoneyDay, this._customerAgentCd, this._customerAgentName, this._salesAreaCode, this._salesAreaName, this._businessTypeCode, this._businessTypeName, this._claimSectionCode, this._claimCode, this._billCollecterCd, this._postNo, this._address1, this._address3, this._address4, this._mngSectionCode, this._sectionGuideSnm, this._custWarehouseCd, this._name, this._name2, this._customerSnm, this._pureCode, this._goodsMakerCd, this._custRateGrpCode);
        }

        /// <summary>
		/// ���Ӑ�i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>CustomerSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerSet()
		{
		}
        
        /// <summary>
        /// ���Ӑ�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <param name="Kana"></param>
        /// <param name="OfficeTelNo"></param>
        /// <param name="PortableTelNo"></param>
        /// <param name="OfficeFaxNo"></param>
        /// <param name="TotalDay"></param>
        /// <param name="CollectMoneyName"></param>
        /// <param name="CollectMoneyDay"></param>
        /// <param name="CustomerAgentCd"></param>
        /// <param name="CustomerAgentName"></param>
        /// <param name="SalesAreaCode"></param>
        /// <param name="SalesAreaName"></param>
        /// <param name="BusinessTypeCode"></param>
        /// <param name="BusinessTypeName"></param>
        /// <param name="ClaimSectionCode"></param>
        /// <param name="ClaimCode"></param>
        /// <param name="BillCollecterCd"></param>
        /// <param name="PostNo"></param>
        /// <param name="Address1"></param>
        /// <param name="Address3"></param>
        /// <param name="Address4"></param>
        /// <param name="MngSectionCode"></param>
        /// <param name="SectionGuideSnm"></param>
        /// <param name="CustWarehouseCd"></param>
        /// <param name="Name"></param>
        /// <param name="Name2"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="CustRateGrpCode"></param>
        /// <param name="GoodsMakerCd"></param>
        /// <param name="PureCode"></param>
        public CustomerSet(Int32 CustomerCode, string Kana, string OfficeTelNo, string PortableTelNo, string OfficeFaxNo, Int32 TotalDay, string CollectMoneyName, Int32 CollectMoneyDay, string CustomerAgentCd, string CustomerAgentName, Int32 SalesAreaCode, string SalesAreaName, Int32 BusinessTypeCode, string BusinessTypeName, string ClaimSectionCode, Int32 ClaimCode, string BillCollecterCd, string PostNo, string Address1, string Address3, string Address4, string MngSectionCode, string SectionGuideSnm, string CustWarehouseCd, string Name, string Name2, string CustomerSnm, Int32 PureCode, Int32 GoodsMakerCd, Int32 CustRateGrpCode)
        {

            this._customerCode = CustomerCode;
            this._kana = Kana;
            this._officeTelNo = OfficeTelNo;
            this._portableTelNo = PortableTelNo;
            this._officeFaxNo = OfficeFaxNo;
            this._totalDay = TotalDay;
            this._collectMoneyName = CollectMoneyName;
            this._collectMoneyDay = CollectMoneyDay;
            this._customerAgentCd = CustomerAgentCd;
            this._customerAgentName = CustomerAgentName;
            this._salesAreaCode = SalesAreaCode;
            this._salesAreaName = SalesAreaName;
            this._businessTypeCode = BusinessTypeCode;
            this._businessTypeName = BusinessTypeName;
            this._claimSectionCode = ClaimSectionCode;
            this._claimCode = ClaimCode;
            this._billCollecterCd = BillCollecterCd;
            this._postNo = PostNo;
            this._address1 = Address1;
            this._address3 = Address3;
            this._address4 = Address4;
            this._mngSectionCode = MngSectionCode;
            this._sectionGuideSnm = SectionGuideSnm;
            this._custWarehouseCd = CustWarehouseCd;
            this._name = Name;
            this._name2 = Name2;
            this._customerSnm = CustomerSnm;
            this._pureCode = PureCode;
            this._goodsMakerCd = GoodsMakerCd;
            this._custRateGrpCode = CustRateGrpCode;
        }
    }
}
