//****************************************************************************//
// �V�X�e��         : �v�����^�ݒ�}�X�^�i�T�[�o�p�j
// �v���O��������   : �v�����^�ݒ�}�X�^�i�T�[�o�p�j�r���[
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/09/16  �C�����e : �V�K�쐬�iSFCMN09200U���ڐA����уA�����W�j
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Other;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms.Other
{
    using DataTableType     = ServerPrinterSettingDataSet.SrvPrtStDataTable;
    using PrinterProfileType= Dictionary<string, object>;
    using PrinterProfileMap = Dictionary<string, Dictionary<string, object>>;

    /// <summary>
    /// �v�����^�ݒ�}�X�^�i�T�[�o�p�j���̓t�H�[��
    /// </summary>
    public partial class PrtManageForm : Form
    {
        #region <Controller>

        /// <summary>�v�����^�ݒ�}�X�^�i�T�[�o�p�j�R���g���[��</summary>
        private readonly ServerPrinterSettingController _myController;
        /// <summary>�v�����^�ݒ�}�X�^�i�T�[�o�p�j�R���g���[�����擾���܂��B</summary>
        private ServerPrinterSettingController MyController { get { return _myController; } }

        /// <summary>��ƃR�[�h���擾���܂��B</summary>
        private string EnterpriseCode
        {
            get { return MyController.EnterpriseCode; }
        }

        #endregion // </Controller>

        #region <�ҏW���[�h>

        /// <summary>
        /// �ҏW���[�h�񋓌^
        /// </summary>
        public enum EditMode : int
        {
            /// <summary>�V�K</summary>
            New,
            /// <summary>�X�V</summary>
            Update,
            /// <summary>�폜</summary>
            Delete
        }

        /// <summary>
        /// �ҏW���[�h���̂��擾���܂��B
        /// </summary>
        /// <param name="editMode">�ҏW���[�h</param>
        /// <returns>
        /// <c>EditMode.New</c>   :�V�K���[�h<br/>
        /// <c>EditMode.Update</c>:�X�V���[�h<br/>
        /// <c>EditMode.Delete</c>:�폜���[�h<br/>
        /// ����ȊO�� �H�H���[�h ��Ԃ��܂��B
        /// </returns>
        private static string GetEditModeName(EditMode editMode)
        {
            switch (editMode)
            {
                case EditMode.New:
                    return "�V�K���[�h";    // LITERAL:
                case EditMode.Update:
                    return "�X�V���[�h";    // LITERAL:
                case EditMode.Delete:
                    return "�폜���[�h";    // LITERAL:
                default:
                    return "�H�H���[�h";    // LITERAL:
            }
        }

        /// <summary>���݂̕ҏW���[�h</summary>
        private EditMode _currentEditMode;
        /// <summary>���݂̕ҏW���[�h���擾����ѐݒ肵�܂��B</summary>
        private EditMode CurrentEditMode
        {
            get { return _currentEditMode; }
            set { _currentEditMode = value; }
        }

        #endregion // </�ҏW���[�h>

        /// <summary>�v�����^���̃}�b�v</summary>
        private readonly PrinterProfileMap _printerMap = new PrinterProfileMap();
        /// <summary>�v�����^���̃}�b�v���擾���܂��B</summary>
        private PrinterProfileMap PrinterMap { get { return _printerMap; } }

        /// <summary>�N�����̃v�����^�ݒ���e</summary>
        private PrtManage _initialPrtManage;
        /// <summary>�N�����̃v�����^�ݒ���e���擾����ѐݒ肵�܂��B</summary>
        private PrtManage InitialPrtManage
        {
            get { return _initialPrtManage; }
            set { _initialPrtManage = value; }
        }

        /// <summary>�V�K�v�����^�Ǘ�No</summary>
        public const int NONE_PRINTER_MNG_NO = ServerPrinterSettingController.NULL_PRINTER_MNG_NO;

        /// <summary>���݂̃v�����^�Ǘ�No</summary>
        private int _currentPrinterMngNo = NONE_PRINTER_MNG_NO;
        /// <summary>���݂̃v�����^�Ǘ��ԍ����擾�܂��͐ݒ肵�܂��B</summary>
        private int CurrentPrinterMngNo
        {
            get { return _currentPrinterMngNo; }
            set { _currentPrinterMngNo = value; }
        }

        /// <summary>�v���O����ID</summary>
        private const string PG_ID = "PMKHN09581U";

        #region <Constractor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="myController">�R���g���[��</param>
        /// <param name="editMode">�ҏW���[�h</param>
        public PrtManageForm(
            ServerPrinterSettingController myController,
            EditMode editMode
        ) : base()
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>

            _myController = myController;
            if (myController.DoingRecord != null)
            {
                _currentPrinterMngNo = myController.DoingRecord.PrinterMngNo;
            }
            else
            {
                _currentPrinterMngNo = NONE_PRINTER_MNG_NO;
            }
            _currentEditMode = editMode;

            // �V�K���[�h�̏ꍇ�A�����I�Ƀv�����^�Ǘ�No��ݒ�
            if (editMode.Equals(EditMode.New))
            {
                _currentPrinterMngNo = NONE_PRINTER_MNG_NO;
            }
        }

        #endregion // <Constractor>

        #region <������>

        /// <summary>
        /// �v�����^�ݒ�}�X�^�i�T�[�o�p�j���̓t�H�[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void PrtManageForm_Load(object sender, System.EventArgs e)
        {
            Cursor previousCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ��ʂ�������
                InitializeFormControls();
                InitializeFormByMode();
            }
            finally
            {
                Cursor.Current = previousCursor;
            }
        }

        /// <summary>
        /// ��ʂ����������܂��B
        /// </summary>
        private void InitializeFormControls()
        {
            // �v�����^�[����WIN32�̃N�G�����g���Ď擾
            ManagementObjectSearcher mngObjSearcher = new ManagementObjectSearcher("Select * from Win32_Printer");
            ManagementObjectCollection mngObjCollection = mngObjSearcher.Get();

            // �v�����^���R���{�{�b�N�X��������
            this.cboPrinterName.Items.Clear();
            if (mngObjCollection.Count > 0) this.cboPrinterName.Items.Add(string.Empty);
            foreach (ManagementObject mngObj in mngObjCollection)
            {
                // �v�����^���
                PrinterProfileType printerProfile = new PrinterProfileType();
                {
                    printerProfile.Add("Name",      mngObj["Name"]);    // ����
                    printerProfile.Add("Status",    mngObj["Status"]);  // ���
                    printerProfile.Add("PortName",  mngObj["PortName"]);// �|�[�g�ԍ�

                    #region <�Q�l>

                    printerProfile.Add("Caption",       mngObj["Caption"]);     // �L���v�V����
                    printerProfile.Add("Description",   mngObj["Description"]); // �f�B�X�N���v�V����
                    printerProfile.Add("DeviceID",      mngObj["DeviceID"]);    // �h���C�oID
                    printerProfile.Add("DriverName",    mngObj["DriverName"]);  // �h���C�o����
                    printerProfile.Add("Location",      mngObj["Location"]);    // �ꏊ
                    printerProfile.Add("PrinterState",  mngObj["PrinterState"]);// �v�����^���
                    printerProfile.Add("SeverName",     mngObj["ServerName"]);  // �T�[�o�[����
                    printerProfile.Add("ShareName",     mngObj["ShareName"]);   // ���L����
                    printerProfile.Add("StatusInfo",    mngObj["StatusInfo"]);  // ��ԏ��

                    #endregion // </�Q�l>

                    // �v�����^����ێ�
                    PrinterMap.Add((string)mngObj["Name"], printerProfile);

                    this.cboPrinterName.Items.Add((string)mngObj["Name"]);
                }
            }

            #region <�Q�l>
            
            //				// �f�t�H���g�̃v�����^�����ׂ�
            //				if ((((uint) mo["Attributes"]) & 4) == 4)
            //				{
            //					// �R���{��Text�Ƀf�t�H���g�̃v�����^����\��
            //					PrinterName_tComboEditor.Text = mo["Name"].ToString();
            //				}
            
            #endregion // </�Q�l>

            // �v�����^��ʃR���{�{�b�N�X��������
            this.cboPrinterKind.Items.Clear();
            if (this.cboPrinterName.Items.Count > 0)
            {
                foreach (string printerKindName in ServerPrinterSettingDataSet.GetPrinterKindNameList())
                {
                    this.cboPrinterKind.Items.Add(printerKindName);
                }
                this.cboPrinterKind.SelectedIndex = 0;  // �擪��I��
            }

            // �{�^���̈ʒu�𒲐��i[����]�{�^���̉�ʃf�U�C���̈ʒu����v�Z�j
            Point buttonLocation = this.btnClose.Location;
            buttonLocation.X -= this.btnClose.Size.Width;
            this.btnSave.Location = buttonLocation;         // [�ۑ�]�{�^��
            this.btnRevive.Location = buttonLocation;       // [����]�{�^��
            buttonLocation.X -= this.btnClose.Size.Width;
            this.btnDestroy.Location = buttonLocation;      // [���S�폜]�{�^��
        }

        /// <summary>
        /// ���[�h�Ɋ�Â��ĉ�ʂ����������܂��B
        /// </summary>
        private void InitializeFormByMode()
        {
            this.lblEditMode.Text = GetEditModeName(CurrentEditMode);

            // �V�K���[�h
            if (CurrentEditMode.Equals(EditMode.New))
            {
                this.btnSave.Visible    = true; // [�ۑ�]�{�^��
                this.btnClose.Visible   = true; // [����]�{�^��
                this.btnDestroy.Visible = false;// [���S�폜]�{�^��
                this.btnRevive.Visible  = false;// [����]�{�^��

                SetEnabledOfFormControls(true);

                InitialPrtManage = new PrtManage();
                SetFormControls(InitialPrtManage);

                this.txtPrinterMngNo.Focus();   // �v�����^�Ǘ�No
                return;
            }

            // �X�V���[�h�^�폜���[�h
            PrtManage foundPrtManage = MyController.Find(CurrentPrinterMngNo);
            if (foundPrtManage != null)
            {
                InitialPrtManage = foundPrtManage.Clone();
                SetFormControls(InitialPrtManage);
            }
            else
            {
                Debug.Assert(false, "�Y������v�����^�ݒ肪����܂���F" + CurrentPrinterMngNo.ToString());
            }

            // �X�V���[�h
            if (!EntityUtil.Deleted(InitialPrtManage))
            {
                this.btnSave.Visible    = true; // [�ۑ�]�{�^��
                this.btnClose.Visible   = true; // [����]�{�^��
                this.btnDestroy.Visible = false;// [���S�폜]�{�^��
                this.btnRevive.Visible  = false;// [����]�{�^��

                SetEnabledOfFormControls(true);

                // �X�V���[�h�̏ꍇ�́A�v�����^�Ǘ��R�[�h�̂ݓ��͕s�Ƃ���
                this.txtPrinterMngNo.Enabled = false;

                this.cboPrinterName.Focus();    // �v�����^��

                CurrentEditMode = EditMode.Update;
                return;
            }

            // �폜���[�h
            this.lblEditMode.Text = GetEditModeName(EditMode.Delete);

            this.btnSave.Visible    = false;// [�ۑ�]�{�^��
            this.btnClose.Visible   = true; // [����]�{�^��
            this.btnDestroy.Visible = true; // [���S�폜]�{�^��
            this.btnRevive.Visible  = true; // [����]�{�^��

            SetEnabledOfFormControls(false);

            this.btnDestroy.Focus();    // [���S�폜]�{�^��

            CurrentEditMode = EditMode.Delete;
        }

        /// <summary>
        /// ��ʂ̗L���t���O��ݒ肵�܂��B
        /// </summary>
        /// <param name="enabled">�L���t���O</param>
        private void SetEnabledOfFormControls(bool enabled)
        {
            this.txtPrinterMngNo.Enabled= enabled;  // �v�����^�Ǘ�No
            this.cboPrinterName.Enabled = enabled;  // �v�����^��
            this.cboPrinterKind.Enabled = enabled;  // �v�����^���
        }

        #endregion // </������>

        #region <�v�����^�ݒ�f�[�^>

        /// <summary>
        /// ��ʂ̓��͏�񂩂�v�����^�ݒ�f�[�^�𐶐����܂��B
        /// </summary>
        /// <returns>�v�����^�ݒ�f�[�^</returns>
        private PrtManage CreatePrtManageFromFormInput()
        {
            PrtManage prtManage = new PrtManage();
            {
                // ��ƃR�[�h
                prtManage.EnterpriseCode = EnterpriseCode;
                // �v�����^�Ǘ�No
                if (string.IsNullOrEmpty(this.txtPrinterMngNo.Text.Trim()))
                {
                    prtManage.PrinterMngNo = 0;
                }
                else
                {
                    prtManage.PrinterMngNo = int.Parse(this.txtPrinterMngNo.Text.Trim());
                }
                prtManage.PrinterName = this.cboPrinterName.Text.Trim();    //�v�����^��
                prtManage.PrinterPort = this.txtPrinterPort.Text.Trim();    //�v�����^�|�[�g�i�p�X�j
                // �v�����^���
                prtManage.PrinterKind = ServerPrinterSettingDataSet.GetPrinterKind(this.cboPrinterKind.Text);
            }
            return prtManage;
        }

        /// <summary>
        /// �v�����^�ݒ�f�[�^����ʂɐݒ肵�܂��B
        /// </summary>
        /// <param name="prtManage">�v�����^�ݒ�f�[�^</param>
        private void SetFormControls(PrtManage prtManage)
        {
            this.lblGUID.Text = prtManage.FileHeaderGuid.ToString();

            // �v�����^�Ǘ�No
            if (prtManage.PrinterMngNo <= 0)
            {
                this.txtPrinterMngNo.Text = string.Empty;
            }
            else
            {
                this.txtPrinterMngNo.Text = prtManage.PrinterMngNo.ToString();
            }
            this.cboPrinterName.SelectedItem= prtManage.PrinterName;    // �v�����^��
            this.txtPrinterPort.Text        = prtManage.PrinterPort;    // �v�����^�p�X

            // �v�����^���
            this.cboPrinterKind.SelectedItem= ServerPrinterSettingDataSet.GetPrinterKindName(prtManage.PrinterKind);
        }

        #endregion // </�v�����^�ݒ�f�[�^>

        #region <�v�����^�Ǘ�No�̓��͑���>

        /// <summary>
        /// [�v�����^�Ǘ�No]�e�L�X�g�{�b�N�X��Leave�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void txtPrinterMngNo_Leave(object sender, EventArgs e)
        {
            int printerMngNo = EntityUtil.ConvertNaturalNumberIf(this.txtPrinterMngNo.Text);
            if (printerMngNo <= 0)
            {
                Debug.WriteLine("�s���ȃv�����^�Ǘ�No�ł��F" + this.txtPrinterMngNo.Text);
                return;
            }

            // �V�K���[�h���X�V���[�h�^�폜���[�h
            if (!CurrentEditMode.Equals(EditMode.New)) return;

            PrtManage foundPrtManage = MyController.Find(printerMngNo);
            if (foundPrtManage != null)
            {
                CurrentPrinterMngNo = printerMngNo;
                CurrentEditMode = ShowAlertOfChangingMode(foundPrtManage);
                InitializeFormByMode();
            }
        }

        /// <summary>
        /// ���[�h�ύX�̃A���[�g��\�����܂��B
        /// </summary>
        /// <param name="prtManage">�v�����^�ݒ�f�[�^</param>
        /// <returns>�ҏW���[�h</returns>
        private EditMode ShowAlertOfChangingMode(PrtManage prtManage)
        {
            if (EntityUtil.Deleted(prtManage))
            {
                TMsgDisp.Show(
                    this, 					        // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,    // �G���[���x��
                    PG_ID,						    // �A�Z���u���h�c�܂��̓N���XID
                    "���͂��ꂽ�R�[�h�̃v�����^�ݒ���͊��ɍ폜����Ă��܂��B",   // LITERAL:�\�����郁�b�Z�[�W
                    0, 								// �X�e�[�^�X�l
                    MessageBoxButtons.OK            // �\������{�^��
                );
                return EditMode.Delete;
            }

            DialogResult result = TMsgDisp.Show(
                this,                           // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_INFO,    // �G���[���x��
                PG_ID,                          // �A�Z���u��ID�܂��̓N���XID
                "���͂��ꂽ�R�[�h�̃v�����^�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // LITERAL:�\�����郁�b�Z�[�W
                0,                              // �X�e�[�^�X�l
                MessageBoxButtons.YesNo // �\������{�^��
            );
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        return EditMode.Update;
                    }
                case DialogResult.No:
                    {
                        CurrentPrinterMngNo = NONE_PRINTER_MNG_NO;
                        return EditMode.New;
                    }
            }

            return CurrentEditMode;
        }

        #endregion // </�v�����^�Ǘ�No�̓��͑���>

        #region <�v�����^���̓��͑���>

        /// <summary>
        /// �v�����^���R���{�{�b�N�X��ValueChanged�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// �v�����^����I���������A�v�����^�|�[�g��\�����܂��B
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void cboPrinterName_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cboPrinterName.Text)) return;

            if (PrinterMap.ContainsKey(this.cboPrinterName.Text))
            {
                PrinterProfileType printerProfile = PrinterMap[this.cboPrinterName.Text];
                {
                    this.txtPrinterPort.Text = (string)printerProfile["PortName"];
                }
            }
        }

        #endregion // </�v�����^���̓��͑���>

        #region <���鑀��>

        /// <summary>
        /// [����]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            // �ҏW���Ȃ�o�^�m�F��\��
            Control nextControl = null;
            Control nowFocusd = this.ActiveControl;
            if (!CanClose(out nextControl))
            {
                if (nextControl == null)
                {
                    nowFocusd.Focus();
                }
                else
                {
                    nextControl.Focus();
                }
                return;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// �I���\�����f���܂��B
        /// </summary>
        /// <remarks>
        /// �ҏW���Ȃ�o�^�m�F���s���܂��B
        /// </remarks>
        /// <param name="nextControl">�o�^�`�F�b�NNG���̃t�H�[�J�X�ړ���</param>
        /// <returns>
        /// <c>true</c> :�I����<br/>
        /// <c>false</c>:�I���s��
        /// </returns>
        private bool CanClose(out Control nextControl)
        {
            nextControl = null;

            // ���͏�Ԃ��擾
            PrtManage inputedPrtManage = CreatePrtManageFromFormInput();

            // ���͏�Ԃ�������ԂƔ�r
            if (!IsSameInput(InitialPrtManage, inputedPrtManage))
            {
                // �ҏW��
                switch (TMsgDisp.Show(
                    Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_QUESTION,
                    PG_ID,
                    "�ҏW���̃f�[�^�����݂��܂�\r\n\r\n�o�^���Ă���낵���ł����H",
                    0,
                    MessageBoxButtons.YesNo
                ))
                {
                    case DialogResult.Yes:
                        return RegistData(out nextControl); // �o�^����
                    default:
                        return true;    // ����
                }
            }
            return true;
        }

        /// <summary>
        /// �������̓f�[�^�ł��邩���f���܂��B
        /// </summary>
        /// <param name="prtManage1">�v�����^�ݒ�f�[�^1</param>
        /// <param name="prtManage2">�v�����^�ݒ�f�[�^2</param>
        /// <returns>
        /// <c>true</c> :�������̓f�[�^�ł��B<br/>
        /// <c>false</c>:�������̓f�[�^�ł͂���܂���B
        /// </returns>
        private static bool IsSameInput(
            PrtManage prtManage1,
            PrtManage prtManage2
        )
        {
            #region <Guard Phrase>

            if (prtManage1 == null && prtManage2 == null)
            {
                return true;
            }

            if (!(prtManage1 != null && prtManage2 != null))
            {
                return false;
            }

            #endregion // </Guard Phrase>

            // �v�����^�Ǘ�No
            if (!prtManage1.PrinterMngNo.Equals(prtManage2.PrinterMngNo))
            {
                return false;
            }
            // �v�����^��
            if (!prtManage1.PrinterName.Trim().Equals(prtManage2.PrinterName.Trim()))
            {
                return false;
            }
            // �v�����^���
            if (!prtManage1.PrinterKind.Equals(prtManage2.PrinterKind))
            {
                return false;
            }
            return true;
        }

        #endregion // </���鑀��>

        #region <�ۑ�����>

        /// <summary>
        /// [�ۑ�]�{�^����Click�C�x���g�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Control errorControl = null;
            if (!RegistData(out errorControl))
            {
                if (errorControl != null) errorControl.Focus();
                return;
            }

            // �V�K�o�^���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if (CurrentEditMode.Equals(EditMode.New))
            {
                CurrentPrinterMngNo = NONE_PRINTER_MNG_NO;
                InitializeFormByMode();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// �v�����^�ݒ�f�[�^��o�^���܂��B
        /// </summary>
        /// <param name="errorControl">�s���ȓ��͂����R���g���[�� ��������΁A<c>null</c>��Ԃ��܂��B</param>
        /// <returns>
        /// <c>true</c> :�o�^�ɐ���<br/>
        /// <c>false</c>:�o�^�Ɏ��s
        /// </returns>
        private bool RegistData(out Control errorControl)
        {
            errorControl = null;

            // ���̓`�F�b�N
            string message = string.Empty;
            if (!ValidatesInputData(ref errorControl, out message))
            {
                TMsgDisp.Show(
                    Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PG_ID,
                    message,
                    0,
                    MessageBoxButtons.OK
                );
                return false;
            }

            PrtManage writingPrtManage = GetDoingPrtManage();

            MyController.DoingRecord = writingPrtManage;
            MyController.WriteRecord();

            int status = MyController.DoneStatus;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        return true;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
                            PG_ID,
                            "���̃v�����^�Ǘ��R�[�h�͊��Ɏg�p����Ă��܂��B",
                            status,
                            MessageBoxButtons.OK
                        );
                        errorControl = this.txtPrinterMngNo;
                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,
                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PG_ID,
                            "�v�����^�Ǘ����ݒ�",
                            "RegistData",
                            TMsgDisp.OPE_UPDATE,
                            "�ǂݍ��݂Ɏ��s���܂����B",
                            status,
                            "SFCMN09202A",
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1
                        );
                        this.Close();
                        return false;
                    }
            }
        }

        /// <summary>
        /// ��������v�����^�ݒ�f�[�^���擾���܂��B
        /// </summary>
        /// <returns>
        /// �V�K���[�h�̏ꍇ�A�V���ɐ��������f�[�^�ɉ�ʓ��̓f�[�^�𔽉f��������<br/>
        /// ����ȊO�́A�����̃f�[�^�ɉ�ʓ��̓f�[�^�𔽉f��������
        /// </returns>
        private PrtManage GetDoingPrtManage()
        {
            PrtManage writingPrtManage = null;
            {
                PrtManage inputedPrtManage = CreatePrtManageFromFormInput();
                if (CurrentEditMode.Equals(EditMode.New))
                {
                    writingPrtManage = inputedPrtManage;
                }
                else
                {
                    writingPrtManage = MyController.Find(CurrentPrinterMngNo);
                    if (writingPrtManage != null)
                    {
                        writingPrtManage.PrinterMngNo= inputedPrtManage.PrinterMngNo;
                        writingPrtManage.PrinterName = inputedPrtManage.PrinterName;
                        writingPrtManage.PrinterPort = inputedPrtManage.PrinterPort;
                        writingPrtManage.PrinterKind = inputedPrtManage.PrinterKind;
                    }
                    else
                    {
                        Debug.Assert(false, "DB�ɑ��݂��Ȃ��H");
                    }
                }
            }
            return writingPrtManage;
        }

        /// <summary>
        /// ��ʓ��̓f�[�^�������������f���܂��B
        /// </summary>
        /// <param name="errorControl">�s���ΏۃR���g���[��</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>
        /// <c>true</c> :������<br/>
        /// <c>false</c>:�������Ȃ�
        /// </returns>
        private bool ValidatesInputData(
            ref Control errorControl,
            out string errorMessage
        )
        {
            errorMessage = string.Empty;

            // �v�����^�Ǘ�No
            int printerMngNo = EntityUtil.ConvertNaturalNumberIf(this.txtPrinterMngNo.Text);
            if (printerMngNo <= 0)
            {
                errorControl = this.txtPrinterMngNo;
                errorMessage = this.lblPrinterMngNo.Text + "�� 1�ȏ� �̒l����͂��ĉ������B";
                return false;
            }

            PrtManage foundPrtManage = MyController.Find(printerMngNo);
            if (foundPrtManage != null)
            {
                if (CurrentEditMode.Equals(EditMode.New))
                {
                    errorControl = this.txtPrinterMngNo;
                    errorMessage = "���̃v�����^�Ǘ��R�[�h�͊��Ɏg�p����Ă��܂��B";
                    return false;
                }
            }

            // �v�����^��
            if (string.IsNullOrEmpty(this.cboPrinterName.Text))
            {
                errorControl = this.cboPrinterName;
                errorMessage = this.lblPrinterName.Text + "����͂��ĉ������B";
                return false;
            }

            // �v�����^���
            if (string.IsNullOrEmpty(this.cboPrinterKind.Text.Trim()))
            {
                errorControl = this.cboPrinterKind;
                errorMessage = this.lblPrinterKind.Text + "����͂��ĉ������B";
                return false;
            }

            // �d���`�F�b�N
            int foundPrinterMngNo = 0;
            if (MyController.Exists(this.cboPrinterName.Text.Trim(), out foundPrinterMngNo))
            {
                // ���g�̏��łȂ���΃G���[
                if (!foundPrinterMngNo.Equals(printerMngNo))
                {
                    errorControl = this.cboPrinterName;
                    errorMessage = "�����v�����^�͓o�^�ł��܂���";
                    return false;
                }
            }

            return true;
        }

        #endregion // </�ۑ�����>

        #region <��������>

        /// <summary>
        /// [����]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnRevive_Click(object sender, EventArgs e)
        {
            PrtManage revivingPrtManage = GetDoingPrtManage();

            MyController.DoingRecord = revivingPrtManage;
            MyController.ReviveRecord();

            int status = MyController.DoneStatus;
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this,
                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PG_ID,
                            "�v�����^�Ǘ����ݒ�",
                            "Revive_Button_Click",
                            TMsgDisp.OPE_UPDATE,
                            "���Ƀf�[�^�����S�폜����Ă��܂��B",
                            status,
                            "SFCMN09202A",
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1
                        );
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,
                            Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                            PG_ID,
                            "�v�����^�Ǘ����ݒ�",
                            "Revive_Button_Click",
                            TMsgDisp.OPE_UPDATE,
                            "�����Ɏ��s���܂����B",
                            status,
                            "SFCMN09202A",
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1
                        );
                        this.Close();
                        break;
                    }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion // </��������>

        #region <���S�폜����>

        /// <summary>
        /// [���S�폜]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnDestroy_Click(object sender, EventArgs e)
        {
            DialogResult result = TMsgDisp.Show(
                Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                PG_ID,
                "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",
                0,
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2
            );
            if (result.Equals(DialogResult.OK))
            {
                PrtManage destroyingPrtManage = GetDoingPrtManage();

                MyController.DoingRecord = destroyingPrtManage;
                MyController.DestroyRecord();

                int status = MyController.DoneStatus;
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,
                                Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                                PG_ID,
                                "�v�����^�Ǘ����ݒ�",
                                "Delete_Button_Click",
                                TMsgDisp.OPE_DELETE,
                                "�폜�Ɏ��s���܂����B",
                                status,
                                "SFCMN09202A",
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1
                            );
                            this.Close();
                            return;
                        }
                }
            }
            else
            {
                btnDestroy.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion // </���S�폜����>

        #region <�Q�l�F�_���폜>

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <remarks>
        /// �I�𒆂̃f�[�^���폜���܂��B
        /// </remarks>
        /// <returns>�X�e�[�^�X</returns>
        private int Delete()
        {
            PrtManage prtManage = GetDoingPrtManage();

            MyController.DoingRecord = prtManage;
            MyController.DeleteRecord();

            int status = MyController.DoneStatus;
            if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                TMsgDisp.Show(
                    this,
                    Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
                    PG_ID,
                    "�v�����^�Ǘ����ݒ�",
                    "Delete",
                    TMsgDisp.OPE_DELETE,
                    "�폜�Ɏ��s���܂����B",
                    status,
                    "SFCMN09202A",
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1
                );
                this.Close();

                return status;
            }

            #region <�{�c>

            //status = PrtManageAccesser.Read(prtManage.EnterpriseCode, prtManage.PrinterMngNo, out prtManage);
            //if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            //{
            //    if (ExclusiveControl(status) == false)
            //    {
            //        return status;
            //    }
            //    TMsgDisp.Show(
            //        this,
            //        Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
            //        PG_ID,
            //        "�v�����^�Ǘ����ݒ�",
            //        "Delete",
            //        TMsgDisp.OPE_DELETE,
            //        "�ǂݍ��݂Ɏ��s���܂����B",
            //        status,
            //        "SFCMN09202A",
            //        MessageBoxButtons.OK,
            //        MessageBoxDefaultButton.Button1
            //    );
            //    this.Close();

            //    return status;
            //}

            #endregion // </�{�c>

            return status;
        }

        #endregion // </�Q�l�F�_���폜>
    }
}