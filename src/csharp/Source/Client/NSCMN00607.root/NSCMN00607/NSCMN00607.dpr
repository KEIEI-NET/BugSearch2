library NSCMN00607;

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
  SysUtils,
  Classes,
  NSCMN00607CP in 'NSCMN00607CP.pas',
  NSCMN00607CT in 'NSCMN00607CT.pas';

{$R *.res}
exports
  ApplicationStartControl,
  StartApplication,
  EndApplication;

begin
end.
