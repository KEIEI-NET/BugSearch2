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
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2010/06/16  �C�����e : �I�t���C���Ή��̑g��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2010/08/30  �C�����e : �ŗ��ݒ�͈̓`�F�b�N�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2011/02/01  �C�����e : SCM��񑶍݃`�F�b�N�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2011/03/04  �C�����e : SCM��񑶍݃`�F�b�N�����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011/04/13  �C�����e : ���ו����I���s���폜�\�Ƃ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10703874-00 �쐬�S�� : yangyi
// �� �� ��  K2011/08/12 �C�����e : �C�X�R�ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ����g
// �� �� ��  2011/08/18  �C�����e : �A��729 ���ד\�t�t�@���N�V�����{�^����ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�10704766-00   �쐬�S�� : ���v��
// �� �� ��  2011/11/22  �C�����e : Redmine#8037
//			                            BL�߰µ��ް�@�݌Ɋm�F���������̃f�[�^�Z�b�g�̎d�l�ύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���c �N�v
// �� �� ��  2012/05/31  �C�����e : ��QNo.282
//                                  �����I���̎��ɁuESC�v�L�[���������邱�ƂŔ�����������������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/03/28  �C�����e : SCM��QNo.192�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070100-00 �쐬�S�� : �{�{ ����
// �� �� ��  2014/07/15  �C�����e : �d�|�ꗗ ��1912
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100713-00 �쐬�S�� : ���t
// �� �� ��  K2015/04/01 �C�����e : �X�암�i�ʈ˗��̉��Ǎ�ƑS���_�݌ɏ��ꗗ�@�\�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100543-00 �쐬�S�� : �����M
// �� �� ��  K2015/04/29 �C�����e : �x�m�W�[���C������ UOE�捞�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11101427-00 �쐬�S�� : �I��
// �� �� ��  K2015/06/18 �C�����e : �����C�S�@WebUOE�����񓚎捞�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170204-00 �쐬�S�� : �{�{ ����
// �� �� ��  2015/12/09  �C�����e : �����`��Q�Ή� Redmine#47670
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11202099-00  �쐬�S�� : 杍^
// �� �� ��  K2016/11/01  �C�����e : ����`�[���͂���O��PG���N�����Ĕ��P�����Z�o�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11202452-00  �쐬�S�� : 杍^
// �� �� ��  K2016/12/30  �C�����e : ���쏤�H�l�ʕύX���e��PM.NS�ɂĎ������邽�߁A��񔄉��̑Ή��s���܂��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470152-00  �쐬�S�� : 杍^
// �� �� ��  2018/09/04   �C�����e : ���������\���@�\�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00  �쐬�S�� : 杍^
// �� �� ��  2020/02/24   �C�����e : ����Őŗ��@�\�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870080-00  �쐬�S�� : ���O
// �� �� ��  2022/04/26  �C�����e : PMKOBETSU-4208 �d�q����Ή�
//----------------------------------------------------------------------------//

  library MAHNB01013B;

{ DLL �̃������Ǘ��Ɋւ���d�v�Ȓ��ӁF
  �������� DLL ��������Ԃ�l�Ƃ��� String �^���g���֐�/�葱�����G�N�X�|�[
  �g����ꍇ�A�ȉ��� USES �߂Ƃ��� DLL ���g���v���W�F�N�g�\�[�X�� USES ��
  �̗����ɁA�ŏ��Ɍ���郆�j�b�g�Ƃ��� ShareMem ���w�肵�Ȃ���΂Ȃ�܂���B
  �i�v���W�F�N�g�\�[�X�̓��j���[����[�v���W�F�N�g�b�\�[�X�\��] ��I�Ԃ���
  �ŕ\������܂��j
  ����͍\���̂�N���X�ɖ��ߍ��܂�Ă���ꍇ���܂� String �^�� DLL �Ƃ��
  ��肷��ꍇ�ɕK���K�v�ƂȂ�܂��B
  ShareMem �͋��p�������}�l�[�W���ł��� BORLNDMM.DLL �Ƃ̃C���^�[�t�F�[�X
  �ł��B���Ȃ��� DLL �ƈꏏ�ɔz�z����K�v������܂��BBORLNDMM.DLL ���g����
  �������ɂ́APChar �܂��� ShortString �^���g���ĕ�����̂���������
  �Ȃ��Ă��������B}

uses
  ShareMem,
  SysUtils,
  Classes,
  MAHNB01013BAP in 'MAHNB01013BAP.pas',
  MAHNB01013BMP in 'MAHNB01013BMP.pas' {DataModule1: TDataModule};

{$R *.res}

exports
    MAHNB01013B_Clear,
    MAHNB01013B_Close,
    MAHNB01013B_GetDisplayCustomerInfo,
    MAHNB01013B_ShipmentAddUp,
    MAHNB01013B_GetSalesHisGuide,
    MAHNB01013B_GetItemtSalesSlipCd,
    MAHNB01013B_GetAddInfoVisible,
    MAHNB01013B_GetDisplayHeaderFooterInfo,
    MAHNB01013B_GetSalesHisGuide,
    MAHNB01013B_GetInitData,
    MAHNB01013B_GetNoteGuidList,
    MAHNB01013B_customerGuide,
    MAHNB01013B_InitMstCheck,
    MAHNB01013B_Retry,
    MAHNB01013B_RetryResult,
    MAHNB01013B_ShowSalesSlipInputSetup,
    MAHNB01013B_salesSlipGuide,
    MAHNB01013B_SetUserGdBdComboEditor,
    MAHNB01013B_GetCellEnabled,
    MAHNB01013B_GetDisplayName,
    MAHNB01013B_salesSlipGuide,
    MAHNB01013B_GetDetailGrossProfitRate,
    MAHNB01013B_Delete,
    MAHNB01013B_GetItemName,
    MAHNB01013B_GetStatus,
    MAHNB01013B_GetBeforeSalesSlipNumText,
    MAHNB01013B_GetFocusPositionValue,
    MAHNB01013B_GetBeforeSalesSlipNumText,
    MAHNB01013B_AcceptAnOrderReferenceSearch,
    MAHNB01013B_AcceptAnOrderAddup,
    MAHNB01013B_EstimateReferenceSearch,
    MAHNB01013B_EstimateAddup,
    MAHNB01013B_SalesReferenceSearch,
    MAHNB01013B_CopySlip,
    MAHNB01013B_GetOptCarMng,
    MAHNB01013B_RedSlip,
    MAHNB01013B_GetCanRed,
    MAHNB01013B_GetRedDialogResult,
    MAHNB01013B_CopySlipHeader,
    MAHNB01013B_CopySlipDetail,    // ADD �A��729 2011/08/18
    MAHNB01013B_AfterCarMngNoGuideReturn,
    MAHNB01013B_GetRedDialogResult,
    MAHNB01013B_SetNoteCharCnt,
    MAHNB01013B_ReturnSlip,
    MAHNB01013B_ShowSaveCheckDialog,
    MAHNB01013B_Save,
    MAHNB01013B_afterSave,
    MAHNB01013B_GetSaveStatus,
    MAHNB01013B_GetOnlineKindDiv, // ADD 2015/12/09 T.Miyamoto �����`��Q�Ή� Redmine#47670
    MAHNB01013B_setToolMenuCustomizeSetting,
    MAHNB01013B_getToolMenuCustomizeSetting,
    MAHNB01013B_setToolButtonCustomizeSetting,
    MAHNB01013B_getToolButtonCustomizeSetting,
    MAHNB01013B_SaveToolbarCustomizeSetting,
    MAHNB01013B_SaveToolManagerCustomizeInfo,
    MAHNB01013B_SaveCustomizeXml,
    MAHNB01013B_GetSaveStatus,
    MAHNB01013B_ChangeSearchMode,
    MAHNB01013B_GetSearchPartsModeProperty,
    MAHNB01013B_ReNewalBtnClick,
    MAHNB01013B_ProcessingDialogDispose,
    MAHNB01013B_GetUltraOptionSetValue,
    MAHNB01013B_SlipNoteGuide,
    MAHNB01013B_SalesPriceChanged,
    MAHNB01013B_CarInfoFormSetting,
    MAHNB01013B_ShowRedSaveCheckDialog,
    MAHNB01013B_uButtonGuideClick,
    MAHNB01013B_SetItemsDictionary,
    MAHNB01013B_GetNextMovePosition,
    MAHNB01013B_GetPreMovePosition,
    MAHNB01013B_GetParam,
    MAHNB01013B_GetEffectiveJudgment,
    MAHNB01013B_GetSalesDetailDataTable,
    MAHNB01013B_GetSalesAllDetailDataTable,
    MAHNB01013B_SetSalesDetailData,
    MAHNB01013B_AfterGoodsNoUpdate,
    MAHNB01013B_uButtonLineDiscountClick,
    MAHNB01013B_uButtonGoodsDiscountClick,
    MAHNB01013B_uButtonAnnotationClick,
    MAHNB01013B_uButtonChangeWarehouseClick,
    MAHNB01013B_uButtonStockSearchClick,
    MAHNB01013B_uButtonTBOClick,
    MAHNB01013B_uButtonCopyStockBefLineClick,
    MAHNB01013B_uButtonCopyStockAllLineClick,
    MAHNB01013B_uGridDetailsAfterCellUpdate,
    MAHNB01013B_uGridDetailsAfterCellUpdateProc,
    MAHNB01013B_GridJoinCheck,
    MAHNB01013B_DeatilActionTable,
    MAHNB01013B_AfterPartySaleSlipNumFocus,
    MAHNB01013B_CheckDetailAction,
    MAHNB01013B_GetSalesSlipInputConstructionData,
    MAHNB01013B_retGoodsReason,
    MAHNB01013B_SetSlipMemo,
    MAHNB01013B_KeyPressNumCheck,
    MAHNB01013B_CsvPassCheck,
    MAHNB01013B_uButtonEscClick,
    MAHNB01013B_setColDisplayStatusList,
    MAHNB01013B_GetReadSlipFlg,
    MAHNB01013B_SetSalesSlip,
    //----ADD 2010/11/02----->>>>>
    MAHNB01013B_SetSalesSlipByObj,
    //----ADD 2010/11/02-----<<<<<
    MAHNB01013B_FormPosSerialize,
    MAHNB01013B_FormPosDeserialize,
    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    MAHNB01013B_MakeQR,
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    MAHNB01013B_GetOnlineFlag,
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<
    MAHNB01013B_setColDisplayStatusList,
    MAHNB01013B_ReferenceList // 2010/05/30
   ,MAHNB01013B_HisSearch // ADD�@2018/09/04 杍^�@���������\���̑Ή�
   //----- ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�------->>>>>
   ,MAHNB01013B_GetTaxRateDialogResult
   ,MAHNB01013B_GetTaxRate
   ,MAHNB01013B_OrderCheck
   //----- ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�-------<<<<<
   ,MAHNB01013B_StartEBooks // ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�
   ,MAHNB01013B_SettingParameter // 2010/05/30
   ,MAHNB01013B_TimerSCMReadTick // 2010/05/30
   ,MAHNB01013B_GetSobaInfo // 2010/05/30;
   ,MAHNB01013B_GetGrossProfitRateFlg   // 2010/07/16
   ,MAHNB01013B_GetBitButtonCustomizeSetting  // 2010/08/13
   ,MAHNB01013B_SmallPointProc   // 2010/08/23
   ,MAHNB01013B_ExistTaxRateRangeMethod // 2010/08/30
   ,MAHNB01013B_SetHomeKeyFlg // 2010/09/14
   ,MAHNB01013B_ExistSCMInfo // 2011/02/01
   ,MAHNB01013B_SettingEmpInfo // 2011/03/04
   ,MAHNB01013B_DoAddLine  // 2011/02/12
   ,MAHNB01013B_CooprtKindDiv  // 2011/11/22
   ,MAHNB01013B_DoCacheImage // 2011/02/12
   ,MAHNB01013B_GetErrorFlag // 2011/02/12
   ,MAHNB01013B_DetailDeleteActionTable // 2011/04/13
   ,MAHNB01013B_SetSectionCode // 2011/05/30
   ,MAHNB01013B_StockInfoAdjust // 2011/07/18
   ,MAHNB01013B_BeginControllingByOperationAuthority// ADD 2010/07/08
   ,MAHNB01013B_GetOperationSt // ADD 2014/07/15 T.Miyamoto �d�|�ꗗ ��1912
   ,MAHNB01013B_SetAfterSaveData
   ,MAHNB01013B_GetAfterSaveData
   ,MAHNB01013B_DoAfterSave
   ,MAHNB01013B_ShowStockDateMsg
   // --- ADD �����M 2015/04/29 �񓚎捞�p�^���ǉ� ----->>>>>
   ,MAHNB01013B_ReadUoeData
   ,MAHNB01013B_OptPermitForFuJi
   // --- ADD �����M 2015/04/29 �񓚎捞�p�^���ǉ� -----<<<<<
   // --- ADD �I�� K2015/06/18 WebUOE�����񓚎捞 ----->>>>>
   ,MAHNB01013B_OptPermitForMeiGo
   // --- ADD �I�� K2015/06/18 WebUOE�����񓚎捞 -----<<<<<
   ,MAHNB01013B_OptPermitForEBooks//ADD ���O 2022/04/26 PMKOBETSU-4208 �d�q����Ή�
   // --- UPD 2012/05/31 No.282---------->>>>>
   //,MAHNB01013B_SetInitData;
   ,MAHNB01013B_SetInitData
   // --- UPD 2012/05/31 No.282----------<<<<<
   // --- ADD 2012/05/31 No.282---------->>>>>
   ,MAHNB01013B_uButtonEscClick2
   // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ---------->>>>>
   ,MAHNB01013B_SetSecondSalesUnPrcGideLocation
   ,MAHNB01013B_OptPermitForMizuno2ndSellPriceCtl
   // --- ADD K2016/12/30 杍^ ���쏤�H���@��񔄉� ----------<<<<<
   // ------  ADD K2015/04/01 ���t �X�암�i�ʈ˗�------->>>>>
   ,MAHNB01013B_ReadAllSecStockInfo
   ,MAHNB01013B_OptPermitForMoriKawa
   // ------  ADD K2015/04/01 ���t �X�암�i�ʈ˗�-------<<<<<
   // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- >>>>>
   ,MAHNB01013B_SalesUnPrcCalc
   ,MAHNB01013B_OptPermitForKoei
   // --- ADD 杍^ K2016/11/01 �O��PG�����Z�o�Ή�_���R�[�G�C --- <<<<<
   ,MAHNB01013B_SaveOrderInfo;
   // --- ADD 2012/05/31 No.282----------<<<<<

begin
end.
