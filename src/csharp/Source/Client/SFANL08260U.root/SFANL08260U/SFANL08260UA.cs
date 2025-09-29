using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	public partial class SFANL08260UA : Form
	{
		// MessageBox�w�b�_�[�L���v�V����
		internal const string ctMSG_CAPTION = "���R���[�\�[�g���ʏ����l�ݒ�";

		// �e�[�u������
		private const string TBL_PRTITEMSET = "PrtItemSetRF";
		private const string TBL_FPSORTINIT = "FPSortInitRF";
		// ���ʃt�@�C���w�b�_�[
		private const string COL_COMMON_CREATEDATETIME		= "CreateDateTime";		// �쐬����
		private const string COL_COMMON_UPDATEDATETIME		= "UpdateDateTime";		// �X�V����
		private const string COL_COMMON_LOGICALDELETECODE	= "LogicalDeleteCode";	// �_���폜�敪
		// �󎚍��ڐݒ�
		private const string COL_PRTITEMSET_FREEPRTPPRITEMGRPCD		= "FreePrtPprItemGrpCd";	// ���R���[���ڃO���[�v�R�[�h
		private const string COL_PRTITEMSET_FREEPRTPAPERITEMCD		= "FreePrtPaperItemCd";		// ���R���[���ڃR�[�h
		private const string COL_PRTITEMSET_FREEPRTPAPERITEMNM		= "FreePrtPaperItemNm";		// ���R���[���ږ���
		private const string COL_PRTITEMSET_FILENM					= "FileNm";					// �t�@�C������
		private const string COL_PRTITEMSET_DDCHARCNT				= "DDCharCnt";				// DD����
		private const string COL_PRTITEMSET_DDNAME					= "DDName";					// DD����
		private const string COL_PRTITEMSET_REPORTCONTROLCODE		= "ReportControlCode";		// ���|�[�g�R���g���[���敪
		private const string COL_PRTITEMSET_HEADERUSEDIVCD			= "HeaderUseDivCd";			// �w�b�_�[�g�p�敪
		private const string COL_PRTITEMSET_DETAILUSEDIVCD			= "DetailUseDivCd";			// ���׎g�p�敪
		private const string COL_PRTITEMSET_FOOTERUSEDIVCD			= "FooterUseDivCd";			// �t�b�^�[�g�p�敪
		private const string COL_PRTITEMSET_EXTRACONDITIONDIVCD		= "ExtraConditionDivCd";	// ���o�����敪
		private const string COL_PRTITEMSET_EXTRACONDITIONTYPECD	= "ExtraConditionTypeCd";	// ���o�����^�C�v
		private const string COL_PRTITEMSET_COMMAEDITEXISTCD		= "CommaEditExistCd";		// �J���}�ҏW�L��
		private const string COL_PRTITEMSET_PRINTPAGECTRLDIVCD		= "PrintPageCtrlDivCd";		// �󎚃y�[�W����敪
		private const string COL_PRTITEMSET_SYSTEMDIVCD				= "SystemDivCd";			// �V�X�e���敪
		private const string COL_PRTITEMSET_OPTIONCODE				= "OptionCode";				// �I�v�V�����R�[�h
		private const string COL_PRTITEMSET_EXTRACONDDETAILGRPCD	= "ExtraCondDetailGrpCd";	// ���o�������׃O���[�v�R�[�h
		private const string COL_PRTITEMSET_TOTALITEMDIVCD			= "TotalItemDivCd";			// �W�v���ڋ敪
		private const string COL_PRTITEMSET_FORMFEEDITEMDIVCD		= "FormFeedItemDivCd";		// ���ō��ڋ敪
		private const string COL_PRTITEMSET_FREEPRTPPRDISPGRPCD		= "FreePrtPprDispGrpCd";	// ���R���[�\���O���[�v�R�[�h
		private const string COL_PRTITEMSET_NECESSARYEXTRACONDCD	= "NecessaryExtraCondCd";	// �K�{���o�����敪
		private const string COL_PRTITEMSET_CIPHERFLG				= "CipherFlg";				// �Í����t���O
		private const string COL_PRTITEMSET_EXTRACTIONITDEDFLG		= "ExtractionItdedFlg";		// ���o�Ώۃt���O
		private const string COL_PRTITEMSET_GROUPSUPPRESSCD			= "GroupSuppressCd";		// �O���[�v�T�v���X�敪
		private const string COL_PRTITEMSET_DTLCOLORCHANGECD		= "DtlColorChangeCd";		// ���אF�ύX�敪
		private const string COL_PRTITEMSET_HEIGHTADJUSTDIVCD		= "HeightAdjustDivCd";		// ���������敪
		private const string COL_PRTITEMSET_ADDITEMUSEDIVCD			= "AddItemUseDivCd";		// �ǉ����ڎg�p�敪
		// ���R���[�\�[�g���ʏ����l
		private const string COL_FPSORTINIT_FREEPRTPPRITEMGRPCD		= "FreePrtPprItemGrpCd";	// ���R���[���ڃO���[�v�R�[�h
		private const string COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD		= "FreePrtPprSchmGrpCd";	// ���R���[�X�L�[�}�O���[�v�R�[�h
		private const string COL_FPSORTINIT_SORTINGORDERCODE		= "SortingOrderCode";		// �\�[�g���ʃR�[�h
		private const string COL_FPSORTINIT_SORTINGORDER			= "SortingOrder";			// �\�[�g����
		private const string COL_FPSORTINIT_FREEPRTPAPERITEMNM		= "FreePrtPaperItemNm";		// ���R���[���ږ���
		private const string COL_FPSORTINIT_DDNAME					= "DDName";					// DD����
		private const string COL_FPSORTINIT_FILENM					= "FileNm";					// �t�@�C������
		private const string COL_FPSORTINIT_SORTINGORDERDIVCD		= "SortingOrderDivCd";		// �����~���敪

		#region PrivateMember
		// �f�[�^�ێ��pDataSet
		private DataSet				_ds;
		// �t�@�C�����C�A�E�g���ێ��p
		private List<SchemaInfo>	_fPSortInitSchemaInfoList;
		private List<SchemaInfo>	_prtItemSetSchemaInfoList;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08260UA()
		{
			InitializeComponent();

			_ds = new DataSet();
		}
		#endregion

		/// <summary>
		/// �X�L�[�}���LIST�擾����
		/// </summary>
		/// <param name="tableName">�e�[�u������</param>
		/// <returns>�X�L�[�}���LIST</returns>
		private List<SchemaInfo> GetSchemaInfoList(string tableName)
		{
			List<SchemaInfo> schemaInfoList = new List<SchemaInfo>();

			switch (tableName)
			{
				case TBL_PRTITEMSET:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"�쐬����",						typeof(long),	19));	// �쐬����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"�X�V����",						typeof(long),	19));	// �X�V����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"�_���폜�敪",					typeof(int),	2));	// �_���폜�敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FREEPRTPPRITEMGRPCD,	"���R���[���ڃO���[�v�R�[�h",		typeof(int),	4));	// ���R���[���ڃO���[�v�R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FREEPRTPAPERITEMCD,	"���R���[���ڃR�[�h",				typeof(int),	4));	// ���R���[���ڃR�[�h
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FREEPRTPAPERITEMNM,	"���R���[���ږ���",				typeof(string),	30));	// ���R���[���ږ���
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FILENM,				"�t�@�C������",					typeof(string),	32));	// �t�@�C������
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_DDCHARCNT,				"DD����",						typeof(int),	2));	// DD����
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_DDNAME,				"DD����",						typeof(string),	30));	// DD����
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_REPORTCONTROLCODE,		"���|�[�g�R���g���[���敪",		typeof(int),	2));	// ���|�[�g�R���g���[���敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_HEADERUSEDIVCD,		"�w�b�_�[�g�p�敪",				typeof(int),	2));	// �w�b�_�[�g�p�敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_DETAILUSEDIVCD,		"���׎g�p�敪",					typeof(int),	2));	// ���׎g�p�敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FOOTERUSEDIVCD,		"�t�b�^�[�g�p�敪",				typeof(int),	2));	// �t�b�^�[�g�p�敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_EXTRACONDITIONDIVCD,	"���o�����敪",					typeof(int),	2));	// ���o�����敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_EXTRACONDITIONTYPECD,	"���o�����^�C�v",				typeof(int),	2));	// ���o�����^�C�v
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_COMMAEDITEXISTCD,		"�J���}�ҏW�L��",				typeof(int),	2));	// �J���}�ҏW�L��
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_PRINTPAGECTRLDIVCD,	"�󎚃y�[�W����敪",				typeof(int),	2));	// �󎚃y�[�W����敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_SYSTEMDIVCD,			"�V�X�e���敪",					typeof(int),	2));	// �V�X�e���敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_OPTIONCODE,			"�I�v�V�����R�[�h",				typeof(string),	16));	// �I�v�V�����R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_EXTRACONDDETAILGRPCD,	"���o�������׃O���[�v�R�[�h",		typeof(int),	4));	// ���o�������׃O���[�v�R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_TOTALITEMDIVCD,		"�W�v���ڋ敪",					typeof(int),	2));	// �W�v���ڋ敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FORMFEEDITEMDIVCD,		"���ō��ڋ敪",					typeof(int),	2));	// ���ō��ڋ敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_FREEPRTPPRDISPGRPCD,	"���R���[�\���O���[�v�R�[�h",		typeof(int),	4));	// ���R���[�\���O���[�v�R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_NECESSARYEXTRACONDCD,	"�K�{���o�����敪",				typeof(int),	2));	// �K�{���o�����敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_CIPHERFLG,				"�Í����t���O",					typeof(int),	2));	// �Í����t���O
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_EXTRACTIONITDEDFLG,	"���o�Ώۃt���O",				typeof(int),	2));	// ���o�Ώۃt���O
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_GROUPSUPPRESSCD,		"�O���[�v�T�v���X�敪",			typeof(int),	2));	// �O���[�v�T�v���X�敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_DTLCOLORCHANGECD,		"���אF�ύX�敪",				typeof(int),	2));	// ���אF�ύX�敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_HEIGHTADJUSTDIVCD,		"���������敪",					typeof(int),	2));	// ���������敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMSET_ADDITEMUSEDIVCD,		"�ǉ����ڎg�p�敪",				typeof(int),	2));	// �ǉ����ڎg�p�敪
					break;
				}
				case TBL_FPSORTINIT:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"�쐬����",						typeof(long),	19));	// �쐬����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"�X�V����",						typeof(long),	19));	// �X�V����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"�_���폜�敪",					typeof(int),	2));	// �_���폜�敪
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_FREEPRTPPRITEMGRPCD,	"���R���[���ڃO���[�v�R�[�h",		typeof(int),	4));	// ���R���[���ڃO���[�v�R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD,	"���R���[�X�L�[�}�O���[�v�R�[�h",	typeof(int),	4));	// ���R���[�X�L�[�}�O���[�v�R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_SORTINGORDERCODE,		"�\�[�g���ʃR�[�h",				typeof(int),	2));	// �\�[�g���ʃR�[�h
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_SORTINGORDER,			"�\�[�g����",					typeof(int),	2));	// �\�[�g����
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_FREEPRTPAPERITEMNM,	"���R���[���ږ���",				typeof(string),	30));	// ���R���[���ږ���
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_DDNAME,				"DD����",						typeof(string),	30));	// DD����
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_FILENM,				"�t�@�C������",					typeof(string),	32));	// �t�@�C������
					schemaInfoList.Add(new SchemaInfo(COL_FPSORTINIT_SORTINGORDERDIVCD,		"�����~���敪",					typeof(int),	2));	// �����~���敪
					break;
				}
			}

			return schemaInfoList;
		}

		/// <summary>
		/// DataTable�X�L�[�}�쐬����
		/// </summary>
		/// <param name="ds">DataTable�i�[��DataSet</param>
		/// <param name="tableName">DataTable����</param>
		private void CreateDataTableSchema(DataSet ds, string tableName)
		{
			List<SchemaInfo> schemaInfoList = GetSchemaInfoList(tableName);

			if (schemaInfoList != null)
			{
				switch (tableName)
				{
					case TBL_PRTITEMSET: _prtItemSetSchemaInfoList = schemaInfoList; break;
					case TBL_FPSORTINIT: _fPSortInitSchemaInfoList = schemaInfoList; break;
				}

				ds.Tables.Add(new DataTable(tableName));
				foreach (SchemaInfo schemaInfo in schemaInfoList)
				{
					// �^�𓮓I�Ɏw��
					if (schemaInfo.Type != null)
						ds.Tables[tableName].Columns.Add(schemaInfo.Name, schemaInfo.Type);
					else
						ds.Tables[tableName].Columns.Add(schemaInfo.Name);

					// ������^�̏ꍇ�͋󕶎��������l�ɂ���
					if (ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals(typeof(string)))
					{
						ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = string.Empty;
					}
					// GUID�^�̏ꍇ�͐V����GUID�l�������l�ɂ���
					else if (ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals(typeof(Guid)))
					{
						ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = Guid.NewGuid();
					}
					// ���l�^�̏ꍇ��0�������l(Boolean�̏ꍇ��false)�ɂ���
					else if (ds.Tables[tableName].Columns[schemaInfo.Name].DataType.IsPrimitive)
					{
						if (ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals(typeof(bool)))
							ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = false;
						else
							ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = 0;
					}

					// DBNull�͋����Ȃ�
					ds.Tables[tableName].Columns[schemaInfo.Name].AllowDBNull = false;
				}
			}
		}

		/// <summary>
		/// ��ʏ���������
		/// </summary>
		private void DisplayInitialize()
		{
			_ds.Tables[TBL_PRTITEMSET].Rows.Clear();
			_ds.Tables[TBL_FPSORTINIT].Rows.Clear();

			this.ulFreePrtPprItemGrpCd.Text = string.Empty;
			this.tedPrtItemSetFilter.Text = string.Empty;

			StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];
			appendButtonTool.Checked = false;
			LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
			modeLabelTool.SharedProps.Caption = "CSV�㏑�����[�h";

			this.ndtFreePrtPprSchmGrpCd.Enabled = false;
			this.ubSchmAdd.Enabled = false;

			UpdateFilterCommboBox();

			ChangeEnableToSchmAdd();
		}

		/// <summary>
		/// �t�B���^�[�R���{�{�b�N�X�X�V����
		/// </summary>
		private void UpdateFilterCommboBox()
		{
			this.cmbFreePrtPprSchmGrpCd.Items.Clear();

			if (_ds.Tables[TBL_FPSORTINIT].Rows.Count > 0)
			{
				List<int> schmGrpCdList = new List<int>();
				foreach (DataRow dr in _ds.Tables[TBL_FPSORTINIT].Rows)
				{
					if (!schmGrpCdList.Contains((int)dr[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD]))
						schmGrpCdList.Add((int)dr[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD]);
				}

				foreach (int schmGrpCd in schmGrpCdList)
					this.cmbFreePrtPprSchmGrpCd.Items.Add(schmGrpCd);
			}
			else
			{
				this.cmbFreePrtPprSchmGrpCd.Items.Add(0);
			}

			if (this.cmbFreePrtPprSchmGrpCd.Items.Count > 0)
				this.cmbFreePrtPprSchmGrpCd.SelectedIndex = 0;
		}

		/// <summary>
		/// �ړ��p�{�^�����͐��䏈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �s�ړ��p�̃{�^���̓��͐�����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ChangeEnableToMoveButton()
		{
			if (this.gridFPSortInit.ActiveRow != null)
			{
				if (this.gridFPSortInit.ActiveRow.Index == 0)
					this.ubUp.Enabled = false;
				else
					this.ubUp.Enabled = true;

				if (this.gridFPSortInit.ActiveRow.Index >= this.gridFPSortInit.Rows.Count - 1)
					this.ubDown.Enabled = false;
				else
					this.ubDown.Enabled = true;
			}
		}

		/// <summary>
		/// �X�L�[�}�ǉ��p�{�^�����͐��䏈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �X�L�[�}�ǉ��p�̃{�^���̓��͐�����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ChangeEnableToSchmAdd()
		{
			if (this.gridFPSortInit.Rows.Count > 0)
			{
				this.ndtFreePrtPprSchmGrpCd.Enabled = true;
				this.ubSchmAdd.Enabled = true;
			}
			else
			{
				this.ndtFreePrtPprSchmGrpCd.Enabled = false;
				this.ubSchmAdd.Enabled = false;
			}
		}

		/// <summary>
		/// �f�[�^�e�[�u�����X�V����
		/// </summary>
        /// <param name="dr">���R���[���o�����ݒ�}�X�^</param>
        /// <param name="freePrtPprSchmGrpCd">�C���f�b�N�X</param>
		private void AddFPSortInitToDataTable(DataRow dr, int freePrtPprSchmGrpCd)
		{
			DataRow addRow = _ds.Tables[TBL_FPSORTINIT].NewRow();
			addRow[COL_COMMON_CREATEDATETIME]			= dr[COL_COMMON_CREATEDATETIME];			// �쐬����
			addRow[COL_COMMON_UPDATEDATETIME]			= dr[COL_COMMON_UPDATEDATETIME];			// �X�V����
			addRow[COL_COMMON_LOGICALDELETECODE]		= dr[COL_COMMON_LOGICALDELETECODE];			// �_���폜�敪
			addRow[COL_FPSORTINIT_FREEPRTPPRITEMGRPCD]	= dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD];	// ���R���[���ڃO���[�v�R�[�h
			addRow[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD]	= freePrtPprSchmGrpCd;						// ���R���[�X�L�[�}�O���[�v�R�[�h
			addRow[COL_FPSORTINIT_SORTINGORDERCODE]		= dr[COL_PRTITEMSET_FREEPRTPAPERITEMCD];	// �\�[�g���ʃR�[�h
			addRow[COL_FPSORTINIT_SORTINGORDER]			= 0;										// �\�[�g����
			addRow[COL_FPSORTINIT_FREEPRTPAPERITEMNM]	= dr[COL_PRTITEMSET_FREEPRTPAPERITEMNM];	// ���R���[���ږ���
			addRow[COL_FPSORTINIT_DDNAME]				= dr[COL_PRTITEMSET_DDNAME];				// DD����
			addRow[COL_FPSORTINIT_FILENM]				= dr[COL_PRTITEMSET_FILENM];				// �t�@�C������
			addRow[COL_FPSORTINIT_SORTINGORDERDIVCD]	= 0;										// �����~���敪
			_ds.Tables[TBL_FPSORTINIT].Rows.Add(addRow);
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		private int SaveProc(out string errMsg)
		{
			int status = 0;
			errMsg = string.Empty;

			string fileName = string.Empty;
			try
			{
				if (_ds.Tables[TBL_FPSORTINIT].Rows.Count != 0)
				{
					foreach (UltraGridRow row in this.gridFPSortInit.Rows)
						row.Cells[COL_FPSORTINIT_SORTINGORDER].Value = row.Index;

					Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath);

					StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];

					// ������ CSV�t�@�C���̕ۑ� ������
					// ���o���������l
					fileName = Path.Combine(SFANL08246CA.ctCSVSavePath, TBL_FPSORTINIT + ".csv");
					status = SFANL08246CA.SaveCsv(_ds, TBL_FPSORTINIT, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg);

					// ������ XML�t�@�C���̕ۑ� ������
					if (status == 0)
					{
						int freePrtPprItemGrpCd = (int)_ds.Tables[TBL_PRTITEMSET].Rows[0][COL_PRTITEMSET_FREEPRTPPRITEMGRPCD];
						fileName = Path.Combine(SFANL08246CA.ctXMLSavePath, TBL_FPSORTINIT + "_" + freePrtPprItemGrpCd + ".xml");
						status = SFANL08246CA.SaveXml(_ds, TBL_FPSORTINIT, string.Empty, fileName, out errMsg);
					}
				}
				else
				{
					status = 4;
					errMsg = "�f�[�^�����͂���Ă��܂���B";
				}
			}
			catch (Exception ex)
			{
				errMsg = "�ۑ������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void SFANL08243UA_Load(object sender, EventArgs e)
		{
			string message = string.Empty;
			try
			{
				// �󎚍��ڐݒ�
				CreateDataTableSchema(_ds, TBL_PRTITEMSET);
				// ���R���[���o��������
				CreateDataTableSchema(_ds, TBL_FPSORTINIT);

				this.gridPrtItemSet.DataSource = _ds.Tables[TBL_PRTITEMSET];
				this.gridFPSortInit.DataSource = _ds.Tables[TBL_FPSORTINIT];

				DisplayInitialize();
			}
			catch (Exception ex)
			{
				message = "��ʋN�����ɗ�O���������܂����B" + Environment.NewLine + ex.Message;
			}

			if (!string.IsNullOrEmpty(message))
			{
				MessageBox.Show(
					message,
					ctMSG_CAPTION,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);

				this.Close();
			}
		}

		/// <summary>
		/// �O���b�hInitializeLayout�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���C�A�E�g�����������ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void Grid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			List<SchemaInfo> schemaInfoList = null;
			switch (e.Layout.Grid.Name)
			{
				case "gridFPSortInit": schemaInfoList = _fPSortInitSchemaInfoList; break;
				case "gridPrtItemSet": schemaInfoList = _prtItemSetSchemaInfoList; break;
			}

			if (schemaInfoList != null)
			{
				foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
				{
					SchemaInfo schemaInfo = schemaInfoList.Find(
						delegate(SchemaInfo wkSchemaInfo)
						{
							if (wkSchemaInfo.Name == col.Key)
								return true;
							else
								return false;
						}
					);

					col.Header.Caption = schemaInfo.Caption;
					col.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
					col.MaxLength = schemaInfo.Length;

					switch (e.Layout.Grid.Name)
					{
						case "gridPrtItemSet":
						{
							switch (col.Key)
							{
								case COL_PRTITEMSET_FREEPRTPAPERITEMCD:		// ���R���[���ڃR�[�h
								{
									col.CellAppearance.TextHAlign = HAlign.Right;
									break;
								}
								case COL_PRTITEMSET_FREEPRTPAPERITEMNM:		// ���R���[���ږ���
								{
									break;
								}
								default:
								{
									col.Hidden = true;
									break;
								}
							}
							break;
						}
						case "gridFPSortInit":
						{
							switch (col.Key)
							{
								case COL_FPSORTINIT_SORTINGORDERCODE:		// �\�[�g���ʃR�[�h
								{
									col.CellAppearance.TextHAlign = HAlign.Right;
									col.CellActivation = Activation.NoEdit;
									break;
								}
								case COL_FPSORTINIT_FREEPRTPAPERITEMNM:		// ���R���[���ږ���
								{
									col.CellActivation = Activation.NoEdit;
									break;
								}
								case COL_FPSORTINIT_SORTINGORDERDIVCD:		// �����~���敪
								{
									col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

									ValueList valueList = new ValueList();
									valueList.ValueListItems.Add(0, "�Ȃ�");
									valueList.ValueListItems.Add(1, "����");
									valueList.ValueListItems.Add(2, "�~��");
									col.ValueList = valueList;
									break;
								}
								default:
								{
									col.Hidden = true;
									break;
								}
							}
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// ���{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ubUp_Click(object sender, EventArgs e)
		{
			if (this.gridFPSortInit.ActiveRow != null)
			{
				int nowIndex = this.gridFPSortInit.ActiveRow.Index;
				if (nowIndex > 0)
				{
					this.gridFPSortInit.Rows.Move(this.gridFPSortInit.ActiveRow, nowIndex - 1, true);

					ChangeEnableToMoveButton();
				}
			}
		}

		/// <summary>
		/// ���{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ubDown_Click(object sender, EventArgs e)
		{
			if (this.gridFPSortInit.ActiveRow != null)
			{
				int nowIndex = this.gridFPSortInit.ActiveRow.Index;
				if (nowIndex < this.gridFPSortInit.Rows.Count - 1)
				{
					this.gridFPSortInit.Rows.Move(this.gridFPSortInit.ActiveRow, nowIndex + 1, true);

					ChangeEnableToMoveButton();
				}
			}
		}

		/// <summary>
		/// �~�{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �~�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void ubDelete_Click(object sender, EventArgs e)
		{
			int focusSetIndex = 0;

			if (this.gridFPSortInit.ActiveRow != null)
			{
				focusSetIndex = Math.Max(focusSetIndex, this.gridFPSortInit.ActiveRow.Index);

				int sortingOrderCode = (int)this.gridFPSortInit.ActiveRow.Cells[COL_FPSORTINIT_SORTINGORDERCODE].Value;
				DataRow[] drArray = _ds.Tables[TBL_FPSORTINIT].Select(COL_FPSORTINIT_SORTINGORDERCODE + "=" + sortingOrderCode);
				foreach (DataRow dr in drArray)
					_ds.Tables[TBL_FPSORTINIT].Rows.Remove(dr);

				if (focusSetIndex > 0) focusSetIndex--;

				ChangeEnableToMoveButton();

				ChangeEnableToSchmAdd();

				// �s���c���Ă���ꍇ��1�s�ڂ��A�N�e�B�u��
				if (this.gridFPSortInit.Rows.Count > 0)
					this.gridFPSortInit.Rows[focusSetIndex].Activate();
			}
		}

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void utmMainToolbar_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Exit_ButtonTool":
				{
					this.Close();
					break;
				}
				case "Open_ButtonTool":
				{
					this.openFileDialog.Filter = "�\�[�g���ʏ����lXML�t�@�C��|FPSortInit*.xml";
					this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
					if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
						DisplayInitialize();

						// ���R���[���o���������l
						_ds.Tables[TBL_FPSORTINIT].ReadXml(this.openFileDialog.FileName);

						// �󎚍��ڃO���[�v
						this.openFileDialog.Filter = "�󎚍��ڐݒ�XML�t�@�C��|PrtItemSet*.xml";
						this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
						if (this.openFileDialog.ShowDialog() == DialogResult.OK)
						{
							// �󎚍��ڃO���[�v
							_ds.Tables[TBL_PRTITEMSET].ReadXml(this.openFileDialog.FileName);

							UpdateFilterCommboBox();

							ChangeEnableToSchmAdd();
						}
						else
						{
							DisplayInitialize();
						}
					}
					break;
				}
				case "Save_ButtonTool":
				{
					string errMsg;
					int status = SaveProc(out errMsg);
					switch (status)
					{
						case 0:
						{
							MessageBox.Show(
								"�ۑ����܂����B",
								ctMSG_CAPTION,
								MessageBoxButtons.OK,
								MessageBoxIcon.Information,
								MessageBoxDefaultButton.Button1);
							break;
						}
						case 4:
						{
							MessageBox.Show(
								errMsg,
								ctMSG_CAPTION,
								MessageBoxButtons.OK,
								MessageBoxIcon.Information,
								MessageBoxDefaultButton.Button1);
							break;
						}
						default:
						{
							MessageBox.Show(
								errMsg,
								ctMSG_CAPTION,
								MessageBoxButtons.OK,
								MessageBoxIcon.Error,
								MessageBoxDefaultButton.Button1);
							break;
						}
					}
					break;
				}
				case "New_ButtonTool":
				{
					this.openFileDialog.Filter = "�󎚍��ڐݒ�XML�t�@�C��|PrtItemSet*.xml";
					this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
					if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
						DisplayInitialize();

						// �󎚍��ڐݒ�
						_ds.Tables[TBL_PRTITEMSET].ReadXml(this.openFileDialog.FileName);
						if (_ds.Tables[TBL_PRTITEMSET].Rows.Count > 0)
							this.ulFreePrtPprItemGrpCd.Text = _ds.Tables[TBL_PRTITEMSET].Rows[0][COL_PRTITEMSET_FREEPRTPPRITEMGRPCD].ToString();

						UpdateFilterCommboBox();
					}
					break;
				}
				case "Append_StateButtonTool":
				{
					StateButtonTool appendButtonTool = (StateButtonTool)e.Tool;
					LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
					if (appendButtonTool.Checked)
						modeLabelTool.SharedProps.Caption = "CSV�ǋL���[�h";
					else
						modeLabelTool.SharedProps.Caption = "CSV�㏑�����[�h";
					break;
				}
			}
		}

		/// <summary>
		/// �}�E�X�O���b�h�_�u���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �}�E�X�ŃR���g���[�����_�u���N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.23</br>
		/// </remarks>
		private void gridPrtItemSet_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElement�𗘗p���č��W�ʒu�̃R���g���[�����擾
			UIElement element = this.gridPrtItemSet.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// �N���b�N�����ʒu��GridRow�̏ꍇ�̂ݏ������s��
			UltraGridRow ultraGridRow = element.GetContext(typeof(UltraGridRow)) as UltraGridRow;
			if (ultraGridRow != null)
			{
				int freePrtPaperItemCd = (int)ultraGridRow.Cells[COL_PRTITEMSET_FREEPRTPAPERITEMCD].Value;
				DataRow[] drArray = _ds.Tables[TBL_FPSORTINIT].Select(COL_FPSORTINIT_SORTINGORDERCODE + "=" + freePrtPaperItemCd);
				if (drArray == null || drArray.Length == 0)
				{
					for (int ix = 0 ; ix != this.cmbFreePrtPprSchmGrpCd.Items.Count ; ix++)
						AddFPSortInitToDataTable(((DataRowView)ultraGridRow.ListObject).Row, (int)this.cmbFreePrtPprSchmGrpCd.Items[ix].DataValue);

					ChangeEnableToSchmAdd();
				}
			}
		}

		private void cmbFreePrtPprSchmGrpCd_SelectionChanged(object sender, EventArgs e)
		{
			if (this.cmbFreePrtPprSchmGrpCd.Items.Count > 0)
			{
				// �\�[�g���ʂ��̔�
				foreach (UltraGridRow row in this.gridFPSortInit.Rows)
					row.Cells[COL_FPSORTINIT_SORTINGORDER].Value = row.Index;

				int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
				_ds.Tables[TBL_FPSORTINIT].DefaultView.RowFilter = COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd;

				if (this.gridFPSortInit.Rows.Count > 0)
					this.gridFPSortInit.Rows[0].Activate();

				this.gridFPSortInit.DisplayLayout.Bands[0].Columns[COL_FPSORTINIT_SORTINGORDER].SortIndicator = SortIndicator.Ascending;
			}
		}

		private void ubSchmAdd_Click(object sender, EventArgs e)
		{
			try
			{
				int freePrtPprSchmGrpCd = this.ndtFreePrtPprSchmGrpCd.GetInt();

				// ���ɒǉ��ς݂̃X�L�[�}�O���[�v�͂͂���
				for (int ix = 0 ; ix != this.cmbFreePrtPprSchmGrpCd.Items.Count ; ix++)
				{
					if (freePrtPprSchmGrpCd == (int)this.cmbFreePrtPprSchmGrpCd.Items[ix].DataValue)
					{
						MessageBox.Show("���ɒǉ��ς݂̃X�L�[�}�O���[�v�R�[�h�ł�", ctMSG_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						return;
					}
				}

				DataRow[] drArray = _ds.Tables[TBL_FPSORTINIT].Select(COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD + "=" + 0);
				foreach (DataRow dr in drArray)
				{
					DataRow addRow = _ds.Tables[TBL_FPSORTINIT].NewRow();
					foreach (DataColumn col in _ds.Tables[TBL_FPSORTINIT].Columns)
					{
						if (col.ColumnName == COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD)
							addRow[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD] = freePrtPprSchmGrpCd;
						else
							addRow[col.ColumnName] = dr[col.ColumnName];
					}
					_ds.Tables[TBL_FPSORTINIT].Rows.Add(addRow);
				}

				UpdateFilterCommboBox();
			}
			finally
			{
				this.ndtFreePrtPprSchmGrpCd.Clear();
			}
		}

		private void gridFPSortInit_AfterRowActivate(object sender, EventArgs e)
		{
			this.gridFPSortInit.ActiveRow.Selected = true;

			ChangeEnableToMoveButton();
		}

		private void tedPrtItemSetFilter_ValueChanged(object sender, EventArgs e)
		{
			if (_ds.Tables[TBL_PRTITEMSET].Rows.Count > 0)
			{
				if (!string.IsNullOrEmpty(this.tedPrtItemSetFilter.Text))
					_ds.Tables[TBL_PRTITEMSET].DefaultView.RowFilter = COL_PRTITEMSET_FREEPRTPAPERITEMNM + " LIKE '%" + this.tedPrtItemSetFilter.Text + "%'";
				else
					_ds.Tables[TBL_PRTITEMSET].DefaultView.RowFilter = string.Empty;
			}
		}
	}

	/// <summary>
	/// �X�L�[�}���N���X
	/// </summary>
	internal class SchemaInfo
	{
		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="name">����</param>
		/// <param name="caption">�L���v�V����</param>
		/// <param name="type">�^</param>
        /// <param name="length"></param>
		public SchemaInfo(string name, string caption, Type type, int length)
		{
			_name = name;
			_caption = caption;
			_type = type;
			_length = length;
		}
		#endregion

		#region PrivateMember
		// ����
		private string _name;
		// �L���v�V����
		private string _caption;
		// �^
		private Type _type;
		// ����
		private int _length;
		#endregion

		#region Property
		/// <summary>����</summary>
		public string Name
		{
			get
			{
				if (string.IsNullOrEmpty(_name))
					return string.Empty;
				else
					return _name;
			}
			set { _name = value; }
		}

		/// <summary>�L���v�V����</summary>
		public string Caption
		{
			get
			{
				if (string.IsNullOrEmpty(_caption))
					return string.Empty;
				else
					return _caption;
			}
			set { _caption = value; }
		}

		/// <summary>�^</summary>
		public Type Type
		{
			get { return _type; }
			set { _type = value; }
		}

		/// <summary>����</summary>
		public int Length
		{
			get { return _length; }
			set { _length = value; }
		}
		#endregion
	}
}