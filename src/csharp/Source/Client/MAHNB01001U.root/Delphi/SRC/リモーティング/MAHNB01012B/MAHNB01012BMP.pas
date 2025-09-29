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
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : �����
// �� �� ��  2012/02/09  �C�����e : �A�v���P�[�V�����I�������O�ɁA������t���O�̔��f��ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900269-00 �쐬�S�� : FSI���� ���T
// �� �� ��  2013/03/21  �C�����e : SPK�ԑ�ԍ�������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070071-00 �쐬�S�� : �{�{�@����
// �� �� ��  2014/05/19  �C�����e : �d�|�ꗗ��2218 ���q���l���ɃR�[�h���͍��ڂ�ǉ�
//----------------------------------------------------------------------------//

unit MAHNB01012BMP;

interface

uses
    ShareMem, SysUtils, Classes, HDllCall,DBClient,  HFSLLIB, MAHNB01012C, Forms;

type
    TDataModule1 = class(TDataModule)
        HDllCall1: THDllCall;
        private
            { Private �錾 }
        public
            { Public �錾 }
    end;

    /////////////////// ����N���X����̃C���|�[�g�֐��^�錾 /////////////////

    // �ԗ������������\�b�h�^
    TxSalesSlipInputAcs_CarSearch = function(condition: TCarSearchCondition;
    salesRowNo: Integer;
    conditionType: Integer): Integer; stdcall;

    // �ԗ����s�I�u�W�F�N�g�擾���\�b�h�^
    TxSalesSlipInputAcs_GetCarInfoRow = function(salesRowNo: Integer;
    getCarInfoMode: Integer;
    var resultCarInfo: TCarInfo): Integer; stdcall;

    // �I�v�V������񏈗����\�b�h�^
    TxSalesSlipInputAcs_GetSettingOptionInfo = function(var optCarMng: Integer;
    var optStockingPayment: Integer): Integer; stdcall;

    // �J���[���擾�������\�b�h�^
    TxSalesSlipInputAcs_GetColorInfo = function(carRelationGuid: WideString;
    var resultColorInfoList: TSalesSlipInputCustomArrayB2): Integer; stdcall;

    // �I���J���[���擾�������\�b�h�^
    TxSalesSlipInputAcs_GetSelectColorInfo = function(carRelationGuid: WideString;
    var resultColorInfo: TColorInfo): Integer; stdcall;

    // �g�������擾�������\�b�h�^
    TxSalesSlipInputAcs_GetTrimInfo = function(carRelationGuid: WideString;
    var resultTrimInfoList: TSalesSlipInputCustomArrayB3): Integer; stdcall;
    
    // �I���g�������擾�������\�b�h�^
    TxSalesSlipInputAcs_GetSelectTrimInfo = function(carRelationGuid: WideString;
    var resultTrimInfo: TTrimInfo): Integer; stdcall;

    // �������擾�������\�b�h�^
    TxSalesSlipInputAcs_GetEquipInfo = function(carRelationGuid: WideString;
    var resultCEqpDefDspInfoList: TSalesSlipInputCustomArrayB4): Integer; stdcall;

    // �J���[���I���������\�b�h�^
    TxSalesSlipInputAcs_SelectColorInfo = function(carRelationGuid: WideString;
    colorCode: WideString): Integer; stdcall;

    // �g�������I���������\�b�h�^
    TxSalesSlipInputAcs_SelectTrimInfo = function(carRelationGuid: WideString;
    trimCode: WideString): Integer; stdcall;

    // ���Y�N���͈̓`�F�b�N���\�b�h�^
    TxSalesSlipInputAcs_CheckProduceTypeOfYearRange = function(carRelationGuid: WideString;
    firstEntryDate: Integer): Integer; stdcall;

    // �ԗ������f�[�^�e�[�u���N���ݒ菈�����\�b�h�^
    TxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate = function(carRelationGuid: WideString;
    firstEntryDate: WideString): Integer; stdcall;

    // �ԑ�ԍ��͈̓`�F�b�N���\�b�h�^
    TxSalesSlipInputAcs_CheckProduceFrameNo = function(carRelationGuid: WideString;
    inputFrameNo: WideString;
    searchFrameNo: Integer): Integer; stdcall;

    // �ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈�����\�b�h�^
    TxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo = function(carRelationGuid: WideString;
    frameNo: WideString): Integer; stdcall;

    // �Ώ۔N���擾����(�ԑ�ԍ����擾)���\�b�h�^
    TxSalesSlipInputAcs_GetProduceTypeOfYear = function(carRelationGuid: WideString;
    frameNo: WideString): Integer; stdcall;

    // �ԗ����e�[�u���̃N���A���\�b�h�^
    TxSalesSlipInputAcs_ClearCarInfoRow = function(salesRowNo: Integer): Integer; stdcall;

    // �ԗ����e�[�u���s�̔N���Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate = function(salesRowNo: Integer;
    firstEntryDate: Integer): Integer; stdcall;

    // �ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo = function(salesRowNo: Integer;
    frameNo: WideString): Integer; stdcall;

    // �ԗ����e�[�u���s�̎Ԏ���Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo = function(salesRowNo: Integer;
    makerCode: Integer;
    makerFullName: WideString;
    makerHalfName: WideString;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    modelHalfName: WideString): Integer; stdcall;

    // �Ԏ햼�̎擾�������\�b�h�^
    TxSalesSlipInputAcs_GetModelFullName = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer): Integer; stdcall;

    // �Ԏ피�p���̎擾�������\�b�h�^
    TxSalesSlipInputAcs_GetModelHalfName = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer): Integer; stdcall;

    // �ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode = function(salesRowNo: Integer;
    carMngCode: WideString): Integer; stdcall;

    // �ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo = function(salesRowNo: Integer;
    modelDesignationNo: Integer;
    categoryNo: Integer): Integer; stdcall;

    // �ԗ����e�[�u���s�̌^���Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromFullModel = function(salesRowNo: Integer;
    fullModel: WideString): Integer; stdcall;

    // �ԗ����e�[�u���s�̃G���W���^���Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm = function(salesRowNo: Integer;
    engineModelNm: WideString): Integer; stdcall;

    // �ԗ���񑶍݃`�F�b�N���\�b�h�^
    TxSalesSlipInputAcs_ExistCarInfo = function(): Integer; stdcall;

    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------>>>>>
    // �ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode = function(salesRowNo: Integer;
    carNoteCode: Integer): Integer; stdcall;
    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------<<<<<

    // �ԗ����e�[�u���s�̎��q���l�Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromCarNote = function(salesRowNo: Integer;
    carNote: WideString): Integer; stdcall;

    // �ԗ����e�[�u���s�̎��q���s�����Z�b�g���\�b�h�^
    TxSalesSlipInputAcs_SettingCarInfoRowFromMileage = function(salesRowNo: Integer;
    mileage: Integer): Integer; stdcall;

    // add by gaofeng start
    // ���_�K�C�h�������\�b�h�^
    TxSalesSlipInputAcs_sectionGuide = function(enterpriseCode: WideString;
    formName: WideString;
    var resultSalesSlip: TSalesSlip): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeSalesSlip = function(resultList: PSalesSlip;
        resultCount: Integer): Integer; stdcall;

    // ����K�C�h�������\�b�h�^
    TxSalesSlipInputAcs_subSectionGuide = function(enterpriseCode: WideString;
    var resultSalesSlip: TSalesSlip): Integer; stdcall;

    // �]�ƈ��K�C�h�������\�b�h�^
    TxSalesSlipInputAcs_employeeGuide = function(sender: WideString;
    enterpriseCode: WideString;
    salesInputNm: WideString;
    salesInputCode: WideString;
    var salesSlip: TSalesSlip;
    var isReInputErr: Boolean)
    : Integer; stdcall;


    // �Ǘ��ԍ��K�C�h�������\�b�h�^
    TxSalesSlipInputAcs_carMngNoGuide = function(customerCode: Integer;
    enterpriseCode: WideString;
    var resultSelectedInfo: TCarMangInputExtraInfo;
    var resultStatus: Integer;
    salesRowNo: Integer;
    carMngCode: string): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCarMangInputExtraInfo = function(resultList: PCarMangInputExtraInfo;
        resultCount: Integer): Integer; stdcall;

    // �Ԏ�K�C�h�������\�b�h�^
    TxSalesSlipInputAcs_modelFullGuide = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var resultModelNameU: TModelNameU): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeModelNameU = function(resultList: PModelNameU;
        resultCount: Integer): Integer; stdcall;

    // ���l�K�C�h�{�{�^���������\�b�h�^
    TxSalesSlipInputAcs_slipNote = function(sender: WideString;
    enterpriseCode: WideString;
    var resultSalesSlip: TSalesSlip): Integer; stdcall;

    // ���Z�菈�����\�b�h�^
    TxSalesSlipInputAcs_GetRate = function(numerator: Double;
    denominator: Double;
    var rate: Double): Integer; stdcall;

    // --- ADD 2010/05/31 ---------->>>>>
    // CalculationSalesPrice���\�b�h�^
    TxSalesSlipInputAcs_CalculationSalesPrice = function(): Integer; stdcall;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by gaofeng end

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeColorInfo = function(resultList: PColorInfo;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeTrimInfo = function(resultList: PTrimInfo;
        resultCount: Integer): Integer; stdcall;

//    // ������\�b�h�^
//    TxShowUAcs_FreeSalesSlipSearchResult = function(resultList: PSalesSlipSearchResult;
//        resultCount: Integer): Integer; stdcall;

    TxSalesSlipInputAcs_FreeCEqpDefDspInfo = function(resultList: PCEqpDefDspInfo;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCarSpecInfo = function(resultList: PCarSpecInfo;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCarInfo = function(resultList: PCarInfo;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCarModel = function(resultList: PCarModel;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeEngineModel = function(resultList: PEngineModel;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCarSearchCondition = function(resultList: PCarSearchCondition;
        resultCount: Integer): Integer; stdcall;
        
    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCustomArrayB4 = function(resultList: PSalesSlipInputCustomArrayB4;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCustomArrayB3 = function(resultList: PSalesSlipInputCustomArrayB3;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCustomArrayB2 = function(resultList: PSalesSlipInputCustomArrayB2;
        resultCount: Integer): Integer; stdcall;

    //�����������\�b�h�^
     TxShowUAcs_FreeMessage = function(msg : WideString):Integer; stdcall;

    TxSalesSlipInputAcs_FreeMessage = function(msg : WideString):Integer; stdcall;
    
    // add by gaofeng start
	// add by gaofeng end

    // add by Zhangkai start

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeSalesDetail = function(resultList: PSalesDetail;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCustomArrayA2 = function(resultList: PSalesSlipInputCustomArrayA2;
        resultCount: Integer): Integer; stdcall;

    // add by Zhangkai end

    // add by Lizc start
    // �J�[���[�J�[�R�[�h�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterMakerCodeFocus = function(makerCode: Integer;
    salesRowNo: Integer;
    var makerName: WideString): Integer; stdcall;

    // �Ԏ�R�[�h�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterModelCodeFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString): Integer; stdcall;

    // �Ԏ�ď̃R�[�h�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterModelSubCodeFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString): Integer; stdcall;

    // �Ԏ햼�̂̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterModelFullNameFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    salesRowNo: Integer): Integer; stdcall;

    // �N���̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterFirstEntryDateFocus = function(firstEntryDate: Integer;
    salesRowNo: Integer;
    var resultBoolRet: Boolean): Integer; stdcall;
    
    // �ԑ�ԍ��̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterProduceFrameNoFocus = function(produceFrameNo: WideString;
    salesRowNo: Integer;
    var resultBoolRet: Boolean;
    mode : Integer): Integer; stdcall;
    
    // �ǉ����^�u����Visible�ݒ胁�\�b�h�^
    TxSalesSlipInputAcs_SettingAddInfoVisible = function(customerCode: Integer;
    carMngCode: WideString;
    salesRowNo: Integer;
    var resultBoolRet: Boolean): Integer; stdcall;
    
    // �Ԏ�ύX�{�^��Visible���\�b�h�^
    TxSalesSlipInputAcs_GetChangeCarInfoVisible = function(customerCode: Integer;
    carMngCode: WideString;
    var visibleFlag: Integer): Integer; stdcall;
    
    // �Ǘ��ԍ��̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterCarMngCodeFocus = function(carMngCode: WideString;
    customerCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var resultSelectedInfo: TCarMangInputExtraInfo;
    var resultReturnFlag: Boolean;
    var clearCarInfoFlag: Boolean): Integer; stdcall;
    
    // ���_�R�[�h�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterSectionCodeFocus = function(sectionCode: WideString;
    salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip): Integer; stdcall;
    
    // ���喼�̎擾�������\�b�h�^
    TxSalesSlipInputAcs_GetNameFromSubSection = function(subSectionCode: Integer;
    var subSectionNm: WideString): Integer; stdcall;
    
    // �S���ҕύX�������\�b�h�^
    TxSalesSlipInputAcs_ChangeSalesEmployee = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    canChangeFocus: Boolean;
    var refCanChangeFocus: Boolean): Integer; stdcall;

    // �󒍎ҕύX�������\�b�h�^
    TxSalesSlipInputAcs_ChangeFrontEmployee = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    canChangeFocus: Boolean;
    var refCanChangeFocus: Boolean): Integer; stdcall;

    // ���s�ҕύX�������\�b�h�^
    TxSalesSlipInputAcs_ChangeSalesInput = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    canChangeFocus: Boolean;
    var refCanChangeFocus: Boolean): Integer; stdcall;
    
    // �`�[�敪�ύX�������\�b�h�^
    TxSalesSlipInputAcs_ChangeSalesSlip = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    isCache: Boolean;
    code: Integer;
    changeSalesSlipDisplay: Boolean;
    var refChangeSalesSlipDisplay: Boolean;
    var resultClearDetailInput: Boolean;
    var resultClearCarInfo: Boolean): Integer; stdcall;

    // ���i�敪�ύX�������\�b�h�^
    TxSalesSlipInputAcs_ChangeSalesGoodsCd = function(salesSlipCurrent: TSalesSlip;
    code: Integer;
    changeSalesGoodsCd: Boolean;
    var refChangeSalesGoodsCd: Boolean;
    var resultClearDetailInput: Boolean;
    var resultClearCarInfo: Boolean): Integer; stdcall;
    
    // ���Ӑ�R�[�h�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterCustomerCodeFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    code: Integer;
    customerInfo: TCustomerInfo;
    var refCustomerInfo: TCustomerInfo;
    var resultClearAddCarInfo: Boolean;
    canChangeFocus: Boolean;
    var refCanChangeFocus: Boolean;
    reCalcSalesPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    guideStart: Boolean;
    var refGuideStart: Boolean;
    var resultClearDetailInput: Boolean;
    var resultClearCarInfo: Boolean;
    reCalcSalesUnitPrice: Boolean;
    var refReCalcSalesUnitPrice: Boolean;
    clearRateInfo: Boolean;
    var refClearRateInfo: Boolean): Integer; stdcall;
    
    // �`�[�ԍ��̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterSalesSlipNumFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var refSalesSlipCurrent: TSalesSlip;
    code: WideString;
    enterpriseCode: WideString;
    var resultEquelFlag: Boolean;
    var readDBDatStatus: Integer;
    reCalcSalesPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    var resultDeleteEmptyRow: Boolean;
    var resultFindDataFlg: Boolean    // ADD 2010/07/01
    ): Integer; stdcall;

    // �󒍃X�e�[�^�X���X�g�쐬���\�b�h�^
    TxSalesSlipInputAcs_SetStateList = function(): Integer; stdcall;
    
    // ������̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterSalesDateFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    salesDate: Int64;
    salesDateText: WideString;
    reCalcSalesUnitPrice: Boolean;
    var refReCalcSalesUnitPrice: Boolean;
    reCalcSalesPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    //var refTaxRate: Double): Integer; stdcall;// DEL K2011/08/12
    // ----- ADD K2011/08/12 --------->>>>>
    var refTaxRate: Double;
    var refReCanChangeFocus: Boolean): Integer; stdcall;
    // ----- ADD K2011/08/12 ---------<<<<<

    // �[����R�[�h�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterAddresseeCodeFocue = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    code: Integer;
    enterpriseCode: WideString;
    reCalcSalesPrice: Boolean;
    var refReCalcSalesPrice: Boolean): Integer; stdcall;
    
    // ����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B���\�b�h�^
    TxSalesSlipInputAcs_CacheForChange = function(salesSlip: TSalesSlip): Integer; stdcall;
    
    // ��������̓��e�Ɣ�r���\�b�h�^
    TxSalesSlipInputAcs_CompareSalesSlip = function(salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var resultCompareRes: Boolean): Integer; stdcall;
    
    // ����P���Čv�Z���\�b�h�^
    TxSalesSlipInputAcs_ReCalcSalesUnitPrice = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip): Integer; stdcall;

    // �|�����N���A�����i�S�āj���\�b�h�^
    TxSalesSlipInputAcs_ClearAllRateInfo = function(): Integer; stdcall;


    // ���l�P�R�[�h�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterSlipNoteCodeFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    value: Integer): Integer; stdcall;

    // ���l�Q�R�[�h�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterSlipNote2CodeFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    //value: Integer): Integer; stdcall; // DEL K2011/08/12
    // ----- ADD K2011/08/12 --------->>>>>
    value: Integer;
    var refReCanChangeFocus: Boolean): Integer; stdcall;
    // ----- ADD K2011/08/12 ---------<<<<<

    // ----- ADD K2011/08/12 --------------------------->>>>>
    // ���l�Q�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterSlipNote2Focus = function(salesSlip: TSalesSlip;
    slipNote2: WideString;
    var refReCanChangeFocus: Boolean): Integer; stdcall;
    // ----- ADD K2011/08/12 ---------------------------<<<<<

    // ���l�R�R�[�h�̃t�H�[�J�X�������\�b�h�^
    TxSalesSlipInputAcs_AfterSlipNote3CodeFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    value: Integer): Integer; stdcall;
    
    // ����f�[�^�������\�b�h�^
    TxSalesSlipInputAcs_GetSalesSlip = function(var resultSalesSlip: TSalesSlip): Integer; stdcall;

   // ������m�F�{�^���N���b�N���\�b�h�^
    TxSalesSlipInputAcs_CustomerClaimConfirmationClick = function(salesDate: Int64;
    var focus: WideString): Integer; stdcall;

    // �[����m�F�{�^���N���b�N���\�b�h�^
    TxSalesSlipInputAcs_AddresseeConfirmationClick = function(var resultSalesSlip: TSalesSlip): Integer; stdcall;
    
    // ���㖾�׃f�[�^�̑��݃`�F�b�N���\�b�h�^
    TxSalesSlipInputAcs_ExistSalesDetail = function(var resultExist: Boolean): Integer; stdcall;

    // ����`���ύX�\�`�F�b�N�������\�b�h�^
    TxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus = function(code: Integer;
    salesSlip: TSalesSlip;
    var resultClearDisplayCarInfo: Boolean;
    var resultClearAddUpInfo: Boolean;
    var resultResult: Boolean): Integer; stdcall;

    // ����`���ύX�\�������\�b�h�^
    TxSalesSlipInputAcs_ChangeAcptAnOdrStatus = function(code: Integer;
    salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    svCode: Integer): Integer; stdcall;

    // ����f�[�^�L���b�V���������\�b�h�^
    TxSalesSlipInputAcs_Cache = function(salesSlip: TSalesSlip): Integer; stdcall;
    
    // �\���p�`�[�敪���A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂����\�b�h�^
    TxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip): Integer; stdcall;
    
    // �������I���������\�b�h�^
    TxSalesSlipInputAcs_SelectEquipInfo = function(carRelationGuid: WideString;
    equipmentGenreCd: WideString;
    equipmentName: WideString): Integer; stdcall;
    
    // �f�[�^�ύX�t���O�̐ݒ菈�����\�b�h�^
    TxSalesSlipInputAcs_SetGetIsDataChanged = function(flag: Integer;
    isDataChanged: Boolean;
    var refIsDataChanged: Boolean): Integer; stdcall;
    
    // �w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞�������\�b�h�^
    TxSalesSlipInputAcs_GetHeaderFocusConstructionListValue = function(var resultHeaderFocusConstructionList: TSalesSlipInputCustomArrayB5;
    var resultFooterFocusConstructionList: TSalesSlipInputCustomArrayB6): Integer; stdcall;

    // �t�H�[�J�X�ݒ胊�X�g�̎捞�������\�b�h�^
    TxSalesSlipInputAcs_GetFocusConstructionValue = function(var headerList: WideString;
    var footerList: WideString): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeHeaderFocusConstruction = function(resultList: PHeaderFocusConstruction;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeFooterFocusConstruction = function(resultList: PFooterFocusConstruction;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCustomArrayB6 = function(resultList: PSalesSlipInputCustomArrayB6;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputAcs_FreeCustomArrayB5 = function(resultList: PSalesSlipInputCustomArrayB5;
        resultCount: Integer): Integer; stdcall;

	// ���_���̂̎捞�������\�b�h�^
    TxSalesSlipInputAcs_GetSectionNm = function(section: WideString;
    var sectionName: WideString): Integer; stdcall;
    
    // --- ADD 2010/07/16 ---------->>>>>
    // �ԗ������敪�̎捞�������\�b�h�^
    TxSalesSlipInputAcs_SetGetSearchCarDiv = function(flag: Integer;
    searchCarDiv: Boolean;
    var refSearchCarDiv: Boolean): Integer; stdcall;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
    // �c�[���`�b�v�����������\�b�h�^
    TxSalesSlipInputAcs_CreateStockCountInfoString = function(salesRowNo: Integer;
    var StockCountInfo: WideString): Integer; stdcall;
    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    TxSalesSlipInputAcs_MakeMailDefaultData = procedure( var sFileName: WideString ); stdcall;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    TxSalesSlipInputAcs_CopyToRC = function(salesRowNo: Integer) : Integer; stdcall;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    TxSalesSlipInputAcs_GetPrintThreadOverFlag = function(var printThreadOverFlag: Boolean) : Integer; stdcall;  //ADD 2012/02/09 ����� Redmine#28289

    // --- ADD 2013/03/21 ---------->>>>>
    // �n���h���ʒu�`�F�b�N�������\�b�h�^
    TxSalesSlipInputAcs_CheckHandlePosition = function(carRelationGuid: WideString;
    vinCode: WideString)
    : Boolean; stdcall;
    // --- ADD 2013/03/21 ----------<<<<<

    //�A�N�Z�X�N���X����DLL���[�h���\�b�h
    function LoadLibraryMAHNB01012M(HDllCall1: THDllCall): Integer;

    //�A�N�Z�X�N���X����DLL�A�����[�h���\�b�h
    procedure FreeLibraryMAHNB01012M(HDllCall1: THDllCall);

var
//    // �ԗ����������֐��ďo���p�|�C���^�ϐ�
//    gpxShowUAcs_SalesSlipGuide: TxShowUAcs_SalesSlipGuide;
//    // ��������������Ăяo���p�|�C���^�ϐ�
//    gpxShowUAcs_FreeSalesSlipSearchResult: TxShowUAcs_FreeSalesSlipSearchResult;

    // �I�v�V������񏈗��֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetSettingOptionInfo: TxSalesSlipInputAcs_GetSettingOptionInfo;
    gpxSalesSlipInputAcs_CarSearch: TxSalesSlipInputAcs_CarSearch;
    // �ԗ����s�I�u�W�F�N�g�擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetCarInfoRow: TxSalesSlipInputAcs_GetCarInfoRow;
    // �J���[���擾�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetColorInfo: TxSalesSlipInputAcs_GetColorInfo;
    // �I���J���[���擾�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetSelectColorInfo: TxSalesSlipInputAcs_GetSelectColorInfo;
    // �g�������擾�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetTrimInfo: TxSalesSlipInputAcs_GetTrimInfo;
    // �I���g�������擾�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetSelectTrimInfo: TxSalesSlipInputAcs_GetSelectTrimInfo;
    // �������擾�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetEquipInfo: TxSalesSlipInputAcs_GetEquipInfo;
    // �J���[���I�������֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SelectColorInfo: TxSalesSlipInputAcs_SelectColorInfo;
    // �g�������I�������֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SelectTrimInfo: TxSalesSlipInputAcs_SelectTrimInfo;
    // ���Y�N���͈̓`�F�b�N�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_CheckProduceTypeOfYearRange: TxSalesSlipInputAcs_CheckProduceTypeOfYearRange;
    // �ԗ������f�[�^�e�[�u���N���ݒ菈���֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate: TxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate;
    // �ԑ�ԍ��͈̓`�F�b�N�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_CheckProduceFrameNo: TxSalesSlipInputAcs_CheckProduceFrameNo;
    // �ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈���֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo: TxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo;
    // �Ώ۔N���擾����(�ԑ�ԍ����擾)�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetProduceTypeOfYear: TxSalesSlipInputAcs_GetProduceTypeOfYear;
    // �ԗ����e�[�u���̃N���A�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ClearCarInfoRow: TxSalesSlipInputAcs_ClearCarInfoRow;
    // �ԗ����e�[�u���s�̔N���Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate: TxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate;
    // �ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo: TxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo;
    // �ԗ����e�[�u���s�̎Ԏ���Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo: TxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo;
    // �Ԏ햼�̎擾�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetModelFullName: TxSalesSlipInputAcs_GetModelFullName;
    // �Ԏ피�p���̎擾�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetModelHalfName: TxSalesSlipInputAcs_GetModelHalfName;
    // �ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode: TxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode;
    // �ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo: TxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo;
    // �ԗ����e�[�u���s�̌^���Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFullModel: TxSalesSlipInputAcs_SettingCarInfoRowFromFullModel;
    // �ԗ����e�[�u���s�̃G���W���^���Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm: TxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm;
    // �ԗ���񑶍݃`�F�b�N�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ExistCarInfo: TxSalesSlipInputAcs_ExistCarInfo;
    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------>>>>>
    // �ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode: TxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode;
    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------<<<<<
    // �ԗ����e�[�u���s�̎��q���l�Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNote: TxSalesSlipInputAcs_SettingCarInfoRowFromCarNote;
    // �ԗ����e�[�u���s�̎��q���s�����Z�b�g�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingCarInfoRowFromMileage: TxSalesSlipInputAcs_SettingCarInfoRowFromMileage;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeColorInfo: TxSalesSlipInputAcs_FreeColorInfo;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeTrimInfo: TxSalesSlipInputAcs_FreeTrimInfo;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCEqpDefDspInfo: TxSalesSlipInputAcs_FreeCEqpDefDspInfo;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCarSpecInfo: TxSalesSlipInputAcs_FreeCarSpecInfo;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCarInfo: TxSalesSlipInputAcs_FreeCarInfo;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCarModel: TxSalesSlipInputAcs_FreeCarModel;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeEngineModel: TxSalesSlipInputAcs_FreeEngineModel;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCarSearchCondition: TxSalesSlipInputAcs_FreeCarSearchCondition;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCustomArrayB4: TxSalesSlipInputAcs_FreeCustomArrayB4;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCustomArrayB3: TxSalesSlipInputAcs_FreeCustomArrayB3;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCustomArrayB2: TxSalesSlipInputAcs_FreeCustomArrayB2;
    //�������������Ăяo���p�|�C���^�ϐ�
    gpxShowUAcs_FreeMessage: TxShowUAcs_FreeMessage;
    gpxSalesSlipInputAcs_FreeMessage: TxSalesSlipInputAcs_FreeMessage;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeHeaderFocusConstruction: TxSalesSlipInputAcs_FreeHeaderFocusConstruction;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeFooterFocusConstruction: TxSalesSlipInputAcs_FreeFooterFocusConstruction;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCustomArrayB6: TxSalesSlipInputAcs_FreeCustomArrayB6;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCustomArrayB5: TxSalesSlipInputAcs_FreeCustomArrayB5;

    DataModule1: TDataModule1;
    
    // add by gaofeng start

    // ���_�K�C�h�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_sectionGuide: TxSalesSlipInputAcs_sectionGuide;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeSalesSlip: TxSalesSlipInputAcs_FreeSalesSlip;
    // ����K�C�h�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_subSectionGuide: TxSalesSlipInputAcs_subSectionGuide;
    // �]�ƈ��K�C�h�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_employeeGuide: TxSalesSlipInputAcs_employeeGuide;
    // �Ǘ��ԍ��K�C�h�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_carMngNoGuide: TxSalesSlipInputAcs_carMngNoGuide;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCarMangInputExtraInfo: TxSalesSlipInputAcs_FreeCarMangInputExtraInfo;
    // �Ԏ�K�C�h�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_modelFullGuide: TxSalesSlipInputAcs_modelFullGuide;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeModelNameU: TxSalesSlipInputAcs_FreeModelNameU;
    // ���l�K�C�h�{�{�^�������֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_slipNote: TxSalesSlipInputAcs_slipNote;
    gpxSalesSlipInputAcs_GetRate: TxSalesSlipInputAcs_GetRate;

    // --- ADD 2010/05/31 ---------->>>>>
    // CalculationSalesPrice�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_CalculationSalesPrice: TxSalesSlipInputAcs_CalculationSalesPrice;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by gaofeng end

    // add by Zhangkai start

    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeSalesDetail: TxSalesSlipInputAcs_FreeSalesDetail;

    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_FreeCustomArrayA2: TxSalesSlipInputAcs_FreeCustomArrayA2;

    // add by Zhangkai end

    // add by Lizc start
	// �J�[���[�J�[�R�[�h�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterMakerCodeFocus: TxSalesSlipInputAcs_AfterMakerCodeFocus;
    // �Ԏ�R�[�h�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterModelCodeFocus: TxSalesSlipInputAcs_AfterModelCodeFocus;
    // �Ԏ�ď̃R�[�h�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterModelSubCodeFocus: TxSalesSlipInputAcs_AfterModelSubCodeFocus;
    // �Ԏ햼�̂̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterModelFullNameFocus: TxSalesSlipInputAcs_AfterModelFullNameFocus;
    // �N���̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterFirstEntryDateFocus: TxSalesSlipInputAcs_AfterFirstEntryDateFocus;
    // �ԑ�ԍ��̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterProduceFrameNoFocus: TxSalesSlipInputAcs_AfterProduceFrameNoFocus;
     // �ǉ����^�u����Visible�ݒ�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SettingAddInfoVisible: TxSalesSlipInputAcs_SettingAddInfoVisible;
    // �Ԏ�ύX�{�^��Visible�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetChangeCarInfoVisible: TxSalesSlipInputAcs_GetChangeCarInfoVisible;
    // �Ǘ��ԍ��̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterCarMngCodeFocus: TxSalesSlipInputAcs_AfterCarMngCodeFocus;
    // ���_�R�[�h�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterSectionCodeFocus: TxSalesSlipInputAcs_AfterSectionCodeFocus;
    // ���喼�̎擾�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetNameFromSubSection: TxSalesSlipInputAcs_GetNameFromSubSection;
    // �S���ҕύX�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ChangeSalesEmployee: TxSalesSlipInputAcs_ChangeSalesEmployee;
    // �󒍎ҕύX�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ChangeFrontEmployee: TxSalesSlipInputAcs_ChangeFrontEmployee;
    // ���s�ҕύX�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ChangeSalesInput: TxSalesSlipInputAcs_ChangeSalesInput;
    // �`�[�敪�ύX�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ChangeSalesSlip: TxSalesSlipInputAcs_ChangeSalesSlip;
    // ���i�敪�ύX�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ChangeSalesGoodsCd: TxSalesSlipInputAcs_ChangeSalesGoodsCd;
    // ���Ӑ�R�[�h�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterCustomerCodeFocus: TxSalesSlipInputAcs_AfterCustomerCodeFocus;
    // �`�[�ԍ��̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterSalesSlipNumFocus: TxSalesSlipInputAcs_AfterSalesSlipNumFocus;
    // �󒍃X�e�[�^�X���X�g�쐬�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SetStateList: TxSalesSlipInputAcs_SetStateList;
    // ������̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterSalesDateFocus: TxSalesSlipInputAcs_AfterSalesDateFocus;
    // �[����R�[�h�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterAddresseeCodeFocue: TxSalesSlipInputAcs_AfterAddresseeCodeFocue;
    // ����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_CacheForChange: TxSalesSlipInputAcs_CacheForChange;
    // ��������̓��e�Ɣ�r�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_CompareSalesSlip: TxSalesSlipInputAcs_CompareSalesSlip;
    // ����P���Čv�Z�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ReCalcSalesUnitPrice: TxSalesSlipInputAcs_ReCalcSalesUnitPrice;
    // �|�����N���A�����i�S�āj�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ClearAllRateInfo: TxSalesSlipInputAcs_ClearAllRateInfo;
    // ���l�P�R�[�h�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterSlipNoteCodeFocus: TxSalesSlipInputAcs_AfterSlipNoteCodeFocus;
    // ���l�Q�R�[�h�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus: TxSalesSlipInputAcs_AfterSlipNote2CodeFocus;
    // ���l�Q�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterSlipNote2Focus: TxSalesSlipInputAcs_AfterSlipNote2Focus; // ADD K2011/08/12
    // ���l�R�R�[�h�̃t�H�[�J�X�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AfterSlipNote3CodeFocus: TxSalesSlipInputAcs_AfterSlipNote3CodeFocus;
    // ����f�[�^�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetSalesSlip: TxSalesSlipInputAcs_GetSalesSlip;
    // ������m�F�{�^���N���b�N�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_CustomerClaimConfirmationClick: TxSalesSlipInputAcs_CustomerClaimConfirmationClick;
    // �[����m�F�{�^���N���b�N�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_AddresseeConfirmationClick: TxSalesSlipInputAcs_AddresseeConfirmationClick;
    // ���㖾�׃f�[�^�̑��݃`�F�b�N�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ExistSalesDetail: TxSalesSlipInputAcs_ExistSalesDetail;
    // ����`���ύX�\�`�F�b�N�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus: TxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus;
    // ����`���ύX�\�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_ChangeAcptAnOdrStatus: TxSalesSlipInputAcs_ChangeAcptAnOdrStatus;
    // ����f�[�^�L���b�V�������֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_Cache: TxSalesSlipInputAcs_Cache;
    // �\���p�`�[�敪���A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂��֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay: TxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay;
    // �������I�������֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SelectEquipInfo: TxSalesSlipInputAcs_SelectEquipInfo;
    // �f�[�^�ύX�t���O�̐ݒ菈���֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SetGetIsDataChanged: TxSalesSlipInputAcs_SetGetIsDataChanged;
    // �w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetHeaderFocusConstructionListValue: TxSalesSlipInputAcs_GetHeaderFocusConstructionListValue;
    // �t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetFocusConstructionValue: TxSalesSlipInputAcs_GetFocusConstructionValue;
    // ���_���̂̎捞�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_GetSectionNm: TxSalesSlipInputAcs_GetSectionNm;
    // --- ADD 2010/07/16 ---------->>>>>
    // �ԗ������敪�̎捞�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_SetGetSearchCarDiv: TxSalesSlipInputAcs_SetGetSearchCarDiv;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
    // �c�[���`�b�v���������֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_CreateStockCountInfoString: TxSalesSlipInputAcs_CreateStockCountInfoString;
    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    gpxSalesSlipInputAcs_MakeMailDefaultData: TxSalesSlipInputAcs_MakeMailDefaultData;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    gpxSalesSlipInputAcs_CopyToRC: TxSalesSlipInputAcs_CopyToRC; //2010/06/15 yamaji ADD

    gpxSalesSlipInputAcs_GetPrintThreadOverFlag: TxSalesSlipInputAcs_GetPrintThreadOverFlag; //ADD 2012/02/09 ����� Redmine#28289

    // --- ADD 2013/03/21 ---------->>>>>
    // �n���h���ʒu�`�F�b�N�����֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputAcs_CheckHandlePosition: TxSalesSlipInputAcs_CheckHandlePosition;
    // --- ADD 2013/03/21 ----------<<<<<

implementation

{$R *.dfm}

// �ԗ������A�N�Z�X�N���X����DLL���[�h����
function LoadLibraryMAHNB01012M(HDllCall1: THDllCall): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCall1.DllName := 'MAHNB01012M.DLL';
    nSt := HDllCall1.HLoadLibrary;

    // DLL���[�h
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'LOADLIBRARY', '�ԗ��������i�̃��[�h�Ɏ��s���܂���',
            nSt, nil, 0);
        Exit;
    end;

//    // ����`�[�K�C�h�����֐��A�h���X�擾
//    HDllCall1.ProcName := 'ShowUAcs_SalesSlipGuide';
//    nSt := HDllCall1.HGetPAdr(@gpxShowUAcs_SalesSlipGuide);
//    if nSt <> 0 then
//    begin
//        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�Ԏ핔�i',
//            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
//            '�Ԏ핔�i����`�[�K�C�h�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
//        Exit;
//    end;
    // �ԗ����������֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_CarSearch';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CarSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �I�v�V������񏈗��֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSettingOptionInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSettingOptionInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�Ԏ핔�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�Ԏ핔�i�I�v�V������񏈗��֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����s�I�u�W�F�N�g�擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetCarInfoRow';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetCarInfoRow);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����s�I�u�W�F�N�g�擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �J���[���擾�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetColorInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�J���[���擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �I���J���[���擾�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSelectColorInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSelectColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�I���J���[���擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �g�������擾�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetTrimInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�g�������擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �I���g�������擾�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSelectTrimInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSelectTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�I���g�������擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �������擾�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetEquipInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetEquipInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�������擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �J���[���I�������֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SelectColorInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SelectColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�J���[���I�������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �g�������I�������֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SelectTrimInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SelectTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�g�������I�������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ���Y�N���͈̓`�F�b�N�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_CheckProduceTypeOfYearRange';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CheckProduceTypeOfYearRange);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���Y�N���͈̓`�F�b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ������f�[�^�e�[�u���N���ݒ菈���֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ������f�[�^�e�[�u���N���ݒ菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԑ�ԍ��͈̓`�F�b�N�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_CheckProduceFrameNo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CheckProduceFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԑ�ԍ��͈̓`�F�b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈���֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �Ώ۔N���擾����(�ԑ�ԍ����擾)�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetProduceTypeOfYear';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetProduceTypeOfYear);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�Ώ۔N���擾����(�ԑ�ԍ����擾)�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����e�[�u���̃N���A�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ClearCarInfoRow';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ClearCarInfoRow);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���̃N���A�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����e�[�u���s�̔N���Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̔N���Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromFrameNo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����e�[�u���s�̎Ԏ���Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromModelInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎Ԏ���Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �Ԏ햼�̎擾�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetModelFullName';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetModelFullName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ햼�̎擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �Ԏ피�p���̎擾�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetModelHalfName';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetModelHalfName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ피�p���̎擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromCarMngCode';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����e�[�u���s�̌^���Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromFullModel';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromFullModel);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̌^���Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����e�[�u���s�̃G���W���^���Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̃G���W���^���Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ���񑶍݃`�F�b�N�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ExistCarInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ExistCarInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ���񑶍݃`�F�b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------>>>>>
    // �ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------<<<<<

    // �ԗ����e�[�u���s�̎��q���l�Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromCarNote';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNote);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎��q���l�Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �ԗ����e�[�u���s�̎��q���s�����Z�b�g�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromMileage';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromMileage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎��q���s�����Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeColorInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeTrimInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCEqpDefDspInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCEqpDefDspInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

//    // �f�[�^����֐��A�h���X�擾
//    HDllCall1.ProcName := 'ShowUAcs_FreeSalesSlipSearchResult';
//    nSt := HDllCall1.HGetPAdr(@gpxShowUAcs_FreeSalesSlipSearchResult);
//    if nSt <> 0 then
//    begin
//        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�Ԏ핔�i',
//            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
//            '�Ԏ핔�i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
//        Exit;
//    end;
    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarSpecInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarSpecInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarModel';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarModel);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeEngineModel';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeEngineModel);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarSearchCondition';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarSearchCondition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

//    //���������֐��A�h���X�擾
//    HDllCall1.ProcName := 'ShowUAcs_FreeMessage';
//    nSt := HDllCall1.HGetPAdr(@gpxShowUAcs_FreeMessage);
//    if nSt <> 0 then
//    begin
//        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�Ԏ핔�i',
//            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
//            '�Ԏ핔�i���������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
//        Exit;
//    end;

    //���������֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeMessage';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeMessage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // add by gaofeng start

    // ���_�K�C�h�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_sectionGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_sectionGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '���_�K�C�h���암�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '���_�K�C�h���암�i���_�K�C�h�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '���_�K�C�h���암�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '���_�K�C�h���암�i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ����K�C�h�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_subSectionGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_subSectionGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '����K�C�h���암�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '����K�C�h���암�i����K�C�h�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �]�ƈ��K�C�h�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_employeeGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_employeeGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�]�ƈ��K�C�h���암�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�]�ƈ��K�C�h���암�i�]�ƈ��K�C�h�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �Ǘ��ԍ��K�C�h�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_carMngNoGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_carMngNoGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�Ǘ��ԍ��K�C�h���암�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�Ǘ��ԍ��K�C�h���암�i�Ǘ��ԍ��K�C�h�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarMangInputExtraInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarMangInputExtraInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�Ǘ��ԍ��K�C�h���암�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�Ǘ��ԍ��K�C�h���암�i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �Ԏ�K�C�h�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_modelFullGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_modelFullGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�Ԏ핔�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�Ԏ핔�i�Ԏ�K�C�h�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeModelNameU';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeModelNameU);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�Ԏ핔�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�Ԏ핔�i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ���l�K�C�h�{�{�^�������֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_slipNote';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_slipNote);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '���l�K�C�h�{�{�^�����암�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '���l�K�C�h�{�{�^�����암�i���l�K�C�h�{�{�^�������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ���Z�菈���֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetRate';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetRate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '���Z�菈�����i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '���Z�菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2010/05/31 ---------->>>>>
    // CalculationSalesPrice�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_CalculationSalesPrice';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CalculationSalesPrice);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '������z�v�Z����',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '������z�v�Z�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/05/31 ----------<<<<<

	// add by gaofeng end
	
    // add by Zhangkai start

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeSalesDetail';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeSalesDetail);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�i�Ԍ������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�i�Ԍ������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;


    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayA2';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayA2);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�i�Ԍ������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�i�Ԍ������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // add by Zhangkai end

    // add by Lizc start
    // �J�[���[�J�[�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterMakerCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterMakerCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�J�[���[�J�[�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �Ԏ�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterModelCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterModelCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �Ԏ�ď̃R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterModelSubCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterModelSubCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ�ď̃R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �Ԏ햼�̂̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterModelFullNameFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterModelFullNameFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ햼�̂̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �N���̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterFirstEntryDateFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterFirstEntryDateFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�N���̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �ԑ�ԍ��̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterProduceFrameNoFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterProduceFrameNoFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԑ�ԍ��̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �ǉ����^�u����Visible�ݒ�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingAddInfoVisible';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingAddInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ǉ����^�u����Visible�ݒ�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �Ԏ�ύX�{�^��Visible�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetChangeCarInfoVisible';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetChangeCarInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ�ύX�{�^��Visible�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �Ǘ��ԍ��̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterCarMngCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterCarMngCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�Ǘ��ԍ��̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ���_�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSectionCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSectionCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���_�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ���喼�̎擾�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetNameFromSubSection';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetNameFromSubSection);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���喼�̎擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �S���ҕύX�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeSalesEmployee';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeSalesEmployee);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�S���ҕύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �󒍎ҕύX�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeFrontEmployee';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeFrontEmployee);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�󒍎ҕύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ���s�ҕύX�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeSalesInput';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeSalesInput);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���s�ҕύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �`�[�敪�ύX�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�`�[�敪�ύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ���i�敪�ύX�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeSalesGoodsCd';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeSalesGoodsCd);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���i�敪�ύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ���Ӑ�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterCustomerCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterCustomerCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���Ӑ�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �`�[�ԍ��̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSalesSlipNumFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSalesSlipNumFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�`�[�ԍ��̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �󒍃X�e�[�^�X���X�g�쐬�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SetStateList';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SetStateList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�󒍃X�e�[�^�X���X�g�쐬�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ������̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSalesDateFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSalesDateFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i������̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �[����R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterAddresseeCodeFocue';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterAddresseeCodeFocue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�[����R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_CacheForChange';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CacheForChange);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ��������̓��e�Ɣ�r�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_CompareSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CompareSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i��������̓��e�Ɣ�r�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �|�����N���A�����i�S�āj�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ClearAllRateInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ClearAllRateInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�|�����N���A�����i�S�āj�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ���l�P�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSlipNoteCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSlipNoteCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���l�P�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ���l�Q�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSlipNote2CodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���l�Q�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ----- ADD K2011/08/12 --------------------------->>>>>
    // ���l�Q�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSlipNote2Focus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSlipNote2Focus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���l�Q�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // ----- ADD K2011/08/12 ---------------------------<<<<<

    // ���l�R�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSlipNote3CodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSlipNote3CodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���l�R�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ����f�[�^�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����f�[�^�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ������m�F�{�^���N���b�N�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_CustomerClaimConfirmationClick';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CustomerClaimConfirmationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i������m�F�{�^���N���b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �[����m�F�{�^���N���b�N�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_AddresseeConfirmationClick';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AddresseeConfirmationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�[����m�F�{�^���N���b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ���㖾�׃f�[�^�̑��݃`�F�b�N�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ExistSalesDetail';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ExistSalesDetail);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���㖾�׃f�[�^�̑��݃`�F�b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ����`���ύX�\�`�F�b�N�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeCheckAcptAnOdrStatus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����`���ύX�\�`�F�b�N�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ����`���ύX�\�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeAcptAnOdrStatus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeAcptAnOdrStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����`���ύX�\�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ����f�[�^�L���b�V�������֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_Cache';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_Cache);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����f�[�^�L���b�V�������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �\���p�`�[�敪���A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂��֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�\���p�`�[�敪���A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂��֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �������I�������֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SelectEquipInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SelectEquipInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�������I�������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �f�[�^�ύX�t���O�̐ݒ菈���֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SetGetIsDataChanged';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SetGetIsDataChanged);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�f�[�^�ύX�t���O�̐ݒ菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetHeaderFocusConstructionListValue';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetHeaderFocusConstructionListValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetFocusConstructionValue';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetFocusConstructionValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeHeaderFocusConstruction';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeHeaderFocusConstruction);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeFooterFocusConstruction';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeFooterFocusConstruction);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;


    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB6';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB6);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB5';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB5);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB4';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB4);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB3';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB3);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB2';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB2);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // ���_���̂̎捞�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSectionNm';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSectionNm);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i���_���̂̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // --- ADD 2010/07/16 ---------->>>>>
    // �ԗ������敪�̎捞�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_SetGetSearchCarDiv';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SetGetSearchCarDiv);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ������敪�̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
    // �c�[���`�b�v���������֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_CreateStockCountInfoString';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CreateStockCountInfoString);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�o�׏Ɖ�i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�o�׏Ɖ�i�c�[���`�b�v���������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // add by Yangmj end

    // --- ADD 2010/05/31 ---------->>>>>
    HDllCall1.ProcName := 'SalesSlipInputAcs_ReCalcSalesUnitPrice';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ReCalcSalesUnitPrice);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '����P���Čv�Z',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '����P���Čv�Z�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by Tanhong start

    // add by Tanhong end
    //2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //RC�A�g - CSV�o��
    HDllCALL1.ProcName := 'SalesSlipInputAcs_CopyToRC';
    nSt := HDllCALL1.HGetPAdr(@gpxSalesSlipInputAcs_CopyToRC);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', 'RC�A�g���i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�q�b�A�g�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    // ���[�������\���f�[�^�쐬����
    HDllCall1.ProcName := 'SalesSlipInputAcs_MakeMailDefaultData';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_MakeMailDefaultData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '����f�[�^�쐬���i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '���[�������\���f�[�^�쐬�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    // --- ADD 2012/02/09 ����� Redmine#28289 ---------->>>>>
    // ������t���O�̎捞����
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetPrintThreadOverFlag';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetPrintThreadOverFlag);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '������t���O�̎捞����',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '������t���O�̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/02/09 ����� Redmine#28289 ----------<<<<<

    // --- ADD 2013/03/21 ---------->>>>>
    // �n���h���ʒu�`�F�b�N�����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputAcs_CheckHandlePosition';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CheckHandlePosition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '�ԗ��������i',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '�n���h���ʒu�`�F�b�N�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2013/03/21 ----------<<<<<

    Result := 0;

end;

// �A�N�Z�X�N���X����DLL������\�b�h
procedure FreeLibraryMAHNB01012M(HDllCall1: THDllCall);
begin
    HDllCall1.DllName := 'MAHNB01012M.DLL';
    HDllCall1.HFreeLibrary;
//    gpxShowUAcs_SalesSlipGuide := nil;
//    gpxShowUAcs_FreeSalesSlipSearchResult := nil;
//    gpxShowUAcs_FreeMessage := nil;
    gpxSalesSlipInputAcs_CarSearch := nil;
    gpxSalesSlipInputAcs_GetSettingOptionInfo := nil;
    gpxSalesSlipInputAcs_GetCarInfoRow := nil;
    gpxSalesSlipInputAcs_GetColorInfo := nil;
    gpxSalesSlipInputAcs_GetSelectColorInfo := nil;
    gpxSalesSlipInputAcs_GetTrimInfo := nil;
    gpxSalesSlipInputAcs_GetSelectTrimInfo := nil;
    gpxSalesSlipInputAcs_GetEquipInfo := nil;
    gpxSalesSlipInputAcs_SelectColorInfo := nil;
    gpxSalesSlipInputAcs_SelectTrimInfo := nil;
    gpxSalesSlipInputAcs_CheckProduceTypeOfYearRange := nil;
    gpxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate := nil;
    gpxSalesSlipInputAcs_CheckProduceFrameNo := nil;
    gpxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo := nil;
    gpxSalesSlipInputAcs_GetProduceTypeOfYear := nil;
    gpxSalesSlipInputAcs_ClearCarInfoRow := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo := nil;
    gpxSalesSlipInputAcs_GetModelFullName := nil;
    gpxSalesSlipInputAcs_GetModelHalfName := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFullModel := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm := nil;
    gpxSalesSlipInputAcs_ExistCarInfo := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode := nil; // ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNote := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromMileage := nil;

    gpxSalesSlipInputAcs_FreeColorInfo := nil;
    gpxSalesSlipInputAcs_FreeTrimInfo := nil;
    gpxSalesSlipInputAcs_FreeCEqpDefDspInfo := nil;
    gpxSalesSlipInputAcs_FreeCarSpecInfo := nil;
    gpxSalesSlipInputAcs_FreeCarInfo := nil;
    gpxSalesSlipInputAcs_FreeCarModel := nil;
    gpxSalesSlipInputAcs_FreeEngineModel := nil;
    gpxSalesSlipInputAcs_FreeCarSearchCondition := nil;
    gpxSalesSlipInputAcs_FreeMessage := nil;
    gpxSalesSlipInputAcs_FreeHeaderFocusConstruction := nil;
    gpxSalesSlipInputAcs_FreeFooterFocusConstruction := nil;
    gpxSalesSlipInputAcs_FreeCustomArrayB6 := nil;
    gpxSalesSlipInputAcs_FreeCustomArrayB5 := nil;
    
    // add by gaofeng start
    gpxSalesSlipInputAcs_sectionGuide := nil;
    gpxSalesSlipInputAcs_FreeSalesSlip := nil;
    gpxSalesSlipInputAcs_subSectionGuide := nil;
    gpxSalesSlipInputAcs_employeeGuide := nil;
    gpxSalesSlipInputAcs_carMngNoGuide := nil;
    gpxSalesSlipInputAcs_FreeCarMangInputExtraInfo := nil;
    gpxSalesSlipInputAcs_modelFullGuide := nil;
    gpxSalesSlipInputAcs_FreeModelNameU := nil;
    gpxSalesSlipInputAcs_slipNote := nil;
    gpxSalesSlipInputAcs_GetRate := nil;

    // --- ADD 2010/05/31 ---------->>>>>
    gpxSalesSlipInputAcs_CalculationSalesPrice := nil;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by gaofeng end
    
    // add by Zhangkai start
    gpxSalesSlipInputAcs_FreeSalesDetail := nil;
    gpxSalesSlipInputAcs_FreeCustomArrayA2 := nil;
    // add by Zhangkai end

    // add by Lizc start
	gpxSalesSlipInputAcs_AfterMakerCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterModelCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterModelSubCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterModelFullNameFocus := nil;
    gpxSalesSlipInputAcs_AfterFirstEntryDateFocus := nil;
    gpxSalesSlipInputAcs_AfterProduceFrameNoFocus := nil;
    gpxSalesSlipInputAcs_SettingAddInfoVisible := nil;
    gpxSalesSlipInputAcs_GetChangeCarInfoVisible := nil;
    gpxSalesSlipInputAcs_AfterCarMngCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterSectionCodeFocus := nil;
    gpxSalesSlipInputAcs_GetNameFromSubSection := nil;
    gpxSalesSlipInputAcs_ChangeSalesEmployee := nil;
    gpxSalesSlipInputAcs_ChangeFrontEmployee := nil;
    gpxSalesSlipInputAcs_ChangeSalesInput := nil;
    gpxSalesSlipInputAcs_ChangeSalesSlip := nil;
    gpxSalesSlipInputAcs_ChangeSalesGoodsCd := nil;
    gpxSalesSlipInputAcs_AfterCustomerCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterSalesSlipNumFocus := nil;
    gpxSalesSlipInputAcs_SetStateList := nil;
    gpxSalesSlipInputAcs_AfterSalesDateFocus := nil;
    gpxSalesSlipInputAcs_AfterAddresseeCodeFocue := nil;
    gpxSalesSlipInputAcs_CacheForChange := nil;
    gpxSalesSlipInputAcs_CompareSalesSlip := nil;
    gpxSalesSlipInputAcs_ReCalcSalesUnitPrice := nil;
    gpxSalesSlipInputAcs_ClearAllRateInfo := nil;
    gpxSalesSlipInputAcs_AfterSlipNoteCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus := nil;
    gpxSalesSlipInputAcs_AfterSlipNote2Focus := nil; // ADD K2011/08/12
    gpxSalesSlipInputAcs_AfterSlipNote3CodeFocus := nil;
    gpxSalesSlipInputAcs_GetSalesSlip := nil;
    gpxSalesSlipInputAcs_CustomerClaimConfirmationClick := nil;
    gpxSalesSlipInputAcs_AddresseeConfirmationClick := nil;
    gpxSalesSlipInputAcs_ExistSalesDetail := nil;
    gpxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus := nil;
    gpxSalesSlipInputAcs_ChangeAcptAnOdrStatus := nil;
    gpxSalesSlipInputAcs_Cache := nil;
    gpxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay := nil;
    gpxSalesSlipInputAcs_SelectEquipInfo := nil;
    gpxSalesSlipInputAcs_SetGetIsDataChanged := nil;
    gpxSalesSlipInputAcs_GetHeaderFocusConstructionListValue := nil;
    gpxSalesSlipInputAcs_GetSectionNm := nil;
    gpxSalesSlipInputAcs_SetGetSearchCarDiv := nil; //ADD 2010/07/16
    // add by Lizc end

    // add by Yangmj start
    gpxSalesSlipInputAcs_CreateStockCountInfoString := nil;
    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    gpxSalesSlipInputAcs_MakeMailDefaultData := nil;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    gpxSalesSlipInputAcs_CopyToRC := nil;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    // --- ADD 2013/03/21 ---------->>>>>
    gpxSalesSlipInputAcs_CheckHandlePosition := nil;
    // --- ADD 2013/03/21 ----------<<<<<
end;

(*============================================================================*)
(*  ����������                                                                *)
(*============================================================================*)
initialization
  //------------------------------------------------//
  //  �f�[�^���W���[���̐���                        //
  //------------------------------------------------//
  if DataModule1 = nil then
  begin
    DataModule1 := TDataModule1.Create(Application);
    if DataModule1 = nil then
    begin
      //HDspErrorDlg('����������(initialization)', 'CREATE', '�f�[�^���W���[�������G���[', -99, nil);
    end
    else
    begin
        //�֐����[�h
        LoadLibraryMAHNB01012M(DataModule1.HDllCall1);
    end;
  end;


(*============================================================================*)
(*  �I��������                                                                *)
(*============================================================================*)
finalization

  //------------------------------------------------//
  //  �f�[�^���W���[���̉��                        //
  //------------------------------------------------//
  if DataModule1 <> nil then
  begin
    //�֐��A�����[�h
    FreeLibraryMAHNB01012M(DataModule1.HDllCall1);

    DataModule1.Free;
    DataModule1 := nil;
  end;

end.
