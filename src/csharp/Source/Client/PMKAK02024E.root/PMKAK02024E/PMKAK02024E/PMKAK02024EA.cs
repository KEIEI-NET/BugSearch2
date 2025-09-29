//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���|�c���ꗗ�\(����)���o�����N���X
// �v���O�����T�v   : ���|�c���ꗗ�\(����)���o�����N���X�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�y�~ �їR��
// �� �� ��  2012/09/14  �C�����e : �V�K�쐬 �d�������@�\�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00 �쐬�S�� : 3H ������
// �C �� ��  2020/04/10  �C�����e : �y���ŗ��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SumAccPaymentListCndtn
    /// <summary>
    ///                      ���|�c���ꗗ�\(����)���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���|�c���ꗗ�\(����)���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>UpdateNote       :   11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer       :   3H ������</br>
    /// <br>Date	         :   2020/04/10</br>
    /// </remarks>
    public class SumAccPaymentListCndtn�@�@
	{
		#region �� Private Member
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h�i�����w��j</summary>
        /// <remarks>�i�z��j</remarks>
        private string[] _sectionCodes = new string[0];

        /// <summary>�v��N����</summary>
        private DateTime _addUpDate;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>�J�n������R�[�h</summary>
        private Int32 _st_PayeeCode;

        /// <summary>�I��������R�[�h</summary>
        private Int32 _ed_PayeeCode;

        /// <summary>�o�͋��z�敪</summary>
        /// <remarks>0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:��׽��ϲŽ 5:0��ϲŽ 6:ϲŽ�̂�</remarks>
        private OutMoneyDivState _outMoneyDiv;

        /// <summary>����</summary>
        private Int32 _newPageType;

        /// <summary>��������敪</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _sumSuppDtlDiv;

        /// <summary>�x������敪</summary>
        /// <remarks>0:�󎚂��� 1:�󎚂��Ȃ�</remarks>
        private Int32 _payDtlDiv;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
        /// <summary>�ŕʓ���󎚋敪</summary>
        private Int32 _taxPrintDiv;

        /// <summary>�ŗ�1</summary>
        private Double _taxRate1;

        /// <summary>�ŗ�2</summary>
        private Double _taxRate2;
        // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
		#endregion �� Private Member

        #region �� Public Property
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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
        /// <value>�i�z��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  St_PayeeCode
        /// <summary>�J�n������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_PayeeCode
        {
            get { return _st_PayeeCode; }
            set { _st_PayeeCode = value; }
        }

        /// public propaty name  :  Ed_PayeeCode
        /// <summary>�I��������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_PayeeCode
        {
            get { return _ed_PayeeCode; }
            set { _ed_PayeeCode = value; }
        }

        /// public propaty name  :  OutMoneyDiv
        /// <summary>�o�͋��z�敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:��׽��ϲŽ 5:0��ϲŽ 6:ϲŽ�̂�</value>
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

        /// public propaty name  :  SumSuppDtlDiv
        /// <summary>��������敪�v���p�e�B</summary>
        /// <value>0:�󎚂��� 1:�󎚂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SumSuppDtlDiv
        {
            get { return _sumSuppDtlDiv; }
            set { _sumSuppDtlDiv = value; }
        }

        /// public propaty name  :  PayDtlDiv
        /// <summary>�x������敪�v���p�e�B</summary>
        /// <value>0:�󎚂��� 1:�󎚂��Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayDtlDiv
        {
            get { return _payDtlDiv; }
            set { _payDtlDiv = value; }
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
		#endregion �� Public Property

        #region �� Private Const (���������ȊO)
        /// <summary>���� ���t�t�H�[�}�b�g</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";
        /// <summary>���� ���t�t�H�[�}�b�g</summary>
        public const string ct_MonthFomat = "YYYY/MM";

        /// <summary>���� �S�� �R�[�h</summary>
        public const int ct_All_Code = -1;
        /// <summary>���� �S�� ����</summary>
        public const string ct_All_Name = "�S��";

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

        #region �� Public Member (���������ȊO)
        /// <summary>
        /// ���_�I�v�V�����敪
        /// </summary>
        private bool _isOptSection = false;
        /// <summary>
        /// �S���_�I���敪
        /// </summary>
        private bool _isSelectAllSection = false;
        #endregion

        #region �� Public Property (���������ȊO)
        /// <summary>
        /// ���_�I�v�V�����敪�v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// �S���_�I���敪�v���p�e�B
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
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
                switch ( this._outMoneyDiv )
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

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
        /// <summary>�ŕʓ���󎚋敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŕʓ���󎚋敪</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxPrintDiv
        {
            get { return _taxPrintDiv; }
            set { _taxPrintDiv = value; }
        }

        /// public propaty name  :  TaxRate1
        /// <summary>�ŗ�1</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�1</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate1
        {
            get { return _taxRate1; }
            set { _taxRate1 = value; }
        }

        /// public propaty name  :  TaxRate2
        /// <summary>�ŗ�2</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŗ�2</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TaxRate2
        {
            get { return _taxRate2; }
            set { _taxRate2 = value; }
        }
        // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
        #endregion

        #region �� Public Enum (���������ȊO)
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
            Minus = 6,
        }
        #endregion ��
        #endregion

        #region �� Constructor
        /// <summary>
		/// �R���X�g���N�^
		/// </summary>
        /// <returns>AccPaymentListCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccPaymentListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SumAccPaymentListCndtn ()
		{
		}
		#endregion �� Constructor

	}
}
