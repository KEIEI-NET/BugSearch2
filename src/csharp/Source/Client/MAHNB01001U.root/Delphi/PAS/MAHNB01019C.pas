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
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601193-00 �쐬�S�� : 杍^
// �� �� ��  2010/08/13  �C�����e : ��Q�E���ǑΉ�(�W�������[�X�Č�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2011/02/01  �C�����e : SCM��񑶍݃`�F�b�N�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2011/05/25  �C�����e : SCM����
//                                : 1)���M�m�F��ʂɎw�����ԍ��̓��͂�ǉ�
//                                : 2)�t�b�^���Ɏw�����ԍ��̓��͂�ǉ�
//                                : 3)�̔��敪�̓��͐���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���юR
// �� �� ��  2011/08/20  �C�����e : �A��882 ���艿���\���̂�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30182 ���J ���� R.Tachiya
// �� �� ��  2012.07.23  �C�����e : ��QNo.995�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �{�{ �����@
// �� �� ��  2012/11/13  �C�����e : ���t������I�v�V������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �{�{ �����@
// �� �� ��  2012/12/21  �C�����e : �R�`���i�I�v�V�����Ή�
//----------------------------------------------------------------------------//
unit MAHNB01019C;

interface

Uses
    HDllCall, DBClient, HFSLLIB;

type

    //�[���Ǘ��ݒ�}�X�^�f�[�^�\����
    TPosTerminalMg = packed record
        PosPCTermCd: LongInt;    //POS/PC�[���敪
    end;

    //�[���Ǘ��ݒ�}�X�^�f�[�^�|�C���^�^
    PPosTerminalMg = ^TPosTerminalMg;

    //�[���Ǘ��ݒ�}�X�^�f�[�^�z��^
    TPosTerminalMgArray = array of TPosTerminalMg;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    //�󔭒��Ǘ��S�̐ݒ�}�X�^�f�[�^�\����
    TAcptAnOdrTtlSt = packed record
      EstmCountReflectDiv : LongInt;  //���ϐ����f�敪
      AcpOdrrSlipPrtDiv : LongInt;    //�󒍓`�[���s�敪
      FaxOrderDiv : LongInt;          //�e�`�w�����敪
    end;

    //�󔭒��Ǘ��S�̐ݒ�}�X�^�f�[�^�|�C���^�^
    PAcptAnOdrTtlSt = ^TAcptAnOdrTtlSt;

    //�󔭒��Ǘ��S�̐ݒ�}�X�^�f�[�^�z��^
    TAcptAnOdrTtlStArray = array of TAcptAnOdrTtlSt;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    //����S�̐ݒ�}�X�^�f�[�^�\����
    TSalesTtlSt = packed record
      AcpOdrAgentDispDiv: LongInt;    //�󒍎ҕ\���敪
      AcpOdrInputDiv: LongInt;    //xxxxxx
      AutoEntryGoodsDivCd: LongInt;    //���i�����o�^
      BLGoodsCdInpDiv: LongInt;    //BL���i�R�[�h���͋敪
      BrSlipNote2DispDiv: LongInt;    //�`�[���l�Q�\���敪
      BrSlipNote3DispDiv: LongInt;    //�`�[���l�R�\���敪
      CarMngNoDispDiv: LongInt;    //���q�Ǘ��ԍ��\���敪
      CostDspDivCd: LongInt;    //�����\���敪
      CustGuideDispDiv: LongInt;    //���Ӑ�K�C�h�����\���敪
      DtlNoteDispDiv: LongInt;    //���ה��l�\���敪
      GrsProfitDspCd: LongInt;    //�e���\���敪
      InpAgentDispDiv: LongInt;    //���s�ҕ\���敪
      InpGrsProfChkLowDiv: LongInt;    //���͑e���`�F�b�N�����敪
      MakerInpDiv: LongInt;    //���[�J�[���͋敪
      PartsSearchDivCd: LongInt;    //���i�����敪
      RetGoodsStockEtyDiv: LongInt;    //�ԕi���݌ɓo�^�敪
      RetSlipChngDivCost: LongInt;    //�ԕi�`�[�C���敪�i�����j
      RetSlipChngDivUnPrc: LongInt;    //�ԕi�`�[�C���敪�i�����j
      SalesAgentChngDiv: LongInt;    //����S���ύX�敪
      SalesStockDiv: LongInt;    //����d���敪
      SectDspDivCd: LongInt;    //���_�\���敪
      SlipChngDivCost: LongInt;    //�`�[�C���敪�i�����j
      SlipChngDivDate: LongInt;    //�`�[�C���敪�i���t�j
      SlipChngDivLPrice: LongInt;    //�`�[�C���敪�i�艿�j
      SlipDateClrDivCd: LongInt;    //�`�[���t�N���A�敪
      SupplierInpDiv: LongInt;    //�d������͋敪
      SupplierSlipDelDiv: LongInt;    //�d���`�[�폜�敪
      UnPrcNonSettingDiv: LongInt;    //�������ݒ莞�敪
      SlipChngDivUnPrc: LongInt;
      InpGrsProfChkUppDiv: LongInt;
      DwnPLCdSpDivCd: LongInt;      // ADD 2010/08/13
      SalesCdDspDivCd: LongInt; // 2011/05/25
      RentStockDiv: LongInt;    // 2012/05/02
    end;

    //����S�̐ݒ�}�X�^�f�[�^�|�C���^�^
    PSalesTtlSt = ^TSalesTtlSt;

    //����S�̐ݒ�}�X�^�f�[�^�z��^
    TSalesTtlStArray = array of TSalesTtlSt;

    //�S�̏����l�ݒ�}�X�^�f�[�^�\����
    TAllDefSet = packed record
        EraNameDispCd1: LongInt;    //�����\���敪�P
        RemCntAutoDspDiv: LongInt;    //�c�������\���敪
        GoodsNoInpDiv: LongInt;
    end;

    //�S�̏����l�ݒ�}�X�^�f�[�^�|�C���^�^
    PAllDefSet = ^TAllDefSet;

    //�S�̏����l�ݒ�}�X�^�f�[�^�z��^
    TAllDefSetArray = array of TAllDefSet;

    //���Џ��ݒ�}�X�^�f�[�^�\����
    TCompanyInf = packed record
        SecMngDiv: LongInt;    //�����Ǘ��敪�h
    end;

    //���Џ��ݒ�}�X�^�f�[�^�|�C���^�^
    PCompanyInf = ^TCompanyInf;

    //���Џ��ݒ�}�X�^�f�[�^�z��^
    TCompanyInfArray = array of TCompanyInf;


    //�֐��^��`

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitData = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitDataSecond = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitDataThird = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitDataFourth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitDataFifth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitDataSixth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitDataSeventh = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitDataEighth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitDataNinth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐���`
    TxMAHNB01019B_ReadInitDataTenth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //�[���Ǘ��}�X�^�֐���`
    TxMAHNB01019B_GetPosTerminalMg = function(var posTerminalMg: TPosTerminalMg)
    : Integer; stdcall;

    //�I�v�V������񏈗��֐���`
    TxMAHNB01019B_GetOptInfo = function(var optCarMng: Integer;
                                        var optFreeSearch: Integer;
                                        var optPcc: Integer;
                                        var optRCLink: Integer;
                                        var optUoe: Integer;
                                        var optStockingPayment: Integer;
                                        var optScm: Integer;
                                        var opt_QRMail: Integer;
                                        var opt_DateCtrl: Integer; // ADD T.Miyamoto 2012/11/13
                                        var opt_NoBuTo: Integer // ADD 杍^ K2014/01/22
                                       ) : Integer; stdcall;

    // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    //�R�`���i�I�v�V������񏈗��֐���`
    TxMAHNB01019B_GetYamagataOptInfo = function(var optStockEntCtrl: Integer;  //���d���������͐���I�v�V����    (OPT-CPM0050)
                                                var optStockDateCtrl: Integer; //�d�����t�t�H�[�J�X����I�v�V����(OPT-CPM0060)
                                                var optSalesCostCtrl: Integer  //�����C������I�v�V����          (OPT-CPM0070)
                                               ) : Integer; stdcall;
    // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

    // -- Add St 2012.07.23 30182 R.Tachiya --
    //�󔭒��Ǘ��S�̐ݒ�}�X�^�֐���`
    TxMAHNB01019B_GetAcptAnOdrTtlSt = function(var acptAnOdrTtlSt: TAcptAnOdrTtlSt)
    : Integer; stdcall;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    //����S�̐ݒ�}�X�^�֐���`
    TxMAHNB01019B_GetSalesTtlSt = function(var salesTtlSt: TSalesTtlSt)
    : Integer; stdcall;

    //�S�̏����l�ݒ�}�X�^�֐���`
    TxMAHNB01019B_GetAllDefSet = function(var allDefSet: TAllDefSet)
    : Integer; stdcall;

    //���Џ��ݒ�}�X�^�֐���`
    TxMAHNB01019B_GetCompanyInf = function(var companyInf: TCompanyInf)
    : Integer; stdcall;

    //������z�����敪�ݒ�}�X�^���䏈���֐���`
    TxMAHNB01019B_CacheSalesProcMoneyListCall = function()
    : Integer; stdcall;

    //�d�����z�����敪�ݒ�}�X�^���䏈���֐���`
    TxMAHNB01019B_CacheStockProcMoneyListCall = function()
    : Integer; stdcall;

    //�|���D��Ǘ��}�X�^���䏈���֐���`
    TxMAHNB01019B_CacheRateProtyMngListCall = function()
    : Integer; stdcall;

    //�����敪�}�X�^���X�g�ݒ菈���֐���`
    TxMAHNB01019B_SettingProcMoney = function()
    : Integer; stdcall;

    PRCHNB01003UADM = ^TRCHNB01003UADM;
    TRCHNB01003UADM = packed record
      BLGoodsCode     : array[0..99] of LongInt;  // BL�R�[�h
      GoodsName       : array[0..99] of string;    // �i��
      GoodsNo         : array[0..99] of string;    // �i��
      RowStatus       : array[0..99] of LongInt;   // �s���
      SalesSlipNum    : array[0..99] of string;    // ����`�[�ԍ�
      SalesRowNo      : array[0..99] of LongInt;    // ����s�ԍ�
      EditStatus      : array[0..99] of LongInt;    //
      AlreadyAddUpCnt : array[0..99] of Double;    //

      GoodsKindCode   : array[0..99] of LongInt;   // ���i���� 0:�����@1:���̑�
      GoodsMakerCd    : array[0..99] of LongInt;   // ���[�J�[�R�[�h
      SupplierCd      : array[0..99] of LongInt;   // �d���� �R�[�h
      ShipmentCnt     : array[0..99] of Double;    // �o�א�
      StdUnPrcLPrice  : array[0..99] of Double;    // ��P���i�艿�j
      SalesUnitCost   : array[0..99] of Double;    // �����P��

      // 2011/08/20 XUJS ADD STA ------>>>>>>
      StdUnPrcUnCst   : array[0..99] of Double;    // �����艿
      // 2011/08/20 XUJS ADD END ------<<<<<<

      ShipmentCntDisplay      : array[0..99] of Double;    // �o�א�(�\���p)
      AcceptAnOrderCntDisplay : array[0..99] of Double;    // �󒍐�(�\���p)
      SalesSlipCdDtl          : array[0..99] of LongInt;    // ����`�[�敪(����)
      WarehouseCode           : array[0..99] of string;    // �q�ɃR�[�h
      SupplierStockDisplay    : array[0..99] of Double;    // ���݌ɐ�(�\���p)

      ListPriceTaxExcFl    : array[0..99] of Double;    // �W�����i
      ListPriceDisplay     : array[0..99] of Double;    // �W�����i(�\���p)
      CostRate             : array[0..99] of Double;    // ������
      SalesRate            : array[0..99] of Double;    // ������
      SalesUnPrcTaxExcFl   : array[0..99] of Double;    // ���P��
      SalesMoneyTaxExc     : array[0..99] of LongInt;   // ������z
      StockDate            : array[0..99] of Int64;     // �d����

      BoCode               : array[0..99] of string;     // BO
      SupplierCdForOrder   : array[0..99] of LongInt;    // ������
      SupplierSnmForOrder  : array[0..99] of string;     // �����於��
      AcptAnOdrStatusSrc   : array[0..99] of LongInt;    // �󒍃X�e�[�^�X�i���j(10:����,20:��,30:����,40:�o��)
      SalesSlipDtlNumSrc   : array[0..99] of LongInt;    // ����`�[�ԍ��i���j
      TaxDiv               : array[0..99] of LongInt;    // �ېŁE��ېŋ敪
      SalesMoneyInputDiv   : array[0..99] of LongInt;    // ���z����͋敪
      OpenPriceDiv         : array[0..99] of LongInt;    // OP

      DeliveredGoodsDivNm  : array[0..99] of string;     // �[�i�敪
      SalesCode            : array[0..99] of LongInt;    // �̔��敪
      Cost                 : array[0..99] of LongInt;    // ����
      //DeliGdsCmpltDueDate  : array[0..99] of Int64;      // �[�i�����\�� // DEL 2010/07/01
      DeliGdsCmpltDueDate  : array[0..99] of string;      // �[�i�����\��  // ADD 2010/07/01
      PartySlipNumDtl      : array[0..99] of string;     // �����`�[�ԍ��i���ׁj
      AcceptAnOrderCntForOrder     : array[0..99] of Double;    // ������
      FollowDeliGoodsDivNm : array[0..99] of string;    // �g�[�i�敪
      UOEResvdSectionNm    : array[0..99] of string;    // �w�苒�_

      UOEDeliGoodsDiv      : array[0..99] of string;     // �[�i�敪
      FollowDeliGoodsDiv   : array[0..99] of string;    // �g�[�i�敪
      UOEResvdSection      : array[0..99] of string;    // �w�苒�_

      WarehouseShelfNo     : array[0..99] of string;    // �q�ɒI��
      PartySalesSlipNum    : array[0..99] of string;     // �d���`�[�ԍ�
      DtlNote              : array[0..99] of string;     // ���ה��l
      SalesSlipDtlNum      : array[0..99] of LongInt;     // ���גʔ�
      AcceptAnOrderNo      : array[0..99] of LongInt;     // �󒍔ԍ�
      AcptAnOdrStatus      : array[0..99] of LongInt;    // �󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��)
      SearchPartsModeState : array[0..99] of LongInt;    // ���i�������

      //>>>2010/05/30
      RecycleDivNm    : array[0..99] of string;    // RC�敪����
      RecycleDiv      : array[0..99] of LongInt;    // RC�敪
      GoodsMngNo      : array[0..99] of LongInt;     // PS�Ǘ��ԍ�
      //<<<2010/05/30

    procedure ClrData(iRow :Integer);

    end;

    // �Ăяo���o�f�͈ȉ��̊֐����o�f�̊J�n�ƏI���ɌĂт܂��B
function LoadLibraryMAHNB01019B(HDllCALL1: THDLLCALL): Integer;
procedure FreeLibraryMAHNB01019B(HDllCALL1: THDLLCALL);
procedure ClearTPosTerminalMg(var h_PosTerminalMg: TPosTerminalMg);
procedure ClearTAcptAnOdrTtlSt(var h_AcptAnOdrTtlSt: TAcptAnOdrTtlSt);// -- Add 2012.07.23 30182 R.Tachiya --
procedure ClearTSalesTtlSt(var h_SalesTtlSt: TSalesTtlSt);
procedure ClearTAllDefSet(var h_AllDefSet: TAllDefSet);
procedure ClearTCompanyInf(var h_CompanyInf: TCompanyInf);

var
    //�֐��|�C���^�錾
    gpxMAHNB01019B_ReadInitData : TxMAHNB01019B_ReadInitData;
    gpxMAHNB01019B_ReadInitDataSecond : TxMAHNB01019B_ReadInitDataSecond;
    gpxMAHNB01019B_ReadInitDataThird : TxMAHNB01019B_ReadInitDataThird;
    gpxMAHNB01019B_ReadInitDataFourth : TxMAHNB01019B_ReadInitDataFourth;
    gpxMAHNB01019B_ReadInitDataFifth : TxMAHNB01019B_ReadInitDataFifth;
    gpxMAHNB01019B_ReadInitDataSixth : TxMAHNB01019B_ReadInitDataSixth;
    gpxMAHNB01019B_ReadInitDataSeventh : TxMAHNB01019B_ReadInitDataSeventh;
    gpxMAHNB01019B_ReadInitDataEighth : TxMAHNB01019B_ReadInitDataEighth;
    gpxMAHNB01019B_ReadInitDataNinth : TxMAHNB01019B_ReadInitDataNinth;
    gpxMAHNB01019B_ReadInitDataTenth : TxMAHNB01019B_ReadInitDataTenth;
    gpxMAHNB01019B_GetPosTerminalMg : TxMAHNB01019B_GetPosTerminalMg;
    gpxMAHNB01019B_GetAcptAnOdrTtlSt : TxMAHNB01019B_GetAcptAnOdrTtlSt;// -- Add 2012.07.23 30182 R.Tachiya --
    gpxMAHNB01019B_GetSalesTtlSt : TxMAHNB01019B_GetSalesTtlSt;
    gpxMAHNB01019B_GetAllDefSet : TxMAHNB01019B_GetAllDefSet;
    gpxMAHNB01019B_GetCompanyInf : TxMAHNB01019B_GetCompanyInf;
    gpxMAHNB01019B_CacheSalesProcMoneyListCall : TxMAHNB01019B_CacheSalesProcMoneyListCall;
    gpxMAHNB01019B_CacheStockProcMoneyListCall : TxMAHNB01019B_CacheStockProcMoneyListCall;
    gpxMAHNB01019B_CacheRateProtyMngListCall : TxMAHNB01019B_CacheRateProtyMngListCall;
    gpxMAHNB01019B_SettingProcMoney : TxMAHNB01019B_SettingProcMoney;
    gpxMAHNB01019B_GetOptInfo : TxMAHNB01019B_GetOptInfo;
    gpxMAHNB01019B_GetYamagataOptInfo : TxMAHNB01019B_GetYamagataOptInfo; // ADD 2012/12/21 T.Miyamoto

implementation

// **********************************************************************//
// Module Name     :  ���������i���[�h�֐�                            //
// :  LoadLibraryMAHNB01019B                            //
// ����            :  �P�DHDLLCALL                                      //
// �߂�l          :  �X�e�[�^�X ctFNC_NORMAL : ����                    //
// :             ctFNC_ERROR  : ���s                    //
// Programer       :  ��������                                            //
// Date            :  2010.03.25                                          //
// Note            :  ���������i���[�h���܂�                          //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
function LoadLibraryMAHNB01019B(HDllCALL1: THDLLCALL): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCALL1.DllName := 'MAHNB01019B.DLL';
    nSt := HDllCALL1.HLoadLibrary;

    //DLL���[�h
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '������',
            'LoadLibraryMAHNB01019B', 'LOADLIBRARY', '�������̃��[�h�Ɏ��s���܂���', nSt,
            nil, 0);
        Exit;
    end;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '������������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '������������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�I�v�V������񏈗��֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_GetOptInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetOptInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '�Ԏ핔�i',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '�Ԏ핔�i�I�v�V������񏈗��֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    //�R�`���i�I�v�V������񏈗��֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_GetYamagataOptInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetYamagataOptInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '�R�`���i',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '�R�`���i�I�v�V������񏈗��֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataSecond';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataSecond);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���������i������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataThird';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataThird);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���������i������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataFourth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataFourth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���������i������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataFifth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataFifth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���������i������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataSixth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataSixth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���������i������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataSeventh';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataSeventh);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���������i������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataEighth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataEighth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���������i������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataNinth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataNinth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���������i������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataTenth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataTenth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���������i������͂Ŏg�p����',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�[���Ǘ��}�X�^�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_GetPosTerminalMg';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetPosTerminalMg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '�[���Ǘ��}�X�^',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '�[���Ǘ��}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    //�󔭒��Ǘ��S�̐ݒ�}�X�^�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_GetAcptAnOdrTtlSt';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetAcptAnOdrTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '�󔭒��Ǘ��S�̐ݒ�}�X�^',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '�󔭒��Ǘ��S�̐ݒ�}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    //����S�̐ݒ�}�X�^�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_GetSalesTtlSt';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetSalesTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '����S�̐ݒ�}�X�^',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '����S�̐ݒ�}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�S�̏����l�ݒ�}�X�^�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_GetAllDefSet';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetAllDefSet);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '�S�̏����l�ݒ�}�X�^',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '�S�̏����l�ݒ�}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���Џ��ݒ�}�X�^�֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_GetCompanyInf';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetCompanyInf);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '���Џ��ݒ�}�X�^',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '���Џ��ݒ�}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //������z�����敪�ݒ�}�X�^���䏈���֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_CacheSalesProcMoneyListCall';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_CacheSalesProcMoneyListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '������z�����敪�ݒ�}�X�^',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '������z�����敪�ݒ�}�X�^���䏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�d�����z�����敪�ݒ�}�X�^���䏈���֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_CacheStockProcMoneyListCall';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_CacheStockProcMoneyListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '�d�����z�����敪�ݒ�}�X�^',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '�d�����z�����敪�ݒ�}�X�^���䏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�|���D��Ǘ��}�X�^���䏈���֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_CacheRateProtyMngListCall';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_CacheRateProtyMngListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '�|���D��Ǘ��}�X�^',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '�|���D��Ǘ��}�X�^���䏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //�����敪�}�X�^���X�g�ݒ菈���֐��A�h���X�擾
    HDllCALL1.ProcName := 'MAHNB01019B_SettingProcMoney';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_SettingProcMoney);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '�����敪�}�X�^',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '�����敪�}�X�^���X�g�ݒ菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;


    Result := 0;

end;

// **********************************************************************//
// Module Name     :  ���������i�t���[�֐�                        //
// :  FreeLibraryMAHNB01019B                            //
// ����            :  �P�DHDLLCALL                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.25                                          //
// Note            :  ���������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure FreeLibraryMAHNB01019B(HDllCALL1: THDLLCALL);
begin
    HDllCALL1.DllName := 'MAHNB01019B.DLL';
    HDllCALL1.HFreeLibrary;
    gpxMAHNB01019B_ReadInitData := nil;
    gpxMAHNB01019B_ReadInitDataSecond := nil;
    gpxMAHNB01019B_ReadInitDataThird := nil;
    gpxMAHNB01019B_ReadInitDataFourth := nil;
    gpxMAHNB01019B_ReadInitDataFifth := nil;
    gpxMAHNB01019B_ReadInitDataSixth := nil;
    gpxMAHNB01019B_ReadInitDataSeventh := nil;
    gpxMAHNB01019B_ReadInitDataEighth := nil;
    gpxMAHNB01019B_ReadInitDataNinth := nil;
    gpxMAHNB01019B_ReadInitDataTenth := nil;
    gpxMAHNB01019B_GetPosTerminalMg := nil;
    gpxMAHNB01019B_GetAcptAnOdrTtlSt := nil;// -- Add 2012.07.23 30182 R.Tachiya --
    gpxMAHNB01019B_GetSalesTtlSt := nil;
    gpxMAHNB01019B_GetAllDefSet := nil;
    gpxMAHNB01019B_GetCompanyInf := nil;
    gpxMAHNB01019B_CacheSalesProcMoneyListCall := nil;
    gpxMAHNB01019B_CacheStockProcMoneyListCall := nil;
    gpxMAHNB01019B_CacheRateProtyMngListCall := nil;
    gpxMAHNB01019B_SettingProcMoney := nil;
    gpxMAHNB01019B_GetOptInfo := nil;
    gpxMAHNB01019B_GetYamagataOptInfo := nil; // ADD 2012/12/21 T.Miyamoto

end;

// **********************************************************************//
// Module Name     :  ���������i�t���[�֐�                        //
// :  ClearTPosTerminalMg                            //
// ����            :  �P�D�[���Ǘ��ݒ�}�X�^                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.25                                          //
// Note            :  ���������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTPosTerminalMg(var h_PosTerminalMg: TPosTerminalMg);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_PosTerminalMg.PosPCTermCd := 0;
end;

// -- Add St 2012.07.23 30182 R.Tachiya --
// **********************************************************************//
// Module Name     :  ���������i�t���[�֐�                               //
// :  ClearTAcptAnOdrTtlSt                                               //
// ����            :  �P�D�󔭒��Ǘ��S�̐ݒ�}�X�^                       //
// �߂�l          :  ����                                               //
// Programer       :  30182 ���J���� R.Tachiya                           //
// Date            :  2012.07.23                                         //
// Note            :  ���������i�t���[���܂�                             //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                             //
// **********************************************************************//
procedure ClearTAcptAnOdrTtlSt(var h_AcptAnOdrTtlSt: TAcptAnOdrTtlSt);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_AcptAnOdrTtlSt.EstmCountReflectDiv := 0;
  h_AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv := 0;
  h_AcptAnOdrTtlSt.FaxOrderDiv := 0;
end;
// -- Add Ed 2012.07.23 30182 R.Tachiya --

// **********************************************************************//
// Module Name     :  ���������i�t���[�֐�                        //
// :  ClearTSalesTtlSt                            //
// ����            :  �P�D����S�̐ݒ�}�X�^                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.25                                          //
// Note            :  ���������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTSalesTtlSt(var h_SalesTtlSt: TSalesTtlSt);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_SalesTtlSt.AcpOdrAgentDispDiv := 0;
  h_SalesTtlSt.AcpOdrInputDiv := 0;
  h_SalesTtlSt.AutoEntryGoodsDivCd := 0;
  h_SalesTtlSt.BLGoodsCdInpDiv := 0;
  h_SalesTtlSt.BrSlipNote2DispDiv := 0;
  h_SalesTtlSt.BrSlipNote3DispDiv := 0;
  h_SalesTtlSt.CarMngNoDispDiv := 0;
  h_SalesTtlSt.CostDspDivCd := 0;
  h_SalesTtlSt.CustGuideDispDiv := 0;
  h_SalesTtlSt.DtlNoteDispDiv := 0;
  h_SalesTtlSt.GrsProfitDspCd := 0;
  h_SalesTtlSt.InpAgentDispDiv := 0;
  h_SalesTtlSt.InpGrsProfChkLowDiv := 0;
  h_SalesTtlSt.MakerInpDiv := 0;
  h_SalesTtlSt.PartsSearchDivCd := 0;
  h_SalesTtlSt.RetGoodsStockEtyDiv := 0;
  h_SalesTtlSt.RetSlipChngDivCost := 0;
  h_SalesTtlSt.RetSlipChngDivUnPrc := 0;
  h_SalesTtlSt.SalesAgentChngDiv := 0;
  h_SalesTtlSt.SalesStockDiv := 0;
  h_SalesTtlSt.SectDspDivCd := 0;
  h_SalesTtlSt.SlipChngDivCost := 0;
  h_SalesTtlSt.SlipChngDivDate := 0;
  h_SalesTtlSt.SlipChngDivLPrice := 0;
  h_SalesTtlSt.SlipDateClrDivCd := 0;
  h_SalesTtlSt.SupplierInpDiv := 0;
  h_SalesTtlSt.SupplierSlipDelDiv := 0;
  h_SalesTtlSt.UnPrcNonSettingDiv := 0;
  h_SalesTtlSt.InpGrsProfChkUppDiv :=0;
  h_SalesTtlSt.DwnPLCdSpDivCd :=0;        // ADD 2010/08/13
  h_SalesTtlSt.SalesCdDspDivCd := 0; // 2011/05/25
  h_SalesTtlSt.RentStockDiv := 0; // 2012/05/02
end;

// **********************************************************************//
// Module Name     :  ���������i�t���[�֐�                        //
// :  ClearTAllDefSet                            //
// ����            :  �P�D�S�̏����l�ݒ�}�X�^                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.25                                          //
// Note            :  ���������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTAllDefSet(var h_AllDefSet: TAllDefSet);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_AllDefSet.EraNameDispCd1 := 0;
  h_AllDefSet.RemCntAutoDspDiv := 0;
end;

// **********************************************************************//
// Module Name     :  ���������i�t���[�֐�                        //
// :  ClearTCompanyInf                            //
// ����            :  �P�D���Џ��ݒ�}�X�^                                      //
// �߂�l          :  ����                                              //
// Programer       :  ��������                                            //
// Date            :  2010.03.25                                          //
// Note            :  ���������i�t���[���܂�                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  �����@����                            //
// **********************************************************************//
procedure ClearTCompanyInf(var h_CompanyInf: TCompanyInf);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_CompanyInf.SecMngDiv := 0;
end;

procedure TRCHNB01003UADM.ClrData(iRow : Integer);
begin
   if (iRow <= 99) then
   BLGoodsCode[iRow] := 0;
   GoodsName[iRow] := '';
   GoodsNo[iRow] := '';
   RowStatus[iRow] := 0;
   SalesSlipNum[iRow] := '';
   SalesRowNo[iRow] := 0;
   EditStatus[iRow] := 0;
   AlreadyAddUpCnt[iRow] := 0;

   GoodsKindCode[iRow] := 0;
   GoodsMakerCd[iRow] := 0;
   SupplierCd[iRow] := 0;
   ShipmentCnt[iRow] := 0;
   StdUnPrcLPrice[iRow] := 0;
   SalesUnitCost[iRow] := 0;

   // 2011/08/20 XUJS ADD STA ------>>>>>>
   StdUnPrcUnCst[iRow] := 0;
   // 2011/08/20 XUJS ADD END ------<<<<<<

   ShipmentCntDisplay[iRow] := 0;
   AcceptAnOrderCntDisplay[iRow] := 0;
   SalesSlipCdDtl[iRow] := 0;
   WarehouseCode[iRow] := '';
   SupplierStockDisplay[iRow] := 0;

   ListPriceTaxExcFl[iRow] := 0;
   CostRate[iRow] := 0;
   SalesRate[iRow] := 0;
   SalesUnPrcTaxExcFl[iRow] := 0;
   SalesMoneyTaxExc[iRow] := 0;
   StockDate[iRow] := 0;

   BoCode[iRow] := '';
   SupplierCdForOrder[iRow] := 0;
   SupplierSnmForOrder[iRow] := '';
   AcptAnOdrStatusSrc[iRow] := 0;
   SalesSlipDtlNumSrc[iRow] := 0;
   TaxDiv[iRow] := 0;
   SalesMoneyInputDiv[iRow] := 0;
   OpenPriceDiv[iRow] := 0;

   DeliveredGoodsDivNm[iRow] := '';
   SalesCode[iRow] := 0;
   Cost[iRow] := 0;
   //DeliGdsCmpltDueDate[iRow] := 0; // DEL 2010/07/01
   DeliGdsCmpltDueDate[iRow] := '';  // ADD 2010/07/01
   PartySlipNumDtl[iRow] := '';
   AcceptAnOrderCntForOrder[iRow] := 0;
   FollowDeliGoodsDivNm[iRow] := '';
   UOEResvdSectionNm[iRow] := '';

   UOEDeliGoodsDiv[iRow] := '';
   FollowDeliGoodsDiv[iRow] := '';
   UOEResvdSection[iRow] := '';
   WarehouseShelfNo[iRow] := '';
   PartySalesSlipNum[iRow] := '';
   DtlNote[iRow] := '';
   SalesSlipDtlNum[iRow] := 0;
   AcceptAnOrderNo[iRow] := 0;
   AcptAnOdrStatus[iRow] := 0;
   SearchPartsModeState[iRow] := 0;

   //>>>2010/05/30
   RecycleDivNm[iRow] := '';
   RecycleDiv[iRow] := 0;
   GoodsMngNo[iRow] := 0;
   //<<<2010/05/30
end;

end.
