using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// <summary>
	/// �󒍏o�׊m�F�\���o�����N���X
	/// </summary>
	/// <returns>ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X��Ԃ��܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>

	/// public class name:   ExtrInfo_DCHNB02013E
	/// <summary>
	///                      �󒍏o�׊m�F�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// �󒍏o�׊m�F�\���o�����N���X�w�b�_�t�@�C��
	/// </remarks>
	public class ExtrInfo_DCHNB02013E
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�S�БI��</summary>
		/// <remarks>true:�S�БI�� false:�e���_�I��</remarks>
		private Boolean _isSelectAllSection;

		/// <summary>�S���_���R�[�h�o��</summary>
		/// <remarks>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</remarks>
		private Boolean _isOutputAllSecRec;

		/// <summary>���ьv�㋒�_�R�[�h���X�g</summary>
		/// <remarks>�����^�@���z�񍀖�</remarks>
		private string[] _resultsAddUpSecList;

		/// <summary>�󒍃X�e�[�^�X[����]</summary>
		private Int32 _acptAnOdrStatus;

		/// <summary>����i�󒍁j���t(�J�n)</summary>
		private Int32 _salesDateSt;

		/// <summary>����i�󒍁j���t(�I��)</summary>
		private Int32 _salesDateEd;

		/// <summary>�o�ד��t(�J�n)</summary>
		private Int32 _shipmentDaySt;

		/// <summary>�o�ד��t(�I��)</summary>
		private Int32 _shipmentDayEd;

		/// <summary>���͓��t(�J�n)</summary>
		private Int32 _searchSlipDateSt;

		/// <summary>���͓��t(�I��)</summary>
		private Int32 _searchSlipDateEd;

		/// <summary>���Ӑ�R�[�h(�J�n)</summary>
		private Int32 _customerCodeSt;

		/// <summary>���Ӑ�R�[�h(�I��)</summary>
		private Int32 _customerCodeEd;

		/// <summary>�̔��]�ƈ��i�S���j�R�[�h(�J�n)</summary>
		private string _salesEmployeeCdSt = "";

		/// <summary>�̔��]�ƈ��i�S���j�R�[�h(�I��)</summary>
		private string _salesEmployeeCdEd = "";

		/// <summary>����`�[�ԍ�[�`�[]</summary>
		private string _salesSlipNum = "";

		/// <summary>�ԓ`�敪[����]</summary>
		private Int32 _debitNoteDiv;

		/// <summary>����`�[�敪[�`�[]</summary>
		/// <remarks>0:����,1:�ԕi</remarks>
		private Int32 _salesSlipCd;

		/// <summary>����`�[�敪[����]</summary>
		/// <remarks>0:����,1:�ԕi,2:�l��,9:�ꎮ</remarks>
		private Int32 _salesSlipCdDtl;

		/// <summary>�e���`�F�b�N����</summary>
		/// <remarks>�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckLower;

		/// <summary>�e���`�F�b�N�K��</summary>
		/// <remarks>�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckBest;

		/// <summary>�e���`�F�b�N���</summary>
		/// <remarks>�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�</remarks>
		private Double _grsProfitCheckUpper;

		/// <summary>�e���`�F�b�N2</summary>
		/// <remarks>�e���`�F�b�N2�@XX.X���@�ȏ�</remarks>
		private Double _grossMarginLow2;

		/// <summary>�e���`�F�b�N3</summary>
		/// <remarks>�e���`�F�b�N3�@XX.X���@�ȏ�</remarks>
		private Double _grossMarginBest2;

		/// <summary>�e���`�F�b�N4</summary>
		/// <remarks>�e���`�F�b�N4�@XX.X���@�ȏ�</remarks>
		private Double _grossMarginUpper2;

		/// <summary>�e���`�F�b�N�}�[�N1</summary>
		private string _grossMargin1Mark = "";

		/// <summary>�e���`�F�b�N�}�[�N2</summary>
		private string _grossMargin2Mark = "";

		/// <summary>�e���`�F�b�N�}�[�N3</summary>
		private string _grossMargin3Mark = "";

		/// <summary>�e���`�F�b�N�}�[�N4</summary>
		private string _grossMargin4Mark = "";

        /// <summary>���s�^�C�v</summary>
        /// <remarks>0:��,1:�󒍌v��ς�,2:�ݏo,3:�ݏo�v��ς�</remarks>
        private Int32 _publicationType;

        /// <summary>����</summary>
        private Int32 _newPageType;

		/// <summary>�o�͏�</summary>
		private Int32 _sortOrder;

		/// <summary>���[�^�C�v�敪</summary>
		/// <remarks>�i���[�̃}�X�����j�w�p�r�x���ڂƓ���</remarks>
		private Int32 _printDiv;

		/// <summary>���[�^�C�v�敪����</summary>
		private string _printDivName = "";

        // --- ADD 2009/03/30 -------------------------------->>>>>
        /// <summary>�����E�e���o��</summary>
        private Int32 _costOut;

        /// <summary>���v��</summary>
        private Int32 _printDailyFooter;
        // --- ADD 2009/03/30 --------------------------------<<<<<

        /// <summary>���� ���t�t�H�[�}�b�g</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

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

		/// public propaty name  :  IsSelectAllSection
		/// <summary>�S�БI���v���p�e�B</summary>
		/// <value>true:�S�БI�� false:�e���_�I��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S�БI���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean IsSelectAllSection
		{
			get { return _isSelectAllSection; }
			set { _isSelectAllSection = value; }
		}

		/// public propaty name  :  IsOutputAllSecRec
		/// <summary>�S���_���R�[�h�o�̓v���p�e�B</summary>
		/// <value>true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �S���_���R�[�h�o�̓v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Boolean IsOutputAllSecRec
		{
			get { return _isOutputAllSecRec; }
			set { _isOutputAllSecRec = value; }
		}

		/// public propaty name  :  ResultsAddUpSecList
		/// <summary>���ьv�㋒�_�R�[�h���X�g�v���p�e�B</summary>
		/// <value>�����^�@���z�񍀖�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ьv�㋒�_�R�[�h���X�g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] ResultsAddUpSecList
		{
			get { return _resultsAddUpSecList; }
			set { _resultsAddUpSecList = value; }
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>20:�� 40:�o��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get { return _acptAnOdrStatus; }
			set { _acptAnOdrStatus = value; }
		}

		/// public propaty name  :  SalesDateSt
		/// <summary>������t(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������t(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesDateSt
		{
			get { return _salesDateSt; }
			set { _salesDateSt = value; }
		}

		/// public propaty name  :  SalesDateEd
		/// <summary>������t(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������t(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesDateEd
		{
			get { return _salesDateEd; }
			set { _salesDateEd = value; }
		}

		/// public propaty name  :  ShipmentDaySt
		/// <summary>�o�ד��t(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ד��t(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipmentDaySt
		{
			get { return _shipmentDaySt; }
			set { _shipmentDaySt = value; }
		}

		/// public propaty name  :  ShipmentDayEd
		/// <summary>�o�ד��t(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�ד��t(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShipmentDayEd
		{
			get { return _shipmentDayEd; }
			set { _shipmentDayEd = value; }
		}

		/// public propaty name  :  SearchSlipDateSt
		/// <summary>���͓��t(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SearchSlipDateSt
		{
			get { return _searchSlipDateSt; }
			set { _searchSlipDateSt = value; }
		}

		/// public propaty name  :  SearchSlipDateEd
		/// <summary>���͓��t(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͓��t(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SearchSlipDateEd
		{
			get { return _searchSlipDateEd; }
			set { _searchSlipDateEd = value; }
		}

		/// public propaty name  :  CustomerCodeSt
		/// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get { return _customerCodeSt; }
			set { _customerCodeSt = value; }
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get { return _customerCodeEd; }
			set { _customerCodeEd = value; }
		}

		/// public propaty name  :  SalesEmployeeCdSt
		/// <summary>�̔��]�ƈ��R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��]�ƈ��R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesEmployeeCdSt
		{
			get { return _salesEmployeeCdSt; }
			set { _salesEmployeeCdSt = value; }
		}

		/// public propaty name  :  SalesEmployeeCdEd
		/// <summary>�̔��]�ƈ��R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �̔��]�ƈ��R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesEmployeeCdEd
		{
			get { return _salesEmployeeCdEd; }
			set { _salesEmployeeCdEd = value; }
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>�ԓ`�敪�v���p�e�B</summary>
		/// <value>0:���`,1:�ԓ`,2:�����@�@���S�Ă�-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ԓ`�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get { return _debitNoteDiv; }
			set { _debitNoteDiv = value; }
		}

		/// public propaty name  :  SalesSlipCd
		/// <summary>����`�[�敪�v���p�e�B</summary>
		/// <value>0:����,1:�ԕi�@���S�Ă�-1</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipCd
		{
			get { return _salesSlipCd; }
			set { _salesSlipCd = value; }
		}

		/// public propaty name  :  SalesSlipCdDtl
		/// <summary>����`�[�敪[����]�v���p�e�B</summary>
		/// <value>0:����,1:�ԕi,2:�l��,9:�ꎮ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�敪[����]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipCdDtl
		{
			get { return _salesSlipCdDtl; }
			set { _salesSlipCdDtl = value; }
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>����`�[�ԍ�[�`�[]�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ�[�`�[]�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get { return _salesSlipNum; }
			set { _salesSlipNum = value; }
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>�e���`�F�b�N�����v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitCheckLower
		{
			get { return _grsProfitCheckLower; }
			set { _grsProfitCheckLower = value; }
		}

		/// public propaty name  :  GrsProfitCheckBest
		/// <summary>�e���`�F�b�N�K���v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N�K���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitCheckBest
		{
			get { return _grsProfitCheckBest; }
			set { _grsProfitCheckBest = value; }
		}

		/// public propaty name  :  GrsProfitCheckUpper
		/// <summary>�e���`�F�b�N����v���p�e�B</summary>
		/// <value>�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrsProfitCheckUpper
		{
			get { return _grsProfitCheckUpper; }
			set { _grsProfitCheckUpper = value; }
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>�e���`�F�b�N2�v���p�e�B</summary>
		/// <value>�e���`�F�b�N2�̒l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrossMarginLow2
		{
			get { return _grossMarginLow2; }
			set { _grossMarginLow2 = value; }
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>�e���`�F�b�N3�v���p�e�B</summary>
		/// <value>�e���`�F�b�N3�̒l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrossMarginBest2
		{
			get { return _grossMarginBest2; }
			set { _grossMarginBest2 = value; }
		}

		/// public propaty name  :  GrsProfitCheckLower
		/// <summary>�e���`�F�b�N4�v���p�e�B</summary>
		/// <value>�e���`�F�b�N4�̒l�i���œ��́j�@XX.X���@�ȏ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N4�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double GrossMarginUpper2
		{
			get { return _grossMarginUpper2; }
			set { _grossMarginUpper2 = value; }
		}

		/// public propaty name  :  GrossMargin1Mark
		/// <summary>�e���`�F�b�N�}�[�N1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N1(�}�[�N)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrossMargin1Mark
		{
			get { return _grossMargin1Mark; }
			set { _grossMargin1Mark = value; }
		}

		/// public propaty name  :  GrossMargin2Mark
		/// <summary>�e���`�F�b�N�}�[�N2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N2(�}�[�N)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrossMargin2Mark
		{
			get { return _grossMargin2Mark; }
			set { _grossMargin2Mark = value; }
		}

		/// public propaty name  :  GrossMargin3Mark
		/// <summary>�e���`�F�b�N�}�[�N3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �e���`�F�b�N3(�}�[�N)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string GrossMargin3Mark
		{
			get { return _grossMargin3Mark; }
			set { _grossMargin3Mark = value; }
		}

		/// public propaty name  :  GrossMargin4Mark
        /// <summary>���s�^�C�v�v���p�e�B</summary>
        /// <value>0:��,1:�󒍌v��ς�,2:�ݏo,3:�ݏo�v��ς�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
		public string GrossMargin4Mark
		{
			get { return _grossMargin4Mark; }
			set { _grossMargin4Mark = value; }
		}

        /// public propaty name  :  PublicationType
        /// <summary>���[�^�C�v�敪�v���p�e�B</summary>
        /// <value>1:�󒍊m�F�\(���v) 2:�󒍊m�F�\(����) 3:�o�׊m�F�\(���v)  4:�o�׊m�F�\(����)</value>
        /// -----------------------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪�v���p�e�B</br>
        /// <br>Programer        :   Ai Mabuchi</br>
        /// </remarks>
        public Int32 PublicationType
        {
            get { return _publicationType; }
            set { _publicationType = value; }
        }

        /// public propaty name  :  NewPageType
        /// <summary>���Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NewPageType
        {
            get { return _newPageType; }
            set { _newPageType = value; }
        }


		/// public propaty name  :  SortOrder
		/// <summary>�o�͏��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͏��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value; }
		}

		/// public propaty name  :  PrintDiv
		/// <summary>���[�^�C�v�敪�v���p�e�B</summary>
		/// <value>1:�󒍊m�F�\(���v) 2:�󒍊m�F�\(����) 3:�o�׊m�F�\(���v)  4:�o�׊m�F�\(����)</value>
		/// -----------------------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�^�C�v�敪�v���p�e�B</br>
		/// <br>Programer        :   Ai Mabuchi</br>
		/// </remarks>
		public Int32 PrintDiv
		{
			get { return _printDiv; }
			set { _printDiv = value; }
		}

		/// public propaty name  :  PrintDivName
		/// <summary>���[�^�C�v�敪���̃v���p�e�B</summary>
		/// -------------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�^�C�v�敪���̃v���p�e�B</br>
		/// <br>Programer        :   Ai Mabuchi</br>
		/// </remarks>
		public string PrintDivName
		{
			get { return _printDivName; }
			set { _printDivName = value; }
		}

		//-------------------------------------------------------------------------------------

        // --- ADD 2009/03/30 -------------------------------->>>>>
        /// public propaty name  :  CostOut
        /// <summary>�����E�e���o�̓v���p�e�B</summary>
        /// -------------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����E�e���o�̓v���p�e�B</br>
        /// <br>Programer        :   Ai Mabuchi</br>
        /// </remarks>
        public Int32 CostOut
        {
            get { return _costOut; }
            set { _costOut = value; }
        }

        /// public propaty name  :  PrindDailyFooter
        /// <summary>���v�󎚃v���p�e�B</summary>
        /// -------------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�󎚃v���p�e�B</br>
        /// <br>Programer        :   Ai Mabuchi</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }
        // --- ADD 2009/03/30 --------------------------------<<<<<

		#region ���[�^�C�v�敪��
		/// <summary>���[�^�C�v�敪��</summary>
		public enum PrintDivState
		{
			///<summary>�`�[�`��</summary>
			Slipform = 1,
			///<summary>���׌`��</summary>
			Detialform = 2

		}
		#endregion

		/// <summary>
		/// �󒍏o�׊m�F�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCHNB02013E�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DCHNB02013E()
		{
		}

		/// <summary>
		/// �󒍏o�׊m�F�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>		
		/// <param name="isSelectAllSection">�S�БI��(true:�S�БI�� false:�e���_�I��)</param>
		/// <param name="isOutputAllSecRec">�S���_���R�[�h�o��(true:�S���_���R�[�h���o�͂���Bfalse:�S���_���R�[�h���o�͂��Ȃ�)</param>
		/// <param name="resultsAddUpSecList">���ьv�㋒�_�R�[�h���X�g(�����^�@���z�񍀖�)</param>
		/// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(20:�� 40:�o��)</param>
		/// <param name="salesDateSt">������t(�J�n)</param>
		/// <param name="salesDateEd">������t(�I��)</param>
		/// <param name="shipmentDaySt">�o�ד��t(�J�n)</param>
		/// <param name="shipmentDayEd">�o�ד��t(�I��)</param>
		/// <param name="searchSlipDateSt">���͓��t(�J�n)</param>
		/// <param name="searchSlipDateEd">���͓��t(�I��)</param>
		/// <param name="customerCodeSt">���Ӑ�R�[�h(�J�n)</param>
		/// <param name="customerCodeEd">���Ӑ�R�[�h(�I��)</param>
		/// <param name="salesEmployeeCdSt">�̔��]�ƈ��i�S���ҁj�R�[�h(�J�n)</param>
		/// <param name="salesEmployeeCdEd">�̔��]�ƈ��i�S���ҁj�R�[�h(�I��)</param>
		/// <param name="debitNoteDiv">�ԓ`�敪(0:���`,1:�ԓ`,2:�����@�@���S�Ă�-1)</param>
		/// <param name="salesSlipCd">����`�[�敪(0:����,1:�ԕi�@���S�Ă�-1)</param>
		/// <param name="salesSlipCdDtl">����`�[�敪(0:����,1:�ԕi,2:�l��,9:�ꎮ)</param>
		/// <param name="grsProfitCheckLower">�e���`�F�b�N����(�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�)</param>
		/// <param name="grsProfitCheckBest">�e���`�F�b�N�K��(�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�)</param>
		/// <param name="grsProfitCheckUpper">�e���`�F�b�N���(�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�)</param>
		/// <param name="grossMargin1St">�e���`�F�b�N2(�e���`�F�b�N2�̒l�i���œ��́j�@XX.X���@�ȏ�)</param>
		/// <param name="grossMargin2Ed">�e���`�F�b�N3(�e���`�F�b�N3�̒l�i���œ��́j�@XX.X���@�ȏ�)</param>
		/// <param name="grossMargin3Ed">�e���`�F�b�N4(�e���`�F�b�N4�̒l�i���œ��́j�@XX.X���@�ȏ�)</param>
		/// <param name="grossMargin1Mark">�e���`�F�b�N�}�[�N1</param>
		/// <param name="grossMargin2Mark">�e���`�F�b�N�}�[�N2</param>
		/// <param name="grossMargin3Mark">�e���`�F�b�N�}�[�N3</param>
		/// <param name="grossMargin4Mark">�e���`�F�b�N�}�[�N4</param>
        /// <param name="publicationType">���s�^�C�v</param>
        /// <param name="newPageType">����</param>
        /// <param name="sortOrder">�o�͏�</param>
		/// <param name="printDiv">���[�^�C�v�敪</param>
		/// <param name="printDivName">���[�^�C�v�敪����</param>
        /// <param name="constOut">�����E�e���o��</param>
        /// <param name="printDailyFooter">���v��</param>

		/// <returns>ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCHNB02013E�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>

		public ExtrInfo_DCHNB02013E(string enterpriseCode, Boolean isSelectAllSection, Boolean isOutputAllSecRec, string[] resultsAddUpSecList, Int32 acptAnOdrStatus, Int32 salesDateSt, Int32 salesDateEd, Int32 shipmentDaySt, Int32 shipmentDayEd, Int32 searchSlipDateSt, Int32 searchSlipDateEd, Int32 customerCodeSt, Int32 customerCodeEd, string salesEmployeeCdSt, string salesEmployeeCdEd, Int32 debitNoteDiv, Int32 salesSlipCd, Int32 salesSlipCdDtl, Double grsProfitCheckLower, Double grsProfitCheckBest, Double grsProfitCheckUpper, Double grossMargin1St, Double grossMargin2Ed, Double grossMargin3Ed, string grossMargin1Mark, string grossMargin2Mark, string grossMargin3Mark, string grossMargin4Mark, Int32 publicationType, Int32 newPageType, Int32 sortOrder , Int32 printDiv, string printDivName, Int32 constOut, Int32 printDailyFooter)
		{
			this._enterpriseCode = enterpriseCode;
			this._isSelectAllSection = isSelectAllSection;
			this._isOutputAllSecRec = isOutputAllSecRec;
			this._resultsAddUpSecList = resultsAddUpSecList;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._salesDateSt = salesDateSt;
			this._salesDateEd = salesDateEd;
			this._shipmentDaySt = shipmentDaySt;
			this._shipmentDayEd = shipmentDayEd;
			this._searchSlipDateSt = searchSlipDateSt;
			this._searchSlipDateEd = searchSlipDateEd;
			this._customerCodeSt = customerCodeSt;
			this._customerCodeEd = customerCodeEd;
			this._salesEmployeeCdSt = salesEmployeeCdSt;
			this._salesEmployeeCdEd = salesEmployeeCdEd;
			this._debitNoteDiv = debitNoteDiv;
			this._salesSlipCd = salesSlipCd;
			this._salesSlipCdDtl = salesSlipCdDtl;
			this._grsProfitCheckLower = grsProfitCheckLower;
			this._grsProfitCheckBest = grsProfitCheckBest;
			this._grsProfitCheckUpper = grsProfitCheckUpper;
			this._grossMarginLow2 = grossMargin1St;
			this._grossMarginBest2 = grossMargin2Ed;
			this._grossMarginUpper2 = grossMargin3Ed;
			this._grossMargin1Mark = grossMargin1Mark;
			this._grossMargin2Mark = grossMargin2Mark;
			this._grossMargin3Mark = grossMargin3Mark;
			this._grossMargin4Mark = grossMargin4Mark;
            this._publicationType = publicationType;
            this._newPageType = newPageType;
			this._sortOrder = sortOrder;
			this._printDiv = printDiv;
			this._printDivName = printDivName;
            // --- ADD 2009/03/30 -------------------------------->>>>>
            this._costOut = constOut;
            this._printDailyFooter = printDailyFooter;
            // --- ADD 2009/03/30 --------------------------------<<<<<

		}

		/// <summary>
		/// �󒍏o�׊m�F�\���o�����N���X��������
		/// </summary>
		/// <returns>ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ExtrInfo_DCHNB02013E Clone()
		{
			return new ExtrInfo_DCHNB02013E(this._enterpriseCode, this._isSelectAllSection, this._isOutputAllSecRec, this._resultsAddUpSecList, this._acptAnOdrStatus, this._salesDateSt, this._salesDateEd, this._shipmentDaySt, this._shipmentDayEd, this._searchSlipDateSt, this._searchSlipDateEd, this._customerCodeSt, this._customerCodeEd, this._salesEmployeeCdSt, this._salesEmployeeCdEd, this._debitNoteDiv, this._salesSlipCd, this._salesSlipCdDtl, this._grsProfitCheckLower, this._grsProfitCheckBest, this._grsProfitCheckUpper, this._grossMarginLow2, this._grossMarginBest2, this._grossMarginUpper2, this._grossMargin1Mark, this._grossMargin2Mark, this._grossMargin3Mark, this._grossMargin4Mark, this._publicationType, this._newPageType, this._sortOrder , this._printDiv, this._printDivName, this._costOut, this._printDailyFooter);
		}

		/// <summary>
		/// �󒍏o�׊m�F�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCHNB02013E�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DCHNB02013E target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsSelectAllSection == target.IsSelectAllSection)
				 && (this.IsOutputAllSecRec == target.IsOutputAllSecRec)
				 && (this.ResultsAddUpSecList == target.ResultsAddUpSecList)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.SalesDateSt == target.SalesDateSt)
				 && (this.SalesDateEd == target.SalesDateEd)
				 && (this.ShipmentDaySt == target.ShipmentDaySt)
				 && (this.ShipmentDayEd == target.ShipmentDayEd)
				 && (this.SearchSlipDateSt == target.SearchSlipDateSt)
				 && (this.SearchSlipDateEd == target.SearchSlipDateEd)
				 && (this.CustomerCodeSt == target.CustomerCodeSt)
				 && (this.SalesEmployeeCdSt == target.SalesEmployeeCdSt)
				 && (this.SalesEmployeeCdEd == target.SalesEmployeeCdEd)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.SalesSlipCd == target.SalesSlipCd)
				 && (this.SalesSlipCdDtl == target.SalesSlipCdDtl)
				 && (this.GrsProfitCheckLower == target.GrsProfitCheckLower)
				 && (this.GrsProfitCheckBest == target.GrsProfitCheckBest)
				 && (this.GrsProfitCheckUpper == target.GrsProfitCheckUpper)
				 && (this._grossMarginLow2 == target._grossMarginLow2)
				 && (this._grossMarginBest2 == target._grossMarginBest2)
				 && (this._grossMarginUpper2 == target._grossMarginUpper2)
				 && (this.GrossMargin1Mark == target.GrossMargin1Mark)
				 && (this.GrossMargin2Mark == target.GrossMargin2Mark)
				 && (this.GrossMargin3Mark == target.GrossMargin3Mark)
				 && (this.GrossMargin4Mark == target.GrossMargin4Mark)
                 && (this.PublicationType == target.PublicationType)
                 && (this.NewPageType == target.NewPageType)
				 && (this.SortOrder == target.SortOrder)
				 && (this.PrintDiv == target.PrintDiv)
				 && (this.PrintDivName == target.PrintDivName)
                // --- ADD 2009/03/30 -------------------------------->>>>>
                && (this.CostOut == target.CostOut)
                && (this.PrintDailyFooter == target.PrintDailyFooter)
                // --- ADD 2009/03/30 --------------------------------<<<<<
				 );

		}

		/// <summary>
		/// �󒍏o�׊m�F�\���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DCHNB02013E1">
		///                    ��r����ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X
		/// </param>
		/// <param name="extrInfo_DCHNB02013E2">��r����ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCHNB02013E�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_DCHNB02013E extrInfo_DCHNB02013E1, ExtrInfo_DCHNB02013E extrInfo_DCHNB02013E2)
		{
			return ((extrInfo_DCHNB02013E1.EnterpriseCode == extrInfo_DCHNB02013E2.EnterpriseCode)
				 && (extrInfo_DCHNB02013E1.IsSelectAllSection == extrInfo_DCHNB02013E2.IsSelectAllSection)
				 && (extrInfo_DCHNB02013E1.IsOutputAllSecRec == extrInfo_DCHNB02013E2.IsOutputAllSecRec)
				 && (extrInfo_DCHNB02013E1.ResultsAddUpSecList == extrInfo_DCHNB02013E2.ResultsAddUpSecList)
				 && (extrInfo_DCHNB02013E1.AcptAnOdrStatus == extrInfo_DCHNB02013E2.AcptAnOdrStatus)
				 && (extrInfo_DCHNB02013E1.SalesDateSt == extrInfo_DCHNB02013E2.SalesDateSt)
				 && (extrInfo_DCHNB02013E1.SalesDateEd == extrInfo_DCHNB02013E2.SalesDateEd)
				 && (extrInfo_DCHNB02013E1.ShipmentDaySt == extrInfo_DCHNB02013E2.ShipmentDaySt)
				 && (extrInfo_DCHNB02013E1.ShipmentDayEd == extrInfo_DCHNB02013E2.ShipmentDayEd)
				 && (extrInfo_DCHNB02013E1.SearchSlipDateSt == extrInfo_DCHNB02013E2.SearchSlipDateSt)
				 && (extrInfo_DCHNB02013E1.SearchSlipDateEd == extrInfo_DCHNB02013E2.SearchSlipDateEd)
				 && (extrInfo_DCHNB02013E1.CustomerCodeSt == extrInfo_DCHNB02013E2.CustomerCodeSt)
				 && (extrInfo_DCHNB02013E1.CustomerCodeEd == extrInfo_DCHNB02013E2.CustomerCodeEd)
				 && (extrInfo_DCHNB02013E1.SalesEmployeeCdSt == extrInfo_DCHNB02013E2.SalesEmployeeCdSt)
				 && (extrInfo_DCHNB02013E1.SalesEmployeeCdEd == extrInfo_DCHNB02013E2.SalesEmployeeCdEd)
				 && (extrInfo_DCHNB02013E1.DebitNoteDiv == extrInfo_DCHNB02013E2.DebitNoteDiv)
				 && (extrInfo_DCHNB02013E1.SalesSlipCd == extrInfo_DCHNB02013E2.SalesSlipCd)
				 && (extrInfo_DCHNB02013E1.SalesSlipCdDtl == extrInfo_DCHNB02013E2.SalesSlipCdDtl)
				 && (extrInfo_DCHNB02013E1.GrsProfitCheckLower == extrInfo_DCHNB02013E2.GrsProfitCheckLower)
				 && (extrInfo_DCHNB02013E1.GrsProfitCheckBest == extrInfo_DCHNB02013E2.GrsProfitCheckBest)
				 && (extrInfo_DCHNB02013E1.GrsProfitCheckUpper == extrInfo_DCHNB02013E2.GrsProfitCheckUpper)
				 && (extrInfo_DCHNB02013E1.GrossMarginLow2 == extrInfo_DCHNB02013E2.GrossMarginLow2)
				 && (extrInfo_DCHNB02013E1.GrossMarginBest2 == extrInfo_DCHNB02013E2.GrossMarginBest2)
				 && (extrInfo_DCHNB02013E1.GrossMarginUpper2 == extrInfo_DCHNB02013E2.GrossMarginUpper2)
				 && (extrInfo_DCHNB02013E1.GrossMargin1Mark == extrInfo_DCHNB02013E2.GrossMargin1Mark)
				 && (extrInfo_DCHNB02013E1.GrossMargin2Mark == extrInfo_DCHNB02013E2.GrossMargin2Mark)
				 && (extrInfo_DCHNB02013E1.GrossMargin3Mark == extrInfo_DCHNB02013E2.GrossMargin3Mark)
				 && (extrInfo_DCHNB02013E1.GrossMargin4Mark == extrInfo_DCHNB02013E2.GrossMargin4Mark)
                 && (extrInfo_DCHNB02013E1.PublicationType == extrInfo_DCHNB02013E2.PublicationType)
                 && (extrInfo_DCHNB02013E1.NewPageType == extrInfo_DCHNB02013E2.NewPageType)
				 && (extrInfo_DCHNB02013E1.SortOrder == extrInfo_DCHNB02013E2.SortOrder)
				 && (extrInfo_DCHNB02013E1.PrintDiv == extrInfo_DCHNB02013E2.PrintDiv)
				 && (extrInfo_DCHNB02013E1.PrintDivName == extrInfo_DCHNB02013E2.PrintDivName)
                // --- ADD 2009/03/30 -------------------------------->>>>>
                && (extrInfo_DCHNB02013E1.CostOut == extrInfo_DCHNB02013E2.CostOut)
                && (extrInfo_DCHNB02013E1.PrintDailyFooter == extrInfo_DCHNB02013E2.PrintDailyFooter)
                // --- ADD 2009/03/30 --------------------------------<<<<<
				 );

		}
		/// <summary>
		/// �󒍏o�׊m�F�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCHNB02013E�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_DCHNB02013E target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (this.IsOutputAllSecRec != target.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (this.ResultsAddUpSecList != target.ResultsAddUpSecList) resList.Add("ResultsAddUpSecList");
			if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
			if (this.SalesDateSt != target.SalesDateSt) resList.Add("SalesDateSt");
			if (this.SalesDateEd != target.SalesDateEd) resList.Add("SalesDateEd");
			if (this.ShipmentDaySt != target.ShipmentDaySt) resList.Add("ShipmentDaySt");
			if (this.ShipmentDayEd != target.ShipmentDayEd) resList.Add("ShipmentDayEd");
			if (this.SearchSlipDateSt != target.SearchSlipDateSt) resList.Add("SearchSlipDateSt");
			if (this.SearchSlipDateEd != target.SearchSlipDateEd) resList.Add("SearchSlipDateEd");
			if (this.CustomerCodeSt != target.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if (this.CustomerCodeEd != target.CustomerCodeEd) resList.Add("CustomerCodeEd");
			if (this.SalesEmployeeCdSt != target.SalesEmployeeCdSt) resList.Add("SalesEmployeeCdSt");
			if (this.SalesEmployeeCdEd != target.SalesEmployeeCdEd) resList.Add("SalesEmployeeCdEd");
			if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
			if (this.SalesSlipCdDtl != target.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");//����`�[�敪[����]
			if (this.GrsProfitCheckLower != target.GrsProfitCheckLower) resList.Add("GrsProfitCheckLower");
			if (this.GrsProfitCheckBest != target.GrsProfitCheckBest) resList.Add("GrsProfitCheckBest");
			if (this.GrsProfitCheckUpper != target.GrsProfitCheckUpper) resList.Add("GrsProfitCheckUpper");
			if (this.GrossMarginLow2 != target.GrossMarginLow2) resList.Add("GrossMarginLow2");
			if (this.GrossMarginBest2 != target.GrossMarginBest2) resList.Add("GrossMarginBest2");
			if (this.GrossMarginUpper2 != target.GrossMarginUpper2) resList.Add("GrossMarginUpper2");
			if (this.GrossMargin1Mark != target.GrossMargin1Mark) resList.Add("GrossMargin1Mark");
			if (this.GrossMargin2Mark != target.GrossMargin2Mark) resList.Add("GrossMargin2Mark");
			if (this.GrossMargin3Mark != target.GrossMargin3Mark) resList.Add("GrossMargin3Mark");
			if (this.GrossMargin4Mark != target.GrossMargin4Mark) resList.Add("GrossMargin4Mark");
            if (this.PublicationType != target.PublicationType) resList.Add("PublicationType");
            if (this.NewPageType != target.NewPageType) resList.Add("NewPageType");
			if (this.SortOrder != target.SortOrder) resList.Add("SortOrder");
			if (this.PrintDiv != target.PrintDiv) resList.Add("PrintDiv");
			if (this.PrintDivName != target.PrintDivName) resList.Add("PrintDivName");
            // --- ADD 2009/03/30 -------------------------------->>>>>
            if (this.CostOut != target.CostOut) resList.Add("CostOut");
            if (this.PrintDailyFooter != target.PrintDailyFooter) resList.Add("PrintDailyFooter");
            // --- ADD 2009/03/30 --------------------------------<<<<<

			return resList;
		}

		/// <summary>
		/// �󒍏o�׊m�F�\���o�����N���X��r����
		/// </summary>
		/// <param name="extrInfo_DCHNB02013E1">��r����ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X</param>
		/// <param name="extrInfo_DCHNB02013E2">��r����ExtrInfo_DCHNB02013E�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ExtrInfo_DCHNB02013E�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_DCHNB02013E extrInfo_DCHNB02013E1, ExtrInfo_DCHNB02013E extrInfo_DCHNB02013E2)
		{
			ArrayList resList = new ArrayList();
			if (extrInfo_DCHNB02013E1.EnterpriseCode != extrInfo_DCHNB02013E2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (extrInfo_DCHNB02013E1.IsSelectAllSection != extrInfo_DCHNB02013E2.IsSelectAllSection) resList.Add("IsSelectAllSection");
			if (extrInfo_DCHNB02013E1.IsOutputAllSecRec != extrInfo_DCHNB02013E2.IsOutputAllSecRec) resList.Add("IsOutputAllSecRec");
			if (extrInfo_DCHNB02013E1.ResultsAddUpSecList != extrInfo_DCHNB02013E2.ResultsAddUpSecList) resList.Add("ResultsAddUpSecList");
			if (extrInfo_DCHNB02013E1.AcptAnOdrStatus != extrInfo_DCHNB02013E2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
			if (extrInfo_DCHNB02013E1.SalesDateSt != extrInfo_DCHNB02013E2.SalesDateSt) resList.Add("SalesDateSt");
			if (extrInfo_DCHNB02013E1.SalesDateEd != extrInfo_DCHNB02013E2.SalesDateEd) resList.Add("SalesDateEd");
			if (extrInfo_DCHNB02013E1.ShipmentDaySt != extrInfo_DCHNB02013E2.ShipmentDaySt) resList.Add("ShipmentDaySt");
			if (extrInfo_DCHNB02013E1.ShipmentDayEd != extrInfo_DCHNB02013E2.ShipmentDayEd) resList.Add("ShipmentDayEd");
			if (extrInfo_DCHNB02013E1.SearchSlipDateSt != extrInfo_DCHNB02013E2.SearchSlipDateSt) resList.Add("SearchSlipDateSt");
			if (extrInfo_DCHNB02013E1.SearchSlipDateEd != extrInfo_DCHNB02013E2.SearchSlipDateEd) resList.Add("SearchSlipDateEd");
			if (extrInfo_DCHNB02013E1.CustomerCodeSt != extrInfo_DCHNB02013E2.CustomerCodeSt) resList.Add("CustomerCodeSt");
			if (extrInfo_DCHNB02013E1.CustomerCodeEd != extrInfo_DCHNB02013E2.CustomerCodeEd) resList.Add("CustomerCodeEd");
			if (extrInfo_DCHNB02013E1.SalesEmployeeCdSt != extrInfo_DCHNB02013E2.SalesEmployeeCdSt) resList.Add("SalesEmployeeCdSt");
			if (extrInfo_DCHNB02013E1.SalesEmployeeCdEd != extrInfo_DCHNB02013E2.SalesEmployeeCdEd) resList.Add("SalesEmployeeCdEd");
			if (extrInfo_DCHNB02013E1.DebitNoteDiv != extrInfo_DCHNB02013E2.DebitNoteDiv) resList.Add("DebitNoteDiv");
			if (extrInfo_DCHNB02013E1.SalesSlipCd != extrInfo_DCHNB02013E2.SalesSlipCd) resList.Add("SalesSlipCd");
			if (extrInfo_DCHNB02013E1.SalesSlipCdDtl != extrInfo_DCHNB02013E2.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
			if (extrInfo_DCHNB02013E1.GrsProfitCheckLower != extrInfo_DCHNB02013E2.GrsProfitCheckLower) resList.Add("GrsProfitCheckLower");
			if (extrInfo_DCHNB02013E1.GrsProfitCheckBest != extrInfo_DCHNB02013E2.GrsProfitCheckBest) resList.Add("GrsProfitCheckBest");
			if (extrInfo_DCHNB02013E1.GrsProfitCheckUpper != extrInfo_DCHNB02013E2.GrsProfitCheckUpper) resList.Add("GrsProfitCheckUpper");
			if (extrInfo_DCHNB02013E1.GrossMarginLow2 != extrInfo_DCHNB02013E2.GrossMarginLow2) resList.Add("GrossMarginLow2");
			if (extrInfo_DCHNB02013E1.GrossMarginBest2 != extrInfo_DCHNB02013E2.GrossMarginBest2) resList.Add("GrossMarginBest2");
			if (extrInfo_DCHNB02013E1.GrossMarginUpper2 != extrInfo_DCHNB02013E2.GrossMarginUpper2) resList.Add("GrossMarginUpper2");
			if (extrInfo_DCHNB02013E1.GrossMargin1Mark != extrInfo_DCHNB02013E2.GrossMargin1Mark) resList.Add("GrossMargin1Mark");
			if (extrInfo_DCHNB02013E1.GrossMargin2Mark != extrInfo_DCHNB02013E2.GrossMargin2Mark) resList.Add("GrossMargin2Mark");
			if (extrInfo_DCHNB02013E1.GrossMargin3Mark != extrInfo_DCHNB02013E2.GrossMargin3Mark) resList.Add("GrossMargin3Mark");
			if (extrInfo_DCHNB02013E1.GrossMargin4Mark != extrInfo_DCHNB02013E2.GrossMargin4Mark) resList.Add("GrossMargin4Mark");
            if (extrInfo_DCHNB02013E1.PublicationType != extrInfo_DCHNB02013E2.PublicationType) resList.Add("PublicationType");
            if (extrInfo_DCHNB02013E1.NewPageType != extrInfo_DCHNB02013E2.NewPageType) resList.Add("NewPageType");
            if (extrInfo_DCHNB02013E1.SortOrder != extrInfo_DCHNB02013E2.SortOrder) resList.Add("SortOrder");
			if (extrInfo_DCHNB02013E1.PrintDiv != extrInfo_DCHNB02013E2.PrintDiv) resList.Add("PrintDiv");
			if (extrInfo_DCHNB02013E1.PrintDivName != extrInfo_DCHNB02013E2.PrintDivName) resList.Add("PrintDivName");
            // --- ADD 2009/03/30 -------------------------------->>>>>
            if (extrInfo_DCHNB02013E1.CostOut != extrInfo_DCHNB02013E2.CostOut) resList.Add("CostOut");
            if (extrInfo_DCHNB02013E1.PrintDailyFooter != extrInfo_DCHNB02013E2.PrintDailyFooter) resList.Add("PrintDailyFooter");
            // --- ADD 2009/03/30 --------------------------------<<<<<

			return resList;
		}

        #region �� ���s�^�C�v�񋓑�
        /// <summary> ���s�^�C�v�񋓑� </summary>
        public enum PublicationTypeState
        {
            /// <summary> �� </summary>
            AcceptAnOrder = 0,
            /// <summary> �󒍌v��� </summary>
            AcceptAnOrderAddUp = 1,
            // 2008.09.24 30413 ���� �ݏo�Ƒݏo�v��ς̒l��ύX >>>>>>START
            /// <summary> �ݏo </summary>
            //Loan = 1,
            Loan = 2,
            /// <summary> �ݏo�v��� </summary>
            //LoanAddUp = 2
            LoanAddUp = 3
            // 2008.09.24 30413 ���� �ݏo�Ƒݏo�v��ς̒l��ύX <<<<<<END
        }
        #endregion ��
	}
}
