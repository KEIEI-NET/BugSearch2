//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ɉꊇ�폜���
// �v���O�����T�v   : �݌Ɉꊇ�폜���UI�t�H�[���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00  �쐬�S�� : 杍^
// �� �� ��  2020/03/09   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00   �쐬�S�� : ������
// �� �� ��  2021/06/21    �C�����e : PMKOBETSU-3268�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    using Broadleaf.Application.Remoting.ParamData;
    using System.Text.RegularExpressions;

	/// <summary>
    /// �݌Ɉꊇ�폜��ʃ��C���t���[���t�H�[��
	/// </summary>
    /// <remarks>
    /// <br>Note		: �݌Ɉꊇ�폜��ʃ��C���t���[���t�H�[���B</br>
    /// <br>Programmer	: 杍^</br>
    /// <br>Date		: 2020/03/09</br>
    /// <br>Update Note: ������</br>
    /// <br>Date       : 2021/06/21</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br>           : PMKOBETSU-3268�̑Ή�</br> 
    /// </remarks>
	public partial class PMKHN09770UA : Form
    {
        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �f�t�H���g�R���X�g���N�^�B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        public PMKHN09770UA()
        {
            InitializeComponent();
            DateGetAcsObj = DateGetAcs.GetInstance();
            // ���O�C����񐶐�
            if (LoginInfoAcquisition.Employee != null)
            {
                // �]�ƈ����
                Employee employee = new Employee();
                employee = LoginInfoAcquisition.Employee;
                //��ƃR�[�h
                this._enterpriseCode = employee.EnterpriseCode;
                //���O�C���]�ƈ��R�[�h
                this._employeeCode = employee.EmployeeCode;
                //���O�C���]�ƈ�����
                this._employeeName = employee.Name;
            }

            // ���[�J�[�i�ԃp�^�[���}�X�^�A�N�Z�X�N���X
            MakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
            this._prevInfo = new HandyDeleteStockCondWork();
        }
        #endregion

        #region Private Members
        // �N���XID
        private const string ClassID = "PMKHN09770U";
        // �_�C�A���O���U���g
        private DialogResult DialogRes = DialogResult.Cancel;
        // ���t�擾���i
        private DateGetAcs DateGetAcsObj;
        /// <summary>�q�ɃA�N�Z�X�N���X</summary>
        private WarehouseAcs WarehouseObj;
        /// <summary>���[�J�[�}�X�^�@�A�N�Z�X�N���X</summary>
        private MakerAcs MakerObj;
        private HandyMakerGoodsPtrnAcs MakerGoodsPtrnAcs;	    // ���[�J�[�i�ԃp�^�[���}�X�^�A�N�Z�X�N���X
        private HandyDeleteStockCondWork _prevInfo;        // �O����͌����������
        // ���O�C�����
        private string _enterpriseCode;
        private string _employeeCode;
        private string _employeeName;

        #endregion

        #region Private Constant
        // ���t��������
        private const string NoInput = "����͂��Ă��������B";
        // ���t�����͕s��
        private const string DateInputError = "�ŏI������̓��͂��s���ł��B";
        /// <summary>�J�n�������t�����N�����̃��b�Z�[�W</summary>
        private const string SearchDateBeginInvalidDate = "�J�n�������t�̓��͂��s���ł��B";
        /// <summary>�I���������t�����N�����̃��b�Z�[�W</summary>
        private const string SearchDateEndInvalidDate = "�I���������t�̓��͂��s���ł��B";
        /// <summary>�������t�J�n���I���̃��b�Z�[�W</summary>
        private const string SearchDateStartEndError = "�������t�͈͎̔w��Ɍ�肪����܂��B";
        // �������������͖���
        private const string NoInputError = "�݌Ɉꊇ�폜������������͂��ĉ������B";
        // ���s�{�^�� LITERAL
        private const string DoText = "�݌Ɉꊇ�폜�����s���܂����H";
        // �I���A���s�{�^�� LITERAL
        private const string Caption = "�m�F";
        // ���o����ʕ��i�^�C�g��
        private const string FormTitle = "�݌Ɉꊇ�폜";
        // ���o����ʕ��i���b�Z�[�W
        private const string FormMessage = "�݌Ɉꊇ�폜�������ł�";
        // �݌Ɉꊇ�폜�Ώۂ̃f�[�^���Ȃ����b�Z�[�W
        private const string NoDeleteData = "�݌Ɉꊇ�폜�Ώۂ����݂��܂���B";
        // �݌Ɉꊇ�폜�����������b�Z�[�W
        private const string DeleteCopyFinish = "�݌Ɉꊇ�폜�������������܂����B";
        // �G���[���O�Q�ƃ��b�Z�[�W
        private const string ErrorLog = "�݌Ɉꊇ�폜���ɃG���[���������܂����B";
        // ���O�C���^�C�g��
        private const string LoginName = "LOGINTITLE";
        // ���O�C������
        private const string LoginNameTitle = "LoginName_LabelTool";
        // [�I��]�c�[���{�^���̃L�[
        private const string ToolButtonCloseKey = "Close";
        // [�I��]�c�[���{�^���̃A�C�R���i�C���f�b�N�X�j
        private const int ToolButtonCloseIconIndex = (int)Size16_Index.CLOSE;
        // [���s]�c�[���{�^���̃L�[
        private const string ToolButtonSaveKey = "Save";
        // [���s]�c�[���{�^���̃A�C�R���i�C���f�b�N�X�j
        private const int ToolButtonSaveIconIndex = (int)Size16_Index.SAVE;

        /// <summary>���t�u0�v�F���t������</summary>
        private const int LongDateZero = 0;
        /// <summary>0�X�e�[�^�X</summary>
        private const int StatusNormal = 0;
        #endregion

        #region Private Methods
        /// <summary>
        /// �c�[���o�[�����������܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�����������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// <br>Update Note: ������</br>
        /// <br>Date       : 2021/06/21</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>           : PMKOBETSU-3268�̑Ή�</br> 
        /// </remarks>
        private void InitializeToolbar()
        {
            // �C���[�W���X�g��ݒ肷��
            this.mainToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            // �c�[���o�[�Ƀ��O�C���S���҂�\������            
            this.ShowToolbarSlip();

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_GoodsMakerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_WarehouseGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            //�ŏI�����
            this.LastSalesDate_TDateEdit.SetDateTime(DateTime.Now);
            // �q��
            this.Warehouse_tComboEditor.SelectedIndex = 0;
            // �I��
            this.ShelfNo_tComboEdotor.SelectedIndex = 0;
            //-----DEL 2021/06/21 ������ PMKOBETSU-3268�̑Ή�----->>>>>
            //// �݌ɐ�
            //this.tComboEditor_StockCnt.SelectedIndex = 0;
            //-----DEL 2021/06/21 ������ PMKOBETSU-3268�̑Ή�-----<<<<<
            // �������t�˃V�X�e�����t�Z�b�g
            DateTime dateTime = DateTime.Now;
            this.tDate_SearchDateBegin.SetDateTime(dateTime);
            this.tDate_SearchDateEnd.SetDateTime(dateTime);
            //--------------------------------------------------------------
            // �W�� �c�[���o�[
            //--------------------------------------------------------------
            // ����c�[���{�^���̃A�C�R���ݒ�
            CloseToolButton.SharedProps.AppearancesSmall.Appearance.Image = ToolButtonCloseIconIndex;

            // ���s�c�[���{�^���̃A�C�R���ݒ�
            SaveToolButton.SharedProps.AppearancesSmall.Appearance.Image = ToolButtonSaveIconIndex;
        }

        /// <summary>
        /// �c�[���o�[�Ƀ��O�C���S���҂�\������
        /// </summary>
        private void ShowToolbarSlip()
        {
            //���O�C���]�ƈ�����
            if (LoginInfoAcquisition.Employee.Name != null)
            {
                this.mainToolbarsManager.Tools[LoginNameTitle].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            LabelTool loginName = (LabelTool)mainToolbarsManager.Tools[LoginNameTitle];
            if (loginName != null && _employeeName != null)
                loginName.SharedProps.Caption = this._employeeName;
        }

        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <param name="extraInfo">�݌Ɉꊇ�폜��ʂ̒��o�������[�N</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// <br>Update Note : ������</br>
        /// <br>Date        : 2021/06/21</br>
        /// <br>�Ǘ��ԍ�    : 11601223-00</br>
        /// <br>            : PMKOBETSU-3268�̑Ή�</br> 
        /// </remarks>
        private int SetExtraInfoFromScreen(ref HandyDeleteStockCondWork extraInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                extraInfo.EnterpriseCode = this._enterpriseCode;
                // �ŏI�����
                extraInfo.LastSalesDate = this.LastSalesDate_TDateEdit.GetLongDate();
                // �q��
                extraInfo.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                // ���[�J�[
                extraInfo.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
                // �q�ɒI��
                extraInfo.WarehouseShelfNo = this.tEdit_WarehouseShelfNo.Text.TrimEnd();
                //-----DEL 2021/06/21 ������ PMKOBETSU-3268�̑Ή�----->>>>>
                //// �݌ɐ�
                //extraInfo.StockDiv = this.tComboEditor_StockCnt.SelectedIndex;
                //-----DEL 2021/06/21 ������ PMKOBETSU-3268�̑Ή�-----<<<<<
                // �g�p��
                extraInfo.UseCount = this.tNedit1_count.GetInt();
                // �������t�J�n
                extraInfo.SearchDateSt = GetLongDate(this.tDate_SearchDateBegin.GetDateTime());
                // �������t�I��
                extraInfo.SearchDateEd = GetLongDate(this.tDate_SearchDateEnd.GetDateTime());

            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �݌Ɉꊇ�폜����
        /// </summary>
        /// <param name="deleteStockCondWork">�݌Ɉꊇ�폜�f�[�^���o�������[�N</param>
        /// <remarks>
        /// <br>Note        : �݌Ɉꊇ�폜�������s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private void DeleteStockWithMng(HandyDeleteStockCondWork deleteStockCondWork)
        {
            // ���o����ʕ��i�̃C���X�^���X���쐬
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // �\��������ݒ�
            form.Title = FormTitle;
            form.Message = FormMessage;
            this.Cursor = Cursors.WaitCursor;
            // �_�C�A���O�\��
            ToolbarOff();
            form.Show();

            //�������ʏ�Ԏ擾
            status = this.MakerGoodsPtrnAcs.DeleteStockWithMng(deleteStockCondWork);

            this.Cursor = Cursors.Default;
            // �_�C�A���O�����
            form.Close();
            ToolbarOn();
            this.Activate();

            // ���s����̏ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �݌Ɉꊇ�폜�������b�Z�[�W
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                 ClassID,
                                 DeleteCopyFinish,
                                 0,
                                 MessageBoxButtons.OK);

            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ���b�Z�[�W��\��
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 ClassID,
                                 NoDeleteData,
                                 0,
                                 MessageBoxButtons.OK);
            }
            else
            {
                //�݌Ɉꊇ�폜���ɃG���[����������ꍇ�A���b�Z�[�W��\��
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                 ClassID,
                                 ErrorLog,
                                 0,
                                 MessageBoxButtons.OK);
            }
        }

        #region ���t���l�擾����
        /// <summary>
        /// ���t���l�擾����
        /// </summary>
        /// <param name="date">DateTime�^���t</param>
        /// <returns>���l���t(YYYYMMDD)</returns>
        /// <remarks>
        /// <br>Note       : ���t���l�擾�������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private static int GetLongDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return 0;
            }
            else
            {
                return ((date.Year * 10000) + (date.Month * 100) + (date.Day));
            }
        }
        #endregion
        #endregion

        #region ���̓`�F�b�N
        /// <summary>
        /// ��ʂ̓��̓`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ̓��̓`�F�b�N���s��</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private bool InputCheck()
        {
            bool status = true;

            string errMessage = null;
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, ClassID, errMessage, 0, MessageBoxButtons.OK);
                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }
                else
                {
                    //�Ȃ�
                }
                status = false;
            }
            else
            {
                //�Ȃ�
            }
            return status;
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// <br>Update Note : ������</br>
        /// <br>Date        : 2021/06/21</br>
        /// <br>�Ǘ��ԍ�    : 11601223-00</br>
        /// <br>            : PMKOBETSU-3268�̑Ή�</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            // �ŏI�����
            if (DateGetAcsObj.CheckDate(ref LastSalesDate_TDateEdit, true) == DateGetAcs.CheckDateResult.ErrorOfInvalid)
            {
                errMessage = DateInputError;
                errComponent = this.LastSalesDate_TDateEdit;
                status = false;
                return status;
            }

            DateGetAcs.CheckDateResult Cdr;

            // �������t�J�n
            if (this.tDate_SearchDateBegin.GetLongDate() != LongDateZero)
            {
                // �����N�����̏ꍇ
                Cdr = this.DateGetAcsObj.CheckDate(ref this.tDate_SearchDateBegin, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    errMessage = SearchDateBeginInvalidDate;
                    errComponent = this.tDate_SearchDateBegin;
                    status = false;
                    return status;
                }
            }

            // �������t�I��
            if (this.tDate_SearchDateEnd.GetLongDate() != LongDateZero)
            {
                // �����N�����̏ꍇ
                Cdr = this.DateGetAcsObj.CheckDate(ref this.tDate_SearchDateEnd, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    errMessage = SearchDateEndInvalidDate;
                    errComponent = this.tDate_SearchDateEnd;
                    status = false;
                    return status;
                }
            }

            // �������t�J�n�A�I��
            // �J�n�A�I���̑召��r
            if (this.tDate_SearchDateBegin.GetLongDate() != LongDateZero && this.tDate_SearchDateEnd.GetLongDate() != LongDateZero)
            {
                if (this.tDate_SearchDateBegin.GetLongDate() > this.tDate_SearchDateEnd.GetLongDate())
                {
                    errMessage = SearchDateStartEndError;
                    errComponent = this.tDate_SearchDateBegin;
                    status = false;
                    return status;
                }
            }

            // �����������̏ꍇ
            // �݌ɐ����w��Ȃ��݂̂̏ꍇ�A�`�F�b�N���s��
            //-----DEL 2021/06/21 ������ PMKOBETSU-3268�̑Ή�----->>>>>
            //if (tComboEditor_StockCnt.SelectedIndex == 0)
            //{
            //-----DEL 2021/06/21 ������ PMKOBETSU-3268�̑Ή�-----<<<<<
                if (string.IsNullOrEmpty(tEdit_WarehouseCode.Text.Trim())
                    && string.IsNullOrEmpty(tEdit_WarehouseShelfNo.Text.Trim())
                    && string.IsNullOrEmpty(tNedit_GoodsMakerCd.Text.Trim())
                    && string.IsNullOrEmpty(tNedit1_count.Text.Trim())
                    && this.LastSalesDate_TDateEdit.GetLongDate() == LongDateZero
                    && this.tDate_SearchDateBegin.GetLongDate() == LongDateZero
                    && this.tDate_SearchDateEnd.GetLongDate() == LongDateZero)
                {
                    errMessage = NoInputError;
                    errComponent = this.Warehouse_tComboEditor;
                    status = false;
                }
            //}// DEL 2021/06/21 ������ PMKOBETSU-3268�̑Ή� 
            return status;
        }
        #endregion
        
        #region ControlEvent

        #region [�I��]�c�[���{�^��

        /// <summary>
        /// [�I��]�c�[���{�^�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note		: ����c�[���{�^���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private ButtonTool CloseToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[ToolButtonCloseKey]; }
        }

        #endregion

        #region [���s]�c�[���{�^��

        /// <summary>
        /// [���s]�c�[���{�^�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note		: [���s]�c�[���{�^���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private ButtonTool SaveToolButton
        {
            get { return (ButtonTool)this.mainToolbarsManager.Tools[ToolButtonSaveKey]; }
        }

        #endregion

        /// <summary>
        /// �c�[���o�[��ToolClick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[��ToolClick�C�x���g�n���h���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private void mainToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case ToolButtonCloseKey: // [�I��]
                    {
                        this.Close();
                        break;
                    }
                case ToolButtonSaveKey:  // [���s]
                    {
                        // [���s]�c�[���{�^�����N���b�N
                        // �m�菈��
                        if (InputCheck().Equals(true))
                        {
                            HandyDeleteStockCondWork deleteStockCondWork = new HandyDeleteStockCondWork();
                            // ���s�𔻒f����B
                            if (!TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ClassID, DoText, 0, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1).Equals(DialogResult.Yes)) break;
                            // ���o�����ݒ菈��
                            this.SetExtraInfoFromScreen(ref deleteStockCondWork);
                            // �m�菈��
                            this.DeleteStockWithMng(deleteStockCondWork);
                            // �_�C�A���O���U���g�ݒ菈��
                            this.SetDialogRes(DialogResult.OK);
                        }
                        else
                        {
                            //�Ȃ�
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �_�C�A���O���U���g�ݒ菈��
        /// </summary>
        /// <param name="dialogRes">�_�C�A���O���U���g</param>
        /// <remarks>
        /// <br>Note       : �_�C�A���O���U���g�ݒ菈���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void SetDialogRes(DialogResult dialogRes)
        {
            DialogRes = dialogRes;
        }

        /// <summary>
		/// �Z�L�����e�B�Ǘ����C���t���[����Load�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʏ�����Load���A���s����B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        private void PMKHN09770UA_Load(object sender, EventArgs e)
        {
            // �c�[���o�[��������
            InitializeToolbar();
        }
        

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �`�F�b�N���X�g�{�b�N�X�t�H�[�J�XRight���A�ړ����Ȃ��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // �}�E�X�Ń��j���̃t�@���N�V�����{�^�����N���b�N����ꍇ
            if (e.NextCtrl is Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea) return;

            switch (e.PrevCtrl.Name)
            {
                case "Warehouse_tComboEditor":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("Warehouse_tComboEditor"))
                            {
                                e.NextCtrl = this.Warehouse_tComboEditor;
                            }
                        }

                        break;
                    }
                case "uButton_WarehouseGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("uButton_WarehouseGuide"))
                            {
                                e.NextCtrl = this.uButton_WarehouseGuide;
                            }
                            if (e.Key == Keys.Down && e.PrevCtrl.Name.Equals("uButton_WarehouseGuide"))
                            {
                                e.NextCtrl = this.ShelfNo_tComboEdotor;
                            }
                        }

                        break;
                    }
                case "tEdit_WarehouseCode":
                    {
                        # region [�q��]

                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Down && e.PrevCtrl.Name.Equals("tEdit_WarehouseCode"))
                            {
                                e.NextCtrl = this.ShelfNo_tComboEdotor;
                            }
                        }

                        bool status;

                        if (tEdit_WarehouseCode.Text == _prevInfo.WarehouseCode)
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;
                            // �ǂݍ���
                            status = ReadWarehouse(tEdit_WarehouseCode.Text, out code, out name);

                            if (status)
                            {
                                // �R�[�h�E���̂��X�V
                                tEdit_WarehouseCode.Text = code.TrimEnd();
                                _prevInfo.WarehouseCode = code.TrimEnd();
                                uLabel_WarehouseName.Text = name;
                            }
                            else
                            {
                                tEdit_WarehouseCode.Text = _prevInfo.WarehouseCode;
                            }
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
                                            if (_prevInfo.WarehouseCode == string.Empty)
                                            {
                                                e.NextCtrl = this.uButton_WarehouseGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.ShelfNo_tComboEdotor;
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
                                "�q�ɃR�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                        break;
                    }
                case "tNedit_GoodsMakerCd":
                    {
                        # region [���[�J�[]

                        bool status = false;

                        if (tNedit_GoodsMakerCd.GetInt() == _prevInfo.GoodsMakerCd)
                        {
                            status = true;
                        }
                        else
                        {
                            int code;
                            string name;
                            // �ǂݍ���
                            status = ReadGoodsMaker(tNedit_GoodsMakerCd.GetInt(), out code, out name);

                            if (status)
                            {
                                // �R�[�h�E���̂��X�V
                                tNedit_GoodsMakerCd.SetInt(code);
                                _prevInfo.GoodsMakerCd = code;
                                uLabel_MakerName.Text = name;
                            }
                            else
                            {
                                tNedit_GoodsMakerCd.SetInt(_prevInfo.GoodsMakerCd);
                            }
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
                                            if (_prevInfo.GoodsMakerCd == 0)
                                            {
                                                e.NextCtrl = this.uButton_GoodsMakerGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit1_count;
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
                                "���[�J�[�R�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);
                        }
                        # endregion
                        break;
                    }
                case "tComboEditor_StockCnt":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("tComboEditor_StockCnt"))
                            {
                                e.NextCtrl = this.ShelfNo_tComboEdotor;
                            }
                        }
                        break;
                    }
                case "tEdit_WarehouseShelfNo":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("tEdit_WarehouseShelfNo"))
                            {
                                e.NextCtrl = this.Warehouse_tComboEditor;
                            }
                        }
                        break;
                    }
                case "LastSalesDate_TDateEdit":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Down && e.PrevCtrl.Name.Equals("LastSalesDate_TDateEdit"))
                            {
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                            }
                        }
                        break;
                    }
                case "uButton_GoodsMakerGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            if (e.Key == Keys.Up && e.PrevCtrl.Name.Equals("uButton_GoodsMakerGuide"))
                            {
                                e.NextCtrl = this.LastSalesDate_TDateEdit;
                            }
                        }
                        break;
                    }
                case "tDate_SearchDateBegin":

                    // �����ȊO����͂���ꍇ�A�N���A����
                    if (this.tDate_SearchDateBegin.GetDateYear() == 0 || this.tDate_SearchDateBegin.GetDateMonth() == 0 || this.tDate_SearchDateBegin.GetDateDay() == 0)
                    {
                        this.tDate_SearchDateBegin.Clear();
                    }
                    if (!e.ShiftKey && e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.tNedit1_count;
                    }
                    break;
                case "tDate_SearchDateEnd":

                    // �����ȊO����͂���ꍇ�A�N���A����
                    if (this.tDate_SearchDateEnd.GetDateYear() == 0 || this.tDate_SearchDateEnd.GetDateMonth() == 0 || this.tDate_SearchDateEnd.GetDateDay() == 0)
                    {
                        this.tDate_SearchDateEnd.Clear();
                    }
                    if (!e.ShiftKey && e.Key == Keys.Up)
                    {
                        e.NextCtrl = this.tNedit1_count;
                    }

                    break;
            }
        }
        # region �� �c�[���o�[�N���p�t���O ��
        /// <summary>
        /// �c�[���o�[�N���p�t���O
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �c�[���o�[�N���p�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private void ToolbarOn()
        {
            this.mainToolbarsManager.Tools[ToolButtonCloseKey].SharedProps.Enabled = true;
            this.mainToolbarsManager.Tools[ToolButtonSaveKey].SharedProps.Enabled = true;
        }
        # endregion �� �c�[���o�[�N���p�t���O ��

        # region �� �c�[���o�[�߂�p�t���O ��
        /// <summary>
        /// �c�[���o�[�߂�p�t���O
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �c�[���o�[�߂�p�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private void ToolbarOff()
        {
            this.mainToolbarsManager.Tools[ToolButtonCloseKey].SharedProps.Enabled = false;
            this.mainToolbarsManager.Tools[ToolButtonSaveKey].SharedProps.Enabled = false;
        }
        # endregion �� �c�[���o�[�߂�p�t���O ��


        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �q�ɃK�C�h�{�^���N���b�N�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2020/03/09</br>
        /// </remarks>
        private void uButton_WarehouseGuide_Click(object sender, EventArgs e)
        {
            // �A�N�Z�X�N���X�C���X�^���X����
            if (WarehouseObj == null)
            {
                WarehouseObj = new WarehouseAcs();
            }

            // �K�C�h���s
            Warehouse warehouse;
            int status = WarehouseObj.ExecuteGuid(out warehouse, this._enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_WarehouseCode.Text = warehouse.WarehouseCode.Trim();
                _prevInfo.WarehouseCode = warehouse.WarehouseCode.Trim();
                this.uLabel_WarehouseName.Text = warehouse.WarehouseName;

                // ���t�H�[�J�X
                ShelfNo_tComboEdotor.Focus();
            }
        }

        /// <summary>
        /// ���[�J�[�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�K�C�h�{�^���N���b�N�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void uButton_GoodsMakerGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUMnt;
            // �A�N�Z�X�N���X�C���X�^���X����
            if (MakerObj == null)
            {
                MakerObj = new MakerAcs();
            }
            int status = MakerObj.ExecuteGuid(this._enterpriseCode, out makerUMnt);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                _prevInfo.GoodsMakerCd = makerUMnt.GoodsMakerCd;
                uLabel_MakerName.Text = makerUMnt.MakerName.Trim();

                // ���t�H�[�J�X
                tNedit1_count.Focus();
            }
        }

        /// <summary>
        /// �q�ɒ��o���� �l�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �q�ɒ��o���� �l�ύX�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void Warehouse_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.Warehouse_tComboEditor.SelectedIndex == 0)
            {
                this.uButton_WarehouseGuide.Enabled = false;
                this.tEdit_WarehouseCode.Enabled = false;
                this.tEdit_WarehouseCode.Clear();
                this.uLabel_WarehouseName.Text = "";
                this._prevInfo.WarehouseCode = string.Empty;
            }
            else
            {
                this.uButton_WarehouseGuide.Enabled = true;
                this.tEdit_WarehouseCode.Enabled = true;
                this.tEdit_WarehouseCode.Clear();
                this.uLabel_WarehouseName.Text = "";
                this._prevInfo.WarehouseCode = string.Empty;
            }

        }

        /// <summary>
        /// �I�Ԓ��o���� �l�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �I�Ԓ��o���� �l�ύX�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void ShelfNo_tComboEdotor_ValueChanged(object sender, EventArgs e)
        {
            if (this.ShelfNo_tComboEdotor.SelectedIndex == 0)
            {
                this.tEdit_WarehouseShelfNo.Enabled = false;
                this.tEdit_WarehouseShelfNo.Clear();
            }
            else
            {
                this.tEdit_WarehouseShelfNo.Enabled = true;
                this.tEdit_WarehouseShelfNo.Clear();
            }

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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private bool ReadWarehouse(string warehouseCode, out string code, out string name)
        {
            bool result = false;

            // �����͔���
            if (warehouseCode != string.Empty)
            {
                // �ǂݍ���
                if (WarehouseObj == null)
                {
                    WarehouseObj = new WarehouseAcs();
                }
                Warehouse warehouse;
                string warehouseCd = warehouseCode.Trim().PadLeft(4, '0');
                int status = WarehouseObj.Read(out warehouse, this._enterpriseCode, string.Empty, warehouseCd);

                if (status == 0 && warehouse != null && warehouse.LogicalDeleteCode == 0)
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private bool ReadGoodsMaker(int goodsMakerCd, out int code, out string name)
        {
            bool result = false;

            // �����͔���
            if (goodsMakerCd != 0)
            {
                // �ǂݍ���
                if (MakerObj == null)
                {
                    MakerObj = new MakerAcs();
                }
                MakerUMnt maker;
                int status = MakerObj.Read(out maker, this._enterpriseCode, goodsMakerCd);

                if (status == 0 && maker != null && maker.LogicalDeleteCode == 0)
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

    }
}