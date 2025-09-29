//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �G���[�ڍׂt�h�N���X
// �v���O�����T�v   : �G���[�ڍו\���������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �v��
// �� �� ��  2011/07/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/09/01  �C�����e : #24288 �o�͐ݒ�̉�ʕ\��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �� �� ��  2011/09/16  �C�����e : #25198 �uPDF�\���v�{�^�����u����v�{�^���ɕύX
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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Net.NetworkInformation;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �G���[�ڍ׃t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �G���[�ڍׂ��s���܂�
	/// <br>Programmer	: �v��</br>
	/// <br>Date		: 2011.07.29</br>
    /// </br>
    /// </remarks>
	public partial class PMKYO01900UA : System.Windows.Forms.Form
	{
		#region -- Constructor --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �G���[�ڍ׃t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: �G���[�ڍ׃t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer	: �v��</br>
		/// <br>Date		: 2011.07.29</br>
		/// </remarks>
        public PMKYO01900UA(ArrayList errList)
		{
			InitializeComponent();

            if (null == errList)
            {
                _errList = new ArrayList();
            }
            else
            {
                _errList = errList;
            }

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �������f�[�^
            SetGridLayout();

            // Grid�Ńf�[�^�\��
            ShowData();
		}

		#endregion

		#region -- Private Members --
		/*----------------------------------------------------------------------------------*/
        private ArrayList _errList;
        private DataTable _dataTable = new DataTable();
        private DataView _dataView = new DataView();
        private DataSet _dataSet = new DataSet();
        private const string tableName = PMKYO01901EA.Tbl_ErrorInfoTable;
        // �N���XID
        private const string ct_ClassID = "PMKYO01900UA";
        // �v���O����ID
        private const string ct_PGID = "PMKYO01900U";
        // ���[����
        private const string ct_PrintName = "�G���[�ڍ�";
        // ���[�L�[	
        private const string ct_PrintKey = "ef11229a-f35a-43ba-8a15-c6721147f50f";

		private string _enterpriseCode;

        private const string COLUMN_0 = "slipCode";
        private const string COLUMN_1 = "noFlg";
        private const string COLUMN_2 = "no";
        private const string COLUMN_3 = "date";
        private const string COLUMN_4 = "sectionInfo";
        private const string COLUMN_5 = "customerInfo";
        private const string COLUMN_6 = "error";

        private const string SLIP_1 = "����";
        private const string SLIP_2 = "����";
        private const string SLIP_3 = "�d��";
        private const string SLIP_4 = "�x��";

		#endregion

		#region -- Private Methods --
        /// <summary>
        /// Grid�Ńf�[�^�\������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: Grid�ŃG���[�ڍ׏���\������</br>
        /// <br>Programmer	: �v��</br>
        /// <br>Date		: 2011.07.29</br>
        /// </remarks>
        private int ShowData()
        {
            int status = 0;

            if (_errList != null && _errList.Count > 0)�@�@�@�@�@// �f�[�^���݂���ꍇ
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            else
            {
                // �{�^�����䏈��
                this.PDF_Button.Enabled = false;

                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �X�e�[�^�X���f
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        this.uGrid_Details.BeginUpdate();

                        // Grid�̃f�[�^����������
                        InitialRowData(_errList);

                        this.uGrid_Details.EndUpdate();

                        break;
                    }
            }

            return status;
        }

		/// <summary>
        /// Grid�̃f�[�^����������
		/// </summary>
        /// <param name="errList">�G���[�ڍ�</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�ɍs��ǉ����܂��B</br>
		/// <br>Programmer : �v��</br>
		/// <br>Date       : 2011.07.29</br>
		/// </remarks>
        private void InitialRowData(ArrayList errList)
		{
            foreach (PMKYO01901EA tempBean in errList)
			{
                DataRow dr = _dataTable.NewRow();

                dr[COLUMN_1] = tempBean.NoFlg;
                dr[COLUMN_2] = tempBean.No;
                dr[COLUMN_3] = tempBean.Date;
                dr[COLUMN_4] = tempBean.SectionCode + " " + tempBean.SectionNm;
                dr[COLUMN_5] = tempBean.CustomerCode + " " + tempBean.CustomerNm;
                dr[COLUMN_6] = tempBean.Error;

                if (SLIP_1.Equals(tempBean.NoFlg))
                {
                    dr[COLUMN_0] = "1";
                }
                else if (SLIP_2.Equals(tempBean.NoFlg))
                {
                    dr[COLUMN_0] = "2";
                }
                else if (SLIP_3.Equals(tempBean.NoFlg))
                {
                    dr[COLUMN_0] = "3";
                }
                else if (SLIP_4.Equals(tempBean.NoFlg))
                {
                    dr[COLUMN_0] = "4";
                }
                _dataTable.Rows.Add(dr);
			}

            _dataSet.Tables.Add(_dataTable);
		}

		/// <summary>
		/// �O���b�h���C�A�E�g�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �O���b�h���C�A�E�g��ݒ肵�܂��B</br>
		/// <br>Programmer : �v��</br>
		/// <br>Date       : 2011.07.29</br>
		/// </remarks>
		private void SetGridLayout()
		{

            _dataSet = new DataSet();
            _dataTable = new DataTable(tableName);

            _dataTable.Columns.Add(COLUMN_0, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_1, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_2, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_3, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_4, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_5, System.Type.GetType("System.String"));
            _dataTable.Columns.Add(COLUMN_6, System.Type.GetType("System.String"));

            _dataView = _dataTable.DefaultView;
            _dataView.Sort = COLUMN_0 + "," + COLUMN_2 + "," + COLUMN_3 + "," + COLUMN_4 + "," + COLUMN_5;
            this.uGrid_Details.DataSource = _dataView;
            
			ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            //--------------------------------------
            // �\���s��
            //--------------------------------------
            columns[COLUMN_0].Hidden = true;

            //--------------------------------------
            // ���͕s��
            //--------------------------------------
            columns[COLUMN_1].CellActivation = Activation.NoEdit;
            columns[COLUMN_2].CellActivation = Activation.NoEdit;
            columns[COLUMN_3].CellActivation = Activation.NoEdit;
            columns[COLUMN_4].CellActivation = Activation.NoEdit;
            columns[COLUMN_5].CellActivation = Activation.NoEdit;
            columns[COLUMN_6].CellActivation = Activation.NoEdit;


			// �L���v�V����
			//--------------------------------------
            columns[COLUMN_1].Header.Caption = "�`�[";
            columns[COLUMN_2].Header.Caption = "�`�[�ԍ�";
            columns[COLUMN_3].Header.Caption = "���t";
            columns[COLUMN_4].Header.Caption = "���_";
            columns[COLUMN_5].Header.Caption = "���Ӑ�/�d����";
            columns[COLUMN_6].Header.Caption = "�G���[���e";

			//--------------------------------------
			// ��
			//--------------------------------------
            columns[COLUMN_1].Width = 60;
            columns[COLUMN_2].Width = 100;
            columns[COLUMN_3].Width = 100;
            columns[COLUMN_4].Width = 180;
            columns[COLUMN_5].Width = 200;
            columns[COLUMN_6].Width = 200;

			//--------------------------------------
			// �e�L�X�g�ʒu(VAlign)
			//--------------------------------------
			for (int index = 0; index < columns.Count; index++)
			{
				columns[index].CellAppearance.TextVAlign = VAlign.Middle;
			}
		}

		#endregion

		# region -- Control Events --
        /// <summary>
        /// Form���[�h����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMKYO01900UA_Load(object sender, EventArgs e)
        {
            ImageList imageList = IconResourceManagement.ImageList32;

            this.PDF_Button.ImageList = imageList;
            this.Close_Button.ImageList = imageList;

            //this.PDF_Button.Appearance.Image = Size32_Index.LIST1; //DEL 2011/09/16 #25198
            this.PDF_Button.Appearance.Image = Size32_Index.PRINT; //ADD 2011/09/16 #25198
            this.Close_Button.Appearance.Image = Size32_Index.CLOSE;
        }
		/*----------------------------------------------------------------------------------*/

		/// <summary>
		/// �C�x���g(PDF_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : PDF�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: �v��</br>
		/// <br>Date		: 2011.07.29</br>
		/// </remarks>
		private void PDF_Button_Click(object sender, EventArgs e)
		{
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = new SFCMN06002C();	// ������p�����[�^

            //ADD 2011/09/01 #24288 �o�͐ݒ�̉�ʕ\��--------->>>>>
            // PDF�o�͐ݒ�̉�ʕ\��
            printInfo.printmode = 1;
            //ADD 2011/09/01 #24288 �o�͐ݒ�̉�ʕ\��---------<<<<<

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;
            printInfo.rdData = this._dataSet;

            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���B", 0);
            }
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: �v��</br>
		/// <br>Date		: 2011.07.29</br>
		/// </remarks>
        private void Close_Button_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		/// <summary>
		/// ChangeFocus �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null || e.NextCtrl == null)
			{
				return;
			}
		}

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date	   : 2011.07.29</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion
		#endregion
	}
}