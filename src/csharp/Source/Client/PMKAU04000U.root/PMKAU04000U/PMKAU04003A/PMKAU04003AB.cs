//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 得意先電子元帳
// プログラム概要   : 得意先電子元帳の表示・印刷・赤伝発行を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30418 徳永
// 作 成 日  2008/09/09  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2008/12/18  修正内容 : 赤伝登録機能の実装
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2009/02/17  修正内容 : 売上伝票入力の変更に伴い金額端数処理の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2009/02/19  修正内容 : 売上データ登録時のリモート処理エラー後の処理を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2009/03/06  修正内容 : 消費税端数処理の修正(売上伝票入力と同様)（ ※ver1.1）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/10  修正内容 : MANTIS【13439】対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/08/03  修正内容 : オールパーツエラー対応
//                                  メーカーがない明細を赤伝発行するとエラーになる現象の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 作 成 日  2009/08/07  修正内容 : オールパーツエラー対応
//                                  赤伝発行時、明細データの売上日付が元黒になっているため、
//                                  月次集計データの集計月の不具合が発生した現象を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/09/07  修正内容 : PM.NS-2-A 車輛管理
//                                  赤伝発行時の車輌情報登録内容に項目を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/11/25  修正内容 : PM.NS保守依頼③
//                                  赤伝発行時に返品理由コードを追加
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 呉元嘯
// 作 成 日  2010/01/29  修正内容 : 4次改良 不具合対応
//                                  返品時在庫登録「1:しない」で赤伝発行した場合に在庫があれば更新するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/06/08  修正内容 : 赤伝発行の発行者のセット仕様を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/07/20  修正内容 : 成果物統合２
//                                   ・赤伝発行時に元黒伝票をReadする際、行№で判定する。
//                                     （物理的な順番と、行№順が異なる登録が出来る為）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/08/10  修正内容 : 赤伝発行時に明細の選択次第でエラー発生する件の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/10/07  修正内容 : ①売上赤伝と同時入力の仕入返品がデータ上連携していない件の修正
//                               : ②同時仕入の伝票区分を売上に合わせるよう修正
//                               :   　売上(数量マイナス)→仕入(数量マイナス)
//                               :   　売上返品→仕入返品
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/11/26  修正内容 : 商品自動登録の価格開始日を前回月次更新日＋１に変更
//                               : （※DCCMN00003C.dll、SFUKN09001E.dll、PMCMN00102A.dll）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024 佐々木 健
// 作 成 日  2010/11/29  修正内容 : 赤伝発行時の自動入金対応（MANTIS[0015365]）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 作 成 日  2010/12/20  修正内容 : 赤伝のデータセット仕様の修正（MANTIS: 16057）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2010/12/20  修正内容 : 障害・改良対応12月リリース分対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/08/06  修正内容 : 赤伝発行時、データ送信対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/08/18  修正内容 : Redmine#23241の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/08/31  修正内容 : Redmine#24110 備考のチェック処理を追加する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2011/09/21  修正内容 : Redmine#25412 PCCUOE PM側／得意先電子元帳　赤伝発行時のSF側の表示不正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2011/09/21  修正内容 : Redmine#25210 返品時は回答納期をセットしないの対応
//----------------------------------------------------------------------------//
// 管理番号 10707327-00  作成担当 : 凌小青
// 作 成 日  2012/01/11  修正内容 : 2012/02/23配信分　
//　　　　　　　　　　　　　　　　　Redmine#27932 得意先電子元帳 赤伝発行時の得意先伝票番号の採番の対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/03/05  修正内容 : PMSF連携伝票を赤伝発行した場合の返品手数料明細の
//                                  売上伝票区分(明細)のセット方法変更(返品→値引)
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/03/21  修正内容 : PMSF連携伝票を赤伝発行した場合の
//                                  問合せ行番号および問合せ行番号枝番の付番方法を変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gezh
// 修 正 日  2012/03/29  修正内容 : 2012/05/24配信分 Redmine#29149 得意先電子元帳　赤伝返品手数料入力時の販売区分についての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/05/18  修正内容 : 障害一覧表№117対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/07/11  修正内容 : 障害一覧表№35対応  赤伝時に問合せ番号を設定する
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : FSI菅原　要
// 作 成 日  2012/08/22  修正内容 : 得意先電子元帳 赤伝発行入力画面　仕入日の追加に伴う修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/09/20  修正内容 : №35の戻し
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/09/26  修正内容 : №35の戻し　回答送信していない伝票の赤伝発行対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本　利明　
// 作 成 日  2012/11/21  修正内容 : 連携データの赤伝発行の場合でも入力した伝票区分で登録
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子　
// 作 成 日  2012/10/17  修正内容 : SCM障害№10414対応　SCM送信処理用売上伝票番号リスト追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : daibin
// 修 正 日  2013/02/06  修正内容 : 2013/03/13配信分の緊急対応 Redmine#34580
//                                  赤伝発行入力画面　計上日と入荷日をセット修正
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI菅原　要
// 作 成 日  2013/01/15  修正内容 : 仕入返品予定データ作成対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : daibin
// 修 正 日  2013/02/20  修正内容 : 2013/03/13配信分の緊急対応 Redmine#34580
//                                  赤伝発行入力画面　入力日をセット修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22027 橋本 将樹
// 作 成 日  2013/02/25  修正内容 : 赤伝発行時の商品データ取得の際に、商品付加情報を取得しないように修正
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 凌小青
// 作 成 日  2013/02/27  修正内容 : 2013/03/13配信分　
//　　　　　　　　　　　　　　　　　Redmine#33797の＃14対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI斎藤 和宏
// 作 成 日  2013/02/27  修正内容 : 仕入返品予定データ作成時に元伝票削除されていた場合のメッセージ表示対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : zhaimm
// 修 正 日  2013/03/18  修正内容 : 2013/05/15配信分 Redmine#34807得意先電子元帳の対応
//                                  赤伝発行時：売上伝票入力の仕様と同様、0詰めを行う
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/25  修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 修 正 日  2013/06/19  修正内容 : システムテスト障害対応
//             ①№50 赤伝発行時にSCM受注データ(車両情報)の入庫予定日を元データから引継
//             ②№51 赤伝発行時にSCM受注データのタブレット使用区分を元データから引継
//             ③№66 赤伝発行時にSCM受注データの車輌管理コードを元データから引継
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 修 正 日  2013/06/25  修正内容 : 赤伝発行時のリモート伝票発行の不具合対応
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 宮本 利明
// 修 正 日  2013/10/10  修正内容 : 仕掛一覧 №2149 障害対応
//                                  赤伝発行時の伝票作成順をリモートに渡すリストに設定
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 修 正 日  2013/09/17  修正内容 : SCM障害№10573対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 修 正 日  2013/11/01  修正内容 : VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18
//----------------------------------------------------------------------------//
// 管理番号  10902160-00 作成担当 : wangl2
// 作 成 日  K2013/09/09 修正内容 : フタバ様、特定得意先倉庫に在庫が存在する商品の返品時は、実際の出庫元倉庫ではなく
//　　　　　　　　　　　　　　　　　特定得意先倉庫の在庫数を増やすように変更が必要な為、変更を行う。　　　　
//----------------------------------------------------------------------------//
// 管理番号  10902160-00 作成担当 : huangt
// 修 正 日  K2013/10/11 修正内容 : Redmine#40626 フタバ_システム障害について
//　　　　　　　　　　　　　　　　　No.92 返品する商品の在庫が論理削除されている場合に、
//                                        出庫元倉庫に返品するように修正　　　
//----------------------------------------------------------------------------//
// 管理番号  10902160-00 作成担当 : huangt
// 修 正 日  K2013/10/15 修正内容 : Redmine#40626 フタバ_システム障害について
//　　　　　　　　　　　　　　　　　No.96 オプション取得方式の変更
//----------------------------------------------------------------------------//
// 管理番号  10970522-00  作成担当 : wangl2
// 作 成 日  K2014/01/20  修正内容 : Redmine#41497 フタバ個別対応
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : 譚洪
// 修 正 日  2014/01/07  修正内容 : Redmine#41771 売上伝票入力消費税8%増税対応
//----------------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : xuyb
// 修 正 日  2014/02/07  修正内容 : Redmine#41771 売上伝票入力消費税8%増税対応 売り・仕入同時
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 修 正 日  2014/06/04  修正内容 : SCM仕掛一覧№10659対応
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 宮本 利明
// 修 正 日  2014/08/12  修正内容 : SCM障害№10643対応
//----------------------------------------------------------------------------//
// 管理番号  11002291-00 作成担当 : wupf
// 修 正 日  2014/08/13  修正内容 : Redmine＃43184 倉庫コードの障害解除
//----------------------------------------------------------------------------//
// 管理番号  11070148-00 作成担当 : 鄧潘ハン
// 作 成 日  2014/08/26  修正内容 : SCM仕掛一覧№10650  RedMine#43145の対応 
//    ①売仕入同時の仕入伝票を呼び出せない　…　№10650対応
//    ↓これに伴い、以下の既存の障害も修正した
//    ②赤伝発行時に仕入情報を入力しても仕入データが作成されない場合がある。
//    ③SCM回答送信していない伝票に対し、赤伝発行時にSCM回答送信を行うとエラーになる。
//----------------------------------------------------------------------------//
// 管理番号  11001634-00 作成担当 : 脇田 靖之
// 作 成 日  K2014/06/20 修正内容 : フタバ個別対応
// 　　　　　　　　　　　　　　　　 赤伝･返品･削除時在庫引当処理対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応
// 　　　　　　　　　　　　　　　　 貸出区分、メーカー希望小売価格、オープン価格区分の追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢 憲弘
// 修 正 日  2015/01/19  修正内容 : リコメンド対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2015/01/30  修正内容 : SCM高速化 生産年式、車台番号対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30745 吉岡
// 修 正 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31126 下口
// 修 正 日  2015/02/23  修正内容 : SCM高速化 Ｃ向け種別特記対応
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2015/02/09  修正内容 : SCM連携 マルチキャスト対応
// 　　　　　　　　　　　　　　　　 問合せ行番号枝番の採番方法の修正
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 譚洪
// 作 成 日  2018/04/16  修正内容 : SCM連携 新BLコード対応
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 陳艶丹
// 作 成 日  2020/11/20  修正内容 : PMKOBETSU-4097 TSPインライン機能追加対応
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 呉元嘯
// 作 成 日  2020/12/21  修正内容 : PMKOBETSU-4097 TSPインライン機能追加対応
//----------------------------------------------------------------------------//
// 管理番号  11870080-00 作成担当 : 仰亮亮
// 作 成 日  2022/05/05  修正内容 : 納品書電子帳簿連携対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using System.Windows.Forms;
using Broadleaf.RCDS.Web.Services;//add 2011/08/06 duzg
using System.IO;// ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応
using System.Diagnostics;// ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先電子元帳用赤伝発行データ取得・登録アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先電子元帳で赤伝発行を行う際に使用するアクセスクラス</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.09.09</br>
    /// <br></br>
    /// <br>UpdateNote : 2008.12.18  22018 鈴木正臣</br>
    /// <br>             ①赤伝登録機能の実装</br>
    /// <br></br>
    /// <br>UpdateNote : 2008.02.17  22018 鈴木正臣</br>
    /// <br>             ①売上伝票入力の変更に伴い金額端数処理の変更</br>
    /// <br></br>
    /// <br>Update Note: 2009/02/19 30452 上野 俊治</br>
    /// <br>             ①売上データ登録時のリモート処理エラー後の処理を修正</br>
    /// <br></br>
    /// <br>Update Note: 2009/03/06 22018 鈴木正臣</br>
    /// <br>             ①消費税端数処理の修正(売上伝票入力と同様)（ ※ver1.1）</br>
    /// <br>Update Note: 2009/09/07 張莉莉</br>
    /// <br>             PM.NS-2-A 車輛管理</br>
    /// <br>             赤伝発行時の車輌情報登録内容に項目を追加</br>
    /// <br></br>
    /// <br>Update Note: 2009/11/25 呉元嘯</br>
    /// <br>             赤伝発行時に返品理由コードを追加</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/06/08  22018 鈴木正臣</br>
    /// <br>             赤伝発行の発行者のセット仕様を修正。</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/20  22018 鈴木正臣</br>
    /// <br>             成果物統合２</br>
    /// <br>             　・赤伝発行時に元黒伝票をReadした後、行№でListをソートするように修正。</br>
    /// <br>             　　（物理的な順番と、行№順が異なる登録が出来る為）</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/08/10  22018 鈴木正臣</br>
    /// <br>             赤伝発行時に明細の選択次第でエラー発生する件の修正</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/11/29  21024　佐々木 健</br>
    /// <br>             赤伝発行時の自動入金対応（MANTIS[0015365]）</br>
    /// <br>UpdateNote : 2010/12/20  yangmj</br>
    /// <br>             障害・改良対応12月リリース分対応</br>
    /// <br>UpdateNote : 2011/08/06  duzg</br>
    /// <br>             赤伝発行時、データ送信対応</br>
    /// <br>UpdateNote : 2011/08/31  李占川</br>
    /// <br>             Redmine#24110 備考のチェック処理を追加する</br>
    /// <br>UpdateNote : 2012/03/29  gezh</br>
    /// <br>             2012/05/24配信分 Redmine#29149 得意先電子元帳　赤伝返品手数料入力時の販売区分についての対応</br>
    /// <br>UpdateNote : 2013/02/06  daibin</br>
    /// <br>             10801804-00 2013/03/13配信分 Redmine#34580 赤伝発行入力画面　計上日と入荷日をセット修正</br>
    /// <br>UpdateNote : 2013/01/15  FSI菅原　要</br>
    /// <br>             仕入返品予定データ作成対応</br>
    /// <br>UpdateNote : 2013/02/20  daibin</br>
    /// <br>             10801804-00 2013/03/13配信分 Redmine#34580 赤伝発行入力画面　入力日をセット修正</br>
    /// <br>UpdateNote : 2013/02/25  22027 橋本 将樹</br>
    /// <br>             赤伝発行時の商品データ取得の際に、商品付加情報を取得しないように修正</br>
    /// <br>UpdateNote : 2013/03/18 zhaimm </br>
    /// <br>           : 10800003-00、2013/05/15配信分、Redmine#34807得意先電子元帳の対応</br>
    /// <br>           : 赤伝発行時：売上伝票入力の仕様と同様、0詰めを行う</br>
    /// <br>UpdateNote : 2013/10/22 吉岡 </br>
    /// <br>           : VSS[019]　Redmine#37707 ｼｽﾃﾑﾃｽﾄ障害№93対応</br>
    /// <br>UpdateNote : K2014/01/20 wangl2 </br>
    /// <br>           : Redmine#41497 フタバ個別対応</br>
    /// <br>UpdateNote : 2014/08/26 鄧潘ハン </br>
    /// <br>管理番号   : 11070148-00　仕掛 №10650　RedMine#43145の対応</br>
    /// <br>           : ①売仕入同時の仕入伝票を呼び出せない</br>
    /// <br>             ②赤伝発行時に仕入情報を入力しても仕入データが作成されない場合がある</br>
    /// <br>             ③SCM回答送信していない伝票に対し、赤伝発行時にSCM回答送信を行うとエラーになる。</br>
    /// <br>UpdateNote : 2014/12/19 30744 湯上 千加子</br>
    /// <br>管理番号   : 11070266-00</br>
    /// <br>           : SCM高速化 PMNS対応</br>
    /// <br>           : 貸出区分、メーカー希望小売価格、オープン価格区分の追加</br>
    /// <br>UpdateNote : 2018/04/16 譚洪</br>
    /// <br>管理番号   : 11470007-00</br>
    /// <br>           : 赤伝発行時に元黒伝票に設定されている新BLコード等の新項目をSCM受注明細データ(回答)データに設定する。</br>
    /// <br>Update Note: 2020/11/20 陳艶丹</br>
    /// <br>管理番号   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
    /// <br>Update Note: 2020/12/21 呉元嘯</br>
    /// <br>管理番号   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
    /// <br>Update Note: 2022/05/05 仰亮亮</br>
    /// <br>管理番号   : 11870080-00</br>
    /// <br>           : 納品書電子帳簿連携対応</br>
    /// <br></br>
    /// </remarks>
    public partial class CustPtrSalesDetailRedSlipAcs
    {
        // --- DEL 2020/12/21 警告対応 ---------->>>>>
        //private Dictionary<string,int> _printRedSalesSlipNo;        //退避赤伝伝票番号
        // --- DEL 2020/12/21 警告対応 ----------<<<<<

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CustPtrSalesDetailRedSlipAcs()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 DEL
            //// インスタンス
            //this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 DEL

            //// 見積初期値設定マスタ
            //this._estimateDefSetAcs = new EstimateDefSetAcs();  

            //ArrayList al = null;
            //status = _estimateDefSetAcs.Search(out al, enterpriseCode);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    if (al != null)
            //    {
            //        this.CacheEstimateDefSet(al);
            //        this.CacheEstimateDefSet(enterpriseCode, sectionCode);
            //    }
            //}
            _salesSlipInputAcs = SalesSlipInputAcs.GetInstance();// ADD 2011/08/06 duzg for 赤伝発行時、データ送信対応
            _iIOWritScmDB = MediationIOWriteScmDB.GetIOWriteScmDB();// ADD 2011/08/06 duzg for 赤伝発行時、データ送信対応
            // ----- ADD 2013/01/15 ----->>>>>
            _stockSlipRetPlnAcs = StockSlipRetPlnAcs.GetInstance();
            // ----- ADD 2013/01/15 -----<<<<<

            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance(); // ADD 譚洪 2014/01/07

            // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
            #region ●TSPオプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_Tsp);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // TSP連携マスタ設定
                TspCprtStAccess = new TspCprtStAcs();
                TspCprtStWork tspCprtStWork = new TspCprtStWork();
                try
                {
                    // 企業コード
                    tspCprtStWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    // TSP連携マスタ設定情報取得
                    int status = TspCprtStAccess.Search(tspCprtStWork, out this.TspCprtStWorkList);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        LogWrite("CustPtrSalesDetailRedSlipAcs", "TSP連携マスタ設定情報の取得に失敗しました。");
                    }
                }
                catch (Exception ex)
                {
                    LogWrite("CustPtrSalesDetailRedSlipAcs", "TSP連携マスタ設定情報の取得に失敗しました、" + ex.Message.ToString());
                }
            }
            #endregion
            // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        }

        #endregion // コンストラクタ

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
        # region enum
        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        internal enum OptWorkSettingType : int
        {
            /// <summary>登録</summary>
            Write = 0,
            /// <summary>読込</summary>
            Read = 1,
            /// <summary>削除</summary>
            Delete = 2,
        }
        /// <summary>
        /// 総額表示方法区分
        /// </summary>
        internal enum TotalAmountDispWayCd : int
        {
            /// <summary>総額表示しない</summary>
            NoTotalAmount = 0,
            /// <summary>総額表示する</summary>
            TotalAmount = 1,
        }
        /// <summary>
        /// 消費税転嫁方式
        /// </summary>
        internal enum ConsTaxLayMethod : int
        {
            /// <summary>伝票転嫁</summary>
            SlipLay = 0,
            /// <summary>明細転嫁</summary>
            DetailLay = 1,
            /// <summary>請求親</summary>
            DemandParentLay = 2,
            /// <summary>請求子</summary>
            DemandChildLay = 3,
            /// <summary>非課税</summary>
            TaxExempt = 9,
        }
        /// <summary>
        /// 売上伝票区分（明細）
        /// </summary>
        internal enum SalesSlipCdDtl : int
        {
            /// <summary>売上</summary>
            Sales = 0,
            /// <summary>返品</summary>
            RetGoods = 1,
            /// <summary>値引</summary>
            Discount = 2,
            /// <summary>注釈</summary>
            Annotation = 3,
            /// <summary>小計</summary>
            Subtotal = 4,
            /// <summary>作業</summary>
            Work = 5,
        }
        ///// <summary>
        ///// 売上金額手入力区分
        ///// </summary>
        //public enum SalesMoneyInputDiv : int
        //{
        //    /// <summary>通常算出</summary>
        //    Calculate = 0,
        //    /// <summary>手入力</summary>
        //    Input = 1,
        //}
        /// <summary>
        /// 商品区分
        /// </summary>
        internal enum SalesGoodsCd : int
        {
            /// <summary>商品</summary>
            Goods = 0,
            /// <summary>商品外</summary>
            NonGoods = 1,
            /// <summary>消費税調整</summary>
            ConsTaxAdjust = 2,
            /// <summary>残高調整</summary>
            BalanceAdjust = 3,
            /// <summary>売掛用消費税調整</summary>
            AccRecConsTaxAdjust = 4,
            /// <summary>売掛用残高調整</summary>
            AccRecBalanceAdjust = 5,
        }
        # endregion

        # region const
        /// <summary>端数処理対象金額区分（売上金額）</summary>
        internal const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        internal const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        internal const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        ///// <summary>端数処理対象金額区分（原価単価）</summary>
        //internal const int ctFracProcMoneyDiv_SalesUnitCost = 3;
        ///// <summary>端数処理対象金額区分（原価金額）</summary>
        //internal const int ctFracProcMoneyDiv_Cost = 4;
        # endregion

        # region struct
        # region [仕入伝票論理KEY]
        /// <summary>
        /// 仕入伝票論理KEY
        /// </summary>
        private struct StockSlipLogicalKey
        {
            /// <summary>企業コード</summary>
            private string _enterpriseCode;
            /// <summary>仕入先</summary>
            private int _supplierCd;
            /// <summary>仕入日</summary>
            private DateTime _stockDate;
            /// <summary>伝票区分</summary>
            private int _supplierSlipCd;
            /// <summary>伝票番号</summary>
            private string _partySaleSlipNum;
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>
            /// 企業コード
            /// </summary>
            public string EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }
            /// <summary>
            /// 仕入先
            /// </summary>
            public int SupplierCd
            {
                get { return _supplierCd; }
                set { _supplierCd = value; }
            }
            /// <summary>
            /// 仕入日
            /// </summary>
            public DateTime StockDate
            {
                get { return _stockDate; }
                set { _stockDate = value; }
            }
            /// <summary>
            /// 伝票区分
            /// </summary>
            public int SupplierSlipCd
            {
                get { return _supplierSlipCd; }
                set { _supplierSlipCd = value; }
            }
            /// <summary>
            /// 伝票番号
            /// </summary>
            /// <remarks>相手先の伝票番号</remarks>
            public string PartySaleSlipNum
            {
                get { return _partySaleSlipNum; }
                set { _partySaleSlipNum = value; }
            }
            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="enterpriseCode">企業コード</param>
            /// <param name="supplierCd">仕入先</param>
            /// <param name="stockDate">仕入日</param>
            /// <param name="supplierSlipCd">伝票区分</param>
            /// <param name="partySaleSlipNum">伝票番号</param>
            /// <param name="sectionCode">拠点コード</param>
            public StockSlipLogicalKey( string enterpriseCode, int supplierCd, DateTime stockDate, int supplierSlipCd, string partySaleSlipNum, string sectionCode )
            {
                _enterpriseCode = enterpriseCode;
                _supplierCd = supplierCd;
                _stockDate = stockDate;
                _supplierSlipCd = supplierSlipCd;
                _partySaleSlipNum = partySaleSlipNum;
                _sectionCode = sectionCode;
            }
        }
        # endregion

        # region [商品KEY]
        /// <summary>
        /// 商品KEY
        /// </summary>
        private struct GoodsKey
        {
            /// <summary>品番</summary>
            private string _goodsNo;
            /// <summary>メーカー</summary>
            private int _goodsMakerCd;
            /// <summary>
            /// 品番
            /// </summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>
            /// メーカー
            /// </summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="goodsNo">品番</param>
            /// <param name="goodsMakerCd">メーカー</param>
            public GoodsKey( string goodsNo, int goodsMakerCd )
            {
                _goodsNo = goodsNo;
                _goodsMakerCd = goodsMakerCd;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="goodsUnitData">商品</param>
            public GoodsKey( GoodsUnitData goodsUnitData )
            {
                _goodsNo = goodsUnitData.GoodsNo;
                _goodsMakerCd = goodsUnitData.GoodsMakerCd;
            }
        }
        # endregion
        # endregion

        # region class
        # region [赤伝登録パラメータ]
        /// <summary>
        /// 赤伝登録パラメータ
        /// </summary>
        public class RedSlipWriteParameter
        {
            /// <summary>企業コード</summary>
            private string _enterpriseCode;
            /// <summary>伝票区分</summary>
            private int _slipCd;
            /// <summary>入力従業員コード</summary>
            private string _inputEmployeeCd;
            /// <summary>入力従業員名称</summary>
            private string _inputEmployeeNm;
            /// <summary>売上日</summary>
            private DateTime _salesDate;
            /// <summary>手数料率(取寄)</summary>
            private double _feeRateOfOrder;
            /// <summary>手数料額(取寄)</summary>
            private Int64 _feePriceOfOrder;
            /// <summary>手数料率(在庫)</summary>
            private double _feeRateOfStock;
            /// <summary>手数料額(在庫)</summary>
            private Int64 _feePriceOfStock;
            /// <summary>手数料率(合計)</summary>
            private double _feeRateOfTotal;
            /// <summary>手数料額(合計)</summary>
            private Int64 _feePriceOfTotal;
            // ADD 2012/03/29 gezh Redmine#29149 --------->>>>>
            /// <summary>販売区分</summary>
            private Int32 _salesCodeDiv;
            // ADD 2012/03/29 gezh Redmine#29149 ---------<<<<<
            /// <summary>得意先注番</summary>
            private string _partySalesSlipNo;
            /// <summary>備考１</summary>
            private string _slipNote;
            /// <summary>備考２</summary>
            private string _slipNote2;
            /// <summary>備考３</summary>
            private string _slipNote3;
            /// <summary>返品理由</summary>
            private string _returnReason;
            // --- ADD 2009/11/25 ---------->>>>>
            /// <summary>返品理由コード</summary>
            private Int32 _returnReasonDiv;
            // --- ADD 2009/11/25 ----------<<<<<
            /// <summary>拠点コード</summary>
            private string _sectionCode;
            /// <summary>得意先コード</summary>
            private int _customerCode;

            // --- ADD 2009/09/07 ---------->>>>>
            /// <summary>車両走行距離</summary>
            private int _mileage;
            /// <summary>車輌備考</summary>
            private string _carNote;

            /// <summary>
            /// 車輌備考
            /// </summary>
            public string CarNote
            {
                get { return _carNote; }
                set { _carNote = value; }
            }
            /// <summary>
            /// 車両走行距離
            /// </summary>
            public int Mileage
            {
                get { return _mileage; }
                set { _mileage = value; }
            }
            // --- ADD 2009/09/07 ----------<<<<<
            

            /// <summary>
            /// 企業コード
            /// </summary>
            public string EnterpriseCode
            {
                get { return _enterpriseCode; }
                set { _enterpriseCode = value; }
            }
            /// <summary>
            /// 伝票区分
            /// </summary>
            public int SlipCd
            {
                get { return _slipCd; }
                set { _slipCd = value; }
            }
            /// <summary>
            /// 入力従業員コード
            /// </summary>
            public string InputEmployeeCd
            {
                get { return _inputEmployeeCd; }
                set { _inputEmployeeCd = value; }
            }
            /// <summary>
            /// 入力従業員名称
            /// </summary>
            public string InputEmployeeNm
            {
                get { return _inputEmployeeNm; }
                set { _inputEmployeeNm = value; }
            }
            /// <summary>
            /// 売上日
            /// </summary>
            public DateTime SalesDate
            {
                get { return _salesDate; }
                set { _salesDate = value; }
            }
            /// <summary>
            /// 手数料率(取寄)
            /// </summary>
            public double FeeRateOfOrder
            {
                get { return _feeRateOfOrder; }
                set { _feeRateOfOrder = value; }
            }
            /// <summary>
            /// 手数料額(取寄)
            /// </summary>
            public Int64 FeePriceOfOrder
            {
                get { return _feePriceOfOrder; }
                set { _feePriceOfOrder = value; }
            }
            /// <summary>
            /// 手数料率(在庫)
            /// </summary>
            public double FeeRateOfStock
            {
                get { return _feeRateOfStock; }
                set { _feeRateOfStock = value; }
            }
            /// <summary>
            /// 手数料額(在庫)
            /// </summary>
            public Int64 FeePriceOfStock
            {
                get { return _feePriceOfStock; }
                set { _feePriceOfStock = value; }
            }
            /// <summary>
            /// 手数料率(合計)
            /// </summary>
            public double FeeRateOfTotal
            {
                get { return _feeRateOfTotal; }
                set { _feeRateOfTotal = value; }
            }
            /// <summary>
            /// 手数料額(合計)
            /// </summary>
            public Int64 FeePriceOfTotal
            {
                get { return _feePriceOfTotal; }
                set { _feePriceOfTotal = value; }
            }
            // ADD 2012/03/29 gezh Redmine#29149 --------->>>>>
            /// <summary>
            /// 販売区分
            /// </summary>
            public Int32 SalesCodeDiv
            {
                get { return _salesCodeDiv; }
                set { _salesCodeDiv = value; }
            }
            // ADD 2012/03/29 gezh Redmine#29149 ---------<<<<<
            /// <summary>
            /// 得意先注番
            /// </summary>
            public string PartySalesSlipNo
            {
                get { return _partySalesSlipNo; }
                set { _partySalesSlipNo = value; }
            }
            /// <summary>
            /// 備考１
            /// </summary>
            public string SlipNote
            {
                get { return _slipNote; }
                set { _slipNote = value; }
            }
            /// <summary>
            /// 備考２
            /// </summary>
            public string SlipNote2
            {
                get { return _slipNote2; }
                set { _slipNote2 = value; }
            }
            /// <summary>
            /// 備考３
            /// </summary>
            public string SlipNote3
            {
                get { return _slipNote3; }
                set { _slipNote3 = value; }
            }
            /// <summary>
            /// 返品理由
            /// </summary>
            public string ReturnReason
            {
                get { return _returnReason; }
                set { _returnReason = value; }
            }
            // --- ADD 2009/11/25 ---------->>>>>
            /// <summary>
            /// 返品理由コード
            /// </summary>
            public Int32 RetGoodsReasonDiv
            {
                get { return _returnReasonDiv; }
                set { _returnReasonDiv = value; }
            }
            // --- ADD 2009/11/25 ----------<<<<<
            /// <summary>
            /// 拠点コード
            /// </summary>
            public string SectionCode
            {
                get { return _sectionCode; }
                set { _sectionCode = value; }
            }
            /// <summary>
            /// 得意先コード
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public RedSlipWriteParameter()
            {
                _enterpriseCode = string.Empty;
                _slipCd = 0;
                _inputEmployeeCd = string.Empty;
                _inputEmployeeNm = string.Empty;
                _salesDate = DateTime.MinValue;
                _feeRateOfOrder = 0;
                _feePriceOfOrder = 0;
                _feeRateOfStock = 0;
                _feePriceOfStock = 0;
                _feeRateOfTotal = 0;
                _feePriceOfTotal = 0;
                _salesCodeDiv = 0; // ADD 2012/03/29 gezh Redmine#29149
                _partySalesSlipNo = string.Empty;
                _slipNote = string.Empty;
                _slipNote2 = string.Empty;
                _slipNote3 = string.Empty;
                _returnReason = string.Empty;
                _sectionCode = string.Empty;
                _customerCode = 0;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="enterpriseCode">企業コード</param>
            /// <param name="slipCd">伝票区分</param>
            /// <param name="inputEmployeeCd">入力従業員コード</param>
            /// <param name="inputEmployeeNm">入力従業員名称</param>
            /// <param name="salesDate">売上日</param>
            /// <param name="feeRateOfOrder">手数料率(取寄)</param>
            /// <param name="feePriceOfOrder">手数料額(取寄)</param>
            /// <param name="feeRateOfStock">手数料率(在庫)</param>
            /// <param name="feePriceOfStock">手数料額(在庫)</param>
            /// <param name="feeRateOfTotal">手数料率(合計)</param>
            /// <param name="feePriceOfTotal">手数料額(合計)</param>
            /// <param name="salesCodeDiv">販売区分</param>  // ADD 2012/03/29 gezh Redmine#29149 
            /// <param name="partySalesSlipNo">得意先注番</param>
            /// <param name="slipNote">備考１</param>
            /// <param name="slipNote2">備考２</param>
            /// <param name="slipNote3">備考３</param>
            /// <param name="returnReason">返品理由</param>
            /// <param name="returnReasonDiv">返品理由コード</param>
            /// <param name="sectionCode">拠点コード</param>
            /// <param name="customerCode">得意先コード</param>
            //public RedSlipWriteParameter( string enterpriseCode, int slipCd, string inputEmployeeCd, string inputEmployeeNm, DateTime salesDate, double feeRateOfOrder, Int64 feePriceOfOrder, double feeRateOfStock, Int64 feePriceOfStock, double feeRateOfTotal, Int64 feePriceOfTotal, string partySalesSlipNo, string slipNote, string slipNote2, string slipNote3, string returnReason, int returnReasonDiv, string sectionCode, int customerCode )  // DEL 2012/03/29 gezh Redmine#29149
            public RedSlipWriteParameter(string enterpriseCode, int slipCd, string inputEmployeeCd, string inputEmployeeNm, DateTime salesDate, double feeRateOfOrder, Int64 feePriceOfOrder, double feeRateOfStock, Int64 feePriceOfStock, double feeRateOfTotal, Int64 feePriceOfTotal,Int32 salesCodeDiv, string partySalesSlipNo, string slipNote, string slipNote2, string slipNote3, string returnReason, int returnReasonDiv, string sectionCode, int customerCode)  // ADD 2012/03/29 gezh Redmine#29149
            {
                _enterpriseCode = enterpriseCode;
                _slipCd = slipCd;
                _inputEmployeeCd = inputEmployeeCd;
                _inputEmployeeNm = inputEmployeeNm;
                _salesDate = salesDate;
                _feeRateOfOrder = feeRateOfOrder;
                _feePriceOfOrder = feePriceOfOrder;
                _feeRateOfStock = feeRateOfStock;
                _feePriceOfStock = feePriceOfStock;
                _feeRateOfTotal = feeRateOfTotal;
                _feePriceOfTotal = feePriceOfTotal;
                _salesCodeDiv = salesCodeDiv;  // ADD 2012/03/29 gezh Redmine#29149
                _partySalesSlipNo = partySalesSlipNo;
                _slipNote = slipNote;
                _slipNote2 = slipNote2;
                _slipNote3 = slipNote3;
                _returnReason = returnReason;
                _returnReasonDiv = returnReasonDiv;// ADD 2009/11/25
                _sectionCode = sectionCode;
                _customerCode = customerCode;
            }
        }
        # endregion
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
        // --- ADD m.suzuki 2010/08/18 ---------->>>>>
        # region delegate
        /// <summary>
        /// 書き込みデータチェックデリゲート
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public delegate bool WriteDataCheck( out string errorMessage );
        # endregion
        // --- ADD m.suzuki 2010/08/18 ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 DEL
        //private IIOWriteControlDB _iIOWriteControlDB;
        //private EstimateDefSetAcs _estimateDefSetAcs;

        //private EstimateDefSet _estimateDefSet;     // 見積初期値設定マスタ
        //private ArrayList _estimateDefSetList;      // 見積初期値設定マスタリスト
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 DEL
        // ----------ADD 2009/09/07---------------->>>>>
        /// <summary>オプション情報</summary>
        private int _opt_CarMngDiv;
        // --- ADD K2014/06/20 Y.Wakita ---------->>>>>
        private int _opt_Cpm_FutabaSlipPrtCtl; // フタバ伝票印刷制御オプション（個別）：OPT-CPM0090
        // --- ADD K2014/06/20 Y.Wakita ----------<<<<<

        #region ■列挙体
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
        #endregion
        // ----------ADD 2009/09/07----------------<<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
        private SalesTtlSt _salesTtlSt;     // 売上全体設定
        private int _carMngDivCd;           // 車輌管理区分
        private CustPtrSalesDetailDataSet _detailDataSet; // 明細データ格納データセット
        private CarSearchController _carSearchController; // 車両検索コントローラクラス
        private SalesInputDataSet.CarInfoDataTable _carInfoDataTable; // 車両情報テーブル
        private Dictionary<Guid, PMKEN01010E> _carInfo;   // 車両情報
        private Dictionary<Guid, PMKEN01010E.ColorCdInfoDataTable> _colorInfoDic;       // カラー情報
        private Dictionary<Guid, PMKEN01010E.TrimCdInfoDataTable> _trimInfoDic;         // トリム情報
        private Dictionary<Guid, PMKEN01010E.CEqpDefDspInfoDataTable> _cEqpDspInfoDic;  // 装備情報
        private Dictionary<Int32, Guid> _carRelationDic; // 車両情報リレーションディクショナリ
        private Dictionary<Guid, Guid> _dtlCarRelationDic; // 明細－車両情報リレーションディクショナリ
        private CustomerInfoAcs _customerInfoAcs;
        private SupplierAcs _supplierAcs;
        /// <summary>SFTOK09382A)従業員</summary>
        private EmployeeAcs _employeeAcs;//ADD 2010/12/20
        //private StockMstAcs _stockMstAcs;// ADD  K2013/09/09 wangl2 FOR フタバ様改修 // DEL K2014/01/20 wangl2 Redmine#41497
        private string _enterpriseCode;
        private SalesPriceCalculate _salesPriceCalculate;
        private StockPriceCalculate _stockPriceCalculate;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
        //private SalesInputInitialDataSet.SalesProcMoneyDataTable _salesProcMoneyDataTable;
        //private SalesInputInitialDataSet.StockProcMoneyDataTable _stockProcMoneyDataTable;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
        private List<SalesProcMoney> _salesProcMoneyList;
        private List<StockProcMoney> _stockProcMoneyList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
        private SalesProcMoneyAcs _salesProcMoneyAcs;
        private StockProcMoneyAcs _stockProcMoneyAcs;
        private IStockSlipDB _iStockSlipDB;
        private GoodsAcs _goodsAcs;
        private string _loginSectionCode;
        private Dictionary<GoodsKey, GoodsUnitData> _goodsUnitDataDic;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
        private List<SlipPrtSet> _slipPrtSetList; // 伝票印刷パターン設定リスト
        private List<CustSlipMng> _custSlipMngList; // 伝票設定リスト
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
        private ICustPrtPprWorkDB _iCustPrtPprWorkDB = null;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
        // --- ADD m.suzuki 2010/11/26 ---------->>>>>
        private TotalDayCalculator _totalDayCalculator; // 締日チェック部品
        private DateGetAcs _dateGetAcs; // 日付取得部品
        // --- ADD m.suzuki 2010/11/26 ----------<<<<<
        
        private SalesSlipInputAcs _salesSlipInputAcs;// Add 2011/08/06 duzg for 赤伝発行時、データ送信対応
        private IIOWriteScmDB _iIOWritScmDB;// Add 2011/08/06 duzg for 赤伝発行時、データ送信対応

        // ADD 2012/10/17 湯上 SCM障害№10414対応 ------------------------>>>>>
        private List<string> _salesSlipNumList = null;
        // ADD 2012/10/17 湯上 SCM障害№10414対応 ------------------------<<<<<

        // ----- ADD 2013/01/15 ----->>>>>
        // 仕入返品計上更新部品
        private StockSlipRetPlnAcs _stockSlipRetPlnAcs;
        // ----- ADD 2013/01/15 -----<<<<<

        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs; // ADD 譚洪 2014/01/07

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        private TspCprtStAcs TspCprtStAccess;
        // TSP連携マスタ設定
        private ArrayList TspCprtStWorkList;
        // 起動パラメータ
        private string Parameter = string.Empty;

        /// <summary>
        /// TSP連携マスタ設定
        /// </summary>
        public ArrayList TspCprtStList
        {
            get { return this.TspCprtStWorkList; }
            set { this.TspCprtStWorkList = value; }
        }

        /// <summary>
        /// 起動パラメータ
        /// </summary>
        public string LoginParameter
        {
            get { return this.Parameter; }
            set { this.Parameter = value; }
        }
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 売上全体設定
        /// </summary>
        public SalesTtlSt SalesTtlSt
        {
            get { return _salesTtlSt; }
            set { _salesTtlSt = value; }
        }
        /// <summary>
        /// 車輌管理区分
        /// </summary>
        public int CarMngDivCd
        {
            get { return _carMngDivCd; }
            set { _carMngDivCd = value; }
        }
        /// <summary>
        /// 明細データ格納データセット
        /// </summary>
        public CustPtrSalesDetailDataSet DetailDataSet
        {
            get { return _detailDataSet; }
            set { _detailDataSet = value; }
        }
        /// <summary>
        /// ログイン拠点コード
        /// </summary>
        public string LoginSectionCode
        {
            get { return _loginSectionCode; }
            set { _loginSectionCode = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD

        // --- ADD 2011/08/31 ---------->>>>>
        /// <summary>伝票備考桁数</summary>
        private Int32 _slipNoteCharCnt;

        /// <summary>伝票備考２桁数</summary>
        private Int32 _slipNote2CharCnt;

        /// <summary>伝票備考３桁数</summary>
        private Int32 _slipNote3CharCnt;

        /// public propaty name  :  SlipNoteCharCnt
        /// <summary>伝票備考桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNoteCharCnt
        {
            get { return _slipNoteCharCnt; }
            set { _slipNoteCharCnt = value; }
        }

        /// public propaty name  :  SlipNote2CharCnt
        /// <summary>伝票備考２桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNote2CharCnt
        {
            get { return _slipNote2CharCnt; }
            set { _slipNote2CharCnt = value; }
        }

        /// public propaty name  :  SlipNote3CharCnt
        /// <summary>伝票備考３桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNote3CharCnt
        {
            get { return _slipNote3CharCnt; }
            set { _slipNote3CharCnt = value; }
        }
        // --- ADD 2011/08/31 ----------<<<<<


        // ADD 2012/10/17 湯上 SCM障害№10414対応 ------------------------>>>>>
        /// public propaty name  :  SalesSlipNumList
        /// <summary>SCM送信処理用売上伝票番号リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM送信処理用売上伝票番号リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<string> SalesSlipNumList
        {
            get { return this._salesSlipNumList; }
            set { this._salesSlipNumList = value; }
        }
        // ADD 2012/10/17 湯上 SCM障害№10414対応 ------------------------<<<<<

        // --- ADD 2013/10/10 T.Miyamoto ------------------------------>>>>>
        private int _redSlipWorkSlipNo;
        // --- ADD 2013/10/10 T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize( string enterpriseCode, string loginSectionCode )
        {
            _enterpriseCode = enterpriseCode;
            _loginSectionCode = loginSectionCode;

            // 最初に使用するときアクセスクラスを生成する
            if ( _goodsAcs == null )
            {
                _goodsAcs = new GoodsAcs();
                string retMessage;
                //_goodsAcs.SearchInitial(_enterpriseCode, _loginSectionCode, out retMessage); // 2012.02.25 橋本 DEL
                // 商品不足情報は取得しないように変更
                _goodsAcs.SearchInitial(_enterpriseCode, _loginSectionCode, out retMessage, 0); // 2012.02.25 橋本 ADD

                // 商品ディクショナリ生成
                _goodsUnitDataDic = new Dictionary<GoodsKey, GoodsUnitData>();
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD

        /// <summary>
        /// 売上データのリードを行います。（オーバーロード）
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        /// <param name="addUpSrcDetailList">計上元売上明細データオブジェクトリスト</param>
        /// <param name="depsitMain">入金データオブジェクト</param>
        /// <param name="dePositAlwWork">入金引当データオブジェクト</param>
        /// <param name="stockSlipWorkList">仕入データワークオブジェクトリスト</param>
        /// <param name="stockDetailWorkList">仕入明細データワークオブジェクトリスト</param>
        /// <param name="addUpSrcStockDetailList">計上元仕入明細データワークオブジェクトリスト</param>
        /// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        /// <param name="acceptOdrCarList">受注マスタ（車両）オブジェクトリスト</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 DEL
        ////public int ReadDBDataProc( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlip salesSlip, out List<SalesDetail> salesDetailList, out List<SalesDetail> addUpSrcDetailList, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWorkList, out List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList, out List<StockWork> stockWorkList, out List<AcceptOdrCar> acceptOdrCarList )
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
        //public int ReadDBDataProc( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlipWork salesSlip, out List<SalesDetailWork> salesDetailList, out List<SalesDetailWork> addUpSrcDetailList, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWorkList, out List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList, out List<StockWork> stockWorkList, out List<AcceptOdrCarWork> acceptOdrCarList )
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
        public int ReadDBDataProc( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlipWork salesSlip, out List<SalesDetailWork> salesDetailList, out List<SalesDetailWork> addUpSrcDetailList, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWorkList, out List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList, out List<StockWork> stockWorkList, out List<AcceptOdrCarWork> acceptOdrCarList, int readMode )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            salesSlip = null;
            salesDetailList = null;
            addUpSrcDetailList = null;
            depsitMain = null;
            depositAlw = null;
            stockSlipWorkList = null;
            stockDetailWorkList = null;
            addUpSrcStockDetailWorkList = null;
            stockWorkList = null;
            acceptOdrCarList = null;

            // パラメータ
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            IOWriteMAHNBReadWork readPara = new IOWriteMAHNBReadWork();
            readPara.EnterpriseCode = enterpriseCode;
            readPara.AcptAnOdrStatus = acptAnOdrStatus;
            readPara.SalesSlipNum = salesSlipNum;
            paraList.Add(readPara);

            //------------------------------------------------------
            // リモート参照用パラメータ
            //------------------------------------------------------
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // リモート参照用パラメータ
            this.SettingIOWriteCtrlOptWork( OptWorkSettingType.Read, out iOWriteCtrlOptWork ); // リモート参照用パラメータ設定処理
            paraList.Add( iOWriteCtrlOptWork );

            object paraObj = (object)paraList;
            object retObj1;
            object retObj2;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //status = this._iIOWriteControlDB.Read( ref paraObj, out retObj1, out retObj2 );

            if ( _iCustPrtPprWorkDB == null )
            {
                _iCustPrtPprWorkDB = MediationCustPrtPprWorkDB.GetCustPrtPprWorkDB();
            }
            status = this._iCustPrtPprWorkDB.ReadSalesSlip( ref paraObj, out retObj1, out retObj2, readMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD

            CustomSerializeArrayList retList1 = (CustomSerializeArrayList)retObj1;
            CustomSerializeArrayList retList2 = (CustomSerializeArrayList)retObj2;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlipWork salesSlipWork;                                // 売上データワークオブジェクト
                SalesDetailWork[] salesDetailWorkArray;                     // 売上明細データワークオブジェクト配列
                AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray;     // 計上元明細データワークオブジェクト配列
                //DepsitMainWork depsitMainWork;                              // 入金データワークオブジェクト
                DepsitDataWork depsitDataWork;                              // 入金データワークオブジェクト
                DepositAlwWork depositAlwWork;                              // 入金引当データワークオブジェクト
                StockWork[] stockWorkArray;                                 // 在庫ワークデータオブジェクト配列
                AcceptOdrCarWork[] acceptOdrCarWorkArray;                   // 受注マスタ（車両）ワークオブジェクト配列

                // CustomSerializeArrayList分割処理
                this.DivisionCustomSerializeArrayListForAfterRead(retList1, retList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWorkList, out addUpSrcStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 DEL
                //salesSlip = ConvertSalesSlip.UIDataFromParamData(salesSlipWork);
                //salesDetailList = ConvertSalesSlip.UIDataFromParamData(salesDetailWorkArray);
                //addUpSrcDetailList = ConvertSalesSlip.UIDataFromParamData(addUpOrgSalesDetailWorkArray);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
                salesSlip = salesSlipWork;
                if ( salesDetailWorkArray != null )
                {
                    salesDetailList = new List<SalesDetailWork>( salesDetailWorkArray );
                }
                if ( addUpOrgSalesDetailWorkArray != null )
                {
                    addUpSrcDetailList = new List<SalesDetailWork>( addUpOrgSalesDetailWorkArray );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
                //depsitMain = (depsitDataWork != null) ? (SearchDepsitMain)DBAndXMLDataMergeParts.CopyPropertyInClass(depsitMainWork, typeof(SearchDepsitMain)) : new SearchDepsitMain();
                depsitMain = ConvertSalesSlip.UIDataFromParamData(depsitDataWork);
                depositAlw = (depositAlwWork != null) ? (SearchDepositAlw)DBAndXMLDataMergeParts.CopyPropertyInClass(depositAlwWork, typeof(SearchDepositAlw)) : new SearchDepositAlw();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 DEL
                //acceptOdrCarList = ConvertSalesSlip.UIDataFromParamData(acceptOdrCarWorkArray);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
                acceptOdrCarList = new List<AcceptOdrCarWork>( acceptOdrCarWorkArray );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
                if ((stockWorkArray != null) && (stockWorkArray.Length > 0))
                {
                    //if (stockWorkList == null) 
                    stockWorkList = new List<StockWork>();
                    stockWorkList.AddRange(stockWorkArray);
                }

                if (stockSlipWorkList == null) stockSlipWorkList = new List<StockSlipWork>();
                if (stockDetailWorkList == null) stockDetailWorkList = new List<StockDetailWork>();
                if (addUpSrcStockDetailWorkList == null) addUpSrcStockDetailWorkList = new List<AddUpOrgStockDetailWork>();

            }


            return status;
            // 不要
            //this.DataSettingSalesSlipEstimateDef(ref salesSlip, this._salesSlipInputInitDataAcs.GetEstimateDefSet());

//            this.SettingCompleteInfoFromSalesDetailList(salesDetailList);                           // 一式情報セット

        }
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------->>>>>

        /// <summary>
        /// 売上データのリードを行います。（オーバーロード）
        /// </summary>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        /// <param name="addUpSrcDetailList">計上元売上明細データオブジェクトリスト</param>
        /// <param name="depsitMain">入金データオブジェクト</param>
        /// <param name="depositAlw">入金引当データオブジェクト</param>
        /// <param name="stockSlipWorkList">仕入データワークオブジェクトリスト</param>
        /// <param name="stockDetailWorkList">仕入明細データワークオブジェクトリスト</param>
        /// <param name="addUpSrcStockDetailWorkList">計上元仕入明細データワークオブジェクトリスト</param>
        /// <param name="stockWorkList">在庫ワークオブジェクトリスト</param>
        /// <param name="acceptOdrCarList">受注マスタ（車両）オブジェクトリスト</param>
        /// <param name="readMode">履歴区分(0:通常 1:履歴)</param>
        /// <returns>
        /// <br>Update Note: 2022/05/05 仰亮亮</br>
        /// <br>管理番号   : 11870080-00</br>
        /// <br>           : 納品書電子帳簿連携対応</br>
        /// </returns>
        public int ReadDBDataProc2(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out SalesSlipWork salesSlip, out List<SalesDetailWork> salesDetailList, out List<SalesDetailWork> addUpSrcDetailList, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWorkList, out List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList, out List<StockWork> stockWorkList, out List<AcceptOdrCarWork> acceptOdrCarList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            salesSlip = null;
            salesDetailList = null;
            addUpSrcDetailList = null;
            depsitMain = null;
            depositAlw = null;
            stockSlipWorkList = null;
            stockDetailWorkList = null;
            addUpSrcStockDetailWorkList = null;
            stockWorkList = null;
            acceptOdrCarList = null;

            // パラメータ
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            IOWriteMAHNBReadWork readPara = new IOWriteMAHNBReadWork();
            readPara.EnterpriseCode = enterpriseCode;
            readPara.AcptAnOdrStatus = acptAnOdrStatus;
            readPara.SalesSlipNum = salesSlipNum;
            readPara.LogicalDeleteCodeFlg = (int)logicalMode;
            paraList.Add(readPara);

            //------------------------------------------------------
            // リモート参照用パラメータ
            //------------------------------------------------------
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // リモート参照用パラメータ
            this.SettingIOWriteCtrlOptWork(OptWorkSettingType.Read, out iOWriteCtrlOptWork);    // リモート参照用パラメータ設定処理
            paraList.Add(iOWriteCtrlOptWork);

            object paraObj = (object)paraList;
            object retObj1;
            object retObj2;

            if (_iCustPrtPprWorkDB == null)
            {
                _iCustPrtPprWorkDB = MediationCustPrtPprWorkDB.GetCustPrtPprWorkDB();
            }
            status = this._iCustPrtPprWorkDB.ReadSalesSlip(ref paraObj, out retObj1, out retObj2, readMode);

            CustomSerializeArrayList retList1 = (CustomSerializeArrayList)retObj1;
            CustomSerializeArrayList retList2 = (CustomSerializeArrayList)retObj2;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlipWork salesSlipWork;                                // 売上データワークオブジェクト
                SalesDetailWork[] salesDetailWorkArray;                     // 売上明細データワークオブジェクト配列
                AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray;     // 計上元明細データワークオブジェクト配列
                //DepsitMainWork depsitMainWork;                            // 入金データワークオブジェクト
                DepsitDataWork depsitDataWork;                              // 入金データワークオブジェクト
                DepositAlwWork depositAlwWork;                              // 入金引当データワークオブジェクト
                StockWork[] stockWorkArray;                                 // 在庫ワークデータオブジェクト配列
                AcceptOdrCarWork[] acceptOdrCarWorkArray;                   // 受注マスタ（車両）ワークオブジェクト配列

                // CustomSerializeArrayList分割処理
                this.DivisionCustomSerializeArrayListForAfterRead(retList1, retList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWorkList, out addUpSrcStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray);

                salesSlip = salesSlipWork;
                if (salesDetailWorkArray != null)
                {
                    salesDetailList = new List<SalesDetailWork>(salesDetailWorkArray);
                }
                if (addUpOrgSalesDetailWorkArray != null)
                {
                    addUpSrcDetailList = new List<SalesDetailWork>(addUpOrgSalesDetailWorkArray);
                }
                depsitMain = ConvertSalesSlip.UIDataFromParamData(depsitDataWork);
                depositAlw = (depositAlwWork != null) ? (SearchDepositAlw)DBAndXMLDataMergeParts.CopyPropertyInClass(depositAlwWork, typeof(SearchDepositAlw)) : new SearchDepositAlw();
                acceptOdrCarList = new List<AcceptOdrCarWork>(acceptOdrCarWorkArray);
                if ((stockWorkArray != null) && (stockWorkArray.Length > 0))
                {
                    stockWorkList = new List<StockWork>();
                    stockWorkList.AddRange(stockWorkArray);
                }

                if (stockSlipWorkList == null) stockSlipWorkList = new List<StockSlipWork>();
                if (stockDetailWorkList == null) stockDetailWorkList = new List<StockDetailWork>();
                if (addUpSrcStockDetailWorkList == null) addUpSrcStockDetailWorkList = new List<AddUpOrgStockDetailWork>();

            }
            return status;
        }
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿対応　-------<<<<<

        //#region SalesSlip移項処理

        ///// <summary>
        ///// PramData→UIData移項処理
        ///// </summary>
        ///// <param name="salesSlipWork">売上データワークオブジェクト</param>
        ///// <returns>売上データオブジェクト</returns>
        //private SalesSlip UIDataFromParamData(SalesSlipWork salesSlipWork)
        //{
        //    SalesSlip salesSlip = new SalesSlip();

        //    salesSlip.CreateDateTime = salesSlipWork.CreateDateTime; // 作成日時
        //    salesSlip.UpdateDateTime = salesSlipWork.UpdateDateTime; // 更新日時
        //    salesSlip.EnterpriseCode = salesSlipWork.EnterpriseCode; // 企業コード
        //    salesSlip.FileHeaderGuid = salesSlipWork.FileHeaderGuid; // GUID
        //    salesSlip.UpdEmployeeCode = salesSlipWork.UpdEmployeeCode; // 更新従業員コード
        //    salesSlip.UpdAssemblyId1 = salesSlipWork.UpdAssemblyId1; // 更新アセンブリID1
        //    salesSlip.UpdAssemblyId2 = salesSlipWork.UpdAssemblyId2; // 更新アセンブリID2
        //    salesSlip.LogicalDeleteCode = salesSlipWork.LogicalDeleteCode; // 論理削除区分
        //    salesSlip.AcptAnOdrStatus = salesSlipWork.AcptAnOdrStatus; // 受注ステータス
        //    salesSlip.SalesSlipNum = salesSlipWork.SalesSlipNum; // 売上伝票番号
        //    salesSlip.SectionCode = salesSlipWork.SectionCode; // 拠点コード
        //    salesSlip.SubSectionCode = salesSlipWork.SubSectionCode; // 部門コード
        //    salesSlip.DebitNoteDiv = salesSlipWork.DebitNoteDiv; // 赤伝区分
        //    salesSlip.DebitNLnkSalesSlNum = salesSlipWork.DebitNLnkSalesSlNum; // 赤黒連結売上伝票番号
        //    salesSlip.SalesSlipCd = salesSlipWork.SalesSlipCd; // 売上伝票区分
        //    salesSlip.SalesGoodsCd = salesSlipWork.SalesGoodsCd; // 売上商品区分
        //    salesSlip.AccRecDivCd = salesSlipWork.AccRecDivCd; // 売掛区分
        //    salesSlip.SalesInpSecCd = salesSlipWork.SalesInpSecCd; // 売上入力拠点コード
        //    salesSlip.DemandAddUpSecCd = salesSlipWork.DemandAddUpSecCd; // 請求計上拠点コード
        //    salesSlip.ResultsAddUpSecCd = salesSlipWork.ResultsAddUpSecCd; // 実績計上拠点コード
        //    salesSlip.UpdateSecCd = salesSlipWork.UpdateSecCd; // 更新拠点コード
        //    salesSlip.SalesSlipUpdateCd = salesSlipWork.SalesSlipUpdateCd; // 売上伝票更新区分
        //    salesSlip.SearchSlipDate = salesSlipWork.SearchSlipDate; // 伝票検索日付
        //    salesSlip.ShipmentDay = salesSlipWork.ShipmentDay; // 出荷日付
        //    salesSlip.SalesDate = salesSlipWork.SalesDate; // 売上日付
        //    salesSlip.AddUpADate = salesSlipWork.AddUpADate; // 計上日付
        //    salesSlip.DelayPaymentDiv = salesSlipWork.DelayPaymentDiv; // 来勘区分
        //    salesSlip.EstimateFormNo = salesSlipWork.EstimateFormNo; // 見積書番号
        //    salesSlip.EstimateDivide = salesSlipWork.EstimateDivide; // 見積区分
        //    salesSlip.InputAgenCd = salesSlipWork.InputAgenCd; // 入力担当者コード
        //    salesSlip.InputAgenNm = salesSlipWork.InputAgenNm; // 入力担当者名称
        //    salesSlip.SalesInputCode = salesSlipWork.SalesInputCode; // 売上入力者コード
        //    salesSlip.SalesInputName = salesSlipWork.SalesInputName; // 売上入力者名称
        //    salesSlip.FrontEmployeeCd = salesSlipWork.FrontEmployeeCd; // 受付従業員コード
        //    salesSlip.FrontEmployeeNm = salesSlipWork.FrontEmployeeNm; // 受付従業員名称
        //    salesSlip.SalesEmployeeCd = salesSlipWork.SalesEmployeeCd; // 販売従業員コード
        //    salesSlip.SalesEmployeeNm = salesSlipWork.SalesEmployeeNm; // 販売従業員名称
        //    salesSlip.TotalAmountDispWayCd = salesSlipWork.TotalAmountDispWayCd; // 総額表示方法区分
        //    salesSlip.TtlAmntDispRateApy = salesSlipWork.TtlAmntDispRateApy; // 総額表示掛率適用区分
        //    salesSlip.SalesTotalTaxInc = salesSlipWork.SalesTotalTaxInc; // 売上伝票合計（税込み）
        //    salesSlip.SalesTotalTaxExc = salesSlipWork.SalesTotalTaxExc; // 売上伝票合計（税抜き）
        //    salesSlip.SalesPrtTotalTaxInc = salesSlipWork.SalesPrtTotalTaxInc; // 売上部品合計（税込み）
        //    salesSlip.SalesPrtTotalTaxExc = salesSlipWork.SalesPrtTotalTaxExc; // 売上部品合計（税抜き）
        //    salesSlip.SalesWorkTotalTaxInc = salesSlipWork.SalesWorkTotalTaxInc; // 売上作業合計（税込み）
        //    salesSlip.SalesWorkTotalTaxExc = salesSlipWork.SalesWorkTotalTaxExc; // 売上作業合計（税抜き）
        //    salesSlip.SalesSubtotalTaxInc = salesSlipWork.SalesSubtotalTaxInc; // 売上小計（税込み）
        //    salesSlip.SalesSubtotalTaxExc = salesSlipWork.SalesSubtotalTaxExc; // 売上小計（税抜き）
        //    salesSlip.SalesPrtSubttlInc = salesSlipWork.SalesPrtSubttlInc; // 売上部品小計（税込み）
        //    salesSlip.SalesPrtSubttlExc = salesSlipWork.SalesPrtSubttlExc; // 売上部品小計（税抜き）
        //    salesSlip.SalesWorkSubttlInc = salesSlipWork.SalesWorkSubttlInc; // 売上作業小計（税込み）
        //    salesSlip.SalesWorkSubttlExc = salesSlipWork.SalesWorkSubttlExc; // 売上作業小計（税抜き）
        //    salesSlip.SalesNetPrice = salesSlipWork.SalesNetPrice; // 売上正価金額
        //    salesSlip.SalesSubtotalTax = salesSlipWork.SalesSubtotalTax; // 売上小計（税）
        //    salesSlip.ItdedSalesOutTax = salesSlipWork.ItdedSalesOutTax; // 売上外税対象額
        //    salesSlip.ItdedSalesInTax = salesSlipWork.ItdedSalesInTax; // 売上内税対象額
        //    salesSlip.SalSubttlSubToTaxFre = salesSlipWork.SalSubttlSubToTaxFre; // 売上小計非課税対象額
        //    salesSlip.SalesOutTax = salesSlipWork.SalesOutTax; // 売上金額消費税額（外税）
        //    salesSlip.SalAmntConsTaxInclu = salesSlipWork.SalAmntConsTaxInclu; // 売上金額消費税額（内税）
        //    salesSlip.SalesDisTtlTaxExc = salesSlipWork.SalesDisTtlTaxExc; // 売上値引金額計（税抜き）
        //    salesSlip.ItdedSalesDisOutTax = salesSlipWork.ItdedSalesDisOutTax; // 売上値引外税対象額合計
        //    salesSlip.ItdedSalesDisInTax = salesSlipWork.ItdedSalesDisInTax; // 売上値引内税対象額合計
        //    salesSlip.ItdedPartsDisOutTax = salesSlipWork.ItdedPartsDisOutTax; // 部品値引対象額合計（税抜き）
        //    salesSlip.ItdedPartsDisInTax = salesSlipWork.ItdedPartsDisInTax; // 部品値引対象額合計（税込み）
        //    salesSlip.ItdedWorkDisOutTax = salesSlipWork.ItdedWorkDisOutTax; // 作業値引対象額合計（税抜き）
        //    salesSlip.ItdedWorkDisInTax = salesSlipWork.ItdedWorkDisInTax; // 作業値引対象額合計（税込み）
        //    salesSlip.ItdedSalesDisTaxFre = salesSlipWork.ItdedSalesDisTaxFre; // 売上値引非課税対象額合計
        //    salesSlip.SalesDisOutTax = salesSlipWork.SalesDisOutTax; // 売上値引消費税額（外税）
        //    salesSlip.SalesDisTtlTaxInclu = salesSlipWork.SalesDisTtlTaxInclu; // 売上値引消費税額（内税）
        //    salesSlip.PartsDiscountRate = salesSlipWork.PartsDiscountRate; // 部品値引率
        //    salesSlip.RavorDiscountRate = salesSlipWork.RavorDiscountRate; // 工賃値引率
        //    salesSlip.TotalCost = salesSlipWork.TotalCost; // 原価金額計
        //    salesSlip.ConsTaxLayMethod = salesSlipWork.ConsTaxLayMethod; // 消費税転嫁方式
        //    salesSlip.ConsTaxRate = salesSlipWork.ConsTaxRate; // 消費税税率
        //    salesSlip.FractionProcCd = salesSlipWork.FractionProcCd; // 端数処理区分
        //    salesSlip.AccRecConsTax = salesSlipWork.AccRecConsTax; // 売掛消費税
        //    salesSlip.AutoDepositCd = salesSlipWork.AutoDepositCd; // 自動入金区分
        //    salesSlip.AutoDepositSlipNo = salesSlipWork.AutoDepositSlipNo; // 自動入金伝票番号
        //    salesSlip.DepositAllowanceTtl = salesSlipWork.DepositAllowanceTtl; // 入金引当合計額
        //    salesSlip.DepositAlwcBlnce = salesSlipWork.DepositAlwcBlnce; // 入金引当残高
        //    salesSlip.ClaimCode = salesSlipWork.ClaimCode; // 請求先コード
        //    salesSlip.ClaimSnm = salesSlipWork.ClaimSnm; // 請求先略称
        //    salesSlip.CustomerCode = salesSlipWork.CustomerCode; // 得意先コード
        //    salesSlip.CustomerName = salesSlipWork.CustomerName; // 得意先名称
        //    salesSlip.CustomerName2 = salesSlipWork.CustomerName2; // 得意先名称2
        //    salesSlip.CustomerSnm = salesSlipWork.CustomerSnm; // 得意先略称
        //    salesSlip.HonorificTitle = salesSlipWork.HonorificTitle; // 敬称
        //    salesSlip.OutputNameCode = salesSlipWork.OutputNameCode; // 諸口コード
        //    salesSlip.OutputName = salesSlipWork.OutputName; // 諸口名称
        //    salesSlip.CustSlipNo = salesSlipWork.CustSlipNo; // 得意先伝票番号
        //    salesSlip.SlipAddressDiv = salesSlipWork.SlipAddressDiv; // 伝票住所区分
        //    salesSlip.AddresseeCode = salesSlipWork.AddresseeCode; // 納品先コード
        //    salesSlip.AddresseeName = salesSlipWork.AddresseeName; // 納品先名称
        //    salesSlip.AddresseeName2 = salesSlipWork.AddresseeName2; // 納品先名称2
        //    salesSlip.AddresseePostNo = salesSlipWork.AddresseePostNo; // 納品先郵便番号
        //    salesSlip.AddresseeAddr1 = salesSlipWork.AddresseeAddr1; // 納品先住所1(都道府県市区郡・町村・字)
        //    salesSlip.AddresseeAddr3 = salesSlipWork.AddresseeAddr3; // 納品先住所3(番地)
        //    salesSlip.AddresseeAddr4 = salesSlipWork.AddresseeAddr4; // 納品先住所4(アパート名称)
        //    salesSlip.AddresseeTelNo = salesSlipWork.AddresseeTelNo; // 納品先電話番号
        //    salesSlip.AddresseeFaxNo = salesSlipWork.AddresseeFaxNo; // 納品先FAX番号
        //    salesSlip.PartySaleSlipNum = salesSlipWork.PartySaleSlipNum; // 相手先伝票番号
        //    salesSlip.SlipNote = salesSlipWork.SlipNote; // 伝票備考
        //    salesSlip.SlipNote2 = salesSlipWork.SlipNote2; // 伝票備考２
        //    salesSlip.SlipNote3 = salesSlipWork.SlipNote3; // 伝票備考３
        //    salesSlip.RetGoodsReasonDiv = salesSlipWork.RetGoodsReasonDiv; // 返品理由コード
        //    salesSlip.RetGoodsReason = salesSlipWork.RetGoodsReason; // 返品理由
        //    salesSlip.RegiProcDate = salesSlipWork.RegiProcDate; // レジ処理日
        //    salesSlip.CashRegisterNo = salesSlipWork.CashRegisterNo; // レジ番号
        //    salesSlip.PosReceiptNo = salesSlipWork.PosReceiptNo; // POSレシート番号
        //    salesSlip.DetailRowCount = salesSlipWork.DetailRowCount; // 明細行数
        //    salesSlip.EdiSendDate = salesSlipWork.EdiSendDate; // ＥＤＩ送信日
        //    salesSlip.EdiTakeInDate = salesSlipWork.EdiTakeInDate; // ＥＤＩ取込日
        //    salesSlip.UoeRemark1 = salesSlipWork.UoeRemark1; // ＵＯＥリマーク１
        //    salesSlip.UoeRemark2 = salesSlipWork.UoeRemark2; // ＵＯＥリマーク２
        //    salesSlip.SlipPrintDivCd = salesSlipWork.SlipPrintDivCd; // 伝票発行区分
        //    salesSlip.SlipPrintFinishCd = salesSlipWork.SlipPrintFinishCd; // 伝票発行済区分
        //    salesSlip.SalesSlipPrintDate = salesSlipWork.SalesSlipPrintDate; // 売上伝票発行日
        //    salesSlip.BusinessTypeCode = salesSlipWork.BusinessTypeCode; // 業種コード
        //    salesSlip.BusinessTypeName = salesSlipWork.BusinessTypeName; // 業種名称
        //    salesSlip.OrderNumber = salesSlipWork.OrderNumber; // 発注番号
        //    salesSlip.DeliveredGoodsDiv = salesSlipWork.DeliveredGoodsDiv; // 納品区分
        //    salesSlip.DeliveredGoodsDivNm = salesSlipWork.DeliveredGoodsDivNm; // 納品区分名称
        //    salesSlip.SalesAreaCode = salesSlipWork.SalesAreaCode; // 販売エリアコード
        //    salesSlip.SalesAreaName = salesSlipWork.SalesAreaName; // 販売エリア名称
        //    salesSlip.ReconcileFlag = salesSlipWork.ReconcileFlag; // 消込フラグ
        //    salesSlip.SlipPrtSetPaperId = salesSlipWork.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
        //    salesSlip.CompleteCd = salesSlipWork.CompleteCd; // 一式伝票区分
        //    salesSlip.SalesPriceFracProcCd = salesSlipWork.SalesPriceFracProcCd; // 売上金額端数処理区分
        //    salesSlip.StockGoodsTtlTaxExc = salesSlipWork.StockGoodsTtlTaxExc; // 在庫商品合計金額（税抜）
        //    salesSlip.PureGoodsTtlTaxExc = salesSlipWork.PureGoodsTtlTaxExc; // 純正商品合計金額（税抜）
        //    salesSlip.ListPricePrintDiv = salesSlipWork.ListPricePrintDiv; // 定価印刷区分
        //    salesSlip.EraNameDispCd1 = salesSlipWork.EraNameDispCd1; // 元号表示区分１
        //    salesSlip.EstimaTaxDivCd = salesSlipWork.EstimaTaxDivCd; // 見積消費税区分
        //    salesSlip.EstimateFormPrtCd = salesSlipWork.EstimateFormPrtCd; // 見積書印刷区分
        //    salesSlip.EstimateSubject = salesSlipWork.EstimateSubject; // 見積件名
        //    salesSlip.Footnotes1 = salesSlipWork.Footnotes1; // 脚注１
        //    salesSlip.Footnotes2 = salesSlipWork.Footnotes2; // 脚注２
        //    salesSlip.EstimateTitle1 = salesSlipWork.EstimateTitle1; // 見積タイトル１
        //    salesSlip.EstimateTitle2 = salesSlipWork.EstimateTitle2; // 見積タイトル２
        //    salesSlip.EstimateTitle3 = salesSlipWork.EstimateTitle3; // 見積タイトル３
        //    salesSlip.EstimateTitle4 = salesSlipWork.EstimateTitle4; // 見積タイトル４
        //    salesSlip.EstimateTitle5 = salesSlipWork.EstimateTitle5; // 見積タイトル５
        //    salesSlip.EstimateNote1 = salesSlipWork.EstimateNote1; // 見積備考１
        //    salesSlip.EstimateNote2 = salesSlipWork.EstimateNote2; // 見積備考２
        //    salesSlip.EstimateNote3 = salesSlipWork.EstimateNote3; // 見積備考３
        //    salesSlip.EstimateNote4 = salesSlipWork.EstimateNote4; // 見積備考４
        //    salesSlip.EstimateNote5 = salesSlipWork.EstimateNote5; // 見積備考５
        //    salesSlip.EstimateValidityDate = salesSlipWork.EstimateValidityDate; // 見積有効期限
        //    salesSlip.PartsNoPrtCd = salesSlipWork.PartsNoPrtCd; // 品番印字区分
        //    salesSlip.OptionPringDivCd = salesSlipWork.OptionPringDivCd; // オプション印字区分
        //    salesSlip.RateUseCode = salesSlipWork.RateUseCode; // 掛率使用区分
        //    //salesSlip.InputMode = salesSlipWork.InputMode; // 入力モード
        //    //salesSlip.SalesSlipDisplay = salesSlipWork.SalesSlipDisplay; // 売上伝票区分(画面表示用)
        //    //salesSlip.AcptAnOdrStatusDisplay = salesSlipWork.AcptAnOdrStatusDisplay; // 受注ステータス
        //    //salesSlip.CustRateGrpCode = salesSlipWork.CustRateGrpCode; // 得意先掛率グループコード
        //    //salesSlip.ClaimName = salesSlipWork.ClaimName; // 請求先名称
        //    //salesSlip.ClaimName2 = salesSlipWork.ClaimName2; // 請求先名称２
        //    //salesSlip.CreditMngCode = salesSlipWork.CreditMngCode; // 与信管理区分
        //    //salesSlip.TotalDay = salesSlipWork.TotalDay; // 締日
        //    //salesSlip.NTimeCalcStDate = salesSlipWork.NTimeCalcStDate; // 次回勘定開始日
        //    //salesSlip.TotalMoneyForGrossProfit = salesSlipWork.TotalMoneyForGrossProfit; // 粗利計算用売上金額
        //    //salesSlip.AcceptAnOrderDate = salesSlipWork.AcceptAnOrderDate; // 受注日
        //    //salesSlip.SectionName = salesSlipWork.SectionName; // 拠点名称
        //    //salesSlip.SubSectionName = salesSlipWork.SubSectionName; // 部門名称
        //    //salesSlip.CarMngDivCd = salesSlipWork.CarMngDivCd; // 車輌管理区分
        //    //salesSlip.SearchMode = salesSlipWork.SearchMode; // 部品検索モード
        //    //salesSlip.SearchCarMode = salesSlipWork.SearchCarMode; // 車両検索モード

        //    return salesSlip;
        //}

        //#endregion

        //#region SalesDetail移項処理

        ///// <summary>
        ///// PramData→UIData移項処理
        ///// </summary>
        ///// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        ///// <returns>売上明細データオブジェクトリスト</returns>
        //private List<SalesDetail> UIDataFromParamData(SalesDetailWork[] salesDetailWorkArray)
        //{
        //    if (salesDetailWorkArray == null) return null;

        //    List<SalesDetail> salesDetailList = new List<SalesDetail>();

        //    foreach (SalesDetailWork salesDetailWork in salesDetailWorkArray)
        //    {
        //        salesDetailList.Add(UIDataFromParamData(salesDetailWork));
        //    }

        //    return salesDetailList;
        //}

        //#endregion

        //#region AddUpSalesDetyail移項処理

        ///// <summary>
        ///// PramData→UIData移項処理
        ///// </summary>
        ///// <param name="addUppSrcStockDetailWorkList">計上元仕入明細データワークオブジェクト配列</param>
        ///// <returns>売上明細データオブジェクトリスト</returns>
        //private List<SalesDetail> UIDataFromParamData(AddUpOrgSalesDetailWork[] addUpSrcSalesDetailWorkList)
        //{
        //    if (addUpSrcSalesDetailWorkList == null) return null;

        //    List<SalesDetail> addUpOrgSalesDetailList = new List<SalesDetail>();

        //    foreach (AddUpOrgSalesDetailWork addUpSrcSalesDetailWork in addUpSrcSalesDetailWorkList)
        //    {
        //        addUpOrgSalesDetailList.Add(UIDataFromParamData((SalesDetailWork)addUpSrcSalesDetailWork));
        //    }

        //    return addUpOrgSalesDetailList;
        //}

        //#endregion

        //#region AccestOdrCarList移項処理

        ///// <summary>
        ///// PramData→UIData移行処理
        ///// </summary>
        ///// <param name="acceptOdrCarWorkList">受注マスタ（車両）ワークオブジェクト配列</param>
        ///// <returns>受注マスタ（車両）オブジェクトリスト</returns>
        //private List<AcceptOdrCar> UIDataFromParamData(AcceptOdrCarWork[] acceptOdrCarWorkList)
        //{
        //    if (acceptOdrCarWorkList == null) return null;

        //    List<AcceptOdrCar> acceptOdrCarList = new List<AcceptOdrCar>();

        //    foreach (AcceptOdrCarWork acceptOdrCarWork in acceptOdrCarWorkList)
        //    {
        //        acceptOdrCarList.Add(UIDataFromParamData(acceptOdrCarWork));
        //    }

        //    return acceptOdrCarList;
        //}

        //#endregion

        //#region 見積初期値設定情報設定処理
        /////// <summary>
        /////// 見積初期値設定情報設定処理
        /////// </summary>
        /////// <param name="salesSlip"></param>
        /////// <param name="estimateDefSet"></param>
        ////public void DataSettingSalesSlipEstimateDef(ref SalesSlip salesSlip, EstimateDefSet estimateDefSet)
        ////{
        ////    if (estimateDefSet == null) return;

        ////    salesSlip.ListPricePrintDiv = estimateDefSet.ListPricePrintDiv;     // 定価印刷区分
        ////    salesSlip.EstimaTaxDivCd = estimateDefSet.ConsTaxPrintDiv;          // 税表示区分

        ////    salesSlip.EstimateNote1 = estimateDefSet.EstimateNote1;             // 見積書備考１
        ////    salesSlip.EstimateNote2 = estimateDefSet.EstimateNote2;             // 見積書備考２
        ////    salesSlip.EstimateNote3 = estimateDefSet.EstimateNote3;             // 見積書備考３
        ////    salesSlip.EstimateTitle1 = estimateDefSet.EstimateTitle1;           // 見積タイトル１
        ////}
        //#endregion // 見積初期値設定情報設定処理

        //#region DepositData移項処理

        ///// <summary>
        ///// PramData→UIData移項処理
        ///// </summary>
        ///// <param name="depsitDataWork">入金ワークオブジェクト</param>
        ///// <returns>入金データオブジェクト</returns>
        //private SearchDepsitMain UIDataFromParamData(DepsitDataWork depsitDataWork)
        //{
        //    SearchDepsitMain searchDepsitMain = new SearchDepsitMain();
        //    DepsitMainWork depsitMainWork;
        //    DepsitDtlWork[] depsitDtlWorkArray;

        //    DepsitDataUtil.Division(depsitDataWork, out depsitMainWork, out depsitDtlWorkArray);
        //    searchDepsitMain.CreateDateTime = depsitMainWork.CreateDateTime; // 作成日時
        //    searchDepsitMain.UpdateDateTime = depsitMainWork.UpdateDateTime; // 更新日時
        //    searchDepsitMain.EnterpriseCode = depsitMainWork.EnterpriseCode; // 企業コード
        //    searchDepsitMain.FileHeaderGuid = depsitMainWork.FileHeaderGuid; // GUID
        //    searchDepsitMain.UpdEmployeeCode = depsitMainWork.UpdEmployeeCode; // 更新従業員コード
        //    searchDepsitMain.UpdAssemblyId1 = depsitMainWork.UpdAssemblyId1; // 更新アセンブリID1
        //    searchDepsitMain.UpdAssemblyId2 = depsitMainWork.UpdAssemblyId2; // 更新アセンブリID2
        //    searchDepsitMain.LogicalDeleteCode = depsitMainWork.LogicalDeleteCode; // 論理削除区分
        //    searchDepsitMain.AcptAnOdrStatus = depsitMainWork.AcptAnOdrStatus; // 受注ステータス
        //    searchDepsitMain.DepositDebitNoteCd = depsitMainWork.DepositDebitNoteCd; // 入金赤黒区分
        //    searchDepsitMain.DepositSlipNo = depsitMainWork.DepositSlipNo; // 入金伝票番号
        //    searchDepsitMain.SalesSlipNum = depsitMainWork.SalesSlipNum; // 売上伝票番号
        //    searchDepsitMain.InputDepositSecCd = depsitMainWork.InputDepositSecCd; // 入金入力拠点コード
        //    searchDepsitMain.AddUpSecCode = depsitMainWork.AddUpSecCode; // 計上拠点コード
        //    searchDepsitMain.UpdateSecCd = depsitMainWork.UpdateSecCd; // 更新拠点コード
        //    searchDepsitMain.SubSectionCode = depsitMainWork.SubSectionCode; // 部門コード
        //    searchDepsitMain.DepositDate = depsitMainWork.DepositDate; // 入金日付
        //    searchDepsitMain.AddUpADate = depsitMainWork.AddUpADate; // 計上日付
        //    searchDepsitMain.DepositTotal = depsitMainWork.DepositTotal; // 入金計
        //    searchDepsitMain.Deposit = depsitMainWork.Deposit; // 入金金額
        //    searchDepsitMain.FeeDeposit = depsitMainWork.FeeDeposit; // 手数料入金額
        //    searchDepsitMain.DiscountDeposit = depsitMainWork.DiscountDeposit; // 値引入金額
        //    searchDepsitMain.AutoDepositCd = depsitMainWork.AutoDepositCd; // 自動入金区分
        //    searchDepsitMain.DraftDrawingDate = depsitMainWork.DraftDrawingDate; // 手形振出日
        //    searchDepsitMain.DraftKind = depsitMainWork.DraftKind; // 手形種類
        //    searchDepsitMain.DraftKindName = depsitMainWork.DraftKindName; // 手形種類名称
        //    searchDepsitMain.DraftDivide = depsitMainWork.DraftDivide; // 手形区分
        //    searchDepsitMain.DraftDivideName = depsitMainWork.DraftDivideName; // 手形区分名称
        //    searchDepsitMain.DraftNo = depsitMainWork.DraftNo; // 手形番号
        //    searchDepsitMain.DepositAllowance = depsitMainWork.DepositAllowance; // 入金引当額
        //    searchDepsitMain.DepositAlwcBlnce = depsitMainWork.DepositAlwcBlnce; // 入金引当残高
        //    searchDepsitMain.DebitNoteLinkDepoNo = depsitMainWork.DebitNoteLinkDepoNo; // 赤黒入金連結番号
        //    searchDepsitMain.LastReconcileAddUpDt = depsitMainWork.LastReconcileAddUpDt; // 最終消し込み計上日
        //    searchDepsitMain.DepositAgentCode = depsitMainWork.DepositAgentCode; // 入金担当者コード
        //    searchDepsitMain.DepositAgentNm = depsitMainWork.DepositAgentNm; // 入金担当者名称
        //    searchDepsitMain.DepositInputAgentCd = depsitMainWork.DepositInputAgentCd; // 入金入力者コード
        //    searchDepsitMain.DepositInputAgentNm = depsitMainWork.DepositInputAgentNm; // 入金入力者名称
        //    searchDepsitMain.CustomerCode = depsitMainWork.CustomerCode; // 得意先コード
        //    searchDepsitMain.CustomerName = depsitMainWork.CustomerName; // 得意先名称
        //    searchDepsitMain.CustomerName2 = depsitMainWork.CustomerName2; // 得意先名称2
        //    searchDepsitMain.CustomerSnm = depsitMainWork.CustomerSnm; // 得意先略称
        //    searchDepsitMain.ClaimCode = depsitMainWork.ClaimCode; // 請求先コード
        //    searchDepsitMain.ClaimName = depsitMainWork.ClaimName; // 請求先名称
        //    searchDepsitMain.ClaimName2 = depsitMainWork.ClaimName2; // 請求先名称2
        //    searchDepsitMain.ClaimSnm = depsitMainWork.ClaimSnm; // 請求先略称
        //    searchDepsitMain.Outline = depsitMainWork.Outline; // 伝票摘要
        //    searchDepsitMain.BankCode = depsitMainWork.BankCode; // 銀行コード
        //    searchDepsitMain.BankName = depsitMainWork.BankName; // 銀行名称

        //    //searchDepsitMain.CreateDateTime = depsitDtlWorkArray[0].CreateDateTime; // 作成日時
        //    //searchDepsitMain.UpdateDateTime = depsitDtlWorkArray[0].UpdateDateTime; // 更新日時
        //    //searchDepsitMain.EnterpriseCode = depsitDtlWorkArray[0].EnterpriseCode; // 企業コード
        //    //searchDepsitMain.FileHeaderGuid = depsitDtlWorkArray[0].FileHeaderGuid; // GUID
        //    //searchDepsitMain.UpdEmployeeCode = depsitDtlWorkArray[0].UpdEmployeeCode; // 更新従業員コード
        //    //searchDepsitMain.UpdAssemblyId1 = depsitDtlWorkArray[0].UpdAssemblyId1; // 更新アセンブリID1
        //    //searchDepsitMain.UpdAssemblyId2 = depsitDtlWorkArray[0].UpdAssemblyId2; // 更新アセンブリID2
        //    //searchDepsitMain.LogicalDeleteCode = depsitDtlWorkArray[0].LogicalDeleteCode; // 論理削除区分
        //    //searchDepsitMain.AcptAnOdrStatus = depsitDtlWorkArray[0].AcptAnOdrStatus; // 受注ステータス
        //    //searchDepsitMain.DepositSlipNo = depsitDtlWorkArray[0].DepositSlipNo; // 入金伝票番号

        //    if (depsitDtlWorkArray != null)
        //    {
        //        for (int i = 0; i < depsitDtlWorkArray.Length; i++)
        //        {
        //            searchDepsitMain.DepositRowNo[i] = depsitDtlWorkArray[i].DepositRowNo; // 入金行番号
        //            searchDepsitMain.MoneyKindCode[i] = depsitDtlWorkArray[i].MoneyKindCode; // 金種コード
        //            searchDepsitMain.MoneyKindName[i] = depsitDtlWorkArray[i].MoneyKindName; // 金種名称
        //            searchDepsitMain.MoneyKindDiv[i] = depsitDtlWorkArray[i].MoneyKindDiv; // 金種区分
        //            searchDepsitMain.DepositDtl[i] = depsitDtlWorkArray[i].Deposit; // 入金金額
        //            searchDepsitMain.ValidityTerm[i] = depsitDtlWorkArray[i].ValidityTerm; // 有効期限
        //        }
        //    }

        //    return searchDepsitMain;
        //}

        //#endregion

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（Read後専用）
        /// </summary>
        /// <param name="paraList1">カスタムシリアライズリストオブジェクト(親データ)</param>
        /// <param name="paraList2">カスタムシリアライズリストオブジェクト(計上元／同時入力データ)</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockSlipWorkList">同時入力データワークオブジェクトリスト</param>
        /// <param name="stockDetailWrokList">同時入力明細データワークオブジェクトリスト</param>
        /// <param name="addUpOrgStockDetailWorkList">同時入力計上元仕入明細データワークリスト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayListForAfterRead(CustomSerializeArrayList paraList1, CustomSerializeArrayList paraList2, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWrokList, out List<AddUpOrgStockDetailWork> addUpOrgStockDetailWorkList, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            //-----------------------------------------------------------------------------------------------------------------------
            // ParaList構成
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                売上情報リスト(第１パラメータ ParaList1)
            //    --SalesSlipWork                       売上データ                              →親データ
            //    --ArrayList                           売上明細リスト
            //        --SalesDetailWork                 売上明細データ                          →親データ
            //    --ArrayList                           計上元明細リスト
            //        --AddUppOrgSalesDetailWork        計上元明細データ                        →参照のみ(残数チェック)
            //    --DepsitDataWork                      入金データ                              →親データ同時修正可能
            //    --DepositAlwWork                      入金引当データ                          →親データ同時修正可能
            //    --ArrayList                           在庫ワークリスト                        
            //        --StockWork                       在庫ワークデータ                        →参照のみ(現在庫数セット)
            //    --ArrayList                           受注マスタ（車両）リスト
            //        --AcceptOdrCar                    受注マスタ（車両）
            //-----------------------------------------------------------------------------------------------------------------------
            //  CustomSerializeArrayList                計上元／同時入力リスト(第２パラメータ ParaList2)
            //    --CustomSerializeArrayList            計上元情報リスト(出荷、受注、見積)
            //      --SalesSlipWork                     計上元データ                            →親データ同時修正可(見積のみ)
            //      --ArrayList                         計上元明細リスト
            //          --SalesDetailWork               計上元明細データ                        →親データ同時修正可(見積のみ)
            //      --ArrayList                         計上元元明細リスト
            //          --AddUppOrgSalesDetailWork      計上元元明細データ                      →未使用(見積時は未セットとなる為)
            //      --DepsitMainWork                    計上元入金データ                        →未使用(見積時は未セットとなる為)
            //      --DepositAlwWork                    計上元入金引当データ                    →未使用(見積時は未セットとなる為)
            //      --ArrayList                         計上元在庫ワークリスト                        
            //          --StockWork                     計上元在庫ワークデータ                  →未使用
            //------------------------------------------
            //    --CustomSerializeArrayList            同時入力リスト(仕入、出荷、発注)
            //      --StockSlipWork                     同時入力データ                          →親データ同時修正可(受発注のみ)
            //      --ArrayList                         同時入力明細リスト
            //          --StockDetailWork               同時入力明細データ                      →親データ同時修正可(受発注のみ)
            //      --ArrayList                         同時入力計上元明細リスト
            //          --AddUpOrgStockDetailWork       同時入力計上元明細データ                →未使用(発注時は未セットとなる為)
            //      --PaymentSlpWork                    同時入力支払データ                      →親データ同時削除可
            //      --ArrayList                         同時入力在庫ワークリスト                        
            //          --StockWork                     同時入力在庫ワークデータ                →未使用
            //------------------------------------------
            //    --CustomSerializeArrayList            同時入力計上元リスト(出荷、発注)
            //      --StockSlipWork                     同時入力計上元データ                    →未使用
            //      --ArrayList                         同時入力計上元明細リスト
            //          --StockDetailWork               同時入力計上元明細データ                →未使用
            //      --ArrayList                         同時入力計上元元明細リスト
            //          --AddUpOrgStockDetailWork       同時入力計上元元明細データ              →未使用
            //      --PaymentSlpWork                    同時入力計上元支払データ                →未使用
            //      --ArrayList                         同時入力計上元在庫ワークリスト                        
            //          --StockWork                     同時入力計上元在庫ワークデータ          →未使用
            //-----------------------------------------------------------------------------------------------------------------------

            salesSlipWork = null;                                                   // 売上データワークオブジェクト
            salesDetailWorkArray = null;                                            // 売上明細データワークオブジェクト配列
            addUpOrgSalesDetailWorkArray = null;                                    // 計上元明細データワークオブジェクト配列
            depsitDataWork = null;                                                  // 入金データワークオブジェクト
            depositAlwWork = null;                                                  // 入金引当データワークオブジェクト
            stockWorkArray = null;                                                  // 在庫ワークオブジェクト配列
            stockSlipWorkList = new List<StockSlipWork>();                          // 同時入力データワークオブジェクトリスト
            stockDetailWrokList = new List<StockDetailWork>();                      // 同時入力明細データワークオブジェクトリスト
            addUpOrgStockDetailWorkList = new List<AddUpOrgStockDetailWork>();     // 同時入力計上元仕入明細データワークオブジェクトリスト
            acceptOdrCarWorkArray = null;                                           // 受注マスタ（車両）ワークオブジェクト配列

            SalesSlipWork tempSalesSlipWork = null;                                 // 売上データワークオブジェクト
            SalesDetailWork[] tempSalesDetailWorkArray = null;                      // 売上明細データワークオブジェクト配列
            AddUpOrgSalesDetailWork[] tempAddUpOrgSalesDetailWorkArray = null;      // 計上元明細データワークオブジェクト配列
            DepsitDataWork tempDepsitDataWork = null;                               // 入金データワークオブジェクト
            DepositAlwWork tempDepositAlwWork = null;                               // 入金引当データワークオブジェクト
            StockWork[] tempStockWorkArray = null;                                  // 在庫ワークオブジェクト配列
            StockSlipWork tempStockSlipWork = null;                                 // 同時入力データワークオブジェクト
            StockDetailWork[] tempStockDetailWorkArray = null;                      // 同時入力明細データワークオブジェクト配列
            AddUpOrgStockDetailWork[] tempAddUpOrgStockDetailWorkArray = null;      // 同時入力計上元明細データワークオブジェクト配列
            AcceptOdrCarWork[] tempAcceptOdrCarWorkArray = null;                    // 受注マスタ（車両）ワークオブジェクト配列

            //---------------------------------------------------
            // 親データ分割（売上情報リスト）
            //---------------------------------------------------
            this.DivisionCustomSerializeArrayList(paraList1, out tempSalesSlipWork, out tempSalesDetailWorkArray, out tempAddUpOrgSalesDetailWorkArray, out tempDepsitDataWork, out tempDepositAlwWork, out tempStockWorkArray, out tempAcceptOdrCarWorkArray);
            salesSlipWork = tempSalesSlipWork;
            salesDetailWorkArray = tempSalesDetailWorkArray;
            addUpOrgSalesDetailWorkArray = tempAddUpOrgSalesDetailWorkArray;
            depsitDataWork = tempDepsitDataWork;
            depositAlwWork = tempDepositAlwWork;
            stockWorkArray = tempStockWorkArray;
            acceptOdrCarWorkArray = tempAcceptOdrCarWorkArray;

            //---------------------------------------------------
            // 計上元／同時入力リスト分割
            //---------------------------------------------------
            for (int i = 0; i < paraList2.Count; i++)
            {
                if (paraList2[i] is CustomSerializeArrayList)
                {

                    CustomSerializeArrayList tempList = (CustomSerializeArrayList)paraList2[i];
                    foreach (object tempObj in tempList)
                    {
                        //---------------------------------------------------
                        // 同時入力データ
                        //---------------------------------------------------
                        if (tempObj is ArrayList)
                        {
                            ArrayList tempArrayList = (ArrayList)tempObj;
                            foreach (object detailObj in tempArrayList)
                            {
                                if (detailObj is StockDetailWork)
                                {
                                    StockDetailWork tempWork = (StockDetailWork)detailObj;
                                    if ((tempWork.SalesSlipDtlNumSync != 0) && (tempWork.StockSlipDtlNumSrc == 0))
                                    {
                                        this.DivisionCustomSerializeArrayList(tempList, out tempStockSlipWork, out tempStockDetailWorkArray, out tempAddUpOrgStockDetailWorkArray, out tempStockWorkArray);
                                        if (tempStockSlipWork != null)
                                        {
                                            stockSlipWorkList.Add(tempStockSlipWork);
                                            stockDetailWrokList.AddRange(tempStockDetailWorkArray);
                                        }
                                        if (tempAddUpOrgStockDetailWorkArray != null)
                                        {
                                            addUpOrgStockDetailWorkList.AddRange(tempAddUpOrgStockDetailWorkArray);
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（仕入情報用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="stockSlipWork">仕入データワークオブジェクト</param>
        /// <param name="stockDetailWorkArray">仕入明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgStockDetailWorkArray">計上元仕入明細データワークオブジェクト配列</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out StockSlipWork stockSlipWork, out StockDetailWork[] stockDetailWorkArray, out AddUpOrgStockDetailWork[] addUpOrgStockDetailWorkArray, out StockWork[] stockWorkArray)
        {
            stockSlipWork = null;
            stockDetailWorkArray = null;
            addUpOrgStockDetailWorkArray = null;
            stockWorkArray = null;

            object objStockSlipWork;
            object objStockDetailWorkArray;
            object objPaymentWork;
            object objDepositAlwWork;
            object objAddUpOrgStockDetailWorkArray;

            this.DivisionCustomSerializeArrayListProc(paraList, out objStockSlipWork, out objStockDetailWorkArray, out objAddUpOrgStockDetailWorkArray, out objPaymentWork, out objDepositAlwWork, out stockWorkArray);

            if ((objStockSlipWork != null) && (objStockSlipWork is StockSlipWork)) stockSlipWork = (StockSlipWork)objStockSlipWork;

            if ((objStockDetailWorkArray != null) && (objStockDetailWorkArray is StockDetailWork[])) stockDetailWorkArray = (StockDetailWork[])objStockDetailWorkArray;

            if ((objAddUpOrgStockDetailWorkArray != null) && (objAddUpOrgStockDetailWorkArray is AddUpOrgStockDetailWork[])) addUpOrgStockDetailWorkArray = (AddUpOrgStockDetailWork[])objAddUpOrgStockDetailWorkArray;
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。（売上情報用）
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="salesSlipWork">売上データワークオブジェクト</param>
        /// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        /// <param name="addUppOrgSalesDetailWorkArray">計上元売上明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金データオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>        
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesSlipWork salesSlipWork, out SalesDetailWork[] salesDetailWorkArray, out AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray, out DepsitDataWork depsitDataWork, out DepositAlwWork depositAlwWork, out StockWork[] stockWorkArray, out AcceptOdrCarWork[] acceptOdrCarWorkArray)
        {
            salesSlipWork = null;
            salesDetailWorkArray = null;
            addUpOrgSalesDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;

            object objSalesSlipWork;
            object objSalesDetailWorkArray;
            object objAddUpOrgSalesDetailWorkArray;
            object objDepsitDataWork;
            object objDepositAlwWork;
            object objAcceptOdrCarWorkArray;

            this.DivisionCustomSerializeArrayListProc(paraList, out objSalesSlipWork, out objSalesDetailWorkArray, out objAddUpOrgSalesDetailWorkArray, out objDepsitDataWork, out objDepositAlwWork, out stockWorkArray, out objAcceptOdrCarWorkArray);

            if ((objSalesSlipWork != null) && (objSalesSlipWork is SalesSlipWork)) salesSlipWork = (SalesSlipWork)objSalesSlipWork;

            if ((objSalesDetailWorkArray != null) && (objSalesDetailWorkArray is SalesDetailWork[])) salesDetailWorkArray = (SalesDetailWork[])objSalesDetailWorkArray;

            if ((objAddUpOrgSalesDetailWorkArray != null) && (objAddUpOrgSalesDetailWorkArray is AddUpOrgSalesDetailWork[])) addUpOrgSalesDetailWorkArray = (AddUpOrgSalesDetailWork[])objAddUpOrgSalesDetailWorkArray;

            if ((objDepsitDataWork != null) && (objDepsitDataWork is DepsitDataWork)) depsitDataWork = (DepsitDataWork)objDepsitDataWork;

            if ((objDepositAlwWork != null) && (objDepositAlwWork is DepositAlwWork)) depositAlwWork = (DepositAlwWork)objDepositAlwWork;

            if ((objAcceptOdrCarWorkArray != null) && (objAcceptOdrCarWorkArray is AcceptOdrCarWork[])) acceptOdrCarWorkArray = (AcceptOdrCarWork[])objAcceptOdrCarWorkArray;
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="slipWork">伝票データワークオブジェクト</param>
        /// <param name="detailWorkArray">明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金／支払データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayListProc(CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray)
        {
            object acceptOdrCarWorkArray = null;
            this.DivisionCustomSerializeArrayListProc(paraList, out slipWork, out detailWorkArray, out addUpOrgDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockWorkArray, out acceptOdrCarWorkArray);
        }

        /// <summary>
        /// CustomSerializeArrayListを各種データオブジェクトに分割します。
        /// </summary>
        /// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        /// <param name="slipWork">伝票データワークオブジェクト</param>
        /// <param name="detailWorkArray">明細データワークオブジェクト配列</param>
        /// <param name="addUpOrgDetailWorkArray">計上元明細データワークオブジェクト配列</param>
        /// <param name="depsitDataWork">入金／支払データワークオブジェクト</param>
        /// <param name="depositAlwWork">入金引当データワークオブジェクト</param>
        /// <param name="stockWorkArray">在庫ワークオブジェクト配列</param>
        /// <param name="acceptOdrCarWorkArray">受注マスタ（車両）ワークオブジェクト配列</param>
        private void DivisionCustomSerializeArrayListProc(CustomSerializeArrayList paraList, out object slipWork, out object detailWorkArray, out object addUpOrgDetailWorkArray, out object depsitDataWork, out object depositAlwWork, out StockWork[] stockWorkArray, out object acceptOdrCarWorkArray)
        {
            slipWork = null;
            detailWorkArray = null;
            addUpOrgDetailWorkArray = null;
            depsitDataWork = null;
            depositAlwWork = null;
            stockWorkArray = null;
            acceptOdrCarWorkArray = null;

            for (int i = 0; i < paraList.Count; i++)
            {
                if ((paraList[i] is StockSlipWork) || (paraList[i] is SalesSlipWork))
                {
                    slipWork = paraList[i];
                }
                else if ((paraList[i] is PaymentSlpWork) || (paraList[i] is DepsitDataWork))
                {
                    depsitDataWork = paraList[i];
                }
                else if (paraList[i] is DepositAlwWork)
                {
                    depositAlwWork = paraList[i];
                }
                else if (paraList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)paraList[i];

                    if (list.Count == 0) continue;

                    if (list[0] is AddUpOrgStockDetailWork)
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgStockDetailWork[])list.ToArray(typeof(AddUpOrgStockDetailWork));
                    }
                    else if (list[0] is AddUpOrgSalesDetailWork)
                    {
                        addUpOrgDetailWorkArray = (AddUpOrgSalesDetailWork[])list.ToArray(typeof(AddUpOrgSalesDetailWork));
                    }
                    else if (list[0] is StockDetailWork)
                    {
                        detailWorkArray = (StockDetailWork[])list.ToArray(typeof(StockDetailWork));
                    }
                    else if (list[0] is SalesDetailWork)
                    {
                        detailWorkArray = (SalesDetailWork[])list.ToArray(typeof(SalesDetailWork));
                    }
                    else if (list[0] is StockWork)
                    {
                        stockWorkArray = (StockWork[])list.ToArray(typeof(StockWork));
                    }
                    else if (list[0] is AcceptOdrCarWork)
                    {
                        acceptOdrCarWorkArray = (AcceptOdrCarWork[])list.ToArray(typeof(AcceptOdrCarWork));
                    }
                }
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
        ///// <summary>
        ///// CustomSerializeArrayListを売上明細データオブジェクトに分割します。
        ///// </summary>
        ///// <param name="paraList">カスタムシリアライズリストオブジェクト</param>
        ///// <param name="salesDetailWorkArray">売上明細データワークオブジェクト配列</param>
        //private void DivisionCustomSerializeArrayList(CustomSerializeArrayList paraList, out SalesDetailWork[] salesDetailWorkArray)
        //{
        //    salesDetailWorkArray = null;

        //    ArrayList retSalesDetailWorkList = new ArrayList();
        //    for (int i = 0; i < paraList.Count; i++)
        //    {
        //        if (paraList[i] is SalesDetailWork)
        //        {
        //            retSalesDetailWorkList.Add((SalesDetailWork)paraList[i]);
        //        }
        //    }
        //    salesDetailWorkArray = (SalesDetailWork[])retSalesDetailWorkList.ToArray(typeof(SalesDetailWork));
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
        /// <summary>
        /// 赤伝登録処理
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note: 2010/12/20 liyp</br>
        /// <br>            赤伝のデータセット仕様の修正（MANTIS: 16057）</br>
        /// <br>Update Note: 2013/01/15 FSI菅原　要</br>
        /// <br>            仕入返品予定データ作成処理追加</br>
        /// <br>Update Note: 2013/02/27 凌小青</br>
        /// <br>            Redmine#33797の＃14対応</br>
        /// <br>Update Note: 2020/11/20 陳艶丹</br>
        /// <br>管理番号   : 11670305-00</br>
        /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
        /// <br>Update Note: 2020/12/21 呉元嘯</br>
        /// <br>管理番号   : 11670305-00</br>
        /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
        // --- UPD m.suzuki 2010/08/18 ---------->>>>>
        //public int WriteRedSlip(RedSlipWriteParameter parameter, out string errorMessage, out Dictionary<string, int> _printRedSalesSlipNo)
        //public int WriteRedSlip(RedSlipWriteParameter parameter, out string errorMessage, out Dictionary<string, int> _printRedSalesSlipNo, WriteDataCheck dateCheck)// Del 2011/08/06 duzg for 赤伝発行時、データ送信対応
        public int WriteRedSlip(RedSlipWriteParameter parameter, out string errorMessage, out Dictionary<string, int> _printRedSalesSlipNo, WriteDataCheck dateCheck, string partySaleSlipNum, bool scmFlg)// Add 2011/08/06 duzg for 赤伝発行時、データ送信対応
        // --- UPD m.suzuki 2010/08/18 ----------<<<<<
        {
            int status;
            int stockSlipCd;
            bool errorFlag = false;
            errorMessage = string.Empty;
            _printRedSalesSlipNo = null;

            # region [書き込み準備]
            //// テーブル生成
            //_salesProcMoneyDataTable = new SalesInputInitialDataSet.SalesProcMoneyDataTable();
            //_stockProcMoneyDataTable = new SalesInputInitialDataSet.StockProcMoneyDataTable();

            // アクセスクラス生成
            // (得意先)
            if ( _customerInfoAcs == null )
            {
                _customerInfoAcs = new CustomerInfoAcs();
            }
            //----- DEL K2014/01/20 wangl2 Redmine#41497 --------------->>>>>
            //// --------------- ADD START K2013/09/09 wangl2 FOR フタバ様改修------>>>>
            //// 商品在庫
            //if (_stockMstAcs == null)
            //{
            //    _stockMstAcs = new StockMstAcs();
            //}
            //// --------------- ADD END K2013/09/09 wangl2 FOR フタバ様改修--------<<<<
            //----- DEL K2014/01/20 wangl2 Redmine#41497 ---------------<<<<<
            // (仕入先)
            if ( _supplierAcs == null )
            {
                _supplierAcs = new SupplierAcs();
            }
            // ----------ADD 2010/12/20 -------------<<<<<
            if (_employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            // ----------ADD 2010/12/20 ------------->>>>>
            // (売上金額処理設定)
            if ( _salesProcMoneyAcs == null )
            {
                _salesProcMoneyAcs = new SalesProcMoneyAcs();
                CacheSalesProcMoney();
            }
            // (仕入金額処理設定)
            if ( _stockProcMoneyAcs == null )
            {
                _stockProcMoneyAcs = new StockProcMoneyAcs();
                CacheStockProcMoney();
            }
            // (売上金額算出モジュール)
            if ( _salesPriceCalculate == null )
            {
                _salesPriceCalculate = new SalesPriceCalculate();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 ADD
                _salesPriceCalculate.CacheSalesProcMoneyList( this._salesProcMoneyList );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 ADD
            }
            // (仕入金額算出モジュール)
            if ( _stockPriceCalculate == null )
            {
                _stockPriceCalculate = new StockPriceCalculate();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 ADD
                _stockPriceCalculate.CacheStockProcMoneyList( this._stockProcMoneyList );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 ADD
            }
            //// フィールド退避
            //_enterpriseCode = parameter.EnterpriseCode;
            // 仕入伝票区分
            switch (parameter.SlipCd)
	        {
                case 0:
                    stockSlipCd = 10;
                    break;
                case 1:
		        default:
                    stockSlipCd = 20;
                    break;
	        }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
            // (伝票印刷パターン設定)
            if ( _slipPrtSetList == null )
            {
                SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
                ArrayList retList;
                int retStatus = slipPrtSetAcs.SearchAllSlipPrtSet( out retList, this._enterpriseCode );
                if ( retStatus == 0 )
                {
                    _slipPrtSetList = new List<SlipPrtSet>( (SlipPrtSet[])retList.ToArray( typeof( SlipPrtSet ) ) );
                }
                else
                {
                    _slipPrtSetList = new List<SlipPrtSet>();
                }
            }
            // (伝票設定)
            if ( _custSlipMngList == null )
            {
                CustSlipMngAcs custSlipMngAcs = new CustSlipMngAcs();
                ArrayList retList;
                int totalCnt;
                int retStatus = custSlipMngAcs.SearchAll( out totalCnt, this._enterpriseCode );

                if ( retStatus == 0 )
                {
                    retList = custSlipMngAcs.CustSlipMngList;
                    _custSlipMngList = new List<CustSlipMng>( (CustSlipMng[])retList.ToArray( typeof( CustSlipMng ) ) );
                }
                else
                {
                    _custSlipMngList = new List<CustSlipMng>();
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 DEL // 処理順移動
            //// 車両リレーション
            //_carRelationDic = new Dictionary<int, Guid>();
            //_dtlCarRelationDic = new Dictionary<Guid, Guid>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 DEL

            # region [赤伝登録データ生成]

            // 変数定義
            # region [変数定義]
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 DEL
            //// 読み込み結果退避用
            //SalesSlipWork salesSlip = null;
            //List<SalesDetailWork> salesDetailList = null;
            //List<SalesDetailWork> addUpSrcDetailList = null;
            //SearchDepsitMain searchDepsitMain = null;
            //SearchDepositAlw searchDepositAlw = null;
            //List<StockSlipWork> stockSlipWorkList = null;
            //List<StockDetailWork> stockDetailWorkList = null;
            //List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList = null;
            //List<StockWork> stockWorkList = null;
            //List<AcceptOdrCarWork> acceptOdrCarList = null;

            //// 前行読込情報退避用
            //int prevAcptAnOdrStatus = 0;
            //string prevSalesSlipNum = string.Empty;

            //// 登録用伝票情報退避用
            //SalesSlipWork redSalesSlip = null;
            //List<SalesDetailWork> redSalesDetailList = new List<SalesDetailWork>();
            //List<AcceptOdrCarWork> redAcceptOdrCarList = new List<AcceptOdrCarWork>();
            //// 登録用仕入伝票情報退避用
            //Dictionary<StockSlipLogicalKey, StockSlipWork> orgStockSlipDic = new Dictionary<StockSlipLogicalKey, StockSlipWork>();
            //Dictionary<StockSlipLogicalKey, List<StockDetailWork>> orgStockDetailListDic = new Dictionary<StockSlipLogicalKey, List<StockDetailWork>>();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD // 定義と初期化を分離
            // 読み込み結果退避用
            //SalesSlipWork salesSlip;// del 2011/08/06 duzg
            SalesSlipWork salesSlip = null;// add 2011/08/06 duzg
            //List<SalesDetailWork> salesDetailList;// del 2011/08/06 duzg
            List<SalesDetailWork> salesDetailList = null;// add 2011/08/06 duzg
            List<SalesDetailWork> addUpSrcDetailList;
            SearchDepsitMain searchDepsitMain;
            SearchDepositAlw searchDepositAlw;
            List<StockSlipWork> stockSlipWorkList;
            List<StockDetailWork> stockDetailWorkList;
            List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList;
            List<StockWork> stockWorkList;
            //List<AcceptOdrCarWork> acceptOdrCarList;// del 2011/08/06 duzg
            List<AcceptOdrCarWork> acceptOdrCarList = null;// add 2011/08/06 duzg
            // 前行読込情報退避用
            int prevAcptAnOdrStatus;
            //string prevSalesSlipNum; // 2012/03/21
            string prevSalesSlipNum = "000000000"; // 2012/03/21
            // 登録用伝票情報退避用
            SalesSlipWork redSalesSlip;
            List<SalesDetailWork> redSalesDetailList;
            List<AcceptOdrCarWork> redAcceptOdrCarList;
            // 登録用仕入伝票情報退避用
            Dictionary<StockSlipLogicalKey, StockSlipWork> orgStockSlipDic;
            Dictionary<StockSlipLogicalKey, List<StockDetailWork>> orgStockDetailListDic;
            // ---------- ADD 2012/08/22 ---------->>>>>
            Dictionary<StockSlipLogicalKey, DateTime> stockDateForUpdateDic;
            // ---------- ADD 2012/08/22 ----------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD

            // 2010/11/29 Add >>>
            DepsitDataWork redDepsitDataWork;      // 入金データワークオブジェクト
            DepositAlwWork redDepositAlwWork;      // 入金引当データワークオブジェクト
            // 2010/11/29 Add <<<
            // ---------- ADD 2013/01/15 ---------->>>>>
            // 仕入返品予定データ作成情報退避用
            Dictionary<StockSlipLogicalKey, StockSlipWork> stockSlipRgdsExpctDic;
            Dictionary<StockSlipLogicalKey, List<StockDetailWork>> stockSlipRgdsExpctDetailListDic;
            // 仕入返品予定データ（仕入明細データ）仕入行番号設定用カウンタ（実際は画面上の明細行のカウンタとして用いる）
            int rgdsExpctRowCount = 1;              
            // ---------- ADD 2013/01/15 ----------<<<<<
            # endregion

            // 明細ソートと伝票分割
            # region [明細ソートと伝票分割]
            // 赤伝明細DataView取得
            DataView redSlipView = new DataView( _detailDataSet.RedSlipDetail );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
            // 赤伝明細入力順をセット（ソート作業用）
            for ( int index = 0; index < redSlipView.Count; index++ )
            {
                redSlipView[index][DetailDataSet.RedSlipDetail.RedSlipInputRowNoColumn.ColumnName] = index;
            }
            // 変更をコミット
            redSlipView.Table.AcceptChanges();  // ADD 2009/06/10
            redSlipView.Sort = this.MakeSalesSlipSort( _salesTtlSt ); // ソート
            
            // Max明細行数取得
            SlipPrtSet slipPrtSet = this.GetPrtSlipSet( SlipTypeController.SlipKind.SalesSlip, parameter.SectionCode.Trim(), parameter.CustomerCode );
            int slipFeedCnt;
            if (slipPrtSet != null)
            {
                slipFeedCnt = slipPrtSet.DetailRowCount;
            }
            else
            {
                slipFeedCnt = 4;
            }
            
            // 作業用伝票index採番
            int slipIndex = 0;
            int slipIndexCnt = 0;
            for ( int index = 0; index < redSlipView.Count; index++ )
            {
                // 最大数に達する時or条件ブレイク時
                if ( slipIndexCnt >= slipFeedCnt ||
                     (index > 0 && CheckSlipBreak( redSlipView[index - 1], redSlipView[index], _salesTtlSt )) )
                {
                    // indexインクリメント
                    slipIndex++;
                    // 次の伝票の明細数はゼロに戻す
                    slipIndexCnt = 0;
                }

                redSlipView[index][DetailDataSet.RedSlipDetail.RedSlipWorkSlipNoColumn.ColumnName] = slipIndex;
                slipIndexCnt ++;
            }
            // このタイミングで、slipIndex＝最後のindexとなる
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD
            // 変更をコミット
            redSlipView.Table.AcceptChanges();  // ADD 2009/06/10
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
            // 赤伝登録データ
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();
            // 登録用仕入伝票情報退避用
            orgStockSlipDic = new Dictionary<StockSlipLogicalKey, StockSlipWork>();
            orgStockDetailListDic = new Dictionary<StockSlipLogicalKey, List<StockDetailWork>>();
            // ---------- ADD 2012/08/22 ---------->>>>>
            stockDateForUpdateDic = new Dictionary<StockSlipLogicalKey, DateTime>();
            // ---------- ADD 2012/08/22 ----------<<<<<
            // ---------- ADD 2013/01/15 ---------->>>>>
            // 仕入返品予定データ作成情報退避用キャッシュ初期化
            stockSlipRgdsExpctDic = new Dictionary<StockSlipLogicalKey, StockSlipWork>();
            stockSlipRgdsExpctDetailListDic = new Dictionary<StockSlipLogicalKey, List<StockDetailWork>>();
            // ---------- ADD 2013/01/15 ----------<<<<<
            // 車両情報退避用
            _carInfo = new Dictionary<Guid, PMKEN01010E>();
            _colorInfoDic = new Dictionary<Guid, PMKEN01010E.ColorCdInfoDataTable>();
            _trimInfoDic = new Dictionary<Guid, PMKEN01010E.TrimCdInfoDataTable>();
            _cEqpDspInfoDic = new Dictionary<Guid, PMKEN01010E.CEqpDefDspInfoDataTable>();
            _carInfoDataTable = new SalesInputDataSet.CarInfoDataTable();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD

            // ADD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 赤伝の行番号(index:1)と元黒の行番号(index:2)
            List<int[]> rowNoNewOld = new List<int[]>();
            // ADD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
            for ( int slipUnitIndex = 0; slipUnitIndex <= slipIndex; slipUnitIndex++ )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD
            {
                // --- ADD 2013/10/10 T.Miyamoto ------------------------------>>>>>
                _redSlipWorkSlipNo = slipUnitIndex;
                // --- ADD 2013/10/10 T.Miyamoto ------------------------------<<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
                // 分割した伝票単位にフィルタリングする
                redSlipView.RowFilter = string.Format( "{0}='{1}'", 
                                                        DetailDataSet.RedSlipDetail.RedSlipWorkSlipNoColumn.ColumnName, slipUnitIndex );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD // 定義と初期化を分離・処理順移動
                # region [変数初期化]
                // 読み込み結果退避用
                salesSlip = null;
                salesDetailList = null;
                addUpSrcDetailList = null;
                searchDepsitMain = null;
                searchDepositAlw = null;
                stockSlipWorkList = null;
                stockDetailWorkList = null;
                addUpSrcStockDetailWorkList = null;
                stockWorkList = null;
                acceptOdrCarList = null;
                // 前行読込情報退避用
                prevAcptAnOdrStatus = 0;
                prevSalesSlipNum = string.Empty;
                // 登録用伝票情報退避用
                redSalesSlip = null;
                redSalesDetailList = new List<SalesDetailWork>();
                redAcceptOdrCarList = new List<AcceptOdrCarWork>();
                //// 登録用仕入伝票情報退避用
                //orgStockSlipDic = new Dictionary<StockSlipLogicalKey, StockSlipWork>();
                //orgStockDetailListDic = new Dictionary<StockSlipLogicalKey, List<StockDetailWork>>();
                // 車両リレーション
                _carRelationDic = new Dictionary<int, Guid>();
                _dtlCarRelationDic = new Dictionary<Guid, Guid>();

                // 2010/11/29 Add >>>
                redDepsitDataWork = null;      // 入金データワークオブジェクト
                redDepositAlwWork = null;      // 入金引当データワークオブジェクト
                // 2010/11/29 Add <<<
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD

                // 赤伝明細でループ
                foreach ( DataRowView rowView in redSlipView )
                {
                    // 明細KEY情報取得
                    # region [明細KEY情報取得]
                    // 受注ステータス
                    int acptAnOdrStatus = (int)rowView[_detailDataSet.RedSlipDetail.AcptAnOdrStatusColumn.ColumnName];
                    // 伝票番号
                    string salesSlipNum = (string)rowView[_detailDataSet.RedSlipDetail.SalesSlipNumColumn.ColumnName];
                    // 明細行№
                    int rowNo = (int)rowView[_detailDataSet.RedSlipDetail.SalesRowNoColumn.ColumnName];
                    # endregion

                    // 伝票Read
                    # region [伝票Read]
                    // １つ前の行と同じ伝票ならば再Readしない
                    if ( prevAcptAnOdrStatus == acptAnOdrStatus && prevSalesSlipNum == salesSlipNum )
                    {
                        status = 0;
                    }
                    else
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
                        //// データリード
                        //status = this.ReadDBDataProc( ConstantManagement.LogicalMode.GetData0,
                        //    parameter.EnterpriseCode, acptAnOdrStatus, salesSlipNum,
                        //    out salesSlip, out salesDetailList,
                        //    out addUpSrcDetailList, out searchDepsitMain,
                        //    out searchDepositAlw, out stockSlipWorkList,
                        //    out stockDetailWorkList, out addUpSrcStockDetailWorkList,
                        //    out stockWorkList, out acceptOdrCarList );

                        int readMode;

                        // 履歴判断
                        if ( string.IsNullOrEmpty( (string)rowView[this._detailDataSet.RedSlipDetail.HistoryDivNameColumn.ColumnName] ) )
                        {
                            // 通常
                            readMode = 0;
                        }
                        else
                        {
                            // 履歴
                            readMode = 1;
                        }
                        // データリード
                        status = this.ReadDBDataProc( ConstantManagement.LogicalMode.GetData0,
                            parameter.EnterpriseCode, acptAnOdrStatus, salesSlipNum,
                            out salesSlip, out salesDetailList,
                            out addUpSrcDetailList, out searchDepsitMain,
                            out searchDepositAlw, out stockSlipWorkList,
                            out stockDetailWorkList, out addUpSrcStockDetailWorkList,
                            out stockWorkList, out acceptOdrCarList,
                            readMode
                            );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD

                        if ( status != 0 )
                        {
                            errorFlag = true;
                            break;
                        }
                    }
                    # endregion

                    // 明細取得・退避
                    # region [明細取得・退避]
                    // エラーチェック
                    if ( salesSlip == null ||
                        salesDetailList == null ||
                        salesDetailList.Count < rowNo - 1 )
                    {
                        errorFlag = true;
                        break;
                    }

                    // 元伝票(先頭)の伝票情報取得
                    if ( redSalesDetailList.Count == 0 )
                    {
                        redSalesSlip = salesSlip;
                    }
                    // 元伝票の明細取得
                    bool addCarRelation;
                    // --- UPD m.suzuki 2010/07/20 ---------->>>>>
                    //int acceptAnOrderNo = salesDetailList[rowNo - 1].AcceptAnOrderNo;
                    //long salesDtlNum = salesDetailList[rowNo - 1].SalesSlipDtlNum;
                    //redSalesDetailList.Add( CopyToRedSalesDetail( salesDetailList[rowNo - 1], redSalesSlip, redSalesDetailList, rowView, parameter, out addCarRelation ) );

                    SalesDetailWork targetSalesDetail = GetSalesDetailFromRowNo( salesDetailList, rowNo );
                    if ( targetSalesDetail == null )
                    {
                        errorFlag = true;
                        break;
                    }
                    int acceptAnOrderNo = targetSalesDetail.AcceptAnOrderNo;
                    long salesDtlNum = targetSalesDetail.SalesSlipDtlNum;
                    // --- UPD m.suzuki 2010/10/07 ---------->>>>>
                    //redSalesDetailList.Add( CopyToRedSalesDetail( targetSalesDetail, redSalesSlip, redSalesDetailList, rowView, parameter, out addCarRelation ) );
                    // UPD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // SalesDetailWork redSalesdetail = CopyToRedSalesDetail(targetSalesDetail, redSalesSlip, redSalesDetailList, rowView, parameter, out addCarRelation);
                    SalesDetailWork redSalesdetail = CopyToRedSalesDetail(targetSalesDetail, redSalesSlip, redSalesDetailList, rowView, parameter, out addCarRelation, ref rowNoNewOld);
                    // UPD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    redSalesDetailList.Add(redSalesdetail);
                    // --- UPD m.suzuki 2010/10/07 ----------<<<<<
                    // --- UPD m.suzuki 2010/07/20 ----------<<<<<

                    if ( addCarRelation )

                    {
                        // 車両情報
                        redAcceptOdrCarList.Add( FindAcceptOdrCar( acceptOdrCarList, acceptAnOrderNo ) );
                    }
                    # endregion

                    // 同時仕入情報取得
                    # region [同時仕入情報取得]
                    if ( stockSlipWorkList != null && stockSlipWorkList.Count > 0 &&
                        stockDetailWorkList != null && stockDetailWorkList.Count > 0 &&
                        rowView[_detailDataSet.RedSlipDetail.StockPartySaleSlipNumColumn.ColumnName] != DBNull.Value &&
                        (string)rowView[_detailDataSet.RedSlipDetail.StockPartySaleSlipNumColumn.ColumnName] != string.Empty )
                    {
                        // 明細に対応する仕入伝票データの取得
                        StockSlipWork retStockSlip;
                        StockDetailWork retStockDetail = new StockDetailWork();
                        this.SelectStockSlip( rowView, salesDtlNum, stockSlipWorkList, stockDetailWorkList, out retStockSlip, out retStockDetail );

                        // 前準備として仕入伝票明細の情報を書き換える
                        ReflectStockSlipDetail( ref retStockDetail, retStockSlip, redSalesSlip, redSalesDetailList[redSalesDetailList.Count - 1], rowView );


                        // 仕入伝票論理キー生成
                        int supplierCd = (int)rowView[_detailDataSet.RedSlipDetail.SupplierCdColumn.ColumnName];
                        string slipNo = (string)rowView[_detailDataSet.RedSlipDetail.StockPartySaleSlipNumColumn.ColumnName];

                        StockSlipLogicalKey key = new StockSlipLogicalKey( _enterpriseCode, supplierCd, parameter.SalesDate, stockSlipCd, slipNo, parameter.SectionCode );

                        // ---------- ADD 2012/08/22 ---------->>>>>
                        // グリッド上で入力された仕入日を取得
                        DateTime stockDateForUpdate = (DateTime)rowView[_detailDataSet.RedSlipDetail.StockDateColumn.ColumnName];
                        // 仕入日用退避ディクショナリに追加
                        // キーは、仕入伝票のキーと同じ値を用いる
                        if (!stockDateForUpdateDic.ContainsKey(key))
                        {
                            stockDateForUpdateDic.Add(key, stockDateForUpdate);
                        }
                        else
                        {
                            // --- DEL 2020/12/21 警告対応 ---------->>>>>
                            //if (stockDateForUpdateDic[key] == null)
                            //    stockDateForUpdateDic[key] = stockDateForUpdate;
                            // --- DEL 2020/12/21 警告対応 ----------<<<<<
                        }
                        // ---------- ADD 2012/08/22 ----------<<<<<

                        // 退避ディクショナリに追加
                        # region [退避ディクショナリに追加]
                        // 仕入伝票
                        if ( !orgStockSlipDic.ContainsKey( key ) )
                        {
                            orgStockSlipDic.Add( key, retStockSlip );
                        }
                        else if ( orgStockSlipDic[key] == null )
                        {
                            orgStockSlipDic[key] = retStockSlip;
                        }
                        // --- ADD m.suzuki 2010/10/07 ---------->>>>>
                        // 仕入明細と売上明細を関連付ける
                        retStockDetail.DtlRelationGuid = redSalesdetail.DtlRelationGuid;
                        retStockDetail.AcptAnOdrStatusSync = 30; // 30:売上
                        // --- ADD m.suzuki 2010/10/07 ----------<<<<<

                        // 仕入明細
                        if ( !orgStockDetailListDic.ContainsKey( key ) )
                        {
                            orgStockDetailListDic.Add( key, new List<StockDetailWork>( new StockDetailWork[] { retStockDetail } ) );
                        }
                        else if ( orgStockDetailListDic[key] == null )
                        {
                            orgStockDetailListDic[key] = new List<StockDetailWork>( new StockDetailWork[] { retStockDetail } );
                        }
                        else
                        {
                            orgStockDetailListDic[key].Add( retStockDetail );
                        }
                        # endregion
                    }
                    # endregion

                    // ----- ADD 2013/01/15 ----->>>>>
                    #region [仕入返品予定データ作成]

                    // 仕入返品予定区分が「する」の場合のみ処理実行
                    if (_salesTtlSt.StockRetGoodsPlnDiv == 1)
                    {
                        string supplyDivName = (string)rowView[this._detailDataSet.RedSlipDetail.SupplyDivNameColumn.ColumnName].ToString();
                        if (supplyDivName == "○")
                        {
                            // 画面上で仕入伝票番号と倉庫コードが共に未入力かチェック
                            string stockPartySaleSlipNum;
                            string warehouseCode;
                            if (rowView[_detailDataSet.RedSlipDetail.StockPartySaleSlipNumColumn.ColumnName] == DBNull.Value)
                            {
                                stockPartySaleSlipNum = string.Empty;
                            }
                            else
                            {
                                stockPartySaleSlipNum = (string)rowView[_detailDataSet.RedSlipDetail.StockPartySaleSlipNumColumn.ColumnName];
                            }
                            if (rowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName] == DBNull.Value)
                            {
                                warehouseCode = string.Empty;
                            }
                            else
                            {
                                warehouseCode = (string)rowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName];
                            }

                            if (stockPartySaleSlipNum == String.Empty && warehouseCode == String.Empty)
                            {
                                // 仕入返品予定データを作成

                                // 明細に対応する仕入伝票データの取得
                                StockSlipWork retStockSlip;
                                StockDetailWork retStockDetail = new StockDetailWork();

                                // ----- ADD 2013/02/27 ----->>>>>
                                int ret = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

                                ret = this.SelectStockSlipForRetPln(rowView, salesDtlNum, stockSlipWorkList, stockDetailWorkList, out retStockSlip, out retStockDetail);

                                if (ret != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    errorMessage = "元の仕入伝票が削除されているため、赤伝発行はできません。";
                                    return (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                }
                                // ----- ADD 2013/02/27 -----<<<<<

                                // 仕入返品予定データ（仕入データ）作成
                                CreateStockSlipRetGoodsExpectedData(ref retStockSlip, parameter);

                                // データキャッシュ用キー生成（キー＝仕入先コード）
                                int supplierCd = (int)rowView[_detailDataSet.RedSlipDetail.SupplierCdColumn.ColumnName];
                                string slipNo = string.Empty;
                                StockSlipLogicalKey key = new StockSlipLogicalKey(_enterpriseCode, supplierCd, parameter.SalesDate, stockSlipCd, slipNo, parameter.SectionCode);

                                // 仕入返品予定データ（仕入データ）キャッシュ
                                if (!stockSlipRgdsExpctDic.ContainsKey(key))
                                {
                                    stockSlipRgdsExpctDic.Add(key, retStockSlip);
                                }
                                else if (stockSlipRgdsExpctDic[key] == null)
                                {
                                    stockSlipRgdsExpctDic[key] = retStockSlip;
                                }

                                // 仕入返品予定データ（仕入明細データ）作成
                                CreateStockSlipDetailRetGoodsExpectedData(retStockSlip, ref retStockDetail, rowView, redSalesDetailList, rgdsExpctRowCount, parameter);
                                rgdsExpctRowCount++;

                                // 仕入明細と売上明細を関連付ける
                                retStockDetail.DtlRelationGuid = redSalesdetail.DtlRelationGuid;

                                // 仕入返品予定データ（仕入明細データ）キャッシュ
                                if (!stockSlipRgdsExpctDetailListDic.ContainsKey(key))
                                {
                                    stockSlipRgdsExpctDetailListDic.Add(key, new List<StockDetailWork>(new StockDetailWork[] { retStockDetail }));
                                }
                                else if (stockSlipRgdsExpctDetailListDic[key] == null)
                                {
                                    stockSlipRgdsExpctDetailListDic[key] = new List<StockDetailWork>(new StockDetailWork[] { retStockDetail });
                                }
                                else
                                {
                                    stockSlipRgdsExpctDetailListDic[key].Add(retStockDetail);
                                }
                            }
                        }
                    }
                    #endregion [仕入返品予定データ作成]
                    // ----- ADD 2013/01/15 -----<<<<<

                    // 前回情報退避
                    # region [前回情報退避]
                    prevAcptAnOdrStatus = acptAnOdrStatus;
                    prevSalesSlipNum = salesSlipNum;
                    # endregion
                }
                if ( errorFlag )
                {
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                # region [赤伝情報調整]
                // 手数料明細追加
                AddFeeDetail( ref redSalesDetailList, redSalesSlip, parameter );
                // 赤伝伝票情報更新
                ReflectRedSalesSlip( ref redSalesSlip, redSalesDetailList, parameter );
                # endregion

                # region [車両情報]
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 DEL
                //_carInfo = new Dictionary<Guid, PMKEN01010E>();
                //_colorInfoDic = new Dictionary<Guid, PMKEN01010E.ColorCdInfoDataTable>();
                //_trimInfoDic = new Dictionary<Guid, PMKEN01010E.TrimCdInfoDataTable>();
                //_cEqpDspInfoDic = new Dictionary<Guid, PMKEN01010E.CEqpDefDspInfoDataTable>();
                //_carInfoDataTable = new SalesInputDataSet.CarInfoDataTable();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 DEL

                if ( redAcceptOdrCarList.Count > 0 )
                {
                    _carSearchController = new CarSearchController();
                }
                // --- ADD 2009/09/07 ---------->>>>>
                int carMngDiv = 0;
                if (parameter.CustomerCode > 0)
                {
                    // 得意先>0,請求先=0のとき、請求先コードは得意先マスタから取得
                    CustomerInfo customerInfo;
                    int flg = this._customerInfoAcs.ReadDBData(this._enterpriseCode, parameter.CustomerCode, out customerInfo);

                    if (flg == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        carMngDiv = customerInfo.CarMngDivCd;
                    }
                }
                // --- ADD 2009/09/07 ----------<<<<<
                for ( int index = 0; index < redAcceptOdrCarList.Count; index++ )
                {
                    // --- ADD 2009/09/07 ---------->>>>>
                    this.CacheOptionInfo();
                    if (this._opt_CarMngDiv == (int)Option.ON)
                    {
                        // --- ADD s.sannohe 2012/05/18 ---------->>>>>
                        if (redAcceptOdrCarList[index] != null)
                        {
                        // --- ADD s.sannohe 2012/05/18 ----------<<<<<
                            // 「車輌管理」区分が「登録（確認）」「登録（自動）」の場合
                            if (carMngDiv == 1 || carMngDiv == 2)
                            {
                                if (!string.IsNullOrEmpty(redAcceptOdrCarList[index].CarMngCode))
                                {
                                    if (redAcceptOdrCarList[index].CarMngNo == 0)
                                    {
                                        redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                        redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                    }
                                    else
                                    {
                                        redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                        redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                    }

                                }
                                else
                                {
                                    if (redAcceptOdrCarList[index].CarMngNo == 0)
                                    {
                                        // 変更無し（項目表示無し）
                                        redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                        redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                    }
                                    else
                                    {
                                        // 変更無し（項目表示無し）
                                        redAcceptOdrCarList[index].CarMngNo = 0;
                                        redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                        redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                    }
                                }
                            }
                            // 「車輌管理」区分が「登録無」の場合
                            else if (carMngDiv == 3)
                            {
                                if (!string.IsNullOrEmpty(redAcceptOdrCarList[index].CarMngCode))
                                {
                                    if (redAcceptOdrCarList[index].CarMngNo == 0)
                                    {
                                        redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                        redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                    }
                                    else
                                    {
                                        redAcceptOdrCarList[index].CarMngNo = 0;
                                        redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                        redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                    }
                                }
                                else
                                {
                                    if (redAcceptOdrCarList[index].CarMngNo == 0)
                                    {
                                        // 変更無し（項目表示無し）
                                        redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                        redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                    }
                                    else
                                    {
                                        // 変更無し（項目表示無し）
                                        redAcceptOdrCarList[index].CarMngNo = 0;
                                        redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                        redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                    }
                                }
                            }
                            // 「車輌管理」区分が「しない」の場合
                            else
                            {
                                if (redAcceptOdrCarList[index].CarMngNo == 0)
                                {
                                    // 変更無し（項目表示無し）
                                    redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                    redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                }
                                else
                                {
                                    // 変更無し（項目表示無し）
                                    redAcceptOdrCarList[index].CarMngNo = 0;
                                    redAcceptOdrCarList[index].Mileage = parameter.Mileage;
                                    redAcceptOdrCarList[index].CarNote = parameter.CarNote;
                                }
                            }
                        // --- ADD s.sannohe 2012/05/18 ---------->>>>>
                        }
                        // --- ADD s.sannohe 2012/05/18 ----------<<<<<
                    }
                    // --- ADD 2009/09/07 ----------<<<<<

                    // 車両情報キャッシュ(DataTableに格納し、SaveDBDataで使用)
                    CacheCarInfo( redAcceptOdrCarList[index] );
                }
                # endregion

                // 2010/11/29 Add >>>
                #region [ 自動入金情報 ]
                if (( redSalesSlip.AcptAnOdrStatus == 30 ) &&
                    ( redSalesSlip.AccRecDivCd == (int)SalesSlipInputAcs.AccRecDivCd.NonAccRec ) &&
                    ( redSalesSlip.SalesGoodsCd == (int)SalesGoodsCd.Goods ) &&
                    ( this._salesTtlSt.AutoDepositCd == (int)SalesSlipInputAcs.AutoDepositCd.Write ))
                {
                    long totalPrice = redSalesSlip.SalesTotalTaxInc;
                    if (redSalesSlip.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.NoTotalAmount)
                    {
                        // 総額表示しない
                        switch (salesSlip.ConsTaxLayMethod)
                        {
                            case 0: // 伝票転嫁
                            case 1: // 明細転嫁
                                break;
                            case 2: // 請求親
                            case 3: // 請求子
                            case 9: // 非課税
                                // 総合計
                                totalPrice = redSalesSlip.ItdedSalesInTax + redSalesSlip.ItdedSalesOutTax + redSalesSlip.SalSubttlSubToTaxFre +
                                             redSalesSlip.ItdedSalesDisOutTax + redSalesSlip.ItdedSalesDisInTax + redSalesSlip.ItdedSalesDisTaxFre +
                                             redSalesSlip.SalAmntConsTaxInclu + redSalesSlip.SalesDisTtlTaxInclu;
                                break;
                        }
                    }

                    DepsitMainWork depsitMainWork = new DepsitMainWork();
                    DepsitDtlWork[] depsitDtlWorkArray = new DepsitDtlWork[1] { new DepsitDtlWork() };

                    depsitDtlWorkArray[0].DepositRowNo = 1; // 入金行番号
                    depsitDtlWorkArray[0].MoneyKindCode = this._salesTtlSt.AutoDepoKindCode; // 入金金種コード
                    depsitDtlWorkArray[0].MoneyKindName = this._salesTtlSt.AutoDepoKindName; // 入金金種名称
                    depsitDtlWorkArray[0].MoneyKindDiv = this._salesTtlSt.AutoDepoKindDivCd; // 入金金種区分

                    // 請求先名称、請求先名称2のみ売上データからセットできないので得意先マスタから再取得
                    CustomerInfo customerInfo;
                    int flg = this._customerInfoAcs.ReadDBData(this._enterpriseCode, parameter.CustomerCode, out customerInfo);
                    if (flg == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        depsitMainWork.ClaimName = customerInfo.ClaimName; // 請求先名称
                        depsitMainWork.ClaimName2 = customerInfo.ClaimName2; // 請求先名称２
                    }

                    DepsitDataUtil.Union(out redDepsitDataWork, depsitMainWork, depsitDtlWorkArray);

                    redSalesSlip.AutoDepositCd = 1; // 自動入金区分(1:自動入金)
                    redSalesSlip.DepositAlwcBlnce = totalPrice; // 入金引当残高
                    redSalesSlip.DepositAllowanceTtl = 0; // 入金引当合計額
                    redSalesSlip.AutoDepositNoteDiv = this._salesTtlSt.AutoDepositNoteDiv; // 自動入金備考区分(0:売上伝票番号 1:売上伝票備考 2:無し) // ADD BY 凌小青 on 2013/02/27  Redmine#33797の＃14対応
                    redDepositAlwWork = new DepositAlwWork();
                }
                #endregion
                // 2010/11/29 Add <<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 DEL
                # region // DEL
                //# region [伝票登録]
                //// 伝票登録
                //string retMessage;
                //status = this.SaveDBData( redSalesSlip, redSalesDetailList, parameter, out retMessage, ref _printRedSalesSlipNo );
                //if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                //{
                //    errorMessage = "保存に失敗しました。";
                //    return status;
                //}
                //# endregion
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 DEL

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
                // 売上伝票を１伝票paraListに追加（SaveDBDataで書き込み）
                // 2010/11/29 >>>
                //this.CreateWriteParam( ref paraList, redSalesSlip, redSalesDetailList, parameter );
                this.CreateWriteParam(ref paraList, redSalesSlip, redSalesDetailList, parameter, redDepsitDataWork, redDepositAlwWork);
                // 2010/11/29 <<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD
            }
            # endregion

            // --- ADD m.suzuki 2010/08/18 ---------->>>>>
            // 日付再チェック
            if ( dateCheck != null )
            {
                string dateCheckMessage;
                bool dateCheckResult = dateCheck( out dateCheckMessage );
                if ( dateCheckResult == false )
                {
                    errorMessage = dateCheckMessage;
                    return -1;
                }
            }
            // --- ADD m.suzuki 2010/08/18 ----------<<<<<

            // --- UPD m.suzuki 2010/10/07 ---------->>>>>
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
            //# region [伝票登録]
            //// 伝票登録
            //string retMessage;
            //status = this.SaveDBData( ref paraList, parameter, out retMessage, ref _printRedSalesSlipNo );
            //if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            //{
            //    errorMessage = "保存に失敗しました。";
            //    return status;
            //}
            //# endregion
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD

            // --- Add 2011/08/06 duzg for 赤伝発行時、データ送信対応 --->>>
            if (scmFlg)
            {
                // SCM受注データワークオブジェクト
                SCMAcOdrDataWork scmAcOdrDataWork = null;
                // SCM受注データ(車両情報)ワークオブジェクト      
                SCMAcOdrDtCarWork scmAcOdrDtCarWork = null;
                // SCM受注明細データ(問合せ・発注)ワークオブジェクトリスト(SCMAcOdrDtlIqWork)  
                ArrayList scmAcOdrDtlIqWorkList = null;
                // SCM受注明細データ(回答)ワークオブジェクトリスト(SCMAcOdrDtlAsWork)                    
                ArrayList scmAcOdrDtlAsWorkList = null;   
                      
                //-----------------------------------------------------------------------------
                // SCM情報
                //-----------------------------------------------------------------------------
                if ((null != salesDetailList) && (salesDetailList.Count != 0))
                {
                    salesSlip.PartySaleSlipNum = partySaleSlipNum;
                    SalesSlip convSalesSlip = ConvertSalesSlip.UIDataFromParamData(salesSlip);
                    List<SalesDetail> convSalesDetailList = new List<SalesDetail>();
                    foreach (CustomSerializeArrayList customSerializeArrayList in paraList)
                    {
                        foreach (object obj in customSerializeArrayList)
                        {
                            if (obj is ArrayList)
                            {
                                if (((ArrayList)obj)[0] is SalesDetailWork)
                                {
                                    foreach (SalesDetailWork salesDetailWork in ((ArrayList)obj))
                                    {
                                        convSalesDetailList.Add(ConvertSalesSlip.UIDataFromParamData(salesDetailWork));
                                    }
                                }
                            }
                        }
                    }
                    convSalesSlip.OnlineKindDiv = 10;
                    convSalesSlip.SalesSlipNum = "000000000";

                    // ADD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    #region 旧ソース
                    ////>>>2012/03/21
                    ////this.GetCurrentSCM(acceptOdrCarList, convSalesSlip, convSalesDetailList, out scmAcOdrDataWork, out scmAcOdrDtCarWork, out scmAcOdrDtlIqWorkList, out scmAcOdrDtlAsWorkList);
                    //this.GetCurrentSCM(prevSalesSlipNum, acceptOdrCarList, convSalesSlip, convSalesDetailList, out scmAcOdrDataWork, out scmAcOdrDtCarWork, out scmAcOdrDtlIqWorkList, out scmAcOdrDtlAsWorkList);
                    ////<<<2012/03/21
                    #endregion
                    this.GetCurrentSCM(prevSalesSlipNum, acceptOdrCarList, convSalesSlip, convSalesDetailList, out scmAcOdrDataWork, out scmAcOdrDtCarWork, out scmAcOdrDtlIqWorkList, out scmAcOdrDtlAsWorkList, rowNoNewOld);
                    // ADD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                    if (scmAcOdrDataWork != null)
                    {
                        // --- DEL 2012/09/20 三戸 №35の戻し --------->>>>>>>>>>>>>>>>>>>>>>>>
                        //// ADD 2012/07/11 №35 T.Yoshioka ------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //scmAcOdrDataWork.InquiryNumber = salesDetailList[0].InquiryNumber;
                        //scmAcOdrDtCarWork.InquiryNumber = salesDetailList[0].InquiryNumber;
                        //foreach (SCMAcOdrDtlAsWork target in scmAcOdrDtlAsWorkList)
                        //{
                        //    target.InquiryNumber = salesDetailList[0].InquiryNumber;
                        //}
                        //// ADD 2012/07/11 №35 T.Yoshioka -------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        // --- DEL 2012/09/20 三戸 №35の戻し ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        // SCM受注データ
                        ((CustomSerializeArrayList)paraList[0]).Add(scmAcOdrDataWork);  
                        if (scmAcOdrDtCarWork != null)
                        {
                            // SCM受注データ(車両情報)
                            ((CustomSerializeArrayList)paraList[0]).Add(scmAcOdrDtCarWork);           
                        }
                        if (scmAcOdrDtlIqWorkList != null && scmAcOdrDtlIqWorkList.Count != 0)
                        {
                            // SCM受注明細データ(問合せ・発注)
                            ((CustomSerializeArrayList)paraList[0]).Add(scmAcOdrDtlIqWorkList); 
                        }
                        if (scmAcOdrDtlAsWorkList.Count != 0)
                        {
                            // SCM受注明細データ(回答)
                            ((CustomSerializeArrayList)paraList[0]).Add(scmAcOdrDtlAsWorkList); 
                        }
                    }
                }
                // SCM Webサーバーチェック
                ArrayList salesDataList = new ArrayList();
                CustomSerializeArrayList customSerializeArrayList1 = new CustomSerializeArrayList();
                foreach (CustomSerializeArrayList customSerializeArrayList in paraList)
                {
                    foreach (object obj in customSerializeArrayList)
                    {
                        if (obj is SalesSlipWork)
                        {
                            // --- DEL 2012/11/21 T.Miyamoto ------------------------------>>>>>
                            //((SalesSlipWork)obj).SalesSlipCd = 1;
                            // --- DEL 2012/11/21 T.Miyamoto ------------------------------<<<<<
                            ((SalesSlipWork)obj).SalesSlipNum = "0";
                            // DEL 2013/09/17 吉岡 SCM障害№10573 ---------------->>>>>>>>>>>>>
                            // ((SalesSlipWork)obj).SalesInputCode = string.Empty;
                            // DEL 2013/09/17 吉岡 SCM障害№10573 ----------------<<<<<<<<<<<<<
                            ((SalesSlipWork)obj).PartySaleSlipNum = partySaleSlipNum;
                            customSerializeArrayList1.Add(ConvertSalesSlip.UIDataFromParamData((SalesSlipWork)obj));
                        }
                        if (obj is ArrayList)
                        {
                            if (((ArrayList)obj)[0] is SalesDetailWork)
                            {
                                foreach (SalesDetailWork salesDetailWork in ((ArrayList)obj))
                                {
                                    //>>>2012/03/05
                                    //salesDetailWork.SalesSlipCdDtl = 1;
                                    //<<<2012/03/05
                                    salesDetailWork.AcceptAnOrderCnt = salesDetailWork.AcceptAnOrderCnt * -1;
                                    salesDetailWork.AcptAnOdrRemainCnt = 0;
                                    salesDetailWork.AutoAnswerDivSCM = 1;
                                    salesDetailWork.SupplierFormalSync = -1;
                                }
                            }
                            if (((ArrayList)obj)[0] is SCMAcOdrDtlAsWork)
                            {
                                ArrayList sCMAcOdrDtlAsWorkList = new ArrayList();
                                foreach (SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork in ((ArrayList)obj))
                                {
                                    sCMAcOdrDtlAsWorkList.Add(sCMAcOdrDtlAsWork);
                                }
                                customSerializeArrayList1.Add(sCMAcOdrDtlAsWorkList);
                            }
                        }
                    }
                }
                salesDataList.Add(customSerializeArrayList1);

                #region ●SCM Webサーバーデータ更新チェック
                if (scmFlg)
                {
                    if ((salesDataList != null) && (salesDataList.Count != 0))
                    {
                        if (null == _salesSlipInputAcs)
                        {
                            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
                        }
                        int st = this._salesSlipInputAcs.CheckWebServer(salesDataList);
                        if (st == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                        {
                            TMsgDisp.Show(
                                new Form(),
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "",
                                "Webサーバーのデータが更新されています。" + "\r\n" +
                                "受信処理実行後、再度処理を行って下さい。" + "\r\n",
                                -1,
                                MessageBoxButtons.OK);
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        else if (st == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                        {
                            TMsgDisp.Show(
                                new Form(),
                                emErrorLevel.ERR_LEVEL_INFO,
                                "",
                                "Webサーバーが更新された可能性があります。" + "\r\n" +
                                "受信処理実行後、再度処理を行って下さい。" + "\r\n",
                                -1,
                                MessageBoxButtons.OK);
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                        else if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            TMsgDisp.Show(
                                new Form(),
                                emErrorLevel.ERR_LEVEL_INFO,
                                "",
                                "Webサーバーの更新に失敗しました。" + "\r\n" +
                                "受信処理実行後、再度処理を行って下さい。" + "\r\n",
                                -1,
                                MessageBoxButtons.OK);
                            return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        }
                    }
                }
                #endregion

                #region ●SCM Webサーバー確定済チェック
                if (scmFlg)
                {
                    if ((customSerializeArrayList1 != null) && (customSerializeArrayList1.Count != 0))
                    {
                        bool isFixed;
                        if (null == _salesSlipInputAcs)
                        {
                            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
                        }
                        int st = this._salesSlipInputAcs.CheckScmOdrDataFixed(customSerializeArrayList1, out isFixed);

                        if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (isFixed)
                            {
                                TMsgDisp.Show(
                                    new Form(),
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    "",
                                    "Webサーバーのデータが確定済みです。" + "\r\n" +
                                    "この伝票は、登録および送信することはできません。" + "\r\n",
                                    -1,
                                    MessageBoxButtons.OK);
                                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            }
                        }
                    }
                }
                #endregion
            }
            // --- Add 2011/08/06 duzg for 赤伝発行時、データ送信対応 ---<<<

            string retMessage;
            object writeObjSales;
            object writeObjStock = null;
            this.CreateParamForSaveDBData( out writeObjSales, ref paraList, parameter, out retMessage, ref _printRedSalesSlipNo );
            status = 0;
            // --- UPD m.suzuki 2010/10/07 ----------<<<<<

            # region [仕入返品伝票登録]
            if ( orgStockSlipDic != null && orgStockSlipDic.Count > 0 &&
                orgStockDetailListDic != null && orgStockSlipDic.Count > 0 )
            {
                // リモートオブジェクト生成
                if ( _iStockSlipDB == null )
                {
                    _iStockSlipDB = MediationStockSlipDB.GetStockSlipDB();
                }

                List<StockSlipWork> redStockSlipList = new List<StockSlipWork>();
                List<List<StockDetailWork>> redStockDetailListList = new List<List<StockDetailWork>>();


                foreach ( StockSlipLogicalKey key in orgStockSlipDic.Keys )
                {
                    // 明細が無い場合は迂回
                    if ( !orgStockDetailListDic.ContainsKey( key ) ) continue;

                    StockSlipWork redStockSlip;
                    List<StockDetailWork> redStockDetailList;

                    // ---------- ADD 2012/08/22 ---------->>>>>
                    // キー値の一部を更新するために別変数にコピー
                    StockSlipLogicalKey keyBuf = key;

                    // 仕入日用退避ディクショナリから、該当する仕入日（グリッド上で入力された仕入日）を取得
                    DateTime stockDateForUpdateBuf = stockDateForUpdateDic[key];

                    // 仕入伝票読み込みのためのキー値のうち、仕入日を更新する
                    // 検索に使用する仕入日は、グリッド上で入力された仕入日とする
                    keyBuf.StockDate = stockDateForUpdateBuf;
                    // ---------- ADD 2012/08/22 ----------<<<<<

                    // 仕入伝票読み込み(これから発行しようとしている仕入返品伝票と同一伝票番号の返品が無いかチェック)
                    // ---------- DEL 2012/08/22 ---------->>>>>
                    //ReadStockSlip( key, out redStockSlip, out redStockDetailList );
                    // ---------- DEL 2012/08/22 ----------<<<<<
                    // ---------- ADD 2012/08/22 ---------->>>>>
                    ReadStockSlip(keyBuf, out redStockSlip, out redStockDetailList);
                    // ---------- ADD 2012/08/22 ----------<<<<<

                    if ( redStockSlip == null )
                    {
                        // 仕入返品伝票 新規作成
                        //redStockSlip = orgStockSlipDic[key];      // DEL 2014/08/26 鄧潘ハン SCM仕掛一覧 №10650の②
                        redStockSlip = orgStockSlipDic[key].Clone();// ADD 2014/08/26 鄧潘ハン SCM仕掛一覧 №10650の②
                        redStockDetailList = orgStockDetailListDic[key];
                        // ---------- DEL 2012/08/22 ---------->>>>>
                        //CreateRedStockSlip( key, ref redStockSlip, ref redStockDetailList, parameter );
                        // ---------- DEL 2012/08/22 ----------<<<<<
                        // ---------- ADD 2012/08/22 ---------->>>>>
                        CreateRedStockSlip(key, ref redStockSlip, ref redStockDetailList, parameter, stockDateForUpdateBuf);
                        // ---------- ADD 2012/08/22 ----------<<<<<
                    }
                    else
                    {
                        // ---------- ADD 2012/08/22 ---------->>>>>

                        // 仕入商品区分をチェック
                        // 「合計」であれば、赤伝発行せず処理終了
                        if (redStockSlip.StockGoodsCd == 6)
                        {
                            errorMessage = "伝票番号：" + keyBuf.PartySaleSlipNum + "は合計入力の伝票です";
                            return -101;
                        }

                        // 仕入伝票区分チェック
                        // 仕入伝票区分が「返品」ではなく、画面上で指定した伝票区分が「掛売上」でなければ
                        // （つまり、仕入伝票区分が「仕入」で画面上で指定した伝票区分が「掛返品」の場合）、
                        // 赤伝発行せず処理終了
                        if (redStockSlip.SupplierSlipCd != 20 &&
                            parameter.SlipCd != 0)
                        {
                            errorMessage = "伝票番号：" + keyBuf.PartySaleSlipNum + "は既存の同一仕入伝票と伝票区分が違います";
                            return -102;
                        }

                        // 仕入伝票区分が「返品」だが、画面上で指定した伝票区分が「掛売上」であれば、
                        // 赤伝発行せず処理終了
                        if (redStockSlip.SupplierSlipCd == 20 &&
                            parameter.SlipCd == 0)
                        {
                            errorMessage = "伝票番号：" + keyBuf.PartySaleSlipNum + "は既存の同一仕入伝票と伝票区分が違います";
                            return -102;
                        }

                        // ---------- ADD 2012/08/22 ----------<<<<<


                        // 仕入返品伝票 更新
                        // ---------- DEL 2012/08/22 ---------->>>>>
                        //UpdateRedStockSlip(key, ref redStockSlip, ref redStockDetailList, orgStockSlipDic[key], orgStockDetailListDic[key], parameter);
                        // ---------- DEL 2012/08/22 ----------<<<<<
                        // ---------- ADD 2012/08/22 ---------->>>>>
                        UpdateRedStockSlip(key, ref redStockSlip, ref redStockDetailList, orgStockSlipDic[key], orgStockDetailListDic[key], parameter, stockDateForUpdateBuf);
                        // ---------- ADD 2012/08/22 ----------<<<<<
                    }
                    // リストに追加
                    redStockSlipList.Add( redStockSlip );
                    redStockDetailListList.Add( redStockDetailList );
                }

                // --- UPD m.suzuki 2010/10/07 ---------->>>>>
                //status = this.SaveDBDataOfStock( redStockSlipList, redStockDetailListList, out retMessage, ref _printRedSalesSlipNo );
                //if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                //{
                //    errorMessage = "保存に失敗しました。";
                //    return status;
                //}
                this.CreateParamForSaveDBDataOfStock( out writeObjStock, redStockSlipList, redStockDetailListList, out retMessage );
                status = 0;
                // --- UPD m.suzuki 2010/10/07 ----------<<<<<
            }
            # endregion

            // --- ADD 2014/08/26 鄧潘ハン SCM仕掛一覧 №10650の① -------------------->>>>>
            #region [仕入形式（同時）補正]
            if (writeObjStock != null)
            {
                // 仕入と明細関連Dictionary　key 明細Guid
                Dictionary<Guid, string> stockDtlGuid = new Dictionary<Guid, string>();
                // 同時仕入Noの初期化
                string partySaleSlipNumSalesYou = string.Empty;
                //仕入データ
                CustomSerializeArrayList writeStockHoSei = null;　
                writeStockHoSei = (writeObjStock as CustomSerializeArrayList);
                // 仕入と明細関連Dictionaryのセット
                foreach (CustomSerializeArrayList customSerializeArrayList in writeStockHoSei)
                {
                    foreach (object obj in customSerializeArrayList)
                    {
                        // 仕入データから同時仕入Noの取得
                        if (obj is StockSlipWork)
                        {
                            partySaleSlipNumSalesYou = ((StockSlipWork)obj).PartySaleSlipNum;
                        }
                        else if (obj is ArrayList)
                        {
                            // 仕入明細データから明細Guidの取得
                            if (((ArrayList)obj)[0] is StockDetailWork)
                            {
                                foreach (StockDetailWork stockDetailWork in ((ArrayList)obj))
                                {
                                    if (Guid.Empty!=stockDetailWork.DtlRelationGuid)
                                    {
                                        // 仕入と明細関連Dictionaryに仕入明細Guidと同時仕入Noのセット
                                        stockDtlGuid.Add(stockDetailWork.DtlRelationGuid, partySaleSlipNumSalesYou);
                                    }
                                }
                            }
                        }
                    }
                }

                // 売上データ
                CustomSerializeArrayList writeListHoSei = null;
                if (writeObjSales != null)
                {
                    writeListHoSei = (writeObjSales as CustomSerializeArrayList);
                    CustomSerializeArrayList customSerializeArrayListHoSei;
                    // 仕入形式（同時）補正
                    foreach (object customSerializeArrayObjList in writeListHoSei)
                    {
                        customSerializeArrayListHoSei = new CustomSerializeArrayList();
                        // 売上データ
                        if (customSerializeArrayObjList is ArrayList)
                        {
                            customSerializeArrayListHoSei = (customSerializeArrayObjList as CustomSerializeArrayList);
                        }
                        else
                        {
                            // データフィルタ
                            continue;
                        }
                        foreach (object obj in customSerializeArrayListHoSei)
                        {
                            if (obj is ArrayList)
                            {
                                if (((ArrayList)obj)[0] is SalesDetailWork)
                                {
                                    foreach (SalesDetailWork salesDetailWork in ((ArrayList)obj))
                                    {
                                        // 当該データは同時仕入Noがある時　仕入形式（同時）補正する
                                        if (stockDtlGuid.ContainsKey(salesDetailWork.DtlRelationGuid)
                                            && !string.IsNullOrEmpty(stockDtlGuid[salesDetailWork.DtlRelationGuid]))
                                        {
                                            salesDetailWork.SupplierFormalSync = 0;

                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            #endregion
            // --- ADD 2014/08/26 鄧潘ハン SCM仕掛一覧 №10650の① --------------------<<<<<

            // --- ADD m.suzuki 2010/10/07 ---------->>>>>
            // 売上・仕入を１つにまとめる
            object writeObj = writeObjSales;
            if ( writeObj != null && writeObjStock != null )
            {
                CustomSerializeArrayList writeList = (writeObj as CustomSerializeArrayList);
                foreach ( object obj in (writeObjStock as CustomSerializeArrayList) )
                {
                    writeList.Add( obj );
                }
            }
            // １つにまとめた後、紛らわしいのでNULLにする
            writeObjSales = null;
            writeObjStock = null;

            // 更新
            // ----- DEL 2013/01/15 ----->>>>>
            //status = this.SaveDBData( writeObj, out retMessage, ref _printRedSalesSlipNo );
            // ----- DEL 2013/01/15 -----<<<<<
            // ----- ADD 2013/01/15 ----->>>>>
            status = this.SaveDBData(ref writeObj, out retMessage, ref _printRedSalesSlipNo);
            // ----- ADD 2013/01/15 -----<<<<<
            // --- ADD m.suzuki 2010/10/07 ----------<<<<<

            // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
            // TSPインラインオプションが立っている時、且つ、ＴＳＰインラインの得意先の時
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // TSP連携マスタ設定情報設定ある場合
                if (TspCprtStWorkList != null && TspCprtStWorkList.Count > 0)
                {
                    SalesSlipWork salesSlp = new SalesSlipWork();
                    CustomSerializeArrayList retList = (CustomSerializeArrayList)writeObj;
                    for (int i = 0; i < retList.Count; i++)
                    {
                        if ((object)retList[i] is CustomSerializeArrayList)
                        {
                            CustomSerializeArrayList list = (CustomSerializeArrayList)retList[i];
                            foreach (object obj in list)
                            {
                                if (obj is SalesSlipWork)
                                {
                                    // 売上伝票データ取得
                                    salesSlp = (SalesSlipWork)obj;
                                    break;
                                }
                            }
                        }
                        // 売上伝票データ取得した場合
                        if (salesSlp.CustomerCode != 0)
                        {
                            break;
                        }
                    }
                    bool tspCustomerCode = false;
                    int sendCode = -1;
                    // 得意先コードが設定するの判断
                    foreach (TspCprtStWork tspWork in TspCprtStWorkList)
                    {
                        if (tspWork.CustomerCode == salesSlp.CustomerCode)
                        {
                            // 送信区分
                            sendCode = tspWork.SendCode;
                            // 赤伝送信有り
                            if (tspWork.DebitNSendCode == 0)
                            {
                                tspCustomerCode = true;
                            }
                            break;
                        }
                    }
                    // 指示書№入力した、且つ、得意先コードが設定する
                    if (tspCustomerCode && salesSlp.PartySaleSlipNum != string.Empty)
                    {
                        WriteTspSdRvDataAcs tspAcs = new WriteTspSdRvDataAcs();
                        try
                        {
                            // ---UPD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------>>>>
                            //bool tspFlg = tspAcs.GetTspSdRvData((CustomSerializeArrayList)writeObj, 1, this.TspCprtStWorkList);
                            bool dataFlg = false;
                            bool tspFlg = tspAcs.GetTspSdRvData((CustomSerializeArrayList)writeObj, 1, this.TspCprtStWorkList, out dataFlg);
                            // ---UPD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------<<<<
                            if (!tspFlg)
                            {
                                LogWrite("WriteRedSlip", "TSP送信データ作成に失敗しました、\\Log\\TSP送信データ作成\\PMTSP01201A.Logを確認してください。");
                            }
                            else
                            {
                                // ---ADD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------>>>>
                                if (!dataFlg)
                                {
                                    LogWrite("WriteRedSlip", "TSP送信対象ではない。");
                                }
                                else
                                {
                                // ---ADD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------<<<<
                                    LogWrite("WriteRedSlip", "TSP送信データを作成しました。");
                                    // 送信区分0:自動の場合
                                    if (sendCode == 0)
                                    {
                                        // TSP.NS自動送信処理
                                        Process.Start("PMTSP01100U.EXE", this.Parameter + " /A");
                                    }
                                }// ADD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応
                                
                            }
                        }
                        catch (Exception ex)
                        {
                            LogWrite("WriteRedSlip", "TSP送信データ作成に失敗しました、" + ex.Message.ToString());
                        }
                    }
                }
            }
            // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
            // ----- ADD 2013/01/15 ----->>>>>
            #region [仕入返品予定データ登録]

            // 仕入返品予定区分が「する」の場合のみ処理実行
            if (_salesTtlSt.StockRetGoodsPlnDiv == 1)
            {
                // 売上・仕入のデータ更新処理がNGだった場合は、以降の処理を行わない
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;

                if (stockSlipRgdsExpctDic != null && stockSlipRgdsExpctDic.Count > 0 &&
                    stockSlipRgdsExpctDetailListDic != null && stockSlipRgdsExpctDetailListDic.Count > 0)
                {
                    // 仕入返品予定データ登録用格納リスト初期化
                    List<StockSlipWork> rgdsExpctList = new List<StockSlipWork>();
                    List<List<StockDetailWork>> rgdsExpctDetailList = new List<List<StockDetailWork>>();

                    // 仕入返品予定データ（仕入データ）のキャッシュ件数分ループ
                    foreach (StockSlipLogicalKey key in stockSlipRgdsExpctDic.Keys)
                    {
                        // 仕入返品予定データ（仕入明細データ）が存在しない場合は以降の処理をスキップ
                        // （通常はあり得ない）
                        if (!stockSlipRgdsExpctDetailListDic.ContainsKey(key)) continue;

                        // キャッシュから仕入返品予定データ（仕入データ、仕入明細データ）を取得
                        StockSlipWork stockSlipRgdsExpct = stockSlipRgdsExpctDic[key];
                        List<StockDetailWork> stockSlipRgdsExpctDetaiList = stockSlipRgdsExpctDetailListDic[key];

                        // 仕入返品予定データ（仕入データ）の明細行数を、仕入返品予定データ（仕入明細データ）のデータ件数で更新
                        stockSlipRgdsExpct.DetailRowCount = stockSlipRgdsExpctDetaiList.Count;

                        // 仕入先マスタから消費税端数処理情報を取得
                        int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, stockSlipRgdsExpct.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
                        double fracProcUnit;
                        int fracProcCd;
                        this.GetStockFractionProcInfo(ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

                        // 仕入返品予定データ（仕入データ）の仕入合計金額を更新
                        // （画面上で入力された返品数、原価を元に計算し直して更新）
                        StockSlipPriceCalculator.TotalPriceSetting(ref stockSlipRgdsExpct, stockSlipRgdsExpctDetaiList, fracProcUnit, fracProcCd);

                        // リストに追加
                        rgdsExpctList.Add(stockSlipRgdsExpct);
                        rgdsExpctDetailList.Add(stockSlipRgdsExpctDetaiList);
                    }

                    // 仕入返品計上更新部品(PMKAK01100A)で、仕入返品予定データ（仕入明細データ）の売上明細通番(同時)に
                    // 売上明細データ（赤伝）の売上明細通番を設定するため、
                    // 売上明細データ（赤伝）のGUIDを仕入返品予定データ（仕入明細データ）のGUIDにセット
                    status = setGUIDForRgdsExpct(writeObj, ref rgdsExpctDetailList, out errorMessage);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // 仕入返品予定データ（仕入明細データ）　仕入行番号更新
                        setStockRowNoForRgdsExpct(ref rgdsExpctDetailList);

                        // 書き込みパラメータ生成（仕入返品予定データ、他パラメータ）
                        object writeObjStockForRgdsExpct;
                        this.CreateParamForSaveDBDataOfRgdsExpct(out writeObjStockForRgdsExpct, rgdsExpctList, rgdsExpctDetailList);

                        // 売上データ（赤伝）売上伝票番号リスト作成
                        ArrayList slipNoList;
                        status =  createSlipNoList(out slipNoList, _printRedSalesSlipNo, out errorMessage);
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 仕入返品予定データを登録　仕入返品計上更新部品(PMKAK01100A)を使用
                            status = this._stockSlipRetPlnAcs.WriteStockSlipRetPln((object)writeObjStockForRgdsExpct, slipNoList, out errorMessage);
                        }
                    }
                }
            }

            #endregion [仕入返品予定データ登録]
            // ----- ADD 2013/01/15 -----<<<<<
            return status;
        }
        // --- ADD duzg 2011/08/06 ---------->>>>>
        public bool CheckScmDataExit(string salesSlipNum, int acptAnOdrStatus)
        {
            IOWriteSCMReadWork iOWriteSCMReadWork = new IOWriteSCMReadWork();
            iOWriteSCMReadWork.SalesSlipNum = salesSlipNum;
            iOWriteSCMReadWork.EnterpriseCode = this._enterpriseCode;
            iOWriteSCMReadWork.AcptAnOdrStatus = acptAnOdrStatus;
            object retScmCsObj = null;
            object paraSCMReadObj = (object)iOWriteSCMReadWork;
            int status = _iIOWritScmDB.ScmRead(ref retScmCsObj, paraSCMReadObj);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // --- ADD 2012/12/19 T.MIyamoto ------------------------------>>>>>
        /// <summary>
        /// サーバーシステム日付を取得します
        /// </summary>
        /// <returns>DateTime.now</returns>
        /// <br>Note        : サーバーシステム日付取得を戻します	</br>
        /// <br>Programmer  : 今野</br>
        public DateTime GetServerNowTime()
        {
            if (_iCustPrtPprWorkDB == null)
            {
                _iCustPrtPprWorkDB = MediationCustPrtPprWorkDB.GetCustPrtPprWorkDB();
            }

            // 日時から日付に変換して返す
            DateTime time = _iCustPrtPprWorkDB.GetServerNowTime();
            return time.Date;
        }
        // --- ADD 2012/12/19 T.MIyamoto ------------------------------<<<<<

        /// <summary>
        /// SCM情報保存用オブジェクト取得
        /// </summary>
        /// <param name="acceptOdrCarWorkList">受注マスタ(車両)データリスト</param>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="scmAcOdrDataWork">SCM受注データ</param>
        /// <param name="scmAcOdrDtCarWork">SCM受注データ(車両情報)</param>
        /// <param name="scmAcOdrDtlIqWorkList">SCM受注明細データ（問合せ・発注）</param>
        /// <param name="scmAcOdrDtlAsWorkList">SCM受注明細データ（回答）</param>
        /// <remarks>
        /// <br>Update Note : 2018/04/16 譚洪</br>
        /// <br>管理番号    : 11470007-00</br>
        /// <br>            : 赤伝発行時に元黒伝票に設定されている新BLコード等の新項目をSCM受注明細データ(回答)データに設定する。</br>
        /// </remarks>
        // UPD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region 旧ソース
        ////>>>2012/03/21
        ////private void GetCurrentSCM(List<AcceptOdrCarWork> acceptOdrCarList, SalesSlip salesSlip, List<SalesDetail> salesDetailList, out SCMAcOdrDataWork scmAcOdrDataWork, out SCMAcOdrDtCarWork scmAcOdrDtCarWork, out ArrayList scmAcOdrDtlIqWorkList, out ArrayList scmAcOdrDtlAsWorkList)
        //private void GetCurrentSCM(string salesSlipNum, List<AcceptOdrCarWork> acceptOdrCarList, SalesSlip salesSlip, List<SalesDetail> salesDetailList, out SCMAcOdrDataWork scmAcOdrDataWork, out SCMAcOdrDtCarWork scmAcOdrDtCarWork, out ArrayList scmAcOdrDtlIqWorkList, out ArrayList scmAcOdrDtlAsWorkList)
        ////<<<2012/03/21
        #endregion
        private void GetCurrentSCM(string salesSlipNum, List<AcceptOdrCarWork> acceptOdrCarList, SalesSlip salesSlip, List<SalesDetail> salesDetailList, out SCMAcOdrDataWork scmAcOdrDataWork, out SCMAcOdrDtCarWork scmAcOdrDtCarWork, out ArrayList scmAcOdrDtlIqWorkList, out ArrayList scmAcOdrDtlAsWorkList, List<int[]> rowNoNewOld )
        // UPD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            scmAcOdrDataWork = null;
            scmAcOdrDtCarWork = null;
            scmAcOdrDtlAsWorkList = null;
            scmAcOdrDtlIqWorkList = null;

            if ((salesSlip == null) ||
                (salesDetailList == null) ||
                (salesDetailList.Count == 0) ||
                (salesSlip.OnlineKindDiv != (int)OnlineKindDiv.SCM)) return;

            // 得意先取得
            CustomerInfo customer;
            int custStatus = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, salesSlip.EnterpriseCode, salesSlip.CustomerCode, true, false, out customer);
            if (custStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL) customer = new CustomerInfo();

            // ADD 2013/06/19 T.Miyamoto ------------------------------>>>>>
            // 売上データからSCM情報取得
            UserSCMOrderHeaderRecord scmHeader;
            UserSCMOrderCarRecord scmCar;
            List<UserSCMOrderDetailRecord> scmDetailList;
            List<UserSCMOrderAnswerRecord> scmAnswerList;
            this.ReadDBData(ConstantManagement.LogicalMode.GetData0
                          , salesSlip.EnterpriseCode
                          , salesSlip.AcptAnOdrStatus
                          , salesSlipNum
                          , out scmHeader
                          , out scmCar
                          , out scmDetailList
                          , out scmAnswerList);
            // ADD 2013/06/19 T.Miyamoto ------------------------------<<<<<

            //-----------------------------------------------------------------------------
            // SCM受注データ取得
            //-----------------------------------------------------------------------------
            # region SCM受注データ
            scmAcOdrDataWork = new SCMAcOdrDataWork();
            scmAcOdrDataWork.InqOtherEpCd = this._enterpriseCode; // 問合せ先企業コード
            scmAcOdrDataWork.InqOtherSecCd = salesSlip.ResultsAddUpSecCd; // 問合せ先拠点コード
            scmAcOdrDataWork.InquiryNumber = salesSlip.InquiryNumber; // 問合せ番号
            scmAcOdrDataWork.CustomerCode = salesSlip.CustomerCode; // 得意先コード
            scmAcOdrDataWork.AnswerDivCd = 20; // 回答区分
            scmAcOdrDataWork.AnswerCreateDiv = 2; // 回答作成区分(0:自動, 1:手動(Web), 2:手動(その他))// 2011/08/18 duzg for Redmine#23241
            scmAcOdrDataWork.InqOrdNote = salesSlip.SlipNote; // 問合せ・発注備考 
            scmAcOdrDataWork.AnsEmployeeCd = salesSlip.SalesEmployeeCd; // 回答従業員コード
            scmAcOdrDataWork.AnsEmployeeNm = salesSlip.SalesEmployeeNm; // 回答従業員名称
            scmAcOdrDataWork.InquiryDate = salesSlip.SalesDate; // 問合せ日
            scmAcOdrDataWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // 受注ステータス
            scmAcOdrDataWork.SalesSlipNum = salesSlip.SalesSlipNum; // 売上伝票番号
            scmAcOdrDataWork.SalesTotalTaxInc = salesSlip.SalesTotalTaxInc; // 売上伝票合計（税込み）
            scmAcOdrDataWork.SalesSubtotalTax = salesSlip.SalesSubtotalTax; // 売上小計（税）
            scmAcOdrDataWork.InqOrdDivCd = 2; // 問合せ・発注種別
            scmAcOdrDataWork.InqOrdAnsDivCd = 2; // 問発・回答種別(2:回答)
            scmAcOdrDataWork.SfPmCprtInstSlipNo = salesSlip.PartySaleSlipNum;
            scmAcOdrDataWork.InqOriginalEpCd = customer.CustomerEpCode.Trim();// 問合せ元企業コード//@@@@20230303
            scmAcOdrDataWork.InqOriginalSecCd = customer.CustomerSecCode;// 問合せ元拠点コード
            scmAcOdrDataWork.CancelDiv = 1;
            // ---------------------- ADD START 2011.09.21 redmine#25412 zhubj ----------------->>>>>
            if (salesDetailList != null && salesDetailList.Count > 0)
            {
                scmAcOdrDataWork.AcceptOrOrderKind = salesDetailList[0].AcceptOrOrderKind;//受発注種別
            }
            // ---------------------- ADD END   2011.09.21 redmine#25412 zhubj -----------------<<<<<
            // ADD 2013/06/19 T.Miyamoto ------------------------------>>>>>
            scmAcOdrDataWork.CarMngCode = scmHeader.CarMngCode; // 車輌管理コード
            scmAcOdrDataWork.TabUseDiv = scmHeader.TabUseDiv;   // タブレット使用区分
            // ADD 2013/06/19 T.Miyamoto ------------------------------<<<<<
            // --- ADD 2014/08/12 T.Miyamoto SCM仕掛一覧 №10643 -------------------->>>>>
            scmAcOdrDataWork.InqEmployeeCd = scmHeader.InqEmployeeCd; // 問合せ従業員コード
            // --- ADD 2014/08/12 T.Miyamoto SCM仕掛一覧 №10643 --------------------<<<<<
            # endregion
            //-----------------------------------------------------------------------------
            // SCM受注データ(車両情報)取得
            //-----------------------------------------------------------------------------
            # region SCM受注データ(車両情報)
            scmAcOdrDtCarWork = new SCMAcOdrDtCarWork();
            // 問合せ元企業コード
            scmAcOdrDtCarWork.InqOriginalEpCd = customer.CustomerEpCode.Trim();//@@@@20230303
            // 問合せ元拠点コード
            scmAcOdrDtCarWork.InqOriginalSecCd = customer.CustomerSecCode;
            // 問合せ番号
            scmAcOdrDtCarWork.InquiryNumber = salesSlip.InquiryNumber;
            // 受注ステータス
            scmAcOdrDtCarWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus;
            // 売上伝票番号
            scmAcOdrDtCarWork.SalesSlipNum = salesSlip.SalesSlipNum;

            // ADD 2013/10/22 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№93 Redmine#37707 ------->>>>>>>>>>>>>>>
            if (scmCar != null)
            {
                // 陸運事務所番号
                scmAcOdrDtCarWork.NumberPlate1Code = scmCar.NumberPlate1Code;
                // 陸運事務局名称
                scmAcOdrDtCarWork.NumberPlate1Name = scmCar.NumberPlate1Name;
                // 車両登録番号（種別）
                scmAcOdrDtCarWork.NumberPlate2 = scmCar.NumberPlate2;
                // 車両登録番号（カナ）
                scmAcOdrDtCarWork.NumberPlate3 = scmCar.NumberPlate3;
                // 車両登録番号（プレート番号）
                scmAcOdrDtCarWork.NumberPlate4 = scmCar.NumberPlate4;
                // 型式指定番号
                scmAcOdrDtCarWork.ModelDesignationNo = scmCar.ModelDesignationNo;
                // 類別番号
                scmAcOdrDtCarWork.CategoryNo = scmCar.CategoryNo;
                // メーカーコード
                scmAcOdrDtCarWork.MakerCode = scmCar.MakerCode;
                // 車種コード
                scmAcOdrDtCarWork.ModelCode = scmCar.ModelCode;
                // 車種サブコード
                scmAcOdrDtCarWork.ModelSubCode = scmCar.ModelSubCode;
                // 車種名
                scmAcOdrDtCarWork.ModelName = scmCar.ModelName;
                // 車検証型式
                scmAcOdrDtCarWork.CarInspectCertModel = scmCar.CarInspectCertModel;
                // 型式（フル型）
                scmAcOdrDtCarWork.FullModel = scmCar.FullModel;
                // 車台番号
                scmAcOdrDtCarWork.FrameNo = scmCar.FrameNo;
                // 車台型式
                scmAcOdrDtCarWork.FrameModel = scmCar.FrameModel;
                // シャシーNo
                scmAcOdrDtCarWork.ChassisNo = scmCar.ChassisNo;
                // 車両固有番号
                scmAcOdrDtCarWork.CarProperNo = scmCar.CarProperNo;
                // 生産年式(NUMタイプ)
                scmAcOdrDtCarWork.ProduceTypeOfYearNum = scmCar.ProduceTypeOfYearNum;
                // コメント
                scmAcOdrDtCarWork.Comment = scmCar.Comment;
                // リペアカラーコード
                scmAcOdrDtCarWork.RpColorCode = scmCar.RpColorCode;
                // カラー名称1
                scmAcOdrDtCarWork.ColorName1 = scmCar.ColorName1;
                // トリムコード
                scmAcOdrDtCarWork.TrimCode = scmCar.TrimCode;
                // トリム名称
                scmAcOdrDtCarWork.TrimName = scmCar.TrimName;
                // 車両走行距離
                scmAcOdrDtCarWork.Mileage = scmCar.Mileage;
                // 装備オブジェクト
                scmAcOdrDtCarWork.EquipObj = scmCar.EquipObj;
                // 号車
                scmAcOdrDtCarWork.CarNo = scmCar.CarNo;
                // メーカー名称
                scmAcOdrDtCarWork.MakerName = scmCar.MakerName;
                // グレード名称
                scmAcOdrDtCarWork.GradeName = scmCar.GradeName;
                // ボディー名称
                scmAcOdrDtCarWork.BodyName = scmCar.BodyName;
                // ドア数
                scmAcOdrDtCarWork.DoorCount = scmCar.DoorCount;
                // エンジン型式名称
                scmAcOdrDtCarWork.EngineModelNm = scmCar.EngineModelNm;
                // 通称排気量
                scmAcOdrDtCarWork.CmnNmEngineDisPlace = scmCar.CmnNmEngineDisPlace;
                // 原動機型式（エンジン）
                scmAcOdrDtCarWork.EngineModel = scmCar.EngineModel;
                // 変速段数
                scmAcOdrDtCarWork.NumberOfGear = scmCar.NumberOfGear;
                // 変速機名称
                scmAcOdrDtCarWork.GearNm = scmCar.GearNm;
                // E区分名称
                scmAcOdrDtCarWork.EDivNm = scmCar.EDivNm;
                // ミッション名称
                scmAcOdrDtCarWork.TransmissionNm = scmCar.TransmissionNm;
                // シフト名称
                scmAcOdrDtCarWork.ShiftNm = scmCar.ShiftNm;
                // 初年度（NUMタイプ）
                scmAcOdrDtCarWork.FirstEntryDateNumTyp = scmCar.FirstEntryDateNumTyp;
                // 車両付加情報オブジェクト
                scmAcOdrDtCarWork.CarAddInf = scmCar.CarAddInf;
                // 装備部品オブジェクト
                scmAcOdrDtCarWork.EquipPrtsObj = scmCar.EquipPrtsObj;
                // 車輌管理コード
                scmAcOdrDtCarWork.CarMngCode = scmCar.CarMngCode;
                // 入庫予定日
                scmAcOdrDtCarWork.ExpectedCeDate = scmCar.ExpectedCeDate;
            }
            else
            // ADD 2013/10/22 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№93 Redmine#37707 -------<<<<<<<<<<<<<<<
            if (acceptOdrCarList != null && acceptOdrCarList.Count > 0)
            {
                // 陸運事務所番号
                scmAcOdrDtCarWork.NumberPlate1Code = acceptOdrCarList[0].NumberPlate1Code;
                // 陸運事務局名称
                scmAcOdrDtCarWork.NumberPlate1Name = acceptOdrCarList[0].NumberPlate1Name;
                // 車両登録番号（種別）
                scmAcOdrDtCarWork.NumberPlate2 = acceptOdrCarList[0].NumberPlate2;
                // 車両登録番号（カナ）
                scmAcOdrDtCarWork.NumberPlate3 = acceptOdrCarList[0].NumberPlate3;
                // 車両登録番号（プレート番号）
                scmAcOdrDtCarWork.NumberPlate4 = acceptOdrCarList[0].NumberPlate4;
                // 型式指定番号
                scmAcOdrDtCarWork.ModelDesignationNo = acceptOdrCarList[0].ModelDesignationNo;
                // 類別番号
                scmAcOdrDtCarWork.CategoryNo = acceptOdrCarList[0].CategoryNo;
                // メーカーコード
                scmAcOdrDtCarWork.MakerCode = acceptOdrCarList[0].MakerCode;
                // 車種コード
                scmAcOdrDtCarWork.ModelCode = acceptOdrCarList[0].ModelCode;
                // 車種サブコード
                scmAcOdrDtCarWork.ModelSubCode = acceptOdrCarList[0].ModelSubCode;
                // 車種名
                scmAcOdrDtCarWork.ModelName = acceptOdrCarList[0].ModelFullName;
                string carInspectCertModel = string.Empty;
                if (acceptOdrCarList[0].ExhaustGasSign.Trim() != string.Empty)
                {
                    carInspectCertModel = acceptOdrCarList[0].ExhaustGasSign.Trim();
                    if (acceptOdrCarList[0].SeriesModel.Trim() != string.Empty) carInspectCertModel = carInspectCertModel + '-' + acceptOdrCarList[0].SeriesModel.Trim();
                }
                else
                {
                    if (acceptOdrCarList[0].SeriesModel.Trim() != string.Empty) carInspectCertModel = acceptOdrCarList[0].SeriesModel.Trim();
                }
                // 車検証型式
                scmAcOdrDtCarWork.CarInspectCertModel = carInspectCertModel;
                // 型式（フル型）
                scmAcOdrDtCarWork.FullModel = acceptOdrCarList[0].FullModel;
                // 車台番号
                scmAcOdrDtCarWork.FrameNo = acceptOdrCarList[0].FrameNo;
                // 車台型式
                scmAcOdrDtCarWork.FrameModel = acceptOdrCarList[0].FrameModel;
                // リペアカラーコード
                scmAcOdrDtCarWork.RpColorCode = acceptOdrCarList[0].ColorCode;
                // カラー名称1
                scmAcOdrDtCarWork.ColorName1 = acceptOdrCarList[0].ColorName1;
                // トリムコード
                scmAcOdrDtCarWork.TrimCode = acceptOdrCarList[0].TrimCode;
                // トリム名称
                scmAcOdrDtCarWork.TrimName = acceptOdrCarList[0].TrimName;
                // 車両走行距離
                scmAcOdrDtCarWork.Mileage = acceptOdrCarList[0].Mileage;
                // 装備オブジェクト
                scmAcOdrDtCarWork.EquipObj = acceptOdrCarList[0].CategoryObjAry;
                // ADD 2013/06/19 T.Miyamoto ------------------------------>>>>>
                // 車輌管理コード
                scmAcOdrDtCarWork.CarMngCode = scmCar.CarMngCode;
                // 入庫予定日
                scmAcOdrDtCarWork.ExpectedCeDate = scmCar.ExpectedCeDate;
                // ADD 2013/06/19 T.Miyamoto ------------------------------<<<<<
            }
            # endregion
            

            //-----------------------------------------------------------------------------
            // SCM受注明細データ(問合せ・発注)取得
            //-----------------------------------------------------------------------------
            scmAcOdrDtlAsWorkList = null;

            //-----------------------------------------------------------------------------
            // SCM受注明細データ(回答)取得
            //-----------------------------------------------------------------------------
            //>>>2012/03/21
            //GetScmOdDtAnsList(salesSlip, salesDetailList, out scmAcOdrDtlAsWorkList);
            GetScmOdDtAnsList(salesSlipNum, salesSlip, salesDetailList, out scmAcOdrDtlAsWorkList);
            //<<<2012/03/21
            foreach (SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork in scmAcOdrDtlAsWorkList)
            {
                // 問合せ元企業コード
                sCMAcOdrDtlAsWork.InqOriginalEpCd = customer.CustomerEpCode.Trim();//@@@@20230303
                // 問合せ元拠点コード
                sCMAcOdrDtlAsWork.InqOriginalSecCd = customer.CustomerSecCode;
                // キャンセル状態区分
                sCMAcOdrDtlAsWork.CancelCndtinDiv = 30;
                sCMAcOdrDtlAsWork.SalesSlipNum = string.Empty;
                sCMAcOdrDtlAsWork.InqOrdDivCd = 2;

                // ADD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // 赤伝の伝票行番号から、元黒の伝票行番号を検索
                int[] rowNoNewOldTgt = rowNoNewOld.Find(
                    delegate(int[] newOld)
                    {
                        if (newOld[0] == sCMAcOdrDtlAsWork.SalesRowNo)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    );

                if (rowNoNewOldTgt != null)
                {
                    // 元黒のSCM受注明細データ(回答)を検索
                    UserSCMOrderAnswerRecord tgtAns = scmAnswerList.Find(
                        delegate(UserSCMOrderAnswerRecord r)
                        {
                            if (r.SalesRowNo == rowNoNewOldTgt[1])
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                    // 元黒のSCM受注明細データ(回答)の倉庫情報の上書き
                    if (tgtAns != null)
                    {
                        // 倉庫コード
                        sCMAcOdrDtlAsWork.WarehouseCode = tgtAns.PmWarehouseCd;
                        // 倉庫名称
                        sCMAcOdrDtlAsWork.WarehouseName = tgtAns.PmWarehouseName;
                        // 倉庫棚番
                        sCMAcOdrDtlAsWork.WarehouseShelfNo = tgtAns.PmShelfNo;
                        // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
                        // 優良設定詳細コード２
                        sCMAcOdrDtlAsWork.PrmSetDtlNo2 = tgtAns.PrmSetDtlNo2;
                        // 優良設定詳細名称２
                        sCMAcOdrDtlAsWork.PrmSetDtlName2 = tgtAns.PrmSetDtlName2;
                        // 在庫状況区分
                        sCMAcOdrDtlAsWork.StockStatusDiv = tgtAns.StockStatusDiv;
                        // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
                        // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
                        // 貸出区分
                        sCMAcOdrDtlAsWork.RentDiv = tgtAns.RentDiv;
                        // メーカー希望小売価格
                        sCMAcOdrDtlAsWork.MkrSuggestRtPric = tgtAns.MkrSuggestRtPric;
                        // オープン価格区分
                        sCMAcOdrDtlAsWork.OpenPriceDiv = tgtAns.OpenPriceDiv;
                        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
                        // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
                        // お買得商品選択区分
                        sCMAcOdrDtlAsWork.BgnGoodsDiv = tgtAns.BgnGoodsDiv;
                        // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

                        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
                        // 型式別部品採用年月
                        sCMAcOdrDtlAsWork.ModelPrtsAdptYm = tgtAns.ModelPrtsAdptYm;
                        // 型式別部品廃止年月
                        sCMAcOdrDtlAsWork.ModelPrtsAblsYm = tgtAns.ModelPrtsAblsYm;
                        // 型式別部品採用車台番号
                        sCMAcOdrDtlAsWork.ModelPrtsAdptFrameNo = tgtAns.ModelPrtsAdptFrameNo;
                        // 型式別部品廃止車台番号
                        sCMAcOdrDtlAsWork.ModelPrtsAblsFrameNo = tgtAns.ModelPrtsAblsFrameNo;
                        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

                        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // 回答納期区分
                        sCMAcOdrDtlAsWork.AnsDeliDateDiv = tgtAns.AnsDeliDateDiv;
                        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        // ADD 2015/02/23 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // 商品規格・特記事項(工場向け)
                        sCMAcOdrDtlAsWork.GoodsSpecialNtForFac = tgtAns.GoodsSpecialNtForFac;
                        // 商品規格・特記事項(カーオーナー向け)
                        sCMAcOdrDtlAsWork.GoodsSpecialNtForCOw = tgtAns.GoodsSpecialNtForCOw;
                        // 優良設定詳細名称２(工場向け)
                        sCMAcOdrDtlAsWork.PrmSetDtlName2ForFac = tgtAns.PrmSetDtlName2ForFac;
                        // 優良設定詳細名称２(カーオーナー向け)
                        sCMAcOdrDtlAsWork.PrmSetDtlName2ForCOw = tgtAns.PrmSetDtlName2ForCOw;
                        // ADD 2015/02/23 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        //----- ADD 2018/04/16 譚洪 SCM連携 新BLコード対応 ---------->>>>>
                        // 問発BL統一部品コード(スリーコード版)
                        sCMAcOdrDtlAsWork.InqBlUtyPtThCd = tgtAns.InqBlUtyPtThCd;
                        // 問発BL統一部品サブコード
                        sCMAcOdrDtlAsWork.InqBlUtyPtSbCd = tgtAns.InqBlUtyPtSbCd;
                        // 回答BL統一部品コード(スリーコード版)
                        sCMAcOdrDtlAsWork.AnsBlUtyPtThCd = tgtAns.AnsBlUtyPtThCd;
                        // 回答BL統一部品サブコード
                        sCMAcOdrDtlAsWork.AnsBlUtyPtSbCd = tgtAns.AnsBlUtyPtSbCd;
                        // 回答BL商品コード
                        sCMAcOdrDtlAsWork.AnsBLGoodsCode = tgtAns.AnsBLGoodsCode;
                        // 回答BL商品コード枝番
                        sCMAcOdrDtlAsWork.AnsBLGoodsDrCode = tgtAns.AnsBLGoodsDrCode;
                        //----- ADD 2018/04/16 譚洪 SCM連携 新BLコード対応 ----------<<<<<
                    }

                }
                // ADD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
        }
        
        /// <summary>
        /// SCM受注明細データ(回答)オブジェクトからSCM受注明細データ(回答)作成
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="scmAcOdrDtlAsWorkList">作成オブジェクト</param>
        //>>>2012/03/21
        //private void GetScmOdDtAnsList(SalesSlip salesSlip, List<SalesDetail> salesDetailList, out ArrayList scmAcOdrDtlAsWorkList)
        private void GetScmOdDtAnsList(string salesSlipNum, SalesSlip salesSlip, List<SalesDetail> salesDetailList, out ArrayList scmAcOdrDtlAsWorkList)
        //<<2012/03/21
        {
            scmAcOdrDtlAsWorkList = null;
            if (salesSlip == null) return;
            scmAcOdrDtlAsWorkList = new ArrayList();
            int length = 0;
            
            //>>>2012/03/21
            UserSCMOrderHeaderRecord scmHeader;
            UserSCMOrderCarRecord scmCar;
            List<UserSCMOrderDetailRecord> scmDetailList;
            List<UserSCMOrderAnswerRecord> scmAnswerList;

            // SCM情報取得の為、売上データ読込
            this.ReadDBData(ConstantManagement.LogicalMode.GetData0, salesSlip.EnterpriseCode, salesSlip.AcptAnOdrStatus, salesSlipNum, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
            //<<<2012/03/21

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                //>>>2012/03/21
                UserSCMOrderAnswerRecord retAns = null;
                if ((scmAnswerList != null) && (scmAnswerList.Count != 0))
                {
                    retAns = scmAnswerList.Find(
                        delegate(UserSCMOrderAnswerRecord ansRec)
                        {
                            if ((salesDetail.InquiryNumber == ansRec.InquiryNumber) &&
                                (salesDetail.InqRowNumber == ansRec.InqRowNumber))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                }
                //<<<2012/03/21

                //>>>2012/03/21
                //SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork = this.SetRowFromUIData(salesSlip, salesDetail, salesDetailList, length++);
                SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork = this.SetRowFromUIData(salesSlip, salesDetail, salesDetailList, retAns, length++);
                //<<<2012/03/21
                if (null != sCMAcOdrDtlAsWork)
                {
                    scmAcOdrDtlAsWorkList.Add(sCMAcOdrDtlAsWork);
                }
            }
        }

        /// <summary>
        /// SCM受注明細データ(回答)オブジェクトからSCM受注明細データ(回答)行オブジェクトに項目を設定します。
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="salesDetail">売上明細データ</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="length">問合せ行番号用</param>
        /// <br>Update Note  : 2011/09/21 Redmine#25210 返品時は回答納期をセットしないの対応 </br>
        //>>>2012/03/21
        //private SCMAcOdrDtlAsWork SetRowFromUIData(SalesSlip salesSlip, SalesDetail salesDetail, List<SalesDetail> salesDetailList, int length)
        private SCMAcOdrDtlAsWork SetRowFromUIData(SalesSlip salesSlip, SalesDetail salesDetail, List<SalesDetail> salesDetailList, UserSCMOrderAnswerRecord retAns, int length)
        //<<<201203/21
        {
            SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork = new SCMAcOdrDtlAsWork();
            #region 項目セット
            // 問合せ元企業コード
            sCMAcOdrDtlAsWork.InqOriginalEpCd = salesSlip.InqOriginalEpCd.Trim();//@@@@20230303
            // 問合せ元拠点コード
            sCMAcOdrDtlAsWork.InqOriginalSecCd = salesSlip.InqOriginalSecCd;

            if (salesSlip.InquiryNumber == 0)
            {
                // 問合せ先企業コード
                sCMAcOdrDtlAsWork.InqOtherEpCd = this._enterpriseCode;
                // 問合せ先拠点コード
                sCMAcOdrDtlAsWork.InqOtherSecCd = salesSlip.ResultsAddUpSecCd;
            }
            else
            {
                // 問合せ先企業コード
                sCMAcOdrDtlAsWork.InqOtherEpCd = sCMAcOdrDtlAsWork.InqOtherEpCd;
                // 問合せ先拠点コード
                sCMAcOdrDtlAsWork.InqOtherSecCd = sCMAcOdrDtlAsWork.InqOtherSecCd;
            }
            /* ---------------------- DEL START 2011.09.21  for Redmine#25412----------------->>>>>
            // 問合せ番号
            sCMAcOdrDtlAsWork.InquiryNumber = salesSlip.InquiryNumber;
            if ((salesDetailList != null) && (salesDetail.InqRowNumber == 0))
            {
                // 問合せ行番号
                sCMAcOdrDtlAsWork.InqRowNumber = (length + 1) * -1;
            }
            // 問合せ行番号枝番
            sCMAcOdrDtlAsWork.InqRowNumDerivedNo = sCMAcOdrDtlAsWork.InqRowNumDerivedNo;
            ---------------------- DEL END   2011.09.21 for Redmine#25412-----------------<<<<<*/

            //>>>2012/03/21
            //// --- Add 2011.09.21  for Redmine#25412 --->>>
            //// 問合せ行番号
            //sCMAcOdrDtlAsWork.InqRowNumber = salesDetail.SalesRowNo;
            //// 問合せ行番号枝番
            //sCMAcOdrDtlAsWork.InqRowNumDerivedNo = salesDetail.SalesRowDerivNo;
            //// --- Add 2011.09.21  for Redmine#25412 ---<<<

            if (retAns != null)
            {
                sCMAcOdrDtlAsWork.InqRowNumber = retAns.InqRowNumber;
                sCMAcOdrDtlAsWork.InqRowNumDerivedNo = retAns.InqRowNumDerivedNo;
            }
            else
            {
                // 問合せ行番号
                sCMAcOdrDtlAsWork.InqRowNumber = (length + 1) * -1;
                // UPD 2015/02/09 SCM連携 マルチキャスト対応 ----------------------->>>>>
                //sCMAcOdrDtlAsWork.InqRowNumDerivedNo = 1;
                sCMAcOdrDtlAsWork.InqRowNumDerivedNo = -1; // SCM-APにて採番するため固定値を設定
                // UPD 2015/02/09 SCM連携 マルチキャスト対応 -----------------------<<<<<
            }

            if (salesDetail.SalesSlipCdDtl == 2) // 返品手数料明細は値引き
            {
                sCMAcOdrDtlAsWork.GoodsDivCd = 99;
            }
            //<<<2012/03/21

            // リサイクル部品種別
            sCMAcOdrDtlAsWork.RecyclePrtKindCode = salesDetail.RecycleDiv;
            // リサイクル部品種別名称
            sCMAcOdrDtlAsWork.RecyclePrtKindName = salesDetail.RecycleDivNm;
            // 回答納期
            // ADD 2011/09/21 ---- >>>>>>
            if (salesDetail.SalesSlipCdDtl == 1)
            {
                sCMAcOdrDtlAsWork.AnswerDeliveryDate = string.Empty;
            }
            else
            {
                sCMAcOdrDtlAsWork.AnswerDeliveryDate = salesDetail.AnswerDelivDate;
            }
            // ADD 2011/09/21 ---- <<<<<<

            //sCMAcOdrDtlAsWork.AnswerDeliveryDate = salesDetail.AnswerDelivDate;  // DEL 2011/09/21
            
            // BL商品コード
            sCMAcOdrDtlAsWork.BLGoodsCode = salesDetail.PrtBLGoodsCode;
            // UPD 2012/09/27配信 2012/09/26 №35戻し T.Yoshioka ------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // ADD 2012/07/11 №35 T.Yoshioka ------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // sCMAcOdrDtlAsWork.InqGoodsName = retAns.InqGoodsName;
            // ADD 2012/07/11 №35 T.Yoshioka -------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            if (retAns != null)
            {
                sCMAcOdrDtlAsWork.InqGoodsName = retAns.InqGoodsName;
            }
            // UPD 2012/09/27配信 2012/09/26 №35戻し T.Yoshioka -------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // 回答商品名
            sCMAcOdrDtlAsWork.AnsGoodsName = salesDetail.GoodsName;
            if (sCMAcOdrDtlAsWork.SalesOrderCount == 0)
            {
                // 発注数
                sCMAcOdrDtlAsWork.SalesOrderCount = salesDetail.ShipmentCnt;
            }
            // 納品数
            sCMAcOdrDtlAsWork.DeliveredGoodsCount = salesDetail.ShipmentCnt;
            // 商品番号
            sCMAcOdrDtlAsWork.GoodsNo = salesDetail.GoodsNo;
            // 商品メーカーコード
            sCMAcOdrDtlAsWork.GoodsMakerCd = salesDetail.GoodsMakerCd;
            // 商品メーカー名称
            sCMAcOdrDtlAsWork.GoodsMakerNm = salesDetail.MakerName;
            // 定価
            sCMAcOdrDtlAsWork.ListPrice = (long)salesDetail.ListPriceTaxExcFl;
            // 単価
            sCMAcOdrDtlAsWork.UnitPrice = (long)Math.Round(salesDetail.SalesUnPrcTaxExcFl, 0, MidpointRounding.AwayFromZero);
            if ((salesDetail.ShipmentCnt == 0) && (salesDetail.SalesUnPrcTaxExcFl == 0))
            {
                // 売上金額
                sCMAcOdrDtlAsWork.UnitPrice = (long)salesDetail.SalesMoneyTaxExc;
            }

            string url = string.Empty;
            this.GetURL(salesDetail.GoodsMngNo, out url);
            // 商品補足情報
            sCMAcOdrDtlAsWork.GoodsAddInfo = url;
            // 粗利額
            sCMAcOdrDtlAsWork.RoughRrofit = (long)(salesDetail.SalesUnPrcTaxExcFl - salesDetail.SalesUnitCost);
            double totalGrossProfitRate;
            this.GetRate((salesDetail.SalesUnPrcTaxExcFl - salesDetail.SalesUnitCost), salesDetail.SalesUnPrcTaxExcFl, out totalGrossProfitRate);
            // 粗利率
            sCMAcOdrDtlAsWork.RoughRate = totalGrossProfitRate;
            // 備考(明細)
            sCMAcOdrDtlAsWork.CommentDtl = salesDetail.DtlNote;
            // 棚番
            sCMAcOdrDtlAsWork.ShelfNo = salesDetail.WarehouseShelfNo;
            // 受注ステータス
            sCMAcOdrDtlAsWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus;
            // 売上伝票番号
            sCMAcOdrDtlAsWork.SalesSlipNum = salesDetail.SalesSlipNum;
            // 売上行番号
            sCMAcOdrDtlAsWork.SalesRowNo = salesDetail.SalesRowNo;

            int InqOrdDivCd = ((salesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales) || (salesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.AcceptAnOrder)) ? 1 : 2;
            // 問合せ・発注種別
            sCMAcOdrDtlAsWork.InqOrdDivCd = InqOrdDivCd;
            // 商品管理番号
            sCMAcOdrDtlAsWork.GoodsMngNo = salesDetail.GoodsMngNo;

            if (salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods)
            {
                sCMAcOdrDtlAsWork.CancelCndtinDiv = 30;
            }
            // 倉庫コード
            sCMAcOdrDtlAsWork.WarehouseCode = salesDetail.WarehouseCode;
            // 倉庫名称
            sCMAcOdrDtlAsWork.WarehouseName = salesDetail.WarehouseName;
            // 棚番
            sCMAcOdrDtlAsWork.WarehouseShelfNo = salesDetail.WarehouseShelfNo;

            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            if (retAns != null)
            {
                sCMAcOdrDtlAsWork.PrmSetDtlNo2 = retAns.PrmSetDtlNo2; // 優良設定詳細コード２
                sCMAcOdrDtlAsWork.PrmSetDtlName2 = retAns.PrmSetDtlName2; // 優良設定詳細名称２
                sCMAcOdrDtlAsWork.StockStatusDiv = retAns.StockStatusDiv; // 在庫状況区分
                // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
                sCMAcOdrDtlAsWork.RentDiv = retAns.RentDiv; // 貸出区分            
                sCMAcOdrDtlAsWork.MkrSuggestRtPric = retAns.MkrSuggestRtPric; // メーカー希望小売価格
                sCMAcOdrDtlAsWork.OpenPriceDiv = retAns.OpenPriceDiv; // オープン価格区分    
                // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
                // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
                // お買得商品選択区分
                sCMAcOdrDtlAsWork.BgnGoodsDiv = retAns.BgnGoodsDiv;
                // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<
                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
                // 型式別部品採用年月
                sCMAcOdrDtlAsWork.ModelPrtsAdptYm = retAns.ModelPrtsAdptYm;
                // 型式別部品廃止年月
                sCMAcOdrDtlAsWork.ModelPrtsAblsYm = retAns.ModelPrtsAblsYm;
                // 型式別部品採用車台番号
                sCMAcOdrDtlAsWork.ModelPrtsAdptFrameNo = retAns.ModelPrtsAdptFrameNo;
                // 型式別部品廃止車台番号
                sCMAcOdrDtlAsWork.ModelPrtsAblsFrameNo = retAns.ModelPrtsAblsFrameNo;
                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // 回答納期区分
                sCMAcOdrDtlAsWork.AnsDeliDateDiv = retAns.AnsDeliDateDiv;
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/23 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // 商品規格・特記事項(工場向け)
                sCMAcOdrDtlAsWork.GoodsSpecialNtForFac = retAns.GoodsSpecialNtForFac;
                // 商品規格・特記事項(カーオーナー向け)
                sCMAcOdrDtlAsWork.GoodsSpecialNtForCOw = retAns.GoodsSpecialNtForCOw;
                // 優良設定詳細名称２(工場向け)
                sCMAcOdrDtlAsWork.PrmSetDtlName2ForFac = retAns.PrmSetDtlName2ForFac;
                // 優良設定詳細名称２(カーオーナー向け)
                sCMAcOdrDtlAsWork.PrmSetDtlName2ForCOw = retAns.PrmSetDtlName2ForCOw;
                // ADD 2015/02/23 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
            #endregion
            return sCMAcOdrDtlAsWork;
        }

        //>>>2012/03/21
        /// <summary>
        /// 売上データ読込
        /// </summary>
        /// <param name="logicalMode"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="acptAnOdrStatus"></param>
        /// <param name="salesSlipNum"></param>
        /// <param name="salesSlip"></param>
        /// <param name="baseSalesSlip"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="addUpSrcDetailList"></param>
        /// <param name="depsitMain"></param>
        /// <param name="depositAlw"></param>
        /// <param name="stockSlipWorkList"></param>
        /// <param name="stockDetailWorkList"></param>
        /// <param name="addUpSrcStockDetailWorkList"></param>
        /// <param name="stockWorkList"></param>
        /// <param name="acceptOdrCarList"></param>
        /// <param name="uoeOrderDtlWorkList"></param>
        /// <param name="scmHeader"></param>
        /// <param name="scmCar"></param>
        /// <param name="scmDetailList"></param>
        /// <param name="scmAnswerList"></param>
        /// <returns></returns>
        public int ReadDBData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, out UserSCMOrderHeaderRecord scmHeader, out UserSCMOrderCarRecord scmCar, out List<UserSCMOrderDetailRecord> scmDetailList, out List<UserSCMOrderAnswerRecord> scmAnswerList)
        {
            SalesSlip salesSlip;
            SalesSlip baseSalesSlip;
            List<SalesDetail> salesDetailList;
            List<SalesDetail> addUpSrcDetailList;
            SearchDepsitMain depsitMain;
            SearchDepositAlw depositAlw;
            List<StockSlipWork> stockSlipWorkList;
            List<StockDetailWork> stockDetailWorkList;
            List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList;
            List<StockWork> stockWorkList;
            List<AcceptOdrCar> acceptOdrCarList;
            List<UOEOrderDtlWork> uoeOrderDtlWorkList;

            return this.ReadDBDataProc(logicalMode, enterpriseCode, acptAnOdrStatus, salesSlipNum, false, out salesSlip, out baseSalesSlip, out salesDetailList, out addUpSrcDetailList, out depsitMain, out depositAlw, out stockSlipWorkList, out stockDetailWorkList, out addUpSrcStockDetailWorkList, out stockWorkList, out acceptOdrCarList, out uoeOrderDtlWorkList, out scmHeader, out scmCar, out scmDetailList, out scmAnswerList);
        }

        /// <summary>
        /// 売上データ読込
        /// </summary>
        /// <param name="logicalMode"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="acptAnOdrStatus"></param>
        /// <param name="salesSlipNum"></param>
        /// <param name="searchEstimate"></param>
        /// <param name="salesSlip"></param>
        /// <param name="baseSalesSlip"></param>
        /// <param name="salesDetailList"></param>
        /// <param name="addUpSrcDetailList"></param>
        /// <param name="depsitMain"></param>
        /// <param name="depositAlw"></param>
        /// <param name="stockSlipWorkList"></param>
        /// <param name="stockDetailWorkList"></param>
        /// <param name="addUpSrcStockDetailWorkList"></param>
        /// <param name="stockWorkList"></param>
        /// <param name="acceptOdrCarList"></param>
        /// <param name="uoeOrderDtlWorkList"></param>
        /// <param name="scmHeader"></param>
        /// <param name="scmCar"></param>
        /// <param name="scmDetailList"></param>
        /// <param name="scmAnswerList"></param>
        /// <returns></returns>
        private int ReadDBDataProc(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, int acptAnOdrStatus, string salesSlipNum, bool searchEstimate, out SalesSlip salesSlip, out SalesSlip baseSalesSlip, out List<SalesDetail> salesDetailList, out List<SalesDetail> addUpSrcDetailList, out SearchDepsitMain depsitMain, out SearchDepositAlw depositAlw, out List<StockSlipWork> stockSlipWorkList, out List<StockDetailWork> stockDetailWorkList, out List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList, out List<StockWork> stockWorkList, out List<AcceptOdrCar> acceptOdrCarList, out List<UOEOrderDtlWork> uoeOrderDtlWorkList, out UserSCMOrderHeaderRecord scmHeader, out UserSCMOrderCarRecord scmCar, out List<UserSCMOrderDetailRecord> scmDetailList, out List<UserSCMOrderAnswerRecord> scmAnswerList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            salesSlip = null;
            baseSalesSlip = null;
            salesDetailList = null;
            addUpSrcDetailList = null;
            depsitMain = null;
            depositAlw = null;
            stockSlipWorkList = null;
            stockDetailWorkList = null;
            addUpSrcStockDetailWorkList = null;
            stockWorkList = null;
            acceptOdrCarList = null;
            uoeOrderDtlWorkList = null;
            scmHeader = null;
            scmCar = null;
            scmDetailList = null;
            scmAnswerList = null;
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            IOWriteMAHNBReadWork readPara = new IOWriteMAHNBReadWork();
            readPara.EnterpriseCode = enterpriseCode;
            readPara.AcptAnOdrStatus = acptAnOdrStatus;
            readPara.SalesSlipNum = salesSlipNum;
            paraList.Add(readPara);

            #region ●リモート参照用パラメータ
            //------------------------------------------------------
            // リモート参照用パラメータ
            //------------------------------------------------------
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // リモート参照用パラメータ
            IIOWriteControlDB iIOWriteControlDB;
            this.SettingIOWriteCtrlOptWork(SalesSlipInputAcs.OptWorkSettingType.Read, out iOWriteCtrlOptWork); // リモート参照用パラメータ設定処理
            paraList.Add(iOWriteCtrlOptWork);
            #endregion

            object paraObj = (object)paraList;
            object retObj1;
            object retObj2;

            iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            status = iIOWriteControlDB.Read(ref paraObj, out retObj1, out retObj2);

            CustomSerializeArrayList retList1 = (CustomSerializeArrayList)retObj1;
            CustomSerializeArrayList retList2 = (CustomSerializeArrayList)retObj2;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                SalesSlipWork salesSlipWork;                                // 売上データワークオブジェクト
                SalesDetailWork[] salesDetailWorkArray;                     // 売上明細データワークオブジェクト配列
                AddUpOrgSalesDetailWork[] addUpOrgSalesDetailWorkArray;     // 計上元明細データワークオブジェクト配列
                DepsitDataWork depsitDataWork;                              // 入金データワークオブジェクト
                DepositAlwWork depositAlwWork;                              // 入金引当データワークオブジェクト
                StockWork[] stockWorkArray;                                 // 在庫ワークデータオブジェクト配列
                AcceptOdrCarWork[] acceptOdrCarWorkArray;                   // 受注マスタ（車両）ワークオブジェクト配列
                UOEOrderDtlWork[] uoeOrderDtlWorkArray;                     // UOE発注データワークオブジェクト配列
                UserSCMOrderDetailRecord[] scmDetailArray;                  // SCM受注明細データ(問合せ・発注)ワークオブジェクト配列
                UserSCMOrderAnswerRecord[] scmAnswerArray;                  // SCM受注明細データ(回答)ワークオブジェクト配列

                // CustomSerializeArrayList分割処理
                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForReading(retList1, retList2, out salesSlipWork, out salesDetailWorkArray, out addUpOrgSalesDetailWorkArray, out depsitDataWork, out depositAlwWork, out stockSlipWorkList, out stockDetailWorkList, out addUpSrcStockDetailWorkList, out stockWorkArray, out acceptOdrCarWorkArray, out uoeOrderDtlWorkArray, out scmHeader, out scmCar, out scmDetailArray, out scmAnswerArray);

                #region 処理速度を低下させないため、現状使用するSCM情報のみ展開
                //stockSlipWorkTempList = new List<StockSlipWork>();
                //stockSlipWorkTempListForExist = new List<StockSlipWork>();
                //foreach (StockSlipWork stockSlipWork in stockSlipWorkList)
                //{
                //    StockSlipWork stockSlipTempWork = new StockSlipWork();
                //    stockSlipTempWork.SupplierCd = stockSlipWork.SupplierCd;
                //    stockSlipTempWork.PartySaleSlipNum = stockSlipWork.PartySaleSlipNum;
                //    stockSlipTempWork.SupplierFormal = stockSlipWork.SupplierFormal;
                //    stockSlipTempWork.StockDate = stockSlipWork.StockDate;
                //    if (!stockSlipWorkTempList.Contains(stockSlipTempWork)) stockSlipWorkTempList.Add(stockSlipTempWork);
                //}

                //if ((!searchEstimate) &&
                //    (salesSlipWork.EstimateDivide == (int)EstimateDivide.SearchEstimate))
                //{
                //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    return status;
                //}
                //if (this._enterpriseCode == login_EnterpriseCode)
                //{
                //    if (this._surveyUseLogOutputAcs == null) this._surveyUseLogOutputAcs = new SurveyUseLogOutputAcs();
                //}
                //this._surveyUseLogOutputAcs.AddLine(40, Convert.ToInt32(salesSlipWork.SalesSlipNum), salesSlipWork.AcptAnOdrStatus);
                //if (this._enterpriseCode == login_EnterpriseCode)
                //{
                //    SalesSlip tmpSalesSlip = new SalesSlip();
                //    tmpSalesSlip = ConvertSalesSlip.UIDataFromParamData(salesSlipWork);
                //    if (tmpSalesSlip.AcptAnOdrStatus == 30)
                //    {
                //        DateTime serverTime = this._getServerNowTime;
                //        if (_employeeAcs == null)
                //        {
                //            _employeeAcs = new EmployeeAcs();
                //        }
                //        Employee employee = new Employee();
                //        status = _employeeAcs.Read(out employee, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
                //        if (employee.AuthorityLevel1 != 99 || employee.AuthorityLevel2 != 99)
                //        {
                //            if (TDateTime.DateTimeToLongDate(tmpSalesSlip.SalesDate) < TDateTime.DateTimeToLongDate(serverTime))
                //            {
                //                TMsgDisp.Show(
                //                 new Form(),
                //                 emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //                 "",
                //                 "当日以前の伝票は修正できません。",
                //                 -1,
                //                 MessageBoxButtons.OK);
                //                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //                this._salesSlipCanEditDivCd = false;
                //                return status;
                //            }
                //            else
                //            {
                //                this._salesSlipCanEditDivCd = true;
                //            }
                //        }
                //        else
                //        {
                //            this._salesSlipCanEditDivCd = true;
                //        }
                //    }
                //    salesSlip = tmpSalesSlip;
                //}
                //if (this._enterpriseCode != login_EnterpriseCode)
                //{
                //    salesSlip = ConvertSalesSlip.UIDataFromParamData(salesSlipWork);
                //}
                //baseSalesSlip = ConvertSalesSlip.UIDataFromParamData(salesSlipWork);
                //salesDetailList = ConvertSalesSlip.UIDataFromParamData(salesDetailWorkArray);
                //salesDetailList.Sort(new SalesDetail.SalesDetailComparer());
                //addUpSrcDetailList = ConvertSalesSlip.UIDataFromParamData(addUpOrgSalesDetailWorkArray);
                //depsitMain = ConvertSalesSlip.UIDataFromParamData(depsitDataWork);
                //depositAlw = (depositAlwWork != null) ? (SearchDepositAlw)DBAndXMLDataMergeParts.CopyPropertyInClass(depositAlwWork, typeof(SearchDepositAlw)) : new SearchDepositAlw();
                //acceptOdrCarList = ConvertSalesSlip.UIDataFromParamData(acceptOdrCarWorkArray);
                //if ((stockWorkArray != null) && (stockWorkArray.Length > 0))
                //{
                //    if (stockWorkList == null) stockWorkList = new List<StockWork>();
                //    stockWorkList.AddRange(stockWorkArray);
                //}
                //if ((uoeOrderDtlWorkArray != null) && (uoeOrderDtlWorkArray.Length > 0))
                //{
                //    if (uoeOrderDtlWorkList == null) uoeOrderDtlWorkList = new List<UOEOrderDtlWork>();
                //    uoeOrderDtlWorkList.AddRange(uoeOrderDtlWorkArray);
                //}
                //if (stockSlipWorkList == null) stockSlipWorkList = new List<StockSlipWork>();
                //if (stockDetailWorkList == null) stockDetailWorkList = new List<StockDetailWork>();
                //if (addUpSrcStockDetailWorkList == null) addUpSrcStockDetailWorkList = new List<AddUpOrgStockDetailWork>();

                //this.SettingSalesSlipEstimateDef(ref salesSlip, this._salesSlipInputInitDataAcs.GetEstimateDefSet());

                //this.SettingCompleteInfoFromSalesDetailList(salesDetailList);                           // 一式情報セット
                //CustomerInfo customerInfo = null;
                //int cusStatus = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //cusStatus = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, salesSlip.CustomerCode, true, false, out customerInfo);
                //if (cusStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    string customerSnm = salesSlip.CustomerSnm; // ADD 2012/01/18 tianjw
                //    this.SettingSalesSlipFromCustomer(ref salesSlip, customerInfo);
                //    salesSlip.CustomerSnm = customerSnm; // ADD 2012/01/18 tianjw
                //}
                #endregion

                if (scmDetailArray != null) scmDetailList = new List<UserSCMOrderDetailRecord>((UserSCMOrderDetailRecord[])scmDetailArray);
                if (scmAnswerArray != null) scmAnswerList = new List<UserSCMOrderAnswerRecord>((UserSCMOrderAnswerRecord[])scmAnswerArray);

            }

            return status;

        }

        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        /// <param name="optWorkSettinType"></param>
        /// <param name="iOWriteCtrlOptWork"></param>
        private void SettingIOWriteCtrlOptWork(SalesSlipInputAcs.OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork)
        {
            iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;                              // 制御起点(0:売上 1:仕入 2:仕入売上同時計上)
            #region delete
            //iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrrAddUpRemDiv;     // 受注データ計上残区分(0:残す 1:残さない)
            //iOWriteCtrlOptWork.ShipmAddUpRemDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().ShipmAddUpRemDiv;         // 出荷データ計上残区分(0:残す 1:残さない)
            //iOWriteCtrlOptWork.EstimateAddUpRemDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().EstmateAddUpRemDiv;    // 見積データ計上残区分(0:残す 1:残さない)
            //iOWriteCtrlOptWork.RetGoodsStockEtyDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().RetGoodsStockEtyDiv;   // 返品時在庫登録区分
            //iOWriteCtrlOptWork.RemainCntMngDiv = 0;                                                                         // 残数管理区分(0:する 固定とする)
            //iOWriteCtrlOptWork.SupplierSlipDelDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SupplierSlipDelDiv;     // 仕入伝票削除区分
            //iOWriteCtrlOptWork.CarMngDivCd = this._salesSlip.CarMngDivCd;                                                   // 車両管理マスタ登録区分(0:登録しない 1:登録する)
            //switch (optWorkSettinType)
            //{
            //    case OptWorkSettingType.Write:
            //        break;
            //    case OptWorkSettingType.Read:
            //        break;
            //    case OptWorkSettingType.Delete:
            //        if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().SupplierSlipDelDiv == 1)
            //        {
            //            iOWriteCtrlOptWork.SupplierSlipDelDiv = this._supplierSlipDelDiv; // 仕入伝票削除区分
            //        }
            //        break;
            //}
            #endregion
        }
        //<<<2012/03/21

        /// <summary>
        /// オンライン種別区分
        /// </summary>
        public enum OnlineKindDiv : int
        {
            /// <summary>なし</summary>
            None = 0,
            /// <summary>SCM</summary>
            SCM = 10,
            /// <summary>TSP.NS</summary>
            TSPNS = 20,
            /// <summary>TSP.NSインライン</summary>
            TSPINLINE = 30,
            /// <summary>TSPメール</summary>
            TSPMAIL = 40,
        }

        /// <summary>
        /// 受注ステータス
        /// </summary>
        public enum AcptAnOdrStatusState : int
        {
            /// <summary>見積</summary>
            Estimate = 10,
            /// <summary>単価見積</summary>
            UnitPriceEstimate = 15,
            /// <summary>検索見積</summary>
            SearchEstimate = 16,
            /// <summary>受注</summary>
            AcceptAnOrder = 20,
            /// <summary>売上</summary>
            Sales = 30,
            /// <summary>貸出</summary>
            Shipment = 40,
        }

        /// <summary>
        /// URL取得処理
        /// </summary>
        /// <param name="goodsMngNo"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private int GetURL(int goodsMngNo, out string url)
        {
            int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            url = string.Empty;

            if (goodsMngNo == 0) return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                PartsDetailURLService service = new PartsDetailURLService();
                GetURLResType res = new GetURLResType();
                GetURLReqType req = new GetURLReqType();
                req.UC = this._enterpriseCode;
                ArrayList al = new ArrayList();
                PSNoType ps = new PSNoType();
                ps.PSNo = goodsMngNo;
                al.Add(ps);
                PSNoType[] psNoType = (PSNoType[])al.ToArray(typeof(PSNoType));
                req.PSNoList = psNoType;

                res = service.GetURL(req);
                URLType[] urlList = new URLType[0];
                urlList = res.URLList;
                url = ((URLType)urlList[0]).URL;
            }
            catch (Exception)
            {
                st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return st;
        }

        /// <summary>
        /// 率算定処理
        /// </summary>
        /// <param name="numerator">数値(分子)</param>
        /// <param name="denominator">数値(分母)</param>
        /// <param name="rate">率</param>
        public void GetRate(double numerator, double denominator, out double rate)
        {
            rate = this._salesPriceCalculate.CalculateMarginRate(numerator, denominator);
        }
        // --- ADD duzg 2011/08/06 ----------<<<<<

        // --- ADD m.suzuki 2010/07/20 ---------->>>>>
        /// <summary>
        /// 売上明細取得処理（行No.指定）
        /// </summary>
        /// <param name="salesDetailList"></param>
        /// <param name="rowNo"></param>
        /// <returns></returns>
        private SalesDetailWork GetSalesDetailFromRowNo( List<SalesDetailWork> salesDetailList, int rowNo )
        {
            foreach ( SalesDetailWork detail in salesDetailList )
            {
                // 行№が一致するインスタンスを返す
                if ( detail.SalesRowNo == rowNo )
                {
                    return detail;
                }
            }

            // 該当なし
            return null;
        }
        // --- ADD m.suzuki 2010/07/20 ----------<<<<<

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
        /// <summary>
        /// 赤伝明細ソートstring取得
        /// </summary>
        /// <param name="salesTtlSt"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string MakeSalesSlipSort( SalesTtlSt salesTtlSt )
        {
            string sortString;
            switch ( salesTtlSt.SlipCreateProcess )
            {
                default:
                case 0:
                    // 入力順
                    sortString = string.Format( "{0}", DetailDataSet.RedSlipDetail.RedSlipInputRowNoColumn.ColumnName );
                    break;
                case 1:
                    // 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)
                    sortString = string.Format( "{0} DESC,{1}", DetailDataSet.RedSlipDetail.SalesOrderDivCdColumn.ColumnName,
                                                                DetailDataSet.RedSlipDetail.RedSlipInputRowNoColumn.ColumnName );
                    break;
                case 2:
                    // 倉庫順(倉庫・行番号順)
                    sortString = string.Format( "{0},{1}", DetailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName,
                                                           DetailDataSet.RedSlipDetail.RedSlipInputRowNoColumn.ColumnName );
                    break;
                case 3:
                    // 出力先別(倉庫・行番号順)
                    sortString = string.Format( "{0},{1}", DetailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName,
                                                           DetailDataSet.RedSlipDetail.RedSlipInputRowNoColumn.ColumnName );
                    break;
            }
            return sortString;
        }
        /// <summary>
        /// 伝票ブレイクチェック処理
        /// </summary>
        /// <param name="dataRowView"></param>
        /// <param name="dataRowView_2"></param>
        /// <param name="salesTtlSt"></param>
        /// <returns></returns>
        /// <br>Update Note: 2010/12/20 liyp</br>
        /// <br>            赤伝明細のセット仕様の修正</br>
        private bool CheckSlipBreak( DataRowView prevRow, DataRowView currRow, SalesTtlSt salesTtlSt )
        {
            bool result;
            switch ( salesTtlSt.SlipCreateProcess )
            {
                default:
                case 0:
                    // 入力順
                    result = false;
                    break;
                case 1:
                    // 在庫・取寄順(在庫取寄区分(0:取寄 1:在庫)・行番号順)
                    // -------------UPD 2010/12/20 ------------>>>>>
                    //result = (prevRow[DetailDataSet.RedSlipDetail.SalesOrderDivCdColumn.ColumnName]
                    //            != currRow[DetailDataSet.RedSlipDetail.SalesOrderDivCdColumn.ColumnName]);
                    result = false;
                    // -------------UPD 2010/12/20 ------------<<<<<
                    break;
                case 2:
                    // 倉庫順(倉庫・行番号順)
                    // -------------UPD 2010/12/20 ------------>>>>>
                    //result = (prevRow[DetailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName]
                    //            != currRow[DetailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName]);
                    result = false;
                    // -------------UPD 2010/12/20 ------------<<<<<
                    break;
                case 3:
                    // 出力先別(倉庫・行番号順)
                    // -------------UPD 2010/12/20 ------------>>>>>
                    //result = (prevRow[DetailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName]
                    //            != currRow[DetailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName]);
                    result = false;
                    // -------------UPD 2010/12/20 ------------<<<<<
                    break;
            }
            return result;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD

        /// <summary>
        /// 登録用仕入返品伝票明細 編集処理(前準備)
        /// </summary>
        /// <param name="retStockDetail"></param>
        /// <param name="retStockSlip"></param>
        /// <param name="redSalesSlip"></param>
        /// <param name="salesDetailWork"></param>
        private void ReflectStockSlipDetail( ref StockDetailWork retStockDetail, StockSlipWork retStockSlip, SalesSlipWork redSalesSlip, SalesDetailWork redSalesDetail, DataRowView redRowView )
        {
            // 数量を調整（対応する売上データに合わせる）
            retStockDetail.StockCount = redSalesDetail.ShipmentCnt;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
            // 原単価
            retStockDetail.StockUnitPriceFl = (double)redRowView[_detailDataSet.RedSlipDetail.SalesUnitCostColumn.ColumnName];
            retStockDetail.StockUnitTaxPriceFl = retStockDetail.StockUnitPriceFl;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD

            // 倉庫情報を調整
            retStockDetail.WarehouseCode = redSalesDetail.WarehouseCode;
            retStockDetail.WarehouseName = redSalesDetail.WarehouseName;
            retStockDetail.WarehouseShelfNo = redSalesDetail.WarehouseShelfNo;
            retStockDetail.StockOrderDivCd = (retStockDetail.WarehouseCode.Trim() == string.Empty) ? 0 : 1;
        }

        // ---------- ADD daibin 2013/02/06 Redmine#34580 ---------->>>>>
        /// <summary>
        /// 計上日計算処理
        /// </summary>
        /// <param name="key">仕入伝票論理KEY</param>
        /// <param name="redStockSlip">仕入伝票</param>
        /// <param name="addUpADate">仕入計上日付</param>
        /// <param name="delayPaymentDiv">来勘区分</param>
        /// <remarks>
        /// <br>Note       : 計上日計算処理を行う。</br>
        /// <br>Programmer : daibin</br>
        /// <br>Date       : 2013/02/06</br>
        /// <br>管理番号   : 10801804-00 2013/03/13配信分 Redmine#34580 赤伝発行入力画面　計上日と入荷日をセット修正</br>
        /// </remarks>
        private void CalcAddUpDate(StockSlipLogicalKey key, StockSlipWork redStockSlip, out DateTime addUpADate, out int delayPaymentDiv)
        {
            // 仕入先情報
            Supplier supplier;
            // 支払先情報
            Supplier payeeSupplier;
            // 仕入計上日付
            addUpADate = redStockSlip.StockDate;
            // 来勘区分
            delayPaymentDiv = 0;
            try
            {
                // 仕入先情報を取得
                int status = this._supplierAcs.ReadCache(out supplier, key.EnterpriseCode, key.SupplierCd);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 支払先情報を取得
                    status = this._supplierAcs.ReadCache(out payeeSupplier, key.EnterpriseCode, supplier.PayeeCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 計上日計算処理
                        SalesSlipInputAcs.CalcAddUpDate(redStockSlip.StockDate, payeeSupplier.PaymentTotalDay, payeeSupplier.NTimeCalcStDate, out addUpADate, out delayPaymentDiv);
                    }
                }
            }
            catch
            {
                //何もない
            }
        }
        // ---------- ADD daibin 2013/02/06 Redmine#34580 ----------<<<<<

        /// <summary>
        /// 登録用仕入返品伝票生成（追加用）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="redStockSlip"></param>
        /// <param name="redStockDetailList"></param>
        /// <param name="stockDateForUpdate">ADD 2012/08/22</param>
        // ---------- DEL 2012/08/22 ---------->>>>>
        //private void CreateRedStockSlip(StockSlipLogicalKey key, ref StockSlipWork redStockSlip, ref List<StockDetailWork> redStockDetailList, RedSlipWriteParameter parameter)
        // ---------- DEL 2012/08/22 ----------<<<<<
        // ---------- ADD 2012/08/22 ---------->>>>>
        private void CreateRedStockSlip(StockSlipLogicalKey key, ref StockSlipWork redStockSlip, ref List<StockDetailWork> redStockDetailList, RedSlipWriteParameter parameter, DateTime stockDateForUpdate)
        // ---------- ADD 2012/08/22 ----------<<<<<
        {
            //--------------------------------------------------------------------
            // ※売上データ読み込み時に同時に取得した、
            // 　同時入力仕入データを元にして、新たに追加用レコードを生成します。
            //--------------------------------------------------------------------
            // --- ADD m.suzuki 2010/10/07 ---------->>>>>
            int supplierSlipCd; // 10:仕入,20:返品
            int stockSlipCdDtl; // 0:仕入,1:返品,2:値引

            if ( parameter.SlipCd == 0 )
            {
                supplierSlipCd = 10; // 10:仕入
                stockSlipCdDtl = 0; // 0:仕入
            }
            else
            {
                supplierSlipCd = 20; // 20:返品
                stockSlipCdDtl = 1; // 1:返品
            }
            // --- ADD m.suzuki 2010/10/07 ----------<<<<<

            DateTime inputDay = parameter.SalesDate;
            DateTime stockDate = key.StockDate;
            string stockInputCode = parameter.InputEmployeeCd;
            string stockInputName = parameter.InputEmployeeNm;
            int retGoodsReasonDiv = 0;
            string retGoodsReason = parameter.ReturnReason;
            string partySaleSlipNum = key.PartySaleSlipNum;
            //string warehouseCode = string.Empty;
            //string warehouseName = string.Empty;
            //string warehouseShelfNo = string.Empty;
            //int stockOrderDivCd = (warehouseCode.Trim() == string.Empty) ? 0 : 1;

            # region [伝票]
            redStockSlip.CreateDateTime = DateTime.MinValue; // 作成日時
            redStockSlip.UpdateDateTime = DateTime.MinValue; // 更新日時
            redStockSlip.EnterpriseCode = _enterpriseCode; // 企業コード
            redStockSlip.FileHeaderGuid = Guid.Empty; // GUID
            redStockSlip.UpdEmployeeCode = string.Empty; // 更新従業員コード
            redStockSlip.UpdAssemblyId1 = string.Empty; // 更新アセンブリID1
            redStockSlip.UpdAssemblyId2 = string.Empty; // 更新アセンブリID2
            redStockSlip.LogicalDeleteCode = 0; // 論理削除区分
            redStockSlip.SupplierFormal = 0; // 仕入形式　0:仕入
            redStockSlip.SupplierSlipNo = 0; // 仕入伝票番号
            //redStockSlip.SectionCode = default( string ); // 拠点コード
            //redStockSlip.SubSectionCode = default( Int32 ); // 部門コード
            redStockSlip.DebitNoteDiv = 0; // 赤伝区分
            redStockSlip.DebitNLnkSuppSlipNo = 0; // 赤黒連結仕入伝票番号
            // --- UPD m.suzuki 2010/10/07 ---------->>>>>
            //redStockSlip.SupplierSlipCd = 20; // 仕入伝票区分
            redStockSlip.SupplierSlipCd = supplierSlipCd; // 仕入伝票区分
            // --- UPD m.suzuki 2010/10/07 ----------<<<<<
            //redStockSlip.StockGoodsCd = default( Int32 ); // 仕入商品区分
            //redStockSlip.AccPayDivCd = default( Int32 ); // 買掛区分
            //redStockSlip.StockSectionCd = default( string ); // 仕入拠点コード
            //redStockSlip.StockAddUpSectionCd = default( string ); // 仕入計上拠点コード
            redStockSlip.StockSlipUpdateCd = 0; // 仕入伝票更新区分
            //redStockSlip.InputDay = inputDay; // 入力日 // DEL daibin 2013/02/20 Redmine#34580
            redStockSlip.InputDay = DateTime.Today; // 入力日 // ADD daibin 2013/02/20 Redmine#34580
            //redStockSlip.ArrivalGoodsDay = stockDate; // 入荷日 // DEL daibin 2013/02/06 Redmine#34580
            // ---------- DEL 2012/08/22 ---------->>>>>
            //redStockSlip.StockDate = stockDate; // 仕入日
            // ---------- DEL 2012/08/22 ----------<<<<<
            // --- ADD xuyb 2014/02/07 Redmine#41771------------ >>>>>>
            // 消費税転嫁方式編集判断メソッドの返値がtrueの場合、
            if (CheckStockConsTaxLay(redStockSlip, stockDateForUpdate))
            {
                // 仕入データ(StockSlipRf).消費税転嫁方式(ConsTaxLayMethodRF)＝０：伝票単位
                redStockSlip.SuppCTaxLayCd = 0;
            }
            // --- ADD xuyb 2014/02/07 Redmine#41771 ------------ <<<<<<
            // ---------- ADD 2012/08/22 ---------->>>>>
            if (stockDateForUpdate != null && stockDateForUpdate != DateTime.MinValue)
            {
                redStockSlip.StockDate = stockDateForUpdate; // 仕入日 グリッド上で入力された仕入日
            }
            else
            {
                redStockSlip.StockDate = stockDate; // 仕入日
            }
            // ---------- ADD 2012/08/22 ----------<<<<<
            // ---------- DEL daibin 2013/02/06 Redmine#34580 ---------->>>>>
            //redStockSlip.StockAddUpADate = stockDate; // 仕入計上日付
            //redStockSlip.DelayPaymentDiv = 0; // 来勘区分
            // ---------- DEL daibin 2013/02/06 Redmine#34580 ----------<<<<<
            // ---------- ADD daibin 2013/02/06 Redmine#34580 ---------->>>>>
            DateTime addUpADate = DateTime.MinValue; // 仕入計上日付
            int delayPaymentDiv; // 来勘区分 
            // 仕入計上日を算出処理
            this.CalcAddUpDate(key, redStockSlip, out addUpADate, out delayPaymentDiv); 

            redStockSlip.DelayPaymentDiv = delayPaymentDiv; // 来勘区分
            redStockSlip.StockAddUpADate = addUpADate; // 仕入計上日付
            redStockSlip.ArrivalGoodsDay = redStockSlip.StockDate; // 入荷日
            // ---------- ADD daibin 2013/02/06 Redmine#34580 ----------<<<<<
            //redStockSlip.PayeeCode = default( Int32 ); // 支払先コード
            //redStockSlip.PayeeSnm = default( string ); // 支払先略称
            //redStockSlip.SupplierCd = default( Int32 ); // 仕入先コード
            //redStockSlip.SupplierNm1 = default( string ); // 仕入先名1
            //redStockSlip.SupplierNm2 = default( string ); // 仕入先名2
            //redStockSlip.SupplierSnm = default( string ); // 仕入先略称
            //redStockSlip.BusinessTypeCode = default( Int32 ); // 業種コード
            //redStockSlip.BusinessTypeName = default( string ); // 業種名称
            //redStockSlip.SalesAreaCode = default( Int32 ); // 販売エリアコード
            //redStockSlip.SalesAreaName = default( string ); // 販売エリア名称
            redStockSlip.StockInputCode = stockInputCode; // 仕入入力者コード
            redStockSlip.StockInputName = stockInputName; // 仕入入力者名称
            redStockSlip.StockAgentCode = stockInputCode; // 仕入担当者コード
            redStockSlip.StockAgentName = stockInputName; // 仕入担当者名称
            //redStockSlip.SuppTtlAmntDspWayCd = default( Int32 ); // 仕入先総額表示方法区分
            //redStockSlip.TtlAmntDispRateApy = default( Int32 ); // 総額表示掛率適用区分
            //redStockSlip.StockTotalPrice = default( Int64 ); // 仕入金額合計
            //redStockSlip.StockSubttlPrice = default( Int64 ); // 仕入金額小計
            //redStockSlip.StockTtlPricTaxInc = default( Int64 ); // 仕入金額計（税込み）
            //redStockSlip.StockTtlPricTaxExc = default( Int64 ); // 仕入金額計（税抜き）
            //redStockSlip.StockNetPrice = default( Int64 ); // 仕入正価金額
            //redStockSlip.StockPriceConsTax = default( Int64 ); // 仕入金額消費税額
            //redStockSlip.TtlItdedStcOutTax = default( Int64 ); // 仕入外税対象額合計
            //redStockSlip.TtlItdedStcInTax = default( Int64 ); // 仕入内税対象額合計
            //redStockSlip.TtlItdedStcTaxFree = default( Int64 ); // 仕入非課税対象額合計
            //redStockSlip.StockOutTax = default( Int64 ); // 仕入金額消費税額（外税）
            //redStockSlip.StckPrcConsTaxInclu = default( Int64 ); // 仕入金額消費税額（内税）
            //redStockSlip.StckDisTtlTaxExc = default( Int64 ); // 仕入値引金額計（税抜き）
            //redStockSlip.ItdedStockDisOutTax = default( Int64 ); // 仕入値引外税対象額合計
            //redStockSlip.ItdedStockDisInTax = default( Int64 ); // 仕入値引内税対象額合計
            //redStockSlip.ItdedStockDisTaxFre = default( Int64 ); // 仕入値引非課税対象額合計
            //redStockSlip.StockDisOutTax = default( Int64 ); // 仕入値引消費税額（外税）
            //redStockSlip.StckDisTtlTaxInclu = default( Int64 ); // 仕入値引消費税額（内税）
            //redStockSlip.TaxAdjust = default( Int64 ); // 消費税調整額
            //redStockSlip.BalanceAdjust = default( Int64 ); // 残高調整額
            //redStockSlip.SuppCTaxLayCd = default( Int32 ); // 仕入先消費税転嫁方式コード
            //redStockSlip.SupplierConsTaxRate = default( Double ); // 仕入先消費税税率
            //redStockSlip.AccPayConsTax = default( Int64 ); // 買掛消費税
            //redStockSlip.StockFractionProcCd = default( Int32 ); // 仕入端数処理区分
            //redStockSlip.AutoPayment = default( Int32 ); // 自動支払区分
            //redStockSlip.AutoPaySlipNum = default( Int32 ); // 自動支払伝票番号
            redStockSlip.RetGoodsReasonDiv = retGoodsReasonDiv; // 返品理由コード
            redStockSlip.RetGoodsReason = retGoodsReason; // 返品理由
            redStockSlip.PartySaleSlipNum = partySaleSlipNum; // 相手先伝票番号
            //redStockSlip.SupplierSlipNote1 = default( string ); // 仕入伝票備考1
            //redStockSlip.SupplierSlipNote2 = default( string ); // 仕入伝票備考2
            redStockSlip.DetailRowCount = redStockDetailList.Count; // 明細行数
            redStockSlip.EdiSendDate = DateTime.MinValue; // ＥＤＩ送信日
            redStockSlip.EdiTakeInDate = DateTime.MinValue; // ＥＤＩ取込日
            redStockSlip.UoeRemark1 = string.Empty; // ＵＯＥリマーク１
            redStockSlip.UoeRemark2 = string.Empty; // ＵＯＥリマーク２
            redStockSlip.SlipPrintDivCd = 0; // 伝票発行区分
            redStockSlip.SlipPrintFinishCd = 0; // 伝票発行済区分
            redStockSlip.StockSlipPrintDate = DateTime.MinValue; // 仕入伝票発行日
            redStockSlip.SlipPrtSetPaperId = string.Empty; // 伝票印刷設定用帳票ID
            //redStockSlip.SlipAddressDiv = default( Int32 ); // 伝票住所区分
            //redStockSlip.AddresseeCode = default( Int32 ); // 納品先コード
            //redStockSlip.AddresseeName = default( string ); // 納品先名称
            //redStockSlip.AddresseeName2 = default( string ); // 納品先名称2
            //redStockSlip.AddresseePostNo = default( string ); // 納品先郵便番号
            //redStockSlip.AddresseeAddr1 = default( string ); // 納品先住所1(都道府県市区郡・町村・字)
            //redStockSlip.AddresseeAddr3 = default( string ); // 納品先住所3(番地)
            //redStockSlip.AddresseeAddr4 = default( string ); // 納品先住所4(アパート名称)
            //redStockSlip.AddresseeTelNo = default( string ); // 納品先電話番号
            //redStockSlip.AddresseeFaxNo = default( string ); // 納品先FAX番号
            //redStockSlip.DirectSendingCd = default( Int32 ); // 直送区分
            # endregion

            // 明細ループ
            for ( int index = 0; index < redStockDetailList.Count; index++ )
            {
                StockDetailWork redStockDetail = redStockDetailList[index];
                // --- ADD m.suzuki 2010/10/07 ---------->>>>>
                int supplierFormalSrc = redStockDetail.SupplierFormal;
                long stockSlipDtlNumSrc = redStockDetail.StockSlipDtlNum;
                // --- ADD m.suzuki 2010/10/07 ----------<<<<<

                # region [明細]
                redStockDetail.CreateDateTime = DateTime.MinValue; // 作成日時
                redStockDetail.UpdateDateTime = DateTime.MinValue; // 更新日時
                redStockDetail.EnterpriseCode = _enterpriseCode; // 企業コード
                redStockDetail.FileHeaderGuid = Guid.Empty; // GUID
                redStockDetail.UpdEmployeeCode = string.Empty; // 更新従業員コード
                redStockDetail.UpdAssemblyId1 = string.Empty; // 更新アセンブリID1
                redStockDetail.UpdAssemblyId2 = string.Empty; // 更新アセンブリID2
                redStockDetail.LogicalDeleteCode = 0; // 論理削除区分
                redStockDetail.AcceptAnOrderNo = 0; // 受注番号
                redStockDetail.SupplierFormal = 0; // 仕入形式
                redStockDetail.SupplierSlipNo = 0; // 仕入伝票番号
                redStockDetail.StockRowNo = (index + 1); // 仕入行番号
                //redStockDetail.SectionCode = redStockSlip.SectionCode; // 拠点コード
                //redStockDetail.SubSectionCode = redStockSlip.SubSectionCode; // 部門コード
                redStockDetail.CommonSeqNo = 0; // 共通通番
                redStockDetail.StockSlipDtlNum = 0; // 仕入明細通番
                // --- UPD m.suzuki 2010/10/07 ---------->>>>>
                //redStockDetail.SupplierFormalSrc = 0; // 仕入形式（元）
                //redStockDetail.StockSlipDtlNumSrc = 0; // 仕入明細通番（元）
                redStockDetail.SupplierFormalSrc = supplierFormalSrc; // 仕入形式（元）
                redStockDetail.StockSlipDtlNumSrc = stockSlipDtlNumSrc; // 仕入明細通番（元）
                // --- UPD m.suzuki 2010/10/07 ----------<<<<<
                // --- UPD m.suzuki 2010/10/07 ---------->>>>>
                //redStockDetail.AcptAnOdrStatusSync = 0; // 受注ステータス（同時）
                redStockDetail.AcptAnOdrStatusSync = 30; // 受注ステータス（同時）=30:売上
                // --- UPD m.suzuki 2010/10/07 ----------<<<<<
                redStockDetail.SalesSlipDtlNumSync = 0; // 売上明細通番（同時）
                // --- UPD m.suzuki 2010/10/07 ---------->>>>>
                //redStockDetail.StockSlipCdDtl = 1; // 仕入伝票区分（明細）
                redStockDetail.StockSlipCdDtl = stockSlipCdDtl; // 仕入伝票区分（明細）
                // --- UPD m.suzuki 2010/10/07 ----------<<<<<
                redStockDetail.StockInputCode = redStockSlip.StockInputCode; // 仕入入力者コード
                redStockDetail.StockInputName = redStockSlip.StockInputName; // 仕入入力者名称
                redStockDetail.StockAgentCode = redStockSlip.StockAgentCode; // 仕入担当者コード
                redStockDetail.StockAgentName = redStockSlip.StockAgentName; // 仕入担当者名称
                //redStockDetail.GoodsKindCode = default( Int32 ); // 商品属性
                //redStockDetail.GoodsMakerCd = default( Int32 ); // 商品メーカーコード
                //redStockDetail.MakerName = default( string ); // メーカー名称
                //redStockDetail.MakerKanaName = default( string ); // メーカーカナ名称
                //redStockDetail.CmpltMakerKanaName = default( string ); // メーカーカナ名称（一式）
                //redStockDetail.GoodsNo = default( string ); // 商品番号
                //redStockDetail.GoodsName = default( string ); // 商品名称
                //redStockDetail.GoodsNameKana = default( string ); // 商品名称カナ
                //redStockDetail.GoodsLGroup = default( Int32 ); // 商品大分類コード
                //redStockDetail.GoodsLGroupName = default( string ); // 商品大分類名称
                //redStockDetail.GoodsMGroup = default( Int32 ); // 商品中分類コード
                //redStockDetail.GoodsMGroupName = default( string ); // 商品中分類名称
                //redStockDetail.BLGroupCode = default( Int32 ); // BLグループコード
                //redStockDetail.BLGroupName = default( string ); // BLグループコード名称
                //redStockDetail.BLGoodsCode = default( Int32 ); // BL商品コード
                //redStockDetail.BLGoodsFullName = default( string ); // BL商品コード名称（全角）
                //redStockDetail.EnterpriseGanreCode = default( Int32 ); // 自社分類コード
                //redStockDetail.EnterpriseGanreName = default( string ); // 自社分類名称
                //redStockDetail.WarehouseCode = warehouseCode; // 倉庫コード
                //redStockDetail.WarehouseName = warehouseName; // 倉庫名称
                //redStockDetail.WarehouseShelfNo = warehouseShelfNo; // 倉庫棚番
                //redStockDetail.StockOrderDivCd = stockOrderDivCd; // 仕入在庫取寄せ区分
                //redStockDetail.OpenPriceDiv = default( Int32 ); // オープン価格区分
                //redStockDetail.GoodsRateRank = default( string ); // 商品掛率ランク
                //redStockDetail.CustRateGrpCode = default( Int32 ); // 得意先掛率グループコード
                //redStockDetail.SuppRateGrpCode = default( Int32 ); // 仕入先掛率グループコード
                //redStockDetail.ListPriceTaxExcFl = default( Double ); // 定価（税抜，浮動）
                //redStockDetail.ListPriceTaxIncFl = default( Double ); // 定価（税込，浮動）
                //redStockDetail.StockRate = default( Double ); // 仕入率
                //redStockDetail.RateSectStckUnPrc = default( string ); // 掛率設定拠点（仕入単価）
                //redStockDetail.RateDivStckUnPrc = default( string ); // 掛率設定区分（仕入単価）
                //redStockDetail.UnPrcCalcCdStckUnPrc = default( Int32 ); // 単価算出区分（仕入単価）
                //redStockDetail.PriceCdStckUnPrc = default( Int32 ); // 価格区分（仕入単価）
                //redStockDetail.StdUnPrcStckUnPrc = default( Double ); // 基準単価（仕入単価）
                //redStockDetail.FracProcUnitStcUnPrc = default( Double ); // 端数処理単位（仕入単価）
                //redStockDetail.FracProcStckUnPrc = default( Int32 ); // 端数処理（仕入単価）
                //redStockDetail.StockUnitPriceFl = default( Double ); // 仕入単価（税抜，浮動）
                //redStockDetail.StockUnitTaxPriceFl = default( Double ); // 仕入単価（税込，浮動）
                //redStockDetail.StockUnitChngDiv = default( Int32 ); // 仕入単価変更区分
                //redStockDetail.BfStockUnitPriceFl = default( Double ); // 変更前仕入単価（浮動）
                //redStockDetail.BfListPrice = default( Double ); // 変更前定価
                //redStockDetail.RateBLGoodsCode = default( Int32 ); // BL商品コード（掛率）
                //redStockDetail.RateBLGoodsName = default( string ); // BL商品コード名称（掛率）
                //redStockDetail.RateGoodsRateGrpCd = default( Int32 ); // 商品掛率グループコード（掛率）
                //redStockDetail.RateGoodsRateGrpNm = default( string ); // 商品掛率グループ名称（掛率）
                //redStockDetail.RateBLGroupCode = default( Int32 ); // BLグループコード（掛率）
                //redStockDetail.RateBLGroupName = default( string ); // BLグループ名称（掛率）
                //redStockDetail.StockCount = default( Double ); // 仕入数
                //redStockDetail.OrderCnt = default( Double ); // 発注数量
                //redStockDetail.OrderAdjustCnt = default( Double ); // 発注調整数
                //redStockDetail.OrderRemainCnt = default( Double ); // 発注残数
                redStockDetail.RemainCntUpdDate = DateTime.MinValue; // 残数更新日
                //redStockDetail.StockPriceTaxExc = default( Int64 ); // 仕入金額（税抜き）
                //redStockDetail.StockPriceTaxInc = default( Int64 ); // 仕入金額（税込み）
                //redStockDetail.StockGoodsCd = default( Int32 ); // 仕入商品区分
                //redStockDetail.StockPriceConsTax = default( Int64 ); // 仕入金額消費税額
                //redStockDetail.TaxationCode = default( Int32 ); // 課税区分
                redStockDetail.StockDtiSlipNote1 = string.Empty; // 仕入伝票明細備考1
                //redStockDetail.SalesCustomerCode = default( Int32 ); // 販売先コード
                //redStockDetail.SalesCustomerSnm = default( string ); // 販売先略称
                redStockDetail.SlipMemo1 = string.Empty; // 伝票メモ１
                redStockDetail.SlipMemo2 = string.Empty; // 伝票メモ２
                redStockDetail.SlipMemo3 = string.Empty; // 伝票メモ３
                redStockDetail.InsideMemo1 = string.Empty; // 社内メモ１
                redStockDetail.InsideMemo2 = string.Empty; // 社内メモ２
                redStockDetail.InsideMemo3 = string.Empty; // 社内メモ３
                redStockDetail.SupplierCd = redStockSlip.SupplierCd; // 仕入先コード
                redStockDetail.SupplierSnm = redStockSlip.SupplierSnm; // 仕入先略称
                redStockDetail.AddresseeCode = 0; // 納品先コード
                redStockDetail.AddresseeName = string.Empty; // 納品先名称
                redStockDetail.DirectSendingCd = 0; // 直送区分
                redStockDetail.OrderNumber = string.Empty; // 発注番号
                redStockDetail.WayToOrder = 0; // 注文方法
                redStockDetail.DeliGdsCmpltDueDate = DateTime.MinValue; // 納品完了予定日
                redStockDetail.ExpectDeliveryDate = DateTime.MinValue; // 希望納期
                redStockDetail.OrderDataCreateDiv = 0; // 発注データ作成区分
                redStockDetail.OrderDataCreateDate = DateTime.MinValue; // 発注データ作成日
                redStockDetail.OrderFormIssuedDiv = 0; // 発注書発行済区分
                # endregion

                # region [明細金額算出]
                double stockUnitPriceTaxExc;
                double stockUnitPriceTaxInc;
                long stockPriceConsTax;
                long stockPriceTaxExc;
                long stockPriceTaxInc;
                // 算出
                CalculateStockPrice( redStockSlip, redStockDetail, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax );
                // 格納
                redStockDetail.StockUnitPriceFl = stockUnitPriceTaxExc;
                redStockDetail.StockUnitTaxPriceFl = stockUnitPriceTaxInc;
                redStockDetail.StockPriceTaxExc = stockPriceTaxExc;
                redStockDetail.StockPriceTaxInc = stockPriceTaxInc;
                redStockDetail.StockPriceConsTax = stockPriceConsTax;
                # endregion
            }

            # region [伝票金額算出]
            // 仕入先マスタから消費税端数処理情報を取得
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd( this._enterpriseCode, redStockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd );		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //this.GetStockFractionProcInfo( SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            this.GetStockFractionProcInfo( ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD

            // MAKON01112Aの共通クラス使用
            StockSlipPriceCalculator.TotalPriceSetting( ref redStockSlip, redStockDetailList, fracProcUnit, fracProcCd );
            # endregion
        }
        /// <summary>
        /// 登録用仕入返品伝票生成（更新用）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="redStockSlip"></param>
        /// <param name="stockDetailWorkList"></param>
        /// <param name="stockSlipWork"></param>
        /// <param name="redStockDetailList"></param>
        /// <param name="stockDateForUpdate">ADD 2012/08/22</param>
        // ---------- DEL 2012/08/22 ---------->>>>>
        //private void UpdateRedStockSlip(StockSlipLogicalKey key, ref StockSlipWork redStockSlip, ref List<StockDetailWork> redStockDetailList, StockSlipWork stockSlipWork, List<StockDetailWork> stockDetailWorkList, RedSlipWriteParameter parameter)
        // ---------- DEL 2012/08/22 ----------<<<<<
        // ---------- ADD 2012/08/22 ---------->>>>>
        private void UpdateRedStockSlip( StockSlipLogicalKey key, ref StockSlipWork redStockSlip, ref List<StockDetailWork> redStockDetailList, StockSlipWork stockSlipWork, List<StockDetailWork> stockDetailWorkList, RedSlipWriteParameter parameter, DateTime stockDateForUpdate )
        // ---------- ADD 2012/08/22 ----------<<<<<
        {
            //--------------------------------------------------------------------
            // ※売上データ読み込み時に同時に取得した、同時入力仕入データと
            //   これから更新する既存の仕入返品伝票の内容を元にして、
            //   更新用レコードを生成します。
            //--------------------------------------------------------------------

            DateTime inputDay = parameter.SalesDate;
            DateTime stockDate = key.StockDate;
            string stockInputCode = parameter.InputEmployeeCd;
            string stockInputName = parameter.InputEmployeeNm;
            int retGoodsReasonDiv = 0;
            string retGoodsReason = parameter.ReturnReason;
            string partySaleSlipNum = key.PartySaleSlipNum;
            //string warehouseCode = string.Empty;
            //string warehouseName = string.Empty;
            //string warehouseShelfNo = string.Empty;
            //int stockOrderDivCd = (warehouseCode.Trim() == string.Empty) ? 0 : 1;

            # region [仕入伝票更新]
            redStockSlip.StockSlipUpdateCd = 1; // 仕入伝票更新区分
            //redStockSlip.ArrivalGoodsDay = stockDate; // 入荷日 // DEL daibin 2013/02/06 Redmine#34580
            // ---------- DEL 2012/08/22 ---------->>>>>
            //redStockSlip.StockDate = stockDate; // 仕入日
            // ---------- DEL 2012/08/22 ----------<<<<<
            // ---------- ADD 2012/08/22 ---------->>>>>
            if (stockDateForUpdate != null && stockDateForUpdate != DateTime.MinValue)
            {
                redStockSlip.StockDate = stockDateForUpdate; // 仕入日  グリッド上で入力された仕入日
            }
            else
            {
                redStockSlip.StockDate = stockDate; // 仕入日
            }
            // ---------- ADD 2012/08/22 ----------<<<<<

            //redStockSlip.StockAddUpADate = stockDate; // 仕入計上日付 // DEL daibin 2013/02/06 Redmine#34580
            // ---------- ADD daibin 2013/02/06 Redmine#34580 ---------->>>>>
            DateTime addUpADate = DateTime.MinValue; // 仕入計上日付
            int delayPaymentDiv; // 来勘区分 
            // 仕入計上日を算出処理
            this.CalcAddUpDate(key, redStockSlip, out addUpADate, out delayPaymentDiv); 

            redStockSlip.DelayPaymentDiv = delayPaymentDiv; // 来勘区分
            redStockSlip.StockAddUpADate = addUpADate; // 仕入計上日付
            redStockSlip.ArrivalGoodsDay = redStockSlip.StockDate; // 入荷日
            // ---------- ADD daibin 2013/02/06 Redmine#34580 ----------<<<<<
            redStockSlip.StockInputCode = stockInputCode; // 仕入入力者コード
            redStockSlip.StockInputName = stockInputName; // 仕入入力者名称
            redStockSlip.StockAgentCode = stockInputCode; // 仕入担当者コード
            redStockSlip.StockAgentName = stockInputName; // 仕入担当者名称
            redStockSlip.RetGoodsReasonDiv = retGoodsReasonDiv; // 返品理由コード
            redStockSlip.RetGoodsReason = retGoodsReason; // 返品理由
            redStockSlip.PartySaleSlipNum = partySaleSlipNum; // 相手先伝票番号
            redStockSlip.DetailRowCount = redStockDetailList.Count + stockDetailWorkList.Count; // 明細行数

            # endregion

            // 明細ループ
            for ( int addIndex = 0; addIndex < stockDetailWorkList.Count; addIndex++ )
            {
                StockDetailWork redStockDetail = stockDetailWorkList[addIndex];
                // --- ADD m.suzuki 2010/10/07 ---------->>>>>
                int supplierFormalSrc = redStockDetail.SupplierFormal;
                long stockSlipDtlNumSrc = redStockDetail.StockSlipDtlNum;
                // --- ADD m.suzuki 2010/10/07 ----------<<<<<

                # region [仕入明細追加分]
                redStockDetail.CreateDateTime = DateTime.MinValue; // 作成日時
                redStockDetail.UpdateDateTime = DateTime.MinValue; // 更新日時
                redStockDetail.EnterpriseCode = _enterpriseCode; // 企業コード
                redStockDetail.FileHeaderGuid = Guid.Empty; // GUID
                redStockDetail.UpdEmployeeCode = string.Empty; // 更新従業員コード
                redStockDetail.UpdAssemblyId1 = string.Empty; // 更新アセンブリID1
                redStockDetail.UpdAssemblyId2 = string.Empty; // 更新アセンブリID2
                redStockDetail.LogicalDeleteCode = 0; // 論理削除区分
                redStockDetail.AcceptAnOrderNo = 0; // 受注番号
                redStockDetail.SupplierFormal = 0; // 仕入形式
                redStockDetail.SupplierSlipNo = 0; // 仕入伝票番号
                redStockDetail.StockRowNo = (redStockDetailList.Count + 1); // 仕入行番号
                //redStockDetail.SectionCode = redStockSlip.SectionCode; // 拠点コード
                //redStockDetail.SubSectionCode = redStockSlip.SubSectionCode; // 部門コード
                redStockDetail.CommonSeqNo = 0; // 共通通番
                redStockDetail.StockSlipDtlNum = 0; // 仕入明細通番
                // --- UPD m.suzuki 2010/10/07 ---------->>>>>
                //redStockDetail.SupplierFormalSrc = 0; // 仕入形式（元）
                //redStockDetail.StockSlipDtlNumSrc = 0; // 仕入明細通番（元）
                redStockDetail.SupplierFormalSrc = supplierFormalSrc; // 仕入形式（元）
                redStockDetail.StockSlipDtlNumSrc = stockSlipDtlNumSrc; // 仕入明細通番（元）
                // --- UPD m.suzuki 2010/10/07 ----------<<<<<
                // --- UPD m.suzuki 2010/10/07 ---------->>>>>
                //redStockDetail.AcptAnOdrStatusSync = 0; // 受注ステータス（同時）
                redStockDetail.AcptAnOdrStatusSync = 30; // 受注ステータス（同時）=30:売上
                // --- UPD m.suzuki 2010/10/07 ----------<<<<<
                redStockDetail.SalesSlipDtlNumSync = 0; // 売上明細通番（同時）
                redStockDetail.StockSlipCdDtl = 1; // 仕入伝票区分（明細）
                redStockDetail.StockInputCode = redStockSlip.StockInputCode; // 仕入入力者コード
                redStockDetail.StockInputName = redStockSlip.StockInputName; // 仕入入力者名称
                redStockDetail.StockAgentCode = redStockSlip.StockAgentCode; // 仕入担当者コード
                redStockDetail.StockAgentName = redStockSlip.StockAgentName; // 仕入担当者名称
                //redStockDetail.GoodsKindCode = default( Int32 ); // 商品属性
                //redStockDetail.GoodsMakerCd = default( Int32 ); // 商品メーカーコード
                //redStockDetail.MakerName = default( string ); // メーカー名称
                //redStockDetail.MakerKanaName = default( string ); // メーカーカナ名称
                //redStockDetail.CmpltMakerKanaName = default( string ); // メーカーカナ名称（一式）
                //redStockDetail.GoodsNo = default( string ); // 商品番号
                //redStockDetail.GoodsName = default( string ); // 商品名称
                //redStockDetail.GoodsNameKana = default( string ); // 商品名称カナ
                //redStockDetail.GoodsLGroup = default( Int32 ); // 商品大分類コード
                //redStockDetail.GoodsLGroupName = default( string ); // 商品大分類名称
                //redStockDetail.GoodsMGroup = default( Int32 ); // 商品中分類コード
                //redStockDetail.GoodsMGroupName = default( string ); // 商品中分類名称
                //redStockDetail.BLGroupCode = default( Int32 ); // BLグループコード
                //redStockDetail.BLGroupName = default( string ); // BLグループコード名称
                //redStockDetail.BLGoodsCode = default( Int32 ); // BL商品コード
                //redStockDetail.BLGoodsFullName = default( string ); // BL商品コード名称（全角）
                //redStockDetail.EnterpriseGanreCode = default( Int32 ); // 自社分類コード
                //redStockDetail.EnterpriseGanreName = default( string ); // 自社分類名称
                //redStockDetail.WarehouseCode = warehouseCode; // 倉庫コード
                //redStockDetail.WarehouseName = warehouseName; // 倉庫名称
                //redStockDetail.WarehouseShelfNo = warehouseShelfNo; // 倉庫棚番
                //redStockDetail.StockOrderDivCd = stockOrderDivCd; // 仕入在庫取寄せ区分
                //redStockDetail.OpenPriceDiv = default( Int32 ); // オープン価格区分
                //redStockDetail.GoodsRateRank = default( string ); // 商品掛率ランク
                //redStockDetail.CustRateGrpCode = default( Int32 ); // 得意先掛率グループコード
                //redStockDetail.SuppRateGrpCode = default( Int32 ); // 仕入先掛率グループコード
                //redStockDetail.ListPriceTaxExcFl = default( Double ); // 定価（税抜，浮動）
                //redStockDetail.ListPriceTaxIncFl = default( Double ); // 定価（税込，浮動）
                //redStockDetail.StockRate = default( Double ); // 仕入率
                //redStockDetail.RateSectStckUnPrc = default( string ); // 掛率設定拠点（仕入単価）
                //redStockDetail.RateDivStckUnPrc = default( string ); // 掛率設定区分（仕入単価）
                //redStockDetail.UnPrcCalcCdStckUnPrc = default( Int32 ); // 単価算出区分（仕入単価）
                //redStockDetail.PriceCdStckUnPrc = default( Int32 ); // 価格区分（仕入単価）
                //redStockDetail.StdUnPrcStckUnPrc = default( Double ); // 基準単価（仕入単価）
                //redStockDetail.FracProcUnitStcUnPrc = default( Double ); // 端数処理単位（仕入単価）
                //redStockDetail.FracProcStckUnPrc = default( Int32 ); // 端数処理（仕入単価）
                //redStockDetail.StockUnitPriceFl = default( Double ); // 仕入単価（税抜，浮動）
                //redStockDetail.StockUnitTaxPriceFl = default( Double ); // 仕入単価（税込，浮動）
                //redStockDetail.StockUnitChngDiv = default( Int32 ); // 仕入単価変更区分
                //redStockDetail.BfStockUnitPriceFl = default( Double ); // 変更前仕入単価（浮動）
                //redStockDetail.BfListPrice = default( Double ); // 変更前定価
                //redStockDetail.RateBLGoodsCode = default( Int32 ); // BL商品コード（掛率）
                //redStockDetail.RateBLGoodsName = default( string ); // BL商品コード名称（掛率）
                //redStockDetail.RateGoodsRateGrpCd = default( Int32 ); // 商品掛率グループコード（掛率）
                //redStockDetail.RateGoodsRateGrpNm = default( string ); // 商品掛率グループ名称（掛率）
                //redStockDetail.RateBLGroupCode = default( Int32 ); // BLグループコード（掛率）
                //redStockDetail.RateBLGroupName = default( string ); // BLグループ名称（掛率）
                //redStockDetail.StockCount = default( Double ); // 仕入数
                //redStockDetail.OrderCnt = default( Double ); // 発注数量
                //redStockDetail.OrderAdjustCnt = default( Double ); // 発注調整数
                //redStockDetail.OrderRemainCnt = default( Double ); // 発注残数
                redStockDetail.RemainCntUpdDate = DateTime.MinValue; // 残数更新日
                //redStockDetail.StockPriceTaxExc = default( Int64 ); // 仕入金額（税抜き）
                //redStockDetail.StockPriceTaxInc = default( Int64 ); // 仕入金額（税込み）
                //redStockDetail.StockGoodsCd = default( Int32 ); // 仕入商品区分
                //redStockDetail.StockPriceConsTax = default( Int64 ); // 仕入金額消費税額
                //redStockDetail.TaxationCode = default( Int32 ); // 課税区分
                redStockDetail.StockDtiSlipNote1 = string.Empty; // 仕入伝票明細備考1
                //redStockDetail.SalesCustomerCode = default( Int32 ); // 販売先コード
                //redStockDetail.SalesCustomerSnm = default( string ); // 販売先略称
                redStockDetail.SlipMemo1 = string.Empty; // 伝票メモ１
                redStockDetail.SlipMemo2 = string.Empty; // 伝票メモ２
                redStockDetail.SlipMemo3 = string.Empty; // 伝票メモ３
                redStockDetail.InsideMemo1 = string.Empty; // 社内メモ１
                redStockDetail.InsideMemo2 = string.Empty; // 社内メモ２
                redStockDetail.InsideMemo3 = string.Empty; // 社内メモ３
                redStockDetail.SupplierCd = redStockSlip.SupplierCd; // 仕入先コード
                redStockDetail.SupplierSnm = redStockSlip.SupplierSnm; // 仕入先略称
                redStockDetail.AddresseeCode = 0; // 納品先コード
                redStockDetail.AddresseeName = string.Empty; // 納品先名称
                redStockDetail.DirectSendingCd = 0; // 直送区分
                redStockDetail.OrderNumber = string.Empty; // 発注番号
                redStockDetail.WayToOrder = 0; // 注文方法
                redStockDetail.DeliGdsCmpltDueDate = DateTime.MinValue; // 納品完了予定日
                redStockDetail.ExpectDeliveryDate = DateTime.MinValue; // 希望納期
                redStockDetail.OrderDataCreateDiv = 0; // 発注データ作成区分
                redStockDetail.OrderDataCreateDate = DateTime.MinValue; // 発注データ作成日
                redStockDetail.OrderFormIssuedDiv = 0; // 発注書発行済区分
                # endregion

                # region [明細金額算出]
                double stockUnitPriceTaxExc;
                double stockUnitPriceTaxInc;
                long stockPriceConsTax;
                long stockPriceTaxExc;
                long stockPriceTaxInc;
                // 算出
                CalculateStockPrice( redStockSlip, redStockDetail, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax );
                // 格納
                redStockDetail.StockUnitPriceFl = stockUnitPriceTaxExc;
                redStockDetail.StockUnitTaxPriceFl = stockUnitPriceTaxInc;
                redStockDetail.StockPriceTaxExc = stockPriceTaxExc;
                redStockDetail.StockPriceTaxInc = stockPriceTaxInc;
                redStockDetail.StockPriceConsTax = stockPriceConsTax;
                # endregion

                redStockDetailList.Add( redStockDetail );
            }

            # region [伝票金額算出]
            // 仕入先マスタから消費税端数処理情報を取得
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd( this._enterpriseCode, redStockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd );		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //this.GetStockFractionProcInfo( SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            this.GetStockFractionProcInfo( ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD

            // MAKON01112Aの共通クラス使用
            StockSlipPriceCalculator.TotalPriceSetting( ref redStockSlip, redStockDetailList, fracProcUnit, fracProcCd );
            # endregion
        }
        /// <summary>
        /// 仕入伝票抽出処理
        /// </summary>
        /// <param name="rowView"></param>
        /// <param name="salesDtlNum"></param>
        /// <param name="stockSlipWorkList"></param>
        /// <param name="stockDetailWorkList"></param>
        /// <param name="retStockSlip"></param>
        /// <param name="retStockDetailList"></param>
        private void SelectStockSlip( DataRowView rowView, long salesDtlNum, List<StockSlipWork> stockSlipWorkList, List<StockDetailWork> stockDetailWorkList, out StockSlipWork retStockSlip, out StockDetailWork retStockDetail )
        {
            retStockSlip = null;
            retStockDetail = null;

            // 仕入SEQ番号
            int supplierSlipNo = (int)rowView[_detailDataSet.RedSlipDetail.SupplierSlipNoColumn.ColumnName];

            retStockSlip = stockSlipWorkList.Find(
                                    delegate( StockSlipWork stockSlip )
                                    {
                                        return (stockSlip.SupplierSlipNo == supplierSlipNo);
                                    }
                                    );
            retStockDetail = stockDetailWorkList.Find(
                                    delegate( StockDetailWork stockDetail )
                                    {
                                        return (stockDetail.SupplierSlipNo == supplierSlipNo && stockDetail.SalesSlipDtlNumSync == salesDtlNum);
                                    }
                                    );
            if (retStockSlip == null) retStockSlip = new StockSlipWork();
            if (retStockDetail == null) retStockDetail = new StockDetailWork();
        }
        // ----- ADD 2013/02/27 ----->>>>>
        /// <summary>
        /// 仕入伝票抽出処理(仕入返品予定用)
        /// </summary>
        /// <param name="rowView"></param>
        /// <param name="salesDtlNum"></param>
        /// <param name="stockSlipWorkList"></param>
        /// <param name="stockDetailWorkList"></param>
        /// <param name="retStockSlip"></param>
        /// <param name="retStockDetailList"></param>
        private int SelectStockSlipForRetPln(DataRowView rowView, long salesDtlNum, List<StockSlipWork> stockSlipWorkList, List<StockDetailWork> stockDetailWorkList, out StockSlipWork retStockSlip, out StockDetailWork retStockDetail)
        {
            // 仕入返品予定では、元仕入伝票が見つからない場合はエラーとして扱う。
            int ret = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            retStockSlip = null;
            retStockDetail = null;

            // 仕入SEQ番号
            int supplierSlipNo = (int)rowView[_detailDataSet.RedSlipDetail.SupplierSlipNoColumn.ColumnName];

            retStockSlip = stockSlipWorkList.Find(
                                    delegate(StockSlipWork stockSlip)
                                    {
                                        return (stockSlip.SupplierSlipNo == supplierSlipNo);
                                    }
                                    );
            retStockDetail = stockDetailWorkList.Find(
                                    delegate(StockDetailWork stockDetail)
                                    {
                                        return (stockDetail.SupplierSlipNo == supplierSlipNo && stockDetail.SalesSlipDtlNumSync == salesDtlNum);
                                    }
                                    );
            if (retStockSlip == null || retStockDetail == null)
            {
                retStockSlip = new StockSlipWork();
                retStockDetail = new StockDetailWork();
                ret = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return ret;
        }
        // ----- ADD 2013/02/27 -----<<<<<
        /// <summary>
        /// 受注マスタ（車両）Find処理
        /// </summary>
        /// <param name="acceptOdrCarList"></param>
        /// <param name="acceptAnOrderNo"></param>
        /// <returns></returns>
        private AcceptOdrCarWork FindAcceptOdrCar( List<AcceptOdrCarWork> acceptOdrCarList, int acceptAnOrderNo )
        {
            return acceptOdrCarList.Find( 
                    delegate( AcceptOdrCarWork acceptOdrCar )
                    {
                        return (acceptOdrCar.AcceptAnOrderNo == acceptAnOrderNo);
                    }
                    );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
        /// <summary>
        /// 売上データ登録パラメータ生成
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="redSlipWork"></param>
        /// <param name="redDetailWorkList"></param>
        /// <param name="parameter"></param>
        /// <param name="redDepositAlwWork"></param>
        /// <param name="redDepsitDataWork"></param>
        /// <remarks>１伝票分をparaListに追加する</remarks>
        // 2010/11/29 >>>
        //private void CreateWriteParam( ref CustomSerializeArrayList paraList, SalesSlipWork redSlipWork, List<SalesDetailWork> redDetailWorkList, RedSlipWriteParameter parameter )
        private void CreateWriteParam(ref CustomSerializeArrayList paraList, SalesSlipWork redSlipWork, List<SalesDetailWork> redDetailWorkList, RedSlipWriteParameter parameter, DepsitDataWork redDepsitDataWork, DepositAlwWork redDepositAlwWork)
        // 2010/11/29 <<<
        {
            if ( paraList == null )
            {
                paraList = new CustomSerializeArrayList();
            }

            // 売上データ
            # region [売上データ]
            CustomSerializeArrayList salesWriteList = new CustomSerializeArrayList();
            paraList.Add( salesWriteList );

            // 売上伝票
            salesWriteList.Add( redSlipWork );
            // 売上明細
            salesWriteList.Add( new ArrayList( (SalesDetailWork[])redDetailWorkList.ToArray() ) );
            # endregion

            // 車輌管理情報
            # region [車両管理情報]
            ArrayList carManagementWorkList;
            GetCarManagementWorkListFromCarInfoTable( _carInfoDataTable, out carManagementWorkList );
            if ( carManagementWorkList != null && carManagementWorkList.Count > 0 )
            {
                salesWriteList.Add( carManagementWorkList );
            }
            # endregion

            // 明細追加情報
            # region [明細追加情報]
            ArrayList slipDetailAddInfoWorkList;
            GetSlipDetailAddInfoWorkListFromDic( redDetailWorkList, parameter, out slipDetailAddInfoWorkList );
            if ( slipDetailAddInfoWorkList != null && slipDetailAddInfoWorkList.Count > 0 )
            {
                salesWriteList.Add( slipDetailAddInfoWorkList );
            }
            # endregion

            // 2010/11/29 Add >>>
            # region [ 入金情報 ]

            if (redDepsitDataWork != null)
            {
                salesWriteList.Add(redDepsitDataWork);
            }

            if (redDepositAlwWork != null)
            {
                salesWriteList.Add(redDepositAlwWork);
            }
            #endregion
            // 2010/11/29 Add <<<
        }
        // --- ADD m.suzuki 2010/10/07 ---------->>>>>
        /// <summary>
        /// データ登録処理
        /// </summary>
        /// <param name="writeObj"></param>
        /// <param name="retMessage"></param>
        /// <param name="_printRedSalesSlipNo"></param>
        /// <returns></returns>
        // ----- DEL 2013/01/15 ----->>>>>
        //private int SaveDBData( object paraObj, out string retMessage, ref Dictionary<string, int> _printRedSalesSlipNo )
        // ----- DEL 2013/01/15 -----<<<<<
        // ----- ADD 2013/01/15 ----->>>>>
        private int SaveDBData(ref object paraObj, out string retMessage, ref Dictionary<string, int> _printRedSalesSlipNo)
        // ----- ADD 2013/01/15 -----<<<<<
        {
            string retItemInfo;

            // 得意先電子元帳Rを経由してIOWriter呼び出し
            int status = this._iCustPrtPprWorkDB.WriteByIOWriter( ref paraObj, out retMessage, out retItemInfo );

            // ADD 2012/10/17 湯上 SCM障害№10414対応 ------------------------>>>>>
            this._salesSlipNumList = new List<string>();
            // ADD 2012/10/17 湯上 SCM障害№10414対応 ------------------------<<<<<

            // 伝票番号･受注ステータス退避(赤伝発行時使用)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && paraObj != null )
            {
                _printRedSalesSlipNo = new Dictionary<string, int>();
                SalesSlipWork _salesslipWork = new SalesSlipWork();

                ArrayList paramList = (ArrayList)paraObj;
                for ( int i = 1; i < paramList.Count; i++ )
                {
                    ArrayList al = paramList[i] as ArrayList;

                    // ﾘｽﾄ[0]のSalesSlipWorkから伝票番号・受注ステータスをDictionaryに格納
                    if ( al[0] is SalesSlipWork )
                    {
                        SalesSlipWork paraSalesSlip = al[0] as SalesSlipWork;
                        _printRedSalesSlipNo.Add( paraSalesSlip.SalesSlipNum, paraSalesSlip.AcptAnOdrStatus );
                    }
                    // ADD 2012/10/17 湯上 SCM障害№10414対応 ------------------------>>>>>
                    // リストが売上伝票データの時、売上伝票番号をリストに格納する
                    for (int index = 0; index < al.Count; index++)
                    {
                        if (al[index] is SalesSlipWork)
                        {
                            SalesSlipWork tempSalesSlipWork = (SalesSlipWork)al[index];
                            this._salesSlipNumList.Add(tempSalesSlipWork.SalesSlipNum);
                        }
                    }
                    // ADD 2012/10/17 湯上 SCM障害№10414対応 ------------------------<<<<<
                }
            }

            return status;
        }
        // --- ADD m.suzuki 2010/10/07 ----------<<<<<

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD
        /// <summary>
        /// 売上データ登録処理
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="parameter"></param>
        /// <param name="retMessage"></param>
        /// <param name="_printRedSalesSlipNo"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        // --- UPD m.suzuki 2010/10/07 ---------->>>>>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 DEL
        ////private int SaveDBData(SalesSlipWork redSlipWork, List<SalesDetailWork> redDetailWorkList, RedSlipWriteParameter parameter, out string retMessage, ref Dictionary<string, int> _printRedSalesSlipNo)
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
        //private int SaveDBData( ref CustomSerializeArrayList paraList, RedSlipWriteParameter parameter, out string retMessage, ref Dictionary<string, int> _printRedSalesSlipNo )
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD
        private int CreateParamForSaveDBData( out object writeObj, ref CustomSerializeArrayList paraList, RedSlipWriteParameter parameter, out string retMessage, ref Dictionary<string, int> _printRedSalesSlipNo )
        // --- UPD m.suzuki 2010/10/07 ----------<<<<<
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --CustomSerializeArrayList      売上リスト
            //          --SalesSlipWork             売上データオブジェクト
            //          --ArrayList                 売上明細リスト
            //              --SalesDetailWork       売上明細データオブジェクト
            //          --CarManagementWork         車両管理データオブジェクト
            //          --ArrayList                 明細追加情報リスト
            //              --SlipDetailAddInfo     明細追加情報データオブジェクト
            //      --IOWriteCtrlOptWork            リモート参照用パラメータ
            //------------------------------------------------------------------------------------

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 DEL // CreateWriteParamに移行
            # region // DEL
            //CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            //// 売上データ
            //# region [売上データ]
            //CustomSerializeArrayList salesWriteList = new CustomSerializeArrayList();
            //paraList.Add( salesWriteList );

            //// 売上伝票
            //salesWriteList.Add( redSlipWork );
            //// 売上明細
            //salesWriteList.Add( new ArrayList( (SalesDetailWork[])redDetailWorkList.ToArray() ) );
            //# endregion

            //// 車輌管理情報
            //# region [車両管理情報]
            //ArrayList carManagementWorkList;
            //GetCarManagementWorkListFromCarInfoTable( _carInfoDataTable, out carManagementWorkList );
            //if ( carManagementWorkList != null && carManagementWorkList.Count > 0 )
            //{
            //    salesWriteList.Add( carManagementWorkList );
            //}
            //# endregion

            //// 明細追加情報
            //# region [明細追加情報]
            //ArrayList slipDetailAddInfoWorkList;
            //GetSlipDetailAddInfoWorkListFromDic( redDetailWorkList, parameter, out slipDetailAddInfoWorkList );
            //if ( slipDetailAddInfoWorkList != null && slipDetailAddInfoWorkList.Count > 0 )
            //{
            //    salesWriteList.Add( slipDetailAddInfoWorkList );
            //}
            //# endregion
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 DEL

            // リモート参照用パラメータ
            # region [リモート参照用パラメータ]
            IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // リモート参照用パラメータ
            this.SettingIOWriteCtrlOptWork( OptWorkSettingType.Write, out iOWriteCtrlOptWork ); // リモート参照用パラメータ設定処理
            paraList.Add( iOWriteCtrlOptWork );
            # endregion

            // ＤＢ書き込み実行
            # region [書き込み]
            retMessage = string.Empty;
            string retItemInfo = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            object paraObj = (object)paraList;

            // --- UPD m.suzuki 2010/10/07 ---------->>>>>
            //// 書き込み
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            ////status = this._iIOWriteControlDB.Write( ref paraObj, out retMessage, out retItemInfo );
            //status = this._iCustPrtPprWorkDB.WriteByIOWriter( ref paraObj, out retMessage, out retItemInfo );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            writeObj = paraObj;
            // --- UPD m.suzuki 2010/10/07 ----------<<<<<

            # endregion

            // --- DEL m.suzuki 2010/10/07 ---------->>>>> // SaveDBDataメソッドに移す
            //// Add sakurai 2009/02/03 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// 伝票番号･受注ステータス退避(赤伝発行時使用)
            ////if (paraObj != null) // DEL 2009/02/19
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
            //    && paraObj != null) // ADD 2009/02/19
            //{
            //    _printRedSalesSlipNo = new Dictionary<string, int>();
            //    SalesSlipWork _salesslipWork = new SalesSlipWork();

            //    ArrayList paramList = (ArrayList)paraObj;
            //    for (int i = 1; i < paramList.Count; i++)
            //    {
            //        ArrayList al = paramList[i] as ArrayList;

            //        // ﾘｽﾄ[0]のSalesSlipWorkから伝票番号・受注ステータスをDictionaryに格納
            //        if (al[0] is SalesSlipWork)
            //        {
            //            SalesSlipWork paraSalesSlip = al[0] as SalesSlipWork;
            //            _printRedSalesSlipNo.Add(paraSalesSlip.SalesSlipNum,paraSalesSlip.AcptAnOdrStatus);
            //        }
            //    }
            //}
            //// Add sakurai 2009/02/03 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // --- DEL m.suzuki 2010/10/07 ----------<<<<<
            return status;
        }
        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        /// <param name="optWorkSettinType"> </param>
        /// <param name="iOWriteCtrlOptWork"></param>
        private void SettingIOWriteCtrlOptWork( OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork )
        {
            iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;                              // 制御起点(0:売上 1:仕入 2:仕入売上同時計上)
            iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this.SalesTtlSt.AcpOdrrAddUpRemDiv;     // 受注データ計上残区分
            iOWriteCtrlOptWork.ShipmAddUpRemDiv = this.SalesTtlSt.ShipmAddUpRemDiv;         // 出荷データ計上残区分
            iOWriteCtrlOptWork.EstimateAddUpRemDiv = this.SalesTtlSt.EstmateAddUpRemDiv;    // 見積データ計上残区分
            iOWriteCtrlOptWork.RetGoodsStockEtyDiv = this.SalesTtlSt.RetGoodsStockEtyDiv;   // 返品時在庫登録区分
            iOWriteCtrlOptWork.RemainCntMngDiv = 0;                                                                         // 残数管理区分(0:する 固定とする)
            iOWriteCtrlOptWork.SupplierSlipDelDiv = this.SalesTtlSt.SupplierSlipDelDiv;     // 仕入伝票削除区分
            iOWriteCtrlOptWork.CarMngDivCd = this.CarMngDivCd;                                                   // 車両管理マスタ登録区分(0:登録しない 1:登録する)
            switch ( optWorkSettinType )
            {
                case OptWorkSettingType.Write:
                    break;
                case OptWorkSettingType.Read:
                    break;
                //case OptWorkSettingType.Delete:
                //    if ( this.SalesTtlSt.SupplierSlipDelDiv == 1 )
                //    {
                //        iOWriteCtrlOptWork.SupplierSlipDelDiv = this._supplierSlipDelDiv; // 仕入伝票削除区分
                //    }
                //    break;
            }
        }
        /// <summary>
        /// 仕入伝票登録処理
        /// </summary>
        /// <param name="redStockSlipList"></param>
        /// <param name="redStockDetailListList"></param>
        /// <param name="retMessage"></param>
        /// <returns></returns>
        // --- UPD m.suzuki 2010/10/07 ---------->>>>>
        //private int SaveDBDataOfStock(List<StockSlipWork> redStockSlipList, List<List<StockDetailWork>> redStockDetailListList, out string retMessage, ref Dictionary<string, int> _printRedSalesSlipNo)
        private int CreateParamForSaveDBDataOfStock( out object writeObj, List<StockSlipWork> redStockSlipList, List<List<StockDetailWork>> redStockDetailListList, out string retMessage )
        // --- UPD m.suzuki 2010/10/07 ----------<<<<<
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 明細追加情報リスト // ADD m.suzuki 2010/10/07
            //              --SlipDetailAddInfo     明細追加情報データオブジェクト // ADD m.suzuki 2010/10/07
            //      --IOWriteCtrlOptWork            リモート参照用パラメータ // DEL m.suzuki 2010/10/07
            //------------------------------------------------------------------------------------


            retMessage = string.Empty;

            CustomSerializeArrayList paraList = new CustomSerializeArrayList();


            for ( int index = 0; index < redStockSlipList.Count; index++ )
            {
                // 明細が無ければ終了
                if ( redStockDetailListList.Count <= index ) break;
                
                CustomSerializeArrayList stockWriteList = new CustomSerializeArrayList();

                // 仕入伝票
                stockWriteList.Add( redStockSlipList[index] );
                // 仕入明細
                stockWriteList.Add( new ArrayList( redStockDetailListList[index].ToArray() ) );

                // --- ADD m.suzuki 2010/10/07 ---------->>>>>
                // 仕入用明細追加情報ﾘｽﾄ生成処理
                stockWriteList.Add( new ArrayList( CreateSlipDetailAddInfoListForStock( redStockSlipList[index], redStockDetailListList[index] ) ) );
                // --- ADD m.suzuki 2010/10/07 ----------<<<<<

                paraList.Add( stockWriteList );
            }

            // --- DEL m.suzuki 2010/10/07 ---------->>>>>
            //// リモート参照用パラメータ
            //# region [リモート参照用パラメータ]
            //IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // リモート参照用パラメータ
            //this.SettingIOWriteCtrlOptWorkForStock( OptWorkSettingType.Write, out iOWriteCtrlOptWork ); // リモート参照用パラメータ設定処理
            //paraList.Add( iOWriteCtrlOptWork );
            //# endregion
            // --- DEL m.suzuki 2010/10/07 ----------<<<<<

            // ＤＢ書き込み実行
            # region [書き込み]
            retMessage = string.Empty;
            string retItemInfo = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            object paraObj = (object)paraList;


            // --- UPD m.suzuki 2010/10/07 ---------->>>>>
            //// 書き込み
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            ////status = this._iIOWriteControlDB.Write( ref paraObj, out retMessage, out retItemInfo );
            //status = _iCustPrtPprWorkDB.WriteByIOWriter( ref paraObj, out retMessage, out retItemInfo );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            writeObj = paraObj;
            // --- UPD m.suzuki 2010/10/07 ----------<<<<<

            # endregion

            return status;
        }
        // --- ADD m.suzuki 2010/10/07 ---------->>>>>
        /// <summary>
        /// （仕入用）明細追加情報ﾘｽﾄ生成処理
        /// </summary>
        /// <param name="stockSlipWork"></param>
        /// <param name="stockDetailWorkList"></param>
        /// <returns></returns>
        private List<SlipDetailAddInfoWork> CreateSlipDetailAddInfoListForStock( StockSlipWork stockSlipWork, List<StockDetailWork> stockDetailWorkList )
        {
            List<SlipDetailAddInfoWork> slipDetailAddInfoWorkList = new List<SlipDetailAddInfoWork>();

            for ( int index = 0; index < stockDetailWorkList.Count; index++ )
            {
                // 仕入明細
                StockDetailWork stockDetailWork = stockDetailWorkList[index];

                // 仕入明細追加情報
                SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
                # region [slipDetailAddInfoWork]
                slipDetailAddInfoWork.GoodsEntryDiv = 0;
                slipDetailAddInfoWork.PriceUpdateDiv = 0;
                slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;
                slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;
                slipDetailAddInfoWork.DtlRelationGuid = stockDetailWork.DtlRelationGuid;
                slipDetailAddInfoWork.SlipDtlRegOrder = index + 1;
                # endregion
                // --- ADD K2014/06/20 Y.Wakita ---------->>>>>
                slipDetailAddInfoWork.ZaiUpdFlg = false;
                // --- ADD K2014/06/20 Y.Wakita ----------<<<<<
                slipDetailAddInfoWorkList.Add( slipDetailAddInfoWork );
            }

            return slipDetailAddInfoWorkList;
        }
        // --- ADD m.suzuki 2010/10/07 ----------<<<<<
        // --- DEL m.suzuki 2010/10/07 ---------->>>>>
        ///// <summary>
        ///// リモート参照用パラメータ設定処理
        ///// </summary>
        ///// <param name="optWorkSettinType"></param>
        ///// <param name="iOWriteCtrlOptWork"></param>
        //private void SettingIOWriteCtrlOptWorkForStock( OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork )
        //{
        //    iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
        //    iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Purchase;// 制御起点(0:売上 1:仕入 2:仕入売上同時計上)
        //    iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this.SalesTtlSt.AcpOdrrAddUpRemDiv;     // 受注データ計上残区分
        //    iOWriteCtrlOptWork.ShipmAddUpRemDiv = this.SalesTtlSt.ShipmAddUpRemDiv;         // 出荷データ計上残区分
        //    iOWriteCtrlOptWork.EstimateAddUpRemDiv = this.SalesTtlSt.EstmateAddUpRemDiv;    // 見積データ計上残区分
        //    iOWriteCtrlOptWork.RetGoodsStockEtyDiv = this.SalesTtlSt.RetGoodsStockEtyDiv;   // 返品時在庫登録区分
        //    iOWriteCtrlOptWork.RemainCntMngDiv = 0;                                                                         // 残数管理区分(0:する 固定とする)
        //    iOWriteCtrlOptWork.SupplierSlipDelDiv = this.SalesTtlSt.SupplierSlipDelDiv;     // 仕入伝票削除区分
        //    iOWriteCtrlOptWork.CarMngDivCd = this.CarMngDivCd;                                                   // 車両管理マスタ登録区分(0:登録しない 1:登録する)
        //    iOWriteCtrlOptWork.EnterpriseCode = this.SalesTtlSt.EnterpriseCode;
        //    switch ( optWorkSettinType )
        //    {
        //        case OptWorkSettingType.Write:
        //            break;
        //        case OptWorkSettingType.Read:
        //            break;
        //        //case OptWorkSettingType.Delete:
        //        //    if ( this.SalesTtlSt.SupplierSlipDelDiv == 1 )
        //        //    {
        //        //        iOWriteCtrlOptWork.SupplierSlipDelDiv = this._supplierSlipDelDiv; // 仕入伝票削除区分
        //        //    }
        //        //    break;
        //    }
        //}
        // --- DEL m.suzuki 2010/10/07 ----------<<<<<

        // --- ADD 譚洪 2014/01/07 ---------->>>>>
        /// <summary>
        /// 消費税転嫁方式編集判断メソッド
        /// </summary>
        /// <param name="salesSlip">売上データ</param>
        /// <param name="parameter">赤伝データ</param>
        /// <remarks>
        /// <br>Note       : 消費税転嫁方式編集判断を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2013/12/30</br>
        /// </remarks>
        /// <returns>true:存在する false:存在しない</returns>
        private bool CheckConsTaxLayMethod(SalesSlipWork salesSlip, RedSlipWriteParameter parameter)
        {
            bool consTaxLayMethodFlg = false;

            // ①元黒の消費税転嫁方式が、請求親又は請求子の場合、
            if (salesSlip.ConsTaxLayMethod == 2 || salesSlip.ConsTaxLayMethod == 3)
            {
                this._salesSlipInputInitDataAcs.GetTaxRateSet(this.EnterpriseCode, salesSlip.SalesDate);

                // ②税率設定が２件以上ある場合、
                if (this._salesSlipInputInitDataAcs.GetTaxRateSet().TaxRateStartDate2 != DateTime.MinValue
                    || this._salesSlipInputInitDataAcs.GetTaxRateSet().TaxRateStartDate3 != DateTime.MinValue)
                {
                    double taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(parameter.SalesDate);

                    // ③元黒売上日付と赤伝売上日付で、税率が違う場合、
                    if (salesSlip.ConsTaxRate != taxRate)
                    {
                        consTaxLayMethodFlg = true;
                    }
                }
            }

            return consTaxLayMethodFlg;
        }
        // --- ADD 譚洪 2014/01/07 ----------<<<<<
        // --- ADD xuyb 2014/02/07 Redmine#41771 ---------->>>>>
        /// <summary>
        /// 消費税転嫁方式編集判断メソッド(仕入)
        /// </summary>
        /// <param name="redStockSlip">仕入データ</param>
        /// <param name="redStockDate">赤伝仕入日付</param>
        /// <remarks>
        /// <br>Note       : 消費税転嫁方式編集判断を行います。</br>
        /// <br>Programmer : xuyb</br>
        /// <br>Date       : 2014/02/07</br>
        /// </remarks>
        /// <returns>true:存在する false:存在しない</returns>
        private bool CheckStockConsTaxLay(StockSlipWork redStockSlip, DateTime redStockDate)
        {
            bool consTaxLayMethodFlg = false;

            // ①元黒の消費税転嫁方式が、請求親又は請求子の場合、
            if (redStockSlip.SuppCTaxLayCd == 2 || redStockSlip.SuppCTaxLayCd == 3)
            {
                this._salesSlipInputInitDataAcs.GetTaxRateSet(this.EnterpriseCode, redStockSlip.StockDate);

                // ②税率設定が２件以上ある場合、
                if (this._salesSlipInputInitDataAcs.GetTaxRateSet().TaxRateStartDate2 != DateTime.MinValue
                    || this._salesSlipInputInitDataAcs.GetTaxRateSet().TaxRateStartDate3 != DateTime.MinValue)
                {
                    double taxRate = this._salesSlipInputInitDataAcs.GetTaxRate(redStockDate);

                    // ③元黒売上日付と赤伝売上日付で、税率が違う場合、
                    if (redStockSlip.SupplierConsTaxRate != taxRate)
                    {
                        consTaxLayMethodFlg = true;
                    }
                }
            }

            return consTaxLayMethodFlg;
        }
        // --- ADD xuyb 2014/02/07 Redmine#41771 ----------<<<<<

        # region [登録用赤伝データ生成]
        /// <summary>
        /// 登録用赤伝（伝票）生成処理
        /// </summary>
        /// <param name="redSalesSlip"></param>
        /// <param name="redSalesDetailList"></param>
        /// <param name="parameter"></param>
        /// <br>Update Note: 2010/12/20 liyp</br>
        /// <br>            赤伝のデータセット仕様の修正（MANTIS: 16057）</br>
        /// <br>            担当者名の桁数が多い場合のエラー修正</br>
        /// <br>Update Note: 2013/03/18 zhaimm</br>
        /// <br>           : 10800003-00、2013/05/15配信分、Redmine#34807得意先電子元帳の対応</br>
        /// <br>           : 赤伝発行時：売上伝票入力の仕様と同様、0詰めを行う</br>
        private void ReflectRedSalesSlip( ref SalesSlipWork redSalesSlip, List<SalesDetailWork> redSalesDetailList, RedSlipWriteParameter parameter )
        {
            # region [書き換え]
            // 共通ファイルヘッダ
            redSalesSlip.CreateDateTime = DateTime.MinValue; // 作成日時
            redSalesSlip.UpdateDateTime = DateTime.MinValue; // 更新日時
            redSalesSlip.EnterpriseCode = parameter.EnterpriseCode; // 企業コード
            redSalesSlip.FileHeaderGuid = Guid.Empty; // GUID
            redSalesSlip.UpdEmployeeCode = string.Empty; // 更新従業員コード
            redSalesSlip.UpdAssemblyId1 = string.Empty; // 更新アセンブリID1
            redSalesSlip.UpdAssemblyId2 = string.Empty; // 更新アセンブリID2
            redSalesSlip.LogicalDeleteCode = 0; // 論理削除区分

            // --------------ADD 2010/12/20 ------------>>>>>
            redSalesSlip.SectionCode = _loginSectionCode; //ログイン拠点
            if (!string.IsNullOrEmpty(parameter.InputEmployeeCd.Trim()))
            {
                Employee employeeInfo;
                int status = this._employeeAcs.Read(out employeeInfo, this._enterpriseCode, parameter.InputEmployeeCd);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    redSalesSlip.SalesInpSecCd = employeeInfo.BelongSectionCode;//発行者の所属拠点
                }
            }
            redSalesSlip.UpdateSecCd = _loginSectionCode;//ログイン拠点
            // --------------ADD 2010/12/20 ------------<<<<<

            // --- ADD 譚洪 2014/01/07 ------------ >>>>>>
            // 消費税転嫁方式編集判断メソッドの返値がtrueの場合、
            if (CheckConsTaxLayMethod(redSalesSlip, parameter))
            {
                // 売上データ(SalesSlipRf).消費税転嫁方式(ConsTaxLayMethodRF)＝０：伝票単位
                redSalesSlip.ConsTaxLayMethod = 0;
            }
            // --- ADD 譚洪 2014/01/07 ------------ <<<<<<

            // 伝票区分
            redSalesSlip.SalesSlipCd = parameter.SlipCd;
            // 伝票番号
            redSalesSlip.SalesSlipNum = string.Empty;
            // ---ADD BY 凌小青 on 2012/01/11 for Redmine#27932 ---->>>>>
            //得意先伝票番号
            redSalesSlip.CustSlipNo = 0;
            // ---ADD BY 凌小青 on 2012/01/11 for Redmine#27932 ----<<<<<
            // 明細行数 
            redSalesSlip.DetailRowCount = redSalesDetailList.Count;
            // --- UPD m.suzuki 2010/06/08 ---------->>>>>
            //// 入力担当者
            //redSalesSlip.InputAgenCd = parameter.InputEmployeeCd;
            //redSalesSlip.InputAgenNm = parameter.InputEmployeeNm;
            // 入力担当者 ← ログイン従業員
            redSalesSlip.InputAgenCd = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
            redSalesSlip.InputAgenNm = LoginInfoAcquisition.Employee.Name.Trim();
            // 発行者 ← 画面入力の発行者
            redSalesSlip.SalesInputCode = parameter.InputEmployeeCd;
            // -----UPD 2010/12/20----->>>>>
            //redSalesSlip.SalesInputName = parameter.InputEmployeeNm;
            if (parameter.InputEmployeeNm.Length > 16)
            {
                redSalesSlip.SalesInputName = parameter.InputEmployeeNm.Substring(0, 16);
            }
            else
            {
                redSalesSlip.SalesInputName = parameter.InputEmployeeNm;
            }
            // -----UPD 2010/12/20-----<<<<<
            // --- UPD m.suzuki 2010/06/08 ----------<<<<<

            // 売上日
            redSalesSlip.SalesDate = parameter.SalesDate;
            // 出荷日
            redSalesSlip.ShipmentDay = parameter.SalesDate;
            // 計上日
            redSalesSlip.AddUpADate = parameter.SalesDate;
            // 入力日
            redSalesSlip.SearchSlipDate = DateTime.Today;


            // 得意先注番
            //redSalesSlip.PartySaleSlipNum = parameter.PartySalesSlipNo.Trim(); // DEL 2013/03/18 zhaimm Redmine#34807
            redSalesSlip.PartySaleSlipNum = parameter.PartySalesSlipNo.TrimEnd(); // ADD 2013/03/18 zhaimm Redmine#34807
            // 備考１
            redSalesSlip.SlipNote = parameter.SlipNote.Trim();
            // 備考２
            redSalesSlip.SlipNote2 = parameter.SlipNote2.Trim();
            // 備考３
            redSalesSlip.SlipNote3 = parameter.SlipNote3.Trim();
            // 返品理由
            redSalesSlip.RetGoodsReason = parameter.ReturnReason.Trim();
            // --- ADD 2009/11/25 ---------->>>>>
            // 返品理由コード
            redSalesSlip.RetGoodsReasonDiv = parameter.RetGoodsReasonDiv;
            // --- DEL m.suzuki 2010/10/07 ---------->>>>>
            //// 赤伝区分
            //if (parameter.SlipCd == 0)
            //{
            //    // 1:赤伝
            //    redSalesSlip.DebitNoteDiv = 1;
            //}
            // --- DEL m.suzuki 2010/10/07 ----------<<<<<
            // --- ADD 2009/11/25 ----------<<<<<
            // 合計金額算出
            this.TotalPriceSetting( ref redSalesSlip, redSalesDetailList );

            // ---ADD 2009/02/10 不具合対応[11134] ---------------------------->>>>>
            //入金引当合計額
            redSalesSlip.DepositAllowanceTtl = 0;
            //入金引当残高
            redSalesSlip.DepositAlwcBlnce = redSalesSlip.SalesTotalTaxInc;
            // ---ADD 2009/02/10 不具合対応[11134] ----------------------------<<<<<

            # endregion
        }
        /// <summary>
        /// 登録用赤伝（明細）生成処理
        /// </summary>
        /// <param name="redSalesDetail"></param>
        /// <param name="redSalesSlip"></param>
        /// <param name="redSalesDetailList"></param>
        /// <param name="redRowView"></param>
        /// <param name="parameter"></param>
        /// <param name="addCarRelation"></param>
        /// <returns></returns>
        // UPD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // private SalesDetailWork CopyToRedSalesDetail(SalesDetailWork redSalesDetail, SalesSlipWork redSalesSlip, List<SalesDetailWork> redSalesDetailList, DataRowView redRowView, RedSlipWriteParameter parameter, out bool addCarRelation)
        private SalesDetailWork CopyToRedSalesDetail(SalesDetailWork redSalesDetail, SalesSlipWork redSalesSlip, List<SalesDetailWork> redSalesDetailList, DataRowView redRowView, RedSlipWriteParameter parameter, out bool addCarRelation, ref List<int[]> rowNoNewOld)
        // UPD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            // --- ADD m.suzuki 2010/08/10 ---------->>>>>
            // ※メモリ上の別実体に置き換える
            redSalesDetail = redSalesDetail.Clone();
            // --- ADD m.suzuki 2010/08/10 ----------<<<<<

            // ※redSalesDetailを書き換えて返す

            // 明細リレーションGUID
            redSalesDetail.DtlRelationGuid = Guid.NewGuid();

            # region [車両リレーション]
            if ( redSalesDetail.AcceptAnOrderNo != 0 )
            {
                Guid carRelationGuid;
                if ( _carRelationDic.ContainsKey( redSalesDetail.AcceptAnOrderNo ) )
                {
                    carRelationGuid = _carRelationDic[redSalesDetail.AcceptAnOrderNo];
                    addCarRelation = false;
                }
                else
                {
                    carRelationGuid = Guid.NewGuid();
                    _carRelationDic.Add( redSalesDetail.AcceptAnOrderNo, carRelationGuid );
                    addCarRelation = true;
                }
                _dtlCarRelationDic.Add( redSalesDetail.DtlRelationGuid, carRelationGuid );
            }
            else
            {
                addCarRelation = false;
            }
            # endregion

            # region [書き換え]
            // 共通ファイルヘッダ
            redSalesDetail.CreateDateTime = DateTime.MinValue; // 作成日時
            redSalesDetail.UpdateDateTime = DateTime.MinValue; // 更新日時
            redSalesDetail.EnterpriseCode = redSalesSlip.EnterpriseCode; // 企業コード
            redSalesDetail.FileHeaderGuid = Guid.Empty; // GUID
            redSalesDetail.UpdEmployeeCode = string.Empty; // 更新従業員コード
            redSalesDetail.UpdAssemblyId1 = string.Empty; // 更新アセンブリID1
            redSalesDetail.UpdAssemblyId2 = string.Empty; // 更新アセンブリID2
            redSalesDetail.LogicalDeleteCode = 0; // 論理削除区分

            // 伝票番号
            redSalesDetail.SalesSlipNum = string.Empty;

            // ADD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            rowNoNewOld.Add(new int[] { redSalesDetailList.Count + 1, redSalesDetail.SalesRowNo });
            // ADD 2013/11/01 吉岡 VSS[019] ｼｽﾃﾑﾃｽﾄ障害№18 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // 明細行番号
            redSalesDetail.SalesRowNo = redSalesDetailList.Count + 1;

            // 受注ステータス（元）
            redSalesDetail.AcptAnOdrStatusSrc = redSalesDetail.AcptAnOdrStatus;
            // 売上明細通番（元）
            redSalesDetail.SalesSlipDtlNumSrc = redSalesDetail.SalesSlipDtlNum;

            // 受注ステータス
            redSalesDetail.AcptAnOdrStatus = 30;
            // 売上明細通番
            redSalesDetail.SalesSlipDtlNum = 0;

            // 数量（-1×入力内容）
            redSalesDetail.ShipmentCnt = -1 * (double)redRowView[_detailDataSet.RedSlipDetail.ReturnCntColumn.ColumnName];

            // 倉庫コード
            //redSalesDetail.WarehouseCode = (string)redRowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName];// DEL BY wupf 2014/08/13 FOR Redmine＃43184 倉庫コードの障害解除
            // ADD BY wupf 2014/08/13 FOR Redmine＃43184 倉庫コードの障害解除---->>>>>
            if (redRowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName] == null
                || string.IsNullOrEmpty(redRowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName].ToString())
                || redRowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName].ToString() == "0")
            {
                redSalesDetail.WarehouseCode = "";
            }
            else
            {
                redRowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName] = redRowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName].ToString().PadLeft(4, '0');
                redSalesDetail.WarehouseCode = (string)redRowView[_detailDataSet.RedSlipDetail.WarehouseCodeColumn.ColumnName];
            }
            // ADD BY wupf 2014/08/13 FOR Redmine＃43184 倉庫コードの障害解除----<<<<<

            // 倉庫名称
            redSalesDetail.WarehouseName = (string)redRowView[_detailDataSet.RedSlipDetail.WarehouseNameColumn.ColumnName];
            //----------- UPD 2009/11/25 --------->>>>>
            // 返品時在庫登録区分(1:しない)
            //if (this.SalesTtlSt.RetGoodsStockEtyDiv == 1)// DEL 2010/01/29
            if (string.IsNullOrEmpty(redSalesDetail.WarehouseCode))// ADD 2010/01/29
            {
                // 棚番
                redSalesDetail.WarehouseShelfNo = string.Empty;
            }
            else
            {
                // 棚番
                redSalesDetail.WarehouseShelfNo = (string)redRowView[_detailDataSet.RedSlipDetail.ShelfNoColumn.ColumnName];
            }
            //----------- UPD 2009/11/25 ---------<<<<<
            // 在庫取寄区分
            if ( redSalesDetail.WarehouseCode.Trim() != string.Empty )
            {
                // 1:在庫
                redSalesDetail.SalesOrderDivCd = 1;
            }
            else
            {
                // 0:取寄
                redSalesDetail.SalesOrderDivCd = 0;
            }
            //----- DEL K2014/01/20 wangl2 Redmine#41497 --------------->>>>>
            #region DEL K2014/01/20 wangl2 Redmine#41497
            //// --------------- ADD START K2013/09/09 wangl2 FOR フタバ様改修------>>>>
            ////PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaWarehAlloc);   // DEL huangt K2013/10/15 Redmine#40626 No.96 オプション取得方式の変更
            //PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaWarehAlloc);         // ADD huangt K2013/10/15 Redmine#40626 No.96 オプション取得方式の変更
            //if (ps == PurchaseStatus.Contract)
            //{
            //    // 得意先マスタ
            //    CustomerInfo customer = new CustomerInfo();
            //    // 商品在庫マスタ
            //    Stock stock = new Stock();
            //    if (_customerInfoAcs == null)
            //        _customerInfoAcs = new CustomerInfoAcs();
            //    // 得意先マスタ取得
            //    int status = this._customerInfoAcs.ReadDBData(0, _enterpriseCode, redSalesSlip.CustomerCode, out  customer);
            //    // 得意先在庫ある場合
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        if (_stockMstAcs == null)
            //            _stockMstAcs = new StockMstAcs();
            //        ArrayList stockList = new ArrayList();
            //        ArrayList retStockList = new ArrayList(); // ADD huangt K2013/10/11 Redmine#40626 No.92 返品する倉庫の修正
            //        string retMessage;
            //        // 商品在庫検索
            //        //status = this._stockMstAcs.SearchStockInfo(_enterpriseCode, redSalesDetail.GoodsNo, redSalesDetail.GoodsMakerCd, out  stockList, out  retMessage);    // DEL huangt K2013/10/11 Redmine#40626 No.92 返品する倉庫の修正
            //        status = this._stockMstAcs.SearchStockInfo(_enterpriseCode, redSalesDetail.GoodsNo, redSalesDetail.GoodsMakerCd, out  retStockList, out  retMessage);   // ADD huangt K2013/10/11 Redmine#40626 No.92 返品する倉庫の修正
            //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //        {
            //            // --- ADD huangt K2013/10/11 Redmine#40626 No.92 返品する倉庫の修正 ----- >>>>>
            //            // 在庫有効データを取得する
            //            for (int index = 0; index < retStockList.Count; index++)
            //            {
            //                Stock retStock = retStockList[index] as Stock;

            //                if (retStock.LogicalDeleteCode == 0)
            //                {
            //                    stockList.Add(retStock);
            //                }
            //            }
            //            // --- ADD huangt K2013/10/11 Redmine#40626 No.92 返品する倉庫の修正 ----- <<<<<

            //            // 掛売上場合
            //            if (parameter.SlipCd == 0)
            //            {
            //                // 商品在庫ある場合
            //                if (stockList.Count > 0)
            //                {
            //                    foreach (Stock st in stockList)
            //                    {
            //                        // 倉庫コード
            //                        if (st.WarehouseCode == customer.CustWarehouseCd)
            //                        {
            //                            // 倉庫コード
            //                            redSalesDetail.WarehouseCode = customer.CustWarehouseCd;
            //                            // 倉庫名称
            //                            redSalesDetail.WarehouseName = customer.CustWarehouseName;
            //                            // 棚番
            //                            redSalesDetail.WarehouseShelfNo = st.WarehouseShelfNo;
            //                            // 在庫取寄区分「在庫」
            //                            redSalesDetail.SalesOrderDivCd = 1;
            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //             // 掛返品
            //            else if (parameter.SlipCd == 1)
            //            {
            //                //返品時在庫登録区分(1:しない)or （返品時在庫登録区分(0:する) and 画面の在庫取寄区分は「在庫」）
            //                if ((this.SalesTtlSt.RetGoodsStockEtyDiv == 1) || (this.SalesTtlSt.RetGoodsStockEtyDiv == 0 && redSalesDetail.SalesOrderDivCd == 1))
            //                {
            //                    // 商品在庫ある場合
            //                    if (stockList.Count > 0)
            //                    {
            //                        foreach (Stock st in stockList)
            //                        {
            //                            // 倉庫コード
            //                            if (st.WarehouseCode == customer.CustWarehouseCd)
            //                            {
            //                                // 倉庫コード
            //                                redSalesDetail.WarehouseCode = customer.CustWarehouseCd;
            //                                // 倉庫名称
            //                                redSalesDetail.WarehouseName = customer.CustWarehouseName;
            //                                // 棚番
            //                                redSalesDetail.WarehouseShelfNo = st.WarehouseShelfNo;
            //                                // 在庫取寄区分「在庫」
            //                                redSalesDetail.SalesOrderDivCd = 1;
            //                                break;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                // なし
            //            }
            //        }
            //    }
            //}
            //// --------------- ADD END K2013/09/09 wangl2 FOR フタバ様改修--------<<<<
            #endregion
            //----- DEL K2014/01/20 wangl2 Redmine#41497 ---------------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
            redSalesDetail.SalesUnitCost = (double)redRowView[_detailDataSet.RedSlipDetail.SalesUnitCostColumn.ColumnName];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD

            // 原価金額再計算
            long cost;
            this.CalculationCost( redSalesSlip, redSalesDetail, out cost );
            redSalesDetail.Cost = cost;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
            double salesUnPrc = (double)redRowView[_detailDataSet.RedSlipDetail.SalesUnPrcTaxExcFlColumn.ColumnName];
            double salesUnPrcTaxExc;
            double salesUnPrcTaxInc;
            // 単価算出
            CalcTaxExcAndTaxIncForSales( redSalesDetail.TaxationDivCd, redSalesSlip.CustomerCode, redSalesSlip.ConsTaxRate, redSalesSlip.TotalAmountDispWayCd, salesUnPrc, out salesUnPrcTaxExc, out salesUnPrcTaxInc );
            redSalesDetail.SalesUnPrcTaxExcFl = salesUnPrcTaxExc;
            redSalesDetail.SalesUnPrcTaxIncFl = salesUnPrcTaxInc;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD

            //--------- UPD 2009/11/25 --------->>>>>
            redSalesDetail.SalesMoneyTaxExc = (long)redRowView[_detailDataSet.RedSlipDetail.SalesMoneyTaxExcColumn.ColumnName];// 金額
            //--------- UPD 2009/11/25 ---------<<<<<
            // 売上金額再計算
            long salesMoneyTaxExc;
            long salesMoneyTaxInc;
            long salesMoneyDisplay;
            int fractionProcCd;
            // ------------UPD 2009/11/25 ----------->>>>>
            // 売上金額手入力
            this.SalesDetailRowSalesGoodsCdSetting(redSalesSlip, ref redSalesDetail);
            this.CalculationSalesMoney(redSalesSlip, redSalesDetail, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay, out fractionProcCd);
            redSalesDetail.SalesMoneyTaxExc = salesMoneyTaxExc;
            redSalesDetail.SalesMoneyTaxInc = salesMoneyTaxInc;
            redSalesDetail.SalesPriceConsTax = salesMoneyTaxInc - salesMoneyTaxExc;
            // ------------UPD 2009/11/25 -----------<<<<<
            //// 受注番号
            //redSalesDetail.AcceptAnOrderNo = 0;

            //仕入明細通番（同時）
            redSalesDetail.StockSlipDtlNumSync = 0;
            //仕入形式（同時）
            //redSalesDetail.SupplierFormalSync = 0;// DEL 2014/08/26 鄧潘ハン SCM仕掛一覧 №10650の①
            redSalesDetail.SupplierFormalSync = -1; // ADD 2014/08/26 鄧潘ハン SCM仕掛一覧 №10650の①

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
            // 共通通番
            redSalesDetail.CommonSeqNo = 0;

            // 伝票区分(明細)
            //-----ADD 2010/12/20 ----->>>>>
            //redSalesDetail.SalesSlipCdDtl = parameter.SlipCd;
            if (redSalesDetail.SalesSlipCdDtl != (int)SalesSlipCdDtl.Discount)
            {
                redSalesDetail.SalesSlipCdDtl = parameter.SlipCd;
            }
            //-----ADD 2010/12/20 -----<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

            // -- ADD 2009/08/07 ---------------------->>>
            //伝票情報から売上日付をセット
            redSalesDetail.SalesDate = parameter.SalesDate;
            // -- ADD 2009/08/07 ----------------------<<<

            // ---------- ADD 2013/06/25 Y.Wakita ---------->>>>>
            //問合せ番号
            redSalesDetail.InquiryNumber = 0;
            //問合せ行番号
            redSalesDetail.InqRowNumber = 0;
            // ---------- ADD 2013/06/25 Y.Wakita ----------<<<<<

            # endregion

            return redSalesDetail;
        }
        /// <summary>
        /// 登録用赤伝　手数料明細追加処理
        /// </summary>
        /// <param name="redSalesDetailList"></param>
        /// <param name="parameter"></param>
        private void AddFeeDetail( ref List<SalesDetailWork> redSalesDetailList, SalesSlipWork redSalesSlip, RedSlipWriteParameter parameter )
        {
            // 手数料額未入力ならば終了
            if ( parameter.FeePriceOfTotal == 0 ) return;

            # region [データ準備]
            // 品名
            const string feeName = "返品手数料額";

            // 課税区分・税抜金額・税込金額
            int taxationDivCd = 0;
            long salesMoneyTaxExc;
            long salesMoneyTaxInc;
            long salesPriceConsTax;
            this.CalculateSalesMoneyForFee( redSalesSlip, parameter.FeePriceOfTotal, out taxationDivCd, out salesMoneyTaxExc, out salesMoneyTaxInc, out salesPriceConsTax );
            # endregion

            SalesDetailWork feeDetail = new SalesDetailWork();

            # region [手数料データ格納]
            feeDetail.CreateDateTime = DateTime.MinValue; // 作成日時
            feeDetail.UpdateDateTime = DateTime.MinValue; // 更新日時
            feeDetail.EnterpriseCode = parameter.EnterpriseCode; // 企業コード
            feeDetail.FileHeaderGuid = Guid.Empty; // GUID
            feeDetail.UpdEmployeeCode = string.Empty; // 更新従業員コード
            feeDetail.UpdAssemblyId1 = string.Empty; // 更新アセンブリID1
            feeDetail.UpdAssemblyId2 = string.Empty; // 更新アセンブリID2
            feeDetail.LogicalDeleteCode = 0; // 論理削除区分
            feeDetail.AcceptAnOrderNo = 0; // 受注番号
            feeDetail.AcptAnOdrStatus = 30; // 受注ステータス　←30:売上
            feeDetail.SalesSlipNum = string.Empty; // 売上伝票番号
            feeDetail.SalesRowNo = redSalesDetailList.Count + 1; // 売上行番号
            feeDetail.SalesRowDerivNo = 0; // 売上行番号枝番
            feeDetail.SectionCode = redSalesDetailList[0].SectionCode; // 拠点コード
            feeDetail.SubSectionCode = redSalesDetailList[0].SubSectionCode; // 部門コード
            feeDetail.SalesDate = parameter.SalesDate; // 売上日付
            feeDetail.CommonSeqNo = 0; // 共通通番
            feeDetail.SalesSlipDtlNum = 0; // 売上明細通番
            feeDetail.AcptAnOdrStatusSrc = 0; // 受注ステータス（元）
            feeDetail.SalesSlipDtlNumSrc = 0; // 売上明細通番（元）
            //feeDetail.SupplierFormalSync = 0; // 仕入形式（同時）// DEL 2014/08/26 鄧潘ハン SCM仕掛一覧 №10650の①
            feeDetail.SupplierFormalSync = -1; // 仕入形式（同時） // ADD 2014/08/26 鄧潘ハン SCM仕掛一覧 №10650の①
            feeDetail.StockSlipDtlNumSync = 0; // 仕入明細通番（同時）
            feeDetail.SalesSlipCdDtl = (int)SalesSlipCdDtl.Discount; // 売上伝票区分（明細）　←2:値引
            feeDetail.DeliGdsCmpltDueDate = DateTime.MinValue; // 納品完了予定日
            feeDetail.GoodsKindCode = 0; // 商品属性
            feeDetail.GoodsSearchDivCd = 2; // 商品検索区分　←2:手入力
            feeDetail.GoodsMakerCd = 0; // 商品メーカーコード
            feeDetail.MakerName = string.Empty; // メーカー名称
            feeDetail.MakerKanaName = string.Empty; // メーカーカナ名称
            feeDetail.GoodsNo = string.Empty; // 商品番号
            feeDetail.GoodsName = feeName; // 商品名称　←「手数料」
            feeDetail.GoodsNameKana = feeName; // 商品名称カナ　←「手数料」
            feeDetail.GoodsLGroup = 0; // 商品大分類コード
            feeDetail.GoodsLGroupName = string.Empty; // 商品大分類名称
            feeDetail.GoodsMGroup = 0; // 商品中分類コード
            feeDetail.GoodsMGroupName = string.Empty; // 商品中分類名称
            feeDetail.BLGroupCode = 0; // BLグループコード
            feeDetail.BLGroupName = string.Empty; // BLグループコード名称
            feeDetail.BLGoodsCode = 0; // BL商品コード
            feeDetail.BLGoodsFullName = string.Empty; // BL商品コード名称（全角）
            feeDetail.EnterpriseGanreCode = 0; // 自社分類コード
            feeDetail.EnterpriseGanreName = string.Empty; // 自社分類名称
            feeDetail.WarehouseCode = string.Empty; // 倉庫コード
            feeDetail.WarehouseName = string.Empty; // 倉庫名称
            feeDetail.WarehouseShelfNo = string.Empty; // 倉庫棚番
            feeDetail.SalesOrderDivCd = 0; // 売上在庫取寄せ区分
            feeDetail.OpenPriceDiv = 0; // オープン価格区分
            feeDetail.GoodsRateRank = string.Empty; // 商品掛率ランク
            feeDetail.CustRateGrpCode = 0; // 得意先掛率グループコード
            feeDetail.ListPriceRate = 0; // 定価率
            feeDetail.RateSectPriceUnPrc = string.Empty; // 掛率設定拠点（定価）
            feeDetail.RateDivLPrice = string.Empty; // 掛率設定区分（定価）
            feeDetail.UnPrcCalcCdLPrice = 0; // 単価算出区分（定価）
            feeDetail.PriceCdLPrice = 0; // 価格区分（定価）
            feeDetail.StdUnPrcLPrice = 0; // 基準単価（定価）
            feeDetail.FracProcUnitLPrice = 0; // 端数処理単位（定価）
            feeDetail.FracProcLPrice = 0; // 端数処理（定価）
            feeDetail.ListPriceTaxIncFl = 0; // 定価（税込，浮動）
            feeDetail.ListPriceTaxExcFl = 0; // 定価（税抜，浮動）
            feeDetail.ListPriceChngCd = 0; // 定価変更区分
            feeDetail.SalesRate = 0; // 売価率
            feeDetail.RateSectSalUnPrc = string.Empty; // 掛率設定拠点（売上単価）
            feeDetail.RateDivSalUnPrc = string.Empty; // 掛率設定区分（売上単価）
            feeDetail.UnPrcCalcCdSalUnPrc = 0; // 単価算出区分（売上単価）
            feeDetail.PriceCdSalUnPrc = 0; // 価格区分（売上単価）
            feeDetail.StdUnPrcSalUnPrc = 0; // 基準単価（売上単価）
            feeDetail.FracProcUnitSalUnPrc = 0; // 端数処理単位（売上単価）
            feeDetail.FracProcSalUnPrc = 0; // 端数処理（売上単価）
            feeDetail.SalesUnPrcTaxIncFl = 0; // 売上単価（税込，浮動）
            feeDetail.SalesUnPrcTaxExcFl = 0; // 売上単価（税抜，浮動）
            feeDetail.SalesUnPrcChngCd = 0; // 売上単価変更区分
            feeDetail.CostRate = 0; // 原価率
            feeDetail.RateSectCstUnPrc = string.Empty; // 掛率設定拠点（原価単価）
            feeDetail.RateDivUnCst = string.Empty; // 掛率設定区分（原価単価）
            feeDetail.UnPrcCalcCdUnCst = 0; // 単価算出区分（原価単価）
            feeDetail.PriceCdUnCst = 0; // 価格区分（原価単価）
            feeDetail.StdUnPrcUnCst = 0; // 基準単価（原価単価）
            feeDetail.FracProcUnitUnCst = 0; // 端数処理単位（原価単価）
            feeDetail.FracProcUnCst = 0; // 端数処理（原価単価）
            feeDetail.SalesUnitCost = 0; // 原価単価
            feeDetail.SalesUnitCostChngDiv = 0; // 原価単価変更区分
            feeDetail.RateBLGoodsCode = 0; // BL商品コード（掛率）
            feeDetail.RateBLGoodsName = string.Empty; // BL商品コード名称（掛率）
            feeDetail.RateGoodsRateGrpCd = 0; // 商品掛率グループコード（掛率）
            feeDetail.RateGoodsRateGrpNm = string.Empty; // 商品掛率グループ名称（掛率）
            feeDetail.RateBLGroupCode = 0; // BLグループコード（掛率）
            feeDetail.RateBLGroupName = string.Empty; // BLグループ名称（掛率）
            feeDetail.PrtBLGoodsCode = 0; // BL商品コード（印刷）
            feeDetail.PrtBLGoodsName = string.Empty; // BL商品コード名称（印刷）
            //feeDetail.SalesCode = 0; // 販売区分コード  // DEL 2012/03/29 gezh Redmine#29149
            feeDetail.SalesCode = parameter.SalesCodeDiv;  // 販売区分コード // ADD 2012/03/29 gezh Redmine#29149
            feeDetail.SalesCdNm = string.Empty; // 販売区分名称
            feeDetail.WorkManHour = 0; // 作業工数
            feeDetail.ShipmentCnt = 0; // 出荷数
            feeDetail.AcceptAnOrderCnt = 0; // 受注数量
            feeDetail.AcptAnOdrAdjustCnt = 0; // 受注調整数
            feeDetail.AcptAnOdrRemainCnt = 0; // 受注残数
            feeDetail.RemainCntUpdDate = DateTime.MinValue; // 残数更新日
            feeDetail.SalesMoneyTaxInc = salesMoneyTaxInc; // 売上金額（税込み）　←手数料額
            feeDetail.SalesMoneyTaxExc = salesMoneyTaxExc; // 売上金額（税抜き）　←手数料額
            feeDetail.Cost = 0; // 原価
            feeDetail.GrsProfitChkDiv = 0; // 粗利チェック区分
            feeDetail.SalesGoodsCd = 0; // 売上商品区分
            feeDetail.SalesPriceConsTax = salesPriceConsTax; // 売上金額消費税額
            feeDetail.TaxationDivCd = taxationDivCd; // 課税区分
            feeDetail.PartySlipNumDtl = string.Empty; // 相手先伝票番号（明細）
            feeDetail.DtlNote = string.Empty; // 明細備考
            feeDetail.SupplierCd = 0; // 仕入先コード
            feeDetail.SupplierSnm = string.Empty; // 仕入先略称
            feeDetail.OrderNumber = string.Empty; // 発注番号
            feeDetail.WayToOrder = 0; // 注文方法
            feeDetail.SlipMemo1 = string.Empty; // 伝票メモ１
            feeDetail.SlipMemo2 = string.Empty; // 伝票メモ２
            feeDetail.SlipMemo3 = string.Empty; // 伝票メモ３
            feeDetail.InsideMemo1 = string.Empty; // 社内メモ１
            feeDetail.InsideMemo2 = string.Empty; // 社内メモ２
            feeDetail.InsideMemo3 = string.Empty; // 社内メモ３
            feeDetail.BfListPrice = 0; // 変更前定価
            feeDetail.BfSalesUnitPrice = 0; // 変更前売価
            feeDetail.BfUnitCost = 0; // 変更前原価
            feeDetail.CmpltSalesRowNo = 0; // 一式明細番号
            feeDetail.CmpltGoodsMakerCd = 0; // メーカーコード（一式）
            feeDetail.CmpltMakerName = string.Empty; // メーカー名称（一式）
            feeDetail.CmpltMakerKanaName = string.Empty; // メーカーカナ名称（一式）
            feeDetail.CmpltGoodsName = string.Empty; // 商品名称（一式）
            feeDetail.CmpltShipmentCnt = 0; // 数量（一式）
            feeDetail.CmpltSalesUnPrcFl = 0; // 売上単価（一式）
            feeDetail.CmpltSalesMoney = 0; // 売上金額（一式）
            feeDetail.CmpltSalesUnitCost = 0; // 原価単価（一式）
            feeDetail.CmpltCost = 0; // 原価金額（一式）
            feeDetail.CmpltPartySalSlNum = string.Empty; // 相手先伝票番号（一式）
            feeDetail.CmpltNote = string.Empty; // 一式備考
            feeDetail.PrtGoodsNo = string.Empty; // 印刷用品番
            feeDetail.PrtMakerCode = 0; // 印刷用メーカーコード
            feeDetail.PrtMakerName = string.Empty; // 印刷用メーカー名称
            # endregion

            redSalesDetailList.Add( feeDetail );
            
        }
        /// <summary>
        /// 手数料金額算出処理
        /// </summary>
        /// <param name="redSalesSlip"></param>
        /// <param name="salesMoneyDisplay"></param>
        /// <param name="taxationDivCd"></param>
        /// <param name="salesMoneyTaxExc"></param>
        /// <param name="salesMoneyTaxInc"></param>
        /// <param name="salesPriceConsTax"></param>
        private void CalculateSalesMoneyForFee( SalesSlipWork redSalesSlip, long salesMoneyDisplay, out int taxationDivCd, out long salesMoneyTaxExc, out long salesMoneyTaxInc, out long salesPriceConsTax )
        {
            // 金額処理コード取得
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd( this._enterpriseCode, redSalesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd );
            
            // 税端数処理区分コード・単位取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //this.GetFractionProcInfo( SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            this.GetSalesFractionProcInfo( ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD

            // 非課税
            if ( redSalesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt )
            {
                salesMoneyTaxExc = salesMoneyDisplay;
                salesMoneyTaxInc = salesMoneyDisplay;
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // 総額表示しない
            else if ( redSalesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount )
            {
                salesMoneyTaxExc = salesMoneyDisplay;
                salesMoneyTaxInc = salesMoneyDisplay + CalculateTax.GetTaxFromPriceExc( redSalesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoneyDisplay );
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxExc;
            }
            // 総額表示する
            else
            {
                salesMoneyTaxExc = salesMoneyDisplay - CalculateTax.GetTaxFromPriceInc( redSalesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoneyDisplay );
                salesMoneyTaxInc = salesMoneyDisplay;
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxInc;
            }

            salesPriceConsTax = (long)((decimal)salesMoneyTaxInc - (decimal)salesMoneyTaxExc);
        }
        # endregion

        # region [登録用赤伝車輌情報取得]
        /// <summary>
        /// 車両情報キャッシュ（受注マスタ（車両）からキャッシュ）
        /// </summary>
        /// <param name="baseSalesSlip">処理元売上データオブジェクト</param>
        /// <param name="salesDetail">売上明細データオブジェクト</param>
        /// <param name="acceptOdrCar">受注マスタ（車両）オブジェクト</param>
        private void CacheCarInfo( AcceptOdrCarWork acceptOdrCar )
        {
            if ( acceptOdrCar == null ) return;
            SalesInputDataSet.CarInfoRow carInfoRow = this.GetCarInfoRow( acceptOdrCar );
            if ( carInfoRow == null ) return;

            // 車両再検索
            PMKEN01010E carInfoDataset = new PMKEN01010E();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //CarSearchResultReport result = this.SearchCar( acceptOdrCar.FullModelFixedNoAry, acceptOdrCar.ModelDesignationNo, acceptOdrCar.CategoryNo, ref carInfoDataset );

            CarSearchCondition carSearchCond = new CarSearchCondition();
            carSearchCond.CarModel.FullModel = acceptOdrCar.FullModel;
            carSearchCond.MakerCode = acceptOdrCar.MakerCode;
            carSearchCond.ModelCode = acceptOdrCar.ModelCode;
            carSearchCond.ModelSubCode = acceptOdrCar.ModelSubCode;

            CarSearchResultReport result = this.SearchCar( acceptOdrCar.FullModelFixedNoAry, carSearchCond, ref carInfoDataset );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
            if ( (result != CarSearchResultReport.retError) && (result != CarSearchResultReport.retFailed) )
            {
                this.CacheCarInfo( ref carInfoRow, carInfoDataset );
            }

            carInfoRow.CarMngNo = acceptOdrCar.CarMngNo; // 車両管理番号
            carInfoRow.CarMngCode = acceptOdrCar.CarMngCode; // 車輌管理コード
            carInfoRow.NumberPlate1Code = acceptOdrCar.NumberPlate1Code; // 陸運事務所番号
            carInfoRow.NumberPlate1Name = acceptOdrCar.NumberPlate1Name; // 陸運事務局名称
            carInfoRow.NumberPlate2 = acceptOdrCar.NumberPlate2; // 車両登録番号（種別）
            carInfoRow.NumberPlate3 = acceptOdrCar.NumberPlate3; // 車両登録番号（カナ）
            carInfoRow.NumberPlate4 = acceptOdrCar.NumberPlate4; // 車両登録番号（プレート番号）
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 DEL
            //carInfoRow.ProduceTypeOfYearInput = 0; // 初年度
            //if ( acceptOdrCar.FirstEntryDate != DateTime.MinValue )
            //{
            //    int iyy = acceptOdrCar.FirstEntryDate.Year * 100;
            //    int imm = acceptOdrCar.FirstEntryDate.Month;
            //    carInfoRow.ProduceTypeOfYearInput = iyy + imm; // 初年度
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
            carInfoRow.ProduceTypeOfYearInput = acceptOdrCar.FirstEntryDate; // 初年度
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD
            carInfoRow.MakerCode = acceptOdrCar.MakerCode; // メーカーコード
            carInfoRow.MakerFullName = acceptOdrCar.MakerFullName; // メーカー全角名称
            carInfoRow.MakerHalfName = acceptOdrCar.MakerHalfName; // メーカー半角名称
            carInfoRow.ModelCode = acceptOdrCar.ModelCode; // 車種コード
            carInfoRow.ModelSubCode = acceptOdrCar.ModelSubCode; // 車種サブコード
            carInfoRow.ModelFullName = acceptOdrCar.ModelFullName; // 車種全角名称
            carInfoRow.ModelHalfName = acceptOdrCar.ModelHalfName; // 車種半角名称
            carInfoRow.ExhaustGasSign = acceptOdrCar.ExhaustGasSign; // 排ガス記号
            carInfoRow.SeriesModel = acceptOdrCar.SeriesModel; // シリーズ型式
            carInfoRow.CategorySignModel = acceptOdrCar.CategorySignModel; // 型式（類別記号）
            carInfoRow.FullModel = acceptOdrCar.FullModel; // 型式（フル型）
            carInfoRow.ModelDesignationNo = acceptOdrCar.ModelDesignationNo; // 型式指定番号
            carInfoRow.CategoryNo = acceptOdrCar.CategoryNo; // 類別番号
            carInfoRow.FrameModel = acceptOdrCar.FrameModel; // 車台型式
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
            //carInfoRow.ProduceFrameNoInput = TStrConv.StrToIntDef( acceptOdrCar.FrameNo, 0 ); // 車台番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
            carInfoRow.FrameNo = acceptOdrCar.FrameNo; // 車台番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD
            carInfoRow.SearchFrameNo = acceptOdrCar.SearchFrameNo; // 車台番号（検索用）
            carInfoRow.EngineModelNm = acceptOdrCar.EngineModelNm; // エンジン型式名称
            carInfoRow.RelevanceModel = acceptOdrCar.RelevanceModel; // 関連型式
            carInfoRow.SubCarNmCd = acceptOdrCar.SubCarNmCd; // サブ車名コード
            carInfoRow.ModelGradeSname = acceptOdrCar.ModelGradeSname; // 型式グレード略称
            carInfoRow.Mileage = acceptOdrCar.Mileage; // 車両走行距離
            carInfoRow.FullModelFixedNoAry = acceptOdrCar.FullModelFixedNoAry; // フル型式固定番号配列
            carInfoRow.ColorCode = acceptOdrCar.ColorCode; // カラーコード
            carInfoRow.ColorName1 = acceptOdrCar.ColorName1; // カラー名称
            carInfoRow.TrimCode = acceptOdrCar.TrimCode; // トリムコード
            carInfoRow.TrimName = acceptOdrCar.TrimName; // トリム名称
            // --- ADD 2009/09/07 ---------->>>>>
            carInfoRow.CarNote = acceptOdrCar.CarNote; // 車輌備考
            // --- ADD 2009/09/07 ----------<<<<<
            // --- ADD 2013/03/25 ---------->>>>>
            carInfoRow.DomesticForeignCode = acceptOdrCar.DomesticForeignCode; // 国産/外車区分
            // --- ADD 2013/03/25 ----------<<<<<

            carInfoRow.AcceptAnOrderNo = acceptOdrCar.AcceptAnOrderNo; // 受注番号
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
            this.SelectEquipInfo( carInfoRow.CarRelationGuid, acceptOdrCar.CategoryObjAry ); // 装備オブジェクト配列
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
        /// <summary>
        /// 装備情報選択処理
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <param name="categoryObjAry">装備情報配列</param>
        private void SelectEquipInfo( Guid carRelationGuid, byte[] categoryObjAry )
        {
            if ( (this._cEqpDspInfoDic.ContainsKey( carRelationGuid )) && (categoryObjAry != null) )
            {
                PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
                if ( categoryObjAry.Length > 0 )
                {
                    // 指定の装備を選択状態にする
                    eqpDspInfoDataTable.SetTableFromByteArray( categoryObjAry );
                }
                else
                {
                    // 全て解除
                    foreach ( PMKEN01010E.CEqpDefDspInfoRow row in eqpDspInfoDataTable.Rows )
                    {
                        row.SelectionState = false;
                    }
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
        ///// <summary>
        ///// 車両検索(フル型式固定番号より検索)
        ///// </summary>
        ///// <param name="fullModelFixedNo">フル型式固定番号配列</param>
        ///// <param name="modelDesignationNo">型式指定番号(未設定可)</param>
        ///// <param name="categoryNo">類別区分番号(未設定可)</param>
        ///// <param name="carInfoDataSet">車両検索データセット</param>
        ///// <returns>CarSearchResultReport</returns>
        ///// <remarks>型式指定番号および類別区分番号は、類別検索によるフル型式固定番号配列の場合のみ必須</remarks>
        //public CarSearchResultReport SearchCar( int[] fullModelFixedNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E carInfoDataSet )
        //{
        //    CarSearchResultReport ret = CarSearchResultReport.retFailed;
        //    if ( fullModelFixedNo.Length != 0 )
        //    {
        //        ret = this._carSearchController.SearchByFullModelFixedNo( fullModelFixedNo, modelDesignationNo, categoryNo, ref carInfoDataSet );
        //    }
        //    return ret;
        //}

        /// <summary>
        /// 車両検索(フル型式固定番号より検索)
        /// </summary>
        /// <param name="fullModelFixedNo">フル型式固定番号配列</param>
        /// <param name="carSearchCond">車輌検索条件クラス</param>
        /// <param name="carInfoDataSet">車両検索データセット</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>型式指定番号および類別区分番号は、類別検索によるフル型式固定番号配列の場合のみ必須</remarks>
        public CarSearchResultReport SearchCar( int[] fullModelFixedNo, CarSearchCondition carSearchCond, ref PMKEN01010E carInfoDataSet )
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            if ( fullModelFixedNo.Length != 0 )
            {
                ret = this._carSearchController.SearchByFullModelFixedNo( fullModelFixedNo, carSearchCond, ref carInfoDataSet );
            }
            return ret;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD        /// <summary>
        /// 対象行の車両情報行オブジェクトを取得
        /// </summary>
        /// <returns>車両情報行オブジェクト</returns>
        public SalesInputDataSet.CarInfoRow GetCarInfoRow(AcceptOdrCarWork acceptOdrCar)
        {
            if ( acceptOdrCar == null ) return null;
            if ( !_carRelationDic.ContainsKey( acceptOdrCar.AcceptAnOrderNo ) )return null;


            // 車両情報共通キー取得
            Guid carRelationGuid = _carRelationDic[acceptOdrCar.AcceptAnOrderNo];

            // 車両情報データ行オブジェクト生成
            SalesInputDataSet.CarInfoRow carInfoRow = this._carInfoDataTable.NewCarInfoRow();
            this.ClearCarInfoRow( ref carInfoRow );

            // キーセット
            carInfoRow.CarRelationGuid = carRelationGuid;
            carInfoRow.FullModelFixedNoAry = new Int32[0];
            this._carInfoDataTable.AddCarInfoRow( carInfoRow );

            return carInfoRow;
        }
        /// <summary>
        /// 車両情報テーブルのクリア
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        public void ClearCarInfoRow( ref SalesInputDataSet.CarInfoRow carInfoRow )
        {
            if ( carInfoRow == null ) return;

            //carInfoRow.CarRelationGuid = Guid.Empty;            // 車両情報共通キー
            carInfoRow.CustomerCode = 0;                        // 得意先コード
            carInfoRow.CarMngNo = 0;                            // 車両管理番号
            carInfoRow.CarMngCode = string.Empty;               // 車輌管理コード
            carInfoRow.NumberPlate1Code = 0;                    // 陸運事務所番号
            carInfoRow.NumberPlate1Name = string.Empty;         // 陸運事務局名称
            carInfoRow.NumberPlate2 = string.Empty;             // 車両登録番号（種別）
            carInfoRow.NumberPlate3 = string.Empty;             // 車両登録番号（カナ）
            carInfoRow.NumberPlate4 = 0;                        // 車両登録番号（プレート番号）
            carInfoRow.EntryDate = DateTime.MinValue;           // 登録年月日
            //carInfoRow.FirstEntryDate = DateTime.MinValue;      // 初年度
            carInfoRow.FirstEntryDate = 0;
            carInfoRow.MakerCode = 0;                           // メーカーコード
            carInfoRow.MakerFullName = string.Empty;            // メーカー全角名称
            carInfoRow.ModelCode = 0;                           // 車種コード
            carInfoRow.ModelSubCode = 0;                        // 車種サブコード
            carInfoRow.ModelFullName = string.Empty;            // 車種全角名称
            carInfoRow.SystematicCode = 0;                      // 系統コード
            carInfoRow.SystematicName = string.Empty;           // 系統名称
            carInfoRow.ProduceTypeOfYearCd = 0;                 // 生産年式コード
            carInfoRow.ProduceTypeOfYearNm = string.Empty;      // 生産年式名称
            carInfoRow.StProduceTypeOfYear = DateTime.MinValue; // 開始生産年式
            carInfoRow.EdProduceTypeOfYear = DateTime.MinValue; // 終了生産年式
            carInfoRow.DoorCount = 0;                           // ドア数
            carInfoRow.BodyNameCode = 0;                        // ボディー名コード
            carInfoRow.BodyName = string.Empty;                 // ボディー名称
            carInfoRow.ExhaustGasSign = string.Empty;           // 排ガス記号
            carInfoRow.SeriesModel = string.Empty;              // シリーズ型式
            carInfoRow.CategorySignModel = string.Empty;        // 型式（類別記号）
            carInfoRow.FullModel = string.Empty;                // 型式（フル型）
            carInfoRow.ModelDesignationNo = 0;                  // 型式指定番号
            carInfoRow.CategoryNo = 0;                          // 類別番号
            carInfoRow.FrameModel = string.Empty;               // 車台型式
            carInfoRow.FrameNo = string.Empty;                  // 車台番号
            carInfoRow.SearchFrameNo = 0;                       // 車台番号（検索用）
            carInfoRow.StProduceFrameNo = 0;                    // 生産車台番号開始
            carInfoRow.EdProduceFrameNo = 0;                    // 生産車台番号終了
            carInfoRow.ModelGradeNm = string.Empty;             // 型式グレード名称
            carInfoRow.EngineModelNm = string.Empty;            // エンジン型式名称
            carInfoRow.EngineDisplaceNm = string.Empty;         // 排気量名称
            carInfoRow.EDivNm = string.Empty;                   // E区分名称
            carInfoRow.TransmissionNm = string.Empty;           // ミッション名称
            carInfoRow.ShiftNm = string.Empty;                  // シフト名称
            carInfoRow.WheelDriveMethodNm = string.Empty;       // 駆動方式名称
            carInfoRow.AddiCarSpec1 = string.Empty;             // 追加諸元1
            carInfoRow.AddiCarSpec2 = string.Empty;             // 追加諸元2
            carInfoRow.AddiCarSpec3 = string.Empty;             // 追加諸元3
            carInfoRow.AddiCarSpec4 = string.Empty;             // 追加諸元4
            carInfoRow.AddiCarSpec5 = string.Empty;             // 追加諸元5
            carInfoRow.AddiCarSpec6 = string.Empty;             // 追加諸元6
            carInfoRow.AddiCarSpecTitle1 = string.Empty;        // 追加諸元タイトル1
            carInfoRow.AddiCarSpecTitle2 = string.Empty;        // 追加諸元タイトル2
            carInfoRow.AddiCarSpecTitle3 = string.Empty;        // 追加諸元タイトル3
            carInfoRow.AddiCarSpecTitle4 = string.Empty;        // 追加諸元タイトル4
            carInfoRow.AddiCarSpecTitle5 = string.Empty;        // 追加諸元タイトル5
            carInfoRow.AddiCarSpecTitle6 = string.Empty;        // 追加諸元タイトル6
            carInfoRow.RelevanceModel = string.Empty;           // 関連型式
            carInfoRow.SubCarNmCd = 0;                          // サブ車名コード
            carInfoRow.ModelGradeSname = string.Empty;          // 型式グレード略称
            carInfoRow.BlockIllustrationCd = 0;                 // ブロックイラストコード
            carInfoRow.ThreeDIllustNo = 0;                      // 3DイラストNo
            carInfoRow.PartsDataOfferFlag = 0;                  // 部品データ提供フラグ
            carInfoRow.InspectMaturityDate = DateTime.MinValue; // 車検満期日
            carInfoRow.LTimeCiMatDate = DateTime.MinValue;      // 前回車検満期日
            carInfoRow.CarInspectYear = 0;                      // 車検期間
            carInfoRow.Mileage = 0;                             // 車両走行距離
            carInfoRow.CarNo = string.Empty;                    // 号車
            carInfoRow.FullModelFixedNoAry = new Int32[0];      // フル型式固定番号配列
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
            //carInfoRow.ProduceFrameNoInput = 0;                 // 車台番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
            carInfoRow.FrameNo = string.Empty;                  // 車台番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD
            carInfoRow.ProduceTypeOfYearInput = 0;              // 年式
            carInfoRow.ColorCode = string.Empty;                // カラーコード
            carInfoRow.ColorName1 = string.Empty;               // カラー名称
            carInfoRow.TrimCode = string.Empty;                 // トリムコード
            carInfoRow.TrimName = string.Empty;                 // トリム名称
            carInfoRow.AcceptAnOrderNo = 0;                     // 受注番号
            // -------ADD 2009/09/07--------->>>>>
            carInfoRow.CarNote = string.Empty;                     // 受注番号
            carInfoRow.CarAddInfo1 = string.Empty;                     // 受注番号
            carInfoRow.CarAddInfo2 = string.Empty;                     // 受注番号
            // -------ADD 2009/09/07---------<<<<<
        }
        /// <summary>
        /// 車両情報キャッシュ（車両検索情報からキャッシュ）
        /// </summary>
        /// <param name="carInfoRow">車両情報行オブジェクト</param>
        /// <param name="salesDetailRow">売上明細行オブジェクト</param>
        /// <param name="searchCarInfo">車両検索結果クラス</param>
        private void CacheCarInfo( ref SalesInputDataSet.CarInfoRow carInfoRow, PMKEN01010E searchCarInfo )
        {
            PMKEN01010E.CarModelUIDataTable carModelUIDataTable = searchCarInfo.CarModelUIData; // ＵＩ用型式情報テーブル
            PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchCarInfo.CarModelInfoSummarized; // 型式情報要約テーブル

            //carInfoRow.CarRelationGuid = salesDetailRow.CarRelationGuid; // 車両情報共通キー
            //carInfoRow.CustomerCode = carModelInfoDataTable[0].CustomerCode; // 得意先コード
            //carInfoRow.CarMngNo = carModelInfoDataTable[0].CarMngNo; // 車両管理番号
            //carInfoRow.CarMngCode = carModelInfoDataTable[0].CarMngCode; // 車輌管理コード
            //carInfoRow.NumberPlate1Code = carModelInfoDataTable[0].NumberPlate1Code; // 陸運事務所番号
            //carInfoRow.NumberPlate1Name = carModelInfoDataTable[0].NumberPlate1Name; // 陸運事務局名称
            //carInfoRow.NumberPlate2 = carModelInfoDataTable[0].NumberPlate2; // 車両登録番号（種別）
            //carInfoRow.NumberPlate3 = carModelInfoDataTable[0].NumberPlate3; // 車両登録番号（カナ）
            //carInfoRow.NumberPlate4 = carModelInfoDataTable[0].NumberPlate4; // 車両登録番号（プレート番号）
            //carInfoRow.EntryDate = carModelInfoDataTable[0].EntryDate; // 登録年月日
            //carInfoRow.FirstEntryDate = carModelInfoDataTable[0].FirstEntryDate; // 初年度
            carInfoRow.MakerCode = carModelInfoDataTable[0].MakerCode; // メーカーコード
            carInfoRow.MakerFullName = carModelInfoDataTable[0].MakerFullName; // メーカー全角名称
            carInfoRow.MakerHalfName = carModelInfoDataTable[0].MakerHalfName; // メーカー半角名称
            carInfoRow.ModelCode = carModelInfoDataTable[0].ModelCode; // 車種コード
            carInfoRow.ModelSubCode = carModelInfoDataTable[0].ModelSubCode; // 車種サブコード
            carInfoRow.ModelFullName = carModelInfoDataTable[0].ModelFullName; // 車種全角名称
            carInfoRow.ModelHalfName = carModelInfoDataTable[0].ModelHalfName; // 車種半角名称
            carInfoRow.SystematicCode = carModelInfoDataTable[0].SystematicCode; // 系統コード
            carInfoRow.SystematicName = carModelInfoDataTable[0].SystematicName; // 系統名称
            carInfoRow.ProduceTypeOfYearCd = carModelInfoDataTable[0].ProduceTypeOfYearCd; // 生産年式コード
            carInfoRow.ProduceTypeOfYearNm = carModelInfoDataTable[0].ProduceTypeOfYearNm; // 生産年式名称
            DateTime sdt;
            DateTime edt;
            int iyy = carModelInfoDataTable[0].StProduceTypeOfYear / 100;
            int imm = carModelInfoDataTable[0].StProduceTypeOfYear % 100;
            if ( (iyy == 9999) || (imm == 99) )
            {
                sdt = DateTime.MinValue;
            }
            else
            {
                sdt = new DateTime( iyy, imm, 1 );
            }
            iyy = carModelInfoDataTable[0].EdProduceTypeOfYear / 100;
            imm = carModelInfoDataTable[0].EdProduceTypeOfYear % 100;
            if ( (iyy == 9999) || (imm == 99) )
            {
                edt = DateTime.MinValue;
            }
            else
            {
                edt = new DateTime( iyy, imm, 1 );
            }
            carInfoRow.StProduceTypeOfYear = sdt; // 開始生産年式
            carInfoRow.EdProduceTypeOfYear = edt; // 終了生産年式
            carInfoRow.ProduceTypeOfYearInput = carModelUIDataTable[0].ProduceTypeOfYearInput; // 生産年式入力
            carInfoRow.DoorCount = carModelInfoDataTable[0].DoorCount; // ドア数
            carInfoRow.BodyNameCode = carModelInfoDataTable[0].BodyNameCode; // ボディー名コード
            carInfoRow.BodyName = carModelInfoDataTable[0].BodyName; // ボディー名称
            carInfoRow.ExhaustGasSign = carModelInfoDataTable[0].ExhaustGasSign; // 排ガス記号
            carInfoRow.SeriesModel = carModelInfoDataTable[0].SeriesModel; // シリーズ型式
            carInfoRow.CategorySignModel = carModelInfoDataTable[0].CategorySignModel; // 型式（類別記号）
            carInfoRow.FullModel = carModelInfoDataTable[0].FullModel; // 型式（フル型）
            carInfoRow.ModelDesignationNo = carModelUIDataTable[0].ModelDesignationNo; // 型式指定番号
            carInfoRow.CategoryNo = carModelUIDataTable[0].CategoryNo; // 類別番号
            carInfoRow.FrameModel = carModelInfoDataTable[0].FrameModel; // 車台型式
            //carInfoRow.FrameNo = carModelInfoDataTable[0].FrameNo; // 車台番号
            //carInfoRow.SearchFrameNo = carModelInfoDataTable[0].SearchFrameNo; // 車台番号（検索用）
            carInfoRow.StProduceFrameNo = carModelInfoDataTable[0].StProduceFrameNo; // 生産車台番号開始
            carInfoRow.EdProduceFrameNo = carModelInfoDataTable[0].EdProduceFrameNo; // 生産車台番号終了
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
            //carInfoRow.ProduceFrameNoInput = carModelUIDataTable[0].ProduceFrameNoInput; // 生産車台番号入力
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
            carInfoRow.FrameNo = carModelUIDataTable[0].FrameNo; // 生産車台番号入力
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD
            carInfoRow.ModelGradeNm = carModelInfoDataTable[0].ModelGradeNm; // 型式グレード名称
            carInfoRow.EngineModelNm = carModelInfoDataTable[0].EngineModelNm; // エンジン型式名称
            carInfoRow.EngineDisplaceNm = carModelInfoDataTable[0].EngineDisplaceNm; // 排気量名称
            carInfoRow.EDivNm = carModelInfoDataTable[0].EDivNm; // E区分名称
            carInfoRow.TransmissionNm = carModelInfoDataTable[0].TransmissionNm; // ミッション名称
            carInfoRow.ShiftNm = carModelInfoDataTable[0].ShiftNm; // シフト名称
            carInfoRow.WheelDriveMethodNm = carModelInfoDataTable[0].WheelDriveMethodNm; // 駆動方式名称
            carInfoRow.AddiCarSpec1 = carModelInfoDataTable[0].AddiCarSpec1; // 追加諸元1
            carInfoRow.AddiCarSpec2 = carModelInfoDataTable[0].AddiCarSpec2; // 追加諸元2
            carInfoRow.AddiCarSpec3 = carModelInfoDataTable[0].AddiCarSpec3; // 追加諸元3
            carInfoRow.AddiCarSpec4 = carModelInfoDataTable[0].AddiCarSpec4; // 追加諸元4
            carInfoRow.AddiCarSpec5 = carModelInfoDataTable[0].AddiCarSpec5; // 追加諸元5
            carInfoRow.AddiCarSpec6 = carModelInfoDataTable[0].AddiCarSpec6; // 追加諸元6
            carInfoRow.AddiCarSpecTitle1 = carModelInfoDataTable[0].AddiCarSpecTitle1; // 追加諸元タイトル1
            carInfoRow.AddiCarSpecTitle2 = carModelInfoDataTable[0].AddiCarSpecTitle2; // 追加諸元タイトル2
            carInfoRow.AddiCarSpecTitle3 = carModelInfoDataTable[0].AddiCarSpecTitle3; // 追加諸元タイトル3
            carInfoRow.AddiCarSpecTitle4 = carModelInfoDataTable[0].AddiCarSpecTitle4; // 追加諸元タイトル4
            carInfoRow.AddiCarSpecTitle5 = carModelInfoDataTable[0].AddiCarSpecTitle5; // 追加諸元タイトル5
            carInfoRow.AddiCarSpecTitle6 = carModelInfoDataTable[0].AddiCarSpecTitle6; // 追加諸元タイトル6
            carInfoRow.RelevanceModel = carModelInfoDataTable[0].RelevanceModel; // 関連型式
            carInfoRow.SubCarNmCd = carModelInfoDataTable[0].SubCarNmCd; // サブ車名コード
            carInfoRow.ModelGradeSname = carModelInfoDataTable[0].ModelGradeSname; // 型式グレード略称
            carInfoRow.BlockIllustrationCd = carModelInfoDataTable[0].BlockIllustrationCd; // ブロックイラストコード
            carInfoRow.ThreeDIllustNo = carModelInfoDataTable[0].ThreeDIllustNo; // 3DイラストNo
            carInfoRow.PartsDataOfferFlag = carModelInfoDataTable[0].PartsDataOfferFlag; // 部品データ提供フラグ
            //carInfoRow.InspectMaturityDate = carModelInfoDataTable[0].InspectMaturityDate; // 車検満期日
            //carInfoRow.LTimeCiMatDate = carModelInfoDataTable[0].LTimeCiMatDate; // 前回車検満期日
            //carInfoRow.CarInspectYear = carModelInfoDataTable[0].CarInspectYear; // 車検期間
            //carInfoRow.Mileage = carModelInfoDataTable[0].Mileage; // 車両走行距離
            //carInfoRow.CarNo = carModelInfoDataTable[0].CarNo; // 号車

            carInfoRow.FullModelFixedNoAry = this._carSearchController.GetFullModelFixedNoArray( carModelInfoDataTable ); // フル型式固定番号配列

            //carInfoRow.ProduceFrameNoInput = carModelInfoDataTable[0].ProduceFrameNoInput; // 車台番号
            //carInfoRow.ProduceTypeOfYearInput = carModelInfoDataTable[0].ProduceTypeOfYearInput; // 年式
            //carInfoRow.ColorCode; // カラーコード
            //carInfoRow.ColorName1; // カラー名称
            //carInfoRow.TrimCode; // トリムコード
            //carInfoRow.TrimName; // トリム名称

            this.CacheColorInfo( carInfoRow.CarRelationGuid, searchCarInfo.ColorCdInfo );                         // カラー情報
            this.CacheTrimInfo( carInfoRow.CarRelationGuid, searchCarInfo.TrimCdInfo );                           // トリム情報
            this.CacheEquipInfo( carInfoRow.CarRelationGuid, searchCarInfo.CEqpDefDspInfo );                      // 装備情報

            // --- DEL m.suzuki 2010/10/07 ---------->>>>> // 元レコードを更新する為、受注番号をクリアしない
            //carInfoRow.AcceptAnOrderNo = 0; // 受注番号
            // --- DEL m.suzuki 2010/10/07 ----------<<<<<

            // 車両情報Dictionaryキャッシュ
            if ( !this._carInfo.ContainsKey( carInfoRow.CarRelationGuid ) )
            {
                this._carInfo.Add( carInfoRow.CarRelationGuid, searchCarInfo );
            }
        }
        /// <summary>
        /// カラー情報キャッシュ
        /// </summary>
        /// <param name="carRelationGuid"></param>
        /// <param name="colorCdInfoDataTable"></param>
        private void CacheColorInfo( Guid carRelationGuid, PMKEN01010E.ColorCdInfoDataTable colorCdInfoDataTable )
        {
            if ( this._colorInfoDic.ContainsKey( carRelationGuid ) ) this._colorInfoDic.Remove( carRelationGuid );
            this._colorInfoDic.Add( carRelationGuid, colorCdInfoDataTable );
        }
        /// <summary>
        /// トリム情報キャッシュ
        /// </summary>
        /// <param name="carRelationGuid"></param>
        /// <param name="trimCdInfoDataTable"></param>
        private void CacheTrimInfo( Guid carRelationGuid, PMKEN01010E.TrimCdInfoDataTable trimCdInfoDataTable )
        {
            if ( this._trimInfoDic.ContainsKey( carRelationGuid ) ) this._trimInfoDic.Remove( carRelationGuid );
            this._trimInfoDic.Add( carRelationGuid, trimCdInfoDataTable );
        }
        /// <summary>
        /// 装備情報キャッシュ
        /// </summary>
        /// <param name="carRelationGuid"></param>
        /// <param name="cEqpDefDspInfoDataTable"></param>
        private void CacheEquipInfo( Guid carRelationGuid, PMKEN01010E.CEqpDefDspInfoDataTable cEqpDefDspInfoDataTable )
        {
            if ( this._cEqpDspInfoDic.ContainsKey( carRelationGuid ) ) this._cEqpDspInfoDic.Remove( carRelationGuid );
            this._cEqpDspInfoDic.Add( carRelationGuid, cEqpDefDspInfoDataTable );
        }
        /// <summary>
        /// 車両管理ワークオブジェクトリスト取得処理
        /// </summary>
        /// <param name="carInfoDataTable">車両情報テーブル</param>
        /// <param name="carManagementWorkList">車両管理ワークオブジェクトリスト</param>
        private void GetCarManagementWorkListFromCarInfoTable( SalesInputDataSet.CarInfoDataTable carInfoDataTable, out ArrayList carManagementWorkList )
        {
            carManagementWorkList = new ArrayList();

            foreach ( SalesInputDataSet.CarInfoRow carInfoRow in carInfoDataTable )
            {
                CarManagementWork carManagementWork = this.GetParamDataFromCarInfoRow( carInfoRow );
                CarManagementWork clearCarManagementWork = new CarManagementWork();
                ArrayList differentList = carManagementWork.Compare( clearCarManagementWork );

                if ( differentList.Count > 1 )
                {
                    if ( carManagementWork != null ) carManagementWorkList.Add( carManagementWork );
                }
            }
        }
        /// <summary>
        /// 車両管理ワークオブジェクトを車両情報行オブジェクトから取得
        /// </summary>
        /// <param name="carInfoRow">車両情報行オブジェクト</param>
        /// <returns></returns>
        private CarManagementWork GetParamDataFromCarInfoRow( SalesInputDataSet.CarInfoRow carInfoRow )
        {
            CarManagementWork carManagementWork = new CarManagementWork();

            carManagementWork.EnterpriseCode = string.Empty;                        // 企業コード
            carManagementWork.CustomerCode = carInfoRow.CustomerCode;               // 得意先コード
            carManagementWork.CarMngNo = carInfoRow.CarMngNo;                       // 車両管理番号
            carManagementWork.CarMngCode = carInfoRow.CarMngCode;                   // 車輌管理コード
            carManagementWork.NumberPlate1Code = carInfoRow.NumberPlate1Code;       // 陸運事務所番号
            carManagementWork.NumberPlate1Name = carInfoRow.NumberPlate1Name;       // 陸運事務局名称
            carManagementWork.NumberPlate2 = carInfoRow.NumberPlate2;               // 車両登録番号（種別）
            carManagementWork.NumberPlate3 = carInfoRow.NumberPlate3;               // 車両登録番号（カナ）
            carManagementWork.NumberPlate4 = carInfoRow.NumberPlate4;               // 車両登録番号（プレート番号）
            carManagementWork.EntryDate = carInfoRow.EntryDate;                     // 登録年月日
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 DEL
            //int iyy = carInfoRow.ProduceTypeOfYearInput / 100;
            //int imm = carInfoRow.ProduceTypeOfYearInput % 100;
            //DateTime produceTypeOfYearInput = DateTime.MinValue;
            //if ( (iyy != 0) && (imm != 0) ) produceTypeOfYearInput = new DateTime( iyy, imm, 1 );
            //carManagementWork.FirstEntryDate = produceTypeOfYearInput;              // 初年度
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
            carManagementWork.FirstEntryDate = carInfoRow.ProduceTypeOfYearInput;              // 初年度
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD
            carManagementWork.MakerCode = carInfoRow.MakerCode;                     // メーカーコード
            carManagementWork.MakerFullName = carInfoRow.MakerFullName;             // メーカー全角名称
            carManagementWork.MakerHalfName = carInfoRow.MakerHalfName;             // メーカー半角名称
            carManagementWork.ModelCode = carInfoRow.ModelCode;                     // 車種コード
            carManagementWork.ModelSubCode = carInfoRow.ModelSubCode;               // 車種サブコード
            carManagementWork.ModelFullName = carInfoRow.ModelFullName;             // 車種全角名称
            carManagementWork.ModelHalfName = carInfoRow.ModelHalfName;             // 車種半角名称
            carManagementWork.SystematicCode = carInfoRow.SystematicCode;           // 系統コード
            carManagementWork.SystematicName = carInfoRow.SystematicName;           // 系統名称
            carManagementWork.ProduceTypeOfYearCd = carInfoRow.ProduceTypeOfYearCd; // 生産年式コード
            carManagementWork.ProduceTypeOfYearNm = carInfoRow.ProduceTypeOfYearNm; // 生産年式名称
            carManagementWork.StProduceTypeOfYear = carInfoRow.StProduceTypeOfYear; // 開始生産年式
            carManagementWork.EdProduceTypeOfYear = carInfoRow.EdProduceTypeOfYear; // 終了生産年式
            carManagementWork.DoorCount = carInfoRow.DoorCount;                     // ドア数
            carManagementWork.BodyNameCode = carInfoRow.BodyNameCode;               // ボディー名コード
            carManagementWork.BodyName = carInfoRow.BodyName;                       // ボディー名称
            carManagementWork.ExhaustGasSign = carInfoRow.ExhaustGasSign;           // 排ガス記号
            carManagementWork.SeriesModel = carInfoRow.SeriesModel;                 // シリーズ型式
            carManagementWork.CategorySignModel = carInfoRow.CategorySignModel;     // 型式（類別記号）
            carManagementWork.FullModel = carInfoRow.FullModel;                     // 型式（フル型）
            carManagementWork.ModelDesignationNo = carInfoRow.ModelDesignationNo;   // 型式指定番号
            carManagementWork.CategoryNo = carInfoRow.CategoryNo;                   // 類別番号
            carManagementWork.FrameModel = carInfoRow.FrameModel;                   // 車台型式
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
            //carManagementWork.FrameNo = (carInfoRow.ProduceFrameNoInput == 0) ? string.Empty : carInfoRow.ProduceFrameNoInput.ToString();  // 車台番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
            carManagementWork.FrameNo = carInfoRow.FrameNo;                         // 車台番号
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD
            carManagementWork.SearchFrameNo = carInfoRow.SearchFrameNo;             // 車台番号（検索用）
            carManagementWork.StProduceFrameNo = carInfoRow.StProduceFrameNo;       // 生産車台番号開始
            carManagementWork.EdProduceFrameNo = carInfoRow.EdProduceFrameNo;       // 生産車台番号終了
            carManagementWork.ModelGradeNm = carInfoRow.ModelGradeNm;               // 型式グレード名称
            carManagementWork.EngineModelNm = carInfoRow.EngineModelNm;             // エンジン型式名称
            carManagementWork.EngineDisplaceNm = carInfoRow.EngineDisplaceNm;       // 排気量名称
            carManagementWork.EDivNm = carInfoRow.EDivNm;                           // E区分名称
            carManagementWork.TransmissionNm = carInfoRow.TransmissionNm;           // ミッション名称
            carManagementWork.ShiftNm = carInfoRow.ShiftNm;                         // シフト名称
            carManagementWork.WheelDriveMethodNm = carInfoRow.WheelDriveMethodNm;   // 駆動方式名称
            carManagementWork.AddiCarSpec1 = carInfoRow.AddiCarSpec1;               // 追加諸元1
            carManagementWork.AddiCarSpec2 = carInfoRow.AddiCarSpec2;               // 追加諸元2
            carManagementWork.AddiCarSpec3 = carInfoRow.AddiCarSpec3;               // 追加諸元3
            carManagementWork.AddiCarSpec4 = carInfoRow.AddiCarSpec4;               // 追加諸元4
            carManagementWork.AddiCarSpec5 = carInfoRow.AddiCarSpec5;               // 追加諸元5
            carManagementWork.AddiCarSpec6 = carInfoRow.AddiCarSpec6;               // 追加諸元6
            carManagementWork.AddiCarSpecTitle1 = carInfoRow.AddiCarSpecTitle1;     // 追加諸元タイトル1
            carManagementWork.AddiCarSpecTitle2 = carInfoRow.AddiCarSpecTitle2;     // 追加諸元タイトル2
            carManagementWork.AddiCarSpecTitle3 = carInfoRow.AddiCarSpecTitle3;     // 追加諸元タイトル3
            carManagementWork.AddiCarSpecTitle4 = carInfoRow.AddiCarSpecTitle4;     // 追加諸元タイトル4
            carManagementWork.AddiCarSpecTitle5 = carInfoRow.AddiCarSpecTitle5;     // 追加諸元タイトル5
            carManagementWork.AddiCarSpecTitle6 = carInfoRow.AddiCarSpecTitle6;     // 追加諸元タイトル6
            carManagementWork.RelevanceModel = carInfoRow.RelevanceModel;           // 関連型式
            carManagementWork.SubCarNmCd = carInfoRow.SubCarNmCd;                   // サブ車名コード
            carManagementWork.ModelGradeSname = carInfoRow.ModelGradeSname;         // 型式グレード略称
            carManagementWork.BlockIllustrationCd = carInfoRow.BlockIllustrationCd; // ブロックイラストコード
            carManagementWork.ThreeDIllustNo = carInfoRow.ThreeDIllustNo;           // 3DイラストNo
            carManagementWork.PartsDataOfferFlag = carInfoRow.PartsDataOfferFlag;   // 部品データ提供フラグ
            carManagementWork.InspectMaturityDate = carInfoRow.InspectMaturityDate; // 車検満期日
            carManagementWork.LTimeCiMatDate = carInfoRow.LTimeCiMatDate;           // 前回車検満期日
            carManagementWork.CarInspectYear = carInfoRow.CarInspectYear;           // 車検期間
            carManagementWork.Mileage = carInfoRow.Mileage;                         // 車両走行距離
            carManagementWork.CarNo = carInfoRow.CarNo;                             // 号車
            carManagementWork.FullModelFixedNoAry = carInfoRow.FullModelFixedNoAry; // フル型式固定番号配列
            carManagementWork.ColorCode = carInfoRow.ColorCode;                     // カラーコード
            carManagementWork.ColorName1 = carInfoRow.ColorName1;                   // カラー名称
            carManagementWork.TrimCode = carInfoRow.TrimCode;                       // トリムコード
            carManagementWork.TrimName = carInfoRow.TrimName;                       // トリム名称
            carManagementWork.CategoryObjAry = this.GetEquipInfoRows( carInfoRow.CarRelationGuid ); // 装備オブジェクト配列
            carManagementWork.CarRelationGuid = carInfoRow.CarRelationGuid;         // 車両情報共通キー

            // --- ADD 2009/09/07 ---------->>>>>
            carManagementWork.CarNote = carInfoRow.CarNote; // 車両走行距離
            carManagementWork.CarAddInfo1 = carInfoRow.CarAddInfo1;
            carManagementWork.CarAddInfo2 = carInfoRow.CarAddInfo2; 
            // --- ADD 2009/09/07 ----------<<<<<
            // --- ADD 2013/03/25 ---------->>>>>
            carManagementWork.DomesticForeignCode = carInfoRow.DomesticForeignCode; // 国産/外車区分
            // --- ADD 2013/03/25 ----------<<<<<
            return carManagementWork;
        }
        /// <summary>
        /// 装備情報行オブジェクト配列取得
        /// </summary>
        /// <param name="carRelationGuid">車両情報共通キー</param>
        /// <returns>装備情報バイト配列</returns>
        private byte[] GetEquipInfoRows( Guid carRelationGuid )
        {
            byte[] equipInfoRows = new byte[0];
            if ( this._cEqpDspInfoDic.ContainsKey( carRelationGuid ) )
            {
                // 装備情報データテーブル取得
                PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];

                if ( equipInfoDataTable != null )
                {
                    // 装備情報バイト配列
                    equipInfoRows = equipInfoDataTable.GetByteArray( true );
                }
            }
            return equipInfoRows;
        }
        /// <summary>
        /// 伝票明細追加情報Workリスト生成処理
        /// </summary>
        /// <param name="_dtlCarRelationDic"></param>
        /// <param name="slipDetailAddInfoWorkList"></param>
        /// <br>Update Note : 2009/12/28 呉元嘯 PM.NS保守依頼④</br>
        /// <br>              商品マスタ未登録品を赤伝発行した場合、無条件で商品マスタに追加される件の修正</br>
        private void GetSlipDetailAddInfoWorkListFromDic( List<SalesDetailWork> redDetailWorkList, RedSlipWriteParameter parameter,out ArrayList slipDetailAddInfoWorkList )
        {
            // --- DEL m.suzuki 2010/11/26 ---------->>>>>
            //DateTime goodsEntryDate = parameter.SalesDate;
            // --- DEL m.suzuki 2010/11/26 ----------<<<<<

            // --- ADD K2014/06/20 Y.Wakita ---------->>>>>
            #region フタバ個別対応
            string sectWarehouseCd1 = string.Empty; // 拠点倉庫1
            string sectWarehouseCd2 = string.Empty; // 拠点倉庫2
            string sectWarehouseCd3 = string.Empty; // 拠点倉庫3
            string custWarehouseCd = string.Empty;  // 得意先優先倉庫

            bool sectWarehouseCdDiv = false;    // 拠点設定マスタ
            bool custWarehouseCdDiv = false;    // 得意先設定マスタ

            // フタバ個別オプションコードの追加
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus futabaCustom;
            futabaCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaSlipPrtCtl);
            if (futabaCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaSlipPrtCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaSlipPrtCtl = (int)Option.OFF;
            }

            if (this._opt_Cpm_FutabaSlipPrtCtl == (int)Option.ON)
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                // ログイン拠点情報を取得
                SecInfoSetAcs _secInfoSetAcs;
                _secInfoSetAcs = new SecInfoSetAcs();

                SecInfoSet secInfoSet;
                status = _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this._loginSectionCode.Trim());

                // ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && secInfoSet.LogicalDeleteCode == 0)
                {
                    sectWarehouseCd1 = secInfoSet.SectWarehouseCd1;  // 拠点倉庫1
                    sectWarehouseCd2 = secInfoSet.SectWarehouseCd2;  // 拠点倉庫2
                    sectWarehouseCd3 = secInfoSet.SectWarehouseCd3;  // 拠点倉庫3
                }

                // 得意先優先倉庫コード
                CustomerInfo customerInfo;
                status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, parameter.CustomerCode, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    custWarehouseCd = customerInfo.CustWarehouseCd;
                }
            }
            #endregion
            // --- ADD K2014/06/20 Y.Wakita ----------<<<<<

            slipDetailAddInfoWorkList = new ArrayList();

            // 売上明細でループする
            for ( int index = 0; index < redDetailWorkList.Count; index++ )
            {
                // -- DEL 2009/08/03 ---------------------------->>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/26 ADD
                //if ( !string.IsNullOrEmpty( redDetailWorkList[index].GoodsNo ) && redDetailWorkList[index].GoodsMakerCd != 0 )
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/26 ADD
                //{
                //    SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();

                //    // 商品自動登録
                //    slipDetailAddInfoWork.GoodsEntryDiv = 1; // 商品登録する
                //    slipDetailAddInfoWork.PriceUpdateDiv = 1; // 価格更新する
                //    slipDetailAddInfoWork.GoodsOfferDate = goodsEntryDate;
                //    slipDetailAddInfoWork.PriceStartDate = goodsEntryDate;
                //    slipDetailAddInfoWork.PriceOfferDate = goodsEntryDate;

                //    // 明細－車両リレーション
                //    Guid dtlGuid = redDetailWorkList[index].DtlRelationGuid;
                //    if ( _dtlCarRelationDic.ContainsKey( dtlGuid ) )
                //    {
                //        slipDetailAddInfoWork.DtlRelationGuid = dtlGuid;
                //        slipDetailAddInfoWork.CarRelationGuid = _dtlCarRelationDic[dtlGuid];
                //    }

                //    slipDetailAddInfoWorkList.Add( slipDetailAddInfoWork );
                //}
                // -- DEL 2009/08/03 ----------------------------<<<
                
                // -- ADD 2009/08/03 ---------------------------->>>
                SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();

                // 商品自動登録
                // -------------UPD 2009/12/28-------------->>>>>
                //if (!string.IsNullOrEmpty(redDetailWorkList[index].GoodsNo) && redDetailWorkList[index].GoodsMakerCd != 0)
                // 品番、メーカーが入力されている明細、売上全体設定マスタ.返品時在庫登録「0:する」、在取区分(SalesOrderDivCd)が「1:在庫」、倉庫コードがセットされている場合
                if (!string.IsNullOrEmpty(redDetailWorkList[index].GoodsNo) && 
                    redDetailWorkList[index].GoodsMakerCd != 0 && 
                    this.SalesTtlSt.RetGoodsStockEtyDiv == 0 && 
                    redDetailWorkList[index].SalesOrderDivCd == 1 && 
                    !string.IsNullOrEmpty(redDetailWorkList[index].WarehouseCode))
                // -------------UPD 2009/12/28--------------<<<<<
                {
                    slipDetailAddInfoWork.GoodsEntryDiv = 1; // 商品登録する
                    slipDetailAddInfoWork.PriceUpdateDiv = 1; // 価格更新する
                    // --- UPD m.suzuki 2010/11/26 ---------->>>>>
                    //slipDetailAddInfoWork.GoodsOfferDate = goodsEntryDate;
                    //slipDetailAddInfoWork.PriceStartDate = goodsEntryDate;
                    //slipDetailAddInfoWork.PriceOfferDate = goodsEntryDate;
                    slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                    slipDetailAddInfoWork.PriceStartDate = GetPriceStartDate( parameter.SalesDate );
                    slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;
                    // --- UPD m.suzuki 2010/11/26 ----------<<<<<

                }
                else
                {
                    //品番、メーカーがセットされていない明細は「商品登録しない」で作成

                    slipDetailAddInfoWork.GoodsEntryDiv = 0; // 商品登録しない
                    slipDetailAddInfoWork.PriceUpdateDiv = 0; // 価格更新しない
                    slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                    slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;
                    slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;
                }

                // 明細－車両リレーション
                Guid dtlGuid = redDetailWorkList[index].DtlRelationGuid;
                if (_dtlCarRelationDic.ContainsKey(dtlGuid))
                {
                    slipDetailAddInfoWork.DtlRelationGuid = dtlGuid;
                    slipDetailAddInfoWork.CarRelationGuid = _dtlCarRelationDic[dtlGuid];
                }

                // --- ADD 2013/10/10 T.Miyamoto ------------------------------>>>>>
                slipDetailAddInfoWork.SlipDtlRegOrder = _redSlipWorkSlipNo;
                // --- ADD 2013/10/10 T.Miyamoto ------------------------------<<<<<

                // --- ADD K2014/06/20 Y.Wakita ---------->>>>>
                slipDetailAddInfoWork.ZaiUpdFlg = false;

                #region フタバ個別対応
                if (this._opt_Cpm_FutabaSlipPrtCtl == (int)Option.ON)
                {
                    sectWarehouseCdDiv = false;
                    custWarehouseCdDiv = false;
                    
                    // 拠点倉庫1～3
                    if ((sectWarehouseCd1.Trim() == redDetailWorkList[index].WarehouseCode.Trim()) ||
                        (sectWarehouseCd2.Trim() == redDetailWorkList[index].WarehouseCode.Trim()) ||
                        (sectWarehouseCd3.Trim() == redDetailWorkList[index].WarehouseCode.Trim()))
                    {
                        sectWarehouseCdDiv = true;
                    }

                    // 得意先優先倉庫コード
                    if (custWarehouseCd.Trim() == redDetailWorkList[index].WarehouseCode.Trim())
                    {
                        custWarehouseCdDiv = true;
                    }

                    if ((sectWarehouseCdDiv == false) && (custWarehouseCdDiv == false))
                    {
                        // フタバ個別で在庫更新しない場合
                        slipDetailAddInfoWork.ZaiUpdFlg = true;
                    }
                }
                #endregion
                // --- ADD K2014/06/20 Y.Wakita ----------<<<<<

                slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
                // -- ADD 2009/08/03 ----------------------------<<<

            }
        }
        // --- ADD m.suzuki 2010/11/26 ---------->>>>>
        /// <summary>
        /// 価格開始日取得処理
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private DateTime GetPriceStartDate( DateTime dateTime )
        {
            try
            {
                //--------------------------------------------------
                // 通常は、前回月次更新日の翌日
                //--------------------------------------------------
                DateTime prevTotalDay = GetHisTotalDayMonthly();
                if ( prevTotalDay != DateTime.MinValue )
                {
                    // 前回月次更新日の翌日
                    return prevTotalDay.AddDays( 1 );
                }

                //--------------------------------------------------
                // （※新規搬入して一度も月次更新をしていないような場合）自社.期首日
                //--------------------------------------------------
                if ( _dateGetAcs == null )
                {
                    _dateGetAcs = DateGetAcs.GetInstance();
                }
                else
                {
                    _dateGetAcs.ReloadCompanyInf(); // 必ず再取得する
                }
                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;

                CompanyInf companyInf = _dateGetAcs.GetCompanyInf();
                if ( companyInf != null && companyInf.CompanyBiginDate != 0 )
                {
                    _dateGetAcs.GetFinancialYearTable( out startMonthDateList, out endMonthDateList );
                    if ( startMonthDateList != null && startMonthDateList.Count > 0 )
                    {
                        // 期首日←最初の月の開始日
                        return startMonthDateList[0];
                    }
                }
            }
            catch
            {
            }

            // ※通常は発生しないが期首日も取得できなかった場合は既存処理と同様。
            return dateTime;
        }
        /// <summary>
        /// 前回月次更新日取得
        /// </summary>
        /// <returns></returns>
        private DateTime GetHisTotalDayMonthly()
        {
            if ( _totalDayCalculator == null ) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            int status;
            DateTime prevTotalDay;

            // 締日算出モジュールのキャッシュクリア
            this._totalDayCalculator.ClearCache();

            // 買掛オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment );
            if ( ps == PurchaseStatus.Contract )
            {
                // 買掛オプションあり
                // 売上月次処理日、仕入月次処理日の古い年月取得
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly( string.Empty, out prevTotalDay );
                if ( prevTotalDay == DateTime.MinValue )
                {
                    // 売上月次処理日取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec( string.Empty, out prevTotalDay );
                    if ( prevTotalDay == DateTime.MinValue )
                    {
                        // 仕入月次処理日取得
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay( string.Empty, out prevTotalDay );
                    }
                }
            }
            else
            {
                // 買掛オプションなし
                // 売上月次処理日取得
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec( string.Empty, out prevTotalDay );
            }

            return prevTotalDay;
        }
        // --- ADD m.suzuki 2010/11/26 ----------<<<<<
        # endregion

        # region [赤伝売上関連]
        # region [赤伝売上明細売上金額算出]
        /// <summary>
        /// 売上金額を計算します。（明細部金額）（オーバーロード）
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailRow"></param>
        /// <param name="salesMoneyTaxInc"></param>
        /// <param name="salesMoneyTaxExc"></param>
        /// <param name="salesMoneyDisplay"></param>
        /// <returns></returns>
        public bool CalculationSalesMoney( SalesSlipWork salesSlip, SalesDetailWork salesDetail, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out long salesMoneyDisplay, out int fractionProcCd )
        {
            fractionProcCd = -1;

            // 売上金額を算定
            double taxRate = salesSlip.ConsTaxRate;

            // 売上金額端数処理コード(得意先マスタより取得)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
           // this.GetFractionProcInfo( SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            this.GetSalesFractionProcInfo( ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
            salesSlip.FractionProcCd = taxFracProcCd;

            // 課税区分
            int taxationCode = salesDetail.TaxationDivCd;

            double salesUnPrc = 0;// 売上単価(税抜)
            if ( (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) || // 内税
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount) ) // 総額表示する(総額表示する場合、内税計算を行う)
            {
                // 内税
                salesUnPrc = salesDetail.SalesUnPrcTaxIncFl;
            }
            else
            {
                // 外税/非課税
                salesUnPrc = salesDetail.SalesUnPrcTaxExcFl;
            }

            // 非課税
            if ( salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt )
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // 総額表示時は内税で計算する
            else if ( salesSlip.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.TotalAmount )
            {
                // 総額表示する
                if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc )
                {
                    taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                }
            }
            bool ret = true;
            //if ( ((salesDetailRow.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount) && (salesDetailRow.ShipmentCnt == 0)) || // 行値引き
            //    (salesDetailRow.SalesMoneyInputDiv == (int)SalesMoneyInputDiv.Input) ) // 売上金額手入力
            if ( ((salesDetail.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount) && (salesDetail.ShipmentCnt == 0)) ) // 行値引き
            {
                salesMoneyTaxInc = salesDetail.SalesMoneyTaxInc;
                salesMoneyTaxExc = salesDetail.SalesMoneyTaxExc;
            }
            //---------- ADD 2009/11/25 ---------->>>>>
            else if (salesDetail.SalesMoneyTaxExc != 0 && salesDetail.SalesUnPrcTaxExcFl == 0) // 売上金額手入力
            {
                int sign = (salesDetail.ShipmentCnt < 0) ? -1 : 1;
                salesMoneyTaxInc = Math.Abs(salesDetail.SalesMoneyTaxInc) * sign;
                salesMoneyTaxExc = Math.Abs(salesDetail.SalesMoneyTaxExc) * sign;
            }
            //---------- ADD 2009/11/25 ----------<<<<<
            else
            {
                ret = this.CalculationSalesMoney(
                    salesSlip,
                    salesDetail.ShipmentCnt,
                    salesUnPrc,
                    taxationCode,
                    taxRate,
                    salesMoneyFrcProcCode,
                    salesCnsTaxFrcProcCd,
                    out salesMoneyTaxInc,
                    out salesMoneyTaxExc,
                    out fractionProcCd);
            }

            if ( (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) ||
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount) )
            {
                salesMoneyDisplay = salesMoneyTaxInc; // 表示金額→税込
            }
            else
            {
                salesMoneyDisplay = salesMoneyTaxExc; // 表示金額→税抜
            }
            return ret;
        }
        /// <summary>
        /// 売上金額を計算します。
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="shipmentCnt">数量</param>
        /// <param name="salesUnPrcTaxExcFl">売単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="salesMoneyFrcProcCd">売上端数処理区分(数量*単価に使用)</param>
        /// <param name="taxFrac">消費税端数処理区分</param>
        /// <param name="salesMoneyTaxInc">売上金額（税込み）</param>
        /// <param name="salesMoneyTaxExc">売上金額（税抜き）</param>
        /// <returns>true:算定完了 false:算定失敗</returns>
        /// <remarks>
        /// <br>Call：商品検索／定価／売単価／売価率／原単価／原価率／売上金額 変更時</br>
        /// </remarks>
        private bool CalculationSalesMoney( SalesSlipWork salesSlip, double shipmentCnt, double salesUnPrcTaxExcFl, int taxationCode, double taxRate, int salesMoneyFrcProcCd, int taxFrac, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out int fractionProcCd )
        {
            fractionProcCd = -1;

            salesMoneyTaxInc = 0;
            salesMoneyTaxExc = 0;

            double unitPriceExc = 0;    // 単価（税抜き）
            double unitPriceInc = 0;	// 単価（税込み）
            double unitPriceTax = 0;	// 単価（消費税）
            long priceExc = 0;			// 価格（税抜き）
            long priceInc = 0;			// 価格（税込み）
            long priceTax = 0;			// 価格（消費税）

            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;

            // 出荷数が0または売上単価が0の場合はすべて0で終了
            if ( (shipmentCnt == 0) || (salesUnPrcTaxExcFl == 0) ) return true;

            switch ( (CalculateTax.TaxationCode)taxationCode )
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // 外税
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc( taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd );

                    salesMoneyTaxInc = priceInc;		        // 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		        // 売上金額（税抜き）		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // 内税
                    //---------------------------------
                    unitPriceInc = salesUnPrcTaxExcFl;	// 単価（税込み）
                    priceInc = 0;					        // 価格（税込み）

                    this._salesPriceCalculate.CalcTaxExcFromTaxInc( taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd );

                    salesMoneyTaxInc = priceInc;		        // 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		        // 売上金額（税抜き）
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // 非課税
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc( taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd );

                    salesMoneyTaxInc = priceExc;		// 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		// 売上金額（税込み）
                    break;
            }

            fractionProcCd = taxFracProcCd;
            return true;
        }

        /// <summary>
        /// 売上金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="rowIndex">対象行Index</param>
        /// <remarks>
        /// <br>Note       : 売上金額を計算します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.11.25</br>
        /// </remarks>
        public void CalculationSalesMoney(int rowIndex)
        {
            this.CalculationSalesMoney(rowIndex, this._detailDataSet.RedSlipDetail[rowIndex]);
        }

        /// <summary>
        /// 売上金額を計算します。（明細部金額）（オーバーロード）
        /// </summary>
        /// <param name="rowIndex">対象行Index</param>
        /// <param name="redSlipDetailDataTable">売上明細データテーブル</param>
        /// <remarks>
        /// <br>Note       : 売上金額を計算します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.11.25</br>
        /// </remarks>
        private void CalculationSalesMoney(int rowIndex, CustPtrSalesDetailDataSet.RedSlipDetailRow redSlipDetailRow)
        {
            // 受注ステータス
            int acptAnOdrStatus = (int)redSlipDetailRow[_detailDataSet.RedSlipDetail.AcptAnOdrStatusColumn];
            // 伝票番号
            string salesSlipNum = (string)redSlipDetailRow[_detailDataSet.RedSlipDetail.SalesSlipNumColumn];
            // 明細行№
            int rowNo = (int)redSlipDetailRow[_detailDataSet.RedSlipDetail.SalesRowNoColumn];
            int readMode = 0;
            int status = 0;
            // 履歴判断
            if (string.IsNullOrEmpty((string)redSlipDetailRow[_detailDataSet.RedSlipDetail.HistoryDivNameColumn]))
            {
                // 通常
                readMode = 0;
            }
            else
            {
                // 履歴
                readMode = 1;
            }

            # region [変数初期化]
            // 読み込み結果退避用
            SalesSlipWork salesSlip = null;
            List<SalesDetailWork> salesDetailList = null;
            List<SalesDetailWork> addUpSrcDetailList = null;
            SearchDepsitMain searchDepsitMain = null;
            SearchDepositAlw searchDepositAlw = null;
            List<StockSlipWork> stockSlipWorkList = null;
            List<StockDetailWork> stockDetailWorkList = null;
            List<AddUpOrgStockDetailWork> addUpSrcStockDetailWorkList = null;
            List<StockWork> stockWorkList = null;
            List<AcceptOdrCarWork> acceptOdrCarList = null;
            # endregion
            // データリード
            status = this.ReadDBDataProc(ConstantManagement.LogicalMode.GetData0,
                this._enterpriseCode, acptAnOdrStatus, salesSlipNum,
                out salesSlip, out salesDetailList,
                out addUpSrcDetailList, out searchDepsitMain,
                out searchDepositAlw, out stockSlipWorkList,
                out stockDetailWorkList, out addUpSrcStockDetailWorkList,
                out stockWorkList, out acceptOdrCarList,
                readMode
                );
            if (status == 0)
            {
                if (salesSlip == null || salesDetailList == null) return;
                else if (salesDetailList.Count == 0) return;
                #region [売上金額再計算]
                // (得意先)
                if (_customerInfoAcs == null)
                {
                    _customerInfoAcs = new CustomerInfoAcs();
                }
                // (売上金額処理設定)
                if (_salesProcMoneyAcs == null)
                {
                    _salesProcMoneyAcs = new SalesProcMoneyAcs();
                    CacheSalesProcMoney();
                }
                // (売上金額算出モジュール)
                if (_salesPriceCalculate == null)
                {
                    _salesPriceCalculate = new SalesPriceCalculate();
                    _salesPriceCalculate.CacheSalesProcMoneyList(this._salesProcMoneyList);
                }
                SalesDetailWork salesDetailWork = (SalesDetailWork)salesDetailList[rowNo - 1];
                salesDetailWork.ShipmentCnt = (double)redSlipDetailRow[this._detailDataSet.RedSlipDetail.ReturnCntColumn];
                salesDetailWork.SalesUnPrcTaxExcFl = (double)redSlipDetailRow[this._detailDataSet.RedSlipDetail.SalesUnPrcTaxExcFlColumn];
                // 売上金額再計算
                long salesMoneyTaxExc;
                long salesMoneyTaxInc;
                long salesMoneyDisplay = 0;
                int fractionProcCd;
                this.CalculationSalesMoney(salesSlip, salesDetailWork, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay, out fractionProcCd);
                redSlipDetailRow.SalesMoneyTaxExc = salesMoneyDisplay;
                #endregion
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
        ///// <summary>
        ///// 端数処理単位、端数処理区分取得処理
        ///// </summary>
        ///// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        ///// <param name="fractionProcCode">端数処理コード</param>
        ///// <param name="targetPrice">対象金額</param>
        ///// <param name="fractionProcUnit">端数処理単位</param>
        ///// <param name="fractionProcCd">端数処理区分</param>
        ///// 
        //public void GetFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd )
        //{
        //    //デフォルト
        //    switch ( fracProcMoneyDiv )
        //    {
        //        case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
        //            fractionProcUnit = 0.01;
        //            break;
        //        default:
        //            fractionProcUnit = 1;               // 単価以外は1円単位
        //            break;
        //    }
        //    fractionProcCd = 1;     // 切捨て

        //    // 端数処理対象金額区分、端数処理コードが一致するデータを昇順に取得
        //    DataRow[] dr = _salesProcMoneyDataTable.Select( string.Format( "{0} = {1} AND {2} = {3}", _salesProcMoneyDataTable.FracProcMoneyDivColumn.ColumnName,
        //                                                                                                fracProcMoneyDiv,
        //                                                                                                _salesProcMoneyDataTable.FractionProcCodeColumn, fractionProcCode,
        //                                                                                                fractionProcCode ),
        //                                                       string.Format( "{0} DESC", _salesProcMoneyDataTable.UpperLimitPriceColumn.ColumnName ) );

        //    foreach ( SalesInputInitialDataSet.SalesProcMoneyRow stockProcMoneyRow in dr )
        //    {
        //        if ( stockProcMoneyRow.UpperLimitPrice < targetPrice )
        //        {
        //            break;
        //        }
        //        fractionProcUnit = stockProcMoneyRow.FractionProcUnit;
        //        fractionProcCd = stockProcMoneyRow.FractionProcCd;
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        public void GetSalesFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd )
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch ( fracProcMoneyDiv )
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this._salesProcMoneyList.FindAll(
                delegate( SalesProcMoney sProcMoney )
                {
                    if ( (sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode) )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 DEL
            ////-----------------------------------------------------------------------------
            //// ソート（上限金額（降順））
            ////-----------------------------------------------------------------------------
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 ADD
            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 ADD
            salesProcMoneyList.Sort( new SalesProcMoneyComparer() );

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate( SalesProcMoney spm )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 DEL
                    //if ( spm.UpperLimitPrice <= targetPrice )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 ADD
                    if ( spm.UpperLimitPrice >= targetPrice )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 ADD
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if ( salesProcMoney != null )
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
        /// <summary>
        /// 売上金額処理区分設定マスタキャッシュ処理
        /// </summary>
        private void CacheSalesProcMoney()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //ArrayList al = null;
            //int status = this._salesProcMoneyAcs.Search( out al, _enterpriseCode );
            ////List<SalesProcMoney>  salesProcMoneyList = new List<SalesProcMoney>();
            ////this._goodsAcs.SalesProcMoneyList = this._salesProcMoneyList;
            //if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            //{
            //    if ( al != null )
            //    {
            //        foreach ( SalesProcMoney salesProcMoney in al )
            //        {
            //            this.CacheSalesProcMoney( salesProcMoney );
            //            //salesProcMoneyList.Add( salesProcMoney.Clone() );
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            _salesProcMoneyList = null;
            ArrayList al = null;
            int status = this._salesProcMoneyAcs.Search( out al, _enterpriseCode );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( al != null )
                {
                    _salesProcMoneyList = new List<SalesProcMoney>( (SalesProcMoney[])al.ToArray( typeof( SalesProcMoney ) ) );
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
        ///// <summary>
        ///// 売上金額処理区分設定マスタキャッシュ処理
        ///// </summary>
        ///// <param name="salesProcMoneyWork">売上金額処理区分設定マスタワーククラス</param>
        //internal void CacheSalesProcMoney( SalesProcMoney salesProcMoney )
        //{
        //    try
        //    {
        //        _salesProcMoneyDataTable.AddSalesProcMoneyRow( this.RowFromUIData( salesProcMoney ) );
        //    }
        //    catch ( ConstraintException )
        //    {
        //        SalesInputInitialDataSet.SalesProcMoneyRow row = _salesProcMoneyDataTable.FindByFracProcMoneyDivFractionProcCodeUpperLimitPrice( salesProcMoney.FracProcMoneyDiv, salesProcMoney.FractionProcCode, salesProcMoney.UpperLimitPrice );
        //        this.SetRowFromUIData( ref row, salesProcMoney );
        //    }
        //}
        ///// <summary>
        ///// 売上金額処理区分設定マスタワーククラス→売上金額処理区分設定マスタ行クラス変換処理
        ///// </summary>
        ///// <param name="salesProcMoneyWork">売上金額処理区分設定マスタ行クラス</param>
        ///// <returns>売上金額処理区分設定マスタワークタクラス</returns>
        //internal SalesInputInitialDataSet.SalesProcMoneyRow RowFromUIData( SalesProcMoney salesProcMoney )
        //{
        //    SalesInputInitialDataSet.SalesProcMoneyRow row = _salesProcMoneyDataTable.NewSalesProcMoneyRow();

        //    this.SetRowFromUIData( ref row, salesProcMoney );
        //    return row;
        //}
        ///// <summary>
        ///// 売上金額処理区分設定マスタワーク→売上金額処理区分設定マスタ行クラス設定処理
        ///// </summary>
        ///// <param name="row">売上金額処理区分設定マスタ行クラス</param>
        ///// <param name="salesProcMoneyWork">売上金額処理区分設定マスタワーククラス</param>
        //internal void SetRowFromUIData( ref SalesInputInitialDataSet.SalesProcMoneyRow row, SalesProcMoney salesProcMoney )
        //{
        //    // 端数処理対象金額区分
        //    row.FracProcMoneyDiv = salesProcMoney.FracProcMoneyDiv;

        //    // 端数処理コード
        //    row.FractionProcCode = salesProcMoney.FractionProcCode;

        //    // 上限金額
        //    row.UpperLimitPrice = salesProcMoney.UpperLimitPrice;

        //    // 端数処理単位
        //    row.FractionProcUnit = salesProcMoney.FractionProcUnit;

        //    // 端数処理区分
        //    row.FractionProcCd = salesProcMoney.FractionProcCd;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
        /// <summary>
        /// 対象金額より、税抜き、税込み価格を計算します。
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="displayPrice">対象金額</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        private void CalcTaxExcAndTaxIncForSales( int taxationCode, int customerCode, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // 得意先マスタから消費税端数処理情報を取得
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd( this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd );		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //this.GetStockFractionProcInfo( SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            this.GetStockFractionProcInfo( ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD


            // 内税品
            if ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc )
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc( taxRate, fracProcUnit, fracProcCd, priceTaxInc );
            }
            // 外税品
            else if ( taxationCode == (int)CalculateTax.TaxationCode.TaxExc )
            {
                // 総額表示している場合は税込み価格
                if ( totalAmountDispWayCd == 1 )
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc( taxRate, fracProcUnit, fracProcCd, priceTaxInc );
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc( taxRate, fracProcUnit, fracProcCd, priceTaxExc );
                }
            }
            // 非課税品
            else if ( taxationCode == (int)CalculateTax.TaxationCode.TaxNone )
            {
                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice;
            }
            else
            {
                priceTaxExc = 0;
                priceTaxInc = 0;
            }
        }
        # endregion

        # region [赤伝売上明細原価金額算出]
        /// <summary>
        /// 仕入金額処理区分設定マスタキャッシュ処理
        /// </summary>
        private void CacheStockProcMoney()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //ArrayList al = null;
            //int status = this._stockProcMoneyAcs.Search( out al, _enterpriseCode );
            ////List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();
            //if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            //{
            //    if ( al != null )
            //    {
            //        foreach ( StockProcMoney stockProcMoney in al )
            //        {
            //            this.CacheStockProcMoney( stockProcMoney );
            //            //stockProcMoneyList.Add( stockProcMoney.Clone() );
            //        }
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            _stockProcMoneyList = null;
            ArrayList al = null;
            int status = this._stockProcMoneyAcs.Search( out al, _enterpriseCode );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                if ( al != null )
                {
                    _stockProcMoneyList = new List<StockProcMoney>( (StockProcMoney[])al.ToArray( typeof( StockProcMoney ) ) );
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
        }

        /// <summary>
        /// 売上金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="salesSlip">売上データ行オブジェクト</param>
        /// <param name="salesDetail">売上明細データテーブル</param>
        /// <remarks>
        /// <br>Note       : 売上金額を計算します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.11.25</br>
        /// </remarks>
        private void SalesDetailRowSalesGoodsCdSetting(SalesSlipWork salesSlip, ref SalesDetailWork salesDetail)
        {
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, 0, 0, out taxFracProcUnit, out taxFracProcCd);
            switch ((SalesGoodsCd)salesDetail.SalesGoodsCd)
            {
                // 商品
                case SalesGoodsCd.Goods:
                    // 非課税

                    if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                    {
                        salesDetail.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc;
                        salesDetail.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxExc;
                    }
                    // 総額表示しない
                    else if (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                    {
                        //-----------------------------------------------------
                        // 総額表示しない
                        //-----------------------------------------------------
                        switch ((CalculateTax.TaxationCode)salesDetail.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                salesDetail.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc;
                                salesDetail.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxExc + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesDetail.SalesMoneyTaxExc);
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                salesDetail.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesDetail.SalesMoneyTaxExc);
                                salesDetail.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxExc;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                salesDetail.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc;
                                salesDetail.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxExc;
                                break;
                            default:
                                break;
                        }
                    }
                    // 総額表示する
                    else
                    {
                        //-----------------------------------------------------
                        // 総額表示する
                        //-----------------------------------------------------
                        switch ((CalculateTax.TaxationCode)salesDetail.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                salesDetail.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesDetail.SalesMoneyTaxExc);
                                salesDetail.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxExc;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                salesDetail.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesDetail.SalesMoneyTaxExc);
                                salesDetail.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxExc;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                salesDetail.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc;
                                salesDetail.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxExc;
                                break;
                        }
                        
                    }
                    salesDetail.SalesPriceConsTax = (long)((decimal)salesDetail.SalesMoneyTaxInc - (decimal)salesDetail.SalesMoneyTaxExc);
                    break;
                // 消費税調整
                // 残高調整
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    break;
            }

        }
        /// <summary>
        /// 原価金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="salesDetailRow">売上明細データ行オブジェクト</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブル</param>
        private void CalculationCost( SalesSlipWork salesSlip, SalesDetailWork salesDetail, out long cost  )
        {
            cost = 0;

            switch ( (SalesGoodsCd)salesDetail.SalesGoodsCd )
            {
                // 商品
                case SalesGoodsCd.Goods:

                    // 原価金額を算定
                    long costTaxInc;
                    long costTaxExc;
                    long costDisplay;
                    double taxRate = salesSlip.ConsTaxRate;

                    // 課税区分
                    int taxationCode = salesDetail.TaxationDivCd;

                    double salesUnitCost = 0;

                    // 原価、原価金額再計算(テーブル上に税込、税抜項目が無い為)
                    # region [税込・税抜原価算出]
                    //double costTaxExc = 0;
                    //double costTaxInc = 0;
                    double salesUnitCostTaxExc = 0;
                    double salesUnitCostTaxInc = 0;
                    //this.CalcTaxExcAndTaxInc( salesDetailRow.TaxationDivCd, salesSlip.CustomerCode, salesSlip.ConsTaxRate, salesSlip.TotalAmountDispWayCd, salesDetailRow.Cost, out costTaxExc, out costTaxInc );
                    this.CalcTaxExcAndTaxIncForStock( salesDetail.TaxationDivCd, salesDetail.SupplierCd, salesSlip.ConsTaxRate, salesSlip.TotalAmountDispWayCd, salesDetail.SalesUnitCost, out salesUnitCostTaxExc, out salesUnitCostTaxInc );
                    # endregion

                    switch ( (CalculateTax.TaxationCode)salesDetail.TaxationDivCd )
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            salesUnitCost = salesUnitCostTaxExc;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            salesUnitCost = salesUnitCostTaxInc;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            salesUnitCost = salesUnitCostTaxExc;
                            break;
                    }

                    // 非課税
                    if ( salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt )
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    // 内税
                    else if ( (taxationCode != (int)CalculateTax.TaxationCode.TaxNone) &&
                             (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount) )
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                    }

                    #region ●売上情報
                    if ( this.CalculationCost(
                        salesDetail,
                        salesDetail.ShipmentCnt,
                        salesUnitCost,
                        taxationCode,
                        taxRate,
                        out costTaxInc,
                        out costTaxExc,
                        out costDisplay ) )
                    {
                        //salesDetailRow.CostTaxExc = costTaxExc;        // 外税
                        //salesDetailRow.CostTaxInc = costTaxInc;        // 内税
                        //salesDetailRow.Cost = costDisplay;
                        cost = costDisplay;
                    }
                    #endregion

                    break;
                // 消費税調整
                // 残高調整
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    break;
            }
        }
        /// <summary>
        /// 原価金額を計算します。
        /// </summary>
        /// <param name="shipmentCnt">数量</param>
        /// <param name="SalesUnitCostTaxExc">原価単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="costTaxInc">原価金額（税込み）</param>
        /// <param name="costTaxExc">原価金額（税抜き）</param>
        /// <param name="costDisplay">原価金額（表示）</param>
        /// <returns>true:算定完了 false:算定失敗</returns>
        /// <remarks>
        /// <br>Call：商品検索／定価／売単価／売価率／原単価／原価率／売上金額 変更時</br>
        /// </remarks>
        private bool CalculationCost( SalesDetailWork salesDetail, double shipmentCnt, double SalesUnitCostTaxExc, int taxationCode, double taxRate, out long costInc, out long costExc, out long costDisplay )
        {
            costInc = 0;
            costExc = 0;
            costDisplay = 0;
            double unitPriceExc = 0;	                // 単価（税抜き）
            double unitPriceInc = 0;				    // 単価（税込み）
            double unitPriceTax = 0;					// 単価（消費税）
            long priceExc = 0;					        // 価格（税抜き）
            long priceInc = 0;						    // 価格（税込み）
            long priceTax = 0;						    // 価格（消費税）

            // 原価金額端数処理コード
            int costFrcProcCd = this._supplierAcs.GetStockFractionProcCd( this._enterpriseCode, salesDetail.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd );

            // 消費税端数処理単位、区分取得
            int taxFrac = this._supplierAcs.GetStockFractionProcCd( this._enterpriseCode, salesDetail.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd );
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;

            // 出荷数が0または売上単価が0の場合はすべて0で終了
            if ( (shipmentCnt == 0) || (SalesUnitCostTaxExc == 0) ) return true;

            switch ( (CalculateTax.TaxationCode)taxationCode )
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // 外税
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc( taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd );
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc( taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd );
                    
                    costInc = priceInc;		        // 売上金額（税込み）
                    costExc = priceExc;		        // 売上金額（税抜き）		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // 内税
                    //---------------------------------
                    unitPriceInc = SalesUnitCostTaxExc;	    // 単価（税込み）
                    priceInc = 0;					        // 価格（税込み）

                    //this._salesPriceCalculate.CalcTaxExcFromTaxInc( taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd );
                    this._stockPriceCalculate.CalcTaxExcFromTaxInc( taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd );

                    costInc = priceInc;		        // 売上金額（税込み）
                    costExc = priceExc;		        // 売上金額（税抜き）
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // 非課税
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc( taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd );
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc( taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd );

                    costInc = priceExc;		// 売上金額（税込み）
                    costExc = priceExc;		// 売上金額（税込み）
                    break;
            }

            if ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc ) // 課税区分 // 原価は総額表示区分によらない
            {
                costDisplay = costInc;
            }
            else
            {
                costDisplay = costExc;
            }

            return true;
        }
        /// <summary>
        /// 対象金額より、税抜き、税込み価格を計算します。
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="displayPrice">対象金額</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        private void CalcTaxExcAndTaxIncForStock( int taxationCode, int supplierCd, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc )
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // 仕入先マスタから消費税端数処理情報を取得
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd( this._enterpriseCode, supplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //this.GetStockFractionProcInfo( SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            this.GetStockFractionProcInfo( ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD

            // 内税品
            if ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc )
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc( taxRate, fracProcUnit, fracProcCd, priceTaxInc );
            }
            // 外税品
            else if ( taxationCode == (int)CalculateTax.TaxationCode.TaxExc )
            {
                // 総額表示している場合は税込み価格
                if ( totalAmountDispWayCd == 1 )
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc( taxRate, fracProcUnit, fracProcCd, priceTaxInc );
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc( taxRate, fracProcUnit, fracProcCd, priceTaxExc );
                }
            }
            // 非課税品
            else if ( taxationCode == (int)CalculateTax.TaxationCode.TaxNone )
            {
                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice;
            }
            else
            {
                priceTaxExc = 0;
                priceTaxInc = 0;
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
        ///// <summary>
        ///// 端数処理単位、端数処理区分取得処理
        ///// </summary>
        ///// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        ///// <param name="fractionProcCode">端数処理コード</param>
        ///// <param name="targetPrice">対象金額</param>
        ///// <param name="fractionProcUnit">端数処理単位</param>
        ///// <param name="fractionProcCd">端数処理区分</param>
        ///// 
        //private void GetStockFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd )
        //{
        //    //デフォルト
        //    switch ( fracProcMoneyDiv )
        //    {
        //        case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
        //            fractionProcUnit = 0.01;
        //            break;
        //        default:
        //            fractionProcUnit = 1;               // 単価以外は1円単位
        //            break;
        //    }
        //    fractionProcCd = 1;     // 切捨て

        //    // 端数処理対象金額区分、端数処理コードが一致するデータを昇順に取得
        //    DataRow[] dr = _stockProcMoneyDataTable.Select( string.Format( "{0} = {1} AND {2} = {3}", _stockProcMoneyDataTable.FracProcMoneyDivColumn.ColumnName,
        //                                                                                                fracProcMoneyDiv,
        //                                                                                                _stockProcMoneyDataTable.FractionProcCodeColumn, fractionProcCode,
        //                                                                                                fractionProcCode ),
        //                                                       string.Format( "{0} DESC", _stockProcMoneyDataTable.UpperLimitPriceColumn.ColumnName ) );

        //    foreach ( SalesInputInitialDataSet.StockProcMoneyRow stockProcMoneyRow in dr )
        //    {
        //        if ( stockProcMoneyRow.UpperLimitPrice < targetPrice )
        //        {
        //            break;
        //        }
        //        fractionProcUnit = stockProcMoneyRow.FractionProcUnit;
        //        fractionProcCd = stockProcMoneyRow.FractionProcCd;
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        public void GetStockFractionProcInfo( int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd )
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch ( fracProcMoneyDiv )
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<StockProcMoney> stockProcMoneyList = this._stockProcMoneyList.FindAll(
                delegate( StockProcMoney sProcMoney )
                {
                    if ( (sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode) )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 DEL
            ////-----------------------------------------------------------------------------
            //// ソート（上限金額（降順））
            ////-----------------------------------------------------------------------------
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 ADD
            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 ADD
            stockProcMoneyList.Sort( new StockProcMoneyComparer() );

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            StockProcMoney stockProcMoney = stockProcMoneyList.Find(
                delegate( StockProcMoney spm )
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 DEL
                    //if ( spm.UpperLimitPrice <= targetPrice )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 ADD
                    if ( spm.UpperLimitPrice >= targetPrice )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 ADD
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if ( stockProcMoney != null )
            {
                fractionProcUnit = stockProcMoney.FractionProcUnit;
                fractionProcCd = stockProcMoney.FractionProcCd;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
        # endregion

        # region [赤伝売上伝票金額算出]
        /// <summary>
        /// 合計金額設定処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        private void TotalPriceSetting( ref SalesSlipWork salesSlip, List<SalesDetailWork> salesDetailList )
        {
            if ( salesSlip == null ) return;
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd( this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd );		// 消費税端数処理コード

            long salesTotalTaxInc = 0;      // 売上伝票合計（税込）
            long salesTotalTaxExc = 0;      // 売上伝票合計（税抜）
            long salesSubtotalTax = 0;      // 売上小計（税）
            long itdedSalesOutTax = 0;      // 売上外税対象額
            long itdedSalesInTax = 0;       // 売上内税対象額
            long salSubttlSubToTaxFre = 0;  // 売上小計非課税対象額
            long salesOutTax = 0;           // 売上金額消費税額（外税）
            long salAmntConsTaxInclu = 0;   // 売上金額消費税額（内税）
            long salesDisTtlTaxExc = 0;     // 売上値引金額計（税抜）
            long itdedSalesDisOutTax = 0;   // 売上値引外税対象額合計
            long itdedSalesDisInTax = 0;    // 売上値引内税対象額合計
            long itdedSalesDisTaxFre = 0;   // 売上値引非課税対象額合計
            long salesDisOutTax = 0;        // 売上値引消費税額（外税）
            long salesDisTtlTaxInclu = 0;   // 売上値引消費税額（内税）
            long totalCost = 0;             // 原価金額計
            long stockGoodsTtlTaxExc = 0;   // 在庫商品合計金額（税抜）
            long pureGoodsTtlTaxExc = 0;    // 純正商品合計金額（税抜）
            long taxAdjust = 0;             // 消費税調整額
            long balanceAdjust = 0;         // 残高調整額
            long salesPrtSubttlInc = 0;     // 売上部品小計（税込）
            long salesPrtSubttlExc = 0;     // 売上部品小計（税抜）
            long salesWorkSubttlInc = 0;    // 売上作業小計（税込）
            long salesWorkSubttlExc = 0;    // 売上作業小計（税抜）
            long itdedPartsDisInTax = 0;    // 部品値引対象額合計（税込）
            long itdedPartsDisOutTax = 0;   // 部品値引対象額合計（税抜）
            long itdedWorkDisInTax = 0;     // 作業値引対象額合計（税込）
            long itdedWorkDisOutTax = 0;    // 作業値引対象額合計（税抜）
            long totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            this.CalculationSalesTotalPrice(
                salesDetailList,
                salesSlip.ConsTaxRate,
                salesTaxFrcProcCd,
                salesSlip.TotalAmountDispWayCd,
                salesSlip.ConsTaxLayMethod,
                out salesTotalTaxInc,
                out salesTotalTaxExc,
                out salesSubtotalTax,
                out itdedSalesOutTax,
                out itdedSalesInTax,
                out salSubttlSubToTaxFre,
                out salesOutTax,
                out salAmntConsTaxInclu,
                out salesDisTtlTaxExc,
                out itdedSalesDisOutTax,
                out itdedSalesDisInTax,
                out itdedSalesDisTaxFre,
                out salesDisOutTax,
                out salesDisTtlTaxInclu,
                out totalCost,
                out stockGoodsTtlTaxExc,
                out pureGoodsTtlTaxExc,
                out balanceAdjust,
                out taxAdjust,
                out salesPrtSubttlInc,
                out salesPrtSubttlExc,
                out salesWorkSubttlInc,
                out salesWorkSubttlExc,
                out itdedPartsDisInTax,
                out itdedPartsDisOutTax,
                out itdedWorkDisInTax,
                out itdedWorkDisOutTax,
                out totalMoneyForGrossProfit );


            salesSlip.SalesSubtotalTaxInc = salesTotalTaxInc;       // 売上小計（税込）
            salesSlip.SalesSubtotalTaxExc = salesTotalTaxExc;       // 売上小計（税抜）
            salesSlip.SalesSubtotalTax = salesSubtotalTax;          // 売上小計（税）
            salesSlip.ItdedSalesOutTax = itdedSalesOutTax;          // 売上外税対象額
            salesSlip.ItdedSalesInTax = itdedSalesInTax;            // 売上内税対象額
            salesSlip.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // 売上小計非課税対象額
            salesSlip.SalesOutTax = salesOutTax;                    // 売上金額消費税額（外税）
            salesSlip.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // 売上金額消費税額（内税）
            salesSlip.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // 売上値引金額計（税抜）
            salesSlip.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // 売上値引外税対象額合計
            salesSlip.ItdedSalesDisInTax = itdedSalesDisInTax;      // 売上値引内税対象額合計
            salesSlip.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // 売上値引非課税対象額合計
            salesSlip.SalesDisOutTax = salesDisOutTax;              // 売上値引消費税額（外税）
            salesSlip.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // 売上値引消費税額（内税）
            salesSlip.TotalCost = totalCost;                        // 原価金額計
            salesSlip.StockGoodsTtlTaxExc = stockGoodsTtlTaxExc;    // 在庫商品合計金額（税抜）
            salesSlip.PureGoodsTtlTaxExc = pureGoodsTtlTaxExc;      // 純正商品合計金額（税抜）
            salesSlip.SalesPrtSubttlInc = salesPrtSubttlInc;                // 売上部品小計（税込）
            salesSlip.SalesPrtSubttlExc = salesPrtSubttlExc;                // 売上部品小計（税抜）
            salesSlip.SalesWorkSubttlInc = salesWorkSubttlInc;              // 売上作業小計（税込）
            salesSlip.SalesWorkSubttlExc = salesWorkSubttlExc;              // 売上作業小計（税抜）
            salesSlip.ItdedPartsDisInTax = itdedPartsDisInTax;              // 部品値引対象額合計（税込）
            salesSlip.ItdedPartsDisOutTax = itdedPartsDisOutTax;            // 部品値引対象額合計（税抜）
            salesSlip.ItdedWorkDisInTax = itdedWorkDisInTax;                // 作業値引対象額合計（税込）
            salesSlip.ItdedWorkDisOutTax = itdedWorkDisOutTax;              // 作業値引対象額合計（税抜）
            //salesSlip.TotalMoneyForGrossProfit = totalMoneyForGrossProfit; // 粗利計算用売上金額

            salesSlip.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;                   // 売上伝票合計（税込）= 売上伝票合計（税込） + 売上小計非課税対象額
            salesSlip.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;                   // 売上伝票合計（税抜）= 売上伝票合計（税抜） + 売上小計非課税対象額
            salesSlip.SalesNetPrice = itdedSalesOutTax + itdedSalesInTax + salSubttlSubToTaxFre;    // 売上正価金額 = 売上外税対象額 + 売上内税対象額 + 売上小計非課税対象額
            salesSlip.AccRecConsTax = salesSubtotalTax;                                             // 売掛消費税
            salesSlip.SalesPrtTotalTaxInc = salesPrtSubttlInc + itdedPartsDisInTax;                 // 売上部品合計（税込）
            salesSlip.SalesPrtTotalTaxExc = salesPrtSubttlExc + itdedPartsDisOutTax;                // 売上部品合計（税抜）
            salesSlip.SalesWorkTotalTaxInc = salesWorkSubttlInc + itdedWorkDisInTax;                // 売上作業合計（税込）
            salesSlip.SalesWorkTotalTaxExc = salesWorkSubttlExc + itdedWorkDisOutTax;               // 売上作業合計（税抜）
        }

        /// <summary>
        /// 売上金額の合計を計算します。
        /// </summary>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="pureGoodsTtlTaxExc">純正商品合計金額(税抜)</param>
        /// <param name="stockGoodsTtlTaxExc">在庫商品合計金額(税抜)</param>
        /// <param name="consTaxRate">消費税税率</param>
        /// <param name="salesTaxFrcProcCd">消費税端数処理コード</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <param name="salesTotalTaxInc">売上伝票合計（税込）</param>
        /// <param name="salesTotalTaxExc">売上伝票合計（税抜）</param>
        /// <param name="salesSubtotalTax">売上小計（税）</param>
        /// <param name="itdedSalesOutTax">売上外税対象額</param>
        /// <param name="itdedSalesInTax">売上内税対象額</param>
        /// <param name="salSubttlSubToTaxFre">売上小計非課税対象額</param>
        /// <param name="salesOutTax">売上金額消費税額（外税）</param>
        /// <param name="salAmntConsTaxInclu">売上金額消費税額（内税）</param>
        /// <param name="salesDisTtlTaxExc">売上値引金額計（税抜）</param>
        /// <param name="itdedSalesDisOutTax">売上値引外税対象額合計</param>
        /// <param name="itdedSalesDisInTax">売上値引内税対象額合計</param>
        /// <param name="itdedSalesDisTaxFre">売上値引非課税対象額合計</param>
        /// <param name="salesDisOutTax">売上値引消費税額（外税）</param>
        /// <param name="salesDisTtlTaxInclu">売上値引消費税額（内税）</param>
        /// <param name="totalCost">原価金額計</param>
        /// <param name="balanceAdjust">消費税調整額</param>
        /// <param name="taxAdjust">残高調整額</param>
        /// <param name="salesPrtSubttlInc">売上部品小計（税込）</param>
        /// <param name="salesPrtSubttlExc">売上部品小計（税抜）</param>
        /// <param name="salesWorkSubttlInc">売上作業小計（税込）</param>
        /// <param name="salesWorkSubttlExc">売上作業小計（税抜）</param>
        /// <param name="itdedPartsDisInTax">部品値引対象額合計（税込）</param>
        /// <param name="itdedPartsDisOutTax">部品値引対象額合計（税抜）</param>
        /// <param name="itdedWorkDisInTax">作業値引対象額合計（税込）</param>
        /// <param name="itdedWorkDisOutTax">作業値引対象額合計（税抜）</param>
        /// <param name="totalMoneyForGrossProfit">粗利計算用売上金額</param>
        private void CalculationSalesTotalPrice( List<SalesDetailWork> salesDetailList, double consTaxRate, int salesTaxFrcProcCd, int totalAmountDispWayCd, int consTaxLayMethod, out long salesTotalTaxInc, out long salesTotalTaxExc, out long salesSubtotalTax, out long itdedSalesOutTax, out long itdedSalesInTax, out long salSubttlSubToTaxFre, out long salesOutTax, out long salAmntConsTaxInclu, out long salesDisTtlTaxExc, out long itdedSalesDisOutTax, out long itdedSalesDisInTax, out long itdedSalesDisTaxFre, out long salesDisOutTax, out long salesDisTtlTaxInclu, out long totalCost, out long stockGoodsTtlTaxExc, out long pureGoodsTtlTaxExc, out long balanceAdjust, out long taxAdjust, out long salesPrtSubttlInc, out long salesPrtSubttlExc, out long salesWorkSubttlInc, out long salesWorkSubttlExc, out long itdedPartsDisInTax, out long itdedPartsDisOutTax, out long itdedWorkDisInTax, out long itdedWorkDisOutTax, out long totalMoneyForGrossProfit )
        {
            // 消費税端数処理単位、端数処理区分を取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //this.GetFractionProcInfo( ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            this.GetSalesFractionProcInfo( ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD

            salesTotalTaxInc = 0;       // 売上伝票合計（税込）
            salesTotalTaxExc = 0;       // 売上伝票合計（税抜）
            salesSubtotalTax = 0;       // 売上小計（税）
            itdedSalesOutTax = 0;       // 売上外税対象額
            itdedSalesInTax = 0;        // 売上内税対象額
            salSubttlSubToTaxFre = 0;   // 売上小計非課税対象額
            salesOutTax = 0;            // 売上金額消費税額（外税）
            salAmntConsTaxInclu = 0;    // 売上金額消費税額（内税）
            salesDisTtlTaxExc = 0;      // 売上値引金額計（税抜）
            itdedSalesDisOutTax = 0;    // 売上値引外税対象額合計
            itdedSalesDisInTax = 0;     // 売上値引内税対象額合計
            itdedSalesDisTaxFre = 0;    // 売上値引非課税対象額合計
            salesDisOutTax = 0;         // 売上値引消費税額（外税）
            salesDisTtlTaxInclu = 0;    // 売上値引消費税額（内税）
            stockGoodsTtlTaxExc = 0;    // 在庫商品合計金額（税抜）
            pureGoodsTtlTaxExc = 0;     // 純正商品合計金額（税抜）
            totalCost = 0;              // 原価金額計
            taxAdjust = 0;              // 消費税調整額
            balanceAdjust = 0;          // 残高調整額
            salesPrtSubttlInc = 0;      // 売上部品小計（税込）
            salesPrtSubttlExc = 0;      // 売上部品小計（税抜）
            salesWorkSubttlInc = 0;     // 売上作業小計（税込）
            salesWorkSubttlExc = 0;     // 売上作業小計（税抜）
            itdedPartsDisInTax = 0;     // 部品値引対象額合計（税込）
            itdedPartsDisOutTax = 0;    // 部品値引対象額合計（税抜）
            itdedWorkDisInTax = 0;      // 作業値引対象額合計（税込）
            itdedWorkDisOutTax = 0;     // 作業値引対象額合計（税抜）
            totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            long itdedSalesInTax_TaxInc = 0;    // 売上内税対象額（税込）
            long itdedSalesDisInTax_TaxInc = 0; // 売上値引内税対象額合計（税込）
            long totalMoney_TaxInc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（内税商品分）
            long totalMoney_TaxExc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（外税商品分）
            long totalMoney_TaxNone_ForGrossProfitMoney = 0;    // 粗利計算用売上金額計（非課税商品分）
            long stockGoodsTtlTaxExc_TaxInc = 0;                // 在庫商品合計金額（税抜）（内税商品分）
            long stockGoodsTtlTaxExc_TaxExc = 0;                // 在庫商品合計金額（税抜）（外税商品分）
            long stockGoodsTtlTaxExc_TaxNone = 0;               // 在庫商品合計金額（税抜）（非課税商品分）
            long pureGoodsTtlTaxExc_TaxInc = 0;                 // 純正商品合計金額（税抜）（内税商品分）
            long pureGoodsTtlTaxExc_TaxExc = 0;                 // 純正商品合計金額（税抜）（外税商品分）
            long pureGoodsTtlTaxExc_TaxNone = 0;                // 純正商品合計金額（税抜）（非課税商品分）

            //-----------------------------------------------------------------------------
            // 計算に必要な金額の計算
            //-----------------------------------------------------------------------------
            #region ●計算に必要な金額の計算

            foreach ( SalesDetailWork salesDetail in salesDetailList )
            {
                // 売上伝票区分（明細）によって集計方法が変わる分
                switch ( salesDetail.SalesSlipCdDtl )
                {
                    // 売上、返品
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales:
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods:
                        {
                            // 税区分：外税
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc )
                            {
                                // 売上外税対象額
                                itdedSalesOutTax += salesDetail.SalesMoneyTaxExc;

                                // 売上金額消費税額（外税）
                                salesOutTax += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（外税商品分）
                                if ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock )
                                    stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（外税商品分）
                                if ( salesDetail.GoodsKindCode == 0 )
                                    pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                            }
                            // 税区分：内税
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc )
                            {
                                // 売上内税対象額
                                itdedSalesInTax += salesDetail.SalesMoneyTaxExc;

                                // 売上内税対象額（税込）
                                itdedSalesInTax_TaxInc += salesDetail.SalesMoneyTaxInc;

                                // 売上金額消費税額（内税）
                                salAmntConsTaxInclu += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（内税商品分）
                                if ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock )
                                    stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（内税商品分）
                                if ( salesDetail.GoodsKindCode == 0 )
                                    pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                            }
                            // 税区分：非課税
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone )
                            {
                                // 売上小計非課税対象額
                                salSubttlSubToTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 在庫商品合計金額（税抜）（非課税商品分）
                                if ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock )
                                    stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（非課税商品分）
                                if ( salesDetail.GoodsKindCode == 0 )
                                    pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                            }

                            // 売上部品小計（税込）
                            salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc;
                            // 売上部品小計（税抜）
                            salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc )
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc )
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone )
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // 値引き
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount:
                        {
                            // 税区分：外税
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc )
                            {
                                // 売上値引外税対象額合計
                                itdedSalesDisOutTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引消費税額（外税）
                                salesDisOutTax += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if ( salesDetail.ShipmentCnt != 0 )
                                {
                                    // 在庫商品合計金額（税抜）（外税商品分）
                                    if ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock )
                                        stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（外税商品分）
                                    if ( salesDetail.GoodsKindCode == 0 )
                                        pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：内税
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc )
                            {
                                // 売上値引内税対象額合計
                                itdedSalesDisInTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引内税対象額合計（税込）
                                itdedSalesDisInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                                // 売上値引消費税額（内税）
                                salesDisTtlTaxInclu += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if ( salesDetail.ShipmentCnt != 0 )
                                {
                                    // 在庫商品合計金額（税抜）（内税商品分）
                                    if ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock )
                                        stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（内税商品分）
                                    if ( salesDetail.GoodsKindCode == 0 )
                                        pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：非課税
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone )
                            {
                                // 売上値引非課税対象額合計
                                itdedSalesDisTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 商品値引きの場合
                                if ( salesDetail.ShipmentCnt != 0 )
                                {
                                    // 在庫商品合計金額（税抜）（非課税商品分）
                                    if ( salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock )
                                        stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（非課税商品分）
                                    if ( salesDetail.GoodsKindCode == 0 )
                                        pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                }
                            }

                            // 部品値引対象額合計（税込）
                            itdedPartsDisInTax += salesDetail.SalesMoneyTaxInc;

                            // 部品値引対象額合計（税抜）
                            itdedPartsDisOutTax += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc )
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc )
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone )
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // 注釈
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Annotation:
                        {
                            break;
                        }
                    // 作業
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Work:
                        {
                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc )
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc )
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if ( salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone )
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }
                            break;
                        }
                    // 小計
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal:
                        {
                            break;
                        }
                }

                if ( salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal )
                {
                    // 残高調整額
                    if ( (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust) )
                    {
                        balanceAdjust += salesDetail.SalesMoneyTaxInc;
                    }

                    // 消費税調整額
                    if ( (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust) )
                    {
                        taxAdjust += salesDetail.SalesPriceConsTax;
                    }
                }

            }

            // 売上値引金額計（税抜）
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // 粗利計算用売上金額計
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // 在庫商品合計金額（税抜）
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone;

            // 純正商品合計金額（税抜）
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone;

            #endregion

            #region ●転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            // 転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            if ( consTaxLayMethod == 9 )
            {
                // 売上金額消費税額（外税）
                salesOutTax = 0;

                // 売上金額消費税額（内税）
                salAmntConsTaxInclu = 0;

                // 売上小計非課税対象額
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // 売上外税対象額
                itdedSalesOutTax = 0;

                // 売上内税対象額
                itdedSalesInTax = 0;

                // 売上内税対象額（税込）
                itdedSalesInTax_TaxInc = 0;

                // 売上値引消費税額（外税）
                salesDisOutTax = 0;

                // 売上値引消費税額（内税）
                salesDisTtlTaxInclu = 0;

                // 売上値引非課税対象額合計
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // 売上値引外税対象額合計
                itdedSalesDisOutTax = 0;

                // 売上値引内税対象額合計
                itdedSalesDisInTax = 0;

                // 売上値引内税対象額合計（税込）
                itdedSalesDisInTax_TaxInc = 0;

                // 売上値引金額計（税抜）
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ●各種金額算出
            //-----------------------------------------------------------------------------
            // 各種金額算出
            //-----------------------------------------------------------------------------

            // 明細転嫁以外
            if ( consTaxLayMethod != 1 )
            {
                //-----------------------------------------------------------------------------
                // ① 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計 + 売上値引非課税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税込）： 売上内税対象額（税込） + 売上外税対象額 + 売上値引内税対象額合計（税込） + 売上値引外税対象額合計 + 売上値引非課税対象額合計 + (売上外税対象額 + 売上値引外税対象額合計)×税率)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc( consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax );

                //-----------------------------------------------------------------------------
                // ③ 売上小計（税）：② - ①
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // ④ 売上金額消費税額（外税）：売上外税対象額 × 税率
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc( consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax );

                //-----------------------------------------------------------------------------
                // ⑤ 売上金額消費税額（外税）(税抜、値引き含む) ：(売上外税対象額 + 売上値引外税対象額合計) × 税率
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc( consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax );

                //-----------------------------------------------------------------------------
                // ⑥ 売上値引消費税額（外税）：④ - ⑤
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;
            }
            // 明細転嫁
            else
            {
                //-----------------------------------------------------------------------------
                // ① 売上小計（税）：売上金額消費税額（外税） + 売上金額消費税額（内税） +  売上値引消費税額（外税） + 売上値引消費税額（内税）
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // ③ 売上伝票合計（税込）：① + ②
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion
        }
        # endregion
        # endregion

        # region [赤伝仕入関連]
        # region [仕入検索]
        /// <summary>
        /// 仕入データを検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="partySalesSlipNum">相手先伝票番号</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="targetDate">対象日</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="partySalesSlipNumSearchMode">仕入伝票番号検索モード(0:完全一致,1:前方一致,2:完全一致明細あり)</param>
        /// <param name="stockSlipList">仕入データリスト</param>
        /// <returns>STATUS</returns>
        private int ReadStockSlip( StockSlipLogicalKey key, out StockSlipWork stockSlip, out List<StockDetailWork> stockDetailList )
        {
            int partySalesSlipNumSearchMode = 2; // 2:完全一致明細あり

            // 仕入伝票読み込みパラメータ
            StockSlipWork paraStockSlipWork = new StockSlipWork();
            paraStockSlipWork.EnterpriseCode = key.EnterpriseCode;
            paraStockSlipWork.SupplierFormal = 0; // 0:仕入
            paraStockSlipWork.StockSectionCd = key.SectionCode;
            paraStockSlipWork.SupplierCd = key.SupplierCd;
            paraStockSlipWork.PartySaleSlipNum = key.PartySaleSlipNum;

            if ( paraStockSlipWork.SupplierFormal == 0 )
            {
                paraStockSlipWork.StockDate = key.StockDate;
            }
            else
            {
                paraStockSlipWork.ArrivalGoodsDay = key.StockDate;
            }
            // ---------- ADD 2012/08/22 ---------->>>>>
            paraStockSlipWork.StockDate = key.StockDate;
            // ---------- ADD 2012/08/22 ----------<<<<<
            return this.ReadStockSlipProc( paraStockSlipWork, partySalesSlipNumSearchMode, out stockSlip, out stockDetailList );
        }
        /// <summary>
        /// 仕入データを検索します。
        /// </summary>
        /// <param name="stockSlipWork">検索パラメータ(仕入ワークオブジェクト)</param>
        /// <param name="readMode">相手先伝番の検索モード</param>
        /// <param name="stockSlip"></param>
        /// <param name="stockDetailWorkList"></param>
        /// <returns>STATUS</returns>
        private int ReadStockSlipProc( StockSlipWork paraStockSlipWork, int readMode, out StockSlipWork stockSlip, out List<StockDetailWork> stockDetailWorkList )
        {
            stockSlip = null;
            stockDetailWorkList = null;
            CustomSerializeArrayList retList = new CustomSerializeArrayList();

            object retObj = (object)retList;
            object paraObj;

            paraObj = (object)paraStockSlipWork;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
            //int status = this._iStockSlipDB.SearchPartySaleSlipNum( ref retObj, paraObj, readMode );
            int status = _iCustPrtPprWorkDB.SearchPartySaleSlipNum( ref retObj, paraObj, readMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                CustomSerializeArrayList retCustomSerializeArrayList = (CustomSerializeArrayList)retObj;

                for ( int i = 0; i < retCustomSerializeArrayList.Count; i++ )
                {
                    if ( retCustomSerializeArrayList[i] is StockSlipWork )
                    {
                        stockSlip = (StockSlipWork)retCustomSerializeArrayList[i];
                    }
                    else if ( retCustomSerializeArrayList[i] is ArrayList )
                    {
                        stockDetailWorkList = new List<StockDetailWork>( (StockDetailWork[])((ArrayList)retCustomSerializeArrayList[i]).ToArray( typeof( StockDetailWork ) ) );
                    }
                }
            }
            return status;
        }
        # endregion

        # region [仕入明細金額算出]
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="priceInputType"></param>
        ///// <param name="stockUnitPrice"></param>
        //private void CalculateStockPrice(StockSlipWork stockSlip, StockDetailWork stockDetail, out double stockUnitPriceFl, out double stockUnitTaxPriceFl )
        //{
        //    // 原単価(税込)算出
        //    this.CalcTaxExcAndTaxIncForStock( stockDetail.TaxationCode, stockSlip.SupplierCd, stockSlip.SupplierConsTaxRate, stockSlip.SuppTtlAmntDspWayCd, stockDetail.StockUnitPriceFl, out stockUnitPriceFl, out stockUnitTaxPriceFl );


        //    //_stockPriceCalculate.CalcTaxIncFromTaxExc(
        //    //this._stockPriceCalculate.CalculatePrice( stockDetail.TaxationCode, stockPrice, taxRate, stockCnsTaxFrcProcCd, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax, out taxFracProcUnit, out taxFracProcCd );

        //    int stockMoneyFrcProcCd = 0;
        //    int taxFracProcCode = 0;
        //    long stockPriceTaxInc = 0;
        //    long stockPriceTaxExc = 0;
        //    long stockPriceConsTax = 0;
        //    CalculateStockPrice( stockDetail.StockCount, stockDetail.StockUnitPriceFl, stockDetail.TaxationCode, stockSlip.SupplierConsTaxRate, stockMoneyFrcProcCd, taxFracProcCode, out stockPriceTaxInc, out stockPriceTaxExc, out stockPriceConsTax );


        //    //// 端数処理コード取得
        //    //int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, this._stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);	// 仕入消費税端数処理コード

        //    //// 仕入金額処理区分・単位取得
        //    //int taxFracProcCd = 0;
        //    //double taxFracProcUnit = 0;
        //    //this.GetStockFractionProcInfo(StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

        //    //// 単価算出
        //    //this.CalculateStockPrice(priceInputType, stockUnitPrice, row.TaxationCode, this._stockSlip.SuppTtlAmntDspWayCd, this._stockSlip.SuppCTaxLayCd, this._stockSlip.SupplierConsTaxRate, stockTaxFrcProcCd, out  stockUnitPriceFl, out stockUnitTaxPriceFl, out stockUnitPriceDisplay);

        //    //row.StockUnitPriceFl = stockUnitPriceFl;
        //    //row.StockUnitTaxPriceFl = stockUnitTaxPriceFl;
        //    //row.StockUnitPriceDisplay = stockUnitPriceDisplay;
        //}
        /// <summary>
        /// 指定した消費税率を元に仕入明細データ行オブジェクトの金額情報を更新します。
        /// </summary>
        /// <param name="taxRate">消費税率</param>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード</param>
        public void CalculateStockPrice( StockSlipWork stockSlip, StockDetailWork stockDetail, out double stockUnitPriceFl, out double stockUnitTaxPriceFl, out long stockPriceTaxExc, out long stockPriceTaxInc, out long stockPriceConsTax )
        {
            stockUnitPriceFl = 0;
            stockUnitTaxPriceFl = 0;
            stockPriceTaxExc = 0;
            stockPriceTaxInc = 0;
            stockPriceConsTax = 0;

            // 原単価(税込)算出
            this.CalcTaxExcAndTaxIncForStock( stockDetail.TaxationCode, stockSlip.SupplierCd, stockSlip.SupplierConsTaxRate, stockSlip.SuppTtlAmntDspWayCd, stockDetail.StockUnitPriceFl, out stockUnitPriceFl, out stockUnitTaxPriceFl );


            // 仕入金額端数処理コード
            int stockMoneyFrcProcCd = this._supplierAcs.GetStockFractionProcCd( this._enterpriseCode, stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd );
            // 消費税端数処理区分
            int taxFracProcCode = this._supplierAcs.GetStockFractionProcCd( this._enterpriseCode, stockSlip.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd );


            // 非課税時は税込金額＝税抜き金額
            if ( stockSlip.SuppCTaxLayCd == 9 )
                {
                    stockDetail.StockPriceTaxInc = stockDetail.StockPriceTaxExc;
                    stockDetail.StockUnitTaxPriceFl = stockDetail.StockUnitPriceFl;
                }
                //else if ( stockDetail.StockGoodsCd == 6 )
                //{
                //    //this.CalculateStockPrice( row );
                //}
                else
                {
                    // 課税区分が「外税」の場合
                    if ( stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxExc )
                    {
                        //long stockPriceTaxInc;
                        //long stockPriceTaxExc;
                        //long stockPriceConsTax;
                        double stockUnitPrice = stockDetail.StockUnitPriceFl;

                        if ( this.CalculateStockPrice(
                            stockDetail.StockCount,
                            stockUnitPrice,
                            stockDetail.TaxationCode,
                            stockSlip.SupplierConsTaxRate,
                            stockMoneyFrcProcCd,
                            taxFracProcCode,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax ) )
                        {
                            if ( stockDetail.StockGoodsCd <= 1 )
                            {
                                stockDetail.StockPriceTaxInc = stockPriceTaxInc;
                            }
                        }
                    }
                    // 課税区分が「内税」の場合
                    else if ( stockDetail.TaxationCode == (int)CalculateTax.TaxationCode.TaxInc )
                    {
                        //long stockPriceTaxInc;
                        //long stockPriceTaxExc;
                        //long stockPriceConsTax;
                        double stockUnitPrice = stockDetail.StockUnitPriceFl;

                        if ( this.CalculateStockPrice(
                            stockDetail.StockUnitPriceFl,
                            stockUnitPrice,
                            stockDetail.TaxationCode,
                            stockSlip.SupplierConsTaxRate,
                            stockMoneyFrcProcCd,
                            taxFracProcCode,
                            out stockPriceTaxInc,
                            out stockPriceTaxExc,
                            out stockPriceConsTax ) )
                        {
                            if ( stockDetail.StockGoodsCd <= 1 )
                            {
                                stockDetail.StockPriceTaxExc = stockPriceTaxExc;
                            }
                        }
                    }
            }
        }
        /// <summary>
        /// 仕入金額を計算します。
        /// </summary>
        /// <param name="stockCount">仕入数</param>
        /// <param name="stockUnitPrice">仕入単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="stockMoneyFrcProcCd">仕入金額端数処理コード</param>
        /// <param name="taxFracProcCode">消費税端数処理区分</param>
        /// <param name="stockPriceTaxInc">仕入金額（税込み）</param>
        /// <param name="stockPriceTaxExc">仕入金額（税抜き）</param>
        /// <param name="stockPriceConsTax">仕入消費税</param>
        /// <returns></returns>
        private bool CalculateStockPrice( double stockCount, double stockUnitPrice, int taxationCode, double taxRate, int stockMoneyFrcProcCd, int taxFracProcCode,
            out long stockPriceTaxInc, out long stockPriceTaxExc, out long stockPriceConsTax )
        {
            double taxFracProcUnit;
            int taxFracProcCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //GetStockFractionProcInfo( StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            GetStockFractionProcInfo( ctFracProcMoneyDiv_Tax, taxFracProcCode, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD

            stockPriceTaxInc = 0;
            stockPriceTaxExc = 0;
            stockPriceConsTax = 0;

            // 仕入数が0または仕入単価が0の場合はすべて0で終了
            if ( (stockCount == 0) || (stockUnitPrice == 0) ) return true;

            // 外税の場合
            if ( taxationCode == (int)CalculateTax.TaxationCode.TaxExc )
            {
                double unitPriceExc = stockUnitPrice;	// 単価（税抜き）
                double unitPriceInc;					// 単価（税込み）
                double unitPriceTax;					// 単価（消費税）
                long priceExc = 0;						// 価格（税抜き）
                long priceInc;							// 価格（税込み）
                long priceTax;							// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc( (int)CalculateTax.TaxationCode.TaxExc, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd );

                stockPriceTaxInc = priceInc;			// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;			// 仕入金額（税抜き）		
                stockPriceConsTax = priceTax;			// 仕入消費税
            }
            // 内税の場合
            else if ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc )
            {
                double unitPriceExc;					// 単価（税抜き）
                double unitPriceInc = stockUnitPrice;	// 単価（税込み）
                double unitPriceTax;					// 単価（消費税）
                long priceExc;							// 価格（税抜き）
                long priceInc = 0;						// 価格（税込み）
                long priceTax;							// 価格（消費税）

                this._stockPriceCalculate.CalcTaxExcFromTaxInc( (int)CalculateTax.TaxationCode.TaxInc, stockCount, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd );

                stockPriceTaxInc = priceInc;			// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;			// 仕入金額（税抜き）
                stockPriceConsTax = priceTax;			// 仕入消費税
            }
            // 非課税の場合
            else if ( taxationCode == (int)CalculateTax.TaxationCode.TaxNone )
            {
                double unitPriceExc = stockUnitPrice;	// 単価（税抜き）
                double unitPriceInc;					// 単価（税込み）
                double unitPriceTax;					// 単価（消費税）
                long priceExc = 0;						// 価格（税抜き）
                long priceInc;							// 価格（税込み）
                long priceTax;							// 価格（消費税）

                this._stockPriceCalculate.CalcTaxIncFromTaxExc( (int)CalculateTax.TaxationCode.TaxNone, stockCount, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, stockMoneyFrcProcCd, taxRate, taxFracProcUnit, taxFracProcCd );

                stockPriceTaxInc = priceExc;			// 仕入金額（税込み）
                stockPriceTaxExc = priceExc;			// 仕入金額（税込み）
                stockPriceConsTax = priceTax;			// 仕入消費税
            }

            return true;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
        ///// <summary>
        ///// 仕入金額処理区分設定マスタキャッシュ処理
        ///// </summary>
        ///// <param name="stockProcMoney">仕入金額処理区分設定マスタワーククラス</param>
        //internal void CacheStockProcMoney( StockProcMoney stockProcMoney )
        //{
        //    try
        //    {
        //        _stockProcMoneyDataTable.AddStockProcMoneyRow( this.RowFromUIData( stockProcMoney ) );
        //    }
        //    catch ( ConstraintException )
        //    {
        //        SalesInputInitialDataSet.StockProcMoneyRow row = _stockProcMoneyDataTable.FindByFracProcMoneyDivFractionProcCodeUpperLimitPrice( stockProcMoney.FracProcMoneyDiv, stockProcMoney.FractionProcCode, stockProcMoney.UpperLimitPrice );
        //        this.SetRowFromUIData( ref row, stockProcMoney );
        //    }
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
        ///// <summary>
        ///// 仕入金額処理区分設定マスタオブジェクト→仕入金額処理区分設定マスタ行オブジェクト設定処理
        ///// </summary>
        ///// <param name="row">仕入金額処理区分設定マスタ行クラス</param>
        ///// <param name="stockProcMoney">仕入金額処理区分設定マスタワーククラス</param>
        //internal void SetRowFromUIData( ref SalesInputInitialDataSet.StockProcMoneyRow row, StockProcMoney stockProcMoney )
        //{
        //    // 端数処理対象金額区分
        //    row.FracProcMoneyDiv = stockProcMoney.FracProcMoneyDiv;

        //    // 端数処理コード
        //    row.FractionProcCode = stockProcMoney.FractionProcCode;

        //    // 上限金額
        //    row.UpperLimitPrice = stockProcMoney.UpperLimitPrice;

        //    // 端数処理単位
        //    row.FractionProcUnit = stockProcMoney.FractionProcUnit;

        //    // 端数処理区分
        //    row.FractionProcCd = stockProcMoney.FractionProcCd;
        //}

        ///// <summary>
        ///// 仕入金額処理区分設定マスタオブジェクト→仕入金額処理区分設定マスタ行オブジェクト変換処理
        ///// </summary>
        ///// <param name="stockProcMoney">仕入金額処理区分設定マスタオブジェクト</param>
        ///// <returns>仕入金額処理区分設定マスタ行オブジェクト</returns>
        //internal SalesInputInitialDataSet.StockProcMoneyRow RowFromUIData( StockProcMoney stockProcMoney )
        //{
        //    SalesInputInitialDataSet.StockProcMoneyRow row = _stockProcMoneyDataTable.NewStockProcMoneyRow();

        //    this.SetRowFromUIData( ref row, stockProcMoney );
        //    return row;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL

        /// <summary>
        /// 対象価格から、税抜金額、税込金額、表示金額を計算します
        /// </summary>
        /// <param name="priceInputType">価格入力モード</param>
        /// <param name="unitPrice">対象価格</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="suppCTaxLayCd">仕入先消費税転嫁方式コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="stockTaxFrcProcCd">仕入消費税端数処理コード</param>
        /// <param name="unitPriceTaxExc">税抜金額</param>
        /// <param name="unitPriceTaxInc">税込金額</param>
        /// <param name="unitPriceDisplay">表示金額</param>
        //private void CalculatePrice( PriceInputType priceInputType, double unitPrice, int taxationCode, int totalAmountDispWayCd, int suppCTaxLayCd, double taxRate, int stockTaxFrcProcCd, out  double unitPriceTaxExc, out  double unitPriceTaxInc, out  double unitPriceDisplay )
        private void CalculateStockPrice( /*PriceInputType priceInputType,*/ double unitPrice, int taxationCode, int totalAmountDispWayCd, int suppCTaxLayCd, double taxRate, int stockTaxFrcProcCd, out  double unitPriceTaxExc, out  double unitPriceTaxInc/*, out  double unitPriceDisplay*/ )
        {
            unitPriceTaxExc = 0;
            unitPriceTaxInc = 0;
            //unitPriceDisplay = 0;

            if ( unitPrice == 0 ) return;

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 DEL
            //this.GetStockFractionProcInfo( StockSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
            this.GetStockFractionProcInfo( ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD

            //// 入力タイプ
            //switch ( priceInputType )
            //{
            //    // 税抜き価格
            //    case PriceInputType.PriceTaxExc:
            //        {
                        if ( (taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (suppCTaxLayCd == 9) )
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice;
                        }
                        else
                        {
                            unitPriceTaxExc = unitPrice;
                            unitPriceTaxInc = unitPrice + CalculateTax.GetTaxFromPriceExc( taxRate, taxFracProcUnit, taxFracProcCd, unitPrice );
                        }

                        //break;
                    //}
                //// 税込み価格
                //case PriceInputType.PriceTaxInc:
                //    {
                //        if ( (taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (suppCTaxLayCd == 9) )
                //        {
                //            unitPriceTaxExc = unitPrice;
                //            unitPriceTaxInc = unitPrice;
                //        }
                //        else
                //        {
                //            unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc( taxRate, taxFracProcUnit, taxFracProcCd, unitPrice );
                //            unitPriceTaxInc = unitPrice;
                //        }

                //        break;
                //    }
                //// 表示価格
                //case PriceInputType.PriceDisplay:
                //    {
                //        if ( suppCTaxLayCd == 9 )
                //        {
                //            unitPriceTaxExc = unitPrice;
                //            unitPriceTaxInc = unitPrice;
                //        }
                //        // 総額表示しない
                //        else if ( totalAmountDispWayCd == 0 )
                //        {
                //            // 課税区分が「課税（内税）」の場合
                //            if ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc )
                //            {
                //                unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc( taxRate, taxFracProcUnit, taxFracProcCd, unitPrice );
                //                unitPriceTaxInc = unitPrice;
                //            }
                //            // 課税区分が「課税」の場合
                //            else if ( taxationCode == (int)CalculateTax.TaxationCode.TaxExc )
                //            {
                //                unitPriceTaxExc = unitPrice;
                //                unitPriceTaxInc = unitPrice + CalculateTax.GetTaxFromPriceExc( taxRate, taxFracProcUnit, taxFracProcCd, unitPrice );
                //            }
                //            // 課税区分が「非課税」の場合
                //            else
                //            {
                //                unitPriceTaxExc = unitPrice;
                //                unitPriceTaxInc = unitPrice;
                //            }
                //        }
                //        // 総額表示する
                //        else
                //        {
                //            // 課税区分が「課税（内税）」の場合
                //            if ( taxationCode == (int)CalculateTax.TaxationCode.TaxInc )
                //            {
                //                unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc( taxRate, taxFracProcUnit, taxFracProcCd, unitPrice );
                //                unitPriceTaxInc = unitPrice;
                //            }
                //            // 課税区分が「課税」の場合
                //            else if ( taxationCode == (int)CalculateTax.TaxationCode.TaxExc )
                //            {
                //                unitPriceTaxExc = unitPrice - CalculateTax.GetTaxFromPriceInc( taxRate, taxFracProcUnit, taxFracProcCd, unitPrice );
                //                unitPriceTaxInc = unitPrice;
                //            }
                //            // 課税区分が「非課税」の場合
                //            else
                //            {
                //                unitPriceTaxExc = unitPrice;
                //                unitPriceTaxInc = unitPrice;
                //            }
                //        }
                //        break;
                //    }
            //}

            //// 非課税の仕入先は税抜き金額を表示する
            //if ( suppCTaxLayCd == 9 )
            //{
            //    unitPriceDisplay = unitPriceTaxExc;
            //}
            //// 総額表示か内税は税込み金額を表示する
            //else if ( (totalAmountDispWayCd == 1) || (taxationCode == (int)CalculateTax.TaxationCode.TaxInc) )
            //{
            //    unitPriceDisplay = unitPriceTaxInc;
            //}
            //else
            //{
            //    unitPriceDisplay = unitPriceTaxExc;
            //}
        }
        # endregion
        # endregion

        # region [赤伝商品情報関連]
        /// <summary>
        /// 商品情報読み込み
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsUnitData"></param>
        /// <returns>DB.STATUS</returns>
        public int ReadGoods( string goodsNo, int goodsMakerCd, out GoodsUnitData goodsUnitData )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            goodsUnitData = null;

            // キャッシュから探す
            GoodsKey key = new GoodsKey( goodsNo, goodsMakerCd );
            if ( _goodsUnitDataDic.ContainsKey( key ) )
            {
                goodsUnitData = _goodsUnitDataDic[key];
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                // 商品読み込み(goodsUnitDataには在庫リストが含まれる)
                //status = _goodsAcs.Read(this._enterpriseCode, goodsMakerCd, goodsNo, ConstantManagement.LogicalMode.GetData0, out goodsUnitData); // 2012.02.25 橋本 DEL
                // 仕入先データ取得しない。商品不足情報取得しない。
                status = _goodsAcs.ReadFromCustPtrSales(this._enterpriseCode, "", goodsMakerCd, goodsNo, 1, 2, ConstantManagement.LogicalMode.GetData0, out goodsUnitData); // 2012.02.25 橋本 ADD

                // ディクショナリに追加
                if ( !_goodsUnitDataDic.ContainsKey( new GoodsKey( goodsUnitData ) ) )
                {
                    _goodsUnitDataDic.Add( new GoodsKey( goodsUnitData ), goodsUnitData );
                }
            }
            return status;
        }
        /// <summary>
        /// 在庫取得処理
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="warehouseCode"></param>
        /// <param name="retStock"></param>
        /// <returns>DB.STATUS</returns>
        public int SelectStock( GoodsUnitData goodsUnitData, string warehouseCode, out Stock retStock )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            retStock = null;

            // パラメータチェック処理
            if ( goodsUnitData == null ||
                 warehouseCode.Trim() == string.Empty ||
                 goodsUnitData.StockList == null ||
                 goodsUnitData.StockList.Count == 0 )
            {
                return status;
            }

            // リスト内から探す
            retStock = goodsUnitData.StockList.Find(
                        delegate( Stock stock )
                        {
                            return (stock.WarehouseCode.Trim() == warehouseCode.Trim());
                        }
                        );

            if ( retStock != null )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }
        /// <summary>
        /// 商品キャッシュクリア
        /// </summary>
        public void ClearGoodsInfoCache()
        {
            if ( _goodsUnitDataDic != null )
            {
                _goodsUnitDataDic.Clear();
            }
        }
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
        ///// <summary>
        ///// 売上金額処理区分マスタ比較クラス(上限金額(降順))
        ///// </summary>
        //private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        //{
        //    public override int Compare( SalesProcMoney x, SalesProcMoney y )
        //    {
        //        int result = y.UpperLimitPrice.CompareTo( x.UpperLimitPrice );
        //        return result;
        //    }
        //}
        ///// <summary>
        ///// 仕入金額処理区分マスタ比較クラス(上限金額(降順))
        ///// </summary>
        //private class StockProcMoneyComparer : Comparer<StockProcMoney>
        //{
        //    public override int Compare( StockProcMoney x, StockProcMoney y )
        //    {
        //        int result = y.UpperLimitPrice.CompareTo( x.UpperLimitPrice );
        //        return result;
        //    }
        //}
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/06 ADD
        /// <summary>
        /// 売上金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare( SalesProcMoney x, SalesProcMoney y )
            {
                int result = x.UpperLimitPrice.CompareTo( y.UpperLimitPrice );
                return result;
            }
        }
        /// <summary>
        /// 仕入金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        private class StockProcMoneyComparer : Comparer<StockProcMoney>
        {
            public override int Compare( StockProcMoney x, StockProcMoney y )
            {
                int result = x.UpperLimitPrice.CompareTo( y.UpperLimitPrice );
                return result;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/06 ADD   
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/08 ADD
        /// <summary>
        /// 伝票印刷設定情報取得処理
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="sectionCode"></param>
        /// <param name="customerCode"></param>
        /// <returns></returns>
        private SlipPrtSet GetPrtSlipSet( SlipTypeController.SlipKind slipKind, string sectionCode, int customerCode )
        {
            SlipTypeController stc = new SlipTypeController();
            stc.EnterpriseCode = this._enterpriseCode;
            stc.SlipPrtSetList = this._slipPrtSetList;
            stc.CustSlipMngList = this._custSlipMngList;

            SlipPrtSet slipPrtSet;
            int status = stc.GetSlipType( slipKind, out slipPrtSet, sectionCode, customerCode );

            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                slipPrtSet = null;
            }
            return slipPrtSet;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/08 ADD

        // --- ADD 2011/08/31 ---------->>>>>
        /// <summary>
        /// 伝票備考、伝票備考２、伝票備考３の入力桁数取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <remarks>
        /// <br>Note		: 伝票備考、伝票備考２、伝票備考３の入力桁数取得処理。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2011/08/31</br>
        /// </remarks>
        public void GetNoteCharCnt(string sectionCode, int customerCode)
        {
            // (伝票印刷パターン設定)
            if (_slipPrtSetList == null)
            {
                SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
                ArrayList retList;
                int retStatus = slipPrtSetAcs.SearchAllSlipPrtSet(out retList, this._enterpriseCode);
                if (retStatus == 0)
                {
                    _slipPrtSetList = new List<SlipPrtSet>((SlipPrtSet[])retList.ToArray(typeof(SlipPrtSet)));
                }
                else
                {
                    _slipPrtSetList = new List<SlipPrtSet>();
                }
            }
            // (伝票設定)
            if (_custSlipMngList == null)
            {
                CustSlipMngAcs custSlipMngAcs = new CustSlipMngAcs();
                ArrayList retList;
                int totalCnt;
                int retStatus = custSlipMngAcs.SearchAll(out totalCnt, this._enterpriseCode);

                if (retStatus == 0)
                {
                    retList = custSlipMngAcs.CustSlipMngList;
                    _custSlipMngList = new List<CustSlipMng>((CustSlipMng[])retList.ToArray(typeof(CustSlipMng)));
                }
                else
                {
                    _custSlipMngList = new List<CustSlipMng>();
                }
            }

            SlipPrtSet slipPrtSet = this.GetPrtSlipSet(SlipTypeController.SlipKind.SalesSlip, sectionCode.Trim(), customerCode);

            if (slipPrtSet != null)
            {
                this.SlipNoteCharCnt = slipPrtSet.SlipNoteCharCnt;
                this.SlipNote2CharCnt = slipPrtSet.SlipNote2CharCnt;
                this.SlipNote3CharCnt = slipPrtSet.SlipNote3CharCnt;
            }
        }
        // --- ADD 2011/08/31 ----------<<<<<

        #region ■オプション情報制御処理

        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009/09/07</br>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●車両管理オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_CarMngDiv = (int)Option.ON;
            }
            else
            {
                this._opt_CarMngDiv = (int)Option.OFF;
            }
            #endregion
        }
        #endregion ■オプション情報制御処理

        // ---------- ADD 2013/01/15 ---------->>>>>
        #region [■仕入返品予定データ作成処理]

        /// <summary>
        /// 仕入返品予定データ作成（仕入データ）
        /// </summary>
        /// <param name="redStockSlip">仕入データ</param>
        /// <param name="parameter">パラメータ</param>
        /// <remarks>
	    /// <br>Note       : 仕入返品予定データの内　仕入データを作成する</br>
	    /// <br>Programmer : FSI菅原　要</br>
	    /// <br>Date       : 2013/01/15</br>
        /// <br>UpdateNote : 仕入日のセット内容修正</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2013/02/18</br>
        /// <br>UpdateNote : 画面上の備考をセットするよう修正</br>
        /// <br>Programmer : FSI斎藤 和宏</br>
        /// <br>Date       : 2013/02/27</br>
        /// </remarks>
        private void CreateStockSlipRetGoodsExpectedData(ref StockSlipWork stockSlip, RedSlipWriteParameter parameter)
        {
            //--------------------------------------------------------------------
            // ※売上データ読み込み時に同時に取得した、
            // 　同時入力仕入データを元にして、新たに追加用レコードを生成します。
            //   （仕入データへの追加レコード）
            //--------------------------------------------------------------------

            // 画面上の「伝票区分」の指定から、伝票区分の設定値を決定
            int supplierSlipCd; // 10:仕入,20:返品
            if (parameter.SlipCd == 0)
            {
                supplierSlipCd = 10; // 10:仕入
            }
            else
            {
                supplierSlipCd = 20; // 20:返品
            }

            // 共通ファイルヘッダ　初期値を設定
            stockSlip.CreateDateTime = DateTime.MinValue;               // 作成日時
            stockSlip.UpdateDateTime = DateTime.MinValue;               // 更新日時
            stockSlip.EnterpriseCode = _enterpriseCode;                 // 企業コード（ログイン企業コード）
            stockSlip.FileHeaderGuid = Guid.Empty;                      // GUID
            stockSlip.UpdEmployeeCode = string.Empty;                   // 更新従業員コード
            stockSlip.UpdAssemblyId1 = string.Empty;                    // 更新アセンブリID1
            stockSlip.UpdAssemblyId2 = string.Empty;                    // 更新アセンブリID2
            stockSlip.LogicalDeleteCode = 0;                            // 論理削除区分

            // 取得した仕入データから更新する部分（固定値）
            stockSlip.SupplierFormal = 3;                               // 仕入形式　3:返品予定

            // 取得した仕入データから更新する部分（初期値）
            stockSlip.SupplierSlipNo = 0;                               // 仕入伝票番号
            stockSlip.DebitNoteDiv = 0;                                 // 赤伝区分
            stockSlip.DebitNLnkSuppSlipNo = 0;                          // 赤黒連結仕入伝票番号
            stockSlip.StockSlipUpdateCd = 0;                            // 仕入伝票更新区分
            stockSlip.DelayPaymentDiv = 0;                              // 来勘区分
            stockSlip.EdiSendDate = DateTime.MinValue;                  // ＥＤＩ送信日
            stockSlip.EdiTakeInDate = DateTime.MinValue;                // ＥＤＩ取込日
            stockSlip.UoeRemark1 = string.Empty;                        // ＵＯＥリマーク１
            stockSlip.UoeRemark2 = string.Empty;                        // ＵＯＥリマーク２
            stockSlip.SlipPrintDivCd = 0;                               // 伝票発行区分
            stockSlip.SlipPrintFinishCd = 0;                            // 伝票発行済区分
            // --- DEL 2013/02/18 ---------->>>>>
            //stockSlip.StockSlipPrintDate = DateTime.MinValue;         // 仕入伝票発行日
            // --- DEL 2013/02/18 ----------<<<<<
            stockSlip.SlipPrtSetPaperId = string.Empty;                 // 伝票印刷設定用帳票ID
            stockSlip.PartySaleSlipNum = string.Empty;                  // 相手先伝票番号（画面上の「仕入伝票番号」を設定するが、予定データ作成時は未入力状態のため初期値を設定）
            // --- ADD 2013/02/18 ---------->>>>>
            stockSlip.StockDate = DateTime.MinValue;                    // 仕入日
            // --- ADD 2013/02/18 ----------<<<<<

            // 取得した仕入データから更新する部分
            stockSlip.SectionCode = _loginSectionCode;                  // 拠点コード（ログイン拠点コード）
            stockSlip.InputDay = DateTime.Today;                        // 入力日（システム日付）
            stockSlip.ArrivalGoodsDay = DateTime.MinValue;              // 入荷日
            // --- DEL 2013/02/18 ---------->>>>>
            //stockSlip.StockDate = parameter.SalesDate;                  // 仕入日（画面上の「売上日」を設定）
            // --- DEL 2013/02/18 ----------<<<<<
            stockSlip.StockAddUpADate = DateTime.MinValue;              // 仕入計上日付

            // --- ADD 2013/02/18 ---------->>>>>
            stockSlip.StockSlipPrintDate = parameter.SalesDate;         // 仕入伝票発行日(画面上の売上日)
            // --- ADD 2013/02/18 ----------<<<<<
            string stockInputCode = parameter.InputEmployeeCd;　        // 以下の項目は、画面上の「発行者」を設定
            string stockInputName = parameter.InputEmployeeNm;
            stockSlip.StockInputCode = stockInputCode;                  // 　仕入入力者コード
            stockSlip.StockInputName = stockInputName;                  // 　仕入入力者名称
            stockSlip.StockAgentCode = stockInputCode;                  // 　仕入担当者コード
            stockSlip.StockAgentName = stockInputName;                  // 　仕入担当者名称

            stockSlip.SupplierSlipCd = supplierSlipCd;                  // 仕入伝票区分 画面上の「伝票区分」の指定から設定値を決定して設定
            stockSlip.RetGoodsReasonDiv = parameter.RetGoodsReasonDiv;  // 返品理由コード 画面上の「返品理由コード」を設定
            stockSlip.RetGoodsReason = parameter.ReturnReason;          // 返品理由　   画面上の「返品理由」を設定

            // --- ADD 2013/02/18 ---------->>>>>
            stockSlip.SupplierSlipNote1 = parameter.SlipNote.Trim();    // 備考
            stockSlip.SupplierSlipNote2 = parameter.SlipNote2.Trim();   // 備考２
            // --- ADD 2013/02/18 ----------<<<<<
        }

        /// <summary>
        /// 仕入返品予定データ作成（仕入明細データ）
        /// </summary>
        /// <param name="stockSlip">仕入データ</param>
        /// <param name="stockSlipDetail">仕入明細データ</param>
        /// <param name="rowView">明細View</param>
        /// <param name="redSalesDetailList">明細リスト</param>
        /// <param name="rgdsExpctRowCount">仕入行番号カウンタ</param>
        /// <param name="parameter">パラメータ</param>
        /// <remarks>
        /// <br>Note       : 仕入返品予定データの内　仕入明細データを作成する</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2013/01/15</br>
        /// </remarks>
        private void CreateStockSlipDetailRetGoodsExpectedData(StockSlipWork stockSlip, ref StockDetailWork stockSlipDetail, DataRowView rowView, List<SalesDetailWork> redSalesDetailList, int rgdsExpctRowCount, RedSlipWriteParameter parameter)
        {
            //--------------------------------------------------------------------
            // ※売上データ読み込み時に同時に取得した、
            // 　同時入力仕入データを元にして、新たに追加用レコードを生成します。
            //   （仕入明細データへの追加レコード）
            //--------------------------------------------------------------------

            // 画面上の「伝票区分」の指定から、伝票区分の設定値を決定
            int stockSlipCdDtl; // 0:仕入,1:返品,2:値引
            if (parameter.SlipCd == 0)
            {
                stockSlipCdDtl = 0; // 0:仕入
            }
            else
            {
                stockSlipCdDtl = 1; // 1:返品
            }

            // 元の仕入明細データの仕入形式、仕入明細通番を退避
            // この値を予定データの仕入形式（元）、仕入明細通番（元）へ設定する
            long stockSlipDtlNum = stockSlipDetail.StockSlipDtlNum;
            //int supplierFormal = stockSlipDetail.SupplierFormal;

            // 共通ファイルヘッダ　初期値を設定
            stockSlipDetail.CreateDateTime = DateTime.MinValue;                     // 作成日時
            stockSlipDetail.UpdateDateTime = DateTime.MinValue;                     // 更新日時
            stockSlipDetail.EnterpriseCode = _enterpriseCode;                       // 企業コード（ログイン企業コード）
            stockSlipDetail.FileHeaderGuid = Guid.Empty;                            // GUID
            stockSlipDetail.UpdEmployeeCode = string.Empty;                         // 更新従業員コード
            stockSlipDetail.UpdAssemblyId1 = string.Empty;                          // 更新アセンブリID1
            stockSlipDetail.UpdAssemblyId2 = string.Empty;                          // 更新アセンブリID2
            stockSlipDetail.LogicalDeleteCode = 0;                                  // 論理削除区分

            // 取得した仕入明細データから更新する部分（固定値）
            stockSlipDetail.SupplierFormal = 3;                                     // 仕入形式　3:返品予定
            stockSlipDetail.SupplierFormalSrc = -1;                                 // 仕入形式（元）

            // 取得した仕入明細データから更新する部分（初期値）
            stockSlipDetail.SalesSlipDtlNumSync = 0;                                // 売上明細通番（同時）
            stockSlipDetail.SupplierSlipNo = 0;                                     // 仕入伝票番号
            stockSlipDetail.CommonSeqNo = 0;                                        // 共通通番
            stockSlipDetail.StockSlipDtlNum = 0;                                    // 仕入明細通番
            stockSlipDetail.RemainCntUpdDate = DateTime.MinValue;                   // 残数更新日
            stockSlipDetail.StockDtiSlipNote1 = string.Empty;                       // 仕入伝票明細備考1
            stockSlipDetail.SlipMemo1 = string.Empty;                               // 伝票メモ１
            stockSlipDetail.SlipMemo2 = string.Empty;                               // 伝票メモ２
            stockSlipDetail.SlipMemo3 = string.Empty;                               // 伝票メモ３
            stockSlipDetail.InsideMemo1 = string.Empty;                             // 社内メモ１
            stockSlipDetail.InsideMemo2 = string.Empty;                             // 社内メモ２
            stockSlipDetail.InsideMemo3 = string.Empty;                             // 社内メモ３
            stockSlipDetail.AddresseeCode = 0;                                      // 納品先コード
            stockSlipDetail.AddresseeName = string.Empty;                           // 納品先名称
            stockSlipDetail.DirectSendingCd = 0;                                    // 直送区分
            stockSlipDetail.OrderNumber = string.Empty;                             // 発注番号
            stockSlipDetail.WayToOrder = 0;                                         // 注文方法
            stockSlipDetail.DeliGdsCmpltDueDate = DateTime.MinValue;                // 納品完了予定日
            stockSlipDetail.ExpectDeliveryDate = DateTime.MinValue;                 // 希望納期
            stockSlipDetail.OrderDataCreateDiv = 0;                                 // 発注データ作成区分
            stockSlipDetail.OrderDataCreateDate = DateTime.MinValue;                // 発注データ作成日
            stockSlipDetail.OrderFormIssuedDiv = 0;                                 // 発注書発行済区分
            //stockSlipDetail.StockSlipDtlNumSrc = 0;                                 // 仕入明細通番（元）
            stockSlipDetail.AcptAnOdrStatusSync = 0;                                // 受注ステータス（同時）
            stockSlipDetail.WarehouseCode = string.Empty;                           // 倉庫コード
            stockSlipDetail.WarehouseName = string.Empty;                           // 倉庫名称
            stockSlipDetail.WarehouseShelfNo = string.Empty;                        // 倉庫棚番
            stockSlipDetail.StockOrderDivCd = 0;                                    // 仕入在庫取寄せ区分

            // 取得した仕入明細データから更新する部分（仕入返品予定データ（仕入データ）の内容を設定）
            stockSlipDetail.StockInputCode = stockSlip.StockInputCode;              // 仕入入力者コード
            stockSlipDetail.StockInputName = stockSlip.StockInputName;              // 仕入入力者名称
            stockSlipDetail.StockAgentCode = stockSlip.StockAgentCode;              // 仕入担当者コード
            stockSlipDetail.StockAgentName = stockSlip.StockAgentName;              // 仕入担当者名称
            stockSlipDetail.SupplierCd = stockSlip.SupplierCd;                      // 仕入先コード
            stockSlipDetail.SupplierSnm = stockSlip.SupplierSnm;                    // 仕入先略称

            // 取得した仕入明細データから更新する部分（仕入返品予定データ（仕入明細データ）の別カラムの内容を設定）
            //stockSlipDetail.SupplierFormalSrc = supplierFormal;                     // 仕入形式（元）　元の仕入明細データの仕入形式を設定
            stockSlipDetail.StockSlipDtlNumSrc = stockSlipDtlNum;                   // 仕入明細通番（元）　元の仕入明細データの仕入明細通番を設定

            // 取得した仕入明細データから更新する部分
            stockSlipDetail.SectionCode = _loginSectionCode;                        // 拠点コード（ログイン拠点コード）
            stockSlipDetail.StockRowNo = rgdsExpctRowCount;                         // 仕入行番号　この時点では仕入明細データとしての行番号ではなく、画面表示上の順序を表す値を設定する
            stockSlipDetail.StockSlipCdDtl = stockSlipCdDtl;                        // 仕入伝票区分（明細）　画面上の「伝票区分」の指定から設定値を決定して設定
            stockSlipDetail.StockCount = redSalesDetailList[redSalesDetailList.Count - 1].ShipmentCnt;  
                                                                                    // 仕入数　売上データ（赤伝）の出荷数＝画面上の「返品数」
            stockSlipDetail.StockUnitPriceFl = (double)rowView[_detailDataSet.RedSlipDetail.SalesUnitCostColumn.ColumnName];　
                                                                                    // 仕入単価　画面上の「原価」を一旦設定
            stockSlipDetail.StockUnitTaxPriceFl = stockSlipDetail.StockUnitPriceFl;

            // 更新した仕入数と仕入単価を元に、仕入金額、消費税額を再計算して更新
            double stockUnitPriceTaxExc;
            double stockUnitPriceTaxInc;
            long stockPriceConsTax;
            long stockPriceTaxExc;
            long stockPriceTaxInc;
            CalculateStockPrice(stockSlip, stockSlipDetail, out stockUnitPriceTaxExc, out stockUnitPriceTaxInc, out stockPriceTaxExc, out stockPriceTaxInc, out stockPriceConsTax);
            stockSlipDetail.StockUnitPriceFl = stockUnitPriceTaxExc;                // 仕入単価（税抜き，浮動）
            stockSlipDetail.StockUnitTaxPriceFl = stockUnitPriceTaxInc;             // 仕入単価（税込，浮動）
            stockSlipDetail.StockPriceTaxExc = stockPriceTaxExc;                    // 仕入金額（税抜き）
            stockSlipDetail.StockPriceTaxInc = stockPriceTaxInc;                    // 仕入金額（税込み） 
            stockSlipDetail.StockPriceConsTax = stockPriceConsTax;                  // 仕入金額消費税額

        }

        /// <summary>
        /// パラメータ生成処理（仕入返品予定データ登録用）
        /// </summary>
        /// <param name="writeObj"></param>
        /// <param name="rgdsExpctList"></param>
        /// <param name="rgdsExpctDetailList"></param>
        /// <remarks>
        /// <br>Note       : 仕入返品予定データ登録用のパラメータを生成する</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2013/01/15</br>
        /// </remarks>
        private void CreateParamForSaveDBDataOfRgdsExpct(out object writeObj, List<StockSlipWork> rgdsExpctList, List<List<StockDetailWork>> rgdsExpctDetailList)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --CustomSerializeArrayList      仕入返品予定データリスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 明細追加情報リスト
            //              --SlipDetailAddInfo     明細追加情報データオブジェクト
            //------------------------------------------------------------------------------------
            CustomSerializeArrayList paraList = new CustomSerializeArrayList();

            // 仕入返品予定データ（仕入データ）件数分ループ
            for (int index = 0; index < rgdsExpctList.Count; index++)
            {
                // 仕入返品予定データ（仕入明細データ）が無ければ終了
                // （通常は無い）
                if (rgdsExpctDetailList.Count <= index) break;

                CustomSerializeArrayList stockWriteList = new CustomSerializeArrayList();

                // 仕入返品予定データ（仕入データ）
                stockWriteList.Add(rgdsExpctList[index]);

                // 仕入返品予定データ（仕入明細データ）
                stockWriteList.Add(new ArrayList(rgdsExpctDetailList[index].ToArray()));

                // 仕入用明細追加情報リスト生成
                stockWriteList.Add(new ArrayList(CreateSlipDetailAddInfoListForStock(rgdsExpctList[index], rgdsExpctDetailList[index])));

                paraList.Add(stockWriteList);
            }

            writeObj = (object)paraList;
        }

        /// <summary>
        /// 売上明細データ（赤伝）→仕入明細データ（仕入返品予定データ）GUID設定
        /// </summary>
        /// <param name="writeObj"></param>
        /// <param name="rgdsExpctDetailList"></param>
        /// <remarks>
        /// <br>Note       : 仕入返品計上更新部品(PMKAK01100A)で、売上明細通番(同時)に売上明細データ（赤伝）の売上明細通番を設定するため</br>
        /// <br>           : 売上明細データ（赤伝）のGUIDを仕入返品予定データ（仕入明細データ）のGUIDにセット</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2013/01/15</br>
        /// </remarks>
        private int setGUIDForRgdsExpct(object writeObj, ref  List<List<StockDetailWork>> rgdsExpctDetailList, out string errorMessage)
        {
            errorMessage = string.Empty;
            int rowIdx = 1;

            try
            {
                // 仕入返品予定データ（仕入明細データ）内の全データを取得
                // 　仕入先別にリストが作成され、その各リスト内に仕入明細データが設定されているので、
                //   それを全件Dictionaryに格納する
                Dictionary<int, StockDetailWork> updDataDic = new Dictionary<int, StockDetailWork>();
                foreach (List<StockDetailWork> listData in rgdsExpctDetailList)
                {
                    foreach (StockDetailWork stockDetailWork in listData)
                    {
                        // Keyは仕入行番号（この時点では画面上の明細の表示位置が設定されている）
                        updDataDic.Add(stockDetailWork.StockRowNo, stockDetailWork);
                    }
                }

                ArrayList paramList = (ArrayList)writeObj;
                for (int i = 0; i < paramList.Count; i++)
                {
                    // this.SaveDBDataで更新されている（＝登録した売上伝票（赤伝）の内容に更新される）書き込みパラメータ内より、
                    // 売上明細データを取得
                    ArrayList al = paramList[i] as ArrayList;
                    if (al != null)
                    {
                        // 画面上で売上仕入同時入力の明細（仕入に「○」が表示されている）を選択して仕入伝票番号を入力した場合、
                        // 売上明細データはオフセット[1]にArrayListで格納されているが、
                        // 仕入伝票番号を入力しなかった場合は同じオフセットに別のデータが格納されているため、
                        // ArrayList先頭に格納されているオブジェクトが売上明細データかチェックする
                        ArrayList list = al[1] as ArrayList;
                        if(list != null)
                        {
                            SalesDetailWork salesDetailWork = (list[0]) as SalesDetailWork;
                            if (salesDetailWork == null)
                                continue;
                        }

                        foreach (SalesDetailWork salesDetailWork in (ArrayList)al[1])
                        {
                            // 手数料明細はスキップ
                            if (salesDetailWork.SalesSlipCdDtl == 2)
                                continue;

                            // 売上明細データのGUIDを取得
                            Guid guid = salesDetailWork.FileHeaderGuid;

                            // 仕入返品データ（仕入明細データ）の仕入行番号に設定されている行番号（画面上の明細表示位置）と
                            // 現在の処理行数が一致する、仕入返品データ（仕入明細データ）のGUIDに
                            // 売上明細データから取得したGUIDをセットする
                            if (updDataDic.ContainsKey(rowIdx) == false)
                                continue;
                            StockDetailWork updData = (StockDetailWork)updDataDic[rowIdx];
                            if(updData != null)
                            {
                                updData.FileHeaderGuid = guid;
                                rowIdx++;
                            }
                            else
                            {
                                errorMessage = ": GUIDが見つかりません。";
                                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            }
                        }
                    }
                }
            }
            catch
            {
                errorMessage = ": GUID設定処理でエラーが発生しました。。";
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// 売上返品伝票（赤伝）伝票番号リスト作成
        /// </summary>
        /// <param name="slipNoList"></param>
        /// <param name="_printRedSalesSlipNo"></param>
        /// <param name="?"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 仕入返品計上更新部品(PMKAK01100A)で、売上明細通番(同時)に売上明細データ（赤伝）の</br>
        /// <br>           : 売上明細通番を設定するために使用する、売上返品伝票（赤伝）伝票番号のリストを作成</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2013/01/15</br>
        /// </remarks>
        private int createSlipNoList(out ArrayList slipNoList, Dictionary<string, int> _printRedSalesSlipNo, out string errorMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errorMessage = string.Empty;
            slipNoList = null;

            // 売上返品伝票（赤伝）の伝票番号を取得
            //  this.SaveDBDataが出力する受注ステータスを参照する
            if (_printRedSalesSlipNo.Keys.Count > 0)
            {
                slipNoList = new ArrayList();
                foreach (string key in _printRedSalesSlipNo.Keys)
                {
                    if (key == string.Empty)
                    {
                        errorMessage = "仕入返品予定データ登録のための売上伝票番号が設定されていません。";
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        break;
                    }
                    slipNoList.Add(key);
                }
            }
            else
            {
                errorMessage = "仕入返品予定データ登録のための売上伝票番号が取得できませんでした。";
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 仕入返品予定データ（仕入明細データ）　仕入行番号更新
        /// </summary>
        /// <param name="rgdsExpctDetailList"></param>
        /// <remarks>
        /// <br>Note       : 仕入行番号更新</br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2013/01/15</br>
        /// </remarks>
        private void setStockRowNoForRgdsExpct(ref  List<List<StockDetailWork>> rgdsExpctDetailList)
        {
            // 仕入返品予定データ（仕入明細データ）内の全データを取得
            // 　仕入先別にリストが作成され、その各リスト内に仕入明細データが設定されているので、
            //   各リスト毎に仕入行番号を振り直す
            //   （処理前は、画面上の表示位置が設定されているので、これを「1」から昇順の番号に振り直す）
            foreach (List<StockDetailWork> listData in rgdsExpctDetailList)
            {
                int rowNo = 1;
                foreach (StockDetailWork stockDetailWork in listData)
                {
                    stockDetailWork.StockRowNo = rowNo;
                    rowNo++;
                }
            }
        }

        #endregion [■仕入返品予定データ作成処理]
        // ---------- ADD 2013/01/15 ----------<<<<<

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        #region
        /// <summary>
        /// ログ出力処理
        /// </summary>
        /// <param name="methodName">メソッド名</param>
        /// <param name="pMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : エラーログを書きます。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public static void LogWrite(string methodName, string pMsg)
        {
            System.IO.FileStream fs;										// ファイルストリーム
            System.IO.StreamWriter sw;										// ストリームwriter
            // Logフォルダー
            string logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Log");
            if (!Directory.Exists(logFolderPath))
            {
                // Logフォルダーが存在しない場合、作成する
                Directory.CreateDirectory(logFolderPath);
            }
            // ログファイル
            string logFilePath = Path.Combine(logFolderPath, "TSP送信データ作成");
            if (!Directory.Exists(logFilePath))
            {
                // Logフォルダーが存在しない場合、作成する
                Directory.CreateDirectory(logFilePath);
            }
            string logFilePathName = Path.Combine(logFilePath, "PMKAU04000U.Log");
            fs = new FileStream(logFilePathName, FileMode.Append, FileAccess.Write, FileShare.Write);
            sw = new System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding("shift_jis"));
            string log = string.Format("{0},{1},{2}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), methodName, pMsg);
            sw.WriteLine(log);
            if (sw != null)
                sw.Close();
            if (fs != null)
                fs.Close();
        }
        # endregion
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
    }
}
