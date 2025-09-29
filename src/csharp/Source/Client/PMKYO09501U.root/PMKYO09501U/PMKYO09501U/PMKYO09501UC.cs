//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��ƃR�[�h�K�C�h���
// �v���O�����T�v   : ��ƃR�[�h�K�C�h���
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2012/07/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    ///<summary>
    /// ��ƃR�[�h�K�C�h���
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��ƃR�[�h�K�C�h���</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2012/07/25</br>
    /// <br>Update     : </br>
    /// </remarks>

    public partial class PMKYO09501UC : Form
    {
        #region �� Constructor ��
        /// <summary>
        /// ��ƃR�[�h�K�C�h��� �R���X�g���N�^
        /// </summary>
        /// <param name="detail">����M�������O�Q�ƃ����e���</param>
        /// <param name="enterpriseCodeList">��ƃR�[�h�K�C�h���X�g</param>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        public PMKYO09501UC(PMKYO09501UA detail, ArrayList enterpriseCodeList)
        {
            InitializeComponent();
            InitialSetting();
            DataSetColumnConstruction();

            this._PMKYO09501UA = detail;
            this._enterpriseCodeList = enterpriseCodeList;
        }
        #endregion �� Constructor ��


        #region �� Private Field ��
        private PMKYO09501UA _PMKYO09501UA = null;
        private DataTable _detailsTable;
        private ImageList _imageList16 = null;
        private ArrayList _enterpriseCodeList;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _cancelButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _selectButton;
        #endregion �� Private Field ��

        #region �� Const Memebers ��
        private const string ENTER_CODE = "��ƃR�[�h";
        private const string ENTER_NAME = "��ƃR�[�h����";
        private const string CT_CLASSID = "PMKYO09501UC";
        #endregion �� Const Memebers ��

        #region �� Private Method ��

        /// <summary>
        /// �����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ݒ菈���ł�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void InitialSetting()
        {
            _detailsTable = new DataTable();
            // �{�^���ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._cancelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Cancel"];
            this._selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Select"];

        }

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._cancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            this._selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : ��ʃ��[�h�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void PMKYO09501UC_Load(object sender, EventArgs e)
        {
            ButtonInitialSetting();
            DetailShow();
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g����\�z�����ł�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {

            this._detailsTable.Columns.Add(ENTER_CODE, typeof(string));
            this._detailsTable.Columns.Add(ENTER_NAME, typeof(string));

            this.uGrid_Details.DataSource = _detailsTable;
        }

        /// <summary>
        /// ���R�[�h�̗�̃X�^�C���̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���R�[�h�̗�̃X�^�C���̐ݒ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void SetColumnStyle()
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // �\�����ݒ�
            Columns[this._detailsTable.Columns[ENTER_CODE].ColumnName].Width = 100;
            Columns[this._detailsTable.Columns[ENTER_NAME].ColumnName].Width = 200;

            // ���͋��ݒ�
            Columns[this._detailsTable.Columns[ENTER_CODE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._detailsTable.Columns[ENTER_NAME].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

        }

        /// <summary>
        /// �ڍ׏���\������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׏���\������</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>

        private void DetailShow()
        {
            this._detailsTable.Clear();
            try
            {
                if (_enterpriseCodeList != null && _enterpriseCodeList.Count > 0)
                {
                    for (int i = 0; i < _enterpriseCodeList.Count - 1; i++)
                    {
                        DataRow row = this._detailsTable.NewRow();
                        row[_detailsTable.Columns[ENTER_CODE].ColumnName] = _enterpriseCodeList[i];
                        row[_detailsTable.Columns[ENTER_NAME].ColumnName] = _enterpriseCodeList[++i];
                        this._detailsTable.Rows.Add(row);
                    }
                }
                else
                {
                    DataRow row = this._detailsTable.NewRow();
                    row[_detailsTable.Columns[ENTER_CODE].ColumnName] = "";
                    row[_detailsTable.Columns[ENTER_NAME].ColumnName] = "";
                    this._detailsTable.Rows.Add(row);
                }
                this.uGrid_Details.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                this.Close();

                TMsgDisp.Show(this,                                 // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                            CT_CLASSID,
                            ex.Message,
                             0,									    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
            }

        }

        #endregion �� Private Method ��



        #region �� Event ��

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ToolClickEventArgs</param>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�N���b�N�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Cancel":
                    {
                        //��ʕ���B
                        this.Close();
                    }
                    break;

                case "ButtonTool_Select":
                    {
                        if ((string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_CODE].ColumnName].Value != null && (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_NAME].ColumnName].Value != null)
                        {
                            _PMKYO09501UA.PmEnterpriseCode = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_CODE].ColumnName].Value;
                            _PMKYO09501UA.PmEnterpriseCodeName = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_NAME].ColumnName].Value;
                            this.Close();
                        }

                    }
                    break;
            }
        }

        /// <summary>
        /// ���R�[�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">DoubleClickCellEventArgs</param>
        /// <remarks>
        /// <br>Note       : ���R�[�h�_�u���N���b�N�C�x���g</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void uGrid_Details_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (e.Cell != null)
            {
                _PMKYO09501UA.PmEnterpriseCode = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_CODE].ColumnName].Value;
                _PMKYO09501UA.PmEnterpriseCodeName = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_NAME].ColumnName].Value;
                this.Close();
            }
        }

        /// <summary>
        /// KeyDown����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ��ƃR�[�h�O���b�h�̃}�E�X�E�N���b�N�����B</br>
        /// <br>Programmer  : </br>
        /// <br>Date        : 2012/07/25</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (uGrid_Details.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    _PMKYO09501UA.PmEnterpriseCode = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_CODE].ColumnName].Value;
                    _PMKYO09501UA.PmEnterpriseCodeName = (string)this.uGrid_Details.ActiveRow.Cells[_detailsTable.Columns[ENTER_NAME].ColumnName].Value;
                    this.Close();
                }
            }
        }

        #endregion �� Event ��
    }
}