unit MAHNB01019BMP;

interface

uses
    ShareMem, SysUtils, Classes, HDllCall, HFSLLIB, MAHNB01019C, Forms;

type
    TDataModule1 = class(TDataModule)
        HDllCall1: THDllCall;
        private
            { Private �錾 }
        public
            { Public �錾 }
    end;

    /////////////////// ����N���X����̃C���|�[�g�֐��^�錾 /////////////////

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitData = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitDataSecond = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitDataThird = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitDataFourth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitDataFifth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitDataSixth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitDataSeventh = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitDataEighth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitDataNinth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // ������͂Ŏg�p���鏉���f�[�^���c�a���擾���\�b�h�^
    TxSalesSlipInputInitDataAcs_ReadInitDataTenth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // �I�v�V������񏈗����\�b�h�^
    TxSalesSlipInputInitDataAcs_GetOptInfo = function(var optCarMng: Integer;
                                                      var optFreeSearch: Integer;
                                                      var optPcc: Integer;
                                                      var optRCLink: Integer;
                                                      var optUoe: Integer;
                                                      var optStockingPayment: Integer;
                                                      var optScm: Integer;
                                                      var opt_QRMail: Integer;
                                                      var opt_DateCtrl: Integer; // ADD T.Miyamoto 2012/11/13
                                                      var opt_NoBuTo: Integer  // ADD 杍^ K2014/01/22
                                                     ): Integer; stdcall;

// --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    // �R�`���i�I�v�V������񏈗�
    TxSalesSlipInputInitDataAcs_GetYamagataOptInfo = function(var optStockEntCtrl: Integer;
                                                              var optStockDateCtrl: Integer;
                                                              var optSalesCostCtrl: Integer
                                                             ): Integer; stdcall;
// --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

    // �[���Ǘ��}�X�^���\�b�h�^
    TxSalesSlipInputInitDataAcs_GetPosTerminalMg = function(var resultPosTerminalMg: TPosTerminalMg): Integer; stdcall;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    // �󔭒��Ǘ��S�̐ݒ�}�X�^���\�b�h�^
    TxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt = function(var resultAcptAnOdrTtlSt: TAcptAnOdrTtlSt): Integer; stdcall;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    // ����S�̐ݒ�}�X�^���\�b�h�^
    TxSalesSlipInputInitDataAcs_GetSalesTtlSt = function(var resultSalesTtlSt: TSalesTtlSt): Integer; stdcall;

    // �S�̏����l�ݒ�}�X�^���\�b�h�^
    TxSalesSlipInputInitDataAcs_GetAllDefSet = function(var resultAllDefSet: TAllDefSet): Integer; stdcall;

    // ���Џ��ݒ�}�X�^���\�b�h�^
    TxSalesSlipInputInitDataAcs_GetCompanyInf = function(var resultCompanyInf: TCompanyInf): Integer; stdcall;

    // ������z�����敪�ݒ�}�X�^���䏈�����\�b�h�^
    TxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall = function(): Integer; stdcall;

    // �d�����z�����敪�ݒ�}�X�^���䏈�����\�b�h�^
    TxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall = function(): Integer; stdcall;

    // �|���D��Ǘ��}�X�^���䏈�����\�b�h�^
    TxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall = function(): Integer; stdcall;

    // �����敪�}�X�^���X�g�ݒ菈�����\�b�h�^
    TxSalesSlipInputInitDataAcs_SettingProcMoney = function(): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputInitDataAcs_FreePosTerminalMg = function(resultList: PPosTerminalMg;
        resultCount: Integer): Integer; stdcall;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    // ������\�b�h�^
    TxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt = function(resultList: PAcptAnOdrTtlSt;
        resultCount: Integer): Integer; stdcall;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    // ������\�b�h�^
    TxSalesSlipInputInitDataAcs_FreeSalesTtlSt = function(resultList: PSalesTtlSt;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputInitDataAcs_FreeAllDefSet = function(resultList: PAllDefSet;
        resultCount: Integer): Integer; stdcall;

    // ������\�b�h�^
    TxSalesSlipInputInitDataAcs_FreeCompanyInf = function(resultList: PCompanyInf;
        resultCount: Integer): Integer; stdcall;

    //�����������\�b�h�^
    TxSalesSlipInputInitDataAcs_FreeMessage = function(msg : WideString):Integer; stdcall;

    //�A�N�Z�X�N���X����DLL���[�h���\�b�h
    function LoadLibraryMAHNB01019M(HDllCall1: THDllCall): Integer;

    //�A�N�Z�X�N���X����DLL�A�����[�h���\�b�h
    procedure FreeLibraryMAHNB01019M(HDllCall1: THDllCall);

var
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitData: TxSalesSlipInputInitDataAcs_ReadInitData;
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitDataSecond: TxSalesSlipInputInitDataAcs_ReadInitDataSecond;
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitDataThird: TxSalesSlipInputInitDataAcs_ReadInitDataThird;
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitDataFourth: TxSalesSlipInputInitDataAcs_ReadInitDataFourth;
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitDataFifth: TxSalesSlipInputInitDataAcs_ReadInitDataFifth;
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitDataSixth: TxSalesSlipInputInitDataAcs_ReadInitDataSixth;
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitDataSeventh: TxSalesSlipInputInitDataAcs_ReadInitDataSeventh;
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitDataEighth: TxSalesSlipInputInitDataAcs_ReadInitDataEighth;
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitDataNinth: TxSalesSlipInputInitDataAcs_ReadInitDataNinth;
    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_ReadInitDataTenth: TxSalesSlipInputInitDataAcs_ReadInitDataTenth;
    // �[���Ǘ��}�X�^�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_GetPosTerminalMg: TxSalesSlipInputInitDataAcs_GetPosTerminalMg;
    // -- Add St 2012.07.23 30182 R.Tachiya --
    // �󔭒��Ǘ��S�̐ݒ�}�X�^�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt: TxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --
    // ����S�̐ݒ�}�X�^�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_GetSalesTtlSt: TxSalesSlipInputInitDataAcs_GetSalesTtlSt;
    // �I�v�V������񏈗��֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_GetOptInfo: TxSalesSlipInputInitDataAcs_GetOptInfo;
// --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    // �R�`���i�I�v�V������񏈗��֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_GetYamagataOptInfo: TxSalesSlipInputInitDataAcs_GetYamagataOptInfo;
// --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
    // �S�̏����l�ݒ�}�X�^�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_GetAllDefSet: TxSalesSlipInputInitDataAcs_GetAllDefSet;
    // ���Џ��ݒ�}�X�^�֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_GetCompanyInf: TxSalesSlipInputInitDataAcs_GetCompanyInf;
    // ������z�����敪�ݒ�}�X�^���䏈���֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall: TxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall;
    // �d�����z�����敪�ݒ�}�X�^���䏈���֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall: TxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall;
    // �|���D��Ǘ��}�X�^���䏈���֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall: TxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall;
    // �����敪�}�X�^���X�g�ݒ菈���֐��ďo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_SettingProcMoney: TxSalesSlipInputInitDataAcs_SettingProcMoney;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_FreePosTerminalMg: TxSalesSlipInputInitDataAcs_FreePosTerminalMg;
    // -- Add St 2012.07.23 30182 R.Tachiya --
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt: TxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_FreeSalesTtlSt: TxSalesSlipInputInitDataAcs_FreeSalesTtlSt;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_FreeAllDefSet: TxSalesSlipInputInitDataAcs_FreeAllDefSet;
    // ��������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_FreeCompanyInf: TxSalesSlipInputInitDataAcs_FreeCompanyInf;

    //�������������Ăяo���p�|�C���^�ϐ�
    gpxSalesSlipInputInitDataAcs_FreeMessage: TxSalesSlipInputInitDataAcs_FreeMessage;

    DataModule1: TDataModule1;

implementation

{$R *.dfm}

// �������A�N�Z�X�N���X����DLL���[�h����
function LoadLibraryMAHNB01019M(HDllCall1: THDllCall): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCall1.DllName := 'MAHNB01019M.DLL';
    nSt := HDllCall1.HLoadLibrary;

    // DLL���[�h
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '������',
            'LoadLibraryMAHNB01019M', 'LOADLIBRARY', '�������̃��[�h�Ɏ��s���܂���',
            nSt, nil, 0);
        Exit;
    end;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitData';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�����f�[�^���c�a���擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �I�v�V������񏈗��֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetOptInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetOptInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�Ԏ핔�i',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�Ԏ핔�i�I�v�V������񏈗��֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    // �R�`���i�I�v�V������񏈗��֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetYamagataOptInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetYamagataOptInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�R�`���i',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�R�`���i�I�v�V������񏈗��֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataSecond';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataSecond);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�����f�[�^���c�a���擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataThird';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataThird);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�����f�[�^���c�a���擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataFourth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataFourth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataFifth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataFifth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataSixth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataSixth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataSeventh';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataSeventh);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataEighth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataEighth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataNinth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataNinth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataTenth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataTenth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����f�[�^���c�a���擾',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������i������͂Ŏg�p����擾�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �[���Ǘ��}�X�^�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetPosTerminalMg';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetPosTerminalMg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�������[���Ǘ��}�X�^',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�������[���Ǘ��}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    // �󔭒��Ǘ��S�̐ݒ�}�X�^�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '���������i�󔭒��Ǘ��S�̐ݒ�}�X�^',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������i�󔭒��Ǘ��S�̐ݒ�}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    // ����S�̐ݒ�}�X�^�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetSalesTtlSt';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetSalesTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�������i����S�̐ݒ�}�X�^',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�������i����S�̐ݒ�}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �S�̏����l�ݒ�}�X�^�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetAllDefSet';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetAllDefSet);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�������S�̏����l�ݒ�}�X�^',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�������S�̏����l�ݒ�}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ���Џ��ݒ�}�X�^�֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetCompanyInf';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetCompanyInf);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '���������Џ��ݒ�}�X�^',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������Џ��ݒ�}�X�^�֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // ������z�����敪�ݒ�}�X�^���䏈���֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '������������z�����敪�ݒ�}�X�^',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '������������z�����敪�ݒ�}�X�^���䏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �d�����z�����敪�ݒ�}�X�^���䏈���֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_CacheStockProcMoneyListCall';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�������d�����z�����敪�ݒ�}�X�^',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�������d�����z�����敪�ݒ�}�X�^���䏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �|���D��Ǘ��}�X�^���䏈���֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_CacheRateProtyMngListCall';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�������|���D��Ǘ��}�X�^',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�������|���D��Ǘ��}�X�^���䏈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �����敪�}�X�^���X�g�ݒ菈���֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_SettingProcMoney';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_SettingProcMoney);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '�����������敪�}�X�^',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '�����������敪�}�X�^���X�g�ݒ菈���֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreePosTerminalMg';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreePosTerminalMg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '���������������',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '����������������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // -- Add St 2012.07.23 R.Tachiya --
    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '���������������',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '����������������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;
    // -- Add Ed 2012.07.23 R.Tachiya --

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeSalesTtlSt';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeSalesTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '���������������',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '����������������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeAllDefSet';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeAllDefSet);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '���������������',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '����������������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    // �f�[�^����֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeCompanyInf';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeCompanyInf);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '���������������',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '����������������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    //���������֐��A�h���X�擾
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeMessage';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeMessage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '��������������',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '���������������֐��̃A�h���X�擾�Ɏ��s���܂���', nSt, nil, 0);
        Exit;
    end;

    Result := 0;

end;

// �A�N�Z�X�N���X����DLL������\�b�h
procedure FreeLibraryMAHNB01019M(HDllCall1: THDllCall);
begin
    HDllCall1.DllName := 'MAHNB01019M.DLL';
    HDllCall1.HFreeLibrary;
    gpxSalesSlipInputInitDataAcs_ReadInitData := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataSecond := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataThird := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataFourth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataFifth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataSixth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataSeventh := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataEighth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataNinth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataTenth := nil;
    gpxSalesSlipInputInitDataAcs_GetPosTerminalMg := nil;
    gpxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt := nil;// -- Add 2012.07.23 30182 R.Tachiya --
    gpxSalesSlipInputInitDataAcs_GetSalesTtlSt := nil;
    gpxSalesSlipInputInitDataAcs_GetAllDefSet := nil;
    gpxSalesSlipInputInitDataAcs_GetCompanyInf := nil;
    gpxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall := nil;
    gpxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall := nil;
    gpxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall := nil;
    gpxSalesSlipInputInitDataAcs_SettingProcMoney := nil;
    gpxSalesSlipInputInitDataAcs_GetOptInfo := nil;
    gpxSalesSlipInputInitDataAcs_GetYamagataOptInfo := nil; // ADD 2012/12/21 T.Miyamoto

    gpxSalesSlipInputInitDataAcs_FreePosTerminalMg := nil;
    gpxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt := nil;// -- Add 2012.07.23 30182 R.Tachiya --
    gpxSalesSlipInputInitDataAcs_FreeSalesTtlSt := nil;
    gpxSalesSlipInputInitDataAcs_FreeAllDefSet := nil;
    gpxSalesSlipInputInitDataAcs_FreeCompanyInf := nil;
    gpxSalesSlipInputInitDataAcs_FreeMessage := nil;
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
        LoadLibraryMAHNB01019M(DataModule1.HDllCall1);
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
    FreeLibraryMAHNB01019M(DataModule1.HDllCall1);

    DataModule1.Free;
    DataModule1 := nil;
  end;

end.
