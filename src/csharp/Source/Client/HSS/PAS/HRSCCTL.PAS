unit HRSCCTL;
//**********************************************************************//
// System           :   システム共通                                    //
// Sub System       :   HSS部品                                         //
// Program name     :   メモリアクセスDLL 関数群                        //
//                  :   HRSCCTL.DLL                                     //
// Programer        :   鹿野　幸生 & 宮富　孝洋                         //
// Date             :   1999.07.15                                      //
//----------------------------------------------------------------------//
// Update Note      :   1999.12.20  鹿野　幸生                          //
//                  :   １．SF LITE明細画面用に大幅変更                 //
//                  :       リソース空間を複数個設けて、それぞれに属性を//
//                  :       持たせて制御する様にした。                  //
//                  :   2000.02.22  鹿野　幸生                          //
//                  :   １．SF LITE明細画面用にソート機能、以上、以下   //
//                  :       検索機能を追加                              //
//                  :   2000.05.30  宮富　孝洋                          //
//                  :   １．共有メモリクラス追加                        //
//                  :   2000.06.17  宮富　孝洋                          //
//                  :   １．共有メモリクラス…コンポ化                  //
//                  :   2000.07.05  鹿野　幸生                          //
//                  :   １．SrchKeyRec関数でレコードNoの扱いがおかし    //
//                  :       かったのを修正                              //
//                  :   2000.10.04  鹿野　幸生                          //
//                  :   １．スピードアップの為、冗長なロジックを排除    //
//                  :   2001.02.26  鹿野　幸生                          //
//                  :   １．HRSCCTL.DLLをHRSCCTL50.DLLに変更            //
//                  :   2009.08.12  鹿野　幸生                          //
//                  :   ① HSS100対応                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  1999 TSUBASA SYSTEM Co,. Ltd            //
//**********************************************************************//


interface
 (*>>>>> 2000.05.30 Miyatomi ADD >>>>>*)
uses
    Windows, SysUtils, Classes, Dialogs, HVersion;
 (*<<<<< 2000.05.30 Miyatomi ADD <<<<<*)
const
  MAX_SORT_FIG = 4;                      // 最大ソートＮｏ数(実際には+1)
  MAX_SRCH_KEY = 4;                      // 最大検索KEY数(実際には+1)
  MAX_SRCH_FIG = 9;                      // 最大検索フィールド数(実際には+1)

  LOCK_NO        = 0;                    // ロック無し
  LOCK_READ_ONLY = 1;                    // 読取りのみ許可
  LOCK_EXCLUSIVE = 2;                    // 排他

  FLDTYPE_NONE   = 0;                    // フィールド属性無し(以下の属性以外)
  FLDTYPE_FIG    = 1;                    // 数値型
  FLDTYPE_STR    = 2;                    // 文字型

  RECNO_AUTO     = 0;                    // レコード番号自動発番
  RECNO_MANU     = 1;                    // レコード番号指定発番

  BUFFTYPE_FIX   = 0;                    // バッファタイプ固定長
  BUFFTYPE_VAR   = 1;                    // バッファタイプ可変長

  OPRND_RSCID_DIRECT     = 0;            //  リソースID指定発番型
  OPRND_RSCID_AUTO       = 1;            //  リソースID自動発番型
  OPRND_RSCID_BASE_PLUS  = 2;            //  リソースID指定番号以降自動発番型

  OPRND_GET_DEL_FORCE    = 1;            // 論理削除でも強制読込み
  OPRND_GET_FILTER_FORCE = 2;            // フィルター状態でも強制読込み
  OPRND_NO_MOVE          = 4;            // 現在行の移動無し
  OPRND_PREV_INSERT      = 8;            // レコード挿入の際、相手先の前行に挿入
  OPRND_OVERRIDE         = 16;           // 共有空間同士のコピー際、相手先に上書きコピー

  SRCH_FST   = 1;                        // 先頭行検索
  SRCH_NXT   = 2;                        // 現在行の次行検索
  SRCH_PRV   = 4;                        // 現在行の前行検索
  SRCH_LAST  = 8;                        // 最終行検索
  SRCH_EQUAL = 16;                       // イコール検索(後ろ方向検索)
  SRCH_GT    = 32;                       // より大きい検索(後ろ方向検索)
  SRCH_GTEQ  = 64;                       // 以上検索(後ろ方向検索)
  SRCH_LT    = 128;                      // より小さい検索(前方向検索)
  SRCH_LTEQ  = 256;                      // 以下検索(前方向検索)

type

  // 共有空間情報(検索フィールド)保存用構造体
  tagSrchFld = record
    lStrtFld: longint;                   // 検索開始バイト位置(ゼロからスタート)
    lFldLen:  longint;                   // 検索バイト数
    nPropty:  smallint;                  // 属性(0:その他,1:数値,2:文字)
  end;

  tagSrchKey = record
    nFldFig: smallint;                                // 検索フィールド数
    SrchFld: array [0..MAX_SRCH_FIG] of tagSrchFld;   // 検索フィールド
  end;

  // 共有空間情報構造体(設定用)
  tagSetShrSpaceInf = record
    lRscId:      longint;                // リソースＩＤ
    nLockShrMode:smallint;               // 共有空間ロックモード(0:ロック無し,1:読取りのみ許可,2:排他)
    lLockHandle: longint;                // 共有空間ロック時のハンドル
    nRecNoType:  smallint;               // レコード番号発番タイプ(0:自動発番, 1:指定発番)
    nBuffType:   smallint;               // バッファタイプ(0:固定長, 1:可変長)
    lBuffLen:    longint;                // バッファ長
    lUndoMaxFig: Longint;                // 最大UNDO回数
    nSrchKeyFig: smallint;               // 検索KEY設定数
    SrchKey: array [0..MAX_SRCH_KEY] of tagSrchKey;   // 検索KEY
    nOperand:    smallint;               // 追加オペランド
    reserve: array [0..19] of char;      // リザーブ領域
  end;

  // 共有空間情報構造体(取得用)
  tagGetShrSpaceInf = record
    lRscId:       longint;               // リソースＩＤ
    nLockShrMode: smallint;              // 共有空間ロックモード(0:ロック無し,1:読取りのみ許可,2:排他)
    nRecNoType:  smallint;               // レコード番号発番タイプ(0:自動発番, 1:指定発番)
    nBuffType:   smallint;               // バッファタイプ(0:固定長, 1:可変長)
    lBuffLen:    longint;                // バッファ長
    lCntRec:      longint;               // レコード件数
    lLastRecNo:   longint;               // 最終レコード番号
    lUndoNo:      longint;               // 現在UNDO回数
    nFilterMark:  smallint;              // フィルタ(0:無し, -1:マーキング行無効,1以上:指定番号のマーキング行のみ有効)
    nLastSortNo:  smallint;              // 最終ソートキー番号             2000.02.22  追加
    nSrchKeyFig:  smallint;              // 検索KEY設定数
    reserve: array [0..19] of char;      // リザーブ領域                                             							//	リザーブ領域
  end;

  // 共有空間アクセス用構造体
  tagShrSpaceInf = record
    lRscId:      longint;                // リソースＩＤ
    lLockHandle: longint;                // 共有空間ロック時のハンドル
    nSortNo:     smallint;               // ソート順番号                   2000.02.22  追加
    nOperand:    smallint;               // 追加オペランド
    reserve: array [0..19] of char;      // リザーブ領域                                             							//	リザーブ領域
  end;

  // レコードイメージアクセス用構造体
  tagRecInf = record
    lRscId:   longint;                   // リソースＩＤ
    lLockHandle: longint;                // 共有空間ロック時のハンドル
    lBuffLen: longint;                   // バッファ長
    pBuff:    pointer;                   // レコードイメージバッファへのアドレス
    lDtlNo:   longint;                   // レコード番号
    nFlgMark: smallint;                  // マーキング情報(0:マーキング無し,1:マーキング有り)
    nOperand: smallint;                  // 追加オペランド
    reserve: array [0..19] of char;      // リザーブ領域                                             							//	リザーブ領域
  end;

 (*>>>>> 2000.05.30 Miyatomi ADD >>>>>*)
  EShrSpaceException = class(Exception);
 
  (*----- Undoﾘｿｰｽﾊﾞｯﾌｧ ------------------------------------------------------*)
  PtagUndoRscBuff = ^tagUndoRscBuff;
  tagUndoRscBuff = packed record
    nRscId         : Longint;                         // ﾘｿｰｽID
    nLockHnd       : Longint;                         // ﾛｯｸﾊﾝﾄﾞﾙ
    szName         : array[0..64] of Char;            // ﾊﾞｯﾌｧ名称
  end;

  (*----- 共有空間操作クラス -------------------------------------------------*)
//THRscCtl = class(TObject)          // 2000.06.17 MIYATOMI DEL
  THRscCtl = class(TComponent)       // 2000.06.17 MIYATOMI ADD
  private
    { private 宣言 }
    mbInfoGet      : Boolean;                         // 共有空間情報取得済み
    mnSortNo        : Smallint;                        // 検索キー番号

    mnRscId        : Longint;                         // リソースID
    mnLockShrMode  : Smallint;                        // 共有空間ロックモード
                                                      // 0:無し 1:読取許可 2:排他
    mnRecNoType    : Smallint;                        // ﾚｺｰﾄﾞ発番ﾀｲﾌﾟ 0:自動発番 1:指定発番
    mnBuffType     : Smallint;                        // ﾊﾞｯﾌｧﾀｲﾌﾟ     0:固定長   1:可変長
    mpBuff         : Pointer;                         // ﾊﾞｯﾌｧﾎﾟｲﾝﾀ
    mnBuffLen      : Longint;                         // ﾊﾞｯﾌｧ長

    mnFlgMark      : Smallint;                        // マーク

    mnLockHnd      : Longint;                         // ﾛｯｸﾊﾝﾄﾞﾙ

    mnUndoPos      : Longint;                         // 現在書き込み対象バッファ
    mnUndoMax      : Longint;                         // 最大undo保持件数
    mUndoList      : TList;                           // Undoﾊﾞｯﾌｧﾘｽﾄ

     FVersion      : TVersion;                     { ﾊﾞｰｼﾞｮﾝ        }

    function  GetShrInfo(nRscId: Longint; var stGetShrInf: tagGetShrSpaceInf): Integer;

    procedure SetRscId(nRscId: Longint);              // ﾘｿｰｽID設定

    procedure SetRow(nRowno: Longint);                // ｶﾚﾝﾄ行指定
    function  GetRow: Longint;                        // ｶﾚﾝﾄ行取得
    function  GetRecNo: Longint;                      // ｶﾚﾝﾄ行番号取得
    function  GetRecCnt: Longint;                     // ﾚｺｰﾄﾞ件数取得
    procedure SetFilter(nFilter: Smallint);           // フィルター設定
    function  GetFilter: Smallint;                    // フィルター取得
    function  GetSrchKeyFig: Smallint;                // 検索キー数取得
    function  GetLife: Smallint;                      // 共有空間有り？
    function  GetCanRedo: Boolean;                    // Redo可能？
    function  GetCanUndo: Boolean;                    // Undo可能？
    procedure SetUndoMax(nMax: Longint);              // undo最大件数
    procedure DelUndoBuff(nIndex: Integer);           // 指定ｲﾝﾃﾞｯｸｽのUNDOﾊﾞｯﾌｧ削除
    procedure DelAllUndoBuff;                         // 全てのUNDOﾊﾞｯﾌｧ削除
    function  SetUndoShrSpaceSub: Integer;               // Undoバッファに現在のイメージを設定
    function  CreateUndoBuff(var pUndoBuff: PtagUndoRscBuff): Integer;
    function  CopySpaceSub(var nDstrsc : Longint;
                           var nDstlock: Longint;
                            nLockMode : Smallint;
                            nSrcrsc, nSrclock: Longint; nOperand: Smallint): Integer;
    function  DelShrSpaceSub(nRscid, nLockHandle: Longint): Integer;
    function  DelAllShrRecSub(nRscid, nLockHandle: Longint): Integer;
  protected
    { protected 宣言 }
  public
    { public 宣言 }
//  constructor Create;                                // 2000.06.17 MIYATOMI DEL
    constructor Create(AOwner: TComponent); override;  // 2000.06.17 MIYATOMI ADD
    destructor  Destroy; override;

    (* 共有空間操作 *)
    function CreatShrSpace(var stSetShrInf: tagSetShrSpaceInf): Smallint; // 共有空間生成
    function DelShrSpace: Smallint;                                 // 共有空間破棄

    function CopyShrSpace(var DstSpace: THRscCtl; nLockMode, nOperand: Smallint): Integer;            // 共有空間コピー

    function SetSrchKey(nSortNo: Smallint;
                        var stSrchKey: tagSrchKey): Integer;         // キー設定

    (* レコード操作 *)
    function SrchKeyRec(nSrchType: Smallint; pKeyBuff: Pointer;
                        nOperand : Smallint; var nRecNo: Longint): Integer; // ﾚｺｰﾄﾞ検索
    function GetShrRec(nRecNo: Longint; nOperand: Smallint): Integer;   // ﾚｺｰﾄﾞ取得
    function AddShrRec(var nRecNo: Longint): Integer;                       // ﾚｺｰﾄﾞ追加
    function InsShrRec(var nRecNo: Longint; nOperand: Smallint): Integer;   // ﾚｺｰﾄﾞ挿入
    function UpdtShrRec(var nRecNo: LongInt; nOperand: Smallint): Integer;  // ﾚｺｰﾄﾞ更新
    function MarkShrRec(var nRecNo: Longint): Integer;                     // ﾏｰｸ更新
    function DelShrRec(var nRecNo: Longint): Integer;                       // ﾚｺｰﾄﾞ物理削除
    function DelAllShrRec: Integer;                                     // ﾚｺｰﾄﾞ全物理削除
    function HideShrRec(var nRecNo: Longint): Integer;                      // ﾚｺｰﾄﾞ論理削除
    function UndoShrRec(nUndoNo: Longint): Integer;                     // ﾚｺｰﾄﾞｲﾒｰｼﾞ論理削除復活
    function MoveShrRec(var DstSpace: THRscCtl; nDstRecNo,
                     nSrcRecNo: Longint; nOperand: Smallint): Integer;  // ﾚｺｰﾄﾞｲﾒｰｼﾞ移動
    function CopyShrRec(var DstSpace: THRscCtl; nDstRecNo,
                     nSrcRecNo: Longint; nOperand: Smallint): Integer;  // ﾚｺｰﾄﾞｲﾒｰｼﾞｺﾋﾟｰ
    function  GetHideShrRecCnt(nUndoNo: Longint): Longint;              // 論理削除件数

    (* アンドゥ関連 *)
    function ClearUndoShrSpace: Integer;                             // Undoバッファの消去
    function ClearRedoShrSpace: Integer;                             // Redoバッファの消去
    function UndoShrSpace: Integer;                                  // Undo処理
    function RedoShrSpace: Integer;                                  // Redo処理
    function SetUndoShrSpace: Integer;                               // Undoバッファに現在のイメージを設定

    (* カレント行移動 *)
    function FirstShrRec: Integer;                                   // ｶﾚﾝﾄ行を先頭に
    function PrevShrRec : Integer;                                   // ｶﾚﾝﾄ行を前に
    function NextShrRec : Integer;                                         // ｶﾚﾝﾄ行を次に
    function LastShrRec : Integer;                                         // ｶﾚﾝﾄ行を最後に

    (* プロパティ *)
    property Life      : Smallint read GetLife;                      // 共有空間有り？
    property LockMode  : Smallint read mnLockShrMode;                // ロックモード
    property RecNoType : Smallint read mnRecNoType;                  // ﾚｺｰﾄﾞ発番ﾀｲﾌﾟ
    property BuffType  : Smallint read mnBuffType;                   // ﾊﾞｯﾌｧﾀｲﾌﾟ
    property SrchKeyFig: Smallint read GetSrchKeyFig;                // 検索ｷｰの数
    property SortNo    : Smallint read mnSortNo  write mnSortNo;     // ソートキー番号 0~

    property DatBuff   : Pointer  read mpBuff    write mpBuff;       // ﾚｺｰﾄﾞﾊﾞｯﾌｧﾎﾟｲﾝﾀ
    property BuffLen   : Longint  read mnBuffLen write mnBuffLen;    // ﾚｺｰﾄﾞ長
    property Mark      : Smallint read mnFlgMark write mnFlgMark;    // マーク
             (* 行関連 *)
    property Row       : Longint  read GetRow    write SetRow;       // カレント行番号 1~
    property RecNo     : Longint  read GetRecNo;                     // カレントレコード番号 1~
    property RecCnt    : Longint  read GetRecCnt;                    // ﾚｺｰﾄﾞ件数取得
    property Filter    : Smallint read GetFilter write SetFilter;    // フィルター
             (* UNDO関連 *)
    property CanUndo   : boolean  read GetCanUndo;                   // Undoできるか
    property CanRedo   : boolean  read GetCanRedo;                   // Redoできるか

  published
             (* ﾘｿｰｽID *)
    property RscId     : Longint  read mnRscId   write SetRscId;     // リソースID
    property LockHandle: Longint  read mnLockHnd write mnLockHnd;    // ロックハンドル
    property UndoMax   : Longint  read mnUndoMax write SetUndoMax;   // UNDO最大件数
    property Version   : TVersion read FVersion write FVersion stored False;
  end;
  
 (*<<<<< 2000.05.30 Miyatomi ADD <<<<<*)
 (*>>>>> 2000.06.17 MIYATOMI ADD >>>>>*)
  TCreatShrSpace    = function (var ipSetShrSpaceInf: tagSetShrSpaceInf): Smallint; stdcall;
  TGetShrSpace      = function (var ipGetShrSpaceInf: tagGetShrSpaceInf): Smallint; stdcall;
  TCopyShrSpace     = function (var ipDstShrSpaceInf: tagShrSpaceInf; inDstLockMode: smallint; var ipSrcShrSpaceInf: tagShrSpaceInf): Smallint; stdcall;
  TDelShrSpace      = function (var ipShrSpaceInf: tagShrSpaceInf): Smallint; stdcall;
  TSetShrFilter     = function (var ipShrSpaceInf: tagShrSpaceInf; inFilterMode: Smallint): Smallint; stdcall;

  TInsShrRec        = function (var ipRecInf: tagRecInf): Smallint; stdcall;
  TGetShrRec        = function (var ipRecInf: tagRecInf): smallint; stdcall;
  TDelShrRec        = function (var ipRecInf: tagRecInf): smallint; stdcall;
  THideShrRec       = function (var ipRecInf: tagRecInf): smallint; stdcall;
  TUndoShrRec       = function (var ipShrSpaceInf: tagShrSpaceInf; ilUndoNo: longint): longint; stdcall;
  TGetHideShrRecCnt = function (var ipShrSpaceInf: tagShrSpaceInf; ilUndoNo: longint): longint; stdcall;
  TAddShrRec        = function (var ipRecInf: tagRecInf): smallint; stdcall;
  TUpdtShrRec       = function (var ipRecInf: tagRecInf): smallint; stdcall;
  TQueryCurShrRec   = function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
  TDelAllShrRec     = function (var ipShrSpaceInf: tagShrSpaceInf): smallint; stdcall;
  TGetShrRecCnt     = function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
  TMarkShrRec       = function (var ipRecInf: tagRecInf): smallint; stdcall; 

  TFirstShrRec      = function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
  TPrevShrRec       = function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
  TNextShrRec       = function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
  TLastShrRec       = function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
  TGoShrRow         = function (var ipShrSpaceInf: tagShrSpaceInf; ilRowNo: longint): longint; stdcall;
  TQueryCurShrRow   = function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;

  TMoveShrRec       = function (var ipDstRecInf, ipSrcRecInf: tagRecInf): smallint; stdcall;
  TCopyShrRec       = function (var ipDstRecInf, ipSrcRecInf: tagRecInf): smallint; stdcall;

  TSetSrchKey       = function (var ipShrSpaceInf: tagShrSpaceInf; var ipSrchKey:tagSrchKey): smallint; 
  TSrchKeyRec       = function (var ipRecInf:tagRecInf; inSrchType: smallint;
                                               inKeyFig: smallint; ipKeyBuff: pointer): smallint; stdcall; 
 (*<<<<< 2000.06.17 MIYATOMI ADD <<<<<*)

//**************************************************************************//
//	関数プロトタイプ宣言                                                   //
//**************************************************************************//
 (*>>>>> 2000.06.17 MIYATOMI DEL >>>>>*)
//function CreatShrSpace (var ipSetShrSpaceInf: tagSetShrSpaceInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function GetShrSpace (var ipGetShrSpaceInf: tagGetShrSpaceInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function CopyShrSpace (var ipDstShrSpaceInf: tagShrSpaceInf; inDstLockMode: smallint; var ipSrcShrSpaceInf: tagShrSpaceInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function DelShrSpace (var ipShrSpaceInf: tagShrSpaceInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function SetShrFilter (var ipShrSpaceInf: tagShrSpaceInf; inFilterMode: smallint): smallint; stdcall; external 'HRSCCTL.DLL';

//function InsShrRec (var ipRecInf: tagRecInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function GetShrRec (var ipRecInf: tagRecInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function DelShrRec ( var ipRecInf: tagRecInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function HideShrRec (var ipRecInf: tagRecInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function UndoShrRec (var ipShrSpaceInf: tagShrSpaceInf; ilUndoNo: longint): longint; stdcall; external 'HRSCCTL.DLL';
//function GetHideShrRecCnt (var ipShrSpaceInf: tagShrSpaceInf; ilUndoNo: longint): longint; stdcall; external 'HRSCCTL.DLL';
//function AddShrRec (var ipRecInf: tagRecInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function UpdtShrRec (var ipRecInf: tagRecInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function QueryCurShrRec (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall; external 'HRSCCTL.DLL';
//function DelAllShrRec(var ipShrSpaceInf: tagShrSpaceInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function GetShrRecCnt (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall; external 'HRSCCTL.DLL';
//function MarkShrRec (var ipRecInf: tagRecInf): smallint; stdcall; external 'HRSCCTL.DLL';

//function FirstShrRec (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall; external 'HRSCCTL.DLL';
//function PrevShrRec (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall; external 'HRSCCTL.DLL';
//function NextShrRec (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall; external 'HRSCCTL.DLL';
//function LastShrRec (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall; external 'HRSCCTL.DLL';
//function GoShrRow (var ipShrSpaceInf: tagShrSpaceInf; ilRowNo: longint): longint; stdcall; external 'HRSCCTL.DLL';
//function QueryCurShrRow (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall; external 'HRSCCTL.DLL';

//function MoveShrRec (var ipDstRecInf, ipSrcRecInf: tagRecInf): smallint; stdcall; external 'HRSCCTL.DLL';
//function CopyShrRec (var ipDstRecInf, ipSrcRecInf: tagRecInf): smallint; stdcall; external 'HRSCCTL.DLL';

//function SetSrchKey (var ipShrSpaceInf: tagShrSpaceInf; inKeyFig: smallint; var ipSrchKey:tagSrchKey): smallint; stdcall; external 'HRSCCTL.DLL';  2000.02.22 変更
//function SetSrchKey (var ipShrSpaceInf: tagShrSpaceInf; var ipSrchKey:tagSrchKey): smallint; stdcall; external 'HRSCCTL.DLL';
//function SrchKeyRec (var ipRecInf:tagRecInf; inSrchType: smallint;
//                       inKeyFig: smallint; ipKeyBuff: pointer): smallint; stdcall; external 'HRSCCTL.DLL';
 (*<<<<< 2000.06.17 MIYATOMI DEL <<<<<*)

// 1999.12.20  鹿野　幸生 大幅変更に伴い、従来の関数は削除
// function CreatRecInf (ilRscId: longint; ilDtlNo: longint; ilBuffLen: longint; ipszBUff: pointer): smallint; cdecl; external 'HRSCCTL.DLL';
// function SetRecInf (ilRscId: longint; ilDtlNo: longint; ilBuffLen: longint; ipszBUff: pointer): smallint; cdecl; external 'HRSCCTL.DLL';
// function GetRecInf (ilRscId: longint; ilDtlNo: longint; ilBuffLen: longint; ipszBUff: pointer): smallint; cdecl; external 'HRSCCTL.DLL';
// function DelRecInf (ilRscId: longint; ilDtlNo: longint): smallint; cdecl; external 'HRSCCTL.DLL';
// function LoadDataSpace (ilRscId: longint; ilBuffLen: longint; ipszBUff: pointer): smallint; cdecl; external 'HRSCCTL.DLL';
// function SaveDataSpace (ilRscId: longint; ilBuffLen: longint; ipszBUff: pointer): smallint; cdecl; external 'HRSCCTL.DLL';
// function DelSpace (ilRscId: longint): smallint; cdecl; external 'HRSCCTL.DLL';

procedure Register;

implementation

 (*>>>>> 2000.05.30 Miyatomi ADD >>>>>*)
  (*=====================================*)
  (*  定数宣言                           *)
  (*=====================================*)
const
     ctHRSCCTL_DLL = 'HRSCCTL100.DLL';
     ctErrSetRow   = 'カレント行設定エラー'#13;
     ctErrGetRow   = 'カレント行取得エラー'#13;
     ctErrGetRecNo = 'カレントレコード番号取得エラー'#13;
     ctErrGetRecCnt= 'レコード件数取得エラー'#13;
     cnUndoRsc     = 100000000;

  (*=====================================*)
  (*  グローバル変数                     *)
  (*=====================================*)
var
   mhDllInst           : HINST;
   gfpCreatShrSpace    : function (var ipSetShrSpaceInf: tagSetShrSpaceInf): smallint; stdcall;
   gfpGetShrSpace      : function (var ipGetShrSpaceInf: tagGetShrSpaceInf): smallint; stdcall;
   gfpCopyShrSpace     : function (var ipDstShrSpaceInf: tagShrSpaceInf; inDstLockMode: smallint; var ipSrcShrSpaceInf: tagShrSpaceInf): smallint; stdcall;
   gfpDelShrSpace      : function (var ipShrSpaceInf: tagShrSpaceInf): smallint; stdcall;
   gfpSetShrFilter     : function (var ipShrSpaceInf: tagShrSpaceInf; inFilterMode: smallint): smallint; stdcall;

   gfpInsShrRec        : function (var ipRecInf: tagRecInf): smallint; stdcall;
   gfpGetShrRec        : function (var ipRecInf: tagRecInf): smallint; stdcall;
   gfpDelShrRec        : function (var ipRecInf: tagRecInf): smallint; stdcall;
   gfpHideShrRec       : function (var ipRecInf: tagRecInf): smallint; stdcall;
   gfpUndoShrRec       : function (var ipShrSpaceInf: tagShrSpaceInf; ilUndoNo: longint): longint; stdcall;
   gfpGetHideShrRecCnt : function (var ipShrSpaceInf: tagShrSpaceInf; ilUndoNo: longint): longint; stdcall;
   gfpAddShrRec        : function (var ipRecInf: tagRecInf): smallint; stdcall;
   gfpUpdtShrRec       : function (var ipRecInf: tagRecInf): smallint; stdcall;
   gfpQueryCurShrRec   : function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
   gfpDelAllShrRec     : function (var ipShrSpaceInf: tagShrSpaceInf): smallint; stdcall;
   gfpGetShrRecCnt     : function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
   gfpMarkShrRec       : function (var ipRecInf: tagRecInf): smallint; stdcall;

   gfpFirstShrRec      : function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
   gfpPrevShrRec       : function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
   gfpNextShrRec       : function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
   gfpLastShrRec       : function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;
   gfpGoShrRow         : function (var ipShrSpaceInf: tagShrSpaceInf; ilRowNo: longint): longint; stdcall;
   gfpQueryCurShrRow   : function (var ipShrSpaceInf: tagShrSpaceInf): longint; stdcall;

   gfpMoveShrRec       : function (var ipDstRecInf, ipSrcRecInf: tagRecInf): smallint; stdcall;
   gfpCopyShrRec       : function (var ipDstRecInf, ipSrcRecInf: tagRecInf): smallint; stdcall;

   gfpSetSrchKey       : function (var ipShrSpaceInf: tagShrSpaceInf; var ipSrchKey:tagSrchKey): smallint; stdcall;
   gfpSrchKeyRec       : function (var ipRecInf:tagRecInf; inSrchType: smallint;
                                       inKeyFig: smallint; ipKeyBuff: pointer): smallint; stdcall;

//**********************************************************************//
// Module Name     :  コンポーネント登録処理                            //
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
     RegisterComponents('HSS', [THRscCtl]);           // HSSページに追加
end;

//**********************************************************************//
// Module Name     :  共有空間操作クラス 生成                           //
//                 :  THRscCtl.Create                                 //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
//constructor THRscCtl.Create;                       // 2000.06.17 MIYATOMI DEL
constructor THRscCtl.Create(AOwner: TComponent);     // 2000.06.17 MIYATOMI ADD
begin
//   inherited Create;                                 // 2000.06.17 MIYATOMI DEL

     // アンドゥ用バッファ初期化
     try
       inherited Create(AOwner);                       // 2000.06.17 MIYATOMI ADD
       mUndoList    := TList.Create;
       mnUndoMax    := 5;
       mnUndoPos    := 0;
     except on E:Exception do
       raise EShrSpaceException.Create(E.Message);
     end;

     // その他のバッファ初期化
     mbInfoGet    := False;
     mnSortNo      := 0;
     mnRscId      := 0;
     mnLockHnd    := 0;
     mpBuff       := nil;
     mnBuffLen    := 0;

     FVersion           := HRepeatImageVersion;

     // デザインモードの場合は、DLLを起動しない
     if csDesigning in ComponentState then Exit;

     // 起動時にDLLをロードする
     if mhDllInst = 0 then
     begin
//       mhDllInst := LoadLibrary('HRSCCTL.DLL');                               2001.02.26 変更
       mhDllInst := LoadLibrary(ctHRSCCTL_DLL);
     end;

     if mhDllInst = 0 then
     begin
//       raise EShrSpaceException.Create('Load failed Dynamic link library! <HRSCCTL.DLL>');
       raise EShrSpaceException.Create(ctHRSCCTL_DLL + 'のロードに失敗しました');
     end else
     // 関数ﾎﾟｲﾝﾀの取得                                                         2000.10.04 変更
     begin
       if @gfpCreatShrSpace = nil then
       begin
         if @gfpCreatShrSpace = nil then
           gfpCreatShrSpace    := GetProcAddress(mhDllInst, 'CreatShrSpace');
         if @gfpGetShrSpace = nil then
           gfpGetShrSpace      := GetProcAddress(mhDllInst, 'GetShrSpace');
         if @gfpCopyShrSpace = nil then
           gfpCopyShrSpace     := GetProcAddress(mhDllInst, 'CopyShrSpace');
         if @gfpDelShrSpace = nil then
           gfpDelShrSpace      := GetProcAddress(mhDllInst, 'DelShrSpace');
         if @gfpSetShrFilter = nil then
           gfpSetShrFilter     := GetProcAddress(mhDllInst, 'SetShrFilter');
         if @gfpInsShrRec = nil then
           gfpInsShrRec        := GetProcAddress(mhDllInst, 'InsShrRec');
         if @gfpGetShrRec = nil then
           gfpGetShrRec        := GetProcAddress(mhDllInst, 'GetShrRec');
         if @gfpDelShrRec = nil then
           gfpDelShrRec        := GetProcAddress(mhDllInst, 'DelShrRec');
         if @gfpHideShrRec = nil then
           gfpHideShrRec       := GetProcAddress(mhDllInst, 'HideShrRec');
         if @gfpUndoShrRec = nil then
           gfpUndoShrRec       := GetProcAddress(mhDllInst, 'UndoShrRec');
         if @gfpGetHideShrRecCnt = nil then
           gfpGetHideShrRecCnt := GetProcAddress(mhDllInst, 'GetHideShrRecCnt');
         if @gfpAddShrRec = nil then
           gfpAddShrRec        := GetProcAddress(mhDllInst, 'AddShrRec');
         if @gfpUpdtShrRec = nil then
           gfpUpdtShrRec       := GetProcAddress(mhDllInst, 'UpdtShrRec');
         if @gfpQueryCurShrRec = nil then
           gfpQueryCurShrRec   := GetProcAddress(mhDllInst, 'QueryCurShrRec');
         if @gfpDelAllShrRec = nil then
           gfpDelAllShrRec     := GetProcAddress(mhDllInst, 'DelAllShrRec');
         if @gfpGetShrRecCnt = nil then
           gfpGetShrRecCnt     := GetProcAddress(mhDllInst, 'GetShrRecCnt');
         if @gfpMarkShrRec = nil then
           gfpMarkShrRec       := GetProcAddress(mhDllInst, 'MarkShrRec');
         if @gfpFirstShrRec = nil then
           gfpFirstShrRec      := GetProcAddress(mhDllInst, 'FirstShrRec');
         if @gfpPrevShrRec= nil then
           gfpPrevShrRec       := GetProcAddress(mhDllInst, 'PrevShrRec');
         if @gfpNextShrRec = nil then
           gfpNextShrRec       := GetProcAddress(mhDllInst, 'NextShrRec');
         if @gfpLastShrRec = nil then
           gfpLastShrRec       := GetProcAddress(mhDllInst, 'LastShrRec');
         if @gfpGoShrRow = nil then
           gfpGoShrRow         := GetProcAddress(mhDllInst, 'GoShrRow');
         if @gfpQueryCurShrRow = nil then
           gfpQueryCurShrRow   := GetProcAddress(mhDllInst, 'QueryCurShrRow');
         if @gfpMoveShrRec = nil then
           gfpMoveShrRec       := GetProcAddress(mhDllInst, 'MoveShrRec');
         if @gfpCopyShrRec = nil then
           gfpCopyShrRec       := GetProcAddress(mhDllInst, 'CopyShrRec');
         if @gfpSetSrchKey = nil then
           gfpSetSrchKey       := GetProcAddress(mhDllInst, 'SetSrchKey');
         if @gfpSrchKeyRec = nil then
           gfpSrchKeyRec       := GetProcAddress(mhDllInst, 'SrchKeyRec');

         // ポインタのNULLチェック                                              2000.10.04 追加
         if (@gfpCreatShrSpace = nil) or (@gfpGetShrSpace = nil) or
            (@gfpCopyShrSpace = nil) or (@gfpDelShrSpace = nil) or
            (@gfpSetShrFilter = nil) or(@gfpInsShrRec = nil) or
            (@gfpGetShrRec = nil) or (@gfpDelShrRec = nil) or
            (@gfpHideShrRec = nil) or (@gfpUndoShrRec = nil) or
            (@gfpGetHideShrRecCnt = nil) or (@gfpAddShrRec = nil) or
            (@gfpUpdtShrRec = nil) or (@gfpQueryCurShrRec = nil) or
            (@gfpDelAllShrRec = nil) or (@gfpGetShrRecCnt = nil) then begin

           raise EShrSpaceException.Create(ctHRSCCTL_DLL + 'のバージョンが正しくありません');

         end else if (@gfpMarkShrRec = nil) or (@gfpFirstShrRec = nil) or
            (@gfpPrevShrRec= nil) or (@gfpNextShrRec = nil) or
            (@gfpLastShrRec = nil) or (@gfpGoShrRow = nil) or
            (@gfpQueryCurShrRow = nil) or (@gfpMoveShrRec = nil) or
            (@gfpCopyShrRec = nil) or (@gfpSetSrchKey = nil) or
            (@gfpSrchKeyRec = nil) then begin

           raise EShrSpaceException.Create(ctHRSCCTL_DLL + 'のバージョンが正しくありません');

         end;
       end;
     end;
end;

//**********************************************************************//
// Module Name     :  共有空間操作クラス 破棄                           //
//                 :  THRscCtl.Destroy                                //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
destructor THRscCtl.Destroy;
begin
     // UNDOﾊﾞｯﾌｧを全削除
     DelAllUndoBuff;
     mUndoList.Free;

     inherited Destroy;
end;

//**********************************************************************//
// Module Name     :  共有空間生成                                      //
//                 :  THRscCtl.CreatSpace                             //
// 引数            :  1 stSetShrInf   生成パラメータ                    //
// 戻り値          :  1 Smallint       　0:正常生成                     //
//                                       1:指定領域有り                 //
//                                       3:共有空間ID空き無し           //
//                                       5:リソースに空き無し           //
//                                       9:パラメータ設定ミス           //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.14                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.CreatShrSpace(var stSetShrInf: tagSetShrSpaceInf): Smallint;
begin
     // 共有空間生成処理
//     if mhDllInst = 0           then Result := -98 else                       2000.10.04 削除
//     if @gfpCreatShrSpace = nil then Result := -99 else

     Result := gfpCreatShrSpace(stSetShrInf);

     if Result = 0 then begin
       mbInfoGet := True;
       with stSetShrInf do begin                                                // 2000.10.04 変更
         mnRscId       := lRscId;                         // ﾘｿｰｽID
         mnLockShrMode := nLockShrMode;                   // ﾛｯｸﾓｰﾄﾞ
         mnLockHnd     := lLockHandle;                    // ﾛｯｸﾊﾝﾄﾞﾙ
         mnRecNoType   := nRecNoType;                     // ﾚｺｰﾄﾞ発番ﾀｲﾌﾟ
         mnBuffType    := nBuffType;                      // ﾊﾞｯﾌｧﾀｲﾌﾟ
         BuffLen       := lBuffLen;                       // ﾊﾞｯﾌｧ長
       end;
     end;
end;

//**********************************************************************//
// Module Name     :  共有空間破棄                                      //
//                 :  THRscCtl.DelShrSpace                            //
// 引数            :  --                                                //
// 戻り値          :  1 Smallint          0:正常終了                    //
//                                        1:指定共有空間ID無し          //
//                                        5:ﾚｺｰﾄﾞ削除失敗               //
//                                       85:共有空間ロック中            //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.DelShrSpace: Smallint;
begin
     // 共有空間破棄
     Result := DelShrSpaceSub(RscId, LockHandle);
     if Result = 0 then begin
        DelAllUndoBuff;
        mbInfoGet := False;
        mnRscId := 0;
        mnLockShrMode := 0;                                          // ﾛｯｸﾓｰﾄﾞ
        mnLockHnd     := 0;                                          // ﾛｯｸﾊﾝﾄﾞﾙ
        mnRecNoType   := 0;                                          // ﾚｺｰﾄﾞ発番ﾀｲﾌﾟ
        mnBuffType    := 0;                                          // ﾊﾞｯﾌｧﾀｲﾌﾟ
        BuffLen       := 0;                                          // ﾊﾞｯﾌｧ長
     end;
end;

//**********************************************************************//
// Module Name     :  共有空間操作クラス 共有空間コピー                 //
//                 :  THRscCtl.CopySpace                              //
// 引数            :  1 DstSpace        コピーされる共有空間ｵﾌﾞｼﾞｪｸﾄ    //
// 戻り値          :  1 Integer             0:正常コピー                //
//                                          1:指定共有空間ID無し        //
//                                          5:リソースに空き無し        //
//                                          9:レコードバッファNULL      //
//                                         85:共有空間排他ロック中      //
//                                         -1:作成時指定領域有り        //
//                                         -3:作成時共有空間ID空き無し  //
//                                         -5:作成時リソースに空き無し  //
//                                         -9:パラメータ設定ミス        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.15                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.CopyShrSpace(var DstSpace: THRscCtl; nLockMode, nOperand: Smallint): Integer;
var
   nRscId          : Longint;
   nLockHandle     : Longint;
begin
     nRscId      := DstSpace.RscId ;
     nLockHandle := DstSpace.LockHandle;
     Result      := CopySpaceSub(nRscId, nLockHandle,
                            nLockMode,
                            Self.RscId ,Self.LockHandle, nOperand);
     if Result = 0 then begin
        DstSpace.mnRscId    := 0;
        DstSpace.RscId      := nRscId;
        DstSpace.LockHandle := nLockHandle;
     end;
end;

//**********************************************************************//
// Module Name     :  検索キー設定（個別設定）                          //
//                 :  THRscCtl.SetSrchKey                             //
// 引数            :  1 nSortNo          キー番号                        //
//                    2 stSrchKey       検索キー構造体                  //
// 戻り値          :  1 Integer         0:正常終了                      //
//                                      1:指定共有空間ID無し            //
//                                     20:キー番号間違い                //
//                                     21:ｷｰﾊﾞｯﾌｧNULL                   //
//                                     85:共有空間ロックエラー          //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.SetSrchKey(nSortNo: Smallint; var stSrchKey: tagSrchKey): Integer;
var
   stShrInf        : tagShrSpaceInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpSetSrchKey = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := RscId;                                // リソースID
       stShrInf.lLockHandle := LockHandle;                           // ﾛｯｸﾊﾝﾄﾞﾙ
       stShrInf.nSortNo     := nSortNo;
       // 検索キー設定
       Result := gfpSetSrchKey(stShrInf, stSrchKey);
//     end;
end;

//**********************************************************************//
// Module Name     :  共有空間情報取得                                  //
//                 :  THRscCtl.GetShrInfo                             //
// 引数            :  1 stGetShrInf      共有空間情報構造体             //
// 戻り値          :  1 Integer          0:成功 1:指定共有空間ID無し    //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.GetShrInfo(nRscId: Longint; var stGetShrInf: tagGetShrSpaceInf): Integer;
begin
//     if mhDllInst = 0         then Result := -98 else                         2000.10.04 削除
//     if @gfpGetShrSpace = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stGetShrInf, SizeOf(stGetShrInf), 0);
       stGetShrInf.lRscId := nRscId;
       // 共有空間情報取得
       Result := gfpGetShrSpace(stGetShrInf);
//     end;
end;

//**********************************************************************//
// Module Name     :  リソースＩＤ設定                                  //
//                 :  THRscCtl.SetRscId                               //
// 引数            :  1 nRscId           設定するリソースＩＤ           //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THRscCtl.SetRscId(nRscId: Longint);
var
   stGetShrInf     : tagGetShrSpaceInf;
   st              : Integer;
begin
     if mnRscId = nRscId then Exit;

     if csDesigning in ComponentState then
     begin
       mnRscId := nRscId;
     end else
     begin
       // 現在のﾘｿｰｽ状況取得
       st := GetShrInfo(nRscId, stGetShrInf);
       if st = 0 then
       begin
         mbInfoGet := True;

         mnRscId := stGetShrInf.lRscId;                               // ﾘｿｰｽID
         mnLockShrMode := stGetShrInf.nLockShrMode;                   // ﾛｯｸﾓｰﾄﾞ
         mnLockHnd     := 0;                                          // ﾛｯｸﾊﾝﾄﾞﾙ
         mnRecNoType   := stGetShrInf.nRecNoType;                     // ﾚｺｰﾄﾞ発番ﾀｲﾌﾟ
         mnBuffType    := stGetShrInf.nBuffType;                      // ﾊﾞｯﾌｧﾀｲﾌﾟ
         if mnBuffType = BUFFTYPE_FIX then                            // 固定長の場合
           BuffLen    := stGetShrInf.lBuffLen;                       // ﾊﾞｯﾌｧ長
       end else
       begin
         mnRscId := nRscId;
         // リソースID変更前は、共有空間有りだった？
         if mbInfoGet = True then
         begin
           mnLockShrMode := 0;
           mnRecNoType   := 0;
           mnBuffType    := 0;
           BuffLen       := 0;

           mbInfoGet := False;
         end;
       end;
     end;
end;

//**********************************************************************//
// Module Name     :  カレント行設定                                    //
//                 :  THRscCtl.SetRow                                 //
// 引数            :cc   1 nRowno   設定する行番号                         //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.12                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
procedure THRscCtl.SetRow(nRowno: Longint);
var
   stShrInf        : tagShrSpaceInf;
   st              : Integer;
begin
//     if mhDllInst = 0      then st := -98 else                                2000.10.04 削除
//     if @gfpGoShrRow = nil then st := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;                              // リソースID
       stShrInf.lLockHandle := mnLockHnd;                            // ﾛｯｸﾊﾝﾄﾞﾙ
       stShrInf.nSortNo     := SortNo;                                // ｿｰﾄｷｰNo
       // カレント行変更
       st := gfpGoShrRow(stShrInf, nRowno);
//     end;
     case st of
//      -1: ShowMessageFmt('%s指定共有空間ID無し st=%d',   [ctErrSetRow, st]);
        -5: ShowMessageFmt('%s対象レコード無し st=%d',     [ctErrSetRow, st]);
       -20: ShowMessageFmt('%sキー番号間違い st=%d',       [ctErrSetRow, st]);
       -85: ShowMessageFmt('%s共有空間ロックエラー st=%d', [ctErrSetRow, st]);
       -98: ShowMessageFmt('%sDLLのロード失敗 st=%d',      [ctErrSetRow, st]);
       -99: ShowMessageFmt('%s関数のロード失敗 st=%d',     [ctErrSetRow, st]);
     else
         if (st < 0) And (st <> -1) then
            ShowMessageFmt('%sその他のエラー st=%d',       [ctErrSetRow, st]);
     end;
end;

//**********************************************************************//
// Module Name     :  現在カレント行の取得                              //
//                 :  THRscCtl.GetRow                                 //
// 引数            :  --                                                //
// 戻り値          :  1 Longint    カレント行位置                       //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.12                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.GetRow: Longint;
var
   stShrInf        : tagShrSpaceInf;
   st              : Longint;
begin
//     if mhDllInst = 0 then st := -98 else                                     2000.10.04 削除
//     if @gfpQueryCurShrRow = nil then st := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;                                // リソースID
       stShrInf.lLockHandle := mnLockHnd;                              // ﾛｯｸﾊﾝﾄﾞﾙ
       stShrInf.nSortNo     := SortNo;                                  // ｿｰﾄｷｰNo
       // カレント行取得
       st := gfpQueryCurShrRow(stShrInf);
//     end;
     case st of
//      -1: ShowMessageFmt('%s指定共有空間ID無し st=%d',           [ctErrGetRow, st]);
        -3: ShowMessageFmt('%sフィルターによりレコード無効 st=%d', [ctErrGetRow, st]);
        -4: ShowMessageFmt('%s論理削除によりレコード無効 st=%d',   [ctErrGetRow, st]);
       -20: ShowMessageFmt('%sキー番号間違い st=%d',               [ctErrGetRow, st]);
       -85: ShowMessageFmt('%s共有空間ロックエラー st=%d',         [ctErrGetRow, st]);
       -98: ShowMessageFmt('%sDLLのロード失敗 st=%d',              [ctErrGetRow, st]);
       -99: ShowMessageFmt('%s関数のロード失敗 st=%d',             [ctErrGetRow, st]);
     else
         if (st < 0) And (st <> -1) then
            ShowMessageFmt('%sその他のエラー st=%d',               [ctErrGetRow, st]);
     end;
     if st >= 0 then Result := st
                else Result := 0;
end;

//**********************************************************************//
// Module Name     :  現在カレントレコード番号の取得                    //
//                 :  THRscCtl.GetRecNo                               //
// 引数            :  --                                                //
// 戻り値          :  1 Longint    カレントレコード番号                 //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.12                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.GetRecNo: Longint;
var
   stShrInf        : tagShrSpaceInf;
   st              : Longint;
begin
//     if mhDllInst = 0            then st := -98 else                          2000.10.04 削除
//     if @gfpQueryCurShrRec = nil then st := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;                                // リソースID
       stShrInf.lLockHandle := mnLockHnd;                              // ﾛｯｸﾊﾝﾄﾞﾙ
       // カレントレコード番号取得
       st := gfpQueryCurShrRec(stShrInf);
//     end;

     case st of
//      -1: ShowMessageFmt('%s指定共有空間ID無し st=%d',           [ctErrGetRecNo, st]);
        -3: ShowMessageFmt('%sフィルターによりレコード無効 st=%d', [ctErrGetRecNo, st]);
        -4: ShowMessageFmt('%s論理削除によりレコード無効 st=%d',   [ctErrGetRecNo, st]);
        -5: ShowMessageFmt('%s対象レコード無し st=%d',             [ctErrGetRecNo, st]);
       -85: ShowMessageFmt('%s共有空間ロックエラー st=%d',         [ctErrGetRecNo, st]);
       -98: ShowMessageFmt('%sDLLのロード失敗 st=%d',              [ctErrGetRecNo, st]);
       -99: ShowMessageFmt('%s関数のロード失敗 st=%d',             [ctErrGetRecNo, st]);
     else
         if (st < 0) And (st <> -1) then
            ShowMessageFmt('%sその他のエラー st=%d',               [ctErrGetRecNo, st]);
     end;
     if st >= 0 then Result := st
                else Result := 0;
end;

//**********************************************************************//
// Module Name     :  レコード件数取得                                  //
//                 :  THRscCtl.GetRecCnt                              //
// 引数            :  --                                                //
// 戻り値          :  1 Integer         0~:レコード件数                 //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.GetRecCnt: Longint;
var
   stShrInf        : tagShrSpaceInf;
   st              : Longint;
begin
//     if mhDllInst = 0          then st := -98 else                            2000.10.04 削除
//     if @gfpGetShrRecCnt = nil then st := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;                                // リソースID
       stShrInf.lLockHandle := mnLockHnd;                              // ﾛｯｸﾊﾝﾄﾞﾙ
       // レコード件数取得
       st := gfpGetShrRecCnt(stShrInf);
//     end;
     case st of
//      -1: ShowMessageFmt('%s指定共有空間ID無し st=%d',   [ctErrGetRecCnt, st]);
       -85: ShowMessageFmt('%s共有空間ロックエラー st=%d', [ctErrGetRecCnt, st]);
       -98: ShowMessageFmt('%sDLLのロード失敗 st=%d',      [ctErrGetRecCnt, st]);
       -99: ShowMessageFmt('%s関数のロード失敗 st=%d',     [ctErrGetRecCnt, st]);
     else
         if (st < 0) And (st <> -1) then
            ShowMessageFmt('%sその他のエラー st=%d',       [ctErrGetRecCnt, st]);
     end;
     if st >= 0 then Result := st
                else Result := 0;
end;

//**********************************************************************//
// Module Name     :  論理削除レコード件数取得                          //
//                 :  THRscCtl.GetHideShrRecCnt                       //
// 引数            :  1 Longint          1~:論理削除番号                //
// 戻り値          :  1 Integer          0~:レコード件数                //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function  THRscCtl.GetHideShrRecCnt(nUndoNo: Longint): Longint;
var
   stShrInf        : tagShrSpaceInf;
   st              : Integer;
begin
//     if mhDllInst = 0              then st := -98 else                        2000.10.04 削除
//     if @gfpGetHideShrRecCnt = nil then st := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;                                // リソースID
       stShrInf.lLockHandle := mnLockHnd;                              // ﾛｯｸﾊﾝﾄﾞﾙ
       // 論理削除数取得実行
       st := gfpGetHideShrRecCnt(stShrInf, nUndoNo);
//     end;
     case st of
//      -1: ShowMessageFmt('%s指定共有空間ID無し st=%d',       [ctErrGetRecCnt, st]);
        -7: ShowMessageFmt('%s最大UNDO番号に達している st=%d', [ctErrGetRecCnt, st]);
       -85: ShowMessageFmt('%s共有空間ロックエラー st=%d',     [ctErrGetRecCnt, st]);
       -98: ShowMessageFmt('%sDLLのロード失敗 st=%d',          [ctErrGetRecCnt, st]);
       -99: ShowMessageFmt('%s関数のロード失敗 st=%d',         [ctErrGetRecCnt, st]);
     else
         if (st < 0) And (st <> -1) then
            ShowMessageFmt('%sその他のエラー st=%d',           [ctErrGetRecCnt, st]);
     end;
     if st >= 0 then Result := st
                else Result := 0;
end;

//**********************************************************************//
// Module Name     :  フィールド指定レコード検索                        //
//                 :  THRscCtl.SrchKeyRec                             //
// 引数            :  1 nSrchType        SRCH_FST  :  1 先頭検索        //
//                                       SRCH_NXT  :  2 次行検索        //
//                                       SRCH_PRV  :  4 前行検索        //
//                                       SRCH_LAST :  8 最終行検索      //
//                                       SRCH_EQUAL: 16 イコール検索    //
//                                       SRCH_GT   : 32 より大検索      //
//                                       SRCH_GTEQ : 64 以上検索        //
//                                       SRCH_LT   :128 より小検索      //
//                                       SRCH_LTEQ :256 以下検索        //
//                    2 pKeyBuff         キーバッファ                   //
//                    3 nOperand         追加オプション                 //
//                               OPRND_GET_DEL_FORCE     論理削除無視   //
//                               OPRND_GET_FILTER_FORCE  フィルター無視 //
//                               OPRND_NO_MOVE           現在行の移動無 //
//                    4 nRecNo           検索で見つかったレコードの     //
//                                       レコードNo                     //
// 戻り値          :  1 Integer          0:正常終了                     //
//                                       1:指定共有空間ID無し           //
//                                       5:対象レコード無し             //
//                                       7:検索方法違い                 //
//                                      20:キー番号間違い               //
//                                      21:キーバッファNULL             //
//                                      85:共有空間ロックエラー         //
//                                      99:その他エラー                 //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.14                                        //
//----------------------------------------------------------------------//
// Note                                                                 //
//     指定された検索ﾀｲﾌﾟ及びキーで検索します。                         //
//     (キー番号は、SortNoプロパティに設定してください)                 //
//     オペランドにより、論理削除も含めるか・フィルターを無視するか等が //
//     指定できます。                                                   //
//     検索結果が正常であれば、該当レコード番号が設定されます           //
//     該当レコードイメージは、DatBuffプロパティに設定されます。        //
//----------------------------------------------------------------------//
// Update Note     : 2000.07.05 鹿野　幸生                              //
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.SrchKeyRec(nSrchType: Smallint; pKeyBuff: Pointer; nOperand: Smallint; var nRecNo: Longint): Integer;
var
   stRecInf        : tagRecInf;
begin
//     nRecNo := 0;                                           2000.07.05 変更

//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpSrchKeyRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stRecInf, SizeOf(stRecInf), 0);
       with stRecInf do begin                                                   // 2000.10.04 変更
         lRscId      := RscId;
         lLockHandle := LockHandle;
         lBuffLen    := BuffLen;
         pBuff       := DatBuff;
//       stRecInf.lDtlNo      := RecNo;                       2000.07.05 変更
         lDtlNo      := nRecNo;
       end;
       stRecInf.nOperand    := nOperand;

       // キー設定実行
       Result := gfpSrchKeyRec(stRecInf, nSrchType, SortNo, pKeyBuff);
//     end;

     if Result = 0 then begin
        Mark    := stRecInf.nFlgMark;
        BuffLen := stRecInf.lBuffLen;
        nRecNo  := stRecInf.lDtlNo;
     end;
end;

//**********************************************************************//
// Module Name     :  レコードイメージ取得                              //
//                 :  THRscCtl.GetRec                                 //
// 引数            :  1 nRecNo           レコード番号                   //
//                    2 nOperand         追加オプション                 //
//                               OPRND_GET_DEL_FORCE     論理削除無視   //
//                               OPRND_GET_FILTER_FORCE  フィルター無視 //
//                               OPRND_NO_MOVE           現在行の移動無 //
// 戻り値          :  1 Integer          0:正常終了                     //
//                                       1:指定共有空間ID無し           //
//                                       3:フィルターによりレコード無効 //
//                                       4:論理削除によりレコード無効   //
//                                       5:指定レコード無し             //
//                                       9:レコードバッファNULL         //
//                                      85:共有空間ロックエラー         //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.GetShrRec(nRecNo: Longint; nOperand: Smallint): Integer;
var
   stRecInf        : tagRecInf;
begin
//     if mhDllInst = 0       then Result := -98 else                           2000.10.04 削除
//     if @gfpGetShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stRecInf, SizeOf(stRecInf), 0);
       with stRecInf do begin                                                   // 2000.10.04 変更
         lRscId      := RscId;
         lLockHandle := LockHandle;
         lBuffLen    := BuffLen;
         pBuff       := DatBuff;
         lDtlNo      := nRecNo;
         nFlgMark    := Mark;
       end;
       stRecInf.nOperand    := nOperand;
       // レコード取得実行
       Result := gfpGetShrRec(stRecInf);
//     end;

     if Result = 0 then begin
        Mark    := stRecInf.nFlgMark;
        BuffLen := stRecInf.lBuffLen;
     end;
end;

//**********************************************************************//
// Module Name     :  レコードイメージ追加（最終行へ）                  //
//                 :  THRscCtl.AddRec                                 //
// 引数            :  1 nRecNo           レコード番号                   //
// 戻り値          :  1 Integer           0:正常終了                    //
//                                        1:指定共有空間ID無し          //
//                                        3:指定レコード有り            //
//                                        4:レコード番号に空き無し      //
//                                        5:ﾘｿｰｽに空き無し              //
//                                        9:レコードバッファNULL        //
//                                       85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.AddShrRec(var nRecNo: Longint): Integer;
var
   stRecInf        : tagRecInf;
begin
//     if mhDllInst = 0       then Result := -98 else                           2000.10.04 削除
//     if @gfpAddShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stRecInf, SizeOf(stRecInf), 0);
       with stRecInf do begin                                                   // 2000.10.04 変更
         lRscId      := RscId;
         lLockHandle := LockHandle;
         lBuffLen    := BuffLen;
         pBuff       := DatBuff;
         lDtlNo      := nRecNo;
         nFlgMark    := Mark;
       end;
//       stRecInf.nOperand    := nOperand;
       // 追加実行
       Result := gfpAddShrRec(stRecInf);
//     end;

     if Result = 0 then nRecNo := stRecInf.lDtlNo
                   else nRecNo := 0;
end;

//**********************************************************************//
// Module Name     :  レコードイメージ挿入                              //
//                 :  THRscCtl.InsRec                                 //
// 引数            :  1 nRecNo           レコード番号                   //
//                    2 nOperand         追加オペランド                 //
//                               OPRND_PREV_INSERT       前行に挿入     //
// 戻り値          :  1 Integer           0:正常終了                    //
//                                        1:指定共有空間ID無し          //
//                                        3:指定レコード有り            //
//                                        4:レコード番号に空き無し      //
//                                        5:ﾘｿｰｽに空き無し              //
//                                        9:レコードバッファNULL        //
//                                       85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.InsShrRec(var nRecNo: Longint; nOperand: Smallint): Integer;
var
   stRecInf        : tagRecInf;
begin
//     if mhDllInst = 0       then Result := -98 else                           2000.10.04 削除
//     if @gfpInsShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stRecInf, SizeOf(stRecInf), 0);
       with stRecInf do begin                                                   // 2000.10.04 変更
         lRscId      := RscId;
         lLockHandle := LockHandle;
         lBuffLen    := BuffLen;
         pBuff       := DatBuff;
         lDtlNo      := nRecNo;
         nFlgMark    := Mark;
       end;
       stRecInf.nOperand    := nOperand;
       // 挿入実行
       Result := gfpInsShrRec(stRecInf);
//     end;

     if Result = 0 then nRecNo := stRecInf.lDtlNo
                   else nRecNo := 0;
end;

//**********************************************************************//
// Module Name     :  レコードイメージ更新                              //
//                 :  THRscCtl.UpdtRec                                //
// 引数            :  1 nRecNo           レコード番号                   //
//                    2 nOperand         追加オペランド                 //
//                               OPRND_NO_MOVE           現在行移動無し //
// 戻り値          :  1 Integer           0:正常終了                    //
//                                        1:指定共有空間ID無し          //
//                                        3:指定レコード有り            //
//                                        4:レコード番号に空き無し      //
//                                        5:ﾘｿｰｽに空き無し              //
//                                        9:レコードバッファNULL        //
//                                       85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.UpdtShrRec(var nRecNo: Longint; nOperand: Smallint): Integer;
var
   stRecInf        : tagRecInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpUpdtShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stRecInf, SizeOf(stRecInf), 0);
       with stRecInf do begin                                                   // 2000.10.04 変更
         lRscId      := RscId;
         lLockHandle := LockHandle;
         lBuffLen    := BuffLen;
         pBuff       := DatBuff;
         lDtlNo      := nRecNo;
         nFlgMark    := Mark;
       end;
       stRecInf.nOperand    := nOperand;
       // 更新実行
       Result := gfpUpdtShrRec(stRecInf);
//     end;

     if Result = 0 then nRecNo := stRecInf.lDtlNo
                   else nRecNo := 0;
end;

//**********************************************************************//
// Module Name     :  レコードイメージマーキング更新                    //
//                 :  THRscCtl.UpdtMark                               //
// 引数            :  1 nRecNo           レコード番号                   //
// 戻り値          :  1 Integer           0:正常終了                    //
//                                        1:指定共有空間ID無し          //
//                                        3:指定レコード有り            //
//                                        4:レコード番号に空き無し      //
//                                        5:ﾘｿｰｽに空き無し              //
//                                        9:レコードバッファNULL        //
//                                       85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.MarkShrRec(var nRecNo: Longint): Integer;
var
   stRecInf        : tagRecInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpMarkShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stRecInf, SizeOf(stRecInf), 0);
       with stRecInf do begin                                                   // 2000.10.04 変更
         lRscId      := RscId;
         lLockHandle := LockHandle;
         lDtlNo      := nRecNo;
         nFlgMark    := Mark;
       end;
//       stRecInf.nOperand    := nOperand;
       // マーキング実行
       Result := gfpMarkShrRec(stRecInf);
//     end;

     if Result = 0 then nRecNo := stRecInf.lDtlNo
                   else nRecNo := 0;
end;

//**********************************************************************//
// Module Name     :  レコードイメージ削除（物理削除）                  //
//                 :  THRscCtl.DelRec                                 //
// 引数            :  1 nRecNo           レコード番号                   //
// 戻り値          :  1 Integer           0:正常終了                    //
//                                        1:指定共有空間ID無し          //
//                                        3:指定レコード有り            //
//                                        5:ﾘｿｰｽに空き無し              //
//                                       85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.DelShrRec(var nRecNo: Longint): Integer;
var
   stRecInf        : tagRecInf;
begin
//     if mhDllInst = 0       then Result := -98 else                           2000.10.04 削除
//     if @gfpDelShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stRecInf, SizeOf(stRecInf), 0);
       with stRecInf do begin                                                   // 2000.10.04 変更
         lRscId      := RscId;
         lLockHandle := LockHandle;
         lDtlNo      := nRecNo;
       end;
//       stRecInf.nOperand    := nOperand;
       // 物理削除実行
       Result := gfpDelShrRec(stRecInf);
//     end;

     if Result = 0 then nRecNo := stRecInf.lDtlNo
                   else nRecNo := 0;
end;

//**********************************************************************//
// Module Name     :  レコードイメージ全物理削除                        //
//                 :  THRscCtl.DelAllShrRec                              //
// 引数            :  --                                                //
// 戻り値          :  1 Integer           0:正常終了                    //
//                                        1:指定共有空間ID無し          //
//                                       85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.14                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.DelAllShrRec: Integer;
begin
     // 全削除実行
     Result := DelAllShrRecSub(RscId, LockHandle);
end;

//**********************************************************************//
// Module Name     :  レコードイメージ削除（論理削除）                  //
//                 :  THRscCtl.HideShrRec                                //
// 引数            :  1 nRecNo           レコード番号                   //
// 戻り値          :  1 Integer           0:正常終了                    //
//                                        1:指定共有空間ID無し          //
//                                        3:指定レコード有り            //
//                                        4:論理削除によりﾚｺｰﾄﾞ無効     //
//                                        5:ﾘｿｰｽに空き無し              //
//                                        7:最大UNDO番号に達している    //
//                                       85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.HideShrRec(var nRecNo: Longint): Integer;
var
   stRecInf        : tagRecInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpHideShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stRecInf, SizeOf(stRecInf), 0);
       with stRecInf do begin
         lRscId      := RscId;
         lLockHandle := LockHandle;
         lDtlNo      := nRecNo;
       end;
//       stRecInf.nOperand    := nOperand;
       // 論理削除実行
       Result := gfpHideShrRec(stRecInf);
//     end;

     if Result = 0 then nRecNo := stRecInf.lDtlNo
                   else nRecNo := 0;
end;

//**********************************************************************//
// Module Name     :  レコードイメージ論理削除復活                      //
//                 :  THRscCtl.UndoShrRec                             //
// 引数            :  1 nUndoNo      復活するUNDO番号                   //
// 戻り値          :  1 Integer           0~:復活した件数               //
//                                        -1:指定共有空間無し           //
//                                        -5:UNDO番号無効               //
//                                       -85:共有空間ロック中           //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.UndoShrRec(nUndoNo: Longint): Integer;
var
   stShrInf        : tagShrSpaceInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpUndoShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId := RscId;
       stShrInf.lLockHandle := LockHandle;

       // UNDO実行
       Result := gfpUndoShrRec(stShrInf, nUndoNo);
//     end;
end;

//**********************************************************************//
// Module Name     :  レコードイメージ移動                              //
//                 :  THRscCtl.MoveShrRec                                //
// 引数            :  1 DstSpace           移動先共有空間               //
//                    2 nDstRecNo          移動先レコードNo             //
//                    3 nSrcRecNo          移動元レコードNo             //
//                    4 nOperand           追加オペランド               //
//                               OPRND_OVERRIDE          上書き         //
//                               OPRND_PREV_INSERT       前行に挿入     //
//                               OPRND_GET_DEL_FORCE     論理削除無視   //
//                               OPRND_GET_FILTER_FORCE  フィルター無視 //
// 戻り値          :  1 Integer            0:正常終了                   //
//                                         1:指定共有空間ID無し         //
//                                         3:ﾌｨﾙﾀｰによりﾚｺｰﾄﾞ無効       //
//                                         4:論理削除によりﾚｺｰﾄﾞ無効    //
//                                         5:指定ﾚｺｰﾄﾞ番号無し          //
//                                         7:バッファ長違い             //
//                                         8:ﾚｺｰﾄﾞ番号発番失敗          //
//                                         9:パラメータ設定ミス         //
//                                        85:共有空間ロックエラー       //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.15                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.MoveShrRec(var DstSpace : THRscCtl;
                               nDstRecNo,
                               nSrcRecNo: Longint  ;
                               nOperand : Smallint ): Integer;
var
   stSrcRecInf,
   stDstRecInf     : tagRecInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpMoveShrRec = nil then Result := -99 else
//     begin
       // 移動元 レコード情報設定
       FillChar(stSrcRecInf, SizeOf(stSrcRecInf), 0);
       with stSrcRecInf do begin                                                // 2000.10.04 変更
         lRscId      := Self.RscId;
         lLockHandle := Self.LockHandle;
         lBuffLen    := Self.BuffLen;
         lDtlNo      := nSrcRecNo;
       end;
       stSrcRecInf.nOperand    := nOperand;

       // 移動先 レコード情報設定
       FillChar(stDstRecInf, SizeOf(stDstRecInf), 0);
       with stDstRecInf do begin
         lRscId      := DstSpace.RscId;                                         // 2000.10.04 変更
         lLockHandle := DstSpace.LockHandle;
         lBuffLen    := DstSpace.BuffLen;
         lDtlNo      := nDstRecNo;
       end;
       stDstRecInf.nOperand    := nOperand;

       // 移動実行
       Result := gfpMoveShrRec(stDstRecInf, stSrcRecInf);
//     end;
end;

//**********************************************************************//
// Module Name     :  レコードイメージコピー                            //
//                 :  THRscCtl.CopyShrRec                             //
// 引数            :  1 DstSpace           コピー先共有空間             //
//                    2 nDstRecNo          コピー先レコードNo           //
//                    3 nSrcRecNo          コピー元レコードNo           //
//                    4 nOperand           追加オペランド               //
//                               OPRND_OVERRIDE          上書き         //
//                               OPRND_PREV_INSERT       前行に挿入     //
//                               OPRND_GET_DEL_FORCE     論理削除無視   //
//                               OPRND_GET_FILTER_FORCE  フィルター無視 //
// 戻り値          :  1 Integer            0:正常終了                   //
//                                         1:指定共有空間ID無し         //
//                                         3:ﾌｨﾙﾀｰによりﾚｺｰﾄﾞ無効       //
//                                         4:論理削除によりﾚｺｰﾄﾞ無効    //
//                                         5:指定ﾚｺｰﾄﾞ番号無し          //
//                                         7:バッファ長違い             //
//                                         8:ﾚｺｰﾄﾞ番号発番失敗          //
//                                         9:パラメータ設定ミス         //
//                                        13:挿入時指定ﾚｺｰﾄﾞ番号有り    //
//                                        14:ﾚｺｰﾄﾞ番号に空き無し        //
//                                        15:リソースに空き無し         //
//                                        19:レコードバッファNULL       //
//                                        85:共有空間ロックエラー       //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.15                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.CopyShrRec(var DstSpace : THRscCtl;
                               nDstRecNo,
                               nSrcRecNo: Longint  ;
                               nOperand : Smallint ): Integer;
var
   stSrcRecInf,
   stDstRecInf     : tagRecInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpCopyShrRec = nil then Result := -99 else
//     begin
       // コピー元 レコード情報設定
       FillChar(stSrcRecInf, SizeOf(stSrcRecInf), 0);
       with stSrcRecInf do begin
         lRscId      := Self.RscId;
         lLockHandle := Self.LockHandle;
         lBuffLen    := Self.BuffLen;
         lDtlNo      := nSrcRecNo;
       end;
       stSrcRecInf.nOperand    := nOperand;

       // コピー先 レコード情報設定
       FillChar(stDstRecInf, SizeOf(stDstRecInf), 0);
       with stDstRecInf do begin
         lRscId      := DstSpace.RscId;
         lLockHandle := DstSpace.LockHandle;
         lBuffLen    := DstSpace.BuffLen;
         lDtlNo      := nDstRecNo;
       end;
       stSrcRecInf.nOperand    := nOperand;

       // コピー実行
       Result := gfpCopyShrRec(stDstRecInf, stSrcRecInf);
//     end;
end;

//**********************************************************************//
// Module Name     :  先頭行にカレント行を移動                          //
//                 :  THRscCtl.FirstShrRec                                  //
// 引数            :  --                                                //
// 戻り値          :  1 Longint          0~:移動したレコード番号        //
//                                       -1:指定共有空間ID無し          //
//                                       -5:対象レコード無し            //
//                                      -20:キー番号間違い              //
//                                      -85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.12                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.FirstShrRec: Integer;
var
   stShrInf        : tagShrSpaceInf;
begin
//     if mhDllInst = 0         then Result := -98 else                         2000.10.04 削除
//     if @gfpFirstShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;
       stShrInf.lLockHandle := mnLockHnd;
       stShrInf.nSortNo     := SortNo;
       // カレント行移動
       Result := gfpFirstShrRec(stShrInf);
//     end;
end;

//**********************************************************************//
// Module Name     :  前行にカレント行を移動                            //
//                 :  THRscCtl.PrevShrRec                                   //
// 引数            :  --                                                //
// 戻り値          :  1 Longint          0~:移動したレコード番号        //
//                                       -1:指定共有空間ID無し          //
//                                       -5:対象レコード無し            //
//                                      -20:キー番号間違い              //
//                                      -85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.12                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.PrevShrRec: Integer;
var
   stShrInf        : tagShrSpaceInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpPrevShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;
       stShrInf.lLockHandle := mnLockHnd;
       stShrInf.nSortNo     := SortNo;
       // カレント行移動
       Result := gfpPrevShrRec(stShrInf);
//     end;
end;

//**********************************************************************//
// Module Name     :  次行にカレント行を移動                            //
//                 :  THRscCtl.NextShrRec                                   //
// 引数            :  --                                                //
// 戻り値          :  1 Longint          0~:移動したレコード番号        //
//                                       -1:指定共有空間ID無し          //
//                                       -5:対象レコード無し            //
//                                      -20:キー番号間違い              //
//                                      -85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.12                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.NextShrRec: Integer;
var
   stShrInf        : tagShrSpaceInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpNextShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;
       stShrInf.lLockHandle := mnLockHnd;
       stShrInf.nSortNo     := SortNo;
       // カレント行移動
       Result := gfpNextShrRec(stShrInf);
//     end;
end;

//**********************************************************************//
// Module Name     :  最終行にカレント行を移動                          //
//                 :  THRscCtl.LastShrRec                                   //
// 引数            :  --                                                //
// 戻り値          :  1 Longint          0~:移動したレコード番号        //
//                                       -1:指定共有空間ID無し          //
//                                       -5:対象レコード無し            //
//                                      -20:キー番号間違い              //
//                                      -85:共有空間ロックエラー        //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.12                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.LastShrRec: Integer;
var
   stShrInf        : tagShrSpaceInf;
begin
//     if mhDllInst = 0        then Result := -98 else                          2000.10.04 削除
//     if @gfpLastShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;
       stShrInf.lLockHandle := mnLockHnd;
       stShrInf.nSortNo     := SortNo;
       // カレント行移動
       Result := gfpLastShrRec(stShrInf);
//     end;
end;

//**********************************************************************//
// Module Name     :  フィルターの設定                                  //
//                 :  THRscCtl.SetFilter                              //
// 引数            :  1 nFilter        0:無し                           //
//                                    -1:ﾏｰｷﾝｸﾞ行無効                   //
//                                    1~:指定番号のﾏｰｷﾝｸﾞ行のみ         //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.12                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
procedure THRscCtl.SetFilter(nFilter: Smallint);
const
   ctErrSetFilter= 'フィルター設定エラー'#13;
var
   stShrInf        : tagShrSpaceInf;
   st              : Integer;
begin
//     if mhDllInst = 0          then st := -98 else                            2000.10.04 削除
//     if @gfpSetShrFilter = nil then st := -99 else
//     begin
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := mnRscId;
       stShrInf.lLockHandle := mnLockHnd;
       st := gfpSetShrFilter(stShrInf, nFilter);
//     end;

     case st of
//       1: ShowMessageFmt('%s指定共有空間ID無し st=%d',   [ctErrSetFilter, st]);
        85: ShowMessageFmt('%s共有空間ロックエラー st=%d', [ctErrSetFilter, st]);
       -98: ShowMessageFmt('%sDLLのロード失敗 st=%d',      [ctErrSetFilter, st]);
       -99: ShowMessageFmt('%s関数のロード失敗 st=%d',     [ctErrSetFilter, st]);
     else
         if st < 0 then
            ShowMessageFmt('%sその他のエラー st=%d',       [ctErrSetFilter, st]);
     end;
end;

//**********************************************************************//
// Module Name     :  フィルターを取得                                  //
//                 :  THRscCtl.GetFilter                              //
// 引数            :  --                                                //
// 戻り値          :  1 Smallint        設定されているフィルターを返す  //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.13                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function  THRscCtl.GetFilter: Smallint;
var
   stGetShrInf     : tagGetShrSpaceInf;
   st              : Smallint;
begin
     Result := 0;
     st := GetShrInfo(mnRscId, stGetShrInf);
     case st of
       0: Result := stGetShrInf.nFilterMark;
     else
       if st <> 1 then
          ShowMessageFmt('フィルター取得エラー'#13'%sその他のエラー st=%d', [st]);
     end;
end;

//**********************************************************************//
// Module Name     :  検索キー数を取得                                  //
//                 :  THRscCtl.GetSrchKeyFig                          //
// 引数            :  --                                                //
// 戻り値          :  1 Integer             検索キー数                  //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.15                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.GetSrchKeyFig: Smallint;
var
   stGetShrInf     : tagGetShrSpaceInf;
   st              : Smallint;
begin
     Result := 0;
     st := GetShrInfo(mnRscId, stGetShrInf);
     case st of
       0: Result := stGetShrInf.nSrchKeyFig;
     else
       if st <> 1 then
          ShowMessageFmt('検索キー数取得エラー'#13'その他のエラー st=%d', [st]);
     end;
end;

//**********************************************************************//
// Module Name     :  共有空間が存在するかのチェック                    //
//                 :  THRscCtl.GetLife                                //
// 引数            :  --                                                //
// 戻り値          :  1 Integer(0:存在      1:無し   )                  //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.15                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.GetLife: Smallint;
var
   stGetShrInf     : tagGetShrSpaceInf;
begin
     Result := GetShrInfo(mnRscId, stGetShrInf);
end;

//**********************************************************************//
// Module Name     :  Redo可能かを検査                                  //
//                 :  THRscCtl.GetCanRedo                             //
// 引数            :  --                                                //
// 戻り値          :  1 Boolean         True:可能  False:不可能         //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.18                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.GetCanRedo: Boolean;
begin
     if GetLife = 0 then Result := (mUndoList.Count > mnUndoPos)
                    else Result := False;
end;

//**********************************************************************//
// Module Name     :  Undo可能かを検査                                  //
//                 :  THRscCtl.GetCanUndo                             //
// 引数            :  --                                                //
// 戻り値          :  1 Boolean         True:可能  False:不可能         //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.18                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.GetCanUndo: Boolean;
begin
     if GetLife = 0 then Result := (mnUndoPos > 0)
                    else Result := False;
end;

//**********************************************************************//
// Module Name     :  Undoﾊﾞｯﾌｧの最大値を設定する                       //
//                 :  THRscCtl.SetUndoMax                             //
// 引数            :  1 nMax              最大Undoﾊﾞｯﾌｧ数               //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.19                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THRscCtl.SetUndoMax(nMax: Longint);              // undo最大件数
begin
     mnUndoMax := nMax;
end;

//**********************************************************************//
// Module Name     :  Undoﾊﾞｯﾌｧ指定位置削除                             //
//                 :  DelUndoBuff                                       //
// 引数            :  1 nIndex            ﾊﾞｯﾌｧIndex                    //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.18                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THRscCtl.DelUndoBuff(nIndex: Integer);
var
   pUndoBuff       : PtagUndoRscBuff;
begin
     if mUndoList = nil then Exit;
     if (nIndex < 0) And (nIndex >= mUndoList.Count) then Exit;
     pUndoBuff := mUndoList.Items[nIndex];
     if pUndoBuff <> nil then begin
        // 共有空間有り？
        if pUndoBuff^.nRscId <> 0 then begin
           // 共有空間を破棄
           DelShrSpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd);
        end;
        FreeMem(pUndoBuff, SizeOf(tagUndoRscBuff));
     end;

     mUndoList.Delete(nIndex);

     // 現在のUndoﾊﾞｯﾌｧﾎﾟｼﾞｼｮﾝを移動
     if mnUndoPos > nIndex then Dec(mnUndoPos);
end;

//**********************************************************************//
// Module Name     :  Undoﾊﾞｯﾌｧ全削除                                   //
//                 :  THRscCtl.DelAllUndoBuff                         //
// 引数            :  --                                                //
// 戻り値          :  --                                                //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.18                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
procedure THRscCtl.DelAllUndoBuff;
begin
     (* UNDOﾊﾞｯﾌｧの破棄 *)
     if mUndoList <> nil then begin
        while mUndoList.Count <> 0 do
           DelUndoBuff(mUndoList.Count - 1);
     end;
end;

//**********************************************************************//
// Module Name     :  Undoのみを消す                                    //
//                 :  THRscCtl.ClearUndoShrSpace                      //
// 引数            :  --                                                //
// 戻り値          :  1 Integer              0:成功  1:失敗             //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.19                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.ClearUndoShrSpace: Integer;
begin
     while mnUndoPos <> 0 do
        DelUndoBuff(0);
     Result := 0;
end;

//**********************************************************************//
// Module Name     :  Redoのみを消す                                    //
//                 :  THRscCtl.ClearRedoShrSpace                              //
// 引数            :  --                                                //
// 戻り値          :  1 Integer              0:成功  1:失敗             //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.20                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.ClearRedoShrSpace: Integer;
begin
     while mnUndoPos < mUndoList.Count do
        DelUndoBuff(mUndoList.Count - 1);
     Result := 0;
end;

//**********************************************************************//
// Module Name     :  Undo処理                                          //
//                 :  THRscCtl.UndoShrSpace                                   //
// 引数            :  --                                                //
// 戻り値          :  1 Integer              0:成功  1:失敗             //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.20                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.UndoShrSpace: Integer;
var
   pTempUndo       : PtagUndoRscBuff;
   pUndoBuff       : PtagUndoRscBuff;
begin
     Result := 1;
     // UNDO可能か？
     if CanUndo then begin
        (*----- UNDOﾊﾞｯﾌｧへのﾎﾟｲﾝﾀを取得 -------------------------------------*)
        pUndoBuff := mUndoList.Items[mnUndoPos-1];
        if pUndoBuff = nil then Exit;

        (*----- ﾃﾝﾎﾟﾗﾘ共有空間を作成 -----------------------------------------*)
        if CreateUndoBuff(pTempUndo) <> 0 then begin
           Result := -1; Exit;
        end;

        (*----- 現在の共有空間をﾃﾝﾎﾟﾗﾘにコピー -------------------------------*)
        Result := CopySpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd,
                               mnLockShrMode,
                               mnRscId,           mnLockHnd, OPRND_RSCID_BASE_PLUS);
        if Result <> 0 then begin
           // ﾃﾝﾎﾟﾗﾘの共有区間を破棄
           DelShrSpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd);
           // ﾃﾝﾎﾟﾗﾘ空間の破棄
           FreeMem(pTempUndo);
           Exit;
        end;

        (*----- UNDOﾊﾞｯﾌｧより、現在の共有空間にコピー ------------------------*)
        DelShrSpaceSub(mnRscId, mnLockHnd);

        Result := CopySpaceSub(mnRscId, mnLockHnd,
                               mnLockShrMode,
                               pUndoBuff^.nRscId, pUndoBuff^.nLockHnd, OPRND_RSCID_DIRECT);
        if Result <> 0 then begin
           DelShrSpaceSub(RscId, LockHandle);
           CopySpaceSub(mnRscId,        mnLockHnd,
                        mnLockShrMode,
                        pTempUndo^.nRscId, pTempUndo^.nLockHnd, OPRND_RSCID_DIRECT);
           // ﾃﾝﾎﾟﾗﾘの共有区間を破棄
           DelShrSpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd);
           // ﾃﾝﾎﾟﾗﾘ空間の破棄
           FreeMem(pTempUndo);
           Exit;
        end;

        (*----- ﾃﾝﾎﾟﾗﾘをUNDOﾊﾞｯﾌｧにコピー ------------------------------------*)
        DelShrSpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd);

        Result := CopySpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd,
                               mnLockShrMode,
                               pTempUndo^.nRscId, pTempUndo^.nLockHnd, OPRND_RSCID_DIRECT);
        if Result <> 0 then begin
           DelShrSpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd);
           CopySpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd,
                        mnLockShrMode,
                        mnRscId,           mnLockHnd, OPRND_RSCID_DIRECT);

           DelShrSpaceSub(RscId, LockHandle);
           CopySpaceSub(mnRscId,        mnLockHnd,
                        mnLockShrMode,
                        pTempUndo^.nRscId, pTempUndo^.nLockHnd, OPRND_RSCID_DIRECT);
           // ﾃﾝﾎﾟﾗﾘの共有区間を破棄
           DelShrSpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd);
           // ﾃﾝﾎﾟﾗﾘ空間の破棄
           FreeMem(pTempUndo);
           Exit;
        end;

        // ﾃﾝﾎﾟﾗﾘの共有区間を破棄
        DelShrSpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd);
        // ﾃﾝﾎﾟﾗﾘ空間の破棄
        FreeMem(pTempUndo);
        Dec(mnUndoPos);
     end;
end;

//**********************************************************************//
// Module Name     :  Redo処理                                          //
//                 :  THRscCtl.RedoShrSpace                           //
// 引数            :  --                                                //
// 戻り値          :  1 Integer              0:成功  1:失敗             //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.24                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.RedoShrSpace: Integer;
var
   pTempUndo       : PtagUndoRscBuff;
   pUndoBuff       : PtagUndoRscBuff;
begin
     Result := 1;
     // REDO可能か？
     if CanRedo then begin
        (*----- UNDOﾊﾞｯﾌｧへのﾎﾟｲﾝﾀを取得 -------------------------------------*)
        pUndoBuff := mUndoList.Items[mnUndoPos];
        if pUndoBuff = nil then Exit;

        (*----- ﾃﾝﾎﾟﾗﾘ共有空間を作成 -----------------------------------------*)
        if CreateUndoBuff(pTempUndo) <> 0 then begin
           Result := -1; Exit;
        end;

        (*----- 現在の共有空間をﾃﾝﾎﾟﾗﾘにコピー -------------------------------*)
        Result := CopySpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd,
                               mnLockShrMode,
                               mnRscId,           mnLockHnd, OPRND_RSCID_BASE_PLUS);
        if Result <> 0 then begin
           // ﾃﾝﾎﾟﾗﾘの共有区間を破棄
           DelShrSpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd);
           // ﾃﾝﾎﾟﾗﾘ空間の破棄
           FreeMem(pTempUndo);
           Exit;
        end;

        (*----- UNDOﾊﾞｯﾌｧより、現在の共有空間にコピー ------------------------*)
        DelShrSpaceSub(mnRscId, mnLockHnd);

        Result := CopySpaceSub(mnRscId, mnLockHnd,
                               mnLockShrMode,
                               pUndoBuff^.nRscId, pUndoBuff^.nLockHnd, OPRND_RSCID_DIRECT);
        if Result <> 0 then begin
           DelShrSpaceSub(RscId, LockHandle);
           CopySpaceSub(mnRscId,        mnLockHnd,
                        mnLockShrMode,
                        pTempUndo^.nRscId, pTempUndo^.nLockHnd, OPRND_RSCID_DIRECT);
           // ﾃﾝﾎﾟﾗﾘの共有区間を破棄
           DelShrSpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd);
           // ﾃﾝﾎﾟﾗﾘ空間の破棄
           FreeMem(pTempUndo);
           Exit;
        end;

        (*----- ﾃﾝﾎﾟﾗﾘをUNDOﾊﾞｯﾌｧにコピー ------------------------------------*)
        DelShrSpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd);

        Result := CopySpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd,
                               mnLockShrMode,
                               pTempUndo^.nRscId, pTempUndo^.nLockHnd, OPRND_RSCID_DIRECT);
        if Result <> 0 then begin
           DelShrSpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd);
           CopySpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd,
                        mnLockShrMode,
                        mnRscId,        mnLockHnd, OPRND_RSCID_DIRECT);

           DelShrSpaceSub(RscId, LockHandle);
           CopySpaceSub(mnRscId,        mnLockHnd,
                        mnLockShrMode,
                        pTempUndo^.nRscId, pTempUndo^.nLockHnd, OPRND_RSCID_DIRECT);
           // ﾃﾝﾎﾟﾗﾘの共有区間を破棄
           DelShrSpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd);
           // ﾃﾝﾎﾟﾗﾘ空間の破棄
           FreeMem(pTempUndo);
           Exit;
        end;

        // ﾃﾝﾎﾟﾗﾘの共有区間を破棄
        DelShrSpaceSub(pTempUndo^.nRscId, pTempUndo^.nLockHnd);
        // ﾃﾝﾎﾟﾗﾘ空間の破棄
        FreeMem(pTempUndo);
        Inc(mnUndoPos);
     end;
end;

//**********************************************************************//
// Module Name     :  Undoﾊﾞｯﾌｧに現在の情報を設定する                   //
//                 :  THRscCtl.SetUndoShrSpace                        //
// 引数            :  --                                                //
// 戻り値          :  1 Integer               0:成功  1:失敗            //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.25                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.SetUndoShrSpace: Integer;
begin
     // Redo側をクリアする
     ClearRedoShrSpace;

     // Undoﾊﾞｯﾌｧに現在のｲﾒｰｼﾞを保存する
     Result := SetUndoShrSpaceSub;
     if Result = 0 then begin
        if mUndoList.Count > mnUndoMax then DelUndoBuff(0)   // 最初のUNDOﾊﾞｯﾌｧを消す
                                       else Inc(mnUndoPos);  // UNDO位置を＋１
     end;
end;

//**********************************************************************//
// Module Name     :  現在の情報を設定する                              //
//                 :  THRscCtl.SetUndoShrSpaceSub                     //
// 引数            :  --                                                //
// 戻り値          :  1 Integer               0:成功  1:失敗            //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.25                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.SetUndoShrSpaceSub: Integer;
var
   pUndoBuff       : PtagUndoRscBuff;
begin
     Result := 1;
     if GetLife <> 0 then Exit;

     // 既にUNDO用ﾊﾞｯﾌｧがあるか？無い場合は、作成
     if mUndoList.Count <= mnUndoPos then begin
        // UNDO用ﾊﾞｯﾌｧを確保
        if CreateUndoBuff(pUndoBuff) <> 0 then Exit;

        mUndoList.Add(pUndoBuff);
        mnUndoPos := mUndoList.Count - 1;
     end else begin
        // 現在のUNDOﾊﾞｯﾌｧを取得する
        pUndoBuff := mUndoList.Items[mnUndoPos];
        if pUndoBuff = nil then begin
           Result := -1; Exit;
        end;

        // Undoﾊﾞｯﾌｧ側のﾚｺｰﾄﾞを全て削除
        DelShrSpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd);
     end;

     // 現在の共有空間イメージをUNDOﾊﾞｯﾌｧに設定
     Result := CopySpaceSub(pUndoBuff^.nRscId, pUndoBuff^.nLockHnd,
                            mnLockShrMode,
                            RscId,             LockHandle, OPRND_RSCID_BASE_PLUS);
end;

//**********************************************************************//
// Module Name     :  UNDO格納用ﾊﾞｯﾌｧ及び共有空間作成                   //
//                 :  THRscCtl.CreateUndoBuff                         //
// 引数            :  1 xxxx (0:xxxx 1:xxxx)                            //
// 戻り値          :  1 Integer(0:xxxxxxxx  1:xxxxxxx)                  //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.mm.dd                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.CreateUndoBuff(var pUndoBuff: PtagUndoRscBuff): Integer;
begin
     // 現在の情報を取得
     Result := 0;
     try
        GetMem(pUndoBuff, SizeOf(tagUndoRscBuff));
     except
        on E:EOutOfMemory do begin
           Result := -1; Exit;
        end;
     end;

     // UNDOﾊﾞｯﾌｧとUNDO用ﾘｿｰｽ空間を結びつける
     pUndoBuff^.nRscId   := cnUndoRsc;
     pUndoBuff^.nLockHnd := LockHandle;
     FillChar(pUndoBuff^.szName, SizeOf(pUndoBuff^.szName), ' ');
end;

//**********************************************************************//
// Module Name     :  共有空間をコピーする                              //
//                 :  THRscCtl.CopySpaceSub                           //
// 引数            :  1 nDstrsc        コピー先のリソースＩＤ           //
//                 :  2 nDstlock       コピー先のロックハンドル         //
//                 :  3 nLockMode      コピー先のロックモード           //
//                 :  4 nSrcrsc        コピー元のリソースＩＤ           //
//                 :  5 nSrclock       コピー元のロックハンドル         //
// 戻り値          :  1 Integer        CopyShrSpaceの戻り値             //
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.26                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.CopySpaceSub(var nDstrsc : Longint;
                                var nDstlock: Longint;
                                nLockMode: Smallint;
                                nSrcrsc, nSrclock: Longint; nOperand: Smallint): Integer;
var
   stSrcInf,
   stDstInf       : tagShrSpaceInf;
begin
//     if mhDllInst = 0          then Result := -98 else                        2000.10.04 削除
//     if @gfpCopyShrSpace = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stSrcInf, SizeOf(stSrcInf), 0);
       stSrcInf.lRscId      := nSrcrsc;
       stSrcInf.lLockHandle := nSrclock;
       FillChar(stDstInf, SizeOf(stDstInf), 0);
       stDstInf.lRscId      := nDstrsc;
       stDstInf.lLockHandle := nDstlock;
       stDstInf.nOperand    := nOperand;
       // 共有空間コピー実行
       Result := gfpCopyShrSpace(stDstInf, nLockMode, stSrcInf);
//     end;

     if Result = 0 then begin
        nDstrsc  := stDstInf.lRscId;
        nDstlock := stDstInf.lLockHandle;
     end else begin
        nDstrsc  := 0;
        nDstlock := 0;
     end;
end;

//**********************************************************************//
// Module Name     :  共有空間削除補助処理                              //
//                 :  THRscCtl.DelShrSpaceSub                         //
// 引数            :  1 nRscid         リソースＩＤ                     //
//                 :  2 nLockHandle    ロックハンドル                   //
// 戻り値          :  1 Integer            処理結果  DelShrSpaceの戻り値//
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.26                                        //
//----------------------------------------------------------------------//
// Update Note     :                                                    //
//**********************************************************************//
function THRscCtl.DelShrSpaceSub(nRscid, nLockHandle: Longint): Integer;
var
   stShrInf       : tagShrSpaceInf;
begin
//     if mhDllInst = 0         then Result := -98 else
//     if @gfpDelShrSpace = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := nRscid;                                 // ﾘｿｰｽID
       stShrInf.lLockHandle := nLockHandle;                            // ﾛｯｸﾊﾝﾄﾞﾙ
       // 共有空間削除実行
       Result := gfpDelShrSpace(stShrInf);
//     end;
end;

//**********************************************************************//
// Module Name     :  レコード全削除補助処理                            //
//                 :  THRscCtl.DelAllShrRecSub                           //
// 引数            :  1 nRscid         リソースＩＤ                     //
//                 :  2 nLockHandle    ロックハンドル                   //
// 戻り値          :  1 Integer           処理結果  DelAllShrRecの戻り値//
// Programer       :  宮富 孝洋(980152)                                 //
// Date            :  2000.04.26                                        //
//----------------------------------------------------------------------//
// Update Note     :  2000.10.04  鹿野　幸生                            //
//**********************************************************************//
function THRscCtl.DelAllShrRecSub(nRscid, nLockHandle: Longint): Integer;
var
   stShrInf        : tagShrSpaceInf;
begin
//     if mhDllInst = 0          then Result := -98 else                        2000.10.04 削除
//     if @gfpDelAllShrRec = nil then Result := -99 else
//     begin
       // パラメータ設定
       FillChar(stShrInf, SizeOf(stShrInf), 0);
       stShrInf.lRscId      := nRscId;                                 // ﾘｿｰｽID
       stShrInf.lLockHandle := nLockHandle;                            // ﾛｯｸﾊﾝﾄﾞﾙ
       // 全削除実行
       Result := gfpDelAllShrRec(stShrInf);
//     end;
end;

(*============================================================================*)
(*  初期化部                                                                  *)
(*============================================================================*)
initialization
   mhDllInst           := 0;
   gfpCreatShrSpace    := nil;
   gfpGetShrSpace      := nil;
   gfpCopyShrSpace     := nil;
   gfpDelShrSpace      := nil;
   gfpSetShrFilter     := nil;

   gfpInsShrRec        := nil;
   gfpGetShrRec        := nil;
   gfpDelShrRec        := nil;
   gfpHideShrRec       := nil;
   gfpUndoShrRec       := nil;
   gfpGetHideShrRecCnt := nil;
   gfpAddShrRec        := nil;
   gfpUpdtShrRec       := nil;
   gfpQueryCurShrRec   := nil;
   gfpDelAllShrRec     := nil;
   gfpGetShrRecCnt     := nil;
   gfpMarkShrRec       := nil;

   gfpFirstShrRec      := nil;
   gfpPrevShrRec       := nil;
   gfpNextShrRec       := nil;
   gfpLastShrRec       := nil;
   gfpGoShrRow         := nil;
   gfpQueryCurShrRow   := nil;

   gfpMoveShrRec       := nil;
   gfpCopyShrRec       := nil;

   gfpSetSrchKey       := nil;
   gfpSrchKeyRec       := nil;

(*============================================================================*)
(*  終了処理部                                                                *)
(*============================================================================*)
finalization

   if mhDllInst <> 0 then
     FreeLibrary(mhDllInst);
   mhDllInst := 0;
 (*<<<<< 2000.05.30 MIYATOMI ADD <<<<<*)
end.
