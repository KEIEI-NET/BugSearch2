//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌ɗ������݌ɐ��ݒ�
// �v���O�����T�v   : �݌Ƀ}�X�^�̌��݌ɐ������ɁA�݌ɗ����f�[�^�̐��������݌ɐ����Čv�Z���X�V����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� :
// �C �� ��  2010/01/13  �C�����e : redmine#2333 �Ώ۔N���̏����\�����C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Globalization;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �݌ɗ������݌ɐ��ݒ�
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�̌��݌ɐ������ɁA�݌ɗ����f�[�^�̐��������݌ɐ����Čv�Z���X�V����B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009/12/24</br>
    /// <br>UpdateNote : 2010/01/13 ����� �o�l�D�m�r�ێ�˗��C</br>
    /// <br>             redmine#2333 �Ώ۔N���̏����\�����C��</br>
    /// </remarks>
    public partial class PMZAI09150UA : Form
    {
        #region �� Const Memebers ��
        private const string ct_ClassID = "PMZAI09150UA";
        #endregion �� Const Memebers ��

        #region �� private field ��

        // ��ƃR�[�h
        private string _enterpriseCode;

        private ImageList _imageList16 = null;
        // �N���[�Y�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        // ���s�{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _runButton;
        // ���O�C���S����
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;
        // �݌ɗ������݌ɐ��ݒ�C���^�[�t�F�[�X�Ώ�
        private StockHistoryUpdateAcs _stockHistoryUpdateAcs;
        // ���O�C���S���Җ���
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        // �f�t�H���g�s�̊O�ϐݒ�
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

        private DateGetAcs _dateGetAcs;

        private ObjAutoSetAcs _objAutoSetAcs;
        #endregion �� private field ��

        #region �� Constructor ��
        /// <summary>
        /// �݌ɗ������݌ɐ��ݒ�UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌ɗ������݌ɐ��ݒ�UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/24</br>
        /// <br></br>
        /// </remarks>
        public PMZAI09150UA()
        {
            InitializeComponent();
            // �ϐ�������
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._runButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Run"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._stockHistoryUpdateAcs = new StockHistoryUpdateAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();
            this._objAutoSetAcs = ObjAutoSetAcs.GetInstance();
        }
        #endregion �� Constructor ��

        #region  �� Control Event ��
        #region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2009/12/24</br>
        /// <br>UpdateNote  : 2010/01/13 ����� �o�l�D�m�r�ێ�˗��C</br>
        /// <br>              redmine#2333 �Ώ۔N���̏����\�����C��</br>
        /// </remarks>
        private void PMZAI09150UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // �{�^��������
            this.ButtonInitialSetting();

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // �����\���͖{�N�x�̊��񌎂Ƃ���B
            List<DateTime> yearMonth;
            this._objAutoSetAcs.GetCompanyInf(out yearMonth);
            //this.tDateEdit_AddUpYearMonthSt.SetDateTime(DateTime.ParseExact(DateTime.Now.ToString("yyyy") + yearMonth[0].ToString("MMdd"), "yyyyMMdd", CultureInfo.InvariantCulture)); // DEL 2010/01/13
            this.tDateEdit_AddUpYearMonthSt.SetDateTime(yearMonth[0]); // ADD 2010/01/13
        }
        #endregion �� �t�H�[�����[�h ��

        #region �� �c�[���o�[�{�^���N���b�N�C�x���g���� ��
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2009/12/24</br>
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
                case "ButtonTool_Run":
                    {
                        // �`�F�b�N����
                        if (this.UpdateBeforeCheck())
                        {
                            // ���s�m�F���b�Z�[�W�\��
                            DialogResult dialogResult = TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_QUESTION,
                                this.Name,
                                "���������s���܂����H",
                                0,
                                MessageBoxButtons.YesNo);

                            if (dialogResult == DialogResult.Yes)
                            {
                                // ���s����
                                this.UpdateProcess();
                            }
                        }
                        break;
                    }
            }
        }
        #endregion �� �c�[���o�[�{�^���N���b�N�C�x���g���� ��
        #endregion

        #region  �� Private Method ��
        #region  �� �݌ɗ����f�[�^�X�V���� ��
        /// <summary>
        /// �݌ɗ����f�[�^�X�V����
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �݌ɗ����f�[�^�X�V�������s���B</br>
        /// <br>Programmer	: �����</br>
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        private void UpdateProcess()
        {
            // ���o����ʕ��i�̃C���X�^���X���쐬
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            SFCMN00299CA form = new SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�݌ɗ������݌ɐ��ݒ�";
            form.Message = "���݁A�������ł��B";
            // �_�C�A���O�\��
            form.Show();
            string errMsg = string.Empty;

            // ���������i�[����
            StockHistoryExtractInfo extrInfo;
            this.SetExtrInfo(out extrInfo);

            // �݌ɗ����X�V����
            status = this._stockHistoryUpdateAcs.Update(extrInfo, out errMsg);

            // �_�C�A���O�����
            form.Close();
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�������������܂����B",
                    -1,
                    MessageBoxButtons.OK);
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                TMsgDisp.Show(
                   this,
                   emErrorLevel.ERR_LEVEL_INFO,
                   this.Name,
                   "�Y���f�[�^����܂���B",
                   -1,
                   MessageBoxButtons.OK);
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMsg,
                    status,
                    MessageBoxButtons.OK);
            }
        }
        #endregion �� �݌ɗ����f�[�^�X�V���� ��

        #region  �� �{�^�������ݒ菈�� ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��������ɔ������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            // �I���{�^��
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // ���s�{�^��
            this._runButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            // ���O�C���S���҃��[�x��
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

        }
        #endregion �� �{�^�������ݒ菈�� ��

        /// <summary>
        /// ���������i�[����
        /// </summary>
        /// <param name="extrInfo">��������(�����I��out�p�����[�^�œn���܂�)</param>
        /// <remarks>
        /// <br>Note        : �����������i�[���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/12/24</br>
        /// </remarks>
        private void SetExtrInfo(out StockHistoryExtractInfo extrInfo)
        {
            extrInfo = new StockHistoryExtractInfo();

            // ��ƃR�[�h
            extrInfo.EnterpriseCode = this._enterpriseCode;

            // �Ώ۔N��
            DateTime dateAddUpYearMonthSt = this.tDateEdit_AddUpYearMonthSt.GetDateTime();
            extrInfo.AddUpYearMonthSt = Convert.ToInt32(dateAddUpYearMonthSt.ToString("yyyyMM"));
        }

        /// <summary>
        /// �N���A�O�̃`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note        : �N���A�O�̃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/12/24</br>
        /// </remarks>
        private bool UpdateBeforeCheck()
        {
            string errMsg = string.Empty;

            // ���t�̖����̓`�F�b�N
            if (this.CheckDateNoInput(this.tDateEdit_AddUpYearMonthSt))
            {
                errMsg = "�Ώ۔N������͂��ĉ������B";
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                this.tDateEdit_AddUpYearMonthSt.Select();
                return false;
            }

            // ���t�̕s�����̓`�F�b�N
            if (this.CheckDateInvalid(this.tDateEdit_AddUpYearMonthSt))
            {
                errMsg = "�Ώ۔N�����s���ł��B";
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMsg,
                    -1,
                    MessageBoxButtons.OK);
                this.tDateEdit_AddUpYearMonthSt.Select();
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���t�̖����̓`�F�b�N
        /// </summary>
        /// <param name="targetDateEdit">���t</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note        : ���t�̖����̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/12/24</br>
        /// </remarks>
        private bool CheckDateNoInput(TDateEdit targetDateEdit)
        {
            DateGetAcs.CheckDateResult result = this._dateGetAcs.CheckDate(ref targetDateEdit);
            return (result == DateGetAcs.CheckDateResult.ErrorOfNoInput);
        }

        /// <summary>
        /// ���t�̕s�����̓`�F�b�N
        /// </summary>
        /// <param name="targetDateEdit">���t</param>
        /// <returns>�`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note        : ���t�̕s�����̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009/12/24</br>
        /// </remarks>
        private bool CheckDateInvalid(TDateEdit targetDateEdit)
        {
            DateGetAcs.CheckDateResult result = this._dateGetAcs.CheckDate(ref targetDateEdit);
            return (result == DateGetAcs.CheckDateResult.ErrorOfInvalid);
        }
        #endregion  �� Private Method ��
    }
}