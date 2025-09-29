//**********************************************************************//
// System           :   システム共通                                    //
// Sub System       :   HSS部品                                         //
// Program name     :   ADOアクセス部品                                 //
//                  :   HADOACS.pas                                     //
// Programer        :   kanemaki                                        //
// Date             :   2009.08.13                                      //
//----------------------------------------------------------------------//
// Update Note      :   20090921 SetxxxにTClientDataSetのオーバーライド追加//
// Update Note      :   20091013 コネクション情報取得の認証部品組み込み //
//                  :            このタイミングでHADOACS100廃止         //
//                  :   20091020 ConnectionStringにProvider指定忘れ     //
//                  :   20100423 LocalDB対応     //
//----------------------------------------------------------------------//
//                 (c)Copyright  2009 Broadleaf Co.,Ltd.                //
//**********************************************************************//

unit HADOACS;

interface

uses
  Windows, SysUtils, Classes, Dialogs, ComObj, DB, ADODB, DBClient, HVersion, HDATE,
  HFSLLIB,HInitProc;//20091013 iwa add

type
  EShrSpaceException = class(Exception);

  THADOACS = Class(TComponent)

  private
    FVersion      : TVersion;                     { ﾊﾞｰｼﾞｮﾝ        }

    //>>>>20091013 iwa del start
    //const
    //  ctHADOACS100_DLL = 'HADOACS100.dll';
    //<<<<20091013 iwa del end

    function LoadGetConnectionDll(): Boolean;//20091013 iwa add
  public
    constructor Create(AOwner:TComponent);override;
    destructor Destroy;override;
    function GetConnectionInfo(dbType:Integer; serviceCode:Integer; dbAttribute:Integer) : PChar;
    function OpenSymKey(srcConnection:TADOConnection; dbType:Integer; serviceCode:Integer; dbAttribute:Integer; tableList:array of PChar) : Integer;
    function CloseSymKey(srcConnection:TADOConnection; dbType:Integer; serviceCode:Integer; dbAttribute:Integer; tableList:array of PChar) : Integer;

  published
    property Version   : TVersion read FVersion write FVersion stored False;

End;

procedure Register;

function GetInt16(query:TADOQuery;fieldName:string) : Int16;overload;
function GetInt32(query:TADOQuery;fieldName:string) : Int32;overload;
function GetInt64(query:TADOQuery;fieldName:string) : Int64;overload;
function GetInteger(query:TADOQuery;fieldName:string) : Integer;overload;
function GetShortInt(query:TADOQuery;fieldName:string) : ShortInt;overload;
function GetLongInt(query:TADOQuery;fieldName:string) : LongInt;overload;
function GetDouble(query:TADOQuery;fieldName:string) : Double;overload;
function GetString(query:TADOQuery;fieldName:string) : String;overload;
function GetBytes(query:TADOQuery;fieldName:string) : TBytes;overload;
function GetGuid(query:TADOQuery;fieldName:string) : TGUID;overload;
function GetDateTime(query:TADOQuery;fieldName:string) : TDateTime;overload;
function GetDateTimeFromTicks(query:TADOQuery;fieldName:string) : TDateTime;overload;
function GetDateTimeFromYYYYMM(query:TADOQuery;fieldName:string) : TDateTime;overload;
function GetDateTimeFromYYYYMMDD(query:TADOQuery;fieldName:string) : TDateTime;overload;

function GetInt16(dataSet:TClientDataSet;fieldName:string) : Int16;overload;
function GetInt32(dataSet:TClientDataSet;fieldName:string) : Int32;overload;
function GetInt64(dataSet:TClientDataSet;fieldName:string) : Int64;overload;
function GetInteger(dataSet:TClientDataSet;fieldName:string) : Integer;overload;
function GetShortInt(dataSet:TClientDataSet;fieldName:string) : ShortInt;overload;
function GetLongInt(dataSet:TClientDataSet;fieldName:string) : LongInt;overload;
function GetDouble(dataSet:TClientDataSet;fieldName:string) : Double;overload;
function GetString(dataSet:TClientDataSet;fieldName:string) : String;overload;
function GetBytes(dataSet:TClientDataSet;fieldName:string) : TBytes;overload;
function GetGuid(dataSet:TClientDataSet;fieldName:string) : TGUID;overload;
function GetDateTime(dataSet:TClientDataSet;fieldName:string) : TDateTime;overload;
function GetDateTimeFromTicks(dataSet:TClientDataSet;fieldName:string) : TDateTime;overload;
function GetDateTimeFromYYYYMM(dataSet:TClientDataSet;fieldName:string) : TDateTime;overload;
function GetDateTimeFromYYYYMMDD(dataSet:TClientDataSet;fieldName:string) : TDateTime;overload;

procedure SetInt16(params:TParameters;paramName:string;data:Int16);overload;
procedure SetInt32(params:TParameters;paramName:string;data:Int32);overload;
procedure SetInt64(params:TParameters;paramName:string;data:Int64);overload;
procedure SetInteger(params:TParameters;paramName:string;data:Integer);overload;
procedure SetShortInt(params:TParameters;paramName:string;data:ShortInt);overload;
procedure SetLongInt(params:TParameters;paramName:string;data:LongInt);overload;
procedure SetDouble(params:TParameters;paramName:string;data:Double);overload;
procedure SetString(params:TParameters;paramName:string;data:String);overload;
procedure SetBytes(params:TParameters;paramName:string;data:TBytes);overload;
procedure SetGuid(params:TParameters;paramName:string;data:TGUID);overload;
procedure SetDateTime(params:TParameters;paramName:string;data:TDateTime);overload;
procedure SetDateTimeFromTicks(params:TParameters;paramName:string;data:TDateTime);overload;
procedure SetDateTimeFromYYYYMM(params:TParameters;paramName:string;data:TDateTime);overload;
procedure SetDateTimeFromYYYYMMDD(params:TParameters;paramName:string;data:TDateTime);overload;

//====20090921 iwa add start=========================================
procedure SetInt16(dataSet:TClientDataSet;paramName:string;data:Int16);overload;
procedure SetInt32(dataSet:TClientDataSet;paramName:string;data:Int32);overload;
procedure SetInt64(dataSet:TClientDataSet;paramName:string;data:Int64);overload;
procedure SetInteger(dataSet:TClientDataSet;paramName:string;data:Integer);overload;
procedure SetShortInt(dataSet:TClientDataSet;paramName:string;data:ShortInt);overload;
procedure SetLongInt(dataSet:TClientDataSet;paramName:string;data:LongInt);overload;
procedure SetDouble(dataSet:TClientDataSet;paramName:string;data:Double);overload;
procedure SetString(dataSet:TClientDataSet;paramName:string;data:String);overload;
procedure SetBytes(dataSet:TClientDataSet;paramName:string;data:TBytes);overload;
procedure SetGuid(dataSet:TClientDataSet;paramName:string;data:TGUID);overload;
procedure SetDateTime(dataSet:TClientDataSet;paramName:string;data:TDateTime);overload;
procedure SetDateTimeFromTicks(dataSet:TClientDataSet;paramName:string;data:TDateTime);overload;
procedure SetDateTimeFromYYYYMM(dataSet:TClientDataSet;paramName:string;data:TDateTime);overload;
procedure SetDateTimeFromYYYYMMDD(dataSet:TClientDataSet;paramName:string;data:TDateTime);overload;
//====20090921 iwa add end=========================================

//>>>>200901013 iwa add start
const
  ctMAX_LENGTH            = 256;         // マックスパスレングス

  ctCONSTDLL            = 'NSCMN00615.DLL';
  ctGETCONNECTIONDLL    = 'NSCMN00651.DLL';

  ctSQLServerProvider   = 'Provider=SQLOLEDB.1;';//20091020 iwa add
var
  ghndCST    : THANDLE;
  pConstantManagement_SF_PRO : function (constantManagementkye:string): string; stdcall;
  ghndGCT    : THANDLE;
  pGetConnectionInfo         : function (serviceCode : string ; indexCode : string ):string ; stdcall;

  gDataAttitude : Boolean = False;//True:取得済 False:未取得
  szText:    array [0..ctMAX_LENGTH-1] of Char;

  //☆コネクション文字列グローバル格納領域
  gstConnectData : array[1..2,1..2]of ShortString;

//<<<<20091013 iwa add end

implementation
//>>>>20091013 iwa del start
//var
//   mhDllInst            : HINST;
//   gfpGetConnectionInfo : function (dbType:Integer; serviceCode:Integer; dbAttribute:Integer) : PChar; stdcall;
//   gfpOpenSymKey        : function (srcConnection:TADOConnection; dbType:Integer; serviceCode:Integer; dbAttribute:Integer; tableList:array of PChar) : Integer; stdcall;
//   gfpCloseSymKey       : function (srcConnection:TADOConnection; dbType:Integer; serviceCode:Integer; dbAttribute:Integer; tableList:array of PChar) : Integer; stdcall;
//<<<<20091013 iwa del end

//**********************************************************************//
// Module Name     :  コンポーネント登録処理                            //
//                 :  Register                                          //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  kanemaki                                          //
// Date            :  2009.08.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
procedure Register;
begin
     RegisterComponents('HSS', [THADOACS]);           // HSSページに追加
end;

//*******************************************************************//
// Module Name     :  ADOアクセスクラス 生成                         //
//                 :  THADOACS.Create                                //
// 引数            :  --                                             //
// 戻り値          :  --                                             //
// Programer       :  kanemaki                                       //
// Date            :  2009.08.13                                     //
//-------------------------------------------------------------------//
// Update Note     :                                                 //
//*******************************************************************//
constructor THADOACS.Create(AOwner:TComponent);
begin
  { 派生元呼び出し }
  try
    inherited Create(AOwner);
  except on E:Exception do
    raise EShrSpaceException.Create(E.Message);
  end;

  FVersion     := HADOACSVersion;

  if csDesigning in ComponentState then Exit;

  //>>>>20091013 iwa del start
  // 起動時にDLLをロードする
  //if mhDllInst = 0 then
  //begin
  //  mhDllInst := LoadLibrary(ctHADOACS100_DLL);
  //end;
  //if mhDllInst = 0 then
  //begin
  //  raise EShrSpaceException.Create( ctHADOACS100_DLL + 'のロードに失敗しました');
  //end
  //else
  //begin
  // if @gfpGetConnectionInfo = nil then
  //   gfpGetConnectionInfo := GetProcAddress(mhDllInst, 'HGetConnectionInfo');
  // if @gfpOpenSymKey = nil then
  //   gfpOpenSymKey := GetProcAddress(mhDllInst, 'OpenSymKey');
  // if @gfpCloseSymKey = nil then
  //   gfpCloseSymKey := GetProcAddress(mhDllInst, 'CloseSymKey');

  // ポインタのNULLチェック
  // if (@gfpGetConnectionInfo = nil) or
  //    (@gfpOpenSymKey = nil) or
  //    (@gfpCloseSymKey = nil) then begin
  // raise EShrSpaceException.Create(ctHADOACS100_DLL + 'のバージョンが正しくありません');
  // end;
  //end;
  //<<<<20091013 iwa del end

end;

//*******************************************************************//
// Module Name     :  ADOアクセスクラス 破棄                         //
//                 :  THADOACS.Destroy                               //
// 引数            :  --                                             //
// 戻り値          :  --                                             //
// Programer       :  kanemaki                                       //
// Date            :  2009.08.13                                     //
//-------------------------------------------------------------------//
// Update Note     :                                                 //
//*******************************************************************//
destructor THADOACS.Destroy;
begin
     inherited Destroy;
end;

//*******************************************************************//
// Module Name   : コネクション情報取得処理                          //
//               :                                                   //
// 引数          : 1 Integer     DBタイプ(1:MSSQL,2:ORACLE...)       //
//               : 2 Integer 　  サービスコード 1:Server 2:Local     //
//               : 3 Integer 　  DB属性(1:ユーザー,2:提供)           //
// 戻り値        : 1 String      接続文字列                          //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
// Update        : 20091013 iwa 認証組込＆HADOACS100廃止　　　　　　 //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function THADOACS.GetConnectionInfo(dbType:Integer; serviceCode:Integer; dbAttribute:Integer) : PChar;
var
  connectionStinrg  : PChar;
  szIniPath         : array [0..ctMAX_LENGTH-1] of Char;
  stringPath        : string;
  LoginInf          : tagLoginInf;
  st                : integer;
begin

  //認証情報取得
  HGetLoginInf(LoginInf);

  if  ( LoginInf.nGetflg = 0 )  then //認証できていないならば
  begin
    //===========INIからの取得=================================================

    connectionStinrg := '';
    ZeroMemory(@szIniPath, sizeof(szIniPath));
    stringPath := GetCurrentDir();
    StrPCopy(szIniPath,stringPath);
    if (szIniPath[StrLen(szIniPath)-1] <> '\') then begin
      StrCat(szIniPath, '\');
    end;
    StrCat(szIniPath, 'HADOACS100.ini');

    if(dbType = 1) then
    begin
     if (dbAttribute = 1) then
     begin
       if (GetPrivateProfileString('DB', 'ConnectionString_USERDB', '', szText, sizeof(szText), szIniPath) <> 0) then begin
         connectionStinrg := szText;
       end;
     end;
     if (dbAttribute = 2) then
     begin
       if (GetPrivateProfileString('DB', 'ConnectionString_OFFERDB', '', szText, sizeof(szText), szIniPath) <> 0) then begin
         connectionStinrg := szText;
       end;
     end;
    end;

    Result := connectionStinrg;
    exit;

  end;

  //DLLロード
  if LoadGetConnectionDll() = false then exit;

  //===========認証からの取得=================================================
  if gDataAttitude = false then //コネクションデータを取得していないならば一括取得
  begin
    try
      //User-Server
      //gstConnectData[1,1] := ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_UserAP'),pConstantManagement_SF_PRO('IndexCode_UserDB'))); //20091020 iwa del
      //gstConnectData[1,1] := ctSQLServerProvider + ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_UserAP'),pConstantManagement_SF_PRO('IndexCode_UserDB'))); //20091020 iwa add 20100423 iwa del
      gstConnectData[1,1] := ctSQLServerProvider + ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_Local_UserAP'),pConstantManagement_SF_PRO('IndexCode_Local_UserDB'))); //20100423 iwa add
      //User-Local
      //gstConnectData[1,2] := ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_Local_UserAP'),pConstantManagement_SF_PRO('IndexCode_Local_UserDB')));
      //gstConnectData[1,2] := ctSQLServerProvider + ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_Local_UserAP'),pConstantManagement_SF_PRO('IndexCode_Local_UserDB')));//20100423 iwa del
      gstConnectData[1,2] := ctSQLServerProvider + ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_UserAP'),pConstantManagement_SF_PRO('IndexCode_UserDB')));//20100423 iwa add
      //Offer-Server
      //gstConnectData[2,1] := ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_OfferAP'),pConstantManagement_SF_PRO('IndexCode_OfferDB')));
      //gstConnectData[2,1] := ctSQLServerProvider + ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_OfferAP'),pConstantManagement_SF_PRO('IndexCode_OfferDB'))); //20100423 iwa del
      gstConnectData[2,1] := ctSQLServerProvider + ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_Local_OfferAP'),pConstantManagement_SF_PRO('IndexCode_Local_OfferDB'))); //20100423 iwa add
      //Offer-Local
      //gstConnectData[2,2] := ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_Local_OfferAP'),pConstantManagement_SF_PRO('IndexCode_Local_OfferDB')));
      //gstConnectData[2,2] := ctSQLServerProvider + ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_Local_OfferAP'),pConstantManagement_SF_PRO('IndexCode_Local_OfferDB')));
      gstConnectData[2,2] := ctSQLServerProvider + ShortString(pGetConnectionInfo(pConstantManagement_SF_PRO('ServerCode_OfferAP'),pConstantManagement_SF_PRO('IndexCode_OfferDB')));
    except
      HDspMsg(ERR_LEVEL_STOPDISP, 'HADOACS', GetPgNm, 'コネクション情報取得', ctOPE_CONNECT,
        'コネクション情報の取得に失敗しました',
          GetLastError, nil, 0);
      exit;
    end;

    gDataAttitude := true;
  end;

  //指定されたサービスコードでそのまま抜く。
  try
    connectionStinrg := PChar(string(gstConnectData[dbAttribute,serviceCode]));
  except
    HDspMsg(ERR_LEVEL_STOPDISP, 'HADOACS', GetPgNm, 'コネクション情報取得', ctOPE_CONNECT,
      'コネクション情報の取得に失敗しました',
        GetLastError, nil, 0);
    exit;
  end;

  Result := connectionStinrg;

  //Result := gfpGetConnectionInfo(dbType,serviceCode,dbAttribute);//20091013 iwa del

end;

//*******************************************************************//
// Module Name   : DLLロード関数                                     //
//               :                                                   //
// 引数          : なし                                              //
// 戻り値        : True:成功 False:失敗                              //
// Programer     : iwamoto                                           //
// Date          : 20091013                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function THADOACS.LoadGetConnectionDll(): Boolean;
begin
  Result := False;
  //DLLが既にﾛｰﾄﾞ済みであればﾛｰﾄﾞ処理は行わない
  if ghndCST = 0 then begin
    ghndCST := LoadLibrary(ctCONSTDLL);
    if ghndCST =0 then begin
      //ﾛｰﾄﾞ失敗
        HDspMsg(ERR_LEVEL_STOPDISP, 'HFSLLIB', GetPgNm, 'コネクション情報取得', ctOPE_START,
          PChar(ctCONSTDLL + 'のロードに失敗しました'),
            GetLastError, nil, 0);
      Exit;
    end;
    //関数ｱﾄﾞﾚｽ取得
    pConstantManagement_SF_PRO := GetProcAddress(ghndCST, 'ConstantManagement_SF_PRO');
    if @pConstantManagement_SF_PRO = nil then begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'HFSLLIB', GetPgNm, 'コネクション取得関数', ctOPE_START,
          PChar(ctCONSTDLL + 'で関数の取得に失敗しました'),
            GetLastError, nil, 0);
      exit;
    end;
  end;
  if ghndGCT = 0 then begin
    ghndGCT := LoadLibrary(ctGETCONNECTIONDLL);
    if ghndGCT =0 then begin
      //ﾛｰﾄﾞ失敗
        HDspMsg(ERR_LEVEL_STOPDISP, 'HFSLLIB', GetPgNm, 'コネクション情報取得', ctOPE_START,
          PChar(ctCONSTDLL + 'のロードに失敗しました'),
            GetLastError, nil, 0);
      Exit;
    end;
    //関数ｱﾄﾞﾚｽ取得
    pGetConnectionInfo := GetProcAddress(ghndGCT, 'GetConnectionInfo');
    if @pGetConnectionInfo = nil then begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'HFSLLIB', GetPgNm, 'コネクション取得関数', ctOPE_START,
          PChar(ctCONSTDLL + 'で関数の取得に失敗しました'),
            GetLastError, nil, 0);
      exit;
    end;
  end;
  Result := True;
end;

//*******************************************************************//
// Module Name   : 暗号化キーオープン処理                            //
//               :                                                   //
// 引数          : 1 TADOConnection   コネクションオブジェクト       //
//               : 2 Integer     DBタイプ(1:MSSQL,2:ORACLE...)       //
//               : 3 Integer 　  DB属性(1:ユーザー,2:提供)           //
//               : 4 String[] 　 対象テーブルリスト                  //
// 戻り値        : 1 Integer     結果ステータス(0:正常終了,5:失敗)   //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function THADOACS.OpenSymKey(srcConnection:TADOConnection; dbType:Integer; serviceCode:Integer; dbAttribute:Integer; tableList:array of PChar) : Integer;
var
  status : Integer;
begin

  status := 0;

  with TADOQuery.Create(nil) do
  try
    Connection := srcConnection;//コネクションのセット
    SQL.Add('');
      try
      ExecSQL;//実行
    except
      status := 5;
    end;
  finally
    Free;//開放
  end;

  Result := status;

  //Result := gfpOpenSymKey(srcConnection,dbType,serviceCode,dbAttribute,tableList);//20091013 iwa del
end;

//*******************************************************************//
// Module Name   : 暗号化キークローズ処理                            //
//               :                                                   //
// 引数          : 1 TADOConnection   コネクションオブジェクト       //
//               : 2 Integer     DBタイプ(1:MSSQL,2:ORACLE...)       //
//               : 3 Integer 　  DB属性(1:ユーザー,2:提供)           //
//               : 4 String[] 　 対象テーブルリスト                  //
// 戻り値        : 1 Integer     結果ステータス(0:正常終了,5:失敗)   //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function THADOACS.CloseSymKey(srcConnection:TADOConnection; dbType:Integer; serviceCode:Integer; dbAttribute:Integer; tableList:array of PChar) : Integer;
var
  status : Integer;
begin
  status := 0;

  with TADOQuery.Create(nil) do
  try
    Connection := srcConnection;//コネクションのセット
    SQL.Add('');
    try
      ExecSQL;//実行
    except
      status := 5;
    end;
  finally
    Free;//開放
  end;

  Result := status;

  //Result := gfpCloseSymKey(srcConnection,dbType,serviceCode,dbAttribute,tableList);//20091013 iwa del
end;


//*******************************************************************//
// Module Name   : データ取得処理(Int16)                             //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Int16       取得データ                          //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetInt16(query:TADOQuery;fieldName:string) : Int16;
begin
  Result := query.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(Int32)                             //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Int32       取得データ                          //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetInt32(query:TADOQuery;fieldName:string) : Int32;
begin
  Result := query.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(Int64)                             //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Int64       取得データ                          //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetInt64(query:TADOQuery;fieldName:string) : Int64;
begin
  Result := query.FieldByName(fieldName).AsLargeInt;
end;

//*******************************************************************//
// Module Name   : データ取得処理(Integer)                           //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Integer       取得データ                        //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetInteger(query:TADOQuery;fieldName:string) : Integer;
begin
  Result := query.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(ShortInt)                          //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 ShortInt       取得データ                       //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetShortInt(query:TADOQuery;fieldName:string) : ShortInt;
begin
  Result := query.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(LongInt)                           //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 LongInt       取得データ                        //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetLongInt(query:TADOQuery;fieldName:string) : LongInt;
begin
  Result := query.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(Double)                            //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Double       取得データ                         //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDouble(query:TADOQuery;fieldName:string) : Double;
begin
  Result := query.FieldByName(fieldName).AsFloat;
end;

//*******************************************************************//
// Module Name   : データ取得処理(String)                            //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 String       取得データ                         //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetString(query:TADOQuery;fieldName:string) : String;
begin
  Result := query.FieldByName(fieldName).AsString;
end;

//*******************************************************************//
// Module Name   : データ取得処理(TBytes)                            //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TBytes       取得データ                         //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetBytes(query:TADOQuery;fieldName:string) : TBytes;
begin
  Result := query.FieldByName(fieldName).AsBytes;
end;

//*******************************************************************//
// Module Name   : データ取得処理(TGUID)                             //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TGUID       取得データ                          //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetGuid(query:TADOQuery;fieldName:string) : TGUID;
begin
  Result := StringToGUID(query.FieldByName(fieldName).AsString);
end;

//*******************************************************************//
// Module Name   : データ取得処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TDateTime       取得データ                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDateTime(query:TADOQuery;fieldName:string) : TDateTime;
begin
  Result := query.FieldByName(fieldName).AsDateTime;
end;

//*******************************************************************//
// Module Name   : データ取得処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TDateTime       取得データ                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDateTimeFromTicks(query:TADOQuery;fieldName:string) : TDateTime;
begin
  Result := TicksToTDateTime(query.FieldByName(fieldName).AsLargeInt);
end;

//*******************************************************************//
// Module Name   : データ取得処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TDateTime       取得データ                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDateTimeFromYYYYMM(query:TADOQuery;fieldName:string) : TDateTime;
var
  intdatetime : Integer;
  retdatetime : TDateTime;
  checkResult : LongInt;
begin
  intdatetime := query.FieldByName(fieldName).AsInteger;
  if Length(IntToStr(intdatetime)) = 6 then
  begin
    checkResult := daycheck(1,intdatetime);
    if checkResult = 0 then
    begin
      retdatetime := EncodeDate(
        (intdatetime div 100),
        (intdatetime - ((intdatetime div 100)*100)) ,
        1);
    end;
  end;

  Result := retdatetime;
end;

//*******************************************************************//
// Module Name   : データ取得処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TADOQuery   ADOクエリオブジェクト               //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TDateTime       取得データ                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDateTimeFromYYYYMMDD(query:TADOQuery;fieldName:string) : TDateTime;
var
  intdatetime : Integer;
  retdatetime:TDateTime;
  checkResult : LongInt;
begin
  intdatetime := query.FieldByName(fieldName).AsInteger;
  if Length(IntToStr(intdatetime)) = 8 then
  begin
    checkResult := daycheck(0,intdatetime);
    if checkResult = 0 then
    begin
    retdatetime := EncodeDate(
      (intdatetime div 10000),
      ((intdatetime - ((intdatetime div 10000)*10000)) div 100),
      (intdatetime - ((intdatetime div 100)*100))
      )
    end;
  end;

  Result := retdatetime;
end;

//*******************************************************************//
// Module Name   : データ取得処理(Int16)                             //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Int16       取得データ                          //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetInt16(dataSet:TClientDataSet;fieldName:string) : Int16;
begin
  Result := dataSet.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(Int32)                             //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Int32       取得データ                          //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetInt32(dataSet:TClientDataSet;fieldName:string) : Int32;
begin
  Result := dataSet.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(Int64)                             //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Int16       取得データ                          //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetInt64(dataSet:TClientDataSet;fieldName:string) : Int64;
begin
  Result := dataSet.FieldByName(fieldName).AsLargeInt;
end;

//*******************************************************************//
// Module Name   : データ取得処理(Integer)                           //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Integer       取得データ                        //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetInteger(dataSet:TClientDataSet;fieldName:string) : Integer;
begin
  Result := dataSet.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(ShortInt)                          //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 ShortInt       取得データ                       //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetShortInt(dataSet:TClientDataSet;fieldName:string) : ShortInt;
begin
  Result := dataSet.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(LongInt)                           //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 LongInt       取得データ                        //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetLongInt(dataSet:TClientDataSet;fieldName:string) : LongInt;
begin
  Result := dataSet.FieldByName(fieldName).AsInteger;
end;

//*******************************************************************//
// Module Name   : データ取得処理(Double)                            //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 Double       取得データ                         //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDouble(dataSet:TClientDataSet;fieldName:string) : Double;
begin
  Result := dataSet.FieldByName(fieldName).AsFloat;
end;

//*******************************************************************//
// Module Name   : データ取得処理(String)                            //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 String       取得データ                         //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetString(dataSet:TClientDataSet;fieldName:string) : String;
begin
  Result := dataSet.FieldByName(fieldName).AsString;
end;

//*******************************************************************//
// Module Name   : データ取得処理(TBytes)                            //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TBytes       取得データ                         //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetBytes(dataSet:TClientDataSet;fieldName:string) : TBytes;
begin
  Result := dataSet.FieldByName(fieldName).AsBytes;
end;

//*******************************************************************//
// Module Name   : データ取得処理(TGUID)                             //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TGUID       取得データ                          //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetGuid(dataSet:TClientDataSet;fieldName:string) : TGUID;
begin
  Result := StringToGUID(dataSet.FieldByName(fieldName).AsString);
end;

//*******************************************************************//
// Module Name   : データ取得処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TDateTime       取得データ                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDateTime(dataSet:TClientDataSet;fieldName:string) : TDateTime;
begin
  Result := dataSet.FieldByName(fieldName).AsDateTime;
end;

//*******************************************************************//
// Module Name   : データ取得処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TDateTime       取得データ                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDateTimeFromTicks(dataSet:TClientDataSet;fieldName:string) : TDateTime;
begin
  Result := TicksToTDateTime(dataSet.FieldByName(fieldName).AsLargeInt);
end;

//*******************************************************************//
// Module Name   : データ取得処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TDateTime       取得データ                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDateTimeFromYYYYMM(dataSet:TClientDataSet;fieldName:string) : TDateTime;
var
  intdatetime : Integer;
  retdatetime:TDateTime;
  checkResult : LongInt;
begin
  intdatetime := dataSet.FieldByName(fieldName).AsInteger;
  if Length(IntToStr(intdatetime)) = 6 then
  begin
    checkResult := daycheck(1,intdatetime);
    if checkResult = 0 then
    begin
      retdatetime := EncodeDate(
        (intdatetime div 100),
        (intdatetime - ((intdatetime div 100)*100)) ,
        1)
    end;
  end;

  Result := retdatetime;
end;

//*******************************************************************//
// Module Name   : データ取得処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TClientDataSet   ClientDataSetオブジェクト      //
//               : 2 String      フィールド名称                      //
// 戻り値        : 1 TDateTime       取得データ                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function GetDateTimeFromYYYYMMDD(dataSet:TClientDataSet;fieldName:string) : TDateTime;
var
  intdatetime : Integer;
  retdatetime:TDateTime;
  checkResult : LongInt;
begin
  intdatetime := dataSet.FieldByName(fieldName).AsInteger;
  if Length(IntToStr(intdatetime)) = 8 then
  begin
    checkResult := daycheck(0,intdatetime);
    if checkResult = 0 then
    begin
      retdatetime := EncodeDate(
        (intdatetime div 10000),
        ((intdatetime - ((intdatetime div 10000)*10000)) div 100),
        (intdatetime - ((intdatetime div 100)*100))
        )
    end;
  end;

  Result := retdatetime;
end;


//*******************************************************************//
// Module Name   : データ設定処理(Int16)                             //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetInt16(params:TParameters;paramName:string;data:Int16);
begin
  params.ParamByName(paramName).DataType := ftSmallint;
  params.ParamByName(paramName).Value := data;
end;

//*******************************************************************//
// Module Name   : データ設定処理(Int16)                             //
//               :                                                   //
// 引数          : 1 TClientDataSet クライアントデータセット         //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 20090921                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetInt16(dataSet:TClientDataSet;paramName:string;data:Int16);
begin

  dataSet.FieldByName(paramName).Value := data;
end;


//*******************************************************************//
// Module Name   : データ設定処理(Int32)                             //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetInt32(params:TParameters;paramName:string;data:Int32);
begin
  params.ParamByName(paramName).DataType := ftInteger;
  params.ParamByName(paramName).Value := data;
end;

//*******************************************************************//
// Module Name   : データ設定処理(Int32)                             //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 20090921                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetInt32(dataSet:TClientDataSet;paramName:string;data:Int32);
begin
  dataSet.FieldByName(paramName).Value := data;
end;

//*******************************************************************//
// Module Name   : データ設定処理(Int64)                             //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetInt64(params:TParameters;paramName:string;data:Int64);
begin
  params.ParamByName(paramName).DataType := ftLargeint;
  params.ParamByName(paramName).Value := data;
end;
//*******************************************************************//
// Module Name   : データ設定処理(Int64)                             //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 20090921                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetInt64(dataSet:TClientDataSet;paramName:string;data:Int64);
begin
  dataSet.FieldByName(paramName).Value := data;
end;

//*******************************************************************//
// Module Name   : データ設定処理(Integer)                           //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetInteger(params:TParameters;paramName:string;data:Integer);
begin
  params.ParamByName(paramName).DataType := ftInteger;
  params.ParamByName(paramName).Value := data;
end;
//*******************************************************************//
// Module Name   : データ設定処理(Integer)                           //
//               :                                                   //
// 引数          : 1 TClientDataSet                                  //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 20090921                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetInteger(dataSet:TClientDataSet;paramName:string;data:Integer);
begin
  dataSet.FieldByName(paramName).Value := data;
end;


//*******************************************************************//
// Module Name   : データ設定処理(ShortInt)                          //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetShortInt(params:TParameters;paramName:string;data:ShortInt);
begin
  params.ParamByName(paramName).DataType := ftShortint;
  params.ParamByName(paramName).Value := data;
end;
//*******************************************************************//
// Module Name   : データ設定処理(ShortInt)                          //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 20090921                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetShortInt(dataSet:TClientDataSet;paramName:string;data:ShortInt);
begin
  dataSet.FieldByName(paramName).Value := data;
end;


//*******************************************************************//
// Module Name   : データ設定処理(LongInt)                           //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetLongInt(params:TParameters;paramName:string;data:LongInt);
begin
  params.ParamByName(paramName).DataType := ftInteger;
  params.ParamByName(paramName).Value := data;
end;
//*******************************************************************//
// Module Name   : データ設定処理(LongInt)                           //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 20090921                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetLongInt(dataSet:TClientDataSet;paramName:string;data:LongInt);
begin
  dataSet.FieldByName(paramName).Value := data;
end;

//*******************************************************************//
// Module Name   : データ設定処理(Double)                            //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDouble(params:TParameters;paramName:string;data:Double);
begin
  params.ParamByName(paramName).DataType := ftFloat;
  params.ParamByName(paramName).Value := data;
end;
//*******************************************************************//
// Module Name   : データ設定処理(Double)                            //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 20090921                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDouble(dataSet:TClientDataSet;paramName:string;data:Double);
begin
  dataSet.FieldByName(paramName).Value := data;
end;

//*******************************************************************//
// Module Name   : データ設定処理(String)                            //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetString(params:TParameters;paramName:string;data:String);
begin
  params.ParamByName(paramName).DataType := ftString;
  params.ParamByName(paramName).Value := data;
end;
//*******************************************************************//
// Module Name   : データ設定処理(String)                            //
//               :                                                   //
// 引数          : 1 TClientDataSet   パラメータオブジェクト         //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 20090921                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetString(dataSet:TClientDataSet;paramName:string;data:String);
begin
  dataSet.FieldByName(paramName).Value := data;
end;

//*******************************************************************//
// Module Name   : データ設定処理(TBytes)                            //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetBytes(params:TParameters;paramName:string;data:TBytes);
begin
  params.ParamByName(paramName).DataType := ftBytes;
  params.ParamByName(paramName).Value := data;
end;
//*******************************************************************//
// Module Name   : データ設定処理(TBytes)                            //
//               :                                                   //
// 引数          : 1 TClientDataSet   パラメータオブジェクト         //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetBytes(dataSet:TClientDataSet;paramName:string;data:TBytes);
begin
  dataSet.FieldByName(paramName).Value := data;
end;

//*******************************************************************//
// Module Name   : データ設定処理(TGUID)                             //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetGuid(params:TParameters;paramName:string;data:TGUID);
begin
  params.ParamByName(paramName).DataType := ftGuid;
  params.ParamByName(paramName).Value := GUIDToString(data);
end;
//*******************************************************************//
// Module Name   : データ設定処理(TGUID)                             //
//               :                                                   //
// 引数          : 1 TClientDataSet   パラメータオブジェクト         //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetGuid(dataSet:TClientDataSet;paramName:string;data:TGUID);
begin
  dataSet.FieldByName(paramName).Value := GUIDToString(data);
end;

//*******************************************************************//
// Module Name   : データ設定処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDateTime(params:TParameters;paramName:string;data:TDateTime);
begin
  params.ParamByName(paramName).DataType := ftDateTime;
  params.ParamByName(paramName).Value := data;
end;
//*******************************************************************//
// Module Name   : データ設定処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TClientDataSet   パラメータオブジェクト         //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDateTime(dataSet:TClientDataSet;paramName:string;data:TDateTime);
begin
  dataSet.FieldByName(paramName).Value := data;
end;

//*******************************************************************//
// Module Name   : データ設定処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDateTimeFromTicks(params:TParameters;paramName:string;data:TDateTime);
begin
  params.ParamByName(paramName).DataType := ftLargeint;
  params.ParamByName(paramName).Value := TDateTimeToTicks(data);
end;
//*******************************************************************//
// Module Name   : データ設定処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TClientDataSet   パラメータオブジェクト         //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDateTimeFromTicks(dataSet:TClientDataSet;paramName:string;data:TDateTime);
begin
  dataSet.FieldByName(paramName).Value := TDateTimeToTicks(data);
end;

//*******************************************************************//
// Module Name   : データ設定処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDateTimeFromYYYYMM(params:TParameters;paramName:string;data:TDateTime);
begin
  params.ParamByName(paramName).DataType := ftInteger;
  params.ParamByName(paramName).Value := StrToInt( FormatDateTime('YYYYMM', data));
end;
//*******************************************************************//
// Module Name   : データ設定処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TClientDataSet   パラメータオブジェクト         //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 20090921                                          //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDateTimeFromYYYYMM(dataSet:TClientDataSet;paramName:string;data:TDateTime);
begin
  dataSet.FieldByName(paramName).Value := StrToInt( FormatDateTime('YYYYMM', data));
end;

//*******************************************************************//
// Module Name   : データ設定処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TParameters   パラメータオブジェクト            //
//               : 2 String      フィールド名称                      //
// Programer     : kanemaki                                          //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDateTimeFromYYYYMMDD(params:TParameters;paramName:string;data:TDateTime);
begin
  params.ParamByName(paramName).DataType := ftInteger;
  params.ParamByName(paramName).Value := StrToInt( FormatDateTime('YYYYMMDD', data));
end;
//*******************************************************************//
// Module Name   : データ設定処理(TDateTime)                         //
//               :                                                   //
// 引数          : 1 TClientDataSet   パラメータオブジェクト         //
//               : 2 String      フィールド名称                      //
// Programer     : iwamoto                                           //
// Date          : 2009.08.13                                        //
// Note          : 　　　　　　　　　　　　　　　　　　　　　　　　　//
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
procedure SetDateTimeFromYYYYMMDD(dataSet:TClientDataSet;paramName:string;data:TDateTime);
begin
  dataSet.FieldByName(paramName).Value := StrToInt( FormatDateTime('YYYYMMDD', data));
end;

//>>>>20091013 iwa add start
(*============================================================================*)
(*  ユニット初期化部                                                          *)
(*============================================================================*)
initialization
  ghndCST := 0;
  ghndGCT := 0;
  pConstantManagement_SF_PRO  := nil;
  pGetConnectionInfo          := nil;

(*============================================================================*)
(*  ユニット終了処理部                                                        *)
(*============================================================================*)
finalization

  // DLLを解放する
  FreeLibrary(ghndCST);
  ghndCST := 0;
  pConstantManagement_SF_PRO     := nil;

  FreeLibrary(ghndGCT);
  ghndGCT := 0;
  pGetConnectionInfo     := nil;

//<<<<20091013 iwa add end

end.

