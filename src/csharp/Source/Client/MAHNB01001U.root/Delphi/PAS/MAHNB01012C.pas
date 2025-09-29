//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����`�[����
// �v���O�����T�v   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601193-00 �쐬�S�� : LDNS
// �� �� ��  2010/05/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601193-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2010/05/30  �C�����e : ���ʕ�����
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/06/12  �C�����e : �g�у��[���@�\�̑g��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2011/02/01  �C�����e : SCM��񑶍݃`�F�b�N�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2011/07/18  �C�����e : �񓚋敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10703874-00 �쐬�S�� : yangyi
// �� �� ��  K2011/08/12 �C�����e : �C�X�R�ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : �����
// �� �� ��  2012/02/09  �C�����e : �A�v���P�[�V�����I�������O�ɁA������t���O�̔��f��ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : ���N�n��
// �� �� ��  2012/03/12  �C�����e : Redmine#28288
//                                  �s��ǉ����čX�V���s���ƁA���M�ς݂̃`�F�b�N��������ɂ��Ă̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900269-00 �쐬�S�� : FSI���� ���T
// �� �� ��  2013/03/21  �C�����e : SPK�ԑ�ԍ�������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070071-00 �쐬�S�� : �{�{�@����
// �� �� ��  2014/05/19  �C�����e : �d�|�ꗗ��2218 ���q���l���ɃR�[�h���͍��ڂ�ǉ�
//----------------------------------------------------------------------------//

unit MAHNB01012C;

interface

Uses
    HDllCall, DBClient, HFSLLIB;

type

    // add by gaofeng start
    //����f�[�^�f�[�^�\����
    TSalesSlip = packed record
        AcptAnOdrStatus: LongInt;    //�󒍃X�e�[�^�X
        SalesSlipNum: WideString;    //����`�[�ԍ�
        SectionCode: WideString;    //���_�R�[�h
        InputMode: LongInt;    //���_�R�[�h
        SalesSlipDisplay : LongInt; // ����`�[�敪(��ʕ\���p)
        AcptAnOdrStatusDisplay: LongInt;
        CarMngDivCd: LongInt;
        SubSectionCode: LongInt;    //����R�[�h
        SubSectionName: WideString;    //���喼��
        DebitNoteDiv: LongInt;    //�ԓ`�敪
        DebitNLnkSalesSlNum: WideString;    //�ԍ��A������`�[�ԍ�
        SalesSlipCd: LongInt;    //����`�[�敪
        SalesGoodsCd: LongInt;    //���㏤�i�敪
        AccRecDivCd: LongInt;    //���|�敪
        SalesInpSecCd: WideString;    //������͋��_�R�[�h
        DemandAddUpSecCd: WideString;    //�����v�㋒�_�R�[�h
        ResultsAddUpSecCd: WideString;    //���ьv�㋒�_�R�[�h
        ResultsAddUpSecNm: WideString;
        UpdateSecCd: WideString;    //�X�V���_�R�[�h
        SalesSlipUpdateCd: LongInt;    //����`�[�X�V�敪
        SearchSlipDate: Int64;    //�`�[�������t
        ShipmentDay: Int64;    //�o�ד��t
        SalesDate: Int64;    //������t
        AddUpADate: Int64;    //�v����t
        DelayPaymentDiv: LongInt;    //�����敪
        EstimateFormNo: WideString;    //���Ϗ��ԍ�
        EstimateDivide: LongInt;    //���ϋ敪
        InputAgenCd: WideString;    //���͒S���҃R�[�h
        InputAgenNm: WideString;    //���͒S���Җ���
        SalesInputCode: WideString;    //������͎҃R�[�h
        SalesInputName: WideString;    //������͎Җ���
        FrontEmployeeCd: WideString;    //��t�]�ƈ��R�[�h
        FrontEmployeeNm: WideString;    //��t�]�ƈ�����
        SalesEmployeeCd: WideString;    //�̔��]�ƈ��R�[�h
        SalesEmployeeNm: WideString;    //�̔��]�ƈ�����
        TotalAmountDispWayCd: LongInt;    //���z�\�����@�敪
        TtlAmntDispRateApy: LongInt;    //���z�\���|���K�p�敪
        SalesTotalTaxInc: Int64;    //����`�[���v�i�ō��݁j
        SalesTotalTaxExc: Int64;    //����`�[���v�i�Ŕ����j
        SalesPrtTotalTaxInc: Int64;    //���㕔�i���v�i�ō��݁j
        SalesPrtTotalTaxExc: Int64;    //���㕔�i���v�i�Ŕ����j
        SalesWorkTotalTaxInc: Int64;    //�����ƍ��v�i�ō��݁j
        SalesWorkTotalTaxExc: Int64;    //�����ƍ��v�i�Ŕ����j
        SalesSubtotalTaxInc: Int64;    //���㏬�v�i�ō��݁j
        SalesSubtotalTaxExc: Int64;    //���㏬�v�i�Ŕ����j
        SalesPrtSubttlInc: Int64;    //���㕔�i���v�i�ō��݁j
        SalesPrtSubttlExc: Int64;    //���㕔�i���v�i�Ŕ����j
        SalesWorkSubttlInc: Int64;    //�����Ə��v�i�ō��݁j
        SalesWorkSubttlExc: Int64;    //�����Ə��v�i�Ŕ����j
        SalesNetPrice: Int64;    //���㐳�����z
        SalesSubtotalTax: Int64;    //���㏬�v�i�Łj
        ItdedSalesOutTax: Int64;    //����O�őΏۊz
        ItdedSalesInTax: Int64;    //������őΏۊz
        SalSubttlSubToTaxFre: Int64;    //���㏬�v��ېőΏۊz
        SalesOutTax: Int64;    //������z����Ŋz�i�O�Łj
        SalAmntConsTaxInclu: Int64;    //������z����Ŋz�i���Łj
        SalesDisTtlTaxExc: Int64;    //����l�����z�v�i�Ŕ����j
        ItdedSalesDisOutTax: Int64;    //����l���O�őΏۊz���v
        ItdedSalesDisInTax: Int64;    //����l�����őΏۊz���v
        ItdedPartsDisOutTax: Int64;    //���i�l���Ώۊz���v�i�Ŕ����j
        ItdedPartsDisInTax: Int64;    //���i�l���Ώۊz���v�i�ō��݁j
        ItdedWorkDisOutTax: Int64;    //��ƒl���Ώۊz���v�i�Ŕ����j
        ItdedWorkDisInTax: Int64;    //��ƒl���Ώۊz���v�i�ō��݁j
        ItdedSalesDisTaxFre: Int64;    //����l����ېőΏۊz���v
        SalesDisOutTax: Int64;    //����l������Ŋz�i�O�Łj
        SalesDisTtlTaxInclu: Int64;    //����l������Ŋz�i���Łj
        PartsDiscountRate: Double;    //���i�l����
        RavorDiscountRate: Double;    //�H���l����
        TotalCost: Int64;    //�������z�v
        ConsTaxLayMethod: LongInt;    //����œ]�ŕ���
        ConsTaxRate: Double;    //����Őŗ�
        FractionProcCd: LongInt;    //�[�������敪
        AccRecConsTax: Int64;    //���|�����
        AutoDepositCd: LongInt;    //���������敪
        AutoDepositSlipNo: LongInt;    //���������`�[�ԍ�
        DepositAllowanceTtl: Int64;    //�����������v�z
        DepositAlwcBlnce: Int64;    //���������c��
        ClaimCode: LongInt;    //������R�[�h
        ClaimSnm: WideString;    //�����旪��
        CustomerCode: LongInt;    //���Ӑ�R�[�h
        CustomerName: WideString;    //���Ӑ於��
        CustomerName2: WideString;    //���Ӑ於��2
        CustomerSnm: WideString;    //���Ӑ旪��
        HonorificTitle: WideString;    //�h��
        OutputNameCode: LongInt;    //�����R�[�h
        OutputName: WideString;    //��������
        CustSlipNo: LongInt;    //���Ӑ�`�[�ԍ�
        SlipAddressDiv: LongInt;    //�`�[�Z���敪
        AddresseeCode: LongInt;    //�[�i��R�[�h
        AddresseeName: WideString;    //�[�i�於��
        AddresseeName2: WideString;    //�[�i�於��2
        AddresseePostNo: WideString;    //�[�i��X�֔ԍ�
        AddresseeAddr1: WideString;    //�[�i��Z��1(�s���{���s��S�E�����E��)
        AddresseeAddr3: WideString;    //�[�i��Z��3(�Ԓn)
        AddresseeAddr4: WideString;    //�[�i��Z��4(�A�p�[�g����)
        AddresseeTelNo: WideString;    //�[�i��d�b�ԍ�
        AddresseeFaxNo: WideString;    //�[�i��FAX�ԍ�
        PartySaleSlipNum: WideString;    //�����`�[�ԍ�
        SlipNote: WideString;    //�`�[���l
        SlipNote2: WideString;    //�`�[���l�Q
        SlipNote3: WideString;    //�`�[���l�R
        SlipNoteCode: LongInt;    //�`�[���l
        SlipNote2Code: LongInt;    //�`�[���l�Q
        SlipNote3Code: LongInt;    //�`�[���l�R
        RetGoodsReasonDiv: LongInt;    //�ԕi���R�R�[�h
        RetGoodsReason: WideString;    //�ԕi���R
        RegiProcDate: Int64;    //���W������
        CashRegisterNo: LongInt;    //���W�ԍ�
        PosReceiptNo: LongInt;    //POS���V�[�g�ԍ�
        DetailRowCount: LongInt;    //���׍s��
        EdiSendDate: Int64;    //�d�c�h���M��
        EdiTakeInDate: Int64;    //�d�c�h�捞��
        UoeRemark1: WideString;    //�t�n�d���}�[�N�P
        UoeRemark2: WideString;    //�t�n�d���}�[�N�Q
        SlipPrintDivCd: LongInt;    //�`�[���s�敪
        SlipPrintFinishCd: LongInt;    //�`�[���s�ϋ敪
        SalesSlipPrintDate: Int64;    //����`�[���s��
        BusinessTypeCode: LongInt;    //�Ǝ�R�[�h
        BusinessTypeName: WideString;    //�Ǝ햼��
        OrderNumber: WideString;    //�����ԍ�
        DeliveredGoodsDiv: LongInt;    //�[�i�敪
        DeliveredGoodsDivNm: WideString;    //�[�i�敪����
        SalesAreaCode: LongInt;    //�̔��G���A�R�[�h
        SalesAreaName: WideString;    //�̔��G���A����
        ReconcileFlag: LongInt;    //�����t���O
        SlipPrtSetPaperId: WideString;    //�`�[����ݒ�p���[ID
        CompleteCd: LongInt;    //�ꎮ�`�[�敪
        SalesPriceFracProcCd: LongInt;    //������z�[�������敪
        StockGoodsTtlTaxExc: Int64;    //�݌ɏ��i���v���z�i�Ŕ��j
        PureGoodsTtlTaxExc: Int64;    //�������i���v���z�i�Ŕ��j
        ListPricePrintDiv: LongInt;    //�艿����敪
        EraNameDispCd1: LongInt;    //�����\���敪�P
        EstimaTaxDivCd: LongInt;    //���Ϗ���ŋ敪
        EstimateFormPrtCd: LongInt;    //���Ϗ�����敪
        EstimateSubject: WideString;    //���ό���
        Footnotes1: WideString;    //�r���P
        Footnotes2: WideString;    //�r���Q
        EstimateTitle1: WideString;    //���σ^�C�g���P
        EstimateTitle2: WideString;    //���σ^�C�g���Q
        EstimateTitle3: WideString;    //���σ^�C�g���R
        EstimateTitle4: WideString;    //���σ^�C�g���S
        EstimateTitle5: WideString;    //���σ^�C�g���T
        EstimateNote1: WideString;    //���ϔ��l�P
        EstimateNote2: WideString;    //���ϔ��l�Q
        EstimateNote3: WideString;    //���ϔ��l�R
        EstimateNote4: WideString;    //���ϔ��l�S
        EstimateNote5: WideString;    //���ϔ��l�T
        EstimateValidityDate: Int64;    //���ϗL������
        PartsNoPrtCd: LongInt;    //�i�Ԉ󎚋敪
        OptionPringDivCd: LongInt;    //�I�v�V�����󎚋敪
        RateUseCode: LongInt;    //�|���g�p�敪
        CreateDateTime: Int64;    //�쐬����
        UpdateDateTime: Int64;    //�X�V����
        EnterpriseCode: WideString;    //��ƃR�[�h
        FileHeaderGuid: array [0 .. 15] of AnsiChar;    //GUID
        UpdEmployeeCode: WideString;    //�X�V�]�ƈ��R�[�h
        UpdAssemblyId1: WideString;    //�X�V�A�Z���u��ID1
        UpdAssemblyId2: WideString;    //�X�V�A�Z���u��ID2
        CustOrderNoDispDiv: LongInt;
        CustWarehouseCd : WideString; //���Ӑ�D��q�ɃR�[�h
        CreditMngCode: LongInt;
        DetailRowCountForReadSlip: LongInt;  //���׍s��
        //>>>2010/05/30
        OnlineKindDiv : LongInt;
        InqOriginalEpCd : WideString;
        InqOriginalSecCd : WideString;
        AnswerDiv : Integer;
        InquiryNumber : Int64;
        InqOrdDivCd : Integer;
        //<<<2010/05/30
        AutoAnswerDivSCM : Integer; // �����񓚋敪(SCM)  2011/07/18 zhubj
        PreSalesDate : Int64;    //ADD ���N�n�� 2012/03/12 Redmine#28288
    end;

    //����f�[�^�f�[�^�|�C���^�^
    PSalesSlip = ^TSalesSlip;

    //����f�[�^�f�[�^�z��^
    TSalesSlipArray = array of TSalesSlip;

    //����f�[�^�f�[�^�\���� TCarMngGuideParamInfo
    TCarMangInputExtraInfo = packed record
        AddiCarSpec1: WideString;    //�ǉ�����1
        AddiCarSpec2: WideString;    //�ǉ�����2
        AddiCarSpec3: WideString;    //�ǉ�����3
        AddiCarSpec4: WideString;    //�ǉ�����4
        AddiCarSpec5: WideString;    //�ǉ�����5
        AddiCarSpec6: WideString;    //�ǉ�����6
        AddiCarSpecTitle1: WideString;    //�ǉ������^�C�g��1
        AddiCarSpecTitle2: WideString;    //�ǉ������^�C�g��2
        AddiCarSpecTitle3: WideString;    //�ǉ������^�C�g��3
        AddiCarSpecTitle4: WideString;    //�ǉ������^�C�g��4
        AddiCarSpecTitle5: WideString;    //�ǉ������^�C�g��5
        AddiCarSpecTitle6: WideString;    //�ǉ������^�C�g��6
        BlockIllustrationCd: LongInt;    //�u���b�N�C���X�g�R�[�h
        BodyName: WideString;    //�{�f�B�[����
        BodyNameCode: LongInt;    //�{�f�B�[���R�[�h
        CarAddInfo1: WideString;    //���q�ǉ����P
        CarAddInfo2: WideString;    //���q�ǉ����Q
        CarInspectYear: LongInt;    //�Ԍ�����
        CarMngCode: WideString;    //���q�Ǘ��R�[�h
        CarMngNo: LongInt;    //�ԗ��Ǘ��ԍ�
        CarNo: WideString;    //����
        CarNote: WideString;    //���q���l
        CarRelationGuid: array [0 .. 15] of AnsiChar;    //�ԗ��֘A�t��GUID
        CategoryNo: LongInt;    //�ޕʔԍ�
//        CategoryObjAry: WideString;    //�����I�u�W�F�N�g�z��
        CategorySignModel: WideString;    //�^���i�ޕʋL���j
        ColorCode: WideString;    //�J���[�R�[�h
        ColorName1: WideString;    //�J���[����1
        CreateDateTime: Int64;    //�쐬����
        CustomerCode: LongInt;    //���Ӑ�R�[�h
        CustomerCodeForGuide: WideString;    //���Ӑ�R�[�h
        CustomerName: LongInt;    //���Ӑ於��
        DoorCount: LongInt;    //�h�A��
        EDivNm: WideString;    //E�敪����
        EdProduceFrameNo: LongInt;    //���Y�ԑ�ԍ��I��
        EdProduceTypeOfYear: Int64;    //�I�����Y�N��
        EngineDisplaceNm: WideString;    //�r�C�ʖ���
        EngineModel: WideString;    //�����@�^���i�G���W���j
        EngineModelNm: WideString;    //�G���W���^������
        EnterpriseCode: WideString;    //��ƃR�[�h
        EntryDate: Int64;    // �o�^�N����
        ExhaustGasSign: WideString;    //�r�K�X�L��
        FileHeaderGuid: array [0 .. 15] of AnsiChar;    //GUID
        FirstEntryDate: LongInt;    //���N�x
        FrameModel: WideString;    //�ԑ�^��
        FrameNo: WideString;    //�ԑ�ԍ�
        FullModel: WideString;    //�^���i�t���^�j
//        FullModelFixedNoAry: WideString;    //�t���^���Œ�ԍ��z��
        InspectMaturityDate: Int64;    //�Ԍ�������
        LogicalDeleteCode: LongInt;    //�_���폜�敪
        LTimeCiMatDate: Int64;    //�O��Ԍ�������
        MakerCode: LongInt;    //���[�J�[�R�[�h
        MakerFullName: WideString;    //���[�J�[�S�p����
        MakerHalfName: WideString;    //���[�J�[���p����
        Mileage: LongInt;    //�ԗ����s����
        ModelCode: LongInt;    //�Ԏ�R�[�h
        ModelDesignationNo: LongInt;    //�^���w��ԍ�
        ModelFullName: WideString;    //�Ԏ�S�p����
        ModelGradeNm: WideString;    //�^���O���[�h����
        ModelGradeSname: WideString;    //�^���O���[�h����
        ModelHalfName: WideString;    //�Ԏ피�p����
        ModelSubCode: LongInt;    //�Ԏ�T�u�R�[�h
        NumberPlate1Code: LongInt;    //���^�������ԍ�
        NumberPlate1Name: WideString;    //���^�����ǖ���
        NumberPlate2: WideString;    //�ԗ��o�^�ԍ��i��ʁj
        NumberPlate3: WideString;    //�ԗ��o�^�ԍ��i�J�i�j
        NumberPlate4: LongInt;    //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
        NumberPlateForGuide: WideString;    //�ԗ��o�^�ԍ��i�K�C�h�p�j
        PartsDataOfferFlag: LongInt;    //���i�f�[�^�񋟃t���O�v
        ProduceTypeOfYearCd: LongInt;    //���Y�N���R�[�h
        ProduceTypeOfYearInput: LongInt;    //�N��
        ProduceTypeOfYearNm: WideString;    //���Y�N������
        RelevanceModel: WideString;    //�֘A�^��
        SearchFrameNo: LongInt;    //�ԑ�ԍ��i�����p�j
        SeriesModel: WideString;    //�V���[�Y�^��
        ShiftNm: WideString;    //�V�t�g����
        StProduceFrameNo: LongInt;    //���Y�ԑ�ԍ��J�n
        StProduceTypeOfYear: Int64;    //�J�n���Y�N��
        SubCarNmCd: LongInt;    //�T�u�Ԗ��R�[�h
        SystematicCode: LongInt;    //�n���R�[�h
        SystematicName: WideString;    //�n������
        ThreeDIllustNo: LongInt;    //3D�C���X�gNo
        TransmissionNm: WideString;    //�~�b�V��������
        TrimCode: WideString;    //�g�����R�[�h
        TrimName: WideString;    //�g��������
        UpdateDateTime: Int64;    //�X�V����
        WheelDriveMethodNm: WideString;    //�쓮��������
        DomesticForeignCode: LongInt;    //���Y/�O�ԋ敪 // ADD 2013/03/21
    end;

    //����f�[�^�f�[�^�|�C���^�^
    PCarMangInputExtraInfo = ^TCarMangInputExtraInfo;

    //����f�[�^�f�[�^�z��^
    TCarMangInputExtraInfoArray = array of TCarMangInputExtraInfo;

    //�Ԏ햼�̃}�X�^�f�[�^�\����
    TModelNameU = packed record
        CreateDateTime: Int64;    //�쐬����
        CreateDateTimeAdFormal: WideString;    //�쐬���� ����
        CreateDateTimeAdInFormal: WideString;    //�쐬���� ����(��)
        CreateDateTimeJpFormal: WideString;    //�쐬���� �a��
        CreateDateTimeJpInFormal: WideString;    //�쐬���� �a��(��)
        Division: LongInt;    //�\���敪
        DivisionName: WideString;    //�\���敪����
        EnterpriseCode: WideString;    //��ƃR�[�h
        EnterpriseName: WideString;    //��Ɩ���
        FileHeaderGuid: array [0 .. 15] of AnsiChar;    //GUID
        LogicalDeleteCode: LongInt;    //�_���폜�敪
        MakerCode: LongInt;    //���[�J�[�R�[�h
        ModelAliasName: WideString;    //�Ԏ�Ăі�����
        ModelCode: LongInt;    //�Ԏ�R�[�h
        ModelFullName: WideString;    //�Ԏ�S�p����
        ModelHalfName: WideString;    //�Ԏ피�p����
        ModelSubCode: LongInt;    //�Ԏ�T�u�R�[�h
        ModelUniqueCode: LongInt;    //�Ԏ�R�[�h�i���j�[�N�j
        OfferDataDiv: LongInt;    //�񋟃f�[�^�敪
        OfferDate: Int64;    //�񋟓��t
        UpdAssemblyId1: WideString;    //�X�V�A�Z���u��ID1
        UpdAssemblyId2: WideString;    //�X�V�A�Z���u��ID2
        UpdateDateTime: Int64;    //�X�V����
        UpdateDateTimeAdFormal: WideString;    //�X�V���� ����
        UpdateDateTimeAdInFormal: WideString;    //�X�V���� ����(��)
        UpdateDateTimeJpFormal: WideString;    //�X�V���� �a��
        UpdateDateTimeJpInFormal: WideString;    //�X�V���� �a��(��)
        UpdEmployeeCode: WideString;    //�X�V�]�ƈ��R�[�h
        UpdEmployeeName: WideString;    //�X�V�]�ƈ�����
    end;

    //�Ԏ햼�̃}�X�^�f�[�^�|�C���^�^
    PModelNameU = ^TModelNameU;

    //�Ԏ햼�̃}�X�^�f�[�^�z��^
    TModelNameUArray = array of TModelNameU;

    //�f�[�^�\����
    TUserGdHd = packed record
        CreateDateTime          : Int64;    //�쐬����
        CreateDateTimeAdFormal  : WideString;    //�쐬���� ����
        CreateDateTimeAdInFormal: WideString;    //�쐬���� ����(��)
        CreateDateTimeJpFormal  : WideString;    //�쐬���� �a��
        CreateDateTimeJpInFormal: WideString;    //�쐬���� �a��(��)
        LogicalDeleteCode       : LongInt;    //�_���폜�敪
        MasterOfferCd           : LongInt;    //XXXX
        UpdateDateTime          : Int64;    //�X�V����
        UpdateDateTimeAdFormal  : WideString;    //�X�V���� ����
        UpdateDateTimeAdInFormal: WideString;    //�X�V���� ����(��)
        UpdateDateTimeJpFormal  : WideString;    //�X�V���� �a��
        UpdateDateTimeJpInFormal: WideString;    //�X�V���� �a��(��)
        UserGuideDivCd          : WideString;    //�X�V�]�ƈ��R�[�h
        UserGuideDivNm          : WideString;    //�X�V�]�ƈ�����
    end;

    //�f�[�^�|�C���^�^
    PUserGdHd = ^TUserGdHd;

    //�f�[�^�z��^
    TUserGdHdArray = array of TUserGdHd;

    //�f�[�^�\����
    TUserGdBd = packed record
        CreateDateTime            : Int64;    //�쐬����
        CreateDateTimeAdFormal    : WideString;    //�쐬��������
        CreateDateTimeAdInFormal  : WideString;    //�쐬��������(��)
        CreateDateTimeJpFormal    : WideString;    //�쐬�����a��
        CreateDateTimeJpInFormal  : WideString;    //�쐬�����a��(��)
        EnterpriseCode            : WideString;    //��ƃR�[�h
        EnterpriseName            : WideString;    //��Ɩ���
        FileHeaderGuid            : array [0 .. 15] of AnsiChar;    //GUID
        GuideCode                 : LongInt;    //�K�C�h�R�[�h
        GuideName                 : WideString;    //�K�C�h����
        GuideType                 : LongInt;    //�K�C�h�^�C�v
        LogicalDeleteCode         : LongInt;    //�_���폜�敪
        UpdAssemblyId1            : WideString;    //�X�V�A�Z���u��ID1
        UpdAssemblyId2            : WideString;    //�X�V�A�Z���u��ID2
        UpdateDateTime          : Int64;    //�X�V����
        UpdateDateTimeAdFormal    : WideString;    //�X�V���� ����
        UpdateDateTimeAdInFormal  : WideString;    //�X�V���� ����(��)
        UpdateDateTimeJpFormal    : WideString;    //�X�V���� �a��
        UpdateDateTimeJpInFormal  : WideString;    //�X�V���� �a��(��)
        UpdEmployeeCode           : WideString;    //�X�V�]�ƈ��R�[�h
        UpdEmployeeName           : WideString;    //�X�V�]�ƈ�����
        UserGuideDivCd            : LongInt;    //�X�V�]�ƈ��R�[�h
    end;

    //�f�[�^�|�C���^�^
    PUserGdBd = ^TUserGdBd;

    //�f�[�^�z��^
    TUserGdBdArray = array of TUserGdBd;

    TCustomerInfo = packed record
        AcceptWholeSale: LongInt;
        AccountNoInfo1: WideString;
        AccountNoInfo2: WideString;
        AccountNoInfo3: WideString;
        AccRecDivCd: LongInt;
        AcpOdrrSlipPrtDiv: LongInt;
        Address1: WideString;
        Address3: WideString;
        Address4: WideString;
        BillCollecterCd: WideString;
        BillCollecterNm: WideString;
        BillHonorificTtl: WideString;
        BillHonorTtlPrtDiv: LongInt;
        BillOutputCode: LongInt;
        BillOutPutCodeNm: WideString;
        BillOutputName: WideString;
        BillPartsNoPrtCd: LongInt;
        BusinessTypeCode: LongInt;
        BusinessTypeName: WideString;
        CarMngDivCd: LongInt;
        ClaimCode: LongInt;
        ClaimName: WideString;
        ClaimName2: WideString;
        ClaimSectionCode: WideString;
        ClaimSectionName: WideString;
        ClaimSnm: WideString;
        CollectCond: LongInt;
        CollectMoneyCode: LongInt;
        CollectMoneyDay: LongInt;
        CollectMoneyName: WideString;
        CollectSight: LongInt;
        ConsTaxLayMethod: LongInt;
        CorporateDivCode: LongInt;
        CreateDateTime: Int64;
        CreateDateTimeAdFormal: WideString;
        CreateDateTimeAdInFormal: WideString;
        CreateDateTimeJpFormal: WideString;
        CreateDateTimeJpInFormal: WideString;
        CreditMngCode: LongInt;
        CustAgentChgDate: Int64;
        CustAnalysCode1: LongInt;
        CustAnalysCode2: LongInt;
        CustAnalysCode3: LongInt;
        CustAnalysCode4: LongInt;
        CustAnalysCode5: LongInt;
        CustAnalysCode6: LongInt;
        CustCTaXLayRefCd: LongInt;
        CustomerAgent: WideString;
        CustomerAgentCd: WideString;
        CustomerAgentNm: WideString;
        CustomerAttributeDiv: LongInt;
        CustomerCode: LongInt;
        CustomerEpCode: WideString;
        CustomerSecCode: WideString;
        CustomerSlipNoDiv: LongInt;
        CustomerSnm: WideString;
        CustomerSubCode: WideString;
        CustSlipNoMngCd: LongInt;
        CustWarehouseCd: WideString;
        CustWarehouseName: WideString;
        DefSalesSlipCd: LongInt;
        DeliHonorificTtl: WideString;
        DeliHonorTtlPrtDiv: LongInt;
        DeliPartsNoPrtCd: LongInt;
        DepoBankCode: LongInt;
        DepoBankName: WideString;
        DepoDelCode: LongInt;
        DmOutCode: LongInt;
        DmOutName: WideString;
        EnterpriseCode: WideString;
        EnterpriseName: WideString;
        EstimatePrtDiv: LongInt;
        EstmHonorificTtl: WideString;
        EstmHonorTtlPrtDiv: LongInt;
        GuidFileHeaderGuid: array [0 .. 15] of AnsiChar;
        HomeFaxNo: WideString;
        HomeFaxNoDspName: WideString;
        HomeTelNo: WideString;
        HomeTelNoDspName: WideString;
        HonorificTitle: WideString;
        InpSectionCode: WideString;
        InpSectionName: WideString;
        IsCustomer: Boolean;
        IsReceiver: Boolean;
        JobTypeCode: LongInt;
        JobTypeName: WideString;
        Kana: WideString;
        LavorRateRank: LongInt;
        LogicalDeleteCode: LongInt;
        MailAddress1: WideString;
        MailAddress2: WideString;
        MailAddrKindCode1: LongInt;
        MailAddrKindCode2: LongInt;
        MailAddrKindName1: WideString;
        MailAddrKindName2: WideString;
        MailSendCode1: LongInt;
        MailSendCode2: LongInt;
        MailSendName1: WideString;
        MailSendName2: WideString;
        MainContactCode: LongInt;
        MainContactName: WideString;
        MainSendMailAddrCd: LongInt;
        MngSectionCode: WideString;
        MngSectionName: WideString;
        MobileTelNoDspName: WideString;
        Name: WideString;
        Name2: WideString;
        Note1: WideString;
        Note10: WideString;
        Note2: WideString;
        Note3: WideString;
        Note4: WideString;
        Note5: WideString;
        Note6: WideString;
        Note7: WideString;
        Note8: WideString;
        Note9: WideString;
        NTimeCalcStDate: LongInt;
        OfficeFaxNo: WideString;
        OfficeFaxNoDspName: WideString;
        OfficeTelNo: WideString;
        OfficeTelNoDspName: WideString;
        OldCustomerAgentCd: WideString;
        OldCustomerAgentNm: WideString;
        OnlineKindDiv: LongInt;
        OthersTelNo: WideString;
        OtherTelNoDspName: WideString;
        OutputName: WideString;
        OutputNameCode: LongInt;
        PortableTelNo: WideString;
        PostNo: WideString;
        PrslOrCorpDivNm: WideString;
        PureCode: LongInt;
        QrcodePrtCd: LongInt;
        ReceiptOutputCode: LongInt;
        RectHonorificTtl: WideString;
        RectHonorTtlPrtDiv: LongInt;
        SalesAreaCode: LongInt;
        SalesAreaName: WideString;
        SalesCnsTaxFrcProcCd: LongInt;
        SalesMoneyFrcProcCd: LongInt;
        SalesSlipPrtDiv: LongInt;
        SalesUnPrcFrcProcCd: LongInt;
        SearchTelNo: WideString;
        ShipmSlipPrtDiv: LongInt;
        SlipTtlPrn: LongInt;
        TotalAmntDspWayRef: LongInt;
        TotalAmountDispWayCd: LongInt;
        TotalDay: LongInt;
        TransStopDate: Int64;
        UOESlipPrtDiv: LongInt;
        UpdAssemblyId1: WideString;
        UpdAssemblyId2: WideString;
        UpdateDateTime: Int64;
        UpdateDateTimeAdFormal: WideString;
        UpdateDateTimeAdInFormal: WideString;
        UpdateDateTimeJpFormal: WideString;
        UpdateDateTimeJpInFormal: WideString;
        UpdEmployeeCode: WideString;
        UpdEmployeeName: WideString;
    end;
    // add by gaofeng end

    //�֐��^��`

    // add by Zhangkai start
    //���㖾�׃f�[�^�f�[�^�\����
    TSalesDetail = packed record
        AcptAnOdrStatus: LongInt;    //�󒍃X�e�[�^�X
        SalesSlipNum: WideString;    //����`�[�ԍ�
        SalesRowNo: LongInt;    //����s�ԍ�
        SalesRowDerivNo: LongInt;    //����s�ԍ��}��
        SectionCode: WideString;    //���_�R�[�h
        SubSectionCode: LongInt;    //����R�[�h
        SalesDate: LongInt;    //������t
        CommonSeqNo: Int64;    //���ʒʔ�
        SalesSlipDtlNum: Int64;    //���㖾�גʔ�
        AcptAnOdrStatusSrc: LongInt;    //�󒍃X�e�[�^�X�i���j
        SalesSlipDtlNumSrc: Int64;    //���㖾�גʔԁi���j
        SupplierFormalSync: LongInt;    //�d���`���i�����j
        StockSlipDtlNumSync: Int64;    //�d�����גʔԁi�����j
        SalesSlipCdDtl: LongInt;    //����`�[�敪�i���ׁj
        //DeliGdsCmpltDueDate: Int64;    //�[�i�����\���// DEL 2010/07/01
        DeliGdsCmpltDueDate: WideString;    //�[�i�����\���// ADD 2010/07/01
        GoodsKindCode: LongInt;    //���i����
        GoodsSearchDivCd: LongInt;    //���i�����敪
        GoodsMakerCd: LongInt;    //���i���[�J�[�R�[�h
        MakerName: WideString;    //���[�J�[����
        MakerKanaName: WideString;    //���[�J�[�J�i����
        GoodsNo: WideString;    //���i�ԍ�
        GoodsName: WideString;    //���i����
        GoodsNameKana: WideString;    //���i���̃J�i
        GoodsLGroup: LongInt;    //���i�啪�ރR�[�h
        GoodsLGroupName: WideString;    //���i�啪�ޖ���
        GoodsMGroup: LongInt;    //���i�����ރR�[�h
        GoodsMGroupName: WideString;    //���i�����ޖ���
        BLGroupCode: LongInt;    //BL�O���[�v�R�[�h
        BLGroupName: WideString;    //BL�O���[�v�R�[�h����
        BLGoodsCode: LongInt;    //BL���i�R�[�h
        BLGoodsFullName: WideString;    //BL���i�R�[�h���́i�S�p�j
        EnterpriseGanreCode: LongInt;    //���Е��ރR�[�h
        EnterpriseGanreName: WideString;    //���Е��ޖ���
        WarehouseCode: WideString;    //�q�ɃR�[�h
        WarehouseName: WideString;    //�q�ɖ���
        WarehouseShelfNo: WideString;    //�q�ɒI��
        SalesOrderDivCd: LongInt;    //����݌Ɏ�񂹋敪
        OpenPriceDiv: LongInt;    //�I�[�v�����i�敪
        GoodsRateRank: WideString;    //���i�|�������N
        CustRateGrpCode: LongInt;    //���Ӑ�|���O���[�v�R�[�h
        ListPriceRate: Double;    //�艿��
        RateSectPriceUnPrc: WideString;    //�|���ݒ苒�_�i�艿�j
        RateDivLPrice: WideString;    //�|���ݒ�敪�i�艿�j
        UnPrcCalcCdLPrice: LongInt;    //�P���Z�o�敪�i�艿�j
        PriceCdLPrice: LongInt;    //���i�敪�i�艿�j
        StdUnPrcLPrice: Double;    //��P���i�艿�j
        FracProcUnitLPrice: Double;    //�[�������P�ʁi�艿�j
        FracProcLPrice: LongInt;    //�[�������i�艿�j
        ListPriceTaxIncFl: Double;    //�艿�i�ō��C�����j
        ListPriceTaxExcFl: Double;    //�艿�i�Ŕ��C�����j
        ListPriceChngCd: LongInt;    //�艿�ύX�敪
        SalesRate: Double;    //������
        RateSectSalUnPrc: WideString;    //�|���ݒ苒�_�i����P���j
        RateDivSalUnPrc: WideString;    //�|���ݒ�敪�i����P���j
        UnPrcCalcCdSalUnPrc: LongInt;    //�P���Z�o�敪�i����P���j
        PriceCdSalUnPrc: LongInt;    //���i�敪�i����P���j
        StdUnPrcSalUnPrc: Double;    //��P���i����P���j
        FracProcUnitSalUnPrc: Double;    //�[�������P�ʁi����P���j
        FracProcSalUnPrc: LongInt;    //�[�������i����P���j
        SalesUnPrcTaxIncFl: Double;    //����P���i�ō��C�����j
        SalesUnPrcTaxExcFl: Double;    //����P���i�Ŕ��C�����j
        SalesUnPrcChngCd: LongInt;    //����P���ύX�敪
        CostRate: Double;    //������
        RateSectCstUnPrc: WideString;    //�|���ݒ苒�_�i�����P���j
        RateDivUnCst: WideString;    //�|���ݒ�敪�i�����P���j
        UnPrcCalcCdUnCst: LongInt;    //�P���Z�o�敪�i�����P���j
        PriceCdUnCst: LongInt;    //���i�敪�i�����P���j
        StdUnPrcUnCst: Double;    //��P���i�����P���j
        FracProcUnitUnCst: Double;    //�[�������P�ʁi�����P���j
        FracProcUnCst: LongInt;    //�[�������i�����P���j
        SalesUnitCost: Double;    //�����P��
        SalesUnitCostChngDiv: LongInt;    //�����P���ύX�敪
        RateBLGoodsCode: LongInt;    //BL���i�R�[�h�i�|���j
        RateBLGoodsName: WideString;    //BL���i�R�[�h���́i�|���j
        RateGoodsRateGrpCd: LongInt;    //���i�|���O���[�v�R�[�h�i�|���j
        RateGoodsRateGrpNm: WideString;    //���i�|���O���[�v���́i�|���j
        RateBLGroupCode: LongInt;    //BL�O���[�v�R�[�h�i�|���j
        RateBLGroupName: WideString;    //BL�O���[�v���́i�|���j
        PrtBLGoodsCode: LongInt;    //BL���i�R�[�h�i����j
        PrtBLGoodsName: WideString;    //BL���i�R�[�h���́i����j
        SalesCode: LongInt;    //�̔��敪�R�[�h
        SalesCdNm: WideString;    //�̔��敪����
        WorkManHour: Double;    //��ƍH��
        ShipmentCnt: Double;    //�o�א�
        AcceptAnOrderCnt: Double;    //�󒍐���
        AcptAnOdrAdjustCnt: Double;    //�󒍒�����
        AcptAnOdrRemainCnt: Double;    //�󒍎c��
        RemainCntUpdDate: LongInt;    //�c���X�V��
        SalesMoneyTaxInc: Int64;    //������z�i�ō��݁j
        SalesMoneyTaxExc: Int64;    //������z�i�Ŕ����j
        Cost: Int64;    //����
        GrsProfitChkDiv: LongInt;    //�e���`�F�b�N�敪
        SalesGoodsCd: LongInt;    //���㏤�i�敪
        SalesPriceConsTax: Int64;    //������z����Ŋz
        TaxationDivCd: LongInt;    //�ېŋ敪
        PartySlipNumDtl: WideString;    //�����`�[�ԍ��i���ׁj
        DtlNote: WideString;    //���ה��l
        SupplierCd: LongInt;    //�d����R�[�h
        SupplierSnm: WideString;    //�d���旪��
        OrderNumber: WideString;    //�����ԍ�
        WayToOrder: LongInt;    //�������@
        SlipMemo1: WideString;    //�`�[�����P
        SlipMemo2: WideString;    //�`�[�����Q
        SlipMemo3: WideString;    //�`�[�����R
        InsideMemo1: WideString;    //�Г������P
        InsideMemo2: WideString;    //�Г������Q
        InsideMemo3: WideString;    //�Г������R
        BfListPrice: Double;    //�ύX�O�艿
        BfSalesUnitPrice: Double;    //�ύX�O����
        BfUnitCost: Double;    //�ύX�O����
        CmpltSalesRowNo: LongInt;    //�ꎮ���הԍ�
        CmpltGoodsMakerCd: LongInt;    //���[�J�[�R�[�h�i�ꎮ�j
        CmpltMakerName: WideString;    //���[�J�[���́i�ꎮ�j
        CmpltMakerKanaName: WideString;    //���[�J�[�J�i���́i�ꎮ�j
        CmpltGoodsName: WideString;    //���i���́i�ꎮ�j
        CmpltShipmentCnt: Double;    //���ʁi�ꎮ�j
        CmpltSalesUnPrcFl: Double;    //����P���i�ꎮ�j
        CmpltSalesMoney: Int64;    //������z�i�ꎮ�j
        CmpltSalesUnitCost: Double;    //�����P���i�ꎮ�j
        CmpltCost: Int64;    //�������z�i�ꎮ�j
        CmpltPartySalSlNum: WideString;    //�����`�[�ԍ��i�ꎮ�j
        CmpltNote: WideString;    //�ꎮ���l
        PrtGoodsNo: WideString;    //����p�i��
        PrtMakerCode: LongInt;    //����p���[�J�[�R�[�h
        PrtMakerName: WideString;    //����p���[�J�[����
        EditStatus:  LongInt;
        RowStatus:   LongInt;//�s���
        SalesMoneyInputDiv:  LongInt;//���z����͋敪
        ShipmentCntDisplay: Double; //�o�א�(�\���p)
        SupplierStockDisplay: Double; //���݌ɐ�(�\���p)
        ListPriceDisplay: Double; //�W�����i(�\���p)
        StockDate: Int64;    //�d����
        BoCode: WideString;    //BO
        SupplierCdForOrder: LongInt;    //������
        SupplierSnmForOrder: WideString;    //�����於��
        DeliveredGoodsDivNm: WideString;    //�[�i�敪
        FollowDeliGoodsDivNm: WideString;    //�g�[�i��
        UOEResvdSectionNm: WideString;    //�w�苒�_
        UOEDeliGoodsDiv: WideString;    //�[�i�敪
        FollowDeliGoodsDiv: WideString;    //�g�[�i��
        UOEResvdSection: WideString;    //�w�苒�_
        PartySalesSlipNum : WideString; //�d���`�[�ԍ�
        AcceptAnOrderNo :  LongInt; //�󒍔ԍ�
        SearchPartsModeState : LongInt; //���i�������
        //>>>2010/05/30
//        CampaignCode : Integer;
//        CampaignName : WideString;
//        GoodsDivCd : Integer;
//        AnswerDelivDate : WideString;
        RecycleDiv : Integer;
        RecycleDivNm : WideString;
//        WayToAcptOdr : Integer;
        GoodsMngNo : Integer;
//        InqRowNumber : Integer;
//        InqRowNumDerivedNo : Integer;
        //<<<2010/05/30
    end;

    //���㖾�׃f�[�^�f�[�^�|�C���^�^
    PSalesDetail = ^TSalesDetail;

    //���㖾�׃f�[�^�f�[�^�z��^
    TSalesDetailArray = array of TSalesDetail;

    TSalesSlipInputCustomArrayA2 = packed record
        Csafield1: PSalesDetail;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayA2 = ^TSalesSlipInputCustomArrayA2;

    TSalesSlipInputCustomArrayA2Array = array of TSalesSlipInputCustomArrayA2;
    // add by Zhangkai end

    // add by Lizc start
    //�J���[���f�[�^�\����
    TColorInfo = packed record
        ColorCode: WideString;    //�J���[�R�[�h
        ColorName: WideString;    //�J���[����
        MakerCode: LongInt;    //���[�J�[�R�[�h
        ModelCode: LongInt;    //�Ԏ�R�[�h
        ModelSubCode: LongInt;    //�Ԏ�T�u�R�[�h
        SelectionState: Boolean;    //�I�����
    end;

    //�J���[���f�[�^�|�C���^�^
    PColorInfo = ^TColorInfo;

    //�J���[���f�[�^�z��^
    TColorInfoArray = array of TColorInfo;

    //�g�������f�[�^�\����
    TTrimInfo = packed record
        MakerCode: LongInt;    //���[�J�[�R�[�h
        ModelCode: LongInt;    //�Ԏ�R�[�h
        ModelSubCode: LongInt;    //�Ԏ�T�u�R�[�h
        TrimCode: WideString;    //�g�����R�[�h
        TrimName: WideString;    //�g��������
        SelectionState: Boolean;    //�I�����
    end;

    //�g�������f�[�^�|�C���^�^
    PTrimInfo = ^TTrimInfo;

    //�g�������f�[�^�z��^
    TTrimInfoArray = array of TTrimInfo;

    //�������f�[�^�\����
    TCEqpDefDspInfo = packed record
        EquipmentCode: LongInt;    //xxxxxxxxxxxx
        EquipmentDispOrder: LongInt;    //xxxxxxxxxxxx
        EquipmentGenreCd: LongInt;    //xxxxxxxxxxxx
        EquipmentGenreNm: WideString;    //xxxxxxxxxxxx
        EquipmentIconCode: LongInt;    //xxxxxxxxxxxx
        EquipmentName: WideString;    //xxxxxxxxxxxx
        EquipmentShortName: WideString;    //xxxxxxxxxxxx
        MakerCode: LongInt;    //���[�J�[�R�[�h
        ModelCode: LongInt;    //�Ԏ�R�[�h
        ModelSubCode: LongInt;    //�Ԏ�T�u�R�[�h
        SelectionState: Boolean;    //�I�����
        SystematicCode: LongInt;    //xxxxxxxxxxxx
    end;

    //�������f�[�^�|�C���^�^
    PCEqpDefDspInfo = ^TCEqpDefDspInfo;

    //�������f�[�^�z��^
    TCEqpDefDspInfoArray = array of TCEqpDefDspInfo;

    //�������f�[�^�\����
    TCarSpecInfo = packed record
        ModelGradeNm: WideString;    //�O���[�h
        BodyName: WideString;    //�{�f�B
        DoorCount: LongInt;    //�h�A
        EDivNm: WideString;    //�d�敪
        EngineDisplaceNm: WideString;    //�r�C��
        EngineModelNm: WideString;    //�G���W��
        ShiftNm: WideString;    //�V�t�g
        TransmissionNm: WideString;    //�~�b�V����
        WheelDriveMethodNm: WideString;    //�쓮����
        AddiCarSpec1: WideString;    //�ǉ������P
        AddiCarSpec2: WideString;    //�ǉ������Q
        AddiCarSpec3: WideString;    //�ǉ������R
        AddiCarSpec4: WideString;    //�ǉ������S
        AddiCarSpec5: WideString;    //�ǉ������T
        AddiCarSpec6: WideString;    //�ǉ������U
    end;

    //�������f�[�^�|�C���^�^
    PCarSpecInfo = ^TCarSpecInfo;

    //�������f�[�^�z��^
    TCarSpecInfoArray = array of TCarSpecInfo;

    //�ԗ����f�[�^�\����
    TCarInfo = packed record
        CarRelationGuid: WideString;    //���Ӑ�R�[�h
        CustomerCode: LongInt;    //���Ӑ�R�[�h
        CarMngNo: LongInt;    //�ԗ��Ǘ��ԍ�
        CarMngCode: WideString;    //���q�Ǘ��R�[�h
        NumberPlate1Code: LongInt;    //���^�������ԍ�
        NumberPlate1Name: WideString;    //���^�����ǖ���
        NumberPlate2: WideString;    //�ԗ��o�^�ԍ��i��ʁj
        NumberPlate3: WideString;    //�ԗ��o�^�ԍ��i�J�i�j
        NumberPlate4: LongInt;    //�ԗ��o�^�ԍ��i�v���[�g�ԍ��j
        EntryDate: Int64;    //�o�^�N����
        FirstEntryDate: LongInt;    //���N�x
        MakerCode: LongInt;    //���[�J�[�R�[�h
        MakerFullName: WideString;    //���[�J�[�S�p����
        MakerHalfName: WideString;    //���[�J�[���p����
        ModelCode: LongInt;    //�Ԏ�R�[�h
        ModelSubCode: LongInt;    //�Ԏ�T�u�R�[�h
        ModelFullName: WideString;    //�Ԏ�S�p����
        ModelHalfName: WideString;    //�Ԏ피�p����
        SystematicCode: LongInt;    //�n���R�[�h
        SystematicName: WideString;    //�n������
        ProduceTypeOfYearCd: LongInt;    //���Y�N���R�[�h
        ProduceTypeOfYearNm: WideString;    //���Y�N������
        StProduceTypeOfYear: Int64;    //�J�n���Y�N��
        EdProduceTypeOfYear: Int64;    //�I�����Y�N��
        DoorCount: LongInt;    //�h�A��
        BodyNameCode: LongInt;    //�{�f�B�[���R�[�h
        BodyName: WideString;    //�{�f�B�[����
        ExhaustGasSign: WideString;    //�r�K�X�L��
        SeriesModel: WideString;    //�V���[�Y�^��
        CategorySignModel: WideString;    //�^���i�ޕʋL���j
        FullModel: WideString;    //�^���i�t���^�j
        ModelDesignationNo: LongInt;    //�^���w��ԍ�
        CategoryNo: LongInt;    //�ޕʔԍ�
        FrameModel: WideString;    //�ԑ�^��
        FrameNo: WideString;    //�ԑ�ԍ�
        SearchFrameNo: LongInt;    //�ԑ�ԍ��i�����p�j
        StProduceFrameNo: LongInt;    //���Y�ԑ�ԍ��J�n
        EdProduceFrameNo: LongInt;    //���Y�ԑ�ԍ��I��
        ModelGradeNm: WideString;    //�^���O���[�h����
        EngineModelNm: WideString;    //�G���W���^������
        EngineDisplaceNm: WideString;    //�r�C�ʖ���
        EDivNm: WideString;    //E�敪����
        TransmissionNm: WideString;    //�~�b�V��������
        ShiftNm: WideString;    //�V�t�g����
        WheelDriveMethodNm: WideString;    //�쓮��������
        AddiCarSpec1: WideString;    //�ǉ�����1
        AddiCarSpec2: WideString;    //�ǉ�����2
        AddiCarSpec3: WideString;    //�ǉ�����3
        AddiCarSpec4: WideString;    //�ǉ�����4
        AddiCarSpec5: WideString;    //�ǉ�����5
        AddiCarSpec6: WideString;    //�ǉ�����6
        AddiCarSpecTitle1: WideString;    //�ǉ������^�C�g��1
        AddiCarSpecTitle2: WideString;    //�ǉ������^�C�g��2
        AddiCarSpecTitle3: WideString;    //�ǉ������^�C�g��3
        AddiCarSpecTitle4: WideString;    //�ǉ������^�C�g��4
        AddiCarSpecTitle5: WideString;    //�ǉ������^�C�g��5
        AddiCarSpecTitle6: WideString;    //�ǉ������^�C�g��6
        RelevanceModel: WideString;    //�֘A�^��
        SubCarNmCd: LongInt;    //�T�u�Ԗ��R�[�h
        ModelGradeSname: WideString;    //�^���O���[�h����
        BlockIllustrationCd: LongInt;    //�u���b�N�C���X�g�R�[�h
        ThreeDIllustNo: LongInt;    //3D�C���X�gNo
        PartsDataOfferFlag: LongInt;    //���i�f�[�^�񋟃t���O
        InspectMaturityDate: Int64;    //�Ԍ�������
        LTimeCiMatDate: Int64;    //�O��Ԍ�������
        CarInspectYear: LongInt;    //�Ԍ�����
        Mileage: LongInt;    //�ԗ����s����
        CarNo: WideString;    //����
        FullModelFixedNoAry: WideString;    //�t���^���Œ�ԍ��z��
        CategoryObjAry: WideString;    //�����I�u�W�F�N�g�z��
        ProduceTypeOfYearInput: LongInt;    //���Y�N��
        ColorCode: WideString;    //�J���[�R�[�h
        ColorName1: WideString;    //�J���[����1
        TrimCode: WideString;    //�g�����R�[�h
        TrimName: WideString;    //�g��������
        AcceptAnOrderNo: LongInt;    //�󒍔ԍ�
        CarNote: WideString;    //���q���l
        CarAddInfo1: WideString;    //���q�ǉ����P
        CarAddInfo2: WideString;    //���q�ǉ����Q
        EngineModel: WideString;    //���q���l
        ProduceTypeOfYearRange: WideString;    //���Y�N��
        ProduceFrameNoRange: WideString;    //���Y�ԑ�ԍ�
        DomesticForeignCode: LongInt;    //���Y/�O�ԋ敪 // ADD 2013/03/21
        CarNoteCode: Integer;   //���q���l�R�[�h // ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218
    end;

    //�ԗ����f�[�^�|�C���^�^
    PCarInfo = ^TCarInfo;

    //�ԗ����f�[�^�z��^
    TCarInfoArray = array of TCarInfo;

    //�^���f�[�^�\����
    TCarModel = packed record
        CategorySign: WideString;    //�^���i�ޕʋL���j
        ExhaustGasSign: WideString;    //�r�K�X�L��
        FullModel: WideString;    //�^���i�t���^�j
        IsFullModel: Boolean;    //
        SeriesModel: WideString;    //�V���[�Y�^��
    end;

    //�^���f�[�^�|�C���^�^
    PCarModel = ^TCarModel;

    //�^���f�[�^�z��^
    TCarModelArray = array of TCarModel;

    //�����@�^���f�[�^�\����
    TEngineModel = packed record
        FullModel: WideString;    //�^��
        Model: WideString;    //�Ԏ�
        ModelNm: WideString;    //�Ԏ햼��
    end;

    //�����@�^���f�[�^�|�C���^�^
    PEngineModel = ^TEngineModel;

    //�����@�^���f�[�^�z��^
    TEngineModelArray = array of TEngineModel;

    //�ԗ����������f�[�^�\����
    TCarSearchCondition = packed record
        CarModel: TCarModel;    //�Ԏ�R�[�h
        CategoryNo: LongInt;    //�ޕʔԍ�
        EngineModel: TEngineModel;    //�����@�^���i�G���W���j
        EraNameDispCd1: LongInt;    //
        IsReady: Boolean;    //
        MakerCode: LongInt;    //���[�J�[�R�[�h
        ModelCode: LongInt;    //�Ԏ�R�[�h
        ModelDesignationNo: LongInt;    //�^���w��ԍ�
        ModelPlate: WideString;    //
        ModelSubCode: LongInt;    //�Ԏ�T�u�R�[�h
    end;

    //�ԗ����������f�[�^�|�C���^�^
    PCarSearchCondition = ^TCarSearchCondition;

    //�ԗ����������f�[�^�z��^
    TCarSearchConditionArray = array of TCarSearchCondition;

    TSalesSlipInputCustomArrayB4 = packed record
    Csafield1: PCEqpDefDspInfo;
    Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB4 = ^TSalesSlipInputCustomArrayB4;

    TSalesSlipInputCustomArrayB4Array = array of TSalesSlipInputCustomArrayB4;

    TSalesSlipInputCustomArrayB3 = packed record
        Csafield1: PTrimInfo;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB3 = ^TSalesSlipInputCustomArrayB3;

    TSalesSlipInputCustomArrayB3Array = array of TSalesSlipInputCustomArrayB3;

    TSalesSlipInputCustomArrayB2 = packed record
        Csafield1: PColorInfo;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB2 = ^TSalesSlipInputCustomArrayB2;

    TSalesSlipInputCustomArrayB2Array = array of TSalesSlipInputCustomArrayB2;

      // ���q���ێ��p
    BeforeCarSearchBuffer = packed record
        ProduceFrameNo          : WideString;  // �ԑ�ԍ�
        FirstEntryDate          : LongInt;     // ���Y�N��
        ColorNo                 : WideString;  // �J���[�R�[�h
        TrimNo                  : WideString;  // �g�����R�[�h
    end;

    //�w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X�f�[�^�\����
    THeaderFocusConstruction = packed record
        Key: WideString;    //�L�[
        Caption: WideString;    //���ڕ\������
        EnterStop: WideString;    //�ړ��L��
    end;

    //�w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X�f�[�^�|�C���^�^
    PHeaderFocusConstruction = ^THeaderFocusConstruction;

    //�w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X�f�[�^�z��^
    THeaderFocusConstructionArray = array of THeaderFocusConstruction;

    //�t�b�^���t�H�[�J�X�ړ��ݒ�N���X�f�[�^�\����
    TFooterFocusConstruction = packed record
        Key: WideString;    //�L�[
        Caption: WideString;    //���ڕ\������
        EnterStop: WideString;    //�ړ��L��
    end;

    //�t�b�^���t�H�[�J�X�ړ��ݒ�N���X�f�[�^�|�C���^�^
    PFooterFocusConstruction = ^TFooterFocusConstruction;

    //�t�b�^���t�H�[�J�X�ړ��ݒ�N���X�f�[�^�z��^
    TFooterFocusConstructionArray = array of TFooterFocusConstruction;

    TSalesSlipInputCustomArrayB6 = packed record
        Csafield1: PFooterFocusConstruction;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB6 = ^TSalesSlipInputCustomArrayB6;

    TSalesSlipInputCustomArrayB6Array = array of TSalesSlipInputCustomArrayB6;

    TSalesSlipInputCustomArrayB5 = packed record
        Csafield1: PHeaderFocusConstruction;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB5 = ^TSalesSlipInputCustomArrayB5;

    TSalesSlipInputCustomArrayB5Array = array of TSalesSlipInputCustomArrayB5;
    // add by Lizc end

    // add by Yangmj start

    // add by Yangmj end

    // add by Tanhong start
    //�I�v�V������񏈗��֐���`
    TxMAHNB01012B_GetSettingOptionInfo = function(var optCarMng: Integer;
    var optStockingPayment: Integer)
    : Integer; stdcall;

    // add by Tanhong end

    //�֐��^��`

    // add by gaofeng start
    //���_�K�C�h�����֐���`
    TxMAHNB01012B_sectionGuide = function(enterpriseCode: WideString;
    formName: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //����K�C�h�����֐���`
    TxMAHNB01012B_subSectionGuide = function(enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //�]�ƈ��K�C�h�����֐���`
    TxMAHNB01012B_employeeGuide = function(sender: WideString;
    enterpriseCode: WideString;
    salesInputNm: WideString;
    salesInputCode: WideString;
    var salesSlip: TSalesSlip;
    var isReInputErr: Boolean)
    : Integer; stdcall;

    //�Ǘ��ԍ��K�C�h�����֐���`
    TxMAHNB01012B_carMngNoGuide = function(customerCode: Integer;
    enterpriseCode: WideString;
    var selectedInfo: TCarMangInputExtraInfo;
    var resultStatus: Integer;
    salesRowNo: Integer;
    carMngCode: string)
    : Integer; stdcall;

    //�Ԏ�K�C�h�����֐���`
    TxMAHNB01012B_modelFullGuide = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var modelNameU: TModelNameU)
    : Integer; stdcall;

    //���l�K�C�h�{�^�������֐���`
    TxMAHNB01012B_slipNote = function(sender: WideString;
    enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //���Z�菈���֐���`
    TxMAHNB01012B_GetRate = function(numerator: Double;
    denominator: Double;
    var rate: Double)
    : Integer; stdcall;

    // --- ADD 2010/05/31 ---------->>>>>
    //CalculationSalesPrice�֐���`
    TxMAHNB01012B_CalculationSalesPrice = function()
    : Integer; stdcall;
    // --- ADD 2010/05/31 ----------<<<<<
    // add by gaofeng end

    // add by Zhangkai start


    // add by Zhangkai end

    // add by Lizc start
    //�ԗ����������֐���`
    TxMAHNB01012B_CarSearch = function(condition: TCarSearchCondition;
    salesRowNo: Integer;
    conditionType: Integer)
    : Integer; stdcall;

    //�ԗ����s�I�u�W�F�N�g�擾�֐���`
    TxMAHNB01012B_GetCarInfoRow = function(salesRowNo: Integer;
    getCarInfoMode: Integer;
    var carInfo: TCarInfo)
    : Integer; stdcall;

    //�J���[���擾�����֐���`
    TxMAHNB01012B_GetColorInfo = function(carRelationGuid: WideString;
    var colorInfoList: TSalesSlipInputCustomArrayB2)
    : Integer; stdcall;

    //�I���J���[���擾�����֐���`
    TxMAHNB01012B_GetSelectColorInfo = function(carRelationGuid: WideString;
    var colorInfo: TColorInfo)
    : Integer; stdcall;

    //�g�������擾�����֐���`
    TxMAHNB01012B_GetTrimInfo = function(carRelationGuid: WideString;
    var trimInfoList: TSalesSlipInputCustomArrayB3)
    : Integer; stdcall;

    //�I���g�������擾�����֐���`
    TxMAHNB01012B_GetSelectTrimInfo = function(carRelationGuid: WideString;
    var trimInfo: TTrimInfo)
    : Integer; stdcall;

    //�������擾�����֐���`
    TxMAHNB01012B_GetEquipInfo = function(carRelationGuid: WideString;
    var cEqpDefDspInfoList: TSalesSlipInputCustomArrayB4)
    : Integer; stdcall;

    //�J���[���I�������֐���`
    TxMAHNB01012B_SelectColorInfo = function(carRelationGuid: WideString;
    colorCode: WideString)
    : Boolean; stdcall;

    //�g�������I�������֐���`
    TxMAHNB01012B_SelectTrimInfo = function(carRelationGuid: WideString;
    trimCode: WideString)
    : Boolean; stdcall;

    //���Y�N���͈̓`�F�b�N�֐���`
    TxMAHNB01012B_CheckProduceTypeOfYearRange = function(carRelationGuid: WideString;
    firstEntryDate: Integer)
    : Integer; stdcall;

    //�ԗ������f�[�^�e�[�u���N���ݒ菈���֐���`
    TxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate = function(carRelationGuid: WideString;
    firstEntryDate: WideString)
    : Integer; stdcall;

    //�ԑ�ԍ��͈̓`�F�b�N�֐���`
    TxMAHNB01012B_CheckProduceFrameNo = function(carRelationGuid: WideString;
    inputFrameNo: WideString;
    searchFrameNo: Integer)
    : Integer; stdcall;

    //�ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈���֐���`
    TxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo = function(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;

    //�Ώ۔N���擾����(�ԑ�ԍ����擾)�֐���`
    TxMAHNB01012B_GetProduceTypeOfYear = function(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;

    //�ԗ����e�[�u���̃N���A�֐���`
    TxMAHNB01012B_ClearCarInfoRow = function(salesRowNo: Integer)
    : Integer; stdcall;

    //�ԗ����e�[�u���s�̔N���Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate = function(salesRowNo: Integer;
    firstEntryDate: Integer)
    : Integer; stdcall;

    //�ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromFrameNo = function(salesRowNo: Integer;
    frameNo: WideString)
    : Integer; stdcall;

    //�ԗ����e�[�u���s�̎Ԏ���Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromModelInfo = function(salesRowNo: Integer;
    makerCode: Integer;
    makerFullName: WideString;
    makerHalfName: WideString;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    modelHalfName: WideString)
    : Integer; stdcall;

    //�Ԏ햼�̎擾�����֐���`
    TxMAHNB01012B_GetModelFullName = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;

    //�Ԏ피�p���̎擾�����֐���`
    TxMAHNB01012B_GetModelHalfName = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;

    //�ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromCarMngCode = function(salesRowNo: Integer;
    carMngCode: WideString)
    : Integer; stdcall;

    //�ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo = function(salesRowNo: Integer;
    modelDesignationNo: Integer;
    categoryNo: Integer)
    : Integer; stdcall;

    //�ԗ����e�[�u���s�̌^���Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromFullModel = function(salesRowNo: Integer;
    fullModel: WideString)
    : Integer; stdcall;

    //�ԗ����e�[�u���s�̃G���W���^���Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromEngineModelNm = function(salesRowNo: Integer;
    engineModelNm: WideString)
    : Integer; stdcall;

    //�ԗ���񑶍݃`�F�b�N�֐���`
    TxMAHNB01012B_ExistCarInfo = function()
    : Integer; stdcall;

    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------>>>>>
    //�ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromCarNoteCode = function(salesRowNo: Integer; carNoteCode: Integer) : Integer; stdcall;
    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------<<<<<

    //�ԗ����e�[�u���s�̎��q���l�Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromCarNote = function(salesRowNo: Integer;
    carNote: WideString)
    : Integer; stdcall;

    //�ԗ����e�[�u���s�̎��q���s�����Z�b�g�֐���`
    TxMAHNB01012B_SettingCarInfoRowFromMileage = function(salesRowNo: Integer;
    mileage: Integer)
    : Integer; stdcall;

    //�J�[���[�J�[�R�[�h�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterMakerCodeFocus = function(makerCode: Integer;
    salesRowNo: Integer;
    var makerName: WideString)
    : Integer; stdcall;

    //�Ԏ�R�[�h�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterModelCodeFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;

    //�Ԏ�ď̃R�[�h�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterModelSubCodeFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;

    //�Ԏ햼�̂̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterModelFullNameFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    salesRowNo: Integer)
    : Integer; stdcall;

    //�N���̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterFirstEntryDateFocus = function(firstEntryDate: Integer;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;

    //�ԑ�ԍ��̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterProduceFrameNoFocus = function(produceFrameNo: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean;
    mode : Integer)
    : Integer; stdcall;

    //�ǉ����^�u����Visible�ݒ�֐���`
    TxMAHNB01012B_SettingAddInfoVisible = function(customerCode: Integer;
    carMngCode: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;

    //�Ԏ�ύX�{�^��Visible�֐���`
    TxMAHNB01012B_GetChangeCarInfoVisible = function(customerCode: Integer;
    carMngCode: WideString;
    var visibleFlag: Integer)
    : Integer; stdcall;

    //�Ǘ��ԍ��̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterCarMngCodeFocus = function(carMngCode: WideString;
    customerCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var selectedInfo: TCarMangInputExtraInfo;
    var returnFlag: Boolean;
    var clearCarInfoFlag: Boolean)
    : Integer; stdcall;

    //���_�R�[�h�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterSectionCodeFocus = function(sectionCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //���喼�̎擾�����֐���`
    TxMAHNB01012B_GetNameFromSubSection = function(subSectionCode: Integer;
    var subSectionNm: WideString)
    : Integer; stdcall;

    //�S���ҕύX�����֐���`
    TxMAHNB01012B_ChangeSalesEmployee = function(var salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var canChangeFocus: Boolean)
    : Integer; stdcall;

    //�󒍎ҕύX�����֐���`
    TxMAHNB01012B_ChangeFrontEmployee = function(var salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var canChangeFocus: Boolean)
    : Integer; stdcall;

    //���s�ҕύX�����֐���`
    TxMAHNB01012B_ChangeSalesInput = function(var salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var canChangeFocus: Boolean)
    : Integer; stdcall;

    //�`�[�敪�ύX�����֐���`
    TxMAHNB01012B_ChangeSalesSlip = function(var salesSlip: TSalesSlip;
    isCache: Boolean;
    code: Integer;
    var changeSalesSlipDisplay: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;

    //���i�敪�ύX�����֐���`
    TxMAHNB01012B_ChangeSalesGoodsCd = function(salesSlipCurrent: TSalesSlip;
    code: Integer;
    var changeSalesGoodsCd: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;

    //���Ӑ�R�[�h�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterCustomerCodeFocus = function(var salesSlip: TSalesSlip;
    code: Integer;
    var customerInfo: TCustomerInfo;
    var clearAddCarInfo: Boolean;
    var canChangeFocus: Boolean;
    var reCalcSalesPrice: Boolean;
    var guideStart: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean;
    var reCalcSalesUnitPrice: Boolean;
    var clearRateInfo: Boolean)
    : Integer; stdcall;

    //�`�[�ԍ��̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterSalesSlipNumFocus = function(var salesSlip: TSalesSlip;
    var salesSlipCurrent: TSalesSlip;
    code: WideString;
    enterpriseCode: WideString;
    var equelFlag: Boolean;
    var readDBDatStatus: Integer;
    var reCalcSalesPrice: Boolean;
    var deleteEmptyRow: Boolean;
    var findDataFlg: Boolean)   // ADD 2010/07/01
    : Integer; stdcall;

    //�󒍃X�e�[�^�X���X�g�쐬�֐���`
    TxMAHNB01012B_SetStateList = function()
    : Integer; stdcall;

    //������̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterSalesDateFocus = function(var salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    salesDate: Int64;
    salesDateText: WideString;
    var reCalcSalesUnitPrice: Boolean;
    var reCalcSalesPrice: Boolean;
    var taxRate: Double;
    var reCanChangeFocus: Boolean)// ADD K2011/08/12
    : Integer; stdcall;

    //�[����R�[�h�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterAddresseeCodeFocue = function(var salesSlip: TSalesSlip;
    code: Integer;
    enterpriseCode: WideString;
    var reCalcSalesPrice: Boolean)
    : Integer; stdcall;

    //����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B�֐���`
    TxMAHNB01012B_CacheForChange = function(salesSlip: TSalesSlip)
    : Integer; stdcall;

    //��������̓��e�Ɣ�r�֐���`
    TxMAHNB01012B_CompareSalesSlip = function(salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var compareRes: Boolean)
    : Integer; stdcall;

    //����P���Čv�Z�֐���`
    TxMAHNB01012B_ReCalcSalesUnitPrice = function(var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //�|�����N���A�����i�S�āj�֐���`
    TxMAHNB01012B_ClearAllRateInfo = function()
    : Integer; stdcall;

    //���l�P�R�[�h�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterSlipNoteCodeFocus = function(var salesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;

    //���l�Q�R�[�h�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterSlipNote2CodeFocus = function(var salesSlip: TSalesSlip;
    value: Integer;
    var reCanChangeFocus: Boolean)// ADD K2011/08/12
    : Integer; stdcall;

    // ----- ADD K2011/08/12 --------------------------->>>>>
    //���l�Q�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterSlipNote2Focus = function(salesSlip: TSalesSlip;
    slipNote2: WideString;
    var reCanChangeFocus: Boolean)
    : Integer; stdcall;
    // ----- ADD K2011/08/12 ---------------------------<<<<<

    //���l�R�R�[�h�̃t�H�[�J�X�����֐���`
    TxMAHNB01012B_AfterSlipNote3CodeFocus = function(var salesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;

    //����f�[�^�����֐���`
    TxMAHNB01012B_GetSalesSlip = function(var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //������m�F�{�^���N���b�N�֐���`
    TxMAHNB01012B_CustomerClaimConfirmationClick = function(salesDate: Int64;
    var focus: WideString)
    : Integer; stdcall;

    //�[����m�F�{�^���N���b�N�֐���`
    TxMAHNB01012B_AddresseeConfirmationClick = function(var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //���㖾�׃f�[�^�̑��݃`�F�b�N�֐���`
    TxMAHNB01012B_ExistSalesDetail = function(var exist: Boolean)
    : Integer; stdcall;

    //����`���ύX�\�`�F�b�N�����֐���`
    TxMAHNB01012B_ChangeCheckAcptAnOdrStatus = function(code: Integer;
    salesSlip: TSalesSlip;
    var clearDisplayCarInfo: Boolean;
    var clearAddUpInfo: Boolean;
    var result: Boolean)
    : Integer; stdcall;

    //����`���ύX�\�����֐���`
    TxMAHNB01012B_ChangeAcptAnOdrStatus = function(code: Integer;
    var salesSlip: TSalesSlip;
    svCode: Integer)
    : Integer; stdcall;

    //����f�[�^�L���b�V�������֐���`
    TxMAHNB01012B_Cache = function(salesSlip: TSalesSlip)
    : Integer; stdcall;

    //�\���p�`�[�敪���A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂��֐���`
    TxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay = function(var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //�������I�������֐���`
    TxMAHNB01012B_SelectEquipInfo = function(carRelationGuid: WideString;
    equipmentGenreCd: WideString;
    equipmentName: WideString)
    : Integer; stdcall;

    //�f�[�^�ύX�t���O�̐ݒ菈���֐���`
    TxMAHNB01012B_SetGetIsDataChanged = function(flag: Integer;
    var isDataChanged: Boolean)
    : Integer; stdcall;

    //�w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐���`
    TxMAHNB01012B_GetHeaderFocusConstructionListValue = function(var headerFocusConstructionList: TSalesSlipInputCustomArrayB5;
    var footerFocusConstructionList: TSalesSlipInputCustomArrayB6)
    : Integer; stdcall;

    //�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐���`
    TxMAHNB01012B_GetFocusConstructionValue = function(var headerList: WideString;
    var footerList: WideString)
    : Integer; stdcall;

    //���_���̂̎捞�����֐���`
    TxMAHNB01012B_GetSectionNm = function(section: WideString;
    var sectionName: WideString)
    : Integer; stdcall;
    
    // --- ADD 2010/07/16 ---------->>>>>
    //�ԗ������敪�̎捞�����֐���`
    TxMAHNB01012B_SetGetSearchCarDiv = function(flag: Integer;
    var searchCarDiv: Boolean)
    : Integer; stdcall;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start

    //�c�[���`�b�v���������֐���`
    TxMAHNB01012B_CreateStockCountInfoString = function(salesRowNo: Integer;
    var StockCountInfo: WideString)
    : Integer; stdcall;

    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    // ���[���p�����f�[�^��������
    // public void MakeMailDefaultData(out string fileName)
    TxMAHNB01012B_MakeMailDefaultData = procedure( var fileName: WideString ) stdcall;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //RC�A�g **�A�g�t�H���_�ɑ΂��ACSV�o�͂��s���܂��B
    TxMAHNB01012B_CopyToRC = function(salesRowNo: Integer) : Integer; stdcall;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// ADD 2012/02/09 ����� Redmine#28289 --- >>>>>
    //������t���O�̎捞�����֐���`
    TxMAHNB01012B_GetPrintThreadOverFlag = function(var printThreadOverFlag: Boolean)
    : Integer; stdcall;
// ADD 2012/02/09 ����� Redmine#28289 --- <<<<

    // --- ADD 2013/03/21 ---------->>>>>
    //�n���h���ʒu�`�F�b�N�����֐���`
    TxMAHNB01012B_CheckHandlePosition = function(carRelationGuid: WideString;
    vinCode: WideString)
    : Boolean; stdcall;
    // --- ADD 2013/03/21 ----------<<<<<

// �Ăяo���o�f�͈ȉ��̊֐����o�f�̊J�n�ƏI���ɌĂт܂��B
function LoadLibraryMAHNB01012B(HDllCALL1: THDLLCALL): Integer;
procedure FreeLibraryMAHNB01012B(HDllCALL1: THDLLCALL);
//procedure ClearTSalesSlipSearchResult(var h_SalesSlipSearchResult: TSalesSlipSearchResult);
//procedure ClearTCustomerSearchRet(var h_CustomerSearchRet: TCustomerSearchRet);

    // add by Zhangkai start
procedure ClearTSalesDetail(var h_SalesDetail: TSalesDetail);
    // add by Zhangkai end

    // add by Lizc start
procedure ClearTColorInfo(var h_ColorInfo: TColorInfo);
procedure ClearTTrimInfo(var h_TrimInfo: TTrimInfo);
procedure ClearTCEqpDefDspInfo(var h_CEqpDefDspInfo: TCEqpDefDspInfo);
procedure ClearTCarSpecInfo(var h_CarSpecInfo: TCarSpecInfo);
procedure ClearTCarInfo(var h_CarInfo: TCarInfo);
procedure ClearTCarModel(var h_CarModel: TCarModel);
procedure ClearTEngineModel(var h_EngineModel: TEngineModel);
procedure ClearTCarSearchCondition(var h_CarSearchCondition: TCarSearchCondition);
// add by gaofeng start
procedure ClearTSalesSlip(var h_SalesSlip: TSalesSlip);
procedure ClearTCarMangInputExtraInfo(var h_CarMangInputExtraInfo: TCarMangInputExtraInfo);
procedure ClearTModelNameU(var h_ModelNameU: TModelNameU);
procedure ClearTUserGdHd(var h_UserGdHd: TUserGdHd);
procedure ClearTUserGdBd(var h_UserGdBd: TUserGdBd);
// add by gaofeng end
procedure ClearBeforeCarSearchBuffer(var h_BeforeCarSearchBuffer: BeforeCarSearchBuffer);
procedure ClearTCustomerInfo(var h_CustomerInfo: TCustomerInfo);
procedure ClearTHeaderFocusConstruction(var h_HeaderFocusConstruction: THeaderFocusConstruction);
procedure ClearTFooterFocusConstruction(var h_FooterFocusConstruction: TFooterFocusConstruction);
    // add by Lizc end

    // add by Yangmj start

    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

var
    //�֐��|�C���^�錾

    // add by gaofeng start
    //�֐��|�C���^�錾
    gpxMAHNB01012B_sectionGuide : TxMAHNB01012B_sectionGuide;
    gpxMAHNB01012B_subSectionGuide : TxMAHNB01012B_subSectionGuide;
    gpxMAHNB01012B_employeeGuide : TxMAHNB01012B_employeeGuide;
    gpxMAHNB01012B_carMngNoGuide : TxMAHNB01012B_carMngNoGuide;
    gpxMAHNB01012B_modelFullGuide : TxMAHNB01012B_modelFullGuide;
    gpxMAHNB01012B_slipNote : TxMAHNB01012B_slipNote;
    gpxMAHNB01012B_GetRate : TxMAHNB01012B_GetRate;
    // --- ADD 2010/05/31 ---------->>>>>
    gpxMAHNB01012B_CalculationSalesPrice : TxMAHNB01012B_CalculationSalesPrice;
    // --- ADD 2010/05/31 ----------<<<<<
    // add by gaofeng end

    // add by Zhangkai start
    // add by Zhangkai end

    // add by Lizc start
    gpxMAHNB01012B_CarSearch : TxMAHNB01012B_CarSearch;
    gpxMAHNB01012B_GetCarInfoRow : TxMAHNB01012B_GetCarInfoRow;
    gpxMAHNB01012B_GetColorInfo : TxMAHNB01012B_GetColorInfo;
    gpxMAHNB01012B_GetSelectColorInfo : TxMAHNB01012B_GetSelectColorInfo;
    gpxMAHNB01012B_GetTrimInfo : TxMAHNB01012B_GetTrimInfo;
    gpxMAHNB01012B_GetSelectTrimInfo : TxMAHNB01012B_GetSelectTrimInfo;
    gpxMAHNB01012B_GetEquipInfo : TxMAHNB01012B_GetEquipInfo;
    gpxMAHNB01012B_SelectColorInfo : TxMAHNB01012B_SelectColorInfo;
    gpxMAHNB01012B_SelectTrimInfo : TxMAHNB01012B_SelectTrimInfo;
    gpxMAHNB01012B_CheckProduceTypeOfYearRange : TxMAHNB01012B_CheckProduceTypeOfYearRange;
    gpxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate : TxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate;
    gpxMAHNB01012B_CheckProduceFrameNo : TxMAHNB01012B_CheckProduceFrameNo;
    gpxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo : TxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo;
    gpxMAHNB01012B_GetProduceTypeOfYear : TxMAHNB01012B_GetProduceTypeOfYear;
    gpxMAHNB01012B_ClearCarInfoRow : TxMAHNB01012B_ClearCarInfoRow;
    gpxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate : TxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate;
    gpxMAHNB01012B_SettingCarInfoRowFromFrameNo : TxMAHNB01012B_SettingCarInfoRowFromFrameNo;
    gpxMAHNB01012B_SettingCarInfoRowFromModelInfo : TxMAHNB01012B_SettingCarInfoRowFromModelInfo;
    gpxMAHNB01012B_GetModelFullName : TxMAHNB01012B_GetModelFullName;
    gpxMAHNB01012B_GetModelHalfName : TxMAHNB01012B_GetModelHalfName;
    gpxMAHNB01012B_SettingCarInfoRowFromCarMngCode : TxMAHNB01012B_SettingCarInfoRowFromCarMngCode;
    gpxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo : TxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo;
    gpxMAHNB01012B_SettingCarInfoRowFromFullModel : TxMAHNB01012B_SettingCarInfoRowFromFullModel;
    gpxMAHNB01012B_SettingCarInfoRowFromEngineModelNm : TxMAHNB01012B_SettingCarInfoRowFromEngineModelNm;
    gpxMAHNB01012B_ExistCarInfo : TxMAHNB01012B_ExistCarInfo;
    gpxMAHNB01012B_SettingCarInfoRowFromCarNoteCode : TxMAHNB01012B_SettingCarInfoRowFromCarNoteCode; // ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218
    gpxMAHNB01012B_SettingCarInfoRowFromCarNote : TxMAHNB01012B_SettingCarInfoRowFromCarNote;
    gpxMAHNB01012B_SettingCarInfoRowFromMileage : TxMAHNB01012B_SettingCarInfoRowFromMileage;
    gpxMAHNB01012B_AfterMakerCodeFocus : TxMAHNB01012B_AfterMakerCodeFocus;
    gpxMAHNB01012B_AfterModelCodeFocus : TxMAHNB01012B_AfterModelCodeFocus;
    gpxMAHNB01012B_AfterModelSubCodeFocus : TxMAHNB01012B_AfterModelSubCodeFocus;
    gpxMAHNB01012B_AfterModelFullNameFocus : TxMAHNB01012B_AfterModelFullNameFocus;
    gpxMAHNB01012B_AfterFirstEntryDateFocus : TxMAHNB01012B_AfterFirstEntryDateFocus;
    gpxMAHNB01012B_AfterProduceFrameNoFocus : TxMAHNB01012B_AfterProduceFrameNoFocus;
    gpxMAHNB01012B_SettingAddInfoVisible : TxMAHNB01012B_SettingAddInfoVisible;
    gpxMAHNB01012B_GetChangeCarInfoVisible : TxMAHNB01012B_GetChangeCarInfoVisible;
    gpxMAHNB01012B_AfterCarMngCodeFocus : TxMAHNB01012B_AfterCarMngCodeFocus;
    gpxMAHNB01012B_AfterSectionCodeFocus : TxMAHNB01012B_AfterSectionCodeFocus;
    gpxMAHNB01012B_GetNameFromSubSection : TxMAHNB01012B_GetNameFromSubSection;
    gpxMAHNB01012B_ChangeSalesEmployee : TxMAHNB01012B_ChangeSalesEmployee;
    gpxMAHNB01012B_ChangeFrontEmployee : TxMAHNB01012B_ChangeFrontEmployee;
    gpxMAHNB01012B_ChangeSalesInput : TxMAHNB01012B_ChangeSalesInput;
    gpxMAHNB01012B_ChangeSalesSlip : TxMAHNB01012B_ChangeSalesSlip;
    gpxMAHNB01012B_ChangeSalesGoodsCd : TxMAHNB01012B_ChangeSalesGoodsCd;
    gpxMAHNB01012B_AfterCustomerCodeFocus : TxMAHNB01012B_AfterCustomerCodeFocus;
    gpxMAHNB01012B_AfterSalesSlipNumFocus : TxMAHNB01012B_AfterSalesSlipNumFocus;
    gpxMAHNB01012B_SetStateList : TxMAHNB01012B_SetStateList;
    gpxMAHNB01012B_AfterSalesDateFocus : TxMAHNB01012B_AfterSalesDateFocus;
    gpxMAHNB01012B_AfterAddresseeCodeFocue : TxMAHNB01012B_AfterAddresseeCodeFocue;
    gpxMAHNB01012B_CacheForChange : TxMAHNB01012B_CacheForChange;
    gpxMAHNB01012B_CompareSalesSlip : TxMAHNB01012B_CompareSalesSlip;
    gpxMAHNB01012B_ReCalcSalesUnitPrice : TxMAHNB01012B_ReCalcSalesUnitPrice;
    gpxMAHNB01012B_ClearAllRateInfo : TxMAHNB01012B_ClearAllRateInfo;
    gpxMAHNB01012B_AfterSlipNoteCodeFocus : TxMAHNB01012B_AfterSlipNoteCodeFocus;
    gpxMAHNB01012B_AfterSlipNote2CodeFocus : TxMAHNB01012B_AfterSlipNote2CodeFocus;
    gpxMAHNB01012B_AfterSlipNote3CodeFocus : TxMAHNB01012B_AfterSlipNote3CodeFocus;
    gpxMAHNB01012B_GetSalesSlip : TxMAHNB01012B_GetSalesSlip;
    gpxMAHNB01012B_CustomerClaimConfirmationClick : TxMAHNB01012B_CustomerClaimConfirmationClick;
    gpxMAHNB01012B_AddresseeConfirmationClick : TxMAHNB01012B_AddresseeConfirmationClick;
    gpxMAHNB01012B_ExistSalesDetail : TxMAHNB01012B_ExistSalesDetail;
    gpxMAHNB01012B_ChangeCheckAcptAnOdrStatus : TxMAHNB01012B_ChangeCheckAcptAnOdrStatus;
    gpxMAHNB01012B_ChangeAcptAnOdrStatus : TxMAHNB01012B_ChangeAcptAnOdrStatus;
    gpxMAHNB01012B_Cache : TxMAHNB01012B_Cache;
    gpxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay : TxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay;
    gpxMAHNB01012B_SelectEquipInfo : TxMAHNB01012B_SelectEquipInfo;
    gpxMAHNB01012B_SetGetIsDataChanged : TxMAHNB01012B_SetGetIsDataChanged;
    gpxMAHNB01012B_GetHeaderFocusConstructionListValue : TxMAHNB01012B_GetHeaderFocusConstructionListValue;
    gpxMAHNB01012B_GetFocusConstructionValue : TxMAHNB01012B_GetFocusConstructionValue;
    gpxMAHNB01012B_GetSectionNm : TxMAHNB01012B_GetSectionNm;
    gpxMAHNB01012B_SetGetSearchCarDiv : TxMAHNB01012B_SetGetSearchCarDiv; // ADD 2010/07/16
    gpxMAHNB01012B_AfterSlipNote2Focus : TxMAHNB01012B_AfterSlipNote2Focus; // ADD K2011/08/12
    // add by Lizc end

    // add by Yangmj start

    //�֐��|�C���^�錾
    gpxMAHNB01012B_CreateStockCountInfoString : TxMAHNB01012B_CreateStockCountInfoString;

    // add by Yangmj end

    // add by Tanhong start
    //�֐��|�C���^�錾
    gpxMAHNB01012B_GetSettingOptionInfo : TxMAHNB01012B_GetSettingOptionInfo;

    // add by Tanhong end
    gpxMAHNB01012B_CopyToRC        : TxMAHNB01012B_CopyToRC        ;            //2010/06/15 yamaji ADD

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    //�֐��|�C���^�錾
    gpxMAHNB01012B_MakeMailDefaultData : TxMAHNB01012B_MakeMailDefaultData;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    gpxMAHNB01012B_GetPrintThreadOverFlag : TxMAHNB01012B_GetPrintThreadOverFlag; //ADD 2012/02/09 ����� Redmine#28289

    // --- ADD 2013/03/21 ---------->>>>>
    gpxMAHNB01012B_CheckHandlePosition : TxMAHNB01012B_CheckHandlePosition;
    // --- ADD 2013/03/21 ----------<<<<<

implementation

// **********************************************************************//
// Module Name     :  �Ԏ핔�i���[�h�֐�                            //
// :  LoadLibraryMAHNB01012B                            //
// ����            :  �P�DHDLLCALL                                      //
// �߂�l          :  �X�e�[�^�X ctFNC_NORMAL : ����                    //
// :             ctFNC_ERROR  : ���s                    //
// Programer       :  ��������                                            //
// Date            :  2010.03.16                                          //
// Note            :  �Ԏ핔�i���[�h���܂�                          //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
function LoadLibraryMAHNB01012B(HDllCALL1: THDLLCALL): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCALL1.DllName := 'MAHNB01012B.DLL';
    nSt := HDllCALL1.HLoadLibrary;

    //DLL���[�h
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�Ԏ핔�i',
            'LoadLibraryMAHNB01012B', 'LOADLIBRARY', '�Ԏ핔�i�̃��[�h�Ɏ��s���܂���', nSt,
            nil, 0);
        Exit;
    end;

    // add by gaofeng start
    //���_�K�C�h�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_sectionGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_sectionGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '���_�K�C�h����',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '���_�K�C�h�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�I�v�V������񏈗��֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetSettingOptionInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSettingOptionInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�Ԏ핔�i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�Ԏ핔�i�I�v�V������񏈗��֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;


    //����K�C�h�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_subSectionGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_subSectionGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '����K�C�h����',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '����K�C�h���쏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�]�ƈ��K�C�h�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_employeeGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_employeeGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�]�ƈ��K�C�h����',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�]�ƈ��K�C�h���쏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ǘ��ԍ��K�C�h�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_carMngNoGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_carMngNoGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�Ǘ��ԍ��K�C�h����',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�Ǘ��ԍ��K�C�h���쏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ԏ�K�C�h�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_modelFullGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_modelFullGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�Ԏ�K�C�h����',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�Ԏ�K�C�h���쏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���l�K�C�h�{�^�������֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_slipNote';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_slipNote);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '���l�K�C�h����',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '���l�K�C�h���쏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���Z�菈���֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetRate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetRate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '���Z�菈��',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '���Z�菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2010/05/31 ---------->>>>>
    //CalculationSalesPrice�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_CalculationSalesPrice';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CalculationSalesPrice);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '������z�v�Z����',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '������z�v�Z�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by gaofeng end

    // add by Zhangkai start


    // add by Zhangkai end

    // add by Lizc start
    //�ԗ����������֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_CarSearch';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CarSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����s�I�u�W�F�N�g�擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetCarInfoRow';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetCarInfoRow);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����s�I�u�W�F�N�g�擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�J���[���擾�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetColorInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�J���[���擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�I���J���[���擾�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetSelectColorInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSelectColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�I���J���[���擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�g�������擾�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetTrimInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�g�������擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�I���g�������擾�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetSelectTrimInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSelectTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�I���g�������擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�������擾�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetEquipInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetEquipInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�������擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�J���[���I�������֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SelectColorInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SelectColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�J���[���I�������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�g�������I�������֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SelectTrimInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SelectTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�g�������I�������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���Y�N���͈̓`�F�b�N�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_CheckProduceTypeOfYearRange';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CheckProduceTypeOfYearRange);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���Y�N���͈̓`�F�b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ������f�[�^�e�[�u���N���ݒ菈���֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarModelUIDataFromFirstEntryDate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ������f�[�^�e�[�u���N���ݒ菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԑ�ԍ��͈̓`�F�b�N�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_CheckProduceFrameNo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CheckProduceFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԑ�ԍ��͈̓`�F�b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈���֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarModelUIDataFromProduceFrameNo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ������f�[�^�e�[�u���ԑ�ԍ��ݒ菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ώ۔N���擾����(�ԑ�ԍ����擾)�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetProduceTypeOfYear';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetProduceTypeOfYear);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�Ώ۔N���擾����(�ԑ�ԍ����擾)�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����e�[�u���̃N���A�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ClearCarInfoRow';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ClearCarInfoRow);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���̃N���A�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����e�[�u���s�̔N���Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromFirstEntryDate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̔N���Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromFrameNo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎ԑ�ԍ��Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����e�[�u���s�̎Ԏ���Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromModelInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromModelInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎Ԏ���Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ԏ햼�̎擾�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetModelFullName';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetModelFullName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ햼�̎擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ԏ피�p���̎擾�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetModelHalfName';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetModelHalfName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ피�p���̎擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromCarMngCode';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromCarMngCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̊Ǘ��ԍ��Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̌^���w��ԍ�����їޕʋ敪�ԍ��Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����e�[�u���s�̌^���Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromFullModel';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromFullModel);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̌^���Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����e�[�u���s�̃G���W���^���Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromEngineModelNm';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromEngineModelNm);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̃G���W���^���Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ���񑶍݃`�F�b�N�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ExistCarInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ExistCarInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ���񑶍݃`�F�b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------>>>>>
    //�ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromCarNoteCode';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromCarNoteCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎��q���l�R�[�h�Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218 ------------------------------<<<<<

    //�ԗ����e�[�u���s�̎��q���l�Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromCarNote';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromCarNote);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎��q���l�Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԗ����e�[�u���s�̎��q���s�����Z�b�g�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromMileage';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromMileage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ����e�[�u���s�̎��q���s�����Z�b�g�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�J�[���[�J�[�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterMakerCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterMakerCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�J�[���[�J�[�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ԏ�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterModelCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterModelCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ԏ�ď̃R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterModelSubCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterModelSubCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ�ď̃R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ԏ햼�̂̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterModelFullNameFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterModelFullNameFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ햼�̂̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�N���̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterFirstEntryDateFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterFirstEntryDateFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�N���̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ԑ�ԍ��̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterProduceFrameNoFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterProduceFrameNoFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԑ�ԍ��̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�ǉ����^�u����Visible�ݒ�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SettingAddInfoVisible';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingAddInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ǉ����^�u����Visible�ݒ�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ԏ�ύX�{�^��Visible�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetChangeCarInfoVisible';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetChangeCarInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�Ԏ�ύX�{�^��Visible�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�Ǘ��ԍ��̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterCarMngCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterCarMngCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�Ǘ��ԍ��̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���_�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSectionCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSectionCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���_�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���喼�̎擾�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetNameFromSubSection';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetNameFromSubSection);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���喼�̎擾�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�S���ҕύX�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeSalesEmployee';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeSalesEmployee);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�S���ҕύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�󒍎ҕύX�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeFrontEmployee';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeFrontEmployee);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�󒍎ҕύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���s�ҕύX�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeSalesInput';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeSalesInput);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���s�ҕύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�`�[�敪�ύX�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeSalesSlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�`�[�敪�ύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���i�敪�ύX�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeSalesGoodsCd';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeSalesGoodsCd);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���i�敪�ύX�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���Ӑ�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterCustomerCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterCustomerCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���Ӑ�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�`�[�ԍ��̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSalesSlipNumFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSalesSlipNumFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�`�[�ԍ��̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�󒍃X�e�[�^�X���X�g�쐬�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SetStateList';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SetStateList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�󒍃X�e�[�^�X���X�g�쐬�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSalesDateFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSalesDateFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i������̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�[����R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterAddresseeCodeFocue';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterAddresseeCodeFocue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�[����R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_CacheForChange';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CacheForChange);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i����f�[�^�I�u�W�F�N�g���C���X�^���X�ϐ��ɃL���b�V�����܂��B�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //��������̓��e�Ɣ�r�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_CompareSalesSlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CompareSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i��������̓��e�Ɣ�r�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //����P���Čv�Z�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ReCalcSalesUnitPrice';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ReCalcSalesUnitPrice);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i����P���Čv�Z�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�|�����N���A�����i�S�āj�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ClearAllRateInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ClearAllRateInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�|�����N���A�����i�S�āj�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���l�P�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSlipNoteCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSlipNoteCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���l�P�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���l�Q�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSlipNote2CodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSlipNote2CodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���l�Q�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ----- ADD K2011/08/12 --------------------------->>>>>
    //���l�Q�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSlipNote2Focus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSlipNote2Focus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���l�Q�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // ----- ADD K2011/08/12 ---------------------------<<<<<

    //���l�R�R�[�h�̃t�H�[�J�X�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSlipNote3CodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSlipNote3CodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���l�R�R�[�h�̃t�H�[�J�X�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //����f�[�^�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetSalesSlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i����f�[�^�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������m�F�{�^���N���b�N�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_CustomerClaimConfirmationClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CustomerClaimConfirmationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i������m�F�{�^���N���b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�[����m�F�{�^���N���b�N�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_AddresseeConfirmationClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AddresseeConfirmationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�[����m�F�{�^���N���b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���㖾�׃f�[�^�̑��݃`�F�b�N�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ExistSalesDetail';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ExistSalesDetail);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���㖾�׃f�[�^�̑��݃`�F�b�N�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //����`���ύX�\�`�F�b�N�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeCheckAcptAnOdrStatus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeCheckAcptAnOdrStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i����`���ύX�\�`�F�b�N�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //����`���ύX�\�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeAcptAnOdrStatus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeAcptAnOdrStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i����`���ύX�\�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //����f�[�^�L���b�V�������֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_Cache';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_Cache);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i����f�[�^�L���b�V�������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�\���p�`�[�敪���A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂��֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�A�f�[�^�p�̓`�[�敪�A���|�敪���Z�b�g���܂��֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�������I�������֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SelectEquipInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SelectEquipInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�������I�������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�f�[�^�ύX�t���O�̐ݒ菈���֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SetGetIsDataChanged';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SetGetIsDataChanged);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�f�[�^�ύX�t���O�̐ݒ菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetHeaderFocusConstructionListValue';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetHeaderFocusConstructionListValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�w�b�_�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetFocusConstructionValue';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetFocusConstructionValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�t�H�[�J�X�ݒ胊�X�g�̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���_���̂̎捞�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_GetSectionNm';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSectionNm);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i���_���̂̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    
    // --- ADD 2010/07/16 ---------->>>>>
    //�ԗ������敪�̎捞�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_SetGetSearchCarDiv';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SetGetSearchCarDiv);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�ԗ��������i�ԗ������敪�̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start

    //�c�[���`�b�v���������֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_CreateStockCountInfoString';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CreateStockCountInfoString);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�o�׏Ɖ�i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�o�׏Ɖ�i�c�[���`�b�v���������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    // ���[���p�����f�[�^��������
    HDllCALL1.ProcName := 'MAHNB01012B_MakeMailDefaultData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_MakeMailDefaultData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '���[���p�����f�[�^��������',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '���[���p�����f�[�^���������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //RC�A�g - CSV�o��
    HDllCALL1.ProcName := 'MAHNB01012B_CopyToRC';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CopyToRC);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', 'RC�A�g���i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�q�b�A�g�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//ADD 2012/02/09 ����� Redmine#28289 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //������t���O�̎捞����
    HDllCALL1.ProcName := 'MAHNB01012B_GetPrintThreadOverFlag';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetPrintThreadOverFlag);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '������t���O�̎捞����',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '������t���O�̎捞�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

//ADD 2012/02/09 ����� Redmine#28289 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    // --- ADD 2013/03/21 ---------->>>>>
    //�n���h���ʒu�`�F�b�N�����֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01012B_CheckHandlePosition';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CheckHandlePosition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '�ԗ��������i',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '�n���h���ʒu�`�F�b�N�����֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2013/03/21 ----------<<<<<

    Result := 0;

end;

// **********************************************************************//
// Module Name     :  �Ԏ핔�i�t���[�֐�                        //
// :  FreeLibraryMAHNB01012B                            //
// ����            :  �P�DHDLLCALL                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.16                                          //
// Note            :  �Ԏ핔�i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure FreeLibraryMAHNB01012B(HDllCALL1: THDLLCALL);
begin
    HDllCALL1.DllName := 'MAHNB01012B.DLL';
    HDllCALL1.HFreeLibrary;
    // add by gaofeng start
    gpxMAHNB01012B_sectionGuide := nil;
    gpxMAHNB01012B_subSectionGuide := nil;
    gpxMAHNB01012B_employeeGuide := nil;
    gpxMAHNB01012B_carMngNoGuide := nil;
    gpxMAHNB01012B_modelFullGuide := nil;
    gpxMAHNB01012B_slipNote := nil;
    gpxMAHNB01012B_GetRate := nil;
    // --- ADD 2010/05/31 ---------->>>>>
    gpxMAHNB01012B_CalculationSalesPrice := nil;
    // --- ADD 2010/05/31 ----------<<<<<
    // add by gaofeng end

    // add by Zhangkai start
    // add by Zhangkai end

    // add by Lizc start
    gpxMAHNB01012B_CarSearch := nil;
    gpxMAHNB01012B_GetCarInfoRow := nil;
    gpxMAHNB01012B_GetColorInfo := nil;
    gpxMAHNB01012B_GetSelectColorInfo := nil;
    gpxMAHNB01012B_GetTrimInfo := nil;
    gpxMAHNB01012B_GetSelectTrimInfo := nil;
    gpxMAHNB01012B_GetEquipInfo := nil;
    gpxMAHNB01012B_SelectColorInfo := nil;
    gpxMAHNB01012B_SelectTrimInfo := nil;
    gpxMAHNB01012B_CheckProduceTypeOfYearRange := nil;
    gpxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate := nil;
    gpxMAHNB01012B_CheckProduceFrameNo := nil;
    gpxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo := nil;
    gpxMAHNB01012B_GetProduceTypeOfYear := nil;
    gpxMAHNB01012B_ClearCarInfoRow := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromFrameNo := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromModelInfo := nil;
    gpxMAHNB01012B_GetModelFullName := nil;
    gpxMAHNB01012B_GetModelHalfName := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromCarMngCode := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromFullModel := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromEngineModelNm := nil;
    gpxMAHNB01012B_ExistCarInfo := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromCarNoteCode := nil; // ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218
    gpxMAHNB01012B_SettingCarInfoRowFromCarNote := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromMileage := nil;
    gpxMAHNB01012B_AfterMakerCodeFocus := nil;
    gpxMAHNB01012B_AfterModelCodeFocus := nil;
    gpxMAHNB01012B_AfterModelSubCodeFocus := nil;
    gpxMAHNB01012B_AfterModelFullNameFocus := nil;
    gpxMAHNB01012B_AfterFirstEntryDateFocus := nil;
    gpxMAHNB01012B_AfterProduceFrameNoFocus := nil;
    gpxMAHNB01012B_SettingAddInfoVisible := nil;
    gpxMAHNB01012B_GetChangeCarInfoVisible := nil;
    gpxMAHNB01012B_AfterCarMngCodeFocus := nil;
    gpxMAHNB01012B_AfterSectionCodeFocus := nil;
    gpxMAHNB01012B_GetNameFromSubSection := nil;
    gpxMAHNB01012B_ChangeSalesEmployee := nil;
    gpxMAHNB01012B_ChangeFrontEmployee := nil;
    gpxMAHNB01012B_ChangeSalesInput := nil;
    gpxMAHNB01012B_ChangeSalesSlip := nil;
    gpxMAHNB01012B_ChangeSalesGoodsCd := nil;
    gpxMAHNB01012B_AfterCustomerCodeFocus := nil;
    gpxMAHNB01012B_AfterSalesSlipNumFocus := nil;
    gpxMAHNB01012B_SetStateList := nil;
    gpxMAHNB01012B_AfterSalesDateFocus := nil;
    gpxMAHNB01012B_AfterAddresseeCodeFocue := nil;
    gpxMAHNB01012B_CompareSalesSlip := nil;
    gpxMAHNB01012B_ReCalcSalesUnitPrice := nil;
    gpxMAHNB01012B_ClearAllRateInfo := nil;
    gpxMAHNB01012B_AfterSlipNoteCodeFocus := nil;
    gpxMAHNB01012B_AfterSlipNote2CodeFocus := nil;
    gpxMAHNB01012B_AfterSlipNote3CodeFocus := nil;
    gpxMAHNB01012B_GetSalesSlip := nil;
    gpxMAHNB01012B_CustomerClaimConfirmationClick := nil;
    gpxMAHNB01012B_AddresseeConfirmationClick := nil;
    gpxMAHNB01012B_ExistSalesDetail := nil;
    gpxMAHNB01012B_ChangeCheckAcptAnOdrStatus := nil;
    gpxMAHNB01012B_ChangeAcptAnOdrStatus := nil;
    gpxMAHNB01012B_Cache := nil;
    gpxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay := nil;
    gpxMAHNB01012B_SelectEquipInfo := nil;
    gpxMAHNB01012B_SetGetIsDataChanged := nil;
    gpxMAHNB01012B_GetHeaderFocusConstructionListValue := nil;
    gpxMAHNB01012B_GetFocusConstructionValue := nil;
    gpxMAHNB01012B_GetSectionNm := nil;
    gpxMAHNB01012B_SetGetSearchCarDiv := nil; // ADD 2010/07/16
    gpxMAHNB01012B_AfterSlipNote2Focus := nil; // ADD K2011/08/12
    // add by Lizc end

    // add by Yangmj start
    gpxMAHNB01012B_CreateStockCountInfoString := nil;
    // add by Yangmj end

    // add by Tanhong start
    gpxMAHNB01012B_GetSettingOptionInfo := nil;

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    gpxMAHNB01012B_MakeMailDefaultData := nil;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    // --- ADD 2012/02/09 ����� Redmine#28289 ---------->>>>>
    gpxMAHNB01012B_GetPrintThreadOverFlag := nil;
    // --- ADD 2012/02/09 ����� Redmine#28289 ----------<<<<<

    // --- ADD 2013/03/21 ---------->>>>>
    gpxMAHNB01012B_CheckHandlePosition := nil;
    // --- ADD 2013/03/21 ----------<<<<<
end;

// add by gaofeng start
// **********************************************************************//
// Module Name     :  ���_�K�C�h���암�i�t���[�֐�                        //
// :  ClearTSalesSlip                            //
// ����            :  �P�D����f�[�^                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.04.01                                          //
// Note            :  ���_�K�C�h���암�i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTSalesSlip(var h_SalesSlip: TSalesSlip);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_SalesSlip.AcptAnOdrStatus := 0;
  h_SalesSlip.SalesSlipNum := '';
  h_SalesSlip.SectionCode := '';
  h_SalesSlip.InputMode := 0;
  h_SalesSlip.SalesSlipDisplay := 0;
  h_SalesSlip.AcptAnOdrStatusDisplay := 0;
  h_SalesSlip.CarMngDivCd := 0;
  h_SalesSlip.SubSectionCode := 0;
  h_SalesSlip.SubSectionName := '';
  h_SalesSlip.DebitNoteDiv := 0;
  h_SalesSlip.DebitNLnkSalesSlNum := '';
  h_SalesSlip.SalesSlipCd := 0;
  h_SalesSlip.SalesGoodsCd := 0;
  h_SalesSlip.AccRecDivCd := 0;
  h_SalesSlip.SalesInpSecCd := '';
  h_SalesSlip.DemandAddUpSecCd := '';
  h_SalesSlip.ResultsAddUpSecCd := '';
  h_SalesSlip.ResultsAddUpSecNm := '';
  h_SalesSlip.UpdateSecCd := '';
  h_SalesSlip.SalesSlipUpdateCd := 0;
  h_SalesSlip.SearchSlipDate := 0;
  h_SalesSlip.ShipmentDay := 0;
  h_SalesSlip.SalesDate := 0;
  h_SalesSlip.AddUpADate := 0;
  h_SalesSlip.DelayPaymentDiv := 0;
  h_SalesSlip.EstimateFormNo := '';
  h_SalesSlip.EstimateDivide := 0;
  h_SalesSlip.InputAgenCd := '';
  h_SalesSlip.InputAgenNm := '';
  h_SalesSlip.SalesInputCode := '';
  h_SalesSlip.SalesInputName := '';
  h_SalesSlip.FrontEmployeeCd := '';
  h_SalesSlip.FrontEmployeeNm := '';
  h_SalesSlip.SalesEmployeeCd := '';
  h_SalesSlip.SalesEmployeeNm := '';
  h_SalesSlip.TotalAmountDispWayCd := 0;
  h_SalesSlip.TtlAmntDispRateApy := 0;
  h_SalesSlip.SalesTotalTaxInc := 0;
  h_SalesSlip.SalesTotalTaxExc := 0;
  h_SalesSlip.SalesPrtTotalTaxInc := 0;
  h_SalesSlip.SalesPrtTotalTaxExc := 0;
  h_SalesSlip.SalesWorkTotalTaxInc := 0;
  h_SalesSlip.SalesWorkTotalTaxExc := 0;
  h_SalesSlip.SalesSubtotalTaxInc := 0;
  h_SalesSlip.SalesSubtotalTaxExc := 0;
  h_SalesSlip.SalesPrtSubttlInc := 0;
  h_SalesSlip.SalesPrtSubttlExc := 0;
  h_SalesSlip.SalesWorkSubttlInc := 0;
  h_SalesSlip.SalesWorkSubttlExc := 0;
  h_SalesSlip.SalesNetPrice := 0;
  h_SalesSlip.SalesSubtotalTax := 0;
  h_SalesSlip.ItdedSalesOutTax := 0;
  h_SalesSlip.ItdedSalesInTax := 0;
  h_SalesSlip.SalSubttlSubToTaxFre := 0;
  h_SalesSlip.SalesOutTax := 0;
  h_SalesSlip.SalAmntConsTaxInclu := 0;
  h_SalesSlip.SalesDisTtlTaxExc := 0;
  h_SalesSlip.ItdedSalesDisOutTax := 0;
  h_SalesSlip.ItdedSalesDisInTax := 0;
  h_SalesSlip.ItdedPartsDisOutTax := 0;
  h_SalesSlip.ItdedPartsDisInTax := 0;
  h_SalesSlip.ItdedWorkDisOutTax := 0;
  h_SalesSlip.ItdedWorkDisInTax := 0;
  h_SalesSlip.ItdedSalesDisTaxFre := 0;
  h_SalesSlip.SalesDisOutTax := 0;
  h_SalesSlip.SalesDisTtlTaxInclu := 0;
  h_SalesSlip.PartsDiscountRate := 0;
  h_SalesSlip.RavorDiscountRate := 0;
  h_SalesSlip.TotalCost := 0;
  h_SalesSlip.ConsTaxLayMethod := 0;
  h_SalesSlip.ConsTaxRate := 0;
  h_SalesSlip.FractionProcCd := 0;
  h_SalesSlip.AccRecConsTax := 0;
  h_SalesSlip.AutoDepositCd := 0;
  h_SalesSlip.AutoDepositSlipNo := 0;
  h_SalesSlip.DepositAllowanceTtl := 0;
  h_SalesSlip.DepositAlwcBlnce := 0;
  h_SalesSlip.ClaimCode := 0;
  h_SalesSlip.ClaimSnm := '';
  h_SalesSlip.CustomerCode := 0;
  h_SalesSlip.CustomerName := '';
  h_SalesSlip.CustomerName2 := '';
  h_SalesSlip.CustomerSnm := '';
  h_SalesSlip.HonorificTitle := '';
  h_SalesSlip.OutputNameCode := 0;
  h_SalesSlip.OutputName := '';
  h_SalesSlip.CustSlipNo := 0;
  h_SalesSlip.SlipAddressDiv := 0;
  h_SalesSlip.AddresseeCode := 0;
  h_SalesSlip.AddresseeName := '';
  h_SalesSlip.AddresseeName2 := '';
  h_SalesSlip.AddresseePostNo := '';
  h_SalesSlip.AddresseeAddr1 := '';
  h_SalesSlip.AddresseeAddr3 := '';
  h_SalesSlip.AddresseeAddr4 := '';
  h_SalesSlip.AddresseeTelNo := '';
  h_SalesSlip.AddresseeFaxNo := '';
  h_SalesSlip.PartySaleSlipNum := '';
  h_SalesSlip.SlipNote := '';
  h_SalesSlip.SlipNote2 := '';
  h_SalesSlip.SlipNote3 := '';
  h_SalesSlip.SlipNoteCode := 0;
  h_SalesSlip.SlipNote2Code := 0;
  h_SalesSlip.SlipNote3Code := 0;
  h_SalesSlip.RetGoodsReasonDiv := 0;
  h_SalesSlip.RetGoodsReason := '';
  h_SalesSlip.RegiProcDate := 0;
  h_SalesSlip.CashRegisterNo := 0;
  h_SalesSlip.PosReceiptNo := 0;
  h_SalesSlip.DetailRowCount := 0;
  h_SalesSlip.EdiSendDate := 0;
  h_SalesSlip.EdiTakeInDate := 0;
  h_SalesSlip.UoeRemark1 := '';
  h_SalesSlip.UoeRemark2 := '';
  h_SalesSlip.SlipPrintDivCd := 0;
  h_SalesSlip.SlipPrintFinishCd := 0;
  h_SalesSlip.SalesSlipPrintDate := 0;
  h_SalesSlip.BusinessTypeCode := 0;
  h_SalesSlip.BusinessTypeName := '';
  h_SalesSlip.OrderNumber := '';
  h_SalesSlip.DeliveredGoodsDiv := 0;
  h_SalesSlip.DeliveredGoodsDivNm := '';
  h_SalesSlip.SalesAreaCode := 0;
  h_SalesSlip.SalesAreaName := '';
  h_SalesSlip.ReconcileFlag := 0;
  h_SalesSlip.SlipPrtSetPaperId := '';
  h_SalesSlip.CompleteCd := 0;
  h_SalesSlip.SalesPriceFracProcCd := 0;
  h_SalesSlip.StockGoodsTtlTaxExc := 0;
  h_SalesSlip.PureGoodsTtlTaxExc := 0;
  h_SalesSlip.ListPricePrintDiv := 0;
  h_SalesSlip.EraNameDispCd1 := 0;
  h_SalesSlip.EstimaTaxDivCd := 0;
  h_SalesSlip.EstimateFormPrtCd := 0;
  h_SalesSlip.EstimateSubject := '';
  h_SalesSlip.Footnotes1 := '';
  h_SalesSlip.Footnotes2 := '';
  h_SalesSlip.EstimateTitle1 := '';
  h_SalesSlip.EstimateTitle2 := '';
  h_SalesSlip.EstimateTitle3 := '';
  h_SalesSlip.EstimateTitle4 := '';
  h_SalesSlip.EstimateTitle5 := '';
  h_SalesSlip.EstimateNote1 := '';
  h_SalesSlip.EstimateNote2 := '';
  h_SalesSlip.EstimateNote3 := '';
  h_SalesSlip.EstimateNote4 := '';
  h_SalesSlip.EstimateNote5 := '';
  h_SalesSlip.EstimateValidityDate := 0;
  h_SalesSlip.PartsNoPrtCd := 0;
  h_SalesSlip.OptionPringDivCd := 0;
  h_SalesSlip.RateUseCode := 0;
  h_SalesSlip.CreateDateTime := 0;
  h_SalesSlip.UpdateDateTime := 0;
  h_SalesSlip.EnterpriseCode := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_SalesSlip.FileHeaderGuid[i] := guidcleararray[i];
  end;
  h_SalesSlip.UpdEmployeeCode := '';
  h_SalesSlip.UpdAssemblyId1 := '';
  h_SalesSlip.UpdAssemblyId2 := '';
  h_SalesSlip.CustOrderNoDispDiv := 0;
  h_SalesSlip.CustWarehouseCd := '';
  h_SalesSlip.CreditMngCode := 0;
  h_SalesSlip.DetailRowCountForReadSlip := 0;

  //>>>2010/05/30
  h_SalesSlip.OnlineKindDiv := 0;
  h_SalesSlip.InqOriginalEpCd := '';
  h_SalesSlip.InqOriginalSecCd := '';
  h_SalesSlip.AnswerDiv := 0;
  h_SalesSlip.InquiryNumber := 0;
  h_SalesSlip.InqOrdDivCd := 0;
  //<<<2010/05/30
  h_SalesSlip.AutoAnswerDivSCM := 0;// add 2011/07/18 zhubj
  h_SalesSlip.PreSalesDate  := 0; //ADD ���N�n�� 2012/03/12 Redmine#28288
end;

// **********************************************************************//
// Module Name     :  �Ǘ��ԍ��K�C�h���암�i�t���[�֐�                        //
// :  ClearTCarMangInputExtraInfo                            //
// ����            :  �P�D����f�[�^                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.04.01                                          //
// Note            :  �Ǘ��ԍ��K�C�h���암�i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTCarMangInputExtraInfo(var h_CarMangInputExtraInfo: TCarMangInputExtraInfo);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_CarMangInputExtraInfo.AddiCarSpec1 := '';
  h_CarMangInputExtraInfo.AddiCarSpec2 := '';
  h_CarMangInputExtraInfo.AddiCarSpec3 := '';
  h_CarMangInputExtraInfo.AddiCarSpec4 := '';
  h_CarMangInputExtraInfo.AddiCarSpec5 := '';
  h_CarMangInputExtraInfo.AddiCarSpec6 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle1 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle2 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle3 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle4 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle5 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle6 := '';
  h_CarMangInputExtraInfo.BlockIllustrationCd := 0;
  h_CarMangInputExtraInfo.BodyName := '';
  h_CarMangInputExtraInfo.BodyNameCode := 0;
  h_CarMangInputExtraInfo.CarAddInfo1 := '';
  h_CarMangInputExtraInfo.CarAddInfo2 := '';
  h_CarMangInputExtraInfo.CarInspectYear := 0;
  h_CarMangInputExtraInfo.CarMngCode := '';
  h_CarMangInputExtraInfo.CarMngNo := 0;
  h_CarMangInputExtraInfo.CarNo := '';
  h_CarMangInputExtraInfo.CarNote := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_CarMangInputExtraInfo.CarRelationGuid[i] := guidcleararray[i];
  end;
  h_CarMangInputExtraInfo.CategoryNo := 0;
//  h_CarMangInputExtraInfo.CategoryObjAry := '';
  h_CarMangInputExtraInfo.CategorySignModel := '';
  h_CarMangInputExtraInfo.ColorCode := '';
  h_CarMangInputExtraInfo.ColorName1 := '';
  h_CarMangInputExtraInfo.CreateDateTime := 0;
  h_CarMangInputExtraInfo.CustomerCode := 0;
  h_CarMangInputExtraInfo.CustomerCodeForGuide := '';
  h_CarMangInputExtraInfo.CustomerName := 0;
  h_CarMangInputExtraInfo.DoorCount := 0;
  h_CarMangInputExtraInfo.EDivNm := '';
  h_CarMangInputExtraInfo.EdProduceFrameNo := 0;
  h_CarMangInputExtraInfo.EdProduceTypeOfYear := 0;
  h_CarMangInputExtraInfo.EngineDisplaceNm := '';
  h_CarMangInputExtraInfo.EngineModel := '';
  h_CarMangInputExtraInfo.EngineModelNm := '';
  h_CarMangInputExtraInfo.EnterpriseCode := '';
  h_CarMangInputExtraInfo.EntryDate := 0;
  h_CarMangInputExtraInfo.ExhaustGasSign := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_CarMangInputExtraInfo.FileHeaderGuid[i] := guidcleararray[i];
  end;
  h_CarMangInputExtraInfo.FirstEntryDate := 0;
  h_CarMangInputExtraInfo.FrameModel := '';
  h_CarMangInputExtraInfo.FrameNo := '';
  h_CarMangInputExtraInfo.FullModel := '';
//  h_CarMangInputExtraInfo.FullModelFixedNoAry := '';
  h_CarMangInputExtraInfo.InspectMaturityDate := 0;
  h_CarMangInputExtraInfo.LogicalDeleteCode := 0;
  h_CarMangInputExtraInfo.LTimeCiMatDate := 0;
  h_CarMangInputExtraInfo.MakerCode := 0;
  h_CarMangInputExtraInfo.MakerFullName := '';
  h_CarMangInputExtraInfo.MakerHalfName := '';
  h_CarMangInputExtraInfo.Mileage := 0;
  h_CarMangInputExtraInfo.ModelCode := 0;
  h_CarMangInputExtraInfo.ModelDesignationNo := 0;
  h_CarMangInputExtraInfo.ModelFullName := '';
  h_CarMangInputExtraInfo.ModelGradeNm := '';
  h_CarMangInputExtraInfo.ModelGradeSname := '';
  h_CarMangInputExtraInfo.ModelHalfName := '';
  h_CarMangInputExtraInfo.ModelSubCode := 0;
  h_CarMangInputExtraInfo.NumberPlate1Code := 0;
  h_CarMangInputExtraInfo.NumberPlate1Name := '';
  h_CarMangInputExtraInfo.NumberPlate2 := '';
  h_CarMangInputExtraInfo.NumberPlate3 := '';
  h_CarMangInputExtraInfo.NumberPlate4 := 0;
  h_CarMangInputExtraInfo.NumberPlateForGuide := '';
  h_CarMangInputExtraInfo.PartsDataOfferFlag := 0;
  h_CarMangInputExtraInfo.ProduceTypeOfYearCd := 0;
  h_CarMangInputExtraInfo.ProduceTypeOfYearInput := 0;
  h_CarMangInputExtraInfo.ProduceTypeOfYearNm := '';
  h_CarMangInputExtraInfo.RelevanceModel := '';
  h_CarMangInputExtraInfo.SearchFrameNo := 0;
  h_CarMangInputExtraInfo.SeriesModel := '';
  h_CarMangInputExtraInfo.ShiftNm := '';
  h_CarMangInputExtraInfo.StProduceFrameNo := 0;
  h_CarMangInputExtraInfo.StProduceTypeOfYear := 0;
  h_CarMangInputExtraInfo.SubCarNmCd := 0;
  h_CarMangInputExtraInfo.SystematicCode := 0;
  h_CarMangInputExtraInfo.SystematicName := '';
  h_CarMangInputExtraInfo.ThreeDIllustNo := 0;
  h_CarMangInputExtraInfo.TransmissionNm := '';
  h_CarMangInputExtraInfo.TrimCode := '';
  h_CarMangInputExtraInfo.TrimName := '';
  h_CarMangInputExtraInfo.UpdateDateTime := 0;
  h_CarMangInputExtraInfo.WheelDriveMethodNm := '';
  h_CarMangInputExtraInfo.DomesticForeignCode := 0; // ADD 2013/03/21
end;

// **********************************************************************//
// Module Name     :  �Ԏ핔�i�t���[�֐�                        //
// :  ClearTModelNameU                            //
// ����            :  �P�D�Ԏ햼�̃}�X�^                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.16                                          //
// Note            :  �Ԏ핔�i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTModelNameU(var h_ModelNameU: TModelNameU);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_ModelNameU.CreateDateTime := 0;
  h_ModelNameU.CreateDateTimeAdFormal := '';
  h_ModelNameU.CreateDateTimeAdInFormal := '';
  h_ModelNameU.CreateDateTimeJpFormal := '';
  h_ModelNameU.CreateDateTimeJpInFormal := '';
  h_ModelNameU.Division := 0;
  h_ModelNameU.DivisionName := '';
  h_ModelNameU.EnterpriseCode := '';
  h_ModelNameU.EnterpriseName := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_ModelNameU.FileHeaderGuid[i] := guidcleararray[i];
  end;
  h_ModelNameU.LogicalDeleteCode := 0;
  h_ModelNameU.MakerCode := 0;
  h_ModelNameU.ModelAliasName := '';
  h_ModelNameU.ModelCode := 0;
  h_ModelNameU.ModelFullName := '';
  h_ModelNameU.ModelHalfName := '';
  h_ModelNameU.ModelSubCode := 0;
  h_ModelNameU.ModelUniqueCode := 0;
  h_ModelNameU.OfferDataDiv := 0;
  h_ModelNameU.OfferDate := 0;
  h_ModelNameU.UpdAssemblyId1 := '';
  h_ModelNameU.UpdAssemblyId2 := '';
  h_ModelNameU.UpdateDateTime := 0;
  h_ModelNameU.UpdateDateTimeAdFormal := '';
  h_ModelNameU.UpdateDateTimeAdInFormal := '';
  h_ModelNameU.UpdateDateTimeJpFormal := '';
  h_ModelNameU.UpdateDateTimeJpInFormal := '';
  h_ModelNameU.UpdEmployeeCode := '';
  h_ModelNameU.UpdEmployeeName := '';
end;

// **********************************************************************//
// Module Name     :  �ԕi���R���i�t���[�֐�                        //
// :  ClearTUserGdHd                            //
// ����            :  �P�DXXXX                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.17                                          //
// Note            :  �ԕi���R���i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTUserGdHd(var h_UserGdHd: TUserGdHd);
begin
  h_UserGdHd.CreateDateTime           := 0;
  h_UserGdHd.CreateDateTimeAdFormal   := '';
  h_UserGdHd.CreateDateTimeAdInFormal := '';
  h_UserGdHd.CreateDateTimeJpFormal   := '';
  h_UserGdHd.CreateDateTimeJpInFormal := '';
  h_UserGdHd.LogicalDeleteCode        := 0;
  h_UserGdHd.MasterOfferCd            := 0;
  h_UserGdHd.UpdateDateTime           := 0;
  h_UserGdHd.UpdateDateTimeAdFormal   := '';
  h_UserGdHd.UpdateDateTimeAdInFormal := '';
  h_UserGdHd.UpdateDateTimeJpFormal   := '';
  h_UserGdHd.UpdateDateTimeJpInFormal := '';
  h_UserGdHd.UserGuideDivCd           := '';
  h_UserGdHd.UserGuideDivNm           := '';
end;

// **********************************************************************//
// Module Name     :  �ԕi���R���i�t���[�֐�                        //
// :  ClearTUserGdBd                            //
// ����            :  �P�DXXXX                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.17                                          //
// Note            :  �ԕi���R���i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTUserGdBd(var h_UserGdBd: TUserGdBd);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_UserGdBd.CreateDateTime             := 0;
  h_UserGdBd.CreateDateTimeAdFormal     := '';
  h_UserGdBd.CreateDateTimeAdInFormal   := '';
  h_UserGdBd.CreateDateTimeJpFormal     := '';
  h_UserGdBd.CreateDateTimeJpInFormal   := '';
  h_UserGdBd.EnterpriseCode             := '';
  h_UserGdBd.EnterpriseName             := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_UserGdBd.FileHeaderGuid            [i] := guidcleararray[i];
  end;
  h_UserGdBd.GuideCode                  := 0;
  h_UserGdBd.GuideName                  := '';
  h_UserGdBd.GuideType                  := 0;
  h_UserGdBd.LogicalDeleteCode          := 0;
  h_UserGdBd.UpdAssemblyId1             := '';
  h_UserGdBd.UpdAssemblyId2             := '';
  h_UserGdBd.UpdateDateTime           := 0;
  h_UserGdBd.UpdateDateTimeAdFormal     := '';
  h_UserGdBd.UpdateDateTimeAdInFormal   := '';
  h_UserGdBd.UpdateDateTimeJpFormal     := '';
  h_UserGdBd.UpdateDateTimeJpInFormal   := '';
  h_UserGdBd.UpdEmployeeCode            := '';
  h_UserGdBd.UpdEmployeeName            := '';
  h_UserGdBd.UserGuideDivCd             := 0;
end;
// add by gaofeng end


// add by Lizc start

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTColorInfo                            //
// ����            :  �P�D�J���[���                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.30                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTColorInfo(var h_ColorInfo: TColorInfo);
begin
  h_ColorInfo.ColorCode := '';
  h_ColorInfo.ColorName := '';
  h_ColorInfo.MakerCode := 0;
  h_ColorInfo.ModelCode := 0;
  h_ColorInfo.ModelSubCode := 0;
  h_ColorInfo.SelectionState := False;
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTTrimInfo                            //
// ����            :  �P�D�g�������                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.30                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTTrimInfo(var h_TrimInfo: TTrimInfo);
begin
  h_TrimInfo.MakerCode := 0;
  h_TrimInfo.ModelCode := 0;
  h_TrimInfo.ModelSubCode := 0;
  h_TrimInfo.TrimCode := '';
  h_TrimInfo.TrimName := '';
  h_TrimInfo.SelectionState := False;
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTCEqpDefDspInfo                            //
// ����            :  �P�D�������                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.30                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTCEqpDefDspInfo(var h_CEqpDefDspInfo: TCEqpDefDspInfo);
begin
  h_CEqpDefDspInfo.EquipmentCode := 0;
  h_CEqpDefDspInfo.EquipmentDispOrder := 0;
  h_CEqpDefDspInfo.EquipmentGenreCd := 0;
  h_CEqpDefDspInfo.EquipmentGenreNm := '';
  h_CEqpDefDspInfo.EquipmentIconCode := 0;
  h_CEqpDefDspInfo.EquipmentName := '';
  h_CEqpDefDspInfo.EquipmentShortName := '';
  h_CEqpDefDspInfo.MakerCode := 0;
  h_CEqpDefDspInfo.ModelCode := 0;
  h_CEqpDefDspInfo.ModelSubCode := 0;
  h_CEqpDefDspInfo.SelectionState := False;
  h_CEqpDefDspInfo.SystematicCode := 0;
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTCarSpecInfo                            //
// ����            :  �P�D�������                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.30                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTCarSpecInfo(var h_CarSpecInfo: TCarSpecInfo);
begin
  h_CarSpecInfo.ModelGradeNm := '';
  h_CarSpecInfo.BodyName := '';
  h_CarSpecInfo.DoorCount := 0;
  h_CarSpecInfo.EDivNm := '';
  h_CarSpecInfo.EngineDisplaceNm := '';
  h_CarSpecInfo.EngineModelNm := '';
  h_CarSpecInfo.ShiftNm := '';
  h_CarSpecInfo.TransmissionNm := '';
  h_CarSpecInfo.WheelDriveMethodNm := '';
  h_CarSpecInfo.AddiCarSpec1 := '';
  h_CarSpecInfo.AddiCarSpec2 := '';
  h_CarSpecInfo.AddiCarSpec3 := '';
  h_CarSpecInfo.AddiCarSpec4 := '';
  h_CarSpecInfo.AddiCarSpec5 := '';
  h_CarSpecInfo.AddiCarSpec6 := '';
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTCarInfo                            //
// ����            :  �P�D�ԗ����                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.30                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTCarInfo(var h_CarInfo: TCarInfo);
begin
  h_CarInfo.CarRelationGuid := '';
  h_CarInfo.CustomerCode := 0;
  h_CarInfo.CarMngNo := 0;
  h_CarInfo.CarMngCode := '';
  h_CarInfo.NumberPlate1Code := 0;
  h_CarInfo.NumberPlate1Name := '';
  h_CarInfo.NumberPlate2 := '';
  h_CarInfo.NumberPlate3 := '';
  h_CarInfo.NumberPlate4 := 0;
  h_CarInfo.EntryDate := 0;
  h_CarInfo.FirstEntryDate := 0;
  h_CarInfo.MakerCode := 0;
  h_CarInfo.MakerFullName := '';
  h_CarInfo.MakerHalfName := '';
  h_CarInfo.ModelCode := 0;
  h_CarInfo.ModelSubCode := 0;
  h_CarInfo.ModelFullName := '';
  h_CarInfo.ModelHalfName := '';
  h_CarInfo.SystematicCode := 0;
  h_CarInfo.SystematicName := '';
  h_CarInfo.ProduceTypeOfYearCd := 0;
  h_CarInfo.ProduceTypeOfYearNm := '';
  h_CarInfo.StProduceTypeOfYear := 0;
  h_CarInfo.EdProduceTypeOfYear := 0;
  h_CarInfo.DoorCount := 0;
  h_CarInfo.BodyNameCode := 0;
  h_CarInfo.BodyName := '';
  h_CarInfo.ExhaustGasSign := '';
  h_CarInfo.SeriesModel := '';
  h_CarInfo.CategorySignModel := '';
  h_CarInfo.FullModel := '';
  h_CarInfo.ModelDesignationNo := 0;
  h_CarInfo.CategoryNo := 0;
  h_CarInfo.FrameModel := '';
  h_CarInfo.FrameNo := '';
  h_CarInfo.SearchFrameNo := 0;
  h_CarInfo.StProduceFrameNo := 0;
  h_CarInfo.EdProduceFrameNo := 0;
  h_CarInfo.ModelGradeNm := '';
  h_CarInfo.EngineModelNm := '';
  h_CarInfo.EngineDisplaceNm := '';
  h_CarInfo.EDivNm := '';
  h_CarInfo.TransmissionNm := '';
  h_CarInfo.ShiftNm := '';
  h_CarInfo.WheelDriveMethodNm := '';
  h_CarInfo.AddiCarSpec1 := '';
  h_CarInfo.AddiCarSpec2 := '';
  h_CarInfo.AddiCarSpec3 := '';
  h_CarInfo.AddiCarSpec4 := '';
  h_CarInfo.AddiCarSpec5 := '';
  h_CarInfo.AddiCarSpec6 := '';
  h_CarInfo.AddiCarSpecTitle1 := '';
  h_CarInfo.AddiCarSpecTitle2 := '';
  h_CarInfo.AddiCarSpecTitle3 := '';
  h_CarInfo.AddiCarSpecTitle4 := '';
  h_CarInfo.AddiCarSpecTitle5 := '';
  h_CarInfo.AddiCarSpecTitle6 := '';
  h_CarInfo.RelevanceModel := '';
  h_CarInfo.SubCarNmCd := 0;
  h_CarInfo.ModelGradeSname := '';
  h_CarInfo.BlockIllustrationCd := 0;
  h_CarInfo.ThreeDIllustNo := 0;
  h_CarInfo.PartsDataOfferFlag := 0;
  h_CarInfo.InspectMaturityDate := 0;
  h_CarInfo.LTimeCiMatDate := 0;
  h_CarInfo.CarInspectYear := 0;
  h_CarInfo.Mileage := 0;
  h_CarInfo.CarNo := '';
  h_CarInfo.FullModelFixedNoAry := '';
  h_CarInfo.CategoryObjAry := '';
  h_CarInfo.ProduceTypeOfYearInput := 0;
  h_CarInfo.ColorCode := '';
  h_CarInfo.ColorName1 := '';
  h_CarInfo.TrimCode := '';
  h_CarInfo.TrimName := '';
  h_CarInfo.AcceptAnOrderNo := 0;
  h_CarInfo.CarNote := '';
  h_CarInfo.CarAddInfo1 := '';
  h_CarInfo.CarAddInfo2 := '';
  h_CarInfo.EngineModel := '';
  h_CarInfo.ProduceTypeOfYearRange := '';
  h_CarInfo.ProduceFrameNoRange := '';
  h_CarInfo.DomesticForeignCode := 0; // ADD 2013/03/21
  h_CarInfo.CarNoteCode := 0; //ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTCarModel                            //
// ����            :  �P�Dxxxxx                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.30                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTCarModel(var h_CarModel: TCarModel);
begin
  h_CarModel.CategorySign := '';
  h_CarModel.ExhaustGasSign := '';
  h_CarModel.FullModel := '';
  h_CarModel.IsFullModel := True;
  h_CarModel.SeriesModel := '';
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTEngineModel                            //
// ����            :  �P�Dxxxxx                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.30                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTEngineModel(var h_EngineModel: TEngineModel);
begin
  h_EngineModel.FullModel := '';
  h_EngineModel.Model := '';
  h_EngineModel.ModelNm := '';
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTCarSearchCondition                            //
// ����            :  �P�D�ԗ���������                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.30                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTCarSearchCondition(var h_CarSearchCondition: TCarSearchCondition);
begin
  ClearTCarModel(h_CarSearchCondition.CarModel);
  h_CarSearchCondition.CategoryNo := 0;
  ClearTEngineModel(h_CarSearchCondition.EngineModel);
  h_CarSearchCondition.EraNameDispCd1 := 0;
  h_CarSearchCondition.IsReady := False;
  h_CarSearchCondition.MakerCode := 0;
  h_CarSearchCondition.ModelCode := 0;
  h_CarSearchCondition.ModelDesignationNo := 0;
  h_CarSearchCondition.ModelPlate := '';
  h_CarSearchCondition.ModelSubCode := 0;
end;


procedure ClearBeforeCarSearchBuffer(var h_BeforeCarSearchBuffer: BeforeCarSearchBuffer);
begin
  h_BeforeCarSearchBuffer.ProduceFrameNo := '';
  h_BeforeCarSearchBuffer.FirstEntryDate := 0;
  h_BeforeCarSearchBuffer.ColorNo := '';
  h_BeforeCarSearchBuffer.TrimNo := '';
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTCustomerInfo                            //
// ����            :  �P�D���Ӑ���                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.04.19                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTCustomerInfo(var h_CustomerInfo: TCustomerInfo);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_CustomerInfo.AcceptWholeSale := 0;
  h_CustomerInfo.AccountNoInfo1 := '';
  h_CustomerInfo.AccountNoInfo2 := '';
  h_CustomerInfo.AccountNoInfo3 := '';
  h_CustomerInfo.AccRecDivCd := 0;
  h_CustomerInfo.AcpOdrrSlipPrtDiv := 0;
  h_CustomerInfo.Address1 := '';
  h_CustomerInfo.Address3 := '';
  h_CustomerInfo.Address4 := '';
  h_CustomerInfo.BillCollecterCd := '';
  h_CustomerInfo.BillCollecterNm := '';
  h_CustomerInfo.BillHonorificTtl := '';
  h_CustomerInfo.BillHonorTtlPrtDiv := 0;
  h_CustomerInfo.BillOutputCode := 0;
  h_CustomerInfo.BillOutPutCodeNm := '';
  h_CustomerInfo.BillOutputName := '';
  h_CustomerInfo.BillPartsNoPrtCd := 0;
  h_CustomerInfo.BusinessTypeCode := 0;
  h_CustomerInfo.BusinessTypeName := '';
  h_CustomerInfo.CarMngDivCd := 0;
  h_CustomerInfo.ClaimCode := 0;
  h_CustomerInfo.ClaimName := '';
  h_CustomerInfo.ClaimName2 := '';
  h_CustomerInfo.ClaimSectionCode := '';
  h_CustomerInfo.ClaimSectionName := '';
  h_CustomerInfo.ClaimSnm := '';
  h_CustomerInfo.CollectCond := 0;
  h_CustomerInfo.CollectMoneyCode := 0;
  h_CustomerInfo.CollectMoneyDay := 0;
  h_CustomerInfo.CollectMoneyName := '';
  h_CustomerInfo.CollectSight := 0;
  h_CustomerInfo.ConsTaxLayMethod := 0;
  h_CustomerInfo.CorporateDivCode := 0;
  h_CustomerInfo.CreateDateTime := 0;
  h_CustomerInfo.CreateDateTimeAdFormal := '';
  h_CustomerInfo.CreateDateTimeAdInFormal := '';
  h_CustomerInfo.CreateDateTimeJpFormal := '';
  h_CustomerInfo.CreateDateTimeJpInFormal := '';
  h_CustomerInfo.CreditMngCode := 0;
  h_CustomerInfo.CustAgentChgDate := 0;
  h_CustomerInfo.CustAnalysCode1 := 0;
  h_CustomerInfo.CustAnalysCode2 := 0;
  h_CustomerInfo.CustAnalysCode3 := 0;
  h_CustomerInfo.CustAnalysCode4 := 0;
  h_CustomerInfo.CustAnalysCode5 := 0;
  h_CustomerInfo.CustAnalysCode6 := 0;
  h_CustomerInfo.CustCTaXLayRefCd := 0;
  h_CustomerInfo.CustomerAgent := '';
  h_CustomerInfo.CustomerAgentCd := '';
  h_CustomerInfo.CustomerAgentNm := '';
  h_CustomerInfo.CustomerAttributeDiv := 0;
  h_CustomerInfo.CustomerCode := 0;
  h_CustomerInfo.CustomerEpCode := '';
  h_CustomerInfo.CustomerSecCode := '';
  h_CustomerInfo.CustomerSlipNoDiv := 0;
  h_CustomerInfo.CustomerSnm := '';
  h_CustomerInfo.CustomerSubCode := '';
  h_CustomerInfo.CustSlipNoMngCd := 0;
  h_CustomerInfo.CustWarehouseCd := '';
  h_CustomerInfo.CustWarehouseName := '';
  h_CustomerInfo.DefSalesSlipCd := 0;
  h_CustomerInfo.DeliHonorificTtl := '';
  h_CustomerInfo.DeliHonorTtlPrtDiv := 0;
  h_CustomerInfo.DeliPartsNoPrtCd := 0;
  h_CustomerInfo.DepoBankCode := 0;
  h_CustomerInfo.DepoBankName := '';
  h_CustomerInfo.DepoDelCode := 0;
  h_CustomerInfo.DmOutCode := 0;
  h_CustomerInfo.DmOutName := '';
  h_CustomerInfo.EnterpriseCode := '';
  h_CustomerInfo.EnterpriseName := '';
  h_CustomerInfo.EstimatePrtDiv := 0;
  h_CustomerInfo.EstmHonorificTtl := '';
  h_CustomerInfo.EstmHonorTtlPrtDiv := 0;
//  for i := 0 to Length(guidcleararray) - 1 do
//  begin
//    h_CustomerInfo.GuidFileHeaderGuid[i] := guidcleararray[i];
//  end;
  h_CustomerInfo.HomeFaxNo := '';
  h_CustomerInfo.HomeFaxNoDspName := '';
  h_CustomerInfo.HomeTelNo := '';
  h_CustomerInfo.HomeTelNoDspName := '';
  h_CustomerInfo.HonorificTitle := '';
  h_CustomerInfo.InpSectionCode := '';
  h_CustomerInfo.InpSectionName := '';
  //h_CustomerInfo.IsCustomer := '';
  //h_CustomerInfo.IsReceiver := '';
  h_CustomerInfo.JobTypeCode := 0;
  h_CustomerInfo.JobTypeName := '';
  h_CustomerInfo.Kana := '';
  h_CustomerInfo.LavorRateRank := 0;
  h_CustomerInfo.LogicalDeleteCode := 0;
  h_CustomerInfo.MailAddress1 := '';
  h_CustomerInfo.MailAddress2 := '';
  h_CustomerInfo.MailAddrKindCode1 := 0;
  h_CustomerInfo.MailAddrKindCode2 := 0;
  h_CustomerInfo.MailAddrKindName1 := '';
  h_CustomerInfo.MailAddrKindName2 := '';
  h_CustomerInfo.MailSendCode1 := 0;
  h_CustomerInfo.MailSendCode2 := 0;
  h_CustomerInfo.MailSendName1 := '';
  h_CustomerInfo.MailSendName2 := '';
  h_CustomerInfo.MainContactCode := 0;
  h_CustomerInfo.MainContactName := '';
  h_CustomerInfo.MainSendMailAddrCd := 0;
  h_CustomerInfo.MngSectionCode := '';
  h_CustomerInfo.MngSectionName := '';
  h_CustomerInfo.MobileTelNoDspName := '';
  h_CustomerInfo.Name := '';
  h_CustomerInfo.Name2 := '';
  h_CustomerInfo.Note1 := '';
  h_CustomerInfo.Note10 := '';
  h_CustomerInfo.Note2 := '';
  h_CustomerInfo.Note3 := '';
  h_CustomerInfo.Note4 := '';
  h_CustomerInfo.Note5 := '';
  h_CustomerInfo.Note6 := '';
  h_CustomerInfo.Note7 := '';
  h_CustomerInfo.Note8 := '';
  h_CustomerInfo.Note9 := '';
  h_CustomerInfo.NTimeCalcStDate := 0;
  h_CustomerInfo.OfficeFaxNo := '';
  h_CustomerInfo.OfficeFaxNoDspName := '';
  h_CustomerInfo.OfficeTelNo := '';
  h_CustomerInfo.OfficeTelNoDspName := '';
  h_CustomerInfo.OldCustomerAgentCd := '';
  h_CustomerInfo.OldCustomerAgentNm := '';
  h_CustomerInfo.OnlineKindDiv := 0;
  h_CustomerInfo.OthersTelNo := '';
  h_CustomerInfo.OtherTelNoDspName := '';
  h_CustomerInfo.OutputName := '';
  h_CustomerInfo.OutputNameCode := 0;
  h_CustomerInfo.PortableTelNo := '';
  h_CustomerInfo.PostNo := '';
  h_CustomerInfo.PrslOrCorpDivNm := '';
  h_CustomerInfo.PureCode := 0;
  h_CustomerInfo.QrcodePrtCd := 0;
  h_CustomerInfo.ReceiptOutputCode := 0;
  h_CustomerInfo.RectHonorificTtl := '';
  h_CustomerInfo.RectHonorTtlPrtDiv := 0;
  h_CustomerInfo.SalesAreaCode := 0;
  h_CustomerInfo.SalesAreaName := '';
  h_CustomerInfo.SalesCnsTaxFrcProcCd := 0;
  h_CustomerInfo.SalesMoneyFrcProcCd := 0;
  h_CustomerInfo.SalesSlipPrtDiv := 0;
  h_CustomerInfo.SalesUnPrcFrcProcCd := 0;
  h_CustomerInfo.SearchTelNo := '';
  h_CustomerInfo.ShipmSlipPrtDiv := 0;
  h_CustomerInfo.SlipTtlPrn := 0;
  h_CustomerInfo.TotalAmntDspWayRef := 0;
  h_CustomerInfo.TotalAmountDispWayCd := 0;
  h_CustomerInfo.TotalDay := 0;
  h_CustomerInfo.TransStopDate := 0;
  h_CustomerInfo.UOESlipPrtDiv := 0;
  h_CustomerInfo.UpdAssemblyId1 := '';
  h_CustomerInfo.UpdAssemblyId2 := '';
  h_CustomerInfo.UpdateDateTime := 0;
  h_CustomerInfo.UpdateDateTimeAdFormal := '';
  h_CustomerInfo.UpdateDateTimeAdInFormal := '';
  h_CustomerInfo.UpdateDateTimeJpFormal := '';
  h_CustomerInfo.UpdateDateTimeJpInFormal := '';
  h_CustomerInfo.UpdEmployeeCode := '';
  h_CustomerInfo.UpdEmployeeName := '';
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTHeaderFocusConstruction                            //
// ����            :  �P�D�w�b�_�[���t�H�[�J�X�ړ��ݒ�N���X                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.05.15                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTHeaderFocusConstruction(var h_HeaderFocusConstruction: THeaderFocusConstruction);
begin
  h_HeaderFocusConstruction.Key := '';
  h_HeaderFocusConstruction.Caption := '';
  h_HeaderFocusConstruction.EnterStop := '';
end;

// **********************************************************************//
// Module Name     :  �ԗ��������i�t���[�֐�                        //
// :  ClearTFooterFocusConstruction                            //
// ����            :  �P�D�t�b�^���t�H�[�J�X�ړ��ݒ�N���X                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.05.15                                          //
// Note            :  �ԗ��������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTFooterFocusConstruction(var h_FooterFocusConstruction: TFooterFocusConstruction);
begin
  h_FooterFocusConstruction.Key := '';
  h_FooterFocusConstruction.Caption := '';
  h_FooterFocusConstruction.EnterStop := '';
end;
// add by Lizc end

// add by Zhangkai start

// **********************************************************************//
// Module Name     :  �i�Ԍ������i�t���[�֐�                        //
// :  ClearTSalesDetail                            //
// ����            :  �P�D���㖾�׃f�[�^                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.31                                          //
// Note            :  �i�Ԍ������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTSalesDetail(var h_SalesDetail: TSalesDetail);
begin
  h_SalesDetail.AcptAnOdrStatus := 0;
  h_SalesDetail.SalesSlipNum := '';
  h_SalesDetail.SalesRowNo := 0;
  h_SalesDetail.SalesRowDerivNo := 0;
  h_SalesDetail.SectionCode := '';
  h_SalesDetail.SubSectionCode := 0;
  h_SalesDetail.SalesDate := 0;
  h_SalesDetail.CommonSeqNo := 0;
  h_SalesDetail.SalesSlipDtlNum := 0;
  h_SalesDetail.AcptAnOdrStatusSrc := 0;
  h_SalesDetail.SalesSlipDtlNumSrc := 0;
  h_SalesDetail.SupplierFormalSync := 0;
  h_SalesDetail.StockSlipDtlNumSync := 0;
  h_SalesDetail.SalesSlipCdDtl := 0;
  //h_SalesDetail.DeliGdsCmpltDueDate := 0;// DEL 2010/07/01
  h_SalesDetail.DeliGdsCmpltDueDate := '';// ADD 2010/07/01
  h_SalesDetail.GoodsKindCode := 0;
  h_SalesDetail.GoodsSearchDivCd := 0;
  h_SalesDetail.GoodsMakerCd := 0;
  h_SalesDetail.MakerName := '';
  h_SalesDetail.MakerKanaName := '';
  h_SalesDetail.GoodsNo := '';
  h_SalesDetail.GoodsName := '';
  h_SalesDetail.GoodsNameKana := '';
  h_SalesDetail.GoodsLGroup := 0;
  h_SalesDetail.GoodsLGroupName := '';
  h_SalesDetail.GoodsMGroup := 0;
  h_SalesDetail.GoodsMGroupName := '';
  h_SalesDetail.BLGroupCode := 0;
  h_SalesDetail.BLGroupName := '';
  h_SalesDetail.BLGoodsCode := 0;
  h_SalesDetail.BLGoodsFullName := '';
  h_SalesDetail.EnterpriseGanreCode := 0;
  h_SalesDetail.EnterpriseGanreName := '';
  h_SalesDetail.WarehouseCode := '';
  h_SalesDetail.WarehouseName := '';
  h_SalesDetail.WarehouseShelfNo := '';
  h_SalesDetail.SalesOrderDivCd := 0;
  h_SalesDetail.OpenPriceDiv := 0;
  h_SalesDetail.GoodsRateRank := '';
  h_SalesDetail.CustRateGrpCode := 0;
  h_SalesDetail.ListPriceRate := 0;
  h_SalesDetail.RateSectPriceUnPrc := '';
  h_SalesDetail.RateDivLPrice := '';
  h_SalesDetail.UnPrcCalcCdLPrice := 0;
  h_SalesDetail.PriceCdLPrice := 0;
  h_SalesDetail.StdUnPrcLPrice := 0;
  h_SalesDetail.FracProcUnitLPrice := 0;
  h_SalesDetail.FracProcLPrice := 0;
  h_SalesDetail.ListPriceTaxIncFl := 0;
  h_SalesDetail.ListPriceTaxExcFl := 0;
  h_SalesDetail.ListPriceChngCd := 0;
  h_SalesDetail.SalesRate := 0;
  h_SalesDetail.RateSectSalUnPrc := '';
  h_SalesDetail.RateDivSalUnPrc := '';
  h_SalesDetail.UnPrcCalcCdSalUnPrc := 0;
  h_SalesDetail.PriceCdSalUnPrc := 0;
  h_SalesDetail.StdUnPrcSalUnPrc := 0;
  h_SalesDetail.FracProcUnitSalUnPrc := 0;
  h_SalesDetail.FracProcSalUnPrc := 0;
  h_SalesDetail.SalesUnPrcTaxIncFl := 0;
  h_SalesDetail.SalesUnPrcTaxExcFl := 0;
  h_SalesDetail.SalesUnPrcChngCd := 0;
  h_SalesDetail.CostRate := 0;
  h_SalesDetail.RateSectCstUnPrc := '';
  h_SalesDetail.RateDivUnCst := '';
  h_SalesDetail.UnPrcCalcCdUnCst := 0;
  h_SalesDetail.PriceCdUnCst := 0;
  h_SalesDetail.StdUnPrcUnCst := 0;
  h_SalesDetail.FracProcUnitUnCst := 0;
  h_SalesDetail.FracProcUnCst := 0;
  h_SalesDetail.SalesUnitCost := 0;
  h_SalesDetail.SalesUnitCostChngDiv := 0;
  h_SalesDetail.RateBLGoodsCode := 0;
  h_SalesDetail.RateBLGoodsName := '';
  h_SalesDetail.RateGoodsRateGrpCd := 0;
  h_SalesDetail.RateGoodsRateGrpNm := '';
  h_SalesDetail.RateBLGroupCode := 0;
  h_SalesDetail.RateBLGroupName := '';
  h_SalesDetail.PrtBLGoodsCode := 0;
  h_SalesDetail.PrtBLGoodsName := '';
  h_SalesDetail.SalesCode := 0;
  h_SalesDetail.SalesCdNm := '';
  h_SalesDetail.WorkManHour := 0;
  h_SalesDetail.ShipmentCnt := 0;
  h_SalesDetail.AcceptAnOrderCnt := 0;
  h_SalesDetail.AcptAnOdrAdjustCnt := 0;
  h_SalesDetail.AcptAnOdrRemainCnt := 0;
  h_SalesDetail.RemainCntUpdDate := 0;
  h_SalesDetail.SalesMoneyTaxInc := 0;
  h_SalesDetail.SalesMoneyTaxExc := 0;
  h_SalesDetail.Cost := 0;
  h_SalesDetail.GrsProfitChkDiv := 0;
  h_SalesDetail.SalesGoodsCd := 0;
  h_SalesDetail.SalesPriceConsTax := 0;
  h_SalesDetail.TaxationDivCd := 0;
  h_SalesDetail.PartySlipNumDtl := '';
  h_SalesDetail.DtlNote := '';
  h_SalesDetail.SupplierCd := 0;
  h_SalesDetail.SupplierSnm := '';
  h_SalesDetail.OrderNumber := '';
  h_SalesDetail.WayToOrder := 0;
  h_SalesDetail.SlipMemo1 := '';
  h_SalesDetail.SlipMemo2 := '';
  h_SalesDetail.SlipMemo3 := '';
  h_SalesDetail.InsideMemo1 := '';
  h_SalesDetail.InsideMemo2 := '';
  h_SalesDetail.InsideMemo3 := '';
  h_SalesDetail.BfListPrice := 0;
  h_SalesDetail.BfSalesUnitPrice := 0;
  h_SalesDetail.BfUnitCost := 0;
  h_SalesDetail.CmpltSalesRowNo := 0;
  h_SalesDetail.CmpltGoodsMakerCd := 0;
  h_SalesDetail.CmpltMakerName := '';
  h_SalesDetail.CmpltMakerKanaName := '';
  h_SalesDetail.CmpltGoodsName := '';
  h_SalesDetail.CmpltShipmentCnt := 0;
  h_SalesDetail.CmpltSalesUnPrcFl := 0;
  h_SalesDetail.CmpltSalesMoney := 0;
  h_SalesDetail.CmpltSalesUnitCost := 0;
  h_SalesDetail.CmpltCost := 0;
  h_SalesDetail.CmpltPartySalSlNum := '';
  h_SalesDetail.CmpltNote := '';
  h_SalesDetail.PrtGoodsNo := '';
  h_SalesDetail.PrtMakerCode := 0;
  h_SalesDetail.PrtMakerName := '';
  h_SalesDetail.EditStatus := 0;
  h_SalesDetail.RowStatus := 0;
  h_SalesDetail.SalesMoneyInputDiv := 0;
  h_SalesDetail.ShipmentCntDisplay := 0;
  h_SalesDetail.SupplierStockDisplay := 0;
  h_SalesDetail.ListPriceDisplay := 0;
  h_SalesDetail.StockDate := 0;
  h_SalesDetail.BoCode := '';
  h_SalesDetail.SupplierCdForOrder := 0;
  h_SalesDetail.SupplierSnmForOrder := '';
  h_SalesDetail.DeliveredGoodsDivNm := '';
  h_SalesDetail.FollowDeliGoodsDivNm := '';
  h_SalesDetail.UOEResvdSectionNm := '';
  h_SalesDetail.UOEDeliGoodsDiv := '';
  h_SalesDetail.FollowDeliGoodsDiv := '';
  h_SalesDetail.UOEResvdSection := '';
  h_SalesDetail.PartySalesSlipNum := '';
  h_SalesDetail.AcceptAnOrderNo := 0;
  h_SalesDetail.SearchPartsModeState := 0;
  //>>>2010/05/30
//  h_SalesDetail.CampaignCode := 0;
//  h_SalesDetail.CampaignName := '';
//  h_SalesDetail.GoodsDivCd := 0;
//  h_SalesDetail.AnswerDelivDate := '';
  h_SalesDetail.RecycleDiv := 0;
  h_SalesDetail.RecycleDivNm := '';
//  h_SalesDetail.WayToAcptOdr := 0;
  h_SalesDetail.GoodsMngNo := 0;
//  h_SalesDetail.InqRowNumber := 0;
//  h_SalesDetail.InqRowNumDerivedNo := 0;
  //<<<2010/05/30
end;

// add by Zhangkai end

end.



