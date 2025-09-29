unit HSHRPARA;
//**********************************************************************//
// System           :   パラメータ用共有メモリコンポ                    //
// Sub System       :   ＨＳＳ部品                                      //
// Program name     :   HShrPara                                        //
//                  :                                                   //
// Programer        :   宮富  孝洋                                      //
// Date             :   2000.06.17                                      //
//----------------------------------------------------------------------//
// Update Note      :   2001.02.26  鹿野　幸生                          //
//                  :   １．HSHRPARA.DLLをHSHRPARA50.DLLに変更          //
//                  :   2009.08.12  鹿野　幸生                          //
//                  :   ① HSS100対応                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2000 TSUBASA SYSTEM Co,. Ltd            //
//**********************************************************************//
(*============================================================================*)
(*  宣言部                                                                    *)
(*============================================================================*)
interface

  (*=====================================*)
  (*  使用ユニット                       *)
  (*=====================================*)
uses
    Windows, SysUtils, Classes, HVersion;

  (*=====================================*)
  (*  クラス(型)宣言                     *)
  (*=====================================*)
type
  // HSHRPARA.Dllアクセス関数型
  TCreatRecInf = function (inRscId, inDtlNo, inlBuffLen: Smallint; var iBuff): Smallint; stdcall;
  TSetRecInf   = function (inRscId, inDtlNo, inlBuffLen: Smallint; var iBuff): Smallint; stdcall;
  TGetRecInf   = function (inRscId, inDtlNo, inlBuffLen: Smallint; var oBuff): Smallint; stdcall;
  TDelRecInf   = function (inRscId, inDtlNo: Smallint): Smallint; stdcall;
  TGetParam    = function (inRscId, inlBuffLen: Smallint; var iBuff): Smallint; stdcall;
  TSetParam    = function (inRscId, inlBuffLen: Smallint; var oBuff): Smallint; stdcall;
  TDelParam    = function (inRscId: Smallint): Smallint; stdcall;

  // パラメータ共有メモリ例外クラス
  EShrParaException = class(Exception);

  // パラメータ共有メモリクラス
  THShrPara = class(TComponent)
  private
    mnRscId:     Smallint;
    mnDtlNo:     Smallint;
    mnBuffLen:   Smallint;
    mpBuff:      Pointer;
    FVersion: TVersion;

    procedure SetRscId(nRscId: Smallint);
    procedure SetBuffLen(nBuffLen: Smallint);
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;

    function CreatRecInf(nOperand: Integer = 0): Smallint;
    function SetRecInf(nOperand: Integer = 0): Smallint;
    function GetRecInf(nOperand: Integer = 0): Smallint;
    function DelRecInf(nOperand: Integer = 0): Smallint;
    function GetParam(nOperand: Integer = 0): Smallint;
    function SetParam(nOperand: Integer = 0): Smallint;
    function DelParam(nOperand: Integer = 0): Smallint;

    property ParaBuff: Pointer read mpBuff    write mpBuff;
  published
    property RscId:   Smallint read mnRscId   write SetRscId   default 0;
    property DtlNo:   Smallint read mnDtlNo   write mnDtlNo    default 0;
    property BuffLen: Smallint read mnBuffLen write SetBuffLen default 0;
    property Version: TVersion read FVersion  write FVersion   stored False;
  end;

procedure Register;

(*============================================================================*)
(*  実行部                                                                    *)
(*============================================================================*)
implementation

const
   ctHSHRPARA_DLL = 'HSHRPARA100.DLL';

  (*=====================================*)
  (*  グローバル変数                     *)
  (*=====================================*)
var
   ghInstance    : HINST;
   gfpCreatRecInf: function (inRscId, inDtlNo, inlBuffLen: Smallint; ipBuff: Pointer): Smallint; stdcall;
   gfpSetRecInf  : function (inRscId, inDtlNo, inlBuffLen: Smallint; ipBuff: Pointer): Smallint; stdcall;
   gfpGetRecInf  : function (inRscId, inDtlNo, inlBuffLen: Smallint; opBuff: Pointer): Smallint; stdcall;
   gfpDelRecInf  : function (inRscId, inDtlNo: Smallint): Smallint; stdcall;
   gfpGetParam   : function (inRscId, inlBuffLen: Smallint; ipBuff: Pointer): Smallint; stdcall;
   gfpSetParam   : function (inRscId, inlBuffLen: Smallint; opBuff: Pointer): Smallint; stdcall;
   gfpDelParam   : function (inRscId: Smallint): Smallint; stdcall;

//**********************************************************************//
// Module Name     :  コンポーネント登録                                //
//                 :  Register                                          //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.17                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
procedure Register;
begin
     RegisterComponents('HSS', [THShrPara]);
end;

//**********************************************************************//
// Module Name     :  パラメータ共有メモリ生成                          //
//                 :  THShrPara.Create                                  //
// 引数            :  AOwner         : 親コンポーネント                 //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.17                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
constructor THShrPara.Create(AOwner: TComponent);
begin
     try
       Inherited Create(AOwner);
     except
       on E:Exception do
         begin
           raise EShrParaException.Create(E.Message);
         end;
     end;

     mnRscId   := 0;
     mnDtlNo   := 0;
     mnBuffLen := 0;
     mpBuff    := nil;
     FVersion := HShrParaVersion;

     // 設計時はＤＬＬのロードは行わない
     if csDesigning in ComponentState then Exit;

     if ghInstance = 0 then
     begin
//       ghInstance := LoadLibrary('HSHRPARA.DLL');                             2001.02.26 変更
       ghInstance := LoadLibrary(ctHSHRPARA_DLL);
     end;

     // ＤＬＬのロード失敗
     if ghInstance = 0 then
     begin
//       raise EShrParaException.Create('Load failed Dynamic link library! <HSHRPARA50.DLL>');
       raise EShrParaException.Create(ctHSHRPARA_DLL + 'のロードに失敗しました');
     end else
     // ファンクションの取得
     begin
       if @gfpDelParam = nil then
       begin
{                                                                               2001.02.26 変更
         gfpCreatRecInf := GetProcAddress(ghInstance, 'CreatRecInf');
         if @gfpCreatRecInf = nil then
         begin
           raise EShrParaException.Create('Not found function in <HSHRPARA50.DLL> ･･･ CreatRecInf');
         end;

         gfpSetRecInf   := GetProcAddress(ghInstance, 'SetRecInf');
         if @gfpSetRecInf = nil then
         begin
           raise EShrParaException.Create('Not found function in <HSHRPARA50.DLL> ･･･ SetRecInf');
         end;

         gfpGetRecInf   := GetProcAddress(ghInstance, 'GetRecInf');
         if @gfpGetRecInf = nil then
         begin
           raise EShrParaException.Create('Not found function in <HSHRPARA50.DLL> ･･･ GetRecInf');
         end;

         gfpDelRecInf   := GetProcAddress(ghInstance, 'DelRecInf');
         if @gfpDelRecInf = nil then
         begin
           raise EShrParaException.Create('Not found function in <HSHRPARA50.DLL> ･･･ DelRecInf');
         end;

         gfpGetParam    := GetProcAddress(ghInstance, 'GetParam');
         if @gfpGetParam = nil then
         begin
           raise EShrParaException.Create('Not found function in <HSHRPARA50.DLL> ･･･ GetParam');
         end;

         gfpSetParam    := GetProcAddress(ghInstance, 'SetParam');
         if @gfpSetParam = nil then
         begin
           raise EShrParaException.Create('Not found function in <HSHRPARA50.DLL> ･･･ SetParam');
         end;

         gfpDelParam    := GetProcAddress(ghInstance, 'DelParam');
         if @gfpDelParam = nil then
         begin
           raise EShrParaException.Create('Not found function in <HSHRPARA50.DLL> ･･･ DelParam');
         end;
}
         gfpCreatRecInf := GetProcAddress(ghInstance, 'CreatRecInf');
         gfpSetRecInf   := GetProcAddress(ghInstance, 'SetRecInf');
         gfpGetRecInf   := GetProcAddress(ghInstance, 'GetRecInf');
         gfpDelRecInf   := GetProcAddress(ghInstance, 'DelRecInf');
         gfpGetParam    := GetProcAddress(ghInstance, 'GetParam');
         gfpSetParam    := GetProcAddress(ghInstance, 'SetParam');
         gfpDelParam    := GetProcAddress(ghInstance, 'DelParam');
         if (@gfpCreatRecInf = nil) or (@gfpSetRecInf = nil)   or
            (@gfpGetRecInf = nil)   or (@gfpDelRecInf = nil)   or
            (@gfpGetParam = nil)    or (@gfpSetParam = nil)    or
            (@gfpDelParam = nil) then begin

           raise EShrParaException.Create(ctHSHRPARA_DLL + 'のバージョンが正しくありません');
           
         end;
       end;
     end;
end;

//**********************************************************************//
// Module Name     :  パラメータ共有メモリ消滅                          //
//                 :  THShrPara.Destroy                                 //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.17                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
destructor THShrPara.Destroy;
begin
     mnBuffLen := 0;

     inherited Destroy;
end;

//**********************************************************************//
// Module Name     :  リソースＩＤ設定                                  //
//                 :  THShrPara.SetRscId                                //
// 引数            :  1 Smallint     : 設定するリソースＩＤ             //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.17                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
procedure THShrPara.SetRscId(nRscId: Smallint);
begin
     if mnRscId <> nRscId then
     begin
       mnRscId := nRscId;
     end;
end;

//**********************************************************************//
// Module Name     :  バッファ長設定                                    //
//                 :  THShrPara.SetBuffLen                              //
// 引数            :  1 Smallint     : 設定するバッファ長               //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.17                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
procedure THShrPara.SetBuffLen(nBuffLen: Smallint);
begin
     if mnBuffLen <> nBuffLen then
     begin
       mnBuffLen := nBuffLen;
     end;
end;

//**********************************************************************//
// Module Name     :  レコード情報生成                                  //
//                 :  THShrPara.CreatRecInf                             //
// 引数            :  --                                                //
// 戻り値          :  HSHRPARA50.DLLのCreatRecInfを参照                   //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.19                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
function THShrPara.CreatRecInf(nOperand: Integer = 0): Smallint;
begin
     Result := gfpCreatRecInf(mnRscId, mnDtlNo, mnBuffLen, mpBuff);
end;

//**********************************************************************//
// Module Name     :  レコード情報設定                                  //
//                 :  THShrPara.SetRecInf                               //
// 引数            :  --                                                //
// 戻り値          :  HSHRPARA50.DLLのSetRecInfを参照                     //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.19                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
function THShrPara.SetRecInf(nOperand: Integer = 0): Smallint;
begin
     Result := gfpSetRecInf(mnRscId, mnDtlNo, mnBuffLen, mpBuff);
end;

//**********************************************************************//
// Module Name     :  レコード情報取得                                  //
//                 :  THShrPara.GetRecInf                               //
// 引数            :  --                                                //
// 戻り値          :  HSHRPARA50.DLLのGetRecInfを参照                     //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.19                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
function THShrPara.GetRecInf(nOperand: Integer = 0): Smallint;
begin
     Result := gfpGetRecInf(mnRscId, mnDtlNo, mnBuffLen, mpBuff);
end;

//**********************************************************************//
// Module Name     :  レコード情報削除                                  //
//                 :  THShrPara.DelRecInf                               //
// 引数            :  --                                                //
// 戻り値          :  HSHRPARA50.DLLのDelRecInfを参照                     //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.19                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
function THShrPara.DelRecInf(nOperand: Integer = 0): Smallint;
begin
     Result := gfpDelRecInf(mnRscId, mnDtlNo);
end;

//**********************************************************************//
// Module Name     :  パラメータ取得                                    //
//                 :  THShrPara.GetParam                                //
// 引数            :  --                                                //
// 戻り値          :  HSHRPARA50.DLLのGetParamを参照                      //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.19                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
function THShrPara.GetParam(nOperand: Integer = 0): Smallint;
begin
     Result := gfpGetParam(mnRscId, mnBuffLen, mpBuff);
end;

//**********************************************************************//
// Module Name     :  パラメータ設定                                    //
//                 :  THShrPara.SetParam                                //
// 引数            :  --                                                //
// 戻り値          :  HSHRPARA50.DLLのSetParamを参照                      //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.19                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
function THShrPara.SetParam(nOperand: Integer = 0): Smallint;
begin
     Result := gfpSetParam(mnRscId, mnBuffLen, mpBuff);
end;

//**********************************************************************//
// Module Name     :  パラメータ削除                                    //
//                 :  THShrPara.DelParam                                //
// 引数            :  --                                                //
// 戻り値          :  HSHRPARA50.DLLのDelParamを参照                      //
// Programer       :  宮富 孝洋                                         //
// Date            :  2000.06.19                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
//**********************************************************************//
function THShrPara.DelParam(nOperand: Integer = 0): Smallint;
begin
     Result := gfpDelParam(mnRscId);
end;

(*============================================================================*)
(*  ユニット初期化部                                                          *)
(*============================================================================*)
initialization
     ghInstance := 0;
     gfpCreatRecInf := nil;
     gfpSetRecInf   := nil;
     gfpGetRecInf   := nil;
     gfpDelRecInf   := nil;
     gfpGetParam    := nil;
     gfpSetParam    := nil;
     gfpDelParam    := nil;

(*============================================================================*)
(*  ユニット終了処理部                                                        *)
(*============================================================================*)
finalization

     // ＤＬＬをロード済みの場合…解放
     if ghInstance <> 0 then
     begin
       FreeLibrary(ghInstance);
       ghInstance := 0;
     end;

end.
