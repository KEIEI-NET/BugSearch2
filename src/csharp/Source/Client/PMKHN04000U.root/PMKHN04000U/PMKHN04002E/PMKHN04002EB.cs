//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ挟��
// �v���O�����T�v   �F���Ӑ�̌������s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22018 ��� ���b
// �C����    2008/05/07     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30452 ��� �r��
// �C����    2008/09/04     �C�����e�F�X�V������ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30452 ��� �r��
// �C����    2009/02/12     �C�����e�F���Ӑ�`�[�ԍ��敪��ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/08     �C�����e�FSCM�I�v�V�������ڒǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/19     �C�����e�FSCM�I�v�V�������ڒǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10504551-00    �쐬�S���F30517 �Ė� �x��
// �C����    2009/12/02     �C�����e�FMANTIS:14721 ���Ӑ挟�����ʂ̕\�����ڂɎ���FAX�ƋΖ���FAX��ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10601193-00    �쐬�S���F21024 ���X�� ��
// �C����    2010/04/06     �C�����e�F�I�����C����ʋ敪 �ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10601193-00    �쐬�S���F30434 �H�� �b�D
// �C����    2010/06/26     �C�����e�F�ȒP�⍇���A�J�E���g�O���[�vID �ǉ�
// ---------------------------------------------------------------------//
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22024 ���� �_�u
// �C����    2012.04.10     �C�����e�F�ڋq�S���]�ƈ����� �ǉ�
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerSearchRet
	/// <summary>
	///                      ���Ӑ挟�����ʃN���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ӑ挟�����ʃN���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/02/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      : 2008.09.04 30452 ��� �r��</br>
    /// <br>                   �X�V������ǉ�</br>
    /// <br>Update Note      : 2009.02.12 30452 ��� �r��</br>
    /// <br>                   ���Ӑ�`�[�ԍ��敪��ǉ�</br>
    /// <br>Update Note      : 2009/12/02 30517 �Ė� �x��</br>
    /// <br>                   MANTIS:14721 ���Ӑ挟�����ʂ̕\�����ڂɎ���FAX�ƋΖ���FAX��ǉ�</br>
    /// <br>Update Note      : 2010/04/06 21024 ���X�� ��</br>
    /// <br>                   �I�����C����ʋ敪 �ǉ�</br>
    /// <br>Update Note      : 2010/06/26 30434 �H�� �b�D</br>
    /// <br>                   �ȒP�⍇���A�J�E���g�O���[�vID �ǉ�</br>
	/// <br>Update Note      : 2012.04.10 22024 ���� �_�u</br>
	/// <br>                   �ڋq�S���]�ƈ����� �ǉ�</br>
	/// </remarks>
	[Serializable]	
	public class CustomerSearchRet
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>���Ӑ�T�u�R�[�h</summary>
		private string _customerSubCode = "";

		/// <summary>����</summary>
		private string _name = "";

		/// <summary>���̂Q</summary>
		private string _name2 = "";

        /// <summary>����</summary>
        private string _snm = "";

		/// <summary>�J�i</summary>
		private string _kana = "";

		/// <summary>�h��</summary>
		private string _honorificTitle = "";

		/// <summary>�d�b�ԍ��i�����p��4���j</summary>
		private string _searchTelNo = "";

		/// <summary>�d�b�ԍ��i����j</summary>
		/// <remarks>�n�C�t�����܂߂�16���̔ԍ�</remarks>
		private string _homeTelNo = "";

		/// <summary>�d�b�ԍ��i�Ζ���j</summary>
		private string _officeTelNo = "";

		/// <summary>�d�b�ԍ��i�g�сj</summary>
		private string _portableTelNo = "";

		/// <summary>�X�֔ԍ�</summary>
		private string _postNo = "";

		/// <summary>�Z���P�i�s���{���s��S�E�����E���j</summary>
		private string _address1 = "";

		/// <summary>�Z���R�i�Ԓn�j</summary>
		private string _address3 = "";

		/// <summary>�Z���S�i�A�p�[�g���́j</summary>
		private string _address4 = "";

		/// <summary>����</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>���Ӑ�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�Ɣ̐�敪</summary>
		/// <remarks>0:�Ɣ̐�ȊO,1:�Ɣ̐�</remarks>
		private Int32 _acceptWholeSale;

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // --- ADD 2009/02/12 -------------------------------->>>>>
        /// <summary>���Ӑ�`�[�ԍ��敪</summary>
        private Int32 _customerSlipNoDiv;
        // --- ADD 2009/02/12 --------------------------------<<<<<

        // ADD 2009/06/08 ------>>>
        /// <summary>���Ӑ��ƃR�[�h</summary>
        private string _customerEpCode = string.Empty;

        /// <summary>���Ӑ拒�_�R�[�h</summary>
        private string _customerSecCode = string.Empty;
        // ADD 2009/06/08 ------<<<

        // --- ADD 2009/06/19 -------------------------------->>>>>
        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        private string _customerAgentCd;
        // --- ADD 2009/06/19 --------------------------------<<<<<

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        /// <summary>�ڋq�S���]�ƈ�����</summary>
        private string _customerAgentNm;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// <summary>�X�V���t</summary>
        private DateTime _updateDate;
        // --- ADD 2008/09/04 --------------------------------<<<<<

        // 2009/12/02 Add >>>
        /// <summary>FAX�ԍ��i����j</summary>
        /// <remarks>�n�C�t�����܂߂�16���̔ԍ�</remarks>
        private string _homeFaxNo = "";

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        private string _officeFaxNo = "";
        // 2009/12/02 Add <<<

        // 2010/04/06 Add >>>
        /// <summary>�I�����C����ʋ敪</summary>
        private int _onlineKindDiv;
        // 2010/04/06 Add <<<

        // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
        /// <summary>�ȒP�⍇���A�J�E���g�O���[�vID</summary>
        /// <remarks>(���p�p��)</remarks>
        private string _simplInqAcntAcntGrId;
        // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<

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
		/// <summary>���̂Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���̂Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name2
		{
			get { return _name2; }
			set { _name2 = value; }
		}

        /// public propaty name  :  Snm
        /// <summary>���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Snm
        {
            get { return _snm; }
            set { _snm = value; }
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

		/// public propaty name  :  HonorificTitle
		/// <summary>�h�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �h�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string HonorificTitle
		{
			get { return _honorificTitle; }
			set { _honorificTitle = value; }
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

		/// public propaty name  :  HomeTelNo
		/// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
		/// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string HomeTelNo
		{
			get { return _homeTelNo; }
			set { _homeTelNo = value; }
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
		/// <summary>�Z���P�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z���P�i�s���{���s��S�E�����E���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address1
		{
			get { return _address1; }
			set { _address1 = value; }
		}

		/// public propaty name  :  Address3
		/// <summary>�Z���R�i�Ԓn�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z���R�i�Ԓn�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address3
		{
			get { return _address3; }
			set { _address3 = value; }
		}

		/// public propaty name  :  Address4
		/// <summary>�Z���S�i�A�p�[�g���́j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z���S�i�A�p�[�g���́j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address4
		{
			get { return _address4; }
			set { _address4 = value; }
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

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>���Ӑ�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
		}

        /// public propaty name  :  AcceptWholeSale
		/// <summary>�Ɣ̐�敪�v���p�e�B</summary>
		/// <value>0:�Ɣ̐�ȊO,1:�Ɣ̐�</value>
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // --- ADD 2008/09/04 -------------------------------->>>>>
        /// public propaty name  :  UpdateDate
        /// <summary>�X�V���t</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���t</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        // --- ADD 2008/09/04 --------------------------------<<<<<

        // 2009/12/02 Add >>>
        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX�ԍ��i����j�v���p�e�B</summary>
        /// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
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
        // 2009/12/02 Add <<<

        // --- ADD 2009/02/12 -------------------------------->>>>>
        /// public propaty name  :  CustomerSlipNoDiv
        /// <summary>���Ӑ�`�[�ԍ��敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���t</br>
        /// </remarks>
        public Int32 CustomerSlipNoDiv
        {
            get { return _customerSlipNoDiv; }
            set { _customerSlipNoDiv = value; }
        }
        // --- ADD 2009/02/12 --------------------------------<<<<<

        // ADD 2009/06/08 ------>>>
        /// public propaty name  :  CustomerEpCode
        /// <summary>���Ӑ��ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerEpCode
        {
            get { return _customerEpCode; }
            set { _customerEpCode = value; }
        }

        /// public propaty name  :  CustomerSecCode
        /// <summary>���Ӑ拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSecCode
        {
            get { return _customerSecCode; }
            set { _customerSecCode = value; }
        }
        // ADD 2009/06/08 ------<<<

        // --- ADD 2009/06/19 -------------------------------->>>>>
        /// public propaty name  :  CustomerAgentCd
        /// <summary>�ڋq�S���]�ƈ��R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ��R�[�h</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }
        // --- ADD 2009/06/19 --------------------------------<<<<<

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        /// public propaty name  :  CustomerAgentNm
        /// <summary>�ڋq�S���]�ƈ�����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڋq�S���]�ƈ�����</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        // 2010/04/06 Add >>>
        /// public propaty name  :  OnlineKindDiv
        /// <summary>�I�����C����ʋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����C����ʋ敪�v���p�e�B</br>
        /// <br>Programer        :   21024 ���X�� ��</br>
        /// </remarks>
        public int OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }
        // 2010/04/06 Add <<<
        // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
        /// public propaty name  :  SimplInqAcntAcntGrId
        /// <summary>�ȒP�⍇���A�J�E���g�O���[�vID</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ȒP�⍇���A�J�E���g�O���[�vID�v���p�e�B</br>
        /// <br>Programer        :   30434 �H��</br>
        /// </remarks>
        public string SimplInqAcntAcntGrId
        {
            get { return _simplInqAcntAcntGrId; }
            set { _simplInqAcntAcntGrId = value; }
        }
        // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<

		/// <summary>
		/// ���Ӑ挟�����ʃN���X�R���X�g���N�^
		/// </summary>
		/// <returns>CustomerSearchRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerSearchRet()
		{
		}

		/// <summary>
		/// ���Ӑ挟�����ʃN���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="customerSubCode">���Ӑ�T�u�R�[�h</param>
		/// <param name="name">����</param>
		/// <param name="name2">���̂Q</param>
        /// <param name="snm">����</param>
		/// <param name="kana">�J�i</param>
		/// <param name="honorificTitle">�h��</param>
		/// <param name="searchTelNo">�d�b�ԍ��i�����p��4���j</param>
		/// <param name="homeTelNo">�d�b�ԍ��i����j(�n�C�t�����܂߂�16���̔ԍ�)</param>
		/// <param name="officeTelNo">�d�b�ԍ��i�Ζ���j</param>
		/// <param name="portableTelNo">�d�b�ԍ��i�g�сj</param>
		/// <param name="postNo">�X�֔ԍ�</param>
		/// <param name="address1">�Z���P�i�s���{���s��S�E�����E���j</param>
		/// <param name="address3">�Z���R�i�Ԓn�j</param>
		/// <param name="address4">�Z���S�i�A�p�[�g���́j</param>
		/// <param name="totalDay">����(DD)</param>
		/// <param name="logicalDeleteCode">���Ӑ�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="acceptWholeSale">�Ɣ̐�敪(0:�Ɣ̐�ȊO,1:�Ɣ̐�)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="mngSectionCode">�Ǘ����_�R�[�h</param>
        /// <param name="customerEpCode">���Ӑ��ƃR�[�h</param>
        /// <param name="customerSecCode">���Ӑ拒�_�R�[�h</param>
		/// <param name="customerAgentCd">�ڋq�S���]�ƈ��R�[�h</param>
		/// <param name="customerAgentNm">�ڋq�S���]�ƈ�����</param>
        /// <param name="updateDate">�X�V����</param>
		/// <returns>CustomerSearchRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchRet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        // 2010/04/06 >>>
        //// 2009/06/19 >>>
        //////public CustomerSearchRet(string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, DateTime updateDate)
        ////// 2009/12/02 >>>
        //////public CustomerSearchRet(string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, DateTime updateDate)
        ////public CustomerSearchRet(string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, DateTime updateDate, string homeFaxNo, string OfficeFaxNo)
        ////// 2009/12/02 <<<
        //public CustomerSearchRet(string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, string customerAgentCd, DateTime updateDate, string homeFaxNo, string OfficeFaxNo)
        //// 2009/06/19 <<<

		#region 2012.04.10 TERASAKA DEL STA
//        public CustomerSearchRet(
//            string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, string customerAgentCd, DateTime updateDate, string homeFaxNo, string OfficeFaxNo, int onlineKindDiv
//            , string simplInqAcntAcntGrId  // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή�
//        )
		#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        public CustomerSearchRet(
			string enterpriseCode, Int32 customerCode, string customerSubCode, string name, string name2, string snm, string kana, string honorificTitle, string searchTelNo, string homeTelNo, string officeTelNo, string portableTelNo, string postNo, string address1, string address3, string address4, Int32 totalDay, Int32 logicalDeleteCode, Int32 acceptWholeSale, string enterpriseName, string mngSectionCode, string customerEpCode, string customerSecCode, string customerAgentCd, string customerAgentNm, DateTime updateDate, string homeFaxNo, string OfficeFaxNo, int onlineKindDiv
            , string simplInqAcntAcntGrId
        )
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        // 2010/04/06 <<<
        {
            this._enterpriseCode = enterpriseCode;
            this._customerCode = customerCode;
            this._customerSubCode = customerSubCode;
            this._name = name;
            this._name2 = name2;
            this._snm = snm;
            this._kana = kana;
            this._honorificTitle = honorificTitle;
            this._searchTelNo = searchTelNo;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;

            // 2009/12/02 Add >>>
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = OfficeFaxNo;
            // 2009/12/02 Add <<<

            this._postNo = postNo;
            this._address1 = address1;
            this._address3 = address3;
            this._address4 = address4;
            this._totalDay = totalDay;
            this._logicalDeleteCode = logicalDeleteCode;
            this._acceptWholeSale = acceptWholeSale;
            this._enterpriseName = enterpriseName;
            this._mngSectionCode = mngSectionCode;
            // ADD 2009/06/08 ------>>>
            this._customerEpCode = customerEpCode;
            this._customerSecCode = customerSecCode;
            // ADD 2009/06/08 ------<<<
            // --- ADD 2009/06/19 -------------------------------->>>>>
            this._customerAgentCd = customerAgentCd;
            // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            this._customerAgentNm = customerAgentNm;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // --- ADD 2008/09/04 -------------------------------->>>>>
            this._updateDate = updateDate;
            // --- ADD 2008/09/04 --------------------------------<<<<<

            this._onlineKindDiv = onlineKindDiv;    // 2010/04/06 Add
            // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
            this._simplInqAcntAcntGrId = simplInqAcntAcntGrId;
            // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<
        }

		/// <summary>
		/// ���Ӑ挟�����ʃN���X��������
		/// </summary>
		/// <returns>CustomerSearchRet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustomerSearchRet�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CustomerSearchRet Clone()
		{
            // 2010/04/06 >>>
            //// 2009/06/19 >>>
            //////return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1,  this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._updateDate);
            ////// 2009/12/02 >>>
            //////return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._updateDate);
            ////return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._updateDate, this._homeFaxNo, this._officeFaxNo);
            ////// 2009/12/02 <<<
            //return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._customerAgentCd, this._updateDate, this._homeFaxNo, this._officeFaxNo);
            //// 2009/06/19 <<<

			#region 2012.04.10 TERASAKA DEL STA
//            return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._customerAgentCd, this._updateDate, this._homeFaxNo, this._officeFaxNo, this._onlineKindDiv
//            , this._simplInqAcntAcntGrId    // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή�
//            );
//            // 2010/04/06 <<<
			#endregion
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			return new CustomerSearchRet(this._enterpriseCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._snm, this._kana, this._honorificTitle, this._searchTelNo, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._postNo, this._address1, this._address3, this._address4, this._totalDay, this._logicalDeleteCode, this._acceptWholeSale, this._enterpriseName, this._mngSectionCode, this._customerEpCode, this._customerSecCode, this._customerAgentCd, this._customerAgentNm, this._updateDate, this._homeFaxNo, this._officeFaxNo, this._onlineKindDiv
            , this._simplInqAcntAcntGrId
            );
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        }

		/// <summary>
		/// ���Ӑ挟�����ʃN���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustomerSearchRet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchRet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(CustomerSearchRet target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerSubCode == target.CustomerSubCode)
				 && (this.Name == target.Name)
				 && (this.Name2 == target.Name2)
                 && (this.Snm == target.Snm)
				 && (this.Kana == target.Kana)
				 && (this.HonorificTitle == target.HonorificTitle)
				 && (this.SearchTelNo == target.SearchTelNo)
				 && (this.HomeTelNo == target.HomeTelNo)
				 && (this.OfficeTelNo == target.OfficeTelNo)
				 && (this.PortableTelNo == target.PortableTelNo)
				 && (this.PostNo == target.PostNo)
				 && (this.Address1 == target.Address1)
				 && (this.Address3 == target.Address3)
				 && (this.Address4 == target.Address4)
				 && (this.TotalDay == target.TotalDay)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.AcceptWholeSale == target.AcceptWholeSale)
				 && (this.EnterpriseName == target.EnterpriseName)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (this.MngSectionCode == target.MngSectionCode)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                 // ADD 2009/06/08 ------>>>
                 && (this.CustomerEpCode == target.CustomerEpCode)
                 && (this.CustomerSecCode == target.CustomerSecCode)
                 // ADD 2009/06/08 ------<<<
                // --- ADD 2009/06/19 -------------------------------->>>>>
                 && ( this.CustomerAgentCd == target.CustomerAgentCd )
                // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
                 && ( this.CustomerAgentNm == target.CustomerAgentNm )
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
                // --- ADD 2008/09/04 -------------------------------->>>>>
                 && (this._updateDate == target.UpdateDate)
                 // --- ADD 2008/09/04 --------------------------------<<<<<
                 // 2009/12/02 Add >>>
                 && (this._homeFaxNo == target.HomeFaxNo)
                 && (this._officeFaxNo == target.OfficeFaxNo)
                 // 2009/12/02 Add <<<
                 && ( this._onlineKindDiv == target.OnlineKindDiv )     // 2010/04/06 Add
                 && (this._simplInqAcntAcntGrId == target.SimplInqAcntAcntGrId) // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή�
                 );
		}

		/// <summary>
		/// ���Ӑ挟�����ʃN���X��r����
		/// </summary>
		/// <param name="customerSearchRet1">
		///                    ��r����CustomerSearchRet�N���X�̃C���X�^���X
		/// </param>
		/// <param name="customerSearchRet2">��r����CustomerSearchRet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchRet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(CustomerSearchRet customerSearchRet1, CustomerSearchRet customerSearchRet2)
		{
			return ((customerSearchRet1.EnterpriseCode == customerSearchRet2.EnterpriseCode)
				 && (customerSearchRet1.CustomerCode == customerSearchRet2.CustomerCode)
				 && (customerSearchRet1.CustomerSubCode == customerSearchRet2.CustomerSubCode)
				 && (customerSearchRet1.Name == customerSearchRet2.Name)
				 && (customerSearchRet1.Name2 == customerSearchRet2.Name2)
                 && (customerSearchRet1.Snm == customerSearchRet2.Snm)
				 && (customerSearchRet1.Kana == customerSearchRet2.Kana)
				 && (customerSearchRet1.HonorificTitle == customerSearchRet2.HonorificTitle)
				 && (customerSearchRet1.SearchTelNo == customerSearchRet2.SearchTelNo)
				 && (customerSearchRet1.HomeTelNo == customerSearchRet2.HomeTelNo)
				 && (customerSearchRet1.OfficeTelNo == customerSearchRet2.OfficeTelNo)
				 && (customerSearchRet1.PortableTelNo == customerSearchRet2.PortableTelNo)
				 && (customerSearchRet1.PostNo == customerSearchRet2.PostNo)
				 && (customerSearchRet1.Address1 == customerSearchRet2.Address1)
				 && (customerSearchRet1.Address3 == customerSearchRet2.Address3)
				 && (customerSearchRet1.Address4 == customerSearchRet2.Address4)
				 && (customerSearchRet1.TotalDay == customerSearchRet2.TotalDay)
				 && (customerSearchRet1.LogicalDeleteCode == customerSearchRet2.LogicalDeleteCode)
				 && (customerSearchRet1.AcceptWholeSale == customerSearchRet2.AcceptWholeSale)
				 && (customerSearchRet1.EnterpriseName == customerSearchRet2.EnterpriseName)
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (customerSearchRet1.MngSectionCode == customerSearchRet2.MngSectionCode)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                 // ADD 2009/06/08 ------>>>
                 && (customerSearchRet1.CustomerEpCode == customerSearchRet2.CustomerEpCode)
                 && (customerSearchRet1.CustomerSecCode == customerSearchRet2.CustomerSecCode)
                 // ADD 2009/06/08 ------<<<
                // --- ADD 2009/06/19 -------------------------------->>>>>
                 && ( customerSearchRet1.CustomerAgentCd == customerSearchRet2.CustomerAgentCd )
                // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
                 && ( customerSearchRet1.CustomerAgentNm == customerSearchRet2.CustomerAgentNm )
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
                // --- ADD 2008/09/04 -------------------------------->>>>>
                 && (customerSearchRet1.UpdateDate == customerSearchRet2.UpdateDate)
                 // --- ADD 2008/09/04 --------------------------------<<<<<

                 // 2009/12/02 Add >>>
                 && (customerSearchRet1.HomeFaxNo == customerSearchRet2.HomeFaxNo)
                 && (customerSearchRet1.OfficeFaxNo == customerSearchRet2.OfficeFaxNo)
                 // 2009/12/02 Add <<<
                 && ( customerSearchRet1.OnlineKindDiv == customerSearchRet2.OnlineKindDiv )    // 2010/04/06 Add
                 && (customerSearchRet1.SimplInqAcntAcntGrId == customerSearchRet2.SimplInqAcntAcntGrId)    // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή�
                 );
		}
		/// <summary>
		/// ���Ӑ挟�����ʃN���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CustomerSearchRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchRet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(CustomerSearchRet target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
			if (this.CustomerSubCode != target.CustomerSubCode) resList.Add("CustomerSubCode");
			if (this.Name != target.Name) resList.Add("Name");
			if (this.Name2 != target.Name2) resList.Add("Name2");
            if (this.Snm != target.Snm) resList.Add( "Snm" );
			if (this.Kana != target.Kana) resList.Add("Kana");
			if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
			if (this.SearchTelNo != target.SearchTelNo) resList.Add("SearchTelNo");
			if (this.HomeTelNo != target.HomeTelNo) resList.Add("HomeTelNo");
			if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
			if (this.PortableTelNo != target.PortableTelNo) resList.Add("PortableTelNo");

            // 2009/12/02 Add >>>
            if (this.HomeFaxNo != target.HomeFaxNo) resList.Add("HomeFaxNo");
            if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
            // 2009/12/02 Add <<<

			if (this.PostNo != target.PostNo) resList.Add("PostNo");
			if (this.Address1 != target.Address1) resList.Add("Address1");
			if (this.Address3 != target.Address3) resList.Add("Address3");
			if (this.Address4 != target.Address4) resList.Add("Address4");
			if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.AcceptWholeSale != target.AcceptWholeSale) resList.Add("AcceptWholeSale");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( this.MngSectionCode != target.MngSectionCode ) resList.Add( "MngSectionCode" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // ADD 2009/06/08 ------>>>
            if (this.CustomerEpCode != target.CustomerEpCode) resList.Add("CustomerEpCode");
            if (this.CustomerSecCode != target.CustomerSecCode) resList.Add("CustomerSecCode");
            // ADD 2009/06/08 ------<<<
            // --- ADD 2009/06/19 -------------------------------->>>>>
            if (this.CustomerAgentCd != target.CustomerAgentCd) resList.Add("CustomerAgentCd");
            // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            if (this.CustomerAgentNm != target.CustomerAgentNm) resList.Add("CustomerAgentNm");
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // --- ADD 2008/09/04 -------------------------------->>>>>
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            // --- ADD 2008/09/04 --------------------------------<<<<<
            if (this.OnlineKindDiv != target.OnlineKindDiv) resList.Add("OnlineKindDiv");    // 2010/04/06 Add
            // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
            if (this.SimplInqAcntAcntGrId != target.SimplInqAcntAcntGrId) resList.Add("SimplInqAcntAcntGrId");
            // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<

			return resList;
		}

		/// <summary>
		/// ���Ӑ挟�����ʃN���X��r����
		/// </summary>
		/// <param name="customerSearchRet1">��r����CustomerSearchRet�N���X�̃C���X�^���X</param>
		/// <param name="customerSearchRet2">��r����CustomerSearchRet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CustomerSearchRet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(CustomerSearchRet customerSearchRet1, CustomerSearchRet customerSearchRet2)
		{
			ArrayList resList = new ArrayList();
			if (customerSearchRet1.EnterpriseCode != customerSearchRet2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (customerSearchRet1.CustomerCode != customerSearchRet2.CustomerCode) resList.Add("CustomerCode");
			if (customerSearchRet1.CustomerSubCode != customerSearchRet2.CustomerSubCode) resList.Add("CustomerSubCode");
			if (customerSearchRet1.Name != customerSearchRet2.Name) resList.Add("Name");
			if (customerSearchRet1.Name2 != customerSearchRet2.Name2) resList.Add("Name2");
            if (customerSearchRet1.Snm != customerSearchRet2.Snm) resList.Add( "Snm" );
			if (customerSearchRet1.Kana != customerSearchRet2.Kana) resList.Add("Kana");
			if (customerSearchRet1.HonorificTitle != customerSearchRet2.HonorificTitle) resList.Add("HonorificTitle");
			if (customerSearchRet1.SearchTelNo != customerSearchRet2.SearchTelNo) resList.Add("SearchTelNo");
			if (customerSearchRet1.HomeTelNo != customerSearchRet2.HomeTelNo) resList.Add("HomeTelNo");
			if (customerSearchRet1.OfficeTelNo != customerSearchRet2.OfficeTelNo) resList.Add("OfficeTelNo");

            // 2009/12/02 Add >>>
            if (customerSearchRet1.HomeFaxNo != customerSearchRet2.HomeFaxNo) resList.Add("HomeFaxNo");
            if (customerSearchRet1.OfficeFaxNo != customerSearchRet2.OfficeFaxNo) resList.Add("OfficeFaxNo");
            // 2009/12/02 Add <<<

			if (customerSearchRet1.PortableTelNo != customerSearchRet2.PortableTelNo) resList.Add("PortableTelNo");
			if (customerSearchRet1.PostNo != customerSearchRet2.PostNo) resList.Add("PostNo");
			if (customerSearchRet1.Address1 != customerSearchRet2.Address1) resList.Add("Address1");
			if (customerSearchRet1.Address3 != customerSearchRet2.Address3) resList.Add("Address3");
			if (customerSearchRet1.Address4 != customerSearchRet2.Address4) resList.Add("Address4");
			if (customerSearchRet1.TotalDay != customerSearchRet2.TotalDay) resList.Add("TotalDay");
			if (customerSearchRet1.LogicalDeleteCode != customerSearchRet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (customerSearchRet1.AcceptWholeSale != customerSearchRet2.AcceptWholeSale) resList.Add("AcceptWholeSale");
			if (customerSearchRet1.EnterpriseName != customerSearchRet2.EnterpriseName) resList.Add("EnterpriseName");
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            if ( customerSearchRet1.MngSectionCode != customerSearchRet2.MngSectionCode ) resList.Add( "MngSectionCode" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // ADD 2009/06/08 ------>>>
            if (customerSearchRet1.CustomerEpCode != customerSearchRet2.CustomerEpCode) resList.Add("CustomerEpCode");
            if (customerSearchRet1.CustomerSecCode != customerSearchRet2.CustomerSecCode) resList.Add("CustomerSecCode");
            // ADD 2009/06/08 ------<<<
            // --- ADD 2009/06/19 -------------------------------->>>>>
            if (customerSearchRet1.CustomerAgentCd != customerSearchRet2.CustomerAgentCd) resList.Add("CustomerAgentCd");
            // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
            if (customerSearchRet1.CustomerAgentNm != customerSearchRet2.CustomerAgentNm) resList.Add("CustomerAgentNm");
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // --- ADD 2008/09/04 -------------------------------->>>>>
            if (customerSearchRet1.UpdateDate != customerSearchRet2.UpdateDate) resList.Add("UpdateDate");
            // --- ADD 2008/09/04 --------------------------------<<<<<
            if (customerSearchRet1.OnlineKindDiv != customerSearchRet2.OnlineKindDiv) resList.Add("OnlineKindDiv");  // 2010/04/06 Add
            // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ---------->>>>>
            if (customerSearchRet1.SimplInqAcntAcntGrId != customerSearchRet2.SimplInqAcntAcntGrId) resList.Add("SimplInqAcntAcntGrId");
            // ADD 2010/06/26 SCM�FIDExchange�T�[�r�X�̕ύX�ɔ����Ή� ----------<<<<<
            
            return resList;
		}
	}
}
