using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R���[�󎚈ʒuExportUI�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚈ʒu�ݒ����Export���s���ׂ�UI��ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.11.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class SFANL08170UA : Form
	{
		#region Const
		// �c�[���{�^���p
		private const string ctButtonTool_SelectALL = "SelectAll_ButtonTool";
		private const string ctButtonTool_CancelALL = "CancelAll_ButtonTool";
		// �X�L�[�}�p
		private const string TBL_FREPRTEXPORT = "FrePrtExport";
		private const string COL_FREPRTEXPORT_EXPORTEDFLG			= "ExportedFlg";			// �G�N�X�|�[�g�ς݃t���O
		private const string COL_FREPRTEXPORT_EXTRACTIONITDEDFLG	= "ExtractionItdedFlg";		// ���o�Ώۃt���O
		private const string COL_FREPRTEXPORT_ENTERPRISECODE		= "EnterpriseCode";			// ��ƃR�[�h
		private const string COL_FREPRTEXPORT_OUTPUTFORMFILENAME	= "OutputFormFileName";		// �o�̓t�@�C����
		private const string COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO	= "UserPrtPprIdDerivNo";	// ���[�U�[���[ID�}�ԍ�
		private const string COL_FREPRTEXPORT_DISPLAYNAME			= "DisplayName";			// �o�͖���
		private const string COL_FREPRTEXPORT_PRTPPRUSERDERIVNOCMT	= "PrtPprUserDerivNoCmt";	// ���[���[�U�[�}�ԃR�����g
		private const string COL_FREPRTEXPORT_EXPORTDATAFILEPATH	= "ExportDataFilePath";		// �G�N�X�|�[�g�f�[�^�t�@�C���p�X
		private const string COL_FREPRTEXPORT_DATAINPUTSYSTEM		= "DataInputSystem";		// �f�[�^���̓V�X�e��
		private const string COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD	= "PrintPaperUseDivcd";		// ���[�g�p�敪
		private const string COL_FREPRTEXPORT_NOTE					= "Note";					// ���l
		private const string COL_FREPRTEXPORT_SLIPKINDENTRYDIV1		= "SlipKindEntryDiv1";		// �`�[��ʓo�^�敪1
		private const string COL_FREPRTEXPORT_SLIPKINDENTRYDIV2		= "SlipKindEntryDiv2";		// �`�[��ʓo�^�敪2
		private const string COL_FREPRTEXPORT_SLIPKINDENTRYDIV3		= "SlipKindEntryDiv3";		// �`�[��ʓo�^�敪3
		private const string COL_FREPRTEXPORT_SLIPKINDENTRYDIV4		= "SlipKindEntryDiv4";		// �`�[��ʓo�^�敪4
		private const string COL_FREPRTEXPORT_SLIPPRTKIND			= "SlipPrtKind";			// �`�[������
		private const string COL_FREPRTEXPORT_ERRORMESSAGE			= "ErrorMessage";			// �G���[���b�Z�[�W
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
        private const string COL_FREPRTEXPORT_FREEPRTPPRITEMGRPCD   = "FreePrtPprItemGrpCd";    // ���R���[������ڃO���[�v�R�[�h
        private const string COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD   = "FreePrtPprSpPrpseCd";    // ���R���[����p�r�R�[�h
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ������ �e��A�N�Z�X�N���X ������
		// --------------------------------------------------------
		// ���R���[Export�A�N�Z�X�N���X
		private FrePrtPSetExportAcs	_frePrtPSetExportAcs;

		// --------------------------------------------------------
		// ������ ���̑����[�N�ϐ� ������
		// --------------------------------------------------------
		// Grid�o�C���h�pDataTable
		private DataTable			_dt;
		// Export���t���O
		private bool				_isInExport;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08170UA()
		{
			InitializeComponent();

			_frePrtPSetExportAcs = new FrePrtPSetExportAcs();
			_frePrtPSetExportAcs.FrePrtPSetExported += new FrePrtPSetExportAcs.FrePrtPSetExportEventHandler(FrePrtPSetExportAcs_FrePrtPSetExported);

			InitializeSetting();
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// �����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �����ݒ���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void InitializeSetting()
		{
			this.Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// �S�I��
			ButtonTool selectAllButton = (ButtonTool)this.Main_ToolbarsManager.Tools[ctButtonTool_SelectALL];
			if (selectAllButton != null) selectAllButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLSELECT;
			// �S����
			ButtonTool cancelAllButton = (ButtonTool)this.Main_ToolbarsManager.Tools[ctButtonTool_CancelALL];
			if (cancelAllButton != null) cancelAllButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
			// �G�N�X�|�[�g�{�^��
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
			//this.ubExport.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.EXPORT];
            this.ubExport.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CSVOUTPUT];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			// �L�����Z���{�^��
			this.ubCancel.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.CLOSE];

			// DataTable�̃X�L�[�}�ݒ�
			_dt = new DataTable(TBL_FREPRTEXPORT);
			_dt.Columns.Add(COL_FREPRTEXPORT_EXTRACTIONITDEDFLG,	typeof(int));		// ���o�Ώۃt���O
			_dt.Columns.Add(COL_FREPRTEXPORT_ENTERPRISECODE,		typeof(string));	// ��ƃR�[�h
			_dt.Columns.Add(COL_FREPRTEXPORT_OUTPUTFORMFILENAME,	typeof(string));	// �o�̓t�@�C����
			_dt.Columns.Add(COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO,	typeof(int));		// ���[�U�[���[ID�}�ԍ�
			_dt.Columns.Add(COL_FREPRTEXPORT_DATAINPUTSYSTEM,		typeof(int));		// �f�[�^���̓V�X�e��
			_dt.Columns.Add(COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD,	typeof(int));		// ���[�g�p�敪
			_dt.Columns.Add(COL_FREPRTEXPORT_DISPLAYNAME,			typeof(string));	// �o�͖���
			_dt.Columns.Add(COL_FREPRTEXPORT_PRTPPRUSERDERIVNOCMT,	typeof(string));	// ���[���[�U�[�}�ԃR�����g
			_dt.Columns.Add(COL_FREPRTEXPORT_EXPORTDATAFILEPATH,	typeof(string));	// �G�N�X�|�[�g�f�[�^�t�@�C���p�X
			_dt.Columns.Add(COL_FREPRTEXPORT_NOTE,					typeof(string));	// ���l
			_dt.Columns.Add(COL_FREPRTEXPORT_SLIPPRTKIND,			typeof(int));		// �`�[������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
            //_dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV1, typeof( int ) );		// �`�[��ʓo�^�敪1(����)
            //_dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV2, typeof( int ) );		// �`�[��ʓo�^�敪2(��)
            //_dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV3, typeof( int ) );		// �`�[��ʓo�^�敪3(�ݏo)
            //_dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV4, typeof( int ) );		// �`�[��ʓo�^�敪4(����)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
            _dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV4, typeof( int ) );		// �`�[��ʓo�^�敪4(����)
            _dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV2, typeof( int ) );		// �`�[��ʓo�^�敪2(��)
            _dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV3, typeof( int ) );		// �`�[��ʓo�^�敪3(�ݏo)
            _dt.Columns.Add( COL_FREPRTEXPORT_SLIPKINDENTRYDIV1, typeof( int ) );		// �`�[��ʓo�^�敪1(����)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
			_dt.Columns.Add(COL_FREPRTEXPORT_EXPORTEDFLG,			typeof(int));		// �G�N�X�|�[�g�ς݃t���O
			_dt.Columns.Add(COL_FREPRTEXPORT_ERRORMESSAGE,			typeof(string));	// �G���[���b�Z�[�W
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
            _dt.Columns.Add( COL_FREPRTEXPORT_FREEPRTPPRITEMGRPCD, typeof( int ) );     // ���R���[������ڃO���[�v�R�[�h
            _dt.Columns.Add( COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD, typeof( int ) );     // ���R���[���ꍀ�ڃR�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD

			// Grid�Ƀo�C���h
			this.gridExportDataSelect.DataSource = _dt;
		}

		/// <summary>
		/// �o�C���h�f�[�^�쐬����
		/// </summary>
		/// <param name="frePrtExportList">���R���[Export�f�[�^List</param>
		/// <remarks>
		/// <br>Note		: ���R���[Export�f�[�^���Grid�ւ̃o�C���h�����쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void CreateBindData(List<FrePrtExport> frePrtExportList)
		{
			foreach (FrePrtExport frePrtExport in frePrtExportList)
			{
				DataRow dr = _dt.NewRow();
				foreach (DataColumn col in _dt.Columns)
				{
					PropertyInfo propInfo = typeof(FrePrtExport).GetProperty(col.ColumnName);
					if (propInfo != null)
						dr[col.ColumnName] = propInfo.GetValue(frePrtExport, null);
				}
				dr[COL_FREPRTEXPORT_EXPORTEDFLG] = 0;
				_dt.Rows.Add(dr);
			}
		}

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="message">NG���̃��b�Z�[�W</param>
		/// <param name="rowIndex">NG���̍s�C���f�b�N</param>
		/// <param name="columnName">NG���̗񖼏�</param>
		/// <returns>�`�F�b�N����</returns>
		/// <remarks>
		/// <br>Note		: ��ʓ��e�̓��̓`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private bool InputCheck(out string message, out int rowIndex, out string columnName)
		{
			message		= string.Empty;
			rowIndex	= -1;
			columnName	= string.Empty;

			DataRow[] drArray = _dt.Select(COL_FREPRTEXPORT_EXTRACTIONITDEDFLG + "=1");
			if (drArray == null || drArray.Length == 0)
			{
				message		= "�󎚈ʒu����I�����Ă��������B";
				rowIndex	= this.gridExportDataSelect.ActiveRow.Index;
				columnName	= COL_FREPRTEXPORT_EXTRACTIONITDEDFLG;
				return false;
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
            //drArray = _dt.Select( COL_FREPRTEXPORT_EXTRACTIONITDEDFLG + "=1 AND " + COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD + "=2" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
            drArray = _dt.Select( COL_FREPRTEXPORT_EXTRACTIONITDEDFLG + "=1 AND " + COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD + "=2 AND " + COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD + "=0" );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
            if ( drArray != null )
            {
                foreach ( DataRow dr in drArray )
                {
                    if ( (int)dr[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1] == 0 &&
                        (int)dr[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2] == 0 &&
                        (int)dr[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3] == 0 &&
                        (int)dr[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4] == 0 )
                    {
                        message = "�`�[��ʂ��I������Ă��܂���B";
                        rowIndex = this.gridExportDataSelect.Rows.GetRowWithListIndex( _dt.Rows.IndexOf( dr ) ).Index;
                        columnName = COL_FREPRTEXPORT_SLIPKINDENTRYDIV1;
                        return false;
                    }
                }
            }

			return true;
		}

		/// <summary>
		/// �f�[�^�i�[�����iTo�f�[�^�A�N�Z�X�N���X�j
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���͏����f�[�^�A�N�Z�X�N���X�ɃZ�b�g���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void SetDataToAccessClass()
		{
			foreach (DataRow dr in _dt.Rows)
			{
				FrePrtExport frePrtExport =
					_frePrtPSetExportAcs.FrePrtExportList.Find(
						delegate(FrePrtExport wkFrePrtExport)
						{
							if (wkFrePrtExport.EnterpriseCode == dr[COL_FREPRTEXPORT_ENTERPRISECODE].ToString() &&
								wkFrePrtExport.OutputFormFileName == dr[COL_FREPRTEXPORT_OUTPUTFORMFILENAME].ToString() &&
								wkFrePrtExport.UserPrtPprIdDerivNo == (int)dr[COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO])
								return true;
							else
								return false;
						}
					);
				if (frePrtExport != null)
				{
					foreach (DataColumn col in _dt.Columns)
					{
						PropertyInfo propInfo = typeof(FrePrtExport).GetProperty(col.ColumnName);
						if (propInfo != null)
							propInfo.SetValue(frePrtExport, dr[col.ColumnName], null);
					}
				}
			}
		}

		/// <summary>
		/// Export����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �I���󎚈ʒu�f�[�^��Export���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void ExportProc()
		{
			_isInExport = true;

			try
			{
				string message;
				int rowIndex;
				string columnName;
				// ���̓`�F�b�N
				if (InputCheck(out message, out rowIndex, out columnName))
				{
					string filePath = string.Empty;

					DialogResult dlgRet = DialogResult.Retry;
					while (dlgRet == DialogResult.Retry)
					{
						dlgRet = this.folderBrowserDialog.ShowDialog();
						if (dlgRet == DialogResult.OK)
						{
							filePath = Path.Combine(this.folderBrowserDialog.SelectedPath, FrePrtExport.ctExportFileName);
							// �����t�@�C�������݂���ꍇ�͏㏑���m�F
							if (File.Exists(filePath))
							{
								message = "�w�肳�ꂽ�f�B���N�g���ɂ́A���ɃG�N�X�|�[�g�t�@�C�������݂��܂��B"
									+ Environment.NewLine + Environment.NewLine
									+ "���݂̃G�N�X�|�[�g�t�@�C���� �㏑�� ���� �ǉ� ���܂�����낵���ł����H";
								dlgRet = TMsgDisp.Show(
									emErrorLevel.ERR_LEVEL_QUESTION,
									Program.ctASSEMBLY_ID,
									message,
									0,
									MessageBoxButtons.OKCancel);

								// �㏑�����Ȃ��ꍇ�̓f�B���N�g���̑I�������蒼��
								if (dlgRet != DialogResult.OK)
									dlgRet = DialogResult.Retry;
							}
						}
						else
						{
							return;
						}
					}

					// ��ʏ����A�N�Z�X�N���X���̃f�[�^�ɔ��f
					SetDataToAccessClass();

					int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

					// ���ʏ��������
					SFCMN00299CA waitForm = new SFCMN00299CA();
					waitForm.DispCancelButton = false;
					waitForm.Title = "�G�N�X�|�[�g��";
					waitForm.Message = "���R���[�󎚈ʒu�̃G�N�X�|�[�g���ł��D�D�D";
					try
					{
						waitForm.Show();

						// �G�N�X�|�[�g����
						status = _frePrtPSetExportAcs.Export(filePath);
					}
					finally
					{
						waitForm.Close();
					}

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						message = "�G�N�X�|�[�g�������I�����܂����B"
							+ Environment.NewLine + Environment.NewLine
							+ "�o�͐� : " + filePath;
						TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO,		// �G���[���x��
							Program.ctASSEMBLY_ID,				// �A�Z���u���h�c�܂��̓N���X�h�c
							message,							// �\�����郁�b�Z�[�W 
							0,									// �X�e�[�^�X�l
							MessageBoxButtons.OK);				// �\������{�^��
					}
					else
					{
						TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
							Program.ctASSEMBLY_ID,				// �A�Z���u���h�c�܂��̓N���X�h�c
							this.Text,							// �v���O��������
							"ExportProc",						// ���\�b�h����
							TMsgDisp.OPE_INSERT,				// �������
							_frePrtPSetExportAcs.ErrorMessage,	// �\�����郁�b�Z�[�W 
							status,								// �X�e�[�^�X�l
							null,
							MessageBoxButtons.OK,				// �\������{�^��
							MessageBoxDefaultButton.Button1);	// �{�^���̏����t�H�[�J�X
					}
				}
				else
				{
					TMsgDisp.Show(
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO,		// �G���[���x��
						Program.ctASSEMBLY_ID,				// �A�Z���u���h�c�܂��̓N���X�h�c
						message,							// �\�����郁�b�Z�[�W 
						0,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);				// �\������{�^��

					this.gridExportDataSelect.Focus();
					this.gridExportDataSelect.Rows[rowIndex].Cells[columnName].Activate();
				}
			}
			finally
			{
				_isInExport = false;
			}
		}

		/// <summary>
		/// Search����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �I���󎚈ʒu�f�[�^��Search���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private int SearchProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				status = _frePrtPSetExportAcs.Search(LoginInfoAcquisition.EnterpriseCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						foreach (FrePrtExport frePrtExport in _frePrtPSetExportAcs.FrePrtExportList)
						{
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                            //if (frePrtExport.PrintPaperUseDivcd == 2)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                            if (frePrtExport.PrintPaperUseDivcd == 2 && frePrtExport.FreePrtPprSpPrpseCd == 0)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
							{
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                                //frePrtExport.SlipKindEntryDiv1 = 1;
                                //frePrtExport.SlipKindEntryDiv2 = 1;
                                //frePrtExport.SlipKindEntryDiv3 = 1;
                                //frePrtExport.SlipKindEntryDiv4 = 1;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                                foreach ( SlipPrtSet slipPrtSet in _frePrtPSetExportAcs.SlipPrtSetList )
                                {
                                    int derivNo;
                                    try
                                    {
                                        derivNo = Int32.Parse(slipPrtSet.SpecialPurpose2);
                                    }
                                    catch
                                    {
                                        derivNo = 0;
                                    }

                                    if ( slipPrtSet.OutputFormFileName == frePrtExport.OutputFormFileName &&
                                         derivNo == frePrtExport.UserPrtPprIdDerivNo )
                                    {
                                        switch ( slipPrtSet.SlipPrtKind )
                                        {
                                            case 30:
                                                // ����
                                                frePrtExport.SlipKindEntryDiv4 = 1;
                                                break;
                                            case 120:
                                                // ��
                                                frePrtExport.SlipKindEntryDiv2 = 1;
                                                break;
                                            case 130:
                                                // �ݏo
                                                frePrtExport.SlipKindEntryDiv3 = 1;
                                                break;
                                            case 140:
                                                // ����
                                                frePrtExport.SlipKindEntryDiv1 = 1;
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
							}
						}

						CreateBindData(_frePrtPSetExportAcs.FrePrtExportList);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						string message = "���R���[�󎚈ʒu��񂪂���܂���B"
							+ Environment.NewLine + "���R���[�󎚈ʒu����o�^���Ă��������B";
						TMsgDisp.Show(
							this,								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
							Program.ctASSEMBLY_ID,				// �A�Z���u���h�c�܂��̓N���X�h�c
							message,							// �\�����郁�b�Z�[�W 
							0,									// �X�e�[�^�X�l
							MessageBoxButtons.OK);				// �\������{�^��
						break;
					}
					default:
					{
						TMsgDisp.Show(this
							, emErrorLevel.ERR_LEVEL_STOPDISP
							, Program.ctASSEMBLY_ID
							, this.Text
							, "SearchProc"
							, TMsgDisp.OPE_INIT
							, _frePrtPSetExportAcs.ErrorMessage
							, status
							, null
							, MessageBoxButtons.OK
							, MessageBoxDefaultButton.Button1);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				string message = "���R���[�󎚈ʒu�ݒ�f�[�^���������ɂė�O���������܂����B"
					+ Environment.NewLine + ex.Message;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, Program.ctASSEMBLY_ID
					, this.Text
					, "SearchProc"
					, TMsgDisp.OPE_INIT
					, message
					, status
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
			}

			return status;
		}
		#endregion

		#region Event
		/// <summary>
		/// ���R���[Export�C�x���g
		/// </summary>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <param name="frePrtExport">���R���[Export�N���X</param>
		/// <remarks>
		/// <br>Note		: ���R���[�󎚈ʒu�ݒ肪Export�����x�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void FrePrtPSetExportAcs_FrePrtPSetExported(int status, string errMsg, FrePrtExport frePrtExport)
		{
			string filter = COL_FREPRTEXPORT_ENTERPRISECODE + "='" + frePrtExport.EnterpriseCode + "'"
				+ " AND " + COL_FREPRTEXPORT_OUTPUTFORMFILENAME + "='" + frePrtExport.OutputFormFileName + "'"
				+ " AND " + COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO + "=" + frePrtExport.UserPrtPprIdDerivNo;
			DataRow[] drArray = _dt.Select(filter);
			if (drArray != null && drArray.Length > 0)
			{
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					drArray[0][COL_FREPRTEXPORT_EXPORTEDFLG]	= 1;
					drArray[0][COL_FREPRTEXPORT_ERRORMESSAGE]	= string.Empty;
				}
				else
				{
					drArray[0][COL_FREPRTEXPORT_EXPORTEDFLG]	= 2;
					drArray[0][COL_FREPRTEXPORT_ERRORMESSAGE]	= errMsg;
					TMsgDisp.Show(this
						, emErrorLevel.ERR_LEVEL_NODISP
						, Program.ctASSEMBLY_ID
						, this.Text
						, "FrePrtPSetExportAcs_FrePrtPSetExported"
						, TMsgDisp.OPE_INSERT
						, errMsg
						, status
						, null
						, MessageBoxButtons.OK
						, MessageBoxDefaultButton.Button1);
				}
				UltraGridRow ultraGridRow = this.gridExportDataSelect.DisplayLayout.Rows.GetRowWithListIndex(_dt.Rows.IndexOf(drArray[0]));
				this.gridExportDataSelect.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(ultraGridRow);
				ultraGridRow.Activate();
			}
			this.Refresh();
		}

		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void SFANL08170UA_Load(object sender, EventArgs e)
		{
			if (SearchProc() != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				this.Close();
		}

		/// <summary>
		/// �t�H�[��Shown�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����ŏ��ɕ\�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void SFANL08170UA_Shown(object sender, EventArgs e)
		{
			this.gridExportDataSelect.Focus();
		}

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			if (_isInExport) return;

			this.gridExportDataSelect.PerformAction(UltraGridAction.ExitEditMode);

			switch (e.Tool.Key)
			{
				case ctButtonTool_SelectALL:
				{
					foreach (DataRow dr in _dt.Rows)
						dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 1;
					break;
				}
				case ctButtonTool_CancelALL:
				{
					foreach (DataRow dr in _dt.Rows)
						dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 0;
					break;
				}
			}
		}

		/// <summary>
		/// �G�N�X�|�[�g�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �G�N�X�|�[�g�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void ubExport_Click(object sender, EventArgs e)
		{
			if (_isInExport) return;

			ExportProc();
		}

		/// <summary>
		/// �L�����Z���{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �L�����Z���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void ubCancel_Click(object sender, EventArgs e)
		{
			if (_isInExport) return;

			this.Close();
		}

		/// <summary>
		/// �O���b�h�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h�����������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
			{
				switch (col.Key)
				{
					case COL_FREPRTEXPORT_EXPORTEDFLG:	// �G�N�X�|�[�g�ς݃t���O
					{
						ValueList valueList = new ValueList();
						valueList.ValueListItems.Add(0, "�@");
						valueList.ValueListItems.Add(1, "��");
						valueList.ValueListItems.Add(2, "�~");
						col.ValueList = valueList;

						col.Header.Caption					= "����";
						col.CellActivation					= Activation.Disabled;
						col.CellAppearance.TextHAlign		= HAlign.Center;
						col.CellAppearance.FontData.Bold	= DefaultableBoolean.True;
						col.Width							= 50;
						break;
					}
					case COL_FREPRTEXPORT_EXTRACTIONITDEDFLG:	// ���o�Ώۃt���O
					{
						col.Header.Caption	= string.Empty;
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.CellActivation	= Activation.NoEdit;
						col.Width			= 30;
						break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV1:	// �`�[��ʓo�^�敪1
					{
						col.Header.Caption	= "����";
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
						break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV2:	// �`�[��ʓo�^�敪2
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                        //col.Header.Caption	= "�w��";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        col.Header.Caption	= "��";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
                        break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV3:	// �`�[��ʓo�^�敪3
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                        //col.Header.Caption	= "����";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        col.Header.Caption = "�ݏo";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
                        break;
					}
					case COL_FREPRTEXPORT_SLIPKINDENTRYDIV4:	// �`�[��ʓo�^�敪4
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                        //col.Header.Caption	= "�[�i";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        col.Header.Caption = "����";
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
						col.Width			= 50;
                        break;
					}
					case COL_FREPRTEXPORT_SLIPPRTKIND:	// �`�[������
					{
						col.Header.Caption	= "�g�p�]��";
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
						col.Width			= 70;
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        col.Hidden = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
                        break;
					}
					case COL_FREPRTEXPORT_DATAINPUTSYSTEM:	// �f�[�^���̓V�X�e��
					{
						ValueList valueList = new ValueList();
						valueList.ValueListItems.Add(0, "����");
						valueList.ValueListItems.Add(1, "����");
						valueList.ValueListItems.Add(2, "���");
						valueList.ValueListItems.Add(3, "�Ԕ�");
						col.ValueList = valueList;

						col.Header.Caption	= "�V�X�e��";
						col.CellActivation	= Activation.NoEdit;
						col.Width			= 70;
						break;
					}
					case COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD:	// ���[�g�p�敪
					{
						ValueList valueList = new ValueList();
						valueList.ValueListItems.Add(1, "���[");
						valueList.ValueListItems.Add(2, "�`�[");
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
                        //valueList.ValueListItems.Add(3, "DM�ꗗ�\");
                        //valueList.ValueListItems.Add(4, "DM�͂���");
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
                        valueList.ValueListItems.Add( 5, "������" );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
						col.ValueList = valueList;

						col.Header.Caption	= "���[�g�p�敪";
						col.CellActivation	= Activation.NoEdit;
						col.Width			= 70;
						break;
					}
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                    case COL_FREPRTEXPORT_OUTPUTFORMFILENAME: // ���[�h�c
                    {
                        col.Header.Caption = "���[�h�c";
                        col.CellActivation = Activation.NoEdit;
                        break;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
					case COL_FREPRTEXPORT_DISPLAYNAME:	// �o�͖���
					{
						col.Header.Caption	= "���[����";
						col.CellActivation	= Activation.NoEdit;
						break;
					}
					case COL_FREPRTEXPORT_PRTPPRUSERDERIVNOCMT:	// ���[���[�U�[�}�ԃR�����g
					{
						col.Header.Caption	= "�R�����g";
						col.CellActivation	= Activation.NoEdit;
						break;
					}
					case COL_FREPRTEXPORT_NOTE:	// ���l
					{
						col.Header.Caption	= "���l";
						col.Style			= Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
						break;
					}
					default:
					{
						col.Hidden = true;
						break;
					}
				}
			}
		}

		/// <summary>
		/// �O���b�hAfterRowActivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h��̍s���A�N�e�B�u���������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_AfterRowActivate(object sender, EventArgs e)
		{
			this.gridExportDataSelect.ActiveRow.Selected = true;

			if (this.gridExportDataSelect.ActiveCell == null)
				this.gridExportDataSelect.ActiveRow.Cells[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG].Activate();
		}

		/// <summary>
		/// �O���b�hInitializeRow�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �s�����������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_InitializeRow(object sender, InitializeRowEventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 DEL
            //// �`�[������
            //ValueList valueList = new ValueList();
            //valueList.ValueListItems.Add(0, "�݌v");
            //e.Row.Cells[COL_FREPRTEXPORT_SLIPPRTKIND].ValueList = valueList;
            //if ((int)e.Row.Cells[COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD].Value == 2)
            //{
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1].Activation	= Activation.AllowEdit;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2].Activation	= Activation.AllowEdit;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3].Activation	= Activation.AllowEdit;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4].Activation	= Activation.AllowEdit;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPPRTKIND].Activation		= Activation.AllowEdit;

            //    // ��ƃR�[�h
            //    string enterpriseCode		= e.Row.Cells[COL_FREPRTEXPORT_ENTERPRISECODE].Value.ToString();
            //    // �f�[�^���̓V�X�e��	
            //    int dataInputSystem			= (int)e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Value;
            //    // �`�[����ݒ�p���[ID
            //    string slipPrtSetPaperId	= e.Row.Cells[COL_FREPRTEXPORT_OUTPUTFORMFILENAME].Value.ToString() + e.Row.Cells[COL_FREPRTEXPORT_USERPRTPPRIDDERIVNO].Value.ToString();
            //    List<SlipPrtSet> slipPrtSetList
            //        = _frePrtPSetExportAcs.SlipPrtSetList.FindAll(
            //            delegate(SlipPrtSet slipPrtSet)
            //            {
            //                if (slipPrtSet.EnterpriseCode == enterpriseCode &&
            //                    slipPrtSet.DataInputSystem == dataInputSystem &&
            //                    slipPrtSet.SlipPrtSetPaperId == slipPrtSetPaperId)
            //                    return true;
            //                else
            //                    return false;
            //            }
            //        );
            //    if (slipPrtSetList != null && slipPrtSetList.Count > 0)
            //    {
            //        foreach (SlipPrtSet slipPrtSet in slipPrtSetList)
            //        {
            //            if (slipPrtSet.SlipPrtKind == 10)
            //                valueList.ValueListItems.Add(slipPrtSet.SlipPrtKind, "����");
            //            else if (slipPrtSet.SlipPrtKind == 20)
            //                valueList.ValueListItems.Add(slipPrtSet.SlipPrtKind, "�w��");
            //            else if (slipPrtSet.SlipPrtKind == 21)
            //                valueList.ValueListItems.Add(slipPrtSet.SlipPrtKind, "����");
            //            else if (slipPrtSet.SlipPrtKind == 30)
            //                valueList.ValueListItems.Add(slipPrtSet.SlipPrtKind, "�[�i");
            //        }
            //    }
            //}
            //else
            //{
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1].Activation	= Activation.Disabled;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2].Activation	= Activation.Disabled;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3].Activation	= Activation.Disabled;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4].Activation	= Activation.Disabled;
            //    e.Row.Cells[COL_FREPRTEXPORT_SLIPPRTKIND].Activation		= Activation.NoEdit;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
            if ( (int)e.Row.Cells[COL_FREPRTEXPORT_PRINTPAPERUSEDIVCD].Value == 2 &&
                (int)e.Row.Cells[COL_FREPRTEXPORT_FREEPRTPPRSPPRPSECD].Value == 0 )
            {
                e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1].Activation = Activation.AllowEdit;
                e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2].Activation = Activation.AllowEdit;
                e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3].Activation = Activation.AllowEdit;
                e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4].Activation = Activation.AllowEdit;
            }
            else
            {
                e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV1].Activation = Activation.Disabled;
                e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV2].Activation = Activation.Disabled;
                e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV3].Activation = Activation.Disabled;
                e.Row.Cells[COL_FREPRTEXPORT_SLIPKINDENTRYDIV4].Activation = Activation.Disabled;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD

			// Export�t���O
			if ((int)e.Row.Cells[COL_FREPRTEXPORT_EXPORTEDFLG].Value == 2)
				e.Row.Cells[COL_FREPRTEXPORT_EXPORTEDFLG].Appearance.ForeColorDisabled = Color.Red;
			else
				e.Row.Cells[COL_FREPRTEXPORT_EXPORTEDFLG].Appearance.ForeColorDisabled = Color.Blue;

			// �f�[�^���̓V�X�e��
			switch ((int)e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Value)
			{
				case 1: e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Appearance.ForeColor = Color.Blue; break;
				case 2: e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Appearance.ForeColor = Color.Green; break;
				case 3: e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Appearance.ForeColor = Color.Purple; break;
				default: e.Row.Cells[COL_FREPRTEXPORT_DATAINPUTSYSTEM].Appearance.ForeColor = Color.Black; break;
			}
		}

		/// <summary>
		/// �O���b�h�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŃN���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_MouseClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElement�𗘗p���č��W�ʒu�̃R���g���[�����擾
			UIElement element = this.gridExportDataSelect.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// �N���b�N�����ʒu��GridRow�̏ꍇ�̂ݏ������s��
			UltraGridCell ultraGridCell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
			if (ultraGridCell != null && ultraGridCell.Column.Key.Equals(COL_FREPRTEXPORT_EXTRACTIONITDEDFLG))
			{
				DataRow dr = _dt.Rows[ultraGridCell.Row.ListIndex];
				if ((int)dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] == 0)
					dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 1;
				else
					dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 0;
			}
		}

		/// <summary>
		/// �O���b�h�_�u���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h��Ń_�u���N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElement�𗘗p���č��W�ʒu�̃R���g���[�����擾
			UIElement element = this.gridExportDataSelect.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// �N���b�N�����ʒu��GridRow�̏ꍇ�̂ݏ������s��
			UltraGridCell ultraGridCell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
			if (ultraGridCell != null && ultraGridCell.Column.CellActivation == Activation.NoEdit)
			{
				DataRow dr = _dt.Rows[ultraGridCell.Row.ListIndex];
				if ((int)dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] == 0)
					dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 1;
				else
					dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 0;
			}
		}

		/// <summary>
		/// �O���b�hBeforeEnterEditMode�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			// ���l����IME���u�Ђ炪�ȁv�ŋN������
			if (this.gridExportDataSelect.ActiveCell.Column.Key == COL_FREPRTEXPORT_NOTE)
				this.gridExportDataSelect.ImeMode = ImeMode.Hiragana;
			else
				this.gridExportDataSelect.ImeMode = ImeMode.Disable;
		}

		/// <summary>
		/// �O���b�hAfterExitEditMode�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�����ҏW���[�h���I��������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_AfterExitEditMode(object sender, EventArgs e)
		{
			this.gridExportDataSelect.ImeMode = ImeMode.Disable;
		}

		/// <summary>
		/// �O���b�h�L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŃL�[���������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_KeyDown(object sender, KeyEventArgs e)
		{
			UltraGrid ultraGrid = (UltraGrid)sender;
			if (ultraGrid.ActiveCell != null)
			{
				switch (e.KeyCode)
				{
					case Keys.Space:
					{
						if (ultraGrid.ActiveCell.Column.Key == COL_FREPRTEXPORT_EXTRACTIONITDEDFLG)
						{
							DataRow dr = _dt.Rows[ultraGrid.ActiveCell.Row.ListIndex];
							if ((int)dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] == 0)
								dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 1;
							else
								dr[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG] = 0;
						}
						break;
					}
					case Keys.Up:
					{
						switch (ultraGrid.ActiveCell.Column.Style)
						{
							case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
							{
								if (e.Alt)
								{
									ultraGrid.ActiveCell.DroppedDown = true;
									e.Handled = true;
								}
								else if (!ultraGrid.ActiveCell.DroppedDown)
								{
									ultraGrid.PerformAction(UltraGridAction.AboveCell);
									e.Handled = true;
								}
								break;
							}
							default:
							{
								ultraGrid.PerformAction(UltraGridAction.AboveCell);
								e.Handled = true;
								break;
							}
						}
						break;
					}
					case Keys.Down:
					{
						switch (ultraGrid.ActiveCell.Column.Style)
						{
							case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
							{
								if (e.Alt)
								{
									ultraGrid.ActiveCell.DroppedDown = true;
									e.Handled = true;
								}
								else if (!ultraGrid.ActiveCell.DroppedDown)
								{
									ultraGrid.PerformAction(UltraGridAction.BelowCell);
									e.Handled = true;
								}
								break;
							}
							default:
							{
								if (ultraGrid.ActiveCell.Row.Index == ultraGrid.Rows.Count - 1)
									this.ubExport.Focus();
								else
									ultraGrid.PerformAction(UltraGridAction.BelowCell);
								e.Handled = true;
								break;
							}
						}
						break;
					}
					case Keys.Left:
					{
						if (ultraGrid.ActiveCell.IsInEditMode &&
							ultraGrid.ActiveCell.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
						{
							if (ultraGrid.ActiveCell.SelStart == 0 &&
								ultraGrid.ActiveCell.SelLength == 0)
							{
								ultraGrid.PerformAction(UltraGridAction.PrevCell);
								e.Handled = true;
							}
						}
						else
						{
							ultraGrid.PerformAction(UltraGridAction.PrevCell);
							e.Handled = true;
						}
						break;
					}
					case Keys.Right:
					{
						if (ultraGrid.ActiveCell.IsInEditMode &&
							ultraGrid.ActiveCell.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit)
						{
							if (ultraGrid.ActiveCell.SelStart == ultraGrid.ActiveCell.Text.Length &&
								ultraGrid.ActiveCell.SelLength == 0)
							{
								ultraGrid.PerformAction(UltraGridAction.NextCell);
								e.Handled = true;
							}
						}
						else
						{
							ultraGrid.PerformAction(UltraGridAction.NextCell);
							e.Handled = true;
						}
						break;
					}
					case Keys.PageUp:
					{
						ultraGrid.PerformAction(UltraGridAction.PageUpCell);
						e.Handled = true;
						break;
					}
					case Keys.PageDown:
					{
						ultraGrid.PerformAction(UltraGridAction.PageDownCell);
						e.Handled = true;
						break;
					}
				}
			}
		}

		/// <summary>
		/// �O���b�hAfterCellActivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�����A�N�e�B�u�ɂȂ�����ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_AfterCellActivate(object sender, EventArgs e)
		{
			if (this.gridExportDataSelect.ActiveCell.CanEnterEditMode)
				this.gridExportDataSelect.PerformAction(UltraGridAction.EnterEditMode);
		}

		/// <summary>
		/// �O���b�hEnter�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[���ɂȂ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_Enter(object sender, EventArgs e)
		{
			if (this.gridExportDataSelect.ActiveCell != null)
			{
				if (this.gridExportDataSelect.ActiveCell.Activation == Activation.AllowEdit)
					this.gridExportDataSelect.PerformAction(UltraGridAction.EnterEditMode);
			}
			else if (this.gridExportDataSelect.ActiveRow != null)
			{
				this.gridExportDataSelect.ActiveRow.Cells[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG].Activate();
			}
			else
			{
				if (this.gridExportDataSelect.Rows.Count > 0)
					this.gridExportDataSelect.Rows[0].Cells[COL_FREPRTEXPORT_EXTRACTIONITDEDFLG].Activate();
			}
		}

		/// <summary>
		/// MouseEnterElement�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �}�E�X���v�f�̎l�p�`�ɓ��������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_MouseEnterElement(object sender, UIElementEventArgs e)
		{
			object objContextRow	= e.Element.GetContext(typeof(UltraGridRow));
			if (objContextRow != null)
			{
				DataRow dr = _dt.Rows[((UltraGridRow)objContextRow).ListIndex];
				if ((int)dr[COL_FREPRTEXPORT_EXPORTEDFLG] == 2)
				{
					UltraToolTipInfo ultraToolTipInfo = new UltraToolTipInfo();
					ultraToolTipInfo.ToolTipImage		= ToolTipImage.Error;
					ultraToolTipInfo.ToolTipTitle		= "�G���[���";
					ultraToolTipInfo.ToolTipText		= dr[COL_FREPRTEXPORT_ERRORMESSAGE].ToString();

					this.uttmGridToolTip.SetUltraToolTip(this.gridExportDataSelect, ultraToolTipInfo);
					this.uttmGridToolTip.Enabled = true;
				}
			}
		}

		/// <summary>
		/// MouseLeaveElement�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �}�E�X���v�f�̎l�p�`���痣�ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.11.06</br>
		/// </remarks>
		private void gridExportDataSelect_MouseLeaveElement(object sender, UIElementEventArgs e)
		{
			// �c�[���`�b�v���\���ɂ���
			this.uttmGridToolTip.HideToolTip();
			this.uttmGridToolTip.Enabled = false;
		}
		#endregion
	}
}