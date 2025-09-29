//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����`�[����
// �v���O�����T�v   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/06/12  �C�����e : �g�у��[���@�\�̑g��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10703874-00 �쐬�S�� : yangyi
// �� �� ��  K2011/08/12 �C�����e : �C�X�R�ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900269-00 �쐬�S�� : FSI���� ���T
// �� �� ��  2013/03/21  �C�����e : SPK�ԑ�ԍ�������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070071-00 �쐬�S�� : �{�{�@����
// �� �� ��  2014/05/19  �C�����e : �d�|�ꗗ��2218 ���q���l���ɃR�[�h���͍��ڂ�ǉ�
//----------------------------------------------------------------------------//

unit MAHNB01012BAP;

interface

uses ShareMem, SysUtils, HDllCall, DBClient, HFSLLIB, MAHNB01012C,
    MAHNB01012BMP, messages, classes, windows, controls, dialogs;

/////////////// Delphi���ւ̃G�N�X�|�[�g�֐��錾 //////////////////////////

// �ԗ���������
function MAHNB01012B_CarSearch(condition: TCarSearchCondition;
    salesRowNo: Integer;
    conditionType: Integer)
    : Integer; stdcall;


// �ԗ����s�I�u�W�F�N�g�擾
function MAHNB01012B_GetCarInfoRow(salesRowNo: Integer;
    getCarInfoMode: Integer;
    var carInfo: TCarInfo)
    : Integer; stdcall;

// �I�v�V������񏈗�
function MAHNB01012B_GetSettingOptionInfo(var optCarMng: Integer;
    var optStockingPayment: Integer)
    : Integer; stdcall;


// �J���[���擾����
function MAHNB01012B_GetColorInfo(carRelationGuid: WideString;
    var colorInfoList: TSalesSlipInputCustomArrayB2)
    : Integer; stdcall;


// �I���J���[���擾����
function MAHNB01012B_GetSelectColorInfo(carRelationGuid: WideString;
    var colorInfo: TColorInfo)
    : Integer; stdcall;


// �g�������擾����
function MAHNB01012B_GetTrimInfo(carRelationGuid: WideString;
    var trimInfoList: TSalesSlipInputCustomArrayB3)
    : Integer; stdcall;


// �I���g�������擾����
function MAHNB01012B_GetSelectTrimInfo(carRelationGuid: WideString;
    var trimInfo: TTrimInfo)
    : Integer; stdcall;


// �������擾����
function MAHNB01012B_GetEquipInfo(carRelationGuid: WideString;
    var cEqpDefDspInfoList: TSalesSlipInputCustomArrayB4)
    : Integer; stdcall;


// �J���[���I������
function MAHNB01012B_SelectColorInfo(carRelationGuid: WideString;
    colorCode: WideString)
    : Integer; stdcall;


// �g�������I������
function MAHNB01012B_SelectTrimInfo(carRelationGuid: WideString;
    trimCode: WideString)
    : Integer; stdcall;


// ���Y�N���͈̓`�F�b�N
function MAHNB01012B_CheckProduceTypeOfYearRange(carRelationGuid: WideString;
    firstEntryDate: Integer)
    : Integer; stdcall;


// �ԗ������f�[�^�e�[�u���N���ݒ菈��
function MAHNB01012B_SettingCarModelUIDataFromFirstEntryDate(carRelationGuid: WideString;
    firstEntryDate: WideString)
    : Integer; stdcall;


// �ԑ�ԍ��͈̓`�F�b�N
function MAHNB01012B_CheckProduceFrameNo(carRelationGuid: WideString;
    inputFrameNo: WideString;
    searchFrameNo: Integer)
    : Integer; stdcall;


// �ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈��
function MAHNB01012B_SettingCarModelUIDataFromProduceFrameNo(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;


// �Ώ۔N���擾����(�ԑ�ԍ����擾)
function MAHNB01012B_GetProduceTypeOfYear(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;


// �ԗ����e�[�u���̃N���A
function MAHNB01012B_ClearCarInfoRow(salesRowNo: Integer)
    : Integer; stdcall;


// �ԗ����e�[�u���s�̔N���Z�b�g
function MAHNB01012B_SettingCarInfoRowFromFirstEntryDate(salesRowNo: Integer;
    firstEntryDate: Integer)
    : Integer; stdcall;


// �ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g
function MAHNB01012B_SettingCarInfoRowFromFrameNo(salesRowNo: Integer;
    frameNo: WideString)
    : Integer; stdcall;


// �ԗ����e�[�u���s�̎Ԏ���Z�b�g
function MAHNB01012B_SettingCarInfoRowFromModelInfo(salesRowNo: Integer;
    makerCode: Integer;
    makerFullName: WideString;
    makerHalfName: WideString;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    modelHalfName: WideString)
    : Integer; stdcall;


// �Ԏ햼�̎擾����
function MAHNB01012B_GetModelFullName(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;


// �Ԏ피�p���̎擾����
function MAHNB01012B_GetModelHalfName(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;


// �ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g
function MAHNB01012B_SettingCarInfoRowFromCarMngCode(salesRowNo: Integer;
    carMngCode: WideString)
    : Integer; stdcall;


// �ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g
function MAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo: Integer;
    modelDesignationNo: Integer;
    categoryNo: Integer)
    : Integer; stdcall;


// �ԗ����e�[�u���s�̌^���Z�b�g
function MAHNB01012B_SettingCarInfoRowFromFullModel(salesRowNo: Integer;
    fullModel: WideString)
    : Integer; stdcall;


// �ԗ����e�[�u���s�̃G���W���^���Z�b�g
function MAHNB01012B_SettingCarInfoRowFromEngineModelNm(salesRowNo: Integer;
    engineModelNm: WideString)
    : Integer; stdcall;


// �ԗ���񑶍݃`�F�b�N
function MAHNB01012B_ExistCarInfo()
    : Integer; stdcall;

// --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------>>>>>
// �ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g
function MAHNB01012B_SettingCarInfoRowFromCarNoteCode(salesRowNo: Integer;
    carNoteCode: Integer)
    : Integer; stdcall;
// --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------<<<<<

// �ԗ����e�[�u���s�̎��q���l�Z�b�g
function MAHNB01012B_SettingCarInfoRowFromCarNote(salesRowNo: Integer;
    carNote: WideString)
    : Integer; stdcall;


// �ԗ����e�[�u���s�̎��q���s�����Z�b�g
function MAHNB01012B_SettingCarInfoRowFromMileage(salesRowNo: Integer;
    mileage: Integer)
    : Integer; stdcall;

// add by gaofeng start

// ���_�K�C�h����
function MAHNB01012B_sectionGuide(enterpriseCode: WideString;
    formName: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

// ����K�C�h����
function MAHNB01012B_subSectionGuide(enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

// �]�ƈ��K�C�h����
function MAHNB01012B_employeeGuide(sender: WideString;
    enterpriseCode: WideString;
    salesInputNm: WideString;
    salesInputCode: WideString;
    var salesSlip: TSalesSlip;
    var isReInputErr: Boolean)
    : Integer; stdcall;

// �Ǘ��ԍ��K�C�h����
function MAHNB01012B_carMngNoGuide(customerCode: Integer;
    enterpriseCode: WideString;
    var selectedInfo: TCarMangInputExtraInfo;
    var resultStatus: Integer;
    salesRowNo: Integer;
    carMngCode: string)
    : Integer; stdcall;

// �Ԏ�K�C�h����
function MAHNB01012B_modelFullGuide(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var modelNameU: TModelNameU)
    : Integer; stdcall;

// ���l�K�C�h�{�{�^������
function MAHNB01012B_slipNote(sender: WideString;
    enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

// ���Z�菈��
function MAHNB01012B_GetRate(numerator: Double;
    denominator: Double;
    var rate: Double)
    : Integer; stdcall;

// --- ADD 2010/05/31 ---------->>>>>
// CalculationSalesPrice
function MAHNB01012B_CalculationSalesPrice()
    : Integer; stdcall;
// --- ADD 2010/05/31 ----------<<<<<
// add by gaofeng end

    // add by Zhangkai start


    // add by Zhangkai end

    // add by Lizc start
// �J�[���[�J�[�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterMakerCodeFocus(makerCode: Integer;
    salesRowNo: Integer;
    var makerName: WideString)
    : Integer; stdcall;


// �Ԏ�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterModelCodeFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;


// �Ԏ�ď̃R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterModelSubCodeFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;


// �Ԏ햼�̂̃t�H�[�J�X����
function MAHNB01012B_AfterModelFullNameFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    salesRowNo: Integer)
    : Integer; stdcall;


// �N���̃t�H�[�J�X����
function MAHNB01012B_AfterFirstEntryDateFocus(firstEntryDate: Integer;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;
    
// �ԑ�ԍ��̃t�H�[�J�X����
function MAHNB01012B_AfterProduceFrameNoFocus(produceFrameNo: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean;
    mode : Integer)
    : Integer; stdcall;

// �ǉ����^�u����Visible�ݒ�
function MAHNB01012B_SettingAddInfoVisible(customerCode: Integer;
    carMngCode: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;
    
// �Ԏ�ύX�{�^��Visible
function MAHNB01012B_GetChangeCarInfoVisible(customerCode: Integer;
    carMngCode: WideString;
    var visibleFlag: Integer)
    : Integer; stdcall;
    
// �Ǘ��ԍ��̃t�H�[�J�X����
function MAHNB01012B_AfterCarMngCodeFocus(carMngCode: WideString;
    customerCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var selectedInfo: TCarMangInputExtraInfo;
    var returnFlag: Boolean;
    var clearCarInfoFlag: Boolean)
    : Integer; stdcall;
    
// ���_�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterSectionCodeFocus(sectionCode: WideString;
    var refSalesSlip: TSalesSlip)
    : Integer; stdcall;
    
// ���喼�̎擾����
function MAHNB01012B_GetNameFromSubSection(subSectionCode: Integer;
    var subSectionNm: WideString)
    : Integer; stdcall;
    
// �S���ҕύX����
function MAHNB01012B_ChangeSalesEmployee(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;
    
// �󒍎ҕύX����
function MAHNB01012B_ChangeFrontEmployee(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;


// ���s�ҕύX����
function MAHNB01012B_ChangeSalesInput(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;
    
// �`�[�敪�ύX����
function MAHNB01012B_ChangeSalesSlip(var refSalesSlip: TSalesSlip;
    isCache: Boolean;
    code: Integer;
    var refChangeSalesSlipDisplay: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;


// ���i�敪�ύX����
function MAHNB01012B_ChangeSalesGoodsCd(salesSlipCurrent: TSalesSlip;
    code: Integer;
    var refChangeSalesGoodsCd: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;
    
// ���Ӑ�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterCustomerCodeFocus(var refSalesSlip: TSalesSlip;
    code: Integer;
    var refCustomerInfo: TCustomerInfo;
    var clearAddCarInfo: Boolean;
    var refCanChangeFocus: Boolean;
    var refReCalcSalesPrice: Boolean;
    var refGuideStart: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean;
    var refReCalcSalesUnitPrice: Boolean;
    var refClearRateInfo: Boolean)
    : Integer; stdcall;
    
// �`�[�ԍ��̃t�H�[�J�X����
function MAHNB01012B_AfterSalesSlipNumFocus(var refSalesSlip: TSalesSlip;
    var refSalesSlipCurrent: TSalesSlip;
    code: WideString;
    enterpriseCode: WideString;
    var equelFlag: Boolean;
    var readDBDatStatus: Integer;
    var refReCalcSalesPrice: Boolean;
    var deleteEmptyRow: Boolean;
    var findDataFlg: Boolean)   // ADD 2010/07/01
    : Integer; stdcall;


// �󒍃X�e�[�^�X���X�g�쐬
function MAHNB01012B_SetStateList()
    : Integer; stdcall;
    
// ������̃t�H�[�J�X����
function MAHNB01012B_AfterSalesDateFocus(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    salesDate: Int64;
    salesDateText: WideString;
    var refReCalcSalesUnitPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    var refTaxRate: Double;
    var refReCanChangeFocus: Boolean) // ADD K2011/08/12
    : Integer; stdcall;


// �[����R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterAddresseeCodeFocue(var refSalesSlip: TSalesSlip;
    code: Integer;
    enterpriseCode: WideString;
    var refReCalcSalesPrice: Boolean)
    : Integer; stdcall;
    
// ����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B
function MAHNB01012B_CacheForChange(salesSlip: TSalesSlip)
    : Integer; stdcall;

// ��������̓��e�Ɣ�r
function MAHNB01012B_CompareSalesSlip(salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var compareRes: Boolean)
    : Integer; stdcall;
    
// ����P���Čv�Z
function MAHNB01012B_ReCalcSalesUnitPrice(var refSalesSlip: TSalesSlip)
    : Integer; stdcall;


// �|�����N���A�����i�S�āj
function MAHNB01012B_ClearAllRateInfo()
    : Integer; stdcall;


// ���l�P�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterSlipNoteCodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;


// ���l�Q�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterSlipNote2CodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer;
    var refReCanChangeFocus: Boolean) // ADD K2011/08/12
    : Integer; stdcall;

// ----- ADD K2011/08/12 --------------------------->>>>>
// ���l�Q�̃t�H�[�J�X����
function MAHNB01012B_AfterSlipNote2Focus(salesSlip: TSalesSlip;
    slipNote2: WideString;
    var refReCanChangeFocus: Boolean)
    : Integer; stdcall;
// ----- ADD K2011/08/12 ---------------------------<<<<<


// ���l�R�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterSlipNote3CodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;
    
// ����f�[�^����
function MAHNB01012B_GetSalesSlip(var salesSlip: TSalesSlip)
    : Integer; stdcall;
    
// ������m�F�{�^���N���b�N
function MAHNB01012B_CustomerClaimConfirmationClick(salesDate: Int64;
    var focus: WideString)
    : Integer; stdcall;


// �[����m�F�{�^���N���b�N
function MAHNB01012B_AddresseeConfirmationClick(var salesSlip: TSalesSlip)
    : Integer; stdcall;
    
// ���㖾�׃f�[�^�̑��݃`�F�b�N
function MAHNB01012B_ExistSalesDetail(var exist: Boolean)
    : Integer; stdcall;


// ����`���ύX�\�`�F�b�N����
function MAHNB01012B_ChangeCheckAcptAnOdrStatus(code: Integer;
    salesSlip: TSalesSlip;
    var clearDisplayCarInfo: Boolean;
    var clearAddUpInfo: Boolean;
    var result1: Boolean)
    : Integer; stdcall;


// ����`���ύX�\����
function MAHNB01012B_ChangeAcptAnOdrStatus(code: Integer;
    var refSalesSlip: TSalesSlip;
    svCode: Integer)
    : Integer; stdcall;


// ����f�[�^�L���b�V������
function MAHNB01012B_Cache(salesSlip: TSalesSlip)
    : Integer; stdcall;
    
// �\���p�`�[�敪���A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂�
function MAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay(var refSalesSlip: TSalesSlip)
    : Integer; stdcall;
    
// �������I������
function MAHNB01012B_SelectEquipInfo(carRelationGuid: WideString;
    equipmentGenreCd: WideString;
    equipmentName: WideString)
    : Integer; stdcall;
    
// �f�[�^�ύX�t���O�̐ݒ菈��
function MAHNB01012B_SetGetIsDataChanged(flag: Integer;
    var refIsDataChanged: Boolean)
    : Integer; stdcall;
    
// �w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞����
function MAHNB01012B_GetHeaderFocusConstructionListValue(var headerFocusConstructionList: TSalesSlipInputCustomArrayB5;
    var footerFocusConstructionList: TSalesSlipInputCustomArrayB6)
    : Integer; stdcall;


// �t�H�[�J�X�ݒ胊�X�g�̎捞����
function MAHNB01012B_GetFocusConstructionValue(var headerList: WideString;
    var footerList: WideString)
    : Integer; stdcall;
    
// ���_���̂̎捞����
function MAHNB01012B_GetSectionNm(section: WideString;
    var sectionName: WideString)
    : Integer; stdcall;

// --- ADD 2010/07/16 ---------->>>>>    
// �ԗ������敪�̎捞����
function MAHNB01012B_SetGetSearchCarDiv(flag: Integer;
    var refSearchCarDiv: Boolean)
    : Integer; stdcall;
// --- ADD 2010/07/16 ----------<<<<<

// --- ADD 2012/02/09 ---------->>>>>
// ������t���O�̎捞����
function MAHNB01012B_GetPrintThreadOverFlag(var printThreadOverFlag: Boolean)
    : Integer; stdcall;
// --- ADD 2012/02/09  ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
// �c�[���`�b�v��������
// �c�[���`�b�v��������
function MAHNB01012B_CreateStockCountInfoString(salesRowNo: Integer;
    var StockCountInfo: WideString)
    : Integer; stdcall;

    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

// --- ADD m.suzuki 2010/06/12 ---------->>>>>
procedure MAHNB01012B_MakeMailDefaultData( var fileName: WideString ); stdcall;
// --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
function MAHNB01012B_CopyToRC(salesRowNo: Integer) : Integer; stdcall;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// --- ADD 2013/03/21 ---------->>>>>
// �n���h���ʒu�`�F�b�N����
function MAHNB01012B_CheckHandlePosition(carRelationGuid: WideString;
    vinCode: WideString)
    : Boolean; stdcall;
// --- ADD 2013/03/21 ----------<<<<<

implementation

// �I�v�V������񏈗�
function MAHNB01012B_GetSettingOptionInfo(var optCarMng: Integer;
    var optStockingPayment: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultOptCarMng: Integer;
    resultOptStockingPayment: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    optCarMng := 0;
    optStockingPayment := 0;

    try
        try
            // ���ʃf�[�^��������
            resultOptCarMng := 0;
            resultOptStockingPayment := 0;

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetSettingOptionInfo(resultOptCarMng, resultOptStockingPayment);
            // ���ʃR�s�[
            optCarMng := resultOptCarMng;
            optStockingPayment := resultOptStockingPayment;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

        // ���b�Z�[�W�̃��������
    end;
end;

// �ԗ���������
function MAHNB01012B_CarSearch(condition: TCarSearchCondition;
    salesRowNo: Integer;
    conditionType: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_CarSearch(condition, salesRowNo, conditionType);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����s�I�u�W�F�N�g�擾
function MAHNB01012B_GetCarInfoRow(salesRowNo: Integer;
    getCarInfoMode: Integer;
    var carInfo: TCarInfo)
    : Integer; stdcall;

var
    status: Integer;
    resultCarInfo: TCarInfo;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTCarInfo(resultCarInfo);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetCarInfoRow(salesRowNo, getCarInfoMode, resultCarInfo);
            // ���ʃR�s�[
            carInfo := resultCarInfo;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �J���[���擾����
function MAHNB01012B_GetColorInfo(carRelationGuid: WideString;
    var colorInfoList: TSalesSlipInputCustomArrayB2)
    : Integer; stdcall;

var
    status: Integer;
    //resultColorInfoList: TSalesSlipInputCustomArrayB2;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetColorInfo(carRelationGuid, colorInfoList);
            // ���ʃR�s�[
            //colorInfoList := resultColorInfoList;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������
        //gpxSalesSlipInputAcs_FreeCustomArrayB2(@colorInfoList, 0);

    end;
end;

// �I���J���[���擾����
function MAHNB01012B_GetSelectColorInfo(carRelationGuid: WideString;
    var colorInfo: TColorInfo)
    : Integer; stdcall;

var
    status: Integer;
    resultColorInfo: TColorInfo;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTColorInfo(resultColorInfo);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetSelectColorInfo(carRelationGuid, resultColorInfo);
            // ���ʃR�s�[
            colorInfo := resultColorInfo;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �g�������擾����
function MAHNB01012B_GetTrimInfo(carRelationGuid: WideString;
    var trimInfoList: TSalesSlipInputCustomArrayB3)
    : Integer; stdcall;

var
    status: Integer;
    //resultTrimInfoList: TSalesSlipInputCustomArrayB3;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetTrimInfo(carRelationGuid, trimInfoList);
            // ���ʃR�s�[
            //trimInfoList := resultTrimInfoList;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������
        //gpxSalesSlipInputAcs_FreeCustomArrayB3(@resultTrimInfoList, 0);

    end;
end;

// �I���g�������擾����
function MAHNB01012B_GetSelectTrimInfo(carRelationGuid: WideString;
    var trimInfo: TTrimInfo)
    : Integer; stdcall;

var
    status: Integer;
    resultTrimInfo: TTrimInfo;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTTrimInfo(resultTrimInfo);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetSelectTrimInfo(carRelationGuid, resultTrimInfo);
            // ���ʃR�s�[
            trimInfo := resultTrimInfo;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �������擾����
function MAHNB01012B_GetEquipInfo(carRelationGuid: WideString;
    var cEqpDefDspInfoList: TSalesSlipInputCustomArrayB4)
    : Integer; stdcall;

var
    status: Integer;
    //resultCEqpDefDspInfoList: TSalesSlipInputCustomArrayB4;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetEquipInfo(carRelationGuid, cEqpDefDspInfoList);
            // ���ʃR�s�[
            //cEqpDefDspInfoList := resultCEqpDefDspInfoList;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������
        //gpxSalesSlipInputAcs_FreeCustomArrayB4(@resultCEqpDefDspInfoList, 0);

    end;
end;

// �J���[���I������
function MAHNB01012B_SelectColorInfo(carRelationGuid: WideString;
    colorCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SelectColorInfo(carRelationGuid, colorCode);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �g�������I������
function MAHNB01012B_SelectTrimInfo(carRelationGuid: WideString;
    trimCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SelectTrimInfo(carRelationGuid, trimCode);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���Y�N���͈̓`�F�b�N
function MAHNB01012B_CheckProduceTypeOfYearRange(carRelationGuid: WideString;
    firstEntryDate: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_CheckProduceTypeOfYearRange(carRelationGuid, firstEntryDate);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ������f�[�^�e�[�u���N���ݒ菈��
function MAHNB01012B_SettingCarModelUIDataFromFirstEntryDate(carRelationGuid: WideString;
    firstEntryDate: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate(carRelationGuid, firstEntryDate);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԑ�ԍ��͈̓`�F�b�N
function MAHNB01012B_CheckProduceFrameNo(carRelationGuid: WideString;
    inputFrameNo: WideString;
    searchFrameNo: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_CheckProduceFrameNo(carRelationGuid, inputFrameNo, searchFrameNo);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈��
function MAHNB01012B_SettingCarModelUIDataFromProduceFrameNo(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo(carRelationGuid, frameNo);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �Ώ۔N���擾����(�ԑ�ԍ����擾)
function MAHNB01012B_GetProduceTypeOfYear(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetProduceTypeOfYear(carRelationGuid, frameNo);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����e�[�u���̃N���A
function MAHNB01012B_ClearCarInfoRow(salesRowNo: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ClearCarInfoRow(salesRowNo);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����e�[�u���s�̔N���Z�b�g
function MAHNB01012B_SettingCarInfoRowFromFirstEntryDate(salesRowNo: Integer;
    firstEntryDate: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g
function MAHNB01012B_SettingCarInfoRowFromFrameNo(salesRowNo: Integer;
    frameNo: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo(salesRowNo, frameNo);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����e�[�u���s�̎Ԏ���Z�b�g
function MAHNB01012B_SettingCarInfoRowFromModelInfo(salesRowNo: Integer;
    makerCode: Integer;
    makerFullName: WideString;
    makerHalfName: WideString;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    modelHalfName: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, makerFullName, makerHalfName, modelCode, modelSubCode, modelFullName, modelHalfName);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �Ԏ햼�̎擾����
function MAHNB01012B_GetModelFullName(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetModelFullName(makerCode, modelCode, modelSubCode);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �Ԏ피�p���̎擾����
function MAHNB01012B_GetModelHalfName(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetModelHalfName(makerCode, modelCode, modelSubCode);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g
function MAHNB01012B_SettingCarInfoRowFromCarMngCode(salesRowNo: Integer;
    carMngCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode(salesRowNo, carMngCode);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g
function MAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo: Integer;
    modelDesignationNo: Integer;
    categoryNo: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, modelDesignationNo, categoryNo);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����e�[�u���s�̌^���Z�b�g
function MAHNB01012B_SettingCarInfoRowFromFullModel(salesRowNo: Integer;
    fullModel: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromFullModel(salesRowNo, fullModel);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����e�[�u���s�̃G���W���^���Z�b�g
function MAHNB01012B_SettingCarInfoRowFromEngineModelNm(salesRowNo: Integer;
    engineModelNm: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm(salesRowNo, engineModelNm);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ���񑶍݃`�F�b�N
function MAHNB01012B_ExistCarInfo()
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ExistCarInfo();
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------>>>>>
// �ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g
function MAHNB01012B_SettingCarInfoRowFromCarNoteCode(salesRowNo: Integer;
    carNoteCode: Integer)
    : Integer; stdcall;

var
    status: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode(salesRowNo, carNoteCode);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;
// --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------<<<<<

// �ԗ����e�[�u���s�̎��q���l�Z�b�g
function MAHNB01012B_SettingCarInfoRowFromCarNote(salesRowNo: Integer;
    carNote: WideString)
    : Integer; stdcall;

var
    status: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNote(salesRowNo, carNote);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԗ����e�[�u���s�̎��q���s�����Z�b�g
function MAHNB01012B_SettingCarInfoRowFromMileage(salesRowNo: Integer;
    mileage: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromMileage(salesRowNo, mileage);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;
// add by gaofeng start

function MAHNB01012B_sectionGuide(enterpriseCode: WideString;
    formName: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_sectionGuide(enterpriseCode, formName, resultSalesSlip);
            // ���ʃR�s�[
            salesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

        // ���b�Z�[�W�̃��������
    end;
end;

// ����K�C�h����
function MAHNB01012B_subSectionGuide(enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_subSectionGuide(enterpriseCode, resultSalesSlip);
            // ���ʃR�s�[
            salesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

        // ���b�Z�[�W�̃��������
    end;
end;

// �]�ƈ��K�C�h����
function MAHNB01012B_employeeGuide(sender: WideString;
    enterpriseCode: WideString;
    salesInputNm: WideString;
    salesInputCode: WideString;
    var salesSlip: TSalesSlip;
    var isReInputErr: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultIsReInputErr: Boolean;
    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_employeeGuide(sender, enterpriseCode, salesInputNm, salesInputCode, resultSalesSlip, resultIsReInputErr);
            // ���ʃR�s�[
            salesSlip := resultSalesSlip;
            isReInputErr := resultIsReInputErr;
            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

        // ���b�Z�[�W�̃��������
    end;
end;

// �Ǘ��ԍ��K�C�h����
function MAHNB01012B_carMngNoGuide(customerCode: Integer;
    enterpriseCode: WideString;
    var selectedInfo: TCarMangInputExtraInfo;
    var resultStatus: Integer;
    salesRowNo: Integer;
    carMngCode: string)
    : Integer; stdcall;
var
    status: Integer;
    resultSelectedInfo: TCarMangInputExtraInfo;
    paraStatus: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTCarMangInputExtraInfo(resultSelectedInfo);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_carMngNoGuide(customerCode, enterpriseCode, resultSelectedInfo, paraStatus, salesRowNo, carMngCode);
            // ���ʃR�s�[
            selectedInfo := resultSelectedInfo;
            resultStatus := paraStatus;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

        // ���b�Z�[�W�̃��������
    end;
end;

// �Ԏ�K�C�h����
function MAHNB01012B_modelFullGuide(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var modelNameU: TModelNameU)
    : Integer; stdcall;

var
    status: Integer;
    resultModelNameU: TModelNameU;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTModelNameU(resultModelNameU);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_modelFullGuide(makerCode, modelCode, modelSubCode, enterpriseCode, salesRowNo, resultModelNameU);
            // ���ʃR�s�[
            modelNameU := resultModelNameU;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

        // ���b�Z�[�W�̃��������
    end;
end;

// ���l�K�C�h�{�{�^������
function MAHNB01012B_slipNote(sender: WideString;
    enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_slipNote(sender, enterpriseCode, resultSalesSlip);
            // ���ʃR�s�[
            salesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

        // ���b�Z�[�W�̃��������
    end;
end;

// ���Z�菈��
function MAHNB01012B_GetRate(numerator: Double;
    denominator: Double;
    var rate: Double)
    : Integer; stdcall;

var
    status: Integer;
    resultRate: Double;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    rate := 0;

    try
        try
            // ���ʃf�[�^��������
            resultRate := 0;

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetRate(numerator, denominator, resultRate);
            // ���ʃR�s�[
            rate := resultRate;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

        // ���b�Z�[�W�̃��������
    end;
end;

// --- ADD 2010/05/31 ---------->>>>>
// CalculationSalesPrice
function MAHNB01012B_CalculationSalesPrice()
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_CalculationSalesPrice();
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

        // ���b�Z�[�W�̃��������
    end;
end;
// --- ADD 2010/05/31 ----------<<<<<

// add by gaofeng end

    // add by Zhangkai start

    // add by Zhangkai end

    // add by Lizc start
// �J�[���[�J�[�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterMakerCodeFocus(makerCode: Integer;
    salesRowNo: Integer;
    var makerName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultMakerName: WideString;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    makerName := '';

    try
        try
            // ���ʃf�[�^��������
            resultMakerName := '';

            // �������\�b�h�ďo��
            gpxSalesSlipInputAcs_AfterMakerCodeFocus(makerCode, salesRowNo, resultMakerName);
            // ���ʃR�s�[
            makerName := resultMakerName;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �Ԏ�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterModelCodeFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultModelFullName: WideString;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    modelFullName := '';

    try
        try
            // ���ʃf�[�^��������
            resultModelFullName := '';

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterModelCodeFocus(makerCode, modelCode, modelSubCode, salesRowNo, resultModelFullName);
            // ���ʃR�s�[
            modelFullName := resultModelFullName;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �Ԏ�ď̃R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterModelSubCodeFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultModelFullName: WideString;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    modelFullName := '';

    try
        try
            // ���ʃf�[�^��������
            resultModelFullName := '';

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterModelSubCodeFocus(makerCode, modelCode, modelSubCode, salesRowNo, resultModelFullName);
            // ���ʃR�s�[
            modelFullName := resultModelFullName;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �Ԏ햼�̂̃t�H�[�J�X����
function MAHNB01012B_AfterModelFullNameFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    salesRowNo: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterModelFullNameFocus(makerCode, modelCode, modelSubCode, modelFullName, salesRowNo);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �N���̃t�H�[�J�X����
function MAHNB01012B_AfterFirstEntryDateFocus(firstEntryDate: Integer;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultBoolRet: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            //resultBoolRet := False;

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterFirstEntryDateFocus(firstEntryDate, salesRowNo, resultBoolRet);
            // ���ʃR�s�[
            boolRet := resultBoolRet;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ԑ�ԍ��̃t�H�[�J�X����
function MAHNB01012B_AfterProduceFrameNoFocus(produceFrameNo: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean;
    mode : Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultBoolRet: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterProduceFrameNoFocus(produceFrameNo, salesRowNo, resultBoolRet, mode);
            // ���ʃR�s�[
            boolRet := resultBoolRet;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �ǉ����^�u����Visible�ݒ�
function MAHNB01012B_SettingAddInfoVisible(customerCode: Integer;
    carMngCode: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultBoolRet: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SettingAddInfoVisible(customerCode, carMngCode, salesRowNo, resultBoolRet);
            // ���ʃR�s�[
            boolRet := resultBoolRet;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �Ԏ�ύX�{�^��Visible
function MAHNB01012B_GetChangeCarInfoVisible(customerCode: Integer;
    carMngCode: WideString;
    var visibleFlag: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultVisibleFlag: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    visibleFlag := 0;

    try
        try
            // ���ʃf�[�^��������
            resultVisibleFlag := 0;

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetChangeCarInfoVisible(customerCode, carMngCode, resultVisibleFlag);
            // ���ʃR�s�[
            visibleFlag := resultVisibleFlag;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �Ǘ��ԍ��̃t�H�[�J�X����
function MAHNB01012B_AfterCarMngCodeFocus(carMngCode: WideString;
    customerCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var selectedInfo: TCarMangInputExtraInfo;
    var returnFlag: Boolean;
    var clearCarInfoFlag: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSelectedInfo: TCarMangInputExtraInfo;
    //resultReturnFlag: Tbool;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTCarMangInputExtraInfo(resultSelectedInfo);
            //ClearTbool(resultReturnFlag);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterCarMngCodeFocus(carMngCode, customerCode, enterpriseCode, salesRowNo, resultSelectedInfo, returnFlag, clearCarInfoFlag);
            // ���ʃR�s�[
            selectedInfo := resultSelectedInfo;
            //refReturnFlag := resultReturnFlag;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���_�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterSectionCodeFocus(sectionCode: WideString;
    var refSalesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterSectionCodeFocus(sectionCode, refSalesSlip, resultSalesSlip);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���喼�̎擾����
function MAHNB01012B_GetNameFromSubSection(subSectionCode: Integer;
    var subSectionNm: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultSubSectionNm: WideString;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    subSectionNm := '';

    try
        try
            // ���ʃf�[�^��������
            resultSubSectionNm := '';

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetNameFromSubSection(subSectionCode, resultSubSectionNm);
            // ���ʃR�s�[
            subSectionNm := resultSubSectionNm;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �S���ҕύX����
function MAHNB01012B_ChangeSalesEmployee(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    //resultCanChangeFocus: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);
            //ClearTbool(resultCanChangeFocus);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ChangeSalesEmployee(refSalesSlip, resultSalesSlip, salesSlipCurrent, code, refCanChangeFocus, refCanChangeFocus);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;
            //refCanChangeFocus := resultCanChangeFocus;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �󒍎ҕύX����
function MAHNB01012B_ChangeFrontEmployee(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultCanChangeFocus: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ChangeFrontEmployee(refSalesSlip, resultSalesSlip, salesSlipCurrent, code, refCanChangeFocus, resultCanChangeFocus);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;
            refCanChangeFocus := resultCanChangeFocus;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���s�ҕύX����
function MAHNB01012B_ChangeSalesInput(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultCanChangeFocus: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ChangeSalesInput(refSalesSlip, resultSalesSlip, salesSlipCurrent, code, refCanChangeFocus, resultCanChangeFocus);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;
            refCanChangeFocus := resultCanChangeFocus;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �`�[�敪�ύX����
function MAHNB01012B_ChangeSalesSlip(var refSalesSlip: TSalesSlip;
    isCache: Boolean;
    code: Integer;
    var refChangeSalesSlipDisplay: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultChangeSalesSlipDisplay: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ChangeSalesSlip(refSalesSlip, resultSalesSlip, isCache, code, refChangeSalesSlipDisplay, resultChangeSalesSlipDisplay, clearDetailInput, clearCarInfo);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;
            refChangeSalesSlipDisplay := resultChangeSalesSlipDisplay;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���i�敪�ύX����
function MAHNB01012B_ChangeSalesGoodsCd(salesSlipCurrent: TSalesSlip;
    code: Integer;
    var refChangeSalesGoodsCd: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultChangeSalesGoodsCd: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ChangeSalesGoodsCd(salesSlipCurrent, code, refChangeSalesGoodsCd, resultChangeSalesGoodsCd, clearDetailInput, clearCarInfo);
            // ���ʃR�s�[
            refChangeSalesGoodsCd := resultChangeSalesGoodsCd;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���Ӑ�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterCustomerCodeFocus(var refSalesSlip: TSalesSlip;
    code: Integer;
    var refCustomerInfo: TCustomerInfo;
    var clearAddCarInfo: Boolean;
    var refCanChangeFocus: Boolean;
    var refReCalcSalesPrice: Boolean;
    var refGuideStart: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean;
    var refReCalcSalesUnitPrice: Boolean;
    var refClearRateInfo: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultCustomerInfo: TCustomerInfo;
    resultClearAddCarInfo: Boolean;
    resultCanChangeFocus: Boolean;
    resultReCalcSalesPrice: Boolean;
    resultGuideStart: Boolean;
    resultClearDetailInput: Boolean;
    resultClearCarInfo: Boolean;
    resultReCalcSalesUnitPrice: Boolean;
    resultClearRateInfo: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // --- ADD 2010/07/06 ----------<<<<<
            ClearTCustomerInfo(resultCustomerInfo);
            // --- ADD 2010/07/06 ---------->>>>>

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterCustomerCodeFocus(refSalesSlip, resultSalesSlip, code, refCustomerInfo, resultCustomerInfo, resultClearAddCarInfo, refCanChangeFocus, resultCanChangeFocus, refReCalcSalesPrice, resultReCalcSalesPrice, refGuideStart, resultGuideStart, resultClearDetailInput, resultClearCarInfo, refReCalcSalesUnitPrice, resultReCalcSalesUnitPrice, refClearRateInfo, resultClearRateInfo);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;
            refCustomerInfo := resultCustomerInfo;
            clearAddCarInfo := resultClearAddCarInfo;
            refCanChangeFocus := resultCanChangeFocus;
            refReCalcSalesPrice := resultReCalcSalesPrice;
            refGuideStart := resultGuideStart;
            clearDetailInput := resultClearDetailInput;
            clearCarInfo := resultClearCarInfo;
            refReCalcSalesUnitPrice := resultReCalcSalesUnitPrice;
            refClearRateInfo := resultClearRateInfo;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �`�[�ԍ��̃t�H�[�J�X����
function MAHNB01012B_AfterSalesSlipNumFocus(var refSalesSlip: TSalesSlip;
    var refSalesSlipCurrent: TSalesSlip;
    code: WideString;
    enterpriseCode: WideString;
    var equelFlag: Boolean;
    var readDBDatStatus: Integer;
    var refReCalcSalesPrice: Boolean;
    var deleteEmptyRow: Boolean;
    var findDataFlg: Boolean)   // ADD 2010/07/01
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultSalesSlipCurrent: TSalesSlip;
    resultEquelFlag: Boolean;
    resultReadDBDatStatus: Integer;
    resultReCalcSalesPrice: Boolean;
    resultDeleteEmptyRow: Boolean;
    resultFindDataFlg: Boolean;     // ADD 2010/07/01

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    readDBDatStatus := 0;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);
            ClearTSalesSlip(resultSalesSlipCurrent);
            resultReadDBDatStatus := 0;

            // �������\�b�h�ďo��
            // --- UPD 2010/07/01 --------->>>>>
//            status := gpxSalesSlipInputAcs_AfterSalesSlipNumFocus(refSalesSlip, resultSalesSlip, refSalesSlipCurrent, resultSalesSlipCurrent, code, enterpriseCode, resultEquelFlag, resultReadDBDatStatus, refReCalcSalesPrice, resultReCalcSalesPrice, resultDeleteEmptyRow);
            status := gpxSalesSlipInputAcs_AfterSalesSlipNumFocus(refSalesSlip, resultSalesSlip, refSalesSlipCurrent, resultSalesSlipCurrent, code, enterpriseCode, resultEquelFlag, resultReadDBDatStatus, refReCalcSalesPrice, resultReCalcSalesPrice, resultDeleteEmptyRow, resultFindDataFlg);
            // --- UPD 2010/07/01 ---------<<<<<

            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;
            refSalesSlipCurrent := resultSalesSlipCurrent;
            equelFlag := resultEquelFlag;
            readDBDatStatus := resultReadDBDatStatus;
            refReCalcSalesPrice := resultReCalcSalesPrice;
            deleteEmptyRow := resultDeleteEmptyRow;
            findDataFlg := resultFindDataFlg;  // ADD 2010/07/01

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �󒍃X�e�[�^�X���X�g�쐬
function MAHNB01012B_SetStateList()
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SetStateList();
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ������̃t�H�[�J�X����
function MAHNB01012B_AfterSalesDateFocus(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    salesDate: Int64;
    salesDateText: WideString;
    var refReCalcSalesUnitPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    var refTaxRate: Double;
    var refReCanChangeFocus: Boolean) // ADD K2011/08/12
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultReCalcSalesUnitPrice: Boolean;
    resultReCalcSalesPrice: Boolean;
    resultTaxRate: Double;
    resultReCanChangeFocus: Boolean; // ADD K2011/08/12

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);
            resultTaxRate := 0;

            // �������\�b�h�ďo��
            //status := gpxSalesSlipInputAcs_AfterSalesDateFocus(refSalesSlip, resultSalesSlip, salesSlipCurrent, salesDate, salesDateText, refReCalcSalesUnitPrice, resultReCalcSalesUnitPrice, refReCalcSalesPrice, resultReCalcSalesPrice, resultTaxRate); // DEL K2011/08/12
            status := gpxSalesSlipInputAcs_AfterSalesDateFocus(refSalesSlip, resultSalesSlip, salesSlipCurrent, salesDate, salesDateText, refReCalcSalesUnitPrice, resultReCalcSalesUnitPrice, refReCalcSalesPrice, resultReCalcSalesPrice, resultTaxRate, resultReCanChangeFocus); // ADD K2011/08/12
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;
            refReCalcSalesUnitPrice := resultReCalcSalesUnitPrice;
            refReCalcSalesPrice := resultReCalcSalesPrice;
            refTaxRate := resultTaxRate;
            refReCanChangeFocus := resultReCanChangeFocus; // ADD K2011/08/12

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �[����R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterAddresseeCodeFocue(var refSalesSlip: TSalesSlip;
    code: Integer;
    enterpriseCode: WideString;
    var refReCalcSalesPrice: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultReCalcSalesPrice: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterAddresseeCodeFocue(refSalesSlip, resultSalesSlip, code, enterpriseCode, refReCalcSalesPrice, resultReCalcSalesPrice);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;
            refReCalcSalesPrice := resultReCalcSalesPrice;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B
function MAHNB01012B_CacheForChange(salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_CacheForChange(salesSlip);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ��������̓��e�Ɣ�r
function MAHNB01012B_CompareSalesSlip(salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var compareRes: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultCompareRes: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_CompareSalesSlip(salesSlip, salesSlipCurrent, resultCompareRes);
            // ���ʃR�s�[
            compareRes := resultCompareRes;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ����P���Čv�Z
function MAHNB01012B_ReCalcSalesUnitPrice(var refSalesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ReCalcSalesUnitPrice(refSalesSlip, resultSalesSlip);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �|�����N���A�����i�S�āj
function MAHNB01012B_ClearAllRateInfo()
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ClearAllRateInfo();
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���l�P�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterSlipNoteCodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterSlipNoteCodeFocus(refSalesSlip, resultSalesSlip, value);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���l�Q�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterSlipNote2CodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer;
    var refReCanChangeFocus: Boolean) // ADD K2011/08/12
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
    resultReCanChangeFocus: Boolean; // ADD K2011/08/12
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            //status := gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus(refSalesSlip, resultSalesSlip, value); // DEL K2011/08/12
            status := gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus(refSalesSlip, resultSalesSlip, value, resultReCanChangeFocus); // ADD K2011/08/12
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;
            refReCanChangeFocus := resultReCanChangeFocus; // ADD K2011/08/12

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ----- ADD K2011/08/12 --------------------------->>>>>
// ���l�Q�̃t�H�[�J�X����
function MAHNB01012B_AfterSlipNote2Focus(salesSlip: TSalesSlip;
    slipNote2: WideString;
    var refReCanChangeFocus: Boolean)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
    resultReCanChangeFocus: Boolean;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterSlipNote2Focus(salesSlip, slipNote2, resultReCanChangeFocus);
            // ���ʃR�s�[
            refReCanChangeFocus := resultReCanChangeFocus;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;
// ----- ADD K2011/08/12 ---------------------------<<<<<

// ���l�R�R�[�h�̃t�H�[�J�X����
function MAHNB01012B_AfterSlipNote3CodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AfterSlipNote3CodeFocus(refSalesSlip, resultSalesSlip, value);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ����f�[�^����
function MAHNB01012B_GetSalesSlip(var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetSalesSlip(resultSalesSlip);
            // ���ʃR�s�[
            salesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ������m�F�{�^���N���b�N
function MAHNB01012B_CustomerClaimConfirmationClick(salesDate: Int64;
    var focus: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultFocus: WideString;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    focus := '';

    try
        try
            // ���ʃf�[�^��������
            resultFocus := '';

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_CustomerClaimConfirmationClick(salesDate, resultFocus);
            // ���ʃR�s�[
            focus := resultFocus;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �[����m�F�{�^���N���b�N
function MAHNB01012B_AddresseeConfirmationClick(var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_AddresseeConfirmationClick(resultSalesSlip);
            // ���ʃR�s�[
            salesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���㖾�׃f�[�^�̑��݃`�F�b�N
function MAHNB01012B_ExistSalesDetail(var exist: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultExist: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ExistSalesDetail(resultExist);
            // ���ʃR�s�[
            exist := resultExist;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ����`���ύX�\�`�F�b�N����
function MAHNB01012B_ChangeCheckAcptAnOdrStatus(code: Integer;
    salesSlip: TSalesSlip;
    var clearDisplayCarInfo: Boolean;
    var clearAddUpInfo: Boolean;
    var result1: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultClearDisplayCarInfo: Boolean;
    resultClearAddUpInfo: Boolean;
    resultResult: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus(code, salesSlip, resultClearDisplayCarInfo, resultClearAddUpInfo, resultResult);
            // ���ʃR�s�[
            clearDisplayCarInfo := resultClearDisplayCarInfo;
            clearAddUpInfo := resultClearAddUpInfo;
            result1 := resultResult;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ����`���ύX�\����
function MAHNB01012B_ChangeAcptAnOdrStatus(code: Integer;
    var refSalesSlip: TSalesSlip;
    svCode: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_ChangeAcptAnOdrStatus(code, refSalesSlip, resultSalesSlip, svCode);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ����f�[�^�L���b�V������
function MAHNB01012B_Cache(salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_Cache(salesSlip);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �\���p�`�[�敪���A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂�
function MAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay(var refSalesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesSlip(resultSalesSlip);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay(refSalesSlip, resultSalesSlip);
            // ���ʃR�s�[
            refSalesSlip := resultSalesSlip;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �������I������
function MAHNB01012B_SelectEquipInfo(carRelationGuid: WideString;
    equipmentGenreCd: WideString;
    equipmentName: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SelectEquipInfo(carRelationGuid, equipmentGenreCd, equipmentName);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �f�[�^�ύX�t���O�̐ݒ菈��
function MAHNB01012B_SetGetIsDataChanged(flag: Integer;
    var refIsDataChanged: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultIsDataChanged: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            //ClearTbool(resultIsDataChanged);
            resultIsDataChanged := refIsDataChanged;

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SetGetIsDataChanged(flag, refIsDataChanged, resultIsDataChanged);
            // ���ʃR�s�[
            refIsDataChanged := resultIsDataChanged;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// �w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞����
function MAHNB01012B_GetHeaderFocusConstructionListValue(var headerFocusConstructionList: TSalesSlipInputCustomArrayB5;
    var footerFocusConstructionList: TSalesSlipInputCustomArrayB6)
    : Integer; stdcall;

var
    status: Integer;
    resultHeaderFocusConstructionList: TSalesSlipInputCustomArrayB5;
    resultFooterFocusConstructionList: TSalesSlipInputCustomArrayB6;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetHeaderFocusConstructionListValue(resultHeaderFocusConstructionList, resultFooterFocusConstructionList);
            // ���ʃR�s�[
            headerFocusConstructionList := resultHeaderFocusConstructionList;
            footerFocusConstructionList := resultFooterFocusConstructionList;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������
        gpxSalesSlipInputAcs_FreeCustomArrayB5(@resultHeaderFocusConstructionList, 0);
        gpxSalesSlipInputAcs_FreeCustomArrayB6(@resultFooterFocusConstructionList, 0);

    end;
end;

// �t�H�[�J�X�ݒ胊�X�g�̎捞����
function MAHNB01012B_GetFocusConstructionValue(var headerList: WideString;
    var footerList: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultHeaderList: WideString;
    resultFooterList: WideString;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    headerList := '';
    footerList := '';

    try
        try
            // ���ʃf�[�^��������
            resultHeaderList := '';
            resultFooterList := '';

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetFocusConstructionValue(resultHeaderList, resultFooterList);
            // ���ʃR�s�[
            headerList := resultHeaderList;
            footerList := resultFooterList;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// ���_���̂̎捞����
function MAHNB01012B_GetSectionNm(section: WideString;
    var sectionName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultSectionName: WideString;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    sectionName := '';

    try
        try
            // ���ʃf�[�^��������
            resultSectionName := '';

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetSectionNm(section, resultSectionName);
            // ���ʃR�s�[
            sectionName := resultSectionName;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;

// --- ADD 2010/07/16 ---------->>>>>
// �ԗ������敪�̎捞����
function MAHNB01012B_SetGetSearchCarDiv(flag: Integer;
    var refSearchCarDiv: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSearchCarDiv: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            resultSearchCarDiv := refSearchCarDiv;

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_SetGetSearchCarDiv(flag, refSearchCarDiv, resultSearchCarDiv);
            // ���ʃR�s�[
            refSearchCarDiv := resultSearchCarDiv;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;
// --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
// �c�[���`�b�v��������
function MAHNB01012B_CreateStockCountInfoString(salesRowNo: Integer;
    var StockCountInfo: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultStockCountInfo: WideString;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    StockCountInfo := '';

    try
        try
            // ���ʃf�[�^��������
            resultStockCountInfo := '';

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_CreateStockCountInfoString(salesRowNo, resultStockCountInfo);
            // ���ʃR�s�[
            StockCountInfo := resultStockCountInfo;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;
    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

// --- ADD m.suzuki 2010/06/12 ---------->>>>>
//**************************************************
// ���[�������\���f�[�^�쐬����
//**************************************************
procedure MAHNB01012B_MakeMailDefaultData( var fileName: WideString ); stdcall;
var
    resultFileName: WideString;
begin
    try
        try
            // ���ʃf�[�^��������
            resultFileName := '';

            // �������\�b�h�ďo��
            gpxSalesSlipInputAcs_MakeMailDefaultData( resultFileName );
            // ���ʃR�s�[
            fileName := resultFileName;

            // ���ʂ�ݒ�
        // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;
// --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//******************************************************************************
// RC�A��-CSV�o��
//******************************************************************************
function MAHNB01012B_CopyToRC(salesRowNo: Integer) : Integer; stdcall;
var
  status: Integer;
begin
  // �߂�X�e�[�^�X������
  try
    try
      // �������\�b�h�ďo��
      status := gpxSalesSlipInputAcs_CopyToRC(salesRowNo);

      // ���ʂ�ݒ�
      Result := status;
      // ��O����
    except
      on ex: Exception do
      begin
          // ��O�������̓G���[���b�Z�[�W��߂�
          Result := -1;
      end;
    end;
  finally
    // ���b�p�[�N���X������n���ꂽ�����������

  end;
end;

//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// ADD 2012/02/09 ����� Redmine#28289 --- >>>>>
//**************************************************
// ������t���O�̎捞����
//**************************************************
function MAHNB01012B_GetPrintThreadOverFlag(var printThreadOverFlag: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultPrintThreadOverFlag: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            resultPrintThreadOverFlag := printThreadOverFlag;

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_GetPrintThreadOverFlag(resultPrintThreadOverFlag);
            // ���ʃR�s�[
            printThreadOverFlag := resultPrintThreadOverFlag;

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := -1;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;
// ADD 2012/02/09 ����� Redmine#28289 --- <<<<

// --- ADD 2013/03/21 ---------->>>>>
// �n���h���ʒu�`�F�b�N����
function MAHNB01012B_CheckHandlePosition(carRelationGuid: WideString;
    vinCode: WideString)
    : Boolean; stdcall;

var
    status: Boolean;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    // �f�t�H���g��TRUE��Ԃ�
    Result := True;

    try
        try
            // ���ʃf�[�^��������

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputAcs_CheckHandlePosition(carRelationGuid, vinCode);
            // ���ʃR�s�[

            // ���ʂ�ݒ�
            Result := status;
            // ��O����
        except
            on ex: Exception do
            begin
                // ��O�������̓G���[���b�Z�[�W��߂�
                Result := True;
            end;
        end;
    finally
        // ���b�p�[�N���X������n���ꂽ�����������

    end;
end;
// --- ADD 2013/03/21 ----------<<<<<

end.
