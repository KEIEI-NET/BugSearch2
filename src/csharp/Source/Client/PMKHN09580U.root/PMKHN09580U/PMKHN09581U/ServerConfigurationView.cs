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
// �� �� ��  2009/09/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �T�[�o�\���ݒ�r���[�R���g���[��
    /// </summary>
    public partial class ServerConfigurationView : UserControl
    {
        #region <Controller>

        /// <summary>�T�[�o�\���ݒ�R���g���[��</summary>
        private IServerConfigurationController _controller;
        /// <summary>�T�[�o�\���ݒ�R���g���[�����擾���܂��B</summary>
        private IServerConfigurationController Controller
        {
            get
            {
                if (_controller == null)
                {
                    _controller = CreateController();
                    _controller.UpdatingView += new UpdateViewEventHandler(OnUpdateView);
                }
                return _controller;
            }
        }

        /// <summary>
        /// �T�[�o�\���ݒ�R���g���[���𐶐����܂��B
        /// </summary>
        /// <remarks>
        /// �T�u�N���X���ŃI�[�o�[���C�h���K�{�ł��B
        /// </remarks>
        /// <returns>�e�@�\�p�̃T�[�o�\���ݒ�R���g���[�� ���v�I�[�o�[���C�h</returns>
        protected virtual IServerConfigurationController CreateController()
        {
            return null;    // TODO:�v�I�[�o�[���C�h
        }

        #endregion // </Controller>

        #region <�L���v�V����>

        /// <summary>�L���v�V����</summary>
        private string _caption;
        /// <summary>�L���v�V�������擾�܂��͐ݒ肵�܂��B</summary>
        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        #endregion // </�L���v�V����>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public ServerConfigurationView()
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>
        }

        #endregion // </Constructor>

        #region <������>

        /// <summary>
        /// �T�[�o�\���ݒ�r���[�R���g���[����Load�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ServerConfiguratorView_Load(object sender, EventArgs e)
        {
            InitializeMemberControls(); // �����o�R���g���[����������
            InitializeEventHandler();   // �C�x���g�n���h����������
        }

        /// <summary>
        /// �����o�R���g���[�������������܂��B
        /// </summary>
        private void InitializeMemberControls()
        {
            ShowImportControl();// �f�o�b�O�p
            InitializeGrid();   // �O���b�h��������
        }

        /// <summary>
        /// �C�x���g�n���h�������������܂��B
        /// </summary>
        private void InitializeEventHandler()
        {
            InitializeNewEventHandler();    // �V�K�o�^�C�x���g�n���h����������
            InitializeDeleteEventHandler(); // �폜�C�x���g�n���h����������
            InitializeEditEventHandler();   // �C���C�x���g�n���h����������
            InitializeImportEventHandler(); // �C���|�[�g�C�x���g�n���h����������
        }

        #endregion // </������>

        #region <�O���b�h>

        /// <summary>
        /// �O���b�h�̃J�����C���f�b�N�X�񋓌^
        /// </summary>
        protected enum GridColumnIndex : int
        {
            /// <summary>�폜��</summary>
            DeletedDate = 0
        }

        /// <summary>
        /// DB�\���p�O���b�h���擾���܂��B
        /// </summary>
        protected DataGridView GridDB
        {
            get { return this.gridDB; }
        }

        /// <summary>
        /// �O���b�h�����������܂��B
        /// </summary>
        private void InitializeGrid()
        {
            RefleshGrid();
        }

        /// <summary>
        /// �O���b�h�̕\�����X�V���܂��B
        /// </summary>
        protected void RefleshGrid()
        {
            // �f�[�^�\�[�X��ݒ�
            GridDB.DataSource = GetBindingData();

            // �O���b�h�̃J����������ݒ�
            SetGridColumnsProperty();

            // �폜�ς݃f�[�^���t�B���^
            FilterDeletedData(VisiblesDeletedData);

            // ��T�C�Y�̎�������
            SetGridAutoSizeColumnsMode();
        }

        /// <summary>
        /// �O���b�h�Ƀo�C���h����f�[�^���擾���܂��B
        /// </summary>
        /// <returns>
        /// <c>Controller.DefaultView</c>
        /// </returns>
        private object GetBindingData()
        {
            return Controller.DefaultView;
        }

        /// <summary>
        /// �폜�ς݃f�[�^���t�B���^���܂��B
        /// </summary>
        /// <param name="showingAllData">�S�f�[�^��\������t���O</param>
        private void FilterDeletedData(bool showingAllData)
        {
            Controller.DefaultView.RowFilter = showingAllData ? string.Empty : GetAvailableRecordQuery();

            // �\���F��ύX
            if (string.IsNullOrEmpty(Controller.DefaultView.RowFilter))
            {
                foreach (DataGridViewRow row in GridDB.Rows)
                {
                    row.Cells[(int)GridColumnIndex.DeletedDate].Style.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// �L���ȃ��R�[�h�̏��������擾���܂��B
        /// </summary>
        /// <returns>"LogicalDeleteCode = 0"</returns>
        protected virtual string GetAvailableRecordQuery()
        {
            return "LogicalDeleteCode = 0";
        }

        /// <summary>
        /// �O���b�h�̃J����������ݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// �w�b�_�̖��̂��f�[�^�e�[�u���̃L���v�V�����Őݒ肵�܂��B
        /// </remarks>
        private void SetGridColumnsProperty()
        {
            List<string> hideColumnNameList = CreateHideColumnNameList();

            foreach (DataGridViewColumn column in GridDB.Columns)
            {
                DataColumn dataColumn = ((DataView)GridDB.DataSource).Table.Columns[column.Index];
                {
                    column.HeaderText = dataColumn.Caption;

                    column.Visible = !hideColumnNameList.Exists(
                        delegate(string item)
                        {
                            return dataColumn.ColumnName.Equals(item);
                        }
                    );
                }
                // �폜���͐擪�ɕ\��
                if (IsDeletedDateColumn(dataColumn.ColumnName))
                {
                    column.DisplayIndex = (int)GridColumnIndex.DeletedDate;
                }
            }
        }

        /// <summary>
        /// �B���J�������̃��X�g�𐶐����܂��B
        /// </summary>
        /// <returns>�B���J�������̃��X�g</returns>
        protected virtual List<string> CreateHideColumnNameList()
        {
            return new List<string>();
        }

        /// <summary>�f�t�H���g�폜���J������</summary>
        protected const string DEFAULT_DELETEAD_DATE_COLUMN_NAME = "DeletedDate";

        /// <summary>
        /// �폜���J�����ł��邩���f���܂��B
        /// </summary>
        /// <param name="columnName">�J������</param>
        /// <returns>
        /// <c>true</c> :�폜���J�����ł��B<br/>
        /// <c>false</c>:�폜���J�����ł͂���܂���B
        /// </returns>
        protected virtual bool IsDeletedDateColumn(string columnName)
        {
            return columnName.Equals(DEFAULT_DELETEAD_DATE_COLUMN_NAME);
        }

        /// <summary>
        /// DB�\���p�O���b�h��MouseDoubleClick�C�x���g�n���h��
        /// </summary>
        /// <remarks>
        /// �C���������s���܂��B���̏������s���ꍇ�A�T�u�N���X���ŃI�[�o�[���C�h���邱�ƁB
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected virtual void ActOnGridCellMouseDoubleClick(
            object sender,
            DataGridViewCellMouseEventArgs e
        )
        {
            OnEdit(sender, new EditEventArgs(e));
        }

        /// <summary>
        /// DB�\���p�O���b�h��MouseDoubleClick�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void gridDB_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ActOnGridCellMouseDoubleClick(sender, e);
        }

        /// <summary>null��\���C���f�b�N�X</summary>
        private const int NULL_INDEX = -1;

        /// <summary>�f�t�H���g�J�����̃C���f�b�N�X</summary>
        private int _defaultColumnIndex = NULL_INDEX;
        /// <summary>�f�t�H���g�J�����̃C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</summary>
        private int DefaultColumnIndex
        {
            get { return _defaultColumnIndex; }
            set { _defaultColumnIndex = value; }
        }

        /// <summary>
        /// DB�\���p�O���b�h��KeyDown�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void gridDB_KeyDown(object sender, KeyEventArgs e)
        {
            // [Enter]�L�[�������͏C��
            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.Handled = true;
                OnEdit(sender, new EditEventArgs(e));
                return;
            }

            // [Tab]�L�[�������͑I���s���ړ�
            if (e.KeyCode.Equals(Keys.Tab))
            {
                if (DefaultColumnIndex.Equals(NULL_INDEX))
                {
                    DefaultColumnIndex = GridDB.CurrentCell.ColumnIndex;
                }

                if (!e.Shift)
                {
                    if (GridDB.CurrentRow.Index + 1 < GridDB.Rows.Count)
                    {
                        GridDB.CurrentCell = GridDB[DefaultColumnIndex, GridDB.CurrentCell.RowIndex + 1];
                        GridDB.CurrentCell.Selected = true;
                    }
                    else
                    {
                        this.chkAdjustAutomatically.Focus();    // TODO:���̈ړ���R���g���[�����擾�������������͂�
                    }
                }
                else
                {
                    if (GridDB.CurrentRow.Index - 1 >= 0)
                    {
                        GridDB.CurrentCell = GridDB[DefaultColumnIndex, GridDB.CurrentCell.RowIndex];
                        GridDB.CurrentCell.Selected = true;
                    }
                    else
                    {
                        this.btnEdit.Focus();   // TODO:�O�̈ړ���R���g���[�����擾�������������͂�
                    }
                }

                return;
            }   // if (e.KeyCode.Equals(Keys.Tab))
        }

        #endregion // </�O���b�h>

        #region <�V�K����>

        /// <summary>�V�K�o�^�C�x���g</summary>
        public event NewEventHandler Newing;

        /// <summary>
        /// �V�K�o�^�C�x���g�n���h�������������܂��B
        /// </summary>
        private void InitializeNewEventHandler()
        {
            Newing += new NewEventHandler(OnNew);
        }

        /// <summary>
        /// �V�K�o�^���܂��B
        /// </summary>
        /// <remarks>
        /// �V�K�o�^�@�\������ꍇ�A�T�u�N���X���ŃI�[�o�[���C�h���邱�ƁB
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected virtual void OnNew(
            object sender,
            NewEventArgs e
        )
        {
            Debug.WriteLine("�f�t�H���g�V�K�o�^����");
        }

        /// <summary>
        /// [�V�K]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            Newing(sender, new NewEventArgs(e));
        }

        #endregion // </�V�K����>

        #region <�폜����>

        /// <summary>�폜�C�x���g</summary>
        public event DeleteEventHandler Deleting;

        /// <summary>
        /// �폜�C�x���g�n���h�������������܂��B
        /// </summary>
        private void InitializeDeleteEventHandler()
        {
            Deleting += new DeleteEventHandler(OnDelete);
        }

        /// <summary>
        /// �폜���܂��B
        /// </summary>
        /// <remarks>
        /// �폜�@�\������ꍇ�A�T�u�N���X���ŃI�[�o�[���C�h���邱�ƁB
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected virtual void OnDelete(
            object sender,
            DeleteEventArgs e
        )
        {
            Debug.WriteLine("�f�t�H���g�폜����");
        }

        /// <summary>
        /// [�폜]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Deleting(sender, new DeleteEventArgs(e));
        }

        #endregion // </�폜����>

        #region <�C������>

        /// <summary>�C���C�x���g</summary>
        public event EditEventHandler Editing;

        /// <summary>
        /// �C���C�x���g�n���h�������������܂��B
        /// </summary>
        private void InitializeEditEventHandler()
        {
            Editing += new EditEventHandler(OnEdit);
        }

        /// <summary>
        /// �C�����܂��B
        /// </summary>
        /// <remarks>
        /// �C���@�\������ꍇ�A�T�u�N���X���ŃI�[�o�[���C�h���邱�ƁB
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected virtual void OnEdit(
            object sender,
            EditEventArgs e
        )
        {
            Debug.WriteLine("�f�t�H���g�C������");
        }

        /// <summary>
        /// [�C��]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Editing(sender, new EditEventArgs(e));
        }

        #endregion // </�C������>

        #region <�C���|�[�g����>

        /// <summary>�C���|�[�g�C�x���g</summary>
        public event ImportEventHandler Importing;

        /// <summary>
        /// [�C���|�[�g]�{�^����\�����܂��B
        /// </summary>
        [Conditional("DEBUG")]
        private void ShowImportControl()
        {
            this.btnImport.Visible = true;
        }

        /// <summary>
        /// �C���|�[�g�C�x���g�n���h�������������܂��B
        /// </summary>
        private void InitializeImportEventHandler()
        {
            Importing += new ImportEventHandler(OnImport);
        }

        /// <summary>
        /// �C���|�[�g���܂��B
        /// </summary>
        /// <remarks>
        /// �C���|�[�g�@�\������ꍇ�A�T�u�N���X���ŃI�[�o�[���C�h���邱�ƁB
        /// </remarks>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected virtual void OnImport(
            object sender,
            ImportEventArgs e
        )
        {
            Controller.Import();
            RefleshGrid();
        }

        /// <summary>
        /// [�C���|�[�g]�{�^����Click�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            Importing(sender, new ImportEventArgs(e));
        }

        #endregion // <�C���|�[�g����>

        #region <�폜�ς݃f�[�^�̕\��>

        /// <summary>
        /// �폜�ς݃f�[�^��\�����邩���f���܂��B
        /// </summary>
        /// <value>
        /// <c>true</c> :�폜�ς݃f�[�^��\�����܂��B<br/>
        /// <c>false</c>:�폜�ς݃f�[�^��\�����܂���B
        /// </value>
        protected bool VisiblesDeletedData
        {
            get { return this.chkShowDeletedData.Checked; }
        }

        /// <summary>
        /// [�폜�ς݃f�[�^��\������]�`�F�b�N�{�b�N�X��CheckedChangeed�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void chkShowDeletedData_CheckedChanged(object sender, EventArgs e)
        {
            RefleshGrid();
        }

        #endregion // </�폜�ς݃f�[�^�̕\��>

        #region <��T�C�Y�̎�������>

        /// <summary>
        /// ��T�C�Y�̎����������s���܂��B
        /// </summary>
        private void SetGridAutoSizeColumnsMode()
        {
            // ��T�C�Y�̎�������
            if (this.chkAdjustAutomatically.Checked)
            {
                GridDB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
            {
                GridDB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }

        /// <summary>
        /// [��T�C�Y�̎�������]�`�F�b�N�{�b�N�X��CheckedChangeed�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void chkAdjustAutomatically_CheckedChanged(object sender, EventArgs e)
        {
            SetGridAutoSizeColumnsMode();
        }

        #endregion // </��T�C�Y�̎�������>

        #region <�\���X�V>

        /// <summary>
        /// �\�����X�V����C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        protected virtual void OnUpdateView(
            object sender,
            UpdateViewEventArgs e
        )
        {
            RefleshGrid();
        }

        #endregion // </�\���X�V>
    }

    #region <�V�K�o�^�C�x���g��`>

    /// <summary>
    /// �V�K�o�^�C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�p�����[�^</param>
    public delegate void NewEventHandler(
        object sender,
        NewEventArgs e
    );

    /// <summary>
    /// �V�K�o�^�C�x���g�p�����[�^�N���X
    /// </summary>
    public sealed class NewEventArgs : EventArgs
    {
        #region <���ƂȂ����C�x���g�̃p�����[�^>

        /// <summary>���ƂȂ����C�x���g�̃p�����[�^</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>���ƂȂ����C�x���g�̃p�����[�^���擾���܂��B</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </���ƂȂ����C�x���g�̃p�����[�^>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="innerEventArgs">���ƂȂ����C�x���g�̃p�����[�^</param>
        public NewEventArgs(EventArgs innerEventArgs)
            : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </�V�K�o�^�C�x���g��`>

    #region <�폜�C�x���g��`>

    /// <summary>
    /// �폜�C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�p�����[�^</param>
    public delegate void DeleteEventHandler(
        object sender,
        DeleteEventArgs e
    );

    /// <summary>
    /// �폜�C�x���g�p�����[�^�N���X
    /// </summary>
    public sealed class DeleteEventArgs : EventArgs
    {
        #region <���ƂȂ����C�x���g�̃p�����[�^>

        /// <summary>���ƂȂ����C�x���g�̃p�����[�^</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>���ƂȂ����C�x���g�̃p�����[�^���擾���܂��B</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </���ƂȂ����C�x���g�̃p�����[�^>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="innerEventArgs">���ƂȂ����C�x���g�̃p�����[�^</param>
        public DeleteEventArgs(EventArgs innerEventArgs) : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </�폜�C�x���g��`>

    #region <�C���C�x���g��`>

    /// <summary>
    /// �C���C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�p�����[�^</param>
    public delegate void EditEventHandler(
        object sender,
        EditEventArgs e
    );

    /// <summary>
    /// �C���C�x���g�p�����[�^�N���X
    /// </summary>
    public sealed class EditEventArgs : EventArgs
    {
        #region <���ƂȂ����C�x���g�̃p�����[�^>

        /// <summary>���ƂȂ����C�x���g�̃p�����[�^</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>���ƂȂ����C�x���g�̃p�����[�^���擾���܂��B</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </���ƂȂ����C�x���g�̃p�����[�^>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="innerEventArgs">���ƂȂ����C�x���g�̃p�����[�^</param>
        public EditEventArgs(EventArgs innerEventArgs) : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </�C���C�x���g��`>

    #region <�C���|�[�g�C�x���g��`>

    /// <summary>
    /// �C���|�[�g�C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�p�����[�^</param>
    public delegate void ImportEventHandler(
        object sender,
        ImportEventArgs e
    );

    /// <summary>
    /// �C���|�[�g�C�x���g�p�����[�^�N���X
    /// </summary>
    public sealed class ImportEventArgs : EventArgs
    {
        #region <���ƂȂ����C�x���g�̃p�����[�^>

        /// <summary>���ƂȂ����C�x���g�̃p�����[�^</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>���ƂȂ����C�x���g�̃p�����[�^���擾���܂��B</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </���ƂȂ����C�x���g�̃p�����[�^>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="innerEventArgs">���ƂȂ����C�x���g�̃p�����[�^</param>
        public ImportEventArgs(EventArgs innerEventArgs)
            : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </�C���|�[�g�C�x���g��`>
}
