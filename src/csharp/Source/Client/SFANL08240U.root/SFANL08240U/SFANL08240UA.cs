using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Tools;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���R���[�󎚍��ڐݒ�UI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R���[�󎚍��ڐݒ�UI�N���X�ł��B</br>
    /// <br>Programmer	: 22024 ����@�_�u</br>
    /// <br>Date		: 2007.07.03</br>
    /// <br></br>
    /// <br>Update Note	: 2008.06.04  22018  ��� ���b</br>
    /// <br>             : �@�@PM.NS�����ύX</br>
    /// <br>             :   �A���ו��ʋ@�\��ǉ�</br>
    /// <br></br>
    /// <br>Update Note	: 2009.04.21  22018  ��� ���b</br>
    /// <br>             : �@�@�\�[�g���ݒ�@�\��ǉ�</br>
    /// <br></br>
    /// </remarks>
    public partial class SFANL08240UA : Form
    {
        #region Const
        // MessageBox�w�b�_�[�L���v�V����
        private const string ctMSG_CAPTION = "���R���[�󎚍��ڐݒ�";

        // Excel�t�@�C������
        private const string ctPrtItemGrpLayoutNm = "FNo0000�󎚍��ڃO���[�v�}�X�^.xls";
        private const string ctPrtItemSetLayoutNm = "FNo0000�󎚍��ڐݒ�}�X�^.xls";
        private const string ctFrePExCndDLayoutNm = "FNo0000���R���[���o�������׃}�X�^.xls";

        // �e�[�u������
        private const string TBL_PRTITEMGRP = "PrtItemGrpRF";
        private const string TBL_PRTITEMSET = "PrtItemSetRF";
        private const string TBL_FREPEXCNDD = "FrePExCndDRF";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
        private const string TBL_FPSORTINIT = "FPSortInitRF";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

        // ���ʃt�@�C���w�b�_�[
        private const string COL_COMMON_CREATEDATETIME = "CreateDateTime";		// �쐬����
        private const string COL_COMMON_UPDATEDATETIME = "UpdateDateTime";		// �X�V����
        private const string COL_COMMON_ENTERPRISECODE = "EnterpriseCode";		// ��ƃR�[�h
        private const string COL_COMMON_FILEHEADERGUID = "FileHeaderGuid";		// GUID
        private const string COL_COMMON_UPDEMPLOYEECODE = "UpdEmployeeCode";	// �X�V�]�ƈ��R�[�h
        private const string COL_COMMON_UPDASSEMBLYID1 = "UpdAssemblyId1";		// �X�V�A�Z���u��ID1
        private const string COL_COMMON_UPDASSEMBLYID2 = "UpdAssemblyId2";		// �X�V�A�Z���u��ID2
        private const string COL_COMMON_LOGICALDELETECODE = "LogicalDeleteCode";	// �_���폜�敪
        // �󎚍��ڃO���[�v
        private const string COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD = "FreePrtPprItemGrpCd";	// ���R���[���ڃO���[�v�R�[�h
        private const string COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM = "FreePrtPprItemGrpNm";	// ���R���[���ڃO���[�v����
        private const string COL_PRTITEMGRP_PRINTPAPERUSEDIVCD = "PrintPaperUseDivcd";		// ���[�g�p�敪
        private const string COL_PRTITEMGRP_EXTRACTIONPGID = "ExtractionPgId";			// ���o�v���O����ID
        private const string COL_PRTITEMGRP_EXTRACTIONPGCLASSID = "ExtractionPgClassId";	// ���o�v���O�����N���XID
        private const string COL_PRTITEMGRP_OUTPUTPGID = "OutputPgId";				// �o�̓v���O����ID
        private const string COL_PRTITEMGRP_OUTPUTPGCLASSID = "OutputPgClassId";		// �o�̓v���O�����N���XID
        private const string COL_PRTITEMGRP_DATAINPUTSYSTEM = "DataInputSystem";		// �f�[�^���̓V�X�e��
        private const string COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS = "LinkSlipDataInputSys";	// �����N�`�[�f�[�^���̓V�X�e��
        private const string COL_PRTITEMGRP_LINKSLIPPRTKIND = "LinkSlipPrtKind";		// �����N�`�[������
        private const string COL_PRTITEMGRP_LINKSLIPPRTSETPPRID = "LinkSlipPrtSetPprId";	// �����N�`�[����ݒ�p���[ID
        private const string COL_PRTITEMGRP_EXTRASECTIONKINDCD = "ExtraSectionKindCd";		// ���o���_��ʋ敪
        private const string COL_PRTITEMGRP_EXTRASECTIONSELEXIST = "ExtraSectionSelExist";	// ���o���_�I��L��
        private const string COL_PRTITEMGRP_FORMFEEDLINECOUNT = "FormFeedLineCount";		// ���ōs��
        private const string COL_PRTITEMGRP_CRCHARCNT = "CrCharCnt";				// ���s������
        private const string COL_PRTITEMGRP_FREEPRTPPRSPPRPSECD = "FreePrtPprSpPrpseCd";	// ���R���[ ����p�r�敪
        // �󎚍��ڐݒ�
        private const string COL_PRTITEMSET_FREEPRTPPRITEMGRPCD = "FreePrtPprItemGrpCd";	// ���R���[���ڃO���[�v�R�[�h
        private const string COL_PRTITEMSET_FREEPRTPAPERITEMCD = "FreePrtPaperItemCd";		// ���R���[���ڃR�[�h
        private const string COL_PRTITEMSET_FREEPRTPAPERITEMNM = "FreePrtPaperItemNm";		// ���R���[���ږ���
        private const string COL_PRTITEMSET_FILENM = "FileNm";					// �t�@�C������
        private const string COL_PRTITEMSET_DDCHARCNT = "DDCharCnt";				// DD����
        private const string COL_PRTITEMSET_DDNAME = "DDName";					// DD����
        private const string COL_PRTITEMSET_REPORTCONTROLCODE = "ReportControlCode";		// ���|�[�g�R���g���[���敪
        private const string COL_PRTITEMSET_HEADERUSEDIVCD = "HeaderUseDivCd";			// �w�b�_�[�g�p�敪
        private const string COL_PRTITEMSET_DETAILUSEDIVCD = "DetailUseDivCd";			// ���׎g�p�敪
        private const string COL_PRTITEMSET_FOOTERUSEDIVCD = "FooterUseDivCd";			// �t�b�^�[�g�p�敪
        private const string COL_PRTITEMSET_EXTRACONDITIONDIVCD = "ExtraConditionDivCd";	// ���o�����敪
        private const string COL_PRTITEMSET_EXTRACONDITIONTYPECD = "ExtraConditionTypeCd";	// ���o�����^�C�v
        private const string COL_PRTITEMSET_COMMAEDITEXISTCD = "CommaEditExistCd";		// �J���}�ҏW�L��
        private const string COL_PRTITEMSET_PRINTPAGECTRLDIVCD = "PrintPageCtrlDivCd";		// �󎚃y�[�W����敪
        private const string COL_PRTITEMSET_SYSTEMDIVCD = "SystemDivCd";			// �V�X�e���敪
        private const string COL_PRTITEMSET_OPTIONCODE = "OptionCode";				// �I�v�V�����R�[�h
        private const string COL_PRTITEMSET_EXTRACONDDETAILGRPCD = "ExtraCondDetailGrpCd";	// ���o�������׃O���[�v�R�[�h
        private const string COL_PRTITEMSET_TOTALITEMDIVCD = "TotalItemDivCd";			// �W�v���ڋ敪
        private const string COL_PRTITEMSET_FORMFEEDITEMDIVCD = "FormFeedItemDivCd";		// ���ō��ڋ敪
        private const string COL_PRTITEMSET_FREEPRTPPRDISPGRPCD = "FreePrtPprDispGrpCd";	// ���R���[�\���O���[�v�R�[�h
        private const string COL_PRTITEMSET_NECESSARYEXTRACONDCD = "NecessaryExtraCondCd";	// �K�{���o�����敪
        private const string COL_PRTITEMSET_CIPHERFLG = "CipherFlg";				// �Í����t���O
        private const string COL_PRTITEMSET_EXTRACTIONITDEDFLG = "ExtractionItdedFlg";		// ���o�Ώۃt���O
        private const string COL_PRTITEMSET_GROUPSUPPRESSCD = "GroupSuppressCd";		// �O���[�v�T�v���X�敪
        private const string COL_PRTITEMSET_DTLCOLORCHANGECD = "DtlColorChangeCd";		// ���אF�ύX�敪
        private const string COL_PRTITEMSET_HEIGHTADJUSTDIVCD = "HeightAdjustDivCd";		// ���������敪
        private const string COL_PRTITEMSET_ADDITEMUSEDIVCD = "AddItemUseDivCd";		// �ǉ����ڎg�p�敪
        private const string COL_PRTITEMSET_INPUTCHARCNT = "InputCharCnt";			// ���͌���
        private const string COL_PRTITEMSET_BARCODESTYLE = "BarCodeStyle";			// �o�[�R�[�h�X�^�C��
        // ���R���[���o��������
        private const string COL_FREPEXCNDD_EXTRACONDDETAILGRPCD = "ExtraCondDetailGrpCd";	// ���o�������׃O���[�v�R�[�h
        private const string COL_FREPEXCNDD_EXTRACONDDETAILCODE = "ExtraCondDetailCode";	// ���o�������׃R�[�h
        private const string COL_FREPEXCNDD_EXTRACONDDETAILNAME = "ExtraCondDetailName";	// ���o�������ז���
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
        // ���R���[�\�[�g���ʏ����l
        //private const string COL_FPSORTINIT_CREATEDATETIME = "CreateDateTime"; // �쐬����
        //private const string COL_FPSORTINIT_UPDATEDATETIME = "UpdateDateTime"; // �X�V����
        //private const string COL_FPSORTINIT_LOGICALDELETECODE = "LogicalDeleteCode"; // �_���폜�敪
        private const string COL_FPSORTINIT_FREEPRTPPRITEMGRPCD = "FreePrtPprItemGrpCd"; // ���R���[���ڃO���[�v�R�[�h
        private const string COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD = "FreePrtPprSchmGrpCd"; // ���R���[�X�L�[�}�O���[�v�R�[�h
        private const string COL_FPSORTINIT_SORTINGORDERCODE = "SortingOrderCode"; // �\�[�g���ʃR�[�h
        private const string COL_FPSORTINIT_SORTINGORDER = "SortingOrder"; // �\�[�g����
        private const string COL_FPSORTINIT_FREEPRTPAPERITEMNM = "FreePrtPaperItemNm"; // ���R���[���ږ���
        private const string COL_FPSORTINIT_DDNAME = "DDName"; // DD����
        private const string COL_FPSORTINIT_FILENM = "FileNm"; // �t�@�C������
        private const string COL_FPSORTINIT_SORTINGORDERDIVCD = "SortingOrderDivCd"; // �����~���敪
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
        #endregion

        #region PrivateMember
        // �t�@�C���d�l���A�N�Z�X�R���g���[��
        private FileLayoutControl _layoutCtrl;
        // �f�[�^�ێ��pDataSet
        private DataSet _ds;
        // �t�@�C�����C�A�E�g���ێ��p
        private List<SchemaInfo> _prtItemGrpSchemaInfoList;
        private List<SchemaInfo> _prtItemSetSchemaInfoList;
        private List<SchemaInfo> _frePExCndDSchemaInfoList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
        private List<SchemaInfo> _fPSortInitSchemaInfoList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
        // �ύX�O�̎��R���[���ڃO���[�v�R�[�h
        private int _prevFreePrtPprItemGrpCd;
        // �ύX�`�F�b�N�t���O
        private bool _isChanged;
        // ���o�������׃��[�h�t���O
        private bool _isLoadFrePExCndD;
        #endregion

        #region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SFANL08240UA()
        {
            InitializeComponent();

            _layoutCtrl = new FileLayoutControl();

            _ds = new DataSet();
        }
        #endregion

        #region PrivateMethod
        /// <summary>
        /// �X�L�[�}���LIST�擾����
        /// </summary>
        /// <param name="tableName">�e�[�u������</param>
        /// <returns>�X�L�[�}���LIST</returns>
        private List<SchemaInfo> GetSchemaInfoList( string tableName )
        {
            List<SchemaInfo> schemaInfoList = new List<SchemaInfo>();

            switch ( tableName )
            {
                case TBL_PRTITEMGRP:
                    {
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_CREATEDATETIME, "�쐬����", typeof( long ), 19 ) );	// �쐬����
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDATEDATETIME, "�X�V����", typeof( long ), 19 ) );	// �X�V����
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_LOGICALDELETECODE, "�_���폜�敪", typeof( int ), 2 ) );	// �_���폜�敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD, "���R���[���ڃO���[�v�R�[�h", typeof( int ), 4 ) );	// ���R���[���ڃO���[�v�R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM, "���R���[���ڃO���[�v����", typeof( string ), 20 ) );	// ���R���[���ڃO���[�v����
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_PRINTPAPERUSEDIVCD, "���[�g�p�敪", typeof( int ), 2 ) );	// ���[�g�p�敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_EXTRACTIONPGID, "���o�v���O����ID", typeof( string ), 16 ) );	// ���o�v���O����ID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_EXTRACTIONPGCLASSID, "���o�v���O�����N���XID", typeof( string ), 80 ) );	// ���o�v���O�����N���XID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_OUTPUTPGID, "�o�̓v���O����ID", typeof( string ), 16 ) );	// �o�̓v���O����ID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_OUTPUTPGCLASSID, "�o�̓v���O�����N���XID", typeof( string ), 80 ) );	// �o�̓v���O�����N���XID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_DATAINPUTSYSTEM, "�f�[�^���̓V�X�e��", typeof( int ), 2 ) );	// �f�[�^���̓V�X�e��
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS, "�����N�`�[�f�[�^���̓V�X�e��", typeof( int ), 2 ) );	// �����N�`�[�f�[�^���̓V�X�e��
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_LINKSLIPPRTKIND, "�����N�`�[������", typeof( int ), 4 ) );	// �����N�`�[������
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_LINKSLIPPRTSETPPRID, "�����N�`�[����ݒ�p���[ID", typeof( string ), 24 ) );	// �����N�`�[����ݒ�p���[ID
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_EXTRASECTIONKINDCD, "���o���_��ʋ敪", typeof( int ), 2 ) );	// ���o���_��ʋ敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_EXTRASECTIONSELEXIST, "���o���_�I��L��", typeof( int ), 2 ) );	// ���o���_�I��L��
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_FORMFEEDLINECOUNT, "���ōs��", typeof( int ), 4 ) );	// ���ōs��
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_CRCHARCNT, "���s������", typeof( int ), 4 ) );	// ���s������
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMGRP_FREEPRTPPRSPPRPSECD, "����p�r�敪", typeof( int ), 2 ) );	// ���R���[ ����p�r�敪
                        break;
                    }
                case TBL_PRTITEMSET:
                    {
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_CREATEDATETIME, "�쐬����", typeof( long ), 19 ) );	// �쐬����
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDATEDATETIME, "�X�V����", typeof( long ), 19 ) );	// �X�V����
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_LOGICALDELETECODE, "�_���폜�敪", typeof( int ), 2 ) );	// �_���폜�敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FREEPRTPPRITEMGRPCD, "���R���[���ڃO���[�v�R�[�h", typeof( int ), 4 ) );	// ���R���[���ڃO���[�v�R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FREEPRTPAPERITEMCD, "���R���[���ڃR�[�h", typeof( int ), 4 ) );	// ���R���[���ڃR�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FREEPRTPAPERITEMNM, "���R���[���ږ���", typeof( string ), 30 ) );	// ���R���[���ږ���
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FILENM, "�t�@�C������", typeof( string ), 32 ) );	// �t�@�C������
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_DDCHARCNT, "DD����", typeof( int ), 2 ) );	// DD����
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_DDNAME, "DD����", typeof( string ), 30 ) );	// DD����
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_REPORTCONTROLCODE, "���|�[�g�R���g���[���敪", typeof( int ), 2 ) );	// ���|�[�g�R���g���[���敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_HEADERUSEDIVCD, "�w�b�_�[�g�p�敪", typeof( int ), 2 ) );	// �w�b�_�[�g�p�敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_DETAILUSEDIVCD, "���׎g�p�敪", typeof( int ), 2 ) );	// ���׎g�p�敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FOOTERUSEDIVCD, "�t�b�^�[�g�p�敪", typeof( int ), 2 ) );	// �t�b�^�[�g�p�敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_EXTRACONDITIONDIVCD, "���o�����敪", typeof( int ), 2 ) );	// ���o�����敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_EXTRACONDITIONTYPECD, "���o�����^�C�v", typeof( int ), 2 ) );	// ���o�����^�C�v
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_COMMAEDITEXISTCD, "�J���}�ҏW�L��", typeof( int ), 2 ) );	// �J���}�ҏW�L��
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_PRINTPAGECTRLDIVCD, "�󎚃y�[�W����敪", typeof( int ), 2 ) );	// �󎚃y�[�W����敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_SYSTEMDIVCD, "�V�X�e���敪", typeof( int ), 2 ) );	// �V�X�e���敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_OPTIONCODE, "�I�v�V�����R�[�h", typeof( string ), 16 ) );	// �I�v�V�����R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_EXTRACONDDETAILGRPCD, "���o�������׃O���[�v�R�[�h", typeof( int ), 4 ) );	// ���o�������׃O���[�v�R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_TOTALITEMDIVCD, "�W�v���ڋ敪", typeof( int ), 2 ) );	// �W�v���ڋ敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FORMFEEDITEMDIVCD, "���ō��ڋ敪", typeof( int ), 2 ) );	// ���ō��ڋ敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_FREEPRTPPRDISPGRPCD, "���R���[�\���O���[�v�R�[�h", typeof( int ), 4 ) );	// ���R���[�\���O���[�v�R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_NECESSARYEXTRACONDCD, "�K�{���o�����敪", typeof( int ), 2 ) );	// �K�{���o�����敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_CIPHERFLG, "�Í����t���O", typeof( int ), 2 ) );	// �Í����t���O
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_EXTRACTIONITDEDFLG, "���o�Ώۃt���O", typeof( int ), 2 ) );	// ���o�Ώۃt���O
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_GROUPSUPPRESSCD, "�O���[�v�T�v���X�敪", typeof( int ), 2 ) );	// �O���[�v�T�v���X�敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_DTLCOLORCHANGECD, "���אF�ύX�敪", typeof( int ), 2 ) );	// ���אF�ύX�敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_HEIGHTADJUSTDIVCD, "���������敪", typeof( int ), 2 ) );	// ���������敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_ADDITEMUSEDIVCD, "�ǉ����ڎg�p�敪", typeof( int ), 2 ) );	// �ǉ����ڎg�p�敪
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_INPUTCHARCNT, "���͌���", typeof( int ), 4 ) );	// ���͌���
                        schemaInfoList.Add( new SchemaInfo( COL_PRTITEMSET_BARCODESTYLE, "�o�[�R�[�h�X�^�C��", typeof( int ), 2 ) );	// �o�[�R�[�h�X�^�C��
                        break;
                    }
                case TBL_FREPEXCNDD:
                    {
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_CREATEDATETIME, "�쐬����", typeof( long ), 19 ) );	// �쐬����
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDATEDATETIME, "�X�V����", typeof( long ), 19 ) );	// �X�V����
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_ENTERPRISECODE, "��ƃR�[�h", typeof( string ), 16 ) );	// ��ƃR�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_FILEHEADERGUID, "GUID", typeof( Guid ), 32 ) );	// GUID
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDEMPLOYEECODE, "�X�V�]�ƈ��R�[�h", typeof( string ), 9 ) );	// �X�V�]�ƈ��R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDASSEMBLYID1, "�X�V�A�Z���u��ID1", typeof( string ), 30 ) );	// �X�V�A�Z���u��ID1
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDASSEMBLYID2, "�X�V�A�Z���u��ID2", typeof( string ), 30 ) );	// �X�V�A�Z���u��ID2
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_LOGICALDELETECODE, "�_���폜�敪", typeof( int ), 2 ) );	// �_���폜�敪
                        schemaInfoList.Add( new SchemaInfo( COL_FREPEXCNDD_EXTRACONDDETAILGRPCD, "���o�������׃O���[�v�R�[�h", typeof( int ), 4 ) );	// ���o�������׃O���[�v�R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_FREPEXCNDD_EXTRACONDDETAILCODE, "���o�������׃R�[�h", typeof( int ), 4 ) );	// ���o�������׃R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_FREPEXCNDD_EXTRACONDDETAILNAME, "���o�������ז���", typeof( string ), 20 ) );	// ���o�������ז���
                        break;
                    }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                case TBL_FPSORTINIT:
                    {
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_CREATEDATETIME, "�쐬����", typeof( long ), 19 ) );	// �쐬����
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_UPDATEDATETIME, "�X�V����", typeof( long ), 19 ) );	// �X�V����
                        schemaInfoList.Add( new SchemaInfo( COL_COMMON_LOGICALDELETECODE, "�_���폜�敪", typeof( int ), 2 ) );	// �_���폜�敪
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_FREEPRTPPRITEMGRPCD, "���R���[���ڃO���[�v�R�[�h", typeof( int ), 4 ) ); // ���R���[���ڃO���[�v�R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD, "���R���[�X�L�[�}�O���[�v�R�[�h", typeof( int ), 4 ) ); // ���R���[�X�L�[�}�O���[�v�R�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_SORTINGORDERCODE, "�\�[�g���ʃR�[�h", typeof( int ), 2 ) ); // �\�[�g���ʃR�[�h
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_SORTINGORDER, "�\�[�g����", typeof( int ), 2 ) ); // �\�[�g����
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_FREEPRTPAPERITEMNM, "���R���[���ږ���", typeof( string ), 30 ) ); // ���R���[���ږ���
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_DDNAME, "DD����", typeof( string ), 30 ) ); // DD����
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_FILENM, "�t�@�C������", typeof( string ), 32 ) ); // �t�@�C������
                        schemaInfoList.Add( new SchemaInfo( COL_FPSORTINIT_SORTINGORDERDIVCD, "�����~���敪", typeof( int ), 2 ) ); // �����~���敪
                        break;
                    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
            }

            return schemaInfoList;
        }

        /// <summary>
        /// DataTable�X�L�[�}�쐬����
        /// </summary>
        /// <param name="ds">DataTable�i�[��DataSet</param>
        /// <param name="tableName">DataTable����</param>
        private void CreateDataTableSchema( DataSet ds, string tableName )
        {
            List<SchemaInfo> schemaInfoList = GetSchemaInfoList( tableName );

            if ( schemaInfoList != null )
            {
                switch ( tableName )
                {
                    case TBL_PRTITEMGRP: _prtItemGrpSchemaInfoList = schemaInfoList; break;
                    case TBL_PRTITEMSET: _prtItemSetSchemaInfoList = schemaInfoList; break;
                    case TBL_FREPEXCNDD: _frePExCndDSchemaInfoList = schemaInfoList; break;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                    case TBL_FPSORTINIT: _fPSortInitSchemaInfoList = schemaInfoList; break;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
                }

                ds.Tables.Add( new DataTable( tableName ) );

                foreach ( SchemaInfo schemaInfo in schemaInfoList )
                {
                    // �^�𓮓I�Ɏw��
                    if ( schemaInfo.Type != null )
                        ds.Tables[tableName].Columns.Add( schemaInfo.Name, schemaInfo.Type );
                    else
                        ds.Tables[tableName].Columns.Add( schemaInfo.Name );

                    // ������^�̏ꍇ�͋󕶎��������l�ɂ���
                    if ( ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals( typeof( string ) ) )
                    {
                        ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = string.Empty;
                    }
                    // GUID�^�̏ꍇ�͐V����GUID�l�������l�ɂ���
                    else if ( ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals( typeof( Guid ) ) )
                    {
                        ds.Tables[tableName].Columns[schemaInfo.Name].DefaultValue = Guid.NewGuid();
                    }
                    // ���l�^�̏ꍇ��0�������l(Boolean�̏ꍇ��false)�ɂ���
                    else if ( ds.Tables[tableName].Columns[schemaInfo.Name].DataType.IsPrimitive )
                    {
                        if ( ds.Tables[tableName].Columns[schemaInfo.Name].DataType.Equals( typeof( bool ) ) )
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
        /// ���C�A�E�g���W�J����
        /// </summary>
        /// <param name="filePath">���C�A�E�g�t�@�C���p�X</param>
        /// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
        private void DeployLayoutInfo( string filePath, int freePrtPprItemGrpCd )
        {
            string msg;
            FileLayout layout = _layoutCtrl.ImportFileLayout( filePath, out msg );

            if ( string.IsNullOrEmpty( msg ) )
            {
                // �ő���擾
                int freePrtPaperItemCd = GetMaxFreePrtPaperItemCd( freePrtPprItemGrpCd );
                foreach ( LayoutField field in layout.FieldList )
                {
                    switch ( field.Name )
                    {
                        case COL_COMMON_CREATEDATETIME:
                        case COL_COMMON_UPDATEDATETIME:
                        case COL_COMMON_ENTERPRISECODE:
                        case COL_COMMON_FILEHEADERGUID:
                        case COL_COMMON_UPDEMPLOYEECODE:
                        case COL_COMMON_UPDASSEMBLYID1:
                        case COL_COMMON_UPDASSEMBLYID2:
                        case COL_COMMON_LOGICALDELETECODE:
                            {
                                // ���ʃw�b�_���͓W�J���Ȃ�
                                break;
                            }
                        default:
                            {
                                DataRow dr = _ds.Tables[TBL_PRTITEMSET].NewRow();

                                dr[COL_COMMON_CREATEDATETIME] = GetPrtItemGrpCreateDateTime();
                                dr[COL_COMMON_UPDATEDATETIME] = dr[COL_COMMON_CREATEDATETIME];
                                dr[COL_COMMON_LOGICALDELETECODE] = 0;
                                dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD] = freePrtPprItemGrpCd;
                                dr[COL_PRTITEMSET_FREEPRTPAPERITEMCD] = ++freePrtPaperItemCd;
                                dr[COL_PRTITEMSET_FREEPRTPAPERITEMNM] = field.NameJp;
                                dr[COL_PRTITEMSET_FILENM] = layout.LayoutName + "RF";
                                dr[COL_PRTITEMSET_DDCHARCNT] = field.Length;
                                dr[COL_PRTITEMSET_DDNAME] = field.Name + "RF";

                                Type type = Type.GetType( "System." + field.Type );
                                if ( type == typeof( Image ) )
                                    dr[COL_PRTITEMSET_REPORTCONTROLCODE] = 3;
                                else
                                    dr[COL_PRTITEMSET_REPORTCONTROLCODE] = 1;

                                dr[COL_PRTITEMSET_HEADERUSEDIVCD] = 1;
                                dr[COL_PRTITEMSET_DETAILUSEDIVCD] = 1;
                                dr[COL_PRTITEMSET_FOOTERUSEDIVCD] = 1;
                                dr[COL_PRTITEMSET_EXTRACONDITIONDIVCD] = 0;
                                dr[COL_PRTITEMSET_EXTRACONDITIONTYPECD] = 0;
                                dr[COL_PRTITEMSET_COMMAEDITEXISTCD] = 0;
                                dr[COL_PRTITEMSET_PRINTPAGECTRLDIVCD] = 0;
                                dr[COL_PRTITEMSET_SYSTEMDIVCD] = 0;
                                dr[COL_PRTITEMSET_OPTIONCODE] = string.Empty;
                                dr[COL_PRTITEMSET_EXTRACONDDETAILGRPCD] = 0;
                                dr[COL_PRTITEMSET_TOTALITEMDIVCD] = 0;
                                dr[COL_PRTITEMSET_FORMFEEDITEMDIVCD] = 0;
                                dr[COL_PRTITEMSET_FREEPRTPPRDISPGRPCD] = 0;
                                dr[COL_PRTITEMSET_NECESSARYEXTRACONDCD] = 0;
                                if ( field.IsEncrypt )
                                    dr[COL_PRTITEMSET_CIPHERFLG] = 1;
                                else
                                    dr[COL_PRTITEMSET_CIPHERFLG] = 0;
                                dr[COL_PRTITEMSET_EXTRACTIONITDEDFLG] = 1;
                                dr[COL_PRTITEMSET_GROUPSUPPRESSCD] = 0;
                                dr[COL_PRTITEMSET_DTLCOLORCHANGECD] = 0;
                                dr[COL_PRTITEMSET_HEIGHTADJUSTDIVCD] = 0;
                                dr[COL_PRTITEMSET_ADDITEMUSEDIVCD] = 1;
                                dr[COL_PRTITEMSET_INPUTCHARCNT] = field.Width;
                                dr[COL_PRTITEMSET_BARCODESTYLE] = 0;

                                _ds.Tables[TBL_PRTITEMSET].Rows.Add( dr );
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// �s�ǉ�����
        /// </summary>
        /// <param name="tableName">DataTable����</param>
        /// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
        private void AddRow( string tableName, int freePrtPprItemGrpCd )
        {
            DataRow dr = _ds.Tables[tableName].NewRow();

            switch ( tableName )
            {
                case TBL_PRTITEMGRP:
                    {
                        dr[COL_COMMON_CREATEDATETIME] = DateTime.Now.Ticks;
                        dr[COL_COMMON_UPDATEDATETIME] = dr[COL_COMMON_CREATEDATETIME];
                        dr[COL_COMMON_LOGICALDELETECODE] = 0;
                        dr[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD] = freePrtPprItemGrpCd;
                        dr[COL_PRTITEMGRP_FREEPRTPPRITEMGRPNM] = string.Empty;
                        dr[COL_PRTITEMGRP_PRINTPAPERUSEDIVCD] = 1;
                        dr[COL_PRTITEMGRP_EXTRACTIONPGID] = string.Empty;
                        dr[COL_PRTITEMGRP_EXTRACTIONPGCLASSID] = string.Empty;
                        dr[COL_PRTITEMGRP_OUTPUTPGID] = string.Empty;
                        dr[COL_PRTITEMGRP_OUTPUTPGCLASSID] = string.Empty;
                        dr[COL_PRTITEMGRP_DATAINPUTSYSTEM] = 0;
                        dr[COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS] = 0;
                        dr[COL_PRTITEMGRP_LINKSLIPPRTKIND] = 0;
                        dr[COL_PRTITEMGRP_LINKSLIPPRTSETPPRID] = string.Empty;
                        dr[COL_PRTITEMGRP_EXTRASECTIONKINDCD] = 0;
                        dr[COL_PRTITEMGRP_EXTRASECTIONSELEXIST] = 0;
                        dr[COL_PRTITEMGRP_FORMFEEDLINECOUNT] = 0;
                        dr[COL_PRTITEMGRP_CRCHARCNT] = 0;
                        dr[COL_PRTITEMGRP_FREEPRTPPRSPPRPSECD] = 0;
                        break;
                    }
                case TBL_PRTITEMSET:
                    {
                        dr[COL_COMMON_CREATEDATETIME] = GetPrtItemGrpCreateDateTime();
                        dr[COL_COMMON_UPDATEDATETIME] = dr[COL_COMMON_CREATEDATETIME];
                        dr[COL_COMMON_LOGICALDELETECODE] = 0;
                        dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD] = freePrtPprItemGrpCd;
                        dr[COL_PRTITEMSET_FREEPRTPAPERITEMCD] = GetMaxFreePrtPaperItemCd( freePrtPprItemGrpCd ) + 1;
                        dr[COL_PRTITEMSET_FREEPRTPAPERITEMNM] = string.Empty;
                        dr[COL_PRTITEMSET_FILENM] = string.Empty;
                        dr[COL_PRTITEMSET_DDCHARCNT] = 0;
                        dr[COL_PRTITEMSET_DDNAME] = string.Empty;
                        dr[COL_PRTITEMSET_REPORTCONTROLCODE] = 1;
                        dr[COL_PRTITEMSET_HEADERUSEDIVCD] = 1;
                        dr[COL_PRTITEMSET_DETAILUSEDIVCD] = 1;
                        dr[COL_PRTITEMSET_FOOTERUSEDIVCD] = 1;
                        dr[COL_PRTITEMSET_EXTRACONDITIONDIVCD] = 0;
                        dr[COL_PRTITEMSET_EXTRACONDITIONTYPECD] = 0;
                        dr[COL_PRTITEMSET_COMMAEDITEXISTCD] = 0;
                        dr[COL_PRTITEMSET_PRINTPAGECTRLDIVCD] = 0;
                        dr[COL_PRTITEMSET_SYSTEMDIVCD] = 0;
                        dr[COL_PRTITEMSET_OPTIONCODE] = string.Empty;
                        dr[COL_PRTITEMSET_EXTRACONDDETAILGRPCD] = 0;
                        dr[COL_PRTITEMSET_TOTALITEMDIVCD] = 0;
                        dr[COL_PRTITEMSET_FORMFEEDITEMDIVCD] = 0;
                        dr[COL_PRTITEMSET_FREEPRTPPRDISPGRPCD] = 0;
                        dr[COL_PRTITEMSET_NECESSARYEXTRACONDCD] = 0;
                        dr[COL_PRTITEMSET_CIPHERFLG] = 0;
                        dr[COL_PRTITEMSET_EXTRACTIONITDEDFLG] = 1;
                        dr[COL_PRTITEMSET_GROUPSUPPRESSCD] = 0;
                        dr[COL_PRTITEMSET_DTLCOLORCHANGECD] = 0;
                        dr[COL_PRTITEMSET_HEIGHTADJUSTDIVCD] = 0;
                        dr[COL_PRTITEMSET_ADDITEMUSEDIVCD] = 1;
                        dr[COL_PRTITEMSET_INPUTCHARCNT] = 0;
                        dr[COL_PRTITEMSET_BARCODESTYLE] = 0;
                        break;
                    }
                case TBL_FREPEXCNDD:
                    {
                        dr[COL_COMMON_CREATEDATETIME] = DateTime.Now.Ticks;
                        dr[COL_COMMON_UPDATEDATETIME] = dr[COL_COMMON_CREATEDATETIME];
                        dr[COL_COMMON_ENTERPRISECODE] = "TBS1            ";
                        dr[COL_COMMON_FILEHEADERGUID] = Guid.NewGuid();
                        dr[COL_COMMON_UPDEMPLOYEECODE] = "0283     ";
                        dr[COL_COMMON_UPDASSEMBLYID1] = "ImportData";
                        dr[COL_COMMON_UPDASSEMBLYID2] = "ImportData";
                        dr[COL_COMMON_LOGICALDELETECODE] = 0;
                        dr[COL_FREPEXCNDD_EXTRACONDDETAILGRPCD] = GetPrtItemSetExtraCondDtlGrpCd();
                        dr[COL_FREPEXCNDD_EXTRACONDDETAILCODE] = GetMaxExtraCondDetailCode( (int)dr[COL_FREPEXCNDD_EXTRACONDDETAILGRPCD] ) + 1;
                        dr[COL_FREPEXCNDD_EXTRACONDDETAILNAME] = "";
                        break;
                    }
            }

            _ds.Tables[tableName].Rows.Add( dr );
        }

        /// <summary>
        /// �󎚍��ڐݒ�f�t�H���g�s�ǉ�����
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
        private void AddPrtItemSetDefaultValueRow( int freePrtPprItemGrpCd )
        {
            string filePath = Path.Combine( System.Windows.Forms.Application.StartupPath, "PrtItemSet_Default.xml" );

            if ( File.Exists( filePath ) )
            {
                long createDateTime = 0;
                long updateDateTime = 0;

                DataRow[] drArray
                    = _ds.Tables[TBL_PRTITEMGRP].Select( COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd );
                if ( drArray != null && drArray.Length > 0 )
                {
                    createDateTime = (long)drArray[0][COL_COMMON_CREATEDATETIME];
                    updateDateTime = (long)drArray[0][COL_COMMON_UPDATEDATETIME];

                    DataSet ds = new DataSet();
                    ds.ReadXml( filePath );
                    if ( ds.Tables[0].Columns.Contains( COL_PRTITEMSET_FREEPRTPPRITEMGRPCD ) )
                    {
                        foreach ( DataRow dr in ds.Tables[0].Rows )
                        {
                            dr[COL_COMMON_CREATEDATETIME] = createDateTime;
                            dr[COL_COMMON_UPDATEDATETIME] = updateDateTime;
                            dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD] = freePrtPprItemGrpCd;
                            _ds.Tables[TBL_PRTITEMSET].Rows.Add( dr.ItemArray );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �󎚍��ڃO���[�v�쐬�����擾����
        /// </summary>
        /// <returns>�쐬����</returns>
        private long GetPrtItemGrpCreateDateTime()
        {
            long createDateTime = 0;

            if ( this.gridPrtItemGrp.ActiveRow != null )
            {
                createDateTime
                    = (long)this.gridPrtItemGrp.ActiveRow.Cells[COL_COMMON_CREATEDATETIME].Value;
            }

            return createDateTime;
        }

        /// <summary>
        /// ���o�������׃O���[�v�R�[�h�擾����
        /// </summary>
        /// <returns>���o�������׃O���[�v�R�[�h</returns>
        private long GetPrtItemSetExtraCondDtlGrpCd()
        {
            long extraCondDtlGrpCd = 0;

            if ( this.gridPrtItemSet.ActiveRow != null )
            {
                extraCondDtlGrpCd
                    = (int)this.gridPrtItemSet.ActiveRow.Cells[COL_PRTITEMSET_EXTRACONDDETAILGRPCD].Value;
            }

            return extraCondDtlGrpCd;
        }

        /// <summary>
        /// ���R���[���ڃO���[�v�R�[�h�ő�l�擾����
        /// </summary>
        /// <returns>���R���[���ڃO���[�v�R�[�h</returns>
        private int GetMaxFreePrtPprItemGrpCd()
        {
            int freePrtPprItemGrpCd = 0;

            string sort = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + " DESC";
            DataRow[] drArray = _ds.Tables[TBL_PRTITEMGRP].Select( "", sort );
            if ( drArray != null && drArray.Length > 0 )
                freePrtPprItemGrpCd = (int)drArray[0][COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];

            return freePrtPprItemGrpCd;
        }

        /// <summary>
        /// ���R���[���ڃR�[�h�ő�l�擾����
        /// </summary>
        /// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
        /// <returns>���R���[���ڃR�[�h</returns>
        private int GetMaxFreePrtPaperItemCd( int freePrtPprItemGrpCd )
        {
            int freePrtPaperItemCd = 100;

            string filter = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;
            string sort = COL_PRTITEMSET_FREEPRTPAPERITEMCD + " DESC";
            DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter, sort );
            if ( drArray != null && drArray.Length > 0 )
                freePrtPaperItemCd = Math.Max( freePrtPaperItemCd, (int)drArray[0][COL_PRTITEMSET_FREEPRTPAPERITEMCD] );

            return freePrtPaperItemCd;
        }

        /// <summary>
        /// ���o�������׃R�[�h�ő�l�擾����
        /// </summary>
        /// <param name="extraCondDtlGrpCd">���o�������׃O���[�v�R�[�h</param>
        /// <returns>���o�������׃R�[�h</returns>
        private int GetMaxExtraCondDetailCode( int extraCondDtlGrpCd )
        {
            int extraCondDetailCode = 0;

            string filter = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + extraCondDtlGrpCd;
            string sort = COL_FREPEXCNDD_EXTRACONDDETAILCODE + " DESC";
            DataRow[] drArray = _ds.Tables[TBL_FREPEXCNDD].Select( filter, sort );
            if ( drArray != null && drArray.Length > 0 )
                extraCondDetailCode = (int)drArray[0][COL_FREPEXCNDD_EXTRACONDDETAILCODE];

            return extraCondDetailCode;
        }

        /// <summary>
        /// ���o�����^�C�v�ύX����
        /// </summary>
        /// <param name="extraConditionDivCd">���o�����敪</param>
        private void ChangeExtraConditionType( int extraConditionDivCd )
        {
            UltraGridColumn column
                = this.gridPrtItemSet.DisplayLayout.Bands[0].Columns[COL_PRTITEMSET_EXTRACONDITIONTYPECD];

            ValueList valueList = new ValueList();
            switch ( extraConditionDivCd )
            {
                case 0: // �g�p���Ȃ�
                case 5: // �R���{�{�b�N�X�^
                case 6: // �`�F�b�N�{�b�N�X�^
                    {
                        valueList.ValueListItems.Add( 0, " " );
                        break;
                    }
                case 1:	// ���l�^
                    {
                        valueList.ValueListItems.Add( 0, "��v" );
                        valueList.ValueListItems.Add( 1, "�͈�" );
                        break;
                    }
                case 2: // �����^�i���p�j
                case 3: // �����^�i�S�p�j
                    {
                        valueList.ValueListItems.Add( 0, "��v" );
                        valueList.ValueListItems.Add( 1, "�͈�" );
                        valueList.ValueListItems.Add( 2, "�����܂�" );
                        break;
                    }
                case 4: // ���t�^
                    {
                        valueList.ValueListItems.Add( 0, "��v" );
                        valueList.ValueListItems.Add( 1, "�͈�" );
                        valueList.ValueListItems.Add( 2, "�����܂�" );
                        valueList.ValueListItems.Add( 3, "����" );
                        break;
                    }
            }

            this.gridPrtItemSet.DisplayLayout.Bands[0].Columns[COL_PRTITEMSET_EXTRACONDITIONTYPECD].ValueList = valueList;
        }

        /// <summary>
        /// ���̓`�F�b�N
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�`�F�b�N����</returns>
        private bool InputCheck( out string errMsg )
        {
            errMsg = string.Empty;

            // �󎚍��ڃO���[�v
            foreach ( UltraGridRow grpRow in this.gridPrtItemGrp.Rows )
            {
                string filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + grpRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                DataRow[] filterDrArray = _ds.Tables[TBL_PRTITEMGRP].Select( filter );
                if ( filterDrArray.Length > 1 )
                {
                    errMsg = "�󎚍��ڃO���[�v�R�[�h���d�����Ă��܂�";
                    this.gridPrtItemGrp.Focus();
                    this.gridPrtItemGrp.Rows[grpRow.Index].Activate();
                    return false;
                }

                // �󎚍��ږ���
                foreach ( UltraGridRow setRow in this.gridPrtItemSet.Rows )
                {
                    filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + grpRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value
                        + " AND " + COL_PRTITEMSET_FREEPRTPAPERITEMCD + " = " + setRow.Cells[COL_PRTITEMSET_FREEPRTPAPERITEMCD].Value;
                    filterDrArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                    if ( filterDrArray.Length > 1 )
                    {
                        errMsg = "�󎚍��ڃR�[�h���d�����Ă��܂�";
                        this.gridPrtItemSet.Focus();
                        this.gridPrtItemSet.Rows[setRow.Index].Activate();
                        return false;
                    }
                }
            }

            // ���o��������
            foreach ( UltraGridRow row in this.gridFrePExCndD.Rows )
            {
                string filter = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + row.Cells[COL_FREPEXCNDD_EXTRACONDDETAILGRPCD].Value
                    + " AND " + COL_FREPEXCNDD_EXTRACONDDETAILCODE + "=" + row.Cells[COL_FREPEXCNDD_EXTRACONDDETAILCODE].Value;
                DataRow[] filterDrArray = _ds.Tables[TBL_FREPEXCNDD].Select( filter );
                if ( filterDrArray.Length > 1 )
                {
                    errMsg = "���o���׃R�[�h���d�����Ă��܂�";
                    if ( !this.pnlFrePExCndD.Visible ) this.pnlFrePExCndD.Visible = true;
                    this.gridFrePExCndD.Focus();
                    this.gridFrePExCndD.Rows[row.Index].Activate();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SaveProc( out string errMsg )
        {
            int status = 0;
            errMsg = string.Empty;

            string fileName = string.Empty;
            try
            {
                this.ubPrtItemGrpAddRow.Focus();

                // ���̓`�F�b�N
                if ( !InputCheck( out errMsg ) )
                    return 4;

                if ( _ds.Tables[TBL_PRTITEMGRP].Rows.Count != 0 ||
                    _ds.Tables[TBL_PRTITEMSET].Rows.Count != 0 )
                {
                    Directory.SetCurrentDirectory( System.Windows.Forms.Application.StartupPath );

                    StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];

                    // ������ CSV�t�@�C���̕ۑ� ������
                    // �󎚍��ڃO���[�v
                    fileName = Path.Combine( SFANL08246CA.ctCSVSavePath, TBL_PRTITEMGRP + ".csv" );
                    status = SFANL08246CA.SaveCsv( _ds, TBL_PRTITEMGRP, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg );
                    // �󎚍��ڐݒ�
                    if ( status == 0 )
                    {
                        fileName = Path.Combine( SFANL08246CA.ctCSVSavePath, TBL_PRTITEMSET + ".csv" );
                        status = SFANL08246CA.SaveCsv( _ds, TBL_PRTITEMSET, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg );
                    }
                    // ���R���[���o��������
                    if ( status == 0 )
                    {
                        fileName = Path.Combine( SFANL08246CA.ctCSVSavePath, TBL_FREPEXCNDD + ".csv" );
                        status = SFANL08246CA.SaveCsv( _ds, TBL_FREPEXCNDD, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg );
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                    // ���R���[�\�[�g���ʏ����ݒ�
                    if ( status == 0 )
                    {
                        fileName = Path.Combine( SFANL08246CA.ctCSVSavePath, TBL_FPSORTINIT + ".csv" );
                        status = SFANL08246CA.SaveCsv( _ds, TBL_FPSORTINIT, SFANL08246CA.ctXSLFileName, fileName, appendButtonTool.Checked, out errMsg );
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

                    // ������ XML�t�@�C���̕ۑ� ������
                    if ( status == 0 )
                    {
                        string filter = string.Empty;
                        foreach ( DataRow dr in _ds.Tables[TBL_PRTITEMGRP].Rows )
                        {
                            int freePrtPprItemGrpCd = (int)dr[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];
                            filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;
                            fileName = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_PRTITEMGRP + "_" + freePrtPprItemGrpCd + ".xml" );
                            status = SFANL08246CA.SaveXml( _ds, TBL_PRTITEMGRP, filter, fileName, out errMsg );
                            if ( status == 0 )
                            {
                                fileName = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_PRTITEMSET + "_" + freePrtPprItemGrpCd + ".xml" );
                                status = SFANL08246CA.SaveXml( _ds, TBL_PRTITEMSET, filter, COL_PRTITEMSET_FREEPRTPAPERITEMCD + " ASC", fileName, out errMsg );
                            }
                            if ( status == 0 )
                            {
                                fileName = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_FREPEXCNDD + ".xml" );
                                status = SFANL08246CA.SaveXml( _ds, TBL_FREPEXCNDD, string.Empty, fileName, out errMsg );
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                            if ( status == 0 )
                            {
                                fileName = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_FPSORTINIT + "_" + freePrtPprItemGrpCd + ".xml" );
                                status = SFANL08246CA.SaveXml( _ds, TBL_FPSORTINIT, filter, fileName, out errMsg );
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

                            if ( status != 0 ) break;
                        }
                    }
                }
                else
                {
                    status = 4;
                    errMsg = "�f�[�^�����͂���Ă��܂���B";
                }
            }
            catch ( Exception ex )
            {
                errMsg = "�ۑ������ɂė�O���������܂����B" + Environment.NewLine + ex.Message;
#if DEBUG
				errMsg += Environment.NewLine + ex.StackTrace;
#endif
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        private void DisplayInitialize()
        {
            _ds.Tables[TBL_PRTITEMGRP].Rows.Clear();
            _ds.Tables[TBL_PRTITEMSET].Rows.Clear();
            _ds.Tables[TBL_FREPEXCNDD].Rows.Clear();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
            _ds.Tables[TBL_FPSORTINIT].Rows.Clear();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

            this.ubPrtItemGrpDelRow.Enabled = false;
            this.ubPrtItemSetDelRow.Enabled = false;
            this.ubFrePExCndDDelRow.Enabled = false;

            this.pnlPrtItemSet.Enabled = false;

            StateButtonTool appendButtonTool = (StateButtonTool)this.utmMainToolbar.Tools["Append_StateButtonTool"];
            appendButtonTool.Checked = false;
            LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
            modeLabelTool.SharedProps.Caption = "CSV�㏑�����[�h";

            _isChanged = false;
            _isLoadFrePExCndD = false;
        }

        /// <summary>
        /// ���o�������׃O���[�v�R�[�h�X�V���̉�ʕύX����
        /// </summary>
        private void ChangeDispOfExtraCondDtlGrpCdUpdate()
        {
            if ( this.gridPrtItemSet.ActiveRow != null )
            {
                // �t�B���^�����̕ύX
                int extraCondDtlGrpCd
                    = (int)this.gridPrtItemSet.ActiveRow.Cells[COL_PRTITEMSET_EXTRACONDDETAILGRPCD].Value;
                if ( uceFilterFrePExCndD.Checked )
                {
                    _ds.Tables[TBL_FREPEXCNDD].DefaultView.RowFilter
                        = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + extraCondDtlGrpCd;
                }

                if ( extraCondDtlGrpCd != 0 )
                {
                    this.pnlFrePExCndD.Visible = true;
                }
                else
                {
                    if ( !this.uceDispFrePExCndD.Checked )
                        this.pnlFrePExCndD.Visible = false;
                }
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void SFANL08240UA_Load( object sender, EventArgs e )
        {
            string message = string.Empty;
            try
            {
                // �󎚍��ڃO���[�v
                CreateDataTableSchema( _ds, TBL_PRTITEMGRP );

                // �󎚍��ڐݒ�
                CreateDataTableSchema( _ds, TBL_PRTITEMSET );

                // ���R���[���o��������
                CreateDataTableSchema( _ds, TBL_FREPEXCNDD );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                // ���R���[�\�[�g���ʏ����ݒ�
                CreateDataTableSchema( _ds, TBL_FPSORTINIT );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

                this.gridPrtItemGrp.DataSource = _ds.Tables[TBL_PRTITEMGRP];
                this.gridPrtItemSet.DataSource = _ds.Tables[TBL_PRTITEMSET];
                this.gridFrePExCndD.DataSource = _ds.Tables[TBL_FREPEXCNDD];

                DisplayInitialize();
            }
            catch ( Exception ex )
            {
                message = "��ʋN�����ɗ�O���������܂����B" + Environment.NewLine + ex.Message;
            }

            if ( !string.IsNullOrEmpty( message ) )
            {
                MessageBox.Show(
                    message,
                    ctMSG_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1 );

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
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Grid_InitializeLayout( object sender, InitializeLayoutEventArgs e )
        {
            List<SchemaInfo> schemaInfoList = null;
            switch ( e.Layout.Grid.Name )
            {
                case "gridPrtItemGrp": schemaInfoList = _prtItemGrpSchemaInfoList; break;
                case "gridPrtItemSet": schemaInfoList = _prtItemSetSchemaInfoList; break;
                case "gridFrePExCndD": schemaInfoList = _frePExCndDSchemaInfoList; break;
            }

            if ( schemaInfoList != null )
            {
                foreach ( UltraGridColumn col in e.Layout.Bands[0].Columns )
                {
                    SchemaInfo schemaInfo = schemaInfoList.Find(
                        delegate( SchemaInfo wkSchemaInfo )
                        {
                            if ( wkSchemaInfo.Name == col.Key )
                                return true;
                            else
                                return false;
                        }
                    );

                    col.Header.Caption = schemaInfo.Caption;
                    col.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
                    col.MaxLength = schemaInfo.Length;

                    switch ( col.Key )
                    {
                        case COL_PRTITEMSET_FREEPRTPAPERITEMNM:
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/04 ADD
                        case COL_PRTITEMSET_FREEPRTPAPERITEMCD:
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/04 ADD
                            {
                                col.Header.Fixed = true;
                                break;
                            }
                        case COL_COMMON_CREATEDATETIME:
                        case COL_COMMON_UPDATEDATETIME:
                        case COL_COMMON_ENTERPRISECODE:
                        case COL_COMMON_FILEHEADERGUID:
                        case COL_COMMON_UPDEMPLOYEECODE:
                        case COL_COMMON_UPDASSEMBLYID1:
                        case COL_COMMON_UPDASSEMBLYID2:
                        case COL_COMMON_LOGICALDELETECODE:
                            {
                                if ( e.Layout.Grid.Name != "gridPrtItemGrp" )
                                    col.Hidden = true;
                                break;
                            }
                        case COL_PRTITEMGRP_PRINTPAPERUSEDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 1, "���[" );
                                valueList.ValueListItems.Add( 2, "�`�[" );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 DEL
                                //valueList.ValueListItems.Add(3, "DM�ꗗ�\");
                                //valueList.ValueListItems.Add(4, "DM�͂���");
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                                valueList.ValueListItems.Add( 5, "������" );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_REPORTCONTROLCODE:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 1, "TextBox" );
                                valueList.ValueListItems.Add( 2, "Label" );
                                valueList.ValueListItems.Add( 3, "Picture" );
                                valueList.ValueListItems.Add( 4, "Shape" );
                                valueList.ValueListItems.Add( 5, "Line" );
                                valueList.ValueListItems.Add( 6, "BarCode" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_FREEPRTPPRITEMGRPCD:
                            {
                                if ( e.Layout.Grid.Name == "gridPrtItemSet" )
                                    col.Hidden = true;
                                break;
                            }
                        case COL_PRTITEMSET_HEADERUSEDIVCD:
                        case COL_PRTITEMSET_DETAILUSEDIVCD:
                        case COL_PRTITEMSET_FOOTERUSEDIVCD:
                        case COL_PRTITEMSET_TOTALITEMDIVCD:
                        case COL_PRTITEMSET_FORMFEEDITEMDIVCD:
                        case COL_PRTITEMSET_NECESSARYEXTRACONDCD:
                        case COL_PRTITEMSET_ADDITEMUSEDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "�g�p���Ȃ�" );
                                valueList.ValueListItems.Add( 1, "�g�p����" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_DTLCOLORCHANGECD:
                        case COL_PRTITEMSET_GROUPSUPPRESSCD:
                        case COL_PRTITEMSET_CIPHERFLG:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "�Ȃ�" );
                                valueList.ValueListItems.Add( 1, "����" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_EXTRACTIONITDEDFLG:
                        case COL_PRTITEMSET_HEIGHTADJUSTDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "��Ώ�" );
                                valueList.ValueListItems.Add( 1, "�Ώ�" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_COMMAEDITEXISTCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "�g�p���Ȃ�" );
                                valueList.ValueListItems.Add( 1, "#,###" );
                                valueList.ValueListItems.Add( 2, "#,##0" );
                                valueList.ValueListItems.Add( 5, "\\#,##0" );
                                valueList.ValueListItems.Add( 6, "\\#,##0-" );
                                valueList.ValueListItems.Add( 3, "0.0" );
                                valueList.ValueListItems.Add( 4, "0.00" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_EXTRACONDITIONDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "�g�p���Ȃ�" );
                                valueList.ValueListItems.Add( 1, "���l�^" );
                                valueList.ValueListItems.Add( 2, "�����^�i���p�j" );
                                valueList.ValueListItems.Add( 3, "�����^�i�S�p�j" );
                                valueList.ValueListItems.Add( 4, "���t�^" );
                                valueList.ValueListItems.Add( 5, "�R���{�{�b�N�X�^" );
                                valueList.ValueListItems.Add( 6, "�`�F�b�N�{�b�N�X�^" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_EXTRACONDITIONTYPECD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "��v" );
                                valueList.ValueListItems.Add( 1, "�͈�" );
                                valueList.ValueListItems.Add( 2, "�����܂�" );
                                valueList.ValueListItems.Add( 3, "����" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_PRINTPAGECTRLDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "�S�y�[�W" );
                                valueList.ValueListItems.Add( 1, "1�y�[�W�ڂ̂�" );
                                valueList.ValueListItems.Add( 2, "�ŏI�y�[�W�̂�" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMGRP_DATAINPUTSYSTEM:
                        case COL_PRTITEMGRP_LINKSLIPDATAINPUTSYS:
                        case COL_PRTITEMSET_SYSTEMDIVCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "����" );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                                //valueList.ValueListItems.Add( 1, "����" );
                                //valueList.ValueListItems.Add( 2, "���" );
                                //valueList.ValueListItems.Add( 3, "�Ԕ�" );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMGRP_EXTRASECTIONKINDCD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "�g�p���Ȃ�" );
                                valueList.ValueListItems.Add( 1, "���сE����" );
                                valueList.ValueListItems.Add( 2, "�d���E�̔�" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMGRP_FREEPRTPPRSPPRPSECD:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "�g�p���Ȃ�" );
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                                //valueList.ValueListItems.Add( 1, "�ē�������^�C�v" );
                                //valueList.ValueListItems.Add( 2, "��p���[" );
                                //valueList.ValueListItems.Add( 3, "�����͂���" );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                                // �`�[�֘A�i�敪�l�͐݌v�t�h�ł̋�ʂׂ̈����Ɏg�p�j
                                valueList.ValueListItems.Add( 1, "���Ϗ�" );
                                valueList.ValueListItems.Add( 4, "�d���ԕi�`�[" );
                                valueList.ValueListItems.Add( 15, "�݌Ɉړ��`�[" );
                                valueList.ValueListItems.Add( 16, "�t�n�d�`�[" );
                                // �������֘A�i�敪�l�����̂܂ܐ������Ǘ��}�X�^�̈���^�C�v�ɃZ�b�g�j
                                valueList.ValueListItems.Add( 50, "���v������" );
                                valueList.ValueListItems.Add( 60, "���א�����" );
                                valueList.ValueListItems.Add( 70, "�`�[���v������" );
                                valueList.ValueListItems.Add( 80, "�̎���" );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMGRP_EXTRASECTIONSELEXIST:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "�g�p���Ȃ�" );
                                valueList.ValueListItems.Add( 1, "�g�p����(�����I��)" );
                                valueList.ValueListItems.Add( 2, "�g�p����(�P�̑I��)" );
                                col.ValueList = valueList;
                                break;
                            }
                        case COL_PRTITEMSET_BARCODESTYLE:
                            {
                                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

                                ValueList valueList = new ValueList();
                                valueList.ValueListItems.Add( 0, "�Ȃ�" );
                                valueList.ValueListItems.Add( 1, "Code_128_A" );
                                valueList.ValueListItems.Add( 2, "JapanesePostal" );
                                valueList.ValueListItems.Add( 3, "QRCode" );
                                col.ValueList = valueList;
                                break;
                            }
                        default:
                            {
                                if ( col.DataType.IsPrimitive && !col.DataType.Equals( typeof( bool ) ) )
                                    col.CellAppearance.TextHAlign = HAlign.Right;
                                break;
                            }
                    }
                }
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
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void utmMainToolbar_ToolClick( object sender, ToolClickEventArgs e )
        {
            switch ( e.Tool.Key )
            {
                case "Exit_ButtonTool":
                    {
                        this.Close();
                        break;
                    }
                case "Open_ButtonTool":
                    {
                        this.openFileDialog.Filter = "�󎚍��ڃO���[�vXML�t�@�C��|PrtItemGrp*.xml";
                        this.openFileDialog.InitialDirectory = Path.Combine( System.Windows.Forms.Application.StartupPath, SFANL08246CA.ctXMLSavePath );
                        if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
                        {
                            // �󎚍��ڃO���[�v
                            _ds.Tables[TBL_PRTITEMGRP].ReadXml( this.openFileDialog.FileName );
                            // �󎚍��ڐݒ�
                            string fileName = Path.GetFileName( this.openFileDialog.FileName );
                            string filePath = Path.Combine( Path.GetDirectoryName( this.openFileDialog.FileName ), fileName.Replace( TBL_PRTITEMGRP, TBL_PRTITEMSET ) );
                            if ( File.Exists( filePath ) )
                                _ds.Tables[TBL_PRTITEMSET].ReadXml( filePath );
                            // ���R���[���o��������
                            if ( !_isLoadFrePExCndD )
                            {
                                filePath = Path.Combine( Path.GetDirectoryName( this.openFileDialog.FileName ), TBL_FREPEXCNDD + ".xml" );
                                if ( File.Exists( filePath ) )
                                {
                                    _ds.Tables[TBL_FREPEXCNDD].ReadXml( filePath );
                                    _isLoadFrePExCndD = true;
                                }
                            }
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                            // ���R���[�\�[�g���ʏ����ݒ�
                            filePath = Path.Combine( Path.GetDirectoryName( this.openFileDialog.FileName ), fileName.Replace( TBL_PRTITEMGRP, TBL_FPSORTINIT ) );
                            if ( File.Exists( filePath ) )
                            {
                                _ds.Tables[TBL_FPSORTINIT].ReadXml( filePath );
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD

                            _isChanged = false;
                        }
                        break;
                    }
                case "Save_ButtonTool":
                    {
                        string errMsg;
                        int status = SaveProc( out errMsg );
                        switch ( status )
                        {
                            case 0:
                                {
                                    MessageBox.Show(
                                        "�ۑ����܂����B",
                                        ctMSG_CAPTION,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1 );
                                    _isChanged = false;
                                    break;
                                }
                            case 4:
                                {
                                    MessageBox.Show(
                                        errMsg,
                                        ctMSG_CAPTION,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information,
                                        MessageBoxDefaultButton.Button1 );
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show(
                                        errMsg,
                                        ctMSG_CAPTION,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1 );
                                    break;
                                }
                        }
                        break;
                    }
                case "New_ButtonTool":
                    {
                        DisplayInitialize();
                        break;
                    }
                case "Append_StateButtonTool":
                    {
                        StateButtonTool appendButtonTool = (StateButtonTool)e.Tool;
                        LabelTool modeLabelTool = (LabelTool)this.utmMainToolbar.Tools["Mode_LabelTool"];
                        if ( appendButtonTool.Checked )
                            modeLabelTool.SharedProps.Caption = "CSV�ǋL���[�h";
                        else
                            modeLabelTool.SharedProps.Caption = "CSV�㏑�����[�h";
                        break;
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
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemGrp_AfterRowActivate( object sender, EventArgs e )
        {
            this.gridPrtItemGrp.Selected.Rows.Clear();
            this.gridPrtItemGrp.ActiveRow.Selected = true;

            // �t�B���^�����̕ύX
            int freePrtPprItemGrpCd
                = (int)this.gridPrtItemGrp.ActiveRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
            _ds.Tables[TBL_PRTITEMSET].DefaultView.RowFilter
                = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;

            if ( freePrtPprItemGrpCd != 0 )
                this.pnlPrtItemSet.Enabled = true;

            this.ubPrtItemGrpDelRow.Enabled = true;
        }

        /// <summary>
        /// �O���b�hAfterRowActivate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �O���b�h��̍s���A�N�e�B�u���������ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemSet_AfterRowActivate( object sender, EventArgs e )
        {
            this.gridPrtItemSet.Selected.Rows.Clear();
            this.gridPrtItemSet.ActiveRow.Selected = true;

            ChangeDispOfExtraCondDtlGrpCdUpdate();

            this.ubPrtItemSetDelRow.Enabled = true;
        }

        /// <summary>
        /// �O���b�hAfterRowActivate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �O���b�h��̍s���A�N�e�B�u���������ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridFrePExCndD_AfterRowActivate( object sender, EventArgs e )
        {
            this.gridFrePExCndD.Selected.Rows.Clear();
            this.gridFrePExCndD.ActiveRow.Selected = true;

            this.ubFrePExCndDDelRow.Enabled = true;
        }

        /// <summary>
        /// �O���b�hAfterCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����V�����l���󂯓��ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemGrp_AfterCellUpdate( object sender, CellEventArgs e )
        {
            switch ( e.Cell.Column.Key )
            {
                case COL_COMMON_CREATEDATETIME:
                case COL_COMMON_UPDATEDATETIME:
                case COL_COMMON_LOGICALDELETECODE:
                    {
                        int freePrtPprItemGrpCd = (int)e.Cell.Row.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                        string filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;
                        DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                        foreach ( DataRow dr in drArray )
                            dr[e.Cell.Column.Key] = e.Cell.Value;
                        break;
                    }
                case COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD:
                    {
                        _ds.Tables[TBL_PRTITEMGRP].Rows[e.Cell.Row.ListIndex][COL_PRTITEMSET_FREEPRTPPRITEMGRPCD]
                            = e.Cell.Value;

                        string filter = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + _prevFreePrtPprItemGrpCd;
                        DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                        foreach ( DataRow dr in drArray )
                            dr[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD] = e.Cell.Value;

                        // �t�B���^�ݒ���X�V
                        _ds.Tables[TBL_PRTITEMSET].DefaultView.RowFilter
                            = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + e.Cell.Value;
                        break;
                    }
            }
            _isChanged = true;
        }

        /// <summary>
        /// �O���b�hBeforeCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����V�����l���󂯓����O�ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemGrp_BeforeCellUpdate( object sender, BeforeCellUpdateEventArgs e )
        {
            string message = string.Empty;

            switch ( e.Cell.Column.Key )
            {
                case COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD:
                    {
                        int freePrtPprItemGrpCd = (int)e.NewValue;
                        if ( freePrtPprItemGrpCd == 0 )
                        {
                            message = e.Cell.Column.Header.Caption + "��0�͐ݒ�ł��܂���B";
                        }
                        else
                        {
                            DataRow[] drArray = _ds.Tables[TBL_PRTITEMGRP].Select( COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd );
                            if ( drArray == null || drArray.Length == 0 )
                                _prevFreePrtPprItemGrpCd = (int)e.Cell.Value;
                            else
                                message = e.Cell.Column.Header.Caption + "�̏d���͋�����Ă��܂���B";
                        }
                        break;
                    }
            }

            if ( !string.IsNullOrEmpty( message ) )
            {
                MessageBox.Show(
                    message,
                    ctMSG_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1 );
                e.Cancel = true;
            }
        }

        /// <summary>
        /// �O���b�hBeforeCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����V�����l���󂯓����O�ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemSet_BeforeCellUpdate( object sender, BeforeCellUpdateEventArgs e )
        {
            string message = string.Empty;

            switch ( e.Cell.Column.Key )
            {
                case COL_PRTITEMSET_FREEPRTPAPERITEMCD:
                    {
                        int freePrtPprItemGrpCd = (int)e.Cell.Row.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                        int freePrtPaperItemCd = (int)e.NewValue;
                        string filter = COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd + " AND " + COL_PRTITEMSET_FREEPRTPAPERITEMCD + "=" + freePrtPaperItemCd;
                        DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                        if ( drArray != null && drArray.Length > 0 )
                            message = e.Cell.Column.Header.Caption + "�̏d���͋�����Ă��܂���B";
                        break;
                    }
                case COL_PRTITEMSET_EXTRACONDITIONTYPECD:
                    {
                        int extraConditionTypeCd = (int)e.NewValue;
                        int extraConditionDivCd = (int)e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Value;
                        switch ( extraConditionDivCd )
                        {
                            case 1:	// ���l�^
                                {
                                    if ( extraConditionTypeCd != 0 &&
                                        extraConditionTypeCd != 1 )
                                    {
                                        message =
                                            e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Column.Header.Caption + "�u"
                                            + e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Text + "�v�̎��A"
                                            + e.Cell.Column.Header.Caption + "�u" + e.Cell.Text + "�v�͑I���o���܂���B";
                                    }
                                    break;
                                }
                            case 2: // �����^�i���p�j
                            case 3: // �����^�i�S�p�j
                                {
                                    if ( extraConditionTypeCd != 0 &&
                                        extraConditionTypeCd != 1 &&
                                        extraConditionTypeCd != 2 )
                                    {
                                        message =
                                            e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Column.Header.Caption + "�u"
                                            + e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Text + "�v�̎��A"
                                            + e.Cell.Column.Header.Caption + "�u" + e.Cell.Text + "�v�͑I���o���܂���B";
                                    }
                                    break;
                                }
                            case 4: // ���t�^
                                {
                                    if ( extraConditionTypeCd != 0 &&
                                        extraConditionTypeCd != 1 &&
                                        extraConditionTypeCd != 2 &&
                                        extraConditionTypeCd != 3 )
                                    {
                                        message =
                                            e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Column.Header.Caption + "�u"
                                            + e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Text + "�v�̎��A"
                                            + e.Cell.Column.Header.Caption + "�u" + e.Cell.Text + "�v�͑I���o���܂���B";
                                    }
                                    break;
                                }
                            default:
                                {
                                    message =
                                        e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Column.Header.Caption + "�u"
                                        + e.Cell.Row.Cells[COL_PRTITEMSET_EXTRACONDITIONDIVCD].Text + "�v�̎��A"
                                        + e.Cell.Column.Header.Caption + "�u" + e.Cell.Text + "�v�͑I���o���܂���B";
                                    break;
                                }
                        }
                        break;
                    }
            }

            if ( !string.IsNullOrEmpty( message ) )
            {
                MessageBox.Show(
                    message,
                    ctMSG_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1 );
                e.Cancel = true;
            }
        }

        /// <summary>
        /// �O���b�hBeforeCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����V�����l���󂯓����O�ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridFrePExCndD_BeforeCellUpdate( object sender, BeforeCellUpdateEventArgs e )
        {
            string message = string.Empty;

            switch ( e.Cell.Column.Key )
            {
                case COL_FREPEXCNDD_EXTRACONDDETAILCODE:
                    {
                        int extraCondDetailGrpCd = (int)e.Cell.Row.Cells[COL_FREPEXCNDD_EXTRACONDDETAILGRPCD].Value;
                        int extraCondDetailCode = (int)e.NewValue;
                        string filter = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + extraCondDetailGrpCd + " AND " + COL_FREPEXCNDD_EXTRACONDDETAILCODE + "=" + extraCondDetailCode;
                        DataRow[] drArray = _ds.Tables[TBL_FREPEXCNDD].Select( filter );
                        if ( drArray != null && drArray.Length > 0 )
                            message = e.Cell.Column.Header.Caption + "�̏d���͋�����Ă��܂���B";
                        break;
                    }
            }

            if ( !string.IsNullOrEmpty( message ) )
            {
                MessageBox.Show(
                    message,
                    ctMSG_CAPTION,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1 );
                e.Cancel = true;
            }
        }

        /// <summary>
        /// �O���b�hAfterCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����V�����l���󂯓��ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemSet_AfterCellUpdate( object sender, CellEventArgs e )
        {
            switch ( e.Cell.Column.Key )
            {
                case COL_PRTITEMSET_EXTRACONDITIONDIVCD:
                    {
                        _ds.Tables[TBL_PRTITEMSET].Rows[e.Cell.Row.ListIndex][COL_PRTITEMSET_EXTRACONDITIONTYPECD] = 0;
                        break;
                    }
                case COL_PRTITEMSET_EXTRACONDDETAILGRPCD:
                    {
                        ChangeDispOfExtraCondDtlGrpCdUpdate();
                        break;
                    }
            }
            _isChanged = true;
        }

        /// <summary>
        /// �O���b�hAfterCellActivate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����A�N�e�B�u�ɂȂ�����ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Gird_AfterCellActivate( object sender, EventArgs e )
        {
            UltraGrid ultraGrid = (UltraGrid)sender;

            if ( ultraGrid.ActiveCell.CanEnterEditMode )
                ultraGrid.PerformAction( UltraGridAction.EnterEditMode );
        }

        /// <summary>
        /// �O���b�hKeyDown�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �L�[���ŏ��ɉ����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Grid_KeyDown( object sender, KeyEventArgs e )
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            switch ( e.KeyCode )
            {
                case Keys.Enter:
                    {
                        ultraGrid.PerformAction( UltraGridAction.NextCell );
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if ( ultraGrid.ActiveCell != null )
                        {
                            switch ( ultraGrid.ActiveCell.Column.Style )
                            {
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
                                    {
                                        if ( e.Alt )
                                        {
                                            ultraGrid.ActiveCell.DroppedDown = true;
                                            e.Handled = true;
                                        }
                                        else if ( !ultraGrid.ActiveCell.DroppedDown )
                                        {
                                            ultraGrid.PerformAction( UltraGridAction.AboveCell );
                                            e.Handled = true;
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        ultraGrid.PerformAction( UltraGridAction.AboveCell );
                                        e.Handled = true;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if ( ultraGrid.ActiveCell != null )
                        {
                            switch ( ultraGrid.ActiveCell.Column.Style )
                            {
                                case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
                                    {
                                        if ( e.Alt )
                                        {
                                            ultraGrid.ActiveCell.DroppedDown = true;
                                            e.Handled = true;
                                        }
                                        else if ( !ultraGrid.ActiveCell.DroppedDown )
                                        {
                                            ultraGrid.PerformAction( UltraGridAction.BelowCell );
                                            e.Handled = true;
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        ultraGrid.PerformAction( UltraGridAction.BelowCell );
                                        e.Handled = true;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        switch ( ultraGrid.ActiveCell.Column.Style )
                        {
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                                {
                                    if ( ultraGrid.ActiveCell.IsInEditMode )
                                    {
                                        if ( ultraGrid.ActiveCell.SelStart == 0 &&
                                            ultraGrid.ActiveCell.SelLength == 0 )
                                        {
                                            ultraGrid.PerformAction( UltraGridAction.PrevCell );
                                            e.Handled = true;
                                        }
                                    }
                                    else
                                    {
                                        ultraGrid.PerformAction( UltraGridAction.PrevCell );
                                        e.Handled = true;
                                    }
                                    break;
                                }
                            default:
                                {
                                    ultraGrid.PerformAction( UltraGridAction.PrevCell );
                                    e.Handled = true;
                                    break;
                                }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        switch ( ultraGrid.ActiveCell.Column.Style )
                        {
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                                {
                                    if ( ultraGrid.ActiveCell.IsInEditMode )
                                    {
                                        if ( ultraGrid.ActiveCell.SelStart == ultraGrid.ActiveCell.Text.Length &&
                                            ultraGrid.ActiveCell.SelLength == 0 )
                                        {
                                            ultraGrid.PerformAction( UltraGridAction.NextCell );
                                            e.Handled = true;
                                        }
                                    }
                                    else
                                    {
                                        ultraGrid.PerformAction( UltraGridAction.NextCell );
                                        e.Handled = true;
                                    }
                                    break;
                                }
                            default:
                                {
                                    ultraGrid.PerformAction( UltraGridAction.NextCell );
                                    e.Handled = true;
                                    break;
                                }
                        }
                        break;
                    }
                case Keys.Delete:
                    {
                        if ( ultraGrid.ActiveCell != null )
                        {
                            if ( ultraGrid.ActiveCell.Column.DataType.Equals( typeof( int ) ) )
                                ultraGrid.ActiveCell.CancelUpdate();
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �J���{�^��Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �J���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubFileOpen_Click( object sender, EventArgs e )
        {
            if ( this.gridPrtItemGrp.ActiveRow != null )
            {
                int freePrtPprItemGrpCd = (int)this.gridPrtItemGrp.ActiveRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                this.openFileDialog.Filter = "�t�@�C���d�l��(*.xls)|*.xls";
                if ( this.openFileDialog.ShowDialog() == DialogResult.OK )
                {
                    DeployLayoutInfo( this.openFileDialog.FileName, freePrtPprItemGrpCd );
                }
            }
            _isChanged = true;
        }

        /// <summary>
        /// �s�ǉ��{�^��Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �s�ǉ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubAddRow_Click( object sender, EventArgs e )
        {
            int freePrtPprItemGrpCd = 0;
            if ( sender == this.ubPrtItemGrpAddRow )
            {
                freePrtPprItemGrpCd = GetMaxFreePrtPprItemGrpCd() + 1;
                AddRow( TBL_PRTITEMGRP, freePrtPprItemGrpCd );

                // ���R���[���o��������
                if ( !_isLoadFrePExCndD )
                {
                    string filePath = Path.Combine( SFANL08246CA.ctXMLSavePath, TBL_FREPEXCNDD + ".xml" );
                    if ( File.Exists( filePath ) )
                    {
                        _ds.Tables[TBL_FREPEXCNDD].ReadXml( filePath );
                        _isLoadFrePExCndD = true;
                    }
                }

                AddPrtItemSetDefaultValueRow( freePrtPprItemGrpCd );
            }
            else if ( sender == this.ubPrtItemSetAddRow )
            {
                if ( this.gridPrtItemGrp.ActiveRow != null )
                {
                    freePrtPprItemGrpCd
                        = (int)this.gridPrtItemGrp.ActiveRow.Cells[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD].Value;
                    AddRow( TBL_PRTITEMSET, freePrtPprItemGrpCd );
                }
            }
            else if ( sender == this.ubFrePExCndDAddRow )
            {
                AddRow( TBL_FREPEXCNDD, 0 );
            }
            _isChanged = true;
        }

        /// <summary>
        /// �s�폜�{�^��Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �s�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubDelRow_Click( object sender, EventArgs e )
        {
            int focusSetIndex = 0;

            if ( sender == this.ubPrtItemGrpDelRow )
            {
                if ( this.gridPrtItemGrp.ActiveRow != null )
                {
                    // �폜�ΏۂƂȂ�DataRow���擾
                    focusSetIndex = Math.Max( focusSetIndex, this.gridPrtItemGrp.ActiveRow.Index );
                    DataRow row = _ds.Tables[TBL_PRTITEMGRP].Rows[this.gridPrtItemGrp.ActiveRow.ListIndex];
                    int freePrtPprItemGrpCd = (int)row[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];

                    // �I���s���폜
                    _ds.Tables[TBL_PRTITEMGRP].Rows.Remove( row );
                    if ( focusSetIndex > 0 ) focusSetIndex--;

                    // �R�t���󎚍��ڐݒ���폜
                    string filter = COL_PRTITEMSET_FREEPRTPPRITEMGRPCD + "=" + freePrtPprItemGrpCd;
                    DataRow[] drArray = _ds.Tables[TBL_PRTITEMSET].Select( filter );
                    foreach ( DataRow dr in drArray )
                        _ds.Tables[TBL_PRTITEMSET].Rows.Remove( dr );

                    // �s���c���Ă���ꍇ��1�s�ڂ��A�N�e�B�u��
                    if ( this.gridPrtItemGrp.Rows.Count > 0 )
                    {
                        this.gridPrtItemGrp.Rows[focusSetIndex].Activate();
                    }
                    else
                    {
                        this.ubPrtItemGrpDelRow.Enabled = false;
                        this.pnlPrtItemSet.Enabled = false;
                    }
                }
            }
            else if ( sender == this.ubPrtItemSetDelRow )
            {
                if ( this.gridPrtItemSet.ActiveRow != null )
                {
                    // �폜�ΏۂƂȂ�DataRow���擾
                    List<DataRow> drList = new List<DataRow>();
                    focusSetIndex = Math.Max( focusSetIndex, this.gridPrtItemSet.ActiveRow.Index );

                    // �I���s���폜
                    DataRow row = ((DataRowView)this.gridPrtItemSet.ActiveRow.ListObject).Row;
                    _ds.Tables[TBL_PRTITEMSET].Rows.Remove( row );
                    if ( focusSetIndex > 0 ) focusSetIndex--;

                    // �s���c���Ă���ꍇ��1�s�ڂ��A�N�e�B�u��
                    if ( this.gridPrtItemSet.Rows.Count > 0 )
                        this.gridPrtItemSet.Rows[focusSetIndex].Activate();
                    else
                        this.ubPrtItemSetDelRow.Enabled = false;
                }
            }
            else if ( sender == this.ubFrePExCndDDelRow )
            {
                if ( this.gridFrePExCndD.ActiveRow != null )
                {
                    // �폜�ΏۂƂȂ�DataRow���擾
                    focusSetIndex = Math.Max( focusSetIndex, this.gridFrePExCndD.ActiveRow.Index );

                    // �I���s���폜
                    DataRow row = _ds.Tables[TBL_FREPEXCNDD].Rows[this.gridFrePExCndD.ActiveRow.ListIndex];
                    _ds.Tables[TBL_FREPEXCNDD].Rows.Remove( row );
                    if ( focusSetIndex > 0 ) focusSetIndex--;

                    // �s���c���Ă���ꍇ��1�s�ڂ��A�N�e�B�u��
                    if ( this.gridFrePExCndD.Rows.Count > 0 )
                        this.gridFrePExCndD.Rows[focusSetIndex].Activate();
                    else
                        this.ubFrePExCndDDelRow.Enabled = false;
                }
            }
            _isChanged = true;
        }

        /// <summary>
        /// �R���g���[��CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: Checked�v���p�e�B�̒l���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void uceDispFrePExCndD_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.uceDispFrePExCndD.Checked )
            {
                this.pnlFrePExCndD.Visible = true;
            }
            else
            {
                if ( this.gridPrtItemSet.ActiveRow != null )
                {
                    int extraCondDtlGrpCd
                        = (int)this.gridPrtItemSet.ActiveRow.Cells[COL_PRTITEMSET_EXTRACONDDETAILGRPCD].Value;

                    if ( extraCondDtlGrpCd != 0 )
                        this.pnlFrePExCndD.Visible = true;
                    else
                        this.pnlFrePExCndD.Visible = false;
                }
                else
                {
                    this.pnlFrePExCndD.Visible = false;
                }
            }
        }

        /// <summary>
        /// �R���g���[��CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: Checked�v���p�e�B�̒l���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void uceFilterFrePExCndD_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.uceFilterFrePExCndD.Checked )
            {
                // �t�B���^�����̕ύX
                if ( this.gridPrtItemSet.ActiveRow != null )
                {
                    int extraCondDtlGrpCd
                        = (int)this.gridPrtItemSet.ActiveRow.Cells[COL_PRTITEMSET_EXTRACONDDETAILGRPCD].Value;

                    _ds.Tables[TBL_FREPEXCNDD].DefaultView.RowFilter
                        = COL_FREPEXCNDD_EXTRACONDDETAILGRPCD + "=" + extraCondDtlGrpCd;
                }
            }
            else
            {
                _ds.Tables[TBL_FREPEXCNDD].DefaultView.RowFilter = string.Empty;
            }
        }

        /// <summary>
        /// �O���b�hKeyPress�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �R���g���[�����t�H�[�J�X�������Ă��āA</br>
        /// <br>			: ���[�U�[���L�[�������ė������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Grid_KeyPress( object sender, KeyPressEventArgs e )
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            // Ctrl�AAlt�L�[���������Ă��Ȃ�
            if ( !Control.ModifierKeys.Equals( Keys.Control ) &&
                !Control.ModifierKeys.Equals( Keys.Alt ) )
            {
                // ��̃X�^�C����Edit
                if ( ultraGrid.ActiveCell != null &&
                    ultraGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default )
                {
                    // ���l�^�̗�
                    if ( ultraGrid.ActiveCell.Column.DataType.IsPrimitive &&
                        !ultraGrid.ActiveCell.Column.DataType.Equals( typeof( bool ) ) )
                    {
                        // �����L�[�y��BackSpace�ȊO�͏��O
                        if ( (!char.IsDigit( e.KeyChar )) &&
                            (!e.KeyChar.Equals( (char)Keys.Back )) )
                            e.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// FormClosing�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[������邽�тɁA�t�H�[����������O�A</br>
        /// <br>			: ����ѕ��闝�R���w�肷��O�ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void SFANL08240UA_FormClosing( object sender, FormClosingEventArgs e )
        {
            if ( _isChanged )
            {
                if ( _ds.Tables[TBL_PRTITEMGRP].Rows.Count > 0 ||
                    _ds.Tables[TBL_PRTITEMSET].Rows.Count > 0 ||
                    _ds.Tables[TBL_FREPEXCNDD].Rows.Count > 0 )
                {
                    DialogResult dlgRet = MessageBox.Show(
                        "���ݕҏW���̃f�[�^�����݂��܂��B" + Environment.NewLine + "�f�[�^��ۑ����܂����H"
                        , "�ۑ��m�F"
                        , MessageBoxButtons.YesNoCancel
                        , MessageBoxIcon.Question
                        , MessageBoxDefaultButton.Button1
                    );
                    switch ( dlgRet )
                    {
                        case DialogResult.Yes:
                            {
                                string errMsg;
                                int status = SaveProc( out errMsg );
                                switch ( status )
                                {
                                    case 0:
                                        {
                                            break;
                                        }
                                    default:
                                        {
                                            MessageBox.Show(
                                                errMsg,
                                                ctMSG_CAPTION,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error,
                                                MessageBoxDefaultButton.Button1 );
                                            break;
                                        }
                                }
                                break;
                            }
                        case DialogResult.No:
                            {
                                break;
                            }
                        case DialogResult.Cancel:
                            {
                                e.Cancel = true;
                                break;
                            }
                    }
                }
            }
        }

        /// <summary>
        /// ���R���[���ڃR�[�h�̔ԃ{�^��Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���R���[���ڃR�[�h�̔ԃ{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubSetFreePrtPaperItemCd_Click( object sender, EventArgs e )
        {
            this.gridPrtItemSet.EventManager.AllEventsEnabled = false;
            try
            {
                int number = 101;
                foreach ( UltraGridRow row in this.gridPrtItemSet.Rows )
                {
                    int freePrtPaperItemCd;
                    int.TryParse( row.Cells[COL_PRTITEMSET_FREEPRTPAPERITEMCD].Value.ToString(), out freePrtPaperItemCd );
                    if ( freePrtPaperItemCd > 100 )
                        _ds.Tables[TBL_PRTITEMSET].Rows[row.ListIndex][COL_PRTITEMSET_FREEPRTPAPERITEMCD] = number++;
                }
            }
            finally
            {
                this.gridPrtItemSet.EventManager.AllEventsEnabled = true;
            }
        }

        /// <summary>
        /// �O���b�hAfterCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�����V�����l���󂯓��ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridFrePExCndD_AfterCellUpdate( object sender, CellEventArgs e )
        {
            _isChanged = true;
        }

        /// <summary>
        /// UP�{�^��Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UP�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubUp_Click( object sender, EventArgs e )
        {
            if ( this.gridPrtItemSet.ActiveRow != null )
            {
                int rowIndex = this.gridPrtItemSet.ActiveRow.Index;
                if ( rowIndex > 0 )
                    this.gridPrtItemSet.Rows.Move( this.gridPrtItemSet.ActiveRow, rowIndex - 1, true );
                _isChanged = true;
            }
        }

        /// <summary>
        /// DOWN�{�^��Click�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: DOWN�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void ubDown_Click( object sender, EventArgs e )
        {
            if ( this.gridPrtItemSet.ActiveRow != null )
            {
                int rowIndex = this.gridPrtItemSet.ActiveRow.Index;
                if ( rowIndex < this.gridPrtItemSet.Rows.Count - 1 )
                    this.gridPrtItemSet.Rows.Move( this.gridPrtItemSet.ActiveRow, rowIndex + 1, true );
                _isChanged = true;
            }
        }

        /// <summary>
        /// �O���b�hENTER�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[���ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void Grid_Enter( object sender, EventArgs e )
        {
            UltraGrid ultraGrid = (UltraGrid)sender;
            if ( ultraGrid.Rows.Count > 0 )
            {
                if ( ultraGrid.ActiveCell == null )
                {
                    if ( ultraGrid.ActiveRow == null )
                        ultraGrid.Rows[0].Cells[0].Activate();
                    else
                        ultraGrid.ActiveRow.Cells[0].Activate();
                }
                ultraGrid.PerformAction( UltraGridAction.EnterEditMode );
            }
        }

        /// <summary>
        /// �O���b�hInitializeRow�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �s�����������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.07.03</br>
        /// </remarks>
        private void gridPrtItemSet_InitializeRow( object sender, InitializeRowEventArgs e )
        {
            // �o�[�R�[�h�X�^�C���̓R���g���[���^�C�v��Barcode�̎��̂ݕҏW�\
            if ( (int)e.Row.Cells[COL_PRTITEMSET_REPORTCONTROLCODE].Value == 6 )
                e.Row.Cells[COL_PRTITEMSET_BARCODESTYLE].Activation = Activation.AllowEdit;
            else
                e.Row.Cells[COL_PRTITEMSET_BARCODESTYLE].Activation = Activation.Disabled;
        }
        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/04 ADD
        /// <summary>
        /// ���ו��ʃ{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click( object sender, EventArgs e )
        {
            // �A�N�e�B�u�ȍs�̃O���[�v�R�[�h���擾
            int focusSetIndex = this.gridPrtItemGrp.ActiveRow.Index;
            DataRow row = _ds.Tables[TBL_PRTITEMGRP].Rows[this.gridPrtItemGrp.ActiveRow.ListIndex];
            int freePrtPprItemGrpCd = (int)row[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];

            // �R�s�[�t�H�[���Ăяo��
            SFANL08240UB copyForm = new SFANL08240UB( _ds.Tables[TBL_PRTITEMSET], freePrtPprItemGrpCd );
            copyForm.Show();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/04 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
        private void ultraButton2_Click( object sender, EventArgs e )
        {
            // �f�[�^�R�s�[
            CopyToSortInitFromPrtItem();

            // �A�N�e�B�u�ȍs�̃O���[�v�R�[�h���擾
            int focusSetIndex = this.gridPrtItemGrp.ActiveRow.Index;
            DataRow row = _ds.Tables[TBL_PRTITEMGRP].Rows[this.gridPrtItemGrp.ActiveRow.ListIndex];
            int freePrtPprItemGrpCd = (int)row[COL_PRTITEMGRP_FREEPRTPPRITEMGRPCD];

            SFANL08240UC sortSettingForm = new SFANL08240UC( _ds.Tables[TBL_FPSORTINIT], freePrtPprItemGrpCd );
            sortSettingForm.ShowDialog();

            // �s�v�f�[�^�폜
            ComplessSortInit();
        }

        /// <summary>
        /// ���R���[�\�[�g���ʏ����ݒ� ����
        /// </summary>
        /// <remarks>�󎚍��ڐݒ�̓��e�����ɁA�\�[�g�������ݒ�f�[�^�𐶐�����</remarks>
        private void CopyToSortInitFromPrtItem()
        {
            bool createNew = (_ds.Tables[TBL_FPSORTINIT].Rows.Count == 0);


            int sortingOrder = _ds.Tables[TBL_FPSORTINIT].Rows.Count + 1;

            // �󎚍��ڂ���R�s�[����
            foreach ( DataRow itemRow in _ds.Tables[TBL_PRTITEMSET].Rows )
            {
                // DD���̖�������(�Œ蕶��,�����Ȃ�)�͏��O����
                if ( itemRow[COL_PRTITEMSET_DDNAME] == DBNull.Value || string.IsNullOrEmpty( (string)itemRow[COL_PRTITEMSET_DDNAME] ) )
                {
                    continue;
                }

                // �������ڂ͉I��
                if ( CheckExistsSortInit( (int)itemRow[COL_PRTITEMSET_FREEPRTPAPERITEMCD], _ds.Tables[TBL_FPSORTINIT] ) )
                {
                    continue;
                }

                // ���ڒǉ�
                DataRow newRow = _ds.Tables[TBL_FPSORTINIT].NewRow();

                # region [�l�Z�b�g]
                newRow[COL_COMMON_CREATEDATETIME] = itemRow[COL_COMMON_CREATEDATETIME]; // �쐬����
                newRow[COL_COMMON_UPDATEDATETIME] = itemRow[COL_COMMON_UPDATEDATETIME]; // �X�V����
                newRow[COL_COMMON_LOGICALDELETECODE] = itemRow[COL_COMMON_LOGICALDELETECODE]; // �_���폜�敪

                newRow[COL_FPSORTINIT_FREEPRTPPRITEMGRPCD] = itemRow[COL_PRTITEMSET_FREEPRTPPRITEMGRPCD]; // ���R���[���ڃO���[�v�R�[�h
                newRow[COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD] = 0; // ���R���[�X�L�[�}�O���[�v�R�[�h (0:�V�K)
                newRow[COL_FPSORTINIT_SORTINGORDER] = sortingOrder++; // �\�[�g���� (1�`)
                newRow[COL_FPSORTINIT_SORTINGORDERCODE] = itemRow[COL_PRTITEMSET_FREEPRTPAPERITEMCD]; // �\�[�g���ʃR�[�h
                newRow[COL_FPSORTINIT_FREEPRTPAPERITEMNM] = itemRow[COL_PRTITEMSET_FREEPRTPAPERITEMNM]; // ���R���[���ږ���
                newRow[COL_FPSORTINIT_DDNAME] = itemRow[COL_PRTITEMSET_DDNAME]; // DD����
                newRow[COL_FPSORTINIT_FILENM] = itemRow[COL_PRTITEMSET_FILENM]; // �t�@�C������

                if ( createNew )
                {
                    newRow[COL_FPSORTINIT_SORTINGORDERDIVCD] = 0; // �����~���敪 (0:�\�[�g��)
                }
                else
                {
                    newRow[COL_FPSORTINIT_SORTINGORDERDIVCD] = -1; // �����~���敪 (-1:�ݒ�s��)
                }
                # endregion

                _ds.Tables[TBL_FPSORTINIT].Rows.Add( newRow );
            }
        }
        /// <summary>
        /// ���R���[�\�[�g���ʏ����ݒ�̍��ڑ��݃`�F�b�N
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private bool CheckExistsSortInit( int itemCode, DataTable table )
        {
            DataView view = new DataView( table );
            view.RowFilter = string.Format( "{0}='{1}'", COL_FPSORTINIT_SORTINGORDERCODE, itemCode );

            return (view.Count > 0);
        }
        /// <summary>
        /// ���R���[�\�[�g���ʏ����ݒ舳�k�����i�s�v���R�[�h�폜�j
        /// </summary>
        private void ComplessSortInit()
        {
            List<DataRow> deleteRowList = new List<DataRow>();
            DataView view = new DataView( _ds.Tables[TBL_FPSORTINIT] );

            foreach ( DataRowView rowView in view )
            {
                if ( (int)rowView[COL_FPSORTINIT_SORTINGORDERDIVCD] <= -1 )
                {
                    // -1:�ݒ�s�@�͍폜�Ώۂɂ���
                    deleteRowList.Add( rowView.Row );
                }
            }

            // �e�[�u������폜
            foreach ( DataRow row in deleteRowList )
            {
                _ds.Tables[TBL_FPSORTINIT].Rows.Remove( row );
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
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
        public SchemaInfo( string name, string caption, Type type, int length )
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
                if ( string.IsNullOrEmpty( _name ) )
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
                if ( string.IsNullOrEmpty( _caption ) )
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