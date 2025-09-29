//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �x���`�[����
// �v���O�����T�v   : �x���`�[���͂̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �C �� ��  2010/03/26  �C�����e : MANTIS�y15200�z0�~�x���ۑ����ɢ�����ʣ��\�����A�I����ɓo�^�֕ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �C �� ��  2010/04/30  �C�����e : MANTIS�y15200�z�C���ďo���͓o�^������f�t�H���g�ŕ\��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �C �� ��  2010/05/12  �C�����e : MANTIS�y15200�z����0���C���ďo���A�����ύX����ƁA�O��̋��킪�c��
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
using Broadleaf.Application.UIData;

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
    public partial class SFSIR02102UF : Form
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

        #region �x���`�[�}�X�^���R�[�h

        /// <summary>�x���`�[�}�X�^���R�[�h</summary>
        private readonly PaymentSlp _paymentSlpRecord;
        /// <summary>�x���`�[�}�X�^���R�[�h</summary>
        private PaymentSlp PaymentSlpRecord { get { return _paymentSlpRecord; } }
        
        // ADD 2010/04/30 MANTIS�Ή�[15200]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ---------->>>>>
        /// <summary>
        /// ���݂̋��햼�̂̃C���f�b�N�X���擾���܂��B
        /// </summary>
        private int CurrentKindNameIndex
        {
            get
            {
                string[] foundKindNames = Array.FindAll(
                    PaymentSlpRecord.MoneyKindNameDtl,
                delegate(string kindName)
                {
                    return !string.IsNullOrEmpty(kindName);
                });
                if (foundKindNames.Length > 1 || foundKindNames.Length.Equals(0)) return 0;

                int foundIndex = Array.FindIndex(
                    PaymentSlpRecord.MoneyKindNameDtl,
                delegate(string kindName)
                {
                    return !string.IsNullOrEmpty(kindName);
                });
                if (foundIndex >= 0) return foundIndex;

                return 0;
            }
        }
        // ADD 2010/04/30 MANTIS�Ή�[15200]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ----------<<<<<

        /// <summary>
        /// �x���`�[�}�X�^���R�[�h��ݒ肵�܂��B
        /// </summary>
        /// <param name="selectedMoneyKind">�I�����ꂽ���퍀��</param>
        private void SetPaymentSlpRecord(MoneyKindItem selectedMoneyKind)
        {
            // ����R�[�h
            int moneyKindCode = selectedMoneyKind.MoneyKindCode;
            // ���햼��
            string moneyKindName = selectedMoneyKind.MoneyKindName;
            // ����敪
            int moneyKindDiv = selectedMoneyKind.MoneyKindDiv;
            // �x���s�ԍ�
            int paymentRowNo = selectedMoneyKind.RowNo;
            // �x�����z
            double payment = selectedMoneyKind.Amount;
            // ����
            DateTime validityTerm = selectedMoneyKind.ValidityTerm;

            // ADD 2010/05/12 MANTIS�Ή�[15200]�F����0���C���ďo���A�����ύX����ƁA�O��̋��킪�c�� ---------->>>>>
            // �������i�S�N���A�j
            for (int i = 0; i < PaymentSlpRecord.PaymentRowNoDtl.Length; i++)
            {
                PaymentSlpRecord.PaymentRowNoDtl[i] = 0;
                PaymentSlpRecord.MoneyKindCodeDtl[i]= 0;
                PaymentSlpRecord.MoneyKindNameDtl[i]= string.Empty;
                PaymentSlpRecord.MoneyKindDivDtl[i] = 0;
                PaymentSlpRecord.PaymentDtl[i]      = 0;
                PaymentSlpRecord.ValidityTermDtl[i] = DateTime.MinValue;
            }
            // ADD 2010/05/12 MANTIS�Ή�[15200]�F����0���C���ďo���A�����ύX����ƁA�O��̋��킪�c�� ----------<<<<<

            PaymentSlpRecord.PaymentRowNoDtl[paymentRowNo - 1] = paymentRowNo;
            PaymentSlpRecord.MoneyKindCodeDtl[paymentRowNo - 1] = moneyKindCode;
            PaymentSlpRecord.MoneyKindNameDtl[paymentRowNo - 1] = moneyKindName;
            PaymentSlpRecord.MoneyKindDivDtl[paymentRowNo - 1] = moneyKindDiv;
            PaymentSlpRecord.PaymentDtl[paymentRowNo - 1] = (long)payment;
            PaymentSlpRecord.ValidityTermDtl[paymentRowNo - 1] = validityTerm;
        }

        #endregion // �x���`�[�}�X�^���R�[�h

        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="paymentKindGrid">�x������O���b�h</param>
        /// <param name="paymentSlpRecord">�x���`�[�}�X�^���R�[�h</param>
        public SFSIR02102UF(
            UltraGrid paymentKindGrid,
            PaymentSlp paymentSlpRecord
        )
        {
            #region DesignerCode

            InitializeComponent();

            #endregion // DesignerCode

            _moneyKindGrid  = paymentKindGrid;
            _paymentSlpRecord = paymentSlpRecord;
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
            this.tcboPaymentKind.Clear();

            if (MoneyKindGrid == null) return;

            int paymentRowNo = 0;
            for (int i = 0; i < MoneyKindGrid.Rows.Count; i++)
            {
                paymentRowNo++;

                DateTime validityTerm = DateTime.MinValue;
                TakeValidityTerm(i, out validityTerm);

                this.tcboPaymentKind.Items.Add(new MoneyKindItem(
                    0.0,            // �x�����z�F0 �~�i�Œ�j
                    validityTerm,   // �L������
                    paymentRowNo,
                    (int)MoneyKindGrid.Rows[i].Cells[SFSIR02102UA.ctMoneyKindCode].Value,
                    (int)MoneyKindGrid.Rows[i].Cells[SFSIR02102UA.ctMoneyKindDiv].Value,
                    MoneyKindGrid.Rows[i].Cells[SFSIR02102UA.ctMoneyKindName].Value.ToString()
                ));
            }

            if (this.tcboPaymentKind.Items.Count > 0)
            {
                this.tcboPaymentKind.Enabled = true;
                // DEL 2010/04/30 MANTIS�Ή�[15200]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ---------->>>>>
                //this.tcboPaymentKind.SelectedIndex = 0; // �擪��I��
                // DEL 2010/04/30 MANTIS�Ή�[15200]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ----------<<<<<
                // ADD 2010/04/30 MANTIS�Ή�[15200]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ---------->>>>>
                this.tcboPaymentKind.SelectedIndex = CurrentKindNameIndex;
                // ADD 2010/04/30 MANTIS�Ή�[15200]�F�C���ďo���͓o�^������f�t�H���g�ŕ\�� ----------<<<<<
            }
            else
            {
                this.tcboPaymentKind.Enabled = false;
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
            MoneyKindItem selectedMoneyKind = (MoneyKindItem)this.tcboPaymentKind.Value;

            // �x���`�[�}�X�^���R�[�h��ݒ�
            SetPaymentSlpRecord(selectedMoneyKind);

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