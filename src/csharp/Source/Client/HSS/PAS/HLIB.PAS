{
******************************************************************************
	HSS ｺﾝﾎﾟｰﾈﾝﾄﾗｲﾌﾞﾗﾘ  ｢HSS｣

		共通ﾗｲﾌﾞﾗﾘ

		ﾕﾆｯﾄ名  :   HLIB.PAS
		作成者  :   Kubochi
		作成日  :   1999/7
//               :   2001.02.26  鹿野　幸生                                //
//                               ① HIniPathMakeLibを削除                  //
//               :   2009.08.10 徳永　誠                                   //
//               :      ①  Delphi2009対応(HSS100対応）                    //
*******************************************************************************
}
unit HLib;

{$DEFINE UPDATE}
//{$DEFINE ADDCOMRADE}
//{$DEFINE VDATE_PLUSPOS}
// Modify VDATE_PLUSPOS 97/04/10

{
******************************************************************************
	interface部
******************************************************************************
}
interface

	{ ﾕﾆｯﾄ指定 }
	uses
		SysUtils, WinTypes, WinProcs, Messages, Classes, Graphics, Controls,
		Forms, StdCtrls, ExtCtrls, Buttons, Tabs, TabNotBk, Mask, OutLine, ComCtrls,Filectrl,
//{$IFDEF ADDCOMRADE}
//		VEdit, VFEdit, VDtEdit, VTmEdit, VButton, VFLabel, VCalEdit, VValEdit, VNEdit,
//{$ENDIF}
		HEdit, HDedit,{ XTedit, XVedit, XCalendr, XRect,} HLine{ XFkeyBtn,}, HDblBtn;
	{ 定数定義 }
	const
		kMinYear    = 1;
		kMaxYear    = 9999;
		kMinMonth   = 1;
		kMaxMonth   = 12;
		kMinDay     = 1;
		kMaxDay     = 31;
		kDaysOfWeek = 7;
		kMaxWeek    = 6;

	{ 型宣言 }
	type
		{ 矢印ｷｰによるﾌｫｰｶｽ移動順 }
		TArrowFocusSeq = (ByAxis,   { 軸優先 }
						  ByDist);  { 距離優先 }


		{ RETによるﾌｫｰｶｽ移動順 }
		TRetFocusSeq = (ByTab,      { ﾀﾌﾞ順 }
						ByPosY,     { 始点順(Y優先) }
						ByPosX);    { 始点順(X優先) }

		{ ﾌｧｲﾙ名要素 }
		TFileNameElement = (
			fneDrive,
			fneDirectory,
			fneFname,
			fneExtension
		);
		TFileNameElements = set of TFileNameElement;

		{ 日付ﾁｪｯｸ結果 }
		TCheckDateStat = (
			cdsOk,
			cdsIllegalYear,
			cdsIllegalMonth,
			cdsIllegalDay
		);

	{ 文字、文字列関係 }
	function    IsSign(c:Char):Boolean;
	function    IsKana(c:Char):Boolean;
	function    IsAlpha(c:Char):Boolean;
	function    IsNumSign(c:Char):Boolean;
	function    IsNum(c:Char):Boolean;
	function    IsKanji(c:Char):Boolean;
	function    IsCntrl(c:Char):Boolean;
	procedure   CutLeftSpc(var Str:String);
	procedure   CutRightSpc(var Str:String);
	procedure   AlignString(var Text:String; Len:Integer; Alignment:TAlignment);
	procedure   DelStrChr(var Text:String; c:Char);
	function    GetNumStrAttr(Str:String; var Attr:THNumStrAttr):Boolean;
	procedure   KanmaEdit(var Str:String);
	function    CountChar(Str:String; c:Char):Integer;
	function    StrChr(Str:String; c:Char):Integer;
	function    StrChrR(Str:String; c:Char):Integer;
//	procedure   FnSplit(FullPath:String; var Drive:String; var Direct:String; var Fname:String; var Ext:String);  // 2009.08.10 Del
//	function    GetFileNameElements(FileName:String):TFileNameElements;         // 2009.08.10 Del
//	function    GetWordCharCode(AWord:String):Word;                             // 2009.08.10 Del
	function    SpnStrR(Src:String; Len:Integer):String;
	procedure   SeparateString(Src:String; var s1:String; var s2:String; Separator:Char);
{$IFDEF UPDATE}
	function    MakeRepeatString(Src:String; n:Integer):String;
{$ENDIF}
    function    HSpcCut(szParam: String): String;

	{ 日付関係 }
	function    CheckYear(AYear:Integer):Boolean;
	function    CheckMonth(AMonth:Integer):Boolean;
	function    GetMonthDay(AYear, AMonth:Integer):Integer;
	procedure   ShiftDate(var AYear:Integer; var AMonth:Integer; var ADay:Integer; Delta:Integer);
	function    EncodeLongDate(AYear, AMonth, ADay:Integer):Longint;
	procedure   DecodeLongDate(ADate:Longint; var AYear, AMonth, ADay:Integer);
	function    GetDateDiffer(ADate1:Longint; ADate2:Longint):Longint;
	function    EncodeLongTime(AHour, AMinute, ASecond:Integer):Longint;
	procedure   DecodeLongTime(ATime:Longint; var AHour, AMinute, ASecond:Integer);
	function    CheckDate(AYear:Integer; AMonth:Integer; ADay:Integer):TCheckDateStat;
	function    CheckLongDate(ADate:Longint):TCheckDateStat;

	{ 座標、矩形関係 }
	function    IsIncludePoint(Pt:TPoint; Rect:TRect):Boolean;
	function    IsIncludeRect(Rc:TRect; Rect:TRect):Boolean;
	function    ShiftPoint(Point:TPoint; DX, DY:Integer):TPoint;
	function    ShiftRect(Rect:TRect; DX, DY:Integer):TRect;
	function    IsSameRect(Rc1:TRect; Rc2:TRect):Boolean;
	function    ExpandRect(ARect:TRect; Delta:Integer):TRect;

	{ ｺﾝﾄﾛｰﾙの座標、矩形関係 }
	function    CmpPosV(a, b:TControl):Integer;
	function    CmpPosH(a, b:TControl):Integer;
	function    GetPosDefV(a, b:TControl):Integer;
	function    GetPosDefH(a, b:TControl):Integer;
	function    CmpStartV(a, b:TControl):Integer;
	function    CmpStartH(a, b:TControl):Integer;
//	function    CmpEndV(a, b:TControl):Integer;
//	function    CmpEndH(a, b:TControl):Integer;
	function    CmpUpper(a, b:TControl):Integer;
	function    CmpLower(a, b:TControl):Integer;
	function    CmpLeft(a, b:TControl):Integer;
	function    CmpRight(a, b:TControl):Integer;
	procedure   GetJustUpperCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl);
	procedure   GetJustLowerCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl);
	procedure   GetJustLeftCtrl(var NextCtrl:TWinControl;  CrntCtrl:TWinControl; Parent:TWinControl);
	procedure   GetJustRightCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl);
	procedure   GetUpperCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TArrowFocusSeq);
	procedure   GetLowerCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TArrowFocusSeq);
	procedure   GetLeftCtrl(var NextCtrl:TWinControl;  CrntCtrl:TWinControl; Parent:TWinControl; Seq:TArrowFocusSeq);
	procedure   GetRightCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TArrowFocusSeq);
	procedure   GetNextCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TRetFocusSeq);
	procedure   GetPrevCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TRetFocusSeq);
	procedure   GetTopCtrl(var WinCtrl:TWinControl; Parent:TWinControl; Seq:TRetFocusSeq);
	procedure   GetBtmCtrl(var WinCtrl:TWinControl; Parent:TWinControl; Seq:TRetFocusSeq);
	function    GetControlRect(Control:TControl):TRect;

	{ ｺﾝﾄﾛｰﾙ操作関係 }
	function    CreateControl(Owner:TComponent; Control:TControl):TControl;
	procedure   CopyControlProperty(Dst:TControl; Src:TControl);
	procedure   CopyLabelProperty(Dst:TLabel; Src:TLabel);
	procedure   CopyEditProperty(Dst:TEdit; Src:TEdit);
	procedure   CopyButtonProperty(Dst:TButton; Src:TButton);
	procedure   CopyCheckBoxProperty(Dst:TCheckBox; Src:TCheckBox);
	procedure   CopyRadioButtonProperty(Dst:TRadioButton; Src:TRadioButton);
	procedure   CopyComboBoxProperty(Dst:TComboBox; Src:TComboBox);
	procedure   CopyRadioGroupProperty(Dst:TRadioGroup; Src:TRadioGroup);
	procedure   CopyPanelProperty(Dst:TPanel; Src:TPanel);
	procedure   CopyBitBtnProperty(Dst:TBitBtn; Src:TBitBtn);
	procedure   CopyMaskEditProperty(Dst:TMaskEdit; Src:TMaskEdit);
	procedure   CopyImageProperty(Dst:TImage; Src:TImage);
	procedure   CopyShapeProperty(Dst:TShape; Src:TShape);
	procedure   CopyBevelProperty(Dst:TBevel; Src:TBevel);
	procedure   CopyXEditProperty(Dst:THEdit; Src:THEdit);
	procedure   CopyXNeditProperty(Dst:THNedit; Src:THNedit);
	procedure   CopyXDateEditProperty(Dst:THDateEdit; Src:THDateEdit);
//	procedure   CopyXTimeEditProperty(Dst:TXTimeEdit; Src:TXTimeEdit);
//	procedure   CopyXValueEditProperty(Dst:TXValueEdit; Src:TXValueEdit);
//{$IFDEF ADDCOMRADE}
//	procedure   CopyVEditProperty(Dst:TVEdit; Src:TVEdit);
//	procedure   CopyVFormatEditProperty(Dst:TVFormatEdit; Src:TVFormatEdit);
//	procedure   CopyVDateEditProperty(Dst:TVDateEdit; Src:TVDateEdit);
//	procedure   CopyVTimeEditProperty(Dst:TVTimeEdit; Src:TVTimeEdit);
//	procedure   CopyVCalcEditProperty(Dst:TVCalcEdit; Src:TVCalcEdit);
//	procedure   CopyVValueEditProperty(Dst:TVValueEdit; Src:TVValueEdit);
//	procedure   CopyVNEditProperty(Dst:TVNEdit; Src:TVNEdit);
//	procedure   CopyVButtonProperty(Dst:TVButton; Src:TVButton);
//	procedure   CopyVLabelProperty(Dst:TVLabel; Src:TVLabel);
//	procedure   CopyVFormatLabelProperty(Dst:TVFormatLabel; Src:TVFormatLabel);
//{$ENDIF}
//	procedure   CopyXRectangleProperty(Dst:TXRectangle; Src:TXRectangle);
	procedure   CopyXLineProperty(Dst:THLine; Src:THLine);
	procedure   CopyXDoubleCaptionButtonProperty(Dst:THDoubleCaptionButton; Src:THDoubleCaptionButton);
	function    IsReadOnly(Control: TWinControl): Boolean;
	function    IsFocusEnable(WinCtrl:TWinControl):Boolean;
	function    GetBaseControl(Control:TWinControl):TWinControl;
	function    IsMouseFocusControl(Control:TWinControl):Boolean;

	{ その他 }
	function    GetShiftState:TShiftState;
//	function    GetMotiveDirect(ModuleHandle:THandle):String;                   // 2009.08.10 Del
//	procedure   SetWindowRectValue(AHandle:THandle; ALeft, ATop, AWidth, AHeight: Integer);
//	function    GetCurrDataControl(component:TComponent): TComponent;
(* 19990925 ADD ueo 各種INIﾌｧｲﾙﾊﾟｽ取得 begin *)
//        function    HIniPathMakeLib(strIFile:String):String;                  2001.02.26 削除
(* 19990925 ADD ueo 各種INIﾌｧｲﾙﾊﾟｽ取得 end *)

{
******************************************************************************
	implementation部
******************************************************************************
}
implementation

	{ ﾕﾆｯﾄ指定 }
//	uses
//		XTable, DataCtrl;

	{
	***************************************************************************
		記号文字のﾁｪｯｸ

			入力    c       :   検査する文字
			出力    return  :   FALSE/TRUE
	***************************************************************************
	}
	function IsSign(c:Char):Boolean;
	begin
//		IsSign := (c in ['!','"','#','$','%','&','''','(',')',':',';','<','>',    //2009.08.10 Del
//								'?','@','[','\',']','^','{','|','}','~','_']);                //2009.08.10 Del
		IsSign := CharInSet(c , ['!','"','#','$','%','&','''','(',')',':',';','<','>',  // 2009.08.10 Ins
								'?','@','[','\',']','^','{','|','}','~','_']);                      // 2009.08.10 Ins
	end;

	{
	***************************************************************************
		ｶﾅ文字のﾁｪｯｸ

			入力    c       :   検査する文字
			出力    return  :   FALSE/TRUE
	***************************************************************************
	}
	function IsKana(c:Char):Boolean;
	begin
//		IsKana := (c in ['｡'..'ﾟ']);
//    IsKana := CharInSet(c, ['ｱ'..'ﾟ']);
    result := False;
    case Ord(c) of // var wc: WideChar;                               // 2009.08.10 Ins
      $FF61..$FF9F:                                                   // 2009.08.10 Ins
        result := True;                                               // 2009.08.10 Ins
    end;                                                              // 2009.08.10 Ins
	end;

	{
	***************************************************************************
		ｱﾙﾌｧﾍﾞｯﾄ文字のﾁｪｯｸ

			入力    c       :   検査する文字
			出力    return  :   FALSE/TRUE
	***************************************************************************
	}
	function IsAlpha(c:Char):Boolean;
	begin
//		IsAlpha := (c in ['A'..'Z', 'a'..'z']);                                   // 2009.08.10 Del
		IsAlpha := CharInSet(c , ['A'..'Z', 'a'..'z']);                             // 2009.08.10 Ins
	end;

	{
	***************************************************************************
		数値記号文字のﾁｪｯｸ

			入力    c       :   検査する文字
			出力    return  :   FALSE/TRUE
	***************************************************************************
	}
	function IsNumSign(c:Char):Boolean;
	begin
//		IsNumSign := (c in ['-','/','*','+','=','.',',']);                        // 2009.08.10 Del
		IsNumSign := CharInSet(c , ['-','/','*','+','=','.',',']);                  // 2009.08.10 Ins
	end;

	{
	***************************************************************************
		数値文字のﾁｪｯｸ

			入力    c       :   検査する文字
			出力    return  :   FALSE/TRUE
	***************************************************************************
	}
	function IsNum(c:Char):Boolean;
	begin
//		IsNum := (c in ['0'..'9']);                                               // 2009.08.10 Del
		IsNum := CharInSet(c , ['0'..'9']);                                         // 2009.08.10 Ins
	end;

	{
	***************************************************************************
		漢字1ﾊﾞｲﾄ目のﾁｪｯｸ

			入力    c       :   検査する文字
			出力    return  :   FALSE/TRUE
	***************************************************************************
	}
	function IsKanji(c:Char):Boolean;
	begin
//		IsKanji := ((c in [#$81..#$9F]) or (c in [#$E0..#$FC]));                  // 2009.08.10 Ins
    result := True;
    // 半角文字・カナ文字範囲以外を全角文字とみなす
    case Ord(c) of // var wc: WideChar;                                         // 2009.08.10 Ins
       $00..$7F, $FF61..$FF9F:                                                  // 2009.08.10 Ins
        result := false;                                                        // 2009.08.10 Ins
    end;                                                                        // 2009.08.10 Ins

	end;

	{
	***************************************************************************
		制御文字のﾁｪｯｸ

			入力    c       :   検査する文字
			出力    return  :   FALSE/TRUE
	***************************************************************************
	}
	function IsCntrl(c:Char):Boolean;
	begin
//		IsCntrl := ((c in [#$00..#$1F]) or (c = #$7F));                           // 2009.08.10 Del
    result := False;
    case Ord(c) of // var wc: WideChar;                                         // 2009.08.10 Ins
       $00..$1F , $7F:                                                          // 2009.08.10 Ins
        result := True;                                                         // 2009.08.10 Ins
    end;                                                                        // 2009.08.10 Ins

	end;

	{
	***************************************************************************
		左ｽﾍﾟｰｽのｶｯﾄ

			入力    Str     :   編集元文字列
			出力    Str     :   編集後文字列
	***************************************************************************
	}
	procedure CutLeftSpc(var Str:String);
	begin
		while (Length(str) > 0) do begin
			if Str[1] <> ' ' then
				Break;
			Delete(Str, 1, 1);
		end;
	end;

	{
	***************************************************************************
		右ｽﾍﾟｰｽのｶｯﾄ

			入力    Str     :   編集元文字列
			出力    Str     :   編集後文字列
	***************************************************************************
	}
	procedure CutRightSpc(var Str:String);
	var
		i:Integer;
	begin
		i := Length(Str);
		while i > 0 do begin
			if Str[i] <> ' ' then
				Break;
			Delete(Str, i, 1);
			Dec(i);
		end;
	end;

	{
	***************************************************************************
		文字列の詰め方編集

			入力    Text        :   編集元字列
					Len         :   長さ
					Alignment   :   詰め方
			出力    Str         :   編集後文字列
	***************************************************************************
	}
	procedure AlignString(var Text:String; Len:Integer; Alignment:TAlignment);
	var
		Str:String;
		TxtLen:Integer;
		N:Integer;
	begin
		TxtLen := Length(Text);

		if (Alignment <> alNone) and (TxtLen < Len) then begin
			CutRightSpc(Text);
			CutLeftSpc(Text);

			case Alignment of
			alLeft:
				begin
					Str := Format('%-*s', [Len, Text]);
					Text := Str;
				end;
			alCenter:
				begin
					N := TxtLen + Round((Len - TxtLen) / 2);
					Str := Format('%*s', [N, Text]);
					Text := Format('%-*s', [Len, Str]);
				end;
			alRight:
				begin
					Str := Format('%*s', [Len, Text]);
					Text := Str;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		文字列から指定文字を除去

			入力    Text    :   編集元文字列
					c       :   除去する文字列
			出力    Text    :   編集後文字列
	***************************************************************************
	}
	procedure DelStrChr(var Text:String; c:Char);
	var
		i:Integer;
	begin
		for i := Length(Text) downto 1 do begin
			if Text[i] = c then
				Delete(Text, i, 1);
		end;
	end;

	{
	***************************************************************************
		数値文字列属性の取得

			入力    Str     :   ﾁｪｯｸする文字列
					Attr    :   取得ﾊﾞｯﾌｧ
			出力    Attr    :   数値文字列属性
					return  :   TRUE/FALSE
	***************************************************************************
	}
	{$HINTS	OFF}
	function GetNumStrAttr(Str:String; var Attr:THNumStrAttr):Boolean;
	var
		i:Integer;
		Value:Real;
		Code:Integer;
	begin
		{ 数値文字列の妥当性ﾁｪｯｸ }
		Val(Str, Value, Code);
		if not ((Str[Length(Str)] = '.') and (CountChar(Str, '.') = 1))
		and (Code <> 0) then
			GetNumStrAttr := FALSE

		else begin
			{ 属性初期化 }
			Attr.Sign     := FALSE;
			Attr.HiColumn := 0;
			Attr.Point    := FALSE;
			Attr.LoColumn := 0;

			{ 属性設定 }
			for i := 1 to Length(Str) do begin
				if (Str[i] = '+') or (Str[i] = '-') then Attr.Sign := TRUE
				else if Str[i] = '.' then Attr.Point := TRUE
				else begin
					if not Attr.Point then Inc(Attr.HiColumn)
					else                   Inc(Attr.LoColumn);
				end;
			end;

			GetNumStrAttr := TRUE;
		end;
	end;
	{$HINTS	ON}

	{
	***************************************************************************
		数値文字列に対するｶﾝﾏ編集

			入力    Str     :   編集元
			出力    Str     :   編集先
	***************************************************************************
	}
	procedure KanmaEdit(var Str:String);
	var
		i:Integer;
		n:Integer;
	begin
		n := Pos('.', Str);
		if n = 0 then n := Length(Str)
		else          Dec(n);

		if n > 3 then begin
			i := 1;
			while (n - i > 0) and (Str[n - i] <> '-') do begin
				if (i mod 3 = 0) then
					Insert(',', Str, n - (i - 1));
				Inc(i);
			end;
		end;
	end;

	{
	***************************************************************************
		文字列中の文字の数を数える（ANKのみ）

			入力    Str     :   文字列
					c       :   文字
			出力    retuirn :   文字数
	***************************************************************************
	}
	function    CountChar(Str:String; c:Char):Integer;
	var
		i:Integer;
	begin
		Result := 0;
		for i := 1 to Length(Str) do
			if Str[i] = c then Inc(Result);
	end;

	{
	***************************************************************************
		文字列中の最初の文字の位置を検査する

			入力    Str     :   文字列
					c       :   文字
			出力    retuirn :   文字位置(1..) / 0=なし

			漢字対応あり
	***************************************************************************
	}
	function    StrChr(Str:String; c:Char):Integer;
	var
		i:Integer;
		Len:Integer;
	begin
		Result := 0;
		i      := 1;
		Len    := Length(Str);

		while i <= Len do begin
			if Str[i] = c then begin
				Result := i;
				Break;
			end;

			if IsKanji(Str[i]) then i := i + 2
			else                    i := i + 1;
		end;
	end;

	{
	***************************************************************************
		文字列中の最後の文字の位置を検査する

			入力    Str     :   文字列
					c       :   文字
			出力    retuirn :   文字位置(1..) / 0=なし

			漢字対応あり
	***************************************************************************
	}
	function    StrChrR(Str:String; c:Char):Integer;
	var
		i:Integer;
		Hit:Boolean;
	begin
		Result := 0;
		i      := Length(Str);
		Hit    := FALSE;

		while i >= 1 do begin
			if Str[i] = c then begin
				if i = 1 then Hit := TRUE
				else if not IsKanji(Str[i]) then Hit := TRUE;

				if Hit then begin
					Result := i;
					Break;
				end;
			end;

			Dec(i);
			if (i > 1) and IsKanji(Str[i]) then Dec(i);
		end;
	end;

	{
	***************************************************************************
		ﾌﾙﾊﾟｽ名を分解する

			入力    Fullpath    :   ﾌﾙﾊﾟｽ
			出力    Drive       :   ﾄﾞﾗｲﾌﾞ（X:）/ ''
					Direct      :   ﾃﾞｨﾚｸﾄﾘ（Directory\）/ ''
					Fname       :   ﾌｧｲﾙ名（Filename）/ ''
					Ext         :   拡張子（.Extension）/''

			漢字対応あり
	***************************************************************************
	}
// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
	procedure   FnSplit(FullPath:String; var Drive:String; var Direct:String; var Fname:String; var Ext:String);
	var
		Src:String;
		Index:Integer;
	begin
		Src    := FullPath;
		Drive  := '';
		Direct := '';
		Fname  := '';
		Ext    := '';

		{ ﾄﾞﾗｲﾌﾞ名 }
		Index := StrChr(Src, ':');
		if Index <> 0 then begin
			Drive := Copy(Src, 1, Index);
			Delete(Src, 1, Index);
		end;

		{ 拡張子 }
		Index := StrChrR(Src, '.');
		if Index <> 0 then begin
			Ext := Copy(Src, Index, Length(Src) - Index + 1);
			Delete(Src, Index, Length(Src) - Index + 1);
		end;

		{ ﾌｧｲﾙ名 }
		Index := StrChrR(Src, '\');
		if Index = 0 then begin
			Fname := Src;
			Src := '';
		end
		else begin
			Fname := Copy(Src, Index + 1, Length(Src) - Index);
			Delete(Src, Index + 1, Length(Src) - Index);
		end;

		{ ﾃﾞｨﾚｸﾄﾘ }
		Direct := Src;
	end;

	{
	***************************************************************************
		ﾌｧｲﾙ名ﾉ構成要素を取得する
	***************************************************************************
	}
	function    GetFileNameElements(FileName:String):TFileNameElements;
	var
		Drive:String;
		Direct:String;
		Fname:String;
		Ext:String;
	begin
		FnSplit(FileName, Drive, Direct, Fname, Ext);
		Result := [];
		if Drive  <> '' then Result := Result + [fneDrive];
		if Direct <> '' then Result := Result + [fneDirectory];
		if Fname  <> '' then Result := Result + [fneFname];
		if Ext    <> '' then Result := Result + [fneExtension];
	end;

	{
	***************************************************************************
		全角ｺｰﾄﾞの取得

			入力    AWord   :   文字列（先頭の1ﾜｰﾄﾞを検査する）
			出力    return  :   全角ｺｰﾄﾞ
	***************************************************************************
	}
	function    GetWordCharCode(AWord:String):Word;
	begin
		Result := Ord(AWord[1]) * 256 + Ord(AWord[2]);
	end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

	{
	***************************************************************************
		文字列を最大の長さに調節する

			入力    Src     :   元の文字列
					Len     :   ﾊﾞｲﾄ数
			出力    return  :   調節後の文字列
	***************************************************************************
	}
	function    SpnStrR(Src:String; Len:Integer):String;
	var
		i:Integer;
		SrcLength:Integer;
		Dst:String;
	begin
		SrcLength := Length(Src);
		Dst := '';
		for i := 0 to Length(Src)  - 1 do begin
			if i >= Len then
				Break;
			Insert(Src[SrcLength - i], Dst, 1);
		end;

		Result := Dst;
	end;

	{
	***************************************************************************
		文字列の分割

			入力    Src         :   元の文字列
					Separator   :   区切り子
			出力    s1, s2      :   分解された文字列
	***************************************************************************
	}
	procedure   SeparateString(Src:String; var s1:String; var s2:String; Separator:Char);
	var
		i:Integer;
		str:String;
	begin
		s1  := ''; s2  := '';
		str := '';
		for i := 1 to Length(Src) do begin
			if Src[i] = ' ' then
				continue
			else if Src[i] <> Separator then
				Insert(Src[i], Str, Length(Str) + 1)
			else begin
				s1  := Str;
				Str := '';
			end;
		end;
		s2 := Str;
	end;

{$IFDEF UPDATE}
	{
	***************************************************************************
		繰り返し文字列の生成

			入力    Src     :   元の文字列
					n       :   繰り返し数
			出力    return  :   繰り返し文字列
	***************************************************************************
	}
	function    MakeRepeatString(Src:String; n:Integer):String;
	var
		i:Integer;
	begin
		Result := '';
		for i := 0 to n - 1 do
			Result := Result + Src;
	end;
{$ENDIF}

	{
	***************************************************************************
		年のﾁｪｯｸ

			入力    AYear   :   年
			出力    return  :   TRUE/FALSE
	***************************************************************************
	}
	function    CheckYear(AYear:Integer):Boolean;
	begin
		Result := (kMinYear <= AYear) and (AYear <= kMaxYear);
	end;

	{
	***************************************************************************
		月のﾁｪｯｸ

			入力    AMonth  :   月
			出力    return  :   TRUE/FALSE
	***************************************************************************
	}
	function    CheckMonth(AMonth:Integer):Boolean;
	begin
		Result := (kMinMonth <= AMonth) and (AMonth <= kMaxMonth);
	end;

	{
	***************************************************************************
		一ヶ月の日数の取得

			入力    AYear   :   年
			　　    AMonth  :   月
			出力    return  :   日数
	***************************************************************************
	}
	function    GetMonthDay(AYear, AMonth:Integer):Integer;
		function IsLeapYear(AYear:Integer):Boolean;
		begin
			Result := (AYear mod 4 = 0) and ((AYear mod 100 <> 0) or (AYear mod 400 = 0));
		end;
	const
		NormYear:array [1..12] of Integer = (31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
		LeapYear:array [1..12] of Integer = (31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
	begin
		if IsLeapYear(AYear) then Result := LeapYear[AMonth]
		else                      Result := NormYear[AMonth];
	end;

	{
	***************************************************************************
		年月日のｼﾌﾄ

			入力    AYear, AMonth, ADay :   年月日
					Delta               :   ｼﾌﾄする日数
			出力    AYear, AMonth, ADay :   ｼﾌﾄ後の年月日
	***************************************************************************
	}
	procedure   ShiftDate(var AYear:Integer; var AMonth:Integer; var ADay:Integer; Delta:Integer);
	var
		NewYear, NewMonth, NewDay:Word;
	begin
		DecodeDate(EncodeDate(AYear, AMonth, ADay) + Delta, NewYear, NewMonth, NewDay);
		AYear  := NewYear;
		AMonth := NewMonth;
		ADay   := NewDay;
	end;

	{
	***************************************************************************
		LongDateにｺｰﾄﾞ化する

			入力    AYear, AMonth, ADay :   年月日
			出力    return              :   LongDate型日付
	***************************************************************************
	}
	function    EncodeLongDate(AYear, AMonth, ADay:Integer):Longint;
	begin
		Result := AYear * 10000 + AMonth * 100 + ADay;
	end;

	{
	***************************************************************************
		LongDateを非ｺｰﾄﾞ化する

			入力    ADate               :   LongDate型日付
			出力    AYear, AMonth, ADay :   年月日
	***************************************************************************
	}
	procedure   DecodeLongDate(ADate:Longint; var AYear, AMonth, ADay:Integer);
	begin
		AYear := ADate div 10000;
		AMonth := (ADate - (AYear * 10000)) div 100;
		ADay := ADate - (AYear * 10000) - (AMonth * 100);
	end;

	{
	***************************************************************************
		LongDateの差を求める

			入力    ADate1, ADate2  :   LongDate型日付
			出力    return          :   ADate1 - ADate2の日数
	***************************************************************************
	}
	function    GetDateDiffer(ADate1:Longint; ADate2:Longint):Longint;
	var
		AYear1, AMonth1, ADay1:Integer;
		AYear2, AMonth2, ADay2:Integer;
	begin
		DecodeLongDate(ADate1, AYear1, AMonth1, ADay1);
		DecodeLongDate(ADate2, AYear2, AMonth2, ADay2);

		Result := Round(EncodeDate(AYear1, AMonth1, ADay1) - EncodeDate(AYear2, AMonth2, ADay2));
	end;
	{
	***************************************************************************
		LongTimeにｺｰﾄﾞ化する

			入力    AHour, AMinute, ASecond :   時分秒
			出力    return                  :   LongTime型時間
	***************************************************************************
	}
	function    EncodeLongTime(AHour, AMinute, ASecond:Integer):Longint;
	begin
		Result := AHour * 10000 + AMinute * 100 + ASecond;
	end;

	{
	***************************************************************************
		LongTimeを非ｺｰﾄﾞ化する

			入力    ATime                   :   LongTime型時間
			出力    AHour, AMinute, ASecond :   時分秒
	***************************************************************************
	}
	procedure   DecodeLongTime(ATime:Longint; var AHour, AMinute, ASecond:Integer);
	begin
		AHour := ATime div 10000;
		AMinute := (ATime - (AHour * 10000)) div 100;
		ASecond := ATime - (AHour * 10000) - (AMinute * 100);
	end;

	{
	***************************************************************************
		年月日の妥当性をﾁｪｯｸする

			入力    AYear, AMonth, ADay :   年月日
			出力    return              :   TRUE/FALSE
	***************************************************************************
	}
	function    CheckDate(AYear:Integer; AMonth:Integer; ADay:Integer):TCheckDateStat;
	begin
		Result := cdsOk;
		if (AYear <> 0) and not CheckYear(AYear) then begin
			Result := cdsIllegalYear;
			Exit;
		end;
		if (AMonth <> 0) and not CheckMonth(AMonth) then begin
			Result := cdsIllegalMonth;
			Exit;
		end;
		if ADay <> 0 then begin
			if (AYear <> 0) and (AMonth <> 0) then begin
				if (ADay < kMinDay) or (GetMonthDay(AYear, AMonth) < ADay) then begin
					Result := cdsIllegalDay;
					Exit;
				end;
			end
			else begin
				if (ADay < kMinDay) or (kMaxDay < ADay) then begin
					Result := cdsIllegalDay;
					Exit;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		LongDateの妥当性をﾁｪｯｸする

			入力    ADate               :   LongDate
			出力    return              :   TRUE/FALSE
	***************************************************************************
	}
	function    CheckLongDate(ADate:Longint):TCheckDateStat;
	var
		AYear, AMonth, ADay:Integer;
	begin
		DecodeLongDate(ADate, AYear, AMonth, ADay);
		Result := CheckDate(AYear, AMonth, ADay);
	end;

	{
	***************************************************************************
		座標の矩形包含検査

			入力    Pt      :   検査する座標
					Rect    :   対象となる矩形
			出力    return  :   FALSE/TRUE
	***************************************************************************
	}
	function    IsIncludePoint(Pt:TPoint; Rect:TRect):Boolean;
	begin
		if (Pt.X < Rect.Left) or (Rect.Right < Pt.X) then
			IsIncludePoint := False
		else if (Pt.Y < Rect.Top) or (Rect.Bottom < Pt.Y) then
			IsIncludePoint := False
		else
			IsIncludePoint := True;
	end;

	{
	***************************************************************************
		矩形の矩形包含検査

			入力    Pt      :   検査する矩形
					Rect    :   対象となる矩形
			出力    return  :   FALSE/TRUE
	***************************************************************************
	}
	function    IsIncludeRect(Rc:TRect; Rect:TRect):Boolean;
	begin
		if (Rc.Left < Rect.Left) or (Rect.Right < Rc.Right) then
			IsIncludeRect := False
		else if (Rc.Top < Rect.Top) or (Rect.Bottom < Rc.Bottom) then
			IsIncludeRect := False
		else
			IsIncludeRect := True;
	end;

	{
	***************************************************************************
		TPoint型のｼﾌﾄ

			入力    Point   :   ｼﾌﾄ前の座標
					DX, DY  :   ｼﾌﾄするﾄﾞｯﾄ数
			出力    return  :   ｼﾌﾄ後の座標
	***************************************************************************
	}
	function    ShiftPoint(Point:TPoint; DX, DY:Integer):TPoint;
	begin
		ShiftPoint.X := Point.X + DX;
		ShiftPoint.Y := Point.Y + DY;
	end;

	{
	***************************************************************************
		TRect型のｼﾌﾄ

			入力    Rect    :   ｼﾌﾄ前の矩形
					DX, DY  :   ｼﾌﾄするﾄﾞｯﾄ数
			出力    return  :   ｼﾌﾄ後の矩形
	***************************************************************************
	}
	function    ShiftRect(Rect:TRect; DX, DY:Integer):TRect;
	begin
		with Rect do begin
			Result.Left   := Left   + DX;
			Result.Top    := Top    + DY;
			Result.Right  := Right  + DX;
			Result.Bottom := Bottom + DY;
		end;
	end;

	{
	***************************************************************************
		TRect型が等価かどうか調べる

			入力    Rc1, Rc2    :   調査するTRect
			出力    return      :   True/False
	***************************************************************************
	}
	function    IsSameRect(Rc1:TRect; Rc2:TRect):Boolean;
	begin
		if      Rc1.Left   <> Rc2.Left   then Result := False
		else if Rc1.Top    <> Rc2.Top    then Result := False
		else if Rc1.Right  <> Rc2.Right  then Result := False
		else if Rc1.Bottom <> Rc2.Bottom then Result := False
		else                                  Result := True;
	end;

	{
	***************************************************************************
		矩形の拡大

			入力    ARect   :   元の矩形
					Delta   :   拡大量（ﾄﾞｯﾄ）
			出力    return  :   拡大後の矩形
			縮小する場合はDeltaにﾏｲﾅｽ値を
	***************************************************************************
	}
	function    ExpandRect(ARect:TRect; Delta:Integer):TRect;
	begin
		with ARect do
			Result := Rect(Left - Delta, Top - Delta, Right + Delta, Bottom + Delta);
	end;

	{
	***************************************************************************
		TControl座標の縦方向の比較
	***************************************************************************
	}
	function CmpPosV(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
	begin
//{$IFDEF VDATE_PLUSPOS}
//		if not (a = nil) then
//			if  (GetBaseControl(TWinControl(a)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(a)) is TVTimeEdit) then
//				a := GetBaseControl(TWinControl(a));
//		if not (b = nil) then
//			if  (GetBaseControl(TWinControl(b)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(b)) is TVTimeEdit) then
//				b := GetBaseControl(TWinControl(b));
//{$ENDIF}
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Left, aRect.Top);
//			bPoint := Point(bRect.Left, bRect.Top);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left, a.Top));
			bPoint := b.Parent.ClientToScreen(Point(b.Left, b.Top));
//		end;

		if      aPoint.Y + a.Height - 1 < bPoint.Y then Result := -1
		else if aPoint.Y > bPoint.Y + b.Height - 1 then Result := 1
		else                                            Result := 0
	end;

	{
	***************************************************************************
		TControl座標の横方向の比較
	***************************************************************************
	}
	function CmpPosH(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
	begin
//{$IFDEF VDATE_PLUSPOS}
//		if not (a = nil) then
//			if  (GetBaseControl(TWinControl(a)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(a)) is TVTimeEdit) then
//				a := GetBaseControl(TWinControl(a));
//		if not (b = nil) then
//			if  (GetBaseControl(TWinControl(b)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(b)) is TVTimeEdit) then
//				b := GetBaseControl(TWinControl(b));
//{$ENDIF}
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Left, aRect.Top);
//			bPoint := Point(bRect.Left, bRect.Top);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left, a.Top));
			bPoint := b.Parent.ClientToScreen(Point(b.Left, b.Top));
//		end;
//
		if      aPoint.X + a.Width - 1 < bPoint.X then Result := -1
		else if aPoint.X > bPoint.X + b.Width - 1 then Result := 1
		else                                           Result := 0
	end;

	{
	***************************************************************************
		縦方向の座標差の取得
	***************************************************************************
	}
	function GetPosDefV(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
		aCenter, bCenter:Integer;
//		aRect,  bRect:TRect;
	begin
//{$IFDEF VDATE_PLUSPOS}
//		if not (a = nil) then
//			if  (GetBaseControl(TWinControl(a)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(a)) is TVTimeEdit) then
//				a := GetBaseControl(TWinControl(a));
//		if not (b = nil) then
//			if  (GetBaseControl(TWinControl(b)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(b)) is TVTimeEdit) then
//				b := GetBaseControl(TWinControl(b));
//{$ENDIF}
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Left, aRect.Top);
//			bPoint := Point(bRect.Left, bRect.Top);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left, a.Top));
			bPoint := b.Parent.ClientToScreen(Point(b.Left, b.Top));
//		end;
//
		aCenter := (aPoint.Y  +  (aPoint.Y + a.Height - 1)) div 2;
		bCenter := (bPoint.Y  +  (bPoint.Y + b.Height - 1)) div 2;

		Result := abs(aCenter - bCenter);
	end;

	{
	***************************************************************************
		横方向の座標差の取得
	***************************************************************************
	}
	function GetPosDefH(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
		aCenter, bCenter:Integer;
//		aRect,  bRect:TRect;
	begin
//{$IFDEF VDATE_PLUSPOS}
//		if not (a = nil) then
//			if  (GetBaseControl(TWinControl(a)) is TVDateEdit) or
// 				(GetBaseControl(TWinControl(a)) is TVTimeEdit) then
//				a := GetBaseControl(TWinControl(a));
//		if not (b = nil) then
//			if  (GetBaseControl(TWinControl(b)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(b)) is TVTimeEdit) then
//				b := GetBaseControl(TWinControl(b));
//{$ENDIF}
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Left, aRect.Top);
//			bPoint := Point(bRect.Left, bRect.Top);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left, a.Top));
			bPoint := b.Parent.ClientToScreen(Point(b.Left, b.Top));
//		end;

		aCenter := (aPoint.X  +  (aPoint.X + a.Height - 1)) div 2;
		bCenter := (bPoint.X  +  (bPoint.X + b.Height - 1)) div 2;

		Result := abs(aCenter - bCenter);
	end;

	{
	***************************************************************************
		TControl始点座標の縦方向の比較
	***************************************************************************
	}
	function    CmpStartV(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
	begin
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Left, aRect.Top);
//			bPoint := Point(bRect.Left, bRect.Top);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left, a.Top));
			bPoint := b.Parent.ClientToScreen(Point(b.Left, b.Top));
//		end;

		Result := aPoint.Y - bPoint.Y;
		if Result = 0 then
			Result := aPoint.X - bPoint.X;
	end;

	{
	***************************************************************************
		TControl始点座標の縦方向の比較
	***************************************************************************
	}
	function    CmpStartH(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
	begin
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Left, aRect.Top);
//			bPoint := Point(bRect.Left, bRect.Top);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left, a.Top));
			bPoint := b.Parent.ClientToScreen(Point(b.Left, b.Top));
//		end;

		Result := aPoint.X - bPoint.X;
		if Result = 0 then
			Result := aPoint.Y - bPoint.Y;
	end;

	{
	***************************************************************************
		TControl終点座標の縦方向の比較
	***************************************************************************
	}
//	function    CmpEndV(a, b:TControl):Integer;
//	var
//		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
//	begin
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Right, aRect.Bottom);
//			bPoint := Point(bRect.Right, bRect.Bottom);
//		end
//		else begin
//			aPoint := a.Parent.ClientToScreen(Point(a.Left + a.Width - 1, a.Top + a.Height - 1));
//			bPoint := b.Parent.ClientToScreen(Point(b.Left + b.Width - 1, b.Top + b.Height - 1));
//		end;
//
//		Result := aPoint.Y - bPoint.Y;
//		if Result = 0 then
//			Result := aPoint.X - bPoint.X;
//	end;

	{
	***************************************************************************
		TControl終点座標の縦方向の比較
	***************************************************************************
	}
//	function    CmpEndH(a, b:TControl):Integer;
//	var
//		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
//	begin
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Right, aRect.Bottom);
//			bPoint := Point(bRect.Right, bRect.Bottom);
//		end
//		else begin
//			aPoint := a.Parent.ClientToScreen(Point(a.Left + a.Width - 1, a.Top + a.Height - 1));
//			bPoint := b.Parent.ClientToScreen(Point(b.Left + b.Width - 1, b.Top + b.Height - 1));
//		end;
//
//		Result := aPoint.X - bPoint.X;
//		if Result = 0 then
//			Result := aPoint.Y - bPoint.Y;
//	end;

	{
	***************************************************************************

	***************************************************************************
	}
	function    CmpUpper(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
	begin
//{$IFDEF VDATE_PLUSPOS}
//		if not (a = nil) then
//			if  (GetBaseControl(TWinControl(a)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(a)) is TVTimeEdit) then
//				a := GetBaseControl(TWinControl(a));
//		if not (b = nil) then
//			if  (GetBaseControl(TWinControl(b)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(b)) is TVTimeEdit) then
//				b := GetBaseControl(TWinControl(b));
//{$ENDIF}
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Left, aRect.Top);
//			bPoint := Point(bRect.Left, bRect.Top);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left, a.Top));
			bPoint := b.Parent.ClientToScreen(Point(b.Left, b.Top));
//		end;

		Result := aPoint.Y - bPoint.Y;
	end;

	{
	***************************************************************************

	***************************************************************************
	}
	function    CmpLower(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
	begin
//{$IFDEF VDATE_PLUSPOS}
//		if not (a = nil) then
//			if  (GetBaseControl(TWinControl(a)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(a)) is TVTimeEdit) then
//				a := GetBaseControl(TWinControl(a));
//		if not (b = nil) then
//			if  (GetBaseControl(TWinControl(b)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(b)) is TVTimeEdit) then
//				b := GetBaseControl(TWinControl(b));
//{$ENDIF}
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Right, aRect.Bottom);
//			bPoint := Point(bRect.Right, bRect.Bottom);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left + a.Width - 1, a.Top + a.Height - 1));
			bPoint := b.Parent.ClientToScreen(Point(b.Left + b.Width - 1, b.Top + b.Height - 1));
//		end;

		Result := aPoint.Y - bPoint.Y;
	end;

	{
	***************************************************************************

	***************************************************************************
	}
	function    CmpLeft(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
	begin
//{$IFDEF VDATE_PLUSPOS}
//		if not (a = nil) then
//			if  (GetBaseControl(TWinControl(a)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(a)) is TVTimeEdit) then
//				a := GetBaseControl(TWinControl(a));
//		if not (b = nil) then
//			if  (GetBaseControl(TWinControl(b)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(b)) is TVTimeEdit) then
//				b := GetBaseControl(TWinControl(b));
//{$ENDIF}
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Left, aRect.Top);
//			bPoint := Point(bRect.Left, bRect.Top);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left, a.Top));
			bPoint := b.Parent.ClientToScreen(Point(b.Left, b.Top));
//		end;

		Result := aPoint.X - bPoint.X;
	end;

	{
	***************************************************************************

	***************************************************************************
	}
	function    CmpRight(a, b:TControl):Integer;
	var
		aPoint, bPoint:TPoint;
//		aRect,  bRect:TRect;
	begin
//{$IFDEF VDATE_PLUSPOS}
//		if not (a = nil) then
//			if  (GetBaseControl(TWinControl(a)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(a)) is TVTimeEdit) then
//				a := GetBaseControl(TWinControl(a));
//		if not (b = nil) then
//			if  (GetBaseControl(TWinControl(b)) is TVDateEdit) or
//				(GetBaseControl(TWinControl(b)) is TVTimeEdit) then
//				b := GetBaseControl(TWinControl(b));
//{$ENDIF}
//		if (a.Parent is TXChildPanel) and (b.Parent is TXChildPanel) then begin
//			aRect := TXTable(a.Parent.Parent).GetInitialRect(a);
//			bRect := TXTable(a.Parent.Parent).GetInitialRect(b);
//			aPoint := Point(aRect.Right, aRect.Bottom);
//			bPoint := Point(bRect.Right, bRect.Bottom);
//		end
//		else begin
			aPoint := a.Parent.ClientToScreen(Point(a.Left + a.Width - 1, a.Top + a.Height - 1));
			bPoint := b.Parent.ClientToScreen(Point(b.Left + b.Width - 1, b.Top + b.Height - 1));
//		end;

		Result := aPoint.X - bPoint.X;
	end;

	{
	***************************************************************************
		ちょうど上のｺﾝﾄﾛｰﾙの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetJustUpperCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl);
		procedure SetNextCtrl(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpLower(New, Ctrl) > 0 then
				Ctrl := New
			else if (CmpLower(New, Ctrl) = 0)
			and (GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt)) then
				Ctrl := New;
		end;
	var
		i:Integer;
	begin
		with Parent do begin
			for i := 0 to ControlCount - 1 do begin
				if not (Controls[i] is TWinControl) then
					continue;

				GetJustUpperCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]));

				if (CmpPosH(Controls[i], CrntCtrl) = 0)
				and (CmpUpper(Controls[i], CrntCtrl) < 0)
				and IsFocusEnable(TWinControl(Controls[i])) then begin
//					if not (Controls[i].Parent is TXChildPanel) then
						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//					else if CrntCtrl.Parent is TXChildPanel then
//						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//					else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		ちょうど下のｺﾝﾄﾛｰﾙの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetJustLowerCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl);
		procedure SetNextCtrl(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpUpper(New, Ctrl) < 0 then
				Ctrl := New
			else if (CmpUpper(New, Ctrl) = 0)
			and (GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt)) then
				Ctrl := New;
		end;
	var
		i:Integer;
	begin
		with Parent do begin
			for i := 0 to ControlCount - 1 do begin
				if not (Controls[i] is TWinControl) then
					continue;

				GetJustLowerCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]));

				if (CmpPosH(Controls[i], CrntCtrl) = 0)
				and (CmpLower(Controls[i], CrntCtrl) > 0)
				and IsFocusEnable(TWinControl(Controls[i])) then begin
//					if not (Controls[i].Parent is TXChildPanel) then
						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//					else if CrntCtrl.Parent is TXChildPanel then
//						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//					else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		ちょうど左のｺﾝﾄﾛｰﾙの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetJustLeftCtrl(var NextCtrl:TWinControl;  CrntCtrl:TWinControl; Parent:TWinControl);
		procedure SetNextCtrl(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpRight(New, Ctrl) > 0 then
				Ctrl := New
			else if (CmpRight(New, Ctrl) = 0)
			and (GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt)) then
				Ctrl := New;
		end;
	var
		i:Integer;
	begin
		with Parent do begin
			for i := 0 to ControlCount - 1 do begin
				if not (Controls[i] is TWinControl) then
					continue;

				GetJustLeftCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]));

				if (CmpPosV(Controls[i], CrntCtrl) = 0)
				and (CmpLeft(Controls[i], CrntCtrl) < 0)
				and IsFocusEnable(TWinControl(Controls[i])) then begin
//					if not (Controls[i].Parent is TXChildPanel) then
						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//					else if CrntCtrl.Parent is TXChildPanel then
//						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//					else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		ちょうど右のｺﾝﾄﾛｰﾙの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetJustRightCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl);
		procedure SetNextCtrl(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpLeft(New, Ctrl) < 0 then
				Ctrl := New
			else if (CmpLeft(New, Ctrl) = 0)
			and (GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt)) then
				Ctrl := New;
		end;
	var
		i:Integer;
	begin
		with Parent do begin
			for i := 0 to ControlCount - 1 do begin
				if not (Controls[i] is TWinControl) then
					continue;

				GetJustRightCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]));

				if (CmpPosV(Controls[i], CrntCtrl) = 0)
				and (CmpRight(Controls[i], CrntCtrl) > 0)
				and IsFocusEnable(TWinControl(Controls[i])) then begin
//					if not (Controls[i].Parent is TXChildPanel) then
						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//					else if CrntCtrl.Parent is TXChildPanel then
//						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//					else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//						SetNextCtrl(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		上のｺﾝﾄﾛｰﾙの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetUpperCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TArrowFocusSeq);
		procedure SetByAxis(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt) then
				Ctrl := New
			else if (GetPosDefH(New, Crnt) = GetPosDefH(Ctrl, Crnt))
			and (GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt)) then
				Ctrl := New;
		end;

		procedure SetByDist(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt) then
				Ctrl := New
			else if (GetPosDefV(New, Crnt) = GetPosDefV(Ctrl, Crnt))
			and (GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt)) then
				Ctrl := New;
		end;

	var
		i:Integer;
	begin
		GetJustUpperCtrl(NextCtrl, CrntCtrl, Parent);
		if NextCtrl <> nil then
			Exit;

		with Parent do begin
			case Seq of
			{ 軸優先 }
			ByAxis:
				begin
					for i := 0 to ControlCount - 1 do begin
						if not (Controls[i] is TWinControl) then
							continue;

						GetUpperCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

						if (CmpPosV(Controls[i], CrntCtrl) < 0)
						and IsFocusEnable(TWinControl(Controls[i])) then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
						end;
					end;
				end;
			{ 距離優先 }
			ByDist:
				begin
					for i := 0 to ControlCount - 1 do begin
						if not (Controls[i] is TWinControl) then
							continue;

						GetUpperCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

						if (CmpPosV(Controls[i], CrntCtrl) < 0)
						and IsFocusEnable(TWinControl(Controls[i])) then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByDist(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByDist(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByDist(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
						end;
					end;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		下のｺﾝﾄﾛｰﾙの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetLowerCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TArrowFocusSeq);
		procedure SetByAxis(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt) then
				Ctrl := New
			else if (GetPosDefH(New, Crnt) = GetPosDefH(Ctrl, Crnt))
			and (GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt)) then
				Ctrl := New;
		end;

		procedure SetByDist(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt) then
				Ctrl := New
			else if (GetPosDefV(New, Crnt) = GetPosDefV(Ctrl, Crnt))
			and (GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt)) then
			Ctrl := New;
		end;

	var
		i:Integer;
	begin
		GetJustLowerCtrl(NextCtrl, CrntCtrl, Parent);
		if NextCtrl <> nil then
			Exit;

		with Parent do begin
			case Seq of
			{ 軸優先 }
			ByAxis:
				begin
					for i := 0 to ControlCount - 1 do begin
						if not (Controls[i] is TWinControl) then
							continue;

						GetLowerCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

						if (CmpPosV(Controls[i], CrntCtrl) > 0)
						and IsFocusEnable(TWinControl(Controls[i])) then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
						end;
					end;
				end;
			{ 距離優先 }
			ByDist:
				begin
					for i := 0 to ControlCount - 1 do begin
						if not (Controls[i] is TWinControl) then
							continue;

						GetLowerCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

						if (CmpPosV(Controls[i], CrntCtrl) > 0)
						and IsFocusEnable(TWinControl(Controls[i])) then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByDist(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByDist(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByDist(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
						end;
					end;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		左のｺﾝﾄﾛｰﾙの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetLeftCtrl(var NextCtrl:TWinControl;  CrntCtrl:TWinControl; Parent:TWinControl; Seq:TArrowFocusSeq);
		procedure SetByAxis(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt) then
				Ctrl := New
			else if (GetPosDefV(New, Crnt) = GetPosDefV(Ctrl, Crnt))
			and (GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt)) then
				Ctrl := New;
		end;

		procedure SetByDist(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt) then
				Ctrl := New
			else if (GetPosDefH(New, Crnt) = GetPosDefH(Ctrl, Crnt))
			and (GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt)) then
				Ctrl := New;
		end;

	var
		i:Integer;
	begin
		GetJustLeftCtrl(NextCtrl, CrntCtrl, Parent);
		if NextCtrl <> nil then
			Exit;

		with Parent do begin
			case Seq of
			{ 軸優先 }
			ByAxis:
				begin
					for i := 0 to ControlCount - 1 do begin
						if not (Controls[i] is TWinControl) then
							continue;

						GetLeftCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

						if (CmpPosH(Controls[i], CrntCtrl) < 0)
						and IsFocusEnable(TWinControl(Controls[i])) then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
						end;
					end;
				end;
			{ 距離優先 }
			ByDist:
				begin
					for i := 0 to ControlCount - 1 do begin
						if not (Controls[i] is TWinControl) then
							continue;

						GetLeftCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

						if (CmpPosH(Controls[i], CrntCtrl) < 0)
						and IsFocusEnable(TWinControl(Controls[i])) then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByDist(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByDist(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByDist(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
						end;
					end;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		右のｺﾝﾄﾛｰﾙの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetRightCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TArrowFocusSeq);
		procedure SetByAxis(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt) then
				Ctrl := New
			else if (GetPosDefV(New, Crnt) = GetPosDefV(Ctrl, Crnt))
			and (GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt)) then
				Ctrl := New;
		end;

		procedure SetByDist(var Ctrl:TWinControl; New:TWinControl; Crnt:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if GetPosDefH(New, Crnt) < GetPosDefH(Ctrl, Crnt) then
				Ctrl := New
			else if (GetPosDefH(New, Crnt) = GetPosDefH(Ctrl, Crnt))
			and (GetPosDefV(New, Crnt) < GetPosDefV(Ctrl, Crnt)) then
				Ctrl := New;
		end;

	var
		i:Integer;
	begin
		GetJustRightCtrl(NextCtrl, CrntCtrl, Parent);
		if NextCtrl <> nil then
			Exit;

		with Parent do begin
			case Seq of
			{ 軸優先 }
			ByAxis:
				begin
					for i := 0 to ControlCount - 1 do begin
						if not (Controls[i] is TWinControl) then
							continue;

						GetRightCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

						if (CmpPosH(Controls[i], CrntCtrl) > 0)
						and IsFocusEnable(TWinControl(Controls[i])) then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
						end;
					end;
				end;
			{ 距離優先 }
			ByDist:
				begin
					for i := 0 to ControlCount - 1 do begin
						if not (Controls[i] is TWinControl) then
							continue;

						GetRightCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

						if (CmpPosH(Controls[i], CrntCtrl) > 0)
						and IsFocusEnable(TWinControl(Controls[i])) then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl)
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByAxis(NextCtrl, TWinControl(Controls[i]), CrntCtrl);
						end;
					end;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		次のTWinControlの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetNextCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TRetFocusSeq);
		procedure SetByPosY(var Ctrl:TWinControl; New:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpStartV(New, Ctrl) < 0 then
				Ctrl := New;
		end;

		procedure SetByPosX(var Ctrl:TWinControl; New:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpStartH(New, Ctrl) < 0 then
				Ctrl := New;
		end;

	var
		i:Integer;
		List:TList;

	begin
		with Parent do begin
			case Seq of
			{ ﾀﾌﾟｽﾄｯﾌﾟ順 }
			ByTab:
				begin
					List := TList.Create;
					try
						GetTabOrderList(List);
						if List.Count > 0 then begin
							for i := List.IndexOf(CrntCtrl) + 1 to List.Count - 1 do
								if IsFocusEnable(TWinControl(List[i])) then begin
									NextCtrl := TWinControl(List[i]);
									break;
							end;
						end;
					finally
						List.Destroy;
					end;
				end;
			{ 始点順（Y座標優先） }
			ByPosY:
				for i := 0 to ControlCount - 1 do begin
					if not (Controls[i] is TWinControl) then
						continue;

					GetNextCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

					if IsFocusEnable(TWinControl(Controls[i])) then begin
						if CmpStartV(Controls[i], CrntCtrl) > 0 then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByPosY(NextCtrl, TWinControl(Controls[i]))
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByPosY(NextCtrl, TWinControl(Controls[i]))
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByPosY(NextCtrl, TWinControl(Controls[i]));
						end;
					end;
				end;
			{ 始点順（X座標優先） }
			ByPosX:
				for i := 0 to ControlCount - 1 do begin
					if not (Controls[i] is TWinControl) then
						continue;

					GetNextCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

					if IsFocusEnable(TWinControl(Controls[i])) then begin
						if CmpStartH(Controls[i], CrntCtrl) > 0 then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByPosX(NextCtrl, TWinControl(Controls[i]))
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByPosX(NextCtrl, TWinControl(Controls[i]))
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByPosX(NextCtrl, TWinControl(Controls[i]))
						end;
					end;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		前のTWinControlの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetPrevCtrl(var NextCtrl:TWinControl; CrntCtrl:TWinControl; Parent:TWinControl; Seq:TRetFocusSeq);
		procedure SetByPosY(var Ctrl:TWinControl; New:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpStartV(New, Ctrl) > 0 then
				Ctrl := New;
		end;

		procedure SetByPosX(var Ctrl:TWinControl; New:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpStartH(New, Ctrl) > 0 then
				Ctrl := New;
		end;

	var
		i:Integer;
		List:TList;

	begin
		with Parent do begin
			case Seq of
			{ ﾀﾌﾟｽﾄｯﾌﾟ順 }
			ByTab:
				begin
					List := TList.Create;
					try
						GetTabOrderList(List);
						if List.Count > 0 then begin
							for i := List.IndexOf(CrntCtrl) - 1 downto 0 do begin
								if IsFocusEnable(TWinControl(List[i])) then begin
									NextCtrl := TWinControl(List[i]);
									break;
								end;
							end;
						end;
					finally
						List.Destroy;
					end;
				end;
			{ 終点順（Y座標優先） }
			ByPosY:
				for i := 0 to ControlCount - 1 do begin
					if not (Controls[i] is TWinControl) then
						continue;

					GetPrevCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

					if IsFocusEnable(TWinControl(Controls[i])) then begin
						if CmpStartV(Controls[i], CrntCtrl) < 0 then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByPosY(NextCtrl, TWinControl(Controls[i]))
//							else if CrntCtrl.Parent is TXChildPanel then
//							SetByPosY(NextCtrl, TWinControl(Controls[i]))
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByPosY(NextCtrl, TWinControl(Controls[i]))
						end;
					end;
				end;
			{ 始点順（X座標優先） }
			ByPosX:
				for i := 0 to ControlCount - 1 do begin
					if not (Controls[i] is TWinControl) then
					continue;

					GetPrevCtrl(NextCtrl, CrntCtrl, TWinControl(Controls[i]), Seq);

					if IsFocusEnable(TWinControl(Controls[i])) then begin
						if CmpStartH(Controls[i], CrntCtrl) < 0 then begin
//							if not (Controls[i].Parent is TXChildPanel) then
								SetByPosX(NextCtrl, TWinControl(Controls[i]))
//							else if CrntCtrl.Parent is TXChildPanel then
//								SetByPosX(NextCtrl, TWinControl(Controls[i]))
//							else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//								SetByPosX(NextCtrl, TWinControl(Controls[i]))
						end;
					end;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		先頭のTWinControlの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetTopCtrl(var WinCtrl:TWinControl; Parent:TWinControl; Seq:TRetFocusSeq);
		procedure SetByPosY(var Ctrl:TWinControl; New:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpStartV(New, Ctrl) < 0 then
				Ctrl := New;
		end;

		procedure SetByPosX(var Ctrl:TWinControl; New:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpStartH(New, Ctrl) < 0 then
				Ctrl := New;
		end;

	var
		i:Integer;
		List:TList;

	begin
		with Parent do begin
			case Seq of
			{ ﾀﾌﾟｽﾄｯﾌﾟ順 }
			ByTab:
				begin
					List := TList.Create;
					try
						GetTabOrderList(List);
						if List.Count > 0 then begin
							for i := 0 to List.Count - 1 do
								if IsFocusEnable(TWinControl(List[i])) then begin
									WinCtrl := TWinControl(List[i]);
									break;
								end;
						end;
					finally
						List.Destroy;
				end;
				end;
		{ 始点順（Y座標優先） }
			ByPosY:
				for i := 0 to ControlCount - 1 do begin
					if not (Controls[i] is TWinControl) then
						continue;

					GetTopCtrl(WinCtrl, TWinControl(Controls[i]), Seq);

					if IsFocusEnable(TWinControl(Controls[i])) then begin
//						if not (Controls[i].Parent is TXChildPanel) then
							SetByPosY(WinCtrl, TWinControl(Controls[i]))
//						else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//							SetByPosY(WinCtrl, TWinControl(Controls[i]))
					end;
				end;
			{ 始点順（X座標優先） }
			ByPosX:
				for i := 0 to ControlCount - 1 do begin
					if not (Controls[i] is TWinControl) then
						continue;

					GetTopCtrl(WinCtrl, TWinControl(Controls[i]), Seq);

					if IsFocusEnable(TWinControl(Controls[i])) then begin
//						if not (Controls[i].Parent is TXChildPanel) then
							SetByPosX(WinCtrl, TWinControl(Controls[i]))
//						else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//							SetByPosX(WinCtrl, TWinControl(Controls[i]))
					end;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		末尾のTWinControlの取得（NextCtrlはnilで初期化）
	***************************************************************************
	}
	procedure   GetBtmCtrl(var WinCtrl:TWinControl; Parent:TWinControl; Seq:TRetFocusSeq);
		procedure SetByPosY(var Ctrl:TWinControl; New:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpStartV(New, Ctrl) > 0 then
				Ctrl := New;
		end;

		procedure SetByPosX(var Ctrl:TWinControl; New:TWinControl);
		begin
			if Ctrl = nil then
				Ctrl := New
			else if CmpStartH(New, Ctrl) > 0 then
				Ctrl := New;
		end;

	var
		i:Integer;
		List:TList;

	begin
		with Parent do
		begin
			case Seq of
			{ ﾀﾌﾟｽﾄｯﾌﾟ順 }
			ByTab:
				begin
					List := TList.Create;
					try
						GetTabOrderList(List);
						if List.Count > 0 then begin
							for i := List.Count - 1 downto 0 do
								if IsFocusEnable(TWinControl(List[i])) then begin
									WinCtrl := TWinControl(List[i]);
									break;
								end;
						end;
					finally
						List.Destroy;
					end;
				end;
			{ 始点順（Y座標優先） }
			ByPosY:
				for i := 0 to ControlCount - 1 do
				begin
					if not (Controls[i] is TWinControl) then
						continue;

					GetBtmCtrl(WinCtrl, TWinControl(Controls[i]), Seq);

					if IsFocusEnable(TWinControl(Controls[i])) then begin
//						if not (Controls[i].Parent is TXChildPanel) then
							SetByPosY(WinCtrl, TWinControl(Controls[i]))
//						else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//							SetByPosY(WinCtrl, TWinControl(Controls[i]))
					end;
				end;
			{ 始点順（X座標優先） }
			ByPosX:
				for i := 0 to ControlCount - 1 do
				begin
					if not (Controls[i] is TWinControl) then
						continue;

					GetBtmCtrl(WinCtrl, TWinControl(Controls[i]), Seq);

					if IsFocusEnable(TWinControl(Controls[i])) then begin
//						if not (Controls[i].Parent is TXChildPanel) then
							SetByPosX(WinCtrl, TWinControl(Controls[i]))
//						else if TXTable(Controls[i].Parent.Parent).GetMemberState(Controls[i]) = msVisible then
//							SetByPosX(WinCtrl, TWinControl(Controls[i]))
					end;
				end;
			end;
		end;
	end;

	{
	***************************************************************************
		ｺﾝﾄﾛｰﾙ矩形の取得
	***************************************************************************
	}
	function    GetControlRect(Control:TControl):TRect;
	begin
		with Control do begin
			Result.Left   := Left;
			Result.Top    := Top;
			Result.Right  := Left + Width  - 1;
			Result.Bottom := Top  + Height - 1;
		end;
	end;

	{
	***************************************************************************
		TControl派生ｵﾌﾞｼﾞｪｸﾄの生成

			入力    Owner       :   ｵｰﾅ
					Control     :   複製元ｺﾝﾄﾛｰﾙ
			出力    return      :   生成されたｺﾝﾄﾛｰﾙ

			Controlのｸﾗｽを判定し、該当するｺﾝｽﾄﾗｸﾀを呼び出す。
			ﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰは行わない
	***************************************************************************
	}
	function    CreateControl(Owner:TComponent; Control:TControl):TControl;
	begin
		{ VCL/Xtend palette }
		if      Control is THNedit      then Result := THNedit.Create(Owner)
		else if Control is THEdit       then Result := THEdit.Create(Owner)
		else if Control is THDateEdit   then Result := THDateEdit.Create(Owner)
//		else if Control is TXTimeEdit   then Result := TXTimeEdit.Create(Owner)
//		else if Control is TXValueEdit  then Result := TXValueEdit.Create(Owner)
//{$IFDEF ADDCOMRADE}
//		else if Control is TVDateEdit   then Result := TVDateEdit.Create(Owner)
//		else if Control is TVTimeEdit   then Result := TVTimeEdit.Create(Owner)
//		else if Control is TVEdit       then Result := TVEdit.Create(Owner)
//		else if Control is TVFormatEdit then Result := TVFormatEdit.Create(Owner)
//		else if Control is TVCalcEdit   then Result := TVCalcEdit.Create(Owner)
//		else if Control is TVValueEdit  then Result := TVValueEdit.Create(Owner)
//		else if Control is TVNEdit      then Result := TVNEdit.Create(Owner)
//		else if Control is TVButton     then Result := TVButton.Create(Owner)
//		else if Control is TVLabel      then Result := TVLabel.Create(Owner)
//		else if Control is TVFormatLabel then Result := TVFormatLabel.Create(Owner)
//{$ENDIF}
//		else if Control is TXRectangle  then Result := TXRectangle.Create(Owner)
		else if Control is THLine       then Result := THLine.Create(Owner)
		else if Control is THDoubleCaptionButton then Result := THDoubleCaptionButton.Create(Owner)

		{ Additional palette }
		else if Control is TBitBtn      then Result := TBitBtn.Create(Owner)
		else if Control is TMaskEdit    then Result := TMaskEdit.Create(Owner)
		else if Control is TImage       then Result := TImage.Create(Owner)
		else if Control is TShape       then Result := TShape.Create(Owner)
		else if Control is TBevel       then Result := TBevel.Create(Owner)

		{ Standard palette }
		else if Control is TLabel       then Result := TLabel.Create(Owner)
		else if Control is TEdit        then Result := TEdit.Create(Owner)
		else if Control is TButton      then Result := TButton.Create(Owner)
		else if Control is TCheckBox    then Result := TCheckBox.Create(Owner)
		else if Control is TRadioButton then Result := TRadioButton.Create(Owner)
		else if Control is TComboBox    then Result := TComboBox.Create(Owner)
		else if Control is TRadioGroup  then Result := TRadioGroup.Create(Owner)
		else if Control is TPanel       then Result := TPanel.Create(Owner)

		{ Other }
		else Result := nil;
	end;

	{
	***************************************************************************
		TControlﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyControlProperty(Dst:TControl; Src:TControl);
	begin
		{ VCL/Xtend palette }
		if      Src is THNedit         then CopyXNeditProperty(THNedit(Dst), THNedit(Src))
		else if Src is THEdit          then CopyXEditProperty(THEdit(Dst), THEdit(Src))
		else if Src is THDateEdit      then CopyXDateEditProperty(THDateEdit(Dst), THDateEdit(Src))
//		else if Src is TXTimeEdit      then CopyXTimeEditProperty(TXTimeEdit(Dst), TXTimeEdit(Src))
//		else if Src is TXValueEdit     then CopyXValueEditProperty(TXValueEdit(Dst), TXValueEdit(Src))
//{$IFDEF ADDCOMRADE}
//		else if Src is TVDateEdit      then CopyVDateEditProperty(TVDateEdit(Dst), TVDateEdit(Src))
//		else if Src is TVTimeEdit      then CopyVTimeEditProperty(TVTimeEdit(Dst), TVTimeEdit(Src))
//		else if Src is TVEdit          then CopyVEditProperty(TVEdit(Dst), TVEdit(Src))
//		else if Src is TVFormatEdit    then CopyVFormatEditProperty(TVFormatEdit(Dst), TVFormatEdit(Src))
//		else if Src is TVCalcEdit      then CopyVCalcEditProperty(TVCalcEdit(Dst), TVCalcEdit(Src))
//		else if Src is TVValueEdit     then CopyVValueEditProperty(TVValueEdit(Dst), TVValueEdit(Src))
//		else if Src is TVNEdit         then CopyVNEditProperty(TVNEdit(Dst), TVNEdit(Src))
//		else if Src is TVButton        then CopyVButtonProperty(TVButton(Dst), TVButton(Src))
//		else if Src is TVLabel         then CopyVLabelProperty(TVLabel(Dst), TVLabel(Src))
//		else if Src is TVFormatLabel   then CopyVFormatLabelProperty(TVFormatLabel(Dst), TVFormatLabel(Src))
//{$ENDIF}
//		else if Src is TXRectangle     then CopyXRectangleProperty(TXRectangle(Dst), TXRectangle(Src))
		else if Src is THLine          then CopyXLineProperty(THLine(Dst), THLine(Src))
		else if Src is THDoubleCaptionButton then CopyXDoubleCaptionButtonProperty(THDoubleCaptionButton(Dst), THDoubleCaptionButton(Src))

		{ Additional palette }
		else if Src is TBitBtn         then CopyBitBtnProperty(TBitBtn(Dst), TBitBtn(Src))
		else if Src is TMaskEdit       then CopyMaskEditProperty(TMaskEdit(Dst), TMaskEdit(Src))
		else if Src is TImage          then CopyImageProperty(TImage(Dst), TImage(Src))
		else if Src is TShape          then CopyShapeProperty(TShape(Dst), TShape(Src))
		else if Src is TBevel          then CopyBevelProperty(TBevel(Dst), TBevel(Src))

		{ Standard palette }
		else if Src is TLabel          then CopyLabelProperty(TLabel(Dst), TLabel(Src))
		else if Src is TEdit           then CopyEditProperty(TEdit(Dst), TEdit(Src))
		else if Src is TButton         then CopyButtonProperty(TButton(Dst), TButton(Src))
		else if Src is TCheckBox       then CopyCheckBoxProperty(TCheckBox(Dst), TCheckBox(Src))
		else if Src is TRadioButton    then CopyRadioButtonProperty(TRadioButton(Dst), TRadioButton(Src))
		else if Src is TComboBox       then CopyComboBoxProperty(TComboBox(Dst), TComboBox(Src))
		else if Src is TRadioGroup     then CopyRadioGroupProperty(TRadioGroup(Dst), TRadioGroup(Src))
		else if Src is TPanel          then CopyPanelProperty(TPanel(Dst), TPanel(Src))

		{ Other }
		else ;
	end;

	{
	***************************************************************************
		TLabelﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyLabelProperty(Dst:TLabel; Src:TLabel);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Align          := Src.Align;
		Dst.Alignment      := Src.Alignment;
		Dst.AutoSize       := Src.AutoSize;
		Dst.Caption        := Src.Caption;
		Dst.Color          := Src.Color;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.FocusControl   := Src.FocusControl;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.Hint           := Src.Hint;
		Dst.Left           := Src.Left;
{       Dst.Name           := Src.Name; }
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ShowAccelChar  := Src.ShowAccelChar;
		Dst.ShowHint       := Src.ShowHint;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Transparent    := Src.Transparent;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;
		Dst.WordWrap       := Src.WordWrap;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnClick        := Src.OnClick;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyEditProperty(Dst:TEdit; Src:TEdit);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.AutoSelect     := Src.AutoSelect;
		Dst.AutoSize       := Src.AutoSize;
		Dst.BorderStyle    := Src.BorderStyle;
		Dst.CharCase       := Src.CharCase;
		Dst.Color          := Src.Color;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.HideSelection  := Src.HideSelection;
		Dst.Hint           := Src.Hint;
		Dst.ImeMode        := Src.ImeMode;
		Dst.Left           := Src.Left;
		Dst.MaxLength      := Src.MaxLength;
{        Dst.Name           := Src.Name;        }
		Dst.OEMConvert     := Src.OEMConvert;
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentCtl3D    := Src.ParentCtl3D;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PasswordChar   := Src.PasswordChar;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ReadOnly       := Src.ReadOnly;
		Dst.ShowHint       := Src.ShowHint;
{       Dst.TabOrder       := Src.TabOrder;     }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Text           := Src.Text;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnChange       := Src.OnChange;
		Dst.OnClick        := Src.OnClick;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyPress     := Src.OnKeyPress;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TButtonﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyButtonProperty(Dst:TButton; Src:TButton);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Cancel         := Src.Cancel;
		Dst.Caption        := Src.Caption;
		Dst.Cursor         := Src.Cursor;
		Dst.Default        := Src.Default;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.Hint           := Src.Hint;
		Dst.Left           := Src.Left;
		Dst.ModalResult    := Src.ModalResult;
{       Dst.Name           := Src.Name;             }
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ShowHint       := Src.ShowHint;
{       Dst.TabOrder       := Src.TabOrder;         }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnClick        := Src.OnClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyPress     := Src.OnKeyPress;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TCheckBoxﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyCheckBoxProperty(Dst:TCheckBox; Src:TCheckBox);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Alignment      := Src.Alignment;
		Dst.AllowGrayed    := Src.AllowGrayed;
		Dst.Caption        := Src.Caption;
		Dst.Checked        := Src.Checked;
		Dst.Color          := Src.Color;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.Hint           := Src.Hint;
		Dst.Left           := Src.Left;
{       Dst.Name           := Src.Name;         }
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentCtl3D    := Src.ParentCtl3D;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ShowHint       := Src.ShowHint;
		Dst.State          := Src.State;
{       Dst.TabOrder       := Src.TabOrder;     }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnClick        := Src.OnClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyPress     := Src.OnKeyPress;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TRadioButtonﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyRadioButtonProperty(Dst:TRadioButton; Src:TRadioButton);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Alignment      := Src.Alignment;
		Dst.Caption        := Src.Caption;
		Dst.Checked        := Src.Checked;
		Dst.Color          := Src.Color;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.Hint           := Src.Hint;
		Dst.Left           := Src.Left;
{       Dst.Name           := Src.Name;         }
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentCtl3D    := Src.ParentCtl3D;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ShowHint       := Src.ShowHint;
{       Dst.TabOrder       := Src.TabOrder;     }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnClick        := Src.OnClick;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyPress     := Src.OnKeyPress;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TComboBoxﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyComboBoxProperty(Dst:TComboBox; Src:TComboBox);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Color          := Src.Color;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.DropDownCount  := Src.DropDownCount;
		Dst.Enabled        := Src.Enabled;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.Hint           := Src.Hint;
		Dst.ImeMode        := Src.ImeMode;
		Dst.ItemHeight     := Src.ItemHeight;
		Dst.Items          := Src.Items;
		Dst.Left           := Src.Left;
		Dst.MaxLength      := Src.MaxLength;
{       Dst.Name           := Src.Name;         }
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentCtl3D    := Src.ParentCtl3D;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ShowHint       := Src.ShowHint;
		Dst.Sorted         := Src.Sorted;
		Dst.Style          := Src.Style;
{       Dst.TabOrder       := Src.TabOrder;     }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Text           := Src.Text;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnChange       := Src.OnChange;
		Dst.OnClick        := Src.OnClick;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnDrawItem     := Src.OnDrawItem;
		Dst.OnDropDown     := Src.OnDropDown;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyPress     := Src.OnKeyPress;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMeasureItem  := Src.OnMeasureItem;
	end;

	{
	***************************************************************************
		TRadioGroupﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyRadioGroupProperty(Dst:TRadioGroup; Src:TRadioGroup);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Align          := Src.Align;
		Dst.Caption        := Src.Caption;
		Dst.Color          := Src.Color;
		Dst.Columns        := Src.Columns;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.Hint           := Src.Hint;
		Dst.ItemIndex      := Src.ItemIndex;
		Dst.Items          := Src.Items;
		Dst.Left           := Src.Left;
{       Dst.Name           := Src.Name;         }
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentCtl3D    := Src.ParentCtl3D;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ShowHint       := Src.ShowHint;
{       Dst.TabOrder       := Src.TabOrder;     }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnClick        := Src.OnClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
	end;

	{
	***************************************************************************
		TPanelﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyPanelProperty(Dst:TPanel; Src:TPanel);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Align          := Src.Align;
		Dst.Alignment      := Src.Alignment;
		Dst.BevelInner     := Src.BevelInner;
		Dst.BevelOuter     := Src.BevelOuter;
		Dst.BevelWidth     := Src.BevelWidth;
		Dst.BorderStyle    := Src.BorderStyle;
		Dst.BorderWidth    := Src.BorderWidth;
		Dst.Caption        := Src.Caption;
		Dst.Color          := Src.Color;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.Hint           := Src.Hint;
		Dst.Left           := Src.Left;
		Dst.Locked         := Src.Locked;
{       Dst.Name           := Src.Name;         }
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentCtl3D    := Src.ParentCtl3D;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ShowHint       := Src.ShowHint;
{       Dst.TabOrder       := Src.TabOrder;     }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnClick        := Src.OnClick;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
		Dst.OnResize       := Src.OnResize;
	end;

	{
	***************************************************************************
		TBitBtnﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyBitBtnProperty(Dst:TBitBtn; Src:TBitBtn);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Cancel         := Src.Cancel;
		Dst.Caption        := Src.Caption;
		Dst.Cursor         := Src.Cursor;
		Dst.Default        := Src.Default;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.Font           := Src.Font;
		Dst.Glyph          := Src.Glyph;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.Hint           := Src.Hint;
		Dst.Kind           := Src.Kind;
		Dst.Layout         := Src.Layout;
		Dst.Left           := Src.Left;
		Dst.Margin         := Src.Margin;
		Dst.ModalResult    := Src.ModalResult;
{       Dst.Name           := Src.Name;             }
		Dst.NumGlyphs      := Src.NumGlyphs;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ShowHint       := Src.ShowHint;
		Dst.Spacing        := Src.Spacing;
		Dst.Style          := Src.Style;
{       Dst.TabOrder       := Src.TabOrder;         }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnClick        := Src.OnClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyPress     := Src.OnKeyPress;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TMaskEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyMaskEditProperty(Dst:TMaskEdit; Src:TMaskEdit);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.AutoSelect     := Src.AutoSelect;
		Dst.AutoSize       := Src.AutoSize;
		Dst.BorderStyle    := Src.BorderStyle;
		Dst.CharCase       := Src.CharCase;
		Dst.Color          := Src.Color;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.EditMask       := Src.EditMask;
		Dst.Enabled        := Src.Enabled;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.Hint           := Src.Hint;
		Dst.ImeMode        := Src.ImeMode;
		Dst.Left           := Src.Left;
		Dst.MaxLength      := Src.MaxLength;
{        Dst.Name           := Src.Name;        }
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentCtl3D    := Src.ParentCtl3D;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PasswordChar   := Src.PasswordChar;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ReadOnly       := Src.ReadOnly;
		Dst.ShowHint       := Src.ShowHint;
{       Dst.TabOrder       := Src.TabOrder;     }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Text           := Src.Text;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnChange       := Src.OnChange;
		Dst.OnClick        := Src.OnClick;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyPress     := Src.OnKeyPress;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TImageﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyImageProperty(Dst:TImage; Src:TImage);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Align          := Src.Align;
		Dst.AutoSize       := Src.AutoSize;
		Dst.Center         := Src.Center;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.Height         := Src.Height;
		Dst.Hint           := Src.Hint;
		Dst.Left           := Src.Left;
{       Dst.Name           := Src.Name;        }
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.Picture        := Src.Picture;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ShowHint       := Src.ShowHint;
		Dst.Stretch        := Src.Stretch;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnClick        := Src.OnClick;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TShapeﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyShapeProperty(Dst:TShape; Src:TShape);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Brush          := Src.Brush;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
		Dst.Height         := Src.Height;
		Dst.Hint           := Src.Hint;
		Dst.Left           := Src.Left;
{       Dst.Name           := Src.Name;        }
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.Pen            := Src.Pen;
		Dst.Shape          := Src.Shape;
		Dst.ShowHint       := Src.ShowHint;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TBevelﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyBevelProperty(Dst:TBevel; Src:TBevel);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Align          := Src.Align;
		Dst.Cursor         := Src.Cursor;
		Dst.Height         := Src.Height;
		Dst.Hint           := Src.Hint;
		Dst.Left           := Src.Left;
{       Dst.Name           := Src.Name;        }
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.Shape          := Src.Shape;
		Dst.ShowHint       := Src.ShowHint;
		Dst.Style          := Src.Style;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
{       なし                                    }
	end;

	{
	***************************************************************************
		THEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyXEditProperty(Dst:THEdit; Src:THEdit);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.ActBgColor     := Src.ActBgColor;
		Dst.ActFgColor     := Src.ActFgColor;
		Dst.AutoSelect     := Src.AutoSelect;
		Dst.AutoSize       := Src.AutoSize;
		Dst.BorderStyle    := Src.BorderStyle;
//		Dst.CheckDD        := Src.CheckDD;
		Dst.CharCase       := Src.CharCase;
		Dst.Color          := Src.Color;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
//		Dst.ExtCase        := Src.ExtCase;
		Dst.ExtEdit        := Src.ExtEdit;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.HideSelection  := Src.HideSelection;
		Dst.Hint           := Src.Hint;
		Dst.ImeMode        := Src.ImeMode;
		Dst.Left           := Src.Left;
{        Dst.Name           := Src.Name;        }
		Dst.OEMConvert     := Src.OEMConvert;
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentCtl3D    := Src.ParentCtl3D;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PasswordChar   := Src.PasswordChar;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ReadOnly       := Src.ReadOnly;
		Dst.ShowHint       := Src.ShowHint;
{       Dst.TabOrder       := Src.TabOrder;     }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Text           := Src.Text;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnChange       := Src.OnChange;
		Dst.OnClick        := Src.OnClick;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyPress     := Src.OnKeyPress;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		THNeditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyXNeditProperty(Dst:THNedit; Src:THNedit);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.ActBgColor     := Src.ActBgColor;
		Dst.ActFgColor     := Src.ActFgColor;
		Dst.AutoSelect     := Src.AutoSelect;
		Dst.AutoSize       := Src.AutoSize;
		Dst.BorderStyle    := Src.BorderStyle;
		Dst.CharCase       := Src.CharCase;
//		Dst.CheckDD        := Src.CheckDD;
		Dst.Color          := Src.Color;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DragCursor     := Src.DragCursor;
		Dst.DragMode       := Src.DragMode;
		Dst.Enabled        := Src.Enabled;
//		Dst.ExtCase        := Src.ExtCase;
		Dst.ExtEdit        := Src.ExtEdit;
		Dst.Font           := Src.Font;
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.HideSelection  := Src.HideSelection;
		Dst.Hint           := Src.Hint;
		Dst.ImeMode        := Src.ImeMode;
		Dst.Left           := Src.Left;
{        Dst.Name           := Src.Name;        }
		Dst.NumEdit        := Src.NumEdit;
		Dst.OEMConvert     := Src.OEMConvert;
		Dst.ParentColor    := Src.ParentColor;
		Dst.ParentCtl3D    := Src.ParentCtl3D;
		Dst.ParentFont     := Src.ParentFont;
		Dst.ParentShowHint := Src.ParentShowHint;
		Dst.PasswordChar   := Src.PasswordChar;
		Dst.PopupMenu      := Src.PopupMenu;
		Dst.ReadOnly       := Src.ReadOnly;
		Dst.ShowHint       := Src.ShowHint;
{       Dst.TabOrder       := Src.TabOrder;     }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Text           := Src.Text;
		Dst.Top            := Src.Top;
		Dst.Visible        := Src.Visible;
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnChange       := Src.OnChange;
		Dst.OnClick        := Src.OnClick;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnDragDrop     := Src.OnDragDrop;
		Dst.OnDragOver     := Src.OnDragOver;
		Dst.OnEndDrag      := Src.OnEndDrag;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyPress     := Src.OnKeyPress;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseMove    := Src.OnMouseMove;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		THDateEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyXDateEditProperty(Dst:THDateEdit; Src:THDateEdit);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.BorderStyle    := Src.BorderStyle;
		Dst.Color          := Src.Color;
		Dst.Ctl3D          := Src.Ctl3D;
		Dst.Cursor         := Src.Cursor;
		Dst.DateFormat     := Src.DateFormat;
		Dst.DateSequence   := Src.DateSequence;
		Dst.Enabled        := Src.Enabled;
		Dst.EnabledEditors := Src.EnabledEditors;
		//Dst.ExtCase        := Src.ExtCase;
		Dst.Font           := Src.Font;
(* ADD FIT T.S 1997-02-28 *)
                Dst.GengouSection  := Src.GengouSection;
(* ADD END *)
		Dst.Height         := Src.Height;
		Dst.HelpContext    := Src.HelpContext;
		Dst.Hint           := Src.Hint;
(* ADD FIT T.S 1997-02-28 *)
                Dst.ImeMode        := Src.ImeMode;
(* ADD END *)
(* 19990729 DEL Kubochi Begin *)
//		Dst.IniFileName    := Src.IniFileName;
(* Del End *)
		Dst.InitFocus      := Src.InitFocus;
		Dst.JpnYearCol     := Src.JpnYearCol;
		Dst.LabelD         := Src.LabelD;
		Dst.LabelM         := Src.LabelM;
		Dst.LabelY         := Src.LabelY;
		Dst.Left           := Src.Left;
{       Dst.Name           := Src.Name;       }
(* ADD FIT T.S 1997-02-28 *)
                Dst.NecessaryEditors := Src.NecessaryEditors;
(* ADD END *)
		Dst.Options        := Src.Options;
		Dst.ReadOnly       := Src.ReadOnly;
{       Dst.TabOrder       := Src.TabOrder;   }
		Dst.TabStop        := Src.TabStop;
		Dst.Tag            := Src.Tag;
		Dst.Top            := Src.Top;
(* ADD matsu 1997-03-21 *)
                Dst.YearName       := Src.YearName;
(* ADD END *)
		Dst.Width          := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnChange       := Src.OnChange;
		Dst.OnDblClick     := Src.OnDblClick;
		Dst.OnEnter        := Src.OnEnter;
		Dst.OnExit         := Src.OnExit;
		Dst.OnKeyDown      := Src.OnKeyDown;
		Dst.OnKeyUp        := Src.OnKeyUp;
		Dst.OnMouseDown    := Src.OnMouseDown;
		Dst.OnMouseUp      := Src.OnMouseUp;
	end;

	{
	***************************************************************************
		TXTimeEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyXTimeEditProperty(Dst:TXTimeEdit; Src:TXTimeEdit);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.BorderStyle    := Src.BorderStyle;
//		Dst.Color          := Src.Color;
//		Dst.Ctl3D          := Src.Ctl3D;
//		Dst.Cursor         := Src.Cursor;
//		Dst.Enabled        := Src.Enabled;
//		Dst.EnabledEditors := Src.EnabledEditors;
//		Dst.ExtCase        := Src.ExtCase;
//		Dst.Font           := Src.Font;
//		Dst.Height         := Src.Height;
//		Dst.HelpContext    := Src.HelpContext;
//		Dst.Hint           := Src.Hint;
//		Dst.InitFocus      := Src.InitFocus;
//		Dst.LabelH         := Src.LabelH;
//		Dst.LabelM         := Src.LabelM;
//		Dst.LabelS         := Src.LabelS;
//		Dst.Left           := Src.Left;
//{       Dst.Name           := Src.Name;       }
//		Dst.Options        := Src.Options;
//		Dst.ReadOnly       := Src.ReadOnly;
//{       Dst.TabOrder       := Src.TabOrder;   }
//		Dst.TabStop        := Src.TabStop;
//		Dst.Tag            := Src.Tag;
//		Dst.Top            := Src.Top;
//		Dst.Width          := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnChange       := Src.OnChange;
//		Dst.OnDblClick     := Src.OnDblClick;
//		Dst.OnEnter        := Src.OnEnter;
//		Dst.OnExit         := Src.OnExit;
//		Dst.OnKeyDown      := Src.OnKeyDown;
//		Dst.OnKeyUp        := Src.OnKeyUp;
//		Dst.OnMouseDown    := Src.OnMouseDown;
//		Dst.OnMouseUp      := Src.OnMouseUp;
//	end;
//
	{
	***************************************************************************
		TXValueEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyXValueEditProperty(Dst:TXValueEdit; Src:TXValueEdit);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.BorderStyle  := Src.BorderStyle;
//		Dst.ButtonDirect := Src.ButtonDirect;
//		Dst.ButtonWidth  := Src.ButtonWidth;
//		Dst.Color        := Src.Color;
//		Dst.Column       := Src.Column;
//		Dst.Ctl3D        := Src.Ctl3D;
//		Dst.Cursor       := Src.Cursor;
//		Dst.DecKey       := Src.DecKey;
//		Dst.Difference   := Src.Difference;
//		Dst.Enabled      := Src.Enabled;
//		Dst.ExtCase      := Src.ExtCase;
//		Dst.Font         := Src.Font;
//		Dst.Height       := Src.Height;
//		Dst.HelpContext  := Src.HelpContext;
//		Dst.Hint         := Src.Hint;
//		Dst.IncKey       := Src.IncKey;
//		Dst.LabelColor   := Src.LabelColor;
//		Dst.Left         := Src.Left;
//		Dst.MaxValue     := Src.MaxValue;
//		Dst.MinValue     := Src.MinValue;
//{       Dst.Name         := Src.Name;        }
//		Dst.Options      := Src.Options;
//		Dst.Pitch        := Src.Pitch;
//		Dst.ReadOnly     := Src.ReadOnly;
//{       Dst.TabOrder     := Src.TabOrder;     }
//		Dst.TabStop      := Src.TabStop;
//		Dst.Tag          := Src.Tag;
//		Dst.Top          := Src.Top;
//		Dst.UnitName     := Src.UnitName;
//		Dst.Visible      := Src.Visible;
//		Dst.Width        := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnChange     := Src.OnChange;
//		Dst.OnDblClick   := Src.OnDblClick;
//		Dst.OnEnter      := Src.OnEnter;
//		Dst.OnExit       := Src.OnExit;
//		Dst.OnKeyDown    := Src.OnKeyDown;
//		Dst.OnKeyUp      := Src.OnKeyUp;
//		Dst.OnMouseDown  := Src.OnMouseDown;
//		Dst.OnMouseUp    := Src.OnMouseUp;
//	end;
//
//{$IFDEF ADDCOMRADE}
	{
	***************************************************************************
		TVEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVEditProperty(Dst:TVEdit; Src:TVEdit);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.AlignmentH   := Src.AlignmentH ;
//		Dst.AlignmentV   := Src.AlignmentV ;
//		Dst.BorderStyle  := Src.BorderStyle;
////okada		Dst.BorderDraw   := Src.BorderDraw;
//		Dst.Color        := Src.Color;
//		{Dst.Ctl3D        := Src.Ctl3D;}
//		Dst.CaretPos     := Src.CaretPos ;
//                Dst.CheckDD      := Src.CheckDD;       //okada
//		Dst.Cursor       := Src.Cursor;
//		Dst.DragCursor   := Src.DragCursor;    //okada
//                Dst.DragMode     := Src.DragMode;      //okada
//		Dst.Enabled      := Src.Enabled;
//		Dst.ExtCase      := Src.ExtCase;       //okada
//                Dst.ExtEdit      := Src.ExtEdit;       //okada
//		Dst.Font         := Src.Font;
//		Dst.Height       := Src.Height;
//		Dst.HelpContext  := Src.HelpContext;
//		Dst.Hint         := Src.Hint;
//		Dst.InsMode      := Src.InsMode ;
//		Dst.ImeMode      := Src.ImeMode ;
//		Dst.KeyRepMode   := Src.KeyRepMode ;
//		Dst.Left         := Src.Left;
//		Dst.MaxLength    := Src.MaxLength ;
//                Dst.Name         := Src.Name;
//		Dst.ParentFont   := Src.ParentFont ;
//		Dst.ReadOnly     := Src.ReadOnly;
//                Dst.ShowHint     := Src.ShowHint;      //okada
//                Dst.TabOrder     := Src.TabOrder;
//		Dst.TabStop      := Src.TabStop;
//		Dst.Tag          := Src.Tag;
//                Dst.Text         := Src.Text;           //okada
//		Dst.Top          := Src.Top;
//		Dst.Visible      := Src.Visible;
//		Dst.Width        := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnChange     := Src.OnChange;
//		Dst.OnClick      := Src.OnClick;
//                Dst.OnDblClick   := Src.OnDblClick;    //okada
//                Dst.OnDragDrop   := Src.OnDragDrop;    //okada
//                Dst.OnDragOver   := Src.OnDragOver;
//                Dst.OnEndDrag    := Src.OnEndDrag;
//		Dst.OnEnter      := Src.OnEnter;
//		Dst.OnExit       := Src.OnExit;
////okada		Dst.OnExitRight  := Src.OnExitRight ;
//		Dst.OnKeyDown    := Src.OnKeyDown;
//		Dst.OnKeyUp      := Src.OnKeyUp;
//		Dst.OnKeyPress   := Src.OnKeyPress ;
//		Dst.OnMouseDown  := Src.OnMouseDown;
//		Dst.OnMouseUp    := Src.OnMouseUp;
//	end;

	{
	***************************************************************************
		TVFormatEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVFormatEditProperty(Dst:TVFormatEdit; Src:TVFormatEdit);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.AlignmentH   := Src.AlignmentH ;
//		Dst.AlignmentV   := Src.AlignmentV ;
//		Dst.BorderStyle  := Src.BorderStyle;
////okada		Dst.BorderDraw   := Src.BorderDraw;
//		Dst.Color        := Src.Color;
//		Dst.CaretPos     := Src.CaretPos ;
//		Dst.CaretPosB    := Src.CaretPosB ;
//                Dst.CheckDD      := Src.CheckDD;       //okada
//		Dst.Cursor       := Src.Cursor;
//		Dst.DragCursor   := Src.DragCursor;    //okada
//                Dst.DragMode     := Src.DragMode;      //okada
//		Dst.Enabled      := Src.Enabled;
//		Dst.ExtCase      := Src.ExtCase;       //okada
//                Dst.ExtEdit      := Src.ExtEdit;       //okada
//		Dst.ExtEdit      := Src.ExtEdit;
//		Dst.Font         := Src.Font;
//		Dst.FocusBorder      := Src.FocusBorder ;
//		Dst.FocusBorderColor := Src.FocusBorderColor ;
//		Dst.FormatString     := Src.FormatString ;
//		Dst.Height       := Src.Height;
//		Dst.HelpContext  := Src.HelpContext;
//		Dst.Hint         := Src.Hint;
//		Dst.InsMode      := Src.InsMode ;
//		Dst.ImeMode      := Src.ImeMode ;
//		Dst.KeyRepMode   := Src.KeyRepMode ;
//		Dst.Left         := Src.Left;
//                Dst.MaxLength    := Src.MaxLength ;
//                Dst.Name         := Src.Name;            //okada
//		Dst.ParentFont   := Src.ParentFont ;
//		Dst.ReadOnly     := Src.ReadOnly;
//                Dst.ShowHint     := Src.ShowHint;      //okada
//                Dst.TabOrder     := Src.TabOrder;         //okada
//		Dst.TabStop      := Src.TabStop;
//		Dst.Tag          := Src.Tag;
//                Dst.Text         := Src.Text;           //okada
//		Dst.Top          := Src.Top;
//		Dst.Visible      := Src.Visible;
//		Dst.Width        := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		{Dst.OnChange     := Src.OnChange;}
//		Dst.OnChangeString  := Src.OnChangeString ;
//		Dst.OnClick      := Src.OnClick;
//                Dst.OnDblClick   := Src.OnDblClick;    //okada
//                Dst.OnDragDrop   := Src.OnDragDrop;    //okada
//                Dst.OnDragOver   := Src.OnDragOver;
//                Dst.OnEndDrag    := Src.OnEndDrag;
//		Dst.OnEnter      := Src.OnEnter;
//		Dst.OnErrOrText     := Src.OnErrOrText ;
//		Dst.OnExit       := Src.OnExit;
////okada		Dst.OnExitRight  := Src.OnExitRight ;
//		Dst.OnKeyDown    := Src.OnKeyDown;
//		Dst.OnKeyUp      := Src.OnKeyUp;
//		Dst.OnKeyPress   := Src.OnKeyPress ;
//		Dst.OnMouseDown  := Src.OnMouseDown;
//		Dst.OnMouseUp    := Src.OnMouseUp;
//	end;

	{
	***************************************************************************
		TVDateEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVDateEditProperty(Dst:TVDateEdit; Src:TVDateEdit);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.BorderStyle  := Src.BorderStyle;
////okada		Dst.BorderDraw   := Src.BorderDraw;
//		Dst.Color        := Src.Color;
//		{Dst.Ctl3D        := Src.Ctl3D;}
//		Dst.Cursor       := Src.Cursor;
//		Dst.DateFormat   := Src.DateFormat ;
//		Dst.DateSequence := Src.DateSequence ;
//		Dst.EditYear     := Src.EditYear ;
//		Dst.EditMonth    := Src.EditMonth ;
//		Dst.EditDay      := Src.EditDay ;
//		Dst.Enabled      := Src.Enabled;
//		Dst.EnabledEditors   := Src.EnabledEditors ;
//                Dst.ExtCase      := Src.ExtCase;
//		Dst.Font         := Src.Font;
//		Dst.FocusBorder      := Src.FocusBorder ;
//		Dst.FocusBorderColor := Src.FocusBorderColor ;
//		Dst.FrontColor   := Src.FrontColor ;
//		Dst.Height       := Src.Height;
//		Dst.HelpContext  := Src.HelpContext;
//		Dst.Hint         := Src.Hint;
//		Dst.Left         := Src.Left;
//		Dst.LabelColor   := Src.LabelColor ;
//		Dst.LabelY       := Src.LabelY ;
//		Dst.LabelM       := Src.LabelM ;
//		Dst.LabelD       := Src.LabelD ;
//                Dst.LongDate     := Src.LongDate;
//		Dst.MaxDay       := Src.MaxDay ;
//		Dst.MinDay       := Src.MinDay ;
//                Dst.Name         := Src.Name;       //okada
//		Dst.Options      := Src.Options ;
//		Dst.ParentFont   := Src.ParentFont ;
//                Dst.ShowHint     := Src.ShowHint;   //okada
//		Dst.ReadOnly     := Src.ReadOnly;   //okada
//                Dst.TabOrder     := Src.TabOrder;   //okada
//		Dst.TabStop      := Src.TabStop;
//		Dst.Tag          := Src.Tag;
//		Dst.Top          := Src.Top;
//                Dst.ViewText     := Src.ViewText;   //okada
//		Dst.Visible      := Src.Visible;
//		Dst.Width        := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnChange     := Src.OnChange;   // okaa
//		Dst.OnEnter      := Src.OnEnter;
//		Dst.OnExit       := Src.OnExit;
//	end;

	{
	***************************************************************************
		TVTimeEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVTimeEditProperty(Dst:TVTimeEdit; Src:TVTimeEdit);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.BorderStyle  := Src.BorderStyle;
////okada		Dst.BorderDraw   := Src.BorderDraw;
//		Dst.Color        := Src.Color;
//		{Dst.Ctl3D        := Src.Ctl3D;}
//		Dst.Cursor       := Src.Cursor;
//		Dst.EditHour     := Src.EditHour ;
//		Dst.EditMinute   := Src.EditMinute ;
//		Dst.EditSecond   := Src.EditSecond ;
//		Dst.Enabled      := Src.Enabled;
//		Dst.EnabledEditors   := Src.EnabledEditors ;
//                Dst.ExtCase      := Src.ExtCase;    //okada
//		Dst.Font         := Src.Font;
//		Dst.FocusBorder      := Src.FocusBorder ;
//		Dst.FocusBorderColor := Src.FocusBorderColor ;
//		Dst.Height       := Src.Height;
//		Dst.HelpContext  := Src.HelpContext;
//		Dst.Hint         := Src.Hint;
//		Dst.Left         := Src.Left;
//		Dst.FrontColor   := Src.FrontColor ;
//		Dst.LabelColor   := Src.LabelColor ;
//		Dst.LabelH       := Src.LabelH ;
//		Dst.LabelM       := Src.LabelM ;
//		Dst.LabelS       := Src.LabelS ;
//                Dst.LongTime     := Src.LongTime;   //okada
//		Dst.MaxTime      := Src.MaxTime ;
//		Dst.MinTime      := Src.MinTime ;
//		Dst.ModeAMPM     := Src.ModeAMPM ;
//                Dst.Name         := Src.Name;       //okada
//		Dst.Options      := Src.Options ;
//		Dst.ParentFont   := Src.ParentFont ;
//		Dst.ReadOnly     := Src.ReadOnly;   //okada
//                Dst.TabOrder     := Src.TabOrder;   //okada
//		Dst.TabStop      := Src.TabStop;
//		Dst.TimeFormat   := Src.TimeFormat ;
//		Dst.Tag          := Src.Tag;
//		Dst.Top          := Src.Top;
//                Dst.ViewText     := Src.ViewText;  //okada
//		Dst.Visible      := Src.Visible;
//		Dst.Width        := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnChange     := Src.OnChange;   // okaa
//		Dst.OnEnter      := Src.OnEnter;
//		Dst.OnExit       := Src.OnExit;
//	end;

	{
	***************************************************************************
		TVCalcEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVCalcEditProperty(Dst:TVCalcEdit; Src:TVCalcEdit);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.BorderStyle  := Src.BorderStyle;
//		Dst.BorderDraw   := Src.BorderDraw;
//		{Dst.ButtonDirect := Src.ButtonDirect;}
//		{Dst.ButtonWidth  := Src.ButtonWidth;}
//		Dst.Color        := Src.Color;
//		Dst.Column       := Src.Column;
//		{Dst.Ctl3D        := Src.Ctl3D;}
//		Dst.Cursor       := Src.Cursor;
//		Dst.Enabled      := Src.Enabled;
//		Dst.ExtCase      := Src.ExtCase;
//		Dst.FocusBorder      := Src.FocusBorder ;
//		Dst.FocusBorderColor := Src.FocusBorderColor ;
//		Dst.Font         := Src.Font;
//		Dst.Height       := Src.Height;
//		Dst.HelpContext  := Src.HelpContext;
//		Dst.Hint         := Src.Hint;
//		Dst.Left         := Src.Left;
//		Dst.MaxValue     := Src.MaxValue;
//		Dst.MinValue     := Src.MinValue;
//{       Dst.Name         := Src.Name;        }
//		{Dst.Options      := Src.Options;}
//		{Dst.Pitch        := Src.Pitch;}
//		Dst.ReadOnly     := Src.ReadOnly;
//{       Dst.TabOrder     := Src.TabOrder;     }
//		Dst.TabStop      := Src.TabStop;
//		Dst.Tag          := Src.Tag;
//		Dst.Top          := Src.Top;
//		Dst.Visible      := Src.Visible;
//		Dst.Width        := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnChange     := Src.OnChange;
//		{Dst.OnDblClick   := Src.OnDblClick;} // Comrade. okada 97/02/13
//		Dst.OnEnter      := Src.OnEnter;
//		Dst.OnExit       := Src.OnExit;
//		Dst.OnKeyDown    := Src.OnKeyDown;
//		Dst.OnKeyUp      := Src.OnKeyUp;
//		Dst.OnMouseDown  := Src.OnMouseDown;
//		Dst.OnMouseUp    := Src.OnMouseUp;
//	end;

	{
	***************************************************************************
		TVValueEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVValueEditProperty(Dst:TVValueEdit; Src:TVValueEdit);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.BorderStyle  := Src.BorderStyle;
//// okada	Dst.BorderDraw   := Src.BorderDraw;
//		Dst.ButtonDirect := Src.ButtonDirect;
//		Dst.ButtonWidth  := Src.ButtonWidth;
//		Dst.Color        := Src.Color;
//		Dst.Column       := Src.Column;
//		{Dst.Ctl3D        := Src.Ctl3D;}
//		Dst.Cursor       := Src.Cursor;
//		Dst.DecKey       := Src.DecKey;
//		Dst.Difference   := Src.Difference;
//		Dst.Enabled      := Src.Enabled;
//		Dst.ExtCase      := Src.ExtCase;
//		Dst.FocusBorder      := Src.FocusBorder ;
//		Dst.FocusBorderColor := Src.FocusBorderColor ;
//		Dst.Font         := Src.Font;
//		Dst.Height       := Src.Height;
//		Dst.HelpContext  := Src.HelpContext;
//		Dst.Hint         := Src.Hint;
//		Dst.IncKey       := Src.IncKey;
//		Dst.LabelColor   := Src.LabelColor;
//		Dst.Left         := Src.Left;
//		Dst.MaxValue     := Src.MaxValue;
//		Dst.MinValue     := Src.MinValue;
//{       Dst.Name         := Src.Name;        }
//		{Dst.Options      := Src.Options;}
//		{Dst.Pitch        := Src.Pitch;}
//		Dst.ReadOnly     := Src.ReadOnly;
//{       Dst.TabOrder     := Src.TabOrder;     }
//		Dst.TabStop      := Src.TabStop;
//		Dst.Tag          := Src.Tag;
//		Dst.Top          := Src.Top;
//		Dst.UnitName     := Src.UnitName;
//		Dst.Visible      := Src.Visible;
//		Dst.Width        := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnChange     := Src.OnChange;
//		Dst.OnDblClick   := Src.OnDblClick;
//		Dst.OnEnter      := Src.OnEnter;
//		Dst.OnExit       := Src.OnExit;
//		Dst.OnKeyDown    := Src.OnKeyDown;
//		Dst.OnKeyUp      := Src.OnKeyUp;
//		Dst.OnMouseDown  := Src.OnMouseDown;
//		Dst.OnMouseUp    := Src.OnMouseUp;
//	end;

// Comrade okada 97/03/27 --------------------------->
	{
	***************************************************************************
		TVNEditﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVNEditProperty(Dst:TVNEdit; Src:TVNEdit);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.BorderStyle  := Src.BorderStyle;
//		Dst.Color        := Src.Color;
//		Dst.Column       := Src.Column;
//		Dst.Cursor       := Src.Cursor;
//		Dst.Enabled      := Src.Enabled;
//		Dst.ExtCase      := Src.ExtCase;
//		Dst.FocusBorder      := Src.FocusBorder ;
//		Dst.FocusBorderColor := Src.FocusBorderColor ;
//		Dst.Font         := Src.Font;
//		Dst.Height       := Src.Height;
//		Dst.HelpContext  := Src.HelpContext;
//		Dst.Hint         := Src.Hint;
//// ImeMode
//		Dst.Left         := Src.Left;
//		Dst.MaxValue     := Src.MaxValue;
//		Dst.MinValue     := Src.MinValue;
//// Name
//// ParentFont
//		Dst.ReadOnly     := Src.ReadOnly;
//// ShowHint
//// TabOrder
//		Dst.TabStop      := Src.TabStop;
//		Dst.Tag          := Src.Tag;
//		Dst.Top          := Src.Top;
//		Dst.Visible      := Src.Visible;
//		Dst.Width        := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnChange     := Src.OnChange;
//		Dst.OnDblClick   := Src.OnDblClick;
//		Dst.OnEnter      := Src.OnEnter;
//		Dst.OnExit       := Src.OnExit;
//		Dst.OnKeyDown    := Src.OnKeyDown;
//		Dst.OnKeyUp      := Src.OnKeyUp;
//		Dst.OnMouseDown  := Src.OnMouseDown;
//		Dst.OnMouseUp    := Src.OnMouseUp;
//	end;
// Comrade okada 97/03/27 <---------------------------

	{
	***************************************************************************
		TVButtonﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVButtonProperty(Dst:TVButton; Src:TVButton);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.Caption1    := Src.Caption1;
//		Dst.Caption2    := Src.Caption2;
//		Dst.Cursor      := Src.Cursor;
//		Dst.Enabled     := Src.Enabled;
//		Dst.Font1       := Src.Font1;
//		Dst.Font2       := Src.Font2;
//		Dst.Height      := Src.Height;
//		Dst.HelpContext := Src.HelpContext;
//		Dst.Hint        := Src.Hint;
//		Dst.Left        := Src.Left;
//{       Dst.Name        := Src.Name;        }
//		Dst.Pitch       := Src.Pitch;
//{       Dst.TabOrder    := Src.TabOrder;    }
//		Dst.TabStop     := Src.TabStop;
//		Dst.Tag         := Src.Tag;
//		Dst.Top         := Src.Top;
//		Dst.Visible     := Src.Visible;
//		Dst.Width       := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnClick     := Src.OnClick;
//		{Dst.OnDblClick  := Src.OnDblClick;} // Comrade. Okada 97/02/13
//		Dst.OnEnter     := Src.OnEnter;
//		Dst.OnExit      := Src.OnExit;
//		Dst.OnMouseDown := Src.OnMouseDown;
//		Dst.OnMouseMove := Src.OnMouseMove;
//		Dst.OnMouseUp   := Src.OnMouseUp;
//	end;

	{
	***************************************************************************
		TVLabelﾌﾟﾛﾊﾟﾃｨのｺﾋ**ﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVLabelProperty(Dst:TVLabel; Src:TVLabel);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.AlignmentH     := Src.AlignmentH;
//		Dst.AlignmentV     := Src.AlignmentV;
//		Dst.Caption        := Src.Caption;
//		Dst.Color          := Src.Color;
//		Dst.DragCursor     := Src.DragCursor;
//		Dst.DragMode       := Src.DragMode;
//		Dst.DrawStyle      := Src.DrawStyle;
//		Dst.Enabled        := Src.Enabled;
//		Dst.FocusControl   := Src.FocusControl;
//		Dst.Font           := Src.Font;
//		Dst.Height         := Src.Height;
//		Dst.Hint           := Src.Hint;
//		Dst.Left           := Src.Left;
//{       Dst.Name           := Src.Name; }
//		Dst.ParentColor    := Src.ParentColor;
//		Dst.ParentFont     := Src.ParentFont;
//		Dst.ParentColor    := Src.ParentColor;
//		Dst.ParentShowHint := Src.ParentShowHint;
//		Dst.PopupMenu      := Src.PopupMenu;
//		Dst.ShowAccelChar  := Src.ShowAccelChar;
//		Dst.ShowHint       := Src.ShowHint;
//		Dst.Tag            := Src.Tag;
//		Dst.Text3D         := Src.Text3D;
//		Dst.Top            := Src.Top;
//		Dst.Transparent    := Src.Transparent;
//		Dst.Visible        := Src.Visible;
//		Dst.Width          := Src.Width;
//		{Dst.WordWrap       := Src.WordWrap;}
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnClick        := Src.OnClick;
//		Dst.OnDblClick     := Src.OnDblClick;
//		Dst.OnDragDrop     := Src.OnDragDrop;
//		Dst.OnDragOver     := Src.OnDragOver;
//		Dst.OnEndDrag      := Src.OnEndDrag;
//		Dst.OnMouseDown    := Src.OnMouseDown;
//		Dst.OnMouseMove    := Src.OnMouseMove;
//		Dst.OnMouseUp      := Src.OnMouseUp;
//	end;

	{
	***************************************************************************
		TVFormatLabelﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyVFormatLabelProperty(Dst:TVFormatLabel; Src:TVFormatLabel);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.AlignmentH     := Src.AlignmentH;
//		Dst.AlignmentV     := Src.AlignmentV;
//		Dst.Caption        := Src.Caption;
//		Dst.Color          := Src.Color;
//		Dst.DragCursor     := Src.DragCursor;
//		Dst.DragMode       := Src.DragMode;
//		Dst.DrawStyle      := Src.DrawStyle;
//		Dst.Enabled        := Src.Enabled;
//		Dst.FocusControl   := Src.FocusControl;
//		Dst.Font           := Src.Font;
//		Dst.FormatString     := Src.FormatString;  // add Okada
//		Dst.Height         := Src.Height;
//		Dst.Hint           := Src.Hint;
//		Dst.Left           := Src.Left;
//{       Dst.Name           := Src.Name; }
//		Dst.ParentColor    := Src.ParentColor;
//		Dst.ParentFont     := Src.ParentFont;
//		Dst.ParentColor    := Src.ParentColor;
//		Dst.ParentShowHint := Src.ParentShowHint;
//		Dst.PopupMenu      := Src.PopupMenu;
//		Dst.ShowAccelChar  := Src.ShowAccelChar;
//		Dst.ShowHint       := Src.ShowHint;
//		Dst.Tag            := Src.Tag;
//		Dst.Text3D         := Src.Text3D;
//		Dst.Top            := Src.Top;
//		Dst.Transparent    := Src.Transparent;
//		Dst.Visible        := Src.Visible;
//		Dst.Width          := Src.Width;
//		{Dst.WordWrap       := Src.WordWrap;}
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnClick        := Src.OnClick;
//		Dst.OnChangeFormat := Src.OnChangeFormat;
//		Dst.OnChangeString := Src.OnChangeString;
//		Dst.OnDblClick     := Src.OnDblClick;
//		Dst.OnDragDrop     := Src.OnDragDrop;
//		Dst.OnDragOver     := Src.OnDragOver;
//		Dst.OnEndDrag      := Src.OnEndDrag;
//		Dst.OnMouseDown    := Src.OnMouseDown;
//		Dst.OnMouseMove    := Src.OnMouseMove;
//		Dst.OnMouseUp      := Src.OnMouseUp;
//	end;
//
//{$ENDIF}
	{
	***************************************************************************
		TXRectangleﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
//	procedure   CopyXRectangleProperty(Dst:TXRectangle; Src:TXRectangle);
//	begin
//		{ ﾌﾟﾛﾊﾟﾃｨ }
//		Dst.Align          := Src.Align;
//		Dst.BGColor        := Src.BGColor;
//		Dst.BlackFrameType := Src.BlackFrameType;
//		Dst.Cursor         := Src.Cursor;
//		Dst.FGColor        := Src.FGColor;
//		Dst.FillStyle      := Src.FillStyle;
//		Dst.FrameColor     := Src.FrameColor;
//		Dst.FrameThick     := Src.FrameThick;
//		Dst.FrameType      := Src.FrameType;
//		Dst.Height         := Src.Height;
//		Dst.HighlightColor := Src.HighlightColor;
//		Dst.Hint           := Src.Hint;
//		Dst.Left           := Src.Left;
//{        Dst.Name           := Src.Name;    }
//		Dst.Options        := Src.Options;
//		Dst.Round          := Src.Round;
//		Dst.ShadowColor    := Src.ShadowColor;
//		Dst.Tag            := Src.Tag;
//		Dst.Top            := Src.Top;
//		Dst.Width          := Src.Width;
//
//		{ ｲﾍﾞﾝﾄ }
//		Dst.OnDragDrop     := Src.OnDragDrop;
//		Dst.OnDragOver     := Src.OnDragOver;
//		Dst.OnEndDrag      := Src.OnEndDrag;
//		Dst.OnMouseDown    := Src.OnMouseDown;
//		Dst.OnMouseMove    := Src.OnMouseMove;
//		Dst.OnMouseUp      := Src.OnMouseUp;
//		Dst.OnStartDrag    := Src.OnStartDrag;
//	end;

	{
	***************************************************************************
		THLineﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyXLineProperty(Dst:THLine; Src:THLine);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.BgColor   := Src.BgColor;
		Dst.Cursor    := Src.Cursor;
		Dst.FgColor   := Src.FgColor;
		Dst.Height    := Src.Height;
		Dst.Hint      := Src.Hint;
		Dst.Left      := Src.Left;
		Dst.LineStyle := Src.LineStyle;
		Dst.LineType  := Src.LineType;
{        Dst.Name      := Src.Name; }
		Dst.Opaque    := Src.Opaque;
		Dst.Pattern   := Src.Pattern;
		Dst.Tag       := Src.Tag;
		Dst.Thick     := Src.Thick;
		Dst.Top       := Src.Top;
		Dst.Width     := Src.Width;

		{ ｲﾍﾞﾝﾄ }
	end;

	{
	***************************************************************************
		THDoubleCaptionButtonﾌﾟﾛﾊﾟﾃｨのｺﾋﾟｰ

			入力    Dst, Src    :   ｺﾋﾟｰ先、ｺﾋﾟｰ元
			出力    なし
	***************************************************************************
	}
	procedure   CopyXDoubleCaptionButtonProperty(Dst:THDoubleCaptionButton; Src:THDoubleCaptionButton);
	begin
		{ ﾌﾟﾛﾊﾟﾃｨ }
		Dst.Caption1    := Src.Caption1;
		Dst.Caption2    := Src.Caption2;
		Dst.Cursor      := Src.Cursor;
		Dst.Enabled     := Src.Enabled;
		Dst.Font1       := Src.Font1;
		Dst.Font2       := Src.Font2;
		Dst.Height      := Src.Height;
		Dst.HelpContext := Src.HelpContext;
		Dst.Hint        := Src.Hint;
		Dst.Left        := Src.Left;
{       Dst.Name        := Src.Name;        }
		Dst.Pitch       := Src.Pitch;
{       Dst.TabOrder    := Src.TabOrder;    }
		Dst.TabStop     := Src.TabStop;
		Dst.Tag         := Src.Tag;
		Dst.Top         := Src.Top;
		Dst.Visible     := Src.Visible;
		Dst.Width       := Src.Width;

		{ ｲﾍﾞﾝﾄ }
		Dst.OnClick     := Src.OnClick;
		Dst.OnDblClick  := Src.OnDblClick;
		Dst.OnEnter     := Src.OnEnter;
		Dst.OnExit      := Src.OnExit;
		Dst.OnMouseDown := Src.OnMouseDown;
		Dst.OnMouseMove := Src.OnMouseMove;
		Dst.OnMouseUp   := Src.OnMouseUp;
	end;
	{
	***************************************************************************
		ﾘｰﾄﾞｵﾝﾘ属性の取得

			入力    Control :   検査対象のTWinControl
			出力    return  :   TRUE/FALSE
	***************************************************************************
	}
	function IsReadOnly(Control: TWinControl): Boolean;
	begin
	  if      Control is TMemo       then Result := TMemo(Control).ReadOnly
	  else if Control is TEdit       then Result := TEdit(Control).ReadOnly
	  else if Control is TMaskEdit   then Result := TMaskEdit(Control).ReadOnly
	  else if Control is THEdit      then Result := THEdit(Control).ReadOnly
	  else if Control is THNedit     then Result := THNedit(Control).ReadOnly
	  else if Control is THDateEdit  then Result := THDateEdit(Control).ReadOnly
//	  else if Control is TXTimeEdit  then Result := TXTimeEdit(Control).ReadOnly
//	  else if Control is TXValueEdit then Result := TXValueEdit(Control).ReadOnly
//{$IFDEF ADDCOMRADE}
//	  else if Control is TVDateEdit  then Result := TVDateEdit(Control).ReadOnly
//	  else if Control is TVTimeEdit  then Result := TVTimeEdit(Control).ReadOnly
//	  else if Control is TVEdit      then Result := TVEdit(Control).ReadOnly
//	  else if Control is TVFormatEdit then Result := TVFormatEdit(Control).ReadOnly
//	  else if Control is TVCalcEdit  then Result := TVCalcEdit(Control).ReadOnly
//	  else if Control is TVValueEdit then Result := TVValueEdit(Control).ReadOnly
//	  else if Control is TVNEdit     then Result := TVNEdit(Control).ReadOnly
//{$ENDIF}
//	  else if Control is TXCalendar  then Result := TXCalendar(Control).ReadOnly
	  else                                Result := False;
	end;

	{
	***************************************************************************
		ﾌｫｰｶｽ移動が有効かどうか調べる

			入力    WinCtrl :   検査対象のTWinControl
			出力    return  :   TRUE/FALSE
	***************************************************************************
	}
	function    IsFocusEnable(WinCtrl:TWinControl):Boolean;
	begin

(* ADD FIT T.S 1997-03-17 PageControl＋GroupBoxに対応させる為 PageControlへのﾌｫｰｶｽ移動を無効にする*)
(* ADD FIT T.S 1997-05-02 上記修正で沖縄に障害が発生したため元に戻す*)
//                if WinCtrl is TPageControl  then Result := False
//		else if not WinCtrl.CanFocus then Result := False
		if not WinCtrl.CanFocus     then Result := False
(* ADD END *)
(* ADD END *)

		else if IsReadOnly(WinCtrl) then Result := False
		else if not WinCtrl.TabStop then Result := False
		else                             Result := True;
	end;

	{
	***************************************************************************
		複合ｺﾝﾎﾟｰﾈﾝﾄのﾍﾞｰｽｺﾝﾄﾛｰﾙを取得する

			入力    Control :   ｺﾝﾄﾛｰﾙ
			出力    return  :   ﾍﾞｰｽｺﾝﾄﾛｰﾙ
	***************************************************************************
	}
	function    GetBaseControl(Control:TWinControl):TWinControl;
	begin
		if      Control = nil                    then Result := nil
		else if Control.Owner is THDateEdit      then Result := TWinControl(Control.Owner)
//		else if Control.Owner is TXTimeEdit      then Result := TWinControl(Control.Owner)
//		else if Control.Owner is TXValueEdit     then Result := TWinControl(Control.Owner)
//{$IFDEF ADDCOMRADE}
//		else if Control.Owner is TVDateEdit      then Result := TWinControl(Control.Owner)
//		else if Control.Owner is TVTimeEdit      then Result := TWinControl(Control.Owner)
//		else if Control.Owner is TVValueEdit     then Result := TWinControl(Control.Owner)
//		else if Control.Owner is TVNEdit         then Result := TWinControl(Control.Owner)
//{$ENDIF}
//		else if Control.Owner is TXCalendar      then Result := TWinControl(Control.Owner)
//		else if Control.Owner is TXFunckeyButton then Result := TWinControl(Control.Owner)
//		else if Control.Owner is TXTable         then Result := TWinControl(Control.Owner)
		else                                          Result := Control;
	end;

	{
	***************************************************************************
		ﾏｳｽによるﾌｫｰｶｽ移動が可能かどうかしらべる

			入力    Control :   ｺﾝﾄﾛｰﾙ
			出力    return  :   TRUE/FALSE
	***************************************************************************
	}
	function    IsMouseFocusControl(Control:TWinControl):Boolean;
	begin
		{  TForm }
		if Control is TForm then
			Result := FALSE

{$IFDEF ZERO}
		{ Standard Palette }
		else if (Control is TGroupBox) or (Control is TPanel) then
			Result := FALSE
{$ENDIF}

//		{ TXTable }
//		else if (Control is TXTable) or (Control is TXChildPanel) then
//			Result := FALSE
//
//{$IFDEF UPDATE}
//		{ TXDateEdit, TXTimeEdit }
//		else if (Control is THDateEdit) or (Control is TXTimeEdit) then
//			Result := FALSE
(* 19990920 ADD kubochi begin *)
		else if (Control is THDateEdit) then
			Result := FALSE
(* 19990920 ADD kubochi end   *)
//{$ENDIF}
		else
			Result := TRUE;
	end;

	{
	***************************************************************************
		直前のWM_KEYDOWNに対するｼﾌﾄｷｰ状態の取得

			入力    なし
			出力    return  :   ｼﾌﾄｷｰの状態

			ssShift, ssAlt, ssCtrlのみのﾁｪｯｸ
	***************************************************************************
	}
	function    GetShiftState:TShiftState;
	begin
		Result    := [];
		if GetKeyState(VK_SHIFT)   < 0 then Result := Result + [ssShift];
		if GetKeyState(VK_MENU)    < 0 then Result := Result + [ssAlt];
		if GetKeyState(VK_CONTROL) < 0 then Result := Result + [ssCtrl];
	end;

	{
	***************************************************************************
		起動ﾃﾞｨﾚｸﾄﾘを取得する

			入力    ModuleHandle    :   ｱﾌﾟﾘｹｰｼｮﾝﾊﾝﾄﾞﾙ
			出力    return          :   起動ﾃﾞｨﾚｸﾄﾘ
	***************************************************************************
	}
// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
	function    GetMotiveDirect(ModuleHandle:THandle):String;
	var
		FullPath:array[0..255] of Char;
		Drive:String;
		Direct:String;
		Fname:String;
		Ext:String;
	begin
		if GetModuleFileName(ModuleHandle, FullPath, 255) = 0 then
			Result := ''
		else begin
			FnSplit(StrPas(FullPath), Drive, Direct, Fname, Ext);
			Result := Drive + Direct;
		end;
	end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
	{
	***************************************************************************
		ｳｨﾝﾄﾞｳ領域を再描画せずに設定する

			入力    AHandle         :   ｳｨﾝﾄﾞｳﾊﾝﾄﾞﾙ
					ALeft, ATop     :   始点座標
					AWidth, AHeight :   ｻｲｽﾞ
			出力    なし
	***************************************************************************
	}
//	procedure   SetWindowRectValue(AHandle:HWND; ALeft, ATop, AWidth, AHeight: Integer);
//	var
//		DeferData:HDWP;
//	begin
//		DeferData := BeginDeferWindowPos(1);
//		DeferWindowPos(DeferData, AHandle, 0, ALeft, ATop, AWidth, AHeight, SWP_NOZORDER or SWP_NOREDRAW);
//		EndDeferWindowPos(DeferData);
//	end;
//
        //画面のDSLの名前を取得する
//	function GetCurrDataControl(component:TComponent): TComponent;
//          	function IsDSLControl(compo:TComponent): Boolean;
//               	begin
//               		Result := (compo is TDataControl);
//               	end;
//	var
//		compoForm: TComponent ;
//		i: Integer ;
//	begin
//                Result := nil;
//		if component <> nil then begin
//			compoForm := component.Owner ;
//			if compoForm is TForm then begin
//				for i := 0 to compoForm.ComponentCount - 1 do begin
//					if IsDSLControl(compoForm.Components[i]) then begin
//						if TDataControl(compoForm.Components[i]).FormData = True then begin
//							Result := compoForm.Components[i] ;
//							Exit ;
//						end;
//					end;
//				end;
//			end;
//		end;
//	end;

{*******************************************************************}
{ Module Name   : ｽﾍﾟｰｽｶｯﾄ                                          }
{               : HSpcCut                                           }
{ 引数          : 1 String  ｽﾍﾟｰｽｶｯﾄする文字列                      }
{ 戻り値        : 1 String  ｽﾍﾟｰｽｶｯﾄ後の文字列                      }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 文字列中の全ての半角ｽﾍﾟｰｽ、全角ｽﾍﾟｰｽをｶｯﾄします。 }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function HSpcCut(szParam: String): String;
var
   ix: integer;
   iCnt: integer;
   szStr: String;
   lpStr1: array[0..255] of Char;
   lpStr2: array[0..255] of Char;
begin
  FillChar(lpStr1, SizeOf(lpStr1), #0);
  FillChar(lpStr2, SizeOf(lpStr2), #0);
  StrPLCopy(lpStr1, szParam, Length(szParam));

  iCnt := 0;
  ix := 0;
  while (ix <= SizeOf(lpStr1) - 1) do
  begin
// 2009.08.10 Del Start >>>>>>>>>>>>>>>
//       if (lpStr1[ix] = Chr($81)) and (lpStr1[ix + 1] = Chr($40)) then
//       begin
//         Inc(ix);
//       end
//       else if (lpStr1[ix] <> Chr($20)) and (lpStr1[ix] <> Chr($0)) then
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<
       if (lpStr1[ix] <> ' ') and (lpStr1[ix] <> '　') and (lpStr1[ix] <> Chr($0)) then  // 2009.08.10 Ins
       begin
          lpStr2[iCnt] := lpStr1[ix];
          Inc(iCnt);
       end
       else if lpStr1[ix] = Chr($0) then
            Break;

       Inc(ix);
  end;

  lpStr2[iCnt + 1] := Chr($0);
  szStr := StrPas(lpStr2);
  Result := szStr;
end;

{*******************************************************************}
{ Module Name   : 各種INIﾌｧｲﾙﾊﾟｽ取得                                }
{               : HIniPathMakeLib                                   }
{ 引数          : 1 String   INIﾌｧｲﾙ名称                            }
{ 戻り値        : 1 String   編集後文字列                           }
{ Programer     : ueo                                               }
{ Date          : 1999.09.25                                        }
{ Note          : SFPATH.INIﾌｧｲﾙよりそれぞれのINIﾌｧｲﾙﾊﾟｽを取得します}
{               : 取得した文字列が'LAN'or'LOCAL'の場合はさらにLANの }
{               : ﾊﾟｽ及びLOCALのﾊﾟｽを取得する。                     }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
{                                                                      2001.02.26 削除
function HIniPathMakeLib(strIFile:String):String;
var
  ix         : Integer;
  szRetPath  : Array[0..MAX_PATH] of Char;
  strIName   : String;
  cDrive     : Char;
  strDirPart : String;
  strFilePart: String;
begin
  Result := '';

  //INIﾌｧｲﾙ名称から拡張子、ﾄﾞﾗｲﾌﾞﾊﾟｽをはずす。
  strIName := ChangeFileExt(ExtractFileName(strIFile),'');

  //SFPATH.INIより情報取得
  ZeroMemory(@szRetPath,sizeof(szRetPath));
  for ix:=0 to 100 do
  begin
    GetPrivateProfileString('INIPATH',PChar(strIName),'',@szRetPath,
      sizeof(szRetPath),'SFPATH.INI');
    if strlen(szRetPath) <> 0 then
      break;
  end;
  if strlen(szRetPath) = 0 then
    Exit;
  if CompareText(szRetPath,'LAN') = 0 then
  begin
    for ix:=0 to 100 do
    begin
      GetPrivateProfileString('INIPATH','LAN','',@szRetPath,
        sizeof(szRetPath),'SFPATH.INI');
      if strlen(szRetPath) <> 0 then
        break;
    end;
    if strlen(szRetPath) = 0 then
      Exit;
  end;
  if CompareText(szRetPath,'LOCAL') = 0 then
  begin
    for ix:=0 to 100 do
    begin
      GetPrivateProfileString('INIPATH','LOCAL','',@szRetPath,
        sizeof(szRetPath),'SFPATH.INI');
      if strlen(szRetPath) <> 0 then
        break;
    end;
    if strlen(szRetPath) = 0 then
      Exit;
  end;

  //取得したﾊﾟｽの確認
  cDrive := CHR(0);
  strDirPart := '';
  strFilePart:= '';
  ProcessPath(szRetPath,cDrive,strDirPart,strFilePart);
  if strFilePart = '' then
  begin
    if szRetPath[strlen(szRetPath)-1] <> '\' then
      strcat(szRetPath,'\');
    strcat(szRetPath,PChar(ExtractFileName(strIFile)));
  end;

  //拡張子が無い場合は｢.INI｣をつける
  if ExtractFileExt(szRetPath) = '' then
    strcat(szRetPath,'.INI');
  Result := szRetPath;
end;
}
end.
