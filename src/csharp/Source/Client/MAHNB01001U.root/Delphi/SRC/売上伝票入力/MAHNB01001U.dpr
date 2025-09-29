program MAHNB01001U;

uses
  ShareMem,
  Forms,
  HInitProc,
  MAHNB01001UA in 'MAHNB01001UA.pas' {Form4},
  ReadInitDataThread in '..\..\PAS\ReadInitDataThread.pas',
  MAHNB01012C in '..\..\PAS\MAHNB01012C.pas',
  MAHNB01013C in '..\..\PAS\MAHNB01013C.pas',
  MAHNB01019C in '..\..\PAS\MAHNB01019C.pas',
  ReadInitDataEighthThread in '..\..\PAS\ReadInitDataEighthThread.pas',
  ReadInitDataFifthThread in '..\..\PAS\ReadInitDataFifthThread.pas',
  ReadInitDataFourthThread in '..\..\PAS\ReadInitDataFourthThread.pas',
  ReadInitDataNinthThread in '..\..\PAS\ReadInitDataNinthThread.pas',
  ReadInitDataSecondThread in '..\..\PAS\ReadInitDataSecondThread.pas',
  ReadInitDataSeventhThread in '..\..\PAS\ReadInitDataSeventhThread.pas',
  ReadInitDataSixthThread in '..\..\PAS\ReadInitDataSixthThread.pas',
  ReadInitDataTenthThread in '..\..\PAS\ReadInitDataTenthThread.pas',
  ReadInitDataThirdThread in '..\..\PAS\ReadInitDataThirdThread.pas',
  CalendarGuid in 'CalendarGuid.pas' {CalendarForm};

{$R *.res}

const
  // --- UPD 2012/06/13 T.Nishi ---------->>>>>
  //ctPGID = 'test';
  //ctPGNM = 'test';
  ctPGID = 'MAHNB01001U';
  ctPGNM = 'îÑè„ì`ï[ì¸óÕ';
  // --- UPD 2012/06/13 T.Nishi ----------<<<<<

begin
  // EXEèâä˙èàóù (DLLÇÃèÍçáÇÕ HStrtDll ÇégópÇ∑ÇÈ)
  if HStrtExe(100, ctPGID, ctPGNM, LOGIN_CHECK, ERR_MSG_DISP) <> 0 then
    exit;
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm4, Form4);
  //Application.CreateForm(TCalendarForm, CalendarForm); // DEL 2012/12/17
  Application.Run;
  
  //>>>2010/07/15
  Form4.FreeLib();
  //<<<2010/07/15
  
    // EXEèIóπèàóù
  HEndExe;
end.

