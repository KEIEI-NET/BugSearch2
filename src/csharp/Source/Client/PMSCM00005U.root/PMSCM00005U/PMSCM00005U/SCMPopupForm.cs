//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : SCMポップアップ
// プログラム概要   : ポップアップ処理を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 作 成 日  2009/05/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/02  修正内容 : 更新件数の表示方法の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/03  修正内容 : ローカル設定対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/09  修正内容 : 画面イメージ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/16  修正内容 : 複数表示対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/28  修正内容 : 一部回答、キャンセル分も表示する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優
// 作 成 日  2010/06/17  修正内容 : キャンセル分の判断方式を変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/06/17  修正内容 : Delphi売伝を起動するように変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2010/07/14  修正内容 : 売伝起動時、起動パラメータ仕様変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2010/07/30  修正内容 : サーバーからの呼び出しによりPOPUPせず、
//                               : クライアント側で一定時間間隔でPOPUP実行するよう変更。
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 21024　佐々木 健
// 作 成 日  2010/11/17  修正内容 : SCM検証結果対応(MANTIS[0016654])
//                                 ①売上伝票入力を起動した問合せ番号は、表示中のリストから削除する。
//                                 ②ポップアップ画面を起動中に新着があった場合、表示中のデータに追加してデータを表示する。
//                                 ③タスクトレイの初期表示アイコンを緑（新着無し）に変更する。
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 21024　佐々木 健
// 作 成 日  2010/12/22  修正内容 : SCM検証結果対応
//                                 ①キャンセル処理をポップアップから出来るように変更
//                                 ②データ確認して新着データが無くなった場合には画面を閉じるように変更
//                                 ③画面表示中に再描画がある場合は、画面サイズ等を変更しない
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/25  修正内容 : 回答済み明細を非表示にする
//----------------------------------------------------------------------------//
// 管理番号  10703242-00 作成担当 : 30517　夏野 駿希
// 作 成 日  2011/05/27  修正内容 : SCMデモ用ツールで作成した設定ファイルを読込、インターバルを秒単位で設定する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/07/18  修正内容 : 自動回答分も画面上にポップアップする
//                                : 自動回答分も画面上にポップアップする設定を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/08/19  修正内容 : Redmine#23241対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/08/11  修正内容 : PCC-UOEリモート伝票発行
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011/08/19  修正内容 : PCC-UOEメールメッセージ送信
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/06  修正内容 : Websync PCCUOEのチャンネルを追加
//----------------------------------------------------------------------------//
/// 管理番号             作成担当 : zhouzy
/// 作 成 日 2011.09.10	 修正内容 : 1.PCC-UOE WebSync チャンネルを統一する。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/13  修正内容 : リモート伝票発行、ＳＦ側に渡す条件の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhouzy
// 作 成 日  2011/09/20  修正内容 : ＰＯＰUPよりエントリ起動する時の不具合を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/09/29  修正内容 : redmine #25635 常駐プログラム（ポップアップ）を終了出来ないように変更の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2011/10/10  修正内容 : redmine #25786 PCCUOE／ＰＭ側 新着ポップアップ表示の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22024 寺坂 誉志
// 作 成 日  2012/04/10  修正内容 : 高速化対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2012/04/18  修正内容 : PM-SCM高速化対応の修正
//                                 （※検索結果が不正にならないよう、キャッシュクリア）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22024 寺坂 誉志
// 作 成 日  2012/04/24  修正内容 : 状態表示対応(SF側)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/06/06  修正内容 : 自動回答速度改善により受信処理の起動方法が変更され
//                                  SCMCheckerのログが出力されなくなったので出力されるように変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/26  修正内容 : SCM障害№71対応 自動回答時にポップアップを表示する件の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/07/11  修正内容 : システムテスト障害№80 SCM障害№71対応時の修正漏れ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/07/17  修正内容 : システムテスト障害№96 SCM障害№71対応時の修正漏れ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/07/19  修正内容 : システムテスト障害№113 システムテスト障害№96対応の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/07/23  修正内容 : 2012/08/07配信 システムテスト障害№115対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/07/26  修正内容 : 2012/08/07配信 システムテスト障害№125の対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/08/23  修正内容 : 2012/09/12配信 システムテスト障害№4対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/08/24  修正内容 : 2012/09/12配信 システムテスト障害№17対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/09/11  修正内容 : SCM障害№10365対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 作 成 日  2012/11/12  修正内容 : SCM障害№10415対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/08/24  修正内容 : 2012/10月配信予定 SCM障害№10340の対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 作 成 日  2012/11/21  修正内容 : SCM障害№10415仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/11/30  修正内容 : 2012/12/12配信 システムテスト障害№92対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/02/26  修正内容 : 2013/03/06配信予定 redmine34863対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : qijh
// 作 成 日  2013/04/26  修正内容 : 2013/06/18配信 No.234 Redmine#35272 売伝へ遷移前のチェックを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/04/01  修正内容 : 2013/06/18配信　SCM障害№10334対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2013/05/09  修正内容 : 2013/06/18配信 SCM障害№10525対応  PCCforNS、状況通知改良。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/06/03  修正内容 : 2013/06/18配信 SCM障害№234(#35272)マージ漏れ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2013/06/12  修正内容 : "PM "文字付加対応
//                                  ①テキストプロパティ
//                                  ②パトランプアイコンのMouseMoveイベントハンドラ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/11/21  修正内容 : 商品保証課Redmine#86対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/11/25  修正内容 : 商品保証課Redmine#86対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/11/26  修正内容 : SCM仕掛一覧№10592対応　新着データ取得時サーバー負荷障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/04/24  修正内容 : SCM仕掛一覧№10651対応　
//----------------------------------------------------------------------------//
// 管理番号  11070091-00 作成担当 : zhujw
// 作 成 日  2014/06/11  修正内容 : RedMine#42648 Windows8.1動作検証結果_常駐ポップアップ背景が白抜き表示される場合がある 修正
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 譚洪
// 作 成 日  2014/08/11  修正内容 : 障害一覧No.10651 ポップアップの「自動回答があります」の表示が消えてしまいます 修正
//----------------------------------------------------------------------------//
// 管理番号  11070184-00 作成担当 : 陳艶丹
// 作 成 日  2014/09/22  修正内容 : PM-SCM仕掛一覧No.10661とNo.85 複数端末で同時に発注できるので、過剰出荷、過剰売上のリスクの対応
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 宮本 利明
// 作 成 日  2014/10/01  修正内容 : 例外対応：例外発生時に警告メッセージ表示
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 宮本 利明
// 作 成 日  2014/10/17  修正内容 : SCM仕掛一覧№82　着信音対応
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 宮本 利明
// 作 成 日  2014/10/28  修正内容 : システムテスト障害一覧№3  返品の着信情報クリック時も消音するように修正
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 宮本 利明
// 作 成 日  2014/11/21  修正内容 : 着信音項目がconfigに無い場合に例外エラーとなる障害を修正
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 吉岡
// 作 成 日  2014/12/01  修正内容 : №10695 起動時、XML読込み処理完了前に、パトランプアイコンクリックイベント実行を抑制する
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 吉岡
// 作 成 日  2014/12/19  修正内容 : SCM高速化 ポップアップ対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30746 高川 悟
// 作 成 日  2015/06/12  修正内容 : 高速化Redmine#3848 スリープから復帰後、自動回答できない障害の対応
//----------------------------------------------------------------------------//
// 管理番号  11170130-00 作成担当 : 譚洪
// 修正日    2015/08/28  修正内容 : 修正内容：Redmine#47284 SCM仕掛一覧№10722対応
//                       ①前回受信日時を保管するファイルが破損防止対応（PMのユーザーDBにデータを登録する機能となる）
//                       ②新着表示不具合対応
// --------------------------------------------------------------------------//
// 管理番号  11170141-00 作成担当 : 30746 高川 悟
// 作 成 日  2015/09/16  修正内容 : システムテスト障害No.157対応
//                                  ウィルスバスター導入環境でサスペンド⇒復帰を繰り返すと
//                                  WebSyncの通知が正常に受信されない
//----------------------------------------------------------------------------//
// 管理番号  11175346-00 作成担当 : 陳艶丹
// 作 成 日  2015/10/09  修正内容 : RedMine#47256　先頭行しか自動回答されない場合があるの対応
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
// 管理番号  11670165-00 作成担当 : JSE菅原
// 修 正 日  2020/04/06  修正内容 : 回答速度遅延障害対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 陳艶丹
// 修 正 日  2020/07/03  修正内容 : PMKOBETSU-3926 WebSyncに間するログ追加対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 陳艶丹
// 修 正 日  2020/07/28  修正内容 : PMKOBETSU-3926 リトライ追加対応
//----------------------------------------------------------------------------//
// 管理番号  11600001-00 作成担当 : 陳艶丹
// 修 正 日  2020/10/30  修正内容 : PMKOBETSU-4088 BLP新着チェッカ（日付取得処理改善）の対応
//----------------------------------------------------------------------------//


using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
// 2010/03/02 Add >>>
using System.Collections;
using Broadleaf.Application.UIData;
using System.Threading;
// 2010/03/02 Add <<<
// 2010/03/09 Add >>>
using System.Drawing.Drawing2D;
using System.Drawing;
// 2010/03/09 Add <<<
using System.Data;// 2010/04/16 Add
using Broadleaf.Library.Windows.Forms; // 2010/08/04
// 2011/05/27 Add >>>
using Broadleaf.Application.Resources;
using System.Runtime.Serialization.Formatters.Binary;
// 2011/05/27 Add <<<
using Broadleaf.Application.UIData.Util;// Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする
using Broadleaf.Application.Remoting.ParamData; // 2011.07.12 ZHANGYH ADD
using Broadleaf.Library.Resources;	// 2012.04.11 TERASAKA DEL ADD
using Microsoft.Win32;  // 2015/06/12 ADD TAKAGAWA 高速化Redmine#3848 

#region 2012.04.11 TERASAKA DEL STA
//using System.Windows.Forms;
#endregion
namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCMポップアップUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: ポップアップ受信処理を行います。</br>
    /// <br>Programmer	: 30452 上野 俊治</br>
    /// <br>Date		: 2009/05/21</br>
    /// <br></br>
    /// <br>Note		: 更新件数の表示方法の変更</br>
    /// <br>Programmer	: 21024 佐々木 健</br>
    /// <br>Date		: 2010/03/02</br>
    /// <br></br>
    /// <br>Note		: ローカル設定対応</br>
    /// <br>Programmer	: 21024 佐々木 健</br>
    /// <br>Date		: 2010/03/03</br>
    /// <br></br>
    /// <br>Note		: IAAE対応(画面イメージの変更)</br>
    /// <br>Programmer	: 21024 佐々木 健</br>
    /// <br>Date		: 2010/03/09</br>
    /// <br></br>
    /// <br>Note		: 複数表示対応</br>
    /// <br>Programmer	: 21024 佐々木 健</br>
    /// <br>Date		: 2010/04/16</br>
    /// <br></br>
    /// <br>Note		: 一部回答、キャンセル分も表示する</br>
    /// <br>Programmer	: 21024 佐々木 健</br>
    /// <br>Date		: 2010/04/28</br>
    /// <br></br>
    /// <br>Note		: サーバーからの呼び出しによりPOPUPせず、</br>
    /// <br>         : クライアント側で一定時間間隔でPOPUP実行するよう変更。</br>
    /// <br>Programmer	: 22018 鈴木 正臣</br>
    /// <br>Date		: 2010/07/30</br>
    /// <br></br>
    /// <br>Note		: ①売上伝票入力を起動した問合せ番号は、表示中のリストから削除する。</br>
    /// <br>              ②ポップアップ画面を起動中に新着があった場合、表示中のデータに追加してデータを表示する。</br>
    /// <br>              ③タスクトレイの初期表示アイコンを緑（新着無し）に変更する。</br>
    /// <br>Programmer	: 21024 佐々木 健</br>
    /// <br>Date		: 2010/11/17</br>
    /// <br></br>
    /// <br>Note		: ①自動回答分も画面上にポップアップする</br>
    /// <br>              ②自動回答分も画面上にポップアップする設定を追加</br>
    /// <br>Programmer	: duzg</br>
    /// <br>Date		: 2011/07/18</br>
    /// <br></br>
    /// <br>Note		: Redmine#23241対応</br>
    /// <br>              ①次回起動時から有効になります」とラベル表記を追加</br>
    /// <br>              ②自動回答非表示にするように変更</br>
    /// <br>Programmer	: duzg</br>
    /// <br>Date		: 2011/07/28</br>
    /// <br>Note		: 1分と負荷問題の対応</br>
    /// <br>Programmer	: LDNS ZHANGYH</br>
    /// <br>Date		: 2011/07/12</br>
    /// <br>Programmer	: yangmj</br>
    /// <br>Date		: 2011/09/29</br>
    /// <br>Note		: redmine #25635 常駐プログラム（ポップアップ）を終了出来ないように変更の対応</br>
	/// <br>Update Note	: 2012.04.11 22024 寺坂 誉志</br>
	/// <br>			: １．高速化対応</br>
    /// <br>Update Note	: 2020/07/03 陳艶丹</br>
    /// <br>			: PMKOBETSU-3926 WebSyncに間するログ追加対応</br>
    /// <br>Update Note	: 2020/07/28 陳艶丹</br>
    /// <br>			: PMKOBETSU-3926 リトライ追加対応</br>
    /// <br>Update Note	: 2020/10/30 陳艶丹</br>
    /// <br>			: PMKOBETSU-4088 BLP新着チェッカ（日付取得処理改善）の対応</br>
    /// <br></br>
    /// </remarks>
    public partial class SCMPopupForm : Form
    {
        #region private定数
        private const string CT_Conf_PortNumber = "PortNumber"; // 通信用ポート番号
        private const string CT_Conf_CheckInterval = "CheckInterval"; // 定期Popupチェック間隔 // ADD m.suzuki 2010/07/30
        private const string CT_Conf_RcvCancelStartTime = "RcvCancelStartTime"; // クライアント受信処理停止 開始時間(時のみ) // 2010/08/04
        private const string CT_Conf_RcvCancelEndTime = "RcvCancelEndTime"; // クライアント受信処理停止 終了時間(時のみ) // 2010/08/04
        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private const string CT_Conf_AnswerMode = "AnswerMode"; //回答モード "0":通常モード "1":手動回答モード
        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        private const double ctFormOpacity = 0.92;              // 2010/03/09 Add
        private const int ctDefaultFormHeight = 108;            // 2010/04/16 Add
        // --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする --->>>
        /// <summary>自動回答の情報を表示するかどうか定数</summary>
        private const string CT_Conf_AutoAnswerView = "AutoAnswerView";
        /// <summary>「config」ファイル</summary>
        private const string Exe_Conf_Filename = "PMSCM00005U.exe.config";
        /// <summary>appSettings</summary>
        private const string App_Set_Section = "appSettings";
        /// <summary>ログ用</summary>
        private const string TAB = "\t";　　　　　　　　// ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応

        /// <summary>自動回答の情報を表示するかどうかフラグ</summary>
        private bool _visbleFlg = false;
        // --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする ---<<<
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
        private const string CT_Conf_SoundMode = "SoundMode"; //着信音モード
        private const string CT_Conf_SoundTime = "SoundTime"; //着信音秒数
        private const string CT_Conf_SoundPath = "SoundPath"; //着信音ファイル
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<

        // 2010/04/16 Add >>>
        private const string ctColumnName_Display = "Display";
        private const string ctColumnName_UpdateDate = "UpdateDate";
        private const string ctColumnName_UpdateTime = "UpdateTime";
        private const string ctColumnName_Data = "Data";
        // 2010/04/16 Add <<<
        private const string ctColumnName_CustomerInfo = "CustomerInfo";
        // 2010/11/17 Add >>>
        private const string ctColumnName_KEY = "KEY";
        // 2010/11/17 Add <<<
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
        private const string ctColumnName_DateTime = "DateTime";
        private const string ctColumnName_Elapsed = "Elapsed";
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<
        // ADD 2012/08/24 2012/09/12配信システムテスト障害№17対応 ------------------>>>>>
        private const string CT_Conf_ExeFileName = "PMSCM00005U.exe";
        // ADD 2012/08/24 2012/09/12配信システムテスト障害№17対応 ------------------<<<<< 

        #endregion

        #region private変数
        private List<string> _settingList; // ログイン情報、App.config情報設定リスト

        // 2010/03/02 Add >>>
        /// <summary>新着メッセージデータのキュー</summary>
        private Queue _availableDataQueue = new Queue();

        // 2011/02/25 Add >>>
        /// <summary>回答済みデータのキュー</summary>
        private Queue _answeredDataQueue = new Queue();
        // 2011/02/25 Add <<<

        // 2010/04/16 Del >>>
        ///// <summary>CMTの接続中確認用</summary>
        //private const string CMTConnectingGuid = "3a9629e9ec924219a5ff2ef8e875845a";
        // 2010/04/16 Del <<<
        // 2010/03/02 Add <<<

        // 2010/03/03 Add >>>
        private ScmLocalSet _scmLocalSet;
        // --- 2011/07/18 duzg for 自動回答の情報を表示するかどうかの設定画面 --->>>
        /// <summary>自動回答の情報を表示するかどうかの設定画面</summary>
        private PMSCM00005UF _form = null;

        /// <summary>前回回答済みデータのキュー</summary>
        private List<ISCMOrderHeaderRecord> _bakAnswerdList = new List<ISCMOrderHeaderRecord>();// Add 2011/07/28 duzg for Redmine#23241対応

        /// <summary> 問合せ一覧表アクセスクラス</summary>
        //private SCMInquiryOrderAcs _scmInquiryOrderAcs = null;// Del 2011/07/28 duzg for Redmine#23241対応

        /// <summary>企業コード</summary>
        //private string _enterpriseCode;// Del 2011/07/28 duzg for Redmine#23241対応
        // --- 2011/07/18 duzg for 自動回答の情報を表示するかどうかの設定画面 ---<<<

        private DateTime _getLateUpdateDate = DateTime.MinValue; // 前回の最新取得日付
        private DateTime _nowLateUpdateDate = DateTime.MinValue; // 現在の最新取得日付
        private int _getLateUpdateTime = 0; // 前回の最新取得時間
        private int _nowLateUpdateTime = 0; // 現在の最新取得時間
        // 2010/03/03 Add <<<

        // 2010/04/16 Add >>>
        private SimplInqCnectInfoAcs _simplInqCnectInfoAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private DataTable _dataTable;
        // 2010/04/16 Add <<<
        // --- ADD m.suzuki 2010/07/30 ---------->>>>>
        private NewArrNtfyController _newArrNtfyController;
        // --- ADD m.suzuki 2010/07/30 ----------<<<<<

        //>>>2010/08/04
        private SCMDtRcveExecAcs _scmDtRcveExecAcs;
        private SCMTtlSt _scmTtlSt;
        private SCMTtlStAcs _scmTtlStAcs;
        private int _rcvCancelStart;
        private int _rcvCancelEnd;
        //<<<2010/08/04

        // 2010/11/17 Add >>>
        private bool _formClose = false;
        // 2010/11/17 Add <<<

        // 2011.07.12 ZHANGYH ADD STA >>>>>>
        private SFCMN01501CA _scmPushClient;    // Pushクライアントオブジェクト
        private string _enterpriseCode;         // ログイン従業員の企業コード
        private string _sectionCode;            // ログイン従業員の拠点コード
        private bool _scmCheck;                 // ShowPopup実行判別用フラグ
        // 2011.07.12 ZHANGYH ADD END <<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
		private Thread _initProcThread;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
        // ADD 2012/07/17 システムテスト障害№96 -------------------------------->>>>>
        private bool _autoAnswerDisplay = false;   // 自動回答表示フラグ
        // ADD 2012/07/17 システムテスト障害№96 --------------------------------<<<<<

        // 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 ----------->>>>>>>>>>>>>>>>>>>>
        private ScmPushData _payload = null;        // SFからの通知内容
        private string _pushkey = null;             // SFへPushするkey
        // 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 -----------<<<<<<<<<<<<<<<<<<<<

        // 2012/11/21 ADD TAKAGAWA SCM障害改良No10415仕様変更対応 ----------->>>>>>>>>>>>>>>>>>>>
        private string _pushkeyWK = null;           // SFへPushするkey(退避用)
        // 2012/11/21 ADD TAKAGAWA SCM障害改良No10415仕様変更対応 -----------<<<<<<<<<<<<<<<<<<<<

        private string _dataKey;   // ADD 2011/10/10

        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private bool _ManualAnswerMode = false; //true:手動回答モード
        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
        private bool _soundMode = false;
        private int _soundTime = 0;
        private string _soundPath = string.Empty;

        private System.Media.SoundPlayer _SoundPlayer = null;
        private DateTime _autoStartTime = DateTime.MinValue;
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<
        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private bool _timeDeletFlg = false; //true:削除しました
        private DateTime _deletTime = DateTime.MinValue;
        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ------>>>>>
        // リトライ情報
        private RetrySet retrySettingInfo = null;
        // リトライ設定XMLファイル
        private const string xmlFileName = "WebSync_RetrySetting.xml";
        // リトライ回数-デフォルト：10回
        private const int retryCountTemp = 10;
        // リトライ間隔-デフォルト：1秒
        private const int retryIntervalTemp = 1000;
        // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ------<<<<<
        #endregion

        #region <コマンドライン引数>

        /// <summary>コマンドライン引数</summary>
        private readonly string[] _commandLineArgs;
        /// <summary>コマンドライン引数を取得します。</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        #endregion // </コマンドライン引数>

        #region <フォームを閉じる判定>

        /// <summary>フォームを閉じる判定フラグ</summary>
        private bool _canClose;
        /// <summary>フォームを閉じる判定フラグのアクセサ</summary>
        private bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion // </フォームを閉じる判定>

        #region <SCM端末>

        /// <summary>SCM端末</summary>
        private ISCMTerminal _terminal;
        /// <summary>SCM端末を取得します。</summary>
        private ISCMTerminal Terminal
        {
            get
            {
                if (_terminal == null)
                {
                    _terminal = new SCMTerminal(this._settingList);
                }
                return _terminal;
            }
        }

        #region <初期情報の取得>
        /// <summary>
        /// 初期情報取得処理
        /// </summary>
        private void GetInitialSettings()
        {
            this._settingList = new List<string>();
            // PM7連携か
            //Int32.TryParse(ConfigurationManager.AppSettings[CT_Conf_PM7Connect], out this._pm7Connect);

            if (Program.PM7Mode)
            {
                // 企業コード取得
                this._settingList.Add("0000000000000000");

                // ログイン情報より自拠点を取得
                this._settingList.Add("00");

                // ポップアップ命令送受信用のポート番号
                this._settingList.Add(ConfigurationManager.AppSettings[CT_Conf_PortNumber]);

                // PM7連携コード
                this._settingList.Add("0");
            }
            else
            {
                // 企業コード取得
                this._settingList.Add(LoginInfoAcquisition.EnterpriseCode);

                // ログイン情報より自拠点を取得
                this._settingList.Add(LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'));

                // ポップアップ命令送受信用のポート番号
                this._settingList.Add(ConfigurationManager.AppSettings[CT_Conf_PortNumber]);

                // PM7連携コード
                this._settingList.Add("1");

            }

        }

        /// <summary>
        /// 初期情報の設定内容チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckInitialSettings()
        {
            Int32 portNumber;
            if (!Int32.TryParse(ConfigurationManager.AppSettings[CT_Conf_PortNumber], out portNumber))
            {
                LogWriter.LogWrite("configファイルのポート番号の設定が正しくありません。");
                return false;
            }
            else
            {
                if (portNumber < 0 || portNumber > 65535)
                {
                    LogWriter.LogWrite("configファイルのポート番号の設定が正しくありません。");
                    return false;
                }
            }

            //Int32 pm7Connect;
            //if (!Int32.TryParse(ConfigurationManager.AppSettings[CT_Conf_PM7Connect], out pm7Connect))
            //{
            //    LogWriter.LogWrite("configファイルの環境設定が正しくありません。");
            //    return false;
            //}
            //else
            //{
            //    if (pm7Connect != 0 && pm7Connect != 1)
            //    {
            //        LogWriter.LogWrite("configファイルの環境設定が正しくありません。");
            //        return false;
            //    }
            //}

            return true;
        }
        #endregion
        #endregion // </SCM端末>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        private SCMPopupForm()
            : base()
        {
            #region <Designer Code>

            InitializeComponent();

            #endregion // </Designer Code>
            //2020/04/06 ADD -------------------------->>>>>
            if (this._getLateUpdateDate == DateTime.MinValue)
            {
                //システム日付の１ヶ月前を設定
                // UPD 2020/10/30 陳艶丹 PMKOBETSU-4088対応  --------->>>>>
                //this._getLateUpdateDate = DateTime.Now.AddMonths(-1);
                this._getLateUpdateDate = DateTime.Today.AddMonths(-1);
                // UPD 2020/10/30 陳艶丹 PMKOBETSU-4088対応  ---------<<<<<
            }
            //2020/04/06 ADD --------------------------<<<<<

            // ADD 2013/11/25 商品保証課Redmine#86対応 -------------------------------->>>>>
            this._loading = true;  
            // ADD 2013/11/25 商品保証課Redmine#86対応 --------------------------------<<<<<

            // 2011.07.12 ZHANGYH ADD STA >>>>>>
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            // 2011.07.12 ZHANGYH ADD END <<<<<<

            // 2010/04/16 Add >>>
            this._dataTable = new DataTable();
            //this._detailTable.Columns.Add(new DataColumn("BLANK", typeof(string)));
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_Display, typeof(string)));
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_UpdateDate, typeof(DateTime)));
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_UpdateTime, typeof(long)));
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_Data, typeof(object)));
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_CustomerInfo, typeof(CustomerInfo)));// 2010/12/22 Add
            // 2010/11/17 Add >>>
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_KEY, typeof(string)));
            this._dataTable.PrimaryKey = new DataColumn[] { this._dataTable.Columns[ctColumnName_KEY] };
            // 2010/11/17 Add <<<
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_DateTime, typeof(string)));
            this._dataTable.Columns.Add(new DataColumn(ctColumnName_Elapsed, typeof(string)));
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<
            this._dataTable.DefaultView.Sort = string.Format("{0} DESC,{1} DESC", ctColumnName_UpdateDate, ctColumnName_UpdateTime);
            this.dataGridView_Data.DataSource = this._dataTable.DefaultView;
            // 2010/04/12 Add <<<
            // --- ADD m.suzuki 2010/07/30 ---------->>>>>
            this._newArrNtfyController = new NewArrNtfyController();
            this._newArrNtfyController.SearchSetting(LoginInfoAcquisition.EnterpriseCode);
            // --- ADD m.suzuki 2010/07/30 ----------<<<<<

            //>>>2010/08/04
            // SCM全体設定取得
            this._scmTtlStAcs = new SCMTtlStAcs();
            this._scmTtlStAcs.Read(out this._scmTtlSt, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            if (this._scmTtlSt == null) this._scmTtlStAcs.Read(out this._scmTtlSt, LoginInfoAcquisition.EnterpriseCode, "00");
            GetXmlInfo(); // ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応
            // 受信処理停止時間取得
            try
            {
                this._rcvCancelStart = Int32.Parse(ConfigurationManager.AppSettings[CT_Conf_RcvCancelStartTime]) * 100;
                this._rcvCancelEnd = Int32.Parse(ConfigurationManager.AppSettings[CT_Conf_RcvCancelEndTime]) * 100;
            }
            catch
            {
                this._rcvCancelStart = -1;
                this._rcvCancelEnd = -1;
            }
            //<<<2010/08/04
            // 自企業コード
            //this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; // Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする// Del 2011/07/28 duzg for Redmine#23241対応
////////////////////////////////////////////// 2012.04.11 TERASAKA ADD STA //
			_initProcThread = new Thread(new ParameterizedThreadStart(InitialProc));
			_initProcThread.Start();
// 2012.04.11 TERASAKA ADD END //////////////////////////////////////////////

            // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (ConfigurationManager.AppSettings[CT_Conf_AnswerMode] != null)
            {
                if (ConfigurationManager.AppSettings[CT_Conf_AnswerMode].Equals("1"))
                {
                    this._ManualAnswerMode = true;
                }
            }
            // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._timeDeletFlg = false;
            this._deletTime = DateTime.Today;
            // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2015/06/12 ADD TAKAGAWA 高速化Redmine#3848 ---------->>>>>>>>>>
            // 電源状態変更イベントを割り当て
            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(PowerModeChanged);
            // 2015/06/12 ADD TAKAGAWA 高速化Redmine#3848 ----------<<<<<<<<<<
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="commandLineArgs">コマンドライン引数</param>
        public SCMPopupForm(string[] commandLineArgs)
            : this()
        {
            _commandLineArgs = commandLineArgs;
        }

        #endregion // </Constructor>

        #region <フォーム>

        /// <summary>デフォルトx座標</summary>
        private const int DEFAULT_X = 100000;
        /// <summary>デフォルトy座標</summary>
        private const int DEFAULT_Y = 100000;

        /// <summary>
        /// フォームのLoadイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SCMPopupForm_Load(object sender, EventArgs e)
        {
            // ADD 2013/11/21 商品保証課Redmine#86対応 -------------------------------------------->>>>>
            this.Enabled = false;
            // ADD 2013/11/21 商品保証課Redmine#86対応 --------------------------------------------<<<<<

            // 2010/04/16 Add >>>
            //this.dataGridView1.Columns["BLANK"].Width = 20;
            this.dataGridView_Data.Columns[ctColumnName_Data].Visible = false;
            this.dataGridView_Data.Columns[ctColumnName_UpdateDate].Visible = false;
            this.dataGridView_Data.Columns[ctColumnName_UpdateTime].Visible = false;
            this.dataGridView_Data.Columns[ctColumnName_KEY].Visible = false;  // 2010/11/17 Add
            this.dataGridView_Data.Columns[ctColumnName_CustomerInfo].Visible = false;  // 2010/12/22 Add
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
            // 着信経過時間非表示(Debug用)
            this.dataGridView_Data.Columns[ctColumnName_DateTime].Visible = false;
            this.dataGridView_Data.Columns[ctColumnName_Elapsed].Visible = false;
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<

            this.Height = ctDefaultFormHeight;
            this.SetNewestData();
            // 2010/04/16 Add <<<
            //>>2012/06/06
            //LogWriter.isKillLog = true;
            LogWriter.isKillLog = false;
            //<<<2012/06/06

            // 初期表示は隠し
            // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SetVisibleState(false);
            SetVisibleState(this._ManualAnswerMode);
            //// --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // 初期位置を設定（ちらつき防止の為、10000にしています）
            // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);
            if (!this._ManualAnswerMode) SetDesktopBounds(DEFAULT_X, DEFAULT_Y, Width, Height);
            // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // 2010/03/09 Add >>>
            //int diameter = 12;										// 円弧の直径
            //int radius = diameter / 2;								// 円弧の半径

            // 2010/04/16 Del >>>
            #region 削除
            //// フォームの形状をGraphicsPathで設定
            //using (GraphicsPath graphicsPath = new GraphicsPath())
            //{
            //    graphicsPath.FillMode = FillMode.Winding;

            //    // フォームの直線部を追加
            //    //graphicsPath.AddLine(radius, 0, Width - radius, 0); //上
            //    //graphicsPath.AddLine(Width, radius, Width, Height); //右
            //    //graphicsPath.AddLine(Width, Height, 0, Height);     //下
            //    //graphicsPath.AddLine(0, Height, 0, radius);         //左

            //    //// 上部の扇を追加
            //    //graphicsPath.AddPie(Width - diameter, 0, diameter, diameter, 270, 90);  // 右上
            //    //graphicsPath.AddPie(0, 0, diameter, diameter, 180, 90);    //左上

            //    // フォームの直線部を追加
            //    graphicsPath.AddLine(radius, 0, Width - radius, 0); graphicsPath.AddLine(Width, radius, Width, Height - radius); graphicsPath.AddLine(Width - radius, Height, radius, Height); graphicsPath.AddLine(0, Height - radius, 0, radius);

            //    // 四つ角の扇を追加
            //    graphicsPath.AddPie(Width - diameter - 1, 0, diameter, diameter, 270, 90); graphicsPath.AddPie(Width - diameter - 1, Height - diameter - 1, diameter, diameter, 0, 90); graphicsPath.AddPie(0, Height - diameter - 1, diameter, diameter, 90, 90); graphicsPath.AddPie(0, 0, diameter, diameter, 180, 90);


            //    // リージョンの設定
            //    Region = new Region(graphicsPath);
            //}
            //// 2010/03/09 Add <<<
            #endregion
            // 2010/04/16 Del <<<

            // App.Config情報取得
            GetInitialSettings();

            // App.Config情報チェック
            if (!this.CheckInitialSettings())
            {
                // 初期設定がエラーの場合は終了
                CanClose = true;
                Close();
                return;
            }

            // 2010/03/03 Add >>>
            ScmLocalSetAcs scmLocalSetAcs = new ScmLocalSetAcs();
            this._scmLocalSet = scmLocalSetAcs.ReadScmLocalSet();

            // DEL 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            //this._getLateUpdateDate = _scmLocalSet.LastGetDate;
            //if (this._getLateUpdateDate == null) this._getLateUpdateDate = DateTime.MinValue;
            //this._getLateUpdateTime = _scmLocalSet.LastGetTime;
            // DEL 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2010/03/03 Add <<<
            // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
            object obj = null;
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // DBから、最終取得日付と最終取得時間を取得します。
            if (this._newArrNtfyController.PosTerminalMg != null)
            {
                status = Terminal.SearchScmTimeData(this._newArrNtfyController.PosTerminalMg.CashRegisterNo, out obj);
            }

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && obj != null)
            {
                // 最終取得日付
                this._getLateUpdateDate = ((ScmTimeDataWork)obj).LastGetDate;

                //2020/04/06 UPD -------------------------->>>>>
                //if (this._getLateUpdateDate == null)
                if ((this._getLateUpdateDate == null) ||
                    (this._getLateUpdateDate == DateTime.MinValue))
                //2020/04/06 UPD --------------------------<<<<<
                {
                    //2020/04/06 UPD -------------------------->>>>>
                    //this._getLateUpdateDate = DateTime.MinValue;
                    //システム日付の１ヶ月前を設定
                    // UPD 2020/10/30 陳艶丹 PMKOBETSU-4088対応  --------->>>>>
                    //this._getLateUpdateDate = DateTime.Now.AddMonths(-1);
                    this._getLateUpdateDate = DateTime.Today.AddMonths(-1);
                    // UPD 2020/10/30 陳艶丹 PMKOBETSU-4088対応  ---------<<<<<
                    //2020/04/06 UPD --------------------------<<<<<
                }
                // 最終取得時間
                this._getLateUpdateTime = ((ScmTimeDataWork)obj).LastGetTime;
            }
            // DBから取得できない場合、XMLファイルから取得します。
            else
            {
                LogWriter.LogWrite("SCM新着データ表示管理から最終取得日付と最終取得時間を取得失敗しました。");// ADD 2020/10/30 陳艶丹 PMKOBETSU-4088

                // 最終取得日付
            this._getLateUpdateDate = _scmLocalSet.LastGetDate;

                //2020/04/06 UPD -------------------------->>>>>
                //if (this._getLateUpdateDate == null)
                if ((this._getLateUpdateDate == null) ||
                    (this._getLateUpdateDate == DateTime.MinValue))
                //2020/04/06 UPD --------------------------<<<<<
                {
                    //2020/04/06 UPD -------------------------->>>>>
                    //this._getLateUpdateDate = DateTime.MinValue;
                    //システム日付の１ヶ月前を設定
                    // UPD 2020/10/30 陳艶丹 PMKOBETSU-4088対応  --------->>>>>
                    //this._getLateUpdateDate = DateTime.Now.AddMonths(-1);
                    this._getLateUpdateDate = DateTime.Today.AddMonths(-1);
                    // UPD 2020/10/30 陳艶丹 PMKOBETSU-4088対応  ---------<<<<<
                    //2020/04/06 UPD --------------------------<<<<<
                }

                // 最終取得時間
            this._getLateUpdateTime = _scmLocalSet.LastGetTime;
            // 2010/03/03 Add <<<
             }
             // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2020/10/30 陳艶丹 PMKOBETSU-4088対応  --------->>>>>
            // 最終取得時間が「システム日時から1か月前」よりも古い場合、最終取得日時を「システム日時から1か月前」とする
             if (this._getLateUpdateDate < DateTime.Today.AddMonths(-1))
            {
                this._getLateUpdateDate = DateTime.Today.AddMonths(-1);
                // 最終取得時間
                this._getLateUpdateTime = 0;
            }
            // ADD 2020/10/30 陳艶丹 PMKOBETSU-4088対応  ---------<<<<<

            // 2010/04/16 Del >>>
            //// 新着情報を設定
            //NewOrderCount = -1;
            // 2010/04/16 Del <<<

            // メッセージ受信処理を開始
            Terminal.MessageReceiver.Received += new ReceivedEventHandler(ShowPopup);
            Terminal.StartReceiving();

            // PM.NS環境の場合、起動時に受信処理を実行
            if (Program.PM7Mode == false)
            {
                // DEL 2012/07/11 yugami システム障害№80 --------------------->>>>>
                //ShowPopup(new object(), new ReceivedEventArgs());
                // DEL 2012/07/11 yugami システム障害№80 ---------------------<<<<<
            }
            // 2010/04/16 Add >>>
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            // 2010/04/16 Add <<<

            // --- ADD m.suzuki 2010/07/30 ---------->>>>>
            check_timer.Interval = this.GetCheckInterval();
            check_timer.Enabled = true;
            // --- ADD m.suzuki 2010/07/30 ----------<<<<<

            // 2011.09.06 zhouzy UPDATE STA >>>>>>
            //// 2011.07.12 ZHANGYH ADD STA >>>>>>
            //// Pushモードの初期化
            //if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract)
            //{
            InitPushMode();
            //}
            //// 2011.07.12 ZHANGYH ADD END <<<<<<
            // 2011.09.06 zhouzy UPDATE END <<<<<<

            // --- ADD 2012/11/30 三戸 2012/12/12配信分 システムテスト障害№92 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this._newArrNtfyController.PosTerminalMg.CashRegisterNo != this._scmTtlSt.CashRegisterNo)
            {
                // 自端末が受信処理端末ではない場合、右クリックメニューに「切替」を表示しない
                this.patoLampNotifyIcon.ContextMenuStrip.Items["changeToolStripMenuItem"].Visible = false;
            }
            // --- ADD 2012/11/30 三戸 2012/12/12配信分 システムテスト障害№92 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/11/21 商品保証課Redmine#86対応 -------------------------------------------->>>>>
            this.Enabled = true;
            // ADD 2013/11/21 商品保証課Redmine#86対応 --------------------------------------------<<<<<
            // ADD 2013/11/25 商品保証課Redmine#86対応 -------------------------------->>>>>
            this._loading = false;
            // ADD 2013/11/25 商品保証課Redmine#86対応 --------------------------------<<<<<

            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
            // マウスダウンイベント制御
            AllControlMouseDownSet(this);
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<

            // ADD 2014/12/01 吉岡 №10695 ---------------->>>>>>>>>>>>>>>>>>
            // パトランプアイコン マウスクリックイベント 設定
            this.patoLampNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.patoLampNotifyIcon_MouseClick);
            // ADD 2014/12/01 吉岡 №10695 ----------------<<<<<<<<<<<<<<<<<<

            // ADD 2014/12/19 吉岡 SCM高速化 ポップアップ対応 ------------>>>>>>>>>>>>>>>>>>>>>
            // int status;   // DEL 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応
            // 受信端末の場合
            if (this._newArrNtfyController.PosTerminalMg.CashRegisterNo.Equals(this._scmTtlSt.CashRegisterNo))
            {
                #region ■ PMオプション管理マスタ
                try
                {
                    // 以下オプション情報を更新する
                    string[] optionCodeList = new string[9]{ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicOfferData       // 基本提供データオプション
                                                     , ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData      // 外装提供データオプション
                                                     , ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData       // 大型提供データオプション
                                                     , ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch             // 自由検索オプションオプションコード 
                                                     , ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BikeSearch             // 二輪提供データオプションコード 
                                                     , ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_TactiSearch            // タクティ他社結合オプション 
                                                     , ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM                    // SCM
                                                     , ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCCUOE                 // PCCUOE
                                                     , ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCMAutoAnswer          // 自動回答
                                                    };

                    PMOptMngWork pmOptMngWork;
                    ArrayList paraList = new ArrayList();

                    foreach (string optionCode in optionCodeList)
                    {
                        pmOptMngWork = new PMOptMngWork();
                        pmOptMngWork.EnterpriseCode = this._enterpriseCode;
                        pmOptMngWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                        pmOptMngWork.OptionCode = optionCode;

                        if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(optionCode) >= PurchaseStatus.Contract)
                        {
                            pmOptMngWork.OptionUseDiv = 1;  // 使用
                        }
                        else
                        {
                            pmOptMngWork.OptionUseDiv = 0;  // 未使用
                        }

                        paraList.Add(pmOptMngWork);
                    }

                    object paraObj = paraList;

                    Broadleaf.Application.Remoting.IPMOptMngDB iPMOptMngDB = (Broadleaf.Application.Remoting.IPMOptMngDB)Broadleaf.Application.Remoting.Adapter.MediationPMOptMngDB.GetPMOptMngDB();

                    status = iPMOptMngDB.Write(ref paraObj);
                    if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                    {
                        LogWriter.LogWrite("PMオプション管理マスタの更新に失敗しました");
                    }
                }
                catch (Exception ex)
                {
                    LogWriter.LogWrite("PMオプション管理マスタの更新に失敗しました");
                }

                #endregion

                #region ■ SCM企業拠点連結マスタ PMDBID
                ScmEpScCntAcs scmEpScCntAcs = new ScmEpScCntAcs();	//SCM企業拠点連結アクセスクラス
                bool msgDiv = false;
                string errMsg = string.Empty;
                try
                {
                    // リモートオブジェクト取得
                    Broadleaf.Application.Remoting.ISynchConfirmDB iSynchConfirmDB = (Broadleaf.Application.Remoting.ISynchConfirmDB)Broadleaf.Application.Remoting.Adapter.MediationSynchConfirmDB.GetSynchConfirmDB();

                    // 初期同期完了判断
                    if (iSynchConfirmDB.SyncMngDataExists())
                    {
                        // リモートオブジェクト取得
                        Broadleaf.Application.Remoting.IPmDbIdMngDB iPmDbIdMngDB = (Broadleaf.Application.Remoting.IPmDbIdMngDB)Broadleaf.Application.Remoting.Adapter.MediationPmDbIdMngDB.GetPmDbIdMngDB();

                        // キー情報の設定
                        PmDbIdMngWork pmDbIdMngWork = new PmDbIdMngWork();
                        pmDbIdMngWork.EnterpriseCode = this._enterpriseCode;

                        // PMDBID管理マスタワーカークラスをオブジェクトに設定
                        object paraObj2 = pmDbIdMngWork as object;

                        // PMDBID管理マスタ読み込み
                        status = iPmDbIdMngDB.Read(ref paraObj2, 0);

                        if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                        {
                            // 読み込み結果を設定
                            pmDbIdMngWork = (PmDbIdMngWork)paraObj2;

                            status = scmEpScCntAcs.UpdatePMDBStatus(this._enterpriseCode, this._sectionCode, pmDbIdMngWork.DbIdMngGuid, 1, out msgDiv, out errMsg);
                        }

                        if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
                        {
                            LogWriter.LogWrite("PMDBID管理マスタの更新に失敗しました");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogWriter.LogWrite("PMDBID管理マスタの更新に失敗しました  " + ex.Message);
                }

                #endregion
            }
            // ADD 2014/12/19 吉岡 SCM高速化 ポップアップ対応 ------------<<<<<<<<<<<<<<<<<<<<<
        }

        // 2011.07.12 ZHANGYH ADD STA >>>>>>
        /// <summary>
        /// Pushモードの初期化
        /// </summary>
        private void InitPushMode()
        {
            ClientArgs clientArgs = new ClientArgs();

            // PushサーバーURLの設定
            string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
            string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
            string webSyncUrl = wkStr1 + wkStr2;
            clientArgs.Url = webSyncUrl;

            // 2015/09/16 ADD TAKAGAWA システムテスト障害No.157対応 ---------->>>>>>>>>>
            try
            {
                if (_scmPushClient != null)
                {
                    _scmPushClient.Disconnect();
                }
            }
            catch
            {
            }
            // 2015/09/16 ADD TAKAGAWA システムテスト障害No.157対応 ----------<<<<<<<<<<

            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
            try
            {
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
                _scmPushClient = new SFCMN01501CA(clientArgs);

                ConnectArgs connectArgs = new ConnectArgs();
                connectArgs.StayConnected = true; // 接続が切断場合、自動的に再接続する
                connectArgs.ReconnectInterval = 5000; // 5秒　接続失敗場合、再接続間隔を指定する
                connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
                    delegate(IScmPushClient client, ConnectFailureEventArgs args)
                    {
                        // 新着チェッカーが起動する時、Pushサーバーを接続できなければ、このメソッドを呼びられる
                        // 接続した後、Pushサーバーと通信エラー場合、OnStreamFailureイベントだけを呼びられる

                        // 接続が失敗すれば、Pushサーバーへ再接続
                        args.Reconnect = true;
                        LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ WebSyncサーバーへ再接続 WebSyncUrl:" + webSyncUrl);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                    }
                );
                _scmPushClient.Connect(connectArgs);

                // SCM問い合わせ或いはテストメッセージを受け取れるために、チャンネルを予約する            
                if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract)// 2011.09.06 zhouzy ADD
                {// 2011.09.06 zhouzy ADD
                    SubscribeArgs<ScmPushData> subscribeArgs = new SubscribeArgs<ScmPushData>();
                    // 2011.09.10 zhouzy update STA >>>>>>
                    //subscribeArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM, _enterpriseCode, _sectionCode);
                    subscribeArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM, _enterpriseCode, _sectionCode.Trim());
                    // 2011.09.10 zhouzy update End <<<<<<
                    subscribeArgs.SubscribeSuccess += new PushClientEventHandler<SubscribeSuccessEventArgs>(
                        delegate(IScmPushClient client, SubscribeSuccessEventArgs args)
                        {
                            // 接続あるいは再接続が成功するとき、このメソッドを呼びられる
                            Invoke(new MethodInvoker(delegate()
                            {
                                if (args.IsResubscribe)
                                {
                                    // 新着回答チェックフラグをセットする(性能を向上するために)
                                    _scmCheck = true;
                                    LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ 新着回答データあり(通常SCM) チャンネル:" + subscribeArgs.Channel);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                                }
                            }));
                        }
                    );
                    subscribeArgs.SubscribeReceive += new PushClientEventHandler<SubscribeReceiveEventArgs<ScmPushData>>(
                        delegate(IScmPushClient client, SubscribeReceiveEventArgs<ScmPushData> args)
                        {
                            // SF.NSから問い合わせ或いはテストメッセージが受け取れたら、このメソッドを呼びられる
                            Invoke(new MethodInvoker(delegate()
                            {
                                // PushサーバーからPushデータ取得の後処理
                                ScmPushData data = args.Payload;

                                // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 --------->>>>>
                                int retryCount = 0;

                                // 他端末での回答の場合
                                if (!RetrySubscribe(data, ref retryCount))
                                {
                                    return;
                                }
                                //// --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ------->>>>>
                                //// 他端末での回答確認
                                //if (args != null && data != null && data.NoticeMode == 100)
                                //{
                                //    // 表示から消去
                                //    RemoveAnswerdRow(data.InquiryNumber);
                                //    LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ ポップアップ表示(通常SCM)から消去 問合せ番号:" + data.InquiryNumber);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                                //    return;
                                //}
                                //// --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 -------<<<<<
                               
                                //// --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                //// 通知の種類を判定
                                //switch (data.NoticeMode)
                                //{
                                //    case ScmPushDataConstMode.SENDFINISHED:         // 通常の問合せまたは発注
                                //    case ScmPushDataConstMode.CHECNK2WAITESEND:     // 起動チェック２
                                //        //string key = string.Format("{0}:{1}:{2}:", data.OrigEnterpriseCode, data.OrigSectionCode, data.InquiryNumber);
                                //        string key = string.Format("{0}:{1}:{2}:{3}:", data.OrigEnterpriseCode, data.OrigSectionCode, data.InquiryNumber, _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM);
                                //        _pushkey = key;
                                //        string keyNoticeMode = null;

                                //        if (data.NoticeMode == ScmPushDataConstMode.SENDFINISHED)
                                //        {
                                //            keyNoticeMode = ((int)ScmPushDataConstMode.CHECNK1WAITESEND).ToString();
                                //        }
                                //        else
                                //        {
                                //            keyNoticeMode = ((int)ScmPushDataConstMode.CHECNK2WAITESEND).ToString();
                                //        }
                                //        LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ WebSync通知 開始 通知のキー:" + _pushkey + "通知処理モード:" + keyNoticeMode);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                                //        NotifyOtherSidePCCUOEStatus(_pushkey, keyNoticeMode);
                                //        LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ WebSync通知 終了");// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                                //        break;
                                //    default:    // それ以外は何もしない
                                //        break;
                                //}
                                //// --- ADD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 -----<<<<<<
                                if (data.OrigEnterpriseCode != null && data.OrigSectionCode != null)
                                {
                                    #region 2012.04.11 TERASAKA DEL STA
                                    //                                // 関連のSF.NS端末へ返答します
                                    //                                NotifySfByPublish(data.OrigEnterpriseCode, data.OrigSectionCode, true);
                                    #endregion

                                    // 新着回答チェックフラグをセットする(性能を向上するために)
                                    // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                    //_scmCheck = true;
                                    if (data.NoticeMode == ScmPushDataConstMode.SENDFINISHED)
                                    {
                                        _scmCheck = true;
                                        _payload = data;
                                    }
                                    // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                }
                            }));
                        }
                     );
                    _scmPushClient.Subscribe<ScmPushData>(subscribeArgs);
                } // 2011.09.06 zhouzy ADD


                // 2011.09.06 zhouzy ADD STA >>>>>>
                // メッセージを受け取れるために、チャンネルを予約する
                if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCCUOE) >= PurchaseStatus.Contract)
                {
                    // PCCUOE用チャネル登録
                    SubscribeArgs<ScmPushData> subscribePCCUOE = new SubscribeArgs<ScmPushData>();
                    // 2011.09.10 zhouzy update STA >>>>>>
                    //subscribePCCUOE.Channel = string.Format("/{0}/PMNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE, _enterpriseCode, _sectionCode);
                    subscribePCCUOE.Channel = string.Format("/{0}/PMNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE, _enterpriseCode, _sectionCode.Trim());
                    // 2011.09.10 zhouzy update End <<<<<<
                    subscribePCCUOE.SubscribeSuccess += new PushClientEventHandler<SubscribeSuccessEventArgs>(
                        delegate(IScmPushClient client, SubscribeSuccessEventArgs args)
                        {
                            // 接続あるいは再接続が成功するとき、このメソッドを呼びられる
                            Invoke(new MethodInvoker(delegate()
                            {
                                // 新着回答チェックフラグをセットする(性能を向上するために)
                                _scmCheck = true;
                                LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ 新着回答データあり(BLP) チャンネル:" + subscribePCCUOE.Channel);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            }));
                        }
                    );
                    subscribePCCUOE.SubscribeReceive += new PushClientEventHandler<SubscribeReceiveEventArgs<ScmPushData>>(
                        delegate(IScmPushClient client, SubscribeReceiveEventArgs<ScmPushData> args)
                        {
                            // SF.NSから問い合わせ或いはテストメッセージが受け取れたら、このメソッドを呼びられる
                            Invoke(new MethodInvoker(delegate()
                            {
                                // PushサーバーからPushデータ取得の後処理
                                ScmPushData data = args.Payload;
                               
                                // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ------->>>>>
                                // 他端末での回答確認
                                if (args != null && data != null && data.NoticeMode == 100)
                                {
                                    // 表示から消去
                                    RemoveAnswerdRow(data.InquiryNumber);
                                    LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ ポップアップ表示(BLP)から消去 問合せ番号:" + data.InquiryNumber);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                                    return;
                                }
                                // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 -------<<<<<
                                // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ----->>>>>
                                int retryCount = 0;
                                RetrySubscribe(data, ref retryCount);
                                //// 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 ----------->>>>>>>>>>>>>>>>>>>>
                                //// 通知の種類を判定
                                //switch (data.NoticeMode)
                                //{
                                //    case ScmPushDataConstMode.SENDFINISHED:         // 通常の在庫確認または発注
                                //    case ScmPushDataConstMode.CHECNK2WAITESEND:     // 起動チェック２
                                //        // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                //        //string key = string.Format("{0}:{1}:{2}:", data.OrigEnterpriseCode, data.OrigSectionCode, data.InquiryNumber);
                                //        string key = string.Format("{0}:{1}:{2}:{3}:", data.OrigEnterpriseCode, data.OrigSectionCode, data.InquiryNumber, _scmPushClient.WEBSYNC_CHANNEL_PCCUOE);
                                //        // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                //        _pushkey = key;
                                //        string keyNoticeMode = null;

                                //        if (data.NoticeMode == ScmPushDataConstMode.SENDFINISHED)
                                //        {
                                //            keyNoticeMode = ((int)ScmPushDataConstMode.CHECNK1WAITESEND).ToString();
                                //        }
                                //        else
                                //        {
                                //            keyNoticeMode = ((int)ScmPushDataConstMode.CHECNK2WAITESEND).ToString();
                                //        }
                                //        LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ WebSync通知 開始 通知のキー:" + key + "通知処理モード:" + keyNoticeMode);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                                //        NotifyOtherSidePCCUOEStatus(_pushkey, keyNoticeMode);
                                //        LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ WebSync通知 終了");// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                                //        break;
                                //    default:    // それ以外は何もしない
                                //        break;
                                //}
                                //// 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 -----------<<<<<<<<<<<<<<<<<<<<
                                // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 -----<<<<<<
                                if (data.OrigEnterpriseCode != null && data.OrigSectionCode != null)
                                {
                                    #region 2012.04.11 TERASAKA DEL STA
                                    //                                // 関連のSF.NS端末へ返答します
                                    //                                NotifySfByPublishPCCUOE(data.OrigEnterpriseCode, data.OrigSectionCode, true);
                                    #endregion

                                    // 新着回答チェックフラグをセットする(性能を向上するために)
                                    // 2012/11/12 UPD TAKAGAWA SCM障害改良No10415対応 ----------->>>>>>>>>>>>>>>>>>>>
                                    //_scmCheck = true;
                                    if (data.NoticeMode == ScmPushDataConstMode.SENDFINISHED)
                                    {
                                        _scmCheck = true;
                                        _payload = data;
                                    }
                                    // 2012/11/12 UPD TAKAGAWA SCM障害改良No10415対応 -----------<<<<<<<<<<<<<<<<<<<<
                                }
                            }));
                        }
                     );
                    _scmPushClient.Subscribe<ScmPushData>(subscribePCCUOE);
                }
                // 2011.09.06 zhouzy ADD END <<<<<<
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ 処理失敗しました。" +"\r\n" + "例外内容：" + ex.ToString());
                throw ex;
            }
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<


            ScmCheck_timer.Enabled = true;
            ScmCheck_timer.Interval = 1000; // 1秒
        }

        // 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 ----------->>>>>>>>>>>>>>>>>>>>
        private void WaitTimeResetTimer(object state)
        {
            // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
            //if (_pushkey != null) NotifyOtherSidePCCUOEStatus(_pushkey, ScmPushDataConstMode.WAITETIMERESET.ToString());
            if (_pushkey != null)
            {
                // 送信結果
                bool resultCode = false;
                // エラーメッセージ
                string errMsg = string.Empty;
                // リトライ回数より送信処理を行う
                for (int i = 1; i <= retrySettingInfo.RetryCount; i++)
                {
                    // 指定のSF.NS端末への返答送信処理
                    resultCode = NotifyOtherSidePCCUOEWait(_pushkey, out errMsg);

                    // 送信成功場合
                    if (resultCode)
                    {
                        break;
                    }
                    // 送信失敗場合
                    else
                    {
                        LogWriter.LogWrite("SCMPopupForm.WaitTimeResetTimer ⇒ WebSync送信処理に失敗しました。" + "\r\n" + "例外内容：" + errMsg + "\r\n" + "リトライ回数：" + i.ToString());
                    }
                }
            }
            // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
        }

        // 以下PMSCM01010U(自動回答処理)の処理を流用
        // 2012/11/21 UPD TAKAGAWA SCM障害改良No10415仕様変更対応 ----------->>>>>>>>>>>>>>>>>>>>
        //private void NotifyOtherSidePCCUOEStatus(string _pushkey, string keyNoticeMode)
        private void NotifyOtherSidePCCUOEStatus(string pushSCMKey, string keyNoticeMode)
        // 2012/11/21 UPD TAKAGAWA SCM障害改良No10415仕様変更対応 -----------<<<<<<<<<<<<<<<<<<<<
        {
            // 2012/11/21 ADD TAKAGAWA SCM障害改良No10415仕様変更対応 ----------->>>>>>>>>>>>>>>>>>>>
            if (pushSCMKey == null) return;
            // 2012/11/21 ADD TAKAGAWA SCM障害改良No10415仕様変更対応 -----------<<<<<<<<<<<<<<<<<<<<

            // オプション制御
            bool canNotify = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract;
            if (!canNotify) return;
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
            try
            {
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
                if (_scmPushClient == null)
                {
                    ClientArgs clientArgs = new ClientArgs();

                    // PushサーバーURLの設定
                    string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP);
                    string wkStr2 = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_WEBSYNCAP, ConstantManagement_SF_PRO.IndexCode_WebSync_WebPath);
                    string webSyncUrl = wkStr1 + wkStr2;
                    clientArgs.Url = webSyncUrl;

                    _scmPushClient = new SFCMN01501CA(clientArgs);

                    ConnectArgs connectArgs = new ConnectArgs();
                    connectArgs.StayConnected = true; // 接続が切断場合、自動的に再接続する
                    connectArgs.ReconnectInterval = 5000; // 5秒　接続失敗場合、再接続間隔を指定する

                    connectArgs.ConnectFailure += new PushClientEventHandler<ConnectFailureEventArgs>(
                        delegate(IScmPushClient client, ConnectFailureEventArgs args)
                        {
                            // 新着チェッカーが起動する時、Pushサーバーを接続できなければ、このメソッドを呼びられる
                            // 接続した後、Pushサーバーと通信エラー場合、OnStreamFailureイベントだけを呼びられる

                            // 接続が失敗すれば、Pushサーバーへ再接続
                            args.Reconnect = true;
                            LogWriter.LogWrite("SCMPopupForm.NotifyOtherSidePCCUOEStatus ⇒ WebSyncサーバーへ再接続 WebSyncUrl:" + webSyncUrl);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                        }
                    );
                    _scmPushClient.Connect(connectArgs);
                }

                // 2012/11/21 UPD TAKAGAWA SCM障害改良No10415仕様変更対応 ----------->>>>>>>>>>>>>>>>>>>>
                //string keyall = _pushkey + keyNoticeMode;
                string keyall = pushSCMKey + keyNoticeMode;
                // 2012/11/21 UPD TAKAGAWA SCM障害改良No10415仕様変更対応 -----------<<<<<<<<<<<<<<<<<<<<

                string[] para = keyall.Split(':');

                string inqOriginalEpCd = para[0].Trim();//@@@@20230303
                string inqOriginalSecCd = para[1];
                long inquiryNumber;
                long.TryParse(para[2], out inquiryNumber);
                // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //int noticeMode;
                //int.TryParse(para[3], out noticeMode);
                string pushClient = para[3];
                int noticeMode;
                int.TryParse(para[4], out noticeMode);
                // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                ScmPushData payload = new ScmPushData();
                payload.OrigEnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                payload.OrigSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
                payload.InquiryNumber = inquiryNumber;
                payload.NoticeMode = noticeMode;
                payload.IsReply = true;

                PublishArgs publishArgs = new PublishArgs();
                publishArgs.Payload = payload;
                // 指定のSF.NS端末への返答送信処理
                // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE, inqOriginalEpCd, inqOriginalSecCd.Trim());
                publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", pushClient, inqOriginalEpCd.Trim(), inqOriginalSecCd.Trim());//@@@@20230303
                // --- UPD 2013/05/09 三戸 2013/06/18配信分 SCM障害№10525 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                LogWriter.LogWrite("SCMPopupForm.NotifyOtherSidePCCUOEStatus ⇒ WebSync送信処理 返答送信のパラメータ：" + keyall);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                _scmPushClient.Publish(publishArgs);
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("SCMPopupForm.NotifyOtherSidePCCUOEStatus ⇒ WebSync送信処理に失敗しました。" +"\r\n" + "例外内容：" + ex.ToString());
                throw ex;
            }
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
        }
        // 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 -----------<<<<<<<<<<<<<<<<<<<<

        // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 --------->>>>>
        /// <summary>
        /// XML情報取得
        /// </summary>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2020/07/28</br>
        /// </remarks>
        private void GetXmlInfo()
        {
            try
            {
                retrySettingInfo = new RetrySet();

                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName)))
                {
                    // XMLからリトライ回数とリトライ間隔を取得する
                    retrySettingInfo = UserSettingController.DeserializeUserSetting<RetrySet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, xmlFileName));
                }
                else
                {
                    // リトライ回数-デフォルト：10回
                    retrySettingInfo.RetryCount = retryCountTemp;
                    // リトライ間隔-デフォルト：1秒
                    retrySettingInfo.RetryInterval = retryIntervalTemp;
                }
            }
            catch
            {
                if (retrySettingInfo == null) retrySettingInfo = new RetrySet();
                // リトライ回数-デフォルト：10回
                retrySettingInfo.RetryCount = retryCountTemp;
                // リトライ間隔-デフォルト：1秒
                retrySettingInfo.RetryInterval = retryIntervalTemp;
            }
        }

        /// <summary>
        /// 指定のSF.NS端末への返答送信処理（待機延長通知）
        /// </summary>
        /// <param name="pushSCMKey">キー</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note         : 指定のSF.NS端末への返答送信処理を行う</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2020/07/28</br>
        /// </remarks>
        private bool NotifyOtherSidePCCUOEWait(string pushSCMKey, out string errMsg)
        {
            // 送信結果
            bool resultCode = true;
            // エラーメッセージ
            errMsg = string.Empty;

            try
            {
                NotifyOtherSidePCCUOEStatus(pushSCMKey, ScmPushDataConstMode.WAITETIMERESET.ToString());
            }
            catch (Exception ex)
            {
                resultCode = false;
                errMsg = ex.ToString();
            }
            return resultCode;
        }

        /// <summary>
        /// 返答送信処理(チェック待機発信)
        /// </summary>
        /// <param name="data">Pushからデータ</param>
        /// <param name="retryCount">リトライ回数</param>
        /// <returns>true:他端末での回答なし、false:他端末での回答</returns>
        /// <remarks>
        /// <br>Note         : 返答送信処理(チェック待機発信)リトライ処理を行う</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2020/07/28</br>
        /// </remarks>
        private bool RetrySubscribe(ScmPushData data, ref int retryCount)
        {
            retryCount++;
            string key = string.Empty;

            try
            {
                // 他端末での回答確認
                if (data != null && data.NoticeMode == 100)
                {
                    // 表示から消去
                    RemoveAnswerdRow(data.InquiryNumber);
                    LogWriter.LogWrite("SCMPopupForm.InitPushMode ⇒ ポップアップ表示(通常SCM)から消去 問合せ番号:" + data.InquiryNumber);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                    return false;
                }

                // 通知の種類を判定
                switch (data.NoticeMode)
                {
                    case ScmPushDataConstMode.SENDFINISHED:         // 通常の在庫確認または発注
                    case ScmPushDataConstMode.CHECNK2WAITESEND:     // 起動チェック２
                        if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCCUOE) >= PurchaseStatus.Contract)
                        {
                            key = string.Format("{0}:{1}:{2}:{3}:", data.OrigEnterpriseCode, data.OrigSectionCode, data.InquiryNumber, _scmPushClient.WEBSYNC_CHANNEL_PCCUOE);
                        }
                        else if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract)
                        {
                            key = string.Format("{0}:{1}:{2}:{3}:", data.OrigEnterpriseCode, data.OrigSectionCode, data.InquiryNumber, _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM);
                        }
                        _pushkey = key;
                        string keyNoticeMode = null;

                        if (data.NoticeMode == ScmPushDataConstMode.SENDFINISHED)
                        {
                            keyNoticeMode = ((int)ScmPushDataConstMode.CHECNK1WAITESEND).ToString();
                        }
                        else
                        {
                            keyNoticeMode = ((int)ScmPushDataConstMode.CHECNK2WAITESEND).ToString();
                        }
                        LogWriter.LogWrite("SCMPopupForm.RetrySubscribe ⇒ WebSync通知 開始 通知のキー:" + key + "通知処理モード:" + keyNoticeMode);
                        NotifyOtherSidePCCUOEStatus(_pushkey, keyNoticeMode);
                        LogWriter.LogWrite("SCMPopupForm.RetrySubscribe ⇒ WebSync通知 終了");
                        break;
                    default:    // それ以外は何もしない
                        break;
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("SCMPopupForm.RetrySubscribe ⇒ 例外内容：" + ex.ToString() + "  リトライ回数：" + retryCount.ToString());

                if (retryCount >= retrySettingInfo.RetryCount)
                {
                    throw ex;
                }
                else
                {
                    Thread.Sleep(retrySettingInfo.RetryInterval);
                    RetrySubscribe(data, ref retryCount);
                }
            }
            return true;
        }

        /// <summary>
        /// 返答送信処理(自動回答なし)
        /// </summary>
        /// <param name="newdataList">全てデータ</param>
        /// <param name="answerdDataList">回答データリスト</param>
        /// <param name="pushkeyWK">キー</param>
        /// <param name="retryCount">リトライ回数</param>
        /// <remarks>
        /// <br>Note         : 返答送信処理(自動回答なし)リトライ処理を行う</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2020/07/28</br>
        /// </remarks>
        private void RetryNoAuto(List<ISCMOrderHeaderRecord> newdataList, List<ISCMOrderHeaderRecord> answerdDataList, string pushkeyWK, ref int retryCount)
        {
            retryCount++;
            try
            {
                bool AutoAnswerExistFlag = false;   // 自動回答データ存在チェックフラグ

                // 一部自動回答分チェック
                foreach (ISCMOrderHeaderRecord _ISCMOrderHeaderRecord in newdataList)
                {
                    if (_ISCMOrderHeaderRecord.AnswerCreateDiv == 0) AutoAnswerExistFlag = true;    // 自動回答ならtrue
                }

                // 全部自動回答分チェック
                foreach (ISCMOrderHeaderRecord _ISCMOrderHeaderRecord in answerdDataList)
                {
                    if (_ISCMOrderHeaderRecord.AnswerCreateDiv == 0) AutoAnswerExistFlag = true;
                }
                // 自動回答されたデータが1件もない場合は手動回答の通知をする
                if (AutoAnswerExistFlag == false)
		{
                    LogWriter.LogWrite("SCMPopupForm.RetryNoAuto ⇒ WebSync手動回答の通知 開始 通知パラメータ:" + pushkeyWK + " 通知処理モード:" + ScmPushDataConstMode.NOAUTOANSWER.ToString());
　　　　　　　　    NotifyOtherSidePCCUOEStatus(pushkeyWK, ScmPushDataConstMode.NOAUTOANSWER.ToString());
                    LogWriter.LogWrite("SCMPopupForm.RetryNoAuto ⇒ WebSync手動回答の通知 終了");
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("SCMPopupForm.RetryNoAuto ⇒ 例外内容：" + ex.ToString() + "  リトライ回数：" + retryCount.ToString());

                if (retryCount >= retrySettingInfo.RetryCount)
                {
                    throw ex;
                }
                else
                {
                    Thread.Sleep(retrySettingInfo.RetryInterval);
                    RetryNoAuto(newdataList, answerdDataList, pushkeyWK, ref retryCount);
                }
            }
        }

        /// <summary>
        /// 返答送信処理(自動回答なし)リトライ処理しない
        /// </summary>
        /// <param name="newdataList">全てデータ</param>
        /// <param name="answerdDataList">回答データリスト</param>
        /// <param name="pushkeyWK">キー</param>
        /// <param name="retryCount">リトライ回数</param>
        /// <remarks>
        /// <br>Note         : 返答送信処理(自動回答なし)リトライ処理しない</br>
        /// <br>Programmer   : 陳艶丹</br>
        /// <br>Date         : 2020/07/28</br>
        /// </remarks>
        private void NoRetryNoAuto(List<ISCMOrderHeaderRecord> newdataList, List<ISCMOrderHeaderRecord> answerdDataList, string pushkeyWK)
        {
            try
            {
                bool AutoAnswerExistFlag = false;   // 自動回答データ存在チェックフラグ

                // 一部自動回答分チェック
                foreach (ISCMOrderHeaderRecord _ISCMOrderHeaderRecord in newdataList)
                {
                    if (_ISCMOrderHeaderRecord.AnswerCreateDiv == 0) AutoAnswerExistFlag = true;    // 自動回答ならtrue
                }

                // 全部自動回答分チェック
                foreach (ISCMOrderHeaderRecord _ISCMOrderHeaderRecord in answerdDataList)
                {
                    if (_ISCMOrderHeaderRecord.AnswerCreateDiv == 0) AutoAnswerExistFlag = true;
                }
                // 自動回答されたデータが1件もない場合は手動回答の通知をする
                if (AutoAnswerExistFlag == false)
                {
                    LogWriter.LogWrite("SCMPopupForm.NoRetryNoAuto ⇒ WebSync手動回答の通知 開始 通知パラメータ:" + pushkeyWK + " 通知処理モード:" + ScmPushDataConstMode.NOAUTOANSWER.ToString());
                    NotifyOtherSidePCCUOEStatus(pushkeyWK, ScmPushDataConstMode.NOAUTOANSWER.ToString());
                    LogWriter.LogWrite("SCMPopupForm.NoRetryNoAuto ⇒ WebSync手動回答の通知 終了");
                }
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite("SCMPopupForm.NoRetryNoAuto ⇒ 例外内容：" + ex.ToString());
            }
        }
        // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------<<<<<

        /// <summary>
        /// 指定或いは関連のSF.NS端末への返答送信処理
        /// </summary>
        /// <param name="destEnterpriseCode">企業コード</param>
        /// <param name="destSectionCode">拠点コード</param>
        /// <param name="inquiryNumber">問い合わせ番号</param>
        private void NotifySfByPublish(string destEnterpriseCode, string destSectionCode, bool reply)
        {
            ScmPushData payload = new ScmPushData();
            payload.IsReply = reply;
            payload.OrigEnterpriseCode = _enterpriseCode;
            payload.OrigSectionCode = _sectionCode;

            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // 指定のSF.NS端末への返答送信処理
            // 2011.09.10 zhouzy update STA >>>>>>
            //publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM, destEnterpriseCode, destSectionCode);
            publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM, destEnterpriseCode, destSectionCode.Trim());
            // 2011.09.10 zhouzy update End <<<<<<
            _scmPushClient.Publish(publishArgs);
        }

        /// <summary>
        /// 指定或いは関連のSF.NS端末への返答送信処理
        /// </summary>
        /// <param name="destEnterpriseCode">企業コード</param>
        /// <param name="destSectionCode">拠点コード</param>
        /// <param name="inquiryNumber">問い合わせ番号</param>
        private void NotifySfByPublishPCCUOE(string destEnterpriseCode, string destSectionCode, bool reply)
        {
            ScmPushData payload = new ScmPushData();
            payload.IsReply = reply;
            payload.OrigEnterpriseCode = _enterpriseCode;
            payload.OrigSectionCode = _sectionCode;

            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // 指定のSF.NS端末への返答送信処理
            // 2011.09.10 zhouzy update STA >>>>>>
            //publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE, destEnterpriseCode, destSectionCode);
            publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE, destEnterpriseCode, destSectionCode.Trim());
            // 2011.09.10 zhouzy update End <<<<<<
            _scmPushClient.Publish(publishArgs);
        }

        //-----ADD by huanghx for PCC-UOEメールメッセージ送信 on 2011.08.19 ----->>>>>
        /// <summary>
        /// 指定或いは関連のSF.NS端末への返答送信処理( PCC-UOEメールメッセージ送信)
        /// </summary>
        /// <param name="destEnterpriseCode">問合先企業コード</param>
        /// <param name="destSectionCode">問合先拠点コード</param>
        /// <param name="inqOtherEpCd">問合先企業コード</param>
        /// <param name="inqOtherSecCd">問合先拠点コード</param>
        /// <param name="updateDate">更新年月日</param>
        /// <param name="updateTime">更新時分秒ミリ秒</param>
        /// <param name="pccMailTitle">PCCメール件名</param>
        /// <param name="pccMailDocCnts">PCCメール本文</param>
        private void NotifySfByPublishPCCUOEMessage(string destEnterpriseCode, string destSectionCode, string inqOtherEpCd, string inqOtherSecCd, string updateDate, string updateTime, string pccMailTitle, string pccMailDocCnts)
        {
            ScmPushDataScmPccMailDt payload = new ScmPushDataScmPccMailDt();
            payload.InqOriginalEpCd = destEnterpriseCode.Trim();//@@@@20230303
            payload.InqOriginalSecCd = destSectionCode;
            payload.InqOtherEpCd = inqOtherEpCd;
            payload.InqOtherSecCd = inqOtherSecCd;
            payload.UpdateDate = int.Parse(updateDate);
            payload.UpdateTime = int.Parse(updateTime);
            payload.PccMailTitle = pccMailTitle;
            payload.PccMailDocCnts = pccMailDocCnts;
            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // 指定のSF.NS端末への返答送信処理
            // 2011.09.10 zhouzy update STA >>>>>>
            //publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE_MSG, destEnterpriseCode, destSectionCode);
            publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE_MSG, destEnterpriseCode, destSectionCode.Trim());
            // 2011.09.10 zhouzy update End <<<<<<
            _scmPushClient.Publish(publishArgs);
        }
        //-----ADD by huanghx for PCC-UOEメールメッセージ送信  on 2011.08.19 -----<<<<<

        // 2011.08.11 zhouzy ADD STA >>>>>>
        //zhouzy update 2011.09.13 begin
        ///// <summary>
        ///// 指定或いは関連のSF.NS端末への返答送信処理(リモート伝票発行)
        ///// </summary>
        ///// <param name="destEnterpriseCode">問合先企業コード</param>
        ///// <param name="destSectionCode">問合先拠点コード</param>
        ///// <param name="inqOtherEpCd">問合先企業コード</param>
        ///// <param name="inqOtherSecCd">問合先拠点コード</param>
        ///// <param name="inquiryNumber">問合番号</param>
        //private void NotifySfByPublishPCCUOERslip(string destEnterpriseCode, string destSectionCode, string inqOtherEpCd, string inqOtherSecCd, string inquiryNumber)
        /// <summary>
        /// 指定或いは関連のSF.NS端末への返答送信処理(リモート伝票発行)
        /// </summary>
        /// <param name="destEnterpriseCode">問合先企業コード</param>
        /// <param name="destSectionCode">問合先拠点コード</param>
        /// <param name="inqOtherEpCd">問合先企業コード</param>
        /// <param name="inqOtherSecCd">問合先拠点コード</param>
        /// <param name="updateDate">更新年月日</param>
        /// <param name="updateTime">更新時分秒ミリ秒</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        private void NotifySfByPublishPCCUOERslip(string destEnterpriseCode, string destSectionCode, string inqOtherEpCd, string inqOtherSecCd,
            string updateDate, string updateTime, string slipPrtKind, string salesSlipNum)
        //zhouzy update 2011.09.13 end
    
        {
            ScmPushDataScmRtPrtDt payload = new ScmPushDataScmRtPrtDt();
            payload.InqOriginalEpCd = destEnterpriseCode.Trim();//@@@@20230303
            payload.InqOriginalSecCd = destSectionCode;
            payload.InqOtherEpCd = inqOtherEpCd;
            payload.InqOtherSecCd = inqOtherSecCd;
            //zhouzy update 2011.09.13 begin
            //payload.InquiryNumber = int.Parse(inquiryNumber);
            payload.UpdateDate = int.Parse(updateDate);
            payload.UpdateTime = int.Parse(updateTime);
            payload.SlipPrtKind = int.Parse(slipPrtKind);
            payload.SalesSlipNum = salesSlipNum;
            //zhouzy update 2011.09.13 end

            PublishArgs publishArgs = new PublishArgs();
            publishArgs.Payload = payload;
            // 指定のSF.NS端末への返答送信処理
            // 2011.09.10 zhouzy update STA >>>>>>
            //publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE_RSLIP, destEnterpriseCode, destSectionCode);
            publishArgs.Channel = string.Format("/{0}/SFNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE_RSLIP, destEnterpriseCode, destSectionCode.Trim());
            // 2011.09.10 zhouzy update End <<<<<<
            _scmPushClient.Publish(publishArgs);

        }
        // 2011.08.11 zhouzy ADD END <<<<<<

        /// <summary>
        /// 定期チェック実行タイマー処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void ScmCheck_timer_Tick(object sender, EventArgs e)
        {
            if (_scmCheck)
            {
                // --- ADD 2014/10/01 T.Miyamoto ------------------------------>>>>>
                if (Broadleaf.Windows.Forms.Program.ExceptionFlg)
                {
                    ScmCheck_timer.Enabled = false;
                    return;
                }
                // --- ADD 2014/10/01 T.Miyamoto ------------------------------<<<<<
                // ADD 2012/06/26 №71  -------------------------------------------------->>>>>
                // 自動回答分もポップアップ表示する
                AppSettingsSection appSettingSection = GetAppSettingsSection();

                if (appSettingSection.Settings[CT_Conf_AutoAnswerView].Value.Equals("1"))
                    this._visbleFlg = true;
                else
                    this._visbleFlg = false;
                // ADD 2012/06/26 №71  --------------------------------------------------<<<<<
                // 新着回答チェックを実行する
                ShowPopup(new object(), new ReceivedEventArgs());
                // フラグをリセットする
                _scmCheck = false;
            }
        }
        // 2011.07.12 ZHANGYH ADD END <<<<<<

        // --- ADD m.suzuki 2010/07/30 ---------->>>>>
        /// <summary>
        /// チェック間隔取得
        /// </summary>
        /// <returns></returns>
        private int GetCheckInterval()
        {
            // デフォルトは5分とする
            const int ct_defaultInterval = 5;


            // 時間間隔[分単位]
            int interval;

            // 2011/05/27 Add >>>
            // SCMデモ用設定ファイル読込（intervalは秒単位）
            int status = GetSCMDemoSettings(out interval);
            if (status == 0)
            {
                // 秒→ミリ秒に変換して返却
                return (interval * 1000);
            }
            // 2011/05/27 Add <<<

            try
            {
                //>>>2010/08/04
                //// configファイルから取得
                //interval = Int32.Parse(ConfigurationManager.AppSettings[CT_Conf_CheckInterval]);
                interval = this._scmTtlSt.RcvProcStInterval;
                //<<<2010/08/04
            }
            catch
            {
                interval = 0;
            }

            // 未設定時はデフォルト値をセットする
            if (interval <= 0)
            {
                interval = ct_defaultInterval;
            }

            // 分→ミリ秒単位に変換して返却
            return (interval * 60 * 1000);
        }
        // --- ADD m.suzuki 2010/07/30 ----------<<<<<

        // 2010/03/02 Add >>>
        /// <summary>
        /// Ipcサーバ有効チェック
        /// </summary>
        /// <returns>true:有効 false:無効</returns>
        private bool CheckCMT()
        {
            // 2010/04/16 >>>
            //using (Mutex _ipcMutex = new Mutex(false, CMTConnectingGuid))
            //{
            //    // 所有権が取得出来る場合サーバは無効と判断する
            //    if (_ipcMutex.WaitOne(0, false))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}

            if (this._simplInqCnectInfoAcs == null)
            {
                this._simplInqCnectInfoAcs = new SimplInqCnectInfoAcs();
            }
            List<SimplInqCnectInfo> list;
            int status = this._simplInqCnectInfoAcs.SearchOwnCnectInfoList(LoginInfoAcquisition.EnterpriseCode, out list);
            if (status == 0)
            {
                return (list != null && list.Count > 0);
            }
            return false;
            // 2010/04/16 <<<
        }
        // 2010/03/02 Add <<<

        /// <summary>
        /// 表示状態を設定します。
        /// </summary>
        /// <param name="visible">表示フラグ</param>
        private void SetVisibleState(bool visible)
        {
            if (visible)
            {
                SetInitialPosition();
                // UPD 2013/04/01 SCM障害№10334対応 --------------------------------->>>>>
                //Visible = true;
                //TopMost = true;
                //Activate();
                //TopMost = false;
                SetWindowPos(true);
                Visible = true;
                // UPD 2013/04/01 SCM障害№10334対応 ---------------------------------<<<<<

                this.Refresh();// ADD BY zhujw 2014/06/11 RedMine#42648 Windows8.1動作検証結果_常駐ポップアップ背景が白抜き表示される場合がある 修正
            }
            else
            {
                Visible = false;
            }
        }

        /// <summary>
        /// 初期起動位置を設定します。
        /// </summary>
        private void SetInitialPosition()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenheigth = Screen.PrimaryScreen.WorkingArea.Height;
            int appWidth = Width;
            int appHeight = Height;
            int appLeftXPos = screenWidth - appWidth;
            int appLeftYPos = screenheigth - appHeight;

            SetDesktopBounds(appLeftXPos, appLeftYPos, appWidth, appHeight);
        }

        // ADD 2013/04/01 SCM障害№10334対応 --------------------------------->>>>>
        /// <summary>
        /// ShowWithoutActivation
        /// </summary>
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        /// <summary>
        /// SetWindowPos
        /// </summary>
        /// <param name="isTopMost">表示フラグ</param>
        private void SetWindowPos(bool isTopMost)
        {
            const int HWND_NOTOPMOST = -2;
            const int HWND_TOPMOST = -1;
            const int SWP_NOSIZE = 0x0001;
            const int SWP_NOMOVE = 0x0002;
            const int SWP_NOACTIVATE = 0x0010;
            const int SWP_DRAWFRAME = 0x0020;
            const int SWP_SHOWWINDOW = 0x0040;

            if (isTopMost)
                SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_DRAWFRAME);
            else
            {
                if (Visible)
                    SetWindowPos(this.Handle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW | SWP_DRAWFRAME);
            }
        }
        // ADD 2013/04/01 SCM障害№10334対応 ---------------------------------<<<<<

        /// <summary>
        /// フォームのFormClosingイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void SCMPopupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanClose)
            {
                if (e.CloseReason.Equals(CloseReason.UserClosing))
                {
                    // 意図的な終了以外はキャンセルしてアイコン化（フォームを非表示にする）
                    e.Cancel = true; // 終了処理のキャンセル
                    _formClose = true;  // 2010/11/17 Add
                    // 2010/03/02 >>>
                    //Visible = false;
                    this.close_Timer.Enabled = true;
                    //this.display_timer.Enabled = true;
                    // 2010/03/02 <<<
                    // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
                    SoundStop(); //消音
                    // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<
                    return;
                }
            }
            // メッセージ受信処理を終了
            Terminal.Dispose();

            // 2015/06/12 ADD TAKAGAWA 高速化Redmine#3848 ---------->>>>>>>>>>
            // 電源状態変更イベントを解放
            SystemEvents.PowerModeChanged -= new PowerModeChangedEventHandler(PowerModeChanged);
            // 2015/06/12 ADD TAKAGAWA 高速化Redmine#3848 ----------<<<<<<<<<<
        }

        #endregion // </フォーム>

        #region <メニュー>

        /// <summary>
        /// [表示]メニューアイテムのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetVisibleState(true);
        }

        /// <summary>
        /// [終了]メニューアイテムのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //>>>2010/08/04

            if ((this._newArrNtfyController.PosTerminalMg != null) &&                                       // 端末情報が取得できない場合、処理しない
                (this._scmTtlSt != null) &&                                                                 // SCM全体設定が取得できない場合、処理しない
                (this._newArrNtfyController.PosTerminalMg.CashRegisterNo == this._scmTtlSt.CashRegisterNo)) // 受信端末設定が自端末以外の場合、処理しない
            {
                DialogResult dResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    this.Name,
                    "受信待機処理も終了します。\r\n" +
                    "終了してもよろしいですか？",
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dResult == DialogResult.No) return;
            }
            //<<<2010/08/04

            CanClose = true;
            Close();
        }

        #endregion // </メニュー>

        #region <パトランプ>

        /// <summary>パトランプの点灯フラグ</summary>
        private bool _lightsPatLamp;
        /// <summary>パトランプの点灯フラグのアクセサ</summary>
        private bool LightsPatLamp
        {
            get { return _lightsPatLamp; }
            set
            {
                _lightsPatLamp = value;
                if (_lightsPatLamp)
                {
                    this.patoLampImage.Image = Broadleaf.Windows.Forms.Properties.Resources.PatLampRed;
                    this.patoLampNotifyIcon.Icon = Broadleaf.Windows.Forms.Properties.Resources.PatLampRedIcon;
                }
                else
                {
                    this.patoLampImage.Image = Broadleaf.Windows.Forms.Properties.Resources.PatLampGreen;
                    this.patoLampNotifyIcon.Icon = Broadleaf.Windows.Forms.Properties.Resources.PatLampGreenIcon;
                }
            }
        }

        /// <summary>
        /// パトランプアイコンのMouseMoveイベントハンドラ
        /// </summary>
        /// <remarks>新着情報を表示します。</remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void patoLampNotifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            // --- UPD 2013/06/12 Y.Wakita ---------->>>>>
            //this.patoLampNotifyIcon.Text = this.lblInformation.Text;
            this.patoLampNotifyIcon.Text = "PM " + this.lblInformation.Text;
            // --- UPD 2013/06/12 Y.Wakita ----------<<<<<
        }

        /// <summary>
        /// パトランプアイコンのMouseClickイベントハンドラ
        /// </summary>
        /// <remarks>ポップアップ画面を表示します。</remarks>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void patoLampNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            #region <Guard Phrase>

            if (!e.Button.Equals(MouseButtons.Left)) return;

            #endregion // </Guard Phrase>

            // 2010/04/28 >>>
            //// 2010/04/16 >>>
            //this.ShowPopup(null, new ReceivedEventArgs());
            //// 2010/04/16 <<<

            // UPD 2013/11/25 商品保証課Redmine#86対応 -------------------------------->>>>>
            //if (!_loading) this.ShowPopup(null, new ReceivedEventArgs());
            //// 2010/04/28 <<<

            //SetVisibleState(true);
            // ロード中はポップアップ画面表示しない
            if (!_loading)
            {
                this.ShowPopup(null, new ReceivedEventArgs());
                SetVisibleState(true);
            }
            // UPD 2013/11/25 商品保証課Redmine#86対応 --------------------------------<<<<<
        }

        #endregion // </パトランプ>

        #region <新着情報>
        /// <summary>新着情報があります(PM7連携時のポップアップメッセージ)</summary>
        private const string MSG_PM7CONNECT_NEW_ORDER = "新着情報があります";
        /// <summary>新着情報はありません</summary>
        private const string MSG_NO_NEW_ORDER = "新着情報はありません";     // LITERAL:
        /// <summary>新着情報が {0} 件あります</summary>
        private const string MSG_NEW_ORDER = "新着情報が {0} 件あります";   // LITERAL:
        // 2010/03/02 Add >>>
        private const string CONST_AFTERMSG = "{0}番の{1}があります";
        // 2010/03/02 Add <<<

        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private const string MSG_MANUAL_MODE = "手動回答モードです";     // LITERAL:
        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // UPD 2012/07/19 システムテスト障害No.113 ------------------------------->>>>>
        // ADD 2012/06/26 №71  -------------------------------------------->>>>>
        //private const string MSG_AUTO_ANSWER = "自動回答があります";
        // ADD 2012/06/26 №71  --------------------------------------------<<<<<
        private const string MSG_AUTO_ANSWER = "新着情報があります";
        // UPD 2012/07/19 システムテスト障害No.113 -------------------------------<<<<<

        // 2010/04/28 Add >>>
        private bool _loading = false;
        // 2010/04/28 Add <<<

        // 2010/04/16 Del >>>
        #region 削除
        ///// <summary>0:PM7環境 1:PM.NS環境</summary>
        ////private int _pm7Connect;
        ///// <summary>新着件数</summary>
        //private int _newOrderCount;
        ///// <summary>新着件数のアクセサ</summary>
        //private int NewOrderCount
        //{
        //    get { return _newOrderCount; }
        //    set
        //    {
        //        _newOrderCount = value;

        //        if (Program.PM7Mode)
        //        {
        //            if (_newOrderCount >= 0)
        //            {
        //                this.lblInformation.Text = MSG_PM7CONNECT_NEW_ORDER;
        //            }
        //            else
        //            {
        //                // 初期起動時用
        //                this.lblInformation.Text = MSG_NO_NEW_ORDER;
        //            }

        //            LightsPatLamp = (_newOrderCount >= 0);
        //        }
        //        else
        //        {
        //            if (_newOrderCount > 0)
        //            {
        //                this.lblInformation.Text = string.Format(MSG_NEW_ORDER, _newOrderCount);
        //            }
        //            else
        //            {
        //                this.lblInformation.Text = MSG_NO_NEW_ORDER;
        //            }

        //            LightsPatLamp = (_newOrderCount > 0);
        //        }
        //    }
        //}
        #endregion
        // 2010/04/16 Del <<<

        // 2010/03/02 >>>
        /// <summary>
        /// 最新データの表示
        /// </summary>
        /// <returns></returns>
        private bool SetNewestData()
        {
            // 2010/11/17 Del >>>
            //// 2010/04/16 Add >>>
            //this._dataTable.Rows.Clear();
            //// 2010/04/16 Add <<<
            // 2010/11/17 Del <<<
            bool ret = false;
            // 2010/04/28 Add >>>
            _loading = true;
            try
            {
                // 2010/04/28 Add <<<
                // 2010/11/17 Add >>>
                // UPD 2012/07/17 システムテスト障害№96 --------------------------------->>>>>
                //if (_formClose) this._dataTable.Rows.Clear();
                if (_formClose)
                {
                    this._dataTable.Rows.Clear();
                    this._autoAnswerDisplay = false;
                }
                // UPD 2012/07/17 システムテスト障害№96 --------------------------------->>>>>
                _formClose = false;
                // 先にデータをテーブルにセットする
                if (_availableDataQueue.Count > 0)
                {
                    while (_availableDataQueue.Count > 0)
                    {
                        ISCMOrderHeaderRecord scmodrdata = (ISCMOrderHeaderRecord)_availableDataQueue.Dequeue();
                        // ADD 2013/02/26 三戸 2013/03/06配信予定 redmine34863 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        if (scmodrdata.CancelDiv == (short)CancelDiv.ExistsCancel && scmodrdata.InqOrdDivCd == (int)InqOrdDivCd.Inquiry) continue;
                        // ADD 2013/02/26 三戸 2013/03/06配信予定 redmine34863 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        this.AddDataRow(scmodrdata);
                    }
                }
                // 2010/11/17 Add <<<

                // 2011/02/25 Add >>>
                if (_answeredDataQueue.Count > 0)
                {
                    List<ISCMOrderHeaderRecord> answerdDataList = new List<ISCMOrderHeaderRecord>();
                    while (_answeredDataQueue.Count > 0)
                    {
                        // UPD 2012/07/26 2012/08/07配信システムテスト障害№125 --------------------->>>>>
                        //answerdDataList.Add((ISCMOrderHeaderRecord)_answeredDataQueue.Dequeue());
                        // ADD 2012/07/17 システムテスト障害№96 -------------------------------->>>>>>
                        //this._autoAnswerDisplay = true;
                        // ADD 2012/07/17 システムテスト障害№96 --------------------------------<<<<<<
                        ISCMOrderHeaderRecord scmodrdata = (ISCMOrderHeaderRecord)_answeredDataQueue.Dequeue();
                        answerdDataList.Add(scmodrdata);
                        if (scmodrdata.AnswerCreateDiv == (int)AnswerCreateDivValue.Auto)
                        {
                            this._autoAnswerDisplay = true;
                        }
                        // UPD 2012/07/26 2012/08/07配信システムテスト障害№125 ---------------------<<<<<
                    }
                    this.RemoveAnswerdRow(answerdDataList);
                }
                // 2011/02/25 Add <<<

                // 2010/11/17 >>>
                //if (_availableDataQueue.Count > 0)
                if (this._dataTable.Rows.Count > 0)
                // 2010/11/17 <<<
                {
                    // 2010/04/16 >>>
                    //ScmOdrData scmodrdata = (ScmOdrData)_availableDataQueue.Dequeue();
                    //if (scmodrdata != null)
                    //{
                    //    // 2010/03/03 >>>
                    //    //this.lblInformation.Text = scmodrdata.InquiryNumber.ToString() + CONST_AFTERMSG;
                    //    this.lbl_CorpName.Text = GetCustomerName(scmodrdata.InqOriginalEpCd);

                    //    this.lblInformation.Text = string.Format(CONST_AFTERMSG, scmodrdata.InquiryNumber, ( scmodrdata.InqOrdDivCd == 1 ) ? "問合せ" : "発注");
                    //    // 2010/03/03 <<<

                    //    panel_Data.Controls.Add(this.CreateDisplayPanel(scmodrdata));   // 2010/04/16 Add

                    //    this.lblInformation.Tag = scmodrdata;
                    //}

                    // 2010/11/17 >>>
                    //switch (_availableDataQueue.Count)
                    switch (this._dataTable.Rows.Count)
                    // 2010/11/17 <<<
                    {
                        case 0:
                            // UPD 2012/07/17 システムテスト障害№96 ------------------------------>>>>>
                            //this.Height = ctDefaultFormHeight;
                            if (this._visbleFlg && this._autoAnswerDisplay) this.Height = ctDefaultFormHeight + this.bottom_Panel.Height;
                            else this.Height = ctDefaultFormHeight;
                            // UPD 2012/07/17 システムテスト障害№96 ------------------------------<<<<<
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            // 2010/12/22 >>>
                            //// 2010/11/17 >>>
                            ////this.Height = ctDefaultFormHeight + ( this.dataGridView_Data.RowTemplate.Height * _availableDataQueue.Count );
                            //this.Height = ctDefaultFormHeight + ( this.dataGridView_Data.RowTemplate.Height * this._dataTable.Rows.Count );
                            //// 2010/11/17 <<<

                            // UPD 2012/07/17 システムテスト障害№96 ------------------------------>>>>>
                            //if ((this.Height < (ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * this._dataTable.Rows.Count))) ||
                            //    !this.Visible)
                            //{
                            //    this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * this._dataTable.Rows.Count);
                            //}
                            if (this._visbleFlg && this._autoAnswerDisplay)
                            {
                                if ((this.Height < (ctDefaultFormHeight + this.bottom_Panel.Height + (this.dataGridView_Data.RowTemplate.Height * this._dataTable.Rows.Count))) ||
                                    !this.Visible)
                                {
                                    this.Height = ctDefaultFormHeight + this.bottom_Panel.Height + (this.dataGridView_Data.RowTemplate.Height * this._dataTable.Rows.Count);
                                }
                            }
                            else
                            {
                                if ((this.Height < (ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * this._dataTable.Rows.Count))) ||
                                    !this.Visible)
                                {
                                    this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * this._dataTable.Rows.Count);
                                }
                            }
                            // UPD 2012/07/17 システムテスト障害№96 ------------------------------<<<<<
                            // 2010/12/22 <<<
                            break;
                        default:
                            // UPD 2012/07/17 システムテスト障害№96 ------------------------------>>>>>
                            // 2010/12/22 >>>
                            //this.Height = ctDefaultFormHeight + ( this.dataGridView_Data.RowTemplate.Height * 5 );
                            //if ((this.Height < (ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * 5))) ||
                            //    !this.Visible)
                            //{
                            //    this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * 5);
                            //}
                            // 2010/12/22 <<<
                            if (this._visbleFlg && this._autoAnswerDisplay)
                            {
                                if ((this.Height < (ctDefaultFormHeight + this.bottom_Panel.Height + (this.dataGridView_Data.RowTemplate.Height * 5))) ||
                                    !this.Visible)
                                {
                                    this.Height = ctDefaultFormHeight + this.bottom_Panel.Height + (this.dataGridView_Data.RowTemplate.Height * 5);
                                }
                            }
                            else
                            {
                                if ((this.Height < (ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * 5))) ||
                                    !this.Visible)
                                {
                                    this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * 5);
                                }
                            }
                            // UPD 2012/07/17 システムテスト障害№96 ------------------------------<<<<
                            break;
                    }
                    // ADD 2012/06/26 №71  ----------------------------------------------->>>>>
                    this.dataGridView_Data.Height = this.Height - ctDefaultFormHeight;
                    this.bottom_Panel.Visible = false;
                    // ADD 2012/06/26 №71  -----------------------------------------------<<<<<
                    // UPD 2012/07/19 システムテスト障害No.113 -------------------------->>>>> 
                    // UPD 2012/07/17 システムテスト障害№96 ---------------------->>>>> 
                    // 2010/11/17 >>>
                    //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, _availableDataQueue.Count);
                    //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                    // 2010/11/17 <<<
                    //if (this._visbleFlg && this._autoAnswerDisplay)
                    //{
                    //    this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count + 1);
                    //}
                    //else
                    //{
                    //    this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                    //}
                    // UPD 2012/07/17 システムテスト障害№96 ----------------------<<<<< 

                    // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                    if (this._ManualAnswerMode)
                    {
                        this.lblInformation.Text = MSG_MANUAL_MODE;
                    }
                    else
                    {
                        this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                    }
                    // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                    // UPD 2012/07/19 システムテスト障害No.113 -------------------------->>>>> 

                    // 2010/11/17 Del >>>
                    //while (_availableDataQueue.Count > 0)
                    //{
                    //    ISCMOrderHeaderRecord scmodrdata = (ISCMOrderHeaderRecord)_availableDataQueue.Dequeue();

                    //    DataRow dr = this._dataTable.NewRow();

                    //    dr[ctColumnName_Display] = this.CreateDisplayString(scmodrdata);
                    //    dr[ctColumnName_Data] = scmodrdata;
                    //    dr[ctColumnName_UpdateDate] = scmodrdata.UpdateDate;
                    //    dr[ctColumnName_UpdateTime] = scmodrdata.UpdateTime;
                    //    this._dataTable.Rows.Add(dr);
                    //}
                    // 2010/11/17 Del <<<
                    // 2010/12/22 >>>
                    //if (this._dataTable.Rows.Count > 0)
                    if (this._dataTable.Rows.Count > 0 && !this.Visible)
                    // 2010/12/22 <<<
                    {
                        this.dataGridView_Data.CurrentCell = this.dataGridView_Data[ctColumnName_Display, 0];
                    }
                    // 2010/04/28 Add >>>
                    if (this.dataGridView_Data.Rows.Count > 0)
                    {
                        this.dataGridView_Data.SuspendLayout();

                        try
                        {
                            Font font = new Font(this.dataGridView_Data.RowsDefaultCellStyle.Font.Name, this.dataGridView_Data.RowsDefaultCellStyle.Font.Size, FontStyle.Bold);
                            foreach (DataGridViewRow row in this.dataGridView_Data.Rows)
                            {
                                // DEL 2010/06/17 キャンセル分の判断方式を変更 ---------->>>>>
                                //if (( (ISCMOrderHeaderRecord)row.Cells[ctColumnName_Data].Value ).AnswerDivCd == 99)
                                // DEL 2010/06/17 キャンセル分の判断方式を変更 ----------<<<<<
                                // ADD 2010/06/17 キャンセル分の判断方式を変更 ---------->>>>>
                                // 「キャンセル区分」…0:キャンセルなし/1:キャンセルあり
                                if (((ISCMOrderHeaderRecord)row.Cells[ctColumnName_Data].Value).CancelDiv == 1)
                                // ADD 2010/06/17 キャンセル分の判断方式を変更 ----------<<<<<
                                {
                                    row.Cells[ctColumnName_Display].Style.ForeColor = Color.Red;
                                    row.Cells[ctColumnName_Display].Style.SelectionForeColor = Color.Red;
                                    // 2010/12/22 >>>
                                    //row.Cells[ctColumnName_Display].Style.Font = font;
                                    // 2010/12/22 <<<
                                }
                                else
                                {
                                    row.Cells[ctColumnName_Display].Style.ForeColor = Color.Blue;
                                    row.Cells[ctColumnName_Display].Style.SelectionForeColor = Color.Blue;
                                }
                            }
                        }
                        finally
                        {
                            this.dataGridView_Data.ResumeLayout();
                        }
                    }
                    // 2010/04/28 Add <<<
                    ret = true;
                    LightsPatLamp = true;

                }
                else
                {
                    // 2010/04/16 Del >>>
                    //// 2010/03/03 Add >>>
                    //this.lbl_CorpName.Text = string.Empty;
                    //// 2010/03/03 Add <<<
                    // 2010/04/16 Del <<<
                    // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //this.lblInformation.Text = MSG_NO_NEW_ORDER;
                    if (this._ManualAnswerMode)
                    {
                        this.lblInformation.Text = MSG_MANUAL_MODE;
                    }
                    else
                    {
                        this.lblInformation.Text = MSG_NO_NEW_ORDER;
                    }
                    // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    //LightsPatLamp = false;// Del 2011/07/28 duzg for Redmine#23241
                    // --- Add 2011/07/28 duzg for Redmine#23241 --->>>
                    if (this._visbleFlg && bottom_Panel.Visible)
                    {
                        LightsPatLamp = true;
                    }
                    else
                    {
                        LightsPatLamp = false;
                    }
                    // --- Add 2011/07/28 duzg for Redmine#23241 ---<<<
                    // UPD 2012/07/17 システムテスト障害№96 ------------------------------>>>>>
                    //this.Height = ctDefaultFormHeight;  // 2010/04/16 Add
                    if (this._visbleFlg && this._autoAnswerDisplay) this.Height = ctDefaultFormHeight + this.bottom_Panel.Height;
                    else this.Height = ctDefaultFormHeight;
                    // UPD 2012/07/17 システムテスト障害№96 ------------------------------<<<<<
                }
                // 2010/04/28 Add >>>
                // ADD 2012/07/17 システムテスト障害№96 ------------------------------>>>>>
                // 自動回答通知を表示する
                if (this._visbleFlg && this._autoAnswerDisplay)
                {
                    this.bottom_Panel.Visible = true;
                    this.autoAnswerLabel.Visible = true;
                }
                // ADD 2012/07/17 システムテスト障害№96 ------------------------------<<<<<

                // --- ADD 2014/08/11 譚洪 ----------- >>>
                // 自動回答の場合、かつ、bottom_PanelがFalseの場合、
                if (!this._ManualAnswerMode && !this.bottom_Panel.Visible)
                {
                    if (this._dataTable.Rows.Count <= 4)
                    {
                        this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * this._dataTable.Rows.Count);
                    }
                    else
                    {
                        this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * 5);
                    }

                }
                // --- ADD 2014/08/11 譚洪 ----------- <<<
            }
            finally
            {
                _loading = false;
            }
            // 2010/04/28 Add <<<


            return ret;
        }

        // 2010/03/02 <<<

        #endregion // </新着情報>

        #region <ポップアップ>

        /// <summary>
        /// 受信スレッド用ポップアップ表示処理コールバック
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private delegate void ShowPopupCallback(object sender, ReceivedEventArgs e);

        /// <summary>
        /// ポップアップを表示します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        void ShowPopup(
            object sender,
            ReceivedEventArgs e
        )
        {
            if (InvokeRequired)
            {
                // 受信スレッドからのイベント処理
                Invoke(new ShowPopupCallback(ShowPopup), new object[] { sender, e });
            }
            else
            {
                // 2011.07.12 ZHANGYH ADD STA >>>>>>
                // 回答送信があれば、このメソッドを呼びられる                
                if (e.Text != null && e.Text.Length > 0)
                {
                    if (e.Text.StartsWith("SCM/"))
                    {
						#region 2012.04.11 TERASAKA DEL STA
//                        // SCM連携場合
//                        if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract)
//                        {
//                            string msg = e.Text.Substring(4);
//                            // Push送信用の企業コードと拠点コードを取得して、SF.NS端末を通知します
//                            string[] temp = msg.Split('|');
//                            for (int i = 0; i < temp.Length; i++)
//                            {
//                                string[] paras = ((string)temp[i]).Split(',');
//                                string targetEnterpriseCode = paras[0];
//                                string targetSectionCode = paras[1];
//
//                                NotifySfByPublish(targetEnterpriseCode, targetSectionCode, false);
//                            }
//                        }
						#endregion
                    }
                    // 2011.09.06 zhouzy ADD STA >>>>>>
                    else if (e.Text.StartsWith("PCCUOE/"))
                    {
						#region 2012.04.11 TERASAKA DEL STA
//                        // SCM連携場合
//                        if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract)
//                        {
//                            string msg = e.Text.Substring(7);
//                            // Push送信用の企業コードと拠点コードを取得して、SF.NS端末を通知します
//                            string[] temp = msg.Split('|');
//                            for (int i = 0; i < temp.Length; i++)
//                            {
//                                string[] paras = ((string)temp[i]).Split(',');
//                                string targetEnterpriseCode = paras[0];
//                                string targetSectionCode = paras[1];
//
//                                NotifySfByPublishPCCUOE(targetEnterpriseCode, targetSectionCode, false);
//                            }
//                        }                        
						#endregion
                    }
                    // 2011.09.06 zhouzy ADD END <<<<<<
                    else if (e.Text.StartsWith("PCCUOE_RSLIP/"))
                    {
                        // 2011.08.11 zhouzy ADD STA >>>>>>
                        // SCM連携場合 PCCUOE OPTION
                        if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RemoteSlipPrt) >= PurchaseStatus.Contract)
                        {
                            string msg = e.Text.Substring(13);
                            // Push送信用の企業コードと拠点コードを取得して、SF.NS端末を通知します
                            string[] temp = msg.Split('|');
                            for (int i = 0; i < temp.Length; i++)
                            {
                                //zhouzy update 2011.09.13 begin
                                //string[] paras = ((string)temp[i]).Split(',');
                                //string targetEnterpriseCode = paras[0];
                                //string targetSectionCode = paras[1];
                                //string inqOtherEpCd = paras[2];
                                //string inqOtherSecCd = paras[3];
                                //string inquiryNumber = paras[4];
                                //NotifySfByPublishPCCUOERslip(targetEnterpriseCode, targetSectionCode,
                                //    inqOtherEpCd, inqOtherSecCd, inquiryNumber);
                                string[] paras = ((string)temp[i]).Split(',');
                                string targetEnterpriseCode = paras[0];
                                string targetSectionCode = paras[1];
                                string inqOtherEpCd = paras[2];
                                string inqOtherSecCd = paras[3];
                                string updateDate = paras[4];
                                string updateTime = paras[5];
                                string slipPrtKind = paras[6];
                                string salesSlipNum = paras[7];
                                NotifySfByPublishPCCUOERslip(targetEnterpriseCode, targetSectionCode,
                                    inqOtherEpCd, inqOtherSecCd, updateDate, updateTime, slipPrtKind, salesSlipNum);
                                //zhouzy update 2011.09.13 end

                            }
                        }
                    }
                    // 2011.08.11 zhouzy ADD END <<<<<<
                    //-----ADD by huanghx for PCC-UOEメールメッセージ送信 on 2011.08.19 ----->>>>>
                    else if (e.Text.StartsWith("PCCUOE_MESSAGE/"))
                    {
                        string msg = e.Text.Substring(15);
                        // Push送信用の企業コードと拠点コードを取得して、SF.NS端末を通知します
                        string[] temp = msg.Split('|');
                        for (int i = 0; i < temp.Length; i++)
                        {
                            string[] paras = ((string)temp[i]).Split(',');
                            string targetEnterpriseCode = paras[0];
                            string targetSectionCode = paras[1];
                            string inqOtherEpCd = paras[2];
                            string inqOtherSecCd = paras[3];
                            string updateDate = paras[4];
                            string updateTime = paras[5];
                            string pccMailTitle = paras[6];
                            string pccMailDocCnts = paras[7];
                            NotifySfByPublishPCCUOEMessage(targetEnterpriseCode, targetSectionCode,
                                inqOtherEpCd, inqOtherSecCd, updateDate, updateTime, pccMailTitle, pccMailDocCnts);
                        }
                    }
                    //-----ADD by huanghx for PCC-UOEメールメッセージ送信 on 2011.08.19 -----<<<<<
                    return;
                }
                // 2011.07.12 ZHANGYH ADD END <<<<<<

                try
                {
                    //>>>2010/08/04
                    int nowHour = DateTime.Now.Hour;
                    int nowMinute = DateTime.Now.Minute;
                    int now = nowHour * 100 + nowMinute;
                    if (((this._rcvCancelStart != -1) && (this._rcvCancelEnd != -1) &&
                         (now > this._rcvCancelStart) && (this._rcvCancelEnd <= now)) ||
                        ((this._rcvCancelStart == -1) || (this._rcvCancelEnd == -1)))                                   // 受信処理停止時間内は処理しない
                    {
                        if ((this._newArrNtfyController.PosTerminalMg != null) &&                                       // 端末情報が取得できない場合、処理しない
                            (this._scmTtlSt != null) &&                                                                 // SCM全体設定が取得できない場合、処理しない
                            (this._newArrNtfyController.PosTerminalMg.CashRegisterNo == this._scmTtlSt.CashRegisterNo)) // 受信端末設定が自端末以外の場合、処理しない
                        {
							#region 2012.04.11 TERASAKA DEL STA
//                            // 受信処理起動
//                            if (this._scmDtRcveExecAcs == null) this._scmDtRcveExecAcs = new SCMDtRcveExecAcs();
//                            this._scmDtRcveExecAcs.GetStartParameterEvent += new SCMDtRcveExecAcs.GetStartParameterEventHandler(this.GetStartParameter);
//                            string msg;
//                            int status = this._scmDtRcveExecAcs.DataReceive(true, out msg);
							#endregion
////////////////////////////////////////////// 2012.04.11 TERASAKA ADD STA //
							// 初期処理スレッドが終了するまで待つ
							_initProcThread.Join();

                            // 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 ----------->>>>>>>>>>>>>>>>>>>>
                            LogWriter.LogWrite("SCMPopupForm.ShowPopup ⇒ 待機延長通知");// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                            TimerCallback timercallback = new TimerCallback(WaitTimeResetTimer);
                            System.Threading.Timer timer = new System.Threading.Timer(timercallback, null, 0, 60000);
                            // 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 -----------<<<<<<<<<<<<<<<<<<<<

							using (IRunable scmWebServerChecker = new SCMCheckerForm())
							{
								scmWebServerChecker.Run();
							}

                            // 2012/11/21 ADD TAKAGAWA SCM障害改良No10415仕様変更対応 ----------->>>>>>>>>>>>>>>>>>>>
                            _pushkeyWK = _pushkey;
                            // 2012/11/21 ADD TAKAGAWA SCM障害改良No10415仕様変更対応 -----------<<<<<<<<<<<<<<<<<<<<
                            // 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 ----------->>>>>>>>>>>>>>>>>>>>
                            _pushkey = null;
                            timer.Dispose();
                            // 2012/11/12 ADD TAKAGAWA SCM障害改良No10415対応 -----------<<<<<<<<<<<<<<<<<<<<

// 2012.04.11 TERASAKA ADD END //////////////////////////////////////////////
                        }
                    }
                    //<<<2010/08/04

                    // 2010/04/16 Add >>>
                    _nowLateUpdateDate = _getLateUpdateDate;
                    _nowLateUpdateTime = _getLateUpdateTime;
                    // 2010/04/16 Add <<<

                    // 新着件数の取得
                    if (Program.PM7Mode)
                    {
                        // 2010/04/16 >>>
                        //// PM7
                        //NewOrderCount = 0;
                        // 2010/04/16 <<<
                        SetVisibleState(true);

                    }
                    else
                    {
                        // 2010/04/16 SCMTerminalから取得するデータが変わるので変更 >>>

                        #region 削除

                        //// 2010/03/02 >>>
                        ////// PM.NS
                        ////NewOrderCount = Terminal.GetNewOrderCount();
                        ////if (NewOrderCount > 0)
                        ////{
                        ////    SetVisibleState(true);
                        ////}
                        //object obj = Terminal.GetNewOrderList();
                        //if (obj != null && obj is List<ScmOdrData> && ( (List<ScmOdrData>)obj ).Count > 0)
                        //{
                        //    // 2010/03/03 Add >>>
                        //    DateTime lateUpdateDate = _getLateUpdateDate;
                        //    int lateUpdateTime = _getLateUpdateTime;
                        //    // 2010/03/03 Add <<<
                        //    foreach (ScmOdrData work in ( (List<ScmOdrData>)obj ))
                        //    {
                        //        // 2010/03/03 >>>
                        //        //_availableDataQueue.Enqueue(work);
                        //        // PMの新着チェッカーは、そもそも当日分しか取らないけど...
                        //        if (_getLateUpdateDate == DateTime.MinValue || _getLateUpdateDate < work.UpdateDate)
                        //        {
                        //            _availableDataQueue.Enqueue(work);
                        //        }
                        //        else if (_getLateUpdateDate == work.UpdateDate)
                        //        {
                        //            if (_getLateUpdateTime < work.UpdateTime)
                        //            {
                        //                _availableDataQueue.Enqueue(work);
                        //            }
                        //            // 2010/03/08 Add >>>
                        //            else
                        //            {
                        //                continue;
                        //            }
                        //            // 2010/03/08 Add <<<
                        //        }

                        //        // 今回取得の最終データを退避
                        //        if (lateUpdateDate < work.UpdateDate)
                        //        {
                        //            lateUpdateDate = work.UpdateDate;
                        //            lateUpdateTime = work.UpdateTime;
                        //        }
                        //        else if (lateUpdateDate == work.UpdateDate)
                        //        {
                        //            if (lateUpdateTime < work.UpdateTime)
                        //            {
                        //                lateUpdateTime = work.UpdateTime;
                        //            }
                        //        }
                        //        // 2010/03/03 <<<
                        //    }
                        //    // 2010/03/03 >>>
                        //    _scmLocalSet.LastGetDate = lateUpdateDate;
                        //    _scmLocalSet.LastGetTime = lateUpdateTime;
                        //    ScmLocalSetAcs scmLocalSetAcs = new ScmLocalSetAcs();
                        //    scmLocalSetAcs.ScmLocal = _scmLocalSet;
                        //    scmLocalSetAcs.WriteScmLocalSet();
                        //    _nowLateUpdateDate = lateUpdateDate;
                        //    _nowLateUpdateTime = lateUpdateTime;
                        //    // 2010/03/03 <<<

                        //    //if (!CheckCMT())                                      // 2010/03/03 Del
                        //    if (_availableDataQueue.Count > 0 && ( !CheckCMT() ))   // 2010/03/03 Add
                        //    {
                        //        this.SetNewestData();

                        //        SetVisibleState(true);
                        //    }
                        //}
                        //// 2010/03/02 <<<

                        #endregion

                        // UPD 2013/11/26 SCM仕掛一覧№10592対応 ------------------------------------>>>>>
                        //object obj = Terminal.GetNewOrderList(_getLateUpdateDate, _getLateUpdateTime);
                        object obj = null;
                        // 設定マッチングチェック（引数はTerminalクラスのコンストラクタ時の引数と同じものを使用する）
                        if (this._newArrNtfyController.Match(this._settingList[0], this._settingList[1]))
                        {
                            obj = Terminal.GetNewOrderList(_getLateUpdateDate, _getLateUpdateTime);
                        }
                        // UPD 2013/11/26 SCM仕掛一覧№10592対応 ------------------------------------<<<<<

                        // 2011/02/25 >>>
                        //if (obj != null && obj is List<ISCMOrderHeaderRecord> && ( (List<ISCMOrderHeaderRecord>)obj ).Count > 0)
                        if (obj != null && obj is ArrayList)
                        // 2011/02/25 <<<
                        {
                            // 2011/02/25 Add >>>
                            ArrayList retList = (ArrayList)obj;
                            List<ISCMOrderHeaderRecord> newdataList = (retList.Count > 0 && retList[0] is List<ISCMOrderHeaderRecord>) ? (List<ISCMOrderHeaderRecord>)retList[0] : null;
                            List<ISCMOrderHeaderRecord> answerdDataList = (retList.Count > 1 && retList[1] is List<ISCMOrderHeaderRecord>) ? (List<ISCMOrderHeaderRecord>)retList[1] : null;
                            // ADD 2012/07/17 システムテスト障害№96 ---------------------->>>>>
                            // ---ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 --------->>>>>
                            try
                            {
                            // ---ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------<<<<
                                DateTime lateUpdateDate = _getLateUpdateDate;
                                int lateUpdateTime = _getLateUpdateTime;
                                // ADD 2012/07/17 システムテスト障害№96 ----------------------<<<<<
                                if (newdataList != null && newdataList.Count > 0)
                                {
                                    // 2011/02/25 Add <<<

                                    // DEL 2012/07/17 システムテスト障害№96 ---------------------->>>>>
                                    //DateTime lateUpdateDate = _getLateUpdateDate;
                                    //int lateUpdateTime = _getLateUpdateTime;
                                    // DEL 2012/07/17 システムテスト障害№96 ----------------------<<<<<
                                    // 2011/02/25 >>>
                                    //foreach (ISCMOrderHeaderRecord work in ( (List<ISCMOrderHeaderRecord>)obj ))
                                    foreach (ISCMOrderHeaderRecord work in newdataList)
                                    // 2011/02/25 <<<
                                    {
                                        // --- ADD m.suzuki 2010/07/30 ---------->>>>>
                                        // 設定マッチングチェック
                                        if (this._newArrNtfyController.Match(work.InqOtherEpCd, work.InqOtherSecCd, work.CustomerCode) == false)
                                        {
                                            // この端末では対象外のデータ
                                            continue;
                                        }
                                        // --- ADD m.suzuki 2010/07/30 ----------<<<<<

                                        // PMの新着チェッカーは、そもそも当日分しか取らないけど...
                                        if (_getLateUpdateDate == DateTime.MinValue || _getLateUpdateDate < work.UpdateDate)
                                        {
                                            _availableDataQueue.Enqueue(work);
                                        }
                                        else if (_getLateUpdateDate == work.UpdateDate)
                                        {
                                            if (_getLateUpdateTime < work.UpdateTime)
                                            {
                                                _availableDataQueue.Enqueue(work);
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }

                                        // 今回取得の最終データを退避
                                        if (lateUpdateDate < work.UpdateDate)
                                        {
                                            lateUpdateDate = work.UpdateDate;
                                            lateUpdateTime = work.UpdateTime;
                                        }
                                        else if (lateUpdateDate == work.UpdateDate)
                                        {
                                            if (lateUpdateTime < work.UpdateTime)
                                            {
                                                lateUpdateTime = work.UpdateTime;
                                            }
                                        }
                                    }
                                    // DEL 2012/07/17 システムテスト障害№96 ---------------------->>>>>
                                    //_scmLocalSet.LastGetDate = lateUpdateDate;
                                    //_scmLocalSet.LastGetTime = lateUpdateTime;
                                    //ScmLocalSetAcs scmLocalSetAcs = new ScmLocalSetAcs();
                                    //scmLocalSetAcs.ScmLocal = _scmLocalSet;
                                    //scmLocalSetAcs.WriteScmLocalSet();
                                    //_nowLateUpdateDate = lateUpdateDate;
                                    //_nowLateUpdateTime = lateUpdateTime;
                                    // DEL 2012/07/17 システムテスト障害№96 ----------------------<<<<<
                                    // 2011/02/25 >>>
                                }
                                if (answerdDataList != null && answerdDataList.Count > 0)
                                {
                                    foreach (ISCMOrderHeaderRecord work in answerdDataList)
                                    {
                                        // 設定マッチングチェック
                                        if (this._newArrNtfyController.Match(work.InqOtherEpCd, work.InqOtherSecCd, work.CustomerCode) == false)
                                        {
                                            // この端末では対象外のデータ
                                            continue;
                                        }
                                        // UPD 2012/07/17 システムテスト障害№96 ---------------------->>>>> 
                                        // 回答済みデータに関しては、時間チェック無し
                                        //_answeredDataQueue.Enqueue(work);
                                        // 回答済みデータの時間チェックを行う
                                        if (_getLateUpdateDate == DateTime.MinValue || _getLateUpdateDate < work.UpdateDate)
                                        {
                                            _answeredDataQueue.Enqueue(work);
                                        }
                                        else if (_getLateUpdateDate == work.UpdateDate)
                                        {
                                            if (_getLateUpdateTime < work.UpdateTime)
                                            {
                                                _answeredDataQueue.Enqueue(work);
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }

                                        // 今回取得の最終データを退避
                                        if (lateUpdateDate < work.UpdateDate)
                                        {
                                            lateUpdateDate = work.UpdateDate;
                                            lateUpdateTime = work.UpdateTime;
                                        }
                                        else if (lateUpdateDate == work.UpdateDate)
                                        {
                                            if (lateUpdateTime < work.UpdateTime)
                                            {
                                                lateUpdateTime = work.UpdateTime;
                                            }
                                        }
                                        // UPD 2012/07/17 システムテスト障害№96 ----------------------<<<<<

                                        this._dataKey = this.DataToKey(work);  // ADD 2011/10/10
                                    }
                                }
                                // 2011/02/25 <<<
                                // ADD 2012/07/17 システムテスト障害№96 ---------------------->>>>>
                                // 今回取得の最終時間を保管
                                _scmLocalSet.LastGetDate = lateUpdateDate;
                                _scmLocalSet.LastGetTime = lateUpdateTime;
                                ScmLocalSetAcs scmLocalSetAcs = new ScmLocalSetAcs();
                                scmLocalSetAcs.ScmLocal = _scmLocalSet;
                                scmLocalSetAcs.WriteScmLocalSet();
                                //_nowLateUpdateDate = lateUpdateDate;// DEL 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応
                                //_nowLateUpdateTime = lateUpdateTime;// DEL 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応
                                // ADD 2012/07/17 システムテスト障害№96 ----------------------<<<<< 

                                // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                if (_nowLateUpdateDate == lateUpdateDate && _nowLateUpdateTime == lateUpdateTime)
                                {
                                    // 今回取得の最終日付と時間は前回取得の最終日付と時間が一致の場合、
                                }
                                else
                                {
                                    // 今回取得最終日付と時間はDBに保存します。
                                    int status = Terminal.UpdateScmTimeData(this._newArrNtfyController.PosTerminalMg.CashRegisterNo, lateUpdateDate, lateUpdateTime);

                                    // ログを出力します。
                                    StringBuilder before = new StringBuilder();
                                    {
                                        before.Append("新着データの最終取得日付と最終取得時間を取得します。status = " + status).Append(Environment.NewLine);
                                        before.Append(TAB).Append("企業コード：[").Append(this._settingList[0]).Append("]").Append(Environment.NewLine);
                                        before.Append(TAB).Append("拠点コード：[").Append(this._settingList[1]).Append("]").Append(Environment.NewLine);
                                        before.Append(TAB).Append("端末番号：[").Append(this._newArrNtfyController.PosTerminalMg.CashRegisterNo).Append("]").Append(Environment.NewLine);
                                        before.Append(TAB).Append("最終取得日付：[").Append(lateUpdateDate).Append("]").Append(Environment.NewLine);
                                        before.Append(TAB).Append("最終取得時間：[").Append(lateUpdateTime).Append("]").Append(Environment.NewLine);
                                    }
                                    LogWriter.LogWrite(before.ToString());
                                }
                                _nowLateUpdateDate = lateUpdateDate;
                                _nowLateUpdateTime = lateUpdateTime;
                                // ADD 2012/07/17 システムテスト障害№96 ----------------------<<<<< 

                                // ShowPopupメソッドがルーツで処理の場合、毎日初回のみ60日前のログファイルを削除します。
                                if (this._deletTime != DateTime.Today)
                                {
                                    this._deletTime = DateTime.Today;
                                    this._timeDeletFlg = false;
                                }
                                // 初回削除FLG = FALSE && 削除日付 = システム日付
                                if (!this._timeDeletFlg && this._deletTime == DateTime.Today)
                                {
                                    // 今日初回ログファイルを削除します。
                                    Thread logDeletThread = new Thread(this.LogDelet);
                                    logDeletThread.IsBackground = true;
                                    logDeletThread.Start();
                                    this._timeDeletFlg = true;
                                }
                                // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<


                                // 2011/02/25 >>>
                                //if (_availableDataQueue.Count > 0 && ( !CheckCMT() ))
                                int newDataCount = _availableDataQueue.Count;
                                // DEL 2012/07/17 システムテスト障害№96 -------------------------------->>>>>>
                                // ADD 2012/06/26 №71  ----------------------------------------->>>>> 
                                // 回答リストに自動回答データが含まれているか
                                //bool autoAnswerFlag = false;
                                // ADD 2012/06/26 №71  -----------------------------------------<<<<< 
                                // DEL 2012/07/17 システムテスト障害№96 --------------------------------<<<<<
                                if (((_availableDataQueue.Count > 0) || (_answeredDataQueue.Count > 0)) && (!CheckCMT()))
                                // 2011/02/25 <<<
                                {
                                    // --- Add 2011/08/19 duzg for Redmine#23241対応 --->>>
                                    bool existsFlg = false;
                                    if (_availableDataQueue.Count > 0)
                                    {
                                        List<ISCMOrderHeaderRecord> answerdList = new List<ISCMOrderHeaderRecord>();
                                        IEnumerator ie = _availableDataQueue.GetEnumerator();
                                        while (ie.MoveNext())
                                        {
                                            answerdList.Add((ISCMOrderHeaderRecord)ie.Current);
                                        }
                                        // UPD 2014/04/24 SCM仕掛一覧№10651対応 ---------------------------->>>>>
                                        //existsFlg = answerdList.Exists(delegate(ISCMOrderHeaderRecord p) { return p.AnswerDivCd == 10; });
                                        existsFlg = answerdList.Exists(delegate(ISCMOrderHeaderRecord p) { return p.AnswerDivCd == 10 && p.AcptAnOdrStatus != 0; });
                                        // UPD 2014/04/24 SCM仕掛一覧№10651対応 ----------------------------<<<<<
                                    }

                                    if (_answeredDataQueue.Count > 0)
                                    {
                                        List<ISCMOrderHeaderRecord> answerdList = new List<ISCMOrderHeaderRecord>();
                                        List<ISCMOrderHeaderRecord> midList = new List<ISCMOrderHeaderRecord>();
                                        IEnumerator ie = _answeredDataQueue.GetEnumerator();
                                        while (ie.MoveNext())
                                        {
                                            answerdList.Add((ISCMOrderHeaderRecord)ie.Current);
                                            midList.Add((ISCMOrderHeaderRecord)ie.Current);
                                        }
                                        // DEL 2012/07/17 システムテスト障害№96 -------------------------------->>>>>
                                        //for (int i = 0; i < _bakAnswerdList.Count; i++)
                                        //{
                                        //    ISCMOrderHeaderRecord record = _bakAnswerdList[i];
                                        //    if (answerdList.Exists(delegate(ISCMOrderHeaderRecord p) { return p.InquiryNumber == record.InquiryNumber; }))
                                        //    {
                                        //        for (int k = 0; k < answerdList.Count; k++)
                                        //        {
                                        //            ISCMOrderHeaderRecord midrecord = answerdList[k];
                                        //            if (midrecord.InquiryNumber == record.InquiryNumber)
                                        //            {
                                        //                answerdList.RemoveAt(k);
                                        //                break;
                                        //            }
                                        //        }
                                        //    }
                                        //}
                                        // DEL 2012/07/17 システムテスト障害№96 --------------------------------<<<<<
                                        if (!existsFlg)
                                        {
                                            existsFlg = answerdList.Exists(delegate(ISCMOrderHeaderRecord p) { return p.AnswerCreateDiv == (int)AnswerCreateDivValue.Auto; });
                                            // DEL 2012/07/17 システムテスト障害№96 -------------------------------->>>>>>
                                            // ADD 2012/06/26 №71  ---------------------------------------------->>>>> 
                                            //autoAnswerFlag = existsFlg;
                                            // ADD 2012/06/26 №71  ----------------------------------------------<<<<<
                                            // DEL 2012/07/17 システムテスト障害№96 --------------------------------<<<<<
                                        }
                                        _bakAnswerdList = midList;
                                    }
                                    // --- Add 2011/08/19 duzg for Redmine#23241対応 ---<<<
                                    this.SetNewestData();
                                    // --- Add 2011/07/28 duzg for Redmine#23241対応 --->>>
                                    if (existsFlg)
                                    {
                                        int count = 0;
                                        if (this._dataTable.Rows.Count >= 5)
                                        {
                                            count = 5;
                                        }
                                        else
                                        {
                                            count = this._dataTable.Rows.Count;
                                        }
                                        if (existsFlg && this._visbleFlg)
                                        {
                                            // UPD 2012/07/17 システムテスト障害№96 ---------------------->>>>> 
                                            // UPD 2012/06/26 №71  --------------------------------------->>>>> 
                                            ////this.bottom_panel.visible = true;
                                            ////if (this._visbleflg && bottom_panel.visible)
                                            ////{
                                            ////    this.lblinformation.text = string.format(msg_new_order, this._datatable.rows.count + 1);
                                            ////}
                                            ////this.height = ctdefaultformheight + (this.datagridview_data.rowtemplate.height * count) + 50;
                                            //this.bottom_Panel.Visible = false;
                                            //// 新着情報を表示する
                                            //if (this._visbleFlg && bottom_Panel.Visible)
                                            //{
                                            //    this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count + 1);
                                            //    this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count) + 50;
                                            //}
                                            //// 自動回答通知を表示する
                                            //else if (this._visbleFlg && autoAnswerFlag)
                                            //{
                                            //    this.bottom_Panel.Visible = true;
                                            //    this.autoAnswerLabel.Visible = true;
                                            //    this.lblInformation.Text = MSG_AUTO_ANSWER;
                                            //    this.Height = ctDefaultFormHeight + this.bottom_Panel.Height;
                                            //    LightsPatLamp = true;
                                            //}
                                            //// 上記以外の通知を表示する
                                            //else
                                            //{
                                            //    this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count) + 50;
                                            //}
                                            // UPD 2012/06/26 №71  ---------------------------------------<<<<< 
                                            this.bottom_Panel.Visible = true;
                                            if (this._visbleFlg && bottom_Panel.Visible)
                                            {
                                                // UPD 2012/07/19 システムテスト障害No.113 ----------------------------------->>>>>
                                                //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count + 1);
                                                // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                                //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                                                if (this._ManualAnswerMode)
                                                {
                                                    this.lblInformation.Text = MSG_MANUAL_MODE;
                                                }
                                                else
                                                {
                                                    this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                                                }
                                                // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                                // UPD 2012/07/19 システムテスト障害No.113 -----------------------------------<<<<<
                                            }
                                            this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count) + 50;
                                            // 自動回答通知を表示する
                                            if (this._visbleFlg && this._autoAnswerDisplay)
                                            {
                                                // UPD 2012/07/19 システムテスト障害No.113 ----------------------------------->>>>>
                                                //if (count == 0) this.lblInformation.Text = string.Format(MSG_NEW_ORDER, 1);
                                                // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                                //if (count == 0) this.lblInformation.Text = MSG_AUTO_ANSWER;
                                                if (this._ManualAnswerMode)
                                                {
                                                    if (count == 0) this.lblInformation.Text = MSG_MANUAL_MODE;
                                                }
                                                else
                                                {
                                                    if (count == 0) this.lblInformation.Text = MSG_AUTO_ANSWER;
                                                }
                                                // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                                // UPD 2012/07/19 システムテスト障害No.113 -----------------------------------<<<<<
                                                LightsPatLamp = true;
                                            }
                                            if (bottom_Panel.Visible) this.autoAnswerLabel.Visible = true;
                                            // UPD 2012/07/17 システムテスト障害№96 ----------------------<<<<< 
                                        }
                                        if (!this._visbleFlg && this.bottom_Panel.Visible)
                                        {
                                            this.bottom_Panel.Visible = false;
                                            // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                            //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                                            if (this._ManualAnswerMode)
                                            {
                                                this.lblInformation.Text = MSG_MANUAL_MODE;
                                            }
                                            else
                                            {
                                                this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                                            }
                                            // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                            this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count);
                                        }
                                    }
                                    // --- Add 2011/07/28 duzg for Redmine#23241対応 ---<<<

                                    /* --- Del 2011/07/28 duzg for Redmine#23241対応 --->>>
                                    // --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする --->>>
                                    this._scmInquiryOrderAcs = SCMInquiryOrderAcs.GetInstance();
                                    SCMInquiryOrder scmInquiryOrder = SetExtraInfo();
                                    string errMsg = string.Empty;
                                    _scmInquiryOrderAcs.Search(scmInquiryOrder, out errMsg);
                                    int count = 0;
                                    if (this._dataTable.Rows.Count >= 5)
                                    {
                                        count = 5;
                                    }
                                    else
                                    {
                                        count = this._dataTable.Rows.Count;
                                    }
                                    if (_scmInquiryOrderAcs.SCMInquiryResultDataTable.Count > 0 && this._visbleFlg)
                                    {
                                        this.bottom_Panel.Visible = true;
                                        this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count) + 50;
                                    }
                                    if (!this._visbleFlg && this.bottom_Panel.Visible)
                                    {
                                        this.bottom_Panel.Visible = false;
                                        this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count);
                                    }
                                    // --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする ---<<<
                                    --- Del 2011/07/28 duzg for Redmine#23241対応 --->>>*/

                                    // 2011/02/25 >>>
                                    //SetVisibleState(true);
                                    // UPD 2012/06/26 №71  ----------------------------------------------->>>>> 
                                    //if (this._dataTable.Rows.Count == 0)
                                    //{
                                    //    this.Visible = false;
                                    //}
                                    //else
                                    //{
                                    //    if (newDataCount > 0) SetVisibleState(true);
                                    //}
                                    // 新着情報も自動回答通知もない場合、表示しない
                                    // UPD 2012/07/17 システムテスト障害№96 -------------------------------->>>>>
                                    //if (this._dataTable.Rows.Count == 0 && (!this._visbleFlg || !autoAnswerFlag))
                                    if (this._dataTable.Rows.Count == 0 && (!this._visbleFlg || !this._autoAnswerDisplay))
                                    // UPD 2012/07/17 システムテスト障害№96 --------------------------------<<<<<
                                    {
                                        // DEL 2012/07/11 システムテスト障害№80 --------------------->>>>>
                                        //this.Visible = false;
                                        // DEL 2012/07/11 システムテスト障害№80 ---------------------<<<<<
                                    }
                                    else
                                    {
                                        // ポップアップ表示時の表示状態を設定
                                        // UPD 2012/07/17 システムテスト障害№96 -------------------------------->>>>>
                                        //if (newDataCount > 0 || (this._visbleFlg && autoAnswerFlag)) SetVisibleState(true);
                                        if (newDataCount > 0 || (this._visbleFlg && this._autoAnswerDisplay)) SetVisibleState(true);
                                        // UPD 2012/07/17 システムテスト障害№96 --------------------------------<<<<<

                                        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
                                        if (newDataCount > 0 || (this._visbleFlg && this._autoAnswerDisplay))
                                        {
                                            if (this._visbleFlg && this._autoAnswerDisplay)
                                            {
                                                _autoStartTime = DateTime.Now; // 自動回答着信時間セット
                                            }
                                            SoundStart();
                                        }
                                        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<

                                        // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
                                        int retryCount = 0;
                                        RetryNoAuto(newdataList, answerdDataList, _pushkeyWK, ref retryCount);
                                        //// 2012/11/21 ADD TAKAGAWA SCM障害改良No10415仕様変更対応 ----------->>>>>>>>>>>>>>>>>>>>
                                        ////bool AutoAnswerExistFlag = false;   // 自動回答データ存在チェックフラグ

                                        //// 一部自動回答分チェック
                                        //foreach (ISCMOrderHeaderRecord _ISCMOrderHeaderRecord in newdataList)
                                        //{
                                        //    if (_ISCMOrderHeaderRecord.AnswerCreateDiv == 0) AutoAnswerExistFlag = true;    // 自動回答ならtrue
                                        //}

                                        //// 全部自動回答分チェック
                                        //foreach (ISCMOrderHeaderRecord _ISCMOrderHeaderRecord in answerdDataList)
                                        //{
                                        //    if (_ISCMOrderHeaderRecord.AnswerCreateDiv == 0) AutoAnswerExistFlag = true;
                                        //}
                                        //LogWriter.LogWrite("SCMPopupForm.ShowPopup ⇒ WebSync手動回答の通知 開始 通知パラメータ:" + _pushkeyWK + " 通知処理モード:" + ScmPushDataConstMode.NOAUTOANSWER.ToString());// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                                        //// 自動回答されたデータが1件もない場合は手動回答の通知をする
                                        //if (AutoAnswerExistFlag == false) NotifyOtherSidePCCUOEStatus(_pushkeyWK, ScmPushDataConstMode.NOAUTOANSWER.ToString());
                                        //LogWriter.LogWrite("SCMPopupForm.ShowPopup ⇒ WebSync手動回答の通知 終了");// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                                        //// 2012/11/21 ADD TAKAGAWA SCM障害改良No10415仕様変更対応 -----------<<<<<<<<<<<<<<<<<<<<
                                        // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
                                    }
                                    // UPD 2012/06/26 №71  -----------------------------------------------<<<<< 
                                    // 2011/02/25 <<<
                                }
                            // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 --------->>>>>
                            }
                            catch (Exception ex)
                            {
                                LogWriter.LogWrite("SCMPopupForm.ShowPopup ⇒ 例外内容：" + ex.ToString());
                                NoRetryNoAuto(newdataList, answerdDataList, _pushkeyWK);
                                throw ex;
                            }
                            // --- ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------<<<<<
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    // 2010/03/03 Add >>>
                    _getLateUpdateDate = _nowLateUpdateDate;
                    _getLateUpdateTime = _nowLateUpdateTime;
                    // 2010/03/03 Add <<<
                }
            }
        }

        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ログ削除処理
        /// </summary>
        /// <param name="pMsg"></param>
        public void LogDelet()
        {
            string workDir = null;

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Product\Partsman");

                if (key == null) // あってはいけないケース
                {
                    workDir = @"C:\Program Files\Partsman"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    // ログ書き込みﾌｫﾙﾀﾞ指定
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman").ToString();
                }
                string path = Path.Combine(@workDir, "Log\\PMCMN06200S");
                DateTime writingDateTime = DateTime.Now;
                // フォルダ存在する
                if (Directory.Exists(path))
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    FileSystemInfo[] fi = di.GetFileSystemInfos();

                    // PMCMN06200Sファイルに全部ファイルを遍歴する。
                    DateTime expiredDateTime = writingDateTime.AddDays(-60);
                    foreach (FileSystemInfo tempFsi in fi)
                    {
                        // // ログファイルの保存期間（６０日）を過ぎたログは削除します。
                        if (tempFsi.LastWriteTime <= expiredDateTime)
                        {
                            // DEL 2015/09/11 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            //if (tempFsi.GetType() == typeof(FileInfo))
                            //{
                            //    tempFsi.Delete();
                            //}
                            // DEL 2015/09/11 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<

                            // ADD 2015/09/11 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            try
                            {
                                if (tempFsi.GetType() == typeof(FileInfo))
                                {
                                    tempFsi.Delete();
                                }
                            }
                            catch
                            {

                            }
                            // ADD 2015/09/11 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        }
                    }
                }
            }
            catch
            {
                // ファイルを削除する時、それぞれ異常エラーが発生の可能性があります。既存処理を影響しないために、エラーが発生の時、何もしない。
            }
        }
        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion // </ポップアップ>

        #region <着信音>
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
        /// <summary>
        /// 着信音開始
        /// </summary>
        private void SoundStart()
        {
            AppSettingsSection appSettingSection = GetAppSettingsSection();
            // 着信音設定がオンの場合
            // --- UPD 2014/11/21 T.Miyamoto ------------------------------>>>>>
            //if (appSettingSection.Settings[CT_Conf_SoundMode].Value.Equals("1"))
            if ((appSettingSection.Settings[CT_Conf_SoundMode] != null) &&
                (appSettingSection.Settings[CT_Conf_SoundMode].Value.Equals("1")))
            // --- UPD 2014/11/21 T.Miyamoto ------------------------------<<<<<
            {
                if (_SoundPlayer == null)
                {
                    this._soundMode = (appSettingSection.Settings[CT_Conf_SoundMode].Value.Equals("1"));
                    this._soundTime = int.Parse(appSettingSection.Settings[CT_Conf_SoundTime].Value);
                    this._soundPath = appSettingSection.Settings[CT_Conf_SoundPath].Value;

                    if (string.IsNullOrEmpty(this._soundPath.Trim())) this._soundPath = DefaultSoundFileGet();
                    if (!string.IsNullOrEmpty(this._soundPath.Trim()))
                    {
                        // 着信音再生
                        _SoundPlayer = new System.Media.SoundPlayer(this._soundPath);
                        _SoundPlayer.PlayLooping(); //ループ再生

                        SoundCheck_timer.Enabled = true; //着信音停止チェック処理タイマー：オン
                    }
                }
            }
        }

        /// <summary>
        /// 着信音停止
        /// </summary>
        private void SoundStop()
        {
            SoundCheck_timer.Enabled = false; //着信音停止チェック処理タイマー：オフ
            _autoStartTime = DateTime.MinValue;
            if (_SoundPlayer != null)
            {
                _SoundPlayer.Stop();
                _SoundPlayer.Dispose();
                _SoundPlayer = null;
            }
        }

        /// <summary>
        /// 着信音停止チェック(1秒間隔)
        /// </summary>
        private void SoundCheck_timer_Tick(object sender, EventArgs e)
        {
            DateTime startTime;
            TimeSpan checkTime;

            //画面表示(Debug用)
            this.dataGridView_Data.SuspendLayout();
            try
            {
                foreach (DataGridViewRow row in this.dataGridView_Data.Rows)
                {
                    // 現在時刻との差分を計算
                    startTime = Convert.ToDateTime(row.Cells[ctColumnName_DateTime].Value);
                    checkTime = DateTime.Now - startTime;

                    row.Cells[ctColumnName_Elapsed].Value = Math.Truncate(checkTime.TotalSeconds).ToString();
                    if (checkTime.TotalSeconds < this._soundTime)
                    {
                    }
                    else
                    {
                        row.Cells[ctColumnName_Elapsed].Value = "消音";
                    }
                }
            }
            finally
            {
                this.dataGridView_Data.ResumeLayout();
            }

            bool checkSound = false;
            // 着信データ(手動回答)が存在する場合
            if (this.dataGridView_Data.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in this.dataGridView_Data.Rows)
                {
                    // 現在時刻との差分を計算
                    startTime = Convert.ToDateTime(row.Cells[ctColumnName_DateTime].Value);
                    checkTime = DateTime.Now - startTime;
                    if (checkTime.TotalSeconds < this._soundTime)
                    {
                        checkSound = true;
                        break;
                    }
                }
            }
            // 自動回答データが存在する場合
            if (_autoStartTime != DateTime.MinValue)
            {
                checkTime = DateTime.Now - _autoStartTime;
                if (checkTime.TotalSeconds < this._soundTime)
                {
                    checkSound = true;
                }
            }
            // 全て着信音の設定再生時間を超えた場合
            if (!checkSound)
            {
                SoundStop(); //消音
            }
        }

        /// <summary>
        /// デフォルト着信音取得
        /// </summary>
        private string DefaultSoundFileGet()
        {
            // Windowsのデフォルトメール着信音
            const string CT_RegKey_SoundFile = "AppEvents\\Schemes\\Apps\\.Default\\MailBeep\\.current";
            const string CT_RegName_SoundFile = ""; //規定値

            string fileName = string.Empty;

            //キーを読み取り専用で開く
            Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(CT_RegKey_SoundFile, false);
            //キーが存在
            if (regkey != null)
            {
                fileName = (string)regkey.GetValue(CT_RegName_SoundFile);
            }
            regkey.Close();

            return fileName;
        }
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<
        #endregion // </着信音>

        #region <SCM問合せ一覧>

        /// <summary>
        /// SCM問合せ一覧のアプリケーション名称
        /// </summary>
        private const string SCM_ORDER_DATA_VIEWER_EXE_NAME = "PMSCM04000U.exe";

        // 2010/03/02 >>>
        /// <summary>売上伝票入力のアプリケーション名称</summary>
        //>>>2010/06/17 Delphi売伝対応
        //private const string SCM_NS_ENTRY_EXE_NAME = "MAHNB01000U.exe";
        private const string SCM_NS_ENTRY_EXE_NAME = "MAHNB01001U.exe";
        //<<<2010/06/17 Delphi売伝対応
        // 2010/03/02 <<<
        private const string SCM_PM7_EXE_NAME = "PMPP1101E.exe";

        // 2010/04/16 Del >>>
        #region 削除
        ///// <summary>
        ///// 情報表示ラベルのClickイベントハンドラ
        ///// </summary>
        ///// <param name="sender">イベントソース</param>
        ///// <param name="e">イベントパラメータ</param>
        //private void lblInformation_Click(object sender, EventArgs e)
        //{
        //    if (Program.PM7Mode)
        //    {
        //        // SCM問合せ一覧を起動
        //        Process.Start(SCM_PM7_EXE_NAME, "");
        //    }
        //    else
        //    {
        //        // 2010/03/02 >>>
        //        //string programPath = Path.Combine(Directory.GetCurrentDirectory(), SCM_ORDER_DATA_VIEWER_EXE_NAME);
        //        string programPath = Path.Combine(Directory.GetCurrentDirectory(), SCM_NS_ENTRY_EXE_NAME);
        //        // 2010/03/02 <<<
        //        if (!File.Exists(programPath)) return;

        //        // ログインパラメータ情報を設定
        //        StringBuilder loginArguments = new StringBuilder();
        //        {
        //            foreach (string argument in CommandLineArgs)
        //            {
        //                if (!string.IsNullOrEmpty(argument.Trim()))
        //                {
        //                    loginArguments.Append(argument + " ");
        //                }
        //            }
        //        }

        //        // 2010/04/16 >>>
        //        //// 2010/03/02 >>>
        //        ////loginArguments.Append("Popup");
        //        //// 2010/04/16 >>>
        //        //if (lblInformation.Tag != null && lblInformation.Tag is ScmOdrData)
        //        //{
        //        //    ScmOdrData scmOdrData = (ScmOdrData)lblInformation.Tag;
        //        //    loginArguments.Append("/INQ" + " ");
        //        //    loginArguments.Append(scmOdrData.InquiryNumber.ToString() + ",");
        //        //    loginArguments.Append(0.ToString() + ",");
        //        //    loginArguments.Append("000000000" + ",");
        //        //    loginArguments.Append(scmOdrData.InqOriginalEpCd + ",");
        //        //    loginArguments.Append(scmOdrData.InqOriginalSecCd + ",");
        //        //    loginArguments.Append(scmOdrData.InqOrdDivCd.ToString() + " ");
        //        //}
        //        ////this.Close();

        //        if (sender is Infragistics.Win.Misc.UltraLabel)
        //        {
        //            Infragistics.Win.Misc.UltraLabel lbl = (Infragistics.Win.Misc.UltraLabel)sender;

        //            if (lbl.Tag != null && lbl.Tag is ISCMOrderHeaderRecord)
        //            {
        //                ISCMOrderHeaderRecord scmOdrData = (ISCMOrderHeaderRecord)lbl.Tag;
        //                loginArguments.Append("/INQ" + " ");
        //                loginArguments.Append(scmOdrData.InquiryNumber.ToString() + ",");
        //                loginArguments.Append(0.ToString() + ",");
        //                loginArguments.Append("000000000" + ",");
        //                loginArguments.Append(scmOdrData.InqOriginalEpCd + ",");
        //                loginArguments.Append(scmOdrData.InqOriginalSecCd + ",");
        //                loginArguments.Append(scmOdrData.InqOrdDivCd.ToString() + ",");
        //                loginArguments.Append(scmOdrData.AnswerDivCd.ToString() + " ");
        //            }
        //        }
        //        // 2010/04/16 <<<

        //        // SCM問合せ一覧を起動
        //        Process.Start(programPath, loginArguments.ToString());
        //    }
        //}
        #endregion
        // 2010/04/16 Del <<<

        #endregion // </SCM問合せ一覧>

////////////////////////////////////////////// 2012.04.11 TERASAKA ADD STA //
		#region InitialProc
		/// <summary>
		/// 初期処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ダミーデータを自動回処理に流します</br>
		/// <br>			: ※2回目以降の自動回答が高速化される為</br>
		/// <br>Programmer	: 22024 寺坂 誉志</br>
		/// <br>Date		: 2012.04.11</br>
        /// <br>Update Note : 2018/04/16 田建委</br>
        /// <br>管理番号    : 11470007-00</br>
        /// <br>            : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
		/// </remarks>
		private void InitialProc(object sender)
		{
			string inqOriginalEpCd	= string.Empty;
			string inqOriginalSecCd	= string.Empty;

			bool msgDiv;
			string errMsg;

			// 企業拠点連結より有効な問合せ元企業コード、問合せ元拠点コードを取得する
			ScmEpCnectAcs scmEpCnectAcs = new ScmEpCnectAcs();
			List<ScmEpCnect> scmEpCnectList;
			int status = scmEpCnectAcs.SearchCnectOriginalEp(_enterpriseCode, ConstantManagement.LogicalMode.GetData0, out scmEpCnectList, out msgDiv, out errMsg);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				List<ScmEpCnect> wkList = scmEpCnectList.FindAll(
					delegate(ScmEpCnect wkObj)
					{
						if (wkObj.DiscDivCd == 0)
							return true;
						else
							return false;
					}
				);

				if (wkList != null && wkList.Count > 0)
				{
					ScmEpScCntAcs scmEpScCntAcs = new ScmEpScCntAcs();
					List<ScmEpScCnt> scmEpScCntList;
					status = scmEpScCntAcs.SearchCnectOriginalEpFromSc(_enterpriseCode, ConstantManagement.LogicalMode.GetData0, out scmEpScCntList, out msgDiv, out errMsg);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						foreach (ScmEpCnect scmEpCnect in wkList)
						{
							ScmEpScCnt scmEpScCnt = scmEpScCntList.Find(
								delegate(ScmEpScCnt wkObj)
								{
									if (wkObj.CnectOriginalEpCd		== wkObj.CnectOriginalEpCd &&
										wkObj.CnectOriginalSecCd	== wkObj.CnectOriginalSecCd &&
										wkObj.CnectOtherEpCd		== wkObj.CnectOtherEpCd &&
										wkObj.CnectOtherSecCd		== wkObj.CnectOtherSecCd &&
										wkObj.DiscDivCd == 0)
										return true;
									else
										return false;
								}
							);
							if (scmEpScCnt != null)
							{
								inqOriginalEpCd		= scmEpScCnt.CnectOriginalEpCd.Trim();//@@@@20230303
								inqOriginalSecCd	= scmEpScCnt.CnectOriginalSecCd;
								break;
							}
						}
					}
				}
			}

			if (inqOriginalEpCd.Trim() == string.Empty)//@@@@20230303
			{
				// ダミー企業コードをセットする
				inqOriginalEpCd		= "0140150842030114";
				inqOriginalSecCd	= "000001";
			}

			List<ISCMOrderHeaderRecord> autoReplyHeaderRecordList = new List<ISCMOrderHeaderRecord>();

			#region ダミーデータセット
			ISCMOrderHeaderRecord iSCMOrderHeaderRecord = new UserSCMOrderHeaderRecord();
			iSCMOrderHeaderRecord.InqOriginalEpCd		= inqOriginalEpCd.Trim();//@@@@20230303
			iSCMOrderHeaderRecord.InqOriginalSecCd		= inqOriginalSecCd;
			iSCMOrderHeaderRecord.InqOtherEpCd			= _enterpriseCode;
			iSCMOrderHeaderRecord.InqOtherSecCd			= _sectionCode;
			iSCMOrderHeaderRecord.InquiryNumber			= -1;
			iSCMOrderHeaderRecord.UpdateDate			= new DateTime(634696992000000000);
			iSCMOrderHeaderRecord.UpdateTime			= 220553489;
			iSCMOrderHeaderRecord.AnswerDivCd			= 0;
			iSCMOrderHeaderRecord.InqOrdNote			= string.Empty;
			iSCMOrderHeaderRecord.AnsEmployeeCd			= string.Empty;
			iSCMOrderHeaderRecord.AnsEmployeeNm			= string.Empty;
			iSCMOrderHeaderRecord.InquiryDate			= new DateTime(634696992000000000);
			iSCMOrderHeaderRecord.InqOrdAnsDivCd		= 1;
			iSCMOrderHeaderRecord.ReceiveDateTime		= new DateTime(0);
			iSCMOrderHeaderRecord.EnterpriseCode		= "0101150842020070";
            //iSCMOrderHeaderRecord.CustomerCode			= 2; // DEL 2015/10/09 陳艶丹 For Redmine #47456
            iSCMOrderHeaderRecord.CustomerCode          = 100000000; // ADD 2015/10/09 陳艶丹 For Redmine #47456
			iSCMOrderHeaderRecord.InqOrdDivCd			= 1;
			iSCMOrderHeaderRecord.AcptAnOdrStatus		= 0;
			iSCMOrderHeaderRecord.SalesSlipNum			= "000000000";
			iSCMOrderHeaderRecord.SalesTotalTaxInc		= 0;
			iSCMOrderHeaderRecord.AnswerCreateDiv		= 1;
			iSCMOrderHeaderRecord.CancelDiv				= 0;
			iSCMOrderHeaderRecord.CMTCooprtDiv			= 0;
			iSCMOrderHeaderRecord.JudgementDate			= new DateTime(0);
			iSCMOrderHeaderRecord.SfPmCprtInstSlipNo	= string.Empty;
			iSCMOrderHeaderRecord.AcceptOrOrderKind		= 1;
			autoReplyHeaderRecordList.Add(iSCMOrderHeaderRecord);

			List<ISCMOrderDetailRecord> autoReplyDetailRecordList = new List<ISCMOrderDetailRecord>();
			ISCMOrderDetailRecord iSCMOrderDetailRecord = new UserSCMOrderDetailRecord();
			iSCMOrderDetailRecord.InqOriginalEpCd		= inqOriginalEpCd.Trim();//@@@@20230303
			iSCMOrderDetailRecord.InqOriginalSecCd		= inqOriginalSecCd;
			iSCMOrderDetailRecord.InqOtherEpCd			= _enterpriseCode;
			iSCMOrderDetailRecord.InqOtherSecCd			= _sectionCode;
			iSCMOrderDetailRecord.InquiryNumber			= -1;
			iSCMOrderDetailRecord.UpdateDate			= new DateTime(634696992000000000);
			iSCMOrderDetailRecord.UpdateTime			= 220553489;
			iSCMOrderDetailRecord.InqRowNumber			= 1;
			iSCMOrderDetailRecord.InqRowNumDerivedNo	= 1;
			iSCMOrderDetailRecord.BLGoodsCode			= 12;
			iSCMOrderDetailRecord.BLGoodsDrCode			= 0;
			iSCMOrderDetailRecord.GoodsDivCd			= 0;
			iSCMOrderDetailRecord.InqGoodsName			= "オイルエレメント";
			iSCMOrderDetailRecord.AnsGoodsName			= string.Empty;
			iSCMOrderDetailRecord.GoodsNo				= string.Empty;
			iSCMOrderDetailRecord.GoodsMakerCd			= 0;
			iSCMOrderDetailRecord.SalesOrderCount		= 1;
			iSCMOrderDetailRecord.DeliveredGoodsCount	= 0;
			iSCMOrderDetailRecord.ListPrice				= 0;
			iSCMOrderDetailRecord.UnitPrice				= 0;
			iSCMOrderDetailRecord.ShelfNo				= string.Empty;
			iSCMOrderDetailRecord.InqOrdDivCd			= 1;
			iSCMOrderDetailRecord.RecyclePrtKindCode	= 0;
			iSCMOrderDetailRecord.RecyclePrtKindName	= string.Empty;
			iSCMOrderDetailRecord.AnswerDeliveryDate	= string.Empty;
			iSCMOrderDetailRecord.DisplayOrder			= 1;
			iSCMOrderDetailRecord.EnterpriseCode		= _enterpriseCode;
			iSCMOrderDetailRecord.CancelCndtinDiv		= 0;
			iSCMOrderDetailRecord.AcptAnOdrStatus		= 0;
			iSCMOrderDetailRecord.SalesSlipNum			= "000000000";
			iSCMOrderDetailRecord.SalesRowNo			= 0;
			iSCMOrderDetailRecord.DtlTakeinDivCd		= 0;
			iSCMOrderDetailRecord.PmWarehouseCd			= string.Empty;
			iSCMOrderDetailRecord.PmWarehouseName		= string.Empty;
			iSCMOrderDetailRecord.PmShelfNo				= string.Empty;
			iSCMOrderDetailRecord.PmPrsntCount			= 0;
			iSCMOrderDetailRecord.SetPartsMkrCd			= 0;
			iSCMOrderDetailRecord.SetPartsNumber		= string.Empty;
			iSCMOrderDetailRecord.SetPartsMainSubNo		= 0;
			iSCMOrderDetailRecord.HandleDivCode			= 0;
			iSCMOrderDetailRecord.GoodsShape			= 0;
			iSCMOrderDetailRecord.DelivrdGdsConfCd		= 0;
			iSCMOrderDetailRecord.DeliGdsCmpltDueDate	= new DateTime(0);
			iSCMOrderDetailRecord.InqPureGoodsNo		= string.Empty;
			iSCMOrderDetailRecord.GoodsAddInfo			= string.Empty;
			iSCMOrderDetailRecord.AnsPureGoodsNo		= string.Empty;
			iSCMOrderDetailRecord.CommentDtl			= string.Empty;
			iSCMOrderDetailRecord.AnswerLimitDate		= new DateTime(0);
			iSCMOrderDetailRecord.GoodsMakerNm			= string.Empty;
			iSCMOrderDetailRecord.PureGoodsMakerCd		= 0;
			iSCMOrderDetailRecord.RoughRrofit			= 0;
			iSCMOrderDetailRecord.RoughRate				= 0;
			iSCMOrderDetailRecord.AdditionalDivCd		= 0;
			iSCMOrderDetailRecord.CorrectDivCD			= 0;
			iSCMOrderDetailRecord.DeliveredGoodsDiv		= 0;
			iSCMOrderDetailRecord.CampaignCode			= 0;
			iSCMOrderDetailRecord.GoodsSpecialNote		= string.Empty;
            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            iSCMOrderDetailRecord.InqBlUtyPtThCd        = string.Empty;
            iSCMOrderDetailRecord.InqBlUtyPtSbCd        = 0;
            iSCMOrderDetailRecord.AnsBlUtyPtThCd        = string.Empty;
            iSCMOrderDetailRecord.AnsBlUtyPtSbCd        = 0;
            iSCMOrderDetailRecord.AnsBLGoodsCode        = 0;
            iSCMOrderDetailRecord.AnsBLGoodsDrCode      = 0;
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
			autoReplyDetailRecordList.Add(iSCMOrderDetailRecord);
			
			List<ISCMOrderCarRecord> autoReplyCarRecordList = new List<ISCMOrderCarRecord>();
			ISCMOrderCarRecord iSCMOrderCarRecord = new UserSCMOrderCarRecord();
			iSCMOrderCarRecord.InqOriginalEpCd		= inqOriginalEpCd.Trim();//@@@@20230303
			iSCMOrderCarRecord.InqOriginalSecCd		= inqOriginalSecCd;
			iSCMOrderCarRecord.InquiryNumber		= -1;
			iSCMOrderCarRecord.CategoryNo			= 24;
			iSCMOrderCarRecord.ModelName			= "プリウス";
			iSCMOrderCarRecord.ModelDesignationNo	= 12100;
			iSCMOrderCarRecord.NumberPlate4			= 0;
			iSCMOrderCarRecord.MakerCode			= 1;
			iSCMOrderCarRecord.ModelCode			= 41;
			iSCMOrderCarRecord.ModelSubCode			= 0;
			iSCMOrderCarRecord.CarInspectCertModel	= "DAA-NHW20";
			iSCMOrderCarRecord.FullModel			= string.Empty;
			iSCMOrderCarRecord.RpColorCode			= string.Empty;
			iSCMOrderCarRecord.ProduceTypeOfYearNum	= 0;
			iSCMOrderCarRecord.TrimCode				= string.Empty;
			iSCMOrderCarRecord.ChassisNo			= string.Empty;
			iSCMOrderCarRecord.AcptAnOdrStatus		= 0;
			iSCMOrderCarRecord.SalesSlipNum			= "000000000";
			iSCMOrderCarRecord.CarNo				= string.Empty;
			iSCMOrderCarRecord.MakerName			= "トヨタ";
			iSCMOrderCarRecord.GradeName			= "Ｇ";
			iSCMOrderCarRecord.BodyName				= string.Empty;
			iSCMOrderCarRecord.DoorCount			= 0;
			iSCMOrderCarRecord.EngineModelNm		= string.Empty;
			iSCMOrderCarRecord.CmnNmEngineDisPlace	= 1500;
			iSCMOrderCarRecord.EngineModel			= "1NZ-3CM";
			iSCMOrderCarRecord.NumberOfGear			= 0;
			iSCMOrderCarRecord.GearNm				= string.Empty;
			iSCMOrderCarRecord.EDivNm				= string.Empty;
			iSCMOrderCarRecord.TransmissionNm		= string.Empty;
			iSCMOrderCarRecord.ShiftNm				= string.Empty;
			iSCMOrderCarRecord.SalesRelationId		= new Guid("d12a9aeb-234f-4112-9bb1-dd690ba5f323");
			autoReplyCarRecordList.Add(iSCMOrderCarRecord);

			List<ISCMOrderDetailRecord> orgDetailRecordList = new List<ISCMOrderDetailRecord>();
			ISCMOrderDetailRecord targetDtl = new UserSCMOrderDetailRecord();
			targetDtl.InqOriginalEpCd		= inqOriginalEpCd.Trim();//@@@@20230303
			targetDtl.InqOriginalSecCd		= inqOriginalSecCd;
			targetDtl.InqOtherEpCd			= _enterpriseCode;
			targetDtl.InqOtherSecCd			= _sectionCode;
			targetDtl.InquiryNumber			= -1;
			targetDtl.UpdateDate			= new DateTime(634696992000000000);
			targetDtl.UpdateTime			= 220553489;
			targetDtl.InqRowNumber			= 1;
			targetDtl.InqRowNumDerivedNo	= 1;
			targetDtl.BLGoodsCode			= 12;
			targetDtl.BLGoodsDrCode			= 0;
			targetDtl.GoodsDivCd			= 0;
			targetDtl.InqGoodsName			= "オイルエレメント";
			targetDtl.AnsGoodsName			= string.Empty;
			targetDtl.GoodsNo				= string.Empty;
			targetDtl.GoodsMakerCd			= 0;
			targetDtl.SalesOrderCount		= 1;
			targetDtl.DeliveredGoodsCount	= 0;
			targetDtl.ListPrice				= 0;
			targetDtl.UnitPrice				= 0;
			targetDtl.ShelfNo				= string.Empty;
			targetDtl.InqOrdDivCd			= 1;
			targetDtl.RecyclePrtKindCode	= 0;
			targetDtl.RecyclePrtKindName	= string.Empty;
			targetDtl.AnswerDeliveryDate	= string.Empty;
			targetDtl.DisplayOrder			= 1;
			targetDtl.EnterpriseCode		= _enterpriseCode;
			targetDtl.CancelCndtinDiv		= 0;
			targetDtl.AcptAnOdrStatus		= 0;
			targetDtl.SalesSlipNum			= "000000000";
			targetDtl.SalesRowNo			= 0;
			targetDtl.DtlTakeinDivCd		= 0;
			targetDtl.PmWarehouseCd			= string.Empty;
			targetDtl.PmWarehouseName		= string.Empty;
			targetDtl.PmShelfNo				= string.Empty;
			targetDtl.PmPrsntCount			= 0;
			targetDtl.SetPartsMkrCd			= 0;
			targetDtl.SetPartsNumber		= string.Empty;
			targetDtl.SetPartsMainSubNo		= 0;
			targetDtl.HandleDivCode			= 0;
			targetDtl.GoodsShape			= 0;
			targetDtl.DelivrdGdsConfCd		= 0;
			targetDtl.DeliGdsCmpltDueDate	= new DateTime(0);
			targetDtl.InqPureGoodsNo		= string.Empty;
			targetDtl.GoodsAddInfo			= string.Empty;
			targetDtl.AnsPureGoodsNo		= string.Empty;
			targetDtl.CommentDtl			= string.Empty;
			targetDtl.AnswerLimitDate		= new DateTime(0);
			targetDtl.GoodsMakerNm			= string.Empty;
			targetDtl.PureGoodsMakerCd		= 0;
			targetDtl.RoughRrofit			= 0;
			targetDtl.RoughRate				= 0;
			targetDtl.AdditionalDivCd		= 0;
			targetDtl.CorrectDivCD			= 0;
			targetDtl.DeliveredGoodsDiv		= 0;
			targetDtl.CampaignCode			= 0;
			targetDtl.GoodsSpecialNote		= string.Empty;
            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            targetDtl.InqBlUtyPtThCd = string.Empty;
            targetDtl.InqBlUtyPtSbCd = 0;
            targetDtl.AnsBlUtyPtThCd = string.Empty;
            targetDtl.AnsBlUtyPtSbCd = 0;
            targetDtl.AnsBLGoodsCode = 0;
            targetDtl.AnsBLGoodsDrCode = 0;
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
			orgDetailRecordList.Add(targetDtl);
			#endregion

			List<ISCMOrderAnswerRecord> orgAnswerRecordList = new List<ISCMOrderAnswerRecord>();

			SCMRespondent autoSCMRespondent = AutoFacade.CreateSCMRespondent(
				AutoFacade.RunningMode.Auto
				, autoReplyHeaderRecordList
				, autoReplyCarRecordList
				, autoReplyDetailRecordList
				, orgAnswerRecordList
				, orgDetailRecordList
				);

			List<string> sendEnterpriseCodeList;
			List<string> sendSectionCodeList;

			// DBに登録無しで自動回答処理を行う
			autoSCMRespondent.WriteFlg = false;
			try
			{
				autoSCMRespondent.Reply(out sendEnterpriseCodeList, out sendSectionCodeList);
			}
			finally
			{
				autoSCMRespondent.WriteFlg = true;
			}

            // --- ADD m.suzuki 2012/04/18 ---------->>>>>
            autoSCMRespondent.ClearSearchResult();
            // --- ADD m.suzuki 2012/04/18 ----------<<<<<
		}
		#endregion
// 2012.04.11 TERASAKA ADD END //////////////////////////////////////////////

        // 2010/03/02 Add >>>
        private void close_Timer_Tick(object sender, EventArgs e)
        {
            // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this._ManualAnswerMode)
            {
                return;
            }
            // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                this.Opacity = this.Opacity - 0.02;
            }
            catch (Exception)
            {
                this.Opacity = 0.0;
            }
            finally
            {
                if (this.Opacity <= 0.0)
                {
                    this.Visible = false;

                    // 透過率を元に戻しておく
                    // 2010/03/09 >>>
                    //this.Opacity = 1.0;
                    this.Opacity = ctFormOpacity;
                    // 2010/03/09 <<<

                    this.close_Timer.Enabled = false;
                    // 2010/04/16 Del >>>
                    //this.display_timer.Enabled = true;
                    this.SetNewestData();
                    // 2010/04/16 Del <<<
                }
            }
        }

        private void display_timer_Tick(object sender, EventArgs e)
        {
            this.display_timer.Enabled = false;
            if (this.SetNewestData())
            {
                this.SetVisibleState(true);
            }
        }

        private void SCMPopupForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        // 2010/03/02 Add <<<


        // 2010/04/16  >>>
        #region 削除
        //// 2010/03/03 Add >>>
        //private string GetCustomerName(string inqOriginalEpCd)
        //{
        //    // 2010/04/16 >>>
        //    //CustomerSearchRet ret = this.GetCustomerFromCustomerEpCode(inqOriginalEpCd);
        //    CustomerSearchRet ret = this.GetCustomerFromCustomerEpCode(inqOriginalEpCd, inqOriginalSecCd);
        //    // 2010/04/16 <<<
        //    if (ret != null)
        //    {
        //        return ret.Snm;
        //    }
        //    else
        //    {
        //        return string.Empty;
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="customerEpCode"></param>
        ///// <returns></returns>
        //private CustomerSearchRet GetCustomerFromCustomerEpCode(string customerEpCode)
        //{
        //    List<CustomerSearchRet> custList = new List<CustomerSearchRet>();
        //    CustomerSearchAcs _customerSearchAcs = new CustomerSearchAcs();
        //    CustomerSearchPara para = new CustomerSearchPara();
        //    para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        //    CustomerSearchRet[] retList;

        //    int status = _customerSearchAcs.Serch(out retList, para);

        //    if (status == 0)
        //    {
        //        custList = new List<CustomerSearchRet>();

        //        custList.AddRange(retList);
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //    if (custList == null || custList.Count == 0) return null;
        //    CustomerSearchRet ret = custList.Find(
        //        delegate(CustomerSearchRet searchRet)
        //        {
        //            // 2010/04/16 >>>
        //            //if (searchRet.CustomerEpCode.Trim() == customerEpCode.Trim()) 
        //            if (searchRet.CustomerEpCode.Trim() == customerEpCode.Trim() &&
        //                searchRet.CustomerSecCode.Trim() == inqOriginalSecCd.Trim())
        //            // 2010/04/16 <<<
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    );
        //    return ret;
        //}
        //// 2010/03/03 Add <<<
        #endregion

        // 2010/12/22 >>>
        ///// <summary>
        ///// 得意先名称取得処理
        ///// </summary>
        ///// <param name="customerCode"></param>
        ///// <returns></returns>
        //private string GetCustomerName(int customerCode)
        //{
        //    if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

        //    CustomerInfo cust;

        //    int status = _customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out cust);

        //    if (status == 0 && cust!=null)
        //    {
        //        return cust.CustomerSnm;
        //    }
        //    else
        //    {
        //        return string.Empty;
        //    }
        //}

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private CustomerInfo GetCustomerInfo(int customerCode)
        {
            if (_customerInfoAcs == null) _customerInfoAcs = new CustomerInfoAcs();

            CustomerInfo cust;

            int status = _customerInfoAcs.ReadDBData(LoginInfoAcquisition.EnterpriseCode, customerCode, out cust);

            if (status == 0 && cust != null)
            {
                return cust;
            }
            else
            {
                return new CustomerInfo();
            }
        }

        // 2010/12/22 <<<
        // 2010/04/16 <<<



        // 2010/04/16 Del >>>
        #region 削除

        //// 2010/03/09 Add >>>
        ///// <summary>
        ///// ×ボタンのクリックイベント
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Close_uButton_Click(object sender, EventArgs e)
        //{
        //    this.close_Timer.Enabled = true;
        //}

        ////マウスのクリック位置を記憶
        //private Point mousePoint;

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void common_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (( e.Button & MouseButtons.Left ) == MouseButtons.Left)
        //    {
        //        //位置を記憶する
        //        mousePoint = new Point(e.X, e.Y);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void common_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (( e.Button & MouseButtons.Left ) == MouseButtons.Left)
        //    {
        //        this.Location = new Point(
        //            this.Location.X + e.X - mousePoint.X,
        //            this.Location.Y + e.Y - mousePoint.Y);
        //    }
        //}
        #endregion
        // 2010/04/16 Del <<<

        // 2010/04/16 Add >>>
        /// <summary>
        /// 画面 Paintイベント（ダブルバッファリングにより、画面サイズ変更時に発生する）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SCMPopupForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //たてに白から黒へのグラデーションのブラシを作成
            //g.VisibleClipBoundsは表示クリッピング領域に外接する四角形
            LinearGradientBrush gb = new LinearGradientBrush(
                    panel_Info.Bounds,
                    Color.Black,
                    Color.Gray,
                    LinearGradientMode.Vertical);

            // 四角を描く
            g.FillRectangle(gb, panel_Info.Bounds);
            gb.Dispose();
            g.Dispose();
        }

        /// <summary>
        /// 表示する文字列の生成
        /// </summary>
        /// <param name="scmodrdata"></param>
        /// <returns></returns>
        // 2010/12/22 >>>
        //private string CreateDisplayString(ISCMOrderHeaderRecord scmodrdata)
        private string CreateDisplayString(ISCMOrderHeaderRecord scmodrdata, CustomerInfo customerInfo)
        // 2010/12/22 <<<
        {
            // 2010/12/22 >>>
            //string name = this.GetCustomerName(scmodrdata.CustomerCode);
            string name = customerInfo.CustomerSnm;
            // 2010/12/22 <<<
            // 2010/04/28 >>>
            //return string.Format("{0}　{1}：{2,9}", SubStringOfByteLeft(name, 20), ( scmodrdata.InqOrdDivCd == 1 ) ? "問合せ" : "発注　", scmodrdata.InquiryNumber);
            string orderName = (scmodrdata.InqOrdDivCd == 1) ? "問合せ　　" : "発注　　　";
            // DEL 2010/06/17 キャンセル分の判断方式を変更 ---------->>>>>
            //if (scmodrdata.AnswerDivCd == 99) orderName = "キャンセル";
            // DEL 2010/06/17 キャンセル分の判断方式を変更 ----------<<<<<
            // ADD 2010/06/17 キャンセル分の判断方式を変更 ---------->>>>>
            // 「キャンセル区分」…0:キャンセルなし/1:キャンセルあり
            if (scmodrdata.CancelDiv == 1) orderName = "キャンセル";
            // ADD 2010/06/17 キャンセル分の判断方式を変更 ----------<<<<<
            return string.Format("{0}　{1}：{2,9}", SubStringOfByteLeft(name, 20), orderName, scmodrdata.InquiryNumber);
            // 2010/04/28 <<<
        }

        /// <summary>
        /// 文字列　バイト数指定切り抜き（Left [12345]678→12345）
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        private static string SubStringOfByteLeft(string orgString, int byteCount)
        {
            Encoding _sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = _sjisEnc.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            int nowlength = _sjisEnc.GetByteCount(resultString);
            if (nowlength < byteCount)
            {
                for (int x = 0; x < byteCount - nowlength; x++)
                {
                    resultString += " ";
                }
            }

            return resultString;
        }


        /// <summary>
        /// MouseLeaveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Data_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// MouseMoveイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Data_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hti = this.dataGridView_Data.HitTest(e.X, e.Y);
            // 2010/04/28 Add >>>
            int orgRowIndex = (this.dataGridView_Data.CurrentCell != null) ? this.dataGridView_Data.CurrentCell.RowIndex : -1;
            int orgColIndex = (this.dataGridView_Data.CurrentCell != null) ? this.dataGridView_Data.CurrentCell.ColumnIndex : -1;
            // 2010/04/28 Add <<<
            if (hti.Type == DataGridViewHitTestType.Cell && hti.RowIndex >= 0 && hti.ColumnIndex >= 0)
            {
                this.dataGridView_Data.CurrentCell = this.dataGridView_Data[hti.ColumnIndex, hti.RowIndex];
            }

            if (hti.RowIndex >= 0 && hti.ColumnIndex >= 0)
            {
                // 2010/12/22 >>>
                //// 2010/04/28 Add >>>
                ////this.Cursor = Cursors.Hand;
                //// DEL 2010/06/17 キャンセル分の判断方式を変更 ---------->>>>>
                ////if (( (ISCMOrderHeaderRecord)this.dataGridView_Data.Rows[hti.RowIndex].Cells[ctColumnName_Data].Value ).AnswerDivCd == 99)
                //// DEL 2010/06/17 キャンセル分の判断方式を変更 ----------<<<<<
                //// ADD 2010/06/17 キャンセル分の判断方式を変更 ---------->>>>>
                //// 「キャンセル区分」…0:キャンセルなし/1:キャンセルあり
                //if (((ISCMOrderHeaderRecord)this.dataGridView_Data.Rows[hti.RowIndex].Cells[ctColumnName_Data].Value).CancelDiv == 1)
                //// ADD 2010/06/17 キャンセル分の判断方式を変更 ----------<<<<<
                //{
                //    this.Cursor = Cursors.Default;
                //}
                //else
                //{
                //    this.Cursor = Cursors.Hand;
                //}
                //// 2010/04/28 Add <<<

                this.Cursor = Cursors.Hand;
                // 2010/12/22 <<<
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        // ------------------ ADD 2013/04/26 qijh #35272 -------------- >>>>>
        /// <summary>
        /// SCMデータ検索用のパラメータを取得
        /// </summary>
        /// <param name="scmOdrData">SCM受発注データレコード</param>
        /// <returns>SCMデータ検索用のパラメータ</returns>
        private SCMInquiryOrder GetScmSearchCond(ISCMOrderHeaderRecord scmOdrData)
        {
            SCMInquiryOrder scmInquiryOrder = new SCMInquiryOrder();

            // 企業・拠点・問合せ番号
            scmInquiryOrder.EnterpriseCode = scmOdrData.InqOtherEpCd;
            scmInquiryOrder.InqOtherEpCd = scmOdrData.InqOtherEpCd; // 問合せ先企業コード
            scmInquiryOrder.InqOtherSecCd = scmOdrData.InqOtherSecCd; // 問合せ先拠点コード
            scmInquiryOrder.InqOriginalEpCd = scmOdrData.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            scmInquiryOrder.InqOriginalSecCd = scmOdrData.InqOriginalSecCd; // 問合せ元拠点コード
            scmInquiryOrder.St_InquiryNumber = scmOdrData.InquiryNumber; // 問合せ番号(開始)
            scmInquiryOrder.Ed_InquiryNumber = scmOdrData.InquiryNumber; // 問合せ番号(終了)

            // 問合せ・発注種別
            List<Int32> inqOrdDivList = new List<int>();
            inqOrdDivList.Add(scmOdrData.InqOrdDivCd);
            scmInquiryOrder.InqOrdDivCd = inqOrdDivList.ToArray();

            // 回答区分
            List<Int32> answerDivList = new List<int>();
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Non);
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Part);
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Complete);
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Cancel);
            scmInquiryOrder.AnswerDivCd = answerDivList.ToArray();

            // 回答方法
            List<Int32> answerMethodList = new List<int>();
            answerMethodList.AddRange(new Int32[] {(int)SCMInquiryOrder.AnswerMethodState.Auto ,
                                                    (int)SCMInquiryOrder.AnswerMethodState.ManualWeb ,
                                                    (int)SCMInquiryOrder.AnswerMethodState.ManualOther});
            scmInquiryOrder.AwnserMethod = answerMethodList.ToArray();

            // 受注ステータス
            List<Int32> acptAnOdrStatusList = new List<int>();
            acptAnOdrStatusList.AddRange(new Int32[] { (int)SCMInquiryOrder.AcptAnOdrStatusState.NotSet ,
                                                    (int)SCMInquiryOrder.AcptAnOdrStatusState.Estimate ,
                                                    //(int)SCMInquiryOrder.AcptAnOdrStatusState.Accept ,  // DEL 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722 新着表示不具合対応
                                                    (int)SCMInquiryOrder.AcptAnOdrStatusState.Sales});
            scmInquiryOrder.AcptAnOdrStatus = acptAnOdrStatusList.ToArray();

            // 連携対象区分
            List<Int16> cooperationOptionDivList = new List<Int16>();
            cooperationOptionDivList.AddRange(new Int16[] {(int)SCMInquiryOrder.CooperationOptionDivState.PCCNS ,
                                                    (int)SCMInquiryOrder.CooperationOptionDivState.BL});
            scmInquiryOrder.CooperationOptionDiv = cooperationOptionDivList.ToArray();

            return scmInquiryOrder;
        }

        /// <summary>
        /// 選択された問合せ回答済みかをチェック
        /// </summary>
        /// <returns>true:未回答、false:回答済</returns>
        private bool CheckAnsStatus(ISCMOrderHeaderRecord scmOdrData)
        {
            if (null == scmOdrData)
                return true; // 処理できない場合、本メソッドを無視

            try
            {
                // SCMデータを取得
                SCMInquiryOrderAcs scmInquiryOrderAcs = SCMInquiryOrderAcs.GetInstance();
                string errMsg;
                int status = scmInquiryOrderAcs.Search(GetScmSearchCond(scmOdrData), out errMsg);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || scmInquiryOrderAcs.SCMInquiryResultDataTable.Rows.Count <= 0)
                    return true;

                // 回答済みかをチェック
                if (20 == Convert.ToInt32(scmInquiryOrderAcs.SCMInquiryResultDataTable.Rows[0][scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName]))
                {
                    // 回答済みの場合
                    TMsgDisp.Show(
                                   this,
                                   emErrorLevel.ERR_LEVEL_INFO,
                                   this.Name,
                                   "すでに回答が完了しています",
                                   0,
                                   MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    // 以外は既存の処理を続ける
                    return true;
                }
            }
            catch
            {
                return true; // 本メソッドを無視
            }
        }
        // ------------------ ADD 2013/04/26 qijh #35272 -------------- <<<<<

        /// <summary>
        /// CellClickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // --- ADD 2014/10/28 T.Miyamoto システムテスト障害一覧№3 -------------------->>>>>
            SoundStop(); //消音
            // --- ADD 2014/10/28 T.Miyamoto システムテスト障害一覧№3 --------------------<<<<<

            if (_loading) return;   // 2011/02/25 Add
            if (e.RowIndex >= 0)
            {
                if (Program.PM7Mode)
                {
                    // SCM問合せ一覧を起動
                    Process.Start(SCM_PM7_EXE_NAME, "");
                }
                else
                {
                    // 2010/12/22 >>>
#if false
                    //// 2010/04/28 Del >>>
                    //ISCMOrderHeaderRecord scmOdrData = (ISCMOrderHeaderRecord)dataGridView_Data[ctColumnName_Data, e.RowIndex].Value;

                    //// DEL 2010/06/17 キャンセル分の判断方式を変更 ---------->>>>>
                    ////if (scmOdrData.AnswerDivCd == 99) return;
                    //// DEL 2010/06/17 キャンセル分の判断方式を変更 ----------<<<<<
                    //// ADD 2010/06/17 キャンセル分の判断方式を変更 ---------->>>>>
                    //// 「キャンセル区分」…0:キャンセルなし/1:キャンセルあり
                    //if (scmOdrData.CancelDiv == 1) return;
                    //// ADD 2010/06/17 キャンセル分の判断方式を変更 ----------<<<<<
                    //// 2010/04/28 Del <<<

                    //string programPath = Path.Combine(Directory.GetCurrentDirectory(), SCM_NS_ENTRY_EXE_NAME);
                    //if (!File.Exists(programPath)) return;

                    //// ログインパラメータ情報を設定
                    ////>>>2010/07/14
                    ////StringBuilder loginArguments = new StringBuilder();
                    ////{
                    ////    foreach (string argument in CommandLineArgs)
                    ////    {
                    ////        if (!string.IsNullOrEmpty(argument.Trim()))
                    ////        {
                    ////            loginArguments.Append(argument + " ");
                    ////        }
                    ////    }
                    ////}

                    //int iCnt = 0;
                    //StringBuilder loginArguments = new StringBuilder();
                    //{
                    //    foreach (string argument in CommandLineArgs)
                    //    {
                    //        if (iCnt >= 2) break;
                    //        if (!string.IsNullOrEmpty(argument.Trim()))
                    //        {
                    //            iCnt++;
                    //            loginArguments.Append(argument + " ");
                    //        }
                    //    }
                    //}
                    ////<<<2010/07/14

                    //// 2010/04/28 Del >>>
                    ////ISCMOrderHeaderRecord scmOdrData = (ISCMOrderHeaderRecord)dataGridView_Data[ctColumnName_Data, e.RowIndex].Value;
                    //// 2010/04/28 Del <<<

                    //if (scmOdrData != null)
                    //{
                    //    loginArguments.Append("/SCM" + " ");
                    //    loginArguments.Append(scmOdrData.InquiryNumber.ToString() + ",");
                    //    loginArguments.Append(0.ToString() + ",");
                    //    loginArguments.Append("000000000" + ",");
                    //    loginArguments.Append(scmOdrData.InqOriginalEpCd + ",");
                    //    loginArguments.Append(scmOdrData.InqOriginalSecCd + ",");
                    //    loginArguments.Append(scmOdrData.InqOrdDivCd.ToString() + ",");
                    //    loginArguments.Append(scmOdrData.AnswerDivCd.ToString() + " ");
                    //}

                    //// SCM問合せ一覧を起動
                    //Process.Start(programPath, loginArguments.ToString());
                    //// 2010/11/17 Add >>>
                    //// 売上伝票入力を起動したデータは画面上から消す
                    //Guid dataGuid = (Guid)dataGridView_Data[ctColumnName_Guid, e.RowIndex].Value;
                    //// 2010/11/17 Add <<<
                    //DataRow dr = this._dataTable.Rows.Find(dataGuid);
                    //if (dr != null)
                    //{
                    //    this._dataTable.Rows.Remove(dr);
                    //}
                    //this.SetNewestData();
#endif

                    // 選択したデータを取得
                    ISCMOrderHeaderRecord scmOdrData = (ISCMOrderHeaderRecord)dataGridView_Data[ctColumnName_Data, e.RowIndex].Value;
                    // データのGuidを取得
                    string datakey = (string)dataGridView_Data[ctColumnName_KEY, e.RowIndex].Value;
                    bool executeEntry = true;

                    // キャンセルデータの場合、先にダイアログを表示する
                    if (scmOdrData.CancelDiv == 1)
                    {
                        PMSCM00005UD frm = new PMSCM00005UD();
						#region 2012.04.11 TERASAKA DEL STA
//						object obj;
						#endregion
						DialogResult ret = frm.ShowDialog(this, this.Terminal, scmOdrData, (CustomerInfo)dataGridView_Data[ctColumnName_CustomerInfo, e.RowIndex].Value);

                        if (ret == DialogResult.Yes)
                        {
                        }
                        else
                        {
                            executeEntry = false;
                        }
                    }

                    if (executeEntry)
                    {
                        string programPath = Path.Combine(Directory.GetCurrentDirectory(), SCM_NS_ENTRY_EXE_NAME);
                        if (!File.Exists(programPath)) return;

                        // ログインパラメータ情報を設定
                        int iCnt = 0;
                        StringBuilder loginArguments = new StringBuilder();
                        {
                            foreach (string argument in CommandLineArgs)
                            {
                                if (iCnt >= 2) break;
                                if (!string.IsNullOrEmpty(argument.Trim()))
                                {
                                    iCnt++;
                                    loginArguments.Append(argument + " ");
                                }
                            }
                        }
                        if (scmOdrData != null)
                        {
                            loginArguments.Append("/SCM" + " ");
                            loginArguments.Append(scmOdrData.InquiryNumber.ToString() + ",");
                            loginArguments.Append(0.ToString() + ",");
                            loginArguments.Append("000000000" + ",");
                            loginArguments.Append(scmOdrData.InqOriginalEpCd.Trim() + ",");//@@@@20230303_
                            // zhouzy update 20110920 begin
                            //loginArguments.Append(scmOdrData.InqOriginalSecCd + ",");
                            loginArguments.Append(scmOdrData.InqOriginalSecCd.TrimEnd() + ",");
                            // zhouzy update 20110920 end
                            loginArguments.Append(scmOdrData.InqOrdDivCd.ToString() + ",");
                            // 2011/02/18 >>>
                            //loginArguments.Append(scmOdrData.AnswerDivCd.ToString() + " ");
                            loginArguments.Append(scmOdrData.CancelDiv.ToString() + " ");
                            // 2011/02/18 <<<
                        }

                        // DEL 2013/06/03 吉岡 2013/06/18配信 SCM障害№234(#35272)マージ漏れ --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// SCM問合せ一覧を起動
                        //Process.Start(programPath, loginArguments.ToString());
                        #endregion
                        // DEL 2013/06/03 吉岡 2013/06/18配信 SCM障害№234(#35272)マージ漏れ ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        // SCM問合せ一覧を起動
                        //Process.Start(programPath, loginArguments.ToString()); // DEL 2013/04/26 qijh #35272
                        // ------------------ ADD 2013/04/26 qijh #35272 -------------- >>>>>
                        if (CheckAnsStatus(scmOdrData))
                            Process.Start(programPath, loginArguments.ToString());
                        // ------------------ ADD 2013/04/26 qijh #35272 -------------- <<<<<
                    }

                    LogWriter.LogWrite("dataGridView_Data_CellClick() ⇒ 関連のPM端末への返答送信処理 開始 問合せ番号:" + scmOdrData.InquiryNumber);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                    // 指定或いは関連のPM端末への返答送信処理
                    // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
                    //this.NotifyPmByPublish(scmOdrData.InquiryNumber);// ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応
                    int retryCount = 0;
                    this.NotifyPmByPublish(scmOdrData.InquiryNumber, ref retryCount);
                    // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
                    LogWriter.LogWrite("dataGridView_Data_CellClick() ⇒ 関連のPM端末への返答送信処理 終了");// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                    
                    this.RemoveData(datakey);
                    this.SetNewestData();
                    #region Del 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応
                    //// --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする --->>>
                    //int count = 0;
                    //if (this._dataTable.Rows.Count >= 5)
                    //{
                    //    count = 5;
                    //}
                    //else
                    //{
                    //    count = this._dataTable.Rows.Count;
                    //}
                    //if (this._visbleFlg && this.bottom_Panel.Visible)
                    //{
                    //    this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count) + 50;
                    //    // UPD 2012/07/19 システムテスト障害No.113 --------------------------------------------->>>>>
                    //    //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count + 1);
                    //    // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //    //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                    //    if (this._ManualAnswerMode)
                    //    {
                    //        this.lblInformation.Text = MSG_MANUAL_MODE;
                    //    }
                    //    else
                    //    {
                    //        this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                    //    }
                    //    // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    //    // UPD 2012/07/19 システムテスト障害No.113 ---------------------------------------------<<<<<
                    //}
                    //// --- Add 2011/07/28 duzg for Redmine#23241対応 --->>>
                    //else
                    //    this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count);
                    //// --- Add 2011/07/28 duzg for Redmine#23241対応 ---<<<
                    //// --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする ---<<<
                    //if (this.dataGridView_Data.Rows.Count == 0)
                    //{
                    //    //this.Visible = false;// Del 2011/07/28 duzg for Redmine#23241
                    //    // --- Add 2011/07/28 duzg for Redmine#23241 --->>>
                    //    if (this._visbleFlg && this.bottom_Panel.Visible)
                    //    // UPD 2012/07/19 システムテスト障害No.113 --------------------------------------------->>>>>
                    //        //this.Visible = true;
                    //    {
                    //        // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //        //this.lblInformation.Text = MSG_AUTO_ANSWER;
                    //        if (this._ManualAnswerMode)
                    //        {
                    //            this.lblInformation.Text = MSG_MANUAL_MODE;
                    //        }
                    //        else
                    //        {
                    //            this.lblInformation.Text = MSG_AUTO_ANSWER;
                    //        }
                    //        // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    //        this.Visible = true;
                    //    }
                    //    // UPD 2012/07/19 システムテスト障害No.113 ---------------------------------------------<<<<<
                    //    else
                    //        // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //        //this.Visible = false;
                    //        SetVisibleState(this._ManualAnswerMode);
                    //    // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    //    // --- Add 2011/07/28 duzg for Redmine#23241 ---<<<
                    //}
                    //// 2010/12/22 <<<
                    #endregion

                    // 画面再度調整
                    this.ResetLayout();// ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応
                }
            }
        }

        // 2010/12/22 Add >>>
        /// <summary>
        /// データリストから指定したデータを削除します
        /// </summary>
        /// <param name="dataguid"></param>
        private void RemoveData(string dataKey)
        {
            DataRow dr = this._dataTable.Rows.Find(dataKey);
            if (dr != null)
            {
                this._dataTable.Rows.Remove(dr);
            }
        }
        // 2010/12/22 Add <<<

        // 2010/04/16 Add <<<
        // --- ADD m.suzuki 2010/07/30 ---------->>>>>
        /// <summary>
        /// 定期チェック実行タイマー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_timer_Tick(object sender, EventArgs e)
        {
            // --- ADD 2014/10/01 T.Miyamoto ------------------------------>>>>>
            if (Broadleaf.Windows.Forms.Program.ExceptionFlg)
            {
                check_timer.Enabled = false;
                return;
            }
            // --- ADD 2014/10/01 T.Miyamoto ------------------------------<<<<<

            // --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする --->>>
            AppSettingsSection appSettingSection = GetAppSettingsSection();

            if (appSettingSection.Settings[CT_Conf_AutoAnswerView].Value.Equals("1"))
                this._visbleFlg = true;
            else
                this._visbleFlg = false;
            // --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする ---<<<

            // POPUP表示
            this.ShowPopup(this, new ReceivedEventArgs());
        }
        // --- ADD m.suzuki 2010/07/30 ----------<<<<<

        //>>>2010/08/04
        /// <summary>
        /// 起動パラメータ取得処理(エントリメイン画面でデリゲートで使用)
        /// </summary>
        /// <param name="param"></param>
        private void GetStartParameter(out string param)
        {
            if (this._commandLineArgs.Length != 0)
            {
                param = this._commandLineArgs[0] + " " + this._commandLineArgs[1];
            }
            else
            {
                param = string.Empty;
            }
        }
        //<<<2010/08/04

        // 2010/11/17 Add >>>
        /// <summary>
        /// TableへのRow追加
        /// </summary>
        /// <param name="scmodrdata"></param>
        private void AddDataRow(ISCMOrderHeaderRecord scmodrdata)
        {
            string dataKey = this.DataToKey(scmodrdata);
            DataRow dr = this._dataTable.Rows.Find(dataKey);
            if (dr == null)
            {
                // UPD 2012/07/23 T.Yoshioka 2012/08/07配信 障害№115 ------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                dr = this._dataTable.NewRow();
                dr[ctColumnName_KEY] = dataKey;
                this._dataTable.Rows.Add(dr);// Add 2011/08/19 duzg for Redmine#23241対応
                //if (string.IsNullOrEmpty(this._dataKey) || !this._dataKey.Equals(dataKey))  // ADD 2011/10/10
                //{
                //    dr = this._dataTable.NewRow();
                //    dr[ctColumnName_KEY] = dataKey;
                //    this._dataTable.Rows.Add(dr);// Add 2011/08/19 duzg for Redmine#23241対応
                //}
                // UPD 2012/07/23 T.Yoshioka 2012/08/07配信 障害№115 -------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            // 2010/12/22 Add >>>
            //dr[ctColumnName_Display] = this.CreateDisplayString(scmodrdata);

            dr[ctColumnName_CustomerInfo] = this.GetCustomerInfo(scmodrdata.CustomerCode);
            dr[ctColumnName_Display] = this.CreateDisplayString(scmodrdata, (CustomerInfo)dr[ctColumnName_CustomerInfo]);
            // 2010/12/22 Add <<<

            dr[ctColumnName_Data] = scmodrdata;
            dr[ctColumnName_UpdateDate] = scmodrdata.UpdateDate;
            dr[ctColumnName_UpdateTime] = scmodrdata.UpdateTime;
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
            dr[ctColumnName_DateTime] = DateTime.Now.ToString();
            // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<

            //this._dataTable.Rows.Add(dr);// Del 2011/08/19 duzg for Redmine#23241対応
            this._dataKey = dataKey; // ADD 2011/10/10
        }

        /// <summary>
        /// データ→キーに変換します
        /// </summary>
        /// <param name="scmodrdata"></param>
        /// <returns></returns>
        private string DataToKey(ISCMOrderHeaderRecord scmodrdata)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
                scmodrdata.InqOriginalEpCd.Trim(), //@@@@20230303
                scmodrdata.InqOriginalSecCd,
                scmodrdata.InqOtherEpCd,
                scmodrdata.InqOtherSecCd,
                scmodrdata.InquiryNumber,
                scmodrdata.InqOrdDivCd,
                scmodrdata.CancelDiv);
        }
        // 2010/11/17 Add <<<

        // 2011/02/25 >>>
        /// <summary>
        /// 回答済み明細を削除します。
        /// </summary>
        /// <param name="answerdDataList"></param>
        private void RemoveAnswerdRow(List<ISCMOrderHeaderRecord> answeredDataList)
        {
            if (this._dataTable.Rows.Count == 0) return;

            List<string> deleteDataList = new List<string>();
            foreach (DataRow row in this._dataTable.Rows)
            {
                ISCMOrderHeaderRecord target = (ISCMOrderHeaderRecord)row[ctColumnName_Data];
                ISCMOrderHeaderRecord answer = answeredDataList.Find(
                    delegate(ISCMOrderHeaderRecord data)
                    {
                        if ((target.InqOriginalEpCd.Trim().Equals(data.InqOriginalEpCd.Trim())) &&
                            (target.InqOriginalSecCd.Trim().Equals(data.InqOriginalSecCd.Trim())) &&
                            (target.InqOtherEpCd.Trim().Equals(data.InqOtherEpCd.Trim())) &&
                            (target.InqOtherSecCd.Trim().Equals(data.InqOtherSecCd.Trim())) &&
                            (target.InquiryNumber.Equals(data.InquiryNumber)) &&
                            (target.InqOrdDivCd.Equals(data.InqOrdDivCd)) &&
                            (target.CancelDiv.Equals(data.CancelDiv)))
                        {
                            if ((target.UpdateDate < data.UpdateDate) ||
                                ((target.UpdateDate == data.UpdateDate) && (target.UpdateTime < data.UpdateTime)))
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    );
                if (answer != null) deleteDataList.Add((string)row[ctColumnName_KEY]);
            }
            if (deleteDataList.Count > 0)
            {
                foreach (string key in deleteDataList)
                {
                    this.RemoveData(key);
                }
            }
        }
        // 2011/02/25 <<<

        // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ---------->>>>>
        /// <summary>
        /// 指定或いは関連のPM端末への返答送信処理
        /// </summary>
        /// <param name="inquiryNumber">問い合わせ番号</param>
        /// <param name="retryCount">リトライ回数</param>
        // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
        //private void NotifyPmByPublish(long inquiryNumber)
        private void NotifyPmByPublish(long inquiryNumber, ref int retryCount)
        {
            retryCount++;
            // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
            try
            {
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
                // 指定のPM端末への返答送信処理
                if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) >= PurchaseStatus.Contract)
                {
                    ScmPushData payload = new ScmPushData();
                    payload.NoticeMode = 100;// 新着一覧で回答済みデータを削除する判断モードです
                    payload.InquiryNumber = inquiryNumber;
                    payload.IsReply = false;

                    PublishArgs publishArgs = new PublishArgs();
                    publishArgs.Payload = payload;
                    publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_SFPMSCM, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                    LogWriter.LogWrite("SCMPopupForm.NotifyPmByPublish ⇒ 関連のPM端末への返答送信処理(通常SCM) 送信チャンネル:" + publishArgs.Channel + "問合せ番号:" + inquiryNumber);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                    _scmPushClient.Publish(publishArgs);
                }
                else if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCCUOE) >= PurchaseStatus.Contract)
                {
                    ScmPushData payload = new ScmPushData();
                    payload.NoticeMode = 100;// 新着一覧で選択済みデータを削除する判断モードです
                    payload.InquiryNumber = inquiryNumber;
                    payload.IsReply = false;

                    PublishArgs publishArgs = new PublishArgs();
                    publishArgs.Payload = payload;
                    publishArgs.Channel = string.Format("/{0}/PMNS/{1}/{2}", _scmPushClient.WEBSYNC_CHANNEL_PCCUOE, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                    LogWriter.LogWrite("SCMPopupForm.NotifyPmByPublish ⇒ 関連のPM端末への返答送信処理(BLP) 送信チャンネル:" + publishArgs.Channel + "問合せ番号:" + inquiryNumber);// ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応
                    _scmPushClient.Publish(publishArgs);
                }
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
            }
            catch (Exception ex)
            {
                // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ---------->>>>>
                //LogWriter.LogWrite("SCMPopupForm.NotifyPmByPublish ⇒ WebSync送信処理に失敗しました。" + "\r\n" + "例外内容：" + ex.ToString());
                //throw ex;
                
                LogWriter.LogWrite("SCMPopupForm.NotifyPmByPublish ⇒ 例外内容：" + ex.ToString() + "  リトライ回数：" + retryCount.ToString());
                if (retryCount >= retrySettingInfo.RetryCount)
                {
                    throw ex;
                }
                else
                {
                    Thread.Sleep(retrySettingInfo.RetryInterval);
                    NotifyPmByPublish(inquiryNumber, ref retryCount);
                }
                // --- UPD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
            }
            // --- ADD 2020/07/03 陳艶丹 PMKOBETSU-3926対応 ----------<<<<<
        }

        /// <summary>
        /// 選択済み明細を削除します。
        /// </summary>
        /// <param name="inquiryNumber">問合せ番号</param>
        private void RemoveAnswerdRow(long inquiryNumber)
        {
            if (this._dataTable.Rows.Count == 0) return;

            string deleteKey = string.Empty;
            foreach (DataRow row in this._dataTable.Rows)
            {
                ISCMOrderHeaderRecord target = (ISCMOrderHeaderRecord)row[ctColumnName_Data];
                if (target.InquiryNumber == inquiryNumber)
                {
                    deleteKey = (string)row[ctColumnName_KEY];
                    break;
                }
            }
            if (!string.IsNullOrEmpty(deleteKey))
            {
                this.RemoveData(deleteKey);

                this.SetNewestData();

                // 削除後、画面再度調整
                ResetLayout();
            }
        }

        /// <summary>
        /// 新着一覧画面再度調整
        /// </summary>
        private void ResetLayout()
        {
            int count = 0;
            if (this._dataTable.Rows.Count >= 5)
            {
                count = 5;
            }
            else
            {
                count = this._dataTable.Rows.Count;
            }
            if (this._visbleFlg && this.bottom_Panel.Visible)
            {
                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count) + 50;

                if (this._ManualAnswerMode)
                {
                    this.lblInformation.Text = MSG_MANUAL_MODE;
                }
                else
                {
                    this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                }
            }
            else
                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count);

            if (this.dataGridView_Data.Rows.Count == 0)
            {
                if (this._visbleFlg && this.bottom_Panel.Visible)
                {
                    if (this._ManualAnswerMode)
                    {
                        this.lblInformation.Text = MSG_MANUAL_MODE;
                    }
                    else
                    {
                        this.lblInformation.Text = MSG_AUTO_ANSWER;
                    }
                    this.Visible = true;
                }
                else
                    SetVisibleState(this._ManualAnswerMode);
            }
        }
        // --- ADD 2014/09/22 chenyd For PM-SCM仕掛一覧No.10661とNo.85対応 ----------<<<<<

        // 2011/05/27 Add >>>
        /// <summary>
        /// SCMデモ用設定ファイルを読込みます
        /// </summary>
        /// <param name="receiveTime"></param>
        /// <returns></returns>
        private int GetSCMDemoSettings(out int receiveTime)
        {
            int status = 0;
            receiveTime = 0;
            string filePass = System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, "SCMDemoSetting.xml");
            object obj = LoadFromBinaryFile(filePass);
            if (obj == null)
            {
                // ファイルが存在しない場合はSCM全体設定参照
                status = 1;
            }
            else
            {
                try
                {
                    receiveTime = (int)obj;
                }
                catch
                {
                    // 念の為、数値型以外の値がセットされていたらSCM全体設定参照
                    status = 1;
                    receiveTime = 0;
                }
            }
            // 0がセットされていたらSCM全体設定参照
            if (receiveTime == 0)
                status = 1;

            return status;
        }

        /// <summary>
        /// 読込処理
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private object LoadFromBinaryFile(string path)
        {
            object obj = null;
            try
            {
                FileStream fs = new FileStream(path,
                    FileMode.Open,
                    FileAccess.Read);
                BinaryFormatter f = new BinaryFormatter();
                //読み込んで逆シリアル化する
                obj = f.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                obj = null;
            }

            return obj;
        }
        // 2011/05/27 Add <<<

        // --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする設定 --->>>
        /// <summary>
        /// [設定]メニューアイテムのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == _form)
            {
                this._form = new PMSCM00005UF();
            }
            this._form.Owner = this;
            
            this._form.ShowDialog();

            //-----ADD 2011/09/29----->>>>>
            this.SetNewestData();

            AppSettingsSection appSettingSection = GetAppSettingsSection();

            int count = 0;
            if (this._dataTable.Rows.Count >= 5)
            {
                count = 5;
            }
            else
            {
                count = this._dataTable.Rows.Count;
            }

            if (appSettingSection.Settings[CT_Conf_AutoAnswerView].Value.Equals("1"))
            {
                this._visbleFlg = true;
                this.bottom_Panel.Visible = true;
                if (this._visbleFlg && bottom_Panel.Visible)
                {
                    // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count + 1);
                    if (this._ManualAnswerMode)
                    {
                        this.lblInformation.Text = MSG_MANUAL_MODE;
                    }
                    else
                    {
                        this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count + 1);
                    }
                    // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                }
                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count) + 50;
            }
            else
            {
                // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //this._visbleFlg = false;
                //this.bottom_Panel.Visible = false;
                //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                if (this._ManualAnswerMode)
                {
                    this.lblInformation.Text = MSG_MANUAL_MODE;
                }
                else
                {
                    this._visbleFlg = false;
                    this.bottom_Panel.Visible = false;
                    this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                }
                // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                this.Height = ctDefaultFormHeight + (this.dataGridView_Data.RowTemplate.Height * count);
            }
            //-----ADD 2011/09/29-----<<<<<
        }

        // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ---------->>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// [更新]メニューアイテムのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 新しいプロセスの起動
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                // UPD 2012/08/24 2012/09/12配信システムテスト障害№17対応 ------------------>>>>> 
                //process.StartInfo.FileName = "r:\\sfnetasm\\PMSCM00005U.exe";
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), CT_Conf_ExeFileName);
                process.StartInfo.FileName = fileName;
                // UPD 2012/08/24 2012/09/12配信システムテスト障害№17対応 ------------------<<<<< 
                // コマンドライン引数の数を3個に設定（タスクのパトランプアイコン右クリックメニューの"更新"）
                // UPD 2012/09/11 T.Yoshioka SCM障害№10365対応 ---------->>>>>>>>>>>>>>>>>>
                process.StartInfo.Arguments = Program.argsSave[0] + " " + Program.argsSave[1] + " " + Program.RIGHTCLICK;
                //process.StartInfo.Arguments = Program.argsSave[0] + " " + Program.argsSave[1] + " rightClick";
                // UPD 2012/09/11 T.Yoshioka SCM障害№10365対応 ----------<<<<<<<<<<<<<<<<<
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CanClose = true;
            Close();

            //patoLampNotifyIcon.Dispose();
            //System.Diagnostics.Process wPs = System.Diagnostics.Process.GetProcessById(System.Diagnostics.Process.GetCurrentProcess().Id);
            //System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            //// ComSpec（cmd.exe）のパスを取得
            //psi.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
            //// ウィンドウを表示しないようにする
            //psi.CreateNoWindow = true;
            //// ウィンドウを非表示に
            //psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            //// コマンドラインを指定（"/c"は実行後閉じるために必要） /t:通常終了（タスクバーのアイコン消去）
            //psi.Arguments = @"/C taskkill /t /pid " + wPs.Id.ToString();
            //// 起動（コマンド実行）
            //System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
            //p.WaitForExit();

            //// コマンドラインを指定（"/c"は実行後閉じるために必要）/f:強制終了（上記通常終了だとプロセスが終了されない）
            //psi.Arguments = @"/C taskkill /f /pid " + wPs.Id.ToString();
            //// 起動（コマンド実行）
            //p = System.Diagnostics.Process.Start(psi);
            //p.WaitForExit();

        }
        // ADD 2012/08/23 T.Yoshioka 2012/09/12配信システム障害№4 対応 ----------<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// [切替]メニューアイテムのClickイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Configuration.ExeConfigurationFileMap file = new System.Configuration.ExeConfigurationFileMap();

            file.ExeConfigFilename = Exe_Conf_Filename;
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(file, System.Configuration.ConfigurationUserLevel.None);
            System.Configuration.AppSettingsSection appSettingSection = (System.Configuration.AppSettingsSection)config.GetSection(App_Set_Section);
            if (appSettingSection.Settings[CT_Conf_AnswerMode] == null)
            {
                config.AppSettings.Settings.Add(CT_Conf_AnswerMode, "0");
            }
            if (appSettingSection.Settings[CT_Conf_AnswerMode].Value.Equals("0"))
            {
                appSettingSection.Settings[CT_Conf_AnswerMode].Value = "1";
                ConfigurationManager.AppSettings[CT_Conf_AnswerMode] = "1";
                _ManualAnswerMode = true;
                this.lblInformation.Text = MSG_MANUAL_MODE;
            }
            else
            {
                appSettingSection.Settings[CT_Conf_AnswerMode].Value = "0";
                ConfigurationManager.AppSettings[CT_Conf_AnswerMode] = "0";
                _ManualAnswerMode = false;
                if (this._dataTable.Rows.Count > 0)
                {
                    this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                }
                else
                {
                    this.lblInformation.Text = MSG_NO_NEW_ORDER;
                }
            }
            config.Save(System.Configuration.ConfigurationSaveMode.Modified);
            SetVisibleState(_ManualAnswerMode);
        }
        // --- ADD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 画面Visible変更イベント処理
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 画面表示処理を行います。</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private void SCMPopupForm_VisibleChanged(object sender, EventArgs e)
        {
            AppSettingsSection appSettingSection = GetAppSettingsSection();

            if (appSettingSection.Settings[CT_Conf_AutoAnswerView].Value.Equals("1"))
                this._visbleFlg = true;
            else
                this._visbleFlg = false;
        }

        /// <summary>
        /// ConfigurationSection取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ConfigurationSection取得処理を行います。</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private AppSettingsSection GetAppSettingsSection()
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();

            file.ExeConfigFilename = Exe_Conf_Filename;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(file, ConfigurationUserLevel.None);

            return (AppSettingsSection)config.GetSection(App_Set_Section);
        }

        /// <summary>
        /// 自動回答ラベルクリックイベント処理
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 自動回答ラベルクリック処理を行います。</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private void autoAnswerLabel_Click(object sender, EventArgs e)
        {
            string programPath = Path.Combine(Directory.GetCurrentDirectory(), SCM_ORDER_DATA_VIEWER_EXE_NAME);

            if (!File.Exists(programPath)) return;

            // ログインパラメータ情報を設定
            StringBuilder loginArguments = new StringBuilder();
            {
                foreach (string argument in CommandLineArgs)
                {
                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        loginArguments.Append(argument + " ");
                    }
                }
            }

            loginArguments.Append("AutoAnswerDiv" + " ");
            // SCM問合せ一覧を起動
            Process.Start(programPath, loginArguments.ToString());
            // --- Add 2011/07/28 duzg for Redmine#23241 --->>>
            this.bottom_Panel.Visible = false;
            this.Height = this.Height - this.bottom_Panel.Height;
            // ADD 2012/07/17 システムテスト障害№96 ---------------------------------------------->>>>>
            // 自動回答非表示
            this._autoAnswerDisplay = false;
            // ADD 2012/07/17 システムテスト障害№96 ----------------------------------------------<<<<<

            SetVisibleState(true);
            if (this._dataTable.Rows.Count > 0)
            {
                // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                if (this._ManualAnswerMode)
                {
                    this.lblInformation.Text = MSG_MANUAL_MODE;
                }
                else
                {
                    this.lblInformation.Text = string.Format(MSG_NEW_ORDER, this._dataTable.Rows.Count);
                }
                // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            }
            else
            // UPD 2012/07/17 システムテスト障害№96 --------------------------->>>>>
            //this.lblInformation.Text = MSG_NO_NEW_ORDER;
                // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //this.Visible = false;
                SetVisibleState(this._ManualAnswerMode);
            // --- UPD 2012/08/24 三戸 2012/10月配信予定 SCM障害№10340 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // UPD 2012/07/17 システムテスト障害№96 ---------------------------<<<<<
            // --- Add 2011/07/28 duzg for Redmine#23241 ---<<<
        }

        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 -------------------->>>>>
        /// <summary>
        /// 全てのコントロールでマウスダウンイベントを取得
        /// </summary>
        public void AllControlMouseDownSet(Control hParent)
        {
            // パラメータコントロール内のの全コントロール
            foreach (Control cControl in hParent.Controls)
            {
                // 列挙したコントロールにコントロールが含まれている場合は再帰
                if (cControl.HasChildren == true)
                {
                    AllControlMouseDownSet(cControl);
                }

                // フォームのイベントハンドラを追加
                cControl.MouseClick += new MouseEventHandler(SCMPopupForm_MouseClick);
            }
        }

        /// <summary>
        /// フォームマウスダウンイベント処理
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0xA1;
            //const int HTMINBUTTON = 8;
            //const int HTMAXBUTTON = 9;
            //const int HTCAPTION = 2;
            //const int HTCLOSE = 20;
            if (m.Msg == WM_NCLBUTTONDOWN)
            {
                SoundStop(); //消音
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// フォームマウスクリックイベント処理
        /// </summary>
        private void SCMPopupForm_MouseClick(object sender, MouseEventArgs e)
        {
            SoundStop(); //消音
        }
        // --- ADD 2014/10/17 T.Miyamoto SCM仕掛一覧№82 着信音対応 --------------------<<<<<

        /* --- Del 2011/07/28 duzg for Redmine#23241対応 --->>>
        /// <summary>
        /// システム日付内の自動回答検索条件
        /// </summary>
        /// <remarks>
        /// <br>Note        : システム日付内の自動回答検索条件を設定します</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011/07/18</br>
        /// </remarks>
        private SCMInquiryOrder SetExtraInfo()
        {
            SCMInquiryOrder scmInquiryOrder = new SCMInquiryOrder();
            // 共通ヘッダの企業コード
            scmInquiryOrder.EnterpriseCode = this._enterpriseCode; 

            // 回答区分
            List<Int32> answerDivList = new List<int>();
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Non);
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Part);
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Complete);
            answerDivList.Add((int)SCMInquiryOrder.AnswerDivState.Cancel);

            scmInquiryOrder.AnswerDivCd = answerDivList.ToArray();

            Broadleaf.Library.Windows.Forms.TDateEdit tde_InquiryDateSt = new TDateEdit();
            tde_InquiryDateSt.SetDateTime(DateTime.Today);
            // 問合せ日(開始)
            scmInquiryOrder.St_InquiryDate = tde_InquiryDateSt.GetLongDate();
            // 問合せ日(終了)
            scmInquiryOrder.Ed_InquiryDate = tde_InquiryDateSt.GetLongDate();
            // 問合せ先企業コード
            scmInquiryOrder.InqOtherEpCd = this._enterpriseCode;
            // 問合せ先拠点コード
            scmInquiryOrder.InqOtherSecCd = "01"; 

            // 回答方法
            List<Int32> answerMethodList = new List<int>();
            answerMethodList.Add((int)SCMInquiryOrder.AnswerMethodState.Auto);

            scmInquiryOrder.AwnserMethod = answerMethodList.ToArray();

            // 伝票番号(受注ステータス)
            List<Int32> acptAnOdrStatusList = new List<int>();
            acptAnOdrStatusList.AddRange(new Int32[] { (int)SCMInquiryOrder.AcptAnOdrStatusState.NotSet ,
                                                        (int)SCMInquiryOrder.AcptAnOdrStatusState.Estimate ,
                                                        (int)SCMInquiryOrder.AcptAnOdrStatusState.Accept ,
                                                        (int)SCMInquiryOrder.AcptAnOdrStatusState.Sales});

            scmInquiryOrder.AcptAnOdrStatus = acptAnOdrStatusList.ToArray();

            

            // 問合せ番号(問合せ・発注種別)
            List<Int32> inqOrdDivList = new List<int>();
            inqOrdDivList.AddRange(new Int32[] {(int)SCMInquiryOrder.InqOrdDivState.Estimate ,
                                                        (int)SCMInquiryOrder.InqOrdDivState.Accept});

            scmInquiryOrder.InqOrdDivCd = inqOrdDivList.ToArray();

            return scmInquiryOrder;
        }
         --- Del 2011/07/28 duzg for Redmine#23241対応 ---<<<*/
        // --- Add 2011/07/18 duzg for 自動回答分も画面上にポップアップする設定 ---<<<

        // 2015/06/12 ADD TAKAGAWA 高速化Redmine#3848 ---------->>>>>>>>>>
        /// <summary>
        /// 電源状態変更イベントハンドラ。
        /// 電源状態（スリープ、休止状態、復帰）の変化があった場合に実行。
        /// 復帰したとき、WebSyncチャンネルを再接続するためにInitPushModeメソッドを実行する。
        /// </summary>
        /// <param name="sender">xxxxxx</param>
        /// <param name="e">xxxxxx</param>
        /// <returns>
        /// なし
        /// </returns>
        /// <example>
        /// if (e.Mode == PowerModes.Resume)
        ///     {
        ///         WebSyncチャンネル再接続
        ///     }
        /// </example>
        private void PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            // 電源状態の変更後モードが復帰の場合
            if (e.Mode == PowerModes.Resume)
            {
                // WebSyncチャンネルを再接続
                InitPushMode();
            }
        }
        // 2015/06/12 ADD TAKAGAWA 高速化Redmine#3848 ----------<<<<<<<<<<

    }
    // --- ADD m.suzuki 2010/07/30 ---------->>>>>
    /// <summary>
    /// 新着情報制御クラス
    /// </summary>
    /// <remarks>このクライアントで新着表示すべきデータかどうかを判断する為のクラスです。</remarks>
    internal class NewArrNtfyController
    {
        private PosTerminalMg _posTerminalMg;
        private List<SCMNewArrNtfySt> _scmNewArrNtfyStList;

        //>>>2010/08/04
        public PosTerminalMg PosTerminalMg
        {
            get { return _posTerminalMg; }
        }
        //<<<2010/08/04

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewArrNtfyController()
        {
        }
        /// <summary>
        /// 設定読み込み(全件)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        public void SearchSetting(string enterpriseCode)
        {
            try
            {
                # region [新着表示設定]
                _scmNewArrNtfyStList = null;
                SCMNewArrNtfyStAcs scmNewArrNtfyStAcs = new SCMNewArrNtfyStAcs();

                // マスタ読み込み
                ArrayList al;
                int status = scmNewArrNtfyStAcs.SearchAvailable(out al, enterpriseCode);

                if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 取得結果をリストに退避
                    _scmNewArrNtfyStList = new List<SCMNewArrNtfySt>((SCMNewArrNtfySt[])al.ToArray(typeof(SCMNewArrNtfySt)));
                }
                if (_scmNewArrNtfyStList == null)
                {
                    _scmNewArrNtfyStList = new List<SCMNewArrNtfySt>();
                }
                # endregion

                # region [端末管理設定]
                // 自端末の端末番号を取得
                PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
                status = posTerminalMgAcs.Search(out _posTerminalMg, enterpriseCode);
                # endregion
            }
            catch
            {
            }
        }
        /// <summary>
        /// マッチング判定処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        public bool Match(string enterpriseCode, string sectionCode, int customerCode)
        {
            string allSectionCd = "00";
            List<SCMNewArrNtfySt> retSCMNewArrNtfyStList;

            // 端末管理設定
            if (_posTerminalMg == null)
            {
                return false;
            }

            // 得意先設定／拠点設定／全社設定取得
            # region [新着表示設定]
            if (_scmNewArrNtfyStList == null)
            {
                return false;
            }
            retSCMNewArrNtfyStList = _scmNewArrNtfyStList.FindAll(
                delegate(SCMNewArrNtfySt scmNew)
                {
                    if (((string.IsNullOrEmpty(scmNew.SectionCode.Trim())) && (scmNew.CustomerCode == customerCode)) ||  // 得意先設定
                        ((scmNew.CustomerCode == 0) && (scmNew.SectionCode.Trim() == sectionCode.Trim())) ||      // 拠点設定
                        ((scmNew.CustomerCode == 0) && (scmNew.SectionCode.Trim() == allSectionCd)))            // 全社設定
                    {
                        return true; // 注) Findのreturnなのでメソッドの返却値ではありません
                    }
                    else
                    {
                        return false; // 注) Findのreturnなのでメソッドの返却値ではありません
                    }
                }
            );
            if (retSCMNewArrNtfyStList == null || retSCMNewArrNtfyStList.Count == 0)
            {
                return false;
            }
            # endregion

            // 得意先設定／拠点設定／全社設定取得の どれかの設定であたるならばこのクライアントは対象
            foreach (SCMNewArrNtfySt scmNewArrNtfySt in retSCMNewArrNtfyStList)
            {
                if (scmNewArrNtfySt.CashRegisterNo == _posTerminalMg.CashRegisterNo)
                {
                    // 該当があればtrue
                    return true;
                }
            }
            // 該当が無ければfalse
            return false;
        }
        // ADD 2013/11/26 SCM仕掛一覧№10592対応 ------------------------------------>>>>>
        /// <summary>
        /// マッチング判定処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        public bool Match(string enterpriseCode, string sectionCode)
        {
            string allSectionCd = "00";
            List<SCMNewArrNtfySt> retSCMNewArrNtfyStList;

            // 端末管理設定
            if (_posTerminalMg == null)
            {
                return false;
            }

            // 得意先設定／拠点設定／全社設定取得
            # region [新着表示設定]
            if (_scmNewArrNtfyStList == null)
            {
                return false;
            }
            retSCMNewArrNtfyStList = _scmNewArrNtfyStList.FindAll(
                delegate(SCMNewArrNtfySt scmNew)
                {
                    if (((string.IsNullOrEmpty(scmNew.SectionCode.Trim())) && (scmNew.CustomerCode != 0)) ||  // 得意先設定（得意先設定は無条件で対象とする）
                        ((scmNew.CustomerCode == 0) && (scmNew.SectionCode.Trim() == sectionCode.Trim())) ||      // 拠点設定
                        ((scmNew.CustomerCode == 0) && (scmNew.SectionCode.Trim() == allSectionCd)))            // 全社設定
                    {
                        return true; // 注) Findのreturnなのでメソッドの返却値ではありません
                    }
                    else
                    {
                        return false; // 注) Findのreturnなのでメソッドの返却値ではありません
                    }
                }
            );
            if (retSCMNewArrNtfyStList == null || retSCMNewArrNtfyStList.Count == 0)
            {
                return false;
            }
            # endregion

            // 得意先設定／拠点設定／全社設定取得の どれかの設定であたるならばこのクライアントは対象
            foreach (SCMNewArrNtfySt scmNewArrNtfySt in retSCMNewArrNtfyStList)
            {
                if (scmNewArrNtfySt.CashRegisterNo == _posTerminalMg.CashRegisterNo)
                {
                    // 該当があればtrue
                    return true;
                }
            }
            // 該当が無ければfalse
            return false;
        }
        // ADD 2013/11/26 SCM仕掛一覧№10592対応 ------------------------------------<<<<<
    }
    // --- ADD m.suzuki 2010/07/30 ----------<<<<<

    // ---ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 ----->>>>>
    # region
    /// <summary>
    /// リトライ設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : リトライ設定クラス</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/07/28</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RetrySet
    {
        // リトライ回数
        private int _retryCount;

        // リトライ間隔
        private int _retryInterval;

        /// <summary>
        /// リトライ設定クラス
        /// </summary>
        public RetrySet()
        {

        }

        /// <summary>リトライ回数</summary>
        public int RetryCount
        {
            get { return this._retryCount; }
            set { this._retryCount = value; }
        }

        /// <summary>リトライ間隔</summary>
        public int RetryInterval
        {
            get { return this._retryInterval; }
            set { this._retryInterval = value; }
        }
    }
    # endregion
    // ---ADD 2020/07/28 陳艶丹 PMKOBETSU-3926対応 -----<<<<<

}

