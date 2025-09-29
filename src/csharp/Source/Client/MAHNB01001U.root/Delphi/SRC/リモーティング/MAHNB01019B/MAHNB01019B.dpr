library MAHNB01019B;

{ DLL のメモリ管理に関する重要な注意：
  もしこの DLL が引数や返り値として String 型を使う関数/手続きをエクスポー
  トする場合、以下の USES 節とこの DLL を使うプロジェクトソースの USES 節
  の両方に、最初に現れるユニットとして ShareMem を指定しなければなりません。
  （プロジェクトソースはメニューから[プロジェクト｜ソース表示] を選ぶこと
  で表示されます）
  これは構造体やクラスに埋め込まれている場合も含め String 型を DLL とやり
  取りする場合に必ず必要となります。
  ShareMem は共用メモリマネージャである BORLNDMM.DLL とのインターフェース
  です。あなたの DLL と一緒に配布する必要があります。BORLNDMM.DLL を使うの
  を避けるには、PChar または ShortString 型を使って文字列のやり取りをおこ
  なってください。}

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
