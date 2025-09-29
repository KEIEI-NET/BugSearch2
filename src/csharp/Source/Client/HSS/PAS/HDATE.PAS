//****************************************************************************//
// System			      : HSS100									                                //
// Sub System       :	HLabel												                          //
// Program name     :	日付操作関連部品	                                      //
//					        :	HDate.pas									                              //
// Name Space		    :	                                                        //
// Programmer		    :	ueo												                              //
// Date				      :	2009.08.11										                          //
// Note             : HSS70のHDATE70.DLLの機能を実装                          //
//----------------------------------------------------------------------------//
// Update Note		  :													                                //
//                  :   2009.09.07 23002 上野 耕平                            //
//                  :      ①  GetTimeNowToTicksを追加                        //
//                  :      ②  TDateTimeToTicksを追加                         //
//                  :      ③  TicksToTDateTimeを追加                         //
//                  :   2018.12.20 譚洪 新元号対応(11470076-00)                //
//----------------------------------------------------------------------------//
//				  (c)Copyright  2009 Broadleaf Co,. Ltd					                    //
//****************************************************************************//
unit HDATE;

interface

uses
  Windows, SysUtils;

const
  ctGENNO_MEIJI = 0;
  ctGENNO_TAISHO = 1;
  ctGENNO_SYOWA = 2;
  ctGENNO_HEISEI = 3;
  ctGENNO_WAHEI = 4;    //ADD 譚洪 2018/12/20 新元号対応

type
  //TGEN_REC = packed record
  //  szGen : array[0..9] of array[0..3] of Char;
  //  cRya	: array[0..9] of Char;
  //  nSdate: array[0..9] of LongInt;
  //  nEdate: array[0..9] of LongInt;
  //  nSadate: array[0..9] of LongInt;
  //end;
  TGEN_REC = packed record
    szGen : array[0..9] of String;
    cRya	: array[0..9] of String;
    nSdate: array[0..9] of LongInt;
    nEdate: array[0..9] of LongInt;
    nSadate: array[0..9] of LongInt;
  end;

  TJpn_Date = class
    private
      sGen : Array[0..9] of String;
      sRya : Array[0..9] of String;
      nSdate : Array[0..9] of LongInt;
      nEdate : Array[0..9] of LongInt;
      nSadate : Array[0..9] of LongInt;
    public
      constructor Create;
      function GetJpn_Date(var genList:TGEN_REC;start:Integer):Integer;
  end;



  function genset(var gengo:TGEN_REC; start:Integer=0):SmallInt;
  function swchg(lSdate:LongInt;var sGen:String;var sRya:String):LongInt;
  function wschg(lWdate:LongInt;cRya:String): LongInt;
  function sdateget1(var sYy:SmallInt;var sMm:SmallInt;var sDd:SmallInt):SmallInt;
  function sdateget2: LongInt;
  function DateAdd( kb:SmallInt;ymd:LongInt;addymd:LongInt): LongInt;
  function lastday(yy:SmallInt;mm:SmallInt):SmallInt;
  function uruu(yy:SmallInt):SmallInt;
  function daycheck( kb1:SmallInt; yymmdd:LongInt ): LongInt;
  function tukiAdd(sMm : SmallInt):LongInt;
  function dayclc(kb:SmallInt;ymd1:LongInt;ymd2:LongInt): LongInt;
  function gngget(sRya:String;var sGen:String ):SmallInt;
  function GngoGet(sRya: String):String;
  function stimeget(var inHh: smallint; var inMm: smallint; var inSs:smallint): Smallint;

  // 実装不要なはず
//  function sdategetPC1(sYy:PSmallInt;sMm:PSmallInt;sDd:PSmallInt): SmallInt;
//  function sdategetPC2: LongInt;
//  function stimegetPC(var inHh: smallint; var inMm: smallint; var inSs:smallint): Smallint;

  //>>>>2009.09.07 ueno add start
  function GetTimeNowToTicks():Int64;
  function TDateTimeToTicks(time:TDateTime):Int64;
  function TicksToTDateTime(ticks:Int64):TDateTime;
  //<<<<2009.09.07 ueno add end
  
var
  _dayMax : Array[0..11] of Integer = (31,29,31,30,31,30,31,31,30,31,30,31);

implementation

//*********************************************************************//
// Module Name     :  genset                                           //
//                 :  元号リストを取得する                             //
// 引数            :  1.元号リスト                                     //
//                 :  2.元号リスト開始No                               //
// 戻り値          :  取得した元号の数                                 //
// Programer       :  ueo                                              //
// Date            :  2009.08.11                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function genset(var gengo:TGEN_REC; start:Integer=0):SmallInt;
var
  cJpn_Date : TJpn_Date;
begin
  try
    cJpn_Date := TJpn_Date.Create;

    Result := cJpn_Date.GetJpn_Date(gengo, start);
  finally
    FreeAndNil(cJpn_Date);
  end;
end;

//*********************************************************************//
// Module Name     :  swchg                                            //
//                 :  西暦を和暦に変換する                             //
// 引数            :  1.西暦日付                                       //
//                 :  2.元号(Return)                                   //
//                 :  3.略号(Return)                                   //
// 戻り値          :  和暦日付                                         //
// Programer       :  ueo                                              //
// Date            :  2009.08.11                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function swchg(lSdate:LongInt;var sGen:String; var sRya:String):LongInt;
var
  lRet : LongInt;
  ix   : Integer;
  cJpn_Date : TJpn_Date;
  genList : TGEN_REC;
  nGenCnt : Integer;
begin
	lRet := 0;

	//引き渡しパラメータ初期化
	sRya := '';
	sGen := '';

  try
    cJpn_Date := TJpn_Date.Create;
    nGenCnt := cJpn_Date.GetJpn_Date(genList, ctGENNO_MEIJI);

    for ix := nGenCnt-1 downto 0 do
    begin
      if genList.nSdate[ix] = 0 then
        continue;
      if (genList.nSdate[ix] <= lSdate) or
         ((lSdate mod 100 = 0) and ((genList.nSdate[ix] div 100) <= (lSdate div 100)))or
         ((lSdate mod 10000 = 0) and ((genList.nSdate[ix] div 10000 <= lSdate div 10000))) then
      begin
        lRet := lSdate - (genList.nSadate[ix] * 10000);
        sRya := genList.cRya[ix];
        sGen := genList.szGen[ix];
        break;
      end;
    end;
  finally
    FreeAndNil(cJpn_Date);
  end;
  Result := lRet;
end;

//*********************************************************************//
// Module Name     :  wschg                                            //
//                 :  和暦を西暦に変換する                             //
// 引数            :  1.和暦日付                                       //
//                 :  2.略号                                           //
// 戻り値          :  西暦日付                                         //
// Programer       :  ueo                                              //
// Date            :  2009.08.11                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function wschg(lWdate:LongInt;cRya:String):LongInt;
var
  lRet : LongInt;
  ix  : Integer;
  cJpn_Date : TJpn_Date;
  genList : TGEN_REC;
  nGenCnt : Integer;
begin
  lRet := 0;

  if Trim(cRya) = '' then
  begin
    Result := -1;
    Exit;
  end;

  try
    cJpn_Date := TJpn_Date.Create;
    nGenCnt := cJpn_Date.GetJpn_Date(genList, ctGENNO_MEIJI);

    for ix := 0 to nGenCnt - 1 do
    begin
      if genList.cRya[ix] = cRya then
      begin
        lRet := lWdate + (genList.nSadate[ix] * 10000);
        break;
      end;
    end;
  finally
    FreeAndNil(cJpn_Date);
  end;

  Result := lRet;
end;

//*********************************************************************//
// Module Name     :  sdateget1                                        //
//                 :  システム日付を年月日別々に取得する               //
// 引数            :  1.年（西暦）(Return)                             //
//                 :  2.月(Return)                                     //
//                 :  3.日(Return)                                     //
// 戻り値          :  0:成功                                           //
// Programer       :  ueo                                              //
// Date            :  2009.08.12                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function sdateget1(var sYy:SmallInt;var sMm:SmallInt;var sDd:SmallInt):SmallInt;
var
  systemTime : TSystemTime;
begin
  GetLocalTime(systemTime);
	sYy := systemTime.wYear;
	sMm := systemTime.wMonth;
	sDd := systemTime.wDay;

  Result := 0;
end;

//*********************************************************************//
// Module Name     :  sdateget2                                        //
//                 :  システム日付取得する(西暦)                       //
// 引数            :  無し                                             //
// 戻り値          :  システム日付                                     //
// Programer       :  ueo                                              //
// Date            :  2009.08.12                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function sdateget2:LongInt;
var
  systemTime : TSystemTime;
begin
  GetLocalTime(systemTime);
  Result := systemTime.wYear * 10000 + systemTime.wMonth * 100 + systemTime.wDay;
end;

//*********************************************************************//
// Module Name     :  DateAdd                                          //
//                 :  日数計算                                         //
// 引数            :  1.区分(0:年計算,1:月計算,2:日計算)               //
//                 :  2.計算元西暦年月日                               //
//                 :  3.加算年・月・日数                               //
// 戻り値          :  計算後西暦年月日                                 //
// Programer       :  ueo                                              //
// Date            :  2009.08.12                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function DateAdd( kb:SmallInt;ymd:LongInt;addymd:LongInt):LongInt;
var
  sYy,sMm,sDd,sDdWrk : SmallInt;
  lRetYmd : LongInt;
  sWy,sWm : SmallInt;
  ix      : Integer;
begin
  lRetYmd := 0;
  case kb of
    0: // 年計算
    begin
      lRetYmd  := ymd + addymd * 10000;
		  sWy := ymd div 10000;
      sWm := ymd div 100 mod 100;
      if Lastday(sWy, sWm) = ymd mod 100 then
      begin
        sWy := lRetYmd div 10000;
        sWm := (lRetYmd div 100) mod 100;
        lRetYmd := ((lRetYmd div 100) * 100) + lastday(sWy, sWm);
      end;
    end;
    1: // 月計算
    begin
  	  sWy := ymd div 10000;
	    sWm := ((ymd div 100) mod 100);
      if (addymd + sWm) mod 12 = 0 then
      begin
        sYy := ((addymd + sWm) div 12) -1;
        sMm := ((addymd + sWm) mod 12) +12;
      end else
      // 加算月数 + 元日付月がマイナスの場合
      if (addymd + sWm) mod 100 < 0 then
      begin
        sYy := 0;
        sMm := sWm;
        for ix := addymd to 0 do
        begin
          sMm := sMm -1;
          if sMm <= 0 then
          begin
            sMm := 12;
            sYy := sYy -1;
          end;
        end;
      end else
      begin
        sYy := (addymd + sWm) div 12;
        sMm := (addymd + sWm) mod 12;
      end;

      lRetYmd := ymd;
      lRetYmd := lRetYmd - (sWm * 100);
      lRetYmd := lRetYmd + (sYy * 10000) + (sMm * 100);
      if lastday(sWy, sWm) = ymd mod 100 then
      begin
        sWy := lRetYmd div 10000;
        sWm := lRetYmd div 100 mod 100;
        lRetYmd := ((lRetYmd div 100) * 100) + (lastday(sWy,sWm));
      end;
    end;
    2: // 日計算
    begin
      // 現在の日付を分割
  	  sYy := ymd div 10000;
	    sMm := ((ymd div 100) mod 100);
      sDd := ymd mod 100;

      sDd := sDd + addymd;

      while True do
      begin
        sDdWrk := lastday(sYy, sMm);
        if addymd < 0 then
        begin
          if 1 <= sDd then
          begin
            break;
          end else
          begin
            Dec(sMm);
            if sMm < 1 then
            begin
              Dec(sYy);
              sMm := 12;
            end;
            Inc(sDd, lastday(sYy,sMm));
          end;
        end else
        begin
          if sDdWrk >= sDd then
          begin
            break;
          end else
          begin
            Inc(sMm);
            Dec(sDd,sDdWrk);
            if sMm > 12 then
            begin
              Inc(sYy);
              sMm := 1;
            end;
          end;
        end;
      end;
      lRetYmd := sYy * 10000 + sMm * 100 + sDd;
    end;
  end;
  if (lastday((lRetYmd div 100), (lRetYmd mod 10000 div 100))) < (lRetYmd mod 100) then
  begin
    lRetYmd := lastday(lRetYmd div 10000, lRetYmd mod 100000 div 100 ) + lRetYmd div 100 * 100;
  end;

  Result := lRetYmd;
end;

//*********************************************************************//
// Module Name     :  lastday                                          //
//                 :  末日取得                                         //
// 引数            :  1.年                                             //
//                 :  2.月                                             //
// 戻り値          :  末日                                             //
// Programer       :  ueo                                              //
// Date            :  2009.08.12                                       //
// Note            :  渡された年月に対する末日を算出します             //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function lastday(yy:SmallInt;mm:SmallInt):SmallInt;
var
  ret    : Integer;
begin
  case mm of
    1,3,5,7,8,10,12:
    begin
      ret := 31;
    end;
    4,6,9,11:
    begin
      ret := 30;
    end;
    2:
    begin
      ret := 28 + uruu(yy);
    end;
    else
      ret := 0;
  end;

  Result := ret;
end;

//*********************************************************************//
// Module Name     :  uruu                                             //
//                 :  閏年判定                                         //
// 引数            :  1.年                                             //
// 戻り値          :  閏年の時１、閏年でない時０を返す                 //
// Programer       :  ueo                                              //
// Date            :  2009.08.12                                       //
// Note            :  閏年の算出を行います。                           //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function uruu(yy:SmallInt):SmallInt;
var
  ret : Integer;
begin
  if yy mod 400 = 0 then
  begin
    ret := 1;
  end else
  if (yy mod 4 = 0) and (yy mod 100 <> 0) then
  begin
    ret := 1;
  end else
  begin
    ret := 0;
  end;

  Result := ret;
end;

//*********************************************************************//
// Module Name     :  daycheck                                         //
//                 :  日付の有効性チェック                             //
// 引数            :  1.区分(0.年月日ﾁｪｯｸ,1:年月ﾁｪｯｸ,2:月日ﾁｪｯｸ        //
//                 :  2.チェックする日付                               //
// 戻り値          :  0:正常,1:年異常,2:月異常,3:日異常,9:ﾊﾟﾗﾒｰﾀ異常   //
// Programer       :  ueo                                              //
// Date            :  2009.08.13                                       //
// Note            :  日付の有効性チェックを行います                   //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function daycheck( kb1:SmallInt; yymmdd:LongInt ):LongInt;
var
  nen,tuki,day : LongInt;
  ymd : LongInt;
begin

  case kb1 of
    1: // 年月チェック
    begin
      if yymmdd div 10000000 <> 0 then
      begin
        nen := yymmdd div 10000;
        tuki := (yymmdd mod 10000) div 100;
      end else
      begin
        nen := yymmdd div 100;
        tuki := yymmdd - nen * 100;
      end;
      if nen < 1 then
      begin
        Result := 1;
        Exit;
      end else
      if (tuki < 1) or (tuki > 12) then
      begin
        Result := 2;
        Exit;
      end;
      Result := 0;
    end;
    2: // 月日チェック
    begin
      if yymmdd div 10000 <> 0 then
      begin
        tuki := yymmdd mod 10000 div 100;
        day := yymmdd mod 100;
      end else
      begin
        tuki := yymmdd div 100;
        day := yymmdd - tuki * 100;
      end;
      if (tuki < 1) or (tuki > 12) then
      begin
        Result := 2;
        Exit;
      end else
      if (day < 1) or (day > _dayMax[tuki-1]) then
      begin
        Result := 3;
        Exit;
      end;
      Result := 0;
    end;
    0: // 年月日チェック
    begin
      ymd := yymmdd;
      nen := ymd div 10000;
      tuki := ymd mod 10000 div 100;
      day := ymd mod 100;

      if nen < 1 then
      begin
        Result := 1;
        Exit;
      end;
      if (tuki < 1) or (tuki > 12) then
      begin
        Result := 2;
        Exit;
      end;
      if (day < 1) or (day > lastday(nen,tuki)) then
      begin
        Result := 3;
        Exit;
      end;
      Result := 0;
    end;
    else
    begin
      Result := 9;
    end;
  end;
end;

//*********************************************************************//
// Module Name     :  dayclc                                           //
//                 :  日数計算                                         //
// 引数            :  1.区分(0.年月日計算,1:年月計算,2:月日計算        //
//                 :  2.古西暦年月日                                   //
//                 :  3.新西暦年月日                                   //
// 戻り値          :  日数                                             //
// Programer       :  ueo                                              //
// Date            :  2009.08.13                                       //
// Note            :                                                   //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function dayclc(kb:SmallInt;ymd1:LongInt;ymd2:LongInt):LongInt;
var
  nen1,tuki1,day1 : SmallInt;
  nen2,tuki2,day2 : SmallInt;
  wrk1,wrk2 : LongInt;
  lRet : LongInt;
  ix: Integer;
begin
  wrk1 := 0;
  wrk2 := 0;

  case kb of
    2: // 月日計算
    begin
      tuki1 := ymd1 div 100;
      day1 := ymd1 - (tuki1 * 100);

      tuki2 := ymd2 div 100;
      day2 := ymd2 - (tuki2 * 100);
      // 月・日数  計算
      wrk1 := tukiAdd(tuki1-1);
      wrk2 := tukiAdd(tuki2-1);
      // 日・日数  計算
      wrk1 := wrk1 + day1;
      wrk2 := wrk2 + day2;
      // 差（古月日－新月日）計算
      lRet := wrk2 - wrk1;

      Result := lRet;
    end;
    1: // 年月計算
    begin
      nen1 := ymd1 div 100;
      tuki1 := ymd1 - nen1 * 100;
      nen2 := ymd2 div 100;
      tuki2 := ymd2 - nen2 * 100;
      // 年・日数  計算
      wrk1 := nen1 * 365 + uruu(nen1);
      wrk2 := nen2 * 365 + uruu(nen2);
      // 月・日数  計算
      wrk1 := wrk1 + tukiadd(tuki1-1);
      if (uruu(nen1) = 0) and (tuki1 > 2) then
      begin
        Dec(wrk1);
      end;
      wrk2 := wrk2 + tukiadd(tuki2-1);
      if (uruu(nen2) = 0) and (tuki2 > 2) then
      begin
        Dec(wrk2);
      end;
      // 差（古月日 － 新月日）計算
      lRet := wrk2 - wrk1;
      Result := lRet;
    end;
    0: // 年月日計算
    begin
      nen1 := ymd1 div 100;
      tuki1 := ymd1 mod 10000 div 100;
      day1 := ymd1 mod 100;
      nen2 := ymd2 div 100;
      tuki2 := ymd2 mod 10000 div 100;
      day2 := ymd2 mod 100;
      // 年・日数  計算
      for ix := 0 to nen1 - 1 do
      begin
        wrk1 := wrk1 + 365 + uruu(ix);
      end;
      for ix := 0 to nen2 - 1 do
      begin
        wrk2 := wrk2 + 365 + uruu(ix);
      end;
      // 月・日数  計算
      wrk1 := wrk1 + tukiadd(tuki1-1);
      if (uruu(nen1) = 0) and (tuki1 > 2) then
      begin
        Dec(wrk1);
      end;
      wrk2 := wrk2 + tukiadd(tuki2-1);
      if (uruu(nen2) = 0) and (tuki2 > 2) then
      begin
        Dec(wrk2);
      end;
      // 日・日数  計算
      wrk1 := wrk1 + day1;
      wrk2 := wrk2 + day2;
      // 差（古月日 － 新月日）計算
      lRet := wrk2 - wrk1;

      Result := lRet;
    end;
    else
    begin
      Result := -2;
    end;
  end;
end;


//*********************************************************************//
// Module Name     :  tukiAdd                                          //
//                 :  月数計算                                         //
// 引数            :  1.月                                             //
// 戻り値          :  月の日数                                         //
// Programer       :  ueo                                              //
// Date            :  2009.08.13                                       //
// Note            :                                                   //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function tukiAdd(sMm : SmallInt):LongInt;
var
  cnt : Integer;
  wdat : LongInt;
begin
  wdat := 0;
  cnt := 0;

  while cnt < sMm do
  begin
    wdat := wdat + _daymax[cnt];
    Inc(cnt);
  end;

  Result := wdat;
end;

//*********************************************************************//
// Module Name     :  gngget                                           //
//                 :  元号取得                                         //
// 引数            :  1.略号                                           //
//                 :  2.元号                                           //
// 戻り値          :  0:成功, -1:対象無し                              //
// Programer       :  ueo                                              //
// Date            :  2009.08.13                                       //
// Note            :                                                   //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function gngget(sRya:String;var sGen:String ):SmallInt;
var
  cJpn_Date : TJpn_Date;
  nGenCnt : Integer;
  genList : TGEN_REC;
  ix: Integer;
begin
  Result := -1;
  sGen := '';

  if Trim(sRya) = '' then
  begin
    Exit;
  end;

  try
    cJpn_Date := TJpn_Date.Create;
    nGenCnt := cJpn_Date.GetJpn_Date(genList, ctGENNO_MEIJI);

    for ix := 0 to nGenCnt - 1 do
    begin
      if sRya = genList.cRya[ix] then
      begin
        sGen := genList.szGen[ix];
        Result := 0;
        break;
      end;
    end;
  finally
    FreeAndNil(cJpn_Date);
  end;
end;

//*********************************************************************//
// Module Name     :  GngoGet                                          //
//                 :  元号取得                                         //
// 引数            :  1.略号                                           //
// 戻り値          :  元号                                             //
// Programer       :  ueo                                              //
// Date            :  2009.08.13                                       //
// Note            :                                                   //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function GngoGet(sRya: String):String;
var
  sGen : String;
begin
  gngget(sRya,sGen);

  Result := sGen;
end;

//*********************************************************************//
// Module Name     :  stimeget                                         //
//                 :  システム時間取得                                 //
// 引数            :  1.時                                             //
//                 :  2.分                                             //
//                 :  3.秒                                             //
// 戻り値          :  0:成功                                           //
// Programer       :  ueo                                              //
// Date            :  2009.08.13                                       //
// Note            :                                                   //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function stimeget(var inHh: smallint; var inMm: smallint; var inSs:smallint): Smallint;
var
  systemTime : TSystemTime;
begin
  GetLocalTime(systemTime);
	inHh := systemTime.wHour;
	inMm := systemTime.wMinute;
	inSs := systemTime.wSecond;

  Result := 0;
end;


//function sdategetPC1(sYy:PSmallInt;sMm:PSmallInt;sDd:PSmallInt):SmallInt;
//var
//  yy,mm,dd : Integer;
//begin
//  yy := 2009;
//  mm := 8;
//  dd := 13;
//
//  sYy := @yy;
//  sMm := @mm;
//  sDd := @dd;
//  Result := 0;
//end;
//function sdategetPC2:LongInt;
//begin
//  Result := 20090813;
//end;
//function stimegetPC(var inHh: smallint; var inMm: smallint; var inSs:smallint): Smallint;
//begin
//  inHh := 12;
//  inMm := 12;
//  inSs := 12;
//  Result := 0;
//end;




//*********************************************************************//
// Module Name     :  TJpn_Date.Create                                 //
//                 :  TJpn_Dateコンストラクタ                          //
// 引数            :  無し                                             //
// 戻り値          :  0:成功                                           //
// Programer       :  ueo                                              //
// Date            :  2009.08.11                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
constructor TJpn_Date.Create;
var
  ix: Integer;
begin
  // 派生元呼び出し
  inherited Create;
  //--------------- UPD 譚洪 2018/12/20 新元号対応 --------------->>>>> 
  //for ix := 0 to 4 - 1 do
  for ix := 0 to 5 - 1 do
  //--------------- UPD 譚洪 2018/12/20 新元号対応 ---------------<<<<<
  begin
    case ix of
      0:
      begin
        sGen[ix] := '明治';
        sRya[ix] := 'M';
        nSdate[ix] := 18680908;
        nEdate[ix] := 19120729;
        nSadate[ix] := 1867;
      end;
      1:
      begin
        sGen[ix] := '大正';
        sRya[ix] := 'T';
        nSdate[ix] := 19120730;
        nEdate[ix] := 19261224;
        nSadate[ix] := 1911;
      end;
      2:
      begin
        sGen[ix] := '昭和';
        sRya[ix] := 'S';
        nSdate[ix] := 19261225;
        nEdate[ix] := 19890107;
        nSadate[ix] := 1925;
      end;
      3:
      begin
        sGen[ix] := '平成';
        sRya[ix] := 'H';
        nSdate[ix] := 19890108;
        //nEdate[ix] := 99991231;    //DEL 譚洪 2018/12/20 新元号対応
        nEdate[ix] := 20190430;    //ADD 譚洪 2018/12/20 新元号対応
        nSadate[ix] := 1988;
      end;
      //--------------- ADD 譚洪 2018/12/20 新元号対応 --------------->>>>> 
      4:
      begin
        sGen[ix] := '令和';
        sRya[ix] := 'R';
        nSdate[ix] := 20190501;
        nEdate[ix] := 99991231;
        nSadate[ix] := 2018;
      end;
      //--------------- ADD 譚洪 2018/12/20 新元号対応 ---------------<<<<<
    end;
  end;
end;

//*********************************************************************//
// Module Name     :  TJpn_Date.GetJpn_Date                            //
//                 :  元号リスト取得                                   //
// 引数            :  1.元号リスト                                     //
//                 :  2.開始No(0:明治,1:大正,2:昭和,3:平成             //
// 戻り値          :  取得した元号の数                                 //
// Programer       :  ueo                                              //
// Date            :  2009.08.11                                       //
//---------------------------------------------------------------------//
// Update Note     :                                                   //
//*********************************************************************//
function TJpn_Date.GetJpn_Date(var genList:TGEN_REC; start:Integer):Integer;
var
  ix: Integer;
  jx: Integer;
  gen_cnt : Integer;
begin
  // 元号リストを初期化
  ZeroMemory(@genList,sizeof(genList));

  // 定義元号数
  //--------------- UPD 譚洪 2018/12/20 新元号対応 --------------->>>>>
  //gen_cnt := 4;
  gen_cnt := 5;

  //if start > 3 then
  if start > 4 then
  //--------------- UPD 譚洪 2018/12/20 新元号対応 ---------------<<<<<
  begin
    Result := 0;
    Exit;
  end;

  jx := 0;
  for ix := start to gen_cnt - 1 do
  begin
    genList.szGen[jx] := sGen[ix];
    genList.cRya[jx] := sRya[ix];
    genList.nSdate[jx] := nSdate[ix];
    genList.nEdate[jx] := nEdate[ix];
    genList.nSadate[jx] := nSadate[ix];
    jx := jx + 1;
  end;

  Result := jx;
end;

{*******************************************************************}
{ Module Name   : Ticks取得関数                                     }
{               : GetTimeNowToTicks                                 }
{ 引数          :                                                   }
{               :                                                   }
{ 戻り値        : 1 Int64                                           }
{ Programer     : 23002 上野 耕平                                   }
{ Date          : 2009.09.07                                        }
{ Note          : 0001 年 1 月 1 日午前 00:00:00 以降の経過時間     }
{               : (100 ナノ秒単位）で取得します                     }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function GetTimeNowToTicks():Int64;
var
  utcTime : FILETIME; // ファイルタイム（UTC形式の現在時刻格納用）
  ticks   : Int64;    // Ticks（C#言語仕様と同じ値）
begin

  // システムの現在の日付と時刻を UTC 形式で取得
  GetSystemTimeAsFileTime(&utcTime);

  // UTC形式の時刻をローカル形式に変換
  FileTimeToLocalFileTime(utcTime,&utcTime);

  // 1601年1月1日 00:00:00 からの経過時間を100ナノ秒単位で取得（Int64形式）
  ticks := Int64(utcTime.dwLowDateTime) + (Int64(utcTime.dwHighDateTime) shl 32);

  // 0001/1/1 00:00:00 からの経過時間に変換する
  // 1601年1月1日 00:00:00　⇒ 504911232000000000　を足す
  ticks := ticks + 504911232000000000;

  result := ticks;

end;




{*******************************************************************}
{ Module Name   : TDateTimeからTicks変換関数                        }
{               : TDateTimeToTicks                                  }
{ 引数          : 1 TDateTime   変換元のTDateTime                   }
{               :                                                   }
{ 戻り値        : 1 Int64       Ticks                               }
{ Programer     : 23002 上野 耕平                                   }
{ Date          : 2009.09.07                                        }
{ Note          : TDateTimeからTicksに変換します                    }
{               : (100ミリ秒単位）                                  }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function TDateTimeToTicks(time:TDateTime):Int64;
var
  utcTime: FILETIME;   // ファイルタイム
  sTime  : SYSTEMTIME; // システムタイム
  ticks  : Int64;      // Ticks（C#言語仕様と同じ値）
begin

  // TDateTime⇒SystemTimeに変換
  DateTimeToSystemTime(time,&sTime);

  // SystemTime⇒FileTimeに変換
  SystemTimeToFileTime(sTime,&utcTime);

  // 1601年1月1日 00:00:00 からの経過時間を100ナノ秒単位で取得（Int64形式）
  ticks := Int64(utcTime.dwLowDateTime) + (Int64(utcTime.dwHighDateTime) shl 32);

  // 0001/1/1 00:00:00 からの経過時間に変換する
  // 1601年1月1日 00:00:00　⇒ 504911232000000000　を足す
  ticks := ticks + 504911232000000000;

  result := ticks;

end;



{*******************************************************************}
{ Module Name   : TicksからTDateTime変換関数                        }
{               : TicksToTDateTime                                  }
{ 引数          : 1 Int64        Ticks                              }
{               :                                                   }
{ 戻り値        : 1 TDateTime    変換後のTDateTime                  }
{ Programer     : 23002 上野 耕平                                   }
{ Date          : 2009.09.07                                        }
{ Note          : TicksからTDateTimeに変換します                    }
{               :                                                   }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function TicksToTDateTime(ticks:Int64):TDateTime;
var
  utcTime  : FILETIME;   // ファイルタイム
  sTime    : SYSTEMTIME; // システムタイム
  tmpTicks : Int64;      // Ticks（C#言語仕様と同じ値）
  tmp      : Int64;      // Bit演算結果格納用
begin

  // 1601/1/1 00:00:00 からの経過時間に変換する
  tmpTicks := ticks - 504911232000000000;

  // FileTime形式に格納する
  utcTime.dwHighDateTime := tmpTicks shr 32;
  tmp                    := Int64(utcTime.dwHighDateTime) shl 32;
  utcTime.dwLowDateTime  := tmpTicks - tmp ;

  // 下記計算だと誤差が発生する為一度変数に格納してから計算を行う
  {utcTime.dwLowDateTime  :=  tmpTicks - (Int64(utcTime.dwHighDateTime) shl 32) ;}

  // FileTime⇒SystemTimeに変換
  FileTimeToSystemTime(utcTime,&sTime);

  // SystemTime⇒FileTimeに変換した結果を返す
  result := SystemTimeToDateTime(sTime);

end;

end.
