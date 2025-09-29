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
// �Ǘ��ԍ�  10900269-00 �쐬�S�� : FSI���� ���T
// �� �� ��  2013/03/21  �C�����e : SPK�ԑ�ԍ�������Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070071-00 �쐬�S�� : �{�{�@����
// �� �� ��  2014/05/19  �C�����e : �d�|�ꗗ��2218 ���q���l���ɃR�[�h���͍��ڂ�ǉ�
//----------------------------------------------------------------------------//

library MAHNB01012B;

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
  MAHNB01012BAP in 'MAHNB01012BAP.pas',
  MAHNB01012BMP in 'MAHNB01012BMP.pas' {DataModule1: TDataModule};

{$R *.res}

exports
    MAHNB01012B_CarSearch,
    MAHNB01012B_GetCarInfoRow,
    MAHNB01012B_GetColorInfo,
    MAHNB01012B_GetSelectColorInfo,
    MAHNB01012B_GetTrimInfo,
    MAHNB01012B_GetSelectTrimInfo,
    MAHNB01012B_GetEquipInfo,
    MAHNB01012B_SelectColorInfo,
    MAHNB01012B_SelectTrimInfo,
    MAHNB01012B_CheckProduceTypeOfYearRange,
    MAHNB01012B_SettingCarModelUIDataFromFirstEntryDate,
    MAHNB01012B_CheckProduceFrameNo,
    MAHNB01012B_SettingCarModelUIDataFromProduceFrameNo,
    MAHNB01012B_GetProduceTypeOfYear,
    MAHNB01012B_ClearCarInfoRow,
    MAHNB01012B_SettingCarInfoRowFromFirstEntryDate,
    MAHNB01012B_SettingCarInfoRowFromFrameNo,
    MAHNB01012B_SettingCarInfoRowFromModelInfo,
    MAHNB01012B_GetModelFullName,
    MAHNB01012B_GetModelHalfName,
    MAHNB01012B_SettingCarInfoRowFromCarMngCode,
    MAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo,
    MAHNB01012B_SettingCarInfoRowFromFullModel,
    MAHNB01012B_SettingCarInfoRowFromEngineModelNm,
    MAHNB01012B_ExistCarInfo,
    MAHNB01012B_SettingCarInfoRowFromCarNoteCode, // ADD 2014/05/19 T.Miyamoto �d�|�ꗗ��2218
    MAHNB01012B_SettingCarInfoRowFromCarNote,
    MAHNB01012B_SettingCarInfoRowFromMileage,
    // add by gaofeng start
    MAHNB01012B_sectionGuide,
    MAHNB01012B_subSectionGuide,
    MAHNB01012B_employeeGuide,
    MAHNB01012B_carMngNoGuide,
    MAHNB01012B_modelFullGuide,
    MAHNB01012B_slipNote,
    MAHNB01012B_GetRate,
    MAHNB01012B_CalculationSalesPrice,
    // add by gaofeng end

    // add by Zhangkai start
    // add by Zhangkai end

    // add by Lizc start
    MAHNB01012B_AfterMakerCodeFocus,
    MAHNB01012B_AfterModelCodeFocus,
    MAHNB01012B_AfterModelSubCodeFocus,
    MAHNB01012B_AfterModelFullNameFocus,
    MAHNB01012B_AfterFirstEntryDateFocus,
    MAHNB01012B_AfterProduceFrameNoFocus,
    MAHNB01012B_SettingAddInfoVisible,
    MAHNB01012B_GetChangeCarInfoVisible,
    MAHNB01012B_AfterCarMngCodeFocus,
    MAHNB01012B_AfterSectionCodeFocus,
    MAHNB01012B_GetNameFromSubSection,
    MAHNB01012B_ChangeSalesEmployee,
    MAHNB01012B_ChangeFrontEmployee,
    MAHNB01012B_ChangeSalesInput,
    MAHNB01012B_ChangeSalesSlip,
    MAHNB01012B_ChangeSalesGoodsCd,
    MAHNB01012B_AfterCustomerCodeFocus,
    MAHNB01012B_AfterSalesSlipNumFocus,
    MAHNB01012B_SetStateList,
    MAHNB01012B_AfterSalesDateFocus,
    MAHNB01012B_AfterAddresseeCodeFocue,
    MAHNB01012B_CacheForChange,
    MAHNB01012B_CompareSalesSlip,
    MAHNB01012B_ReCalcSalesUnitPrice,
    MAHNB01012B_ClearAllRateInfo,
    MAHNB01012B_AfterSlipNoteCodeFocus,
    MAHNB01012B_AfterSlipNote2CodeFocus,
    MAHNB01012B_AfterSlipNote2Focus, // ADD K2011/08/12
    MAHNB01012B_AfterSlipNote3CodeFocus,
    MAHNB01012B_GetSalesSlip,
    MAHNB01012B_CustomerClaimConfirmationClick,
    MAHNB01012B_AddresseeConfirmationClick,
    MAHNB01012B_ExistSalesDetail,
    MAHNB01012B_ChangeCheckAcptAnOdrStatus,
    MAHNB01012B_ChangeAcptAnOdrStatus,
    MAHNB01012B_Cache,
    MAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay,
    MAHNB01012B_SelectEquipInfo,
    MAHNB01012B_SetGetIsDataChanged,
    MAHNB01012B_GetHeaderFocusConstructionListValue,
    MAHNB01012B_GetFocusConstructionValue,
    MAHNB01012B_GetSectionNm,
    MAHNB01012B_SetGetSearchCarDiv, // ADD 2010/07/16
    MAHNB01012B_GetPrintThreadOverFlag,    // ADD 2012/02/09 ����� Redmine#28289
    // add by Lizc end
    MAHNB01012B_GetSettingOptionInfo,
    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    MAHNB01012B_MakeMailDefaultData,
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // add by Yangmj start
    MAHNB01012B_CreateStockCountInfoString,
    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end
    //MAHNB01012B_CopyToRC; // DEL 2013/03/21
    MAHNB01012B_CopyToRC,   // ADD 2013/03/21
    MAHNB01012B_CheckHandlePosition; // ADD 2013/03/21

begin
end.
