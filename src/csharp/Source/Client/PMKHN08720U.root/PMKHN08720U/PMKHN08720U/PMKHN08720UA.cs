//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^���
// �v���O�����T�v   : �\���敪�}�X�^����t�H�[��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �� �� ��  2012/06/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F�L�w��
// �C �� ��  2012/07/03  �C�����e �FRedmine#30390 �\���敪�}�X�^���
//                                  ���Ӑ�|���O���[�v�A�I�����Ӑ�R�[�h�ƃ`�F�b�N�̉���
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �\���敪�}�X�^���
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���敪�}�X�^����N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : �L�w��</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// </remarks>
    public partial class PMKHN08720UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {
        #region �� Constructor
        /// <summary>
        /// �N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���X�R���X�g���N�^�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public PMKHN08720UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �f�[�^�A�N�Z�X
            this._priceSelectSetAcs = new PriceSelectSetAcs();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();
        }
        #endregion

        #region �� Private member

        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;

        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = true;

        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;

        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;

        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;

        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        // �f�[�^�A�N�Z�X
        private PriceSelectSetAcs _priceSelectSetAcs;

        // ���o�����N���X
        private PriceSelectSetPrint _priceSelectSetPrintWork;

        // ���[�J�[�K�C�h
        private MakerAcs _makerAcs;

        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;

        // ���Ӑ�|���O���[�v�K�C�h
        private UserGuideAcs _userGuideAcs;

        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;

        // ���Ӑ�K�C�h
        private UltraButton _customerGuideSender;
        #endregion �� Private member

        #region  �� Private cost
        // �N���XID
        private const string ct_ClassID = "PMKHN08720UA";

        // �v���O����ID
        private const string ct_PGID = "PMKHN08720U";

        // ���[����
        private string _printName = "�\���敪�}�X�^�i����j";

        // ���[�L�[	
        private string _printKey = "aa37c077-6bcb-4700-9938-a23a1f7545c2";   // �ۗ�

        // ExporerBar �O���[�v����
        private const string PRINTSET_TABLE = "PRICESELECTSETRF";

        // dataview���̗p
        private const string CUSTOMERCODE = "customercode";         // ���Ӑ�
        private const string CUSTOMERNAME = "customername";         // ���Ӑ於
        private const string BLGROUPCODE = "blgroupcode";           // ���Ӑ�|���O���[�v
        private const string MAKERCODE = "makercode";               // ���[�J�[
        private const string MAKERNAME = "makername";               // ���[�J�[��
        private const string BLGOODSCODE = "blgoodscode";           // BL�R�[�h
        private const string BLGOODSNAME = "blgoodsname";           // BL�R�[�h��
        private const string PRICESELECTDIV = "priceselectdiv";     // �\���敪

        // ���Ӑ�
        private const string CUSTOMERCODE_TITLE = "���Ӑ�";
        // ���Ӑ於
        private const string CUSTOMERNAME_TITLE = "���Ӑ於";
        // ���Ӑ�|���O���[�v
        private const string BLGROUPCODE_TITLE = "���Ӑ�|���O���[�v";
        // ���[�J�[
        private const string MAKERCODE_TITLE = "���[�J�[";
        // ���[�J�[��
        private const string MAKERNAME_TITLE = "���[�J�[��";
        // BL�R�[�h
        private const string BLGOODSCODE_TITLE = "BL�R�[�h";
        // BL�R�[�h��
        private const string BLGOODSNAME_TITLE = "BL�R�[�h��";
        // ���i�\���敪
        private const string PRICESELECTDIV_TITLE = "���i�\���敪";
        #endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\���v���p�e�B </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion �� Public Property

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = 0;
            ArrayList secPrintSets = null;

            // ��ʁ����o�����N���X
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 0)
            {
                status = this._priceSelectSetAcs.Search(out secPrintSets, this._enterpriseCode, this._priceSelectSetPrintWork);
            }

            else
            {
                status = this._priceSelectSetAcs.SearchDelete(out secPrintSets, this._enterpriseCode, this._priceSelectSetPrintWork);
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {

                        // ���ʃN���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (PriceSelectSet priceSelectSet in secPrintSets)
                        {

                            SecPrintSetToDataSet(priceSelectSet.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ct_ClassID, 					    // �A�Z���u���h�c�܂��̓N���X�h�c
                            this._printName, 			        // �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._priceSelectSetAcs, 			// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }
            return 0;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note	   : ����������s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				        // �N��PGID

            // PDF�o�͗���p
            printInfo.key = this._printKey;
            printInfo.prpnm = this._printName;

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            // ���o�����̐ݒ�
            printInfo.jyoken = this._priceSelectSetPrintWork;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note	�@ : ��ʕ\�����s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._priceSelectSetPrintWork = new PriceSelectSetPrint();

            this.Show();
            return;
        }
        #endregion

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public void GetBindDataSet(ref DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// ���C���t���[���O���b�g���C�A�E�g�ݒ�
        /// </summary>
        /// <param name="UGrid"></param>
        /// <remarks>
        /// <br>Note       : ���C���t���[���O���b�g���C�A�E�g�ݒ�B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public void SetGridStyle(ref Infragistics.Win.UltraWinGrid.UltraGrid UGrid)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = UGrid.DisplayLayout.Bands[0];
            if (editBand == null) return;

            UGrid.DisplayLayout.Bands[0].UseRowLayout = true;

            // �񕝂̎����������@
            UGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            UGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            UGrid.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            UGrid.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            UGrid.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            UGrid.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            UGrid.DisplayLayout.Bands[0].RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            UGrid.DisplayLayout.Bands[0].RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            #region ���ڂ̃T�C�Y��ݒ�

            // ���Ӑ�
            sizeCell.Width = 80;
            sizeHeader.Width = 80;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���Ӑ於
            sizeCell.Width = 220;
            sizeHeader.Width = 220;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���Ӑ�|���O���[�v
            sizeCell.Width = 170;
            sizeHeader.Width = 170;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���[�J�[
            sizeCell.Width = 70;
            sizeHeader.Width = 70;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // ���[�J�[��
            sizeCell.Width = 330;
            sizeHeader.Width = 330;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // BL�R�[�h
            sizeCell.Width = 70;
            sizeHeader.Width = 70;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // BL�R�[�h��
            sizeCell.Width = 270;
            sizeHeader.Width = 270;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            // �\���敪
            sizeCell.Width = 130;
            sizeHeader.Width = 130;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;
            #endregion  ���ڂ̃T�C�Y��ݒ�

            #region LabelSpan�̐ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.LabelSpan = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.LabelSpan = 2;
            #endregion LabelSpan�̐ݒ�

            // �w�b�_���̂�ݒ�
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].Header.Caption = CUSTOMERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].Header.Caption = CUSTOMERNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].Header.Caption = BLGROUPCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].Header.Caption = MAKERCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].Header.Caption = MAKERNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].Header.Caption = BLGOODSCODE_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].Header.Caption = BLGOODSNAME_TITLE;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].Header.Caption = PRICESELECTDIV_TITLE;

            // 1�s��
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginX = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.OriginX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[CUSTOMERNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginX = 4;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGROUPCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.OriginX = 6;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginX = 8;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[MAKERNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginX = 10;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSCODE].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.OriginX = 12;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[BLGOODSNAME].RowLayoutColumnInfo.SpanY = 2;

            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.OriginX = 14;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.OriginY = 0;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.SpanX = 2;
            UGrid.DisplayLayout.Bands[0].Columns[PRICESELECTDIV].RowLayoutColumnInfo.SpanY = 2;
        }

        /// <summary>
        /// ���o�����`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�����`�F�b�N�������s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>Update Note: 2012/07/03 �L�w��</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// <br>             Redmine#30390 �\���敪�}�X�^��� ���Ӑ�|���O���[�v�A�I�����Ӑ�R�[�h�ƃ`�F�b�N�̉���</br>
        /// </remarks>
        public bool DataCheck()
        {
            bool status = true;

            // ���s�^�C�v
            if (this._priceSelectSetPrintWork.PrintType != (int)this.tComboEditor_PrintType.Value)
            {
                status = false;
                return status;
            }

            // �J�n���i���[�J�[�R�[�h
            if (this._priceSelectSetPrintWork.GoodsMakerCdSt != this.tNedit_GoodsMakerCd_St.GetInt())
            {
                status = false;
                return status;
            }

            // �I�����i���[�J�[�R�[�h
            if (this._priceSelectSetPrintWork.GoodsMakerCdEd != this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                status = false;
                return status;
            }

            // �J�nBL���i�R�[�h
            if (this._priceSelectSetPrintWork.BLGoodsCodeSt != this.tNedit_BLGoodsCode_St.GetInt())
            {
                status = false;
                return status;
            }

            // �I��BL���i�R�[�h
            if (this._priceSelectSetPrintWork.BLGoodsCodeEd != this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                status = false;
                return status;
            }

            // �J�n���Ӑ�|���O���[�v
            // if (this._priceSelectSetPrintWork.BLGroupCodeSt != this.tNedit_BLGoodsCode_St.DataText)  // DEL 2012/07/03 �L�w�� Redmine#30390
            if (this._priceSelectSetPrintWork.BLGroupCodeSt != this.tNedit_CustRateGroupCodeAllowZero_St.DataText)  // ADD 2012/07/03 �L�w�� Redmine#30390
            {
                status = false;
                return status;
            }

            // �I�����Ӑ�|���O���[�v
            // if (this._priceSelectSetPrintWork.BLGroupCodeEd != this.tNedit_BLGoodsCode_Ed.DataText)  // DEL 2012/07/03 yaoxg Redmine#30390
            if (this._priceSelectSetPrintWork.BLGroupCodeEd != this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText)  // ADD 2012/07/03 �L�w�� Redmine#30390
            {
                status = false;
                return status;
            }

            // �J�n���Ӑ�R�[�h
            if (this._priceSelectSetPrintWork.CustomerCodeSt != this.tNedit_CustomerCode_St.GetInt())
            {
                status = false;
                return status;
            }

            // �I�����Ӑ�R�[�h
            // if (this._priceSelectSetPrintWork.CustomerCodeEd != this.tNedit_BLGoodsCode_Ed.GetInt()) // DEL 2012/07/03 �L�w�� Redmine#30390
            if (this._priceSelectSetPrintWork.CustomerCodeEd != this.tNedit_CustomerCode_Ed.GetInt())   // ADD 2012/07/03 �L�w�� Redmine#30390
            {
                status = false;
                return status;
            }

            // �폜�w��
            if (this._priceSelectSetPrintWork.LogicalDeleteCode != (int)this.tComboEditor_LogicalDeleteCode.Value)
            {
                status = false;
                return status;
            }

            // �J�n�폜�N����
            if (this._priceSelectSetPrintWork.DeleteDateTimeSt != this.SerchSlipDataStRF_tDateEdit.GetDateTime())
            {
                status = false;
                return status;
            }

            // �I���폜�N����
            if (this._priceSelectSetPrintWork.DeleteDateTimeEd != this.SerchSlipDataEdRF_tDateEdit.GetDateTime())
            {
                status = false;
                return status;
            }

            return status;
        }
        #endregion �� Public Method
        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return this._printKey; }
        }
        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return this._printName; }
        }

        #endregion
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���͍��ڂ̏��������s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �����l�Z�b�g�E������
                // ���[�J�[�R�[�h�i�J�n�j
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                // ���[�J�[�R�[�h�i�I���j
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                // �a�k�R�[�h�i�J�n�j
                this.tNedit_BLGoodsCode_St.DataText = string.Empty;
                // �a�k�R�[�h�i�I���j
                this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
                // ���Ӑ�R�[�h�i�J�n�j
                this.tNedit_CustomerCode_St.DataText = string.Empty;
                // ���Ӑ�R�[�h�i�I���j
                this.tNedit_CustomerCode_Ed.DataText = string.Empty;
                // ���Ӑ�|���O���[�v�i�J�n�j 
                this.tNedit_CustRateGroupCodeAllowZero_St.DataText = string.Empty;
                // ���Ӑ�|���O���[�v�i�I���j
                this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText = string.Empty;

                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);

                // �폜�w��R���{�̐ݒ�
                this.tComboEditor_LogicalDeleteCode.Value = 0;
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_DetailGoodsGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_DetailGoodsGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_St_CustomerGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_CustomerGuide, Size16_Index.STAR1);

                // �R���{�̏�����
                this.tComboEditor_PrintType.Value = 0;      //���[�J�[+�a�k�R�[�h+���Ӑ�

                // �����t�H�[�J�X�Z�b�g
                this.tComboEditor_PrintType.Focus();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note	   : �{�^���A�C�R���ݒ菈�����s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note	   : ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";

            // ���[�J�[
            if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) && (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) && this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("���[�J�[{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }

            // �a�k�R�[�h
            if (
                (this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = string.Format("�a�k�R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
                return status;
            }

            // ���Ӑ�
            if (
                (this.tNedit_CustomerCode_St.GetInt() != 0) &&
                (this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt())
            {
                errMessage = string.Format("���Ӑ�{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                status = false;
                return status;
            }

            // ���Ӑ�|���O���[�v
            if (
                (!string.IsNullOrEmpty(this.tNedit_CustRateGroupCodeAllowZero_St.Text)) &&
                (!string.IsNullOrEmpty(this.tNedit_CustRateGroupCodeAllowZero_Ed.Text)) &&
                this.tNedit_CustRateGroupCodeAllowZero_St.GetInt() > this.tNedit_CustRateGroupCodeAllowZero_Ed.GetInt())
            {
                errMessage = string.Format("���Ӑ�|���O���[�v{0}", ct_RangeError);
                errComponent = this.tNedit_CustRateGroupCodeAllowZero_St;
                status = false;
                return status;
            }

            // �폜���t
            if ((int)this.tComboEditor_LogicalDeleteCode.Value == 1)
            {
                if (IsErrorTDateEdit(this.SerchSlipDataStRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataStRF_tDateEdit;
                    status = false;
                    return status;
                }

                if (IsErrorTDateEdit(this.SerchSlipDataEdRF_tDateEdit, false, out errMessage) == false)
                {
                    errComponent = this.SerchSlipDataEdRF_tDateEdit;
                    status = false;
                    return status;
                }

                // �͈̓`�F�b�N
                if ((this.SerchSlipDataStRF_tDateEdit.GetDateTime() != DateTime.MinValue) &&
                    (this.SerchSlipDataEdRF_tDateEdit.GetDateTime() != DateTime.MinValue))
                {
                    if (this.SerchSlipDataStRF_tDateEdit.GetDateTime() > this.SerchSlipDataEdRF_tDateEdit.GetDateTime())
                    {
                        errMessage = "�폜���͈͎̔w��Ɍ�肪����܂��B";
                        this.SerchSlipDataStRF_tDateEdit.Focus();
                        return (false);
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="tDateEdit">�`�F�b�N�Ώ�TDateEdit</param>
        /// <param name="minValueCheck">�����̓`�F�b�N�t���O(True:�����͕s�� False:�����͉�)</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note	   : ���t���̓`�F�b�N�������s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private bool IsErrorTDateEdit(TDateEdit tDateEdit, bool minValueCheck, out string errMessage)
        {
            errMessage = "";

            int year = tDateEdit.GetDateYear();
            int month = tDateEdit.GetDateMonth();
            int day = tDateEdit.GetDateDay();

            if (minValueCheck == true)
            {
                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMessage = "���t���w�肵�Ă��������B";
                    return (false);
                }
            }
            else
            {
                if ((year == 0) && (month == 0) && (day == 0))
                {
                    return (true);
                }

                if ((year == 0) || (month == 0) || (day == 0))
                {
                    errMessage = "���t���w�肵�Ă��������B";
                    return (false);
                }
            }

            if (year < 1900)
            {
                errMessage = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (month > 12)
            {
                errMessage = "���������t���w�肵�Ă��������B";
                return (false);
            }

            if (day > DateTime.DaysInMonth(year, month))
            {
                errMessage = "���������t���w�肵�Ă��������B";
                return (false);
            }

            return (true);
        }
        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note	   : ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ���s�^�C�v
                this._priceSelectSetPrintWork.PrintType = (int)this.tComboEditor_PrintType.Value;
                // �J�n���i���[�J�[
                this._priceSelectSetPrintWork.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();
                // �I�����i���[�J�[
                this._priceSelectSetPrintWork.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // �J�nBL���i�R�[�h
                this._priceSelectSetPrintWork.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();
                // �I��BL���i�R�[�h
                this._priceSelectSetPrintWork.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();
                // �J�n���Ӑ�
                this._priceSelectSetPrintWork.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                // �I�����Ӑ�
                this._priceSelectSetPrintWork.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                // �J�n���Ӑ�|���O���[�v
                if (string.IsNullOrEmpty(this.tNedit_CustRateGroupCodeAllowZero_St.DataText))
                {
                    this._priceSelectSetPrintWork.BLGroupCodeSt = string.Empty;
                }
                else
                {
                    this._priceSelectSetPrintWork.BLGroupCodeSt = this.tNedit_CustRateGroupCodeAllowZero_St.DataText.PadLeft(4, '0');
                }
                // �I�����Ӑ�|���O���[�v
                if (string.IsNullOrEmpty(this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText))
                {
                    this._priceSelectSetPrintWork.BLGroupCodeEd = string.Empty;
                }
                else
                {
                    this._priceSelectSetPrintWork.BLGroupCodeEd = this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText.PadLeft(4, '0');
                }
                // �폜�w��敪
                this._priceSelectSetPrintWork.LogicalDeleteCode = (int)this.tComboEditor_LogicalDeleteCode.Value;
                // �J�n�폜���t
                this._priceSelectSetPrintWork.DeleteDateTimeSt = this.SerchSlipDataStRF_tDateEdit.GetDateTime();
                // �I���폜���t
                this._priceSelectSetPrintWork.DeleteDateTimeEd = this.SerchSlipDataEdRF_tDateEdit.GetDateTime();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        #endregion
        #endregion �� ����O����

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="emErrorLevel">�G���[���x��</param>
        /// <param name="errMessage">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel emErrorLevel, string errMessage, int status)
        {
            TMsgDisp.Show(
                emErrorLevel, 						// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }

        #endregion

        #region DataSet�֘A

        /// <summary>
        /// �\���敪�N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="priceSelectSet">�\���敪�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �\���敪�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void SecPrintSetToDataSet(PriceSelectSet priceSelectSet, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            // ���Ӑ�
            if (priceSelectSet.CustomerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERCODE] = priceSelectSet.CustomerCode.ToString("00000000");
            }

            // ���Ӑ於
            if (priceSelectSet.CustomerCode != 0 && string.IsNullOrEmpty(priceSelectSet.CustomerSnm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERNAME] = "���o�^";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CUSTOMERNAME] = priceSelectSet.CustomerSnm;
            }

            // ���Ӑ�|���O���[�v
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 3: // Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
                case 4: // Ұ�����ށE���Ӑ�|����ٰ��
                case 5: // BL���ށE���Ӑ�|����ٰ��
                    this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = priceSelectSet.BLGroupCode.ToString("0000");
                    break;
                case 0: // Ұ�����ށEBL���ށE���Ӑ溰��
                case 1: // Ұ�����ށE���Ӑ溰��
                case 2: // BL���ށE���Ӑ溰��
                case 6: // Ұ�����ށEBL���
                case 7: // Ұ������
                case 8: // BL����
                    this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = DBNull.Value;
                    break;
                case 9: // �S��
                    {
                        if (priceSelectSet.PriceSelectPtn == 3 || priceSelectSet.PriceSelectPtn == 4 || priceSelectSet.PriceSelectPtn == 5)
                        {
                            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = priceSelectSet.BLGroupCode.ToString("0000");
                        }
                        else
                        {
                            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGROUPCODE] = DBNull.Value;
                        }
                        break;
                    }
            }

            // ���[�J�[
            if (priceSelectSet.GoodsMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERCODE] = priceSelectSet.GoodsMakerCd.ToString("0000");
            }

            // ���[�J�[��
            if (priceSelectSet.GoodsMakerCd != 0 && string.IsNullOrEmpty(priceSelectSet.GoodsMakerSnm))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERNAME] = "���o�^";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][MAKERNAME] = priceSelectSet.GoodsMakerSnm;
            }

            // BL�R�[�h
            if (priceSelectSet.BLGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = DBNull.Value;
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = priceSelectSet.BLGoodsCode.ToString("00000");
            }

            // BL�R�[�h��
            if (priceSelectSet.BLGoodsCode != 0 && string.IsNullOrEmpty(priceSelectSet.BLGoodsHalfName))
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSNAME] = "���o�^";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSNAME] = priceSelectSet.BLGoodsHalfName;
            }

            // �\���敪
            if (priceSelectSet.PriceSelectDiv == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESELECTDIV] = "0:�D��";
            }
            if (priceSelectSet.PriceSelectDiv == 1)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESELECTDIV] = "1:����";
            }
            if (priceSelectSet.PriceSelectDiv == 2)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESELECTDIV] = "2:������(1:N)";
            }
            if (priceSelectSet.PriceSelectDiv == 3)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][PRICESELECTDIV] = "3:������(1:1)";
            }
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable secPrintSetTable = new DataTable(PRINTSET_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            secPrintSetTable.Columns.Add(CUSTOMERCODE, typeof(string));		        // ���Ӑ�

            secPrintSetTable.Columns.Add(CUSTOMERNAME, typeof(string));		        // ���Ӑ於

            secPrintSetTable.Columns.Add(BLGROUPCODE, typeof(string));              // ���Ӑ�|���O���[�v

            secPrintSetTable.Columns.Add(MAKERCODE, typeof(string));		        // ���[�J�[

            secPrintSetTable.Columns.Add(MAKERNAME, typeof(string));		        // ���[�J�[��

            secPrintSetTable.Columns.Add(BLGOODSCODE, typeof(string));              // BL�R�[�h

            secPrintSetTable.Columns.Add(BLGOODSNAME, typeof(string));		        // BL�R�[�h��

            secPrintSetTable.Columns.Add(PRICESELECTDIV, typeof(string));		    // �\���敪

            this.Bind_DataSet.Tables.Add(secPrintSetTable);
        }

        #endregion DataSet�֘A
        #endregion �� Private Method
        #endregion �� Private Method

        #region �� Control Event
        #region �� PMKHN08720UA
        #region �� PMKHN08720UA_Load Event

        /// <summary>
        /// PMKHN08720UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ�������B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void PMKHN08720UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }
        #endregion

        #endregion �� PMKHN08720UA

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ���[�J�[�K�C�h���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            if (this._makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            // ���[�J�[�K�C�h
            MakerUMnt makerUMnt;
            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;

                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 0: // Ұ�����ށEBL���ށE���Ӑ溰��
                    case 3: // Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
                    case 6: // Ұ�����ށEBL���
                    case 9: // �S��
                        nextControl = this.tNedit_BLGoodsCode_St;
                        break;
                    case 1: // Ұ�����ށE���Ӑ溰��
                        nextControl = this.tNedit_CustomerCode_St;
                        break;
                    case 4: // Ұ�����ށE���Ӑ�|����ٰ��
                        nextControl = this.tNedit_CustRateGroupCodeAllowZero_St;
                        break;
                    case 7: // Ұ������
                        nextControl = this.tComboEditor_LogicalDeleteCode;
                        break;
                }
            }
            else
            {
                return;
            }

            targetControl.DataText = makerUMnt.GoodsMakerCd.ToString().TrimEnd();

            // ���t�H�[�J�X
            nextControl.Focus();
        }

        /// <summary>
        /// �a�k�R�[�h�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : �a�k�R�[�h�K�C�h���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            BLGoodsCdUMnt blGoodsCdUMnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;

                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 0: // Ұ�����ށEBL���ށE���Ӑ溰��
                    case 9: // �S��
                        nextControl = this.tNedit_CustomerCode_St;
                        break;
                    case 2: // BL���ށE���Ӑ溰��
                        nextControl = this.tNedit_CustomerCode_St;
                        break;
                    case 3: // Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
                    case 5: // BL���ށE���Ӑ�|����ٰ��
                        nextControl = this.tNedit_CustRateGroupCodeAllowZero_St;
                        break;
                    case 6: // Ұ�����ށEBL����
                    case 8: // BL����
                        nextControl = this.tComboEditor_LogicalDeleteCode;
                        break;
                }
            }
            else
            {
                return;
            }

            targetControl.DataText = blGoodsCdUMnt.BLGoodsCode.ToString().TrimEnd();
            // ���t�H�[�J�X
            nextControl.Focus();
        }

        /// <summary>
        /// ���Ӑ溰�ރK�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ���Ӑ溰�ރK�C�h���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void ub_St_CustomerGuide_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            // �K�C�h�㎟�t�H�[�J�X
            if (_customerGuideOK)
            {
                Control nextControl = null;
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.tNedit_CustomerCode_Ed;
                }
                else
                {
                    switch ((int)this.tComboEditor_PrintType.Value)
                    {
                        case 0: // Ұ�����ށEBL���ށE���Ӑ溰��
                        case 1: // Ұ�����ށE���Ӑ溰��
                        case 2: // BL���ށE���Ӑ溰��
                            nextControl = this.tComboEditor_LogicalDeleteCode;
                            break;
                        case 9: // �S��
                            nextControl = this.tNedit_CustRateGroupCodeAllowZero_St;
                            break;
                    }
                }
                // �t�H�[�J�X�ړ�
                nextControl.Focus();
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        /// <remarks>
        /// <br>Note	   : ���Ӑ�K�C�h�I���C�x���g�K�C�h���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            if (_customerGuideSender == this.ub_St_CustomerGuide)
            {
                this.tNedit_CustomerCode_St.SetInt(customerSearchRet.CustomerCode);
                _customerGuideOK = true;
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerSearchRet.CustomerCode);
                _customerGuideOK = true;
            }
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ���Ӑ�|���O���[�v�K�C�h���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void ub_St_DetailGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            int GuideNo = 43;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo); // �K�C�h�f�[�^�T�[�`���[�h(1:�����[�g)

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_CustRateGroupCodeAllowZero_St;
                nextControl = this.tNedit_CustRateGroupCodeAllowZero_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_CustRateGroupCodeAllowZero_Ed;
                switch ((int)this.tComboEditor_PrintType.Value)
                {
                    case 3: // Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
                    case 4: // Ұ�����ށE���Ӑ�|����ٰ��
                    case 5: // BL���ށE���Ӑ�|����ٰ��
                    case 9: // �S��
                        nextControl = this.tComboEditor_LogicalDeleteCode;
                        break;
                }
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // �t�H�[�J�X�ړ�
            nextControl.Focus();
        }

        /// <summary>
        /// �폜�w��ݒ莞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : �폜�w��ݒ莞���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void tComboEditor_LogicalDeleteCode_ValueChanged(object sender, EventArgs e)
        {
            if ((int)tComboEditor_LogicalDeleteCode.Value == 1)
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = true;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = true;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.Now);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.Now);
            }
            else
            {
                this.SerchSlipDataStRF_tDateEdit.Enabled = false;
                this.SerchSlipDataEdRF_tDateEdit.Enabled = false;
                this.SerchSlipDataStRF_tDateEdit.SetDateTime(DateTime.MinValue);
                this.SerchSlipDataEdRF_tDateEdit.SetDateTime(DateTime.MinValue);
            }
        }

        /// <summary>
        /// ���s�^�C�v�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note	   : ���s�^�C�v�ύX���s���B</br>
        /// <br>Programmer : �L�w��</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        private void tComboEditor_PrintType_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)this.tComboEditor_PrintType.Value)
            {
                case 0: // Ұ�����ށEBL���ށE���Ӑ溰��
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = true;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 1: // Ұ�����ށE���Ӑ溰��
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = false;
                    this.pn_CustomerCode.Visible = true;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 2: // BL���ށE���Ӑ溰��
                    this.pn_GoodsMakerCd.Visible = false;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = true;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 3: // Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = true;
                    break;

                case 4: // Ұ�����ށE���Ӑ�|����ٰ��
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = false;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = true;
                    break;

                case 5: // BL���ށE���Ӑ�|����ٰ��
                    this.pn_GoodsMakerCd.Visible = false;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = true;
                    break;

                case 6: // Ұ�����ށEBL����
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 7: // Ұ������
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = false;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 8: // BL����
                    this.pn_GoodsMakerCd.Visible = false;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = false;
                    this.pn_BLGloupCode.Visible = false;
                    break;

                case 9: // �S��
                    this.pn_GoodsMakerCd.Visible = true;
                    this.pn_BLGoodsCode.Visible = true;
                    this.pn_CustomerCode.Visible = true;
                    this.pn_BLGloupCode.Visible = true;
                    break;
            }
            this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
            this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
            this.tNedit_BLGoodsCode_St.DataText = string.Empty;
            this.tNedit_BLGoodsCode_Ed.DataText = string.Empty;
            this.tNedit_CustomerCode_St.DataText = string.Empty;
            this.tNedit_CustomerCode_Ed.DataText = string.Empty;
            this.tNedit_CustRateGroupCodeAllowZero_St.DataText = string.Empty;
            this.tNedit_CustRateGroupCodeAllowZero_Ed.DataText = string.Empty;
        }
        #endregion �� Control Event
    }
}
