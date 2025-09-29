//**********************************************************************//
// System           :   システム共通                                    //
// Sub System       :   HSS100部品                                      //
// Program name     :   DLLコールコンポ                                 //
//                  :   HDLLCALL                                        //
// Programer        :   iwamoto　                                       //
// Date             :   20090810                                        //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//**********************************************************************//
unit HDllCall;

{$DEFINE HREG}

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  HVersion;

type
TLoadInfo = record
  DllNm:  string;
  Hins:	  LongInt;
end;

{
-----------------------------------------------------------------------
	THDllCallｵﾌﾞｼﾞｪｸﾄ定義
-----------------------------------------------------------------------
}
THDllCall = class(TComponent)
private
  { Private 宣言 }
  FVersion :	TVersion;
  FDllName:	string;
  FProcName:	string;
  FCount:		SmallInt;
  FInsHandle:	THandle;
protected
  { Protected 宣言 }
  LoadInfo:	array of TLoadInfo;					{ ﾛｰﾄﾞ中ﾓｼﾞｭｰﾙ情報構造体}
  LoadCount:	SmallInt;							{ ﾛｰﾄﾞ中ﾓｼﾞｭｰﾙ数}
  procedure   WMCLOSE(var msg:TWMCLOSE);message WM_CLOSE;
public
  { Public 宣言 }
  constructor Create(AOwner:TComponent); override;
  destructor  Destroy; override;
  procedure	SetDllName(Value:string);
  procedure	SetProcName(Value:string);
  procedure	SetCount(Value:SmallInt);
  function	HLoadLibrary:SmallInt;
  function	HFreeLibrary:SmallInt;
  procedure	HAllFreeLibrary;
  function	HGetPAdr(var fpProc:FARPROC):SmallInt;
published
  { Published 宣言 }
  property	Version: TVersion  read FVersion  write FVersion stored False;
  property	DllName: string    read FDllName  write SetDllName;
  property	ProcName:string    read FProcName write SetProcName;
  property	Count:   SmallInt  read FCount    write SetCount;
  property	InsHandle:THandle  read FInsHandle;
end;

{ ﾌﾟﾛｼｰｼﾞｬ、関数宣言 }
{$IFNDEF HREG}
  procedure Register;
{$ENDIF}

// DLL側特殊エラーをハンドリングする為の関数群
procedure SetCallLastError(inErrCd: integer);
function GetCallLastError:integer;

implementation
uses
  HReg;

const
  ctDLL_EXT = '.DLL';                                                // デフォルト拡張子

var
  gnLastErrorCd :integer = 0;


{$IFNDEF HREG}
  procedure Register;
  begin
    RegisterComponents('HSS', [THDllCall]);
  end;
{$ENDIF}

{
---------------------------------------------------------------------------
	特殊エラー設定関数
---------------------------------------------------------------------------
}
procedure SetCallLastError(inErrCd: integer);
begin
  gnLastErrorCd := inErrCd;
end;
{
---------------------------------------------------------------------------
	特殊エラー取得関数
---------------------------------------------------------------------------
}
function GetCallLastError:integer;
begin
  Result := gnLastErrorCd;
end;

{
---------------------------------------------------------------------------
	THDllCall    ｺﾝｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}
constructor THDllCall.Create(AOwner:TComponent);
begin
  { 派生元呼び出し }
  inherited Create(AOwner);
  FVersion     := HDllCallVersion;

  { ﾒﾝﾊﾞ初期化 }
  LoadCount := 0;
  FCount := 20;
end;

{
---------------------------------------------------------------------------
	THDllCall    ﾃﾞｽﾄﾗｸﾀ
---------------------------------------------------------------------------
}
destructor THDllCall.Destroy;
begin
  if not (csDesigning in ComponentState) then
  begin
    HAllFreeLibrary;
  end;
  { 派生元呼び出し }
  inherited Destroy;
end;

{
---------------------------------------------------------------------------
	THDllCall  DllNameﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure THDllCall.SetDllName(Value:string);
var
  strExtType  : string;

begin

  if FDllName <> Value then
    FDllName := Value;

  // ファイル拡張子のデフォルトを設定する                                       2001.03.08 追加
  strExtType := ExtractFileExt(FDllName);
  if Trim(strExtType) = '' then begin
    FDllName := FDllName + ctDLL_EXT;
  end;

end;

{
---------------------------------------------------------------------------
	THDllCall  ProcNameﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure THDllCall.SetProcName(Value:string);
begin
  if FProcName <> Value then
    FProcName := Value;
end;

{
---------------------------------------------------------------------------
	THDllCall  Countﾌﾟﾛﾊﾟﾃｨの設定
---------------------------------------------------------------------------
}
procedure THDllCall.SetCount(Value:SmallInt);
begin
  if FCount <> Value then
    FCount := Value;
end;

{
---------------------------------------------------------------------------
	THDllCall  HLoadLibraryﾒｿｯﾄﾞ
---------------------------------------------------------------------------
}
function THDllCall.HLoadLibrary:SmallInt;
var
	szDName:	array[0..255] of Char;
	ix:			integer;
begin

  try

  	 if LoadInfo = nil then
  	   {動的配列確保}
  		 SetLength(LoadInfo,FCount);

      if FCount <= LoadCount then begin
        Inc(FCount,10);
      {動的配列確保}
      SetLength(LoadInfo,FCount);
    end;

  except

    Result := GetLastError;

  end;

	FInsHandle   := 0;
	Result := 0;
	ZeroMemory(@szDName,sizeof(szDName));
	StrPCopy(@szDName,FDllName);

	//すでにﾛｰﾄﾞ済みかどうかのﾁｪｯｸ
	for ix:=0 to LoadCount-1 do
	begin
		if UpperCase(FDllName) = UpperCase(LoadInfo[ix].DllNm) then begin
			FInsHandle := LoadInfo[ix].hIns;
			break;
		end;
	end;

	if FInsHandle <> 0 then
		Exit;

	//DLLのﾛｰﾄﾞ
 try
   gnLastErrorCd := 0;
  	FInsHandle := LoadLibrary(szDName);
   if (FInsHandle = 0) or (gnLastErrorCd <>0) then begin
     if FInsHandle <> 0 then begin
       Result := gnLastErrorCd;
     end else begin
       Result := GetLastError;
     end;

     //ﾛｰﾄﾞ失敗
     FInsHandle := 0;

   end else begin

     //ﾛｰﾄﾞﾓｼﾞｭｰﾙ情報保存
     LoadInfo[LoadCount].DllNm := FDllName;
     LoadInfo[LoadCount].hIns  := FInsHandle;
     Inc(LoadCount);

   end;

	except
   FInsHandle := 0;
   Result := GetLastError;
 end;

end;

{
---------------------------------------------------------------------------
	THDllCall  HFreeLibraryﾒｿｯﾄﾞ
---------------------------------------------------------------------------
}
function THDllCall.HFreeLibrary:SmallInt;
var
	ix:		integer;
begin

	Result := -1;

	//すでにﾛｰﾄﾞ済みかどうかのﾁｪｯｸ
	for ix:=0 to LoadCount-1 do begin

		if UpperCase(FDllName) = UpperCase(LoadInfo[ix].DllNm) then begin
     try
  			FreeLibrary(LoadInfo[ix].hIns);
     finally
       FInsHandle := 0;
  			LoadInfo[ix].hIns := 0;
	   		LoadInfo[ix].DllNm:= '';
  			Result := 0;
     end;
			break;
		end;

	end;

end;

{
---------------------------------------------------------------------------
	THDllCall  HAllFreeLibraryﾒｿｯﾄﾞ
---------------------------------------------------------------------------
}
procedure THDllCall.HAllFreeLibrary;
var
	ix:		integer;
begin

	for ix:=LoadCount-1 downto 0 do	begin

		if LoadInfo[ix].hIns = 0 then
			continue;
   try
  		FreeLibrary(LoadInfo[ix].hIns);
   finally
  		LoadInfo[ix].hIns := 0;
 		LoadInfo[ix].DllNm:= '';
   end;

	end;

end;

{
---------------------------------------------------------------------------
	THDllCall  HGetPAdrﾒｿｯﾄﾞ
---------------------------------------------------------------------------
}
function THDllCall.HGetPAdr(var fpProc:FARPROC):SmallInt;
var
	ix:		integer;
	szProcName:	array[0..255] of Char;
begin

	Result := 0;
	FInsHandle := 0;

	//DLLのﾊﾝﾄﾞﾙ取得
	for ix:=0 to LoadCount-1 do	begin

		if UpperCase(FDllName) = UpperCase(LoadInfo[ix].DllNm) then begin
			FInsHandle := LoadInfo[ix].hIns;
			break;
		end;

	end;

	//関数のﾊﾝﾄﾞﾙ取得
 try
  	ZeroMemory(@szProcName,sizeof(szProcName));
  	StrPCopy(@szProcName,FProcName);
  	fpProc := GetProcAddress(FInsHandle,szProcName);

 finally

  	if fpProc = nil then
  		Result := GetLastError;

 end;

end;

procedure THDllCall.WMCLOSE(var msg:TWMCLOSE);
begin
  inherited;
  HAllFreeLibrary;
end;

end.

