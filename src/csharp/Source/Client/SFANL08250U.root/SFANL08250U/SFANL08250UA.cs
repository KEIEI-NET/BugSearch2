using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	public partial class SFANL08250UA : Form
	{
		#region Const
		// MessageBox�w�b�_�[�L���v�V����
		internal const string ctMSG_CAPTION = "���R���[���o���������l�ݒ�";
		
		// �e�[�u������
		private const string TBL_PRTITEMGRP = "PrtItemGrpRF";
		private const string TBL_PRTITEMSET = "PrtItemSetRF";
		private const string TBL_FREPEXCNDD = "FrePExCndDRF";
		private const string TBL_FPECNDINIT = "FPECndInitRF";
		// ��ʕ\���p
		private const string TBL_FREPPRECND_SETTING		= "FrePprECnd2Setting";
		private const string COL_FREEPRTPPRSCHMGRPCD	= "FreePrtPprSchmGrpCd";	// ���R���[�X�L�[�}�O���[�v�R�[�h
		private const string COL_EXTRACONDITIONTITLE	= "ExtraConditionTitle";	// ���o�����^�C�g��
		private const string COL_DISPLAYORDER			= "DisplayOrder";			// �\������
		private const string COL_FREPRTPPREXTRACONDCD	= "FrePrtPprExtraCondCd";	// ���R���[���o�����}��
		private const string COL_FREPPRECND				= "FrePprECnd2";			// ���R���[���o�����}�X�^
		// ���ʃt�@�C���w�b�_�[
		#region CommonFileHeader
		private const string COL_COMMON_CREATEDATETIME		= "CreateDateTime";		// �쐬����
		private const string COL_COMMON_UPDATEDATETIME		= "UpdateDateTime";		// �X�V����
		private const string COL_COMMON_ENTERPRISECODE		= "EnterpriseCode";		// ��ƃR�[�h
		private const string COL_COMMON_FILEHEADERGUID		= "FileHeaderGuid";		// GUID
		private const string COL_COMMON_UPDEMPLOYEECODE		= "UpdEmployeeCode";	// �X�V�]�ƈ��R�[�h
		private const string COL_COMMON_UPDASSEMBLYID1		= "UpdAssemblyId1";		// �X�V�A�Z���u��ID1
		private const string COL_COMMON_UPDASSEMBLYID2		= "UpdAssemblyId2";		// �X�V�A�Z���u��ID2
		private const string COL_COMMON_LOGICALDELETECODE	= "LogicalDeleteCode";	// �_���폜�敪
		#endregion
		// �󎚍��ڃO���[�v
		#region PrtItemGrp
		private const string COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD		= "FreePrtPprItemGrpCd";	// ���R���[���ڃO���[�v�R�[�h
		private const string COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM		= "FreePrtPprItemGrpNm";	// ���R���[���ڃO���[�v����
		private const string COL_PRTITEMGRP_PRINTPAPERUSEDIVCD		= "PrintPaperUseDivcd";		// ���[�g�p�敪
		private const string COL_PRTITEMGRP_EXTRACTIONPGID			= "ExtractionPgId";			// ���o�v���O����ID
		private const string COL_PRTITEMGRP_EXTRACTIONPGCLASSID		= "ExtractionPgClassId";	// ���o�v���O�����N���XID
		private const string COL_PRTITEMGRP_OUTPUTPGID				= "OutputPgId";				// �o�̓v���O����ID
		private const string COL_PRTITEMGRP_OUTPUTPGCLASSID			= "OutputPgClassId";		// �o�̓v���O�����N���XID
		private const string COL_PRTITEMGRP_DATAINPUTSYSTEM			= "DataInputSystem";		// �f�[�^���̓V�X�e��
		private const string COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS	= "LinkSlipDataInputSys";	// �����N�`�[�f�[�^���̓V�X�e��
		private const string COL_PRTITEMGRP_LINKSLIPPRTKIND			= "LinkSlipPrtKind";		// �����N�`�[������
		private const string COL_PRTITEMGRP_LINKSLIPPRTSETPPRID		= "LinkSlipPrtSetPprId";	// �����N�`�[����ݒ�p���[ID
		private const string COL_PRTITEMGRP_EXTRASECTIONKINDCD		= "ExtraSectionKindCd";		// ���o���_��ʋ敪
		private const string COL_PRTITEMGRP_EXTRASECTIONSELEXIST	= "ExtraSectionSelExist";	// ���o���_�I��L��
		private const string COL_PRTITEMGRP_FORMFEEDLINECOUNT		= "FormFeedLineCount";		// ���ōs��
		private const string COL_PRTITEMGRP_CRCHARCNT				= "CrCharCnt";				// ���s������
		#endregion
		// �󎚍��ڐݒ�
		#region PrtItemSet
		private const string COL_PRTITEMSET_FREEPRTPPRITEMGRPCD		= "FreePrtPprItemGrpCd";	// ���R���[���ڃO���[�v�R�[�h
		internal const string COL_PRTITEMSET_FREEPRTPAPERITEMCD		= "FreePrtPaperItemCd";		// ���R���[���ڃR�[�h
		internal const string COL_PRTITEMSET_FREEPRTPAPERITEMNM		= "FreePrtPaperItemNm";		// ���R���[���ږ���
		private const string COL_PRTITEMSET_FILENM					= "FileNm";					// �t�@�C������
		private const string COL_PRTITEMSET_DDCHARCNT				= "DDCharCnt";				// DD����
		private const string COL_PRTITEMSET_DDNAME					= "DDName";					// DD����
		private const string COL_PRTITEMSET_REPORTCONTROLCODE		= "ReportControlCode";		// ���|�[�g�R���g���[���敪
		private const string COL_PRTITEMSET_HEADERUSEDIVCD			= "HeaderUseDivCd";			// �w�b�_�[�g�p�敪
		private const string COL_PRTITEMSET_DETAILUSEDIVCD			= "DetailUseDivCd";			// ���׎g�p�敪
		private const string COL_PRTITEMSET_FOOTERUSEDIVCD			= "FooterUseDivCd";			// �t�b�^�[�g�p�敪
		internal const string COL_PRTITEMSET_EXTRACONDITIONDIVCD	= "ExtraConditionDivCd";	// ���o�����敪
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
		#endregion
		// ���R���[���o��������
		#region FrePExCndD
		private const string COL_FREPEXCNDD_EXTRACONDDETAILGRPCD	= "ExtraCondDetailGrpCd";	// ���o�������׃O���[�v�R�[�h
		private const string COL_FREPEXCNDD_EXTRACONDDETAILCODE		= "ExtraCondDetailCode";	// ���o�������׃R�[�h
		private const string COL_FREPEXCNDD_EXTRACONDDETAILNAME		= "ExtraCondDetailName";	// ���o�������ז���
		#endregion
		// ���R���[���o���������l
		#region FPECndInit
		private const string COL_FPECNDINIT_FREEPRTPPRSCHMGRPCD		= "FreePrtPprSchmGrpCd";	// ���R���[�X�L�[�}�O���[�v�R�[�h
		private const string COL_FPECNDINIT_FREPRTPPREXTRACONDCD	= "FrePrtPprExtraCondCd";	// ���R���[���o�����}��
		private const string COL_FPECNDINIT_DISPLAYORDER			= "DisplayOrder";			// �\������
		private const string COL_FPECNDINIT_STEXTRANUMCODE			= "StExtraNumCode";			// ���o�J�n�R�[�h�i���l�j
		private const string COL_FPECNDINIT_EDEXTRANUMCODE			= "EdExtraNumCode";			// ���o�I���R�[�h�i���l�j
		private const string COL_FPECNDINIT_STEXTRACHARCODE			= "StExtraCharCode";		// ���o�J�n�R�[�h�i�����j
		private const string COL_FPECNDINIT_EDEXTRACHARCODE			= "EdExtraCharCode";		// ���o�I���R�[�h�i�����j
		private const string COL_FPECNDINIT_STEXTRADATEBASECD		= "StExtraDateBaseCd";		// ���o�J�n���t�i��j
		private const string COL_FPECNDINIT_STEXTRADATESIGNCD		= "StExtraDateSignCd";		// ���o�J�n���t�i�����j
		private const string COL_FPECNDINIT_STEXTRADATENUM			= "StExtraDateNum";			// ���o�J�n���t�i���l�j
		private const string COL_FPECNDINIT_STEXTRADATEUNITCD		= "StExtraDateUnitCd";		// ���o�J�n���t�i�P�ʁj
		private const string COL_FPECNDINIT_STARTEXTRADATE			= "StartExtraDate";			// ���o�J�n���t�i���t�j
		private const string COL_FPECNDINIT_EDEXTRADATEBASECD		= "EdExtraDateBaseCd";		// ���o�I�����t�i��j
		private const string COL_FPECNDINIT_EDEXTRADATESIGNCD		= "EdExtraDateSignCd";		// ���o�I�����t�i�����j
		private const string COL_FPECNDINIT_EDEXTRADATENUM			= "EdExtraDateNum";			// ���o�I�����t�i���l�j
		private const string COL_FPECNDINIT_EDEXTRADATEUNITCD		= "EdExtraDateUnitCd";		// ���o�I�����t�i�P�ʁj
		private const string COL_FPECNDINIT_ENDEXTRADATE			= "EndExtraDate";			// ���o�I�����t�i���t�j
		private const string COL_FPECNDINIT_CHECKITEMCODE1			= "CheckItemCode1";			// �`�F�b�N���ڃR�[�h1
		private const string COL_FPECNDINIT_CHECKITEMCODE2			= "CheckItemCode2";			// �`�F�b�N���ڃR�[�h2
		private const string COL_FPECNDINIT_CHECKITEMCODE3			= "CheckItemCode3";			// �`�F�b�N���ڃR�[�h3
		private const string COL_FPECNDINIT_CHECKITEMCODE4			= "CheckItemCode4";			// �`�F�b�N���ڃR�[�h4
		private const string COL_FPECNDINIT_CHECKITEMCODE5			= "CheckItemCode5";			// �`�F�b�N���ڃR�[�h5
		private const string COL_FPECNDINIT_CHECKITEMCODE6			= "CheckItemCode6";			// �`�F�b�N���ڃR�[�h6
		private const string COL_FPECNDINIT_CHECKITEMCODE7			= "CheckItemCode7";			// �`�F�b�N���ڃR�[�h7
		private const string COL_FPECNDINIT_CHECKITEMCODE8			= "CheckItemCode8";			// �`�F�b�N���ڃR�[�h8
		private const string COL_FPECNDINIT_CHECKITEMCODE9			= "CheckItemCode9";			// �`�F�b�N���ڃR�[�h9
		private const string COL_FPECNDINIT_CHECKITEMCODE10			= "CheckItemCode10";		// �`�F�b�N���ڃR�[�h10
		#endregion
		#endregion

		#region PrivateMember
		// �f�[�^�ێ��pDataSet
		private DataSet				_ds;
		// �t�@�C�����C�A�E�g���ێ��p
		private List<SchemaInfo>	_fPECndInitSchemaInfoList;
		// �ύX�`�F�b�N�t���O
		private int					_buffCode;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08250UA()
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
				case TBL_FREPPRECND_SETTING:
				{
					schemaInfoList.Add(new SchemaInfo(COL_FREEPRTPPRSCHMGRPCD,	"�X�L�[�}�O���[�v",		typeof(int),			4));	// ���R���[�X�L�[�}�O���[�v�R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_FREPRTPPREXTRACONDCD,	"���o�����}��",			typeof(int),			2));	// ���R���[���o�����}��
					schemaInfoList.Add(new SchemaInfo(COL_DISPLAYORDER,			"�\������",				typeof(int),			4));	// �\������
					schemaInfoList.Add(new SchemaInfo(COL_EXTRACONDITIONTITLE,	"�����^�C�g��",			typeof(string),			30));	// ���o�����^�C�g��
					schemaInfoList.Add(new SchemaInfo(COL_FREPPRECND,			"���R���[���o�����}�X�^",	typeof(FrePprECnd2),	1));	// ���R���[���o�����}�X�^
					break;
				}
				case TBL_PRTITEMGRP:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"�쐬����",						typeof(long),	19));	// �쐬����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"�X�V����",						typeof(long),	19));	// �X�V����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"�_���폜�敪",					typeof(int),	2));	// �_���폜�敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD,	"���R���[���ڃO���[�v�R�[�h",		typeof(int),	4));	// ���R���[���ڃO���[�v�R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM,	"���R���[���ڃO���[�v����",		typeof(string),	20));	// ���R���[���ڃO���[�v����
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_PRINTPAPERUSEDIVCD,	"���[�g�p�敪",					typeof(int),	2));	// ���[�g�p�敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_EXTRACTIONPGID,		"���o�v���O����ID",				typeof(string),	16));	// ���o�v���O����ID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_EXTRACTIONPGCLASSID,	"���o�v���O�����N���XID",			typeof(string),	80));	// ���o�v���O�����N���XID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_OUTPUTPGID,			"�o�̓v���O����ID",				typeof(string),	16));	// �o�̓v���O����ID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_OUTPUTPGCLASSID,		"�o�̓v���O�����N���XID",			typeof(string),	80));	// �o�̓v���O�����N���XID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_DATAINPUTSYSTEM,		"�f�[�^���̓V�X�e��",				typeof(int),	2));	// �f�[�^���̓V�X�e��
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS,	"�����N�`�[�f�[�^���̓V�X�e��",	typeof(int),	2));	// �����N�`�[�f�[�^���̓V�X�e��
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_LINKSLIPPRTKIND,		"�����N�`�[������",				typeof(int),	4));	// �����N�`�[������
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_LINKSLIPPRTSETPPRID,	"�����N�`�[����ݒ�p���[ID",		typeof(string),	24));	// �����N�`�[����ݒ�p���[ID
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_EXTRASECTIONKINDCD,	"���o���_��ʋ敪",				typeof(int),	2));	// ���o���_��ʋ敪
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_EXTRASECTIONSELEXIST,	"���o���_�I��L��",				typeof(int),	2));	// ���o���_�I��L��
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_FORMFEEDLINECOUNT,		"���ōs��",						typeof(int),	4));	// ���ōs��
					schemaInfoList.Add(new SchemaInfo(COL_PRTITEMGRP_CRCHARCNT,				"���s������",					typeof(int),	4));	// ���s������
					break;
				}
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
				case TBL_FREPEXCNDD:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"�쐬����",						typeof(long),	19));	// �쐬����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"�X�V����",						typeof(long),	19));	// �X�V����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_ENTERPRISECODE,			"��ƃR�[�h",					typeof(string),	16));	// ��ƃR�[�h
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_FILEHEADERGUID,			"GUID",							typeof(Guid),	32));	// GUID
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDEMPLOYEECODE,			"�X�V�]�ƈ��R�[�h",				typeof(string),	9));	// �X�V�]�ƈ��R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDASSEMBLYID1,			"�X�V�A�Z���u��ID1",				typeof(string),	30));	// �X�V�A�Z���u��ID1
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDASSEMBLYID2,			"�X�V�A�Z���u��ID2",				typeof(string),	30));	// �X�V�A�Z���u��ID2
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"�_���폜�敪",					typeof(int),	2));	// �_���폜�敪
					schemaInfoList.Add(new SchemaInfo(COL_FREPEXCNDD_EXTRACONDDETAILGRPCD,	"���o�������׃O���[�v�R�[�h",		typeof(int),	4));	// ���o�������׃O���[�v�R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_FREPEXCNDD_EXTRACONDDETAILCODE,	"���o�������׃R�[�h",				typeof(int),	4));	// ���o�������׃R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_FREPEXCNDD_EXTRACONDDETAILNAME,	"���o�������ז���",				typeof(string),	20));	// ���o�������ז���
					break;
				}
				case TBL_FPECNDINIT:
				{
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_CREATEDATETIME,			"�쐬����",						typeof(long),	19));	// �쐬����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_UPDATEDATETIME,			"�X�V����",						typeof(long),	19));	// �X�V����
					schemaInfoList.Add(new SchemaInfo(COL_COMMON_LOGICALDELETECODE,			"�_���폜�敪",					typeof(int),	2));	// �_���폜�敪
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_FREEPRTPPRSCHMGRPCD,	"���R���[�X�L�[�}�O���[�v�R�[�h", typeof(int),		4));	// ���R���[�X�L�[�}�O���[�v�R�[�h
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_FREPRTPPREXTRACONDCD,	"���R���[���o�����}��",			typeof(int),	3));	// ���R���[���o�����}��
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_DISPLAYORDER,			"�\������",						typeof(int),	4));	// �\������
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRANUMCODE,		"���o�J�n�R�[�h�i���l�j",			typeof(int),	12));	// ���o�J�n�R�[�h�i���l�j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRANUMCODE,		"���o�I���R�[�h�i���l�j",			typeof(int),	12));	// ���o�I���R�[�h�i���l�j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRACHARCODE,		"���o�J�n�R�[�h�i�����j",			typeof(string),	30));	// ���o�J�n�R�[�h�i�����j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRACHARCODE,		"���o�I���R�[�h�i�����j",			typeof(string),	20));	// ���o�I���R�[�h�i�����j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRADATEBASECD,		"���o�J�n���t�i��j",			typeof(int),	2));	// ���o�J�n���t�i��j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRADATESIGNCD,		"���o�J�n���t�i�����j",			typeof(int),	2));	// ���o�J�n���t�i�����j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRADATENUM,		"���o�J�n���t�i���l�j",			typeof(int),	2));	// ���o�J�n���t�i���l�j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STEXTRADATEUNITCD,		"���o�J�n���t�i�P�ʁj",			typeof(int),	2));	// ���o�J�n���t�i�P�ʁj
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_STARTEXTRADATE,		"���o�J�n���t�i���t�j",			typeof(int),	8));	// ���o�J�n���t�i���t�j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRADATEBASECD,		"���o�I�����t�i��j",			typeof(int),	2));	// ���o�I�����t�i��j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRADATESIGNCD,		"���o�I�����t�i�����j",			typeof(int),	2));	// ���o�I�����t�i�����j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRADATENUM,		"���o�I�����t�i���l�j",			typeof(int),	2));	// ���o�I�����t�i���l�j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_EDEXTRADATEUNITCD,		"���o�I�����t�i�P�ʁj",			typeof(int),	2));	// ���o�I�����t�i�P�ʁj
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_ENDEXTRADATE,			"���o�I�����t�i���t�j",			typeof(int),	8));	// ���o�I�����t�i���t�j
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE1,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h1
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE2,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h2
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE3,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h3
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE4,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h4
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE5,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h5
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE6,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h6
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE7,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h7
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE8,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h8
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE9,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h9
					schemaInfoList.Add(new SchemaInfo(COL_FPECNDINIT_CHECKITEMCODE10,		"�`�F�b�N���ڃR�[�h1",			typeof(int),	8));	// �`�F�b�N���ڃR�[�h10
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
        /// <param name="allowDBNull"></param>
		private void CreateDataTableSchema(DataSet ds, string tableName, bool allowDBNull)
		{
			List<SchemaInfo> schemaInfoList = GetSchemaInfoList(tableName);

			if (schemaInfoList != null)
			{
				if (tableName == TBL_FREPPRECND_SETTING)
					_fPECndInitSchemaInfoList = schemaInfoList;

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
					ds.Tables[tableName].Columns[schemaInfo.Name].AllowDBNull = allowDBNull;
				}
			}
		}

		/// <summary>
		/// ��ʏ���������
		/// </summary>
		private void DisplayInitialize()
		{
			_ds.Tables[TBL_FREPPRECND_SETTING].Rows.Clear();
			_ds.Tables[TBL_PRTITEMGRP].Rows.Clear();
			_ds.Tables[TBL_PRTITEMSET].Rows.Clear();
			_ds.Tables[TBL_FREPEXCNDD].Rows.Clear();
			_ds.Tables[TBL_FPECNDINIT].Rows.Clear();

			StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];
			appendButtonTool.Checked = false;
			LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
			modeLabelTool.SharedProps.Caption = "CSV�㏑�����[�h";

			this.ndtDisplayOder.Clear();
			this.tedExtraConditionTitle.Text = string.Empty;
			this.cmdExtraConditionTypeCd.SelectedIndex = -1;

			UpdateFilterCommboBox();
		}

		private Type CreateDataClassFromDataRow<Type>(DataRow dr)
		{
			PropertyInfo[] propInfoArray = typeof(Type).GetProperties();

			Assembly assm = typeof(Type).Assembly;
			object instance = assm.CreateInstance(typeof(Type).FullName);

			foreach (PropertyInfo propInfo in propInfoArray)
			{
				if (dr.Table.Columns.Contains(propInfo.Name))
				{
					switch (propInfo.Name)
					{
						case COL_COMMON_CREATEDATETIME:
						case COL_COMMON_UPDATEDATETIME:
						{
							propInfo.SetValue(instance, new DateTime((long)dr[propInfo.Name]), null);
							break;
						}
						default:
						{
							if (propInfo.PropertyType.Equals(typeof(DateTime)))
								propInfo.SetValue(instance, TDateTime.LongDateToDateTime((int)dr[propInfo.Name]), null);
							else
								propInfo.SetValue(instance, dr[propInfo.Name], null);
							break;
						}
					}
				}
			}
			return (Type)instance;
		}

		private List<Type> CreateListFromDataSet<Type>(string tableName)
		{
			List<Type> retList = new List<Type>();
			PropertyInfo[] propInfoArray = typeof(Type).GetProperties();
			foreach (DataRow dr in _ds.Tables[tableName].Rows)
			{
				Assembly assm = typeof(Type).Assembly;
				object instance = assm.CreateInstance(typeof(Type).FullName);
				retList.Add((Type)instance);

				foreach (PropertyInfo propInfo in propInfoArray)
				{
					if (_ds.Tables[tableName].Columns.Contains(propInfo.Name))
					{
						switch (propInfo.Name)
						{
							case COL_COMMON_CREATEDATETIME:
							case COL_COMMON_UPDATEDATETIME:
							{
								propInfo.SetValue(instance, new DateTime((long)dr[propInfo.Name]), null);
								break;
							}
							default:
							{
								if (propInfo.PropertyType.Equals(typeof(DateTime)))
									propInfo.SetValue(instance, TDateTime.LongDateToDateTime((int)dr[propInfo.Name]), null);
								else
									propInfo.SetValue(instance, dr[propInfo.Name], null);
								break;
							}
						}
					}
				}
			}
			return retList;
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�쐬����
		/// </summary>
        /// <param name="freePrtPprSchmGrpCd">�X�L�[�}�O���[�v</param>
		/// <returns>���R���[���o�����ݒ�}�X�^���X�g</returns>
		private List<FrePprECnd2> CreateFrePprECnd2FromPrtItemSetList(int freePrtPprSchmGrpCd)
		{
			List<FrePprECnd2> frePprECndList = new List<FrePprECnd2>();
			List<PrtItemSetWork> prtItemSetList = CreateListFromDataSet<PrtItemSetWork>(TBL_PRTITEMSET);
			foreach (PrtItemSetWork prtItemSet in prtItemSetList)
			{
			    if (prtItemSet.ExtraConditionDivCd != 0)
					frePprECndList.Add(CreateFrePprECnd2FromPrtItemSet(prtItemSet, freePrtPprSchmGrpCd));
			}

			return frePprECndList;
		}

		private FrePprECnd2 CreateFrePprECnd2FromPrtItemSet(PrtItemSetWork prtItemSet, int freePrtPprSchmGrpCd)
		{
	        FrePprECnd2 frePprECnd = new FrePprECnd2();
			frePprECnd.CreateDateTime		= prtItemSet.CreateDateTime;
			frePprECnd.UpdateDateTime		= prtItemSet.UpdateDateTime;
			frePprECnd.LogicalDeleteCode	= prtItemSet.LogicalDeleteCode;
			frePprECnd.FreePrtPprSchmGrpCd	= freePrtPprSchmGrpCd;				// ���R���[�X�L�[�}�O���[�v�R�[�h
	        frePprECnd.FrePrtPprExtraCondCd = prtItemSet.FreePrtPaperItemCd;	// ���R���[���o�����}��
	        frePprECnd.ExtraConditionDivCd	= prtItemSet.ExtraConditionDivCd;	// ���o�����敪
	        frePprECnd.ExtraConditionTypeCd	= prtItemSet.ExtraConditionTypeCd;	// ���o�����^�C�v
	        frePprECnd.ExtraConditionTitle	= prtItemSet.FreePrtPaperItemNm;	// ���o�����^�C�g��
	        frePprECnd.DDName				= prtItemSet.DDName;				// DD����
	        frePprECnd.DDCharCnt			= prtItemSet.DDCharCnt;				// DD����
	        frePprECnd.ExtraCondDetailGrpCd = prtItemSet.ExtraCondDetailGrpCd;	// ���o�������׃O���[�v�R�[�h
	        frePprECnd.StExtraDateBaseCd	= 2;								// ���o�J�n���t�i��j
	        frePprECnd.EdExtraDateBaseCd	= 2;								// ���o�I�����t�i��j
	        frePprECnd.DisplayOrder			= 999;
	        frePprECnd.NecessaryExtraCondCd = prtItemSet.NecessaryExtraCondCd;	// �K�{���o�����敪
	        frePprECnd.FileNm				= prtItemSet.FileNm;				// �t�@�C������

			return frePprECnd;
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�}�[�W����
		/// </summary>
        /// <param name="frePprECndList">�}�[�W�Ώێ��R���[���o�����ݒ�}�X�^</param>
        /// <param name="fPECndInitList">�㏑���Ώێ��R���[���o�����ݒ�}�X�^</param>
		/// <returns>�}�[�W�ςݎ��R���[���o�����ݒ�}�X�^</returns>
		private List<FrePprECnd2> MergeFrePprECnd2(List<FrePprECnd2> frePprECndList, List<FPECndInitWork> fPECndInitList)
		{
			List<FrePprECnd2> retList = new List<FrePprECnd2>();
			foreach (FrePprECnd2 frePprECnd in frePprECndList)
			{
				FrePprECnd2 frePprECndClone = frePprECnd.Clone();

				FPECndInitWork fPECndInit = fPECndInitList.Find(
						delegate(FPECndInitWork fPECndInitWork)
						{
							if (fPECndInitWork.FreePrtPprSchmGrpCd == frePprECnd.FreePrtPprSchmGrpCd &&
								fPECndInitWork.FrePrtPprExtraCondCd == frePprECnd.FrePrtPprExtraCondCd)
								return true;
							else
								return false;
						}
					);
				if (fPECndInit != null)
				{
					frePprECndClone.FreePrtPprSchmGrpCd = fPECndInit.FreePrtPprSchmGrpCd;
					frePprECndClone.DisplayOrder		= fPECndInit.DisplayOrder;
					frePprECndClone.StExtraNumCode		= fPECndInit.StExtraNumCode;
					frePprECndClone.EdExtraNumCode		= fPECndInit.EdExtraNumCode;
					frePprECndClone.StExtraCharCode		= fPECndInit.StExtraCharCode;
					frePprECndClone.EdExtraCharCode		= fPECndInit.EdExtraCharCode;
					frePprECndClone.StExtraDateBaseCd	= fPECndInit.StExtraDateBaseCd;
					frePprECndClone.StExtraDateSignCd	= fPECndInit.StExtraDateSignCd;
					frePprECndClone.StExtraDateNum		= fPECndInit.StExtraDateNum;
					frePprECndClone.StExtraDateUnitCd	= fPECndInit.StExtraDateUnitCd;
					frePprECndClone.StartExtraDate		= fPECndInit.StartExtraDate;
					frePprECndClone.EdExtraDateBaseCd	= fPECndInit.EdExtraDateBaseCd;
					frePprECndClone.EdExtraDateSignCd	= fPECndInit.EdExtraDateSignCd;
					frePprECndClone.EdExtraDateNum		= fPECndInit.EdExtraDateNum;
					frePprECndClone.EdExtraDateUnitCd	= fPECndInit.EdExtraDateUnitCd;
					frePprECndClone.EndExtraDate		= fPECndInit.EndExtraDate;
					frePprECndClone.CheckItemCode1		= fPECndInit.CheckItemCode1;
					frePprECndClone.CheckItemCode2		= fPECndInit.CheckItemCode2;
					frePprECndClone.CheckItemCode3		= fPECndInit.CheckItemCode3;
					frePprECndClone.CheckItemCode4		= fPECndInit.CheckItemCode4;
					frePprECndClone.CheckItemCode5		= fPECndInit.CheckItemCode5;
					frePprECndClone.CheckItemCode6		= fPECndInit.CheckItemCode6;
					frePprECndClone.CheckItemCode7		= fPECndInit.CheckItemCode7;
					frePprECndClone.CheckItemCode8		= fPECndInit.CheckItemCode8;
					frePprECndClone.CheckItemCode9		= fPECndInit.CheckItemCode9;
					frePprECndClone.CheckItemCode10		= fPECndInit.CheckItemCode10;

					retList.Add(frePprECndClone);
				}
			}

			return retList;
		}

		/// <summary>
		/// �f�[�^�e�[�u�����X�V����
		/// </summary>
		/// <param name="frePprECnd">���R���[���o�����ݒ�}�X�^</param>
		/// <param name="index">�C���f�b�N�X</param>
		private void SetFrePprECnd2ToDataTable(FrePprECnd2 frePprECnd, int index)
		{
			DataRow dr;
			if (index < 0)
			{
				dr = _ds.Tables[TBL_FREPPRECND_SETTING].NewRow();
				_ds.Tables[TBL_FREPPRECND_SETTING].Rows.Add(dr);
			}
			else
			{
				dr = _ds.Tables[TBL_FREPPRECND_SETTING].Rows[index];
			}

			dr[COL_FREEPRTPPRSCHMGRPCD]		= frePprECnd.FreePrtPprSchmGrpCd;	// ���R���[�X�L�[�}�O���[�v�R�[�h
			dr[COL_FREPRTPPREXTRACONDCD]	= frePprECnd.FrePrtPprExtraCondCd;	// ���R���[���o�����}��
			dr[COL_DISPLAYORDER]			= frePprECnd.DisplayOrder;			// �\������
			dr[COL_EXTRACONDITIONTITLE]		= frePprECnd.ExtraConditionTitle;	// ���o�����^�C�g��
			dr[COL_FREPPRECND]				= frePprECnd;						// ���R���[���o�����}�X�^
		}

		private void UpdateFilterCommboBox()
		{
			this.cmbFreePrtPprSchmGrpCd.Items.Clear();
			List<int> schmGrpCdList = new List<int>();
			foreach (DataRow dr in _ds.Tables[TBL_FREPPRECND_SETTING].Rows)
			{
				if (!schmGrpCdList.Contains((int)dr[COL_FREEPRTPPRSCHMGRPCD]))
					schmGrpCdList.Add((int)dr[COL_FREEPRTPPRSCHMGRPCD]);
			}

			foreach (int schmGrpCd in schmGrpCdList)
				this.cmbFreePrtPprSchmGrpCd.Items.Add(schmGrpCd);

			if (this.cmbFreePrtPprSchmGrpCd.Items.Count > 0)
				this.cmbFreePrtPprSchmGrpCd.SelectedIndex = 0;
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
				if (_ds.Tables[TBL_FREPPRECND_SETTING].Rows.Count != 0)
				{
					this.ubFPECndInitAddRow.Focus();
					this.gridFPECndInit.ActiveRow = null;
					this.gridFPECndInit.Rows[0].Activate();

					Directory.SetCurrentDirectory(System.Windows.Forms.Application.StartupPath);

					StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];

					_ds.Tables[TBL_FPECNDINIT].Rows.Clear();
					List<FPECndInitWork> fPECndInitList = new List<FPECndInitWork>();
					foreach (DataRow dr in _ds.Tables[TBL_FREPPRECND_SETTING].Rows)
					{
						FrePprECnd2 frePprECnd2 = (FrePprECnd2)dr[COL_FREPPRECND];
						if (frePprECnd2.UsedFlg == 0)
						{
							frePprECnd2.StExtraNumCode		= 0;
							frePprECnd2.EdExtraNumCode		= 0;
							frePprECnd2.StExtraCharCode		= string.Empty;
							frePprECnd2.EdExtraCharCode		= string.Empty;
							frePprECnd2.StExtraDateBaseCd	= 2;
							frePprECnd2.StExtraDateSignCd	= 0;
							frePprECnd2.StExtraDateNum		= 0;
							frePprECnd2.StExtraDateUnitCd	= 0;
							frePprECnd2.StartExtraDate		= 0;
							frePprECnd2.EdExtraDateBaseCd	= 2;
							frePprECnd2.EdExtraDateSignCd	= 0;
							frePprECnd2.EdExtraDateNum		= 0;
							frePprECnd2.EdExtraDateUnitCd	= 0;
							frePprECnd2.EndExtraDate		= 0;
							frePprECnd2.CheckItemCode1		= -1;
							frePprECnd2.CheckItemCode2		= -1;
							frePprECnd2.CheckItemCode3		= -1;
							frePprECnd2.CheckItemCode4		= -1;
							frePprECnd2.CheckItemCode5		= -1;
							frePprECnd2.CheckItemCode6		= -1;
							frePprECnd2.CheckItemCode7		= -1;
							frePprECnd2.CheckItemCode8		= -1;
							frePprECnd2.CheckItemCode9		= -1;
							frePprECnd2.CheckItemCode10		= -1;
						}
						fPECndInitList.Add((FPECndInitWork)DBAndXMLDataMergeParts.CopyPropertyInClass(frePprECnd2, typeof(FPECndInitWork)));
					}
					PropertyInfo[] propInfoArray = typeof(FPECndInitWork).GetProperties();
					foreach (FPECndInitWork fPECndInit in fPECndInitList)
					{
						if (fPECndInit.FreePrtPprSchmGrpCd == 0) continue;

						DataRow dr = _ds.Tables[TBL_FPECNDINIT].NewRow();
						_ds.Tables[TBL_FPECNDINIT].Rows.Add(dr);

						foreach (PropertyInfo propInfo in propInfoArray)
						{
							if (_ds.Tables[TBL_FPECNDINIT].Columns.Contains(propInfo.Name))
							{
								switch (propInfo.Name)
								{
									case COL_COMMON_CREATEDATETIME:
									case COL_COMMON_UPDATEDATETIME:
									{
										dr[propInfo.Name] = ((DateTime)propInfo.GetValue(fPECndInit, null)).Ticks;
										break;
									}
									default:
									{
										if (propInfo.PropertyType.Equals(typeof(DateTime)))
											dr[propInfo.Name] = TDateTime.DateTimeToLongDate((DateTime)propInfo.GetValue(fPECndInit, null));
										else
											dr[propInfo.Name] = propInfo.GetValue(fPECndInit, null);
										break;
									}
								}
								
							}
						}
					}

					// ������ CSV�t�@�C���̕ۑ� ������
					// ���o���������l
					fileName = Path.Combine(SFANL08246CA.ctCSVSavePath, TBL_FPECNDINIT + ".csv");
					status = SFANL08246CA.SaveCsv(_ds, TBL_FPECNDINIT, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg);

					// ������ XML�t�@�C���̕ۑ� ������
					if (status == 0)
					{
						int freePrtPprItemGrpCd = (int)_ds.Tables[TBL_PRTITEMGRP].Rows[0][COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];
						fileName = Path.Combine(SFANL08246CA.ctXMLSavePath, TBL_FPECNDINIT + "_" + freePrtPprItemGrpCd + ".xml");
						status = SFANL08246CA.SaveXml(_ds, TBL_FPECNDINIT, string.Empty, fileName, out errMsg);
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
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void utmMainToolbar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
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
					this.openFileDialog.Filter = "���o���������lXML�t�@�C��|FPECndInit*.xml";
					this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
					if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
						DisplayInitialize();

						// ���R���[���o���������l
						_ds.Tables[TBL_FPECNDINIT].ReadXml(this.openFileDialog.FileName);

						// �󎚍��ڃO���[�v
						this.openFileDialog.Filter = "�󎚍��ڃO���[�vXML�t�@�C��|PrtItemGrp*.xml";
						this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
						if (this.openFileDialog.ShowDialog() == DialogResult.OK)
						{
							// �󎚍��ڃO���[�v
							_ds.Tables[TBL_PRTITEMGRP].ReadXml(this.openFileDialog.FileName);
							// �󎚍��ڐݒ�
							string fileName = Path.GetFileName(this.openFileDialog.FileName);
							string filePath = Path.Combine(Path.GetDirectoryName(this.openFileDialog.FileName), fileName.Replace(TBL_PRTITEMGRP, TBL_PRTITEMSET));
							if (File.Exists(filePath))
								_ds.Tables[TBL_PRTITEMSET].ReadXml(filePath);
							// ���R���[���o��������
							filePath = Path.Combine(Path.GetDirectoryName(this.openFileDialog.FileName), TBL_FREPEXCNDD + ".xml");
							if (File.Exists(filePath))
								_ds.Tables[TBL_FREPEXCNDD].ReadXml(filePath);

							List<FPECndInitWork> fPECndInitList = CreateListFromDataSet<FPECndInitWork>(TBL_FPECNDINIT);
							List<int> schmGrpCdList = new List<int>();
							foreach (FPECndInitWork fPECndInitWork in fPECndInitList)
								if (!schmGrpCdList.Contains(fPECndInitWork.FreePrtPprSchmGrpCd))
									schmGrpCdList.Add(fPECndInitWork.FreePrtPprSchmGrpCd);

							List<FrePprECnd2> frePprECndList = new List<FrePprECnd2>();
							foreach (int schmGrpCd in schmGrpCdList)
							{
								List<FrePprECnd2> wkList = CreateFrePprECnd2FromPrtItemSetList(schmGrpCd);
								frePprECndList.AddRange(wkList);
							}
							frePprECndList = MergeFrePprECnd2(frePprECndList, fPECndInitList);
							foreach (FrePprECnd2 frePprECnd in frePprECndList)
								SetFrePprECnd2ToDataTable(frePprECnd, -1);

							UpdateFilterCommboBox();
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
					this.openFileDialog.Filter = "�󎚍��ڃO���[�vXML�t�@�C��|PrtItemGrp*.xml";
					this.openFileDialog.InitialDirectory = Path.Combine(System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath);
					if (this.openFileDialog.ShowDialog() == DialogResult.OK)
					{
						DisplayInitialize();

						// �󎚍��ڃO���[�v
						_ds.Tables[TBL_PRTITEMGRP].ReadXml(this.openFileDialog.FileName);
						// �󎚍��ڐݒ�
						string fileName = Path.GetFileName(this.openFileDialog.FileName);
						string filePath = Path.Combine(Path.GetDirectoryName(this.openFileDialog.FileName), fileName.Replace(TBL_PRTITEMGRP, TBL_PRTITEMSET));
						if (File.Exists(filePath))
							_ds.Tables[TBL_PRTITEMSET].ReadXml(filePath);
						// ���R���[���o��������
						filePath = Path.Combine(Path.GetDirectoryName(this.openFileDialog.FileName), TBL_FREPEXCNDD + ".xml");
						if (File.Exists(filePath))
							_ds.Tables[TBL_FREPEXCNDD].ReadXml(filePath);

						// �󎚍��ڐݒ聨���o�����ݒ�쐬
						List<FrePprECnd2> frePprECndList = CreateFrePprECnd2FromPrtItemSetList(0);
						// �\������ASC,�K�{���o�����敪DESC,���R���[���o�����}��ASC���Ń\�[�g
						frePprECndList.Sort(new FrePprECnd2Compare());
						// �\�����ʂ��̔�
						int displayOrder = 1;
						foreach (FrePprECnd2 frePprECnd in frePprECndList)
						{
							if (frePprECnd.NecessaryExtraCondCd == 1)
								frePprECnd.DisplayOrder = displayOrder;
							displayOrder++;
						}

						foreach (FrePprECnd2 frePprECnd in frePprECndList)
							SetFrePprECnd2ToDataTable(frePprECnd, -1);

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
				case "Schema_ButtonTool":
				{
					try
					{
						List<int> schmGrpCdList = new List<int>();
						for (int ix = 0 ; ix != this.cmbFreePrtPprSchmGrpCd.Items.Count ; ix++)
							schmGrpCdList.Add((int)this.cmbFreePrtPprSchmGrpCd.Items[ix].DataValue);
						SFANL08250UC copySchmGrpSelectFrom = new SFANL08250UC();
						DialogResult dlgRet = copySchmGrpSelectFrom.ShowDialog(schmGrpCdList);
						switch (dlgRet)
						{
							case DialogResult.OK:
							{
								this.ubFPECndInitAddRow.Focus();

								if (copySchmGrpSelectFrom.SelectedSchmGrpCd < 0)
								{
									// �󎚍��ڐݒ聨���o�����ݒ�쐬
									List<FrePprECnd2> frePprECndList = CreateFrePprECnd2FromPrtItemSetList(copySchmGrpSelectFrom.NewSchmGrpCd);
									// �\������ASC,�K�{���o�����敪DESC,���R���[���o�����}��ASC���Ń\�[�g
									frePprECndList.Sort(new FrePprECnd2Compare());
									// �\�����ʂ��̔�
									int displayOrder = 1;
									foreach (FrePprECnd2 frePprECnd in frePprECndList)
									{
										if (frePprECnd.NecessaryExtraCondCd == 1)
											frePprECnd.DisplayOrder = displayOrder;
										displayOrder++;
									}

									foreach (FrePprECnd2 frePprECnd in frePprECndList)
										SetFrePprECnd2ToDataTable(frePprECnd, -1);
								}
								else
								{
									DataRow[] drArray
										= _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + copySchmGrpSelectFrom.SelectedSchmGrpCd);
									if (drArray != null && drArray.Length > 0)
									{
										List<FrePprECnd2> frePprECndList = new List<FrePprECnd2>();
										foreach (DataRow dr in drArray)
										{
											FrePprECnd2 frePprECndClone = ((FrePprECnd2)dr[COL_FREPPRECND]).Clone();
											frePprECndClone.FreePrtPprSchmGrpCd = copySchmGrpSelectFrom.NewSchmGrpCd;
											frePprECndList.Add(frePprECndClone);
										}
										foreach (FrePprECnd2 frePprECnd in frePprECndList)
											SetFrePprECnd2ToDataTable(frePprECnd, -1);
									}
								}

								UpdateFilterCommboBox();
								break;
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(
							ex.Message,
							ctMSG_CAPTION,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1);
					}
					break;
				}
			}
		}

		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void SFANL08242UA_Load(object sender, EventArgs e)
		{
			string message = string.Empty;
			try
			{
				// �󎚍��ڃO���[�v
				CreateDataTableSchema(_ds, TBL_PRTITEMGRP, false);
				// �󎚍��ڐݒ�
				CreateDataTableSchema(_ds, TBL_PRTITEMSET, false);
				// ���R���[���o��������
				CreateDataTableSchema(_ds, TBL_FREPEXCNDD, false);
				// ���R���[���o���������l
				CreateDataTableSchema(_ds, TBL_FPECNDINIT, false);
				// ���R���[���o�����ݒ���
				CreateDataTableSchema(_ds, TBL_FREPPRECND_SETTING, true);

				this.gridFPECndInit.DataSource = _ds.Tables[TBL_FREPPRECND_SETTING];

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
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridFPECndInit_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			if (_fPECndInitSchemaInfoList != null)
			{
				foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
				{
					SchemaInfo schemaInfo = _fPECndInitSchemaInfoList.Find(
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

					switch (col.Key)
					{
						case COL_DISPLAYORDER:	// �\������
						{
							col.CellAppearance.TextHAlign = HAlign.Right;
							col.CellActivation = Activation.NoEdit;
							col.SortIndicator = SortIndicator.Ascending;
							break;
						}
						case COL_EXTRACONDITIONTITLE:	// ���o�����^�C�g��
						{
							col.CellActivation = Activation.NoEdit;
							break;
						}
						case COL_FREEPRTPPRSCHMGRPCD:	// ���R���[�X�L�[�}�O���[�v�R�[�h
						case COL_FREPRTPPREXTRACONDCD:	// ���R���[���o�����}��
						case COL_FREPPRECND:	// ���R���[���o�����}�X�^
						{
							col.Hidden = true;
							break;
						}
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
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridFPECndInit_AfterRowActivate(object sender, EventArgs e)
		{
			this.gridFPECndInit.ActiveRow.Selected = true;

			this.pnlInitSetting.Controls.Clear();

			int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
			int frePrtPprExtraCondCd = (int)this.gridFPECndInit.ActiveRow.Cells[COL_FREPRTPPREXTRACONDCD].Value;

			DataRow[] drArray = _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd + " AND " + COL_FREPRTPPREXTRACONDCD + "=" + frePrtPprExtraCondCd);
			if (drArray != null && drArray.Length > 0)
			{
				FrePprECnd2 frePprECnd = drArray[0][COL_FREPPRECND] as FrePprECnd2;
				List<FrePExCndD> frePExCndDList = CreateListFromDataSet<FrePExCndD>(TBL_FREPEXCNDD);

				Control defSettingCtrl = SFANL08132CA.GetExtrSettingControl(frePprECnd, frePExCndDList);
				if (defSettingCtrl != null)
				{
					this.pnlInitSetting.Controls.Add(defSettingCtrl);
					defSettingCtrl.Dock = DockStyle.Top;

					this.cmdExtraConditionTypeCd.Items.Clear();
					switch (frePprECnd.ExtraConditionDivCd)
					{
						case 1:
						{
							this.cmdExtraConditionTypeCd.Items.Add(0, "���S��v");
							this.cmdExtraConditionTypeCd.Items.Add(1, "�͈�");
							break;
						}
						case 2:
						case 3:
						{
							this.cmdExtraConditionTypeCd.Items.Add(0, "���S��v");
							this.cmdExtraConditionTypeCd.Items.Add(1, "�͈�");
							this.cmdExtraConditionTypeCd.Items.Add(2, "�����܂�����");
							break;
						}
						case 4:
						{
							this.cmdExtraConditionTypeCd.Items.Add(0, "���S��v");
							this.cmdExtraConditionTypeCd.Items.Add(1, "�͈�");
							this.cmdExtraConditionTypeCd.Items.Add(3, "���ԁi�J�n����j");
							this.cmdExtraConditionTypeCd.Items.Add(4, "���ԁi�I������j");
							break;
						}
						case 5:
						case 6:
						{
							this.cmdExtraConditionTypeCd.Items.Add(0, "�@");
							break;
						}
					}

					this.tedExtraConditionTitle.Text = frePprECnd.ExtraConditionTitle;
					this.ndtDisplayOder.SetInt(frePprECnd.DisplayOrder);
					this.cmdExtraConditionTypeCd.Value = frePprECnd.ExtraConditionTypeCd;
				}
			}
		}

		/// <summary>
		/// BeforeRowDeactivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �s����A�N�e�B�u�ɂȂ�O�ɔ������܂��B</br>
		/// <br>Programer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridFPECndInit_BeforeRowDeactivate(object sender, CancelEventArgs e)
		{
			int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
			int frePrtPprExtraCondCd = (int)this.gridFPECndInit.ActiveRow.Cells[COL_FREPRTPPREXTRACONDCD].Value;

			DataRow[] drArray = _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd + " AND " + COL_FREPRTPPREXTRACONDCD + "=" + frePrtPprExtraCondCd);
			if (drArray != null && drArray.Length > 0)
			{
				FrePprECnd2 frePprECnd = drArray[0][COL_FREPPRECND] as FrePprECnd2;

				string controlName = SFANL08132CA.GetControlName(frePprECnd);
				if (this.pnlInitSetting.Controls.ContainsKey(controlName))
				{
					IFreePrintUserControl iFreePrintUserControl = this.pnlInitSetting.Controls[controlName] as IFreePrintUserControl;
					FrePprECnd wkFrePprECnd = (FrePprECnd)frePprECnd;
					iFreePrintUserControl.GetFrePprECndInfo(ref wkFrePprECnd);

					SetFrePprECnd2ToDataTable(frePprECnd, _ds.Tables[TBL_FREPPRECND_SETTING].Rows.IndexOf(drArray[0]));

					frePprECnd.ExtraConditionTitle = this.tedExtraConditionTitle.Text;
					frePprECnd.DisplayOrder = this.ndtDisplayOder.GetInt();
					frePprECnd.ExtraConditionTypeCd = (int)this.cmdExtraConditionTypeCd.Value;
				}
			}
		}

		private void ndtDisplayOder_AfterExitEditMode(object sender, EventArgs e)
		{
			if (_buffCode == this.ndtDisplayOder.GetInt()) return;

			int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
			int frePrtPprExtraCondCd = (int)this.gridFPECndInit.ActiveRow.Cells[COL_FREPRTPPREXTRACONDCD].Value;

			DataRow[] drArray = _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd + " AND " + COL_FREPRTPPREXTRACONDCD + "=" + frePrtPprExtraCondCd);
			if (drArray != null && drArray.Length > 0)
			{
				FrePprECnd2 frePprECnd = drArray[0][COL_FREPPRECND] as FrePprECnd2;
				frePprECnd.DisplayOrder = this.ndtDisplayOder.GetInt();

				SetFrePprECnd2ToDataTable(frePprECnd, _ds.Tables[TBL_FREPPRECND_SETTING].Rows.IndexOf(drArray[0]));

				this.gridFPECndInit.DisplayLayout.Bands[0].Columns[COL_DISPLAYORDER].SortIndicator
					= SortIndicator.Ascending;
			}
		}

		private void cmbFreePrtPprSchmGrpCd_SelectionChanged(object sender, EventArgs e)
		{
			int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
			_ds.Tables[TBL_FREPPRECND_SETTING].DefaultView.RowFilter = COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd;

			if (this.gridFPECndInit.Rows.Count > 0)
				this.gridFPECndInit.Rows[0].Activate();
		}

		private void ubFPECndInitAddRow_Click(object sender, EventArgs e)
		{
			try
			{
				List<int> extraCndCdList = new List<int>();
				foreach (UltraGridRow row in this.gridFPECndInit.Rows)
					extraCndCdList.Add((int)row.Cells[COL_FREPRTPPREXTRACONDCD].Value);

				SFANL08250UB newRowDataSelectForm = new SFANL08250UB();
				DialogResult dlgRet = newRowDataSelectForm.ShowDialog(_ds.Tables[TBL_PRTITEMSET], extraCndCdList);
				switch (dlgRet)
				{
					case DialogResult.OK:
					{
						if (newRowDataSelectForm.SelectedRow != null)
						{
							PrtItemSetWork prtItemSet
								= CreateDataClassFromDataRow<PrtItemSetWork>(newRowDataSelectForm.SelectedRow);
							if (prtItemSet != null)
							{
								FrePprECnd2 frePprECnd = CreateFrePprECnd2FromPrtItemSet(prtItemSet, (int)this.cmbFreePrtPprSchmGrpCd.Value);
								SetFrePprECnd2ToDataTable(frePprECnd, -1);
							}
						}
						break;
					}
					case DialogResult.Abort:
					{
						MessageBox.Show("�ǉ��o����s�͂���܂���", ctMSG_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					ex.Message,
					ctMSG_CAPTION,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
			}
		}

		private void ubFPECndInitDelRow_Click(object sender, EventArgs e)
		{
			int focusSetIndex = 0;

			if (this.gridFPECndInit.ActiveRow != null)
			{
				// �폜�ΏۂƂȂ�DataRow���擾
				focusSetIndex = Math.Max(focusSetIndex, this.gridFPECndInit.ActiveRow.Index);

				int freePrtPprSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;
				int frePrtPprExtraCondCd = (int)this.gridFPECndInit.ActiveRow.Cells[COL_FREPRTPPREXTRACONDCD].Value;

				DataRow[] drArray = _ds.Tables[TBL_FREPPRECND_SETTING].Select(COL_FREEPRTPPRSCHMGRPCD + "=" + freePrtPprSchmGrpCd + " AND " + COL_FREPRTPPREXTRACONDCD + "=" + frePrtPprExtraCondCd);
				if (drArray != null && drArray.Length > 0)
				{
					// �I���s���폜
					_ds.Tables[TBL_FREPPRECND_SETTING].Rows.Remove(drArray[0]);
					if (focusSetIndex > 0) focusSetIndex--;

					// �s���c���Ă���ꍇ��1�s�ڂ��A�N�e�B�u��
					if (this.gridFPECndInit.Rows.Count > 0)
						this.gridFPECndInit.Rows[focusSetIndex].Activate();
					else
						UpdateFilterCommboBox();
				}
			}
			else
			{
				MessageBox.Show("�폜����s��I�����Ă�������", ctMSG_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
			}
		}

		private void ndtDisplayOder_Enter(object sender, EventArgs e)
		{
			_buffCode = this.ndtDisplayOder.GetInt();
		}

		private void cmbFreePrtPprSchmGrpCd_Enter(object sender, EventArgs e)
		{
			if (this.gridFPECndInit.ActiveRow != null)
				gridFPECndInit_BeforeRowDeactivate(sender, new CancelEventArgs());
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

	/// <summary>
	/// 
	/// </summary>
	internal class FrePprECnd2 : FrePprECnd
	{
		#region PrivateMember
		/// <summary>���R���[�X�L�[�}�O���[�v�R�[�h</summary>
		private Int32 _freePrtPprSchmGrpCd;
		#endregion

		#region Property
		/// public propaty name  :  FreePrtPprSchmGrpCd
		/// <summary>���R���[�X�L�[�}�O���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[�X�L�[�}�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FreePrtPprSchmGrpCd
		{
			get { return _freePrtPprSchmGrpCd; }
			set { _freePrtPprSchmGrpCd = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>FrePprECnd�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECnd�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprECnd2()
			: base()
		{
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����(�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID)</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="frePrtPprExtraCondCd">���R���[���o�����}��</param>
		/// <param name="displayOrder">�\������</param>
		/// <param name="extraConditionDivCd">���o�����敪(0:�g�p�s��,1:���l�^,2:�����^�i���p�j,3:�����^�i�S�p�j,4:���t�^,5:�R���{�^,6:�`�F�b�N�^)</param>
		/// <param name="extraConditionTypeCd">���o�����^�C�v(0:��v,1:�͈�,2:�����܂�,3:����)</param>
		/// <param name="extraConditionTitle">���o�����^�C�g��</param>
		/// <param name="dDCharCnt">DD����</param>
		/// <param name="dDName">DD����(�������œo�^)</param>
		/// <param name="stExtraNumCode">���o�J�n�R�[�h�i���l�j</param>
		/// <param name="edExtraNumCode">���o�I���R�[�h�i���l�j</param>
		/// <param name="stExtraCharCode">���o�J�n�R�[�h�i�����j</param>
		/// <param name="edExtraCharCode">���o�I���R�[�h�i�����j</param>
		/// <param name="stExtraDateBaseCd">���o�J�n���t�i��j(0:�O�X��,1:�O��,2:�{��,3:����,4:���X��,5:���t�w��)</param>
		/// <param name="stExtraDateSignCd">���o�J�n���t�i�����j(0:�{�i�v���X�j,1:�|�i�}�C�i�X�j)</param>
		/// <param name="stExtraDateNum">���o�J�n���t�i���l�j</param>
		/// <param name="stExtraDateUnitCd">���o�J�n���t�i�P�ʁj(0:��,1:�T,2:��,3:�N)</param>
		/// <param name="startExtraDate">���o�J�n���t�i���t�j</param>
		/// <param name="edExtraDateBaseCd">���o�I�����t�i��j(0:�O�X��,1:�O��,2:�{��,3:����,4:���X��,5:���t�w��)</param>
		/// <param name="edExtraDateSignCd">���o�I�����t�i�����j(0:�{�i�v���X�j,1:�|�i�}�C�i�X�j)</param>
		/// <param name="edExtraDateNum">���o�I�����t�i���l�j</param>
		/// <param name="edExtraDateUnitCd">���o�I�����t�i�P�ʁj(0:��,1:�T,2:��,3:�N)</param>
		/// <param name="endExtraDate">���o�I�����t�i���t�j</param>
		/// <param name="extraCondDetailGrpCd">���o�������׃O���[�v�R�[�h(���o�����敪���R���{�{�b�N�X�^�̎��Ɏg�p)</param>
		/// <param name="necessaryExtraCondCd">�K�{���o�����敪(0:�C��,1:�K�{)</param>
		/// <param name="checkItemCode1">�`�F�b�N���ڃR�[�h1</param>
		/// <param name="checkItemCode2">�`�F�b�N���ڃR�[�h2</param>
		/// <param name="checkItemCode3">�`�F�b�N���ڃR�[�h3</param>
		/// <param name="checkItemCode4">�`�F�b�N���ڃR�[�h4</param>
		/// <param name="checkItemCode5">�`�F�b�N���ڃR�[�h5</param>
		/// <param name="checkItemCode6">�`�F�b�N���ڃR�[�h6</param>
		/// <param name="checkItemCode7">�`�F�b�N���ڃR�[�h7</param>
		/// <param name="checkItemCode8">�`�F�b�N���ڃR�[�h8</param>
		/// <param name="checkItemCode9">�`�F�b�N���ڃR�[�h9</param>
		/// <param name="checkItemCode10">�`�F�b�N���ڃR�[�h10</param>
		/// <param name="fileNm">�t�@�C������(DB�̃e�[�u��ID)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="freePrtPprSchmGrpCd"></param>
		/// <returns>FrePprECnd�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECnd�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprECnd2(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 frePrtPprExtraCondCd, Int32 displayOrder, Int32 extraConditionDivCd, Int32 extraConditionTypeCd, string extraConditionTitle, Int32 dDCharCnt, string dDName, Int64 stExtraNumCode, Int64 edExtraNumCode, string stExtraCharCode, string edExtraCharCode, Int32 stExtraDateBaseCd, Int32 stExtraDateSignCd, Int32 stExtraDateNum, Int32 stExtraDateUnitCd, Int32 startExtraDate, Int32 edExtraDateBaseCd, Int32 edExtraDateSignCd, Int32 edExtraDateNum, Int32 edExtraDateUnitCd, Int32 endExtraDate, Int32 extraCondDetailGrpCd, Int32 necessaryExtraCondCd, Int32 checkItemCode1, Int32 checkItemCode2, Int32 checkItemCode3, Int32 checkItemCode4, Int32 checkItemCode5, Int32 checkItemCode6, Int32 checkItemCode7, Int32 checkItemCode8, Int32 checkItemCode9, Int32 checkItemCode10, string fileNm, string enterpriseName, string updEmployeeName, int freePrtPprSchmGrpCd)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this.EnterpriseCode = enterpriseCode;
			this.FileHeaderGuid = fileHeaderGuid;
			this.UpdEmployeeCode = updEmployeeCode;
			this.UpdAssemblyId1 = updAssemblyId1;
			this.UpdAssemblyId2 = updAssemblyId2;
			this.LogicalDeleteCode = logicalDeleteCode;
			this.OutputFormFileName = outputFormFileName;
			this.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
			this.FrePrtPprExtraCondCd = frePrtPprExtraCondCd;
			this.DisplayOrder = displayOrder;
			this.ExtraConditionDivCd = extraConditionDivCd;
			this.ExtraConditionTypeCd = extraConditionTypeCd;
			this.ExtraConditionTitle = extraConditionTitle;
			this.DDCharCnt = dDCharCnt;
			this.DDName = dDName;
			this.StExtraNumCode = stExtraNumCode;
			this.EdExtraNumCode = edExtraNumCode;
			this.StExtraCharCode = stExtraCharCode;
			this.EdExtraCharCode = edExtraCharCode;
			this.StExtraDateBaseCd = stExtraDateBaseCd;
			this.StExtraDateSignCd = stExtraDateSignCd;
			this.StExtraDateNum = stExtraDateNum;
			this.StExtraDateUnitCd = stExtraDateUnitCd;
			this.StartExtraDate = startExtraDate;
			this.EdExtraDateBaseCd = edExtraDateBaseCd;
			this.EdExtraDateSignCd = edExtraDateSignCd;
			this.EdExtraDateNum = edExtraDateNum;
			this.EdExtraDateUnitCd = edExtraDateUnitCd;
			this.EndExtraDate = endExtraDate;
			this.ExtraCondDetailGrpCd = extraCondDetailGrpCd;
			this.NecessaryExtraCondCd = necessaryExtraCondCd;
			this.CheckItemCode1 = checkItemCode1;
			this.CheckItemCode2 = checkItemCode2;
			this.CheckItemCode3 = checkItemCode3;
			this.CheckItemCode4 = checkItemCode4;
			this.CheckItemCode5 = checkItemCode5;
			this.CheckItemCode6 = checkItemCode6;
			this.CheckItemCode7 = checkItemCode7;
			this.CheckItemCode8 = checkItemCode8;
			this.CheckItemCode9 = checkItemCode9;
			this.CheckItemCode10 = checkItemCode10;
			this.FileNm = fileNm;
			this.EnterpriseName = enterpriseName;
			this.UpdEmployeeName = updEmployeeName;
			this._freePrtPprSchmGrpCd = freePrtPprSchmGrpCd;

		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^��������
		/// </summary>
		/// <returns>FrePprECnd�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����FrePprECnd�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public new FrePprECnd2 Clone()
		{
			return new FrePprECnd2(this.CreateDateTime, this.UpdateDateTime, this.EnterpriseCode, this.FileHeaderGuid, this.UpdEmployeeCode, this.UpdAssemblyId1, this.UpdAssemblyId2, this.LogicalDeleteCode, this.OutputFormFileName, this.UserPrtPprIdDerivNo, this.FrePrtPprExtraCondCd, this.DisplayOrder, this.ExtraConditionDivCd, this.ExtraConditionTypeCd, this.ExtraConditionTitle, this.DDCharCnt, this.DDName, this.StExtraNumCode, this.EdExtraNumCode, this.StExtraCharCode, this.EdExtraCharCode, this.StExtraDateBaseCd, this.StExtraDateSignCd, this.StExtraDateNum, this.StExtraDateUnitCd, this.StartExtraDate, this.EdExtraDateBaseCd, this.EdExtraDateSignCd, this.EdExtraDateNum, this.EdExtraDateUnitCd, this.EndExtraDate, this.ExtraCondDetailGrpCd, this.NecessaryExtraCondCd, this.CheckItemCode1, this.CheckItemCode2, this.CheckItemCode3, this.CheckItemCode4, this.CheckItemCode5, this.CheckItemCode6, this.CheckItemCode7, this.CheckItemCode8, this.CheckItemCode9, this.CheckItemCode10, this.FileNm, this.EnterpriseName, this.UpdEmployeeName, this._freePrtPprSchmGrpCd);
		}
		#endregion
	}

	/// <summary>
	/// �󎚍��ڐݒ��r�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �󎚍��ڐݒ���\�[�g����ۂɎg�p����Compare�N���X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal class FrePprECnd2Compare : IComparer<FrePprECnd2>
	{
		#region PublicMethod
		/// <summary>
		/// ��r����
		/// </summary>
		/// <param name="x">��r�Ώ�1</param>
		/// <param name="y">��r�Ώ�2</param>
		/// <returns>��r����</returns>
		public int Compare(FrePprECnd2 x, FrePprECnd2 y)
		{
			int retCompare = 0;
			retCompare = x.DisplayOrder - y.DisplayOrder;
			if (retCompare == 0)
			{
				retCompare = y.NecessaryExtraCondCd - x.NecessaryExtraCondCd;
				if (retCompare == 0)
				{
					retCompare = x.FrePrtPprExtraCondCd - y.FrePrtPprExtraCondCd;
				}
			}
			return retCompare;
		}
		#endregion
	}
}