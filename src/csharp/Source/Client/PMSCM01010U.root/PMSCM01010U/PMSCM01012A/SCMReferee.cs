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
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/03/30  修正内容 : 回答が純正・優良・相場となるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優
// 作 成 日  2010/04/05  修正内容 : 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優
// 作 成 日  2010/04/15  修正内容 : 相場回答は自動回答できる場合のみ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優 
// 作 成 日  2010/04/21  修正内容 : 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434　工藤 恵優 
// 作 成 日  2010/04/22  修正内容 : 作成される売上データが「受注」となる(受注ステータスが「受注」となる)場合、自動回答の対象としない
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517　夏野 駿希 
// 作 成 日  2010/07/07  修正内容 : 端数処理区分，端数処理単位が取得できていない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : Web上のSCM受発注データ.確定日のチェックを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/08/02  修正内容 : Redmine#23307の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaofeng
// 作 成 日  2011/08/10  修正内容 : PCCUOEの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaofeng
// 作 成 日  2011/09/19  修正内容 : Redmine#25216, Redmine#25017の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhubj
// 作 成 日  2011/09/22  修正内容 : Redmine#25436の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liusy
// 作 成 日  2011/09/26  修正内容 : Redmine#25492の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : wangqx
// 作 成 日  2011/09/29  修正内容 : Redmine#25632の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LIUSY
// 作 成 日  2011/10/09  修正内容 : Redmine#25798の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : x_chenjm
// 作 成 日  2011/10/11  修正内容 : Redmine#25798の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/10/11  修正内容 : Redmine#25760の対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/01/04  修正内容 : SCM改良対応
//                                  1)純正情報設定対応
//                                  2)表示順位設定対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/02/12  修正内容 : SCM改良対応
//                                  BLPOS在庫確認でPCC品目設定マスタを有効にする
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/04/09  修正内容 : BL-Pダイレクト発注対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30182 立谷 亮介
// 作 成 日  2012/04/12  修正内容 : SCM改良対応（速度改善対応）
//                                  PCC自社設定マスタの取得処理を修正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/04/17  修正内容 : 障害№166 発注時に在庫の確認を行うように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2012/04/19  修正内容 : RC-SCM速度改良の修正
//                                 （※検索結果が不正にならないようキャッシュクリアする）
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/04/20  修正内容 : 自動回答時、販売区分設定対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 湯上　千加子
// 作 成 日  2012/04/23  修正内容 : 障害№150 2012/02/23配信分、Redmine#28038の対応
//　　　　　　　　　　　　　　　　　SCM改良／修正漏れ対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/05/09  修正内容 : 障害№132 自動回答時の締済みチェック（発注の場合のみ）
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/05/18  修正内容 : 障害№156 セット子のSCM品目設定マスタの取得、設定を追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/05/28  修正内容 : 障害№274 在庫確認でＰＣＣ品目設定が無くても自動回答する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/06/20  修正内容 : SCM障害№166、システム障害№98の戻し
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/06/26  修正内容 : 障害№274 削除(2012/06/28配信から除外)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/06/29  修正内容 : 障害№274 在庫確認でＰＣＣ品目設定が無くても自動回答する
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/07/18  修正内容 : SCM障害№173 PCC優先設定で優先倉庫設定時の表示順条件を変更する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2012/07/09  修正内容 : 障害№10304 掛率設定：3Fの時、セット子の掛率があたらない 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/08  修正内容 : 2012/11/14配信 システムテスト障害対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM障害№76 自動回答時表示区分対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 吉岡　孝憲
// 作 成 日  2012/11/09  修正内容 : SCM障害№10435対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341,10364,10431,10364,10431対応 PCCforNS、BLPの自動回答判定処理統合
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/11/09  修正内容 : SCM改良№10427対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/20  修正内容 : 2012/12/12配信予定システムテスト障害№50対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/21  修正内容 : 2012/12/12配信予定システムテスト障害№56対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/04  修正内容 : 2012/12/12配信予定システムテスト障害№95対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/12  修正内容 : SCM改良№10423対応 PCCforNS、BLPの委託在庫・参照在庫の判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡　孝憲
// 作 成 日  2013/01/17  修正内容 : 2013/01/23配信 SCM障害№10475対応 自動回答が遅い（BLP 在確）
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/01/11  修正内容 : 2013/03/13配信予定 SCM障害№10472対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/13  修正内容 : 2013/03/06配信 SCM障害追加②対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/09/17  修正内容 : SCM仕掛一覧№210対応　表示順設定の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/11/05  修正内容 : 2013/11/xx配信予定システムテスト№19対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/11/18  修正内容 : SCM仕掛一覧№210対応　表示順設定の優先順位に表示順を追加 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/11/28  修正内容 : 商品保証課Redmine#719対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/12/09  修正内容 : SCM仕掛一覧№10608対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/01/30  修正内容 : Redmine#41771 障害№13対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/12/16  修正内容 : SCM仕掛一覧№10590対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2014/02/06  修正内容 : SCM仕掛一覧№10634対応
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/08  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 01.商品検索アクセスクラス補正処理プロパティ対応
//                                : 02.得意先掛率グループマスタ取得改良対応（回答判定時）
//                                : 03.変更前単価計算呼出回数改良対応
//                                : 04.キャンペーン売価設定マスタ取得改良対応
//                                : 05.得意先マスタ（伝票管理）取得改良対応
//                                : 06.得意先マスタ取得改良対応（金額計算クラス）
//                                : 07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応）
//                                : 08.売上データ生成時のシステム日付取得対応
//                                : 09.得意先掛率グループマスタ取得改良対応（売上データ生成時）
//                                : 10.単価計算呼出回数改良
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/13  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 13.フル型式固定番号からのＢＬコード検索回数改良対応
//                                : 14.明細取込区分の更新方法を改良対応
//                                : 15.SCM受発注データ（車両情報）取得方法改良対応
//                                : 16.純正品検索改良対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡
// 修 正 日  2014/05/27  修正内容 : SCM仕掛一覧№10658対応 ｼｽﾃﾑﾃｽﾄ障害№2対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上
// 修 正 日  2014/09/09  修正内容 : SCM高速化 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応
//                                : PM-SCM速度改良 フェーズ２ 
//                                : 14.明細取込区分の更新方法を改良対応,15.SCM受発注データ（車両情報）取得方法改良対応のデグレ 
//----------------------------------------------------------------------------//
// 管理番号  11070221-00 作成担当 : 脇田 靖之
// 作 成 日  2014/10/14  修正内容 : SCM障害№10535対応
//                                : PM-SCMセット部品情報表示対応
//----------------------------------------------------------------------------//
// 管理番号  11070221-00 作成担当 : 脇田 靖之
// 作 成 日  2014/11/05  修正内容 : SCM障害№10535対応
//                                : 2014/11/26配信システムテスト障害№6対応
//                                : PM-SCMセット部品情報表示でキャンペーンが反映されない障害対応
//----------------------------------------------------------------------------//
// 管理番号  11070221-00 作成担当 : 30744 湯上
// 作 成 日  2014/11/10  修正内容 : 2014/11/26配信システムテスト障害対応
//                                : 品番検索時に結合先品番が回答されない障害の対応
//----------------------------------------------------------------------------//
// 管理番号  11070221-00 作成担当 : 30744 湯上
// 作 成 日  2014/11/10  修正内容 : 2014/11/26配信システムテスト障害対応
//                                : SFで即発注時、PM側でセット品子を複数選択後に登録した場合、
//                                : PM側売伝の売上金額と、SF側の金額に差異あるの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上
// 作 成 日  2014/11/27  修正内容 : SCM仕掛一覧№10700対応
//                                : ダイレクト発注の判定方法を修正
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/01/19  修正内容 : リコメンド対応 リコメンド発注時、単価計算を行わない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/01/28  修正内容 : SCM高速化Redmine#61対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/01/29  修正内容 : SCM高速化Redmine#87対応 SCM高速化Redmine#61のデグレ対応 
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢
// 作 成 日  2015/02/02  修正内容 : PM-SCM社内障害一覧No.69対応
//                                : メーカー違いの同一品番が複数存在する場合の再問合せエラー対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 宮本 利明
// 作 成 日  2015/02/24  修正内容 : リコメンド対応 お買い得商品の回答時は定価を算出する
//                                  ※2015/01/19分の修正を削除(定価)
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/03/03  修正内容 : SCM高速化Redmine#310対応 
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2015/02/09  修正内容 : SCM連携マルチキャスト対応
//                                : 問合せ行番号枝番の採番方法を修正
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/03/18  修正内容 : SCM高速化 メーカー希望小売価格対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/06/18  修正内容 : 商品保証課Resmine#3939対応 自動回答判定時、「該当無し自動回答」の条件に検索タイプを追加し、BLコード検索時のみ「該当無し自動回答」の判定を行うように修正
//----------------------------------------------------------------------------//
// 管理番号  11470103-00 作成担当 : 陳艶丹
// 修 正 日  2018/07/06  修正内容 : SF側セット子品番の在庫情報の障害対応
//----------------------------------------------------------------------------//
// 管理番号  11470103-00 作成担当 : 陳艶丹
// 修 正 日  2018/07/26  修正内容 : SF側セット子品番発注時の障害対応
//----------------------------------------------------------------------------//
// 管理番号  11470103-00 作成担当 : 譚洪
// 作 成 日  2018/07/26  修正内容 : BLパーツオーダー自動回答不具合対応
//----------------------------------------------------------------------------//
// 管理番号  11900025-00 作成担当 : yamaji
// 作 成 日  2023/08/07  修正内容 : 締日チェック不具合対応
//----------------------------------------------------------------------------//

//#define _IS_GOODS_OF_REPLYING_AUTOMATICALLY_    // 強制的にSCM品目設定マスタに登録があるとするフラグ
//#define _ENABLED_MANUAL_DATA_                   // 手動回答と判定されたデータを回答対象とするフラグ
//#define _SOBA_ONLY_MODE_    // 相場回答のみモードフラグ ※通常は無効にしておくこと    2010/03/23の修正でこのモードは無効となります

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller.Agent2;  // 2010/07/07 Add
using Broadleaf.Application.Remoting.Adapter; // ADD 2011/08/10
using System.Collections; // ADD 2011/08/10
using Broadleaf.Application.Remoting.ParamData; // ADD 2011/08/10
using Broadleaf.Application.Remoting; // ADD 2011/08/10
// --- ADD 吉岡 2012/05/09 №132 ---------->>>>>
using Broadleaf.Application.Common;
// --- ADD 吉岡 2012/05/09 №132 ----------<<<<<
using Broadleaf.Application.UIData.Util;  //20230807ADD yamaji

namespace Broadleaf.Application.Controller
{
    using SalesProcMoneyServer = SingletonInstance<SalesProcMoneyAgent>;   // 売上金額処理区分マスタ //2010/07/07 add
    using StockProcMoneyServer = SingletonInstance<StockProcMoneyAgent>;   // 仕入金額処理区分マスタ //2010/07/07 add
    using SCMOrderHeaderRecordType = ISCMOrderHeaderRecord;                        // SCM受注データ
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;                           // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;                        // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;                        // SCM受注明細データ(回答)
    using SCMGoodsUnitDataListPair  = KeyValuePair<bool, IList<SCMGoodsUnitData>>;  // 回答用SCM情報付商品連結データのペア
    
    // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
    using PriceSelectSetAgentServer = SingletonInstance<PriceSelectSetAgent>;   // 表示区分マスタ   
    using SalesTtlStServer = SingletonInstance<SalesTtlStAgent>;   // 売上全体設定マスタ
    // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<

    // --- ADD m.suzuki 2011/05/23 ---------->>>>>
    using SCMWebServer = SingletonInstance<SCMWebAcsAgent>; // SCMWebアクセス
    // --- ADD m.suzuki 2011/05/23 ----------<<<<<

    /// <summary>
    /// SCM回答判定処理クラス
    /// </summary>
    public abstract class SCMReferee
    {
        const string MY_NAME = "SCMReferee";    // ログ用

		// -- Add St 2012.04.05 30182 R.Tachiya --
		private PccCmpnyStWork pccCmpnyStWork = null;	// 流用取得用PccCmpnyStWork
		// -- Add Ed 2012.04.05 30182 R.Tachiya --

        // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
        private List<PriceSelectSet> _priceSelectSetAgent = null;                   //表示区分マスタ
        private List<CustRateGroup> _custRateGroupList = new List<CustRateGroup>(); //得意先掛率マスタ
        private CustRateGroupAcs _custRateGroupAcs = new CustRateGroupAcs();
        private SCMTtlSt _scmTtlSt = new SCMTtlSt();                                // SCM全体設定マスタ
        private int _autoAnsHourDspDiv = -1;                                        // 自動回答時表示区分
        // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<
        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№02.得意先掛率グループマスタ取得改良対応（回答判定時） ---------------------------------->>>>>
        private int _prevCustomerCode = 0;  // 得意先コード前回値
        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№02.得意先掛率グループマスタ取得改良対応（回答判定時） ----------------------------------<<<<<

        // ADD 2014/02/06 SCM仕掛一覧№10634対応 ------------------------------------------------->>>>>
        CampaignObjGoodsStAcs _campaignObjGoodsStAcs = new CampaignObjGoodsStAcs(); // キャンペーンマスタアクセスクラス
        // ADD 2014/02/06 SCM仕掛一覧№10634対応 -------------------------------------------------<<<<<

        #region <SCM検索処理>

        /// <summary>SCM検索処理</summary>
        private readonly SCMSearcher _searcher;
        /// <summary>SCM検索処理を取得します。</summary>
        public SCMSearcher Searcher { get { return _searcher; } }
        //add start 2011/08/12
        List<PccItemGrp> pccItemGrpList = new List<PccItemGrp>();

        List<PccItemSt> pccItemStList = new List<PccItemSt>();

        PccItemGrpAcs pccItemGrpAcs;
        //add end 2011/08/12
        #endregion // </SCM検索処理>

        #region <手動回答と判定されたSCM受注明細データ(問合せ・発注)>

        /// <summary>手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップ</summary>
        private IDictionary<string, ISCMOrderDetailRecord> _manualSCMDetailRecordMap;
        /// <summary>手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップを取得します。</summary>
        /// <remarks>キー：SCM受注明細データ(問合せ・発注)のキー</remarks>
        protected IDictionary<string, ISCMOrderDetailRecord> ManualSCMDetailRecordMap
        {
            get
            {
                if (_manualSCMDetailRecordMap == null)
                {
                    _manualSCMDetailRecordMap = new Dictionary<string, ISCMOrderDetailRecord>();
                }
                return _manualSCMDetailRecordMap;
            }
        }

        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>セット商品情報のマップ</summary>
        private IDictionary<string, List<GoodsUnitData>> _setGoodsUnitDataMap;
        /// <summary>セット商品情報のマップを取得します。</summary>
        /// <remarks>キー</remarks>
        protected IDictionary<string, List<GoodsUnitData>> SetGoodsUnitDataMap
        {
            get
            {
                if (_setGoodsUnitDataMap == null)
                {
                    _setGoodsUnitDataMap = new Dictionary<string, List<GoodsUnitData>>();
                }
                return _setGoodsUnitDataMap;
            }
        }
        // ----- ADD 2011/08/10 ----- <<<<<

        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        /// <summary>セット商品価格情報（提供データ）のマップ</summary>
        private IDictionary<string, List<GoodsPrice>> _setOfferPriceMap;
        /// <summary>セット商品価格情報（提供データ）のマップを取得します。</summary>
        /// <remarks>キー</remarks>
        public IDictionary<string, List<GoodsPrice>> SetOfferPriceMap
        {
            get
            {
                if (_setOfferPriceMap == null)
                {
                    _setOfferPriceMap = new Dictionary<string, List<GoodsPrice>>();
                }
                return _setOfferPriceMap;
            }
        }
        /// <summary>セット商品価格情報（ユーザー登録分）のマップ</summary>
        private IDictionary<string, List<GoodsPrice>> _setUserPriceMap;
        /// <summary>セット商品価格情報（ユーザー登録分）のマップを取得します。</summary>
        /// <remarks>キー</remarks>
        public IDictionary<string, List<GoodsPrice>> SetUserPriceMap
        {
            get
            {
                if (_setUserPriceMap == null)
                {
                    _setUserPriceMap = new Dictionary<string, List<GoodsPrice>>();
                }
                return _setUserPriceMap;
            }
        }
        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        /// <summary>
        /// 手動回答と判定されたSCM受注明細データ(問合せ・発注)を
        /// 回答用SCM情報付商品連結データのマップに追加します。
        /// </summary>
        [Obsolete("【隠しメソッド】：手動回答と判定されたSCM受注明細データ(問合せ・発注)を回答対象とします。")]
        protected void AddManualSCMDetailDataToSCMGoodsUnitDataMap()
        {
            foreach (ISCMOrderDetailRecord detailRecord in ManualSCMDetailRecordMap.Values)
            {
                // SCM情報付商品連結データのリストを構築
                IList<SCMGoodsUnitData> scmGoodsUnitDataList = new List<SCMGoodsUnitData>();
                {
                    foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)
                    {
                        // SCM情報付商品連結データ
                        SCMGoodsUnitData scmGoodsUnitData = new SCMGoodsUnitData(
                            goodsUnitData,
                            Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                            detailRecord,
                            GetCustomerCode(detailRecord),
                            true
                        );
                        scmGoodsUnitData.AcceptOrOrderKind = Searcher.RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind; // ADD 2011/08/10
                        scmGoodsUnitDataList.Add(scmGoodsUnitData);
                    }
                }
                // 回答用SCM情報付商品連結データのマップを構築
                BuildSCMGoodsUnitDataMap(detailRecord, scmGoodsUnitDataList);
            }
        }

        #endregion // </手動回答と判定されたSCM受注明細データ(問合せ・発注)>

        #region <回答用SCM情報付商品連結データ>

        /// <summary>SCM用の情報付商品連結データのマップ</summary>
        /// <remarks>キー：SCM受注明細データ(問合せ・発注)のキー</remarks>
        private readonly IDictionary<string, IList<SCMGoodsUnitData>> _scmGoodsUnitDataMap = new Dictionary<string, IList<SCMGoodsUnitData>>();
        /// <summary>SCM用の情報付商品連結データのマップを取得または設定します。</summary>
        public IDictionary<string, IList<SCMGoodsUnitData>> SCMGoodsUnitDataMap { get { return _scmGoodsUnitDataMap; } }

        /// <summary>
        /// SCM用の情報付商品連結データのマップにSCM用の情報付商品連結データを追加します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM用の情報付商品連結データのリスト</param>
        private void AddToSCMGoodsUnitDataMap(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            // ADD 2010/04/22 作成される売上データが「受注」となる(受注ステータスが「受注」となる)場合、自動回答の対象としない ---------->>>>>
            // 商品の情報を検査し、売上データを作成する(自動回答する)するか最終判定する
            if (!CanMakeSalesData(detailRecord, scmGoodsUnitDataList)) return;
            // ADD 2010/04/22 作成される売上データが「受注」となる(受注ステータスが「受注」となる)場合、自動回答の対象としない ----------<<<<<

            string key = detailRecord.ToKey();
            if (!SCMGoodsUnitDataMap.ContainsKey(key))
            {
                SCMGoodsUnitDataMap.Add(key, new List<SCMGoodsUnitData>());
            }
            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                SCMGoodsUnitDataMap[key].Add(scmGoodsUnitData);
            }
        }

        #endregion // </回答用SCM情報付商品連結データ>

        // ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------>>>>>
        #region <変更前SCM情報付商品連結データ>

        /// <summary>SCM用の情報付商品連結データのマップ</summary>
        /// <remarks>キー：SCM受注明細データ(問合せ・発注)のキー</remarks>
        //private readonly List<SCMGoodsUnitData> _beforeScmGoodsUnitDataList = new List<SCMGoodsUnitData>(); // DEL 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応
        private readonly IDictionary<string, List<SCMGoodsUnitData>> _beforeScmGoodsUnitDataMap = new Dictionary<string, List<SCMGoodsUnitData>>(); // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応
        /// <summary>SCM用の情報付商品連結データのマップを取得します。</summary>
        //public List<SCMGoodsUnitData> BeforeSCMGoodsUnitDataList { get { return _beforeScmGoodsUnitDataList; } } // DEL 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応
        public IDictionary<string, List<SCMGoodsUnitData>> BeforeSCMGoodsUnitDataMap { get { return _beforeScmGoodsUnitDataMap; } } // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応

        /// <summary>
        /// 変更前SCM用の情報付商品連結データのマップにSCM用の情報付商品連結データを追加します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM用の情報付商品連結データのリスト（変更前）</param>
        private void AddToBeforeSCMGoodsUnitDataList(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            if (scmGoodsUnitDataList != null && scmGoodsUnitDataList.Count != 0)
            {
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    // 商品単価情報をコピーして格納
                    List<GoodsPrice> pliceList = new List<GoodsPrice>();
                    if (scmGoodsUnitData.RealGoodsUnitData.GoodsPriceList != null &&
                        scmGoodsUnitData.RealGoodsUnitData.GoodsPriceList.Count != 0)
                    {
                        foreach (GoodsPrice recored in scmGoodsUnitData.RealGoodsUnitData.GoodsPriceList)
                        {
                            pliceList.Add(recored.Clone());
                        }
                        //SCM情報付商品連結データ
                        SCMGoodsUnitData beforeDetail = new SCMGoodsUnitData(
                           scmGoodsUnitData.RealGoodsUnitData.Clone(),
                           Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                           detailRecord,
                           GetCustomerCode(detailRecord)
                        );

                        beforeDetail.RealGoodsUnitData.GoodsPriceList = pliceList;

                        // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応 ---------------------------->>>>>
                        //this._beforeScmGoodsUnitDataList.Add(beforeDetail.Clone());
                        string key = detailRecord.ToKey();
                        if (!BeforeSCMGoodsUnitDataMap.ContainsKey(key))
                        {
                            BeforeSCMGoodsUnitDataMap.Add(key, new List<SCMGoodsUnitData>());
                        }
                        BeforeSCMGoodsUnitDataMap[key].Add(beforeDetail.Clone());
                        // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応 ----------------------------<<<<<
                    }
                }
                // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応 ---------------------------->>>>>
                // 変更前売価計算
                //CalclateUnitPrice(detailRecord, BeforeSCMGoodsUnitDataList);
                CalclateUnitPriceForBeforeGoodsUnitDataList(detailRecord);
                // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応 ----------------------------<<<<<
            }
        }

        #endregion // </回答用SCM情報付商品連結データ>
        // ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------<<<<<

        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
        #region 削除(SCM改良の為)
        //#region <SCM品目設定マスタ>

        ///// <summary>SCM品目設定マスタのアクセサ</summary>
        //private SCMPrtSettingAgent _scmPrtSettingDB;
        ///// <summary>SCM品目設定マスタのアクセサを取得します。</summary>
        //protected SCMPrtSettingAgent ScmPrtSettingDB
        //{
        //    get
        //    {
        //        if (_scmPrtSettingDB == null)
        //        {
        //            _scmPrtSettingDB = new SCMPrtSettingAgent();
        //        }
        //        return _scmPrtSettingDB;
        //    }
        //}

        //#endregion // </SCM品目設定マスタ>
        #endregion

        #region <自動回答品目設定マスタ>

        /// <summary>自動回答品目設定マスタのアクセサ</summary>
        private AutoAnsItemStAgent _autoAnsItemStDB;
        /// <summary>自動回答品目設定マスタのアクセサを取得します。</summary>
        protected AutoAnsItemStAgent AutoAnsItemStDB
        {
            get
            {
                if (_autoAnsItemStDB == null)
                {
                    _autoAnsItemStDB = new AutoAnsItemStAgent();
                }
                return _autoAnsItemStDB;
            }
        }

        #endregion // </自動回答品目設定マスタ>
        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

        #region <価格系算出>

        /// <summary>価格系算出</summary>
        private CalculatorAgent _calculator;
        /// <summary>価格系算出を取得します。</summary>
        protected CalculatorAgent Calculator
        {
            get
            {
                if (_calculator == null)
                {
                    _calculator = new CalculatorAgent();
                }
                return _calculator;
            }
        }

        #endregion // </価格系算出>

        #region <SCM優先設定マスタ>

        /// <summary>SCM優先設定マスタのアクセサ</summary>
        private SCMPrioritySettingAgent _prioritySettingDB;
        /// <summary>SCM優先設定マスタのアクセサを取得します。</summary>
        protected SCMPrioritySettingAgent PrioritySettingDB
        {
            get
            {
                if (_prioritySettingDB == null)
                {
                    _prioritySettingDB = new SCMPrioritySettingAgent();
                }
                return _prioritySettingDB;
            }
        }

        #endregion // </SCM優先設定マスタ>

        // --- Add 2011/07/14 duzg for 自動回答できる品目を委託在庫分以外も可能 --->>>
        #region <SCM全体設定マスタ>
        /// <summary>SCM全体設定マスタのアクセサ</summary>
        private SCMTtlStAgent _ttlStSettingDB;
        /// <summary>SCM全体設定マスタのアクセサを取得します。</summary>
        //>>>2012/04/20
        //protected SCMTtlStAgent TtlStSettingDB
        public SCMTtlStAgent TtlStSettingDB
        //<<<2012/04/20
        {
            get
            {
                if (_ttlStSettingDB == null)
                {
                    _ttlStSettingDB = new SCMTtlStAgent();
                }
                return _ttlStSettingDB;
            }
        }

        #endregion // </SCM全体設定マスタ>
        // --- Add 2011/07/14 duzg for 自動回答できる品目を委託在庫分以外も可能 ---<<<

        // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
        #region <売上全体設定>

        /// <summary>
        /// 売上全体設定マスタを取得します。
        /// </summary>
        protected static SalesTtlStAgent SalesTtlStDB
        {
            get { return SalesTtlStServer.Singleton.Instance; }
        }

        #endregion // </売上全体設定>
        // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<

        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２対応 14.明細取込区分の更新方法を改良対応 ---------------------------------->>>>>
        #region <SCM受発注明細データ（問合せ・発注）>

        private List<ScmOdDtInq> _scmOdDtInqList = new List<ScmOdDtInq>();
        /// <summary>
        ///  SCM受発注明細データ（問合せ・発注）を取得します
        /// </summary>
        public List<ScmOdDtInq> ScmOdDtInqList
        {
            get
            {
                return this._scmOdDtInqList;
            }
        }

        #endregion // <SCM受発注明細データ（問合せ・発注）>

        #region <SCM受発注データ（車両情報）>
        List<ScmOdDtCar> _scmOdDtCarList = new List<ScmOdDtCar>();
        /// <summary>
        ///  SCM受発注データ（車両情報）を取得します
        /// </summary>
        public List<ScmOdDtCar> ScmOdDtCarList
        {
            get
            {
                return this._scmOdDtCarList;
            }
        }

        #endregion // <SCM受発注データ（車両情報）>
        // ADD 2014/05/13 PM-SCM速度改良 フェーズ２対応 14.明細取込区分の更新方法を改良対応 ----------------------------------<<<<<

        // DEL 2015/01/29 SCM高速化Redmine#87対応 ---------------------------------------->>>>>
        #region 削除
        //// ADD 2015/01/28 SCM高速化Redmine#61対応 ---------------------------------------->>>>>
        //#region <提供部品検索コントローラー>

        //private IOfferPartsInfo _iOfferPartsInfo;
        ///// <summary>
        /////  提供部品検索コントローラーを取得します
        ///// </summary>
        //public IOfferPartsInfo IOfferPartsInfo
        //{
        //    get
        //    {
        //        if (_iOfferPartsInfo == null)
        //        {
        //            _iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo(); 
        //        }
        //        return _iOfferPartsInfo;
        //    }
        //}

        //#endregion // <SCM受発注データ（車両情報）>

        //// ADD 2015/01/28 SCM高速化Redmine#61対応 ----------------------------------------<<<<<
        #endregion
        // DEL 2015/01/29 SCM高速化Redmine#87対応 ----------------------------------------<<<<<

        // ADD 2023/08/07 yamaji 売上データ生成時のシステム日付取得対応 ---------------------------------->>>>>
        private DateTime _getServerNowTime;
        private DateTime GetServerNowTime
        {
            get
            {
                if (this._getServerNowTime == DateTime.MinValue)
                {
                    SalesSlipInputAcs salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
                    this._getServerNowTime = salesSlipInputAcs.GetServerNowTime;
                }
                return this._getServerNowTime;
            }
        }
        // ADD 2023/08/07 yamaji 売上データ生成時のシステム日付取得対応 ----------------------------------<<<<<

        
        // --- ADD 吉岡 2012/05/09 №132 ---------->>>>>
        /// <summary>
        /// 締チェック
        /// 　発注の場合のみ、締済み、月次更新済みか否かのチェックを行う
        /// </summary>
        /// <returns>
        /// 締済み又は月次更新済みの場合：false　その他（見積の場合含む）：true
        /// </returns>
        public bool CheckAddUp()
        {
          
            // SCM受注データ取得
            ISCMOrderHeaderRecord headerRec;
            if (HeaderRecordList != null && HeaderRecordList.Count > 0)
            {
                headerRec = HeaderRecordList[0];
            }
            else
            {
                // データが取得できない場合はfalseを返す（先処理のCheckScmOdrDataFixedでチェック済みなので、通常ありえない）
                return false;
            }

            // 発注の場合のみチェックする
            if (headerRec.InqOrdDivCd.Equals(2))
            {

                DateTime CheckDate = headerRec.InquiryDate;                     //yamaji ADD 2023/08/07 初期値に問合せ日付

                if (headerRec.InqOrdDivCd == (int)InqOrdDivCdValue.Ordering)    //yamaji ADD 2023/08/07 発注の場合
                {                                                               //yamaji ADD 2023/08/07
                    CheckDate = GetServerNowTime;   //…サーバー日付            //yamaji ADD 2023/08/07 サーバー日付に変更 データセットと同等の修正
                }                                                               //yamaji ADD 2023/08/07

                // 締日算出モジュール
                TotalDayCalculator _totalDayCalculator = TotalDayCalculator.GetInstance();

                // 月次更新チェック(締済みであればtrueが返ってくる)
//DEL                if (_totalDayCalculator.CheckMonthlyAccRec(headerRec.InqOtherSecCd, headerRec.CustomerCode, headerRec.InquiryDate))  //yamaji DEL 2023/08/07
                if (_totalDayCalculator.CheckMonthlyAccRec(headerRec.InqOtherSecCd, headerRec.CustomerCode, CheckDate))                   //yamaji ADD 2023/08/07
                {
                    return false;
                }

                // 締更新チェック(締済みであればtrueが返ってくる)
//DEL                if (_totalDayCalculator.CheckDmdC(headerRec.InqOtherSecCd, headerRec.CustomerCode, headerRec.InquiryDate))           //yamaji DEL 2023/08/07
                if (_totalDayCalculator.CheckDmdC(headerRec.InqOtherSecCd, headerRec.CustomerCode, CheckDate))           //yamaji DEL 2023/08/07
                {
                    return false;
                }
            }

            return true;
        }
        // --- ADD 吉岡 2012/05/09 №132 ----------<<<<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>
        /// 回答可能チェック
        /// </summary>
        /// <returns></returns>
        public bool CanReply()
        {
            // WebのSCM受発注データ.確定日をチェックする
            if ( this.CheckScmOdrDataFixed() )
            {
                // 確定済みならば回答不可
                return false;
            }

            return true;
        }
        /// <summary>
        /// 受発注データ確定済チェック処理
        /// </summary>
        /// <returns></returns>
        private bool CheckScmOdrDataFixed()
        {
            bool isFixed = false;

            try
            {
                //------------------------------------------------------------------
                // SCM受注データ取得
                //------------------------------------------------------------------
                ISCMOrderHeaderRecord headerRec;
                if ( HeaderRecordList != null && HeaderRecordList.Count > 0 )
                {
                    headerRec = HeaderRecordList[0];
                }
                else
                {
                    return false;
                }

                // UPD 2014/05/13 PM-SCM速度改良 フェーズ２対応 14.明細取込区分の更新方法を改良対応 ---------------------------------->>>>>
                //int status = SCMWebServer.Singleton.Instance.CheckScmOdrDataFixed(headerRec, out isFixed);
                //if ( status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL )
                //{
                //    return false;
                //}
                List<ScmOdDtInq> scmOdDtInqList;
                List<ScmOdDtCar> scmOdDtCarList;

                // UPD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 ----------------------------------->>>>>
                //int status = SCMWebServer.Singleton.Instance.CheckScmOdrDataFixed(headerRec, out isFixed, out scmOdDtInqList, out scmOdDtCarList);
                List<ISCMOrderHeaderRecord> scmHeaderList = new List<ISCMOrderHeaderRecord>();
                scmHeaderList.AddRange(HeaderRecordList);
                int status = SCMWebServer.Singleton.Instance.CheckScmOdrDataFixed(scmHeaderList, out isFixed, out scmOdDtInqList, out scmOdDtCarList);
                // UPD 2014/09/09 ｼｽﾃﾑﾃｽﾄ障害№11,12,13対応 -----------------------------------<<<<<
                if (status != (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return false;
                }
                else
                {
                    if (scmOdDtInqList != null && scmOdDtInqList.Count != 0) this._scmOdDtInqList = scmOdDtInqList;
                    if (scmOdDtCarList != null && scmOdDtCarList.Count != 0) this._scmOdDtCarList = scmOdDtCarList;
                }
                // UPD 2014/05/13 PM-SCM速度改良 フェーズ２対応 14.明細取込区分の更新方法を改良対応 ----------------------------------<<<<<
            }
            catch ( Exception ex )
            {
            }

            return isFixed;
        }
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

        /// <summary>
        /// 自動回答が可能か判断します。
        /// </summary>
        /// <remarks>
        /// 自動回答可能な明細データが1件以上あれば<c>true</c>(可能)を返します。
        /// </remarks>
        /// <returns>
        /// <c>true</c> :自動回答が可能です。<br/>
        /// <c>false</c>:自動回答が不可能です。
        /// </returns>
        public bool CanReplyAutomatically()
        {
			// -- Add St 2012.04.05 30182 R.Tachiya --
			// PccCmpnyStWork取得
			if (this.DetailRecordList.Count != 0)
			{
				SCMOrderDetailRecordType sCMOrderDetailRecordType = this.DetailRecordList[0];
				this.pccCmpnyStWork = SCMSearcher.searchPccCmpnyStList(
					sCMOrderDetailRecordType.InqOriginalEpCd.Trim(),//@@@@20230303
					sCMOrderDetailRecordType.InqOriginalSecCd,
					sCMOrderDetailRecordType.InqOtherEpCd,
					sCMOrderDetailRecordType.InqOtherSecCd
					);
			}
			// -- Add Ed 2012.04.05 30182 R.Tachiya --

            // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
            //表示区分マスタ取得
            _priceSelectSetAgent = PriceSelectSetAgentServer.Singleton.Instance.FindList(LoginInfoAcquisition.EnterpriseCode);
            //-----------------------------------------------------
            // 得意先掛率グループ情報
            //-----------------------------------------------------
            ArrayList custRateGroupList;
            this._custRateGroupList.Clear();
            if (GetCustomerCode(this.DetailRecordList[0]) != 0)
            {
                this._custRateGroupAcs.Search(out custRateGroupList, this.DetailRecordList[0].InqOtherEpCd, GetCustomerCode(this.DetailRecordList[0]), ConstantManagement.LogicalMode.GetData0);
                if ((custRateGroupList != null) && (custRateGroupList.Count != 0))
                {
                    this._custRateGroupList = new List<CustRateGroup>((CustRateGroup[])custRateGroupList.ToArray(typeof(CustRateGroup)));
                }
            }
            // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<

            int canReplyCount = 0;
            foreach (SCMOrderDetailRecordType detailRecord in DetailRecordList)
            {
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                #region 削除(SCM改良の為)
                //// ADD 2011/08/10 gaofeng >>>
                ////PCCUOEについて自動回答
                //if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                //{
                //    //>>>2012/04/09
                //    //if (CanReplyAutomaticallyForPccuoe(detailRecord))
                //    //{
                //    //    canReplyCount++;
                //    //}
                //    ////>>>2012/02/12
                //    //else
                //    //{
                //    //    _searcher.SearchByGoodsName(detailRecord, SCMSearchedResult.GoodsSearchDivCd.GoodsName);
                //    //    canReplyCount++;
                //    //}
                //    ////<<<2012/02/12

                //    if (((this._searcher.OrgAnswerRecordList == null) || (this._searcher.OrgAnswerRecordList.Count == 0)) &&
                //        (RelationalHeaderMap[detailRecord.ToRelationKey()].InqOrdDivCd == (int)InqOrdDivCd.Order))
                //    {
                //    } 
                //    else
                //    {
                //        if (CanReplyAutomaticallyForPccuoe(detailRecord))
                //        {
                //            canReplyCount++;
                //        }
                //        else
                //        {
                //            _searcher.SearchByGoodsName(detailRecord, SCMSearchedResult.GoodsSearchDivCd.GoodsName);
                //            canReplyCount++;
                //        }
                //    }
                //    //<<<2012/04/09
                //}
                ////SCM自動回答
                //else
                //{
                //// ADD 2011/08/10 gaofeng <<<
                #endregion
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                    if (CanReplyAutomatically(detailRecord))
                    {
                        canReplyCount++;
                    }
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                //} // ADD 2011/08/10 gaofeng
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            }

        #if _ENABLED_MANUAL_DATA_

            // 手動回答と判定されたSCM受注明細データ(問合せ・発注)を
            // 回答用SCM情報付商品連結データのマップに追加
            AddManualSCMDetailDataToSCMGoodsUnitDataMap();

        #endif

            return canReplyCount > 0;
        }
        /// <summary>
        /// Pccuoe自動回答が可能か判断します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>
        /// <c>true</c> :自動回答が可能です。<br/>
        /// <c>false</c>:自動回答が不可能です。
        /// </returns>
        public bool CanReplyAutomaticallyForPccuoe(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            const string METHOD_NAME = "CanReplyAutomaticallyForPccuoe()";   // ログ用

            #region <Guard Phrase>

            if (scmOrderDetailRecord == null) return false;

            if (Searcher.ResultMap.Count.Equals(0))
            {
                // 検索結果が0件の場合、自動回答不可
                #region <Log>

                string msg = "Pccuoeの場合、検索結果が0件の場合、自動回答不可";
                string label = SCMDataHelper.GetLabel(scmOrderDetailRecord);
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                #endregion // </Log>

                return false;
            }
            IList<SCMGoodsUnitData> scmGoodsUnitDataList = ExistsGoodsWithoutSet(scmOrderDetailRecord);
            #endregion // </Guard Phrase>

            //>>>2012/02/12
            // 自動回答品目（SCM品目設定マスタに登録が無い場合、回答なし）
            SCMGoodsUnitDataListPair scmGoodsUnitDataListPair = ExistsGoodsOfReplyingAutomatically(scmOrderDetailRecord);
            if (!scmGoodsUnitDataListPair.Key)
            {
                #region <手動回答>

                //// 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                //if (!ManualSCMDetailRecordMap.ContainsKey(scmOrderDetailRecord.ToKey()))
                //{
                //    ManualSCMDetailRecordMap.Add(scmOrderDetailRecord.ToKey(), scmOrderDetailRecord);

                //    #region <Log>

                //    string msg = "自動回答品目ではない(SCM品目設定マスタに登録が無い または SCM品目設定マスタ.自動回答区分が「0:しない」)ため、手動回答としました。";
                //    string label = SCMDataHelper.GetLabel(scmOrderDetailRecord);
                //    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //    #endregion // </Log>
                //}

                #endregion // </手動回答>

                // 回答用SCM情報付商品連結データのマップを構築
                BuildSCMGoodsUnitDataMap(scmOrderDetailRecord, scmGoodsUnitDataList);

                if (SCMGoodsUnitDataMap[scmOrderDetailRecord.ToKey()].Count != scmGoodsUnitDataList.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //<<<2012/02/12

            // 回答用SCM情報付商品連結データのマップを構築
            //>>>2012/02/12
            //BuildSCMGoodsUnitDataMap(scmOrderDetailRecord, scmGoodsUnitDataList, false);
            BuildSCMGoodsUnitDataMap(scmOrderDetailRecord, scmGoodsUnitDataListPair.Value);
            //<<<212/02/12

            return true;

        }
        /// <summary>
        /// 自動回答が可能か判断します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>
        /// <c>true</c> :自動回答が可能です。<br/>
        /// <c>false</c>:自動回答が不可能です。
        /// </returns>
        /// <remarks>
        /// <br>Update Note : 2018/07/26 陳艶丹</br>
        /// <br>管理番号    : 11470103-00</br>
        /// <br>            : SF側セット子品番発注時の障害対応</br>
        /// </remarks>
        public bool CanReplyAutomatically(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            const string METHOD_NAME = "CanReplyAutomatically()";   // ログ用

            #region <Guard Phrase>

            if (scmOrderDetailRecord == null) return false;

            // 検索結果が0件の場合、自動回答不可
            if (Searcher.ResultMap.Count.Equals(0)) return false;

            #endregion // </Guard Phrase>

            // 相場回答は自動、手動問わず行うため、←2010/04/15 相場回答は自動回答できる場合のみに変更
            // 相場回答用のSCM情報付商品連結データを構築
            IList<SCMGoodsUnitData> scmGoodsUnitDataWithSobaList = GetSCMGoodsUnitDataListHavingSobaResponse(
                scmOrderDetailRecord
            );
            // ADD 2010/04/15 相場回答は自動回答できる場合のみ ---------->>>>>
            // 自動回答が可能フラグ（相場回答は自動回答できる場合だけ）
            bool canReplySoba = true;
            // ADD 2010/04/15 相場回答は自動回答できる場合のみ ----------<<<<<

            try // 2010/03/30 Add         
            {   // 2010/03/30 Add
                if (!ListUtil.IsNullOrEmpty(scmGoodsUnitDataWithSobaList))
                {
                    // 2010/03/30 追加するタイミングは最後 >>>
                    //// 回答用SCM情報付商品連結データのマップを構築
                    //BuildSCMGoodsUnitDataMap(scmOrderDetailRecord, scmGoodsUnitDataWithSobaList, true);
                    // 2010/03/30 Del <<<

            #if _SOBA_ONLY_MODE_
                return true;    // 相場回答のテスト用
            #endif
                }

                // 商品種別（相場、中古(リサイクル)の場合、手動回答）
                if (IsMarketAtGoodsDivCd(scmOrderDetailRecord))
                {
                    #region <手動回答>

                    // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                    if (!ManualSCMDetailRecordMap.ContainsKey(scmOrderDetailRecord.ToKey()))
                    {
                        ManualSCMDetailRecordMap.Add(scmOrderDetailRecord.ToKey(), scmOrderDetailRecord);

                        #region <Log>

                        string msg = "商品種別が相場または中古(リサイクル)のため、手動回答としました。";
                        string label = SCMDataHelper.GetLabel(scmOrderDetailRecord);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                        #endregion // </Log>
                    }

                    #endregion // </手動回答>

                    canReplySoba = false;   // ADD 2010/04/15 相場回答は自動回答できる場合のみ

                    return false;
                }

                // 2011/01/11 Add >>>
                // 検索処理正常終了（正常終了していない場合、手動回答）(2012/11/09 コメント記述変更)
                if (!IsSearchNormal(scmOrderDetailRecord))
                {
                    #region <手動回答>

                    // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                    if (!ManualSCMDetailRecordMap.ContainsKey(scmOrderDetailRecord.ToKey()))
                    {
                        ManualSCMDetailRecordMap.Add(scmOrderDetailRecord.ToKey(), scmOrderDetailRecord);

                        #region <Log>

                        string msg = "検索でエラーになっていた為、手動回答としました。";
                        string label = SCMDataHelper.GetLabel(scmOrderDetailRecord);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                        #endregion // </Log>
                    }

                    #endregion // </手動回答>

                    canReplySoba = false;   // ADD 2010/04/15 相場回答は自動回答できる場合のみ

                    return !ListUtil.IsNullOrEmpty(scmGoodsUnitDataWithSobaList);
                }

                // 2011/01/11 Add <<<

                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                #region 削除(SCM改良の為)
                //// 純正1品番（複数品番の場合、手動回答）
                //if (!IsOnePureGoods(scmOrderDetailRecord))
                //{
                //    #region <手動回答>

                //    // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                //    if (!ManualSCMDetailRecordMap.ContainsKey(scmOrderDetailRecord.ToKey()))
                //    {
                //        ManualSCMDetailRecordMap.Add(scmOrderDetailRecord.ToKey(), scmOrderDetailRecord);

                //        #region <Log>

                //        string msg = "純正1品番ではないため(複数品番のため)、手動回答としました。";
                //        string label = SCMDataHelper.GetLabel(scmOrderDetailRecord);
                //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                //        #endregion // </Log>
                //    }

                //    #endregion // </手動回答>

                //    canReplySoba = false;   // ADD 2010/04/15 相場回答は自動回答できる場合のみ

                //    return !ListUtil.IsNullOrEmpty(scmGoodsUnitDataWithSobaList);
                //}
                #endregion
                // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                // UPD 2014/11/27 SCM仕掛一覧№10700対応 ------------------------------------->>>>>
                // ダイレクト発注の時は手動回答
                //if (((this._searcher.OrgAnswerRecordList == null) || (this._searcher.OrgAnswerRecordList.Count == 0)) &&
                //    (RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].InqOrdDivCd == (int)InqOrdDivCd.Order))
                //// 前回回答データより問合せ行番号単位で前回回答データが存在するかチェック
                bool retAnswer = false;
                foreach (ISCMOrderAnswerRecord rec in this._searcher.OrgAnswerRecordList)
                {
                    if (rec.InqOriginalEpCd.Trim() == scmOrderDetailRecord.InqOriginalEpCd.Trim() && //@@@@20230303
                        rec.InqOriginalSecCd == scmOrderDetailRecord.InqOriginalSecCd &&
                        rec.InqOtherEpCd == scmOrderDetailRecord.InqOtherEpCd &&
                        rec.InqOtherSecCd == scmOrderDetailRecord.InqOtherSecCd &&
                        rec.InquiryNumber == scmOrderDetailRecord.InquiryNumber &&
                        // --- UPD 2018/07/26 陳艶丹  SF側セット子品番発注時の障害対応-------------------->>>>>
                        //rec.InqRowNumber == scmOrderDetailRecord.InqRowNumber)
                        ((rec.InqRowNumber == scmOrderDetailRecord.InqRowNumber) ||
                        (rec.GoodsMakerCd == scmOrderDetailRecord.SetPartsMkrCd && 
                        rec.GoodsNo == scmOrderDetailRecord.SetPartsNumber)))
                    　　// --- UPD 2018/07/26 陳艶丹  SF側セット子品番発注時の障害対応--------------------<<<<<
                    {
                        retAnswer = true;
                        break;
                    }
                }
                // ダイレクト発注の時は手動回答
                if (retAnswer == false &&
                    (RelationalHeaderMap[scmOrderDetailRecord.ToRelationKey()].InqOrdDivCd == (int)InqOrdDivCd.Order))
                // UPD 2014/11/27 SCM仕掛一覧№10700対応 -------------------------------------<<<<<
                {
                    #region <手動回答>

                    // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                    if (!ManualSCMDetailRecordMap.ContainsKey(scmOrderDetailRecord.ToKey()))
                    {
                        ManualSCMDetailRecordMap.Add(scmOrderDetailRecord.ToKey(), scmOrderDetailRecord);

                        #region <Log>

                        string msg = "ダイレクト発注のため、手動回答としました。";
                        string label = SCMDataHelper.GetLabel(scmOrderDetailRecord);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                        #endregion // </Log>
                    }

                    #endregion // </手動回答>

                    canReplySoba = false;   // ADD 2010/04/15 相場回答は自動回答できる場合のみ

                    return !ListUtil.IsNullOrEmpty(scmGoodsUnitDataWithSobaList);

                }
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

                // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
                // SCM全体設定マスタ取得
                this._scmTtlSt = TtlStSettingDB.Find(
                        scmOrderDetailRecord.InqOtherEpCd,
                        scmOrderDetailRecord.InqOtherSecCd
                        );
                this._autoAnsHourDspDiv = this._scmTtlSt.AutoAnsHourDspDiv;   // 自動回答時表示区分
                int priceSelectDiv = 0;

                // 前回見積データ取得
                List<ISCMOrderAnswerRecord> originalAnswerList = null;
                List<ISCMOrderDetailRecord> originalDetailList = null;
                if (HeaderRecordList != null && HeaderRecordList.Count != 0)
                {
                    this.Searcher.GetOriginalDataList(HeaderRecordList[0], out originalDetailList, out originalAnswerList);
                }
                // 前回見積データが存在しない時、表示区分による自動回答判定を行う
                if (originalDetailList == null || originalDetailList[0].AcptAnOdrStatus != (int)AcptAnOdrStatus.Estimate)
                {
                    // 自動回答時表示区分：「PM設定に従う」場合
                    if (this._autoAnsHourDspDiv == 1)
                    {
                        // 売上全体設定マスタを取得
                        SalesTtlSt salesTotalSetting = SalesTtlStDB.Find(
                                                       scmOrderDetailRecord.InqOtherEpCd,
                                                       scmOrderDetailRecord.InqOtherSecCd
                                                       );

                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                        // 自動回答品目設定マスタ取得
                        List<AutoAnsItemSt> foundAutoAnsItemStList = AutoAnsItemStDB.Search(
                            Searcher.ResultMap[scmOrderDetailRecord.ToKey()].GoodsUnitDataList,
                            GetCustomerCode(scmOrderDetailRecord)
                        );
                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>

                        // 回答対象に1件でも表示区分マスタの情報が存在しない場合、手動回答
                        foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[scmOrderDetailRecord.ToKey()].GoodsUnitDataList)
                        {
                            // 優良品の時のみ
                            if (!IsPureAtOfferKubun(goodsUnitData))
                            {
                                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                                #region 削除(SCM改良のため)
                                //// SCM品目設定マスタを検索
                                //IList<SCMPrtSetting> foundSCMPrtSettingList = ScmPrtSettingDB.Find(
                                //    goodsUnitData,
                                //    GetCustomerCode(scmOrderDetailRecord)
                                //);

                                //// SCM品目設定マスタに登録がない場合、次の品目へ
                                //if (ListUtil.IsNullOrEmpty(foundSCMPrtSettingList))
                                //{
                                //    continue;
                                //}

                                //// SCM品目設定マスタの自動回答区分が「しない」時は次の品目へ
                                //bool autoAnswerFlag = false;
                                //foreach (SCMPrtSetting scmPrtSettingRecord in foundSCMPrtSettingList)
                                //{
                                //    if (scmPrtSettingRecord.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.None))
                                //    {
                                //        autoAnswerFlag = true;
                                //        break;
                                //    }
                                //}
                                //if (autoAnswerFlag)
                                //{
                                //    continue;
                                //}
                                #endregion

                                // 自動回答品目設定マスタを検索
                                AutoAnsItemSt selectAutoAnsItemSt = AutoAnsItemStDB.Find(
                                    foundAutoAnsItemStList,
                                    goodsUnitData,
                                    GetCustomerCode(scmOrderDetailRecord)
                                );
                                // 自動回答品目設定マスタに登録がない場合、または自動回答しない場合、次の品目へ
                                if (selectAutoAnsItemSt == null || 
                                   (selectAutoAnsItemSt != null && selectAutoAnsItemSt.AutoAnswerDiv == (int)AutoAnsItemStAcs.AutoAnswerDiv.None))
                                {
                                    continue;
                                }
                                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>

                                // 売上全体設定マスタの標準価格選択表示区分が「する」の時
                                if (salesTotalSetting.PriceSelectDispDiv == 1)
                                {
                                    //価格表示区分取得
                                    PriceSelectSetAgentServer.Singleton.Instance.GetDisplayDiv(_priceSelectSetAgent, goodsUnitData.GoodsMakerCd, goodsUnitData.BLGoodsCode, GetCustomerCode(scmOrderDetailRecord), GetCustRateGroupCode(goodsUnitData.GoodsMakerCd), out priceSelectDiv);
                                    if ((priceSelectDiv == -1))
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    priceSelectDiv = 0;
                                }
                            }
                        }
                    }

                }
                // 売上全体設定マスタの表示区分プロセスが「する」で表示区分マスタの設定がない場合、手動回答
                if (priceSelectDiv == -1)
                {
                    #region <手動回答>

                    // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                    if (!ManualSCMDetailRecordMap.ContainsKey(scmOrderDetailRecord.ToKey()))
                    {
                        ManualSCMDetailRecordMap.Add(scmOrderDetailRecord.ToKey(), scmOrderDetailRecord);

                        #region <Log>

                        string msg = "表示区分プロセスが「する」ですが表示区分マスタの設定がないため、手動回答としました。";
                        string label = SCMDataHelper.GetLabel(scmOrderDetailRecord);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                        #endregion // </Log>
                    }

                    #endregion // </手動回答>

                    canReplySoba = false;   // ADD 2010/04/15 相場回答は自動回答できる場合のみ

                    return !ListUtil.IsNullOrEmpty(scmGoodsUnitDataWithSobaList);
                }
                // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<

                // 自動回答品目（自動回答品目設定マスタに登録が無い場合、手動回答）(2012/11/09コメント内容変更)
                // ※同時にSCM情報付商品連結データを構築
                SCMGoodsUnitDataListPair scmGoodsUnitDataListPair = ExistsGoodsOfReplyingAutomatically(scmOrderDetailRecord);
                if (!scmGoodsUnitDataListPair.Key)
                {
                    #region <手動回答>

                    // 手動回答と判定されたSCM受注明細データ(問合せ・発注)のマップへ追加
                    if (!ManualSCMDetailRecordMap.ContainsKey(scmOrderDetailRecord.ToKey()))
                    {
                        ManualSCMDetailRecordMap.Add(scmOrderDetailRecord.ToKey(), scmOrderDetailRecord);

                        #region <Log>

                        string msg = "自動回答品目ではない(SCM品目設定マスタに登録が無い または SCM品目設定マスタ.自動回答区分が「0:しない」)ため、手動回答としました。";
                        string label = SCMDataHelper.GetLabel(scmOrderDetailRecord);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg + Environment.NewLine + label));

                        #endregion // </Log>
                    }

                    #endregion // </手動回答>

                    // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
                    // UPD 2015/06/18 商品保証課Redmine#3939対応 ------------------------------------->>>>>
                    ////問合せ時でSCM全体設定マスタの自動回答区分（問合せ）が「しない（手動）」以外の時
                    ////且つ該当無自動回答区分が「する」時、用品入力処理を行う
                    //if (scmOrderDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Inquiry) &&
                    //    !this._scmTtlSt.AutoAnsInquiryDiv.Equals((int)AutoAnsInquiryDiv.None) &&
                    //    this._scmTtlSt.FuwioutAutoAnsDiv.Equals((int)FuwioutAutoAnsDiv.Auto))
                    // 問合せ時でSCM全体設定マスタの自動回答区分（問合せ）が「しない（手動）」以外の時
                    // 且つ該当無し自動回答区分が「する」時
                    // 且つBLコード検索結果の時(該当なしBLコード検索時は検索タイプが用品入力になります)、用品入力処理を行う
                    if (scmOrderDetailRecord.InqOrdDivCd.Equals((int)InqOrdDivCd.Inquiry) &&
                        !this._scmTtlSt.AutoAnsInquiryDiv.Equals((int)AutoAnsInquiryDiv.None) &&
                        this._scmTtlSt.FuwioutAutoAnsDiv.Equals((int)FuwioutAutoAnsDiv.Auto) &&
                        (Searcher.ResultMap.ContainsKey(scmOrderDetailRecord.ToKey()) && Searcher.ResultMap[scmOrderDetailRecord.ToKey()].SearchedType.Equals(SCMSearchedResult.GoodsSearchDivCd.GoodsName))
                       )
                    // UPD 2015/06/18 商品保証課Redmine#3939対応 -------------------------------------<<<<<
                    {
                        IList<SCMGoodsUnitData> scmGoodsUnitDataList = ExistsGoodsWithoutSet(scmOrderDetailRecord);
                        // 回答用SCM情報付商品連結データのマップを構築
                        BuildSCMGoodsUnitDataMap(scmOrderDetailRecord, scmGoodsUnitDataList);

                        if (SCMGoodsUnitDataMap[scmOrderDetailRecord.ToKey()].Count != scmGoodsUnitDataList.Count)
                        {
                            return true;
                        }
                        else
                        {
                            _searcher.SearchByGoodsName(scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd.GoodsName);
                            return true;
                        }
                    }
                    // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

                    canReplySoba = false;   // ADD 2010/04/15 相場回答は自動回答できる場合のみ

                    return !ListUtil.IsNullOrEmpty(scmGoodsUnitDataWithSobaList);
                }
                // 回答判定処理としてはここまででよい

                // 回答用SCM情報付商品連結データのマップを構築
                BuildSCMGoodsUnitDataMap(scmOrderDetailRecord, scmGoodsUnitDataListPair.Value);

                return true;

            }   // 2010/03/30 Add
            // 2010/03/30 Add >>>
            finally
            {
                if (!ListUtil.IsNullOrEmpty(scmGoodsUnitDataWithSobaList))
                {
                    if (canReplySoba)   // ADD 2010/04/15 相場回答は自動回答できる場合のみ
                    {
                        // 回答用SCM情報付商品連結データのマップを構築
                        BuildSCMGoodsUnitDataMap(scmOrderDetailRecord, scmGoodsUnitDataWithSobaList, true);
                    }
                }
            }
            // 2010/03/30 Add <<<
        }

        // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
        /// <summary>
        ///  得意先掛率グループコード取得処理
        /// </summary>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <returns></returns>
        private int GetCustRateGroupCode(int goodsMakerCode)
        {
            int pureCode = (goodsMakerCode <= 999) ? 0 : 1; // 0:純正 1:優良

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

            return -1;
        }
        // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<

        #region <相場回答用のSCM情報付商品連結データ構築>

        /// <summary>
        /// 相場情報付き回答用SCM情報付商品連結データのリストを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>相場情報付き回答用SCM情報付商品連結データのリスト</returns>
        protected virtual IList<SCMGoodsUnitData> GetSCMGoodsUnitDataListHavingSobaResponse(SCMOrderDetailRecordType detailRecord)
        {
            return new List<SCMGoodsUnitData>();
        }

        #endregion // </相場回答用のSCM情報付商品連結データ構築>

        #region <回答用SCM情報付商品連結データのマップを構築>

        /// <summary>
        /// 回答用SCM情報付商品連結データのマップを構築します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        protected void BuildSCMGoodsUnitDataMap(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            BuildSCMGoodsUnitDataMap(detailRecord, scmGoodsUnitDataList, false);
        }

        /// <summary>
        /// 回答用SCM情報付商品連結データのマップを構築します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <param name="isSobaData">相場データであるかのフラグ</param>
        protected void BuildSCMGoodsUnitDataMap(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList,
            bool isSobaData
        )
        {
            const string METHOD_NAME = "BuildSCMGoodsUnitDataMap";  // ログ用 // ADD 2011/08/10

            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№10.単価計算呼出回数改良 ---------------------------------->>>>>

            #region 速度改善のため削除
            //// ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------>>>>>
            //// 変更前SCM情報付商品連結データ退避
            //AddToBeforeSCMGoodsUnitDataList(detailRecord, scmGoodsUnitDataList);
            //// ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------<<<<<

            //// 各種価格算出→演算結果は回答データおよび売上データ、優先設定適用での価格系の適用で使用される
            //CalclateUnitPrice(detailRecord, scmGoodsUnitDataList);

            //// ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------>>>>>
            //// 優良品単価の再設定
            //SetListPrice(detailRecord, scmGoodsUnitDataList);
            //// ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------<<<<<

            //// 相場情報適用(自動回答モードの場合のみ)…相場回答は自動、手動問わず行うため、廃止
            //// キャンペーン情報適用
            //TakeCampaignInformation(detailRecord, scmGoodsUnitDataList);

            //// 相場回答用のSCM情報付商品連結データの場合、優先設定の適用を行わない
            //if (isSobaData)
            //{
            //    // 回答用SCM情報付商品連結データに追加
            //    AddToSCMGoodsUnitDataMap(detailRecord, scmGoodsUnitDataList);
            //}
            //else
            //{
            //    // -- DEL 2011/08/10   ------ >>>>>>
            //    /*// 優先設定適用
            //    selectedSCMGoodsUnitDataList = SelectSCMGoodsUnitDataBySCMPrioritySetteing(
            //        detailRecord,
            //        scmGoodsUnitDataList
            //    );
            //    // 回答用SCM情報付商品連結データに追加
            //    AddToSCMGoodsUnitDataMap(detailRecord, selectedSCMGoodsUnitDataList);*/
            //    // -- DEL 2011/08/10   ------ <<<<<


            //    // ----- ADD 2011/08/10 ----- >>>>>
            //    // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
            //    //if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            //    //{
            //    // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
            //        // PCC自社設定取得
            //        //PccCmpnyStWork pccCmpnyStWork = SCMSearcher.searchPccCmpnyStList(detailRecord.InqOriginalEpCd, detailRecord.InqOriginalSecCd, detailRecord.InqOtherEpCd, detailRecord.InqOtherSecCd);// -- Del 2012.04.05 30182 R.Tachiya --
            //        // -- Add St 2012.04.05 30182 R.Tachiya --
            //        if (pccCmpnyStWork == null)
            //        {
            //            this.pccCmpnyStWork = SCMSearcher.searchPccCmpnyStList(detailRecord.InqOriginalEpCd, detailRecord.InqOriginalSecCd, detailRecord.InqOtherEpCd, detailRecord.InqOtherSecCd);
            //        }
            //        else if (
            //            this.pccCmpnyStWork.InqOriginalEpCd != detailRecord.InqOriginalEpCd ||
            //            this.pccCmpnyStWork.InqOriginalSecCd != detailRecord.InqOriginalSecCd ||
            //            this.pccCmpnyStWork.InqOtherEpCd != detailRecord.InqOtherEpCd ||
            //            this.pccCmpnyStWork.InqOtherSecCd != detailRecord.InqOtherSecCd
            //            )
            //        {
            //            this.pccCmpnyStWork = SCMSearcher.searchPccCmpnyStList(detailRecord.InqOriginalEpCd, detailRecord.InqOriginalSecCd, detailRecord.InqOtherEpCd, detailRecord.InqOtherSecCd);
            //        }
            //        // -- Add Ed 2012.04.05 30182 R.Tachiya --
					
            //        foreach (SCMGoodsUnitData sCMGoodsUnitData in scmGoodsUnitDataList)
            //        {
            //            sCMGoodsUnitData.PccCmpnySt = pccCmpnyStWork;
            //        }
            //    // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
            //    //}
            //    // DEL 2012/12/12 2013/01/16配信 SCM改良№10423対応 ---------------------------------->>>>>
            //    // ----- ADD 2011/08/10 ----- <<<<<
            //    IList<SCMGoodsUnitData> selectedSCMGoodsUnitDataList = new List<SCMGoodsUnitData>();

            //    #region PCCUOEの場合
            //    // -- ADD 2011/08/10   ------ >>>>>>
            //    //PCCUOEの場合
            //    if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            //    {
            //        //1:問合せの場合、優先設定適用を行う
            //        if (detailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry)
            //        {
            //            // PCCUOE優先設定適用
            //            selectedSCMGoodsUnitDataList = SelectPCCUOEGoodsUnitDataBySCMPrioritySetteing(
            //                detailRecord,
            //                scmGoodsUnitDataList
            //            );
            //        }
            //        else
            //        {
            //            selectedSCMGoodsUnitDataList = scmGoodsUnitDataList;
            //        }
            //        // ----- ADD 2011/08/10 ----- >>>>>
            //        // PCCUOEの在庫確認の場合、セット商品の部品情報を取得する
            //        if ((detailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry
            //            && (((SCMSearchedResult)Searcher.ResultMap[detailRecord.ToKey()]).SearchedType == SCMSearchedResult.GoodsSearchDivCd.BLCode)
            //            || ((SCMSearchedResult)Searcher.ResultMap[detailRecord.ToKey()]).SearchedType == SCMSearchedResult.GoodsSearchDivCd.GoodsNo))
            //        {
            //            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            //            // 自動回答品目設定マスタを取得
            //            List<AutoAnsItemSt> foundAutoAnsItemStList = AutoAnsItemStDB.Search(selectedSCMGoodsUnitDataList, GetCustomerCode(detailRecord));
            //            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

            //            // セット子商品の関連情報取得
            //            foreach (SCMGoodsUnitData parentScmGoodsUnitData in selectedSCMGoodsUnitDataList)
            //            {
            //                string key = parentScmGoodsUnitData.RealGoodsUnitData.GoodsNo + "/"
            //                            + parentScmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd.ToString() + "/"
            //                            + detailRecord.ToKey();
            //                if (SetGoodsUnitDataMap.ContainsKey(key))
            //                {
            //                    foreach (GoodsUnitData goodsUnitData in SetGoodsUnitDataMap[key])
            //                    {
            //                        goodsUnitData.SectionCode = detailRecord.InqOtherSecCd; // ADD 2011/09/19
            //                        SCMGoodsUnitData scmGoodsUnitData = new SCMGoodsUnitData(
            //                            goodsUnitData,
            //                            Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
            //                            detailRecord,
            //                            GetCustomerCode(detailRecord)
            //                        );
            //                        scmGoodsUnitData.AcceptOrOrderKind = parentScmGoodsUnitData.AcceptOrOrderKind;
            //                        scmGoodsUnitData.PccCmpnySt = parentScmGoodsUnitData.PccCmpnySt;
            //                        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            //                        #region 削除(SCM改良の為)
            //                        //// --- ADD 吉岡 2012/05/18 №156 ---------->>>>>
            //                        //// SCM品目設定マスタを検索
            //                        //IList<SCMPrtSetting> foundSCMPrtSettingList = ScmPrtSettingDB.Find(
            //                        //    goodsUnitData,
            //                        //    GetCustomerCode(detailRecord)
            //                        //);
            //                        //// SCM品目設定マスタ.自動回答区分が"しない"以外の場合、自動回答品目であることを設定
            //                        //foreach (SCMPrtSetting scmPrtSettingRecord in foundSCMPrtSettingList)
            //                        //{
            //                        //    // SCM品目設定を保持
            //                        //    scmGoodsUnitData.SCMItemConfig = scmPrtSettingRecord;

            //                        //    if (IsReplyAutomaticallyAtAutoAnswerDiv(scmPrtSettingRecord))
            //                        //    {
            //                        //        // 自動回答品目であることを設定
            //                        //        scmGoodsUnitData.CanReplyAutomatically = true;
            //                        //    }
            //                        //}
            //                        //// --- ADD 吉岡 2012/05/18 №156 ----------<<<<<
            //                        #endregion

            //                        // 自動回答品目設定マスタを検索
            //                        AutoAnsItemSt autoAnsItemSt = AutoAnsItemStDB.Find(foundAutoAnsItemStList,
            //                                                                           goodsUnitData,
            //                                                                           GetCustomerCode(detailRecord));
            //                        // UPD 2012/11/21 2012/12/12配信予定システムテスト障害№56対応 ------------------------->>>>>
            //                        //// 自動回答品目設定を保持
            //                        //scmGoodsUnitData.AutoAnsItemStConfig = autoAnsItemSt;

            //                        //if (IsReplyAutomaticallyAtAutoAnswerDiv(autoAnsItemSt))
            //                        //{
            //                        //    // 自動回答品目であることを設定
            //                        //    scmGoodsUnitData.CanReplyAutomatically = true;
            //                        //}
            //                        if (autoAnsItemSt != null)
            //                        {
            //                            // 自動回答品目設定を保持
            //                            scmGoodsUnitData.AutoAnsItemStConfig = autoAnsItemSt;

            //                            if (IsReplyAutomaticallyAtAutoAnswerDiv(autoAnsItemSt))
            //                            {
            //                                // 自動回答品目であることを設定
            //                                scmGoodsUnitData.CanReplyAutomatically = true;
            //                            }
            //                        }
            //                        // UPD 2012/11/21 2012/12/12配信予定システムテスト障害№56対応 -------------------------<<<<<<
            //                        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
            //                        parentScmGoodsUnitData.SetSCMGoodsUnitDataList.Add(scmGoodsUnitData);
            //                    }
            //                }

            //                // セット子商品の関連情報補正
            //                // 各種価格算出→演算結果は回答データおよび売上データ、優先設定適用での価格系の適用で使用される
            //                CalclateUnitPrice(detailRecord, parentScmGoodsUnitData.SetSCMGoodsUnitDataList);

            //                // キャンペーン情報適用
            //                TakeCampaignInformation(detailRecord, parentScmGoodsUnitData.SetSCMGoodsUnitDataList);
            //            }
            //        }
            //        // ----- ADD 2011/08/10 ----- <<<<<

            //    }
            //    //SCMの場合
            //    else
            //    {
            //        #region SCMの場合

            //        // 優先設定適用
            //        selectedSCMGoodsUnitDataList = SelectSCMGoodsUnitDataBySCMPrioritySetteing(
            //            detailRecord,
            //            scmGoodsUnitDataList
            //        );
            //        // 回答用SCM情報付商品連結データに追加
            //        //AddToSCMGoodsUnitDataMap(detailRecord, selectedSCMGoodsUnitDataList);
            //        #endregion
            //    }
                

            //    #endregion
            #endregion //速度改善のため削除

            // 価格計算前のPCC優先設定による部品絞込み処理
            IList<SCMGoodsUnitData> beforeCalcSCMGoodsUnitDataList = new List<SCMGoodsUnitData>();
            // BLPの時
            if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            {
                //1:問合せの場合、優先設定適用を行う
                if (detailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry)
                {
                    // PCCUOE優先設定適用
                    beforeCalcSCMGoodsUnitDataList = SelectPCCUOEGoodsUnitDataBySCMPrioritySetteingForStock(
                        detailRecord,
                        scmGoodsUnitDataList
                    );
                }
                else
                {
                    beforeCalcSCMGoodsUnitDataList = scmGoodsUnitDataList;
                }
            }
            // 部品問合せの場合
            else
            {
                // UPD 2014/11/10 PM-SCM優先案件11月対応分 ---------------------------------->>>>>
                //// 優先設定適用
                //beforeCalcSCMGoodsUnitDataList = SelectSCMGoodsUnitDataBySCMPrioritySetteingForStock(
                //    detailRecord,
                //    scmGoodsUnitDataList
                //);
                // 問合せの場合、優先設定適用を行う
                if (detailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry)
                {
                    // 優先設定適用
                    beforeCalcSCMGoodsUnitDataList = SelectSCMGoodsUnitDataBySCMPrioritySetteingForStock(
                        detailRecord,
                        scmGoodsUnitDataList
                    );
                }
                else
                {
                    beforeCalcSCMGoodsUnitDataList = scmGoodsUnitDataList;
                }
                // UPD 2014/11/10 PM-SCM優先案件11月対応分 ----------------------------------<<<<<
            }

            // 変更前SCM情報付商品連結データ退避
            AddToBeforeSCMGoodsUnitDataList(detailRecord, beforeCalcSCMGoodsUnitDataList);

            // 各種価格算出→演算結果は回答データおよび売上データ、優先設定適用での価格系の適用で使用される
            CalclateUnitPrice(detailRecord, beforeCalcSCMGoodsUnitDataList);

            // 優良品単価の再設定
            SetListPrice(detailRecord, beforeCalcSCMGoodsUnitDataList);

            // 相場情報適用(自動回答モードの場合のみ)…相場回答は自動、手動問わず行うため、廃止
            // キャンペーン情報適用
            TakeCampaignInformation(detailRecord, beforeCalcSCMGoodsUnitDataList);

            // 相場回答用のSCM情報付商品連結データの場合、優先設定の適用を行わない
            if (isSobaData)
            {
                // 回答用SCM情報付商品連結データに追加
                AddToSCMGoodsUnitDataMap(detailRecord, beforeCalcSCMGoodsUnitDataList);
            }
            else
            {
                if (pccCmpnyStWork == null)
                {
                    this.pccCmpnyStWork = SCMSearcher.searchPccCmpnyStList(detailRecord.InqOriginalEpCd.Trim(), detailRecord.InqOriginalSecCd, detailRecord.InqOtherEpCd, detailRecord.InqOtherSecCd);//@@@@20230303
                }
                else if (
                    this.pccCmpnyStWork.InqOriginalEpCd.Trim() != detailRecord.InqOriginalEpCd.Trim() || //@@@@20230303
                    this.pccCmpnyStWork.InqOriginalSecCd != detailRecord.InqOriginalSecCd ||
                    this.pccCmpnyStWork.InqOtherEpCd != detailRecord.InqOtherEpCd ||
                    this.pccCmpnyStWork.InqOtherSecCd != detailRecord.InqOtherSecCd
                    )
                {
                    this.pccCmpnyStWork = SCMSearcher.searchPccCmpnyStList(detailRecord.InqOriginalEpCd.Trim(), detailRecord.InqOriginalSecCd, detailRecord.InqOtherEpCd, detailRecord.InqOtherSecCd);//@@@@20230303
                }

                foreach (SCMGoodsUnitData sCMGoodsUnitData in beforeCalcSCMGoodsUnitDataList)
                {
                    sCMGoodsUnitData.PccCmpnySt = pccCmpnyStWork;
                }

                IList<SCMGoodsUnitData> selectedSCMGoodsUnitDataList = new List<SCMGoodsUnitData>();

                //PCCUOEの場合
                #region PCCUOEの場合
                if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                {
                    //1:問合せの場合、優先設定適用を行う
                    if (detailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry)
                    {
                        // PCCUOE優先設定適用
                        selectedSCMGoodsUnitDataList = SelectPCCUOEGoodsUnitDataBySCMPrioritySetteing(
                            detailRecord,
                            beforeCalcSCMGoodsUnitDataList
                        );
                    }
                    else
                    {
                        selectedSCMGoodsUnitDataList = beforeCalcSCMGoodsUnitDataList;
                    }
                    // PCCUOEの在庫確認の場合、セット商品の部品情報を取得する
                    if ((detailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry
                        && (((SCMSearchedResult)Searcher.ResultMap[detailRecord.ToKey()]).SearchedType == SCMSearchedResult.GoodsSearchDivCd.BLCode)
                        || ((SCMSearchedResult)Searcher.ResultMap[detailRecord.ToKey()]).SearchedType == SCMSearchedResult.GoodsSearchDivCd.GoodsNo))
                    {
                        // 自動回答品目設定マスタを取得
                        List<AutoAnsItemSt> foundAutoAnsItemStList = AutoAnsItemStDB.Search(selectedSCMGoodsUnitDataList, GetCustomerCode(detailRecord));

                        // セット子商品の関連情報取得
                        foreach (SCMGoodsUnitData parentScmGoodsUnitData in selectedSCMGoodsUnitDataList)
                        {
                            string key = parentScmGoodsUnitData.RealGoodsUnitData.GoodsNo + "/"
                                        + parentScmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd.ToString() + "/"
                                        + detailRecord.ToKey();
                            if (SetGoodsUnitDataMap.ContainsKey(key))
                            {
                                foreach (GoodsUnitData goodsUnitData in SetGoodsUnitDataMap[key])
                                {
                                    goodsUnitData.SectionCode = detailRecord.InqOtherSecCd;
                                    SCMGoodsUnitData scmGoodsUnitData = new SCMGoodsUnitData(
                                        goodsUnitData,
                                        Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                                        detailRecord,
                                        GetCustomerCode(detailRecord)
                                    );
                                    scmGoodsUnitData.AcceptOrOrderKind = parentScmGoodsUnitData.AcceptOrOrderKind;
                                    scmGoodsUnitData.PccCmpnySt = parentScmGoodsUnitData.PccCmpnySt;

                                    // 自動回答品目設定マスタを検索
                                    AutoAnsItemSt autoAnsItemSt = AutoAnsItemStDB.Find(foundAutoAnsItemStList,
                                                                                       goodsUnitData,
                                                                                       GetCustomerCode(detailRecord));
                                    if (autoAnsItemSt != null)
                                    {
                                        // 自動回答品目設定を保持
                                        scmGoodsUnitData.AutoAnsItemStConfig = autoAnsItemSt;

                                        if (IsReplyAutomaticallyAtAutoAnswerDiv(autoAnsItemSt))
                                        {
                                            // 自動回答品目であることを設定
                                            scmGoodsUnitData.CanReplyAutomatically = true;
                                        }
                                    }
                                    parentScmGoodsUnitData.SetSCMGoodsUnitDataList.Add(scmGoodsUnitData);
                                }
                            }

                            // セット子商品の関連情報補正
                            // 各種価格算出→演算結果は回答データおよび売上データ、優先設定適用での価格系の適用で使用される
                            CalclateUnitPrice(detailRecord, parentScmGoodsUnitData.SetSCMGoodsUnitDataList);

                            // キャンペーン情報適用
                            TakeCampaignInformation(detailRecord, parentScmGoodsUnitData.SetSCMGoodsUnitDataList);
                        }
                    }
                    // ----- ADD 2011/08/10 ----- <<<<<

                }
                #endregion
                //SCMの場合
                #region SCMの場合
                else
                {
                    // UPD 2014/11/10 PM-SCM優先案件11月対応分 ---------------------------------->>>>>
                    //// 優先設定適用
                    //selectedSCMGoodsUnitDataList = SelectSCMGoodsUnitDataBySCMPrioritySetteing(
                    //    detailRecord,
                    //    beforeCalcSCMGoodsUnitDataList
                    //);
                    //1:問合せの場合、優先設定適用を行う
                    if (detailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry)
                    {
                        // 優先設定適用
                        selectedSCMGoodsUnitDataList = SelectSCMGoodsUnitDataBySCMPrioritySetteing(
                            detailRecord,
                            beforeCalcSCMGoodsUnitDataList
                        );
                    }
                    else
                    {
                        selectedSCMGoodsUnitDataList = beforeCalcSCMGoodsUnitDataList;
                    }
                    // UPD 2014/11/10 PM-SCM優先案件11月対応分 ----------------------------------<<<<<

                    // --- ADD 2014/10/14 Y.Wakita ---------->>>>>
                    // SCMの在庫確認の場合、セット商品の部品情報を取得する
                    if ((detailRecord.InqOrdDivCd == (int)InqOrdDivCd.Inquiry
                        && (((SCMSearchedResult)Searcher.ResultMap[detailRecord.ToKey()]).SearchedType == SCMSearchedResult.GoodsSearchDivCd.BLCode)
                        || ((SCMSearchedResult)Searcher.ResultMap[detailRecord.ToKey()]).SearchedType == SCMSearchedResult.GoodsSearchDivCd.GoodsNo))
                    {
                        // セット子商品の関連情報取得
                        foreach (SCMGoodsUnitData parentScmGoodsUnitData in selectedSCMGoodsUnitDataList)
                        {
                            string key = parentScmGoodsUnitData.RealGoodsUnitData.GoodsNo + "/"
                                        + parentScmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd.ToString() + "/"
                                        + detailRecord.ToKey();
                            if (SetGoodsUnitDataMap.ContainsKey(key))
                            {
                                foreach (GoodsUnitData goodsUnitData in SetGoodsUnitDataMap[key])
                                {
                                    goodsUnitData.SectionCode = detailRecord.InqOtherSecCd;
                                    SCMGoodsUnitData scmGoodsUnitData = new SCMGoodsUnitData(
                                        goodsUnitData,
                                        Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                                        detailRecord,
                                        GetCustomerCode(detailRecord)
                                    );
                                    scmGoodsUnitData.AcceptOrOrderKind = parentScmGoodsUnitData.AcceptOrOrderKind;
                                    scmGoodsUnitData.PccCmpnySt = parentScmGoodsUnitData.PccCmpnySt;

                                    parentScmGoodsUnitData.SetSCMGoodsUnitDataList.Add(scmGoodsUnitData);
                                }
                            }

                            // セット子商品の関連情報補正
                            // 各種価格算出→演算結果は回答データおよび売上データ、優先設定適用での価格系の適用で使用される
                            CalclateUnitPrice(detailRecord, parentScmGoodsUnitData.SetSCMGoodsUnitDataList);

                            // --- ADD 2014/11/05 Y.Wakita ---------->>>>>
                            // キャンペーン情報適用
                            TakeCampaignInformation(detailRecord, parentScmGoodsUnitData.SetSCMGoodsUnitDataList);
                            // --- ADD 2014/11/05 Y.Wakita ----------<<<<<
                        }
                    }
                    // --- ADD 2014/10/14 Y.Wakita ----------<<<<<
                }
                #endregion
                // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№10.単価計算呼出回数改良 ----------------------------------<<<<<

                // 回答用SCM情報付商品連結データに追加
                AddToSCMGoodsUnitDataMap(detailRecord, selectedSCMGoodsUnitDataList);
                // -- ADD 2011/08/10   ------ <<<<<<
            }
        }

        #endregion // </回答用SCM情報付商品連結データのマップを構築>

        /// <summary>
        /// 回答用SCM情報付商品連結データが空の場合、初期化します。
        /// </summary>
        public virtual void InitializeIfSCMGoodsUnitDataMapIsEmpty()
        {
            EasyLogger.LogWrite("●回答用SCM情報付商品連結データ構築");

            if (SCMGoodsUnitDataMap.Count > 0) return;

            foreach (SCMOrderDetailRecordType detailRecord in DetailRecordList)
            {
                IList<SCMGoodsUnitData> scmGoodsUnitDataList = new List<SCMGoodsUnitData>();
                {
                    Debug.WriteLine("明細キー：" + detailRecord.ToKey() + ", BLコード：" + detailRecord.BLGoodsCode.ToString());
                    if (!Searcher.ResultMap.ContainsKey(detailRecord.ToKey())) continue;
                    
                    foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)
                    {
                        // SCM情報付商品連結データ
                        SCMGoodsUnitData scmGoodsUnitData = new SCMGoodsUnitData(
                            goodsUnitData,
                            Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                            detailRecord,
                            GetCustomerCode(detailRecord)
                        );
                        scmGoodsUnitData.AcceptOrOrderKind = Searcher.RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind; // ADD 2011/08/10
                        scmGoodsUnitDataList.Add(scmGoodsUnitData);
                    }
                }
                // 回答用SCM情報付商品連結データのマップを構築
                BuildSCMGoodsUnitDataMap(detailRecord, scmGoodsUnitDataList);
            }
        }

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="searcher">SCM検索処理</param>
        protected SCMReferee(SCMSearcher searcher)
        {
            _searcher = searcher;
        }

        #endregion // </Constructor>

        #region <SCM受注データ>

        #region <ヘッダ>

        /// <summary>
        /// SCM受注データのレコードリストを取得します。
        /// </summary>
        protected IList<SCMOrderHeaderRecordType> HeaderRecordList
        {
            get { return Searcher.HeaderRecordList; }
        }

        /// <summary>
        /// SCM受注データの関連マップを取得します。
        /// </summary>
        protected IDictionary<string, ISCMOrderHeaderRecord> RelationalHeaderMap
        {
            get { return Searcher.RelationalHeaderMap; }
        }

        #endregion // </ヘッダ>

        #region <車両情報>

        /// <summary>
        /// SCM受注データ(車両情報)のレコードリストを取得します。
        /// </summary>
        protected IList<SCMOrderCarRecordType> CarRecordList
        {
            get { return Searcher.CarRecordList; }
        }

        #endregion // </車両情報>

        #region <明細>

        /// <summary>
        /// SCM受注明細データ(問合せ・発注)のレコードリストを取得します。
        /// </summary>
        protected IList<SCMOrderDetailRecordType> DetailRecordList
        {
            get { return Searcher.DetailRecordList; }
        }

        #endregion // </明細>

        #endregion // </SCM受注データ>

        #region <商品種別>

        /// <summary>
        /// 商品種別が相場であるか判断します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>
        /// <c>true</c> :商品種別は相場です。<br/>
        /// <c>false</c>:商品種別は相場ではりません。
        /// </returns>
        protected bool IsMarketAtGoodsDivCd(SCMOrderDetailRecordType detailRecord)
        {
            return detailRecord.GoodsDivCd.Equals((int)GoodsDivCode.Market)
                        ||
                    detailRecord.GoodsDivCd.Equals((int)GoodsDivCode.Used);
        }

        #endregion // </商品種別>

        // 2011/01/11 Add >>>
        /// <summary>
        /// 検索で正常終了したか判断します。
        /// </summary>
        /// <param name="detailRecord"></param>
        /// <returns></returns>
        protected bool IsSearchNormal(SCMOrderDetailRecordType detailRecord)
        {
            const string METHOD_NAME = "IsSearchNormal()";  // ログ用

            #region <Guard Phrase>

            // 検索結果が存在していなければ、false
            if (!Searcher.ResultMap.ContainsKey(detailRecord.ToKey()))
            {
                return false;
            }

            #endregion // </Guard Phrase>

            int status = Searcher.ResultMap[detailRecord.ToKey()].Status;

            #region <Log>

            if (status != (int)ResultUtil.ResultCode.Normal)
            {
                string msg = "部品検索で異常終了しています。STATUS=" + status.ToString();
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));
            }
            #endregion // </Log>

            return status.Equals((int)ResultUtil.ResultCode.Normal);
        }
        // 2011/01/11 Add <<<

        #region <純正部品>

        /// <summary>
        /// 純正1品番か判断します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>
        /// <c>true</c> :純正1品番です。<br/>
        /// <c>false</c>:純正1品番ではありません。
        /// </returns>
        protected bool IsOnePureGoods(SCMOrderDetailRecordType detailRecord)
        {
            const string METHOD_NAME = "IsOnePureGoods()";  // ログ用

            #region <Guard Phrase>

            // 検索結果が存在していなければ、false
            if (!Searcher.ResultMap.ContainsKey(detailRecord.ToKey()))
            {
                return false;
            }

            #endregion // </Guard Phrase>

            #region <Log>

            string title = "純正1品番であるか判定中...";
            title += Environment.NewLine + SCMDataHelper.GetProfile(detailRecord);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(title));

            #endregion // </Log>

            // 純正が2件以上存在した場合、false
            int pureCount = 0;
            foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)
            {
                // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
                #region 見積計上用処理

                // 前回、｢見積｣で回答済み商品はチェック対象としない
                if (goodsUnitData is AnsweredGoodsUnitData)
                {
                    #region <Log>

                    string msg = "純正1品番の判定を省略します。∵前回、｢見積｣で回答済み商品です";
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    continue;
                }

                #endregion // 見積計上用処理
                // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

                // 商品連結データの商品種別(複数あり)がセット子の場合、純正1品番ではない（手動回答）
                if (ContainsSetChildAtGoodsKind(goodsUnitData))
                {
                    #region <Log>

                    string msg = "純正1品番ではありません。∵商品連結データの商品種別(複数あり)がセット子";
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    return false;
                }

                // 商品連結データの商品種別(複数あり)が親または代替または代替互換で、
                // 「提供区分(OfferKubun)：純正」のデータが2件以上存在した場合、
                // 純正1品番ではない（手動回答）
                if (ContainsParentAtGoodsKind(goodsUnitData) && IsPureAtOfferKubun(goodsUnitData))
                {
                    pureCount++;

                    #region <Log>

                    string msg = "商品連結データの商品種別(複数あり)が親 または 代替 または 代替互換で、「提供区分(OfferKubun)：純正」のデータ";
                    msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(goodsUnitData);
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    if (pureCount > 1)
                    {
                        #region <Log>

                        msg = "純正1品番ではありません。";
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return false;
                    }
                }
            }

            #region <Log>

            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("純正1品番です。"));

            #endregion // </Log>

            return true;
        }
        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>
        /// 結合子、代替を含むか判断します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :結合子、代替を含みます。<br/>
        /// <c>false</c>:結合子、代替を含みません。
        /// </returns>
        protected static bool ContainsCenectAtGoodsKind(GoodsUnitData goodsUnitData)
        {
            IList<int> splitedGoodsKind = SplitGoodsKind(goodsUnitData);
            {
                foreach (int goodsKind in splitedGoodsKind)
                {
                    // 2:結合子, 8:代替
                    if (goodsKind.Equals(2) || goodsKind.Equals(8)) return true;
                }
            }
            return false;
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        /// <summary>
        /// セット子を含むか判断します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :セット子を含みます。<br/>
        /// <c>false</c>:セット子を含みません。
        /// </returns>
        protected static bool ContainsSetChildAtGoodsKind(GoodsUnitData goodsUnitData)
        {
            IList<int> splitedGoodsKind = SplitGoodsKind(goodsUnitData);
            {
                foreach (int goodsKind in splitedGoodsKind)
                {
                    // 4:セット子
                    if (goodsKind.Equals(4)) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 親, 代替, 代替互換を含むか判断します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :親, 代替, 代替互換を含みます。<br/>
        /// <c>false</c>:親, 代替, 代替互換を含みません。
        /// </returns>
        protected static bool ContainsParentAtGoodsKind(GoodsUnitData goodsUnitData)
        {
            IList<int> splitedGoodsKind = SplitGoodsKind(goodsUnitData);
            {
                foreach (int goodsKind in splitedGoodsKind)
                {
                    // 1:親, 8:代替, 16:代替互換
                    if (goodsKind.Equals(1) || goodsKind.Equals(8) || goodsKind.Equals(16)) return true;
                }
            }
            return false;
        }

        // ADD 2015/02/02 豊沢 PM-SCM社内障害一覧No.69対応 ------------------------------------------>>>>>
        /// <summary>
        /// 結合元、結合先を含むか判断します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :結合元、結合先を含みます。<br/>
        /// <c>false</c>:結合元、結合先を含みません。
        /// </returns>
        public static bool ContainsJoinAtGoodsKind(GoodsUnitData goodsUnitData)
        {
            IList<int> splitedGoodsKind = SCMReferee.SplitGoodsKind(goodsUnitData);
            foreach (int goodsKind in splitedGoodsKind)
            {
                // 1:親, 2:結合先
                if ((goodsKind == (int)GoodsKind.Parent || goodsKind == (int)GoodsKind.Join)) return true;
            }
            return false;
        }
        // UPD 2015/02/02 豊沢 PM-SCM社内障害一覧No.69対応 ------------------------------------------<<<<<

        /// <summary>
        /// 商品種別(複数あり)を1, 2, 4, 8, 16 の構成に分解します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// 1, 2, 4, 8, 16 のうち、構成される数値のリスト
        /// </returns>
        protected static IList<int> SplitGoodsKind(GoodsUnitData goodsUnitData)
        {
            int number = goodsUnitData.GoodsKind;

            IList<int> splitedNumber = new List<int>();
            {
                int surplus = number;
                
                surplus %= 16;  // 代替互換
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(16);
                }

                number = surplus;
                surplus %= 8;   // 代替
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(8);
                }

                number = surplus;
                surplus %= 4;   // セット子
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(4);
                }

                number = surplus;
                surplus %= 2;   // 結合子
                if (!surplus.Equals(number))
                {
                    splitedNumber.Add(2);
                }

                // 親
                if (surplus.Equals(1))
                {
                    splitedNumber.Add(1);
                }
            }
            return splitedNumber;
        }

        /// <summary>
        /// 純正であるか判断します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>
        /// <c>true</c> :純正です。<br/>
        /// <c>false</c>:純正ではありません。
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">提供区分の値が範囲外です。</exception>
        protected static bool IsPureAtOfferKubun(GoodsUnitData goodsUnitData)
        {
            switch (goodsUnitData.OfferKubun)
            {
                // 2011/02/09 >>>
                //case 0: return false;   // 0:ユーザー登録
                // ----- UPD 2011/10/11 ----- >>>>>
                //case 0: return !string.IsNullOrEmpty(goodsUnitData.FreSrchPrtPropNo.Trim());   // 0:ユーザー登録
                case 0: // ユーザー登録
                    {
                        // 0:純正
                        if (goodsUnitData.GoodsKindCode == 0)
                        {
                            return true;
                        }
                        // 1:その他
                        else if (goodsUnitData.GoodsKindCode == 1)
                        {
                            return false;
                        }
                        return false;
                    }
                // ----- UPD 2011/10/11 ----- <<<<<
                // 2011/02/09 <<<
                case 1: return true;    // 1:提供純正編集
                case 2: return false;   // 2:提供優良編集
                case 3: return true;    // 3:提供純正
                case 4: return false;   // 4:提供優良
                case 5: return false;   // 5:TBO
                case 7: return false;   // 7:オリジナル部品
                default:
                    throw new ArgumentOutOfRangeException(
                        string.Format("提供区分の値が範囲外です。(={0})", goodsUnitData.OfferKubun)
                    );
            }
        }

        #endregion // </純正部品>

        #region <親データとセットデータを絞り込み>
        /// <summary>
        /// 親データとセットデータを絞込します。
        /// </summary>
        /// <remarks>
        /// 親のSCM情報付商品連結データを同時に構築します。
        /// </remarks>
        /// <param name="detailRecord">SCM受注データ(問合せ・発注)のレコード</param>
        protected IList<SCMGoodsUnitData> ExistsGoodsWithoutSet(
            SCMOrderDetailRecordType detailRecord)
        {
            const string METHOD_NAME = "ExitGoodsWithoutSet()";  // ログ用

            #region <Log>

            string title = "親データとセットデータを絞り込み中...";
            title += Environment.NewLine + SCMDataHelper.GetProfile(detailRecord);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(title));

            #endregion // </Log>
            IList<SCMGoodsUnitData> scmGoodsUnitDataList = new List<SCMGoodsUnitData>();

            //>>>2012/01/04
            // 検索結果データクラス退避
            PartsInfoDataSet savePartsInfo = null; 
            if (Searcher.ResultMap[detailRecord.ToKey()].PartsInfoDB != null)
            {
                savePartsInfo = (PartsInfoDataSet)Searcher.ResultMap[detailRecord.ToKey()].PartsInfoDB.Copy();
            }
            //<<<2012/01/04

            // セット子商品のマップを構築する
            foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataListForPccuoe)
            {
                // 商品連結データの商品種別(複数あり)がセット子の場合、絞込
                if (ContainsSetChildAtGoodsKind(goodsUnitData))
                {
                    GoodsUnitData setgoodsUnitData = null;
                    string msgerr = string.Empty;
                    //セット品番検索を行います。（既存品番検索には、セット商品のOFFERKUBUNが取得されないので、再度検索を行う）
                    int setstatus = _searcher.SearchSetFromGoodsNo(
                        detailRecord,
                        goodsUnitData.GoodsNo,
                        goodsUnitData.GoodsMakerCd,
                        out setgoodsUnitData,
                        out msgerr);
                    //取得失敗した場合
                    if (setgoodsUnitData != null)
                    {
                        goodsUnitData.OfferKubun = setgoodsUnitData.OfferKubun;
                        // ADD 2012/07/09 T.Yoshioka №10304 ---------------->>>>>>>>>>>>>>>>>>>>>
                        goodsUnitData.BLGroupCode = setgoodsUnitData.BLGroupCode;           // グループコード
                        goodsUnitData.GoodsRateGrpCode = setgoodsUnitData.GoodsRateGrpCode; // 商品掛率グループ
                        goodsUnitData.SupplierCd = setgoodsUnitData.SupplierCd;             // 仕入先コード
                        // ADD 2012/07/09 T.Yoshioka №10304 ----------------<<<<<<<<<<<<<<<<<<<<<
                    }

                    foreach (PartsInfoDataSet.UsrSetPartsRow row in Searcher.SetResultMap[detailRecord.ToKey()].UsrSetParts.Rows)
                    {
                        if (row.SubGoodsNo == goodsUnitData.GoodsNo && row.SubGoodsMakerCd == goodsUnitData.GoodsMakerCd)
                        {
                            string key = row.ParentGoodsNo + "/" + row.ParentGoodsMakerCd.ToString() + "/" + detailRecord.ToKey();
                            if (!SetGoodsUnitDataMap.ContainsKey(key))
                            {
                                List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                                goodsUnitDataList.Add(goodsUnitData);
                                SetGoodsUnitDataMap.Add(key, goodsUnitDataList);
                            }
                            else
                            {
                                SetGoodsUnitDataMap[key].Add(goodsUnitData);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }

                    continue;
                }
            }

            // SCM情報付商品連結データリストを構築する
            foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)
            {
                // ----- ADD 2011/09/29 ----- >>>>>
                if (ContainsSetChildAtGoodsKind(goodsUnitData))
                {
                    continue;
                }
                // ----- ADD 2011/09/29 ----- <<<<<
                goodsUnitData.SectionCode = detailRecord.InqOtherSecCd; // ADD 2011/09/19
                // SCM情報付商品連結データ
                SCMGoodsUnitData scmGoodsUnitData = new SCMGoodsUnitData(
                    goodsUnitData,
                    Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                    detailRecord,
                    GetCustomerCode(detailRecord)
                );

                scmGoodsUnitData.AcceptOrOrderKind = Searcher.RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind;

                scmGoodsUnitDataList.Add(scmGoodsUnitData);
            }

            //>>>2012/01/04
            // 検索結果データクラス戻し
            if (savePartsInfo != null)
            {
                Searcher.ResultMap[detailRecord.ToKey()].PartsInfoDB = savePartsInfo;
            }
            //<<<2012/01/04

            return scmGoodsUnitDataList;
        }
        #endregion // </親データとセットデータを絞り込み>

        #region <自動回答品目>

        /// <summary>
        /// 自動回答品目が存在するか判断します。
        /// </summary>
        /// <remarks>
        /// SCM情報付商品連結データを同時に構築します。
        /// </remarks>
        /// <param name="detailRecord">SCM受注データ(問合せ・発注)のレコード</param>
        /// <returns>
        /// <c>true</c> :自動回答品目が存在します。<br/>
        /// <c>false</c>:自動回答品目が存在しません。
        /// </returns>
        /// <remarks>
        /// <br>Update Note : 2018/07/06 陳艶丹</br>
        /// <br>管理番号    : 11470103-00</br>
        /// <br>            : SF側セット子品番の在庫情報の障害対応</br>
        /// </remarks>
        protected SCMGoodsUnitDataListPair ExistsGoodsOfReplyingAutomatically(
            SCMOrderDetailRecordType detailRecord
        )
        {
            const string METHOD_NAME = "ExistsGoodsOfReplyingAutomatically()";  // ログ用

            #region <Log>

            string title = "自動回答品目であるか判定中...";
            title += Environment.NewLine + SCMDataHelper.GetProfile(detailRecord);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(title));

            #endregion // </Log>

            #region <Guard Phrase>

            // ヘッダがない
            if (!RelationalHeaderMap.ContainsKey(detailRecord.ToRelationKey()))
            {
                string msg = string.Format("明細のヘッダが存在しません。：{0}", detailRecord.ToRelationKey());
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                Debug.Assert(false, msg);
                return new SCMGoodsUnitDataListPair(false, null);
            }

            // 検索結果がない
            if (!Searcher.ResultMap.ContainsKey(detailRecord.ToKey()))
            {
                string msg = string.Format("検索結果が存在しません。：{0}", detailRecord.ToRelationKey());
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                return new SCMGoodsUnitDataListPair(false, null);
            }

            #endregion // </Guard Phrase>

            bool exists = false;
            IList<SCMGoodsUnitData> scmGoodsUnitDataList = new List<SCMGoodsUnitData>();
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            // ADD 2012/06/29 湯上 No.274 ---------------------------------------------------->>>>>
            //IList<SCMGoodsUnitData> pureGoodsUnitDataList = new List<SCMGoodsUnitData>();
            // ADD 2012/06/29 湯上 No.274 ----------------------------------------------------<<<<<
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

            // --- Add  2011/08/02 duzg for Redmine#23307 --->>>
            // SCM全体設定を取得
            SCMTtlSt foundSCMTtlSt = TtlStSettingDB.Find(
                 detailRecord.InqOtherEpCd,
                 detailRecord.InqOtherSecCd
                );
            // --- Add  2011/08/02 duzg for Redmine#23307 ---<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            // 自動回答品目設定優先順位
            int selectPriorityOrder = 0;
            // 自動回答品目設定マスタ取得
            List<AutoAnsItemSt> foundAutoAnsItemStList = AutoAnsItemStDB.Search(
                Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList,
                GetCustomerCode(detailRecord)
            );
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

            // ADD 2012/11/20 2012/12/12配信予定システムテスト障害№50対応 -------------------------->>>>>
            // --- DEL 2014/10/14 Y.Wakita ---------->>>>>
            // PCCUOEの時、セット品情報の構築を行う
            //if (Searcher.RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            //{
            // --- DEL 2014/10/14 Y.Wakita ----------<<<<<
                foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataListForPccuoe)
                {
                    // 商品連結データの商品種別(複数あり)がセット子の場合、絞込
                    if (ContainsSetChildAtGoodsKind(goodsUnitData))
                    {
                        // UPD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                        #region 削除
                        //GoodsUnitData setgoodsUnitData = null;
                        //string msgerr = string.Empty;
                        ////セット品番検索を行います。（既存品番検索には、セット商品のOFFERKUBUNが取得されないので、再度検索を行う）
                        //int setstatus = _searcher.SearchSetFromGoodsNo(
                        //    detailRecord,
                        //    goodsUnitData.GoodsNo,
                        //    goodsUnitData.GoodsMakerCd,
                        //    out setgoodsUnitData,
                        //    out msgerr);
                        #endregion 
                        GoodsUnitData setgoodsUnitData = null;
                        string msgerr = string.Empty;
                        List<GoodsPrice> offerPriceList = null;
                        List<GoodsPrice> userPriceList = null;
                        //セット品番検索を行います。（既存品番検索には、セット商品のOFFERKUBUNが取得されないので、再度検索を行う）
                        int setstatus = _searcher.SearchSetFromGoodsNo(
                            detailRecord,
                            goodsUnitData.GoodsNo,
                            goodsUnitData.GoodsMakerCd,
                            out setgoodsUnitData,
                            out offerPriceList,
                            out userPriceList,
                            out msgerr);
                        // UPD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                        //取得失敗した場合
                        if (setgoodsUnitData != null)
                        {
                            goodsUnitData.OfferKubun = setgoodsUnitData.OfferKubun;
                            goodsUnitData.BLGroupCode = setgoodsUnitData.BLGroupCode;           // グループコード
                            goodsUnitData.GoodsRateGrpCode = setgoodsUnitData.GoodsRateGrpCode; // 商品掛率グループ
                            goodsUnitData.SupplierCd = setgoodsUnitData.SupplierCd;             // 仕入先コード
                            // ADD 2012/12/04 2012/12/12配信 システムテスト障害№95対応 ------------------------>>>>>
                            goodsUnitData.MakerKanaName = setgoodsUnitData.MakerKanaName;       // メーカー名称カナ
                            goodsUnitData.MakerName = setgoodsUnitData.MakerName;               // メーカー名称
                            // ADD 2012/12/04 2012/12/12配信 システムテスト障害№95対応 ------------------------<<<<<
                            // ADD 2015/03/03 SCM高速化Redmine#310対応 --------------------------------->>>>>
                            goodsUnitData.PrmSetDtlNo2 = setgoodsUnitData.PrmSetDtlNo2;  // 優良設定詳細コード２
                            goodsUnitData.PrmSetDtlName2 = setgoodsUnitData.PrmSetDtlName2;  // 優良設定詳細名称２
                            goodsUnitData.PrmSetDtlName2ForFac = setgoodsUnitData.PrmSetDtlName2ForFac;  // 優良設定詳細名称２（工場向け）
                            goodsUnitData.PrmSetDtlName2ForCOw = setgoodsUnitData.PrmSetDtlName2ForCOw;  // 優良設定詳細名称２（カーオーナー向け）
                            // ADD 2015/03/03 SCM高速化Redmine#310対応 ---------------------------------<<<<<
                            // 優先倉庫
                            goodsUnitData.SelectedWarehouseCode = setgoodsUnitData.SelectedWarehouseCode; // ADD 2018/07/06 陳艶丹 SF側セット子品番の在庫情報の障害対応

                        }

                        foreach (PartsInfoDataSet.UsrSetPartsRow row in Searcher.SetResultMap[detailRecord.ToKey()].UsrSetParts.Rows)
                        {
                            if (row.SubGoodsNo == goodsUnitData.GoodsNo && row.SubGoodsMakerCd == goodsUnitData.GoodsMakerCd)
                            {
                                // DEL 2015/01/29 SCM高速化Redmine#87対応 ---------------------------------------->>>>>
                                #region 削除
                                //// ADD 2015/01/28 SCM高速化Redmine#61対応 --------------------------------------->>>>>
                                //// 商品情報がユーザー登録の品番の時、品番検索を行い提供データのメーカー希望小売価格を取得する
                                //if (IsUserRegistAtOfferKubun(goodsUnitData))
                                //{
                                //    List<GoodsPrice> mkrSuggestRtPricList = new List<GoodsPrice>(); // メーカー希望小売価格リスト
                                //    GetOfferGoodsPrice(goodsUnitData, out mkrSuggestRtPricList);
                                //    goodsUnitData.MkrSuggestRtPricList = mkrSuggestRtPricList;
                                //}
                                //// ADD 2015/01/28 SCM高速化Redmine#61対応 ---------------------------------------<<<<<
                                #endregion
                                // DEL 2015/01/29 SCM高速化Redmine#87対応 ----------------------------------------<<<<<
                                // ADD 2013/01/11 2013/03/13配信予定 SCM障害№10472対応 --------------------------------->>>>>
                                goodsUnitData.DisplayOrder = row.DisplayOrder;
                                // ADD 2013/01/11 2013/03/13配信予定 SCM障害№10472対応 ---------------------------------<<<<<
                                string key = row.ParentGoodsNo + "/" + row.ParentGoodsMakerCd.ToString() + "/" + detailRecord.ToKey();
                                if (!SetGoodsUnitDataMap.ContainsKey(key))
                                {
                                    List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                                    goodsUnitDataList.Add(goodsUnitData);
                                    SetGoodsUnitDataMap.Add(key, goodsUnitDataList);
                                }
                                else
                                {
                                    SetGoodsUnitDataMap[key].Add(goodsUnitData);
                                }
                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                                // 提供データ価格情報をマップに追加
                                if (!SetOfferPriceMap.ContainsKey(key))
                                {
                                    List<GoodsPrice> priceListTemp = new List<GoodsPrice>();
                                    priceListTemp.AddRange(offerPriceList);
                                    SetOfferPriceMap.Add(key, priceListTemp);
                                }
                                else
                                {
                                    List<GoodsPrice> priceListTemp = new List<GoodsPrice>();
                                    priceListTemp.AddRange(offerPriceList);
                                    SetOfferPriceMap[key].AddRange(priceListTemp);
                                }
                                // ユーザー登録分価格情報をマップに追加
                                if (!SetUserPriceMap.ContainsKey(key))
                                {
                                    List<GoodsPrice> priceListTemp = new List<GoodsPrice>();
                                    priceListTemp.AddRange(userPriceList);
                                    SetUserPriceMap.Add(key, priceListTemp);
                                }
                                else
                                {
                                    List<GoodsPrice> priceListTemp = new List<GoodsPrice>();
                                    priceListTemp.AddRange(userPriceList);
                                    SetUserPriceMap[key].AddRange(priceListTemp);
                                }
                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                            }
                            else
                            {
                                continue;
                            }
                        }

                        continue;
                    }
                }
            // --- DEL 2014/10/14 Y.Wakita ---------->>>>>
            //}
            // --- DEL 2014/10/14 Y.Wakita ----------<<<<<
            // ADD 2012/11/20 2012/12/12配信予定システムテスト障害№50対応 --------------------------<<<<<

            Debug.WriteLine("明細キー：" + detailRecord.ToKey() + ", BLコード：" + detailRecord.BLGoodsCode.ToString());
            foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)
            {
                Debug.WriteLine("商品番号：" + goodsUnitData.GoodsNo);

                // DEL 2015/01/29 SCM高速化Redmine#87対応 ---------------------------------------->>>>>
                #region 削除
                //// ADD 2015/01/28 SCM高速化Redmine#61対応 --------------------------------------->>>>>
                //// 商品情報がユーザー登録の品番の時、品番検索を行い提供データのメーカー希望小売価格を取得する
                //if (IsUserRegistAtOfferKubun(goodsUnitData))
                //{
                //    List<GoodsPrice> mkrSuggestRtPricList = new List<GoodsPrice>(); // メーカー希望小売価格リスト
                //    GetOfferGoodsPrice(goodsUnitData, out mkrSuggestRtPricList);
                //    goodsUnitData.MkrSuggestRtPricList = mkrSuggestRtPricList;
                //}
                //// ADD 2015/01/28 SCM高速化Redmine#61対応 ---------------------------------------<<<<<
                #endregion
                // DEL 2015/01/29 SCM高速化Redmine#87対応 ----------------------------------------<<<<<

                // SCM情報付商品連結データ
                SCMGoodsUnitData scmGoodsUnitData = new SCMGoodsUnitData(
                    goodsUnitData,
                    Searcher.ResultMap[detailRecord.ToKey()].SearchedType,
                    detailRecord,
                    GetCustomerCode(detailRecord)
                );

                // ADD 2012/11/09 2012/12/12配信 SCM障害№10435対応 -------------------------------------->>>>>
                scmGoodsUnitData.AcceptOrOrderKind = Searcher.RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind;
                // ADD 2012/11/09 2012/12/12配信 SCM障害№10435対応 --------------------------------------<<<<<

                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                #region 削除(SCM改良の為)
                //                // ADD 2012/06/29 湯上 No.274 ---------------------------------------------------->>>>>
                //                // PCCUOEで問合せの時
                //                if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
                //                    RelationalHeaderMap[detailRecord.ToRelationKey()].InqOrdAnsDivCd == (int)InqOrdAnsDivCd.Inquiry)
                //                {
                //                    // 純正品の時、リストに退避する
                //                    if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                //                    {
                //                        // データを複製し自動回答品目の設定をしてリストに追加する
                //                        SCMGoodsUnitData pureGoodsUnitData = scmGoodsUnitData.Clone();
                //                        pureGoodsUnitData.CanReplyAutomatically = true;
                //                        pureGoodsUnitData.AcceptOrOrderKind = Searcher.RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind;
                //                        pureGoodsUnitDataList.Add(pureGoodsUnitData);
                //                    }
                //                }
                //                // ADD 2012/06/29 湯上 No.274 ----------------------------------------------------<<<<<

                //                // SCM品目設定マスタを検索
                //                IList<SCMPrtSetting> foundSCMPrtSettingList = ScmPrtSettingDB.Find(
                //                    goodsUnitData,
                //                    GetCustomerCode(detailRecord)
                //                );

                //                // SCM品目設定マスタに登録がない場合、次の品目へ
                //                if (ListUtil.IsNullOrEmpty(foundSCMPrtSettingList))
                //                {
                //                    //>>>2012/06/26
                ////                    // --- UPD 三戸 2012/05/28 №274 ---------->>>>>
                ////                    //#if _IS_GOODS_OF_REPLYING_AUTOMATICALLY_
                ////                    //                    Debug.WriteLine("強制的にSCM品目設定マスタに登録があるとしました。");
                ////                    //                    scmGoodsUnitData.CanReplyAutomatically = true;
                ////                    //                    exists = true;
                ////                    //                    scmGoodsUnitDataList.Add(scmGoodsUnitData);
                ////                    //                    continue;
                ////                    //#else
                ////                    //                    #region <Log>

                ////                    //                    string msg = "SCM品目設定マスタに登録がありませんでした。";
                ////                    //                    msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(scmGoodsUnitData);
                ////                    //                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                ////                    //                    #endregion // </Log>

                ////                    //                    continue;
                ////                    //#endif
                ////                    if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
                ////                    {
                ////                        if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                ////                        {
                ////                            Debug.WriteLine("強制的にSCM品目設定マスタに登録があるとしました。");
                ////                            scmGoodsUnitData.CanReplyAutomatically = true;
                ////                            exists = true;
                ////                            scmGoodsUnitDataList.Add(scmGoodsUnitData);
                ////                            continue;
                ////                        }
                ////                        else
                ////                        {
                ////                            string msg = "SCM品目設定マスタに登録がありませんでした。";
                ////                            msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(scmGoodsUnitData);
                ////                            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                ////                            continue;
                ////                        }
                ////                    }
                ////                    else
                ////                    {
                ////#if _IS_GOODS_OF_REPLYING_AUTOMATICALLY_
                ////                                            Debug.WriteLine("強制的にSCM品目設定マスタに登録があるとしました。");
                ////                                            scmGoodsUnitData.CanReplyAutomatically = true;
                ////                                            exists = true;
                ////                                            scmGoodsUnitDataList.Add(scmGoodsUnitData);
                ////                                            continue;
                ////#else
                ////                        #region <Log>

                ////                        string msg = "SCM品目設定マスタに登録がありませんでした。";
                ////                        msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(scmGoodsUnitData);
                ////                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                ////                        #endregion // </Log>

                ////                        continue;
                ////#endif
                ////                    }
                ////                    // --- UPD 三戸 2012/05/28 №274 ----------<<<<<

                //#if _IS_GOODS_OF_REPLYING_AUTOMATICALLY_
                //                                        Debug.WriteLine("強制的にSCM品目設定マスタに登録があるとしました。");
                //                                        scmGoodsUnitData.CanReplyAutomatically = true;
                //                                        exists = true;
                //                                        scmGoodsUnitDataList.Add(scmGoodsUnitData);
                //                                        continue;
                //#else
                //                    #region <Log>

                //                    string msg = "SCM品目設定マスタに登録がありませんでした。";
                //                    msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(scmGoodsUnitData);
                //                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //                    #endregion // </Log>

                //                    continue;
                //#endif
                //                    //<<<2012/06/26
                //                }

                //                // SCM品目設定マスタ.自動回答区分が"しない"以外の場合、true:存在する
                //                foreach (SCMPrtSetting scmPrtSettingRecord in foundSCMPrtSettingList)
                //                {
                //                    // SCM品目設定を保持
                //                    scmGoodsUnitData.SCMItemConfig = scmPrtSettingRecord;

                //                    if (IsReplyAutomaticallyAtAutoAnswerDiv(scmPrtSettingRecord))
                //                    {
                //                        #region <Log>

                //                        string msg = string.Format(
                //                            "自動回答品目です。自動回答区分={0}：{1}",
                //                            scmPrtSettingRecord.AutoAnswerDiv,
                //                            SCMPrtSettingAgent.GetAutoAnswerDivName(scmPrtSettingRecord)
                //                        );
                //                        msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(scmGoodsUnitData);
                //                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //                        #endregion // </Log>

                //                        // --- UPD 湯上 2012/04/23 №150 Redmine#28038 ---------->>>>>
                //                        //// 自動回答品目であることを設定
                //                        //scmGoodsUnitData.CanReplyAutomatically = true;
                //                        //exists = true;
                //                        // する（委託在庫分のみ）
                //                        if (null != foundSCMTtlSt && scmGoodsUnitData.GetAcptAnOdrStatus() != (int)AcptAnOdrStatus.Estimate)
                //                        {
                //                            if (foundSCMTtlSt.AutoAnswerDiv == 1 && scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust)
                //                            {
                //                                scmGoodsUnitData.CanReplyAutomatically = true;
                //                                exists = true;
                //                            }
                //                            else if (foundSCMTtlSt.AutoAnswerDiv == 2
                //                                && (scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust
                //                                || scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Customer
                //                                || scmGoodsUnitData.GetStockDiv() == (int)StockDiv.PriorityWarehouse
                //                                || scmGoodsUnitData.GetStockDiv() == (int)StockDiv.OwnCompany))
                //                            {
                //                                scmGoodsUnitData.CanReplyAutomatically = true;
                //                                exists = true;
                //                            }
                //                            else if (foundSCMTtlSt.AutoAnswerDiv == 3)
                //                            {
                //                                scmGoodsUnitData.CanReplyAutomatically = true;
                //                                exists = true;
                //                            }
                //                            else if (foundSCMTtlSt.AutoAnswerDiv == 0)
                //                            {
                //                                scmGoodsUnitData.CanReplyAutomatically = false;
                //                                exists = false;
                //                            }

                //                            // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ---------->>>>>
                //                            // --- ADD 三戸 2012/04/17 №166 ---------->>>>>
                //                            // 現在の在庫が足りていない場合は手動にする
                //                            //if (detailRecord.SalesOrderCount > scmGoodsUnitData.GetStockQty())
                //                            //{
                //                            //    scmGoodsUnitData.CanReplyAutomatically = false;
                //                            //    exists = false;
                //                            //}
                //                            // --- ADD 三戸 2012/04/17 №166 ----------<<<<<
                //                            // --- UPD 吉岡 2012/06/20 SCM障害№166、システムテスト№98の戻し   ----------<<<<<
                //                        }
                //                        else
                //                        {
                //                            // 自動回答品目であることを設定
                //                            scmGoodsUnitData.CanReplyAutomatically = true;
                //                            exists = true;
                //                        }
                //                        // --- UPD 湯上 2012/04/23 №150 Redmine#28038 ----------<<<<<
                //                    }
                //                    else
                //                    {
                //                        #region <Log>

                //                        string msg = "SCM品目設定マスタ.自動回答区分が「0:しない」でした。";
                //                        msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(scmGoodsUnitData);
                //                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                //                        #endregion // </Log>
                //                    }
                //                }
                #endregion

                // PCC自社設定マスタ情報
                scmGoodsUnitData.PccCmpnySt = this.pccCmpnyStWork;

                // 自動回答品目設定マスタを検索
                AutoAnsItemSt selectAutoAnsItemSt = AutoAnsItemStDB.Find(
                    foundAutoAnsItemStList,
                    goodsUnitData,
                    GetCustomerCode(detailRecord)
                );

                // 自動回答品目設定マスタに登録がない場合、次の品目へ
                if (selectAutoAnsItemSt == null)
                {
#if _IS_GOODS_OF_REPLYING_AUTOMATICALLY_
                                        Debug.WriteLine("強制的にSCM品目設定マスタに登録があるとしました。");
                                        scmGoodsUnitData.CanReplyAutomatically = true;
                                        exists = true;
                                        scmGoodsUnitDataList.Add(scmGoodsUnitData);
                                        continue;
#else
                    #region <Log>

                    string msg = "自動回答品目設定マスタに登録がありませんでした。";
                    msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(scmGoodsUnitData);
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    continue;
#endif
                }

                // 自動回答品目設定を保持
                scmGoodsUnitData.AutoAnsItemStConfig = selectAutoAnsItemSt;

                // 初期設定：自動回答しない
                scmGoodsUnitData.CanReplyAutomatically = false;

                if (IsReplyAutomaticallyAtAutoAnswerDiv(selectAutoAnsItemSt))
                {
                    #region <Log>

                    string msg = string.Format(
                        "自動回答品目です。自動回答区分={0}：{1}",
                        selectAutoAnsItemSt.AutoAnswerDiv,
                        AutoAnsItemStAgent.GetAutoAnswerDivName(selectAutoAnsItemSt)
                    );
                    msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(scmGoodsUnitData);
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>

                    // 問合せ時
                    if (null != foundSCMTtlSt && scmGoodsUnitData.GetAcptAnOdrStatus() == (int)AcptAnOdrStatus.Estimate)
                    {
                        // 自動回答区分：する（全て自動回答）又は する（絞り込み時自動回答）の時
                        if (foundSCMTtlSt.AutoAnsInquiryDiv == 1 || foundSCMTtlSt.AutoAnsInquiryDiv == 2)
                        {
                            scmGoodsUnitData.CanReplyAutomatically = true;
                            exists = true;
                        }
                    }
                    // 発注時
                    if (null != foundSCMTtlSt && scmGoodsUnitData.GetAcptAnOdrStatus() == (int)AcptAnOdrStatus.Sales)
                    {
                        // 自動回答区分：する（全て自動回答）
                        if (foundSCMTtlSt.AutoAnsOrderDiv == 1)
                        {
                            scmGoodsUnitData.CanReplyAutomatically = true;
                            exists = true;
                        }
                        // 自動回答区分：する（委託倉庫分のみ自動回答）
                        else if (foundSCMTtlSt.AutoAnsOrderDiv == 2
                            && scmGoodsUnitData.GetStockDiv() == (int)StockDiv.Trust)
                        {
                            scmGoodsUnitData.CanReplyAutomatically = true;
                            exists = true;
                        }
                    }
                }
                else
                {
                    #region <Log>

                    string msg = "自動回答品目設定マスタ.自動回答区分が「0:しない(全て手動回答)」でした。";
                    msg += Environment.NewLine + "\t" + SCMDataHelper.GetProfile(scmGoodsUnitData);
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // </Log>
                }
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

                // 自動回答品目であれば回答対象にする
                if (scmGoodsUnitData.CanReplyAutomatically)
                {
                    // DEL 2012/11/09 2012/12/12配信 SCM障害№10435対応 -------------------------------------->>>>>
                    ////>>>2012/02/12
                    //scmGoodsUnitData.AcceptOrOrderKind = Searcher.RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind;
                    ////<<<2012/02/12
                    // DEL 2012/11/09 2012/12/12配信 SCM障害№10435対応 -------------------------------------->>>>>

                    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                    // 自動回答品目設定の自動回答区分が「する（優先順位）」の時、高い優先順位を保持する
                    if (scmGoodsUnitData.AutoAnsItemStConfig.AutoAnswerDiv == (int)AutoAnsItemStAgent.AutoAnswerDiv.Priority)
                    {
                        if (selectPriorityOrder == 0 ||
                            selectPriorityOrder > (int)scmGoodsUnitData.AutoAnsItemStConfig.PriorityOrder)
                        {
                            // 優先順位設定
                            selectPriorityOrder = (int)scmGoodsUnitData.AutoAnsItemStConfig.PriorityOrder;
                        }
                    }
                    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

                    scmGoodsUnitDataList.Add(scmGoodsUnitData);
                }

            }   // foreach (GoodsUnitData goodsUnitData in Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList)

            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            #region 削除(SCM改良の為)
            //// ADD 2012/06/29 湯上 No.274 ---------------------------------------------------->>>>>
            //// PCCUOEの問合せで自動回答品目が１件も存在しない時、純正品のみ回答する
            //if (RelationalHeaderMap[detailRecord.ToRelationKey()].AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&
            //    RelationalHeaderMap[detailRecord.ToRelationKey()].InqOrdAnsDivCd == (int)InqOrdAnsDivCd.Inquiry &&
            //    scmGoodsUnitDataList.Count == 0)
            //{
            //    if (pureGoodsUnitDataList != null && pureGoodsUnitDataList.Count != 0)
            //    {
            //        scmGoodsUnitDataList = pureGoodsUnitDataList;
            //        exists = true;

            //        #region <Log>

            //        string msg = "自動回答品目が１件も存在しないため純正品のみ回答します。";
            //        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            //        #endregion // </Log>
            //    }
            //}
            //// ADD 2012/06/29 湯上 No.274 ----------------------------------------------------<<<<<
            #endregion
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            // 自動回答品目設定の自動回答区分が「する（優先順位）」の時、最優先の品目以外は除外する
            if (selectPriorityOrder != 0)
            {
                List<SCMGoodsUnitData> deleteList = new List<SCMGoodsUnitData>();
                foreach (SCMGoodsUnitData scmGoodsUnitDataRecored in scmGoodsUnitDataList)
                {
                    if (scmGoodsUnitDataRecored.AutoAnsItemStConfig.AutoAnswerDiv == (int)AutoAnsItemStAgent.AutoAnswerDiv.Priority &&
                        (int)scmGoodsUnitDataRecored.AutoAnsItemStConfig.PriorityOrder > selectPriorityOrder)
                    {
                        deleteList.Add(scmGoodsUnitDataRecored);
                    }
                }
                foreach (SCMGoodsUnitData deleteRecord in deleteList)
                {
                    scmGoodsUnitDataList.Remove(deleteRecord);
                }
            }
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

            return new SCMGoodsUnitDataListPair(exists, scmGoodsUnitDataList);
        }

        /// <summary>
        /// 自動回答区分が"しない"以外であるか判断します。
        /// </summary>
        /// <param name="scmPrtSettingRecord">SCM品目設定マスタのレコード</param>
        /// <returns>
        /// <c>true</c> :納期または価格<br/>
        /// <c>false</c>:しない
        /// </returns>
        protected static bool IsReplyAutomaticallyAtAutoAnswerDiv(SCMPrtSetting scmPrtSettingRecord)
        {
            // SCM品目設定マスタ.自動回答区分…0:しない, 1:納期, 2:価格
            return !scmPrtSettingRecord.AutoAnswerDiv.Equals((int)SCMPrtSettingAgent.AutoAnswerDiv.None);
        }

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
        /// <summary>
        /// 自動回答区分が"しない"以外であるか判断します。
        /// </summary>
        /// <param name="autoAnsItemStRecord">自動回答品目設定マスタのレコード</param>
        /// <returns>
        /// <c>true</c> :する（全て自動回答又は優先順位）<br/>
        /// <c>false</c>:しない（全て手動回答）
        /// </returns>
        protected static bool IsReplyAutomaticallyAtAutoAnswerDiv(AutoAnsItemSt autoAnsItemStRecord)
        {
            // 自動回答品目設定マスタ.自動回答区分…0:しない(全て手動回答), 1:する(全て自動回答), 2:する(優先順位)
            return !autoAnsItemStRecord.AutoAnswerDiv.Equals((int)AutoAnsItemStAgent.AutoAnswerDiv.None);
        }
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

        // DEL 2015/01/29 SCM高速化Redmine#87対応 ---------------------------------------->>>>>
        #region 削除
        //// ADD 2015/01/28 SCM高速化Redmine#61対応 --------------------------------------->>>>>
        ///// <summary>
        /////  提供区分がユーザー登録の提供データか判定します
        ///// </summary>
        ///// <param name="goodsUnitData">商品情報</param>
        ///// <returns>true:ユーザー登録の提供データ false:提供データ・ユーザー登録のみ</returns>
        //private bool IsUserRegistAtOfferKubun(GoodsUnitData goodsUnitData)
        //{
        //    if (goodsUnitData == null) return false;

        //    switch (goodsUnitData.OfferKubun)
        //    {
        //        case 0:                 // ユーザー登録
        //            {
        //                // 0:ユーザー登録
        //                if (goodsUnitData.OfferDataDiv == 0)
        //                {
        //                    return false;
        //                }
        //                // 1:提供データ
        //                else if (goodsUnitData.OfferDataDiv == 1)
        //                {
        //                    return true;
        //                }
        //                return false;
        //            }
        //        case 1: return true;    // 1:提供純正編集
        //        case 2: return true;    // 2:提供優良編集
        //        case 3: return false;   // 3:提供純正
        //        case 4: return false;   // 4:提供優良
        //        case 5: return false;   // 5:TBO
        //        case 7: return false;   // 7:オリジナル部品
        //        default:
        //            return false;
        //    }
        //}

        ///// <summary>
        /////  提供データの価格情報を取得します
        ///// </summary>
        ///// <param name="goodsUnitData"></param>
        ///// <param name="mkrSuggestRtPricList"></param>
        //private void GetOfferGoodsPrice(GoodsUnitData goodsUnitData, out List<GoodsPrice> mkrSuggestRtPricList)
        //{
        //    mkrSuggestRtPricList = null;

        //    if (goodsUnitData == null) return;

        //    // メーカーコード、品番より提供データの価格情報を取得
        //    ArrayList goodsPriceUWorkList = new ArrayList();
        //    GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
        //    ArrayList lstCond = new ArrayList();
        //    ArrayList lstRst;
        //    ArrayList lstRstPrm;
        //    ArrayList lstPrmPrice;

        //    OfrPrtsSrchCndWork work = new OfrPrtsSrchCndWork();
        //    work.MakerCode = goodsUnitData.GoodsMakerCd;
        //    work.PrtsNo = goodsUnitData.GoodsNo;
        //    lstCond.Add(work);

        //    if (_iOfferPartsInfo == null) _iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
        //    int status = _iOfferPartsInfo.GetOfrPartsInf(lstCond, out lstRst, out lstRstPrm, out lstPrmPrice);
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        if ((lstPrmPrice != null) && (lstPrmPrice.Count != 0))
        //        {
        //            // 優良価格
        //            foreach (OfferJoinPriceRetWork retWork in lstPrmPrice)
        //            {
        //                goodsPriceUWork = new GoodsPriceUWork();
        //                goodsPriceUWork.GoodsMakerCd = retWork.PartsMakerCd;
        //                goodsPriceUWork.GoodsNo = retWork.PrimePartsNoWithH;
        //                goodsPriceUWork.ListPrice = retWork.NewPrice;
        //                goodsPriceUWork.OfferDate = retWork.OfferDate;
        //                goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
        //                goodsPriceUWork.PriceStartDate = retWork.PriceStartDate;

        //                goodsPriceUWorkList.Add(goodsPriceUWork);
        //            }
        //        }
        //        if ((lstRst != null) && (lstRst.Count != 0))
        //        {
        //            // 純正価格
        //            foreach (RetPartsInf retWork in lstRst)
        //            {
        //                goodsPriceUWork = new GoodsPriceUWork();
        //                goodsPriceUWork.GoodsMakerCd = retWork.CatalogPartsMakerCd;
        //                goodsPriceUWork.GoodsNo = retWork.ClgPrtsNoWithHyphen;
        //                goodsPriceUWork.ListPrice = retWork.PartsPrice;
        //                goodsPriceUWork.OfferDate = retWork.OfferDate;
        //                goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
        //                goodsPriceUWork.PriceStartDate = retWork.PartsPriceStDate;

        //                goodsPriceUWorkList.Add(goodsPriceUWork);
        //            }
        //        }
        //    }

        //    if (goodsPriceUWorkList != null && goodsPriceUWorkList.Count != 0)
        //    {
        //        // 価格情報リスト(ArrayList)をGoodsPriceのリストに変換
        //        GetGoodsPriceListFromGoodsPriceUWorkList(goodsPriceUWorkList, out mkrSuggestRtPricList);
        //    }
        //}

        ///// <summary>
        ///// 価格情報データオブジェクトリスト取得処理
        ///// </summary>
        ///// <param name="goodsPriceWorkList">価格情報データワークオブジェクトリスト</param>
        ///// <param name="goodsPriceList">価格情報データオブジェクトリスト</param>
        //private void GetGoodsPriceListFromGoodsPriceUWorkList(ArrayList goodsPriceWorkList, out List<GoodsPrice> goodsPriceList)
        //{
        //    goodsPriceList = new List<GoodsPrice>();

        //    foreach (GoodsPriceUWork goodsPriceUWork in goodsPriceWorkList)
        //    {
        //        GoodsPrice goodsPrice = new GoodsPrice();

        //        goodsPrice.CreateDateTime = goodsPriceUWork.CreateDateTime; // 作成日時
        //        goodsPrice.UpdateDateTime = goodsPriceUWork.UpdateDateTime; // 更新日時
        //        goodsPrice.EnterpriseCode = goodsPriceUWork.EnterpriseCode; // 企業コード
        //        goodsPrice.FileHeaderGuid = goodsPriceUWork.FileHeaderGuid; // GUID
        //        goodsPrice.UpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode; // 更新従業員コード
        //        goodsPrice.UpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1; // 更新アセンブリID1
        //        goodsPrice.UpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2; // 更新アセンブリID2
        //        goodsPrice.LogicalDeleteCode = goodsPriceUWork.LogicalDeleteCode; // 論理削除区分
        //        goodsPrice.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd; // 商品メーカーコード
        //        goodsPrice.GoodsNo = goodsPriceUWork.GoodsNo; // 商品番号
        //        goodsPrice.PriceStartDate = goodsPriceUWork.PriceStartDate; // 価格開始日
        //        goodsPrice.ListPrice = goodsPriceUWork.ListPrice; // 定価（浮動）
        //        goodsPrice.SalesUnitCost = goodsPriceUWork.SalesUnitCost; // 原価単価
        //        goodsPrice.StockRate = goodsPriceUWork.StockRate; // 仕入率
        //        goodsPrice.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv; // オープン価格区分
        //        goodsPrice.OfferDate = goodsPriceUWork.OfferDate; // 提供日付
        //        goodsPrice.UpdateDate = goodsPriceUWork.UpdateDate; // 更新年月日

        //        goodsPriceList.Add(goodsPrice);
        //    }
        //}
        //// ADD 2015/01/28 SCM高速化Redmine#61対応 ---------------------------------------<<<<<
        #endregion
        // DEL 2015/01/29 SCM高速化Redmine#87対応 ---------------------------------------->>>>>

        #endregion // </自動回答品目>

        #region <各種価格算出>

        /// <summary>
        /// 単価を算出します。(SCM情報付商品連結データに設定します)
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        protected void CalclateUnitPrice(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            const string METHOD_NAME = "CalclateUnitPrice()";   // ログ用

            #region <Guard Phrase>

            // ヘッダがない
            if (!RelationalHeaderMap.ContainsKey(detailRecord.ToRelationKey()))
            {
                Debug.Assert(false, string.Format("明細のヘッダが存在しません。：{0}", detailRecord.ToRelationKey()));
                return;
            }

            // 検索結果がない
            if (!Searcher.ResultMap.ContainsKey(detailRecord.ToKey()))
            {
                return;
            }

            #endregion // </Guard Phrase>

            foreach (SCMGoodsUnitData goodsUnitData in scmGoodsUnitDataList)
            {
                // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
                #region 見積計上用処理

                // 見積で回答済み商品の場合、見積データの各種金額情報を使用する
                if (goodsUnitData.RealGoodsUnitData is AnsweredGoodsUnitData)
                {
                    #region <Log>

                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("見積データの各種金額情報を使用します。∵見積で回答済み商品です"));

                    #endregion // </Log>

                    AnsweredGoodsUnitData answeredGoodsUnitData = goodsUnitData.RealGoodsUnitData as AnsweredGoodsUnitData;
                    goodsUnitData.UnitPriceCalcRetList = answeredGoodsUnitData.UnitPriceList;
                    continue;
                }

                #endregion // 見積計上用処理
                // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

                // --- DEL 2015/02/24 T.Miyamoto ------------------------------>>>>>
                //// ADD 2015/01/19 リコメンド対応 -------------------------------------->>>>>
                //// リコメンド発注時は単価計算を行わない
                //if (detailRecord.BgnGoodsDiv == (short)BgnGoodsDiv.BargainItem)
                //{
                //    goodsUnitData.UnitPriceCalcRetList = new List<UnitPriceCalcRet>();
                //    continue;
                //}
                //// ADD 2015/01/19 リコメンド対応 --------------------------------------<<<<<
                // --- DEL 2015/02/24 T.Miyamoto ------------------------------<<<<<

                //>>>2010/07/07 add

                List<SalesProcMoney> salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(detailRecord.EnterpriseCode);

                Calculator.RealAccesser.CacheSalesProcMoneyList(salesProcMoneyList);

                List<StockProcMoney> stockProcMoneyList = (List<StockProcMoney>)StockProcMoneyServer.Singleton.Instance.Find(detailRecord.EnterpriseCode);

                Calculator.RealAccesser.CacheStockProcMoneyList(stockProcMoneyList);

                //<<<2010/07/07 add
                // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                //IList<UnitPriceCalcRet> unitPriceList = Calculator.GetUnitPrice(
                //    GetCustomerCode(detailRecord),
                //    detailRecord,
                //    goodsUnitData.RealGoodsUnitData
                //);
                IList<UnitPriceCalcRet> unitPriceList = Calculator.GetUnitPrice(
                    GetCustomerCode(detailRecord),
                    detailRecord,
                    goodsUnitData.RealGoodsUnitData,
                    HeaderRecordList[0].CancelDiv,
                    HeaderRecordList[0].InquiryDate
                );
                // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                goodsUnitData.UnitPriceCalcRetList = unitPriceList;
            }
        }

        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応 ------------------------------------------->>>>>
        /// <summary>
        ///  変更前商品連結データ単価計算
        /// </summary>
        public void CalclateUnitPriceForBeforeGoodsUnitDataList(ISCMOrderDetailRecord detailRecord)
        {
            const string METHOD_NAME = "CalclateUnitPriceForBeforeGoodsUnitDataList()";   // ログ用
            string detailKey = detailRecord.ToKey();

            #region <Guard Phrase>

            // 変更前商品連結データがない
            if (this._beforeScmGoodsUnitDataMap == null || this._beforeScmGoodsUnitDataMap.Count == 0)
            {
                Debug.Assert(false, string.Format("変更前商品連結データマップが存在しません。"));
                return;
            }
            if (!this._beforeScmGoodsUnitDataMap.ContainsKey(detailKey))
            {
                return;
            }

            #endregion // </Guard Phrase>

            foreach (SCMGoodsUnitData goodsUnitData in this._beforeScmGoodsUnitDataMap[detailKey])
            {
                // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
                #region 見積計上用処理

                // 見積で回答済み商品の場合、見積データの各種金額情報を使用する
                if (goodsUnitData.RealGoodsUnitData is AnsweredGoodsUnitData)
                {
                    #region <Log>

                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("見積データの各種金額情報を使用します。∵見積で回答済み商品です"));

                    #endregion // </Log>

                    AnsweredGoodsUnitData answeredGoodsUnitData = goodsUnitData.RealGoodsUnitData as AnsweredGoodsUnitData;
                    goodsUnitData.UnitPriceCalcRetList = answeredGoodsUnitData.UnitPriceList;
                    continue;
                }

                #endregion // 見積計上用処理
                // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

                // --- DEL 2015/02/24 T.Miyamoto ------------------------------>>>>>
                //// ADD 2015/01/19 リコメンド対応 -------------------------------------->>>>>
                //// リコメンド時は単価計算を行わない
                //if (detailRecord.BgnGoodsDiv == (short)BgnGoodsDiv.BargainItem)
                //{
                //    goodsUnitData.UnitPriceCalcRetList = new List<UnitPriceCalcRet>();
                //    continue;
                //}
                //// ADD 2015/01/19 リコメンド対応 --------------------------------------<<<<<
                // --- DEL 2015/02/24 T.Miyamoto ------------------------------<<<<<

                //>>>2010/07/07 add
                List<SalesProcMoney> salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(detailRecord.EnterpriseCode);

                Calculator.RealAccesser.CacheSalesProcMoneyList(salesProcMoneyList);

                List<StockProcMoney> stockProcMoneyList = (List<StockProcMoney>)StockProcMoneyServer.Singleton.Instance.Find(detailRecord.EnterpriseCode);

                Calculator.RealAccesser.CacheStockProcMoneyList(stockProcMoneyList);

                IList<UnitPriceCalcRet> unitPriceList = Calculator.GetUnitPrice(
                    GetCustomerCode(detailRecord),
                    detailRecord,
                    goodsUnitData.RealGoodsUnitData,
                    HeaderRecordList[0].CancelDiv,
                    HeaderRecordList[0].InquiryDate
                );
                goodsUnitData.UnitPriceCalcRetList = unitPriceList;
            }
        }
        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№03.変更前単価計算呼出回数改良対応 -------------------------------------------<<<<<

        // ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------>>>>>
        /// <summary>
        /// 優良品の定価及び売価を再設定します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        protected void SetListPrice(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {

            #region <Guard Phrase>
            // ヘッダがない
            if (!RelationalHeaderMap.ContainsKey(detailRecord.ToRelationKey()))
            {
                Debug.Assert(false, string.Format("明細のヘッダが存在しません。：{0}", detailRecord.ToRelationKey()));
                return;
            }

            // 検索結果がない
            if (!Searcher.ResultMap.ContainsKey(detailRecord.ToKey()))
            {
                return;
            }

            #endregion <Guard Phrase>

            UnitPriceCalcRet goodsPriceResult = null;  // 定価
            bool listPriceSettingFlag = false;         // 単価再設定フラグ true:再計算する false:再計算しない

            // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>

            #region 自動回答時表示区分取得
            if (this._autoAnsHourDspDiv < 0)
            {
                this._scmTtlSt = TtlStSettingDB.Find(
                    detailRecord.InqOtherEpCd,
                    detailRecord.InqOtherSecCd
                );
                this._autoAnsHourDspDiv = this._scmTtlSt.AutoAnsHourDspDiv;
            }
            #endregion

            #region 表示区分マスタ取得
            if (_priceSelectSetAgent == null)
            {
                //表示区分マスタ取得
                _priceSelectSetAgent = PriceSelectSetAgentServer.Singleton.Instance.FindList(LoginInfoAcquisition.EnterpriseCode);
            }
            #endregion

            #region 得意先掛率グループ情報
            //-----------------------------------------------------
            // 得意先掛率グループ情報
            //-----------------------------------------------------
            ArrayList custRateGroupList;
            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№02.得意先掛率グループマスタ取得改良対応（回答判定時） ---------------------------------->>>>>
            //this._custRateGroupList.Clear();
            //if (GetCustomerCode(this.DetailRecordList[0]) != 0)
            //{
            //    this._custRateGroupAcs.Search(out custRateGroupList, this.DetailRecordList[0].InqOtherEpCd, GetCustomerCode(this.DetailRecordList[0]), ConstantManagement.LogicalMode.GetData0);
            //    if ((custRateGroupList != null) && (custRateGroupList.Count != 0))
            //    {
            //        this._custRateGroupList = new List<CustRateGroup>((CustRateGroup[])custRateGroupList.ToArray(typeof(CustRateGroup)));
            //    }
            //}
            int customerCode = GetCustomerCode(this.DetailRecordList[0]);
            if (customerCode != 0 && customerCode != this._prevCustomerCode)
            {
                this._custRateGroupList.Clear();
                this._custRateGroupAcs.Search(out custRateGroupList, this.DetailRecordList[0].InqOtherEpCd, GetCustomerCode(this.DetailRecordList[0]), ConstantManagement.LogicalMode.GetData0);
                if ((custRateGroupList != null) && (custRateGroupList.Count != 0))
                {
                    this._custRateGroupList = new List<CustRateGroup>((CustRateGroup[])custRateGroupList.ToArray(typeof(CustRateGroup)));
                }
                this._prevCustomerCode = customerCode;
            }
            // UPD 2014/05/08 PM-SCM速度改良 フェーズ２№02.得意先掛率グループマスタ取得改良対応（回答判定時） ----------------------------------<<<<<
            #endregion

            // 検索結果データクラス退避
            PartsInfoDataSet savePartsInfo = null;
            if (Searcher.ResultMap[detailRecord.ToKey()].PartsInfoDB != null)
            {
                savePartsInfo = (PartsInfoDataSet)Searcher.ResultMap[detailRecord.ToKey()].PartsInfoDB.Copy();
            }

            PartsInfoDataSet partsInfoDataSet = (PartsInfoDataSet)Searcher.ResultMap[detailRecord.ToKey()].PartsInfoDB;

            // 回答純正品番設定
            IList<SCMGoodsUnitData> retScmGoodsUnitDataList = new List<SCMGoodsUnitData>();
            List<SCMGoodsUnitData> pureGoodsUnitDataList = new List<SCMGoodsUnitData>();

            // 純正品番のみ抽出
            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                // 純正品の時、純正品番リストに格納
                if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                {
                    pureGoodsUnitDataList.Add(scmGoodsUnitData);
                }
            }

            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                // ResultMapより商品情報を取得
                List<GoodsUnitData> goodsUnitDataList = Searcher.ResultMap[detailRecord.ToKey()].GoodsUnitDataList;
                // 対象品番抽出
                GoodsUnitData targetGoods = goodsUnitDataList.Find(
                    delegate(GoodsUnitData goodsUnitData)
                    {
                        if ((goodsUnitData.GoodsNo == scmGoodsUnitData.RealGoodsUnitData.GoodsNo) &&
                            (goodsUnitData.GoodsMakerCd == scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                int j = 0;
                while (true)
                {
                    int pureGoodsMakerCd = 0;
                    string ansPureGoodsNo = string.Empty;
                    bool ret = false;
                    if ((targetGoods != null) && (partsInfoDataSet != null))
                    {
                        // 純正品番取得
                        ret = this.GetPureInfo(partsInfoDataSet, targetGoods.GoodsMakerCd, targetGoods.GoodsNo, j, out pureGoodsMakerCd, out ansPureGoodsNo);
                        // 2013/12/09 SCM仕掛一覧№10608対応 --------------------------------------------------------->>>>>
                        // 問合せ時のメーカー・品番が指定されている時は再問合せとみなし、純正メーカーコード・純正品番は問合せ時のコードを使用する
                        if (!string.IsNullOrEmpty(detailRecord.GoodsNo.Trim()) && detailRecord.GoodsMakerCd != 0)
                        {
                            pureGoodsMakerCd = detailRecord.PureGoodsMakerCd;
                            ansPureGoodsNo = detailRecord.AnsPureGoodsNo;
                        }
                        // 2013/12/09 SCM仕掛一覧№10608対応 ---------------------------------------------------------<<<<<
                        // ADD 2014/11/10 PM-SCM優先案件11月対応分 --------------------------------------------->>>>>
                        else
                        {
                            // 品番検索時は結合状態で回答しないため回答純正メーカー・回答純正品番に結合先メーカー・品番を設定する
                            if (scmGoodsUnitData.SearchedType == SCMSearchedResult.GoodsSearchDivCd.GoodsNo)
                            {
                                pureGoodsMakerCd = targetGoods.GoodsMakerCd;
                                ansPureGoodsNo = targetGoods.GoodsNo;
                            }
                        }
                        // ADD 2014/11/10 PM-SCM優先案件11月対応分 ---------------------------------------------<<<<<
                        if (pureGoodsMakerCd == 0) pureGoodsMakerCd = targetGoods.GoodsMakerCd;
                        if (ansPureGoodsNo == string.Empty) ansPureGoodsNo = targetGoods.GoodsNo;
                    }
                    // 純正品番設定
                    scmGoodsUnitData.PureGoodsMakerCd = pureGoodsMakerCd;
                    scmGoodsUnitData.AnsPureGoodsNo = ansPureGoodsNo;

                    if ((!IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData)) && (ret == false))
                    {
                        retScmGoodsUnitDataList.Add(scmGoodsUnitData);
                        break;
                    }

                    bool pureFlg = false;
                    bool bFlg = false;
                    // 優良品番の時
                    if (!IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                    {
                        // 回答純正品番重複チェック
                        foreach (SCMGoodsUnitData loopUnitData in retScmGoodsUnitDataList)
                        {
                            if ((loopUnitData.AnsPureGoodsNo == scmGoodsUnitData.AnsPureGoodsNo) &&
                                (loopUnitData.PureGoodsMakerCd == scmGoodsUnitData.PureGoodsMakerCd) &&
                                (loopUnitData.RealGoodsUnitData.GoodsNo == scmGoodsUnitData.RealGoodsUnitData.GoodsNo) &&
                                (loopUnitData.RealGoodsUnitData.GoodsMakerCd == scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd))
                            {
                                bFlg = true;
                            }
                        }
                        // 回答純正品番が回答対象データに含まれているか
                        foreach (SCMGoodsUnitData pureUnitData in pureGoodsUnitDataList)
                        {
                            if (pureUnitData.RealGoodsUnitData.GoodsNo == scmGoodsUnitData.AnsPureGoodsNo &&
                                pureUnitData.RealGoodsUnitData.GoodsMakerCd == scmGoodsUnitData.PureGoodsMakerCd)
                            {
                                pureFlg = true;
                            }
                        }
                    }
                    else
                    {
                        pureFlg = true;
                    }
                    if (bFlg == false && pureFlg == true)
                    {
                        retScmGoodsUnitDataList.Add(scmGoodsUnitData);
                        break;
                    }
                    j++;
                }
            }
            // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<

            // 定価設定
            foreach (SCMGoodsUnitData goodsUnitData in scmGoodsUnitDataList)
            {
                // 純正品の時は次の品番へ
                if (IsPureAtOfferKubun(goodsUnitData.RealGoodsUnitData))
                {
                    continue;
                }
                // 価格情報未設定時は次の品番へ
                if (goodsUnitData.RealGoodsUnitData.GoodsPriceList == null ||
                    goodsUnitData.RealGoodsUnitData.GoodsPriceList.Count == 0)
                {
                    continue;
                }

                // 価格情報リストより定価情報取得
                UnitPriceCalcRet listPriceResult = new UnitPriceCalcRet();
                foreach (UnitPriceCalcRet unitPriceCalcRet in goodsUnitData.UnitPriceCalcRetList)
                {
                    if (unitPriceCalcRet.UnitPriceKind.Equals(UnitPriceCalculation.ctUnitPriceKind_ListPrice))
                    {
                        listPriceResult = unitPriceCalcRet;
                        break;
                    }
                }
                // 優良品定価が掛率設定済みの時は次の品番へ
                if (listPriceResult.RateMngCustCd.Trim().Length != 0)
                {
                    continue;
                }

                listPriceSettingFlag = false;

                // 価格選択画面による標準単価選択時、定価を再設定
                if (goodsUnitData.RealGoodsUnitData.SelectedListPrice > 0)
                {
                    DateTime dateWk = DateTime.MinValue;
                    foreach (GoodsPrice listPrice in goodsUnitData.RealGoodsUnitData.GoodsPriceList)
                    {
                        if ((listPrice.PriceStartDate <= DateTime.Today) && (listPrice.PriceStartDate > dateWk))
                        {
                            listPrice.ListPrice = goodsUnitData.RealGoodsUnitData.SelectedListPrice;
                            listPriceSettingFlag = true;
                        }
                    }
                }
                // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
                else
                {
                    // ADD 2012/11/09 2012/12/12配信 SCM障害№10427対応 -------------------------------------->>>>>
                    int autoAnsHourDspDiv = this._autoAnsHourDspDiv;   // 自動回答時表示区分
                    // ADD 2012/11/09 2012/12/12配信 SCM障害№10427対応 --------------------------------------<<<<<

                    // SCM全体設定マスタの自動回答時表示区分が「PM設定に従う」時、価格表示区分を取得する
                    if (autoAnsHourDspDiv == 1)
                    {
                        int priceSelectDiv = -1;   //価格表示区分

                        //価格表示区分取得
                        PriceSelectSetAgentServer.Singleton.Instance.GetDisplayDiv(_priceSelectSetAgent, goodsUnitData.RealGoodsUnitData.GoodsMakerCd, goodsUnitData.RealGoodsUnitData.BLGoodsCode, goodsUnitData.CustomerCode, GetCustRateGroupCode(goodsUnitData.RealGoodsUnitData.GoodsMakerCd), out priceSelectDiv);

                        switch (priceSelectDiv)
                        {
                            case 0:  // 優良
                                autoAnsHourDspDiv = 2;
                                break;
                            case 1:  // 純正
                                autoAnsHourDspDiv = 3;
                                break;
                            case 2:  // 高い方(1:N)
                                autoAnsHourDspDiv = 4;
                                break;
                            case 3:  // 高い方(1:1)
                                autoAnsHourDspDiv = 5;
                                break;
                            default:
                                autoAnsHourDspDiv = priceSelectDiv;
                                break;
                        }
                    }

                    // 表示区分により定価設定
                    switch (autoAnsHourDspDiv)
                    {
                        case 1: // PM設定に従う（表示区分マスタの表示区分を使用するためこの条件に一致することはない） 
                        case 2: //優良 
                            {
                                break;  // 何もしない
                            }
                        case 3: //純正
                            {
                                goodsPriceResult = null;
                                // 純正品番定価を取得
                                foreach (SCMGoodsUnitData pureGoodsUnitData in pureGoodsUnitDataList)
                                {
                                    if (pureGoodsUnitData.RealGoodsUnitData.GoodsMakerCd == goodsUnitData.PureGoodsMakerCd
                                        && pureGoodsUnitData.RealGoodsUnitData.GoodsNo == goodsUnitData.AnsPureGoodsNo)
                                    {
                                        goodsPriceResult = CalculatorAgent.GetListPriceResult(pureGoodsUnitData.UnitPriceCalcRetList);
                                        break;
                                    }
                                }
                                if (goodsPriceResult != null)
                                {
                                    // 純正定価を設定
                                    DateTime dateWk = DateTime.MinValue;
                                    foreach (GoodsPrice listPrice in goodsUnitData.RealGoodsUnitData.GoodsPriceList)
                                    {
                                        if ((listPrice.PriceStartDate <= DateTime.Today) && (listPrice.PriceStartDate > dateWk))
                                        {
                                            listPrice.ListPrice = goodsPriceResult.UnitPriceTaxExcFl;
                                            listPriceSettingFlag = true;
                                        }
                                    }
                                }
                                else
                                {
                                    // 価格選択画面による標準単価選択時、定価を再設定
                                    if (goodsUnitData.RealGoodsUnitData.SelectedListPrice > 0)
                                    {
                                        DateTime dateWk = DateTime.MinValue;
                                        foreach (GoodsPrice listPrice in goodsUnitData.RealGoodsUnitData.GoodsPriceList)
                                        {
                                            if ((listPrice.PriceStartDate <= DateTime.Today) && (listPrice.PriceStartDate > dateWk))
                                            {
                                                listPrice.ListPrice = goodsUnitData.RealGoodsUnitData.SelectedListPrice;
                                                listPriceSettingFlag = true;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 4: //高い方(1:N)
                            {
                                goodsPriceResult = null;
                                // 純正品番定価を取得
                                foreach (SCMGoodsUnitData pureGoodsUnitData in pureGoodsUnitDataList)
                                {
                                    if (pureGoodsUnitData.RealGoodsUnitData.GoodsMakerCd == goodsUnitData.PureGoodsMakerCd
                                        && pureGoodsUnitData.RealGoodsUnitData.GoodsNo == goodsUnitData.AnsPureGoodsNo)
                                    {
                                        goodsPriceResult = CalculatorAgent.GetListPriceResult(pureGoodsUnitData.UnitPriceCalcRetList);
                                        break;
                                    }
                                }
                                // 高い定価を設定
                                if (goodsPriceResult != null &&
                                    listPriceResult.UnitPriceTaxExcFl <= goodsPriceResult.UnitPriceTaxExcFl)
                                {
                                    DateTime dateWk = DateTime.MinValue;
                                    foreach (GoodsPrice listPrice in goodsUnitData.RealGoodsUnitData.GoodsPriceList)
                                    {
                                        if ((listPrice.PriceStartDate <= DateTime.Today) && (listPrice.PriceStartDate > dateWk))
                                        {
                                            listPrice.ListPrice = goodsPriceResult.UnitPriceTaxExcFl;
                                            listPriceSettingFlag = true;
                                        }
                                    }
                                }
                                else if (goodsPriceResult == null)
                                {
                                    // 価格選択画面による標準単価選択時、定価を再設定
                                    if (goodsUnitData.RealGoodsUnitData.SelectedListPrice > 0)
                                    {
                                        DateTime dateWk = DateTime.MinValue;
                                        foreach (GoodsPrice listPrice in goodsUnitData.RealGoodsUnitData.GoodsPriceList)
                                        {
                                            if ((listPrice.PriceStartDate <= DateTime.Today) && (listPrice.PriceStartDate > dateWk))
                                            {
                                                listPrice.ListPrice = goodsUnitData.RealGoodsUnitData.SelectedListPrice;
                                                listPriceSettingFlag = true;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 5: //高い方(1:1)
                            {
                                goodsPriceResult = null;
                                // 純正品番定価を取得
                                foreach (SCMGoodsUnitData pureGoodsUnitData in pureGoodsUnitDataList)
                                {
                                    if (pureGoodsUnitData.RealGoodsUnitData.GoodsMakerCd == goodsUnitData.PureGoodsMakerCd
                                        && pureGoodsUnitData.RealGoodsUnitData.GoodsNo == goodsUnitData.AnsPureGoodsNo)
                                    {
                                        goodsPriceResult = CalculatorAgent.GetListPriceResult(pureGoodsUnitData.UnitPriceCalcRetList);
                                        break;
                                    }
                                }
                                // 高い定価を設定
                                if (goodsPriceResult != null &&
                                    listPriceResult.UnitPriceTaxExcFl <= goodsPriceResult.UnitPriceTaxExcFl)
                                {
                                    DateTime dateWk = DateTime.MinValue;
                                    foreach (GoodsPrice listPrice in goodsUnitData.RealGoodsUnitData.GoodsPriceList)
                                    {
                                        if ((listPrice.PriceStartDate <= DateTime.Today) && (listPrice.PriceStartDate > dateWk))
                                        {
                                            listPrice.ListPrice = goodsPriceResult.UnitPriceTaxExcFl;
                                            listPriceSettingFlag = true;
                                        }
                                    }
                                }
                                else if (goodsPriceResult == null)
                                {
                                    // 価格選択画面による標準単価選択時、定価を再設定
                                    if (goodsUnitData.RealGoodsUnitData.SelectedListPrice > 0)
                                    {
                                        DateTime dateWk = DateTime.MinValue;
                                        foreach (GoodsPrice listPrice in goodsUnitData.RealGoodsUnitData.GoodsPriceList)
                                        {
                                            if ((listPrice.PriceStartDate <= DateTime.Today) && (listPrice.PriceStartDate > dateWk))
                                            {
                                                listPrice.ListPrice = goodsUnitData.RealGoodsUnitData.SelectedListPrice;
                                                listPriceSettingFlag = true;
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        default:  // 該当区分が存在しない時
                            {
                                // 価格選択画面による標準単価選択時、定価を再設定
                                if (goodsUnitData.RealGoodsUnitData.SelectedListPrice > 0)
                                {
                                    DateTime dateWk = DateTime.MinValue;
                                    foreach (GoodsPrice listPrice in goodsUnitData.RealGoodsUnitData.GoodsPriceList)
                                    {
                                        if ((listPrice.PriceStartDate <= DateTime.Today) && (listPrice.PriceStartDate > dateWk))
                                        {
                                            listPrice.ListPrice = goodsUnitData.RealGoodsUnitData.SelectedListPrice;
                                            listPriceSettingFlag = true;
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
                // UPD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<

                // 単価の再計算を行う
                if (listPriceSettingFlag)
                {
                    List<SalesProcMoney> salesProcMoneyList = (List<SalesProcMoney>)SalesProcMoneyServer.Singleton.Instance.Find(detailRecord.EnterpriseCode);

                    Calculator.RealAccesser.CacheSalesProcMoneyList(salesProcMoneyList);

                    List<StockProcMoney> stockProcMoneyList = (List<StockProcMoney>)StockProcMoneyServer.Singleton.Instance.Find(detailRecord.EnterpriseCode);

                    Calculator.RealAccesser.CacheStockProcMoneyList(stockProcMoneyList);

                    //<<<2010/07/07 add

                    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------>>>>>
                    //IList<UnitPriceCalcRet> unitPriceList = Calculator.GetUnitPrice(
                    //    GetCustomerCode(detailRecord),
                    //    detailRecord,
                    //    goodsUnitData.RealGoodsUnitData
                    //);
                    IList<UnitPriceCalcRet> unitPriceList = Calculator.GetUnitPrice(
                        GetCustomerCode(detailRecord),
                        detailRecord,
                        goodsUnitData.RealGoodsUnitData,
                        HeaderRecordList[0].CancelDiv,
                        HeaderRecordList[0].InquiryDate
                    );
                    // UPD 2014/01/30 Redmine#41771-障害№13対応 ------------------------------------------------------<<<<<
                    goodsUnitData.UnitPriceCalcRetList = unitPriceList;
                }
            }
            // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
            // 検索結果データクラス戻し
            if (savePartsInfo != null)
            {
                Searcher.ResultMap[detailRecord.ToKey()].PartsInfoDB = savePartsInfo;
            }
            // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<
        }
        // ADD 2012/11/08 2012/11/14配信 システムテスト障害対応：湯上 ------------------<<<<<

        // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 -------------------------------------->>>>>
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
                        ansPureGoodsNo = usrJoinPartsRows[i].JoinSrcPartsNoWithH;
                    }
                    ret = true;
                }
            }
            // 純正品番が取得できなかった時、代替品の検索を行い代替品該当時は代替元品番で純正品番を取得する
            if (!ret)
            {
                PartsInfoDataSet.UsrSubstPartsDataTable usrSubstPartsDataTable = (PartsInfoDataSet.UsrSubstPartsDataTable)partsInfoDataSet.UsrSubstParts.Copy();

                filter = string.Format("{0}={1} AND {2}='{3}'", usrSubstPartsDataTable.ChgDestMakerCdColumn.ColumnName,
                                                                goodsMakerCd,
                                                                usrSubstPartsDataTable.ChgDestGoodsNoColumn.ColumnName,
                                                                goodsNo);
                PartsInfoDataSet.UsrSubstPartsRow[] usrSubstPartsRows = (PartsInfoDataSet.UsrSubstPartsRow[])usrSubstPartsDataTable.Select(filter);

                if ((usrSubstPartsRows != null) && (usrSubstPartsRows.Length != 0) && !usrSubstPartsRows[0].OfferKubun)
                {
                    usrJoinPartsRows = null;
                    filter = string.Format("{0}={1} AND {2}='{3}'", usrJoinPartsDataTable.JoinDestMakerCdColumn.ColumnName,
                                                                    usrSubstPartsRows[0].ChgSrcMakerCd,
                                                                    usrJoinPartsDataTable.JoinDestPartsNoColumn.ColumnName,
                                                                    usrSubstPartsRows[0].ChgSrcGoodsNo);
                    usrJoinPartsRows = (PartsInfoDataSet.UsrJoinPartsRow[])usrJoinPartsDataTable.Select(filter);

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
                                ansPureGoodsNo = usrJoinPartsRows[i].JoinSrcPartsNoWithH;
                            }
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }
        // ADD 2012/11/09 2012/12/12配信 SCM障害№76対応 --------------------------------------<<<<<

        #endregion // </各種価格算出>

        #region <相場情報適用>

        // 相場情報適用…相場回答は自動、手動問わず行うため、廃止

        #endregion // </相場情報適用>

        #region <自動連携値引適用>

        #endregion // </自動連携値引適用>

        #region <キャンペーン情報適用>

        /// <summary>
        /// キャンペーン情報を取得します。(SCM情報付商品連結データに設定します)
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        private void TakeCampaignInformation(
            SCMOrderDetailRecordType detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            const string METHOD_NAME = "TakeCampaignInformation()"; // ログ用

            int customerCode = GetCustomerCode(detailRecord);
            DateTime inquiryDate = GetInquiryDate(detailRecord);
            // -- DELETE 2011/08/10   ------ >>>>>>
            //CampaignMngAcs campaignMngAcs = new CampaignMngAcs(detailRecord.InqOtherEpCd, detailRecord.InqOtherSecCd);
            // -- DELETE 2011/08/10   ------ <<<<<<
            // -- ADD 2011/08/10   ------ >>>>>>
            // UPD 2014/02/06 SCM仕掛一覧№10634対応 ------------------------------------------------->>>>>
            //CampaignObjGoodsStAcs campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
            if (_campaignObjGoodsStAcs == null) _campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
            // UPD 2014/02/06 SCM仕掛一覧№10634対応 -------------------------------------------------<<<<<
            // -- ADD 2011/08/10   ------ <<<<<<
            {
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    // ADD 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ---------->>>>>
                    #region 見積計上用処理

                    // 見積で回答済み商品の場合、キャンペーン情報を取得しない
                    if (scmGoodsUnitData.RealGoodsUnitData is AnsweredGoodsUnitData)
                    {
                        #region <Log>

                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("キャンペーン情報を取得しません。∵見積で回答済み商品です"));

                        #endregion // </Log>

                        continue;
                    }

                    #endregion // 見積計上用処理
                    // ADD 2010/04/21 見積計上の場合、自動連携値引き、キャンペーン値引きは行わない ----------<<<<<
                    CampaignMng campaignMng = null;
                    // -- DELETE 2011/08/10   ------ >>>>>>
                    //campaignMngAcs.GetRatePriceOfCampaignMng(
                    //    out campaignMng,
                    //    detailRecord.InqOtherEpCd,
                    //    detailRecord.InqOtherSecCd,
                    //    customerCode,
                    //    scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd,
                    //    scmGoodsUnitData.RealGoodsUnitData.GoodsMGroup,
                    //    scmGoodsUnitData.RealGoodsUnitData.BLGoodsCode,
                    //    scmGoodsUnitData.RealGoodsUnitData.GoodsNo,
                    //    inquiryDate
                    //);
                    // -- DELETE 2011/08/10   ------ <<<<<<
                    // -- ADD 2011/08/10   ------ >>>>>>
                    CampaignObjGoodsSt campaignObjGoodsSt;
                    // UPD 2014/02/06 SCM仕掛一覧№10634対応 ------------------------------------------------->>>>>
                    //campaignObjGoodsStAcs.GetRatePriceOfCampaignMng(
                    //    out campaignObjGoodsSt,
                    //    detailRecord.InqOtherEpCd,
                    //    detailRecord.InqOtherSecCd,
                    //    customerCode,
                    //    scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd,
                    //    scmGoodsUnitData.RealGoodsUnitData.BLGroupCode,
                    //    scmGoodsUnitData.RealGoodsUnitData.BLGoodsCode,
                    //    scmGoodsUnitData.RealGoodsUnitData.SalesCode,
                    //    scmGoodsUnitData.RealGoodsUnitData.GoodsNo,
                    //    inquiryDate
                    //);
                    _campaignObjGoodsStAcs.GetRatePriceOfCampaignMng(
                        out campaignObjGoodsSt,
                        detailRecord.InqOtherEpCd,
                        detailRecord.InqOtherSecCd,
                        customerCode,
                        scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd,
                        scmGoodsUnitData.RealGoodsUnitData.BLGroupCode,
                        scmGoodsUnitData.RealGoodsUnitData.BLGoodsCode,
                        scmGoodsUnitData.RealGoodsUnitData.SalesCode,
                        scmGoodsUnitData.RealGoodsUnitData.GoodsNo,
                        inquiryDate
                    );
                    // UPD 2014/02/06 SCM仕掛一覧№10634対応 -------------------------------------------------<<<<<
                    convertCampaignObjGoodsStToCampaignMng(campaignObjGoodsSt, ref campaignMng);
                    // -- ADD 2011/08/10   ------ <<<<<<

                    if (campaignMng == null) continue;

                    scmGoodsUnitData.CampaignInformation = new CampaignInformation(campaignMng);
                }
            }
        }

        #endregion // </キャンペーン情報適用>
        // -- ADD 2011/08/10   ------ >>>>>>
        #region <キャンペーン情報コンバート>

        /// <summary>
        /// キャンペーン情報をコンバートします。
        /// </summary>
        /// <param name="campaignObjGoodsSt">キャンペーン情報</param>
        /// <param name="campaignMng">キャンペーン情報</param>
        private void convertCampaignObjGoodsStToCampaignMng(
            CampaignObjGoodsSt campaignObjGoodsSt,
            ref CampaignMng campaignMng
        )
        {
            if (campaignObjGoodsSt == null)
            {
                return;
            }
            else
            {
                campaignMng = new CampaignMng();
            }
            campaignMng.BLGoodsCode = campaignObjGoodsSt.BLGoodsCode;
            campaignMng.BLGroupCode = campaignObjGoodsSt.BLGroupCode;
            campaignMng.CampaignCode = campaignObjGoodsSt.CampaignCode;
            campaignMng.CreateDateTime = campaignObjGoodsSt.CreateDateTime;
            campaignMng.CreateDateTimeAdFormal = campaignObjGoodsSt.CreateDateTimeAdFormal;
            campaignMng.CreateDateTimeAdInFormal = campaignObjGoodsSt.CreateDateTimeAdInFormal;
            campaignMng.CreateDateTimeJpFormal = campaignObjGoodsSt.CreateDateTimeJpFormal;
            campaignMng.CreateDateTimeJpInFormal = campaignObjGoodsSt.CreateDateTimeJpInFormal;
            campaignMng.EnterpriseCode = campaignObjGoodsSt.EnterpriseCode;
            campaignMng.EnterpriseName = campaignObjGoodsSt.EnterpriseName;
            campaignMng.FileHeaderGuid = campaignObjGoodsSt.FileHeaderGuid;
            campaignMng.GoodsMakerCd = campaignObjGoodsSt.GoodsMakerCd;
            campaignMng.GoodsMGroup = campaignObjGoodsSt.GoodsMGroup;
            campaignMng.GoodsNo = campaignObjGoodsSt.GoodsNo;
            campaignMng.LogicalDeleteCode = campaignObjGoodsSt.LogicalDeleteCode;
            campaignMng.PriceFl = campaignObjGoodsSt.PriceFl;
            campaignMng.RateVal = campaignObjGoodsSt.RateVal;
            campaignMng.SalesTargetCount = campaignObjGoodsSt.SalesTargetCount;
            campaignMng.SalesTargetMoney = campaignObjGoodsSt.SalesTargetMoney;
            campaignMng.SalesTargetProfit = campaignObjGoodsSt.SalesTargetProfit;
            campaignMng.SectionCode = campaignObjGoodsSt.SectionCode;
            campaignMng.UpdAssemblyId1 = campaignObjGoodsSt.UpdAssemblyId1;
            campaignMng.UpdAssemblyId2 = campaignObjGoodsSt.UpdAssemblyId2;
            campaignMng.UpdateDateTime = campaignObjGoodsSt.UpdateDateTime;
            campaignMng.UpdateDateTimeAdFormal = campaignObjGoodsSt.UpdateDateTimeAdFormal;
            campaignMng.UpdateDateTimeAdInFormal = campaignObjGoodsSt.UpdateDateTimeAdInFormal;
            campaignMng.UpdateDateTimeJpFormal = campaignObjGoodsSt.UpdateDateTimeJpFormal;
            campaignMng.UpdateDateTimeJpInFormal = campaignObjGoodsSt.UpdateDateTimeJpInFormal;
            campaignMng.UpdEmployeeCode = campaignObjGoodsSt.UpdEmployeeCode;
            campaignMng.UpdEmployeeName = campaignObjGoodsSt.UpdEmployeeName;
        }

        #endregion // </キャンペーン情報コンバート>
        // -- ADD 2011/08/10   ------ <<<<<<
        #region <優先設定適用>

        /// <summary>
        /// SCM優先設定に従って、SCM情報付商品連結データを選択します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>SCM優先設定に従って選択されたSCM情報付商品連結データのリスト</returns>
        private IList<SCMGoodsUnitData> SelectSCMGoodsUnitDataBySCMPrioritySetteing(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            const string METHOD_NAME = "SelectSCMGoodsUnitDataBySCMPrioritySetteing()"; // ログ用

            #region <Log>

            string title = "優先設定を適用中...";
            title += Environment.NewLine + SCMDataHelper.GetProfile(detailRecord);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(title));

            #endregion // </Log>

            // SCM情報付商品連結データが 1件または 0件の場合、何もしない
            if (scmGoodsUnitDataList.Count.Equals(1) || scmGoodsUnitDataList.Count.Equals(0))
            {
                #region <Log>

                string msg = string.Format("判定結果が {0} 件のため、処理を中断しました。", scmGoodsUnitDataList.Count);
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return scmGoodsUnitDataList;
            }
            /* ---------------------- DEL START 2011.09.22 redmine#25436 ----------------->>>>>
            // -- ADD 2011/08/10   ------ >>>>>>
            // SCM優先設定を取得
            SCMPriorSt foundPrioritySetteing = PrioritySettingDB.Find(
                detailRecord.InqOtherEpCd,
                detailRecord.InqOtherSecCd);
            // -- ADD 2011/08/10   ------ <<<<<<
            if (!SCMDataHelper.IsAvailableRecord(foundPrioritySetteing)) foundPrioritySetteing = null;

            IList<SCMGoodsUnitData> selectedList = scmGoodsUnitDataList;
            {
                if (foundPrioritySetteing != null)
                {
                    #region <優先設定で選択>

                    // 優先設定1で選択
                    selectedList = SCMPrioritySettingAgent.SelectBySetting1(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先設定1(={0})で選択されました。", foundPrioritySetteing.PrioritySettingCd1);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    // 優先設定2で選択
                    selectedList = SCMPrioritySettingAgent.SelectBySetting2(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先設定2(={0})で選択されました。", foundPrioritySetteing.PrioritySettingCd2);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    // 優先設定3で選択
                    selectedList = SCMPrioritySettingAgent.SelectBySetting3(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先設定3(={0})で選択されました。", foundPrioritySetteing.PrioritySettingCd3);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    // 優先設定4で選択
                    selectedList = SCMPrioritySettingAgent.SelectBySetting4(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先設定4(={0})で選択されました。", foundPrioritySetteing.PrioritySettingCd4);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    // 優先設定5で選択
                    selectedList = SCMPrioritySettingAgent.SelectBySetting3(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先設定5(={0})で選択されました。", foundPrioritySetteing.PrioritySettingCd5);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    #endregion // </優先設定で選択>

                    #region <優先価格設定で選択>

                    // 優先価格設定1で選択
                    selectedList = SCMPrioritySettingAgent.SelectByPriceSetting1(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先価格設定1(={0})で選択されました。", foundPrioritySetteing.PriorPriceSetCd1);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    // 優先価格設定2で選択
                    selectedList = SCMPrioritySettingAgent.SelectByPriceSetting2(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先価格設定2(={0})で選択されました。", foundPrioritySetteing.PriorPriceSetCd2);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    // 優先価格設定3で選択
                    selectedList = SCMPrioritySettingAgent.SelectByPriceSetting3(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先価格設定3(={0})で選択されました。", foundPrioritySetteing.PriorPriceSetCd3);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    // 優先価格設定4で選択
                    selectedList = SCMPrioritySettingAgent.SelectByPriceSetting4(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先価格設定4(={0})で選択されました。", foundPrioritySetteing.PriorPriceSetCd4);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    // 優先価格設定5で選択
                    selectedList = SCMPrioritySettingAgent.SelectByPriceSetting5(
                        foundPrioritySetteing,
                        selectedList
                    );
                    if (selectedList.Count.Equals(1))
                    {
                        #region <Log>

                        string msg = string.Format("優先価格設定5(={0})で選択されました。", foundPrioritySetteing.PriorPriceSetCd5);
                        msg += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                        #endregion // </Log>

                        return selectedList;
                    }

                    #endregion // </優先価格設定で選択>
                }
                else
                {
                    #region <Log>

                    string msg = string.Format(
                        "SCM優先設定マスタに登録がありません。(企業={0}, 拠点={1})",
                        detailRecord.InqOtherEpCd,
                        detailRecord.InqOtherSecCd
                    );
                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                    #endregion // <Log>
                }

                // 表示順位で選択
                selectedList = SelectByDisplayOrder(selectedList.Count.Equals(0) ? scmGoodsUnitDataList : selectedList);
            }
            ---------------------- DEL END   2011.09.22 redmine#25436-----------------<<<<<*/
            // ---------------------- ADD START 2011.09.22 redmine#25436 ----------------->>>>>
            SCMPriorSt foundPrioritySetteing = PrioritySettingDB.Find(
                detailRecord.InqOtherEpCd,
                detailRecord.InqOtherSecCd,
                GetCustomerCode(detailRecord),
                (int)PriorappliDiv.SCM); //0:共通, 1:PCC, 2:PCCUOE
            if (!SCMDataHelper.IsAvailableRecord(foundPrioritySetteing)) foundPrioritySetteing = null;

            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            if (foundPrioritySetteing != null)
            {
                //表示順
                // DEL 2013/09/17 SCM仕掛一覧№210対応 --------------------------------------->>>>>
                //scmGoodsUnitDataList = GoodsUnitDataByOrder(foundPrioritySetteing, scmGoodsUnitDataList);
                // DEL 2013/09/17 SCM仕掛一覧№210対応 ---------------------------------------<<<<<
                List<SCMGoodsUnitData> realList = new List<SCMGoodsUnitData>();
                List<SCMGoodsUnitData> unrealList = new List<SCMGoodsUnitData>();
                //部品選択有りの場合、優先設定の判定は、優良のみとし純正は必ず回答対象とする。
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    //純正は必ず回答対象として返す
                    if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                    {
                        realList.Add(scmGoodsUnitData);

                    }
                    else
                    {
                        unrealList.Add(scmGoodsUnitData);
                    }
                }
                //PCCUOE優先設定で選択します
                selectedList = SCMPrioritySettingAgent.PCCUOESelectBySetting(
                foundPrioritySetteing,
                unrealList, (int)SelectMode.On);
                //純正回答データを追加します
                realList.AddRange(selectedList);
                selectedList = realList;

                // ADD 2013/09/17 SCM仕掛一覧№210対応 --------------------------------------->>>>>
                scmGoodsUnitDataList = realList;
                // ADD 2013/09/17 SCM仕掛一覧№210対応 ---------------------------------------<<<<<

                //純正回答データを絞込ため、表示順処理を行う
                if (selectedList.Count > 1)
                {
                    selectedList = GoodsUnitDataByOrder(foundPrioritySetteing, selectedList);
                }

                // ADD 2013/09/17 SCM仕掛一覧№210対応 --------------------------------------->>>>>
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    // UPD 2013/11/28 商品保証部Redmine#719対応 --------------------------------------->>>>>
                    //scmGoodsUnitData.RetDisplayOrder = selectedList.IndexOf(scmGoodsUnitData) + 1;
                    // UPD 2015/02/09 SCM連携マルチキャスト対応 ---------------------------------->>>>>
                    //scmGoodsUnitData.RetDisplayOrder = (scmGoodsUnitData.SourceDetailRecord.InqRowNumDerivedNo - 1) + selectedList.IndexOf(scmGoodsUnitData) + 1;
                    // 表示順設定が行われていない場合、表示順はゼロを設定する
                    if (selectedList == null || selectedList.Count == 0)
                    {
                        scmGoodsUnitData.RetDisplayOrder = 0;
                    }
                    else
                    {
                        scmGoodsUnitData.RetDisplayOrder = (scmGoodsUnitData.SourceDetailRecord.InqRowNumDerivedNo - 1) + selectedList.IndexOf(scmGoodsUnitData) + 1;
                    }
                    // UPD 2015/02/09 SCM連携マルチキャスト対応 ---------------------------------->>>>>
                    // UPD 2013/11/28 商品保証部Redmine#719対応 ---------------------------------------<<<<<
                }
                // ADD 2013/09/17 SCM仕掛一覧№210対応 ---------------------------------------<<<<<

            }
            else
            {
                #region <Log>

                string msg = string.Format(
                    "SCM優先設定マスタに登録がありません。(企業={0}, 拠点={1})",
                    detailRecord.InqOtherEpCd,
                    detailRecord.InqOtherSecCd
                );
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // <Log>
            }
            // ---------------------- ADD END   2011.09.22 redmine#25436 -----------------<<<<<
            #region <Log>

            string message = "以下の商品が表示順位で選択されました。";
            if (selectedList.Count > 0)
            {
                message += Environment.NewLine + SCMDataHelper.GetProfile(selectedList);
            }
            else
            {
                message += Environment.NewLine + SCMDataHelper.GetProfile(scmGoodsUnitDataList);
            }
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(message));

            #endregion // </Log>

            // UPD 2013/09/17 SCM仕掛一覧№210対応 --------------------------------------->>>>>
            //return selectedList.Count.Equals(0) ? scmGoodsUnitDataList : selectedList;
            return scmGoodsUnitDataList;
            // UPD 2013/09/17 SCM仕掛一覧№210対応 ---------------------------------------<<<<<
        }

        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№10.単価計算呼出回数改良 ---------------------------------->>>>>
        /// <summary>
        /// SCM優先設定に従って、SCM情報付商品連結データを選択します。（在庫区分）
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>SCM優先設定に従って選択されたSCM情報付商品連結データのリスト</returns>
        private IList<SCMGoodsUnitData> SelectSCMGoodsUnitDataBySCMPrioritySetteingForStock(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            const string METHOD_NAME = "SelectSCMGoodsUnitDataBySCMPrioritySetteingForStock()"; // ログ用

            #region <Log>

            string title = "優先設定（在庫区分）を適用中...";
            title += Environment.NewLine + SCMDataHelper.GetProfile(detailRecord);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(title));

            #endregion // </Log>

            // SCM情報付商品連結データが 1件または 0件の場合、何もしない
            if (scmGoodsUnitDataList.Count.Equals(1) || scmGoodsUnitDataList.Count.Equals(0))
            {
                #region <Log>

                string msg = string.Format("判定結果が {0} 件のため、処理を中断しました。", scmGoodsUnitDataList.Count);
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return scmGoodsUnitDataList;
            }

            SCMPriorSt foundPrioritySetteing = PrioritySettingDB.Find(
                detailRecord.InqOtherEpCd,
                detailRecord.InqOtherSecCd,
                GetCustomerCode(detailRecord),
                (int)PriorappliDiv.SCM); //0:共通, 1:PCC, 2:PCCUOE
            if (!SCMDataHelper.IsAvailableRecord(foundPrioritySetteing)) foundPrioritySetteing = null;

            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            if (foundPrioritySetteing != null)
            {
                List<SCMGoodsUnitData> realList = new List<SCMGoodsUnitData>();
                List<SCMGoodsUnitData> unrealList = new List<SCMGoodsUnitData>();
                //部品選択有りの場合、優先設定の判定は、優良のみとし純正は必ず回答対象とする。
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    //純正は必ず回答対象として返す
                    if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                    {
                        realList.Add(scmGoodsUnitData);

                    }
                    else
                    {
                        unrealList.Add(scmGoodsUnitData);
                    }
                }
                //PCCUOE優先設定で選択します
                selectedList = SCMPrioritySettingAgent.PCCUOESelectBySettingForStock(
                foundPrioritySetteing,
                unrealList, (int)SelectMode.On);
                //純正回答データを追加します
                realList.AddRange(selectedList);
                selectedList = realList;

                scmGoodsUnitDataList = realList;

            }
            else
            {
                #region <Log>

                string msg = string.Format(
                    "SCM優先設定マスタに登録がありません。(企業={0}, 拠点={1})",
                    detailRecord.InqOtherEpCd,
                    detailRecord.InqOtherSecCd
                );
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // <Log>
            }

            return scmGoodsUnitDataList;
        }
        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№10.単価計算呼出回数改良 ----------------------------------<<<<<

        /// <summary>
        /// 表示順位で選択します。
        /// </summary>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>表示順位が最小のSCM情報付商品連結データのリスト(純正品と優良品×0..1)</returns>
        private static IList<SCMGoodsUnitData> SelectByDisplayOrder(IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            {
                int pureCount = 0;
                int minValue = int.MaxValue;
                SCMGoodsUnitData minSCMGoodsUnitData = null;
                {
                    foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                    {
                        // 純正は必須
                        if (scmGoodsUnitData.IsPure())
                        {
                            pureCount++;
                            selectedList.Add(scmGoodsUnitData);
                            continue;
                        }
                        // 最小値を選択
                        if (scmGoodsUnitData.DisplayOrder < minValue)
                        {
                            minValue = scmGoodsUnitData.DisplayOrder;
                            minSCMGoodsUnitData = scmGoodsUnitData;
                        }
                    }
                    if (minSCMGoodsUnitData != null)
                    {
                        selectedList.Add(minSCMGoodsUnitData);
                    }
                }
            }
            return selectedList;
        }

        #endregion // </優先設定適用>

        /// <summary>
        /// SCM表示順を設定
        /// </summary>
        /// <returns>SCM表示順に従って選択されたSCM情報付商品連結データのリスト</returns>
        private IList<SCMGoodsUnitData> GoodsUnitDataByOrder(SCMPriorSt foundPrioritySetteing,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();
            List<SCMGoodsUnitData> templist = new List<SCMGoodsUnitData>();
            foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
            {
                templist.Add(scmGoodsUnitData);
            }
            #region Del For #25798 by x_chenjm 2011/10/11
            //if (foundPrioritySetteing.PrioritySettingCd1 != 0 ||
            //    foundPrioritySetteing.PrioritySettingCd2 != 0 ||
            //    foundPrioritySetteing.PrioritySettingCd3 != 0 ||
            //    foundPrioritySetteing.PrioritySettingCd4 != 0 ||
            //    foundPrioritySetteing.PrioritySettingCd5 != 0 ||
            //    foundPrioritySetteing.PriorPriceSetCd1 != 0 ||
            //    foundPrioritySetteing.PriorPriceSetCd2 != 0)
            //{
            #endregion
            templist.Sort(new PccuoeOrderComparer(foundPrioritySetteing));
            #region Del For #25798 by x_chenjm 2011/10/11
            //}
            //else
            //{
            //    templist.Sort(new PccuoeOrderSort(foundPrioritySetteing));
                //}
            #endregion
            foreach (SCMGoodsUnitData scmGoodsUnitData in templist)
            {
                selectedList.Add(scmGoodsUnitData);
            }
            return selectedList;
        }


        /// <summary>
        /// SCM優先設定に従って、PCCUOE情報付商品連結データを選択します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>SCM優先設定に従って選択されたSCM情報付商品連結データのリスト</returns>
        /// <remarks>
        /// <br>Update Note : 2018/07/26 譚洪</br>
        /// <br>管理番号    : 11470103-00</br>
        /// <br>            : BLパーツオーダー自動回答不具合対応</br>
        /// </remarks>
        private IList<SCMGoodsUnitData> SelectPCCUOEGoodsUnitDataBySCMPrioritySetteing(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            const string METHOD_NAME = "SelectPCCUOEGoodsUnitDataBySCMPrioritySetteing()"; // ログ用
            bool checkFlg = false;              //部品選択有無
            #region <Log>

            string title = "優先設定を適用中...";
            title += Environment.NewLine + SCMDataHelper.GetProfile(detailRecord);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(title));

            #endregion // </Log>

            // SCM情報付商品連結データが 1件または 0件の場合、何もしない
            if (scmGoodsUnitDataList.Count.Equals(1) || scmGoodsUnitDataList.Count.Equals(0))
            {
                #region <Log>

                string msg = string.Format("判定結果が {0} 件のため、処理を中断しました。", scmGoodsUnitDataList.Count);
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return scmGoodsUnitDataList;
            }

            // SCM優先設定を取得
            // -- ADD 2011/08/10   ------ >>>>>>
            SCMPriorSt foundPrioritySetteing = PrioritySettingDB.Find(
                detailRecord.InqOtherEpCd,
                detailRecord.InqOtherSecCd,
                GetCustomerCode(detailRecord),
                (int)PriorappliDiv.PCCUOE); //0:共通, 1:PCC, 2:PCCUOE
            if (!SCMDataHelper.IsAvailableRecord(foundPrioritySetteing)) foundPrioritySetteing = null;

            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            if (foundPrioritySetteing != null)
            {
                //表示順
                // DEL 2013/09/17 SCM仕掛一覧№210対応 --------------------------------------->>>>>
                //scmGoodsUnitDataList = GoodsUnitDataByOrder(foundPrioritySetteing, scmGoodsUnitDataList);
                // DEL 2013/09/17 SCM仕掛一覧№210対応 ---------------------------------------<<<<<

                // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
                ////品番検索時、優先設定の絞込み行わない
                //if (((SCMSearchedResult)Searcher.ResultMap[detailRecord.ToKey()]).SearchedType == SCMSearchedResult.GoodsSearchDivCd.BLCode)
                //{
                //    //PCCUOE品目設定マスタを取得
                //    if (pccItemGrpAcs == null)
                //    {
                //        pccItemGrpAcs = new PccItemGrpAcs();
                //        // UPD 2013/01/17 T.Yoshioka 2013/01/23配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                //        // pccItemGrpAcs.Search(out pccItemGrpList, out pccItemStList, null, 0, ConstantManagement.LogicalMode.GetData0);
                //        if (this.HeaderRecordList != null && this.HeaderRecordList.Count > 0)
                //        {
                //            PccItemGrid parsePccItemGrid = new PccItemGrid();
                //            parsePccItemGrid.EnterpriseCode = this.HeaderRecordList[0].EnterpriseCode;
                //            parsePccItemGrid.InqOtherEpCd = this.HeaderRecordList[0].InqOtherEpCd;
                //            parsePccItemGrid.InqOtherSecCd = this.HeaderRecordList[0].InqOtherSecCd;
                //            pccItemGrpAcs.Search(out pccItemGrpList, out pccItemStList, parsePccItemGrid, 0, ConstantManagement.LogicalMode.GetData0);
                //        }
                //        else
                //        {
                //            pccItemGrpAcs.Search(out pccItemGrpList, out pccItemStList, null, 0, ConstantManagement.LogicalMode.GetData0);
                //        }
                //        // UPD 2013/01/17 T.Yoshioka 2013/01/23配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                //        //pccItemGrpAcs.Read(ref pccItemGrpList, ref pccItemStList, 0, ConstantManagement.LogicalMode.GetData0);
                //    }
                //    //部品選択有無を判断します PCCUOE品目設定マスタに設定されていない場合は「部品選択無し」として処理。
                //    if (pccItemStList != null && pccItemStList.Count > 0)
                //    {
                //        foreach (PccItemSt pccItemSt in pccItemStList)
                //        {
                //            if (detailRecord.InqOriginalEpCd == pccItemSt.InqOriginalEpCd &&     //問合せ元企業コード
                //                detailRecord.InqOriginalSecCd.Trim() == pccItemSt.InqOriginalSecCd.Trim() &&   //問合せ元拠点コード
                //                detailRecord.InqOtherEpCd == pccItemSt.InqOtherEpCd &&           //問合せ先企業コード
                //                detailRecord.InqOtherSecCd.Trim() == pccItemSt.InqOtherSecCd.Trim() &&         //問合せ先拠点コード
                //                detailRecord.BLGoodsCode == pccItemSt.BLGoodsCode &&            //BLコード
                //                pccItemSt.ItemSelectDiv != (int)ItemSelectDiv.OFF)              //品目選択区分!＝0:OFF 部品選択あり
                //            {

                //                checkFlg = true;
                //                break;
                //            }
                //        }
                //    }
                //    #region <優先設定で選択>
                //    //部品選択有
                //    if (checkFlg)
                //    {
                // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
                        List<SCMGoodsUnitData> realList = new List<SCMGoodsUnitData>();
                        List<SCMGoodsUnitData> unrealList = new List<SCMGoodsUnitData>();
                        //部品選択有りの場合、優先設定の判定は、優良のみとし純正は必ず回答対象とする。
                        foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                        {
                            //純正は必ず回答対象として返す
                            if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                            {
                                realList.Add(scmGoodsUnitData);
                                
                            }
                            else
                            {
                                unrealList.Add(scmGoodsUnitData);
                            }
                        }
                        //PCCUOE優先設定で選択します
                        selectedList = SCMPrioritySettingAgent.PCCUOESelectBySetting(
                        foundPrioritySetteing,
                        unrealList, (int)SelectMode.On);
                        //純正回答データを追加します
                        realList.AddRange(selectedList);
                        selectedList = realList;

                        // ADD 2013/09/17 SCM仕掛一覧№210対応 --------------------------------------->>>>>
                        scmGoodsUnitDataList = realList;
                        // ADD 2013/09/17 SCM仕掛一覧№210対応 ---------------------------------------<<<<<

                        //純正回答データを絞込ため、表示順処理を行う
                        if (selectedList.Count > 1)
                        {
                            selectedList = GoodsUnitDataByOrder(foundPrioritySetteing, selectedList);
                        }
                // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
                //    }
                //    //部品選択無
                //    else
                //    {
                //        //PCCUOE優先設定で選択します
                //        selectedList = SCMPrioritySettingAgent.PCCUOESelectBySetting(
                //        foundPrioritySetteing,
                //        scmGoodsUnitDataList, (int)SelectMode.None);
                //        //部品選択無しの場合、上記絞り込みで複数部品該当した場合、SCM優先設定マスタの表示順で先頭行となる品番を回答とする。
                //        if (selectedList.Count > 1)
                //        {
                //            List<SCMGoodsUnitData> fristRecord = new List<SCMGoodsUnitData>();
                //            fristRecord.Add(selectedList[0]);
                //            selectedList = fristRecord;
                //        }
                //        // 部品選択なしの場合、上記絞り込み結果が0件の場合、
                //        else if (selectedList.Count == 0)
                //        {
                //            // 検索結果の先頭純正部品を回答とする
                //            foreach (SCMGoodsUnitData realRecord in scmGoodsUnitDataList)
                //            {
                //                //先頭純正部品を回答とする
                //                if (IsPureAtOfferKubun(realRecord.RealGoodsUnitData))
                //                {
                //                    selectedList.Add(realRecord);
                //                    break;
                //                }
                //            }
                //        }
                //        // ADD 2013/11/05 2013/11/xx配信予定システムテスト№19対応 --------------------------------------->>>>>
                //        scmGoodsUnitDataList = selectedList;
                //        // ADD 2013/11/05 2013/11/xx配信予定システムテスト№19対応 ---------------------------------------<<<<<
                //    }
                //    #endregion
                //}
                // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
                // ADD 2013/09/17 SCM仕掛一覧№210対応 --------------------------------------->>>>>
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    // UPD 2013/11/28 商品保証部Redmine#719対応 ---------------------------------------->>>>>
                    //scmGoodsUnitData.RetDisplayOrder = selectedList.IndexOf(scmGoodsUnitData) + 1;
                    // UPD 2015/02/09 SCM連携マルチキャスト対応 -------------------------------------->>>>>
                    //scmGoodsUnitData.RetDisplayOrder = (scmGoodsUnitData.SourceDetailRecord.InqRowNumDerivedNo - 1)  + selectedList.IndexOf(scmGoodsUnitData) + 1;
                    // 表示順設定が行われていない場合、表示順位をゼロで設定する
                    if (selectedList == null || selectedList.Count == 0)
                    {
                        scmGoodsUnitData.RetDisplayOrder = 0;
                    }
                    else
                    {
                        scmGoodsUnitData.RetDisplayOrder = (scmGoodsUnitData.SourceDetailRecord.InqRowNumDerivedNo - 1) + selectedList.IndexOf(scmGoodsUnitData) + 1;
                    }
                    // UPD 2015/02/09 SCM連携マルチキャスト対応 --------------------------------------<<<<<
                    // UPD 2013/11/28 商品保証部Redmine#719対応 ---------------------------------------->>>>>
                }
                // ADD 2013/09/17 SCM仕掛一覧№210対応 ---------------------------------------<<<<<
            }
            // ADD 2013/09/17 SCM仕掛一覧№210対応 --------------------------------------->>>>>
            //return selectedList.Count.Equals(0) ? scmGoodsUnitDataList : selectedList;
            return scmGoodsUnitDataList;
            // ADD 2013/09/17 SCM仕掛一覧№210対応 ---------------------------------------<<<<<
        }

        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№10.単価計算呼出回数改良 ---------------------------------->>>>>
        /// <summary>
        /// SCM優先設定に従って、PCCUOE情報付商品連結データを選択します。（在庫区分）
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM情報付商品連結データのリスト</param>
        /// <returns>SCM優先設定に従って選択されたSCM情報付商品連結データのリスト</returns>
        /// <remarks>
        /// <br>Update Note : 2018/07/26 譚洪</br>
        /// <br>管理番号    : 11470103-00</br>
        /// <br>            : BLパーツオーダー自動回答不具合対応</br>
        /// </remarks>
        private IList<SCMGoodsUnitData> SelectPCCUOEGoodsUnitDataBySCMPrioritySetteingForStock(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            const string METHOD_NAME = "SelectPCCUOEGoodsUnitDataBySCMPrioritySetteingForStock()"; // ログ用
            bool checkFlg = false;              //部品選択有無
            #region <Log>

            string title = "優先設定（在庫区分）を適用中...";
            title += Environment.NewLine + SCMDataHelper.GetProfile(detailRecord);
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(title));

            #endregion // </Log>

            // SCM情報付商品連結データが 1件または 0件の場合、何もしない
            if (scmGoodsUnitDataList.Count.Equals(1) || scmGoodsUnitDataList.Count.Equals(0))
            {
                #region <Log>

                string msg = string.Format("判定結果が {0} 件のため、処理を中断しました。", scmGoodsUnitDataList.Count);
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                return scmGoodsUnitDataList;
            }

            // SCM優先設定を取得
            SCMPriorSt foundPrioritySetteing = PrioritySettingDB.Find(
                detailRecord.InqOtherEpCd,
                detailRecord.InqOtherSecCd,
                GetCustomerCode(detailRecord),
                (int)PriorappliDiv.PCCUOE); //0:共通, 1:PCC, 2:PCCUOE
            if (!SCMDataHelper.IsAvailableRecord(foundPrioritySetteing)) foundPrioritySetteing = null;

            IList<SCMGoodsUnitData> selectedList = new List<SCMGoodsUnitData>();

            if (foundPrioritySetteing != null)
            {
                // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
                ////品番検索時、優先設定の絞込み行わない
                //if (((SCMSearchedResult)Searcher.ResultMap[detailRecord.ToKey()]).SearchedType == SCMSearchedResult.GoodsSearchDivCd.BLCode)
                //{
                //    //PCCUOE品目設定マスタを取得
                //    if (pccItemGrpAcs == null)
                //    {
                //        pccItemGrpAcs = new PccItemGrpAcs();
                //        if (this.HeaderRecordList != null && this.HeaderRecordList.Count > 0)
                //        {
                //            PccItemGrid parsePccItemGrid = new PccItemGrid();
                //            parsePccItemGrid.EnterpriseCode = this.HeaderRecordList[0].EnterpriseCode;
                //            parsePccItemGrid.InqOtherEpCd = this.HeaderRecordList[0].InqOtherEpCd;
                //            parsePccItemGrid.InqOtherSecCd = this.HeaderRecordList[0].InqOtherSecCd;
                //            pccItemGrpAcs.Search(out pccItemGrpList, out pccItemStList, parsePccItemGrid, 0, ConstantManagement.LogicalMode.GetData0);
                //        }
                //        else
                //        {
                //            pccItemGrpAcs.Search(out pccItemGrpList, out pccItemStList, null, 0, ConstantManagement.LogicalMode.GetData0);
                //        }
                //    }
                //    //部品選択有無を判断します PCCUOE品目設定マスタに設定されていない場合は「部品選択無し」として処理。
                //    if (pccItemStList != null && pccItemStList.Count > 0)
                //    {
                //        foreach (PccItemSt pccItemSt in pccItemStList)
                //        {
                //            if (detailRecord.InqOriginalEpCd == pccItemSt.InqOriginalEpCd &&     //問合せ元企業コード
                //                detailRecord.InqOriginalSecCd.Trim() == pccItemSt.InqOriginalSecCd.Trim() &&   //問合せ元拠点コード
                //                detailRecord.InqOtherEpCd == pccItemSt.InqOtherEpCd &&           //問合せ先企業コード
                //                detailRecord.InqOtherSecCd.Trim() == pccItemSt.InqOtherSecCd.Trim() &&         //問合せ先拠点コード
                //                detailRecord.BLGoodsCode == pccItemSt.BLGoodsCode &&            //BLコード
                //                pccItemSt.ItemSelectDiv != (int)ItemSelectDiv.OFF)              //品目選択区分!＝0:OFF 部品選択あり
                //            {

                //                checkFlg = true;
                //                break;
                //            }
                //        }
                //    }
                //    #region <優先設定で選択>
                //    //部品選択有
                //    if (checkFlg)
                //    {
                // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
                        List<SCMGoodsUnitData> realList = new List<SCMGoodsUnitData>();
                        List<SCMGoodsUnitData> unrealList = new List<SCMGoodsUnitData>();
                        //部品選択有りの場合、優先設定の判定は、優良のみとし純正は必ず回答対象とする。
                        foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                        {
                            //純正は必ず回答対象として返す
                            if (IsPureAtOfferKubun(scmGoodsUnitData.RealGoodsUnitData))
                            {
                                realList.Add(scmGoodsUnitData);

                            }
                            else
                            {
                                unrealList.Add(scmGoodsUnitData);
                            }
                        }
                        //PCCUOE優先設定で選択します
                        selectedList = SCMPrioritySettingAgent.PCCUOESelectBySettingForStock(
                        foundPrioritySetteing,
                        unrealList, (int)SelectMode.On);
                        //純正回答データを追加します
                        realList.AddRange(selectedList);
                        selectedList = realList;

                        scmGoodsUnitDataList = realList;
                // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------>>>>>
                //    }
                //    //部品選択無
                //    else
                //    {
                //        //PCCUOE優先設定で選択します
                //        selectedList = SCMPrioritySettingAgent.PCCUOESelectBySettingForStock(
                //        foundPrioritySetteing,
                //        scmGoodsUnitDataList, (int)SelectMode.None);

                //        // UPD 2014/05/27 速度改善フェーズ２№10 №10658　システムテスト障害№2 ----------------->>>>>>>>>>>>>>>>>>>>>>
                //        #region 旧ソース
                //        ////部品選択無しの場合、上記絞り込みで複数部品該当した場合、SCM優先設定マスタの表示順で先頭行となる品番を回答とする。
                //        //if (selectedList.Count > 1)
                //        //{
                //        //    List<SCMGoodsUnitData> fristRecord = new List<SCMGoodsUnitData>();
                //        //    fristRecord.Add(selectedList[0]);
                //        //    selectedList = fristRecord;
                //        //}
                //        //// 部品選択なしの場合、上記絞り込み結果が0件の場合、
                //        //else if (selectedList.Count == 0)
                //        //{
                //        //    // 検索結果の先頭純正部品を回答とする
                //        //    foreach (SCMGoodsUnitData realRecord in scmGoodsUnitDataList)
                //        //    {
                //        //        //先頭純正部品を回答とする
                //        //        if (IsPureAtOfferKubun(realRecord.RealGoodsUnitData))
                //        //        {
                //        //            selectedList.Add(realRecord);
                //        //            break;
                //        //        }
                //        //    }
                //        //}
                //        #endregion
                //        // 部品選択なしの場合、上記絞り込み結果が0件の場合、
                //        if (selectedList.Count == 0)
                //        {
                //            // 検索結果の先頭純正部品を回答とする
                //            foreach (SCMGoodsUnitData realRecord in scmGoodsUnitDataList)
                //            {
                //                //先頭純正部品を回答とする
                //                if (IsPureAtOfferKubun(realRecord.RealGoodsUnitData))
                //                {
                //                    selectedList.Add(realRecord);
                //                    break;
                //                }
                //            }
                //        }
                //        // UPD 2014/05/27 速度改善フェーズ２№10 №10658　システムテスト障害№2 -----------------<<<<<<<<<<<<<<<<<<<<<<<<
                //        scmGoodsUnitDataList = selectedList;
                //    }
                //    #endregion
                //}
                // ---DEL 譚洪 2018/07/26 BLパーツオーダー自動回答不具合対応 ------<<<<<
            }
            return scmGoodsUnitDataList;
        }
        // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№10.単価計算呼出回数改良 ----------------------------------<<<<<

        // ADD 2010/04/22 作成される売上データが「受注」となる(受注ステータスが「受注」となる)場合、自動回答の対象としない ---------->>>>>
        #region <売上データを作成できるかの判定>

        /// <summary>
        /// 売上データを作成できるか判断します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="scmGoodsUnitDataList">SCM用の情報付商品連結データのリスト</param>
        /// <returns>
        /// <c>true</c> :売上データを作成できます。<br/>
        /// <c>false</c>:売上データを作成できません。
        /// </returns>
        protected virtual bool CanMakeSalesData(
            ISCMOrderDetailRecord detailRecord,
            IList<SCMGoodsUnitData> scmGoodsUnitDataList
        )
        {
            return detailRecord != null && !ListUtil.IsNullOrEmpty(scmGoodsUnitDataList);
        }

        #endregion // </売上データを作成できるかの判定>
        // ADD 2010/04/22 作成される売上データが「受注」となる(受注ステータスが「受注」となる)場合、自動回答の対象としない ----------<<<<<

        /// <summary>
        /// 得意先コードを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>該当するSCM受注データの得意先コード</returns>
        protected int GetCustomerCode(ISCMOrderDetailRecord detailRecord)
        {
            return Searcher.GetCustomerCode(detailRecord);
        }

        /// <summary>
        /// 問合せ日を取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>該当するSCM受注データの問合せ日</returns>
        protected DateTime GetInquiryDate(ISCMOrderDetailRecord detailRecord)
        {
            return Searcher.GetInquiryDate(detailRecord);
        }

        /// <summary>
        /// 型式(フル型)を取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>該当するSCM受注データ(車両情報)の型式(フル型)</returns>
        protected string GetFullModel(ISCMOrderDetailRecord detailRecord)
        {
            string fullModel = Searcher.GetFullModel(detailRecord);

            if (!string.IsNullOrEmpty(fullModel.Trim())) return fullModel;

            string key = detailRecord.ToKey();
            if (!Searcher.ResultMap.ContainsKey(key)) return fullModel;

            const int SINGLE_ROW = 0;
            fullModel = Searcher.ResultMap[key].SearchCarInfo.CarModelInfoSummarized[SINGLE_ROW].FullModel;

            return fullModel;
        }

        /// <summary>
        /// 類別型式を取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>該当する車両検索結果の類別型式 ※該当するものが無い場合、<c>string.Empty</c>を返します。</returns>
        protected string GetRelevanceModel(ISCMOrderDetailRecord detailRecord)
        {
            string relevanceModel = string.Empty;

            string key = detailRecord.ToKey();
            if (!Searcher.ResultMap.ContainsKey(key)) return relevanceModel;
            if (Searcher.ResultMap[key].SearchCarInfo == null) return relevanceModel;
            if (Searcher.ResultMap[key].SearchCarInfo.CarModelInfo == null) return relevanceModel;
            if (Searcher.ResultMap[key].SearchCarInfo.CarModelInfo.Count.Equals(0)) return relevanceModel;

            relevanceModel = Searcher.ResultMap[key].SearchCarInfo.CarModelInfo[0].RelevanceModel;
            if (Searcher.ResultMap[key].SearchCarInfo.CarModelInfo.Count > 1)
            {
                for (int i = 1; i < Searcher.ResultMap[key].SearchCarInfo.CarModelInfo.Count; i++)
                {
                    if (!relevanceModel.Trim().Equals(
                        Searcher.ResultMap[key].SearchCarInfo.CarModelInfo[i].RelevanceModel.Trim()
                    ))
                    {
                        return string.Empty;
                    }
                }
            }
            return relevanceModel;
        }
        
        #region Del For #25798 by x_chenjm 2011/10/11
        // -- ADD 2011/08/10   ------ >>>>>>
        ///// <summary>
        ///// 優先設定表示順処理前ソート
        ///// </summary>
        ///// <remarks>
        ///// <br>Note        : 優先設定表示順によってソート処理をします。</br>
        ///// <br>Programmer	: liusy</br>
        ///// <br>Date		: 2011.08.10</br>
        ///// </remarks>
        //private class PccuoeOrderSort : System.Collections.Generic.IComparer<SCMGoodsUnitData>
        //{
        //    private SCMPriorSt _foundPrioritySetteing;

        //    public PccuoeOrderSort(SCMPriorSt foundPrioritySetteing)
        //    {
        //        this._foundPrioritySetteing = foundPrioritySetteing;
        //    }
        //    public int Compare(SCMGoodsUnitData obj1, SCMGoodsUnitData obj2)
        //    {
        //        //純正かどうかのソート 純正/優良(純正が先です)
        //        int result = 0;
        //        bool obj1Pure = IsPureAtOfferKubun(obj1.RealGoodsUnitData);
        //        bool obj2Pure = IsPureAtOfferKubun(obj2.RealGoodsUnitData);
        //        if((!obj1Pure && !obj2Pure) ||(obj1Pure && obj2Pure))
        //        {
        //            result = 0;
        //        }else if(obj1Pure && !obj2Pure)
        //        {
        //            result = -1;

        //        }else if(!obj1Pure && obj2Pure)
        //        {
        //            result = 1;
        //        }
        //        if (result != 0)
        //        {
        //            return result;
        //        }

        //        //品番
        //        result = obj1.GetGoodsNo().CompareTo(obj2.GetGoodsNo());
        //        if (result != 0)
        //        {
        //            return result;
        //        }

        //        //メーカー
        //        result = obj1.RealGoodsUnitData.GoodsMakerCd.CompareTo(obj2.RealGoodsUnitData.GoodsMakerCd);

        //        return result;
        //    }
        //}
        #endregion
        
        /// <summary>
        /// 優先設定表示順処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 優先設定表示順によってソート処理をします。</br>
        /// <br>Programmer	: liusy</br>
        /// <br>Date		: 2011.06.29</br>
        /// </remarks>
        private class PccuoeOrderComparer : System.Collections.Generic.IComparer<SCMGoodsUnitData>
        {
            private SCMPriorSt _foundPrioritySetteing;

            public PccuoeOrderComparer(SCMPriorSt foundPrioritySetteing)
            {
                this._foundPrioritySetteing = foundPrioritySetteing;
            }
            public int Compare(SCMGoodsUnitData obj1, SCMGoodsUnitData obj2)
            {
                int result = 0;
                //優先設定コード１
                result = codeCompare(_foundPrioritySetteing.PrioritySettingCd1, obj1, obj2);
                if (result != 0)
                {
                    return result;
                }
                //優先設定コード２
                result = codeCompare(_foundPrioritySetteing.PrioritySettingCd2, obj1, obj2);
                if (result != 0)
                {
                    return result;
                }
                //優先設定コード３
                result = codeCompare(_foundPrioritySetteing.PrioritySettingCd3, obj1, obj2);
                if (result != 0)
                {
                    return result;
                }
                //優先設定コード４
                result = codeCompare(_foundPrioritySetteing.PrioritySettingCd4, obj1, obj2);
                if (result != 0)
                {
                    return result;
                }
                //優先設定コード５
                result = codeCompare(_foundPrioritySetteing.PrioritySettingCd5, obj1, obj2);
                if (result != 0)
                {
                    return result;
                }
                //優先価格設定コード１
                result = codeCompare(_foundPrioritySetteing.PriorPriceSetCd1, obj1, obj2);
                if (result != 0)
                {
                    return result;
                }
                // ----- ADD 2011/09/26 ----- >>>>>
                // ----- DEL 2011/09/19 ----- >>>>>
                //優先価格設定コード２
                result = codeCompare(_foundPrioritySetteing.PriorPriceSetCd2, obj1, obj2);
                if (result != 0)
                {
                    return result;
                }
                // ----- DEL 2011/09/19 ----- <<<<<
                // ----- ADD 2011/09/26 ----- <<<<<

                /***ADD START BY x_chenjm 2011/10/11 #25798 ************/
                //純正かどうかのソート 純正/優良(純正が先です)
                bool obj1Pure = IsPureAtOfferKubun(obj1.RealGoodsUnitData);
                bool obj2Pure = IsPureAtOfferKubun(obj2.RealGoodsUnitData);
                if((!obj1Pure && !obj2Pure) ||(obj1Pure && obj2Pure))
                {
                    result = 0;
                }else if(obj1Pure && !obj2Pure)
                {
                    result = -1;

                }else if(!obj1Pure && obj2Pure)
                {
                    result = 1;
                }
                if (result != 0)
                {
                    return result;
                }
                /***ADD END BY x_chenjm 2011/10/11 #25798 ************/
                /***ADD START BY LIUSY 2011/10/09 #25798 ************/
                // ADD 2013/11/18 SCM仕掛一覧№210対応 ------------------------------------------------>>>>>
                // 表示順位
                result = obj1.RealGoodsUnitData.JoinDispOrder.CompareTo(obj2.RealGoodsUnitData.JoinDispOrder);
                if (result != 0)
                {
                    return result;
                }
                // ADD 2013/11/18 SCM仕掛一覧№210対応 ------------------------------------------------<<<<<
                //メーカー
                result = obj1.RealGoodsUnitData.GoodsMakerCd.CompareTo(obj2.RealGoodsUnitData.GoodsMakerCd);
                if (result != 0)
                {
                    return result;
                }
                //品番
                result = obj1.GetGoodsNo().CompareTo(obj2.GetGoodsNo());
                /***ADD END BY LIUSY 2011/10/09 #25798 ************/

                return result;
            }
            public int codeCompare(int code, SCMGoodsUnitData obj1, SCMGoodsUnitData obj2)
            {
                int retrunCode = 0;
                int Stock1 = obj1.GetStockDiv();
                int Stock2 = obj2.GetStockDiv();

                //0:なし
                if (code == (int)SCMPriorOrder.None)
                {
                    return 0;
                }
                //1:粗利率
                else if (code == (int)SCMPriorOrder.RoughRate)
                {
                    retrunCode = obj2.GetRoughRate().CompareTo(obj1.GetRoughRate());
                }
                //2:単価
                else if (code == (int)SCMPriorOrder.UnitPrice)
                {
                    retrunCode = obj2.GetUnitPrice().CompareTo(obj1.GetUnitPrice());
                }
                //3:定価(高)
                else if (code == (int)SCMPriorOrder.ListPriceHigh)
                {
                    retrunCode = obj2.GetListPrice().CompareTo(obj1.GetListPrice());
                }
                //4:定価(低)
                else if (code == (int)SCMPriorOrder.ListPriceLow)
                {
                    retrunCode = obj1.GetListPrice().CompareTo(obj2.GetListPrice());
                }
                //5:キャンペーン
                else if (code == (int)SCMPriorOrder.Campaign)
                {
                    bool Campaign1 = obj1.CampaignInformation.Enabled;
                    bool Campaign2 = obj2.CampaignInformation.Enabled;
                    if ((Campaign1 && Campaign2) || (!Campaign1 && !Campaign2))
                    {
                        retrunCode = 0;
                    }
                    else if (Campaign1 && !Campaign2)
                    {
                        retrunCode = -1;
                    }
                    else if (!Campaign1 && Campaign2)
                    {
                        retrunCode = 1;
                    }

                }
                // ----- ADD 2011/09/26 ----- >>>>>
                // ----- DEL 2011/09/19 ----- >>>>>
                //6:在庫
                else if (code == (int)SCMPriorOrder.StockOn)
                {
                    if ((Stock1 != (int)StockDiv.None && Stock2 != (int)StockDiv.None) || (Stock1 == (int)StockDiv.None && Stock2 == (int)StockDiv.None))
                    {
                        retrunCode = 0;
                    }
                    else if (Stock1 != (int)StockDiv.None && Stock2 == (int)StockDiv.None)
                    {
                        retrunCode = -1;
                    }
                    else if (Stock1 == (int)StockDiv.None && Stock2 != (int)StockDiv.None)
                    {
                        retrunCode = 1;
                    }
                }
                // ----- DEL 2011/09/19 ----- <<<<<
                // ----- ADD 2011/09/26 ----- <<<<<

                //7:委託 // DEL 2011/09/19      // ADD 2011/09/26
                ////6:委託 // ADD 2011/09/19    // DEL 2011/09/26
                else if (code == (int)SCMPriorOrder.Trust)
                {
                    if ((Stock1 != (int)StockDiv.Trust && Stock2 != (int)StockDiv.Trust) || (Stock1 == (int)StockDiv.Trust && Stock2 == (int)StockDiv.Trust))
                    {
                        retrunCode = 0;
                    }
                    else if (Stock1 == (int)StockDiv.Trust && Stock2 != (int)StockDiv.Trust)
                    {
                        retrunCode = -1;
                    }
                    else if (Stock1 != (int)StockDiv.Trust && Stock2 == (int)StockDiv.Trust)
                    {
                        retrunCode = 1;
                    }
                }
                //8:優先倉庫 // DEL 2011/09/19     // ADD 2011/09/26
                ////7:優先倉庫 // ADD 2011/09/19   // DEL 2011/09/26
                else if (code == (int)SCMPriorOrder.PriorityWarehouse)
                {
                    // UPD 2012/07/18 SCM障害№173 --------------------------------------------->>>>>
                    //if ((Stock1 != (int)StockDiv.PriorityWarehouse && Stock2 != (int)StockDiv.PriorityWarehouse) || (Stock1 == (int)StockDiv.PriorityWarehouse && Stock2 == (int)StockDiv.PriorityWarehouse))
                    //{
                    //    retrunCode = 0;
                    //}
                    if (Stock1 != (int)StockDiv.PriorityWarehouse && Stock2 != (int)StockDiv.PriorityWarehouse)
                    {
                        retrunCode = 0;
                    }
                    else if (Stock1 == (int)StockDiv.PriorityWarehouse && Stock2 == (int)StockDiv.PriorityWarehouse)
                    {
                        // 優先倉庫順位を取得する
                        int priWarehouseOrder1 = (int)obj1.GetPriWareHouseOrder();
                        int priWarehouseOrder2 = (int)obj2.GetPriWareHouseOrder();
                        if (!priWarehouseOrder1.Equals(0) && !priWarehouseOrder2.Equals(0))
                        {
                            if (priWarehouseOrder1 == priWarehouseOrder2)
                            {
                                retrunCode = 0;
                            }
                            else if (priWarehouseOrder1 < priWarehouseOrder2)
                            {
                                retrunCode = -1;
                            }
                            else
                            {
                                retrunCode = 1;
                            }
                        }
                        else
                        {
                            retrunCode = 0;
                        }
                    }
                    // UPD 2012/07/18 SCM障害№173 ---------------------------------------------<<<<<
                    else if (Stock1 == (int)StockDiv.PriorityWarehouse && Stock2 != (int)StockDiv.PriorityWarehouse)
                    {
                        retrunCode = -1;
                    }
                    else if (Stock1 != (int)StockDiv.PriorityWarehouse && Stock2 == (int)StockDiv.PriorityWarehouse)
                    {
                        retrunCode = 1;
                    }
                }
                // ADD 2013/12/16 SCM仕掛一覧№10590対応 ---------------------------------------->>>>>
                // 9:優先設定
                else if (code == (int)SCMPriorOrder.PrioritySetting)
                {
                    int joinDispOrder1 = obj1.RealGoodsUnitData.JoinDispOrder;
                    int joinDispOrder2 = obj2.RealGoodsUnitData.JoinDispOrder;
                    if (!joinDispOrder1.Equals(0) && !joinDispOrder2.Equals(0))
                    {
                        if (joinDispOrder1.Equals(joinDispOrder2))
                        {
                            retrunCode = 0;
                        }
                        else if (joinDispOrder1 < joinDispOrder2)
                        {
                            retrunCode = -1;
                        }
                        else
                        {
                            retrunCode = 1;
                        }
                    }
                    else
                    {
                        if (joinDispOrder1.Equals(0))
                        {
                            retrunCode = 1;
                        }
                        else if (joinDispOrder2.Equals(0))
                        {
                            retrunCode = -1;
                        }
                    }
                }
                // ADD 2013/12/16 SCM仕掛一覧№10590対応 ----------------------------------------<<<<<

                return retrunCode;
            }
        }
        // -- ADD 2011/08/10   ------ <<<<<<
        // --- ADD m.suzuki 2012/04/19 ---------->>>>>
        /// <summary>
        /// 検索結果を強制的にクリアする処理
        /// </summary>
        public void ClearSearchResult()
        {
            if ( _searcher != null )
            {
                _searcher.ClearSearchResult();
            }
            if ( _scmGoodsUnitDataMap != null )
            {
                _scmGoodsUnitDataMap.Clear();
            }
            if ( _setGoodsUnitDataMap != null )
            {
                _setGoodsUnitDataMap.Clear();
            }
        }
        // --- ADD m.suzuki 2012/04/19 ----------<<<<<

    }
}
