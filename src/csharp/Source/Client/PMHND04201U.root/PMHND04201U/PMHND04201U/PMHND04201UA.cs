//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品照会
// プログラム概要   : 検品照会の登録・検索・更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 譚洪
// 作 成 日  2017/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 3H 張小磊                               
// 修 正 日  2017/09/07  修正内容 : 検品照会の変更対応
//----------------------------------------------------------------------------//
// 管理番号  11370104-00 作成担当 : 脇田　靖之                              
// 修 正 日  2017/12/19  修正内容 : ハンディターミナル三次対応
//                                  委託在庫補充機能復活
//----------------------------------------------------------------------------//
// 管理番号  11470154-00 作成担当 : 陳艶丹                              
// 修 正 日  2018/10/16  修正内容 : ハンディターミナル五次対応
//                                  取消機能とテキスト出力機能の追加
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller.Facade;// ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 検品照会メインフレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品照会メインフレームの定義と実装を行うクラス。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br>Update Note: 2017/09/07 3H 張小磊</br>
    /// <br>　　　　　 : 検品照会の変更対応</br>
    /// <br>Update Note: 2018/10/16 陳艶丹</br>
    /// <br>　　　　　 : ハンディターミナル五次対応</br>
    /// </remarks>
    public partial class PMHND04201UA : System.Windows.Forms.Form
    {
        #region ■Private Const
        /// <summary>終了ボタン</summary>
        private const string ButtonToolClose = "ButtonTool_Close";
        /// <summary>検索ボタン</summary>
        private const string ButtonToolSearch = "ButtonTool_Search";
        /// <summary>確定ボタン</summary>
        private const string ButtonToolOk = "ButtonTool_OK";
        /// <summary>クリアボタン</summary>
        private const string ButtonToolClear = "ButtonTool_Clear";
        /// <summary>検品引当ボタン</summary>
        private const string ButtonToolInspectUpd = "ButtonTool_InspectUpd";
        /// <summary>検品表示ボタン</summary>
        private const string ButtonToolShow = "ButtonTool_Show";
        /// <summary>ログイン担当者タイトル</summary>
        private const string LabelToolLoginTitle = "LabelTool_LoginTitle";
        /// <summary>ログイン担当者名称</summary>
        private const string LabelToolLoginName = "LabelTool_LoginName";

        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        /// <summary>取消ボタン</summary>
        private const string ButtonToolDelete = "ButtonTool_Delete";
        /// <summary>テキスト出力ボタン</summary>
        private const string ButtonToolTextOut = "ButtonTool_TextOut";
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

        /// <summary>開始入出荷日未入力のメッセージ</summary>
        private const string IoGoodsDayBeginEmptyDate = "開始入出荷日を入力して下さい。";
        /// <summary>開始入出荷日無効年月日のメッセージ</summary>
        private const string IoGoodsDayBeginInvalidDate = "開始入出荷日の入力が不正です。";
        /// <summary>終了入出荷日未入力のメッセージ</summary>
        private const string IoGoodsDayEndEmptyDate = "終了入出荷日を入力して下さい。";
        /// <summary>終了入出荷日無効年月日のメッセージ</summary>
        private const string IoGoodsDayEndInvalidDate = "終了入出荷日の入力が不正です。";
        /// <summary>入出荷日開始＞終了のメッセージ</summary>
        private const string IoGoodsDayStartEndError = "入出荷日の範囲指定に誤りがあります。";
        /// <summary>開始検品日未入力のメッセージ</summary>
        private const string InspectDayBeginEmptyDate = "開始検品日を入力して下さい。";
        /// <summary>開始検品日無効年月日のメッセージ</summary>
        private const string InspectDayBeginInvalidDate = "開始検品日の入力が不正です。";
        /// <summary>終了検品日未入力のメッセージ</summary>
        private const string InspectDayEndEmptyDate = "終了検品日を入力して下さい。";
        /// <summary>終了検品日無効年月日のメッセージ</summary>
        private const string InspectDayEndInvalidDate = "終了検品日の入力が不正です。";
        /// <summary>検品日開始＞終了のメッセージ</summary>
        private const string InspectDayStartEndError = "検品日の範囲指定に誤りがあります。";
        /// <summary>パターンが「検品のみ」以外で、取引対象のいずれも選択されていないのメッセージ</summary>
        private const string TransObjectEmptyError = "取引対象を指定して下さい。";

        /// <summary>従業員情報取得エラーのメッセージ</summary>
        private const string EmployeeSearchError = "従業員情報取得に失敗しました。";
        /// <summary>拠点情報取得エラーのメッセージ</summary>
        private const string SecInfoSearchError = "拠点情報取得に失敗しました。";
        /// <summary>倉庫情報取得エラーのメッセージ</summary>
        private const string WarehouseInfoSearchError = "倉庫情報取得に失敗しました。";
        /// <summary>メーカー情報取得エラーのメッセージ</summary>
        private const string GoodsMakerInfoSearchError = "メーカー情報取得に失敗しました。";
        /// <summary>端末設定情報取得エラーのメッセージ</summary>
        private const string PosTerminalInfoSearchError = "端末情報取得に失敗しました。";

        /// <summary>拠点情報取得できないのメッセージ</summary>
        private const string SecInfoEmptyError = "拠点コードが存在しません。";
        /// <summary>倉庫情報取得できないのメッセージ</summary>
        private const string WarehouseInfoEmptyError = "倉庫コードが存在しません。";
        /// <summary>メーカー情報取得できないのメッセージ</summary>
        private const string GoodsMakerInfoEmptyError = "メーカーコードが存在しません。";
        /// <summary>従業員情報取得できないのメッセージ</summary>
        private const string EmployeeInfoEmptyError = "従業員コードが存在しません。";

        /// <summary>データ情報取得できないのメッセージ</summary>
        private const string DataInfoEmptyError = "該当するデータがありません。";
        /// <summary>検品情報取得エラーのメッセージ</summary>
        private const string InspectInfoSearchError = "読み込みに失敗しました。";
        /// <summary>検品情報確定前グリッド未チェックエラーのメッセージ</summary>
        private const string BeforeSaveNoSelectError = "手動引当の対象となる明細を選択して下さい。";
        /// <summary>検品情報引当前グリッド未チェックエラーのメッセージ</summary>
        private const string BeforeUpdateNoSelectError = "検品引当の対象となる明細を選択して下さい。";
        /// <summary>検品情報表示前グリッド未チェックエラーのメッセージ</summary>
        private const string BeforeShowNoSelectError = "検品表示の対象となる明細を選択して下さい。";
        /// <summary>検品情報引当前明細グリッドに選択されたレコードの「検」欄が「※」のエラーのメッセージ</summary>
        private const string BeforeUpdatePickingError = "ピッキング済み明細の為、引当できません。";
        /// <summary>検品情報引当前明細グリッドに選択されたレコードの「検」欄が「✔」のエラーのメッセージ</summary>
        private const string BeforeUpdateMoreUpdError = "引当済み明細の為、引当できません。";
        /// <summary>検品情報引当前明細グリッドに選択されたレコードの「検」欄が「○」のエラーのメッセージ</summary>
        private const string BeforeUpdateInspectingError = "検品中明細の為、引当できません。";
        /// <summary>検品情報引当前明細グリッドに選択されたレコードの「選択」欄がチェックされているエラーのメッセージ</summary>
        private const string BeforeUpdateCheckedError = "手動引当対象明細の為、引当できません。";
        /// <summary>検品情報引当前確認ダイアログのメッセージ</summary>
        private const string BeforeUpdateQuestionMessage = "選択行の自動検品引当処理を行います。" + "\r\n" + "\r\n" +
                                                           "よろしいですか？";
        /// <summary>検品情報確定前確認ダイアログのメッセージ</summary>
        private const string BeforeSaveQuestionMessage = "選択行の手動検品データ登録を行います。" + "\r\n" + "\r\n" +
                                                           "よろしいですか？";
        /// <summary>画面閉じる前確認ダイアログのメッセージ</summary>
        private const string BeforeCloseQuestionMessage = "明細グリッドに手動引当対象明細が選択されています。" + "\r\n" + "\r\n" +
                                                          "検品登録してもよろしいですか？";
        /// <summary>検品情報確定登録エラーのメッセージ</summary>
        private const string InspectInfoSaveError = "登録処理に失敗しました。";

        /// <summary>グリッド列表示状態保存処理エラーのメッセージ</summary>
        private const string ColDisplayStatusSaveError = "グリッド列表示状態保存処理に失敗しました。";
        /// <summary>列表示状態セッティングXMLファイル名</summary>
        private const string FileNameColDisplayStatus = "PMHND04201U_ColSetting.DAT";

        /// <summary>抽出中画面のタイトル</summary>
        private const string SearchFormTitle = "抽出中";
        /// <summary>抽出中画面のメッセージ</summary>
        private const string SearchFormMessage = "データ抽出中です。";
        /// <summary>確定中画面のタイトル</summary>
        private const string SaveFormTitle = "保存中";
        /// <summary>確定中画面のメッセージ</summary>
        private const string SaveFormMessage = "検品データ登録中です。";

        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>委託先倉庫情報取得できないのメッセージ</summary>
        private const string AfWarehouseInfoEmptyError = "委託先倉庫コードが存在しません。";
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<

        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        /// <summary>確定前チェックエラーのメッセージ</summary> 
        private const string BeforeSaveError = "検品済み明細が選択されている為、手動検品登録できません。";
        /// <summary>取消前グリッド未チェックエラーのメッセージ</summary>
        private const string BeforeDeleteNoSelectError = "取消の対象となる明細を選択して下さい。";
        /// <summary>取消前確認ダイアログのメッセージ</summary>
        private const string BeforeDeleteQuestionMessage = "選択行の検品取消処理を行います。" + "\r\n" + "\r\n" +
                                                           "よろしいですか？";
        /// <summary>画面クリア前確認ダイアログのメッセージ</summary>
        private const string BeforeClearQuestionMessage = "明細グリッドに取消対象明細が選択されています。" + "\r\n" + "\r\n" +
                                                          "検品取消してもよろしいですか？";
        /// <summary>メモリアウトのメッセージ</summary>
        private const string OutOfMemoryError = "抽出対象件数が多い為、処理に失敗しました。" + "\r\n" + "\r\n" +
                                                  "絞込条件を再設定し、処理を実行してください。";
        /// <summary>ファイルが他で使用中のメッセージ</summary>
        private const string FileAlrdyError = "出力ファイルが他で使用中です。";
        /// <summary>ファイルのアクセスチェックのメッセージ</summary>
        private const string FileAccessError = "出力ファイルへのアクセスが拒否されました。";
        /// <summary>チェック時メッセージ「ファイルへの出力に失敗しました。」</summary>
        private const string MsgOutputFailed = "ファイルへの出力に失敗しました。";
        /// <summary>テキストエクスポート成功時メッセージ</summary>
        private const string MsgOutputSucceeded = "CSVデータを作成しました。";
        /// <summary>検品情報取消エラーのメッセージ</summary>
        private const string InspectDeleteError = "取消処理が失敗しました。";
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
      
        /// <summary>プログラムID</summary>
        private const string AssemblyId = "PMHND04201U";
        /// <summary>プログラム名前</summary>
        private const string AssemblyName = "検品照会";
        /// <summary>画面メニュー</summary>
        private const string Toolbars = "Toolbars";

        enum GoodNoSearchType
        {
            /// <summary>あいまい検索「と一致」ステータス</summary>
            MatchWith = 0,
            /// <summary>あいまい検索「で始る」ステータス</summary>
            StartWith = 1,
            /// <summary>あいまい検索「で終る」ステータス</summary>
            EndWith = 2,
            /// <summary>あいまい検索「を含む」ステータス</summary>
            IncludeWith = 3,
        };

        /// <summary>0文字列</summary>
        private const char CharZero = '0';
        /// <summary>0文字列</summary>
        private const string StringZero = "0";
        /// <summary>00文字列</summary>
        private const string StringZZ = "00";
        /// <summary>0000文字列</summary>
        private const string StringZZZZ = "0000";
        /// <summary>/文字列</summary>
        private const string StringSlash = "/";
        /// <summary>／文字列</summary>
        private const string StringZanSlash = "／";
        /// <summary>※文字列</summary>
        private const string StringHoshi = "※";
        /// <summary>✔文字列</summary>
        private const string StringCheck = "✔";
        /// <summary>○文字列</summary>
        private const string StringCircle = "○";
        /// <summary>*文字列</summary>
        private const string StringHash = "*";
        /// <summary>コンマ文字列</summary>
        private const string StringComma = ",";
        /// <summary>コロン文字列</summary>
        private const string StringColon = ":";
        /// <summary>HT文字列</summary>
        private const string StringHT = "HT";
        /// <summary>PC文字列</summary>
        private const string StringPC = "PC";

        /// <summary>-1ステータス</summary>
        private const int StatusError = -1;
        /// <summary>0ステータス</summary>
        private const int StatusNormal = 0;

        /// <summary>登録モード「0」:手動検品データ登録処理</summary>
        private const int RegistModeManualInspect = 0;
        /// <summary>登録モード「1」:先行検品引当登録処理</summary>
        private const int RegistModeAllocPreInspect = 1;

        /// <summary>グリッドのアクティブ行のインデックス「0」：グリッドの最上行</summary>
        private const int ActiveRowIndexZero = 0;

        /// <summary>日付「0」：日付未入力</summary>
        private const int LongDateZero = 0;

        /// <summary>メーカーコード「0」：メーカーコード未入力</summary>
        private const int GoodsMakerCdZero = 0;
        /// <summary>グリッドデータ件数「0」：グリッドデータ件数0件</summary>
        private const int InspectGridRowsCountZero = 0;

        /// <summary>ガイド起動モード「0」：検品表示</summary>
        private const int GuideModeInspectShow = 0;
        /// <summary>ガイド起動モード「1」：検品引当</summary>
        private const int GuideModeInspectProvision = 1;

        /// <summary>売上伝票区分（明細）「0」：売上</summary>
        private const int SalesSlipCdDtlDivSalesSlip = 0;
        /// <summary>売上伝票区分（明細）「1」：返品</summary>
        private const int SalesSlipCdDtlDivReturned = 1;

        /// <summary>入庫数「0」：入庫数0件</summary>
        private const int InputCntZero = 0;
        /// <summary>出庫数「0」：出庫数0件</summary>
        private const int ShipmentCntZero = 0;
        /// <summary>削除フラグ「0」：有効</summary>
        private const int DataEffective = 0;
        /// <summary>削除フラグ「1」：論理削除</summary>
        private const int DataLogicalDeleted = 1;

        /// <summary>検品ステータス「1」：検品中</summary>
        private const int InspectStatusDuring = 1;
        /// <summary>検品ステータス「2」：ピッキング済み</summary>
        private const int InspectStatusAlreadyPicking = 2;
        /// <summary>検品ステータス「3」：検品済み</summary>
        private const int InspectStatusAlreadyInspected = 3;

        /// <summary>検品区分「2」：手動検品 </summary>
        private const int InspectCodeManual = 2;

        /// <summary>ハンディターミナル区分「1」：ハンディターミナル</summary>
        private const int DivHandTerminal = 1;
        /// <summary>ハンディターミナル区分「9」：その他</summary>
        private const int DivOtherwise = 9;

        /// <summary>受払元取引区分「10」：通常伝票</summary>
        private const int AcPayTransCdNormalSlip = 10;
        /// <summary>受払元取引区分「11」：返品</summary>
        private const int AcPayTransCdReturned = 11;
        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>受払元取引区分「30」：在庫数調整</summary>
        private const int AcPayTransCdAdjust = 30;
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<

        /// <summary>受注ステータス「30」：売上</summary>
        private const int AcptAnOdrStatusEarnings = 30;
        /// <summary>受注ステータス「40」：出荷</summary>
        private const int AcptAnOdrStatusShipment = 40;


        /// <summary>受払元伝票区分「10」：仕入</summary>
        private const int AcPaySlipCdStock = 10;
        /// <summary>受払元伝票区分「11」：受託</summary>
        private const int AcPaySlipCdAccession = 11;
        /// <summary>受払元伝票区分「13」：在庫仕入</summary>
        private const int AcPaySlipCdStockSupplier = 13;
        /// <summary>受払元伝票区分「20」：売上</summary>
        private const int AcPaySlipCdEarnings = 20;
        /// <summary>受払元伝票区分「22」：貸出</summary>
        private const int AcPaySlipCdRental = 22;
        /// <summary>受払元伝票区分「30」：移動出荷</summary>
        private const int AcPaySlipCdMovementShipping = 30;
        /// <summary>受払元伝票区分「31」：移動入荷</summary>
        private const int AcPaySlipCdMovingStock = 31;
        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>受払元伝票区分「70」：補充出庫</summary>
        private const int AcPaySlipCdReplenish = 70;
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<

        /// <summary>チェックボックス「1」：選択有り</summary>
        private const int CheckBoxSelected = 1;

        /// <summary>パターンコンボボックス「3」：検品のみ</summary>
        private const int ComboEditorPatternInspectOnly = 3;

        /// <summary>文字列の一部を取得(Substring用:0)</summary>
        private const int SubstringIndexZero = 0;
        /// <summary>文字列の一部を取得(Substring用:2)</summary>
        private const int SubstringIndexTwo = 2;
        /// <summary>文字列の一部を取得(Substring用:4)</summary>
        private const int SubstringIndexFour = 4;
        /// <summary>文字列の一部を取得(Substring用:6)</summary>
        private const int SubstringIndexSix = 6;

        /// <summary>文字列の長度(Length:8)</summary>
        private const int StringLengthEight = 8;

        /// <summary>文字列の一部を補正(PadLeft用:2)</summary>
        private const int PadLeftIndexTwo = 2;
        /// <summary>文字列の一部を補正(PadLeft用:4)</summary>
        private const int PadLeftIndexFour = 4;

        /// <summary>取寄ｺﾝﾎﾞﾎﾞｯｸｽ選択値0</summary>
        private const int ToRiyoSeValue0 = 0;
        /// <summary>取寄ｺﾝﾎﾞﾎﾞｯｸｽ選択値1</summary>
        private const int ToRiyoSeValue1 = 1;
        /// <summary>取寄ｺﾝﾎﾞﾎﾞｯｸｽ表示値0</summary>
        private const string ToRiyoSeDisp0 = "含む";
        /// <summary>取寄ｺﾝﾎﾞﾎﾞｯｸｽ表示値1</summary>
        private const string ToRiyoSeDisp1 = "含まない";

        /// <summary>ﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ選択値0</summary>
        private const int PatternValue0 = 0;
        /// <summary>ﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ選択値1</summary>
        private const int PatternValue1 = 1;
        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>ﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ選択値2</summary>
        private const int PatternValue2 = 2;
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
        /// <summary>ﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ選択値3</summary>
        private const int PatternValue3 = 3;
        /// <summary>ﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ表示値0</summary>
        private const string PatternDisp0 = "出庫検品";
        /// <summary>ﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ表示値1</summary>
        private const string PatternDisp1 = "入庫検品";
        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>ﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ表示値2</summary>
        private const string PatternDisp2 = "未入庫";
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
        /// <summary>ﾊﾟﾀｰﾝｺﾝﾎﾞﾎﾞｯｸｽ表示値3</summary>
        private const string PatternDisp3 = "検品のみ";


        /// <summary>売上</summary>
        private const string Sales = "売上";
        /// <summary>貸出</summary>
        private const string Rental = "貸出";
        /// <summary>仕入</summary>
        private const string StockSlip = "仕入";
        /// <summary>在庫仕入</summary>
        private const string StockStockSlip = "在庫仕入";
        /// <summary>移動出庫</summary>
        private const string MoveOutWarehouse = "移動出庫";
        /// <summary>移動入庫</summary>
        private const string MoveInWarehouse = "移動入庫";
        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>補充出庫</summary>
        private const string ReplenishOutWarehouse = "補充出庫";
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
        /// <summary>全社</summary>
        private const string WholeCompany = "全社";

        /// <summary>選択</summary>
        private const string SelectFlagCaption = "選択";
        /// <summary>選択</summary>
        private const string InspectStatusDispCaption = "検";
        /// <summary>選択</summary>
        private const string InspectStatusCaption = "検品ステータス";
        /// <summary>入出荷日</summary>
        private const string ShipmentDayCaption = "入出荷日";
        /// <summary>メーカーコード</summary>
        private const string GoodsMakerCdCaption = "メーカーコード";
        /// <summary>メーカー</summary>
        private const string GoodsMakerNameCaption = "メーカー";
        /// <summary>品番</summary>
        private const string GoodsNoCaption = "品番";
        /// <summary>品名</summary>
        private const string GoodsNameCaption = "品名";
        /// <summary>検品</summary>
        private const string HandTerminalCodeDispCaption = "検品";
        /// <summary>ハンディターミナル区分</summary>
        private const string HandTerminalCodeCaption = "ハンディターミナル区分";
        /// <summary>入庫数</summary>
        private const string InputCntCaption = "入庫数";
        /// <summary>出庫数</summary>
        private const string ShipmentCntCaption = "出庫数";
        /// <summary>仕入先/得意先/相手倉庫</summary>
        private const string CustNmWareNmCaption = "仕入先/得意先/相手倉庫";
        /// <summary>棚番</summary>
        private const string WarehouseShelfNoCaption = "棚番";
        /// <summary>取引</summary>
        private const string TransactionCaption = "取引";
        /// <summary>伝票番号</summary>
        private const string SalesSlipNumCaption = "伝票番号";
        /// <summary>検品担当者</summary>
        private const string EmployeeCodeCaption = "検品担当者";
        /// <summary>検品日付</summary>
        private const string InspectDateCaption = "検品日付";
        /// <summary>検品時刻</summary>
        private const string InspectTimeCaption = "検品時刻";
        /// <summary>行番号</summary>
        private const string SalesRowNoCaption = "行番号";
        /// <summary>倉庫コード</summary>
        private const string WarehouseCodeCaption = "倉庫コード";
        /// <summary>受払元伝票区分</summary>
        private const string AcPaySlipCdCaption = "受払元伝票区分";
        /// <summary>受払元取引区分</summary>
        private const string AcPayTransCdCaption = "受払元取引区分";
        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>伝票番号引当用</summary>
        private const string SalesSlipNumHFCaption = "伝票番号引当用";
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<

        /// <summary>金額フォーマット</summary>
        private const string CountFormat = "#,###,##0.00";
        /// <summary>合計フォーマット</summary>
        private const string TotalCountFormat = "#,###,##0";
        
        #endregion ■ Private Const

        # region ◆Private Members

        /// <summary>コントロール部品スキン</summary>
        private ControlScreenSkin ControlScreenSkinAccessor = null;
        /// <summary>画面イメージ</summary>
        private ImageList ImageList16 = null;
        /// <summary>企業コード</summary>
        private string EnterpriseCode = string.Empty;
        /// <summary>ログイン従業員</summary>
        private Employee LoginEmployee = null;
        /// <summary>ログイン拠点コード</summary>
        private string LoginSectionCode = string.Empty;
        /// <summary>ログイン拠点名</summary>
        private string LoginSectionName = string.Empty;
        /// <summary>検品アクセスクラス</summary>
        private InspectInfoAcs InspectInfoAccessor = null;
        /// <summary>日付アクセスクラス</summary>
        private DateGetAcs DateGetAccessor = null;
        /// <summary>拠点アクセスクラス</summary>
        private SecInfoSetAcs SecInfoSetAccessor = null;
        /// <summary>倉庫アクセスクラス</summary>
        private WarehouseAcs WarehouseAccessor = null;
        /// <summary>メーカーアクセスクラス</summary>
        private MakerAcs MakerAccessor = null;
        /// <summary>従業員アクセスクラス</summary>
        private EmployeeAcs EmployeeAccessor = null;
        /// <summary>端末設定ワーク</summary>
        private PosTerminalMg PosTerminalMgData = null;
        /// <summary>端末設定アクセスクラス</summary>
        private PosTerminalMgAcs PosTerminalMgAccessor = null;

        /// <summary>前回入力倉庫コード</summary>
        private string PrevWarehouseCode = string.Empty;
        /// <summary>前回入力倉庫名</summary>
        private string PrevWarehouseName = string.Empty;
        /// <summary>前回入力拠点コード</summary>
        private string PrevSectionCode = string.Empty;
        /// <summary>前回入力拠点名</summary>
        private string PrevSectionName = string.Empty;
        /// <summary>前回入力従業員コード</summary>
        private string PrevEmployeeCode = string.Empty;
        /// <summary>前回入力従業員名</summary>
        private string PrevEmployeeName = string.Empty;
        /// <summary>前回入力メーカーコード</summary>
        private string PrevGoodsMakerCode = string.Empty;
        /// <summary>前回入力メーカー名</summary>
        private string PrevGoodsMakerName = string.Empty;
        /// <summary>明細データ格納データビュー</summary>
        private DataView DataViewInspect = null;
        /// <summary>明細データ格納データセット</summary>
        private InspectDataSet InspectDs = null;
        /// <summary>拠点ディクショナリー</summary>
        private Dictionary<string, string> SecInfoDic = null;
        /// <summary>倉庫ディクショナリー</summary>
        private Dictionary<string, string> WarehouseDic = null;
        /// <summary>メーカーディクショナリー</summary>
        private Dictionary<int, string> GoodsMakerDic = null;
        /// <summary>「enter、マウス、F2など」連続押下判断用フラグ</summary>
        private bool IsSaveFlg = false;
        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary> オプションコードの仕入業務プラス</summary>
        private bool HaveStockSlipPs = false;
        /// <summary>前回入力委託先倉庫コード</summary>
        private string PrevAfWarehouseCode = string.Empty;
        /// <summary>前回入力委託先倉庫名</summary>
        private string PrevAfWarehouseName = string.Empty;
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<

        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        // 画面設定値の保存
        private PrevInputValue UserSetting;
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMHND04200U_Construction.XML";
        /// <summary>ﾃｷｽﾄ出力ファイル名</summary>
        private const string TextFileName = "HTInspectData.CSV";
        /// <summary>テキスト出力オプション情報</summary>
        #region テキスト出力
        /// <summary>入出荷日</summary>
        private const string TextShipmentDayCaption = "入出荷日";
        /// <summary>検品日付</summary>
        private const string TextInspectDateCaption = "検品日";
        /// <summary>検品時刻</summary>
        private const string TextInspectTimeCaption = "検品時刻";
        /// <summary>検（検品区分）</summary>
        private const string TextInspectStatusCaption = "検（検品区分）";
        /// <summary>検品区分名</summary>
        private const string TextInspectStNameCaption = "検品区分名";
        /// <summary>検品（検品処理方法）</summary>
        private const string TextHandTerminalCodeCaption = "検品（検品処理方法）";
        /// <summary>検品処理方法名</summary>
        private const string TextHandTerminalNameCaption = "検品処理方法名";
        /// <summary>取引（検品対象区分）</summary>
        private const string TextTransactionCaption = "取引（検品対象区分）";
        /// <summary>伝票番号</summary>
        private const string TextSalesSlipNumCaption = "伝票番号";
        /// <summary>行番号</summary>
        private const string TextSalesRowNoCaption = "行番号";
        /// <summary>検品担当者コード</summary>
        private const string TextEmployeeCodeCaption = "検品担当者コード";
        /// <summary>検品担当者名</summary>
        private const string TextEmployeeNameCaption = "検品担当者名";
        /// <summary>商品メーカーコード</summary>
        private const string TextGoodsMakerCdCaption = "商品メーカーコード";
        /// <summary>メーカー（メーカー名）</summary>
        private const string TextGoodsMakerNameCaption = "メーカー名";
        /// <summary>品番</summary>
        private const string TextGoodsNoCaption = "品番";
        /// <summary>品名</summary>
        private const string TextGoodsNameCaption = "品名";
        /// <summary>倉庫コード</summary>
        private const string TextWarehouseCodeCaption = "倉庫コード";
        /// <summary>倉庫名</summary>
        private const string TextWarehouseNameCaption = "倉庫名";
        /// <summary>棚番</summary>
        private const string TextWarehouseShelfNoCaption = "棚番";
        /// <summary>仕入先/得意先/相手先倉庫</summary>
        private const string TextCustNmWareNmCaption = "仕入先/得意先/相手先倉庫";
        /// <summary>出庫数</summary>
        private const string TextShipmentCntCaption = "出庫数";
        /// <summary>入庫数</summary>
        private const string TextInputCntCaption = "入庫数";
        // テキスト出力用テーブル名
        private const string TextOutputInspectTable = "TextOutputInspectTable";
        // テキスト出力用テーブルのカラム
        private const string ShipmentDayCol = "TextShipmentDay";
        private const string InspectCol = "TextInspectDate";
        private const string InspectTimeCol = "TextInspectTime";
        private const string InspectStatusCol = "TextInspectStatus";
        private const string InspectStNameCol = "TextInspectStName";
        private const string HandTerminalCodeCol = "TextHandTerminalCode";
        private const string HandTerminalNameCol = "TextHandTerminalName";
        private const string TransactionCol = "TextTransaction";
        private const string SalesSlipNumCol = "TextSalesSlipNum";
        private const string SalesRowNoCol = "TextSalesRowNo";
        private const string EmployeeCodeCol = "TextEmployeeCode";
        private const string EmployeeNameCol = "TextEmployeeName";
        private const string GoodsMakerCdCol = "TextGoodsMakerCd";
        private const string GoodsMakerNameCol = "TextGoodsMakerName";
        private const string GoodsNoCol = "TextGoodsNo";
        private const string GoodsNameCol = "TextGoodsName";
        private const string WarehouseCodeCol = "TextWarehouseCode";
        private const string WarehouseNameCol = "TextWarehouseName";
        private const string WarehouseShelfNoCol = "TextWarehouseShelfNo";
        private const string CustNmWareNmCol = "TextCustNmWareNm";
        private const string ShipmentCntCol = "TextShipmentCnt";
        private const string InputCntCol = "TextInputCnt";
        /// <summary>1:検品中</summary>
        private const string InspectDuring = "検品中";
        /// <summary>2:ピッキング済み</summary>
        private const string InspectAlreadyPicking = "ピッキング済み";
        /// <summary>3:検品済み</summary>
        private const string InspectAlreadyInspected = "検品済み";
        /// <summary>0:未検品</summary>
        private const string Inspect = "未検品";
        /// <summary>テキスト出力用</summary>
        private DataTable TextOutputTable = null;

        private int OptTextOutput;

        #endregion　テキスト出力
        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority _operationAuthority;
        
        /// <summary>操作権限の制御オブジェクト</summary>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateReferenceOperationAuthority("PMHND04200U", this);
                }
                return _operationAuthority;
            }
        }

        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
        # endregion

        #region ◆Constractor

        /// <summary>
        /// 検品照会フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検品照会フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        public PMHND04201UA()
        {
            InitializeComponent();
            // コントロール部品スキンを設定します。
            this.ControlScreenSkinAccessor = new ControlScreenSkin();
            // コントロール部品イメージを設定します。
            this.ImageList16 = IconResourceManagement.ImageList16;
            // 企業コードを取得します。
            this.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 検品アクセスクラスを初期化します。
            this.InspectInfoAccessor = InspectInfoAcs.GetInstance();
            // 従業員マスタデータキャッシューします。
            int status = this.InspectInfoAccessor.ReadEmployee();
            // 従業員マスタ情報を取得できない場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(EmployeeSearchError, status);
                this.Close();
            }
            // 拠点アクセスクラスを初期化します。
            this.SecInfoSetAccessor = new SecInfoSetAcs();
            // 拠点マスタデータキャッシューします。
            status = this.GetSecInfo();

            // 拠点情報を取得できない場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(SecInfoSearchError, status);
                this.Close();
            }

            // 従業員情報を取得できる場合
            if (LoginInfoAcquisition.Employee != null)
            {
                // 従業員情報を設定します。
                this.LoginEmployee = LoginInfoAcquisition.Employee.Clone();
                // ログイン拠点コードを設定します。
                this.LoginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                // ログイン拠点名を設定します。
                this.LoginSectionName = this.getSectionName(this.LoginSectionCode);
            }
            
            // 倉庫アクセスクラスを初期化します。
            this.WarehouseAccessor = new WarehouseAcs();
            // 倉庫マスタデータキャッシューします。
            status = this.GetWarehouseInfo();

            // 倉庫情報を取得できない場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(WarehouseInfoSearchError, status);
                this.Close();
            }

            // 従業員アクセスクラスを初期化します。
            this.EmployeeAccessor = new EmployeeAcs();
            // 日付アクセスクラスを初期化します。
            this.DateGetAccessor = DateGetAcs.GetInstance();

            // メーカーアクセスクラスを初期化します。
            this.MakerAccessor = new MakerAcs();
            // メーカーマスタデータキャッシューします。
            status = this.GetGoodsMakerInfo();

            // メーカー情報を取得できない場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(GoodsMakerInfoSearchError, status);
                this.Close();
            }

            // 端末設定アクセスクラスを初期化します。
            this.PosTerminalMgAccessor = new PosTerminalMgAcs();
            // 端末情報を検索します。
            status = this.PosTerminalMgAccessor.Search(out this.PosTerminalMgData, this.EnterpriseCode);
            // 端末情報を取得できない場合
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ErrMsgDispProc(PosTerminalInfoSearchError, status);
                this.Close();
            }
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // オプションコード
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus stockSlipPs;
            // OP検品管理（仕入業務プラス）[OPT-PM02410]
            stockSlipPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_HND_InspMng_Stock);
            // OP検品管理（仕入業務プラス）[OPT-PM02410]=1の場合
            if (stockSlipPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                HaveStockSlipPs = true;
            }

            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            this.UserSetting = new PrevInputValue();
            #region ● テキスト出力オプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus textOutputPs;
            textOutputPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (textOutputPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this.OptTextOutput = (int)Option.ON;
            }
            else
            {
                this.OptTextOutput = (int)Option.OFF;
            }
            //テキスト出力オプションが有効の場合
            if (this.OptTextOutput == (int)Option.ON)
            {
                // テキスト出力
                this.tToolsManager_MainMenu.Tools[ButtonToolTextOut].SharedProps.Visible = true;

            }
            //テキスト出力オプションが無効の場合
            else
            {
                // テキスト出力
                this.tToolsManager_MainMenu.Tools[ButtonToolTextOut].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[ButtonToolTextOut].SharedProps.Shortcut = Shortcut.None;
            }

            // 取消(F8)
            if (MyOpeCtrl.Disabled(3))
            {
                this.tToolsManager_MainMenu.Tools[ButtonToolDelete].SharedProps.Visible = false;
                this.tToolsManager_MainMenu.Tools[ButtonToolDelete].SharedProps.Shortcut = Shortcut.None;
                this.CheckEditor_Inspected.Visible = false;
            }
            #endregion
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

        }
        #endregion

        #region ◆ControlEvent

        /// <summary>
        /// Form.Load イベント (PMHND04201U)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが表示されるときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        private void PMHND04201UA_Load(object sender, EventArgs e)
        {
            // 画面を構築
            this.ScreenInitialSetting();
            this.ScreenClear();
            this.Deserialize();// ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応
        }

        /// <summary>
        ///	Control.ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカス移動時に発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;
            Control NextControl = null;

            switch (e.PrevCtrl.Name)
            {
                #region ●グリッド内フォーカス移動
                case "Inspect_Grid":
                    {
                        NextControl = this.GetInspectFormFocus(e);
                        if (this.Inspect_Grid.ActiveRow != null && e.NextCtrl != null && e.NextCtrl.Name.IndexOf(Toolbars) < 0)
                        {
                            this.Inspect_Grid.ActiveRow.Selected = false;
                            this.Inspect_Grid.ActiveRow = null;
                        }
                        break;
                    }
                #endregion

                #region ●倉庫コード
                case "tEdit_WarehouseCode":
                    {
                        #region < 編集チェック >
                        // 変数保持
                        string warehouseCode = this.tEdit_WarehouseCode.Text.Trim();

                        if (this.PrevWarehouseCode == warehouseCode)
                        {
                            // 編集前と同じなら処理を行なわない
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                            break;
                        }
                        #endregion

                        #region < 倉庫検索 >
                        if (!string.IsNullOrEmpty(warehouseCode))
                        {
                            string warehouseName = this.getWarehouseName(warehouseCode.PadLeft(PadLeftIndexFour, CharZero));

                            if (string.IsNullOrEmpty(warehouseName))
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    WarehouseInfoEmptyError,
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tEdit_WarehouseCode.Text = this.PrevWarehouseCode;
                                this.tEdit_WarehouseCode.SelectAll();
                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                                #endregion
                            }
                            else
                            {
                                this.tEdit_WarehouseCode.Text = warehouseCode.PadLeft(PadLeftIndexFour, CharZero);
                                this.lb_WarehouseName.Text = warehouseName;
                                // カーソル制御
                                NextControl = this.GetInspectFormFocus(e);
                            }
                        }
                        else
                        {
                            this.tEdit_WarehouseCode.Clear();
                            this.lb_WarehouseName.Text = string.Empty;
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                        }
                        #endregion

                        #region < 編集前データ保持 >
                        // 編集された親商品情報を編集前データとして保持
                        this.PrevWarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                        this.PrevWarehouseName = this.lb_WarehouseName.Text.Trim();
                        #endregion

                        break;
                    }

                #endregion
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                #region ●委託先倉庫コード
                case "tEdit_AfWarehouseCode":
                    {
                        #region < 編集チェック >
                        // 変数保持
                        string afWarehouseCode = this.tEdit_AfWarehouseCode.Text.Trim();

                        if (this.PrevAfWarehouseCode == afWarehouseCode)
                        {
                            // 編集前と同じなら処理を行なわない
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                            break;
                        }
                        #endregion

                        #region < 倉庫検索 >
                        if (!string.IsNullOrEmpty(afWarehouseCode))
                        {
                            string afWarehouseName = this.getWarehouseName(afWarehouseCode.PadLeft(PadLeftIndexFour, CharZero));

                            if (string.IsNullOrEmpty(afWarehouseName))
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    AfWarehouseInfoEmptyError,
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tEdit_AfWarehouseCode.Text = this.PrevAfWarehouseCode;
                                this.tEdit_AfWarehouseCode.SelectAll();
                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                                #endregion
                            }
                            else
                            {
                                this.tEdit_AfWarehouseCode.Text = afWarehouseCode.PadLeft(PadLeftIndexFour, CharZero);
                                this.lb_AfWarehouseName.Text = afWarehouseName;
                                // カーソル制御
                                NextControl = this.GetInspectFormFocus(e);
                            }
                        }
                        else
                        {
                            this.tEdit_AfWarehouseCode.Clear();
                            this.lb_AfWarehouseName.Text = string.Empty;
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                        }
                        #endregion

                        #region < 編集前データ保持 >
                        // 編集された親商品情報を編集前データとして保持
                        this.PrevAfWarehouseCode = this.tEdit_AfWarehouseCode.Text.Trim();
                        this.PrevAfWarehouseName = this.lb_AfWarehouseName.Text.Trim();
                        #endregion

                        break;
                    }
                #endregion
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                #region ●拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        #region < 編集チェック >
                        // 変数保持
                        string sectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();

                        if (this.PrevSectionCode == sectionCode)
                        {
                            if (string.IsNullOrEmpty(sectionCode))
                            {
                                this.tEdit_SectionCodeAllowZero.Text = StringZZ;
                                this.lb_SectionName.Text = WholeCompany;
                            }
                            // 編集前と同じなら処理を行なわない
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                            break;
                        }
                        #endregion

                        #region < 拠点検索 >
                        if (!string.IsNullOrEmpty(sectionCode))
                        {
                            string sectionName = this.getSectionName(sectionCode.PadLeft(PadLeftIndexTwo, CharZero));

                            if (string.IsNullOrEmpty(sectionName))
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    SecInfoEmptyError,
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tEdit_SectionCodeAllowZero.Text = this.PrevSectionCode;
                                this.tEdit_SectionCodeAllowZero.SelectAll();
                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                                #endregion
                            }
                            else
                            {
                                this.tEdit_SectionCodeAllowZero.Text = sectionCode.PadLeft(PadLeftIndexTwo, CharZero);
                                this.lb_SectionName.Text = sectionName;
                                // カーソル制御
                                NextControl = this.GetInspectFormFocus(e);
                            }
                        }
                        else
                        {
                            this.tEdit_SectionCodeAllowZero.Text = StringZZ;
                            this.lb_SectionName.Text = WholeCompany;
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                        }
                        #endregion

                        #region < 編集前データ保持 >
                        // 編集された親商品情報を編集前データとして保持
                        this.PrevSectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                        this.PrevSectionName = this.lb_SectionName.Text.Trim();
                        #endregion

                        break;
                    }

                #endregion

                #region ●メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        #region < 編集チェック >
                        // 変数保持
                        string goodsMakerCd = this.tNedit_GoodsMakerCd.GetInt().ToString();

                        if (this.PrevGoodsMakerCode == goodsMakerCd)
                        {
                            if (goodsMakerCd == StringZero)
                            {
                                this.tNedit_GoodsMakerCd.Clear();
                                this.lb_GoodsMakerName.Text = string.Empty;
                            }
                            // 編集前と同じなら処理を行なわない
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                            break;
                        }
                        #endregion

                        #region < メーカー検索 >
                        if (goodsMakerCd != StringZero)
                        {
                            string goodsMakerName = this.getGoodsMakerName(goodsMakerCd);

                            if (string.IsNullOrEmpty(goodsMakerName))
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    GoodsMakerInfoEmptyError,
                                    -1,
                                    MessageBoxButtons.OK);

                                if (!string.IsNullOrEmpty(this.PrevGoodsMakerCode))
                                {
                                    this.tNedit_GoodsMakerCd.SetInt(int.Parse(this.PrevGoodsMakerCode));
                                }
                                else
                                {
                                    this.tNedit_GoodsMakerCd.Clear();
                                }

                                this.tNedit_GoodsMakerCd.SelectAll();
                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                                #endregion
                            }
                            else
                            {
                                this.tNedit_GoodsMakerCd.SetInt(int.Parse(goodsMakerCd));
                                this.lb_GoodsMakerName.Text = goodsMakerName;
                                // カーソル制御
                                NextControl = this.GetInspectFormFocus(e);
                            }
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.Clear();
                            this.lb_GoodsMakerName.Text = string.Empty;
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                        }
                        #endregion

                        #region < 編集前データ保持 >
                        // 編集された親商品情報を編集前データとして保持
                        this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                        this.PrevGoodsMakerName = this.lb_GoodsMakerName.Text.Trim();
                        #endregion

                        break;
                    }

                #endregion

                #region ●従業員
                case "tEdit_EmployeeCode":
                    {
                        #region < 編集チェック >
                        // 変数保持
                        string inspectEmployee = this.tEdit_EmployeeCode.Text.Trim();

                        if (this.PrevEmployeeCode == inspectEmployee)
                        {
                            // 編集前と同じなら処理を行なわない
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                            break;
                        }
                        #endregion

                        #region < 従業員検索 >
                        if (!string.IsNullOrEmpty(inspectEmployee))
                        {
                            string inspectEmployeeName = this.InspectInfoAccessor.GetEmployeeName(inspectEmployee.PadLeft(PadLeftIndexFour, CharZero));

                            if (string.IsNullOrEmpty(inspectEmployeeName))
                            {
                                #region -- 取得失敗 --
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    EmployeeInfoEmptyError,
                                    -1,
                                    MessageBoxButtons.OK);

                                this.tEdit_EmployeeCode.Text = this.PrevEmployeeCode;
                                this.tEdit_EmployeeCode.SelectAll();
                                // カーソル制御
                                e.NextCtrl = e.PrevCtrl;
                                #endregion
                            }
                            else
                            {
                                this.tEdit_EmployeeCode.Text = inspectEmployee.PadLeft(PadLeftIndexFour, CharZero);
                                this.lb_InspectEmployeeName.Text = inspectEmployeeName;
                                // カーソル制御
                                NextControl = this.GetInspectFormFocus(e);
                            }
                        }
                        else
                        {
                            this.tEdit_EmployeeCode.Clear();
                            this.lb_InspectEmployeeName.Text = string.Empty;
                            // カーソル制御
                            NextControl = this.GetInspectFormFocus(e);
                        }
                        #endregion

                        #region < 編集前データ保持 >
                        // 編集された親商品情報を編集前データとして保持
                        this.PrevEmployeeCode = this.tEdit_EmployeeCode.Text.Trim();
                        this.PrevEmployeeName = this.lb_InspectEmployeeName.Text.Trim();
                        #endregion

                        break;
                    }

                #endregion

                #region ●検品日開始
                case "tDate_InspectDayBegin":

                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_InspectDayBegin.GetDateYear() == 0 || this.tDate_InspectDayBegin.GetDateMonth() == 0 || this.tDate_InspectDayBegin.GetDateDay() == 0)
                    {
                        this.tDate_InspectDayBegin.Clear();
                    }

                    NextControl = this.GetInspectFormFocus(e);
                    break;
                #endregion

                #region ●検品日終了
                case "tDate_InspectDayEnd":

                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_InspectDayEnd.GetDateYear() == 0 || this.tDate_InspectDayEnd.GetDateMonth() == 0 || this.tDate_InspectDayEnd.GetDateDay() == 0)
                    {
                        this.tDate_InspectDayEnd.Clear();
                    }
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    NextControl = this.GetInspectFormFocus(e);
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    break;
                #endregion

                #region ●入出荷日開始
                case "tDate_IoGoodsDayBegin":

                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_IoGoodsDayBegin.GetDateYear() == 0 || this.tDate_IoGoodsDayBegin.GetDateMonth() == 0 || this.tDate_IoGoodsDayBegin.GetDateDay() == 0)
                    {
                        this.tDate_IoGoodsDayBegin.Clear();
                    }
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    NextControl = this.GetInspectFormFocus(e);
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    break;
                #endregion

                #region ●入出荷日終了
                case "tDate_IoGoodsDayEnd":

                    // 数字以外を入力する場合、クリアする
                    if (this.tDate_IoGoodsDayEnd.GetDateYear() == 0 || this.tDate_IoGoodsDayEnd.GetDateMonth() == 0 || this.tDate_IoGoodsDayEnd.GetDateDay() == 0)
                    {
                        this.tDate_IoGoodsDayEnd.Clear();
                    }
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    NextControl = this.GetInspectFormFocus(e);
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    break;
                #endregion

                #region ほかのフォーカス補正処理
                case "tComboEditor_ToRiyoSe":
                case "tEdit_SeachStr":
                case "CheckEditor_Inspected":// ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応
                case "CheckEditor_Inspect":
                    NextControl = this.GetInspectFormFocus(e);

                    if (NextControl == this.Inspect_Grid)
                    {
                        this.Inspect_Grid.ActiveRow = this.Inspect_Grid.Rows[0];
                        this.Inspect_Grid.ActiveRow.Selected = true;
                    }

                    break;
                case "CheckEditor_Sales":
                case "CheckEditor_Rental":
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                case "CheckEditor_MoveOutWarehouse":
                case "CheckEditor_ReplenishOutWarehouse":
                case "CheckEditor_StockStockSlip":
                case "CheckEditor_StockSlip":
                case "CheckEditor_MoveInWarehouse":
                case "ub_WarehouseGuide":
                case "ub_SectionGuide":
                case "ub_AfWarehouseGuide":
                case "ub_InspectEmployee":  
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                case "tEdit_GoodsNo":
                case "ub_GoodsMakerCd":
                    NextControl = this.GetInspectFormFocus(e);
                    break;
                #endregion
            }

            // フォーカス補正コントロールがある場合
            if (NextControl != null)
            {
                e.NextCtrl = NextControl;
            }
        }

        /// <summary>
        /// パターン値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : パターン値変更イベント時に発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        private void tComboEditor_Pattern_ValueChanged(object sender, EventArgs e)
        {
            // --- DEL 3H 張小磊 2017/09/07---------->>>>>
            //if ((int)this.tComboEditor_Pattern.Value == ComboEditorPatternInspectOnly)
            //{
            //    this.CheckEditor_Sales.Checked = true;
            //    this.CheckEditor_Sales.Enabled = false;

            //    this.CheckEditor_Rental.Checked = true;
            //    this.CheckEditor_Rental.Enabled = false;

            //    this.tDate_IoGoodsDayBegin.Clear();
            //    this.tDate_IoGoodsDayEnd.Clear();
            //    this.tDate_IoGoodsDayBegin.Enabled = false;
            //    this.tDate_IoGoodsDayEnd.Enabled = false;
            //}
            //else
            //{
            //    this.tDate_IoGoodsDayBegin.Enabled = true;
            //    this.tDate_IoGoodsDayEnd.Enabled = true;

            //    // 入出荷日⇒システム日付セット
            //    DateTime dateTime = DateTime.Now;
            //    if (this.tDate_IoGoodsDayBegin.GetLongDate() == LongDateZero)
            //    {
            //        this.tDate_IoGoodsDayBegin.SetDateTime(dateTime);
            //    }
            //    if (this.tDate_IoGoodsDayEnd.GetLongDate() == LongDateZero)
            //    {
            //        this.tDate_IoGoodsDayEnd.SetDateTime(dateTime);
            //    }

            //    this.CheckEditor_Sales.Enabled = true;
            //    this.CheckEditor_Rental.Enabled = true;
            //}
            // --- DEL 3H 張小磊 2017/09/07----------<<<<<
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // パターン:出庫検品
            if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
            {
                // 取引対象_売上
                this.CheckEditor_Sales.Enabled = true;
                // 取引対象_貸出
                this.CheckEditor_Rental.Enabled = true;
                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Enabled = true;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Enabled = true;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Enabled = true;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Enabled = true;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Enabled = false;

                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Checked = false;

                // 入出荷日_開始
                this.tDate_IoGoodsDayBegin.Enabled = true;
                // 入出荷日_終了
                this.tDate_IoGoodsDayEnd.Enabled = true;

                // 入出荷日⇒システム日付セット
                DateTime dateTime = DateTime.Now;
                // 入出荷日_開始
                if (this.tDate_IoGoodsDayBegin.GetLongDate() == LongDateZero)
                {
                    this.tDate_IoGoodsDayBegin.SetDateTime(dateTime);
                }
                // 入出荷日_終了
                if (this.tDate_IoGoodsDayEnd.GetLongDate() == LongDateZero)
                {
                    this.tDate_IoGoodsDayEnd.SetDateTime(dateTime);
                }
                // 検品日_開始
                this.tDate_InspectDayBegin.Enabled = true;
                // 検品日_終了
                this.tDate_InspectDayEnd.Enabled = true;
                // 検品担当者コード
                this.tEdit_EmployeeCode.Enabled = true;
                // 検品担当者ガイド
                this.ub_InspectEmployee.Enabled = true;

                if (CheckEditor_ReplenishOutWarehouse.Checked)
                {
                    // 委託先倉庫コードと委託先倉庫ガイドを入力可にする。
                    tEdit_AfWarehouseCode.Enabled = true;
                    ub_AfWarehouseGuide.Enabled = true;
                }
                else
                {
                    // 委託先倉庫コードとガイドををグレーアウトさせて入力不可にする。
                    tEdit_AfWarehouseCode.Enabled = false;
                    ub_AfWarehouseGuide.Enabled = false;
                    tEdit_AfWarehouseCode.Text = string.Empty;
                    lb_AfWarehouseName.Text = string.Empty;
                }
            }
            // パターン:入庫検品
            else if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
            {
                // 取引対象_売上
                this.CheckEditor_Sales.Enabled = true;
                // 取引対象_貸出
                this.CheckEditor_Rental.Enabled = true;
                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Enabled = false;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Enabled = false;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Enabled = true;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Enabled = true;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Enabled = true;

                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Checked = false;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Checked = false;

                // 入出荷日_開始
                this.tDate_IoGoodsDayBegin.Enabled = true;
                // 入出荷日_終了
                this.tDate_IoGoodsDayEnd.Enabled = true;

                // 入出荷日⇒システム日付セット
                DateTime dateTime = DateTime.Now;
                // 入出荷日_開始
                if (this.tDate_IoGoodsDayBegin.GetLongDate() == LongDateZero)
                {
                    this.tDate_IoGoodsDayBegin.SetDateTime(dateTime);
                }
                // 入出荷日_終了
                if (this.tDate_IoGoodsDayEnd.GetLongDate() == LongDateZero)
                {
                    this.tDate_IoGoodsDayEnd.SetDateTime(dateTime);
                }
                // 検品日_開始
                this.tDate_InspectDayBegin.Enabled = true;
                // 検品日_終了
                this.tDate_InspectDayEnd.Enabled = true;
                // 検品担当者コード
                this.tEdit_EmployeeCode.Enabled = true;
                // 検品担当者ガイド
                this.ub_InspectEmployee.Enabled = true;
                // 委託先倉庫
                tEdit_AfWarehouseCode.Enabled = false;
                ub_AfWarehouseGuide.Enabled = false;
            }
            // パターン:未入庫
            else if ((int)this.tComboEditor_Pattern.Value == PatternValue2)
            {
                // 取引対象_売上
                this.CheckEditor_Sales.Enabled = false;
                // 取引対象_貸出
                this.CheckEditor_Rental.Enabled = false;
                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Enabled = false;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Enabled = false;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Enabled = false;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Enabled = false;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Enabled = false;

                // 取引対象_売上
                this.CheckEditor_Sales.Checked = false;
                // 取引対象_貸出
                this.CheckEditor_Rental.Checked = false;
                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Checked = false;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Checked = false;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Checked = false;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Checked = true;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Checked = false;

                // 入出荷日_開始
                this.tDate_IoGoodsDayBegin.Enabled = true;
                // 入出荷日_終了
                this.tDate_IoGoodsDayEnd.Enabled = true;

                // 入出荷日⇒システム日付セット
                DateTime dateTime = DateTime.Now;
                // 入出荷日_開始
                if (this.tDate_IoGoodsDayBegin.GetLongDate() == LongDateZero)
                {
                    this.tDate_IoGoodsDayBegin.SetDateTime(dateTime);
                }
                // 入出荷日_終了
                if (this.tDate_IoGoodsDayEnd.GetLongDate() == LongDateZero)
                {
                    this.tDate_IoGoodsDayEnd.SetDateTime(dateTime);
                }

                // 検品日_開始
                this.tDate_InspectDayBegin.Enabled = false;
                // 検品日_終了
                this.tDate_InspectDayEnd.Enabled = false;
                // 検品担当者コード
                this.tEdit_EmployeeCode.Enabled = false;
                // 検品担当者ガイド
                this.ub_InspectEmployee.Enabled = false;

                // 検品日_開始
                this.tDate_InspectDayBegin.Clear();
                // 検品日_終了
                this.tDate_InspectDayEnd.Clear();
                // 検品担当者コード
                this.tEdit_EmployeeCode.Text = string.Empty;
                // 検品担当者名
                this.lb_InspectEmployeeName.Text = string.Empty;
                // 委託先倉庫
                tEdit_AfWarehouseCode.Enabled = false;
                ub_AfWarehouseGuide.Enabled = false;
            }
            // パターン:検品のみ
            else
            {
                // 取引対象_売上
                this.CheckEditor_Sales.Enabled = false;
                // 取引対象_貸出
                this.CheckEditor_Rental.Enabled = false;
                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Enabled = false;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Enabled = false;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Enabled = false;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Enabled = false;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Enabled = false;

                // 取引対象_売上
                this.CheckEditor_Sales.Checked = true;
                // --- DEL 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                //// 取引対象_貸出
                //this.CheckEditor_Rental.Checked = true;
                // --- DEL 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                // 取引対象_貸出
                this.CheckEditor_Rental.Checked = false;
                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Checked = false;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Checked = false;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Checked = false;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Checked = false;
                if (HaveStockSlipPs)
                {
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                    // 取引対象_仕入
                    this.CheckEditor_StockSlip.Checked = true;
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                }
                else
                {
                    // 取引対象_仕入
                    this.CheckEditor_StockSlip.Checked = false;
                }
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

                // 入出荷日_開始
                this.tDate_IoGoodsDayBegin.Enabled = false;
                // 入出荷日_終了
                this.tDate_IoGoodsDayEnd.Enabled = false;
                // 入出荷日_開始
                this.tDate_IoGoodsDayBegin.Clear();
                // 入出荷日_終了
                this.tDate_IoGoodsDayEnd.Clear();

                // 検品日_開始
                this.tDate_InspectDayBegin.Enabled = true;
                // 検品日_終了
                this.tDate_InspectDayEnd.Enabled = true;
                // 検品担当者コード
                this.tEdit_EmployeeCode.Enabled = true;
                // 検品担当者ガイド
                this.ub_InspectEmployee.Enabled = true;

                // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                // 委託先倉庫
                //tEdit_AfWarehouseCode.Enabled = true;
                //ub_AfWarehouseGuide.Enabled = true;
                tEdit_AfWarehouseCode.Enabled = false;
                ub_AfWarehouseGuide.Enabled = false;
                // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
            }
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
        }

        /// <summary>
        /// 検索文字列値変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 検索文字列値変更イベント時に発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        private void tEdit_SeachStr_TextChanged(object sender, EventArgs e)
        {
            string filter = string.Empty;

            string searchStr = this.tEdit_SeachStr.Text.Trim();

            if (this.CheckEditor_Inspect.Checked)
            {
                if (string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetCheckedRowFilter();
                }
                else
                {
                    filter = this.GetAllRowFilter(searchStr);
                }
                this.DataViewInspect.RowFilter = filter;
            }
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            else if (this.CheckEditor_Inspected.Checked)
            {
                if (string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetInspectedRowFilter();
                }
                else
                {

                    filter = GetInspectedAllRowFilter(searchStr);
                }
                this.DataViewInspect.RowFilter = filter;
            }
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
            else
            {
                if (string.IsNullOrEmpty(searchStr))
                {
                    this.DataViewInspect.RowFilter = string.Empty;
                }
                else
                {
                    filter = this.GetSearchStrRowFilter(searchStr);
                    this.DataViewInspect.RowFilter = filter;
                }
            }

            this.SetTotalCountProc();
        }

        /// <summary>
        /// メインメニュークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メインメニューをクリックした際に発生するイベントハンドラ</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // 処理中、再処理不可
            // IsSaveFlgがTrueの場合、処理不可。IsSaveFlgがFalseの場合、処理可
            if (this.IsSaveFlg)
            {
                return;
            }
            this.IsSaveFlg = true;

            #region 各処理前、フォーカスアウト補正処理
            Control ActiveControl = this.GetActiveControl();
            if (ActiveControl != null)
            {
                if (ActiveControl != this.Inspect_Grid)
                {
                    ChangeFocusEventArgs ex = new ChangeFocusEventArgs(false, false, false, Keys.Right, this.GetActiveControl(), this.uGroupBox_ExtractInfo);
                    this.tArrowKeyControl1_ChangeFocus(sender, ex);
                }
                else
                {
                    this.uGroupBox_ExtractInfo.Focus();
                    this.Inspect_Grid.Focus();
                }
            }
            #endregion

            try
            {
                switch (e.Tool.Key)
                {
                    #region 終了(F1)
                    case "ButtonTool_Close":
                        {
                            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                            if (this.Inspect_Grid.ActiveCell != null)
                            {
                                this.Inspect_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            // 画面変更確認処理
                            if (this.CheckScreenChange())
                            {
                                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                                //取消可能チェックOFFの場合
                                if (!this.CheckEditor_Inspected.Checked)
                                {
                                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                                    // 明細グリッドに「選択」欄が一個以上選択されている場合、終了ボタンを押すと、以下確認ダイアログを表示する。
                                    DialogResult Dialog = this.QuestionYesNoCancelProc(BeforeCloseQuestionMessage);

                                    // はい(Y)ボタン：手動検品データの登録処理を行い
                                    if (Dialog == DialogResult.Yes)
                                    {
                                        ArrayList HandyInspectList = new ArrayList();

                                        // 登録前処理
                                        if (this.BeforeSaveProc(out HandyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            return;
                                        }

                                        // 登録処理
                                        ArrayList DelHandyInspectList = null;
                                        if (this.SaveProc(DelHandyInspectList, HandyInspectList, RegistModeManualInspect) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            return;
                                        }

                                        // 終了処理
                                        this.Close();
                                    }
                                    // いいえ(N)ボタン：何もせずに、照会画面を閉じる
                                    else if (Dialog == DialogResult.No)
                                    {
                                        // 終了処理
                                        this.Close();
                                    }
                                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                                }
                                else
                                {
                                    //取消可能チェックONの場合
                                    DialogResult Dialog = this.QuestionYesNoCancelProc2(BeforeClearQuestionMessage);
                                    // はい(Y)ボタン：検品データの取消処理を行う
                                    if (Dialog == DialogResult.Yes)
                                    {
                                        ArrayList handyInspectList = new ArrayList();
                                        // 取消前処理
                                        if (this.BeforeDeleteProc(out handyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            return;
                                        }
                                        // 取消処理
                                        if (this.DeleteProc(handyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            return;
                                        }
                                        // 終了処理
                                        this.Close();
                                    }
                                    // いいえ(N)ボタン：何もせずに、照会画面を閉じる
                                    else if (Dialog == DialogResult.No)
                                    {
                                        // 終了処理
                                        this.Close();
                                    }
                                }
                            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                            }
                            else
                            {
                                // 終了処理
                                this.Close();
                            }

                            break;
                        }
                    #endregion

                    #region 確定(F10)
                    case "ButtonTool_OK":
                        {
                            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                            if (this.Inspect_Grid.ActiveCell != null)
                            {
                                this.Inspect_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            ArrayList HandyInspectList = new ArrayList();

                            // 確定前処理
                            if (this.BeforeSaveProc(out HandyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return;
                            }

                            // 確定処理
                            ArrayList DelHandyInspectList = null;
                            if (this.SaveProc(DelHandyInspectList, HandyInspectList, RegistModeManualInspect) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return;
                            }

                            // 登録後、再検索します。
                            // 入力項目チェック処理
                            if (!this.CheckInputPara())
                            {
                                return;
                            }

                            // 再検索します。
                            this.SearchProc();

                            break;
                        }
                    #endregion

                    #region 検索(F2)
                    case "ButtonTool_Search":
                        {
                            // 入力項目チェック処理
                            if (!this.CheckInputPara())
                            {
                                return;
                            }

                            // 検索処理
                            this.SearchProc();

                            break;
                        }
                    #endregion

                    #region クリア(F9)
                    case "ButtonTool_Clear":
                        {
                            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                            if (this.Inspect_Grid.ActiveCell != null)
                            {
                                this.Inspect_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            // 画面変更確認処理
                            if (this.CheckScreenChange())
                            {
                                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                                // 取消可能チェックOFFの場合
                                if (!this.CheckEditor_Inspected.Checked)
                                {
                                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                                    // 明細グリッドに「選択」欄が一個以上選択されている場合、終了ボタンを押すと、以下確認ダイアログを表示する。
                                    DialogResult Dialog = this.QuestionYesNoCancelProc(BeforeCloseQuestionMessage);

                                    // はい(Y)ボタン：手動検品データの登録処理を行い、照会画面を初期表示にする
                                    if (Dialog == DialogResult.Yes)
                                    {
                                        ArrayList HandyInspectList = new ArrayList();

                                        // 確定前処理
                                        if (this.BeforeSaveProc(out HandyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            return;
                                        }

                                        // 確定処理
                                        ArrayList DelHandyInspectList = null;
                                        if (this.SaveProc(DelHandyInspectList, HandyInspectList, RegistModeManualInspect) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            return;
                                        }

                                        // 終了処理
                                        this.ScreenClear();
                                        this.tComboEditor_ToRiyoSe.Focus();
                                    }
                                    // いいえ(N)ボタン：何もせずに、照会画面を初期表示にする。
                                    else if (Dialog == DialogResult.No)
                                    {
                                        // 終了処理
                                        this.ScreenClear();
                                        this.tComboEditor_ToRiyoSe.Focus();
                                    }
                                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                                }
                                else
                                {
                                    // 取消可能チェクONの場合
                                    DialogResult Dialog = this.QuestionYesNoCancelProc2(BeforeClearQuestionMessage);

                                    // はい(Y)ボタン：検品データの取消処理を行い、照会画面を初期表示にする
                                    if (Dialog == DialogResult.Yes)
                                    {
                                        ArrayList handyInspectList = new ArrayList();
                                        // 取消前処理
                                        if (this.BeforeDeleteProc(out handyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            return;
                                        }
                                        // 取消処理
                                        if (this.DeleteProc(handyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            return;
                                        }
                                        // クリア処理
                                        this.ScreenClear();
                                        this.tComboEditor_ToRiyoSe.Focus();
                                    }
                                    // いいえ(N)ボタン：何もせずに、照会画面を初期表示にする。
                                    else if (Dialog == DialogResult.No)
                                    {
                                        // クリア処理
                                        this.ScreenClear();
                                        this.tComboEditor_ToRiyoSe.Focus();
                                    }
                                }
                            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                            }
                            // キャンセルボタン：何もせずに、照会画面へ戻る。
                            else
                            {
                                // 終了処理
                                this.ScreenClear();
                                this.tComboEditor_ToRiyoSe.Focus();
                            }

                            break;
                        }
                    #endregion

                    #region 検品引当(F5)
                    case "ButtonTool_InspectUpd":
                        {
                            // 検品引当前処理
                            ArrayList DelHandyInspectList = new ArrayList();
                            ArrayList HandyInspectList = new ArrayList();
                            if (this.BeforeUpdateProc(out DelHandyInspectList, out HandyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return;
                            }

                            // 検品引当処理
                            if (this.SaveProc(DelHandyInspectList, HandyInspectList, RegistModeAllocPreInspect) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return;
                            }

                            // 登録後、再検索します。
                            // 入力項目チェック処理
                            if (!this.CheckInputPara())
                            {
                                return;
                            }

                            // 再検索します。
                            this.SearchProc();

                            break;

                        }
                    #endregion

                    #region 検品表示(F3)
                    case "ButtonTool_Show":
                        {
                            // 検品表示処理
                            this.ShowProc();
                            break;
                        }
                    #endregion
                    // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                    #region 取消(F8)
                    case "ButtonTool_Delete":
                        {
                            // セル編集後に直接ボタンクリックを行なうとセルの編集が発生しないため
                            if (this.Inspect_Grid.ActiveCell != null)
                            {
                                this.Inspect_Grid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                            }

                            ArrayList handyInspectList = new ArrayList();

                            // 確定前処理
                            if (this.BeforeDeleteProc(out handyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return;
                            }

                            // 取消処理
                            if (this.DeleteProc(handyInspectList) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return;
                            }

                            // 登録後、再検索します。
                             this.SearchProc();
                            break;
                        }
                    #endregion
                    #region テキスト出力(T)
                    case "ButtonTool_TextOut":
                        {
                            // テキスト出力処理の確認ダイアログ
                            BeforeTextOutputDialog dialogResult = new BeforeTextOutputDialog();

                            DialogResult Dialog = dialogResult.ShowDialog();

                            if (Dialog == DialogResult.Yes)
                            {
                                this.ExportIntoTextFile();                       
                            }
                            break;
                        }
                    #endregion
                    // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                }
            }
            finally
            {
                this.IsSaveFlg = false;
            }
        }


        /// <summary>
        /// 拠点ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 拠点ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void ub_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                SecInfoSet SecInfoSetWork;
                int Status = this.SecInfoSetAccessor.ExecuteGuid(this.EnterpriseCode, true, out SecInfoSetWork);

                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.tEdit_SectionCodeAllowZero.Text = SecInfoSetWork.SectionCode.Trim();
                    this.lb_SectionName.Text = SecInfoSetWork.SectionGuideNm.Trim();

                    #region < 編集前データ保持 >
                    // 編集された親商品情報を編集前データとして保持
                    this.PrevSectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
                    this.PrevSectionName = this.lb_SectionName.Text.Trim();
                    #endregion

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 倉庫ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void ub_WarehouseGuide_Click(object sender, EventArgs e)
        {
            try
            {
                Warehouse WarehouseWork;
                int Status = this.WarehouseAccessor.ExecuteGuid(out WarehouseWork, this.EnterpriseCode);

                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.tEdit_WarehouseCode.Text = WarehouseWork.WarehouseCode.Trim();
                    this.lb_WarehouseName.Text = WarehouseWork.WarehouseName.Trim();

                    #region < 編集前データ保持 >
                    // 編集された親商品情報を編集前データとして保持
                    this.PrevWarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
                    this.PrevWarehouseName = this.lb_WarehouseName.Text.Trim();
                    #endregion

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// メーカーガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : メーカーガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void ub_GoodsMakerCd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt MakerUMntWork;

                int Status = this.MakerAccessor.ExecuteGuid(this.EnterpriseCode, out MakerUMntWork);
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 結果セット
                    this.tNedit_GoodsMakerCd.SetInt(MakerUMntWork.GoodsMakerCd);
                    this.lb_GoodsMakerName.Text = MakerUMntWork.MakerName;

                    #region < 編集前データ保持 >
                    // 編集された親商品情報を編集前データとして保持
                    this.PrevGoodsMakerCode = this.tNedit_GoodsMakerCd.GetInt().ToString();
                    this.PrevGoodsMakerName = this.lb_GoodsMakerName.Text.Trim();
                    #endregion

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 検品担当者ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 検品担当者ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void ub_InspectEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // ガイド表示
                Employee EmployeeInfoWork;
                int Status;
                Status = this.EmployeeAccessor.ExecuteGuid(this.EnterpriseCode, true, out EmployeeInfoWork);

                // ステータスが正常の場合
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コードと名称をセット
                    this.tEdit_EmployeeCode.Text = EmployeeInfoWork.EmployeeCode.TrimEnd();
                    this.lb_InspectEmployeeName.Text = EmployeeInfoWork.Name.TrimEnd();

                    #region < 編集前データ保持 >
                    // 編集された親商品情報を編集前データとして保持
                    this.PrevEmployeeCode = this.tEdit_EmployeeCode.Text.Trim();
                    this.PrevEmployeeName = this.lb_InspectEmployeeName.Text.Trim();
                    #endregion

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// グリッド　マウスクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド　マウスクリックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void Inspect_Grid_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Inspect_Grid.ActiveRow == null || this.Inspect_Grid.ActiveCell == null) return;
            if (e.Button != MouseButtons.Left) return;

            int RowIndex = this.Inspect_Grid.ActiveCell.Row.Index;

            if (this.Inspect_Grid.ActiveCell == this.Inspect_Grid.Rows[RowIndex].Cells[this.InspectDs.InspectList.SelectFlagColumn.ColumnName])
            {
                this.SetGridRowChecked(RowIndex);
            }

            this.Inspect_Grid.ActiveRow.Selected = true;

        }

        /// <summary>
        /// グリッドの選択チェック処理
        /// </summary>
        ///  <param name="rowIndex">選択チェック対象行インデックス</param>
        /// <remarks>
        /// <br>Note       : グリッドの選択チェックを設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        private void SetGridRowChecked(int rowIndex)
        {
            string InspectStatusDisp = (string)this.Inspect_Grid.Rows[rowIndex].Cells[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].Value;
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            string AcPaySlipCd = (string)this.Inspect_Grid.Rows[rowIndex].Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value;
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            int rowNo = int.Parse((string)this.Inspect_Grid.Rows[rowIndex].Cells[this.InspectDs.InspectList.SalesRowNoColumn.ColumnName].Value);// ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応
            // --- DEL 3H 張小磊 2017/09/07---------->>>>>
            //if (!StringHoshi.Equals(InspectStatusDisp) && !StringCheck.Equals(InspectStatusDisp) && !StringCircle.Equals(InspectStatusDisp))
            // --- DEL 3H 張小磊 2017/09/07----------<<<<<
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            if (!this.CheckEditor_Inspected.Checked)
            {
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                if (!StringHoshi.Equals(InspectStatusDisp) && !StringCheck.Equals(InspectStatusDisp) && !StringCircle.Equals(InspectStatusDisp) && !AcPaySlipCdAccession.ToString().Equals(AcPaySlipCd))
                {
                    if ((bool)this.Inspect_Grid.Rows[rowIndex].Cells[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Value)
                    {
                        this.Inspect_Grid.Rows[rowIndex].Cells[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Value = false;
                    }
                    else
                    {
                        this.Inspect_Grid.Rows[rowIndex].Cells[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Value = true;
                    }
                }
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            }
            else
            {
                if ((StringCheck.Equals(InspectStatusDisp) ||
                     StringHoshi.Equals(InspectStatusDisp) ||
                     StringCircle.Equals(InspectStatusDisp)) &&
                    ((AcPaySlipCdEarnings.ToString().Equals(AcPaySlipCd) ||
                    AcPaySlipCdRental.ToString().Equals(AcPaySlipCd) ||
                    AcPaySlipCdMovementShipping.ToString().Equals(AcPaySlipCd) ||
                    AcPaySlipCdMovingStock.ToString().Equals(AcPaySlipCd) ||
                    AcPaySlipCdReplenish.ToString().Equals(AcPaySlipCd)) ||
                    (AcPaySlipCdStock.ToString().Equals(AcPaySlipCd) &&
                    (rowNo == 0))))
                {
                    if ((bool)this.Inspect_Grid.Rows[rowIndex].Cells[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Value)
                    {
                        this.Inspect_Grid.Rows[rowIndex].Cells[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Value = false;
                    }
                    else
                    {
                        this.Inspect_Grid.Rows[rowIndex].Cells[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Value = true;
                    }
                }
            }
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

        }

        /// <summary>
        /// グリッド　キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド　キーダウンイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void Inspect_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Inspect_Grid.ActiveRow == null) return;

            int RowIndex = this.Inspect_Grid.ActiveRow.Index;

            if (e.KeyCode == Keys.Space)
            {
                this.SetGridRowChecked(RowIndex);
            }
            else if ((this.Inspect_Grid.ActiveRow.Index == ActiveRowIndexZero && e.KeyCode == Keys.Up))
            {
                this.tEdit_SeachStr.Focus();
                this.Inspect_Grid.ActiveRow.Selected = false;
                this.Inspect_Grid.ActiveRow = null;

            }
        }

        /// <summary>
        /// グリッド　セルアクティブ前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : グリッド　セルアクティブ前イベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void Inspect_Grid_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            if (this.Inspect_Grid.ActiveRow == null) return;
            this.Inspect_Grid.ActiveRow.Selected = true;
        }

        /// <summary>
        /// 未検品チェックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 未検品チェックイベント。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        private void CheckEditor_Inspect_CheckedChanged(object sender, EventArgs e)
        {
            string Filter = string.Empty;
            string SearchStr = this.tEdit_SeachStr.Text.Trim();

            if (this.CheckEditor_Inspect.Checked)
            {
                this.CheckEditor_Inspected.Checked = false; // ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応
                if (string.IsNullOrEmpty(SearchStr))
                {
                    Filter = this.GetCheckedRowFilter();
                }
                else
                {

                    Filter = GetAllRowFilter(SearchStr);
                }
                this.DataViewInspect.RowFilter = Filter;
            }
            else
            {
                if (string.IsNullOrEmpty(SearchStr))
                {
                    this.DataViewInspect.RowFilter = string.Empty;
                }
                else
                {
                    Filter = this.GetSearchStrRowFilter(SearchStr);
                    this.DataViewInspect.RowFilter = Filter;
                }
            }

            this.SetTotalCountProc();
        }
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        /// <summary>
        /// 検品画面設定値シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検品画面設定値シリアライズを行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(UserSetting, Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検品画面設定値デシリアライズを行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        public void Deserialize()
        {
            PrevInputValue data = new PrevInputValue();
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    data = UserSettingController.DeserializeUserSetting<PrevInputValue>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                    // 取寄区分
                    this.tComboEditor_ToRiyoSe.SelectedIndex = data.OrderDivCd;
                    // パターン区分
                    if (!HaveStockSlipPs && data.PatternDiv == PatternValue3)
                    {
                        this.tComboEditor_Pattern.SelectedIndex = PatternValue2;
                    }
                    else
                    {
                        this.tComboEditor_Pattern.SelectedIndex = data.PatternDiv;
                    }

                    if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
                    {
                        // 取引対象_移動入庫
                        this.CheckEditor_MoveInWarehouse.Checked = true;
                    }

                }
                catch
                {
                    data = new PrevInputValue();
                }
          
            }
        }

        /// <summary>
        /// 明細データ取得処理
        /// </summary>
        /// <param name="filter">対象条件</param>
        /// <remarks>
        /// <br>Note       : 明細データを取得する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void GetFilter(out string filter)
        {
            filter = string.Empty;
            string searchStr = this.tEdit_SeachStr.Text.Trim();
            if (this.CheckEditor_Inspected.Checked)
            {
                if (string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetInspectedRowFilter();
                }
                else
                {

                    filter = GetInspectedAllRowFilter(searchStr);
                }
            }
            else  if (this.CheckEditor_Inspect.Checked)
            {
                if (string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetCheckedRowFilter();
                }
                else
                {

                    filter = GetAllRowFilter(searchStr);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetSearchStrRowFilter(searchStr);
                }
            }
        }

        /// <summary>
        /// 検品済みチェックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 検品済みチェックイベント。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void CheckEditor_Inspected_CheckedChanged(object sender, EventArgs e)
        {
            string filter = string.Empty;
            string searchStr = this.tEdit_SeachStr.Text.Trim();
            if (this.CheckEditor_Inspected.Checked)
            {
                this.CheckEditor_Inspect.Checked = false;
                this.tToolsManager_MainMenu.Tools[ButtonToolDelete].SharedProps.Enabled = true;
                if (string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetInspectedRowFilter();
                }
                else
                {

                    filter = GetInspectedAllRowFilter(searchStr);
                }
                this.DataViewInspect.RowFilter = filter;
            }
            else if (this.CheckEditor_Inspect.Checked)
            {
                this.CheckEditor_Inspected.Checked = false;
                this.tToolsManager_MainMenu.Tools[ButtonToolDelete].SharedProps.Enabled = false;
                if (string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetCheckedRowFilter();
                }
                else
                {

                    filter = GetAllRowFilter(searchStr);
                }
                this.DataViewInspect.RowFilter = filter;
                SelectFlagSetting();
            }
            else
            {
                this.tToolsManager_MainMenu.Tools[ButtonToolDelete].SharedProps.Enabled = false;
                if (string.IsNullOrEmpty(searchStr))
                {
                    this.DataViewInspect.RowFilter = string.Empty;
                }
                else
                {
                    filter = this.GetSearchStrRowFilter(searchStr);
                    this.DataViewInspect.RowFilter = filter;
                }

                SelectFlagSetting();
            }
            this.SetTotalCountProc();
        }

        /// <summary>
        /// 「取消可能」チェックOFFした場合、 選択チェックもOFFの設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 「取消可能」チェックOFFした場合、 選択チェックもOFFを設定処理する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void SelectFlagSetting()
        {
            string filter1 = string.Empty;
            string searchStr = this.tEdit_SeachStr.Text.Trim();
            if (string.IsNullOrEmpty(searchStr))
            {
                filter1 = this.GetInspectedRowFilter();
            }
            else
            {

                filter1 = GetInspectedAllRowFilter(searchStr);
            }
            string filter2 = string.Format(" {0}='{1}'",
                        this.InspectDs.InspectList.SelectFlagColumn, true);
            if (!filter1.Equals(string.Empty))
            {
                filter2 = string.Format(" AND {0}='{1}'",
                        this.InspectDs.InspectList.SelectFlagColumn, true);
            }

            InspectDataSet.InspectListRow[] inspectListRow =
                (InspectDataSet.InspectListRow[])this.InspectDs.InspectList.Select(filter1 + filter2);
            foreach (InspectDataSet.InspectListRow row in inspectListRow)
            {
                //「取消可能」チェックOFFした場合、 選択チェックもOFFの設定
                if (row.SelectFlag)
                {
                    row.SelectFlag = false;
                }
            }
        }

        /// <summary>
        /// 検品済みチェック行フィルタ文字列の取得処理。
        /// </summary>
        /// <returns>検品済みチェック行フィルタ文字列</returns>
        /// <remarks>
        /// <br>Note       : 検品済みチェック行フィルタ文字列を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private string GetInspectedRowFilter()
        {
            return string.Format(" ({0} ='{1}' OR {0} ='{2}' OR {0} ='{3}') AND (({4} = {5} OR {6} = {7} OR {8} = {9} OR {10} = {11} OR {12} = {13}) "
                                     + " OR ({14} = {15} AND {16} = {17})) ",
                                   this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName, StringCheck,StringHoshi,StringCircle,
                                   this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdEarnings,
                                   this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdRental,
                                   this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdMovementShipping,
                                   this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdReplenish,
                                   this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdMovingStock,
                                   this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdStock,
                                   this.InspectDs.InspectList.SalesRowNoColumn.ColumnName, 0);
        }

        /// <summary>\
        /// 検品済み行検索フィルタ文字列の取得処理。
        /// </summary>
        /// <param name="searchStr">検索文字列</param>
        /// <returns>検品済み行検索フィルタ文字列</returns>
        /// <remarks>
        /// <br>Note       : 検品済み行検索フィルタ文字列を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private string GetInspectedAllRowFilter(string searchStr)
        {
            return string.Format(" ({0} like '%{1}%' OR {2} like '%{3}%' OR {4} like '%{5}%' "
                                     + " OR {6} like '%{7}%' OR {8} like '%{9}%' OR {10} like '%{11}%' "
                                     + " OR {12} like '%{13}%' OR {14} like '%{15}%' OR {16} like '%{17}%' "
                                     + " OR {18} like '%{19}%' OR {20} like '%{21}%' OR {22} like '%{23}%' "
                                     + " OR {24} like '%{25}%' OR {26} like '%{27}%' OR {28} like '%{29}%') "
                                     + " AND ({30} = '{31}' OR {30} = '{32}' OR {30} = '{33}') "
                                     + " AND (({34} = {35} OR {36} = {37} OR {38} = {39} OR {40} = {41} OR {42} = {43}) "
                                     + " OR ({44} = {45} AND {46} = {47})) ",
                                        this.InspectDs.InspectList.InspectStatusDispColumn, searchStr,
                                        this.InspectDs.InspectList.HandTerminalCodeDispColumn, searchStr,
                                        this.InspectDs.InspectList.GoodsMakerNameColumn, searchStr,
                                        this.InspectDs.InspectList.GoodsNoColumn, searchStr,
                                        this.InspectDs.InspectList.GoodsNameColumn, searchStr,
                                        this.InspectDs.InspectList.InputCntColumn, searchStr,
                                        this.InspectDs.InspectList.ShipmentCntColumn, searchStr,
                                        this.InspectDs.InspectList.WarehouseShelfNoColumn, searchStr,
                                        this.InspectDs.InspectList.CustNmWareNmColumn, searchStr,
                                        this.InspectDs.InspectList.TransactionColumn, searchStr,
                                        this.InspectDs.InspectList.SalesSlipNumColumn, searchStr,
                                        this.InspectDs.InspectList.EmployeeCodeColumn, searchStr,
                                        this.InspectDs.InspectList.InspectDateColumn, searchStr,
                                        this.InspectDs.InspectList.InspectTimeColumn, searchStr,
                                        this.InspectDs.InspectList.ShipmentDayColumn.ColumnName, searchStr,
                                        this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName, StringCheck,StringHoshi,StringCircle,
                                        this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdEarnings,
                                        this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdRental,
                                        this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdMovementShipping,
                                        this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdReplenish,
                                        this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdMovingStock,
                                        this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName, AcPaySlipCdStock,
                                        this.InspectDs.InspectList.SalesRowNoColumn.ColumnName, 0);
        }

        /// <summary>
        /// 取消前処理
        /// </summary>
        /// <param name="handyInspectList">取消用情報リスト</param>
        /// <returns>結果[0: 正常, 0以外: 異常]</returns>
        /// <remarks>
        /// <br>Note       : 検品情報の取消前処理を行ないます。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private int BeforeDeleteProc(out ArrayList handyInspectList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            handyInspectList = new ArrayList();
            string searchStr = this.tEdit_SeachStr.Text.Trim();

            try
            {
                string filter = string.Empty;
                if (string.IsNullOrEmpty(searchStr))
                {
                    filter = this.GetInspectedRowFilter();
                }
                else
                {

                    filter = GetInspectedAllRowFilter(searchStr);
                }
                string filter2 = string.Format(" AND {0}='{1}'",
                            this.InspectDs.InspectList.SelectFlagColumn, true);
                InspectDataSet.InspectListRow[] inspectListRow =
                    (InspectDataSet.InspectListRow[])this.InspectDs.InspectList.Select(filter + filter2);

                // 明細グリッドに「選択」欄が一個も選択されていない場合は以下のメッセージを表示する。
                if (inspectListRow.Length == 0)
                {
                    this.InfoMsgDispProc(BeforeDeleteNoSelectError, StatusNormal);
                    return status;
                }

                // 検品取消処理の確認ダイアログ
                DialogResult Dialog = this.QuestionYesNoProc(BeforeDeleteQuestionMessage);

                if (Dialog == DialogResult.Yes)
                {
                    // 検品登録のパラメータを準備します。
                    HandyInspectDataWork paraInspectDataWork = null;
                    foreach (InspectDataSet.InspectListRow row in inspectListRow)
                    {
                        paraInspectDataWork = new HandyInspectDataWork();
                        // 企業コード
                        paraInspectDataWork.EnterpriseCode = this.EnterpriseCode;
                        // 受払元伝票区分
                        paraInspectDataWork.AcPaySlipCd = int.Parse(row.AcPaySlipCd);
                        // 受払元取引区分
                        paraInspectDataWork.AcPayTransCd = int.Parse(row.AcPayTransCd);
                        // 受払元伝票区分
                        paraInspectDataWork.AcPaySlipNum = (string)row.SalesSlipNumHF;
                        // 受払元行番号⇒明細グリッド.行番号
                        paraInspectDataWork.AcPaySlipRowNo = int.Parse(row.SalesRowNo);
                        handyInspectList.Add(paraInspectDataWork);

                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.ErrMsgDispProc(InspectInfoSearchError, status);
            }
            return status;
        }

        /// <summary>
        /// 検品済み行の取消処理。
        /// </summary>
        /// <param name="handyInspectList">取消用情報リスト</param>
        /// <returns>検品済み行検索フィルタ文字列</returns>
        /// <remarks>
        /// <br>Note       : 検品済み行を取消します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private int DeleteProc(ArrayList handyInspectList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errMessage = string.Empty;
            object paraInspectDataObj = (object)handyInspectList;
            status = this.InspectInfoAccessor.DeleteInspectData(paraInspectDataObj, out errMessage);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録完了
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);

            }
            else
            {
                this.ErrMsgDispProc(InspectDeleteError, status);
            }

            return status;
        }
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

        /// <summary>
        /// フォントサイズ値変更
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォントサイズの値が変更された時に発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void FontSize_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // フォントサイズを変更
            this.Inspect_Grid.DisplayLayout.Appearance.FontData.SizeInPoints = (int)FontSize_tComboEditor.Value;
        }

        /// <summary>
        /// 列サイズの自動調整チェック変更
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 列サイズの自動調整のチェックが変更された時に発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void AutoFitCol_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            // 列サイズの自動調整
            if (this.AutoFitCol_ultraCheckEditor.Checked)
                this.Inspect_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            else
                this.Inspect_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn wkColumn in this.Inspect_Grid.DisplayLayout.Bands[0].Columns)
            {
                wkColumn.PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
            }
        }

        /// <summary>
        /// フォーム閉じる処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void PMHND04201UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.BeforeClosing();
            }
            catch
            {
                // エラーメッセージ表示
                this.ErrMsgDispProc(ColDisplayStatusSaveError, StatusError);

            }
        }

        /// <summary>
        /// フォーカス補正処理
        /// </summary>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカス移動の補正処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        /// <returns>フォーカス補正コントロール</returns>
        private Control GetInspectFormFocus(ChangeFocusEventArgs e)
        {
            Control NextControl = null;
            if (e == null || e.PrevCtrl == null) return null;

            switch (e.PrevCtrl.Name)
            {
                #region 取寄
                case "tComboEditor_ToRiyoSe":

                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        if (this.Inspect_Grid.Rows.Count > InspectGridRowsCountZero)
                        {
                            NextControl = this.Inspect_Grid;
                        }
                        else
                        {
                            NextControl = this.CheckEditor_Inspect;
                        }
                    }
                    break;
                #endregion

                // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                //#region 検品日(開始)
                //case "tDate_InspectDayBegin":

                //    if (e.Key == Keys.Down)
                //    {
                //        NextControl = this.ub_SectionGuide;
                //    }
                //    break;
                //#endregion
                // --- DEL 3H 張小磊 2017/09/07----------<<<<<

                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                #region 検品日(開始)
                case "tDate_InspectDayBegin":
                    if (e.Key == Keys.Down)
                    {
                        if (HaveStockSlipPs)
                        {
                            if (tEdit_EmployeeCode.Enabled)
                            {
                                NextControl = tEdit_EmployeeCode;
                            }
                            else
                            {
                                NextControl = this.ub_SectionGuide;
                            }
                        }
                        else 
                        {
                            NextControl = this.ub_SectionGuide;
                        }
                    }
                    break;
                #endregion

                #region 検品日(終了)
                case "tDate_InspectDayEnd":
                    if (e.Key == Keys.Down)
                    {
                        if (HaveStockSlipPs)
                        {
                            if (tEdit_EmployeeCode.Enabled)
                            {
                                NextControl = tEdit_EmployeeCode;
                            }
                            else
                            {
                                NextControl = this.ub_SectionGuide;
                            }
                        }
                        else
                        {
                            NextControl = this.ub_SectionGuide;
                        }
                    }
                    break;
                #endregion

                #region 入出荷日(開始)
                case "tDate_IoGoodsDayBegin":
                    if (e.Key == Keys.Down)
                    {
                        if (!this.tDate_InspectDayBegin.Enabled)
                        {
                            NextControl = this.tComboEditor_Pattern;
                        }
                    }
                    break;
                #endregion

                #region 入出荷日(終了)
                case "tDate_IoGoodsDayEnd":
                    if (e.Key == Keys.Down)
                    {
                        if (!this.tDate_InspectDayEnd.Enabled)
                        {
                            NextControl = this.tComboEditor_Pattern;
                        }
                    }
                    break;
                #endregion
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                #region 品番*
                case "tEdit_GoodsNo":
                    // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                    //if (!e.ShiftKey && e.Key == Keys.Down)
                    //{
                    //    if (this.CheckEditor_Sales.Enabled)
                    //    {
                    //        NextControl = this.CheckEditor_Rental;
                    //    }
                    //    else
                    //    {
                    //        NextControl = this.tEdit_SeachStr;
                    //    }
                    //}
                    //else if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    //{
                    //    if (this.CheckEditor_Sales.Enabled)
                    //    {
                    //        NextControl = this.CheckEditor_Sales;
                    //    }
                    //    else
                    //    {
                    //        NextControl = this.tEdit_SeachStr;
                    //    }
                    //}
                    // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
                    {
                        // ﾊﾟﾀｰﾝ  0:出庫検品 or 1:入庫検品
                        if ((int)this.tComboEditor_Pattern.Value == PatternValue0 || (int)this.tComboEditor_Pattern.Value == PatternValue1)
                        {
                            // 取引対象_売上
                            NextControl = this.CheckEditor_Sales;
                        }
                        // ﾊﾟﾀｰﾝ  2:未入庫
                        else if ((int)this.tComboEditor_Pattern.Value == PatternValue2)
                        {
                            // 検索文字列
                            NextControl = this.tEdit_SeachStr;
                        }
                        // ﾊﾟﾀｰﾝ  3:検品のみ
                        else if ((int)this.tComboEditor_Pattern.Value == PatternValue3)
                        {
                            // 検索文字列
                            NextControl = this.tEdit_SeachStr;
                        }
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab)) || e.Key == Keys.Left)
                    {
                        // メーカーガイド
                        NextControl = this.ub_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        if (HaveStockSlipPs)
                        {
                            if (tEdit_AfWarehouseCode.Enabled)
                            {
                                // 委託先倉庫
                                NextControl = this.tEdit_AfWarehouseCode;
                            }
                            else if (this.tEdit_EmployeeCode.Enabled)
                            {
                                // 検品担当者
                                NextControl = this.tEdit_EmployeeCode;
                            }
                            else if (this.tDate_InspectDayBegin.Enabled)
                            {
                                // 検品日
                                NextControl = this.tDate_InspectDayBegin;
                            }
                            else
                            {
                                // 入出荷日
                                NextControl = this.tDate_IoGoodsDayBegin;
                            }
                        }
                        else
                        {
                            // ﾊﾟﾀｰﾝ  0:出庫検品 or 1:入庫検品 or 3:検品のみ
                            if ((int)this.tComboEditor_Pattern.Value == PatternValue0 || (int)this.tComboEditor_Pattern.Value == PatternValue1
                                || (int)this.tComboEditor_Pattern.Value == PatternValue3)
                            {
                                // 検品担当者コード
                                NextControl = this.tEdit_EmployeeCode;
                            }
                            // 2:未入庫
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue2)
                            {
                                // 倉庫ガイド
                                NextControl = this.ub_WarehouseGuide;
                            }
                        }
                    }
                    else if (e.Key == Keys.Right)
                    {
                        // ﾊﾟﾀｰﾝ  0:出庫検品 or 1:入庫検品 or 3:検品のみ
                        if ((int)this.tComboEditor_Pattern.Value == PatternValue0 || (int)this.tComboEditor_Pattern.Value == PatternValue1
                            || (int)this.tComboEditor_Pattern.Value == PatternValue3)
                        {
                            // 検品日終了_年
                            NextControl = this.tDate_InspectDayEnd;
                        }
                        // 2:未入庫
                        else if ((int)this.tComboEditor_Pattern.Value == PatternValue2)
                        {
                            // 入出荷日終了_年
                            NextControl = this.tDate_IoGoodsDayEnd;
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        if (HaveStockSlipPs)
                        {
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                            //// ﾊﾟﾀｰﾝ  0:出庫検品 or 2:未入庫
                            //if ((int)this.tComboEditor_Pattern.Value == PatternValue0 || (int)this.tComboEditor_Pattern.Value == PatternValue2)
                            // ﾊﾟﾀｰﾝ  0:出庫検品 
                            if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                            {
                                // 取引対象_仕入
                                NextControl = this.CheckEditor_StockSlip;
                            }
                            // ﾊﾟﾀｰﾝ  1:入庫検品
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
                            {
                                // 取引対象_在庫仕入
                                NextControl = this.CheckEditor_StockStockSlip;
                            }
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                            //// ﾊﾟﾀｰﾝ  3:検品のみ
                            //else if ((int)this.tComboEditor_Pattern.Value == PatternValue3)
                            // ﾊﾟﾀｰﾝ  3:検品のみ  or 2:未入庫
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue3 || (int)this.tComboEditor_Pattern.Value == PatternValue2)
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                            {
                                // 検索文字列
                                NextControl = this.tEdit_SeachStr;
                            }
                        }
                        else
                        {
                            // ﾊﾟﾀｰﾝ  0:出庫検品 or 2:未入庫
                            if ((int)this.tComboEditor_Pattern.Value == PatternValue0 || (int)this.tComboEditor_Pattern.Value == PatternValue1)
                            {
                                // 取引対象_貸出
                                NextControl = this.CheckEditor_Rental;
                            }
                            // ﾊﾟﾀｰﾝ  3:検品のみ
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue3)
                            {
                                // 検索文字列
                                NextControl = this.tEdit_SeachStr;
                            }
                        }
                    }
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    break;
                #endregion

                #region メーカーガイドボタン
                case "tNedit_GoodsMakerCd":
                    // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                    //if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    //{
                    //    NextControl = this.ub_InspectEmployee;
                    //}
                    //else if (e.Key == Keys.Down)
                    //{
                    //    if (this.CheckEditor_Sales.Enabled)
                    //    {
                    //        NextControl = this.CheckEditor_Sales;
                    //    }
                    //    else
                    //    {
                    //        NextControl = this.tEdit_SeachStr;
                    //    }
                    //}
                    //else if (e.Key == Keys.Tab || e.Key == Keys.Return)
                    //{
                    //    if (this.tNedit_GoodsMakerCd.GetInt() != GoodsMakerCdZero)
                    //    {
                    //        NextControl = this.tEdit_GoodsNo;
                    //    }
                    //    else
                    //    {
                    //        NextControl = this.ub_GoodsMakerCd;
                    //    }
                    //}
                    // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
                    {
                        if (this.tNedit_GoodsMakerCd.GetInt() != GoodsMakerCdZero)
                        {
                            // 品番*
                            NextControl = this.tEdit_GoodsNo;
                        }
                        else
                        {
                            // メーカーガイド
                            NextControl = this.ub_GoodsMakerCd;
                        }
                    }
                    else if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (HaveStockSlipPs)
                        {
                            if (this.ub_AfWarehouseGuide.Enabled)
                            {
                                // 委託先倉庫ガイド
                                NextControl = this.ub_AfWarehouseGuide;
                            }
                            else
                            {
                                // 倉庫ガイド
                                NextControl = this.ub_WarehouseGuide;
                            }
                        }
                        else
                        {
                            if (this.ub_InspectEmployee.Enabled)
                            {
                                // 検品担当者ガイド
                                NextControl = this.ub_InspectEmployee;
                            }
                            else
                            {
                                // 倉庫ガイド
                                NextControl = this.ub_WarehouseGuide;
                            }
                        }
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // 倉庫コード
                        NextControl = this.tEdit_WarehouseCode;
                    }
                    else if (e.Key == Keys.Right)
                    {
                        // メーカーガイド
                        NextControl = this.ub_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        // ﾊﾟﾀｰﾝ  0:出庫検品
                        if ((int)this.tComboEditor_Pattern.Value == PatternValue0 || (int)this.tComboEditor_Pattern.Value == PatternValue1)
                        {
                            // 取引対象_売上
                            NextControl = this.CheckEditor_Sales;
                        }
                        // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                        //// ﾊﾟﾀｰﾝ  2:未入庫
                        //else if ((int)this.tComboEditor_Pattern.Value == PatternValue2)
                        //{
                        //    // 取引対象_仕入
                        //    NextControl = this.CheckEditor_StockSlip;
                        //}
                        //// ﾊﾟﾀｰﾝ  3:検品のみ
                        //else if ((int)this.tComboEditor_Pattern.Value == PatternValue3)
                        // ﾊﾟﾀｰﾝ  2:未入庫  3:検品のみ
                        else if ((int)this.tComboEditor_Pattern.Value == PatternValue3 || (int)this.tComboEditor_Pattern.Value == PatternValue2)
                        // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                        {
                            // 検索文字列
                            NextControl = this.tEdit_SeachStr;
                        }
                    }
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    break;
                #endregion
                
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                #region メーカーガイドボタン
                case "ub_GoodsMakerCd":
                    if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab || e.Key == Keys.Right))
                    {
                        // 品番*
                        NextControl = this.tEdit_GoodsNo;
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        // メーカーコード
                        NextControl = this.tNedit_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // 倉庫ガイド
                        NextControl = this.ub_WarehouseGuide;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        if (HaveStockSlipPs)
                        {
                            // ﾊﾟﾀｰﾝ  0:出庫検品
                            if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
                            {
                                // 取引対象_移動出庫
                                NextControl = this.CheckEditor_MoveOutWarehouse;
                            }
                            // ﾊﾟﾀｰﾝ  1:入庫検品
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
                            {
                                // 取引対象_貸出
                                NextControl = this.CheckEditor_Rental;
                            }
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                            //// ﾊﾟﾀｰﾝ  2:未入庫
                            //else if ((int)this.tComboEditor_Pattern.Value == PatternValue2)
                            //{
                            //    // 取引対象_仕入
                            //    NextControl = this.CheckEditor_StockSlip;
                            //}
                            //// ﾊﾟﾀｰﾝ  3:検品のみ
                            //else if ((int)this.tComboEditor_Pattern.Value == PatternValue3)
                            // ﾊﾟﾀｰﾝ  3:検品のみ 2:未入庫
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue3 || (int)this.tComboEditor_Pattern.Value == PatternValue2)
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                            {
                                // 検索文字列
                                NextControl = this.tEdit_SeachStr;
                            }
                        }
                        else
                        {
                            if (this.CheckEditor_Rental.Enabled)
                            {
                                // 取引対象_貸出
                                NextControl = this.CheckEditor_Rental;
                            }
                            else
                            {
                                // 検索文字列
                                NextControl = this.tEdit_SeachStr;
                            }
                        }
                    }
                    break;
                #endregion
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                #region 拠点コード
                case "tEdit_SectionCodeAllowZero":

                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        if (this.tDate_InspectDayEnd.Enabled)
                        {
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                            NextControl = this.tDate_InspectDayEnd;
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        }
                        else
                        {
                            // ﾊﾟﾀｰﾝ 
                            NextControl = this.tComboEditor_Pattern;
                        }
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    }
                    else if (e.Key == Keys.Up)
                    {
                        NextControl = this.tComboEditor_Pattern;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        NextControl = this.tEdit_WarehouseCode;
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Return)
                    {
                        if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                        {
                            NextControl = this.ub_SectionGuide;
                        }
                        else
                        {
                            //NextControl = this.tEdit_WarehouseCode; // --- DEL 3H 張小磊 2017/09/07
                            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                            if (HaveStockSlipPs)
                            {
                                // 検品担当者
                                if (tEdit_EmployeeCode.Enabled)
                                {
                                    NextControl = this.tEdit_EmployeeCode;
                                }
                            }
                            else
                            {
                                // 倉庫
                                NextControl = this.tEdit_WarehouseCode;
                            }
                            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                        }
                    }
                    break;
                #endregion

                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                #region 拠点ガイドボタン
                case "ub_SectionGuide":
                    if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
                    {
                        if (HaveStockSlipPs)
                        {
                            // 検品担当者
                            if (tEdit_EmployeeCode.Enabled)
                            {
                                NextControl = this.tEdit_EmployeeCode;
                            }
                        }
                        else
                        {
                            // 倉庫コード
                            NextControl = this.tEdit_WarehouseCode;
                        }
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        // 拠点コード
                        NextControl = this.tEdit_SectionCodeAllowZero;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // ﾊﾟﾀｰﾝ
                        NextControl = this.tComboEditor_Pattern;
                    }
                    else if (e.Key == Keys.Right)
                    {
                        if (HaveStockSlipPs)
                        {
                            // 検品担当者
                            if (this.tEdit_EmployeeCode.Enabled)
                            {
                                NextControl = this.tEdit_EmployeeCode;
                            }
                            // 委託先倉庫
                            else if (tEdit_AfWarehouseCode.Enabled)
                            {
                                NextControl = this.tEdit_AfWarehouseCode;
                            }
                            else 
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                        else
                        {
                            if (this.tEdit_EmployeeCode.Enabled)
                            {
                                // 検品担当者コード
                                NextControl = this.tEdit_EmployeeCode;
                            }
                            else
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        // 倉庫ガイド
                        NextControl = this.ub_WarehouseGuide;
                    }
                    break;
                #endregion
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                #region 倉庫コード
                case "tEdit_WarehouseCode":

                    if (!e.ShiftKey && e.Key == Keys.Up)
                    {
                        NextControl = this.tEdit_SectionCodeAllowZero;
                    }
                    else if (!e.ShiftKey && e.Key == Keys.Down)
                    {
                        NextControl = this.tNedit_GoodsMakerCd;
                    }
                    else if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        if (string.IsNullOrEmpty(this.tEdit_WarehouseCode.Text.Trim()))
                        {
                            NextControl = this.ub_WarehouseGuide;
                        }
                        else
                        {
                            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                            if (HaveStockSlipPs)
                            {
                                if (this.tEdit_AfWarehouseCode.Enabled)
                                {
                                    // 委託先倉庫
                                    NextControl = this.tEdit_AfWarehouseCode;
                                }
                                else
                                {
                                    // メーカーコード
                                    NextControl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            else 
                            {
                                if (this.tEdit_EmployeeCode.Enabled)
                                {
                                    // 検品担当者
                                    NextControl = this.tEdit_EmployeeCode;
                                   
                                }
                                else
                                {
                                    // メーカーコード
                                    NextControl = this.tNedit_GoodsMakerCd;
                                }

                            }
                            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                            // NextControl = this.tEdit_EmployeeCode; // --- DEL 3H 張小磊 2017/09/07
                        }
                    }
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    else if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return)) 
                    {
                        if (HaveStockSlipPs)
                        {
                            if (this.ub_InspectEmployee.Enabled)
                            {
                                // 検品担当者
                                NextControl = this.ub_InspectEmployee;
                            }
                            else
                            {
                                // 拠点ガイド
                                NextControl = this.ub_SectionGuide;
                            }
                        }
                    }
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    break;
                #endregion

                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                #region 倉庫ガイドボタン
                case "ub_WarehouseGuide":
                    if (!e.ShiftKey && (e.Key == Keys.Enter || e.Key == Keys.Tab))
                    {
                        if (HaveStockSlipPs)
                        {
                            if (this.tEdit_AfWarehouseCode.Enabled)
                            {
                                // 委託先倉庫
                                NextControl = this.tEdit_AfWarehouseCode;
                            }
                            else
                            {
                                // メーカーコード
                                NextControl = this.tNedit_GoodsMakerCd;
                            }

                        }
                        else
                        {
                            if (this.tEdit_EmployeeCode.Enabled)
                            {
                                // 検品担当者コード
                                NextControl = this.tEdit_EmployeeCode;
                            }
                            else
                            {
                                // メーカーコード
                                NextControl = this.tNedit_GoodsMakerCd;
                            }
                        }
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        // 倉庫コード
                        NextControl = this.tEdit_WarehouseCode;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // 拠点ガイド
                        NextControl = this.ub_SectionGuide;
                    }
                    else if (e.Key == Keys.Right)
                    {
                        if (HaveStockSlipPs)
                        {
                            if (this.tEdit_AfWarehouseCode.Enabled)
                            {
                                // 委託先倉庫
                                NextControl = this.tEdit_AfWarehouseCode;
                            }
                            else
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }

                        }
                        else
                        {
                            if (this.tEdit_EmployeeCode.Enabled)
                            {
                                // 検品担当者コード
                                NextControl = this.tEdit_EmployeeCode;
                            }
                            else
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                    }
                    else if (e.Key == Keys.Down)
                    {
                        // メーカーガイド
                        NextControl = this.ub_GoodsMakerCd;
                    }
                    break;
                #endregion
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                #region 従業員コード
                case "tEdit_EmployeeCode":

                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        if (HaveStockSlipPs)
                        {
                            NextControl = this.ub_SectionGuide;
                        }
                        else
                        {
                            NextControl = this.ub_WarehouseGuide;
                        }
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                        // NextControl = this.ub_WarehouseGuide; // --- DEL 3H 張小磊 2017/09/07
                    }
                    else if (e.Key == Keys.Up)
                    {
                        //NextControl = this.tComboEditor_Pattern;  // --- DEL 3H 張小磊 2017/09/07
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        if (tDate_InspectDayBegin.Enabled)
                        {
                            // 検品日
                            NextControl = this.tDate_InspectDayBegin;
                        }
                        else 
                        {
                            // 従業員コード
                            NextControl = tEdit_EmployeeCode;
                        }
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    }
                    else if (e.Key == Keys.Down)
                    {
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        if (HaveStockSlipPs)
                        {
                            // 委託先倉庫
                            if (tEdit_AfWarehouseCode.Enabled)
                            {
                                NextControl = tEdit_AfWarehouseCode;
                            }
                            else
                            {
                                // 品番
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                        else 
                        {
                            // 品番
                            NextControl = this.tEdit_GoodsNo;
                        }
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                        // NextControl = this.tEdit_GoodsNo; // --- DEL 3H 張小磊 2017/09/07
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Return)
                    {
                        if (string.IsNullOrEmpty(this.tEdit_EmployeeCode.Text.Trim()))
                        {
                            NextControl = this.ub_InspectEmployee;
                        }
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        else if (HaveStockSlipPs)
                        {
                            NextControl = this.tEdit_WarehouseCode;
                        }
                        else 
                        {
                            NextControl = this.tNedit_GoodsMakerCd;
                        }
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                        // --- DEL 3H 張小磊 2017/09/07---------->>>>> 
                        //else
                        //{
                        //    NextControl = this.tNedit_GoodsMakerCd;
                        //}
                        // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                    }
                    break;
                #endregion

                #region 合計表示_売上
                case "CheckEditor_Sales":

                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return || e.Key == Keys.Enter))
                    {
                        NextControl = this.CheckEditor_Rental;
                    }
                    else if (!e.ShiftKey && (e.Key == Keys.Down))
                    {
                        NextControl = this.tEdit_SeachStr;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        NextControl = this.tNedit_GoodsMakerCd;
                    }

                    break;
                #endregion

                #region 合計表示_貸出
                case "CheckEditor_Rental":

                    // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                    //if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return || e.Key == Keys.Enter || e.Key == Keys.Down))
                    //{
                    //    NextControl = this.tEdit_SeachStr;
                    //}
                    // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (HaveStockSlipPs)
                        {
                            // ﾊﾟﾀｰﾝ  0:出庫検品
                            if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
                            {
                                // 取引対象_移動出庫
                                NextControl = this.CheckEditor_MoveOutWarehouse;
                            }
                             // ﾊﾟﾀｰﾝ  1:入庫検品
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
                            {
                                // 取引対象_在庫仕入
                                NextControl = this.CheckEditor_StockStockSlip;
                            }
                        }
                        else
                        {
                            // 検索文字列
                            NextControl = this.tEdit_SeachStr;
                        }
                    }
                    else if (e.Key == Keys.Right)
                    {
                        if (HaveStockSlipPs)
                        {
                            // ﾊﾟﾀｰﾝ  0:出庫検品
                            if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
                            {
                                // 取引対象_移動出庫
                                NextControl = this.CheckEditor_MoveOutWarehouse;
                            }
                            // ﾊﾟﾀｰﾝ  1:入庫検品
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
                            {
                                // 取引対象_在庫仕入
                                NextControl = this.CheckEditor_StockStockSlip;
                            }
                        }
                        else
                        {
                            // メーカーガイド
                            NextControl = this.ub_GoodsMakerCd;
                        }
                    }
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    else if (e.Key == Keys.Up)
                    {
                        NextControl = this.tNedit_GoodsMakerCd;
                    }

                    break;
                #endregion

                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                #region 委託先倉庫ガイド
                case "ub_AfWarehouseGuide":
                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        NextControl = this.tEdit_AfWarehouseCode;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        if (ub_InspectEmployee.Enabled)
                        {
                            // 検品担当者
                            NextControl = ub_InspectEmployee;
                        }
                        else if (tDate_InspectDayBegin.Enabled)
                        {
                            // 検品日
                            NextControl = this.tDate_InspectDayBegin;
                        }
                        else
                        {
                            // 委託先倉庫コード
                            NextControl = ub_AfWarehouseGuide;
                        }
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Return)
                    {
                        NextControl = this.tNedit_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Right)
                    {
                        NextControl = this.tDate_InspectDayEnd;
                    }
                    break;
                #endregion

                #region 検品担当者ガイド
                case "ub_InspectEmployee":
                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        // 検品担当者
                        NextControl = this.tEdit_EmployeeCode;
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Return)
                    {
                        if (HaveStockSlipPs)
                        {
                            // 倉庫
                            NextControl = this.tEdit_WarehouseCode;
                        }
                        else
                        {
                            // メーカー
                            NextControl = this.tNedit_GoodsMakerCd;
                        }
                    }
                    break;
                #endregion

                #region 委託先倉庫
                case "tEdit_AfWarehouseCode":
                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Return))
                    {
                        NextControl = this.ub_WarehouseGuide;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        if (tEdit_EmployeeCode.Enabled)
                        {
                            NextControl = tEdit_EmployeeCode;
                        }
                        else if (tDate_InspectDayBegin.Enabled)
                        {
                            // 検品日
                            NextControl = this.tDate_InspectDayBegin;
                        }
                        else
                        {
                            // 委託先倉庫コード
                            NextControl = tEdit_AfWarehouseCode;
                        }
                    }
                    else if (e.Key == Keys.Tab || e.Key == Keys.Return)
                    {
                        if (string.IsNullOrEmpty(this.tEdit_AfWarehouseCode.Text.Trim()))
                        {
                            NextControl = this.ub_AfWarehouseGuide;
                        }
                        else
                        {
                            NextControl = this.tNedit_GoodsMakerCd;
                        }
                    }
                    break;
                #endregion
                #region 取引対象_移動出庫
                case "CheckEditor_MoveOutWarehouse":
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Right))
                    {
                        // 取引対象_補充出庫
                        NextControl = this.CheckEditor_ReplenishOutWarehouse;
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        // 取引対象_貸出
                        NextControl = this.CheckEditor_Rental;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // メーカーコード
                        NextControl = this.tNedit_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        // 検索文字列
                        NextControl = this.tEdit_SeachStr;
                    }
                    break;
                #endregion

                #region 取引対象_補充出庫
                case "CheckEditor_ReplenishOutWarehouse":
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Right))
                    {
                        // 取引対象_在庫仕入
                        NextControl = this.CheckEditor_StockStockSlip;
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        // 取引対象_移動出庫
                        NextControl = this.CheckEditor_MoveOutWarehouse;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // メーカーガイド
                        NextControl = this.ub_GoodsMakerCd;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        // 検索文字列
                        NextControl = this.tEdit_SeachStr;
                    }
                    break;
                #endregion

                #region 取引対象_在庫仕入
                case "CheckEditor_StockStockSlip":
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Right))
                    {
                        // 取引対象_仕入
                        NextControl = this.CheckEditor_StockSlip;
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
                        {
                            // 取引対象_補充出庫
                            NextControl = this.CheckEditor_ReplenishOutWarehouse;
                        }
                        else if((int)this.tComboEditor_Pattern.Value == PatternValue1)
                        {
                            // 取引対象_貸出
                            NextControl = this.CheckEditor_Rental;
                        }
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // 品番*
                        NextControl = this.tEdit_GoodsNo;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        // 検索文字列
                        NextControl = this.tEdit_SeachStr;
                    }
                    break;
                #endregion

                #region 取引対象_仕入
                case "CheckEditor_StockSlip":
                    // ﾊﾟﾀｰﾝ  0:出庫検品
                    if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
                    {
                        if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Down))
                        {
                            // 検索文字列
                            NextControl = this.tEdit_SeachStr;
                        }
                        else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                        {
                            // 取引対象_在庫仕入
                            NextControl = this.CheckEditor_StockStockSlip;
                        }
                        else if (e.Key == Keys.Up || e.Key == Keys.Right)
                        {
                            // 品番*
                            NextControl = this.tEdit_GoodsNo;
                        }
                    }
                    // ﾊﾟﾀｰﾝ  1:入庫検品
                    else if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
                    {
                        if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Right))
                        {
                            // 取引対象_移動入庫
                            NextControl = this.CheckEditor_MoveInWarehouse;
                        }
                        else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                        {
                            // 取引対象_在庫仕入
                            NextControl = this.CheckEditor_StockStockSlip;
                        }
                        else if (e.Key == Keys.Up)
                        {
                            // 品番*
                            NextControl = this.tEdit_GoodsNo;
                        }
                        else if (e.Key == Keys.Down)
                        {
                            // 検索文字列
                            NextControl = this.tEdit_SeachStr;
                        }
                    }
                    // ﾊﾟﾀｰﾝ  2:未入庫
                    else if ((int)this.tComboEditor_Pattern.Value == PatternValue2)
                    {
                        if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Down))
                        {
                            // 検索文字列
                            NextControl = this.tEdit_SeachStr;
                        }
                        else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Right || e.Key == Keys.Up)
                        {
                            // 品番*
                            NextControl = this.tEdit_GoodsNo;
                        }
                        else if (e.Key == Keys.Left)
                        {
                            // メーカーコード
                            NextControl = this.tNedit_GoodsMakerCd;
                        }
                    }
                    break;
                #endregion

                #region 取引対象_移動入庫
                case "CheckEditor_MoveInWarehouse":
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Down))
                    {
                        // 検索文字列
                        NextControl = this.tEdit_SeachStr;
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        // 取引対象_仕入
                        NextControl = this.CheckEditor_StockSlip;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        // 品番*
                        NextControl = this.tEdit_GoodsNo;
                    }
                    else if (e.Key == Keys.Right)
                    {
                        // 検品日終了_年
                        NextControl = this.tDate_InspectDayEnd;
                    }
                    break;
                #endregion
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                #region 未検品チェック
                case "CheckEditor_Inspect":
                    // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                    //if ((!e.ShiftKey && e.Key == Keys.Down)
                    //     || (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)))
                    //{
                    //    if (this.Inspect_Grid.Rows.Count > 0)
                    //    {
                    //        NextControl = this.Inspect_Grid;
                    //    }
                    //    else if (this.uGroupBox_ExtractInfo.Expanded)
                    //    {
                    //        NextControl = this.tComboEditor_ToRiyoSe;
                    //    }
                    //    else 
                    //    {
                    //        NextControl = this.tEdit_SeachStr;
                    //    }

                    //}
                    //else if (!e.ShiftKey && e.Key == Keys.Up)
                    //{
                    //    if (this.CheckEditor_Rental.Enabled)
                    //    {
                    //        NextControl = this.CheckEditor_Rental;
                    //    }
                    //    else if (this.CheckEditor_Sales.Enabled)
                    //    {
                    //        NextControl = this.CheckEditor_Sales;
                    //    }
                    //    else
                    //    {
                    //        NextControl = this.tEdit_GoodsNo;
                    //    }
                    //}
                    //else if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    //{
                    //    NextControl = this.tEdit_SeachStr;
                    //}
                    // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (this.Inspect_Grid.Rows.Count > InspectGridRowsCountZero)
                        {
                            // グリッド
                            NextControl = this.Inspect_Grid;
                        }
                        else
                        {
                            // 取寄
                            NextControl = this.tComboEditor_ToRiyoSe;
                        }
                    }
                    else if ((e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter)) || e.Key == Keys.Left)
                    {
                        // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                        // 検索文字列
                        //NextControl = this.tEdit_SeachStr;
                        if (this.CheckEditor_Inspected.Visible == true)
                        {
                            // 検品済み
                            NextControl = this.CheckEditor_Inspected;
                        }
                        else
                        {
                            // 検索文字列
                            NextControl = this.tEdit_SeachStr;
                        }
                        // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                    }
                    else if (e.Key == Keys.Down)
                    {
                        if (this.Inspect_Grid.Rows.Count > InspectGridRowsCountZero)
                        {
                            // グリッド
                            NextControl = this.Inspect_Grid;
                        }
                        else
                        {
                            // 移動しない
                            NextControl = this.CheckEditor_Inspect;
                        }
                    }
                    else if (e.Key == Keys.Up)
                    {
                        if (HaveStockSlipPs)
                        {
                            // ﾊﾟﾀｰﾝ  0:出庫検品 or 2:未入庫
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                            //if ((int)this.tComboEditor_Pattern.Value == PatternValue0 || (int)this.tComboEditor_Pattern.Value == PatternValue2)
                            if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                            {
                                // 取引対象_仕入
                                NextControl = this.CheckEditor_StockSlip;
                            }
                            // ﾊﾟﾀｰﾝ  1:入庫検品
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
                            {
                                // 取引対象_移動入庫
                                NextControl = this.CheckEditor_MoveInWarehouse;
                            }
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                            //// ﾊﾟﾀｰﾝ  3:検品のみ
                            //else if ((int)this.tComboEditor_Pattern.Value == PatternValue3)
                            // ﾊﾟﾀｰﾝ  3:検品のみ  2:未入庫
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue3 || (int)this.tComboEditor_Pattern.Value == PatternValue2)
                            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                        else
                        {
                            if (this.CheckEditor_Rental.Enabled)
                            {
                                // 取引対象_貸出
                                NextControl = this.CheckEditor_Rental;
                            }
                            else
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                    }
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    break;
                #endregion
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                #region 取消可能
                case "CheckEditor_Inspected":
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Right))
                    {
                        // 未検品チェック
                        NextControl = this.CheckEditor_Inspect;
                    }
                    else if (e.Key == Keys.Down)
                    {
                        if (this.Inspect_Grid.Rows.Count > InspectGridRowsCountZero)
                        {
                            // グリッド
                            NextControl = this.Inspect_Grid;
                        }
                        else
                        {
                            // 移動しない
                            NextControl = this.CheckEditor_Inspected;
                        }
                    }
                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        // 検索文字列
                        NextControl = this.tEdit_SeachStr;
                    }
                    else if (e.Key == Keys.Up)
                    {
                        if (HaveStockSlipPs)
                        {
                            // ﾊﾟﾀｰﾝ  0:出庫検品
                            if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
                            {
                                // 取引対象_仕入
                                NextControl = this.CheckEditor_StockSlip;
                            }
                            // ﾊﾟﾀｰﾝ  1:入庫検品
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
                            {
                                // 取引対象_移動入庫
                                NextControl = this.CheckEditor_MoveInWarehouse;
                            }
                            // ﾊﾟﾀｰﾝ  3:検品のみ 2:未入庫
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue3 || (int)this.tComboEditor_Pattern.Value == PatternValue2)
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                        else
                        {
                            if (this.CheckEditor_Rental.Enabled)
                            {
                                // 取引対象_貸出
                                NextControl = this.CheckEditor_Rental;
                            }
                            else
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                    }
                break;
                #endregion
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                #region 検索文字列
                case "tEdit_SeachStr":
                    // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                    //if (!e.ShiftKey && e.Key == Keys.Down)
                    //{
                    //    if (this.Inspect_Grid.Rows.Count > InspectGridRowsCountZero)
                    //    {
                    //        NextControl = this.Inspect_Grid;
                    //    }
                    //    else
                    //    {
                    //        NextControl = this.tEdit_SeachStr;
                    //    }
                    //}
                    //else if (!e.ShiftKey && e.Key == Keys.Up)
                    //{
                    //    if (this.CheckEditor_Sales.Enabled)
                    //    {
                    //        NextControl = this.CheckEditor_Sales;
                    //    }
                    //    else if (this.CheckEditor_Rental.Enabled)
                    //    {
                    //        NextControl = this.CheckEditor_Rental;
                    //    }
                    //    else
                    //    {
                    //        NextControl = this.tNedit_GoodsMakerCd;
                    //    }
                        
                    //}
                    //else if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    //{
                    //    if (this.uGroupBox_ExtractInfo.Expanded)
                    //    {
                    //        if (this.CheckEditor_Rental.Enabled)
                    //        {
                    //            NextControl = this.CheckEditor_Rental;
                    //        }
                    //        else if (this.CheckEditor_Sales.Enabled)
                    //        {
                    //            NextControl = this.CheckEditor_Sales;
                    //        }
                    //        else
                    //        {
                    //            NextControl = this.tEdit_GoodsNo;
                    //        }  
                    //    }
                    //    else if (this.Inspect_Grid.Rows.Count > 0)
                    //    {
                    //        NextControl = this.Inspect_Grid;
                    //    }
                    //    else
                    //    {
                    //        NextControl = this.CheckEditor_Inspect;
                    //    }                        
                    //}
                    // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    if (!e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter || e.Key == Keys.Right))
                    {
                        // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                        // 未検品チェック
                        //NextControl = this.CheckEditor_Inspect;
                        if (this.CheckEditor_Inspected.Visible == true)
                        {
                            // 検品済み
                            NextControl = this.CheckEditor_Inspected;
                        }
                        else
                        {
                            // 未検品チェック
                            NextControl = this.CheckEditor_Inspect;
                        }
                        // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                    }
                    else if (e.Key == Keys.Down)
                    {
                        if (this.Inspect_Grid.Rows.Count > InspectGridRowsCountZero)
                        {
                            // グリッド
                            NextControl = this.Inspect_Grid;
                        }
                        else
                        {
                            // 移動しない
                            NextControl = this.tEdit_SeachStr;
                        }
                    }
                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        if (HaveStockSlipPs)
                        {
                            // ﾊﾟﾀｰﾝ  0:出庫検品 
                            if ((int)this.tComboEditor_Pattern.Value == PatternValue0)
                            {
                                // 取引対象_仕入
                                NextControl = this.CheckEditor_StockSlip;
                            }
                            // ﾊﾟﾀｰﾝ  1:入庫検品
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue1)
                            {
                                // 取引対象_移動入庫
                                NextControl = this.CheckEditor_MoveInWarehouse;
                            }
                            // ﾊﾟﾀｰﾝ  2:未入庫
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue2)
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                            // ﾊﾟﾀｰﾝ  3:検品のみ
                            else if ((int)this.tComboEditor_Pattern.Value == PatternValue3)
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                        else
                        {
                            if (this.CheckEditor_Rental.Enabled)
                            {
                                // 取引対象_貸出
                                NextControl = this.CheckEditor_Rental;
                            }
                            else
                            {
                                // 品番*
                                NextControl = this.tEdit_GoodsNo;
                            }
                        }
                    }
                    else if (e.Key == Keys.Up)
                    {
                        if (this.CheckEditor_Sales.Enabled)
                        {
                            // 取引対象_売上
                            NextControl = this.CheckEditor_Sales;
                        }
                        else if (this.CheckEditor_StockSlip.Enabled)
                        {
                            // 取引対象_仕入
                            NextControl = this.CheckEditor_StockSlip;
                        }
                        else
                        {
                            // メーカーコード
                            NextControl = this.tNedit_GoodsMakerCd;
                        }
                    }
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    break;
                #endregion

                #region グリッド
                case "Inspect_Grid":

                    if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                    {
                        NextControl = this.CheckEditor_Inspect;
                    }
                    else if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        if (this.uGroupBox_ExtractInfo.Expanded)
                        {
                            NextControl = this.tComboEditor_ToRiyoSe;
                        }
                        else
                        {
                            NextControl = this.tEdit_SeachStr;
                        }
                    }

                    break;
                #endregion

                default:
                    break;
            }
            return NextControl;
        }

        #endregion

        #region Private Method
        /// <summary>
        ///	画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面の初期設定を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // スキン設定
            this.ControlScreenSkinAccessor.LoadSkin();
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            excCtrlNm.Add(this.uGroupBox_AmountInfo.Name);
            this.ControlScreenSkinAccessor.SetExceptionCtrl(excCtrlNm);
            this.ControlScreenSkinAccessor.SettingScreenSkin(this);

            // アイコン設定
            this.ImageList16 = IconResourceManagement.ImageList16;

            // ガイドボタンのアイコン設定
            this.ub_WarehouseGuide.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ub_SectionGuide.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ub_GoodsMakerCd.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ub_InspectEmployee.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1];
            this.ub_AfWarehouseGuide.Appearance.Image = this.ImageList16.Images[(int)Size16_Index.STAR1]; // --- ADD 3H 張小磊 2017/09/07

            // イメージリスト設定
            this.tToolsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;

            //----------------------------
            // ツールアイコン設定
            //----------------------------
            // 終了
            this.tToolsManager_MainMenu.Tools[ButtonToolClose].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 検索
            this.tToolsManager_MainMenu.Tools[ButtonToolSearch].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // 確定
            this.tToolsManager_MainMenu.Tools[ButtonToolOk].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // クリア
            this.tToolsManager_MainMenu.Tools[ButtonToolClear].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            // 検品引当
            this.tToolsManager_MainMenu.Tools[ButtonToolInspectUpd].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // 検品表示
            this.tToolsManager_MainMenu.Tools[ButtonToolShow].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // ログイン担当者
            this.tToolsManager_MainMenu.Tools[LabelToolLoginTitle].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // 担当者表示
            if (LoginInfoAcquisition.Employee != null)
            {
                this.tToolsManager_MainMenu.Tools[LabelToolLoginName].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }

            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            // 取消
            this.tToolsManager_MainMenu.Tools[ButtonToolDelete].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
            this.tToolsManager_MainMenu.Tools[ButtonToolDelete].SharedProps.Enabled = false;

            // テキスト出力
            this.tToolsManager_MainMenu.Tools[ButtonToolTextOut].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

            this.InspectDs = new InspectDataSet();

            this.DataViewInspect = new DataView(this.InspectDs.InspectList);

            this.Inspect_Grid.DataSource = this.DataViewInspect;

            // グリッド列初期設定処理
            InitializeGridColumns(this.Inspect_Grid.DisplayLayout.Bands[0].Columns);

            // 取寄のｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.tComboEditor_ToRiyoSe.Items.Clear();
            this.tComboEditor_ToRiyoSe.Items.Add(ToRiyoSeValue0, ToRiyoSeDisp0);
            this.tComboEditor_ToRiyoSe.Items.Add(ToRiyoSeValue1, ToRiyoSeDisp1);
            this.tComboEditor_ToRiyoSe.MaxDropDownItems = this.tComboEditor_ToRiyoSe.Items.Count;

            // ﾊﾟﾀｰﾝのｺﾝﾎﾞﾎﾞｯｸｽに情報セット
            this.tComboEditor_Pattern.Items.Clear();
            this.tComboEditor_Pattern.Items.Add(PatternValue0, PatternDisp0);
            this.tComboEditor_Pattern.Items.Add(PatternValue1, PatternDisp1);
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // オプションコードの仕入業務プラス
            if (HaveStockSlipPs)
            {
                this.tComboEditor_Pattern.Items.Add(PatternValue2, PatternDisp2);
            }
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            this.tComboEditor_Pattern.Items.Add(PatternValue3, PatternDisp3);
            this.tComboEditor_Pattern.MaxDropDownItems = this.tComboEditor_Pattern.Items.Count;

            // 取引対象_売上
            this.CheckEditor_Sales.Checked = true;
            // 合計表示_貸出
            this.CheckEditor_Rental.Checked = true;

            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // 取引対象_売上
            this.CheckEditor_Sales.Enabled = true;
            // 取引対象_貸出
            this.CheckEditor_Rental.Enabled = true;
            // オプションコードの仕入業務プラス
            if (HaveStockSlipPs)
            {
                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Enabled = true;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Enabled = true;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Enabled = true;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Enabled = true;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Enabled = false;

                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Checked = true;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Checked = true;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Checked = true;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Checked = true;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Checked = false;

                // 画面の項目 位置調整
                #region [画面の項目 位置調整]
                // 検品担当者Title
                this.uLabel_InspectEmployee.Location = new Point(379, 66);
                // 検品担当者コード
                this.tEdit_EmployeeCode.Location = new Point(471, 59);
                // 検品担当者名称
                this.lb_InspectEmployeeName.Location = new Point(520, 59);
                // 検品担当者ガイド
                this.ub_InspectEmployee.Location = new Point(694, 59);

                // 委託先倉庫Title
                this.uLabel_AfWarehouse.Location = new Point(379, 94);
                // 委託先倉庫コード
                this.tEdit_AfWarehouseCode.Location = new Point(471, 87);
                // 委託先倉庫名称
                this.lb_AfWarehouseName.Location = new Point(520, 87);
                // 委託先倉庫ガイド
                this.ub_AfWarehouseGuide.Location = new Point(694, 87);
                #endregion

            }
            else
            {
                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Enabled = false;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Enabled = false;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Enabled = false;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Enabled = false;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Enabled = false;

                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Visible = false;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Visible = false;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Visible = false;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Visible = false;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Visible = false;
                // 委託先倉庫Title
                this.uLabel_AfWarehouse.Visible = false;
                // 委託先倉庫コード
                this.tEdit_AfWarehouseCode.Visible = false;
                // 委託先倉庫名称
                this.lb_AfWarehouseName.Visible = false;
                // 委託先倉庫ガイド
                this.ub_AfWarehouseGuide.Visible = false;

                // 合計表示エリア
                this.uGroupBox_AmountInfo.Height = 58;
                // 合計表示_移動出庫
                this.lb_MoveOutWarehouse.Visible = false;
                this.lb_MoveOutWarehouseTitle.Visible = false;
                // 合計表示_補充出庫
                this.lb_ReplenishOutWarehouse.Visible = false;
                this.lb_ReplenishOutWarehouseTitle.Visible = false;
                // 合計表示_在庫仕入
                this.lb_StockStockSlip.Visible = false;
                this.lb_StockStockSlipTitle.Visible = false;
                // 合計表示_仕入
                this.lb_StockSlip.Visible = false;
                this.lb_StockSlipTitle.Visible = false;
                // 合計表示_移動入庫
                this.lb_MoveInWarehouse.Visible = false;
                this.lb_MoveInWarehouseTitle.Visible = false;
            }
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            // --- DEL 3H 張小磊 2017/09/07---------->>>>>
            //#region 今回使用しないので、非表示を設定します。
            //this.CheckEditor_MoveInWarehouse.Visible = false;
            //this.CheckEditor_MoveOutWarehouse.Visible = false;
            //this.CheckEditor_StockSlip.Visible = false;
            //this.CheckEditor_StockStockSlip.Visible = false;

            //this.lb_MoveInWarehouseTitle.Visible = false;
            //this.lb_MoveOutWarehouseTitle.Visible = false;
            //this.lb_StockSlipTitle.Visible = false;
            //this.lb_StockStockSlipTitle.Visible = false;
            //this.lb_MoveInWarehouse.Visible = false;
            //this.lb_MoveOutWarehouse.Visible = false;
            //this.lb_StockSlip.Visible = false;
            //this.lb_StockStockSlip.Visible = false;
            //#endregion
            // --- DEL 3H 張小磊 2017/09/07----------<<<<<
        }

        /// <summary>
        ///	画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面をクリアします。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        ///</remarks>
        private void ScreenClear()
        {
            // ｺﾝﾎﾞﾎﾞｯｸｽに情報をクリアします。
            this.tComboEditor_ToRiyoSe.SelectedIndex = 0;
            this.tComboEditor_Pattern.SelectedIndex = 0;

            // 日付に情報をクリアします。
            this.tDate_IoGoodsDayBegin.Clear();
            this.tDate_IoGoodsDayEnd.Clear();
            this.tDate_InspectDayBegin.Clear();
            this.tDate_InspectDayEnd.Clear();

            // 入出荷日⇒システム日付セット
            DateTime dateTime = DateTime.Now;
            this.tDate_IoGoodsDayBegin.SetDateTime(dateTime);
            this.tDate_IoGoodsDayEnd.SetDateTime(dateTime);

            // 画面内容をクリアします。
            this.tEdit_WarehouseCode.Text = string.Empty;
            this.lb_WarehouseName.Text = string.Empty;
            this.tEdit_SectionCodeAllowZero.Text = this.LoginSectionCode;
            this.lb_SectionName.Text = this.LoginSectionName;
            this.tEdit_EmployeeCode.Text = string.Empty;
            this.lb_InspectEmployeeName.Text = string.Empty;
            this.tNedit_GoodsMakerCd.Clear();
            this.lb_GoodsMakerName.Text = string.Empty;
            this.tEdit_GoodsNo.Text = string.Empty;
            this.tEdit_SeachStr.Text = string.Empty;
            this.lb_Sales.Text = StringZero;
            this.lb_Rental.Text = StringZero;
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // 委託先倉庫
            tEdit_AfWarehouseCode.Text = string.Empty;
            lb_AfWarehouseName.Text = string.Empty;

            // 合計表示_移動出庫
            this.lb_MoveOutWarehouse.Text = StringZero;
            // 合計表示_補充出庫
            this.lb_ReplenishOutWarehouse.Text = StringZero;
            // 合計表示_在庫仕入
            this.lb_StockStockSlip.Text = StringZero;
            // 合計表示_仕入
            this.lb_StockSlip.Text = StringZero;
            // 合計表示_移動入庫
            this.lb_MoveInWarehouse.Text = StringZero;
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            // グリッドをクリアします。
            this.InspectDs.InspectList.Clear();

            this.CheckEditor_Sales.Checked = true;
            this.CheckEditor_Rental.Checked = true;
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // 取引対象_売上
            this.CheckEditor_Sales.Enabled = true;
            // 取引対象_貸出
            this.CheckEditor_Rental.Enabled = true;

            // オプションコードの仕入業務プラス
            if (HaveStockSlipPs)
            {
                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Enabled = true;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Enabled = true;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Enabled = true;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Enabled = true;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Enabled = false;

                // 取引対象_移動出庫
                this.CheckEditor_MoveOutWarehouse.Checked = true;
                // 取引対象_補充出庫
                this.CheckEditor_ReplenishOutWarehouse.Checked = true;
                // 取引対象_在庫仕入
                this.CheckEditor_StockStockSlip.Checked = true;
                // 取引対象_仕入
                this.CheckEditor_StockSlip.Checked = true;
                // 取引対象_移動入庫
                this.CheckEditor_MoveInWarehouse.Checked = false;
            }
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            this.CheckEditor_Inspect.Checked = false;

            this.CheckEditor_Inspected.Checked = false;// ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応
            
        }

        #region グリッドレイアウト設定処理
        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドレイアウトを設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// </remarks>
        private void InitializeGridColumns(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            int visiblePosition = 0;

            // セル選択時は行選択に
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.Inspect_Grid.DisplayLayout.Bands[0];
            for (int i = 0; i < band.Columns.Count; i++)
            {
                band.Columns[i].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            }

            // 選択
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Header.Caption = SelectFlagCaption;
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Width = 30;
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].AutoEdit = true;
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 検
            columns[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].Header.Caption = InspectStatusDispCaption;
            columns[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].Width = 30;
            columns[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            columns[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 検品ステータス
            columns[this.InspectDs.InspectList.InspectStatusColumn.ColumnName].Hidden = true;
            columns[this.InspectDs.InspectList.InspectStatusColumn.ColumnName].Header.Caption = InspectStatusCaption;
            columns[this.InspectDs.InspectList.InspectStatusColumn.ColumnName].Width = 50;
            columns[this.InspectDs.InspectList.InspectStatusColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[this.InspectDs.InspectList.InspectStatusColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入出荷日
            columns[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].Header.Caption = ShipmentDayCaption;
            columns[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].Width = 110;
            columns[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 商品メーカーコード
            columns[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].Hidden = true;
            columns[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].Header.Caption = GoodsMakerCdCaption;
            columns[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].Width = 80;
            columns[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 商品メーカー名
            columns[this.InspectDs.InspectList.GoodsMakerNameColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.GoodsMakerNameColumn.ColumnName].Header.Caption = GoodsMakerNameCaption;
            columns[this.InspectDs.InspectList.GoodsMakerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.GoodsMakerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.GoodsMakerNameColumn.ColumnName].Width = 140;
            columns[this.InspectDs.InspectList.GoodsMakerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.GoodsMakerNameColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.GoodsMakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 商品番号
            columns[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].Header.Caption = GoodsNoCaption;
            columns[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].Width = 130;
            columns[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 品名
            columns[this.InspectDs.InspectList.GoodsNameColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.GoodsNameColumn.ColumnName].Header.Caption = GoodsNameCaption;
            columns[this.InspectDs.InspectList.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.GoodsNameColumn.ColumnName].Width = 150;
            columns[this.InspectDs.InspectList.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.GoodsNameColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 検品
            columns[this.InspectDs.InspectList.HandTerminalCodeDispColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.HandTerminalCodeDispColumn.ColumnName].Header.Caption = HandTerminalCodeDispCaption;
            columns[this.InspectDs.InspectList.HandTerminalCodeDispColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.HandTerminalCodeDispColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.HandTerminalCodeDispColumn.ColumnName].Width = 70;
            columns[this.InspectDs.InspectList.HandTerminalCodeDispColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.HandTerminalCodeDispColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.HandTerminalCodeDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ハンディターミナル区分
            columns[this.InspectDs.InspectList.HandTerminalCodeColumn.ColumnName].Hidden = true;
            columns[this.InspectDs.InspectList.HandTerminalCodeColumn.ColumnName].Header.Caption = HandTerminalCodeCaption;
            columns[this.InspectDs.InspectList.HandTerminalCodeColumn.ColumnName].Width = 50;
            columns[this.InspectDs.InspectList.HandTerminalCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[this.InspectDs.InspectList.HandTerminalCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 入庫数
            columns[this.InspectDs.InspectList.InputCntColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.InputCntColumn.ColumnName].Header.Caption = InputCntCaption;
            columns[this.InspectDs.InspectList.InputCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.InputCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.InputCntColumn.ColumnName].Width = 120;
            columns[this.InspectDs.InspectList.InputCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[this.InspectDs.InspectList.InputCntColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.InputCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 出庫数
            columns[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].Header.Caption = ShipmentCntCaption;
            columns[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].Width = 120;
            columns[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 仕入先/得意先/相手倉庫
            columns[this.InspectDs.InspectList.CustNmWareNmColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.CustNmWareNmColumn.ColumnName].Header.Caption = CustNmWareNmCaption;
            columns[this.InspectDs.InspectList.CustNmWareNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.CustNmWareNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.CustNmWareNmColumn.ColumnName].Width = 240;
            columns[this.InspectDs.InspectList.CustNmWareNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.CustNmWareNmColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.CustNmWareNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 棚番
            columns[this.InspectDs.InspectList.WarehouseShelfNoColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.WarehouseShelfNoColumn.ColumnName].Header.Caption = WarehouseShelfNoCaption;
            columns[this.InspectDs.InspectList.WarehouseShelfNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.WarehouseShelfNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.WarehouseShelfNoColumn.ColumnName].Width = 70;
            columns[this.InspectDs.InspectList.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.WarehouseShelfNoColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 取引
            columns[this.InspectDs.InspectList.TransactionColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.TransactionColumn.ColumnName].Header.Caption = TransactionCaption;
            columns[this.InspectDs.InspectList.TransactionColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.TransactionColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.TransactionColumn.ColumnName].Width = 100;
            columns[this.InspectDs.InspectList.TransactionColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.TransactionColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.TransactionColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 伝票番号
            columns[this.InspectDs.InspectList.SalesSlipNumColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.SalesSlipNumColumn.ColumnName].Header.Caption = SalesSlipNumCaption;
            columns[this.InspectDs.InspectList.SalesSlipNumColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.SalesSlipNumColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.SalesSlipNumColumn.ColumnName].Width = 110;
            columns[this.InspectDs.InspectList.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.SalesSlipNumColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 検品担当者
            columns[this.InspectDs.InspectList.EmployeeCodeColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.EmployeeCodeColumn.ColumnName].Header.Caption = EmployeeCodeCaption;
            columns[this.InspectDs.InspectList.EmployeeCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.EmployeeCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.EmployeeCodeColumn.ColumnName].Width = 150;
            columns[this.InspectDs.InspectList.EmployeeCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.EmployeeCodeColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.EmployeeCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 検品日付
            columns[this.InspectDs.InspectList.InspectDateColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.InspectDateColumn.ColumnName].Header.Caption = InspectDateCaption;
            columns[this.InspectDs.InspectList.InspectDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.InspectDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.InspectDateColumn.ColumnName].Width = 110;
            columns[this.InspectDs.InspectList.InspectDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.InspectDateColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.InspectDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 検品時刻
            columns[this.InspectDs.InspectList.InspectTimeColumn.ColumnName].Hidden = false;
            columns[this.InspectDs.InspectList.InspectTimeColumn.ColumnName].Header.Caption = InspectTimeCaption;
            columns[this.InspectDs.InspectList.InspectTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.InspectTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.InspectTimeColumn.ColumnName].Width = 110;
            columns[this.InspectDs.InspectList.InspectTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.InspectTimeColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.InspectTimeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 行番号
            columns[this.InspectDs.InspectList.SalesRowNoColumn.ColumnName].Hidden = true;
            columns[this.InspectDs.InspectList.SalesRowNoColumn.ColumnName].Header.Caption = SalesRowNoCaption;
            columns[this.InspectDs.InspectList.SalesRowNoColumn.ColumnName].Width = 100;
            columns[this.InspectDs.InspectList.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[this.InspectDs.InspectList.SalesRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 倉庫コード
            columns[this.InspectDs.InspectList.WarehouseCodeColumn.ColumnName].Hidden = true;
            columns[this.InspectDs.InspectList.WarehouseCodeColumn.ColumnName].Header.Caption = WarehouseCodeCaption;
            columns[this.InspectDs.InspectList.WarehouseCodeColumn.ColumnName].Width = 100;
            columns[this.InspectDs.InspectList.WarehouseCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.WarehouseCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 受払元伝票区分
            columns[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Hidden = true;
            columns[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Header.Caption = AcPaySlipCdCaption;
            columns[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Width = 100;
            columns[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // 受払元取引区分
            columns[this.InspectDs.InspectList.AcPayTransCdColumn.ColumnName].Hidden = true;
            columns[this.InspectDs.InspectList.AcPayTransCdColumn.ColumnName].Header.Caption = AcPayTransCdCaption;
            columns[this.InspectDs.InspectList.AcPayTransCdColumn.ColumnName].Width = 100;
            columns[this.InspectDs.InspectList.AcPayTransCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            columns[this.InspectDs.InspectList.AcPayTransCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // 伝票番号引当用
            columns[this.InspectDs.InspectList.SalesSlipNumHFColumn.ColumnName].Hidden = true;
            columns[this.InspectDs.InspectList.SalesSlipNumHFColumn.ColumnName].Header.Caption = SalesSlipNumHFCaption;
            columns[this.InspectDs.InspectList.SalesSlipNumHFColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            columns[this.InspectDs.InspectList.SalesSlipNumHFColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[this.InspectDs.InspectList.SalesSlipNumHFColumn.ColumnName].Width = 110;
            columns[this.InspectDs.InspectList.SalesSlipNumHFColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            columns[this.InspectDs.InspectList.SalesSlipNumHFColumn.ColumnName].Header.Fixed = true;
            columns[this.InspectDs.InspectList.SalesSlipNumHFColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<

            //-------------------------------------------------------------
            // 前回表示情報設定
            //-------------------------------------------------------------
            // 列表示状態クラスリストXMLファイルをデシリアライズ
            List<ColDisplayStatus> colDisplayStatusList = this.Deserialize(FileNameColDisplayStatus);

            foreach (ColDisplayStatus colDisplayStatus in colDisplayStatusList)
            {
                if (colDisplayStatus.Key == this.FontSize_tComboEditor.Name)
                {
                    this.FontSize_tComboEditor.Value = colDisplayStatus.Width;
                }
                else if (columns.Exists(colDisplayStatus.Key))
                {
                    columns[colDisplayStatus.Key].Header.VisiblePosition = colDisplayStatus.VisiblePosition;
                    columns[colDisplayStatus.Key].Header.Fixed = colDisplayStatus.HeaderFixed;
                    columns[colDisplayStatus.Key].Width = colDisplayStatus.Width;
                }
            }
        }
        #endregion

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検品情報の検索処理を行ないます。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        /// <returns>[0: 正常, 4: 検索結果0件,0、4以外: 異常]</returns>
        private int SearchProc()
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // パラメータを設定します。
            HandyInspectParamWork HandyInspectParamWork = new HandyInspectParamWork();
            // 企業コード
            HandyInspectParamWork.EnterpriseCode = this.EnterpriseCode;
            // 取寄区分
            HandyInspectParamWork.OrderDivCd = (int)this.tComboEditor_ToRiyoSe.Value;
            // 入出荷日開始
            HandyInspectParamWork.St_SalesDate = this.tDate_IoGoodsDayBegin.GetDateTime();
            // 入出荷日終了
            HandyInspectParamWork.Ed_SalesDate = this.tDate_IoGoodsDayEnd.GetDateTime();
            HandyInspectParamWork.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            HandyInspectParamWork.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
            HandyInspectParamWork.AfWarehouseCd = this.tEdit_AfWarehouseCode.Text.Trim(); // --- ADD 3H 張小磊 2017/09/07
            // 検品日開始
            HandyInspectParamWork.St_InspectDate = this.tDate_InspectDayBegin.GetDateTime();
            // 検品日終了
            DateTime ParaInspectDayEnd = this.tDate_InspectDayEnd.GetDateTime();
            if (ParaInspectDayEnd != DateTime.MinValue)
            {
                ParaInspectDayEnd = ParaInspectDayEnd.AddDays(1);
                HandyInspectParamWork.Ed_InspectDate = ParaInspectDayEnd;
            }
            // メーカーコード
            HandyInspectParamWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // 検品担当者コード
            HandyInspectParamWork.EmployeeCode = this.tEdit_EmployeeCode.Text.Trim();
            // 品番検索区分
            string ResultGoodsNo = string.Empty;
            HandyInspectParamWork.GoodsNoSrchTyp = this.getGoodsNoType(this.tEdit_GoodsNo.Text.Trim(), out ResultGoodsNo);
            // 品番
            HandyInspectParamWork.GoodsNo = ResultGoodsNo;
            // パターン
            HandyInspectParamWork.Pattern = (int)this.tComboEditor_Pattern.Value;
            // 取引対象_売上
            if (this.CheckEditor_Sales.Checked)
            {
                HandyInspectParamWork.TransSales = CheckBoxSelected;
            }
            // 取引対象_貸出
            if (this.CheckEditor_Rental.Checked)
            {
                HandyInspectParamWork.TransLend = CheckBoxSelected;
            }
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // 取引対象_移動出庫
            if (this.CheckEditor_MoveOutWarehouse.Checked)
            {
                HandyInspectParamWork.TransMoveOutWarehouse = CheckBoxSelected;
            }
            // 取引対象_補充出庫
            if (this.CheckEditor_ReplenishOutWarehouse.Checked)
            {
                HandyInspectParamWork.TransReplenishOutWarehouse = CheckBoxSelected;
            }
            // 取引対象_在庫仕入
            if (this.CheckEditor_StockStockSlip.Checked)
            {
                HandyInspectParamWork.TransStockStockSlip = CheckBoxSelected;
            }
            // 取引対象_仕入
            if (this.CheckEditor_StockSlip.Checked)
            {
                HandyInspectParamWork.TransStockSlip = CheckBoxSelected;
            }
            // 取引対象_移動入庫
            if (this.CheckEditor_MoveInWarehouse.Checked)
            {
                HandyInspectParamWork.TransMoveInWarehouse = CheckBoxSelected;
            }
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<

            // 抽出中画面インスタンス作成
            Broadleaf.Windows.Forms.SFCMN00299CA sfcmn00299ca = new Broadleaf.Windows.Forms.SFCMN00299CA();
            sfcmn00299ca.Title = SearchFormTitle;
            sfcmn00299ca.Message = SearchFormMessage;

            ArrayList HandyInspectList = new ArrayList();

            try
            {
                // 抽出中画面を表示します。
                sfcmn00299ca.Show();
                Status = this.InspectInfoAccessor.Search(HandyInspectParamWork, out HandyInspectList);
            }
            finally
            {
                // 抽出中画面を閉じます。
                sfcmn00299ca.Close();
                // グリッドをクリアします。
                this.InspectDs.InspectList.Clear();
                // 合計表示をクリアします。
                this.lb_Sales.Text = StringZero;
                this.lb_Rental.Text = StringZero;
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                // 合計表示_移動出庫
                this.lb_MoveOutWarehouse.Text = StringZero;
                // 合計表示_補充出庫
                this.lb_ReplenishOutWarehouse.Text = StringZero;
                // 合計表示_在庫仕入
                this.lb_StockStockSlip.Text = StringZero;
                // 合計表示_仕入
                this.lb_StockSlip.Text = StringZero;
                // 合計表示_移動入庫
                this.lb_MoveInWarehouse.Text = StringZero;
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            }

            #region < 検索後処理 >
            switch (Status)
            {
                #region -- 正常終了 --
                // 全件取得メソッドの結果が"正常終了"のとき
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 検索結果はグリッドに設定します。
                        this.InspectGridSetting(HandyInspectList);
                        // グリッド選択行を設定します。
                        if (this.Inspect_Grid.Rows.Count > InspectGridRowsCountZero)
                        {
                            this.Inspect_Grid.Focus();
                            this.Inspect_Grid.ActiveRow = this.Inspect_Grid.Rows[0];
                            this.Inspect_Grid.ActiveRow.Selected = true;
                        }
                        // 検索後、フィールドします。
                        // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                        //this.CheckEditor_Inspect_CheckedChanged(null, null);
                        this.CheckEditor_Inspected_CheckedChanged(null, null);
                        // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

                        // 合計表示を設定します。
                        this.SetTotalCountProc();
                        break;
                    }
                #endregion

                #region -- データ無し --
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        this.InfoMsgDispProc(DataInfoEmptyError, Status);
                        break;
                    }
                #endregion
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                #region -- メモリアウト --
                case (-100):
                    {
                        this.InfoMsgDispProc(OutOfMemoryError, Status);
                        break;
                    }
                #endregion
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                #region -- 検索失敗 --
                default:
                    {
                        this.ErrMsgDispProc(InspectInfoSearchError, Status);
                        break;
                    }
                #endregion
            }
            #endregion

            return Status;

        }

        /// <summary>
        /// 検索前処理
        /// </summary>
        /// <param name="handyInspectList">登録用情報リスト</param>
        /// <remarks>
        /// <br>Note       : 検品情報の検索前処理を行ないます。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        /// <returns>結果[0: 正常, 0以外: 異常]</returns>
        private int BeforeSaveProc(out ArrayList handyInspectList)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            handyInspectList = new ArrayList();
            string filter = string.Empty;// ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応
            try
            {
                // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                //string Filter = string.Format("{0}='{1}'",
                //            this.InspectDs.InspectList.SelectFlagColumn, true);
                //InspectDataSet.InspectListRow[] InspectListRow =
                //    (InspectDataSet.InspectListRow[])this.InspectDs.InspectList.Select(Filter);
                string filter2 = string.Format(" {0}='{1}'",
                            this.InspectDs.InspectList.SelectFlagColumn, true);
                GetFilter(out filter);
                if (!filter.Equals(string.Empty))
                {
                    filter2 = string.Format(" AND {0}='{1}'",
                            this.InspectDs.InspectList.SelectFlagColumn, true);
                }

                InspectDataSet.InspectListRow[] InspectListRow =
                    (InspectDataSet.InspectListRow[])this.InspectDs.InspectList.Select(filter + filter2);
                // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

                // 明細グリッドに「選択」欄が一個も選択されていない場合は以下のメッセージを表示する。
                if (InspectListRow.Length == 0)
                {
                    this.InfoMsgDispProc(BeforeSaveNoSelectError, StatusError);
                    return Status;
                }
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                // 明細グリッドに「選択」欄が選択されている行に、「検」欄が「✔」となる行があった場合は以下のメッセージを表示する。
                foreach (InspectDataSet.InspectListRow Row in InspectListRow)
                {
                    if (StringCheck.Equals(Row.InspectStatusDisp))
                    {
                        this.InfoMsgDispProc(BeforeSaveError, StatusError);
                        return Status;
                    }
                }
                // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                // 検品確定処理の確認ダイアログ
                DialogResult Dialog = this.QuestionYesNoProc(BeforeSaveQuestionMessage);

                if (Dialog == DialogResult.Yes)
                {
                    // 検品登録のパラメータを準備します。
                    HandyInspectDataWork ParaInspectDataWork = null;
                    foreach (InspectDataSet.InspectListRow Row in InspectListRow)
                    {
                        ParaInspectDataWork = new HandyInspectDataWork();
                        // 企業コード
                        ParaInspectDataWork.EnterpriseCode = this.EnterpriseCode;
                        // 従業員コード⇒ログインユーザーの従業員コード
                        ParaInspectDataWork.EmployeeCode = this.LoginEmployee.EmployeeCode;
                        // 端末名称⇒ログインユーザーの端末名称
                        ParaInspectDataWork.MachineName = this.PosTerminalMgData.MachineName;
                        // 受払元伝票区分⇒明細グリッド.受払元伝票区分
                        ParaInspectDataWork.AcPaySlipCd = int.Parse(Row.AcPaySlipCd);
                        // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                        //// 受払元伝票番号⇒明細グリッド.伝票番号
                        //ParaInspectDataWork.AcPaySlipNum = Row.SalesSlipNum;
                        // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        // 受払元伝票番号⇒明細グリッド.伝票番号引当用
                        ParaInspectDataWork.AcPaySlipNum = Row.SalesSlipNumHF;
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                        // 受払元行番号⇒明細グリッド.行番号
                        ParaInspectDataWork.AcPaySlipRowNo = int.Parse(Row.SalesRowNo);
                        // 受払元取引区分⇒明細グリッド.受払元取引区分
                        ParaInspectDataWork.AcPayTransCd = int.Parse(Row.AcPayTransCd);
                        // 商品メーカーコード⇒明細グリッド.商品メーカーコード
                        ParaInspectDataWork.GoodsMakerCd = int.Parse(Row.GoodsMakerCd);
                        // 商品番号⇒明細グリッド.商品番号
                        ParaInspectDataWork.GoodsNo = Row.GoodsNo;
                        // 倉庫コード⇒明細グリッド.倉庫コード
                        ParaInspectDataWork.WarehouseCode = this.GetWarehouseCode(Row.WarehouseCode);
                        // 検品ステータス⇒「3：検品済み」固定
                        ParaInspectDataWork.InspectStatus = InspectStatusAlreadyInspected;
                        // 検品区分⇒「2：手動検品」固定
                        ParaInspectDataWork.InspectCode = InspectCodeManual;
                        // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                        //// 受払元取引区分が「10」の場合、検品数⇒明細グリッド.出庫数
                        //if (int.Parse(Row.AcPayTransCd) == AcPayTransCdNormalSlip)
                        //{
                        //    ParaInspectDataWork.InspectCnt = ChangeStringToDouble(Row.ShipmentCnt);
                        //}
                        //// 受払元取引区分が「11」の場合、検品数⇒明細グリッド.入庫数
                        //else if (int.Parse(Row.AcPayTransCd) == AcPayTransCdReturned)
                        //{
                        //    ParaInspectDataWork.InspectCnt = ChangeStringToDouble(Row.InputCnt);
                        //}
                        // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        // 検品数
                        ParaInspectDataWork.InspectCnt = GetInspectCnt(int.Parse(Row.AcPaySlipCd),
                                                                       int.Parse(Row.AcPayTransCd),
                                                                       ChangeStringToDouble(Row.InputCnt),
                                                                       ChangeStringToDouble(Row.ShipmentCnt));

                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                        // ハンディターミナル区分⇒「9：その他」固定
                        ParaInspectDataWork.HandTerminalCode = DivOtherwise;

                        handyInspectList.Add(ParaInspectDataWork);
                    }
                    Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.ErrMsgDispProc(InspectInfoSearchError, Status);
            }
            return Status;
        }

        /// <summary>
        /// 検品引当前処理
        /// </summary>
        /// <param name="delHandyInspectList">削除用条件情報リスト</param>
        /// <param name="handyInspectList">登録用情報リスト</param>
        /// <remarks>
        /// <br>Note       : 検品情報の検品引当前処理を行ないます。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// </remarks>
        /// <returns>結果[0: 正常, 0以外: 異常]</returns>
        private int BeforeUpdateProc(out ArrayList delHandyInspectList, out ArrayList handyInspectList)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            handyInspectList = new ArrayList();
            delHandyInspectList = new ArrayList();

            try
            {
                // フォーカスが明細グリッドの明細行に落ちていない場合、以下のメッセージを表示する。
                if (this.Inspect_Grid.ActiveRow == null || this.Inspect_Grid.ActiveRow.Selected == false)
                {
                    this.InfoMsgDispProc(BeforeUpdateNoSelectError, StatusNormal);
                    return Status;
                }

                
                // 明細グリッドに選択されたレコードの「検」欄が「※」の場合は以下のメッセージを表示する。
                string InspectStatusDisp = (string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].Value;
                if (InspectStatusDisp.Equals(StringHoshi))
                {
                    this.InfoMsgDispProc(BeforeUpdatePickingError, StatusNormal);
                    return Status;
                }
                // 明細グリッドに選択されたレコードの「検」欄が「✔」の場合は以下のメッセージを表示する。
                else if (InspectStatusDisp.Equals(StringCheck))
                {
                    this.InfoMsgDispProc(BeforeUpdateMoreUpdError, StatusNormal);
                    return Status;
                }
                // 明細グリッドに選択されたレコードの「検」欄が「○」の場合は以下のメッセージを表示する。
                else if (InspectStatusDisp.Equals(StringCircle))
                {
                    this.InfoMsgDispProc(BeforeUpdateInspectingError, StatusNormal);
                    return Status;
                }

                // 明細グリッドに選択されたレコードの「選択」欄がチェックされている場合は以下のメッセージを表示する。
                if ((bool)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.SelectFlagColumn.ColumnName].Value)
                {
                    this.InfoMsgDispProc(BeforeUpdateCheckedError, StatusNormal);
                    return Status;
                }

                // 検品引当確認ダイアログ
                DialogResult Dialog = this.QuestionYesNoProc(BeforeUpdateQuestionMessage);

                if (Dialog == DialogResult.Yes)
                {
                    int ActiveRowIndex = this.Inspect_Grid.ActiveRow.Index;

                    HandyInspectDataWork ParaInspectDataWork = new HandyInspectDataWork();

                    // 入出荷日
                    string InspectString = (string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].Value;
                    DateTime InspectDateTime = new DateTime();
                    if (this.GetDateTimeForString(InspectString, out InspectDateTime))
                    {
                        ParaInspectDataWork.InspectDateTime = InspectDateTime;
                    }
                    // 品番
                    string GoodsNo = (string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].Value;
                    ParaInspectDataWork.GoodsNo = GoodsNo;
                    // 企業コード
                    ParaInspectDataWork.EnterpriseCode = this.EnterpriseCode;
                    // 受払元伝票区分
                    int AcPaySlipCd = int.Parse((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value);
                    ParaInspectDataWork.AcPaySlipCd = AcPaySlipCd;
                    // 受払元取引区分
                    int AcPayTransCd = int.Parse((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.AcPayTransCdColumn.ColumnName].Value);
                    ParaInspectDataWork.AcPayTransCd = AcPayTransCd;
                    // メーカーコード
                    int GoodsMakerCd = int.Parse((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].Value);
                    ParaInspectDataWork.GoodsMakerCd = GoodsMakerCd;
                    // 倉庫コード
                    string WarehouseCode = this.GetWarehouseCode((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.WarehouseCodeColumn.ColumnName].Value);
                    ParaInspectDataWork.WarehouseCode = WarehouseCode;

                    // 検品ガイドを起動します。
                    PMHND04201UB InspectSelect = new PMHND04201UB();
                    Dialog = InspectSelect.ShowDialog(this, ParaInspectDataWork, GuideModeInspectProvision);

                    if (Dialog == DialogResult.OK)
                    {
                        ParaInspectDataWork = new HandyInspectDataWork();
                        // 企業コード
                        ParaInspectDataWork.EnterpriseCode = this.EnterpriseCode;
                        // 従業員コード⇒ログインユーザーの従業員コード
                        ParaInspectDataWork.EmployeeCode = InspectSelect.RetInspectDataWork.EmployeeCode;
                        // 端末名称⇒ログインユーザーの端末名称
                        ParaInspectDataWork.MachineName = InspectSelect.RetInspectDataWork.MachineName;
                        // 受払元伝票区分⇒明細グリッド.受払元伝票区分
                        ParaInspectDataWork.AcPaySlipCd = AcPaySlipCd;
                        // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                        //// 受払元伝票番号⇒明細グリッド.伝票番号
                        //ParaInspectDataWork.AcPaySlipNum = (string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.SalesSlipNumColumn.ColumnName].Value;
                        // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        // 受払元伝票番号⇒明細グリッド.伝票番号引当用
                        ParaInspectDataWork.AcPaySlipNum = (string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.SalesSlipNumHFColumn.ColumnName].Value;
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                        // 受払元行番号⇒明細グリッド.行番号
                        ParaInspectDataWork.AcPaySlipRowNo = int.Parse((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.SalesRowNoColumn.ColumnName].Value);
                        // 受払元取引区分⇒明細グリッド.受払元取引区分
                        ParaInspectDataWork.AcPayTransCd = AcPayTransCd;
                        // 商品メーカーコード⇒明細グリッド.商品メーカーコード
                        ParaInspectDataWork.GoodsMakerCd = GoodsMakerCd;
                        // 商品番号⇒明細グリッド.商品番号
                        ParaInspectDataWork.GoodsNo = GoodsNo;
                        // 倉庫コード⇒明細グリッド.倉庫コード
                        ParaInspectDataWork.WarehouseCode = WarehouseCode;
                        // 検品ステータス⇒「3：検品済み」固定
                        ParaInspectDataWork.InspectStatus = InspectSelect.RetInspectDataWork.InspectStatus;
                        // 検品区分⇒「2：手動検品」固定
                        ParaInspectDataWork.InspectCode = InspectSelect.RetInspectDataWork.InspectCode;
                        // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                        //// 受払元取引区分が「10」の場合、検品数⇒明細グリッド.出庫数
                        //if (ParaInspectDataWork.AcPayTransCd == AcPayTransCdNormalSlip)
                        //{
                        //    ParaInspectDataWork.InspectCnt = ChangeStringToDouble((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].Value);
                        //}
                        //// 受払元取引区分が「11」の場合、検品数⇒明細グリッド.入庫数
                        //else if (ParaInspectDataWork.AcPayTransCd == AcPayTransCdReturned)
                        //{
                        //    ParaInspectDataWork.InspectCnt = ChangeStringToDouble((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.InputCntColumn.ColumnName].Value);
                        //}
                        // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                        // 検品数
                        ParaInspectDataWork.InspectCnt = GetInspectCnt(AcPaySlipCd,
                                                                       AcPayTransCd,
                                                                       ChangeStringToDouble((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.InputCntColumn.ColumnName].Value),
                                                                       ChangeStringToDouble((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.ShipmentCntColumn.ColumnName].Value));
                        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                        // ハンディターミナル区分⇒「9：その他」固定
                        ParaInspectDataWork.HandTerminalCode = InspectSelect.RetInspectDataWork.HandTerminalCode;
                        // 検品日時
                        ParaInspectDataWork.InspectDateTime = InspectSelect.RetInspectDataWork.InspectDateTime;

                        // 削除用条件情報リスト
                        delHandyInspectList.Add(InspectSelect.RetInspectDataWork);
                        // 登録用情報リスト
                        handyInspectList.Add(ParaInspectDataWork);

                        Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.ErrMsgDispProc(InspectInfoSaveError, Status);
            }
            return Status;
        }

        /// <summary>
        /// 検品表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 検品情報の検品表示処理を行ないます。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void ShowProc()
        {
            try
            {
                // フォーカスが明細グリッドの明細行に落ちていない場合、以下のメッセージを表示する。
                if (this.Inspect_Grid.ActiveRow == null || this.Inspect_Grid.ActiveRow.Selected == false)
                {
                    this.InfoMsgDispProc(BeforeShowNoSelectError, StatusNormal);
                    return;
                }

                // 明細グリッドに選択されたレコードの「検」欄が「※」の場合は以下のメッセージを表示する。
                string InspectStatusDisp = (string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName].Value;
                if (InspectStatusDisp.Equals(StringHoshi))
                {
                    this.InfoMsgDispProc(BeforeUpdatePickingError, StatusNormal);
                    return;
                }
                // 明細グリッドに選択されたレコードの「検」欄が「✔」の場合は以下のメッセージを表示する。
                else if (InspectStatusDisp.Equals(StringCheck))
                {
                    this.InfoMsgDispProc(BeforeUpdateMoreUpdError, StatusNormal);
                    return;
                }
                // 明細グリッドに選択されたレコードの「検」欄が「○」の場合は以下のメッセージを表示する。
                else if (InspectStatusDisp.Equals(StringCircle))
                {
                    this.InfoMsgDispProc(BeforeUpdateInspectingError, StatusNormal);
                    return;
                }

                int ActiveRowIndex = this.Inspect_Grid.ActiveRow.Index;

                HandyInspectDataWork ParaInspectDataWork = new HandyInspectDataWork();

                // 入出荷日
                string InspectString = (string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.ShipmentDayColumn.ColumnName].Value;
                DateTime InspectDateTime = new DateTime();
                if (this.GetDateTimeForString(InspectString, out InspectDateTime))
                {
                    ParaInspectDataWork.InspectDateTime = InspectDateTime;
                }
                // 品番
                string GoodsNo = (string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.GoodsNoColumn.ColumnName].Value;
                ParaInspectDataWork.GoodsNo = GoodsNo;
                // 企業コード
                ParaInspectDataWork.EnterpriseCode = this.EnterpriseCode;
                // 受払元伝票区分
                int AcPaySlipCd = int.Parse((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value);
                ParaInspectDataWork.AcPaySlipCd = AcPaySlipCd;
                // 受払元取引区分
                int AcPayTransCd = int.Parse((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.AcPayTransCdColumn.ColumnName].Value);
                ParaInspectDataWork.AcPayTransCd = AcPayTransCd;
                // メーカーコード
                int GoodsMakerCd = int.Parse((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.GoodsMakerCdColumn.ColumnName].Value);
                ParaInspectDataWork.GoodsMakerCd = GoodsMakerCd;
                // 倉庫コード
                string WarehouseCode = this.GetWarehouseCode((string)this.Inspect_Grid.ActiveRow.Cells[this.InspectDs.InspectList.WarehouseCodeColumn.ColumnName].Value);
                ParaInspectDataWork.WarehouseCode = WarehouseCode;

                // 検品ガイドを起動します。
                PMHND04201UB InspectSelect = new PMHND04201UB();
                InspectSelect.ShowDialog(this, ParaInspectDataWork, GuideModeInspectShow);
            }
            catch
            {
                this.ErrMsgDispProc(InspectInfoSearchError, StatusError);
            }
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        /// <param name="delHandyInspectList">削除用条件情報リスト</param>
        /// <param name="handyInspectList">登録用情報リスト</param>
        /// <param name="mode">確定モード</param>
        /// <remarks>
        /// <br>Note       : 検品情報の確定処理を行ないます。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>結果[0: 正常, 0以外: 異常]</returns>
        private int SaveProc(ArrayList delHandyInspectList, ArrayList handyInspectList, int mode)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 確定中画面インスタンス作成
            Broadleaf.Windows.Forms.SFCMN00299CA sfcmn00299ca = new Broadleaf.Windows.Forms.SFCMN00299CA();
            sfcmn00299ca.Title = SaveFormTitle;
            sfcmn00299ca.Message = SaveFormMessage;

            try
            {
                // 確定中画面を表示します。
                sfcmn00299ca.Show();

                Status = this.InspectInfoAccessor.WriteInspectData(delHandyInspectList, handyInspectList, mode);
            }
            finally
            {
                // 確定中画面を閉じます。
                sfcmn00299ca.Close();
            }

            #region < 確定後処理 >
            switch (Status)
            {
                #region -- 正常終了 --
                // 全件取得メソッドの結果が"正常終了"のとき
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        SaveCompletionDialog Dialog = new SaveCompletionDialog();
                        Dialog.ShowDialog(2);
                        break;
                    }
                #endregion

                #region -- 確定失敗 --
                default:
                    {
                        this.ErrMsgDispProc(InspectInfoSaveError, Status);
                        break;
                    }
                #endregion
            }
            #endregion

            return Status;

        }

        /// <summary>
        /// 画面変更確認処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 各処理ボタン押下時、画面に変更があったかのチェックを行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        /// <returns>チェック結果[true: 変更有, false: 変更無]</returns>
        private bool CheckScreenChange()
        {
            bool Result = false;

            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            //string Filter = string.Format("{0}='{1}'",
            //                this.InspectDs.InspectList.SelectFlagColumn, true);
            //InspectDataSet.InspectListRow[] InspectListRow =
            //    (InspectDataSet.InspectListRow[])this.InspectDs.InspectList.Select(Filter);
            string filter = string.Empty;
            string filter2 = string.Format(" {0}='{1}'",
                            this.InspectDs.InspectList.SelectFlagColumn, true);
            GetFilter(out filter);
            if (!filter.Equals(string.Empty))
            {
                filter2 = string.Format(" AND {0}='{1}'",
                        this.InspectDs.InspectList.SelectFlagColumn, true);
            }

            InspectDataSet.InspectListRow[] InspectListRow =
                (InspectDataSet.InspectListRow[])this.InspectDs.InspectList.Select(filter + filter2);
            // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

            // グリッド選択列中にチェックがある場合
            if (InspectListRow.Length > 0) Result = true;

            return Result;
        }

        /// <summary>
        /// アクティブコントロール取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : アクティブコントロールを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private Control GetActiveControl()
        {
            Control Ctrl = this.ActiveControl;

            if (Ctrl != null)
            {
                Ctrl = this.GetParentControl(Ctrl);
            }

            return Ctrl;
        }

        /// <summary>
        /// 親コントロール取得処理
        /// </summary>
        /// <param name="ctrl">子コントロール</param>
        /// <remarks>
        /// <br>Note       : 親コントロールを取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>親コントロール</returns>
        private Control GetParentControl(Control ctrl)
        {
            Control RetCtrl = ctrl;
            if (RetCtrl.Parent != null)
            {
                if ((RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TEdit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TDateEdit) ||
                    (RetCtrl.Parent is Broadleaf.Library.Windows.Forms.TComboEditor))
                {
                    RetCtrl = GetParentControl(RetCtrl.Parent);
                }
            }

            return RetCtrl;
        }

        /// <summary>
        /// グリッドに情報設定処理
        /// </summary>
        /// <param name="inspectList">検品情報リスト</param>
        /// <remarks>
        /// <br>Note       : グリッドに検品情報を設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// </remarks>
        private void InspectGridSetting(ArrayList inspectList)
        {
            if (inspectList == null || inspectList.Count == InspectGridRowsCountZero)
            {
                return;
            }

            this.InspectDs.InspectList.BeginLoadData();
            this.InspectDs.InspectList.Rows.Clear();

            DataRow Row = null;
            foreach (InspectRefDataWork InspectRefDataWork in inspectList)
            {
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                //データソース区分 1:売上データ
                if (InspectRefDataWork.DataSourceDiv == 1)
                {
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    if (InspectRefDataWork.LogicalDeleteCode == DataLogicalDeleted)
                    {
                        // 受払元伝票区分
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdRental;
                        // 受払元取引区分
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdReturned;
                    }
                    else
                    {
                        if (InspectRefDataWork.AcptAnOdrStatus == AcptAnOdrStatusEarnings && InspectRefDataWork.SalesSlipCdDtl == SalesSlipCdDtlDivSalesSlip)
                        {
                            // 受払元伝票区分
                            InspectRefDataWork.AcPaySlipCd = AcPaySlipCdEarnings;
                            // 受払元取引区分
                            InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                        }
                        else if (InspectRefDataWork.AcptAnOdrStatus == AcptAnOdrStatusEarnings && InspectRefDataWork.SalesSlipCdDtl == SalesSlipCdDtlDivReturned)
                        {
                            // 受払元伝票区分
                            InspectRefDataWork.AcPaySlipCd = AcPaySlipCdEarnings;
                            // 受払元取引区分
                            InspectRefDataWork.AcPayTransCd = AcPayTransCdReturned;
                        }
                        else if (InspectRefDataWork.AcptAnOdrStatus == AcptAnOdrStatusShipment && InspectRefDataWork.SalesSlipCdDtl == SalesSlipCdDtlDivSalesSlip)
                        {
                            // 受払元伝票区分
                            InspectRefDataWork.AcPaySlipCd = AcPaySlipCdRental;
                            // 受払元取引区分
                            InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                        }
                        else if (InspectRefDataWork.AcptAnOdrStatus == AcptAnOdrStatusShipment && InspectRefDataWork.SalesSlipCdDtl == SalesSlipCdDtlDivReturned)
                        {
                            // 受払元伝票区分
                            InspectRefDataWork.AcPaySlipCd = AcPaySlipCdRental;
                            // 受払元取引区分
                            InspectRefDataWork.AcPayTransCd = AcPayTransCdReturned;
                        }
                    }
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                }
                //データソース区分 2:仕入データ
                else if (InspectRefDataWork.DataSourceDiv == 2)
                {
                    // 仕入形式が「0:仕入」、売上伝票区分(明細)が「0:仕入」
                    if (InspectRefDataWork.SupplierFormal == 0 && InspectRefDataWork.StockSlipCdDtl == 0)
                    {
                        // 受払元伝票区分「10」：仕入
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdStock;
                        // 受払元取引区分 「10」：通常伝票
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                    }
                    // 仕入形式が「0:仕入」、売上伝票区分(明細)が「1:返品」
                    else if (InspectRefDataWork.SupplierFormal == 0 && InspectRefDataWork.StockSlipCdDtl == 1)
                    {
                        // 受払元伝票区分「10」：仕入
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdStock;
                        // 受払元取引区分「11」：返品
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdReturned;
                    }
                    // 仕入形式が「1:入荷」、売上伝票区分(明細)が「0:仕入」
                    else if (InspectRefDataWork.SupplierFormal == 1 && InspectRefDataWork.StockSlipCdDtl == 0)
                    {
                        // 受払元伝票区分「11」：受託
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdAccession;
                        // 受払元取引区分「10」：通常伝票
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                    }
                }
                //データソース区分 3:在庫移動データ
                else if (InspectRefDataWork.DataSourceDiv == 3)
                {
                    // 移動形式 1:在庫出庫 or 2:倉庫出庫
                    if (InspectRefDataWork.StockMoveFormal == 1 || InspectRefDataWork.StockMoveFormal == 2)
                    {
                        // 受払元伝票区分「30」：移動出荷
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdMovementShipping;
                        // 受払元取引区分「10」：通常伝票
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                    }
                    // 移動形式 3:在庫入庫 or 4:倉庫入庫
                    else if (InspectRefDataWork.StockMoveFormal == 3 || InspectRefDataWork.StockMoveFormal == 4)
                    {
                        // 受払元伝票区分「31」：移動入荷
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdMovingStock;
                        // 受払元取引区分「10」：通常伝票
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                    }
                }
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                Row = this.InspectDs.InspectList.NewRow();

                // チェックオフ
                Row[this.InspectDs.InspectList.SelectFlagColumn] = false;

                // 抽出結果データ.検品ステータスが「1：検品中」
                if (InspectRefDataWork.InspectStatus == InspectStatusDuring)
                {
                    Row[this.InspectDs.InspectList.InspectStatusDispColumn] = StringCircle;
                    Row[this.InspectDs.InspectList.InspectStatusColumn] = InspectStatusDuring;
                }
                // 抽出データ.検品ステータスが「2：ピッキング済み」
                else if (InspectRefDataWork.InspectStatus == InspectStatusAlreadyPicking)
                {
                    Row[this.InspectDs.InspectList.InspectStatusDispColumn] = StringHoshi;
                    Row[this.InspectDs.InspectList.InspectStatusColumn] = InspectStatusAlreadyPicking;
                }
                // 抽出データ.検品ステータスが「3：検品済み」
                else if (InspectRefDataWork.InspectStatus == InspectStatusAlreadyInspected)
                {
                    Row[this.InspectDs.InspectList.InspectStatusDispColumn] = StringCheck;
                    Row[this.InspectDs.InspectList.InspectStatusColumn] = InspectStatusAlreadyInspected;
                }
                // 抽出データ.検品ステータスが「2」「3」以外
                else
                {
                    Row[this.InspectDs.InspectList.InspectStatusDispColumn] = string.Empty;
                }

                // 入出荷日
                Row[this.InspectDs.InspectList.ShipmentDayColumn] = this.GetStringDateTimeForInt(InspectRefDataWork.ShipmentDay);

                // 商品番号
                Row[this.InspectDs.InspectList.GoodsNoColumn] = InspectRefDataWork.GoodsNo;

                // 品名
                Row[this.InspectDs.InspectList.GoodsNameColumn] = InspectRefDataWork.GoodsName;

                // 検品
                // 抽出データ.ハンディターミナル区分が「1」の場合
                if (InspectRefDataWork.HandTerminalCode == DivHandTerminal)
                {
                    Row[this.InspectDs.InspectList.HandTerminalCodeDispColumn] = StringHT;
                }
                // 抽出データ.ハンディターミナル区分が「9」の場合
                else if (InspectRefDataWork.HandTerminalCode == DivOtherwise)
                {
                    Row[this.InspectDs.InspectList.HandTerminalCodeDispColumn] = StringPC;
                }
                // 抽出データ.ハンディターミナル区分が「1」「9」以外の場合
                else
                {
                    Row[this.InspectDs.InspectList.HandTerminalCodeDispColumn] = string.Empty;
                }

                // 入庫数
                if (InspectRefDataWork.InputCnt != InputCntZero)
                {
                    Row[this.InspectDs.InspectList.InputCntColumn] = InspectRefDataWork.InputCnt.ToString(CountFormat);
                }
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                else
                {
                    Row[this.InspectDs.InspectList.InputCntColumn] = "";
                }
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                // 出庫数
                if (InspectRefDataWork.ShipmentCnt != ShipmentCntZero)
                {
                    Row[this.InspectDs.InspectList.ShipmentCntColumn] = InspectRefDataWork.ShipmentCnt.ToString(CountFormat);
                }
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                else
                {
                    Row[this.InspectDs.InspectList.ShipmentCntColumn] = "";
                }
                // 受払元伝票区分が「20」「22」「10」「11」の場合
                if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdEarnings || InspectRefDataWork.AcPaySlipCd == AcPaySlipCdRental ||
                    InspectRefDataWork.AcPaySlipCd == AcPaySlipCdStock || InspectRefDataWork.AcPaySlipCd == AcPaySlipCdAccession)
                {
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    // 仕入先/得意先/相手倉庫
                    if (!string.IsNullOrEmpty(InspectRefDataWork.CustomerSnm) && !string.IsNullOrEmpty(InspectRefDataWork.WarehouseName))
                    {
                        Row[this.InspectDs.InspectList.CustNmWareNmColumn] = InspectRefDataWork.CustomerSnm + StringZanSlash + InspectRefDataWork.WarehouseName;
                    }
                    else if (string.IsNullOrEmpty(InspectRefDataWork.CustomerSnm) && string.IsNullOrEmpty(InspectRefDataWork.WarehouseName))
                    {
                        Row[this.InspectDs.InspectList.CustNmWareNmColumn] = string.Empty;
                    }
                    else if (string.IsNullOrEmpty(InspectRefDataWork.CustomerSnm))
                    {
                        Row[this.InspectDs.InspectList.CustNmWareNmColumn] = InspectRefDataWork.WarehouseName;
                    }
                    else if (string.IsNullOrEmpty(InspectRefDataWork.WarehouseName))
                    {
                        Row[this.InspectDs.InspectList.CustNmWareNmColumn] = InspectRefDataWork.CustomerSnm;
                    }
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                }
                // 受払元伝票区分が「30」「31」「13」の場合は抽出結果データ.取引先名称でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdMovementShipping || InspectRefDataWork.AcPaySlipCd == AcPaySlipCdMovingStock ||
                    InspectRefDataWork.AcPaySlipCd == AcPaySlipCdStockSupplier)
                {
                    Row[this.InspectDs.InspectList.CustNmWareNmColumn] = InspectRefDataWork.CustomerSnm;
                }
                // 受払元伝票区分が「70」の場合はNULLでセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdReplenish)
                {
                    Row[this.InspectDs.InspectList.CustNmWareNmColumn] = null;
                }
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                // 棚番
                Row[this.InspectDs.InspectList.WarehouseShelfNoColumn] = InspectRefDataWork.WarehouseShelfNo;

                // 取引
                // 受払元伝票区分が「20」の場合、「売上」でセットする。
                if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdEarnings)
                {
                    Row[this.InspectDs.InspectList.TransactionColumn] = Sales;
                }
                // 受払元伝票区分が「22」の場合、「貸出」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdRental)
                {
                    Row[this.InspectDs.InspectList.TransactionColumn] = Rental;
                }
                // 受払元伝票区分が「10」OR「11」の場合、「仕入」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdStock || InspectRefDataWork.AcPaySlipCd == AcPaySlipCdAccession)
                {
                    Row[this.InspectDs.InspectList.TransactionColumn] = StockSlip;
                }
                // 受払元伝票区分が「13」の場合、「在庫仕入」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdStockSupplier)
                {
                    Row[this.InspectDs.InspectList.TransactionColumn] = StockStockSlip;
                }
                // 受払元伝票区分が「30」の場合、「移動出庫」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdMovementShipping)
                {
                    Row[this.InspectDs.InspectList.TransactionColumn] = MoveOutWarehouse;
                }
                // 受払元伝票区分が「31」の場合、「移動入庫」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdMovingStock)
                {
                    Row[this.InspectDs.InspectList.TransactionColumn] = MoveInWarehouse;
                }
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                // 受払元伝票区分が「70」の場合、「補充出庫」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdReplenish)
                {
                    Row[this.InspectDs.InspectList.TransactionColumn] = ReplenishOutWarehouse;
                }
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                // 上記以外場合、
                else
                {
                    Row[this.InspectDs.InspectList.TransactionColumn] = string.Empty;
                }

                // 受払元取引区分
                Row[this.InspectDs.InspectList.AcPayTransCdColumn] = InspectRefDataWork.AcPayTransCd;

                // 受払元伝票区分
                Row[this.InspectDs.InspectList.AcPaySlipCdColumn] = InspectRefDataWork.AcPaySlipCd;

                // 伝票番号
                // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                //Row[this.InspectDs.InspectList.SalesSlipNumColumn] = InspectRefDataWork.SalesSlipNum;
                // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                if ((int)this.tComboEditor_Pattern.Value == PatternValue3)
                {
                    // 検品のみの場合
                    Row[this.InspectDs.InspectList.SalesSlipNumColumn] = "";
                }
                else
                {
                    Row[this.InspectDs.InspectList.SalesSlipNumColumn] = InspectRefDataWork.SalesSlipNum.PadLeft(9, '0');
                }
                // 伝票番号引当用
                Row[this.InspectDs.InspectList.SalesSlipNumHFColumn] = InspectRefDataWork.SalesSlipNum;
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<

                // 検品担当者
                Row[this.InspectDs.InspectList.EmployeeCodeColumn] = this.InspectInfoAccessor.GetEmployeeName(InspectRefDataWork.EmployeeCode);

                // 検品日付
                Row[this.InspectDs.InspectList.InspectDateColumn] = this.GetDateForInspectDateTime(InspectRefDataWork.InspectDateTime);

                // 検品時刻
                Row[this.InspectDs.InspectList.InspectTimeColumn] = this.GetTimeForInspectDateTime(InspectRefDataWork.InspectDateTime);

                // 受払元行番号
                Row[this.InspectDs.InspectList.SalesRowNoColumn] = InspectRefDataWork.SalesRowNo;

                // 商品メーカーコード
                Row[this.InspectDs.InspectList.GoodsMakerCdColumn] = InspectRefDataWork.GoodsMakerCd;

                // 商品メーカー名称
                Row[this.InspectDs.InspectList.GoodsMakerNameColumn] = InspectRefDataWork.MakerName;

                // 倉庫コード
                Row[this.InspectDs.InspectList.WarehouseCodeColumn] = InspectRefDataWork.WarehouseCode;

                this.InspectDs.InspectList.Rows.Add(Row);
            }
            this.InspectDs.InspectList.EndLoadData();
        }

        /// <summary>
        /// DateTimeの年月日取得処理
        /// </summary>
        /// <param name="inspectDateTime">検品時間</param>
        /// <remarks>
        /// <br>Note       : DateTimeの年月日を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>DateTimeの年月日</returns>
        private string GetDateForInspectDateTime(DateTime inspectDateTime)
        {
            string ResultDate = string.Empty;
            if (inspectDateTime == null || inspectDateTime == DateTime.MinValue)
            {
                return ResultDate;
            }
            // 年
            int Year = inspectDateTime.Year;
            // 月
            int Month = inspectDateTime.Month;
            // 日
            int Day = inspectDateTime.Day;
            // yyyy/MM/dd
            ResultDate = Year.ToString(StringZZZZ) + StringSlash + Month.ToString(StringZZ) + StringSlash + Day.ToString(StringZZ);
            return ResultDate;
        }

        /// <summary>
        /// DateTimeの時分秒取得処理
        /// </summary>
        /// <param name="inspectDateTime">検品時間</param>
        /// <remarks>
        /// <br>Note       : DateTimeの時分秒を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>DateTimeの時分秒</returns>
        private string GetTimeForInspectDateTime(DateTime inspectDateTime)
        {
            string ResultDate = string.Empty;
            if (inspectDateTime == null || inspectDateTime == DateTime.MinValue)
            {
                return ResultDate;
            }
            // 時
            int Hour = inspectDateTime.Hour;
            // 分
            int Minute = inspectDateTime.Minute;
            // 秒
            int Second = inspectDateTime.Second;
            // 時分秒
            ResultDate = Hour.ToString(StringZZ) + StringColon + Minute.ToString(StringZZ) + StringColon + Second.ToString(StringZZ);
            return ResultDate;
        }

        /// <summary>
        /// 文字列⇒DateTimeの変換処理
        /// </summary>
        /// <param name="paraDateTime">時間文字列</param>
        /// <param name="resultDateTime">変換後時間</param>
        /// <remarks>
        /// <br>Note       : 字列⇒DateTimeを変換します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>チェック結果[true: 変換OK, false: 変換エラー]</returns>
        private bool GetDateTimeForString(string paraDateTime, out DateTime resultDateTime)
        {
            bool ChangeFlg = false;
            resultDateTime = new DateTime();
            try
            {
                if (string.IsNullOrEmpty(paraDateTime))
                {
                    return ChangeFlg;
                }
                string dateStr = paraDateTime.Replace(StringSlash, string.Empty);
                if (dateStr.Length != StringLengthEight)
                {
                    return ChangeFlg;
                }
                // 年
                int Year = int.Parse(dateStr.Substring(SubstringIndexZero, SubstringIndexFour));
                // 月
                int Month = int.Parse(dateStr.Substring(SubstringIndexFour, SubstringIndexTwo));
                // 日
                int Day = int.Parse(dateStr.Substring(SubstringIndexSix, SubstringIndexTwo));

                resultDateTime = new DateTime(Year, Month, Day);
                ChangeFlg = true;
            }
            catch
            {
                ChangeFlg = false;
            }

            return ChangeFlg;
        }

        /// <summary>
        /// int型値からyyyy/MM/dd文字列の変換処理
        /// </summary>
        /// <param name="paraDate">時間数字</param>
        /// <remarks>
        /// <br>Note       : int型値からyyyy/MM/dd文字列を変換します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>変換後yyyy/MM/dd文字列</returns>
        private string GetStringDateTimeForInt(int paraDate)
        {
            string ResultDate = string.Empty;
            string dateStr = paraDate.ToString();
            if (dateStr.Length != StringLengthEight)
            {
                return ResultDate;
            }
            // 年
            int Year = int.Parse(dateStr.Substring(SubstringIndexZero, SubstringIndexFour));
            // 月
            int Month = int.Parse(dateStr.Substring(SubstringIndexFour, SubstringIndexTwo));
            // 日
            int Day = int.Parse(dateStr.Substring(SubstringIndexSix, SubstringIndexTwo));
            // yyyy/MM/dd
            ResultDate = Year.ToString(StringZZZZ) + StringSlash + Month.ToString(StringZZ) + StringSlash + Day.ToString(StringZZ);
            return ResultDate;
        }

        /// <summary>
        /// 倉庫コードの変換処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <remarks>
        /// <br>Note       : 倉庫コードを変換します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>変換後倉庫コード</returns>
        private string GetWarehouseCode(string warehouseCode)
        {
            string ResultWarehouseCode = string.Empty;
            // 倉庫がNULL値の場合はゼロでセットする
            if (string.IsNullOrEmpty(warehouseCode))
            {
                ResultWarehouseCode = StringZero;
            }
            else
            {
                ResultWarehouseCode = warehouseCode;
            }
            return ResultWarehouseCode;
        }

        /// <summary>
        /// String文字列⇒Double数字の変換処理
        /// </summary>
        /// <param name="count">String文字列</param>
        /// <remarks>
        /// <br>Note       : String文字列⇒Double数字を変換します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>変換後Double数字</returns>
        private double ChangeStringToDouble(string count)
        {
            double ResultCount = 0d;
            if (string.IsNullOrEmpty(count)) return ResultCount;
            count = count.Replace(StringComma, string.Empty);
            double.TryParse(count, out ResultCount);
            return ResultCount;
        }

        /// <summary>
        /// 入力項目チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力項目をチェックします。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>チェック結果[true: チェックOK, false: チェックエラー]</returns>
        private bool CheckInputPara()
        {
            bool CheckInputParaFlg = true;

            DateGetAcs.CheckDateResult Cdr;

            // 検品のみ場合、入出荷日チェックしない
            if ((int)this.tComboEditor_Pattern.Value != ComboEditorPatternInspectOnly)
            {
                // 入出荷日開始
                // 未入力の場合
                if (this.tDate_IoGoodsDayBegin.GetLongDate() == LongDateZero)
                {
                    this.tDate_IoGoodsDayBegin.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        IoGoodsDayBeginEmptyDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
                // 無効年月日の場合
                Cdr = this.DateGetAccessor.CheckDate(ref this.tDate_IoGoodsDayBegin, true);
                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    this.tDate_IoGoodsDayBegin.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        IoGoodsDayBeginInvalidDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }

                // 入出荷日終了
                // 未入力の場合
                if (this.tDate_IoGoodsDayEnd.GetLongDate() == LongDateZero)
                {
                    this.tDate_IoGoodsDayEnd.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        IoGoodsDayEndEmptyDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
                // 無効年月日の場合
                Cdr = this.DateGetAccessor.CheckDate(ref this.tDate_IoGoodsDayEnd, true);
                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    this.tDate_IoGoodsDayEnd.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        IoGoodsDayEndInvalidDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }

                // 入出荷日開始、終了
                // 開始、終了の大小比較
                if (this.tDate_IoGoodsDayBegin.GetLongDate() > this.tDate_IoGoodsDayEnd.GetLongDate())
                {
                    this.tDate_IoGoodsDayBegin.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        IoGoodsDayStartEndError,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            // 検品日開始
            if (this.tDate_InspectDayBegin.GetLongDate() != LongDateZero)
            {
                // 無効年月日の場合
                Cdr = this.DateGetAccessor.CheckDate(ref this.tDate_InspectDayBegin, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    this.tDate_InspectDayBegin.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        InspectDayBeginInvalidDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            // 検品日終了
            if (this.tDate_InspectDayEnd.GetLongDate() != LongDateZero)
            {
                // 無効年月日の場合
                Cdr = this.DateGetAccessor.CheckDate(ref this.tDate_InspectDayEnd, true);

                if (Cdr != DateGetAcs.CheckDateResult.OK)
                {
                    this.tDate_InspectDayEnd.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        InspectDayEndInvalidDate,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            // 検品日開始、終了
            // 開始、終了の大小比較
            if (this.tDate_InspectDayBegin.GetLongDate() != LongDateZero && this.tDate_InspectDayEnd.GetLongDate() != LongDateZero)
            {
                if (this.tDate_InspectDayBegin.GetLongDate() > this.tDate_InspectDayEnd.GetLongDate())
                {
                    this.tDate_InspectDayBegin.Focus();

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        InspectDayStartEndError,
                        StatusNormal,
                        MessageBoxButtons.OK);

                    return false;
                }
            }

            // ﾊﾟﾀｰﾝが「検品のみ」以外で、取引対象のいずれも選択されていないの場合
            // --- DEL 3H 張小磊 2017/09/07---------->>>>>
            //if ((int)this.tComboEditor_Pattern.Value != ComboEditorPatternInspectOnly
            //    && !this.CheckEditor_Sales.Checked
            //    && !this.CheckEditor_Rental.Checked
            //    && !this.CheckEditor_MoveInWarehouse.Checked
            //    && !this.CheckEditor_MoveOutWarehouse.Checked
            //    && !this.CheckEditor_StockSlip.Checked
            //    && !this.CheckEditor_StockStockSlip.Checked)
            // --- DEL 3H 張小磊 2017/09/07----------<<<<<
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            if ((int)this.tComboEditor_Pattern.Value != ComboEditorPatternInspectOnly
                && !this.CheckEditor_Sales.Checked                        // 売上
                && !this.CheckEditor_Rental.Checked                       // 貸出
                && !this.CheckEditor_MoveOutWarehouse.Checked             // 移動出庫
                && !this.CheckEditor_ReplenishOutWarehouse.Checked        // 補充出庫
                && !this.CheckEditor_StockStockSlip.Checked               // 在庫仕入
                && !this.CheckEditor_StockSlip.Checked                    // 仕入
                && !this.CheckEditor_MoveInWarehouse.Checked)             // 移動入庫
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            {
                this.CheckEditor_Sales.Focus();

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    TransObjectEmptyError,
                    StatusNormal,
                    MessageBoxButtons.OK);

                return false;
            }

            return CheckInputParaFlg;
        }

        /// <summary>
        /// 拠点情報のキャッシュ処理。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報をキャッシュします。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>取得結果[0: 取得OK, 0以外: 取得エラー]</returns>
        private int GetSecInfo()
        {
            ArrayList SectionCodeList = new ArrayList();
            int Status = this.SecInfoSetAccessor.SearchAll(out SectionCodeList, this.EnterpriseCode);

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SecInfoDic = new Dictionary<string, string>();
                foreach (SecInfoSet SecInfoSetWork in SectionCodeList)
                {
                    if (SecInfoSetWork.LogicalDeleteCode == DataEffective && !SecInfoDic.ContainsKey(SecInfoSetWork.SectionCode.Trim().PadLeft(PadLeftIndexTwo, CharZero)))
                    {
                        this.SecInfoDic.Add(SecInfoSetWork.SectionCode.Trim().PadLeft(PadLeftIndexTwo, CharZero), SecInfoSetWork.SectionGuideNm.Trim());
                    }
                }
            }
            return Status;
        }

        /// <summary>
        /// 倉庫情報のキャッシュ処理。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫情報をキャッシュします。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>取得結果[0: 取得OK, 0以外: 取得エラー]</returns>
        private int GetWarehouseInfo()
        {
            ArrayList WarehouseList = new ArrayList();
            int Status = this.WarehouseAccessor.SearchAll(out WarehouseList, this.EnterpriseCode);

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.WarehouseDic = new Dictionary<string, string>();
                foreach (Warehouse WarehouseWork in WarehouseList)
                {
                    if (WarehouseWork.LogicalDeleteCode == DataEffective && !this.WarehouseDic.ContainsKey(WarehouseWork.WarehouseCode.Trim().PadLeft(PadLeftIndexFour, CharZero)))
                    {
                        this.WarehouseDic.Add(WarehouseWork.WarehouseCode.Trim().PadLeft(PadLeftIndexFour, CharZero), WarehouseWork.WarehouseName.Trim());
                    }
                }
            }
            return Status;
        }

        /// <summary>
        /// メーカー情報のキャッシュ処理。
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカー情報をキャッシュします。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>取得結果[0: 取得OK, 0以外: 取得エラー]</returns>
        private int GetGoodsMakerInfo()
        {
            ArrayList MakerList = new ArrayList();
            int Status = this.MakerAccessor.SearchAll(out MakerList, this.EnterpriseCode);

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.GoodsMakerDic = new Dictionary<int, string>();
                foreach (MakerUMnt MakerUMntWork in MakerList)
                {
                    if (MakerUMntWork.LogicalDeleteCode == 0 && !this.GoodsMakerDic.ContainsKey(MakerUMntWork.GoodsMakerCd))
                    {
                        this.GoodsMakerDic.Add(MakerUMntWork.GoodsMakerCd, MakerUMntWork.MakerName.Trim());
                    }
                }
            }
            return Status;
        }

        /// <summary>
        /// 拠点名の取得処理。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note       : 拠点名を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>拠点名</returns>
        private string getSectionName(string sectionCode)
        {
            string SectionGuideNm = string.Empty;
            if (string.IsNullOrEmpty(sectionCode)) return SectionGuideNm;
            sectionCode = sectionCode.Trim();
            // 00の場合、全社を設定します。
            if (sectionCode.Equals(StringZZ))
            {
                SectionGuideNm = WholeCompany;
            }
            else
            {
                if (this.SecInfoDic.ContainsKey(sectionCode))
                {
                    SectionGuideNm = this.SecInfoDic[sectionCode];
                }
            }
            return SectionGuideNm;
        }

        /// <summary>
        /// 倉庫名の取得処理。
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <remarks>
        /// <br>Note       : 倉庫名を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>倉庫名</returns>
        private string getWarehouseName(string warehouseCode)
        {
            string WarehouseName = string.Empty;
            if (string.IsNullOrEmpty(warehouseCode)) return WarehouseName;
            warehouseCode = warehouseCode.Trim();

            if (this.WarehouseDic.ContainsKey(warehouseCode))
            {
                WarehouseName = this.WarehouseDic[warehouseCode];
            }

            return WarehouseName;
        }

        /// <summary>
        /// メーカー名の取得処理。
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <remarks>
        /// <br>Note       : メーカー名を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>メーカー名</returns>
        private string getGoodsMakerName(string goodsMakerCode)
        {
            string GoodsMakerName = string.Empty;
            if (string.IsNullOrEmpty(goodsMakerCode)) return GoodsMakerName;
            int goodsMakerCodeInt = int.Parse(goodsMakerCode.Trim());

            if (this.GoodsMakerDic.ContainsKey(goodsMakerCodeInt))
            {
                GoodsMakerName = this.GoodsMakerDic[goodsMakerCodeInt];
            }

            return GoodsMakerName;
        }

        /// <summary>
        /// 品番曖昧検索区分の取得処理。
        /// </summary>
        /// <param name="inputGoodsNo">入力品番</param>
        /// <param name="resultGoodsNo">変更後品番</param>
        /// <remarks>
        /// <br>Note       : 品番曖昧検索区分を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>取得結果[0: 取得OK, 0以外: 取得エラー]</returns>
        private int getGoodsNoType(string inputGoodsNo, out string resultGoodsNo)
        {
            int GoodsNoType = 0;
            resultGoodsNo = string.Empty;
            if (string.IsNullOrEmpty(inputGoodsNo)) return GoodsNoType;

            if (!inputGoodsNo.Contains(StringHash))
            {
                // [*]なし（「と一致」）
                GoodsNoType = (int)GoodNoSearchType.MatchWith;
            }
            else if (inputGoodsNo.StartsWith(StringHash) && inputGoodsNo.EndsWith(StringHash))
            {
                // [*]…[*]（「を含む」）
                GoodsNoType = (int)GoodNoSearchType.IncludeWith;
            }
            else if (inputGoodsNo.StartsWith(StringHash))
            {
                // [*]…（「で終る」）
                GoodsNoType = (int)GoodNoSearchType.EndWith;
            }
            else if (inputGoodsNo.EndsWith(StringHash))
            {
                // …[*]（「で始る」）
                GoodsNoType = (int)GoodNoSearchType.StartWith;
            }
            resultGoodsNo = inputGoodsNo.Replace(StringHash, string.Empty);
            return GoodsNoType;
        }

        /// <summary>
        /// 未検品チェック行フィルタ文字列の取得処理。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 未検品チェック行フィルタ文字列を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>未検品チェック行フィルタ文字列</returns>
        private string GetCheckedRowFilter()
        {
            return string.Format(" {0} ='{1}' ",
                                   this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName, string.Empty);
        }

        /// <summary>
        /// 行検索フィルタ文字列の取得処理。
        /// </summary>
        /// <param name="searchStr">検索文字列</param>
        /// <remarks>
        /// <br>Note       : 行検索フィルタ文字列を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        /// <returns>行検索フィルタ文字列</returns>
        private string GetSearchStrRowFilter(string searchStr)
        {
            //return string.Format("{0} like '%{1}%' OR {2} like '%{3}%' OR {4} like '%{5}%' " // DEL 陳艶丹 2018/10/16 ハンディターミナル五次対応
            return string.Format("({0} like '%{1}%' OR {2} like '%{3}%' OR {4} like '%{5}%' " // ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応
                                + " OR {6} like '%{7}%' OR {8} like '%{9}%' OR {10} like '%{11}%' "
                                + " OR {12} like '%{13}%' OR {14} like '%{15}%' OR {16} like '%{17}%' "
                                + " OR {18} like '%{19}%' OR {20} like '%{21}%' OR {22} like '%{23}%' "
                                + " OR {24} like '%{25}%' OR {26} like '%{27}%' OR {28} like '%{29}%') ", // ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応
                                //+ " OR {24} like '%{25}%' OR {26} like '%{27}%' OR {28} like '%{29}%' ", // DEL 陳艶丹 2018/10/16 ハンディターミナル五次対応

                                   this.InspectDs.InspectList.InspectStatusDispColumn, searchStr,
                                   this.InspectDs.InspectList.HandTerminalCodeDispColumn, searchStr,
                                   this.InspectDs.InspectList.GoodsMakerNameColumn, searchStr,
                                   this.InspectDs.InspectList.GoodsNoColumn, searchStr,
                                   this.InspectDs.InspectList.GoodsNameColumn, searchStr,
                                   this.InspectDs.InspectList.InputCntColumn, searchStr,
                                   this.InspectDs.InspectList.ShipmentCntColumn, searchStr,
                                   this.InspectDs.InspectList.WarehouseShelfNoColumn, searchStr,
                                   this.InspectDs.InspectList.CustNmWareNmColumn, searchStr,
                                   this.InspectDs.InspectList.TransactionColumn, searchStr,
                                   this.InspectDs.InspectList.SalesSlipNumColumn, searchStr,
                                   this.InspectDs.InspectList.EmployeeCodeColumn, searchStr,
                                   this.InspectDs.InspectList.InspectDateColumn, searchStr,
                                   this.InspectDs.InspectList.InspectTimeColumn, searchStr,
                                   this.InspectDs.InspectList.ShipmentDayColumn.ColumnName, searchStr);
        }

        /// <summary>
        /// 未検品行検索フィルタ文字列の取得処理。
        /// </summary>
        /// <param name="searchStr">検索文字列</param>
        /// <remarks>
        /// <br>Note       : 未検品行検索フィルタ文字列を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>未検品行検索フィルタ文字列</returns>
        private string GetAllRowFilter(string searchStr)
        {
            return string.Format(" ({0} like '%{1}%' OR {2} like '%{3}%' OR {4} like '%{5}%' "
                                     + " OR {6} like '%{7}%' OR {8} like '%{9}%' OR {10} like '%{11}%' "
                                     + " OR {12} like '%{13}%' OR {14} like '%{15}%' OR {16} like '%{17}%' "
                                     + " OR {18} like '%{19}%' OR {20} like '%{21}%' OR {22} like '%{23}%' "
                                     + " OR {24} like '%{25}%' OR {26} like '%{27}%' OR {28} like '%{29}%') "
                                     + " AND {30} = '{31}' ",
                                        this.InspectDs.InspectList.InspectStatusDispColumn, searchStr,
                                        this.InspectDs.InspectList.HandTerminalCodeDispColumn, searchStr,
                                        this.InspectDs.InspectList.GoodsMakerNameColumn, searchStr,
                                        this.InspectDs.InspectList.GoodsNoColumn, searchStr,
                                        this.InspectDs.InspectList.GoodsNameColumn, searchStr,
                                        this.InspectDs.InspectList.InputCntColumn, searchStr,
                                        this.InspectDs.InspectList.ShipmentCntColumn, searchStr,
                                        this.InspectDs.InspectList.WarehouseShelfNoColumn, searchStr,
                                        this.InspectDs.InspectList.CustNmWareNmColumn, searchStr,
                                        this.InspectDs.InspectList.TransactionColumn, searchStr,
                                        this.InspectDs.InspectList.SalesSlipNumColumn, searchStr,
                                        this.InspectDs.InspectList.EmployeeCodeColumn, searchStr,
                                        this.InspectDs.InspectList.InspectDateColumn, searchStr,
                                        this.InspectDs.InspectList.InspectTimeColumn, searchStr,
                                        this.InspectDs.InspectList.ShipmentDayColumn.ColumnName, searchStr,
                                        this.InspectDs.InspectList.InspectStatusDispColumn.ColumnName, string.Empty);
        }

        /// <summary>
        /// 合計情報設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 合計情報を設定します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// </remarks>
        private void SetTotalCountProc()
        {
            int SalesCount = 0;
            int RentalCount = 0;
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // 移動出庫
            int moveOutWarehouseCount = 0;
            // 補充出庫
            int replenishOutWarehouseCount = 0;
            // 在庫仕入
            int stockStockSlipCount = 0;
            // 仕入
            int stockSlipCount = 0;
            // 移動入庫
            int moveInWarehouseCount = 0;
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<

            for (int i = 0; i < this.Inspect_Grid.Rows.Count; i++)
            {
                if (AcPaySlipCdEarnings.ToString().Equals((string)this.Inspect_Grid.Rows[i].Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value))
                {
                    SalesCount = SalesCount + 1;
                }
                else if (AcPaySlipCdRental.ToString().Equals((string)this.Inspect_Grid.Rows[i].Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value))
                {
                    RentalCount = RentalCount + 1;
                }
                // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                // 移動出庫
                else if (AcPaySlipCdMovementShipping.ToString().Equals((string)this.Inspect_Grid.Rows[i].Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value))
                {
                    moveOutWarehouseCount = moveOutWarehouseCount + 1;
                }
                // 補充出庫
                else if (AcPaySlipCdReplenish.ToString().Equals((string)this.Inspect_Grid.Rows[i].Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value))
                {
                    replenishOutWarehouseCount = replenishOutWarehouseCount + 1;
                }
                // 在庫仕入
                else if (AcPaySlipCdStockSupplier.ToString().Equals((string)this.Inspect_Grid.Rows[i].Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value))
                {
                    stockStockSlipCount = stockStockSlipCount + 1;
                }
                // 仕入や受託
                else if (AcPaySlipCdStock.ToString().Equals((string)this.Inspect_Grid.Rows[i].Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value)
                         || AcPaySlipCdAccession.ToString().Equals((string)this.Inspect_Grid.Rows[i].Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value))
                {
                    stockSlipCount = stockSlipCount + 1;
                }
                // 移動入庫
                else if (AcPaySlipCdMovingStock.ToString().Equals((string)this.Inspect_Grid.Rows[i].Cells[this.InspectDs.InspectList.AcPaySlipCdColumn.ColumnName].Value))
                {
                    moveInWarehouseCount = moveInWarehouseCount + 1;
                }
                // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            }

            this.lb_Sales.Text = SalesCount.ToString(TotalCountFormat);
            this.lb_Rental.Text = RentalCount.ToString(TotalCountFormat);
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // 合計表示_移動出庫
            this.lb_MoveOutWarehouse.Text = moveOutWarehouseCount.ToString(TotalCountFormat);
            // 合計表示_補充出庫
            this.lb_ReplenishOutWarehouse.Text = replenishOutWarehouseCount.ToString(TotalCountFormat);
            // 合計表示_在庫仕入
            this.lb_StockStockSlip.Text = stockStockSlipCount.ToString(TotalCountFormat);
            // 合計表示_仕入
            this.lb_StockSlip.Text = stockSlipCount.ToString(TotalCountFormat);
            // 合計表示_移動入庫
            this.lb_MoveInWarehouse.Text = moveInWarehouseCount.ToString(TotalCountFormat);
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
        }

        #region ◎ エラーメッセージ表示処理
        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void ErrMsgDispProc(string message, int status)
        {
            TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP, 							// エラーレベル
                AssemblyId,						// アセンブリＩＤまたはクラスＩＤ
                AssemblyName,						// プログラム名称
                MethodBase.GetCurrentMethod().Name, // 処理名称
                string.Empty,						// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                string.Empty, 						// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }

        /// <summary>
        /// インフォメッセージ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : インフォメッセージの表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void InfoMsgDispProc(string message, int status)
        {
            TMsgDisp.Show(this,											// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,					// エラーレベル
                          AssemblyId,									// アセンブリＩＤ
                          message, 										// 表示するメッセージ
                          status,										// ステータス値
                          MessageBoxButtons.OK);						// 表示するボタン
        }

        /// <summary>
        /// 確認（はい、いいえ）ダイアログ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <remarks>
        /// <br>Note       : 確認（はい、いいえ）ダイアログの表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>>DialogResult[OK: 確定, OK以外: キャンセル]</returns>
        private DialogResult QuestionYesNoProc(string message)
        {
            DialogResult Dialog = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    AssemblyId,
                    message,
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);
            return Dialog;
        }

        /// <summary>
        /// 確認（はい、いいえ、キャンセル）ダイアログ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <remarks>
        /// <br>Note       : 確認（はい、いいえ、キャンセル）ダイアログの表示を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        /// <returns>>DialogResult[OK: 確定, No:確定なし , Cancel: キャンセル]</returns>
        private DialogResult QuestionYesNoCancelProc(string message)
        {
            DialogResult Dialog = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    AssemblyId,
                    message,
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button1);
            return Dialog;
        }

        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        /// <summary>
        /// 確認（はい、いいえ、キャンセル）ダイアログ表示処理
        /// </summary>
        /// <param name="message">表示メッセージ</param>
        /// <returns>>DialogResult[OK: 確定, No:確定なし , Cancel: キャンセル]</returns>
        /// <remarks>
        /// <br>Note       : 確認（はい、いいえ、キャンセル）ダイアログの表示を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private DialogResult QuestionYesNoCancelProc2(string message)
        {
            DialogResult Dialog = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    AssemblyId,
                    message,
                    0,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxDefaultButton.Button2);
            return Dialog;
        }
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
        #endregion

        #region 列表示状態構築と保存処理
        /// <summary>
        /// 列表示状態クラスリスト構築処理
        /// </summary>
        /// <param name="columns">グリッドのカラムコレクション</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのカラムコレクションを元に、列表示状態クラスリストを構築します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private List<ColDisplayStatus> ColDisplayStatusListConstruction(Infragistics.Win.UltraWinGrid.ColumnsCollection columns)
        {
            List<ColDisplayStatus> colDisplayStatusList = new List<ColDisplayStatus>();

            // フォントサイズを格納
            ColDisplayStatus fontStatus = new ColDisplayStatus();
            fontStatus.Key = this.FontSize_tComboEditor.Name;
            fontStatus.VisiblePosition = -1;
            fontStatus.Width = (int)this.FontSize_tComboEditor.Value;
            colDisplayStatusList.Add(fontStatus);

            // グリッドから列表示状態クラスリストを構築
            // グループ内の各カラム
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns)
            {
                ColDisplayStatus colDisplayStatus = new ColDisplayStatus();
                colDisplayStatus.Key = column.Key;
                colDisplayStatus.VisiblePosition = column.Header.VisiblePosition;
                colDisplayStatus.HeaderFixed = column.Header.Fixed;
                colDisplayStatus.Width = column.Width;

                colDisplayStatusList.Add(colDisplayStatus);
            }

            return colDisplayStatusList;
        }

        /// <summary>
        /// 終了前処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 終了前処理を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        private void BeforeClosing()
        {
            // 列表示状態クラスリスト構築処理
            List<ColDisplayStatus> colDisplayStatusList = this.ColDisplayStatusListConstruction(this.Inspect_Grid.DisplayLayout.Bands[0].Columns);
            // 列表示状態クラスリストをXMLにシリアライズする
            this.Serialize(colDisplayStatusList, FileNameColDisplayStatus);
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            // 取寄区分
            UserSetting.OrderDivCd = (int)this.tComboEditor_ToRiyoSe.Value;
            // パターン区分
            UserSetting.PatternDiv = (int)this.tComboEditor_Pattern.Value;
            // 出力パス
            UserSetting.OutputFilePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\HTDATA\\");
            // 出力ファイル名
            UserSetting.OutputFileName = TextFileName;
            // シリアライズ
            this.Serialize();
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
        }

        /// <summary>
        /// 列表示状態クラスリストシリアライズ処理
        /// </summary>
        /// <param name="colDisplayStatusList">列表示状態クラスリスト</param>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストのシリアライズ処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void Serialize(List<ColDisplayStatus> colDisplayStatusList, string fileName)
        {
            ColDisplayStatus[] colDisplayStatusArray = new ColDisplayStatus[colDisplayStatusList.Count];
            colDisplayStatusList.CopyTo(colDisplayStatusArray);

            UserSettingController.SerializeUserSetting(colDisplayStatusArray, Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
        }

        /// <summary>
        /// 列表示状態クラスリストデシリアライズ処理
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>列表示状態クラスリスト</returns>
        /// <remarks>
        /// <br>Note       : 列表示状態クラスリストのデシリアライズ処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public List<ColDisplayStatus> Deserialize(string fileName)
        {
            List<ColDisplayStatus> retList = new List<ColDisplayStatus>();

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName)) == true)
            {
                try
                {
                    ColDisplayStatus[] retArray = UserSettingController.DeserializeUserSetting<ColDisplayStatus[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));

                    foreach (ColDisplayStatus colDisplayStatus in retArray)
                    {
                        retList.Add(colDisplayStatus);
                    }
                }
                catch (System.InvalidOperationException)
                {
                    UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings_GridInfo, fileName));
                }
            }

            return retList;
        }
        #endregion

        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        /// <summary>
        /// 委託先倉庫ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 委託先倉庫ガイドボタンクリックイベント。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private void ub_AfWarehouseGuide_Click(object sender, EventArgs e)
        {
            try
            {
                Warehouse WarehouseWork;
                int Status = this.WarehouseAccessor.ExecuteGuid(out WarehouseWork, this.EnterpriseCode);

                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.tEdit_AfWarehouseCode.Text = WarehouseWork.WarehouseCode.Trim();
                    this.lb_AfWarehouseName.Text = WarehouseWork.WarehouseName.Trim();

                    #region < 編集前データ保持 >
                    // 編集された親商品情報を編集前データとして保持
                    this.PrevAfWarehouseCode = this.tEdit_AfWarehouseCode.Text.Trim();
                    this.PrevAfWarehouseName = this.lb_AfWarehouseName.Text.Trim();
                    #endregion

                    // 次のコントロールへフォーカスを移動
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// 補充出庫選択処理イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : 補充出庫選択処理イベントを行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private void CheckEditor_ReplenishOutWarehouse_CheckStateChanged(object sender, EventArgs e)
        {
            if (CheckEditor_ReplenishOutWarehouse.Checked)
            {
                // 委託先倉庫コードと委託先倉庫ガイドを入力可にする。
                tEdit_AfWarehouseCode.Enabled = true;
                ub_AfWarehouseGuide.Enabled = true;
            }
            else 
            {
                // 委託先倉庫コードとガイドををグレーアウトさせて入力不可にする。
                tEdit_AfWarehouseCode.Enabled = false;
                ub_AfWarehouseGuide.Enabled = false;
                tEdit_AfWarehouseCode.Text = string.Empty;
                lb_AfWarehouseName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 検品数の取得処理
        /// </summary>
        /// <param name="acPaySlipCd">受払元伝票区分</param>
        /// <param name="acPayTransCd">受払元取引区分</param>
        /// <param name="inputCnt">入庫数</param>
        /// <param name="shipmentCnt">出庫数</param>
        /// <remarks>
        /// <br>Note       : 検品数の取得処理</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        /// <returns>検品数</returns>
        private double GetInspectCnt(int acPaySlipCd, int acPayTransCd, double inputCnt, double shipmentCnt)
        {
            // 検品数
            double inspectCnt=0d;

            switch (acPaySlipCd)
            {
                // 受払元伝票区分が「20:売上」OR「22：貸出」の場合
                case AcPaySlipCdEarnings:
                case AcPaySlipCdRental:
                    // 受払元取引区分が「10：通常」の場合、検品数⇒明細グリッド.出庫数
                    if(acPayTransCd==AcPayTransCdNormalSlip)
                    {
                        inspectCnt=shipmentCnt;
                    }
                    // 受払元取引区分が「11：返品」の場合、検品数⇒明細グリッド.入庫数
                    else if(acPayTransCd==AcPayTransCdReturned)
                    {
                        inspectCnt=inputCnt;
                    }
                    break;
                // 受払元伝票区分が「10：仕入」の場合
                case AcPaySlipCdStock:
                    // 受払元取引区分が「10：通常」の場合、検品数⇒明細グリッド.入庫数
                    if (acPayTransCd == AcPayTransCdNormalSlip)
                    {
                        inspectCnt = inputCnt;
                    }
                    // 受払元取引区分が「11：返品」の場合、検品数⇒明細グリッド.出庫数
                    else if (acPayTransCd == AcPayTransCdReturned)
                    {
                        inspectCnt = shipmentCnt;
                    }
                    break;
                // 受払元伝票区分が「30:移動出荷」の場合、検品数⇒明細グリッド.出庫数
                case AcPaySlipCdMovementShipping:
                    inspectCnt = shipmentCnt;
                    break;
                // 受払元伝票区分が「31:移動入荷」の場合、検品数⇒明細グリッド.入庫数
                case AcPaySlipCdMovingStock:
                    inspectCnt = inputCnt;
                    break;
                // 受払元伝票区分が「13：在庫仕入」の場合、検品数⇒明細グリッド.入庫数
                case AcPaySlipCdStockSupplier:
                    inspectCnt = inputCnt;
                    break;
                // 受払元伝票区分が「70：補充出庫」の場合、検品数⇒明細グリッド.出庫数
                case AcPaySlipCdReplenish:
                    inspectCnt = shipmentCnt;
                    break;
                default:
                    break;
            }

            return inspectCnt;
        }
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<
        #endregion
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        # region テキスト出力
        /// <summary>
        /// テキスト出力
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void ExportIntoTextFile()
        {
            string fullFilePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), ConstantManagement_ClientDirectory.PRTOUT + "\\HTDATA\\");
            string fullFileName = fullFilePath + TextFileName;
            
            try
            {
                // フォルダーがない場合
                if (!Directory.Exists(fullFilePath))
                {
                    // フォルダーを作成する
                    Directory.CreateDirectory(fullFilePath);
                }

                // ファイルが使用中チェック
                if (IsFileLocked(fullFileName) == (int)FileLocked_Status.FileLocked_LOCKED)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        FileAlrdyError, -1, MessageBoxButtons.OK);
                    return ;
                }

                // ファイルのアクセスチェック
                if (IsFileLocked(fullFileName) == (int)FileLocked_Status.FileLocked_CANNOTACCESS ||
                    IsFileLocked(fullFileName) == (int)FileLocked_Status.FileLocked_EOF)
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        FileAccessError, -1, MessageBoxButtons.OK);
                    return ;
                }
                //画面の入力チェック
                if (!this.CheckInputPara())
                {
                    return;
                }
                // 検索処理
                ArrayList TextHandyInspectList;
                int searchStus = this.SearchProcForTextOutPut(out TextHandyInspectList);
                switch (searchStus)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // テキスト出力
                            int outputStatus = ExportIntoTextFileProc(fullFileName, TextHandyInspectList);
                            if (outputStatus == (int)ConstantManagement.DB_Status.ctDB_EOF) // 9:異常終了
                            {
                                // 出力失敗
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                                    MsgOutputFailed, -1, MessageBoxButtons.OK);
                                return;
                            }
                            // 出力成功
                            if (outputStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                string msg = MsgOutputSucceeded + "\r\n" + "\r\n" + fullFilePath + "\r\n" + TextFileName;
                                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                                    msg, -1, MessageBoxButtons.OK);
                                return;
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        {
                            this.InfoMsgDispProc(DataInfoEmptyError, searchStus);
                            break;
                        }
                    // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                    case (-100):
                        {
                            // メモリアウト
                            this.InfoMsgDispProc(OutOfMemoryError, searchStus);
                            break;
                        }
                    // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                    default:
                        {
                            this.ErrMsgDispProc(InspectInfoSearchError, searchStus);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                            ex.Message, -1, MessageBoxButtons.OK);
            }
            finally
            {
            }
        }

        /// <summary>
        /// 指定したフルファイルは使用するかどうかをチェックしている
        /// </summary>
        /// <param name="fullFileName">フルファイル名</param>
        /// <returns>0:使用できる 1:他で使用中 2:アクセスできない 3その他エラー</returns>
        /// <remarks>
        /// <br>Note       : 指定したフルファイルは使用するかどうかをチェックしている。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private int IsFileLocked(string fullFileName)
        {
            FileStream stream = null;

            // ファイルが存在しない場合、テキスト出力時に作成している
            if (!File.Exists(fullFileName))
                return (int)FileLocked_Status.FileLocked_NORMAL;

            try
            {
                // ファイルがOpen
                stream = File.Open(fullFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                // ファイルが他で使用中です
                return (int)FileLocked_Status.FileLocked_LOCKED;

            }
            catch (UnauthorizedAccessException)
            {
                // ファイルがアクセスできない。
                return (int)FileLocked_Status.FileLocked_CANNOTACCESS;
            }
            catch (Exception)
            {
                // その他エラー
                return (int)FileLocked_Status.FileLocked_EOF;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return (int)FileLocked_Status.FileLocked_NORMAL;
        }

        #region ■列挙体
        /// <summary>
        /// ファイルは使用フラグ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ファイルは使用フラグ</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private enum FileLocked_Status
        {
            //ファイルは使用できる
            FileLocked_NORMAL = 0,
            //ファイルが他で使用中です
            FileLocked_LOCKED = 1,
            //ファイルがアクセスできない。
            FileLocked_CANNOTACCESS = 2,
            //その他エラー
            FileLocked_EOF = 3,
        }
        #endregion  

        /// <summary>
        /// テキスト出力の検索処理
        /// </summary>
        /// <param name="handyInspectList">検品情報リスト</param>
        /// <returns>[0: 正常, 4: 検索結果0件,0、4以外: 異常]</returns>
        /// <remarks>
        /// <br>Note       : テキスト出力の検索処理を行ないます。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private int SearchProcForTextOutPut(out ArrayList handyInspectList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            handyInspectList = new ArrayList();
            // パラメータを設定します。
            HandyInspectParamWork handyInspectParamWork = new HandyInspectParamWork();
            // 企業コード
            handyInspectParamWork.EnterpriseCode = this.EnterpriseCode;
            // 取寄区分
            handyInspectParamWork.OrderDivCd = (int)this.tComboEditor_ToRiyoSe.Value;
            // 入出荷日開始
            handyInspectParamWork.St_SalesDate = this.tDate_IoGoodsDayBegin.GetDateTime();
            // 入出荷日終了
            handyInspectParamWork.Ed_SalesDate = this.tDate_IoGoodsDayEnd.GetDateTime();
            handyInspectParamWork.SectionCode = this.tEdit_SectionCodeAllowZero.Text.Trim();
            handyInspectParamWork.WarehouseCode = this.tEdit_WarehouseCode.Text.Trim();
            handyInspectParamWork.AfWarehouseCd = this.tEdit_AfWarehouseCode.Text.Trim();
            // 検品日開始
            handyInspectParamWork.St_InspectDate = this.tDate_InspectDayBegin.GetDateTime();
            // 検品日終了
            DateTime ParaInspectDayEnd = this.tDate_InspectDayEnd.GetDateTime();
            if (ParaInspectDayEnd != DateTime.MinValue)
            {
                ParaInspectDayEnd = ParaInspectDayEnd.AddDays(1);
                handyInspectParamWork.Ed_InspectDate = ParaInspectDayEnd;
            }
            // メーカーコード
            handyInspectParamWork.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // 検品担当者コード
            handyInspectParamWork.EmployeeCode = this.tEdit_EmployeeCode.Text.Trim();
            // 品番検索区分
            string ResultGoodsNo = string.Empty;
            handyInspectParamWork.GoodsNoSrchTyp = this.getGoodsNoType(this.tEdit_GoodsNo.Text.Trim(), out ResultGoodsNo);
            // 品番
            handyInspectParamWork.GoodsNo = ResultGoodsNo;
            // パターン
            handyInspectParamWork.Pattern = (int)this.tComboEditor_Pattern.Value;
            // 取引対象_売上
            if (this.CheckEditor_Sales.Checked)
            {
                handyInspectParamWork.TransSales = CheckBoxSelected;
            }
            // 取引対象_貸出
            if (this.CheckEditor_Rental.Checked)
            {
                handyInspectParamWork.TransLend = CheckBoxSelected;
            }
            // 取引対象_移動出庫
            if (this.CheckEditor_MoveOutWarehouse.Checked)
            {
                handyInspectParamWork.TransMoveOutWarehouse = CheckBoxSelected;
            }
            // 取引対象_補充出庫
            if (this.CheckEditor_ReplenishOutWarehouse.Checked)
            {
                handyInspectParamWork.TransReplenishOutWarehouse = CheckBoxSelected;
            }
            // 取引対象_在庫仕入
            if (this.CheckEditor_StockStockSlip.Checked)
            {
                handyInspectParamWork.TransStockStockSlip = CheckBoxSelected;
            }
            // 取引対象_仕入
            if (this.CheckEditor_StockSlip.Checked)
            {
                handyInspectParamWork.TransStockSlip = CheckBoxSelected;
            }
            // 取引対象_移動入庫
            if (this.CheckEditor_MoveInWarehouse.Checked)
            {
                handyInspectParamWork.TransMoveInWarehouse = CheckBoxSelected;
            }
            // 抽出中画面インスタンス作成
            Broadleaf.Windows.Forms.SFCMN00299CA sfcmn00299ca = new Broadleaf.Windows.Forms.SFCMN00299CA();
            sfcmn00299ca.Title = SearchFormTitle;
            sfcmn00299ca.Message = SearchFormMessage;
            try
            {
                // 抽出中画面を表示します。
                sfcmn00299ca.Show();
                status = (int)this.InspectInfoAccessor.Search(handyInspectParamWork, out handyInspectList);
            }
            catch (Exception)
            {
                return status;
            }
            finally
            {
                // 抽出中画面を閉じます。
                sfcmn00299ca.Close();
            }
            return status;
        }

        /// <summary>
        /// テキスト出力
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="inspectList">検品情報リスト</param>
        /// <remarks>
        /// <br>Note       : テキスト出力。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private int ExportIntoTextFileProc(string fileName, ArrayList inspectList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            FormattedTextWriter formattedTextWriter = new FormattedTextWriter();
            int outputCount = 0;
            DataView view = null;
            // 項目括り適用
            String typeStr = string.Empty;
            Int32 typeInt32 = new int();
            try
            {
                List<String> schemeList;
                getSchemeList(out schemeList);
                // 出力項目名
                formattedTextWriter.SchemeList = schemeList;

                // テーブル列情報構築処理
                if (TextOutputTable == null)
                {
                    this.TextTableColumnConstruction();
                }

                // テキスト出力テーブルに情報設定処理
                TextInspectInfoSetting(inspectList);

                view = new DataView(TextOutputTable);

                formattedTextWriter.DataSource = view;

                #region オプションセット
                // ファイル名
                formattedTextWriter.OutputFileName = fileName;
                // 区切り文字
                formattedTextWriter.Splitter = ",";
                // 項目括り文字
                formattedTextWriter.Encloser = "\"";
                // 固定幅
                formattedTextWriter.FixedLength = false;
                // タイトル行出力
                formattedTextWriter.CaptionOutput = true;
                formattedTextWriter.ReplaceList = null;
                // 項目括り適用
                List<Type> enclosingTypeList = new List<Type>();
                enclosingTypeList.Add(typeStr.GetType());
                enclosingTypeList.Add(typeInt32.GetType());
                formattedTextWriter.EnclosingTypeList = enclosingTypeList;
                formattedTextWriter.FormatList = null;
               
                #endregion
                status = formattedTextWriter.TextOut(out outputCount);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                outputCount = 0;
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            finally
            {
                // メモリの解放
                TextOutputTable.Clear();
                formattedTextWriter = null;
            }
            return status;
        }

        /// <summary>
        /// テーブル列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : テーブルの列情報を構築します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void TextTableColumnConstruction()
        {
            //----------------------------------------------------------------
            // テーブル列定義
            //----------------------------------------------------------------
            TextOutputTable = new DataTable(TextOutputInspectTable);
            string defaultString = string.Empty;
            int defaultint = 0;
            // 入出荷日
            TextOutputTable.Columns.Add(ShipmentDayCol, typeof(string));
            TextOutputTable.Columns[ShipmentDayCol].DefaultValue = defaultString;
            TextOutputTable.Columns[ShipmentDayCol].Caption = TextShipmentDayCaption;
            // 検品日付
            TextOutputTable.Columns.Add(InspectCol, typeof(string));
            TextOutputTable.Columns[InspectCol].DefaultValue = defaultString;
            TextOutputTable.Columns[InspectCol].Caption = TextInspectDateCaption;
            // 検品時刻
            TextOutputTable.Columns.Add(InspectTimeCol, typeof(string));
            TextOutputTable.Columns[InspectTimeCol].DefaultValue = defaultString;
            TextOutputTable.Columns[InspectTimeCol].Caption = TextInspectTimeCaption;
            // 検（検品区分）
            TextOutputTable.Columns.Add(InspectStatusCol, typeof(int));
            TextOutputTable.Columns[InspectStatusCol].DefaultValue = defaultint;
            TextOutputTable.Columns[InspectStatusCol].Caption = TextInspectStatusCaption;
            // 検品区分名
            TextOutputTable.Columns.Add(InspectStNameCol, typeof(string));
            TextOutputTable.Columns[InspectStNameCol].DefaultValue = defaultString;
            TextOutputTable.Columns[InspectStNameCol].Caption = TextInspectStNameCaption;
            // 検品（検品処理方法）
            TextOutputTable.Columns.Add(HandTerminalCodeCol, typeof(int));
            TextOutputTable.Columns[HandTerminalCodeCol].DefaultValue = defaultint;
            TextOutputTable.Columns[HandTerminalCodeCol].Caption = TextHandTerminalCodeCaption;
            // 検品処理方法名
            TextOutputTable.Columns.Add(HandTerminalNameCol, typeof(string));
            TextOutputTable.Columns[HandTerminalNameCol].DefaultValue = defaultString;
            TextOutputTable.Columns[HandTerminalNameCol].Caption = TextHandTerminalNameCaption;
            // 取引
            TextOutputTable.Columns.Add(TransactionCol, typeof(string));
            TextOutputTable.Columns[TransactionCol].DefaultValue = defaultString;
            TextOutputTable.Columns[TransactionCol].Caption = TextTransactionCaption;
            // 伝票番号
            TextOutputTable.Columns.Add(SalesSlipNumCol, typeof(string));
            TextOutputTable.Columns[SalesSlipNumCol].DefaultValue = defaultString;
            TextOutputTable.Columns[SalesSlipNumCol].Caption = TextSalesSlipNumCaption;
            // 行番号
            TextOutputTable.Columns.Add(SalesRowNoCol, typeof(Int32));
            TextOutputTable.Columns[SalesRowNoCol].DefaultValue = defaultint;
            TextOutputTable.Columns[SalesRowNoCol].Caption = TextSalesRowNoCaption;
            // 検品担当者
            TextOutputTable.Columns.Add(EmployeeCodeCol, typeof(string));
            TextOutputTable.Columns[EmployeeCodeCol].DefaultValue = defaultString;
            TextOutputTable.Columns[EmployeeCodeCol].Caption = TextEmployeeCodeCaption;
            // 検品担当名
            TextOutputTable.Columns.Add(EmployeeNameCol, typeof(string));
            TextOutputTable.Columns[EmployeeNameCol].DefaultValue = defaultString;
            TextOutputTable.Columns[EmployeeNameCol].Caption = TextEmployeeNameCaption;
            // 商品メーカーコード
            TextOutputTable.Columns.Add(GoodsMakerCdCol, typeof(string));
            TextOutputTable.Columns[GoodsMakerCdCol].DefaultValue = defaultString;
            TextOutputTable.Columns[GoodsMakerCdCol].Caption = TextGoodsMakerCdCaption;
            // 商品メーカー名称
            TextOutputTable.Columns.Add(GoodsMakerNameCol, typeof(string));
            TextOutputTable.Columns[GoodsMakerNameCol].DefaultValue = defaultString;
            TextOutputTable.Columns[GoodsMakerNameCol].Caption = TextGoodsMakerNameCaption;
            // 商品番号
            TextOutputTable.Columns.Add(GoodsNoCol, typeof(string));
            TextOutputTable.Columns[GoodsNoCol].DefaultValue = defaultString;
            TextOutputTable.Columns[GoodsNoCol].Caption = TextGoodsNoCaption;
            // 品名
            TextOutputTable.Columns.Add(GoodsNameCol, typeof(string));
            TextOutputTable.Columns[GoodsNameCol].DefaultValue = defaultString;
            TextOutputTable.Columns[GoodsNameCol].Caption = TextGoodsNameCaption;
            // 倉庫コード
            TextOutputTable.Columns.Add(WarehouseCodeCol, typeof(string));
            TextOutputTable.Columns[WarehouseCodeCol].DefaultValue = defaultString;
            TextOutputTable.Columns[WarehouseCodeCol].Caption = TextWarehouseCodeCaption;
            // 倉庫名
            TextOutputTable.Columns.Add(WarehouseNameCol, typeof(string));
            TextOutputTable.Columns[WarehouseNameCol].DefaultValue = defaultString;
            TextOutputTable.Columns[WarehouseNameCol].Caption = TextWarehouseNameCaption;
            // 棚番
            TextOutputTable.Columns.Add(WarehouseShelfNoCol, typeof(string));
            TextOutputTable.Columns[WarehouseShelfNoCol].DefaultValue = defaultString;
            TextOutputTable.Columns[WarehouseShelfNoCol].Caption = TextWarehouseShelfNoCaption;
            // 仕入先/得意先/相手倉庫
            TextOutputTable.Columns.Add(CustNmWareNmCol, typeof(string));
            TextOutputTable.Columns[CustNmWareNmCol].DefaultValue = defaultString;
            TextOutputTable.Columns[CustNmWareNmCol].Caption = TextCustNmWareNmCaption;
            // 出庫数
            TextOutputTable.Columns.Add(ShipmentCntCol, typeof(string));
            TextOutputTable.Columns[ShipmentCntCol].DefaultValue = defaultString;
            TextOutputTable.Columns[ShipmentCntCol].Caption = TextShipmentCntCaption;
            // 入庫数
            TextOutputTable.Columns.Add(InputCntCol, typeof(string));
            TextOutputTable.Columns[InputCntCol].DefaultValue = defaultString;
            TextOutputTable.Columns[InputCntCol].Caption = TextInputCntCaption;
        }

        /// <summary>
        /// スキーマリストを取得する
        /// </summary>
        /// <param name="schemeList">スキーマリスト</param>
        /// <remarks>
        /// <br>Note       : スキーマリストを取得する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// <br></br>
        /// </remarks>
        private void getSchemeList(out List<String> schemeList)
        {
            schemeList = new List<string>();
            schemeList.Add(ShipmentDayCol);
            schemeList.Add(InspectCol);
            schemeList.Add(InspectTimeCol);
            schemeList.Add(InspectStatusCol);
            schemeList.Add(InspectStNameCol);
            schemeList.Add(HandTerminalCodeCol);
            schemeList.Add(HandTerminalNameCol);
            schemeList.Add(TransactionCol);
            schemeList.Add(SalesSlipNumCol);
            schemeList.Add(SalesRowNoCol);
            schemeList.Add(EmployeeCodeCol);
            schemeList.Add(EmployeeNameCol);
            schemeList.Add(GoodsMakerCdCol);
            schemeList.Add(GoodsMakerNameCol);
            schemeList.Add(GoodsNoCol);
            schemeList.Add(GoodsNameCol);
            schemeList.Add(WarehouseCodeCol);
            schemeList.Add(WarehouseNameCol);
            schemeList.Add(WarehouseShelfNoCol);
            schemeList.Add(CustNmWareNmCol);
            schemeList.Add(ShipmentCntCol);
            schemeList.Add(InputCntCol);
        }

        /// <summary>
        /// テキスト出力テーブルに情報設定処理
        /// </summary>
        /// <param name="inspectList">検品情報リスト</param>
        /// <remarks>
        /// <br>Note       : テキスト出力テーブルに検品情報を設定します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private void TextInspectInfoSetting(ArrayList inspectList)
        {
            if (inspectList == null || inspectList.Count == InspectGridRowsCountZero)
            {
                return;
            }
            DataRow Row = null;
            foreach (InspectRefDataWork InspectRefDataWork in inspectList)
            {
                //データソース区分 1:売上データ
                if (InspectRefDataWork.DataSourceDiv == 1)
                {
                    if (InspectRefDataWork.LogicalDeleteCode == DataLogicalDeleted)
                    {
                        // 受払元伝票区分
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdRental;
                        // 受払元取引区分
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdReturned;
                    }
                    else
                    {
                        if (InspectRefDataWork.AcptAnOdrStatus == AcptAnOdrStatusEarnings && InspectRefDataWork.SalesSlipCdDtl == SalesSlipCdDtlDivSalesSlip)
                        {
                            // 受払元伝票区分
                            InspectRefDataWork.AcPaySlipCd = AcPaySlipCdEarnings;
                            // 受払元取引区分
                            InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                        }
                        else if (InspectRefDataWork.AcptAnOdrStatus == AcptAnOdrStatusEarnings && InspectRefDataWork.SalesSlipCdDtl == SalesSlipCdDtlDivReturned)
                        {
                            // 受払元伝票区分
                            InspectRefDataWork.AcPaySlipCd = AcPaySlipCdEarnings;
                            // 受払元取引区分
                            InspectRefDataWork.AcPayTransCd = AcPayTransCdReturned;
                        }
                        else if (InspectRefDataWork.AcptAnOdrStatus == AcptAnOdrStatusShipment && InspectRefDataWork.SalesSlipCdDtl == SalesSlipCdDtlDivSalesSlip)
                        {
                            // 受払元伝票区分
                            InspectRefDataWork.AcPaySlipCd = AcPaySlipCdRental;
                            // 受払元取引区分
                            InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                        }
                        else if (InspectRefDataWork.AcptAnOdrStatus == AcptAnOdrStatusShipment && InspectRefDataWork.SalesSlipCdDtl == SalesSlipCdDtlDivReturned)
                        {
                            // 受払元伝票区分
                            InspectRefDataWork.AcPaySlipCd = AcPaySlipCdRental;
                            // 受払元取引区分
                            InspectRefDataWork.AcPayTransCd = AcPayTransCdReturned;
                        }
                    }
                }
                //データソース区分 2:仕入データ
                else if (InspectRefDataWork.DataSourceDiv == 2)
                {
                    // 仕入形式が「0:仕入」、売上伝票区分(明細)が「0:仕入」
                    if (InspectRefDataWork.SupplierFormal == 0 && InspectRefDataWork.StockSlipCdDtl == 0)
                    {
                        // 受払元伝票区分「10」：仕入
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdStock;
                        // 受払元取引区分 「10」：通常伝票
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                    }
                    // 仕入形式が「0:仕入」、売上伝票区分(明細)が「1:返品」
                    else if (InspectRefDataWork.SupplierFormal == 0 && InspectRefDataWork.StockSlipCdDtl == 1)
                    {
                        // 受払元伝票区分「10」：仕入
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdStock;
                        // 受払元取引区分「11」：返品
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdReturned;
                    }
                    // 仕入形式が「1:入荷」、売上伝票区分(明細)が「0:仕入」
                    else if (InspectRefDataWork.SupplierFormal == 1 && InspectRefDataWork.StockSlipCdDtl == 0)
                    {
                        // 受払元伝票区分「11」：受託
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdAccession;
                        // 受払元取引区分「10」：通常伝票
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                    }
                }
                //データソース区分 3:在庫移動データ
                else if (InspectRefDataWork.DataSourceDiv == 3)
                {
                    // 移動形式 1:在庫出庫 or 2:倉庫出庫
                    if (InspectRefDataWork.StockMoveFormal == 1 || InspectRefDataWork.StockMoveFormal == 2)
                    {
                        // 受払元伝票区分「30」：移動出荷
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdMovementShipping;
                        // 受払元取引区分「10」：通常伝票
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                    }
                    // 移動形式 3:在庫入庫 or 4:倉庫入庫
                    else if (InspectRefDataWork.StockMoveFormal == 3 || InspectRefDataWork.StockMoveFormal == 4)
                    {
                        // 受払元伝票区分「31」：移動入荷
                        InspectRefDataWork.AcPaySlipCd = AcPaySlipCdMovingStock;
                        // 受払元取引区分「10」：通常伝票
                        InspectRefDataWork.AcPayTransCd = AcPayTransCdNormalSlip;
                    }
                }

                Row = TextOutputTable.NewRow();

                // 入出荷日
                Row[ShipmentDayCol] = this.GetStringDateTimeForInt(InspectRefDataWork.ShipmentDay);

                // 検品日付
                Row[InspectCol] = this.GetDateForInspectDateTime(InspectRefDataWork.InspectDateTime);

                // 検品時刻
                Row[InspectTimeCol] = this.GetTimeForInspectDateTime(InspectRefDataWork.InspectDateTime);

                // 抽出結果データ.検品ステータスが「1：検品中」
                if (InspectRefDataWork.InspectStatus == InspectStatusDuring)
                {
                    Row[InspectStatusCol] = InspectStatusDuring;
                    Row[InspectStNameCol] = InspectDuring;
                }
                // 抽出データ.検品ステータスが「2：ピッキング済み」
                else if (InspectRefDataWork.InspectStatus == InspectStatusAlreadyPicking)
                {
                    Row[InspectStatusCol] = InspectStatusAlreadyPicking;
                    Row[InspectStNameCol] = InspectAlreadyPicking;
                }
                // 抽出データ.検品ステータスが「3：検品済み」
                else if (InspectRefDataWork.InspectStatus == InspectStatusAlreadyInspected)
                {
                    Row[InspectStatusCol] = InspectStatusAlreadyInspected;
                    Row[InspectStNameCol] = InspectAlreadyInspected;
                }
                // 抽出データ.検品ステータスが「2」「3」以外
                else
                {
                    // 未検品
                    Row[InspectStatusCol] = 0;
                    Row[InspectStNameCol] = Inspect;
                }

                // 検品
                // 抽出データ.ハンディターミナル区分が「1」の場合
                if (InspectRefDataWork.HandTerminalCode == DivHandTerminal)
                {
                    Row[HandTerminalCodeCol] = DivHandTerminal;
                    Row[HandTerminalNameCol] = StringHT;
                }
                // 抽出データ.ハンディターミナル区分が「9」の場合
                else if (InspectRefDataWork.HandTerminalCode == DivOtherwise)
                {
                    Row[HandTerminalCodeCol] = DivOtherwise;
                    Row[HandTerminalNameCol] = StringPC;
                }
                // 抽出データ.ハンディターミナル区分が「1」「9」以外の場合
                else
                {
                    Row[HandTerminalCodeCol] = 0;
                    Row[HandTerminalNameCol] = " ";
                }

                // 取引
                // 受払元伝票区分が「20」の場合、「売上」でセットする。
                if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdEarnings)
                {
                    Row[TransactionCol] = Sales;
                }
                // 受払元伝票区分が「22」の場合、「貸出」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdRental)
                {
                    Row[TransactionCol] = Rental;
                }
                // 受払元伝票区分が「10」OR「11」の場合、「仕入」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdStock || InspectRefDataWork.AcPaySlipCd == AcPaySlipCdAccession)
                {
                    Row[TransactionCol] = StockSlip;
                }
                // 受払元伝票区分が「13」の場合、「在庫仕入」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdStockSupplier)
                {
                    Row[TransactionCol] = StockStockSlip;
                }
                // 受払元伝票区分が「30」の場合、「移動出庫」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdMovementShipping)
                {
                    Row[TransactionCol] = MoveOutWarehouse;
                }
                // 受払元伝票区分が「31」の場合、「移動入庫」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdMovingStock)
                {
                    Row[TransactionCol] = MoveInWarehouse;
                }
                // 受払元伝票区分が「70」の場合、「補充出庫」でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdReplenish)
                {
                    Row[TransactionCol] = ReplenishOutWarehouse;
                }
                // 上記以外場合
                else
                {
                    Row[TransactionCol] = string.Empty;
                }

                // 伝票番号
                if ((int)this.tComboEditor_Pattern.Value == PatternValue3)
                {
                    // 検品のみの場合
                    Row[SalesSlipNumCol] = "";
                }
                else
                {
                    Row[SalesSlipNumCol] = InspectRefDataWork.SalesSlipNum.PadLeft(9, CharZero);
                }

                // 行番号
                Row[SalesRowNoCol] = InspectRefDataWork.SalesRowNo;

                // 検品担当者
                Row[EmployeeCodeCol] = InspectRefDataWork.EmployeeCode.Trim().PadLeft(PadLeftIndexFour, CharZero);
                if (InspectRefDataWork.EmployeeCode.Trim().PadLeft(PadLeftIndexFour, CharZero).Equals("0000"))
                {
                    Row[EmployeeCodeCol] = string.Empty;
                }

                // 検品担当名
                Row[EmployeeNameCol] = this.InspectInfoAccessor.GetEmployeeName(InspectRefDataWork.EmployeeCode.Trim());

                // 商品メーカーコード
                Row[GoodsMakerCdCol] = InspectRefDataWork.GoodsMakerCd.ToString().PadLeft(PadLeftIndexFour, CharZero);

                // 商品メーカー名称
                Row[GoodsMakerNameCol] = InspectRefDataWork.MakerName;

                // 商品番号
                Row[GoodsNoCol] = InspectRefDataWork.GoodsNo;

                // 品名
                Row[GoodsNameCol] = InspectRefDataWork.GoodsName;

                // 倉庫コード
                Row[WarehouseCodeCol] = InspectRefDataWork.WarehouseCode.Trim().PadLeft(PadLeftIndexFour, CharZero);
                if (InspectRefDataWork.WarehouseCode.Trim().PadLeft(PadLeftIndexFour, CharZero).Equals("0000"))
                {
                    Row[WarehouseCodeCol] = string.Empty;
                }

                // 倉庫名
                Row[WarehouseNameCol] = this.getWarehouseName(InspectRefDataWork.WarehouseCode.PadLeft(PadLeftIndexFour, CharZero));

                // 棚番
                Row[WarehouseShelfNoCol] = InspectRefDataWork.WarehouseShelfNo.Trim();

                // 受払元伝票区分が「20」「22」「10」「11」の場合
                if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdEarnings || InspectRefDataWork.AcPaySlipCd == AcPaySlipCdRental ||
                    InspectRefDataWork.AcPaySlipCd == AcPaySlipCdStock || InspectRefDataWork.AcPaySlipCd == AcPaySlipCdAccession)
                {
                    // 仕入先/得意先/相手倉庫
                    if (!string.IsNullOrEmpty(InspectRefDataWork.CustomerSnm) && !string.IsNullOrEmpty(InspectRefDataWork.WarehouseName))
                    {
                        Row[CustNmWareNmCol] = InspectRefDataWork.CustomerSnm + StringZanSlash + InspectRefDataWork.WarehouseName;
                    }
                    else if (string.IsNullOrEmpty(InspectRefDataWork.CustomerSnm) && string.IsNullOrEmpty(InspectRefDataWork.WarehouseName))
                    {
                        Row[CustNmWareNmCol] = string.Empty;
                    }
                    else if (string.IsNullOrEmpty(InspectRefDataWork.CustomerSnm))
                    {
                        Row[CustNmWareNmCol] = InspectRefDataWork.WarehouseName;
                    }
                    else if (string.IsNullOrEmpty(InspectRefDataWork.WarehouseName))
                    {
                        Row[CustNmWareNmCol] = InspectRefDataWork.CustomerSnm;
                    }
                }
                // 受払元伝票区分が「30」「31」「13」の場合は抽出結果データ.取引先名称でセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdMovementShipping || InspectRefDataWork.AcPaySlipCd == AcPaySlipCdMovingStock ||
                    InspectRefDataWork.AcPaySlipCd == AcPaySlipCdStockSupplier)
                {
                    Row[CustNmWareNmCol] = InspectRefDataWork.CustomerSnm;
                }
                // 受払元伝票区分が「70」の場合はNULLでセットする。
                else if (InspectRefDataWork.AcPaySlipCd == AcPaySlipCdReplenish)
                {
                    Row[CustNmWareNmCol] = null;
                }

                // 出庫数
                if (InspectRefDataWork.ShipmentCnt != ShipmentCntZero)
                {
                    Row[ShipmentCntCol] = InspectRefDataWork.ShipmentCnt.ToString(CountFormat);
                }
                else
                {
                    Row[ShipmentCntCol] = "";
                }

                // 入庫数
                if (InspectRefDataWork.InputCnt != InputCntZero)
                {
                    Row[InputCntCol] = InspectRefDataWork.InputCnt.ToString(CountFormat);
                }
                else
                {
                    Row[InputCntCol] = "";
                }

                this.TextOutputTable.Rows.Add(Row);
            }
        }
        #endregion
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
    }
   
    // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
    # region [前回値保持]
    /// <summary>
    /// 前回値保持設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 前回値情報を管理するクラス</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2018/10/16</br>
    /// </remarks>
    [Serializable]
    public class PrevInputValue
    {
        // 取寄区分
        private int _orderDivCd;

        // パターン区分
        private int _patternDiv;

        // 出力パス
        private string _outputFilePath;
        // 出力ファイル名
        private string _outputFileName;

        /// <summary>
        /// 前回値保持クラス
        /// </summary>
        public PrevInputValue()
        {
            
        }

        /// <summary>
        /// 取寄区分
        /// </summary>
        public int OrderDivCd
        {
            get { return _orderDivCd; }
            set { _orderDivCd = value; }
        }

        /// <summary>
        /// パターン区分
        /// </summary>
        public int PatternDiv
        {
            get { return _patternDiv; }
            set { _patternDiv = value; }
        }

         /// <summary>
         /// 出力パス
         /// </summary>
        public string OutputFilePath
        {
            get { return _outputFilePath; }
            set { _outputFilePath = value; }
        }

        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string OutputFileName
        {
            get { return _outputFileName; }
            set { _outputFileName = value; }
        }
    }
    #endregion
    // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
}
