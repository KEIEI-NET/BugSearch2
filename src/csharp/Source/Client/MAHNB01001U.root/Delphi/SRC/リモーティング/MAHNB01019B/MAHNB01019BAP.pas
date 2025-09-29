unit MAHNB01019BAP;

interface

uses ShareMem, SysUtils, HFSLLIB, MAHNB01019C,
    MAHNB01019BMP, messages, classes, windows, controls, dialogs;

/////////////// Delphi���ւ̃G�N�X�|�[�g�֐��錾 //////////////////////////


// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitData(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // �I�v�V������񏈗�
function MAHNB01019B_GetOptInfo(var optCarMng: Integer;
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
    // �R�`���i�I�v�V������񏈗�
function MAHNB01019B_GetYamagataOptInfo(var optStockEntCtrl: Integer;
                                        var optStockDateCtrl: Integer;
                                        var optSalesCostCtrl: Integer
                                       ) : Integer; stdcall;
// --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataSecond(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;


// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataThird(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataFourth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataFifth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataSixth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataSeventh(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataEighth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataNinth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataTenth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;


// �[���Ǘ��}�X�^
function MAHNB01019B_GetPosTerminalMg(var posTerminalMg: TPosTerminalMg)
    : Integer; stdcall;

// -- Add St 2012.07.23 30182 R.Tachiya --
// �󔭒��Ǘ��S�̐ݒ�}�X�^
function MAHNB01019B_GetAcptAnOdrTtlSt(var acptAnOdrTtlSt: TAcptAnOdrTtlSt)
    : Integer; stdcall;
// -- Add Ed 2012.07.23 30182 R.Tachiya --

// ����S�̐ݒ�}�X�^
function MAHNB01019B_GetSalesTtlSt(var salesTtlSt: TSalesTtlSt)
    : Integer; stdcall;


// �S�̏����l�ݒ�}�X�^
function MAHNB01019B_GetAllDefSet(var allDefSet: TAllDefSet)
    : Integer; stdcall;


// ���Џ��ݒ�}�X�^
function MAHNB01019B_GetCompanyInf(var companyInf: TCompanyInf)
    : Integer; stdcall;

// ������z�����敪�ݒ�}�X�^���䏈��
function MAHNB01019B_CacheSalesProcMoneyListCall()
    : Integer; stdcall;


// �d�����z�����敪�ݒ�}�X�^���䏈��
function MAHNB01019B_CacheStockProcMoneyListCall()
    : Integer; stdcall;


// �|���D��Ǘ��}�X�^���䏈��
function MAHNB01019B_CacheRateProtyMngListCall()
    : Integer; stdcall;


// �����敪�}�X�^���X�g�ݒ菈��
function MAHNB01019B_SettingProcMoney()
    : Integer; stdcall;


implementation

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitData(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitData(enterpriseCode, sectionCode);
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

// �I�v�V������񏈗�
function MAHNB01019B_GetOptInfo(var optCarMng: Integer;
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

var
    status: Integer;
    resultOptCarMng: Integer;
    resultOptFreeSearch: Integer;
    resultOptPcc: Integer;
    resultOptRCLink: Integer;
    resultOptUoe: Integer;
    resultOptStockingPayment: Integer;
    resultOptScm: Integer;
    resultOpt_QRMail: Integer;
    resultOpt_DateCtrl: Integer; // ADD T.Miyamoto 2012/11/13
    resultOpt_NoBuTo: Integer; // ADD 杍^ K2014/01/22

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    optCarMng := 0;
    optFreeSearch := 0;
    optPcc := 0;
    optRCLink := 0;
    optUoe := 0;
    optStockingPayment := 0;
    optScm := 0;
    opt_QRMail := 0;
    opt_DateCtrl := 0; // ADD T.Miyamoto 2012/11/13
    opt_NoBuTo := 0; // ADD 杍^ K2014/01/22

    try
        try
            // ���ʃf�[�^��������
            resultOptCarMng := 0;
            resultOptFreeSearch := 0;
            resultOptPcc := 0;
            resultOptRCLink := 0;
            resultOptUoe := 0;
            resultOptStockingPayment := 0;
            resultOptScm := 0;
            resultOpt_QRMail := 0;
            resultOpt_DateCtrl := 0; // ADD T.Miyamoto 2012/11/13
            resultOpt_NoBuTo := 0; // ADD 杍^ K2014/01/22

            // �������\�b�h�ďo��
            // UPD T.Miyamoto 2012/11/13 ------------------------------>>>>>
            //status := gpxSalesSlipInputInitDataAcs_GetOptInfo(resultOptCarMng, resultOptFreeSearch, resultOptPcc, resultOptRCLink, resultOptUoe, resultOptStockingPayment, resultOptScm, resultOpt_QRMail);
            //status := gpxSalesSlipInputInitDataAcs_GetOptInfo(resultOptCarMng, resultOptFreeSearch, resultOptPcc, resultOptRCLink, resultOptUoe, resultOptStockingPayment, resultOptScm, resultOpt_QRMail, resultOpt_DateCtrl);  // DEL 杍^ K2014/01/22
            status := gpxSalesSlipInputInitDataAcs_GetOptInfo(resultOptCarMng, resultOptFreeSearch, resultOptPcc, resultOptRCLink, resultOptUoe, resultOptStockingPayment, resultOptScm, resultOpt_QRMail, resultOpt_DateCtrl, resultOpt_NoBuTo);  // ADD 杍^ K2014/01/22
            // UPD T.Miyamoto 2012/11/13 ------------------------------<<<<<
            // ���ʃR�s�[
            optCarMng := resultOptCarMng;
            optFreeSearch := resultOptFreeSearch;
            optPcc := resultOptPcc;
            optRCLink := resultOptRCLink;
            optUoe := resultOptUoe;
            optStockingPayment := resultOptStockingPayment;
            optScm := resultOptScm;
            opt_QRMail := resultOpt_QRMail;
            opt_DateCtrl := resultOpt_DateCtrl; // ADD T.Miyamoto 2012/11/13
            opt_NoBuTo := resultOpt_NoBuTo; // ADD 杍^ K2014/01/22

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

// --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    // �R�`���i�I�v�V������񏈗�
function MAHNB01019B_GetYamagataOptInfo(var optStockEntCtrl: Integer;
                                        var optStockDateCtrl: Integer;
                                        var optSalesCostCtrl: Integer
                                       ) : Integer; stdcall;

var
    status: Integer;
    resultOptStockEntCtrl: Integer;
    resultOptStockDateCtrl: Integer;
    resultOptSalesCostCtrl: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;
    optStockEntCtrl := 0;
    optStockDateCtrl := 0;
    optSalesCostCtrl := 0;

    try
        try
            // ���ʃf�[�^��������
            resultOptStockEntCtrl := 0;
            resultOptStockDateCtrl := 0;
            resultOptSalesCostCtrl := 0;

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputInitDataAcs_GetYamagataOptInfo(resultOptStockEntCtrl
                                                                     ,resultOptStockDateCtrl
                                                                     ,resultOptSalesCostCtrl
                                                                     );
            // ���ʃR�s�[
            optStockEntCtrl := resultOptStockEntCtrl;
            optStockDateCtrl := resultOptStockDateCtrl;
            optSalesCostCtrl := resultOptSalesCostCtrl;

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
// --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataSecond(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataSecond(enterpriseCode, sectionCode);
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

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataThird(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataThird(enterpriseCode, sectionCode);
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

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataFourth(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataFourth(enterpriseCode, sectionCode);
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

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataFifth(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataFifth(enterpriseCode, sectionCode);
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

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataSixth(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataSixth(enterpriseCode, sectionCode);
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

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataSeventh(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataSeventh(enterpriseCode, sectionCode);
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

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataEighth(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataEighth(enterpriseCode, sectionCode);
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

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataNinth(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataNinth(enterpriseCode, sectionCode);
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

// ������͂Ŏg�p���鏉���f�[�^���c�a���擾
function MAHNB01019B_ReadInitDataTenth(enterpriseCode: WideString;
    sectionCode: WideString)
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
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataTenth(enterpriseCode, sectionCode);
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

// �[���Ǘ��}�X�^
function MAHNB01019B_GetPosTerminalMg(var posTerminalMg: TPosTerminalMg)
    : Integer; stdcall;

var
    status: Integer;
    resultPosTerminalMg: TPosTerminalMg;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTPosTerminalMg(resultPosTerminalMg);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputInitDataAcs_GetPosTerminalMg(resultPosTerminalMg);
            // ���ʃR�s�[
            posTerminalMg := resultPosTerminalMg;

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

// -- Add St 2012.07.23 30182 R.Tachiya --
// �󔭒��Ǘ��S�̐ݒ�}�X�^
function MAHNB01019B_GetAcptAnOdrTtlSt(var acptAnOdrTtlSt: TAcptAnOdrTtlSt)
    : Integer; stdcall;

var
    status: Integer;
    resultAcptAnOdrTtlSt: TAcptAnOdrTtlSt;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTAcptAnOdrTtlSt(resultAcptAnOdrTtlSt);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt(resultAcptAnOdrTtlSt);
            // ���ʃR�s�[
            acptAnOdrTtlSt := resultAcptAnOdrTtlSt;

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
// -- Add Ed 2012.07.23 30182 R.Tachiya --

// ����S�̐ݒ�}�X�^
function MAHNB01019B_GetSalesTtlSt(var salesTtlSt: TSalesTtlSt)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesTtlSt: TSalesTtlSt;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTSalesTtlSt(resultSalesTtlSt);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputInitDataAcs_GetSalesTtlSt(resultSalesTtlSt);
            // ���ʃR�s�[
            salesTtlSt := resultSalesTtlSt;

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

// �S�̏����l�ݒ�}�X�^
function MAHNB01019B_GetAllDefSet(var allDefSet: TAllDefSet)
    : Integer; stdcall;

var
    status: Integer;
    resultAllDefSet: TAllDefSet;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTAllDefSet(resultAllDefSet);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputInitDataAcs_GetAllDefSet(resultAllDefSet);
            // ���ʃR�s�[
            allDefSet := resultAllDefSet;

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

// ���Џ��ݒ�}�X�^
function MAHNB01019B_GetCompanyInf(var companyInf: TCompanyInf)
    : Integer; stdcall;

var
    status: Integer;
    resultCompanyInf: TCompanyInf;

    I: Integer;
begin
    // �߂�X�e�[�^�X������
    Result := -1;

    try
        try
            // ���ʃf�[�^��������
            ClearTCompanyInf(resultCompanyInf);

            // �������\�b�h�ďo��
            status := gpxSalesSlipInputInitDataAcs_GetCompanyInf(resultCompanyInf);
            // ���ʃR�s�[
            companyInf := resultCompanyInf;

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

// ������z�����敪�ݒ�}�X�^���䏈��
function MAHNB01019B_CacheSalesProcMoneyListCall()
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
            status := gpxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall();
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

// �d�����z�����敪�ݒ�}�X�^���䏈��
function MAHNB01019B_CacheStockProcMoneyListCall()
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
            status := gpxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall();
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

// �|���D��Ǘ��}�X�^���䏈��
function MAHNB01019B_CacheRateProtyMngListCall()
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
            status := gpxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall();
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

// �����敪�}�X�^���X�g�ݒ菈��
function MAHNB01019B_SettingProcMoney()
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
            status := gpxSalesSlipInputInitDataAcs_SettingProcMoney();
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


end.
