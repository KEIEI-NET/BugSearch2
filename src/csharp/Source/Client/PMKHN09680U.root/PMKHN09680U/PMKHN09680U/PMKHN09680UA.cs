//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�R���o�[�g
// �v���O�����T�v   : �݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪���A�o�׉\�����X�V����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/08/26  �C�����e : �A��No.1016 �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Broadleaf.Application.Common;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌Ƀ}�X�^�R���o�[�g����
    /// </summary>
    /// <remarks>
    /// Note       : �݌Ƀ}�X�^�R���o�[�g�����ł��B<br />
    /// Programmer : �����<br />
    /// Date       : 2011/08/26<br />
    /// </remarks>
    public partial class PMKHN09680UA : Form
    {
        #region �� Const Memebers ��
        private const string PROGRAM_ID = "PMKHN01300U";
        #endregion

        # region �� private field ��
        private ControlScreenSkin _controlScreenSkin;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executeButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private StockConvertAcs _stockConvertAcs;
        private StockMngTtlStAcs _stockMngTtlStAcs = null;              //�݌ɑS�̐ݒ�}�X�^�A�N�Z�X
        private StockMngTtlSt _stockMngTtlSt = null;                    //�݌ɊǗ��S�̐ݒ�
        #endregion

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        public PMKHN09680UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._controlScreenSkin = new ControlScreenSkin();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Execute"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._stockConvertAcs = StockConvertAcs.GetInstance();

            // �݌ɑS�̊Ǘ��ݒ�ǂݍ���
            this.ReadStockMngTtlSt();
        }
        #endregion

        # region �� ��ʏ�������C�x���g ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪�ɏ]���A��ʂ̕\���̕ύX�B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪�ɏ]���A��ʂ̕\����ύX����</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private void StockDivSetting()
        {
            // �݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪�ɏ]���B
            if (_stockMngTtlSt.PreStckCntDspDiv == 0)
            {
                this.StockDiv_uLabel.Text = "�݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪�́u0:�󒍕��܂ށv�ł��B";
            }
            else
            {
                this.StockDiv_uLabel.Text = "�݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪�́u1:�󒍕��܂܂Ȃ��v�ł��B";
            }
        }
        #endregion

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: �����</br>	
        /// <br>Date		: 2011/08/26</br>
        /// </remarks>
        private void PMKHN01300UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();
            // ��ʂ̕\���̕ύX
            this.StockDivSetting();

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }
        #endregion

        #region �� �݌Ƀ}�X�^�R���o�[�g�������b�\�h�֘A ��
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: �����</br>	
        /// <br>Date		: 2011/08/26</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                case "ButtonTool_Execute":
                    {
                        DialogResult dialogResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "�݌Ƀ}�X�^�R���o�[�g���������s���܂��B\r\n\r\n��낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // ���s����
                            this.ExecuteProcess();
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �݌Ƀ}�X�^�R���o�[�g����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �݌Ƀ}�X�^�R���o�[�g�������s���B</br>
        /// <br>Programmer	: �����</br>	
        /// <br>Date		: 2011/08/26</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            int stockCount = 0;
            int stockAcPayHistCount = 0;

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�݌Ƀ}�X�^�R���o�[�g";
            form.Message = "���݁A�݌Ƀ}�X�^�R���o�[�g�������ł��B";

            this.Cursor = Cursors.WaitCursor;
            // �_�C�A���O�\��
            form.Show();

            int status = _stockConvertAcs.StockConvertProc(_enterpriseCode,this._stockMngTtlSt.PreStckCntDspDiv, out stockCount, out stockAcPayHistCount);

            // �_�C�A���O�����
            form.Close();
            this.Cursor = Cursors.Default;

            this.StockCount_uLabel.Text = stockCount.ToString("#,##0") + " ��";
            this.StockAcPayHist_uLabel.Text = stockAcPayHistCount.ToString("#,##0") + " ��";

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "�݌Ƀ}�X�^�R���o�[�g�������������܂����B",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            else
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    "�R���o�[�g�����ɃG���[���������܂����B",
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        #region ReadStockMngTtlSt(�݌ɑS�̊Ǘ��ݒ�ǂݍ���)
        /// <summary>
        /// �݌ɑS�̊Ǘ��ݒ�ǂݍ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private void ReadStockMngTtlSt()
        {
            ArrayList retList;

            if (_stockMngTtlStAcs == null)
            {
                _stockMngTtlStAcs = new StockMngTtlStAcs();
            }

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        this._stockMngTtlSt = stockMngTtlSt;
                        break;
                    }
                }
            }
            else
            {
                this._stockMngTtlSt = new StockMngTtlSt();
            }
        }
        #endregion
    }
}