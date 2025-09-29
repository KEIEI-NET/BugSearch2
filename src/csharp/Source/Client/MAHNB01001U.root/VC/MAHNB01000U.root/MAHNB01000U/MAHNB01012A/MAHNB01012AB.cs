using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

using System.Threading;  // ADD 譚洪 2014/09/01 FOR Redmine#43289

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上入力アクセスクラス(商品／在庫／単価／金額関係)
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の制御全般を行います。</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 對馬 大輔 新規作成</br>
    /// <br>2009.06.23 21024 佐々木 健 MANTIS[0013598] 商品種別はPMKEN01020Eの定義を参照するように修正</br>
    /// <br>2009/09/08 20056 對馬 大輔 MANTIS[0013973] 優先倉庫の取得拠点コードを画面拠点から取得するように修正</br>
    /// <br></br>
    /// <br>Update Note : 2009/10/19 張凱</br>
    /// <br>              PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>              PM.NS保守依頼②を追加</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/25 21024 佐々木 健</br>
    /// <br>              ・検索ＢＬコードを複数選択・セット子部品選択時も正しく取得できるように修正(MANTIS[0014690])</br>
    /// <br>              ・部品検索結果の画面表示するＢＬコードがＰＭ７同様の仕様になるように修正（MANTIS[0014671]</br>
    /// <br>Update Note : 2009/12/17 對馬 大輔 保守依頼③対応</br>
    /// <br>             MANTIS[14785] BLコードガイドから標準価格選択を行った場合も選択した標準価格を有効にする</br>
    /// <br>Update Note : 2009/12/23 張凱</br>
    /// <br>              PM.NS-5-A・PM.NS保守依頼④</br>
    /// <br>              PM.NS保守依頼④を追加</br>
    /// <br>Update Note : 2010/01/27 張凱 ４次改良対応</br>
    /// <br>              PM.NS保守依頼４次改良対応を追加</br>
    /// <br>Update Note : 2010/02/26 對馬 大輔 </br>
    /// <br>              SCM対応</br>
    /// <br>Update Note : 2010/03/12 李占川 redmine#3773</br>
    /// <br>              原価計算処理の不具合対応</br>
    /// <br>Update Note : 2010/03/22 李侠 redmine#4075</br>
    /// <br>              原価計算処理の不具合対応</br>
    /// <br>Update Note : 2010/04/02 21024 佐々木 健</br>
    /// <br>              ・結合選択で選択した部品のBLコードが、検索BLコードになる不具合の修正(MANTIS[0015247])</br>
    /// <br>Update Note : 2010/04/12 鈴木 正臣</br>
    /// <br>              検索結果のQTYが正しく出荷数にセットされない件の修正(デグレの為、2010/03/17分の再組み込み。コメントは2010/04/12)</br>
    /// <br>Update Note : 2010/05/04 王海立 PM1007・6次改良</br>
    /// <br>              発行者チェック、入力倉庫チェック等処理を追加</br>
    /// <br>Update Note : 2010/05/17 30434 工藤 恵優</br>
    /// <br>              品名表示対応</br>
    /// <br>Update Note : 2010/06/02 譚洪 PM.NS障害・改良対応（７月リリース案件）</br>
    /// <br>Update Note : 2010/06/26 李占川 </br>
    /// <br>              BLコード変換処理のロジックの削除</br>
    /// <br>Update Note: 2010/07/21 20056 對馬 大輔 </br>
    /// <br>             用品入力で品名・メーカー変更時の明細情報クリア処理変更(一部内容をクリアしない)</br>
    /// <br>Update Note: 2010/07/28 20056 對馬 大輔 </br>
    /// <br>             売価率、原価率、原単価が入力された状態で、価格再計算し掛率ヒットしなかった場合、売価率、原価率、原単価がクリアされない件の対応</br>
    /// <br>Update Note: 2010/07/29 20056 對馬 大輔 </br>
    /// <br>             ①原価率または原単価が商品マスタで設定されている場合、商品検索で原価率、原単価が表示されない件の対応</br>
    /// <br>             ②原価情報変更時、売価情報がクリアされる件の対応</br>
    /// <br>             ③受注伝票を修正呼出で、行追加し検索を行うと受注数が設定されない件の対応</br>
    /// <br>Update Note: 2010/09/19 譚洪 </br>
    /// <br>             PM.NS障害・改良対応（９月リリース案件）</br>
    /// <br>Update Note: 2010/10/01 對馬 大輔</br>
    /// <br>             用品入力明細で掛率算出を可能とする</br>
    /// <br>Update Note: 2010/11/19 20056 對馬 大輔</br>
    /// <br>             ①原価率が設定されている状態で定価を変更した場合、原単価が更新されない件の対応</br>
    /// <br>               発生条件：定価が掛率算出されていない状態で定価を変更した場合</br>
    /// <br>Update Note: 2011/02/16 22018 鈴木 正臣</br>
    /// <br>             ①標準価格ゼロで数量変更時に標準価格が再セットされる件の対応。（⇒再セットしない）</br>
    /// <br>             ②手入力で売価率を変更後、１回目に数量変更時に売価率が再セットされない件の対応。（⇒２回目以降と同様に再セットする）</br>
    /// <br>             ③標準価格ゼロ・売価率ゼロ・売単価ゼロ以外のとき数量変更すると売単価がゼロになる件の対応。（⇒売単価はそのままにする）</br>
    /// <br>             ④売価率を変更後、F5:ガイドで基準定価が表示されない件の対応。（⇒売価率が変更されても基準定価を表示する）</br>
    /// <br>             ⑤標準価格ゼロ・売価率ゼロ以外手入力後、数量を変更しても売価率が再セットされない件の対応。（⇒売価率を再セットする）</br>
    /// <br>Update Note: 2011/03/10 20056 對馬 大輔</br>
    /// <br>              1)車輌情報入力ありの伝票を修正呼出し、追加検索でカラー、トリム、年式の絞込が有効となるように修正</br>
    /// <br>Update Note: 2011/03/16 20056 對馬 大輔</br>
    /// <br>             SCM対応</br>
    /// <br>              1)BLコード検索不可のBLコードで問合せ／発注データを展開後、明細入力すると回答送信されない件の対応</br>
    /// <br>Update Note: 2011/05/30 曹文傑</br>
    /// <br>             やキャンペーン売価を取得するように変更</br>
    /// <br>UpdateNote : 2011/07/06 譚洪 売上全体設定の売価未設定時の対応</br>
    /// <br>UpdateNote : 2011/07/11 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
    /// <br>UpdateNote : 2011/07/13 曹文傑 Redmine#22953 標準価格＝０、売上伝票入力で０除算のエラーメッセージが表示しません</br>
    /// <br>                               Redmine#22773 [売価未設定時区分＝ゼロを表示]、掛率なし、キャンペーン値引率≠0の場合の不具合修正</br>
    /// <br>UpdateNote : 2011/07/14 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
    /// <br>Update Note: 2011/07/20 連番1028,Redmine#22936 許雁波</br>
    /// <br>             仕入・出荷後数表示区分(明細算出後在庫数表示区分)について修正</br>
    /// <br>UpdateNote : 2011/08/12 譚洪 Redmine#23554 キャンペーンの売価「売価率、値引率、売価額」が設定されている場合は、掛率マスタの売価の設定をクリアするように仕様変更の対応</br>
    /// <br>Update Note: 2011/08/15 譚洪 Redmine#23554 掛率マスタの売価率設定ありで且つ、キャンペーンの売価額設定ありの場合、売価率はクリアの対応</br>
    /// <br>Update Note: 2011/08/20 連番882 徐錦山 10704766-00 </br>
    /// <br>             元定価が表示のを追加</br>
    /// <br>Update Note: 2011/08/31 連番721 Redmine#23887 許雁波 10704766-00 </br>
    /// <br>             純正定価採用した後仕入先変更を行うと、価格の再取得の不具合を修正する</br>
    /// <br>Update Note: 2011/09/01 連番681 yangmj 10704766-00 </br>
    /// <br>             Redmine#23723 提供定価とユーザー定価が一致しない場合、文字色の改修</br>
    /// <br>UpdateNote : 2011/09/05 譚洪 Redmine#23965 販売区分を変更時の価格再取得のメッセージ表示の対応</br>   
    /// <br>UpdateNote : 2011/09/05 yangmj Redmine#23554 キャンペーンの売価「売価率、値引率、売価額」が設定されている場合は、掛率マスタの売価の設定をクリアするように仕様変更の対応</br>
    /// <br>UpdateNote : 2011/09/14 譚洪 Redmine#25016 提供の純正品番で、売価率が登録されている＆キャンペーン売率が登録されている場合、売単価が空白になり不正の修正</br>
    /// <br>UpdateNote : 2011/09/16 譚洪 Redmine#25195 売上伝票入力で売単価がクリアされてしまうの対応</br>
    /// <br>UpdateNote : 2011/09/21 yangmj Redmine#25261 元伝票を指定しての返品時動作の修正</br>
    /// <br>UpdateNote : 2011/10/27 高峰 Redmine#26293 売上伝票入力／PMからいきなり回答する場合のＢＬコードの回答方法の対応</br>
    /// <br>Update Note: 2011/10/29 20056 對馬 大輔</br>
    /// <br>             障害対応</br>
    /// <br>               1)受注伝票を修正呼出した場合、金額情報が再計算される</br>
    /// <br>                 →受注伝票修正呼出時、価格の再計算を行わないように修正</br>
    /// <br>               2)原単価、原価率、売単価、売価率を変更しても発注受注に反映されない</br>
    /// <br>                 →受注データ分割時、価格再計算を行わないように修正</br>
    /// <br>                 →発注数入力時、受注情報の価格再計算を行わないように修正</br>
    /// <br>                 →発注数入力時、売上情報の価格再計算を行わないように修正</br>
    /// <br>               3)発注受注に販売区分が反映されない</br>
    /// <br>                 →販売区分入力時に受注情報を更新</br>    
    /// <br>UpdateNote : 2011/11/08 yangmj Redmine#26316 BLコード検索でQTYが反映されないの対応</br>
    /// <br>Update Note: 2011/12/28 凌小青</br>
    /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
    /// <br>             Redmine#27385　基準価格の対応</br>
    /// <br>UpdateNote : 2012/01/16 30517 夏野 駿希</br>
    /// <br>             SCM改良・特記事項対応</br>
    /// <br>UpdateNote : 2012/02/07 20056 對馬 大輔</br>
    /// <br>             SCM改良・特記事項対応 40桁以上カット対応</br>
    /// <br>Update Note: 2012/02/28 鄧潘ハン</br>
    /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
    /// <br>             Redmine#27385 原価の金額が不正についての対応</br>
    /// <br>Update Note: 2012/04/09 yangmj</br>
    /// <br>管理番号   : 10801804-00 2012/05/24配信分</br>
    /// <br>             Redmine#29313   売上伝票入力 商品価格の再取得で販売区分が初期値に戻る</br>
    /// <br>Update Note: 2012/06/15 吉岡 孝憲</br>
    /// <br>             障害対応 №90</br>
    /// <br>             SCM障害№171修正時のバグ対応。</br>
    /// <br>Update Note: 2012/08/30 脇田 靖之</br>
    /// <br>             仕入先コードがクリアされてしまう件の修正。</br>
    /// <br>Update Note: 2012/08/30 30745 吉岡 孝憲</br>
    /// <br>             2012/10月配信予定SCM障害№10345対応 </br>
    /// <br>Update Note: 2012/09/05 脇田 靖之</br>
    /// <br>管理番号   : 10801804-00 2012/09/12配信分</br>
    /// <br>             空商品情報特定項目再設定を品番が変更された場合は行わないように修正</br>
    /// <br>Update Note: 2012/10/11 脇田 靖之</br>
    /// <br>             メーカー、仕入先変更により発注先情報がクリアされてしまう件の修正。</br>
    /// <br>Update Note: 2012/10/19 脇田 靖之</br>
    /// <br>             メーカー、仕入先変更により発注先情報がクリアされてしまう件の再修正。</br>
    /// <br>Update Note: 2012/11/21 西 毅</br>
    /// <br>             受注データ作成時、売単価に原単価がセットされてしまう障害の修正</br>
    /// <br>Update Note: 2013/02/13 脇田 靖之</br>
    /// <br>             車輌情報によって月を入れなければBLコード検索できないことがある障害の修正</br>
    /// <br>Update Note: 2013/02/20 宮本 利明</br>
    /// <br>             出荷数=0かつ受注数>0の場合は受注数で算出</br>
    /// <br>Update Note: 2013/02/22 吉岡 孝憲</br>
    /// <br>             2013/03/06配信 №108対応時の不具合対応 </br>
    /// <br>Update Note: 2013/04/04 30744 湯上 千加子</br>
    /// <br>             SCM障害№10504対応</br>
    /// <br>Update Note: 2013/04/06 20056 對馬 大輔</br>
    /// <br>             SCM障害№10504対応によるデグレ対応</br>
    /// <br>               1.品番検索にて部品情報が取得できなかった場合も商品情報クラスを参照する為、不正な動作となる</br>
    /// <br>               2.部品情報入力後、BLコードを変更すると変更後のBLコードで回答されない件の対応</br>
    /// <br>               3.部品情報入力後、行操作を行うと正常にBLコードが回答されない件の対応</br>
    /// <br>Update Note: 2013/04/10 宮本 利明</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             倉庫切替(F8)時に原価の再取得を行う</br>
    /// <br>Update Note: 2013/06/17 脇田 靖之</br>
    /// <br>管理番号   : 10902175-00</br>
    /// <br>             2013/06/18配信　システムテスト障害№43</br>
    /// <br>Update Note: 2013/06/17 脇田 靖之</br>
    /// <br>管理番号   : 10902175-00</br>
    /// <br>             新規登録ログ出力対応</br>
    /// <br>Update Note: 2013/07/09 宮本 利明</br>
    /// <br>管理番号   : 10902175-00 仕掛一覧 №2000</br>
    /// <br>             計上明細の場合は単価再計算時の商品・在庫情報の再設定を行わないように修正</br>
    /// <br>Update Note: 2013/07/10 王君</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             Redmine#37769のBL変更後BLｸﾞﾙｰﾌﾟｺｰﾄﾞ、大・中分類の情報も更新する</br>
    /// <br>Update Note: 2013/07/25 liusy</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             #34551 受注伝票を伝票呼出し明細追加して価格項目保存不正の修正</br>
    /// <br>Update Note: 2013/08/07 脇田 靖之</br>
    /// <br>管理番号   : 10902175-00</br>
    /// <br>             Redmine#39699 行値引きをした場合の消費税端数処理がおかしい</br>
    /// <br>Update Note: 2013/09/13 30744 湯上 千加子</br>
    /// <br>             SCM仕掛一覧№10571対応 PCC自社設定マスタの参照倉庫コードを追加</br>
    /// <br>Update Note: K2013/09/20 宮本 利明</br>
    /// <br>             ㈱フタバ個別 本社倉庫優先順位対応</br>
    /// <br>Update Note: K2013/10/11 宮本 利明</br>
    /// <br>             ㈱フタバ個別 本社管理倉庫該当チェック内で対象倉庫コードをTrimしてチェック</br>
    /// <br>Update Note: 2013/11/05 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>             仕掛一覧№1492(№594)対応</br>
    /// <br>             「商品検索後のフォーカス位置」項目追加し、受注伝票を入力しやすくする</br>
    /// <br>Update Note: 2013/12/19 陳健</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : Redmine#41550 売上伝票入力消費税8%増税対応</br>
    /// <br>Update Note: 2014/01/23 陳健</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : Redmine#41771 売上伝票入力消費税8%増税対応。</br>
    /// <br>Update Note: 2014/04/02 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>           : 仕掛一覧№2346対応</br>
    /// <br>             消費税の算出がおかしくなる障害。</br>
    /// <br>Update Note: 2013/12/10 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>             純正定価印字対応</br>
    /// <br>Update Note: 2014/01/15 宮本 利明</br>
    /// <br>管理番号   : 10904597-00　純正定価印字対応</br>
    /// <br>             純正情報取得処理を修正</br>
    /// <br>Update Note: 2014/01/29 宮本 利明</br>
    /// <br>管理番号   : 10904597-00　純正定価印字対応</br>
    /// <br>             セット品の場合も親の純正情報を登録</br>
    /// <br>Update Note: 2014/03/17 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>             仕掛一覧№2326対応</br>
    /// <br>             品番検索で品番入力し受注数入力後、品番を修正し登録を行うと、</br>
    /// <br>             修正した行の受注伝票の明細が登録されない障害の対応。</br>
    /// <br>Update Note: 2014/04/03 脇田 靖之</br>
    /// <br>管理番号   : 10904597-00</br>
    /// <br>             品質保証部Redmine#1319</br>
    /// <br>             売上伝票修正時、明細追加後に売上日を変えると出荷数がクリアされる</br>
    /// <br>Update Note: K2014/02/09 yangyi</br>
    /// <br>管理番号   : 10970681-00 前橋京和商会個別個別対応</br>
    /// <br>           : 売上伝票入力の改良対応</br>
    /// <br>Update Note: 2014/03/20 陳健</br>
    /// <br>管理番号   : Redmine#42174 更新日の変更</br>
    /// <br>           : 売上伝票入力の単価情報改良対応</br>
    /// <br>Update Note: 2014/07/14 脇田 靖之</br>
    /// <br>管理番号   : 11070100-00</br>
    /// <br>             仕掛一覧№2487対応</br>
    /// <br>             価格の再算出を行った際に、純正定価がクリアされる障害対応</br>
    /// <br>Update Note: 2014/09/01 譚洪</br>
    /// <br>管理番号   : 11070184-00　SCM障害対応 №190　RedMine#43289</br>
    /// <br>         　: SFから問合せの車輌情報・備考を売上伝票入力に表示する</br>
    /// <br>Update Note: 2015/01/30  30744 湯上 千加子</br>
    /// <br>管理番号   : 11070266-00</br>
    /// <br>           : SCM高速化 生産年式、車台番号対応</br>
    /// <br>Update Note: 2015/02/10  30745 吉岡</br>
    /// <br>管理番号   : 11070266-00</br>
    /// <br>           : SCM高速化 回答納期区分対応</br>
    /// <br>Update Note: 2015/03/18  31065 豊沢</br>
    /// <br>管理番号   : 11070266-00</br>
    /// <br>           : SCM高速化 メーカー希望小売価格対応</br>
    /// <br>Update Note: 2015/04/06 30757 佐々木 貴英</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>             仕掛№2405 得意先変更時表示区分再取得対応</br>
    /// <br>Update Note: 2015/04/16 30757 佐々木 貴英</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>             社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応</br>
    /// <br>Update Note: 2015/09/03 脇田 靖之</br>
    /// <br>管理番号   : 11170139-00</br>
    /// <br>             社内障害№707 販売区分を変更した場合に売価が再計算されない障害の対応</br>
    /// <br>             社内障害№711 掛率マスタが設定されている場合に、出荷数の変更の仕方で金額が変わる。</br>
    /// <br>Update Note: 2015/10/28 李侠</br>
    /// <br>管理番号   : 11170187-00</br>
    /// <br>             Redmine#47537 伝票修正モード、納品書の最大明細数を超えて追加入力すると</br>
    /// <br>             画面と伝票で明細件数が不一致の障害を対応する</br>
    /// <br>Update Note: 2015/12/09 陳永康</br>
    /// <br>管理番号   : 11170204-00</br>
    /// <br>           : Redmine#47787 最大行を超えて明細を追加すると、画面に表示されない部品が登録される障害の修正</br>
    /// <br>Update Note: 2021/03/16 陳艶丹</br>
    /// <br>管理番号   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4133 売上伝票入力原価0円障害の対応</br>
    /// <br>Update Note: K2021/07/22 陳艶丹</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>             PMKOBETSU-4148 原価0円障害の対応</br>  
    /// </remarks>
    public partial class SalesSlipInputAcs
    {
        // --- ADD m.suzuki 2011/02/16 ---------->>>>>
        // 標準価格再設定なしフラグ
        private bool _noneResettingListPriceFlag = false;
        // 原単価再設定なしフラグ
        private bool _noneResettingUnitCostFlag = false;
        // --- ADD m.suzuki 2011/02/16 ----------<<<<<

        private IDictionary<int, int> _originalBLGoodsCodeMap = new Dictionary<int, int>(); // ADD 2011/10/27

        public double _salesUnitPriceForCheck; // ADD 2011/09/05
        public double _salesRateForCheck; // ADD 2011/09/05

        // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>> 
        /// <summary>
        /// 部品検索結果保管用
        /// </summary>
        private PartsInfoDataSet _partsInfo = new PartsInfoDataSet();
        // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        public Int32 _CustAnalysCode1 = 0; // 得意先分析コード1
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<


        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- >>>
        /// <summary>車両情報を表示用</summary>
        private const string PGID_XML = "MAHNB01001U";
        //Thread中、車両情報SOLT名
        private const string CARINFOSOLT = "CARINFOSOLT";
        private LocalDataStoreSlot carInfoSolt = null;
        // ADD 譚洪 2014/09/01 FOR Redmine#43289 --- <<<
        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
        private const int CtZero = 0;
        /// <summary> ログ内容</summary> 
        private const string LogMessage = "{0} ==> {1}";
        /// <summary> メソッド名</summary> 
        private const string MethodNameUnit = "CalculateUnitPrice";
        /// <summary>メーカーコード</summary>
        private const string CtMakeCode = "MakeCd={0},";
        /// <summary>品番</summary>
        private const string CtGoodsNo = "GoodsNo={0},";
        /// <summary>品名</summary>
        private const string CtGoodsName = "GoodsNm={0},";
        /// <summary>BL商品コード</summary>
        private const string CtBLGoodsCode = "BLGoodsCd={0},";
        /// <summary>商品大分類コード</summary>
        private const string CtGoodsLGroup = "GoodsLGp={0},";
        /// <summary>商品中分類コード</summary>
        private const string CtGoodsMGroup = "GoodsMGp={0},";
        /// <summary>BLグループコード</summary>
        private const string CtBLGroupCode = "BLGroupCd={0},";
        /// <summary>商品掛率ランク(層別)</summary>
        private const string CtGoodsRateRank = "GoodsRateRk={0},";
        /// <summary>自社分類コード</summary>
        private const string CtEnterpriseGanreCode = "EntGanreCd={0},";
        /// <summary>商品掛率グループコード</summary>
        private const string CtGoodsRateGrpCd = "GoodsRateGrpCd={0},";
        /// <summary>仕入先コード</summary>
        private const string CtSupplierCd = "SupplierCd={0},";
        /// <summary>拠点</summary>
        private const string CtSectionCode = "SectionCd={0},";
        /// <summary>得意先コード</summary>
        private const string CtCustomerCode = "CustomerCd={0},";
        /// <summary>担当者コード</summary>
        private const string CtEmployeeCode = "EmployeeCd={0},";
        /// <summary>売上日</summary>
        private const string CtSalesDate = "SalesDate={0}";
        /// <summary>Sleep実行モード(0:実行される 1:実行されない)</summary>
        private const int CtSleepMode = 1;
        // ログ出力部品
        OutLogCommon LogCommon;
        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<<

        #region ●商品＆在庫
        /// <summary>
        /// 指定した商品、在庫情報のリストを元に、売上明細データ行オブジェクトに商品、在庫情報を一括設定します。（在庫ベース）
        /// </summary>
        /// <param name="activeSalesRowNo">アクティブ売上行番号</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitDataList">商品情報オブジェクトリスト</param>
        /// <param name="stockList">在庫情報オブジェクトリスト</param>
        /// <param name="settingSalesRowNoList">設定した売上行番号のリスト</param>
        /// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        /// <param name="overWriteRow">true:行上書きあり false:行上書きなし</param>
        /// <remarks>コール：在庫検索</remarks>
        public void SalesDetailRowGoodsSetting_StockBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow)
        {
            settingSalesRowNoList = new List<int>();
            List<int> deletingSalesRowNoList = new List<int>();
            List<int> goodsDiscountRowList = new List<int>();
            SalesInputDataSet.SalesDetailRow activeRow = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, activeSalesRowNo);

            int settingCount = this._salesSlipInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            int iCount = 0;
            int iRowNo = 1;
            while (true)
            {
                if (iCount >= settingCount) break;

                SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, iRowNo);
                iRowNo++;

                if (row != null)
                {
                    if (overWriteRow == false)
                    {
                        // 入力済み行は設定対象外
                        if (!string.IsNullOrEmpty(row.GoodsName))
                        {
                            continue;
                        }
                        else
                        {
                            settingSalesRowNoList.Add(row.SalesRowNo);
                            iCount++;
                        }
                    }
                    else
                    {
                        settingSalesRowNoList.Add(row.SalesRowNo);
                        iCount++;
                    }
                }
                else
                {
                    break;
                }
                
                if (activeRow.EditStatus == ctEDITSTATUS_GoodsDiscount) goodsDiscountRowList.Add(row.SalesRowNo);

                if (stockList.Count <= settingSalesRowNoList.Count) break;

                deletingSalesRowNoList.Add(row.SalesRowNo);

                row.AcceptChanges(); // 変更内容コミット
            }

            // 売上明細行クリア処理
            this.ClearSalesDetailRow(deletingSalesRowNoList);
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();

            for (int i = 0; i < settingSalesRowNoList.Count; i++)
            {
                if (stockList.Count <= i) break;

                stock = stockList[i];
                int targetStockRowNo = settingSalesRowNoList[i];
                goodsUnitData = this.GetGoodsUnitDataFromList(stock.GoodsNo, stock.GoodsMakerCd, goodsUnitDataList);
                int salesSlipCdDtl = (goodsDiscountRowList.Contains(settingSalesRowNoList[i])) ? (int)SalesSlipCdDtl.Discount : (int)SalesSlipCdDtl.Sales;
                // 商品、在庫情報設定処理
                this.SalesDetailRowGoodsSetting(targetStockRowNo, goodsUnitData.Clone(), stock, setDefaultRowCount, salesSlipCdDtl, this._searchPartsMode);
            }
        }

        //>>>2010/07/21
        /// <summary>
        /// 指定した商品、在庫情報のリストを元に、売上明細データ行オブジェクトに商品、在庫情報を一括設定します。（商品ベース）
        /// </summary>
        /// <param name="activeSalesRowNo">アクティブ売上行番号</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitDataList">商品情報オブジェクトリスト</param>
        /// <param name="stockList">在庫情報オブジェクトリスト</param>
        /// <param name="settingSalesRowNoList">設定した売上行番号のリスト</param>
        /// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        /// <param name="overWriteRow">true:行上書きあり false:行上書きなし</param>
        /// <param name="emptyInfoSetting">true:空商品情報セット false:通常商品情報セット</param>
        //>>>2010/07/21
        public void SalesDetailRowGoodsSetting_GoodsBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow)
        {
            // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
            //this.SalesDetailRowGoodsSetting_GoodsBase(activeSalesRowNo, salesRowNo, goodsUnitDataList, stockList, out settingSalesRowNoList, setDefaultRowCount, overWriteRow, false);
            this.SalesDetailRowGoodsSetting_GoodsBase(activeSalesRowNo, salesRowNo, goodsUnitDataList, stockList, out settingSalesRowNoList, setDefaultRowCount, overWriteRow, false, false);
            // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        }
        //<<<2010/07/21

        /// <summary>
        /// 指定した商品、在庫情報のリストを元に、売上明細データ行オブジェクトに商品、在庫情報を一括設定します。（商品ベース）
        /// </summary>
        /// <param name="activeSalesRowNo">アクティブ売上行番号</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitDataList">商品情報オブジェクトリスト</param>
        /// <param name="stockList">在庫情報オブジェクトリスト</param>
        /// <param name="settingSalesRowNoList">設定した売上行番号のリスト</param>
        /// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        /// <param name="overWriteRow">true:行上書きあり false:行上書きなし</param>
        /// <param name="emptyInfoSetting">true:空商品情報セット false:通常商品情報セット</param>
        /// <remarks>
        /// <br>Update Note: 2015/10/28 李侠</br>
        /// <br>管理番号   : 11170187-00</br>
        /// <br>           : Redmine#47537 伝票修正モード、納品書の最大明細数を超えて追加入力すると</br>
        /// <br>           : 画面と伝票で明細件数が不一致の障害を対応する</br>
        /// <br>Update Note: 2015/12/09 陳永康</br>
        /// <br>管理番号   : 11170204-00</br>
        /// <br>           : Redmine#47787 最大行を超えて明細を追加すると、画面に表示されない部品が登録される障害の修正</br>
        /// </remarks>
        //>>>2010/07/21
        //public void SalesDetailRowGoodsSetting_GoodsBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow)
        // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
        //public void SalesDetailRowGoodsSetting_GoodsBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow, bool emptyInfoSetting)
        public void SalesDetailRowGoodsSetting_GoodsBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow, bool emptyInfoSetting, bool saveValueSetting)
        // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        //<<<2010/07/21
        {
            settingSalesRowNoList = new List<int>();
            List<int> deletingSalesRowNoList = new List<int>();
            List<int> goodsDiscountRowList = new List<int>();
            SalesInputDataSet.SalesDetailRow activeRow = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, activeSalesRowNo);

            int settingCount = this._salesSlipInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            for (int i = 0; i < settingCount; i++)
            {
                SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo + i);

                // 行が存在しない場合は新規に追加する
                if (row == null)
                {
                    if (this._salesSlip.SalesSlipNum != ctDefaultSalesSlipNum) break;// ADD 2015/10/28 李侠 For Redmine#47537

                    // --- ADD 2015/12/09 陳永康 For Redmine#47787 最大行を超えて明細を追加すると、画面に表示されない部品が登録される障害の修正 ---------->>>>>
                    //受注計上、貸出計上、見積計上、SCM返品の場合、画面表示の最大明細数を超えて追加入力すると、メモリ(明細データ)に追加しない。
                    if ((this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
                       (this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
                       (this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp)||
                       (this._salesSlip.InquiryNumber != 0 && this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods))
                    {
                        break;
                    }
                    // --- ADD 2015/12/09 陳永康 For Redmine#47787 最大行を超えて明細を追加すると、画面に表示されない部品が登録される障害の修正 ----------<<<<<

                    this.AddSalesDetailRow();

                    row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo + i);

                    settingSalesRowNoList.Add(row.SalesRowNo);
                }
                else
                {
                    if (overWriteRow == false)
                    {
                        // 入力済み行は設定対象外
                        if (!string.IsNullOrEmpty(row.GoodsName))
                        {
                            continue;
                        }
                        else
                        {
                            // 明細クリア対象外
                            if (this.SearchPartsModeProperty == SearchPartsMode.GoodsNoSearch)
                            {
                                if (!string.IsNullOrEmpty(row.GoodsNo))
                                {
                                    settingSalesRowNoList.Add(row.SalesRowNo);
                                    continue;
                                }
                            }
                            else
                            {
                                if (row.BLGoodsCode != 0)
                                {
                                    settingSalesRowNoList.Add(row.SalesRowNo);
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        settingSalesRowNoList.Add(row.SalesRowNo);
                    }
                }
                if (activeRow.EditStatus == ctEDITSTATUS_GoodsDiscount) goodsDiscountRowList.Add(row.SalesRowNo);

                if (goodsUnitDataList.Count <= settingSalesRowNoList.Count) break;

                deletingSalesRowNoList.Add(row.SalesRowNo);

                row.AcceptChanges(); // 変更内容コミット
            }

            // 売上明細行クリア処理
            this.ClearSalesDetailRow(deletingSalesRowNoList);
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();

            for (int i = 0; i < settingCount; i++)
            {
                // UPD 2010/09/19 --- >>>
                //if (goodsUnitDataList.Count <= i) break;
                if (goodsUnitDataList.Count == 0 || goodsUnitDataList.Count <= i) break;
                if (settingSalesRowNoList.Count == 0 || settingSalesRowNoList.Count <= i) break;
                // UPD 2010/09/19 --- <<<

                goodsUnitData = goodsUnitDataList[i];
                stock = (goodsUnitData.SelectedWarehouseCode != null) ? this.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim()) : this.GetStock(goodsUnitData);

                int targetSalesRowNo = settingSalesRowNoList[i];
                int salesSlipCdDtl = (goodsDiscountRowList.Contains(settingSalesRowNoList[i])) ? (int)SalesSlipCdDtl.Discount : (int)SalesSlipCdDtl.Sales;
                // 商品、在庫情報設定処理
                //>>>2010/07/21
                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch);
                // --- UPD 2013/11/05 Y.Wakita ---------->>>>>
                //// --- UPD 2012/09/05 Y.Wakita ---------->>>>>
                ////this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch, emptyInfoSetting);
                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch, emptyInfoSetting, saveValueSetting);
                //// --- UPD 2012/09/05 Y.Wakita ----------<<<<<
                //初期フォーカス位置が受注数の場合は出荷数に値をセットしない
                if (this.CheckFocusPositionAfterBLCodeSearch(targetSalesRowNo))
                {
                    this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch, emptyInfoSetting, saveValueSetting);
                }
                else
                {
                    this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch, emptyInfoSetting, saveValueSetting);
                }
                // --- UPD 2013/11/05 Y.Wakita ----------<<<<<
                //<<<<2010/07/21
            }
        }

        /// <summary>
        /// 指定した商品、在庫情報のリストを元に、売上明細データ行オブジェクトに商品、在庫情報を一括設定します。（商品ベース＆BLコード検索専用）
        /// </summary>
        /// <param name="activeSalesRowNo">アクティブ売上行番号</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="stockList">在庫情報オブジェクトリスト</param>
        /// <param name="settingSalesRowNoList">設定した売上行番号リスト</param>
        /// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        /// <param name="overWriteRow">true:行上書きあり false:行上書きなし</param>
        /// <remarks>
        /// <br>Update Note: 2015/10/28 李侠</br>
        /// <br>管理番号   : 11170187-00</br>
        /// <br>             Redmine#47537 伝票修正モード、納品書の最大明細数を超えて追加入力すると</br>
        /// <br>             画面と伝票で明細件数が不一致の障害を対応する</br>
        /// <br>Update Note: 2015/12/09 陳永康</br>
        /// <br>管理番号   : 11170204-00</br>
        /// <br>           : Redmine#47787 最大行を超えて明細を追加すると、画面に表示されない部品が登録される障害の修正</br>
        /// </remarks>
        // 2009/11/25 >>>
        //public void SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow)
        public void SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow, int blGoodsCode)
        // 2009/11/25 <<<
        {
            settingSalesRowNoList = new List<int>();
            List<int> deletingSalesRowNoList = new List<int>();
            List<int> goodsDiscountRowList = new List<int>();
            SalesInputDataSet.SalesDetailRow activeRow = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, activeSalesRowNo);

            if (this._salesSlipInputConstructionAcs.DataInputCountValue < salesRowNo) return;

            int settingCount = this._salesSlipInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            for (int i = 0; i < this._salesSlipInputConstructionAcs.DataInputCountValue; i++)
            //for (int i = 0; i < settingCount; i++)
            //for (int i = 0; i < goodsUnitDataList.Count + this.GetAlreadyInputRowCount(); i++)
            {
                //if (this._salesSlipInputConstructionAcs.DataInputCountValue <= i) break;
                if (settingCount <= i) break;

                SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo + i);

                // 行が存在しない場合は新規に追加する
                if (row == null)
                {
                    if (this._salesSlip.SalesSlipNum != ctDefaultSalesSlipNum) break;// ADD 2015/10/28 李侠 For Redmine#47537

                    // --- ADD 2015/12/09 陳永康 For Redmine#47787 最大行を超えて明細を追加すると、画面に表示されない部品が登録される障害の修正 ---------->>>>>
                    //受注計上、貸出計上、見積計上、SCM返品のの場合、画面表示の最大明細数を超えて追加入力すると、メモリ(明細データ)に追加しない。
                    if ((this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
                       (this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
                       (this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp) ||
                       (this._salesSlip.InquiryNumber != 0 && this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods))
                    {
                        break;
                    }
                    // --- ADD 2015/12/09 陳永康 For Redmine#47787 最大行を超えて明細を追加すると、画面に表示されない部品が登録される障害の修正 ----------<<<<<

                    this.AddSalesDetailRow();

                    row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo + i);

                    settingSalesRowNoList.Add(row.SalesRowNo);
                }
                else
                {
                    if (overWriteRow == false)
                    {
                        // 入力済み行は設定対象外
                        if (!string.IsNullOrEmpty(row.GoodsName))
                        {
                            continue;
                        }
                        else
                        {
                            settingSalesRowNoList.Add(row.SalesRowNo);
                        }
                    }
                    else
                    {
                        settingSalesRowNoList.Add(row.SalesRowNo);
                    }
                }
                if (activeRow.EditStatus == ctEDITSTATUS_GoodsDiscount) goodsDiscountRowList.Add(row.SalesRowNo);

                if (goodsUnitDataList.Count <= settingSalesRowNoList.Count) break;

                deletingSalesRowNoList.Add(row.SalesRowNo);

                row.AcceptChanges(); // 変更内容コミット
            }

            // 売上明細行クリア処理
            this.ClearSalesDetailRow(deletingSalesRowNoList);
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();
            for (int i = 0; i < settingCount; i++)
            //for (int i = 0; i < goodsUnitDataList.Count; i++)
            {
                if (goodsUnitDataList.Count <= i) break;
                if (settingSalesRowNoList.Count <= i) break;// ADD 2015/10/28 李侠 For Redmine#47537

                goodsUnitData = goodsUnitDataList[i];
                stock = (goodsUnitData.SelectedWarehouseCode != null) ? this.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim()) : this.GetStock(goodsUnitData);
                int targetSalesRowNo = settingSalesRowNoList[i];
                int salesSlipCdDtl = (goodsDiscountRowList.Contains(settingSalesRowNoList[i])) ? (int)SalesSlipCdDtl.Discount : (int)SalesSlipCdDtl.Sales;
                // 商品、在庫情報設定処理
                // 2009/11/25 >>>
                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.BLCodeSearch);
                this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.BLCodeSearch, blGoodsCode);
                // 2009/11/25 <<<
            }
        }

        /// <summary>
        /// 指定した商品・在庫情報オブジェクトを元に、売上明細データ行オブジェクトに商品・在庫情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <param name="stock">在庫情報オブジェクト</param>
        /// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount)
        {
            this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, (int)SalesSlipCdDtl.Sales, this._searchPartsMode);
        }

        // 2009/11/25 Add >>>
        /// <summary>
        /// 指定した商品・在庫情報オブジェクトを元に、売上明細データ行オブジェクトに商品・在庫情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <param name="stock">在庫情報オブジェクト</param>
        /// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        /// <param name="salesSlipCdDtl">売上伝票区分(明細)</param>
        /// <param name="searchPartsMode">部品検索モード</param>
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode)
        {
            this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, 0);
        }
        // 2009/11/25 Add <<<

        //>>>2010/07/21
        /// <summary>
        /// 指定した商品・在庫情報オブジェクトを元に、売上明細データ行オブジェクトに商品・在庫情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <param name="stock">在庫情報オブジェクト</param>
        /// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        /// <param name="salesSlipCdDtl">売上伝票区分(明細)</param>
        /// <param name="searchPartsMode">部品検索モード</param>
        // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
        //public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, bool emptyInfoSetting)
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, bool emptyInfoSetting, bool saveValueSetting)
        // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        {
            // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
            //this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, 0, emptyInfoSetting);
            this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, 0, emptyInfoSetting, saveValueSetting);
            // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        }
        //<<<2010/07/21

        //>>>2010/07/21
        /// <summary>
        /// 指定した商品・在庫情報オブジェクトを元に、売上明細データ行オブジェクトに商品・在庫情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <param name="stock">在庫情報オブジェクト</param>
        /// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        /// <param name="salesSlipCdDtl">売上伝票区分(明細)</param>
        /// <param name="searchPartsMode">部品検索モード</param>
        /// <param name="blGoodsCode">ＢＬコード</param>
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, int blGoodsCode)
        {
            // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
            //this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, blGoodsCode, false);
            this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, blGoodsCode, false, false);
            // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        }
        //<<<2010/07/21
        
        //>>>2010/07/21
        ///// <summary>
        ///// 指定した商品・在庫情報オブジェクトを元に、売上明細データ行オブジェクトに商品・在庫情報を設定します。
        ///// </summary>
        ///// <param name="salesRowNo">売上行番号</param>
        ///// <param name="goodsUnitData">商品情報オブジェクト</param>
        ///// <param name="stock">在庫情報オブジェクト</param>
        ///// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        ///// <param name="salesSlipCdDtl">売上伝票区分(明細)</param>
        ///// <param name="searchPartsMode">部品検索モード</param>
        //// 2009/11/25 >>>
        ////public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode)
        ///// <br>Update Note: 2010/01/27 高峰 売上日変更した場合の商品情報再取得時、在庫情報を更新しないように変更する対応</br>
        //public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, int blGoodsCode)
        //// 2009/11/25 <<<
        /// <summary>
        /// 指定した商品・在庫情報オブジェクトを元に、売上明細データ行オブジェクトに商品・在庫情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <param name="stock">在庫情報オブジェクト</param>
        /// <param name="setDefaultRowCount">true:出荷数に1(返品の場合は-1)を初期設定する false:出荷数を0とする</param>
        /// <param name="salesSlipCdDtl">売上伝票区分(明細)</param>
        /// <param name="searchPartsMode">部品検索モード</param>
        /// <param name="blGoodsCode">ＢＬコード</param>
        /// <param name="emptyInfoSetting">空商品情報セット区分(true:空商品情報セット false:通常商品情報セット)</param>
        // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
        //public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, int blGoodsCode, bool emptyInfoSetting)
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, int blGoodsCode, bool emptyInfoSetting, bool saveValueSetting)
        // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        //<<<2010/07/21
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                // ADD 2013/07/09 T.Miyamoto ------------------------------>>>>>
                if ((row.SalesSlipDtlNumSrc != 0) && (row.AcptAnOdrStatusSrc != row.AcptAnOdrStatus))
                {
                    return;
                }
                // ADD 2013/07/09 T.Miyamoto ------------------------------<<<<<
                #region 退避
                // 2009/11/25 >>>
                //int svBLGoodsCode = ( row.BLGoodsCode != 0 ) ? row.BLGoodsCode : goodsUnitData.BLGoodsCode;
                int svBLGoodsCode = goodsUnitData.BLGoodsCode;
                if ((GoodsKind)goodsUnitData.GoodsKindResolved == GoodsKind.Parent || (GoodsKind)goodsUnitData.GoodsKindResolved == GoodsKind.Join)
                {
                    if (( blGoodsCode != 0 )) svBLGoodsCode = blGoodsCode;
                }
                // 2009/11/25 <<<
                BLGoodsCdUMnt blGoods = this._salesSlipInputInitDataAcs.GetBLGoodsInfo_FromBLGoods(svBLGoodsCode);
                string svBLGoodsFullName = string.Empty;
                if ((searchPartsMode == SearchPartsMode.BLCodeSearch) && (blGoods != null)) svBLGoodsFullName = blGoods.BLGoodsFullName;
                
                DateTime stockDate = row.StockDate;
                string partySalesSlipNum = row.PartySalesSlipNum;
                Guid dtlRelationGuid = row.DtlRelationGuid;

                double svAcceptAnOrderCntDisplay = row.AcceptAnOrderCntDisplay;
                double svAcceptAnOrderCnt = row.AcceptAnOrderCnt;
                double svAcceptAnOrderCntDefault = row.AcceptAnOrderCntDefault;
                double svAcptAnOdrAdjustCnt = row.AcptAnOdrAdjustCnt;
                double svAcptAnOdrRemainCnt = row.AcptAnOdrRemainCnt;
                double svShipmentCntDisplay = row.ShipmentCntDisplay;
                double svShipmentCnt = row.ShipmentCnt;

                //>>>2010/07/21
                string goodsNameKana = row.GoodsNameKana;
                string blGoodsFullName = row.BLGoodsFullName;
                string prtBLGoodsName = row.PrtBLGoodsName;
                int blGroupCode = row.BLGroupCode;
                string blGroupName = row.BLGroupName;
                int goodsMGroup = row.GoodsMGroup;
                string goodsMGroupName = row.GoodsMGroupName;
                int goodsLGroup = row.GoodsLGroup;
                string goodsLGroupName = row.GoodsLGroupName;
                string makerKanaName = row.MakerKanaName;
                int rateBLGoodsCode = row.RateBLGoodsCode;
                //<<<2010/07/21
                #endregion

                // --- ADD 2010/01/27 -------------->>>>>
                string warehouseCode = row.WarehouseCode; //倉庫コード
                string warehouseName = row.WarehouseName; //倉庫名称
                string warehouseShelfNo = row.WarehouseShelfNo; //棚番
                double supplierStock = row.SupplierStock; //在庫数
                double supplierStockDisplay = row.SupplierStockDisplay; //在庫数(画面表示)
                int salesOrderDivCd = row.SalesOrderDivCd; //売上在庫取寄区分
                // --- ADD 2010/01/27 --------------<<<<<

                //>>>2011/03/16
                int inqRowNumber = row.InqRowNumber;
                int inqRowNumDerivedNo = row.InqRowNumDerivedNo;
                //<<<2011/03/16

                // --- ADD 2012/08/30 Y.Wakita ---------->>>>>
                int svSupplierCdForStock = row.SupplierCdForStock;  // 仕入先コード(仕入情報)
                string svSupplierSnm = row.SupplierSnm;             // 仕入先略称
                // --- ADD 2012/08/30 Y.Wakita ----------<<<<<

                // --- DEL 2012/10/19 Y.Wakita ---------->>>>>
                //// --- ADD 2012/10/11 Y.Wakita ---------->>>>>
                //string svBoCode = row.BoCode;										// BO区分
                //int svSupplierCdForOrder = row.SupplierCdForOrder; 					// 発注先
                //string svSupplierSnmForOrder = row.SupplierSnmForOrder; 			// 発注先名称
                //double svAcceptAnOrderCntForOrder = row.AcceptAnOrderCntForOrder; 	// 発注数
                //string svUOEDeliGoodsDiv = row.UOEDeliGoodsDiv; 					// 納品区分
                //string svDeliveredGoodsDivNm = row.DeliveredGoodsDivNm; 			// 納品区分名称
                //string svDeliveredGoodsDivNmSave = row.DeliveredGoodsDivNmSave; 	// 納品区分名称（保存用）
                //string svFollowDeliGoodsDiv = row.FollowDeliGoodsDiv; 				// H納品区分
                //string svFollowDeliGoodsDivNm = row.FollowDeliGoodsDivNm; 			// H納品区分名称
                //string svFollowDeliGoodsDivNmSave = row.FollowDeliGoodsDivNmSave; 	// H納品区分名称（保存用）
                //string svUOEResvdSection = row.UOEResvdSection; 					// 指定拠点
                //string svUOEResvdSectionNm = row.UOEResvdSectionNm; 				// 指定拠点名称
                //string svUOEResvdSectionNmSave = row.UOEResvdSectionNmSave; 		// 指定拠点名称（保存用）
                //// --- ADD 2012/10/11 Y.Wakita ----------<<<<<
                // --- DEL 2012/10/19 Y.Wakita ----------<<<<<

                // --- ADD 2013/12/10 Y.Wakita ---------->>>>>
                int svCmpltSalesRowNo = row.CmpltSalesRowNo;            // 純正-BL商品コード
                int svCmpltGoodsMakerCd = row.CmpltGoodsMakerCd;        // 純正-メーカー
                string svCmpltGoodsName = row.CmpltGoodsName;           // 純正-商品番号
                double svCmpltSalesUnPrcFl = row.CmpltSalesUnPrcFl;     // 純正-定価
                // --- ADD 2013/12/10 Y.Wakita ----------<<<<<
                // --- ADD 2014/07/14 Y.Wakita ---------->>>>>
                string svGoodsNo = row.GoodsNo;             // 商品番号
                // --- ADD 2014/07/14 Y.Wakita ----------<<<<<

                // --- ADD 2014/04/03 Y.Wakita ---------->>>>>
                bool acceptAnOrderCntClearFlg = false;
                if (setDefaultRowCount == false)
                {
                    // 品番が変更された場合
                    if (row.GoodsNo != goodsUnitData.GoodsNo)
                        acceptAnOrderCntClearFlg = true;
                }
                // --- ADD 2014/04/03 Y.Wakita ----------<<<<<

                this.ClearSalesDetailRow(row);

                row.SalesSlipCdDtl = salesSlipCdDtl;
                row.StockDate = stockDate;
                row.PartySalesSlipNum = partySalesSlipNum;
                row.DtlRelationGuid = dtlRelationGuid;
                
                //>>>2011/03/16
                row.InqRowNumber = inqRowNumber;
                row.InqRowNumDerivedNo = inqRowNumDerivedNo;
                //<<<2011/03/16

                if (goodsUnitData != null)
                {
                    #region 商品情報
                    //--------------------------------------------
                    // 商品情報
                    //--------------------------------------------
                    GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                    GoodsInfoKey goodsInfoKey = new GoodsInfoKey(tempGoodsUnitData.GoodsNo, tempGoodsUnitData.GoodsMakerCd);
                    if (!this._goodsUnitDataInfo.ContainsKey(goodsInfoKey))
                    {
                        this._goodsUnitDataInfo.Add(goodsInfoKey, tempGoodsUnitData);
                    }

                    row.GoodsMakerCd = goodsUnitData.GoodsMakerCd;					// メーカーコード
                    row.MakerName = goodsUnitData.MakerName;						// メーカー名称
                    row.MakerKanaName = goodsUnitData.MakerKanaName;                // メーカーカナ名称
                    row.GoodsNo = goodsUnitData.GoodsNo;						    // 品番
                    row.GoodsName = goodsUnitData.GoodsName;                        // 品名
                    row.GoodsNameKana = goodsUnitData.GoodsNameKana;                // 品名カナ
                    row.BLGoodsCode = goodsUnitData.BLGoodsCode;                    // BLコード
                    row.BLGoodsFullName = goodsUnitData.BLGoodsFullName;            // BLコード名称(全角)
                    row.GoodsLGroup = goodsUnitData.GoodsLGroup;                    // 商品大分類コード
                    row.GoodsLGroupName = goodsUnitData.GoodsLGroupName;            // 商品大分類名称
                    row.GoodsMGroup = goodsUnitData.GoodsMGroup;                    // 商品中分類コード
                    row.GoodsMGroupName = goodsUnitData.GoodsMGroupName;            // 商品中分類名称
                    row.BLGroupCode = goodsUnitData.BLGroupCode;                    // BLグループコード
                    row.BLGroupName = goodsUnitData.BLGroupName;                    // BLグループコード名称
                    row.GoodsRateRank = goodsUnitData.GoodsRateRank;                // 商品掛率ランク
                    row.TaxationDivCd = goodsUnitData.TaxationDivCd;                // 課税区分
                    //row.GoodsKindCode = goodsUnitData.GoodsKindCode;                // 商品属性  // DEL 2010/09/19
                    row.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;    // 自社分類コード
                    row.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;    // 自社分類名称
                    //row.SalesCode = goodsUnitData.SalesCode;                      // 販売区分コード// DEL 2012/04/09 yangmj redmine#29313
                    //row.SalesCdNm = goodsUnitData.SalesCodeName;                  // 販売区分名称// DEL 2012/04/09 yangmj redmine#29313
                    //--- ADD 2012/04/09 yangmj redmine#29313 ----->>>>>
                    if (!_salesCodeChgFlag)
                    {
                        row.SalesCode = goodsUnitData.SalesCode;                        // 販売区分コード
                        row.SalesCdNm = goodsUnitData.SalesCodeName;                    // 販売区分名称
                    }
                    //--- ADD 2012/04/09 yangmj redmine#29313 -----<<<<<

                    //row.SupplierCd = goodsUnitData.SupplierCd;                      // 仕入先コード  // DEL 2010/09/19
                    row.SupplierCdForStock = goodsUnitData.SupplierCd;              // 仕入先コード(仕入情報)
                    row.SupplierSnm = goodsUnitData.SupplierSnm;                    // 仕入先略称

                    // ADD 2010/09/19 --- >>>
                    if (!this._clearFlgForMaker)
                    {
                        row.GoodsKindCode = goodsUnitData.GoodsKindCode;
                        row.SupplierCd = goodsUnitData.SupplierCd;
                    }
                    // ADD 2010/09/19 --- <<<

                    // 発注先情報設定(発注情報)
                    UOESupplier uoeSupplier;

                    // --- ADD 2012/10/19 Y.Wakita ---------->>>>>
                    int code = goodsUnitData.SupplierCd;
                    if (goodsUnitData.SupplierCd == 0)
                    {
                        code = row.SupplierCd;
                    }
                    // --- ADD 2012/10/19 Y.Wakita ----------<<<<<

                    // --- UPD 2012/10/19 Y.Wakita ---------->>>>>
                    ////>>>2010/07/01
                    ////int st = this._uoeSupplierAcs.Read(out uoeSupplier, this._enterpriseCode, goodsUnitData.SupplierCd, this._salesSlip.SectionCode);
                    //int st = this._uoeSupplierAcs.ReadCache(out uoeSupplier, this._enterpriseCode, goodsUnitData.SupplierCd, this._salesSlip.SectionCode);
                    ////<<<2010/07/01
                    int st = this._uoeSupplierAcs.ReadCache(out uoeSupplier, this._enterpriseCode, code, this._salesSlip.SectionCode);
                    // --- UPD 2012/10/19 Y.Wakita ----------<<<<<

                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        row.SupplierCdForOrder = uoeSupplier.UOESupplierCd;         // 発注先コード
                        row.SupplierSnmForOrder = uoeSupplier.UOESupplierName;      // 発注先名称
                        // --- ADD 2012/10/11 Y.Wakita ---------->>>>>
                        row.BoCode = uoeSupplier.BoCode; 										// BO区分
                        row.UOEDeliGoodsDiv = uoeSupplier.UOEDeliGoodsDiv; 						// 納品区分
                        row.UOEResvdSection = uoeSupplier.UOEResvdSection; 						// 指定拠点
                        // --- ADD 2012/10/11 Y.Wakita ----------<<<<<
                    }
                    // --- ADD 2012/10/19 Y.Wakita ---------->>>>>
                    else
                    {
                        // キャッシュされていない場合は、初期値設定
                        uoeSupplier = new UOESupplier();
                        this.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);

                        row.SupplierCdForOrder = 0;
                        row.SupplierSnmForOrder = string.Empty;
                        row.BoCode = ctDefaultBoCode;
                        row.AcceptAnOrderCntForOrder = 0;
                        row.UOEDeliGoodsDiv = string.Empty;
                        row.DeliveredGoodsDivNm = string.Empty;
                        row.DeliveredGoodsDivNmSave = string.Empty;
                        row.FollowDeliGoodsDiv = string.Empty;
                        row.FollowDeliGoodsDivNm = string.Empty;
                        row.FollowDeliGoodsDivNmSave = string.Empty;
                        row.UOEResvdSection = string.Empty;
                        row.UOEResvdSectionNm = string.Empty;
                        row.UOEResvdSectionNmSave = string.Empty;
                    }
                    // --- ADD 2012/10/19 Y.Wakita ----------<<<<<
                    // 2009/11/25 Add >>>
                    // 検索で使用したコードと部品のBLコードが異なる場合

                    // 2010/04/02 Del >>>
                    //if ((blGoodsCode != 0)) goodsUnitData.SearchBLCode = blGoodsCode;　//ADD 2009/12/23   

                    // goodsUnitData.SearchBLCodeは、純正部品を選択した場合のみセットして良い
                    // 優良部品を選択した場合は、実績も優良部品のＢＬコードで取る
                    // 2010/04/02 Del <<<
                    bool blGoodsCodeChanged = ((goodsUnitData.SearchBLCode != 0) && (goodsUnitData.BLGoodsCode != goodsUnitData.SearchBLCode));
                    if (blGoodsCodeChanged)
                    {
                        GoodsUnitData wkGoodsUnitData = goodsUnitData.Clone();

                        // 実績は検索BLコードで集計する
                        wkGoodsUnitData.BLGoodsCode = wkGoodsUnitData.SearchBLCode;
                        _salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref wkGoodsUnitData, false);

                        row.BLGoodsCode = wkGoodsUnitData.BLGoodsCode;                    // BLコード
                        row.BLGoodsFullName = wkGoodsUnitData.BLGoodsFullName;            // BLコード名称(全角)
                        row.GoodsLGroup = wkGoodsUnitData.GoodsLGroup;                    // 商品大分類コード
                        row.GoodsLGroupName = wkGoodsUnitData.GoodsLGroupName;            // 商品大分類名称
                        row.GoodsMGroup = wkGoodsUnitData.GoodsMGroup;                    // 商品中分類コード
                        row.GoodsMGroupName = wkGoodsUnitData.GoodsMGroupName;            // 商品中分類名称
                        row.BLGroupCode = wkGoodsUnitData.BLGroupCode;                    // BLグループコード
                        row.BLGroupName = wkGoodsUnitData.BLGroupName;                    // BLグループコード名称
                        row.GoodsRateRank = wkGoodsUnitData.GoodsRateRank;                // 商品掛率ランク
                        row.SalesCode = wkGoodsUnitData.SalesCode;                        // 販売区分コード
                        row.SalesCdNm = wkGoodsUnitData.SalesCodeName;                    // 販売区分名称
                    }
                    // 2009/11/25 Add <<<
                    
                    row.RateBLGoodsCode = goodsUnitData.BLGoodsCode;                // BL商品コード（掛率）
                    row.RateBLGoodsName = goodsUnitData.BLGoodsFullName;            // BL商品コード名称（掛率）
                    row.RateGoodsRateGrpCd = goodsUnitData.GoodsRateGrpCode;        // 商品掛率グループコード（掛率）
                    row.RateGoodsRateGrpNm = goodsUnitData.GoodsRateGrpName;        // 商品掛率グループ名称（掛率）
                    row.RateBLGroupCode = goodsUnitData.BLGroupCode;                // BLグループコード（掛率）
                    row.RateBLGroupName = goodsUnitData.BLGroupName;                // BLグループ名称（掛率）
                    row.CanTaxDivChange = false;									// 課税非課税区分変更可能フラグ

                    if ((this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrtBLGoodsCodeDiv == 0) || // 印刷用BLコード区分(0:部品 1:検索)
                        (searchPartsMode == SearchPartsMode.GoodsNoSearch))
                    {
                        // 2009/11/25 >>>
                        //row.PrtBLGoodsCode = goodsUnitData.BLGoodsCode;
                        //row.PrtBLGoodsName = goodsUnitData.BLGoodsFullName;
                        row.PrtBLGoodsCode = row.BLGoodsCode;
                        row.PrtBLGoodsName = row.BLGoodsFullName;
                        // 2009/11/25 <<<
                    }
                    else
                    {
                        row.PrtBLGoodsCode = svBLGoodsCode;
                        row.PrtBLGoodsName = svBLGoodsFullName;
                    }

                    //>>>2010/06/26
                    ////>>>2010/02/26
                    //// BLコード変換
                    //if ((this._salesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM) &&
                    //    (goodsUnitData.BLGoodsCodeChange != 0))
                    //{
                    //    row.PrtBLGoodsCode = goodsUnitData.BLGoodsCodeChange;
                    //}
                    ////<<<2010/02/26
                    //<<<2010/06/26

                    if (salesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;					// 変更可能ステータス
                    }
                    else
                    {
                        row.EditStatus = ctEDITSTATUS_AllOK;							// 変更可能ステータス
                    }

                    double targetCount = 1;
                    double qty = this.GetQty(goodsUnitData);
                    if (qty != 0) targetCount = qty;

                    switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatus)
                    {
                        case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate: // 見積
                            {
                                if (this._salesSlip.EstimateDivide == (int)EstimateDivide.Estimate)
                                {
                                    // 通常見積
                                    if (setDefaultRowCount)
                                    {
                                        int sign = (row.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount) ? -1 : 1;
                                        row.ShipmentCntDisplay = targetCount * sign;
                                        sign = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                                        row.ShipmentCnt = row.ShipmentCntDisplay * sign; // 出荷数
                                    }
                                }
                                else
                                {
                                    // 単価見積
                                    row.ShipmentCntDisplay = 0;
                                    row.ShipmentCnt = row.ShipmentCntDisplay;
                                }
                                break;
                            }
                        case SalesSlipInputAcs.AcptAnOdrStatusState.Sales: // 売上
                        case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment: // 出荷
                            {
                                if (setDefaultRowCount)
                                {
                                    int sign = (row.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount) ? -1 : 1;
                                    row.ShipmentCntDisplay = targetCount * sign;
                                    sign = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                                    row.ShipmentCnt = row.ShipmentCntDisplay * sign; // 出荷数
                                }
                                // --- ADD 2014/03/17 Y.Wakita ---------->>>>>
                                else
                                {
                                    // --- ADD 2014/04/03 Y.Wakita ---------->>>>>
                                    if (acceptAnOrderCntClearFlg)
                                    {
                                        // 品番が変更された場合、クリアする。
                                        // --- ADD 2014/04/03 Y.Wakita ----------<<<<<
                                    svAcceptAnOrderCntDisplay = 0;
                                    svAcceptAnOrderCnt = 0;
                                    svAcceptAnOrderCntDefault = 0;
                                    svAcptAnOdrAdjustCnt = 0;
                                    svAcptAnOdrRemainCnt = 0;
                                    svShipmentCntDisplay = 0;
                                    svShipmentCnt = 0;
                                        // --- ADD 2014/04/03 Y.Wakita ---------->>>>>
                                    }
                                    // --- ADD 2014/04/03 Y.Wakita ----------<<<<<
                                }
                                // --- ADD 2014/03/17 Y.Wakita ----------<<<<<
                                break;
                            }
                        //>>>2010/09/27
                        case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder: // 受注
                            {
                                if (setDefaultRowCount)
                                {
                                    int sign = (row.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount) ? -1 : 1;
                                    row.AcceptAnOrderCntDisplay = targetCount * sign;
                                    sign = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                                    row.AcceptAnOrderCnt = row.AcceptAnOrderCntDisplay * sign; // 出荷数

                                    // 受注情報設定
                                    this.SettingSalesDetailAcceptAnOrder(row.SalesRowNo);

                                    SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);
                                    acptAnOdrRow.ShipmentCntDisplay = row.AcceptAnOrderCntDisplay;

                                    // 数量設定処理
                                    this.SettingAcptAnOdrDetailRowShipmentCnt(row.SalesRowNo);
                                }
                                break;
                            }
                        //<<<2010/09/27
                    }

                    if ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatus != SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) // 2010/09/27
                    { // 2010/09/27
                        if (setDefaultRowCount)
                        {
                            row.AcceptAnOrderCntDisplay = 0; // 受注数
                            row.AcceptAnOrderCnt = 0; // 受注数
                            row.AcceptAnOrderCntDefault = 0;
                            row.AcptAnOdrAdjustCnt = 0; // 受注調整数
                            row.AcptAnOdrRemainCnt = 0; // 受注残数
                        }
                        else
                        {
                            row.AcceptAnOrderCntDisplay = svAcceptAnOrderCntDisplay;
                            row.AcceptAnOrderCnt = svAcceptAnOrderCnt;
                            row.AcceptAnOrderCntDefault = svAcceptAnOrderCntDefault;
                            row.AcptAnOdrAdjustCnt = svAcptAnOdrAdjustCnt;
                            row.AcptAnOdrRemainCnt = svAcptAnOdrRemainCnt;
                            row.ShipmentCntDisplay = svShipmentCntDisplay;
                            row.ShipmentCnt = svShipmentCnt;
                        }
                    } //<<<2010/09/27
                    // --- ADD 2014/04/03 Y.Wakita ---------->>>>>
                    else
                    {
                        if (setDefaultRowCount == false)
                        {
                            row.AcceptAnOrderCntDisplay = svAcceptAnOrderCntDisplay;
                            row.AcceptAnOrderCnt = svAcceptAnOrderCnt;
                            row.AcceptAnOrderCntDefault = svAcceptAnOrderCntDefault;
                            row.AcptAnOdrAdjustCnt = svAcptAnOdrAdjustCnt;
                            row.AcptAnOdrRemainCnt = svAcptAnOdrRemainCnt;
                            row.ShipmentCntDisplay = svShipmentCntDisplay;
                            row.ShipmentCnt = svShipmentCnt;
                        }
                    }
                    // --- ADD 2014/04/03 Y.Wakita ----------<<<<<

                    row.ShipmentCntDefForChk = row.ShipmentCnt; // 出荷数初期値（変更チェック用）
                    row.AcceptAnOrderCntDefForChk = row.AcceptAnOrderCnt; // 受注数初期値（変更チェック用）

                    //>>>2012/02/07
                    //// 2012/01/16 Add >>>
                    //row.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote;
                    //// 2012/01/16 Add <<<
                    row.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote;
                    // --- UPD 2013/06/17 Y.Wakita ---------->>>>>
                    //if (goodsUnitData.GoodsSpecialNote.Length > 40) row.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote.Substring(0, 40);
                    if (goodsUnitData.SetSpecialNote.Length != 0)
                        // セット品
                        row.GoodsSpecialNote = goodsUnitData.SetSpecialNote;
                    if (row.GoodsSpecialNote.Length > 40) row.GoodsSpecialNote = row.GoodsSpecialNote.Substring(0, 40);
                    // --- UPD 2013/06/17 Y.Wakita ----------<<<<<
                    //<<<2012/02/07
                    #endregion

                    #region 在庫情報
                    //--------------------------------------------
                    // 在庫情報
                    //--------------------------------------------
                    //List<string> warehouseList = new List<string>();
                    //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0);
                    //if ((stock != null) && (warehouseList.Contains(stock.WarehouseCode)))
                    // ---------- UPD 2010/01/27 ---------->>>>>>>>>>
                    //売上日変更した場合の商品情報再取得時、在庫情報を更新しない
                    if (!this._salesSlip.StockUpdateFlag) // ADD 2010/01/27
                    {
                        if (stock != null)
                        {
                            this.CacheStockInfo(stock);

                            row.WarehouseCode = stock.WarehouseCode;
                            row.WarehouseName = stock.WarehouseName;
                            row.WarehouseShelfNo = stock.WarehouseShelfNo;
                            row.SupplierStock = stock.ShipmentPosCnt;
                            row.SalesOrderDivCd = (int)SalesOrderDivCd.Stock; // 売上在庫取寄区分(0:取寄 1:在庫)
                            //row.SupplierStockDisplay = row.SupplierStock - row.ShipmentCntDisplay;   //DEL 2011/07/20
                            row.SupplierStockDisplay = row.SupplierStock;          //ADD 2011/07020
                        }
                        else
                        {
                            row.SupplierStock = 0;
                            row.SalesOrderDivCd = (int)SalesOrderDivCd.NonStock; // 売上在庫取寄区分(0:取寄 1:在庫)
                            row.SupplierStockDisplay = 0;
                        }
                    }
                    else
                    {
                        // --- ADD 2010/01/27 -------------->>>>>
                        row.WarehouseCode = warehouseCode;
                        row.WarehouseName = warehouseName;
                        row.WarehouseShelfNo = warehouseShelfNo;
                        row.SupplierStock = supplierStock;
                        row.SalesOrderDivCd = salesOrderDivCd;
                        row.SupplierStockDisplay = supplierStockDisplay;
                        // --- ADD 2010/01/27 --------------<<<<<
                    }
                    // ---------- UPD 2010/01/27 ----------<<<<<<<<<<
                    #endregion

                    #region 得意先掛率グループコード
                    row.CustRateGrpCode = this.GetCustRateGroupCode(row.GoodsMakerCd); // 得意先掛率グループコード
                    #endregion

                    #region 商品価格情報
                    //--------------------------------------------
                    // 商品価格情報
                    //--------------------------------------------
                    DateTime targetDate = new DateTime();
                    switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatus)
                    {
                        case AcptAnOdrStatusState.Estimate:
                        case AcptAnOdrStatusState.UnitPriceEstimate:
                            targetDate = this._salesSlip.SalesDate;
                            break;
                        case AcptAnOdrStatusState.AcceptAnOrder:
                            targetDate = this._salesSlip.SalesDate;
                            break;
                        case AcptAnOdrStatusState.Sales:
                            targetDate = this._salesSlip.SalesDate;
                            break;
                        case AcptAnOdrStatusState.Shipment:
                            targetDate = this._salesSlip.ShipmentDay;
                            break;
                    }
                    GoodsPrice goodsPrice = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsUnitData.GoodsPriceList);
                    if (goodsPrice != null)
                    {
                        row.OpenPriceDiv = goodsPrice.OpenPriceDiv; // オープン価格区分
                    }

                    if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                    {
                        this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, true); // 単価算出処理
                        // --- ADD liusy 2013/07/25 for Redemine34551 ------------>>>>>>>>>>>>>
                        if (setDefaultRowCount)
                        {
                            //受注データ単価など項目の補正
                            SettingAcceptAnOrderforPrice(row);
                        }
                        // --- ADD liusy 2013/07/25 for Redemine#34551 ------------<<<<<<<<<<<<<
                    }
                    #endregion

                    #region その他
                    //--------------------------------------------
                    // その他
                    //--------------------------------------------
                    //>>>2010/02/26
                    //row.DeliGdsCmpltDueDate = DateTime.Today; // 納品完了予定日
                    row.DeliGdsCmpltDueDate = string.Empty; // 納品完了予定日
                    //<<<2010/02/26

                    double detailGrossProfitRate = 0;
                    int signn = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                    if ((row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) ||
                       (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone))
                    {
                        // 外税 非課税 → 税抜定価から算出
                        this.GetRate((row.SalesMoneyTaxExc - row.Cost * signn), row.SalesMoneyTaxExc, out detailGrossProfitRate); // 小数第３位を四捨五入固定
                    }
                    else if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        // 内税 → 税込定価から算出
                        this.GetRate((row.SalesMoneyTaxInc - row.Cost * signn), row.SalesMoneyTaxInc, out detailGrossProfitRate); // 小数第３位を四捨五入固定
                    }
                    row.DetailGrossProfitRate = detailGrossProfitRate; // 明細粗利率

                    if (this._partySaleSlipDiv == (int)SalesSlipInputConstructionAcs.PartySaleSlipDiv.On) row.PartySlipNumDtl = SalesSlip.PartySaleSlipNum; // 得意先注番
                    
                    this.SettingSearchPartsMode(row, searchPartsMode); // 部品検索状態

                    //>>>2010/02/26
                    // 回答納期
                    if ((this._salesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM) &&
                        ((this._salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) ||
                        // 2011/01/31 >>>
                        ( this._salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales ) ||
                        // 2011/01/31 <<<
                         ( this._salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate ) ))
                    {
                        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// 2012/08/30 UPD T.Yoshioka 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //// row.DeliGdsCmpltDueDate = this.GetAnswerDeliveryDate(this._salesSlip, row.WarehouseCode, row.WarehouseName, row.WarehouseShelfNo);
                        //row.DeliGdsCmpltDueDate = this.GetAnswerDeliveryDate(this._salesSlip, row.WarehouseCode, row.WarehouseName, row.WarehouseShelfNo, stock, row.ShipmentCnt);
                        //// 2012/08/30 UPD T.Yoshioka 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        #endregion
                        Int16 ansDeliDateDiv;
                        row.DeliGdsCmpltDueDate = this.GetAnswerDeliveryDate(this._salesSlip, row.WarehouseCode, row.WarehouseName, row.WarehouseShelfNo, stock, row.ShipmentCnt, out ansDeliDateDiv);
                        row.AnsDeliDateDiv = ansDeliDateDiv;
                        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    //<<<2010/02/26

                    // --- ADD 2014/07/14 Y.Wakita ---------->>>>>
                    // 商品番号に変更がない場合、純正情報を再設定する。
                    if (row.GoodsNo.Trim() == svGoodsNo.Trim())
                    {
                        // --- ADD 2014/07/14 Y.Wakita ----------<<<<<

                    // --- ADD 2013/12/10 Y.Wakita ---------->>>>>
                    row.CmpltSalesRowNo = svCmpltSalesRowNo;        // 純正-BL商品コード
                    row.CmpltGoodsMakerCd = svCmpltGoodsMakerCd;    // 純正-メーカー
                    row.CmpltGoodsName = svCmpltGoodsName;          // 純正-商品番号
                    row.CmpltSalesUnPrcFl = svCmpltSalesUnPrcFl;    // 純正-定価
                    // --- ADD 2013/12/10 Y.Wakita ----------<<<<<

                        // --- ADD 2014/07/14 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2014/07/14 Y.Wakita ----------<<<<<
                    #endregion
                }

                //>>>2010/07/21
                if (emptyInfoSetting)
                {
                    // --- ADD 2012/09/05 Y.Wakita ---------->>>>>
                    if (saveValueSetting)
                    {
                        // --- ADD 2012/09/05 Y.Wakita ----------<<<<<
		                    // 空商品情報設定、特定項目を再設定する
		                    row.GoodsNameKana = goodsNameKana;
		                    row.BLGoodsFullName = blGoodsFullName;
		                    row.PrtBLGoodsName = prtBLGoodsName;
		                    row.MakerKanaName = makerKanaName;
		                    row.RateBLGoodsCode = rateBLGoodsCode;
		                    row.BLGroupCode = blGroupCode;
		                    row.BLGroupName = blGroupName;
		                    row.GoodsMGroup = goodsMGroup;
		                    row.GoodsMGroupName = goodsMGroupName;
		                    row.GoodsLGroup = goodsLGroup;
		                    row.GoodsLGroupName = goodsLGroupName;
		                    // --- ADD 2012/08/30 Y.Wakita ---------->>>>>
		                    row.SupplierCdForStock = svSupplierCdForStock;  // 仕入先コード(仕入情報)
		                    row.SupplierSnm = svSupplierSnm;                // 仕入先略称
		                    // --- ADD 2012/08/30 Y.Wakita ----------<<<<<
                            // --- DEL 2012/10/19 Y.Wakita ---------->>>>>
                            //// --- ADD 2012/10/11 Y.Wakita ---------->>>>>
                            //row.BoCode = svBoCode;                                      // BO区分
                            //row.SupplierCdForOrder = svSupplierCdForOrder; 				// 発注先
                            //row.SupplierSnmForOrder = svSupplierSnmForOrder; 			// 発注先名称
                            //row.AcceptAnOrderCntForOrder = svAcceptAnOrderCntForOrder; 	// 発注数
                            //row.UOEDeliGoodsDiv = svUOEDeliGoodsDiv; 					// 納品区分
                            //row.DeliveredGoodsDivNm = svDeliveredGoodsDivNm; 			// 納品区分名称
                            //row.DeliveredGoodsDivNmSave = svDeliveredGoodsDivNmSave; 	// 納品区分名称（保存用）
                            //row.FollowDeliGoodsDiv = svFollowDeliGoodsDiv; 				// H納品区分
                            //row.FollowDeliGoodsDivNm = svFollowDeliGoodsDivNm; 			// H納品区分名称
                            //row.FollowDeliGoodsDivNmSave = svFollowDeliGoodsDivNmSave; 	// H納品区分名称（保存用）
                            //row.UOEResvdSection = svUOEResvdSection; 					// 指定拠点
                            //row.UOEResvdSectionNm = svUOEResvdSectionNm; 				// 指定拠点名称
                            //row.UOEResvdSectionNmSave = svUOEResvdSectionNmSave; 		// 指定拠点名称（保存用）
                            //// --- ADD 2012/10/11 Y.Wakita ----------<<<<<
                            // --- DEL 2012/10/19 Y.Wakita ----------<<<<<
                            // --- ADD 2012/09/05 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2012/09/05 Y.Wakita ----------<<<<<
                }
                //<<<2010/07/21

                // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>> 
                int ansPureGoodsNo = 0;
                string pureGoodsMakerCd = string.Empty;
                // 優良商品の場合、回答純正商品番号と純正商品メーカーコードの取得
                // 純正商品の場合は、0、空文字が返ってくる
                GetPureInfo(_partsInfo, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, 0, out ansPureGoodsNo, out pureGoodsMakerCd);

                // 回答純正商品番号と純正商品メーカーコードの設定
                if (ansPureGoodsNo.Equals(0))
                {
                    // 純正商品の場合 商品番号と商品メーカーコードを設定
                    row.AnsPureGoodsNo = row.GoodsNo;
                    row.PureGoodsMakerCd = row.GoodsMakerCd;
                }
                else
                {
                    // 優良商品の場合
                    row.AnsPureGoodsNo = pureGoodsMakerCd;    // 回答純正商品番号
                    row.PureGoodsMakerCd = ansPureGoodsNo;    // 純正商品メーカーコード
                }
                // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
                // --- DEL 2014/07/14 Y.Wakita ---------->>>>>
                //row.CmpltSalesRowNo = 0;
                //row.CmpltGoodsMakerCd = 0;
                //row.CmpltGoodsName = string.Empty;
                //row.CmpltSalesUnPrcFl = 0;
                // --- DEL 2014/07/14 Y.Wakita ----------<<<<<

                //---DEL 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
                //// --- UPD 2014/01/29 T.Miyamoto ------------------------------>>>>>
                ////// 商品属性が「1:優良」の場合に純正定価情報の取得を行う
                ////if (goodsUnitData.GoodsKindCode == (int)GoodsKindCode.PrimeGoods)
                //// 親情報(結合・セット)が存在する場合に純正定価情報の取得を行う
                //if ((goodsUnitData.JoinSourceMakerCode != 0) && (goodsUnitData.JoinSrcPartsNoWithH != ""))
                //// --- UPD 2014/01/29 T.Miyamoto ------------------------------<<<<<
                //---DEL 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
                //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
                // 親情報(結合・セット)に純正品が設定されている場合に純正定価情報の取得を行う
                if (   (0 < goodsUnitData.JoinSourceMakerCode && SalesSlipInputAcs.ctPureGoodsMakerCode >= goodsUnitData.JoinSourceMakerCode)
                    && (!string.IsNullOrEmpty(goodsUnitData.JoinSrcPartsNoWithH)))
                //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
                {
                    PartsInfoDataSet.UsrGoodsInfoRow PureGoodsInfoRow = GetPurePriceInfo(_partsInfo, goodsUnitData);
                    if (PureGoodsInfoRow != null)
                    {
                        row.CmpltSalesRowNo = PureGoodsInfoRow.BlGoodsCode;    // 純正-BL商品コード
                        row.CmpltGoodsMakerCd = PureGoodsInfoRow.GoodsMakerCd; // 純正-メーカー
                        row.CmpltGoodsName = PureGoodsInfoRow.GoodsNo;         // 純正-商品番号
                        row.CmpltSalesUnPrcFl = PureGoodsInfoRow.PriceTaxExc;  // 純正-定価
                    }
                }
                // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<

            }
        }

        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
        /// <summary>
        ///  提供データ純正部品情報取得
        /// </summary>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="retPartsInfo"></param>
        private void GetPartsInfo(int goodsMakerCd, string goodsNo, out PartsInfoDataSet.PartsInfoRow retPartsInfo)
        {
            retPartsInfo = null;

            if (goodsMakerCd == 0 || string.IsNullOrEmpty(goodsNo)) return;
            if (this._partsInfo == null || this._partsInfo.PartsInfo == null || this._partsInfo.PartsInfo.Count == 0) return;

            foreach (PartsInfoDataSet.PartsInfoRow row in this._partsInfo.PartsInfo)
            {
                if (row.CatalogPartsMakerCd == goodsMakerCd && (row.ClgPrtsNoWithHyphen.Trim() == goodsNo.Trim() || row.NewPrtsNoWithHyphen.Trim() == goodsNo.Trim()))
                {
                    retPartsInfo = row;
                    return;
                }
            }
        }
        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

        // --- ADD liusy 2013/07/25 for Redemine34551 ------------>>>>>>>>>>>>>
        /// <summary>
        /// 受注データ単価など項目の補正
        /// </summary>
        /// <param name="row">売上明細データテーブル行オブジェクト</param>
        private void SettingAcceptAnOrderforPrice(SalesInputDataSet.SalesDetailRow row)
        {
            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatus)
            {
                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder: // 受注
                    {

                        // 受注情報設定
                        this.SettingSalesDetailAcceptAnOrder(row.SalesRowNo);

                        SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);
                        acptAnOdrRow.ShipmentCntDisplay = row.AcceptAnOrderCntDisplay;

                        // 数量設定処理及び掛率から単価再計算の補正
                        this.SettingAcptAnOdrDetailRowShipmentCnt(row.SalesRowNo);
                        break;
                    }
            }
        }
        // --- ADD liusy 2013/07/25 for Redemine#34551 ------------<<<<<<<<<<<<<
        /// <summary>
        /// 部品検索状態設定処理
        /// </summary>
        /// <param name="row">売上明細データテーブル行オブジェクト</param>
        /// <param name="searchPartsMode">部品検索モード</param>
        private void SettingSearchPartsMode(SalesInputDataSet.SalesDetailRow row, SearchPartsMode searchPartsMode)
        {
            if (row != null)
            {
                switch (searchPartsMode)
                {
                    case SearchPartsMode.BLCodeSearch:
                        if (row.BLGoodsCode != 0)
                        {
                            row.SearchPartsModeState = (int)SearchPartsModeState.BLCodeSearch;
                        }
                        else
                        {
                            row.SearchPartsModeState = (int)SearchPartsModeState.NonSearch;
                        }
                        break;
                    case SearchPartsMode.GoodsNoSearch:
                        if (!string.IsNullOrEmpty(row.GoodsNo))
                        {
                            row.SearchPartsModeState = (int)SearchPartsModeState.GoodsNoSearch;
                        }
                        else
                        {
                            row.SearchPartsModeState = (int)SearchPartsModeState.NonSearch;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 部品検索状態取得処理
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <returns></returns>
        public SearchPartsModeState GetSearchPartsMode(int salesRowNo)
        {
            SearchPartsModeState retState = SearchPartsModeState.NonSearch;
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null)
            {
                retState = (SearchPartsModeState)row.SearchPartsModeState;
            }
            return retState;
        }

        /// <summary>
        /// QTY取得処理
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        private double GetQty(GoodsUnitData goodsUnitData)
        {
            switch ((GoodsKind)goodsUnitData.GoodsKindResolved)
            {
                case GoodsKind.Parent:
                    //-----UPD 2011/11/08----->>>>>
                    //return goodsUnitData.PartsQty;
                    if ((GoodsKind)goodsUnitData.GoodsKind == GoodsKind.Join)
                    {
                        return goodsUnitData.JoinQty;
                    }
                    else
                    {
                        return goodsUnitData.PartsQty;
                    } 
                    //-----UPD 2011/11/08-----<<<<<
                case GoodsKind.Join:
                    return goodsUnitData.JoinQty;
                case GoodsKind.Set:
                    return goodsUnitData.SetQty;
                case GoodsKind.Subst:
                    return goodsUnitData.PartsQty;
                // 2009.06.23 >>>
                //case GoodsKind.PluralSubst:
                case GoodsKind.SubstPlrl:
                // 2009.06.23 <<<
                    return goodsUnitData.PartsQty;
                default:
                    // --- UPD m.suzuki 2010/04/12 ---------->>>>>
                    //return 0;
                    return goodsUnitData.PartsQty;
                // --- UPD m.suzuki 2010/04/12 ----------<<<<<
            }
        }

        /// <summary>
        /// 指定した売上商品区分を元に、売上明細データ行オブジェクトに関連する項目を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesGoodsCd">売上商品区分</param>
        /// <param name="salesRateClearFlag">単価情報クリアＦlag</param>
        // --- UPD 2009/12/23 ---------->>>>>
        //public void SalesDetailRowSalesGoodsCdSetting(int salesRowNo, int salesGoodsCd)
        public void SalesDetailRowSalesGoodsCdSetting(int salesRowNo, int salesGoodsCd, bool salesRateClearFlag)
        // --- UPD 2009/12/23 ----------<<<<<
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
			int taxFracProcCd = 0;
			double taxFracProcUnit = 0;
            //this._salesSlipInputInitDataAcs.GetFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            // --- UPD 2013/08/07 Y.Wakita ---------->>>>>
            //this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, 0, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            // --- UPD 2013/08/07 Y.Wakita ----------<<<<<

            if (row != null)
            {
                switch ((SalesGoodsCd)salesGoodsCd)
                {
                    case SalesGoodsCd.Goods:
                        {
                            #region ●行値引き
                            if (row.EditStatus == ctEDITSTATUS_RowDiscount)    // 行値引き
                            {
                                row.SalesGoodsCd = salesGoodsCd;
                                row.CanTaxDivChange = false;
                                row.EditStatus = ctEDITSTATUS_RowDiscount;

                                int sign = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                                // 非課税
                                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                                {
                                    row.SalesMoneyTaxExc = row.SalesMoneyDisplay * sign;
                                    row.SalesMoneyTaxInc = row.SalesMoneyDisplay * sign;
                                    row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
                                }
                                // 総額表示しない
                                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                                {
                                    row.SalesMoneyTaxExc = row.SalesMoneyDisplay * sign;
                                    row.SalesMoneyTaxInc = (row.SalesMoneyDisplay + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyDisplay)) * sign;
                                    row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxExc;
                                }
                                // 総額表示する
                                else
                                {
                                    row.SalesMoneyTaxExc = (row.SalesMoneyDisplay - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyDisplay)) * sign;
                                    row.SalesMoneyTaxInc = row.SalesMoneyDisplay * sign;
                                    row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxInc;
                                }
                                row.SalesPriceConsTax = (long)((decimal)row.SalesMoneyTaxInc - (decimal)row.SalesMoneyTaxExc);
                            }
                            #endregion

                            #region ●商品値引き
                            else if (row.EditStatus == ctEDITSTATUS_GoodsDiscount)
                            {
                                row.SalesGoodsCd = salesGoodsCd;
                                row.EditStatus = ctEDITSTATUS_GoodsDiscount;
                                row.CanTaxDivChange = true;

                                #region ●通常
                                // --- UPD 2009/12/23 ---------->>>>>
                                //this.SalesDetailRowSalesMoneySetting(salesRowNo, row.SalesMoneyDisplay);
                                this.SalesDetailRowSalesMoneySetting(salesRowNo, row.SalesMoneyDisplay, salesRateClearFlag);
                                // --- UPD 2009/12/23 ----------<<<<<

                                // 金額手入力区分
                                if ((row.SalesUnPrcDisplay == 0) && (row.SalesMoneyDisplay != 0))
                                {
                                    row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Input;
                                }
                                else
                                {
                                    row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
                                }
                                #endregion
                            }
                            #endregion

                            #region ●注釈
                            else if (row.SalesSlipCdDtl == 3)
                            {
                                row.ShipmentCnt = 0;
                                row.SalesGoodsCd = salesGoodsCd;
                                row.CanTaxDivChange = false;
                                row.EditStatus = ctEDITSTATUS_Annotation;
                            }
                            #endregion

                            else
                            {
                                #region ●品番必須モード
                                // 品番必須モード
                                if ((this._salesSlipInputInitDataAcs.InputMode != SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo) && (string.IsNullOrEmpty(row.GoodsNo)))
                                {
                                    if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                                    {
                                        row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxExc;
                                    }
                                    else
                                    {
                                        row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxInc;
                                    }
                                    row.SalesGoodsCd = salesGoodsCd;
                                    row.EditStatus = ctEDITSTATUS_AllOK;
                                    row.CanTaxDivChange = true;
                                }
                                #endregion

                                #region ●通常
                                // --- UPD 2009/12/23 ---------->>>>>
                                //this.SalesDetailRowSalesMoneySetting(salesRowNo, row.SalesMoneyDisplay);
                                this.SalesDetailRowSalesMoneySetting(salesRowNo, row.SalesMoneyDisplay, salesRateClearFlag);
                                // --- UPD 2009/12/23 ----------<<<<<

                                // 金額手入力区分
                                if ((row.SalesUnPrcDisplay == 0) && (row.SalesMoneyDisplay != 0))
                                {
                                    row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Input;
                                }
                                else
                                {
                                    row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
                                }
                                #endregion
                            }
                            break;
                        }
                    case SalesGoodsCd.ConsTaxAdjust:								// 売上商品区分 = 2:消費税調整
                    case SalesGoodsCd.AccRecConsTaxAdjust:								// 売上商品区分 = 4:売掛用消費税調整
                        {
                            if (row.SalesMoneyDisplay == 0)
                            {
                                this.ClearSalesDetailRow(row.SalesRowNo);
                            }
                            else
                            {
                                row.GoodsName = "消費税調整";
                                row.GoodsNameKana = "消費税調整";
                                row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
                                //if (this._salesSlip.SalesSlipCd == 1) // 0:売上 1:返品
                                //{
                                //    row.ShipmentCnt = -1;
                                //}
                                //else
                                //{
                                //    row.ShipmentCnt = 1;
                                //}
                                row.ShipmentCnt = 1;
                                row.SalesGoodsCd = salesGoodsCd;
                                //row.SalesUnPrcTaxExcFl = row.SalesMoneyDisplay;
                                //row.SalesUnPrcTaxIncFl = row.SalesMoneyDisplay;
                                //row.SalesMoneyTaxExc = row.SalesMoneyDisplay; // 金額(税抜)
                                //row.SalesMoneyTaxInc = row.SalesMoneyDisplay; // 金額(税込)
                                row.SalesPriceConsTax = row.SalesMoneyDisplay;
                                row.CanTaxDivChange = false;
                                row.EditStatus = ctEDITSTATUS_AllOK;
                            }
                            break;
                        }
                    case SalesGoodsCd.BalanceAdjust:								// 売上商品区分 = 3:残高調整
                    case SalesGoodsCd.AccRecBalanceAdjust:								// 売上商品区分 = 5:売掛用残高調整
                        {
                            if (row.SalesMoneyDisplay == 0)
                            {
                                this.ClearSalesDetailRow(row.SalesRowNo);
                            }
                            else
                            {
                                row.GoodsName = "残高調整";
                                row.GoodsNameKana = "残高調整";
                                row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
                                //if (this._salesSlip.SalesSlipCd == 1) // 0:売上 1:返品
                                //{
                                //    row.ShipmentCnt = -1;
                                //}
                                //else
                                //{
                                //    row.ShipmentCnt = 1;
                                //}
                                row.ShipmentCnt = 1;
                                //row.SalesUnPrcTaxExcFl = row.SalesMoneyDisplay; // 単価(税抜)
                                //row.SalesUnPrcTaxIncFl = row.SalesMoneyDisplay; // 単価(税込)
                                //row.SalesMoneyTaxExc = row.SalesMoneyDisplay; // 金額(税抜)
                                row.SalesMoneyTaxInc = row.SalesMoneyDisplay; // 金額(税込)
                                row.SalesGoodsCd = salesGoodsCd;
                                row.CanTaxDivChange = false;
                                row.EditStatus = ctEDITSTATUS_AllOK;
                            }
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// 売上明細行オブジェクトに在庫より明細情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="stockList">在庫情報オブジェクトリスト</param>
        public void SalesDetailRowSettingFromStockSetting(int salesRowNo, List<Stock> stockList)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (stockList.Count != 0)
            {
                Stock stock = stockList[0];
                if (row != null)
                {
                    // 在庫情報
                    if (stock != null)
                    {
                        // 在庫のキャッシュ
                        this.CacheStockInfo(stock);

                        row.WarehouseCode = stock.WarehouseCode.Trim();
                        row.WarehouseName = stock.WarehouseName.Trim();
                        row.WarehouseShelfNo = stock.WarehouseShelfNo.Trim();
                        row.SupplierStock = stock.ShipmentPosCnt;
                        row.SupplierStockDisplay = stock.ShipmentPosCnt;
                        if (this.SupplierStockCountChangeCheck(row)) row.SupplierStockDisplay -= Math.Abs(row.ShipmentCntDisplay);
                    }
                }
            }
            else
            {
                row.WarehouseCode = string.Empty;
                row.WarehouseName = string.Empty;
                row.WarehouseShelfNo = string.Empty;
                row.SupplierStock = 0;
                row.SupplierStockDisplay = 0;
            }
        }

#if false
        ///// <summary>
        ///// 商品情報リストより在庫マスタを検索し、在庫情報リストを取得します。
        ///// </summary>
        ///// <param name="goodsUnitDataList">商品情報リスト</param>
        ///// <returns>在庫情報リスト</returns>
        //public List<Stock> SearchStock(List<GoodsUnitData> goodsUnitDataList)
        //{
        //    List<Stock> retStockList = new List<Stock>();

        //    // 倉庫コード(拠点情報設定マスタ(優先倉庫))
        //    string[] warehouseCodes = new string[_salesSlipInputInitDataAcs.SectWarehouseCd.Count];
        //    for (int i = 0; i < _salesSlipInputInitDataAcs.SectWarehouseCd.Count; i++)
        //    {
        //        warehouseCodes[i] = _salesSlipInputInitDataAcs.SectWarehouseCd[i];
        //    }

        //    // 1商品ずつ、優先倉庫検索する
        //    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
        //    {
        //        StockSearchPara stockSearchPara = new StockSearchPara();
        //        stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //        stockSearchPara.GoodsNo = goodsUnitData.GoodsNo;
        //        stockSearchPara.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
        //        stockSearchPara.WarehouseCodes = warehouseCodes;

        //        List<Stock> searchRetStockList = SearchStock(stockSearchPara);

        //        // 検索結果がゼロ件の場合は次の商品を検索
        //        if (searchRetStockList.Count == 0) continue;

        //        Stock searchRetStock = new Stock();

        //        // 検索結果があった場合は最優先の在庫情報を結果として返す(拠点優先倉庫順)
        //        for (int cnt = 0; cnt < warehouseCodes.Length; cnt++)
        //        {
        //            bool hit = false;
        //            if (String.IsNullOrEmpty(warehouseCodes[cnt])) continue;

        //            foreach (Stock searchRetStockWk in searchRetStockList)
        //            {
        //                if (searchRetStockWk.WarehouseCode.Trim() == warehouseCodes[cnt].Trim())
        //                {
        //                    searchRetStock = searchRetStockWk;
        //                    hit = true;
        //                    break;
        //                }
        //            }
        //            if (hit) break;
        //        }

        //        retStockList.Add(searchRetStock);
        //    }
        //    return retStockList;
        //}
        
        ///// <summary>
        ///// 商品情報より在庫マスタを検索し、在庫リストを取得します。
        ///// </summary>
        ///// <param name="goodsUnitDataList">商品リスト</param>
        ///// <returns>在庫リスト</returns>
        //public List<Stock> SearchStock(GoodsUnitData goodsUnitData)
        //{
        //    //-------------------------------------------
        //    // 検索コード設定
        //    //-------------------------------------------
        //    string goodsNo = goodsUnitData.GoodsNo;
        //    int goodsMakerCd = goodsUnitData.GoodsMakerCd;

        //    //-------------------------------------------
        //    // パラメータセット
        //    //-------------------------------------------
        //    StockSearchPara stockSearchPara = new StockSearchPara();
        //    // 拠点コード
        //    stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //    // 商品番号
        //    stockSearchPara.GoodsNo = goodsNo;
        //    // メーカーコード
        //    stockSearchPara.GoodsMakerCd = goodsMakerCd;
        //    // 倉庫コード(拠点情報設定マスタ(優先倉庫))
        //    string[] warehouseCodes = new string[_salesSlipInputInitDataAcs.SectWarehouseCd.Count];
        //    for (int i = 0; i < _salesSlipInputInitDataAcs.SectWarehouseCd.Count; i++)
        //    {
        //        warehouseCodes[i] = _salesSlipInputInitDataAcs.SectWarehouseCd[i];
        //    }
        //    stockSearchPara.WarehouseCodes = warehouseCodes;

        //    //-------------------------------------------
        //    // 在庫検索
        //    //-------------------------------------------
        //    List<Stock> stockList = new List<Stock>();
        //    string msg;
        //    // ここ
        //    //int status = this._searchStockAcs.Search(stockSearchPara, out stockList, out msg);
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        stockList = new List<Stock>();
        //    }

        //    //-------------------------------------------
        //    // 検索結果から優先倉庫に従い情報取得
        //    //-------------------------------------------
        //    List<Stock> retStockList = new List<Stock>();
        //    for (int i = 0; i < _salesSlipInputInitDataAcs.SectWarehouseCd.Count; i++)
        //    {
        //        int j = 0;
        //        foreach (Stock stock in stockList)
        //        {
        //            if (_salesSlipInputInitDataAcs.SectWarehouseCd[i].Trim() == stock.WarehouseCode.Trim())
        //            {
        //                retStockList.Add(stockList[j]);
        //                return retStockList;
        //            }
        //            j++;
        //        }
        //    }
        //    return retStockList;
        //}

        ///// <summary>
        ///// 明細情報より在庫マスタを検索し、在庫リストを取得します。
        ///// </summary>
        ///// <param name="salesDetailList">明細情報リスト</param>
        ///// <returns>在庫リスト</returns>
        //public List<Stock> SearchStock(List<SalesDetail> salesDetailList)
        //{
        //    List<Stock> retStockList = new List<Stock>();

        //    foreach (SalesDetail salesDetail in salesDetailList)
        //    {
        //        List<Stock> stockList = SearchStock(salesDetail);
        //        if (stockList.Count != 0)
        //        {
        //            retStockList.Add(stockList[0]);
        //        }
        //    }

        //    return retStockList;
        //}

        ///// <summary>
        ///// 明細情報より在庫マスタを検索し、在庫リストを取得します。
        ///// </summary>
        ///// <param name="salesDetailList">明細情報リスト</param>
        ///// <returns>在庫リスト</returns>
        //private List<Stock> SearchStock(SalesDetail salesDetail)
        //{
        //    //-------------------------------------------
        //    // 検索コード設定
        //    //-------------------------------------------
        //    string goodsNo = salesDetail.GoodsNo;
        //    int goodsMakerCd = salesDetail.GoodsMakerCd;

        //    //-------------------------------------------
        //    // パラメータセット
        //    //-------------------------------------------
        //    StockSearchPara stockSearchPara = new StockSearchPara();
        //    // 拠点コード
        //    stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //    // 商品番号
        //    stockSearchPara.GoodsNo = goodsNo;
        //    // メーカーコード
        //    stockSearchPara.GoodsMakerCd = goodsMakerCd;

        //    // 倉庫コード(明細データ倉庫 拠点情報設定マスタ(優先倉庫))
        //    string[] warehouseCodes = new string[_salesSlipInputInitDataAcs.SectWarehouseCd.Count + 1];
        //    int revise = 0;
        //    if (!string.IsNullOrEmpty(salesDetail.WarehouseCode.Trim()))
        //    {
        //        warehouseCodes[0] = salesDetail.WarehouseCode.Trim();
        //        revise++;
        //    }
        //    for (int i = 0; i < _salesSlipInputInitDataAcs.SectWarehouseCd.Count; i++)
        //    {
        //        warehouseCodes[i+revise] = _salesSlipInputInitDataAcs.SectWarehouseCd[i];
        //    }
        //    stockSearchPara.WarehouseCodes = warehouseCodes;

        //    //-------------------------------------------
        //    // 在庫検索
        //    //-------------------------------------------
        //    List<Stock> stockList;
        //    stockList = this.SearchStock(stockSearchPara);

        //    //-------------------------------------------
        //    // 検索結果から明細データ倉庫、優先倉庫に従い情報取得
        //    //-------------------------------------------
        //    List<Stock> retStockList = new List<Stock>();
        //    for (int i = 0; i < warehouseCodes.Length; i++)
        //    {
        //        int j = 0;
        //        foreach (Stock stock in stockList)
        //        {
        //            if (warehouseCodes[i].Trim() == stock.WarehouseCode.Trim())
        //            {
        //                retStockList.Add(stockList[j]);
        //                return retStockList;
        //            }
        //            j++;
        //        }
        //    }
        //    return retStockList;

        //}

        ///// <summary>
        ///// 明細情報より在庫マスタを検索し、在庫リストを取得します。
        ///// </summary>
        ///// <returns>在庫リスト</returns>
        //public List<Stock> SearchStock(int salesRowNo)
        //{
        //    SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

        //    //-------------------------------------------
        //    // 検索コード設定
        //    //-------------------------------------------
        //    string goodsNo = row.GoodsNo;
        //    int goodsMakerCd = row.GoodsMakerCd;
        //    string warehouseCode = row.WarehouseCode;

        //    //-------------------------------------------
        //    // パラメータセット
        //    //-------------------------------------------
        //    StockSearchPara stockSearchPara = new StockSearchPara();
        //    // 拠点コード
        //    stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //    // 商品番号
        //    stockSearchPara.GoodsNo = goodsNo;
        //    // メーカーコード
        //    stockSearchPara.GoodsMakerCd = goodsMakerCd;
        //    // 倉庫コード
        //    stockSearchPara.WarehouseCode = warehouseCode;

        //    //-------------------------------------------
        //    // 在庫検索
        //    //-------------------------------------------
        //    return this.SearchStock(stockSearchPara);
        //}

        ///// <summary>
        ///// 在庫検索パラメータより在庫検索を行い、在庫リストを取得します。
        ///// </summary>
        ///// <param name="stockSearchPara">在庫検索パラメータ</param>
        ///// <returns>在庫リスト</returns>
        //private List<Stock> SearchStock(StockSearchPara stockSearchPara)
        //{
        //    List<Stock> retStockList = new List<Stock>();

        //    string msg;
        //    // ここ
        //    //int status = this._searchStockAcs.Search(stockSearchPara, out retStockList, out msg);
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        retStockList = new List<Stock>();
        //    }

        //    return retStockList;
        //}
#endif

        /// <summary>
        /// 在庫リストより在庫情報取得
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public Stock GetStock(GoodsUnitData goodsUnitData)
        {
            List<string> warehouseList = new List<string>();
            //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
            warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD

            if (goodsUnitData.StockList != null)
            {
                foreach (Stock stock in goodsUnitData.StockList)
                {
                    for (int i = 0; i < warehouseList.Count; i++)
                    {
                        Stock retStock = new Stock();
                        retStock = this._salesSlipInputInitDataAcs.GetStockFromStockList(warehouseList[i], goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                        if (retStock != null) return retStock;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 在庫リストより在庫情報取得
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public Stock GetStock(GoodsUnitData goodsUnitData, string warehouseCode)
        {
            if ((goodsUnitData != null) &&
                (goodsUnitData.StockList != null))
            {
                Stock retStock = new Stock();

                retStock = this._salesSlipInputInitDataAcs.GetStockFromStockList(warehouseCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                if (retStock != null) return retStock;
            }
            return null;
        }

        /// <summary>
        /// 倉庫切替処理
        /// </summary>
        /// <param name="rowNo"></param>
        public void ChangeWarehouse(int rowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, rowNo);
            //>>>2010/10/01
            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
            //<<<2010/10/01

            if (row != null)
            {
                // 次倉庫取得
                Stock stock = this.GetStockNext(row.WarehouseCode, goodsUnitData);

                // 在庫情報設定処理
                this.SettingSalesDetailStockInfo(row, stock);
            }
        }
        
        // --- ADD 2010/05/04 ---------->>>>>
        /// <summary>
        /// 倉庫切替処理
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="msg"></param>
        /// <remarks>
        /// <br>Update Note: 2015/04/16 30757 佐々木 貴英</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>             社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応</br>
        /// <br>Update Note: K2021/07/22 陳艶丹</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>             PMKOBETSU-4148 原価0円障害の対応</br> 
        /// </remarks>
        public void ChangeWarehouse(int rowNo, out string msg)
        {
            msg = "";

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, rowNo);
            //>>>2010/10/01
            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
            //<<<2010/10/01

            if (row != null)
            {
                // 次倉庫取得
                Stock stock = this.GetStockNext(row.WarehouseCode, goodsUnitData);

                if (stock != null && !string.IsNullOrEmpty(stock.SectionCode) && !string.IsNullOrEmpty(LoginInfoAcquisition.Employee.BelongSectionCode))
                {
                    if (!stock.SectionCode.Trim().Equals(LoginInfoAcquisition.Employee.BelongSectionCode.Trim()))
                    {
                        // 入力倉庫チェック区分 0:無視 1:再入力 2:警告
                        switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().InpWarehChkDiv)
                        {
                            case 0:
                                break;
                            case 1:
                                {
                                    msg = "不正な値が存在するため、登録できません。"
                                        + "\r\n"
                                        + "\r\n"
                                        + rowNo
                                        + "行目の在庫管理拠点とログイン拠点が不一致です。";

                                    return;
                                }
                            case 2:
                                {
                                    msg = "在庫管理拠点とログイン拠点が不一致です。";

                                    break;
                                }
                        }
                    }
                }

                // 在庫情報設定処理
                this.SettingSalesDetailStockInfo(row, stock);

                // ADD 2013/04/10 T.Miyamoto ------------------------------>>>>>
                if (this._salesSlipInputInitDataAcs.Opt_SalesCostCtrl == (int)SalesSlipInputInitDataAcs.Option.ON)
                {
                    //---ADD 30757 佐々木 貴英 2015/04/16 社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応 ---------------->>>>>
                    // 売上明細データセッティング処理（定価設定）用に現在の表示定価金額を一時退避
                    double tempReturnListPrice = row.ListPriceDisplay;
                    //---ADD 30757 佐々木 貴英 2015/04/16 社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応 ----------------<<<<<

                    // 原価再取得
                    this.SalesDetailRowGoodsPriceReSetting(row);

                    //---ADD 30757 佐々木 貴英 2015/04/16 社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応 ---------------->>>>>
                    // 明細項目変更時の標準価格及び売単価変更処理
                    this.salesDetailRowSalesUnitPriceReSettingProc(rowNo, tempReturnListPrice);
                    //---ADD 30757 佐々木 貴英 2015/04/16 社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応 ----------------<<<<<

                    //-----ADD K2021/07/22 陳艶丹 PMKOBETSU-4148 ----->>>>>
                    // 原価金額計算処理
                    this.CalculationCost(rowNo - 1);
                    // 明細粗利率設定処理
                    this.SettingSalesDetailRowGrossProfitRate(row.SalesRowNo);
                    //-----ADD K2021/07/22 陳艶丹 PMKOBETSU-4148 -----<<<<<
                }
                // ADD 2013/04/10 T.Miyamoto ------------------------------<<<<<
            }
        }
        // --- ADD 2010/05/04 ----------<<<<<
        
        //---ADD 30757 佐々木 貴英 2015/04/16 社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応 ---------------->>>>>
        /// <summary>
        /// 明細項目変更時の標準価格及び売単価変更処理
        /// </summary>
        /// <param name="salesRowNo">明細行番号</param>
        /// <param name="listPriceDisplay">設定する標準価格</param>
        /// <param name="targetTable">変更対象売上明細データ</param>
        /// <returns>0:成功、0以外:失敗</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// パラメータsalesRowNoで設定した番号の明細行番号の明細レコードが存在しない場合に発生します。
        /// </exception>
        /// <remarks>
        /// <br>Note       : 社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/04/16</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// <br>           : </br>
        /// <br></br>
        /// </remarks>
        public int SalesDetailRowSalesUnitPriceReSetting(int salesRowNo, double listPriceDisplay)
        {
            return this.salesDetailRowSalesUnitPriceReSettingProc(salesRowNo, listPriceDisplay);
        }
        
        /// <summary>
        /// 明細項目変更時の標準価格及び売単価変更処理（実体）
        /// </summary>
        /// <param name="salesRowNo">明細行番号</param>
        /// <param name="listPriceDisplay">設定する標準価格</param>
        /// <returns>0:成功、0以外:失敗</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// パラメータsalesRowNoで設定した番号の明細行番号の明細レコードが存在しない場合に発生します。
        /// </exception>
        /// <remarks>
        /// <br>Note       : 社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/04/16</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br></br>
        /// <br>Update Note: 社内障害№707 販売区分を変更した場合に売価が再計算されない障害の対応</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/09/03</br>
        /// <br>管理番号   : 11170139-00</br>
        /// <br></br>
        /// </remarks>
        private int salesDetailRowSalesUnitPriceReSettingProc(int salesRowNo, double listPriceDisplay)
        {
            int result = -1;
            int rowIndex = salesRowNo - 1;

            SalesInputDataSet.SalesDetailRow nowRow = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (null == nowRow)
            {
                throw new ArgumentOutOfRangeException("salesRowNo", "salesRowNoで指定した明細行番号のレコードは売上明細データに存在しません。");
            }

            //標準価格設定
            nowRow.ListPriceDisplay = listPriceDisplay;
            // 売上明細データセッティング処理（定価設定）
            this.SalesDetailRowListPriceSetting(
                salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, listPriceDisplay, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);

            //売単価設定
            if (nowRow.SalesRate != 0)
            {
                // 売上明細データセッティング処理（単価設定）
                this.SalesDetailRowSalesUnitPriceSettingbyRate(salesRowNo, nowRow.SalesRate, false);
            }
            else
            {
                if (string.IsNullOrEmpty(nowRow.RateDivSalUnPrc))
                {
                    if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1) // 売価＝定価
                    {
                        this.SalesDetailRowSalesUnitPriceSetting(
                            salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPrice, listPriceDisplay, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable, 0);
                    }

                    // --- ADD 2015/09/03 Y.Wakita 社内障害№707 ---------->>>>>
                    //キャンペーン値引率
                    if (nowRow.CampaignDiscountRate != 0)
                    {
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = this.GetGoodsUnitDataDic(nowRow.GoodsMakerCd, nowRow.GoodsNo, nowRow);

                        if (goodsUnitData.GoodsPriceList != null && goodsUnitData.GoodsPriceList.Count > 0)
                        {
                            List<GoodsPrice> tempGoodsPriceList = new List<GoodsPrice>();
                            foreach (GoodsPrice goodsPrice in goodsUnitData.GoodsPriceList)
                            {
                                goodsPrice.ListPrice = nowRow.ListPriceDisplay;
                                tempGoodsPriceList.Add(goodsPrice);
                            }
                            goodsUnitData.GoodsPriceList = tempGoodsPriceList;
                        }
                        this.SettingSalesDetailGoodsCampaignPriceOnChange(nowRow.SalesRowNo, goodsUnitData);
                    }
                    // --- ADD 2015/09/03 Y.Wakita 社内障害№707 ----------<<<<<
                }
            }
            // 売上金額計算処理
            this.CalculationSalesMoney(rowIndex, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
            
            result = 0;

            return result;
        }
        //---ADD 30757 佐々木 貴英 2015/04/16 社内障害№684 販売区分、倉庫コードを変更すると表示区分に関わらず優良品の標準価格が表示される障害の対応 ----------------<<<<<
        
        /// <summary>
        /// 在庫リストより次在庫情報取得
        /// </summary>
        /// <param name="warehouseCd">倉庫コード</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <returns></returns>
        private Stock GetStockNext(string warehouseCd, GoodsUnitData goodsUnitData)
        {
            Stock retStock = null;

            // 優先倉庫リスト作成(得意先優先倉庫＋拠点優先倉庫)
            List<string> warehouseList = new List<string>();
            //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
            warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD

            if ((goodsUnitData != null) && (goodsUnitData.StockList != null))
            {
                // 優先倉庫のみ対象
                foreach (Stock stock in goodsUnitData.StockList)
                {
                    if (retStock != null) break;

                    Stock tempStock = null;
                    for (int i = 0; i < warehouseList.Count; i++)
                    {
                        if (this.GetSectWarehousePriorityRank(warehouseList, warehouseCd.Trim()) < this.GetSectWarehousePriorityRank(warehouseList, warehouseList[i]))
                        {
                            tempStock = this._salesSlipInputInitDataAcs.GetStockFromStockList(warehouseList[i], goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                        }
                        if (tempStock != null)
                        {
                            retStock = tempStock;
                            break;
                        }
                    }
                }

                // 在庫マスタのみ対象
                if (retStock == null)
                {
                    foreach (Stock stock in goodsUnitData.StockList)
                    {
                        if (this.GetSectWarehousePriorityRank(warehouseList, stock.WarehouseCode.Trim()) <= warehouseList.Count) continue;
                        if (!this.CheckSectWarehouse(warehouseList, warehouseCd.Trim()))
                        {
                            if (TStrConv.StrToIntDef(stock.WarehouseCode, 0) <= TStrConv.StrToIntDef(warehouseCd, 0)) continue;
                        }
                        retStock = stock;
                        break;
                    }
                }
            }

            return retStock;
        }

        /// <summary>
        /// 優先倉庫順位位置取得処理
        /// </summary>
        /// <param name="warehouseList"></param>
        /// <param name="warehouseCd"></param>
        /// <returns></returns>
        private int GetSectWarehousePriorityRank(List<string>warehouseList, string warehouseCd)
        {
            if (string.IsNullOrEmpty(warehouseCd)) return 0;
            for (int i = 0; i < warehouseList.Count; i++)
            {
                if (warehouseCd.Trim() == warehouseList[i].Trim()) return i + 1;
            }
            return warehouseList.Count + 1;
        }

        /// <summary>
        /// 優先倉庫該当チェック
        /// </summary>
        /// <param name="warehouseList"></param>
        /// <param name="warehouseCd"></param>
        /// <returns></returns>
        private bool CheckSectWarehouse(List<string> warehouseList, string warehouseCd)
        {
            bool ret = false;
            if (warehouseList.Contains(warehouseCd)) ret = true;
            return ret;
        }

        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 本社管理倉庫該当チェック(営業所での入力時は優先設定されていない倉庫の入力は不可)
        /// </summary>
        /// <param name="warehouseList"></param>
        /// <param name="warehouseCd"></param>
        /// <returns></returns>
        public bool CheckPriorWarehouse(string warehouseCd)
        {
            bool ret = false;

            List<string> warehouseList = new List<string>();
            warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0);
            // --- UPD 2013/10/11 T.Miyamoto ------------------------------>>>>>
            //if (warehouseList.Contains(warehouseCd)) ret = true;
            if (warehouseList.Contains(warehouseCd.Trim())) ret = true;
            // --- UPD 2013/10/11 T.Miyamoto ------------------------------<<<<<
            return ret;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// 倉庫リスト位置指定追加処理
        /// </summary>
        /// <param name="sectWarehouseCdList"></param>
        /// <param name="targetCode"></param>
        /// <param name="index"></param>
        /// <remarks>indexがリスト件数を超える場合、最終に追加</remarks>
        private List<string> AddWarehouseList(List<string> sectWarehouseCdList, string targetCode, int index)
        {
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
            if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
            {
                List<string> warehouseListC = new List<string>();

                // 本社管理倉庫マスタから倉庫リスト取得
                List<string> WarehouseCdList = this._salesSlipInputInitDataAcs.GetPriorWarehouseInfo(this._enterpriseCode, this._sectionCode);

                // 得意先分析コード取得
                CustomerInfo customerInfoWrk;
                int custStatus = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this._salesSlip.CustomerCode, true, false, out customerInfoWrk);
                if (custStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL) customerInfoWrk = new CustomerInfo();
                _CustAnalysCode1 = customerInfoWrk.CustAnalysCode1;

                // 特定得意先の場合
                if (customerInfoWrk.CustAnalysCode1 != 0)
                {
                    warehouseListC.AddRange(WarehouseCdList);
                    warehouseListC.Add(targetCode.Trim());
                }
                else
                {
                    warehouseListC.Add(targetCode.Trim());

                    // 指定拠点が本社管理倉庫マスタに登録済の場合、拠点＝本社
                    if (!this._salesSlipInputInitDataAcs.CheckMainSection(this._enterpriseCode, this.SectionCode))
                    {
                        // 営業所の場合
                        warehouseListC.AddRange(sectWarehouseCdList);
                    }
                    warehouseListC.AddRange(WarehouseCdList);
                }
                return warehouseListC;
            }
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

            // 設定コード不正な場合
            if ((targetCode == null) || (targetCode.Trim() == string.Empty)) return sectWarehouseCdList;

            List<string> warehouseList = new List<string>();

            // 指定Indexがリスト件数を超えた場合
            if (sectWarehouseCdList.Count - 1 < index) 
            {
                warehouseList.AddRange(sectWarehouseCdList);
                warehouseList.Add(targetCode.Trim());
                return warehouseList;
            }

            int sectIndex = 0;

            for (int i = 0; i < sectWarehouseCdList.Count + 1; i++)
            {
                if (i == index)
                {
                    warehouseList.Add(targetCode.Trim());
                }
                else
                {
                    warehouseList.Add(sectWarehouseCdList[sectIndex]);
                    sectIndex++;
                }
            }
            return warehouseList;
        }

        // 2012/08/30 ADD T.Yoshioka 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 倉庫リスト取得
        /// </summary>
        /// <param name="sectWarehouseCdList">拠点（優先）</param>
        /// <param name="targetCode">委託</param>
        /// <remarks></remarks>
        private List<string> AddWarehouseList2(List<string> sectWarehouseCdList, string targetCode)
        {
            if ((targetCode == null) || (targetCode.Trim() == string.Empty))
            {
                targetCode = string.Empty;
            }

            List<string> warehouseList = new List<string>();

            // 委託倉庫の追加
            warehouseList.Add(targetCode.Trim());

            for (int i = 0; i < sectWarehouseCdList.Count; i++)
            {
                warehouseList.Add(sectWarehouseCdList[i]);
            }
            return warehouseList;
        }

        /// <summary>
        /// 優先倉庫リスト(PCC自社設定マスタの優先倉庫)を生成します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <returns>優先倉庫リスト</returns>
        //
        /// <summary>
        /// 優先倉庫リスト(PCC自社設定マスタの優先倉庫)を生成します。
        /// </summary>
        /// <param name="InqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="InqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="InqOtherEpCd">問合せ先企業コード</param>
        /// <param name="InqOtherSecCd">問合せ先拠点コード</param>
        /// <returns></returns>
        private List<string> CreatePriorWarehouseListForPccuoe(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd)
        {
            PccCmpnyStWork pccCmpnySt = searchPccCmpnyStList(inqOriginalEpCd.Trim(), inqOriginalSecCd, inqOtherEpCd, inqOtherSecCd);//@@@@20230303

            List<string> sectWarehouseCdList = new List<string>();
            if (pccCmpnySt != null)
            {
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccWarehouseCd) ? "" : pccCmpnySt.PccWarehouseCd.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd1) ? "" : pccCmpnySt.PccPriWarehouseCd1.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd2) ? "" : pccCmpnySt.PccPriWarehouseCd2.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd3) ? "" : pccCmpnySt.PccPriWarehouseCd3.Trim());
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                int opt_BLPPriWarehouse = -1;
                this._salesSlipInputInitDataAcs.GetBLPPriWarehouseOptInfo(out opt_BLPPriWarehouse);
                if (opt_BLPPriWarehouse == (int)SalesSlipInputInitDataAcs.Option.ON)
                    sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd4) ? "" : pccCmpnySt.PccPriWarehouseCd4.Trim());
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

            }
            return sectWarehouseCdList;
        }
        /// <summary>
        /// 自社設定マストデータを取得する
        /// </summary>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <returns></returns>
        public static PccCmpnyStWork searchPccCmpnyStList(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd)
        {
            IPccCmpnyStDB writer = MediationPccCmpnyStDB.GetPccCmpnyStDB();

            object pccCmpnyStObj = null;
            // 検索パラメータ
            PccCmpnyStWork parsePccCmpnyStWork = new PccCmpnyStWork();
            // 問合せ元企業コード
            parsePccCmpnyStWork.InqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            // 問合せ元拠点コード
            parsePccCmpnyStWork.InqOriginalSecCd = inqOriginalSecCd;
            // 問合せ先企業コード
            parsePccCmpnyStWork.InqOtherEpCd = inqOtherEpCd;
            // 問合せ先拠点コード
            parsePccCmpnyStWork.InqOtherSecCd = inqOtherSecCd;
            // 検索区分(現在未使用)
            int readMode = 0;
            // 論理削除有無
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;

            int status = writer.Search(out pccCmpnyStObj, parsePccCmpnyStWork, readMode, logicalMode);

            if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return (PccCmpnyStWork)((ArrayList)pccCmpnyStObj)[0];
            }
            else
            {
                #region <Log>

                string msg = string.Format(
                    "優先倉庫リスト(PCC自社設定マスタの優先倉庫)を生成中...PCC自社設定情報が検索できませんでした。(問合せ元企業コード=「{0}」, 問合せ元拠点コード=「{1}」, 問合せ先企業コード=「{2}」, 問合せ先拠点コード=「{3}」)",
                    inqOriginalEpCd.Trim(),//@@@@20230303
                    inqOriginalSecCd,
                    inqOtherEpCd,
                    inqOtherSecCd
                );
                SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "searchPccCmpnyStList", msg);

                #endregion 
            }
            return null;
        }
        // 2012/08/30 ADD T.Yoshioka 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        //>>>2010/10/01
        ///// <summary>
        ///// 商品連結データオブジェクト取得(商品Dictionaryより取得)
        ///// </summary>
        ///// <param name="goodsMakerCode"></param>
        ///// <param name="goodsNo"></param>
        ///// <returns></returns>
        //public GoodsUnitData GetGoodsUnitDataDic(int goodsMakerCode, string goodsNo)
        //{
        //    GoodsUnitData goodsUnitData = null;
        //    GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsNo, goodsMakerCode);
        //    if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) goodsUnitData = this._goodsUnitDataInfo[goodsInfoKey];
        //    GoodsUnitData retGoodsUnitData = (goodsUnitData != null) ? goodsUnitData.Clone() : null;
        //    return retGoodsUnitData;
        //}


        /// <summary>
        /// 商品連結データオブジェクト取得(商品Dictionaryより取得)
        /// </summary>
        /// <param name="goodsMakerCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        public GoodsUnitData GetGoodsUnitDataDic(int goodsMakerCode, string goodsNo)
        {
            return this.GetGoodsUnitDataDic(goodsMakerCode, goodsNo, null);
        }

        /// <summary>
        /// 商品連結データオブジェクト取得(商品Dictionaryより取得)
        /// </summary>
        /// <param name="goodsMakerCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        public GoodsUnitData GetGoodsUnitDataDic(int goodsMakerCode, string goodsNo, SalesInputDataSet.SalesDetailRow row)
        {
            GoodsUnitData goodsUnitData = null;
            GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsNo, goodsMakerCode);
            if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) goodsUnitData = this._goodsUnitDataInfo[goodsInfoKey];
            GoodsUnitData retGoodsUnitData = (goodsUnitData != null) ? goodsUnitData.Clone() : null;

            if ((retGoodsUnitData != null) && (row != null))
            {
                if (retGoodsUnitData.GoodsPriceList == null)
                {
                    List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();
                    GoodsPrice goodsPrice = new GoodsPrice();
                    goodsPrice.PriceStartDate = this._salesSlip.SalesDate;
                    goodsPriceList.Add(goodsPrice);
                    retGoodsUnitData.GoodsPriceList = goodsPriceList;
                }

                if (row.GoodsMakerCd != 0)
                {
                    retGoodsUnitData.GoodsMakerCd = row.GoodsMakerCd;
                }

                if (row.BLGoodsCode != 0)
                {
                    retGoodsUnitData.BLGoodsCode = row.BLGoodsCode;
                    retGoodsUnitData.BLGoodsFullName = row.BLGoodsFullName;
                }

                if (row.SupplierCd != 0)
                {
                    retGoodsUnitData.SupplierCd = row.SupplierCd;
                }
                // ----- ADD 王君　2013/07/10 Redmine#37769 ----->>>>>
                if (row.BLGroupCode != 0)
                {
                    retGoodsUnitData.BLGroupCode = row.BLGroupCode;  //BLグループコード
                    retGoodsUnitData.BLGroupName = row.BLGroupName;  //BLグループコード名
                }
                if (row.GoodsMGroup != 0)
                {
                    retGoodsUnitData.GoodsMGroup = row.GoodsMGroup;　//中分類コード
                    retGoodsUnitData.GoodsMGroupName = row.GoodsMGroupName;  //中分類名
                }
                if (row.GoodsLGroup != 0)
                {
                    retGoodsUnitData.GoodsLGroup = row.GoodsLGroup; //大分類コード
                    retGoodsUnitData.GoodsLGroupName = row.GoodsLGroupName;　//大分類名
                }
                // ----- ADD 王君　2013/07/10 Redmine#37769 -----<<<<<
            }

            return retGoodsUnitData;
        }
        //<<<2010/10/01

        /// <summary>
        /// 商品連結データオブジェクトの在庫オブジェクト取得(商品Dictionaryより取得)
        /// </summary>
        /// <param name="goodsMakerCode"></param>
        /// <param name="goodsNo"></param>
        /// <param name="warehouseCode"></param>
        /// <returns></returns>
        public Stock GetGoodsUnitDataDicStock(int goodsMakerCode, string goodsNo, string warehouseCode)
        {
            GoodsUnitData goodsUnitData = null;
            GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsNo, goodsMakerCode);
            if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) goodsUnitData = this._goodsUnitDataInfo[goodsInfoKey];

            Stock stock = null;
            if (goodsUnitData != null)
            {
                stock = this._salesSlipInputInitDataAcs.GetStockFromStockList(warehouseCode, goodsMakerCode, goodsNo, goodsUnitData.StockList);
            }
            return stock;

        }

        /// <summary>
        /// 商品連結データオブジェクトキャッシュ(商品Dictionary)
        /// </summary>
        /// <param name="goodsUnitDataListList"></param>
        private void CacheGoodsUnitDataDic(List<List<GoodsUnitData>> goodsUnitDataListList)
        {
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            foreach (List<GoodsUnitData> goodsUnitDataList in goodsUnitDataListList)
            {
                if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    goodsUnitData = goodsUnitDataList[0].Clone();
                    this.SettingGoodsUnitDataDic(goodsUnitData);
                }
            }
        }

        /// <summary>
        /// 商品連結データオブジェクト設定処理(商品Dictionary)
        /// </summary>
        /// <param name="goodsUnitData"></param>
        private void SettingGoodsUnitDataDic(GoodsUnitData goodsUnitData)
        {
            GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
            if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) this._goodsUnitDataInfo.Remove(goodsInfoKey);
            this._goodsUnitDataInfo.Add(goodsInfoKey, goodsUnitData);
        }

        /// <summary>
        /// 商品連結データオブジェクト在庫情報設定処理(商品Dictionary)
        /// </summary>
        /// <param name="stock"></param>
        private void SettingGoodsUnitDataDicStockList(Stock stock)
        {
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(stock.GoodsMakerCd, stock.GoodsNo);
            this.SettingGoodsUnitDataDicStockList(ref goodsUnitData, stock);
            this.SettingGoodsUnitDataDic(goodsUnitData);
        }

        /// <summary>
        /// 商品連結データオブジェクト在庫情報設定処理(商品Dictionary)
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="stock"></param>
        private void SettingGoodsUnitDataDicStockList(ref GoodsUnitData goodsUnitData, Stock stock)
        {
            GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
            if ((goodsUnitData != null) && (stock != null))
            {
                int index = 0;
                foreach (Stock checkStock in tempGoodsUnitData.StockList)
                {
                    if (checkStock.WarehouseCode == stock.WarehouseCode)
                    {
                        goodsUnitData.StockList[index] = stock;
                        return;
                    }
                    index++;
                }
                goodsUnitData.StockList.Add(stock);
            }
        }

        /// <summary>
        /// 品番検索
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
        /// <br></br>
        /// <br>Update Note: 2015/04/06 30757 佐々木 貴英</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>             仕掛№2405 得意先変更時表示区分再取得対応</br>
        /// <br></br>
        /// </remarks>
        public int SearchPartsFromGoodsNo(string enterpriseCode, string sectionCode, int goodsMakerCode, string goodsNo, int salesRowNo, out List<GoodsUnitData> goodsUnitDataList)
        {
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "●検索前初期化　開始");
            #region ●検索前初期化
            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            string msg;
            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "○検索前初期化終了");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "●抽出条件設定　開始");
            #region ●抽出条件設定
            //-----------------------------------------------------------------------------
            // 抽出条件設定
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.GoodsMakerCd = goodsMakerCode;
            cndtn.GoodsNo = goodsNo;
            cndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
            cndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
            cndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
            cndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
            cndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
            cndtn.PartsNoSearchDivCd = this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue;
            cndtn.PartsJoinCntDivCd = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;
            cndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            cndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
            cndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
            cndtn.PriceApplyDate = this._salesSlip.SalesDate;
            cndtn.IsSettingSupplier = 1;

            // --- ADD 2009/10/19 ---------->>>>>
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if ((row != null) && (row.CarRelationGuid != Guid.Empty))
            {
                cndtn.SearchCarInfo = this.GetCarInfoNew(row.CarRelationGuid);
            }
            else
            {
                cndtn.SearchCarInfo = this.GetCarInfoNew(this._beforeCarRelationGuid);
            }
            // --- ADD 2009/10/19 ----------<<<<<
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "○抽出条件設定　終了");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "☆●部品検索　開始");
            #region ●部品検索
            //-----------------------------------------------------------------------------
            // 部品検索
            //-----------------------------------------------------------------------------
            int status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNo(cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList);
            }
            // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<

            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "☆○部品検索　終了", "検索数:" + goodsUnitDataList.Count.ToString());

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // 選択無し
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理
#if true
                    if (partsInfoDataSet.CalculateGoodsPrice == null)
                    {
                        partsInfoDataSet.CalculateGoodsPrice += new PartsInfoDataSet.CalculateGoodsPriceCallback(this.CalculateUnitPrice);
                    }
                    if (partsInfoDataSet.CalculatePrice == null)
                    {
                        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(this.CalcPrice);
                    }

                    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;
#else
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "●商品連結データ不足情報設定　開始");
                    #region ●商品連結データ不足情報設定
                    //-----------------------------------------------------------------------------
                    // 商品連結データ不足情報設定
                    //-----------------------------------------------------------------------------
                    this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "○商品連結データ不足情報設定　終了", "処理件数:" + goodsUnitDataList.Count.ToString());

                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "●単価情報取得　開始");
                    #region ●単価情報取得
                    //-----------------------------------------------------------------------------
                    // 単価情報取得
                    //-----------------------------------------------------------------------------
                    unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "○単価情報取得　終了", "対象商品数:" + goodsUnitDataList.Count.ToString(), "該当単価情報数:" + unitPriceCalcRetList.Count);

                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "SetUnitPriceInfo", "●単価情報を部品検索データセットへ反映　開始");
                    #region ●単価情報を部品検索データセットへ反映
                    //-----------------------------------------------------------------------------
                    // 単価情報を部品検索データセットへ反映
                    //-----------------------------------------------------------------------------
                    if ((unitPriceCalcRetList != null) && (unitPriceCalcRetList.Count != 0)) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "SetUnitPriceInfo", "○単価情報を部品検索データセットへ反映　終了", "対象商品数:" + goodsUnitDataList.Count.ToString(), "該当単価情報数:" + unitPriceCalcRetList.Count);
#endif
                    //>>>2010/02/26
                    // キャンペーン価格適用処理追加
                    partsInfoDataSet.CustomerCode = this._salesSlip.CustomerCode;
                    if (partsInfoDataSet.ReflectCampaign == null)
                    {
                        partsInfoDataSet.ReflectCampaign += new PartsInfoDataSet.ReflectCampaignCallback(this.ReflectCampaign);
                    }
                    //<<<2010/02/26

                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "", "●各種設定　開始");
                    #region ●各種設定
                    //-----------------------------------------------------------------------------
                    // 優先倉庫設定
                    //-----------------------------------------------------------------------------
                    // 優先倉庫リスト作成(得意先優先倉庫＋拠点優先倉庫)
                    List<string> warehouseList = new List<string>();
                    //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                    warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                    partsInfoDataSet.ListPriorWarehouse = warehouseList;
                    
                    //-----------------------------------------------------------------------------
                    // 品名表示区分
                    //-----------------------------------------------------------------------------
                    // DEL 2010/05/17 品名表示対応 ---------->>>>>
                    //partsInfoDataSet.PartsNameDspDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd;
                    // DEL 2010/05/17 品名表示対応 ----------<<<<<
                    // ADD 2010/05/17 品名表示対応 ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._salesSlipInputInitDataAcs.GetSalesTtlSt());
                    // ADD 2010/05/17 品名表示対応 ----------<<<<<

                    // --- ADD 2009/10/19 ---------->>>>>
                    //表示区分ﾌﾟﾛｾｽ
                    partsInfoDataSet.PriceSelectDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PriceSelectDispDiv;
                    //結合元検索ﾃﾞﾘｹﾞｰﾄ
                    if (partsInfoDataSet.SearchPartsForSrcParts == null)
                    {
                        partsInfoDataSet.SearchPartsForSrcParts += new PartsInfoDataSet.SearchPartsForSrcPartsCallBack(this.SearchPartsForSrcPartsPrc);
                    }
                    //得意先ｺｰﾄﾞ
                    partsInfoDataSet.CustomerCode = this._salesSlip.CustomerCode;
                    //得意先掛率ｸﾞﾙｰﾌﾟｺｰﾄﾞﾘｽﾄ
                    partsInfoDataSet.CustRateGrpCodeList = this._salesSlipInputInitDataAcs.GetGetCustRateGrpAll();
                    //得意先掛率ｸﾞﾙｰﾌﾟ取得ﾃﾞﾘｹﾞｰﾄ
                    if (partsInfoDataSet.GetCustRateGrp == null)
                    {
                        partsInfoDataSet.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(this.GetCustRateGrpCode);
                    }
                    //表示区分ﾘｽﾄ
                    partsInfoDataSet.PriceSelectDivList = this._salesSlipInputInitDataAcs.GetDisplayDivList();
                    //表示区分取得ﾃﾞﾘｹﾞｰﾄ
                    if (partsInfoDataSet.GetDisplayDiv == null)
                    {
                        partsInfoDataSet.GetDisplayDiv += new PartsInfoDataSet.GetDisplayDivCallBack(this.GetDisplayDiv);
                    }
                    // --- ADD 2009/10/19 ----------<<<<<

                    // ADD 2010/05/17 品名表示対応 ---------->>>>>
                    // BL商品情報
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 品名表示対応 ----------<<<<<

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 売価未設定時区分
                    partsInfoDataSet.UnPrcNonSettingDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
                    // 在庫情報テーブルを退避
                    PartsInfoDataSet.StockDataTable StockBack = new PartsInfoDataSet.StockDataTable();
                    StockBack = (PartsInfoDataSet.StockDataTable)partsInfoDataSet.Stock.Copy();

                    if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
                    {
                        string rowFilter = "";

                        // 特定得意先の場合･･･在庫数が０以下の引き当ては不可
                        if (_CustAnalysCode1 == 1)
                        {
                            // 在庫数が０以下のデータを抽出
                            rowFilter = String.Format("{0}<={1}", partsInfoDataSet.Stock.ShipmentPosCntColumn.ColumnName, 0);
                            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])partsInfoDataSet.Stock.Select(rowFilter);

                            foreach (PartsInfoDataSet.StockRow stock in rowStock)
                            {
                                for (int iRow = 0; iRow < partsInfoDataSet.Stock.Count; iRow++)
                                {
                                    if ((partsInfoDataSet.Stock[iRow].GoodsMakerCd == stock.GoodsMakerCd) &&
                                        (partsInfoDataSet.Stock[iRow].GoodsNo == stock.GoodsNo) &&
                                        (partsInfoDataSet.Stock[iRow].WarehouseCode == stock.WarehouseCode))
                                    {
                                        // 在庫テーブルから該当データを除外
                                        partsInfoDataSet.Stock.RemoveStockRow(partsInfoDataSet.Stock[iRow]);
                                        break;
                                    }
                                }
                            }
                        }
                        // 営業所の場合･･･本社・自拠点で設定されている倉庫以外の引き当ては不可
                        if (!this._salesSlipInputInitDataAcs.CheckMainSection(this._enterpriseCode, this.SectionCode))
                        {
                            if (partsInfoDataSet.ListPriorWarehouse != null)
                            {
                                // 本社・自拠点で設定されていない倉庫を抽出
                                rowFilter = "";
                                foreach (string PriorWarehouse in partsInfoDataSet.ListPriorWarehouse)
                                {
                                    if (rowFilter != "") rowFilter += " AND ";
                                    rowFilter += String.Format("{0}<>'{1}'", partsInfoDataSet.Stock.WarehouseCodeColumn.ColumnName, PriorWarehouse);
                                }
                                PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])partsInfoDataSet.Stock.Select(rowFilter);

                                foreach (PartsInfoDataSet.StockRow stock in rowStock)
                                {
                                    for (int iRow = 0; iRow < partsInfoDataSet.Stock.Count; iRow++)
                                    {
                                        if ((partsInfoDataSet.Stock[iRow].GoodsMakerCd == stock.GoodsMakerCd) &&
                                            (partsInfoDataSet.Stock[iRow].GoodsNo == stock.GoodsNo) &&
                                            (partsInfoDataSet.Stock[iRow].WarehouseCode == stock.WarehouseCode))
                                        {
                                            // 在庫テーブルから該当データを除外
                                            partsInfoDataSet.Stock.RemoveStockRow(partsInfoDataSet.Stock[iRow]);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "", "○各種設定　終了");

                    // 車両情報補正
                    #region 車両情報補正
                    // --- ADD 譚洪 2014/09/01 ---------->>>>>
                    this.SetCarInfoToThread(cndtn);
                    // --- ADD 譚洪 2014/09/01 ----------<<<<<
                    #endregion

                    SalesSlipInputInitDataAcs.LogWrite("UIDisplayControl", "ProcessPartsSearch", "●部品選択制御起動　開始");
                    #region ●部品選択制御起動
                    //-----------------------------------------------------------------------------
                    // 部品選択制御起動
                    //-----------------------------------------------------------------------------
                    //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
                    // 部品選択UI制御クラスの静的メンバー選択純正品番情報リストをクリアする。
                    UIDisplayControl.CrearSelectedSrcList();
                    //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
                    // --- UPD 2009/10/19 ---------->>>>>
                    partsInfoDataSet.SearchCarInfo = cndtn.SearchCarInfo;
                    DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(this._owner, null, partsInfoDataSet);
                    // --- UPD 2009/10/19 ----------<<<<<
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
                    if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
                    {
                        // 在庫情報テーブルを戻す
                        partsInfoDataSet.Stock.Clear();
                        PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])StockBack.Select();
                        foreach (PartsInfoDataSet.StockRow stock in StockBack)
                        {
                            partsInfoDataSet.Stock.ImportRow(stock);
                        }
                    }
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

                    // --- ADD 2013/12/10 Y.Wakita ---------->>>>>
                    // 部品検索の結果を保管
                    _partsInfo = partsInfoDataSet;
                    // --- ADD 2013/12/10 Y.Wakita ----------<<<<<

                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("UIDisplayControl", "ProcessPartsSearch", "○部品選択制御起動　終了");

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                        case DialogResult.Cancel:
                            partsInfoDataSet.Clear();
                            goodsUnitDataList.Clear();
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                        case DialogResult.Yes:
                            SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "GetGoodsList", "●部品検索データセットから商品連結データオブジェクト取得　開始");
                            #region ●部品検索データセットから選択情報の商品連結データオブジェクトを取得
                            //-----------------------------------------------------------------------------
                            // 部品検索データセットから選択情報の商品連結データオブジェクトを取得
                            //-----------------------------------------------------------------------------
                            // --- UPD 2014/01/15 T.Miyamoto ------------------------------>>>>>
                            ////>>>2010/02/26
                            ////goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            //goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd, false).ToArray(typeof(GoodsUnitData)));
                            ////<<<2010/02/26
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsListWithSrc(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd, false).ToArray(typeof(GoodsUnitData)));
                            // --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
                            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>

                            // 部品選択UI制御クラスの静的メンバー選択純正品番情報リストを取得
                            List<GoodsUnitData> selectedSrcList = UIDisplayControl.SelectedSrcList;

                            // 選択純正品番情報リストがnullでなく、かつ要素数が1以上の場合、
                            // 結合元（純正）品情報のセットを行う
                            if ( null != selectedSrcList && 0 < selectedSrcList.Count )
                            {
                                //選択情報の商品連結データオブジェクトリストの要素毎に結合元検索結果を設定
                                foreach (GoodsUnitData nowUnit in goodsUnitDataList)
                                {
                                     //選択純正情報リストの該当情報から結合元検索結果を取得して設定
                                    foreach (GoodsUnitData nowSrc in selectedSrcList)
                                    {
                                        if (0 != string.Compare(nowUnit.GoodsNo, nowSrc.GoodsNo))
                                        {
                                            // 結合先（優良）品番が異なる場合、対象外
                                            continue;
                                        }
                                        if (nowUnit.GoodsMakerCd != nowSrc.GoodsMakerCd)
                                        {
                                            // 結合先（優良）品メーカーコードが異なる場合、対象外
                                            continue;
                                        }

                                        // 結合元（純正）品のメーカーコードを設定
                                        nowUnit.JoinSourceMakerCode = nowSrc.JoinSourceMakerCode;
                                        // 結合元（純正）品の品番を設定
                                        nowUnit.JoinSrcPartsNoWithH = nowSrc.JoinSrcPartsNoWithH;

                                        //対象の品番検索結果から結合元（純正）品の部品情報を取得
                                        PartsInfoDataSet.UsrGoodsInfoRow targetGoodsInfoRow = partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                                            nowUnit.JoinSourceMakerCode, nowUnit.JoinSrcPartsNoWithH);

                                        //結合元（純正）品の部品情報を取得出来なかった場合、結合元（純正）品の部品情報を追加する
                                        if (null == targetGoodsInfoRow)
                                        {
                                            PartsInfoDataSet.UsrGoodsInfoRow newRow = partsInfoDataSet.UsrGoodsInfo.NewUsrGoodsInfoRow();
                                            newRow.BlGoodsCode = nowUnit.BLGoodsCode;
                                            newRow.GoodsMakerCd = nowUnit.JoinSourceMakerCode;
                                            newRow.GoodsNo = nowUnit.JoinSrcPartsNoWithH;
                                            partsInfoDataSet.UsrGoodsInfo.AddUsrGoodsInfoRow(newRow);
                                            partsInfoDataSet.UsrGoodsInfo.AcceptChanges();
                                        }

                                        break;
                                    }
                                }
                            }
                            //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
                            #endregion
                            SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "GetGoodsList", "○部品検索データセットから商品連結データオブジェクト取得　終了", "結果データセット対象件数:" + partsInfoDataSet.UsrGoodsInfo.Count.ToString(), "対象件数:" + goodsUnitDataList.Count.ToString());
                            
                            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "●商品連結データ不足情報設定　開始");
                            #region ●商品連結データ不足情報設定
                            //-------------------------------------------------------------------------
                            // 商品連結データ不足情報設定
                            //-------------------------------------------------------------------------
                            this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, this._salesSlip.ResultsAddUpSecCd);
                            #endregion
                            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "○商品連結データ不足情報設定　終了", "処理件数:" + goodsUnitDataList.Count.ToString());
                            break;
                        case DialogResult.Retry:
                            break;
                    }
                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // 該当データ無し
                    break;
            }
            
            //>>>2013/04/06
            if ((goodsUnitDataList != null) && (goodsUnitDataList.Count != 0))
            {
                //<<<2013/04/06
                // ADD 2013/04/04 SCM障害№10504対応 --------------------------------------->>>>>
                if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo))
                {
                    this._originalBLGoodsCodeMap[salesRowNo] = goodsUnitDataList[0].BLGoodsCode;
                }
                else
                {
                    this._originalBLGoodsCodeMap.Add(salesRowNo, goodsUnitDataList[0].BLGoodsCode);
                }
                // 部品選択で2品以上選択した場合を考慮
                int cnt = goodsUnitDataList.Count - 1;
                for (int i = 0; i < cnt; i++)
                {
                    if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo + i + 1))
                    {
                        this._originalBLGoodsCodeMap[salesRowNo] = goodsUnitDataList[i].BLGoodsCode;
                    }
                    else
                    {
                        this._originalBLGoodsCodeMap.Add(salesRowNo + i + 1, goodsUnitDataList[i].BLGoodsCode);
                    }
                }
                // ADD 2013/04/04 SCM障害№10504対応 ---------------------------------------<<<<<
            //>>>2013/04/06
            }
            else
            {
                // 品番検索で該当しなかった場合、２部品以上の選択は存在しないので以下ロジックのみとする
                if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo))
                {
                    this._originalBLGoodsCodeMap[salesRowNo] = 0;
                }
                else
                {
                    this._originalBLGoodsCodeMap.Add(salesRowNo, 0);
                }
            }
            //<<<2013/04/06

            return status;
        }

        /// <summary>
        /// BLコード検索
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="bLGoodsCode">BLコード</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns>ConstantManagement.MethodResult(-3:車両情報無し)</returns>
        /// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
        /// <br>UpdateNote : 2011/10/27 高峰 Redmine#26293 売上伝票入力／PMからいきなり回答する場合のＢＬコードの回答方法の対応</br>
        //>>>2010/02/26
        //public int SearchPartsFromBLCode(int salesRowNo, string enterpriseCode, string sectionCode, int bLGoodsCode, out List<GoodsUnitData> goodsUnitDataList)
        public int SearchPartsFromBLCode(int salesRowNo, string enterpriseCode, string sectionCode, int bLGoodsCode, int blGoodsDrCode, out List<GoodsUnitData> goodsUnitDataList)
        //<<<2010/02/26
        {
            // ----- ADD 2011/10/27 ----- >>>>>
            if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo))
            {
                this._originalBLGoodsCodeMap[salesRowNo] = bLGoodsCode;
            }
            else
            {
                this._originalBLGoodsCodeMap.Add(salesRowNo, bLGoodsCode);
            }
            // ----- ADD 2011/10/27 ----- <<<<<
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "●ＢＬコード検索前初期化　開始");
            #region ●初期化
            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            string msg;
            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            goodsUnitDataList = new List<GoodsUnitData>();
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "○ＢＬコード検索前初期化　終了");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "●抽出条件設定　開始");
            #region ●抽出条件設定
            //-----------------------------------------------------------------------------
            // 抽出条件設定
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.BLGoodsCode = bLGoodsCode;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            cndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
            cndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
            cndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
            cndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
            cndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
            cndtn.PartsNoSearchDivCd = this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue;
            cndtn.PartsJoinCntDivCd = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;
            cndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            cndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
            cndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
            cndtn.PriceApplyDate = this._salesSlip.SalesDate;
            cndtn.IsSettingSupplier = 1;

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            //>>>ddddd
            //if ((row != null) && (row.CarRelationGuid != Guid.Empty))
            //    cndtn.SearchCarInfo = this.GetCarInfoFromDic(row.CarRelationGuid);
            //else
            //    cndtn.SearchCarInfo = this.GetCarInfoFromDic(this._beforeCarRelationGuid);

            Guid carGuid = Guid.Empty;
            if ((row != null) && (row.CarRelationGuid != Guid.Empty))
            {
                carGuid = row.CarRelationGuid;
            }
            else
            {
                carGuid = this._beforeCarRelationGuid;
            }

            cndtn.SearchCarInfo = this.GetCarInfoFromDic(carGuid);

            // --- ADD 2013/02/13 Y.Wakita ---------->>>>>
            if (cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput > 0)
            {
                if ((cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput % 100) == 0)
                {
                    cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = 0;
                }
            }
            // --- ADD 2013/02/13 Y.Wakita ----------<<<<<

            //>>>2011/03/10
            //PMKEN01010E.ColorCdInfoDataTable colorTable = this.GetColorInfo(row.CarRelationGuid);
            //if (colorTable != null)
            //{
            //    PMKEN01010E.ColorCdInfoRow colorRow = this.GetSelectColorInfo(row.CarRelationGuid);
            //    if (colorRow != null)
            //    {
            //        this.SelectColorInfo(row.CarRelationGuid, cndtn.SearchCarInfo.ColorCdInfo, colorRow.ColorCode);
            //    }
            //}
            //PMKEN01010E.TrimCdInfoDataTable trimTable = this.GetTrimInfo(row.CarRelationGuid);
            //if (trimTable != null)
            //{
            //    PMKEN01010E.TrimCdInfoRow trimRow = this.GetSelectTrimInfo(row.CarRelationGuid);
            //    if (trimRow != null)
            //    {
            //        this.SelectTrimInfo(row.CarRelationGuid, cndtn.SearchCarInfo.TrimCdInfo, trimRow.TrimCode);
            //    }
            //}
            PMKEN01010E.ColorCdInfoDataTable colorTable = this.GetColorInfo(carGuid);
            if (colorTable != null)
            {
                PMKEN01010E.ColorCdInfoRow colorRow = this.GetSelectColorInfo(carGuid);
                if (colorRow != null)
                {
                    this.SelectColorInfo(carGuid, cndtn.SearchCarInfo.ColorCdInfo, colorRow.ColorCode);
                }
            }
            PMKEN01010E.TrimCdInfoDataTable trimTable = this.GetTrimInfo(carGuid);
            if (trimTable != null)
            {
                PMKEN01010E.TrimCdInfoRow trimRow = this.GetSelectTrimInfo(carGuid);
                if (trimRow != null)
                {
                    this.SelectTrimInfo(carGuid, cndtn.SearchCarInfo.TrimCdInfo, trimRow.TrimCode);
                }
            }
            //<<<2011/03/10
            //<<<ddddd
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "○抽出条件設定　終了");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "●車輌情報存在チェック　開始");
            #region ●車両情報存在チェック
            //-----------------------------------------------------------------------------
            // 車両情報存在チェック
            //-----------------------------------------------------------------------------
            if (cndtn.SearchCarInfo == null) return -3;
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "○車輌情報存在チェック　終了");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromBLCode", "●ＢＬコード検索　開始");
            #region ●BLコード検索
            //-----------------------------------------------------------------------------
            // BLコード検索
            //-----------------------------------------------------------------------------
            int status = this._salesSlipInputInitDataAcs.SearchPartsFromBLCode(cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList);
            }
            // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromBLCode", "○ＢＬコード検索　終了", "検索数:" + goodsUnitDataList.Count.ToString());

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // 選択無し
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理
#if true
                    if (partsInfoDataSet.CalculateGoodsPrice == null)
                    {
                        partsInfoDataSet.CalculateGoodsPrice += new PartsInfoDataSet.CalculateGoodsPriceCallback(this.CalculateUnitPrice);
                    }
                    if (partsInfoDataSet.CalculatePrice== null)
                    {
                        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(this.CalcPrice);
                    }
                    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;
#else
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "●商品連結データ不足情報設定　開始");
                    #region ●商品連結データ不足情報設定
                    //-----------------------------------------------------------------------------
                    // 商品連結データ不足情報設定
                    //-----------------------------------------------------------------------------
                    this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "○商品連結データ不足情報設定　終了", "処理件数:" + goodsUnitDataList.Count.ToString());

                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "●単価情報取得　開始");
                    #region ●単価情報取得
                    //-----------------------------------------------------------------------------
                    // 単価情報取得
                    //-----------------------------------------------------------------------------
                    unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "○単価情報取得　終了", "対象商品数:" + goodsUnitDataList.Count.ToString(), "該当単価情報数:" + unitPriceCalcRetList.Count);

                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "SetUnitPriceInfo", "●単価情報を部品検索データセットへ反映　開始");
                    #region ●単価情報を部品検索データセットへ反映
                    //-----------------------------------------------------------------------------
                    // 単価情報を部品検索データセットへ反映
                    //-----------------------------------------------------------------------------
                    if ((unitPriceCalcRetList != null) && (unitPriceCalcRetList.Count != 0)) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "SetUnitPriceInfo", "○単価情報を部品検索データセットへ反映　終了", "対象商品数:" + goodsUnitDataList.Count.ToString(), "該当単価情報数:" + unitPriceCalcRetList.Count);
#endif
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "", "●各種設定　開始");
                    #region ●各種設定
                    //-----------------------------------------------------------------------------
                    // 優先倉庫設定
                    //-----------------------------------------------------------------------------
                    // 優先倉庫リスト作成(得意先優先倉庫＋拠点優先倉庫)
                    List<string> warehouseList = new List<string>();
                    //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                    warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                    
                    partsInfoDataSet.ListPriorWarehouse = warehouseList;

                    //-----------------------------------------------------------------------------
                    // 品名表示区分
                    //-----------------------------------------------------------------------------
                    // DEL 2010/05/17 品名表示対応 ---------->>>>>
                    //partsInfoDataSet.PartsNameDspDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd;
                    // DEL 2010/05/17 品名表示対応 ----------<<<<<
                    // ADD 2010/05/17 品名表示対応 ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._salesSlipInputInitDataAcs.GetSalesTtlSt());
                    // ADD 2010/05/17 品名表示対応 ----------<<<<<

                    //>>>2010/02/26
                    //-----------------------------------------------------------------------------
                    // BLコード枝番
                    //-----------------------------------------------------------------------------
                    partsInfoDataSet.BLGoodsDrCode = blGoodsDrCode;
                    //<<<2010/02/26

                    // --- ADD 2009/10/19 ---------->>>>>
                    //表示区分ﾌﾟﾛｾｽ
                    partsInfoDataSet.PriceSelectDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PriceSelectDispDiv;
                    //結合元検索ﾃﾞﾘｹﾞｰﾄ
                    if (partsInfoDataSet.SearchPartsForSrcParts == null)
                    {
                        partsInfoDataSet.SearchPartsForSrcParts += new PartsInfoDataSet.SearchPartsForSrcPartsCallBack(this.SearchPartsForSrcPartsPrc);
                    }
                    //得意先ｺｰﾄﾞ
                    partsInfoDataSet.CustomerCode = this._salesSlip.CustomerCode;
                    //得意先掛率ｸﾞﾙｰﾌﾟｺｰﾄﾞﾘｽﾄ
                    partsInfoDataSet.CustRateGrpCodeList = this._salesSlipInputInitDataAcs.GetGetCustRateGrpAll();
                    //得意先掛率ｸﾞﾙｰﾌﾟ取得ﾃﾞﾘｹﾞｰﾄ
                    if (partsInfoDataSet.GetCustRateGrp == null)
                    {
                        partsInfoDataSet.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(this.GetCustRateGrpCode);
                    }
                    //表示区分ﾘｽﾄ
                    partsInfoDataSet.PriceSelectDivList = this._salesSlipInputInitDataAcs.GetDisplayDivList();
                    //表示区分取得ﾃﾞﾘｹﾞｰﾄ
                    if (partsInfoDataSet.GetDisplayDiv == null)
                    {
                        partsInfoDataSet.GetDisplayDiv += new PartsInfoDataSet.GetDisplayDivCallBack(this.GetDisplayDiv);
                    }
                    // --- ADD 2009/10/19 ----------<<<<<

                    // ADD 2010/05/17 品名表示対応 ---------->>>>>
                    // BL商品情報
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 品名表示対応 ----------<<<<<   

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // 売価未設定時区分
                    partsInfoDataSet.UnPrcNonSettingDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
                    // 在庫情報テーブルを退避
                    PartsInfoDataSet.StockDataTable StockBack = new PartsInfoDataSet.StockDataTable();
                    StockBack = (PartsInfoDataSet.StockDataTable)partsInfoDataSet.Stock.Copy();

                    if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
                    {
                        string rowFilter = "";

                        // 特定得意先の場合･･･在庫数が０以下の引き当ては不可
                        if (_CustAnalysCode1 == 1)
                        {
                            // 在庫数が０以下のデータを抽出
                            rowFilter = String.Format("{0}<={1}", partsInfoDataSet.Stock.ShipmentPosCntColumn.ColumnName, 0);
                            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])partsInfoDataSet.Stock.Select(rowFilter);

                            foreach (PartsInfoDataSet.StockRow stock in rowStock)
                            {
                                for (int iRow = 0; iRow < partsInfoDataSet.Stock.Count; iRow++)
                                {
                                    if ((partsInfoDataSet.Stock[iRow].GoodsMakerCd == stock.GoodsMakerCd) &&
                                        (partsInfoDataSet.Stock[iRow].GoodsNo == stock.GoodsNo) &&
                                        (partsInfoDataSet.Stock[iRow].WarehouseCode == stock.WarehouseCode))
                                    {
                                        // 在庫テーブルから該当データを除外
                                        partsInfoDataSet.Stock.RemoveStockRow(partsInfoDataSet.Stock[iRow]);
                                        break;
                                    }
                                }
                            }
                        }
                        // 営業所の場合･･･本社・自拠点で設定されている倉庫以外の引き当ては不可
                        if (!this._salesSlipInputInitDataAcs.CheckMainSection(this._enterpriseCode, this.SectionCode))
                        {
                            if (partsInfoDataSet.ListPriorWarehouse != null)
                            {
                                // 本社・自拠点で設定されていない倉庫を抽出
                                rowFilter = "";
                                foreach (string PriorWarehouse in partsInfoDataSet.ListPriorWarehouse)
                                {
                                    if (rowFilter != "") rowFilter += " AND ";
                                    rowFilter += String.Format("{0}<>'{1}'", partsInfoDataSet.Stock.WarehouseCodeColumn.ColumnName, PriorWarehouse);
                                }
                                PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])partsInfoDataSet.Stock.Select(rowFilter);
                             
                                foreach (PartsInfoDataSet.StockRow stock in rowStock)
                                {
                                    for (int iRow = 0; iRow < partsInfoDataSet.Stock.Count; iRow++)
                                    {
                                        if ((partsInfoDataSet.Stock[iRow].GoodsMakerCd == stock.GoodsMakerCd) &&
                                            (partsInfoDataSet.Stock[iRow].GoodsNo == stock.GoodsNo) &&
                                            (partsInfoDataSet.Stock[iRow].WarehouseCode == stock.WarehouseCode))
                                        {
                                            // 在庫テーブルから該当データを除外
                                            partsInfoDataSet.Stock.RemoveStockRow(partsInfoDataSet.Stock[iRow]);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "", "○各種設定　終了");

                    // 車両情報補正
                    #region 車両情報補正
                    // --- ADD 譚洪 2014/09/01 ---------->>>>>
                    this.SetCarInfoToThread(cndtn);
                    // --- ADD 譚洪 2014/09/01 ----------<<<<<
                    #endregion

                    SalesSlipInputInitDataAcs.LogWrite("UIDisplayControl", "ProcessPartsSearch", "●部品選択制御起動　開始");
                    #region ●部品選択制御起動
                    //-----------------------------------------------------------------------------
                    // 部品選択制御起動
                    //-----------------------------------------------------------------------------
                    partsInfoDataSet.TBOInitializeFlg = 0;
                    DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(this._owner, cndtn.SearchCarInfo, partsInfoDataSet);
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
                    if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
                    {
                        // 在庫情報テーブルを戻す
                        partsInfoDataSet.Stock.Clear();
                        PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])StockBack.Select();
                        foreach (PartsInfoDataSet.StockRow stock in StockBack)
                        {
                            partsInfoDataSet.Stock.ImportRow(stock);
                        }
                    }
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

                    // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // 部品検索の結果を保管
                    _partsInfo = partsInfoDataSet;
                    // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("UIDisplayControl", "ProcessPartsSearch", "○部品選択制御起動　終了");

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                        case DialogResult.Cancel:
                            partsInfoDataSet.Clear();
                            goodsUnitDataList.Clear();
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                        case DialogResult.Yes:
                            SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "GetGoodsList", "●部品検索データセットから商品連結データオブジェクト取得　開始");
                            #region ●部品検索データセットから選択情報の商品連結データオブジェクトを取得
                            //-----------------------------------------------------------------------------
                            // 部品検索データセットから選択情報の商品連結データオブジェクトを取得
                            //-----------------------------------------------------------------------------
                            // --- UPD 2014/01/15 T.Miyamoto ------------------------------>>>>>
                            //goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsListWithSrc(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            // --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
                            #endregion
                            SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "GetGoodsList", "○部品検索データセットから商品連結データオブジェクト取得　終了", "結果データセット対象件数:" + partsInfoDataSet.UsrGoodsInfo.Count.ToString(), "対象件数:" + goodsUnitDataList.Count.ToString());

                            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "●商品連結データ不足情報設定　開始");
                            #region ●商品連結データ不足情報設定
                            //-------------------------------------------------------------------------
                            // 商品連結データ不足情報設定
                            //-------------------------------------------------------------------------
                            this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, this._salesSlip.ResultsAddUpSecCd);
                            #endregion
                            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "○商品連結データ不足情報設定　終了", "処理件数:" + goodsUnitDataList.Count.ToString());
                            break;
                        case DialogResult.Retry:
                            break;
                    }
                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // 該当データ無し
                    break;
            }
            // ADD 2013/02/22 T.Yoshioka 2013/03/06配信予定 SCM障害№108 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 部品選択で2品以上選択した場合を考慮
            int cnt = goodsUnitDataList.Count - 1;
            for (int i = 0; i < cnt; i++)
            {
                if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo + i + 1))
                {
                    this._originalBLGoodsCodeMap[salesRowNo] = bLGoodsCode;
                }
                else
                {
                    this._originalBLGoodsCodeMap.Add(salesRowNo + i + 1, bLGoodsCode);
                }
            }
            // ADD 2013/02/22 T.Yoshioka 2013/03/06配信予定 SCM障害№108 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>> 
        /// <summary>
        /// 純正情報取得処理
        /// </summary>
        /// <param name="partsInfoDataSet"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="i"></param>
        /// <param name="pureGoodsMakerCd"></param>
        /// <param name="ansPureGoodsNo"></param>
        private bool GetPureInfo(PartsInfoDataSet partsInfoDataSet, int goodsMakerCd, string goodsNo, int i, out int pureGoodsMakerCd, out string ansPureGoodsNo)
        {
            bool ret = false;
            PartsInfoDataSet.UsrJoinPartsDataTable usrJoinPartsDataTable = (PartsInfoDataSet.UsrJoinPartsDataTable)partsInfoDataSet.UsrJoinParts.Copy();
            PartsInfoDataSet.UsrGoodsInfoDataTable usrGoodsInfoDataTable = (PartsInfoDataSet.UsrGoodsInfoDataTable)partsInfoDataSet.UsrGoodsInfo.Copy();
            pureGoodsMakerCd = 0;
            ansPureGoodsNo = string.Empty;

            if (usrJoinPartsDataTable == null) return ret;

            string filter = string.Format("{0}={1} AND {2}='{3}'", usrJoinPartsDataTable.JoinDestMakerCdColumn.ColumnName,
                                                                   goodsMakerCd,
                                                                   usrJoinPartsDataTable.JoinDestPartsNoColumn.ColumnName,
                                                                   goodsNo);
            PartsInfoDataSet.UsrJoinPartsRow[] usrJoinPartsRows = (PartsInfoDataSet.UsrJoinPartsRow[])usrJoinPartsDataTable.Select(filter);

            if ((usrJoinPartsRows != null) && (usrJoinPartsRows.Length >= i + 1) && (usrGoodsInfoDataTable != null))
            {
                filter = string.Format("{0}={1} AND {2}='{3}'", usrGoodsInfoDataTable.GoodsMakerCdColumn.ColumnName,
                                                                      usrJoinPartsRows[i].JoinSourceMakerCode,
                                                                      usrGoodsInfoDataTable.GoodsNoColumn.ColumnName,
                                                                      usrJoinPartsRows[i].JoinSrcPartsNoWithH);
                PartsInfoDataSet.UsrGoodsInfoRow[] usrGoodsInfoRows = (PartsInfoDataSet.UsrGoodsInfoRow[])usrGoodsInfoDataTable.Select(filter);

                if ((usrGoodsInfoRows != null) && (usrGoodsInfoRows.Length != 0))
                {
                    pureGoodsMakerCd = usrGoodsInfoRows[0].GoodsMakerCd;
                    if (usrGoodsInfoRows[0].NewGoodsNo.Trim() != string.Empty)
                    {
                        ansPureGoodsNo = usrGoodsInfoRows[0].NewGoodsNo;
                    }
                    else
                    {
                        ansPureGoodsNo = usrJoinPartsRows[0].JoinSrcPartsNoWithH;
                    }
                    ret = true;
                }
            }

            return ret;
        }
        // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 純正定価情報取得処理
        /// </summary>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsMakerCd">メーカー</param>
        /// <param name="goodsNo">品番</param>
        private PartsInfoDataSet.UsrGoodsInfoRow GetPurePriceInfo(PartsInfoDataSet partsInfoDataSet, GoodsUnitData goodsUnitData)
        {
            PartsInfoDataSet.UsrGoodsInfoRow retGoodsInfoRow = null;

            PartsInfoDataSet.UsrGoodsInfoDataTable usrGoodsInfoDataTable = (PartsInfoDataSet.UsrGoodsInfoDataTable)partsInfoDataSet.UsrGoodsInfo.Copy();

            // 選択した優良品の結合元(純正)部品をGoodsInfoから検索
            retGoodsInfoRow = usrGoodsInfoDataTable.FindByGoodsMakerCdGoodsNo(goodsUnitData.JoinSourceMakerCode, goodsUnitData.JoinSrcPartsNoWithH);
            if (retGoodsInfoRow != null)
            {
                if (retGoodsInfoRow.NewGoodsNo.Trim() != string.Empty)
                {
                    // 結合元が代替されている場合は新品番でGoodsInfoを再検索
                    retGoodsInfoRow = usrGoodsInfoDataTable.FindByGoodsMakerCdGoodsNo(retGoodsInfoRow.GoodsMakerCd, retGoodsInfoRow.NewGoodsNo);
                }
            }
            return retGoodsInfoRow;
        }
        // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// 単価算出処理（デリゲートに使用）
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="unitPriceCalcRetList"></param>
        private void CalculateUnitPrice(List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            unitPriceCalcRetList = null;
            if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0)) return;

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "▼商品連結データ不足情報設定　開始");
            this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, false, this._salesSlip.ResultsAddUpSecCd);
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "▲商品連結データ不足情報設定　終了", "処理件数:" + goodsUnitDataList.Count.ToString());

            //-----------------------------------------------------------------------------
            // 単価情報取得
            //-----------------------------------------------------------------------------
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "▼単価情報取得　開始");
            unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList);
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "▲単価情報取得　終了", "対象商品数:" + goodsUnitDataList.Count.ToString(), "該当単価情報数:" + unitPriceCalcRetList.Count);

            // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>
            // 単価算出部品より商品価格を取得
            List<UnitPriceCalcRet> tempUnitPriceCalcRetList = new List<UnitPriceCalcRet>();
            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                // 原価データ取得
                if (unitPriceCalcRet.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    tempUnitPriceCalcRetList.Add(unitPriceCalcRet);
                }
            }
            // 再設定区分
            bool resettingDiv = false;
            // 初回区分
            bool isFirst = false;
            bool isUnitData = false;
            string logMsg = string.Empty;
            // ログ出力
            if (LogCommon == null)
            {
                LogCommon = new OutLogCommon();
            }
            // 現単価情報再取得処理
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                isUnitData = false;
                foreach (UnitPriceCalcRet unitPriceCalcRet in tempUnitPriceCalcRetList)
                {
                    // 商品情報再取得
                    if (unitPriceCalcRet.GoodsMakerCd == goodsUnitData.GoodsMakerCd &&
                        unitPriceCalcRet.GoodsNo == goodsUnitData.GoodsNo)
                    {
                        isUnitData = true;
                        // 現単価が0円の場合、現単価情報再取得処理
                        if (unitPriceCalcRet.UnitPriceTaxExcFl == CtZero &&       // 現単価が0円
                            goodsUnitData.GoodsMakerCd != CtZero &&               // メーカーコード
                           (string.IsNullOrEmpty(goodsUnitData.MakerName) ||      // メーカー名
                            string.IsNullOrEmpty(goodsUnitData.MakerKanaName)))   // メーカーカナ名
                        {
                            // ログ内容
                            logMsg = string.Format(LogMessage, MethodNameUnit, LogInfo(goodsUnitData));
                            // ログ出力
                            LogCommon.OutputClientLogWithSettingSleep(PGID_XML, logMsg, this._enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, CtSleepMode);

                            // 初回にＢＬコード関連マスタ取得処理
                            if (!isFirst)
                            {
                                this._salesSlipInputInitDataAcs.SearchBLGoodsInfo(this._enterpriseCode);
                                isFirst = true;
                            }
                            // 再設定する
                            resettingDiv = true;
                            break;
                        }
                    }
                }
                // 現単価情報取得しないの場合、現単価情報再取得処理
                if (!isUnitData)
                {
                    if (goodsUnitData.GoodsMakerCd != CtZero &&              // メーカーコード
                        (string.IsNullOrEmpty(goodsUnitData.MakerName) ||    // メーカー名
                        string.IsNullOrEmpty(goodsUnitData.MakerKanaName)))  // メーカーカナ名
                    {
                        // ログ内容
                        logMsg = string.Format(LogMessage, MethodNameUnit, LogInfo(goodsUnitData));
                        // ログ出力
                        LogCommon.OutputClientLogWithSettingSleep(PGID_XML, logMsg, this._enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, CtSleepMode);

                        // 初回にＢＬコード関連マスタ取得処理
                        if (!isFirst)
                        {
                            this._salesSlipInputInitDataAcs.SearchBLGoodsInfo(this._enterpriseCode);
                            isFirst = true;
                        }
                        // 再設定する
                        resettingDiv = true;
                    }
                }
            }

            // 再設定の場合、現単価情報再設定
            if (resettingDiv)
            {
                // 商品連結データ不足情報設定
                this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, false, this._salesSlip.ResultsAddUpSecCd);
                
                // 単価情報取得
                unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList);
            }
            // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<
        }

        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133-------->>>>>
        /// <summary>
        /// ログ内容を設定します。
        /// </summary>
        /// <param name="goodsUnitData">商品情報</param>
        /// <remarks>
        /// <br>Note       : ログ内容を設定します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2021/03/16</br>
        /// </remarks>
        public string LogInfo(GoodsUnitData　goodsUnitData)
        {
            StringBuilder logMsg = new StringBuilder();
            // 商品情報取得の場合、ログ内容を作成
            if (goodsUnitData != null && this._salesSlip != null)
            {
                // メーカーコード
                logMsg.Append(string.Format(CtMakeCode, goodsUnitData.GoodsMakerCd));
                // 品番
                logMsg.Append(string.Format(CtGoodsNo, goodsUnitData.GoodsNo));
                // 品名
                logMsg.Append(string.Format(CtGoodsName, goodsUnitData.GoodsName));
                // BL商品コード
                logMsg.Append(string.Format(CtBLGoodsCode, goodsUnitData.BLGoodsCode));
                // 商品大分類コード
                logMsg.Append(string.Format(CtGoodsLGroup, goodsUnitData.GoodsLGroup));
                // 商品中分類コード
                logMsg.Append(string.Format(CtGoodsMGroup, goodsUnitData.GoodsMGroup));
                // BLグループコード
                logMsg.Append(string.Format(CtBLGroupCode, goodsUnitData.BLGroupCode));
                // 商品掛率ランク(層別)
                logMsg.Append(string.Format(CtGoodsRateRank, goodsUnitData.GoodsRateRank));
                // 自社分類コード
                logMsg.Append(string.Format(CtEnterpriseGanreCode, goodsUnitData.EnterpriseGanreCode));
                // 商品掛率グループコード
                logMsg.Append(string.Format(CtGoodsRateGrpCd, goodsUnitData.GoodsRateGrpCode));
                // 仕入先コード
                logMsg.Append(string.Format(CtSupplierCd, goodsUnitData.SupplierCd));
                // 拠点
                logMsg.Append(string.Format(CtSectionCode, _salesSlip.SectionCode));
                // 得意先コード
                logMsg.Append(string.Format(CtCustomerCode, _salesSlip.CustomerCode));
                // 担当者コード
                logMsg.Append(string.Format(CtEmployeeCode, _salesSlip.InputAgenCd));
                // 売上日
                logMsg.Append(string.Format(CtSalesDate, _salesSlip.SalesDate.ToString("yyyy/MM/dd")));
            }
            return logMsg.ToString();
        }
        // ------ ADD 2021/03/16 陳艶丹 FOR PMKOBETSU-4133--------<<<<

        /// <summary>
        /// 価格計算処理（デリゲートに使用）
        /// </summary>
        /// <param name="taxationCode"></param>
        /// <param name="unitPrice"></param>
        /// <param name="priceTaxExc"></param>
        /// <param name="priceTaxInc"></param>
        private void CalcPrice(int taxationCode, double unitPrice, out double priceTaxExc, out double priceTaxInc)
        {
            // 消費税端数処理コード
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            this.CalclatePrice(unitPrice, taxationCode, this._salesSlip.TotalAmountDispWayCd, this._salesSlip.ConsTaxLayMethod, this._salesSlip.ConsTaxRate, salesCnsTaxFrcProcCd, out priceTaxExc, out priceTaxInc);
        }

        /// <summary>
        /// 結合元検索処理（デリゲートに使用）
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="goodsCndt"></param>
        /// <param name="partsInfoDataSe"></param>
        /// <param name="goodsUnitDataLis"></param>
        /// <param name="msg"></param>
        /// <br>Note       : 結合元情報を検索します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/10/19</br>
        private void SearchPartsForSrcPartsPrc(int mode, GoodsCndtn goodsCndt, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            partsInfoDataSet = new PartsInfoDataSet();
            goodsUnitDataList = new List<GoodsUnitData>();
            msg = string.Empty;

            //-----------------------------------------------------------------------------
            if (goodsCndt == null) return;
            // 結合元検索
            //-----------------------------------------------------------------------------
            int status = this._salesSlipInputInitDataAcs.SearchPartsForSrcParts(mode, goodsCndt, out partsInfoDataSet, out goodsUnitDataList, out msg);
            // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList);
            }
            // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<

            if (partsInfoDataSet.CalculatePrice == null)
            {
                partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(this.CalcPrice);
            }

            partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;

            // ADD 2010/05/17 品名表示対応 ---------->>>>>
            if (partsInfoDataSet.GetBLGoodsInfo == null)
            {
                partsInfoDataSet.SetPartsNameDisplayPattern(this._salesSlipInputInitDataAcs.GetSalesTtlSt());

                // BL商品情報
                if (partsInfoDataSet.GetBLGoodsInfo == null)
                {
                    partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                }
            }
            // ADD 2010/05/17 品名表示対応 ----------<<<<<

        }

        /// <summary>
        /// 得意先掛率ｸﾞﾙｰﾌﾟ検索処理（デリゲートに使用）
        /// </summary>
        /// <param name="custRateGrpCodeList">得意先マスタ(掛率グループ)リスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <br>Note       : 得意先掛率ｸﾞﾙｰﾌﾟ情報を検索します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/10/19</br>
        private void GetCustRateGrpCode(ArrayList custRateGrpCodeList, int customerCode, int goodsMakerCode, out int custRateGrpCode)
        {
            custRateGrpCode = 0;
            if (custRateGrpCodeList == null) return;

            //-----------------------------------------------------------------------------
            // 得意先掛率ｸﾞﾙｰﾌﾟ検索
            //-----------------------------------------------------------------------------
            this._custRateGroupAcs.GetCustRateGrp(custRateGrpCodeList, customerCode, goodsMakerCode, out custRateGrpCode);

        }

        /// <summary>
        /// 表示区分取得検索処理（デリゲートに使用）
        /// </summary>
        /// <param name="custRateGrpCodeList">得意先マスタ(掛率グループ)リスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <br>Note       : 得意先掛率ｸﾞﾙｰﾌﾟ情報を検索します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/10/19</br>
        private void GetDisplayDiv(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32 priceSelectDiv)
        {
            priceSelectDiv = -1;
            if (displayDivList == null) return;

            //-----------------------------------------------------------------------------
            // 表示区分検索
            //-----------------------------------------------------------------------------
            this._priceSelectSetAcs.GetDisplayDiv(displayDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, out priceSelectDiv);
        }

        /// <summary>
        /// 対象価格から、税抜金額、税込金額、表示金額を計算します
        /// </summary>
        /// <param name="targetPrice">対象価格</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <param name="taxRate">税率</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード</param>
        /// <param name="priceTaxExc">税抜金額</param>
        /// <param name="priceTaxInc">税込金額</param>
        private void CalclatePrice(double targetPrice, int taxationCode, int totalAmountDispWayCd, int consTaxLayMethod, double taxRate, int salesCnsTaxFrcProcCd, out  double priceTaxExc, out  double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;

            if (targetPrice == 0) return;

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo((int)SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            // 総額表示しない
            if (totalAmountDispWayCd == 0)
            {
                // 課税区分「非課税」、転嫁方式：非課税
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税（内税）」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                }
            }
            // 総額表示する
            else
            {
                // 課税区分「非課税」、転嫁方式：非課税
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税（内税）」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // 課税区分が「課税」の場合
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
            }
        }

        /// <summary>
        /// TBO検索
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns>ConstantManagement.MethodResult</returns>
        public int SearchTBO(int salesRowNo, string enterpriseCode, string sectionCode, out List<GoodsUnitData> goodsUnitDataList)
        {
            //-----------------------------------------------------------------------------
            // 初期化
            //-----------------------------------------------------------------------------
            string msg;
            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            goodsUnitDataList = new List<GoodsUnitData>();

            //-----------------------------------------------------------------------------
            // 抽出条件設定
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            cndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
            cndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
            cndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
            cndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
            cndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
            cndtn.PartsNoSearchDivCd = this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue;
            cndtn.PartsJoinCntDivCd = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;
            cndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            cndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
            cndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
            // 優先倉庫リスト作成(得意先優先倉庫＋拠点優先倉庫)
            List<string> warehouseList = new List<string>();
            //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
            warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
            cndtn.ListPriorWarehouse = warehouseList;

            cndtn.CustomerCode = this._salesSlip.CustomerCode;
            cndtn.PriceApplyDate = this._salesSlip.SalesDate; // 適用日
            cndtn.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            cndtn.TaxRate = this._salesSlip.ConsTaxRate;
            cndtn.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;
            cndtn.TtlAmntDspRateDivCd = this._salesSlipInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;
            cndtn.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            cndtn.IsSettingSupplier = 1;

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null)
            {
                cndtn.CustRateGrpCode = row.CustRateGrpCode;
                if (row.CarRelationGuid != Guid.Empty)
                {
                    cndtn.SearchCarInfo = this.GetCarInfoFromDic(row.CarRelationGuid);
                }
                else
                {
                    cndtn.SearchCarInfo = this.GetCarInfoFromDic(this._beforeCarRelationGuid);
                }
            }

            //-----------------------------------------------------------------------------
            // 車両情報存在チェック
            //-----------------------------------------------------------------------------
            if (cndtn.SearchCarInfo == null) return -3;

            //-----------------------------------------------------------------------------
            // TBO検索
            //-----------------------------------------------------------------------------
            int status = this._salesSlipInputInitDataAcs.SearchTBO(cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList);
            }
            // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // 選択無し
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理
                    // ADD 2010/05/17 品名表示対応 ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._salesSlipInputInitDataAcs.GetSalesTtlSt());

                    // BL商品情報
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 品名表示対応 ----------<<<<<

                    //-----------------------------------------------------------------------------
                    // 部品検索データセットから選択情報の商品連結データオブジェクトを取得
                    //-----------------------------------------------------------------------------
                    goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));

                    //-----------------------------------------------------------------------------
                    // 商品連結データ不足情報設定
                    //-----------------------------------------------------------------------------
                    this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, this._salesSlip.ResultsAddUpSecCd);

                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // 該当データ無し
                    break;
            }
            return status;
        }

        /// <summary>
        /// 品番検索(商品情報一括取得)
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        /// <param name="goodsUnitDataListList">商品連結データリストリスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(SalesSlip salesSlip, List<SalesDetail> salesDetailList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            goodsUnitDataListList = new List<List<GoodsUnitData>>();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            msg = string.Empty;

            //-----------------------------------------------------------------------------
            // 商品検索条件オブジェクトリスト取得
            //-----------------------------------------------------------------------------
            this.GetGoodsCndtnList(salesSlip, salesDetailList, out goodsCndtnList);

            //-----------------------------------------------------------------------------
            // 品番検索(商品情報一括取得)
            //-----------------------------------------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            if ((goodsCndtnList != null) && (goodsCndtnList.Count != 0))
            {
                // UPD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
                //status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
                PartsInfoDataSet partsInfoDataSet = null;
                status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out partsInfoDataSet, out msg);
                // UPD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<

                switch ((ConstantManagement.MethodResult)status)
                {
                    case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理
                        //-----------------------------------------------------------------------------
                        // 商品情報キャッシュ
                        //-----------------------------------------------------------------------------
                        this.CacheGoodsUnitDataDic(goodsUnitDataListList);
                        // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
                        this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataListList);
                        // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<
                        break;
                    default:
                        break;
                }
            }
            return status;
        }

        /// <summary>
        /// 品番検索(商品情報一括取得)
        /// </summary>
        /// <param name="goodsUnitDataListList">商品連結データリストリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            return this.SearchPartsFromGoodsNoNonVariousSearchWholeWord(this._salesSlip, this._salesDetailDataTable, out goodsUnitDataListList, out msg);
        }

        /// <summary>
        /// 品番検索(商品情報一括取得)
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        /// <param name="goodsUnitDataListList">商品連結データリストリスト</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <br>Update Note: 2010/06/02 高峰 PM.NS障害・改良対応（７月リリース案件）No.2</br>
        /// <br>Update Note: 2012/04/09 yangmj Redmine#29313 売上伝票入力 商品価格の再取得で販売区分が初期値に戻る</br>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(SalesSlip salesSlip, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            goodsUnitDataListList = new List<List<GoodsUnitData>>();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            msg = string.Empty;

            //-----------------------------------------------------------------------------
            // 商品検索条件オブジェクトリスト取得
            //-----------------------------------------------------------------------------
            this.GetGoodsCndtnList(salesSlip, salesDetailDataTable, out goodsCndtnList);

            //-----------------------------------------------------------------------------
            // 品番検索(商品情報一括取得)
            //-----------------------------------------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            if ((goodsCndtnList != null) && (goodsCndtnList.Count != 0))
            {
                // UPD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
                //status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
                PartsInfoDataSet partsInfoDataSet = null;
                status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out partsInfoDataSet, out msg);
                // UPD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<

                switch ((ConstantManagement.MethodResult)status)
                {
                    case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理
                        //-----------------------------------------------------------------------------
                        // 商品情報キャッシュ
                        //-----------------------------------------------------------------------------
                        this.CacheGoodsUnitDataDic(goodsUnitDataListList);
                        // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
                        this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataListList);
                        // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<

                        //-----------------------------------------------------------------------------
                        // 明細情報更新
                        //-----------------------------------------------------------------------------
                        foreach (SalesInputDataSet.SalesDetailRow row in salesDetailDataTable)
                        {
                            if ((row.GoodsMakerCd == 0) || (string.IsNullOrEmpty(row.GoodsNo))) continue;
                            //>>>2010/10/01
                            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
                            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
                            //<<<2010/10/01
                            // --- ADD 2010/06/02 ---------->>>>>
                            goodsUnitData.GoodsName = row.GoodsName;
                            goodsUnitData.GoodsNameKana = row.GoodsName;
                            // --- ADD 2010/06/02 ----------<<<<<
                            //Stock stock = (goodsUnitData.SelectedWarehouseCode != null) ? this.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim()) : this.GetStock(goodsUnitData);
                            Stock stock = this.GetStock(goodsUnitData);
                            int targetSalesRowNo = row.SalesRowNo;
                            // 商品、在庫情報設定処理
                            //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, true, (int)SalesSlipCdDtl.Sales, SearchPartsMode.GoodsNoSearch);
                            //>>>2010/07/21
                            //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch);
                            if ((goodsUnitData.OfferKubun == 0) && (goodsUnitData.FileHeaderGuid == Guid.Empty))
                            {
                                // 空商品
                                // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
                                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch, true);
                                this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch, true, true);
                                // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
                            }
                            else
                            {
                                // 通常商品
                                // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
                                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch, false);
                                this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch, false, false);
                                // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
                            }
                            //<<<2010/07/21

                            // 受注情報再設定
                            if (row.AcceptAnOrderCntDisplay != 0)
                            {
                                // 受注情報設定
                                this.SettingSalesDetailAcceptAnOrder(row.SalesRowNo);
                                // 数量設定処理
                                this.SettingAcptAnOdrDetailRowShipmentCnt(row.SalesRowNo);
                            }
                        }
                        //--- ADD 2012/04/09 yangmj redmine#29313 ----->>>>>
                        if (_salesCodeChgFlag)
                        {
                            _salesCodeChgFlag = false;
                        }
                        //--- ADD 2012/04/09 yangmj redmine#29313 -----<<<<<
                        break;
                    default:
                        break;
                }
            }
            return status;
        }

        /// <summary>
        /// 品番検索(商品情報一括取得)
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="goodsMakerCdList">メーカーコードリスト</param>
        /// <param name="goodsNoList">品番リスト</param>
        /// <param name="goodsUnitDataListList">商品連結データリストリスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(SalesSlip salesSlip, List<int> goodsMakerCdList, List<string> goodsNoList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            goodsUnitDataListList = new List<List<GoodsUnitData>>();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            msg = string.Empty;

            //-----------------------------------------------------------------------------
            // 商品検索条件オブジェクトリスト取得
            //-----------------------------------------------------------------------------
            this.GetGoodsCndtnList(salesSlip, goodsMakerCdList, goodsNoList, out goodsCndtnList);

            //-----------------------------------------------------------------------------
            // 品番検索(商品情報一括取得)
            //-----------------------------------------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            if ((goodsCndtnList != null) && (goodsCndtnList.Count != 0))
            {
                // UPD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
                //status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
                PartsInfoDataSet partsInfoDataSet = null;
                status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out partsInfoDataSet, out msg);
                // UPD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<

                switch ((ConstantManagement.MethodResult)status)
                {
                    case ConstantManagement.MethodResult.ctFNC_NORMAL: // 通常処理
                        //-----------------------------------------------------------------------------
                        // 商品情報キャッシュ
                        //-----------------------------------------------------------------------------
                        this.CacheGoodsUnitDataDic(goodsUnitDataListList);
                        // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
                        this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataListList);
                        // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<
                        break;
                    default:
                        break;
                }
            }
            return status;
        }

        /// <summary>
        /// 商品検索条件オブジェクトリスト取得処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データオブジェクトリスト</param>
        /// <param name="goodsCndtnList">商品検索条件オブジェクトリスト</param>
        private void GetGoodsCndtnList(SalesSlip salesSlip, List<SalesDetail> salesDetailList, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                if ((salesDetail.GoodsMakerCd == 0) || (string.IsNullOrEmpty(salesDetail.GoodsNo))) continue;

                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = salesDetail.GoodsMakerCd;
                goodsCndtn.GoodsNo = salesDetail.GoodsNo;
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                goodsCndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
                goodsCndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
                goodsCndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
                goodsCndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
                goodsCndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
                goodsCndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
                goodsCndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
                goodsCndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
                // 優先倉庫リスト作成(得意先優先倉庫＋拠点優先倉庫)
                List<string> warehouseList = new List<string>();
                //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                goodsCndtn.ListPriorWarehouse = warehouseList;

                retGoodsCndtnList.Add(goodsCndtn);                
            }

            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// 商品検索条件オブジェクトリスト取得処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        /// <param name="goodsCndtnList">商品検索条件オブジェクトリスト</param>
        private void GetGoodsCndtnList(SalesSlip salesSlip, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            foreach (SalesInputDataSet.SalesDetailRow row in salesDetailDataTable)
            {
                if ((row.GoodsMakerCd == 0) || (string.IsNullOrEmpty(row.GoodsNo))) continue;

                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = row.GoodsMakerCd;
                goodsCndtn.GoodsNo = row.GoodsNo;
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                goodsCndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
                goodsCndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
                goodsCndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
                goodsCndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
                goodsCndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
                goodsCndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
                goodsCndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
                goodsCndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
                // 優先倉庫リスト作成(得意先優先倉庫＋拠点優先倉庫)
                List<string> warehouseList = new List<string>();
                //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                goodsCndtn.ListPriorWarehouse = warehouseList;

                retGoodsCndtnList.Add(goodsCndtn);
            }

            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// 商品検索条件オブジェクトリスト取得処理
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="goodsMakerCodeList"></param>
        /// <param name="goodsNoList"></param>
        /// <param name="goodsCndtnList"></param>
        private void GetGoodsCndtnList(SalesSlip salesSlip, List<int> goodsMakerCdList, List<string> goodsNoList, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            for (int index = 0; index < goodsNoList.Count; index++)
            {
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = goodsMakerCdList[index];
                goodsCndtn.GoodsNo = goodsNoList[index];
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                goodsCndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
                goodsCndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
                goodsCndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
                goodsCndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
                goodsCndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
                goodsCndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
                goodsCndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
                goodsCndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
                // 優先倉庫リスト作成(得意先優先倉庫＋拠点優先倉庫)
                List<string> warehouseList = new List<string>();
                //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                goodsCndtn.ListPriorWarehouse = warehouseList;

                retGoodsCndtnList.Add(goodsCndtn);
            }
            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// 商品連結リストリストから商品連結リストを取得
        /// </summary>
        /// <param name="goodsUnitDataListList"></param>
        /// <param name="goodsUnitDataList"></param>
        private void GetGoodsUnitDataListFromListList(List<List<GoodsUnitData>> goodsUnitDataListList, out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();
            if (goodsUnitDataListList == null) return;
            foreach (List<GoodsUnitData> tempGoodsUnitDataList in goodsUnitDataListList)
            {
                goodsUnitDataList.Add(tempGoodsUnitDataList[0]);
            }
        }

        // ADD 2010/05/17 品名表示対応 ---------->>>>>
        /// <summary>
        /// BL商品情報を取得します。
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BL商品情報</returns>
        private BLGoodsCdUMnt GetBLGoodsInfo(int blGoodsCode)
        {
            return this._salesSlipInputInitDataAcs.GetBLGoodsInfo_FromBLGoods(blGoodsCode);
        }
        // ADD 2010/05/17 品名表示対応 ----------<<<<<
        #endregion

        public void SalesDetailRowSalesUnitPriceSetting(int salesRowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
        }



        #region ●単価＆金額
        /// <summary>
        /// 指定した売単価の値を元に売上明細行オブジェクトの単価情報を設定します
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesUnitPriceInputType">売上単価入力モード</param>
        /// <param name="salesUnitPrice">売単価</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブルオブジェクト</param>
        /// <param name="inputPositionMode">入力位置モード</param>
        public void SalesDetailRowSalesUnitPriceSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitPrice, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable, int inputPositionMode)
        {
            #region ●初期処理
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // 変更前情報保持
            double svUnitPriceTaxInc = row.SalesUnPrcTaxIncFl;
            double svUnitPriceTaxExc = row.SalesUnPrcTaxExcFl;
            #endregion


            #region ●売上情報
            if (row != null)
            {
                // 非課税
                int taxationDivCd = row.TaxationDivCd;
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

                switch (salesUnitPriceInputType)
                {
                    // 売単価(税抜き)--->>>売価率入力から総額表示しない時のみコール
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.SalesUnPrcDisplay = salesUnitPrice;
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnPrcDisplay = salesUnitPrice;
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnPrcDisplay = salesUnitPrice; // 売単価(税抜)表示
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice;// 売単価単価(税抜)
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice;// 売単価単価(税込)
                                    break;
                            }
                            break;
                        }
                    // 売単価(税込み)--->>>売価率入力から総額表示する時のみコール
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnPrcDisplay = salesUnitPrice;
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnPrcDisplay = salesUnitPrice;
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                            }
                            break;
                        }
                    // 売単価(表示用)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                            {
                                //-----------------------------------------------------
                                // 総額表示しない
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // 総額表示する
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                }
                            }

                            //----------------------------------------------------------------------------
                            // 入力された単価と表示単価が異なった場合、売価率をクリア
                            //----------------------------------------------------------------------------
                            // 掛率算出されている場合or売価率が設定されている場合
                            if (!(string.IsNullOrEmpty(row.RateDivSalUnPrc)) || (row.SalesRate != 0))
                            {
                                //if (row.SalesRate != 0)
                                //{
                                //    this.CalculateUnitPriceByRate(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, out svUnitPriceTaxInc, out svUnitPriceTaxExc, out svUnitPriceDisplay);
                                //}

                                if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                                {
                                    //-----------------------------------------------------
                                    // 総額表示しない
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)taxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            if (svUnitPriceTaxExc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            if (svUnitPriceTaxExc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //-----------------------------------------------------
                                    // 総額表示する
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)taxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                    }
                                }
                            }

                            break;
                        }
                }

                // 売上単価変更区分設定
                if (row.SalesUnPrcTaxExcFl != row.BfSalesUnitPrice)
                {
                    row.SalesUnPrcChngCd = 1; // 変更あり
                }
                else
                {
                    row.SalesUnPrcChngCd = 0; // 変更なし
                }

                // 売上金額手入力区分
                if (inputPositionMode == 0) row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
            }
            #endregion

            #region ●受注情報
            if (acptAnOdrRow != null)
            {
                // 非課税
                int taxationDivCd = acptAnOdrRow.TaxationDivCd;
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

                switch (salesUnitPriceInputType)
                {
                    // 売単価(税抜き)--->>>売価率入力から総額表示しない時のみコール
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice; // 売単価(税抜)表示
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;// 売単価単価(税抜)
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;// 売単価単価(税込)
                                    break;
                            }
                            break;
                        }
                    // 売単価(税込み)--->>>売価率入力から総額表示する時のみコール
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                            }
                            break;
                        }
                    // 売単価(表示用)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                            {
                                //-----------------------------------------------------
                                // 総額表示しない
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // 総額表示する
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                }
                            }

                            //----------------------------------------------------------------------------
                            // 掛率算出されている場合
                            //----------------------------------------------------------------------------
                            if (!(string.IsNullOrEmpty(acptAnOdrRow.RateDivSalUnPrc)) || (acptAnOdrRow.SalesRate != 0))
                            {
                                if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                                {
                                    //-----------------------------------------------------
                                    // 総額表示しない
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)taxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxExc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxExc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                //>>>2010/07/29
                                                //row.SalesRate = 0;
                                                acptAnOdrRow.SalesRate = 0;
                                                //<<<2010/07/29
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxInc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxExc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxExc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //-----------------------------------------------------
                                    // 総額表示する
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)taxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxInc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxInc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxInc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                    }
                                }
                            }

                            break;
                        }
                }

                // 売上単価変更区分設定
                if (acptAnOdrRow.SalesUnPrcTaxExcFl != acptAnOdrRow.BfSalesUnitPrice)
                {
                    acptAnOdrRow.SalesUnPrcChngCd = 1; // 変更あり
                }
                else
                {
                    acptAnOdrRow.SalesUnPrcChngCd = 0; // 変更なし
                }

                // 売上金額手入力区分
                if (inputPositionMode == 0) acptAnOdrRow.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
            }
            #endregion
        }

        /// <summary>
        /// 掛率を使用して単価を算出します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        /// <br>Update Note: 2010/01/27 張凱 原価計算処理の不具合対応(４次改良)</br>
        /// <br>Update Note: 2010/03/12 李占川 redmine#3773 原価計算処理の不具合対応</br>
        /// <br>Update Note: 2010/03/22 李侠 redmine#4075 原価計算処理の不具合対応</br>
        private void CalculateUnitPriceByRate(SalesInputDataSet.SalesDetailRow row, UnitPriceCalculation.UnitPriceKind unitPriceKind, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            int frcProcCd = 0;          // 端数処理コード
            int fracProcDiv = 0;        // 端数処理区分
            double fracProcUnit = 0;    // 端数処理単位
            double rate = 0;            // 掛率
            double price = 0;           // 基準価格

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                #region ●原単価
                //------------------------------------------------------
                // 原単価
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    //------------------------------------------------------
                    // 基準価格×掛率
                    //------------------------------------------------------
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdUnCst)
                    {
                        //------------------------------------------------------
                        // 基準価格×掛率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitUnCst;
                            fracProcDiv = row.FracProcUnCst;
                            rate = row.CostRate;
                            price = row.StdUnPrcUnCst;
                            break;
                        default:
                            frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_SalesUnitCost, frcProcCd, 0, out fracProcUnit, out fracProcDiv);
                            rate = row.CostRate;
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // 外税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    // --- UPD 2010/01/27 -------------->>>>>
                                    //price = row.ListPriceTaxExcFl;
                                    // --- UPD 2010/03/12 -------------->>>>>
                                    //if (string.IsNullOrEmpty(row.RateDivLPrice))
                                    //{

                                    //    price = row.BfListPrice;
                                    //}
                                    //else
                                    //{
                                    //    price = row.StdUnPrcLPrice;
                                    //}

                                    // ListPriceChngCd が「1:変更あり」の場合
                                    if (row.ListPriceChngCd == 1)
                                    {
                                        price = row.ListPriceTaxExcFl;
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(row.RateDivLPrice))
                                        {
                                            // --- UPD 2010/03/22-------------->>>>>
                                            //price = row.BfListPrice;

                                            //変更前定価BfListPriceがゼロの場合、定価(税抜)(ListPriceTaxExcFl)を使用する
                                            if (row.BfListPrice == 0)
                                            {
                                                price = row.ListPriceTaxExcFl;
                                            }
                                            else
                                            {
                                                //>>>2010/11/19
                                                //price = row.BfListPrice;
                                                if (row.SelectedListPriceDiv == 1)
                                                {
                                                    // 標準価格選択で定価を選択した場合は、優良定価で原単価を算出
                                                    price = row.BfListPrice;
                                                }
                                                else
                                                {
                                                    // 標準価格選択で定価を選択していない場合は、画面定価で原単価を算出
                                                    price = row.ListPriceTaxExcFl;
                                                }
                                                //<<<2010/11/19
                                            }
                                            //--- UPD 2010/03/22 --------------<<<<<
                                        }
                                        else
                                        {
                                            // --- UPD 2010/03/22-------------->>>>>
                                            //price = row.StdUnPrcLPrice;

                                            //基準単価(定価)StdUnPrcLPriceがゼロの場合、基準単価(原価)StdUnPrcUnCstを使用する
                                            if (row.StdUnPrcLPrice == 0)
                                            {
                                                if (row.StdUnPrcUnCst == 0)
                                                {
                                                    price = row.ListPriceTaxExcFl;
                                                }
                                                else
                                                {
                                                    price = row.StdUnPrcUnCst;
                                                }   
                                            }
                                            else
                                            {
                                                price = row.StdUnPrcLPrice;
                                            }
                                            //--- UPD 2010/03/22 --------------<<<<<
                                        }                                        
                                    }
                                    // --- UPD 2010/03/12 --------------<<<<<
                                    // --- UPD 2010/01/27 --------------<<<<<
                                    break;
                                //------------------------------------------------------
                                // 内税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = row.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // 非課税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion

                #region ●売単価
                //------------------------------------------------------
                // 売単価
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc)
                    {
                        //------------------------------------------------------
                        // 基準価格×掛率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitSalUnPrc;
                            fracProcDiv = row.FracProcSalUnPrc;
                            rate = row.SalesRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 原単価×原価ＵＰ率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitSalUnPrc;
                            fracProcDiv = row.FracProcSalUnPrc;
                            rate = row.CostUpRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 原単価×(１－粗利率)
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitSalUnPrc;
                            fracProcDiv = row.FracProcSalUnPrc;
                            rate = row.GrossProfitSecureRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 単価直接指定
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitSalUnPrc;
                            fracProcDiv = row.FracProcSalUnPrc;
                            rate = row.SalesRate;
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // 外税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // 内税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = row.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // 非課税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion
            }

            // 非課税
            int taxationDivCd = row.TaxationDivCd;
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            int unPrcCalcCd = 0;
            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    unPrcCalcCd = row.UnPrcCalcCdUnCst;
                    break;
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    unPrcCalcCd = row.UnPrcCalcCdSalUnPrc;
                    break;
            }

            if (unPrcCalcCd != (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate)
            {
                this._unitPriceCalculation.CalculateUnitPriceByRate(unitPriceKind,
                                                                    (UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                    this._salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    this._salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            else
            {
                this._unitPriceCalculation.CalculateUnitPriceByMarginRate(unitPriceKind,
                                                                    //(UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                    this._salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    this._salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            if ((UnitPriceCalculation.UnitPriceKind)unitPriceKind != UnitPriceCalculation.UnitPriceKind.UnitCost)
            {
                // 「総額表示する」か、「内税商品」の場合は税込み単価を表示単価に設定
                if ((this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount) || (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc))
                {
                    unitPriceDisplay = unitPriceTaxInc;
                }
                else
                {
                    unitPriceDisplay = unitPriceTaxExc;
                }
            }
            else
            {
                if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    unitPriceDisplay = unitPriceTaxInc;
                }
                else
                {
                    unitPriceDisplay = unitPriceTaxExc;
                }
            }

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    row.FracProcUnitUnCst = fracProcUnit;
                    row.FracProcUnCst = fracProcDiv;
                    break;
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    row.FracProcUnitSalUnPrc = fracProcUnit;
                    row.FracProcSalUnPrc = fracProcDiv;
                    break;
            }
        }

        /// <summary>
        /// 掛率を使用して単価を算出します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="fracProcDiv"></param>
        /// <param name="fracProcUnit"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(SalesInputDataSet.SalesDetailRow row, UnitPriceCalculation.UnitPriceKind unitPriceKind, ref int fracProcDiv, ref double fracProcUnit, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            int frcProcCd = 0;          // 端数処理コード
            double rate = 0;            // 掛率
            double price = 0;           // 基準価格

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                #region ●原単価
                //------------------------------------------------------
                // 原単価
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    //------------------------------------------------------
                    // 端数処理区分、単位取得
                    //------------------------------------------------------
                    frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                    //------------------------------------------------------
                    // 基準価格×掛率
                    //------------------------------------------------------
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdUnCst)
                    {
                        //------------------------------------------------------
                        // 基準価格×掛率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            rate = row.CostRate;
                            price = row.StdUnPrcUnCst;
                            break;
                        default:
                            rate = row.CostRate;
                            price = row.ListPriceTaxExcFl;
                            break;
                    }
                    break;
                #endregion

                #region ●売単価
                //------------------------------------------------------
                // 売単価
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    //------------------------------------------------------
                    // 端数処理区分、単位取得
                    //------------------------------------------------------
                    frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc)
                    {
                        //------------------------------------------------------
                        // 基準価格×掛率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            rate = row.SalesRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 原単価×原価ＵＰ率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            rate = row.CostUpRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 原単価×(１－粗利率)
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            rate = row.GrossProfitSecureRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 単価直接指定
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        //    rate = 0;
                        //    price = 0;
                        //    break;
                        //default:
                            rate = row.SalesRate;
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // 外税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // 内税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = row.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // 非課税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion
            }

            // 非課税
            int taxationDivCd = row.TaxationDivCd;
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            // --- ADD 2010/07/29 ---------->>>>>
            if ((UnitPriceCalculation.UnitPriceKind)unitPriceKind == UnitPriceCalculation.UnitPriceKind.SalesUnitPrice &&
                 (UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc == UnitPriceCalculation.UnitPrcCalcDiv.Price)
            {
                // 単価直接指定の場合はそのままセット
                unitPriceTaxInc = row.SalesUnPrcTaxIncFl;
                unitPriceTaxExc = row.SalesUnPrcTaxExcFl;
            }
            else
            {
            // --- ADD 2010/07/29 ----------<<<<<

                int unPrcCalcCd = 0;
                switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
                {
                    case UnitPriceCalculation.UnitPriceKind.UnitCost:
                        unPrcCalcCd = row.UnPrcCalcCdUnCst;
                        break;
                    case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                        unPrcCalcCd = row.UnPrcCalcCdSalUnPrc;
                        break;
                }

                if (unPrcCalcCd != (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate)
                {
                    this._unitPriceCalculation.CalculateUnitPriceByRate(unitPriceKind,
                                                                        (UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                        this._salesSlip.TotalAmountDispWayCd,
                                                                        0,
                                                                        frcProcCd,
                                                                        taxationDivCd,
                                                                        price,
                                                                        this._salesSlip.ConsTaxRate,
                                                                        taxFracProcUnit,
                                                                        taxFracProcCd,
                                                                        rate,
                                                                        ref fracProcUnit,
                                                                        ref fracProcDiv,
                                                                        out unitPriceTaxExc,
                                                                        out unitPriceTaxInc);
                }
                else
                {
                    this._unitPriceCalculation.CalculateUnitPriceByMarginRate(unitPriceKind,
                        //(UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                        this._salesSlip.TotalAmountDispWayCd,
                                                                        0,
                                                                        frcProcCd,
                                                                        taxationDivCd,
                                                                        price,
                                                                        this._salesSlip.ConsTaxRate,
                                                                        taxFracProcUnit,
                                                                        taxFracProcCd,
                                                                        rate,
                                                                        ref fracProcUnit,
                                                                        ref fracProcDiv,
                                                                        out unitPriceTaxExc,
                                                                        out unitPriceTaxInc);
                }
            // --- 2010/07/29 ---------->>>>>
            }
            // --- 2010/07/29 ----------<<<<<

            // 「総額表示する」か、「内税商品」の場合は税込み単価を表示単価に設定
            if ((this._salesSlip.TotalAmountDispWayCd == 1) || (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc))
            {
                unitPriceDisplay = unitPriceTaxInc;
            }
            else
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
        }

        /// <summary>
        /// 掛率を使用して単価を算出します。（受注情報用）
        /// </summary>
        /// <param name="acptAnOdrRow"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow, UnitPriceCalculation.UnitPriceKind unitPriceKind, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(acptAnOdrRow, newSalesDetailRow);
            this.CalculateUnitPriceByRate(newSalesDetailRow, UnitPriceCalculation.UnitPriceKind.UnitCost, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
        }

        /// <summary>
        /// 掛率を使用して単価を算出します。（受注情報用）
        /// </summary>
        /// <param name="acptAnOdrRow"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="fracProcDiv"></param>
        /// <param name="fracProcUnit"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow, UnitPriceCalculation.UnitPriceKind unitPriceKind, ref int fracProcDiv, ref double fracProcUnit, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(acptAnOdrRow, newSalesDetailRow);
            // --- UPD 2012/10/31 T.Nishi ---------->>>>>
            //this.CalculateUnitPriceByRate(newSalesDetailRow, UnitPriceCalculation.UnitPriceKind.UnitCost, ref fracProcDiv, ref fracProcUnit, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
            this.CalculateUnitPriceByRate(newSalesDetailRow, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, ref fracProcDiv, ref fracProcUnit, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
            // --- UPD 2012/10/31 T.Nishi ----------<<<<<
        }

        /// <summary>
        /// 指定した売単価の値を元に売上明細行オブジェクトの単価情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesUnitPriceInputType">売上単価入力モード</param>
        /// <param name="salesUnitPrice">売単価</param>
        /// <param name="inputPositionMode">入力位置モード(0:売単価 1:その他)</param>
        /// <remarks>
        /// <br>Call：商品検索、売単価／原単価／原価率 変更時</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitPrice, int inputPositionMode)
        {
            this.SalesDetailRowSalesUnitPriceSetting(salesRowNo, salesUnitPriceInputType, salesUnitPrice, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable, inputPositionMode);
        }

        /// <summary>
        /// 基準単価、掛率を元に売上明細行オブジェクトおよび受注明細行オブジェクトの単価情報を再設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブルオブジェクト</param>
        /// <remarks>
        /// <br>Call：定価／原単価／原価率 変更時(売単価算出の基準単価変更時)</br>
        /// <br>UpdateNote : 2011/08/12 譚洪 Redmine#23554 キャンペーンの売価「売価率、値引率、売価額」が設定されている場合は、掛率マスタの売価の設定をクリアするように仕様変更の対応</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceReSetting(int salesRowNo, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ●初期処理
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // 端数処理区分、端数処理単位
            int fracProcSalUnPrc = 0;
            double fracProcUnitSalUnPrc = 0;

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int fracProcCd;
            double fracProcUnit;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);
            this._salesSlip.FractionProcCd = fracProcCd;

            double unitPriceTaxExc = 0;
            double unitPriceTaxInc = 0;
            double unitPriceDisplay = 0;
            #endregion

            #region ●売上情報

            // 掛率算出されている場合、再設定
            // UPD 2011/08/12 ---- >>>>>>>
            //if ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))
            if (((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0)) && this._campaignObjGoodsSt == null)
            // UPD 2011/08/12 ---- <<<<<<<
            {
                fracProcSalUnPrc = row.FracProcSalUnPrc;
                fracProcUnitSalUnPrc = row.FracProcUnitSalUnPrc;

                this.CalculateUnitPriceByRate(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, ref fracProcSalUnPrc, ref fracProcUnitSalUnPrc, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);

                row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;
                row.FracProcSalUnPrc = fracProcSalUnPrc;
                row.SalesUnPrcTaxExcFl = unitPriceTaxExc;
                row.SalesUnPrcTaxIncFl = unitPriceTaxInc;
                row.SalesUnPrcDisplay = unitPriceDisplay;
            }

            #endregion

            #region ●受注情報
            if (acptAnOdrRow != null)
            {
                // 掛率算出されている場合、再設定
                if ((!string.IsNullOrEmpty(acptAnOdrRow.RateDivSalUnPrc.Trim())) || (acptAnOdrRow.StdUnPrcSalUnPrc != 0))
                {
                    fracProcSalUnPrc = acptAnOdrRow.FracProcSalUnPrc;
                    fracProcUnitSalUnPrc = acptAnOdrRow.FracProcUnitSalUnPrc;
                    this.CalculateUnitPriceByRate(acptAnOdrRow, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, ref fracProcSalUnPrc, ref fracProcUnitSalUnPrc, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);

                    acptAnOdrRow.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;
                    acptAnOdrRow.FracProcSalUnPrc = fracProcSalUnPrc;
                    acptAnOdrRow.SalesUnPrcTaxExcFl = unitPriceTaxExc;
                    acptAnOdrRow.SalesUnPrcTaxIncFl = unitPriceTaxInc;
                    acptAnOdrRow.SalesUnPrcDisplay = unitPriceDisplay;
                }
            }
            #endregion
        }

        /// <summary>
        /// 基準単価、掛率を元に売上明細行オブジェクトの単価情報を再設定します。（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <remarks>
        /// <br>Call：定価／原単価／原価率 変更時(売単価算出の基準単価変更時)</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceReSetting(int salesRowNo)
        {
            this.SalesDetailRowSalesUnitPriceReSetting(salesRowNo, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 指定した売価率の値を元に売上明細行オブジェクトの売単価情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesRate">売価率</param>
        /// <param name="clearCalculateUnitInfoFlg">掛率算出情報クリアフラグ(true:クリアする false:クリアしない)</param>
        /// <remarks>
        /// <br>Call：定価／売価率 変更時</br>
        /// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceSettingbyRate(int salesRowNo, double salesRate, bool clearCalculateUnitInfoFlg)
        {

            double salesUnPrcTaxExcFl;
            double salesUnPrcTaxIncFl;
            double salesUnPrcDisplay;

            #region ●売上情報
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row == null) return;

            row.SalesRate = salesRate;

            if (clearCalculateUnitInfoFlg == true)
            {
                // 掛率算出情報クリア
                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            }
            // --- UPD 2009/10/19 ---------->>>>>
            if (salesRate != 0)
            {
            this.CalclateSalesUnitPrice(row, out salesUnPrcDisplay, out salesUnPrcTaxIncFl, out salesUnPrcTaxExcFl);

            row.SalesUnPrcDisplay = salesUnPrcDisplay;
            row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;

            // 売上単価変更区分設定
            if (row.SalesUnPrcTaxExcFl != row.BfSalesUnitPrice)
            {
                row.SalesUnPrcChngCd = 1; // 変更あり
            }
            else
            {
                row.SalesUnPrcChngCd = 0; // 変更なし
            }
            }
            // --- UPD 2009/10/19 ----------<<<<<

            row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
            #endregion

            #region ●受注情報
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);
            if (acptAnOdrRow == null) return;

            acptAnOdrRow.SalesRate = salesRate;

            if (clearCalculateUnitInfoFlg == true)
            {
                // 掛率算出情報クリア
                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            }

            // --- UPD 2009/10/19 ---------->>>>>
            if (salesRate != 0)
            {
            this.CalclateSalesUnitPrice(acptAnOdrRow, out salesUnPrcDisplay, out salesUnPrcTaxIncFl, out salesUnPrcTaxExcFl);

            acptAnOdrRow.SalesUnPrcDisplay = salesUnPrcDisplay;
            acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;

            // 売上単価変更区分設定
            if (acptAnOdrRow.SalesUnPrcTaxExcFl != acptAnOdrRow.BfSalesUnitPrice)
            {
                acptAnOdrRow.SalesUnPrcChngCd = 1; // 変更あり
            }
            else
            {
                acptAnOdrRow.SalesUnPrcChngCd = 0; // 変更なし
            }
            }
            // --- UPD 2009/10/19 ----------<<<<<

            acptAnOdrRow.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
            #endregion

        }

        /// <summary>
        /// 売価率を使用して定価から売単価情報を算出します。
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="unitPriceDisplay">売単価(表示)</param>
        /// <param name="unitPriceTaxInc">売単価(税込)</param>
        /// <param name="unitPriceTaxExc">売単価(税抜)</param>
        private void CalclateSalesUnitPrice(SalesInputDataSet.SalesDetailRow row, out double unitPriceDisplay, out double unitPriceTaxInc, out double unitPriceTaxExc)
        {
            unitPriceDisplay = 0;
            unitPriceTaxInc = 0;
            unitPriceTaxExc = 0;
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd); // 売上消費税端数処理コード
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            this.CalculateUnitPriceByRate(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
        }

        /// <summary>
        /// 売価率を使用して定価から売単価情報を算出します。（受注情報用）
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="unitPriceDisplay">売単価(表示)</param>
        /// <param name="unitPriceTaxInc">売単価(税込)</param>
        /// <param name="unitPriceTaxExc">売単価(税抜)</param>
        private void CalclateSalesUnitPrice(SalesInputDataSet.SalesDetailAcceptAnOrderRow row, out double unitPriceDisplay, out double unitPriceTaxInc, out double unitPriceTaxExc)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(row, newSalesDetailRow);
            CalclateSalesUnitPrice(newSalesDetailRow, out unitPriceDisplay, out unitPriceTaxInc, out unitPriceTaxExc);
        }

        /// <summary>
        /// 指定した原単価の値を元に売上明細行オブジェクトの原単価情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesUnitPriceInputType">単価入力モード</param>
        /// <param name="salesUnitCost">原単価</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <remarks>
        /// <br>Call：商品検索、原単価／仕入率 変更時</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitCostSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitCost, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ●初期処理
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // 消費税端数処理コード
            int taxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);

            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            double svUnitCostTaxInc = row.SalesUnitCostTaxInc;
            double svUnitCostTaxExc = row.SalesUnitCostTaxExc;
            #endregion

            #region ●売上情報
            if (row != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // 原単価(税抜き)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.SalesUnitCost = salesUnitCost;           // 原価表示
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    row.SalesUnitCostTaxInc = salesUnitCost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnitCost = salesUnitCost;           // 原価表示
                                    row.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税抜)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnitCost = salesUnitCost;           // 原価表示
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                            }
                            break;
                        }
                    // 原単価(税込み)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {

                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnitCost = salesUnitCost;           // 原価表示
                                    row.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税抜)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnitCost = salesUnitCost;           // 原価表示
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                            }
                            break;
                        }
                    // 原単価(表示用)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    row.SalesUnitCostTaxInc = salesUnitCost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税抜)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                            }

                            //----------------------------------------------------------------------------
                            // 掛率算出されている場合
                            //----------------------------------------------------------------------------
                            if ((!string.IsNullOrEmpty(row.RateDivUnCst)) || (row.CostRate != 0))
                            //if (((!string.IsNullOrEmpty(row.RateDivUnCst)) || (row.CostRate != 0)) && this._campaignObjGoodsSt == null)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        if (svUnitCostTaxExc != row.SalesUnitCost)
                                        {
                                            // 掛率算出情報クリア
                                            this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            row.CostRate = 0;
                                        }
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        if (svUnitCostTaxInc != row.SalesUnitCost)
                                        {
                                            // 掛率算出情報クリア
                                            this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            row.CostRate = 0;
                                        }
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        if (svUnitCostTaxExc != row.SalesUnitCost)
                                        {
                                            // 掛率算出情報クリア
                                            this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            row.CostRate = 0;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                }

                // 基準単価(売上単価)設定
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc)
                {
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        break;
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        row.StdUnPrcSalUnPrc = salesUnitCost; // 基準価格(売単価)
                        break;
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        row.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // 原価単価変更区分設定
                if (salesUnitCost != row.BfUnitCost)
                {
                    row.SalesUnitCostChngDiv = 1; // 変更あり
                }
                else
                {
                    row.SalesUnitCostChngDiv = 0; // 変更なし
                }
            }
            #endregion

            #region ●受注情報
            if (acptAnOdrRow != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // 原単価(税抜き)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // 原価表示
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // 原価表示
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税抜)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // 原価表示
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                            }
                            break;
                        }
                    // 原単価(税込み)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {

                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // 原価表示
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税抜)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // 原価表示
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                            }
                            break;
                        }
                    // 原単価(表示用)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // 原価表示
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // 原価表示
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // 原価(税抜)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // 原価表示
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // 原価(税抜)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // 原価(税込)
                                    break;
                            }

                            //----------------------------------------------------------------------------
                            // 掛率算出されている場合
                            //----------------------------------------------------------------------------
                            if ((!string.IsNullOrEmpty(acptAnOdrRow.RateDivUnCst)) || (acptAnOdrRow.CostRate != 0))
                            {
                                switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        if (svUnitCostTaxExc != acptAnOdrRow.SalesUnitCost)
                                        {
                                            // 掛率算出情報クリア
                                            this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            acptAnOdrRow.CostRate = 0;
                                        }
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        if (svUnitCostTaxInc != acptAnOdrRow.SalesUnitCost)
                                        {
                                            // 掛率算出情報クリア
                                            this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            acptAnOdrRow.CostRate = 0;
                                        }
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        if (svUnitCostTaxExc != acptAnOdrRow.SalesUnitCost)
                                        {
                                            // 掛率算出情報クリア
                                            this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            acptAnOdrRow.CostRate = 0;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                }

                // 基準単価(売上単価)設定
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)acptAnOdrRow.UnPrcCalcCdSalUnPrc)
                {
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        break;
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        acptAnOdrRow.StdUnPrcSalUnPrc = salesUnitCost; // 基準価格(売単価)
                        break;
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        acptAnOdrRow.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // 原価単価変更区分設定
                if (salesUnitCost != acptAnOdrRow.BfUnitCost)
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 1; // 変更あり
                }
                else
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 0; // 変更なし
                }
            }
            #endregion
        }

        /// <summary>
        /// 指定した原単価の値を元に売上明細行オブジェクトの原単価情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesUnitPriceInputType">入力モード</param>
        /// <param name="salesUnitCost">原単価</param>
        /// <remarks>
        /// <br>Call：商品検索、原単価／仕入率 変更時</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitCostSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitCost)
        {
            this.SalesDetailRowSalesUnitCostSetting(salesRowNo, salesUnitPriceInputType, salesUnitCost, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 指定した原価率の値を元に売上明細行オブジェクトの原価情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="costRate">原価率</param>
        /// <param name="clearCalculateUnitInfoFlg">掛率算出情報クリアフラグ(true:クリアする false:クリアしない)</param>
        /// <remarks>
        /// <br>Call：定価／原価率 変更時</br>
        /// <br>Update Note: 2009/10/19 張凱 保守依頼②機能対応</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitCostSettingbyRate(int salesRowNo, double costRate, bool clearCalculateUnitInfoFlg)
        {
            double salesUnitCost;
            double SalesUnitCostTaxInc;
            double SalesUnitCostTaxExc;

            #region ●売上情報
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            row.CostRate = costRate;

            if (clearCalculateUnitInfoFlg == true)
            {
                // 掛率算出情報クリア
                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
            }

            // --- UPD 2009/10/19 ---------->>>>>
            if (costRate != 0)
            {
            this.CalclateSalesUnitCost(row, out salesUnitCost, out SalesUnitCostTaxInc, out SalesUnitCostTaxExc);

            row.SalesUnitCost = salesUnitCost;
            row.SalesUnitCostTaxExc = SalesUnitCostTaxExc;
            row.SalesUnitCostTaxInc = SalesUnitCostTaxInc;

            // 原価単価変更区分設定
            if (row.SalesUnitCostTaxExc != row.BfUnitCost)
            {
                row.SalesUnitCostChngDiv = 1; // 変更あり
            }
            else
            {
                row.SalesUnitCostChngDiv = 0; // 変更なし
            }
            }
            // --- UPD 2009/10/19 ----------<<<<<
            #endregion

            #region ●受注情報
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);
            if (acptAnOdrRow != null)
            {
                acptAnOdrRow.CostRate = costRate;

                if (clearCalculateUnitInfoFlg == true)
                {
                    // 掛率算出情報クリア
                    this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                }

                // --- UPD 2009/10/19 ---------->>>>>
                if (costRate != 0)
                {
                this.CalclateSalesUnitCost(acptAnOdrRow, out salesUnitCost, out SalesUnitCostTaxInc, out SalesUnitCostTaxExc);

                acptAnOdrRow.SalesUnitCost = salesUnitCost;
                acptAnOdrRow.SalesUnitCostTaxExc = SalesUnitCostTaxExc;
                acptAnOdrRow.SalesUnitCostTaxInc = SalesUnitCostTaxInc;

                // 原価単価変更区分設定
                if (acptAnOdrRow.SalesUnitCostTaxExc != acptAnOdrRow.BfUnitCost)
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 1; // 変更あり
                }
                else
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 0; // 変更なし
                }
            }
                // --- UPD 2009/10/19 ----------<<<<<
            }
            #endregion
        }

        /// <summary>
        /// 原価率を使用して定価から原価価情報を算出します。
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="unitPriceDisplay">売単価(表示)</param>
        /// <param name="unitPriceTaxInc">売単価(税込)</param>
        /// <param name="unitPriceTaxExc">売単価(税抜)</param>
        private void CalclateSalesUnitCost(SalesInputDataSet.SalesDetailRow row, out double unitCost, out double unitCostTaxInc, out double unitCostTaxExc)
        {
            unitCost = 0;
            unitCostTaxInc = 0;
            unitCostTaxExc = 0;

            // 消費税端数処理コード(ゼロ固定)
            int taxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);

            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            CalculateUnitPriceByRate(row, UnitPriceCalculation.UnitPriceKind.UnitCost, out unitCostTaxInc, out unitCostTaxExc, out unitCost);
        }

        /// <summary>
        /// 原価率を使用して定価から原価価情報を算出します。（受注情報用）
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="unitPriceDisplay">売単価(表示)</param>
        /// <param name="unitPriceTaxInc">売単価(税込)</param>
        /// <param name="unitPriceTaxExc">売単価(税抜)</param>
        private void CalclateSalesUnitCost(SalesInputDataSet.SalesDetailAcceptAnOrderRow row, out double unitCost, out double unitCostTaxInc, out double unitCostTaxExc)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(row, newSalesDetailRow);
            CalclateSalesUnitCost(newSalesDetailRow, out unitCost, out unitCostTaxInc, out unitCostTaxExc);
        }

        /// <summary>
        /// 指定した定価の値を元に売上明細行オブジェクトの定価情報を設定します
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesUnitPriceInputType">売上単価入力モード</param>
        /// <param name="listPrice">定価</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <br>Update Note: 2010/01/27 張凱 原価計算処理の不具合対応(４次改良)</br>
        /// <br>Update Note: 2010/03/22 李侠 標準価格選択ウインドウより、標準価格を選択した場合、定価変更区分(ListPriceChngCd)を「0:変更無し」をセットする</br>
        /// <br>Update Note: 2011/12/28 凌小青</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27385　基準価格の対応</br>
        private void SalesDetailRowListPriceSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double listPrice, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable sales)
        {
            #region ●初期処理
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // 消費税端数処理コード(ゼロ固定)
            int salesCnsTaxFrcProcCd = 0;

            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            double svListPriceTaxInc = row.ListPriceTaxIncFl;
            double svListPriceTaxExc = row.ListPriceTaxExcFl;
            #endregion

            #region ●売上情報
            if (row != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // 売単価(税抜き)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.ListPriceDisplay = listPrice;      // 定価表示
                                    row.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                    row.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.ListPriceDisplay = listPrice;      // 定価表示
                                    row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                    row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.ListPriceDisplay = listPrice;      // 定価表示
                                    row.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                    row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                            }
                            break;
                        }
                    // 売単価(税込み)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.ListPriceDisplay = listPrice;      // 定価表示
                                    row.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                    row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.ListPriceDisplay = listPrice;      // 定価表示
                                    row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                    row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.ListPriceDisplay = listPrice;      // 定価表示
                                    row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                    row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                            }
                            break;
                        }
                    // 売単価(表示用)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                //-----------------------------------------------------
                                // 総額表示しない
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                        row.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                        row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                        row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // 総額表示する
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                        row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                        row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                        row.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                }
                            }

                            //----------------------------------------------------------------------------
                            // 掛率算出されている場合
                            //----------------------------------------------------------------------------
                            if (!(string.IsNullOrEmpty(row.RateDivLPrice)) || (row.ListPriceRate != 0))
                            {
                                if (this._salesSlip.TotalAmountDispWayCd == 0)
                                {
                                    //-----------------------------------------------------
                                    // 総額表示しない
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            if (svListPriceTaxExc != row.ListPriceDisplay)
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            if (svListPriceTaxExc != row.ListPriceDisplay)
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //-----------------------------------------------------
                                    // 総額表示する
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        }
                }

                // 基準単価(定価)設定
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdLPrice)
                {
                    // 掛率
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        row.StdUnPrcLPrice = listPrice;
                        break;
                    // 原価ＵＰ率
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // 粗利確保率
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // 単価手入力or画面手入力
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        row.StdUnPrcLPrice = 0;
                        break;
                }

                // 基準単価(売上単価)設定
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc)
                {
                    // 掛率
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        row.StdUnPrcSalUnPrc = listPrice;
                        break;
                    // 原価ＵＰ率
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // 粗利確保率
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // 単価手入力or画面手入力
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        row.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // 基準単価(原価単価)設定
                if (row.SelectedListPriceDiv == 0) //ADD BY 凌小青 on 2011/12/28 for Redmine#27385
                {///ADD BY 凌小青 on 2011/12/28 for Redmine#27385
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdUnCst)
                    {
                        // 掛率
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            row.StdUnPrcUnCst = listPrice;
                            break;
                        // 原価ＵＰ率
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            break;
                        // 粗利確保率
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            break;
                        // 単価手入力or画面手入力
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            row.StdUnPrcUnCst = 0;
                            break;
                    }
                }//ADD BY 凌小青 on 2011/12/28 for Redmine#27385

                // --- UPD 2010/03/22 ---------->>>>>
                // 標準価格選択ウインドウより、標準価格を選択した場合、定価変更区分(ListPriceChngCd)を「0:変更無し」をセットする
                if (row.SelectedListPriceDiv == 1)
                {
                    //// 定価変更区分設定
                    //if (row.ListPriceTaxExcFl != row.BfListPrice)
                    //{
                    //    row.ListPriceChngCd = 1; // 変更あり
                    //}
                    //else
                    //{
                    //    row.ListPriceChngCd = 0; // 変更なし
                    //} 
                    row.ListPriceChngCd = 0; // 変更なし
                }
                // --- UPD 2010/03/22 ----------<<<<<

            }
            #endregion

            #region ●受注情報
            if (acptAnOdrRow != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // 売単価(税抜き)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // 定価表示
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // 定価表示
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // 定価表示
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                            }
                            break;
                        }
                    // 売単価(税込み)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // 定価表示
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // 定価表示
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // 定価表示
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                            }
                            break;
                        }
                    // 売単価(表示用)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                //-----------------------------------------------------
                                // 総額表示しない
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // 総額表示する
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                }
                            }

                            //----------------------------------------------------------------------------
                            // 掛率算出されている場合
                            //----------------------------------------------------------------------------
                            if (!(string.IsNullOrEmpty(acptAnOdrRow.RateDivLPrice)) || (acptAnOdrRow.ListPriceRate != 0))
                            {
                                if (this._salesSlip.TotalAmountDispWayCd == 0)
                                {
                                    //-----------------------------------------------------
                                    // 総額表示しない
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxExc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxExc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxInc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxExc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxExc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //-----------------------------------------------------
                                    // 総額表示する
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxInc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // 掛率算出情報クリア
                                                acptAnOdrRow.ListPriceRate = 0;
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxInc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxInc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // 掛率算出情報クリア
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        }
                }

                // 基準単価(定価)設定
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)acptAnOdrRow.UnPrcCalcCdLPrice)
                {
                    // 掛率
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        acptAnOdrRow.StdUnPrcLPrice = listPrice;
                        break;
                    // 原価ＵＰ率
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // 粗利確保率
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // 単価手入力or画面手入力
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        acptAnOdrRow.StdUnPrcLPrice = 0;
                        break;
                }

                // 基準単価(売上単価)設定
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)acptAnOdrRow.UnPrcCalcCdSalUnPrc)
                {
                    // 掛率
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        acptAnOdrRow.StdUnPrcSalUnPrc = listPrice;
                        break;
                    // 原価ＵＰ率
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // 粗利確保率
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // 単価手入力or画面手入力
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        acptAnOdrRow.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // 基準単価(原価単価)設定
                if (row.SelectedListPriceDiv == 0) //ADD BY 凌小青 on 2011/12/28 for Redmine#27385
                { //ADD BY 凌小青 on 2011/12/28 for Redmine#27385
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)acptAnOdrRow.UnPrcCalcCdUnCst)
                    {
                        // 掛率
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            acptAnOdrRow.StdUnPrcUnCst = listPrice;
                            break;
                        // 原価ＵＰ率
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            break;
                        // 粗利確保率
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            break;
                        // 単価手入力or画面手入力
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            acptAnOdrRow.StdUnPrcUnCst = 0;
                            break;
                    }
                } //ADD BY 凌小青 on 2011/12/28 for Redmine#27385
                // 定価変更区分設定
                if (acptAnOdrRow.ListPriceTaxExcFl != acptAnOdrRow.BfListPrice)
                {
                    acptAnOdrRow.ListPriceChngCd = 1; // 変更あり
                }
                else
                {
                    acptAnOdrRow.ListPriceChngCd = 0; // 変更なし
                }

            }
            #endregion
        }

        /// <summary>
        /// 指定した定価の値を元に売上明細行オブジェクトの定価情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesUnitPriceInputType">売上単価入力モード</param>
        /// <param name="listPrice">定価</param>
        public void SalesDetailRowListPriceSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double listPrice)
        {
            this.SalesDetailRowListPriceSetting(salesRowNo, salesUnitPriceInputType, listPrice, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 売上合計金額設定処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        public void TotalPriceSetting(ref SalesSlip salesSlip)
        {
            this.TotalPriceSetting(ref salesSlip, this._salesDetailDataTable);
        }

        /// <summary>
        /// 売上合計金額設定処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        public void TotalPriceSetting(ref SalesSlip salesSlip, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable)
        {
            if (salesSlip == null) return;
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 消費税端数処理コード

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
            long salesPrtTotalTaxInc = 0;   // 売上部品合計（税込）
            long salesPrtTotalTaxExc = 0;   // 売上部品合計（税抜）
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
                salesDetailDataTable,
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
                out totalMoneyForGrossProfit,
                out salesPrtTotalTaxInc,
                out salesPrtTotalTaxExc);

            switch ((SalesGoodsCd)salesSlip.SalesGoodsCd)
            {
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                    {

                        salesSlip.SalesSubtotalTaxInc = 0;              // 売上小計（税込）
                        salesSlip.SalesSubtotalTaxExc = 0;              // 売上小計（税抜）
                        salesSlip.SalesSubtotalTax = taxAdjust;         // 売上小計（税）
                        salesSlip.ItdedSalesOutTax = 0;                 // 売上外税対象額
                        salesSlip.ItdedSalesInTax = 0;                  // 売上内税対象額
                        salesSlip.SalSubttlSubToTaxFre = 0;             // 売上小計非課税対象額
                        salesSlip.SalesOutTax = 0;                      // 売上金額消費税額（外税）
                        salesSlip.SalAmntConsTaxInclu = 0;              // 売上金額消費税額（内税）
                        salesSlip.SalesDisTtlTaxExc = 0;                // 売上値引金額計（税抜）
                        salesSlip.ItdedSalesDisOutTax = 0;              // 売上値引外税対象額合計
                        salesSlip.ItdedSalesDisInTax = 0;               // 売上値引内税対象額合計
                        salesSlip.ItdedSalesDisTaxFre = 0;              // 売上値引非課税対象額合計
                        salesSlip.SalesDisOutTax = 0;                   // 売上値引消費税額（外税）
                        salesSlip.SalesDisTtlTaxInclu = 0;              // 売上値引消費税額（内税）
                        salesSlip.TotalCost = 0;                        // 原価金額計
                        salesSlip.StockGoodsTtlTaxExc = 0;              // 在庫商品合計金額（税抜）
                        salesSlip.PureGoodsTtlTaxExc = 0;               // 純正商品合計金額（税抜）
                        salesSlip.SalesPrtSubttlInc = 0;                // 売上部品小計（税込）
                        salesSlip.SalesPrtSubttlExc = 0;                // 売上部品小計（税抜）
                        salesSlip.SalesWorkSubttlInc = 0;               // 売上作業小計（税込）
                        salesSlip.SalesWorkSubttlExc = 0;               // 売上作業小計（税抜）
                        salesSlip.ItdedPartsDisInTax = 0;               // 部品値引対象額合計（税込）
                        salesSlip.ItdedPartsDisOutTax = 0;              // 部品値引対象額合計（税抜）
                        salesSlip.ItdedWorkDisInTax = 0;                // 作業値引対象額合計（税込）
                        salesSlip.ItdedWorkDisOutTax = 0;               // 作業値引対象額合計（税抜）
                        salesSlip.TotalMoneyForGrossProfit = 0;         // 粗利計算用売上金額

                        salesSlip.SalesTotalTaxInc = 0;                 // 売上伝票合計（税込）
                        salesSlip.SalesTotalTaxExc = 0;                 // 売上伝票合計（税抜）
                        salesSlip.SalesNetPrice = 0;                    // 売上正価金額
                        salesSlip.AccRecConsTax = 0;                    // 売掛消費税
                        salesSlip.PartsDiscountRate = 0;                // 部品値引率
                        break;
                    }
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    {
                        salesSlip.SalesSubtotalTaxInc = 0;              // 売上小計（税込）
                        salesSlip.SalesSubtotalTaxExc = 0;              // 売上小計（税抜）
                        salesSlip.SalesSubtotalTax = 0;                 // 売上小計（税）
                        salesSlip.ItdedSalesOutTax = 0;                 // 売上外税対象額
                        salesSlip.ItdedSalesInTax = 0;                  // 売上内税対象額
                        salesSlip.SalSubttlSubToTaxFre = 0;             // 売上小計非課税対象額
                        salesSlip.SalesOutTax = 0;                      // 売上金額消費税額（外税）
                        salesSlip.SalAmntConsTaxInclu = 0;              // 売上金額消費税額（内税）
                        salesSlip.SalesDisTtlTaxExc = 0;                // 売上値引金額計（税抜）
                        salesSlip.ItdedSalesDisOutTax = 0;              // 売上値引外税対象額合計
                        salesSlip.ItdedSalesDisInTax = 0;               // 売上値引内税対象額合計
                        salesSlip.ItdedSalesDisTaxFre = 0;              // 売上値引非課税対象額合計
                        salesSlip.SalesDisOutTax = 0;                   // 売上値引消費税額（外税）
                        salesSlip.SalesDisTtlTaxInclu = 0;              // 売上値引消費税額（内税）
                        salesSlip.TotalCost = 0;                        // 原価金額計
                        salesSlip.StockGoodsTtlTaxExc = 0;              // 在庫商品合計金額（税抜）
                        salesSlip.PureGoodsTtlTaxExc = 0;               // 純正商品合計金額（税抜）
                        salesSlip.SalesPrtSubttlInc = 0;                // 売上部品小計（税込）
                        salesSlip.SalesPrtSubttlExc = 0;                // 売上部品小計（税抜）
                        salesSlip.SalesWorkSubttlInc = 0;               // 売上作業小計（税込）
                        salesSlip.SalesWorkSubttlExc = 0;               // 売上作業小計（税抜）
                        salesSlip.ItdedPartsDisInTax = 0;               // 部品値引対象額合計（税込）
                        salesSlip.ItdedPartsDisOutTax = 0;              // 部品値引対象額合計（税抜）
                        salesSlip.ItdedWorkDisInTax = 0;                // 作業値引対象額合計（税込）
                        salesSlip.ItdedWorkDisOutTax = 0;               // 作業値引対象額合計（税抜）
                        salesSlip.TotalMoneyForGrossProfit = 0;         // 粗利計算用売上金額

                        salesSlip.SalesTotalTaxInc = balanceAdjust;     // 売上伝票合計（税込）
                        salesSlip.SalesTotalTaxExc = 0;                 // 売上伝票合計（税抜）
                        salesSlip.SalesNetPrice = 0;                    // 売上正価金額
                        salesSlip.AccRecConsTax = 0;                    // 売掛消費税
                        salesSlip.PartsDiscountRate = 0;                // 部品値引率
                        break;
                    }
                case SalesGoodsCd.Goods:
                    {
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
                        salesSlip.TotalMoneyForGrossProfit = totalMoneyForGrossProfit;  // 粗利計算用売上金額

                        salesSlip.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;                   // 売上伝票合計（税込）= 売上伝票合計（税込） + 売上小計非課税対象額
                        salesSlip.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;                   // 売上伝票合計（税抜）= 売上伝票合計（税抜） + 売上小計非課税対象額
                        salesSlip.SalesNetPrice = itdedSalesOutTax + itdedSalesInTax + salSubttlSubToTaxFre;    // 売上正価金額 = 売上外税対象額 + 売上内税対象額 + 売上小計非課税対象額
                        salesSlip.AccRecConsTax = salesSubtotalTax;                                             // 売掛消費税
                        salesSlip.SalesPrtTotalTaxInc = salesPrtTotalTaxInc;                                    // 売上部品合計（税込）
                        salesSlip.SalesPrtTotalTaxExc = salesPrtTotalTaxExc;                                    // 売上部品合計（税抜）
                        salesSlip.SalesWorkTotalTaxInc = salesWorkSubttlInc + itdedWorkDisInTax;                // 売上作業合計（税込）
                        salesSlip.SalesWorkTotalTaxExc = salesWorkSubttlExc + itdedWorkDisOutTax;               // 売上作業合計（税抜）
                        double rate;
                        this.GetRate(itdedPartsDisOutTax, salesPrtSubttlExc, out rate);
                        salesSlip.PartsDiscountRate = rate;                                                     // 部品値引率
                        break;
                    }
            }
        }

        /// <summary>
        /// 売上金額の合計を計算します。
        /// </summary>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
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
        /// <param name="StockGoodsTtlTaxExc">在庫商品合計金額(税抜)</param>
        /// <param name="PureGoodsTtlTaxExc">純正商品合計金額(税抜)</param>
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
        /// <param name="salesPrtTotalTaxInc">売上部品合計（税込）</param>
        /// <param name="salesPrtTotalTaxExc">売上部品合計（税抜）</param>
        /// <br>Update Note: 2013/12/19 陳健</br>
        /// <br>             Redmine#41550 売上伝票入力消費税8%増税対応。</br> 
        /// <br>Update Note: 2014/01/23 陳健</br>
        /// <br>             Redmine#41771 売上伝票入力消費税8%増税対応。</br> 
        public void CalculationSalesTotalPrice(SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, double consTaxRate, int salesTaxFrcProcCd, int totalAmountDispWayCd, int consTaxLayMethod, out long salesTotalTaxInc, out long salesTotalTaxExc, out long salesSubtotalTax, out long itdedSalesOutTax, out long itdedSalesInTax, out long salSubttlSubToTaxFre, out long salesOutTax, out long salAmntConsTaxInclu, out long salesDisTtlTaxExc, out long itdedSalesDisOutTax, out long itdedSalesDisInTax, out long itdedSalesDisTaxFre, out long salesDisOutTax, out long salesDisTtlTaxInclu, out long totalCost, out long stockGoodsTtlTaxExc, out long pureGoodsTtlTaxExc, out long balanceAdjust, out long taxAdjust, out long salesPrtSubttlInc, out long salesPrtSubttlExc, out long salesWorkSubttlInc, out long salesWorkSubttlExc, out long itdedPartsDisInTax, out long itdedPartsDisOutTax, out long itdedWorkDisInTax, out long itdedWorkDisOutTax, out long totalMoneyForGrossProfit, out long salesPrtTotalTaxInc, out long salesPrtTotalTaxExc)
        {
            #region ●初期処理
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            // 消費税端数処理単位、端数処理区分を取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // データテーブルの変更をコミットさせる
            salesDetailDataTable.AcceptChanges();

            salesTotalTaxInc = 0;           // 売上伝票合計（税込）
            salesTotalTaxExc = 0;           // 売上伝票合計（税抜）
            salesSubtotalTax = 0;           // 売上小計（税）
            itdedSalesOutTax = 0;           // 売上外税対象額
            itdedSalesInTax = 0;            // 売上内税対象額
            salSubttlSubToTaxFre = 0;       // 売上小計非課税対象額
            salesOutTax = 0;                // 売上金額消費税額（外税）
            salAmntConsTaxInclu = 0;        // 売上金額消費税額（内税）
            salesDisTtlTaxExc = 0;          // 売上値引金額計（税抜）
            itdedSalesDisOutTax = 0;        // 売上値引外税対象額合計
            itdedSalesDisInTax = 0;         // 売上値引内税対象額合計
            itdedSalesDisTaxFre = 0;        // 売上値引非課税対象額合計
            salesDisOutTax = 0;             // 売上値引消費税額（外税）
            salesDisTtlTaxInclu = 0;        // 売上値引消費税額（内税）
            stockGoodsTtlTaxExc = 0;        // 在庫商品合計金額（税抜）
            pureGoodsTtlTaxExc = 0;         // 純正商品合計金額（税抜）
            totalCost = 0;                  // 原価金額計
            taxAdjust = 0;                  // 消費税調整額
            balanceAdjust = 0;              // 残高調整額
            salesPrtTotalTaxInc = 0;        // 売上部品合計（税込）
            salesPrtTotalTaxExc = 0;        // 売上部品合計（税抜）
            salesPrtSubttlInc = 0;          // 売上部品小計（税込）
            salesPrtSubttlExc = 0;          // 売上部品小計（税抜）
            salesWorkSubttlInc = 0;         // 売上作業小計（税込）
            salesWorkSubttlExc = 0;         // 売上作業小計（税抜）
            itdedPartsDisInTax = 0;         // 部品値引対象額合計（税込）
            itdedPartsDisOutTax = 0;        // 部品値引対象額合計（税抜）
            itdedWorkDisInTax = 0;          // 作業値引対象額合計（税込）
            itdedWorkDisOutTax = 0;         // 作業値引対象額合計（税抜）
            totalMoneyForGrossProfit = 0;   // 粗利計算用売上金額
            
            object value = null;
            #endregion

            #region ●計算に必要な金額の計算
            //-----------------------------------------------------------------------------
            // 計算に必要な金額の計算
            //-----------------------------------------------------------------------------
            // 売上外税対象額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})", 
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, 
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            itdedSalesOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上金額消費税額（外税）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上内税対象額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            itdedSalesInTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上内税対象額（税込）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            long itdedSalesInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 売上金額消費税額（内税）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salAmntConsTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            // 売上小計非課税対象額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salSubttlSubToTaxFre = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引外税対象額合計
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}", 
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, 
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引消費税額（外税）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            salesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引内税対象額合計
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisInTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引内税対象額合計（税込）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long itdedSalesDisInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引消費税額（内税）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            salesDisTtlTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引非課税対象額合計
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisTaxFre = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引金額計（税抜）
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // 残高調整額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.BalanceAdjust, 
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecBalanceAdjust));
            balanceAdjust = (value is System.DBNull) ? 0 : (long)value;

            // 消費税調整額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.ConsTaxAdjust, 
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecConsTaxAdjust));
            taxAdjust = (value is System.DBNull) ? 0 : (long)value;

            // 原価金額計（内税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}", 
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 原価金額計（外税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // 原価金額計（非課税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // 原価金額計
            totalCost = totalCost_TaxInc + totalCost_TaxExc + totalCost_TaxNone;

            // 粗利計算用売上金額計（内税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxInc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // 粗利計算用売上金額計（外税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxExc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // 粗利計算用売上金額計（非課税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxNone_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // 粗利計算用売上金額計
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // 在庫商品合計金額（税抜）（内税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 内税商品 AND 在庫 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 在庫商品合計金額（税抜）（外税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 外税商品品 AND 在庫 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // 在庫商品合計金額（税抜）（非課税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 非課税商品 AND 在庫 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // 在庫商品合計金額（税抜）
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone; // 在庫商品合計金額（税抜）

            // 純正商品合計金額（税抜）（内税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                //string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 内税商品 AND 純正 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                //    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                //    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                //    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR {8}={9})",  // 内税商品 AND 純正 AND (売上 OR 返品 OR 値引)
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long pureGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 純正商品合計金額（税抜）（外税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                //string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 外税商品 AND 純正 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                //    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                //    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                //    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR {8}={9})",  // 外税商品 AND 純正 AND (売上 OR 返品 OR 値引)
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long pureGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // 純正商品合計金額（税抜）（非課税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                //string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 非課税 AND 純正 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                //    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                //    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                //    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR {8}={9})",  // 非課税 AND 純正 AND (売上 OR 返品 OR 値引)
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long pureGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // 純正商品合計金額（税抜）
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone; // 純正商品合計金額（税抜）

            // 売上部品小計（税込）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesPrtSubttlInc = (value is System.DBNull) ? 0 : (long)value;

            // 売上部品小計（税抜）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesPrtSubttlExc = (value is System.DBNull) ? 0 : (long)value;

            // 部品値引対象額合計（税込）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedPartsDisInTax = (value is System.DBNull) ? 0 : (long)value;

            // 部品値引対象額合計（税抜）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedPartsDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上部品合計（税込）
            salesPrtTotalTaxInc = salesPrtSubttlInc + itdedPartsDisInTax;

            // 売上部品合計（税抜）
            salesPrtTotalTaxExc = salesPrtSubttlExc + itdedPartsDisOutTax;
            #endregion

            #region ●転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            // 転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
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
            if (consTaxLayMethod != (int)ConsTaxLayMethod.DetailLay)
            {
                //-----------------------------------------------------------------------------
                // ① 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計 + 売上値引非課税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税込）： 売上内税対象額（税込） + 売上外税対象額 + 売上値引内税対象額合計（税込） + 売上値引外税対象額合計 + 売上値引非課税対象額合計 + (売上外税対象額 + 売上値引外税対象額合計)×税率)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ③ 売上小計（税）：② - ①
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // ④ 売上金額消費税額（外税）：売上外税対象額 × 税率
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // ⑤ 売上金額消費税額（外税）(税抜、値引き含む) ：(売上外税対象額 + 売上値引外税対象額合計) × 税率
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑥ 売上値引消費税額（外税）：④ - ⑤
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;

                //-----------------------------------------------------------------------------
                // ⑦ 売上部品小計（税込）：売上部品小計（税抜） × 税率
                //-----------------------------------------------------------------------------
                salesPrtSubttlInc = salesPrtSubttlExc + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc);

                //-----------------------------------------------------------------------------
                // ⑧ 部品値引対象額合計（税込）：部品値引対象額合計（税抜）× 税率
                //-----------------------------------------------------------------------------
                itdedPartsDisInTax = itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedPartsDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑨ 売上部品合計（税込）：(売上部品小計（税抜）+ 部品値引対象額合計（税抜）) × 税率
                //-----------------------------------------------------------------------------
                salesPrtTotalTaxInc = salesPrtSubttlExc + itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc + itdedPartsDisOutTax);
            }
            // 明細転嫁
            else
            {
                // ---------------------------- ADD 陳健 2013/12/19 Redmine#41550 No.1----------------------------------->>>>>
                // ------------------------------
                // 障害現象
                // 明細転嫁の場合、改定前の伝票を修正モードで呼び出し、売上日は改定後へ変更し、
                // 保存する際に、納品書に消費税が改定前の値で表示される
                // ------------------------------
                // 売上金額消費税額（外税）
                salesOutTax = 0;
                // 売上値引消費税額（外税）
                salesDisOutTax = 0;
                foreach (SalesInputDataSet.SalesDetailRow row in salesDetailDataTable)
                {
                    if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) // 商品が外税
                    {
                        // -----------------------------------------------
                        // 明細データに税込の項目と消費税も更新する必要
                        // 更新しないと、下記の現象が発生
                        // 現象：得意先電子元帳にて検索して、「伝票表示」と「明細表示」の消費税が違う
                        // -----------------------------------------------
                        // 定価(税込) = 定価(税抜) + (定価(税抜) * 税率)
                        row.ListPriceTaxIncFl = row.ListPriceTaxExcFl + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.ListPriceTaxExcFl);
                        // 売上単価（税込）= 売上単価(税抜) + (売上単価(税抜) * 税率)
                        row.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxExcFl + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesUnPrcTaxExcFl);
                        // 売上金額（税込）= 売上金額(税抜) + (売上金額(税抜) * 税率)
                        row.SalesMoneyTaxInc = row.SalesMoneyTaxExc + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);

                        // 0:売上,1:返品
                        if (row.SalesSlipCdDtl == (int)SalesSlipCdDtl.Sales || row.SalesSlipCdDtl == (int)SalesSlipCdDtl.RetGoods)
                        {
                            // 売上金額消費税額
                            long salesPriceConsTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                            row.SalesPriceConsTax = salesPriceConsTax;
                            salesOutTax += salesPriceConsTax;
                        }
                        // 2:値引
                        else if (row.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount)
                        {
                            // 売上金額消費税額
                            long salesPriceConsTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                            row.SalesPriceConsTax = salesPriceConsTax;
                            salesDisOutTax += salesPriceConsTax;
                        }
                        // 3:注釈,4:小計,5:作業
                        else
                        {
                            // なし
                        }
                    }
                }
                // ---------------------------- ADD 陳健 2013/12/19 Redmine#41550 No.9 -----------------------------------<<<<<
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

            #region 削除
            //// 総額表示する
            //if (totalAmountDispWayCd == 1)
            //{
            //    //-----------------------------------------------------------------------------
            //    // ① 売上伝票合計（税込）：売上外税対象額 + 売上金額消費税額（外税） + 売上内税対象額（税込） +  売上値引内税対象額合計（税込）
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = itdedSalesOutTax + salesOutTax + itdedSalesInTax_TaxInc + itdedSalesDisInTax_TaxInc;

            //    //-----------------------------------------------------------------------------
            //    // ② 売上小計（税）：①から内税を計算
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = CalculateTax.GetTaxFromPriceInc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesTotalTaxInc);

            //    //-----------------------------------------------------------------------------
            //    // ③ 売上伝票合計（税抜）：② - ①
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = salesTotalTaxInc - salesSubtotalTax;
            //}
            //// 総額表示なし 伝票転嫁以外
            //else if (consTaxLayMethod != 0)
            //{
            //    //-----------------------------------------------------------------------------
            //    // ① 売上小計（税）：売上金額消費税額（外税） + 売上金額消費税額（内税） +  売上値引消費税額（外税） + 売上値引消費税額（内税）
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

            //    //-----------------------------------------------------------------------------
            //    // ② 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax;

            //    //-----------------------------------------------------------------------------
            //    // ③ 売上伝票合計（税込）：① + ②
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            //}
            //// 総額表示無しで、伝票転嫁
            //else
            //{
            //    //-----------------------------------------------------------------------------
            //    // ① 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax;

            //    //-----------------------------------------------------------------------------
            //    // ② 売上伝票合計（税込）： 売上内税対象額（税込） + 売上外税対象額 + 売上値引外税対象額合計 ＋ (売上外税対象額 + 売上値引外税対象額合計)×税率)
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

            //    //-----------------------------------------------------------------------------
            //    // ③ 売上小計（税）：② - ①
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

            //    //-----------------------------------------------------------------------------
            //    // ④ 売上金額消費税額（外税）：売上外税対象額 × 税率
            //    //-----------------------------------------------------------------------------
            //    salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

            //    //-----------------------------------------------------------------------------
            //    // ⑤ 売上金額消費税額（外税）(税抜、値引き含む) ：(売上外税対象額 + 売上値引外税対象額合計) × 税率
            //    //-----------------------------------------------------------------------------
            //    long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

            //    //-----------------------------------------------------------------------------
            //    // ⑥ 売上値引消費税額（外税）：④ - ⑤
            //    //-----------------------------------------------------------------------------
            //    salesDisOutTax = salesOutTax_All - salesOutTax;
            //}
            #endregion
        }

        /// <summary>
        /// 売上合計金額設定処理（受注情報）
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        public void TotalPriceSettingForAcptAnOdr(ref SalesSlip salesSlip)
        {
            this.TotalPriceSettingForAcptAnOdr(ref salesSlip, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 売上合計金額設定処理（受注情報）
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        public void TotalPriceSettingForAcptAnOdr(ref SalesSlip salesSlip, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailDataTable)
        {
            if (salesSlip == null) return;
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 消費税端数処理コード

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
            long salesPrtTotalTaxInc = 0;   // 売上部品合計（税込）
            long salesPrtTotalTaxExc = 0;   // 売上部品合計（税抜）
            long salesPrtSubttlInc = 0;     // 売上部品小計（税込）
            long salesPrtSubttlExc = 0;     // 売上部品小計（税抜）
            long salesWorkSubttlInc = 0;    // 売上作業小計（税込）
            long salesWorkSubttlExc = 0;    // 売上作業小計（税抜）
            long itdedPartsDisInTax = 0;    // 部品値引対象額合計（税込）
            long itdedPartsDisOutTax = 0;   // 部品値引対象額合計（税抜）
            long itdedWorkDisInTax = 0;     // 作業値引対象額合計（税込）
            long itdedWorkDisOutTax = 0;    // 作業値引対象額合計（税抜）
            long totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            this.CalculationSalesTotalPriceForAcptAnOdr(
                salesDetailDataTable,
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
                out totalMoneyForGrossProfit,
                out salesPrtTotalTaxInc,
                out salesPrtTotalTaxExc);

            switch ((SalesGoodsCd)salesSlip.SalesGoodsCd)
            {
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                    {

                        salesSlip.SalesSubtotalTaxInc = 0;              // 売上小計（税込）
                        salesSlip.SalesSubtotalTaxExc = 0;              // 売上小計（税抜）
                        salesSlip.SalesSubtotalTax = taxAdjust;         // 売上小計（税）
                        salesSlip.ItdedSalesOutTax = 0;                 // 売上外税対象額
                        salesSlip.ItdedSalesInTax = 0;                  // 売上内税対象額
                        salesSlip.SalSubttlSubToTaxFre = 0;             // 売上小計非課税対象額
                        salesSlip.SalesOutTax = 0;                      // 売上金額消費税額（外税）
                        salesSlip.SalAmntConsTaxInclu = 0;              // 売上金額消費税額（内税）
                        salesSlip.SalesDisTtlTaxExc = 0;                // 売上値引金額計（税抜）
                        salesSlip.ItdedSalesDisOutTax = 0;              // 売上値引外税対象額合計
                        salesSlip.ItdedSalesDisInTax = 0;               // 売上値引内税対象額合計
                        salesSlip.ItdedSalesDisTaxFre = 0;              // 売上値引非課税対象額合計
                        salesSlip.SalesDisOutTax = 0;                   // 売上値引消費税額（外税）
                        salesSlip.SalesDisTtlTaxInclu = 0;              // 売上値引消費税額（内税）
                        salesSlip.TotalCost = 0;                        // 原価金額計
                        salesSlip.StockGoodsTtlTaxExc = 0;              // 在庫商品合計金額（税抜）
                        salesSlip.PureGoodsTtlTaxExc = 0;               // 純正商品合計金額（税抜）
                        salesSlip.SalesPrtSubttlInc = 0;                // 売上部品小計（税込）
                        salesSlip.SalesPrtSubttlExc = 0;                // 売上部品小計（税抜）
                        salesSlip.SalesWorkSubttlInc = 0;               // 売上作業小計（税込）
                        salesSlip.SalesWorkSubttlExc = 0;               // 売上作業小計（税抜）
                        salesSlip.ItdedPartsDisInTax = 0;               // 部品値引対象額合計（税込）
                        salesSlip.ItdedPartsDisOutTax = 0;              // 部品値引対象額合計（税抜）
                        salesSlip.ItdedWorkDisInTax = 0;                // 作業値引対象額合計（税込）
                        salesSlip.ItdedWorkDisOutTax = 0;               // 作業値引対象額合計（税抜）
                        salesSlip.TotalMoneyForGrossProfit = 0;         // 粗利計算用売上金額

                        salesSlip.SalesTotalTaxInc = 0;                 // 売上伝票合計（税込）
                        salesSlip.SalesTotalTaxExc = 0;                 // 売上伝票合計（税抜）
                        salesSlip.SalesNetPrice = 0;                    // 売上正価金額
                        salesSlip.AccRecConsTax = 0;                    // 売掛消費税
                        break;
                    }
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    {
                        salesSlip.SalesSubtotalTaxInc = 0;              // 売上小計（税込）
                        salesSlip.SalesSubtotalTaxExc = 0;              // 売上小計（税抜）
                        salesSlip.SalesSubtotalTax = 0;                 // 売上小計（税）
                        salesSlip.ItdedSalesOutTax = 0;                 // 売上外税対象額
                        salesSlip.ItdedSalesInTax = 0;                  // 売上内税対象額
                        salesSlip.SalSubttlSubToTaxFre = 0;             // 売上小計非課税対象額
                        salesSlip.SalesOutTax = 0;                      // 売上金額消費税額（外税）
                        salesSlip.SalAmntConsTaxInclu = 0;              // 売上金額消費税額（内税）
                        salesSlip.SalesDisTtlTaxExc = 0;                // 売上値引金額計（税抜）
                        salesSlip.ItdedSalesDisOutTax = 0;              // 売上値引外税対象額合計
                        salesSlip.ItdedSalesDisInTax = 0;               // 売上値引内税対象額合計
                        salesSlip.ItdedSalesDisTaxFre = 0;              // 売上値引非課税対象額合計
                        salesSlip.SalesDisOutTax = 0;                   // 売上値引消費税額（外税）
                        salesSlip.SalesDisTtlTaxInclu = 0;              // 売上値引消費税額（内税）
                        salesSlip.TotalCost = 0;                        // 原価金額計
                        salesSlip.StockGoodsTtlTaxExc = 0;              // 在庫商品合計金額（税抜）
                        salesSlip.PureGoodsTtlTaxExc = 0;               // 純正商品合計金額（税抜）
                        salesSlip.SalesPrtSubttlInc = 0;                // 売上部品小計（税込）
                        salesSlip.SalesPrtSubttlExc = 0;                // 売上部品小計（税抜）
                        salesSlip.SalesWorkSubttlInc = 0;               // 売上作業小計（税込）
                        salesSlip.SalesWorkSubttlExc = 0;               // 売上作業小計（税抜）
                        salesSlip.ItdedPartsDisInTax = 0;               // 部品値引対象額合計（税込）
                        salesSlip.ItdedPartsDisOutTax = 0;              // 部品値引対象額合計（税抜）
                        salesSlip.ItdedWorkDisInTax = 0;                // 作業値引対象額合計（税込）
                        salesSlip.ItdedWorkDisOutTax = 0;               // 作業値引対象額合計（税抜）
                        salesSlip.TotalMoneyForGrossProfit = 0;         // 粗利計算用売上金額

                        salesSlip.SalesTotalTaxInc = balanceAdjust;     // 売上伝票合計（税込）
                        salesSlip.SalesTotalTaxExc = 0;                 // 売上伝票合計（税抜）
                        salesSlip.SalesNetPrice = 0;                    // 売上正価金額
                        salesSlip.AccRecConsTax = 0;                    // 売掛消費税
                        break;
                    }
                case SalesGoodsCd.Goods:
                    {
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
                        salesSlip.TotalMoneyForGrossProfit = totalMoneyForGrossProfit; // 粗利計算用売上金額

                        salesSlip.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;                   // 売上伝票合計（税込）= 売上伝票合計（税込） + 売上小計非課税対象額
                        salesSlip.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;                   // 売上伝票合計（税抜）= 売上伝票合計（税抜） + 売上小計非課税対象額
                        salesSlip.SalesNetPrice = itdedSalesOutTax + itdedSalesInTax + salSubttlSubToTaxFre;    // 売上正価金額 = 売上外税対象額 + 売上内税対象額 + 売上小計非課税対象額
                        salesSlip.AccRecConsTax = salesSubtotalTax;                                             // 売掛消費税
                        salesSlip.SalesPrtTotalTaxInc = salesPrtTotalTaxInc;                                    // 売上部品合計（税込）
                        salesSlip.SalesPrtTotalTaxExc = salesPrtTotalTaxExc;                                    // 売上部品合計（税抜）
                        salesSlip.SalesWorkTotalTaxInc = salesWorkSubttlInc + itdedWorkDisInTax;                // 売上作業合計（税込）
                        salesSlip.SalesWorkTotalTaxExc = salesWorkSubttlExc + itdedWorkDisOutTax;               // 売上作業合計（税抜）
                        break;
                    }
            }
        }

        /// <summary>
        /// 売上金額の合計を計算します。（受注情報）
        /// </summary>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
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
        /// <param name="StockGoodsTtlTaxExc">在庫商品合計金額(税抜)</param>
        /// <param name="PureGoodsTtlTaxExc">純正商品合計金額(税抜)</param>
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
        /// <param name="salesPrtTotalTaxInc">売上部品合計（税込）</param>
        /// <param name="salesPrtTotalTaxExc">売上部品合計（税抜）</param>
        /// <br>Update Note: 2013/12/19 陳健</br>
        /// <br>             Redmine#41550 売上伝票入力消費税8%増税対応。</br> 
        public void CalculationSalesTotalPriceForAcptAnOdr(SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailDataTable, double consTaxRate, int salesTaxFrcProcCd, int totalAmountDispWayCd, int consTaxLayMethod, out long salesTotalTaxInc, out long salesTotalTaxExc, out long salesSubtotalTax, out long itdedSalesOutTax, out long itdedSalesInTax, out long salSubttlSubToTaxFre, out long salesOutTax, out long salAmntConsTaxInclu, out long salesDisTtlTaxExc, out long itdedSalesDisOutTax, out long itdedSalesDisInTax, out long itdedSalesDisTaxFre, out long salesDisOutTax, out long salesDisTtlTaxInclu, out long totalCost, out long stockGoodsTtlTaxExc, out long pureGoodsTtlTaxExc, out long balanceAdjust, out long taxAdjust, out long salesPrtSubttlInc, out long salesPrtSubttlExc, out long salesWorkSubttlInc, out long salesWorkSubttlExc, out long itdedPartsDisInTax, out long itdedPartsDisOutTax, out long itdedWorkDisInTax, out long itdedWorkDisOutTax, out long totalMoneyForGrossProfit, out long salesPrtTotalTaxInc, out long salesPrtTotalTaxExc)
        {
            #region ●初期処理
            //-----------------------------------------------------------------------------
            // 初期処理
            //-----------------------------------------------------------------------------
            // 消費税端数処理単位、端数処理区分を取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // データテーブルの変更をコミットさせる
            salesDetailDataTable.AcceptChanges();

            salesTotalTaxInc = 0;           // 売上伝票合計（税込）
            salesTotalTaxExc = 0;           // 売上伝票合計（税抜）
            salesSubtotalTax = 0;           // 売上小計（税）
            itdedSalesOutTax = 0;           // 売上外税対象額
            itdedSalesInTax = 0;            // 売上内税対象額
            salSubttlSubToTaxFre = 0;       // 売上小計非課税対象額
            salesOutTax = 0;                // 売上金額消費税額（外税）
            salAmntConsTaxInclu = 0;        // 売上金額消費税額（内税）
            salesDisTtlTaxExc = 0;          // 売上値引金額計（税抜）
            itdedSalesDisOutTax = 0;        // 売上値引外税対象額合計
            itdedSalesDisInTax = 0;         // 売上値引内税対象額合計
            itdedSalesDisTaxFre = 0;        // 売上値引非課税対象額合計
            salesDisOutTax = 0;             // 売上値引消費税額（外税）
            salesDisTtlTaxInclu = 0;        // 売上値引消費税額（内税）
            stockGoodsTtlTaxExc = 0;        // 在庫商品合計金額（税抜）
            pureGoodsTtlTaxExc = 0;         // 純正商品合計金額（税抜）
            totalCost = 0;                  // 原価金額計
            taxAdjust = 0;                  // 消費税調整額
            balanceAdjust = 0;              // 残高調整額
            salesPrtTotalTaxInc = 0;        // 売上部品合計（税込）
            salesPrtTotalTaxExc = 0;        // 売上部品合計（税抜）
            salesPrtSubttlInc = 0;          // 売上部品小計（税込）
            salesPrtSubttlExc = 0;          // 売上部品小計（税抜）
            salesWorkSubttlInc = 0;         // 売上作業小計（税込）
            salesWorkSubttlExc = 0;         // 売上作業小計（税抜）
            itdedPartsDisInTax = 0;         // 部品値引対象額合計（税込）
            itdedPartsDisOutTax = 0;        // 部品値引対象額合計（税抜）
            itdedWorkDisInTax = 0;          // 作業値引対象額合計（税込）
            itdedWorkDisOutTax = 0;         // 作業値引対象額合計（税抜）
            totalMoneyForGrossProfit = 0;   // 粗利計算用売上金額

            object value = null;
            #endregion

            #region ●計算に必要な金額の計算
            //-----------------------------------------------------------------------------
            // 計算に必要な金額の計算
            //-----------------------------------------------------------------------------
            // 売上外税対象額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            itdedSalesOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上金額消費税額（外税）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上内税対象額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            itdedSalesInTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上内税対象額（税込）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            long itdedSalesInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 売上金額消費税額（内税）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salAmntConsTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            // 売上小計非課税対象額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salSubttlSubToTaxFre = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引外税対象額合計
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引消費税額（外税）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            salesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引内税対象額合計
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisInTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引内税対象額合計（税込）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long itdedSalesDisInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引消費税額（内税）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            salesDisTtlTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引非課税対象額合計
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisTaxFre = (value is System.DBNull) ? 0 : (long)value;

            // 売上値引金額計（税抜）
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // 残高調整額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.BalanceAdjust,
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecBalanceAdjust));
            balanceAdjust = (value is System.DBNull) ? 0 : (long)value;

            // 消費税調整額
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.ConsTaxAdjust,
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecConsTaxAdjust));
            taxAdjust = (value is System.DBNull) ? 0 : (long)value;

            // 原価金額計（内税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 原価金額計（外税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // 原価金額計（非課税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // 原価金額計
            totalCost = totalCost_TaxInc + totalCost_TaxExc + totalCost_TaxNone;

            // 粗利計算用売上金額計（内税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxInc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // 粗利計算用売上金額計（外税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxExc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // 粗利計算用売上金額計（非課税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxNone_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // 粗利計算用売上金額計
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // 在庫商品合計金額（税抜）（内税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 内税商品 AND 在庫 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 在庫商品合計金額（税抜）（外税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 外税商品品 AND 在庫 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // 在庫商品合計金額（税抜）（非課税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 非課税商品 AND 在庫 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // 在庫商品合計金額（税抜）
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone; // 在庫商品合計金額（税抜）

            // 純正商品合計金額（税抜）（内税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 内税商品 AND 純正 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long pureGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // 純正商品合計金額（税抜）（外税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 外税商品 AND 純正 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long pureGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // 純正商品合計金額（税抜）（非課税商品分）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 非課税 AND 純正 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long pureGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // 純正商品合計金額（税抜）
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone; // 純正商品合計金額（税抜）

            // 売上部品小計（税込）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesPrtSubttlInc = (value is System.DBNull) ? 0 : (long)value;

            // 売上部品小計（税抜）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesPrtSubttlExc = (value is System.DBNull) ? 0 : (long)value;

            // 部品値引対象額合計（税込）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedPartsDisInTax = (value is System.DBNull) ? 0 : (long)value;

            // 部品値引対象額合計（税抜）
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedPartsDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // 売上部品合計（税込）
            salesPrtTotalTaxInc = salesPrtSubttlInc + itdedPartsDisInTax;

            // 売上部品合計（税抜）
            salesPrtTotalTaxExc = salesPrtSubttlExc + itdedPartsDisOutTax;
            #endregion

            #region ●転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            // 転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
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
            if (consTaxLayMethod != (int)ConsTaxLayMethod.DetailLay)
            {
                //-----------------------------------------------------------------------------
                // ① 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計 + 売上値引非課税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税込）： 売上内税対象額（税込） + 売上外税対象額 + 売上値引内税対象額合計（税込） + 売上値引外税対象額合計 + 売上値引非課税対象額合計 + (売上外税対象額 + 売上値引外税対象額合計)×税率)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ③ 売上小計（税）：② - ①
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // ④ 売上金額消費税額（外税）：売上外税対象額 × 税率
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // ⑤ 売上金額消費税額（外税）(税抜、値引き含む) ：(売上外税対象額 + 売上値引外税対象額合計) × 税率
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑥ 売上値引消費税額（外税）：④ - ⑤
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;

                //-----------------------------------------------------------------------------
                // ⑦ 売上部品小計（税込）：売上部品小計（税抜）× 税率
                //-----------------------------------------------------------------------------
                salesPrtSubttlInc = salesPrtSubttlExc + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc);

                //-----------------------------------------------------------------------------
                // ⑧ 部品値引対象額合計（税込）：部品値引対象額合計（税抜）× 税率
                //-----------------------------------------------------------------------------
                itdedPartsDisInTax = itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedPartsDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑨ 売上部品合計（税込）：(売上部品小計（税抜）+ 部品値引対象額合計（税抜）) × 税率
                //-----------------------------------------------------------------------------
                salesPrtTotalTaxInc = salesPrtSubttlExc + itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc + itdedPartsDisOutTax);
            }
            // 明細転嫁
            else
            {
                // ---------------------------- ADD 陳健 2013/12/19 Redmine#41550 No.9----------------------------------->>>>>
                // 売上金額消費税額（外税）
                salesOutTax = 0;
                // 売上値引消費税額（外税）
                salesDisOutTax = 0;
                foreach (SalesInputDataSet.SalesDetailAcceptAnOrderRow row in salesDetailDataTable)
                {
                    if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) // 商品が外税
                    {
                        // 0:売上,1:返品
                        if (row.SalesSlipCdDtl == (int)SalesSlipCdDtl.Sales || row.SalesSlipCdDtl == (int)SalesSlipCdDtl.RetGoods)
                        {
                            // 売上金額消費税額
                            long salesPriceConsTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                            salesOutTax += salesPriceConsTax;
                        }
                        // 2:値引
                        else if (row.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount)
                        {
                            // 売上金額消費税額
                            long salesPriceConsTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                            salesDisOutTax += salesPriceConsTax;
                        }
                        // 3:注釈,4:小計,5:作業
                        else
                        {
                            // なし
                        }
                    }
                }
                // ---------------------------- ADD 陳健 2013/12/19 Redmine#41550 No.9-----------------------------------<<<<<
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

            #region 削除
            //// 消費税端数処理単位、端数処理区分を取得
            //int taxFracProcCd = 0;
            //double taxFracProcUnit = 0;
            //this._salesSlipInputInitDataAcs.GetFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            //// データテーブルの変更をコミットさせる
            //salesDetailDataTable.AcceptChanges();

            //salesTotalTaxInc = 0;       // 売上伝票合計（税込）
            //salesTotalTaxExc = 0;       // 売上伝票合計（税抜）
            //salesSubtotalTax = 0;       // 売上小計（税）
            //itdedSalesOutTax = 0;       // 売上外税対象額
            //itdedSalesInTax = 0;        // 売上内税対象額
            //salSubttlSubToTaxFre = 0;   // 売上小計非課税対象額
            //salesOutTax = 0;            // 売上金額消費税額（外税）
            //salAmntConsTaxInclu = 0;    // 売上金額消費税額（内税）
            //salesDisTtlTaxExc = 0;      // 売上値引金額計（税抜）
            //itdedSalesDisOutTax = 0;    // 売上値引外税対象額合計
            //itdedSalesDisInTax = 0;     // 売上値引内税対象額合計
            //itdedSalesDisTaxFre = 0;    // 売上値引非課税対象額合計
            //salesDisOutTax = 0;         // 売上値引消費税額（外税）
            //salesDisTtlTaxInclu = 0;    // 売上値引消費税額（内税）
            //stockGoodsTtlTaxExc = 0;    // 在庫商品合計金額（税抜）
            //pureGoodsTtlTaxExc = 0;     // 純正商品合計金額（税抜）
            //totalCost = 0;              // 原価金額計
            //taxAdjust = 0;              // 消費税調整額
            //balanceAdjust = 0;          // 残高調整額
            //salesPrtSubttlInc = 0;      // 売上部品小計（税込）
            //salesPrtSubttlExc = 0;      // 売上部品小計（税抜）
            //salesWorkSubttlInc = 0;     // 売上作業小計（税込）
            //salesWorkSubttlExc = 0;     // 売上作業小計（税抜）
            //itdedPartsDisInTax = 0;     // 部品値引対象額合計（税込）
            //itdedPartsDisOutTax = 0;    // 部品値引対象額合計（税抜）
            //itdedWorkDisInTax = 0;      // 作業値引対象額合計（税込）
            //itdedWorkDisOutTax = 0;     // 作業値引対象額合計（税抜）
            //totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            //object value = null;

            ////-----------------------------------------------------------------------------
            //// 計算に必要な金額の計算
            ////-----------------------------------------------------------------------------
            //#region ●計算に必要な金額の計算
            //// 売上外税対象額
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //itdedSalesOutTax = (value is System.DBNull) ? 0 : (long)value;

            //// 売上金額消費税額（外税）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salesOutTax = (value is System.DBNull) ? 0 : (long)value;

            //// 売上内税対象額
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //itdedSalesInTax = (value is System.DBNull) ? 0 : (long)value;

            //// 売上内税対象額（税込）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //long itdedSalesInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// 売上金額消費税額（内税）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salAmntConsTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            //// 売上小計非課税対象額
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salSubttlSubToTaxFre = (value is System.DBNull) ? 0 : (long)value;

            //// 売上値引外税対象額合計
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedSalesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            //// 売上値引消費税額（外税）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //salesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            //// 売上値引内税対象額合計
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedSalesDisInTax = (value is System.DBNull) ? 0 : (long)value;

            //// 売上値引内税対象額合計（税込）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //long itdedSalesDisInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// 売上値引消費税額（内税）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //salesDisTtlTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            //// 売上値引非課税対象額合計
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedSalesDisTaxFre = (value is System.DBNull) ? 0 : (long)value;

            //// 売上値引金額計（税抜）
            //salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            //// 残高調整額
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} OR {2}={3}",
            //        salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.BalanceAdjust,
            //        salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecBalanceAdjust));
            //balanceAdjust = (value is System.DBNull) ? 0 : (long)value;

            //// 消費税調整額
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} OR {2}={3}",
            //        salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.ConsTaxAdjust,
            //        salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecConsTaxAdjust));
            //taxAdjust = (value is System.DBNull) ? 0 : (long)value;

            //// 原価金額計（内税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.CostTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalCost_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// 原価金額計（外税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalCost_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            //// 原価金額計（非課税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalCost_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            //// 原価金額計
            //totalCost = totalCost_TaxInc + totalCost_TaxExc + totalCost_TaxNone;

            //// 粗利計算用売上金額計（内税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalMoney_TaxInc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            //// 粗利計算用売上金額計（外税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalMoney_TaxExc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            //// 粗利計算用売上金額計（非課税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalMoney_TaxNone_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            //// 粗利計算用売上金額計
            //totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            //// 在庫商品合計金額（税抜）（内税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 内税商品 AND 在庫 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long stockGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// 在庫商品合計金額（税抜）（外税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 外税商品品 AND 在庫 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long stockGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            //// 在庫商品合計金額（税抜）（非課税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 非課税商品 AND 在庫 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long stockGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            //// 在庫商品合計金額（税抜）
            //stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone; // 在庫商品合計金額（税抜）

            //// 純正商品合計金額（税抜）（内税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 内税商品 AND 純正 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long pureGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// 純正商品合計金額（税抜）（外税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 外税商品 AND 純正 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long pureGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            //// 純正商品合計金額（税抜）（非課税商品分）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // 非課税 AND 純正 AND (売上 OR 返品 OR (値引 AND 出荷数ゼロ))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long pureGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            //// 純正商品合計金額（税抜）
            //pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone; // 純正商品合計金額（税抜）

            //// 売上部品小計（税込）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} OR {2}={3}",
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salesPrtSubttlInc = (value is System.DBNull) ? 0 : (long)value;

            //// 売上部品小計（税抜）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} OR {2}={3}",
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salesPrtSubttlExc = (value is System.DBNull) ? 0 : (long)value;

            //// 部品値引対象額合計（税込）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1}",
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedPartsDisInTax = (value is System.DBNull) ? 0 : (long)value;

            //// 部品値引対象額合計（税抜）
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1}",
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedPartsDisOutTax = (value is System.DBNull) ? 0 : (long)value;
            //#endregion

            //// 総額表示する
            //if (totalAmountDispWayCd == 1)
            //{
            //    //-----------------------------------------------------------------------------
            //    // ① 売上伝票合計（税込）：売上外税対象額 + 売上金額消費税額（外税） + 売上内税対象額（税込） +  売上値引内税対象額合計（税込）
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = itdedSalesOutTax + salesOutTax + itdedSalesInTax_TaxInc + itdedSalesDisInTax_TaxInc;

            //    //-----------------------------------------------------------------------------
            //    // ② 売上小計（税）：①から内税を計算
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = CalculateTax.GetTaxFromPriceInc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesTotalTaxInc);

            //    //-----------------------------------------------------------------------------
            //    // ③ 売上伝票合計（税抜）：② - ①
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = salesTotalTaxInc - salesSubtotalTax;
            //}
            //// 総額表示なし 伝票転嫁以外
            //else if (consTaxLayMethod != 0)
            //{
            //    //-----------------------------------------------------------------------------
            //    // ① 売上小計（税）：売上金額消費税額（外税） + 売上金額消費税額（内税） +  売上値引消費税額（外税） + 売上値引消費税額（内税）
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

            //    //-----------------------------------------------------------------------------
            //    // ② 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax;

            //    //-----------------------------------------------------------------------------
            //    // ③ 売上伝票合計（税込）：① + ②
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            //}
            //// 総額表示無しで、伝票転嫁
            //else
            //{
            //    //-----------------------------------------------------------------------------
            //    // ① 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax;

            //    //-----------------------------------------------------------------------------
            //    // ② 売上伝票合計（税込）： 売上内税対象額（税込） + 売上外税対象額 + 売上値引外税対象額合計 ＋ (売上外税対象額 + 売上値引外税対象額合計)×税率)
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

            //    //-----------------------------------------------------------------------------
            //    // ③ 売上小計（税）：② - ①
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

            //    //-----------------------------------------------------------------------------
            //    // ④ 売上金額消費税額（外税）：売上外税対象額 × 税率
            //    //-----------------------------------------------------------------------------
            //    salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

            //    //-----------------------------------------------------------------------------
            //    // ⑤ 売上金額消費税額（外税）(税抜、値引き含む) ：(売上外税対象額 + 売上値引外税対象額合計) × 税率
            //    //-----------------------------------------------------------------------------
            //    long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

            //    //-----------------------------------------------------------------------------
            //    // ⑥ 売上値引消費税額（外税）：④ - ⑤
            //    //-----------------------------------------------------------------------------
            //    salesDisOutTax = salesOutTax_All - salesOutTax;
            //}
            #endregion
        }

        // ---------------------------- ADD 陳健 2013/12/19 Redmine#41550 No.9----------------------------------->>>>>
        /// <summary>
        /// 受注明細の更新
        /// </summary>
        /// <param name="salesDetailDataTable"></param>
        /// <param name="consTaxRate"></param>
        private void UpdateAcptAnOrdDetailDT(SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailDataTable, SalesSlip salesSlip)
        {
            // 消費税端数処理コード(得意先マスタより取得)
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 消費税端数処理コード
            // 消費税端数処理単位、端数処理区分を取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            // ----------------------------------------------------------------
            // 障害現象
            // 受注伝票の場合、改定前の受注伝票は修正モードで呼び出す、売上日は改定後へ変更し、
            // 保存する際に、納品書に消費税が改定前の値で表示される
            // ----------------------------------------------------------------
            foreach (SalesInputDataSet.SalesDetailAcceptAnOrderRow row in salesDetailDataTable)
            {
                if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) // 商品が外税
                {
                    // -----------------------------------------------
                    // 明細データに税込の項目と消費税も更新する必要
                    // 更新しないと、下記の現象が発生
                    // 現象：得意先電子元帳にて検索して、「伝票表示」と「明細表示」の消費税が違う
                    // -----------------------------------------------
                    row.ListPriceTaxIncFl = row.ListPriceTaxExcFl + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.ListPriceTaxExcFl);
                    // 売上単価（税込）= 売上単価(税抜) + (売上単価(税抜) * 税率)
                    row.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxExcFl + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesUnPrcTaxExcFl);
                    // 売上金額（税込）= 売上金額(税抜) + (売上金額(税抜) * 税率)
                    row.SalesMoneyTaxInc = row.SalesMoneyTaxExc + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                    // 売上金額消費税額
                    row.SalesPriceConsTax = CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                }
            }
        }

        // ---------------------------- ADD 陳健 2013/12/19 Redmine#41550 No.9-----------------------------------<<<<<

        /// <summary>
        /// 指定した売上金額の値を元に売上明細行オブジェクトの金額情報を設定します（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="salesMoney">売上金額</param>
        /// <param name="salesRateClearFlag">単価情報クリアＦlag</param>
        // --- UPD 2009/12/23 ---------->>>>>
        //public void SalesDetailRowSalesMoneySetting(int salesRowNo, long salesMoney)
        public void SalesDetailRowSalesMoneySetting(int salesRowNo, long salesMoney, bool salesRateClearFlag)
        // --- UPD 2009/12/23 ----------<<<<<
        {
            // --- UPD 2009/12/23 ---------->>>>>
            //this.SalesDetailRowSalesMoneySetting(salesRowNo, salesMoney, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
            this.SalesDetailRowSalesMoneySetting(salesRowNo, salesMoney, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable, salesRateClearFlag);
            // --- UPD 2009/12/23 ----------<<<<<
        }

        /// <summary>
        /// 指定した売上金額の値を元に売上明細行オブジェクトの金額情報を設定します（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="salesMoney">売上金額</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブルオブジェクト</param>
        /// <param name="salesRateClearFlag">単価情報クリアＦlag</param>
        // --- UPD 2009/12/23 ---------->>>>>
        //public void SalesDetailRowSalesMoneySetting(int salesRowNo, long salesMoney, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        public void SalesDetailRowSalesMoneySetting(int salesRowNo, long salesMoney, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable, bool salesRateClearFlag)
        // --- UPD 2009/12/23 ----------<<<<<
        {
            #region ●初期処理
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            int sign = 1;
            if (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) sign = -1;
            salesMoney = salesMoney * sign;
            #endregion

            #region ●売上情報
            if (row != null)
            {
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    //-----------------------------------------------------
                    // 非課税
                    //-----------------------------------------------------
                    row.SalesMoneyTaxExc = salesMoney;
                    row.SalesMoneyTaxInc = salesMoney;
                }
                else if (this._salesSlip.TotalAmountDispWayCd == 0)
                {
                    //-----------------------------------------------------
                    // 総額表示しない
                    //-----------------------------------------------------
                    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            row.SalesMoneyTaxExc = salesMoney;
                            row.SalesMoneyTaxInc = salesMoney + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            row.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            row.SalesMoneyTaxExc = salesMoney;
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    //-----------------------------------------------------
                    // 総額表示する
                    //-----------------------------------------------------
                    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            row.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            row.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            row.SalesMoneyTaxExc = salesMoney;
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                    }
                }

                row.SalesPriceConsTax = row.SalesMoneyTaxInc - row.SalesMoneyTaxExc;

                // 単価情報クリア
                // --- UPD 2009/12/23 ---------->>>>>
                //this.ClearUnitInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                if (salesRateClearFlag == true)
                {
                    this.ClearUnitInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                }
                // --- UPD 2009/12/23 ----------<<<<<

                // 売上単価変更区分設定
                if (row.SalesUnPrcTaxExcFl != row.BfSalesUnitPrice)
                {
                    row.SalesUnPrcChngCd = 1; // 変更あり
                }
                else
                {
                    row.SalesUnPrcChngCd = 0; // 変更なし
                }
            }
            #endregion

            #region ●受注情報
            if (acptAnOdrRow != null)
            {
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    //-----------------------------------------------------
                    // 非課税
                    //-----------------------------------------------------
                    acptAnOdrRow.SalesMoneyTaxExc = salesMoney;
                    acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                }
                else if (this._salesSlip.TotalAmountDispWayCd == 0)
                {
                    //-----------------------------------------------------
                    // 総額表示しない
                    //-----------------------------------------------------
                    switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney;
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney;
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    //-----------------------------------------------------
                    // 総額表示する
                    //-----------------------------------------------------
                    switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney;
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                    }
                }

                acptAnOdrRow.SalesPriceConsTax = acptAnOdrRow.SalesMoneyTaxInc - acptAnOdrRow.SalesMoneyTaxExc;

                // 単価情報クリア
                // --- UPD 2009/12/23 ---------->>>>>
                //this.ClearUnitInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                if (salesRateClearFlag == true)
                {
                    this.ClearUnitInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                }
                // --- UPD 2009/12/23 ----------<<<<<

                // 売上単価変更区分設定
                if (acptAnOdrRow.SalesUnPrcTaxExcFl != acptAnOdrRow.BfSalesUnitPrice)
                {
                    acptAnOdrRow.SalesUnPrcChngCd = 1; // 変更あり
                }
                else
                {
                    acptAnOdrRow.SalesUnPrcChngCd = 0; // 変更なし
                }
            }
            #endregion
        }

        /// <summary>
        /// 売上金額を計算します。（明細部金額）（オーバーロード）
        /// </summary>
        /// <param name="rowIndex">対象行Index</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブル</param>
        private void CalculationSalesMoney(int rowIndex, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            SalesInputDataSet.SalesDetailRow salesDetailRow = salesDetailDataTable[rowIndex];
            this.CalculationSalesMoney(salesDetailRow, salesDetailDataTable, salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 売上金額を計算します。（明細部金額）（オーバーロード）
        /// </summary>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="rowNo">対象行番号</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブル</param>
        private void CalculationSalesMoney(string salesSlipNum, int rowNo, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            SalesInputDataSet.SalesDetailRow salesDetailRow = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, rowNo);
            this.CalculationSalesMoney(salesDetailRow, salesDetailDataTable, salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 売上金額を計算します。（明細部金額）（オーバーロード）
        /// </summary>
        /// <param name="salesDetailRow">売上明細データ行オブジェクト</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブル</param>
        /// <remarks>
        /// <br>Call：商品検索／定価／売単価／売価率／原単価／原価率／売上金額 変更時</br>
        /// </remarks>
        private void CalculationSalesMoney(SalesInputDataSet.SalesDetailRow salesDetailRow, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ●初期処理
            SalesSlip salesSlip = this.SalesSlip;
            if (salesSlip == null) return;
            int sign = (salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;

            // 受注明細行オブジェクト取得
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(salesDetailRow.DtlRelationGuid);
            #endregion

            #region ●金額算定
            switch ((SalesGoodsCd)salesDetailRow.SalesGoodsCd)
            {
                // 商品
                case SalesGoodsCd.Goods:

                    #region ●売上情報
                    long salesMoneyTaxInc;
                    long salesMoneyTaxExc;
                    long salesMoneyDisplay;

                    if (this.CalculationSalesMoney(salesSlip, salesDetailRow, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay))
                    {
                        salesDetailRow.SalesMoneyTaxExc = salesMoneyTaxExc;        // 外税
                        salesDetailRow.SalesMoneyTaxInc = salesMoneyTaxInc;        // 内税
                        salesDetailRow.SalesPriceConsTax = (long)((decimal)salesMoneyTaxInc - (decimal)salesMoneyTaxExc);
                        salesDetailRow.SalesMoneyDisplay = salesMoneyDisplay * sign;
                    }
                    #endregion

                    #region ●受注情報
                    if (acptAnOdrRow != null)
                    {
                        if (this.CalculationSalesMoney(salesSlip, acptAnOdrRow, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay))
                        {
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoneyTaxExc;        // 外税
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoneyTaxInc;        // 内税
                            acptAnOdrRow.SalesPriceConsTax = (long)((decimal)salesMoneyTaxInc - (decimal)salesMoneyTaxExc);
                            acptAnOdrRow.SalesMoneyDisplay = salesMoneyDisplay * sign;
                        }
                    }
                    #endregion
                    break;
                // 消費税調整
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                    salesDetailRow.SalesMoneyDisplay = salesDetailRow.SalesPriceConsTax;
                    break;
                // 残高調整
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    salesDetailRow.SalesMoneyDisplay = salesDetailRow.SalesMoneyTaxInc;
                    break;
            }
            #endregion
        }

        /// <summary>
        /// 売上金額を計算します。（明細部金額）（オーバーロード）
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailRow"></param>
        /// <param name="salesMoneyTaxInc"></param>
        /// <param name="salesMoneyTaxExc"></param>
        /// <param name="salesMoneyDisplay"></param>
        /// <returns></returns>
        public bool CalculationSalesMoney(SalesSlip salesSlip, SalesInputDataSet.SalesDetailRow salesDetailRow, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out long salesMoneyDisplay)
        {
            // 売上金額を算定
            double taxRate = salesSlip.ConsTaxRate;

            // 売上金額端数処理コード(得意先マスタより取得)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // 課税区分
            int taxationCode = salesDetailRow.TaxationDivCd;

            double salesUnPrc = 0;// 売上単価(税抜)
            if ((salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) || // 内税
                (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)) // 総額表示する(総額表示する場合、内税計算を行う)
            {
                // 内税
                salesUnPrc = salesDetailRow.SalesUnPrcTaxIncFl;
            }
            else
            {
                // 外税/非課税
                salesUnPrc = salesDetailRow.SalesUnPrcTaxExcFl;
            }

            // 非課税
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // 総額表示時は内税で計算する
            else if (this._salesSlip.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.TotalAmount)
            {
                // 総額表示する
                if (salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                }
            }
            bool ret = true;
            if ((salesDetailRow.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount) && (salesDetailRow.ShipmentCnt == 0)) // 行値引き
            {
                salesMoneyTaxInc = salesDetailRow.SalesMoneyTaxInc;
                salesMoneyTaxExc = salesDetailRow.SalesMoneyTaxExc;
            }
            else if (salesDetailRow.SalesMoneyInputDiv == (int)SalesMoneyInputDiv.Input) // 売上金額手入力
            {
                int sign = (salesDetailRow.ShipmentCnt < 0) ? -1 : 1;
                salesMoneyTaxInc = Math.Abs(salesDetailRow.SalesMoneyTaxInc) * sign;
                salesMoneyTaxExc = Math.Abs(salesDetailRow.SalesMoneyTaxExc) * sign;
            }
            else
            {
                int sign = (salesSlip.SalesSlipCd == (int)SalesSlipCd.RetGoods) ? -1 : 1;
                ret = this.CalculationSalesMoney(
                    salesDetailRow.ShipmentCntDisplay * sign,
                    salesUnPrc,
                    taxationCode,
                    taxRate,
                    salesMoneyFrcProcCode,
                    salesCnsTaxFrcProcCd,
                    out salesMoneyTaxInc,
                    out salesMoneyTaxExc);
            }

            if ((salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) ||
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
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
        /// 売上金額を計算します。（明細部金額）
        /// </summary>
        /// <param name="shipmentCnt">数量</param>
        /// <param name="salesUnitPrice">単価</param>
        /// <param name="taxationDivCd">課税区分</param>
        /// <param name="salesMoneyTaxInc">金額(税込)</param>
        /// <param name="salesMoneyTaxExc">金額(税抜)</param>
        /// <param name="salesMoneyDisplay">金額(表示)</param>
        /// <returns></returns>
        public bool CalculationSalesMoney(double shipmentCnt, double salesUnitPrice, int taxationDivCd, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out long salesMoneyDisplay)
        {
            // 売上金額を算定
            double taxRate = this._salesSlip.ConsTaxRate;

            // 売上金額端数処理コード(得意先マスタより取得)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // 非課税
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // 総額表示時は内税で計算する
            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
            {
                if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) taxationDivCd = (int)CalculateTax.TaxationCode.TaxInc;
            }

            bool ret = this.CalculationSalesMoney(
                shipmentCnt,
                salesUnitPrice,
                taxationDivCd,
                taxRate,
                salesMoneyFrcProcCode,
                salesCnsTaxFrcProcCd,
                out salesMoneyTaxInc,
                out salesMoneyTaxExc);

            if ((taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) ||
                (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
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
        /// 売上金額を計算します。（明細部金額）（受注情報）（オーバーロード）
        /// </summary>
        /// <param name="acptAnOdrRow"></param>
        private void CalculationSalesMoney(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow)
        {
            #region ●初期処理
            SalesSlip salesSlip = this.SalesSlip;
            if (salesSlip == null) return;
            #endregion

            #region ●金額算定
            if (acptAnOdrRow != null)
            {
                long salesMoneyTaxInc;
                long salesMoneyTaxExc;
                long salesMoneyDisplay;

                if (this.CalculationSalesMoney(salesSlip, acptAnOdrRow, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay))
                {
                    acptAnOdrRow.SalesMoneyTaxExc = salesMoneyTaxExc;        // 外税
                    acptAnOdrRow.SalesMoneyTaxInc = salesMoneyTaxInc;        // 内税
                    acptAnOdrRow.SalesPriceConsTax = (long)((decimal)salesMoneyTaxInc - (decimal)salesMoneyTaxExc);
                    acptAnOdrRow.SalesMoneyDisplay = salesMoneyDisplay;
                }
            }
            #endregion
        }

        /// <summary>
        /// 売上金額を計算します。（明細部金額）（受注情報）（オーバーロード）
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailRow"></param>
        /// <param name="salesMoneyTaxInc"></param>
        /// <param name="salesMoneyTaxExc"></param>
        /// <param name="salesMoneyDisplay"></param>
        /// <returns></returns>
        public bool CalculationSalesMoney(SalesSlip salesSlip, SalesInputDataSet.SalesDetailAcceptAnOrderRow salesDetailRow, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out long salesMoneyDisplay)
        {
            double taxRate = salesSlip.ConsTaxRate;

            // 売上金額端数処理コード(得意先マスタより取得)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // 課税区分
            int taxationCode = salesDetailRow.TaxationDivCd;

            double salesUnPrc = 0;// 売上単価(税抜)
            if ((salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) || // 内税
                (this._salesSlip.TotalAmountDispWayCd == 1)) // 総額表示する(総額表示する場合、内税計算を行う)
            {
                // 内税
                salesUnPrc = salesDetailRow.SalesUnPrcTaxIncFl;
            }
            else
            {
                // 外税/非課税
                salesUnPrc = salesDetailRow.SalesUnPrcTaxExcFl;
            }

            // 非課税
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // 総額表示時は内税で計算する
            else if (this._salesSlip.TotalAmountDispWayCd == 1)
            {
                // 総額表示する
                if (salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                }
            }


            bool ret = true;
            if ((salesDetailRow.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount) && (salesDetailRow.ShipmentCnt == 0)) // 行値引き
            {
                salesMoneyTaxInc = salesDetailRow.SalesMoneyTaxInc;
                salesMoneyTaxExc = salesDetailRow.SalesMoneyTaxExc;
            }
            else if (salesDetailRow.SalesMoneyInputDiv == (int)SalesMoneyInputDiv.Input) // 売上金額手入力
            {
                int sign = (salesDetailRow.ShipmentCnt < 0) ? -1 : 1;
                salesMoneyTaxInc = Math.Abs(salesDetailRow.SalesMoneyTaxInc) * sign;
                salesMoneyTaxExc = Math.Abs(salesDetailRow.SalesMoneyTaxExc) * sign;
            }
            else
            {
                int sign = (salesSlip.SalesSlipCd == (int)SalesSlipCd.RetGoods) ? -1 : 1;
                ret = this.CalculationSalesMoney(
                    salesDetailRow.AcceptAnOrderCntDisplay,
                    salesUnPrc,
                    taxationCode,
                    taxRate,
                    salesMoneyFrcProcCode,
                    salesCnsTaxFrcProcCd,
                    out salesMoneyTaxInc,
                    out salesMoneyTaxExc);
            }

            if ((salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) ||
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
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
        /// 売上金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="salesDetailList"></param>
        public void CalculationSalesMoney(List<SalesDetail> salesDetailList)
        {
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                this.CalculationSalesMoney(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);
            }
        }

        /// <summary>
        /// 売上金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="rowIndex">対象行Index</param>
        /// <remarks>
        /// <br>Call：商品検索／定価／売単価／売価率／原単価／原価率／売上金額 変更時</br>
        /// </remarks>
        public void CalculationSalesMoney(int rowIndex)
        {
            this.CalculationSalesMoney(rowIndex, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 売上金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="rowNo">行番号</param>
        /// <remarks>
        /// <br>Call：商品検索／定価／売単価／売価率／原単価／原価率／売上金額 変更時</br>
        /// </remarks>
        public void CalculationSalesMoney(string salesSlipNum, int rowNo)
        {
            this.CalculationSalesMoney(salesSlipNum, rowNo, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 売上金額を計算します。
        /// </summary>
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
        private bool CalculationSalesMoney(double shipmentCnt, double salesUnPrcTaxExcFl, int taxationCode, double taxRate, int salesMoneyFrcProcCd, int taxFrac, out long salesMoneyTaxInc, out long salesMoneyTaxExc)
        {
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
            if ((shipmentCnt == 0) || (salesUnPrcTaxExcFl == 0)) return true;

            switch ((CalculateTax.TaxationCode)taxationCode)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // 外税
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    
                    salesMoneyTaxInc = priceInc;		        // 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		        // 売上金額（税抜き）		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // 内税
                    //---------------------------------
                    unitPriceInc = salesUnPrcTaxExcFl;	// 単価（税込み）
                    priceInc = 0;					        // 価格（税込み）

                    this._salesPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceInc;		        // 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		        // 売上金額（税抜き）
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // 非課税
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceExc;		// 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		// 売上金額（税込み）
                    break;
            }

            this._salesSlip.FractionProcCd = taxFracProcCd;
            return true;
        }

        /// <summary>
        /// 指定した原価金額の値を元に売上明細行オブジェクトの金額情報を設定します（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        public void SalesDetailRowCostSetting(int salesRowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            this.SalesDetailRowCostSetting(salesRowNo, row.Cost, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 指定した原価金額の値を元に売上明細行オブジェクトの金額情報を設定します（オーバーロード）
        /// </summary>
        /// <param name="salesRowNo">行番号</param>
        /// <param name="cost">原価金額</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブルオブジェクト</param>
        public void SalesDetailRowCostSetting(int salesRowNo, long cost, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ●初期処理
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // 消費税端数処理単位、区分取得
            int taxFrac = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd); // ゼロ固定
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFrac, 0, out taxFracProcUnit, out taxFracProcCd);

            #endregion

            #region ●売上情報
            if (row != null)
            {
                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                {
                    case CalculateTax.TaxationCode.TaxExc:
                        row.CostTaxExc = cost;
                        row.CostTaxInc = cost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, cost);
                        break;
                    case CalculateTax.TaxationCode.TaxInc:
                        row.CostTaxExc = cost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, cost);
                        row.CostTaxInc = cost;
                        break;
                    case CalculateTax.TaxationCode.TaxNone:
                        row.CostTaxExc = cost;
                        row.CostTaxInc = cost;
                        break;
                    default:
                        break;
                }

                // 単価情報クリア
                this.ClearUnitInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);

                // 原価単価変更区分設定
                if (row.SalesUnitCostTaxExc != row.BfUnitCost)
                {
                    row.SalesUnitCostChngDiv = 1; // 変更あり
                }
                else
                {
                    row.SalesUnitCostChngDiv = 0; // 変更なし
                }
            }
            #endregion

            #region ●受注情報
            if (acptAnOdrRow != null)
            {
                switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                {
                    case CalculateTax.TaxationCode.TaxExc:
                        acptAnOdrRow.CostTaxExc = cost;
                        acptAnOdrRow.CostTaxInc = cost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, cost);
                        break;
                    case CalculateTax.TaxationCode.TaxInc:
                        acptAnOdrRow.CostTaxExc = cost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, cost);
                        acptAnOdrRow.CostTaxInc = cost;
                        break;
                    case CalculateTax.TaxationCode.TaxNone:
                        acptAnOdrRow.CostTaxExc = cost;
                        acptAnOdrRow.CostTaxInc = cost;
                        break;
                    default:
                        break;
                }

                // 単価情報クリア
                this.ClearUnitInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);

                // 原価単価変更区分設定
                if (acptAnOdrRow.SalesUnitCostTaxExc != acptAnOdrRow.BfUnitCost)
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 1; // 変更あり
                }
                else
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 0; // 変更なし
                }
            }
            #endregion
        }

        /// <summary>
        /// 原価金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="salesDetailList"></param>
        public void CalculationCost(List<SalesDetail> salesDetailList)
        {
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                this.CalculationCost(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);
            }
        }

        /// <summary>
        /// 原価金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="rowIndex">対象行Index</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブルオブジェクト</param>
        private void CalculationCost(int rowIndex, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            SalesInputDataSet.SalesDetailRow salesDetailRow = salesDetailDataTable[rowIndex];
            this.CalculationCost(salesDetailRow, salesDetailDataTable, salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 原価金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="rowIndex">行番号</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブルオブジェクト</param>
        private void CalculationCost(string salesSlipNum, int rowNo, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            SalesInputDataSet.SalesDetailRow salesDetailRow = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, rowNo);
            this.CalculationCost(salesDetailRow, salesDetailDataTable, salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 原価金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="salesDetailRow">売上明細データ行オブジェクト</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブル</param>
        private void CalculationCost(SalesInputDataSet.SalesDetailRow salesDetailRow, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ●初期処理
            // 受注明細行オブジェクト取得
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(salesDetailRow.DtlRelationGuid);

            // 入力チェック
            //if (string.IsNullOrEmpty(salesDetailRow.GoodsName)) return;
            if ((salesDetailRow.EditStatus == ctEDITSTATUS_RowDiscount) || (salesDetailRow.EditStatus == ctEDITSTATUS_Annotation)) return;

            SalesSlip salesSlip = this.SalesSlip;
            if (salesSlip == null) return;
            #endregion

            #region ●金額算定
            switch ((SalesGoodsCd)salesDetailRow.SalesGoodsCd)
            {
                // 商品
                case SalesGoodsCd.Goods:

                    // 原価金額を算定
                    long costTaxInc;
                    long costTaxExc;
                    long costDisplay;
                    double taxRate = salesSlip.ConsTaxRate;

                    // 課税区分
                    int taxationCode = salesDetailRow.TaxationDivCd;

                    double salesUnitCost = 0;

                    switch ((CalculateTax.TaxationCode)salesDetailRow.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            salesUnitCost = salesDetailRow.SalesUnitCostTaxExc;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            salesUnitCost = salesDetailRow.SalesUnitCostTaxInc;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            salesUnitCost = salesDetailRow.SalesUnitCostTaxExc;
                            break;
                    }

                    // 非課税
                    if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    // 内税
                    else if ((taxationCode != (int)CalculateTax.TaxationCode.TaxNone) &&
                             (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                    }

                    #region ●売上情報
                    int sign = (salesSlip.SalesSlipCd == (int)SalesSlipCd.RetGoods) ? -1 : 1;
                    if (this.CalculationCost(
                        salesDetailRow.SalesRowNo,
                        salesDetailRow.ShipmentCntDisplay * sign,
                        salesUnitCost,
                        taxationCode,
                        taxRate,
                        out costTaxInc,
                        out costTaxExc,
                        out costDisplay))
                    {
                        salesDetailRow.CostTaxExc = costTaxExc;        // 外税
                        salesDetailRow.CostTaxInc = costTaxInc;        // 内税
                        salesDetailRow.Cost = costDisplay;
                    }
                    #endregion

                    #region ●受注情報
                    if (acptAnOdrRow != null)
                    {
                        if (this.CalculationCost(
                            acptAnOdrRow.SalesRowNo,
                            acptAnOdrRow.AcceptAnOrderCntDisplay,
                            salesUnitCost,
                            taxationCode,
                            taxRate,
                            out costTaxInc,
                            out costTaxExc,
                            out costDisplay))
                        {
                            acptAnOdrRow.CostTaxExc = costTaxExc;        // 外税
                            acptAnOdrRow.CostTaxInc = costTaxInc;        // 内税
                            acptAnOdrRow.Cost = costDisplay;
                        }
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
            #endregion
        }

        /// <summary>
        /// 原価金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="rowIndex">対象行Index</param>
        /// <remarks>
        /// <br>Call：商品検索／定価／原単価／原価率 変更時</br>
        /// </remarks>
        public void CalculationCost(int rowIndex)
        {
            this.CalculationCost(rowIndex, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 原価金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="rowNo">行番号</param>
        /// <remarks>
        /// <br>Call：商品検索／定価／原単価／原価率 変更時</br>
        /// </remarks>
        public void CalculationCost(string salesSlipNum, int rowNo)
        {
            this.CalculationCost(salesSlipNum, rowNo, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// 原価金額を計算します。（オーバーロード）
        /// </summary>
        /// <param name="salesDetailRow">売上明細データ行オブジェクト</param>
        /// <param name="salesDetailDataTable">売上明細データテーブル</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブル</param>
        private void CalculationCost(SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow)
        {
            #region ●初期処理
            // 入力チェック
            if ((acptAnOdrRow.EditStatus == ctEDITSTATUS_RowDiscount) || (acptAnOdrRow.EditStatus == ctEDITSTATUS_Annotation)) return;

            SalesSlip salesSlip = this.SalesSlip;
            if (salesSlip == null) return;
            #endregion

            #region ●金額算定
            // 原価金額を算定
            long costTaxInc;
            long costTaxExc;
            long costDisplay;
            double taxRate = salesSlip.ConsTaxRate;

            // 課税区分
            int taxationCode = acptAnOdrRow.TaxationDivCd;

            double salesUnitCost = 0;

            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    salesUnitCost = acptAnOdrRow.SalesUnitCostTaxExc;
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    salesUnitCost = acptAnOdrRow.SalesUnitCostTaxInc;
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    salesUnitCost = acptAnOdrRow.SalesUnitCostTaxExc;
                    break;
            }

            // 非課税
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // 内税
            else if ((taxationCode != (int)CalculateTax.TaxationCode.TaxNone) &&
                     (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
            }

            #region ●受注情報
            if (acptAnOdrRow != null)
            {
                if (this.CalculationCost(
                    acptAnOdrRow.SalesRowNo,
                    acptAnOdrRow.AcceptAnOrderCntDisplay,
                    salesUnitCost,
                    taxationCode,
                    taxRate,
                    out costTaxInc,
                    out costTaxExc,
                    out costDisplay))
                {
                    acptAnOdrRow.CostTaxExc = costTaxExc;        // 外税
                    acptAnOdrRow.CostTaxInc = costTaxInc;        // 内税
                    acptAnOdrRow.Cost = costDisplay;
                }
            }
            #endregion
            #endregion
        }

        /// <summary>
        /// 原価金額を計算します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
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
        private bool CalculationCost(int salesRowNo, double shipmentCnt, double SalesUnitCostTaxExc, int taxationCode, double taxRate, out long costInc, out long costExc, out long costDisplay)
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

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            // 原価金額端数処理コード
            int costFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);

            // 消費税端数処理単位、区分取得
            int taxFrac = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;

            // 出荷数が0または売上単価が0の場合はすべて0で終了
            if ((shipmentCnt == 0) || (SalesUnitCostTaxExc == 0)) return true;

            switch ((CalculateTax.TaxationCode)taxationCode)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // 外税
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd);
                    costInc = priceInc;		        // 売上金額（税込み）
                    costExc = priceExc;		        // 売上金額（税抜き）		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // 内税
                    //---------------------------------
                    unitPriceInc = SalesUnitCostTaxExc;	    // 単価（税込み）
                    priceInc = 0;					        // 価格（税込み）

                    //this._salesPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    costInc = priceInc;		        // 売上金額（税込み）
                    costExc = priceExc;		        // 売上金額（税抜き）
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // 非課税
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd);
                    
                    costInc = priceExc;		// 売上金額（税込み）
                    costExc = priceExc;		// 売上金額（税込み）
                    break;
            }

            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc) // 課税区分 // 原価は総額表示区分によらない
            {
                costDisplay = costInc;
            }
            else
            {
                costDisplay = costExc;
            }

            return true;
        }

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// 指定した商品情報オブジェクトを元に単価算出部品より商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="reCalcUnitInfoDiv">掛率再取得区分(true:再取得する false:再取得しない)</param>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalclationUnitPrice(row, goodsUnitData);
            this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, reCalcUnitInfoDiv, unitPriceCalcRetList);
        }

        //  --------- ADD 2011/09/05 -------------- >>>>>
        /// <summary>
        /// 指定した商品情報オブジェクトを元に単価算出部品より商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="reCalcUnitInfoDiv">掛率再取得区分(true:再取得する false:再取得しない)</param>
        private void SalesDetailRowGoodsPriceForSalesCodeCheck(SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalclationUnitPrice(row, goodsUnitData);
            this.SalesDetailRowGoodsPriceForSalesCodeCheck(row, goodsUnitData, reCalcUnitInfoDiv, unitPriceCalcRetList);
        }
        //  --------- ADD 2011/09/05 -------------- <<<<<

        /// <summary>
        /// 指定した商品情報オブジェクトを元に単価算出部品より商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="reCalcUnitInfoDiv">掛率再取得区分(true:再取得する false:再取得しない)</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <br>Update Note: 2011/05/30 曹文傑</br>
        /// <br>             やキャンペーン売価を取得するように変更</br>
        /// <br>UpdateNote : 2011/07/11 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
        /// <br>UpdateNote : 2011/07/13 曹文傑 Redmine#22953 標準価格＝０、売上伝票入力で０除算のエラーメッセージが表示しません</br>
        /// <br>                               Redmine#22773 [売価未設定時区分＝ゼロを表示]、掛率なし、キャンペーン値引率≠0の場合の不具合修正</br>
        /// <br>UpdateNote : 2011/07/14 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
        /// <br>UpdateNote : 2011/08/15 譚洪 Redmine#23554 キャンペーンの売価「売価率、値引率、売価額」が設定されている場合は、掛率マスタの売価の設定をクリアするように仕様変更の対応</br>
        /// <br>UpdateNote : 2011/08/31 許雁波 連番721 Redmine#23887</br>
        /// <br>Update Note: 2011/09/01 連番681 yangmj 10704766-00 </br>
        /// <br>             Redmine#23723 提供定価とユーザー定価が一致しない場合、文字色の改修</br>
        /// <br>UpdateNote : 2011/09/05 yangmj Redmine#23554 キャンペーンの売価「売価率、値引率、売価額」が設定されている場合は、掛率マスタの売価の設定をクリアするように仕様変更の対応</br>
        /// <br>UpdateNote : 2011/09/14 譚洪 Redmine#25016 提供の純正品番で、売価率が登録されている＆キャンペーン売率が登録されている場合、売単価が空白になり不正の修正</br>
        /// <br>UpdateNote : 2011/09/16 譚洪 Redmine#25195 売上伝票入力で売単価がクリアされてしまうの対応</br>
        /// <br>UpdateNote : 2011/09/21 yangmj Redmine#25261 元伝票を指定しての返品時動作の修正</br>
        /// <br>Update Note: 2012/02/28 鄧潘ハン</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#27385 原価の金額が不正についての対応</br>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv, List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            bool salesUnitPriceFlg = false;
            bool salesUnitCostFlg = false;
            bool listPriceFlg = false;
            bool salesUnitCostCalcRetFlg = false; // 2010/07/29

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet != null)
                {
                    #region ●売単価
                    //--------------------------------------------
                    // 売単価
                    //--------------------------------------------
                    string unitPriceKind = unitPriceCalcRet.UnitPriceKind;

                    if (UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice == unitPriceKind)
                    {
                        double salesUnitPrice = 0;
                        salesUnitPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            //--------------------------------------------
                            // 商品価格課税区分「外税」
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                            //--------------------------------------------
                            // 商品価格課税区分「内税」
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitPrice = row.SalesUnPrcTaxIncFl;
                                break;
                            //--------------------------------------------
                            // 商品価格課税区分「非課税」
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                        }

                        // 売価を手入力で変更している場合は掛率再取得は行わない
                        //if (salesUnitPrice == row.BfSalesUnitPrice)
                        // 掛率設定区分と基準価格が設定されている場合は、掛率再取得
                        // --- UPD m.suzuki 2011/02/16 ---------->>>>>
                        //if ((reCalcUnitInfoDiv == true) ||
                        //    ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))))
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0) || (_noneResettingListPriceFlag))))
                        // --- UPD m.suzuki 2011/02/16 ----------<<<<<
                        //if (row.SalesUnPrcTaxExcFl == row.BfSalesUnitPrice)
                        {
                            row.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                            row.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;       // 掛率設定区分
                            row.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;      // 単価算出区分
                            row.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;                // 価格区分

                            // --- ADD 2011/09/16 ------- >>>>>>>
                            if (row.SupplierCdChgFlg == 1)
                            {
                                //定価の掛率マスタ情報を取得できる場合
                                //または定価の掛率マスタ情報を取得できない、且つ単価算出区分（売上単価）＝(2:原価ＵＰ率 OR 3:粗利率)の場合
                                if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) ||
                                    (string.IsNullOrEmpty(row.RateDivLPrice.Trim()) && (row.UnPrcCalcCdSalUnPrc == 2 || row.UnPrcCalcCdSalUnPrc == 3)))
                                {
                                    row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // 基準単価
                                    row.SalesRate = 0;
                                }
                            }
                            else
                            {
                                row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;
                            }
                            // --- ADD 2011/09/16 ------- <<<<<<<

                            // --- DEL 2011/09/16 ------- >>>>>>>
                            //row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // 基準単価  //DEL 連番721 2011/08/31
                            // --------------- ADD 連番721 2011/08/31 ----------------- >>>>>
                            //定価の掛率マスタ情報を取得できる場合
                            //または定価の掛率マスタ情報を取得できない、且つ単価算出区分（売上単価）＝(2:原価ＵＰ率 OR 3:粗利率)の場合
                            //if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) ||
                            //    (string.IsNullOrEmpty(row.RateDivLPrice.Trim()) && (row.UnPrcCalcCdSalUnPrc == 2 || row.UnPrcCalcCdSalUnPrc == 3)))
                            //{
                            //    row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // 基準単価
                            //}
                            // --------------- ADD 連番721 2011/08/31 ----------------- <<<<<
                            // --- DEL 2011/09/16 ------- <<<<<<<

                            row.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // 売単価(税抜)
                            row.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;    // 売単価(税込)
                            row.SalesRate = 0; // --- ADD 2015/09/03 Y.Wakita 社内障害№711 
                            switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                            {
                                // 基準価格×売価率
                                case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                    row.SalesRate = unitPriceCalcRet.RateVal;                       // 売価率
                                    break;
                                // 原価UP率
                                case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                    row.CostUpRate = unitPriceCalcRet.RateVal;                      // 原価UP率
                                    break;
                                // 粗利確保率
                                case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                    row.GrossProfitSecureRate = unitPriceCalcRet.RateVal;           // 粗利確保率
                                    break;
                                // 単価直接指定
                                case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                    row.SalesRate = 0;
                                    break;
                            }

                            // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
                            row.RateUpdateTimeSales = unitPriceCalcRet.RateUpdateTimeSales;            // 掛率更新日
                            // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<

                            row.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;  // 端数処理単位
                            row.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;       // 端数処理区分
                            row.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;      // 変更前売価
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL商品コード(掛率)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // 商品掛率グループコード（掛率）
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // 商品掛率グループ名称（掛率）
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BLグループコード（掛率）
                            //row.RateBLGroupName = row.BLGroupName;                          // BLグループ名称（掛率）

                            //>>>2010/02/26
                            double price = row.SalesUnPrcTaxExcFl;
                            double priceTaxExc = 0;
                            double priceTaxInc = 0;

                            ////-----------------------------------------------------------------------------
                            //// 自動連携値引き価格反映
                            ////-----------------------------------------------------------------------------
                            //if (this._salesSlip.OnlineKindDiv == (int)OnlineKindDiv.SCM)
                            //{
                            //    this.ReflectAutoDiscount(row.TaxationDivCd, this._salesSlip.CustomerCode, row.GoodsMGroup, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, ref price);
                            //}

                            //-----------------------------------------------------------------------------
                            // キャンペーン価格反映
                            //-----------------------------------------------------------------------------
                            // ---UPD 2011/05/30------------>>>>>
                            //this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.GoodsMGroup, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, this._salesSlip.SalesDate, ref price);
                            this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, row.BLGroupCode, row.SalesCode, this._salesSlip.SalesDate, ref price);
                            if (this._campaignObjGoodsSt != null)
                            {
                                // キャンペーン価格適用
                                if (this._campaignObjGoodsSt.PriceFl != 0)
                                {
                                    price = this._campaignObjGoodsSt.PriceFl;
                                    row.SalesRate = 0;   // ADD 2011/08/15
                                }
                                // ---UPD 2011/07/14------------>>>>>
                                // キャンペーン売価率適用
                                if (this._campaignObjGoodsSt.RateVal != 0)
                                {
                                    //row.SalesRate = this._campaignObjGoodsSt.RateVal;
                                    //price = row.ListPriceDisplay * row.SalesRate / 100;
                                    row.SalesRate = this._campaignObjGoodsSt.RateVal;
                                    //double listPriceDisplay = row.ListPriceDisplay;  // DEL 2011/09/14
                                    //double listPriceDisplay = row.BfListPrice;       // ADD 2011/09/14//DEL 鄧潘ハン 2012/02/28 Redmine#27385
                                    double listPriceDisplay = row.ListPriceDisplay; //ADD 鄧潘ハン 2012/02/28 Redmine#27385

                                    this.CalclatePriceByRate(row.TaxationDivCd, this._campaignObjGoodsSt.RateVal, ref listPriceDisplay);
                                    price = listPriceDisplay;
                                }
                                // ADD 陳健 2014/03/20 -------------------------->>>>>
                                Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                                ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaUpdDateCtrl);

                                if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                                {
                                    row.RateUpdateTimeSales = this._campaignObjGoodsSt.UpdateDateTimeAdFormal;
                                }
                                // ADD 陳健 2014/03/20 --------------------------<<<<<

                                // キャンペーン値引率適用
                                if (this._campaignObjGoodsSt.DiscountRate != 0)
                                {
                                    this.CalclatePriceByRate(row.TaxationDivCd, 100 - this._campaignObjGoodsSt.DiscountRate, ref price);
                                    row.SalesRate = 0;  // ADD 2011/08/15
                                }

                                // ----- ADD 2011/07/11 ------- >>>>>>>>>
                                // ------UPD 2011/07/13-------------->>>>>
                                //if (this._campaignObjGoodsSt.PriceFl == 0)
                                //if (this._campaignObjGoodsSt.PriceFl == 0 && unitPriceCalcRet.UnPrcFracProcUnit != 0)
                                //// ------UPD 2011/07/13-------------->>>>>
                                //{
                                //    // 売単価（税抜）
                                //    FractionCalculate.FracCalcMoney(price, unitPriceCalcRet.UnPrcFracProcUnit, unitPriceCalcRet.UnPrcFracProcDiv, out price);
                                //}
                                // ----- ADD 2011/07/11 ------- <<<<<<<<<

                                //-----ADD 2011/09/05 ------>>>>>
                                row.CampaignCode = this._campaignObjGoodsSt.CampaignCode;
                                row.CampaignRate = this._campaignObjGoodsSt.RateVal;
                                row.CampaignDiscountRate = this._campaignObjGoodsSt.DiscountRate;
                                row.CampaignPriceFl = this._campaignObjGoodsSt.PriceFl;
                                row.CampaignSettingKind = this._campaignObjGoodsSt.CampaignSettingKind;  // ADD 2011/09/14
                                //-----ADD 2011/09/05 ------<<<<<
                            }
                            // ---UPD 2011/05/30------------<<<<<
                            // ---UPD 2011/07/14------------<<<<<

                            //-----------------------------------------------------------------------------
                            // 価格再セット
                            //-----------------------------------------------------------------------------
                            this.CalcTaxExcAndTaxInc(row.TaxationDivCd, this._salesSlip.CustomerCode, this._salesSlipInputInitDataAcs.TaxRate, this._salesSlip.TotalAmountDispWayCd, price, out priceTaxExc, out priceTaxInc);
                            row.SalesUnPrcTaxExcFl = priceTaxExc;
                            row.SalesUnPrcTaxIncFl = priceTaxInc;
                            //<<<2010/02/26

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) salesUnitPriceFlg = false;

                            //--------------------------------------------
                            // 非課税
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                            }
                            //--------------------------------------------
                            // 総額表示しない
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    //--------------------------------------------
                                    // 商品価格課税区分「外税」
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                    //--------------------------------------------
                                    // 商品価格課税区分「内税」
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                                        break;
                                    //--------------------------------------------
                                    // 商品価格課税区分「非課税」
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // 総額表示する
                            //--------------------------------------------
                            else
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            }
                        }
                    }
                    #endregion

                    #region ●原単価
                    //--------------------------------------------
                    // 原単価
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_UnitCost == unitPriceKind)
                    {
                        double salesUnitCost = 0;
                        salesUnitCostFlg = true;
                        salesUnitCostCalcRetFlg = true; // 2010/07/29
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitCost = row.SalesUnitCostTaxInc;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                        }

                        //if (salesUnitCost == row.BfUnitCost)
                        // 掛率設定区分と基準価格が設定されている場合は、掛率再取得
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))))
                        {
                            row.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                            row.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;          // 掛率設定区分
                            row.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;         // 単価算出区分
                            row.PriceCdUnCst = unitPriceCalcRet.PriceDiv;                   // 価格区分
                            row.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;              // 基準単価
                            row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // 原単価(税抜)
                            row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // 原単価(税込)
                            row.CostRate = unitPriceCalcRet.RateVal;                        // 原価率
                            row.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;     // 端数処理単位
                            row.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;          // 端数処理区分
                            row.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;            // 変更前原価
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL商品コード(掛率)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // 商品掛率グループコード（掛率）
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // 商品掛率グループ名称（掛率）
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BLグループコード（掛率）
                            //row.RateBLGroupName = row.BLGroupName;                          // BLグループ名称（掛率）
                            // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
                            row.RateUpdateTimeUnit = unitPriceCalcRet.RateUpdateTimeUnit;            // 掛率更新日
                            // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) salesUnitCostFlg = false;

                            //--------------------------------------------
                            // 非課税
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.SalesUnitCost = row.SalesUnitCostTaxExc;
                            }
                            //--------------------------------------------
                            // 総額表示しない
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // 総額表示する
                            //--------------------------------------------
                            else
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●定価
                    //--------------------------------------------
                    // 定価
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_ListPrice == unitPriceKind)
                    {
                        double listPrice = 0;
                        listPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                listPrice = row.ListPriceTaxIncFl;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                        }

                        // 掛率設定区分と基準価格が設定されている場合は、掛率再取得
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))))
                        {
                            row.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;          // 掛率設定拠点
                            row.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;         // 掛率設定区分
                            row.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;        // 単価算出区分
                            row.PriceCdLPrice = unitPriceCalcRet.PriceDiv;                  // 価格区分
                            row.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;             // 基準単価

                            // --- ADD 2011/09/16 ------- >>>>>>>
                            if (row.SupplierCdChgFlg == 1)
                            {
                                if (!string.IsNullOrEmpty(row.RateDivLPrice.Trim()))
                                {
                                    //定価掛率マスタ情報を取得できる場合
                                    row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)
                                }
                                else
                                {
                                    row.StdUnPrcSalUnPrc = row.ListPriceTaxExcFl;           // 基準単価(売単価)
                                }
                            }
                            else
                            {
                                row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;
                            }
                            // --- ADD 2011/09/16 ------- <<<<<<<<

                            // --- DEL 2011/09/16 ------- >>>>>>>
                            //row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)  //DEL 連番721 2011/08/31
                            // --------------- ADD 連番721 2011/08/31 ----------------- >>>>>
                            //if (!string.IsNullOrEmpty(row.RateDivLPrice.Trim()))
                            //{
                            //    //定価掛率マスタ情報を取得できる場合
                            //    row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)
                            //}
                            //else
                            //{
                            //    row.StdUnPrcSalUnPrc = row.ListPriceTaxExcFl;           // 基準単価(売単価)
                            //}
                            // --------------- ADD 連番721 2011/08/31 ----------------- <<<<<
                            // --- DEL 2011/09/16 ------- >>>>>>>

                            row.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;     // 定価(税込)
                            row.ListPriceRate = unitPriceCalcRet.RateVal;                   // 定価率
                            row.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;    // 端数処理単位
                            row.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;         // 端数処理区分
                            row.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;           // 変更前定価
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL商品コード(掛率)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // 商品掛率グループコード（掛率）
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // 商品掛率グループ名称（掛率）
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BLグループコード（掛率）
                            //row.RateBLGroupName = row.BLGroupName;                          // BLグループ名称（掛率）
                            row.OpenPriceDiv = unitPriceCalcRet.OpenPriceDiv;               // オープン価格区分

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) listPriceFlg = false;

                            //--------------------------------------------
                            // 非課税
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                            }
                            //--------------------------------------------
                            // 総額表示しない
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // 総額表示する
                            //--------------------------------------------
                            else
                            {
                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            }
                        }
                    }
                    #endregion
                }
            }
            //-----ADD 2011/09/01----->>>>>
            if (row.StdUnPrcUnCst == 0)
            {
                DateTime targetDate = new DateTime();

                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
                {
                    case AcptAnOdrStatusState.Estimate:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.UnitPriceEstimate:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.Sales:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.Shipment:
                        targetDate = this._salesSlip.ShipmentDay; // 出荷日
                        break;
                }

                //-----------------------------------------------------------------------
                // 価格情報が存在する場合は、価格情報から基準定価確定
                //-----------------------------------------------------------------------
                //if (goodsUnitData.GoodsPriceList != null)//DEL 2011/09/21
                if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)//ADD 2011/09/21
                {
                    object obj = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsUnitData.GoodsPriceList);
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        row.StdUnPrcUnCst = goodsPrice.ListPrice;             // 基準単価
                    }
                }                
            }
            //-----ADD 2011/09/01-----<<<<<
            #region 変更前売単価設定
            if (salesUnitPriceFlg == false)
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // ゼロ表示
                    case 0:
                        row.BfSalesUnitPrice = 0;
                        break;
                    // 定価表示
                    case 1:
                        row.BfSalesUnitPrice = row.ListPriceTaxExcFl;
                        break;
                    default:
                        row.BfSalesUnitPrice = 0;
                        break;
                }
            }
            #endregion

            #region 初期化
            if (salesUnitPriceFlg == false)
            {
                // 売単価
                row.RateSectSalUnPrc = string.Empty;    // 掛率設定拠点
                row.RateDivSalUnPrc = string.Empty;      // 掛率設定区分
                row.UnPrcCalcCdSalUnPrc = 0;   // 単価算出区分
                row.PriceCdSalUnPrc = 0;       // 価格区分
                row.StdUnPrcSalUnPrc = 0;      // 基準単価
                row.FracProcUnitSalUnPrc = 0;  // 端数処理単位
                row.FracProcSalUnPrc = 0;      // 端数処理区分

                //row.SalesUnPrcDisplay = 0;
                //row.SalesUnPrcTaxExcFl = 0;
                //row.SalesUnPrcTaxIncFl = 0;
                //row.SalesRate = 0;
                //row.CostUpRate = 0;
                //row.GrossProfitSecureRate = 0;

                row.SalesRate = 0; // 2010/07/28
            }
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //if (salesUnitCostFlg == false)
            if (salesUnitCostFlg == false && !_noneResettingUnitCostFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                // 原単価
                row.RateSectCstUnPrc = string.Empty;    // 掛率設定拠点
                row.RateDivUnCst = string.Empty;         // 掛率設定区分
                row.UnPrcCalcCdUnCst = 0;      // 単価算出区分
                row.PriceCdUnCst = 0;          // 価格区分
                //row.StdUnPrcUnCst = 0;         // 基準単価 // DEL 2011/09/01
                row.FracProcUnitUnCst = 0;     // 端数処理単位
                row.FracProcUnCst = 0;         // 端数処理区分

                //row.SalesUnitCost = 0;
                //row.SalesUnitCostTaxExc = 0;
                //row.SalesUnitCostTaxInc = 0;
                //row.CostRate = 0;

                //>>>2010/07/29
                ////>>>2010/07/28
                //row.CostRate = 0;
                //row.SalesUnitCost = 0;
                //row.SalesUnitCostTaxExc = 0;
                //row.SalesUnitCostTaxInc = 0;
                ////<<<2010/07/28

                row.CostRate = 0;
                if (salesUnitCostCalcRetFlg == false)
                {
                    row.SalesUnitCost = 0;
                    row.SalesUnitCostTaxExc = 0;
                    row.SalesUnitCostTaxInc = 0;
                }
                //<<<2010/07/29
            }
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //if (listPriceFlg == false)
            if (listPriceFlg == false && !_noneResettingListPriceFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                // 定価
                row.RateSectPriceUnPrc = string.Empty;  // 掛率設定拠点
                row.RateDivLPrice = string.Empty;        // 掛率設定区分
                row.UnPrcCalcCdLPrice = 0;     // 単価算出区分
                row.PriceCdLPrice = 0;         // 価格区分
                row.StdUnPrcLPrice = 0;        // 基準単価
                row.FracProcUnitLPrice = 0;    // 端数処理単位
                row.FracProcLPrice = 0;        // 端数処理区分

                //row.ListPriceDisplay = 0;
                //row.ListPriceTaxExcFl = 0;
                //row.ListPriceTaxIncFl = 0;
                //row.ListPriceRate = 0;
            }
            if ((salesUnitPriceFlg == false) &&
                (salesUnitCostFlg == false) &&
                (listPriceFlg == false))
            {
                //row.RateBLGoodsCode = 0;                          // BL商品コード(掛率)
                //row.RateBLGoodsName = string.Empty;               // BL商品コード名称(掛率)
                //row.RateGoodsRateGrpCd = 0;                       // 商品掛率グループコード（掛率）
                //row.RateGoodsRateGrpNm = string.Empty;            // 商品掛率グループ名称（掛率）
                //row.RateBLGroupCode = 0;                          // BLグループコード（掛率）
                //row.RateBLGroupName = string.Empty;               // BLグループ名称（掛率）
            }

            // ADD 2011/08/15 ---- >>>>>
            //if (this._campaignObjGoodsSt != null)
            //{
            //    // 掛率算出情報クリア
            //    this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            //}
            // ADD 2011/08/15 ---- <<<<<
            #endregion

            this.SalesDetailRowUnitPriceSetting(ref row, goodsUnitData);

            // ADD 2011/08/15 ---- >>>>>
            if (this._campaignObjGoodsSt != null)
            {
                // 掛率算出情報クリア
                //this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);// DEL 2011/09/05
                this.ClearRateInfoForCampaign(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);// ADD 2011/09/05
            }
            // ADD 2011/08/15 ---- <<<<<
        }

        // ------ ADD 2011/09/05 -------- >>>>>
        /// <summary>
        /// 指定した商品情報オブジェクトを元に単価算出部品より商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="reCalcUnitInfoDiv">掛率再取得区分(true:再取得する false:再取得しない)</param>
        /// <param name="unitPriceCalcRetList">単価算出結果リスト</param>
        /// <br>Update Note: 2011/05/30 曹文傑</br>
        /// <br>             やキャンペーン売価を取得するように変更</br>
        /// <br>UpdateNote : 2011/07/11 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
        /// <br>UpdateNote : 2011/07/13 曹文傑 Redmine#22953 標準価格＝０、売上伝票入力で０除算のエラーメッセージが表示しません</br>
        /// <br>                               Redmine#22773 [売価未設定時区分＝ゼロを表示]、掛率なし、キャンペーン値引率≠0の場合の不具合修正</br>
        /// <br>UpdateNote : 2011/07/14 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
        /// <br>UpdateNote : 2011/08/15 譚洪 Redmine#23554 キャンペーンの売価「売価率、値引率、売価額」が設定されている場合は、掛率マスタの売価の設定をクリアするように仕様変更の対応</br>
        private void SalesDetailRowGoodsPriceForSalesCodeCheck(SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv, List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            bool salesUnitPriceFlg = false;
            bool salesUnitCostFlg = false;
            bool listPriceFlg = false;
            bool salesUnitCostCalcRetFlg = false; // 2010/07/29

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet != null)
                {
                    #region ●売単価
                    //--------------------------------------------
                    // 売単価
                    //--------------------------------------------
                    string unitPriceKind = unitPriceCalcRet.UnitPriceKind;

                    if (UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice == unitPriceKind)
                    {
                        double salesUnitPrice = 0;
                        salesUnitPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            //--------------------------------------------
                            // 商品価格課税区分「外税」
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                            //--------------------------------------------
                            // 商品価格課税区分「内税」
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitPrice = row.SalesUnPrcTaxIncFl;
                                break;
                            //--------------------------------------------
                            // 商品価格課税区分「非課税」
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                        }

                        // 売価を手入力で変更している場合は掛率再取得は行わない
                        // 掛率設定区分と基準価格が設定されている場合は、掛率再取得
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0) || (_noneResettingListPriceFlag))))
                        {
                            row.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                            row.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;       // 掛率設定区分
                            row.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;      // 単価算出区分
                            row.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;                // 価格区分
                            row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // 基準単価
                            row.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // 売単価(税抜)
                            row.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;    // 売単価(税込)
                            row.SalesRate = 0; // --- ADD 2015/09/03 Y.Wakita 社内障害№711 
                            switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                            {
                                // 基準価格×売価率
                                case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                    row.SalesRate = unitPriceCalcRet.RateVal;                       // 売価率
                                    break;
                                // 原価UP率
                                case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                    row.CostUpRate = unitPriceCalcRet.RateVal;                      // 原価UP率
                                    break;
                                // 粗利確保率
                                case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                    row.GrossProfitSecureRate = unitPriceCalcRet.RateVal;           // 粗利確保率
                                    break;
                                // 単価直接指定
                                case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                    row.SalesRate = 0;
                                    break;
                            }
                            row.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;  // 端数処理単位
                            row.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;       // 端数処理区分
                            row.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;      // 変更前売価
                            double price = row.SalesUnPrcTaxExcFl;
                            double priceTaxExc = 0;
                            double priceTaxInc = 0;


                            //-----------------------------------------------------------------------------
                            // キャンペーン価格反映
                            //-----------------------------------------------------------------------------
                            this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, row.BLGroupCode, row.SalesCode, this._salesSlip.SalesDate, ref price);
                            if (this._campaignObjGoodsSt != null)
                            {
                                // キャンペーン価格適用
                                if (this._campaignObjGoodsSt.PriceFl != 0)
                                {
                                    price = this._campaignObjGoodsSt.PriceFl;
                                    row.SalesRate = 0;   // ADD 2011/08/15
                                }

                                // キャンペーン売価率適用
                                if (this._campaignObjGoodsSt.RateVal != 0)
                                {
                                    row.SalesRate = this._campaignObjGoodsSt.RateVal;
                                    double listPriceDisplay = row.ListPriceDisplay;
                                    this.CalclatePriceByRate(row.TaxationDivCd, this._campaignObjGoodsSt.RateVal, ref listPriceDisplay);
                                    price = listPriceDisplay;
                                }
                                // ADD 陳健 2014/03/20 -------------------------->>>>>
                                Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                                ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaUpdDateCtrl);

                                if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                                {
                                    row.RateUpdateTimeSales = this._campaignObjGoodsSt.UpdateDateTimeAdFormal;
                                }
                                // ADD 陳健 2014/03/20 --------------------------<<<<<

                                // キャンペーン値引率適用
                                if (this._campaignObjGoodsSt.DiscountRate != 0)
                                {
                                    this.CalclatePriceByRate(row.TaxationDivCd, 100 - this._campaignObjGoodsSt.DiscountRate, ref price);
                                    row.SalesRate = 0;  // ADD 2011/08/15
                                }


                                //-----ADD 2011/08/29 ------>>>>>
                                row.CampaignCode = this._campaignObjGoodsSt.CampaignCode;
                                row.CampaignRate = this._campaignObjGoodsSt.RateVal;
                                row.CampaignDiscountRate = this._campaignObjGoodsSt.DiscountRate;
                                row.CampaignPriceFl = this._campaignObjGoodsSt.PriceFl;
                                row.CampaignSettingKind = this._campaignObjGoodsSt.CampaignSettingKind;  // ADD 2011/09/14
                                //-----ADD 2011/08/29 ------<<<<<
                            }
                            // ---UPD 2011/05/30------------<<<<<
                            // ---UPD 2011/07/14------------<<<<<

                            //-----------------------------------------------------------------------------
                            // 価格再セット
                            //-----------------------------------------------------------------------------
                            this.CalcTaxExcAndTaxInc(row.TaxationDivCd, this._salesSlip.CustomerCode, this._salesSlipInputInitDataAcs.TaxRate, this._salesSlip.TotalAmountDispWayCd, price, out priceTaxExc, out priceTaxInc);
                            row.SalesUnPrcTaxExcFl = priceTaxExc;
                            row.SalesUnPrcTaxIncFl = priceTaxInc;

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) salesUnitPriceFlg = false;

                            //--------------------------------------------
                            // 非課税
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                            }
                            //--------------------------------------------
                            // 総額表示しない
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    //--------------------------------------------
                                    // 商品価格課税区分「外税」
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                    //--------------------------------------------
                                    // 商品価格課税区分「内税」
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                                        break;
                                    //--------------------------------------------
                                    // 商品価格課税区分「非課税」
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // 総額表示する
                            //--------------------------------------------
                            else
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            }
                        }
                    }
                    #endregion

                    #region ●原単価
                    //--------------------------------------------
                    // 原単価
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_UnitCost == unitPriceKind)
                    {
                        double salesUnitCost = 0;
                        salesUnitCostFlg = true;
                        salesUnitCostCalcRetFlg = true; // 2010/07/29
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitCost = row.SalesUnitCostTaxInc;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                        }

                        //if (salesUnitCost == row.BfUnitCost)
                        // 掛率設定区分と基準価格が設定されている場合は、掛率再取得
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))))
                        {
                            row.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                            row.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;          // 掛率設定区分
                            row.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;         // 単価算出区分
                            row.PriceCdUnCst = unitPriceCalcRet.PriceDiv;                   // 価格区分
                            row.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;              // 基準単価
                            row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // 原単価(税抜)
                            row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // 原単価(税込)
                            row.CostRate = unitPriceCalcRet.RateVal;                        // 原価率
                            row.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;     // 端数処理単位
                            row.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;          // 端数処理区分
                            row.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;            // 変更前原価
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL商品コード(掛率)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // 商品掛率グループコード（掛率）
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // 商品掛率グループ名称（掛率）
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BLグループコード（掛率）
                            //row.RateBLGroupName = row.BLGroupName;                          // BLグループ名称（掛率）

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) salesUnitCostFlg = false;

                            //--------------------------------------------
                            // 非課税
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.SalesUnitCost = row.SalesUnitCostTaxExc;
                            }
                            //--------------------------------------------
                            // 総額表示しない
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // 総額表示する
                            //--------------------------------------------
                            else
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●定価
                    //--------------------------------------------
                    // 定価
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_ListPrice == unitPriceKind)
                    {
                        double listPrice = 0;
                        listPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                listPrice = row.ListPriceTaxIncFl;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                        }

                        // 掛率設定区分と基準価格が設定されている場合は、掛率再取得
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))))
                        {
                            row.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;          // 掛率設定拠点
                            row.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;         // 掛率設定区分
                            row.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;        // 単価算出区分
                            row.PriceCdLPrice = unitPriceCalcRet.PriceDiv;                  // 価格区分
                            row.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;             // 基準単価
                            row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)
                            row.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;     // 定価(税込)
                            row.ListPriceRate = unitPriceCalcRet.RateVal;                   // 定価率
                            row.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;    // 端数処理単位
                            row.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;         // 端数処理区分
                            row.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;           // 変更前定価
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL商品コード(掛率)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // 商品掛率グループコード（掛率）
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // 商品掛率グループ名称（掛率）
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BLグループコード（掛率）
                            //row.RateBLGroupName = row.BLGroupName;                          // BLグループ名称（掛率）
                            row.OpenPriceDiv = unitPriceCalcRet.OpenPriceDiv;               // オープン価格区分

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) listPriceFlg = false;

                            //--------------------------------------------
                            // 非課税
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                            }
                            //--------------------------------------------
                            // 総額表示しない
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // 総額表示する
                            //--------------------------------------------
                            else
                            {
                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            }
                        }
                    }
                    #endregion
                }
            }

            #region 変更前売単価設定
            if (salesUnitPriceFlg == false)
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // ゼロ表示
                    case 0:
                        row.BfSalesUnitPrice = 0;
                        break;
                    // 定価表示
                    case 1:
                        row.BfSalesUnitPrice = row.ListPriceTaxExcFl;
                        break;
                    default:
                        row.BfSalesUnitPrice = 0;
                        break;
                }
            }
            #endregion

            #region 初期化
            if (salesUnitPriceFlg == false)
            {
                // 売単価
                row.RateSectSalUnPrc = string.Empty;    // 掛率設定拠点
                row.RateDivSalUnPrc = string.Empty;      // 掛率設定区分
                row.UnPrcCalcCdSalUnPrc = 0;   // 単価算出区分
                row.PriceCdSalUnPrc = 0;       // 価格区分
                row.StdUnPrcSalUnPrc = 0;      // 基準単価
                row.FracProcUnitSalUnPrc = 0;  // 端数処理単位
                row.FracProcSalUnPrc = 0;      // 端数処理区分

                row.SalesRate = 0;
            }
            if (salesUnitCostFlg == false && !_noneResettingUnitCostFlag)
            {
                // 原単価
                row.RateSectCstUnPrc = string.Empty;    // 掛率設定拠点
                row.RateDivUnCst = string.Empty;         // 掛率設定区分
                row.UnPrcCalcCdUnCst = 0;      // 単価算出区分
                row.PriceCdUnCst = 0;          // 価格区分
                row.StdUnPrcUnCst = 0;         // 基準単価
                row.FracProcUnitUnCst = 0;     // 端数処理単位
                row.FracProcUnCst = 0;         // 端数処理区分

                row.CostRate = 0;
                if (salesUnitCostCalcRetFlg == false)
                {
                    row.SalesUnitCost = 0;
                    row.SalesUnitCostTaxExc = 0;
                    row.SalesUnitCostTaxInc = 0;
                }
            }
            if (listPriceFlg == false && !_noneResettingListPriceFlag)
            {
                // 定価
                row.RateSectPriceUnPrc = string.Empty;  // 掛率設定拠点
                row.RateDivLPrice = string.Empty;        // 掛率設定区分
                row.UnPrcCalcCdLPrice = 0;     // 単価算出区分
                row.PriceCdLPrice = 0;         // 価格区分
                row.StdUnPrcLPrice = 0;        // 基準単価
                row.FracProcUnitLPrice = 0;    // 端数処理単位
                row.FracProcLPrice = 0;        // 端数処理区分

            }
            #endregion

            this.SalesDetailRowUnitPriceForSalesCodeCheck(row, goodsUnitData);

            if (this._campaignObjGoodsSt != null)
            {
                // 掛率算出情報クリア
                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            }
        }
        // ------ ADD 2011/09/05 -------- <<<<<

        /// <summary>
        /// 指定した商品情報オブジェクトを元に単価算出部品より商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。（オーバーロード）
        /// </summary>
        /// <param name="row"></param>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailRow row)
        {
            //>>>2010/10/01
            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
            //<<<2010/10/01
            this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, false);
        }

        /// <summary>
        /// 指定した商品情報オブジェクトを元に商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <br>Update Note: 2011/05/30 曹文傑</br>
        /// <br>             やキャンペーン売価を取得するように変更</br>
        /// <br>UpdateNote :  2011/07/06 譚洪 売上全体設定の売価未設定時の対応</br>
        /// <br>UpdateNote :  2011/07/11 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
        /// <br>UpdateNote : 2011/07/13 曹文傑 Redmine#22953 標準価格＝０、売上伝票入力で０除算のエラーメッセージが表示しません</br>
        /// <br>                               Redmine#22773 [売価未設定時区分＝ゼロを表示]、掛率なし、キャンペーン値引率≠0の場合の不具合修正</br>
        /// <br>UpdateNote :  2011/07/14 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
        /// <br>Update Note:  2011/08/20 連番882 徐錦山 10704766-00 </br>
        /// <br>             元定価が表示のを追加</br>
        private void SalesDetailRowUnitPriceSetting(ref SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData)
        {
            #region ●初期処理
            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // 原価消費税端数処理コード(仕入先マスタより取得)
            int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            // 原価消費税端数処理単位、区分取得
            int stockTaxFracProcCd = 0;
            double stockTaxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, 0, out stockTaxFracProcUnit, out stockTaxFracProcCd);

            int taxationCode;
            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (goodsUnitData != null)
            {
                taxationCode = goodsUnitData.TaxationDivCd;
                goodsPriceList = goodsUnitData.GoodsPriceList;
            }
            else
            {
                taxationCode = row.TaxationDivCd;
            }
            #endregion

            #region ●定価
            // 2011/08/20 XUJS ADD STA ------>>>>>>
            DateTime tDate = new DateTime();

            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
            {
                case AcptAnOdrStatusState.Estimate:
                    tDate = this._salesSlip.SalesDate; // 売上日
                    break;
                case AcptAnOdrStatusState.UnitPriceEstimate:
                    tDate = this._salesSlip.SalesDate; // 売上日
                    break;
                case AcptAnOdrStatusState.Sales:
                    tDate = this._salesSlip.SalesDate; // 売上日
                    break;
                case AcptAnOdrStatusState.Shipment:
                    tDate = this._salesSlip.ShipmentDay; // 出荷日
                    break;
            }
            object objGoodsPrice = this._salesSlipInputInitDataAcs.GetGoodsPrice(tDate, goodsPriceList);
            if ((objGoodsPrice != null) && (objGoodsPrice is GoodsPrice))
            {
                GoodsPrice gPrice = (GoodsPrice)objGoodsPrice;
                row.GoodsListPrice = gPrice.ListPrice;
            }
            // 2011/08/20 XUJS ADD END ------<<<<<
            //--------------------------------------------
            // 定価
            //--------------------------------------------
            double listPrice = 0;
            // 掛率算出した場合、掛率設定区分と基準価格が設定されている場合は基準単価が定価となる
            if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))
            {
                listPrice = row.StdUnPrcLPrice;	// 掛率算出した場合は基準価格が定価
            }
            // 掛率算出できていない場合は、定価を表示する
            //else if ((goodsPriceList != null) && (row.ListPriceRate == 0))
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //else
            else if (!_noneResettingListPriceFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                DateTime targetDate = new DateTime();

                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
                {
                    case AcptAnOdrStatusState.Estimate:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.UnitPriceEstimate:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.Sales:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.Shipment:
                        targetDate = this._salesSlip.ShipmentDay; // 出荷日
                        break;
                }

                //-----------------------------------------------------------------------
                // 価格情報が存在する場合は、価格情報から基準定価確定
                //-----------------------------------------------------------------------
                if (goodsPriceList != null)
                {
                    object obj = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsPriceList);
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        //row.NewListPrice = goodsPrice.NewPrice;
                        //row.NewListPriceStartDate = goodsPrice.NewPriceStartDate;
                        //row.OldListPrice = goodsPrice.OldPrice;
                        //row.ListPriceOpenDiv = goodsPrice.OpenPriceDiv;
                        row.OpenPriceDiv = goodsPrice.OpenPriceDiv;

                        //listPrice = this.GetPrice(targetDate, row.NewListPrice, row.OldListPrice, row.NewListPriceStartDate, goodsPrice.OpenPriceDiv);
                        listPrice = goodsPrice.ListPrice;
                    }
                }
                //-----------------------------------------------------------------------
                // 価格情報が存在しない場合は、テーブル情報の価格情報から基準定価確定
                //-----------------------------------------------------------------------
                else
                {
                    //listPrice = this.GetPrice(targetDate, row.NewListPrice, row.OldListPrice, row.NewListPriceStartDate, row.ListPriceOpenDiv);
                    // ここ
                    listPrice = row.ListPriceDisplay;
                }

                //--------------------------------------------------
                // 定価
                //--------------------------------------------------
                double listPriceTaxExc;
                double listPriceTaxInc;
                if (row.ListPriceTaxExcFl != 0)
                {
                    listPriceTaxExc = row.ListPriceTaxExcFl;
                }
                else
                {
                    listPriceTaxExc = listPrice;
                }
                if (row.ListPriceTaxIncFl != 0)
                {
                    listPriceTaxInc = row.ListPriceTaxIncFl;
                }
                else
                {
                    listPriceTaxInc = listPrice;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // 非課税
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.ListPriceTaxIncFl = listPriceTaxExc;
                    row.ListPriceTaxExcFl = listPriceTaxExc;
                    row.ListPriceDisplay = row.ListPriceTaxExcFl;
                }
                //--------------------------------------------------
                // 総額表示しない
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 0)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            // ①基準定価 = 定価(税抜)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // ②定価(税抜) = 掛率適用後の定価
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // ③定価(税込) = 定価(税抜) + (定価(税抜) * 税率)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // 定価(表示) = 定価(税抜)
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;


                            // 課税区分←外税
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            // ①基準定価 = 定価(税抜)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // ②定価(税込) = 掛率適用後の定価
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // ③定価(税抜) = 定価(税込) - (定価(税込)* 税率/税率+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // 定価(表示) = 定価(税込)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;

                            // 課税区分←非課税
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // 総額表示する
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            // ①基準定価 = 定価(税抜)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // ②定価(税抜) = 掛率適用後の定価
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // ③定価(税込) = 定価(税抜) + (定価(税抜) * 税率)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // 定価(表示) = 定価(税込)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // 課税区分←外税
                            row.TaxationDivCd = 0; // テーブルセット値は変更しない
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            // ①基準定価 = 定価(税抜)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // ②定価(税込) = 掛率適用後の定価
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // ③定価(税抜) = 定価(税込) - (定価(税込)* 税率/税率+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // 定価(表示) = 定価(税抜)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            row.TaxationDivCd = 1;									// 課税区分←非課税
                            break;
                    }
                }
            }
            #endregion

            #region ●原単価
            //--------------------------------------------
            // 原単価
            //--------------------------------------------
            double unitCost = 0;
            // 掛率算出した場合、掛率設定区分と基準価格が設定されている場合は基準単価が原価となる
            if ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))
            {
                unitCost = row.StdUnPrcUnCst;	// 掛率算出した場合は基準価格が原価
            }
            // 掛率算出できていない場合は、ゼロを表示する
            //else if ((goodsPriceList != null) && (row.CostRate == 0))
            else
            {
                //unitCost = listPrice;
                unitCost = 0;

                //--------------------------------------------------
                // 原単価
                //--------------------------------------------------
                double unitCostTaxExc;
                double unitCostTaxInc;
                if (row.SalesUnitCostTaxExc != 0)
                {
                    unitCostTaxExc = row.SalesUnitCostTaxExc;
                }
                else
                {
                    unitCostTaxExc = unitCost;
                }
                if (row.SalesUnitCostTaxInc != 0)
                {
                    unitCostTaxInc = row.SalesUnitCostTaxInc;
                }
                else
                {
                    unitCostTaxInc = unitCost;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // 非課税
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.SalesUnitCostTaxInc = unitCostTaxExc;
                    row.SalesUnitCostTaxExc = unitCostTaxExc;
                    row.SalesUnitCost = row.SalesUnitCostTaxExc;
                }
                else
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 原単価
                            //--------------------------------------------------
                            // ①基準原価 = 原価(税抜)
                            //row.StdUnPrcUnCst = unitCostTaxExc;

                            // ②原価(税抜) = 掛率適用後の原価
                            row.SalesUnitCostTaxExc = unitCostTaxExc;

                            // ③原価(税込) = 原価(税抜) + (原価(税抜) * 税率)
                            row.SalesUnitCostTaxInc = unitCostTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxExc);

                            // 原価(表示) = 原価(税抜)
                            row.SalesUnitCost = row.SalesUnitCostTaxExc;

                            // 課税区分←外税
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 原単価
                            //--------------------------------------------------
                            // ①基準原価 = 原価(税抜)
                            //row.StdUnPrcUnCst = unitCostTaxExc;

                            // ②原価(税込) = 掛率適用後の原価
                            row.SalesUnitCostTaxInc = unitCostTaxInc;

                            // ③原価(税抜) = 原価(税込) - (原価(税込)* 税率/税率+100)
                            row.SalesUnitCostTaxExc = unitCostTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxInc);

                            // 原価(表示) = 原価(税込)
                            row.SalesUnitCost = row.SalesUnitCostTaxInc;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 原単価
                            //--------------------------------------------------
                            //row.StdUnPrcUnCst = unitCostTaxExc;
                            row.SalesUnitCostTaxInc = unitCostTaxExc;
                            row.SalesUnitCostTaxExc = unitCostTaxExc;
                            row.SalesUnitCost = row.SalesUnitCostTaxExc;

                            // 課税区分←非課税
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
            }
            #endregion

            #region ●売単価
            //--------------------------------------------
            // 売単価
            //--------------------------------------------
            double unitPrice = 0;
            // 掛率算出した場合、掛率設定区分と基準価格が設定されている場合は基準単価が売単価となる
            if ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))
            {
                unitPrice = row.StdUnPrcSalUnPrc;	// 掛率算出した場合は基準価格が売単価
            }
            // 掛率算出できていない場合(売上金額手入力以外)
            else if (row.SalesMoneyInputDiv != (int)SalesMoneyInputDiv.Input)
            {
                double goodsPriceTaxExc;
                double goodsPriceTaxInc;
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // ゼロ表示
                    case 0:
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                        break;
                    // 定価表示
                    case 1:
                        goodsPriceTaxExc = row.ListPriceTaxExcFl;
                        goodsPriceTaxInc = row.ListPriceTaxIncFl;
                        break;
                    default:
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                        break;
                }

                row.UnPrcCalcCdSalUnPrcTemp = -1;  // ADD 2011/08/15

                //>>>2010/02/26
                //-----------------------------------------------------------------------------
                // キャンペーン価格反映
                //-----------------------------------------------------------------------------
                // ---UPD 2011/05/30------------>>>>>
                //this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.GoodsMGroup, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, this._salesSlip.SalesDate, ref goodsPriceTaxExc);
                this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, row.BLGroupCode, row.SalesCode, this._salesSlip.SalesDate, ref goodsPriceTaxExc);

                // --- ADD 2011/07/06  ---- >>>>>>
                if (this._campaignObjGoodsSt != null)
                {
                    // ---UPD 2011/07/13------------------>>>>>
                    if (this._campaignObjGoodsSt.DiscountRate != 0 && this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv != 1)
                    {
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                    }
                    else
                    {
                        goodsPriceTaxExc = row.ListPriceTaxExcFl;
                        goodsPriceTaxInc = row.ListPriceTaxIncFl;
                    }
                    // ---UPD 2011/07/13------------------<<<<<

                    // キャンペーン掛率適用
                    if (this._campaignObjGoodsSt.RateVal != 0)
                    {
                        this.CalclatePriceByRate(taxationCode, this._campaignObjGoodsSt.RateVal, ref goodsPriceTaxExc);
                    }

                    // キャンペーン売価額≠0の場合
                    if (this._campaignObjGoodsSt.PriceFl != 0)
                    {
                        goodsPriceTaxExc = this._campaignObjGoodsSt.PriceFl;
                    }
                    // ADD 陳健 2014/03/20 -------------------------->>>>>
                    Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaUpdDateCtrl);

                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        row.RateUpdateTimeSales = this._campaignObjGoodsSt.UpdateDateTimeAdFormal;
                    }
                    // ADD 陳健 2014/03/20 --------------------------<<<<<

                    // キャンペーン値引率適用
                    if (this._campaignObjGoodsSt.DiscountRate != 0)
                    {
                        this.CalclatePriceByRate(taxationCode, 100 - this._campaignObjGoodsSt.DiscountRate, ref goodsPriceTaxExc);
                    }

                    row.SalesRate = this._campaignObjGoodsSt.RateVal;
                    //-----ADD 2011/09/05 ------>>>>>
                    row.CampaignCode = this._campaignObjGoodsSt.CampaignCode;
                    row.CampaignRate = this._campaignObjGoodsSt.RateVal;
                    row.CampaignDiscountRate = this._campaignObjGoodsSt.DiscountRate;
                    row.CampaignPriceFl = this._campaignObjGoodsSt.PriceFl;
                    row.CampaignSettingKind = this._campaignObjGoodsSt.CampaignSettingKind;  // ADD 2011/09/14
                    //-----ADD 2011/09/05 ------<<<<<
                }
                // --- ADD 2011/07/06  ---- <<<<<<
                // --- DEL 2011/07/14  ---- >>>>>>
                //if ((this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1)
                //    || (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 0 && row.SalesRate != 0))
                //{
                //    if (this._campaignObjGoodsSt != null)
                //    {
                //        // キャンペーン価格適用
                //        if (this._campaignObjGoodsSt.PriceFl != 0)
                //        {
                //            goodsPriceTaxExc = this._campaignObjGoodsSt.PriceFl;
                //        }

                //        if (this._campaignObjGoodsSt.RateVal != 0)
                //        {
                //            row.SalesRate = this._campaignObjGoodsSt.RateVal;
                //            goodsPriceTaxExc = row.ListPriceDisplay * row.SalesRate / 100;
                //        }
                //    }
                //}

                //// ----- ADD 2011/07/11 ------- >>>>>>>>>
                //if (this._campaignObjGoodsSt != null)
                //{
                //    // ------UPD 2011/07/13-------------->>>>>
                //    //if (this._campaignObjGoodsSt.PriceFl == 0)
                //    if (this._campaignObjGoodsSt.PriceFl == 0 && taxFracProcUnit != 0)
                //    // ------UPD 2011/07/13-------------->>>>>
                //    {
                //        // 売単価（税抜）
                //        FractionCalculate.FracCalcMoney(goodsPriceTaxExc, taxFracProcUnit, taxFracProcCd, out goodsPriceTaxExc);
                //    }
                //}
                // ----- ADD 2011/07/11 ------- <<<<<<<<<
                // ---UPD 2011/05/30------------<<<<<
                // --- DEL 2011/07/14  ---- <<<<<<
                //-----------------------------------------------------------------------------
                // 価格再セット
                //-----------------------------------------------------------------------------
                double priceTaxExc;
                double priceTaxInc;
                this.CalcTaxExcAndTaxInc(row.TaxationDivCd, this._salesSlip.CustomerCode, this._salesSlipInputInitDataAcs.TaxRate, this._salesSlip.TotalAmountDispWayCd, goodsPriceTaxExc, out priceTaxExc, out priceTaxInc);
                row.SalesUnPrcTaxExcFl = priceTaxExc;
                row.SalesUnPrcTaxIncFl = priceTaxInc;
                //<<<2010/02/26

                //--------------------------------------------------
                // 売単価
                //--------------------------------------------------
                if (row.SalesUnPrcTaxExcFl != 0) goodsPriceTaxExc = row.SalesUnPrcTaxExcFl;
                if (row.SalesUnPrcTaxIncFl != 0) goodsPriceTaxInc = row.SalesUnPrcTaxIncFl;

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // 非課税
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;
                    row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                    row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                }

                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            // ①基準単価 = 税抜単価
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税抜) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // ③売上単価(税込) = 売上単価(税抜) + (売上単価(税抜) * 税率)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // 表示単価 = 税抜単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // 課税区分←外税
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            // ①基準単価 = 税抜価格
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税込) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // ③売上単価(税抜) = 売上単価(税込) - (売上単価(税込)* 税率/税率+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // 表示単価 = 税込単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // 課税区分←非課税
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // 総額表示する
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            // ①基準単価 = 税抜単価
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税抜) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // ③売上単価(税込) = 売上単価(税抜) + (売上単価(税抜) * 税率)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // 表示単価 = 税込単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // 課税区分←外税
                            row.TaxationDivCd = 0; // テーブルセット値は変更しない
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            // ①基準単価 = 税抜価格
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税込) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // ③売上単価(税抜) = 売上単価(税込) - (売上単価(税込)* 税率/税率+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // 表示単価 = 税込単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            row.TaxationDivCd = 1;									// 課税区分←非課税
                            break;
                    }
                }

                #region 削除 2008.12.10
                //--------------------------------------------------
                // 総額表示しない
                //--------------------------------------------------
                //else if (this._salesSlip.TotalAmountDispWayCd == 0)
                //{
                //    switch ((CalculateTax.TaxationCode)taxationCode)
                //    {
                //        case CalculateTax.TaxationCode.TaxExc:
                //            //--------------------------------------------------
                //            // 売単価
                //            //--------------------------------------------------
                //            // ①基準単価 = 税抜単価
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                //            // ②売上単価(税抜) = 掛率適用後の仕入単価
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                //            // ③売上単価(税込) = 売上単価(税抜) + (売上単価(税抜) * 税率)
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxExc);

                //            // 表示単価 = 税抜単価
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                //            // 課税区分←外税
                //            row.TaxationDivCd = 0;
                //            break;
                //        case CalculateTax.TaxationCode.TaxInc:
                //            //--------------------------------------------------
                //            // 売単価
                //            //--------------------------------------------------
                //            // ①基準単価 = 税抜価格
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                //            // ②売上単価(税込) = 掛率適用後の仕入単価
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                //            // ③売上単価(税抜) = 売上単価(税込) - (売上単価(税込)* 税率/税率+100)
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxInc);

                //            // 表示単価 = 税込単価
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                //            // 課税区分←内税
                //            row.TaxationDivCd = 2;
                //            break;
                //        case CalculateTax.TaxationCode.TaxNone:
                //            //--------------------------------------------------
                //            // 売単価
                //            //--------------------------------------------------
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                //            // 課税区分←非課税
                //            row.TaxationDivCd = 1;
                //            break;
                //    }
                //}
                ////--------------------------------------------------
                //// 総額表示する
                ////--------------------------------------------------
                //else if (this._salesSlip.TotalAmountDispWayCd == 1)
                //{
                //    switch ((CalculateTax.TaxationCode)taxationCode)
                //    {
                //        case CalculateTax.TaxationCode.TaxExc:
                //            //--------------------------------------------------
                //            // 売単価
                //            //--------------------------------------------------
                //            // ①基準単価 = 税抜単価
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                //            // ②売上単価(税抜) = 掛率適用後の仕入単価
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                //            // ③売上単価(税込) = 売上単価(税抜) + (売上単価(税抜) * 税率)
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxExc);

                //            // 表示単価 = 税込単価
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                //            // 課税区分←外税
                //            row.TaxationDivCd = 0; // テーブルセット値は変更しない
                //            break;
                //        case CalculateTax.TaxationCode.TaxInc:
                //            //--------------------------------------------------
                //            // 売単価
                //            //--------------------------------------------------
                //            // ①基準単価 = 税抜価格
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                //            // ②売上単価(税込) = 掛率適用後の仕入単価
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                //            // ③売上単価(税抜) = 売上単価(税込) - (売上単価(税込)* 税率/税率+100)
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxInc);

                //            // 表示単価 = 税込単価
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                //            // 課税区分←内税
                //            row.TaxationDivCd = 2;
                //            break;
                //        case CalculateTax.TaxationCode.TaxNone:
                //            //--------------------------------------------------
                //            // 売単価
                //            //--------------------------------------------------
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                //            row.TaxationDivCd = 1;									// 課税区分←非課税
                //            break;
                //    }
                //}
                #endregion

            }
            #endregion

            #region ●共通
            if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
            {
                row.TaxDiv = 1;												// 課税区分←非課税
            }
            else
            {
                row.TaxDiv = 0;												// 課税区分←課税
            }
            #endregion
        }

        // ------ ADD 2011/09/05 --------- >>>>>>
        /// <summary>
        /// 指定した商品情報オブジェクトを元に商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        /// <br>Update Note: 2011/05/30 曹文傑</br>
        /// <br>             やキャンペーン売価を取得するように変更</br>
        /// <br>UpdateNote :  2011/07/06 譚洪 売上全体設定の売価未設定時の対応</br>
        /// <br>UpdateNote :  2011/07/11 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
        /// <br>UpdateNote : 2011/07/13 曹文傑 Redmine#22953 標準価格＝０、売上伝票入力で０除算のエラーメッセージが表示しません</br>
        /// <br>                               Redmine#22773 [売価未設定時区分＝ゼロを表示]、掛率なし、キャンペーン値引率≠0の場合の不具合修正</br>
        /// <br>UpdateNote :  2011/07/14 譚洪 Redmine#22876 売単価の端数処理に関しての修正</br>
        private void SalesDetailRowUnitPriceForSalesCodeCheck(SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData)
        {
            #region ●初期処理
            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // 原価消費税端数処理コード(仕入先マスタより取得)
            int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            // 原価消費税端数処理単位、区分取得
            int stockTaxFracProcCd = 0;
            double stockTaxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, 0, out stockTaxFracProcUnit, out stockTaxFracProcCd);

            int taxationCode;
            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (goodsUnitData != null)
            {
                taxationCode = goodsUnitData.TaxationDivCd;
                goodsPriceList = goodsUnitData.GoodsPriceList;
            }
            else
            {
                taxationCode = row.TaxationDivCd;
            }
            #endregion

            #region ●定価
            //--------------------------------------------
            // 定価
            //--------------------------------------------
            double listPrice = 0;
            // 掛率算出した場合、掛率設定区分と基準価格が設定されている場合は基準単価が定価となる
            if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))
            {
                listPrice = row.StdUnPrcLPrice;	// 掛率算出した場合は基準価格が定価
            }
            // 掛率算出できていない場合は、定価を表示する
            else if (!_noneResettingListPriceFlag)
            {
                DateTime targetDate = new DateTime();

                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
                {
                    case AcptAnOdrStatusState.Estimate:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.UnitPriceEstimate:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.Sales:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.Shipment:
                        targetDate = this._salesSlip.ShipmentDay; // 出荷日
                        break;
                }

                //-----------------------------------------------------------------------
                // 価格情報が存在する場合は、価格情報から基準定価確定
                //-----------------------------------------------------------------------
                if (goodsPriceList != null)
                {
                    object obj = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsPriceList);
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        row.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                        listPrice = goodsPrice.ListPrice;
                    }
                }
                //-----------------------------------------------------------------------
                // 価格情報が存在しない場合は、テーブル情報の価格情報から基準定価確定
                //-----------------------------------------------------------------------
                else
                {
                    // ここ
                    listPrice = row.ListPriceDisplay;
                }

                //--------------------------------------------------
                // 定価
                //--------------------------------------------------
                double listPriceTaxExc;
                double listPriceTaxInc;
                if (row.ListPriceTaxExcFl != 0)
                {
                    listPriceTaxExc = row.ListPriceTaxExcFl;
                }
                else
                {
                    listPriceTaxExc = listPrice;
                }
                if (row.ListPriceTaxIncFl != 0)
                {
                    listPriceTaxInc = row.ListPriceTaxIncFl;
                }
                else
                {
                    listPriceTaxInc = listPrice;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // 非課税
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.ListPriceTaxIncFl = listPriceTaxExc;
                    row.ListPriceTaxExcFl = listPriceTaxExc;
                    row.ListPriceDisplay = row.ListPriceTaxExcFl;
                }
                //--------------------------------------------------
                // 総額表示しない
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 0)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------

                            // ②定価(税抜) = 掛率適用後の定価
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // ③定価(税込) = 定価(税抜) + (定価(税抜) * 税率)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // 定価(表示) = 定価(税抜)
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;


                            // 課税区分←外税
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------

                            // ②定価(税込) = 掛率適用後の定価
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // ③定価(税抜) = 定価(税込) - (定価(税込)* 税率/税率+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // 定価(表示) = 定価(税込)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;

                            // 課税区分←非課税
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // 総額表示する
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------

                            // ②定価(税抜) = 掛率適用後の定価
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // ③定価(税込) = 定価(税抜) + (定価(税抜) * 税率)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // 定価(表示) = 定価(税込)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // 課税区分←外税
                            row.TaxationDivCd = 0; // テーブルセット値は変更しない
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------

                            // ②定価(税込) = 掛率適用後の定価
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // ③定価(税抜) = 定価(税込) - (定価(税込)* 税率/税率+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // 定価(表示) = 定価(税抜)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            row.TaxationDivCd = 1;									// 課税区分←非課税
                            break;
                    }
                }
            }
            #endregion

            #region ●原単価
            //--------------------------------------------
            // 原単価
            //--------------------------------------------
            double unitCost = 0;
            // 掛率算出した場合、掛率設定区分と基準価格が設定されている場合は基準単価が原価となる
            if ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))
            {
                unitCost = row.StdUnPrcUnCst;	// 掛率算出した場合は基準価格が原価
            }
            // 掛率算出できていない場合は、ゼロを表示する
            else
            {
                unitCost = 0;

                //--------------------------------------------------
                // 原単価
                //--------------------------------------------------
                double unitCostTaxExc;
                double unitCostTaxInc;
                if (row.SalesUnitCostTaxExc != 0)
                {
                    unitCostTaxExc = row.SalesUnitCostTaxExc;
                }
                else
                {
                    unitCostTaxExc = unitCost;
                }
                if (row.SalesUnitCostTaxInc != 0)
                {
                    unitCostTaxInc = row.SalesUnitCostTaxInc;
                }
                else
                {
                    unitCostTaxInc = unitCost;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // 非課税
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.SalesUnitCostTaxInc = unitCostTaxExc;
                    row.SalesUnitCostTaxExc = unitCostTaxExc;
                    row.SalesUnitCost = row.SalesUnitCostTaxExc;
                }
                else
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 原単価
                            //--------------------------------------------------

                            // ②原価(税抜) = 掛率適用後の原価
                            row.SalesUnitCostTaxExc = unitCostTaxExc;

                            // ③原価(税込) = 原価(税抜) + (原価(税抜) * 税率)
                            row.SalesUnitCostTaxInc = unitCostTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxExc);

                            // 原価(表示) = 原価(税抜)
                            row.SalesUnitCost = row.SalesUnitCostTaxExc;

                            // 課税区分←外税
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 原単価
                            //--------------------------------------------------

                            // ②原価(税込) = 掛率適用後の原価
                            row.SalesUnitCostTaxInc = unitCostTaxInc;

                            // ③原価(税抜) = 原価(税込) - (原価(税込)* 税率/税率+100)
                            row.SalesUnitCostTaxExc = unitCostTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxInc);

                            // 原価(表示) = 原価(税込)
                            row.SalesUnitCost = row.SalesUnitCostTaxInc;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 原単価
                            //--------------------------------------------------
                            //row.StdUnPrcUnCst = unitCostTaxExc;
                            row.SalesUnitCostTaxInc = unitCostTaxExc;
                            row.SalesUnitCostTaxExc = unitCostTaxExc;
                            row.SalesUnitCost = row.SalesUnitCostTaxExc;

                            // 課税区分←非課税
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
            }
            #endregion

            #region ●売単価
            //--------------------------------------------
            // 売単価
            //--------------------------------------------
            double unitPrice = 0;
            // 掛率算出した場合、掛率設定区分と基準価格が設定されている場合は基準単価が売単価となる
            if ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))
            {
                unitPrice = row.StdUnPrcSalUnPrc;	// 掛率算出した場合は基準価格が売単価
            }
            // 掛率算出できていない場合(売上金額手入力以外)
            else if (row.SalesMoneyInputDiv != (int)SalesMoneyInputDiv.Input)
            {
                double goodsPriceTaxExc;
                double goodsPriceTaxInc;
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // ゼロ表示
                    case 0:
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                        break;
                    // 定価表示
                    case 1:
                        goodsPriceTaxExc = row.ListPriceTaxExcFl;
                        goodsPriceTaxInc = row.ListPriceTaxIncFl;
                        break;
                    default:
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                        break;
                }

                row.UnPrcCalcCdSalUnPrcTemp = -1; 

                //-----------------------------------------------------------------------------
                // キャンペーン価格反映
                //-----------------------------------------------------------------------------
                this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, row.BLGroupCode, row.SalesCode, this._salesSlip.SalesDate, ref goodsPriceTaxExc);

                if (this._campaignObjGoodsSt != null)
                {
                    if (this._campaignObjGoodsSt.DiscountRate != 0 && this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv != 1)
                    {
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                    }
                    else
                    {
                        goodsPriceTaxExc = row.ListPriceTaxExcFl;
                        goodsPriceTaxInc = row.ListPriceTaxIncFl;
                    }

                    // キャンペーン掛率適用
                    if (this._campaignObjGoodsSt.RateVal != 0)
                    {
                        this.CalclatePriceByRate(taxationCode, this._campaignObjGoodsSt.RateVal, ref goodsPriceTaxExc);
                    }

                    // キャンペーン売価額≠0の場合
                    if (this._campaignObjGoodsSt.PriceFl != 0)
                    {
                        goodsPriceTaxExc = this._campaignObjGoodsSt.PriceFl;
                    }

                    // キャンペーン値引率適用
                    if (this._campaignObjGoodsSt.DiscountRate != 0)
                    {
                        this.CalclatePriceByRate(taxationCode, 100 - this._campaignObjGoodsSt.DiscountRate, ref goodsPriceTaxExc);
                    }

                    row.SalesRate = this._campaignObjGoodsSt.RateVal;
                    row.CampaignRate = this._campaignObjGoodsSt.RateVal;
                    row.CampaignDiscountRate = this._campaignObjGoodsSt.DiscountRate;
                    row.CampaignPriceFl = this._campaignObjGoodsSt.PriceFl;
                    row.CampaignSettingKind = this._campaignObjGoodsSt.CampaignSettingKind;  // ADD 2011/09/14

                }
                //-----------------------------------------------------------------------------
                // 価格再セット
                //-----------------------------------------------------------------------------
                double priceTaxExc;
                double priceTaxInc;
                this.CalcTaxExcAndTaxInc(row.TaxationDivCd, this._salesSlip.CustomerCode, this._salesSlipInputInitDataAcs.TaxRate, this._salesSlip.TotalAmountDispWayCd, goodsPriceTaxExc, out priceTaxExc, out priceTaxInc);
                row.SalesUnPrcTaxExcFl = priceTaxExc;
                row.SalesUnPrcTaxIncFl = priceTaxInc;
                //<<<2010/02/26

                //--------------------------------------------------
                // 売単価
                //--------------------------------------------------
                if (row.SalesUnPrcTaxExcFl != 0) goodsPriceTaxExc = row.SalesUnPrcTaxExcFl;
                if (row.SalesUnPrcTaxIncFl != 0) goodsPriceTaxInc = row.SalesUnPrcTaxIncFl;

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // 非課税
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;
                    row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                    row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                }

                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            // ①基準単価 = 税抜単価
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税抜) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // ③売上単価(税込) = 売上単価(税抜) + (売上単価(税抜) * 税率)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // 表示単価 = 税抜単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // 課税区分←外税
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            // ①基準単価 = 税抜価格
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税込) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // ③売上単価(税抜) = 売上単価(税込) - (売上単価(税込)* 税率/税率+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // 表示単価 = 税込単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // 課税区分←非課税
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // 総額表示する
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            // ①基準単価 = 税抜単価
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税抜) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // ③売上単価(税込) = 売上単価(税抜) + (売上単価(税抜) * 税率)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // 表示単価 = 税込単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // 課税区分←外税
                            row.TaxationDivCd = 0; // テーブルセット値は変更しない
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            // ①基準単価 = 税抜価格
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税込) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // ③売上単価(税抜) = 売上単価(税込) - (売上単価(税込)* 税率/税率+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // 表示単価 = 税込単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            row.TaxationDivCd = 1;									// 課税区分←非課税
                            break;
                    }
                }
            }
            #endregion

            #region ●共通
            if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
            {
                row.TaxDiv = 1;												// 課税区分←非課税
            }
            else
            {
                row.TaxDiv = 0;												// 課税区分←課税
            }
            #endregion

            this._salesUnitPriceForCheck = row.SalesUnPrcDisplay;
            this._salesRateForCheck = row.SalesRate;
        }
        // ------ ADD 2011/09/05 --------- <<<<<<

        /// <summary>
        /// 単価算出モジュールにより、単価を算出します。
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <returns>単価算出結果オブジェクト</returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice(SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

            //>>>2010/10/04
            //if ((row.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(row.GoodsNo)))
            if (row.GoodsMakerCd != 0)
            //<<<2010/10/04
            {
                unitPriceCalcParam.BLGoodsCode = row.RateBLGoodsCode;                   // BLコード
                unitPriceCalcParam.BLGoodsName = row.RateBLGoodsName;                   // BLコード名称
                unitPriceCalcParam.BLGroupCode = row.RateBLGroupCode;                   // BLグループコード
                unitPriceCalcParam.CountFl = row.ShipmentCntDisplay;                    // 数量
                // ADD 2013/02/20 T.Miyamoto ------------------------------>>>>>
                // 出荷数=0かつ受注数>0の場合は受注数で算出
                if ((row.ShipmentCntDisplay == 0) && (row.AcceptAnOrderCntDisplay > 0))
                {
                    unitPriceCalcParam.CountFl = row.AcceptAnOrderCntDisplay;
                }
                // ADD 2013/02/20 T.Miyamoto ------------------------------<<<<<
                unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;         // 得意先コード
                unitPriceCalcParam.CustRateGrpCode = row.CustRateGrpCode;               // 得意先掛率グループコード
                unitPriceCalcParam.GoodsMakerCd = row.GoodsMakerCd;                     // メーカーコード
                unitPriceCalcParam.GoodsNo = row.GoodsNo;                               // 品番
                unitPriceCalcParam.GoodsRateGrpCode = row.RateGoodsRateGrpCd;           // 商品掛率グループコード
                unitPriceCalcParam.GoodsRateRank = row.GoodsRateRank;                   // 商品掛率ランク
                unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate; 　　　　　// 適用日
                int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd); // 売上消費税端数処理コード(得意先マスタより取得)
                unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;         // 売上消費税端数処理コード
                int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd); // 売上単価端数処理コード(得意先マスタより取得)
                unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;           // 売上単価端数処理コード
                unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;     // 拠点コード
                int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd); // 仕入消費税端数処理コード(仕入先マスタより取得)
                unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;         // 仕入消費税端数処理コード
                int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd); // 仕入単価端数処理コード(仕入先マスタより取得)
                unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;           // 仕入単価端数処理コード
                unitPriceCalcParam.SupplierCd = row.SupplierCd;                         // 仕入先コード
                unitPriceCalcParam.TaxationDivCd = row.TaxationDivCd;                   // 課税区分
                unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;               // 税率
                unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // 総額表示方法区分
                unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;    // 総額表示掛率適用区分 0:(税込金額×掛率) 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)
                unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod; // 消費税転嫁方式
                this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            }
            return unitPriceCalcRetList;
        }

        // --- ADD m.suzuki 2011/02/16 ---------->>>>>
        /// <summary>
        /// 指定した商品情報オブジェクトを元に単価算出部品より商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。（受注情報）
        /// </summary>
        /// <param name="row">受注明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="reCalcUnitInfoDiv">掛率再取得区分(true:再取得する false:再取得しない)</param>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalclationUnitPriceForAcptAnOdr(row, goodsUnitData);
            this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, reCalcUnitInfoDiv, unitPriceCalcRetList);
        }
        // --- ADD m.suzuki 2011/02/16 ----------<<<<<

        /// <summary>
        /// 指定した商品情報オブジェクトを元に単価算出部品より商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。（受注情報）
        /// </summary>
        /// <param name="row">受注明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="reCalcUnitInfoDiv">掛率再取得区分(true:再取得する false:再取得しない)</param>
        // --- UPD m.suzuki 2011/02/16 ---------->>>>>
        //private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv)
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv, List<UnitPriceCalcRet> unitPriceCalcRetList)
        // --- UPD m.suzuki 2011/02/16 ----------<<<<<
        {
            // --- DEL m.suzuki 2011/02/16 ---------->>>>> // リストは外部から受け取る
            //List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalclationUnitPriceForAcptAnOdr(row, goodsUnitData);
            // --- DEL m.suzuki 2011/02/16 ----------<<<<<

            bool salesUnitPriceFlg = false;
            bool salesUnitCostFlg = false;
            bool listPriceFlg = false;

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet != null)
                {
                    #region ●売単価
                    //--------------------------------------------
                    // 売単価
                    //--------------------------------------------
                    string unitPriceKind = unitPriceCalcRet.UnitPriceKind;

                    if (UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice == unitPriceKind)
                    {
                        double salesUnitPrice = 0;
                        salesUnitPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            //--------------------------------------------
                            // 商品価格課税区分「外税」
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                            //--------------------------------------------
                            // 商品価格課税区分「内税」
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitPrice = row.SalesUnPrcTaxIncFl;
                                break;
                            //--------------------------------------------
                            // 商品価格課税区分「非課税」
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                        }

                        // 売価を手入力で変更している場合は掛率再取得は行わない
                        //if (salesUnitPrice == row.BfSalesUnitPrice)
                        // 掛率設定区分と基準価格が設定されている場合は、掛率再取得
                        // --- UPD m.suzuki 2011/02/16 ---------->>>>>
                        //if ((reCalcUnitInfoDiv == true) ||
                        //    ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))))
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0) || (_noneResettingListPriceFlag))))
                        // --- UPD m.suzuki 2011/02/16 ----------<<<<<
                        {
                            row.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                            row.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;       // 掛率設定区分
                            row.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;      // 単価算出区分
                            row.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;                // 価格区分
                            row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // 基準単価
                            row.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // 売単価(税抜)
                            row.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;    // 売単価(税込)
                            row.SalesRate = 0; // --- ADD 2015/09/03 Y.Wakita 社内障害№711 
                            switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                            {
                                // 基準価格×売価率
                                case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                    row.SalesRate = unitPriceCalcRet.RateVal;                       // 売価率
                                    break;
                                // 原価UP率
                                case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                    row.CostUpRate = unitPriceCalcRet.RateVal;                      // 原価UP率
                                    break;
                                // 粗利確保率
                                case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                    row.GrossProfitSecureRate = unitPriceCalcRet.RateVal;           // 粗利確保率
                                    break;
                                // 単価直接指定
                                case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                    row.SalesRate = 0;
                                    break;
                            }
                            row.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;  // 端数処理単位
                            row.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;       // 端数処理区分
                            row.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;      // 変更前売価
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL商品コード(掛率)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // 商品掛率グループコード（掛率）
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // 商品掛率グループ名称（掛率）
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BLグループコード（掛率）
                            //row.RateBLGroupName = row.BLGroupName;                          // BLグループ名称（掛率）

                            if (unitPriceCalcRet.RateSettingDivide == string.Empty) salesUnitPriceFlg = false;

                            //--------------------------------------------
                            // 総額表示しない
                            //--------------------------------------------
                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    //--------------------------------------------
                                    // 商品価格課税区分「外税」
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                    //--------------------------------------------
                                    // 商品価格課税区分「内税」
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                                        break;
                                    //--------------------------------------------
                                    // 商品価格課税区分「非課税」
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // 総額表示する
                            //--------------------------------------------
                            else
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            }
                        }
                    }
                    #endregion

                    #region ●原単価
                    //--------------------------------------------
                    // 原単価
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_UnitCost == unitPriceKind)
                    {
                        double salesUnitCost = 0;
                        salesUnitCostFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitCost = row.SalesUnitCostTaxInc;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                        }

                        //if (salesUnitCost == row.BfUnitCost)
                        // 掛率設定区分と基準価格が設定されている場合は、掛率再取得
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))))
                        {
                            row.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;            // 掛率設定拠点
                            row.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;          // 掛率設定区分
                            row.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;         // 単価算出区分
                            row.PriceCdUnCst = unitPriceCalcRet.PriceDiv;                   // 価格区分
                            row.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;              // 基準単価
                            row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // 原単価(税抜)
                            row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // 原単価(税込)
                            row.CostRate = unitPriceCalcRet.RateVal;                        // 原価率
                            row.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;     // 端数処理単位
                            row.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;          // 端数処理区分
                            row.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;            // 変更前原価
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL商品コード(掛率)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // 商品掛率グループコード（掛率）
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // 商品掛率グループ名称（掛率）
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BLグループコード（掛率）
                            //row.RateBLGroupName = row.BLGroupName;                          // BLグループ名称（掛率）
                            if (unitPriceCalcRet.RateSettingDivide == string.Empty) salesUnitCostFlg = false;

                            //--------------------------------------------
                            // 総額表示しない
                            //--------------------------------------------
                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // 総額表示する
                            //--------------------------------------------
                            else
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                        }
                    }
                    #endregion

                    #region ●定価
                    //--------------------------------------------
                    // 定価
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_ListPrice == unitPriceKind)
                    {
                        double listPrice = 0;
                        listPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                listPrice = row.ListPriceTaxIncFl;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                        }

                        // 掛率設定区分と基準価格が設定されている場合は、掛率再取得
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))))
                        {
                            row.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;          // 掛率設定拠点
                            row.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;         // 掛率設定区分
                            row.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;        // 単価算出区分
                            row.PriceCdLPrice = unitPriceCalcRet.PriceDiv;                  // 価格区分
                            row.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;             // 基準単価
                            row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // 定価(税抜)
                            row.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;     // 定価(税込)
                            row.ListPriceRate = unitPriceCalcRet.RateVal;                   // 定価率
                            row.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;    // 端数処理単位
                            row.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;         // 端数処理区分
                            row.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;           // 変更前定価
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL商品コード(掛率)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL商品コード名称(掛率)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // 商品掛率グループコード（掛率）
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // 商品掛率グループ名称（掛率）
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BLグループコード（掛率）
                            //row.RateBLGroupName = row.BLGroupName;                          // BLグループ名称（掛率）
                            if (unitPriceCalcRet.RateSettingDivide == string.Empty) listPriceFlg = false;

                            //--------------------------------------------
                            // 総額表示しない
                            //--------------------------------------------
                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // 総額表示する
                            //--------------------------------------------
                            else
                            {
                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            }
                        }
                    }
                    #endregion
                }
            }

            #region 変更前売単価設定
            if (salesUnitPriceFlg == false)
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // ゼロ表示
                    case 0:
                        row.BfSalesUnitPrice = 0;
                        break;
                    // 定価表示
                    case 1:
                        row.BfSalesUnitPrice = row.ListPriceTaxExcFl;
                        break;
                    default:
                        row.BfSalesUnitPrice = 0;
                        break;
                }
            }
            #endregion

            #region 初期化
            if (salesUnitPriceFlg == false)
            {
                // 売単価
                row.RateSectSalUnPrc = string.Empty;    // 掛率設定拠点
                row.RateDivSalUnPrc = string.Empty;      // 掛率設定区分
                row.UnPrcCalcCdSalUnPrc = 0;   // 単価算出区分
                row.PriceCdSalUnPrc = 0;       // 価格区分
                row.StdUnPrcSalUnPrc = 0;      // 基準単価
                row.FracProcUnitSalUnPrc = 0;  // 端数処理単位
                row.FracProcSalUnPrc = 0;      // 端数処理区分
            }
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //if (salesUnitCostFlg == false)
            if (salesUnitCostFlg == false && !_noneResettingUnitCostFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                // 原単価
                row.RateSectCstUnPrc = string.Empty;    // 掛率設定拠点
                row.RateDivUnCst = string.Empty;         // 掛率設定区分
                row.UnPrcCalcCdUnCst = 0;      // 単価算出区分
                row.PriceCdUnCst = 0;          // 価格区分
                row.StdUnPrcUnCst = 0;         // 基準単価
                row.FracProcUnitUnCst = 0;     // 端数処理単位
                row.FracProcUnCst = 0;         // 端数処理区分
            }
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //if (listPriceFlg == false)
            if (listPriceFlg == false && !_noneResettingListPriceFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                // 定価
                row.RateSectPriceUnPrc = string.Empty;  // 掛率設定拠点
                row.RateDivLPrice = string.Empty;        // 掛率設定区分
                row.UnPrcCalcCdLPrice = 0;     // 単価算出区分
                row.PriceCdLPrice = 0;         // 価格区分
                row.StdUnPrcLPrice = 0;        // 基準単価
                row.FracProcUnitLPrice = 0;    // 端数処理単位
                row.FracProcLPrice = 0;        // 端数処理区分
            }
            if ((salesUnitPriceFlg == false) &&
                (salesUnitCostFlg == false) &&
                (listPriceFlg == false))
            {
                //row.RateBLGoodsCode = 0;                          // BL商品コード(掛率)
                //row.RateBLGoodsName = string.Empty;               // BL商品コード名称(掛率)
                //row.RateGoodsRateGrpCd = 0;                       // 商品掛率グループコード（掛率）
                //row.RateGoodsRateGrpNm = string.Empty;            // 商品掛率グループ名称（掛率）
                //row.RateBLGroupCode = 0;                          // BLグループコード（掛率）
                //row.RateBLGroupName = string.Empty;               // BLグループ名称（掛率）
            }
            #endregion

            this.SalesDetailRowUnitPriceSetting(ref row, goodsUnitData);
        }

        /// <summary>
        /// 指定した商品情報オブジェクトを元に単価算出部品より商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。（受注情報）
        /// </summary>
        /// <param name="row">受注明細行オブジェクト</param>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row)
        {
            //>>>2010/10/01
            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
            SalesInputDataSet.SalesDetailRow salesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(row, salesDetailRow); // 受注→売上
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, salesDetailRow);
            //<<<2010/10/01
            this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, false);
        }

        /// <summary>
        /// 指定した商品情報オブジェクトを元に商品価格を取得し、売上明細データ行オブジェクトに商品価格情報を設定します。（受注情報）
        /// </summary>
        /// <param name="row">受注明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品情報オブジェクト</param>
        private void SalesDetailRowUnitPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData)
        {
            #region ●初期処理
            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // 原価消費税端数処理コード(仕入先マスタより取得)
            int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            // 原価消費税端数処理単位、区分取得
            int stockTaxFracProcCd = 0;
            double stockTaxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, 0, out stockTaxFracProcUnit, out stockTaxFracProcCd);

            int taxationCode;
            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (goodsUnitData != null)
            {
                taxationCode = goodsUnitData.TaxationDivCd;
                goodsPriceList = goodsUnitData.GoodsPriceList;
            }
            else
            {
                taxationCode = row.TaxationDivCd;
            }
            #endregion

            #region ●定価
            //--------------------------------------------
            // 定価
            //--------------------------------------------
            double listPrice = 0;
            // 掛率算出した場合、掛率設定区分と基準価格が設定されている場合は基準単価が定価となる
            if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))
            {
                listPrice = row.StdUnPrcLPrice;	// 掛率算出した場合は基準価格が定価
            }
            // 掛率算出できていない場合は、定価を表示する
            //else if ((goodsPriceList != null) && (row.ListPriceRate == 0))
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //else
            else if (!_noneResettingListPriceFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                DateTime targetDate = new DateTime();

                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
                {
                    case AcptAnOdrStatusState.Estimate:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.UnitPriceEstimate:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.Sales:
                        targetDate = this._salesSlip.SalesDate; // 売上日
                        break;
                    case AcptAnOdrStatusState.Shipment:
                        targetDate = this._salesSlip.ShipmentDay; // 出荷日
                        break;
                }

                //-----------------------------------------------------------------------
                // 価格情報が存在する場合は、価格情報から基準定価確定
                //-----------------------------------------------------------------------
                if (goodsPriceList != null)
                {
                    object obj = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsPriceList);
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        //row.NewListPrice = goodsPrice.NewPrice;
                        //row.NewListPriceStartDate = goodsPrice.NewPriceStartDate;
                        //row.OldListPrice = goodsPrice.OldPrice;
                        //row.ListPriceOpenDiv = goodsPrice.OpenPriceDiv;
                        row.OpenPriceDiv = goodsPrice.OpenPriceDiv;

                        //listPrice = this.GetPrice(targetDate, row.NewListPrice, row.OldListPrice, row.NewListPriceStartDate, goodsPrice.OpenPriceDiv);
                        listPrice = goodsPrice.ListPrice;
                    }
                }
                //-----------------------------------------------------------------------
                // 価格情報が存在しない場合は、テーブル情報の価格情報から基準定価確定
                //-----------------------------------------------------------------------
                else
                {
                    //listPrice = this.GetPrice(targetDate, row.NewListPrice, row.OldListPrice, row.NewListPriceStartDate, row.ListPriceOpenDiv);
                    // ここ
                    listPrice = row.ListPriceDisplay;
                }

                //--------------------------------------------------
                // 定価
                //--------------------------------------------------
                double listPriceTaxExc;
                double listPriceTaxInc;
                if (row.ListPriceTaxExcFl != 0)
                {
                    listPriceTaxExc = row.ListPriceTaxExcFl;
                }
                else
                {
                    listPriceTaxExc = listPrice;
                }
                if (row.ListPriceTaxIncFl != 0)
                {
                    listPriceTaxInc = row.ListPriceTaxIncFl;
                }
                else
                {
                    listPriceTaxInc = listPrice;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // 総額表示しない
                //--------------------------------------------------
                if (this._salesSlip.TotalAmountDispWayCd == 0)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            // ①基準定価 = 定価(税抜)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // ②定価(税抜) = 掛率適用後の定価
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // ③定価(税込) = 定価(税抜) + (定価(税抜) * 税率)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // 定価(表示) = 定価(税抜)
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;


                            // 課税区分←外税
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            // ①基準定価 = 定価(税抜)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // ②定価(税込) = 掛率適用後の定価
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // ③定価(税抜) = 定価(税込) - (定価(税込)* 税率/税率+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // 定価(表示) = 定価(税込)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;

                            // 課税区分←非課税
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // 総額表示する
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            // ①基準定価 = 定価(税抜)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // ②定価(税抜) = 掛率適用後の定価
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // ③定価(税込) = 定価(税抜) + (定価(税抜) * 税率)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // 定価(表示) = 定価(税込)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // 課税区分←外税
                            row.TaxationDivCd = 0; // テーブルセット値は変更しない
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            // ①基準定価 = 定価(税抜)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // ②定価(税込) = 掛率適用後の定価
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // ③定価(税抜) = 定価(税込) - (定価(税込)* 税率/税率+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // 定価(表示) = 定価(税抜)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;


                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 定価
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            row.TaxationDivCd = 1;									// 課税区分←非課税
                            break;
                    }
                }
            }
            #endregion

            #region ●原単価
            //--------------------------------------------
            // 原単価
            //--------------------------------------------
            double unitCost = 0;
            // 掛率算出した場合、掛率設定区分と基準価格が設定されている場合は基準単価が原価となる
            if ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))
            {
                unitCost = row.StdUnPrcUnCst;	// 掛率算出した場合は基準価格が原価
            }
            // 掛率算出できていない場合は、ゼロを表示する
            //else if ((goodsPriceList != null) && (row.CostRate == 0))
            else
            {
                //unitCost = listPrice;
                unitCost = 0;

                //--------------------------------------------------
                // 原単価
                //--------------------------------------------------
                double unitCostTaxExc;
                double unitCostTaxInc;
                if (row.SalesUnitCostTaxExc != 0)
                {
                    unitCostTaxExc = row.SalesUnitCostTaxExc;
                }
                else
                {
                    unitCostTaxExc = unitCost;
                }
                if (row.SalesUnitCostTaxInc != 0)
                {
                    unitCostTaxInc = row.SalesUnitCostTaxInc;
                }
                else
                {
                    unitCostTaxInc = unitCost;
                }

                row.CanTaxDivChange = false;

                switch ((CalculateTax.TaxationCode)taxationCode)
                {
                    case CalculateTax.TaxationCode.TaxExc:
                        //--------------------------------------------------
                        // 原単価
                        //--------------------------------------------------
                        // ①基準原価 = 原価(税抜)
                        //row.StdUnPrcUnCst = unitCostTaxExc;

                        // ②原価(税抜) = 掛率適用後の原価
                        row.SalesUnitCostTaxExc = unitCostTaxExc;

                        // ③原価(税込) = 原価(税抜) + (原価(税抜) * 税率)
                        row.SalesUnitCostTaxInc = unitCostTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxExc);

                        // 原価(表示) = 原価(税抜)
                        row.SalesUnitCost = row.SalesUnitCostTaxExc;

                        // 課税区分←外税
                        row.TaxationDivCd = 0;
                        break;
                    case CalculateTax.TaxationCode.TaxInc:
                        //--------------------------------------------------
                        // 原単価
                        //--------------------------------------------------
                        // ①基準原価 = 原価(税抜)
                        //row.StdUnPrcUnCst = unitCostTaxExc;

                        // ②原価(税込) = 掛率適用後の原価
                        row.SalesUnitCostTaxInc = unitCostTaxInc;

                        // ③原価(税抜) = 原価(税込) - (原価(税込)* 税率/税率+100)
                        row.SalesUnitCostTaxExc = unitCostTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxInc);

                        // 原価(表示) = 原価(税込)
                        row.SalesUnitCost = row.SalesUnitCostTaxInc;

                        // 課税区分←内税
                        row.TaxationDivCd = 2;
                        break;
                    case CalculateTax.TaxationCode.TaxNone:
                        //--------------------------------------------------
                        // 原単価
                        //--------------------------------------------------
                        //row.StdUnPrcUnCst = unitCostTaxExc;
                        row.SalesUnitCostTaxInc = unitCostTaxExc;
                        row.SalesUnitCostTaxExc = unitCostTaxExc;
                        row.SalesUnitCost = row.SalesUnitCostTaxExc;

                        // 課税区分←非課税
                        row.TaxationDivCd = 1;
                        break;
                }
            }
            #endregion

            #region ●売単価
            //--------------------------------------------
            // 売単価
            //--------------------------------------------
            double unitPrice = 0;
            // 掛率算出した場合、掛率設定区分と基準価格が設定されている場合は基準単価が売単価となる
            if ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))
            {
                unitPrice = row.StdUnPrcSalUnPrc;	// 掛率算出した場合は基準価格が売単価
            }
            // 掛率算出できていない場合(売上金額手入力以外)
            else if (row.SalesMoneyInputDiv != (int)SalesMoneyInputDiv.Input)
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // ゼロ表示
                    case 0:
                        unitPrice = 0;
                        break;
                    // 定価表示
                    case 1:
                        unitPrice = listPrice;
                        break;
                    default:
                        unitPrice = 0;
                        break;
                }

                //--------------------------------------------------
                // 売単価
                //--------------------------------------------------
                double goodsPriceTaxExc;
                double goodsPriceTaxInc;
                if (row.SalesUnPrcTaxExcFl != 0)
                {
                    goodsPriceTaxExc = row.SalesUnPrcTaxExcFl;
                }
                else
                {
                    goodsPriceTaxExc = unitPrice;
                }
                if (row.SalesUnPrcTaxIncFl != 0)
                {
                    goodsPriceTaxInc = row.SalesUnPrcTaxIncFl;
                }
                else
                {
                    goodsPriceTaxInc = unitPrice;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // 総額表示しない
                //--------------------------------------------------
                if (this._salesSlip.TotalAmountDispWayCd == 0)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            // ①基準単価 = 税抜単価
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税抜) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // ③売上単価(税込) = 売上単価(税抜) + (売上単価(税抜) * 税率)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxExc);

                            // 表示単価 = 税抜単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // 課税区分←外税
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            // ①基準単価 = 税抜価格
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税込) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // ③売上単価(税抜) = 売上単価(税込) - (売上単価(税込)* 税率/税率+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxInc);

                            // 表示単価 = 税込単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // 課税区分←非課税
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // 総額表示する
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            // ①基準単価 = 税抜単価
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税抜) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // ③売上単価(税込) = 売上単価(税抜) + (売上単価(税抜) * 税率)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxExc);

                            // 表示単価 = 税込単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // 課税区分←外税
                            row.TaxationDivCd = 0; // テーブルセット値は変更しない
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            // ①基準単価 = 税抜価格
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // ②売上単価(税込) = 掛率適用後の仕入単価
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // ③売上単価(税抜) = 売上単価(税込) - (売上単価(税込)* 税率/税率+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxInc);

                            // 表示単価 = 税込単価
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // 課税区分←内税
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // 売単価
                            //--------------------------------------------------
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            row.TaxationDivCd = 1;									// 課税区分←非課税
                            break;
                    }
                }
            }
            #endregion

            #region ●共通
            if (row.TaxationDivCd == 1)
            {
                row.TaxDiv = 1;												// 課税区分←非課税
            }
            else
            {
                row.TaxDiv = 0;												// 課税区分←課税
            }
            #endregion
        }

        /// <summary>
        /// 単価算出モジュールにより、単価を算出します。（受注情報）
        /// </summary>
        /// <param name="row">受注明細行オブジェクト</param>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <returns>単価算出結果オブジェクト</returns>
        private List<UnitPriceCalcRet> CalclationUnitPriceForAcptAnOdr(SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

            if ((row.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(row.GoodsNo)))
            {
                unitPriceCalcParam.BLGoodsCode = row.RateBLGoodsCode;                   // BLコード
                unitPriceCalcParam.BLGoodsName = row.RateBLGoodsName;                   // BLコード名称
                unitPriceCalcParam.BLGroupCode = row.RateBLGroupCode;                   // BLグループコード
                unitPriceCalcParam.CountFl = row.AcceptAnOrderCntDisplay;               // 数量
                unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;         // 得意先コード
                unitPriceCalcParam.CustRateGrpCode = row.CustRateGrpCode;               // 得意先掛率グループコード
                unitPriceCalcParam.GoodsMakerCd = row.GoodsMakerCd;                     // メーカーコード
                unitPriceCalcParam.GoodsNo = row.GoodsNo;                               // 品番
                unitPriceCalcParam.GoodsRateGrpCode = row.RateGoodsRateGrpCd;           // 商品掛率グループコード
                unitPriceCalcParam.GoodsRateRank = row.GoodsRateRank;                   // 商品掛率ランク
                unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate;          // 適用日
                int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd); // 売上消費税端数処理コード(得意先マスタより取得)
                unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;         // 売上消費税端数処理コード
                int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd); // 売上単価端数処理コード(得意先マスタより取得)
                unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;           // 売上単価端数処理コード
                unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;     // 拠点コード
                int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd); // 仕入消費税端数処理コード(仕入先マスタより取得)
                unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;         // 仕入消費税端数処理コード
                int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd); // 仕入単価端数処理コード(仕入先マスタより取得)
                unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;           // 仕入単価端数処理コード
                unitPriceCalcParam.SupplierCd = row.SupplierCd;                         // 仕入先コード
                unitPriceCalcParam.TaxationDivCd = row.TaxationDivCd;                   // 課税区分
                unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;               // 税率
                unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // 総額表示方法区分
                unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;    // 総額表示掛率適用区分 0:(税込金額×掛率) 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)
                unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod; // 消費税転嫁方式

                this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            }
            return unitPriceCalcRetList;
        }

        /// <summary>
        /// 単価算出モジュールにより、単価を算出します。
        /// </summary>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice()
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            // 仕入単価端数処理コードディクショナリ
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();
            // 仕入消費税端数処理コードディクショナリ
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();
            // 売上単価端数処理コード(得意先マスタより取得)
            int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            // 売上消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 仕入単価端数処理コード
            int stockUnPrcFrcProcCd = 0;
            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = 0;

            foreach (SalesInputDataSet.SalesDetailRow salesDetailRow in this._salesDetailDataTable)
            {
                if ((salesDetailRow.GoodsMakerCd == 0) || (string.IsNullOrEmpty(salesDetailRow.GoodsNo))) continue;

                //>>>2010/10/01
                //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(salesDetailRow.GoodsMakerCd, salesDetailRow.GoodsNo);
                GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(salesDetailRow.GoodsMakerCd, salesDetailRow.GoodsNo, salesDetailRow);
                //<<<2010/10/01
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.BLGoodsCode = salesDetailRow.RateBLGoodsCode;                // BLコード
                    unitPriceCalcParam.BLGoodsName = salesDetailRow.RateBLGoodsName;                // BLコード名称
                    unitPriceCalcParam.BLGroupCode = salesDetailRow.RateBLGroupCode;                // BLグループコード
                    unitPriceCalcParam.CountFl = salesDetailRow.ShipmentCntDisplay;                 // 数量
                    unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                 // 得意先コード
                    unitPriceCalcParam.CustRateGrpCode = salesDetailRow.CustRateGrpCode;            // 得意先掛率グループコード
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // メーカーコード
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // 商品番号
                    unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // 商品掛率グループコード
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // 商品掛率ランク
                    unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate; 　　　　　       // 適用日
                    unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;                 // 売上消費税端数処理コード
                    unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // 売上単価端数処理コード
                    unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;             // 拠点コード
                    if (stockCnsTaxFrcProcCdDic.ContainsKey(salesDetailRow.SupplierCd))
                    {
                        stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[salesDetailRow.SupplierCd];  // 仕入消費税端数処理コード(ディクショナリか仕入先マスタから取得)
                    }
                    else
                    {
                        stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailRow.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        stockCnsTaxFrcProcCdDic.Add(salesDetailRow.SupplierCd, stockCnsTaxFrcProcCd);
                    }
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
                    
                    if (stockUnPrcFrcProcCdDic.ContainsKey(salesDetailRow.SupplierCd))
                    {
                        stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[salesDetailRow.SupplierCd];    // 仕入単価端数処理コード(ディクショナリか仕入先マスタから取得)
                    }
                    else
                    {
                        stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailRow.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                        stockUnPrcFrcProcCdDic.Add(salesDetailRow.SupplierCd, stockUnPrcFrcProcCd);
                    }
                    unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // 仕入単価端数処理コード
                    unitPriceCalcParam.SupplierCd = salesDetailRow.SupplierCd;                      // 仕入先コード
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // 課税区分
                    unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // 税率
                    unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // 総額表示方法区分
                    unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;	// 総額表示掛率適用区分
                    unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;         // 消費税転嫁方式

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, tempGoodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }

        /// <summary>
        /// 単価算出モジュールにより、単価を算出します。
        /// </summary>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPriceForAcptAnOdr()
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            // 仕入単価端数処理コードディクショナリ
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();
            // 仕入消費税端数処理コードディクショナリ
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();
            // 売上単価端数処理コード(得意先マスタより取得)
            int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            // 売上消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 仕入単価端数処理コード
            int stockUnPrcFrcProcCd = 0;
            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = 0;

            foreach (SalesInputDataSet.SalesDetailAcceptAnOrderRow salesDetailRow in this._salesDetailAcceptAnOrderDataTable)
            {
                if ((salesDetailRow.GoodsMakerCd == 0) || (string.IsNullOrEmpty(salesDetailRow.GoodsNo))) continue;

                //>>>2010/10/01
                //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(salesDetailRow.GoodsMakerCd, salesDetailRow.GoodsNo);
                SalesInputDataSet.SalesDetailRow aRow = this._salesDetailDataTable.NewSalesDetailRow();
                this.CopySalesDetailFromAcceptAnOrder(salesDetailRow, aRow); // 受注→売上
                GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(salesDetailRow.GoodsMakerCd, salesDetailRow.GoodsNo, aRow);
                //<<<2010/10/01
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.BLGoodsCode = salesDetailRow.RateBLGoodsCode;                // BLコード
                    unitPriceCalcParam.BLGoodsName = salesDetailRow.RateBLGoodsName;                // BLコード名称
                    unitPriceCalcParam.BLGroupCode = salesDetailRow.RateBLGroupCode;                // BLグループコード
                    unitPriceCalcParam.CountFl = salesDetailRow.ShipmentCntDisplay;                 // 数量
                    unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                 // 得意先コード
                    unitPriceCalcParam.CustRateGrpCode = salesDetailRow.CustRateGrpCode;            // 得意先掛率グループコード
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // メーカーコード
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // 商品番号
                    unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // 商品掛率グループコード
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // 商品掛率ランク
                    unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate; 　　　　　       // 適用日
                    unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;                 // 売上消費税端数処理コード
                    unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // 売上単価端数処理コード
                    unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;             // 拠点コード
                    if (stockCnsTaxFrcProcCdDic.ContainsKey(salesDetailRow.SupplierCd))
                    {
                        stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[salesDetailRow.SupplierCd];  // 仕入消費税端数処理コード(ディクショナリか仕入先マスタから取得)
                    }
                    else
                    {
                        stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailRow.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        stockCnsTaxFrcProcCdDic.Add(salesDetailRow.SupplierCd, stockCnsTaxFrcProcCd);
                    }
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;

                    if (stockUnPrcFrcProcCdDic.ContainsKey(salesDetailRow.SupplierCd))
                    {
                        stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[salesDetailRow.SupplierCd];    // 仕入単価端数処理コード(ディクショナリか仕入先マスタから取得)
                    }
                    else
                    {
                        stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailRow.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                        stockUnPrcFrcProcCdDic.Add(salesDetailRow.SupplierCd, stockUnPrcFrcProcCd);
                    }
                    unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // 仕入単価端数処理コード
                    unitPriceCalcParam.SupplierCd = salesDetailRow.SupplierCd;                      // 仕入先コード
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // 課税区分
                    unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // 税率
                    unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // 総額表示方法区分
                    unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;	// 総額表示掛率適用区分
                    unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;         // 消費税転嫁方式

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, tempGoodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }

        /// <summary>
        /// 単価算出モジュールにより、単価を算出します。
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice(List<GoodsUnitData> goodsUnitDataList)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            // 仕入単価端数処理コードディクショナリ
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();
            // 仕入消費税端数処理コードディクショナリ
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();
            // 売上単価端数処理コード(得意先マスタより取得)
            int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            // 売上消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 仕入単価端数処理コード
            int stockUnPrcFrcProcCd = 0;
            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = 0;

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BLコード
                    unitPriceCalcParam.BLGoodsName = goodsUnitData.BLGoodsFullName;                 // BLコード名称
                    unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                     // BLグループコード
                    unitPriceCalcParam.CountFl = 0;                                                 // 数量
                    unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                 // 得意先コード
                    unitPriceCalcParam.CustRateGrpCode = this.GetCustRateGroupCode(goodsUnitData.GoodsMakerCd);           // 得意先掛率グループコード
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // メーカーコード
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // 商品番号
                    unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // 商品掛率グループコード
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // 商品掛率ランク
                    unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate; 　　　　　       // 適用日
                    unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;                 // 売上消費税端数処理コード
                    unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // 売上単価端数処理コード
                    unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;             // 拠点コード
                    if (stockCnsTaxFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                    {
                        stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[goodsUnitData.SupplierCd];   // 仕入消費税端数処理コード(ディクショナリか仕入先マスタから取得)
                    }
                    else
                    {
                        stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        stockCnsTaxFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockCnsTaxFrcProcCd);
                    }
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;

                    if (stockUnPrcFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                    {
                        stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[goodsUnitData.SupplierCd];     // 仕入単価端数処理コード(ディクショナリか仕入先マスタから取得)
                    }
                    else
                    {
                        stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                        stockUnPrcFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockUnPrcFrcProcCd);
                    }
                    unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // 仕入単価端数処理コード
                    unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                       // 仕入先コード
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // 課税区分
                    unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // 税率
                    unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // 総額表示方法区分
                    unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;	// 総額表示掛率適用区分
                    unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;         // 消費税転嫁方式

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, tempGoodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }

        /// <summary>
        ///  得意先掛率グループコード取得処理
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int GetCustRateGroupCode(int goodsMakerCode)
        {
            int pureCode = (goodsMakerCode <= ctPureGoodsMakerCode) ? 0 : 1; // 0:純正 1:優良

            // 単独キー
            CustRateGroup custRateGroup = this._custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == goodsMakerCode) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup.CustRateGrpCode;

            // 共通キー
            custRateGroup = this._custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == 0) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup.CustRateGrpCode;

            //return 0; // DEL 2010/07/16
            return -1; // ADD 2010/07/16
        }

        /// <summary>
        /// 単価情報クリア処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        private void ClearUnitInfo(ref SalesInputDataSet.SalesDetailRow row, string unitPriceKind)
        {
            // 定価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_ListPrice)
            {
                row.ListPriceRate = 0;
                row.ListPriceDisplay = 0;
                row.ListPriceTaxExcFl = 0;
                row.ListPriceTaxIncFl = 0;
            }
            // 原価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
            {
                row.CostRate = 0;
                row.SalesUnitCost = 0;
                row.SalesUnitCostTaxExc = 0;
                row.SalesUnitCostTaxInc = 0;
            }
            // 売価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice)
            {
                row.SalesRate = 0;
                row.GrossProfitSecureRate = 0;
                row.CostUpRate = 0;
                row.SalesUnPrcDisplay = 0;
                row.SalesUnPrcTaxExcFl = 0;
                row.SalesUnPrcTaxIncFl = 0;
            }
            this.ClearRateInfo(ref row, unitPriceKind);
        }

        /// <summary>
        /// 単価情報クリア処理（受注情報用）
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        private void ClearUnitInfo(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, string unitPriceKind)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();

            this.CopySalesDetailFromAcceptAnOrder(row, newSalesDetailRow);
            this.ClearUnitInfo(ref newSalesDetailRow, unitPriceKind);
            this.CopyAcceptAnOrderFromSalesDetail(newSalesDetailRow, row);
        }

        /// <summary>
        /// 掛率情報クリア処理
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <param name="unitPriceKind"></param>
        public void ClearRateInfo(int salesRowNo, string unitPriceKind)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null) this.ClearRateInfo(ref row, unitPriceKind);
        }

        /// <summary>
        /// 掛率情報クリア処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <br>Update Note: 2010/03/22 李侠 原価計算処理の不具合対応</br>
        /// <br>Update Note: 2011/08/15 Redmine#23554 譚洪 掛率マスタの売価率設定ありで且つ、キャンペーンの売価額設定ありの場合、売価率はクリアの対応</br>
        /// <br>Update Note: 2011/09/05 Redmine#23554 yangmj 掛率マスタの売価率設定ありで且つ、キャンペーンの売価額設定ありの場合、売価率はクリアの対応</br>
        private void ClearRateInfo(ref SalesInputDataSet.SalesDetailRow row, string unitPriceKind)
        {
            // 定価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_ListPrice)
            {
                row.RateSectPriceUnPrc = string.Empty;
                row.RateDivLPrice = string.Empty;
                row.UnPrcCalcCdLPrice = 0;
                row.PriceCdLPrice = 0;
                row.StdUnPrcLPrice = 0;
                row.FracProcUnitLPrice = 0;
                row.FracProcLPrice = 0;

                //row.BfListPrice = 0;
            }
            // 原価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
            {
                row.RateSectCstUnPrc = string.Empty;
                row.RateDivUnCst = string.Empty;
                row.UnPrcCalcCdUnCst = 0;
                row.PriceCdUnCst = 0;
                // --- DEL 2010/03/22 ---------->>>>>
                // 標準価格の掛率設定において、ユーザー定価を設定するため、クリアしない。
                //row.StdUnPrcUnCst = 0;
                // --- DEL 2010/03/22 ----------<<<<<
                row.FracProcUnitUnCst = 0;
                row.FracProcUnCst = 0;

                //row.BfUnitCost = 0;
            }
            // 売価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice)
            {
                // ADD 2011/08/15 ----- >>>>>
                if (row.UnPrcCalcCdSalUnPrcTemp != -1)
                {
                    row.UnPrcCalcCdSalUnPrcTemp = row.UnPrcCalcCdSalUnPrc;
                }
                // ADD 2011/08/15 ----- <<<<<

                row.RateSectSalUnPrc = string.Empty;
                row.RateDivSalUnPrc = string.Empty;
                row.UnPrcCalcCdSalUnPrc = 0;
                row.PriceCdSalUnPrc = 0;
                // --- DEL m.suzuki 2011/02/16 ---------->>>>>
                //row.StdUnPrcSalUnPrc = 0;
                // --- DEL m.suzuki 2011/02/16 ----------<<<<<
                row.FracProcUnitSalUnPrc = 0;
                row.FracProcSalUnPrc = 0;

                // DEL 2011/09/05 ---- >>>>
                // ADD 2011/08/15 ---- >>>>
                //if (this.CampaignObjGoodsStInfo != null && this.CampaignObjGoodsStInfo.RateVal == 0)
                //{
                //    row.SalesRate = 0;
                //}
                // ADD 2011/08/15 ---- <<<<
                // DEL 2011/09/05 ---- <<<<

                //row.BfSalesUnitPrice = 0;
            }
        }

        // ADD 2011/09/05 ---- >>>>
        /// <summary>
        /// 掛率情報クリア処理(キャンペーン用)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/09/05</br>
        private void ClearRateInfoForCampaign(ref SalesInputDataSet.SalesDetailRow row, string unitPriceKind)
        {
            // 定価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_ListPrice)
            {
                row.RateSectPriceUnPrc = string.Empty;
                row.RateDivLPrice = string.Empty;
                row.UnPrcCalcCdLPrice = 0;
                row.PriceCdLPrice = 0;
                row.StdUnPrcLPrice = 0;
                row.FracProcUnitLPrice = 0;
                row.FracProcLPrice = 0;
            }
            // 原価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
            {
                row.RateSectCstUnPrc = string.Empty;
                row.RateDivUnCst = string.Empty;
                row.UnPrcCalcCdUnCst = 0;
                row.PriceCdUnCst = 0;
                row.FracProcUnitUnCst = 0;
                row.FracProcUnCst = 0;
            }
            // 売価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice)
            {
                if (row.UnPrcCalcCdSalUnPrcTemp != -1)
                {
                    row.UnPrcCalcCdSalUnPrcTemp = row.UnPrcCalcCdSalUnPrc;
                }
                row.RateSectSalUnPrc = string.Empty;
                row.RateDivSalUnPrc = string.Empty;
                row.UnPrcCalcCdSalUnPrc = 0;
                row.PriceCdSalUnPrc = 0;
                row.FracProcUnitSalUnPrc = 0;
                row.FracProcSalUnPrc = 0;

                if (this.CampaignObjGoodsStInfo != null && this.CampaignObjGoodsStInfo.RateVal == 0)
                {
                    row.SalesRate = 0;
                }
            }
        }
        // ADD 2011/09/05 ---- <<<

        /// <summary>
        /// 掛率情報クリア処理（受注情報用）
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        private void ClearRateInfo(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, string unitPriceKind)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();

            this.CopySalesDetailFromAcceptAnOrder(row, newSalesDetailRow);
            this.ClearRateInfo(ref newSalesDetailRow, unitPriceKind);
            this.CopyAcceptAnOrderFromSalesDetail(newSalesDetailRow, row);
        }

        /// <summary>
        /// 掛率情報クリア処理（全て）
        /// </summary>
        public void ClearAllRateInfo()
        {
            foreach (SalesInputDataSet.SalesDetailRow row in this._salesDetailDataTable)
            {
                if ((!string.IsNullOrEmpty(row.GoodsNo)) && (row.GoodsMakerCd != 0))
                {
                    row.RateSectPriceUnPrc = string.Empty;
                    row.RateDivLPrice = string.Empty;
                    row.UnPrcCalcCdLPrice = 0;
                    row.PriceCdLPrice = 0;
                    row.StdUnPrcLPrice = 0;
                    row.FracProcUnitLPrice = 0;
                    row.FracProcLPrice = 0;

                    row.RateSectCstUnPrc = string.Empty;
                    row.RateDivUnCst = string.Empty;
                    row.UnPrcCalcCdUnCst = 0;
                    row.PriceCdUnCst = 0;
                    row.StdUnPrcUnCst = 0;
                    row.FracProcUnitUnCst = 0;
                    row.FracProcUnCst = 0;

                    row.RateSectSalUnPrc = string.Empty;
                    row.RateDivSalUnPrc = string.Empty;
                    row.UnPrcCalcCdSalUnPrc = 0;
                    row.PriceCdSalUnPrc = 0;
                    row.StdUnPrcSalUnPrc = 0;
                    row.FracProcUnitSalUnPrc = 0;
                    row.FracProcSalUnPrc = 0;

                    row.BfListPrice = 0;
                    row.BfSalesUnitPrice = 0;
                    row.BfUnitCost = 0;
                }
            }

            foreach (SalesInputDataSet.SalesDetailAcceptAnOrderRow row in this._salesDetailAcceptAnOrderDataTable)
            {
                if ((!string.IsNullOrEmpty(row.GoodsNo)) && (row.GoodsMakerCd != 0))
                {
                    row.RateSectPriceUnPrc = string.Empty;
                    row.RateDivLPrice = string.Empty;
                    row.UnPrcCalcCdLPrice = 0;
                    row.PriceCdLPrice = 0;
                    row.StdUnPrcLPrice = 0;
                    row.FracProcUnitLPrice = 0;
                    row.FracProcLPrice = 0;

                    row.RateSectCstUnPrc = string.Empty;
                    row.RateDivUnCst = string.Empty;
                    row.UnPrcCalcCdUnCst = 0;
                    row.PriceCdUnCst = 0;
                    row.StdUnPrcUnCst = 0;
                    row.FracProcUnitUnCst = 0;
                    row.FracProcUnCst = 0;

                    row.RateSectSalUnPrc = string.Empty;
                    row.RateDivSalUnPrc = string.Empty;
                    row.UnPrcCalcCdSalUnPrc = 0;
                    row.PriceCdSalUnPrc = 0;
                    row.StdUnPrcSalUnPrc = 0;
                    row.FracProcUnitSalUnPrc = 0;
                    row.FracProcSalUnPrc = 0;

                    row.BfListPrice = 0;
                    row.BfSalesUnitPrice = 0;
                    row.BfUnitCost = 0;
                }
            }
        }
        # endregion

        ///// <summary>
        ///// 指定した単価情報画面の結果情報を元に、売上明細データ行オブジェクトに売単価情報を設定します。
        ///// </summary>
        ///// <param name="stockRowNo">行番号</param>
        ///// <param name="unPrcInfoConfRet">単価情報確認画面結果オブジェクト</param>
        //public void SalesDetailRowUnPrcInfoSetting(int salesRowNo, UnPrcInfoConfRet unPrcInfoConfRet, string unitPriceKind)
        //{
        //    SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

        //    if (row != null)
        //    {

        //        if (UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice == unitPriceKind)
        //        {
        //            //--------------------------------------------
        //            // 売単価
        //            //--------------------------------------------
        //            row.UnPrcCalcCdSalUnPrc = unPrcInfoConfRet.UnitPrcCalcDiv;      // 単価算出区分
        //            row.SalesRate = unPrcInfoConfRet.RateVal;                       // 掛率
        //            row.StdUnPrcSalUnPrc = unPrcInfoConfRet.StdUnitPrice;           // 基準単価
        //            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
        //            {
        //                row.SalesUnPrcDisplay = unPrcInfoConfRet.UnitPriceTaxIncFl;		    // 単価（浮動）
        //                // 売上明細データセッティング処理（単価設定）
        //                this.SalesDetailRowSalesUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxIncFl);
        //            }
        //            else
        //            {
        //                row.SalesUnPrcDisplay = unPrcInfoConfRet.UnitPriceTaxExcFl;		    // 単価（浮動）
        //                // 売上明細データセッティング処理（単価設定）
        //                this.SalesDetailRowSalesUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxExcFl);
        //            }
        //            row.FracProcUnitSalUnPrc = unPrcInfoConfRet.UnPrcFracProcUnit;  // 端数処理単位
        //            row.FracProcSalUnPrc = unPrcInfoConfRet.UnPrcFracProcDiv;       // 端数処理区分

        //            this.SalesDetailRowUnitPriceSetting(ref row, null);
        //            this.SalesDetailRowSalesUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, row.SalesUnPrcDisplay);
        //        }
        //        else if (UnitPriceCalculation.ctUnitPriceKind_UnitCost == unitPriceKind)
        //        {
        //            //--------------------------------------------
        //            // 原単価
        //            //--------------------------------------------
        //            row.UnPrcCalcCdUnCst = unPrcInfoConfRet.UnitPrcCalcDiv;         // 単価算出区分
        //            row.CostRate = unPrcInfoConfRet.RateVal;                        // 掛率
        //            row.StdUnPrcUnCst = unPrcInfoConfRet.StdUnitPrice;              // 基準単価
        //            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
        //            {
        //                row.SalesUnitCost = unPrcInfoConfRet.UnitPriceTaxIncFl;		        // 単価（浮動）
        //                // 売上明細データセッティング処理（原価設定）
        //                this.SalesDetailRowSalesUnitCostSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxIncFl);
        //            }
        //            else
        //            {
        //                row.SalesUnitCost = unPrcInfoConfRet.UnitPriceTaxExcFl;		        // 単価（浮動）
        //                // 売上明細データセッティング処理（原価設定）
        //                this.SalesDetailRowSalesUnitCostSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxExcFl);
        //            }
        //            row.FracProcUnitUnCst = unPrcInfoConfRet.UnPrcFracProcUnit;     // 端数処理単位
        //            row.FracProcUnCst = unPrcInfoConfRet.UnPrcFracProcDiv;          // 端数処理区分

        //            this.SalesDetailRowUnitPriceSetting(ref row, null);
        //            //this.StockDetailRowStockUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, row.SalesUnPrcDisplay);
        //        }
        //        else if (UnitPriceCalculation.ctUnitPriceKind_ListPrice == unitPriceKind)
        //        {
        //            //--------------------------------------------
        //            // 定価
        //            //--------------------------------------------
        //            row.UnPrcCalcCdLPrice = unPrcInfoConfRet.UnitPrcCalcDiv;         // 単価算出区分
        //            row.ListPriceRate = unPrcInfoConfRet.RateVal;                        // 掛率
        //            row.StdUnPrcLPrice = unPrcInfoConfRet.StdUnitPrice;              // 基準単価
        //            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
        //            {
        //                row.ListPriceDisplay = unPrcInfoConfRet.UnitPriceTaxIncFl;		        // 単価（浮動）
        //                // 売上明細データセッティング処理（定価設定）
        //                this.SalesDetailRowListPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxIncFl);
        //            }
        //            else
        //            {
        //                row.ListPriceDisplay = unPrcInfoConfRet.UnitPriceTaxExcFl;		        // 単価（浮動）
        //                // 売上明細データセッティング処理（定価設定）
        //                this.SalesDetailRowListPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxExcFl);
        //            }
        //            row.FracProcUnitLPrice = unPrcInfoConfRet.UnPrcFracProcUnit;     // 端数処理単位
        //            row.FracProcLPrice = unPrcInfoConfRet.UnPrcFracProcDiv;          // 端数処理区分

        //            this.SalesDetailRowUnitPriceSetting(ref row, null);
        //            //this.StockDetailRowStockUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, row.SalesUnPrcDisplay);
        //        }
        //    }
        //}

        /// <summary>
        /// 商品価格の再設定を行います。
        /// </summary>
        /// <param name="salesRowNo"></param>
        public void SalesDetailRowGoodsPriceReSetting(List<List<GoodsUnitData>> goodsUnitDataListList)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            this.GetGoodsUnitDataListFromListList(goodsUnitDataListList, out goodsUnitDataList);
            this.SalesDetailRowGoodsPriceReSetting(goodsUnitDataList);
        }

        /// <summary>
        /// 商品価格の再設定を行います。
        /// </summary>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        public void SalesDetailRowGoodsPriceReSetting(List<GoodsUnitData> goodsUnitDataList)
        {
            // 税率再セット
            // --- UPD 2014/04/02 Y.Wakita ---------->>>>>
            //this._salesSlip.ConsTaxRate = _salesSlipInputInitDataAcs.TaxRate;
            this._salesSlip.ConsTaxRate = this._salesSlipInputInitDataAcs.GetTaxRate(this._salesSlip.SalesDate); // 税率
            // --- UPD 2014/04/02 Y.Wakita ----------<<<<<

            List<UnitPriceCalcRet> allUnitPriceCalcRetList = this.CalclationUnitPrice();
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            for (int i = 0; i < this._salesDetailDataTable.Rows.Count; i++)
            {
                SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable[i];

                if (((row.EditStatus == ctEDITSTATUS_AllOK) || (row.EditStatus == ctEDITSTATUS_AddUpEdit) || (row.EditStatus == ctEDITSTATUS_AddUpNew)) &&
                    (!string.IsNullOrEmpty(row.GoodsNo)) || (!string.IsNullOrEmpty(row.GoodsName)))
                {
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    //>>>2010/10/01
                    //goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
                    goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
                    //<<<2010/10/01
                    unitPriceCalcRetList = this.GetUnitPriceCalcRetList(allUnitPriceCalcRetList, row.GoodsNo, row.GoodsMakerCd, row.SupplierCd);
                    this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, true, unitPriceCalcRetList);
                }
            }
        }

        /// <summary>
        /// 商品価格の再設定を行います。
        /// </summary>
        public void SalesDetailRowGoodsPriceReSetting(int salesRowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            this.SalesDetailRowGoodsPriceReSetting(row);
        }

        // ------ ADD 2011/09/05 --------- >>>>>>
        /// <summary>
        /// 商品価格の再設定を行います「販売区分チェック用」。
        /// </summary>
        public void SalesDetailRowGoodsPriceForSalesCodeCheck(int salesRowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailRow rowBak = this._salesDetailDataTable.NewSalesDetailRow();
            rowBak.GoodsMakerCd = row.GoodsMakerCd;
            rowBak.GoodsNo = row.GoodsNo;
            rowBak.BLGroupCode = row.BLGroupCode;  // ADD 2011/09/14
            rowBak.BLGoodsCode = row.BLGoodsCode;
            rowBak.SupplierCd = row.SupplierCd;
            rowBak.RateBLGoodsCode = row.RateBLGoodsCode;
            rowBak.RateBLGoodsName = row.RateBLGoodsName;
            rowBak.RateBLGroupCode = row.RateBLGroupCode;
            rowBak.ShipmentCntDisplay = row.ShipmentCntDisplay;
            rowBak.CustRateGrpCode = row.CustRateGrpCode;
            rowBak.RateGoodsRateGrpCd = row.RateGoodsRateGrpCd;
            rowBak.GoodsRateRank = row.GoodsRateRank;
            rowBak.TaxationDivCd = row.TaxationDivCd;
            rowBak.SalesUnPrcTaxExcFl = row.SalesUnPrcTaxExcFl;
            rowBak.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxIncFl;
            rowBak.SalesCode = row.SalesCode;
            rowBak.ListPriceDisplay = row.ListPriceDisplay;
            rowBak.ListPriceTaxExcFl = row.ListPriceTaxExcFl;
            rowBak.ListPriceTaxIncFl = row.ListPriceTaxIncFl;
            rowBak.SalesUnitCostTaxExc = row.SalesUnitCostTaxExc;
            rowBak.SalesUnitCostTaxInc = row.SalesUnitCostTaxInc;
            rowBak.StdUnPrcUnCst = row.StdUnPrcUnCst;
            rowBak.RateDivUnCst = row.RateDivUnCst;
            rowBak.StdUnPrcLPrice = row.StdUnPrcLPrice;
            rowBak.RateDivLPrice = row.RateDivLPrice;
            this.SalesDetailRowGoodsPriceForSalesCodeCheck(rowBak);
        }

        /// <summary>
        /// 商品価格の再設定を行います「販売区分チェック用」。
        /// </summary>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        public void SalesDetailRowGoodsPriceForSalesCodeCheck(SalesInputDataSet.SalesDetailRow row)
        {
            // 税率再セット
            // --- UPD 2014/04/02 Y.Wakita ---------->>>>>
            //this._salesSlip.ConsTaxRate = _salesSlipInputInitDataAcs.TaxRate;
            this._salesSlip.ConsTaxRate = this._salesSlipInputInitDataAcs.GetTaxRate(this._salesSlip.SalesDate); // 税率
            // --- UPD 2014/04/02 Y.Wakita ----------<<<<<

            if (((row.EditStatus == ctEDITSTATUS_AllOK) || (row.EditStatus == ctEDITSTATUS_AddUpEdit) ||
                 (row.EditStatus == ctEDITSTATUS_AddUpNew) || (row.EditStatus == ctEDITSTATUS_ExistSlip)))
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();

                goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);

                this.SalesDetailRowGoodsPriceForSalesCodeCheck(row, goodsUnitData, true);
            }
        }
        // ------ ADD 2011/09/05 --------- <<<<<<

        /// <summary>
        /// 商品価格の再設定を行います。
        /// </summary>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        public void SalesDetailRowGoodsPriceReSetting(SalesInputDataSet.SalesDetailRow row)
        {
            // 税率再セット
            // --- UPD 2014/04/02 Y.Wakita ---------->>>>>
            //this._salesSlip.ConsTaxRate = _salesSlipInputInitDataAcs.TaxRate;
            // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>>
            if (this._salesSlip.ConsTaxLayMethod == 0 && (this._salesSlipInputInitDataAcs.TaxRateInput == 0.0 ||
                this._salesSlipInputInitDataAcs.RentSyncSupFlg || (!this._salesSlipInputInitDataAcs.SlipSrcTaxFlg &&
                this._salesSlip.SalesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum)))
            {
                this._salesSlip.ConsTaxRate = this._salesSlipInputInitDataAcs.GetTaxRateMst(this._salesSlip.SalesDate); // 税率
                this._salesSlipInputInitDataAcs.TaxRate = this._salesSlip.ConsTaxRate;
                this._salesSlipInputInitDataAcs.TaxRateDiv = 2;
            }
            else
            {
                // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<
                this._salesSlip.ConsTaxRate = this._salesSlipInputInitDataAcs.GetTaxRate(this._salesSlip.SalesDate); // 税率
            }// ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応
            // --- UPD 2014/04/02 Y.Wakita ----------<<<<<

            //>>>2010/10/04
            //if (((row.EditStatus == ctEDITSTATUS_AllOK) || (row.EditStatus == ctEDITSTATUS_AddUpEdit) || 
            //     (row.EditStatus == ctEDITSTATUS_AddUpNew) || (row.EditStatus == ctEDITSTATUS_ExistSlip)) &&
            //    (!string.IsNullOrEmpty(row.GoodsNo)))
            if (((row.EditStatus == ctEDITSTATUS_AllOK) || (row.EditStatus == ctEDITSTATUS_AddUpEdit) ||
                 (row.EditStatus == ctEDITSTATUS_AddUpNew) || (row.EditStatus == ctEDITSTATUS_ExistSlip)))
            //<<<2010/10/04
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();
                //>>>2010/10/01
                //goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
                goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
                //<<<2010/10/01
                this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, true);
            }
        }

        /// <summary>
        /// 単価算出結果クラス対象レコード取得処理
        /// </summary>
        /// <param name="unitPriceCalcRetList"></param>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="supplierCd"></param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> GetUnitPriceCalcRetList(List<UnitPriceCalcRet> unitPriceCalcRetList, string goodsNo, int goodsMakerCd, int supplierCd)
        {
            List<UnitPriceCalcRet> retUnitPriceCalcRetList = new List<UnitPriceCalcRet>();
            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if ((((!string.IsNullOrEmpty(unitPriceCalcRet.GoodsNo)) && (unitPriceCalcRet.GoodsNo == goodsNo)) || 
                     (string.IsNullOrEmpty(unitPriceCalcRet.GoodsNo))) &&
                    (((unitPriceCalcRet.GoodsMakerCd != 0) && (unitPriceCalcRet.GoodsMakerCd == goodsMakerCd)) ||
                     (unitPriceCalcRet.GoodsMakerCd == 0)) &&
                    (((unitPriceCalcRet.SupplierCd != 0) && (unitPriceCalcRet.SupplierCd == supplierCd)) || 
                     (unitPriceCalcRet.SupplierCd == 0)))
                {
                    UnitPriceCalcRet cloneUnitPriceCalcRet = unitPriceCalcRet.Clone();
                    retUnitPriceCalcRetList.Add(cloneUnitPriceCalcRet);
                }
            }
            return retUnitPriceCalcRetList;
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
        public void CalcTaxExcAndTaxInc(int taxationCode, int customerCode, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // 得意先マスタから消費税端数処理情報を取得
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 売上消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

            // 内税品
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
            }
            // 外税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // 総額表示している場合は税込み価格
                if (totalAmountDispWayCd == 1)
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
                }
            }
            // 非課税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
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

        /// <summary>
        /// 対象金額より、税抜き、税込み価格を計算します。
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="taxRate">税率</param>
        /// <param name="totalAmountDispWayCd">総額表示区分</param>
        /// <param name="displayPrice">対象金額</param>
        /// <param name="priceTaxExc">税抜き金額</param>
        /// <param name="priceTaxInc">税込み金額</param>
        public void CalcTaxExcAndTaxIncForStock(int taxationCode, int supplierCd, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // 仕入先マスタから消費税端数処理情報を取得
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, supplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// 仕入消費税端数処理コード
            double fracProcUnit;
            int fracProcCd;
            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

            // 内税品
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
            }
            // 外税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // 総額表示している場合は税込み価格
                if (totalAmountDispWayCd == 1)
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
                }
            }
            // 非課税品
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
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
        #endregion

        // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
        /// <summary>
        /// 初期入力を出荷数か受注数か判断
        /// </summary>
        /// <returns></returns>
        public bool CheckFocusPositionAfterBLCodeSearch(int salesRowNo)
        {
            bool status = false;

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                // 新規登録　または　各種計上
                if ((this._salesSlip.InputMode == ctINPUTMODE_SalesSlip_Normal &&
                     this._salesSlip.SalesSlipNum == ctDefaultSalesSlipNum) ||
                    (this._salesSlip.InputMode == ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp ||
                     this._salesSlip.InputMode == ctINPUTMODE_SalesSlip_EstimateAddUp ||
                     this._salesSlip.InputMode == ctINPUTMODE_SalesSlip_ShipmentAddUp))
                {
                    // 伝票種別：売上、貸出
                    if (this._salesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales ||
                        this._salesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Shipment)
                    {
                        // 伝票区分：掛売上
                        if (this._salesSlip.SalesSlipCd == (int)SalesSlipCd.Sales)
                        {
                            // 商品値引、行値引以外
                            if (row.EditStatus != ctEDITSTATUS_GoodsDiscount &&
                                row.EditStatus != ctEDITSTATUS_RowDiscount)
                            {
                                // 売上全体設定　受注数入力：する
                                // ユーザー設定　商品検索後のカーソル位置：受注数
                                if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrInputDiv == 1 &&
                                    SalesSlipInputConstructionAcs.GetInstance().FocusPositionAfterBLCodeSearchValue == 1)
                                {
                                    status = true;
                                }
                            }
                        }
                    }
                }
            }

            return status;
        }
        // --- ADD 2013/11/05 Y.Wakita ----------<<<<<


        // --- ADD 譚洪 2014/09/01 Redmine#43289---------->>>>>
        /// <summary>
        /// 車両情報がTHREADに設定します。
        /// </summary>
        /// <returns></returns>
        private void SetCarInfoToThread(GoodsCndtn cndtn)
        {
            // TLS用の変数
            CarInfoThreadData carInfoThreadData = new CarInfoThreadData();

            // 車両情報
            if (cndtn != null && cndtn.SearchCarInfo != null)
            {
                if (cndtn.SearchCarInfo.CarModelUIData.Count > 0)
                {
                    // 類別(PMの情報)
                    carInfoThreadData.ModelDesignationNo = cndtn.SearchCarInfo.CarModelUIData[0].ModelDesignationNo;
                    // 番号(PMの情報)
                    carInfoThreadData.CategoryNo = cndtn.SearchCarInfo.CarModelUIData[0].CategoryNo;
                    // 車台番号(PMの情報)
                    carInfoThreadData.FrameNo = cndtn.SearchCarInfo.CarModelUIData[0].FrameNo;
                    // 国産／外車区分(PMの情報)車輌管理マスタ「1:国産,2:外車」
                    carInfoThreadData.FrameNoKubun = cndtn.SearchCarInfo.CarModelUIData[0].DomesticForeignCode;
                    // 年式(PMの情報)
                    carInfoThreadData.FirstEntryDate = cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput;
                }

                if (cndtn.SearchCarInfo.CarModelInfoSummarized.Count > 0)
                {
                    PMKEN01010E.CarModelInfoRow[] row = (PMKEN01010E.CarModelInfoRow[])cndtn.SearchCarInfo.CarModelInfoSummarized.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                    if (row.Length > 0)
                    {
                        // メーカー(PMの情報)
                        carInfoThreadData.MakerCode = row[0].MakerCode;
                        // 車種(PMの情報)(PMの情報)
                        carInfoThreadData.ModelCode = row[0].ModelCode;
                        // 車種サブコード(PMの情報)
                        carInfoThreadData.ModelSubCode = row[0].ModelSubCode;
                        // 車種名(PMの情報)
                        carInfoThreadData.ModelFullName = row[0].ModelFullName;
                        // 型式(PMの情報)
                        carInfoThreadData.FullModel = row[0].FullModel;
                    }
                }
            }

            // 年式区分(PMの情報)全体初期値設定マスタの「0:西暦　1:和暦（年式）」
            carInfoThreadData.FirstEntryDateKubun = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            // 備考(PMの情報)
            carInfoThreadData.Note = this._salesSlip.SlipNote;
            // XMLファイル保存用
            carInfoThreadData.Pgid = PGID_XML;

            // SOLTを使う前に、FREE処理を実行します。
            Thread.FreeNamedDataSlot(CARINFOSOLT);
            carInfoSolt = Thread.AllocateNamedDataSlot(CARINFOSOLT);
            Thread.SetData(carInfoSolt, carInfoThreadData);
        }
        // --- ADD 譚洪 2014/09/01 Redmine#43289----------<<<<<

        // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 --------------------->>>>>
        /// <summary>
        /// 提供データ価格情報取得
        /// </summary>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        private void GetOfrPriceDataList(PartsInfoDataSet partsInfoDataSet, List<GoodsUnitData> goodsUnitDataList)
        {
            this.GetOfrPriceDataListProc(partsInfoDataSet, goodsUnitDataList, false);
        }

        /// <summary>
        /// 提供データ価格情報取得
        /// </summary>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <returns></returns>
        private void GetOfrPriceDataList(PartsInfoDataSet partsInfoDataSet, List<List<GoodsUnitData>> goodsUnitDataListList)
        {
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            foreach (List<GoodsUnitData> goodsUnitDataList in goodsUnitDataListList)
            {
                if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    this.GetOfrPriceDataListProc(partsInfoDataSet, goodsUnitDataList, true);
                }
            }
        }

        /// <summary>
        /// 提供データ価格情報取得
        /// </summary>
        /// <param name="partsInfoDataSet">部品検索データセット</param>
        /// <param name="goodsUnitDataList">商品連結データオブジェクトリスト</param>
        /// <param name="goodsUnitDataList">更新フラグ</param>
        /// <returns></returns>
        private void GetOfrPriceDataListProc(PartsInfoDataSet partsInfoDataSet, List<GoodsUnitData> goodsUnitDataList, bool isUpdate)
        {
            GoodsInfoKey goodsInfoKey;
            List<GoodsPrice> mkrSuggestRtPricUList = null;
            List<GoodsPrice> mkrSuggestRtPricList = null;

            if (partsInfoDataSet == null || goodsUnitDataList == null || goodsUnitDataList.Count <= 0)
            {
                // パラメータ不正のため終了
                return;
            }

            foreach(GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // 検索キー作成
                goodsInfoKey = new GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);

                // メーカー希望小売価格情報作成
                PartsInfoDataSet.UsrGoodsPriceRow[] usrGoodsPriceRows =
                    (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfoDataSet.UsrGoodsPrice.Select(
                        string.Format("GoodsMakerCd = '{0}' AND GoodsNo = '{1}'",
                        goodsUnitData.GoodsMakerCd,
                        goodsUnitData.GoodsNo));

                // 提供データ価格情報データテーブルから価格一覧を作成
                mkrSuggestRtPricUList = GetGoodsPriceList(usrGoodsPriceRows);

                // メーカー希望小売価格情報（ユーザー登録分）登録済みチェック
                if (this._mkrSuggestRtPricUList.ContainsKey(goodsInfoKey))
                {
                    // 登録済み
                    // 更新フラグがtrueの場合、旧データを削除し新データを追加する
                    // 更新フラグがfalseの場合、データ追加を行わない
                    if (isUpdate)
                    {
                        this._mkrSuggestRtPricUList.Remove(goodsInfoKey);
                        this._mkrSuggestRtPricUList.Add(goodsInfoKey, mkrSuggestRtPricUList);
                    }
                }
                else
                {
                    // 未登録
                    this._mkrSuggestRtPricUList.Add(goodsInfoKey, mkrSuggestRtPricUList);
                }

                // メーカー希望小売価格情報作成
                PartsInfoDataSet.UsrGoodsPriceRow[] ofrPriceRows =
                    (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfoDataSet.OfrPriceDataTable.Select(
                        string.Format("GoodsMakerCd = '{0}' AND GoodsNo = '{1}'",
                        goodsUnitData.GoodsMakerCd,
                        goodsUnitData.GoodsNo));

                // 提供データ価格情報データテーブルから価格一覧を作成
                mkrSuggestRtPricList = GetGoodsPriceList(ofrPriceRows);

                // メーカー希望小売価格情報登録済みチェック
                if (this._mkrSuggestRtPricList.ContainsKey(goodsInfoKey))
                {
                    // 登録済み
                    // 更新フラグがtrueの場合、旧データを削除し新データを追加する
                    // 更新フラグがfalseの場合、データ追加を行わない
                    if (isUpdate)
                    {
                        this._mkrSuggestRtPricList.Remove(goodsInfoKey);
                        this._mkrSuggestRtPricList.Add(goodsInfoKey, mkrSuggestRtPricList);
                    }
                }
                else
                {
                    // 未登録
                    this._mkrSuggestRtPricList.Add(goodsInfoKey, mkrSuggestRtPricList);
                }
            }
        }

        private List<GoodsPrice> GetGoodsPriceList(PartsInfoDataSet.UsrGoodsPriceRow[] priceRows)
        {
            List<GoodsPrice> retList = new List<GoodsPrice>();

            if (priceRows != null)
            {
                // メーカー希望小売価格情報作成
                for (int j = 0; j < priceRows.Length; j++)
                {
                    GoodsPrice prc = new GoodsPrice();
                    prc.CreateDateTime = new DateTime(priceRows[j].CreateDateTime);
                    prc.UpdateDateTime = new DateTime(priceRows[j].UpdateDateTime);
                    prc.EnterpriseCode = priceRows[j].EnterpriseCode;
                    if (priceRows[j].IsFileHeaderGuidNull() == false)
                        prc.FileHeaderGuid = priceRows[j].FileHeaderGuid;
                    prc.UpdAssemblyId1 = priceRows[j].UpdAssemblyId1;
                    prc.UpdAssemblyId2 = priceRows[j].UpdAssemblyId2;
                    prc.UpdEmployeeCode = priceRows[j].UpdEmployeeCode;
                    prc.LogicalDeleteCode = priceRows[j].LogicalDeleteCode;

                    prc.GoodsMakerCd = priceRows[j].GoodsMakerCd;
                    prc.GoodsNo = priceRows[j].GoodsNo;
                    prc.ListPrice = priceRows[j].ListPrice;
                    prc.OpenPriceDiv = priceRows[j].OpenPriceDiv;
                    prc.PriceStartDate = priceRows[j].PriceStartDate;
                    prc.SalesUnitCost = priceRows[j].SalesUnitCost;
                    prc.StockRate = priceRows[j].StockRate;
                    if (priceRows[j].IsUpdateDateNull() == false)
                    {
                        prc.UpdateDate = priceRows[j].UpdateDate;
                    }
                    else
                    {
                        prc.UpdateDate = DateTime.MinValue;
                    }
                    prc.OfferDate = priceRows[j].OfferDate;
                    retList.Add(prc);
                }
            }
            return retList;
        }
        // ADD 2015/03/18 豊沢 SCM高速化 メーカー希望小売価格対応 ---------------------<<<<<
    }

}