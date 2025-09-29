//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�o�ו��i�\��
// �v���O�����T�v   : ���q�o�ו��i�\�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/09/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2009/10/20  �C�����e : PM-2-A Redmin#727�A#567�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2009/11/04  �C�����e : PM-2-A Redmin#1105�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : wangf
// �C �� ��  2011/08/02  �C�����e : NS���[�U�[���Ǘv�]�ꗗ_20110629_PM7����_�A��824�ɂ���āA��ʃv���p�e�B���C
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/08/09  �C�����e : 2012/09/12�z�M���ARedmine#31532 ���q�o�ו��i�\�� �\�[�g���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900269-00 �쐬�S�� : FSI���� �G
// �C �� ��  2013/03/25  �C�����e : SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470076-00 �쐬�S��  杍^
// �� �� ��  2019/01/08 �C�����e  �V�����̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Globarization;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���q�o�ו��i�\�� �t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�o�ו��i�\���̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.09.10</br>
    /// <br></br>
    /// <br>Update Note: 2009/10/20 ������</br>
    /// <br>             Redmin#727�A#567�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/04 MANTIS 0014544 ������</br>
    /// <br>             Redmin#1105�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/02 wangf (�\�[�X�L�q�Ȃ�)</br>
    /// <br>             NS���[�U�[���Ǘv�]�ꗗ_20110629_PM7����_�A��824�ɂ���āA��ʃv���p�e�B���C</br>
    /// <br>Update Note: 2012/08/09 ������</br>
    /// <br>             2012/09/12�z�M���ARedmine#31532 ���q�o�ו��i�\�� �\�[�g���s��</br>
    /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
    /// <br>Programmer : FSI���� �G</br>
    /// <br>Date       : 2013/03/25</br>
    /// </remarks>
    public partial class PMSYA04001UA : Form
    {
        #region �� Const Memebers ��

        #region ���q�����O���b�h
        // �e�[�u������
        private const string CARSEARCH_TABLE = "CarSearchTable";
        // �O���b�h�p
        private const string CUSTOMERSUBNAME_KEY = "CustomerSubName";
        private const string MNGNO_KEY = "CarMngNo";
        private const string ENGINEMODEL_KEY = "EngineModel";
        private const string CARADDINFO1_KEY = "CarAddInfo1";
        private const string CARADDINFO2_KEY = "CarAddInfo2";
        private const string INSERTNO_KEY = "InsertNo";
        private const string MILEAGE_KEY = "Mileage";
        private const string CARINSPECTYEAR_KEY = "CarInspectYear";
        private const string ENTRYDATE_KEY = "EntryDate";
        private const string LTIMECIMATDATE_KEY = "LTimeCiMatDate";
        private const string INSPECTMATURITYDATE_KEY = "InspectMaturityDate";
        private const string CARNOTE_KEY = "CarNote";

        // ��ʕ\���p
        private const string CUSTOMERCODE_KEY = "CustomerCode";
        private const string KINDMODEL_KEY = "KindModel";
        private const string MODELDESIGNATIONNO_KEY = "ModelDesignationNo";
        private const string CATEGORYNO_KEY = "CategoryNo";
        private const string ENGINEMODELNM_KEY = "EngineModelNm";
        private const string MAKERCODE_KEY = "MakerCode";
        private const string MODELCODE_KEY = "ModelCode";
        private const string MODELSUBCODE_KEY = "ModelSubCode";
        private const string MODELFULLNAME_KEY = "ModelFullName";
        private const string FULLMODEL_KEY = "FullModel";
        private const string FIRSTENTRYDATE_KEY = "FirstEntryDate";
        private const string STEDPRODUCETYPEOFYEAR_KEY = "StEdProduceTypeOfYear";
        private const string FRAMENO_KEY = "FrameNo";
        private const string STEDPRODUCEFRAMENO_KEY = "StEdProduceFrameNo";
        private const string COLORCODE_KEY = "ColorCode";
        private const string TRIMCODE_KEY = "TrimCode";
        private const string MODELGRADENM_KEY = "ModelGradeNm";
        private const string BODYNAME_KEY = "BodyName";
        private const string DOORCOUNT_KEY = "DoorCount";
        private const string ENGINEDISPLACENM_KEY = "EngineDisplaceNm";
        private const string EDIVNM_KEY = "EDivNm";
        private const string TRANSMISSIONNM_KEY = "TransmissionNm";
        private const string WHEELDRIVEMETHODNM_KEY = "WheelDriveMethodNm";
        private const string SHIFTNM_KEY = "ShiftNm";
        private const string ADDICARSPECTITLE1_KEY = "AddiCarSpecTitle1";
        private const string ADDICARSPECTITLE2_KEY = "AddiCarSpecTitle2";
        private const string ADDICARSPECTITLE3_KEY = "AddiCarSpecTitle3";
        private const string ADDICARSPECTITLE4_KEY = "AddiCarSpecTitle4";
        private const string ADDICARSPECTITLE5_KEY = "AddiCarSpecTitle5";
        private const string ADDICARSPECTITLE6_KEY = "AddiCarSpecTitle6";
        private const string ADDICARSPEC1_KEY = "AddiCarSpec1";
        private const string ADDICARSPEC2_KEY = "AddiCarSpec2";
        private const string ADDICARSPEC3_KEY = "AddiCarSpec3";
        private const string ADDICARSPEC4_KEY = "AddiCarSpec4";
        private const string ADDICARSPEC5_KEY = "AddiCarSpec5";
        private const string ADDICARSPEC6_KEY = "AddiCarSpec6";
        private const string DOMESTICFOREIGNCODERF_KEY = "DomesticForeignCode";�@// ADD 2013/03/25        

        // �e�L�X�g�p
        private const string COLORNAME1_KEY = "ColorName1";
        private const string TRIMNAME_KEY = "TrimName";
        private const string NUMBERPLATE1CODE_KEY = "NumberPlate1Code";
        private const string NUMBERPLATE1NAME_KEY = "NumberPlate1Name";
        private const string NUMBERPLATE2_KEY = "NumberPlate2";
        private const string NUMBERPLATE3_KEY = "NumberPlate3";
        private const string NUMBERPLATE4_KEY = "NumberPlate4";

        // KEY
        private const string CUSTOMERSUBNAME_TITLE = "���Ӑ�";
        private const string MNGNO_TITLE = "�Ǘ��ԍ�";
        private const string ENGINEMODEL_TITLE = "�����@�^��";
        private const string CARADDINFO1_TITLE = "�ǉ����P";
        private const string CARADDINFO2_TITLE = "�ǉ����Q";
        private const string INSERTNO_TITLE = "�o�^�ԍ�";
        private const string MILEAGE_TITLE = "���s����";
        private const string CARINSPECTYEAR_TITLE = "�Ԍ�����";
        private const string ENTRYDATE_TITLE = "�o�^�N����";
        private const string LTIMECIMATDATE_TITLE = "�O��Ԍ���";
        private const string INSPECTMATURITYDATE_TITLE = "����Ԍ���";
        private const string CARNOTE_TITLE = "���q���l";
        private const string CUSTOMERCODE_TITLE = "���Ӑ�R�[�h";
        private const string KINDMODEL_TITLE = "�^��";
        private const string MODELDESIGNATIONNO_TITLE = "�^���w��ԍ�";
        private const string CATEGORYNO_TITLE = "�ޕʔԍ�";
        private const string ENGINEMODELNM_TITLE = "�G���W���^��";
        private const string MAKERCODE_TITLE = "�Ԏ�i���[�J�[�R�[�h�j";
        private const string MODELCODE_TITLE = "�Ԏ�i�Ԏ�R�[�h�j";
        private const string MODELSUBCODE_TITLE = "�Ԏ�i�ď̃R�[�h�j";
        private const string MODELHALFNAME_TITLE = "�Ԏ햼��";
        private const string FULLMODEL_TITLE = "�^���i�t���^�j";
        private const string FIRSTENTRYDATE_TITLE = "�N��";
        private const string STEDPRODUCETYPEOFYEAR_TITLE = "(���Y�N�� �J�n-�I��)";
        private const string FRAMENO_TITLE = "�ԑ�ԍ�";
        private const string STEDPRODUCEFRAMENO_TITLE = "(�ԑ�ԍ� �J�n-�I��)";
        private const string COLORCODE_TITLE = "�J���[";
        private const string TRIMCODE_TITLE = "�g����";
        private const string MODELGRADENM_TITLE = "�^���O���[�h����";
        private const string BODYNAME_TITLE = "�{�f�B�[����";
        private const string DOORCOUNT_TITLE = "�h�A��";
        private const string ENGINEDISPLACENM_TITLE = "�r�C�ʖ���";
        private const string EDIVNM_TITLE = "E�敪����";
        private const string TRANSMISSIONNM_TITLE = "�~�b�V��������";
        private const string WHEELDRIVEMETHODNM_TITLE = "�쓮��������";
        private const string SHIFTNM_TITLE = "�V�t�g����";
        private const string ADDICARSPECTITLE1_TITLE = "�ǉ������^�C�g���P";
        private const string ADDICARSPECTITLE2_TITLE = "�ǉ������^�C�g���Q";
        private const string ADDICARSPECTITLE3_TITLE = "�ǉ������^�C�g���R";
        private const string ADDICARSPECTITLE4_TITLE = "�ǉ������^�C�g���S";
        private const string ADDICARSPECTITLE5_TITLE = "�ǉ������^�C�g���T";
        private const string ADDICARSPECTITLE6_TITLE = "�ǉ������^�C�g���U";
        private const string ADDICARSPEC1_TITLE = "�ǉ������P";
        private const string ADDICARSPEC2_TITLE = "�ǉ������Q";
        private const string ADDICARSPEC3_TITLE = "�ǉ������R";
        private const string ADDICARSPEC4_TITLE = "�ǉ������S";
        private const string ADDICARSPEC5_TITLE = "�ǉ������T";
        private const string ADDICARSPEC6_TITLE = "�ǉ������U";
        private const string COLORNAME1_TITLE = "�J���[����1";
        private const string TRIMNAME_TITLE = "�g��������";
        private const string NUMBERPLATE1CODE_TITLE = "���^�������ԍ�";
        private const string NUMBERPLATE1NAME_TITLE = "���^����������";
        private const string NUMBERPLATE2_TITLE = "�ԗ��o�^�ԍ��i��ʁj";
        private const string NUMBERPLATE3_TITLE = "�ԗ��o�^�ԍ��i�J�i�j";
        private const string NUMBERPLATE4_TITLE = "�ԗ��o�^�ԍ��i�v���[�g�ԍ��j";

        // ����.�ԗ��Ǘ��ԍ�
        private const string MNGNOTEMP_KEY = "CarMngNoTemp";


        #endregion

        #region ���q���O���b�h
        // �e�[�u������
        private const string CARSPEC_TABLE = "CarSpec";
        // �O���b�h�p
        private const string MODELGRADENM_INFO_TITLE = "�O���[�h";
        private const string BODYNAME_INFO_TITLE = "�{�f�B";
        private const string DOORCOUNT_INFO_TITLE = "�h�A";
        private const string ENGINEMODELNM_INFO_TITLE = "�G���W��";
        private const string ENGINEDISPLACENM_INFO_TITLE = "�r�C��";
        private const string EDIVNM_INFO_TITLE = "�d�敪";
        private const string TRANSMISSIONNM_INFO_TITLE = "�~�b�V����";
        private const string WHEELDRIVEMETHODNM_INFO_TITLE = "�쓮����";
        private const string SHIFTNM_INFO_TITLE = "�V�t�g";
        private const string ADDICARSPECTITLE1_INFO_TITLE = "�ǉ������^�C�g���P";
        private const string ADDICARSPECTITLE2_INFO_TITLE = "�ǉ������^�C�g���Q";
        private const string ADDICARSPECTITLE3_INFO_TITLE = "�ǉ������^�C�g���R";
        private const string ADDICARSPECTITLE4_INFO_TITLE = "�ǉ������^�C�g���S";
        private const string ADDICARSPECTITLE5_INFO_TITLE = "�ǉ������^�C�g���T";
        private const string ADDICARSPECTITLE6_INFO_TITLE = "�ǉ������^�C�g���U";
        #endregion

        #region �o�ו��i�O���b�h
        // �e�[�u������
        private const string CARPARTS_TABLE = "CarParts";
        // �O���b�h�p
        private const string SALESDATE_KEY = "SalesDate";
        private const string GOODSNAME_KEY = "GoodsName";
        private const string GOODSNO_KEY = "GoodsNo";
        private const string GOODSMAKERNAME_KEY = "MakerName";
        private const string BLGOODSCD_KEY = "BLGoodsCd";
        private const string SALESORDERDIVCD_KEY = "SaleSorderDivCd";
        private const string LISTPRICETAXEXCFL_KEY = "ListPriceTaxExcFl";
        private const string SHIPMENTCNT_KEY = "ShipmentCnt";
        private const string SALESUNPRCTAXEXCFL_KEY = "SalesUnPrcTaxExcFl";
        private const string SALESMONEYTAXEXC_KEY = "SalesMoneyTaxExc";
        private const string SALESUNITCOST_KEY = "SalesUnitCost";
        private const string SALESMONEYTAXEXC_COST_KEY = "SalesUnCost";
        private const string COST_SALESMONEYTAXEXC_KEY = "SalesUnCostPer";
        private const string SLIPNOTE_KEY = "SlipNote";
        private const string CARNOTE_PARTS_KEY = "CarNote";
        private const string SALESSLIPNUM_KEY = "SalesSlipNum";
        private const string MILEAGE_PARTS_KEY = "Mileage";
        private const string MODEL1TO2_KEY = "Model1To2";
        private const string ROWNO_KEY = "RowNo"; // ADD BY �����@on 2012/08/09 for Redmine#31532

        private const string GOODSMAKERCD_KEY = "GoodsMakerCd";
        private const string STPRODUCEFRAMENO_KEY = "StProduceFrameNo";
        private const string EDPRODUCEFRAMENO_KEY = "EdProduceFrameNo";
        private const string STPRODUCETYPEOFYEAR_KEY = "StProduceTypeOfYear";
        private const string EDPRODUCETYPEOFYEAR_KEY = "EdProduceTypeOfYear";

        // �O���b�h�p
        private const string SALESDATE_TITLE = "�`�[���t";
        private const string GOODSNAME_TITLE = "�i��";
        private const string ROWNO_TITLE = "�s�ԍ�"; // ADD BY �����@on 2012/08/09 for Redmine#31532
        private const string GOODSNO_TITLE = "�i��";
        private const string GOODSMAKERCD_TITLE = "���[�J�[";
        private const string BLGOODSCODE_TITLE = "BL�R�[�h";
        private const string SALESORDERDIVCD_TITLE = "�݌Ɏ��敪";
        private const string LISTPRICETAXEXCFL_TITLE = "�W�����i";
        private const string SHIPMENTCNT_TITLE = "����";
        private const string SALESUNPRCTAXEXCFL_TITLE = "���P��";
        private const string SALESMONEYTAXEXC_TITLE = "������z";
        private const string SALESUNITCOST_TITLE = "���P��";
        private const string SALESMONEYTAXEXC_COST_TITLE = "�e��";
        private const string COST_SALESMONEYTAXEXC_TITLE = "�e����";
        private const string SLIPNOTE_TITLE = "���l";
        private const string CARNOTE_PARTS_TITLE = "���q���l";
        private const string SALESSLIPNUM_TITLE = "�`�[�ԍ�";
        private const string MILEAGE_PARTS_TITLE = "���s����";
        private const string MODEL1TO2_TITLE = "�^��1-2";

        #endregion

        #region �o�ו��i�i���v�j�O���b�h
        // �e�[�u������
        private const string CARPARTSTOTAL_TABLE = "CarPartsTotal";
        // �O���b�h�p
        private const string GOODSNAME_TOTAL_KEY = "GoodsName";
        private const string GOODSNO_TOTAL_KEY = "GoodsNo";
        private const string GOODSMAKERNAME_TOTAL_KEY = "GoodsMakerName";
        private const string BLGOODSCODE_TOTAL_KEY = "BLGoodsCode";
        private const string SHIPMENTCNT_TOTAL_KEY = "ShipmentCnt";
        private const string SALESMONEYTAXEXC_TOTAL_KEY = "SalesMoneyTaxExc";
        private const string COUNT_TOTAL_KEY = "CountTotal";
        private const string WAREHOUSE_TOTAL_KEY = "WareHouseName";
        private const string SHELFNO_TOTAL_KEY = "ShelfNo";
        private const string SHIPMENTPOSCNT_TOTAL_KEY = "ShipmentPosCnt";
        private const string SHIPMENTCNTIN_TOTAL_KEY = "ShipmentInPosCnt";
        private const string SHIPMENTCNTOUT_TOTAL_KEY = "ShipmentOutPosCnt";


        private const string WAREHOUSECODE_TOTAL_KEY = "WareHouseCode";
        private const string GOODSMAKERCD_TOTAL_KEY = "GoodsMakerCd";

        private const string GOODSNAME_TOTAL_TITLE = "�i��";
        private const string GOODSNO_TOTAL_TITLE = "�i��";
        private const string GOODSMAKERCD_TOTAL_TITLE = "���[�J�[";
        private const string BLGOODSCODE_TOTAL_TITLE = "BL�R�[�h";
        private const string SHIPMENTCNT_TOTAL_TITLE = "����";
        private const string SALESMONEYTAXEXC_TOTAL_TITLE = "������z";
        private const string COUNT_TOTAL_TITLE = "�o�׉�";
        private const string WAREHOUSE_TOTAL_TITLE = "�q��";
        private const string SHELFNO_TOTAL_TITLE = "�I��";
        private const string SHIPMENTPOSCNT_TOTAL_TITLE = "���݌ɐ�";
        private const string SHIPMENTCNTIN_TOTAL_TITLE = "���ʁi�݌Ɂj";
        private const string SHIPMENTCNTOUT_TOTAL_TITLE = "���ʁi���j";


        #endregion

        #region ���̑��ݒ�
        /// <summary>�`�F�b�N�����b�Z�[�W�u���㌎�������擾�̏��������ŃG���[���������܂����B�v</summary>
        private const string MSG_TOTALDAY_INITIALIE_FAILED = "���㌎�������擾�̏��������ŃG���[���������܂����B";

        /// <summary>�N���A�m�F���b�Z�[�W�u�\�����e�����������Ă�낵���ł����H�v</summary>
        private const string MSG_CONFIRM_CLEARINPUT = "�\�����e�����������Ă�낵���ł����H";

        /// <summary>���l�敪201</summary>
        private const int SLIPNOTE_DIV = 201;

        // --- ADD 2013/03/25 ---------->>>>>
        /// <summary>���Y/�O�ԋ敪(�O��:2)</summary>
        private const int FOREIGNCODERF_DIV = 2;
        // --- ADD 2013/03/25 ----------<<<<<

        /// <summary>�����܂������u�ƈ�v�v�X�e�[�^�X</summary>
        private const int CT_FUZZY_MATCHWITH = 0;
        /// <summary>�����܂������u�Ŏn��v�X�e�[�^�X</summary>
        private const int CT_FUZZY_STARTWITH = 1;
        /// <summary>�����܂������u���܂ށv�X�e�[�^�X</summary>
        private const int CT_FUZZY_INCLUDEWITH = 2;
        /// <summary>�����܂������u�ŏI��v�X�e�[�^�X</summary>
        private const int CT_FUZZY_ENDWITH = 3;

        /// <summary>�\���F�����t�H���g�T�C�Y</summary>
        private const int CT_DEF_FONT_SIZE = 11;

        /// <summary>yyyy/MM/dd</summary>
        private const string DATEFORMAT_YYYYMMDD = "yyyy/MM/dd";
        /// <summary>yyyy.MM</summary>
        private const string DATEFORMAT_YYYYMM = "yyyy.MM";
        /// <summary>���_�R�[�h(�S��)</summary>
        public const string ctSectionCode = "00";
        // �v���O����ID
        private const string CT_PGID = "PMSYA04000U";
        #endregion

        #endregion

        # region �� �O��l�ێ� ��
        /// <summary>
        /// �O��l�ێ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O��l�ێ��ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private struct PrevInputValue
        {
            /// <summary>���_�R�[�h</summary>
            private string _sectionCode;
            /// <summary>���Ӑ�R�[�h</summary>
            private int _customerCode;

            /// <summary>
            /// ���_�R�[�h
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// ���Ӑ�R�[�h
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
        }
        # endregion

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        public PMSYA04001UA()
        {
            InitializeComponent();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._textOutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_TextOut"];
            this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Search"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._LoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._controlScreenSkin = new ControlScreenSkin();
            this._carPartDisplayAcs = CarPartDisplayAcs.GetInstance();
            this._tCalcAcs = TotalDayCalculator.GetInstance();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._carMngInputAcs = CarMngInputAcs.GetInstance();
            this._noteGuidAcs = new NoteGuidAcs();
            // ���t�擾���i
            _dateGetAcs = DateGetAcs.GetInstance();
            // �ϐ�������
            this.carSearchTable = new DataTable(CARSEARCH_TABLE);
            this.carSpecTable = new DataTable(CARSPEC_TABLE);
            this.carPartsTable = new DataTable(CARPARTS_TABLE);
            this.carPartsTotalTable = new DataTable(CARPARTSTOTAL_TABLE);

            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
        }
        # endregion

        # region �� private field ��
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _textOutButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _LoginTitleLabel;
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginName = LoginInfoAcquisition.Employee.Name;
        private string _loginSectionCode = string.Empty;
        private DataTable carSearchTable;
        private DataTable carSpecTable;
        private DataTable carPartsTable;
        private DataTable carPartsTotalTable;
        private CarPartDisplayAcs _carPartDisplayAcs;
        private AllDefSet _allDefSet;
        /// <summary>PMKHN09012A)���Ӑ�</summary>
        private CustomerInfoAcs _customerInfoAcs;
        private CustomerSearchAcs _customerSearchAcs;
        /// <summary>SFKTN09002A)���_</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary>DCKHN09092A)BL�R�[�h</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;
        /// <summary>PMKHN09062A)BL�O���[�v</summary>
        private BLGroupUAcs _blGroupUAcs;
        /// <summary>MAKHN09332A)�q��</summary>
        private WarehouseAcs _warehouseAcs;
        /// <summary>PMSYA09024A)�Ǘ��ԍ�</summary>
        private CarMngInputAcs _carMngInputAcs;
        /// <summary>SFTOK9402)���l�ݒ�</summary>
        private NoteGuidAcs _noteGuidAcs;
        /// <summary>���t�擾���i</summary>
        private DateGetAcs _dateGetAcs;
        // **** ���ߓ��֘A ****
        /// <summary>���ߓ��擾�p�N���X</summary>
        TotalDayCalculator _tCalcAcs = null;
        /// <summary>�����������</summary>
        private DateTime _currentTotalDay;
        /// <summary>�����������</summary>
        private DateTime _currentTotalMonth;
        /// <summary>�O���������</summary>
        private DateTime _prevTotalDay;
        /// <summary>�O���������</summary>
        private DateTime _prevTotalMonth;
        // **** �R���g���[�� ****
        private Control _prevControl;
        /// <summary>�O����͒l</summary>
        private PrevInputValue _prevInputValue;

        // **** �R�[�h�������̂�؂�ւ��鍀�ڗp ****
        /// <summary>BL�O���[�v�R�[�h</summary>
        private int _swBLGroupCode = 0;
        /// <summary>BL�O���[�v��</summary>
        private string _swBLGroupName = string.Empty;
        /// <summary>BL�R�[�h</summary>
        private int _swBLGoodsCode = 0;
        /// <summary>BL�R�[�h��</summary>
        private string _swBLGoodsName = string.Empty;
        /// <summary>�q�ɃR�[�h</summary>
        private string _swWarehouseCd = string.Empty;
        /// <summary>�q�ɖ�</summary>
        private string _swWarehouseName = string.Empty;
        /// <summary>�i��</summary>
        private string _srGoodsName = string.Empty;
        /// <summary>�i��(*����������)</summary>
        private string _srRvGoodsName = string.Empty;
        /// <summary>�i��</summary>
        private string _srGoodsNo = string.Empty;
        /// <summary>�i��(*����������)</summary>
        private string _srRvGoodsNo = string.Empty;
        /// <summary>���q���l</summary>
        private string _srCarNote = string.Empty;
        /// <summary>���q���l(*����������)</summary>
        private string _srRvCarNote = string.Empty;
        /// <summary>�Ǘ��ԍ�</summary>
        private string _srCarMngNo = string.Empty;
        /// <summary>�Ǘ��ԍ�(*����������)</summary>
        private string _srRvCarMngNo = string.Empty;
        /// <summary>�^��</summary>
        private string _srFullModel = string.Empty;
        /// <summary>�^��(*����������)</summary>
        private string _srRvFullModel = string.Empty;
        /// <summary>�ԗ��Ǘ��ԍ�</summary>
        private int _carMngNoTemp = 0;
        /// <summary>���Ӑ�R�[�h</summary>
        private int _customerCode = 0;
        /// <summary>�^��</summary>
        private string _fullModel = string.Empty;
        /// <summary>�^���̍i������</summary>
        private int _fullModelCon = 0;
        /// <summary>�Ǘ��ԍ�</summary>
        private string _carMngNo = string.Empty;
        /// <summary>�Ǘ��ԍ��̍i������</summary>
        private int _carMngNoCon = 0;

        // **** �����T�C�Y ****
        /// <summary>�����T�C�Y</summary>
        private readonly int[] _fontpitchSize = new int[] { 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24 };

        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;

        # endregion

        #region �� �R���g���[���C�x���g ��
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void PMSYA04001UA_Load(object sender, EventArgs e)
        {
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            excCtrlNm.Add(this.uGroupBox_ExtractCondition.Name);
            excCtrlNm.Add(this.uGroupBox_CarInfo.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            // ��ʃC���[�W����
            this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            // ���O�C���S���҂̐ݒ�
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // �����擾��������
            GetHisTotalDayProc();

            // �ϐ��Ȃǂ�������
            InitializeVariable();
            ReadInitData(_enterpriseCode);

            // ��ʂ̏���������
            InitializeControl();

            // ���Ӑ�}�X�^�Ǎ�����
            LoadCustomerSearchRet();
        }
        #endregion

        #region �� ���Ӑ挟���}�X�^�Ǎ����� ��
        /// <summary>
        /// ���Ӑ挟���}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ挟���}�X�^�Ǎ��������s��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void LoadCustomerSearchRet()
        {
            CustomerSearchPara para = new CustomerSearchPara();
            para.EnterpriseCode = this._enterpriseCode;

            CustomerSearchRet[] retList;

            int status = this._customerSearchAcs.Serch(out retList, para);
            if (status == 0)
            {
                foreach (CustomerSearchRet ret in retList)
                {
                    if (ret.LogicalDeleteCode == 0 && !this._customerSearchRetDic.ContainsKey(ret.CustomerCode))
                    {
                        this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                    }
                }
            }
        }
        #endregion

        #region �� �����擾�������� ��
        /// <summary>
        /// �����擾��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����擾���������ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void GetHisTotalDayProc()
        {
            int status;

            // �����擾�O��������
            status = _tCalcAcs.InitializeHisMonthlyAccRec();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���񂨂�ёO��̒��ߓ�/�����擾(���Ɠ��͈قȂ�ꍇ������)
                status = _tCalcAcs.GetHisTotalDayMonthlyAccRec(this._loginSectionCode, out this._prevTotalDay, out this._currentTotalDay, out this._prevTotalMonth, out this._currentTotalMonth);

                if (_prevTotalDay == DateTime.MinValue)
                {
                    DateTime today = DateTime.Today;
                    this.tDateEdit_SalesDateSt.SetDateTime(today);
                    this.tDateEdit_SalesDateEd.SetDateTime(today);
                }
                else
                {
                    this.tDateEdit_SalesDateSt.SetDateTime(this._prevTotalDay.AddDays(1));
                    this.tDateEdit_SalesDateEd.SetDateTime(DateTime.Today);

                    if (this._prevTotalDay.AddDays(1) > DateTime.Today)
                    {
                        this.tDateEdit_SalesDateEd.SetDateTime(this._prevTotalDay.AddDays(1));
                    }
                }
            }
            else
            {
                // �����������s
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    MSG_TOTALDAY_INITIALIE_FAILED, -1, MessageBoxButtons.OK);
            }
        }
        #endregion

        #region �� �N���A���� ��
        /// <summary>
        /// �N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���A�����ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void Clear()
        {
            // �m�F�_�C�A���O
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, this.Name,
                MSG_CONFIRM_CLEARINPUT,
                -1, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            // �\���敪�����q������\������
             this.tComboEditor_DisplayDiv.SelectedIndex = 0;
            // ���o�����́u������v�u���͓��v����͕s�ɕύX����B
            this.tDateEdit_SalesDateSt.Enabled = false;
            this.tDateEdit_SalesDateEd.Enabled = false;
            this.tDateEdit_AddUpADateSt.Enabled = false;
            this.tDateEdit_AddUpADateEd.Enabled = false;
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.uLabel_SectionNm.Text = "�S��";
            this.tEdit_SectionCodeAllowZero.Enabled = false;
            this.uButton_SectionGuide.Enabled = false;

            this.tEdit_BlGroupCode.Text = string.Empty;
            this.tEdit_BlGoodsCode.Text = string.Empty;
            this.tEdit_GoodsName.Text = string.Empty;
            this.tComboEditor_GoodsNameFuzzy.SelectedIndex = 0;
            this.tEdit_GoodsNo.Text = string.Empty;
            this.tComboEditor_GoodsNoFuzzy.SelectedIndex = 0;
            this.tComboEditor_SalesOrderDivCd.SelectedIndex = 0;
            this.tEdit_WarehouseCd.Text = string.Empty;

            this.uGroupBox_CarInfo.Expanded = true;
            // ���o�����g���ŏ���
            this.uGroupBox_ExtractCondition.Expanded = false;
            this.tEdit_BlGroupCode.Enabled = false;
            this.uButton_BlGroupCode.Enabled = false;
            this.tEdit_BlGoodsCode.Enabled = false;
            this.uButton_BlGoodsCode.Enabled = false;
            this.tEdit_GoodsName.Enabled = false;
            this.tComboEditor_GoodsNameFuzzy.Enabled = false;
            this.tEdit_GoodsNo.Enabled = false;
            this.tComboEditor_GoodsNoFuzzy.Enabled = false;
            this.tComboEditor_SalesOrderDivCd.Enabled = false;
            this.tEdit_WarehouseCd.Enabled = false;
            this.uButton_WarehouseCd.Enabled = false;

            this.GetHisTotalDayProc();

            this.tDateEdit_AddUpADateSt.Clear();
            this.tDateEdit_AddUpADateEd.Clear();
            this.tNedit_CustomerCode.Text = string.Empty;
            this.uLabel_CustomerName.Text = string.Empty;
            this.tEdit_FullModel.Text = string.Empty;
            this.tComboEditor_FullModelFuzzy.SelectedIndex = 1;
            this.tEdit_CarMngCode.Text = string.Empty;
            // this.tComboEditor_CarMngCode.SelectedIndex = 1;// DEL 2009/10/19 Redmine#704
            this.tComboEditor_CarMngCode.SelectedIndex = 0;// ADD 2009/10/19 Redmine#704
            this.tEdit_SlipNote.Text = string.Empty;
            this.tComboEditor_SlipNoteFuzzy.SelectedIndex = 0;
            this.CarInfoClear();

            this.carSpecTable.Clear();
            this.carSearchTable.Clear();
            this.carPartsTable.Clear();
            this.carPartsTotalTable.Clear();

            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
            this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;

            this.uGrid_CarSearchList.Visible = true;
            this.uGrid_CarPartsTotalList.Visible = false;
            this.uGrid_CarPartsList.Visible = false;

            // �e�L�X�g�o��
            this._textOutButton.SharedProps.Enabled = false;

            this.tEdit_FullModel.Appearance.BackColor = System.Drawing.Color.White;

            this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = false;
            autoColumnAdjust(false, 0);
            #region �R�[�h�������̂�؂�ւ��鍀�ڗp �N���A
            this._prevInputValue.CustomerCode = 0;
            this._prevInputValue.SectionCode = string.Empty;
            // **** �R�[�h�������̂�؂�ւ��鍀�ڗp �N���A****
            this._swBLGroupCode = 0;
            this._swBLGroupName = string.Empty;
            this._swBLGoodsCode = 0;
            this._swBLGoodsName = string.Empty;
            this._swWarehouseCd = string.Empty;
            this._swWarehouseName = string.Empty;
            this._srGoodsName = string.Empty;
            this._srRvGoodsName = string.Empty;
            this._srGoodsNo = string.Empty;
            this._srRvGoodsNo = string.Empty;
            this._srCarNote = string.Empty;
            this._srRvCarNote = string.Empty;
            this._srCarMngNo = string.Empty;
            this._srRvCarMngNo = string.Empty;
            this._srFullModel = string.Empty;
            this._srRvFullModel = string.Empty;
            this._carMngNoTemp = 0;
            this._customerCode = 0;
            this._fullModel = string.Empty;
            this._fullModelCon = 0;
            this._carMngNo = string.Empty;
            this._carMngNoCon = 0;
            #endregion

            #region ���q���O���b�h�f�[�^
            DataRow dataRow;
            dataRow = this.carSpecTable.NewRow();
            dataRow[MODELGRADENM_INFO_TITLE] = string.Empty;
            dataRow[BODYNAME_INFO_TITLE] = string.Empty;
            dataRow[DOORCOUNT_INFO_TITLE] = string.Empty;
            dataRow[ENGINEMODELNM_INFO_TITLE] = string.Empty;
            dataRow[ENGINEDISPLACENM_INFO_TITLE] = string.Empty;
            dataRow[EDIVNM_INFO_TITLE] = string.Empty;
            dataRow[TRANSMISSIONNM_INFO_TITLE] = string.Empty;
            dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = string.Empty;
            dataRow[SHIFTNM_INFO_TITLE] = string.Empty;

            this.carSpecTable.Rows.Add(dataRow);

            this.uGrid_CarSpec.Refresh();
            #endregion
        }
        /// <summary>
        /// ���q���̃N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�����N���A���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void CarInfoClear()
        {
            this.uLabel_ModelDesignationNoData.Text = string.Empty;
            this.uLabel_ModelKindNo.Text = string.Empty;
            this.uLabel_EngineModelNmData.Text = string.Empty;
            this.uLabel_FullModelTitleInfoData.Text = string.Empty;
            this.uLabel_ModelMaker.Text = string.Empty;
            this.uLabel_ModelCode.Text = string.Empty;
            this.uLabel_ModelSubCode.Text = string.Empty;
            this.uLabel_ModelName.Text = string.Empty;
            this.tDateEdit_FirstEntryDate.Clear();
            this.uLabel_FirstEntryDateRange.Text = string.Empty;
            this.uLabel_ColorNoData.Text = string.Empty;
            this.uLabel_ProduceFrameNoData.Text = string.Empty;
            this.uLabel_ProduceFrameNoRange.Text = string.Empty;
            this.uLabel_TrimNoData.Text = string.Empty;
            this.uLabel_CarMngCodeData.Text = string.Empty;// ADD 2009/10/10

        }
        #endregion

        #region �� ���������� ��
        /// <summary>
        /// ����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����������ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void InitializeControl()
        {
            // �\���敪�����q������\������
            this.tComboEditor_DisplayDiv.SelectedIndex = 0;
            // ���o�����́u������v�u���͓��v����͕s�ɕύX����B
            this.tDateEdit_SalesDateSt.Enabled = false;
            this.tDateEdit_SalesDateEd.Enabled = false;
            this.tDateEdit_AddUpADateSt.Enabled = false;
            this.tDateEdit_AddUpADateEd.Enabled = false;
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.Text = "00";
            this.uLabel_SectionNm.Text = "�S��";
            this.tEdit_SectionCodeAllowZero.Enabled = false;
            this.uButton_SectionGuide.Enabled = false;
            // �Ǘ��ԍ������敪:�Ŏn�܂�
            // this.tComboEditor_CarMngCode.SelectedIndex = 1;// DEL 2009/10/19 Redmine#704
            this.tComboEditor_CarMngCode.SelectedIndex = 0;//  ADD 2009/10/19 Redmine#704
            // �^�������敪:�Ŏn�܂�
            this.tComboEditor_FullModelFuzzy.SelectedIndex = 1;
            // ���o�����g���ŏ���
            this.uGroupBox_ExtractCondition.Expanded = false;
            this.tEdit_BlGroupCode.Enabled = false;
            this.uButton_BlGroupCode.Enabled = false;
            this.tEdit_BlGoodsCode.Enabled = false;
            this.uButton_BlGoodsCode.Enabled = false;
            this.tEdit_GoodsName.Enabled = false;
            this.tComboEditor_GoodsNameFuzzy.Enabled = false;
            this.tEdit_GoodsNo.Enabled = false;
            this.tComboEditor_GoodsNoFuzzy.Enabled = false;
            this.tComboEditor_SalesOrderDivCd.Enabled = false;
            this.tEdit_WarehouseCd.Enabled = false;
            this.uButton_WarehouseCd.Enabled = false;
            // �o�ו��i�O���b�h
            this.uGrid_CarPartsTotalList.Visible = false;
            // �o�ו��i�i���v�j�O���b�h
            this.uGrid_CarPartsList.Visible = false;
            // �e�L�X�g�o��
            this._textOutButton.SharedProps.Enabled = false;
            // �N��
            // 0:����
            if (this._allDefSet.EraNameDispCd1 == 0)
            {
                this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.df4Y2M;
            }
            // 1:�a��
            else
            {
                this.tDateEdit_FirstEntryDate.DateFormat = emDateFormat.dfG2Y2M;
            }
            
            this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = false;
            autoColumnAdjust(false, 0);
        }

        /// <summary>
        /// �v���C�x�[�g���x���̕ϐ��Ȃǂ�����������я����擾
        /// </summary>
        /// <remarks>
        /// <br>Note       : �v���C�x�[�g���x���̕ϐ��Ȃǂ�����������я����擾�����ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void InitializeVariable()
        {
            // �����T�C�Y�ݒ�
            for (int i = 0; i < this._fontpitchSize.Length; i++)
            {
                this.tComboEditor_StatusBar_FontSize.Items.Add(this._fontpitchSize[i], this._fontpitchSize[i].ToString());
            }
            this.tComboEditor_StatusBar_FontSize.SelectedIndex = 4;
            // �O���b�h���쐬
            // �O���b�h�񏉊��ݒ菈��
            InitializeGridColumns(this.uGrid_CarSearchList.DisplayLayout.Bands[0].Columns, 0);
            InitializeGridColumns(this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns, 1);
            InitializeGridColumns(this.uGrid_CarPartsList.DisplayLayout.Bands[0].Columns, 2);
            InitializeGridColumns(this.uGrid_CarPartsTotalList.DisplayLayout.Bands[0].Columns, 3);
        }

        #region �{�^�������ݒ菈��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._textOutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this.uButton_SectionGuide.ImageList = this._imageList16;
            this.uButton_SectionGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGoodsCode.ImageList = this._imageList16;
            this.uButton_BlGoodsCode.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_BlGroupCode.ImageList = this._imageList16;
            this.uButton_BlGroupCode.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_SlipNote.ImageList = this._imageList16;
            this.uButton_SlipNote.Appearance.Image = (int)Size16_Index.STAR1;
            this.uButton_WarehouseCd.ImageList = this._imageList16;
            this.uButton_WarehouseCd.Appearance.Image = (int)Size16_Index.STAR1;
            this.CarMngCode_Button.ImageList = this._imageList16;
            this.CarMngCode_Button.Appearance.Image = (int)Size16_Index.STAR1;
        }
        # endregion �� �{�^�������ݒ菈�� ��

        #endregion

        #region �� �O���b�h�쐬 ��
        /// <summary>
        /// �O���b�h��̏�����
        /// </summary>
        /// <param name="Columns">�O���b�h��</param>
        /// <param name="tabNo">�e�[�u���ԍ�</param>
        /// <remarks>
        /// <br>Note       : �O���b�h��̏����������ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.09.10</br>
        /// <br>Update Note: SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
        /// <br>Programmer : FSI���� �G</br>
        /// <br>Date       : 2013/03/25</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns, int tabNo)
        {
            // �\���`���̂����Ŏg�p
            //string formatCount = "#,##0;-#,##0;'0'";
            //string formatCurrency = "#,##0;-#,##0;";
            //string formatFraction = "#,##0.00;-#,##0.00;";
            //string formatDate = "yyyy/MM/dd";

            switch (tabNo)
            {
                case 0:
                    {
                        #region ���q�����O���b�h

                        this.carSearchTable.BeginLoadData();
                        // �I���`�F�b�N�{�b�N�X
                        // ���Ӑ�
                        this.carSearchTable.Columns.Add(CUSTOMERSUBNAME_KEY, typeof(string));
                        // �Ǘ��ԍ�
                        this.carSearchTable.Columns.Add(MNGNO_KEY, typeof(string));
                        // �����@�^��
                        this.carSearchTable.Columns.Add(ENGINEMODEL_KEY, typeof(string));
                        // �ǉ����P
                        this.carSearchTable.Columns.Add(CARADDINFO1_KEY, typeof(string));
                        // �ǉ����Q
                        this.carSearchTable.Columns.Add(CARADDINFO2_KEY, typeof(string));
                        // �o�^�ԍ�
                        this.carSearchTable.Columns.Add(INSERTNO_KEY, typeof(string));
                        // ���s����
                        this.carSearchTable.Columns.Add(MILEAGE_KEY, typeof(string));
                        // �Ԍ�����
                        this.carSearchTable.Columns.Add(CARINSPECTYEAR_KEY, typeof(string));
                        // �o�^�N����
                        this.carSearchTable.Columns.Add(ENTRYDATE_KEY, typeof(string));
                        // �O��Ԍ���
                        this.carSearchTable.Columns.Add(LTIMECIMATDATE_KEY, typeof(string));
                        // ����Ԍ���
                        this.carSearchTable.Columns.Add(INSPECTMATURITYDATE_KEY, typeof(string));
                        // ���q���l
                        this.carSearchTable.Columns.Add(CARNOTE_KEY, typeof(string));

                        // ��ʕ\���p
                        // ���Ӑ�R�[�h
                        this.carSearchTable.Columns.Add(CUSTOMERCODE_KEY, typeof(string));
                        // �^��
                        this.carSearchTable.Columns.Add(KINDMODEL_KEY, typeof(string));
                        // �^���w��ԍ�
                        this.carSearchTable.Columns.Add(MODELDESIGNATIONNO_KEY, typeof(string));
                        // �ޕʔԍ�
                        this.carSearchTable.Columns.Add(CATEGORYNO_KEY, typeof(string));
                        // �G���W���^��
                        this.carSearchTable.Columns.Add(ENGINEMODELNM_KEY, typeof(string));
                        // �Ԏ�i���[�J�[�R�[�h�j
                        this.carSearchTable.Columns.Add(MAKERCODE_KEY, typeof(string));
                        // �Ԏ�i�Ԏ�R�[�h�j
                        this.carSearchTable.Columns.Add(MODELCODE_KEY, typeof(string));
                        // �Ԏ�i�ď̃R�[�h�j
                        this.carSearchTable.Columns.Add(MODELSUBCODE_KEY, typeof(string));
                        // �Ԏ햼��
                        this.carSearchTable.Columns.Add(MODELFULLNAME_KEY, typeof(string));
                        // �^���i�t���^�j
                        this.carSearchTable.Columns.Add(FULLMODEL_KEY, typeof(string));
                        // �N��
                        this.carSearchTable.Columns.Add(FIRSTENTRYDATE_KEY, typeof(string));
                        // (���Y�N�� �J�n-�I��)
                        this.carSearchTable.Columns.Add(STEDPRODUCETYPEOFYEAR_KEY, typeof(string));
                        // �ԑ�ԍ�
                        this.carSearchTable.Columns.Add(FRAMENO_KEY, typeof(string));
                        // (�ԑ�ԍ� �J�n-�I��)
                        this.carSearchTable.Columns.Add(STEDPRODUCEFRAMENO_KEY, typeof(string));
                        // �J���[
                        this.carSearchTable.Columns.Add(COLORCODE_KEY, typeof(string));
                        // �g����
                        this.carSearchTable.Columns.Add(TRIMCODE_KEY, typeof(string));
                        // �^���O���[�h����
                        this.carSearchTable.Columns.Add(MODELGRADENM_KEY, typeof(string));
                        // �{�f�B�[����
                        this.carSearchTable.Columns.Add(BODYNAME_KEY, typeof(string));
                        // �h�A��
                        this.carSearchTable.Columns.Add(DOORCOUNT_KEY, typeof(string));
                        // �G���W���^������
                        //this.carSearchTable.Columns.Add(ENGINEMODELNM_TITLE, typeof(string));
                        // �r�C�ʖ���
                        this.carSearchTable.Columns.Add(ENGINEDISPLACENM_KEY, typeof(string));
                        // E�敪����
                        this.carSearchTable.Columns.Add(EDIVNM_KEY, typeof(string));
                        // �~�b�V��������
                        this.carSearchTable.Columns.Add(TRANSMISSIONNM_KEY, typeof(string));
                        // �쓮��������
                        this.carSearchTable.Columns.Add(WHEELDRIVEMETHODNM_KEY, typeof(string));
                        // �V�t�g����
                        this.carSearchTable.Columns.Add(SHIFTNM_KEY, typeof(string));
                        // �ǉ������^�C�g���P
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE1_KEY, typeof(string));
                        // �ǉ������^�C�g���Q
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE2_KEY, typeof(string));
                        // �ǉ������^�C�g���R
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE3_KEY, typeof(string));
                        // �ǉ������^�C�g���S
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE4_KEY, typeof(string));
                        // �ǉ������^�C�g���T
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE5_KEY, typeof(string));
                        // �ǉ������^�C�g���U
                        this.carSearchTable.Columns.Add(ADDICARSPECTITLE6_KEY, typeof(string));
                        // �ǉ������P
                        this.carSearchTable.Columns.Add(ADDICARSPEC1_KEY, typeof(string));
                        // �ǉ������Q
                        this.carSearchTable.Columns.Add(ADDICARSPEC2_KEY, typeof(string));
                        // �ǉ������R
                        this.carSearchTable.Columns.Add(ADDICARSPEC3_KEY, typeof(string));
                        // �ǉ������S
                        this.carSearchTable.Columns.Add(ADDICARSPEC4_KEY, typeof(string));
                        // �ǉ������T
                        this.carSearchTable.Columns.Add(ADDICARSPEC5_KEY, typeof(string));
                        // �ǉ������U
                        this.carSearchTable.Columns.Add(ADDICARSPEC6_KEY, typeof(string));
                        // --- ADD 2013/03/25 ---------->>>>>
                        // ���Y/�O�ԋ敪
                        this.carSearchTable.Columns.Add(DOMESTICFOREIGNCODERF_KEY, typeof(string));
                        // --- ADD 2013/03/25 ----------<<<<<

                        // �e�L�X�g�p
                        // �J���[����1
                        this.carSearchTable.Columns.Add(COLORNAME1_KEY, typeof(string));
                        // �g��������
                        this.carSearchTable.Columns.Add(TRIMNAME_KEY, typeof(string));
                        // ���^�������ԍ�
                        this.carSearchTable.Columns.Add(NUMBERPLATE1CODE_KEY, typeof(string));
                        // ���^�����ǖ���
                        this.carSearchTable.Columns.Add(NUMBERPLATE1NAME_KEY, typeof(string));
                        // �ԗ��o�^�ԍ��i��ʁj
                        this.carSearchTable.Columns.Add(NUMBERPLATE2_KEY, typeof(string));
                        // �ԗ��o�^�ԍ��i�J�i�j
                        this.carSearchTable.Columns.Add(NUMBERPLATE3_KEY, typeof(string));
                        // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        this.carSearchTable.Columns.Add(NUMBERPLATE4_KEY, typeof(string));

                        // �ԗ��Ǘ��ԍ�
                        this.carSearchTable.Columns.Add(MNGNOTEMP_KEY, typeof(string));

                        this.carSearchTable.EndLoadData();

                        this.uGrid_CarSearchList.DataSource = carSearchTable;

                        #endregion

                        #region ���q�����O���b�h
                        this.uGrid_CarSearchList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
                        this.uGrid_CarSearchList.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;


                        Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarSearchList.DisplayLayout.Bands[0];
                        if (editBand == null) return;

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // �S�Ă̗�����������\���ɂ���B
                            // ���Ӑ�
                            if (!CUSTOMERSUBNAME_KEY.Equals(col.Key)
                                // �Ǘ��ԍ�
                                && !MNGNO_KEY.Equals(col.Key)
                                // �����@�^��
                                && !ENGINEMODEL_KEY.Equals(col.Key)
                                // �ǉ����P
                                && !CARADDINFO1_KEY.Equals(col.Key)
                                // �ǉ����Q
                                && !CARADDINFO2_KEY.Equals(col.Key)
                                // �o�^�ԍ�
                                && !INSERTNO_KEY.Equals(col.Key)
                                // ���s����
                                && !MILEAGE_KEY.Equals(col.Key)
                                // �Ԍ�����
                                && !CARINSPECTYEAR_KEY.Equals(col.Key)
                                // �o�^�N����
                                && !ENTRYDATE_KEY.Equals(col.Key)
                                // �O��Ԍ���
                                && !LTIMECIMATDATE_KEY.Equals(col.Key)
                                // ����Ԍ���
                                && !INSPECTMATURITYDATE_KEY.Equals(col.Key)
                                // ���q���l
                                && !CARNOTE_KEY.Equals(col.Key)
                                // �J���[
                                && !COLORNAME1_KEY.Equals(col.Key)
                                // �g����
                                && !TRIMNAME_KEY.Equals(col.Key)
                                )
                            {
                                col.Hidden = true;
                            }
                        }


                        // Filter�ݒ�
                        editBand.Columns[CUSTOMERSUBNAME_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[MNGNO_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[ENGINEMODEL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARADDINFO1_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARADDINFO2_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[INSERTNO_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[MILEAGE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARINSPECTYEAR_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[ENTRYDATE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[LTIMECIMATDATE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARNOTE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[COLORNAME1_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[TRIMNAME_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                        // �\�����ݒ�
                        editBand.Columns[CUSTOMERSUBNAME_KEY].Width = 120;
                        editBand.Columns[MNGNO_KEY].Width = 120;
                        editBand.Columns[ENGINEMODEL_KEY].Width = 120;
                        editBand.Columns[CARADDINFO1_KEY].Width = 120;
                        editBand.Columns[CARADDINFO2_KEY].Width = 120;
                        editBand.Columns[INSERTNO_KEY].Width = 120;
                        editBand.Columns[MILEAGE_KEY].Width = 120;
                        editBand.Columns[CARINSPECTYEAR_KEY].Width = 120;
                        editBand.Columns[ENTRYDATE_KEY].Width = 120;
                        editBand.Columns[LTIMECIMATDATE_KEY].Width = 120;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Width = 120;
                        editBand.Columns[CARNOTE_KEY].Width = 120;
                        editBand.Columns[COLORNAME1_KEY].Width = 120;
                        editBand.Columns[TRIMNAME_KEY].Width = 120;

                        // �O���b�h����
                        editBand.Columns[CUSTOMERSUBNAME_KEY].Header.Caption = "���Ӑ�";
                        editBand.Columns[MNGNO_KEY].Header.Caption = "�Ǘ��ԍ�";
                        editBand.Columns[ENGINEMODEL_KEY].Header.Caption = "�����@�^��";
                        editBand.Columns[CARADDINFO1_KEY].Header.Caption = "�ǉ����P";
                        editBand.Columns[CARADDINFO2_KEY].Header.Caption = "�ǉ����Q";
                        editBand.Columns[INSERTNO_KEY].Header.Caption = "�o�^�ԍ�";
                        editBand.Columns[MILEAGE_KEY].Header.Caption = "���s����";
                        editBand.Columns[CARINSPECTYEAR_KEY].Header.Caption = "�Ԍ�����";
                        editBand.Columns[ENTRYDATE_KEY].Header.Caption = "�o�^�N����";
                        editBand.Columns[LTIMECIMATDATE_KEY].Header.Caption = "�O��Ԍ���";
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Header.Caption = "����Ԍ���";
                        editBand.Columns[CARNOTE_KEY].Header.Caption = "���q���l";
                        editBand.Columns[COLORNAME1_KEY].Header.Caption = "�J���[";
                        editBand.Columns[TRIMNAME_KEY].Header.Caption = "�g����";

                        // �Œ��ݒ�
                        editBand.Columns[CUSTOMERSUBNAME_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CUSTOMERSUBNAME_KEY].Header.Fixed = false;
                        editBand.Columns[MNGNO_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MNGNO_KEY].Header.Fixed = false;
                        editBand.Columns[ENGINEMODEL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ENGINEMODEL_KEY].Header.Fixed = false;
                        editBand.Columns[CARADDINFO1_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARADDINFO1_KEY].Header.Fixed = false;
                        editBand.Columns[CARADDINFO2_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARADDINFO2_KEY].Header.Fixed = false;
                        editBand.Columns[INSERTNO_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[INSERTNO_KEY].Header.Fixed = false;
                        editBand.Columns[MILEAGE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MILEAGE_KEY].Header.Fixed = false;
                        editBand.Columns[CARINSPECTYEAR_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARINSPECTYEAR_KEY].Header.Fixed = false;
                        editBand.Columns[ENTRYDATE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ENTRYDATE_KEY].Header.Fixed = false;
                        editBand.Columns[LTIMECIMATDATE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[LTIMECIMATDATE_KEY].Header.Fixed = false;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Header.Fixed = false;
                        editBand.Columns[CARNOTE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARNOTE_KEY].Header.Fixed = false;
                        editBand.Columns[COLORNAME1_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[COLORNAME1_KEY].Header.Fixed = false;
                        editBand.Columns[TRIMNAME_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[TRIMNAME_KEY].Header.Fixed = false;
                        // CellAppearance�ݒ�
                        editBand.Columns[CUSTOMERSUBNAME_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[MNGNO_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ENGINEMODEL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[CARADDINFO1_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[CARADDINFO2_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[INSERTNO_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[MILEAGE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[CARINSPECTYEAR_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[ENTRYDATE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[LTIMECIMATDATE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[CARNOTE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[COLORNAME1_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[TRIMNAME_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                        // ���͋��ݒ�
                        editBand.Columns[CUSTOMERSUBNAME_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[MNGNO_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ENGINEMODEL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARADDINFO1_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARADDINFO2_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[INSERTNO_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[MILEAGE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARINSPECTYEAR_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ENTRYDATE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[LTIMECIMATDATE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARNOTE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[COLORNAME1_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[TRIMNAME_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                        editBand.Columns[CUSTOMERSUBNAME_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[MNGNO_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ENGINEMODEL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARADDINFO1_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARADDINFO2_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[INSERTNO_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[MILEAGE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARINSPECTYEAR_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ENTRYDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[LTIMECIMATDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[INSPECTMATURITYDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARNOTE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[COLORNAME1_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[TRIMNAME_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

                        #endregion

                        break;
                    }
                case 1:
                    {
                        #region ���q���O���b�h

                        this.carSpecTable.BeginLoadData();

                        // �^���O���[�h����
                        this.carSpecTable.Columns.Add(MODELGRADENM_INFO_TITLE, typeof(string));
                        // �{�f�B�[����
                        this.carSpecTable.Columns.Add(BODYNAME_INFO_TITLE, typeof(string));
                        // �h�A��
                        this.carSpecTable.Columns.Add(DOORCOUNT_INFO_TITLE, typeof(string));
                        // �G���W���^������
                        this.carSpecTable.Columns.Add(ENGINEMODELNM_INFO_TITLE, typeof(string));
                        // �r�C�ʖ���
                        this.carSpecTable.Columns.Add(ENGINEDISPLACENM_INFO_TITLE, typeof(string));
                        // E�敪����
                        this.carSpecTable.Columns.Add(EDIVNM_INFO_TITLE, typeof(string));
                        // �~�b�V��������
                        this.carSpecTable.Columns.Add(TRANSMISSIONNM_INFO_TITLE, typeof(string));
                        // �쓮��������
                        this.carSpecTable.Columns.Add(WHEELDRIVEMETHODNM_INFO_TITLE, typeof(string));
                        // �V�t�g����
                        this.carSpecTable.Columns.Add(SHIFTNM_INFO_TITLE, typeof(string));
                        // �ǉ������^�C�g���P
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE1_INFO_TITLE, typeof(string));
                        // �ǉ������^�C�g���Q
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE2_INFO_TITLE, typeof(string));
                        // �ǉ������^�C�g���R
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE3_INFO_TITLE, typeof(string));
                        // �ǉ������^�C�g���S
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE4_INFO_TITLE, typeof(string));
                        // �ǉ������^�C�g���T
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE5_INFO_TITLE, typeof(string));
                        // �ǉ������^�C�g���U
                        this.carSpecTable.Columns.Add(ADDICARSPECTITLE6_INFO_TITLE, typeof(string));

                        this.carSpecTable.EndLoadData();

                        this.uGrid_CarSpec.DataSource = carSpecTable;

                        #endregion

                        #region ���q���O���b�h
                        this.uGrid_CarSpec.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;

                        Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarSpec.DisplayLayout.Bands[0];
                        if (editBand == null) return;

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // �S�Ă̗�����������\���ɂ���B
                            // �O���[�h
                            if (!MODELGRADENM_INFO_TITLE.Equals(col.Key)
                                // �{�f�B
                                && !BODYNAME_INFO_TITLE.Equals(col.Key)
                                // �h�A
                                && !DOORCOUNT_INFO_TITLE.Equals(col.Key)
                                // �G���W��
                                && !ENGINEMODELNM_INFO_TITLE.Equals(col.Key)
                                // �r�C��
                                && !ENGINEDISPLACENM_INFO_TITLE.Equals(col.Key)
                                // �d�敪
                                && !EDIVNM_INFO_TITLE.Equals(col.Key)
                                // �~�b�V����
                                && !TRANSMISSIONNM_INFO_TITLE.Equals(col.Key)
                                // �쓮����
                                && !WHEELDRIVEMETHODNM_INFO_TITLE.Equals(col.Key)
                                // �V�t�g
                                && !SHIFTNM_INFO_TITLE.Equals(col.Key))
                            {
                                col.Hidden = true;
                            }
                        }

                        // Filter�ݒ�
                        editBand.Columns[MODELGRADENM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[BODYNAME_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[EDIVNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[SHIFTNM_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                        // �\�����ݒ�
                        editBand.Columns[MODELGRADENM_INFO_TITLE].Width = 120;
                        editBand.Columns[BODYNAME_INFO_TITLE].Width = 120;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].Width = 120;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].Width = 120;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].Width = 120;
                        editBand.Columns[EDIVNM_INFO_TITLE].Width = 120;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].Width = 120;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].Width = 120;
                        editBand.Columns[SHIFTNM_INFO_TITLE].Width = 120;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].Width = 150;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].Width = 150;

                        // �Œ��ݒ�
                        editBand.Columns[MODELGRADENM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MODELGRADENM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[BODYNAME_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[BODYNAME_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[EDIVNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[EDIVNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[SHIFTNM_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIFTNM_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].Header.Fixed = true;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].Header.Fixed = true;

                        // CellAppearance�ݒ�
                        editBand.Columns[MODELGRADENM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[BODYNAME_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[EDIVNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[SHIFTNM_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                        // ���͋��ݒ�
                        editBand.Columns[MODELGRADENM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[BODYNAME_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[EDIVNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIFTNM_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                        // Style�ݒ�
                        editBand.Columns[MODELGRADENM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[BODYNAME_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[DOORCOUNT_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ENGINEMODELNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ENGINEDISPLACENM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[EDIVNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[TRANSMISSIONNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[WHEELDRIVEMETHODNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIFTNM_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE1_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE2_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE3_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE4_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE5_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ADDICARSPECTITLE6_INFO_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

                        #endregion

                        #region ���q���O���b�h
                        DataRow dataRow;
                        dataRow = this.carSpecTable.NewRow();
                        dataRow[MODELGRADENM_INFO_TITLE] = string.Empty;
                        dataRow[BODYNAME_INFO_TITLE] = string.Empty;
                        dataRow[DOORCOUNT_INFO_TITLE] = string.Empty;
                        dataRow[ENGINEMODELNM_INFO_TITLE] = string.Empty;
                        dataRow[ENGINEDISPLACENM_INFO_TITLE] = string.Empty;
                        dataRow[EDIVNM_INFO_TITLE] = string.Empty;
                        dataRow[TRANSMISSIONNM_INFO_TITLE] = string.Empty;
                        dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = string.Empty;
                        dataRow[SHIFTNM_INFO_TITLE] = string.Empty;

                        this.carSpecTable.Rows.Add(dataRow);

                        this.uGrid_CarSpec.Refresh();
                        #endregion

                        break;
                    }
                case 2:
                    {
                        #region �o�ו��i�O���b�h

                        this.carPartsTable.BeginLoadData();
                        // �O���b�h�p
                        // �`�[���t
                        this.carPartsTable.Columns.Add(SALESDATE_KEY, typeof(string));
                        // �i��
                        this.carPartsTable.Columns.Add(GOODSNAME_KEY, typeof(string));
                        //------ADD BY �����@on 2012/08/09 for Redmine#31532------>>>>>>>
                        // �s�ԍ�
                        this.carPartsTable.Columns.Add(ROWNO_KEY, typeof(string));
                        //------ADD BY �����@on 2012/08/09 for Redmine#31532------<<<<<<<
                        // �i��
                        this.carPartsTable.Columns.Add(GOODSNO_KEY, typeof(string));
                        // ���[�J�[
                        this.carPartsTable.Columns.Add(GOODSMAKERNAME_KEY, typeof(string));
                        // BL�R�[�h
                        this.carPartsTable.Columns.Add(BLGOODSCD_KEY, typeof(string));
                        // �݌Ɏ��敪
                        this.carPartsTable.Columns.Add(SALESORDERDIVCD_KEY, typeof(string));
                        // �W�����i
                        this.carPartsTable.Columns.Add(LISTPRICETAXEXCFL_KEY, typeof(string));
                        // ����
                        this.carPartsTable.Columns.Add(SHIPMENTCNT_KEY, typeof(string));
                        // ���P��
                        this.carPartsTable.Columns.Add(SALESUNPRCTAXEXCFL_KEY, typeof(string));
                        // ������z
                        this.carPartsTable.Columns.Add(SALESMONEYTAXEXC_KEY, typeof(string));
                        // ���P��
                        this.carPartsTable.Columns.Add(SALESUNITCOST_KEY, typeof(string));
                        // �e��
                        this.carPartsTable.Columns.Add(SALESMONEYTAXEXC_COST_KEY, typeof(string));
                        // �e����
                        this.carPartsTable.Columns.Add(COST_SALESMONEYTAXEXC_KEY, typeof(string));
                        // ���l
                        this.carPartsTable.Columns.Add(SLIPNOTE_KEY, typeof(string));
                        // ���q���l
                        this.carPartsTable.Columns.Add(CARNOTE_PARTS_KEY, typeof(string));
                        // �`�[�ԍ�
                        this.carPartsTable.Columns.Add(SALESSLIPNUM_KEY, typeof(string));
                        // ���s����
                        this.carPartsTable.Columns.Add(MILEAGE_PARTS_KEY, typeof(string));
                        // �^��1-2
                        this.carPartsTable.Columns.Add(MODEL1TO2_KEY, typeof(string));

                        // ��ʕ\���p
                        // ���Ӑ�R�[�h
                        this.carPartsTable.Columns.Add(CUSTOMERCODE_KEY, typeof(string));
                        // �^��
                        this.carPartsTable.Columns.Add(KINDMODEL_KEY, typeof(string));
                        // �^���w��ԍ�
                        this.carPartsTable.Columns.Add(MODELDESIGNATIONNO_KEY, typeof(string));
                        // �ޕʔԍ�
                        this.carPartsTable.Columns.Add(CATEGORYNO_KEY, typeof(string));
                        // �G���W���^��
                        this.carPartsTable.Columns.Add(ENGINEMODELNM_KEY, typeof(string));
                        // �Ԏ�i���[�J�[�R�[�h�j
                        this.carPartsTable.Columns.Add(MAKERCODE_KEY, typeof(string));
                        // �Ԏ�i�Ԏ�R�[�h�j
                        this.carPartsTable.Columns.Add(MODELCODE_KEY, typeof(string));
                        // �Ԏ�i�ď̃R�[�h�j
                        this.carPartsTable.Columns.Add(MODELSUBCODE_KEY, typeof(string));
                        // �Ԏ햼��
                        this.carPartsTable.Columns.Add(MODELFULLNAME_KEY, typeof(string));
                        // �^���i�t���^�j
                        this.carPartsTable.Columns.Add(FULLMODEL_KEY, typeof(string));
                        // �N��
                        this.carPartsTable.Columns.Add(FIRSTENTRYDATE_KEY, typeof(string));
                        // (���Y�N�� �J�n-�I��)
                        this.carPartsTable.Columns.Add(STEDPRODUCETYPEOFYEAR_KEY, typeof(string));
                        // �ԑ�ԍ�
                        this.carPartsTable.Columns.Add(FRAMENO_KEY, typeof(string));
                        // (�ԑ�ԍ� �J�n-�I��)
                        this.carPartsTable.Columns.Add(STEDPRODUCEFRAMENO_KEY, typeof(string));
                        // �J���[
                        this.carPartsTable.Columns.Add(COLORCODE_KEY, typeof(string));
                        // �g����
                        this.carPartsTable.Columns.Add(TRIMCODE_KEY, typeof(string));
                        // �^���O���[�h����
                        this.carPartsTable.Columns.Add(MODELGRADENM_KEY, typeof(string));
                        // �{�f�B�[����
                        this.carPartsTable.Columns.Add(BODYNAME_KEY, typeof(string));
                        // �h�A��
                        this.carPartsTable.Columns.Add(DOORCOUNT_KEY, typeof(string));
                        // �G���W���^������
                        //this.carSearchTable.Columns.Add(ENGINEMODELNM_TITLE, typeof(string));
                        // �r�C�ʖ���
                        this.carPartsTable.Columns.Add(ENGINEDISPLACENM_KEY, typeof(string));
                        // E�敪����
                        this.carPartsTable.Columns.Add(EDIVNM_KEY, typeof(string));
                        // �~�b�V��������
                        this.carPartsTable.Columns.Add(TRANSMISSIONNM_KEY, typeof(string));
                        // �쓮��������
                        this.carPartsTable.Columns.Add(WHEELDRIVEMETHODNM_KEY, typeof(string));
                        // �V�t�g����
                        this.carPartsTable.Columns.Add(SHIFTNM_KEY, typeof(string));
                        // �ǉ������^�C�g���P
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE1_KEY, typeof(string));
                        // �ǉ������^�C�g���Q
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE2_KEY, typeof(string));
                        // �ǉ������^�C�g���R
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE3_KEY, typeof(string));
                        // �ǉ������^�C�g���S
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE4_KEY, typeof(string));
                        // �ǉ������^�C�g���T
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE5_KEY, typeof(string));
                        // �ǉ������^�C�g���U
                        this.carPartsTable.Columns.Add(ADDICARSPECTITLE6_KEY, typeof(string));
                        // �ǉ������P
                        this.carPartsTable.Columns.Add(ADDICARSPEC1_KEY, typeof(string));
                        // �ǉ������Q
                        this.carPartsTable.Columns.Add(ADDICARSPEC2_KEY, typeof(string));
                        // �ǉ������R
                        this.carPartsTable.Columns.Add(ADDICARSPEC3_KEY, typeof(string));
                        // �ǉ������S
                        this.carPartsTable.Columns.Add(ADDICARSPEC4_KEY, typeof(string));
                        // �ǉ������T
                        this.carPartsTable.Columns.Add(ADDICARSPEC5_KEY, typeof(string));
                        // �ǉ������U
                        this.carPartsTable.Columns.Add(ADDICARSPEC6_KEY, typeof(string));
                        // --- ADD 2013/03/25 ---------->>>>>
                        // ���Y/�O�ԋ敪
                        this.carPartsTable.Columns.Add(DOMESTICFOREIGNCODERF_KEY, typeof(string));
                        // --- ADD 2013/03/25 ----------<<<<<

                        // �e�L�X�g�p
                        // ���[�J�[�R�[�h
                        this.carPartsTable.Columns.Add(GOODSMAKERCD_KEY, typeof(string));
                        // �J���[����1
                        this.carPartsTable.Columns.Add(COLORNAME1_KEY, typeof(string));
                        // �g��������
                        this.carPartsTable.Columns.Add(TRIMNAME_KEY, typeof(string));
                        // ���^�������ԍ�
                        this.carPartsTable.Columns.Add(NUMBERPLATE1CODE_KEY, typeof(string));
                        // ���^�����ǖ���
                        this.carPartsTable.Columns.Add(NUMBERPLATE1NAME_KEY, typeof(string));
                        // �ԗ��o�^�ԍ��i��ʁj
                        this.carPartsTable.Columns.Add(NUMBERPLATE2_KEY, typeof(string));
                        // �ԗ��o�^�ԍ��i�J�i�j
                        this.carPartsTable.Columns.Add(NUMBERPLATE3_KEY, typeof(string));
                        // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        this.carPartsTable.Columns.Add(NUMBERPLATE4_KEY, typeof(string));
                        // �J�n���Y�N��
                        this.carPartsTable.Columns.Add(STPRODUCETYPEOFYEAR_KEY, typeof(string));
                        // �I�����Y�N��
                        this.carPartsTable.Columns.Add(EDPRODUCETYPEOFYEAR_KEY, typeof(string));
                        // ���Y�ԑ�ԍ��J�n
                        this.carPartsTable.Columns.Add(STPRODUCEFRAMENO_KEY, typeof(string));
                        // ���Y�ԑ�ԍ��I��
                        this.carPartsTable.Columns.Add(EDPRODUCEFRAMENO_KEY, typeof(string));

                        //-------ADD 2009/10/10------->>>>>
                        // �Ǘ��ԍ�
                        this.carPartsTable.Columns.Add(MNGNO_KEY, typeof(string));
                        //-------ADD 2009/10/10-------<<<<<

                        this.carPartsTable.EndLoadData();

                        this.uGrid_CarPartsList.DataSource = carPartsTable;

                        #endregion

                        #region �o�ו��i�O���b�h
                        this.uGrid_CarPartsList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
                        this.uGrid_CarPartsList.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;


                        Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarPartsList.DisplayLayout.Bands[0];
                        if (editBand == null) return;

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // �S�Ă̗�����������\���ɂ���B
                            // �`�[���t
                            if (!SALESDATE_KEY.Equals(col.Key)
                                // �i��
                                && !GOODSNAME_KEY.Equals(col.Key)
                                //�s�ԍ� 
                                && !ROWNO_KEY.Equals(col.Key)//ADD BY �����@on 2012/08/09 for Redmine#31532
                                // �i��
                                && !GOODSNO_KEY.Equals(col.Key)
                                // ���[�J�[
                                && !GOODSMAKERNAME_KEY.Equals(col.Key)
                                // BL�R�[�h
                                && !BLGOODSCD_KEY.Equals(col.Key)
                                // �݌Ɏ��敪
                                && !SALESORDERDIVCD_KEY.Equals(col.Key)
                                // �W�����i
                                && !LISTPRICETAXEXCFL_KEY.Equals(col.Key)
                                // ����
                                && !SHIPMENTCNT_KEY.Equals(col.Key)
                                // ���P��
                                && !SALESUNPRCTAXEXCFL_KEY.Equals(col.Key)
                                // ������z
                                && !SALESMONEYTAXEXC_KEY.Equals(col.Key)
                                // ���P��
                                && !SALESUNITCOST_KEY.Equals(col.Key)
                                // �e��
                                && !SALESMONEYTAXEXC_COST_KEY.Equals(col.Key)
                                // �e����
                                && !COST_SALESMONEYTAXEXC_KEY.Equals(col.Key)
                                // ���l
                                && !SLIPNOTE_KEY.Equals(col.Key)
                                // ���q���l
                                && !CARNOTE_PARTS_KEY.Equals(col.Key)
                                // �`�[�ԍ�
                                && !SALESSLIPNUM_KEY.Equals(col.Key)
                                // ���s����
                                && !MILEAGE_PARTS_KEY.Equals(col.Key))
                            {
                                col.Hidden = true;
                            }
                        }


                        // Filter�ݒ�
                        editBand.Columns[SALESDATE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[GOODSNAME_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[ROWNO_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;//ADD BY �����@on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[GOODSMAKERNAME_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[BLGOODSCD_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESORDERDIVCD_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTCNT_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESUNITCOST_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SLIPNOTE_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[CARNOTE_PARTS_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESSLIPNUM_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[MILEAGE_PARTS_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[MODEL1TO2_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                        // �\�����ݒ�
                        editBand.Columns[SALESDATE_KEY].Width = 120;
                        editBand.Columns[GOODSNAME_KEY].Width = 120;
                        editBand.Columns[ROWNO_KEY].Width = 120;//ADD BY �����@on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].Width = 120;
                        editBand.Columns[GOODSMAKERNAME_KEY].Width = 120;
                        editBand.Columns[BLGOODSCD_KEY].Width = 120;
                        editBand.Columns[SALESORDERDIVCD_KEY].Width = 120;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTCNT_KEY].Width = 120;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Width = 120;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Width = 120;
                        editBand.Columns[SALESUNITCOST_KEY].Width = 120;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Width = 120;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Width = 120;
                        editBand.Columns[SLIPNOTE_KEY].Width = 120;
                        editBand.Columns[CARNOTE_PARTS_KEY].Width = 120;
                        editBand.Columns[SALESSLIPNUM_KEY].Width = 120;
                        editBand.Columns[MILEAGE_PARTS_KEY].Width = 120;
                        editBand.Columns[MODEL1TO2_KEY].Width = 120;

                        // �O���b�h����
                        editBand.Columns[SALESDATE_KEY].Header.Caption = SALESDATE_TITLE;
                        editBand.Columns[GOODSNAME_KEY].Header.Caption = GOODSNAME_TITLE;
                        editBand.Columns[ROWNO_KEY].Header.Caption = ROWNO_TITLE;//ADD BY �����@on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].Header.Caption = GOODSNO_TITLE;
                        editBand.Columns[GOODSMAKERNAME_KEY].Header.Caption = GOODSMAKERCD_TITLE;
                        editBand.Columns[BLGOODSCD_KEY].Header.Caption = BLGOODSCODE_TITLE;
                        editBand.Columns[SALESORDERDIVCD_KEY].Header.Caption = SALESORDERDIVCD_TITLE;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Header.Caption = LISTPRICETAXEXCFL_TITLE;
                        editBand.Columns[SHIPMENTCNT_KEY].Header.Caption = SHIPMENTCNT_TITLE;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Header.Caption = SALESUNPRCTAXEXCFL_TITLE;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Header.Caption = SALESMONEYTAXEXC_TITLE;
                        editBand.Columns[SALESUNITCOST_KEY].Header.Caption = SALESUNITCOST_TITLE;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Header.Caption = SALESMONEYTAXEXC_COST_TITLE;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Header.Caption = COST_SALESMONEYTAXEXC_TITLE;
                        editBand.Columns[SLIPNOTE_KEY].Header.Caption = SLIPNOTE_TITLE;
                        editBand.Columns[CARNOTE_PARTS_KEY].Header.Caption = CARNOTE_PARTS_TITLE;
                        editBand.Columns[SALESSLIPNUM_KEY].Header.Caption = SALESSLIPNUM_TITLE;
                        editBand.Columns[MILEAGE_PARTS_KEY].Header.Caption = MILEAGE_PARTS_TITLE;
                        editBand.Columns[MODEL1TO2_KEY].Header.Caption = MODEL1TO2_TITLE;

                        // �Œ��ݒ�
                        editBand.Columns[SALESDATE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESDATE_KEY].Header.Fixed = false;
                        editBand.Columns[GOODSNAME_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSNAME_KEY].Header.Fixed = false;
                        //-----ADD BY �����@on 2012/08/09 for Redmine#31532------->>>>>>>
                        editBand.Columns[ROWNO_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[ROWNO_KEY].Header.Fixed = false;
                        //-----ADD BY �����@on 2012/08/09 for Redmine#31532-------<<<<<<<
                        editBand.Columns[GOODSNO_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSNO_KEY].Header.Fixed = false;
                        editBand.Columns[GOODSMAKERNAME_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSMAKERNAME_KEY].Header.Fixed = false;
                        editBand.Columns[BLGOODSCD_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[BLGOODSCD_KEY].Header.Fixed = false;
                        editBand.Columns[SALESORDERDIVCD_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESORDERDIVCD_KEY].Header.Fixed = false;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTCNT_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTCNT_KEY].Header.Fixed = false;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Header.Fixed = false;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Header.Fixed = false;
                        editBand.Columns[SALESUNITCOST_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESUNITCOST_KEY].Header.Fixed = false;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Header.Fixed = false;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Header.Fixed = false;
                        editBand.Columns[SLIPNOTE_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SLIPNOTE_KEY].Header.Fixed = false;
                        editBand.Columns[CARNOTE_PARTS_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[CARNOTE_PARTS_KEY].Header.Fixed = false;
                        editBand.Columns[SALESSLIPNUM_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESSLIPNUM_KEY].Header.Fixed = false;
                        editBand.Columns[MILEAGE_PARTS_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MILEAGE_PARTS_KEY].Header.Fixed = false;
                        editBand.Columns[MODEL1TO2_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[MODEL1TO2_KEY].Header.Fixed = false;

                        // CellAppearance�ݒ�
                        editBand.Columns[SALESDATE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[GOODSNAME_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[ROWNO_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;//ADD BY �����@on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[GOODSMAKERNAME_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[BLGOODSCD_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESORDERDIVCD_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SHIPMENTCNT_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESUNITCOST_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SLIPNOTE_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[CARNOTE_PARTS_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[SALESSLIPNUM_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[MILEAGE_PARTS_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[MODEL1TO2_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                        // ���͋��ݒ�
                        editBand.Columns[SALESDATE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[GOODSNAME_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[ROWNO_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;//ADD BY �����@on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[GOODSMAKERNAME_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[BLGOODSCD_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESORDERDIVCD_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTCNT_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESUNITCOST_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SLIPNOTE_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[CARNOTE_PARTS_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESSLIPNUM_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[MILEAGE_PARTS_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[MODEL1TO2_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;


                        // Style�ݒ�
                        editBand.Columns[SALESDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESDATE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSNAME_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[ROWNO_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;//ADD BY �����@on 2012/08/09 for Redmine#31532
                        editBand.Columns[GOODSNO_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSMAKERNAME_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[BLGOODSCD_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESORDERDIVCD_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[LISTPRICETAXEXCFL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTCNT_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESUNPRCTAXEXCFL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESMONEYTAXEXC_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESUNITCOST_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESMONEYTAXEXC_COST_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[COST_SALESMONEYTAXEXC_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SLIPNOTE_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[CARNOTE_PARTS_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESSLIPNUM_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[MILEAGE_PARTS_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[MODEL1TO2_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;


                        #endregion

                        break;
                    }
                case 3:
                    {
                        #region �o�ו��i�i���v�j�O���b�h

                        this.carPartsTotalTable.BeginLoadData();
                        // �O���b�h�p
                        // �i��
                        this.carPartsTotalTable.Columns.Add(GOODSNAME_TOTAL_KEY, typeof(string));
                        // �i��
                        this.carPartsTotalTable.Columns.Add(GOODSNO_TOTAL_KEY, typeof(string));
                        // ���[�J�[
                        this.carPartsTotalTable.Columns.Add(GOODSMAKERNAME_TOTAL_KEY, typeof(string));
                        // BL�R�[�h
                        this.carPartsTotalTable.Columns.Add(BLGOODSCODE_TOTAL_KEY, typeof(string));
                        // ����
                        this.carPartsTotalTable.Columns.Add(SHIPMENTCNT_TOTAL_KEY, typeof(string));
                        // ������z
                        this.carPartsTotalTable.Columns.Add(SALESMONEYTAXEXC_TOTAL_KEY, typeof(string));
                        // �o�׉�
                        this.carPartsTotalTable.Columns.Add(COUNT_TOTAL_KEY, typeof(string));
                        // �q��
                        this.carPartsTotalTable.Columns.Add(WAREHOUSE_TOTAL_KEY, typeof(string));
                        // �I��
                        this.carPartsTotalTable.Columns.Add(SHELFNO_TOTAL_KEY, typeof(string));
                        // ���݌ɐ�
                        this.carPartsTotalTable.Columns.Add(SHIPMENTPOSCNT_TOTAL_KEY, typeof(string));
                        // ���ʁi�݌Ɂj
                        this.carPartsTotalTable.Columns.Add(SHIPMENTCNTIN_TOTAL_KEY, typeof(string));
                        // ���ʁi���j
                        this.carPartsTotalTable.Columns.Add(SHIPMENTCNTOUT_TOTAL_KEY, typeof(string));

                        // ���[�J�[�R�[�h
                        this.carPartsTotalTable.Columns.Add(GOODSMAKERCD_TOTAL_KEY, typeof(string));
                        // �q�ɃR�[�h
                        this.carPartsTotalTable.Columns.Add(WAREHOUSECODE_TOTAL_KEY, typeof(string));
                        this.carPartsTotalTable.EndLoadData();

                        this.uGrid_CarPartsTotalList.DataSource = carPartsTotalTable;

                        #endregion

                        #region �o�ו��i�i���v�j�O���b�h
                        this.uGrid_CarPartsTotalList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Single;
                        this.uGrid_CarPartsTotalList.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;


                        Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarPartsTotalList.DisplayLayout.Bands[0];
                        if (editBand == null) return;

                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
                        {
                            // �S�Ă̗�����������\���ɂ���B
                            // �i��
                            if (GOODSMAKERCD_TOTAL_KEY.Equals(col.Key)
                                // �i��
                                || WAREHOUSECODE_TOTAL_KEY.Equals(col.Key))
                            {
                                col.Hidden = true;
                            }
                        }

                        // Filter�ݒ�
                        editBand.Columns[GOODSNAME_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[GOODSNO_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[COUNT_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHELFNO_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;

                        // �\�����ݒ�
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Width = 120;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Width = 120;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Width = 120;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Width = 120;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Width = 120;
                        editBand.Columns[COUNT_TOTAL_KEY].Width = 120;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Width = 120;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Width = 120;

                        // �O���b�h����
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Header.Caption = GOODSNAME_TOTAL_TITLE;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Header.Caption = GOODSNO_TOTAL_TITLE;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Header.Caption = GOODSMAKERCD_TOTAL_TITLE;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Header.Caption = BLGOODSCODE_TOTAL_TITLE;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Header.Caption = SHIPMENTCNT_TOTAL_TITLE;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Header.Caption = SALESMONEYTAXEXC_TOTAL_TITLE;
                        editBand.Columns[COUNT_TOTAL_KEY].Header.Caption = COUNT_TOTAL_TITLE;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Header.Caption = WAREHOUSE_TOTAL_TITLE;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Header.Caption = SHELFNO_TOTAL_TITLE;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Header.Caption = SHIPMENTPOSCNT_TOTAL_TITLE;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Header.Caption = SHIPMENTCNTIN_TOTAL_TITLE;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Header.Caption = SHIPMENTCNTOUT_TOTAL_TITLE;

                        // �Œ��ݒ�
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[COUNT_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[COUNT_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Header.Fixed = false;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Header.Fixed = false;

                        // CellAppearance�ݒ�
                        editBand.Columns[GOODSNAME_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[GOODSNO_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[COUNT_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[SHELFNO_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                        // ���͋��ݒ�
                        editBand.Columns[GOODSNAME_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[GOODSNO_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[COUNT_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHELFNO_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                        // Style�ݒ�
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSNAME_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSNO_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[GOODSMAKERNAME_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[BLGOODSCODE_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTCNT_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SALESMONEYTAXEXC_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[COUNT_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[WAREHOUSE_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHELFNO_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTPOSCNT_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTCNTIN_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        editBand.Columns[SHIPMENTCNTOUT_TOTAL_KEY].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
                        #endregion

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        #endregion

        #region �� �񕝎������� ��

        /// <summary>
        /// �񕝎�������
        /// </summary>
        /// <param name="autoAdjust">�����������邩�ǂ���</param>
        /// <param name="targetGrid">�ΏۂƂȂ�O���b�h 0:���q����, 1:�o�ו��i, 2:�o�ו��i�i���v�j 3:���q���</param>
        /// <remarks>
        /// <br>Note        : ���q��񌟍��������s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void autoColumnAdjust(bool autoAdjust, int targetGrid)
        {
            switch (targetGrid)
            {
                #region ���q�����O���b�h
                case 0:
                    {
                        if (this.uGrid_CarSearchList.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                             this.uGrid_CarSearchList.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) break;

                        // ���������v���p�e�B�𒲐�
                        if (autoAdjust)
                        {
                            this.uGrid_CarSearchList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_CarSearchList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // �S�Ă̗�ŃT�C�Y����
                        for (int i = 0; i < this.uGrid_CarSearchList.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            this.uGrid_CarSearchList.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                #endregion

                #region �o�ו��i�O���b�h
                case 1:
                    {
                        if (this.uGrid_CarPartsList.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                             this.uGrid_CarPartsList.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) break;

                        // ���������v���p�e�B�𒲐�
                        if (autoAdjust)
                        {
                            this.uGrid_CarPartsList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_CarPartsList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // �S�Ă̗�ŃT�C�Y����
                        for (int i = 0; i < this.uGrid_CarPartsList.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            this.uGrid_CarPartsList.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                #endregion

                #region �o�ו��i�i���v�j�O���b�h
                case 2:
                    {
                        //if (this.uGrid_CarPartsTotalList.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                        //     this.uGrid_CarPartsTotalList.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) break;

                        // ���������v���p�e�B�𒲐�
                        if (autoAdjust)
                        {
                            this.uGrid_CarPartsTotalList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_CarPartsTotalList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // �S�Ă̗�ŃT�C�Y����
                        for (int i = 0; i < this.uGrid_CarPartsTotalList.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            this.uGrid_CarPartsTotalList.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                #endregion

                #region ���q���O���b�h
                case 3:
                    {
                        if (this.uGrid_CarSpec.DisplayLayout.AutoFitStyle == Infragistics.Win.UltraWinGrid.AutoFitStyle.None && !autoAdjust ||
                             this.uGrid_CarSpec.DisplayLayout.AutoFitStyle != Infragistics.Win.UltraWinGrid.AutoFitStyle.None && autoAdjust) break;

                        // ���������v���p�e�B�𒲐�
                        if (autoAdjust)
                        {
                            this.uGrid_CarSpec.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                        }
                        else
                        {
                            this.uGrid_CarSpec.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                        }
                        // �S�Ă̗�ŃT�C�Y����
                        for (int i = 0; i < this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns.Count; i++)
                        {
                            this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                        }
                        break;
                    }
                #endregion

                default: break;
            }
        }

        #endregion

        #region �� ���̓`�F�b�N���� ��
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ���̓`�F�b�N�������s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        private bool ExecutBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {

                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);


                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// �G���[���b�Z�[�W����
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note		: ��ʂ̃G���[���b�Z�[�W�������s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,
                CT_PGID,
                "",
                "",
                "",
                message,
                status,
                null,
                MessageBoxButtons.OK,
                MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.09.10</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_NoInput = "����͂��ĉ������B";
            const string ct_InputError = "�̓��͂��s���ł��B";

            if (this.tComboEditor_DisplayDiv.SelectedIndex == 2)
            {
                // �^��
                if (string.IsNullOrEmpty(this.tEdit_FullModel.Text.Trim()))
                {
                    errMessage = string.Format("�^��{0}", ct_NoInput);
                    errComponent = this.tEdit_FullModel;
                    status = false;

                    return status;
                }
            }

            DateGetAcs.CheckDateResult cdResult;

            if (this.tDateEdit_SalesDateSt.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_SalesDateSt, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("�J�n��{0}", ct_InputError);
                    errComponent = this.tDateEdit_SalesDateSt;
                    status = false;

                    return status;
                }
            }

            if (this.tDateEdit_SalesDateEd.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_SalesDateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("�I����{0}", ct_InputError);
                    errComponent = this.tDateEdit_SalesDateEd;
                    status = false;
                    return status;
                }

                if (this.tDateEdit_SalesDateSt.GetDateTime() > this.tDateEdit_SalesDateEd.GetDateTime())
                {
                    errMessage = "������͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tDateEdit_SalesDateEd;
                    status = false;
                    return status;
                }
            }

            if (this.tDateEdit_AddUpADateSt.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_AddUpADateSt, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("�J�n��{0}", ct_InputError);
                    errComponent = this.tDateEdit_AddUpADateSt;
                    status = false;

                    return status;
                }
            }

            if (this.tDateEdit_AddUpADateEd.GetLongDate() != 0)
            {
                cdResult = this._dateGetAcs.CheckDate(ref tDateEdit_AddUpADateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("�I����{0}", ct_InputError);
                    errComponent = this.tDateEdit_AddUpADateEd;
                    status = false;
                    return status;
                }

                if (this.tDateEdit_AddUpADateSt.GetDateTime() > this.tDateEdit_AddUpADateEd.GetDateTime())
                {
                    errMessage = "���͓��͈͎̔w��Ɍ�肪����܂��B";
                    errComponent = this.tDateEdit_AddUpADateEd;
                    status = false;
                    return status;
                }
            }

            return status;
        }
        #endregion

        #region �� ���q��񌟍� ��
        /// <summary>
        /// ���q��񌟍�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���q��񌟍��������s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// <br>Update Note : SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
        /// <br>Programmer  : FSI���� �G</br>
        /// <br>Date        : 2013/03/25</br>
        /// </remarks>
        private void SearchProcess()
        {
            // �O���b�g���N���A
            this.carSearchTable.Clear();
            this.carPartsTable.Clear();
            this.carPartsTotalTable.Clear();
            this.carSpecTable.Clear();
            this.uGrid_CarSearchList.Visible = true;
            this.uGrid_CarPartsList.Visible = false;
            this.uGrid_CarPartsTotalList.Visible = false;
            // ���q���N���A
            this.CarInfoClear();
            // ���o�����g���ŏ���
            this.uGroupBox_ExtractCondition.Expanded = false;

            CarManagementWork carManagementWork = new CarManagementWork();
            // ���Ӑ�R�[�h
            carManagementWork.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // ��ƃR�[�h
            carManagementWork.EnterpriseCode = _enterpriseCode;
            // �Ǘ��ԍ�
            carManagementWork.CarMngCode = this.tEdit_CarMngCode.Text.Trim();
            // �Ǘ��ԍ������敪
            carManagementWork.CarMngCodeSearchDiv = this.tComboEditor_CarMngCode.SelectedIndex;
            // �^��
            carManagementWork.KindModel = this.tEdit_FullModel.Text.Trim();
            // �^�������敪
            carManagementWork.KindModelSearchDiv = this.tComboEditor_FullModelFuzzy.SelectedIndex;
            // ���q���l
            carManagementWork.CarNote = this.tEdit_SlipNote.Text.Trim();
            // ���q���l�����敪
            carManagementWork.CarNoteSearchDiv = this.tComboEditor_SlipNoteFuzzy.SelectedIndex;

            object carMngWorkObj = (object)carManagementWork;
            ArrayList carMngWorkList = new ArrayList();
            object carMngWorkListObj = (object)carMngWorkList;
            int status = _carPartDisplayAcs.CarInfoSearch(carMngWorkObj, ref carMngWorkListObj);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                DataRow dataRow;
                ArrayList carMngList = carMngWorkListObj as ArrayList;
                CustomerSearchRet customerWork = null;
                foreach (CarManagementWork work in carMngList)
                {
                    dataRow = this.carSearchTable.NewRow();
                    // ���Ӑ於��
                    if (this._customerSearchRetDic.Count == 0)
                    {
                        this.LoadCustomerSearchRet();
                    }
                    if (this._customerSearchRetDic.ContainsKey(work.CustomerCode))
                    {
                        customerWork = this._customerSearchRetDic[work.CustomerCode];
                        dataRow[CUSTOMERSUBNAME_KEY] = customerWork.Snm;
                    }
                    else
                    {
                        dataRow[CUSTOMERSUBNAME_KEY] = string.Empty;
                    }
                    // �Ǘ��ԍ�
                    dataRow[MNGNO_KEY] = work.CarMngCode;
                    // �����@�^��
                    dataRow[ENGINEMODEL_KEY] = work.EngineModel;
                    // �ǉ����P
                    dataRow[CARADDINFO1_KEY] = work.CarAddInfo1;
                    // �ǉ����Q
                    dataRow[CARADDINFO2_KEY] = work.CarAddInfo2;
                    // �o�^�ԍ�
                    // ------UPD 2009/10/10-------------->>>>>
                    if (work.NumberPlate4 == 0)
                    {
                        dataRow[INSERTNO_KEY] = work.NumberPlate1Name.PadRight(4, '�@')
                            + work.NumberPlate2.PadLeft(3, ' ')
                            + work.NumberPlate3.PadRight(1, '�@');
                    }
                    else
                    {
                        dataRow[INSERTNO_KEY] = work.NumberPlate1Name.PadRight(4, '�@')
                        + work.NumberPlate2.PadLeft(3, ' ')
                        + work.NumberPlate3.PadRight(1, '�@')
                        + work.NumberPlate4.ToString().PadLeft(4, ' ');
                    }
                    // ------UPD 2009/10/10--------------<<<<<
                    // ���s����
                    dataRow[MILEAGE_KEY] = work.Mileage.ToString("#,##0");
                    // �Ԍ�����
                    if (work.CarInspectYear == 0)
                    {
                        dataRow[CARINSPECTYEAR_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[CARINSPECTYEAR_KEY] = work.CarInspectYear.ToString("d2");
                    }

                    // �o�^�N����
                    if (work.EntryDate == DateTime.MinValue)
                    {
                        dataRow[ENTRYDATE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[ENTRYDATE_KEY] = work.EntryDate.ToString(DATEFORMAT_YYYYMMDD);
                    }
                    // �O��Ԍ���
                    if (work.LTimeCiMatDate == DateTime.MinValue)
                    {
                        dataRow[LTIMECIMATDATE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[LTIMECIMATDATE_KEY] = work.LTimeCiMatDate.ToString(DATEFORMAT_YYYYMMDD);
                    }
                    // ����Ԍ���
                    if (work.InspectMaturityDate == DateTime.MinValue)
                    {
                        dataRow[INSPECTMATURITYDATE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[INSPECTMATURITYDATE_KEY] = work.InspectMaturityDate.ToString(DATEFORMAT_YYYYMMDD);
                    }
                    // ���q���l
                    dataRow[CARNOTE_KEY] = work.CarNote;

                    // ��ʕ\���p
                    // ���Ӑ�R�[�h
                    dataRow[CUSTOMERCODE_KEY] = work.CustomerCode;
                    // �^���i�V���[�Y�^���{�^���i�ޕʋL���j�j
                    if (string.IsNullOrEmpty(work.SeriesModel) && string.IsNullOrEmpty(work.CategorySignModel))
                    {
                        dataRow[KINDMODEL_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[KINDMODEL_KEY] = work.SeriesModel + "-" + work.CategorySignModel;
                    }

                    // �^���w��ԍ�
                    if (work.ModelDesignationNo == 0)
                    {
                        dataRow[MODELDESIGNATIONNO_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[MODELDESIGNATIONNO_KEY] = work.ModelDesignationNo.ToString("00000");
                    }
                    // �ޕʔԍ�
                    if (work.CategoryNo == 0)
                    {
                        dataRow[CATEGORYNO_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[CATEGORYNO_KEY] = work.CategoryNo.ToString("0000");
                    }
                    // �G���W���^��
                    dataRow[ENGINEMODELNM_KEY] = work.EngineModelNm;
                    // �Ԏ�i���[�J�[�R�[�h�j
                    if (work.MakerCode == 0)
                    {
                        dataRow[MAKERCODE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[MAKERCODE_KEY] = work.MakerCode.ToString("000");
                    }
                    // �Ԏ�i�Ԏ�R�[�h�j
                    if (work.ModelCode == 0)
                    {
                        dataRow[MODELCODE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[MODELCODE_KEY] = work.ModelCode.ToString("000");
                    }
                    // �Ԏ�i�ď̃R�[�h�j
                    if (work.ModelSubCode == 0)
                    {
                        dataRow[MODELSUBCODE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[MODELSUBCODE_KEY] = work.ModelSubCode.ToString("000");
                    }
                    // �Ԏ햼��
                    dataRow[MODELFULLNAME_KEY] = work.ModelFullName;
                    // �^���i�t���^�j
                    dataRow[FULLMODEL_KEY] = work.FullModel;
                    // �N��
                    if (work.FirstEntryDate == 0)
                    {
                        dataRow[FIRSTENTRYDATE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[FIRSTENTRYDATE_KEY] = dataRow[FIRSTENTRYDATE_KEY].ToString().PadLeft(6, '0');
                        dataRow[FIRSTENTRYDATE_KEY] = work.FirstEntryDate.ToString().Substring(0, 4) + "/" + work.FirstEntryDate.ToString().Substring(4);
                    }
                    // (���Y�N�� �J�n-�I��)
                    if (work.StProduceTypeOfYear == DateTime.MinValue && work.EdProduceTypeOfYear == DateTime.MinValue)
                    {
                        dataRow[STEDPRODUCETYPEOFYEAR_KEY] = string.Empty;
                    }
                    else
                    {
                        // 0:����
                        if (this._allDefSet.EraNameDispCd1 == 0)
                        {
                            if (work.StProduceTypeOfYear == DateTime.MinValue)
                            {
                                dataRow[STEDPRODUCETYPEOFYEAR_KEY] = "-" + work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                            }
                            else if (work.EdProduceTypeOfYear == DateTime.MinValue)
                            {
                                dataRow[STEDPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-";
                            }
                            else
                            {
                                dataRow[STEDPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-" + work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                            }
                        }
                        // 1:�a��
                        else
                        {
                            string stProduceTypeOfYear = this.GetProduceTypeOfYear(work.StProduceTypeOfYear);
                            string edProduceTypeOfYear = this.GetProduceTypeOfYear(work.EdProduceTypeOfYear);
                            dataRow[STEDPRODUCETYPEOFYEAR_KEY] = this.SettingProduceTypeOfYearRange(stProduceTypeOfYear, edProduceTypeOfYear);
                        }
                    }

                    // �ԑ�ԍ�
                    dataRow[FRAMENO_KEY] = work.FrameNo;
                    // (�ԑ�ԍ� �J�n-�I��)
                    if (work.StProduceFrameNo == 0 && work.EdProduceFrameNo == 0)
                    {
                        dataRow[STEDPRODUCEFRAMENO_KEY] = string.Empty;
                    }
                    else
                    {
                        if (work.StProduceFrameNo == 0)
                        {
                            dataRow[STEDPRODUCEFRAMENO_KEY] = "".PadLeft(8, ' ') + "-" + Convert.ToString(work.EdProduceFrameNo);
                        }
                        else if (work.EdProduceFrameNo == 0)
                        {
                            dataRow[STEDPRODUCEFRAMENO_KEY] = Convert.ToString(work.StProduceFrameNo) + "-" + "".PadLeft(8, ' ');
                        }
                        else
                        {
                            dataRow[STEDPRODUCEFRAMENO_KEY] = Convert.ToString(work.StProduceFrameNo).PadLeft(8, ' ') + "-" + Convert.ToString(work.EdProduceFrameNo).PadLeft(8, ' ');
                        }
                    }
                    // �J���[
                    dataRow[COLORCODE_KEY] = work.ColorCode;
                    // �g����
                    dataRow[TRIMCODE_KEY] = work.TrimCode;
                    // �^���O���[�h����
                    dataRow[MODELGRADENM_KEY] = work.ModelGradeNm;
                    // �{�f�B�[����
                    dataRow[BODYNAME_KEY] = work.BodyName;
                    // �h�A��
                    if (work.DoorCount == 0)
                    {
                        dataRow[DOORCOUNT_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[DOORCOUNT_KEY] = work.DoorCount;
                    }
                    // �G���W���^������
                    //dataRow[ENGINEMODELNM_TITLE] = work.EngineModelNm;
                    // �r�C�ʖ���
                    dataRow[ENGINEDISPLACENM_KEY] = work.EngineDisplaceNm;
                    // E�敪����
                    dataRow[EDIVNM_KEY] = work.EDivNm;
                    // �~�b�V��������
                    dataRow[TRANSMISSIONNM_KEY] = work.TransmissionNm;
                    // �쓮��������
                    dataRow[WHEELDRIVEMETHODNM_KEY] = work.WheelDriveMethodNm;
                    // �V�t�g����
                    dataRow[SHIFTNM_KEY] = work.ShiftNm;
                    // �ǉ������^�C�g���P
                    dataRow[ADDICARSPECTITLE1_KEY] = work.AddiCarSpecTitle1;
                    // �ǉ������^�C�g���Q
                    dataRow[ADDICARSPECTITLE2_KEY] = work.AddiCarSpecTitle2;
                    // �ǉ������^�C�g���R
                    dataRow[ADDICARSPECTITLE3_KEY] = work.AddiCarSpecTitle3;
                    // �ǉ������^�C�g���S
                    dataRow[ADDICARSPECTITLE4_KEY] = work.AddiCarSpecTitle4;
                    // �ǉ������^�C�g���T
                    dataRow[ADDICARSPECTITLE5_KEY] = work.AddiCarSpecTitle5;
                    // �ǉ������^�C�g���U
                    dataRow[ADDICARSPECTITLE6_KEY] = work.AddiCarSpecTitle6;
                    // �ǉ������P
                    dataRow[ADDICARSPEC1_KEY] = work.AddiCarSpec1;
                    // �ǉ������Q
                    dataRow[ADDICARSPEC2_KEY] = work.AddiCarSpec2;
                    // �ǉ������R
                    dataRow[ADDICARSPEC3_KEY] = work.AddiCarSpec3;
                    // �ǉ������S
                    dataRow[ADDICARSPEC4_KEY] = work.AddiCarSpec4;
                    // �ǉ������T
                    dataRow[ADDICARSPEC5_KEY] = work.AddiCarSpec5;
                    // �ǉ������U
                    dataRow[ADDICARSPEC6_KEY] = work.AddiCarSpec6;

                    // ���^�������ԍ�
                    if (work.NumberPlate1Code == 0)
                    {
                        dataRow[NUMBERPLATE1CODE_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[NUMBERPLATE1CODE_KEY] = work.NumberPlate1Code.ToString().PadLeft(4, '0');
                    }

                    // ���^�����ǖ���
                    dataRow[NUMBERPLATE1NAME_KEY] = work.NumberPlate1Name;
                    // �ԗ��o�^�ԍ��i��ʁj
                    dataRow[NUMBERPLATE2_KEY] = work.NumberPlate2;
                    // �ԗ��o�^�ԍ��i�J�i�j
                    dataRow[NUMBERPLATE3_KEY] = work.NumberPlate3;
                    // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                    if (work.NumberPlate4 == 0)
                    {
                        dataRow[NUMBERPLATE4_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[NUMBERPLATE4_KEY] = work.NumberPlate4;
                    }

                    // �ԗ��Ǘ��ԍ�
                    dataRow[MNGNOTEMP_KEY] = work.CarMngNo;
                    // �J���[����
                    if (string.IsNullOrEmpty(work.ColorName1))
                    {
                        work.ColorName1 = string.Empty;
                    }
                    dataRow[COLORNAME1_KEY] = work.ColorName1;
                    // �g��������
                    if (string.IsNullOrEmpty(work.TrimName))
                    {
                        work.TrimName = string.Empty;
                    }
                    // dataRow[TRIMNAME_KEY] = work.ColorName1; // DEL 2009/10/10 wuyx
                    dataRow[TRIMNAME_KEY] = work.TrimName; // ADD 2009/10/10 wuyx
                    
                    // --- ADD 2013/03/25 ---------->>>>>
                    // ���Y/�O�ԋ敪
                    if (work.DomesticForeignCode == 0)
                    {
                        dataRow[DOMESTICFOREIGNCODERF_KEY] = string.Empty;
                    }
                    else
                    {
                        dataRow[DOMESTICFOREIGNCODERF_KEY] = work.DomesticForeignCode.ToString();
                    }
                    // --- ADD 2013/03/25 ----------<<<<<

                    this.carSearchTable.Rows.Add(dataRow);

                }
                if (carMngList.Count > 0)
                {
                    this.uGrid_CarSearchList.Focus();
                    this.uGrid_CarSearchList.ActiveRow = this.uGrid_CarSearchList.Rows[0];
                    this.uGrid_CarSearchList.ActiveRow.Selected = true;
                    this.uGrid_CarSearchList.Refresh();
                    // �e�L�X�g�o��
                    this._textOutButton.SharedProps.Enabled = true;
                }
            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                // �e�L�X�g�o��
                this._textOutButton.SharedProps.Enabled = false;
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Y������f�[�^�����݂��܂���B",
                    0,
                    MessageBoxButtons.OK);
            }
            else
            {
                // �e�L�X�g�o��
                this._textOutButton.SharedProps.Enabled = false;
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "��ʌ��������Ɏ��s���܂����B",
                    0,
                    MessageBoxButtons.OK);
            }
        }
        #endregion

        #region �� ���q���i��񌟍� ��
        /// <summary>
        /// ���q���i��񌟍�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���q���i��񌟍��������s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// <br>Update Note : SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
        /// <br>Programmer  : FSI���� �G</br>
        /// <br>Date        : 2013/03/25</br>
        /// </remarks>
        private void SearchPartsProcess()
        {
            // �O���b�g���N���A
            if (this.tComboEditor_DisplayDiv.SelectedIndex == 1)
            {
                // �O���b�g���N���A
                this.carSearchTable.Clear();
                this.carPartsTable.Clear();
                this.carPartsTotalTable.Clear();
                this.carSpecTable.Clear();
                this.uGrid_CarSearchList.Visible = false;
                this.uGrid_CarPartsList.Visible = true;
                this.uGrid_CarPartsTotalList.Visible = false;
            }
            else if (this.tComboEditor_DisplayDiv.SelectedIndex == 2)
            {
                // �O���b�g���N���A
                this.carSearchTable.Clear();
                this.carPartsTable.Clear();
                this.carPartsTotalTable.Clear();
                this.carSpecTable.Clear();
                this.uGrid_CarSearchList.Visible = false;
                this.uGrid_CarPartsList.Visible = false;
                this.uGrid_CarPartsTotalList.Visible = true;

                this.uLabel_ModelDesignationNoData.Text = string.Empty;
                this.uLabel_ModelKindNo.Text = string.Empty;
                this.uLabel_EngineModelNmData.Text = string.Empty;
                this.uLabel_FullModelTitleInfoData.Text = string.Empty;
                this.uLabel_ModelMaker.Text = string.Empty;
                this.uLabel_ModelCode.Text = string.Empty;
                this.uLabel_ModelSubCode.Text = string.Empty;
                this.uLabel_ModelName.Text = string.Empty;
                this.tDateEdit_FirstEntryDate.Clear();
                this.uLabel_FirstEntryDateRange.Text = string.Empty;
                this.uLabel_ColorNoData.Text = string.Empty;
                this.uLabel_ProduceFrameNoData.Text = string.Empty;
                this.uLabel_ProduceFrameNoRange.Text = string.Empty;
                this.uLabel_TrimNoData.Text = string.Empty;

                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
                this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
                this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;
            }

            // ���q���N���A
            this.CarInfoClear();
            CarInfoConditionWorkWork carInfoConditionWorkWork = new CarInfoConditionWorkWork();

            if (this._customerCode != this.tNedit_CustomerCode.GetInt()
                || !this._fullModel.Equals(this.tEdit_FullModel.Text)
                || this._fullModelCon != this.tComboEditor_FullModelFuzzy.SelectedIndex
                || !this._carMngNo.Equals(this.tEdit_CarMngCode.Text)
                || this._carMngNoCon != this.tComboEditor_CarMngCode.SelectedIndex)
            {
                this._carMngNoTemp = 0;
                this._customerCode = this.tNedit_CustomerCode.GetInt();
                this._fullModel = this.tEdit_FullModel.Text;
                this._fullModelCon = this.tComboEditor_FullModelFuzzy.SelectedIndex;
                this._carMngNo = this.tEdit_CarMngCode.Text;
                this._carMngNoCon = this.tComboEditor_CarMngCode.SelectedIndex;
            }
            // ���_�R�[�h
            carInfoConditionWorkWork.SectionCode = this.tEdit_SectionCodeAllowZero.Text;
            // ���Ӑ�R�[�h
            carInfoConditionWorkWork.CustomerCode = this.tNedit_CustomerCode.GetInt();
            // ��ƃR�[�h
            carInfoConditionWorkWork.EnterpriseCode = _enterpriseCode;
            // �Ǘ��ԍ�
            carInfoConditionWorkWork.CarMngCode = this.tEdit_CarMngCode.Text.Trim();
            // �Ǘ��ԍ������敪
            carInfoConditionWorkWork.CarMngCodeDiv = this.tComboEditor_CarMngCode.SelectedIndex;
            // ������i�J�n�j
            carInfoConditionWorkWork.StSalesDate = this.tDateEdit_SalesDateSt.GetLongDate();
            // ������i�I���j
            carInfoConditionWorkWork.EdSalesDate = this.tDateEdit_SalesDateEd.GetLongDate();
            // ���͓��i�J�n�j
            carInfoConditionWorkWork.StInputDate = this.tDateEdit_AddUpADateSt.GetLongDate();
            // ���͓��i�J�n�j
            carInfoConditionWorkWork.EdInputDate = this.tDateEdit_AddUpADateEd.GetLongDate();
            // �^��
            carInfoConditionWorkWork.FullModel = this.tEdit_FullModel.Text.Trim();
            // �^�������敪
            carInfoConditionWorkWork.FullModelDiv = this.tComboEditor_FullModelFuzzy.SelectedIndex;
            // ���q���l
            carInfoConditionWorkWork.CarNote = this.tEdit_SlipNote.Text.Trim();
            // ���q���l�����敪
            carInfoConditionWorkWork.CarNoteDiv = this.tComboEditor_SlipNoteFuzzy.SelectedIndex;
            // ��ٰ�ߺ���
            carInfoConditionWorkWork.BLGroupCode = this._swBLGroupCode;
            // BL�R�[�h
            carInfoConditionWorkWork.BLGoodsCode = this._swBLGoodsCode;
            // �i��
            carInfoConditionWorkWork.GoodsName = this.tEdit_GoodsName.Text.Trim();
            // �i�������敪
            carInfoConditionWorkWork.GoodsNameDiv = this.tComboEditor_GoodsNameFuzzy.SelectedIndex;
            // �i��
            carInfoConditionWorkWork.GoodsNo = this.tEdit_GoodsNo.Text.Trim();
            // �i�Ԍ����敪
            carInfoConditionWorkWork.GoodsNoDiv = this.tComboEditor_GoodsNoFuzzy.SelectedIndex;
            // �݌Ɏ��敪
            carInfoConditionWorkWork.SalesOrderDivCd = this.tComboEditor_SalesOrderDivCd.SelectedIndex;
            // �q��
            carInfoConditionWorkWork.WarehouseCode = this._swWarehouseCd;
            // �\���敪
            carInfoConditionWorkWork.DispDiv = this.tComboEditor_DisplayDiv.SelectedIndex;
            // �ԗ��Ǘ��ԍ�
            carInfoConditionWorkWork.CarMngNo = this._carMngNoTemp;

            object carInfoConditionWorkWorkObj = (object)carInfoConditionWorkWork;
            ArrayList carMngWorkList = new ArrayList();

            int status = _carPartDisplayAcs.CarPartsInfoSearch(carInfoConditionWorkWorkObj, ref carMngWorkList);
            int i = 0; // ADD 2009/10/10
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                DataRow dataRow;
                #region �o�ו��i
                // �\���敪�u�o�ו��i�v��
                if (this.tComboEditor_DisplayDiv.SelectedIndex == 1)
                {
                    foreach (CarShipmentPartsDispWork work in carMngWorkList)
                    {
                        dataRow = this.carPartsTable.NewRow();
                        // �`�[���t
                        if (work.SalesDate == DateTime.MinValue)
                        {
                            dataRow[SALESDATE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[SALESDATE_KEY] = work.SalesDate.ToString(DATEFORMAT_YYYYMMDD);
                        }
                        // �i��
                        dataRow[GOODSNAME_KEY] = work.GoodsName;
                        // -------ADD BY �����@on 2012/08/09 for Redmine#31532------->>>>>>>
                        //�s�ԍ�
                        dataRow[ROWNO_KEY] = work.RowNo;
                        // -------ADD BY �����@on 2012/08/09 for Redmine#31532-------<<<<<<<
                        // �i��
                        dataRow[GOODSNO_KEY] = work.GoodsNo;
                        // ���[�J�[
                        dataRow[GOODSMAKERNAME_KEY] = work.MakerName;
                        // BL�R�[�h
                        // --- UPD 2009/09/27 -------------->>>
                        if (work.BLGoodsCode != 0)
                        {
                            dataRow[BLGOODSCD_KEY] = work.BLGoodsCode.ToString("d5");
                        }
                        else
                        {
                            dataRow[BLGOODSCD_KEY] = string.Empty;
                        }
                        // --- UPD 2009/09/27 --------------<<<
                        // �݌Ɏ��敪
                        if (work.SalesOrderDivCd == 0)
                        {
                            dataRow[SALESORDERDIVCD_KEY] = "���";
                        }
                        else if (work.SalesOrderDivCd == 1)
                        {
                            dataRow[SALESORDERDIVCD_KEY] = "�݌�";
                        }

                        // --- UPD 2009/10/10 ------------>>>>>
                        // �Ǘ��ԍ�
                        dataRow[MNGNO_KEY] = work.CarMngCode;
                        // �������ʃe�[�u��1.�艿�i�Ŕ��C�����j
                        dataRow[LISTPRICETAXEXCFL_KEY] = work.ListPriceTaxExcFl.ToString("#,##0");
                        // ����
                        dataRow[SHIPMENTCNT_KEY] = douToStrChange(work.ShipmentCnt);
                        // ���P��
                        dataRow[SALESUNPRCTAXEXCFL_KEY] = douToStrChange(work.SalesUnPrcTaxExcFl);
                        // ������z
                        long salesMoneyTax = work.SalesMoneyTaxExc;
                        dataRow[SALESMONEYTAXEXC_KEY] = salesMoneyTax.ToString("#,##0");
                        // ���P��
                        dataRow[SALESUNITCOST_KEY] = douToStrChange(work.SalesUnitCost);
                        // �e��
                        long salesMoney;
                        //���㗚�𖾍׃f�[�^
                        if (-999999999 != work.Cost)
                        {
                            salesMoney = work.SalesMoneyTaxExc - work.Cost;
                            dataRow[SALESMONEYTAXEXC_COST_KEY] = salesMoney.ToString("#,##0");
                        }
                        else
                        {
                            //���q���i�f�[�^(�R���o�[�g)
                            // salesMoney = work.SalesMoneyTaxExc - Convert.ToInt64(work.SalesUnitCost * work.ShipmentCnt);
                            //salesMoney = work.GrossProfit;
                            dataRow[SALESMONEYTAXEXC_COST_KEY] = work.GrossProfit.ToString("#,##0");
                        }
                        // �e���� 
                        double salesMoneyRate;
                        try
                        {
                            if (-999999999 != work.Cost)
                            {
                                // �e�� �� ������z ���Z�b�g
                                salesMoneyRate = Convert.ToDouble((work.SalesMoneyTaxExc - work.Cost)) / Convert.ToDouble(salesMoneyTax) * 100;
                            }
                            else
                            {
                                // �e�� �� ������z ���Z�b�g
                                salesMoneyRate = Convert.ToDouble(work.GrossProfit) / Convert.ToDouble(salesMoneyTax) * 100;
                            }
                            // �����_�ȉ����ʂ܂ŃZ�b�g�i��R�ʂ��l�̌ܓ��j
                            FractionCalculate.FracCalcMoney(salesMoneyRate, 0.01, 2, out salesMoneyRate);
                        }
                        catch
                        {
                            salesMoneyRate = 0.00;
                        }
                        dataRow[COST_SALESMONEYTAXEXC_KEY] = douToStrChange(salesMoneyRate);
                        // --- UPD 2009/10/10 ------------<<<<<

                        // ���l
                        dataRow[SLIPNOTE_KEY] = work.SlipNote;
                        // ���q���l
                        dataRow[CARNOTE_PARTS_KEY] = work.CarNote;
                        // �`�[�ԍ�
                        dataRow[SALESSLIPNUM_KEY] = work.SalesSlipNum;
                        // ���s����
                        dataRow[MILEAGE_PARTS_KEY] = work.Mileage.ToString("#,##0");
                        // �^��1-2
                        if (string.IsNullOrEmpty(work.SeriesModel) && string.IsNullOrEmpty(work.CategorySignModel))
                        {
                            dataRow[MODEL1TO2_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MODEL1TO2_KEY] = work.SeriesModel + '-' + work.CategorySignModel;
                        }
                        // ��ʕ\���p
                        // �^���i�V���[�Y�^���{�^���i�ޕʋL���j�j
                        if (string.IsNullOrEmpty(work.SeriesModel) && string.IsNullOrEmpty(work.CategorySignModel))
                        {
                            dataRow[KINDMODEL_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[KINDMODEL_KEY] = work.SeriesModel + '-' + work.CategorySignModel;
                        }
                        // �^���w��ԍ�
                        if (work.ModelDesignationNo == 0)
                        {
                            dataRow[MODELDESIGNATIONNO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MODELDESIGNATIONNO_KEY] = work.ModelDesignationNo.ToString("00000");
                        }
                        // �ޕʔԍ�
                        if (work.CategoryNo == 0)
                        {
                            dataRow[CATEGORYNO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[CATEGORYNO_KEY] = work.CategoryNo.ToString("0000");
                        }
                        // �G���W���^��
                        dataRow[ENGINEMODELNM_KEY] = work.EngineModelNm;
                        // �Ԏ�i���[�J�[�R�[�h�j
                        if (work.MakerCode == 0)
                        {
                            dataRow[MAKERCODE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MAKERCODE_KEY] = work.MakerCode.ToString("000");
                        }
                        // �Ԏ�i�Ԏ�R�[�h�j
                        if (work.ModelCode == 0)
                        {
                            dataRow[MODELCODE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MODELCODE_KEY] = work.ModelCode.ToString("000");
                        }
                        // �Ԏ�i�ď̃R�[�h�j
                        if (work.ModelSubCode == 0)
                        {
                            dataRow[MODELSUBCODE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[MODELSUBCODE_KEY] = work.ModelSubCode.ToString("000");
                        }
                        // �Ԏ햼��
                        dataRow[MODELFULLNAME_KEY] = work.ModelFullName;
                        // �^���i�t���^�j
                        dataRow[FULLMODEL_KEY] = work.FullModel;
                        // �N��
                        if (work.FirstEntryDate == DateTime.MinValue)
                        {
                            dataRow[FIRSTENTRYDATE_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[FIRSTENTRYDATE_KEY] = work.FirstEntryDate.ToString("yyyy/MM");
                        }
                        // (���Y�N�� �J�n-�I��)
                        if (work.StProduceTypeOfYear == DateTime.MinValue && work.EdProduceTypeOfYear == DateTime.MinValue)
                        {
                            dataRow[STEDPRODUCETYPEOFYEAR_KEY] = string.Empty;
                        }
                        else
                        {
                            // 0:����
                            if (this._allDefSet.EraNameDispCd1 == 0)
                            {
                                if (work.StProduceTypeOfYear == DateTime.MinValue)
                                {
                                    dataRow[STEDPRODUCETYPEOFYEAR_KEY] = "-" + work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                                }
                                else if (work.EdProduceTypeOfYear == DateTime.MinValue)
                                {
                                    dataRow[STEDPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-";
                                }
                                else
                                {
                                    dataRow[STEDPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-" + work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                                }
                            }
                            // 1:�a��
                            else
                            {
                                string stProduceTypeOfYear = this.GetProduceTypeOfYear(work.StProduceTypeOfYear);
                                string edProduceTypeOfYear = this.GetProduceTypeOfYear(work.EdProduceTypeOfYear);
                                dataRow[STEDPRODUCETYPEOFYEAR_KEY] = this.SettingProduceTypeOfYearRange(stProduceTypeOfYear, edProduceTypeOfYear);
                            }
                        }
                        // �ԑ�ԍ�
                        if (string.IsNullOrEmpty(work.FrameNo) || work.FrameNo.Trim() == "0")
                        {
                            dataRow[FRAMENO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[FRAMENO_KEY] = work.FrameNo;
                        }

                        // (�ԑ�ԍ� �J�n-�I��)
                        if (work.StProduceFrameNo == 0 && work.EdProduceFrameNo == 0)
                        {
                            dataRow[STEDPRODUCEFRAMENO_KEY] = string.Empty;
                        }
                        else
                        {
                            if (work.StProduceFrameNo == 0)
                            {
                                dataRow[STEDPRODUCEFRAMENO_KEY] = "".PadLeft(8, ' ') + "-" + Convert.ToString(work.EdProduceFrameNo);
                            }
                            else if (work.EdProduceFrameNo == 0)
                            {
                                dataRow[STEDPRODUCEFRAMENO_KEY] = Convert.ToString(work.StProduceFrameNo) + "-" + "".PadLeft(8, ' ');
                            }
                            else
                            {
                                dataRow[STEDPRODUCEFRAMENO_KEY] = Convert.ToString(work.StProduceFrameNo).PadLeft(8, ' ') + "-" + Convert.ToString(work.EdProduceFrameNo).PadLeft(8, ' ');
                            }
                        }
                        // �J���[
                        dataRow[COLORCODE_KEY] = work.ColorCode;
                        // �g����
                        dataRow[TRIMCODE_KEY] = work.TrimCode;
                        // �^���O���[�h����
                        dataRow[MODELGRADENM_KEY] = work.ModelGradeNm;
                        // �{�f�B�[����
                        dataRow[BODYNAME_KEY] = work.BodyName;
                        // �h�A��
                        if (work.DoorCount == 0)
                        {
                            dataRow[DOORCOUNT_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[DOORCOUNT_KEY] = work.DoorCount;
                        }
                        // �G���W���^������
                        //dataRow[ENGINEMODELNM_TITLE] = work.EngineModelNm;
                        // �r�C�ʖ���
                        dataRow[ENGINEDISPLACENM_KEY] = work.EngineDisplaceNm;
                        // E�敪����
                        dataRow[EDIVNM_KEY] = work.EDivNm;
                        // �~�b�V��������
                        dataRow[TRANSMISSIONNM_KEY] = work.TransmissionNm;
                        // �쓮��������
                        dataRow[WHEELDRIVEMETHODNM_KEY] = work.WheelDriveMethodNm;
                        // �V�t�g����
                        dataRow[SHIFTNM_KEY] = work.ShiftNm;
                        // �ǉ������^�C�g���P
                        dataRow[ADDICARSPECTITLE1_KEY] = work.AddiCarSpecTitle1;
                        // �ǉ������^�C�g���Q
                        dataRow[ADDICARSPECTITLE2_KEY] = work.AddiCarSpecTitle2;
                        // �ǉ������^�C�g���R
                        dataRow[ADDICARSPECTITLE3_KEY] = work.AddiCarSpecTitle3;
                        // �ǉ������^�C�g���S
                        dataRow[ADDICARSPECTITLE4_KEY] = work.AddiCarSpecTitle4;
                        // �ǉ������^�C�g���T
                        dataRow[ADDICARSPECTITLE5_KEY] = work.AddiCarSpecTitle5;
                        // �ǉ������^�C�g���U
                        dataRow[ADDICARSPECTITLE6_KEY] = work.AddiCarSpecTitle6;
                        // �ǉ������P
                        dataRow[ADDICARSPEC1_KEY] = work.AddiCarSpec1;
                        // �ǉ������Q
                        dataRow[ADDICARSPEC2_KEY] = work.AddiCarSpec2;
                        // �ǉ������R
                        dataRow[ADDICARSPEC3_KEY] = work.AddiCarSpec3;
                        // �ǉ������S
                        dataRow[ADDICARSPEC4_KEY] = work.AddiCarSpec4;
                        // �ǉ������T
                        dataRow[ADDICARSPEC5_KEY] = work.AddiCarSpec5;
                        // �ǉ������U
                        dataRow[ADDICARSPEC6_KEY] = work.AddiCarSpec6;


                        // ���[�J�[�R�[�h
                        if (work.GoodsMakerCd == 0)
                        {
                            dataRow[GOODSMAKERCD_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[GOODSMAKERCD_KEY] = work.GoodsMakerCd.ToString("d4");
                        }

                        // �J���[����1
                        dataRow[COLORNAME1_KEY] = work.ColorName1;
                        // �g��������
                        dataRow[TRIMNAME_KEY] = work.TrimName;
                        // ���^�������ԍ�
                        dataRow[NUMBERPLATE1CODE_KEY] = work.NumberPlate1Code;
                        // ���^�����ǖ���
                        dataRow[NUMBERPLATE1NAME_KEY] = work.NumberPlate1Name;
                        // �ԗ��o�^�ԍ��i��ʁj
                        dataRow[NUMBERPLATE2_KEY] = work.NumberPlate2;
                        // �ԗ��o�^�ԍ��i�J�i�j
                        dataRow[NUMBERPLATE3_KEY] = work.NumberPlate3;
                        // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        dataRow[NUMBERPLATE4_KEY] = work.NumberPlate4;
                        // ���Y�ԑ�ԍ��J�n
                        if (work.StProduceFrameNo == 0)
                        {
                            dataRow[STPRODUCEFRAMENO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[STPRODUCEFRAMENO_KEY] = work.StProduceFrameNo;
                        }
                        // ���Y�ԑ�ԍ��I��
                        if (work.EdProduceFrameNo == 0)
                        {
                            dataRow[EDPRODUCEFRAMENO_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[EDPRODUCEFRAMENO_KEY] = work.EdProduceFrameNo;
                        }
                        // �J�n���Y�N��
                        if (work.StProduceTypeOfYear == DateTime.MinValue)
                        {
                            dataRow[STPRODUCETYPEOFYEAR_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[STPRODUCETYPEOFYEAR_KEY] = work.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMMDD);
                        }
                        // �I�����Y�N��
                        if (work.EdProduceTypeOfYear == DateTime.MinValue)
                        {
                            dataRow[EDPRODUCETYPEOFYEAR_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[EDPRODUCETYPEOFYEAR_KEY] = work.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMMDD);
                        }
                        // --- ADD 2013/03/25 ---------->>>>>
                        // ���Y/�O�ԋ敪
                        if (work.DomesticForeignCode == 0)
                        {
                            dataRow[DOMESTICFOREIGNCODERF_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[DOMESTICFOREIGNCODERF_KEY] = work.DomesticForeignCode.ToString();
                        }
                        // --- ADD 2013/03/25 ----------<<<<<

                        this.carPartsTable.Rows.Add(dataRow);

                        this.uGrid_CarPartsList.Refresh();

                        //-----------ADD 2009/10/10----->>>>>
                        i++;

                        if (work.ShipmentCnt < 0)
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarPartsList.DisplayLayout.Bands[0];
                            if (editBand == null) return;

                            UltraGridRow ultraRow = this.uGrid_CarPartsList.Rows[i-1];
                            foreach (UltraGridCell ultraCell in ultraRow.Cells)
                            {
                                ultraCell.Appearance.ForeColor = Color.Red;
                            }
                        }
                        //-----------ADD 2009/10/10-----<<<<<

                    }

                    if (carMngWorkList.Count > 0)
                    {
                        this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = false;
                        autoColumnAdjust(false, 1);
                        this.uGrid_CarPartsList.Focus();
                        this.uGrid_CarPartsList.ActiveRow = this.uGrid_CarPartsList.Rows[0];
                        this.uGrid_CarPartsList.ActiveRow.Selected = true;
                        this.uGrid_CarPartsList.Refresh();
                        // �e�L�X�g�o��
                        this._textOutButton.SharedProps.Enabled = true;
                    }
                }
                #endregion �o�ו��i

                #region �o�ו��i�i���v�j
                // �\���敪�u�o�ו��i�i���v�j�v��
                else if (this.tComboEditor_DisplayDiv.SelectedIndex == 2)
                {
                    foreach (CarShipmentPartsDispWork work in carMngWorkList)
                    {
                        dataRow = this.carPartsTotalTable.NewRow();
                        // �i��
                        dataRow[GOODSNAME_TOTAL_KEY] = work.GoodsName;
                        // �i��
                        dataRow[GOODSNO_TOTAL_KEY] = work.GoodsNo;
                        // ���[�J�[
                        dataRow[GOODSMAKERNAME_TOTAL_KEY] = work.MakerName;
                        // BL�R�[�h
                        // --- UPD 2009/09/27 -------------->>>
                        if (work.BLGoodsCode != 0)
                        {
                            dataRow[BLGOODSCODE_TOTAL_KEY] = work.BLGoodsCode.ToString("d5");
                        }
                        else
                        {
                            dataRow[BLGOODSCODE_TOTAL_KEY] = string.Empty;
                        }
                        // --- UPD 2009/09/27 --------------<<<
                        // ����
                        dataRow[SHIPMENTCNT_TOTAL_KEY] = douToStrChange(work.ShipmentTotalCnt);
                            // --- UPD 2009/10/10 -------------->>>>>
                        // ������z
                        dataRow[SALESMONEYTAXEXC_TOTAL_KEY] = work.SalesMoneyTaxExcTotal.ToString("#,##0");
                        // �o�׉�
                        dataRow[COUNT_TOTAL_KEY] = work.ShipmentCntTotal.ToString("#,##0");
                        // --- UPD 2009/10/10 --------------<<<<<
                        // �q��
                        dataRow[WAREHOUSE_TOTAL_KEY] = work.WarehouseName;
                        // �I��
                        dataRow[SHELFNO_TOTAL_KEY] = work.WarehouseShelfNo;
                        // ���݌ɐ�
                        dataRow[SHIPMENTPOSCNT_TOTAL_KEY] = douToStrChange(work.ShipmentPosCnt);
                        // ���ʁi�݌Ɂj
                        dataRow[SHIPMENTCNTIN_TOTAL_KEY] = douToStrChange(work.ShipmentCntInTotal);
                        // ���ʁi���j
                        dataRow[SHIPMENTCNTOUT_TOTAL_KEY] = douToStrChange(work.ShipmentCntOutTotal);
                        // ���[�J�[�R�[�h
                        if (work.GoodsMakerCd == 0)
                        {
                            dataRow[GOODSMAKERCD_TOTAL_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[GOODSMAKERCD_TOTAL_KEY] = work.GoodsMakerCd.ToString("d4");
                        }
                        // �q�ɃR�[�h
                        if (string.IsNullOrEmpty(work.WarehouseCode) || work.WarehouseCode.Trim().Equals("0"))
                        {
                            dataRow[WAREHOUSECODE_TOTAL_KEY] = string.Empty;
                        }
                        else
                        {
                            dataRow[WAREHOUSECODE_TOTAL_KEY] = work.WarehouseCode;
                        }

                        this.carPartsTotalTable.Rows.Add(dataRow);

                        this.uGrid_CarPartsTotalList.Refresh();
                        //-----------ADD 2009/10/10----->>>>>
                        i++;

                        if (work.ShipmentTotalCnt < 0)
                        {
                            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_CarPartsList.DisplayLayout.Bands[0];
                            if (editBand == null) return;

                            UltraGridRow ultraRow = this.uGrid_CarPartsTotalList.Rows[i - 1];
                            foreach (UltraGridCell ultraCell in ultraRow.Cells)
                            {
                                ultraCell.Appearance.ForeColor = Color.Red;
                            }
                        }
                        //-----------ADD 2009/10/10-----<<<<<

                    }
                    if (carMngWorkList.Count > 0)
                    {
                        this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked = false;
                        autoColumnAdjust(false, 2);
                        this.uGrid_CarPartsTotalList.Focus();
                        this.uGrid_CarPartsTotalList.ActiveRow = this.uGrid_CarPartsTotalList.Rows[0];
                        this.uGrid_CarPartsTotalList.ActiveRow.Selected = true;
                        this.uGrid_CarPartsTotalList.Refresh();
                        // �e�L�X�g�o��
                        this._textOutButton.SharedProps.Enabled = true;
                    }
                }
                #endregion �o�ו��i�i���v�j

            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                // �e�L�X�g�o��
                this._textOutButton.SharedProps.Enabled = false;
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�Y������f�[�^�����݂��܂���B",
                    0,
                    MessageBoxButtons.OK);

            }
            else
            {
                // �e�L�X�g�o��
                this._textOutButton.SharedProps.Enabled = false;
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "��ʌ��������Ɏ��s���܂����B",
                    0,
                    MessageBoxButtons.OK);
            }
        }
        #endregion

        #region �� ���q���I��ω��������C�x���g ��
        /// <summary>
        /// ���q���I��ω��������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �I��ω����ɔ������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.09.10</br>
        /// <br>Update Note : SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
        /// <br>Programmer  : FSI���� �G</br>
        /// <br>Date        : 2013/03/25</br>
        /// </remarks>
        private void uGrid_CarSearchList_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            Type type = e.Type;

            // �s�I���̏ꍇ
            if (type.Name.Equals("UltraGridRow"))
            {
                if (this.uGrid_CarSearchList.ActiveRow == null) return;
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_CarSearchList.ActiveRow;
                //// ���Ӑ�R�[�h
                //this.tNedit_CustomerCode.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERCODE_TITLE]);
                //// ���Ӑ旪��
                //this.uLabel_CustomerName.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERSUBNAME_TITLE]);
                //------UPD 2009/10/20------>>>>>
                // �^���w��ԍ�
                this.uLabel_ModelDesignationNoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELDESIGNATIONNO_KEY].Value.ToString();
                // �ޕʔԍ�
                this.uLabel_ModelKindNo.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[CATEGORYNO_KEY].Value.ToString();
                // �G���W���^��
                this.uLabel_EngineModelNmData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[ENGINEMODELNM_KEY].Value.ToString();
                // �^��
                this.uLabel_FullModelTitleInfoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[FULLMODEL_KEY].Value.ToString();
                // �Ԏ�i���[�J�[�R�[�h�j
                this.uLabel_ModelMaker.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MAKERCODE_KEY].Value.ToString();
                // �Ԏ�i�Ԏ�R�[�h�j
                this.uLabel_ModelCode.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELCODE_KEY].Value.ToString();
                // �Ԏ�i�ď̃R�[�h�j
                this.uLabel_ModelSubCode.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELSUBCODE_KEY].Value.ToString();
                // �Ԏ햼��
                this.uLabel_ModelName.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELFULLNAME_KEY].Value.ToString();
                // �N��
                string firstEntryYearMonth = this.uGrid_CarSearchList.Rows[row.Index].Cells[FIRSTENTRYDATE_KEY].Value.ToString().Replace("/", "");
                if (!string.IsNullOrEmpty(firstEntryYearMonth))
                {
                    this.tDateEdit_FirstEntryDate.SetLongDate(Int32.Parse(firstEntryYearMonth) * 100 + 1);
                }
                else
                {
                    this.tDateEdit_FirstEntryDate.SetLongDate(0);
                }
                // (���Y�N�� �J�n-�I��)
                this.uLabel_FirstEntryDateRange.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[STEDPRODUCETYPEOFYEAR_KEY].Value.ToString();
                // �ԑ�ԍ�
                this.uLabel_ProduceFrameNoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[FRAMENO_KEY].Value.ToString();
                // �ԑ�ԍ� �J�n-�I��
                this.uLabel_ProduceFrameNoRange.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[STEDPRODUCEFRAMENO_KEY].Value.ToString();
                // �J���[
                this.uLabel_ColorNoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[COLORCODE_KEY].Value.ToString();
                // �g����
                this.uLabel_TrimNoData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[TRIMCODE_KEY].Value.ToString();
                //------ADD 2009/10/10-------->>>>>
                // ���q���l
                // this.tEdit_SlipNote.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CARNOTE_KEY]); // DEL 2009/10/19  Redmine567
                // �Ǘ��ԍ�
                this.uLabel_CarMngCodeData.Text = this.uGrid_CarSearchList.Rows[row.Index].Cells[MNGNO_KEY].Value.ToString();
                //------ADD 2009/10/10--------<<<<<

                // --- ADD 2013/03/25 ---------->>>>>
                int divValue = 0;
                Int32.TryParse(this.uGrid_CarSearchList.Rows[row.Index].Cells[DOMESTICFOREIGNCODERF_KEY].Value.ToString(), out divValue);
                if (divValue == FOREIGNCODERF_DIV)
                {
                    this.uLabel_ProduceFrameNoRange.Visible = false;
                }
                else
                {
                    this.uLabel_ProduceFrameNoRange.Visible = true;
                }
                // --- ADD 2013/03/25 ----------<<<<<

                this.carSpecTable.Clear();

                DataRow dataRow;
                dataRow = this.carSpecTable.NewRow();
                // �O���[�h
                dataRow[MODELGRADENM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[MODELGRADENM_KEY].Value.ToString();
                // �{�f�B
                dataRow[BODYNAME_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[BODYNAME_KEY].Value.ToString();
                // �h�A
                dataRow[DOORCOUNT_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[DOORCOUNT_KEY].Value.ToString();
                // �G���W��
                dataRow[ENGINEMODELNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ENGINEMODELNM_KEY].Value.ToString();
                // �r�C��
                dataRow[ENGINEDISPLACENM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ENGINEDISPLACENM_KEY].Value.ToString();
                // �d�敪
                dataRow[EDIVNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[EDIVNM_KEY].Value.ToString();
                // �~�b�V����
                dataRow[TRANSMISSIONNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[TRANSMISSIONNM_KEY].Value.ToString();
                // �쓮����
                dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[WHEELDRIVEMETHODNM_KEY].Value.ToString();
                // �V�t�g
                dataRow[SHIFTNM_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[SHIFTNM_KEY].Value.ToString();

                // �ǉ������^�C�g���P
                string AddiCarSpecTitle1 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE1_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle1))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = AddiCarSpecTitle1;
                    // �ǉ������P
                    dataRow[ADDICARSPECTITLE1_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC1_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE1_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���Q
                string AddiCarSpecTitle2 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE2_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle2))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = AddiCarSpecTitle2;
                    // �ǉ������Q
                    dataRow[ADDICARSPECTITLE2_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC2_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE2_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���R
                string AddiCarSpecTitle3 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE3_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle3))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = AddiCarSpecTitle3;
                    // �ǉ������R
                    dataRow[ADDICARSPECTITLE3_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC3_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE3_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���S
                string AddiCarSpecTitle4 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE4_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle4))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = AddiCarSpecTitle4;
                    // �ǉ������S
                    dataRow[ADDICARSPECTITLE4_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC4_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE4_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���T
                string AddiCarSpecTitle5 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE5_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle5))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = AddiCarSpecTitle5;
                    // �ǉ������T
                    dataRow[ADDICARSPECTITLE5_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC5_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE5_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���U
                string AddiCarSpecTitle6 = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPECTITLE6_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle6))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = AddiCarSpecTitle6;
                    // �ǉ������U
                    dataRow[ADDICARSPECTITLE6_INFO_TITLE] = this.uGrid_CarSearchList.Rows[row.Index].Cells[ADDICARSPEC6_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE6_INFO_TITLE] = string.Empty;
                }
                //------UPD 2009/10/20------<<<<<

                this.carSpecTable.Rows.Add(dataRow);
                this.uGrid_CarSpec.Refresh();

            }
        }
        #endregion

        #region �� ���q���i���I��ω��������C�x���g ��
        /// <summary>
        /// ���q���i���I��ω��������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �I��ω����ɔ������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.09.10</br>
        /// <br>Update Note : SPK�ԑ�ԍ�������Ή��ɔ����ԑ�ԍ��\�����C�A�E�g�̏C��</br>
        /// <br>Programmer  : FSI���� �G</br>
        /// <br>Date        : 2013/03/25</br>
        /// </remarks>
        private void uGrid_CarPartsList_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            Type type = e.Type;

            // �s�I���̏ꍇ
            if (type.Name.Equals("UltraGridRow"))
            {
                if (this.uGrid_CarPartsList.ActiveRow == null) return;
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_CarPartsList.ActiveRow;
                //// ���Ӑ�R�[�h
                //this.tNedit_CustomerCode.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERCODE_TITLE]);
                //// ���Ӑ旪��
                //this.uLabel_CustomerName.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERSUBNAME_TITLE]);
                //------UPD 2009/10/20------>>>>>
                // �^���w��ԍ�
                this.uLabel_ModelDesignationNoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELDESIGNATIONNO_KEY].Value.ToString();
                // �ޕʔԍ�
                this.uLabel_ModelKindNo.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[CATEGORYNO_KEY].Value.ToString();
                // �G���W���^��
                this.uLabel_EngineModelNmData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[ENGINEMODELNM_KEY].Value.ToString();
                // �^��
                this.uLabel_FullModelTitleInfoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[FULLMODEL_KEY].Value.ToString();
                // �Ԏ�i���[�J�[�R�[�h�j
                this.uLabel_ModelMaker.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MAKERCODE_KEY].Value.ToString();
                // �Ԏ�i�Ԏ�R�[�h�j
                this.uLabel_ModelCode.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELCODE_KEY].Value.ToString();
                // �Ԏ�i�ď̃R�[�h�j
                this.uLabel_ModelSubCode.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELSUBCODE_KEY].Value.ToString();
                // �Ԏ햼��
                this.uLabel_ModelName.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELFULLNAME_KEY].Value.ToString();
                // �N��
                string firstEntryYearMonth = this.uGrid_CarPartsList.Rows[row.Index].Cells[FIRSTENTRYDATE_KEY].Value.ToString().Replace("/", "");
                if (!string.IsNullOrEmpty(firstEntryYearMonth))
                {
                    this.tDateEdit_FirstEntryDate.SetLongDate(Int32.Parse(firstEntryYearMonth)*100+1);
                }
                else
                {
                    this.tDateEdit_FirstEntryDate.SetLongDate(0);
                }
                // (���Y�N�� �J�n-�I��)
                this.uLabel_FirstEntryDateRange.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[STEDPRODUCETYPEOFYEAR_KEY].Value.ToString();
                // �ԑ�ԍ�
                this.uLabel_ProduceFrameNoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[FRAMENO_KEY].Value.ToString();
                // �ԑ�ԍ� �J�n-�I��
                this.uLabel_ProduceFrameNoRange.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[STEDPRODUCEFRAMENO_KEY].Value.ToString();
                // �J���[
                this.uLabel_ColorNoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[COLORCODE_KEY].Value.ToString();
                // �g����
                this.uLabel_TrimNoData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[TRIMCODE_KEY].Value.ToString();

                //-------ADD 2009/10/10--------->>>>>
                // �Ǘ��ԍ�
                this.uLabel_CarMngCodeData.Text = this.uGrid_CarPartsList.Rows[row.Index].Cells[MNGNO_KEY].Value.ToString();
                //-------ADD 2009/10/10---------<<<<<

                // --- ADD 2013/03/25 ---------->>>>>
                int divValue = 0;
                Int32.TryParse(this.uGrid_CarPartsList.Rows[row.Index].Cells[DOMESTICFOREIGNCODERF_KEY].Value.ToString(), out divValue);
                if (divValue == FOREIGNCODERF_DIV)
                {
                    this.uLabel_ProduceFrameNoRange.Visible = false;
                }
                else
                {
                    this.uLabel_ProduceFrameNoRange.Visible = true;
                }
                // --- ADD 2013/03/25 ----------<<<<<

                this.carSpecTable.Clear();

                DataRow dataRow;
                dataRow = this.carSpecTable.NewRow();
                // �O���[�h
                dataRow[MODELGRADENM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[MODELGRADENM_KEY].Value.ToString();
                // �{�f�B
                dataRow[BODYNAME_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[BODYNAME_KEY].Value.ToString();
                // �h�A
                dataRow[DOORCOUNT_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[DOORCOUNT_KEY].Value.ToString();
                // �G���W��
                dataRow[ENGINEMODELNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ENGINEMODELNM_KEY].Value.ToString();
                // �r�C��
                dataRow[ENGINEDISPLACENM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ENGINEDISPLACENM_KEY].Value.ToString();
                // �d�敪
                dataRow[EDIVNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[EDIVNM_KEY].Value.ToString();
                // �~�b�V����
                dataRow[TRANSMISSIONNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[TRANSMISSIONNM_KEY].Value.ToString();
                // �쓮����
                dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[WHEELDRIVEMETHODNM_KEY].Value.ToString();
                // �V�t�g
                dataRow[SHIFTNM_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[SHIFTNM_KEY].Value.ToString();

                // �ǉ������^�C�g���P
                string AddiCarSpecTitle1 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE1_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle1))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = AddiCarSpecTitle1;
                    // �ǉ������P
                    dataRow[ADDICARSPECTITLE1_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC1_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE1_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���Q
                string AddiCarSpecTitle2 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE2_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle2))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = AddiCarSpecTitle2;
                    // �ǉ������Q
                    dataRow[ADDICARSPECTITLE2_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC2_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE2_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���R
                string AddiCarSpecTitle3 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE3_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle3))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = AddiCarSpecTitle3;
                    // �ǉ������R
                    dataRow[ADDICARSPECTITLE3_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC3_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE3_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���S
                string AddiCarSpecTitle4 = Convert.ToString(this.carPartsTable.Rows[row.Index][ADDICARSPECTITLE4_KEY]);
                if (!string.IsNullOrEmpty(AddiCarSpecTitle4))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = AddiCarSpecTitle4;
                    // �ǉ������S
                    dataRow[ADDICARSPECTITLE4_INFO_TITLE] = Convert.ToString(this.carPartsTable.Rows[row.Index][ADDICARSPEC4_KEY]);
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE4_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���T
                string AddiCarSpecTitle5 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE5_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle5))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = AddiCarSpecTitle5;
                    // �ǉ������T
                    dataRow[ADDICARSPECTITLE5_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC5_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE5_INFO_TITLE] = string.Empty;
                }

                // �ǉ������^�C�g���U
                string AddiCarSpecTitle6 = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPECTITLE6_KEY].Value.ToString();
                if (!string.IsNullOrEmpty(AddiCarSpecTitle6))
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = false;
                    this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = AddiCarSpecTitle6;
                    // �ǉ������U
                    dataRow[ADDICARSPECTITLE6_INFO_TITLE] = this.uGrid_CarPartsList.Rows[row.Index].Cells[ADDICARSPEC6_KEY].Value.ToString();
                }
                else
                {
                    this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
                    this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;
                    dataRow[ADDICARSPECTITLE6_INFO_TITLE] = string.Empty;
                }
                //------UPD 2009/10/20------<<<<<
                this.carSpecTable.Rows.Add(dataRow);
                this.uGrid_CarSpec.Refresh();

            }
        }
        #endregion

        #region �� �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɃC�x���g ��
        /// <summary>
        /// �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɃC�x���g(tArrowKeyControl)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            this._prevControl = e.NextCtrl;

            // PrevCtrl�ݒ�
            Control prevCtrl = new Control();
            if (e.PrevCtrl is Control)
            {
                prevCtrl = (Control)e.PrevCtrl;
            }

            // ���O�ɂ�蕪��
            switch (prevCtrl.Name)
            {
                //---------------------------------------------------------------
                // �t�B�[���h�Ԉړ�
                //---------------------------------------------------------------
                #region ���q�����O���b�h
                // ���q�����O���b�h
                //case "uGrid_CarSearchList":
                //    {
                //        break;
                //    }
                #endregion

                #region ���_�R�[�h
                // ���_�R�[�h
                case "tEdit_SectionCodeAllowZero":
                    {
                        string inputValue = this.tEdit_SectionCodeAllowZero.Text;

                        string code;
                        string name;
                        bool status = ReadSectionCodeAllowZeroName(out code, out name);

                        if (status == true)
                        {
                            this.tEdit_SectionCodeAllowZero.Text = code;
                            this.uLabel_SectionNm.Text = name;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    //-------DEL 2009/10/10------>>>>>
                                    //case Keys.Left:
                                    //case Keys.Up:
                                    //    {
                                    //        //e.NextCtrl = null;
                                    //    }
                                    //    break;
                                    //-------DEL 2009/10/10------<<<<<
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if (String.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_SectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_CustomerCode;
                                            }
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                        {
                                            //e.NextCtrl = null;// DEL 2009/10/10
                                            e.NextCtrl = this.tComboEditor_DisplayDiv; // ADD 2009/10/10
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���_�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�߂�
                            this.tEdit_SectionCodeAllowZero.Text = code;
                            this.tEdit_SectionCodeAllowZero.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }

                        break;
                    }
                #endregion

                #region ���_�K�C�h
                // ���_�K�C�h
                case "uButton_SectionGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region ���Ӑ�R�[�h
                // ���Ӑ�R�[�h
                case "tNedit_CustomerCode":
                    {
                        int inputValue = tNedit_CustomerCode.GetInt();
                        int code;
                        bool status = ReadCustomerName(out code);

                        if (status == true)
                        {
                            tNedit_CustomerCode.SetInt(code);

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if (String.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim()))
                                            {
                                                e.NextCtrl = this.uButton_CustomerGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_CarMngCode;
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "���Ӑ悪���݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h��߂�
                            tNedit_CustomerCode.SetInt(code);
                            tNedit_CustomerCode.SelectAll();

                            e.NextCtrl = e.PrevCtrl;
                        }
                        break;
                    }
                #endregion // ���Ӑ�R�[�h

                #region ���Ӑ�K�C�h
                // ���Ӑ�K�C�h
                case "uButton_CustomerGuide":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_CarMngCode;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion

                #region ������i�J�n�j
                // ������i�J�n�j
                case "tDateEdit_SalesDateSt":
                    {
                        if (this.tDateEdit_SalesDateSt.GetLongDate() == 0)
                        {
                            this.tDateEdit_SalesDateSt.Clear();
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_SalesDateEd;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ������i�J�n�j

                #region ������i�I���j
                // ������i�I���j
                case "tDateEdit_SalesDateEd":
                    {
                        if (this.tDateEdit_SalesDateEd.GetLongDate() == 0)
                        {
                            this.tDateEdit_SalesDateEd.Clear();
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_AddUpADateSt;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ������i�I���j

                #region ���͓��i�J�n�j
                // ���͓��i�J�n�j
                case "tDateEdit_AddUpADateSt":
                    {
                        if (this.tDateEdit_AddUpADateSt.GetLongDate() == 0)
                        {
                            this.tDateEdit_AddUpADateSt.Clear();
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tDateEdit_AddUpADateEd;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ���͓��i�J�n�j

                #region ���͓��i�I���j
                // ���͓��i�I���j
                case "tDateEdit_AddUpADateEd":
                    {
                        if (this.tDateEdit_AddUpADateEd.GetLongDate() == 0)
                        {
                            this.tDateEdit_AddUpADateEd.Clear();
                        }
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Return:
                                case Keys.Tab:
                                    {
                                        e.NextCtrl = this.tEdit_FullModel;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                #endregion // ���͓��i�I���j

                #region BL�R�[�h
                // BL�R�[�h
                case "tEdit_BlGoodsCode":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_BlGoodsCode.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadBlCodeName(out code);

                        if (status == true)
                        {
                            // ���̕\��
                            tEdit_BlGoodsCode.Text = _swBLGoodsName;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        e.NextCtrl = this.uButton_BlGoodsCode;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�a�k�R�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�ɖ߂�
                            tEdit_BlGoodsCode.Text = code.ToString();
                            tEdit_BlGoodsCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                #endregion

                #region BL�O���[�v
                // BL�O���[�v
                case "tEdit_BlGroupCode":
                    {
                        int inputValue;
                        try
                        {
                            inputValue = Int32.Parse(tEdit_BlGroupCode.Text);
                        }
                        catch
                        {
                            inputValue = 0;
                        }

                        int code;
                        bool status = ReadBlGroupName(out code);

                        if (status == true)
                        {
                            // ���̕\��
                            tEdit_BlGroupCode.Text = _swBLGroupName;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        e.NextCtrl = this.uButton_BlGroupCode;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�O���[�v�R�[�h�����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�ɖ߂�
                            tEdit_BlGroupCode.Text = code.ToString();
                            tEdit_BlGroupCode.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                #endregion

                #region �q��
                // �q��
                case "tEdit_WarehouseCd":
                    {
                        string inputValue = tEdit_WarehouseCd.Text;

                        string code;
                        bool status = ReadWarehouseName(out code);

                        if (status == true)
                        {
                            // ���̕\��
                            tEdit_WarehouseCd.Text = _swWarehouseName;

                            if (!e.ShiftKey)
                            {
                                switch (e.Key)
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // �G���[��
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "�q�ɂ����݂��܂���B",
                                -1,
                                MessageBoxButtons.OK);

                            // �R�[�h�ɖ߂�
                            tEdit_WarehouseCd.Text = code;
                            tEdit_WarehouseCd.SelectAll();
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                #endregion

                #region �^��
                // �^��
                case "tEdit_FullModel":
                    {
                        string inputValue = tEdit_FullModel.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // �\��
                        tEdit_FullModel.Text = searchText;
                        tComboEditor_FullModelFuzzy.Value = fuzzyValue;

                        // �ޔ�
                        _srFullModel = inputValue;
                        _srRvFullModel = searchText;

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // �^�������܂�����
                case "tComboEditor_FullModelFuzzy":
                    {
                        // �ޔ�
                        _srFullModel = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_FullModelFuzzy.Value, tEdit_FullModel.Text);

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #endregion

                #region �i��
                // �i��
                case "tEdit_GoodsName":
                    {
                        string inputValue = tEdit_GoodsName.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // �\��
                        tEdit_GoodsName.Text = searchText;
                        tComboEditor_GoodsNameFuzzy.Value = fuzzyValue;

                        // �ޔ�
                        _srGoodsName = inputValue;
                        _srRvGoodsName = searchText;

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // �i�������܂�����
                case "tComboEditor_GoodsNameFuzzy":
                    {
                        // �ޔ�
                        _srGoodsName = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_GoodsNameFuzzy.Value, tEdit_GoodsName.Text);

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #endregion

                #region �i��
                // �i��
                case "tEdit_GoodsNo":
                    {
                        string inputValue = tEdit_GoodsNo.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // �\��
                        tEdit_GoodsNo.Text = searchText;
                        tComboEditor_GoodsNoFuzzy.Value = fuzzyValue;

                        // �ޔ�
                        _srGoodsNo = inputValue;
                        _srRvGoodsNo = searchText;

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // �i�Ԃ����܂�����
                case "tComboEditor_GoodsNoFuzzy":
                    {
                        // �ޔ�
                        _srGoodsNo = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_GoodsNoFuzzy.Value, tEdit_GoodsNo.Text);

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #endregion
                #region �Ǘ��ԍ�
                case "tEdit_CarMngCode":
                    {
                        string inputValue = this.tEdit_CarMngCode.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // �\��
                        this.tEdit_CarMngCode.Text = searchText;
                        this.tComboEditor_CarMngCode.Value = fuzzyValue;

                        // �ޔ�
                        _srCarMngNo = inputValue;
                        _srRvCarMngNo = searchText;
                        break;
                    }
                case "tComboEditor_CarMngCode":
                    {
                        // �ޔ�
                        _srCarMngNo = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_CarMngCode.Value, tEdit_CarMngCode.Text);
                        break;
                    }
                #endregion

                #region ���q���l
                // ���q���l
                case "tEdit_SlipNote":
                    {
                        string inputValue = tEdit_SlipNote.Text;
                        string searchText;
                        int fuzzyValue;
                        GetFuzzyInput(inputValue, out searchText, out fuzzyValue);

                        // �\��
                        tEdit_SlipNote.Text = searchText;
                        tComboEditor_SlipNoteFuzzy.Value = fuzzyValue;

                        // �ޔ�
                        _srCarNote = inputValue;
                        _srRvCarNote = searchText;

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                // ���q���l�����܂�����
                case "tComboEditor_SlipNoteFuzzy":
                    {
                        // �ޔ�
                        _srCarNote = GetFuzzyInputOnChangeFuzzyValue((int)tComboEditor_SlipNoteFuzzy.Value, tEdit_SlipNote.Text);

                        # region [�t�H�[�J�X]
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    //e.NextCtrl = this.GetNextControl(e.PrevCtrl.Name);
                                    break;
                            }
                        }
                        # endregion
                    }
                    break;
                #endregion

                default: break;
            }
        }

        #region ���_
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadSectionCodeAllowZeroName(out string code, out string name)
        {
            // ���͒l���擾
            string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0');
            code = sectionCode;
            name = uLabel_SectionNm.Text;

            if (_prevInputValue.SectionCode == sectionCode)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionCode;
                return true;
            }

            // 00:�S��
            if (sectionCode == "00")
            {
                sectionCode = "00";
                _prevInputValue.SectionCode = sectionCode;
                code = sectionCode;
                name = "�S��";
                return true;
            }
            else if (!String.IsNullOrEmpty(sectionCode.Trim()))
            {
                // ���_�����擾
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);

                // �X�e�[�^�X������̏ꍇ��UI�ɃZ�b�g
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    code = sectionInfo.SectionCode.TrimEnd();
                    name = sectionInfo.SectionGuideNm.TrimEnd();
                    _prevInputValue.SectionCode = code;
                    return true;
                }
                else
                {
                    code = uiSetControl1.GetZeroPadCanceledText("tEdit_SectionCode", _prevInputValue.SectionCode);
                    return false;
                }
            }
            else
            {
                code = string.Empty;
                name = string.Empty;
                _prevInputValue.SectionCode = code;
                return true;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/07 ADD

        #endregion

        #region ���Ӑ�
        /// <summary>
        /// ���Ӑ於�̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool ReadCustomerName(out int code)
        {
            int customerCode = this.tNedit_CustomerCode.GetInt();
            code = customerCode;

            if (_prevInputValue.CustomerCode == customerCode) return true;

            if (customerCode > 0)
            {
                CustomerInfo customerInfo;
                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();

                    _prevInputValue.CustomerCode = customerCode;

                    // --- UPD 2009/09/27 -------------->>>
                    // ���_����UI�ɐݒ�
                    tEdit_SectionCodeAllowZero.Text = customerInfo.MngSectionCode.Trim();
                    ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tEdit_SectionCodeAllowZero, this.tEdit_SectionCodeAllowZero);
                    this.tArrowKeyControl_ChangeFocus(this, changeFocusEventArgs);
                    // --- UPD 2009/09/27 --------------<<<

                    return true;
                }
                else
                {
                    code = _prevInputValue.CustomerCode;
                    return false;
                }
            }
            else
            {
                _prevInputValue.CustomerCode = customerCode;
                // ���̂��N���A
                this.uLabel_CustomerName.Text = string.Empty;

                return true;
            }
        }

        #endregion // ���Ӑ�

        #region BL�R�[�h
        /// <summary>
        /// BL�R�[�h���̎擾
        /// </summary>
        /// <param name="code">BL�R�[�h</param>
        private bool ReadBlCodeName(out int code)
        {
            // ���͒l���擾
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_BlGoodsCode.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // ��łȂ���Ώ����J�n
            if (inputValue != 0)
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != this._swBLGoodsCode)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        BLGoodsCdUMnt blGoodsCd;
                        int status = _blGoodsCdAcs.Read(out blGoodsCd, this._enterpriseCode, inputValue);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._swBLGoodsCode = inputValue;
                            this._swBLGoodsName = blGoodsCd.BLGoodsFullName;
                            code = _swBLGoodsCode;
                            return true;
                        }
                        else
                        {
                            // �߂�
                            code = _swBLGoodsCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = _swBLGoodsCode;
                    return false;
                }
            }
            else
            {
                this._swBLGoodsCode = 0;
                this._swBLGoodsName = string.Empty;
                code = _swBLGoodsCode;
                return true;
            }
        }
        #endregion

        #region �O���[�v�R�[�h
        /// <summary>
        /// �O���[�v�R�[�h���̎擾
        /// </summary>
        /// <param name="code">�O���[�v�R�[�h</param>
        private bool ReadBlGroupName(out int code)
        {
            // ���͒l���擾
            int inputValue;
            try
            {
                inputValue = Int32.Parse(this.tEdit_BlGroupCode.Text.Trim());
            }
            catch
            {
                inputValue = 0;
            }
            code = inputValue;

            // ��łȂ���Ώ����J�n
            if (inputValue != 0)
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != this._swBLGroupCode)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        BLGroupU blGroup;
                        int status = this._blGroupUAcs.Search(out blGroup, this._enterpriseCode, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._swBLGroupCode = inputValue;
                            this._swBLGroupName = blGroup.BLGroupName;
                            code = _swBLGroupCode;
                            return true;
                        }
                        else
                        {
                            // �߂�
                            code = _swBLGroupCode;
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = _swBLGroupCode;
                    return false;
                }
            }
            else
            {
                this._swBLGroupCode = 0;
                this._swBLGroupName = string.Empty;
                code = _swBLGroupCode;
                return true;
            }
        }
        #endregion

        #region �q�ɖ�
        /// <summary>
        /// �q�ɖ��̎擾
        /// </summary>
        /// <param name="code">�q�ɃR�[�h</param>
        private bool ReadWarehouseName(out string code)
        {
            // ���͒l���擾
            string inputValue = this.tEdit_WarehouseCd.Text.Trim();
            code = inputValue;

            // ��łȂ���Ώ����J�n
            if (!string.IsNullOrEmpty(inputValue))
            {
                try
                {
                    // ���͒l���ς���Ă����ꍇ�̂݃R�[�h�ϊ�
                    if (inputValue != this._swWarehouseCd)
                    {
                        // �R�[�h���疼�̂֕ϊ�
                        Warehouse warehouseInfo;
                        int status = this._warehouseAcs.Read(out warehouseInfo, this._enterpriseCode, string.Empty, inputValue);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this._swWarehouseCd = inputValue;
                            this._swWarehouseName = warehouseInfo.WarehouseName;
                            code = _swWarehouseCd;
                            return true;
                        }
                        else
                        {
                            // �߂�
                            code = uiSetControl1.GetZeroPadCanceledText(tEdit_WarehouseCd.Name, _swWarehouseCd);
                            return false;
                        }
                    }
                    return true;
                }
                catch
                {
                    // �߂�
                    code = uiSetControl1.GetZeroPadCanceledText(tEdit_WarehouseCd.Name, _swWarehouseCd);
                    return false;
                }
            }
            else
            {
                this._swWarehouseCd = string.Empty;
                this._swWarehouseName = string.Empty;
                code = _swWarehouseCd;
                return true;
            }
        }
        #endregion

        #endregion

        #region �� �R�[�h���ۑ�����Ă���Βu�������C�x���g ��
        /// <summary>
        /// �Ǘ��ԍ�Enter�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �Ǘ��ԍ�Enter���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_CarMngCode_Enter(object sender, EventArgs e)
        {
            // �Ǘ��ԍ����ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._srCarMngNo))
            {
                this.tEdit_CarMngCode.Text = this._srCarMngNo;
            }
        }

        /// <summary>
        /// BL�O���[�v�R�[�hEnter�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : BL�O���[�v�R�[�hEnter���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_BlGroupCode_Enter(object sender, EventArgs e)
        {
            // BL�O���[�v�R�[�h���ۑ�����Ă���Βu������
            if (this._swBLGroupCode > 0)
            {
                this.tEdit_BlGroupCode.Text = this._swBLGroupCode.ToString();
            }
        }

        /// <summary>
        /// BL�R�[�h���͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : BL�O���[�v�R�[�hEnter���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_BlGoodsCode_Enter(object sender, EventArgs e)
        {
            // BL�R�[�h���ۑ�����Ă���Βu������
            if (this._swBLGoodsCode > 0)
            {
                this.tEdit_BlGoodsCode.Text = this._swBLGoodsCode.ToString();
            }
        }

        /// <summary>
        /// �q�ɓ��͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �q��Enter���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_WarehouseCd_Enter(object sender, EventArgs e)
        {
            // �q�ɃR�[�h���ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._swWarehouseCd))
            {
                this.tEdit_WarehouseCd.Text = this._swWarehouseCd.Trim();
            }
        }

        /// <summary>
        /// �^�����͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �^��Enter���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_FullModel_Enter(object sender, EventArgs e)
        {
            // �ҏW�J�n����[*]����̌^�����ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._srFullModel))
            {
                this.tEdit_FullModel.Text = this._srFullModel;
            }
        }

        /// <summary>
        /// ���q���l���͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : ���q���lEnter���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_SlipNote_Enter(object sender, EventArgs e)
        {
            // �ҏW�J�n����[*]����̔��l�P���ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._srCarNote))
            {
                this.tEdit_SlipNote.Text = this._srCarNote;
            }
        }

        /// <summary>
        /// �i�����͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �i��Enter���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_GoodsName_Enter(object sender, EventArgs e)
        {
            // �ҏW�J�n����[*]����̕i�����ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._srGoodsName))
            {
                this.tEdit_GoodsName.Text = this._srGoodsName;
            }
        }

        /// <summary>
        /// �i�ԓ��͗�Enter�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �i��Enter���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tEdit_GoodsNo_Enter(object sender, EventArgs e)
        {
            // �ҏW�J�n����[*]����̕i�Ԃ��ۑ�����Ă���Βu������
            if (!String.IsNullOrEmpty(this._srGoodsNo))
            {
                this.tEdit_GoodsNo.Text = this._srGoodsNo;
            }
        }

        # region [�����܂������p�e�L�X�g��������]
        /// <summary>
        /// �����܂������p�e�L�X�g��������
        /// </summary>
        /// <param name="inputValue">���̓f�[�^</param>
        /// <param name="searchText">�����f�[�^</param>
        /// <param name="fuzzyValue">�����܂��f�[�^</param>
        /// <remarks>
        /// <br>Note        : �����܂������p�e�L�X�g�����������s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void GetFuzzyInput(string inputValue, out string searchText, out int fuzzyValue)
        {
            if (!string.IsNullOrEmpty(inputValue))
            {
                fuzzyValue = 0;     // �R���{�{�b�N�X�̒l

                if (!inputValue.Contains("*"))
                {
                    // [*]�Ȃ��i�u�ƈ�v�v�j
                    fuzzyValue = CT_FUZZY_MATCHWITH;
                }
                else if (inputValue.StartsWith("*") && inputValue.EndsWith("*"))
                {
                    // [*]�c[*]�i�u���܂ށv�j
                    fuzzyValue = CT_FUZZY_INCLUDEWITH;
                }
                else if (inputValue.StartsWith("*"))
                {
                    // [*]�c�i�u�ŏI��v�j
                    fuzzyValue = CT_FUZZY_ENDWITH;
                }
                else if (inputValue.EndsWith("*"))
                {
                    // �c[*]�i�u�Ŏn��v�j
                    fuzzyValue = CT_FUZZY_STARTWITH;
                }
                searchText = inputValue.Replace("*", ""); // [*]����������
            }
            else
            {
                // �N���A
                searchText = string.Empty;
                fuzzyValue = 0;
            }
        }
        # endregion

        # region [�����܂������p�e�L�X�g�ϊ�����]
        /// <summary>
        /// �����܂������p�e�L�X�g�ϊ�����
        /// </summary>
        /// <param name="fuzzyValue">�����܂��f�[�^</param>
        /// <param name="searchValue">�����f�[�^</param>
        /// <remarks>
        /// <br>Note        : �����܂������p�e�L�X�g�����������s���B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private string GetFuzzyInputOnChangeFuzzyValue(int fuzzyValue, string searchValue)
        {
            string fullValue = searchValue;

            switch (fuzzyValue)
            {
                // ���S��v
                case CT_FUZZY_MATCHWITH:
                default:
                    fullValue = searchValue;
                    break;
                // �����܂�
                case CT_FUZZY_INCLUDEWITH:
                    fullValue = "*" + searchValue + "*";
                    break;
                // �����v
                case CT_FUZZY_ENDWITH:
                    fullValue = "*" + searchValue;
                    break;
                // �O����v
                case CT_FUZZY_STARTWITH:
                    fullValue = searchValue + "*";
                    break;
            }

            return fullValue;
        }
        #endregion

        #endregion

        #region �� �K�C�h�{�^���N���b�N�C�x���g ��
        /// <summary>
        /// ���_�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^���N���b�N�C�x���g�ł��B</br>      
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            // ���_�K�C�h�\��
            SecInfoSet sectionInfo;

            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out sectionInfo);

            // �X�e�[�^�X�����펞�̂ݏ���UI�ɃZ�b�g
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SectionCodeAllowZero.Text = sectionInfo.SectionCode.Trim();
                this.uLabel_SectionNm.Text = sectionInfo.SectionGuideNm.Trim();

                _prevInputValue.SectionCode = sectionInfo.SectionCode.Trim();
                // ���t�H�[�J�X
                this.tNedit_CustomerCode.Focus();
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g�ł��B</br>      
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_CustomerGuide_Click(object sender, EventArgs e)
        {
            // ���Ӑ�K�C�h�\��
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);

            DialogResult result = customerSearchForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.tEdit_CarMngCode.Focus();
            }
        }

        #region ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g

        /// <summary>
        /// ���Ӑ�I���K�C�h�{�^���N���b�N�������C�x���g
        /// </summary>
        /// <param name="sender">PMKHN4002E�t�H�[���I�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ���߂�l�N���X(PMKHN4002E)</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I���K�C�h�{�^���N���b�N���C�x���g�ł��B</br>      
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            // �C�x���g�n���h����n�������肩��߂�l�N���X���󂯎��Ȃ���ΏI��
            if (customerSearchRet == null) return;

            // DB�f�[�^��ǂݏo��(�L���b�V�����g�p)
            CustomerInfo customerInfo;
            int status = this._customerInfoAcs.ReadDBData(customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            // �X�e�[�^�X�ɂ��G���[���b�Z�[�W���o��
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�I���������Ӑ�͓��Ӑ�����͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status, MessageBoxButtons.OK);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status, MessageBoxButtons.OK);
                return;
            }
            else
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOPDISP, this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status, MessageBoxButtons.OK);
                return;
            }

            // ���Ӑ����UI�ɐݒ�
            this.tNedit_CustomerCode.SetInt(customerInfo.CustomerCode);
            this.uLabel_CustomerName.Text = customerInfo.CustomerSnm.TrimEnd();

            _prevInputValue.CustomerCode = customerInfo.CustomerCode;

            // --- UPD 2009/09/27 -------------->>>
            // ���_����UI�ɐݒ�
            tEdit_SectionCodeAllowZero.Text = customerInfo.MngSectionCode.Trim();
            ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tEdit_SectionCodeAllowZero, this.tEdit_SectionCodeAllowZero);
            this.tArrowKeyControl_ChangeFocus(this, changeFocusEventArgs);
            // --- UPD 2009/09/27 --------------<<<

        }

        #endregion

        /// <summary>
        /// �Ǘ��ԍ��K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �Ǘ��ԍ��K�C�h�{�^���N���b�N�C�x���g�ł��B</br>      
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void CarMngCode_Button_Click(object sender, EventArgs e)
        {
            CarMangInputExtraInfo selectedInfo = new CarMangInputExtraInfo();
            CarMngGuideParamInfo paramInfo = new CarMngGuideParamInfo();
            paramInfo.EnterpriseCode = this._enterpriseCode;
            // �u�V�K�o�^�v�s�\���Ȃ�
            paramInfo.IsDispNewRow = false;
            // ���Ӑ���͗L
            if (this.tNedit_CustomerCode.GetInt() != 0)
            {
                // ���Ӑ�\������
                paramInfo.IsDispCustomerInfo = false;
                // ���Ӑ�R�[�h�i�荞�ݗL��
                paramInfo.IsCheckCustomerCode = true;
                // ���Ӑ�R�[�h
                paramInfo.CustomerCode = this.tNedit_CustomerCode.GetInt();
            }
            // ���Ӑ���͖�
            else
            {
                // ���Ӑ�\������
                paramInfo.IsDispCustomerInfo = true;
                // ���Ӑ�R�[�h�i�荞�ݖ���
                paramInfo.IsCheckCustomerCode = false;
            }

            // �Ǘ��ԍ��i�荞�ݗL��
            string carMngCodeStr = this.tEdit_CarMngCode.Text.Trim();
            if (string.IsNullOrEmpty(carMngCodeStr))
            {
                paramInfo.IsCheckCarMngCode = false;
            }
            else
            {
                paramInfo.IsCheckCarMngCode = true;
                paramInfo.CarMngCode = this.tEdit_CarMngCode.Text.Trim();
                paramInfo.CheckCarMngCodeType = this.tComboEditor_CarMngCode.SelectedIndex;
            }
            // ���q�Ǘ��敪�`�F�b�N�L��
            paramInfo.IsCheckCarMngDivCd = true;
            // �K�C�h�C�x���g�t���O
            paramInfo.IsGuideClick = true;
            int status = this._carMngInputAcs.ExecuteGuid(paramInfo, out selectedInfo);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (selectedInfo.CarMngCode != "�V�K�o�^")
                {
                    // ���Ӑ�R�[�h
                    if (this.tNedit_CustomerCode.GetInt() == 0 && selectedInfo.CustomerCode != 0)
                    {
                        this.tNedit_CustomerCode.Text = selectedInfo.CustomerCode.ToString("00000000");
                    }
                    // �Ǘ��ԍ�
                    this.tEdit_CarMngCode.Text = selectedInfo.CarMngCode;
                    // �Ǘ��ԍ����o����
                    this.tComboEditor_CarMngCode.SelectedIndex = 0;
                    //-----------ADD 2009/11/04-------->>>>>
                    // �Ǘ��ԍ�(���q���)
                    this.uLabel_CarMngCodeData.Text = selectedInfo.CarMngCode;
                    //-----------ADD 2009/11/04--------<<<<<
                    // �^��
                    this.tEdit_FullModel.Text = selectedInfo.SeriesModel + "-" + selectedInfo.CategorySignModel;
                    this._srFullModel = this.tEdit_FullModel.Text;
                    // �^���w��ԍ�
                    if (selectedInfo.ModelDesignationNo == 0)
                    {
                        this.uLabel_ModelDesignationNoData.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelDesignationNoData.Text = selectedInfo.ModelDesignationNo.ToString("00000");
                    }
                    // �ޕʔԍ�
                    if (selectedInfo.CategoryNo == 0)
                    {
                        this.uLabel_ModelKindNo.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelKindNo.Text = selectedInfo.CategoryNo.ToString("0000");
                    }
                    // �G���W���^��
                    this.uLabel_EngineModelNmData.Text = selectedInfo.EngineModelNm;
                    // �Ԏ�i���[�J�[�R�[�h�j
                    if (selectedInfo.MakerCode == 0)
                    {
                        this.uLabel_ModelMaker.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelMaker.Text = selectedInfo.MakerCode.ToString("000");
                    }
                    // �Ԏ�i�Ԏ�R�[�h�j
                    if (selectedInfo.ModelCode == 0)
                    {
                        this.uLabel_ModelCode.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelCode.Text = selectedInfo.ModelCode.ToString("000");
                    }
                    // �Ԏ�i�ď̃R�[�h�j
                    if (selectedInfo.ModelSubCode == 0)
                    {
                        this.uLabel_ModelSubCode.Text = string.Empty;
                    }
                    else
                    {
                        this.uLabel_ModelSubCode.Text = selectedInfo.ModelSubCode.ToString("000");
                    }
                    // �Ԏ햼��
                    this.uLabel_ModelName.Text = selectedInfo.ModelFullName;
                    // �^��
                    this.uLabel_FullModelTitleInfoData.Text = selectedInfo.FullModel;
                    //this._srFullModel = selectedInfo.FullModel;

                    this.tComboEditor_FullModelFuzzy.SelectedIndex = 0;
                    // �N��
                    // if (selectedInfo.FirstEntryDate == DateTime.MinValue) // DEL 2009/10/10
                    if (selectedInfo.FirstEntryDate == 0) // ADD 2009/10/10
                    {
                        tDateEdit_FirstEntryDate.Clear();
                    }
                    else
                    {
                        // string firstEntryStr = selectedInfo.FirstEntryDate.ToString("yyyyMMdd");// DEL 2009/11/04
                        // tDateEdit_FirstEntryDate.SetLongDate(Int32.Parse(firstEntryStr) * 100 + 1);// DEL 2009/11/04
                        tDateEdit_FirstEntryDate.SetLongDate((selectedInfo.FirstEntryDate) * 100 + 1);// ADD 2009/11/04
                    }
                    // (���Y�N�� �J�n-�I��)
                    if (selectedInfo.StProduceTypeOfYear == DateTime.MinValue && selectedInfo.EdProduceTypeOfYear == DateTime.MinValue)
                    {
                        this.uLabel_FirstEntryDateRange.Text = string.Empty;
                    }
                    else
                    {
                        // 0:����
                        if (this._allDefSet.EraNameDispCd1 == 0)
                        {
                            if (selectedInfo.StProduceTypeOfYear == DateTime.MinValue)
                            {
                                this.uLabel_FirstEntryDateRange.Text = "-" + selectedInfo.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                            }
                            else if (selectedInfo.EdProduceTypeOfYear == DateTime.MinValue)
                            {
                                this.uLabel_FirstEntryDateRange.Text = selectedInfo.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-";
                            }
                            else
                            {
                                this.uLabel_FirstEntryDateRange.Text = selectedInfo.StProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM) + "-" + selectedInfo.EdProduceTypeOfYear.ToString(DATEFORMAT_YYYYMM);
                            }
                        }
                        // 1:�a��
                        else
                        {
                            string stProduceTypeOfYear = this.GetProduceTypeOfYear(selectedInfo.StProduceTypeOfYear);
                            string edProduceTypeOfYear = this.GetProduceTypeOfYear(selectedInfo.EdProduceTypeOfYear);
                            this.uLabel_FirstEntryDateRange.Text = this.SettingProduceTypeOfYearRange(stProduceTypeOfYear, edProduceTypeOfYear);
                        }
                    }
                    // �ԑ�ԍ�
                    this.uLabel_ProduceFrameNoData.Text = selectedInfo.FrameNo;
                    // (�ԑ�ԍ� �J�n-�I��)
                    if (selectedInfo.StProduceFrameNo == 0 && selectedInfo.EdProduceFrameNo == 0)
                    {
                        this.uLabel_ProduceFrameNoRange.Text = string.Empty;
                    }
                    else
                    {
                        if (selectedInfo.StProduceFrameNo == 0)
                        {
                            this.uLabel_ProduceFrameNoRange.Text = "".PadLeft(8, ' ') + "-" + Convert.ToString(selectedInfo.EdProduceFrameNo);
                        }
                        else if (selectedInfo.EdProduceFrameNo == 0)
                        {
                            this.uLabel_ProduceFrameNoRange.Text = Convert.ToString(selectedInfo.StProduceFrameNo) + "-" + "".PadLeft(8, ' ');
                        }
                        else
                        {
                            this.uLabel_ProduceFrameNoRange.Text = Convert.ToString(selectedInfo.StProduceFrameNo).PadLeft(8, ' ') + "-" + Convert.ToString(selectedInfo.EdProduceFrameNo).PadLeft(8, ' ');
                        }
                    }
                    // �J���[
                    this.uLabel_ColorNoData.Text = selectedInfo.ColorCode;
                    // �g����
                    this.uLabel_TrimNoData.Text = selectedInfo.TrimCode;

                    this.carSpecTable.Clear();

                    DataRow dataRow;
                    dataRow = this.carSpecTable.NewRow();
                    // �O���[�h
                    dataRow[MODELGRADENM_INFO_TITLE] = selectedInfo.ModelGradeNm;
                    // �{�f�B
                    dataRow[BODYNAME_INFO_TITLE] = selectedInfo.BodyName;
                    // �h�A
                    dataRow[DOORCOUNT_INFO_TITLE] = selectedInfo.DoorCount;
                    // �G���W��
                    dataRow[ENGINEMODELNM_INFO_TITLE] = selectedInfo.EngineModelNm;
                    // �r�C��
                    dataRow[ENGINEDISPLACENM_INFO_TITLE] = selectedInfo.EngineDisplaceNm;
                    // �d�敪
                    dataRow[EDIVNM_INFO_TITLE] = selectedInfo.EDivNm;
                    // �~�b�V����
                    dataRow[TRANSMISSIONNM_INFO_TITLE] = selectedInfo.TransmissionNm;
                    // �쓮����
                    dataRow[WHEELDRIVEMETHODNM_INFO_TITLE] = selectedInfo.WheelDriveMethodNm;
                    // �V�t�g
                    dataRow[SHIFTNM_INFO_TITLE] = selectedInfo.ShiftNm;

                    // �ǉ������^�C�g���P
                    string AddiCarSpecTitle1 = selectedInfo.AddiCarSpecTitle1;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle1))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = AddiCarSpecTitle1;
                        // �ǉ������P
                        dataRow[ADDICARSPECTITLE1_INFO_TITLE] = selectedInfo.AddiCarSpec1;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE1_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE1_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE1_INFO_TITLE] = string.Empty;
                    }

                    // �ǉ������^�C�g���Q
                    string AddiCarSpecTitle2 = selectedInfo.AddiCarSpecTitle2;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle2))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = AddiCarSpecTitle2;
                        // �ǉ������Q
                        dataRow[ADDICARSPECTITLE2_INFO_TITLE] = selectedInfo.AddiCarSpec2;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE2_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE2_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE2_INFO_TITLE] = string.Empty;
                    }

                    // �ǉ������^�C�g���R
                    string AddiCarSpecTitle3 = selectedInfo.AddiCarSpecTitle3;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle3))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = AddiCarSpecTitle3;
                        // �ǉ������R
                        dataRow[ADDICARSPECTITLE3_INFO_TITLE] = selectedInfo.AddiCarSpec3;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE3_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE3_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE3_INFO_TITLE] = string.Empty;
                    }

                    // �ǉ������^�C�g���S
                    string AddiCarSpecTitle4 = selectedInfo.AddiCarSpecTitle4;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle4))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = AddiCarSpecTitle4;
                        // �ǉ������S
                        dataRow[ADDICARSPECTITLE4_INFO_TITLE] = selectedInfo.AddiCarSpec4;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE4_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE4_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE4_INFO_TITLE] = string.Empty;
                    }

                    // �ǉ������^�C�g���T
                    string AddiCarSpecTitle5 = selectedInfo.AddiCarSpecTitle5;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle5))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = AddiCarSpecTitle5;
                        // �ǉ������T
                        dataRow[ADDICARSPECTITLE5_INFO_TITLE] = selectedInfo.AddiCarSpec5;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE5_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE5_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE5_INFO_TITLE] = string.Empty;
                    }

                    // �ǉ������^�C�g���U
                    string AddiCarSpecTitle6 = selectedInfo.AddiCarSpecTitle6;
                    if (!string.IsNullOrEmpty(AddiCarSpecTitle6))
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = false;
                        this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = AddiCarSpecTitle6;
                        // �ǉ������U
                        dataRow[ADDICARSPECTITLE6_INFO_TITLE] = selectedInfo.AddiCarSpec6;
                    }
                    else
                    {
                        this.uGrid_CarSpec.DisplayLayout.Bands[0].Columns[ADDICARSPECTITLE6_INFO_TITLE].Hidden = true;
                        this.carSpecTable.Columns[ADDICARSPECTITLE6_INFO_TITLE].Caption = string.Empty;
                        dataRow[ADDICARSPECTITLE6_INFO_TITLE] = string.Empty;
                    }

                    this.carSpecTable.Rows.Add(dataRow);
                    this.uGrid_CarSpec.Refresh();

                    _customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

                    // --- UPD 2009/09/27 -------------->>>
                    // ���Ӑ����UI�ɐݒ�
                    _prevInputValue.CustomerCode = 0;
                    ChangeFocusEventArgs changeFocusEventArgs = new ChangeFocusEventArgs(false, false, false, Keys.Return, this.tNedit_CustomerCode, this.tNedit_CustomerCode);
                    this.tArrowKeyControl_ChangeFocus(this, changeFocusEventArgs);
                    // --- UPD 2009/09/27 --------------<<<
                }
            }
        }

        /// <summary>
        /// ���q���l�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���q���l�K�C�h�{�^���N���b�N�C�x���g�ł��B</br>      
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_SlipNote_Click(object sender, EventArgs e)
        {
            NoteGuidBd noteGuidBd;
            int status = _noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, SLIPNOTE_DIV);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_SlipNote.Text = noteGuidBd.NoteGuideName;
                this.tEdit_BlGroupCode.Focus();
            }
        }

        /// <summary>
        /// BL��ٰ�߃K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : BL��ٰ�߃K�C�h�{�^���N���b�N�C�x���g�ł��B</br>      
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_BlGroupCode_Click(object sender, EventArgs e)
        {
            // �K�C�h�\��
            BLGroupU blGroupUInfo;
            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupUInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_BlGroupCode.Text = blGroupUInfo.BLGroupName;
                this._swBLGroupCode = blGroupUInfo.BLGroupCode;
                this._swBLGroupName = blGroupUInfo.BLGroupName;

                this.tEdit_BlGoodsCode.Focus();
            }
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�K�C�h�{�^���N���b�N�C�x���g�ł��B</br>      
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_BlGoodsCode_Click(object sender, EventArgs e)
        {
            // �R�[�h���疼�̂֕ϊ�
            BLGoodsCdUMnt blGoodsUnit;
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tEdit_BlGoodsCode.Text = blGoodsUnit.BLGoodsFullName;
                this._swBLGoodsCode = blGoodsUnit.BLGoodsCode;
                this._swBLGoodsName = blGoodsUnit.BLGoodsFullName;

                this.tEdit_GoodsName.Focus();
            }
        }

        /// <summary>
        /// �q�ɃK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �q�ɃK�C�h�{�^���N���b�N�C�x���g�ł��B</br>      
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/09/10</br>
        /// </remarks>
        private void uButton_WarehouseCd_Click(object sender, EventArgs e)
        {
            // ���_�R�[�h���擾
            string sectioncode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            int status = 0;

            // �R�[�h���疼�̂֕ϊ�
            Warehouse warehouseInfo;

            // ���_�R�[�h�����͂���Ă���΋��_���A�Ȃ���ΑS���_�\��
            if (!String.IsNullOrEmpty(sectioncode))
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode, sectioncode);
            }
            else
            {
                status = this._warehouseAcs.ExecuteGuid(out warehouseInfo, this._enterpriseCode);
            }

            // �߂�l������ł����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // UI��ɂ͖��O���Z�b�g�A�R�[�h�̓��������Ɋi�[
                this.tEdit_WarehouseCd.Text = warehouseInfo.WarehouseName;
                this._swWarehouseCd = warehouseInfo.WarehouseCode;
                this._swWarehouseName = warehouseInfo.WarehouseName;
            }
        }
        #endregion

        # region �� ���̑��C�x���g ��
        /// <summary>
        /// �t�H���g�T�C�Y�R���{�{�b�N�X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �t�H���g�T�C�Y�R���{�{�b�N�X�̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tComboEditor_DisplayDiv_ValueChanged(object sender, EventArgs e)
        {
            // �\���敪�����q����
            if (this.tComboEditor_DisplayDiv.SelectedIndex == 0)
            {
                // ���o�����́u������v�u���͓��v����͕s�ɕύX����B
                this.tDateEdit_SalesDateSt.Enabled = false;
                this.tDateEdit_SalesDateEd.Enabled = false;
                this.tDateEdit_AddUpADateSt.Enabled = false;
                this.tDateEdit_AddUpADateEd.Enabled = false;
                // ���_�R�[�h
                this.tEdit_SectionCodeAllowZero.Enabled = false;
                this.uButton_SectionGuide.Enabled = false;

                this.uGroupBox_CarInfo.Expanded = true;
                // ���o�����g���ŏ���
                this.uGroupBox_ExtractCondition.Expanded = false;
                this.tEdit_BlGroupCode.Enabled = false;
                this.uButton_BlGroupCode.Enabled = false;
                this.tEdit_BlGoodsCode.Enabled = false;
                this.uButton_BlGoodsCode.Enabled = false;
                this.tEdit_GoodsName.Enabled = false;
                this.tComboEditor_GoodsNameFuzzy.Enabled = false;
                this.tEdit_GoodsNo.Enabled = false;
                this.tComboEditor_GoodsNoFuzzy.Enabled = false;
                this.tComboEditor_SalesOrderDivCd.Enabled = false;
                this.tEdit_WarehouseCd.Enabled = false;
                this.uButton_WarehouseCd.Enabled = false;


                this.tEdit_FullModel.Appearance.BackColor = System.Drawing.Color.White;

                //------ADD 2009/10/10-------->>>>>
                this.uLabel_CarMngCodeTitle.Visible = true;
                this.uLabel_CarMngCodeData.Visible = true;
                this.uLabel_CarMngCodeData.Text = string.Empty;
                //------ADD 2009/10/10--------<<<<<
            }
            // �\���敪���u�o�ו��i�v�̎�
            else if (this.tComboEditor_DisplayDiv.SelectedIndex == 1)
            {
                // ���o�����́u������v�u���͓��v����͕s�ɕύX����B
                this.tDateEdit_SalesDateSt.Enabled = true;
                this.tDateEdit_SalesDateEd.Enabled = true;
                this.tDateEdit_AddUpADateSt.Enabled = true;
                this.tDateEdit_AddUpADateEd.Enabled = true;
                // ���_�R�[�h
                this.tEdit_SectionCodeAllowZero.Enabled = true;
                this.uButton_SectionGuide.Enabled = true;

                // ���o�����g���ő剻
                this.uGroupBox_ExtractCondition.Expanded = true;
                this.uGroupBox_CarInfo.Expanded = true;
                this.tEdit_BlGroupCode.Enabled = true;
                this.uButton_BlGroupCode.Enabled = true;
                this.tEdit_BlGoodsCode.Enabled = true;
                this.uButton_BlGoodsCode.Enabled = true;
                this.tEdit_GoodsName.Enabled = true;
                this.tComboEditor_GoodsNameFuzzy.Enabled = true;
                this.tEdit_GoodsNo.Enabled = true;
                this.tComboEditor_GoodsNoFuzzy.Enabled = true;
                this.tComboEditor_SalesOrderDivCd.Enabled = true;
                this.tEdit_WarehouseCd.Enabled = true;
                this.uButton_WarehouseCd.Enabled = true;


                this.tEdit_FullModel.Appearance.BackColor = System.Drawing.Color.White;

                //------ADD 2009/10/10-------->>>>>
                this.uLabel_CarMngCodeTitle.Visible = true;
                this.uLabel_CarMngCodeData.Visible = true;
                this.uLabel_CarMngCodeData.Text = string.Empty;
                //------ADD 2009/10/10--------<<<<<

            }
            else
            {
                // ���o�����́u������v�u���͓��v����͕s�ɕύX����B
                this.tDateEdit_SalesDateSt.Enabled = true;
                this.tDateEdit_SalesDateEd.Enabled = true;
                this.tDateEdit_AddUpADateSt.Enabled = true;
                this.tDateEdit_AddUpADateEd.Enabled = true;
                // ���_�R�[�h
                this.tEdit_SectionCodeAllowZero.Enabled = true;
                this.uButton_SectionGuide.Enabled = true;

                // ���o�����g���ő剻
                this.uGroupBox_ExtractCondition.Expanded = true;
                this.uGroupBox_CarInfo.Expanded = false;
                this.tEdit_BlGroupCode.Enabled = true;
                this.uButton_BlGroupCode.Enabled = true;
                this.tEdit_BlGoodsCode.Enabled = true;
                this.uButton_BlGoodsCode.Enabled = true;
                this.tEdit_GoodsName.Enabled = true;
                this.tComboEditor_GoodsNameFuzzy.Enabled = true;
                this.tEdit_GoodsNo.Enabled = true;
                this.tComboEditor_GoodsNoFuzzy.Enabled = true;
                this.tComboEditor_SalesOrderDivCd.Enabled = true;
                this.tEdit_WarehouseCd.Enabled = true;
                this.uButton_WarehouseCd.Enabled = true;

                //------ADD 2009/10/10-------->>>>>
                this.uLabel_CarMngCodeTitle.Visible = false;
                this.uLabel_CarMngCodeData.Visible = false;
                //------ADD 2009/10/10--------<<<<<

                this.tEdit_FullModel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            }
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �c�[���o�[�N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                #region �I��
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                #endregion

                #region �e�L�X�g�o��
                case "ButtonTool_TextOut":
                    {
                        TextOutput();
                        break;
                    }
                #endregion

                #region �N���A
                case "ButtonTool_Clear":
                    {
                        this.Clear();
                        break;
                    }
                #endregion

                #region ����
                case "ButtonTool_Search":
                    {
                        // ��������
                        bool inputCheck = false;

                        if (this.tComboEditor_DisplayDiv.SelectedIndex == 0)
                        {
                            this.SearchProcess();
                        }
                        else
                        {
                            inputCheck = this.ExecutBeforeCheck();

                            if (inputCheck)
                            {
                                this.SearchPartsProcess();
                            }
                        }
                    }
                    break;
                #endregion

                default: break;
            }
        }

        /// <summary>
        /// �񕝎��������C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �񕝎����������ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(object sender, EventArgs e)
        {
            // ���q����
            if (this.uGrid_CarSearchList.Enabled == true)
            {
                autoColumnAdjust(this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked, 0);
            }
            // �o�ו��i
            if (this.uGrid_CarPartsList.Enabled == true)
            {
                autoColumnAdjust(this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked, 1);
            }
            // �o�ו��i�i���v�j
            if (this.uGrid_CarPartsTotalList.Enabled == true)
            {
                autoColumnAdjust(this.uCheckEditor_StatusBar_AutoFillToGridColumn.Checked, 2);
            }
        }

        /// <summary>
        /// �t�H���g�T�C�Y�ύX
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �t�H���g�T�C�Y�ύX���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void tComboEditor_StatusBar_FontSize_ValueChanged(object sender, EventArgs e)
        {
            int a = this.StrToIntDefOfValue(this.tComboEditor_StatusBar_FontSize.Value, CT_DEF_FONT_SIZE);
            float fontPoint = (float)a;

            if (this.uGrid_CarSearchList.Enabled == true)
            {
                this.uGrid_CarSearchList.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
                this.uGrid_CarSearchList.Refresh();
            }
            else if (this.uGrid_CarPartsList.Enabled == true)
            {
                this.uGrid_CarPartsList.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
                this.uGrid_CarPartsList.Refresh();
            }
            else if (this.uGrid_CarPartsTotalList.Enabled == true)
            {
                this.uGrid_CarPartsTotalList.DisplayLayout.Appearance.FontData.SizeInPoints = fontPoint;
                this.uGrid_CarPartsTotalList.Refresh();
            }

            uCheckEditor_StatusBar_AutoFillToGridColumn_CheckedChanged(null, null);
        }

        /// <summary>
        /// �I�u�W�F�N�g�ύX
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <param name="defaultNo">����</param>
        /// <remarks>
        /// <br>Note        : �t�H���g�T�C�Y�ύX���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private int StrToIntDefOfValue(object obj, int defaultNo)
        {
            try
            {
                return (int)obj;
            }
            catch
            {
                return defaultNo;
            }
        }

        /// <summary>
        /// �}�E�X�̃_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �}�E�X�̃_�u���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void uGrid_CarSearchList_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_CarSearchList.ActiveRow;
            if (row == null) return;

            this.tComboEditor_DisplayDiv.SelectedIndex = 1;
            this.tComboEditor_CarMngCode.SelectedIndex = 0;
            this.tComboEditor_FullModelFuzzy.SelectedIndex = 0;
            this.tComboEditor_SlipNoteFuzzy.SelectedIndex = 0;
            this.tNedit_CustomerCode.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CUSTOMERCODE_KEY]);
            int code;
            
            // ���Ӑ�}�X�^�Ǎ�����
            if (this._customerSearchRetDic.Count == 0)
            {
                this.LoadCustomerSearchRet();
            }
            if (!_customerSearchRetDic.ContainsKey(this.tNedit_CustomerCode.GetInt()))
            {
                // �G���[��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���Ӑ悪���݂��܂���B",
                    -1,
                    MessageBoxButtons.OK);

                // �R�[�h��߂�
                this.tNedit_CustomerCode.Focus();
                this.tNedit_CustomerCode.SelectAll();
            }
            else
            {
                this.ReadCustomerName(out code);
                this.tNedit_CustomerCode.Text = code.ToString("d8");
            }

            this.tEdit_CarMngCode.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][MNGNO_KEY]);
            this.tEdit_FullModel.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][KINDMODEL_KEY]);
            // this.tEdit_SlipNote.Text = Convert.ToString(this.carSearchTable.Rows[row.Index][CARNOTE_KEY]); // DEL 2009/10/20
            this._carMngNoTemp = Int32.Parse(this.carSearchTable.Rows[row.Index][MNGNOTEMP_KEY].ToString());
        }

        /// <summary>
        /// �X�y�[�X�L�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �X�y�[�X�L�[���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private void uGrid_CarSearchList_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            if ((uGrid.Rows.Count != 0) && (uGrid.ActiveRow != null))
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        {
                            DoubleClickRowEventArgs e2 = new DoubleClickRowEventArgs(uGrid.ActiveRow, new RowArea());
                            this.uGrid_CarSearchList_DoubleClickRow(sender, e2);
                            break;
                        }
                    //----------ADD 2009/10/10------->>>>>
                    case Keys.Left:
                        {
                            // �����L�[
                            if (e.KeyCode == Keys.Left)
                            {
                                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                                e.Handled = true;
                                if (this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position == 0)
                                {
                                    // �Ȃ�
                                }
                                else
                                {
                                    // �O���b�h�\�������ɃX�N���[��
                                    this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position - 40;
                                }
                            }
                            break;
                        }
                    case Keys.Right:
                        {
                            // �����L�[
                            if (e.KeyCode == Keys.Right)
                            {
                                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                                e.Handled = true;
                                // �O���b�h�\�����E�ɃX�N���[��
                                this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarSearchList.DisplayLayout.ColScrollRegions[0].Position + 40;
                            }
                            break;
                            //----------ADD 2009/10/10-------<<<<<
                        }
                }
                return;
            }

        }

        /// <summary>
        /// �X�y�[�X�L�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �X�y�[�X�L�[���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.10.10</br>
        /// </remarks>
        private void uGrid_CarPartsTotalList_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_CarPartsTotalList.ActiveRow == null) return;
            // �ŏ�s�ł́��L�[
            if (this.uGrid_CarPartsTotalList.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                    e.Handled = true;
                }
            }
            // �����L�[
            if (e.KeyCode == Keys.Right)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                // �O���b�h�\�����E�ɃX�N���[��
                this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position + 40;
            }
            // �����L�[
            if (e.KeyCode == Keys.Left)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                if (this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                }
                else
                {
                    // �O���b�h�\�������ɃX�N���[��
                    this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarPartsTotalList.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }

        }

        /// <summary>
        /// �X�y�[�X�L�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note        : �X�y�[�X�L�[���ɔ������܂��B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2009.10.10</br>
        /// </remarks>
        private void uGrid_CarPartsList_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_CarPartsList.ActiveRow == null) return;
            // �ŏ�s�ł́��L�[
            if (this.uGrid_CarPartsList.ActiveRow.Index == 0)
            {
                if (e.KeyCode == Keys.Up)
                {
                    // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                    e.Handled = true;
                }
            }
            // �����L�[
            if (e.KeyCode == Keys.Right)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                // �O���b�h�\�����E�ɃX�N���[��
                this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position + 40;
            }
            // �����L�[
            if (e.KeyCode == Keys.Left)
            {
                // �L�[�������ꂽ���Ƃɂ��f�t�H���g�̃O���b�h������L�����Z������
                e.Handled = true;
                if (this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position == 0)
                {
                }
                else
                {
                    // �O���b�h�\�������ɃX�N���[��
                    this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_CarPartsList.DisplayLayout.ColScrollRegions[0].Position - 40;
                }
            }
        }

        /// <summary>
        /// double��string�ύX
        /// </summary>
        /// <param name="numberValue">����</param>
        /// <remarks>
        /// <br>Note        : double��string�ύX���ɔ������܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private string douToStrChange(double numberValue)
        {
            return numberValue.ToString("N");
        }

        //-----------DEL 2009/10/10---------->>>>>
        ///// <summary>
        ///// long��string�ύX
        ///// </summary>
        ///// <param name="numberValue">����</param>
        ///// <remarks>
        ///// <br>Note        : long��string�ύX���ɔ������܂��B</br>
        ///// <br>Programmer  : 杍^</br>
        ///// <br>Date        : 2009.09.10</br>
        ///// </remarks>
        //private string longToStrChange(long numberValue)
        //{
        //    return numberValue.ToString("N");
        //}
        ///// <summary>
        ///// int��string�ύX
        ///// </summary>
        ///// <param name="numberValue">����</param>
        ///// <remarks>
        ///// <br>Note        : int��string�ύX���ɔ������܂��B</br>
        ///// <br>Programmer  : 杍^</br>
        ///// <br>Date        : 2009.09.10</br>
        ///// </remarks>
        //private string intToStrChange(int numberValue)
        //{
        //    return numberValue.ToString("N");
        //}
        //-----------DEL 2009/10/10----------<<<<<

        #endregion

        # region �� ÷�ďo�͏��� ��
        /// <summary>
        /// ���÷�ďo�͏���
        /// </summary>
        /// <remarks>
        /// <br>Note        : ÷�ďo�͂��N���b�N���ɔ������܂��B</br>      
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private int TextOutput()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // �e�L�X�g�o�͗p�_�C�A���O�ɕK�v�ȏ����Z�b�g����
            SFCMN06002C printInfo;
            status = this.GetPrintInfo(out printInfo);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return -1;
            }

            CustomTextProviderInfo customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            CustomTextWriter customTextWriter = new CustomTextWriter();
            customTextProviderInfo.OutPutFileName = printInfo.outPutFilePathName;
            // �㏑���^�ǉ��t���O���Z�b�g(true:�ǉ�����Afalse:�㏑������)
            customTextProviderInfo.AppendMode = printInfo.overWriteFlag;
            // �X�L�[�}�擾
            customTextProviderInfo.SchemaFileName = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, printInfo.prpid);

            DataTable outDataTable = new DataTable();

            if (this.uGrid_CarSearchList.Visible == true)
            {
                outDataTable = this.carSearchTable.DefaultView.ToTable();
            }
            else if (this.uGrid_CarPartsList.Visible == true)
            {
                outDataTable = this.carPartsTable.DefaultView.ToTable();
            }
            else if (this.uGrid_CarPartsTotalList.Visible == true)
            {
                outDataTable = this.carPartsTotalTable;
            }


            // CSV�o��
            status = customTextWriter.WriteText(outDataTable, customTextProviderInfo.SchemaFileName, customTextProviderInfo.OutPutFileName, customTextProviderInfo);

            string resultMessage = "";

            switch (status)
            {
                case 0:    // ��������
                    resultMessage = "CSV�o�͂��������܂����B";
                    break;
                case -9:    // �o�͑ΏۊO�̃f�[�^���w�肳�ꂽ
                    resultMessage = "�o�͑ΏۊO�̃f�[�^���w�肳��܂����B";
                    break;
                default:    // ���̑��G���[
                    resultMessage = "���̑��̃G���[���������܂����B�X�e�[�^�X(" + status.ToString() + ")";
                    break;
            }

            if (!string.IsNullOrEmpty(resultMessage))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    resultMessage,
                    status, MessageBoxButtons.OK);
            }

            return status;
        }
        #endregion

        #region �� �o�͏��擾���� ��
        /// <summary>
        /// �o�͏��擾����
        /// </summary>
        /// <param name="printInfo">�o�͏��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �o�͏����擾���܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private int GetPrintInfo(out SFCMN06002C printInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ������p�����[�^
            printInfo = new SFCMN06002C();
            // ���[�I���K�C�h
            SFCMN00391U printDialog = new SFCMN00391U();

            printInfo.enterpriseCode = _enterpriseCode;
            // �N���o�f�h�c
            printInfo.kidopgid = CT_PGID;
            printInfo.selectInfoCode = 1;
            if (this.uGrid_CarSearchList.Visible == true)
            {
                printInfo.PrintPaperSetCd = 0;
            }
            else if (this.uGrid_CarPartsList.Visible == true)
            {
                printInfo.PrintPaperSetCd = 1;
            }
            else if (this.uGrid_CarPartsTotalList.Visible == true)
            {
                printInfo.PrintPaperSetCd = 2;
            }

            // ���[�I���K�C�h
            printDialog.PrintMode = 1;
            printDialog.PrintInfo = printInfo;
            DialogResult dialogResult = printDialog.ShowDialog();
            switch (dialogResult)
            {
                case DialogResult.OK:
                    if (File.Exists(printInfo.outPutFilePathName) == false)
                    {
                        // �t�@�C���Ȃ�
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    }
                    else
                    {
                        // �t�@�C�������݂���ꍇ�́A�I�[�v���`�F�b�N
                        try
                        {
                            // ���ɖ��̂�ύX
                            string tempFileName = printInfo.outPutFilePathName
                                                + DateTime.Now.Ticks.ToString();
                            FileInfo fi = new FileInfo(printInfo.outPutFilePathName);
                            fi.MoveTo(tempFileName);
                            // ���̂̕ύX���������s�����̂ŁA���̂����ɖ߂�
                            fi.MoveTo(printInfo.outPutFilePathName);

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        catch (Exception)
                        {
                            // ���̕ύX���s -> ���̃A�v���P�[�V�������r���Ŏg�p��
                            TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                        "�w�肳�ꂽ�t�@�C���͎g�p�ł��܂���B\r\n"
                                        + "Excel�����g�p���Ă��Ȃ����m�F���āA\r\n"
                                        + "�g�p���Ă���Ƃ��̓t�@�C������ĉ������B",
                                        0, MessageBoxButtons.OK);

                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                    }
                    break;
                case DialogResult.Cancel:
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    break;
                default:
                    // ��O������
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    break;
            }

            return status;
        }
        #endregion

        #region �� �S�̏����l�擾���� ��
        /// <summary>
        /// �S�̏����l�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �S�̏����l���擾���܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        public int ReadInitData(string enterpriseCode)
        {
            // �S�̏����l�ݒ�}�X�^
            AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
            AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
            ArrayList retAllDefSetList;
            int status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
            }
            else
            {
                this._allDefSet = null;
            }
            return status;
        }

        /// <summary>
        /// �S�̏����l�擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="allDefSetArrayList">�S�̏����l</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �S�̏����l���擾���܂��B</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2009.09.10</br>
        /// </remarks>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            if (allDefSetArrayList == null) return null;

            List<AllDefSet> list = new List<AllDefSet>((AllDefSet[])allDefSetArrayList.ToArray(typeof(AllDefSet)));

            AllDefSet allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (allSecAllDefSet != null) return allSecAllDefSet;

            allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return allSecAllDefSet;
        }
        #endregion

        /// <summary>
        /// ���Y�N���擾����(�a���^����)
        /// </summary>
        /// <param name="produceTypeOfYear">���Y�N��</param>
        /// <remarks>
        /// <br>Note       : ���Y�N���擾����(�a���^����)�ł��B</br>      
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>UpdateNote   2019/01/08  杍^</br>
        /// <br>�C�����e     �V�����̑Ή�</br>
        /// </remarks>
        private string GetProduceTypeOfYear(DateTime produceTypeOfYear)
        {
            string retYear = string.Empty;
            if (produceTypeOfYear != DateTime.MinValue)
            {
                if (this._allDefSet.EraNameDispCd1 == 0)
                {
                    // 0:����
                    int iyy = produceTypeOfYear.Year;
                    int imm = produceTypeOfYear.Month;
                    retYear = (produceTypeOfYear != DateTime.MinValue) ? string.Format(@"{0:0000}{1:\.00}", iyy, imm) : string.Empty;
                }
                else
                {
                    // 1:�a��
                    //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ---->>>>>
                    //System.Globalization.DateTimeFormatInfo FormatInfo = null;
                    //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");
                    //System.Globalization.Calendar calendar = new System.Globalization.JapaneseCalendar();
                    //culture.DateTimeFormat.Calendar = calendar;
                    //FormatInfo = culture.DateTimeFormat;
                    //FormatInfo.Calendar = calendar;

                    //retYear = produceTypeOfYear.ToString("gyy/MM/dd", culture);

                    //int Era = FormatInfo.Calendar.GetEra(produceTypeOfYear);
                    //string eraString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    //string eraName = string.Empty;
                    //string tempRetYear = string.Empty;
                    //tempRetYear = retYear.Substring(2, retYear.Length - 2);
                    //for (int eraCounter = 0; eraCounter < eraString.Length; eraCounter++)
                    //{
                    //    if (FormatInfo.GetEra(eraString[eraCounter].ToString()) == Era)
                    //    {
                    //        eraName = eraString[eraCounter].ToString();
                    //        break;
                    //    }
                    //}
                    //tempRetYear = eraName + tempRetYear;
                    //retYear = tempRetYear.Remove(tempRetYear.Length - 3);
                    //retYear = retYear.Replace('/', '.');

                    retYear = TDateTime.DateTimeToString("ggYY.MM", produceTypeOfYear);
                    //---- UPD 杍^  2019/01/08 FOR �V�����̑Ή� ----<<<<<
                }
            }
            return retYear;
        }

        /// <summary>
        /// ���Y�N���͈͐ݒ菈��
        /// </summary>
        /// <param name="stProduceTypeOfYear"></param>
        /// <param name="edProduceTypeOfYear"></param>
        /// <returns>retString</returns>
        /// <remarks>
        /// <br>Note       : ���Y�N���͈͐ݒ菈���ł��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private string SettingProduceTypeOfYearRange(string stProduceTypeOfYear, string edProduceTypeOfYear)
        {
            string retString = string.Empty;
            int maxLength = 7;

            stProduceTypeOfYear = stProduceTypeOfYear.PadRight(maxLength, ' ');
            edProduceTypeOfYear = edProduceTypeOfYear.PadRight(maxLength, ' ');
            if ((string.IsNullOrEmpty(stProduceTypeOfYear.Trim())) && (string.IsNullOrEmpty(edProduceTypeOfYear.Trim())))
            {
                retString = string.Empty;
            }
            else
            {
                retString = stProduceTypeOfYear + "-" + edProduceTypeOfYear;
            }

            return retString;
        }

    }
}
