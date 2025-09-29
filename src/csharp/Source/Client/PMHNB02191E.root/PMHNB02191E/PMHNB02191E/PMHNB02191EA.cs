using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   LedgerCmnCndtn
	/// <summary>
	///                      �������ʒ��o����UI�f�[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �����Ɖ�ꊇ���o����UI�f�[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/09/09</br>
	/// <br>Genarated Date   :   2006/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   20081 �D�c �E�l</br>
    /// <br>                 :   DC.NS�p�ɕύX</br>
    /// <br>Programmer       : 30009 �a�J ���</br>
    /// <br>Date             : 2009.01.21</br>
    /// <br>Note             : PM.NS�p�ɏC��</br>
    /// <br>Note             : ��PM�ŕs�v�ȏ����������Ă���肪�Ȃ���΂��̂܂܂ɂ��Ă���܂���</br>
    /// </remarks>
	public class LedgerCmnCndtn
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

        /// <summary>���_�I�v�V���������敪</summary>
        private bool _isOptSection;

        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        private bool _isMainOfficeFunc;

        /// <summary>�I���v�㋒�_�R�[�h</summary>
        private ArrayList _addupSecCodeList;

        /// <summary>���[�^�C�v�敪</summary>
        /// <remarks>�ݒ�R�[�h�Ɠ���</remarks>
        private int _printDiv;

        /// <summary>���[�^�C�v�敪����</summary>
        private string _printDivName = string.Empty;

		/// <summary>�o�͑Ώ۔N��(�J�n)</summary>
		private Int32 _startTargetYearMonth;

		/// <summary>�o�͑Ώ۔N��(�I��)</summary>
		private Int32 _endTargetYearMonth;

		/// <summary>�o�͏�</summary>
		private Int32 _printOder;

		/// <summary>���Ӑ�R�[�h(�J�n)</summary>
		private Int32 _startCustomerCode;

		/// <summary>���Ӑ�R�[�h(�I��)</summary>
		private Int32 _endCustomerCode;

		/// <summary>���Ӑ�J�i(�J�n)</summary>
		/// <remarks>ALL��=TOP</remarks>
		private string _startCustomerKana = "";

		/// <summary>���Ӑ�J�i(�I��)</summary>
		/// <remarks>ALL��=END</remarks>
		private string _endCustomerKana = "";

		/// <summary>�ڋq�S���ҋ敪</summary>
		/// <remarks>0:�ڋq�S����,1:�W���S����</remarks>
		private Int32 _customerAgentDivCd;

		/// <summary>�]�ƈ��R�[�h(�J�n)</summary>
		private string _startEmployeeCode = "";

		/// <summary>�]�ƈ��R�[�h(�I��)</summary>
		private string _endEmployeeCode = "";

		/// <summary>�o�͒��[�敪</summary>
		/// <remarks>0:�����c,1:���|�c,2:�x���c,3���|�c:</remarks>
		private Int32 _listDivCode;

		/// <summary>����敪</summary>
		/// <remarks>0:���P�ʂň��,1:�w��ŏI���ɔ͈͓��̖��ׂ��ꊇ���</remarks>
		private Int32 _printDivCode;

		/// <summary>�������o�͋敪</summary>
		private bool _isJudgeBillOutputCode = false;

		/// <summary>�J�z�c�O����敪</summary>
		/// <remarks>True:�������,False:������Ȃ�</remarks>
		private bool _isJudgeZeroPrint = false;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�v�㋒�_����</summary>
		private string _addUpSecName = "";

        /// <summary>�o�͋��z�敪</summary>
        /// <remarks>�ݒ�R�[�h�Ɠ���</remarks>
        private OutMoneyDivState _outMoneyDiv;

        #region �� Private Const
        // ���[�^�C�v�敪 ------------------------------------------------------------------
        /// <summary>���[�^�C�v�敪 ���Ӑ挳��(����)</summary>
        public const string ct_PrintDiv_Detail = "���׃^�C�v";
        /// <summary>���[�^�C�v�敪 ���Ӑ挳��(�`�[)</summary>
        public const string ct_PrintDiv_Slip = "�`�[�^�C�v";

        // �o�͋��z�敪 --------------------------------------------------------------------
        /// <summary>�S��</summary>
        public const string ct_OutMoneyDiv_All = "�S�ďo��";
        /// <summary>0+�v���X���z</summary>
        public const string ct_OutMoneyDiv_ZeroPlus = "0�ƃv���X���z���o��";
        /// <summary>�v���X���z</summary>
        public const string ct_OutMoneyDiv_Plus = "�v���X���z�̂ݏo��";
        /// <summary>0�o��</summary>
        public const string ct_OutMoneyDiv_Zero = "0�̂ݏo��";
        /// <summary>�v���X���z+�}�C�i�X���z</summary>
        public const string ct_OutMoneyDiv_PlusMinus = "�v���X���z�ƃ}�C�i�X���z";
        /// <summary>0+�}�C�i�X���z</summary>
        public const string ct_OutMoneyDiv_ZeroMinus = "0�ƃ}�C�i�X���z���o��";
        /// <summary>�}�C�i�X���z</summary>
        public const string ct_OutMoneyDiv_Minus = "�}�C�i�X���z�̂ݏo��";
        #endregion

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
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�I�v�V���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�Ћ@�\�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  AddupSecCodeList
        /// <summary>�I���v�㋒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �I���v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :  ��������</br>
        /// </remarks>
        public ArrayList AddupSecCodeList
        {
            get { return _addupSecCodeList; }
            set { _addupSecCodeList = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>���[�^�C�v�敪�v���p�e�B</summary>
        /// <value>�ݒ�̗p�r�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  PrintDivName
        /// <summary>���[�^�C�v�敪�v���p�e�B����(�ǂݎ���p)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�^�C�v�敪�v���p�e�B����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrintDivName
        {
            get { return _printDivName; }
            set { _printDivName = value; }
        }

		/// public propaty name  :  StartTargetYearMonth
		/// <summary>�o�͑Ώ۔N��(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͑Ώ۔N��(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartTargetYearMonth
		{
			get { return _startTargetYearMonth; }
			set { _startTargetYearMonth = value; }
		}

		/// public propaty name  :  EndTargetYearMonth
		/// <summary>�o�͑Ώ۔N��(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͑Ώ۔N��(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndTargetYearMonth
		{
			get { return _endTargetYearMonth; }
			set { _endTargetYearMonth = value; }
		}

		/// public propaty name  :  PrintOder
		/// <summary>�o�͏��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͏��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintOder
		{
			get { return _printOder; }
			set { _printOder = value; }
		}

		/// public propaty name  :  StartCustomerCode
		/// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartCustomerCode
		{
			get { return _startCustomerCode; }
			set { _startCustomerCode = value; }
		}

		/// public propaty name  :  EndCustomerCode
		/// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndCustomerCode
		{
			get { return _endCustomerCode; }
			set { _endCustomerCode = value; }
		}

		/// public propaty name  :  StartCustomerKana
		/// <summary>���Ӑ�J�i(�J�n)�v���p�e�B</summary>
		/// <value>ALL��=TOP</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�J�i(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartCustomerKana
		{
			get { return _startCustomerKana; }
			set { _startCustomerKana = value; }
		}

		/// public propaty name  :  EndCustomerKana
		/// <summary>���Ӑ�J�i(�I��)�v���p�e�B</summary>
		/// <value>ALL��=END</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�J�i(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EndCustomerKana
		{
			get { return _endCustomerKana; }
			set { _endCustomerKana = value; }
		}

		/// public propaty name  :  CustomerAgentDivCd
		/// <summary>�ڋq�S���ҋ敪�v���p�e�B</summary>
		/// <value>0:�ڋq�S����,1:�W���S����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ڋq�S���ҋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerAgentDivCd
		{
			get { return _customerAgentDivCd; }
			set { _customerAgentDivCd = value; }
		}

		/// public propaty name  :  StartEmployeeCode
		/// <summary>�]�ƈ��R�[�h(�J�n)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��R�[�h(�J�n)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StartEmployeeCode
		{
			get { return _startEmployeeCode; }
			set { _startEmployeeCode = value; }
		}

		/// public propaty name  :  EndEmployeeCode
		/// <summary>�]�ƈ��R�[�h(�I��)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��R�[�h(�I��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EndEmployeeCode
		{
			get { return _endEmployeeCode; }
			set { _endEmployeeCode = value; }
		}

		/// public propaty name  :  ListDivCode
		/// <summary>�o�͒��[�敪�v���p�e�B</summary>
		/// <value>0:�����c,1:���|�c</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͒��[�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ListDivCode
		{
			get { return _listDivCode; }
			set { _listDivCode = value; }
		}

		/// public propaty name  :  PrintDivCode
		/// <summary>����敪�v���p�e�B</summary>
		/// <value>0:���P�ʂň��,1:�w��ŏI���ɔ͈͓��̖��ׂ��ꊇ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintDivCode
		{
			get { return _printDivCode; }
			set { _printDivCode = value; }
		}

		/// public propaty name  :  IsJudgeBillOutputCode
		/// <summary>�������o�͋敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������o�͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsJudgeBillOutputCode
		{
			get { return _isJudgeBillOutputCode; }
			set { _isJudgeBillOutputCode = value; }
		}

		/// public propaty name  :  isJudgeZeroPrint
		/// <summary>�J�z�c�O����敪�v���p�e�B</summary>
		/// <value>True:�������,False:������Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�z�c�O����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool IsJudgeZeroPrint
		{
			get { return _isJudgeZeroPrint; }
			set { _isJudgeZeroPrint = value; }
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

		/// public propaty name  :  AddUpSecName
		/// <summary>�v�㋒�_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AddUpSecName
		{
			get { return _addUpSecName; }
			set { _addUpSecName = value; }
		}

        /// public propaty name  :  OutMoneyDiv
        /// <summary>�o�͋��z�敪�v���p�e�B</summary>
        /// <value>�ݒ�̗p�r�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͋��z�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public OutMoneyDivState OutMoneyDiv
        {
            get { return _outMoneyDiv; }
            set { _outMoneyDiv = value; }
        }

        /// public propaty name  :  OutMoneyDivName
        /// <summary>�o�͋��z�敪���̃v���p�e�B(�ǂݎ���p)</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͋��z�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutMoneyDivName
        {
            get
            {
                string outMoneyDivName = string.Empty;
                // �o�͋��z�敪���疼�̂𔻒f
                switch (this._outMoneyDiv)
                {
                    case OutMoneyDivState.All:		    // �S��
                        outMoneyDivName = ct_OutMoneyDiv_All;
                        break;
                    case OutMoneyDivState.ZeroPlus:	   // 0+�v���X���z
                        outMoneyDivName = ct_OutMoneyDiv_ZeroPlus;
                        break;
                    case OutMoneyDivState.Plus:	       // �v���X���z
                        outMoneyDivName = ct_OutMoneyDiv_Plus;
                        break;
                    case OutMoneyDivState.Zero:	       // 0�o��
                        outMoneyDivName = ct_OutMoneyDiv_Zero;
                        break;
                    case OutMoneyDivState.PlusMinus:   // �v���X���z+�}�C�i�X���z
                        outMoneyDivName = ct_OutMoneyDiv_PlusMinus;
                        break;
                    case OutMoneyDivState.ZeroMinus:   // 0+�}�C�i�X���z
                        outMoneyDivName = ct_OutMoneyDiv_ZeroMinus;
                        break;
                    case OutMoneyDivState.Minus:       // �}�C�i�X���z
                        outMoneyDivName = ct_OutMoneyDiv_Minus;
                        break;
                    default:
                        outMoneyDivName = string.Empty;
                        break;
                }
                return outMoneyDivName;
            }
        }

        #region �� Public Enum
        #region �� ���[�^�C�v�敪�񋓑�
        /// <summary> ���[�^�C�v�敪�񋓑� </summary>
        public enum PrintDivState
        {
            /// <summary> ���׃^�C�v </summary>
            Detail = 1,
            /// <summary> �`�[�^�C�v </summary>
            Slip = 2
        }
        #endregion

        #region �� �o�͋��z�敪�񋓑�
        /// <summary> �o�͋��z�敪�񋓑� </summary>
        public enum OutMoneyDivState
        {
            /// <summary>�S��</summary>
            All = 0,
            /// <summary>0+�v���X���z</summary>
            ZeroPlus = 1,
            /// <summary>�v���X���z</summary>
            Plus = 2,
            /// <summary>0�o��</summary>
            Zero = 3,
            /// <summary>�v���X���z+�}�C�i�X���z</summary>
            PlusMinus = 4,
            /// <summary>0+�}�C�i�X���z</summary>
            ZeroMinus = 5,
            /// <summary>�}�C�i�X���z</summary>
            Minus = 6
        }
        #endregion ��
        #endregion �� Public Enum

        /// <summary>
		/// �����ꊇ���o����UI�f�[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <returns>CsLedgerCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CsLedgerCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public LedgerCmnCndtn()
		{
		}

		/// <summary>
		/// �����ꊇ���o����UI�f�[�^�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="isOptSection">���_�I�v�V���������敪</param>
        /// <param name="isMainOfficeFunc">�{�Ћ@�\�v���p�e�B</param>
        /// <param name="addupSecCodeList">�I���v�㋒�_�R�[�h</param>
        /// <param name="printDiv">���[�^�C�v�敪</param>
        /// <param name="printDivName">���[�^�C�v�敪����</param>
        /// <param name="startTargetYearMonth">�o�͑Ώ۔N��(�J�n)</param>
		/// <param name="endTargetYearMonth">�o�͑Ώ۔N��(�I��)</param>
		/// <param name="printOder">�o�͏�</param>
		/// <param name="startCustomerCode">���Ӑ�R�[�h(�J�n)</param>
		/// <param name="endCustomerCode">���Ӑ�R�[�h(�I��)</param>
		/// <param name="startCustomerKana">���Ӑ�J�i(�J�n)(ALL��=TOP)</param>
		/// <param name="endCustomerKana">���Ӑ�J�i(�I��)(ALL��=END)</param>
		/// <param name="customerAgentDivCd">�ڋq�S���ҋ敪(0:�ڋq�S����,1:�W���S����)</param>
		/// <param name="startEmployeeCode">�]�ƈ��R�[�h(�J�n)</param>
		/// <param name="endEmployeeCode">�]�ƈ��R�[�h(�I��)</param>
		/// <param name="listDivCode">�o�͒��[�敪(0:�����c,1:���|�c)</param>
		/// <param name="printDivCode">����敪(0:���P�ʂň��,1:�w��ŏI���ɔ͈͓��̖��ׂ��ꊇ���)</param>
		/// <param name="isJudgeBillOutputCode">�������o�͋敪</param>
		/// <param name="isJudgeZeroPrint">�J�z�c�O����敪(True:�������,False:������Ȃ�)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="addUpSecName">�v�㋒�_����</param>
        /// <param name="outMoneyDiv">�o�͋��z�敪</param>
        /// <returns>CsLedgerCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CsLedgerCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public LedgerCmnCndtn(string enterpriseCode, bool isOptSection, bool isMainOfficeFunc, ArrayList addupSecCodeList, Int32 printDiv, string printDivName, Int32 startTargetYearMonth, Int32 endTargetYearMonth, Int32 printOder, Int32 startCustomerCode, Int32 endCustomerCode, string startCustomerKana, string endCustomerKana, Int32 customerAgentDivCd, string startEmployeeCode, string endEmployeeCode, Int32 listDivCode, Int32 printDivCode, bool isJudgeBillOutputCode, bool isJudgeZeroPrint, string enterpriseName, string addUpSecName, OutMoneyDivState outMoneyDiv)
		{
			this._enterpriseCode = enterpriseCode;
            this._isOptSection = isOptSection;
            this._isMainOfficeFunc = isMainOfficeFunc;
            this._addupSecCodeList = addupSecCodeList;
            this._printDiv = printDiv;
            this._printDivName = printDivName;
			this._startTargetYearMonth = startTargetYearMonth;
			this._endTargetYearMonth = endTargetYearMonth;
			this._printOder = printOder;
			this._startCustomerCode = startCustomerCode;
			this._endCustomerCode = endCustomerCode;
			this._startCustomerKana = startCustomerKana;
			this._endCustomerKana = endCustomerKana;
			this._customerAgentDivCd = customerAgentDivCd;
			this._startEmployeeCode = startEmployeeCode;
			this._endEmployeeCode = endEmployeeCode;
			this._listDivCode = listDivCode;
			this._printDivCode = printDivCode;
			this._isJudgeBillOutputCode = isJudgeBillOutputCode;
			this._isJudgeZeroPrint = isJudgeZeroPrint;
			this._enterpriseName = enterpriseName;
			this._addUpSecName = addUpSecName;
            this._outMoneyDiv = outMoneyDiv;
		}

		/// <summary>
		/// �����ꊇ���o����UI�f�[�^�N���X��������
		/// </summary>
		/// <returns>CsLedgerCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CsLedgerCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public LedgerCmnCndtn Clone()
		{
            return new LedgerCmnCndtn(this._enterpriseCode, this._isOptSection, this._isMainOfficeFunc, this._addupSecCodeList, this._printDiv, this._printDivName, this._startTargetYearMonth, this._endTargetYearMonth, this._printOder, this._startCustomerCode, this._endCustomerCode, this._startCustomerKana, this._endCustomerKana, this._customerAgentDivCd, this._startEmployeeCode, this._endEmployeeCode, this._listDivCode, this._printDivCode, this._isJudgeBillOutputCode, this._isJudgeZeroPrint, this._enterpriseName, this._addUpSecName, this._outMoneyDiv);
		}

		/// <summary>
		/// �����ꊇ���o����UI�f�[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CsLedgerCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CsLedgerCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(LedgerCmnCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsMainOfficeFunc == target.IsMainOfficeFunc)
                 && (this.AddupSecCodeList == target.AddupSecCodeList)
                 && (this.PrintDiv == target.PrintDiv)
                 && (this.PrintDivName == target.PrintDivName)
				 && (this.StartTargetYearMonth == target.StartTargetYearMonth)
				 && (this.EndTargetYearMonth == target.EndTargetYearMonth)
				 && (this.PrintOder == target.PrintOder)
				 && (this.StartCustomerCode == target.StartCustomerCode)
				 && (this.EndCustomerCode == target.EndCustomerCode)
				 && (this.StartCustomerKana == target.StartCustomerKana)
				 && (this.EndCustomerKana == target.EndCustomerKana)
				 && (this.CustomerAgentDivCd == target.CustomerAgentDivCd)
				 && (this.StartEmployeeCode == target.StartEmployeeCode)
				 && (this.EndEmployeeCode == target.EndEmployeeCode)
				 && (this.ListDivCode == target.ListDivCode)
				 && (this.PrintDivCode == target.PrintDivCode)
				 && (this.IsJudgeBillOutputCode == target.IsJudgeBillOutputCode)
				 && (this.IsJudgeZeroPrint == target.IsJudgeZeroPrint)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.AddUpSecName == target.AddUpSecName)
                 && (this.OutMoneyDiv == target.OutMoneyDiv));
		}

		/// <summary>
		/// �����ꊇ���o����UI�f�[�^�N���X��r����
		/// </summary>
		/// <param name="csLedgerCndtn1">
		///                    ��r����CsLedgerCndtn�N���X�̃C���X�^���X
		/// </param>
		/// <param name="csLedgerCndtn2">��r����CsLedgerCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CsLedgerCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(LedgerCmnCndtn csLedgerCndtn1, LedgerCmnCndtn csLedgerCndtn2)
		{
			return ((csLedgerCndtn1.EnterpriseCode == csLedgerCndtn2.EnterpriseCode)
				 && (csLedgerCndtn1.IsOptSection == csLedgerCndtn2.IsOptSection)
                 && (csLedgerCndtn1.IsMainOfficeFunc == csLedgerCndtn2.IsMainOfficeFunc)
                 && (csLedgerCndtn1.AddupSecCodeList == csLedgerCndtn2.AddupSecCodeList)
                 && (csLedgerCndtn1.PrintDiv == csLedgerCndtn2.PrintDiv)
                 && (csLedgerCndtn1.PrintDivName == csLedgerCndtn2.PrintDivName)
                 && (csLedgerCndtn1.StartTargetYearMonth == csLedgerCndtn2.StartTargetYearMonth)
				 && (csLedgerCndtn1.EndTargetYearMonth == csLedgerCndtn2.EndTargetYearMonth)
				 && (csLedgerCndtn1.PrintOder == csLedgerCndtn2.PrintOder)
				 && (csLedgerCndtn1.StartCustomerCode == csLedgerCndtn2.StartCustomerCode)
				 && (csLedgerCndtn1.EndCustomerCode == csLedgerCndtn2.EndCustomerCode)
				 && (csLedgerCndtn1.StartCustomerKana == csLedgerCndtn2.StartCustomerKana)
				 && (csLedgerCndtn1.EndCustomerKana == csLedgerCndtn2.EndCustomerKana)
				 && (csLedgerCndtn1.CustomerAgentDivCd == csLedgerCndtn2.CustomerAgentDivCd)
				 && (csLedgerCndtn1.StartEmployeeCode == csLedgerCndtn2.StartEmployeeCode)
				 && (csLedgerCndtn1.EndEmployeeCode == csLedgerCndtn2.EndEmployeeCode)
				 && (csLedgerCndtn1.ListDivCode == csLedgerCndtn2.ListDivCode)
				 && (csLedgerCndtn1.PrintDivCode == csLedgerCndtn2.PrintDivCode)
				 && (csLedgerCndtn1.IsJudgeBillOutputCode == csLedgerCndtn2.IsJudgeBillOutputCode)
				 && (csLedgerCndtn1.IsJudgeZeroPrint == csLedgerCndtn2.IsJudgeZeroPrint)
				 && (csLedgerCndtn1.EnterpriseName == csLedgerCndtn2.EnterpriseName)
				 && (csLedgerCndtn1.AddUpSecName == csLedgerCndtn2.AddUpSecName)
                 && (csLedgerCndtn1.OutMoneyDiv == csLedgerCndtn2.OutMoneyDiv));
		}
		/// <summary>
		/// �����ꊇ���o����UI�f�[�^�N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CsLedgerCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CsLedgerCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(LedgerCmnCndtn target)
		{
			ArrayList resList = new ArrayList();
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsMainOfficeFunc != target.IsMainOfficeFunc) resList.Add("IsMainOfficeFunc");
            if (this.AddupSecCodeList != target.AddupSecCodeList) resList.Add("AddupSecCodeList");
            if (this.PrintDiv != target.PrintDiv) resList.Add("PrintDiv");
            if (this.PrintDivName != target.PrintDivName) resList.Add("PrintDivName");
			if (this.StartTargetYearMonth != target.StartTargetYearMonth) resList.Add("StartTargetYearMonth");
			if (this.EndTargetYearMonth != target.EndTargetYearMonth) resList.Add("EndTargetYearMonth");
			if (this.PrintOder != target.PrintOder) resList.Add("PrintOder");
			if (this.StartCustomerCode != target.StartCustomerCode) resList.Add("StartCustomerCode");
			if (this.EndCustomerCode != target.EndCustomerCode) resList.Add("EndCustomerCode");
			if (this.StartCustomerKana != target.StartCustomerKana) resList.Add("StartCustomerKana");
			if (this.EndCustomerKana != target.EndCustomerKana) resList.Add("EndCustomerKana");
			if (this.CustomerAgentDivCd != target.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if (this.StartEmployeeCode != target.StartEmployeeCode) resList.Add("StartEmployeeCode");
			if (this.EndEmployeeCode != target.EndEmployeeCode) resList.Add("EndEmployeeCode");
			if (this.ListDivCode != target.ListDivCode) resList.Add("ListDivCode");
			if (this.PrintDivCode != target.PrintDivCode) resList.Add("PrintDivCode");
			if (this.IsJudgeBillOutputCode != target.IsJudgeBillOutputCode) resList.Add("IsJudgeBillOutputCode");
			if (this.IsJudgeZeroPrint != target.IsJudgeZeroPrint) resList.Add("IsJudgeZeroPrint");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.OutMoneyDiv != target.OutMoneyDiv) resList.Add("OutMoneyDiv");

			return resList;
		}

		/// <summary>
		/// �����ꊇ���o����UI�f�[�^�N���X��r����
		/// </summary>
		/// <param name="csLedgerCndtn1">��r����CsLedgerCndtn�N���X�̃C���X�^���X</param>
		/// <param name="csLedgerCndtn2">��r����CsLedgerCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CsLedgerCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(LedgerCmnCndtn csLedgerCndtn1, LedgerCmnCndtn csLedgerCndtn2)
		{
			ArrayList resList = new ArrayList();
			if (csLedgerCndtn1.EnterpriseCode != csLedgerCndtn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (csLedgerCndtn1.IsOptSection != csLedgerCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (csLedgerCndtn1.IsMainOfficeFunc != csLedgerCndtn2.IsMainOfficeFunc) resList.Add("IsMainOfficeFunc");
            if (csLedgerCndtn1.AddupSecCodeList != csLedgerCndtn2.AddupSecCodeList) resList.Add("AddupSecCodeList");
            if (csLedgerCndtn1.PrintDiv != csLedgerCndtn2.PrintDiv) resList.Add("PrintDiv");
            if (csLedgerCndtn1.PrintDivName != csLedgerCndtn2.PrintDivName) resList.Add("PrintDivName");
			if (csLedgerCndtn1.StartTargetYearMonth != csLedgerCndtn2.StartTargetYearMonth) resList.Add("StartTargetYearMonth");
			if (csLedgerCndtn1.EndTargetYearMonth != csLedgerCndtn2.EndTargetYearMonth) resList.Add("EndTargetYearMonth");
			if (csLedgerCndtn1.PrintOder != csLedgerCndtn2.PrintOder) resList.Add("PrintOder");
			if (csLedgerCndtn1.StartCustomerCode != csLedgerCndtn2.StartCustomerCode) resList.Add("StartCustomerCode");
			if (csLedgerCndtn1.EndCustomerCode != csLedgerCndtn2.EndCustomerCode) resList.Add("EndCustomerCode");
			if (csLedgerCndtn1.StartCustomerKana != csLedgerCndtn2.StartCustomerKana) resList.Add("StartCustomerKana");
			if (csLedgerCndtn1.EndCustomerKana != csLedgerCndtn2.EndCustomerKana) resList.Add("EndCustomerKana");
			if (csLedgerCndtn1.CustomerAgentDivCd != csLedgerCndtn2.CustomerAgentDivCd) resList.Add("CustomerAgentDivCd");
			if (csLedgerCndtn1.StartEmployeeCode != csLedgerCndtn2.StartEmployeeCode) resList.Add("StartEmployeeCode");
			if (csLedgerCndtn1.EndEmployeeCode != csLedgerCndtn2.EndEmployeeCode) resList.Add("EndEmployeeCode");
			if (csLedgerCndtn1.ListDivCode != csLedgerCndtn2.ListDivCode) resList.Add("ListDivCode");
			if (csLedgerCndtn1.PrintDivCode != csLedgerCndtn2.PrintDivCode) resList.Add("PrintDivCode");
			if (csLedgerCndtn1.IsJudgeBillOutputCode != csLedgerCndtn2.IsJudgeBillOutputCode) resList.Add("IsJudgeBillOutputCode");
			if (csLedgerCndtn1.IsJudgeZeroPrint != csLedgerCndtn2.IsJudgeZeroPrint) resList.Add("IsJudgeZeroPrint");
			if (csLedgerCndtn1.EnterpriseName != csLedgerCndtn2.EnterpriseName) resList.Add("EnterpriseName");
			if (csLedgerCndtn1.AddUpSecName != csLedgerCndtn2.AddUpSecName) resList.Add("AddUpSecName");
            if (csLedgerCndtn1.OutMoneyDiv != csLedgerCndtn2.OutMoneyDiv) resList.Add("OutMoneyDiv");

			return resList;
		}
	}
}
