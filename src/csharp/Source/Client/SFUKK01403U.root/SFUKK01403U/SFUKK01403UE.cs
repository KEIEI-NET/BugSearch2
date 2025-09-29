//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �����`�[����
// �v���O�����T�v   : �����`�[�ꗗ�̌������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : ���N
// �C �� ��  2012/12/24  �C�����e : 2013/03/13�z�M�� Redmine#33741�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10806793-00 �쐬�S�� : ���N
// �C �� ��  2013/02/07  �C�����e : 2013/03/13�z�M�� Redmine#33741�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    public partial class SFUKK01403UE : Form
    {
        /// <summary>
        /// �����`�[�����R���g���[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����`�[�̌������s���R���g���[���N���X�ł��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date       : 2012/12/24</br>
        /// <br>Update Note: 2013/02/07 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br></br>
        /// </remarks>
        public SFUKK01403UE()
        {
            InitializeComponent();
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        #region [Private Number]

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;					// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;					// �����{�^��

        /// <summary>�����`�[���͉��(�����^)�A�N�Z�X�N���X</summary>
        private InputDepositNormalTypeAcs _inputDepositNormalTypeAcs;

        /// <summary>�������(�����`�[)�擾�p�p�����[�^</summary>
        private InputDepositNormalTypeAcs.SearchDepositParameter _searchDepositParameter;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>���Ӑ���N���X</summary>
        private CustomerInfoAcs _customerInfoAcs = new CustomerInfoAcs();

        // ���_�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = new SecInfoSetAcs();

        /// <summary>��ʃt�H�[�J�X�����ݒ�Flag</summary>
        private bool _focusSetFlag;

        private int _status;
        /// <summary>���O�C�����_�R�[�h</summary>
        private string _sectionCode;

        /// <summary>���O�C�����_��</summary>
        private string _sectionName;
        
        // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
        /// <summary>���Ӑ�R�[�h</summary>
        private int _custCode;

        /// <summary>���Ӑ於</summary>
        private string _custName;

        private bool _toolSearchFlag;
        // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
        #endregion

        # region [Dispose]
        /// <summary>
        /// �����`�[���͉��(�����^)�A�N�Z�X�N���X
        /// </summary>
        public InputDepositNormalTypeAcs InputDepositNormalTypeAcsUE
        {
            set { _inputDepositNormalTypeAcs = value; }
            get { return _inputDepositNormalTypeAcs; }
        }

        /// <summary>
        /// ���������N���X
        /// </summary>
        public InputDepositNormalTypeAcs.SearchDepositParameter SearchDepositParameter
        {
            set { _searchDepositParameter = value; }
            get { return _searchDepositParameter; }
        }

        /// <summary>
        /// ��������status
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string SectionCode
        {
            set { _sectionCode = value; }
            get { return _sectionCode; }
        }

        /// <summary>
        /// ���_��
        /// </summary>
        public string SectionName
        {
            set { _sectionName = value; }
            get { return _sectionName; }
        }
        #endregion

        #region [Private Methord]

        /// <summary>
        /// �O���b�h�����ݒ菈��
        /// </summary>
        /// <param name="uGrid">�����O���b�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void InitializeGrid(UltraGrid uGrid)
        {
            // �����O���b�h
            if (uGrid.Name == "grdDepositList")
            {
                // �s�I�����[�h�̐ݒ�
                uGrid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;
            }
            // �s�I��ݒ� �s�I�𖳂����[�h(�A�N�e�B�u�̂�)
            uGrid.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            uGrid.DisplayLayout.Override.SelectTypeCell = SelectType.None;
            uGrid.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            // �s�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.RowAppearance.BackColor = Color.White;

            // 1�s�����̊O�ϐݒ�
            uGrid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Lavender;

            // �I���s�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            uGrid.DisplayLayout.Override.SelectedRowAppearance.BackGradientStyle = GradientStyle.Vertical;

            // �A�N�e�B�u�s�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            uGrid.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;

            // �w�b�_�[�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            uGrid.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            uGrid.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.Vertical;
            uGrid.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Left;
            uGrid.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Alpha.Transparent;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
            uGrid.DisplayLayout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;

            // �s�Z���N�^�[�̊O�ϐݒ�
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            uGrid.DisplayLayout.Override.RowSelectorAppearance.BackGradientStyle = GradientStyle.Vertical;

            // �s�t�B���^�[�̐ݒ�
            uGrid.DisplayLayout.Override.RowFilterAction = RowFilterAction.HideFilteredOutRows;

            // ���������̃X�N���[���X�^�C��
            uGrid.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            // ������ʕ\��(�X�v���b�^�[)�̕\���ݒ�
            uGrid.DisplayLayout.MaxRowScrollRegions = 1;

            // �X�N���[���o�[�ŏI�s����
            uGrid.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;

            // �w�b�_�[�N���b�N�A�N�V�����ݒ�
            uGrid.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti;

            // �u�Œ��v�v�b�V���s���A�C�R��������
            uGrid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
        }

        /// <summary>
        /// �����O���b�h�f�[�^�r���[�o�C���h����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����O���b�h�Ƀf�[�^�r���[���o�C���h���܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void BindingDsDepositView()
        {
            // �����O���b�h��View���o�C���h����
            grdDepositList.DataSource = this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable].DefaultView;
        }

        /// <summary>
        /// �����O���b�h�\���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����O���b�h�̕\���ݒ���s���܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void SettingDepositGrid()
        {
            string moneyFormat = "#,##0;-#,##0;''";
            string zeroFormat = "000000000;''";
            string moneyFormatWith0yen = "#,##0;-#,##0";
   
            // --- �����ꗗ�o���h --- //
            ColumnsCollection pareColumns = grdDepositList.DisplayLayout.Bands[InputDepositNormalTypeAcs.ctDepositGuidDataTable].Columns;

            // �����ԍ�
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].Header.Caption = "�����`�[�ԍ�";
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].CellAppearance.TextHAlign = HAlign.Right;
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].Width = 120;
            pareColumns[InputDepositNormalTypeAcs.ctDepositSlipNo].Format = zeroFormat;

            // �����v���(�v����t��\������)
            pareColumns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].Header.Caption = "������";
            pareColumns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDepositAddUpADateDisp].Width = 120;

            //���Ӑ�R�[�h
            pareColumns[InputDepositNormalTypeAcs.ctCustomerCode].Header.Caption = "���Ӑ�R�[�h";
            pareColumns[InputDepositNormalTypeAcs.ctCustomerCode].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[InputDepositNormalTypeAcs.ctCustomerCode].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctCustomerCode].Width = 100;

            //���Ӑ於��
            pareColumns[InputDepositNormalTypeAcs.ctCustomerName].Header.Caption = "���Ӑ於��";
            pareColumns[InputDepositNormalTypeAcs.ctCustomerName].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[InputDepositNormalTypeAcs.ctCustomerName].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctCustomerName].Width = 120;

            // ���� �����z
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].Header.Caption = "�������z";
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].CellAppearance.TextHAlign = HAlign.Right;
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].Width = 100;
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].Format = moneyFormat;
            pareColumns[InputDepositNormalTypeAcs.ctDeposit].Format = moneyFormatWith0yen; 

            // ���� ���v
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].Header.Caption = "�������v";
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].CellAppearance.TextHAlign = HAlign.Right;
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].Width = 100;
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].Format = moneyFormat;
            pareColumns[InputDepositNormalTypeAcs.ctDepositTotal].Format = moneyFormatWith0yen;

            // ��
            pareColumns[InputDepositNormalTypeAcs.ctDepositClosedFlg].Header.Caption = "��";
            pareColumns[InputDepositNormalTypeAcs.ctDepositClosedFlg].CellAppearance.TextHAlign = HAlign.Center;
            pareColumns[InputDepositNormalTypeAcs.ctDepositClosedFlg].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctDepositClosedFlg].Width = 30;

            // �E�v
            pareColumns[InputDepositNormalTypeAcs.ctOutline].Header.Caption = "�E�v";
            pareColumns[InputDepositNormalTypeAcs.ctOutline].CellAppearance.TextHAlign = HAlign.Left;
            pareColumns[InputDepositNormalTypeAcs.ctOutline].CellAppearance.TextVAlign = VAlign.Middle;
            pareColumns[InputDepositNormalTypeAcs.ctOutline].Width = 120;

            // �����O���b�h��W�J���� (�P�s���f�[�^�������Ă��^�C�g����\�������)
            grdDepositList.Rows.ExpandAll(true);
        }

        /// <summary>
        /// �����O���b�h�\����ύX����
        /// </summary>
        /// <param name="checkDetail">�ڍו\�� �L��</param>
        /// <param name="checkAllowance">�����\�� �L��</param>
        /// <remarks>
        /// <br>Note       : �����O���b�h�̕\�����ύX���܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void DetailViewSettingColumun(bool checkDetail, bool checkAllowance)
        {
            // >>>>>>>>>>>>>>>>>>>> //
            // --- �����e�[�u�� --- //
            // >>>>>>>>>>>>>>>>>>>> //
            UltraGridBand bdDeposit = grdDepositList.DisplayLayout.Bands[InputDepositNormalTypeAcs.ctDepositGuidDataTable];

            // >>> �����e�[�u�� ��������֘A�̕\������ >>> //
            // ���� �����z
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit].Hidden = true;
            // ���� �萔��
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctFeeDeposit].Hidden = true;
            // ���� �l��
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDiscountDeposit].Hidden = true;
            // �E�v
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctOutline].Hidden = false;
            // �����S����
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositInputAgentNm].Hidden = true;
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositInputEmpCd].Hidden = true;  // ���s�҃R�[�h
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositInputEmpNm].Hidden = true;  // ���s�Җ�
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctCustomerCode].Hidden = false;
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctCustomerName].Hidden = false;

            // >>> �����e�[�u�� �������v�֘A�̕\������ >>> //
            // �\��
            // ���� �����v
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositTotal].Hidden = false;
            //�敪
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositNm].Hidden = true;
            // ����
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctAllowDiv].Hidden = true;
            //����
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositKindName].Hidden = true;
            //�萔��
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctFeeDeposit].Hidden = true;
            //�l��
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDiscountDeposit].Hidden = true;
            // �����z ���v
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAllowance_Deposit].Hidden = true;
            // ���͒S����
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositInputAgentNm].Hidden = true;
            //�������z
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAlwcBlnce_Deposit].Hidden = true;
            //����`�[�ԍ�
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctSalesSlipNum].Hidden = true;
            //����
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositClosedFlg].Hidden = true;

            // >>> �����e�[�u�� ��ɔ�\������ >>> //
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDebitNoteCd].Hidden = true;			    // �����ԓ`�敪
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDebitNoteNm].Hidden = true;			    // �����ԓ`����
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDebitNoteLinkDepoNo].Hidden = true;			    // �ԍ������A���ԍ�
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDateDisp].Hidden = true;			        // ������(�\���p)
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDate].Hidden = true;			            // ������
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAddUpADate].Hidden = true;			        // �v����t
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAcptAnOdrStatus].Hidden = true;			// �󒍃X�e�[�^�X
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctAutoDepositCd].Hidden = true;			            // ���������敪
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositAllowance_Deposit].Hidden = true;			// ���������z ����
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctBankCode].Hidden = true;	                        // ��s�R�[�h
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctBankName].Hidden = true;                          // ��s����
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftNo].Hidden = true;                           // ��`�ԍ�
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftDivide].Hidden = true;                       // ��`�敪
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftDivideName].Hidden = true;                   // ��`�敪����
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftKind].Hidden = true;                         // ��`���
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftKindName].Hidden = true;                     // ��`��ޖ���
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftDrawingDate].Hidden = true;			        // ��`�U�o��
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDraftDrawingDate].Hidden = true;			        // ��`�U�o��
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositDataRow].Hidden = true;			        // ���g��DataRow
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo1].Hidden = true;			            // �����s�ԍ�1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode1].Hidden = true;			        // ����R�[�h1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName1].Hidden = true;			        // ���햼��1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv1].Hidden = true;			            // ����敪1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit1].Hidden = true;			                // �������z1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm1].Hidden = true;			            // �L������1
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo2].Hidden = true;			            // �����s�ԍ�2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode2].Hidden = true;			        // ����R�[�h2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName2].Hidden = true;			        // ���햼��2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv2].Hidden = true;			            // ����敪2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit2].Hidden = true;			                // �������z2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm2].Hidden = true;			            // �L������2
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo3].Hidden = true;			            // �����s�ԍ�3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode3].Hidden = true;			        // ����R�[�h3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName3].Hidden = true;			        // ���햼��3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv3].Hidden = true;			            // ����敪3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit3].Hidden = true;			                // �������z3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm3].Hidden = true;			            // �L������3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo4].Hidden = true;			            // �����s�ԍ�3
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode4].Hidden = true;			        // ����R�[�h4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName4].Hidden = true;			        // ���햼��4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv4].Hidden = true;			            // ����敪4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit4].Hidden = true;			                // �������z4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm4].Hidden = true;			            // �L������4
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo5].Hidden = true;			            // �����s�ԍ�5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode5].Hidden = true;			        // ����R�[�h5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName5].Hidden = true;			        // ���햼��5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv5].Hidden = true;			            // ����敪5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit5].Hidden = true;			                // �������z5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm5].Hidden = true;			            // �L������5
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo6].Hidden = true;			            // �����s�ԍ�6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode6].Hidden = true;			        // ����R�[�h6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName6].Hidden = true;			        // ���햼��6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv6].Hidden = true;			            // ����敪6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit6].Hidden = true;			                // �������z6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm6].Hidden = true;			            // �L������6
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo7].Hidden = true;			            // �����s�ԍ�7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode7].Hidden = true;			        // ����R�[�h7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName7].Hidden = true;			        // ���햼��7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv7].Hidden = true;			            // ����敪7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit7].Hidden = true;			                // �������z7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm7].Hidden = true;			            // �L������7
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo8].Hidden = true;			            // �����s�ԍ�8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode8].Hidden = true;			        // ����R�[�h8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName8].Hidden = true;			        // ���햼��8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv8].Hidden = true;			            // ����敪8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit8].Hidden = true;			                // �������z8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm8].Hidden = true;			            // �L������8
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo9].Hidden = true;			            // �����s�ԍ�9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode9].Hidden = true;			        // ����R�[�h9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName9].Hidden = true;			        // ���햼��9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv9].Hidden = true;			            // ����敪9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit9].Hidden = true;			                // �������z9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm9].Hidden = true;			            // �L������9
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDepositRowNo10].Hidden = true;			            // �����s�ԍ�10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindCode10].Hidden = true;			        // ����R�[�h10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindName10].Hidden = true;			        // ���햼��10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctMoneyKindDiv10].Hidden = true;			            // ����敪10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctDeposit10].Hidden = true;			                // �������z10
            bdDeposit.Columns[InputDepositNormalTypeAcs.ctValidityTerm10].Hidden = true;			            // �L������10
        }

        /// <summary>
        /// ���Ӑ���擾����
        /// </summary>
        /// <param name="customerInfo">���Ӑ���I�u�W�F�N�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ���Ӑ�R�[�h����Ώۂ̓��Ӑ�����擾���܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// </remarks>
        private int GetCustomerInfo(out CustomerInfo customerInfo, int customerCode)
        {
            customerInfo = new CustomerInfo();
            int status;

            try
            {
                status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, true, out customerInfo);
            }
            catch
            {
                status = -1;
                customerInfo = null;
            }

            return (status);
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this.tEdit_SectionCodeAllowZero.Clear();
                this.uLabel_SectionName.Text = "";
                return;
            }
            else
            {
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
                CustomerInfo customerInfo = new CustomerInfo();
                this.tNedit_CustomerCode.DataText = customerSearchRet.CustomerCode.ToString();
                this.uLabel_CustomerName.Text = customerSearchRet.Name + " " + customerSearchRet.Name2;
            }
        }

        #endregion

        #region [Private Event]

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ގ��ɔ������܂��B</br>
        /// <br>Programmer  : ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>Update Note : 2013/02/07 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void SFUKK01403UE_Load(object sender, EventArgs e)
        {
            //���O�C�����_
            this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
            this.uLabel_SectionName.Text = this.SectionName;
            this._enterpriseCode = this._searchDepositParameter.EnterpriseCode;

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionCodeGuide_ultraButton.ImageList = imageList16;
            this.SectionCodeGuide_ultraButton.Appearance.Image = Size16_Index.STAR1;
            this.CustomerGuide_uButton.ImageList = imageList16;
            this.CustomerGuide_uButton.Appearance.Image = Size16_Index.STAR1;

            this.tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Search"];
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._closeButton.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;

            if (this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable] == null)
            {
                // ������� DataSet Table �쐬����
                this._inputDepositNormalTypeAcs.CreateDepositGuidDataTable();
            }
            else
            {
                this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable].Clear();
            }

            // �����O���b�h�f�[�^�r���[�o�C���h����
            this.BindingDsDepositView();
            //�O���b�h�\���ݒ菈��   
            SettingDepositGrid();
            //�O���b�h�\����ύX����      
            DetailViewSettingColumun(true, true);
            this._focusSetFlag = true;
            this._toolSearchFlag = true;// ADD ���N 2013/02/07 Redmine#33741
        }

        /// <summary>�����K�C�h�O���b�h�����ݒ菈������</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : �����K�C�h�O���b�h�����ݒ菈�������B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            // �����O���b�h
            if (uGrid.Name == "grdDepositList")
            {
                // �����O���b�h�����ݒ菈������
                this.InitializeGrid(this.grdDepositList);
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h���N������B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date       : 2012/12/24</br>
        /// </remarks>
        private void CustomerGuide_uButton_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�p���C�u�������ύX
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// ���Ӑ挟���A�N�Z�X�N���X
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// �L�[�R���g���[�� �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�[�������ꂽ���ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Update Note : 2013/02/07 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (_focusSetFlag && e.NextCtrl != null)
            {
                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                this._focusSetFlag = false;
            }
            if (e.PrevCtrl == null)
            {
                return;
            }
            switch(e.PrevCtrl.Name)
            {
                case "tEdit_SectionCodeAllowZero":�@//���_�R�[�h
                    {
                        //------------------------------------
                        // ���_�R�[�h�擾
                        //------------------------------------
                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.TrimEnd();

                        tEdit_SectionCodeAllowZero_Enter(this.tEdit_SectionCodeAllowZero, new EventArgs());
                        UiSet uiset;
                        uiSetControl1.ReadUISet(out uiset, tEdit_SectionCodeAllowZero.Name);
                        string sectionCodeZero = new string('0', uiset.Column);
                        if (sectionCode == sectionCodeZero || string.IsNullOrEmpty(sectionCode) || "0".Equals(sectionCode))
                        {
                            this.tEdit_SectionCodeAllowZero.DataText = "00";
                            this.uLabel_SectionName.Text = "�S��";
                            this.SectionCode = "00";
                            this.SectionName = "�S��";
                            return;
                        }
                        else if (sectionCode != this.SectionCode)
                        {
                            if (_secInfoSetAcs == null)
                            {
                                _secInfoSetAcs = new SecInfoSetAcs();
                            }
                            if (sectionCode.Length == 1)
                            {
                                sectionCode = sectionCode.PadLeft(2, '0');
                            }
                            SecInfoSet sectionInfo;
                            if (sectionCode != sectionCodeZero)
                            {
                                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) // DEL ���N 2013/02/07 Redmine#33741
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode == 0) // ADD ���N 2013/02/07 Redmine#33741
                                {
                                    // �p�����[�^�ɕۑ�
                                    this.tEdit_SectionCodeAllowZero.DataText = sectionInfo.SectionCode.TrimEnd();
                                    this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
                                    this.SectionCode = sectionInfo.SectionCode.TrimEnd();
                                    this.SectionName = sectionInfo.SectionGuideNm.TrimEnd();
                                }
                                // ----- DEL ���N 2013/02/07 Redmine#33741 ----->>>>>
                                //else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                // ----- DEL ���N 2013/02/07 Redmine#33741 -----<<<<<
                                // ----- ADD ���N 2013/02/07 Redmine#33741 ----->>>>>
                                else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF) || (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && sectionInfo.LogicalDeleteCode != 0))
                                // ----- ADD ���N 2013/02/07 Redmine#33741 -----<<<<<
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����鋒�_�����݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tEdit_SectionCodeAllowZero.Clear();
                                    this.uLabel_SectionName.Text = "";
                                    // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                    this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
                                    this.uLabel_SectionName.Text = this.SectionName;
                                    this._toolSearchFlag = false;
                                    // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    return;
                                }
                                else
                                {
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_STOPDISP,
                                        this.Name,
                                        "���_���̎擾�Ɏ��s���܂����B",
                                        status,
                                        MessageBoxButtons.OK);
                                    this.tEdit_SectionCodeAllowZero.Clear();
                                    this.uLabel_SectionName.Text = "";
                                    // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                    this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
                                    this.uLabel_SectionName.Text = this.SectionName;
                                    this._toolSearchFlag = false;
                                    // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    return;
                                }
                                if (e.ShiftKey == false)
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Right:
                                            {
                                                e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                                break;
                                            }
                                        case Keys.Enter:
                                        case Keys.Tab:
                                            {
                                                if (status == 0)
                                                {
                                                    e.NextCtrl = this.tNedit_CustomerCode;
                                                    break;
                                                }
                                                else
                                                {
                                                    this.tEdit_SectionCodeAllowZero.Clear();
                                                    this.SectionCodeGuide_ultraButton.Text = "";
                                                    //SectionCodeGuide_ultraButton_Click(this.SectionCodeGuide_ultraButton, new EventArgs());  // DEL ���N 2013/02/07 Redmine#33741
                                                    break;
                                                }
                                            }
                                        case Keys.Down:
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                                break;
                                            }
                                    }
                                }
                                // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                else
                                {
                                    switch (e.Key)
                                    {
                                        case Keys.Enter:
                                        case Keys.Tab:
                                            {
                                                if (this.grdDepositList.Rows.Count > 0)
                                                {
                                                    this.grdDepositList.Focus();
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.CustomerGuide_uButton;
                                                }
                                                break;
                                            }
                                    }
                                }
                                // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                            }
                        }
                        else
                        {
                            // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                            if (e.ShiftKey == true)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Enter:
                                    case Keys.Tab:
                                        {
                                            if (this.grdDepositList.Rows.Count > 0)
                                            {
                                                this.grdDepositList.Focus();
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.CustomerGuide_uButton;
                                            }
                                            break;
                                        }
                                }
                            }
                            // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                        }
                        break;
                    }
                case "tNedit_CustomerCode": // ���Ӑ�R�[�h
                    {
                        int code = this.tNedit_CustomerCode.GetInt();
                        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        if (code != 0)
                        {
                            CustomerInfo customerInfo;
                            int customerCode = this.tNedit_CustomerCode.GetInt();
                            //--------------------------------------------------------------------
                            // ���Ӑ�R�[�h���瓾�Ӑ�}�X�^���擾���A������R�[�h�Ɣ�r
                            // ���Ӑ�R�[�h�Ɛ�����R�[�h�ɍ��ق�����ꍇ�͐�����R�[�h�ōČ���
                            //--------------------------------------------------------------------
                            status = GetCustomerInfo(out customerInfo, customerCode);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.tNedit_CustomerCode.DataText = customerInfo.CustomerCode.ToString();
                                this.uLabel_CustomerName.Text = customerInfo.CustomerSnm;
                                // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                this._custCode = customerInfo.CustomerCode;
                                this._custName = customerInfo.CustomerSnm;
                                // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                            }
                            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                if (this.tNedit_CustomerCode.GetInt() != 0)
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y�����链�Ӑ悪���݂��܂���B",
                                        status,
                                        MessageBoxButtons.OK);
                                // ---- DEL ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                //this.tNedit_CustomerCode.Clear();
                                //this.uLabel_CustomerName.Text = "";
                                // ---- DEL ���N 2013/02/07 Redmine#33741 ----- <<<<<
                                // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                                this.tNedit_CustomerCode.DataText = this._custCode.ToString();
                                this.uLabel_CustomerName.Text = this._custName;
                                this._toolSearchFlag = false;
                                // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                                //e.NextCtrl = this.tNedit_CustomerCode; // DEL ���N 2013/02/07 Redmine#33741
                                e.NextCtrl = this.CustomerGuide_uButton; // ADD ���N 2013/02/07 Redmine#33741
                            }
                            else
                            {
                            }
                        }
                        else
                        {
                            this.uLabel_CustomerName.Text = "";
                        }
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                case Keys.Right:
                                    {
                                        if (status == 0)
                                        {
                                            e.NextCtrl = this.grdDepositList;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.CustomerGuide_uButton;
                                        }
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        if (status == 0)
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        }
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        // --- DEL ���N 2013/02/07 Redmine#33741 ---- >>>>>
                                        //if (status == 0)
                                        //{
                                        // --- DEL ���N 2013/02/07 Redmine#33741 ---- >>>>>
                                        if (this.grdDepositList.Rows.Count > 0)
                                        {
                                            e.NextCtrl = this.grdDepositList;
                                        }
                                        // --- DEL ���N 2013/02/07 Redmine#33741 ---- >>>>>
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                        // --- ADD ���N 2013/02/07 Redmine#33741 ---- <<<<<
                                        /* --- DEL ���N 2013/02/07 Redmine#33741 ---- >>>>>
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_CustomerCode;
                                        }
                                       // --- DEL ���N 2013/02/07 Redmine#33741 ---- >>>>>*/
                                        break;
                                    } 
                            }
                        }
                        // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                        break;
                    }
                case "SectionCodeGuide_ultraButton":�@�@//���_�K�C�h
                    {
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                                case Keys.Left:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.CustomerGuide_uButton;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                        break;
                    }
                case "CustomerGuide_uButton":�@�@// ���Ӑ�K�C�h
                    {
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Left:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        e.NextCtrl = this.SectionCodeGuide_ultraButton;
                                        break;
                                    }
                                case Keys.Down:
                                    {
                                        e.NextCtrl = this.CustomerGuide_uButton;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                        else
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Enter:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                            }
                        }
                        // ---- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                        break;
                    }
                case "grdDepositList":
                    {
                        if (e.ShiftKey == false)
                        {
                            switch (e.Key)
                            {
                                case Keys.Enter:
                                    {
                                        if (this.grdDepositList.Rows.Count > 0 && this.grdDepositList.ActiveRow != null)
                                        {
                                            grdDepositList_DoubleClickRow(this.grdDepositList, new DoubleClickRowEventArgs(this.grdDepositList.ActiveRow, RowArea.CellArea));
                                        }
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// DoubleClickRow �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �L�[�������ꂽ���ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void grdDepositList_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            int guidRowIndex = e.Row.Index;
            string slipNo = this.grdDepositList.Rows[guidRowIndex].Cells[InputDepositNormalTypeAcs.ctDepositSlipNo].Value.ToString();
            DataTable dt = this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable];
            DataRow dr = this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositGuidDataTable].NewRow();
            DataRow[] drLike = dt.Select("DepositSlipNo = " + slipNo);
            if (drLike.Length > 0)
            {
                dr = drLike[0];
            }
            CustomerInfo customerInfo;
            //�`�[�̓��Ӑ�R�[�h
            int customerCode = Convert.ToInt32(dr[InputDepositNormalTypeAcs.ctCustomerCode].ToString());
            //���Ӑ���擾����
            int statusCt = GetCustomerInfo(out customerInfo, customerCode);
            if (statusCt == 0)
            {
                // �[������̓`�F�b�N
                if (customerInfo.IsCustomer != true)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�[����͓��͂ł��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    int claimCode = customerInfo.ClaimCode;
                    CustomerInfo claimInfo;
                    statusCt = GetCustomerInfo(out claimInfo, claimCode);
                    if (claimInfo.IsCustomer != true)
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�[����͓��͂ł��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            else
            {
                TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���Ӑ�͑��݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                return;
            }
            this._inputDepositNormalTypeAcs.ClearDsDepositInfoUE();

            this._inputDepositNormalTypeAcs.GetDsDepositInfo().Tables[InputDepositNormalTypeAcs.ctDepositDataTable].ImportRow(dr);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// ToolBar��click�E�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ToolBar��click�E�C�x���g�B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// <br>Update Note : 2013/02/07 ���N</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // ----- ADD ���N 2013/02/07 Redmine#33741 ----->>>>>
                        this._toolSearchFlag = true;
                        if (this.tEdit_SectionCodeAllowZero.Focused)
                        {
                            tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero, null));
                        }
                        if (this.tNedit_CustomerCode.Focused)
                        {
                            tArrowKeyControl1_ChangeFocus(null, new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tNedit_CustomerCode, null));
                        }
                        // ----- ADD ���N 2013/02/07 Redmine#33741 -----<<<<<
                        string message;
                        /* ----- DEL ���N 2013/02/07 Redmine#33741 ----->>>>>
                        if (!"00".Equals(this.tEdit_SectionCodeAllowZero.DataText.TrimEnd()))
                        {
                            this._searchDepositParameter.AddUpSecCode = this.tEdit_SectionCodeAllowZero.DataText.TrimEnd();
                        }
                        else
                        {
                            this._searchDepositParameter.AddUpSecCode = "";
                        }
                        // ----- DEL ���N 2013/02/07 Redmine#33741 -----<<<<< */
                        // ----- ADD ���N 2013/02/07 Redmine#33741 ----- >>>>>
                        if ("00".Equals(this.SectionCode))
                        {
                            this._searchDepositParameter.AddUpSecCode = "";
                        }
                        else
                        {
                            this._searchDepositParameter.AddUpSecCode = this.SectionCode;
                        }
                        if (!this._toolSearchFlag)
                        {
                            return;
                        }
                        // ----- ADD ���N 2013/02/07 Redmine#33741 ----- <<<<<
                        this._searchDepositParameter.CustomerCode = this.tNedit_CustomerCode.GetInt();
                        this._status = _inputDepositNormalTypeAcs.SearchDepositGuidOnlyMode(this._searchDepositParameter, out message);
                        switch (this._status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    this.grdDepositList.Rows[0].Activate();// ADD ���N 2013/02/07 Redmine#33741
                                    this.grdDepositList.Focus();
                                    break;
                                }
                            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                {
                                    // �����`�[�����݂��Ȃ�������
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                                  this.Name,
                                                  message,
                                                  0,
                                                  MessageBoxButtons.OK);
                                    break;
                                }
                            default:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                                  this.Name,
                                                  "�����`�[�̓Ǎ������Ɏ��s���܂����B" + "\r\n\r\n" + message,
                                                  this._status,
                                                  MessageBoxButtons.OK);
                                    return;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void SectionCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.DataText = sectionInfo.SectionCode.TrimEnd();
                this.uLabel_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
            }
            else
            {
                //�O�񋒓_
                this.tEdit_SectionCodeAllowZero.DataText = this.SectionCode;
                this.uLabel_SectionName.Text = this.SectionName;
            }
        }

        /// <summary>
        /// ���_�R�[�hEnter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ���_�R�[�hEnter�C�x���g�B</br>
        /// <br>Programmer : ���N</br>
        /// <br>�Ǘ��ԍ�   : 10806793-00 2013/03/13�z�M��</br>
        /// <br>             Redmine#33741�̑Ή�</br>
        /// <br>Date	   : 2012/12/24</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero_Enter(object sender, EventArgs e)
        {
            // �[���l�߉���
            this.tEdit_SectionCodeAllowZero.Text = this.uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", this.tEdit_SectionCodeAllowZero.Text);
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note�@�@�@  : Guid�ɃL�[�������ꂽ���ɔ������܂��B </br>
        /// <br>Programmer  : ���N</br>
        /// <br>Date        : 2012/12/24</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>              Redmine#33741�̑Ή�</br>
        /// </remarks>
        private void grdDepositList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (this.grdDepositList.Rows.Count > 0 && this.grdDepositList.ActiveRow != null)
                        {
                            if (this.grdDepositList.Rows[0].Activated)
                            {
                                this.tNedit_CustomerCode.Focus();
                            }
                        }
                        break;
                    }
            }
        }
        #endregion
    }
}