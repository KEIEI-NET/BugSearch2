//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �����`�[���́i�����^�j
// �v���O�����T�v   : �����`�[���͂̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �C �� ��  2010/03/25  �C�����e : MANTIS�y15195�z0�~�����ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �C �� ��  2010/04/30  �C�����e : MANTIS�y15195�z�C���ďo���͓o�^������f�t�H���g�ŕ\��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �C �� ��  2010/05/12  �C�����e : MANTIS�y15195�z����0���C���ďo���A�����ύX����ƁA�O��̋��킪�c��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L������������O���b�h����擾����f���Q�[�g
    /// </summary>
    /// <param name="index">�O���b�h�̃C���f�b�N�X(0�`)</param>
    /// <param name="validityTerm">�L������</param>
    public delegate bool TakeValidityTerm(int index, out DateTime validityTerm);

    /// <summary>
    /// ����I����ʃt�H�[��
    /// </summary>
    public partial class SFUKK01403UC : Form
    {
        #region ���퍀��

        /// <summary>
        /// ���퍀�ڍ\����
        /// </summary>
        private struct MoneyKindItem
        {
            #region ���z

            /// <summary>���z</summary>
            private double _amount;
            /// <summary>���z���擾�܂��͐ݒ肵�܂��B</summary>
            public double Amount
            {
                get { return _amount; }
                set { _amount = value; }
            }

            #endregion // ���z

            #region �L������

            /// <summary>�L������</summary>
            private DateTime _validityTerm;
            /// <summary>�L���������擾�܂��͐ݒ肵�܂��B</summary>
            public DateTime ValidityTerm
            {
                get { return _validityTerm; }
                set { _validityTerm = value; }
            }

            #endregion // �L������

            #region �s�ԍ�

            /// <summary>�s�ԍ�</summary>
            private int _rowNo;
            /// <summary>�s�ԍ����擾�܂��͐ݒ肵�܂��B</summary>
            public int RowNo
            {
                get { return _rowNo; }
                set { _rowNo = value; }
            }

            #endregion // �s�ԍ�

            #region ����R�[�h

            /// <summary>����R�[�h</summary>
            private int _moneyKindCode;
            /// <summary>����R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
            public int MoneyKindCode
            {
                get { return _moneyKindCode; }
                set { _moneyKindCode = value; }
            }

            #endregion // ����R�[�h

            #region ����敪

            /// <summary>����敪</summary>
            private int _moneyKindDiv;
            /// <summary>����敪���擾�܂��͐ݒ肵�܂��B</summary>
            public int MoneyKindDiv
            {
                get { return _moneyKindDiv; }
                set { _moneyKindDiv = value; }
            }

            #endregion // ����敪

            #region ���햼��

            /// <summary>���햼��</summary>
            private string _moneyKindName;
            /// <summary>���햼�̂��擾�܂��͐ݒ肵�܂��B</summary>
            public string MoneyKindName
            {
                get { return _moneyKindName; }
                set { _moneyKindName = value; }
            }

            #endregion // ���햼��

            #region Constructor

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            /// <param name="amount">���z</param>
            /// <param name="validityTerm">�L������</param>
            /// <param name="rowNo">�s�ԍ�</param>
            /// <param name="moneyKindCode">����R�[�h</param>
            /// <param name="moneyKindDiv">����敪</param>
            /// <param name="moneyKindName">���햼��</param>
            public MoneyKindItem(
                double amount,
                DateTime validityTerm,
                int rowNo,
                int moneyKindCode,
                int moneyKindDiv,
                string moneyKindName
            )
            {
                _amount = amount;
                _validityTerm = validityTerm;
                _rowNo = rowNo;
                _moneyKindCode = moneyKindCode;
                _moneyKindDiv = moneyKindDiv;
                _moneyKindName = moneyKindName;
            }

            #endregion // Constructor

            #region Override

            /// <summary>
            /// ������ɕϊ����܂��B
            /// </summary>
            /// <returns><c>DepositStKindCdNm</c></returns>
            public override string ToString()
            {
                return MoneyKindName;
            }

            #endregion // Override
        }

        #endregion // ���퍀��

        #region �������O���b�h

        /// <summary>�������O���b�h</summary>
        private readonly UltraGrid _moneyKindGrid;
        /// <summary>�������O���b�h���擾���܂��B</summary>
        private UltraGrid MoneyKindGrid { get { return _moneyKindGrid; } }

        /// <summary>�L������������O���b�h����擾����C�x���g</summary>
        public event TakeValidityTerm TakeValidityTerm = new TakeValidityTerm(
            delegate(int indexer, out DateTime payTimeLimit)
            {
                // �f�t�H���g�̗L������������O���b�h����擾����f���Q�[�g(�������Ȃ�)
                payTimeLimit = DateTime.MinValue;
                return true;
            }
        );

        #endregion // �������O���b�h

        #region �����O���b�h�I���s(�������X�V���e)

        /// <summary>�����O���b�h�I���s(�������X�V���e)</summary>
        private readonly DataRow _selectedDepositCopyRow;
        /// <summary>�����O���b�h�I���s(�������X�V���e)���擾���܂��B</summary>
        private DataRow SelectedDepositCopyRow { get { return _selectedDepositCopyRow; } }

        // ADD 2010/04/30 MANTIS�Ή�[15195]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ---------->>>>>
        /// <summary>
        /// ���݂̋��햼�̂��擾���܂��B
        /// </summary>
        private string CurrentKindName
        {
            get { return SelectedDepositCopyRow.ItemArray[12].ToString(); }
        }
        // ADD 2010/04/30 MANTIS�Ή�[15195]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ----------<<<<<

        /// <summary>
        /// �����O���b�h�I���s(�������X�V���e)��ݒ肵�܂��B
        /// </summary>
        /// <param name="selectedMoneyKind">�I�����ꂽ���퍀��</param>
        private void SetSelectedDepositCopyRow(MoneyKindItem selectedMoneyKind)
        {
            // ADD 2010/05/12 MANTIS�Ή�[15195]�F����0���C���ďo���A�����ύX����ƁA�O��̋��킪�c�� ---------->>>>>
            #region �������i�S�N���A�j
            
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit1]        = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm1]   = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo1]   = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode1]  = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv1]   = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName1]  = string.Empty;     // ���햼��

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit2]        = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm2]   = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo2]   = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode2]  = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv2]   = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName2]  = string.Empty;     // ���햼��

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit3]        = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm3]   = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo3]   = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode3]  = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv3]   = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName3]  = string.Empty;     // ���햼��

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit4]        = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm4]   = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo4]   = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode4]  = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv4]   = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName4]  = string.Empty;     // ���햼��

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit5]        = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm5]   = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo5]   = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode5]  = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv5]   = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName5]  = string.Empty;     // ���햼��

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit6]        = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm6]   = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo6]   = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode6]  = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv6]   = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName6]  = string.Empty;     // ���햼��

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit7]        = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm7]   = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo7]   = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode7]  = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv7]   = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName7]  = string.Empty;     // ���햼��

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit8]        = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm8]   = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo8]   = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode8]  = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv8]   = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName8]  = string.Empty;     // ���햼��

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit9]        = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm9]   = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo9]   = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode9]  = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv9]   = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName9]  = string.Empty;     // ���햼��

            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit10]       = 0.0;              // �������z
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm10]  = DateTime.MinValue;// �L������
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo10]  = 0;                // �����s�ԍ�
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode10] = 0;                // ����R�[�h
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv10]  = 0;                // ����敪
            SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName10] = string.Empty;     // ���햼��

            #endregion // �������i�S�N���A�j
            // ADD 2010/05/12 MANTIS�Ή�[15195]�F����0���C���ďo���A�����ύX����ƁA�O��̋��킪�c�� ----------<<<<<

            switch (selectedMoneyKind.RowNo)
            {
                case 1:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit1] = selectedMoneyKind.Amount;                // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm1] = selectedMoneyKind.ValidityTerm;     // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo1] = selectedMoneyKind.RowNo;            // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode1] = selectedMoneyKind.MoneyKindCode;   // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv1] = selectedMoneyKind.MoneyKindDiv;     // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName1] = selectedMoneyKind.MoneyKindName;   // ���햼��
                }
                    break;
                case 2:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit2] = selectedMoneyKind.Amount;                // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm2] = selectedMoneyKind.ValidityTerm;     // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo2] = selectedMoneyKind.RowNo;            // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode2] = selectedMoneyKind.MoneyKindCode;   // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv2] = selectedMoneyKind.MoneyKindDiv;     // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName2] = selectedMoneyKind.MoneyKindName;   // ���햼��
                }
                    break;
                case 3:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit3] = selectedMoneyKind.Amount;                // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm3] = selectedMoneyKind.ValidityTerm;     // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo3] = selectedMoneyKind.RowNo;            // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode3] = selectedMoneyKind.MoneyKindCode;   // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv3] = selectedMoneyKind.MoneyKindDiv;     // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName3] = selectedMoneyKind.MoneyKindName;   // ���햼��
                }
                    break;
                case 4:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit4] = selectedMoneyKind.Amount;                // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm4] = selectedMoneyKind.ValidityTerm;     // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo4] = selectedMoneyKind.RowNo;            // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode4] = selectedMoneyKind.MoneyKindCode;   // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv4] = selectedMoneyKind.MoneyKindDiv;     // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName4] = selectedMoneyKind.MoneyKindName;   // ���햼��
                }
                    break;
                case 5:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit5] = selectedMoneyKind.Amount;                // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm5] = selectedMoneyKind.ValidityTerm;     // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo5] = selectedMoneyKind.RowNo;            // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode5] = selectedMoneyKind.MoneyKindCode;   // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv5] = selectedMoneyKind.MoneyKindDiv;     // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName5] = selectedMoneyKind.MoneyKindName;   // ���햼��
                }
                    break;
                case 6:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit6] = selectedMoneyKind.Amount;                // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm6] = selectedMoneyKind.ValidityTerm;     // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo6] = selectedMoneyKind.RowNo;            // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode6] = selectedMoneyKind.MoneyKindCode;   // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv6] = selectedMoneyKind.MoneyKindDiv;     // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName6] = selectedMoneyKind.MoneyKindName;   // ���햼��
                }
                    break;
                case 7:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit7] = selectedMoneyKind.Amount;                // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm7] = selectedMoneyKind.ValidityTerm;     // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo7] = selectedMoneyKind.RowNo;            // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode7] = selectedMoneyKind.MoneyKindCode;   // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv7] = selectedMoneyKind.MoneyKindDiv;     // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName7] = selectedMoneyKind.MoneyKindName;   // ���햼��
                }
                    break;
                case 8:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit8] = selectedMoneyKind.Amount;                // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm8] = selectedMoneyKind.ValidityTerm;     // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo8] = selectedMoneyKind.RowNo;            // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode8] = selectedMoneyKind.MoneyKindCode;   // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv8] = selectedMoneyKind.MoneyKindDiv;     // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName8] = selectedMoneyKind.MoneyKindName;   // ���햼��
                }
                    break;
                case 9:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit9] = selectedMoneyKind.Amount;                // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm9] = selectedMoneyKind.ValidityTerm;     // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo9] = selectedMoneyKind.RowNo;            // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode9] = selectedMoneyKind.MoneyKindCode;   // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv9] = selectedMoneyKind.MoneyKindDiv;     // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName9] = selectedMoneyKind.MoneyKindName;   // ���햼��
                }
                    break;
                case 10:
                {
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDeposit10] = selectedMoneyKind.Amount;               // �������z
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctValidityTerm10] = selectedMoneyKind.ValidityTerm;    // �L������
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctDepositRowNo10] = selectedMoneyKind.RowNo;           // �����s�ԍ�
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindCode10] = selectedMoneyKind.MoneyKindCode;  // ����R�[�h
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindDiv10] = selectedMoneyKind.MoneyKindDiv;    // ����敪
                    SelectedDepositCopyRow[InputDepositNormalTypeAcs.ctMoneyKindName10] = selectedMoneyKind.MoneyKindName;  // ���햼��
                }
                    break;
            }
        }

        #endregion // �����O���b�h�I���s(�������X�V���e)

        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="depositKindGrid">��������O���b�h</param>
        /// <param name="selectedDepositCopyRow">�����O���b�h�I���s(�������X�V���e)</param>
        public SFUKK01403UC(
            UltraGrid depositKindGrid,
            DataRow selectedDepositCopyRow
        )
        {
            #region DesignerCode

            InitializeComponent();

            #endregion // DesignerCode

            _moneyKindGrid = depositKindGrid;
            _selectedDepositCopyRow = selectedDepositCopyRow;
        }

        #endregion // Constructor

        #region �t�H�[��

        /// <summary>
        /// ����I����ʃt�H�[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void SFUKK01403UC_Load(object sender, EventArgs e)
        {
            // ����v���_�E����������
            this.tcboDepositKind.Clear();

            if (MoneyKindGrid == null) return;

            // ADD 2010/04/30 MANTIS�Ή�[15195]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ---------->>>>>
            List<string> kindNameList = new List<string>();
            // ADD 2010/04/30 MANTIS�Ή�[15195]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ----------<<<<<

            int depositRowNo = 0;
            for (int i = 0; i < MoneyKindGrid.Rows.Count; i++)
            {
                depositRowNo++;

                DateTime validityTerm = DateTime.MinValue;
                TakeValidityTerm(i, out validityTerm);

                this.tcboDepositKind.Items.Add(new MoneyKindItem(
                    0.0,            // �������z�F0 �~�i�Œ�j
                    validityTerm,   // �L������
                    depositRowNo,
                    (int)MoneyKindGrid.Rows[i].Cells[DepositRelDataAcs.ctDepositKindCode].Value,
                    (int)MoneyKindGrid.Rows[i].Cells[DepositRelDataAcs.ctDepositKindDiv].Value,
                    MoneyKindGrid.Rows[i].Cells[DepositRelDataAcs.ctDepositKindName].Value.ToString()
                ));
                // ADD 2010/04/30 MANTIS�Ή�[15195]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ---------->>>>>
                kindNameList.Add(MoneyKindGrid.Rows[i].Cells[DepositRelDataAcs.ctDepositKindName].Value.ToString());
                // ADD 2010/04/30 MANTIS�Ή�[15195]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ----------<<<<<
            }

            if (this.tcboDepositKind.Items.Count > 0)
            {
                this.tcboDepositKind.Enabled = true;

                // ADD 2010/04/30 MANTIS�Ή�[15195]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ---------->>>>>
                if (string.IsNullOrEmpty(CurrentKindName))
                {
                    this.tcboDepositKind.SelectedIndex = 0; // �擪��I��
                    return;
                }
                
                int foundIndex = kindNameList.FindIndex(delegate(string kindName)
                {
                    return kindName.Equals(CurrentKindName);
                });
                if (foundIndex >= 0 && foundIndex < kindNameList.Count)
                {
                    this.tcboDepositKind.SelectedIndex = foundIndex;
                    return;
                }
                // ADD 2010/04/30 MANTIS�Ή�[15195]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ----------<<<<<

                this.tcboDepositKind.SelectedIndex = 0; // �擪��I��
            }
            else
            {
                this.tcboDepositKind.Enabled = false;
            }
        }

        #endregion // �t�H�[��

        /// <summary>
        /// [OK]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ubtnOK_Click(object sender, EventArgs e)
        {
            MoneyKindItem selectedMoneyKind = (MoneyKindItem)this.tcboDepositKind.Value;

            // �����O���b�h�I���s(�������X�V���e)��ݒ�
            SetSelectedDepositCopyRow(selectedMoneyKind);

            DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// [�L�����Z��]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ubtnCancel_Click(object sender, EventArgs e)
        {
            // ���ɂ��邱�ƂȂ�
        }
    }
}