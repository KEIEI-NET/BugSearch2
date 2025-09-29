//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F����S�̐ݒ�}�X�^
// �v���O�����T�v   �F����S�̐ݒ�̓o�^�E�ύX�E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/05/14     �C�����e�F�i���\���Ή��F�i���\���敪�̏ڍאݒ��ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F�c����
// �C����    2010/12/03     �C�����e�F�i���\���敪�̏ڍאݒ��ʂɂg�d�k�o�{�^���̒ǉ�
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �i���\���p�^�[���ݒ��ʃt�H�[��
    /// </summary>
    public partial class DCKHN09210UB : Form
    {
        #region ����S�̐ݒ�t�H�[���̕i���\���敪

        /// <summary>����S�̐ݒ�t�H�[���̕i���\���敪</summary>
        private TComboEditor _ownerPartsNameDspDivCd;
        /// <summary>����S�̐ݒ�t�H�[���̕i���\���敪���擾�܂��͐ݒ肵�܂��B</summary>
        private TComboEditor OwnerPartsNameDspDivCd
        {
            get { return _ownerPartsNameDspDivCd; }
            set { _ownerPartsNameDspDivCd = value; }
        }

        #endregion // ����S�̐ݒ�t�H�[���̕i���\���敪

        #region �i���\���敪

        /// <summary>
        /// �i���\���敪���C�Ӑݒ�ł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�C�Ӑݒ�ł��B<br/>
        /// <c>false</c>:�C�Ӑݒ�ł͂���܂���B
        /// </returns>
        private bool IsOptionSetting()
        {
            return this.tcboPartsNameDspDivCd.SelectedIndex.Equals((int)SalesTtlSt.PartsNameDspDivCdValue.Option);
        }

        /// <summary>
        /// [�i���\���敪]�v���_�E����ValueChange�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tcboPartsNameDspDivCd_ValueChanged(object sender, EventArgs e)
        {
            EnabledPatternControlsByPartsNameDspDivCd();
        }

        /// <summary>�������̕i���\���敪�l</summary>
        private readonly int[] _prtsNmDspDivCdValues = new int[] {
            (int)SalesTtlSt.PrtsNmDspDivCdValue.None,
            (int)SalesTtlSt.PrtsNmDspDivCdValue.GoodsMaster,
            (int)SalesTtlSt.PrtsNmDspDivCdValue.PartsMaster,
            (int)SalesTtlSt.PrtsNmDspDivCdValue.SearchedGoodsNameMaster,
            (int)SalesTtlSt.PrtsNmDspDivCdValue.BLCodeMaster
        };
        /// <summary>�������̕i���\���敪�l���擾���܂��B</summary>
        private int[] PrtsNmDspDivCdValues { get { return _prtsNmDspDivCdValues; } }

        #endregion // �i���\���敪

        #region BL�R�[�h�����i���\���敪

        #region BL�R�[�h�����i���\���敪1

        /// <summary>BL�R�[�h�����i���\���敪1</summary>
        /// <remarks>0:����/1:���i�}�X�^/2:���i�}�X�^/3:�����i���}�X�^/4:BL�R�[�h�}�X�^</remarks>
        private int _blCdPrtsNmDspDivCd1;
        /// <summary>BL�R�[�h�����i���\���敪1���擾�܂��͐ݒ肵�܂��B</summary>
        public int BLCdPrtsNmDspDivCd1
        {
            get { return _blCdPrtsNmDspDivCd1; }
            private set { _blCdPrtsNmDspDivCd1 = value; }
        }

        #endregion // BL�R�[�h�����i���\���敪1

        #region BL�R�[�h�����i���\���敪2

        /// <summary>BL�R�[�h�����i���\���敪2</summary>
        /// <remarks>0:����/1:���i�}�X�^/2:���i�}�X�^/3:�����i���}�X�^/4:BL�R�[�h�}�X�^</remarks>
        private int _blCdPrtsNmDspDivCd2;
        /// <summary>BL�R�[�h�����i���\���敪2���擾�܂��͐ݒ肵�܂��B</summary>
        public int BLCdPrtsNmDspDivCd2
        {
            get { return _blCdPrtsNmDspDivCd2; }
            private set { _blCdPrtsNmDspDivCd2 = value; }
        }

        #endregion // BL�R�[�h�����i���\���敪2

        #region BL�R�[�h�����i���\���敪3

        /// <summary>BL�R�[�h�����i���\���敪3</summary>
        /// <remarks>0:����/1:���i�}�X�^/2:���i�}�X�^/3:�����i���}�X�^/4:BL�R�[�h�}�X�^</remarks>
        private int _blCdPrtsNmDspDivCd3;
        /// <summary>BL�R�[�h�����i���\���敪3���擾�܂��͐ݒ肵�܂��B</summary>
        public int BLCdPrtsNmDspDivCd3
        {
            get { return _blCdPrtsNmDspDivCd3; }
            private set { _blCdPrtsNmDspDivCd3 = value; }
        }

        #endregion // BL�R�[�h�����i���\���敪3

        #region BL�R�[�h�����i���\���敪4

        /// <summary>BL�R�[�h�����i���\���敪4</summary>
        /// <remarks>0:����/1:���i�}�X�^/2:���i�}�X�^/3:�����i���}�X�^/4:BL�R�[�h�}�X�^</remarks>
        private int _blCdPrtsNmDspDivCd4;
        /// <summary>BL�R�[�h�����i���\���敪4���擾�܂��͐ݒ肵�܂��B</summary>
        public int BLCdPrtsNmDspDivCd4
        {
            get { return _blCdPrtsNmDspDivCd4; }
            private set { _blCdPrtsNmDspDivCd4 = value; }
        }

        #endregion // BL�R�[�h�����i���\���敪4

        /// <summary>BL�R�[�h�����i���\���敪�R���g���[���̃��X�g</summary>
        private readonly List<TComboEditor> _blPartsNameDspDivCdControlList = new List<TComboEditor>();
        /// <summary>BL�R�[�h�����i���\���敪�R���g���[���̃��X�g���擾���܂��B</summary>
        private List<TComboEditor> BLPartsNameDspDivCdControlList { get { return _blPartsNameDspDivCdControlList; } }

        /// <summary>
        /// BL�R�[�h�����i���\���敪�R���g���[���̃��X�g�����������܂��B
        /// </summary>
        private void InitializeBLPartsNameDspDivCdControlList()
        {
            BLPartsNameDspDivCdControlList.Clear();
            {
                BLPartsNameDspDivCdControlList.Add(this.tcboBLCdPrtsNmDspDivCd1);   // BL�R�[�h�����i���\���敪1
                BLPartsNameDspDivCdControlList.Add(this.tcboBLCdPrtsNmDspDivCd2);   // BL�R�[�h�����i���\���敪2
                BLPartsNameDspDivCdControlList.Add(this.tcboBLCdPrtsNmDspDivCd3);   // BL�R�[�h�����i���\���敪3
                BLPartsNameDspDivCdControlList.Add(this.tcboBLCdPrtsNmDspDivCd4);   // BL�R�[�h�����i���\���敪4
            }
        }

        #endregion // BL�R�[�h�����i���\���敪

        #region �i�Ԍ����i���\���敪

        #region �i�Ԍ����i���\���敪1

        /// <summary>�i�Ԍ����i���\���敪1</summary>
        /// <remarks>0:����/1:���i�}�X�^/2:���i�}�X�^/3:�����i���}�X�^/4:BL�R�[�h�}�X�^</remarks>
        private int _gdNoPrtsNmDspDivCd1;
        /// <summary>�i�Ԍ����i���\���敪1���擾�܂��͐ݒ肵�܂��B</summary>
        public int GdNoPrtsNmDspDivCd1
        {
            get { return _gdNoPrtsNmDspDivCd1; }
            private set { _gdNoPrtsNmDspDivCd1 = value; }
        }

        #endregion // �i�Ԍ����i���\���敪1

        #region �i�Ԍ����i���\���敪2

        /// <summary>�i�Ԍ����i���\���敪2</summary>
        /// <remarks>0:����/1:���i�}�X�^/2:���i�}�X�^/3:�����i���}�X�^/4:BL�R�[�h�}�X�^</remarks>
        private int _gdNoPrtsNmDspDivCd2;
        /// <summary>�i�Ԍ����i���\���敪2���擾�܂��͐ݒ肵�܂��B</summary>
        public int GdNoPrtsNmDspDivCd2
        {
            get { return _gdNoPrtsNmDspDivCd2; }
            private set { _gdNoPrtsNmDspDivCd2 = value; }
        }

        #endregion // �i�Ԍ����i���\���敪2

        #region �i�Ԍ����i���\���敪3

        /// <summary>�i�Ԍ����i���\���敪3</summary>
        /// <remarks>0:����/1:���i�}�X�^/2:���i�}�X�^/3:�����i���}�X�^/4:BL�R�[�h�}�X�^</remarks>
        private int _gdNoPrtsNmDspDivCd3;
        /// <summary>�i�Ԍ����i���\���敪3���擾�܂��͐ݒ肵�܂��B</summary>
        public int GdNoPrtsNmDspDivCd3
        {
            get { return _gdNoPrtsNmDspDivCd3; }
            private set { _gdNoPrtsNmDspDivCd3 = value; }
        }

        #endregion // �i�Ԍ����i���\���敪3

        #region �i�Ԍ����i���\���敪4

        /// <summary>�i�Ԍ����i���\���敪4</summary>
        /// <remarks>0:����/1:���i�}�X�^/2:���i�}�X�^/3:�����i���}�X�^/4:BL�R�[�h�}�X�^</remarks>
        private int _gdNoPrtsNmDspDivCd4;
        /// <summary>�i�Ԍ����i���\���敪4���擾�܂��͐ݒ肵�܂��B</summary>
        public int GdNoPrtsNmDspDivCd4
        {
            get { return _gdNoPrtsNmDspDivCd4; }
            private set { _gdNoPrtsNmDspDivCd4 = value; }
        }

        #endregion // �i�Ԍ����i���\���敪4

        /// <summary>�i�Ԍ����i���\���敪�R���g���[���̃��X�g</summary>
        private readonly List<TComboEditor> _gdNoPrtsNmDspDivCdControlList = new List<TComboEditor>();
        /// <summary>�i�Ԍ����i���\���敪�R���g���[���̃��X�g���擾���܂��B</summary>
        private List<TComboEditor> GdNoPrtsNmDspDivCdControlList { get { return _gdNoPrtsNmDspDivCdControlList; } }

        /// <summary>
        /// �i�Ԍ����i���\���敪�R���g���[���̃��X�g�����������܂��B
        /// </summary>
        private void InitializeGdNoPrtsNmDspDivCdControlList()
        {
            GdNoPrtsNmDspDivCdControlList.Clear();
            {
                GdNoPrtsNmDspDivCdControlList.Add(this.tcboGdNoPrtsNmDspDivCd1);    // �i�Ԍ����i���\���敪1
                GdNoPrtsNmDspDivCdControlList.Add(this.tcboGdNoPrtsNmDspDivCd2);    // �i�Ԍ����i���\���敪2
                GdNoPrtsNmDspDivCdControlList.Add(this.tcboGdNoPrtsNmDspDivCd3);    // �i�Ԍ����i���\���敪3
                GdNoPrtsNmDspDivCdControlList.Add(this.tcboGdNoPrtsNmDspDivCd4);    // �i�Ԍ����i���\���敪4
            }
        }

        #endregion // �i�Ԍ����i���\���敪

        #region �D�Ǖ��i�����i���g�p�敪

        /// <summary>�D�Ǖ��i�����i���g�p�敪</summary>
        /// <remarks>0:�g�p/1:���g�p</remarks>
        private int _prmPrtsNmUseDivCd;
        /// <summary>�D�Ǖ��i�����i���g�p�敪</summary>
        public int PrmPrtsNmUseDivCd
        {
            get { return _prmPrtsNmUseDivCd; }
            private set { _prmPrtsNmUseDivCd = value; }
        }

        #endregion // �D�Ǖ��i�����i���g�p�敪

        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public DCKHN09210UB()
        {
            #region Designer Code

            InitializeComponent();

            #endregion // Designer Code
        }

        #endregion // Constructor

        #region ����S�̐ݒ�

        /// <summary>
        /// �i���\���p�^�[���iBL�R�[�h�����i���\���敪�A�i�Ԍ����i���\���敪�A�D�Ǖ��i�����i���敪�j��ݒ肵�܂��B
        /// </summary>
        /// <param name="salesTtlSt">����S�̐ݒ�</param>
        public void SetPatterns(SalesTtlSt salesTtlSt)
        {
            #region Guard Phrase

            if (salesTtlSt == null) return;

            #endregion // Guard Phrase

            BLCdPrtsNmDspDivCd1 = salesTtlSt.BLCdPrtsNmDspDivCd1;   // BL�R�[�h�����i���\���敪1
            BLCdPrtsNmDspDivCd2 = salesTtlSt.BLCdPrtsNmDspDivCd2;   // BL�R�[�h�����i���\���敪2
            BLCdPrtsNmDspDivCd3 = salesTtlSt.BLCdPrtsNmDspDivCd3;   // BL�R�[�h�����i���\���敪3
            BLCdPrtsNmDspDivCd4 = salesTtlSt.BLCdPrtsNmDspDivCd4;   // BL�R�[�h�����i���\���敪4
            GdNoPrtsNmDspDivCd1 = salesTtlSt.GdNoPrtsNmDspDivCd1;   // �i�Ԍ����i���\���敪1
            GdNoPrtsNmDspDivCd2 = salesTtlSt.GdNoPrtsNmDspDivCd2;   // �i�Ԍ����i���\���敪2
            GdNoPrtsNmDspDivCd3 = salesTtlSt.GdNoPrtsNmDspDivCd3;   // �i�Ԍ����i���\���敪3
            GdNoPrtsNmDspDivCd4 = salesTtlSt.GdNoPrtsNmDspDivCd4;   // �i�Ԍ����i���\���敪4
            PrmPrtsNmUseDivCd = salesTtlSt.PrmPrtsNmUseDivCd;       // �D�Ǖ��i�����i���g�p�敪
        }

        /// <summary>
        /// ����S�̐ݒ�֕i���\���p�^�[����ݒ肵�܂��B
        /// </summary>
        /// <param name="salesTtlSt">����S�̐ݒ�</param>
        public void SetToSalesTtlSt(SalesTtlSt salesTtlSt)
        {
            #region Guard Phrase

            if (salesTtlSt == null) return;

            #endregion // Guard Phrase

            salesTtlSt.BLCdPrtsNmDspDivCd1 = BLCdPrtsNmDspDivCd1;   // BL�R�[�h�����i���\���敪1
            salesTtlSt.BLCdPrtsNmDspDivCd2 = BLCdPrtsNmDspDivCd2;   // BL�R�[�h�����i���\���敪2
            salesTtlSt.BLCdPrtsNmDspDivCd3 = BLCdPrtsNmDspDivCd3;   // BL�R�[�h�����i���\���敪3
            salesTtlSt.BLCdPrtsNmDspDivCd4 = BLCdPrtsNmDspDivCd4;   // BL�R�[�h�����i���\���敪4
            salesTtlSt.GdNoPrtsNmDspDivCd1 = GdNoPrtsNmDspDivCd1;   // �i�Ԍ����i���\���敪1
            salesTtlSt.GdNoPrtsNmDspDivCd2 = GdNoPrtsNmDspDivCd2;   // �i�Ԍ����i���\���敪2
            salesTtlSt.GdNoPrtsNmDspDivCd3 = GdNoPrtsNmDspDivCd3;   // �i�Ԍ����i���\���敪3
            salesTtlSt.GdNoPrtsNmDspDivCd4 = GdNoPrtsNmDspDivCd4;   // �i�Ԍ����i���\���敪4
            salesTtlSt.PrmPrtsNmUseDivCd = PrmPrtsNmUseDivCd;       // �D�Ǖ��i�����i���g�p�敪
        }

        #endregion // ����S�̐ݒ�

        #region Form

        /// <summary>
        /// ���������܂��B
        /// </summary>
        /// <remarks>
        /// �i���\���p�^�[���ݒ�<c>SetPatterns()</c>���Ɍďo���K�v������܂��B
        /// </remarks>
        /// <param name="ownerPartsNameDspDivCd">����S�̐ݒ�t�H�[���̕i���\���敪</param>
        private void Initialize(TComboEditor ownerPartsNameDspDivCd)
        {
            // BL�R�[�h�����i���\���敪�R���g���[���̃��X�g��������
            InitializeBLPartsNameDspDivCdControlList();

            // �i�Ԍ����i���\���敪�R���g���[���̃��X�g��������
            InitializeGdNoPrtsNmDspDivCdControlList();

            // ����S�̐ݒ�̕i���\���敪��ێ�
            if (ownerPartsNameDspDivCd != null)
            {
                OwnerPartsNameDspDivCd = ownerPartsNameDspDivCd;
                this.tcboPartsNameDspDivCd.SelectedIndex = OwnerPartsNameDspDivCd.SelectedIndex;
                EnabledPatternControlsByPartsNameDspDivCd();
            }

            // ��ʂ�������
            this.tcboBLCdPrtsNmDspDivCd1.SelectedIndex = BLCdPrtsNmDspDivCd1;   // BL�R�[�h�����i���\���敪1
            this.tcboBLCdPrtsNmDspDivCd2.SelectedIndex = BLCdPrtsNmDspDivCd2;   // BL�R�[�h�����i���\���敪2
            this.tcboBLCdPrtsNmDspDivCd3.SelectedIndex = BLCdPrtsNmDspDivCd3;   // BL�R�[�h�����i���\���敪3
            this.tcboBLCdPrtsNmDspDivCd4.SelectedIndex = BLCdPrtsNmDspDivCd4;   // BL�R�[�h�����i���\���敪4
            this.tcboGdNoPrtsNmDspDivCd1.SelectedIndex = GdNoPrtsNmDspDivCd1;   // �i�Ԍ����i���\���敪1
            this.tcboGdNoPrtsNmDspDivCd2.SelectedIndex = GdNoPrtsNmDspDivCd2;   // �i�Ԍ����i���\���敪2
            this.tcboGdNoPrtsNmDspDivCd3.SelectedIndex = GdNoPrtsNmDspDivCd3;   // �i�Ԍ����i���\���敪3
            this.tcboGdNoPrtsNmDspDivCd4.SelectedIndex = GdNoPrtsNmDspDivCd4;   // �i�Ԍ����i���\���敪4
            this.tcboPrmPrtsNmUseDivCd.SelectedIndex = PrmPrtsNmUseDivCd;       // �D�Ǖ��i�����i���g�p��
        }

        /// <summary>
        /// �_�C�A���O�\�����܂��B
        /// </summary>
        /// <param name="ownerPartsNameDspDivCd">����S�̐ݒ�t�H�[���̕i���\���敪</param>
        /// <returns>���쌋��</returns>
        public DialogResult ShowDialog(TComboEditor ownerPartsNameDspDivCd)
        {
            Initialize(ownerPartsNameDspDivCd);

            return ShowDialog();
        }

        /// <summary>
        /// �i���\���p�^�[���ݒ��ʃt�H�[����Shown�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void DCKHN09210UB_Shown(object sender, EventArgs e)
        {
            // �t�H�[�J�X�̏����ʒu
            this.tcboPartsNameDspDivCd.Focus();
        }

        #endregion // Form

        /// <summary>
        /// �i���\���敪�ɉ����ĕi���\���p�^�[���̓��̓R���g���[���̗L���t���O��ݒ肵�܂��B
        /// </summary>
        private void EnabledPatternControlsByPartsNameDspDivCd()
        {
            // �i���\���p�^�[���͔C�Ӑݒ�ɂƂ��ɗL��
            bool enabled = IsOptionSetting();

            // BL�R�[�h�����i���\���敪
            BLPartsNameDspDivCdControlList.ForEach(delegate(TComboEditor blPartsNameDspDivCdControl)
            {
                blPartsNameDspDivCdControl.Enabled = enabled;
            });

            // �i�Ԍ����i���\���敪
            GdNoPrtsNmDspDivCdControlList.ForEach(delegate(TComboEditor gdNoPrtsNmDspDivCdControl)
            {
                gdNoPrtsNmDspDivCdControl.Enabled = enabled;
            });

            // �D�Ǖ��i�����i���g�p�敪
            this.tcboPrmPrtsNmUseDivCd.Enabled = enabled;
        }

        #region �L�����Z��

        /// <summary>
        /// [�L�����Z��]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ubtnCancel_Click(object sender, EventArgs e)
        {
            // �\���������Ɖ�ʂ̋敪�l���ύX����Ă���ꍇ�́A�m�F���b�Z�[�W��\����A��ʂ����
            SynchronizePartsNameDspDivCdIf();
            this.Close();
        }

        /// <summary>
        /// �\���������Ɖ�ʂ̕i���\���敪�l���ύX����Ă���ꍇ�́A�m�F���b�Z�[�W��\����A�i���\���敪�l�̓������Ƃ�܂��B
        /// </summary>
        private void SynchronizePartsNameDspDivCdIf()
        {
            if (this.tcboPartsNameDspDivCd.SelectedIndex.Equals(OwnerPartsNameDspDivCd.SelectedIndex)) return;

            DialogResult result = MessageBox.Show(
                "�i���\���敪�̕ύX�𔄏�S�̐ݒ�ɔ��f���܂����H",
                this.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result.Equals(DialogResult.Yes))
            {
                OwnerPartsNameDspDivCd.SelectedIndex = this.tcboPartsNameDspDivCd.SelectedIndex;
            }
        }

        #endregion // �L�����Z��

        #region OK

        /// <summary>
        /// [OK]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ubtnOK_Click(object sender, EventArgs e)
        {
            // �i���\���敪���C�Ӑݒ�ł͂Ȃ��ꍇ�A�i���\���p�^�[���͗L���Ƃ��Ȃ��̂ŁA
            // �i���\���敪�݂̂𓯊������ďI��
            if (!IsOptionSetting())
            {
                OwnerPartsNameDspDivCd.SelectedIndex = this.tcboPartsNameDspDivCd.SelectedIndex;
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            if (ValidateInput())
            {
                // �i���\���p�^�[���̐ݒ������
                BLCdPrtsNmDspDivCd1 = this.tcboBLCdPrtsNmDspDivCd1.SelectedIndex;   // BL�R�[�h�����i���\���敪1
                BLCdPrtsNmDspDivCd2 = this.tcboBLCdPrtsNmDspDivCd2.SelectedIndex;   // BL�R�[�h�����i���\���敪2
                BLCdPrtsNmDspDivCd3 = this.tcboBLCdPrtsNmDspDivCd3.SelectedIndex;   // BL�R�[�h�����i���\���敪3
                BLCdPrtsNmDspDivCd4 = this.tcboBLCdPrtsNmDspDivCd4.SelectedIndex;   // BL�R�[�h�����i���\���敪4
                GdNoPrtsNmDspDivCd1 = this.tcboGdNoPrtsNmDspDivCd1.SelectedIndex;   // �i�Ԍ����i���\���敪1
                GdNoPrtsNmDspDivCd2 = this.tcboGdNoPrtsNmDspDivCd2.SelectedIndex;   // �i�Ԍ����i���\���敪2
                GdNoPrtsNmDspDivCd3 = this.tcboGdNoPrtsNmDspDivCd3.SelectedIndex;   // �i�Ԍ����i���\���敪3
                GdNoPrtsNmDspDivCd4 = this.tcboGdNoPrtsNmDspDivCd4.SelectedIndex;   // �i�Ԍ����i���\���敪4
                PrmPrtsNmUseDivCd = this.tcboPrmPrtsNmUseDivCd.SelectedIndex;       // �D�Ǖ��i�����i���g�p�敪

                // �i���\���敪�𓯊������ďI��
                OwnerPartsNameDspDivCd.SelectedIndex = this.tcboPartsNameDspDivCd.SelectedIndex;
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // �G���[����
            MessageBox.Show("�ݒ肪�d�����Ă��܂��B", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// ���͂����؂��܂��B
        /// </summary>
        /// <param name="ownerPartsNameDspDivCd">����S�̐ݒ�t�H�[���̕i���\���敪</param>
        /// <returns>
        /// <c>true</c> :����ł��B<br/>
        /// <c>false</c>:�ُ킪����܂��B
        /// </returns>
        public bool ValidateInput(TComboEditor ownerPartsNameDspDivCd)
        {
            Initialize(ownerPartsNameDspDivCd);

            return ValidateInput();
        }

        /// <summary>
        /// ���͂����؂��܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :����ł��B<br/>
        /// <c>false</c>:�ُ킪����܂��B
        /// </returns>
        private bool ValidateInput()
        {
            // �C�Ӑݒ�̏ꍇ�̂݌���
            if (!IsOptionSetting()) return true;

            // �d�������ݒ��NG
            TComboEditor sameValueItem = FindFirstSameItem(BLPartsNameDspDivCdControlList);
            if (sameValueItem != null)
            {
                sameValueItem.Focus();
                return false;
            }
            sameValueItem = FindFirstSameItem(GdNoPrtsNmDspDivCdControlList);
            if (sameValueItem != null)
            {
                sameValueItem.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// �S�āu�����v�ł��邩���f���܂��B
        /// </summary>
        /// <param name="prtsNmDspDivCdList">�������̕i���\���敪�R���g���[���̃��X�g</param>
        /// <returns>
        /// <c>true</c> :�S�āu�����v�ł��B<br/>
        /// <c>false</c>:�u�����v�ȊO�̐ݒ肪���݂��܂��B
        /// </returns>
        private static bool IsAllNone(List<TComboEditor> prtsNmDspDivCdList)
        {
            List<TComboEditor> foundPrtsNmDspDivCdList = prtsNmDspDivCdList.FindAll(delegate(TComboEditor item)
            {
                return item.SelectedIndex.Equals((int)SalesTtlSt.PrtsNmDspDivCdValue.None);
            });
            return foundPrtsNmDspDivCdList.Count.Equals(prtsNmDspDivCdList.Count);
        }

        /// <summary>
        /// �ŏ��Ɍ������ꂽ�d�������ݒ�l�����i���\���敪�R���g���[�����擾���܂��B
        /// </summary>
        /// <param name="prtsNmDspDivCdList">�������̕i���\���敪�R���g���[���̃��X�g</param>
        /// <returns>
        /// �ŏ��Ɍ������ꂽ�d�������ݒ�l�����i���\���敪�R���g���[��
        /// �i�d�����Ă��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��j
        /// </returns>
        private static TComboEditor FindFirstSameItem(List<TComboEditor> prtsNmDspDivCdList)
        {
            Dictionary<int, TComboEditor> checkedMap = new Dictionary<int, TComboEditor>();
            {
                foreach (TComboEditor checkingItem in prtsNmDspDivCdList)
                {
                    if (checkedMap.ContainsKey(checkingItem.SelectedIndex))
                    {
                        return checkingItem;
                    }
                    else
                    {
                        checkedMap.Add(checkingItem.SelectedIndex, checkingItem);
                    }
                }
            }
            return null;
        }

        #endregion // OK

        // ---------- ADD 2010/12/03 --------------------------->>>>>
        #region HELP
        /// <summary>�i���\���p�^�[���ݒ�(HELP)���</summary>
        private DCKHN09210UC _partsNameDspPatternHelpForm;
        /// <summary>�i���\���p�^�[���ݒ�(HELP)��ʂ��擾���܂��B</summary>
        private DCKHN09210UC PartsNameDspPatternHelpForm
        {
            get
            {
                if (_partsNameDspPatternHelpForm == null) _partsNameDspPatternHelpForm = new DCKHN09210UC();
                return _partsNameDspPatternHelpForm;
            }
        }

        /// <summary>
        /// [HELP]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ubtnHelp_Click(object sender, EventArgs e)
        {
            PartsNameDspPatternHelpForm.ShowDialog();
        }
        #endregion //HELP
        // ---------- ADD 2010/12/03 ---------------------------<<<<<
    }
}