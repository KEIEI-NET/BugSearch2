library MAHNB01019B;

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
  MAHNB01019BAP in 'MAHNB01019BAP.pas',
  MAHNB01019BMP in 'MAHNB01019BMP.pas' {DataModule1: TDataModule};

{$R *.res}

exports
    MAHNB01019B_ReadInitData,
    MAHNB01019B_ReadInitDataSecond,
    MAHNB01019B_ReadInitDataThird,
    MAHNB01019B_ReadInitDataFourth,
    MAHNB01019B_ReadInitDataFifth,
    MAHNB01019B_ReadInitDataSixth,
    MAHNB01019B_ReadInitDataSeventh,
    MAHNB01019B_ReadInitDataEighth,
    MAHNB01019B_ReadInitDataNinth,
    MAHNB01019B_ReadInitDataTenth,
    MAHNB01019B_GetPosTerminalMg,
    MAHNB01019B_GetAcptAnOdrTtlSt,// -- Add 2012.07.23 30182 R.Tachiya --
    MAHNB01019B_GetSalesTtlSt,
    MAHNB01019B_GetAllDefSet,
    MAHNB01019B_GetCompanyInf,
    MAHNB01019B_CacheSalesProcMoneyListCall,
    MAHNB01019B_CacheStockProcMoneyListCall,
    MAHNB01019B_CacheRateProtyMngListCall,
    MAHNB01019B_GetOptInfo,
    MAHNB01019B_GetYamagataOptInfo, // ADD 2012/12/21 T.Miyamoto
    MAHNB01019B_SettingProcMoney;

begin
end.
