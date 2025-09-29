using System;
using System.Collections;
using System.Xml.Serialization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerSearchPara
	/// <summary>
	///                      ���Ӑ挟�������p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ挟�������p�����[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/02/14  (CSharp File Generated Date)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 �Ė� �x��</br>
    /// <br>             MANTIS:14720 ���Ӑ於�����ǉ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2010/08/06 �� ��</br>
    /// <br>             PM1012A:�d�b�ԍ������ǉ��Ɣ����C��</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/08/19 ���C��</br>
    /// <br>             PCC���Зp���Ӑ�K�C�h�ǉ�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/22 ���юR</br>
    /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	public class CustomerSearchPara
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ�T�u�R�[�h</summary>
		private string _customerSubCode = "";

		/// <summary>�J�i</summary>
		private string _kana = "";

		/// <summary>�d�b�ԍ��i�����p��4���j</summary>
		private string _searchTelNo = "";

		/// <summary>�Ɣ̐�敪</summary>
		/// <remarks>0:�Ɣ̐�ȊO,1:�Ɣ̐� -1:�Ɣ̐������</remarks>
		private Int32 _acceptWholeSale;

		/// <summary>���Ӑ�T�u�R�[�h�����^�C�v</summary>
		/// <remarks>0:�O����v����,1:�B������</remarks>
		private Int32 _customerSubCodeSearchType;

		/// <summary>���Ӑ�J�i�����^�C�v</summary>
		/// <remarks>0:�O����v����,1:�B������</remarks>
		private Int32 _kanaSearchType;

		/// <summary>���Ӑ敪�̓R�[�h�P</summary>
		private Int32 _custAnalysCode1;

		/// <summary>���Ӑ敪�̓R�[�h�Q</summary>
		private Int32 _custAnalysCode2;

		/// <summary>���Ӑ敪�̓R�[�h�R</summary>
		private Int32 _custAnalysCode3;

		/// <summary>���Ӑ敪�̓R�[�h�S</summary>
		private Int32 _custAnalysCode4;

		/// <summary>���Ӑ敪�̓R�[�h�T</summary>
		private Int32 _custAnalysCode5;

		/// <summary>���Ӑ敪�̓R�[�h�U</summary>
		private Int32 _custAnalysCode6;

		/// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
		/// <remarks>�����^</remarks>
		private string _customerAgentCd = "";

		/// <summary>�ڋq�S���]�ƈ�����</summary>
		private string _customerAgentNm = "";

		/// <summary>�W���S���]�ƈ��R�[�h</summary>
		private string _billCollecterCd = "";

		/// <summary>�W���S���]�ƈ�����</summary>
		private string _billCollecterNm = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = "";
        /// <summary>�Ǘ����_����</summary>
        private string _mngSectionName = "";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>�_���폜�f�[�^���o�t���O</summary>
		/// <remarks>0:���o���Ȃ� 1:���o����</remarks>
		private Int32 _logicalDeleteDataPickUp;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // 2009/12/02 Add >>>
        /// <summary>���Ӑ於</summary>
        private string _name = "";

        /// <summary>���Ӑ於�����^�C�v</summary>
        /// <remarks>0:�O����v����,1:�B������</remarks>
        private Int32 _nameSearchType;
        // 2009/12/02 Add <<<

        // ---ADD 2010/08/06-------------------->>>
        /// <summary>�d�b�ԍ�</summary>
        private string _telNum = "";

        /// <summary>�d�b�ԍ������^�C�v</summary>
        /// <remarks>0:�O����v����,1:�B������</remarks>
        private Int32 _telNumSearchType;
        // ---ADD 2010/08/06--------------------<<<
        // ---ADD 2010/08/06--------------------<<<
       
        // 2011/7/22 XUJS ADD STA>>>>>>
        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";
        /// <summary>���Ӑ旪�̌����^�C�v</summary>
        /// <remarks>0:�O����v����,1:�B������</remarks>
        private Int32 _customerSnmSearchType;
        // 2011/7/22 XUJS ADD END<<<<<<

        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
        private Int32 _pccuoeMode;
        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<

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

		/// public propaty name  :  CustomerSubCode
		/// <summary>���Ӑ�T�u�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�T�u�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerSubCode
		{
			get { return _customerSubCode; }
			set { _customerSubCode = value; }
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

		/// public propaty name  :  SearchTelNo
		/// <summary>�d�b�ԍ��i�����p��4���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i�����p��4���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SearchTelNo
		{
			get { return _searchTelNo; }
			set { _searchTelNo = value; }
		}

		/// public propaty name  :  AcceptWholeSale
		/// <summary>�Ɣ̐�敪�v���p�e�B</summary>
		/// <value>0:�Ɣ̐�ȊO,1:�Ɣ̐� -1:�Ɣ̐������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Ɣ̐�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcceptWholeSale
		{
			get { return _acceptWholeSale; }
			set { _acceptWholeSale = value; }
		}

		/// public propaty name  :  CustomerSubCodeSearchType
		/// <summary>���Ӑ�T�u�R�[�h�����^�C�v�v���p�e�B</summary>
		/// <value>0:�O����v����,1:�B������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�T�u�R�[�h�����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerSubCodeSearchType
		{
			get { return _customerSubCodeSearchType; }
			set { _customerSubCodeSearchType = value; }
		}

		/// public propaty name  :  KanaSearchType
		/// <summary>���Ӑ�J�i�����^�C�v�v���p�e�B</summary>
		/// <value>0:�O����v����,1:�B������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�J�i�����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 KanaSearchType
		{
			get { return _kanaSearchType; }
			set { _kanaSearchType = value; }
		}

		/// public propaty name  :  CustAnalysCode1
		/// <summary>���Ӑ敪�̓R�[�h�P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ敪�̓R�[�h�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustAnalysCode1
		{
			get { return _custAnalysCode1; }
			set { _custAnalysCode1 = value; }
		}

		/// public propaty name  :  CustAnalysCode2
		/// <summary>���Ӑ敪�̓R�[�h�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ敪�̓R�[�h�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustAnalysCode2
		{
			get { return _custAnalysCode2; }
			set { _custAnalysCode2 = value; }
		}

		/// public propaty name  :  CustAnalysCode3
		/// <summary>���Ӑ敪�̓R�[�h�R�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ敪�̓R�[�h�R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustAnalysCode3
		{
			get { return _custAnalysCode3; }
			set { _custAnalysCode3 = value; }
		}

		/// public propaty name  :  CustAnalysCode4
		/// <summary>���Ӑ敪�̓R�[�h�S�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ敪�̓R�[�h�S�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustAnalysCode4
		{
			get { return _custAnalysCode4; }
			set { _custAnalysCode4 = value; }
		}

		/// public propaty name  :  CustAnalysCode5
		/// <summary>���Ӑ敪�̓R�[�h�T�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ敪�̓R�[�h�T�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustAnalysCode5
		{
			get { return _custAnalysCode5; }
			set { _custAnalysCode5 = value; }
		}

		/// public propaty name  :  CustAnalysCode6
		/// <summary>���Ӑ敪�̓R�[�h�U�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ敪�̓R�[�h�U�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustAnalysCode6
		{
			get { return _custAnalysCode6; }
			set { _custAnalysCode6 = value; }
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

		/// public propaty name  :  CustomerAgentNm
		/// <summary>�ڋq�S���]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڋq�S���]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CustomerAgentNm
		{
			get { return _customerAgentNm; }
			set { _customerAgentNm = value; }
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

		/// public propaty name  :  BillCollecterNm
		/// <summary>�W���S���]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �W���S���]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BillCollecterNm
		{
			get { return _billCollecterNm; }
			set { _billCollecterNm = value; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// public propaty name : MngSectionCode
        /// <summary>�Ǘ����_�R�[�h</summary>
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
        /// public propaty name : MngSectionName
        /// <summary>�Ǘ����_����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionName
        {
            get { return _mngSectionName; }
            set { _mngSectionName = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// public propaty name  :  LogicalDeleteDataPickUp
		/// <summary>�_���폜�f�[�^���o�t���O�v���p�e�B</summary>
		/// <value>0:���o���Ȃ� 1:���o����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�f�[�^���o�t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteDataPickUp
		{
			get { return _logicalDeleteDataPickUp; }
			set { _logicalDeleteDataPickUp = value; }
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

        // 2009/12/02 Add >>>
        /// public propaty name  :  Name
        /// <summary>���Ӑ於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  KanaSearchType
        /// <summary>���Ӑ於�����^�C�v�v���p�e�B</summary>
        /// <value>0:�O����v����,1:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NameSearchType
        {
            get { return _nameSearchType; }
            set { _nameSearchType = value; }
        }

        // 2009/12/02 Add <<<

        // ---ADD 2010/08/06-------------------->>>
        /// public propaty name  :  TelNum
        /// <summary>�d�b�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TelNum
        {
            get { return _telNum; }
            set { _telNum = value; }
        }

        /// public propaty name  :  TelNumSearchType
        /// <summary>�d�b�ԍ������^�C�v�v���p�e�B</summary>
        /// <value>0:�O����v����,1:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TelNumSearchType
        {
            get { return _telNumSearchType; }
            set { _telNumSearchType = value; }
        }
        // ---ADD 2010/08/06--------------------<<<

        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
        // 2011/7/22 XUJS ADD STA>>>>>>
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

        /// public propaty name  :  CustomerSnmSearchType
        /// <summary>���Ӑ旪�̌����^�C�v�v���p�e�B</summary>
        /// <value>0:�O����v����,1:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̌����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerSnmSearchType
        {
            get { return _customerSnmSearchType; }
            set { _customerSnmSearchType = value; }
        }
        // 2011/7/22 XUJS ADD END<<<<<<

        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
        /// public propaty name  :  PccuoeMode
        /// <summary>PCC���Зp�^�C�v���p�e�B</summary>
        /// <value>0:�ʏ�,1:PCC���Зp,2:PCC�}�X�����p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ������^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccuoeMode
        {
            get { return _pccuoeMode; }
            set { _pccuoeMode = value; }
        }
        //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<

		/// <summary>
		/// ���Ӑ挟�������p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>CustomerSearchPara�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerSearchPara()
		{
		}

		/// <summary>
		/// ���Ӑ挟�������p�����[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customerSubCode">���Ӑ�T�u�R�[�h</param>
		/// <param name="kana">�J�i</param>
		/// <param name="searchTelNo">�d�b�ԍ��i�����p��4���j</param>
		/// <param name="acceptWholeSale">�Ɣ̐�敪(0:�Ɣ̐�ȊO,1:�Ɣ̐�)</param>
		/// <param name="customerSubCodeSearchType">���Ӑ�T�u�R�[�h�����^�C�v(0:�O����v����,1:�B������)</param>
		/// <param name="kanaSearchType">���Ӑ�J�i�����^�C�v(0:�O����v����,1:�B������)</param>
		/// <param name="custAnalysCode1">���Ӑ敪�̓R�[�h�P</param>
		/// <param name="custAnalysCode2">���Ӑ敪�̓R�[�h�Q</param>
		/// <param name="custAnalysCode3">���Ӑ敪�̓R�[�h�R</param>
		/// <param name="custAnalysCode4">���Ӑ敪�̓R�[�h�S</param>
		/// <param name="custAnalysCode5">���Ӑ敪�̓R�[�h�T</param>
		/// <param name="custAnalysCode6">���Ӑ敪�̓R�[�h�U</param>
		/// <param name="customerAgentCd">�ڋq�S���]�ƈ��R�[�h(�����^)</param>
		/// <param name="customerAgentNm">�ڋq�S���]�ƈ�����</param>
		/// <param name="billCollecterCd">�W���S���]�ƈ��R�[�h</param>
		/// <param name="billCollecterNm">�W���S���]�ƈ�����</param>
		/// <param name="logicalDeleteDataPickUp">�_���폜�f�[�^���o�t���O(0:���o���Ȃ� 1:���o����)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="mngSectionCode">�Ǘ����_�R�[�h</param>
        /// <param name="mngSectionName">�Ǘ����_����</param>
        /// <param name="telNum">�d�b�ԍ�</param>
        /// <param name="telNumSearchType">�d�b�ԍ��B������</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="customerSnmSearchType">���Ӑ旪�̌����^�C�v</param>
        /// <param name="pccuoeMode">PCC���Зp�^�C�v</param>
		/// <returns>CustomerSearchPara�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchPara�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        // 2009/12/02 >>>
        //public CustomerSearchPara(string enterpriseCode, Int32 customerCode, string customerSubCode, string kana, string searchTelNo, Int32 acceptWholeSale, Int32 customerSubCodeSearchType, Int32 kanaSearchType, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, Int32 logicalDeleteDataPickUp, string enterpriseName, string mngSectionCode, string mngSectionName)
        // ---UPD 2010/08/06-------------------->>>
        //public CustomerSearchPara(string enterpriseCode, Int32 customerCode, string customerSubCode, string kana, string searchTelNo, Int32 acceptWholeSale, Int32 customerSubCodeSearchType, Int32 kanaSearchType, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, Int32 logicalDeleteDataPickUp, string enterpriseName, string mngSectionCode, string mngSectionName, string name, Int32 nameSearchType)
        //public CustomerSearchPara(string enterpriseCode, Int32 customerCode, string customerSubCode, string kana, string searchTelNo, Int32 acceptWholeSale, Int32 customerSubCodeSearchType, Int32 kanaSearchType, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, Int32 logicalDeleteDataPickUp, string enterpriseName, string mngSectionCode, string mngSectionName, string name, Int32 nameSearchType, string telNum, Int32 telNumSearchType) //-----DEL PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 
        // ---UPD 2010/08/06--------------------<<<
        public CustomerSearchPara(string enterpriseCode, Int32 customerCode, string customerSubCode, string kana, string searchTelNo, Int32 acceptWholeSale, Int32 customerSubCodeSearchType, Int32 kanaSearchType, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, string customerAgentCd, string customerAgentNm, string billCollecterCd, string billCollecterNm, Int32 logicalDeleteDataPickUp, string enterpriseName, string mngSectionCode, string mngSectionName, string name, Int32 nameSearchType, string telNum, Int32 telNumSearchType, String customerSnm, Int32 customerSnmSearchType, int pccuoeMode)  //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 
        // 2009/12/02 <<<
        {
            this._enterpriseCode = enterpriseCode;
            this._customerCode = customerCode;
            this._customerSubCode = customerSubCode;
            this._kana = kana;
            this._searchTelNo = searchTelNo;
            this._acceptWholeSale = acceptWholeSale;
            this._customerSubCodeSearchType = customerSubCodeSearchType;
            this._kanaSearchType = kanaSearchType;
            this._custAnalysCode1 = custAnalysCode1;
            this._custAnalysCode2 = custAnalysCode2;
            this._custAnalysCode3 = custAnalysCode3;
            this._custAnalysCode4 = custAnalysCode4;
            this._custAnalysCode5 = custAnalysCode5;
            this._custAnalysCode6 = custAnalysCode6;
            this._customerAgentCd = customerAgentCd;
            this._customerAgentNm = customerAgentNm;
            this._billCollecterCd = billCollecterCd;
            this._billCollecterNm = billCollecterNm;
            this._logicalDeleteDataPickUp = logicalDeleteDataPickUp;
            this._enterpriseName = enterpriseName;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._mngSectionCode = mngSectionCode;
            this._mngSectionName = mngSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            this._name = name;
            this._nameSearchType = nameSearchType;
            // 2009/12/02 Add <<<

            // ---ADD 2010/08/06-------------------->>>
            this._telNum = telNum;
            this._telNumSearchType = telNumSearchType;
            // ---ADD 2010/08/06--------------------<<<
            // 2011/7/22 XUJS ADD STA>>>>>>
            this._customerSnm = customerSnm;
            this._customerSnmSearchType = customerSnmSearchType;
            // 2011/7/22 XUJS ADD END<<<<<<\
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
            this._pccuoeMode = pccuoeMode;
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
            
        }

		/// <summary>
		/// ���Ӑ挟�������p�����[�^�N���X��������
		/// </summary>
		/// <returns>CustomerSearchPara�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustomerSearchPara�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public CustomerSearchPara Clone()
		{
            // 2009/12/02 >>>
            //return new CustomerSearchPara(this._enterpriseCode, this._customerCode, this._customerSubCode, this._kana, this._searchTelNo, this._acceptWholeSale, this._customerSubCodeSearchType, this._kanaSearchType, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._logicalDeleteDataPickUp, this._enterpriseName, this._mngSectionCode, this._mngSectionName);
            // ---UPD 2010/08/06-------------------->>>
            //return new CustomerSearchPara(this._enterpriseCode, this._customerCode, this._customerSubCode, this._kana, this._searchTelNo, this._acceptWholeSale, this._customerSubCodeSearchType, this._kanaSearchType, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._logicalDeleteDataPickUp, this._enterpriseName, this._mngSectionCode, this._mngSectionName, this._name, this._nameSearchType);
            //return new CustomerSearchPara(this._enterpriseCode, this._customerCode, this._customerSubCode, this._kana, this._searchTelNo, this._acceptWholeSale, this._customerSubCodeSearchType, this._kanaSearchType, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._logicalDeleteDataPickUp, this._enterpriseName, this._mngSectionCode, this._mngSectionName, this._name, this._nameSearchType, this._telNum, this._telNumSearchType);//-----DEL PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 
            // ---UPD 2010/08/06--------------------<<<
            return new CustomerSearchPara(this._enterpriseCode, this._customerCode, this._customerSubCode, this._kana, this._searchTelNo, this._acceptWholeSale, this._customerSubCodeSearchType, this._kanaSearchType, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._billCollecterNm, this._logicalDeleteDataPickUp, this._enterpriseName, this._mngSectionCode, this._mngSectionName, this._name, this._nameSearchType, this._telNum, this._telNumSearchType, this._customerSnm, this._customerSnmSearchType, this._pccuoeMode);//-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 
            
            // 2009/12/02 <<<
        }

		/// <summary>
		/// ���Ӑ挟�������p�����[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustomerSearchPara�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchPara�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(CustomerSearchPara target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerSubCode == target.CustomerSubCode)
				 && (this.Kana == target.Kana)
				 && (this.SearchTelNo == target.SearchTelNo)
				 && (this.AcceptWholeSale == target.AcceptWholeSale)
				 && (this.CustomerSubCodeSearchType == target.CustomerSubCodeSearchType)
				 && (this.KanaSearchType == target.KanaSearchType)
				 && (this.CustAnalysCode1 == target.CustAnalysCode1)
				 && (this.CustAnalysCode2 == target.CustAnalysCode2)
				 && (this.CustAnalysCode3 == target.CustAnalysCode3)
				 && (this.CustAnalysCode4 == target.CustAnalysCode4)
				 && (this.CustAnalysCode5 == target.CustAnalysCode5)
				 && (this.CustAnalysCode6 == target.CustAnalysCode6)
				 && (this.CustomerAgentCd == target.CustomerAgentCd)
				 && (this.CustomerAgentNm == target.CustomerAgentNm)
				 && (this.BillCollecterCd == target.BillCollecterCd)
				 && (this.BillCollecterNm == target.BillCollecterNm)
				 && (this.LogicalDeleteDataPickUp == target.LogicalDeleteDataPickUp)
				 && (this.EnterpriseName == target.EnterpriseName)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (this.MngSectionCode == target.MngSectionCode)
                 && (this.MngSectionName == target.MngSectionName)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                 // 2009/12/02 Add >>>
                 &&(this.Name==target.Name)
                 &&(this.NameSearchType==target.NameSearchType)
                 // 2009/12/02 Add <<<

                 // ---ADD 2010/08/06-------------------->>>
                 && (this.TelNum == target.TelNum)
                 && (this.TelNumSearchType == target.TelNumSearchType)
                 // ---ADD 2010/08/06--------------------<<<
                //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.CustomerSnmSearchType == target.CustomerSnmSearchType)
                 && (this.PccuoeMode == target.PccuoeMode)
                //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
                 );
		}

		/// <summary>
		/// ���Ӑ挟�������p�����[�^�N���X��r����
		/// </summary>
		/// <param name="customerSearchPara1">
		///                    ��r����CustomerSearchPara�N���X�̃C���X�^���X
		/// </param>
		/// <param name="customerSearchPara2">��r����CustomerSearchPara�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchPara�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(CustomerSearchPara customerSearchPara1, CustomerSearchPara customerSearchPara2)
		{
			return ((customerSearchPara1.EnterpriseCode == customerSearchPara2.EnterpriseCode)
				 && (customerSearchPara1.CustomerCode == customerSearchPara2.CustomerCode)
				 && (customerSearchPara1.CustomerSubCode == customerSearchPara2.CustomerSubCode)
				 && (customerSearchPara1.Kana == customerSearchPara2.Kana)
				 && (customerSearchPara1.SearchTelNo == customerSearchPara2.SearchTelNo)
				 && (customerSearchPara1.AcceptWholeSale == customerSearchPara2.AcceptWholeSale)
				 && (customerSearchPara1.CustomerSubCodeSearchType == customerSearchPara2.CustomerSubCodeSearchType)
				 && (customerSearchPara1.KanaSearchType == customerSearchPara2.KanaSearchType)
				 && (customerSearchPara1.CustAnalysCode1 == customerSearchPara2.CustAnalysCode1)
				 && (customerSearchPara1.CustAnalysCode2 == customerSearchPara2.CustAnalysCode2)
				 && (customerSearchPara1.CustAnalysCode3 == customerSearchPara2.CustAnalysCode3)
				 && (customerSearchPara1.CustAnalysCode4 == customerSearchPara2.CustAnalysCode4)
				 && (customerSearchPara1.CustAnalysCode5 == customerSearchPara2.CustAnalysCode5)
				 && (customerSearchPara1.CustAnalysCode6 == customerSearchPara2.CustAnalysCode6)
				 && (customerSearchPara1.CustomerAgentCd == customerSearchPara2.CustomerAgentCd)
				 && (customerSearchPara1.CustomerAgentNm == customerSearchPara2.CustomerAgentNm)
				 && (customerSearchPara1.BillCollecterCd == customerSearchPara2.BillCollecterCd)
				 && (customerSearchPara1.BillCollecterNm == customerSearchPara2.BillCollecterNm)
				 && (customerSearchPara1.LogicalDeleteDataPickUp == customerSearchPara2.LogicalDeleteDataPickUp)
				 && (customerSearchPara1.EnterpriseName == customerSearchPara2.EnterpriseName)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (customerSearchPara1.MngSectionCode == customerSearchPara2.MngSectionCode)
                 && (customerSearchPara1.MngSectionName == customerSearchPara2.MngSectionName)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                 // 2009/12/02 Add >>>
                 &&(customerSearchPara1.Name==customerSearchPara1.Name)
                 &&(customerSearchPara1.NameSearchType==customerSearchPara1.NameSearchType)
                 // 2009/12/02 Add <<<
                //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
                 && (customerSearchPara1.CustomerSnm == customerSearchPara1.CustomerSnm)
                  && (customerSearchPara1.CustomerSnmSearchType == customerSearchPara1.CustomerSnmSearchType)
                 && (customerSearchPara1.PccuoeMode == customerSearchPara1.PccuoeMode)
                //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
                 );
		}
		/// <summary>
		/// ���Ӑ挟�������p�����[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustomerSearchPara�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchPara�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public ArrayList Compare(CustomerSearchPara target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
			if (this.CustomerSubCode != target.CustomerSubCode) resList.Add("CustomerSubCode");
			if (this.Kana != target.Kana) resList.Add("Kana");
			if (this.SearchTelNo != target.SearchTelNo) resList.Add("SearchTelNo");
			if (this.AcceptWholeSale != target.AcceptWholeSale) resList.Add("AcceptWholeSale");
			if (this.CustomerSubCodeSearchType != target.CustomerSubCodeSearchType) resList.Add("CustomerSubCodeSearchType");
			if (this.KanaSearchType != target.KanaSearchType) resList.Add("KanaSearchType");
			if (this.CustAnalysCode1 != target.CustAnalysCode1) resList.Add("CustAnalysCode1");
			if (this.CustAnalysCode2 != target.CustAnalysCode2) resList.Add("CustAnalysCode2");
			if (this.CustAnalysCode3 != target.CustAnalysCode3) resList.Add("CustAnalysCode3");
			if (this.CustAnalysCode4 != target.CustAnalysCode4) resList.Add("CustAnalysCode4");
			if (this.CustAnalysCode5 != target.CustAnalysCode5) resList.Add("CustAnalysCode5");
			if (this.CustAnalysCode6 != target.CustAnalysCode6) resList.Add("CustAnalysCode6");
			if (this.CustomerAgentCd != target.CustomerAgentCd) resList.Add("CustomerAgentCd");
			if (this.CustomerAgentNm != target.CustomerAgentNm) resList.Add("CustomerAgentNm");
			if (this.BillCollecterCd != target.BillCollecterCd) resList.Add("BillCollecterCd");
			if (this.BillCollecterNm != target.BillCollecterNm) resList.Add("BillCollecterNm");
			if (this.LogicalDeleteDataPickUp != target.LogicalDeleteDataPickUp) resList.Add("LogicalDeleteDataPickUp");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( this.MngSectionCode != target.MngSectionCode ) resList.Add( "MngSectionCode" );
            if ( this.MngSectionName != target.MngSectionName ) resList.Add( "MngSectionName" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            if (this.Name != target.Name) resList.Add("Name");
            if (this.NameSearchType != target.NameSearchType) resList.Add("NameSearchType");
            // 2009/12/02 Add <<<
            // ---ADD 2010/08/06-------------------->>>
            if (this.TelNum != target.TelNum)
            {
                resList.Add("TelNum");
            }
            if (this.TelNumSearchType != target.TelNumSearchType)
            {
                resList.Add("TelNumSearchType");
            }
            // ---ADD 2010/08/06--------------------<<<

            // 2011/7/22 XUJS ADD STA>>>>>>
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.CustomerSnmSearchType != target.CustomerSnmSearchType) resList.Add("CustomerSnmSearchType");
			// 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
            if (this.PccuoeMode != target.PccuoeMode) resList.Add("PccuoeMode");
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
            
			return resList;
		}

		/// <summary>
		/// ���Ӑ挟�������p�����[�^�N���X��r����
		/// </summary>
		/// <param name="customerSearchPara1">��r����CustomerSearchPara�N���X�̃C���X�^���X</param>
		/// <param name="customerSearchPara2">��r����CustomerSearchPara�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchPara�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 ���юR</br>
        /// <br>             PM1107C:���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public static ArrayList Compare(CustomerSearchPara customerSearchPara1, CustomerSearchPara customerSearchPara2)
		{
			ArrayList resList = new ArrayList();
			if (customerSearchPara1.EnterpriseCode != customerSearchPara2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (customerSearchPara1.CustomerCode != customerSearchPara2.CustomerCode) resList.Add("CustomerCode");
			if (customerSearchPara1.CustomerSubCode != customerSearchPara2.CustomerSubCode) resList.Add("CustomerSubCode");
			if (customerSearchPara1.Kana != customerSearchPara2.Kana) resList.Add("Kana");
			if (customerSearchPara1.SearchTelNo != customerSearchPara2.SearchTelNo) resList.Add("SearchTelNo");
			if (customerSearchPara1.AcceptWholeSale != customerSearchPara2.AcceptWholeSale) resList.Add("AcceptWholeSale");
			if (customerSearchPara1.CustomerSubCodeSearchType != customerSearchPara2.CustomerSubCodeSearchType) resList.Add("CustomerSubCodeSearchType");
			if (customerSearchPara1.KanaSearchType != customerSearchPara2.KanaSearchType) resList.Add("KanaSearchType");
			if (customerSearchPara1.CustAnalysCode1 != customerSearchPara2.CustAnalysCode1) resList.Add("CustAnalysCode1");
			if (customerSearchPara1.CustAnalysCode2 != customerSearchPara2.CustAnalysCode2) resList.Add("CustAnalysCode2");
			if (customerSearchPara1.CustAnalysCode3 != customerSearchPara2.CustAnalysCode3) resList.Add("CustAnalysCode3");
			if (customerSearchPara1.CustAnalysCode4 != customerSearchPara2.CustAnalysCode4) resList.Add("CustAnalysCode4");
			if (customerSearchPara1.CustAnalysCode5 != customerSearchPara2.CustAnalysCode5) resList.Add("CustAnalysCode5");
			if (customerSearchPara1.CustAnalysCode6 != customerSearchPara2.CustAnalysCode6) resList.Add("CustAnalysCode6");
			if (customerSearchPara1.CustomerAgentCd != customerSearchPara2.CustomerAgentCd) resList.Add("CustomerAgentCd");
			if (customerSearchPara1.CustomerAgentNm != customerSearchPara2.CustomerAgentNm) resList.Add("CustomerAgentNm");
			if (customerSearchPara1.BillCollecterCd != customerSearchPara2.BillCollecterCd) resList.Add("BillCollecterCd");
			if (customerSearchPara1.BillCollecterNm != customerSearchPara2.BillCollecterNm) resList.Add("BillCollecterNm");
			if (customerSearchPara1.LogicalDeleteDataPickUp != customerSearchPara2.LogicalDeleteDataPickUp) resList.Add("LogicalDeleteDataPickUp");
			if (customerSearchPara1.EnterpriseName != customerSearchPara2.EnterpriseName) resList.Add("EnterpriseName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( customerSearchPara1.MngSectionCode != customerSearchPara2.MngSectionCode ) resList.Add( "MngSectionCode" );
            if ( customerSearchPara1.MngSectionName != customerSearchPara2.MngSectionName ) resList.Add( "MngSectionName" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            if (customerSearchPara1.Name != customerSearchPara2.Name) resList.Add("Name");
            if (customerSearchPara1.NameSearchType != customerSearchPara2.NameSearchType) resList.Add("NameSearchType");
            // 2009/12/02 Add <<<
            // 2011/7/22 XUJS ADD STA>>>>>>
            if (customerSearchPara1.CustomerSnm != customerSearchPara2.CustomerSnm) resList.Add("CustomerSnm");
            if (customerSearchPara1.CustomerSnmSearchType != customerSearchPara2.CustomerSnmSearchType) resList.Add("CustomerSnmSearchType");
            // 2011/7/22 XUJS ADD END<<<<<<
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
            if (customerSearchPara1.PccuoeMode != customerSearchPara2.PccuoeMode) resList.Add("PccuoeMode");
            //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
            
			return resList;
		}
	}
}
