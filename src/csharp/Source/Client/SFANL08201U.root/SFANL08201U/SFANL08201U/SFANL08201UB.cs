using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �o�^�p�_�C�A���O�N���X
    /// </summary>
	public partial class MaintenanceDlg: GridFormBase
	{
        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        #region delegate
        /// <summary>
        /// ���R���[�O���[�v�ǉ��ۑ��f���Q�[�g
        /// </summary>
        /// <param name="freePprGrp">���R���[�O���[�v</param>
        /// <returns>�X�e�[�^�X</returns>
        public delegate bool SaveNewGroupDelegate(FreePprGrp freePprGrp);

        /// <summary>
        /// ���R���[�O���[�v�U�֒ǉ��ۑ��f���Q�[�g
        /// </summary>
        /// <param name="frePprGrTr">���R���[�O���[�v�U��</param>
        /// <returns>�X�e�[�^�X</returns>
        public delegate bool SaveNewFrePprDelegate(FrePprGrTr frePprGrTr);
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
		public MaintenanceDlg()
		{
			InitializeComponent();
            // �f�[�^�Z�b�g�쐬
            DataSetColumnConstruction();
            // ��ʏ����ݒ�
            InitialScreenSetting();
        }
        #endregion

        // ===================================================================================== //
        // �p�u���b�N�ϐ�
        // ===================================================================================== //
        #region public member
        /// <summary>SaveNewGroup</summary>
        public SaveNewGroupDelegate SaveNewGroup;      // �O���[�v�̕ۑ��{�^�����������ꂽ�Ƃ��̃f���Q�[�g
        /// <summary>SaveNewFrePpr</summary>
        public SaveNewFrePprDelegate SaveNewFrePpr;    // ���ׂ̕ۑ��{�^�����������ꂽ�Ƃ��̃f���Q�[�g
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region private member
        private int _dialogMode = 0;           // 0:���R���[�O���[�v�@1�F���R���[�O���[�v�U��
        private FreePprGrpAcs _freePprGrpAcs = new FreePprGrpAcs();
        private int _groupCode = 0;            // �v���p�e�B�p
        private DateTime _updateTime = DateTime.MinValue;          // �X�V���t�ێ��p
        private DateTime _createTime = DateTime.MinValue;          // �쐬���t�ێ��p
        private Guid _guid = Guid.Empty;                           // FileHeaderGUID�ێ��p
        private DataTable _frePprSelectDT;                         // ���[�I���Ɏg�p����Grid�p
        private bool _canClose = false;                           // ��ʃN���[�Y�����̐ݒ�
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region private constant
        //const string PGID = "MaintenanceDlg";
        const string INS_MODE = "�V�K���[�h";
        const string UPD_MODE = "�X�V���[�h";
        const int CT_GROUPMODE = 0;
        const int CT_TRANCEMODE = 1;
        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region Prorerties
        /// <summary>
        /// �O���[�v�R�[�h
        /// </summary>
        public int GroupCode
        {
            get { return _groupCode; }
            set
            {
                _groupCode = value;
                this.GroupCd_tNedit.SetInt(value); 
            }
        }

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�����̐ݒ���擾�܂��͐ݒ肵�܂�</value>
        public bool CanClose
        {
            get { return this._canClose; }
            set { this._canClose = value; }
        }
        #endregion

        // ===================================================================================== //
        // �p�u���b�N�֐�
        // ===================================================================================== //
        #region private methods
 
        #region ��ʍč\�z����
        /// <summary>
        /// ��ʕ\��(���R���[�O���[�v���[�h)�V�K
        /// </summary>
        public void ShowGroupDlg()
        {
            //��ʃN���A
            ScreenClear();
            //�V�K���[�h
            Mode_Label1.Text = INS_MODE;
            GroupCd_tNedit.Enabled = true;
            GroupCd_tNedit.Text = string.Empty;

            //�_�C�A���O���[�h��(�O���[�v���[�h��)�ύX
            _dialogMode = CT_GROUPMODE;
            groupAdd_panel.Visible = true;
            TranceAdd_Panel.Visible = false;
        
            // �p�l����\������
            groupAdd_panel.Location = new Point(0, 0);
            groupAdd_panel.Visible = true;

            // �E�B���h�E�T�C�Y���O���[�v�p�l���ɂ��킹��
            int beforeClientWidth = this.ClientSize.Width;
            int beforeClientHeight = this.ClientSize.Height;
            int afterClientWidth = groupAdd_panel.Size.Width;
            int afterClientHeight = groupAdd_panel.Size.Height;
            this.ClientSize = new Size(afterClientWidth, afterClientHeight);

            // �E�B���h�E�T�C�Y�̕ύX�ɂ��킹�č��W��␳����
            int newX = this.Location.X - ((afterClientWidth - beforeClientWidth) / 2);
            int newY = this.Location.Y - ((afterClientHeight - beforeClientHeight) / 2);

            this.Text = "���R���[�O���[�v�ݒ�";
            this.TopLevel = true;
            this.Show();
        }

        /// <summary>
        /// ��ʕ\��(���R���[�O���[�v�U�փ��[�h)�V�K
        /// </summary>
        public void ShowTranceDlg()
        {
            //�S�O���[�v�Ȃ�L�����Z��
            if (GroupCode == 0)
            {
                TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_INFO,        // �G���[���x��
                "MaintenanceDlg", 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "�S�O���[�v�ɂ͒ǉ��ł��܂���",     // �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);   // �\������{�^��
                return;
            }

            //��ʃN���A
            ScreenClear();
            //�V�K���[�h
            Mode_Label2.Text = INS_MODE;
            ultraLabel2.Visible = true;

            //�_�C�A���O���[�h��(�U�փ��[�h��)�ύX
            _dialogMode = CT_TRANCEMODE;
            groupAdd_panel.Visible = false;
            TranceAdd_Panel.Visible = true;

            // �p�l����\������
            TranceAdd_Panel.Location = new Point(0, 0);
            TranceAdd_Panel.Visible = true;

            // �E�B���h�E�T�C�Y���O���[�v�p�l���ɂ��킹��
            int beforeClientWidth = this.ClientSize.Width;
            int beforeClientHeight = this.ClientSize.Height;
            int afterClientWidth = TranceAdd_Panel.Size.Width;
            int afterClientHeight = TranceAdd_Panel.Size.Height;
            this.ClientSize = new Size(afterClientWidth, afterClientHeight);

            // �E�B���h�E�T�C�Y�̕ύX�ɂ��킹�č��W��␳����
            int newX = this.Location.X - ((afterClientWidth - beforeClientWidth) / 2);
            int newY = this.Location.Y - ((afterClientHeight - beforeClientHeight) / 2);


            //-- �R���{�{�b�N�X�ݒ� -----------------------------
            ArrayList freePprGrpAL = new ArrayList();
            
            //�O���[�v���擾
            _freePprGrpAcs.SearchStaticMemoryFreePprGrp(out freePprGrpAL, LoginInfoAcquisition.EnterpriseCode);
            foreach (FreePprGrp freePprGrp in freePprGrpAL)
            {
                //�S�O���[�v�͂̂���
                if (freePprGrp.FreePrtPprGroupCd == 0)
                    continue;
                //�R���{�{�b�N�X�ɒǉ�                
                //�I������Ă����O���[�v��W���őI������
                if (freePprGrp.FreePrtPprGroupCd == GroupCode)
                {
                    Group_tComboEditor.Items.Add(freePprGrp.FreePrtPprGroupCd, freePprGrp.FreePrtPprGroupNm);
                    Group_tComboEditor.SelectedIndex = 0;
                }
            }

            // ���[�I���O���b�h���t�B���^�����O 
            _frePprSelectDT.DefaultView.RowFilter = string.Empty;
            FrePprSelect_Grid.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.FireInitializeRow);

            this.Text = "���R���[�ݒ�";
            this.Show();
        }

        /// <summary>
        /// ��ʕ\��(���R���[�O���[�v���[�h)�X�V
        /// </summary>
        public void ShowGroupDlg(int frePprGrpCd, string frePprGrpNm, DateTime updateTime, DateTime createTime,Guid guid)
        {
            //��ʃN���A
            ScreenClear();
            //�X�V���[�h
            Mode_Label1.Text = UPD_MODE;
            GroupCd_tNedit.Enabled = false;

            //�_�C�A���O���[�h��(�O���[�v���[�h��)�ύX
            _dialogMode = CT_GROUPMODE;
            groupAdd_panel.Visible = true;
            TranceAdd_Panel.Visible = false;

            // �p�l����\������
            groupAdd_panel.Location = new Point(0, 0);
            groupAdd_panel.Visible = true;

            // �E�B���h�E�T�C�Y���O���[�v�p�l���ɂ��킹��
            int beforeClientWidth = this.ClientSize.Width;
            int beforeClientHeight = this.ClientSize.Height;
            int afterClientWidth = groupAdd_panel.Size.Width;
            int afterClientHeight = groupAdd_panel.Size.Height;
            this.ClientSize = new Size(afterClientWidth, afterClientHeight);

            // �E�B���h�E�T�C�Y�̕ύX�ɂ��킹�č��W��␳����
            int newX = this.Location.X - ((afterClientWidth - beforeClientWidth) / 2);
            int newY = this.Location.Y - ((afterClientHeight - beforeClientHeight) / 2);

            this.Text = "���R���[�O���[�v�ݒ�";
            GroupCd_tNedit.SetValue(frePprGrpCd);
            GroupNm_tEdit.Text = frePprGrpNm;
            _updateTime = updateTime;
            _createTime = createTime;
            _guid = guid;
            this.Show();
        }

        /// <summary>
        /// ��ʕ\��(���R���[�O���[�v�U�փ��[�h)�X�V
        /// </summary>
        public void ShowTranceDlg(int frePprGrpCd, int frePprGrTrCd, int oderNo, string outputFormFileName, int userPrtPprIdDerivNo, DateTime updateTime, DateTime createTime,Guid guid)
        {
            //��ʃN���A
            ScreenClear();
            //�X�V���[�h
            Mode_Label2.Text = UPD_MODE;
            ultraLabel2.Visible = false;

            //�_�C�A���O���[�h��(�U�փ��[�h��)�ύX
            _dialogMode = CT_TRANCEMODE;
            groupAdd_panel.Visible = false;
            TranceAdd_Panel.Visible = true;

            // �p�l����\������
            TranceAdd_Panel.Location = new Point(0, 0);
            TranceAdd_Panel.Visible = true;

            // �E�B���h�E�T�C�Y���O���[�v�p�l���ɂ��킹��
            int beforeClientWidth = this.ClientSize.Width;
            int beforeClientHeight = this.ClientSize.Height;
            int afterClientWidth = TranceAdd_Panel.Size.Width;
            int afterClientHeight = TranceAdd_Panel.Size.Height;
            this.ClientSize = new Size(afterClientWidth, afterClientHeight);

            // �E�B���h�E�T�C�Y�̕ύX�ɂ��킹�č��W��␳����
            int newX = this.Location.X - ((afterClientWidth - beforeClientWidth) / 2);
            int newY = this.Location.Y - ((afterClientHeight - beforeClientHeight) / 2);

            //-- �R���{�{�b�N�X�ݒ� -----------------------------
            ArrayList freePprGrpAL = new ArrayList();

            //�O���[�v���擾
            _freePprGrpAcs.SearchStaticMemoryFreePprGrp(out freePprGrpAL, LoginInfoAcquisition.EnterpriseCode);
            foreach (FreePprGrp freePprGrp in freePprGrpAL)
            {

                //�I������Ă����O���[�v��W���őI������
                if (freePprGrp.FreePrtPprGroupCd == frePprGrpCd)
                {
                    Group_tComboEditor.Items.Add(freePprGrp.FreePrtPprGroupCd, freePprGrp.FreePrtPprGroupNm);
                    Group_tComboEditor.SelectedIndex = 0;
                }
            }

            //�X�V�����o��
            FrrPptDispOrderCd_tNedit.SetValue(oderNo);
            FrrPptDispOrderCd_tNedit.Tag = frePprGrTrCd;
            FrePrtPSet wk = new FrePrtPSet();
            wk.OutputFormFileName = outputFormFileName;
            wk.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;

            // ���[�I���O���b�h���t�B���^�����O 
            _frePprSelectDT.DefaultView.RowFilter = CT_FREE_PPR_OFrmFilNm + " = '" + outputFormFileName + "' AND " + CT_FREE_PPR_DerivNo + "=" + userPrtPprIdDerivNo.ToString();
            
            _updateTime = updateTime;
            _createTime = createTime;
            _guid = guid;
            
            this.Text = "���R���[�ݒ�";
            this.Show();
        }
        #endregion

        #endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private methods 

        #region ��ʏ����ݒ�
        /// <summary>
        /// ��ʏ����ݒ�
        /// </summary>
        private void InitialScreenSetting()
        {
            //�A�C�R���̐ݒ�
            ImageList imageList24 = IconResourceManagement.ImageList24;
            // �ۑ��{�^��
            this.GrOk_Button.ImageList = imageList24;
            this.GrOk_Button.Appearance.Image = Size24_Index.SAVE;
            this.TrOk_Button.ImageList = imageList24;
            this.TrOk_Button.Appearance.Image = Size24_Index.SAVE;

            // �ۑ��{�^��
            this.GrCancel_Button.ImageList = imageList24;
            this.GrCancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.TrCancel_Button.ImageList = imageList24;
            this.TrCancel_Button.Appearance.Image = Size24_Index.CLOSE;

            //�^�X�N�o�[�ɕ\�����Ȃ�
            this.ShowInTaskbar = false;

            //�O���b�h�̐ݒ�
            FrePprSelect_Grid.DataSource = _frePprSelectDT;
            _frePprSelectDT.DefaultView.Sort = CT_FREE_PPR_DerivNo;
            setGridAppearance(FrePprSelect_Grid);        // �z�F�ݒ�
            setGridBehavior(FrePprSelect_Grid);          // ����ݒ�
            SetGridColAppearance();                      // �\���ݒ�
        }
        #endregion

        #region DataSet�\�z����
        private void DataSetColumnConstruction()
        {
            //-- ���R���[�O���[�v -------------------------------------
            _frePprSelectDT = new DataTable(CT_FREE_PPR_SLCT);
            //// GUID
            //_frePprSelectDT.Columns.Add(CT_FREE_PPR_GUID, typeof(Guid));
            //// �X�V���t
            //_frePprSelectDT.Columns.Add(CT_FREE_PPR_UPDT, typeof(DateTime));
            //// �쐬���t
            //_frePprSelectDT.Columns.Add(CT_FREE_PPR_CRDT, typeof(DateTime));    
            //�o�͖���
            _frePprSelectDT.Columns.Add(CT_FREE_PPR_PrtNm, typeof(string));
            //�R�����g
            _frePprSelectDT.Columns.Add(CT_FREE_PPR_USRComment, typeof(string));
            //�o�̓t�@�C����
            _frePprSelectDT.Columns.Add(CT_FREE_PPR_OFrmFilNm, typeof(string));
            //���[�U�[���[ID�}�ԍ� 
            _frePprSelectDT.Columns.Add(CT_FREE_PPR_DerivNo, typeof(Int32));
        }
        #endregion

        #region ���[�I���O���b�h�f�[�^�쐬����
        private void SetSelectPprInfo()
        {
            //�󎚈ʒu�ݒ�̃L���b�V�����擾
            List<FrePrtPSet> frePprPSetLs = null;
            int sts = SFANL08201UA.GetFrePrtPSetLsCash(ref frePprPSetLs);
            int index = 0;

            //�f�[�^�N���A
            _frePprSelectDT.Rows.Clear();

            //�l���Z�b�g����
            if (sts != 0) return;
            foreach (FrePrtPSet frePprPSet in frePprPSetLs)
            {
                DataRow dataRow = _frePprSelectDT.NewRow();
                dataRow[CT_FREE_PPR_OFrmFilNm]  = frePprPSet.OutputFormFileName;
                dataRow[CT_FREE_PPR_DerivNo]    = frePprPSet.UserPrtPprIdDerivNo;
                dataRow[CT_FREE_PPR_PrtNm]      = frePprPSet.DisplayName;
                dataRow[CT_FREE_PPR_USRComment] = frePprPSet.PrtPprUserDerivNoCmt;
                _frePprSelectDT.Rows.Add(dataRow);
                index++;
            }
            if (FrePprSelect_Grid.Rows.FilteredInRowCount > 0)
            {
                FrePprSelect_Grid.Rows[0].Activate();
            }
        }
        #endregion

        #region �O���b�h��T�ϐݒ�
        private void SetGridColAppearance()
        {
            // �\���ݒ�
            FrePprSelect_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_OFrmFilNm].Hidden = true;
            FrePprSelect_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_DerivNo].Hidden = true;
            FrePprSelect_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_PrtNm].Hidden = false;
            FrePprSelect_Grid.DisplayLayout.Bands[0].Columns[CT_FREE_PPR_USRComment].Hidden = false;
        }
        #endregion

        #region ��ʃN���A����
        private void ScreenClear()
        {
            if(_frePprSelectDT.Rows.Count == 0)
                SetSelectPprInfo();                          // �O���b�h�Ƀf�[�^�ݒ�
            GroupCd_tNedit.SetInt(0);
            GroupNm_tEdit.Text = "";
            FrrPptDispOrderCd_tNedit.SetInt(0);
            FrrPptDispOrderCd_tNedit.Tag = null;
            Group_tComboEditor.Items.Clear();
            _updateTime = DateTime.MinValue;
            _createTime = DateTime.MinValue;
            _guid = Guid.Empty;
            if (FrePprSelect_Grid.Rows.FilteredInRowCount > 0)
                FrePprSelect_Grid.Rows[0].Activate();
        }
        #endregion

        #region ���̓`�F�b�N����
        /// <summary>
        /// ��ʓ��̓`�F�b�N
        /// </summary>
        /// <param name="control">�`�F�b�NNG���̃t�H�[�J�X�ړ���</param>
        /// <param name="message">�`�F�b�NNG���̃��b�Z�[�W</param>
        /// <returns>ture:OK false:�s�����͂���</returns>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            if (_dialogMode == CT_TRANCEMODE)
            {
                // �\�����ʃR�[�h
                if (this.FrrPptDispOrderCd_tNedit.GetInt() <= 0)
                {
                    control = this.FrrPptDispOrderCd_tNedit;
                    message = this.FrrPptDispOrderCd_Title.Text + "����͂��Ă�������";
                    return false;
                }
                // �U�֖���
                if ((this.FrePprSelect_Grid.ActiveRow == null) || (this.FrePprSelect_Grid.ActiveRow.Index < 0))
                {
                    control = this.FrePprSelect_Grid;
                    message = this.FrePpr_Title.Text + "����͂��Ă�������";
                    return false;
                }
            }
            else if (_dialogMode == CT_GROUPMODE)
            {
                // �O���[�v�R�[�h
                if (this.GroupCd_tNedit.GetInt() <= 0)
                {
                    control = this.GroupCd_tNedit;
                    message = this.GroupCd_Title.Text + "����͂��Ă�������";
                    return false;
                }
                // �O���[�v����

                if (this.GroupNm_tEdit.Text.TrimEnd(new char[]{' ','�@'}) == "")
                {
                    control = this.GroupNm_tEdit;
                    message = this.GroupNm_Title.Text + "����͂��Ă�������";
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region ���R���[�O���[�v�o�^����
        private bool RegistGroupData()
        {
            // ���̓`�F�b�N
            string message = "";
            Control control = null;

            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PGID, message, 0, MessageBoxButtons.OK);
                control.Focus();
                if (control is TEdit) ((TEdit)control).SelectAll();
                return false;
            }

            FreePprGrp frePprGr = new FreePprGrp();
            DispToFreePprGrp(ref frePprGr);

            // ���̃f���Q�[�g�����s�����A�N���X���g���ēo�^���ʂ�OK�Ȃ�UI�X�V
            return SaveNewGroup(frePprGr);     //�ۑ��{�^�������f���Q�[�g�ďo��
        }
        #endregion

        #region ���R���[�U�֏��o�^����
        private bool RegistTranceData()
        {
            // ���̓`�F�b�N
            string message = "";
            Control control = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PGID, message, 0, MessageBoxButtons.OK);
                control.Focus();
                if (control is TEdit) ((TEdit)control).SelectAll();
                return false;
            }

            FrePprGrTr frePprGrTr = null;
            DispToFreePprGrTr(ref frePprGrTr);

            //������A�N���X���g���ēo�^���ʂ�OK�Ȃ�UI�X�V
            return SaveNewFrePpr(frePprGrTr);      // �ۑ��{�^�������f���Q�[�g�����ďo��
        }
        #endregion

        #region ��ʁ@���@���R���[�O���[�v
        /// <summary>
        /// ��ʓ��͏�񎩗R���[�O���[�v�N���X�i�[
        /// </summary>
        /// <param name="frePprGrp">���R���[�O���[�v�N���X</param>
        private void DispToFreePprGrp(ref FreePprGrp frePprGrp)
        {
            if (frePprGrp == null)
            {
                // �V�K�̏ꍇ
                frePprGrp = new FreePprGrp();
            }

            frePprGrp.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            frePprGrp.FreePrtPprGroupCd = GroupCd_tNedit.GetInt();
            frePprGrp.FreePrtPprGroupNm = GroupNm_tEdit.Text;
            if (_updateTime != DateTime.MinValue)
                frePprGrp.UpdateDateTime = _updateTime;
            if (_createTime != DateTime.MinValue)
                frePprGrp.CreateDateTime = _createTime;
            if (_guid != Guid.Empty)
                frePprGrp.FileHeaderGuid = _guid;
        }
        #endregion

        #region ��ʁ@���@���R���[�O���[�v�U��
        /// <summary>
        /// ��ʓ��͏�񎩗R���[�O���[�v�U�փN���X�i�[
        /// </summary>
        /// <param name="frePprGrTr">���R���[�O���[�v�N���X</param>
        private void DispToFreePprGrTr(ref FrePprGrTr frePprGrTr)
        {
            if (frePprGrTr == null)
            {
                // �V�K�̏ꍇ
                frePprGrTr = new FrePprGrTr();
            }
            frePprGrTr.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            frePprGrTr.FreePrtPprGroupCd = (Int32)Group_tComboEditor.SelectedItem.DataValue;
            frePprGrTr.DisplayOrder = FrrPptDispOrderCd_tNedit.GetInt();
            
            frePprGrTr.DisplayName = (string)_frePprSelectDT.Rows[FrePprSelect_Grid.ActiveRow.Index][CT_FREE_PPR_PrtNm];
            frePprGrTr.OutputFormFileName = (string)_frePprSelectDT.Rows[FrePprSelect_Grid.ActiveRow.Index][CT_FREE_PPR_OFrmFilNm];
            frePprGrTr.UserPrtPprIdDerivNo = (int)_frePprSelectDT.Rows[FrePprSelect_Grid.ActiveRow.Index][CT_FREE_PPR_DerivNo];

            frePprGrTr.DisplayName = (string)FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_PrtNm].Value;
            frePprGrTr.OutputFormFileName = (string)FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_OFrmFilNm].Value;
            frePprGrTr.UserPrtPprIdDerivNo = (int)FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_DerivNo].Value;


            if (FrrPptDispOrderCd_tNedit.Tag != null)
                frePprGrTr.TransferCode = (int)(FrrPptDispOrderCd_tNedit.Tag);
            if (_updateTime != DateTime.MinValue)
                frePprGrTr.UpdateDateTime = _updateTime;
            if (_createTime != DateTime.MinValue)
                frePprGrTr.CreateDateTime = _createTime;
            if (_guid != Guid.Empty)
                frePprGrTr.FileHeaderGuid = _guid;
        }
        #endregion

        #region ��ʏI������
        /// <summary>
        /// �R���g���[���̕`����~�߂ĉ�ʂ��B���܂�(������h�~)
        /// </summary>
        private void SuspendLayoutHide()
        {
            this.SuspendLayout();
            this.Visible = false;
            this.ResumeLayout();
        }
        #endregion

        #endregion

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        #region Control Event

        /// <summary>
        /// Row�����������ꂽ�Ƃ��ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            string outputFormFileNm = Convert.ToString(e.Row.Cells[CT_FREE_PPR_OFrmFilNm].Text);
            int userDerivNo = Convert.ToInt32(e.Row.Cells[CT_FREE_PPR_DerivNo].Value);
            
            //�󎚈ʒu�ݒ�̃L���b�V�����擾
            FrePprGrTr frePprGrTr = SFANL08201UA.GetFrePprGrTrCash(_groupCode, outputFormFileNm, userDerivNo);
            
            // ���ɑ��݂��Ă��邩
            if ((frePprGrTr == null) || (Mode_Label2.Text == UPD_MODE))
            {
                e.Row.CellAppearance.ForeColor = Color.Black;
            }
            else
            {
                e.Row.CellAppearance.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// �O���b�h���`�悳���Ƃ��������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_Paint(object sender, PaintEventArgs e)
        {
            // �A�N�e�B�u���E���擾
            if (FrePprSelect_Grid.ActiveRow == null) return;

            string outputFormFileNm = Convert.ToString(FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_OFrmFilNm].Text);
            int userDerivNo = Convert.ToInt32(FrePprSelect_Grid.ActiveRow.Cells[CT_FREE_PPR_DerivNo].Value);

            //�󎚈ʒu�ݒ�̃L���b�V�����擾
            FrePprGrTr frePprGrTr = SFANL08201UA.GetFrePprGrTrCash(_groupCode, outputFormFileNm, userDerivNo);
            
            // ���ɑ��݂��Ă��邩
            if ((frePprGrTr == null) || (Mode_Label2.Text == UPD_MODE))
            {
                FrePprSelect_Grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            }
            else
            {
                FrePprSelect_Grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Red;
            }   
        }

        /// <summary>
        /// ���E���A�N�e�B�u�ɂȂ����Ƃ��ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_AfterRowActivate_1(object sender, EventArgs e)
        {
            FrePprSelect_Grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// ����{�^����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            SuspendLayoutHide();
        }

        /// <summary>
        /// ���R���[�O���[�v�ۑ��{�^����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrOk_Button_Click(object sender, EventArgs e)
        {
            // �O���[�v�o�^����
            if (RegistGroupData())
            {
                SuspendLayoutHide();
            }
        }

        /// <summary>
        /// ���R���[�O���[�v�U�֕ۑ��{�^����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrOk_Button_Click(object sender, EventArgs e)
        {
            // �U�֏��o�^����
            if (RegistTranceData())
            {
                SuspendLayoutHide();
            }
        }

        /// <summary>
        /// �O���b�h���A�N�e�B�u�ɂȂ����Ƃ��ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_AfterRowActivate(object sender, EventArgs e)
        {
            FrePprSelect_Grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// �O���b�h��ŃL�[���������ꂽ�Ƃ��ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrePprSelect_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if ((this.FrePprSelect_Grid.ActiveRow != null) && (this.FrePprSelect_Grid.ActiveRow.Index == 0))
                        {
                            FrrPptDispOrderCd_tNedit.Focus();
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ((this.FrePprSelect_Grid.ActiveRow != null) && (this.FrePprSelect_Grid.ActiveRow.Index == (this.FrePprSelect_Grid.Rows.Count-1)))
                        {
                            TrOk_Button.Focus();
                        }
                        break;
                    }
                case Keys.Escape:
                    {
                        SuspendLayoutHide();
                        break;
                    }
            }
        }

        /// <summary>
        /// �\����Ԃ��ω������Ƃ��ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceDlg_VisibleChanged(object sender, EventArgs e)
        {
            //�[���I�Ƀ��[�_���ɂ���
            if (this.Visible)
            {
                this.Owner.Enabled = false;
            }
            else
            {
                this.Owner.Enabled = true;
            }
        }

        /// <summary>
        /// �t�H�[����������Ƃ��ɔ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł�
            if (this.CanClose == false)
            {
                e.Cancel = true;
                this.SuspendLayoutHide();
                return;
            }
        }

        /// <summary>
        /// �t�H�[����ŃL�[���������ꂽ�^�C�~���O�Ŕ������܂�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceDlg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
        }
        #endregion


    }
}