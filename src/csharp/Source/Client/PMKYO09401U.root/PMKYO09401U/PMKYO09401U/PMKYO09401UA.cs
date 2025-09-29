//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M�������O�����e���
// �v���O�����T�v   : ���M�������O�����e���
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����Y
// �� �� ��  2011/08/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/24  �C�����e : Redmine #23930 #23897 �\�[�X���r���[���ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/25  �C�����e : Redmine #23810 ���Z�[�W�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/09/05  �C�����e : Redmine #24387 ���M�������O�����e��UI���C�˗�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/09/14  �C�����e : Redmine #25051 #24952 ���M�������O�����e�@�f�[�^�\���̕s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/11/01  �C�����e : �d�l�A�� #26228: ���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    ///<summary>
    /// ���M�������O�����e��ʃt�H�[���N���X
    /// </summary>
    /// <remarks>
    /// Note       : ���M�������O�����e���<br />
    /// Programmer : �����Y<br />
    /// Date       : 2011/08/01<br />
    /// Update     : <br />
    /// </remarks>
    public partial class PMKYO09401UA : Form
    {
        #region �� Constructor ��
        public PMKYO09401UA()
        {
            InitializeComponent();
            InitialSetting();
        }
        #endregion �� Constructor ��

        #region �� Const Memebers ��
        private const String CHECK_BOX = "�I��";
        private const String ENT_CODE_FROM = "���M����ƃR�[�h";
        private const String SECTION_FROM = "���M�����_";
        private const String SEND_NO = "���M�ԍ�";
        private const String SEND_DATE = "���M����";
        private const String DIV = "���p�敪";
        private const String SEND_DIV = "����M�敪";
        private const String TYPE = "���";
        private const String CONDITION_DIV = "���o�����敪";
		// UPD 2011.09.05 ------->>>>>
		//private const String SECTION = "���M�Ώۋ��_";
		private const String SECTION = "���o�Ώۋ��_";
		// UPD 2011.09.05 -------<<<<<
        private const String SECTION_TO = "���M�拒�_";
        private const String ENT_CODE_TO = "���M���ƃR�[�h";
        private const String START_TIME = "���M�ΏۊJ�n����";
        private const String END_TIME = "���M�ΏۏI������";
		private const String UPDATE_TIME = "�X�V����";
		private const String CT_CLASSID = "PMKYO09401U";
        #endregion �� Const Memebers �� 

        #region �� Private Field ��
        /// <summary>
        /// ���M�������O�����e��ʃA�N�Z�X�N���X
        /// </summary>
        private SndRcvHisAcs _SndRcvHisAcs;
        /// <summary>
        /// ���o�����ڍ׉��
        /// </summary>
        private PMKYO09401UB _detailDialog;
        /// <summary>���_</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>
        /// �����O�b���h
        /// </summary>
        private DataTable detailsTable;

        // ���o���LIST
        object searchResult;
        ArrayList sndRcvHisWorkList;    // �������
        ArrayList sndRcvEtrWorkList;    // �ڍח������

        private string _loginName;
        private string _enterpriseCode;
        private string _loginEmplooyCode;
        private string _loginSectionCode;

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _detailButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        #endregion �� Private Field ��

        #region �� Event ��
        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ToolClickEventArgs</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N�C�x���g</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // ��ʂ̏I��
                case "ButtonTool_Close":
                    {
                        //��ʕ���B
                        this.Close();
                    }
                    break;

                // ��ʂ̍폜
                case "ButtonTool_Delete":
                    {
                        int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

                        object obj = this.GetCheckedRecord();

						// ADD 2011.08.24 ---------->>>>>
						ArrayList list = obj as ArrayList;
						if (0 == list.Count)
						{
							break;
						}						
						DialogResult result = TMsgDisp.Show(
			                      this, 								// �e�E�B���h�E�t�H�[��
								  emErrorLevel.ERR_LEVEL_QUESTION,    // �G���[���x��
								  //"PMKYO09401U",						// �A�Z���u���h�c�܂��̓N���X�h�c // DEL 2011.08.25
								  CT_CLASSID,// ADD 2011.08.25
								  "�폜���܂����H", 				// �\�����郁�b�Z�[�W
								  0, 									// �X�e�[�^�X�l
								  MessageBoxButtons.YesNo,
								  MessageBoxDefaultButton.Button2);	// �\������{�^��

						if (result != DialogResult.Yes)
						{
							break;
						}

						// ADD 2011.08.24 ----------<<<<<
                        status = this._SndRcvHisAcs.Delete(ref obj);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
							//MessageBox.Show("�폜���ɃG���[���������܂����B"); // DEL 2011.08.24
							// ADD 2011.08.24 --------->>>>>
							TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
										emErrorLevel.ERR_LEVEL_STOP,     // �G���[���x��
										//"PMKYO09401U",							// �A�Z���u��ID // DEL 2011.08.25
								        CT_CLASSID,// ADD 2011.08.25
										//"�폜���ɃG���[���������܂����B",	    // �\�����郁�b�Z�[�W // DEL 2011.08.25
										"���M�����f�[�^�̍폜�Ɏ��s���܂����B",  // ADD 2011.08.25
										status,									    // �X�e�[�^�X�l
										MessageBoxButtons.OK);					// �\������{�^��
							// ADD 2011.08.24 ---------<<<<<

                        }
                        else
                        {
                            this.detailsTable.Clear();
                            this.RecordSearch();
                        }
                    }
                    break;

                //��ʂ̌���
                case "ButtonTool_Search":
                    {
                        // �`�F�b�N���G���[���������Ȃ������ꍇ
                        if (this.DateCheck() == 0)
                        {
                            this.RecordSearch();
                        }
                    }
                    break;

                //���o�����ڍ�
                case "ButtonTool_Detail":
                    {
                        if (this.searchResult != null)
                        {
                            this.SetDetailInfo();
                        }
                        else
                        {
							//MessageBox.Show("���o�����ڍׂ��Ȃ��B"); // DEL 2011.08.24
							// ADD 2011.08.24 --------->>>>>
							TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
										emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
								        //"PMKYO09401U",							// �A�Z���u��ID // DEL 2011.08.25
								        CT_CLASSID,// ADD 2011.08.25
										//"���o�����ڍׂ��Ȃ��B",	    // �\�����郁�b�Z�[�W  // DEL 2011.08.25
										"���o�����ڍ׃f�[�^�����݂��܂���B",  // ADD 2011.08.25
										0,									    // �X�e�[�^�X�l
										MessageBoxButtons.OK);					// �\������{�^��
							// ADD 2011.08.24 ---------<<<<<
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : ��ʃ��[�h�C�x���g</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void PMKYO09401UA_Load(object sender, EventArgs e)
        {
            this.DataSetColumnConstruction();
            this.SetColumnStyle();
            this.ButtonInitialSetting();
        }

        /// <summary>
        /// ���R�[�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DoubleClickCellEventArgs</param>
        /// <remarks>
        /// <br>Note       : ���R�[�h�_�u���N���b�N�C�x���g</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void uGrid_Details_DoubleClickCell(object sender, Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs e)
        {
            if (e.Cell != null && e.Cell.Column.Index != 0)
            {
                this.SetDetailInfo();
            }
        }

        /// <summary>
        /// ���R�[�h�������ɂȂ�g�p����C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : ���R�[�h�������ɂȂ�g�p����C�x���g</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled = false;

            // �폜�{�^���͊����ɂ���B
            this.tToolbarsManager1.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;

            SndRcvHisWork sndRcvHisWork = this.GetActiveRow();
            // ��ʂ��u�}�X�^�v�A���o�����f�[�^���u�蓮�����v�̖��׃f�[�^��I�����Ă���ꍇ
            if (sndRcvHisWork.Kind == 1 && sndRcvHisWork.SndLogExtraCondDiv == 1)
            {
                // ���o�����ڍ׃{�^���͊����ɂ���B
                this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled = true;
            }
        }
        #endregion �� Event ��

        #region �� Private Method ��
        /// <summary>
        /// �����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ݒ菈���ł�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void InitialSetting()
        {
            // ���M�������O�����e��ʃA�N�Z�X�N���X
            _SndRcvHisAcs = new SndRcvHisAcs();

            _secInfoSetAcs = new SecInfoSetAcs();

            // �폜�A���o�����ڍ׃{�^���͔񊈐��B
            this.tToolbarsManager1.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
            this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled = false;

            // �ϐ�������
            //�����O�b���h
            detailsTable = new DataTable();
            this.tde_Start_Date.SetDateTime(DateTime.Now);
            this.tde_End_Date.SetDateTime(DateTime.Now);
            this._loginName = LoginInfoAcquisition.Employee.Name;
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();

			// ����M�敪
			this.tce_SendAndReceKubun.SelectedIndex = 0; // ADD 2011.09.02

            // �{�^���ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Delete"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Search"];
            this._detailButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Detail"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginTitle"];
        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._detailButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DETAILS;
            this._LoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager1.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g����\�z�����ł�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            this.detailsTable.Columns.Add(CHECK_BOX, typeof(bool));
			this.detailsTable.Columns.Add(ENT_CODE_FROM, typeof(string));
			this.detailsTable.Columns.Add(SECTION_FROM, typeof(string));			
			// ADD 2011.09.05 ------->>>>>
			this.detailsTable.Columns.Add(ENT_CODE_TO, typeof(string));
			this.detailsTable.Columns.Add(SECTION_TO, typeof(string));
			// ADD 2011.09.05 -------<<<<<
			
            this.detailsTable.Columns.Add(SEND_NO, typeof(string));
            this.detailsTable.Columns.Add(SEND_DATE, typeof(string));
            this.detailsTable.Columns.Add(DIV, typeof(string));
            this.detailsTable.Columns.Add(SEND_DIV, typeof(string));
            this.detailsTable.Columns.Add(TYPE, typeof(string));
            this.detailsTable.Columns.Add(CONDITION_DIV, typeof(string));
            this.detailsTable.Columns.Add(SECTION, typeof(string));
			// DEL 2011.09.05 ------->>>>>
			//this.detailsTable.Columns.Add(SECTION_TO, typeof(string));
			//this.detailsTable.Columns.Add(ENT_CODE_TO, typeof(string));
			// DEL 2011.09.05 -------<<<<<
            this.detailsTable.Columns.Add(START_TIME, typeof(string));
            this.detailsTable.Columns.Add(END_TIME, typeof(string));
            this.detailsTable.Columns.Add(UPDATE_TIME, typeof(string));

            this.uGrid_Details.DataSource = detailsTable;
        }

        /// <summary>
        /// ���R�[�h�̗�̃X�^�C���̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�[�h�̗�̃X�^�C���̐ݒ�</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SetColumnStyle()
        {
            
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // �I���`�F�b�N�{�b�N�X
            Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].ExcludeFromColumnChooser = Infragistics.Win.UltraWinGrid.ExcludeFromColumnChooser.False;
            Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].Header.Fixed = true;

            // �Œ��ݒ�
            Columns[this.detailsTable.Columns[UPDATE_TIME].ColumnName].Hidden = true;
			// DEL 2011.09.14 ------->>>>>
			//// ADD 2011.09.05 ------->>>>>
			//Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].Hidden = true;
			//Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].Hidden = true;
			//// ADD 2011.09.05 -------<<<<<
			// DEL 2011.09.14 -------<<<<<

			// ADD 2011.09.14 ------->>>>>
			if ((int)this.tce_SendAndReceKubun.Value == 1)
			{
				Columns[this.detailsTable.Columns[ENT_CODE_TO].ColumnName].Hidden = false;
				Columns[this.detailsTable.Columns[SECTION_TO].ColumnName].Hidden = false;
				Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].Hidden = true;
				Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].Hidden = true;
			}
			else
			{
				Columns[this.detailsTable.Columns[ENT_CODE_TO].ColumnName].Hidden = true;
				Columns[this.detailsTable.Columns[SECTION_TO].ColumnName].Hidden = true;
				Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].Hidden = false;
				Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].Hidden = false;
			}
			// ADD 2011.09.14 -------<<<<<
            // �\�����ݒ�
            Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].Width = 50;
            Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].Width = 150;
            Columns[this.detailsTable.Columns[SEND_NO].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[SEND_DATE].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[DIV].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[SEND_DIV].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[TYPE].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[CONDITION_DIV].ColumnName].Width = 100;
            Columns[this.detailsTable.Columns[SECTION].ColumnName].Width = 150;
            Columns[this.detailsTable.Columns[SECTION_TO].ColumnName].Width = 150;
            Columns[this.detailsTable.Columns[ENT_CODE_TO].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[START_TIME].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[END_TIME].ColumnName].Width = 200;
            Columns[this.detailsTable.Columns[UPDATE_TIME].ColumnName].Width = 200;
          
            // ���͋��ݒ�
			Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].CellClickAction = CellClickAction.CellSelect;
			Columns[this.detailsTable.Columns[CHECK_BOX].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this.detailsTable.Columns[ENT_CODE_FROM].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SECTION_FROM].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_NO].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_DATE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[DIV].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SEND_DIV].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[TYPE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[CONDITION_DIV].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SECTION].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[SECTION_TO].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[ENT_CODE_TO].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[START_TIME].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[END_TIME].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this.detailsTable.Columns[UPDATE_TIME].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

        }

        /// <summary>
        /// �������������A��ʂŕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������������A��ʂŕ\������</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void RecordSearch()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            this.detailsTable.Clear();
            SndRcvHisCondWork sndRcvHisCondWork = null;
            sndRcvHisWorkList = new ArrayList();
            sndRcvEtrWorkList = new ArrayList();
			SndRcvHisAcs sndRcvHisAcs = new SndRcvHisAcs(); // ADD 2011.08.24
            this.ScreenToSndRcvHisCondWork(out sndRcvHisCondWork);

            status = this._SndRcvHisAcs.Serch(sndRcvHisCondWork, out searchResult);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList resultList = searchResult as ArrayList;

                for (int i = 0; i < resultList.Count; i++)
                {
                    if (resultList[i].GetType() == typeof(SndRcvHisWork))
                    {
                        DataRow row = this.detailsTable.NewRow();
                        SndRcvHisWork work = (SndRcvHisWork)resultList[i];
                        sndRcvHisWorkList.Add(work);    // �������LIST�ɒǉ�����

                        row[detailsTable.Columns[CHECK_BOX].ColumnName] = false;
                        row[detailsTable.Columns[ENT_CODE_FROM].ColumnName] = work.EnterpriseCode;                   // ���M����ƃR�[�h
						//row[detailsTable.Columns[SECTION_FROM].ColumnName] = this.GetSetctionName(work.SectionCode);// ���M�����_ // DEL 2011.08.24
						row[detailsTable.Columns[SECTION_FROM].ColumnName] = sndRcvHisAcs.GetSetctionName(work.SectionCode); // ���M�����_  // ADD 2011.08.24
                        row[detailsTable.Columns[SEND_NO].ColumnName] = work.SndRcvHisConsNo.ToString().PadLeft(7, '0');           // ���M�ԍ�
                        row[detailsTable.Columns[SEND_DATE].ColumnName] = this.LongFormatToString(work.SendDateTime);            // ���M����
                        row[detailsTable.Columns[DIV].ColumnName] = work.SndLogUseDiv == 0 ? "���_�Ǘ�" : "";                  // ���p�敪
						//row[detailsTable.Columns[SEND_DIV].ColumnName] = work.SendOrReceiveDivCd == 0 ? "���M" : "��M";       // ����M�敪 // DEL 2011.09.14
						row[detailsTable.Columns[SEND_DIV].ColumnName] = work.SendOrReceiveDivCd == 0 ? "����M" : "��M";       // ����M�敪 // ADD 2011.09.14
                        row[detailsTable.Columns[TYPE].ColumnName] = work.Kind == 0 ? "�f�[�^" : "�}�X�^";                         // ���
                        //-----Add 2011/11/01 ���� for #26228 start----->>>>>
                        if (work.Kind != 0)
                        {
                        //-----Add 2011/11/01 ���� for #26228 end-----<<<<<    
                            //�}�X�^�̏ꍇ
                            row[detailsTable.Columns[CONDITION_DIV].ColumnName] = work.SndLogExtraCondDiv == 0 ? "����" : "����";  // ���o�����敪
                        //-----Add 2011/11/01 ���� for #26228 start----->>>>>
                        }
                        else
                        {
                            //�f�[�^�̏ꍇ
                            row[detailsTable.Columns[CONDITION_DIV].ColumnName] = work.SndLogExtraCondDiv == 0 ? "����" : "�`�[���t";// ���o�����敪
                        }
                        //-----Add 2011/11/01 ���� for #26228 end-----<<<<<
						//row[detailsTable.Columns[SECTION].ColumnName] = this.GetSetctionName(work.ExtraObjSecCode);             // ���M�Ώۋ��_ // DEL 2011.08.24
						//row[detailsTable.Columns[SECTION_TO].ColumnName] = this.GetSetctionName(work.SendDestSecCode);        // ���M�拒�_ // DEL 2011.08.24
						row[detailsTable.Columns[SECTION].ColumnName] = sndRcvHisAcs.GetSetctionName(work.ExtraObjSecCode);             // ���M�Ώۋ��_ // ADD 2011.08.24
						row[detailsTable.Columns[SECTION_TO].ColumnName] = sndRcvHisAcs.GetSetctionName(work.SendDestSecCode);        // ���M�拒�_ // ADD 2011.08.24
                        row[detailsTable.Columns[ENT_CODE_TO].ColumnName] = work.SendDestEpCode;        // ���M���ƃR�[�h

                        if (work.SndObjStartDate > DateTime.MinValue)
                        {
							//row[detailsTable.Columns[START_TIME].ColumnName] = this.DateTimeFormatToString(work.SndObjStartDate);        // ���M�ΏۊJ�n���� // DEL 2011.08.24
							row[detailsTable.Columns[START_TIME].ColumnName] = sndRcvHisAcs.DateTimeFormatToString(work.SndObjStartDate);        // ���M�ΏۊJ�n���� // ADD 2011.08.24
						}
                        else
                        {
                            row[detailsTable.Columns[START_TIME].ColumnName] = "";        // ���M�ΏۊJ�n����
                        }
                        if (work.SndObjEndDate > DateTime.MinValue)
                        {
							//row[detailsTable.Columns[END_TIME].ColumnName] = this.DateTimeFormatToString(work.SndObjEndDate);            // ���M�ΏۏI������ // DEL 2011.08.24
							row[detailsTable.Columns[END_TIME].ColumnName] = sndRcvHisAcs.DateTimeFormatToString(work.SndObjEndDate);            // ���M�ΏۏI������ // ADD 2011.08.24
                        }
                        else
                        {
                            row[detailsTable.Columns[END_TIME].ColumnName] = "";        // ���M�ΏۏI������
                        }
                        if (work.UpdateDateTime > DateTime.MinValue)
                        {
							//row[detailsTable.Columns[UPDATE_TIME].ColumnName] = this.DateTimeFormatToString(work.UpdateDateTime);        // �X�V���� // DEL 2011.08.24
							row[detailsTable.Columns[UPDATE_TIME].ColumnName] = sndRcvHisAcs.DateTimeFormatToString(work.UpdateDateTime);        // �X�V���� // ADD 2011.08.24
                        }
                        else
                        {
                            row[detailsTable.Columns[UPDATE_TIME].ColumnName] = "";        // �X�V����
                        }
                        
                        this.detailsTable.Rows.Add(row);
                    }
                    else
                    {
                        sndRcvEtrWorkList.Add(resultList[i] as ArrayList);  // �ڍח������lIST�ɒǉ�����
                    }
                }

				// ADD 2011.09.14 ------->>>>>
				this.SetColumnStyle();
				// ADD 2011.09.14 -------<<<<<
            }
			// ADD 2011.08.25 --------->>>>>
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO,     // �G���[���x��
					      //"PMKYO09401U",							// �A�Z���u��ID // DEL 2011.08.25
						    CT_CLASSID,// ADD 2011.08.25
							"�Y������f�[�^��������܂���ł����B",	    // �\�����郁�b�Z�[�W
							0,									    // �X�e�[�^�X�l
							MessageBoxButtons.OK);					// �\������{�^��
				this.tToolbarsManager1.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
				this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled = false;				
			}
			// ADD 2011.08.25 ---------<<<<<
			else
			{
				//MessageBox.Show("�������G���[���������܂����B�G���[�F" + status.ToString());// DEL 2011.08.24
				// ADD 2011.08.24 --------->>>>>
				TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOP,     // �G���[���x��
					        //"PMKYO09401U",							// �A�Z���u��ID // DEL 2011.08.25
						    CT_CLASSID,// ADD 2011.08.25
					        //"�������G���[���������܂����B�G���[�F" + status.ToString(),	    // �\�����郁�b�Z�[�W  // DEL 2011.08.25
							"���M�����f�[�^�̌����Ɏ��s���܂����B",   // ADD 2011.08.25
					        //0,									    // �X�e�[�^�X�l  // DEL 2011.08.25
							status,  // ADD 2011.08.25
							MessageBoxButtons.OK);					// �\������{�^��
				// ADD 2011.08.24 ---------<<<<<
			}
        }

        /// <summary>
        /// �I���������R�[�h���擾����B
        /// </summary>
        /// <returns>���R�[�hLIST</returns>
        /// <remarks>
        /// <br>Note       : �I���������R�[�h���擾����B</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private object GetCheckedRecord()
        {
            CustomSerializeArrayList record = new CustomSerializeArrayList();
            CustomSerializeArrayList rowList = new CustomSerializeArrayList();
            uGrid_Details.UpdateData();
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if ((bool)row.Cells[CHECK_BOX].Value)
                {
                    DataRow dataRow = detailsTable.Rows[row.Index];
                    rowList.Add(dataRow);
                }
            }

            if (rowList != null)
            {
                if (rowList.Count == 0)
                {
					//MessageBox.Show("�폜�Ώۂ̃f�[�^��I�����Ă��������B");// DEL 2011.08.24
					// ADD 2011.08.24 --------->>>>>
					TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
								emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
						        //"PMKYO09401U",							// �A�Z���u��ID// DEL 2011.08.25
							    CT_CLASSID,// ADD 2011.08.25
								"�폜�Ώۃf�[�^��I�����Ă��������B",	    // �\�����郁�b�Z�[�W
								0,									    // �X�e�[�^�X�l
								MessageBoxButtons.OK);					// �\������{�^��
					// ADD 2011.08.24 ---------<<<<<
                }
                else
                {
                    foreach (DataRow row in rowList)
                    {
                        SndRcvHisWork sndRcvHisWork = this.GetCheckedSndRcvHisWork(Convert.ToInt32(row[detailsTable.Columns[SEND_NO]].ToString()));

                        record.Add(sndRcvHisWork);
                    }
                }

            }

            return record;
        }

        /// <summary>
        /// �I������SndRcvHisWork���R�[�h���擾����
        /// </summary>
        /// <param name="sndRcvHisConsNo">SndRcvHisWork��sndRcvHisConsNo</param>
        /// <returns>SndRcvHisWork���R�[�h</returns>
        /// <remarks>
        /// <br>Note       : �I������SndRcvHisWork���R�[�h���擾����</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private SndRcvHisWork GetCheckedSndRcvHisWork(int sndRcvHisConsNo)
        {
            SndRcvHisWork sndRcvHisWork = null;

            foreach (SndRcvHisWork work in sndRcvHisWorkList)
            {
                if (sndRcvHisConsNo == work.SndRcvHisConsNo)
                {
                    sndRcvHisWork = work;
                }
            }

            return sndRcvHisWork;
        }

        /// <summary>
        /// ���o�����ڍׂ��Z�b�g����B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���o�����ڍׂ��Z�b�g����B</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SetDetailInfo()
        {
            if (this.tToolbarsManager1.Tools["ButtonTool_Detail"].SharedProps.Enabled == true)
            {
                SndRcvHisWork sndRcvHisWork = this.GetActiveRow();
                this._detailDialog = new PMKYO09401UB(sndRcvHisWork, this.searchResult);
                this._detailDialog.ShowDialog();
            }
        }

		// DEL 2011.08.24 -------->>>>>
		///// <summary>
		///// DateTime�̓�����String�ɂ���
		///// </summary>
		///// <param name="dateTime">DateTime�̓���</param>
		///// <returns>String�̓���</returns>
		///// <remarks>
		///// <br>Note       : DateTime�̓�����String�ɂ���</br>
		///// <br>Programmer : �����Y</br>
		///// <br>Date       : 2011/08/01</br>
		///// </remarks>
		//private string DateTimeFormatToString(DateTime dateTime)
		//{
		//    string time = null;
		//    time += dateTime.Year + "�N";
		//    time += dateTime.Month + "��";
		//    time += dateTime.Day + "��";
		//    time += dateTime.Hour + "��";
		//    time += dateTime.Minute + "��";
		//    time += dateTime.Second + "�b";

		//    return time;
		//}
		// DEL 2011.08.24 --------<<<<<

		/// <summary>
		/// long�̓�����String�ɂ���
		/// </summary>
		/// <param name="longTime">long�̓���</param>
		/// <returns>String�̓���</returns>
		/// <remarks>
		/// <br>Note       : long�̓�����String�ɂ���</br>
		/// <br>Programmer : �����Y</br>
		/// <br>Date       : 2011/08/01</br>
		/// </remarks>
		private string LongFormatToString(long longTime)
		{
			string time = null;

			time += Convert.ToInt32(longTime.ToString().Substring(0, 4)) + "�N";
			time += Convert.ToInt32(longTime.ToString().Substring(4, 2)) + "��";
			time += Convert.ToInt32(longTime.ToString().Substring(6, 2)) + "��";
			time += Convert.ToInt32(longTime.ToString().Substring(8, 2)) + "��";
			time += Convert.ToInt32(longTime.ToString().Substring(10, 2)) + "��";

			return time;
		}

        /// <summary>
        /// ��ʂ���̓��t���`�F�b�N����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��ʂ���̓��t���`�F�b�N����</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private int DateCheck()
        {
            int status = -1;

            if (!TDateTime.IsAvailableDate(this.tde_Start_Date.GetDateTime()))
            {
				//MessageBox.Show("���M���J�n���t�̎w��Ɍ�肪����܂��B");// DEL 2011.08.24
				// ADD 2011.08.24 --------->>>>>
				TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
							//"PMKYO09401U",							// �A�Z���u��ID // DEL 2011.08.25
							CT_CLASSID,// ADD 2011.08.25
							//"���M���J�n���t�̎w��Ɍ�肪����܂��B",	    // �\�����郁�b�Z�[�W  // DEL 2011.08.25
							"�J�n���M�����s���ł��B",  // ADD 2011.08.25
							0,									    // �X�e�[�^�X�l
							MessageBoxButtons.OK);					// �\������{�^��
				// ADD 2011.08.24 ---------<<<<<
                this.tde_Start_Date.Focus();
                return status;
            }
            if (!TDateTime.IsAvailableDate(this.tde_End_Date.GetDateTime()))
            {
				//MessageBox.Show("���M���I�����t�̎w��Ɍ�肪����܂��B");// DEL 2011.08.24
				// ADD 2011.08.24 --------->>>>>
				TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
							//"PMKYO09401U",							// �A�Z���u��ID	// DEL 2011.08.25
							CT_CLASSID,// ADD 2011.08.25
							//"���M���I�����t�̎w��Ɍ�肪����܂��B",	    // �\�����郁�b�Z�[�W // DEL 2011.08.25
							"�I�����M�����s���ł��B",  // ADD 2011.08.25
							0,									    // �X�e�[�^�X�l
							MessageBoxButtons.OK);					// �\������{�^��
				// ADD 2011.08.24 ---------<<<<<
                this.tde_End_Date.Focus();
                return status;
            }
            if (this.tde_Start_Date.GetDateTime().CompareTo(this.tde_End_Date.GetDateTime()) > 0)
            {
				//MessageBox.Show("���M���t�̎w��Ɍ�肪����܂��B");// DEL 2011.08.24
				// ADD 2011.08.24 --------->>>>>
				TMsgDisp.Show(this,                     // �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
							//"PMKYO09401U",							// �A�Z���u��ID	// DEL 2011.08.25
							CT_CLASSID,// ADD 2011.08.25
					//"���M���t�̎w��Ɍ�肪����܂��B",	    // �\�����郁�b�Z�[�W // DEL 2011.08.25
							"���M���t�͈͎̔w��Ɍ�肪����܂��B",  // ADD 2011.08.25
							0,									    // �X�e�[�^�X�l
							MessageBoxButtons.OK);					// �\������{�^��
				// ADD 2011.08.24 ---------<<<<<
                this.tde_Start_Date.Focus();
                return status;
            }
            status = 0;

            return status;
        }

        /// <summary>
        /// ��ʂ���������擾����
        /// </summary>
        /// <param name="sndRcvHisCondWork">�擾�������</param>
        /// <remarks>
        /// <br>Note       : ��ʂ���������擾����</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void ScreenToSndRcvHisCondWork(out SndRcvHisCondWork sndRcvHisCondWork)
        {
            sndRcvHisCondWork = new SndRcvHisCondWork();

            sndRcvHisCondWork.ParaEnterpriseCode = this._enterpriseCode;
            
            sndRcvHisCondWork.SendDateTimeStart = long.Parse(this.tde_Start_Date.GetLongDate() + "0000");
            sndRcvHisCondWork.SendDateTimeEnd = long.Parse(this.tde_End_Date.GetLongDate() + "2359");

			// ADD 2011.09.05
			if ((int)this.tce_SendAndReceKubun.Value == 1)
			{
				sndRcvHisCondWork.ParaSendOrReceiveDivCd = 0;
			}
			else
			{
				sndRcvHisCondWork.ParaSendOrReceiveDivCd = 1;
			}

			sndRcvHisCondWork.ParaSectionCode = this.tEdit_SectionCodeAllowZero.DataText; // ADD 2011.09.14
			
        }

        /// <summary>
        /// �������R�[�h���擾����
        /// </summary>
        /// <returns>���R�[�h</returns>
        /// <remarks>
        /// <br>Note       : �������R�[�h���擾����</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private SndRcvHisWork GetActiveRow()
        {
            SndRcvHisWork sndRcvHisWork = null;

            int sndRcvHisConsNo = Convert.ToInt32(this.uGrid_Details.ActiveRow.Cells[detailsTable.Columns[SEND_NO].ColumnName].Value);  // ���M�ԍ�
            foreach (SndRcvHisWork work in this.sndRcvHisWorkList)
            {
                if (work.SndRcvHisConsNo == sndRcvHisConsNo)
                {
                    sndRcvHisWork = work;
                }
            }

            return sndRcvHisWork;
        }

		// DEL 2011.08.24 --------------->>>>>
		///// <summary>
		///// ���_�����擾
		///// </summary>
		///// <param name="sectionCode">���_�R�[�h</param>
		///// <returns>���_���O</returns>
		///// /// <remarks>
		///// <br>Note       : ���_�����擾</br>
		///// <br>Programmer : �����Y</br>
		///// <br>Date       : 2011/08/01</br>
		///// </remarks>
		//private string GetSetctionName(string sectionCode)
		//{
		//    string sectionName = null;

		//    SecInfoAcs secInfoAcs = new SecInfoAcs();
		//    try
		//    {
		//        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
		//        {
		//            if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
		//            {
		//                sectionName = secInfoSet.SectionGuideNm.Trim();
		//                break;
		//            }
		//        }
		//    }
		//    catch
		//    {
		//        sectionName = string.Empty;
		//    }

		//    return sectionName;
		//}
		// DEL 2011.08.24 ---------------<<<<<
       
		/// <summary>
		/// KeyDown����
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���M���O���b�h�̃}�E�X�E�N���b�N�����B</br>
		/// <br>Programmer  : �����Y</br>
		/// <br>Date        : 2011/08/01</br>
		/// </remarks>
		private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
		{
			if (uGrid_Details.ActiveRow != null)
			{
				if (e.KeyCode == Keys.Space)
				{
					bool flag = (bool)this.uGrid_Details.ActiveRow.Cells[this.detailsTable.Columns[CHECK_BOX].ColumnName].Value;
					this.uGrid_Details.ActiveRow.Cells[this.detailsTable.Columns[CHECK_BOX].ColumnName].Value = !flag;
				}
			}
		}
		#endregion �� Private Method ��

		private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
		{
			uGrid_Details.Selected.Rows.Clear();
			bool val = !((bool)e.Cell.Value);
			e.Cell.Value = val;

			if (uGrid_Details.Selected.Rows.Count == 0 || e.Cell.Row != uGrid_Details.Selected.Rows[0])
				e.Cell.Row.Selected = true;
			e.Cancel = true;
		}

		// ADD 2011.09.14 ---------->>>>>
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����[�h�C�x���g�����������܂��B</br>
		/// <br>Programmer	: ����</br>
		/// <br>Date		: 2011.09.14</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			 if (e.PrevCtrl == null || e.NextCtrl == null) return;

			switch (e.PrevCtrl.Name)
			{
				//-----ADD 2011/07/28 ���� SCM�Ή�-���_�Ǘ��i10704767-00�j----->>>>>
				case "tEdit_SectionCodeAllowZero":
					{
						// ���_�R�[�h�擾
						string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;
						if (sectionCode.Trim().Equals(""))
						{
							this.tEdit_SectionCodeAllowZero.DataText = "00";
						}
						else
						{
							this.tEdit_SectionCodeAllowZero.DataText = sectionCode.PadLeft(2, '0');
						}
					}
					break;
			}
		}
		// ADD 2011.09.14 ----------<<<<<
	}
}