//****************************************************************************//
// �V�X�e��         : PM.NS                                                   //
// �v���O��������   : ���i�o�[�R�[�h�ꊇ�o�^                                  //
// �v���O�����T�v   : ���i�o�[�R�[�h�ꊇ�o�^ UI�N���X                 �@�@    //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// ����                                                                       //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������                                 //
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬                                  //
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 3H �k�P�N                                  //
// �� �� ��  2017/09/22  �C�����e : �n���f�B�Ή��i2���j���i�o�[�R�[�h�ꊇ�o�^�̉���//
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770175-00 �쐬�S�� : ������                                    //
// �C �� ��  2021/11/03  �C�����e : PJMIT-1499 OUT OF MEMORY�Ή�(4GB�Ή�)     //
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Infragistics.Win.UltraWinGrid;
using System.IO;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�o�[�R�[�h�ꊇ�o�^ UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i�o�[�R�[�h�ꊇ�o�^ UI�N���X</br>
    /// <br>Programmer  : 3H ������</br>
    /// <br>Date        : 2017/06/12</br>
    /// <br>Update Note: 2021/11/03 ������</br>
    /// <br>�Ǘ��ԍ�   : 11770175-00</br>
    /// <br>             PJMIT-1499�@OUT OF MEMORY�Ή�(4GB�Ή�)</br>
    /// </remarks>
    public partial class PMHND09210UA : Form
    {
        # region [private field]
        /// <summary>���_�A�N�Z�X</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>�q�ɃA�N�Z�X</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>���[�J�[�A�N�Z�X</summary>
        private MakerAcs _makerAcs;
        /// <summary>���i�o�[�R�[�h�A�N�Z�X</summary>
        private GoodsBarCodeRevnAcs _goodsBarCodeRevnAcs;
        // �O����͌����������(�w�b�_�p)
        private GoodsBarCodeRevnSearchPara _prevHeaderInfo;

        private string _enterpriseCode;             // ��ƃR�[�h
        private ImageList _imageList16 = null;									// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		// �����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// ����{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;		// �ۑ��{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _inputTextButton;		// �捞�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _extractTextButton;		// �e�L�X�g�{�^��

        /// <summary>��ʃR���g���[���X�L��</summary>
        private ControlScreenSkin _controlScreenSkin;
        /// <summary>���i�o�[�R�[�h�f�[�^�e�[�u��</summary>
        private DataTable _goodsBarCodeDt = null;
        /// <summary>���i�o�[�R�[�h�f�[�^�r���[</summary>
        private DataView _goodsBarCodeView;
        // ���i�o�[�R�[�h�֘A�t���f�B�N�V���i��
        private Dictionary<string, GoodsBarCodeRevn> _goodsBarCodeRevnDic;

        // �O�I���s�C���f�b�N�X(�w�i�F�ݒ�p)
        private List<int> _beforeSelectRowIndexList = new List<int>();

        /// <summary>�O���b�h�ݒ萧��N���X</summary>
        private GridStateController _gridStateController;

        /// <summary>�e�L�X�g�o�͗p�ݒ�XML����̎擾�ݒ�</summary>
        private GoodsBarCodeRevnExtractTextUserConst _userSetting;

        # endregion

        # region [private const]
        // �N���XID
        private const string ct_ClassID = "PMHND09210UA";
        // �N���X����
        private const string ct_ClassName = "���i�o�[�R�[�h�ꊇ�o�^";
        // �O���b�h�\���ő匏���F5000
        private const int ct_MaxCount = 5000;
        // CsvTitle�o�͗p
        private string[] ctCsvTitle = new string[] { "GoodsMakerCd", "GoodsNo", "GoodsBarCode", "GoodsBarCodeKind", "MakerName", "GoodsName"};
        // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------>>>>> 
        // �������A�E�g���̃G���[���b�Z�[�W
        private const string INFO_MEMORYOUT_MSG = "�������鏤�i�����������܂��B����������ǉ����āA�ēx�������s���ĉ������B";
        // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------<<<<<
        # endregion

        # region [private readonly]
        // �K�{���͍��ڃo�b�N�J���[
        private readonly Color ct_EssentialColor = Color.FromArgb(179, 219, 231);
        // ��K�{���͍��ڃo�b�N�J���[
        private readonly Color ct_OptionalColor = Color.FromArgb(255, 255, 255);
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�t�H���g�R���X�g���N�^</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public PMHND09210UA()
        {
            InitializeComponent();

            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            this._inputTextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_InPutText"];
            this._extractTextButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"];
            this._controlScreenSkin = new ControlScreenSkin();
            // �O���b�h�ݒ萧��
            this._gridStateController = new GridStateController();
            // �O����͌����������(�w�b�_�p)
            this._prevHeaderInfo = new GoodsBarCodeRevnSearchPara();
            // ���i�o�[�R�[�h�A�N�Z�X
            this._goodsBarCodeRevnAcs = new GoodsBarCodeRevnAcs();
            // ���i�o�[�R�[�h�֘A�t���f�B�N�V���i��
            this._goodsBarCodeRevnDic = new Dictionary<string, GoodsBarCodeRevn>();
        }
        # endregion

        # region [����������]

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈�����܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            // �I���{�^��
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // �����{�^��
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // �N���A�{�^��
            this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // �ۑ��{�^��
            this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // �捞�{�^��
            this._inputTextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVTAKING;
            // �e�L�X�g�o�̓{�^��
            this._extractTextButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            // ���_�K�C�h
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // �q�ɃK�C�h
            this.uButton_WarehouseGuide.ImageList = this._imageList16;
            this.uButton_WarehouseGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // ���[�J�[�K�C�h
            this.uButton_GoodsMakerGuide.ImageList = this._imageList16;
            this.uButton_GoodsMakerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            // �s�폜�{�^��
            this.uButton_RowGoodsDelete.ImageList = this._imageList16;
            this.uButton_RowGoodsDelete.Appearance.Image = (int)Size16_Index.ROWDELETE;
            // �s�����{�^��
            this.uButton_RowGoodsRevive.ImageList = this._imageList16;
            this.uButton_RowGoodsRevive.Appearance.Image = (int)Size16_Index.RENEWAL;

            // �e�L�X�g�o�̓{�^����Visible���Z�b�g
            this.SetExtractToolButtonVisible();
            // �ۑ��{�^��
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            // �e�L�X�g�o�̓{�^��
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;

            // �폜�{�^����s�ɂ���
            this.uButton_RowGoodsDelete.Enabled = false;
            // �����{�^����s�ɂ���
            this.uButton_RowGoodsRevive.Enabled = false;

        }

        /// <summary>
        /// �e�L�X�g�o�͊֘A�{�^���̗��p�ۃZ�b�g����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͊֘A�{�^���̗��p�ۃZ�b�g����</br>
        /// <br>Programmer  : 3H ������</br>
        /// <br>Date        : 2017/06/12</br>
        /// </remarks>
        private void SetExtractToolButtonVisible()
        {
            // �I�v�V�����R�[�h�̃e�L�X�g�o�͂��Q��
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus textOutputPs;
            textOutputPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (textOutputPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // �e�L�X�g�o�̓{�^���\��
                // Enable�͌������true�ɂ���
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Visible = true;
            }
            else
            {
                // �e�L�X�g�o�̓{�^����\��
                this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Visible = false;
            }
        }

        /// <summary>
        /// ��ʃw�b�_�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʃw�b�_�����ݒ菈�����܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2017/09/22 3H �k�P�N</br>
        /// <br>�Ǘ��ԍ�   : 11370074-00 �n���f�B�Ή��i2���j</br>
        /// <br>             ���i�o�[�R�[�h�ꊇ�o�^�̉���</br>
        /// </remarks>
        private void HeaderInitialSetting()
        {
            // �݌ɋ敪 0:�݌ɂ̂�
            this.tEdit_StockDiv.Text = "0";
            this.tEdit_StockDiv.Appearance.BackColor = this.ct_EssentialColor;

            // �o�^�敪 0:�S��
            this.tEdit_HaveBarCodeDiv.Text = "0";
            this.tEdit_HaveBarCodeDiv.Appearance.BackColor = this.ct_EssentialColor;

            // ���[�J�[
            this.tNedit_GoodsMakerCd.Clear();
            //this.tNedit_GoodsMakerCd.Appearance.BackColor = this.ct_EssentialColor; // --- DEL 3H �k�P�N 2017/09/22
            this.uLabel_MakerName.Text = string.Empty;

            // �i��
            this.tEdit_GoodsNo.Text = string.Empty;
            this.tEdit_GoodsNo.Appearance.BackColor = this.ct_OptionalColor;

            // ���_
            this.tEdit_SectionCode.Text = string.Empty;
            this.uLabel_SectionName.Text = string.Empty;
            this.tEdit_SectionCode.Enabled = true;
            this.uButton_SectionGuide.Enabled = true;

            // �q��
            this.tEdit_WarehouseCode.Text = string.Empty;
            this.tEdit_WarehouseCode.Appearance.BackColor = this.ct_EssentialColor;
            this.uLabel_WarehouseName.Text = string.Empty;
            this.tEdit_WarehouseCode.Enabled = true;
            this.uButton_WarehouseGuide.Enabled = true;

            // �݌ɋ敪
            this.tEdit_StockDiv.Focus();

            // �O����͌����������(�w�b�_�p)
            this._prevHeaderInfo = new GoodsBarCodeRevnSearchPara();
        }

        /// <summary>
        /// �O���b�h�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�����ݒ菈�����܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GridInitialSetting()
        {
            // ���i�o�[�R�[�h�f�[�^�e�[�u��
            GoodsBarCodeRevnTbl.CreateDataTable(ref _goodsBarCodeDt);
            // ���i�o�[�R�[�h�f�[�^�r���[
            _goodsBarCodeView = new DataView(_goodsBarCodeDt);
            GoodsBarCodeRevn_Grid.DataSource = _goodsBarCodeView;
            // �O���b�h�ݒ萧��
            _gridStateController.SetGridStateToGrid(ref this.GoodsBarCodeRevn_Grid);
        }

        # endregion

        # region �c�[���o�[�{�^���C�x���g����
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�{�^���N���b�N�C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        CloseProcess();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // ��������
                        SearchProcess();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // �N���A����
                        ClearProcess();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // �ۑ�����
                        SaveProcess();
                        break;
                    }
                case "ButtonTool_InPutText":
                    {
                        // �捞����
                        InputTextProcess();
                        break;
                    }
                case "ButtonTool_ExtractText":
                    {
                        // �e�L�X�g�o�͏���
                        ExtractTextProcess();
                        break;
                    }
            }
        }

        # region �I������
        /// <summary>
        /// �t�H�[���I������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���I���������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void CloseProcess()
        {
            // �ҏW���̃f�[�^�����ݏ�
            if (GridDataIsChange())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "��ʂ��I���������܂����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            // ��ʏI��
            this.Close();
        }
        # endregion

        # region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2021/11/03 ������</br>
        /// <br>�Ǘ��ԍ�   : 11770175-00</br>
        /// <br>             PJMIT-1499�@OUT OF MEMORY�Ή�(4GB�Ή�)</br> 
        /// </remarks>
        private void SearchProcess()
        {
            // �����������`�F�b�N
            if (!CheckSearchPara()) return;

            // �ҏW���̃f�[�^�����ݏ�
            if (GridDataIsChange())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "�j�����Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
            // �폜�{�^����s�ɂ���
            this.uButton_RowGoodsDelete.Enabled = false;
            // �����{�^����s�ɂ���
            this.uButton_RowGoodsRevive.Enabled = false;
            // ���ʏ�������ʐ���
            SFCMN00299CA form = new SFCMN00299CA();
            try
            {
                // ���ʏ�������ʃv���p�e�B�ݒ�
                form.Title = "���o��";                            // ��ʂ̃^�C�g�������ɕ\�����镶����
                form.Message = "���i�o�[�R�[�h�f�[�^�̓Ǎ��ݒ��ł�";    // ��ʂ̃v���O���X�o�[�̏�ɕ\�����镶����
                form.DispCancelButton = false;                      // �L�����Z���{�^�������ɂ�钆�f�@�\�n�m�i�f�t�H���g�͂n�e�e�j

                // ���ʏ�������ʕ\��
                form.Show();
                // ���i�o�[�R�[�h�f�[�^List
                List<GoodsBarCodeRevn> goodsBarCodeRevnList = new List<GoodsBarCodeRevn>();
                // ���i�o�[�R�[�h��������
                GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara = new GoodsBarCodeRevnSearchPara();
                // ���i�o�[�R�[�h�������������
                GetSearchParaFromScreen(out goodsBarCodeRevnSearchPara);
                // ���i�o�[�R�[�h�֘A�t����������
                int status = _goodsBarCodeRevnAcs.Search(out goodsBarCodeRevnList, goodsBarCodeRevnSearchPara);

                // ���ʏ�������ʏI��
                if (form != null) form.Close();
                
                // �O���b�h�f�[�^�N���A����
                ClearGridDataSource();

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�o�[�R�[�h�֘A�t���f�[�^�e�[�v��
                    SetListToDataTable(goodsBarCodeRevnList);
                    // �擾�f�[�^���O���b�h�ɕ\��
                    GoodsBarCodeRevn_Grid.DataSource = _goodsBarCodeView;
                    // �O���b�h�ݒ萧��
                    _gridStateController.SetGridStateToGrid(ref this.GoodsBarCodeRevn_Grid);

                    this.GoodsBarCodeRevn_Grid.Focus();
                    this.GoodsBarCodeRevn_Grid.Rows[0].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                    this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
                    this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = true;
                    // �폜�{�^�����ɂ���
                    this.uButton_RowGoodsDelete.Enabled = true;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {

                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.ToString(), "�Y���f�[�^������܂���", status, MessageBoxButtons.OK);
                }
                else
                {
                    // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------>>>>>
                    //�������A�E�g���������ꍇ�A���b�Z�[�W���o��
                    if (this._goodsBarCodeRevnAcs.MemoryOutFlag && status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        Form memoryOutForm = new Form();
                        memoryOutForm.TopMost = true;
                        TMsgDisp.Show(memoryOutForm, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), INFO_MEMORYOUT_MSG, status, MessageBoxButtons.OK);
                        memoryOutForm.TopMost = false;
                    }
                    else
                    {
                    // --- ADD 2021/11/03 ������ PJMIT-1499�Ή� ------<<<<<
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "���������Ɏ��s���܂���", status, MessageBoxButtons.OK);
                    }// ADD 2021/11/03 ������ PJMIT-1499�Ή�
                }
            }
            catch
            {
                // ���ʏ�������ʏI��
                if (form != null) form.Close();

                // �O���b�h�f�[�^�N���A����
                ClearGridDataSource();
                
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.ToString(), "���������Ɏ��s���܂���", 9, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// �����������`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏���茟���������`�F�b�N</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2017/09/22 3H �k�P�N</br>
        /// <br>�Ǘ��ԍ�   : 11370074-00 �n���f�B�Ή��i2���j</br>
        /// <br>             ���i�o�[�R�[�h�ꊇ�o�^�̉���</br>
        /// </remarks>
        private bool CheckSearchPara()
        {
            // �݌ɋ敪
            if (string.IsNullOrEmpty(tEdit_StockDiv.DataText.Trim()))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "�݌ɋ敪����͂��Ă��������B", 9, MessageBoxButtons.OK);
                tEdit_StockDiv.Focus();
                return false;
            }
            // �o�^�敪
            if (string.IsNullOrEmpty(tEdit_HaveBarCodeDiv.DataText.Trim()))
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "�o�^�敪����͂��Ă��������B", 9, MessageBoxButtons.OK);
                tEdit_HaveBarCodeDiv.Focus();
                return false;
            }
            // --- DEL 3H �k�P�N 2017/09/22---------->>>>>
            //// ���[�J�[�R�[�h
            //if (string.IsNullOrEmpty(tNedit_GoodsMakerCd.DataText.Trim()))
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "���[�J�[�R�[�h����͂��Ă��������B", 9, MessageBoxButtons.OK);
            //    tNedit_GoodsMakerCd.Focus();
            //    return false;
            //}
            // --- DEL 3H �k�P�N 2017/09/22----------<<<<<
            // �݌ɋ敪:[�S��]
            if (tEdit_StockDiv.DataText.Trim() == "1")
            {
                // --- ADD 3H �k�P�N 2017/09/22---------->>>>>
                // ���[�J�[�R�[�h
                if (string.IsNullOrEmpty(tNedit_GoodsMakerCd.DataText.Trim()))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "���[�J�[�R�[�h����͂��Ă��������B", 9, MessageBoxButtons.OK);
                    tNedit_GoodsMakerCd.Focus();
                    return false;
                }
                // --- ADD 3H �k�P�N 2017/09/22----------<<<<<

                if (string.IsNullOrEmpty(tEdit_GoodsNo.DataText.Trim()))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "�i�Ԃ���͂��Ă��������B", 9, MessageBoxButtons.OK);
                    tEdit_GoodsNo.Focus();
                    return false;
                }
            }
            // �݌ɋ敪:[�݌ɂ̂�]
            else
            {
                // �q��
                if (string.IsNullOrEmpty(tEdit_WarehouseCode.DataText.Trim()))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "�q�ɃR�[�h����͂��Ă��������B", 9, MessageBoxButtons.OK);
                    tEdit_WarehouseCode.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// �������������
        /// </summary>
        /// <param name="goodsBarCodeRevnSearchPara">��������</param>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏���茟�����������</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GetSearchParaFromScreen(out GoodsBarCodeRevnSearchPara goodsBarCodeRevnSearchPara)
        {
            goodsBarCodeRevnSearchPara = new GoodsBarCodeRevnSearchPara();

            // �݌ɋ敪
            if (!string.IsNullOrEmpty(tEdit_StockDiv.Text.Trim()))
            {
                goodsBarCodeRevnSearchPara.StockDiv = int.Parse(tEdit_StockDiv.Text.Trim());
            }
            else
            {
                goodsBarCodeRevnSearchPara.StockDiv = 1;
            }
            // �o�^�敪
            if (!string.IsNullOrEmpty(tEdit_HaveBarCodeDiv.Text.Trim()))
            {
                goodsBarCodeRevnSearchPara.HaveBarCodeDiv = int.Parse(tEdit_HaveBarCodeDiv.Text.Trim());
            }
            else
            {
                goodsBarCodeRevnSearchPara.HaveBarCodeDiv = 0;
            }
            // ��ƃR�[�h
            goodsBarCodeRevnSearchPara.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���i���[�J�[�R�[�h
            goodsBarCodeRevnSearchPara.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // �i��
            goodsBarCodeRevnSearchPara.GoodsNo = this.tEdit_GoodsNo.DataText;
            // �q�ɃR�[�h
            goodsBarCodeRevnSearchPara.WarehouseCode = this.tEdit_WarehouseCode.DataText;
            // �Ǘ����_�R�[�h
            goodsBarCodeRevnSearchPara.SectionCode = this.tEdit_SectionCode.DataText;
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���f�[�^List �� �f�[�^�e�[�v��
        /// </summary>
        /// <param name="goodsBarCodeRevnList">���i�o�[�R�[�h�֘A�t���f�[�^List</param>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���f�[�^List �� �f�[�^�e�[�v��</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetListToDataTable(List<GoodsBarCodeRevn> goodsBarCodeRevnList)
        {
            if (goodsBarCodeRevnList != null && goodsBarCodeRevnList.Count > 0)
            {
                // �\������
                int showCount = ct_MaxCount;
                if (goodsBarCodeRevnList.Count < ct_MaxCount)
                {
                    showCount = goodsBarCodeRevnList.Count;
                }

                for (int i = 0; i < showCount; i++)
                {
                    DataRow row = _goodsBarCodeDt.NewRow();
                    // �s�ԍ�
                    row[GoodsBarCodeRevnTbl.ct_Col_RowNo] = i + 1;
                    // ���i�ԍ�
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsNo] = goodsBarCodeRevnList[i].GoodsNo;
                    // ���i���[�J�[�R�[�h
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd] = goodsBarCodeRevnList[i].GoodsMakerCd.ToString("0000");
                    // ���[�J�[����
                    row[GoodsBarCodeRevnTbl.ct_Col_MakerName] = goodsBarCodeRevnList[i].MakerName;
                    // ���i����
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsName] = goodsBarCodeRevnList[i].GoodsName;
                    // ���i�o�[�R�[�h���
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind] = goodsBarCodeRevnList[i].GoodsBarCodeKind;
                    // ���i�o�[�R�[�h
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode] = goodsBarCodeRevnList[i].GoodsBarCode;
                    // �폜�敪 0:�폜�Ȃ��s
                    row[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv] = "0";
                    _goodsBarCodeDt.Rows.Add(row);
                    // �f�B�N�V���i���̃L�[
                    string dicKey = goodsBarCodeRevnList[i].GoodsMakerCd.ToString("0000") + "_" + goodsBarCodeRevnList[i].GoodsNo;
                    if (!_goodsBarCodeRevnDic.ContainsKey(dicKey))
                    {
                        // �f�[�^���f�B�N�V���i���ɃZ�b�g
                        _goodsBarCodeRevnDic.Add(dicKey, goodsBarCodeRevnList[i]);
                    }
                }
            }
        }

        # endregion

        # region �N���A����
        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���A�������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void ClearProcess()
        {
            // �ҏW���̃f�[�^�����ݏ�
            if (GridDataIsChange())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "������Ԃɖ߂��܂����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            // ��ʃw�b�_�����ݒ菈��
            HeaderInitialSetting();
            // �O���b�h�f�[�^�N���A����
            ClearGridDataSource();
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
            // �폜�{�^����s�ɂ���
            this.uButton_RowGoodsDelete.Enabled = false;
            // �����{�^����s�ɂ���
            this.uButton_RowGoodsRevive.Enabled = false;
        }

        /// <summary>
        /// �O���b�h�f�[�^�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�f�[�^�N���A�������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void ClearGridDataSource()
        {
            // �f�[�^�e�[�u���N���A
            if (_goodsBarCodeDt != null)
            {
                _goodsBarCodeDt.Rows.Clear();
            }
            // �f�B�N�V���i���N���A
            if (_goodsBarCodeRevnDic != null)
            {
                _goodsBarCodeRevnDic.Clear();
            }
        }
        # endregion

        # region �ۑ�����
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ۑ��������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SaveProcess()
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null && this.GoodsBarCodeRevn_Grid.ActiveCell.IsInEditMode)
            {
                // �ҏW���[�h����������
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }
            // �ۑ����i�o�[�R�[�h�֘A�t���f�[�^�@false:�ۑ�
            SaveGoodsBarCodeRevnProcess(false);
        }

        /// <summary>
        /// �ۑ����i�o�[�R�[�h�֘A�t���f�[�^
        /// </summary>
        /// <returns>�ۑ������̌���</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���f�[�^��ۑ����܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int SaveGoodsBarCodeRevnProcess(bool outPutDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            List<GoodsBarCodeRevn> saveList = null;
            List<GoodsBarCodeRevn> deleteList = null;
            try
            {
                // ��ʂ���ۑ��p�f�[�^�����
                GetSaveGoodsBarCodeRevnDataFromScreen(out saveList, out deleteList);
                if ((saveList != null && saveList.Count > 0)
                    || (deleteList != null && deleteList.Count > 0))
                {
                    // ���i�o�[�R�[�h�֘A�t���f�[�^�̕ۑ�����
                    status = _goodsBarCodeRevnAcs.WriteBySave(saveList, deleteList);
                }
                else
                {
                    // �ۑ�
                    if (!outPutDiv)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "�X�V�Ώۂ̃f�[�^�����݂��܂���B", status, MessageBoxButtons.OK);
                        return status;
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ۑ�
                        if (!outPutDiv)
                        {
                            // �O���b�h�f�[�^�N���A
                            ClearGridDataSource();
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
                            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
                            // �폜�{�^����s�ɂ���
                            this.uButton_RowGoodsDelete.Enabled = false;
                            // �����{�^����s�ɂ���
                            this.uButton_RowGoodsRevive.Enabled = false;
                        }
                        if ((saveList != null && saveList.Count > 0)
                            || (deleteList != null && deleteList.Count > 0))
                        {
                            // �o�^�����_�C�A���O�\��
                            SaveCompletionDialog dialog = new SaveCompletionDialog();
                            dialog.ShowDialog(2);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "���ɑ��[�����폜����Ă��܂��B", status, MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "���ɑ��[�����X�V����Ă��܂��B", status, MessageBoxButtons.OK);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "�ۑ������Ɏ��s���܂����B", status, MessageBoxButtons.OK);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.ToString(), "�ۑ������Ɏ��s���܂����B", 9, MessageBoxButtons.OK);
                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// ��ʂ���ۑ��p�f�[�^�����
        /// </summary>
        /// <param name="goodsBarCodeRevnList">���i�o�[�R�[�h�֘A�t���f�[�^List</param>
        /// <param name="deleteGoodsBarCodeRevnList">���i�o�[�R�[�h�֘A�t���f�[�^List</param>
        /// <remarks>
        /// <br>Note       : ��ʂ���ۑ��p�f�[�^�����</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GetSaveGoodsBarCodeRevnDataFromScreen(out List<GoodsBarCodeRevn> goodsBarCodeRevnList, out List<GoodsBarCodeRevn> deleteGoodsBarCodeRevnList)
        {
            goodsBarCodeRevnList = new List<GoodsBarCodeRevn>();
            deleteGoodsBarCodeRevnList = new List<GoodsBarCodeRevn>();
            DataTable dt = new DataTable();
            if (_goodsBarCodeDt != null)
            {
                for (int index = 0; index < _goodsBarCodeDt.Rows.Count; index++)
                {
                    // �L�[
                    string dicKey = StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd]) + "_" + StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsNo]);
                    if (_goodsBarCodeRevnDic.ContainsKey(dicKey))
                    {
                        // �ύX����f�[�^�ƃo�[�R�[�h���Ȃ��f�[�^
                        if ((StrObjToString(_goodsBarCodeRevnDic[dicKey].GoodsBarCode).Trim() != StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode]).Trim()
                            || StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode]).Trim() == ""
                            || _goodsBarCodeRevnDic[dicKey].GoodsBarCodeKind != IntObjToInt(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind]))
                            && StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_DeleteDiv]) == "0")
                        {
                            GoodsBarCodeRevn temp = new GoodsBarCodeRevn();
                            temp = _goodsBarCodeRevnDic[dicKey].Clone();
                            // �o�[�R�[�h��ʁF�O���b�h����l���Z�b�g
                            temp.GoodsBarCodeKind = IntObjToInt(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind]);
                            // ���i�o�[�R�[�h�F�O���b�h����l���Z�b�g
                            temp.GoodsBarCode = StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode]).Trim();
                            if (string.IsNullOrEmpty(temp.GoodsBarCode))
                            {
                                // ���i�o�[�R�[�h�F���[�J�[�R�[�h(4��)+" "+���i�ԍ�
                                temp.GoodsBarCode = StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd]) + " " + StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsNo]);
                                // ���i�o�[�R�[�h��ʁF1:code39
                                temp.GoodsBarCodeKind = 1;
                            }
                            // �ۑ��̃f�[�^�����i�o�[�R�[�h�֘A�t��List�ɃZ�b�g
                            goodsBarCodeRevnList.Add(temp);
                        }
                        else if (StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_DeleteDiv]) == "1")
                        {
                            GoodsBarCodeRevn temp = new GoodsBarCodeRevn();
                            temp = _goodsBarCodeRevnDic[dicKey].Clone();
                            deleteGoodsBarCodeRevnList.Add(temp);
                        }
                    }
                }
            }
        }

        # endregion

        # region �捞����
        /// <summary>
        /// �捞����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �捞�������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void InputTextProcess()
        {
            // �ҏW���̃f�[�^�����ݏ�
            if (GridDataIsChange())
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "���݁A�ҏW���̃f�[�^�����݂��܂��B" + "\r\n" + "\r\n" +
                    "�j�����Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
            // �O���b�h�f�[�^�N���A����
            ClearGridDataSource();
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
            // �폜�{�^����s�ɂ���
            this.uButton_RowGoodsDelete.Enabled = false;
            // �����{�^����s�ɂ���
            this.uButton_RowGoodsRevive.Enabled = false;

            // �捞��ʕ\��
            PMHND09210UB textOutDialog = new PMHND09210UB();
            textOutDialog.ShowDialog();
        }
        # endregion

        # region �e�L�X�g�o�͏���
        /// <summary>
        /// �e�L�X�g�o�͏���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͏������܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void ExtractTextProcess()
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null && this.GoodsBarCodeRevn_Grid.ActiveCell.IsInEditMode)
            {
                // �ҏW���[�h����������
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            // �m�F�_�C�A���O�����E�\��
            PMHND09210UC textOutDialog = new PMHND09210UC();
            if (textOutDialog.ShowDialog() != DialogResult.OK)
            {
                // ���~
                return;
            }

            // �ۑ����i�o�[�R�[�h�֘A�t���f�[�^
            int status = SaveGoodsBarCodeRevnProcess(true);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���~
                return;
            }
            // �o�͗p�e�[�u��
            DataTable outDt = null;
            // �o�̓f�[�^�����
            GetExtractDataTable(out outDt);
            // �O���b�h�f�[�^�N���A
            ClearGridDataSource();
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
            this.tToolbarsManager_MainMenu.Tools["ButtonTool_ExtractText"].SharedProps.Enabled = false;
            // �폜�{�^����s�ɂ���
            this.uButton_RowGoodsDelete.Enabled = false;
            // �����{�^����s�ɂ���
            this.uButton_RowGoodsRevive.Enabled = false;

            try
            {
                // �o�̓f�[�^������܂���
                if (outDt.Rows.Count == 0)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        "�e�L�X�g�o�̓f�[�^������܂���", status, MessageBoxButtons.OK);
                    return;
                }
                // �ݒ�I�u�W�F�N�g���擾
                this._userSetting = textOutDialog.UserSetting;

                FormattedTextWriter tw = new FormattedTextWriter();

                // �o�͍��ږ�
                List<String> schemeList = new List<string>();

                // CsvTitle�o��
                for (int i = 0; i < ctCsvTitle.Length; i++)
                {
                    schemeList.Add(ctCsvTitle[i].ToString());

                }
                tw.SchemeList = schemeList;

                // TextWriter��DataSource�Z�b�g
                tw.DataSource = outDt.DefaultView;

                // �O���b�h�̃\�[�g����K�p����
                if (tw.DataSource is DataView)
                {
                    (tw.DataSource as DataView).Sort = GetSortingColumns(this.GoodsBarCodeRevn_Grid);
                }

                # region [�t�H�[�}�b�g���X�g]

                tw.FormatList = null;
                # endregion

                // �t�@�C����
                tw.OutputFileName = this._userSetting.OutputFilePath + this._userSetting.OutputFileName;
                // ��؂蕶��
                tw.Splitter = ",";

                // ���蕶��
                tw.Encloser = "\"";

                // ���ڊ���K�p
                List<Type> enclosingList = new List<Type>();

                // �����^�C�v
                String typeStr = string.Empty;
                Char typeChar = new char();
                Byte typeByte = new byte();
                DateTime typeDate = new DateTime();
                // ���l�^�C�v
                Int16 typeInt16 = new short();
                Int32 typeInt32 = new int();
                Int64 typeInt64 = new long();
                Single typeSingle = new float();
                Double typeDouble = new double();
                Decimal typeDecimal = new decimal();

                // ���l����
                enclosingList.Add(typeInt16.GetType());
                enclosingList.Add(typeInt32.GetType());
                enclosingList.Add(typeInt64.GetType());
                enclosingList.Add(typeDouble.GetType());
                enclosingList.Add(typeDecimal.GetType());
                enclosingList.Add(typeSingle.GetType());
                // ��������
                enclosingList.Add(typeStr.GetType());
                enclosingList.Add(typeChar.GetType());
                enclosingList.Add(typeByte.GetType());
                enclosingList.Add(typeDate.GetType());

                tw.EnclosingTypeList = enclosingList;

                // �^�C�g���s�o��
                tw.CaptionOutput = true;

                // �Œ蕝
                tw.FixedLength = false;
                int outputCount = 0;

                // �t�H���_�[���Ȃ��ꍇ
                if (!Directory.Exists(this._userSetting.OutputFilePath))
                {
                    // �t�H���_�[���쐬����
                    Directory.CreateDirectory(this._userSetting.OutputFilePath);
                }

                status = tw.TextOut(out outputCount);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    // �o�͎��s
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", status, MessageBoxButtons.OK);
                }
                else
                {
                    // �o�͐���
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                        outputCount.ToString() + "�s�̃f�[�^���t�@�C���֏o�͂��܂����B", status, MessageBoxButtons.OK);
                }
            }
            catch
            {
                // �ُ�I��
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                    "�t�@�C���ւ̏o�͂Ɏ��s���܂����B", 9, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// �o�̓f�[�^�����
        /// </summary>
        /// <param name="outDt">�o�͗p�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �o�̓f�[�^�����</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GetExtractDataTable(out DataTable outDt)
        {
            outDt = null;
            GoodsBarCodeRevnTbl.CreateDataTable(ref outDt);
            foreach (UltraGridRow ultraRow in this.GoodsBarCodeRevn_Grid.Rows)
            {
                if (StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "0")
                {
                    DataRow row = outDt.NewRow();
                    // �s�ԍ�
                    row[GoodsBarCodeRevnTbl.ct_Col_RowNo] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Text);
                    // ���i�ԍ�
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsNo] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Text);
                    // ���i���[�J�[�R�[�h
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Text);
                    // ���[�J�[����
                    row[GoodsBarCodeRevnTbl.ct_Col_MakerName] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_MakerName].Text);
                    // ���i����
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsName] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Text);
                    if (StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Text.Trim()) == "")
                    {
                        // ���i�o�[�R�[�h�F���[�J�[�R�[�h(4��)+" "+���i�ԍ�
                        row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Text)
                            + " " + StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Text);
                    }
                    else
                    {
                        // ���i�o�[�R�[�h
                        row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Text.Trim());
                    }
                    // ���i�o�[�R�[�h���
                    row[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind] = IntObjToInt(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Value);
                    // �폜�敪
                    row[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv] = StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text);
                    outDt.Rows.Add(row);
                }
            }
        }

        /// <summary>
        /// ���݃\�[�g���J�����擾����
        /// </summary>
        /// <param name="grid">�O���b�h</param>
        /// <returns>�\�[�g��</returns>
        /// <remarks>
        /// <br>Note       : ���݃\�[�g���J�����擾�����B</br>
        /// <br>Programmer  : 3H ������</br>
        /// <br>Date        : 2017/06/12</br>
        /// </remarks>
        private string GetSortingColumns(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            string sortText = string.Empty;
            bool firstCol = true;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in grid.DisplayLayout.Bands[0].SortedColumns)
            {
                if (firstCol == false)
                {
                    sortText += ",";
                }

                // �񖼂��擾
                sortText += ultraGridColumn.Key;

                // ��̃\�[�g����(����,�~��)���擾
                if (ultraGridColumn.SortIndicator == Infragistics.Win.UltraWinGrid.SortIndicator.Ascending)
                {
                    sortText += " ASC";
                }
                else
                {
                    sortText += " DESC";
                }

                firstCol = false;
            }

            return sortText;
        }
        # endregion

        # endregion

        # region [��ʁE�C�x���g]
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�����[�h�C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UA_Load(object sender, EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // ��ʃw�b�_�����ݒ菈��
            this.HeaderInitialSetting();

            // �O���b�h�����ݒ菈��
            this.GridInitialSetting();

        }

        /// <summary>
        /// �t�H�[������\���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������\���C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UA_Shown(object sender, EventArgs e)
        {
            // �݌ɋ敪
            this.tEdit_StockDiv.Focus();
        }

        /// <summary>
        /// �L�[�����C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�s�̔w�i�F��ݒ�B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void PMHND09210UA_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    {
                        if (uButton_RowGoodsDelete.Enabled == true)
                        {
                            // ���i�o�[�R�[�h���폜����
                            uButton_RowGoodsDelete_Click(sender, e);
                        }
                        break;
                    }
                case Keys.F4:
                    {
                        if (uButton_RowGoodsRevive.Enabled == true)
                        {
                            // ���i�o�[�R�[�h�𕜊�����
                            uButton_RowGoodsRevive_Click(sender, e);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �݌ɋ敪�ύX���ꂽ�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �݌ɋ敪�ύX���ꂽ���������܂��B</br> 
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// <br>Update Note: 2017/09/22 3H �k�P�N</br>
        /// <br>�Ǘ��ԍ�   : 11370074-00 �n���f�B�Ή��i2���j</br>
        /// <br>             ���i�o�[�R�[�h�ꊇ�o�^�̉���</br>
        /// </remarks>
        private void tEdit_StockDiv_ValueChanged(object sender, EventArgs e)
        {
            // ���_
            tEdit_SectionCode.DataText = string.Empty;
            uLabel_SectionName.Text = string.Empty;
            tEdit_SectionCode.Enabled = false;
            uButton_SectionGuide.Enabled = false;
            // �q��
            tEdit_WarehouseCode.DataText = string.Empty;
            uLabel_WarehouseName.Text = string.Empty;
            tEdit_WarehouseCode.Enabled = false;
            uButton_WarehouseGuide.Enabled = false;
            // --- ADD 3H �k�P�N 2017/09/22---------->>>>>
            // ���[�J�[�R�[�h
            this.tNedit_GoodsMakerCd.Appearance.BackColor = this.ct_EssentialColor;
            // --- ADD 3H �k�P�N 2017/09/22----------<<<<<
            // �q��
            this.tEdit_WarehouseCode.Appearance.BackColor = this.ct_OptionalColor;
            // �i��
            this.tEdit_GoodsNo.Appearance.BackColor = this.ct_EssentialColor;
            // �O����͌����������(�w�b�_�p)
            if (this._prevHeaderInfo != null)
            {
                // ���_
                this._prevHeaderInfo.SectionCode = string.Empty;
                // �q��
                this._prevHeaderInfo.WarehouseCode = string.Empty;
            }

            // �݌ɋ敪�F 0 �� 1 �̂�
            if (!string.IsNullOrEmpty(tEdit_StockDiv.DataText.Trim()) && tEdit_StockDiv.DataText.Trim() != "1" && tEdit_StockDiv.DataText.Trim() != "0")
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "�݌ɋ敪�� 0 �� 1 �ȊO�̒l�����͂ł��܂���B", 0, MessageBoxButtons.OK);
                tEdit_StockDiv.DataText = string.Empty;
                tEdit_StockDiv.Focus();
            }
            else if (tEdit_StockDiv.DataText.Trim() == "0")
            {
                // --- ADD 3H �k�P�N 2017/09/22---------->>>>>
                // ���[�J�[�R�[�h
                this.tNedit_GoodsMakerCd.Appearance.BackColor = this.ct_OptionalColor;
                // --- ADD 3H �k�P�N 2017/09/22----------<<<<<

                // ���_
                tEdit_SectionCode.Enabled = true;
                uButton_SectionGuide.Enabled = true;
                // �q��
                tEdit_WarehouseCode.Enabled = true;
                this.tEdit_WarehouseCode.Appearance.BackColor = this.ct_EssentialColor;
                uButton_WarehouseGuide.Enabled = true;
                // �i��
                this.tEdit_GoodsNo.Appearance.BackColor = this.ct_OptionalColor;
            }
        }

        /// <summary>
        /// �o�^�敪�ύX���ꂽ�������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �o�^�敪�ύX���ꂽ���������܂��B</br> 
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tEdit_HaveBarCodeDiv_ValueChanged(object sender, EventArgs e)
        {
            // �o�^�敪�F 0 �� 1 �̂�
            if (!string.IsNullOrEmpty(tEdit_HaveBarCodeDiv.DataText.Trim()) && tEdit_HaveBarCodeDiv.DataText.Trim() != "0"
                && tEdit_HaveBarCodeDiv.DataText.Trim() != "1" && tEdit_HaveBarCodeDiv.DataText.Trim() != "2")
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.ToString(), "�o�^�敪�� 0,1��2 �ȊO�̒l�����͂ł��܂���B", 0, MessageBoxButtons.OK);
                tEdit_HaveBarCodeDiv.DataText = string.Empty;
                tEdit_HaveBarCodeDiv.Focus();
            }
        }

        /// <summary>
        /// ���i�o�[�R�[�h�폜����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�폜�����B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_RowGoodsDelete_Click(object sender, EventArgs e)
        {
            List<int> rowIndexList = this.GetSelectRowIndex();
            rowIndexList.Sort();

            if (rowIndexList.Count == 0)
            {
                // �I���s�A�A�N�e�B�u�Z���������ꍇ�A�����Ȃ�
                return;
            }
            foreach (int rowIndex in rowIndexList)
            {
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation = Activation.Disabled;
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation = Activation.Disabled;
                // �폜�敪 1:�폜�ςݍs
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Value = "1";
            }

            // �I���s�̏�Ԃ��ς��̂ō폜�{�^����������
            this.uButton_RowGoodsDelete.Enabled = false;
            // �I���s�̏�Ԃ��ς��̂ŕ����{�^����������
            this.uButton_RowGoodsRevive.Enabled = true;

            // �I���s�̏�Ԃ��ς��̂Ŕw�i�F���t���b�V��
            this.SetGridColorAll();
        }

        /// <summary>
        /// ���i�o�[�R�[�h��������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h���������B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_RowGoodsRevive_Click(object sender, EventArgs e)
        {
            List<int> rowIndexList = this.GetSelectRowIndex();
            rowIndexList.Sort();

            if (rowIndexList.Count == 0)
            {
                // �I���s�A�A�N�e�B�u�Z���������ꍇ�A�����Ȃ�
                return;
            }
            foreach (int rowIndex in rowIndexList)
            {
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation = Activation.AllowEdit;
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation = Activation.AllowEdit;
                // �폜�敪 0:����s(�����ς�)
                this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Value = "0";
            }
            // �I���s�̏�Ԃ��ς��̂ō폜�{�^����������
            this.uButton_RowGoodsDelete.Enabled = true;
            // �I���s�̏�Ԃ��ς��̂ŕ����{�^����������
            this.uButton_RowGoodsRevive.Enabled = false;

            // �I���s�̏�Ԃ��ς��̂Ŕw�i�F���t���b�V��
            this.SetGridColorAll();
        }

        # endregion

        # region [ChangeFocus]
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���L�[�ł̃t�H�[�J�X�ړ��C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // ���̎擾 ============================================ //
            # region [���̎擾]
            switch (e.PrevCtrl.Name)
            {
                //-----------------------------------------------------
                // ���[�J�[
                //-----------------------------------------------------
                case "tNedit_GoodsMakerCd":
                    {
                        # region [���[�J�[]
                        bool status;

                        if (tNedit_GoodsMakerCd.GetInt() == _prevHeaderInfo.GoodsMakerCd)
                        {
                            status = true;
                        }
                        else
                        {
                            int code;
                            string name;

                            // �ǂݍ���
                            status = ReadGoodsMaker(tNedit_GoodsMakerCd.GetInt(), out code, out name);

                            // �R�[�h�E���̂��X�V
                            tNedit_GoodsMakerCd.SetInt(code);
                            _prevHeaderInfo.GoodsMakerCd = code;
                            uLabel_MakerName.Text = name;
                        }

                        if (status == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_prevHeaderInfo.GoodsMakerCd == 0)
                                            {
                                                e.NextCtrl = this.uButton_GoodsMakerGuide;
                                            }
                                            else
                                            {
                                                if (this.tEdit_WarehouseCode.Enabled == true)
                                                {
                                                    e.NextCtrl = this.tEdit_WarehouseCode;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = this.tEdit_GoodsNo;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���[�J�[�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                        }

                        # endregion
                    }
                    break;
                case "tEdit_GoodsNo":
                    {
                        if (!e.ShiftKey)
                        {
                            // NextCtrl����
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        if (this.tEdit_SectionCode.Enabled == true)
                                        {
                                            e.NextCtrl = this.tEdit_SectionCode;
                                        }
                                        else
                                        {
                                            if (this.GoodsBarCodeRevn_Grid.Rows.Count > 0)
                                            {
                                                e.NextCtrl = this.GoodsBarCodeRevn_Grid;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_StockDiv;
                                            }
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                    break;
                //-----------------------------------------------------
                // �q��
                //-----------------------------------------------------
                case "tEdit_WarehouseCode":
                    {
                        # region [�q��]

                        bool status;

                        if (tEdit_WarehouseCode.Text == _prevHeaderInfo.WarehouseCode)
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // �ǂݍ���
                            status = ReadWarehouse(tEdit_WarehouseCode.Text, out code, out name);

                            // �R�[�h�E���̂��X�V
                            tEdit_WarehouseCode.Text = code.TrimEnd();
                            _prevHeaderInfo.WarehouseCode = code.TrimEnd();
                            uLabel_WarehouseName.Text = name;
                        }

                        if (status == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_prevHeaderInfo.WarehouseCode == string.Empty)
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_GoodsNo;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�q�ɂ����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                        }

                        # endregion
                    }
                    break;
                //-----------------------------------------------------
                // ���_
                //-----------------------------------------------------
                case "tEdit_SectionCode":
                    {
                        # region [���_]

                        bool status;

                        if (tEdit_SectionCode.Text == _prevHeaderInfo.SectionCode)
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // ���_�ǂݍ���
                            status = ReadSection(tEdit_SectionCode.Text, out code, out name);

                            // �R�[�h�E���̂��X�V
                            tEdit_SectionCode.Text = code.TrimEnd();
                            _prevHeaderInfo.SectionCode = code.TrimEnd();
                            uLabel_SectionName.Text = name;
                        }

                        if (status == true)
                        {
                            if (!e.ShiftKey)
                            {
                                // NextCtrl����
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (_prevHeaderInfo.SectionCode == string.Empty)
                                            {
                                                // ���_�K�C�h
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                if (this.GoodsBarCodeRevn_Grid.Rows.Count > 0)
                                                {
                                                    e.NextCtrl = this.GoodsBarCodeRevn_Grid;
                                                }
                                                else
                                                {
                                                    e.NextCtrl = tEdit_StockDiv;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                    }
                    break;

                // �O���b�h
                case "GoodsBarCodeRevn_Grid":
                    {
                        if (this.GoodsBarCodeRevn_Grid.Rows.Count == 0)
                        {
                            return;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                // �O���b�h�^�u�ړ�����
                                SetGridTabFocus(ref e);
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab || (e.Key == Keys.Enter))
                            {
                                // �O���b�h�V�t�g�^�u�ړ�����
                                SetGridShiftTabFocus(ref e);
                            }
                        }
                        break;
                    }
            }

            if (e.NextCtrl != null && e.NextCtrl.Name == "GoodsBarCodeRevn_Grid")
            {
                if (this.GoodsBarCodeRevn_Grid.Rows.Count == 0)
                {
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down) || (e.Key == Keys.Up))
                        {
                            // �݌ɋ敪
                            e.NextCtrl = this.tEdit_StockDiv;
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab)
                        {
                            // �݌ɋ敪
                            e.NextCtrl = this.tEdit_StockDiv;
                        }
                    }
                }
                else
                {
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter) || (e.Key == Keys.Down))
                        {
                            e.NextCtrl = null;
                            this.GoodsBarCodeRevn_Grid.Focus();

                            bool doActivate = false;

                            for (int i = 0; i < GoodsBarCodeRevn_Grid.Rows.Count; i++)
                            {
                                // �A�N�e�B�u�s�T��
                                if (!GoodsBarCodeRevn_Grid.Rows[i].IsFilteredOut)
                                {
                                    if (GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                                    {
                                        GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                                        GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        doActivate = true;
                                        break;
                                    }
                                }
                            }

                            if (!doActivate)
                            {
                                // �݌ɋ敪
                                this.tEdit_StockDiv.Focus();
                            }

                        }
                        else if (e.Key == Keys.Up)
                        {
                            e.NextCtrl = null;
                            this.GoodsBarCodeRevn_Grid.Focus();

                            bool doActivate = false;

                            for (int i = GoodsBarCodeRevn_Grid.Rows.Count-1; i >= 0; i--)
                            {
                                // �A�N�e�B�u�s�T��
                                if (!GoodsBarCodeRevn_Grid.Rows[i].IsFilteredOut)
                                {
                                    if (GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                                    {
                                        GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                                        GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        doActivate = true;
                                        break;
                                    }
                                }
                            }

                            if (!doActivate)
                            {
                                if (this.uButton_SectionGuide.Enabled == true)
                                {
                                    // ���_�K�C�h
                                    this.uButton_SectionGuide.Focus();
                                }
                                else
                                {
                                    // �i��
                                    this.tEdit_GoodsNo.Focus();
                                }
                            }
                        }
                    }
                    else
                    {
                        if (e.Key == Keys.Tab || (e.Key == Keys.Enter))
                        {
                            e.NextCtrl = null;
                            this.GoodsBarCodeRevn_Grid.Focus();

                            bool doActivate = false;

                            for (int i = GoodsBarCodeRevn_Grid.Rows.Count - 1; i >= 0; i--)
                            {
                                // �A�N�e�B�u�s�T��
                                if (!GoodsBarCodeRevn_Grid.Rows[i].IsFilteredOut)
                                {
                                    if (GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                                    {
                                        GoodsBarCodeRevn_Grid.Rows[i].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                                        GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                        doActivate = true;
                                        break;
                                    }
                                }
                            }

                            if (!doActivate)
                            {
                                if (this.uButton_SectionGuide.Enabled == true)
                                {
                                    // ���_�K�C�h
                                    this.uButton_SectionGuide.Focus();
                                }
                                else
                                {
                                    // �i��
                                    this.tEdit_GoodsNo.Focus();
                                }
                            }
                        }
                    }
                }
            }

            # endregion

        }
        # endregion

        # region [ChangeFocus����Read����]
        /// <summary>
        /// ���_Read
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="code">���_�R�[�h</param>
        /// <param name="name">���_��</param>
        /// <returns>Read��������</returns>
        /// <remarks>
        /// <br>Note       : ���_Read</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool ReadSection(string sectionCode, out string code, out string name)
        {
            bool result = false;

            // �����͔���
            if (sectionCode != string.Empty)
            {
                // �ǂݍ���
                if (_secInfoSetAcs == null)
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, sectionCode);

                if (status == 0 && secInfoSet != null)
                {
                    // �Y�����聨�\��
                    code = secInfoSet.SectionCode.TrimEnd();
                    name = secInfoSet.SectionGuideNm;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// �q��Read
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="code">�q�ɃR�[�h</param>
        /// <param name="name">�q�ɖ�</param>
        /// <returns>Read��������</returns>
        /// <remarks>
        /// <br>Note       : �q��Read</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool ReadWarehouse(string warehouseCode, out string code, out string name)
        {
            bool result = false;

            // �����͔���
            if (warehouseCode != string.Empty)
            {
                // �ǂݍ���
                if (_warehouseAcs == null)
                {
                    _warehouseAcs = new WarehouseAcs();
                }
                Warehouse warehouse;
                int status = _warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, warehouseCode);

                if (status == 0 && warehouse != null)
                {
                    // �Y�����聨�\��
                    code = warehouse.WarehouseCode.TrimEnd();
                    name = warehouse.WarehouseName;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = string.Empty;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// ���i���[�J�[Read
        /// </summary>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="code">���i���[�J�[�R�[�h</param>
        /// <param name="name">���i���[�J�[��</param>
        /// <returns>Read��������</returns>
        /// <remarks>
        /// <br>Note       : ���i���[�J�[Read</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool ReadGoodsMaker(int goodsMakerCd, out int code, out string name)
        {
            bool result = false;

            // �����͔���
            if (goodsMakerCd != 0)
            {
                // �ǂݍ���
                if (_makerAcs == null)
                {
                    _makerAcs = new MakerAcs();
                }
                MakerUMnt maker;
                int status = _makerAcs.Read(out maker, this._enterpriseCode, goodsMakerCd);

                if (status == 0 && maker != null)
                {
                    // �Y�����聨�\��
                    code = maker.GoodsMakerCd;
                    name = maker.MakerName;

                    result = true;
                }
                else
                {
                    // �Y���Ȃ����N���A
                    code = 0;
                    name = string.Empty;

                    // �m�f�ɂ���
                    result = false;
                }
            }
            else
            {
                // �����́��N���A
                code = 0;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        # endregion

        # region [�K�C�h�{�^���N���b�N]
        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^���N���b�N�C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_SectionCode.Text = secInfoSet.SectionCode.Trim();
                uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();
                this._prevHeaderInfo.SectionCode = secInfoSet.SectionCode.Trim();

                // �t�H�[�J�X�ړ�
                tEdit_StockDiv.Focus();
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^���N���b�N�C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
        {
            if (_makerAcs == null)
            {
                _makerAcs = new MakerAcs();
            }

            MakerUMnt makerUMnt;
            int status = _makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                uLabel_MakerName.Text = makerUMnt.MakerName.Trim();
                this._prevHeaderInfo.GoodsMakerCd = makerUMnt.GoodsMakerCd;

                // �t�H�[�J�X�ړ�
                tEdit_GoodsNo.Focus();
            }
        }
        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^���N���b�N�C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            if (_warehouseAcs == null)
            {
                _warehouseAcs = new WarehouseAcs();
            }

            Warehouse warehouse;
            int status = _warehouseAcs.ExecuteGuid(out warehouse, this._enterpriseCode, this.tEdit_SectionCode.Text);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tEdit_WarehouseCode.Text = warehouse.WarehouseCode.TrimEnd();
                uLabel_WarehouseName.Text = warehouse.WarehouseName.TrimEnd();
                this._prevHeaderInfo.WarehouseCode = warehouse.WarehouseCode.TrimEnd();

                // �t�H�[�J�X�ړ�
                tEdit_SectionCode.Focus();
            }
        }
        # endregion

        # region [�O���b�h�C�x���g]

        /// <summary>
        /// �O���b�h�����ݒ�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�����ݒ�C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBar_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �Y���̃O���b�h�R���g���[���擾
            UltraGrid grids = (UltraGrid)sender;

            // �w�Œ��x�v�b�V���s���A�C�R��������
            e.Layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;

            // �Œ�w�b�_�[�@�\��L���ɂ���
            grids.DisplayLayout.UseFixedHeaders = true;
            // �����s�I����
            e.Layout.Override.SelectTypeRow = SelectType.ExtendedAutoDrag;

            // �s�T�C�Y��ݒ�
            grids.DisplayLayout.Override.DefaultRowHeight = 24;
            grids.DisplayLayout.Override.FixedCellSeparatorColor = Color.Black;
            int visiblePosition = 0;

            ColumnsCollection Columns = grids.DisplayLayout.Bands[GoodsBarCodeRevnTbl.ct_Tbl_GoodsBarCodeRevn].Columns;
           
            // �s�ԍ�
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].Width = 50;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellClickAction = CellClickAction.RowSelect;

            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.ForeColor = Color.White;
            Columns[GoodsBarCodeRevnTbl.ct_Col_RowNo].CellAppearance.ForeColorDisabled = Color.White;

            // �i��
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Width = 200;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].CellClickAction = CellClickAction.RowSelect;

            // ���[�J�[�R�[�h
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Hidden = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Width = 100;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].CellClickAction = CellClickAction.RowSelect;

            // ���[�J�[��
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].Width = 100;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_MakerName].CellClickAction = CellClickAction.RowSelect;

            // �i��
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Width = 200;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsName].CellClickAction = CellClickAction.RowSelect;

            //--------------------------------------
            // �R���{�{�b�N�X�ݒ�
            //--------------------------------------
            // �o�[�R�[�h��� 0:JAN  1:CODE39
            ValueList valueList = new ValueList();
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);
            valueList.ValueListItems.Add(0, "0:JAN");
            valueList.ValueListItems.Add(1, "1:CODE39");

            // �o�[�R�[�h���
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Width = 150;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].CellActivation = Activation.AllowEdit;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Header.VisiblePosition = visiblePosition++;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].ValueList = valueList.Clone();

            // �o�[�R�[�h
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Hidden = false;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Width = 250;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].CellActivation = Activation.AllowEdit;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].MaxLength = 128;
            Columns[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Header.VisiblePosition = visiblePosition++;

            // �폜�敪
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Hidden = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Header.Fixed = true;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Width = 50;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].CellActivation = Activation.Disabled;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].CellAppearance.ForeColor = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].CellAppearance.ForeColorDisabled = Color.Black;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].MaxLength = 128;
            Columns[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Header.VisiblePosition = visiblePosition++;

        }

        /// <summary>
        /// AfterCellUpdate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : AfterCellUpdate �C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            int rowIndex = e.Cell.Row.Index;
            // �L�[
            string dicKey = StrObjToString(uGrid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Value) + "_" + StrObjToString(uGrid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Value);
            if (_goodsBarCodeRevnDic.ContainsKey(dicKey))
            {
                // �o�[�R�[�h
                if (e.Cell.Column.Key == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode)
                {
                    // �ύX����f�[�^
                    if (StrObjToString(_goodsBarCodeRevnDic[dicKey].GoodsBarCode) != StrObjToString(uGrid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Value))
                    {
                        e.Cell.Appearance.BackColor = Color.Lime;
                    }
                    else
                    {
                        e.Cell.Appearance.BackColor = Color.Empty;
                    }
                }
                // �o�[�R�[�h���
                else if (e.Cell.Column.Key == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind)
                {
                    // �ύX����f�[�^
                    if (_goodsBarCodeRevnDic[dicKey].GoodsBarCodeKind != IntObjToInt(uGrid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Value))
                    {
                        e.Cell.Appearance.BackColor = Color.Lime;
                    }
                    else
                    {
                        e.Cell.Appearance.BackColor = Color.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if ((GoodsBarCodeRevn_Grid.Rows.Count == 0) ||
                ((GoodsBarCodeRevn_Grid.ActiveCell == null) && (GoodsBarCodeRevn_Grid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            if (this.uButton_SectionGuide.Enabled == true)
                            {
                                // ���_�K�C�h
                                this.uButton_SectionGuide.Focus();
                            }
                            else
                            {
                                // �i��
                                this.tEdit_GoodsNo.Focus();
                            }
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            //�@�݌ɋ敪
                            this.tEdit_StockDiv.Focus();
                            break;
                        }
                    case Keys.Left:
                        {
                            // �i��
                            this.tEdit_GoodsNo.Focus();
                            break;
                        }
                }
                return;
            }

            int rowIndex;
            string columnKey = string.Empty;
            if (GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                // �A�N�e�B�uCell
                rowIndex = GoodsBarCodeRevn_Grid.ActiveCell.Row.Index;
                columnKey = GoodsBarCodeRevn_Grid.ActiveCell.Column.Key;
            }
            else
            {
                // �A�N�e�B�u�s
                rowIndex = GoodsBarCodeRevn_Grid.ActiveRow.Index;
                // ���i�o�[�R�[�h���
                columnKey = GoodsBarCodeRevnTbl.ct_Col_GoodsNo;
            }

            bool doActivate = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {

                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            if (this.uButton_SectionGuide.Enabled == true)
                            {
                                // ���_�K�C�h
                                this.uButton_SectionGuide.Focus();
                            }
                            else
                            {
                                // �i��
                                this.tEdit_GoodsNo.Focus();
                            }
                        }
                        else
                        {
                            if (GoodsBarCodeRevn_Grid.ActiveCell != null)
                            {
                                e.Handled = true;
                                for (int i = rowIndex; i >= 1; i--)
                                {
                                    // �A�N�e�B�u�s�T��
                                    if (!GoodsBarCodeRevn_Grid.Rows[i - 1].IsFilteredOut)
                                    {
                                        if (GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[columnKey].Activation == Activation.AllowEdit && columnKey != GoodsBarCodeRevnTbl.ct_Col_GoodsNo)
                                        {
                                            GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[columnKey].Activate();
                                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {
                                            // �s�A�N�e�B�u
                                            GoodsBarCodeRevn_Grid.Rows[i - 1].Activate();
                                            GoodsBarCodeRevn_Grid.Rows[i - 1].Selected = true;
                                            doActivate = true;
                                            break;
                                        }
                                    }
                                }
                                if (!doActivate)
                                {
                                    if (this.uButton_SectionGuide.Enabled == true)
                                    {
                                        // ���_�K�C�h
                                        this.uButton_SectionGuide.Focus();
                                    }
                                    else
                                    {
                                        // �i��
                                        this.tEdit_GoodsNo.Focus();
                                    }
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                     
                        if (rowIndex == GoodsBarCodeRevn_Grid.Rows.Count - 1)
                        {
                            e.Handled = true;
                            // �݌ɋ敪
                            this.tEdit_StockDiv.Focus();
                        }
                        else
                        {
                            if (GoodsBarCodeRevn_Grid.ActiveCell != null)
                            {
                                e.Handled = true;
                                for (int i = rowIndex; i < GoodsBarCodeRevn_Grid.Rows.Count - 1; i++)
                                {
                                    // �A�N�e�B�u�s�T��
                                    if (!GoodsBarCodeRevn_Grid.Rows[i + 1].IsFilteredOut)
                                    {
                                        if (GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[columnKey].Activation == Activation.AllowEdit && columnKey != GoodsBarCodeRevnTbl.ct_Col_GoodsNo)
                                        {
                                            GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[columnKey].Activate();
                                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {
                                            // �s�A�N�e�B�u
                                            GoodsBarCodeRevn_Grid.Rows[i + 1].Activate();
                                            GoodsBarCodeRevn_Grid.Rows[i + 1].Selected = true;
                                            doActivate = true;
                                            break;
                                        }
                                    }
                                }

                                if (!doActivate)
                                {
                                    // �݌ɋ敪
                                    this.tEdit_StockDiv.Focus();
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        e.Handled = true;
                        // ���i�o�[�R�[�h���
                        if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind)
                        {
                            if (rowIndex == 0)
                            {
                                doActivate = false;
                            }
                            else
                            {
                                for (int i = rowIndex; i >= 1; i--)
                                {
                                    // �A�N�e�B�u�s�T��
                                    if (!GoodsBarCodeRevn_Grid.Rows[i - 1].IsFilteredOut)
                                    {
                                        // ���i�o�[�R�[�h
                                        if (GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                                        {
                                            GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!doActivate)
                            {
                                if (this.uButton_SectionGuide.Enabled == true)
                                {
                                    // ���_�K�C�h
                                    this.uButton_SectionGuide.Focus();
                                }
                                else
                                {
                                    // �i��
                                    this.tEdit_GoodsNo.Focus();
                                }
                            }
                        }
                        // ���i�o�[�R�[�h
                        else
                        {
                            // ���i�o�[�R�[�h���
                            if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                            {
                                GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                                GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                doActivate = true;
                                break;
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        e.Handled = true;
                        // ���i�o�[�R�[�h���
                        if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind)
                        {
                            // ���i�o�[�R�[�h
                            if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                            {
                                GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                                GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                doActivate = true;
                                break;
                            }
                        }
                        // ���i�o�[�R�[�h
                        else
                        {
                            if (rowIndex == GoodsBarCodeRevn_Grid.Rows.Count - 1)
                            {
                                doActivate = false;
                            }
                            else
                            {
                                for (int i = rowIndex; i < GoodsBarCodeRevn_Grid.Rows.Count - 1; i++)
                                {
                                    // �A�N�e�B�u�s�T��
                                    if (!GoodsBarCodeRevn_Grid.Rows[i + 1].IsFilteredOut)
                                    {
                                        // ���i�o�[�R�[�h���
                                        if (GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                                        {
                                            GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!doActivate)
                            {
                                // �݌ɋ敪
                                this.tEdit_StockDiv.Focus();
                            }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyPress �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell == null)
            {
                return;
            }
            // �A�N�e�B�uCell
            UltraGridCell cell = this.GoodsBarCodeRevn_Grid.ActiveCell;

            if (cell.IsInEditMode)
            {
                // UI�ݒ���Q��
                if (this.uiSetControl1.CheckMatchingSet(cell.Column.Key, e.KeyChar) == false)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// �Z���A�N�e�B�u�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �Z���A�N�e�B�u�O�C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // �O���b�hCell�A�N�e�B�u���w�肵���A�{�^�������ې�����s���B
            this.SetDeleteAndReviveRowButtonEnableByActiveCell(e.Cell.Row.Index);
        }

        /// <summary>
        /// �Z����A�N�e�B�u�O�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �Z����A�N�e�B�u�O�C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                int rowIndex = this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index;
                // �w�i�F�ݒ�

                UltraGridRow dr = GoodsBarCodeRevn_Grid.Rows[rowIndex];
                // ���׃O���b�h�s�̔w�i�F��ݒ�
                SetGridColorRow(dr);

            }
        }

        /// <summary>
        /// AfterSelectChange �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : AfterSelectChange �C�x���g</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            // �O�I�������s
            if (this._beforeSelectRowIndexList.Count != 0)
            {
                foreach (int rowIndex in this._beforeSelectRowIndexList)
                {
                    if (rowIndex <= this.GoodsBarCodeRevn_Grid.Rows.Count - 1)
                    {
                        this.SetGridColorRow(this.GoodsBarCodeRevn_Grid.Rows[rowIndex]);
                    }
                }

                this._beforeSelectRowIndexList.Clear();
            }

            // BeforeRowDeactivate����ړ�
            foreach (UltraGridRow ultraGridRow in this.GoodsBarCodeRevn_Grid.Selected.Rows)
            {
                this._beforeSelectRowIndexList.Add(ultraGridRow.Index);
            }

            // �I���s�̔w�i�F�ݒ�
            if (this.GoodsBarCodeRevn_Grid.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraGr in this.GoodsBarCodeRevn_Grid.Selected.Rows)
                {
                    this.SetGridColorRow(ultraGr);
                }
            }

            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                this.SetGridColorRow(this.GoodsBarCodeRevn_Grid.Rows[this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index]);
            }

            // �폜�ƕ����{�^����������
            this.SetDeleteAndReviveRowButtonEnable();
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h����A�N�e�B�u�ɂȂ������ɔ������܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void GoodsBarCodeRevn_Grid_Leave(object sender, EventArgs e)
        {
            if (!uButton_RowGoodsDelete.Focused && !uButton_RowGoodsRevive.Focused)
            {
                this.GoodsBarCodeRevn_Grid.ActiveCell = null;
                this.GoodsBarCodeRevn_Grid.ActiveRow = null;
                this.GoodsBarCodeRevn_Grid.Selected.Rows.Clear();
                // �폜�{�^����s�ɂ���
                this.uButton_RowGoodsDelete.Enabled = false;
                // �����{�^����s�ɂ���
                this.uButton_RowGoodsRevive.Enabled = false;
                // ���׃O���b�h�e�s�̔w�i�F��ݒ�
                SetGridColorAll();
            }

        }

        # endregion

        #region [�Z���l�ϊ�]
        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <returns>�Z���l�ϊ�����</returns>
        /// <remarks>
        /// <br>Note        : �Z���l��String�^�ɕϊ����܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private string StrObjToString(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return "";
            }

            return (string)cellValue;
        }

        /// <summary>
        /// �Z���l�ϊ�����
        /// </summary>
        /// <param name="cellValue">�Z���l</param>
        /// <remarks>
        /// <br>Note        : �Z���l��Int�^�ɕϊ����܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private int IntObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null))
            {
                return 0;
            }

            return (int)cellValue;
        }
        # endregion

        #region [�ҏW���̃f�[�^�����ݏ�]
        /// <summary>
        /// �ҏW���̃f�[�^�����ݏ�
        /// </summary>
        /// <returns>true:���� false:���݂Ȃ� </returns>
        /// <remarks>
        /// <br>Note       : �ҏW���̃f�[�^�����ݏ�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private bool GridDataIsChange()
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null && this.GoodsBarCodeRevn_Grid.ActiveCell.IsInEditMode)
            {
                // �ҏW���[�h����������
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            // �f�[�^�e�[�u��
            if (_goodsBarCodeDt != null)
            {
                for (int index = 0; index < _goodsBarCodeDt.Rows.Count; index++)
                {
                    // �L�[
                    string dicKey = StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd]) + "_" + StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsNo]);
                    if (_goodsBarCodeRevnDic.ContainsKey(dicKey))
                    {
                        // �폜����f�[�^
                        if (StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_DeleteDiv]) == "1")
                        {
                            return true;
                        }
                        // �ύX����f�[�^:���i�o�[�R�[�h
                        if (StrObjToString(_goodsBarCodeRevnDic[dicKey].GoodsBarCode) != StrObjToString(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode]).Trim())
                        {
                            return true;
                        }
                        // �ύX����f�[�^:���i�o�[�R�[�h���
                        if (_goodsBarCodeRevnDic[dicKey].GoodsBarCodeKind != IntObjToInt(_goodsBarCodeDt.Rows[index][GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind]))
                        {
                            return true;
                        } 
                    }
                }
            }
            return false;
        }
        # endregion

        #region [�G���[���b�Z�[�W�\������]
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_ClassName,			    	// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region [�O���b�h�^�u�ړ�]
        /// <summary>
        /// �O���b�h�^�u�ړ�����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Ƀt�H�[�J�X������ꍇ�̃^�u�ړ��𐧌䂵�܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetGridTabFocus(ref ChangeFocusEventArgs e)
        {
            e.NextCtrl = null;
            this.GoodsBarCodeRevn_Grid.Focus();

            int rowIndex = 0;
            string columnKey = string.Empty;

            if (this.GoodsBarCodeRevn_Grid.ActiveCell == null)
            {
                // �A�N�e�B�u�s
                if (this.GoodsBarCodeRevn_Grid.ActiveRow != null)
                {
                    rowIndex = this.GoodsBarCodeRevn_Grid.ActiveRow.Index;
                    // ���i�o�[�R�[�h���
                    columnKey = GoodsBarCodeRevnTbl.ct_Col_GoodsNo;
                }
            }
            else
            {
                // �A�N�e�B�uCell
                rowIndex = this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index;
                columnKey = GoodsBarCodeRevn_Grid.ActiveCell.Column.Key;
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            bool doActivate = false;
            // ���i�o�[�R�[�h���
            if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsNo)
            {
                // ���i�o�[�R�[�h
                if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                {
                    GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                    GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    doActivate = true;
                }
            }
            // ���i�o�[�R�[�h���
            else if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind)
            {
                // ���i�o�[�R�[�h
                if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                {
                    GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                    GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    doActivate = true;
                }
            }
            if (!doActivate)
            {
                for (int i = rowIndex; i < GoodsBarCodeRevn_Grid.Rows.Count - 1; i++)
                {
                    // �A�N�e�B�u�s�T��
                    if (!GoodsBarCodeRevn_Grid.Rows[i + 1].IsFilteredOut)
                    {
                        // ���i�o�[�R�[�h���
                        if (GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                        {
                            GoodsBarCodeRevn_Grid.Rows[i + 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                            doActivate = true;
                            break;
                        }
                    }
                }
            }

            if (!doActivate)
            {
                // �݌ɋ敪
                this.tEdit_StockDiv.Focus();
            }

        }

        /// <summary>
        /// �O���b�h�V�t�g�^�u����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�Ƀt�H�[�J�X������ꍇ�̃V�t�g�^�u�ړ��𐧌䂵�܂��B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            e.NextCtrl = null;
            this.GoodsBarCodeRevn_Grid.Focus();

            int rowIndex = this.GoodsBarCodeRevn_Grid.Rows.Count - 1;
            string columnKey = string.Empty;
            if (this.GoodsBarCodeRevn_Grid.ActiveCell == null)
            {
                // �A�N�e�B�u�s
                if (this.GoodsBarCodeRevn_Grid.ActiveRow != null)
                {
                    rowIndex = this.GoodsBarCodeRevn_Grid.ActiveRow.Index;
                    // ���i�o�[�R�[�h���
                    columnKey = GoodsBarCodeRevnTbl.ct_Col_GoodsNo;
                }
            }
            else
            {
                // �A�N�e�B�uCell
                rowIndex = this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index;
                columnKey = GoodsBarCodeRevn_Grid.ActiveCell.Column.Key;
                this.GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.ExitEditMode);
            }

            bool doActivate = false;
            // ���i�o�[�R�[�h
            if (columnKey == GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode)
            {
                // ���i�o�[�R�[�h���
                if (GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activation == Activation.AllowEdit)
                {
                    GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Activate();
                    GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                    doActivate = true;
                }
            }

            if (!doActivate)
            {
                for (int i = rowIndex; i >= 1; i--)
                {
                    // �A�N�e�B�u�s�T��
                    if (!GoodsBarCodeRevn_Grid.Rows[i - 1].IsFilteredOut)
                    {
                        // ���i�o�[�R�[�h
                        if (GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activation == Activation.AllowEdit)
                        {
                            GoodsBarCodeRevn_Grid.Rows[i - 1].Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Activate();
                            GoodsBarCodeRevn_Grid.PerformAction(UltraGridAction.EnterEditMode);
                            doActivate = true;
                            break;
                        }
                    }
                }
            }
            if (!doActivate)
            {
                if (this.uButton_SectionGuide.Enabled == true)
                {
                    // ���_�K�C�h
                    this.uButton_SectionGuide.Focus();
                }
                else
                {
                    // �i��
                    this.tEdit_GoodsNo.Focus();
                }
            }
        }

        #endregion

        #region [�I���s�C���f�b�N�X�擾]
        /// <summary>
        /// ���׃O���b�h�I���s�A�A�N�e�B�u�Z���̍s�C���f�b�N�X�擾
        /// </summary>
        /// <returns>�I���s�C���f�b�N�X��List</returns>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�I���s�A�A�N�e�B�u�Z���̍s�C���f�b�N�X�擾�B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private List<int> GetSelectRowIndex()
        {
            List<int> rowIndexList = new List<int>();

            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                // �Z���A�N�e�B�u
                rowIndexList.Add(this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index);
            }
            else if (this.GoodsBarCodeRevn_Grid.Selected.Rows.Count != 0)
            {
                foreach (UltraGridRow ultraRow in this.GoodsBarCodeRevn_Grid.Selected.Rows)
                {
                    rowIndexList.Add(ultraRow.Index);
                }
            }

            return rowIndexList;
        }
        #endregion

        #region [�O���b�h�s�̔w�i�F��ݒ�]
        /// <summary>
        /// ���׃O���b�h�e�s�̔w�i�F��ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�e�s�̔w�i�F��ݒ�B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetGridColorAll()
        {
            UltraGridRow dr;

            for (int i = 0; i < this.GoodsBarCodeRevn_Grid.Rows.Count; i++)
            {
                dr = this.GoodsBarCodeRevn_Grid.Rows[i];

                // ���׃O���b�h�s�̔w�i�F��ݒ�
                this.SetGridColorRow(dr);
            }
        }

        /// <summary>
        /// ���׃O���b�h�s�̔w�i�F��ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h�s�̔w�i�F��ݒ�B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow dr)
        {
            // �s�ԍ�
            dr.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Appearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            dr.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Appearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);

            // �폜�s�̓s���N
            if (StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "1")
            {
                dr.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Appearance.BackColorDisabled = Color.Pink;
                dr.Cells[GoodsBarCodeRevnTbl.ct_Col_RowNo].Appearance.BackColorDisabled2 = Color.Pink;
            }

            if (dr.Selected)
            {
                // �I���s�̏ꍇ
                foreach (UltraGridCell cell in dr.Cells)
                {
                    if (cell.Column.Key != GoodsBarCodeRevnTbl.ct_Col_RowNo)
                    {
                        // �����s��Active�Z���F�ŏ㏑��
                        cell.Appearance.BackColor = Color.FromArgb(251, 230, 148);
                        cell.Appearance.BackColor2 = Color.FromArgb(238, 149, 21);
                        cell.Appearance.BackColorDisabled = Color.FromArgb(251, 230, 148);
                        cell.Appearance.BackColorDisabled2 = Color.FromArgb(238, 149, 21);
                        cell.Appearance.BackGradientStyle = GradientStyle.Vertical;
                    }
                }
            }
            else
            {
                // �폜�s�̏ꍇ
                if (StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "1")
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != GoodsBarCodeRevnTbl.ct_Col_RowNo)
                        {
                            cell.Appearance.BackColor = Color.Pink;
                            cell.Appearance.BackColor2 = Color.Pink;
                            cell.Appearance.BackColorDisabled = Color.Pink;
                            cell.Appearance.BackColorDisabled2 = Color.Pink;
                        }
                    }
                    return;
                }

                // �ʏ�F�ݒ�
                if (dr.Index % 2 == 0)
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != GoodsBarCodeRevnTbl.ct_Col_RowNo)
                        {
                            cell.Appearance.BackColor = Color.White;
                            cell.Appearance.BackColor2 = Color.White;
                            cell.Appearance.BackColorDisabled = Color.White;
                            cell.Appearance.BackColorDisabled2 = Color.White;
                        }
                    }

                }
                else
                {
                    foreach (UltraGridCell cell in dr.Cells)
                    {
                        if (cell.Column.Key != GoodsBarCodeRevnTbl.ct_Col_RowNo)
                        {
                            cell.Appearance.BackColor = Color.Lavender;
                            cell.Appearance.BackColor2 = Color.Lavender;
                            cell.Appearance.BackColorDisabled = Color.Lavender;
                            cell.Appearance.BackColorDisabled2 = Color.Lavender;
                        }
                    }
                }

                // �L�[
                string dicKey = StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsMakerCd].Value) + "_" + StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsNo].Value);
                if (_goodsBarCodeRevnDic.ContainsKey(dicKey))
                {
                    // �ύX����f�[�^: ���i�o�[�R�[�h
                    if (StrObjToString(_goodsBarCodeRevnDic[dicKey].GoodsBarCode).Trim() != StrObjToString(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Value).Trim())
                    {
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Appearance.BackColor = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Appearance.BackColor2 = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Appearance.BackColorDisabled = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCode].Appearance.BackColorDisabled2 = Color.Lime;
                    }
                    // �ύX����f�[�^: ���i�o�[�R�[�h���
                    if (_goodsBarCodeRevnDic[dicKey].GoodsBarCodeKind != IntObjToInt(dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Value))
                    {
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Appearance.BackColor = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Appearance.BackColor2 = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Appearance.BackColorDisabled = Color.Lime;
                        dr.Cells[GoodsBarCodeRevnTbl.ct_Col_GoodsBarCodeKind].Appearance.BackColorDisabled2 = Color.Lime;
                    }
                }
            }
        }

        # endregion

        #region �폜�ƕ����{�^������
        /// <summary>
        /// �{�^�������Cell�A�N�e�B�u��Row�A�N�e�B�u�ŐU�蕪����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������Cell�A�N�e�B�u��Row�A�N�e�B�u�ŐU�蕪����</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetDeleteAndReviveRowButtonEnable()
        {
            if (this.GoodsBarCodeRevn_Grid.ActiveCell != null)
            {
                // �O���b�hCell�A�N�e�B�u���w�肵���A�{�^�������ې�����s���B
                this.SetDeleteAndReviveRowButtonEnableByActiveCell(this.GoodsBarCodeRevn_Grid.ActiveCell.Row.Index);
            }
            else
            {
                // �w��O���b�h�s�̏�Ԃɉ������{�^�������ې�����s��
                this.SetDeleteAndReviveRowButtonEnableBySelectedRows();
            }
        }

        /// <summary>
        /// �O���b�hCell�A�N�e�B�u���w�肵���A�{�^�������ې�����s���B
        /// </summary>
        /// <param name="rowIndex">�O���b�hCell�A�N�e�B�u���w�肵���s</param>
        /// <remarks>
        /// <br>Note       : �O���b�hCell�A�N�e�B�u���w�肵���A�{�^�������ې�����s���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetDeleteAndReviveRowButtonEnableByActiveCell(int rowIndex)
        {
            #region �폜�ƕ����{�^������

            // ���i�͍폜�\���Ԃ�
            if (StrObjToString(this.GoodsBarCodeRevn_Grid.Rows[rowIndex].Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "1")
            {
                // �폜�\��s�Ȃ̂ŁA�폜�����s��
                this.uButton_RowGoodsDelete.Enabled = false;
                // �����\��s�Ȃ̂ŁA����������
                this.uButton_RowGoodsRevive.Enabled = true;
            }
            else
            {
                // ����s�Ȃ̂ŁA�폜������
                this.uButton_RowGoodsDelete.Enabled = true;
                // ����s�Ȃ̂ŁA���������s��
                this.uButton_RowGoodsRevive.Enabled = false;
            }
            #endregion
        }

        /// <summary>
        /// �w��O���b�h�s�̏�Ԃɉ������{�^�������ې�����s���B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �w��O���b�h�s�̏�Ԃɉ������{�^�������ې�����s���B</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        private void SetDeleteAndReviveRowButtonEnableBySelectedRows()
        {
            #region �폜�ƕ����{�^������
            // �I������s�ɐ���s�����邩�̏��
            bool isGoodsNotDelete = false;
            // �I������s�ɍ폜�s�����邩�̏��
            bool isGoodNotRevive = false;

            #region �s��ԃ`�F�b�N
            foreach (UltraGridRow ultraRow in this.GoodsBarCodeRevn_Grid.Selected.Rows)
            {
                if (StrObjToString(ultraRow.Cells[GoodsBarCodeRevnTbl.ct_Col_DeleteDiv].Text) == "0")
                {
                    // �I�����鐳��s������
                    isGoodsNotDelete = true;
                }
                else
                {
                    // �I������폜�s������
                    isGoodNotRevive = true;
                }
                if (isGoodsNotDelete && isGoodNotRevive)
                {
                    break;
                }
            }
            #endregion

            if (!isGoodsNotDelete)
            {
                // �I�����鐳��s�������ꍇ�A�폜�{�^�������s��
                this.uButton_RowGoodsDelete.Enabled = false;
            }
            else
            {
                this.uButton_RowGoodsDelete.Enabled = true;
            }

            if (!isGoodNotRevive)
            {
                // �I������폜�s�������ꍇ�A�����{�^�������s��
                this.uButton_RowGoodsRevive.Enabled = false;
            }
            else
            {
                this.uButton_RowGoodsRevive.Enabled = true;
            }

            #endregion
        }

        #endregion

    }
}