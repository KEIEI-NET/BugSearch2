//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/02/25  修正内容 : 拠点優先倉庫と得意先優先倉庫を全て設定しないと
//                                  自動回答できない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/17  修正内容 : 年式、カラー、トリムでの絞り込み追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/31  修正内容 : 回答区分について、過去の履歴も考慮してセットするように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優
// 作 成 日  2010/04/05  修正内容 : 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056　對馬 大輔
// 作 成 日  2010/04/21  修正内容 : 品番検索／ＢＬコード検索で代替区分の設定を可能とする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健
// 作 成 日  2011/01/11  修正内容 : 提供データ・商品に未登録の部品も売上伝票入力に展開されるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健
// 作 成 日  2011/02/09  修正内容 : ・部品検索時にも車輌検索するように修正
//                                 ・過去に回答済みの問合せ時、その時のフル型式固定番号で、
//                                   車両を再検索するように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024  佐々木 健
// 作 成 日  2011/02/14  修正内容 : ・取消明細を自動回答しないように変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/18  修正内容 : キャンセル仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/03/08  修正内容 : 車輌検索時の年式、カラー、トリムの絞り込みを修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : BLコード枝番追加等の対応
//                                 SFから指定された車輌情報がPMでヒットしない場合の処理変更(OKにする)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNSの劉立
// 作 成 日  2011/08/10  修正内容 : 自動回答対応、車両形式検索対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2011/09/16  修正内容 : Readmine#25190対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉立 For Redmine#25325
// 作 成 日  2011/09/20  修正内容 : PCCUOE／PM側　自動回答 複数車種がある場合の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/09/20  修正内容 : Readmine#24583対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/10/16  修正内容 : Redmine#26021 PCCUOE／PM側　発注の手動回答時に型式がクリアされるの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/10/17  修正内容 : Readmine#26022対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/01/04  修正内容 : SCM改良対応
//                                  1)純正情報設定対応
//                                  2)表示順位設定対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 30517 夏野 駿希
// 作 成 日  2012/01/16  修正内容 : SCM改良対応・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/02/12  修正内容 : SCM改良対応
//                                  BLPOS在庫確認でPCC品目設定マスタを有効にする
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/04/09  修正内容 : BL-Pダイレクト発注対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/04/17  修正内容 : 障害№166 発注時に在庫の確認を行うように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2012/04/19  修正内容 : RC-SCM速度改良の修正
//                                 （※検索結果が不正にならないようキャッシュクリアする）
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/04/25  修正内容 : 障害対応(システムテスト障害一覧No28)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20073 西 毅
// 作 成 日  2012/05/30  修正内容 : SCM改良対応・自動見積部品コード
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/12  修正内容 : 手動回答すると売伝に車輌情報が正常に展開されない障害の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/06/14  修正内容 : システムテスト障害 82,83 車両検索条件（車種コード）の編集
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/15  修正内容 : システムテスト障害 98 発注時の前回問合せデータの最新在庫情報取得方法の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/06/20  修正内容 : SCM障害№166、システム障害№98の戻し
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/06/21  修正内容 : システム障害№117 車両検索条件が無い場合、車両検索しない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2012/06/24  修正内容 : 2012/06/28配信分障害一覧No126
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/27  修正内容 : SCM障害№166の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/06/25  修正内容 : SCM障害№10281 自動回答対象の倉庫は委託倉庫、優先（自拠点）倉庫のみ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲 SCM障害№166
// 作 成 日  2012/07/03  修正内容 : PCC for NSの問合せ→発注の場合、在庫情報を更新する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/07/06  修正内容 : システム障害№53　同一商品の判断条件変更（SCM障害№10281対応時の不具合対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/07/30  修正内容 : 2012/08/07配信システムテスト障害№128対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/08/15  修正内容 : 2012/08/23配信システムテスト障害№2対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲　30745
// 作 成 日  2012/08/30  修正内容 : 2012/10月配信予定SCM障害№10345対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/09/28  修正内容 : 2012/11/14配信分 SCM障害№10375 ログ「オプジェクト参照が不正です」
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341,10364,10431対応 PCCforNS、BLPの自動回答判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/22  修正内容 : 2012/12/12配信予定システムテスト障害№66対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2013/01/18  修正内容 : 2013/03/13配信 SCM障害№10475対応 自動回答が遅い
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/13  修正内容 : SCM障害追加②対応 2013/03/06配信
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/02/01  修正内容 : 2013/03/06配信予定 SCM障害№92　車両情報の装備情報を考慮した部品絞込みを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2013/02/22  修正内容 : 2013/02/06配信 SCM障害№10475対応 PCC自社設定マスタ取得のキャッシュ化の戻し
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/03/08  修正内容 : SCM障害№10490対応
//----------------------------------------------------------------------------//
// 管理番号 　　　　　　 作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/04/05  修正内容 : 2013/05/22配信 SCM障害№50 SPK対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 作 成 日  2013/07/16  修正内容 : SCM仕掛一覧 №10551
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 作 成 日  2013/08/02  修正内容 : 部品・問合せの場合もSCM仕掛一覧 №10551と同様の対応を行う
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/08/09  修正内容 : 2013/08/09配信システムテスト障害 №27、28対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/09/13  修正内容 : SCM仕掛一覧№10571対応　PCC自社設定マスタの参照倉庫を追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/05/08  修正内容 : 2013/06/18配信　SCM障害№10308,№10528
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/05/15  修正内容 : 2013/06/18配信　SCM障害№10410
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/06/06  修正内容 : 2013/06/18配信　システムテスト障害№29
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/10/03  修正内容 : SCM仕掛一覧№10578対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/01/30  修正内容 : Redmine#41771 障害№13対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/02/05  修正内容 : SCM仕掛一覧№10627対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/02/06  修正内容 : SCM仕掛一覧№10632対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/04/16  修正内容 : SCM自動回答速度改善 ｼｽﾃﾑﾃｽﾄ障害№74対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/05/30  修正内容 : 商品保証課Redmine#1581対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/06/06  修正内容 : 商品保証課Redmine#1581対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 修 正 日  2014/06/04  修正内容 : SCM仕掛一覧№10659対応
//----------------------------------------------------------------------------//
// 管理番号 11070184-00  作成担当 : 譚洪
// 作 成 日  2014/09/01  修正内容 : SFから問合せの車輌情報・備考を売上伝票入力に表示する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 修 正 日  2014/09/12  修正内容 : SCM仕掛一覧№10680対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応
//                                : 自動回答方式の追加
//                                : 貸出区分、メーカー希望小売価格、オープン価格区分の追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢 憲弘
// 修 正 日  2015/01/19  修正内容 : リコメンド対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上
// 作 成 日  2015/01/30  修正内容 : SCM高速化 生産年式、車台番号対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上
// 作 成 日  2015/03/03  修正内容 : SCM高速化Redmine#300対応 
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上
// 作 成 日  2015/03/03  修正内容 : SCM高速化Redmine#310対応 
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上
// 作 成 日  2015/03/18  修正内容 : SCM高速化 メーカー希望小売価格対応 
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上
// 作 成 日  2015/07/21  修正内容 : 商品保証課Redmine#4334対応 品番検索での車両検索時、複数車種の場合に単一選択するように修正 
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢 憲弘
// 作 成 日  2015/07/29  修正内容 : 商品保証課Redmine#4382対応 過去の回答データ検索時の条件を修正
//----------------------------------------------------------------------------//
// 管理番号  11170206-00 作成担当 : 顧棟
// 作 成 日  2016/01/13  修正内容 : Redmine#48055 2016年2月配信分
//                                : TBO対応 SFからTBOを含む品目を問合せした場合、TBO品目のBLコード検索異常が発生した為、
//                                : 他の品目も含めて全て手動回答となってしまう
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
// 管理番号  11470103-00 作成担当 : 陳艶丹
// 修 正 日  2018/07/06  修正内容 : SF側セット子品番の在庫情報の障害対応
//----------------------------------------------------------------------------//
// 管理番号  11470103-00 作成担当 : 陳艶丹
// 修 正 日  2018/07/26  修正内容 : SF側セット子品番発注時の障害対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 田建委
// 修 正 日  2020/05/15  修正内容 : PMKOBETSU-3932 BLP障害（ログ強化）
//                                : 既存コードのログ出力強化を行う
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 陳艶丹
// 修 正 日  2020/09/22  修正内容 : PMKOBETSU-4074 問合せ内容の情報が消えるの障害対応
//----------------------------------------------------------------------------//
// 管理番号  12000031-00 作成担当 : 陳艶丹
// 作 成 日  2024/04/23  修正内容 : PMKOBETSU-4350 BLP不具合対応
//                                : 得意先設定と異なる倉庫コードが回答される
//----------------------------------------------------------------------------//
// 管理番号  12000031-00 作成担当 : 陳艶丹
// 作 成 日  2024/07/03  修正内容 : BLP障害対応（例外発生箇所修正対応）
//----------------------------------------------------------------------------//

#define _LOCAL_DEBUG_   // ローカルの仮環境でデバッグ用のフラグ

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
// 2011/02/09 Add >>>
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
// 2011/02/09 Add <<<
// ----- ADD 2011/08/10 ----- >>>>>
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
// ----- ADD 2011/08/10 ----- <<<<<

namespace Broadleaf.Application.Controller
{
    using SCMOrderHeaderRecordType = ISCMOrderHeaderRecord;    // SCM受注データ
    using SCMOrderCarRecordType = ISCMOrderCarRecord;       // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType = ISCMOrderAnswerRecord;    // SCM受注明細データ(回答)

    // --- ADD 2011/08/10 ----->>>>>
    using SCMWebServer = SingletonInstance<SCMWebAcsAgent>;         // SCMWebアクセス
    // --- ADD 2011/08/10 -----<<<<<

    using SCMDataTreeType = Tuple<
        UserSCMOrderHeaderRecord,
        UserSCMOrderCarRecord,
        List<ISCMOrderDetailRecord>,
        List<ISCMOrderAnswerRecord>,
        NullObject,
        NullObject,
        NullObject,
        NullObject,
        NullObject,
        NullObject
    >;

    using GoodsAcsServer = SingletonInstance<GoodsAcsAgent>;     // 初期化済み商品検索クラス
    using SalesTtlStServer = SingletonInstance<SalesTtlStAgent>;   // 売上全体設定マスタ
    using SecInfoSetServer = SingletonInstance<SecInfoSetAgent>;   // 拠点設定マスタ
    using CustomerServer = SingletonInstance<CustomerAgent>;     // 得意先マスタ
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
    using SalesDetailServer = SingletonInstance<SalesDetailAgent>;  // 売上明細データ
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

    // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM全体設定マスタ
    // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

    /// <summary>
    /// SCM検索処理クラス
    /// </summary>
    public abstract class SCMSearcher
    {
        #region <ログ用定数>

        /// <summary>クラス名称</summary>
        private const string MY_NAME = "SCMSearcher";
        private const string LinkBreak = "\r\n";  //改行

        #endregion // </ログ用定数>

        // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
        #region <PCC優先倉庫情報>
        /// <summary>PCC優先倉庫リストマップ</summary>
        private static IDictionary<string, List<string>> _sectWarehouseCdListMap = new Dictionary<string, List<string>>();
        /// <summary>PCC優先倉庫リストマップを取得します。</summary>
        /// <remarks>キー：SCM受注データのキー</remarks>
        public static IDictionary<string, List<string>> SectWarehouseCdListMap
        {
            get
            {
                return _sectWarehouseCdListMap;
            }
            set
            {
                _sectWarehouseCdListMap = value;
            }
        }
        #endregion // <PCC優先倉庫情報>
        // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

        // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 ----->>>>>
        private ITbsPartsCodeDB _iBLGoodsCdDB;

        #region <BLコードと装備分類情報>
        //KEY：BLコード　VALUE：装備分類
        private Dictionary<int, int> _blCodeDic = new Dictionary<int, int>();
        /// <summary>
        /// BLコードと装備分類情報のDictionaryを作成
        /// </summary>
        /// <returns>BLコードと装備分類情報のDictionary</returns>
        /// <remarks></remarks>
        public Dictionary<int, int> BLCodeDic
        {
            get
            {
                return _blCodeDic;
            }
            set
            {
                _blCodeDic = value;
            }
        }
        #endregion
        // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 -----<<<<<

        #region <SCM受注データ>

        #region <ヘッダ>

        /// <summary>SCM受注データのレコードリスト</summary>
        private readonly IList<SCMOrderHeaderRecordType> _headerRecordList;
        /// <summary>SCM受注データのレコードリストを取得します。</summary>
        public IList<SCMOrderHeaderRecordType> HeaderRecordList { get { return _headerRecordList; } }

        /// <summary>SCM受注データの関連マップ</summary>
        private IDictionary<string, ISCMOrderHeaderRecord> _relationalHeaderMap;
        /// <summary>SCM受注データの関連マップを取得します。</summary>
        public IDictionary<string, ISCMOrderHeaderRecord> RelationalHeaderMap
        {
            get
            {
                if (_relationalHeaderMap == null)
                {
                    _relationalHeaderMap = CreateRelationalHeaderMap(HeaderRecordList);
                }
                return _relationalHeaderMap;
            }
        }

        /// <summary>
        /// SCM受注データの関連マップを生成します。
        /// </summary>
        /// <param name="headerRecordList">SCM受注データのレコードリスト</param>
        /// <returns>SCM受注データのレコードマップ</returns>
        protected static IDictionary<string, ISCMOrderHeaderRecord> CreateRelationalHeaderMap(
            IList<ISCMOrderHeaderRecord> headerRecordList
        )
        {
            IDictionary<string, ISCMOrderHeaderRecord> headerMap = new Dictionary<string, ISCMOrderHeaderRecord>();
            {
                foreach (ISCMOrderHeaderRecord headerRecord in headerRecordList)
                {
                    if (headerMap.ContainsKey(headerRecord.ToRelationKey())) continue;
                    headerMap.Add(headerRecord.ToRelationKey(), headerRecord);
                }
            }
            return headerMap;
        }

        /// <summary>
        /// SCM受注データのレコードを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>該当するSCM受注データのレコード</returns>
        protected ISCMOrderHeaderRecord GetHeaderRecord(ISCMOrderDetailRecord detailRecord)
        {
            if (RelationalHeaderMap.ContainsKey(detailRecord.ToRelationKey()))
            {
                ISCMOrderHeaderRecord headerRecord = RelationalHeaderMap[detailRecord.ToRelationKey()];
                return headerRecord;
            }
            else
            {
                Debug.Assert(false, string.Format("明細のヘッダが存在しません。：{0}", detailRecord.ToRelationKey()));
                return null;
            }
        }

        /// <summary>
        /// 得意先コードを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>該当するSCM受注データの得意先コード</returns>
        public int GetCustomerCode(ISCMOrderDetailRecord detailRecord)
        {
            if (RelationalHeaderMap.ContainsKey(detailRecord.ToRelationKey()))
            {
                ISCMOrderHeaderRecord headerRecord = RelationalHeaderMap[detailRecord.ToRelationKey()];
                return headerRecord.CustomerCode;
            }
            else
            {
                Debug.Assert(false, string.Format("明細のヘッダが存在しません。：{0}", detailRecord.ToRelationKey()));
                return 0;
            }
        }

        /// <summary>
        /// 問合せ日を取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>該当するSCM受注データの問合せ日</returns>
        public DateTime GetInquiryDate(ISCMOrderDetailRecord detailRecord)
        {
            if (RelationalHeaderMap.ContainsKey(detailRecord.ToRelationKey()))
            {
                ISCMOrderHeaderRecord headerRecord = RelationalHeaderMap[detailRecord.ToRelationKey()];
                return headerRecord.InquiryDate;
            }
            else
            {
                Debug.Assert(false, string.Format("明細のヘッダが存在しません。：{0}", detailRecord.ToRelationKey()));
                return DateTime.Now;
            }
        }

        #endregion // </ヘッダ>

        #region <車両情報>

        /// <summary>SCM受注データ(車両情報)のレコードリスト</summary>
        private readonly IList<SCMOrderCarRecordType> _carRecordList;
        /// <summary>SCM受注データ(車両情報)のレコードリストを取得します。</summary>
        public IList<SCMOrderCarRecordType> CarRecordList { get { return _carRecordList; } }

        /// <summary>SCM受注データ(車両情報)のレコードマップ</summary>
        private readonly IDictionary<string, SCMOrderCarRecordType> _carRecordMap = new Dictionary<string, SCMOrderCarRecordType>();
        /// <summary>SCM受注データ(車両情報)のレコードマップを取得します。</summary>
        /// <remarks>キー：SCM受注データ(車両情報)のキー</remarks>
        public IDictionary<string, SCMOrderCarRecordType> CarRecordMap { get { return _carRecordMap; } }

        /// <summary>
        /// 型式(フル型)を取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>該当するSCM受注データ(車両情報)の型式(フル型)</returns>
        public string GetFullModel(ISCMOrderDetailRecord detailRecord)
        {
            if (CarRecordMap.ContainsKey(detailRecord.ToCarKey()))
            {
                ISCMOrderCarRecord headerRecord = CarRecordMap[detailRecord.ToCarKey()];
                return headerRecord.FullModel;
            }
            else
            {
                Debug.Assert(false, string.Format("明細の車両情報が存在しません。：{0}", detailRecord.ToCarKey()));
                return string.Empty;
            }
        }

        #endregion // </車両情報>

        #region <明細>

        /// <summary>SCM受注明細データ(問合せ・発注)のレコードリスト</summary>
        private readonly IList<SCMOrderDetailRecordType> _detailRecordList;
        /// <summary>SCM受注明細データ(問合せ・発注)のレコードリストを取得します。</summary>
        public IList<SCMOrderDetailRecordType> DetailRecordList { get { return _detailRecordList; } }

        #endregion // </明細>

        // 2010/03/31 Add >>>
        #region <回答(元)>

        /// <summary>SCM受注明細データ(回答)のレコードリスト</summary>
        private readonly IList<SCMOrderAnswerRecordType> _orgAnswerRecordList;
        /// <summary>SCM受注明細データ(回答)のレコードリストを取得します。</summary>
        public IList<SCMOrderAnswerRecordType> OrgAnswerRecordList { get { return _orgAnswerRecordList; } }

        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        /// <summary>
        /// 前回の回答データから見積で回答済みであるデータを検索します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>前回の回答データからの見積で回答済みであるデータ</returns>
        /// <remarks>
        /// <br>Update Note : 2018/07/26 陳艶丹</br>
        /// <br>管理番号    : 11470103-00</br>
        /// <br>            : SF側セット子品番発注時の障害対応</br>
        /// <br>Update Note : 2020/09/22 陳艶丹</br>
        /// <br>管理番号    : 11600006-00</br>
        /// <br>            : PMKOBETSU-4074 問合せ内容の情報が消えるの障害対応</br>
        /// </remarks>
        private List<ISCMOrderAnswerRecord> FindAnsweredRecordByEstimate(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            List<ISCMOrderAnswerRecord> orgAnswerList = (List<ISCMOrderAnswerRecord>)OrgAnswerRecordList;

            string detailKey = SCMEntityUtil.GetAnsweredRelationKey(scmOrderDetailRecord);
            Debug.WriteLine(detailKey);
            // DEL 2011/08/10 gaofeng >>>
            //List<ISCMOrderAnswerRecord> foundRecordList = orgAnswerList.FindAll(delegate(ISCMOrderAnswerRecord answerRecord)
            //    {
            //        if (!answerRecord.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Estimate)) return false;

            //        string answerKey = SCMEntityUtil.GetAnsweredRelationKey(answerRecord);
            //        Debug.WriteLine(answerKey);
            //        if (answerKey.Equals(detailKey))
            //        {
            //            return true;
            //        }
            //        return false;
            //    });
            // DEL 2011/08/10 gaofeng <<<
            // ADD 2011/08/10 gaofeng >>>
            List<ISCMOrderAnswerRecord> foundRecordList = new List<ISCMOrderAnswerRecord>();

            //>>>2012/04/25
            // 同一問合せ行番号のレコードのみ対象
            List<ISCMOrderAnswerRecord> targetList = orgAnswerList.FindAll(delegate(ISCMOrderAnswerRecord answerRecord)
                {
                    // --- UPD 2014/09/12 T.Miyamoto SCM仕掛一覧 №10680 ------------------------------>>>>>
                    //if (answerRecord.InqRowNumber == scmOrderDetailRecord.InqRowNumber)
                    // --- UPD 2018/07/26 陳艶丹  SF側セット子品番発注時の障害対応-------------------->>>>>
                    //if ((answerRecord.InqRowNumber == scmOrderDetailRecord.InqRowNumber) &&
                    if (((answerRecord.InqRowNumber == scmOrderDetailRecord.InqRowNumber) &&
                    // --- UPD 2018/07/26 陳艶丹  SF側セット子品番発注時の障害対応--------------------<<<<<
                        (answerRecord.GoodsMakerCd == scmOrderDetailRecord.GoodsMakerCd) &&
                        (answerRecord.GoodsNo == scmOrderDetailRecord.GoodsNo)) 
                    // --- UPD 2014/09/12 T.Miyamoto SCM仕掛一覧 №10680 ------------------------------<<<<
                        // --- ADD 2018/07/26 陳艶丹  SF側セット子品番発注時の障害対応-------------------->>>>>
                        || ((answerRecord.GoodsMakerCd == scmOrderDetailRecord.SetPartsMkrCd) &&
                        // --- UPD 2020/09/22 陳艶丹  PMKOBETSU-4074の対応-------------------->>>>>
                        //(answerRecord.GoodsNo == scmOrderDetailRecord.SetPartsNumber)))
                         (answerRecord.GoodsNo == scmOrderDetailRecord.SetPartsNumber) &&
                         scmOrderDetailRecord.SetPartsNumber != string.Empty &&
                         scmOrderDetailRecord.SetPartsMkrCd != 0))
                        // --- UPD 2020/09/22 陳艶丹  PMKOBETSU-4074の対応--------------------<<<<<
                        // --- ADD 2018/07/26 陳艶丹  SF側セット子品番発注時の障害対応--------------------<<<<<
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            //<<<2012/04/25
            
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            #region 削除(SCM改良の為)

            //// PCCUOEの発注の場合
            ////>>>2012/04/09 // BLP発注で回答明細が存在するときのみ、回答明細から商品情報構築
            ////if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE && scmOrderDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Order)
            //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE && 
            //    scmOrderDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Order &&
            //    //>>>2012/04/24
            //    //orgAnswerList != null && orgAnswerList.Count != 0)
            //    targetList != null && targetList.Count != 0)
            //    //<<<2012/04/24
            ////<<<2012/04/09
            //{                
            //    #region 商品情報を構築

            //    UserSCMOrderAnswerRecord goodsUnitData = SetAnswerRecordFormDetail(scmOrderDetailRecord);

            //    foundRecordList.Add(goodsUnitData);

            //    #endregion // 商品情報を構築

            //}
            //// SCMの場合、既存のまま
            //else
            //{
            #endregion
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            // ADD 2012/11/22 2012/12/12配信予定システムテスト障害№66対応 （上記削除分の戻し）--------->>>>>
            // --- UPD 2013/08/09 Y.Wakita ---------->>>>>
            ////>>>2012/04/09 // BLP発注で回答明細が存在するときのみ、回答明細から商品情報構築
            ////if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE && scmOrderDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Order)
            //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE && 
            //    scmOrderDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Order &&
            //    //>>>2012/04/24
            //    //orgAnswerList != null && orgAnswerList.Count != 0)
            //    targetList != null && targetList.Count != 0)
            //    //<<<2012/04/24
            ////<<<2012/04/09

            // PCCUOEの発注、SCMの発注を同じにする
            if (scmOrderDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Order &&
                targetList != null && targetList.Count != 0)
            // --- UPD 2013/08/09 Y.Wakita ----------<<<<<
            {                
                #region 商品情報を構築

                UserSCMOrderAnswerRecord goodsUnitData = SetAnswerRecordFormDetail(scmOrderDetailRecord);

                foundRecordList.Add(goodsUnitData);

                #endregion // 商品情報を構築

            }
            // --- DEL 2013/08/09 Y.Wakita ---------->>>>>
            //// SCMの場合、既存のまま
            //else
            //{
            //// ADD 2012/11/22 2012/12/12配信予定システムテスト障害№66対応 -----------------------------<<<<<
            //    foundRecordList = orgAnswerList.FindAll(delegate(ISCMOrderAnswerRecord answerRecord)
            //    {
            //        if (!answerRecord.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Estimate)) return false;

            //        string answerKey = SCMEntityUtil.GetAnsweredRelationKey(answerRecord);
            //        Debug.WriteLine(answerKey);
            //        if (answerKey.Equals(detailKey))
            //        {
            //            return true;
            //        }
            //        return false;
            //    });
            //// DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            ////}
            //// DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            //// ADD 2012/11/22 2012/12/12配信予定システムテスト障害№66対応 （上記削除分の戻し）--------->>>>>
            //}
            //// ADD 2012/11/22 2012/12/12配信予定システムテスト障害№66対応 -----------------------------<<<<<
            // --- DEL 2013/08/09 Y.Wakita ----------<<<<<
            return foundRecordList;
        }
        // ADD 2011/08/10 gaofeng <<<
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<


        // 2011/01/11 Add >>>
        /// <summary>
        /// キャンセルの場合に、前回の回答データを検索します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>前回の回答データからの見積で回答済みであるデータ</returns>
        private List<ISCMOrderAnswerRecord> FindAnsweredRecordByBeforeAnswer(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            List<ISCMOrderAnswerRecord> foundRecordList = null;
            if (!string.IsNullOrEmpty(scmOrderDetailRecord.SalesSlipNum.Trim()) && scmOrderDetailRecord.AcptAnOdrStatus != 0)
            {
                List<ISCMOrderAnswerRecord> orgAnswerList = (List<ISCMOrderAnswerRecord>)OrgAnswerRecordList;
                string detailKey = SCMEntityUtil.GetAnsweredRelationKey(scmOrderDetailRecord);
                Debug.WriteLine(detailKey);
                foundRecordList = orgAnswerList.FindAll(delegate(ISCMOrderAnswerRecord answerRecord)
                {
                    if (answerRecord.AcptAnOdrStatus.Equals(scmOrderDetailRecord.AcptAnOdrStatus) &&
                        answerRecord.SalesSlipNum.Trim().Equals(scmOrderDetailRecord.SalesSlipNum.Trim()) &&
                        answerRecord.SalesRowNo.Equals(scmOrderDetailRecord.SalesRowNo))
                    {
                        string answerKey = SCMEntityUtil.GetAnsweredRelationKey(answerRecord);
                        Debug.WriteLine(answerKey);
                        if (answerKey.Equals(detailKey))
                        {
                            return true;
                        }
                    }
                    return false;
                });
            }
            return foundRecordList;
        }
        // 2011/01/11 Add <<<
        #endregion // </明細>

        #region <問合せ(元)>

        /// <summary>SCM受注明細データ(問合せ・発注)のレコードリスト</summary>
        private readonly IList<SCMOrderDetailRecordType> _orgDetailRecordList;
        /// <summary>SCM受注明細データ(問合せ・発注)のレコードリストを取得します。</summary>
        public IList<SCMOrderDetailRecordType> OrgDetailRecordList { get { return _orgDetailRecordList; } }

        /// <summary>
        /// ヘッダデータに対する元データのリストを取得します。
        /// </summary>
        /// <param name="header"></param>
        /// <param name="detailList"></param>
        /// <param name="answerList"></param>
        public void GetOriginalDataList(ISCMOrderHeaderRecord header, out List<SCMOrderDetailRecordType> detailList, out List<SCMOrderAnswerRecordType> answerList)
        {
            detailList = null;
            answerList = null;
            if (header == null) return;

            detailList = ( (List<SCMOrderDetailRecordType>)OrgDetailRecordList ).FindAll(
                delegate(SCMOrderDetailRecordType target)
                {
                    if (header.InqOriginalEpCd.Trim().Equals(target.InqOriginalEpCd.Trim()) &&
                        header.InqOriginalSecCd.Trim().Equals(target.InqOriginalSecCd.Trim()) &&
                        header.InqOtherEpCd.Trim().Equals(target.InqOtherEpCd.Trim()) &&
                        header.InquiryNumber.Equals(target.InquiryNumber) &&
                        header.InqOrdDivCd.Equals(target.InqOrdDivCd))
                    {
                        return true;
                    }
                    return false;
                });

            answerList = ( (List<SCMOrderAnswerRecordType>)OrgAnswerRecordList ).FindAll(
                delegate(SCMOrderAnswerRecordType target)
                {
                    if (header.InqOriginalEpCd.Trim().Equals(target.InqOriginalEpCd.Trim()) &&
                        header.InqOriginalSecCd.Trim().Equals(target.InqOriginalSecCd.Trim()) &&
                        header.InqOtherEpCd.Trim().Equals(target.InqOtherEpCd.Trim()) &&
                        header.InquiryNumber.Equals(target.InquiryNumber) &&
                        header.InqOrdDivCd.Equals(target.InqOrdDivCd))
                    {
                        return true;
                    }
                    return false;
                });
        }
        #endregion
        // 2010/03/31 Add <<<

        #region <データツリー>

        /// <summary>SCM受注データツリーのマップ</summary>
        private IDictionary<string, SCMDataTreeType> _scmDataTreeMap;
        /// <summary>SCM受注データツリーのマップを取得します。</summary>
        /// <remarks>キー：関連キー</remarks>
        public IDictionary<string, SCMDataTreeType> ScmDataTreeMap
        {
            get
            {
                if (_scmDataTreeMap == null)
                {
                    _scmDataTreeMap = CreateSCMDataTreeMap();
                }
                return _scmDataTreeMap;
            }
        }

        /// <summary>
        /// SCM受注データツリーマップを生成します。
        /// </summary>
        /// <returns>SCM受注データツリーマップ</returns>
        protected IDictionary<string, SCMDataTreeType> CreateSCMDataTreeMap()
        {
            IDictionary<string, SCMDataTreeType> scmDataTreeMap = new Dictionary<string, SCMDataTreeType>();
            {
                foreach (ISCMOrderDetailRecord detailRecord in DetailRecordList)
                {
                    string key = detailRecord.ToRelationKey();
                    if (!scmDataTreeMap.ContainsKey(key))
                    {
                        scmDataTreeMap.Add(key, new SCMDataTreeType());
                    }
                    // SCM受注データ
                    if (RelationalHeaderMap.ContainsKey(key))
                    {
                        scmDataTreeMap[key].Member01 = RelationalHeaderMap[key] as UserSCMOrderHeaderRecord;
                    }
                    // SCM受注データ(車両情報)
                    string carKey = detailRecord.ToCarKey();
                    if (CarRecordMap.ContainsKey(carKey))
                    {
                        scmDataTreeMap[key].Member02 = CarRecordMap[carKey] as UserSCMOrderCarRecord;
                    }
                    // SCM受注明細データ(問合せ・発注)
                    scmDataTreeMap[key].Member03.Add(detailRecord);
                }
            }
            return scmDataTreeMap;
        }

        #endregion // </データツリー>

        #endregion // </SCM受注データ>

        #region <検索用アクセサ>

        /// <summary>品番検索アクセサ</summary>
        private GoodsAcs _goodsAccesser;
        /// <summary>品番検索アクセサを取得します。</summary>
        protected GoodsAcs GoodsAccesser
        {
            get
            {
                if (_goodsAccesser == null)
                {
                    _goodsAccesser = new GoodsAcs(HeaderRecordList[0].InqOtherSecCd);
                }
                return _goodsAccesser;
            }
            set { _goodsAccesser = value; }
        }

        /// <summary>車両検索アクセサ</summary>
        private CarSearchController _carAccesser;
        /// <summary>車両検索アクセサを取得します。</summary>
        protected CarSearchController CarAccesser
        {
            get
            {
                if (_carAccesser == null)
                {
                    _carAccesser = new CarSearchController();
                }
                return _carAccesser;
            }
        }

        #endregion // </検索用アクセサ>

        #region <検索結果>

        /// <summary>検索結果マップ</summary>
        private readonly IDictionary<string, SCMSearchedResult> _resultMap = new Dictionary<string, SCMSearchedResult>();
        /// <summary>検索結果マップを取得します。</summary>
        /// <remarks>キー：SCM受注明細データ(問合せ・発注)のキー</remarks>
        public IDictionary<string, SCMSearchedResult> ResultMap { get { return _resultMap; } }

        // ----- 2011/08/10 ----- >>>>>
        /// <summary>セット部品の結果マップ</summary>
        private readonly IDictionary<string, PartsInfoDataSet> _setResultMap = new Dictionary<string, PartsInfoDataSet>();
        /// <summary>検索結果マップを取得します。</summary>
        /// <remarks>キー：SCM受注明細データ(問合せ・発注)のキー</remarks>
        public IDictionary<string, PartsInfoDataSet> SetResultMap { get { return _setResultMap; } }
        // ----- 2011/08/10 ----- <<<<<

        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        #region 売上明細データ

        /// <summary>
        /// 売上明細データ
        /// </summary>
        private static SalesDetailAgent SalesDetailDB
        {
            get { return SalesDetailServer.Singleton.Instance; }
        }

        #endregion // 売上明細データ

        /// <summary>
        /// 回答済み検索結果を追加します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="answeredRecordList">回答済みSCM受注明細データ(回答)のリスト</param>
        /// <param name="searchedCarInfo">車両検索結果</param>
        private int AddAnsweredResult(
            SCMOrderDetailRecordType scmOrderDetailRecord,
            List<ISCMOrderAnswerRecord> answeredRecordList
            // 2011/02/09 Add >>>
            , PMKEN01010E searchedCarInfo
            // 2011/02/09 Add <<<
        )
        {
            #region Guard Phrase

            if (ListUtil.IsNullOrEmpty(answeredRecordList)) return (int)ResultUtil.ResultCode.Normal;

            #endregion // Guard Phrase

            List<GoodsUnitData> answeredGoodsUnitDataList = new List<GoodsUnitData>();
            {
                // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ---------->>>>>
                // ADD 2012/06/15 ----------------------------------------------->>>>>
                // 現在庫を取得するため商品検索を行う
                // 1パラ目：検索条件
                //GoodsCndtn searchingCondition = EditSearchingGoodsCondition(
                //    CreateSearchingGoodsCondition(scmOrderDetailRecord)
                //);

                //// 2パラ目：部品情報
                //PartsInfoDataSet partsInfoDB = null;

                //// 3パラ目：商品連結データ
                //List<GoodsUnitData> goodsUnitDataList = null;

                //// 4パラ目：メッセージ
                //string msg = string.Empty;

                //EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "品番検索 開始");
                //// 品番検索
                //int status = SearchPartsFromGoodsNo(
                //    searchingCondition,
                //    out partsInfoDB,
                //    out goodsUnitDataList,
                //    out msg
                //);
                //EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "品番検索 終了");
                // ADD 2012/06/15 -----------------------------------------------<<<<<
                // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ---------->>>>>

                // ADD 2012/06/27 SCM障害№166 在庫情報取得----------------------------------->>>>>
                // 現在庫を取得するため商品検索を行う
                // 1パラ目：検索条件
                GoodsCndtn searchingCondition = EditSearchingGoodsCondition(
                    CreateSearchingGoodsCondition(scmOrderDetailRecord)
                );

                // 2パラ目：部品情報
                PartsInfoDataSet partsInfoDB = null;

                // 3パラ目：商品連結データ
                List<GoodsUnitData> goodsUnitDataList = null;

                // 4パラ目：メッセージ
                string msg = string.Empty;
                // ADD 2013/03/08 SCM障害№10490対応 ----------------------------------------->>>>>
                // 品番を含んでいる時のみ商品検索を行う（該当無し品番は見積回答の内容のままとする）
                if (ExistsGoodsNo(scmOrderDetailRecord))
                {
                // ADD 2013/03/08 SCM障害№10490対応 -----------------------------------------<<<<<
                    EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "品番検索 開始");
                    // 品番検索
                    int status = SearchPartsFromGoodsNo(
                        searchingCondition,
                        out partsInfoDB,
                        out goodsUnitDataList,
                        out msg
                    );
                    EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "品番検索 終了");
                // ADD 2013/03/08 SCM障害№10490対応 ----------------------------------------->>>>>
                }
                // ADD 2013/03/08 SCM障害№10490対応 -----------------------------------------<<<<<
                // ADD 2012/06/27 SCM障害№166 在庫情報取得-----------------------------------<<<<<

                foreach (ISCMOrderAnswerRecord answeredRecord in answeredRecordList)
                {
                    // 見積伝票データを検索
                    // 2011/02/09 >>>
                    //SalesDetailWork[] foundSalesDetails = SalesDetailDB.FindSalesDetails(
                    //    answeredRecord.InqOtherEpCd,
                    //    answeredRecord.InqOtherSecCd,
                    //    answeredRecord.AcptAnOdrStatus,
                    //    answeredRecord.SalesSlipNum,
                    //    answeredRecord.SalesRowNo
                    //);

                    SalesDetailWork[] foundSalesDetails = null;
                    AcceptOdrCarWork[] foundAcceptOdrCars;
                    if (answeredRecord.InqOtherEpCd != string.Empty
                        && answeredRecord.InqOtherSecCd != string.Empty
                        && answeredRecord.AcptAnOdrStatus != 0
                        && answeredRecord.SalesSlipNum != string.Empty
                        && answeredRecord.SalesRowNo != 0) // ADD 2011/08/10
                    { // ADD 2011/08/10
                        SalesDetailDB.FindSalesDetailInfo(
                            answeredRecord.InqOtherEpCd,
                            answeredRecord.InqOtherSecCd,
                            answeredRecord.AcptAnOdrStatus,
                            answeredRecord.SalesSlipNum,
                            answeredRecord.SalesRowNo,
                            out foundSalesDetails,
                            out foundAcceptOdrCars
                        );
                    } // ADD 2011/08/10
                    // 2011/02/09 <<<

                    // 回答済み検索結果リストを構築
                    // UPD 2012/07/03 SCM障害№166 在庫情報取得 T.Yoshioka ----------------------------------->>>>>
                    AnsweredGoodsUnitData wAnsGoods = AnsweredSCMSearchedResult.CreateAnsweredGoodsUnitData(answeredRecord, foundSalesDetails);
                    foreach (WarehouseInfo wh in warehouseInfoList)
                    {
                        // UPD 2012/07/06 T.Yoshioka 障害№53 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        if (wh.GoodsNo == wAnsGoods.GoodsNo && wh.MakerCd == wAnsGoods.GoodsMakerCd)
                        // if (wh.GoodsNo == wAnsGoods.GoodsNo)
                        // UPD 2012/07/06 T.Yoshioka 障害№53 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        {
                            wAnsGoods.SelectedWarehouseCode = wh.Selected;
                            wAnsGoods.StockList = wh.StockList;
                            // UPD 2012/07/06 T.Yoshioka 障害№53 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            break;
                            // UPD 2012/07/06 T.Yoshioka 障害№53 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }
                    answeredGoodsUnitDataList.Add(wAnsGoods);

                    //answeredGoodsUnitDataList.Add(
                    //    AnsweredSCMSearchedResult.CreateAnsweredGoodsUnitData(
                    //        answeredRecord,
                    //        foundSalesDetails
                    //    )
                    //);
                    // UPD 2012/07/03 SCM障害№166 在庫情報取得 T.Yoshioka -----------------------------------<<<<<

                    // 2012/08/30 UPD T.Yoshioka 2012/10月配信予定 SCM障害№10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // ADD 2013/03/08 SCM障害№10490対応 ----------------------------------------->>>>>
                    // 商品検索で該当データが存在する時のみ、在庫情報を設定する
                    if (goodsUnitDataList != null && goodsUnitDataList.Count != 0)
                    {
                    // ADD 2013/03/08 SCM障害№10490対応 -----------------------------------------<<<<<
                        // 回答納期設定の為、PCC for NS、BLP両方とも在庫情報等の情報を設定する
                        foreach (GoodsUnitData data in answeredGoodsUnitDataList)
                        {
                            // 取得した商品検索結果を検索し、現在庫情報を回答済み検索結果に設定する
                            foreach (GoodsUnitData dat in goodsUnitDataList)
                            {
                                if (data.GoodsMakerCd.Equals(dat.GoodsMakerCd) &&
                                    data.GoodsNo.Equals(dat.GoodsNo))
                                {
                                    // 在庫情報
                                    data.StockList = dat.StockList;
                                    break;
                                }
                            }
                            GoodsUnitData revisedGoodsUnitData = data.Clone();
                            EasyLogger.Write(MY_NAME, "AddAnsweredResult()", "商品連結データ不足情報設定 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                            GoodsAccesser.SettingGoodsUnitDataFromVariousMst(
                                ref revisedGoodsUnitData,
                                0
                            );
                            EasyLogger.Write(MY_NAME, "AddAnsweredResult()", "商品連結データ不足情報設定 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                            if (revisedGoodsUnitData != null) data.SupplierCd = revisedGoodsUnitData.SupplierCd;
                        }
                        #region 旧ソース
                        //// ----- ADD 2011/10/17 ----- >>>>>
                        //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                        //{
                        //    foreach (GoodsUnitData data in answeredGoodsUnitDataList)
                        //    {
                        //        // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ---------->>>>>
                        //        // ADD 2012/06/15 ----------------------------------------------------->>>>>
                        //        // 取得した商品検索結果を検索し、現在庫情報を回答済み検索結果に設定する
                        //        //foreach (GoodsUnitData dat in goodsUnitDataList)
                        //        //{
                        //        //    if (data.GoodsMakerCd.Equals(dat.GoodsMakerCd) &&
                        //        //        data.GoodsNo.Equals(dat.GoodsNo))
                        //        //    {
                        //        //        // 在庫情報
                        //        //        data.StockList = dat.StockList;
                        //        //        break;
                        //        //    }
                        //        //}
                        //        // ADD 2012/06/15 -----------------------------------------------------<<<<<
                        //        // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ----------<<<<<
                        //        // ADD 2012/06/27 SCM障害№166 在庫情報取得----------------------------------->>>>>
                        //        // 取得した商品検索結果を検索し、現在庫情報を回答済み検索結果に設定する
                        //        foreach (GoodsUnitData dat in goodsUnitDataList)
                        //        {
                        //            if (data.GoodsMakerCd.Equals(dat.GoodsMakerCd) &&
                        //                data.GoodsNo.Equals(dat.GoodsNo))
                        //            {
                        //                // 在庫情報
                        //                data.StockList = dat.StockList;
                        //                break;
                        //            }
                        //        }
                        //        // ADD 2012/06/27 SCM障害№166 在庫情報取得-----------------------------------<<<<<
                        //        GoodsUnitData revisedGoodsUnitData = data.Clone();
                        //        GoodsAccesser.SettingGoodsUnitDataFromVariousMst(
                        //            ref revisedGoodsUnitData,
                        //            0
                        //        );
                        //        if (revisedGoodsUnitData != null) data.SupplierCd = revisedGoodsUnitData.SupplierCd;
                        //    }
                        //}
                        //// ----- ADD 2011/10/17 ----- <<<<<
                        #endregion
                    // ADD 2013/03/08 SCM障害№10490対応 ----------------------------------------->>>>>
                    }
                    // ADD 2013/03/08 SCM障害№10490対応 -----------------------------------------<<<<<
                    // 2012/08/30 UPD T.Yoshioka 2012/10月配信予定 SCM障害№10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                }
            }
            // 検索結果マップに追加
            ResultMap.Add(
                scmOrderDetailRecord.ToKey(),
                new AnsweredSCMSearchedResult(
                    scmOrderDetailRecord,
                    answeredGoodsUnitDataList,
                    ExistsGoodsNo(scmOrderDetailRecord) ? SCMSearchedResult.GoodsSearchDivCd.GoodsNo : SCMSearchedResult.GoodsSearchDivCd.BLCode
                // 2011/02/09 Add >>>
                    , searchedCarInfo
                // 2011/02/09 Add <<<
                )
            );
            return (int)ResultUtil.ResultCode.Normal;
        }
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        /// <summary>離島価格設定リスト</summary>
        private List<IsolIslandPrcWork> _isolIslandList;
        /// <summary>離島価格設定リストを取得・設定します。</summary>
        public List<IsolIslandPrcWork> IsolIslandList 
        { 
            get { return _isolIslandList; }
            set { _isolIslandList = value; }
        }
        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        #endregion // </検索結果>

        #region <価格算出>

        /// <summary>価格算出器</summary>
        private SCMPriceCalculator _priceCalculator;
        /// <summary>価格算出器を取得します。</summary>
        public SCMPriceCalculator PriceCalculator
        {
            get
            {
                if (_priceCalculator == null)
                {
                    _priceCalculator = new SCMPriceCalculator(GoodsAccesser);
                }
                return _priceCalculator;
            }
        }

        #endregion // </価格算出>

        #region <売上全体設定マスタ>

        /// <summary>
        /// 売上全体設定マスタを取得します。
        /// </summary>
        protected static SalesTtlStAgent SalesTtlStDB
        {
            get { return SalesTtlStServer.Singleton.Instance; }
        }

        #endregion // </売上全体設定マスタ>

        #region <拠点設定マスタ>

        /// <summary>拠点設定マスタを取得します。</summary>
        private static SecInfoSetAgent SecInfoSetDB
        {
            get { return SecInfoSetServer.Singleton.Instance; }
        }

        #endregion // </拠点設定マスタ>

        #region <得意先マスタ>

        /// <summary>
        /// 得意先マスタ
        /// </summary>
        private static CustomerAgent CustomerDB
        {
            get { return CustomerServer.Singleton.Instance; }
        }

        /// <summary>
        /// 得意先情報を取得します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <returns>得意先情報</returns>
        private static CustomerInfo GetCustomerInfo(ISCMOrderHeaderRecord headerRecord)
        {
            if (!CustomerDB.CustomerInfoMap.ContainsKey(headerRecord.CustomerCode))
            {
                CustomerDB.TakeCustomerInfo(headerRecord);
            }
            return CustomerDB.CustomerInfoMap[headerRecord.CustomerCode];
        }

        #endregion // </得意先マスタ>

        // ADD 2012/06/25 T.Yoshioka №10281 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region 委託倉庫在庫、優先倉庫在庫
        /// <summary>
        /// 商品毎の委託倉庫在庫、優先倉庫在庫の情報
        /// </summary>
        public struct WarehouseInfo
        {
            // ADD 2012/07/06 T.Yoshioka 障害№53 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            /// <summary>
            /// メーカーコード
            /// </summary>
            public int MakerCd;
            // ADD 2012/07/06 T.Yoshioka 障害№53 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            /// <summary>
            /// 商品番号
            /// </summary>
            public string GoodsNo;
            /// <summary>
            /// 委託倉庫在庫
            /// </summary>
            public Stock Trust;
            /// <summary>
            /// 優先倉庫在庫リスト
            /// </summary>
            public List<Stock> Priority;

            /// <summary>
            /// 在庫リスト
            /// </summary>
            public List<Stock> StockList;

            /// <summary>
            /// 選択倉庫コード
            /// </summary>
            public string Selected;

            /// <summary>
            /// イニシャライズ
            /// </summary>
            public void Initialize()
            {
                // ADD 2012/07/06 T.Yoshioka 障害№53 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                MakerCd = 0;
                // ADD 2012/07/06 T.Yoshioka 障害№53 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                GoodsNo = string.Empty;
                Trust = null;
                Priority = new List<Stock>();
                StockList = new List<Stock>();
                Selected = string.Empty;
            }

            /// <summary>
            /// 委託倉庫が存在するか
            /// </summary>
            /// <returns></returns>
            public bool IsExistTrust()
            {
                return !(Trust == null);
            }

            /// <summary>
            /// 優先倉庫が存在するか
            /// </summary>
            /// <returns></returns>
            public bool IsExistPriority()
            {
                if (Priority == null)
                {
                    return false;
                }
                return Priority.Count > 0;
            }
        }
        #endregion

        /// <summary>
        /// 商品毎の委託倉庫在庫、優先倉庫在庫の情報リスト保管用
        /// </summary>
        public static List<WarehouseInfo> warehouseInfoList = new List<WarehouseInfo>();
        // ADD 2012/06/25 T.Yoshioka №10281 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<

        // DEL 2013/02/22 T.Yoshioka 2013/03/06配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // ADD 2013/01/18 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //public static object pccCmpnyStObj = null;
        // ADD 2013/01/18 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // DEL 2013/02/22 T.Yoshioka 2013/03/06配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
        /// <summary>
        /// 自動回答品目設定マスタ
        /// </summary>
        public static AutoAnsItemStAgent autoAnsItemStDB = new AutoAnsItemStAgent();
        // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<
        /// <summary>
        /// 検索処理を行います。
        /// </summary>
        /// <remarks>
        /// 全明細データの検索結果が得られなかった場合、エラーを返します。
        /// </remarks>
        /// <returns>結果コード</returns>
        public int Search()
        {
            int errorCount = 0;
            // ADD 2012/06/25 T.Yoshioka №10281 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            warehouseInfoList = new List<WarehouseInfo>();
            // ADD 2012/06/25 T.Yoshioka №10281 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/06/06 商品保証課Redmine#1581対応 --------------------------------->>>>>
            autoAnsItemStDB.Clear();
            // ADD 2014/06/06 商品保証課Redmine#1581対応 ---------------------------------<<<<<
            // UPD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
            //foreach (SCMOrderDetailRecordType detailRecord in DetailRecordList)
            //{
            //    // 検索処理
            //    int resultCode = Search(detailRecord);
            //    if (!resultCode.Equals((int)ResultUtil.ResultCode.Normal))
            //    {
            //        errorCount++;
            //    }
            //}
            foreach (ISCMOrderHeaderRecord HeaderRecord in HeaderRecordList)
            {
                List<ISCMOrderDetailRecord> detailRecordList = new List<ISCMOrderDetailRecord>();

                // 同一問合せのみ対象
                foreach (ISCMOrderDetailRecord rec in DetailRecordList)
                {
                    if (HeaderRecord.InqOriginalEpCd.Trim() == rec.InqOriginalEpCd.Trim() && //@@@@20230303
                        HeaderRecord.InqOriginalSecCd == rec.InqOriginalSecCd &&
                        HeaderRecord.InqOtherEpCd == rec.InqOtherEpCd &&
                        HeaderRecord.InqOtherSecCd == rec.InqOtherSecCd &&
                        HeaderRecord.InquiryNumber == rec.InquiryNumber)
                    {
                        detailRecordList.Add(rec);
                    }
                }
                // 検索処理
                int resultCode = Search(detailRecordList, out errorCount);
            }
            // UPD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

            return errorCount.Equals(DetailRecordList.Count)
                ? (int)ResultUtil.ResultCode.Abort
                : (int)ResultUtil.ResultCode.Normal;
        }

        /// <summary>現在のSCM受注データのレコード</summary>
        private ISCMOrderHeaderRecord _currentHeaderRecord;
        /// <summary>現在のSCM受注データのレコードを取得または設定します。</summary>
        /// <remarks>情報共有用</remarks>
        //[Obsolete("あまり良い設計ではないので、要検討")]
        protected ISCMOrderHeaderRecord CurrentHeaderRecord
        {
            get { return _currentHeaderRecord; }
            set { _currentHeaderRecord = value; }
        }

        /// <summary>
        /// 検索処理を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>結果コード</returns>
        public int Search(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            const string METHOD_NAME = "Search(SCMOrderDetailRecordType)";  // ログ用

            CurrentHeaderRecord = GetHeaderRecord(scmOrderDetailRecord);

            int resultCode = (int)ResultUtil.ResultCode.Normal;

            // 2011/02/14 >>>
            //if (!CanSearch(scmOrderDetailRecord))
            List<ISCMOrderAnswerRecord> answerList = ( OrgAnswerRecordList != null ) ? (List<ISCMOrderAnswerRecord>)OrgAnswerRecordList : null;
            if (!CanSearch(scmOrderDetailRecord, answerList))
            // 2011/02/14 <<<
            {
                #region <Log>

                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(
                    "SCM全体設定マスタのレコードが存在しない または SCM全体設定マスタ.自動回答区分が「0:しない」です。" + Environment.NewLine + SCMDataHelper.GetProfile(scmOrderDetailRecord)
                ));

                #endregion // </Log>

                return resultCode;
            }
            // 2011/02/09 Add >>>
            PMKEN01010E searchedCarInfo = null;
            string carKey = scmOrderDetailRecord.ToCarKey();
            if (!SearchedResultAndCarInfoMap.ContainsKey(carKey))
            {
                CarSearchResultReport searchedCarResult;
                PMKEN01010E oldCarInfo;
                this.GetOldCarInfo(CurrentHeaderRecord, out searchedCarResult, out oldCarInfo);
                if (( searchedCarResult != CarSearchResultReport.retError ) && ( searchedCarResult != CarSearchResultReport.retFailed ))
                {

                    SearchedResultAndCarInfoMap.Add(
                        carKey,
                        new KeyValuePair<CarSearchResultReport, PMKEN01010E>(searchedCarResult, oldCarInfo)
                        );

                    searchedCarInfo = oldCarInfo;
                }
                else
                {
                    EasyLogger.Write(MY_NAME, "Search", "過去のデータより、車輌検索情報を取得できませんでした");
                }
            }
            else
            {
                searchedCarInfo = SearchedResultAndCarInfoMap[carKey].Value;
            }
            // 2011/02/09 Add <<<

            // 初期化済み商品検索クラスを取得
            EasyLogger.Write(MY_NAME, METHOD_NAME, "初期化済み商品検索クラスを取得 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            GoodsAccesser = GoodsAcsServer.Singleton.Instance.GetGoodsAccesser(scmOrderDetailRecord);
            EasyLogger.Write(MY_NAME, METHOD_NAME, "初期化済み商品検索クラスを取得 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）

            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
            // 商品検索クラスより離島価格設定リストを取得、保持する
            if (GoodsAccesser != null)
            {
                this._isolIslandList = new List<IsolIslandPrcWork>();
                if (GoodsAccesser.IsolIslandPrcWorkList != null && GoodsAccesser.IsolIslandPrcWorkList.Count != 0)
                {
                    this._isolIslandList.AddRange(GoodsAccesser.IsolIslandPrcWorkList);
                }
            }
            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

            // 対話形式で処理が進む場合（手動回答時）の価格算出用の設定
            // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
            //PriceCalculator.SetCurrentSCMOrderData(GetCustomerCode(scmOrderDetailRecord), scmOrderDetailRecord);
            EasyLogger.Write(MY_NAME, METHOD_NAME, "対話形式で処理が進む場合（手動回答時）の価格算出用の設定 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            PriceCalculator.SetCurrentSCMOrderData(GetCustomerCode(scmOrderDetailRecord), scmOrderDetailRecord, CurrentHeaderRecord);
            EasyLogger.Write(MY_NAME, METHOD_NAME, "対話形式で処理が進む場合（手動回答時）の価格算出用の設定 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<

            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
            #region 見積計上用処理

            // 問合せ・発注種別が｢発注｣で、前回データが｢見積｣で回答で済みの場合、回答済みの検索結果を構築
            // 2011/01/11 >>>
            //List<ISCMOrderAnswerRecord> answeredRecordList = FindAnsweredRecordByEstimate(scmOrderDetailRecord);

            List<ISCMOrderAnswerRecord> answeredRecordList = null;

            // 2011/02/18 >>>
            //if (CurrentHeaderRecord.AnswerDivCd == 99)
            if (CurrentHeaderRecord.CancelDiv == 1)
            // 2011/02/18 <<<
            {
                answeredRecordList = FindAnsweredRecordByBeforeAnswer(scmOrderDetailRecord);
            }
            else
            {
                answeredRecordList = FindAnsweredRecordByEstimate(scmOrderDetailRecord);
            }
            // 2011/01/11 <<<
            if (
                scmOrderDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Ordering)
                    &&
                !ListUtil.IsNullOrEmpty(answeredRecordList)
            )
            {
                #region <Log>

                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(
                    "見積計上となるため、商品検索を省略します。∵問合せ・発注種別が｢発注｣で、前回データが｢見積｣で回答で済み" + Environment.NewLine + SCMDataHelper.GetProfile(scmOrderDetailRecord)
                ));

                #endregion // </Log>

                // ----- ADD 2011/10/16 -------- >>>>>>>

                // PCCUOEの場合
                if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                {
                    if (!CarRecordMap.ContainsKey(carKey))
                    {
                        Debug.Assert(false, "明細に対応する車両情報が無い？");
                        return (int)ResultUtil.ResultCode.Abort;
                    }

                    // 車両情報の検索結果
                    CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;

                    if (!SearchedResultAndCarInfoMap.ContainsKey(carKey))
                    {
                        // 1パラ目：検索条件
                        CarSearchCondition searchingCarCondition = CreateSearchingCarCondition(
                            CarRecordMap[carKey]
                        );

                        //>>>2012/06/24
                        if (searchingCarCondition.ModelDesignationNo == 0 &&             // 型式指定番号
                            searchingCarCondition.CategoryNo == 0 &&                     // 類別区分番号
                            searchingCarCondition.CarModel.FullModel == string.Empty)    // 型式(フル型)
                        {
                            // 車両検索の条件が無いので、車両検索しない
                            searchedCarResult = CarSearchResultReport.retFailed;
                            searchedCarInfo = new PMKEN01010E();
                        }
                        else
                        {
                            //<<<2012/06/24

                            // 2パラ目：検索結果
                            searchedCarInfo = new PMKEN01010E();

                            if (this.CheckCarSearchCondition(searchingCarCondition))
                            {
                                EasyLogger.Write(MY_NAME, METHOD_NAME, "車両検索1 開始" + "パラメータ：" + GetCarSearchCondition(searchingCarCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                                EasyLogger.Write(MY_NAME, METHOD_NAME, "車両検索1 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                if (searchedCarInfo != null)
                                {
                                    if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
                                        searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                                    {
                                        if (searchedCarInfo.CarKindInfo != null &&
                                            searchedCarInfo.CarKindInfo.Count > 0)
                                        {
                                            searchedCarInfo.CarKindInfo[0].SelectionState = true;
                                            EasyLogger.Write(MY_NAME, METHOD_NAME, "車両検索2 開始" + "パラメータ：" + GetCarSearchCondition(searchingCarCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                            searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                                            EasyLogger.Write(MY_NAME, METHOD_NAME, "車両検索2 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                        }
                                    }
                                }
                            }
                            else
                            {
                                searchedCarResult = CarSearchResultReport.retFailed;
                            }
                        } // 2012/06/24

                        if (searchedCarInfo != null)
                        {
                            SearchedResultAndCarInfoMap.Add(
                                carKey,
                                new KeyValuePair<CarSearchResultReport, PMKEN01010E>(searchedCarResult, searchedCarInfo)
                            );
                        }
                    }
                }
                // ----- ADD 2011/10/16 -------- <<<<<<<


                // 2011/02/09 Add >>>
                //resultCode = AddAnsweredResult(scmOrderDetailRecord, answeredRecordList);
                EasyLogger.Write(MY_NAME, METHOD_NAME, "回答済み検索結果を追加する 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                resultCode = AddAnsweredResult(scmOrderDetailRecord, answeredRecordList, searchedCarInfo);
                EasyLogger.Write(MY_NAME, METHOD_NAME, "回答済み検索結果を追加する 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                // 2011/02/09 Add <<<

                // --- 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し（修正無し、目印としてコメント付加）---------->>>>>
                // DEL 2012/06/15 -------------------------------------->>>>>
                // --- ADD 三戸 2012/04/17 №166 ---------->>>>>
                // 自動回答判断時に現在庫を確認する為、商品検索を行う様に修正
                // 1パラ目：検索条件
                //GoodsCndtn searchingCondition = EditSearchingGoodsCondition(
                //    CreateSearchingGoodsCondition(scmOrderDetailRecord)
                //);

                //// 2パラ目：部品情報
                //PartsInfoDataSet partsInfoDB = null;

                //// 3パラ目：商品連結データ
                //List<GoodsUnitData> goodsUnitDataList = null;

                //// 4パラ目：メッセージ
                //string msg = string.Empty;

                //EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "品番検索 開始");
                //// 品番検索
                //int status = SearchPartsFromGoodsNo(
                //    searchingCondition,
                //    out partsInfoDB,
                //    out goodsUnitDataList,
                //    out msg
                //);
                //EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "品番検索 終了");

                //// UPD 2012/06/12 ----------------------------------------------------------------->>>>>
                ////ResultMap[scmOrderDetailRecord.ToKey()] = new SCMSearchedResult(
                ////        scmOrderDetailRecord,
                ////        RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind,
                ////        status,
                ////        partsInfoDB,
                ////        goodsUnitDataList,
                ////        SCMSearchedResult.GoodsSearchDivCd.GoodsName,
                ////        CurrentCarInfo,
                ////        false
                ////    );
                //ResultMap[scmOrderDetailRecord.ToKey()] = new SCMSearchedResult(
                //        scmOrderDetailRecord,
                //        RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind,
                //        status,
                //        partsInfoDB,
                //        goodsUnitDataList,
                //        SCMSearchedResult.GoodsSearchDivCd.GoodsName,
                //        searchedCarInfo,
                //        false
                //    );
                // UPD 2012/06/12 -----------------------------------------------------------------<<<<<
                // --- ADD 三戸 2012/04/17 №166 ----------<<<<<
                // DEL 2012/06/15 --------------------------------------<<<<<
                // --- 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し（修正無し、目印としてコメント付加）----------<<<<<
                return resultCode;  // 商品検索を行わない
            }

            #endregion // 見積計上用処理
            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            #region 削除(SCM改良の為)
            //// ----- ADD 2011/08/10 ----- >>>>>
            //// PCCUOEの場合
            //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            //{ 
            //    if (ExistsGoodsNo(scmOrderDetailRecord))
            //    {
            //        // 品番検索
            //        resultCode = SearchByGoodsNo(scmOrderDetailRecord);
            //        // 品番検索結果なし場合
            //        if (ListUtil.IsNullOrEmpty(ResultMap[scmOrderDetailRecord.ToKey()].GoodsUnitDataList))
            //        {
            //            // 用品入力処理
            //            resultCode = SearchByGoodsName(scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd.GoodsNo);
            //        }
            //    }
            //    else　if (ExistsBLGoodsCd(scmOrderDetailRecord))
            //    {
            //        // 車両検索→BL検索
            //        resultCode = SearchByCarAndBLCode(scmOrderDetailRecord);
            //        // 車両検索→BL検索結果なし場合
            //        if (ListUtil.IsNullOrEmpty(ResultMap[scmOrderDetailRecord.ToKey()].GoodsUnitDataList))
            //        {
            //            // 用品入力処理
            //            resultCode = SearchByGoodsName(scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd.BLCode);
            //        }
            //    } 
            //    else 
            //    {
            //        // 用品入力処理
            //        //>>>2012/04/09
            //        //resultCode = SearchByGoodsName(scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd.GoodsName);

            //        if (scmOrderDetailRecord.InqOrdDivCd == (int)InqOrdDivCd.Order)
            //        {
            //            resultCode = SearchByCarAndBLCode(scmOrderDetailRecord);
            //        }
            //        else
            //        {
            //            resultCode = SearchByGoodsName(scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd.GoodsName);
            //        }
            //        //<<<2012/04/09
            //    }
               
            
            //}
            //else // SCMの場合
            //{
            //// ----- ADD 2011/08/10 ----- <<<<<
            #endregion
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ------------------------------------------>>>>>
                //if (ExistsGoodsNo(scmOrderDetailRecord))
                if (ExistsGoodsNo(scmOrderDetailRecord) || (!ExistsGoodsNo(scmOrderDetailRecord) && !ExistsBLGoodsCd(scmOrderDetailRecord)))
                // UPD 2013/02/17 2013/03/06配信 システムテスト障害対応 ------------------------------------------<<<<<
                {
                    // 品番検索
                    EasyLogger.Write(MY_NAME, METHOD_NAME, "品番検索 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                    resultCode = SearchByGoodsNo(scmOrderDetailRecord);
                    EasyLogger.Write(MY_NAME, METHOD_NAME, "品番検索 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                }
                else
                {
                    // 車両検索→BL検索
                    EasyLogger.Write(MY_NAME, METHOD_NAME, "車両検索→BL検索 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                    resultCode = SearchByCarAndBLCode(scmOrderDetailRecord);
                    EasyLogger.Write(MY_NAME, METHOD_NAME, "車両検索→BL検索 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）

                    // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
                    // 車両検索→BL検索結果なし場合
                    if (ListUtil.IsNullOrEmpty(ResultMap[scmOrderDetailRecord.ToKey()].GoodsUnitDataList))
                    {
                        // SCM全体設定マスタ取得
                        SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(scmOrderDetailRecord.InqOtherEpCd, scmOrderDetailRecord.InqOtherSecCd);
                        if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
                        if (foundTotalSetting != null)
                        {
                            //問合せ時でSCM全体設定マスタの自動回答区分（問合せ）が「しない（手動）」以外の時
                            //且つ該当無自動回答区分が「する」時、用品入力処理を行う
                            if (scmOrderDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Inquiry) &&
                                !foundTotalSetting.AutoAnsInquiryDiv.Equals((int)AutoAnsInquiryDiv.None) &&
                                foundTotalSetting.FuwioutAutoAnsDiv.Equals((int)FuwioutAutoAnsDiv.Auto))
                            {
                                // 用品入力処理
                                EasyLogger.Write(MY_NAME, METHOD_NAME, "用品入力処理 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                resultCode = SearchByGoodsName(scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd.BLCode);
                                EasyLogger.Write(MY_NAME, METHOD_NAME, "用品入力処理 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                            }
                        }
                    }
                    // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                }

            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            //} // ADD 2011/08/10
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

            return resultCode;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 検索処理を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecordList">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="errorCount">エラーカウント</param>
        /// <returns>結果コード</returns>
        /// <remarks>
        /// <br>Update Note : 2018/07/26 陳艶丹</br>
        /// <br>管理番号    : 11470103-00</br>
        /// <br>            : SF側セット子品番発注時の障害対応</br>
        /// </remarks>
        public int Search(List<SCMOrderDetailRecordType> scmOrderDetailRecordList, out int errorCount)
        {
            const string METHOD_NAME = "Search(SCMOrderDetailRecordType, int)";  // ログ用

            errorCount = 0;
 
            CurrentHeaderRecord = GetHeaderRecord(scmOrderDetailRecordList[0]);

            int resultCode = (int)ResultUtil.ResultCode.Normal;

            List<ISCMOrderAnswerRecord> answerList = (OrgAnswerRecordList != null) ? (List<ISCMOrderAnswerRecord>)OrgAnswerRecordList : null;
            if (!CanSearch(scmOrderDetailRecordList[0], answerList))
            {
                #region <Log>

                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(
                    "SCM全体設定マスタのレコードが存在しない または SCM全体設定マスタ.自動回答区分が「0:しない」です。" + Environment.NewLine + SCMDataHelper.GetProfile(scmOrderDetailRecordList[0])
                ));

                #endregion // </Log>

                return resultCode;
            }
            PMKEN01010E searchedCarInfo = null;
            string carKey = scmOrderDetailRecordList[0].ToCarKey();
            if (!SearchedResultAndCarInfoMap.ContainsKey(carKey))
            {
                CarSearchResultReport searchedCarResult;
                PMKEN01010E oldCarInfo;
                this.GetOldCarInfo(CurrentHeaderRecord, out searchedCarResult, out oldCarInfo);
                if ((searchedCarResult != CarSearchResultReport.retError) && (searchedCarResult != CarSearchResultReport.retFailed))
                {

                    SearchedResultAndCarInfoMap.Add(
                        carKey,
                        new KeyValuePair<CarSearchResultReport, PMKEN01010E>(searchedCarResult, oldCarInfo)
                        );

                    searchedCarInfo = oldCarInfo;
                }
                else
                {
                    EasyLogger.Write(MY_NAME, "Search", "過去のデータより、車輌検索情報を取得できませんでした");
                }
            }
            else
            {
                searchedCarInfo = SearchedResultAndCarInfoMap[carKey].Value;
            }

            // 初期化済み商品検索クラスを取得
            GoodsAccesser = GoodsAcsServer.Singleton.Instance.GetGoodsAccesser(scmOrderDetailRecordList[0]);

            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
            // 商品検索クラスより離島価格設定リストを取得、保持する
            if (GoodsAccesser != null)
            {
                this._isolIslandList = new List<IsolIslandPrcWork>();
                if (GoodsAccesser.IsolIslandPrcWorkList != null && GoodsAccesser.IsolIslandPrcWorkList.Count != 0)
                {
                    this._isolIslandList.AddRange(GoodsAccesser.IsolIslandPrcWorkList);
                }
            }
            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

            // 対話形式で処理が進む場合（手動回答時）の価格算出用の設定
            PriceCalculator.SetCurrentSCMOrderData(GetCustomerCode(scmOrderDetailRecordList[0]), scmOrderDetailRecordList[0]);

            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
            #region 見積計上用処理

            // 問合せ・発注種別が｢発注｣で、前回データが｢見積｣で回答で済みの場合、回答済みの検索結果を構築

            List<List<ISCMOrderAnswerRecord>> answeredRecordList = new List<List<ISCMOrderAnswerRecord>>();

            foreach (ISCMOrderDetailRecord scmOrderDetailRecord in scmOrderDetailRecordList)
            {
                List<ISCMOrderAnswerRecord> answeredRecordListTemp = null;
                if (CurrentHeaderRecord.CancelDiv == 1)
                {
                    answeredRecordListTemp = FindAnsweredRecordByBeforeAnswer(scmOrderDetailRecord);
                    if (answeredRecordListTemp != null && answeredRecordListTemp.Count != 0)
                    {
                        answeredRecordList.Add(answeredRecordListTemp);
                    }
                }
                else
                {
                    answeredRecordListTemp = (FindAnsweredRecordByEstimate(scmOrderDetailRecord));
                    if (answeredRecordListTemp != null && answeredRecordListTemp.Count != 0)
                    {
                        answeredRecordList.Add(answeredRecordListTemp);
                    }
                }
            }

            if (
                scmOrderDetailRecordList[0].InqOrdDivCd.Equals((int)InqOrdDivCdValue.Ordering)
                    &&
                !ListUtil.IsNullOrEmpty(answeredRecordList)
            )
            {
                #region <Log>

                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(
                    "見積計上となるため、商品検索を省略します。∵問合せ・発注種別が｢発注｣で、前回データが｢見積｣で回答で済み" + Environment.NewLine + SCMDataHelper.GetProfile(scmOrderDetailRecordList[0])
                ));

                #endregion // </Log>

                // PCCUOEの場合
                if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                {
                    if (!CarRecordMap.ContainsKey(carKey))
                    {
                        Debug.Assert(false, "明細に対応する車両情報が無い？");
                        return (int)ResultUtil.ResultCode.Abort;
                    }

                    // 車両情報の検索結果
                    CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;

                    if (!SearchedResultAndCarInfoMap.ContainsKey(carKey))
                    {
                        // 1パラ目：検索条件
                        CarSearchCondition searchingCarCondition = CreateSearchingCarCondition(
                            CarRecordMap[carKey]
                        );

                        //>>>2012/06/24
                        if (searchingCarCondition.ModelDesignationNo == 0 &&             // 型式指定番号
                            searchingCarCondition.CategoryNo == 0 &&                     // 類別区分番号
                            searchingCarCondition.CarModel.FullModel == string.Empty)    // 型式(フル型)
                        {
                            // 車両検索の条件が無いので、車両検索しない
                            searchedCarResult = CarSearchResultReport.retFailed;
                            searchedCarInfo = new PMKEN01010E();
                        }
                        else
                        {
                            //<<<2012/06/24

                            // 2パラ目：検索結果
                            searchedCarInfo = new PMKEN01010E();

                            if (this.CheckCarSearchCondition(searchingCarCondition))
                            {
                                searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);

                                if (searchedCarInfo != null)
                                {
                                    if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
                                        searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                                    {
                                        if (searchedCarInfo.CarKindInfo != null &&
                                            searchedCarInfo.CarKindInfo.Count > 0)
                                        {
                                            searchedCarInfo.CarKindInfo[0].SelectionState = true;
                                            searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                searchedCarResult = CarSearchResultReport.retFailed;
                            }
                        } // 2012/06/24

                        if (searchedCarInfo != null)
                        {
                            SearchedResultAndCarInfoMap.Add(
                                carKey,
                                new KeyValuePair<CarSearchResultReport, PMKEN01010E>(searchedCarResult, searchedCarInfo)
                            );
                        }
                    }
                }
                // --- UPD 2018/07/26 陳艶丹  SF側セット子品番発注時の障害対応-------------------->>>>>
                //for (int i = 0; i < scmOrderDetailRecordList.Count; i++)
                //{
                //    resultCode = AddAnsweredResult(scmOrderDetailRecordList[i], answeredRecordList[i], searchedCarInfo);
                //}
                for (int i = 0; i < answeredRecordList.Count; i++)
                {
                    ISCMOrderDetailRecord resultWork = null;
                    foreach (ISCMOrderAnswerRecord answeredRecord in answeredRecordList[i])
                    {
                        resultWork = scmOrderDetailRecordList.Find(delegate(ISCMOrderDetailRecord scmOrderDetailRecord)
                        {
                            if ((answeredRecord.InqRowNumber == scmOrderDetailRecord.InqRowNumber &&
                                answeredRecord.GoodsMakerCd == scmOrderDetailRecord.GoodsMakerCd &&
                                answeredRecord.GoodsNo == scmOrderDetailRecord.GoodsNo) ||
                                //------------------UPD 2024/07/03 陳艶丹 BLP障害対応（例外発生箇所修正対応）---------------->>>>>
                                //(answeredRecord.GoodsNo == scmOrderDetailRecord.SetPartsNumber &&
                                (answeredRecord.InqRowNumber == scmOrderDetailRecord.InqRowNumber  &&
                                answeredRecord.GoodsNo == scmOrderDetailRecord.SetPartsNumber &&
                                //------------------UPD 2024/07/03 陳艶丹 BLP障害対応（例外発生箇所修正対応）----------------<<<<<
                                answeredRecord.GoodsMakerCd == scmOrderDetailRecord.SetPartsMkrCd))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        });

                    }
                    if (resultWork != null)
                    {
                        resultCode = AddAnsweredResult(resultWork, answeredRecordList[i], searchedCarInfo);

                    }
                }
                // --- UPD 2018/07/26 陳艶丹  SF側セット子品番発注時の障害対応--------------------<<<<<

                return resultCode;  // 商品検索を行わない
            }

            #endregion // 見積計上用処理
            // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

            // 品番検索リストとBLコード検索リストを生成
            List<ISCMOrderDetailRecord> searchGoodsNoList = new List<ISCMOrderDetailRecord>();
            List<ISCMOrderDetailRecord> searchBLCodeList = new List<ISCMOrderDetailRecord>();
            foreach (ISCMOrderDetailRecord scmOrderDetailRecord in scmOrderDetailRecordList)
            {
                // 品番を含んでいるか
                if (ExistsGoodsNo(scmOrderDetailRecord) || (!ExistsGoodsNo(scmOrderDetailRecord) && !ExistsBLGoodsCd(scmOrderDetailRecord)))
                {
                    // 品番検索
                    searchGoodsNoList.Add(scmOrderDetailRecord);
                }
                else
                {
                    // BLコード検索
                    searchBLCodeList.Add(scmOrderDetailRecord);
                }
            }

            if (searchGoodsNoList != null && searchGoodsNoList.Count != 0)
            {
                // 品番検索
                resultCode = SearchByGoodsNo(searchGoodsNoList);
            }

            if (searchBLCodeList != null && searchBLCodeList.Count != 0)
            {
                // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 ----->>>>>
                //BLコードと装備分類のDictionaryの作成
                GetBLCodeDic();
                // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 -----<<<<<

                // 車両検索→BL検索
                resultCode = SearchByCarAndBLCode(searchBLCodeList);

                foreach (ISCMOrderDetailRecord scmOrderDetailRecord in searchBLCodeList)
                {
                    // 車両検索→BL検索結果なし場合
                    if (ListUtil.IsNullOrEmpty(ResultMap[scmOrderDetailRecord.ToKey()].GoodsUnitDataList))
                    {
                        // SCM全体設定マスタ取得
                        SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(scmOrderDetailRecord.InqOtherEpCd, scmOrderDetailRecord.InqOtherSecCd);
                        if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
                        if (foundTotalSetting != null)
                        {
                            //問合せ時でSCM全体設定マスタの自動回答区分（問合せ）が「しない（手動）」以外の時
                            //且つ該当無自動回答区分が「する」時、用品入力処理を行う
                            if (scmOrderDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Inquiry) &&
                                !foundTotalSetting.AutoAnsInquiryDiv.Equals((int)AutoAnsInquiryDiv.None) &&
                                foundTotalSetting.FuwioutAutoAnsDiv.Equals((int)FuwioutAutoAnsDiv.Auto))
                            {
                                // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 ----->>>>>
                                //TBO品目の場合、手動処理の仕様がある為、用品入力処理を行わない　　TBOの判定：装備分類が「0」以外
                                if (BLCodeDic.ContainsKey(scmOrderDetailRecord.BLGoodsCode)
                                    && BLCodeDic[scmOrderDetailRecord.BLGoodsCode] != 0)
                                {
                                    continue;
                                }
                                // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 -----<<<<<
                                // 用品入力処理
                                resultCode = SearchByGoodsName(scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd.BLCode);
                            }
                        }
                    }
                }
            }

            return resultCode;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 ----->>>>>
        /// <summary>
        /// BLコードと装備分類のDictionaryの作成
        /// </summary>
        /// <returns>BLコードと装備分類のDictionary</returns>
        /// <remarks>
        /// <br>Note       : BLコードマスタから全検索し、BLコードと装備分類のDictionaryを作成して戻す</br>
        /// <br>           : Redmine#48055 2016年2月配信分</br>
        /// <br>           : SFからTBOを含む品目を問合せした場合、TBO品目のBLコード検索異常が発生した為、他の品目も含めて全て手動回答となってしまうの障害対応</br>
        /// <br>Programmer : 顧棟</br>
        /// <br>Date       : 2016/01/13</br>
        /// </remarks>
        private void GetBLCodeDic()
        {
            //BL情報の取得<提供>
            _iBLGoodsCdDB = MediationTbsPartsCodeDB.GetTbsPartsCodeDB();
            object objret = null;
            //条件ワークの作成
            TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
            tbsPartsCodeWork.TbsPartsCode = 0;//全件検索
            //BLコード全件検索
            _iBLGoodsCdDB.SearchDerived(out objret, tbsPartsCodeWork);
            ArrayList BLCodeWorkList = objret as ArrayList;

            //BLコードと装備分類のDictionaryの作成
            BLCodeDic = new Dictionary<int, int>();
            foreach (TbsPartsCodeWork wkTbsPartsCodeWork in BLCodeWorkList)
            {
                if (!BLCodeDic.ContainsKey(wkTbsPartsCodeWork.TbsPartsCode))
                {
                    //Key：BLコード　Value：装備分類
                    BLCodeDic.Add(wkTbsPartsCodeWork.TbsPartsCode, wkTbsPartsCodeWork.EquipGenre);
                }
            }
        }
        // --- ADD 2016/01/13 顧棟 Redmine#48055 自動回答の場合、TBO品目のBLコード検索異常の障害対応 -----<<<<<

        // 2011/02/09 Add >>>
        /// <summary>
        /// 過去の回答データが存在するかチェックします。
        /// </summary>
        /// <param name="CurrentHeaderRecord"></param>
        /// <param name="result"></param>
        /// <param name="searchedCarInfo"></param>
        /// <returns></returns>
        private void GetOldCarInfo(ISCMOrderHeaderRecord CurrentHeaderRecord, out CarSearchResultReport result, out PMKEN01010E searchedCarInfo)
        {
            result = CarSearchResultReport.retError;
            searchedCarInfo = null;
            int acptAnOdrStatus = 0;
            string salesSlipNum = 0.ToString(SCMEntityUtil.SALES_SLIP_NUM_FORMAT);
            int salesRowNo = 0;

            // 各ＰＧからのパラメータから、回答済みの伝票番号を取得する。
            if (OrgAnswerRecordList != null)
            {
                List<ISCMOrderAnswerRecord> orgAnswerList = (List<ISCMOrderAnswerRecord>)OrgAnswerRecordList;
                ISCMOrderAnswerRecord answer = orgAnswerList.Find(delegate(ISCMOrderAnswerRecord answerRecord)
                                {
                                    // ----- UPD 2011/09/20 ----- >>>>>
                                    //if (( answerRecord.AcptAnOdrStatus != 0 ) &&
                                    //    ( !string.IsNullOrEmpty(answerRecord.SalesSlipNum) ) &&
                                    //    ( answerRecord.SalesSlipNum != 0.ToString(SCMEntityUtil.SALES_SLIP_NUM_FORMAT) ))
                                    //{
                                    //    return true;
                                    //}
                                    //return false;
                                    // UPD 2015/07/29 豊沢 SCM高速化 Redmine4382対応 --------------------->>>>>
                                    //// PCCUOEの場合
                                    //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                                    //{
                                    //    if ((answerRecord.AcptAnOdrStatus != 0) &&
                                    //        (!string.IsNullOrEmpty(answerRecord.SalesSlipNum)) &&
                                    //        //(answerRecord.SalesSlipNum != 0.ToString(SCMEntityUtil.SALES_SLIP_NUM_FORMAT)) &&  // DEL 2011/10/16
                                    //        (CurrentHeaderRecord.InquiryNumber == answerRecord.InquiryNumber))
                                    //    {
                                    //        return true;
                                    //    }
                                    //    return false;
                                    //}
                                    //else
                                    //{
                                    //if (( answerRecord.AcptAnOdrStatus != 0 ) &&
                                    //    ( !string.IsNullOrEmpty(answerRecord.SalesSlipNum) ) &&
                                    //    ( answerRecord.SalesSlipNum != 0.ToString(SCMEntityUtil.SALES_SLIP_NUM_FORMAT) ))
                                    //{
                                    //    return true;
                                    //}
                                    //return false;
                                    //}
                                    if ((answerRecord.AcptAnOdrStatus != 0) &&
                                        (!string.IsNullOrEmpty(answerRecord.SalesSlipNum)) &&
                                        (CurrentHeaderRecord.InquiryNumber == answerRecord.InquiryNumber) &&
                                        (CurrentHeaderRecord.InqOriginalEpCd.Trim() == answerRecord.InqOriginalEpCd.Trim()) && //@@@@20230303
                                        (CurrentHeaderRecord.InqOriginalSecCd == answerRecord.InqOriginalSecCd) &&
                                        (CurrentHeaderRecord.InqOtherEpCd == answerRecord.InqOtherEpCd) &&
                                        (CurrentHeaderRecord.InqOtherSecCd == answerRecord.InqOtherSecCd))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                    // UPD 2015/07/29 豊沢 SCM高速化 Redmine4382対応 ---------------------<<<<<
                                    // ----- UPD 2011/09/20 ----- <<<<<
                                    
                                });
                if (answer != null)
                {
                    acptAnOdrStatus = answer.AcptAnOdrStatus;
                    salesSlipNum = answer.SalesSlipNum;
                    salesRowNo = answer.SalesRowNo;
                }
            }
            // この時点で取得出来ていない場合は、リモートで取得
            if (acptAnOdrStatus == 0)
            {
                IOWriteSCMReadWork readWork = new IOWriteSCMReadWork();
                IOWriteSCMReadWork scmReadWork = new IOWriteSCMReadWork();

                scmReadWork.EnterpriseCode = CurrentHeaderRecord.EnterpriseCode;
                scmReadWork.InqOtherSecCd = CurrentHeaderRecord.InqOtherSecCd;
                scmReadWork.InqOriginalEpCd = CurrentHeaderRecord.InqOriginalEpCd.Trim();//@@@@20230303
                scmReadWork.InqOriginalSecCd = CurrentHeaderRecord.InqOriginalSecCd;
                scmReadWork.InquiryNumber = CurrentHeaderRecord.InquiryNumber;
                // 2011/02/18 >>>
                //scmReadWork.AnswerDivCds = new int[] { 0 };
                // 2011/02/18 <<<
                SCMAcOdrDataWork scmHeaderWork;
                SCMAcOdrDtCarWork scmCarWork;
                List<SCMAcOdrDtlIqWork> scmDetailWorkList;
                List<SCMAcOdrDtlAsWork> scmAnswerWorkList;
                List<SCMAcOdSetDtWork> scmAcOdSetDtWorkList; // ADD 2011/08/10

                // ----- UPD 2011/08/10 ----- >>>>>
                //int status = SCMIOWriterAgent.Read(scmReadWork, out scmHeaderWork, out scmCarWork, out scmDetailWorkList, out scmAnswerWorkList);
                int status = SCMIOWriterAgent.Read(scmReadWork, out scmHeaderWork, out scmCarWork, out scmDetailWorkList, out scmAnswerWorkList, out scmAcOdSetDtWorkList);
                // ----- UPD 2011/08/10 ----- <<<<<

                if (status == 0)
                {

                    SCMAcOdrDtlAsWork answer = scmAnswerWorkList.Find(delegate(SCMAcOdrDtlAsWork answerRecord)
                                {
                                    if (( answerRecord.AcptAnOdrStatus != 0 ) &&
                                        ( !string.IsNullOrEmpty(answerRecord.SalesSlipNum) ) &&
                                        ( answerRecord.SalesSlipNum != 0.ToString(SCMEntityUtil.SALES_SLIP_NUM_FORMAT) ))
                                    {
                                        return true;
                                    }
                                    return false;
                                });
                    if (answer != null)
                    {
                        acptAnOdrStatus = answer.AcptAnOdrStatus;
                        salesSlipNum = answer.SalesSlipNum;
                        salesRowNo = answer.SalesRowNo;
                    }
                }
            }
            if (acptAnOdrStatus == 0) return;

            SalesDetailWork[] foundSalesDetails;
            AcceptOdrCarWork[] foundAcceptOdrCars;
            SalesDetailDB.FindSalesDetailInfo(
                CurrentHeaderRecord.InqOtherEpCd,
                CurrentHeaderRecord.InqOtherSecCd,
                acptAnOdrStatus,
                salesSlipNum,
                salesRowNo,
                out foundSalesDetails,
                out foundAcceptOdrCars
            );

            if (foundAcceptOdrCars == null || foundAcceptOdrCars.Length == 0) return;

            string[] freeSrchMdlFxdNoAry = null;
            int[] fullModelFixedNoAry = null;
            if (foundAcceptOdrCars[0].FreeSrchMdlFxdNoAry != null && foundAcceptOdrCars[0].FreeSrchMdlFxdNoAry.Length > 0)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                {
                    MemoryStream ms = null;
                    try
                    {
                        ms = new MemoryStream(foundAcceptOdrCars[0].FreeSrchMdlFxdNoAry);
                        freeSrchMdlFxdNoAry = (string[])formatter.Deserialize(ms);  // 自由検索型式固定番号配列
                    }
                    finally
                    {
                        if (ms != null) ms.Close();
                    }
                }
            }
            if (foundAcceptOdrCars[0].FullModelFixedNoAry != null && foundAcceptOdrCars[0].FullModelFixedNoAry.Length > 0)
            {
                fullModelFixedNoAry = foundAcceptOdrCars[0].FullModelFixedNoAry;
            }
            if (freeSrchMdlFxdNoAry == null && fullModelFixedNoAry == null) return;

            if (freeSrchMdlFxdNoAry == null) freeSrchMdlFxdNoAry = new string[0];
            if (fullModelFixedNoAry == null) fullModelFixedNoAry = new int[0];

            CarSearchCondition carSearchCond = new CarSearchCondition();
            carSearchCond.CarModel.FullModel = foundAcceptOdrCars[0].FullModel;
            carSearchCond.MakerCode = foundAcceptOdrCars[0].MakerCode;
            carSearchCond.ModelCode = foundAcceptOdrCars[0].ModelCode;
            carSearchCond.ModelSubCode = foundAcceptOdrCars[0].ModelSubCode;
            carSearchCond.ModelDesignationNo = foundAcceptOdrCars[0].ModelDesignationNo;
            carSearchCond.CategoryNo = foundAcceptOdrCars[0].CategoryNo;
            searchedCarInfo = new PMKEN01010E();
            result = SearchCarByFullModelFixedNo(fullModelFixedNoAry, freeSrchMdlFxdNoAry, carSearchCond, ref searchedCarInfo);
            // 2011/03/08 Add >>>
            if (result != CarSearchResultReport.retError && result != CarSearchResultReport.retFailed && result != CarSearchResultReport.retMultipleCarKind)
            {
                if (foundAcceptOdrCars[0].FirstEntryDate != 0)
                {
                    searchedCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = foundAcceptOdrCars[0].FirstEntryDate;
                }
                if (foundAcceptOdrCars[0].SearchFrameNo != 0)
                {
                    searchedCarInfo.CarModelUIData[0].SearchFrameNo = foundAcceptOdrCars[0].SearchFrameNo;
                }
                //if (foundAcceptOdrCars[0].FrameNo != 0)
                //{
                //    searchedCarInfo.CarModelUIData[0].FrameNo = foundAcceptOdrCars[0].FrameNo;
                //}

                // --- ADD 譚洪 2014/09/01 Redmine#43289---------->>>>>
                if (foundAcceptOdrCars[0].ModelDesignationNo != 0)
                {
                    searchedCarInfo.CarModelUIData[0].ModelDesignationNo = foundAcceptOdrCars[0].ModelDesignationNo;
                }

                if (foundAcceptOdrCars[0].CategoryNo != 0)
                {
                    searchedCarInfo.CarModelUIData[0].CategoryNo = foundAcceptOdrCars[0].CategoryNo;
                }
                // --- ADD 譚洪 2014/09/01 Redmine#43289----------<<<<<

                if (!string.IsNullOrEmpty(foundAcceptOdrCars[0].ColorCode))
                {
                    PMKEN01010E.ColorCdInfoRow[] colorRows = (PMKEN01010E.ColorCdInfoRow[])searchedCarInfo.ColorCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.ColorCdInfo.ColorCodeColumn.ColumnName, foundAcceptOdrCars[0].ColorCode));
                    if (colorRows.Length > 0)
                    {
                        colorRows[0].SelectionState = true;
                    }
                }

                // トリムの絞込み
                if (!string.IsNullOrEmpty(foundAcceptOdrCars[0].TrimCode))
                {
                    PMKEN01010E.TrimCdInfoRow[] trimRows = (PMKEN01010E.TrimCdInfoRow[])searchedCarInfo.TrimCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.TrimCdInfo.TrimCodeColumn.ColumnName, foundAcceptOdrCars[0].TrimCode));
                    if (trimRows.Length > 0)
                    {
                        trimRows[0].SelectionState = true;
                    }
                }
            }
            // 2011/03/08 Add <<<
        }
        // 2011/02/09 Add <<<

        #region <検索を行えるかの判定>

        /// <summary>
        /// 検索を行えるか判断します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="answerList">SCM受注明細データ(回答)のリスト</param>
        /// <returns>
        /// <c>true</c> :検索を行えます。<br/>
        /// <c>false</c>:検索を行えません。
        /// </returns>
        // 2011/02/14 >>>
        //protected abstract bool CanSearch(SCMOrderDetailRecordType scmOrderDetailRecord);
        protected abstract bool CanSearch(SCMOrderDetailRecordType scmOrderDetailRecord, List<ISCMOrderAnswerRecord> answerList);
        // 2011/02/14 <<<

        #endregion // </検索を行えるかの判定>

        /// <summary>
        /// 品番が存在するか判断します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>
        /// <c>true</c> :存在します。<br/>
        /// <c>false</c>:存在しません。
        /// </returns>
        protected bool ExistsGoodsNo(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            return SCMDataHelper.ExistsGoodsNo(scmOrderDetailRecord);
        }

        // ----- 2011/08/10 ----- >>>>>
        /// <summary>
        /// BLコードが存在するか判断します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>
        /// <c>true</c> :存在します。<br/>
        /// <c>false</c>:存在しません。
        /// </returns>
        protected bool ExistsBLGoodsCd(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            return SCMDataHelper.ExistsBLGoodsCd(scmOrderDetailRecord);
        }
        // ----- 2011/08/10 ----- <<<<<

        #region <品番検索>
        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// セット品番検索を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecord">検索条件</param>
        /// <param name="GoodsNo">商品連結データ</param>
        /// <param name="GoodsMakerCd">商品連結データ</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        public int SearchSetFromGoodsNo(SCMOrderDetailRecordType scmOrderDetailRecord,string GoodsNo,int GoodsMakerCd, out GoodsUnitData goodsUnitData,out string msg)
        {
            goodsUnitData = null;
            // 1パラ目：検索条件
            GoodsCndtn searchingCondition = EditSearchingGoodsCondition(
                CreateSetSearchingGoodsCondition(scmOrderDetailRecord, GoodsNo, GoodsMakerCd)
            );
            // 品番検索(結合検索無し)
            msg = string.Empty;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            // UPD 2013/10/03 SCM仕掛一覧№10578対応 ------------------------------->>>>>
            //int status = GoodsAccesser.SearchPartsFromGoodsNoNonVariousSearch(
            //    searchingCondition,
            //    out goodsUnitDataList,
            //    out msg
            //    );
            int status = GoodsAccesser.SearchPartsFromGoodsNoNonVariousSearch(
                searchingCondition,
                false,
                out goodsUnitDataList,
                out msg
                );
            // UPD 2013/10/03 SCM仕掛一覧№10578対応 -------------------------------<<<<<
            if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL && goodsUnitDataList.Count > 0)
            {
                goodsUnitData = goodsUnitDataList[0];
                // ADD 2013/10/03 SCM仕掛一覧№10578対応 ------------------------------->>>>>
                // 選択倉庫コードがなく、在庫リストが存在する時
                if (string.IsNullOrEmpty(goodsUnitData.SelectedWarehouseCode) && goodsUnitData.StockList.Count > 0)
                {
                    bool findFlag = false;
                    goodsUnitData.SelectedWarehouseCode = null;
                    // 優先倉庫リスト取得
                    List<string> priorWarehouseList = CreatePriorWarehouseList(this._currentHeaderRecord);
                    // 在庫リストより優先倉庫に該当する倉庫コードを取得
                    for (int i = 0; i < priorWarehouseList.Count; i++)
                    {
                        foreach (Stock rec in goodsUnitData.StockList)
                        {
                            if (priorWarehouseList[i].Trim() == rec.WarehouseCode.Trim())
                            {
                                goodsUnitData.SelectedWarehouseCode = priorWarehouseList[i].Trim();
                                findFlag = true;
                                break;
                            }
                        }
                        // 見つかった時処理終了
                        if (findFlag) break;
                    }
                }
                // ADD 2013/10/03 SCM仕掛一覧№10578対応 -------------------------------<<<<<
                // ADD 2015/03/03 SCM高速化Redmine#310対応 ------------------------------->>>>>
                // セット品の品番検索時、不足情報の補正処理を行う
                GoodsAccesser.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 0);
                // ADD 2015/03/03 SCM高速化Redmine#310対応 -------------------------------<<<<<
            }
            return status;

        }

        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        /// <summary>
        /// セット品番検索を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecord">検索条件</param>
        /// <param name="GoodsNo">品番</param>
        /// <param name="GoodsMakerCd">メーカーコード</param>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="offerPriceList">提供データ価格情報</param>
        /// <param name="userPriceList">ユーザー登録分価格情報</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        /// <remarks>
        /// <br>Update Note : 2018/07/06 陳艶丹</br>
        /// <br>管理番号    : 11470103-00</br>
        /// <br>            : SF側セット子品番の在庫情報の障害対応</br>
        /// </remarks>
        public int SearchSetFromGoodsNo(SCMOrderDetailRecordType scmOrderDetailRecord, string GoodsNo, int GoodsMakerCd, out GoodsUnitData goodsUnitData,
                                         out List<GoodsPrice> offerPriceList, out List<GoodsPrice> userPriceList, out string msg)
        {
            goodsUnitData = null;
            offerPriceList = new List<GoodsPrice>();
            userPriceList = new List<GoodsPrice>();
            PartsInfoDataSet retPartsInfoDataSet = null;
            // 1パラ目：検索条件
            GoodsCndtn searchingCondition = EditSearchingGoodsCondition(
                CreateSetSearchingGoodsCondition(scmOrderDetailRecord, GoodsNo, GoodsMakerCd)
            );
            // 品番検索(結合検索無し)
            msg = string.Empty;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            int status = GoodsAccesser.SearchPartsFromGoodsNoNonVariousSearch(
                searchingCondition,
                false,
                out goodsUnitDataList,
                out retPartsInfoDataSet,
                out msg
                );
            if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL && goodsUnitDataList.Count > 0)
            {
                goodsUnitData = goodsUnitDataList[0];
                // 選択倉庫コードがなく、在庫リストが存在する時
                if (string.IsNullOrEmpty(goodsUnitData.SelectedWarehouseCode) && goodsUnitData.StockList.Count > 0)
                {
                    bool findFlag = false;
                    goodsUnitData.SelectedWarehouseCode = null;
                    // 優先倉庫リスト取得
                    // UPD 2018/07/06 陳艶丹 SF側セット子品番の在庫情報の障害対応 --------->>>>>
                    //List<string> priorWarehouseList = CreatePriorWarehouseList(this._currentHeaderRecord);
                    // 優先倉庫リスト(PCC自社設定マスタの優先倉庫)取得
                    List<string> priorWarehouseList = CreatePriorWarehouseListForPccuoe(this._currentHeaderRecord);
                    // UPD 2018/07/06 陳艶丹 SF側セット子品番の在庫情報の障害対応 ---------<<<<<

                    // 在庫リストより優先倉庫に該当する倉庫コードを取得
                    for (int i = 0; i < priorWarehouseList.Count; i++)
                    {
                        foreach (Stock rec in goodsUnitData.StockList)
                        {
                            if (priorWarehouseList[i].Trim() == rec.WarehouseCode.Trim())
                            {
                                goodsUnitData.SelectedWarehouseCode = priorWarehouseList[i].Trim();
                                findFlag = true;
                                break;
                            }
                        }
                        // 見つかった時処理終了
                        if (findFlag) break;
                    }
                }
                // セット品の品番検索時、不足情報の補正処理を行う
                GoodsAccesser.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, 0);

                // 部品情報から提供データの価格情報とユーザー登録分価格情報を戻り値に設定
                if (retPartsInfoDataSet != null)
                {
                    if (retPartsInfoDataSet.OfrPriceDataTable != null && retPartsInfoDataSet.OfrPriceDataTable.Count != 0)
                    {
                        GetGoodsPriceListFromUsrGoodsPriceDataTable(GoodsMakerCd, GoodsNo, retPartsInfoDataSet.OfrPriceDataTable, out offerPriceList);
                    }
                    if (retPartsInfoDataSet.UsrGoodsPrice != null && retPartsInfoDataSet.UsrGoodsPrice.Count != 0)
                    {
                        GetGoodsPriceListFromUsrGoodsPriceDataTable(GoodsMakerCd, GoodsNo, retPartsInfoDataSet.UsrGoodsPrice, out userPriceList);
                    }
                }
            }
            return status;

        }

        /// <summary>
        ///  ユーザー商品価格情報から価格情報リストを取得します
        /// </summary>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="usrGoodsPriceDataTable">PartInfoDataSetユーザー価格情報</param>
        /// <param name="PriceList">価格情報リスト</param>
        private void GetGoodsPriceListFromUsrGoodsPriceDataTable(int goodsMakerCd, string goodsNo, PartsInfoDataSet.UsrGoodsPriceDataTable usrGoodsPriceDataTable, out List<GoodsPrice> PriceList)
        {
            PriceList = new List<GoodsPrice>();

            if (usrGoodsPriceDataTable == null || usrGoodsPriceDataTable.Count == 0) return;
            if (goodsMakerCd == 0 || string.IsNullOrEmpty(goodsNo)) return;

            PartsInfoDataSet.UsrGoodsPriceRow[] priceRows = (PartsInfoDataSet.UsrGoodsPriceRow[])usrGoodsPriceDataTable.Select(string.Format("GoodsMakerCd = '{0}' AND GoodsNo = '{1}'",
                                                              goodsMakerCd, goodsNo.Trim()));
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
                PriceList.Add(prc);
            }
        }
        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        // -- ADD 2011/08/10   ------ <<<<<<
        /// <summary>
        /// 品番検索を行います。
        /// </summary>
        /// <remarks>
        /// 売上伝票入力(MAHNB01012AB.cs::SalesSlipInputAcs.SearchPartsFromGoodsNo())を参考
        /// </remarks>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        /// <br>Update Note : 2024/04/23 陳艶丹</br>
        /// <br>管理番号    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4350 BLP不具合対応 得意先設定と異なる倉庫コードが回答される</br>
        protected int SearchByGoodsNo(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            // 2011/02/09 品番検索でも、車両検索する Add >>>
            #region <車両検索>

            // 車両検索を開始
            string carKey = scmOrderDetailRecord.ToCarKey();
            if (!CarRecordMap.ContainsKey(carKey))
            {
                Debug.Assert(false, "明細に対応する車両情報が無い？");
                return (int)ResultUtil.ResultCode.Abort;
            }

            // 車両情報の検索結果
            CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;
            PMKEN01010E searchedCarInfo = null;

            if (!SearchedResultAndCarInfoMap.ContainsKey(carKey))
            {
                // 1パラ目：検索条件
                CarSearchCondition searchingCarCondition = CreateSearchingCarCondition(
                    CarRecordMap[carKey]
                );

                //>>>2012/06/24
                if (searchingCarCondition.ModelDesignationNo == 0 &&             // 型式指定番号
                    searchingCarCondition.CategoryNo == 0 &&                     // 類別区分番号
                    searchingCarCondition.CarModel.FullModel == string.Empty)    // 型式(フル型)
                {
                    // 車両検索の条件が無いので、車両検索しない
                    searchedCarResult = CarSearchResultReport.retFailed;
                    searchedCarInfo = new PMKEN01010E();
                }
                else
                {
                //<<<2012/06/24

                    // 2パラ目：検索結果
                    searchedCarInfo = new PMKEN01010E();

                    // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                    if (this.CheckCarSearchCondition(searchingCarCondition))
                    {
                        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

                        // 車両検索
                        // 2011/03/08 >>>
                        //searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                        EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "車両検索1 開始" + "パラメータ:" + GetCarSearchCondition(searchingCarCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                        searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                        EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "車両検索1 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                        // 2011/03/08 <<<
                        if (searchedCarInfo != null)
                        {
                            for (int i = 0; i < searchedCarInfo.CategoryEquipmentInfo.Count; i++)
                            {
                                Debug.WriteLine(string.Format("\t車両検索結果：BLコード[{0}] = {1}", i, searchedCarInfo.CategoryEquipmentInfo[i].TbsPartsCode));
                            }
                        }

                        // 検索結果を保持 ∵1問合せで車両は同じであるため、同じ車両検索を何度も行わない
                        if (searchedCarInfo != null)
                        {
                            // 2011/03/08 Del 絞込み等は、各Searcherで行う >>>
                            //// 2010/03/17 Add >>>

                            //// 年式の絞込み
                            //if (CarRecordMap[carKey].ProduceTypeOfYearNum != 0)
                            //{
                            //    PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchedCarInfo.CarModelInfoSummarized; // 型式情報要約テーブル

                            //    int stDate = ( ( ( carModelInfoDataTable[0].StProduceTypeOfYear / 100 ) == 9999 ) || ( ( carModelInfoDataTable[0].StProduceTypeOfYear % 100 ) == 99 ) ) ? 0 : carModelInfoDataTable[0].StProduceTypeOfYear;
                            //    int edDate = ( ( ( carModelInfoDataTable[0].EdProduceTypeOfYear / 100 ) == 9999 ) || ( ( carModelInfoDataTable[0].EdProduceTypeOfYear % 100 ) == 99 ) ) ? 0 : carModelInfoDataTable[0].EdProduceTypeOfYear;

                            //    if (stDate != 0 || edDate != 0)
                            //    {
                            //        edDate = ( edDate == 0 ) ? 999999 : edDate;

                            //        if (stDate <= CarRecordMap[carKey].ProduceTypeOfYearNum && CarRecordMap[carKey].ProduceTypeOfYearNum <= edDate)
                            //        {
                            //            searchedCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = CarRecordMap[carKey].ProduceTypeOfYearNum;
                            //        }
                            //    }
                            //}

                            //// カラーの絞込み
                            //if (!string.IsNullOrEmpty(CarRecordMap[carKey].RpColorCode))
                            //{
                            //    PMKEN01010E.ColorCdInfoRow[] colorRows = (PMKEN01010E.ColorCdInfoRow[])searchedCarInfo.ColorCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.ColorCdInfo.ColorCodeColumn.ColumnName, CarRecordMap[carKey].RpColorCode));
                            //    if (colorRows.Length > 0)
                            //    {
                            //        colorRows[0].SelectionState = true;
                            //    }
                            //}

                            //// トリムの絞込み
                            //if (!string.IsNullOrEmpty(CarRecordMap[carKey].TrimCode))
                            //{
                            //    PMKEN01010E.TrimCdInfoRow[] trimRows = (PMKEN01010E.TrimCdInfoRow[])searchedCarInfo.TrimCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.TrimCdInfo.TrimCodeColumn.ColumnName, CarRecordMap[carKey].TrimCode));
                            //    if (trimRows.Length > 0)
                            //    {
                            //        trimRows[0].SelectionState = true;
                            //    }
                            //}
                            //// 2010/03/17 Add <<<
                            // 2011/03/08 Del <<<

                            // ----- ADD 2011/09/20 ----- >>>>>
                            if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
                                searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                            {
                                if (searchedCarInfo.CarKindInfo != null &&
                                    searchedCarInfo.CarKindInfo.Count > 0)
                                {
                                    searchedCarInfo.CarKindInfo[0].SelectionState = true;
                                    EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "車両検索2 開始" + "パラメータ:" + GetCarSearchCondition(searchingCarCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                    searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                                    EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "車両検索2 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                }
                            }

                            if (searchedCarInfo != null)
                            {
                                // ----- ADD 2011/09/20 ----- <<<<<
                                SearchedResultAndCarInfoMap.Add(
                                    carKey,
                                    new KeyValuePair<CarSearchResultReport, PMKEN01010E>(searchedCarResult, searchedCarInfo)
                                );
                            } // ADD 2011/09/20
                        }
                        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                    }
                    else
                    {
                        searchedCarResult = CarSearchResultReport.retFailed;
                    }
                    // --- ADD m.suzuki 2011/05/23 ----------<<<<<
                } // 2012/06/24
            }
            else
            {
                searchedCarResult = SearchedResultAndCarInfoMap[carKey].Key;
                searchedCarInfo = SearchedResultAndCarInfoMap[carKey].Value;
            }

            CurrentCarInfo = searchedCarInfo;

            #endregion // </車両検索>

            // ----- UPD 2011/08/10 ----- >>>>>
            //// 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
            //if (
            //    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
            //    // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            //        &&
            //    !searchedCarResult.Equals(CarSearchResultReport.retFailed)
            //    // --- ADD m.suzuki 2011/05/23 ----------<<<<<
            //        &&
            //    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
            //)
            //{
            //    return (int)ResultUtil.ResultCode.Abort;
            //}
            //// 2011/02/09 Add <<<

            // SCMの場合
            if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
            {
                // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
                if (
                    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retFailed)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                )
                {
                    return (int)ResultUtil.ResultCode.Abort;
                }
                // 2011/02/09 Add <<<
            }
            // PCCUOEの場合
            else
            {
                // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
                if (
                    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retFailed)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind)
                )
                {
                    return (int)ResultUtil.ResultCode.Abort;
                }
            }
            // ----- UPD 2011/08/10 ----- <<<<<

            // 1パラ目：検索条件
            GoodsCndtn searchingCondition = EditSearchingGoodsCondition(
                CreateSearchingGoodsCondition(scmOrderDetailRecord)
            );

            // 2パラ目：部品情報
            PartsInfoDataSet partsInfoDB = null;

            // 3パラ目：商品連結データ
            List<GoodsUnitData> goodsUnitDataList = null;

            // 4パラ目：メッセージ
            string msg = string.Empty;

            EasyLogger.Write( MY_NAME, "SearchByGoodsNo", "品番検索 開始" );    // 2010/03/17 Add
            // 品番検索
            int status = SearchPartsFromGoodsNo(
                searchingCondition,
                out partsInfoDB,
                out goodsUnitDataList,
                out msg
            );
            EasyLogger.Write( MY_NAME, "SearchByGoodsNo", "品番検索 終了" );    // 2010/03/17 Add

            // 検索結果を保持
            if (partsInfoDB != null)
            {
                SetResultMap.Add(scmOrderDetailRecord.ToKey(), (PartsInfoDataSet)partsInfoDB.Copy()); // ADD 2011/08/10
                ResultMap.Add(
                    scmOrderDetailRecord.ToKey(),
                    new SCMSearchedResult(
                        scmOrderDetailRecord,
                        RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind, // ADD 2011/08/10
                        status,             // 2011/01/11 Add
                        // --- UPD 三戸 2012/08/15 ---------->>>>>
                        //partsInfoDB,
                        (PartsInfoDataSet)partsInfoDB.CopyForSCM(),
                        // --- UPD 三戸 2012/08/15 ----------<<<<<
                        goodsUnitDataList ?? new List<GoodsUnitData>(),
                        SCMSearchedResult.GoodsSearchDivCd.GoodsNo,
                    //null // 2010/04/21
                    // 2011/02/09 >>>
                    //null, // 2010/04/21
                        searchedCarInfo,
                    // 2011/02/09 <<<
                        false // 2010/04/21
                    )
                );
                // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応---------->>>>>
                // 倉庫情報リストをクリア
                SCMSearcher.warehouseInfoList = new List<SCMSearcher.WarehouseInfo>();
                // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応----------<<<<<
            }

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecordList">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        /// <br>Update Note : 2024/04/23 陳艶丹</br>
        /// <br>管理番号    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4350 BLP不具合対応 得意先設定と異なる倉庫コードが回答される</br>
        protected int SearchByGoodsNo(List<SCMOrderDetailRecordType> scmOrderDetailRecordList)
        {
            #region <車両検索>

            // 車両検索を開始
            string carKey = scmOrderDetailRecordList[0].ToCarKey();
            if (!CarRecordMap.ContainsKey(carKey))
            {
                Debug.Assert(false, "明細に対応する車両情報が無い？");
                return (int)ResultUtil.ResultCode.Abort;
            }

            // 車両情報の検索結果
            CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;
            PMKEN01010E searchedCarInfo = null;

            if (!SearchedResultAndCarInfoMap.ContainsKey(carKey))
            {
                // 1パラ目：検索条件
                CarSearchCondition searchingCarCondition = CreateSearchingCarCondition(
                    CarRecordMap[carKey]
                );

                //>>>2012/06/24
                if (searchingCarCondition.ModelDesignationNo == 0 &&             // 型式指定番号
                    searchingCarCondition.CategoryNo == 0 &&                     // 類別区分番号
                    searchingCarCondition.CarModel.FullModel == string.Empty)    // 型式(フル型)
                {
                    // 車両検索の条件が無いので、車両検索しない
                    searchedCarResult = CarSearchResultReport.retFailed;
                    searchedCarInfo = new PMKEN01010E();
                }
                else
                {
                    //<<<2012/06/24

                    // 2パラ目：検索結果
                    searchedCarInfo = new PMKEN01010E();

                    if (this.CheckCarSearchCondition(searchingCarCondition))
                    {
                        // 車両検索
                        searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                        if (searchedCarInfo != null)
                        {
                            for (int i = 0; i < searchedCarInfo.CategoryEquipmentInfo.Count; i++)
                            {
                                Debug.WriteLine(string.Format("\t車両検索結果：BLコード[{0}] = {1}", i, searchedCarInfo.CategoryEquipmentInfo[i].TbsPartsCode));
                            }
                        }

                        // 検索結果を保持 ∵1問合せで車両は同じであるため、同じ車両検索を何度も行わない
                        if (searchedCarInfo != null)
                        {
                            // UPD 2015/07/21 商品保証課Redmine#4334対応 ---------------------------------------->>>>>
                            //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
                            //    searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                            //{
                            //    if (searchedCarInfo.CarKindInfo != null &&
                            //        searchedCarInfo.CarKindInfo.Count > 0)
                            //    {
                            //        searchedCarInfo.CarKindInfo[0].SelectionState = true;
                            //        searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                            //    }
                            //}
                            // 複数車種の時、単一車種を特定する
                            if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                            {
                                if (searchedCarInfo.CarKindInfo != null &&
                                    searchedCarInfo.CarKindInfo.Count > 0)
                                {
                                    if (searchingCarCondition.ModelCode != 0 || searchingCarCondition.ModelSubCode != 0)
                                    {
                                        for (int iCnt = 0; iCnt < searchedCarInfo.CarKindInfo.Count; iCnt++)
                                        {
                                            if (searchedCarInfo.CarKindInfo[iCnt].ModelCode == searchingCarCondition.ModelCode &&
                                                searchedCarInfo.CarKindInfo[iCnt].ModelSubCode == searchingCarCondition.ModelSubCode)
                                            {
                                                searchedCarInfo.CarKindInfo[iCnt].SelectionState = true;
                                                break;
                                            }
                                        }
                                    }
                                    searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                                }
                            }

                            // 車種確定時(検索結果が複数車種の場合は先頭車種)
                            if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel) ||
                                searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel))
                            {
                                // 外車(DomesticForeignCode=2)の場合、車台番号(VINｺｰﾄﾞ)を設定
                                if (searchedCarInfo.CarModelUIData[0].DomesticForeignCode == 2)
                                {
                                    searchedCarInfo.CarModelUIData[0].FrameNo = CarRecordMap[carKey].FrameNo;
                                }
                            }
                            // UPD 2015/07/21 商品保証課Redmine#4334対応 ----------------------------------------<<<<<

                            if (searchedCarInfo != null)
                            {
                                SearchedResultAndCarInfoMap.Add(
                                    carKey,
                                    new KeyValuePair<CarSearchResultReport, PMKEN01010E>(searchedCarResult, searchedCarInfo)
                                );
                            } 
                        }
                    }
                    else
                    {
                        searchedCarResult = CarSearchResultReport.retFailed;
                    }
                } 
            }
            else
            {
                searchedCarResult = SearchedResultAndCarInfoMap[carKey].Key;
                searchedCarInfo = SearchedResultAndCarInfoMap[carKey].Value;
            }

            CurrentCarInfo = searchedCarInfo;

            #endregion // </車両検索>

            // SCMの場合
            if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
            {
                // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
                if (
                    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retFailed)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                )
                {
                    return (int)ResultUtil.ResultCode.Abort;
                }
            }
            // PCCUOEの場合
            else
            {
                // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
                if (
                    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retFailed)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind)
                )
                {
                    return (int)ResultUtil.ResultCode.Abort;
                }
            }

            // 1パラ目：検索条件
            List<GoodsCndtn> searchingConditionList = EditSearchingGoodsCondition(
                CreateSearchingGoodsCondition(scmOrderDetailRecordList)
            );

            // 2パラ目：部品情報
            List<PartsInfoDataSet> partsInfoDBList = null;

            // 3パラ目：商品連結データ
            List<List<GoodsUnitData>> goodsUnitDataList = null;

            // 4パラ目：メッセージ
            string msg = string.Empty;

            EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "品番検索 開始");    // 2010/03/17 Add
            // 品番検索
            int status = SearchPartsFromGoodsNo(
                searchingConditionList,
                out partsInfoDBList,
                out goodsUnitDataList,
                out msg
            );
            EasyLogger.Write(MY_NAME, "SearchByGoodsNo", "品番検索 終了");   

            // 検索結果を保持
            if (partsInfoDBList != null && partsInfoDBList.Count != 0)
            {
                for (int i = 0; i < partsInfoDBList.Count; i++)
                {
                    PartsInfoDataSet partsInfoDB = partsInfoDBList[i];
                    // UPD 2014/04/16 SCM自動回答速度改善 ｼｽﾃﾑﾃｽﾄ障害№74対応 ------------------------------->>>>>
                    //List<GoodsUnitData> goodsUnitDataListTemp = goodsUnitDataList[i];
                    List<GoodsUnitData> goodsUnitDataListTemp;
                    if (goodsUnitDataList != null && goodsUnitDataList.Count != 0)
                    {
                        goodsUnitDataListTemp = goodsUnitDataList[i];
                    }
                    else
                    {
                        goodsUnitDataListTemp = new List<GoodsUnitData>();
                    }
                    // UPD 2014/04/16 SCM自動回答速度改善 ｼｽﾃﾑﾃｽﾄ障害№74対応 -------------------------------<<<<<
                    ISCMOrderDetailRecord scmOrderDetailRecord = scmOrderDetailRecordList[i];
                    // 検索結果がない時はステータスを検索異常に設定
                    if (goodsUnitDataListTemp.Count == 0)
                    {
                        status = 1;
                    }
                    else
                    {
                        status = 0;
                    }

                    SetResultMap.Add(scmOrderDetailRecord.ToKey(), (PartsInfoDataSet)partsInfoDB.Copy());
                    ResultMap.Add(
                        scmOrderDetailRecord.ToKey(),
                        new SCMSearchedResult(
                            scmOrderDetailRecord,
                            RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind,
                            status,
                            (PartsInfoDataSet)partsInfoDB.CopyForSCM(),
                            goodsUnitDataListTemp ?? new List<GoodsUnitData>(),
                            SCMSearchedResult.GoodsSearchDivCd.GoodsNo,
                            searchedCarInfo,
                            false
                        )
                    );
                }
                // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応---------->>>>>
                // 倉庫情報リストをクリア
                SCMSearcher.warehouseInfoList = new List<SCMSearcher.WarehouseInfo>();
                // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応----------<<<<<
            }

            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>
        /// 車輌検索条件設定チェック処理
        /// </summary>
        /// <param name="searchingCarCondition"></param>
        /// <returns>true: 設定あり, false: 未設定</returns>
        private bool CheckCarSearchCondition( CarSearchCondition searchingCarCondition )
        {
            return (searchingCarCondition.ModelDesignationNo != 0 ||
                    searchingCarCondition.CategoryNo != 0 ||
                    searchingCarCondition.EngineModel.FullModel != string.Empty ||
                    searchingCarCondition.EngineModel.Model != string.Empty ||
                    searchingCarCondition.CarModel.CategorySign != string.Empty ||
                    searchingCarCondition.CarModel.SeriesModel != string.Empty ||
                    searchingCarCondition.CarModel.ExhaustGasSign != string.Empty ||
                    searchingCarCondition.CarModel.FullModel != string.Empty ||
                    searchingCarCondition.MakerCode != 0 ||
                    searchingCarCondition.ModelCode != 0 ||
                    searchingCarCondition.ModelSubCode != 0);
        }
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

        #region <検索条件>

        /// <summary>
        /// 品番検索条件を生成します。(品番がない場合、BLコードおよびBLコード枝番を指定します)
        /// </summary>
        /// <remarks>
        /// 売上伝票入力(MAHNB01012AB.cs::SalesSlipInputAcs.SearchPartsFromGoodsNo())を参考
        /// </remarks>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>品番検索条件</returns>
        protected GoodsCndtn CreateSearchingGoodsCondition(ISCMOrderDetailRecord detailRecord)
        {
            return CreateSearchingGoodsCondition(detailRecord, null);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索条件を生成します。(品番がない場合、BLコードおよびBLコード枝番を指定します)
        /// </summary>
        /// <param name="detailRecordList">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>品番検索条件</returns>
        protected List<GoodsCndtn> CreateSearchingGoodsCondition(List<ISCMOrderDetailRecord> detailRecordList)
        {
            return CreateSearchingGoodsCondition(detailRecordList, null);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// セット品番検索条件を生成します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="GoodsNo">品番</param>
        /// <param name="GoodsMakerCd">商品メーカーコード</param>
        /// <returns>品番検索条件</returns>
        protected GoodsCndtn CreateSetSearchingGoodsCondition(ISCMOrderDetailRecord detailRecord, string GoodsNo, int GoodsMakerCd)
        {
            return CreateSetSearchingGoodsCondition(detailRecord, null, GoodsMakerCd, GoodsNo);
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        /// <summary>
        /// 品番検索条件を生成します。(品番がない場合、BLコードおよびBLコード枝番を指定します)
        /// </summary>
        /// <remarks>
        /// 売上伝票入力(MAHNB01012AB.cs::SalesSlipInputAcs.SearchPartsFromGoodsNo())を参考
        /// </remarks>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="searchedCarInfo">車両検索結果</param>
        /// <returns>品番検索条件</returns>
        /// <remarks>
        /// <br>Update Note : 2018/04/16 田建委</br>
        /// <br>管理番号    : 11470007-00</br>
        /// <br>            : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        protected GoodsCndtn CreateSearchingGoodsCondition(
            ISCMOrderDetailRecord detailRecord,
            PMKEN01010E searchedCarInfo
        )
        {
            GoodsCndtn condition = new GoodsCndtn();
            {
                // 企業コード
                condition.EnterpriseCode = detailRecord.InqOtherEpCd;

                // 拠点コード
                condition.SectionCode = detailRecord.InqOtherSecCd;

                // 商品メーカーコード
                condition.GoodsMakerCd = detailRecord.GoodsMakerCd;

                // 商品番号
                condition.GoodsNo = detailRecord.GoodsNo;
                {
                    // 品番がない場合、BLコードおよびBLコード枝番を指定
                    if (string.IsNullOrEmpty(detailRecord.GoodsNo.Trim()))
                    {
                        // BLコード
                        condition.BLGoodsCode = detailRecord.BLGoodsCode;

                        // BLコード枝番
#if _LOCAL_DEBUG_
#else
                        condition.BLGoodsCode = detailRecord.BLGoodsDrCode;
#endif
                        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                        condition.BLGoodsDrCode = detailRecord.BLGoodsDrCode;
                        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

                        AddSearchingGoodsCondition(detailRecord, ref condition);// ADD 2018/04/16 田建委 新BLコード対応 
                    }
                }

                // 売上全体設定を取得
                SalesTtlSt salesTtlSt = SalesTtlStDB.Find(detailRecord.InqOtherEpCd, detailRecord.InqOtherSecCd);
                if (salesTtlSt != null)
                {
                    // 代替条件区分…0:代替しない, 1:代替する(在庫無), 2:代替する(在庫無視) エントリからの部品検索時のみ有効
                    condition.SubstCondDivCd = salesTtlSt.SubstCondDivCd;

                    // 優良代替条件区分…0:しない, 1:する(結合、セット), 2:全て(結合、セット、純正） エントリからの部品検索時のみ有効
                    condition.PrmSubstCondDivCd = salesTtlSt.PrmSubstCondDivCd;

                    // 代替適用区分…0:しない, 1:する(結合、セット), 2:全て(結合、セット、純正) エントリからの部品検索時のみ有効
                    condition.SubstApplyDivCd = salesTtlSt.SubstApplyDivCd;

                    // 部品検索優先順区分…0:純正, 1:優良
                    condition.PartsSearchPriDivCd = salesTtlSt.PartsSearchPriDivCd;

                    // 結合初期表示区分…0:表示順, 1:在庫順
                    condition.JoinInitDispDiv = salesTtlSt.JoinInitDispDiv;
                }

                // 検索画面制御区分…0:PM7, 1:PM.NS エントリからの部品検索時のみ有効
                condition.SearchUICntDivCd = 1; // 自動は1 手動は引数あり 

                // エンターキー処理区分…0:PM7(セットのみ), 1:選択, 2:次画面 エントリからの部品検索時のみ有効
                condition.EnterProcDivCd = 0;   // 自動は0 手動は引数あり

                // 品番検索区分…0:PM7(セットのみ), 1:結合・セット・代替あり エントリからの部品検索時のみ有効
                condition.PartsNoSearchDivCd = 1;   // 自動は1 手動は引数あり

                // ↑0のとき有効
                // 品番結合制御区分…初期値"." エントリからの部品検索時のみ有効
                //cndtn.PartsJoinCntDivCd = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;

                // 元号表示区分1…0:西暦, 1:和暦(年式) エントリからの部品検索時のみ有効
                condition.EraNameDispCd1 = 0;

                // 価格適用日
                condition.PriceApplyDate = GetInquiryDate(detailRecord);    // 問合せ日

                // 仕入先情報取得区分…0:設定あり, 設定なし
                condition.IsSettingSupplier = 0;

                // 結合検索区分…0:結合検索なし, 1:結合検索あり
                condition.JoinSearchDiv = 1;

                // 車両検索結果…BLコード検索時のみ使用
                condition.SearchCarInfo = searchedCarInfo;

            }

            return condition;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索条件を生成します。(品番がない場合、BLコードおよびBLコード枝番を指定します)
        /// </summary>
        /// <param name="detailRecordList">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="searchedCarInfo">車両検索結果</param>
        /// <returns>品番検索条件</returns>
        protected List<GoodsCndtn> CreateSearchingGoodsCondition(
            List<ISCMOrderDetailRecord> detailRecordList,
            PMKEN01010E searchedCarInfo
        )
        {
            List<GoodsCndtn> conditionList = new List<GoodsCndtn>();

            foreach (ISCMOrderDetailRecord detailRecord in detailRecordList)
            {
                conditionList.Add(CreateSearchingGoodsCondition(detailRecord, searchedCarInfo));
            }

            return conditionList;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// セット品番検索条件を生成します。
        /// </summary>
        /// <remarks>
        /// 売上伝票入力(MAHNB01012AB.cs::SalesSlipInputAcs.SearchPartsFromGoodsNo())を参考
        /// </remarks>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="searchedCarInfo">車両検索結果</param>
        /// <param name="GoodsMakerCd">MakerCd</param>
        /// <param name="GoodsNo">品番</param>
        /// <returns>品番検索条件</returns>
        protected GoodsCndtn CreateSetSearchingGoodsCondition(
            ISCMOrderDetailRecord detailRecord,
            PMKEN01010E searchedCarInfo,
            int GoodsMakerCd,
            string GoodsNo
        )
        {
            GoodsCndtn condition = new GoodsCndtn();
            {
                // 企業コード
                condition.EnterpriseCode = detailRecord.InqOtherEpCd;

                // 拠点コード
                condition.SectionCode = detailRecord.InqOtherSecCd;

                // 商品メーカーコード
                condition.GoodsMakerCd = GoodsMakerCd;

                // 商品番号
                condition.GoodsNo = GoodsNo;

                // 売上全体設定を取得
                SalesTtlSt salesTtlSt = SalesTtlStDB.Find(detailRecord.InqOtherEpCd, detailRecord.InqOtherSecCd);
                if (salesTtlSt != null)
                {
                    // 代替条件区分…0:代替しない, 1:代替する(在庫無), 2:代替する(在庫無視) エントリからの部品検索時のみ有効
                    condition.SubstCondDivCd = salesTtlSt.SubstCondDivCd;

                    // 優良代替条件区分…0:しない, 1:する(結合、セット), 2:全て(結合、セット、純正） エントリからの部品検索時のみ有効
                    condition.PrmSubstCondDivCd = salesTtlSt.PrmSubstCondDivCd;

                    // 代替適用区分…0:しない, 1:する(結合、セット), 2:全て(結合、セット、純正) エントリからの部品検索時のみ有効
                    condition.SubstApplyDivCd = salesTtlSt.SubstApplyDivCd;

                    // 部品検索優先順区分…0:純正, 1:優良
                    condition.PartsSearchPriDivCd = salesTtlSt.PartsSearchPriDivCd;

                    // 結合初期表示区分…0:表示順, 1:在庫順
                    condition.JoinInitDispDiv = salesTtlSt.JoinInitDispDiv;
                }

                // 検索画面制御区分…0:PM7, 1:PM.NS エントリからの部品検索時のみ有効
                condition.SearchUICntDivCd = 1; // 自動は1 手動は引数あり 

                // エンターキー処理区分…0:PM7(セットのみ), 1:選択, 2:次画面 エントリからの部品検索時のみ有効
                condition.EnterProcDivCd = 0;   // 自動は0 手動は引数あり

                // 品番検索区分…0:PM7(セットのみ), 1:結合・セット・代替あり エントリからの部品検索時のみ有効
                condition.PartsNoSearchDivCd = 1;   // 自動は1 手動は引数あり

                // ↑0のとき有効
                // 品番結合制御区分…初期値"." エントリからの部品検索時のみ有効
                //cndtn.PartsJoinCntDivCd = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;

                // 元号表示区分1…0:西暦, 1:和暦(年式) エントリからの部品検索時のみ有効
                condition.EraNameDispCd1 = 0;

                // 価格適用日
                condition.PriceApplyDate = GetInquiryDate(detailRecord);    // 問合せ日

                // 仕入先情報取得区分…0:設定あり, 設定なし
                condition.IsSettingSupplier = 0;

                // 結合検索区分…0:結合検索なし, 1:結合検索あり
                condition.JoinSearchDiv = 1;

                // 車両検索結果…BLコード検索時のみ使用
                condition.SearchCarInfo = searchedCarInfo;

            }

            // ----- ADD 2011/08/10 ----- >>>>>
            // PCCUOEの場合
            if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            {
                // 品名
                condition.GoodsName = detailRecord.InqGoodsName;
            }
            // ----- ADD 2011/08/10 ----- <<<<<
            return condition;
        }
        // -- ADD 2011/08/10   ------ <<<<<<
        #endregion // </検索条件>

        #region <Virtual>

        /// <summary>
        /// 品番検索条件を編集します。
        /// </summary>
        /// <param name="searchingCondition">品番検索条件</param>
        /// <returns>編集した品番検索条件</returns>
        protected virtual GoodsCndtn EditSearchingGoodsCondition(GoodsCndtn searchingCondition)
        {
            return searchingCondition;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索条件を編集します。
        /// </summary>
        /// <param name="searchingConditionList">品番検索条件</param>
        /// <returns>編集した品番検索条件</returns>
        protected virtual List<GoodsCndtn> EditSearchingGoodsCondition(List<GoodsCndtn> searchingConditionList)
        {
            return searchingConditionList;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>
        /// <summary>
        /// BLコード検索条件を編集します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="condition">BLコード検索条件</param>
        /// <remarks>
        /// <br>Note        : 2018/04/16 田建委</br>
        /// <br>管理番号    : 11470007-00</br>
        /// <br>            : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        protected virtual void AddSearchingGoodsCondition(ISCMOrderDetailRecord detailRecord, ref GoodsCndtn condition)
        {
            //実処理は派生クラスにて実装する前提
        }
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<

        /// <summary>
        /// 品番検索アクセサを用いて品番検索を行います。
        /// </summary>
        /// <param name="searchingCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        protected abstract int SearchPartsFromGoodsNo(
            GoodsCndtn searchingCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        );

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索アクセサを用いて品番検索を行います。
        /// </summary>
        /// <param name="searchingCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        protected abstract int SearchPartsFromGoodsNo(
            List<GoodsCndtn> searchingCondition,
            out List<PartsInfoDataSet> partsInfoDB,
            out List<List<GoodsUnitData>> goodsUnitDataList,
            out string msg
        );
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        #endregion // </Virtual>

        #endregion // </品番検索>

        #region <車両検索→BL検索>

        #region <検索済み車両情報>

        /// <summary>車両情報の検索結果マップ</summary>
        private IDictionary<string, KeyValuePair<CarSearchResultReport, PMKEN01010E>> _searchedResultAndCarInfoMap;
        /// <summary>車両情報の検索結果マップを取得します。</summary>
        private IDictionary<string, KeyValuePair<CarSearchResultReport, PMKEN01010E>> SearchedResultAndCarInfoMap
        {
            get
            {
                if (_searchedResultAndCarInfoMap == null)
                {
                    _searchedResultAndCarInfoMap = new Dictionary<string, KeyValuePair<CarSearchResultReport, PMKEN01010E>>();
                }
                return _searchedResultAndCarInfoMap;
            }
        }

        /// <summary>現在の車両情報</summary>
        private PMKEN01010E _currentCarInfo;
        /// <summary>現在の車両情報を取得または設定します。</summary>
        /// <remarks>SCMManualSearcherとの情報共有用</remarks>
        //[Obsolete("あまり良い設計ではないので、要検討")]
        protected PMKEN01010E CurrentCarInfo
        {
            get { return _currentCarInfo; }
            set { _currentCarInfo = value; }
        }

        #endregion // </検索済み車両情報>

        /// <summary>
        /// 車両検索→BL検索を行います。
        /// </summary>
        /// <remarks>
        /// 売上伝票入力(MAHNB01012UA.cs::MAHNB01010UA.CarSearch())を参考
        /// </remarks>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>結果コード</returns>
        /// <br>Update Note : 2024/04/23 陳艶丹</br>
        /// <br>管理番号    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4350 BLP不具合対応 得意先設定と異なる倉庫コードが回答される</br>
        protected int SearchByCarAndBLCode(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            // CarSearchController.Search()→GoodsAcs.SearchPartsFromBLCode()→検索結果を保持
            Debug.WriteLine("検索処理が車両検索→BL検索を行います。");

            #region <車両検索>

            // 車両検索を開始
            string carKey = scmOrderDetailRecord.ToCarKey();
            if (!CarRecordMap.ContainsKey(carKey))
            {
                Debug.Assert(false, "明細に対応する車両情報が無い？");
                return (int)ResultUtil.ResultCode.Abort;
            }

            // 車両情報の検索結果
            CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;
            PMKEN01010E searchedCarInfo = null;

            if (!SearchedResultAndCarInfoMap.ContainsKey(carKey))
            {
                // 1パラ目：検索条件
                CarSearchCondition searchingCarCondition = CreateSearchingCarCondition(
                    CarRecordMap[carKey]
                );

                // 2012/06/21 ADD T.Yoshioka システムテスト障害№117 ------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (searchingCarCondition.ModelDesignationNo == 0 &&             // 型式指定番号
                    searchingCarCondition.CategoryNo == 0 &&                     // 類別区分番号
                    searchingCarCondition.CarModel.FullModel == string.Empty)    // 型式(フル型)
                {
                    // 車両検索の条件が無いので、車両検索しない
                    searchedCarResult = CarSearchResultReport.retFailed;
                    searchedCarInfo = new PMKEN01010E();
                }
                else
                {
                // 2012/06/21 ADD T.Yoshioka システムテスト障害№117 -------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 2パラ目：検索結果
                    searchedCarInfo = new PMKEN01010E();

                    // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                    if (this.CheckCarSearchCondition(searchingCarCondition))
                    {
                        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

                        // 車両検索
                        // 2011/03/08 >>>
                        //searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                        EasyLogger.Write(MY_NAME, "SearchByCarAndBLCode", "車両検索1 開始" + "パラメータ:" + GetCarSearchCondition(searchingCarCondition));  // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                        searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                        EasyLogger.Write(MY_NAME, "SearchByCarAndBLCode", "車両検索1 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                        // 2011/03/08 <<<
                        // DEL 2013/07/16 T.Miyamoto ------------------------------>>>>>
                        //// ADD 2013/04/05 吉岡 2013/05/22配信 SCM障害№50 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //// 外車(DomesticForeignCode=2)の場合、車台番号(VINｺｰﾄﾞ)を設定
                        //if (searchedCarInfo.CarModelUIData != null &&
                        //    // ADD 2013/06/06 吉岡 2013/06/18配信 システム障害№29 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //    searchedCarInfo.CarModelUIData.Count > 0 &&
                        //    // ADD 2013/06/06 吉岡 2013/06/18配信 システム障害№29 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        //    searchedCarInfo.CarModelUIData[0].DomesticForeignCode == 2)
                        //{
                        //    searchedCarInfo.CarModelUIData[0].FrameNo = CarRecordMap[carKey].FrameNo;
                        //}
                        //// ADD 2013/04/05 吉岡 2013/05/22配信 SCM障害№50 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // DEL 2013/07/16 T.Miyamoto ------------------------------<<<<<

                        if (searchedCarInfo != null)
                        {
                            for (int i = 0; i < searchedCarInfo.CategoryEquipmentInfo.Count; i++)
                            {
                                Debug.WriteLine(string.Format("\t車両検索結果：BLコード[{0}] = {1}", i, searchedCarInfo.CategoryEquipmentInfo[i].TbsPartsCode));
                            }
                        }

                        // 検索結果を保持 ∵1問合せで車両は同じであるため、同じ車両検索を何度も行わない
                        if (searchedCarInfo != null)
                        {
                            // 2011/03/08 Del 絞込み等は、各Searcherで行う >>>
                            //// 2010/03/17 Add >>>

                            //// 年式の絞込み
                            //if (CarRecordMap[carKey].ProduceTypeOfYearNum != 0)
                            //{
                            //    PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchedCarInfo.CarModelInfoSummarized; // 型式情報要約テーブル

                            //    int stDate = ( ( ( carModelInfoDataTable[0].StProduceTypeOfYear / 100 ) == 9999 ) || ( ( carModelInfoDataTable[0].StProduceTypeOfYear % 100 ) == 99 ) ) ? 0 : carModelInfoDataTable[0].StProduceTypeOfYear;
                            //    int edDate = ( ( ( carModelInfoDataTable[0].EdProduceTypeOfYear / 100 ) == 9999 ) || ( ( carModelInfoDataTable[0].EdProduceTypeOfYear % 100 ) == 99 ) ) ? 0 : carModelInfoDataTable[0].EdProduceTypeOfYear;

                            //    if (stDate != 0 || edDate != 0)
                            //    {
                            //        edDate = ( edDate == 0 ) ? 999999 : edDate;

                            //        if (stDate <= CarRecordMap[carKey].ProduceTypeOfYearNum && CarRecordMap[carKey].ProduceTypeOfYearNum <= edDate)
                            //        {
                            //            searchedCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = CarRecordMap[carKey].ProduceTypeOfYearNum;
                            //        }
                            //    }
                            //}

                            //// カラーの絞込み
                            //if (!string.IsNullOrEmpty(CarRecordMap[carKey].RpColorCode))
                            //{
                            //    PMKEN01010E.ColorCdInfoRow[] colorRows = (PMKEN01010E.ColorCdInfoRow[])searchedCarInfo.ColorCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.ColorCdInfo.ColorCodeColumn.ColumnName, CarRecordMap[carKey].RpColorCode));
                            //    if (colorRows.Length > 0)
                            //    {
                            //        colorRows[0].SelectionState = true;
                            //    }
                            //}

                            //// トリムの絞込み
                            //if (!string.IsNullOrEmpty(CarRecordMap[carKey].TrimCode))
                            //{
                            //    PMKEN01010E.TrimCdInfoRow[] trimRows = (PMKEN01010E.TrimCdInfoRow[])searchedCarInfo.TrimCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.TrimCdInfo.TrimCodeColumn.ColumnName, CarRecordMap[carKey].TrimCode));
                            //    if (trimRows.Length > 0)
                            //    {
                            //        trimRows[0].SelectionState = true;
                            //    }
                            //}
                            //// 2010/03/17 Add <<<
                            // 2011/03/08 Del <<<

                            // ----- ADD 2011/09/20 ----- >>>>>
                            // UPD 2013/08/02 T.Miyamoto ------------------------------>>>>>
                            //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
                            //    searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                            if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                            // UPD 2013/08/02 T.Miyamoto ------------------------------<<<<<
                            {
                                if (searchedCarInfo.CarKindInfo != null &&
                                    searchedCarInfo.CarKindInfo.Count > 0)
                                {
                                    // --- UPD 2013/08/09 Y.Wakita ---------->>>>>
                                    //searchedCarInfo.CarKindInfo[0].SelectionState = true;
                                    if (searchingCarCondition.ModelCode != 0 || searchingCarCondition.ModelSubCode != 0)
                                    {
                                        for (int iCnt = 0; iCnt < searchedCarInfo.CarKindInfo.Count; iCnt++)
                                        {
                                            if (searchedCarInfo.CarKindInfo[iCnt].ModelCode == searchingCarCondition.ModelCode &&
                                                searchedCarInfo.CarKindInfo[iCnt].ModelSubCode == searchingCarCondition.ModelSubCode)
                                            {
                                                searchedCarInfo.CarKindInfo[iCnt].SelectionState = true;
                                                break;
                                            }
                                        }
                                    }
                                    // --- UPD 2013/08/09 Y.Wakita ----------<<<<<
                                    EasyLogger.Write(MY_NAME, "SearchByCarAndBLCode", "車両検索2 開始" + "パラメータ:" + GetCarSearchCondition(searchingCarCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                    searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                                    EasyLogger.Write(MY_NAME, "SearchByCarAndBLCode", "車両検索2 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                }
                            }

                            // ADD 2013/07/16 T.Miyamoto ------------------------------>>>>>
                            // 車種確定時(検索結果が複数車種の場合は先頭車種)
                            if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel) ||
                                searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel))
                            {
                                // 外車(DomesticForeignCode=2)の場合、車台番号(VINｺｰﾄﾞ)を設定
                                if (searchedCarInfo.CarModelUIData[0].DomesticForeignCode == 2)
                                {
                                    searchedCarInfo.CarModelUIData[0].FrameNo = CarRecordMap[carKey].FrameNo;
                                }
                            }
                            // ADD 2013/07/16 T.Miyamoto ------------------------------<<<<<

                            if (searchedCarInfo != null)
                            {
                                // ----- ADD 2011/09/20 ----- <<<<<
                                SearchedResultAndCarInfoMap.Add(
                                    carKey,
                                    new KeyValuePair<CarSearchResultReport, PMKEN01010E>(searchedCarResult, searchedCarInfo)
                                );
                            } // ADD 2011/09/20
                        }
                        // --- ADD m.suzuki 2011/05/23 ---------->>>>>

                    }
                    else
                    {
                        searchedCarResult = CarSearchResultReport.retFailed;
                    }
                    // --- ADD m.suzuki 2011/05/23 ----------<<<<<
                // 2012/06/21 ADD T.Yoshioka システムテスト障害№117 ------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                }
                // 2012/06/21 ADD T.Yoshioka システムテスト障害№117 -------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            else
            {
                searchedCarResult = SearchedResultAndCarInfoMap[carKey].Key;
                searchedCarInfo = SearchedResultAndCarInfoMap[carKey].Value;
            }

            CurrentCarInfo = searchedCarInfo;

            #endregion // </車両検索>

            // ----- UPD 2011/08/10 ----- >>>>>
            //// 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
            //if (
            //    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
            //    // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            //        &&
            //    !searchedCarResult.Equals(CarSearchResultReport.retFailed) // 検索結果0件も許可する
            //    // --- ADD m.suzuki 2011/05/23 ----------<<<<<
            //        &&
            //    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
            //)
            //{
            //    return (int)ResultUtil.ResultCode.Abort;
            //}

            
            // PCCUOEの場合
            if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            {
                // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
                if (
                    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retFailed) // 検索結果0件も許可する
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind)
                )
                {
                    return (int)ResultUtil.ResultCode.Abort;
                }
            }
            else
            // SCMの場合
            {
                // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
                if (
                    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retFailed) // 検索結果0件も許可する
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                )
                {
                    return (int)ResultUtil.ResultCode.Abort;
                }
            }


            // ----- UPD 2011/08/10 ----- <<<<<

            #region <BL検索>

            // 検索結果が1件であれば、BL検索を開始
            // 1パラ目：検索条件
            GoodsCndtn searchingGoodsCondition = EditSearchingGoodsCondition(
                CreateSearchingGoodsCondition(scmOrderDetailRecord, searchedCarInfo)
            );

            // ----- DEL 2011/09/20 ----- >>>>>
            //// ----- ADD 2011/08/10 ----- >>>>>
            //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE && searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
            //{
            //    searchingGoodsCondition.SearchCarInfo.CarModelUIData.Clear();
            //}
            //// ----- ADD 2011/08/10 ----- <<<<<
            // ----- DEL 2011/09/20 ----- <<<<<

            // 2パラ目：部品情報
            PartsInfoDataSet partsInfoDB = null;

            // 3パラ目：商品連結データ
            List<GoodsUnitData> goodsUnitDataList = null;

            // 4パラ目：メッセージ
            string msg = string.Empty;

            // --- UPD m.suzuki 2011/05/23 ---------->>>>> // 車輌情報なし・BLコードあり・品番なしのパターンだと、検索処理内部でエラー発生する為、暫定対応でcatchします。
            //// BL検索
            //int status = SearchPartsFromBLCode(
            //    searchingGoodsCondition,
            //    out partsInfoDB,
            //    out goodsUnitDataList,
            //    out msg
            //);

            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 車輌データあり⇒BLコード検索
                // BL検索
                // UPD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //status = SearchPartsFromBLCode(
                //    searchingGoodsCondition,
                //    out partsInfoDB,
                //    out goodsUnitDataList,
                //    out msg
                //);
                #endregion
                EasyLogger.Write(MY_NAME, "SearchByCarAndBLCode", "BL検索 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                status = SearchPartsFromBLCodeCarInfo(
                    searchingGoodsCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out msg,
                    searchedCarInfo
                );
                EasyLogger.Write(MY_NAME, "SearchByCarAndBLCode", "BL検索 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                // UPD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            catch
            {
            }
            // --- UPD m.suzuki 2011/05/23 ----------<<<<<

            #endregion // </BL検索>

            // 検索結果を保持
            if (partsInfoDB != null)
            {

                // 2011/01/11 Add >>>
                GetGoodsUnitDataList(status, scmOrderDetailRecord, ref goodsUnitDataList);
                // 2011/01/11 Add <<<
                Debug.WriteLine("明細キー：" + scmOrderDetailRecord.ToKey() + ", BLコード：" + scmOrderDetailRecord.BLGoodsCode.ToString());
                SetResultMap.Add(scmOrderDetailRecord.ToKey(), (PartsInfoDataSet)partsInfoDB.Copy()); // ADD 2011/08/10
                //>>>2012/01/04
                //ResultMap.Add(
                //    scmOrderDetailRecord.ToKey(),
                //    new SCMSearchedResult(
                //        scmOrderDetailRecord,
                //        RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind, // ADD 2011/08/10
                //        status,         // 2011/01/11 Add
                //    partsInfoDB, // 2012/01/04
                //    //(PartsInfoDataSet)partsInfoDB.Copy(), // 2012/01/04 // 別インスタンスにする 同じインスタンスになっている為、検索が動作する度に最後の検索結果が有効になる
                //    // 2011/01/11 >>>
                //    //goodsUnitDataList ?? new List<GoodsUnitData>(),
                //        goodsUnitDataList,
                //    // 2011/01/11 <<<
                //        SCMSearchedResult.GoodsSearchDivCd.BLCode,
                //    //searchedCarInfo // 2010/04/21
                //        searchedCarInfo, // 2010/04/21
                //        true // 2010/04/21
                //    )
                //);
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                #region 削除(SCM改良の為)
                //if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                //{
                //    ResultMap.Add(
                //        scmOrderDetailRecord.ToKey(),
                //        new SCMSearchedResult(
                //            scmOrderDetailRecord,
                //            RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind, // ADD 2011/08/10
                //            status,         // 2011/01/11 Add
                //            //>>>2012/04/09
                //            //(PartsInfoDataSet)partsInfoDB.Copy(), // 別インスタンスにする 同じインスタンスになっている為、検索が動作する度に最後の検索結果が有効になる
                //            (PartsInfoDataSet)partsInfoDB.CopyForSCM(), // SCM専用メソッドを使用
                //            //<<<2012/04/09
                //        // 2011/01/11 >>>
                //        //goodsUnitDataList ?? new List<GoodsUnitData>(),
                //            goodsUnitDataList,
                //        // 2011/01/11 <<<
                //            SCMSearchedResult.GoodsSearchDivCd.BLCode,
                //        //searchedCarInfo // 2010/04/21
                //            searchedCarInfo, // 2010/04/21
                //            true // 2010/04/21
                //        )
                //    );
                //}
                //else
                //{
                #endregion
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                    ResultMap.Add(
                        scmOrderDetailRecord.ToKey(),
                        new SCMSearchedResult(
                            scmOrderDetailRecord,
                            RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind, // ADD 2011/08/10
                            status,         // 2011/01/11 Add
                        // 2012/07/30 UPD T.Yoshioka 2012/08/07配信障害№128 --------->>>>>>>>>>>>>>>>>>>>>>>
                            (PartsInfoDataSet)partsInfoDB.CopyForSCM(),
                            // partsInfoDB,
                        // 2012/07/30 UPD T.Yoshioka 2012/08/07配信障害№128 ---------<<<<<<<<<<<<<<<<<<<<<<<
                        // 2011/01/11 >>>
                        //goodsUnitDataList ?? new List<GoodsUnitData>(),
                            goodsUnitDataList,
                        // 2011/01/11 <<<
                            SCMSearchedResult.GoodsSearchDivCd.BLCode,
                        //searchedCarInfo // 2010/04/21
                            searchedCarInfo, // 2010/04/21
                            true // 2010/04/21
                        )
                    );
                    // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応---------->>>>>
                    // 倉庫情報リストをクリア
                    SCMSearcher.warehouseInfoList = new List<SCMSearcher.WarehouseInfo>();
                    // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応----------<<<<<
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                //}
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                //<<<2012/01/04

            }
            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 車両検索→BL検索を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecordList">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>結果コード</returns>
        /// <br>Update Note : 2024/04/23 陳艶丹</br>
        /// <br>管理番号    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4350 BLP不具合対応 得意先設定と異なる倉庫コードが回答される</br>
        protected int SearchByCarAndBLCode(List<SCMOrderDetailRecordType> scmOrderDetailRecordList)
        {
            Debug.WriteLine("検索処理が車両検索→BL検索を行います。");

            #region <車両検索>

            // 車両検索を開始
            string carKey = scmOrderDetailRecordList[0].ToCarKey();
            if (!CarRecordMap.ContainsKey(carKey))
            {
                Debug.Assert(false, "明細に対応する車両情報が無い？");
                return (int)ResultUtil.ResultCode.Abort;
            }

            // 車両情報の検索結果
            CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;
            PMKEN01010E searchedCarInfo = null;

            if (!SearchedResultAndCarInfoMap.ContainsKey(carKey))
            {
                // 1パラ目：検索条件
                CarSearchCondition searchingCarCondition = CreateSearchingCarCondition(
                    CarRecordMap[carKey]
                );

                if (searchingCarCondition.ModelDesignationNo == 0 &&             // 型式指定番号
                    searchingCarCondition.CategoryNo == 0 &&                     // 類別区分番号
                    searchingCarCondition.CarModel.FullModel == string.Empty)    // 型式(フル型)
                {
                    // 車両検索の条件が無いので、車両検索しない
                    searchedCarResult = CarSearchResultReport.retFailed;
                    searchedCarInfo = new PMKEN01010E();
                }
                else
                {

                    // 2パラ目：検索結果
                    searchedCarInfo = new PMKEN01010E();

                    // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                    if (this.CheckCarSearchCondition(searchingCarCondition))
                    {
                        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

                        // 車両検索
                        searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);

                        if (searchedCarInfo != null)
                        {
                            for (int i = 0; i < searchedCarInfo.CategoryEquipmentInfo.Count; i++)
                            {
                                Debug.WriteLine(string.Format("\t車両検索結果：BLコード[{0}] = {1}", i, searchedCarInfo.CategoryEquipmentInfo[i].TbsPartsCode));
                            }
                        }

                        // 検索結果を保持 ∵1問合せで車両は同じであるため、同じ車両検索を何度も行わない
                        if (searchedCarInfo != null)
                        {
                            if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                            {
                                if (searchedCarInfo.CarKindInfo != null &&
                                    searchedCarInfo.CarKindInfo.Count > 0)
                                {
                                    if (searchingCarCondition.ModelCode != 0 || searchingCarCondition.ModelSubCode != 0)
                                    {
                                        for (int iCnt = 0; iCnt < searchedCarInfo.CarKindInfo.Count; iCnt++)
                                        {
                                            if (searchedCarInfo.CarKindInfo[iCnt].ModelCode == searchingCarCondition.ModelCode &&
                                                searchedCarInfo.CarKindInfo[iCnt].ModelSubCode == searchingCarCondition.ModelSubCode)
                                            {
                                                searchedCarInfo.CarKindInfo[iCnt].SelectionState = true;
                                                break;
                                            }
                                        }
                                    }
                                    searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                                }
                            }

                            // 車種確定時(検索結果が複数車種の場合は先頭車種)
                            if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel) ||
                                searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel))
                            {
                                // 外車(DomesticForeignCode=2)の場合、車台番号(VINｺｰﾄﾞ)を設定
                                if (searchedCarInfo.CarModelUIData[0].DomesticForeignCode == 2)
                                {
                                    searchedCarInfo.CarModelUIData[0].FrameNo = CarRecordMap[carKey].FrameNo;
                                }
                            }

                            if (searchedCarInfo != null)
                            {
                                SearchedResultAndCarInfoMap.Add(
                                    carKey,
                                    new KeyValuePair<CarSearchResultReport, PMKEN01010E>(searchedCarResult, searchedCarInfo)
                                );
                            } 
                        }
                    }
                    else
                    {
                        searchedCarResult = CarSearchResultReport.retFailed;
                    }
                }
            }
            else
            {
                searchedCarResult = SearchedResultAndCarInfoMap[carKey].Key;
                searchedCarInfo = SearchedResultAndCarInfoMap[carKey].Value;
            }

            CurrentCarInfo = searchedCarInfo;

            #endregion // </車両検索>

            // PCCUOEの場合
            if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            {
                // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
                if (
                    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retFailed) // 検索結果0件も許可する
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind)
                )
                {
                    return (int)ResultUtil.ResultCode.Abort;
                }
            }
            else
            // SCMの場合
            {
                // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
                if (
                    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retFailed) // 検索結果0件も許可する
                        &&
                    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                )
                {
                    return (int)ResultUtil.ResultCode.Abort;
                }
            }

            #region <BL検索>

            // 検索結果が1件であれば、BL検索を開始
            // 1パラ目：検索条件
            List<GoodsCndtn> searchingGoodsConditionList = EditSearchingGoodsCondition(
                CreateSearchingGoodsCondition(scmOrderDetailRecordList, searchedCarInfo)
            );

            // 2パラ目：部品情報
            List<PartsInfoDataSet> partsInfoDBList = null;

            // 3パラ目：商品連結データ
            List<List<GoodsUnitData>> goodsUnitDataList = null;

            // 4パラ目：メッセージ
            string msg = string.Empty;

            // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
            // 各明細の検索結果リスト
            List<int> statusList = null;
            // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<

            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 車輌データあり⇒BLコード検索
                // BL検索
                status = SearchPartsFromBLCodeCarInfo(
                    searchingGoodsConditionList,
                    out partsInfoDBList,
                    out goodsUnitDataList,
                    // ADD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
                    out statusList,
                    // ADD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
                    out msg,
                    searchedCarInfo
                );
            }
            catch
            {
            }

            #endregion // </BL検索>

            // 検索結果を保持
            if (partsInfoDBList != null && partsInfoDBList.Count != 0)
            {
                for (int i = 0; i < partsInfoDBList.Count; i++)
                {
                    PartsInfoDataSet partsInfoDB = partsInfoDBList[i];
                    List<GoodsUnitData> goodsUnitDataListTemp = goodsUnitDataList[i];
                    ISCMOrderDetailRecord scmOrderDetailRecord = scmOrderDetailRecordList[i];
                    // UPD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
                    //// 検索結果がない時はステータスを検索異常に設定
                    //if (goodsUnitDataListTemp.Count == 0)
                    int searchStatus = statusList[i];
                    if (searchStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // UPD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
                    {
                        status = 1;
                    }
                    else
                    {
                        status = 0;
                    }

                    GetGoodsUnitDataList(status, scmOrderDetailRecord, ref goodsUnitDataListTemp);
                    Debug.WriteLine("明細キー：" + scmOrderDetailRecord.ToKey() + ", BLコード：" + scmOrderDetailRecord.BLGoodsCode.ToString());
                    SetResultMap.Add(scmOrderDetailRecord.ToKey(), (PartsInfoDataSet)partsInfoDB.Copy());
                    ResultMap.Add(
                        scmOrderDetailRecord.ToKey(),
                        new SCMSearchedResult(
                            scmOrderDetailRecord,
                            RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind,
                            status,
                            (PartsInfoDataSet)partsInfoDB.CopyForSCM(),
                            goodsUnitDataListTemp,
                            SCMSearchedResult.GoodsSearchDivCd.BLCode,
                            searchedCarInfo,
                            true
                        )
                    );
                }
                // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応---------->>>>>
                // 倉庫情報リストをクリア
                SCMSearcher.warehouseInfoList = new List<SCMSearcher.WarehouseInfo>();
                // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応----------<<<<<

            }
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // ----- 2011/08/10 ----- >>>>>
        /// <summary>
        /// 用品入力処理を行います。
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="searchedType">検索タイプ</param>
        /// <returns>結果コード</returns>
        /// <br>Update Note : 2024/04/23 陳艶丹</br>
        /// <br>管理番号    : 12000031-00</br>
        /// <br>            : PMKOBETSU-4350 BLP不具合対応 得意先設定と異なる倉庫コードが回答される</br>
        //protected int SearchByGoodsName(SCMOrderDetailRecordType scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd searchedType) // 2012/02/12
        public int SearchByGoodsName(SCMOrderDetailRecordType scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd searchedType) // 2012/02/12
        {
            Debug.WriteLine("用品入力処理を行います。");
            if (searchedType == SCMSearchedResult.GoodsSearchDivCd.GoodsName)
            {
                #region <車両検索>

                // 車両検索を開始
                string carKey = scmOrderDetailRecord.ToCarKey();
                if (!CarRecordMap.ContainsKey(carKey))
                {
                    Debug.Assert(false, "明細に対応する車両情報が無い？");
                    return (int)ResultUtil.ResultCode.Abort;
                }

                // 車両情報の検索結果
                CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;
                PMKEN01010E searchedCarInfo = null;

                if (!SearchedResultAndCarInfoMap.ContainsKey(carKey))
                {
                    // 1パラ目：検索条件
                    CarSearchCondition searchingCarCondition = CreateSearchingCarCondition(
                        CarRecordMap[carKey]
                    );

                    //>>>2012/06/24
                    if (searchingCarCondition.ModelDesignationNo == 0 &&             // 型式指定番号
                        searchingCarCondition.CategoryNo == 0 &&                     // 類別区分番号
                        searchingCarCondition.CarModel.FullModel == string.Empty)    // 型式(フル型)
                    {
                        // 車両検索の条件が無いので、車両検索しない
                        searchedCarResult = CarSearchResultReport.retFailed;
                        searchedCarInfo = new PMKEN01010E();
                    }
                    else
                    {
                    //<<<2012/06/24

                        // 2パラ目：検索結果
                        searchedCarInfo = new PMKEN01010E();

                        if (this.CheckCarSearchCondition(searchingCarCondition))
                        {

                            // 車両検索
                            EasyLogger.Write(MY_NAME, "SearchByGoodsName", "車両検索1 開始" + "パラメータ:" + GetCarSearchCondition(searchingCarCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                            searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                            EasyLogger.Write(MY_NAME, "SearchByGoodsName", "車両検索1 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                            if (searchedCarInfo != null)
                            {
                                for (int i = 0; i < searchedCarInfo.CategoryEquipmentInfo.Count; i++)
                                {
                                    Debug.WriteLine(string.Format("\t車両検索結果：BLコード[{0}] = {1}", i, searchedCarInfo.CategoryEquipmentInfo[i].TbsPartsCode));
                                }
                            }

                            // 検索結果を保持 ∵1問合せで車両は同じであるため、同じ車両検索を何度も行わない
                            if (searchedCarInfo != null)
                            {
                                // ----- ADD 2011/09/20 ----- >>>>>
                                if (CurrentHeaderRecord.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
                                    searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                                {
                                    if (searchedCarInfo.CarKindInfo != null &&
                                        searchedCarInfo.CarKindInfo.Count > 0)
                                    {
                                        searchedCarInfo.CarKindInfo[0].SelectionState = true;
                                        EasyLogger.Write(MY_NAME, "SearchByGoodsName", "車両検索2 開始" + "パラメータ:" + GetCarSearchCondition(searchingCarCondition)); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                        searchedCarResult = SearchCar(searchingCarCondition, CarRecordMap[carKey], ref searchedCarInfo);
                                        EasyLogger.Write(MY_NAME, "SearchByGoodsName", "車両検索2 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                                    }
                                }

                                if (searchedCarInfo != null)
                                {
                                    // ----- ADD 2011/09/20 ----- <<<<<
                                    SearchedResultAndCarInfoMap.Add(
                                        carKey,
                                        new KeyValuePair<CarSearchResultReport, PMKEN01010E>(searchedCarResult, searchedCarInfo)
                                    );
                                } // ADD 2011/09/20 ----- <<<<<
                            }
                        }
                        else
                        {
                            searchedCarResult = CarSearchResultReport.retFailed;
                        }
                    } // 2012/06/24
                }
                else
                {
                    searchedCarResult = SearchedResultAndCarInfoMap[carKey].Key;
                    searchedCarInfo = SearchedResultAndCarInfoMap[carKey].Value;
                }

                CurrentCarInfo = searchedCarInfo;

                #endregion // </車両検索>

                //// 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
                //if (
                //    !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                //        &&
                //    !searchedCarResult.Equals(CarSearchResultReport.retFailed) // 検索結果0件も許可する
                //        &&
                //    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                //        &&
                //    !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind)
                //)
                //{
                //    return (int)ResultUtil.ResultCode.Abort;
                //}
            }

            #region <用品処理>

            // 2パラ目：部品情報
            PartsInfoDataSet partsInfoDB = null;

            // 3パラ目：商品連結データ
            List<GoodsUnitData> goodsUnitDataList = null;

            // 4パラ目：メッセージ
            string msg = string.Empty;

            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // 用品入力
                EasyLogger.Write(MY_NAME, "SearchByGoodsName", "用品入力 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                status = SearchPartsFromGoodsName(
                    scmOrderDetailRecord,
                    searchedType,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out msg
                );
                EasyLogger.Write(MY_NAME, "SearchByGoodsName", "用品入力 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
            }
            catch
            {
            }

            #endregion // </用品処理>

            // 検索結果を保持
            if (partsInfoDB != null)
            {
                GetGoodsUnitDataList(status, scmOrderDetailRecord, ref goodsUnitDataList);
                Debug.WriteLine("明細キー：" + scmOrderDetailRecord.ToKey() + ", BLコード：" + scmOrderDetailRecord.BLGoodsCode.ToString());
                if (!ResultMap.ContainsKey(scmOrderDetailRecord.ToKey()))
                {
                    ResultMap.Add(
                        scmOrderDetailRecord.ToKey(),
                        new SCMSearchedResult(
                            scmOrderDetailRecord,
                            RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind,
                            (int)ResultUtil.ResultCode.Normal,
                            // --- UPD 三戸 2012/08/15 ---------->>>>>
                            //partsInfoDB,
                            (PartsInfoDataSet)partsInfoDB.CopyForSCM(),
                            // --- UPD 三戸 2012/08/15 ----------<<<<<
                            goodsUnitDataList,
                            SCMSearchedResult.GoodsSearchDivCd.GoodsName,
                            CurrentCarInfo,
                            true
                        )
                    );

                }
                else
                {
                    ResultMap[scmOrderDetailRecord.ToKey()] = new SCMSearchedResult(
                            scmOrderDetailRecord,
                            RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].AcceptOrOrderKind,
                            (int)ResultUtil.ResultCode.Normal,
                            // --- UPD 三戸 2012/08/15 ---------->>>>>
                            //partsInfoDB,
                            (PartsInfoDataSet)partsInfoDB.CopyForSCM(),
                            // --- UPD 三戸 2012/08/15 ----------<<<<<
                            goodsUnitDataList,
                            SCMSearchedResult.GoodsSearchDivCd.GoodsName,
                            CurrentCarInfo,
                            true
                        );
                }
                // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応---------->>>>>
                // 倉庫情報リストをクリア
                SCMSearcher.warehouseInfoList = new List<SCMSearcher.WarehouseInfo>();
                // --- ADD 2024/04/23 陳艶丹 PMKOBETSU-4350 BLP不具合対応----------<<<<<
            }
            return status;
        }
        // ----- 2011/08/10 ----- <<<<<

        #region <検索条件>

        /// <summary>
        /// 車両検索条件を生成します。
        /// </summary>
        /// <remarks>
        /// 売上伝票入力(MAHNB01012UA.cs::MAHNB01010UA.CarSearch())を参考
        /// </remarks>
        /// <param name="carRecord">SCM受データ(車両情報)のレコード</param>
        /// <returns>車両検索条件</returns>
        protected static CarSearchCondition CreateSearchingCarCondition(ISCMOrderCarRecord carRecord)
        {
            CarSearchCondition consition = new CarSearchCondition();
            {
                consition.MakerCode = carRecord.MakerCode;          // メーカーコード
                consition.ModelCode = carRecord.ModelCode;          // 車種コード
                // UPDATE T.Yoshioka No82 83 2012/06/14 --------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // consition.ModelSubCode = carRecord.ModelSubCode;       // 車種サブコード
                if (carRecord.MakerCode == 0)
                {
                    // メーカーコードが無効値（0）の場合は、車種サブコードに無効値（-1）を設定する
                    consition.ModelSubCode = -1;
                }
                else
                {
                    consition.ModelSubCode = carRecord.ModelSubCode;       // 車種サブコード
                }
                // -----------------------------------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                consition.ModelDesignationNo = carRecord.ModelDesignationNo; // 型式指定番号
                consition.CategoryNo = carRecord.CategoryNo;         // 類別区分番号

                // 2011/03/08 >>>
                //if (consition.ModelDesignationNo.Equals(0) || consition.CategoryNo.Equals(0))
                //{
                //    consition.ModelDesignationNo = 0;                   // 型式指定番号
                //    consition.CategoryNo = 0;                           // 類別区分番号
                //    consition.CarModel.FullModel = carRecord.FullModel; // 型式(フル型)
                //}

                if (consition.ModelDesignationNo.Equals(0) || consition.CategoryNo.Equals(0))
                {
                    consition.ModelDesignationNo = 0;                   // 型式指定番号
                    consition.CategoryNo = 0;                           // 類別区分番号
                    // DEL 2011/08/10 gaofeng >>>
                    //consition.CarModel.FullModel = carRecord.FullModel; // 型式(フル型)
                    // DEL 2011/08/10 gaofeng <<<
                    // ADD 2011/08/10 gaofeng >>>
                    consition.CarModel.FullModel = string.IsNullOrEmpty(carRecord.FullModel) ? carRecord.CarInspectCertModel : carRecord.FullModel;
                    // ADD 2011/08/10 gaofeng <<<
                }

                // 2011/03/08 <<<

                // 車両検索タイプ（型式指定番号と類別区分番号が > 0 の場合、類別検索）
                consition.Type = (
                    !carRecord.ModelDesignationNo.Equals(0) && !carRecord.CategoryNo.Equals(0)
                        ? CarSearchType.csCategory  // 類別検索
                        : CarSearchType.csModel     // 型式検索
                );
            }
            return consition;
        }

        #endregion // </検索条件>

        #region <Virtual>

        /// <summary>
        /// 車両を検索します。
        /// </summary>
        /// <param name="searchingCarCondition">検索条件</param>
        /// <param name="carRecord">SCM受注データ(車両情報)</param>
        /// <param name="searchedCarInfo">検索結果</param>
        /// <returns>処理ステータス</returns>
        protected virtual CarSearchResultReport SearchCar(
            CarSearchCondition searchingCarCondition,
            // 2011/03/08 >>>
            ISCMOrderCarRecord carRecord,
            // 2011/03/08 <<<
            ref PMKEN01010E searchedCarInfo
        )
        {
            return CarAccesser.Search(searchingCarCondition, ref searchedCarInfo);
        }

        // 2011/02/09 Add >>>
        /// <summary>
        /// フル型式固定番号を使用して車両を検索します。
        /// </summary>
        /// <param name="fullModelFilxedNoArray"></param>
        /// <param name="freeSrchMdlFxdNoAry"></param>
        /// <param name="searchingCarCondition"></param>
        /// <param name="searchedCarInfo"></param>
        /// <returns></returns>
        protected virtual CarSearchResultReport SearchCarByFullModelFixedNo(
            int[] fullModelFilxedNoArray,
            string[] freeSrchMdlFxdNoAry,
            CarSearchCondition searchingCarCondition,
            ref PMKEN01010E searchedCarInfo
        )
        {

            return CarAccesser.SearchByFullModelFixedNo(fullModelFilxedNoArray, freeSrchMdlFxdNoAry, searchingCarCondition, ref searchedCarInfo);
        }

        // 2011/02/09 Add <<<

        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        protected abstract int SearchPartsFromBLCode(
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        );

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsConditionList">検索条件</param>
        /// <param name="partsInfoDBList">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        protected abstract int SearchPartsFromBLCode(
            List<GoodsCndtn> searchingGoodsConditionList,
            out List<PartsInfoDataSet> partsInfoDBList,
            out List<List<GoodsUnitData>> goodsUnitDataList,
            out string msg
        );
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // ADD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="carInfo">車両情報</param>
        /// <returns>結果コード</returns>
        protected abstract int SearchPartsFromBLCodeCarInfo(
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg,
            PMKEN01010E carInfo
        );
        // ADD 2013/02/01 T.Yoshioka 2013/03/06配信予定 SCM障害№92 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索アクセサを用いてBL検索を行います。
        /// </summary>
        /// <param name="searchingGoodsCondition">検索条件</param>
        /// <param name="partsInfoDBList">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="statusList">各明細の検索結果リスト</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="carInfo">車両情報</param>
        /// <returns>結果コード</returns>
        protected abstract int SearchPartsFromBLCodeCarInfo(
            List<GoodsCndtn> searchingGoodsCondition,
            out List<PartsInfoDataSet> partsInfoDBList,
            out List<List<GoodsUnitData>> goodsUnitDataList,
            // UPD 2014/05/30 商品保証課Redmine#1581対応 -------------------------------->>>>>
            out List<int> statusList,
            // UPD 2014/05/30 商品保証課Redmine#1581対応 --------------------------------<<<<<
            out string msg,
            PMKEN01010E carInfo
        );
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // ----- 2011/08/10 ----- >>>>>
        /// <summary>
        /// 用品入力を行います。
        /// </summary>
        /// <param name="scmOrderDetailRecord">検索条件</param>
        /// <param name="searchedType">検索タイプ</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        /// <see cref="SCMSearcher"/>
        protected abstract int SearchPartsFromGoodsName(
            SCMOrderDetailRecordType scmOrderDetailRecord,
            SCMSearchedResult.GoodsSearchDivCd searchedType,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        );
        // ----- 2011/08/10 ----- <<<<<

        // 2011/01/11 Add >>>
        /// <summary>
        /// 商品連結情報リストの取得
        /// </summary>
        /// <param name="searchStatus">ステータス</param>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="goodsUnitDataList">商品連結情報リスト</param>
        protected abstract void GetGoodsUnitDataList(
            int searchStatus,
            SCMOrderDetailRecordType scmOrderDetailRecord,
            ref List<GoodsUnitData> goodsUnitDataList
        );
        // 2011/01/11 Add <<<

        #endregion // </Virtual>

        /// <summary>
        /// 優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を生成します。
        /// </summary>
        /// <remarks>
        /// 売上伝票入力(MAHNB01012AB.cs::SalesSlipInputAcs.SearchPartsFromBLCode())を参考<br/>
        /// warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0);
        /// </remarks>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <returns>優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)</returns>
        protected static List<string> CreatePriorWarehouseList(ISCMOrderHeaderRecord headerRecord)
        {
            const string METHOD_NAME = "CreatePriorWarehouseList()";    // ログ用

            List<string> priorWarehouseList = new List<string>();
            {
                EasyLogger.Write(MY_NAME, METHOD_NAME, "該当する拠点設定 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                SecInfoSet secInfoSet = SecInfoSetDB.Find(
                    headerRecord.InqOtherEpCd,
                    headerRecord.InqOtherSecCd
                );
                EasyLogger.Write(MY_NAME, METHOD_NAME, "該当する拠点設定 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                if (secInfoSet == null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を生成中...拠点情報が検索できませんでした。(企業=「{0}」, 拠点=「{1}」)",
                        headerRecord.InqOtherEpCd,
                        headerRecord.InqOtherSecCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return priorWarehouseList;
                }
                EasyLogger.Write(MY_NAME, METHOD_NAME, "得意先情報を取得 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                CustomerInfo customerInfo = GetCustomerInfo(headerRecord);
                EasyLogger.Write(MY_NAME, METHOD_NAME, "得意先情報を取得 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                if (customerInfo == null)
                {
                    #region <Log>

                    string msg = string.Format(
                        "優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫)を生成中...得意先情報が検索できませんでした。(企業=「{0}」, 拠点=「{1}」, 得意先=「{2}」)",
                        headerRecord.InqOtherEpCd,
                        headerRecord.InqOtherSecCd,
                        headerRecord.CustomerCode
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return priorWarehouseList;
                }

                List<string> sectWarehouseCdList = new List<string>();
                {
                    sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd1.Trim());
                    sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd2.Trim());
                    sectWarehouseCdList.Add(secInfoSet.SectWarehouseCd3.Trim());
                }
                EasyLogger.Write(MY_NAME, METHOD_NAME, "倉庫リスト位置指定追加処理 開始"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）
                priorWarehouseList = OtherAppComponent.AddWarehouseList(
                    sectWarehouseCdList,
                    customerInfo.CustWarehouseCd,
                    0
                );
                EasyLogger.Write(MY_NAME, METHOD_NAME, "倉庫リスト位置指定追加処理 完了"); // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化）

                #region <Log>

                // 2010/02/25 >>>
                //string info = string.Format(
                //    "優先倉庫リスト(得意先優先倉庫＋拠点優先倉庫) 倉庫コード[0]=「{0}」, 倉庫コード[1]=「{1}」, 倉庫コード[2]=「{2}」, 倉庫コード[3]=「{3}」",
                //    priorWarehouseList[0],
                //    priorWarehouseList[1],
                //    priorWarehouseList[2],
                //    priorWarehouseList[3]
                //);
                //EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(info));
                string info = string.Empty;
                foreach (string warehouseCd in priorWarehouseList)
                {
                    if (!string.IsNullOrEmpty(info)) info += ",";
                    info += string.Format("倉庫=「{0}」", warehouseCd);
                }
                if (!string.IsNullOrEmpty(info))
                {
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(string.Format("優先倉庫(得意先優先倉庫＋拠点優先倉庫) {0}", info)));
                }
                else
                {
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("優先倉庫(得意先優先倉庫＋拠点優先倉庫)無し"));
                }
                // 2010/02/25 <<<

                #endregion // </Log>
            }
            return priorWarehouseList;
        }

        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>
        /// 優先倉庫リスト(PCC自社設定マスタの優先倉庫)を生成します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <returns>優先倉庫リスト</returns>
        protected static List<string> CreatePriorWarehouseListForPccuoe(ISCMOrderHeaderRecord headerRecord)
        {

            // ADD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            string key = headerRecord.InqOriginalEpCd.Trim() + headerRecord.InqOriginalSecCd.Trim() + headerRecord.InqOtherEpCd.Trim() + headerRecord.InqOtherSecCd.Trim();
            if (SectWarehouseCdListMap.ContainsKey(key))
            {
                return SectWarehouseCdListMap[key];
            }
            // ADD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<

            PccCmpnyStWork pccCmpnySt = searchPccCmpnyStList(headerRecord.InqOriginalEpCd.Trim(), headerRecord.InqOriginalSecCd, headerRecord.InqOtherEpCd, headerRecord.InqOtherSecCd);//@@@@20230303
            
            List<string> sectWarehouseCdList = new List<string>();
            if (pccCmpnySt != null)
            {
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccWarehouseCd)? "" : pccCmpnySt.PccWarehouseCd.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd1)? "" : pccCmpnySt.PccPriWarehouseCd1.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd2)? "" : pccCmpnySt.PccPriWarehouseCd2.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd3)? "" : pccCmpnySt.PccPriWarehouseCd3.Trim());
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                // BLP参照倉庫追加オプションチェック
                if (CheckPriWarehouseOption())
                {
                    sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd4) ? "" : pccCmpnySt.PccPriWarehouseCd4.Trim());
                }
                // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
            }
            // UPD 2014/02/05 SCM仕掛一覧№10627対応 ----------------------------------->>>>>
            //return sectWarehouseCdList;
            SectWarehouseCdListMap.Add(key, sectWarehouseCdList);

            return sectWarehouseCdList ?? new List<string>();
            // UPD 2014/02/05 SCM仕掛一覧№10627対応 -----------------------------------<<<<<
        }

        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
        /// <summary>
        ///  BLP参照倉庫追加オプションチェック
        /// </summary>
        /// <returns></returns>
        private static bool CheckPriWarehouseOption()
        {
            USBOptionAgent usbOptin = new USBOptionAgent();
            return usbOptin.EnabledBLPPriWarehouseOption();
        }
        // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

        // ----- ADD 2011/08/10 ----- <<<<<

        #endregion // </車両検索→BL検索>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="headerRecordList">SCM受注データのレコードリスト</param>
        /// <param name="carRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="detailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <param name="orgAnswerRecordList"></param>
        /// <param name="orgDetailRecordList"></param>
        protected SCMSearcher(
            IList<SCMOrderHeaderRecordType> headerRecordList,
            IList<SCMOrderCarRecordType> carRecordList,
            IList<SCMOrderDetailRecordType> detailRecordList
            // 2010/03/31 >>>
            , IList<SCMOrderAnswerRecordType> orgAnswerRecordList
            , IList<SCMOrderDetailRecordType> orgDetailRecordList
            // 2010/03/31 <<<
        )
        {
            _headerRecordList = headerRecordList;
            _carRecordList = carRecordList;
            _detailRecordList = detailRecordList;
            // 2010/03/31 Add >>>
            _orgAnswerRecordList = orgAnswerRecordList;
            _orgDetailRecordList = orgDetailRecordList;
            // 2010/03/31 Add <<<

            // SCM受注データ(車両情報)のレコードマップを初期化
            foreach (SCMOrderCarRecordType carRecord in carRecordList)
            {
                string key = carRecord.ToKey();
                if (_carRecordMap.ContainsKey(key)) continue;

                _carRecordMap.Add(key, carRecord);
            }
        }

        // ADD 2011/08/10 gaofeng >>>
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
            const string METHOD_NAME = "searchPccCmpnyStList";

            IPccCmpnyStDB writer = MediationPccCmpnyStDB.GetPccCmpnyStDB();

            // UPD 2013/02/22 T.Yoshioka 2013/02/99配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            // DEL 2013/01/18 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // object pccCmpnyStObj = null;
            // DEL 2013/01/18 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion
            // 2/19配信　速度改善の戻し
            object pccCmpnyStObj = null;
            // UPD 2013/02/22 T.Yoshioka 2013/02/99配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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

            // UPD 2013/02/22 T.Yoshioka 2013/03/06配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            // UPD 2013/01/18 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //// int status = writer.Search(out pccCmpnyStObj, parsePccCmpnyStWork, readMode, logicalMode); 
            //int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
            //if (pccCmpnyStObj == null || ((ArrayList)pccCmpnyStObj).Count <= 0)
            //{
            //    status = writer.Search(out pccCmpnyStObj, parsePccCmpnyStWork, readMode, logicalMode);
            //}
            //// UPD 2013/01/18 T.Yoshioka 2013/01/99配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            #endregion
            // 2/19配信　速度改善の戻し
            int status = writer.Search(out pccCmpnyStObj, parsePccCmpnyStWork, readMode, logicalMode);
            // UPD 2013/02/22 T.Yoshioka 2013/03/06配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>
            }
            return null;
        }
        // ADD 2011/08/10 gaofeng <<<

        #endregion // </Constructor>

        // ----- 2011/08/10 ----- >>>>>
        /// <summary>
        /// SCM受発注明細データ（回答）を設定します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>回答データ</returns>
        private UserSCMOrderAnswerRecord SetAnswerRecordFormDetail(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            UserSCMOrderAnswerRecord resultAnswerRecord = new UserSCMOrderAnswerRecord();

            // 作成日時
            resultAnswerRecord.EnterpriseCode = scmOrderDetailRecord.InqOtherEpCd;                        // 企業コード              
            resultAnswerRecord.InqOriginalEpCd = scmOrderDetailRecord.InqOriginalEpCd.Trim();                  // 問合せ元企業コード//@@@@20230303
            resultAnswerRecord.InqOriginalSecCd = scmOrderDetailRecord.InqOriginalSecCd;                // 問合せ元拠点コード            
            resultAnswerRecord.InqOtherEpCd = scmOrderDetailRecord.InqOtherEpCd;                        // 問合せ先企業コード            
            resultAnswerRecord.InqOtherSecCd = scmOrderDetailRecord.InqOtherSecCd;                      // 問合せ先拠点コード            
            resultAnswerRecord.InquiryNumber = scmOrderDetailRecord.InquiryNumber;                      // 問合せ番号                    
            resultAnswerRecord.InqRowNumber = scmOrderDetailRecord.InqRowNumber;                        // 問合せ行番号                
            resultAnswerRecord.InqRowNumDerivedNo = scmOrderDetailRecord.InqRowNumDerivedNo;            // 問合せ行番号枝番            
            resultAnswerRecord.GoodsDivCd = scmOrderDetailRecord.GoodsDivCd;                            // 商品種別                    
            resultAnswerRecord.RecyclePrtKindCode = scmOrderDetailRecord.RecyclePrtKindCode;            // リサイクル部品種別            
            resultAnswerRecord.RecyclePrtKindName = scmOrderDetailRecord.RecyclePrtKindName;            // リサイクル部品種別名称      
            // --- ADD 2011/09/16 ---------->>>>>
            resultAnswerRecord.DeliveredGoodsDiv = scmOrderDetailRecord.DeliveredGoodsDiv;              // 納品区分                    
            // --- ADD 2011/09/16 ----------<<<<<
            resultAnswerRecord.HandleDivCode = scmOrderDetailRecord.HandleDivCode;                      // 取扱区分                    
            resultAnswerRecord.GoodsShape = scmOrderDetailRecord.GoodsShape;                            // 商品形態                    
            resultAnswerRecord.DelivrdGdsConfCd = scmOrderDetailRecord.DelivrdGdsConfCd;                // 納品確認区分                
            resultAnswerRecord.DeliGdsCmpltDueDate = scmOrderDetailRecord.DeliGdsCmpltDueDate;          // 納品完了予定日                
            resultAnswerRecord.AnswerDeliveryDate = scmOrderDetailRecord.AnswerDeliveryDate;            // 回答納期                    
            resultAnswerRecord.BLGoodsCode = scmOrderDetailRecord.BLGoodsCode;                          // BL商品コード                
            resultAnswerRecord.BLGoodsDrCode = scmOrderDetailRecord.BLGoodsDrCode;                      // BL商品コード枝番            
            resultAnswerRecord.InqGoodsName = scmOrderDetailRecord.InqGoodsName;                        // 問発商品名                    
            resultAnswerRecord.AnsGoodsName = scmOrderDetailRecord.AnsGoodsName;                        // 回答商品名                    
            resultAnswerRecord.SalesOrderCount = scmOrderDetailRecord.SalesOrderCount;                  // 発注数                        
            resultAnswerRecord.DeliveredGoodsCount = scmOrderDetailRecord.DeliveredGoodsCount;          // 納品数                        
            resultAnswerRecord.GoodsNo = scmOrderDetailRecord.GoodsNo;                                  // 商品番号                    
            resultAnswerRecord.GoodsMakerCd = scmOrderDetailRecord.GoodsMakerCd;                        // 商品メーカーコード          
            // --- ADD 2011/09/16 ---------->>>>>
            resultAnswerRecord.GoodsMakerNm = scmOrderDetailRecord.GoodsMakerNm;                        // 商品メーカー名称            
            resultAnswerRecord.PureGoodsMakerCd = scmOrderDetailRecord.PureGoodsMakerCd;                // 純正商品メーカーコード        
            // --- ADD 2011/09/16 ----------<<<<<
            resultAnswerRecord.InqPureGoodsNo = scmOrderDetailRecord.InqPureGoodsNo;                    // 問発純正商品番号            
            resultAnswerRecord.AnsPureGoodsNo = scmOrderDetailRecord.AnsPureGoodsNo;                    // 回答純正商品番号            
            resultAnswerRecord.ListPrice = scmOrderDetailRecord.ListPrice;                              // 定価                        
            resultAnswerRecord.UnitPrice = scmOrderDetailRecord.UnitPrice;                              // 単価                        
            resultAnswerRecord.GoodsAddInfo = scmOrderDetailRecord.GoodsAddInfo;                        // 商品補足情報                
            // --- ADD 2011/09/16 ---------->>>>>
            resultAnswerRecord.RoughRrofit = scmOrderDetailRecord.RoughRrofit;                          // 粗利額                        
            resultAnswerRecord.RoughRate = scmOrderDetailRecord.RoughRate;                              // 粗利率                        
            // --- ADD 2011/09/16 ----------<<<<<
            resultAnswerRecord.AnswerLimitDate = scmOrderDetailRecord.AnswerLimitDate;                  // 回答期限                    
            resultAnswerRecord.CommentDtl = scmOrderDetailRecord.CommentDtl;                            // 備考(明細)                    
            resultAnswerRecord.ShelfNo = scmOrderDetailRecord.ShelfNo;                                  // 棚番                        
            // --- ADD 2011/09/16 ---------->>>>>
            resultAnswerRecord.AdditionalDivCd = scmOrderDetailRecord.AdditionalDivCd;                  // 追加区分                    
            resultAnswerRecord.CorrectDivCD = scmOrderDetailRecord.CorrectDivCD;                        // 訂正区分                    
            // --- ADD 2011/09/16 ----------<<<<<
            resultAnswerRecord.InqOrdDivCd = scmOrderDetailRecord.InqOrdDivCd;                          // 問合せ・発注種別            
            resultAnswerRecord.DisplayOrder = scmOrderDetailRecord.DisplayOrder;                        // 表示順位                    
            resultAnswerRecord.CancelCndtinDiv = scmOrderDetailRecord.CancelCndtinDiv;                  // キャンセル状態区分            
            resultAnswerRecord.PMAcptAnOdrStatus = scmOrderDetailRecord.AcptAnOdrStatus;              // PM受注ステータス            
            resultAnswerRecord.PMSalesSlipNum = string.IsNullOrEmpty(scmOrderDetailRecord.SalesSlipNum)? 0 :Int32.Parse(scmOrderDetailRecord.SalesSlipNum);       // PM売上伝票番号  
            resultAnswerRecord.PMSalesRowNo = scmOrderDetailRecord.SalesRowNo;                        // PM売上行番号                
            resultAnswerRecord.DtlTakeinDivCd = scmOrderDetailRecord.DtlTakeinDivCd;                    // 明細取込区分                
            resultAnswerRecord.PmWarehouseCd = scmOrderDetailRecord.PmWarehouseCd;                      // PM倉庫コード                
            resultAnswerRecord.PmWarehouseName = scmOrderDetailRecord.PmWarehouseName;                  // PM倉庫名称                    
            resultAnswerRecord.PmShelfNo = scmOrderDetailRecord.PmShelfNo;                              // PM棚番                        
            resultAnswerRecord.PmPrsntCount = scmOrderDetailRecord.PmPrsntCount;                        // PM現在個数                    
            resultAnswerRecord.SetPartsMkrCd = scmOrderDetailRecord.SetPartsMkrCd;                      // セット部品メーカーコード    
            resultAnswerRecord.SetPartsNumber = scmOrderDetailRecord.SetPartsNumber;                    // セット部品番号                
            resultAnswerRecord.SetPartsMainSubNo = scmOrderDetailRecord.SetPartsMainSubNo;              // セット部品親子番号 
            // 2012/01/16 Add >>>
            resultAnswerRecord.GoodsSpecialNote = scmOrderDetailRecord.GoodsSpecialNote;                // 特記事項
            // 2012/01/16 Add <<<
            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            resultAnswerRecord.AutoEstimatePartsCd = scmOrderDetailRecord.AutoEstimatePartsCd; // 自動見積部品コード
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<
            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            resultAnswerRecord.SalesTotalTaxInc = scmOrderDetailRecord.SalesTotalTaxInc; // 売上伝票合計（税込）
            resultAnswerRecord.SalesTotalTaxExc = scmOrderDetailRecord.SalesTotalTaxExc; // 売上伝票合計（税抜）
            resultAnswerRecord.ScmConsTaxLayMethod = scmOrderDetailRecord.ScmConsTaxLayMethod; // SCM消費税転嫁方式
            resultAnswerRecord.ConsTaxRate = scmOrderDetailRecord.ConsTaxRate; // 消費税税率
            resultAnswerRecord.ScmFractionProcCd = scmOrderDetailRecord.ScmFractionProcCd; // SCM端数処理区分
            resultAnswerRecord.AccRecConsTax = scmOrderDetailRecord.AccRecConsTax; // 売掛消費税
            resultAnswerRecord.PMSalesDate = scmOrderDetailRecord.PMSalesDate; // PM売上日を取得
            resultAnswerRecord.SuppSlpPrtTime = scmOrderDetailRecord.SuppSlpPrtTime; // 仕入先伝票発行時刻
            resultAnswerRecord.SalesMoneyTaxInc = scmOrderDetailRecord.SalesMoneyTaxInc; // 売上金額（税込み）
            resultAnswerRecord.SalesMoneyTaxExc = scmOrderDetailRecord.SalesMoneyTaxExc; // 売上金額（税抜き）
            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            resultAnswerRecord.DataInputSystem = scmOrderDetailRecord.DataInputSystem; // データ入力システム
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            resultAnswerRecord.PrmSetDtlNo2 = scmOrderDetailRecord.PrmSetDtlNo2; // 優良設定詳細コード２
            resultAnswerRecord.PrmSetDtlName2 = scmOrderDetailRecord.PrmSetDtlName2; // 優良設定詳細名称２
            resultAnswerRecord.StockStatusDiv = scmOrderDetailRecord.StockStatusDiv; // 在庫状況区分
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            resultAnswerRecord.RentDiv = scmOrderDetailRecord.RentDiv; // 貸出区分            
            resultAnswerRecord.MkrSuggestRtPric = scmOrderDetailRecord.MkrSuggestRtPric; // メーカー希望小売価格
            resultAnswerRecord.OpenPriceDiv = scmOrderDetailRecord.OpenPriceDiv; // オープン価格区分    
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

            // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
            resultAnswerRecord.BgnGoodsDiv = scmOrderDetailRecord.BgnGoodsDiv;  // お買得商品選択区分
            // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            resultAnswerRecord.ModelPrtsAdptYm = scmOrderDetailRecord.ModelPrtsAdptYm; // 型式別部品採用年月
            resultAnswerRecord.ModelPrtsAblsYm = scmOrderDetailRecord.ModelPrtsAblsYm; // 型式別部品廃止年月
            resultAnswerRecord.ModelPrtsAdptFrameNo = scmOrderDetailRecord.ModelPrtsAdptFrameNo; // 型式別部品採用車台番号
            resultAnswerRecord.ModelPrtsAblsFrameNo = scmOrderDetailRecord.ModelPrtsAblsFrameNo; // 型式別部品廃止車台番号
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

            // ADD 2015/03/03 SCM高速化Redmine#300対応 ------------------------------------>>>>>
            resultAnswerRecord.PrmSetDtlName2ForFac = scmOrderDetailRecord.PrmSetDtlName2ForFac; // 優良設定詳細名称２（工場向け）
            resultAnswerRecord.PrmSetDtlName2ForCOw = scmOrderDetailRecord.PrmSetDtlName2ForCOw; // 優良設定詳細名称２（カーオーナー向け）
            // ADD 2015/03/03 SCM高速化Redmine#300対応 ------------------------------------<<<<<

            return resultAnswerRecord;
        }
        // ----- 2011/08/10 ----- <<<<<
        // --- ADD m.suzuki 2012/04/19 ---------->>>>>
        /// <summary>
        /// 検索結果を強制的にクリアする処理
        /// </summary>
        public void ClearSearchResult()
        {
            // --- UPD 2012/09/28 三戸 2012/11/14配信分 SCM障害№10375 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //_resultMap.Clear();
            //_setResultMap.Clear();
            //_carRecordMap.Clear();
            //_currentCarInfo.Clear();
            //_carRecordList.Clear();
            //_headerRecordList.Clear();
            //_detailRecordList.Clear();
            //_orgAnswerRecordList.Clear();
            //_orgDetailRecordList.Clear();
            //_relationalHeaderMap.Clear();
            //_searchedResultAndCarInfoMap.Clear();
            if (_resultMap != null) _resultMap.Clear();
            if (_setResultMap != null) _setResultMap.Clear();
            if (_carRecordMap != null) _carRecordMap.Clear();
            if (_currentCarInfo != null) _currentCarInfo.Clear();
            if (_carRecordList != null) _carRecordList.Clear();
            if (_headerRecordList != null) _headerRecordList.Clear();
            if (_detailRecordList != null) _detailRecordList.Clear();
            if (_orgAnswerRecordList != null) _orgAnswerRecordList.Clear();
            if (_orgDetailRecordList != null) _orgDetailRecordList.Clear();
            if (_relationalHeaderMap != null) _relationalHeaderMap.Clear();
            if (_searchedResultAndCarInfoMap != null) _searchedResultAndCarInfoMap.Clear();
            // --- UPD 2012/09/28 三戸 2012/11/14配信分 SCM障害№10375 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            GoodsAcsServer.Singleton.Instance.ClearGoodsAcsMap();
        }
        // --- ADD m.suzuki 2012/04/19 ----------<<<<<

        // ADD 2012/06/25 T.Yoshioka №10281 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 得意先情報の優先倉庫を取得します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データのレコード</param>
        /// <returns>得意先情報の優先倉庫</returns>
        public static string GetCustWarehouseCd(ISCMOrderHeaderRecord headerRecord)
        {
            CustomerInfo cInfo = GetCustomerInfo(headerRecord);
            if (cInfo == null)
            {
                return string.Empty;
            }
            return cInfo.CustWarehouseCd;
        }
        // ADD 2012/06/25 T.Yoshioka №10281 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化） --------->>>>>
        /// <summary>
        /// 車両情報検索条件文字列生成
        /// </summary>
        /// <param name="searchingCarCondition">車両情報検索条件</param>
        /// <returns>車両情報検索条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 車両情報検索条件文字列生成処理を行う</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2020/05/15</br>
        /// </remarks>
        public string GetCarSearchCondition(CarSearchCondition searchingCarCondition)
        {
            string carString = string.Empty;
            try
            {
                carString = LinkBreak + "CarModel.CategorySign:" + searchingCarCondition.CarModel.CategorySign.ToString() + LinkBreak +
                    "CarModel.ExhaustGasSign:" + searchingCarCondition.CarModel.ExhaustGasSign.ToString() + LinkBreak +
                    "CarModel.FullModel:" + searchingCarCondition.CarModel.FullModel.ToString() + LinkBreak +
                    "CarModel.SeriesModel:" + searchingCarCondition.CarModel.SeriesModel.ToString() + LinkBreak +
                    "EngineModel.FullModel:" + searchingCarCondition.EngineModel.FullModel.ToString() + LinkBreak +
                    "EngineModel.Model:" + searchingCarCondition.EngineModel.Model.ToString() + LinkBreak +
                    "EngineModel.ModelNm:" + searchingCarCondition.EngineModel.ModelNm.ToString() + LinkBreak +
                    "CategoryNo:" + searchingCarCondition.CategoryNo.ToString() + LinkBreak +
                    "EraNameDispCd1" + searchingCarCondition.EngineModel.ToString() + LinkBreak +
                    "MakerCode:" + searchingCarCondition.MakerCode.ToString() + LinkBreak +
                    "ModelCode:" + searchingCarCondition.ModelCode.ToString() + LinkBreak +
                    "ModelDesignationNo:" + searchingCarCondition.ModelDesignationNo.ToString() + LinkBreak +
                    "ModelPlate:" + searchingCarCondition.ModelPlate.ToString() + LinkBreak +
                    "ModelSubCode" + searchingCarCondition.ModelCode.ToString();
            }
            catch (Exception ex) 
            {
                carString = LinkBreak + "＃＃＃例外＃＃＃" + LinkBreak + ex.ToString();
            }
            return carString;
        }
        // ADD 2020/05/15 田建委 PMKOBETSU-3932 BLP障害（ログ強化） ---------<<<<<
    }
}
