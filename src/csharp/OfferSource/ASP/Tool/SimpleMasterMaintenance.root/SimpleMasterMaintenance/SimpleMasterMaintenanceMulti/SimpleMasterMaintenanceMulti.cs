using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ȈՃ}�X�����}���`�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �ȈՃ}�X�����̈ꗗ�ҏW�^�C�v�t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 23001 �H�R�@����</br>
	/// <br>Date       : 2007.03.26</br>
	/// </remarks>
	public partial class SimpleMasterMaintenanceMulti : Form
	{
		#region << Constructor >>

		/// <summary>
		/// �ȈՃ}�X�����}���`�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ȈՃ}�X�����}���`�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public SimpleMasterMaintenanceMulti( Form editForm ) : this()
		{
			this._editForm                      = editForm;
			this._iSimpleMasterMaintenanceMulti = this._editForm as ISimpleMasterMaintenanceMulti;

			if( ( this._editForm == null ) || 
				( this._iSimpleMasterMaintenanceMulti == null ) ) {
				throw( new Exception( "�ҏW�t�H�[���̓ǂݍ��݂Ɏ��s���܂����B" ) );
			}

			// �C�x���g�ݒ�
			this._editForm.VisibleChanged += new EventHandler( this.EditForm_VisibleChanged );
		}

		/// <summary>
		/// �ȈՃ}�X�����}���`�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ȈՃ}�X�����}���`�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public SimpleMasterMaintenanceMulti( Assembly assembly, string className, Type type ) : this()
		{
			this._editForm                      = this.LoadAssembly( assembly, className, type ) as Form;
			this._iSimpleMasterMaintenanceMulti = this._editForm as ISimpleMasterMaintenanceMulti;

			if( ( this._editForm == null ) || 
				( this._iSimpleMasterMaintenanceMulti == null ) ) {
				throw( new Exception( "�ҏW�t�H�[���̓ǂݍ��݂Ɏ��s���܂����B" ) );
			}

			// �C�x���g�ݒ�
			this._editForm.VisibleChanged += new EventHandler( this.EditForm_VisibleChanged );
		}

		/// <summary>
		/// �ȈՃ}�X�����}���`�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ȈՃ}�X�����}���`�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public SimpleMasterMaintenanceMulti( string assemblyName, string className, Type type ) : this()
		{
			this._editForm                      = this.LoadAssembly( assemblyName, className, type ) as Form;
			this._iSimpleMasterMaintenanceMulti = this._editForm as ISimpleMasterMaintenanceMulti;

			if( ( this._editForm == null ) || 
				( this._iSimpleMasterMaintenanceMulti == null ) ) {
				throw( new Exception( "�ҏW�t�H�[���̓ǂݍ��݂Ɏ��s���܂����B" ) );
			}

			// �C�x���g�ݒ�
			this._editForm.VisibleChanged += new EventHandler( this.EditForm_VisibleChanged );
		}

		/// <summary>
		/// �ȈՃ}�X�����}���`�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ȈՃ}�X�����}���`�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private SimpleMasterMaintenanceMulti()
		{
			InitializeComponent();
		}

		#endregion

		#region << Private Members >>

		/// <summary>�ҏW�t�H�[��</summary>
		private Form                                 _editForm                      = null;
		/// <summary>�ȈՃ}�X�����}���`�t�H�[���ҏW�C���^�[�t�F�[�X</summary>
		private ISimpleMasterMaintenanceMulti        _iSimpleMasterMaintenanceMulti = null;

		/// <summary>�ꗗ�\���pDataSet</summary>
		private DataSet                              _dataSet                       = null;
		/// <summary>�ꗗ�\���pDataMember</summary>
		private string                               _dataMember                    = null;
		/// <summary>�O���b�h��O�ϐݒ�</summary>
		private Dictionary<string,GridColAppearance> _gridColAppearanceDictionary   = null;

		/// <summary>�I�v�V�����c�[��</summary>
		private SortedList<string,ToolStripItem>     _optionTools                   = null;

		#endregion

		#region << Private Methods >>

		#region ���A�Z���u�����[�h����

		/// <summary>
		/// �A�Z���u�����[�h����
		/// </summary>
		/// <param name="asmName">�A�Z���u����</param>
		/// <param name="className">�N���X��</param>
		/// <param name="type">�N���X�̌^</param>
		/// <returns>�I�u�W�F�N�g�C���X�^���X</returns>
		private object LoadAssembly( string asmName, string className, Type type )
		{
			string asmPath = Path.Combine( Path.GetDirectoryName( Application.ExecutablePath ), asmName );
			Assembly assembly = System.Reflection.Assembly.LoadFrom( asmPath );
			return this.LoadAssembly( assembly, className, type );
		}

		/// <summary>
		/// �A�Z���u�����[�h����
		/// </summary>
		/// <param name="assembly">�A�Z���u���N���X</param>
		/// <param name="className">�N���X��</param>
		/// <param name="type">�N���X�̌^</param>
		/// <returns>�I�u�W�F�N�g�C���X�^���X</returns>
		private object LoadAssembly( Assembly assembly, string className, Type type )
		{
			object obj = null;
			Type objType = assembly.GetType( className );
			if( objType != null ) {
				if( ( objType == type ) || ( objType.IsSubclassOf( type ) == true ) || ( objType.GetInterface( type.Name ).Name == type.Name ) ) {
					obj = Activator.CreateInstance( objType );
				}
			}

			return obj;
		}

		#endregion

		#region �������ݒ菈��

		/// <summary>
		/// �����ݒ菈��
		/// </summary>
		private void InitializeSetting()
		{
			// �V�K�E�폜�̗L���ݒ�
			this.NewData_toolStripMenuItem.Visible  = this._iSimpleMasterMaintenanceMulti.AllowNew;
			this.DelData_toolStripMenuItem.Visible  = this._iSimpleMasterMaintenanceMulti.AllowDelete;
			this.NewData_toolStripButton.Visible    = this._iSimpleMasterMaintenanceMulti.AllowNew;
			this.DelData_toolStripButton.Visible    = this._iSimpleMasterMaintenanceMulti.AllowDelete;

			// �I�v�V�����c�[�����擾
			this._iSimpleMasterMaintenanceMulti.GetOptionTools( ref this._optionTools );
			if( this._optionTools != null ) {
				// �I�v�V�����c�[�����j���[�쐬
				this.CreateOptionToolMenuItems( this._optionTools );
			}
			else {
				// �I�v�V�����c�[�����j���[��\��
				this.Tool_toolStripMenuItem.Visible = false;
			}

			// DataSet ���擾
			this._iSimpleMasterMaintenanceMulti.GetDataSet( ref this._dataSet, ref this._dataMember );
			// Grid �Ƀo�C���h
			this.SearchData_dataGridView.DataSource = this._dataSet;
			this.SearchData_dataGridView.DataMember = this._dataMember;

			// �O���b�h��O�ϐݒ�擾
			this._gridColAppearanceDictionary = this._iSimpleMasterMaintenanceMulti.GetGridColAppearance();
			// �O���b�h��O�ϐݒ菈��
			this.SettingGridColAppearance( this._gridColAppearanceDictionary );
		}

		#endregion

		#region ���I�v�V�����c�[�����j���[��������

		/// <summary>
		/// �I�v�V�����c�[�����j���[��������
		/// </summary>
		/// <param name="optionTools">�I�v�V�����c�[��</param>
		private void CreateOptionToolMenuItems( SortedList<string,ToolStripItem> optionTools )
		{
			this.Tool_toolStripMenuItem.DropDownItems.Clear();
			foreach( KeyValuePair<string,ToolStripItem> keyValue in optionTools )
			{
				ToolStripItem item = keyValue.Value;
				string        key  = keyValue.Key;

				item.Name  = "OptionTool_" + key;
				item.Click += new EventHandler( this.OptionTool_toolStripItem_Click );

				this.Tool_toolStripMenuItem.DropDownItems.Add( item );
			}
		}

		#endregion

		#region ���O���b�h��O�ϐݒ菈��

		/// <summary>
		/// �O���b�h��O�ϐݒ菈��
		/// </summary>
		/// <param name="gridColAppearanceDictionary">�O���b�h��O�ϐݒ�</param>
		private void SettingGridColAppearance( Dictionary<string,GridColAppearance> gridColAppearanceDictionary )
		{
            if (gridColAppearanceDictionary == null)
            {
                return;
            }

            // �����ɃC���f�b�N�X��U��Ȃ���
            List<DataGridViewColumn> dataGridViewColumnList = new List<DataGridViewColumn>();
            dataGridViewColumnList.AddRange( ( DataGridViewColumn[] ) ( new ArrayList( this.SearchData_dataGridView.Columns ) ).ToArray( typeof( DataGridViewColumn )));
            dataGridViewColumnList.Sort(new Comparison<DataGridViewColumn>(delegate(DataGridViewColumn x, DataGridViewColumn y)
            {
                GridColAppearance xApp = null;
                GridColAppearance yApp = null;

                // �O���b�h��O�ϐݒ肪���邩
                if (gridColAppearanceDictionary.ContainsKey(x.Name))
                {
                    xApp = gridColAppearanceDictionary[x.Name];
                }
                // �O���b�h��O�ϐݒ肪���邩
                if (gridColAppearanceDictionary.ContainsKey(y.Name))
                {
                    yApp = gridColAppearanceDictionary[y.Name];
                }

                if (xApp == null && yApp == null)
                {
                    return 0;
                }
                if (xApp != null && yApp == null)
                {
                    return 1;
                }
                if (xApp == null && yApp != null)
                {
                    return -1;
                }

                return xApp.DisplayIndex.CompareTo(yApp.DisplayIndex);
            }));

            int displayIndex = 0;
			// �e�񂲂Ƃɐݒ�
            foreach (DataGridViewColumn column in dataGridViewColumnList)
            {
				// �O���b�h��O�ϐݒ肪���邩
				if( ( gridColAppearanceDictionary != null ) && 
					( gridColAppearanceDictionary.ContainsKey( column.Name ) ) ) {

					// �O���b�h��O�ϐݒ�擾
					GridColAppearance gridColAppearance = gridColAppearanceDictionary[ column.Name ];

					// �\���C���f�b�N�X
                    column.DisplayIndex = displayIndex++;

					// �L���v�V����
					if( ! String.IsNullOrEmpty( gridColAppearance.Caption ) ) {
						column.HeaderText                      = gridColAppearance.Caption;
					}

					// �Z���̓��e�̕\���ʒu
					column.DefaultCellStyle.Alignment          = gridColAppearance.Alignment;

					// �Z���ɓK�p���鏑���w�蕶����
					column.DefaultCellStyle.Format             = gridColAppearance.Format;

					// �Z���̑O�i�F
					column.DefaultCellStyle.ForeColor          = gridColAppearance.ForeColor;

					// �I�����̃Z���̑O�i�F
					column.DefaultCellStyle.SelectionForeColor = gridColAppearance.SelectionForeColor;
				}
				else {
					// ���\�����Ȃ�
					column.Visible = false;
                    column.DisplayIndex = displayIndex++;
				}
			}
		}

		#endregion

		#region ����������

		/// <summary>
		/// ��������
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����������s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private int Search()
		{
			int status = -1;

			try {

				// �������s
				status = this._iSimpleMasterMaintenanceMulti.Search();
				if( status == 0 ) {
						this.SearchData_dataGridView.AutoResizeColumns( DataGridViewAutoSizeColumnsMode.DisplayedCells );
				}
			}
			catch( Exception ex ) {
				// TODO : �G���[���b�Z�[�W�\��
				MessageBox.Show( this, ex.Message, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
			}

			return status;
		}

		#endregion

		#region ���C����ʋN������

		/// <summary>
		/// �C����ʋN������
		/// </summary>
		/// <param name="isNew">�V�K���ǂ���</param>
		/// <remarks>
		/// <br>Note       : �C����ʂ��N�����܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.27</br>
		/// </remarks>
		private void RunDtlEditor( bool isNew )
		{
			int dataIndex = 0;

			// �V�K�̏ꍇ
			if( isNew ) {
				dataIndex  = -1;
			}
			// �X�V�̏ꍇ
			else {
				if( this.SearchData_dataGridView.SelectedRows.Count == 0 ) {
					return;
				}

				dataIndex = this.SearchData_dataGridView.SelectedRows[ 0 ].Index;
			}

			this._iSimpleMasterMaintenanceMulti.DataIndex = dataIndex;


			if( this._editForm.Visible ) {
				this._editForm.Hide();
			}

			this._editForm.Show( this );

			if( this._editForm.DialogResult == DialogResult.OK ) {
			}
		}

		#endregion

		#region ���폜����

		/// <summary>
		/// �폜����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �I������Ă���f�[�^�̍폜���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.30</br>
		/// </remarks>
		private void Delete()
		{
			if( this.SearchData_dataGridView.SelectedRows.Count == 0 ) {
				return;
			}

			// �폜�m�F
			DialogResult result = MessageBox.Show( 
				this, "�I������Ă���f�[�^���폜���܂��B��낵���ł����H", "�m�F", 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1 );
			if( result != DialogResult.Yes ) {
				// �폜���Ȃ�
				return;
			}

			this._iSimpleMasterMaintenanceMulti.DataIndex = this.SearchData_dataGridView.SelectedRows[ 0 ].Index;

			// �폜���s
			int status = this._iSimpleMasterMaintenanceMulti.Delete();
			if( status == 0 ) {
			}
			else {
			}
		}

		#endregion

		#endregion

		#region << Public Methods >>

		#region ����ʕ\������

		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="owner">���̃t�H�[�������L����g�b�v���x���E�B���h�E</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̕\�����s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public new void Show( IWin32Window owner )
		{
			if( this.Visible ) {
				this.Activate();
			}
			else {
				base.Show( owner );
			}
		}

		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̕\�����s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public new void Show()
		{
			if( this.Visible ) {
				this.Activate();
			}
			else {
				base.Show();
			}
		}

		#endregion

		#endregion

		#region << Control Events >>

		#region ��Load �C�x���g (SimpleMasterMaintenanceMulti)

		/// <summary>
		/// Load �C�x���g (SimpleMasterMaintenanceMulti)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������߂ĕ\�������Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void SimpleMasterMaintenanceMulti_Load( object sender, EventArgs e )
		{
			// �����ݒ菈��
			this.InitializeSetting();
			// �������s
			this.Search();
		}

		#endregion

		#region ��Click �C�x���g (Exit_toolStripMenuItem)

		/// <summary>
		/// Click �C�x���g (Exit_toolStripMenuItem)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void Exit_toolStripMenuItem_Click( object sender, EventArgs e )
		{
			// �I��
			this.Close();
		}

		#endregion

		#region ��Click �C�x���g (NewData_toolStripMenuItem)

		/// <summary>
		/// Click �C�x���g (NewData_toolStripMenuItem)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void NewData_toolStripMenuItem_Click( object sender, EventArgs e )
		{
			// �ҏW��ʋN��
			this.RunDtlEditor( true );
		}

		#endregion

		#region ��Click �C�x���g (FixData_toolStripMenuItem)

		/// <summary>
		/// Click �C�x���g (FixData_toolStripMenuItem)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void FixData_toolStripMenuItem_Click( object sender, EventArgs e )
		{
			// �ҏW��ʋN��
			this.RunDtlEditor( false );
		}

		#endregion

		#region ��Click �C�x���g (DelData_toolStripMenuItem)

		/// <summary>
		/// Click �C�x���g (DelData_toolStripMenuItem)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void DelData_toolStripMenuItem_Click( object sender, EventArgs e )
		{
			// �폜����
			this.Delete();
		}

		#endregion

		#region ��MouseDoubleClick �C�x���g (PgMulcasGd_dataGridView)

		/// <summary>
		/// MouseDoubleClick �C�x���g (PgMulcasGd_dataGridView)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �}�E�X���_�u���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void PgMulcasGd_dataGridView_MouseDoubleClick( object sender, MouseEventArgs e )
		{
			// �}�E�X�J�[�\��������ꏊ�̏����擾
			DataGridView.HitTestInfo hitTestInfo = this.SearchData_dataGridView.HitTest( e.X, e.Y );
			// �Z���ォ�A�s�w�b�_�̏ꍇ�̂ݎ��s
			if( ( hitTestInfo.Type == DataGridViewHitTestType.Cell ) || 
				( hitTestInfo.Type == DataGridViewHitTestType.RowHeader ) ) {
				// �ҏW��ʋN��
				this.RunDtlEditor( false );
			}
		}

		#endregion

		#region ��VisibleChanged �C�x���g (EditForm_VisibleChanged)

		/// <summary>
		/// VisibleChanged �C�x���g (EditForm_VisibleChanged)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : Visible �v���p�e�B�̒l���ύX���ꂽ�ꍇ�ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void EditForm_VisibleChanged( object sender, EventArgs e )
		{
			if( this._editForm.Visible == true ) {
				// ���j���[�̃{�^���𖳌�
				this.NewData_toolStripMenuItem.Enabled = false;
				this.FixData_toolStripMenuItem.Enabled = false;
				this.DelData_toolStripMenuItem.Enabled = false;
				this.Exit_toolStripMenuItem.Enabled    = false;

				this.NewData_toolStripButton.Enabled   = false;
				this.FixData_toolStripButton.Enabled   = false;
				this.DelData_toolStripButton.Enabled   = false;
				this.Exit_toolStripButton.Enabled      = false;

				// �I�v�V�����c�[��������ꍇ
				if( this._optionTools != null ) {
					foreach( ToolStripItem item in this._optionTools.Values ) {
						item.Enabled                   = false;
					}
				}
			}
			else {
				// ���j���[�̃{�^����L��
				this.NewData_toolStripMenuItem.Enabled = true;
				this.FixData_toolStripMenuItem.Enabled = true;
				this.DelData_toolStripMenuItem.Enabled = true;
				this.Exit_toolStripMenuItem.Enabled    = true;

				this.NewData_toolStripButton.Enabled   = true;
				this.FixData_toolStripButton.Enabled   = true;
				this.DelData_toolStripButton.Enabled   = true;
				this.Exit_toolStripButton.Enabled      = true;

				// �I�v�V�����c�[��������ꍇ
				if( this._optionTools != null ) {
					foreach( ToolStripItem item in this._optionTools.Values ) {
						item.Enabled                   = true;
					}
				}

				// �������g���A�N�e�B�u�ɂ���
				if( ( Form.ActiveForm == null ) || 
					( Form.ActiveForm != this ) ) {
					this.Activate();
				}
			}
		}

		#endregion

		#region ��Click �C�x���g (OptionTool_toolStripItem)

		/// <summary>
		/// Click �C�x���g (OptionTool_toolStripItem)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void OptionTool_toolStripItem_Click( object sender, EventArgs e )
		{
			ToolStripItem item = sender as ToolStripItem;

			if( item == null ) {
				return;
			}

			// �L�[���擾
			string key = null;
			try {
				key = item.Name.Substring( 11 );
			}
			catch {
				return;
			}

			if( String.IsNullOrEmpty( key ) ) {
				return;
			}

			// �R�}���h����
			this._iSimpleMasterMaintenanceMulti.OptionToolCommand( key, this );
		}

		#endregion

		#endregion
	}
}