//**********************************************************************//
// システム         ：PM.NS
// プログラム名称   ：PMTAB 自動回答処理(検索) テーブルアクセスクラス
// プログラム概要   ：PMTAB常駐処理よりパラメータで車両、部品検索条件が渡される
//                    車両、部品検索条件より車両、部品の検索を行い、
//                    取得した情報をSCM_DBの検索結果関連のテーブルに書込む
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
//----------------------------------------------------------------------//
// 管理番号  10902622-01  作成担当 : songg
// 作 成 日  2013/05/29   作成内容 : PMTAB 自動回答処理(検索)
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.35の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/18  作成内容 : BLグループコードカナ名称が設定されていません。
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.36の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/18  作成内容 : 車両検索時、全選択のロジックを追加する
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.39の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/18  作成内容 : 得意先情報が存在しないにも関わらず、消費税転嫁方式は消費税設定の消費税転嫁方式に設定します。
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.42の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/18  作成内容 : BLコード検索／品番検索でヒットしなかった場合、正常に動作しません。
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.44の対応　               　      
// 管理番号  10902622-01 作成担当 : huangt                                    
// 作 成 日  2013/06/20  作成内容 : BLコード検索／品番検索後の戻り値の対応
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.46の対応　               　      
// 管理番号  10902622-01 作成担当 : licb                                   
// 作 成 日  2013/06/20  作成内容 : PMTAB得意先マスタ(掛率グループ)、PMTAB商品管理情報マスタ　の処理を追加して下さい。
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.46の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                   
// 作 成 日  2013/06/20  作成内容 : PMTAB得意先マスタ(掛率グループ)、PMTAB商品管理情報マスタ　の処理を追加して下さい。
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.43の対応　               　      
// 管理番号  10902622-01 作成担当 : huangt                                    
// 作 成 日  2013/06/20  作成内容 : 車両検索後のSCM-DBのPMTAB売上(車両情報)セッション管理トランザクションデータを更新します。
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.48の対応　               　      
// 管理番号  10902622-01 作成担当 : huangt                                    
// 作 成 日  2013/06/21  作成内容 : 車輌検索時に、カラーや車台番号を指定しても絞込みが行われない。
//----------------------------------------------------------------------//
// 修正内容　仕様連絡 #37004の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/20  作成内容 : 【自動回答処理(検索)(ＰＭ本体側)】型式からの車両検索を可能にする
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37128の対応　               　      
// 管理番号  10902622-01 作成担当 : huangt                                    
// 作 成 日  2013/06/24  作成内容 : 自動回答処理(検索) ソースを修正して下さい
//----------------------------------------------------------------------//
// 修正内容　障害報告 #36972の対応　               　      
// 管理番号  10902622-01 作成担当 : huangt                                    
// 作 成 日  2013/06/24  作成内容 : 部品検索時に空白メッセージが表示される
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37127の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/24  作成内容 : 車両確定画面 自動回答処理（検索）でエラーになります
//                                  車両検索時、型式指定番号・類別区分番号・型式に値が設定されていない時、
//                                  指摘・確認事項一覧のNo.42の対応と同じ部品検索結果のみをSCM-DBへ書き込みする処理
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37172の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/24  作成内容 : 自動回答処理(検索) 　車両検索でカラー・トリムの絞込みができません
//                                  複数車両が存在する時は絞込み可能。単一車両の時は絞込みできません。
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37187の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/25  作成内容 : 売上全体設定マスタを取得し、拠点コードの抽出で該当データが存在しない時は、"00"（全社共通）で再度抽出を行い、
//                                　該当データ存在時は全社共通のデータを対象とする
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37010の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/25  作成内容 : 【部品入力】特定の車両を選択した場合、部品検索に失敗する。
//                                　年月は999999の場合、DateTime.MaxValueを設定する
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37231の対応　               　      
// 管理番号  10902622-01 作成担当 : huangt                                    
// 作 成 日  2013/06/25  作成内容 : タブレットログ対応
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37360の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/27  作成内容 : 【自動回答処理(検索)】車両確定画面で型式のみ入力してBLコード検索を行うと車両検索でエラーになります
//                                   車両検索で戻り値searchedCarResultの値がretMultipleCarKindで戻ってきた場合、エラーが発生する。
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37738の対応　               　      
// 管理番号  10902622-01 作成担当 : licb                                    
// 作 成 日  2013/07/02  作成内容 : 【自動回答処理(検索)】カラーコードが表示されない。
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37755の対応
// 管理番号  10902622-01 作成担当 : huangt
// 作 成 日  2013/07/03  作成内容 : 速度改善
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37983の対応
// 管理番号  10902622-01 作成担当 : songg
// 作 成 日  2013/07/08  作成内容 : 車両情報の排気量がエンジン型式にセットされてしまいます。
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38046の対応
// 管理番号  10902622-01 作成担当 : songg
// 作 成 日  2013/07/09  作成内容 : 品番検索時の車両全選択処理追加
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38106の対応
// 管理番号  10902622-01 作成担当 : songg
// 作 成 日  2013/07/10  作成内容 : 優良品番点付検索
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38120の対応
// 管理番号  10902622-01 作成担当 : licb
// 作 成 日  2013/07/10  作成内容 : 純正品番点付検索
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38220の対応
// 管理番号  10902622-01 作成担当 : huangt
// 作 成 日  2013/07/11  作成内容 : 不必要なログ出力の削除
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38116の対応
// 管理番号  10902622-01 作成担当 : huangt
// 作 成 日  2013/07/12  作成内容 : キャンペーン売価優先設定マスタ追加
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38573の対応
// 管理番号  10902622-01 作成担当 : songg
// 作 成 日  2013/07/18  作成内容 : 【自動回答登録（検索）】受注マスタ（車両）、装備オブジェクト配列／自由検索型式固定番号配列
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38511の対応
// 管理番号  10902622-01 作成担当 : wangl2
// 作 成 日  2013/07/18  作成内容 : 【部品入力】別の管理拠点の得意先を選択して、入力した際に、掛け率が入力拠点で算出されています
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38106の#13対応
// 管理番号  10902622-01 作成担当 : songg
// 作 成 日  2013/07/18  作成内容 : 格納されている結合元チェック処理追加
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38628対応
// 管理番号  10902622-01 作成担当 : songg
// 作 成 日  2013/07/19  作成内容 : レイアウト変更対応依頼, 系統コード、生産年式コードを追加する。
//----------------------------------------------------------------------//
// 修正内容　指摘・確認事項一覧_社内確認用№376
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/07/22  作成内容 : 純正品番検索時、結合選択画面が表示される障害の対応（品番検索、点付き検索時の検索条件修正）
//----------------------------------------------------------------------//
// 修正内容　障害報告 #38992対応
// 管理番号  10902622-01 作成担当 : 鄭慕鈞
// 作 成 日  2013/07/23  作成内容 : データ削除予定日のフォーマット変更
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39039対応
// 管理番号  10902622-01 作成担当 : huangt
// 作 成 日  2013/07/24  作成内容 : 部品検索 使用する拠点コードの修正
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39168対応
// 管理番号  10902622-01 作成担当 : songg
// 作 成 日  2013/07/25  作成内容 : 品番検索を行うと検索結果のユーザー商品検索結果の提供データ区分が必ず97になる
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39055対応
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/07/24  原単価計算についての修正
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39203対応
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/07/26  販売区分は画面から変更可能なので、全件登録する
//----------------------------------------------------------------------//
// 修正内容　ログ見直し
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/07/29  作成内容 : ログ見直し
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39386対応
// 管理番号  10902622-01 作成担当 : songg
// 作 成 日  2013/07/30  作成内容 : 自社情報マスタ追加
//----------------------------------------------------------------------//
// 修正内容　結合元検索 判断追加 
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/07/30  作成内容 : 結合元検索 判断 追加
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39386対応 
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/07/31  作成内容 : 単価算出クラス呼出時のプロパティ設定追加
//----------------------------------------------------------------------//
// 修正内容　部品検索条件　得意先管理拠点対応
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/07/31  作成内容 : 部品検索条件　得意先管理拠点対応
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39451対応 
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/07/31  作成内容 : 商品管理マスタ取得方法変更
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39451対応 
// 管理番号  10902622-01 作成担当 : 三戸
// 作 成 日  2013/08/01  作成内容 : 未使用テーブル４本削除
//----------------------------------------------------------------------//
// 修正内容　障害報告 #39487対応 
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/08/01  作成内容 : 品番検索でSCM-DB車両情報更新条件追加
//----------------------------------------------------------------------//
// 修正内容　Rdmine#39496対応
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/08/01  作成内容 : Rdmine#39496対応
//----------------------------------------------------------------------//
// 修正内容　Rdmine#39451対応
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/08/02  作成内容 : 検索処理速度改善
//----------------------------------------------------------------------//
// 修正内容　Rdmine#39451対応
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/08/05  作成内容 : 検索処理速度改善：仕入金額処理区分マスタ抽出条件追加
//----------------------------------------------------------------------//
// 修正内容　Rdmine#39564対応
// 管理番号  10902622-01 作成担当 : 高川
// 作 成 日  2013/08/05  作成内容 : Redmine#39564対応
//----------------------------------------------------------------------//
// 修正内容　Rdmine#39600対応
// 管理番号  10902622-01 作成担当 : 高川
// 作 成 日  2013/08/05  作成内容 : 自動回答(検索) 標準価格選択の対応
//----------------------------------------------------------------------//
// 修正内容　Rdmine#39694対応
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/08/07  作成内容 : 仕入金額処理区分マスタ抽出条件修正
//----------------------------------------------------------------------//
// 修正内容　Rdmine#39759対応
// 管理番号  10902622-01 作成担当 : 湯上
// 作 成 日  2013/08/08  作成内容 : 仕入金額処理区分マスタ抽出条件修正
//----------------------------------------------------------------------//
// 修正内容　Redmine#40185対応
// 管理番号  10902622-01 作成担当 : 三戸
// 作 成 日  2013/08/28  作成内容 : 装備オブジェクト配列取得修正
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/10/08  修正内容 : 山形部品速度遅延対応 SCM仕掛一覧№10579
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上
// 作 成 日  2013/10/08  修正内容 : 山形部品速度遅延対応 SCM仕掛一覧№10579
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上
// 作 成 日  2013/12/13  修正内容 : SCM障害一覧№10609対応
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/12/19  修正内容 : VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4(SCM障害一覧№10609対応と関連)
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2014/01/16  修正内容 : VSS[020_10] Redmine#979(SCM障害一覧№10609対応と関連)
//----------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using SalesTtlStServer = SingletonInstanceForTablet<SalesTtlStAgentForTablet>;
    using Broadleaf.Library.Resources;
    using System.Collections;
    using Broadleaf.Application.Remoting.ParamData;
    using Broadleaf.Application.Remoting;
    using Broadleaf.Application.Remoting.Adapter;
    using Broadleaf.Library.Collections;
    using Broadleaf.Library.Text;   

    /// <summary>
    /// PMTAB 自動回答処理(検索処理) テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索処理を行います。
    ///                  取得した情報をSCM_DBの検索結果関連のテーブルに書込む</br>
    /// <br>Programmer : songg</br>
    /// <br>Date       : 2013/05/29</br>
    /// </remarks>
    public class PMTAB00142AB
    {
        #region ★Private メンバー
        /// <summary>純正メーカー最大コード</summary>
        private static readonly Int32 ctPureGoodsMakerCode = 999;

        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----->>>>>
        private const string CLASS_NAME = "PMTAB00142AB";
        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 -----<<<<<

        //-----ADD songg 2013/06/27 障害報告 #37360の対応 ---->>>>>
        // 車両検索アクセス
        CarSearchController _carAccesser = null;
        //-----ADD songg 2013/06/27 障害報告 #37360の対応 ----<<<<<

        // ----- ADD huangt 2013/07/03 Redmine#37755 速度改善対応 ----->>>>>
        GoodsAcs _goodsAcs = null;
        // ----- ADD huangt 2013/07/03 Redmine#37755 速度改善対応 -----<<<<<

        // ----- ADD huangt 2013/07/24 Redmine#39039 部品検索 使用する拠点コードの修正 ----->>>>>
        // 管理拠点コード
        private string _mngSectionCode = "";
        // ----- ADD huangt 2013/07/24 Redmine#39039 部品検索 使用する拠点コードの修正 -----<<<<<
        // ADD 2013/07/24 吉岡 Redmine#39055 --------------->>>>>>>>>>>>>>>>>>>>>>
        ArrayList allStockProcMoneyList;
        // ADD 2013/07/24 吉岡 Redmine#39055 ---------------<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/07/31 吉岡 得意先管理拠点対応 ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private CustomerInfoAcs _customerDB = null;
        private CustomerInfo _customerInfo = null;
        // ADD 2013/07/31 吉岡 得意先管理拠点対応 -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/07/31 yugami Redmine#39451対応 ----------------------------------->>>>>
        private List<GoodsMngWork> _goodsMngList = null;
        // ADD 2013/07/31 yugami Redmine#39451対応 -----------------------------------<<<<<

        // ADD 2013/08/01 吉岡 Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private string _enterpriseCode = string.Empty;
        private int _customerCode = 0;
        // ADD 2013/08/01 吉岡 Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/08/02 Redmine#39451 速度改善3 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 売上全体設定マスタアクセスクラス
        /// </summary>
        SalesTtlStAcs _salesTtlStAcs = new SalesTtlStAcs();          // 売上全体設定マスタ
        /// <summary>
        /// 売上全体設定マスタ　キャッシュ用変数
        /// </summary>
        SalesTtlSt _salesTtlSt = null;
        /// <summary>
        /// 売上全体設定マスタがキャッシュされた際の検索拠点コード　
        /// キャッシュ売上全体設定マスタが全社の場合を考慮し、検索時の拠点コードを保管
        /// </summary>
        string _saveSectionCode = string.Empty;
        // 2013/08/02 Redmine#39451 速度改善3 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/08/05 Redmine#39451 --------------->>>>>>>>>>>>>>>>>>>>>>
        private List<StockProcMoney> _stockProcMoneyList;
        // ADD 2013/08/05 Redmine#39451 ---------------<<<<<<<<<<<<<<<<<<<<<<


        #endregion ★Private メンバー

        // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
        private GoodsAcs _goodsAccesser;
        public GoodsAcs GoodsAccesser
        {
            get { return _goodsAccesser; }
            set { _goodsAccesser = value; }
        }
        // キャンペーン売価優先設定リスト
        private ArrayList _campaignPrcPrStList;
        public ArrayList CampaignPrcPrStList
        {
            get { return _campaignPrcPrStList; }
            set { _campaignPrcPrStList = value; }
        }
        // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<


        #region ★BLコード検索処理
        /// <summary>
        /// BLコード検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコード検索処理と行います</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsNo">品番コード</param>
        /// <param name="blGoodsCode">ＢＬ商品コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別区分番号</param>
        /// <param name="fullModel">型式(フル型)</param>
        /// <param name="carInspectCertModel">車検証型式</param>
        /// <param name="businessSessionId">業務セッションコード</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="pmTabSalesDtCarWork">PMTAB売上(車両情報)セッション管理トランザクションデータ</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        public int SearchByCarAndBLCodeForTablet(string enterpriseCode, string sectionCode,
            string goodsNo, int blGoodsCode, int customerCode,
            int makerCode, int modelCode, int modelSubCode, int modelDesignationNo,
            int categoryNo, string fullModel, string carInspectCertModel,
            string businessSessionId, string pmTabSearchGuid,
            out string message
            ,PmTabSalesDtCarWork pmTabSalesDtCarWork)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----->>>>>
            const string methodName = "SearchByCarAndBLCodeForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // メッセージ
            message = string.Empty;

            #region <車両検索>
            // 車両情報の検索結果
            CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;
            PMKEN01010E searchedCarInfo = null;

            // 1パラ目：検索条件
            CarSearchCondition searchingCarCondition = this.CreateSearchingCarCondition(makerCode, modelCode,
                modelSubCode, modelDesignationNo, categoryNo, fullModel, carInspectCertModel);

            if (searchingCarCondition.ModelDesignationNo == 0 &&             // 型式指定番号
                searchingCarCondition.CategoryNo == 0 &&                     // 類別区分番号
                searchingCarCondition.CarModel.FullModel == string.Empty)    // 型式(フル型)
            {
                // 車両検索の条件が無いので、車両検索しない
                searchedCarResult = CarSearchResultReport.retFailed;
                searchedCarInfo = new PMKEN01010E();
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "車両検索の条件（型式指定番号、類別区分番号、型式(フル型)）が無いので、車両検索しませんでした。");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

                //-----ADD songg 2013/06/24 障害報告 #37127の対応  ---->>>>>
                try
                {
                    int status2 = NotCarInfoPro(enterpriseCode, sectionCode, goodsNo, blGoodsCode,
                       businessSessionId, pmTabSearchGuid, out message);

                    if (status2 == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        return status2;
                    }
                }
                catch (Exception ex)
                {
                    message = ex.ToString();
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                message = "車両データがありません。";

                // UPD 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, message);
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　" + message);
                // UPD 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //-----ADD songg 2013/06/24 障害報告 #37127の対応  ----<<<<<
            }
            else
            {

                // 2パラ目：検索結果
                searchedCarInfo = new PMKEN01010E();

                if (this.CheckCarSearchCondition(searchingCarCondition))
                {
                    // 車両検索
                    searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, "車両検索結果　searchedCarResult：" + searchedCarResult.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

                    // 車両検索結果0件の場合
                    if (!searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                       !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                        &&
                       !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                    {
                        // BLコード検索の車両検索でヒットしなかった場合、部品検索結果のみSCM-DBへ書き込みます
                        //-----DEL huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 ---->>>>> 
                        //NotCarInfoPro(enterpriseCode, sectionCode, goodsNo, blGoodsCode,
                        //    businessSessionId, pmTabSearchGuid, out message);
                        //-----DEL huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 ----<<<<<

                        //-----ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 ---->>>>>
                        try
                        {
                            int status2 = NotCarInfoPro(enterpriseCode, sectionCode, goodsNo, blGoodsCode,
                               businessSessionId, pmTabSearchGuid, out message);

                            if (status2 == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                return status2;
                            }
                        }
                        catch (Exception ex)
                        {
                            message = ex.ToString();
                            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                            EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        //-----ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 ----<<<<<

                        message = "車両データがありません。";

                        // UPD 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                        //EasyLogger.Write(CLASS_NAME, methodName, message);
                        //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                        //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                        #endregion
                        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　" + message);
                        // UPD 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        //return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;     // DEL huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応
                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;          // ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応
                    }

                    // 検索結果を保持 ∵1問合せで車両は同じであるため、同じ車両検索を何度も行わない
                    if (searchedCarInfo != null)
                    {
                        if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                        {
                            if (searchedCarInfo.CarKindInfo != null &&
                                searchedCarInfo.CarKindInfo.Count > 0)
                            {
                                searchedCarInfo.CarKindInfo[0].SelectionState = true;
                                searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                            }
                        }
                        //-----ADD songg 2013/06/18 ソースチェック確認事項一覧にNo.36の対応 ---->>>>>
                        //-----DEL songg 2013/06/24 障害報告 #37172の対応 単一車両の時は絞込みできません ---->>>>>
                        // 型式複数件検索の場合、検索結果の車両が全選択処理を行います
                        //else if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel))
                        //{                                                                            
                        //    SearchCarByMultipleCarModel(searchingCarCondition, ref searchedCarInfo, pmTabSalesDtCarWork);
                        //}
                        //-----DEL songg 2013/06/24 障害報告 #37172の対応 単一車両の時は絞込みできません ----<<<<<
                        //-----ADD songg 2013/06/24 障害報告 #37172の対応 単一車両の時は絞込みできません ---->>>>>
                        // 車両検索でカラー・トリムの絞込み
                        SearchCarByMultipleCarModel(searchingCarCondition, ref searchedCarInfo, pmTabSalesDtCarWork);
                        //-----ADD songg 2013/06/24 障害報告 #37172の対応 単一車両の時は絞込みできません ----<<<<<
                        //-----ADD songg 2013/06/18 ソースチェック確認事項一覧にNo.36の対応 ----<<<<<
                    }
                }
                else
                {
                    searchedCarResult = CarSearchResultReport.retFailed;
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, "車輌検索条件設定チェック　ＮＧ");
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                }
            }

            // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
            if (
                !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retFailed)              // 検索結果0件も許可する
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind)
            )
            {
                message = "車両データがありません。";
                // UPD 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, message);
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　" + message);
                // UPD 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                //return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;     // DEL huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;          // ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応
            }


            #endregion // </車両検索>

            #region <BL検索>
            // 検索結果が1件であれば、BL検索を開始
            // 1パラ目：検索条件
            GoodsCndtn searchingGoodsCondition = EditSearchingGoodsCondition(
                // UPD 2013/07/31 吉岡 得意先管理拠点対応 ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //CreateSearchingGoodsCondition(enterpriseCode, sectionCode,
                //                              goodsNo, blGoodsCode, searchedCarInfo)
                CreateSearchingGoodsCondition(enterpriseCode, sectionCode,
                                              goodsNo, blGoodsCode, searchedCarInfo,customerCode)
                // UPD 2013/07/31 吉岡 得意先管理拠点対応 -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                      );

            // 2パラ目：部品情報
            PartsInfoDataSet partsInfoDB = null;

            // 3パラ目：商品連結データ
            List<GoodsUnitData> goodsUnitDataList = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<Rate> rateList = new List<Rate>();
            try
            {
                // 車輌データあり⇒BLコード検索
                // BL検索
                status = SearchPartsFromBLCodeCarInfo(enterpriseCode, sectionCode, customerCode,
                    searchingGoodsCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out message,
                    searchedCarInfo,
                    out unitPriceCalcRetList,
                    out rateList);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "BLコード検索　status：" + status.ToString() + " " + message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }
            catch(Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.ToString();
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

                return status;// ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応
            }

            // 検索なしの場合、またはエラーががある場合、ステータスを戻ります。
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応 ---->>>>>
                // 商品検索結果なしの場合、PMTABユーザー商品検索結果はSCM DBに登録処理
                try
                {
                    status = NotUrGoodsInfoPro(partsInfoDB, enterpriseCode, sectionCode,
                        goodsNo, blGoodsCode, businessSessionId, pmTabSearchGuid,
                        out message);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "部品データがありません。";
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.ToString();
                }
                //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応 ----<<<<<
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            #endregion // </BL検索>

            // 保存用リスト初期化
            CustomSerializeArrayList pmtPartsSearchWorkList = new CustomSerializeArrayList();

            // 車両情報をUSER DBに書込む																							
            // PMTAB受注マスタ（車両）
            // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 ------------------->>>>>>>>>>>>>>>
            #region 旧ソース
            //// UPD 2013/12/12 SCM仕掛一覧№10609対応 -------------------------->>>>>
            ////status = WritePmTabAcpOdrCar(searchedCarInfo,enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            //status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid, pmTabSalesDtCarWork);
            //// UPD 2013/12/12 SCM仕掛一覧№10609対応 --------------------------<<<<<
            #endregion
            status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 -------------------<<<<<<<<<<<<<<<
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "PMTAB受注マスタ（車両）登録処理　status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }

            //-----ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.43の対応 ---->>>>>
            // 車両情報をSCM DBに更新する
            status = WritePmTabSalDCar(searchedCarInfo, pmTabSalesDtCarWork, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "商品検索結果なしの場合、PMTABユーザー商品検索結果のSCM DB登録処理　status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            //-----ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.43の対応 ----<<<<<

            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応 ---->>>>>
            //// 商品検索結果なしの場合、PMTABユーザー商品検索結果はSCM DBに登録処理
            //status = NotUrGoodsInfoPro(partsInfoDB, ref pmtPartsSearchWorkList, 
            //    enterpriseCode, sectionCode, goodsNo, blGoodsCode, 
            //    businessSessionId, pmTabSearchGuid, out message);
            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || 
            //    (status == (int)ConstantManagement.DB_Status.ctDB_ERROR))
            //{
            //    return status;
            //}
            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応 ----<<<<<

            // 商品連結データ不足情報設定
            this.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, sectionCode);

            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
            //// 単価計算
            //SetCalculator(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
            //    sectionCode, customerCode, out unitPriceCalcRetList, out rateList);
            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<

            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
            // 得意先掛率グループリスト
            List<CustRateGroup> custRateGroupList = new List<CustRateGroup>();
            // 単価計算
            SetCalculator(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
                sectionCode, customerCode, out unitPriceCalcRetList, out custRateGroupList, out rateList);
            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<

            // (17個テーブル)部品検索結果をSCM DBに書込む
            GetPartsInfoToScmDBDataList(partsInfoDB, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid, ref pmtPartsSearchWorkList);
																			
            // PMTAB掛率検索結果データ（一時）
            GetRateToScmDBDataList(rateList,
                enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList);

            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
            // 得意先マスタ（掛率グループ）マスタデータ登録
            GetCustRateGroupToScmDBDataList(custRateGroupList,
                enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList);
            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<

            // マスタデータ相関処理
            status = GetMastDataToScmDBDataList(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                ref pmtPartsSearchWorkList, 
                goodsUnitDataList, out message,
                customerCode);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "マスタデータ相関処理　status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            //return status;      // DEL huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 
        }

        //-----ADD songg 2013/06/18 ソースチェック確認事項一覧にNo.36の対応 ---->>>>>
        #region 型式複数件検索の場合、検索結果の車両が全選択処理
        /// <summary>
        /// 型式複数件検索の場合、検索結果の車両が全選択処理
        /// </summary>
        /// <param name="searchingCarCondition">検索条件</param>
        /// <param name="searchedCarInfo">検索結果</param>
        /// <param name="carRecord">PMTAB売上(車両情報)セッション管理トランザクションデータ</param>
        private void SearchCarByMultipleCarModel(CarSearchCondition searchingCarCondition,
            ref PMKEN01010E searchedCarInfo,
            PmTabSalesDtCarWork carRecord)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchCarByMultipleCarModel";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            string frameModel = string.Empty;
            string chassisNo = string.Empty;
            int status = -1;
            int searchFrameNo = 0;
            if (!String.IsNullOrEmpty(carRecord.FrameNo))
            {
                status = GenerateChassisNoFrameFromFrameNo(carRecord.FrameNo, out frameModel, out chassisNo);
                if (status.Equals(0))
                {
                    searchFrameNo = TStrConv.StrToIntDef(chassisNo, 0);
                }
                else
                {
                    searchFrameNo = 0;
                }
            }

            int produceTypeOfYearNum = 0;
            if (carRecord.ProduceTypeOfYearNum != 0)
            {
                produceTypeOfYearNum = carRecord.ProduceTypeOfYearNum;
            }
            else if (0 != searchFrameNo)
            {
                produceTypeOfYearNum = searchedCarInfo.GetProduceTypeOfYear(searchFrameNo); 
            }

            // 型式選択…型式選択ウィンドウ表示対象となった場合、型式選択ウィンドウ表示を行わず、
            // 全選択として処理結果を戻す
            // 年式、車台番号で絞り込み
            int selectedCnt = 0;
            if (produceTypeOfYearNum > 0)
            {
                selectedCnt = searchedCarInfo.SelectCarModelProduceTypeOfYear(produceTypeOfYearNum);
            }
            else if (searchFrameNo > 0)
            {
                selectedCnt = searchedCarInfo.SelectCarModelSearchFrameNo(searchFrameNo);
            }

            if (selectedCnt == 0)
            {
                searchedCarInfo.AllSelect();
            }
            CarSearchController carAccesser = new CarSearchController();
            carAccesser.Search(searchingCarCondition, ref searchedCarInfo);


            if (searchedCarInfo.CarModelInfoSummarized != null && searchedCarInfo.CarModelInfoSummarized.Rows.Count > 0)
            {
                PMKEN01010E.CarModelInfoRow row = searchedCarInfo.CarModelInfoSummarized[0];

                // 年式の絞込み
                if (produceTypeOfYearNum != 0)
                {
                    int stDate = (((row.StProduceTypeOfYear / 100) == 9999) || ((row.StProduceTypeOfYear % 100) == 99)) ? 0 : row.StProduceTypeOfYear;
                    int edDate = (((row.EdProduceTypeOfYear / 100) == 9999) || ((row.EdProduceTypeOfYear % 100) == 99)) ? 0 : row.EdProduceTypeOfYear;

                    if (stDate != 0 || edDate != 0)
                    {
                        edDate = (edDate == 0) ? 999999 : edDate;

                        if (stDate <= produceTypeOfYearNum && produceTypeOfYearNum <= edDate)
                        {
                            searchedCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = produceTypeOfYearNum;
                        }
                    }
                }

                // UPD 2014/01/16 吉岡 2014/01/22配信予定 VSS[020_10] Redmine#979 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // if (searchFrameNo != 0)
                if (chassisNo != null && chassisNo.Length > 0)
                // UPD 2014/01/16 吉岡 2014/01/22配信予定 VSS[020_10] Redmine#979 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    if ((row.StProduceFrameNo != 0 && row.StProduceFrameNo > searchFrameNo) ||
                        (row.EdProduceFrameNo != 0 && row.EdProduceFrameNo < searchFrameNo))
                    {
                    }
                    else
                    {
                        // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 ------------------->>>>>>>>>>>>>>>
                        // searchedCarInfo.CarModelUIData[0].FrameNo = searchFrameNo.ToString();
                        searchedCarInfo.CarModelUIData[0].FrameNo = chassisNo;
                        // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 -------------------<<<<<<<<<<<<<<<
                        searchedCarInfo.CarModelUIData[0].SearchFrameNo = searchFrameNo;
                    }
                }
            }

            // カラーの絞込み
            if (!string.IsNullOrEmpty(carRecord.RpColorCode))
            {
                PMKEN01010E.ColorCdInfoRow[] colorRows = (PMKEN01010E.ColorCdInfoRow[])searchedCarInfo.ColorCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.ColorCdInfo.ColorCodeColumn.ColumnName, carRecord.RpColorCode));
                if (colorRows.Length > 0)
                {
                    colorRows[0].SelectionState = true;
                }
            }

            // トリムの絞込み
            if (!string.IsNullOrEmpty(carRecord.TrimCode))
            {
                PMKEN01010E.TrimCdInfoRow[] trimRows = (PMKEN01010E.TrimCdInfoRow[])searchedCarInfo.TrimCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.TrimCdInfo.TrimCodeColumn.ColumnName, carRecord.TrimCode));
                if (trimRows.Length > 0)
                {
                    trimRows[0].SelectionState = true;
                }
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        }

        /// <summary>
        /// 車台番号→シャシー№生成処理
        /// </summary>
        /// <param name="frameNo">車台番号</param>
        /// <param name="frameModel">車台型式</param>
        /// <param name="chassisNo">シャシNo</param>
        /// <returns>STATUS [0:生成完了 0以外:生成失敗]</returns>
        public static int GenerateChassisNoFrameFromFrameNo(string frameNo, out string frameModel, out string chassisNo)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GenerateChassisNoFrameFromFrameNo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            frameModel = "";
            chassisNo = "";

            if (frameNo == "")
            {
                frameModel = "";
                chassisNo = "";
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return 0;
            }

            // 全角文字列が含まれている場合は生成不能
            if (!IsOneByteChar(frameNo.Trim()))
            {
                frameModel = "";
                chassisNo = "";
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 車台番号に全角文字列有り");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return 0;
            }

            int length = frameNo.Length;
            int chassisNoCache = 0;
            string[] split = frameNo.Split(new Char[] { '-' });

            if (split.Length < 0)
            {
                // 分割した結果の配列数が1以下の場合は算定不能
                return 1;
            }
            else if (split.Length == 1)
            {
                frameModel = split[0];					// 車台型式
                chassisNo = split[0];
                if (!int.TryParse(chassisNo, out chassisNoCache))
                {
                    chassisNo = "";
                }

            }
            else if (split.Length == 2)
            {
                frameModel = split[0];					// 車台型式
                chassisNo = split[1];					// シャシーNo

                if (!int.TryParse(chassisNo, out chassisNoCache))
                {
                    chassisNo = "";
                }
            }
            else
            {
                chassisNo = "";

                frameModel = split[0];					// 車台型式
            }

            // 桁数チェック
            if (frameModel.Length > 16)
            {
                frameModel = frameModel.Remove(16, frameModel.Length - 16);
            }
            if (chassisNo.Length > 18)
            {
                chassisNo = chassisNo.Remove(18, chassisNo.Length - 18);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return 0;
        }

        /// <summary>
        /// 1バイト文字で構成された文字列であるか判定 
        /// 1バイト文字のみで構成された文字列 : True 
        /// 2バイト文字が含まれている文字列 : False
        /// </summary>
        /// <param name="str"></param>
        /// <returns>status</returns>
        private static bool IsOneByteChar(string str)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "IsOneByteChar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            byte[] byte_data = System.Text.Encoding.GetEncoding(932).GetBytes(str);
            if (byte_data.Length == str.Length)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return true;
            }
            else
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return false;
            }
        }
        #endregion 型式複数件検索の場合、検索結果の車両が全選択処理
        //-----ADD songg 2013/06/18 ソースチェック確認事項一覧にNo.36の対応 ----<<<<<

        /// <summary>
        /// BLコード検索の車両検索でヒットしなかった場合、PMTABユーザー商品検索結果はSCM DBに登録処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="blGoodsCode">ＢＬ商品コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        private int NotCarInfoPro(
            string enterpriseCode,
            string sectionCode,
            string goodsNo,
            int blGoodsCode,
            string businessSessionId,
            string pmTabSearchGuid,
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "NotCarInfoPro";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            CustomSerializeArrayList pmtPartsSearchWorkList = new CustomSerializeArrayList();

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            DateTime now = DateTime.Now;
            PmtUrGdsInfTmpWork tempPmtUrGdsInfTmpWork = new PmtUrGdsInfTmpWork();
            tempPmtUrGdsInfTmpWork.CreateDateTime = now;// 作成日時
            tempPmtUrGdsInfTmpWork.UpdateDateTime = now;// 更新日時
            tempPmtUrGdsInfTmpWork.EnterpriseCode = enterpriseCode;// 企業コード
            tempPmtUrGdsInfTmpWork.LogicalDeleteCode = 0;// 論理削除区分
            tempPmtUrGdsInfTmpWork.BusinessSessionId = businessSessionId;// 業務セッションID
            tempPmtUrGdsInfTmpWork.PmTabDtlDiscGuid = pmTabSearchGuid;// PMTAB明細識別GUID
            //tempPmtUrGdsInfTmpWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));// データ削除予定日  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
            tempPmtUrGdsInfTmpWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));//データ削除予定日  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
            tempPmtUrGdsInfTmpWork.SearchSectionCode = sectionCode;// 検索拠点コード
            tempPmtUrGdsInfTmpWork.PmTabSearchRowNum = 1;// PMTAB検索行番号
            tempPmtUrGdsInfTmpWork.GoodsNo = goodsNo;// 商品番号
            tempPmtUrGdsInfTmpWork.BlGoodsCode = blGoodsCode;// BL商品コード
            tempPmtUrGdsInfTmpWork.OfferDataDiv = 98;// 提供データ区分

            List<PmtUrGdsInfTmpWork> pmtUrGdsInfoTmpList = new List<PmtUrGdsInfTmpWork>();
            pmtUrGdsInfoTmpList.Add(tempPmtUrGdsInfTmpWork);

            // 追加部品検索結果情報
            pmtPartsSearchWorkList.Add(pmtUrGdsInfoTmpList);

            // ★★★★★全てUSER DBのデータはSCM DBに保存処理を行います★★★
            IPmtPartsSearchDB iPmtPartsSearchDB = MediationPmtPartsSearchDB.GetPmtPartsSearchDB();
            object objList = pmtPartsSearchWorkList;
            iPmtPartsSearchDB.Write(ref objList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// 商品検索結果なしの場合、PMTABユーザー商品検索結果はSCM DBに登録処理
        /// </summary>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="blGoodsCode">ＢＬ商品コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        private int NotUrGoodsInfoPro(PartsInfoDataSet partsInfoDB,
            // ref CustomSerializeArrayList pmtPartsSearchWorkList, //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応
            string enterpriseCode, 
            string sectionCode,
            string goodsNo, 
            int blGoodsCode,
            string businessSessionId, 
            string pmTabSearchGuid, 
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "NotUrGoodsInfoPro";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";


            // 部品検索結果フラグ（True: ある; False：なし）
            Boolean hasUrGdsInfoData = false;
            // BLコード検索／品番検索でヒットしなかった場合の処理に関して
            // 以下の部品検索結果のみSCM-DBへ書き込みます。

            if ((partsInfoDB.UsrGoodsInfo != null) && (partsInfoDB.UsrGoodsInfo.Count > 0))
            {
                hasUrGdsInfoData = true;

            }

            // データなしの場合
            if (!hasUrGdsInfoData)
            {
                // クリアその他テーブル情報
                //pmtPartsSearchWorkList.Clear();//-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                DateTime now = DateTime.Now;
                PmtUrGdsInfTmpWork tempPmtUrGdsInfTmpWork = new PmtUrGdsInfTmpWork();
                tempPmtUrGdsInfTmpWork.CreateDateTime = now;// 作成日時
                tempPmtUrGdsInfTmpWork.UpdateDateTime = now;// 更新日時
                tempPmtUrGdsInfTmpWork.EnterpriseCode = enterpriseCode;// 企業コード
                tempPmtUrGdsInfTmpWork.LogicalDeleteCode = 0;// 論理削除区分
                tempPmtUrGdsInfTmpWork.BusinessSessionId = businessSessionId;// 業務セッションID
                tempPmtUrGdsInfTmpWork.PmTabDtlDiscGuid = pmTabSearchGuid;// PMTAB明細識別GUID
                //tempPmtUrGdsInfTmpWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));// データ削除予定日  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempPmtUrGdsInfTmpWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));// データ削除予定日  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempPmtUrGdsInfTmpWork.SearchSectionCode = sectionCode;// 検索拠点コード
                tempPmtUrGdsInfTmpWork.PmTabSearchRowNum = 1;// PMTAB検索行番号
                tempPmtUrGdsInfTmpWork.GoodsNo = goodsNo;// 商品番号
                tempPmtUrGdsInfTmpWork.BlGoodsCode = blGoodsCode;// BL商品コード
                tempPmtUrGdsInfTmpWork.OfferDataDiv = 99;// 提供データ区分

                List<PmtUrGdsInfTmpWork> pmtUrGdsInfoTmpList = new List<PmtUrGdsInfTmpWork>();
                pmtUrGdsInfoTmpList.Add(tempPmtUrGdsInfTmpWork);

                CustomSerializeArrayList pmtPartsSearchWorkList = new CustomSerializeArrayList();//-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応

                // 追加部品検索結果情報
                pmtPartsSearchWorkList.Add(pmtUrGdsInfoTmpList);

                // ★★★★★全てUSER DBのデータはSCM DBに保存処理を行います★★★
                IPmtPartsSearchDB iPmtPartsSearchDB = MediationPmtPartsSearchDB.GetPmtPartsSearchDB();
                object objList = pmtPartsSearchWorkList;
                iPmtPartsSearchDB.Write(ref objList);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// BL検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="searchingGoodsCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="carInfo">車両情報</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <returns>結果コード</returns>
        protected int SearchPartsFromBLCodeCarInfo(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg, PMKEN01010E carInfo,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<Rate> rateList)
        {
            return SearchPartsFromBLCode(enterpriseCode, sectionCode, customerCode,
                searchingGoodsCondition, out partsInfoDB, out goodsUnitDataList, out msg,
                out unitPriceCalcRetList,
                out rateList);
        }

        #region <BL検索>
        /// <summary>
        /// BL検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="searchingGoodsCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <returns>結果コード</returns>
        protected int SearchPartsFromBLCode(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<Rate> rateList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchPartsFromBLCode";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            rateList = new List<Rate>();

            // UPD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
            //GoodsAcs _goodsAccesser = new GoodsAcs(sectionCode);
            //_goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);//-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応
            if (_goodsAccesser == null)
            {
                _goodsAccesser = new GoodsAcs(sectionCode);
                _goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);//-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応
            }
            // UPD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

            int status = _goodsAccesser.SearchPartsFromBLCodeForAutoSearch(
                searchingGoodsCondition,
                out partsInfoDB,
                out goodsUnitDataList,
                out msg
            );
            if (!status.Equals((int)ResultUtil.ResultCode.Normal)) return status;

            if (partsInfoDB != null)
            {
                // 品名表示区分
                //-----DEL songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
                //SalesTtlSt foundSalesTtlSt = SalesTtlStDB.Find(
                //    searchingGoodsCondition.EnterpriseCode,
                //    searchingGoodsCondition.SectionCode
                //);
                //-----DEL songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ----<<<<<
                //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
                SalesTtlSt foundSalesTtlSt = GetSalesTtlStInfo(
                    searchingGoodsCondition.EnterpriseCode,
                    searchingGoodsCondition.SectionCode);
                //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ----<<<<<
                if (foundSalesTtlSt != null)
                {
                    partsInfoDB.SetPartsNameDisplayPattern(foundSalesTtlSt);
                    partsInfoDB.PriceSelectDispDiv = foundSalesTtlSt.PriceSelectDispDiv;
                    partsInfoDB.UnPrcNonSettingDiv = foundSalesTtlSt.UnPrcNonSettingDiv;
                }
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        #endregion // </BL検索>
        #endregion ★BLコード検索処理

        #region ★品番検索処理
        /// <summary>
        /// 品番検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 品番検索処理と行います</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsNo">品番コード</param>
        /// <param name="blGoodsCode">ＢＬ商品コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別区分番号</param>
        /// <param name="fullModel">型式(フル型)</param>
        /// <param name="carInspectCertModel">車検証型式</param>
        /// <param name="businessSessionId">業務セッションコード</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="message">メッセージ</param>
        /// <param name="pmTabSalesDtCarWork">PMTAB売上(車両情報)セッション管理トランザクションデータ</param>
        /// <returns>ステータス</returns>
        public int SearchByGoodsNoForTablet(string enterpriseCode, string sectionCode,
            string goodsNo, int blGoodsCode, int customerCode,
            int makerCode, int modelCode, int modelSubCode, int modelDesignationNo,
            int categoryNo, string fullModel, string carInspectCertModel,
            string businessSessionId, string pmTabSearchGuid, out string message
            , PmTabSalesDtCarWork pmTabSalesDtCarWork)     // ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.43の対応 
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchByGoodsNoForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // メッセージ
            message = string.Empty;

            #region <車両検索>

            // 車両情報の検索結果
            CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;
            PMKEN01010E searchedCarInfo = null;

            // 1パラ目：検索条件
            CarSearchCondition searchingCarCondition = this.CreateSearchingCarCondition(makerCode, modelCode,
                modelSubCode, modelDesignationNo, categoryNo, fullModel, carInspectCertModel);

            if (searchingCarCondition.ModelDesignationNo == 0 &&             // 型式指定番号
                searchingCarCondition.CategoryNo == 0 &&                     // 類別区分番号
                searchingCarCondition.CarModel.FullModel == string.Empty)    // 型式(フル型)
            {
                // 車両検索の条件が無いので、車両検索しない
                searchedCarResult = CarSearchResultReport.retFailed;
                searchedCarInfo = new PMKEN01010E();
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "車両検索の条件（型式指定番号、類別区分番号、型式(フル型)）が無いので、車両検索しませんでした。");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }
            else
            {
                // 2パラ目：検索結果
                searchedCarInfo = new PMKEN01010E();

                if (this.CheckCarSearchCondition(searchingCarCondition))
                {
                    // 車両検索
                    searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, "車両検索結果　searchedCarResult：" + searchedCarResult.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

                    // 検索結果を保持 ∵1問合せで車両は同じであるため、同じ車両検索を何度も行わない
                    if (searchedCarInfo != null)
                    {
                        if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                        {
                            if (searchedCarInfo.CarKindInfo != null &&
                                searchedCarInfo.CarKindInfo.Count > 0)
                            {
                                searchedCarInfo.CarKindInfo[0].SelectionState = true;
                                searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                            }
                        }

                        // ADD songg 2013/07/09 Redmine#38046 品番検索時の車両全選択処理追加-------------------------------------------->>>>>
                        // 車両検索でカラー・トリムの絞込み
                        SearchCarByMultipleCarModel(searchingCarCondition, ref searchedCarInfo, pmTabSalesDtCarWork);
                        // ADD songg 2013/07/09 Redmine#38046 品番検索時の車両全選択処理追加--------------------------------------------<<<<<
                    }
                }
                else
                {
                    searchedCarResult = CarSearchResultReport.retFailed;
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, "車輌検索条件設定チェック　ＮＧ");
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                }
            }
            #endregion // </車両検索>

            // 車両検索結果が1件の場合のみ正常 ※全選択した場合は1件とみなす
            if (
                !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retFailed)              // 検索結果0件も許可する
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // 全選択の際の結果
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind)
            )
            {
                message = "車両データがありません。";
                // UPD 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, message);
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　" + message);
                // UPD 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                //return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;      // DEL huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;           // ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応
            }

            #region <品番検索>
            // 1パラ目：検索条件
            GoodsCndtn searchingCondition = EditSearchingGoodsCondition(
                // UPD 2013/07/31 吉岡 得意先管理拠点対応 ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //CreateSearchingGoodsCondition(enterpriseCode, sectionCode,
                //                              goodsNo, blGoodsCode, searchedCarInfo)
                CreateSearchingGoodsCondition(enterpriseCode, sectionCode,
                                              goodsNo, blGoodsCode, searchedCarInfo, customerCode)
                // UPD 2013/07/31 吉岡 得意先管理拠点対応 -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                );

            // DEL 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№376-------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region
            //// ----- ADD licb 2013/07/10 Redmine#38120 純正品番点付検索 ----- >>>>>
            //if (!(string.IsNullOrEmpty(searchingCondition.GoodsNo)) && (searchingCondition.GoodsNo.Length > 1)
            //    && (searchingCondition.GoodsNo.LastIndexOf(".") == searchingCondition.GoodsNo.Length - 1))
            //{
            //    //商品番号がドット(．)付の時はドット(．)を固定でセット
            //    searchingCondition.PartsJoinCntDivCd = ".";
            //    // ----- ADD songg 2013/07/10 Redmine#38106 優良品番点付検索 ----- >>>>>
            //    // 商品番号がドット（．）付の時はドットを除い
            //    searchingCondition.GoodsNo = searchingCondition.GoodsNo.Substring(0, searchingCondition.GoodsNo.Length - 1);
            //    // ----- ADD songg 2013/07/10 Redmine#38106 優良品番点付検索 ----- <<<<<
            //}
            //// ----- ADD licb 2013/07/10 Redmine#38120 純正品番点付検索 ----- <<<<<
            #endregion
            // DEL 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№376--------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2パラ目：部品情報
            PartsInfoDataSet partsInfoDB = null;

            // 3パラ目：商品連結データ
            List<GoodsUnitData> goodsUnitDataList = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<Rate> rateList = new List<Rate>();

            // 品番検索
            try
            {
                status = SearchPartsFromGoodsNo(
                    enterpriseCode,
                    sectionCode,
                    customerCode,
                    searchingCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out message,
                    out unitPriceCalcRetList,
                    out rateList);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "品番検索　status：" + status.ToString() + " " + message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errMsg = ex.ToString();
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

                return status;// ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応
            }

            // 検索なしの場合、またはエラーががある場合、ステータスを戻ります。
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応 ---->>>>>
                // 商品検索結果なしの場合、PMTABユーザー商品検索結果はSCM DBに登録処理
                try
                {
                    status = NotUrGoodsInfoPro(partsInfoDB, enterpriseCode, sectionCode,
                        goodsNo, blGoodsCode, businessSessionId, pmTabSearchGuid,
                        out message);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "部品データがありません。";
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.ToString();
                }
                //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応 ----<<<<<
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            #endregion 品番検索

            // ----- ADD songg 2013/07/10 Redmine#38106 優良品番点付検索 ----- >>>>>
            #region 結合元情報検索
            // 商品番号がドット（．）付の時、取得した品番検索より結合元検索を実行する
            //if (searchingCondition.PartsJoinCntDivCd == ".") // DEL huangt 2013/07/25 Redmine#39168 品番検索を行うと検索結果のユーザー商品検索結果の提供データ区分が必ず97になる
            // ----- ADD huangt 2013/07/25 Redmine#39168 品番検索を行うと検索結果のユーザー商品検索結果の提供データ区分が必ず97になる ----->>>>>
            // UPD 2013/08/05 TAKAGAWA Redmine#39600対応 ---------->>>>>>>>>>
            //if (!(string.IsNullOrEmpty(searchingCondition.GoodsNo)) && (searchingCondition.GoodsNo.Length > 1)
            //    && (searchingCondition.GoodsNo.LastIndexOf(".") == searchingCondition.GoodsNo.Length - 1))
            if (!(string.IsNullOrEmpty(searchingCondition.GoodsNo)) && (searchingCondition.GoodsNo.Length > 1))
            // UPD 2013/08/05 TAKAGAWA Redmine#39600対応 ----------<<<<<<<<<<
            // ----- ADD huangt 2013/07/25 Redmine#39168 品番検索を行うと検索結果のユーザー商品検索結果の提供データ区分が必ず97になる -----<<<<<
            {
                // DEL 2013/07/30 吉岡 結合元検索 判断 ----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //SearchPartsForSrcPartsProc(enterpriseCode, sectionCode,
                //    ref partsInfoDB, ref goodsUnitDataList);
                // DEL 2013/07/30 吉岡 結合元検索 判断 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2013/07/30 吉岡 結合元検索 判断 ----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 結合部品が無い場合に結合元検索を実施
                string gdscd = searchingCondition.GoodsNo.Trim();
                gdscd = gdscd.Remove(gdscd.Length - 1);
                string query = string.Format("{0}='{1}' ",
                                partsInfoDB.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, gdscd);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfoDB.UsrJoinParts.Select(query);
                if (rowGoodsJoin.Length == 0)
                {
                    // 結合元検索
                    // UPD 2013/08/05 TAKAGAWA Redmine#39600対応 ---------->>>>>>>>>>
                    //SearchPartsForSrcPartsProc(enterpriseCode, sectionCode,
                    //    ref partsInfoDB, ref goodsUnitDataList);
                    SearchPartsForSrcPartsProc(enterpriseCode, sectionCode,
                        ref partsInfoDB, ref goodsUnitDataList, searchingCondition.GoodsNo);
                    // UPD 2013/08/05 TAKAGAWA Redmine#39600対応 ---------->>>>>>>>>>
                }
                // ADD 2013/07/30 吉岡 結合元検索 判断 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            }
            #endregion 結合元情報検索
            // ----- ADD songg 2013/07/10 Redmine#38106 優良品番点付検索 ----- <<<<<

            // 保存用リスト初期化
            CustomSerializeArrayList pmtPartsSearchWorkList = new CustomSerializeArrayList();

            // 車両情報をUSER DBに書込む																							
            // PMTAB受注マスタ（車両）	
            // UPD 2013/08/01 yugami Redmine#39487 ------------------------------------------->>>>>
            //status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);

            if (!searchedCarResult.Equals(CarSearchResultReport.retFailed))
            {
                // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 ------------------->>>>>>>>>>>>>>>
                #region 旧ソース
                //// UPD 2013/12/12 SCM仕掛一覧№10609対応 ---------------------------------->>>>>
                ////status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
                //status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid, pmTabSalesDtCarWork);
                //// UPD 2013/12/12 SCM仕掛一覧№10609対応 ----------------------------------<<<<<
                #endregion
                status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
                // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 -------------------<<<<<<<<<<<<<<<
            }
            // 該当データなしの時はSCM-DB売上データ（車両情報）の内容を更新する
            else
            {
                status = WritePmTabAcpOdrCar(pmTabSalesDtCarWork, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            }
            // UPD 2013/08/01 yugami Redmine#39487 -------------------------------------------<<<<<
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "PMTAB受注マスタ（車両）登録処理　status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }

            //-----ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.43の対応 ---->>>>>
            // 車両情報をSCM DBに更新する
            // ADD 2013/08/01 yugami Redmine#39487 ------------------------------------------->>>>>
            // 車両検索結果が0件の時はSCM-DBに更新しない
            if (!searchedCarResult.Equals(CarSearchResultReport.retFailed))
            {
            // ADD 2013/08/01 yugami Redmine#39487 -------------------------------------------<<<<<
                status = WritePmTabSalDCar(searchedCarInfo, pmTabSalesDtCarWork, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            } // ADD 2013/08/01 yugami Redmine#39487 

             // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "商品検索結果なしの場合、PMTABユーザー商品検索結果のSCM DB登録処理　status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            //-----ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.43の対応 ----<<<<<

            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応 ---->>>>>
            //// 商品検索結果なしの場合、PMTABユーザー商品検索結果はSCM DBに登録処理
            //status = NotUrGoodsInfoPro(partsInfoDB, ref pmtPartsSearchWorkList,
            //    enterpriseCode, sectionCode, goodsNo, blGoodsCode,
            //    businessSessionId, pmTabSearchGuid, out message);
            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
            //    (status == (int)ConstantManagement.DB_Status.ctDB_ERROR))
            //{
            //    return status;
            //}
            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.42の対応 ----<<<<<

            // 商品連結データ不足情報設定
            this.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, sectionCode);

            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
            //// 単価計算
            //SetCalculator(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
            //    sectionCode, customerCode, out unitPriceCalcRetList, out rateList);
            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<

            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
            // 得意先掛率グループリスト
            List<CustRateGroup> custRateGroupList = new List<CustRateGroup>();
            // 単価計算
            SetCalculator(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
                sectionCode, customerCode, out unitPriceCalcRetList, out custRateGroupList, out rateList);
            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<

            // (17個テーブル)部品検索結果をSCM DBに書込む
            GetPartsInfoToScmDBDataList(partsInfoDB, 
                enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                ref pmtPartsSearchWorkList);

            // PMTAB掛率検索結果データ（一時）
            GetRateToScmDBDataList(rateList,
                enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList);

            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
            // 得意先マスタ（掛率グループ）マスタデータ登録
            GetCustRateGroupToScmDBDataList(custRateGroupList,
                enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList);
            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<


            // マスタデータ相関処理
            status = GetMastDataToScmDBDataList(enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList,
                goodsUnitDataList, out message,
                customerCode);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "マスタデータ相関処理　status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }

             // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            //return status;    // DEL huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 
        }

        // ----- ADD songg 2013/07/10 Redmine#38106 優良品番点付検索 ----- >>>>>
        /// <summary>
        /// 結合元検索処理
        /// ※MAHNB01001U MAHNB01012AB.cs の SearchPartsFromGoodsNo メソッド内にある	
        /// partsInfoDataSet.SearchPartsForSrcParts を参考に結合元検索を行います	
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">部品情報リスト</param>
        /// <param name="goodsNo">商品番号</param>  // ADD 2013/08/05 TAKAGAWA Redmine#39600対応
        // UPD 2013/08/05 TAKAGAWA Redmine#39600対応 ---------->>>>>>>>>>
        //private void SearchPartsForSrcPartsProc(string enterpriseCode, string sectionCode,
        //    ref PartsInfoDataSet partsInfoDB, ref List<GoodsUnitData> goodsUnitDataList)
        private void SearchPartsForSrcPartsProc(string enterpriseCode, string sectionCode,
            ref PartsInfoDataSet partsInfoDB, ref List<GoodsUnitData> goodsUnitDataList, string goodsNo)
        // UPD 2013/08/05 TAKAGAWA Redmine#39600対応 ----------<<<<<<<<<<
        {
            // 検索用結合先情報
            PartsInfoDataSet.UsrGoodsInfoDataTable usrGoodsInfoTable = partsInfoDB.UsrGoodsInfo;

            const string methodName = "SearchPartsForSrcPartsProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始 結合元検索");

            // 部品情報テーブル
            PartsInfoDataSet.UsrGoodsInfoDataTable tempUsrGoodsInfoDataTable = partsInfoDB.UsrGoodsInfo;
            // 部品価格情報テーブル
            PartsInfoDataSet.UsrGoodsPriceDataTable tempUsrGoodsPriceDataTable = partsInfoDB.UsrGoodsPrice;
            // 結合情報テーブル
            PartsInfoDataSet.UsrJoinPartsDataTable tempUsrJoinPartsDataTable = partsInfoDB.UsrJoinParts;

            Dictionary<string, GoodsUnitData> goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
            foreach (GoodsUnitData tempData in goodsUnitDataList)
            {
                string key = tempData.GoodsNo + ":" + tempData.GoodsMakerCd;
                if (!goodsUnitDataDic.ContainsKey(key))
                {
                    goodsUnitDataDic.Add(key, tempData);
                }
            }

            #region ★更新結合先の提供データ区分に格納処理★
            // 更新結合先の提供データ区分
            // ADD 2013/08/05 TAKAGAWA Redmine#39600対応 ---------->>>>>>>>>>
            if (goodsNo.LastIndexOf(".") == goodsNo.Length - 1)
            {
            // ADD 2013/08/05 TAKAGAWA Redmine#39600対応 ----------<<<<<<<<<<
                for (int i = 0; i < partsInfoDB.UsrGoodsInfo.Count; i++)
                {
                    partsInfoDB.UsrGoodsInfo[i].OfferDataDiv = 97;
                }
            // ADD 2013/08/05 TAKAGAWA Redmine#39600対応 ---------->>>>>>>>>>
            }
            // ADD 2013/08/05 TAKAGAWA Redmine#39600対応 ----------<<<<<<<<<<
            #endregion ★更新結合先の提供データ区分に格納処理★

            PartsInfoDataSet.UsrGoodsInfoRow[] usrGoodsInfoRows = usrGoodsInfoTable.Select() as PartsInfoDataSet.UsrGoodsInfoRow[];
            // 結合先ずつ、相関した結合元情報取得処理を行う
            for (int i = 0; i < usrGoodsInfoRows.Length; i++)
            {
                // 結合先情報取得
                PartsInfoDataSet.UsrGoodsInfoRow tempUsrGoodsInfo = usrGoodsInfoRows[i] as PartsInfoDataSet.UsrGoodsInfoRow;

                // 純正部品の結合情報検索しません。
                if (tempUsrGoodsInfo.GoodsMakerCd < 1000)
                {
                    continue;
                }

                // 結合元検索用検索情報設定
                GoodsCndtn cndtn = new GoodsCndtn();
                cndtn.EnterpriseCode = enterpriseCode;
                cndtn.SectionCode = sectionCode;
                cndtn.GoodsMakerCd = tempUsrGoodsInfo.GoodsMakerCd;
                cndtn.GoodsNo = tempUsrGoodsInfo.GoodsNo;
                cndtn.PartsJoinCntDivCd = ".";
                cndtn.IsSettingSupplier = 1;

                if (null == _goodsAcs)
                {
                    _goodsAcs = new GoodsAcs();
                }

                // 初期化検索結果クラス
                PartsInfoDataSet partsInfoDataSet; 
                List<GoodsUnitData> tempGoodsUnitDataList;
                string msg;

                // 結合元データ検索
                int status = _goodsAcs.SearchPartsForSrcParts(0, cndtn, out partsInfoDataSet, out tempGoodsUnitDataList, out msg);


                // ADD songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ---->>>>>
                // 商品価格情報設定
                if ((status == 0) && (partsInfoDataSet.UsrGoodsPrice.Count > 0))
                {
                    for (int j = 0; j < partsInfoDataSet.UsrGoodsPrice.Count; j++)
                    {
                        #region ★商品価格情報を格納★
                        PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPriceFrom = partsInfoDataSet.UsrGoodsPrice[j] as PartsInfoDataSet.UsrGoodsPriceRow;
                        PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPriceTo = tempUsrGoodsPriceDataTable.NewUsrGoodsPriceRow();

                        tempUsrGoodsPriceTo.CreateDateTime = tempUsrGoodsPriceFrom.CreateDateTime;
                        tempUsrGoodsPriceTo.EnterpriseCode = tempUsrGoodsPriceFrom.EnterpriseCode;
                        // 提供データの場合、tempUsrGoodsPriceFrom.FileHeaderGuidがDBNullの場合があるので、
                        // その際の例外は無視する
                        try
                        {
                            tempUsrGoodsPriceTo.FileHeaderGuid = tempUsrGoodsPriceFrom.FileHeaderGuid;
                        }
                        catch
                        {
                        }
                        tempUsrGoodsPriceTo.GoodsMakerCd = tempUsrGoodsPriceFrom.GoodsMakerCd;
                        tempUsrGoodsPriceTo.GoodsNo = tempUsrGoodsPriceFrom.GoodsNo;
                        tempUsrGoodsPriceTo.ListPrice = tempUsrGoodsPriceFrom.ListPrice;
                        tempUsrGoodsPriceTo.LogicalDeleteCode = tempUsrGoodsPriceFrom.LogicalDeleteCode;
                        tempUsrGoodsPriceTo.OfferDate = tempUsrGoodsPriceFrom.OfferDate;
                        tempUsrGoodsPriceTo.OpenPriceDiv = tempUsrGoodsPriceFrom.OpenPriceDiv;
                        tempUsrGoodsPriceTo.PriceStartDate = tempUsrGoodsPriceFrom.PriceStartDate;
                        tempUsrGoodsPriceTo.SalesUnitCost = tempUsrGoodsPriceFrom.SalesUnitCost;
                        tempUsrGoodsPriceTo.StockRate = tempUsrGoodsPriceFrom.StockRate;
                        tempUsrGoodsPriceTo.UpdAssemblyId1 = tempUsrGoodsPriceFrom.UpdAssemblyId1;
                        tempUsrGoodsPriceTo.UpdAssemblyId2 = tempUsrGoodsPriceFrom.UpdAssemblyId2;
                        tempUsrGoodsPriceTo.UpdateDate = tempUsrGoodsPriceFrom.UpdateDate;
                        tempUsrGoodsPriceTo.UpdateDateTime = tempUsrGoodsPriceFrom.UpdateDateTime;
                        tempUsrGoodsPriceTo.UpdEmployeeCode = tempUsrGoodsPriceFrom.UpdEmployeeCode;

                        // ☆検索した結合データの商品価格情報列新規☆
                        try
                        {
                            tempUsrGoodsPriceDataTable.AddUsrGoodsPriceRow(tempUsrGoodsPriceTo);
                        }
                        catch
                        {
                            continue;
                        }

                        #endregion ★商品価格情報を格納★
                    }
                }
                // ADD songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ----<<<<<

                #region ★GoodsUnitDataを格納処理★
                foreach (GoodsUnitData tempData in tempGoodsUnitDataList)
                {
                    // ADD songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ---->>>>>
                    // tempGoodsUnitDataListに定価のGoodsPriceListが格納されている品番を対象とする
                    if (tempUsrGoodsPriceDataTable.Select(string.Format("GoodsMakerCd = {0} and GoodsNo= '{1}'", tempData.GoodsMakerCd, tempData.GoodsNo)).Length == 0)
                    {
                        continue;
                    }
                    // ADD songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ----<<<<<

                    string key = tempData.GoodsNo + ":" + tempData.GoodsMakerCd;
                    //if ((tempData.CreateDateTime > DateTime.MinValue) && (!goodsUnitDataDic.ContainsKey(key)))// DEL songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加
                    if (!goodsUnitDataDic.ContainsKey(key))// ADD songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加
                    {
                        goodsUnitDataDic.Add(key, tempData);
                        goodsUnitDataList.Add(tempData);
                    }
                }
                #endregion ★GoodsUnitDataを格納処理★

                // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// ログ記録
                //EasyLogger.Write(CLASS_NAME, methodName, "結合元情報検索処理　status：" + status.ToString());
                // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 検索した結合元情報設定
                if ((status == 0) && (partsInfoDataSet.UsrGoodsInfo.Count > 0))
                {
                    for (int j = 0; j < partsInfoDataSet.UsrGoodsInfo.Count; j++)
                    {
                        
                        #region ★結合元を格納★
                        // ★検索した結合データの商品情報を設定する★
                        // 結合元情報取得
                        PartsInfoDataSet.UsrGoodsInfoRow tempUsrGoodsInfoFrom = partsInfoDataSet.UsrGoodsInfo[j] as PartsInfoDataSet.UsrGoodsInfoRow;
                        PartsInfoDataSet.UsrGoodsInfoRow tempUsrGoodsInfoTo = tempUsrGoodsInfoDataTable.NewUsrGoodsInfoRow();

                        // DEL songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ---->>>>>
                        //if (tempUsrGoodsInfoFrom.CreateDateTime == 0)
                        //{
                        //    continue;
                        //}
                        // DEL songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ----<<<<<
                        // ADD songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ---->>>>>
                        if (!goodsUnitDataDic.ContainsKey(tempUsrGoodsInfoFrom.GoodsNo + ":" + tempUsrGoodsInfoFrom.GoodsMakerCd))
                        {
                            continue;
                        }
                        // ADD songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ----<<<<<


                        tempUsrGoodsInfoTo.BlGoodsCode = tempUsrGoodsInfoFrom.BlGoodsCode;
                        tempUsrGoodsInfoTo.CalcPrice = tempUsrGoodsInfoFrom.CalcPrice;
                        tempUsrGoodsInfoTo.CreateDateTime = tempUsrGoodsInfoFrom.CreateDateTime;
                        tempUsrGoodsInfoTo.CustRateGrpCode = tempUsrGoodsInfoFrom.CustRateGrpCode;
                        tempUsrGoodsInfoTo.DisplayOrder = tempUsrGoodsInfoFrom.DisplayOrder;
                        tempUsrGoodsInfoTo.EnterpriseCode = tempUsrGoodsInfoFrom.EnterpriseCode;
                        tempUsrGoodsInfoTo.EnterpriseGanreCode = tempUsrGoodsInfoFrom.EnterpriseGanreCode;

                        // tempUsrGoodsInfoTo.FileHeaderGuid = tempUsrGoodsInfoFrom.FileHeaderGuid;// DEL songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加
                        // ADD songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ---->>>>>
                        try
                        {
                            // 提供データの場合、tempUsrGoodsPriceFrom.FileHeaderGuidがDBNullの場合があるので、
                            // その際の例外は無視する
                            tempUsrGoodsInfoTo.FileHeaderGuid = tempUsrGoodsInfoFrom.FileHeaderGuid;
                        }
                        catch
                        {

                        }
                        // ADD songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ----<<<<<
                        tempUsrGoodsInfoTo.FreSrchPrtPropNo = tempUsrGoodsInfoFrom.FreSrchPrtPropNo;
                        tempUsrGoodsInfoTo.GoodsKind = tempUsrGoodsInfoFrom.GoodsKind;
                        tempUsrGoodsInfoTo.GoodsKindCode = tempUsrGoodsInfoFrom.GoodsKindCode;
                        tempUsrGoodsInfoTo.GoodsKindResolved = tempUsrGoodsInfoFrom.GoodsKindResolved;
                        tempUsrGoodsInfoTo.GoodsMakerCd = tempUsrGoodsInfoFrom.GoodsMakerCd;
        
                        string key = tempUsrGoodsInfoFrom.GoodsNo + ":" + tempUsrGoodsInfoFrom.GoodsMakerCd;
                        if (goodsUnitDataDic.ContainsKey(key))
                        {
                            GoodsUnitData tempData = goodsUnitDataDic[key] as GoodsUnitData;
                            tempUsrGoodsInfoTo.GoodsMakerNm = tempData.MakerName;
                        }

                        tempUsrGoodsInfoTo.GoodsMGroup = tempUsrGoodsInfoFrom.GoodsMGroup;
                        tempUsrGoodsInfoTo.GoodsName = tempUsrGoodsInfoFrom.GoodsName;
                        tempUsrGoodsInfoTo.GoodsNameKana = tempUsrGoodsInfoFrom.GoodsNameKana;
                        tempUsrGoodsInfoTo.GoodsNo = tempUsrGoodsInfoFrom.GoodsNo;
                        tempUsrGoodsInfoTo.GoodsNoNoneHyphen = tempUsrGoodsInfoFrom.GoodsNoNoneHyphen;
                        tempUsrGoodsInfoTo.GoodsNote1 = tempUsrGoodsInfoFrom.GoodsNote1;
                        tempUsrGoodsInfoTo.GoodsNote2 = tempUsrGoodsInfoFrom.GoodsNote2;
                        tempUsrGoodsInfoTo.GoodsOfrName = tempUsrGoodsInfoFrom.GoodsOfrName;
                        tempUsrGoodsInfoTo.GoodsOfrNameKana = tempUsrGoodsInfoFrom.GoodsOfrNameKana;
                        tempUsrGoodsInfoTo.GoodsRateRank = tempUsrGoodsInfoFrom.GoodsRateRank;
                        tempUsrGoodsInfoTo.GoodsSpecialNote = tempUsrGoodsInfoFrom.GoodsSpecialNote;
                        tempUsrGoodsInfoTo.GoodsSpecialNoteOffer = tempUsrGoodsInfoFrom.GoodsSpecialNoteOffer;
                        tempUsrGoodsInfoTo.Jan = tempUsrGoodsInfoFrom.Jan;
                        tempUsrGoodsInfoTo.JoinSrcPrtsNo = tempUsrGoodsInfoFrom.JoinSrcPrtsNo;
                        tempUsrGoodsInfoTo.LogicalDeleteCode = tempUsrGoodsInfoFrom.LogicalDeleteCode;
                        tempUsrGoodsInfoTo.NewGoodsNo = tempUsrGoodsInfoFrom.NewGoodsNo;
                        tempUsrGoodsInfoTo.OfferDataDiv = 97;
                        tempUsrGoodsInfoTo.OfferDate = tempUsrGoodsInfoFrom.OfferDate;
                        tempUsrGoodsInfoTo.OfferKubun = tempUsrGoodsInfoFrom.OfferKubun;
                        tempUsrGoodsInfoTo.PartsPriceStDate = tempUsrGoodsInfoFrom.PartsPriceStDate;
                        tempUsrGoodsInfoTo.PriceSelectDiv = tempUsrGoodsInfoFrom.PriceSelectDiv;
                        tempUsrGoodsInfoTo.PriceTaxExc = tempUsrGoodsInfoFrom.PriceTaxExc;
                        tempUsrGoodsInfoTo.PriceTaxInc = tempUsrGoodsInfoFrom.PriceTaxInc;
                        tempUsrGoodsInfoTo.PrimeDisplayCode = tempUsrGoodsInfoFrom.PrimeDisplayCode;
                        tempUsrGoodsInfoTo.PrimeDispOrder = tempUsrGoodsInfoFrom.PrimeDispOrder;
                        tempUsrGoodsInfoTo.PrmSetDtlName2 = tempUsrGoodsInfoFrom.PrmSetDtlName2;
                        tempUsrGoodsInfoTo.PrtGoodsNo = tempUsrGoodsInfoFrom.PrtGoodsNo;
                        tempUsrGoodsInfoTo.PrtMakerCode = tempUsrGoodsInfoFrom.PrtMakerCode;
                        tempUsrGoodsInfoTo.PrtMakerName = tempUsrGoodsInfoFrom.PrtMakerName;
                        tempUsrGoodsInfoTo.QTY = tempUsrGoodsInfoFrom.QTY;
                        tempUsrGoodsInfoTo.RateDivLPrice = tempUsrGoodsInfoFrom.RateDivLPrice;
                        tempUsrGoodsInfoTo.RateDivSalUnPrc = tempUsrGoodsInfoFrom.RateDivSalUnPrc;
                        tempUsrGoodsInfoTo.RateDivUnCst = tempUsrGoodsInfoFrom.RateDivUnCst;
                        tempUsrGoodsInfoTo.SalesUnitPriceTaxExc = tempUsrGoodsInfoFrom.SalesUnitPriceTaxExc;
                        tempUsrGoodsInfoTo.SalesUnitPriceTaxInc = tempUsrGoodsInfoFrom.SalesUnitPriceTaxInc;
                        tempUsrGoodsInfoTo.SearchPartsFullName = tempUsrGoodsInfoFrom.SearchPartsFullName;
                        tempUsrGoodsInfoTo.SearchPartsHalfName = tempUsrGoodsInfoFrom.SearchPartsHalfName;
                        tempUsrGoodsInfoTo.SelectedGoodsNoDiv = tempUsrGoodsInfoFrom.SelectedGoodsNoDiv;
                        tempUsrGoodsInfoTo.SelectedListPrice = tempUsrGoodsInfoFrom.SelectedListPrice;
                        tempUsrGoodsInfoTo.SelectedListPriceDiv = tempUsrGoodsInfoFrom.SelectedListPriceDiv;
                        tempUsrGoodsInfoTo.SelectionComplete = tempUsrGoodsInfoFrom.SelectionComplete;
                        tempUsrGoodsInfoTo.SelectionState = tempUsrGoodsInfoFrom.SelectionState;
                        tempUsrGoodsInfoTo.SrchPNmAcqrCarMkrCd = tempUsrGoodsInfoFrom.SrchPNmAcqrCarMkrCd;
                        tempUsrGoodsInfoTo.TaxationDivCd = tempUsrGoodsInfoFrom.TaxationDivCd;
                        tempUsrGoodsInfoTo.UnitCostTaxExc = tempUsrGoodsInfoFrom.UnitCostTaxExc;
                        tempUsrGoodsInfoTo.UnitCostTaxInc = tempUsrGoodsInfoFrom.UnitCostTaxInc;
                        tempUsrGoodsInfoTo.UpdAssemblyId1 = tempUsrGoodsInfoFrom.UpdAssemblyId1;
                        tempUsrGoodsInfoTo.UpdAssemblyId2 = tempUsrGoodsInfoFrom.UpdAssemblyId2;
                        tempUsrGoodsInfoTo.UpdateDate = tempUsrGoodsInfoFrom.UpdateDate;
                        tempUsrGoodsInfoTo.UpdateDateTime = tempUsrGoodsInfoFrom.UpdateDateTime;
                        tempUsrGoodsInfoTo.UpdEmployeeCode = tempUsrGoodsInfoFrom.UpdEmployeeCode;

                        // ☆検索した結合データの商品情報列新規☆
                        if (tempUsrGoodsInfoDataTable.Select(string.Format("GoodsMakerCd = {0} and GoodsNo = '{1}'", tempUsrGoodsInfoTo.GoodsMakerCd, tempUsrGoodsInfoTo.GoodsNo)).Length == 0)
                        {
                            tempUsrGoodsInfoDataTable.AddUsrGoodsInfoRow(tempUsrGoodsInfoTo);
                        }
                        #endregion ★結合元を格納★

                        #region ★結合情報格納★
                        // ★結合情報を格納★
                        PartsInfoDataSet.UsrJoinPartsRow tempUsrJoinPartsRowTo = tempUsrJoinPartsDataTable.NewUsrJoinPartsRow();
                        tempUsrJoinPartsRowTo.JoinDestMakerCd =	tempUsrGoodsInfo.GoodsMakerCd; //結合先メーカーコード
                        tempUsrJoinPartsRowTo.JoinDestPartsNo =	tempUsrGoodsInfo.GoodsNo;//結合先品番(－付き品番)
                        tempUsrJoinPartsRowTo.JoinDispOrder = tempUsrGoodsInfo.DisplayOrder;//結合表示順位
                        tempUsrJoinPartsRowTo.JoinOfferDate = tempUsrGoodsInfo.OfferDate;//提供日
                        tempUsrJoinPartsRowTo.JoinQty =	tempUsrGoodsInfo.QTY;//結合QTY
                        tempUsrJoinPartsRowTo.JoinSourceMakerCode =	tempUsrGoodsInfoTo.GoodsMakerCd;//結合元メーカーコード
                        tempUsrJoinPartsRowTo.JoinSpecialNote =	tempUsrGoodsInfo.GoodsSpecialNote;//結合規格・特記事項
                        tempUsrJoinPartsRowTo.JoinSrcPartsNoNoneH = tempUsrGoodsInfoTo.GoodsNoNoneHyphen;//結合元品番(－無し品番)
                        tempUsrJoinPartsRowTo.JoinSrcPartsNoWithH =	tempUsrGoodsInfoTo.GoodsNo;//結合元品番(－付き品番)
                        tempUsrJoinPartsRowTo.PrimeDispOrder = tempUsrGoodsInfo.DisplayOrder;//表示順位
                        if(tempUsrGoodsInfo.GoodsMakerCd >= 1000)
                        {
                            tempUsrJoinPartsRowTo.PrmSettingFlg	=	true;//優良設定区分 // TODO
                        }
                        else
                        {
                            tempUsrJoinPartsRowTo.PrmSettingFlg = false;//優良設定区分 // TODO
                        }
                        tempUsrJoinPartsRowTo.SelectionState	=	false;

                        // ☆結合状態列新規☆
                        if (tempUsrJoinPartsDataTable.Select(string.Format("JoinDestMakerCd = {0} and JoinDestPartsNo = '{1}' and JoinSourceMakerCode = {2} and JoinSrcPartsNoWithH = '{3}'",
                            tempUsrGoodsInfo.GoodsMakerCd,
                            tempUsrGoodsInfo.GoodsNo,
                            tempUsrGoodsInfoTo.GoodsMakerCd,
                            tempUsrGoodsInfoTo.GoodsNo)).Length == 0)
                        {
                            tempUsrJoinPartsDataTable.AddUsrJoinPartsRow(tempUsrJoinPartsRowTo);
                        }
                        #endregion ★結合情報格納★
                    }
                }

                // DEL songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ---->>>>>
                // ★検索した結合データの商品価格情報を設定する★
                //if ((status == 0) && (partsInfoDataSet.UsrGoodsPrice.Count > 0))
                //{
                //    for (int j = 0; j < partsInfoDataSet.UsrGoodsPrice.Count; j++)
                //    {
                //        #region ★商品価格情報を格納★
                //        PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPriceFrom = partsInfoDataSet.UsrGoodsPrice[j] as PartsInfoDataSet.UsrGoodsPriceRow;
                //        PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPriceTo = tempUsrGoodsPriceDataTable.NewUsrGoodsPriceRow();

                //        tempUsrGoodsPriceTo.CreateDateTime = tempUsrGoodsPriceFrom.CreateDateTime;
                //        tempUsrGoodsPriceTo.EnterpriseCode = tempUsrGoodsPriceFrom.EnterpriseCode;
                //        // 提供データの場合、tempUsrGoodsPriceFrom.FileHeaderGuidがDBNullの場合があるので、
                //        // その際の例外は無視する
                //        try
                //        {
                //        tempUsrGoodsPriceTo.FileHeaderGuid = tempUsrGoodsPriceFrom.FileHeaderGuid;
                //        }
                //        catch
                //        {
                //        }
                //        tempUsrGoodsPriceTo.GoodsMakerCd = tempUsrGoodsPriceFrom.GoodsMakerCd;
                //        tempUsrGoodsPriceTo.GoodsNo = tempUsrGoodsPriceFrom.GoodsNo;
                //        tempUsrGoodsPriceTo.ListPrice = tempUsrGoodsPriceFrom.ListPrice;
                //        tempUsrGoodsPriceTo.LogicalDeleteCode = tempUsrGoodsPriceFrom.LogicalDeleteCode;
                //        tempUsrGoodsPriceTo.OfferDate = tempUsrGoodsPriceFrom.OfferDate;
                //        tempUsrGoodsPriceTo.OpenPriceDiv = tempUsrGoodsPriceFrom.OpenPriceDiv;
                //        tempUsrGoodsPriceTo.PriceStartDate = tempUsrGoodsPriceFrom.PriceStartDate;
                //        tempUsrGoodsPriceTo.SalesUnitCost = tempUsrGoodsPriceFrom.SalesUnitCost;
                //        tempUsrGoodsPriceTo.StockRate = tempUsrGoodsPriceFrom.StockRate;
                //        tempUsrGoodsPriceTo.UpdAssemblyId1 = tempUsrGoodsPriceFrom.UpdAssemblyId1;
                //        tempUsrGoodsPriceTo.UpdAssemblyId2 = tempUsrGoodsPriceFrom.UpdAssemblyId2;
                //        tempUsrGoodsPriceTo.UpdateDate = tempUsrGoodsPriceFrom.UpdateDate;
                //        tempUsrGoodsPriceTo.UpdateDateTime = tempUsrGoodsPriceFrom.UpdateDateTime;
                //        tempUsrGoodsPriceTo.UpdEmployeeCode = tempUsrGoodsPriceFrom.UpdEmployeeCode;

                //        // ☆検索した結合データの商品価格情報列新規☆
                //        try
                //        {
                //            tempUsrGoodsPriceDataTable.AddUsrGoodsPriceRow(tempUsrGoodsPriceTo);
                //        }
                //        catch
                //        {
                //            continue;
                //        }

                //        #endregion ★商品価格情報を格納★
                //    }
                //}
                // DEL songg 2013/07/18 Redmine38106の#13 格納されている結合元チェック処理追加 ----<<<<<
            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 結合元検索");
        }
        // ----- ADD songg 2013/07/10 Redmine#38106 優良品番点付検索 ----- <<<<<

        /// <summary>
        /// 品番検索アクセサを用いて品番検索を行います。
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.SearchPartsFromGoodsNo() 1445行目より移植</remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="searchingCondition">検索条件</param>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <param name="rateList">掛率リスト</param>
        /// <returns>結果コード</returns>
        protected int SearchPartsFromGoodsNo(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            GoodsCndtn searchingCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<Rate> rateList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchPartsFromGoodsNo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ResultUtil.ResultCode.Normal;

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            rateList = new List<Rate>();

            // UPD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
            //GoodsAcs _goodsAccesser = new GoodsAcs(sectionCode);
            //_goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);//-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応
            if (_goodsAccesser == null)
            {
                _goodsAccesser = new GoodsAcs(sectionCode);
                _goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);//-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応
            }
            // UPD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

            if (searchingCondition.GoodsMakerCd == 0)
            {
                status = _goodsAccesser.SearchPartsFromGoodsNo(
                    searchingCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out msg);
            }
            else
            {
                searchingCondition.PartsNoSearchDivCd = 0;
                searchingCondition.JoinSearchDiv = 0;
                searchingCondition.PartsJoinCntDivCd = ".";
                status = _goodsAccesser.SearchPartsFromGoodsNo(
                    searchingCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out msg);
            }

            if (!status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                // 検索されなかった場合、手動回答では
                // SCM受注明細データ(問合せ・発注)より売上データを作成するので、
                // 1件だけ検索されたことにする
                if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                {
                    goodsUnitDataList = new List<GoodsUnitData>();
                    goodsUnitDataList.Add(new GoodsUnitData());
                    //status = (int)ResultUtil.ResultCode.Normal;     // DEL huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 
                    status = (int)ResultUtil.ResultCode.NotFound;     // ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.44の対応 
                }
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 品番検索：status:" + status.ToString());
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            if (partsInfoDB != null)
            {
                // 品名表示区分
                //-----DEL songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
                //SalesTtlSt foundSalesTtlSt = SalesTtlStDB.Find(
                //    searchingCondition.EnterpriseCode,
                //    searchingCondition.SectionCode
                //);
                //-----DEL songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ----<<<<<
                //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
                SalesTtlSt foundSalesTtlSt = GetSalesTtlStInfo(
                    searchingCondition.EnterpriseCode,
                    searchingCondition.SectionCode);
                //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
                if (foundSalesTtlSt != null)
                {
                    partsInfoDB.SetPartsNameDisplayPattern(foundSalesTtlSt);
                    partsInfoDB.PriceSelectDispDiv = foundSalesTtlSt.PriceSelectDispDiv;
                    partsInfoDB.UnPrcNonSettingDiv = foundSalesTtlSt.UnPrcNonSettingDiv;
                }
            }
            

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }
        #endregion ★品番検索処理

        #region ★共通メソッド
        #region ◎ 車両検索処理
        /// <summary>
        /// 車両検索条件を生成します。
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="modelCode">車種コード</param>
        /// <param name="modelSubCode">車種サブコード</param>
        /// <param name="modelDesignationNo">型式指定番号</param>
        /// <param name="categoryNo">類別区分番号</param>
        /// <param name="fullModel">型式(フル型)</param>
        /// <param name="carInspectCertModel">車検証型式</param>
        /// <returns>車両検索条件</returns>
        private CarSearchCondition CreateSearchingCarCondition(int makerCode, int modelCode,
            int modelSubCode, int modelDesignationNo, int categoryNo, string fullModel, string carInspectCertModel)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "CreateSearchingCarCondition";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            CarSearchCondition consition = new CarSearchCondition();
            {
                consition.MakerCode = makerCode;          // メーカーコード
                consition.ModelCode = modelCode;          // 車種コード
                if (makerCode == 0)
                {
                    // メーカーコードが無効値（0）の場合は、車種サブコードに無効値（-1）を設定する
                    consition.ModelSubCode = -1;
                }
                else
                {
                    consition.ModelSubCode = modelSubCode;       // 車種サブコード
                }

                consition.ModelDesignationNo = modelDesignationNo; // 型式指定番号

                consition.CategoryNo = categoryNo;         // 類別区分番号

                if (consition.ModelDesignationNo.Equals(0) || consition.CategoryNo.Equals(0))
                {
                    consition.ModelDesignationNo = 0;                   // 型式指定番号
                    consition.CategoryNo = 0;                           // 類別区分番号

                    consition.CarModel.FullModel = string.IsNullOrEmpty(fullModel) ? carInspectCertModel : fullModel;// 型式(フル型)
                }

                //-----DEL songg 2013/06/20 仕様連絡 #37004の対応 型式からの車両検索を可能にする---->>>>>
                //// 車両検索タイプ（固定で１）
                //consition.Type = CarSearchType.csCategory;  // 類別検索
                //-----DEL songg 2013/06/20 仕様連絡 #37004の対応 型式からの車両検索を可能にする----<<<<<
                //-----ADD songg 2013/06/20 仕様連絡 #37004の対応 型式からの車両検索を可能にする---->>>>>
                // 車両検索タイプ(Type)
                // 類別区分番号・型式指定番号がある時、１：類別検索を設定
                if ((consition.ModelDesignationNo != 0) || (consition.ModelDesignationNo != 0))
                {
                    consition.Type = CarSearchType.csCategory;
                }
                // 類別区分番号・型式指定番号がなく型式（フル）がある時、２：型式選択を設定
                else if (!string.IsNullOrEmpty(consition.CarModel.FullModel))
                {
                    consition.Type = CarSearchType.csModel;
                }
                else
                {
                    consition.Type = CarSearchType.csCategory;
                }
                																										

                //-----ADD songg 2013/06/20 仕様連絡 #37004の対応 型式からの車両検索を可能にする----<<<<<
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return consition;
        }

        /// <summary>
        /// 車輌検索条件設定チェック処理
        /// </summary>
        /// <param name="searchingCarCondition">車輌検索条件</param>
        /// <returns>true: 設定あり, false: 未設定</returns>
        private bool CheckCarSearchCondition(CarSearchCondition searchingCarCondition)
        {
            return (searchingCarCondition.ModelDesignationNo != 0 ||                         
                    searchingCarCondition.CategoryNo != 0 ||                                 
                    searchingCarCondition.CarModel.FullModel != string.Empty ||               
                    searchingCarCondition.MakerCode != 0 ||                                   
                    searchingCarCondition.ModelCode != 0 ||                                   
                    searchingCarCondition.ModelSubCode != 0);                                 
        }

        /// <summary>
        /// 車両を検索します。
        /// </summary>
        /// <param name="searchingCarCondition">検索条件</param>
        /// <param name="searchedCarInfo">検索結果</param>
        /// <returns>処理ステータス</returns>
        private CarSearchResultReport SearchCar(
            CarSearchCondition searchingCarCondition,
            ref PMKEN01010E searchedCarInfo
        )
        {
            // CarSearchController　_carAccesser = new CarSearchController();//-----DEL songg 2013/06/27 障害報告 #37360の対応
            //-----ADD songg 2013/06/27 障害報告 #37360の対応 ---->>>>>
            if (null == _carAccesser)
            {
                _carAccesser = new CarSearchController();
            }
            //-----ADD songg 2013/06/27 障害報告 #37360の対応 ----<<<<<
            return _carAccesser.Search(searchingCarCondition, ref searchedCarInfo);
        }
        #endregion ◎ 車両検索処理

        #region ◎ 売上全体設定マスタ取得
        /// <summary>
        /// 売上全体設定マスタを取得します。
        /// </summary>
        protected static SalesTtlStAgentForTablet SalesTtlStDB
        {
            get { return SalesTtlStServer.Singleton.Instance; }
        }
        #endregion ◎ 売上全体設定マスタ取得

        #region ◎ 検索条件設定処理
        /// <summary>
        /// 品番検索条件を生成します。(品番がない場合、BLコードおよびBLコード枝番を指定します)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="blGoodsCode">ＢＬコード</param>
        /// <param name="searchedCarInfo">車両検索結果</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>品番検索条件</returns>
        // UPD 2013/07/31 吉岡 得意先管理拠点対応 ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region 旧ソース
        //protected GoodsCndtn CreateSearchingGoodsCondition(
        //    string enterpriseCode, string sectionCode, string goodsNo, int blGoodsCode,
        //    PMKEN01010E searchedCarInfo
        //)
        #endregion
        protected GoodsCndtn CreateSearchingGoodsCondition(
            string enterpriseCode, string sectionCode, string goodsNo, int blGoodsCode,
            PMKEN01010E searchedCarInfo, int customerCode
        )
        // UPD 2013/07/31 吉岡 得意先管理拠点対応 -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "CreateSearchingGoodsCondition";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            GoodsCndtn condition = new GoodsCndtn();
            {
                // 企業コード
                condition.EnterpriseCode = enterpriseCode;

                // 拠点コード
                // UPD 2013/08/01 吉岡 Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //// UPD 2013/07/31 吉岡 得意先管理拠点対応 ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// condition.SectionCode = sectionCode;
                //condition.SectionCode = this.CustomerInfo(enterpriseCode, customerCode).MngSectionCode.Trim();
                //// UPD 2013/07/31 吉岡 得意先管理拠点対応 -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                #endregion
                condition.SectionCode = this.CustomerInfo().MngSectionCode.Trim();
                // UPD 2013/08/01 吉岡 Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // 商品番号
                condition.GoodsNo = goodsNo;
                {
                    // 品番がない場合、BLコードおよびBLコード枝番を指定
                    if (string.IsNullOrEmpty(goodsNo.Trim()))
                    {
                        // BLコード
                        condition.BLGoodsCode = blGoodsCode;
                    }
                }

                // 売上全体設定を取得
                //-----DEL songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
                //SalesTtlSt salesTtlSt = SalesTtlStDB.Find(enterpriseCode, sectionCode);
                //-----DEL songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ----<<<<<
                //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
                SalesTtlSt salesTtlSt = GetSalesTtlStInfo(enterpriseCode, sectionCode);
                //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ----<<<<<
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

                // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№376-------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 品番検索区分…0:PM7(セットのみ), 1:結合・セット・代替あり エントリからの部品検索時のみ有効
                // condition.PartsNoSearchDivCd = 1;   // 自動は1 手動は引数あり
                condition.PartsNoSearchDivCd = 0;   // 売伝では固定で0をセット
                // UPD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№376--------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 元号表示区分1…0:西暦, 1:和暦(年式) エントリからの部品検索時のみ有効
                condition.EraNameDispCd1 = 0;

                // 価格適用日
                condition.PriceApplyDate = DateTime.Now;    // システム日付

                // 仕入先情報取得区分…0:設定あり, 設定なし
                condition.IsSettingSupplier = 0;

                // 結合検索区分…0:結合検索なし, 1:結合検索あり
                condition.JoinSearchDiv = 1;

                // 車両検索結果…BLコード検索時のみ使用
                // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 ------------------->>>>>>>>>>>>>>>
                // condition.SearchCarInfo = searchedCarInfo;
                condition.SearchCarInfo = (PMKEN01010E)searchedCarInfo.Copy();
                // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 -------------------<<<<<<<<<<<<<<<
                
                // ADD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 ------------------->>>>>>>>>>>>>>>
                // 商品検索の時は、車台番号の先頭0を削除
                // SearchCarByMultipleCarModelと同じ方法で数値に変換後、文字列化
                foreach(PMKEN01010E.CarModelUIRow row in condition.SearchCarInfo.CarModelUIData.Rows)
                {
                    if (row.FrameNo != null && !row.FrameNo.Equals(string.Empty))
                    {
                        row.FrameNo = TStrConv.StrToIntDef(row.FrameNo, 0).ToString();
                    }
                }
                // ADD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 -------------------<<<<<<<<<<<<<<<

                // ADD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№376-------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // 品番結合制御区分
                condition.PartsJoinCntDivCd = "." ;  
                // ADD 2013/07/22 吉岡 指摘・確認事項一覧_社内確認用№376--------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return condition;
        }

        /// <summary>
        /// 品番検索条件を編集します。
        /// </summary>
        /// <param name="searchingCondition">品番検索条件</param>
        /// <returns>編集した品番検索条件</returns>
        protected virtual GoodsCndtn EditSearchingGoodsCondition(GoodsCndtn searchingCondition)
        {
            return searchingCondition;
        }
        #endregion ◎ 検索条件設定処理

        #region ◎ 単価計算
        /// <summary>
        /// 価格算出系デリゲートを設定します。
        /// </summary>
        /// <param name="partsInfoDB">部品情報</param>
        /// <param name="goodsUnitDataList">商品連結情報リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <param name="custRateGroupList">得意先掛率グループリスト</param>
        /// <param name="rateList">掛率リスト</param>
        private void SetCalculator(PartsInfoDataSet partsInfoDB, ref List<GoodsUnitData> goodsUnitDataList, 
            string enterpriseCode, string sectionCode, int customerCode,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<CustRateGroup> custRateGroupList,//-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応
            out List<Rate> rateList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SetCalculator";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
            //// 単価算出処理
            //CalculateUnitPrice(partsInfoDB, ref goodsUnitDataList, enterpriseCode, 
            //    sectionCode, customerCode, out unitPriceCalcRetList, out rateList);
            //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<

            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
            // 単価算出処理
            CalculateUnitPrice(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
                sectionCode, customerCode, out unitPriceCalcRetList, out custRateGroupList, out rateList);
            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        }

        /// <summary>
        ///  得意先掛率グループコード取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先掛率グループ情報リスト</param>
        /// <param name="goodsMakerCode">商品メーカーコード</param>
        /// <returns>ステータス</returns>
        private int GetCustRateGroupCode(ref List<CustRateGroup> custRateGroupList, int goodsMakerCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GetCustRateGroupCode";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int pureCode = (goodsMakerCode <= ctPureGoodsMakerCode) ? 0 : 1; // 0:純正 1:優良

            // 単独キー
            CustRateGroup custRateGroup = custRateGroupList.Find(
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
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            // if (custRateGroup != null) return custRateGroup.CustRateGrpCode;
            if (custRateGroup != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return custRateGroup.CustRateGrpCode;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 共通キー
            custRateGroup = custRateGroupList.Find(
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
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            // if (custRateGroup != null) return custRateGroup.CustRateGrpCode;
            if (custRateGroup != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return custRateGroup.CustRateGrpCode;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 custRateGroup null");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return -1;
        }

        //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
        /// <summary>
        ///  得意先掛率グループ取得処理
        /// </summary>
        /// <param name="custRateGroupList">得意先掛率グループ情報リスト</param>
        /// <param name="goodsMakerCode">商品メーカーコード</param>
        /// <returns>ステータス</returns>
        private CustRateGroup GetCustRateGroup(ref List<CustRateGroup> custRateGroupList, int goodsMakerCode)
        {
            // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //const string methodName = "GetCustRateGroup";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<


            int pureCode = (goodsMakerCode <= ctPureGoodsMakerCode) ? 0 : 1; // 0:純正 1:優良

            // 単独キー
            CustRateGroup custRateGroup = custRateGroupList.Find(
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
            if (custRateGroup != null) return custRateGroup;

            // 共通キー
            custRateGroup = custRateGroupList.Find(
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

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //if (custRateGroup != null) return custRateGroup;
            if (custRateGroup != null)
            {
                // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                return custRateGroup;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 custRateGroup null");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return null;
        }
        //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<

        /// <summary>
        /// 税率設定情報を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>税率設定情報</returns>
        private static TaxRateSet GetTaxRateSet(string enterpriseCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GetTaxRateSet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // TaxRateSet taxRateSet = new TaxRateSet(); //-----DEL songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応
            TaxRateSet taxRateSet = null;                //-----ADD songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            {
                if (taxRateSet == null)
                {
                    int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);
                }

                if (taxRateSet == null)
                {
                    taxRateSet = new TaxRateSet();
                }
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return taxRateSet;
            }
        }


        /// <summary>
        /// 税率を取得します。
        /// </summary>
        /// <param name="taxRateSet">税率設定情報</param>
        /// <param name="targetDate">税率適用日</param>
        /// <returns>税率</returns>
        private static double GetTaxRate(
            TaxRateSet taxRateSet,
            DateTime targetDate
        )
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }

        /// <summary>
        /// 単価算出処理
        /// </summary>
        /// <param name="partsInfoDB">在庫情報</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="unitPriceCalcRetList">単価計算結果リスト</param>
        /// <param name="customRateGroupList">得意先掛率グループリスト</param>
        /// <param name="rateList">掛率リスト</param>
        private void CalculateUnitPrice(PartsInfoDataSet partsInfoDB, ref List<GoodsUnitData> goodsUnitDataList, 
            string enterpriseCode, string sectionCode, int customerCode,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<CustRateGroup> customRateGroupList,//-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応
            out List<Rate> rateList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "CalculateUnitPrice";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
            // 得意先掛率グループリスト
            customRateGroupList = new List<CustRateGroup>();

            // 得意先掛率グループキーリスト（key = 得意先コード：純正区分：商品メーカーコード）
            ArrayList customRateGroupKeyList = new ArrayList();
            //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

            // 得意先掛率グループ情報
            ArrayList custRateGroupList;
            List<CustRateGroup> _custRateGroupList = new List<CustRateGroup>();
            if (customerCode != 0)
            {
                CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
                custRateGroupAcs.Search(out custRateGroupList, enterpriseCode, customerCode, 
                    ConstantManagement.LogicalMode.GetData0);
                if ((custRateGroupList != null) && (custRateGroupList.Count != 0))
                {
                    _custRateGroupList = new List<CustRateGroup>(
                        (CustRateGroup[])custRateGroupList.ToArray(typeof(CustRateGroup)));
                }
            }

            // 売上単価端数処理コード(得意先マスタより取得)
            CustomerInfoAcs customerDB = new CustomerInfoAcs();
            SupplierAcs supplierDB = new SupplierAcs();
            //-----DEL songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応 ---->>>>>
            //int salesUnPrcFrcProcCd = customerDB.GetSalesFractionProcCd(
            //    enterpriseCode,
            //    customerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            //);


            //// 売上消費税端数処理コード(得意先マスタより取得)
            //int salesCnsTaxFrcProcCd = customerDB.GetSalesFractionProcCd(
            //    enterpriseCode,
            //    customerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            //);
            //-----DEL songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応 ----<<<<<
            //-----ADD songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応 ---->>>>>
            // 売上単価端数処理コード
            int salesUnPrcFrcProcCd = 0;

            // 売上消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = 0;

            if (customerCode != 0)
            {
                salesUnPrcFrcProcCd = customerDB.GetSalesFractionProcCd(
                    enterpriseCode,
                    customerCode,
                    CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
                    );


                // 売上消費税端数処理コード(得意先マスタより取得)
                salesCnsTaxFrcProcCd = customerDB.GetSalesFractionProcCd(
                    enterpriseCode,
                    customerCode,
                    CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
                    );
            }
            //-----ADD songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応 ---->>>>>

            // 仕入単価端数処理コードディクショナリ
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();

            // 仕入消費税端数処理コードディクショナリ
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();

            // 仕入単価端数処理コード
            int stockUnPrcFrcProcCd = 0;

            // 仕入消費税端数処理コード
            int stockCnsTaxFrcProcCd = 0;

            // 税率設定情報取得
            TaxRateSet taxRateSet = GetTaxRateSet(enterpriseCode);

            // 税率情報取得
            double taxRateOfNow = GetTaxRate(taxRateSet, DateTime.Now);


            // 得意先情報
            CustomerInfo customerInfo = new CustomerInfo();
            // customerDB.ReadDBData(enterpriseCode, customerCode, out customerInfo); //-----DEL songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応

            //-----ADD songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応 ---->>>>>
            CustomerInfo claimInfo = new CustomerInfo();
            if (customerCode != 0)
            {
                // 得意先情報取得
                customerDB.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                _mngSectionCode = customerInfo.MngSectionCode; // ADD huangt 2013/07/24 Redmine#39039 部品検索 使用する拠点コードの修正

                // 請求先情報取得
                if (customerCode == customerInfo.ClaimCode)
                {
                    claimInfo = customerInfo;
                }
                else
                {
                    customerDB.ReadDBData(enterpriseCode, customerInfo.ClaimCode, out claimInfo);
                }

            }
            //-----ADD songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応 ----<<<<<
            // ADD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "goodsUnitDataListループ処理　開始　件数：" + goodsUnitDataList.Count.ToString() + " ループ処理内呼出しメソッド：GetCustRateGroup");
            // ADD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            foreach (GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
            {
                UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                unitPriceCalcParam.BLGoodsCode           = tempGoodsUnitData.BLGoodsCode;    // BLコード検索結果.BLコード                 // BLコード    																																																																																															
                unitPriceCalcParam.BLGroupCode           = tempGoodsUnitData.BLGroupCode;    // BLコード検索結果.BLグループコード         // BLグループコード    																																																																																															
                unitPriceCalcParam.CountFl               = 0;                                // BLコード検索結果.数量                     // 数量    																																																																																															
                unitPriceCalcParam.CustomerCode          = customerCode;                     // WebSync.得意先コード                      // 得意先コード    																																																																																															
                //unitPriceCalcParam.CustRateGrpCode       = this.GetCustRateGroupCode(ref _custRateGroupList, tempGoodsUnitData.GoodsMakerCd);      //MAHNB01012AB.GetCustRateGroupCode(BLコード検索結果.メーカーコード)  // 得意先掛率グループコード //-----DEL songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応
                //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
                // 得意先掛率グループデータ取得
                CustRateGroup tempCustRateGroup = this.GetCustRateGroup(ref _custRateGroupList, tempGoodsUnitData.GoodsMakerCd);
                if (null == tempCustRateGroup)
                {
                    // 得意先掛率グループコード
                    unitPriceCalcParam.CustRateGrpCode = -1;      
                }
                else
                {
                    // 得意先掛率グループコード
                    unitPriceCalcParam.CustRateGrpCode = tempCustRateGroup.CustRateGrpCode;
                    // 得意先コード  :  純正区分 : 商品メーカーコード

                    string key = tempCustRateGroup.CustomerCode.ToString() + ":" + 
                        tempCustRateGroup.PureCode.ToString() + ":" + 
                        tempCustRateGroup.GoodsMakerCd.ToString();
                    if(!customRateGroupKeyList.Contains(key))
                    {
                        customRateGroupKeyList.Add(key);

                        // 該当得意先掛率グループデータ追加
                        customRateGroupList.Add(tempCustRateGroup);
                    }
                }

                //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<
                unitPriceCalcParam.GoodsMakerCd          = tempGoodsUnitData.GoodsMakerCd;   //BLコード検索結果.メーカーコード           // メーカーコード    																																																																																															
                unitPriceCalcParam.GoodsNo               = tempGoodsUnitData.GoodsNo;        //BLコード検索結果.品番                     // 品番    																																																																																															
                unitPriceCalcParam.GoodsRateGrpCode      = tempGoodsUnitData.GoodsRateGrpCode;//BLコード検索結果.商品掛率グループコード   // 商品掛率グループコード    																																																																																															
                unitPriceCalcParam.GoodsRateRank         = tempGoodsUnitData.GoodsRateRank;                    // BLコード検索結果.商品掛率ランク           // 商品掛率ランク    																																																																																															
                unitPriceCalcParam.PriceApplyDate        = DateTime.Today;                      //システム日付                            // 適用日    																																																																																															
                unitPriceCalcParam.SalesCnsTaxFrcProcCd  = salesCnsTaxFrcProcCd;                     // 売上消費税端数処理コード    																																																																																															
                unitPriceCalcParam.SalesUnPrcFrcProcCd   = salesUnPrcFrcProcCd;                      // 売上単価端数処理コード    																																																																																															
                //unitPriceCalcParam.SectionCode           = sectionCode;                              //WebSync.拠点コード                        // 拠点コード  //DEL 2013/07/18  wangl2 FOR #38511
                unitPriceCalcParam.SectionCode           = customerInfo.MngSectionCode;                         // 拠点コード  //ADD 2013/07/18  wangl2 FOR #38511
				
				if (stockCnsTaxFrcProcCdDic.ContainsKey(tempGoodsUnitData.SupplierCd))
                {
                    stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[tempGoodsUnitData.SupplierCd];   // 仕入消費税端数処理コード(ディクショナリか仕入先マスタから取得)
                }
                else
                {
                    stockCnsTaxFrcProcCd = supplierDB.GetStockFractionProcCd(
                        enterpriseCode,
                        tempGoodsUnitData.SupplierCd,
                        SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd
                    );
                    stockCnsTaxFrcProcCdDic.Add(tempGoodsUnitData.SupplierCd, stockCnsTaxFrcProcCd);
                }
                unitPriceCalcParam.StockCnsTaxFrcProcCd  = stockCnsTaxFrcProcCd;                     // 仕入消費税端数処理コード   
 																																																																																															
                if (stockUnPrcFrcProcCdDic.ContainsKey(tempGoodsUnitData.SupplierCd))
                {
                    stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[tempGoodsUnitData.SupplierCd];     // 仕入単価端数処理コード(ディクショナリか仕入先マスタから取得)
                }
                else
                {
                    stockUnPrcFrcProcCd = supplierDB.GetStockFractionProcCd(
                        enterpriseCode,
                        tempGoodsUnitData.SupplierCd,
                        SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd
                    );
                    stockUnPrcFrcProcCdDic.Add(tempGoodsUnitData.SupplierCd, stockUnPrcFrcProcCd);
                }
                unitPriceCalcParam.StockUnPrcFrcProcCd   = stockUnPrcFrcProcCd;                      // 仕入単価端数処理コード    
																																																																																															
                unitPriceCalcParam.SupplierCd            = tempGoodsUnitData.SupplierCd;                 // BLコード検索結果より                      // 仕入先コード    																																																																																															
                unitPriceCalcParam.TaxationDivCd         = tempGoodsUnitData.TaxationDivCd;              // BLコード検索結果より                      // 課税区分    																																																																																																																																																																																												
                unitPriceCalcParam.TaxRate               = taxRateOfNow;                   // 税率    																																																																																															
                unitPriceCalcParam.TotalAmountDispWayCd  = 0;// 固定                                     // 総額表示方法区分    																																																																																															
                unitPriceCalcParam.TtlAmntDspRateDivCd   = 0; //固定                                     // 総額表示掛率適用区分 0:(税込金額×掛率) 1:(税抜金額×掛率)から消費税を求め合算(消費税算出時消費税の端数処理が動作)    																																																																																															
                //unitPriceCalcParam.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod; //得意先情報.ConsTaxLayMethod               // 消費税転嫁方式    得意先情報は得意先コードより取得 //-----DEL songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応
                //-----ADD songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応 ---->>>>>
                // 消費税転嫁方式
                if(customerCode == 0)
                {
                    // 消費税設定の消費税転嫁方式
                    unitPriceCalcParam.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;
                }
                else
                {
                    // 請求先の消費税転嫁方式
                    unitPriceCalcParam.ConsTaxLayMethod = (claimInfo.CustCTaXLayRefCd == 0) ? taxRateSet.ConsTaxLayMethod : claimInfo.ConsTaxLayMethod;

                }
                //-----ADD songg 2013/06/19 ソースチェック確認事項一覧にNo.39の対応 ----<<<<<

                unitPriceCalcParamList.Add(unitPriceCalcParam);
            }
            // ADD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "goodsUnitDataListループ処理　終了");
            // ADD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 単価算出クラスを利用します。
            // DCKHN01060CA.CalculateSalesRelevanceUnitPriceを参照する
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            // ADD 2013/07/24 吉岡 Redmine#39055 --------------->>>>>>>>>>>>>>>>>>>>>>
            // すべて仕入金額処理区分情報取得
            string msg = string.Empty;
            int status = SearchInitial_StockProcMoneyProc(enterpriseCode, out msg, out allStockProcMoneyList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 仕入金額処理区分情報取得 status：" + status.ToString());
                allStockProcMoneyList = null;
            }
            List<StockProcMoney> stockProcMoneyList = null;
            if (allStockProcMoneyList != null)
            {
                stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])allStockProcMoneyList.ToArray(typeof(StockProcMoney)));
                unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
            }
            // ADD 2013/07/24 吉岡 Redmine#39055 ---------------<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2013/07/31 yugami Redmine#39386 ----------------------------->>>>>
            // 自社情報取得
            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CompanyInf companyInf;
            status = GetCompanyInf(out companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && companyInf != null)
            {
                unitPriceCalculation.RatePriorityDiv = companyInf.RatePriorityDiv;
            }
            // ADD 2013/07/31 yugami Redmine#39386 -----------------------------<<<<<
            
            unitPriceCalculation.CalculateSalesRelevanceUnitPriceForTablet(unitPriceCalcParamList, 
                goodsUnitDataList, out unitPriceCalcRetList, out rateList);


            // 単価計算してから、単価設定する
            SetUnitPriceInfo(ref partsInfoDB, unitPriceCalcRetList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        }

        /// <summary>
        /// 単価設定
        /// </summary>
        /// <param name="partsInfoDB">partsInfoDB</param>
        /// <param name="lstUnitPrice">単価リスト</param>
        private void SetUnitPriceInfo(ref PartsInfoDataSet partsInfoDB, List<UnitPriceCalcRet> lstUnitPrice)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SetUnitPriceInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int cnt = lstUnitPrice.Count;
            for (int i = 0; i < cnt; i++)
            {
                UnitPriceCalcRet unitPriceInfo = lstUnitPrice[i];
                PartsInfoDataSet.UsrGoodsInfoRow row = partsInfoDB.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(unitPriceInfo.GoodsMakerCd, unitPriceInfo.GoodsNo);
                if (row != null)
                {
                    switch (unitPriceInfo.UnitPriceKind)
                    {
                        case UnitPriceCalculation.ctUnitPriceKind_ListPrice: // 定価
                            row.PriceTaxExc = unitPriceInfo.UnitPriceTaxExcFl;
                            row.PriceTaxInc = unitPriceInfo.UnitPriceTaxIncFl; // 総額表示用
                            row.RateDivLPrice = unitPriceInfo.RateSettingDivide; // 掛率設定区分(定価) 

                            break;
                        case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice: // 売上単価
                            row.SalesUnitPriceTaxExc = unitPriceInfo.UnitPriceTaxExcFl;
                            row.SalesUnitPriceTaxInc = unitPriceInfo.UnitPriceTaxIncFl; // 総額表示用
                            row.RateDivSalUnPrc = unitPriceInfo.RateSettingDivide; // 掛率設定区分（売上単価） 
                            break;
                        case UnitPriceCalculation.ctUnitPriceKind_UnitCost: // 原価単価
                            row.UnitCostTaxExc = unitPriceInfo.UnitPriceTaxExcFl;
                            row.UnitCostTaxInc = unitPriceInfo.UnitPriceTaxIncFl; // 総額表示用
                            row.RateDivUnCst = unitPriceInfo.RateSettingDivide; // 掛率設定区分（原価単価）  
                            break;
                    }
                }
            }

            // 売価未設定時「定価を使用する」場合
            if (partsInfoDB.UnPrcNonSettingDiv == 1)
            {
                foreach (PartsInfoDataSet.UsrGoodsInfoRow row in partsInfoDB.UsrGoodsInfo)
                {
                    // 売価がセットされなかった場合
                    if (string.IsNullOrEmpty(row.RateDivSalUnPrc))
                    {
                        row.SalesUnitPriceTaxExc = row.PriceTaxExc; // 税抜き単価
                        row.SalesUnitPriceTaxInc = row.PriceTaxInc; // 税込み単価
                    }
                }
            }

            partsInfoDB.UsrGoodsInfo.AcceptChanges();
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        }
        #endregion ◎ 単価計算

        #region ◎ マスタ相関データ処理
        /// <summary>
        /// マスタ相関データ処理(仕入先マスタ、仕入金額処理区分マスタ、キャンペーン管理マスタ、BLグループマスタ)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="pmtPartsSearchWorkList">部品検索結果リスト</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>ステータス</returns>
        private int GetMastDataToScmDBDataList(string enterpriseCode, 
            string sectionCode, 
            string businessSessionId, 
            string pmTabSearchGuid, 
            ref CustomSerializeArrayList pmtPartsSearchWorkList, 
            List<GoodsUnitData> goodsUnitDataList, 
            out string message,
            int customerCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GetMastDataToScmDBDataList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 初期化処理
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            message = string.Empty;

            // データチェック
            if((null == goodsUnitDataList) || (goodsUnitDataList.Count == 0))
            {
                // UPD 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, "goodsUnitDataList null or Count=0");
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　goodsUnitDataList null or Count=0");
                // UPD 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            message = "";

            #region 仕入先データ処理
            // 仕入先データ処理
            List<PmtSupplierTmpWork> pmtSupplierTmpList = new List<PmtSupplierTmpWork>();
            // ADD 2013/08/05 Redmine#39451 ------------------------------>>>>>
            this._stockProcMoneyList = new List<StockProcMoney>();
            // ADD 2013/08/05 Redmine#39451 ------------------------------<<<<<
            status = SupplierMastDataOpr(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                out message, 
                goodsUnitDataList, 
                ref pmtSupplierTmpList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "仕入先マスタ データ作成処理 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) 
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }

            // 仕入先情報は全てリストに追加する
            pmtPartsSearchWorkList.Add(pmtSupplierTmpList);
            #endregion 仕入先データ処理

            #region 仕入金額処理区分マスタ処理
            List<PmtStkPrcMnyTmpWork> pmtStkPrcMnyTmpList = new List<PmtStkPrcMnyTmpWork>();
            // 仕入金額処理区分マスタ
            status = StockProcMoneyDataOpr(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid,
                out message, 
                ref pmtStkPrcMnyTmpList);
            
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "仕入金額処理区分マスタ データ作成処理 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }

            // 仕入金額処理区分マスタ情報は全てリストに追加する
            pmtPartsSearchWorkList.Add(pmtStkPrcMnyTmpList);
            #endregion 仕入金額処理区分マスタ処理

            #region キャンペーン処理
            List<PmtCmpMngTmpWork> pmtCmpMngTmpList = new List<PmtCmpMngTmpWork>();
            // キャンペーン処理
            status = CompaignMngMastDataOpr(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                out message, 
                goodsUnitDataList, 
                ref pmtCmpMngTmpList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "キャンペーンマスタ データ作成処理 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            pmtPartsSearchWorkList.Add(pmtCmpMngTmpList);
            #endregion キャンペーン処理

            #region BLグループデータ処理
            List<PmtBLGroupUTmpWork> pmtBLGroupUTmpList = new List<PmtBLGroupUTmpWork>();
            // BLグループデータ処理
            status = BLGroupMastDataOpr(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                out message, 
                goodsUnitDataList, 
                ref pmtBLGroupUTmpList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "BLグループマスタ データ作成処理 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            pmtPartsSearchWorkList.Add(pmtBLGroupUTmpList);
            #endregion BLグループデータ処理

            #region 標準価格選択設定マスタ処理
            List<PmtPriSelSetTmpWork> pmtPriSelSetDataList = new List<PmtPriSelSetTmpWork>();
            status = PmtPriSelSetDataOpr(enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                out message,
                goodsUnitDataList,
                ref pmtPriSelSetDataList,
                customerCode);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "標準価格選択設定マスタ データ作成処理 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }

            pmtPartsSearchWorkList.Add(pmtPriSelSetDataList);

            #endregion 標準価格選択設定マスタ処理

            //-----ADD licb 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>  
  
            #region 商品管理情報取得
            
            List<PmtGoodsMngTmpWork> pmtGoodsMngTmpList = new List<PmtGoodsMngTmpWork>();

            // UPD 2013/07/31 yugami Redmine#39451対応 ----------------------------------->>>>>
            //status = GetGoodsMngInfoProc(goodsUnitDataList,
            //    enterpriseCode,
            //    out pmtGoodsMngTmpList,
            //    out message,
            //    sectionCode,
            //    businessSessionId,
            //    pmTabSearchGuid);

            //保存商品管理情報
            status = WritePmtGoodsMngTmp(enterpriseCode,
                 sectionCode,
                 businessSessionId,
                 pmTabSearchGuid,
                 this._goodsMngList,
                 out pmtGoodsMngTmpList);
            // UPD 2013/07/31 yugami Redmine#39451対応 -----------------------------------<<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
             pmtPartsSearchWorkList.Add(pmtGoodsMngTmpList); 
            #endregion 商品管理情報取得

            //-----ADD licb 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<  

            // ----- ADD huangt 2013/07/12 Redmine#38116 キャンペーン売価優先設定マスタ追加 ----- >>>>>
            List<PmtCmpPrcPrStWork> pmtCmpPrcPrStList = new List<PmtCmpPrcPrStWork>();
            status = SetCampaignPrcPrSt(enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid, ref pmtCmpPrcPrStList);
            EasyLogger.Write(CLASS_NAME, methodName, "キャンペーン売価優先設定マスタ データ作成処理 status：" + status.ToString());
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return status;
            }
            pmtPartsSearchWorkList.Add(pmtCmpPrcPrStList);
            // ----- ADD huangt 2013/07/12 Redmine#38116 キャンペーン売価優先設定マスタ追加 ----- <<<<<

            // ----- ADD songg 2013/07/30 Redmine#39386 自社情報マスタ追加 ----- >>>>>
            List<PmtCompanyInfWork> pmtCompanyInfList = new List<PmtCompanyInfWork>();
            status = SetCompanyInf(enterpriseCode, businessSessionId, pmTabSearchGuid, ref pmtCompanyInfList);
            EasyLogger.Write(CLASS_NAME, methodName, "自社情報マスタ データ作成処理 status：" + status.ToString());
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return status;
            }
            pmtPartsSearchWorkList.Add(pmtCompanyInfList);
            // ----- ADD songg 2013/07/30 Redmine#39386 自社情報マスタ追加 ----- <<<<<

            // ★★★★★全てUSER DBのデータはSCM DBに保存処理を行います★★★
            IPmtPartsSearchDB iPmtPartsSearchDB = MediationPmtPartsSearchDB.GetPmtPartsSearchDB();
            object objList = pmtPartsSearchWorkList;
            status = iPmtPartsSearchDB.Write(ref objList);
            // UPD 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, "マスタデータ登録処理　status：" + status.ToString());
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            #endregion
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　マスタデータ登録処理　status：" + status.ToString());
            // UPD 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return status;

        }

        //-----ADD licb 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>    

        #region 商品管理情報取得

        // DEL 2013/07/31 Redmine#39451 ---------------------------------------------------->>>>>
        #region 速度改善のため削除
        /// <summary>
        /// 商品管理情報取得
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="pmtGoodsMngTmpList"> 商品管理リスト</param>
        /// <param name="message"></param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="sectionCode">拠点コード</param>
        //private int GetGoodsMngInfoProc(List<GoodsUnitData> goodsUnitDataList, string enterpriseCode, out List<PmtGoodsMngTmpWork> pmtGoodsMngTmpList, out string message,
        //    string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    const string methodName = "GetGoodsMngInfoProc";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    message = string.Empty;
        //    List<GoodsMngWork> goodsMngList = new List<GoodsMngWork>();
        //    pmtGoodsMngTmpList = new List<PmtGoodsMngTmpWork>();
        //    GoodsMngWork retGoodsMng = null;
        //    //商品管理情報取得用格納バッファ(VALUE:商品管理情報オブジェクト)
        //    Dictionary<string, GoodsMngWork> goodsMngDic1;      //拠点(全社共通含む)＋メーカー＋品番
        //    Dictionary<string, GoodsMngWork> goodsMngDic2;      //拠点(全社共通含む)＋中分類＋メーカー＋ＢＬ
        //    Dictionary<string, GoodsMngWork> goodsMngDic3;      //拠点(全社共通含む)＋中分類＋メーカー
        //    Dictionary<string, GoodsMngWork> goodsMngDic4;      //拠点(全社共通含む)＋メーカー
        //    Dictionary<string, GoodsMngWork> goodsMngDic = new Dictionary<string, GoodsMngWork>();
        //    string key = string.Empty;

        //    //全社指定拠点コード
        //    string ctAllDefSectionCode = "00";

        //    status = this.SearchMngGoodsInfo(enterpriseCode, out goodsMngDic1, out goodsMngDic2, out goodsMngDic3, out goodsMngDic4);
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        //        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        //        return status;
        //    }
        //    try
        //    {
        //        foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
        //        {
        //            //拠点＋メーカー
        //            StringBuilder goodsMngDic4key = new StringBuilder();
        //            goodsMngDic4key.Append(goodsUnitData.SectionCode.Trim().PadLeft(2, '0'));
        //            goodsMngDic4key.Append(goodsUnitData.GoodsMakerCd.ToString("0000"));
        //            //【拠点＋メーカー】＋品番
        //            StringBuilder goodsMngDic1key = new StringBuilder();
        //            goodsMngDic1key.Append(goodsMngDic4key.ToString());
        //            goodsMngDic1key.Append(goodsUnitData.GoodsNo.Trim());

        //            //1.拠点＋メーカー＋品番
        //            if (goodsMngDic1.ContainsKey(goodsMngDic1key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic1[goodsMngDic1key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                    + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;

        //            }

        //            //全社＋メーカー
        //            StringBuilder goodsMngDic8key = new StringBuilder();
        //            goodsMngDic8key.Append(ctAllDefSectionCode);
        //            goodsMngDic8key.Append(goodsUnitData.GoodsMakerCd.ToString("0000"));
        //            //【全社＋メーカー】＋品番
        //            StringBuilder goodsMngDic5key = new StringBuilder();
        //            goodsMngDic5key.Append(goodsMngDic8key.ToString());
        //            goodsMngDic5key.Append(goodsUnitData.GoodsNo.Trim());

        //            //2.全社＋メーカー＋品番
        //            if (goodsMngDic1.ContainsKey(goodsMngDic5key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic1[goodsMngDic5key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //【拠点＋メーカー】＋中分類
        //            StringBuilder goodsMngDic3key = new StringBuilder();
        //            goodsMngDic3key.Append(goodsMngDic4key.ToString());
        //            goodsMngDic3key.Append(goodsUnitData.GoodsMGroup.ToString("0000"));
        //            //【拠点＋メーカー＋中分類】＋ＢＬ
        //            StringBuilder goodsMngDic2key = new StringBuilder();
        //            goodsMngDic2key.Append(goodsMngDic3key.ToString());
        //            goodsMngDic2key.Append(goodsUnitData.BLGoodsCode.ToString("00000"));

        //            //3.拠点＋中分類＋メーカー＋ＢＬ
        //            if (goodsMngDic2.ContainsKey(goodsMngDic2key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic2[goodsMngDic2key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;

        //            }

        //            //【全社＋メーカー】＋中分類
        //            StringBuilder goodsMngDic7key = new StringBuilder();
        //            goodsMngDic7key.Append(goodsMngDic8key.ToString());
        //            goodsMngDic7key.Append(goodsUnitData.GoodsMGroup.ToString("0000"));
        //            //【全社＋メーカー＋中分類】＋ＢＬ
        //            StringBuilder goodsMngDic6key = new StringBuilder();
        //            goodsMngDic6key.Append(goodsMngDic7key.ToString());
        //            goodsMngDic6key.Append(goodsUnitData.BLGoodsCode.ToString("00000"));

        //            //4.全社＋中分類＋メーカー＋ＢＬ
        //            if (goodsMngDic2.ContainsKey(goodsMngDic6key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic2[goodsMngDic6key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //5.拠点＋中分類＋メーカー
        //            if (goodsMngDic3.ContainsKey(goodsMngDic3key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic3[goodsMngDic3key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //6.全社＋中分類＋メーカー
        //            if (goodsMngDic3.ContainsKey(goodsMngDic7key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic3[goodsMngDic7key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //7.拠点＋メーカー
        //            if (goodsMngDic4.ContainsKey(goodsMngDic4key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic4[goodsMngDic4key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //8.全社＋メーカー
        //            if (goodsMngDic4.ContainsKey(goodsMngDic8key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic4[goodsMngDic8key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;

        //            }

        //        }
        //        if (goodsMngDic != null && goodsMngDic.Count != 0)
        //        {

        //            foreach (GoodsMngWork goodsMng in goodsMngDic.Values)
        //            {
        //                goodsMngList.Add(goodsMng);

        //            }

        //            #region  保存キャンペーンデータ
        //            //保存商品管理情報
        //            status = WritePmtGoodsMngTmp(enterpriseCode, 
        //                 sectionCode,
        //                 businessSessionId,
        //                 pmTabSearchGuid,
        //                 goodsMngList,
        //                 out pmtGoodsMngTmpList);
        //            #endregion
        //        }
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        message = "商品管理情報取得で例外が発生しました[" + ex.Message + "]";
        //        message = ex.Message;

        //    }
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, "商品管理情報取得　status：" + status.ToString());
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        //    return status;

        //}

        #endregion // 速度改善のため削除
        // DEL 2013/07/31 Redmine#39451 ----------------------------------------------------<<<<<

        #region 商品管理情報保存処理
        /// <summary>
        /// 商品管理情報保存処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="goodsMngList">商品管理情報データ情報リスト</param>
        /// <param name="pmtGoodsMngTmpList">SCMDBの商品管理情報データ情報リスト</param>
        /// <returns>ステータス</returns>
        private int WritePmtGoodsMngTmp(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                List<GoodsMngWork> goodsMngList,
            out List<PmtGoodsMngTmpWork> pmtGoodsMngTmpList)
        {
            // 初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pmtGoodsMngTmpList = new List<PmtGoodsMngTmpWork>();

            for (int i = 0; i < goodsMngList.Count; i++)
            {
                GoodsMngWork goodsMng = goodsMngList[i] as GoodsMngWork;

                PmtGoodsMngTmpWork tempWork = new PmtGoodsMngTmpWork();

                tempWork.CreateDateTime = goodsMng.CreateDateTime;
                tempWork.UpdateDateTime = goodsMng.UpdateDateTime;
                tempWork.EnterpriseCode = goodsMng.EnterpriseCode;
                tempWork.FileHeaderGuid = goodsMng.FileHeaderGuid;
                tempWork.UpdEmployeeCode = goodsMng.UpdEmployeeCode;
                tempWork.UpdAssemblyId1 = goodsMng.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = goodsMng.UpdAssemblyId2;
                tempWork.LogicalDeleteCode = goodsMng.LogicalDeleteCode;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.SectionCode = goodsMng.SectionCode;
                tempWork.GoodsMGroup = goodsMng.GoodsMGroup;
                tempWork.GoodsMakerCd = goodsMng.GoodsMakerCd;
                tempWork.BLGoodsCode = goodsMng.BLGoodsCode;
                tempWork.GoodsNo = goodsMng.GoodsNo;
                tempWork.SupplierCd = goodsMng.SupplierCd;
                tempWork.SupplierLot = goodsMng.SupplierLot;

                pmtGoodsMngTmpList.Add(tempWork);
            }
            // ADD 2013/07/31 yugami Redmine#39451対応 ----------------------------------->>>>>
            if (pmtGoodsMngTmpList != null) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // ADD 2013/07/31 yugami Redmine#39451対応 -----------------------------------<<<<<
            return status;
        }
        #endregion 

        // DEL 2013/07/31 Redmine#39451 ---------------------------------------------------->>>>>
        #region 速度改善のため削除
        /// <summary>
        /// 商品管理情報の検索
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsMngDic1"></param>
        /// <param name="goodsMngDic2"></param>
        /// <param name="goodsMngDic3"></param>
        /// <param name="goodsMngDic4"></param>
        /// <remarks>
        /// <br>Note       : 商品管理情報の再検索</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/12/01</br>
        /// </remarks>
        //private int SearchMngGoodsInfo(string enterpriseCode, out Dictionary<string, GoodsMngWork> goodsMngDic1,
        //    out Dictionary<string, GoodsMngWork> goodsMngDic2, out Dictionary<string, GoodsMngWork> goodsMngDic3, out Dictionary<string, GoodsMngWork> goodsMngDic4)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    const string methodName = "SearchMngGoodsInfo";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    goodsMngDic1 = new Dictionary<string, GoodsMngWork>();
        //    goodsMngDic2 = new Dictionary<string, GoodsMngWork>();
        //    goodsMngDic3 = new Dictionary<string, GoodsMngWork>();
        //    goodsMngDic4 = new Dictionary<string, GoodsMngWork>();


        //    // 商品管理情報
        //    List<GoodsMngWork> goodsMngList = new List<GoodsMngWork>();
        //    // ユーザー登録分抽出条件
        //    GoodsUCndtnWork goodsUCndtnWork = new GoodsUCndtnWork();
        //    goodsUCndtnWork.EnterpriseCode = enterpriseCode;
        //    // 商品管理情報
        //    GoodsMngWork goodsMngWork = new GoodsMngWork();
        //    goodsMngWork.EnterpriseCode = enterpriseCode;
        //    CustomSerializeArrayList workList = new CustomSerializeArrayList();
        //    workList.Add(goodsMngWork);
        //    // オブジェクトへセット
        //    object retObj;
        //    retObj = workList;
        //    try
        //    {
        //        //商品構成リモートオブジェクト(ユーザー)格納バッファ
        //        IUsrJoinPartsSearchDB iGoodsURelationDataDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
        //        // 検索
        //        status = iGoodsURelationDataDB.Search(ref retObj, goodsUCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

        //        #region 商品管理情報
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        //            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        //            return status;
        //        }
        //        // 商品管理情報
        //        workList = retObj as CustomSerializeArrayList;

        //        if (workList == null)
        //        {
        //            return status;
        //        }
        //        if (workList[0] is ArrayList)
        //        {

        //            foreach (ArrayList arList in workList)
        //            {
        //                if (arList != null && arList.Count > 0)
        //                {
        //                    if (arList[0] is GoodsMngWork)
        //                    {
        //                        goodsMngList = new List<GoodsMngWork>((GoodsMngWork[])arList.ToArray(typeof(GoodsMngWork)));
        //                        goodsMngDic1 = new Dictionary<string, GoodsMngWork>();     //拠点＋メーカー＋品番
        //                        goodsMngDic2 = new Dictionary<string, GoodsMngWork>();     //拠点＋中分類＋メーカー＋ＢＬ
        //                        goodsMngDic3 = new Dictionary<string, GoodsMngWork>();     //拠点＋中分類＋メーカー
        //                        goodsMngDic4 = new Dictionary<string, GoodsMngWork>();     //拠点＋メーカー

        //                        for (int i = 0; i <= goodsMngList.Count - 1; i++)
        //                        {
        //                            goodsMngDic1Key = new StringBuilder();
        //                            goodsMngDic2Key = new StringBuilder();
        //                            goodsMngDic3Key = new StringBuilder();
        //                            goodsMngDic4Key = new StringBuilder();
        //                            goodsMngDic1Key.Length = 0;
        //                            goodsMngDic2Key.Length = 0;
        //                            goodsMngDic3Key.Length = 0;
        //                            goodsMngDic4Key.Length = 0;

        //                            goodsMngDic4Key.Append(goodsMngList[i].SectionCode.Trim().PadLeft(2, '0'));     //拠点
        //                            goodsMngDic4Key.Append(goodsMngList[i].GoodsMakerCd.ToString("0000"));         //メーカー

        //                            if (goodsMngList[i].GoodsNo.Trim() != string.Empty)
        //                            {
        //                                goodsMngDic1Key.Append(goodsMngDic4Key.ToString());                         //拠点＋メーカー
        //                                goodsMngDic1Key.Append(goodsMngList[i].GoodsNo.Trim());                    //品番

        //                                //拠点＋メーカー＋品番
        //                                if (!goodsMngDic1.ContainsKey(goodsMngDic1Key.ToString()))
        //                                {
        //                                    goodsMngDic1.Add(goodsMngDic1Key.ToString(), goodsMngList[i]);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                goodsMngDic3Key.Append(goodsMngDic4Key.ToString());                         //拠点＋メーカー
        //                                goodsMngDic3Key.Append(goodsMngList[i].GoodsMGroup.ToString("0000"));      //中分類

        //                                goodsMngDic2Key.Append(goodsMngDic3Key.ToString());                         //拠点＋メーカー＋中分類
        //                                goodsMngDic2Key.Append(goodsMngList[i].BLGoodsCode.ToString("00000"));     //ＢＬ

        //                                if (goodsMngList[i].BLGoodsCode != 0)
        //                                {
        //                                    //拠点＋中分類＋メーカー＋ＢＬ
        //                                    if (!goodsMngDic2.ContainsKey(goodsMngDic2Key.ToString()))
        //                                    {
        //                                        goodsMngDic2.Add(goodsMngDic2Key.ToString(), goodsMngList[i]);
        //                                    }
        //                                }
        //                                else if (goodsMngList[i].GoodsMGroup != 0)
        //                                {
        //                                    //拠点＋中分類＋メーカー
        //                                    if (!goodsMngDic3.ContainsKey(goodsMngDic3Key.ToString()))
        //                                    {
        //                                        goodsMngDic3.Add(goodsMngDic3Key.ToString(), goodsMngList[i]);
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    //拠点＋メーカー
        //                                    if (!goodsMngDic4.ContainsKey(goodsMngDic4Key.ToString()))
        //                                    {
        //                                        goodsMngDic4.Add(goodsMngDic4Key.ToString(), goodsMngList[i]);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        #endregion
        //    }
        //    catch
        //    {

        //    }
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, "商品管理情報検索　status：" + status.ToString());
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        //    return status;
        //}
        #endregion // 速度改善のため削除
        // DEL 2013/07/31 Redmine#39451 ----------------------------------------------------<<<<<

        #endregion

        //-----ADD licb 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<

        #region 標準価格選択設定マスタ処理
        /// <summary>
        /// 標準価格選択設定マスタ検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="goodsUnitDataList">商品連結情報リスト</param>
        /// <param name="pmtPriSelSetTmpList">標準価格選択設定マスタ情報リスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>ステータス</returns>
        private int PmtPriSelSetDataOpr(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                out string msg,
                List<GoodsUnitData> goodsUnitDataList,
                ref List<PmtPriSelSetTmpWork> pmtPriSelSetTmpList,
                int customerCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "PmtPriSelSetDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 初期化
            msg = "";

            // 商品連結データリストチェック処理
            if (null == goodsUnitDataList || goodsUnitDataList.Count == 0)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 goodsUnitDataList null or Count=0");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";

            // 標準価格選択設定マスタデータリスト
            ArrayList priSelSetTmpList = new ArrayList();

            // 情報リスト
            status = SearchInitial_PmtPriSelSetDataProc(enterpriseCode, sectionCode, customerCode, 
                goodsUnitDataList, out msg, out priSelSetTmpList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 保存標準価格選択設定マスタデータ
                WritePmtPriSelSetDataOpr(enterpriseCode,
                    sectionCode,
                    businessSessionId,
                    pmTabSearchGuid,
                    priSelSetTmpList,
                    ref pmtPriSelSetTmpList);
            }

            
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            return status;
        }

        private int WritePmtPriSelSetDataOpr(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                ArrayList priSelSetTmpList,
            ref List<PmtPriSelSetTmpWork> pmtPriSelSetTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WritePmtPriSelSetDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            for (int i = 0; i < priSelSetTmpList.Count; i++)
            {
                PriceSelectSet priceSelectSet = priSelSetTmpList[i] as PriceSelectSet;

                PmtPriSelSetTmpWork tempWork = new PmtPriSelSetTmpWork();

                tempWork.BLGoodsCode = priceSelectSet.BLGoodsCode;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = priceSelectSet.CreateDateTime;
                tempWork.CustomerCode = priceSelectSet.CustomerCode;
                tempWork.CustRateGrpCode = priceSelectSet.CustRateGrpCode;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.EnterpriseCode = priceSelectSet.EnterpriseCode;
                tempWork.FileHeaderGuid = priceSelectSet.FileHeaderGuid;
                tempWork.GoodsMakerCd = priceSelectSet.GoodsMakerCd;
                tempWork.LogicalDeleteCode = priceSelectSet.LogicalDeleteCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.PriceSelectDiv = priceSelectSet.PriceSelectDiv;
                tempWork.PriceSelectPtn = priceSelectSet.PriceSelectPtn;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.UpdAssemblyId1 = priceSelectSet.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = priceSelectSet.UpdAssemblyId2;
                tempWork.UpdateDateTime = priceSelectSet.UpdateDateTime;
                tempWork.UpdEmployeeCode = priceSelectSet.UpdEmployeeCode;



                pmtPriSelSetTmpList.Add(tempWork);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// 標準価格選択設定マスタ情報取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <param name="priSelSetList">標準価格選択設定マスタ情報リスト</param>
        /// <param name="goodsUnitDataList">商品連結情報リスト</param>
        /// <returns>ステータス</returns>
        private int SearchInitial_PmtPriSelSetDataProc(string enterpriseCode, string sectionCode,
            int customerCode,
            List<GoodsUnitData> goodsUnitDataList,
            out string msg, 
            out ArrayList priSelSetList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchInitial_PmtPriSelSetDataProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            priSelSetList = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";

            // DEL 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, "得意先マスタ　検索条件"
            //    + "　企業コード：" + enterpriseCode
            //    + "　得意先コード：" + customerCode.ToString()
            //);
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            #endregion
            // DEL 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // DEL 2013/07/31 吉岡 得意先管理拠点対応 ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region 取得した得意先情報を使用していなかったので、削除
            // 得意先情報取得
            //CustomerInfo customerInfo = new CustomerInfo();
            //CustomerInfoAcs customerDB = new CustomerInfoAcs();
            //customerDB.ReadDBData(enterpriseCode, customerCode, out customerInfo);
            #endregion
            // DEL 2013/07/31 吉岡 得意先管理拠点対応 -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "売上全体設定マスタ　検索条件"
                + "　企業コード：" + enterpriseCode
            );
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            // 表示区分プロセス≠1:する
            //-----DEL songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
            //SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();          // 売上全体設定マスタ
            //ArrayList allSalesTtlStList = new ArrayList();
            //salesTtlStAcs.Search(out allSalesTtlStList, enterpriseCode);
            //SalesTtlSt onlySalesTtlSt = null;
            //foreach(SalesTtlSt tempSalesTtlSt in allSalesTtlStList)
            //{
            //    if (tempSalesTtlSt.SectionCode.Trim() == sectionCode.Trim())
            //    {
            //        onlySalesTtlSt = tempSalesTtlSt;
            //        break;
            //    }
            //}
            //-----DEL songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ----<<<<<
            //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
            SalesTtlSt onlySalesTtlSt = GetSalesTtlStInfo(enterpriseCode, sectionCode);
            //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ----<<<<<
            if ((onlySalesTtlSt == null) || (1 != onlySalesTtlSt.PriceSelectDispDiv))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 SalesTtlSt null or SalesTtlSt.PriceSelectDispDiv≠1");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "得意先掛率グループマスタ　検索条件"
                + "　企業コード：" + enterpriseCode
                + "　得意先コード：" + customerCode.ToString()
            );
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            // 得意先掛率グループ取得
            ArrayList custRategrouList = new ArrayList();
            CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
            custRateGroupAcs.Search(out custRategrouList, enterpriseCode,customerCode, ConstantManagement.LogicalMode.GetData0);

            try
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "標準価格選択設定マスタ　検索条件"
                    + "　企業コード：" + enterpriseCode
                );
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                PriceSelectSetAcs priceSelectSetAcs = new PriceSelectSetAcs();
                // 全てデータ取得
                ArrayList allPriSelSetList = new ArrayList();
                status = priceSelectSetAcs.Search(out allPriSelSetList, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (ArrayList)allPriSelSetList != null)
                {
                    //0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                    List<string> keyList0 = new List<string>();
                    //1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ
                    List<string> keyList1 = new List<string>();
                    //2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                    List<string> keyList2 = new List<string>();
                    //3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    List<string> keyList3 = new List<string>();
                    //4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    List<string> keyList4 = new List<string>();
                    //5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                    List<string> keyList5 = new List<string>();
                    //6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ
                    List<string> keyList6 = new List<string>();
                    //7:ﾒｰｶｰｺｰﾄﾞ
                    List<string> keyList7 = new List<string>();
                    //8:BLｺｰﾄﾞ
                    List<string> keyList8 = new List<string>();


                    foreach (GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
                    {
                        // 純正品（メーカーコード < 1000）の場合、標準価格選択設定マスタは必要なし
                        if (tempGoodsUnitData.GoodsMakerCd < 1000)
                        {
                            continue;
                        }

                        //0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        string key0 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                            + tempGoodsUnitData.BLGoodsCode.ToString() + ":"
                            + customerCode.ToString();
                        if (!keyList0.Contains(key0))
                        {
                            keyList0.Add(key0);
                        }

                        //1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        string key1 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                            + customerCode.ToString();
                        if (!keyList1.Contains(key1))
                        {
                            keyList1.Add(key1);
                        }

                        //2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        string key2 = tempGoodsUnitData.BLGoodsCode.ToString() + ":"
                            + customerCode.ToString();
                        if (!keyList2.Contains(key2))
                        {
                            keyList2.Add(key2);
                        }

                        foreach(CustRateGroup tempCustRateGroup in custRategrouList)
                        {
                            //3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                            string key3 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                                + tempGoodsUnitData.BLGoodsCode.ToString() + ":"
                                + tempCustRateGroup.CustRateGrpCode.ToString();

                            if (!keyList3.Contains(key3))
                            {
                                keyList3.Add(key3);
                            }

                            //4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                            string key4 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                                 + tempCustRateGroup.CustRateGrpCode.ToString();
                            if (!keyList4.Contains(key4))
                            {
                                keyList4.Add(key4);
                            }

                            //5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                            string key5 = tempGoodsUnitData.BLGoodsCode.ToString() + ":"
                                + tempCustRateGroup.CustRateGrpCode.ToString();
                            if (!keyList5.Contains(key5))
                            {
                                keyList5.Add(key5);
                            }
                        }
                            
                        
                        //6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ
                        string key6 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                            + tempGoodsUnitData.BLGoodsCode.ToString();
                        if (!keyList6.Contains(key6))
                        {
                            keyList6.Add(key6);
                        }

                        //7:ﾒｰｶｰｺｰﾄﾞ
                        string key7 = tempGoodsUnitData.GoodsMakerCd.ToString();
                        if (!keyList7.Contains(key7))
                        {
                            keyList7.Add(key7);
                        }

                        //8:BLｺｰﾄﾞ
                        string key8 = tempGoodsUnitData.BLGoodsCode.ToString();
                        if (!keyList8.Contains(key8))
                        {
                            keyList8.Add(key8);
                        }
                    }

                    foreach (PriceSelectSet tempPriceSelectSet in allPriSelSetList)
                    {
                        //0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        string key0 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                            + tempPriceSelectSet.BLGoodsCode.ToString() + ":"
                            + tempPriceSelectSet.CustomerCode.ToString();


                        //1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        string key1 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                            + tempPriceSelectSet.CustomerCode.ToString();


                        //2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                        string key2 = tempPriceSelectSet.BLGoodsCode.ToString() + ":"
                            + tempPriceSelectSet.CustomerCode.ToString();


                        //3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                        string key3 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                            + tempPriceSelectSet.BLGoodsCode.ToString() + ":"
                            + tempPriceSelectSet.CustRateGrpCode.ToString();


                        //4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                        string key4 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                             + tempPriceSelectSet.CustRateGrpCode.ToString();


                        //5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ
                        string key5 = tempPriceSelectSet.BLGoodsCode.ToString() + ":"
                            + tempPriceSelectSet.CustRateGrpCode.ToString();


                        //6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ
                        string key6 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                            + tempPriceSelectSet.BLGoodsCode.ToString();

                        //7:ﾒｰｶｰｺｰﾄﾞ
                        string key7 = tempPriceSelectSet.GoodsMakerCd.ToString();


                        //8:BLｺｰﾄﾞ
                        string key8 = tempPriceSelectSet.BLGoodsCode.ToString();


                        switch (tempPriceSelectSet.PriceSelectPtn)
                        {
                            case 0:
                                if (keyList0.Contains(key0))
                                {
                                    // 値をセット
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 1:
                                if (keyList1.Contains(key1))
                                {
                                    // 値をセット
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 2:
                                if (keyList2.Contains(key2))
                                {
                                    // 値をセット
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 3:
                                if (keyList3.Contains(key3))
                                {
                                    // 値をセット
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 4:
                                if (keyList4.Contains(key4))
                                {
                                    // 値をセット
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 5:
                                if (keyList5.Contains(key5))
                                {
                                    // 値をセット
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 6:
                                if (keyList6.Contains(key6))
                                {
                                    // 値をセット
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 7:
                                if (keyList7.Contains(key7))
                                {
                                    // 値をセット
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 8:
                                if (keyList8.Contains(key8))
                                {
                                    // 値をセット
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = "標準価格選択設定マスタ情報取得で例外が発生しました[" + ex.Message + "]";
                msg = ex.Message;

                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, msg);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }

            if ((priSelSetList != null) && (priSelSetList.Count > 0))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            return status;
        }
        #endregion 標準価格選択設定マスタ処理

        #region キャンペーン処理
        /// <summary>
        /// キャンペーンデータ作成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="goodsUnitDataList">商品連結情報データリスト</param>
        /// <param name="pmtCmpMngTmpList">キャンペーン管理データリスト</param>
        /// <returns>ステータス</returns>
        private int CompaignMngMastDataOpr(string enterpriseCode, 
                string sectionCode, 
                string businessSessionId,
                string pmTabSearchGuid, 
                out string msg, 
            List<GoodsUnitData> goodsUnitDataList, 
            ref List<PmtCmpMngTmpWork> pmtCmpMngTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "CompaignMngMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // UPD 2013/08/02 Redmine#39451 速度改善9 --------------------------------------------------->>>>>
            //List<CampaignObjGoodsStWork> campaignMngList = new List<CampaignObjGoodsStWork>();
            List<CampaignObjGoodsStWork> campaignMngList;
            // UPD 2013/08/02 Redmine#39451 速度改善9 ---------------------------------------------------<<<<<

            // 検索キャンペーンデータ
            status = SearchInitial_CompaignMngMastDataProc(enterpriseCode, sectionCode, out msg, goodsUnitDataList, out campaignMngList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 保存キャンペーンデータ
                WriteCompaignMngMastDataOpr(enterpriseCode, 
                    sectionCode, 
                    businessSessionId,
                    pmTabSearchGuid, 
                    campaignMngList, 
                    ref pmtCmpMngTmpList);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// キャンペーンデータ保存処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="campaignMngList">キャンペーンデータ情報リスト</param>
        /// <param name="pmtCmpMngTmpList">USER DBのキャンペーンデータリスト</param>
        /// <returns>ステータス</returns>
        private int WriteCompaignMngMastDataOpr(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid, 
                List<CampaignObjGoodsStWork> campaignMngList, 
            ref List<PmtCmpMngTmpWork> pmtCmpMngTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteCompaignMngMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 初期化
            //int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;       // DEL huangt 2013/06/24 障害報告 #37128の対応 自動回答処理(検索) ソースを修正して下さい
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;        // ADD huangt 2013/06/24 障害報告 #37128の対応 自動回答処理(検索) ソースを修正して下さい

            for (int i = 0; i < campaignMngList.Count; i++)
            {
                CampaignObjGoodsStWork campaignMng = campaignMngList[i] as CampaignObjGoodsStWork;

                PmtCmpMngTmpWork tempWork = new PmtCmpMngTmpWork();

                tempWork.BLGoodsCode = campaignMng.BLGoodsCode;
                tempWork.BLGroupCode = campaignMng.BLGroupCode;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CampaignCode = campaignMng.CampaignCode;
                tempWork.CampaignSettingKind = campaignMng.CampaignSettingKind; 
                tempWork.CreateDateTime = campaignMng.CreateDateTime;
                tempWork.CustomerCode = campaignMng.CustomerCode;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", "")); //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DiscountRate = campaignMng.DiscountRate;               
                tempWork.EnterpriseCode = campaignMng.EnterpriseCode;
                tempWork.FileHeaderGuid = campaignMng.FileHeaderGuid;
                tempWork.GoodsMakerCd = campaignMng.GoodsMakerCd;
                tempWork.GoodsMGroup = campaignMng.GoodsMGroup;
                tempWork.GoodsNo = campaignMng.GoodsNo;
                tempWork.LogicalDeleteCode = campaignMng.LogicalDeleteCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.PriceEndDate = GetDate(campaignMng.PriceEndDate);
                tempWork.PriceFl = campaignMng.PriceFl;
                tempWork.PriceStartDate = GetDate(campaignMng.PriceStartDate); 
                tempWork.RateVal = campaignMng.RateVal;
                tempWork.SalesCode = campaignMng.SalesCode; 
                tempWork.SalesPriceSetDiv = campaignMng.SalesPriceSetDiv;
                tempWork.SalesTargetCount = campaignMng.SalesTargetCount;
                tempWork.SalesTargetMoney = campaignMng.SalesTargetMoney;
                tempWork.SalesTargetProfit = campaignMng.SalesTargetProfit;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.SectionCode = campaignMng.SectionCode;
                tempWork.UpdAssemblyId1 = campaignMng.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = campaignMng.UpdAssemblyId2;
                tempWork.UpdateDateTime = campaignMng.UpdateDateTime;
                tempWork.UpdEmployeeCode = campaignMng.UpdEmployeeCode;


                pmtCmpMngTmpList.Add(tempWork);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// キャンペーンデータ検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="campaignMngList">キャンペーン情報リスト</param>
        /// <returns>ステータス</returns>
        private int SearchInitial_CompaignMngMastDataProc(string enterpriseCode, string sectionCode, out string msg, List<GoodsUnitData> goodsUnitDataList, out  List<CampaignObjGoodsStWork> campaignMngList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchInitial_CompaignMngMastDataProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";

            // キャンペーン検索条件設定
            CampaignMngOrderWork paraWork = SetCompaignCond(enterpriseCode, sectionCode, goodsUnitDataList);


            ICampaignObjGoodsStDB iCampaignObjGoodsStDB = (ICampaignObjGoodsStDB)MediationCampaignObjGoodsStDB.GetCampaignObjGoodsStDB();

            // リモート戻りリスト
            object campaignMngWorkList = null;

            // キャンペーン管理マスタ検索
            status = iCampaignObjGoodsStDB.Search(out campaignMngWorkList, paraWork.EnterpriseCode, 0, ConstantManagement.LogicalMode.GetData0, ref msg);

            // 結果格納
            campaignMngList = new List<CampaignObjGoodsStWork>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (ArrayList)campaignMngWorkList != null)
            {
                List<string> keyList1 = new List<string>();// 1：ﾒｰｶｰ+品番
                List<string> keyList2 = new List<string>();// 2：ﾒｰｶｰ+BLｺｰﾄﾞ
                List<string> keyList3 = new List<string>();// 3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                List<string> keyList4 = new List<string>();// 4：ﾒｰｶｰ
                List<string> keyList5 = new List<string>();// 5：BLｺｰﾄﾞ
                // DEL 2013/07/26 吉岡 Redmine#39203 販売区分は画面から変更可能なので、全件登録する----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // List<string> keyList6 = new List<string>();// 6：販売区分
                // DEL 2013/07/26 吉岡 Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                foreach(GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
                {
                    // 1：ﾒｰｶｰ+品番
                    string key1 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":" + tempGoodsUnitData.GoodsNo.Trim();
                    if (!keyList1.Contains(key1))
                    {
                        keyList1.Add(key1);
                    }

                    // 2：ﾒｰｶｰ+BLｺｰﾄﾞ
                    string key2 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":" + tempGoodsUnitData.BLGoodsCode.ToString();
                    if(!keyList2.Contains(key2))
                    {
                        keyList2.Add(key2);
                    }

                    // 3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                    string key3 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":" + tempGoodsUnitData.BLGroupCode.ToString();
                    if (!keyList3.Contains(key3))
                    {
                        keyList3.Add(key3);
                    }

                    // 4：ﾒｰｶｰ
                    string key4 = tempGoodsUnitData.GoodsMakerCd.ToString();
                    if (!keyList4.Contains(key4))
                    {
                        keyList4.Add(key4);
                    }

                    // 5：BLｺｰﾄﾞ
                    string key5 = tempGoodsUnitData.BLGoodsCode.ToString();
                    if (!keyList5.Contains(key5))
                    {
                        keyList5.Add(key5);
                    }

                    // DEL 2013/07/26 吉岡 Redmine#39203 販売区分は画面から変更可能なので、全件登録する----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    #region 旧ソース
                    //// 6：販売区分
                    //string key6 = tempGoodsUnitData.SalesCode.ToString();
                    //if (!keyList6.Contains(key6))
                    //{
                    //    keyList6.Add(key6);
                    //}
                    #endregion
                    // DEL 2013/07/26 吉岡 Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                foreach (object obj in (ArrayList)campaignMngWorkList)
                {
                    if (obj is CampaignObjGoodsStWork)
                    {
                        CampaignObjGoodsStWork retWork = (obj as CampaignObjGoodsStWork);

                        // ADD 2013/07/26 吉岡 Redmine#39203 販売区分は画面から変更可能なので、全件登録する----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        // 自拠点、又は全社以外は対象外
                        if (!(retWork.SectionCode.Trim().Equals(sectionCode.Trim()) || retWork.SectionCode.Trim().Equals("00"))) continue;
                        // ADD 2013/07/26 吉岡 Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        // 1：ﾒｰｶｰ+品番
                        string key1 = retWork.GoodsMakerCd.ToString() + ":" + retWork.GoodsNo.Trim();
                        // 2：ﾒｰｶｰ+BLｺｰﾄﾞ
                        string key2 = retWork.GoodsMakerCd.ToString() + ":" + retWork.BLGoodsCode.ToString();
                        // 3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                        string key3 = retWork.GoodsMakerCd.ToString() + ":" + retWork.BLGroupCode.ToString();
                        // 4：ﾒｰｶｰ
                        string key4 = retWork.GoodsMakerCd.ToString();
                        // 5：BLｺｰﾄﾞ
                        string key5 = retWork.BLGoodsCode.ToString();
                        // DEL 2013/07/26 吉岡 Redmine#39203 販売区分は画面から変更可能なので、全件登録する----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //// 6：販売区分
                        // string key6 = retWork.SalesCode.ToString();
                        // DEL 2013/07/26 吉岡 Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        // キャンペーン設定種別:1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分
                        switch(retWork.CampaignSettingKind)
                        {
                            case 1:
                                if (keyList1.Contains(key1))
                                {
                                    // 値をセット
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            case 2:
                                if (keyList2.Contains(key2))
                                {
                                    // 値をセット
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            case 3:
                                if (keyList3.Contains(key3))
                                {
                                    // 値をセット
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            case 4:
                                if (keyList4.Contains(key4))
                                {
                                    // 値をセット
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            case 5:
                                if (keyList5.Contains(key5))
                                {
                                    // 値をセット
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            // UPD 2013/07/26 吉岡 Redmine#39203 販売区分は画面から変更可能なので、全件登録する----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            #region 旧ソース
                            //case 6:
                            //    if (keyList6.Contains(key6))
                            //    {
                            //        // 値をセット
                            //        campaignMngList.Add(retWork);
                            //    }
                            //    break;
                            #endregion
                            case 6:
                                // 値をセット
                                campaignMngList.Add(retWork);
                                break;
                            // UPD 2013/07/26 吉岡 Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }
                }
            }

            if ((campaignMngList != null) && (campaignMngList.Count > 0))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }


            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// キャンペーン検索条件設定
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsUnitDataList">商品連結情報リスト</param>
        /// <returns>キャンペーン検索条件</returns>
        private CampaignMngOrderWork SetCompaignCond(string enterpriseCode, string sectionCode, List<GoodsUnitData> goodsUnitDataList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SetCompaignCond";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            CampaignMngOrderWork campaignMngOrder = new CampaignMngOrderWork();
            campaignMngOrder.EnterpriseCode = enterpriseCode;      // 企業コード
            campaignMngOrder.SectionCode = sectionCode;            // 拠点コード

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "キャンペーンマスタ　検索条件"
                + "　企業コード：" + enterpriseCode
                + "　拠点コード：" + sectionCode
            );
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return campaignMngOrder;
        }
        #endregion

        #region 仕入金額処理区分設定処理
        /// <summary>
        /// すべて仕入金額処理区分設定処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="pmtStkPrcMnyTmpList">USER DBの仕入金額処理区分リスト</param>
        /// <returns>ステータス</returns>
        private int StockProcMoneyDataOpr(string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid, 
            out string msg, 
            ref List<PmtStkPrcMnyTmpWork> pmtStkPrcMnyTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "StockProcMoneyDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 初期化
            msg = "";

            // DEL 2013/07/24 吉岡 Redmine#39055 --------------->>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            // ArrayList allStockProcMoneyList;

            //int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //// すべて仕入金額処理区分情報取得
            //status = SearchInitial_StockProcMoneyProc(enterpriseCode, out msg, out allStockProcMoneyList);

            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 仕入金額処理区分情報取得 status：" + status.ToString());
            //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            //    return status;
            //}
            #endregion
            // DEL 2013/07/24 吉岡 Redmine#39055 ---------------<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/07/24 吉岡 Redmine#39055 --------------->>>>>>>>>>>>>>>>>>>>>>
            // allStockProcMoneyListの取得は単価算出(CalculateUnitPrice)の際に実施 
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (allStockProcMoneyList == null)
            {
                msg = "単価算出(CalculateUnitPrice) の時点で、仕入金額処理区分情報の取得の取得に失敗しています。";
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 " + msg + " status：" + status.ToString());
                return status;
            }
            // ADD 2013/07/24 吉岡 Redmine#39055 ---------------<<<<<<<<<<<<<<<<<<<<<<

            // 仕入金額処理区分設定設定処理
            status = WriteStockProcMoneyMastDataOpr(enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                // UPD 2013/08/05 Redmine#39451 ------------------------------->>>>>
                //allStockProcMoneyList,
                this._stockProcMoneyList,
                // UPD 2013/08/05 Redmine#39451 -------------------------------<<<<<
                ref pmtStkPrcMnyTmpList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 仕入金額処理区分情報書込み status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }


        // ADD 2013/08/05 Redmine#39451 ------------------------------------------->>>>>
        /// <summary>
        ///  仕入金額処理区分リスト作成
        /// </summary>
        /// <param name="supplierWork"></param>
        /// <param name="allStockProcMoneyList"></param>
        private void GetStockProcMoneyList(SupplierWork supplierWork, ArrayList allStockProcMoneyList)
        {
            // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
            //bool stockUnPrcFrcProcCdFlag = false;
            //bool stockMoneyFrcProcCdFlag = false;
            //bool stockCnsTaxFrcProcCdFlag = false;
            // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<

            if (allStockProcMoneyList == null || allStockProcMoneyList.Count == 0) return;

            for (int i = 0; i < allStockProcMoneyList.Count; i++)
            {

                StockProcMoney stockProcMoneyWork = allStockProcMoneyList[i] as StockProcMoney;

                // 仕入単価端数処理区分
                // UPD 2013/08/07 Redmine#39694 ------------------------------>>>>>
                //if (stockProcMoneyWork.FracProcMoneyDiv == (int)SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd &&
                if (stockProcMoneyWork.FracProcMoneyDiv == 2 &&
                // UPD 2013/08/07 Redmine#39694 ------------------------------<<<<<
                    stockProcMoneyWork.FractionProcCode == supplierWork.StockUnPrcFrcProcCd)
                {
                    if (!this._stockProcMoneyList.Contains(stockProcMoneyWork))
                    {
                        this._stockProcMoneyList.Add(stockProcMoneyWork);
                        // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
                        //stockUnPrcFrcProcCdFlag = true;
                        // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<
                    }
                }
                // 仕入金額端数処理区分
                // UPD 2013/08/07 Redmine#39694 ------------------------------>>>>>
                //if (stockProcMoneyWork.FracProcMoneyDiv == (int)SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd &&
                if (stockProcMoneyWork.FracProcMoneyDiv == 0 &&
                // UPD 2013/08/07 Redmine#39694 ------------------------------<<<<<
                    stockProcMoneyWork.FractionProcCode == supplierWork.StockMoneyFrcProcCd)
                {
                    if (!this._stockProcMoneyList.Contains(stockProcMoneyWork))
                    {
                        this._stockProcMoneyList.Add(stockProcMoneyWork);
                        // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
                        //stockMoneyFrcProcCdFlag = true;
                        // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<
                    }
                }
                // 仕入消費税端数処理区分
                // UPD 2013/08/07 Redmine#39694 ------------------------------>>>>>
                //if (stockProcMoneyWork.FracProcMoneyDiv == (int)SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd &&
                if (stockProcMoneyWork.FracProcMoneyDiv == 1 &&
                // UPD 2013/08/07 Redmine#39694 ------------------------------<<<<<
                    stockProcMoneyWork.FractionProcCode == supplierWork.StockCnsTaxFrcProcCd)
                {
                    if (!this._stockProcMoneyList.Contains(stockProcMoneyWork))
                    {
                        this._stockProcMoneyList.Add(stockProcMoneyWork);
                        // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
                        //stockCnsTaxFrcProcCdFlag = true;
                        // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<
                    }
                }
                // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
                //if (stockUnPrcFrcProcCdFlag && stockMoneyFrcProcCdFlag && stockCnsTaxFrcProcCdFlag) break;
                // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<
            }
        }
        // ADD 2013/08/05 Redmine#39451 -------------------------------------------<<<<<

        /// <summary>
        /// すべて仕入金額処理区分情報取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="allStockProcMoneyList">すべて仕入金額処理区分情報リスト</param>
        /// <returns>ステータス</returns>
        private int SearchInitial_StockProcMoneyProc(string enterpriseCode, out string msg, out ArrayList allStockProcMoneyList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchInitial_StockProcMoneyProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";
            allStockProcMoneyList = new ArrayList();

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "仕入金額処理区分マスタ　検索条件"
                        + "　企業コード：" + enterpriseCode
            );
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            status = stockProcMoneyAcs.Search(out allStockProcMoneyList, enterpriseCode);

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// 仕入金額処理区分設定設定処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="stockProcMoneyList">仕入金額処理区分設定リスト</param>
        /// <param name="pmtStkPrcMnyTmpList">USER DBの仕入金額処理区分リスト</param>
        /// <returns>ステータス</returns>
        private int WriteStockProcMoneyMastDataOpr(string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid, 
            // UPD 2013/08/05 Redmine#39451 ------------------------->>>>>
            //ArrayList stockProcMoneyList,
            List<StockProcMoney> stockProcMoneyList,
            // UPD 2013/08/05 Redmine#39451 -------------------------<<<<<
            ref List<PmtStkPrcMnyTmpWork> pmtStkPrcMnyTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteStockProcMoneyMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // UPD 2013/08/05 Redmine#39451
            for (int i = 0; i < stockProcMoneyList.Count; i++)
            {
                // UPD 2013/08/05 Redmine#39451 -------------------------------------->>>>>
                //StockProcMoney stockProcMoneyWork = stockProcMoneyList[i] as StockProcMoney;
                StockProcMoney stockProcMoneyWork = stockProcMoneyList[i];
                // UPD 2013/08/05 Redmine#39451 --------------------------------------<<<<<
                PmtStkPrcMnyTmpWork tempWork = new PmtStkPrcMnyTmpWork();
               
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = stockProcMoneyWork.CreateDateTime;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.FileHeaderGuid = stockProcMoneyWork.FileHeaderGuid;
                tempWork.FracProcMoneyDiv = stockProcMoneyWork.FracProcMoneyDiv;
                tempWork.FractionProcCd = stockProcMoneyWork.FractionProcCd;
                tempWork.FractionProcCode = stockProcMoneyWork.FractionProcCode;
                tempWork.FractionProcUnit = stockProcMoneyWork.FractionProcUnit;
                tempWork.LogicalDeleteCode = stockProcMoneyWork.LogicalDeleteCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.UpdAssemblyId1 = stockProcMoneyWork.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = stockProcMoneyWork.UpdAssemblyId2;
                tempWork.UpdateDateTime = stockProcMoneyWork.UpdateDateTime;
                tempWork.UpdEmployeeCode = stockProcMoneyWork.UpdEmployeeCode;
                tempWork.UpperLimitPrice = stockProcMoneyWork.UpperLimitPrice;

                pmtStkPrcMnyTmpList.Add(tempWork);
            }

            if (pmtStkPrcMnyTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }
        #endregion

        #region BLグループデータ
        /// <summary>
        /// BLグループデータ処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="pmtBLGroupUTmpList">BLグループデータリスト</param>
        /// <returns>ステータス</returns>
        private int BLGroupMastDataOpr(string enterpriseCode, 
                string sectionCode, 
                string businessSessionId,
                string pmTabSearchGuid, 
                out string msg, 
                List<GoodsUnitData> goodsUnitDataList, 
                ref List<PmtBLGroupUTmpWork> pmtBLGroupUTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "BLGroupMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 初期化
            msg = "";

            // 商品連結データリストチェック処理
            if (null == goodsUnitDataList || goodsUnitDataList.Count == 0)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 goodsUnitDataList null or Count=0");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";
            // すべてBLグループ情報リスト
            Dictionary<int, BLGroupU> allBLGroupWorkList;
            // 仕入先情報リスト
            Dictionary<int, BLGroupU> blGroupWorkList;

            // すべてBLグループ検索
            status = SearchInitial_BLGroupProc(enterpriseCode, out msg, out allBLGroupWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 BLグループ検索 status：" + status.ToString());
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            else
            {
                // グループ情報リスト取得
                status = GetBLGroupList(enterpriseCode, goodsUnitDataList, allBLGroupWorkList,
                            out blGroupWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 グループ情報リスト取得 status：" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                    return status;
                }

                status = WriteBLGroupMastDataOpr(enterpriseCode, 
                    sectionCode, 
                    businessSessionId,
                    pmTabSearchGuid, 
                    blGroupWorkList, 
                    ref pmtBLGroupUTmpList);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// ＢＬグループ情報取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsUnitDataList">商品連結情報リスト</param>
        /// <param name="allBLGroupWorkList">すべてBLグループ情報リスト</param>
        /// <param name="blGroupWorkList">BLグループ情報リスト</param>
        /// <returns>ステータス</returns>
        private int GetBLGroupList(string enterpriseCode, List<GoodsUnitData> goodsUnitDataList, Dictionary<int, BLGroupU> allBLGroupWorkList,
            out Dictionary<int, BLGroupU> blGroupWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GetBLGroupList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            blGroupWorkList = new Dictionary<int, BLGroupU>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            // if (allBLGroupWorkList == null || allBLGroupWorkList.Count == 0) return status;
            if (allBLGroupWorkList == null || allBLGroupWorkList.Count == 0)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 BLGroupWorkList null or Count=0");
                return status;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            try
            {
                foreach (GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
                {
                    if (allBLGroupWorkList.ContainsKey(tempGoodsUnitData.BLGroupCode))
                    {
                        BLGroupU blGroupU = null;

                        blGroupU = allBLGroupWorkList[tempGoodsUnitData.BLGroupCode] as BLGroupU;

                        if (!blGroupWorkList.ContainsKey(tempGoodsUnitData.BLGroupCode))
                        {
                            blGroupWorkList.Add(tempGoodsUnitData.BLGroupCode, blGroupU);
                        }
                    }
                }
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            // catch
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }

            // ステータス設定
            if (blGroupWorkList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// BLグループ新規操作
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="blGroupWorkList">ＢＬグループ情報リスト</param>
        /// <param name="pmtBLGroupUTmpList">USER DBのBLグループリスト</param>
        /// <returns>ステータス</returns>
        private int WriteBLGroupMastDataOpr(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid, 
                Dictionary<int, BLGroupU> blGroupWorkList, 
                ref List<PmtBLGroupUTmpWork> pmtBLGroupUTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteBLGroupMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            int i = 0;
            foreach (BLGroupU blGroupU in blGroupWorkList.Values)
            {
                PmtBLGroupUTmpWork tempWork = new PmtBLGroupUTmpWork();

                tempWork.BLGroupCode = blGroupU.BLGroupCode;
                tempWork.BLGroupKanaName = blGroupU.BLGroupKanaName;
                tempWork.BLGroupName = blGroupU.BLGroupName;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = blGroupU.CreateDateTime;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.FileHeaderGuid = blGroupU.FileHeaderGuid;
                tempWork.GoodsLGroup = blGroupU.GoodsLGroup;
                tempWork.GoodsMGroup = blGroupU.GoodsMGroup;
                tempWork.LogicalDeleteCode = blGroupU.LogicalDeleteCode;
                tempWork.OfferDataDiv = blGroupU.OfferDataDiv;
                tempWork.OfferDate = blGroupU.OfferDate;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = ++i;
                tempWork.SalesCode = blGroupU.SalesCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.UpdAssemblyId1 = blGroupU.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = blGroupU.UpdAssemblyId2;
                tempWork.UpdateDateTime = blGroupU.UpdateDateTime;
                tempWork.UpdEmployeeCode = blGroupU.UpdEmployeeCode;

                pmtBLGroupUTmpList.Add(tempWork);
            }

            if (pmtBLGroupUTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// BLグループ情報取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <param name="allBLGroupWorkList">全て</param>
        /// <returns>ステータス</returns>
        private int SearchInitial_BLGroupProc(string enterpriseCode, out string msg, out Dictionary<int, BLGroupU> allBLGroupWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchInitial_BLGroupProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            allBLGroupWorkList = new Dictionary<int, BLGroupU>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";

            try
            {
                // サーバーユーザーデータ
                IUsrJoinPartsSearchDB iGoodsURelationDataDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                #region BLグループ情報(ユーザー)
                //---------------------------------------------------------------------
                // BLグループ情報(ユーザー)
                //---------------------------------------------------------------------
                // ユーザー登録分抽出条件
                GoodsUCndtnWork goodsUCndtnWork = new GoodsUCndtnWork();
                goodsUCndtnWork.EnterpriseCode = enterpriseCode;

                // 取得したい検索結果データクラスを設定
                CustomSerializeArrayList workList;

                workList = new CustomSerializeArrayList();

                // BLグループ情報
                BLGroupUWork bLGroupUWork = new BLGroupUWork();
                bLGroupUWork.EnterpriseCode = enterpriseCode;
                workList.Add(bLGroupUWork);

                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "BLグループマスタ　検索条件"
                    + "　企業コード：" + enterpriseCode
                );
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

                // オブジェクト型に

                object retObj;

                retObj = workList;

                // 検索
                status = iGoodsURelationDataDB.Search(ref retObj, goodsUCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            workList = retObj as CustomSerializeArrayList;

                            // 取得データを変換
                            if (workList == null)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 BLグループ情報取得 status：" + status.ToString());
                                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                                return status;
                            }

                            #region BLグループ情報
                            //---------------------------------------------------------------------
                            // BLグループ情報取得
                            //---------------------------------------------------------------------
                            List<BLGroupU> bLGroupUList;
                            status2 = GetBLGroupUWorkToUIdata(workList, out bLGroupUList);

                            if ((null != bLGroupUList) && (bLGroupUList.Count > 0))
                            {
                                foreach (BLGroupU tempBLGroupU in bLGroupUList)
                                {
                                    if (!allBLGroupWorkList.ContainsKey(tempBLGroupU.BLGroupCode))
                                    {
                                        allBLGroupWorkList.Add(tempBLGroupU.BLGroupCode, tempBLGroupU);
                                    }
                                }
                            }
                            #endregion

                            break;
                        }
                    default:
                        msg = "BLグループ情報の取得に失敗しました";
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = "BLグループ情報の取得で例外が発生しました[" + ex.Message + "]";
                msg = ex.Message;
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, msg);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString() + " " + msg);
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return 0;
        }

        /// <summary>
        /// CustomSerializeArrayList →　BLグループコードマスタ(ユーザー)リスト取得
        /// </summary>
        /// <param name="workList">WORK型データリスト</param>
        /// <param name="uiList">商品区分詳細(ユーザー登録)クラス</param>
        /// <returns>ステータス</returns>
        private int GetBLGroupUWorkToUIdata(CustomSerializeArrayList workList, out List<BLGroupU> uiList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GetBLGroupUWorkToUIdata";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            uiList = null;

            try
            {
                //---------------------------------------------------------------------
                // サーバーデータ取得
                //---------------------------------------------------------------------
                if ((workList.Count > 0) && (workList[0] is ArrayList))
                {
                    foreach (ArrayList arList in workList)
                    {
                        if (arList != null && arList.Count > 0)
                        {
                            if (arList[0] is BLGroupUWork)
                            {
                                // クラスメンバーコピー処理
                                uiList = this.CopyToBLGroupUFromBLGroupUWork(arList);

                                status = (uiList.Count != 0) ? (int)ConstantManagement.DB_Status.ctDB_NORMAL : (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // 例外を発生させる
                string message = "BLグループコードマスタ(ユーザー)取得で例外が発生しました[" + ex.Message + "]";
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// クラスメンバーコピー処理
        /// </summary>
        /// <param name="bLGroupUWorkList">BLグループコードマスタ(ユーザー)ワークオブジェクトリスト</param>
        /// <returns>BLグループコードマスタ(ユーザー)オブジェクトリスト</returns>
        private List<BLGroupU> CopyToBLGroupUFromBLGroupUWork(ArrayList bLGroupUWorkList)
        {
            List<BLGroupU> bLGroupUList = null;

            if (bLGroupUWorkList != null)
            {
                bLGroupUList = new List<BLGroupU>();

                foreach (BLGroupUWork wrk in bLGroupUWorkList)
                {
                    bLGroupUList.Add(CopyToBLGroupUFromBLGroupUWork(wrk));
                }
            }
            return bLGroupUList;
        }

        /// <summary>
        /// クラスメンバーコピー処理
        /// </summary>
        /// <param name="bLGroupUWork">BLグループコードマスタ(ユーザー)ワークオブジェクト</param>
        /// <returns>BLグループコードマスタ(ユーザー)オブジェクト</returns>
        private BLGroupU CopyToBLGroupUFromBLGroupUWork(BLGroupUWork bLGroupUWork)
        {
            BLGroupU bLGroupU = null;

            if (bLGroupUWork != null)
            {
                bLGroupU = new BLGroupU();

                bLGroupU.CreateDateTime = bLGroupUWork.CreateDateTime; // 作成日時
                bLGroupU.UpdateDateTime = bLGroupUWork.UpdateDateTime; // 更新日時
                bLGroupU.EnterpriseCode = bLGroupUWork.EnterpriseCode; // 企業コード
                bLGroupU.FileHeaderGuid = bLGroupUWork.FileHeaderGuid; // GUID
                bLGroupU.UpdEmployeeCode = bLGroupUWork.UpdEmployeeCode; // 更新従業員コード
                bLGroupU.UpdAssemblyId1 = bLGroupUWork.UpdAssemblyId1; // 更新アセンブリID1
                bLGroupU.UpdAssemblyId2 = bLGroupUWork.UpdAssemblyId2; // 更新アセンブリID2
                bLGroupU.LogicalDeleteCode = bLGroupUWork.LogicalDeleteCode; // 論理削除区分
                bLGroupU.GoodsLGroup = bLGroupUWork.GoodsLGroup; // 商品大分類コード
                bLGroupU.GoodsMGroup = bLGroupUWork.GoodsMGroup; // 商品中分類コード
                bLGroupU.BLGroupCode = bLGroupUWork.BLGroupCode; // BLグループコード
                bLGroupU.BLGroupName = bLGroupUWork.BLGroupName; // BLグループコード名称
                bLGroupU.SalesCode = bLGroupUWork.SalesCode; // 販売区分コード

                //-----ADD songg 2013/06/18 ソースチェック確認事項一覧にNo.35の対応 ---->>>>>
                bLGroupU.BLGroupKanaName = bLGroupUWork.BLGroupKanaName; // BLグループコードカナ名称 
                bLGroupU.OfferDataDiv = bLGroupUWork.OfferDataDiv;
                bLGroupU.OfferDate = bLGroupUWork.OfferDate;
                //-----ADD songg 2013/06/18 ソースチェック確認事項一覧にNo.35の対応 ----<<<<<
                
            }

            return bLGroupU;
        }
        #endregion

        #region 仕入先マスタ処理
        /// <summary>
        /// 仕入先マスタデータ作成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="goodsUnitDataList">商品連結情報データリスト</param>
        /// <param name="pmtSupplierTmpList">仕入先マスタリスト</param>
        /// <returns>ステータス</returns>
        private int SupplierMastDataOpr(string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid, 
            out string msg, 
            List<GoodsUnitData> goodsUnitDataList, 
            ref List<PmtSupplierTmpWork> pmtSupplierTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SupplierMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // 初期化
            msg = "";

            // 商品連結データリストチェック処理
            if (null == goodsUnitDataList || goodsUnitDataList.Count == 0)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 goodsUnitDataList null or Coutn=0");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";
            // すべて仕入先情報リスト
            // UPD 2013/08/02 Redmine#39451 速度改善8 ------------------------------------------->>>>>
            //Dictionary<int, SupplierWork> allSupplierWorkList = new Dictionary<int, SupplierWork>();
            Dictionary<int, SupplierWork> allSupplierWorkList;
            // UPD 2013/08/02 Redmine#39451 速度改善8 -------------------------------------------<<<<<
            // 仕入先情報リスト
            Dictionary<int, SupplierWork> supplierWorkList;

            // すべて仕入先検索
            status = SearchInitial_SupplierProc(enterpriseCode, out msg, out allSupplierWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 仕入先検索 status：" + status.ToString() + " " + msg);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }
            else
            {
                // 仕入先情報リスト取得
                status = GetSupplierList(goodsUnitDataList, allSupplierWorkList,
                            out supplierWorkList);
                
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 仕入先情報リスト取得 status：" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                    return status;
                }

                // 仕入先情報保存します
                status = WriteSupplierMastDataOpr(enterpriseCode,
                    sectionCode,
                    businessSessionId,
                    pmTabSearchGuid, 
                    supplierWorkList, 
                    ref pmtSupplierTmpList);
             }

             // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
             EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
             // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// すべて仕入先情報検査処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="supplierWorkList">仕入先リスト</param>
        /// <returns>ステータス</returns>
        private int SearchInitial_SupplierProc(string enterpriseCode, out string msg, out Dictionary<int, SupplierWork> supplierWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchInitial_SupplierProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            supplierWorkList = new Dictionary<int, SupplierWork>();
            List<SupplierWork> tempSupplierWorkList = new List<SupplierWork>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";

            try
            {
                IUsrJoinPartsSearchDB　_iGoodsURelationDataDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                #region 仕入先情報(ユーザー)
                //---------------------------------------------------------------------
                // 仕入先情報(ユーザー)
                //---------------------------------------------------------------------
                // ユーザー登録分抽出条件
                GoodsUCndtnWork goodsUCndtnWork = new GoodsUCndtnWork();
                goodsUCndtnWork.EnterpriseCode = enterpriseCode;

                // 取得したい検索結果データクラスを設定
                CustomSerializeArrayList workList = new CustomSerializeArrayList();

                // 仕入先情報(ユーザー)
                SupplierWork supplierWork = new SupplierWork();
                supplierWork.EnterpriseCode = enterpriseCode;

                workList.Add(supplierWork);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "仕入先マスタ　検索条件"
                    + "　企業コード：" + enterpriseCode
                );
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

                // オブジェクト型に
                object retObj = workList;

                // リモートからデータ検索
                status = _iGoodsURelationDataDB.Search(ref retObj, goodsUCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);


                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            workList = retObj as CustomSerializeArrayList;

                            // 取得データを変換
                            if (workList == null)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 仕入先情報検索 status：" + status.ToString());
                                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                                return status;
                            }

                            #region 仕入先情報
                            //---------------------------------------------------------------------
                            // 仕入先情報
                            //---------------------------------------------------------------------
                            if (workList.Count > 0)
                            {
                                if ((workList.Count > 0) && (workList[0] is ArrayList))
                                {
                                    foreach (ArrayList arList in workList)
                                    {
                                        if (arList != null && arList.Count > 0)
                                        {
                                            if (arList[0] is SupplierWork)
                                            {
                                                tempSupplierWorkList = new List<SupplierWork>((SupplierWork[])arList.ToArray(typeof(SupplierWork)));
                                            }
                                        }
                                    }

                                    foreach (SupplierWork tempSupplierWork in tempSupplierWorkList)
                                    {
                                        if (!supplierWorkList.ContainsKey(tempSupplierWork.SupplierCd))
                                        {
                                            supplierWorkList.Add(tempSupplierWork.SupplierCd, tempSupplierWork);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 仕入先情報検索 status：" + status.ToString());
                                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                                return status;
                            }
                            #endregion
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        msg = "仕入先情報(ユーザー)の取得に失敗しました";
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = "仕入先情報(ユーザー)の取得で例外が発生しました[" + ex.Message + "]";
                msg = ex.Message;
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, msg);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString() + " " + msg);
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return 0;
        }

        /// <summary>
        /// 商品連結データリストから、仕入先リスト取得処理
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="allSupplierWorkList">すべて仕入先リスト</param>
        /// <param name="supplierWorkList">仕入先リスト</param>
        /// <returns>ステータス</returns>
        private int GetSupplierList(List<GoodsUnitData> goodsUnitDataList, Dictionary<int, SupplierWork> allSupplierWorkList,
            out Dictionary<int, SupplierWork> supplierWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GetSupplierList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            supplierWorkList = new Dictionary<int, SupplierWork>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (allSupplierWorkList == null || allSupplierWorkList.Count == 0) return status;

            try
            {
                foreach (GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
                {
                    if (allSupplierWorkList.ContainsKey(tempGoodsUnitData.SupplierCd))
                    {
                        SupplierWork supplierWork = null;

                        supplierWork = allSupplierWorkList[tempGoodsUnitData.SupplierCd] as SupplierWork;

                        if (!supplierWorkList.ContainsKey(tempGoodsUnitData.SupplierCd))
                        {
                            supplierWorkList.Add(tempGoodsUnitData.SupplierCd, supplierWork);
                            // ADD 2013/08/05 Redmine#39451 ------------------------------------>>>>>
                            // 仕入金額処理区分検索
                            if (allStockProcMoneyList != null && allStockProcMoneyList.Count != 0)
                            {
                                GetStockProcMoneyList(supplierWork, allStockProcMoneyList);
                            }
                            // ADD 2013/08/05 Redmine#39451 ------------------------------------<<<<<
                        }
                    }
                }
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            // catch 
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }

            if (supplierWorkList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// 保存した仕入先データリスト
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="supplierWorkList">仕入先情報リスト</param>
        /// <param name="pmtSupplierTmpList">USER DBの仕入先データリスト</param>
        /// <returns>ステータス</returns>
        private int WriteSupplierMastDataOpr(string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid, 
            Dictionary<int, SupplierWork> supplierWorkList, 
            ref List<PmtSupplierTmpWork> pmtSupplierTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteSupplierMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            int i = 0;
            foreach(SupplierWork supplierWork in supplierWorkList.Values)
            {
                PmtSupplierTmpWork tempWork = new PmtSupplierTmpWork();

                tempWork.BusinessSessionId = businessSessionId;
                tempWork.BusinessTypeCode = supplierWork.BusinessTypeCode;
                tempWork.CreateDateTime = supplierWork.CreateDateTime;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", "")); //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.FileHeaderGuid = supplierWork.FileHeaderGuid;
                tempWork.InpSectionCode = supplierWork.InpSectionCode;
                tempWork.LogicalDeleteCode = supplierWork.LogicalDeleteCode;
                tempWork.MngSectionCode = supplierWork.MngSectionCode;
                tempWork.NTimeCalcStDate = supplierWork.NTimeCalcStDate;
                tempWork.OrderHonorificTtl = supplierWork.OrderHonorificTtl;
                tempWork.PayeeCode = supplierWork.PayeeCode;
                tempWork.PaymentCond = supplierWork.PaymentCond;
                tempWork.PaymentDay = supplierWork.PaymentDay;
                tempWork.PaymentMonthCode = supplierWork.PaymentMonthCode;
                tempWork.PaymentMonthName = supplierWork.PaymentMonthName;
                tempWork.PaymentSectionCode = supplierWork.PaymentSectionCode;
                tempWork.PaymentSight = supplierWork.PaymentSight;
                tempWork.PaymentTotalDay = supplierWork.PaymentTotalDay;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = ++i;
                tempWork.PureCode = supplierWork.PureCode;
                tempWork.SalesAreaCode = supplierWork.SalesAreaCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.StckTtlAmntDspWayRef = supplierWork.StckTtlAmntDspWayRef;
                tempWork.StockAgentCode = supplierWork.StockAgentCode;
                tempWork.StockCnsTaxFrcProcCd = supplierWork.StockCnsTaxFrcProcCd;
                tempWork.StockMoneyFrcProcCd = supplierWork.StockMoneyFrcProcCd;
                tempWork.StockUnPrcFrcProcCd = supplierWork.StockUnPrcFrcProcCd;
                tempWork.SuppCTaxationCd = supplierWork.SuppCTaxationCd;
                tempWork.SuppCTaxLayCd = supplierWork.SuppCTaxLayCd;
                tempWork.SuppCTaxLayRefCd = supplierWork.SuppCTaxLayRefCd;
                tempWork.SuppEnterpriseCd = supplierWork.SuppEnterpriseCd;
                tempWork.SuppHonorificTitle = supplierWork.SuppHonorificTitle;
                tempWork.SupplierAddr1 = supplierWork.SupplierAddr1;
                tempWork.SupplierAddr3 = supplierWork.SupplierAddr3;
                tempWork.SupplierAddr4 = supplierWork.SupplierAddr4;
                tempWork.SupplierAttributeDiv = supplierWork.SupplierAttributeDiv;
                tempWork.SupplierCd = supplierWork.SupplierCd;
                tempWork.SupplierKana = supplierWork.SupplierKana;
                tempWork.SupplierNm1 = supplierWork.SupplierNm1;
                tempWork.SupplierNm2 = supplierWork.SupplierNm2;
                tempWork.SupplierNote1 = supplierWork.SupplierNote1;
                tempWork.SupplierNote2 = supplierWork.SupplierNote2;
                tempWork.SupplierNote3 = supplierWork.SupplierNote3;
                tempWork.SupplierNote4 = supplierWork.SupplierNote4;
                tempWork.SupplierPostNo = supplierWork.SupplierPostNo;
                tempWork.SupplierSnm = supplierWork.SupplierSnm;
                tempWork.SupplierTelNo = supplierWork.SupplierTelNo;
                tempWork.SupplierTelNo1 = supplierWork.SupplierTelNo1;
                tempWork.SupplierTelNo2 = supplierWork.SupplierTelNo2;
                tempWork.SuppTtlAmntDspWayCd = supplierWork.SuppTtlAmntDspWayCd;
                tempWork.UpdAssemblyId1 = supplierWork.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = supplierWork.UpdAssemblyId2;
                tempWork.UpdateDateTime = supplierWork.UpdateDateTime;
                tempWork.UpdEmployeeCode = supplierWork.UpdEmployeeCode;

                pmtSupplierTmpList.Add(tempWork);
            }

            if (pmtSupplierTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }
        #endregion

        // ---- ADD SONGG 2013/07/30 Redmine#39386 自社情報マスタ追加 ----- >>>>>
        #region 自社情報マスタ追加
        /// <summary>
        /// 自社情報マスタ追加処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="pmtCompanyInfList">自社情報リスト</param>
        /// <returns></returns>
        private int SetCompanyInf(string enterpriseCode,
                string businessSessionId,
                string pmTabSearchGuid,
                ref List<PmtCompanyInfWork> pmtCompanyInfList)
        {
            const string methodName = "SetCompanyInf";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CompanyInf companyInf;
            status = GetCompanyInf(out companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && companyInf != null)
            {
                WriteCompanyInf(enterpriseCode, businessSessionId, pmTabSearchGuid, companyInf, ref pmtCompanyInfList);
            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            return status;
        }

        /// <summary>
        /// 引数より自社情報設定マスタ取得処理
        /// </summary>
        /// <param name="companyInf">自社情報</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        private int GetCompanyInf(out CompanyInf companyInf, string enterpriseCode)
        {
            const string methodName = "GetCompanyInf";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();

            status = companyInfAcs.Read(out companyInf, enterpriseCode);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            return status;
        }

        /// <summary>
        /// 自社情報マスタ情報保存処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="companyInf">自社情報</param>
        /// <param name="pmtCompanyInfList">自社情報リスト</param>
        private void WriteCompanyInf(string enterpriseCode,
                string businessSessionId,
                string pmTabSearchGuid,
                CompanyInf companyInf,
                ref List<PmtCompanyInfWork> pmtCompanyInfList)
        {
            const string methodName = "WriteCompanyInf";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            PmtCompanyInfWork tempWork = new PmtCompanyInfWork();

            tempWork.CreateDateTime = companyInf.CreateDateTime;
            tempWork.UpdateDateTime = companyInf.UpdateDateTime;
            tempWork.EnterpriseCode = companyInf.EnterpriseCode;
            tempWork.FileHeaderGuid = companyInf.FileHeaderGuid;
            tempWork.UpdEmployeeCode = companyInf.UpdEmployeeCode;
            tempWork.UpdAssemblyId1 = companyInf.UpdAssemblyId1;
            tempWork.UpdAssemblyId2 = companyInf.UpdAssemblyId2;
            tempWork.LogicalDeleteCode = companyInf.LogicalDeleteCode;
            tempWork.BusinessSessionId = businessSessionId;
            tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
            tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));
            tempWork.CompanyCode = companyInf.CompanyCode;
            tempWork.CompanyTotalDay = companyInf.CompanyTotalDay;
            tempWork.FinancialYear = companyInf.FinancialYear;
            tempWork.CompanyBiginMonth = companyInf.CompanyBiginMonth;
            tempWork.CompanyBiginMonth2 = companyInf.CompanyBiginMonth2;
            tempWork.CompanyBiginDate = GetDate(companyInf.CompanyBiginDate);
            tempWork.StartYearDiv = companyInf.StartYearDiv;
            tempWork.StartMonthDiv = companyInf.StartMonthDiv;
            tempWork.CompanyName1 = companyInf.CompanyName1;
            tempWork.CompanyName2 = companyInf.CompanyName2;
            tempWork.PostNo = companyInf.PostNo;
            tempWork.Address1 = companyInf.Address1;
            tempWork.Address3 = companyInf.Address3;
            tempWork.Address4 = companyInf.Address4;
            tempWork.CompanyTelNo1 = companyInf.CompanyTelNo1;
            tempWork.CompanyTelNo2 = companyInf.CompanyTelNo2;
            tempWork.CompanyTelNo3 = companyInf.CompanyTelNo3;
            tempWork.CompanyTelTitle1 = companyInf.CompanyTelTitle1;
            tempWork.CompanyTelTitle2 = companyInf.CompanyTelTitle2;
            tempWork.CompanyTelTitle3 = companyInf.CompanyTelTitle3;
            tempWork.SecMngDiv = companyInf.SecMngDiv;
            tempWork.DataClrExecDate = GetDate(companyInf.DataClrExecDate);
            tempWork.DataClrExecTime = companyInf.DataClrExecTime;
            tempWork.DataSaveMonths = companyInf.DataSaveMonths;
            tempWork.DataCompressDt = GetDate(companyInf.DataCompressDt);
            tempWork.ResultDtSaveMonths = companyInf.ResultDtSaveMonths;
            tempWork.ResultDtCompressDt = GetDate(companyInf.ResultDtCompressDt);
            tempWork.CaPrtsDtSaveMonths = companyInf.CaPrtsDtSaveMonths;
            tempWork.CaPrtsDtCompressDt = GetDate(companyInf.CaPrtsDtCompressDt);
            tempWork.MasterSaveMonths = companyInf.MasterSaveMonths;
            tempWork.MasterCompressDt = GetDate(companyInf.MasterCompressDt);
            tempWork.RatePriorityDiv = companyInf.RatePriorityDiv;

            pmtCompanyInfList.Add(tempWork);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }
        #endregion 自社情報マスタ追加
        // ---- ADD SONGG 2013/07/30 Redmine#39386 自社情報マスタ追加 ----- <<<<<

        #region キャンペーン売価優先設定マスタの取得

        /// <summary>
        /// キャンペーン売価優先設定マスタの取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="pmtCmpPrcPrStList">売価優先設定マスタ情報リスト</param>
        /// <returns></returns>
        private int SetCampaignPrcPrSt(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                ref List<PmtCmpPrcPrStWork> pmtCmpPrcPrStList)
        {
            const string methodName = "SetCampaignPrcPrSt";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CampaignPrcPrSt campaignPrcPrSt;
            status = GetCampaignPrcPrSt(out campaignPrcPrSt, enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && campaignPrcPrSt != null)
            {
                WritePmtCmpPrcPrSt(enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid, campaignPrcPrSt, ref pmtCmpPrcPrStList);
            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            return status;
 
        }

        /// <summary>
        /// 引数よりキャンペーン売価優先設定マスタ情報を取得。
        /// </summary>
        /// <param name="campaignPrcPrSt">売価優先設定マスタ情報</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        private int GetCampaignPrcPrSt(out CampaignPrcPrSt campaignPrcPrSt, string enterpriseCode, string sectionCode)
        {
            const string methodName = "GetCampaignPrcPrSt";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region 削除
            // DEL 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
            //CampaignPrcPrStAcs campaignPrcPrStAcs = new CampaignPrcPrStAcs();

            //int sectionCd = 0;
            //int.TryParse(sectionCode, out sectionCd);
            //CampaignPrcPrSt campaignPrcPrStRead = new CampaignPrcPrSt();
            //ArrayList campaignPrcPrStList = null;
            //if (campaignPrcPrStList == null)
            //{
            //    status = campaignPrcPrStAcs.SearchAll(out campaignPrcPrStList, enterpriseCode);
            //}
            //foreach (CampaignPrcPrSt campaignPrcPr in campaignPrcPrStList)
            //{
            //    // ----- DEL huangt 2013/07/24 Redmine#39039 部品検索 使用する拠点コードの修正 ----->>>>>
            //    //if (campaignPrcPr.SectionCode.Trim() == sectionCode.Trim())
            //    //{
            //    //    // 拠点コード
            //    //    campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
            //    //    // 優先設定コード
            //    //    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
            //    //    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
            //    //    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
            //    //    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
            //    //    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
            //    //    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
            //    //    break;
            //    //}
            //    // ----- DEL huangt 2013/07/24 Redmine#39039 部品検索 使用する拠点コードの修正 -----<<<<<

            //    if (campaignPrcPr.SectionCode.Trim() == "00")
            //    {
            //        // 拠点コード
            //        campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
            //        // 優先設定コード
            //        campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
            //        campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
            //        campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
            //        campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
            //        campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
            //        campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
            //    }

            //    // ----- ADD huangt 2013/07/24 Redmine#39039 部品検索 使用する拠点コードの修正 ----->>>>>
            //    if (campaignPrcPr.SectionCode.Trim() == this._mngSectionCode.Trim())
            //    {
            //        // 拠点コード	
            //        campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
            //        // 優先設定コード	
            //        campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
            //        campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
            //        campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
            //        campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
            //        campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
            //        campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
            //        break;
            //    }
            //    // ----- ADD huangt 2013/07/24 Redmine#39039 部品検索 使用する拠点コードの修正 -----<<<<<

            //}

            //campaignPrcPrSt = campaignPrcPrStRead;

            //if (status == 0)
            //{
            //    if (campaignPrcPrSt != null)
            //    {
            //        if (campaignPrcPrSt.LogicalDeleteCode != 0)
            //        {
            //            status = -1;
            //        }
            //    }
            //}

            //if (status == 0)
            //{
            //    if (campaignPrcPrSt != null)
            //    {
            //        if (campaignPrcPrSt.PrioritySettingCd1 == 0
            //            && campaignPrcPrSt.PrioritySettingCd2 == 0
            //            && campaignPrcPrSt.PrioritySettingCd3 == 0
            //            && campaignPrcPrSt.PrioritySettingCd4 == 0
            //            && campaignPrcPrSt.PrioritySettingCd5 == 0
            //            && campaignPrcPrSt.PrioritySettingCd6 == 0)
            //        {
            //            campaignPrcPrSt = null;
            //        }
            //    }
            //    else
            //    {
            //        campaignPrcPrSt = null;
            //    }
            //}
            //else
            //{
            //    if (sectionCd != 0)
            //    {
            //        // 引数の拠点に一致するレコードが存在しない場合は、00全社レコードを使用する。
            //        campaignPrcPrSt = null;
            //        status = campaignPrcPrStAcs.Read(out campaignPrcPrSt, enterpriseCode, "00");
            //        if (status == 0)
            //        {
            //            if (campaignPrcPrSt != null)
            //            {
            //                if (campaignPrcPrSt.LogicalDeleteCode != 0)
            //                {
            //                    campaignPrcPrSt = null;
            //                    return status;
            //                }

            //                if (campaignPrcPrSt.PrioritySettingCd1 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd2 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd3 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd4 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd5 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd6 == 0)
            //                {
            //                    campaignPrcPrSt = null;
            //                }
            //            }
            //            else
            //            {
            //                campaignPrcPrSt = null;
            //            }
            //        }
            //        else
            //        {
            //            campaignPrcPrSt = null;
            //        }
            //    }
            //    else
            //    {
            //        campaignPrcPrSt = null;
            //    }
            //}
            // DEL 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<
            #endregion // 削除

            // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
            int sectionCd = 0;
            int.TryParse(sectionCode, out sectionCd);
            campaignPrcPrSt = null;

            // 常駐処理から取得したデータが存在しない時は該当無しで終了
            if (this._campaignPrcPrStList == null) return status;

            CampaignPrcPrSt campaignPrcPrStRead = new CampaignPrcPrSt();

            foreach (CampaignPrcPrSt campaignPrcPr in this._campaignPrcPrStList)
            {
                if (campaignPrcPr.SectionCode.Trim() == "00")
                {
                    campaignPrcPrStRead.LogicalDeleteCode = campaignPrcPr.LogicalDeleteCode;
                    // 拠点コード
                    campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
                    // 優先設定コード
                    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (campaignPrcPr.SectionCode.Trim() == this._mngSectionCode.Trim())
                {
                    campaignPrcPrStRead.LogicalDeleteCode = campaignPrcPr.LogicalDeleteCode;
                    // 拠点コード	
                    campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
                    // 優先設定コード	
                    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            campaignPrcPrSt = campaignPrcPrStRead;

            if (status == 0)
            {
                if (campaignPrcPrSt != null)
                {
                    if (campaignPrcPrSt.LogicalDeleteCode != 0)
                    {
                        status = -1;
                    }
                }
            }

            if (status == 0)
            {
                if (campaignPrcPrSt != null)
                {
                    if (campaignPrcPrSt.PrioritySettingCd1 == 0
                        && campaignPrcPrSt.PrioritySettingCd2 == 0
                        && campaignPrcPrSt.PrioritySettingCd3 == 0
                        && campaignPrcPrSt.PrioritySettingCd4 == 0
                        && campaignPrcPrSt.PrioritySettingCd5 == 0
                        && campaignPrcPrSt.PrioritySettingCd6 == 0)
                    {
                        campaignPrcPrSt = null;
                    }
                }
                else
                {
                    campaignPrcPrSt = null;
                }
            }
            else
            {
                if (sectionCd != 0)
                {
                    // 引数の拠点に一致するレコードが存在しない場合は、00全社レコードを使用する。
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    campaignPrcPrSt = null;
                    foreach (CampaignPrcPrSt campaignPrcPr in this._campaignPrcPrStList)
                    {
                        if (campaignPrcPr.SectionCode.Trim() == "00")
                        {
                            campaignPrcPrSt = new CampaignPrcPrSt();
                            campaignPrcPrSt.LogicalDeleteCode = campaignPrcPr.LogicalDeleteCode;
                            // 拠点コード
                            campaignPrcPrSt.SectionCode = campaignPrcPr.SectionCode;
                            // 優先設定コード
                            campaignPrcPrSt.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                            campaignPrcPrSt.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                            campaignPrcPrSt.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                            campaignPrcPrSt.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                            campaignPrcPrSt.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                            campaignPrcPrSt.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    }
                    if (campaignPrcPrSt != null)
                    {
                        if (campaignPrcPrSt.LogicalDeleteCode != 0)
                        {
                            campaignPrcPrSt = null;
                            return status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }

                        if (campaignPrcPrSt.PrioritySettingCd1 == 0
                            && campaignPrcPrSt.PrioritySettingCd2 == 0
                            && campaignPrcPrSt.PrioritySettingCd3 == 0
                            && campaignPrcPrSt.PrioritySettingCd4 == 0
                            && campaignPrcPrSt.PrioritySettingCd5 == 0
                            && campaignPrcPrSt.PrioritySettingCd6 == 0)
                        {
                            campaignPrcPrSt = null;
                        }
                    }
                    else
                    {
                        campaignPrcPrSt = null;
                    }
                }
                else
                {
                    campaignPrcPrSt = null;
                }
            }
            // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            return status;
        }

        /// <summary>
        /// 売価優先設定マスタ情報保存処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="campaignPrcPrSt">売価優先設定マスタ情報</param>
        /// <param name="pmtCmpPrcPrStList">売価優先設定マスタ情報リスト</param>
        private void WritePmtCmpPrcPrSt(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                CampaignPrcPrSt campaignPrcPrSt,
                ref List<PmtCmpPrcPrStWork> pmtCmpPrcPrStList)
        {
            const string methodName = "WritePmtCmpPrcPrSt";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");

            PmtCmpPrcPrStWork tempWork = new PmtCmpPrcPrStWork();

            tempWork.CreateDateTime = campaignPrcPrSt.CreateDateTime;
            tempWork.UpdateDateTime = campaignPrcPrSt.UpdateDateTime;
            tempWork.EnterpriseCode = enterpriseCode;
            tempWork.FileHeaderGuid = campaignPrcPrSt.FileHeaderGuid;
            tempWork.UpdEmployeeCode = campaignPrcPrSt.UpdEmployeeCode;
            tempWork.UpdAssemblyId1 = campaignPrcPrSt.UpdAssemblyId1;
            tempWork.UpdAssemblyId2 = campaignPrcPrSt.UpdAssemblyId2;
            tempWork.LogicalDeleteCode = campaignPrcPrSt.LogicalDeleteCode;
            tempWork.BusinessSessionId = businessSessionId;
            tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
            //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", "")); //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
            tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
            tempWork.PmTabSearchRowNum = 1;
            tempWork.SearchSectionCode = sectionCode;
            tempWork.SectionCode = campaignPrcPrSt.SectionCode;
            tempWork.PrioritySettingCd1 = campaignPrcPrSt.PrioritySettingCd1;
            tempWork.PrioritySettingCd2 = campaignPrcPrSt.PrioritySettingCd2;
            tempWork.PrioritySettingCd3 = campaignPrcPrSt.PrioritySettingCd3;
            tempWork.PrioritySettingCd4 = campaignPrcPrSt.PrioritySettingCd4;
            tempWork.PrioritySettingCd5 = campaignPrcPrSt.PrioritySettingCd5;
            tempWork.PrioritySettingCd6 = campaignPrcPrSt.PrioritySettingCd6;

            pmtCmpPrcPrStList.Add(tempWork);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
        }
        #endregion
        // ----- ADD huangt 2013/07/12 Redmine#38116 キャンペーン売価優先設定マスタ追加 ----- <<<<<

        #endregion ◎ マスタ相関データ処理

        #region ◎ 部品検索した17個テーブル保存処理
        /// <summary>
        /// 部品検索結果をSCM DBに書込む処理
        /// </summary>
        /// <param name="partsInfoDB">部品除法対象</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="pmtPartsSearchWorkList">全て保存用リスト</param>
        /// <returns>ステータス</returns>
        private void GetPartsInfoToScmDBDataList(PartsInfoDataSet partsInfoDB, 
            string enterpriseCode, 
            string sectionCode, 
            string businessSessionId, 
            string pmTabSearchGuid, 
            ref CustomSerializeArrayList pmtPartsSearchWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GetPartsInfoToScmDBDataList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            try
            {
                List<PmtUrSubPtsTmpWork> pmtUrSubPtsTmpList = new List<PmtUrSubPtsTmpWork>();
                WriteUsrSubstParts(partsInfoDB.UsrSubstParts, ref pmtUrSubPtsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrSubPtsTmpList);

                List<PmtDSbPtInfoTmpWork> pmtDSbPtInfoTmpList = new List<PmtDSbPtInfoTmpWork>();
                WriteDSubstPartsInfo(partsInfoDB.DSubstPartsInfo, ref pmtDSbPtInfoTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtDSbPtInfoTmpList);

                // --- DEL 2013/08/01 三戸 Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //List<PmtGoodsSetTmpWork> pmtGoodsSetTmpList = new List<PmtGoodsSetTmpWork>();
                //WriteGoodsSet(partsInfoDB.GoodsSet, ref pmtGoodsSetTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                //pmtPartsSearchWorkList.Add(pmtGoodsSetTmpList);

                //List<PmtJoinPartsTmpWork> pmtJoinPartsTmpList = new List<PmtJoinPartsTmpWork>();
                //WriteJoinParts(partsInfoDB.JoinParts, ref pmtJoinPartsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                //pmtPartsSearchWorkList.Add(pmtJoinPartsTmpList);
                // --- DEL 2013/08/01 三戸 Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                List<PmtMdlPtDtlTmpWork> pmtMdlPtDtlTmpList = new List<PmtMdlPtDtlTmpWork>();
                WriteModelPartsDetail(partsInfoDB.ModelPartsDetail, ref pmtMdlPtDtlTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtMdlPtDtlTmpList);

                List<PmtOfrColInfTmpWork> pmtOfrColInfTmpList = new List<PmtOfrColInfTmpWork>();
                WriteOfrColorInfo(partsInfoDB.OfrColorInfo, ref pmtOfrColInfTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtOfrColInfTmpList);

                List<PmtOfrEqpInfTmpWork> pmtOfrEqpInfTmpList = new List<PmtOfrEqpInfTmpWork>();
                WriteOfrEquipInfo(partsInfoDB.OfrEquipInfo, ref pmtOfrEqpInfTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtOfrEqpInfTmpList);

                // --- DEL 2013/08/01 三戸 Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //List<PmtOfrPrmPtsTmpWork> pmtOfrPrmPtsTmpList = new List<PmtOfrPrmPtsTmpWork>();
                //WriteOfrPrimeParts(partsInfoDB.OfrPrimeParts, ref pmtOfrPrmPtsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                //pmtPartsSearchWorkList.Add(pmtOfrPrmPtsTmpList);
                // --- DEL 2013/08/01 三戸 Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                List<PmtOfrTrmInfTmpWork> pmtOfrTrmInfTmpList = new List<PmtOfrTrmInfTmpWork>();
                WriteOfrTrimInfo(partsInfoDB.OfrTrimInfo, ref pmtOfrTrmInfTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtOfrTrmInfTmpList);

                List<PmtPartsInfoTmpWork> pmtPartsInfoTmpList = new List<PmtPartsInfoTmpWork>();
                WritePartsInfo(partsInfoDB.PartsInfo, ref pmtPartsInfoTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtPartsInfoTmpList);

                List<PmtStockTmpWork> pmtStockTmpList = new List<PmtStockTmpWork>();
                WriteStock(partsInfoDB.Stock, ref pmtStockTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtStockTmpList);

                // --- DEL 2013/08/01 三戸 Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //List<PmtSbPtsInfoTmpWork> pmtSbPtsInfoTmpList = new List<PmtSbPtsInfoTmpWork>();
                //WriteSubstPartsInfo(partsInfoDB.SubstPartsInfo, ref pmtSbPtsInfoTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                //pmtPartsSearchWorkList.Add(pmtSbPtsInfoTmpList);
                // --- DEL 2013/08/01 三戸 Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                List<PmtTBOInfoTmpWork> pmtTBOInfoTmpList = new List<PmtTBOInfoTmpWork>();
                WriteTBOInfo(partsInfoDB.TBOInfo, ref pmtTBOInfoTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtTBOInfoTmpList);

                List<PmtUrGdsInfTmpWork> pmtUrGdsInfTmpList = new List<PmtUrGdsInfTmpWork>();
                WriteUsrGoodsInfo(partsInfoDB.UsrGoodsInfo, ref pmtUrGdsInfTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrGdsInfTmpList);

                List<PmtUrGdsPriTmpWork> pmtUrGdsPriTmpList = new List<PmtUrGdsPriTmpWork>();
                WriteUsrGoodsPrice(partsInfoDB.UsrGoodsPrice, ref pmtUrGdsPriTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrGdsPriTmpList);

                List<PmtUrJinPtsTmpWork> pmtUrJinPtsTmpList = new List<PmtUrJinPtsTmpWork>();
                WriteUsrJoinParts(partsInfoDB.UsrJoinParts, ref pmtUrJinPtsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrJinPtsTmpList);

                List<PmtUrSetPtsTmpWork> pmtUrSetPtsTmpList = new List<PmtUrSetPtsTmpWork>();
                WriteUsrSetParts(partsInfoDB.UsrSetParts, ref pmtUrSetPtsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrSetPtsTmpList);
            }
            catch (Exception ex)
            {
                string errMsg = ex.ToString();
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        }
        /// <summary>
        /// ユーザー代替検索データ新規操作
        /// </summary>
        /// <param name="usrSubstParts">ユーザー代替検索結果</param>
        /// <param name="pmtUrSubPtsTmpList">SCM DB用ユーザー代替検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteUsrSubstParts(PartsInfoDataSet.UsrSubstPartsDataTable usrSubstParts, 
            ref List<PmtUrSubPtsTmpWork> pmtUrSubPtsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteUsrSubstParts";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrSubstParts.Count; i++)
            {
                PartsInfoDataSet.UsrSubstPartsRow tempUsrSubstParts = usrSubstParts[i] as PartsInfoDataSet.UsrSubstPartsRow;

                PmtUrSubPtsTmpWork tempWork = new PmtUrSubPtsTmpWork();

                tempWork.ChgSrcMakerCd = (int)tempUsrSubstParts[usrSubstParts.ChgSrcMakerCdColumn.ColumnName];
                if ((Boolean)tempUsrSubstParts[usrSubstParts.OfferKubunColumn.ColumnName])
                {
                    tempWork.OfferKubun = 1;             
                }
                else
                {
                    tempWork.OfferKubun = 0;          
                }
                tempWork.ApplyEdDate = (int)tempUsrSubstParts[usrSubstParts.ApplyEdDateColumn.ColumnName];
                if ((Boolean)tempUsrSubstParts[usrSubstParts.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;    
                }
                else
                {
                    tempWork.SelectionState = 0;   
                }

                tempWork.ApplyStDate = (int)tempUsrSubstParts[usrSubstParts.ApplyStDateColumn.ColumnName];

                if (!(tempUsrSubstParts[usrSubstParts.ChgDestGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ChgDestGoodsNo = (string)tempUsrSubstParts[usrSubstParts.ChgDestGoodsNoColumn.ColumnName];
                }

                tempWork.ChgDestMakerCd = (int)tempUsrSubstParts[usrSubstParts.ChgDestMakerCdColumn.ColumnName];

                if (!(tempUsrSubstParts[usrSubstParts.ChgSrcGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ChgSrcGoodsNo = (string)tempUsrSubstParts[usrSubstParts.ChgSrcGoodsNoColumn.ColumnName];
                }

                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrSubPtsTmpList.Add(tempWork);
            }

            if (pmtUrSubPtsTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// 複数代替部品検索結果情報新規操作
        /// </summary>
        /// <param name="dSubstPartsInfo">複数代替部品検索結果情報</param>
        /// <param name="pmtDSbPtInfoTmpList">SCM DB用複数代替部品検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteDSubstPartsInfo(PartsInfoDataSet.DSubstPartsInfoDataTable dSubstPartsInfo, 
            ref List<PmtDSbPtInfoTmpWork> pmtDSbPtInfoTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteDSubstPartsInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < dSubstPartsInfo.Count; i++)
            {
                PartsInfoDataSet.DSubstPartsInfoRow tempDSubstPartsInfo = dSubstPartsInfo[i] as PartsInfoDataSet.DSubstPartsInfoRow;

                PmtDSbPtInfoTmpWork tempWork = new PmtDSbPtInfoTmpWork();

                tempWork.CatalogPartsMakerCd = (int)tempDSubstPartsInfo[dSubstPartsInfo.CatalogPartsMakerCdColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PartsNameKanaColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsNameKana = (string)tempDSubstPartsInfo[dSubstPartsInfo.PartsNameKanaColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.NewPrtsNoNoneHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewPrtsNoNoneHyphen = (string)tempDSubstPartsInfo[dSubstPartsInfo.NewPrtsNoNoneHyphenColumn.ColumnName];
                }

                if ((Boolean)tempDSubstPartsInfo[dSubstPartsInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                tempWork.PartsSearchCode = (int)tempDSubstPartsInfo[dSubstPartsInfo.PartsSearchCodeColumn.ColumnName];
                tempWork.PartsCode = (int)tempDSubstPartsInfo[dSubstPartsInfo.PartsCodeColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PartsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsName = (string)tempDSubstPartsInfo[dSubstPartsInfo.PartsNameColumn.ColumnName];
                }
                tempWork.PartsInfoCtrlFlg = (int)tempDSubstPartsInfo[dSubstPartsInfo.PartsInfoCtrlFlgColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PartsLayerCdColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsLayerCd = (string)tempDSubstPartsInfo[dSubstPartsInfo.PartsLayerCdColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.MakerOfferPartsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.MakerOfferPartsName = (string)tempDSubstPartsInfo[dSubstPartsInfo.MakerOfferPartsNameColumn.ColumnName];
                }
                tempWork.TbsPartsCdDerivedNo = (int)tempDSubstPartsInfo[dSubstPartsInfo.TbsPartsCdDerivedNoColumn.ColumnName];
                tempWork.TbsPartsCode = (int)tempDSubstPartsInfo[dSubstPartsInfo.TbsPartsCodeColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PlrlSubNewPrtNoHypnColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PlrlSubNewPrtNoHypn = (string)tempDSubstPartsInfo[dSubstPartsInfo.PlrlSubNewPrtNoHypnColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PartsPluralSubstCmntColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsPluralSubstCmnt = (string)tempDSubstPartsInfo[dSubstPartsInfo.PartsPluralSubstCmntColumn.ColumnName];
                }
                tempWork.PartsQty = (double)tempDSubstPartsInfo[dSubstPartsInfo.PartsQtyColumn.ColumnName];
                tempWork.MainOrSubPartsDivCd = (int)tempDSubstPartsInfo[dSubstPartsInfo.MainOrSubPartsDivCdColumn.ColumnName];
                tempWork.PartsPluralSubstFlg = (int)tempDSubstPartsInfo[dSubstPartsInfo.PartsPluralSubstFlgColumn.ColumnName];
                tempWork.NPrtNoWithHypnDspOdr = (int)tempDSubstPartsInfo[dSubstPartsInfo.NPrtNoWithHypnDspOdrColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.NewPartsNoWithHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewPartsNoWithHyphen = (string)tempDSubstPartsInfo[dSubstPartsInfo.NewPartsNoWithHyphenColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.OldPartsNoWithHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OldPartsNoWithHyphen = (string)tempDSubstPartsInfo[dSubstPartsInfo.OldPartsNoWithHyphenColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.CatalogPartsMakerNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.CatalogPartsMakerNm = (string)tempDSubstPartsInfo[dSubstPartsInfo.CatalogPartsMakerNmColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtDSbPtInfoTmpList.Add(tempWork);
            }

            if (pmtDSbPtInfoTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        #region 2013/08/01 三戸 削除
        // --- DEL 2013/08/01 三戸 Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// セット部品検索結果情報新規操作
        ///// </summary>
        ///// <param name="goodsSet">セット部品検索結果情報</param>
        ///// <param name="pmtGoodsSetTmpList">SCM DB用セット部品検索結果リスト</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="businessSessionId">業務セッションID</param>
        ///// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        ///// <returns>ステータス</returns>
        //private int WriteGoodsSet(PartsInfoDataSet.GoodsSetDataTable goodsSet, 
        //    ref List<PmtGoodsSetTmpWork> pmtGoodsSetTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    const string methodName = "WriteGoodsSet";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    for (int i = 0; i < goodsSet.Count; i++)
        //    {
        //        PartsInfoDataSet.GoodsSetRow tempGoodsSet = goodsSet[i] as PartsInfoDataSet.GoodsSetRow;

        //        PmtGoodsSetTmpWork tempWork = new PmtGoodsSetTmpWork();

        //        tempWork.GoodsMGroup = (int)tempGoodsSet[goodsSet.GoodsMGroupColumn.ColumnName];

        //        if (!(tempGoodsSet[goodsSet.PrimePartsKanaNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsKanaName = (string)tempGoodsSet[goodsSet.PrimePartsKanaNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.OfferDateColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.OfferDate = (DateTime)tempGoodsSet[goodsSet.OfferDateColumn.ColumnName];
        //        }

        //        if ((Boolean)tempGoodsSet[goodsSet.SelectionStateColumn.ColumnName])
        //        {
        //            tempWork.SelectionState = 1;
        //        }
        //        else
        //        {
        //            tempWork.SelectionState = 0;
        //        }

        //        if (!(tempGoodsSet[goodsSet.SetSubMakerNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.SetSubMakerName = (string)tempGoodsSet[goodsSet.SetSubMakerNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.SetSubPartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.SetSubPartsName = (string)tempGoodsSet[goodsSet.SetSubPartsNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.SubGoodsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.SubGoodsName = (string)tempGoodsSet[goodsSet.SubGoodsNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.ParentGoodsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.ParentGoodsName = (string)tempGoodsSet[goodsSet.ParentGoodsNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.CatalogShapeNoColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.CatalogShapeNo = (string)tempGoodsSet[goodsSet.CatalogShapeNoColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.SetSpecialNoteColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.SetSpecialNote = (string)tempGoodsSet[goodsSet.SetSpecialNoteColumn.ColumnName];    // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される               
        //            tempWork.SetSpecialNote = GetSubString((string)tempGoodsSet[goodsSet.SetSpecialNoteColumn.ColumnName], 40);     // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
        //        }

        //        if (!(tempGoodsSet[goodsSet.SetNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.SetName = (string)tempGoodsSet[goodsSet.SetNameColumn.ColumnName];
        //        }
        //        tempWork.SetQty = (double)tempGoodsSet[goodsSet.SetQtyColumn.ColumnName];
        //        tempWork.SetDisplayOrder = (int)tempGoodsSet[goodsSet.SetDisplayOrderColumn.ColumnName];

        //        if (!(tempGoodsSet[goodsSet.SetSubPartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.SetSubPartsNo = (string)tempGoodsSet[goodsSet.SetSubPartsNoColumn.ColumnName];   // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
        //            tempWork.SetSubPartsNo = GetSubString((string)tempGoodsSet[goodsSet.SetSubPartsNoColumn.ColumnName], 24);      // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
        //        }
        //        tempWork.SetSubMakerCd = (int)tempGoodsSet[goodsSet.SetSubMakerCdColumn.ColumnName];

        //        if (!(tempGoodsSet[goodsSet.SetMainPartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.SetMainPartsNo = (string)tempGoodsSet[goodsSet.SetMainPartsNoColumn.ColumnName];    // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
        //            tempWork.SetMainPartsNo = GetSubString((string)tempGoodsSet[goodsSet.SetMainPartsNoColumn.ColumnName], 24);      // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
        //        }

        //        tempWork.SetMainMakerCd = (int)tempGoodsSet[goodsSet.SetMainMakerCdColumn.ColumnName];
        //        tempWork.TbsPartsCdDerivedNo = (int)tempGoodsSet[goodsSet.TbsPartsCdDerivedNoColumn.ColumnName];
        //        tempWork.TbsPartsCode = (int)tempGoodsSet[goodsSet.TbsPartsCodeColumn.ColumnName];
        //        tempWork.BusinessSessionId = businessSessionId;
        //        tempWork.EnterpriseCode = enterpriseCode;
        //        tempWork.SearchSectionCode = sectionCode;
        //        tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
        //        //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
        //        tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
        //        tempWork.PmTabSearchRowNum = i + 1;

        //        pmtGoodsSetTmpList.Add(tempWork);
        //    }

        //    if (pmtGoodsSetTmpList.Count > 0)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        //    return status;
        //}

        ///// <summary>
        ///// 結合部品検索結果情報新規操作
        ///// </summary>
        ///// <param name="joinParts">結合部品検索結果情報</param>
        ///// <param name="pmtJoinPartsTmpList">SCM DB用結合部品検索結果</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="businessSessionId">業務セッションID</param>
        ///// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        ///// <returns>ステータス</returns>
        //private int WriteJoinParts(PartsInfoDataSet.JoinPartsDataTable joinParts,
        //    ref List<PmtJoinPartsTmpWork> pmtJoinPartsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    const string methodName = "WriteJoinParts";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    for (int i = 0; i < joinParts.Count; i++)
        //    {
        //        PartsInfoDataSet.JoinPartsRow tempJoinParts = joinParts[i] as PartsInfoDataSet.JoinPartsRow;

        //        PmtJoinPartsTmpWork tempWork = new PmtJoinPartsTmpWork();

        //        tempWork.GoodsMGroup = (int)tempJoinParts[joinParts.GoodsMGroupColumn.ColumnName];

        //        if (!(tempJoinParts[joinParts.PrimePartsKanaNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsKanaName = (string)tempJoinParts[joinParts.PrimePartsKanaNameColumn.ColumnName];
        //        }

        //        if (!(tempJoinParts[joinParts.OfferDateColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.OfferDate = (DateTime)tempJoinParts[joinParts.OfferDateColumn.ColumnName];
        //        }

        //        if (!(tempJoinParts[joinParts.JoinDestMakerNmColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.JoinDestMakerNm = (string)tempJoinParts[joinParts.JoinDestMakerNmColumn.ColumnName];
        //        }

        //        if (!(tempJoinParts[joinParts.PrimePartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsName = (string)tempJoinParts[joinParts.PrimePartsNameColumn.ColumnName];
        //        }
        //        tempWork.SetPartsFlg = (int)tempJoinParts[joinParts.SetPartsFlgColumn.ColumnName];

        //        if ((Boolean)tempJoinParts[joinParts.SelectionStateColumn.ColumnName])
        //        {
        //            tempWork.SelectionState = 1;
        //        }
        //        else
        //        {
        //            tempWork.SelectionState = 0; 
        //        }

        //        if (!(tempJoinParts[joinParts.JoinSpecialNoteColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.JoinSpecialNote = (string)tempJoinParts[joinParts.JoinSpecialNoteColumn.ColumnName];     // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
        //            tempWork.JoinSpecialNote = GetSubString((string)tempJoinParts[joinParts.JoinSpecialNoteColumn.ColumnName], 40);      // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
        //        }

        //        tempWork.JoinQty = (double)tempJoinParts[joinParts.JoinQtyColumn.ColumnName];

        //        if (!(tempJoinParts[joinParts.JoinDestPartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.JoinDestPartsNo = (string)tempJoinParts[joinParts.JoinDestPartsNoColumn.ColumnName];
        //        }

        //        tempWork.JoinDestMakerCd = (int)tempJoinParts[joinParts.JoinDestMakerCdColumn.ColumnName];

        //        if (!(tempJoinParts[joinParts.JoinSourPartsNoNoneHColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.JoinSourPartsNoNoneH = (string)tempJoinParts[joinParts.JoinSourPartsNoNoneHColumn.ColumnName];
        //        }

        //        if (!(tempJoinParts[joinParts.JoinSourPartsNoWithHColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.JoinSourPartsNoWithH = (string)tempJoinParts[joinParts.JoinSourPartsNoWithHColumn.ColumnName];
        //        }

        //        tempWork.JoinSourceMakerCode = (int)tempJoinParts[joinParts.JoinSourceMakerCodeColumn.ColumnName];
        //        tempWork.JoinDispOrder = (int)tempJoinParts[joinParts.JoinDispOrderColumn.ColumnName];
        //        tempWork.PrmSetDtlNo2 = (int)tempJoinParts[joinParts.PrmSetDtlNo2Column.ColumnName];
        //        tempWork.PrmSetDtlNo1 = (int)tempJoinParts[joinParts.PrmSetDtlNo1Column.ColumnName];
        //        tempWork.TbsPartsCdDerivedNo = (int)tempJoinParts[joinParts.TbsPartsCdDerivedNoColumn.ColumnName];
        //        tempWork.TbsPartsCode = (int)tempJoinParts[joinParts.TbsPartsCodeColumn.ColumnName];
        //        tempWork.BusinessSessionId = businessSessionId;
        //        tempWork.EnterpriseCode = enterpriseCode;
        //        tempWork.SearchSectionCode = sectionCode;
        //        tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
        //        //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
        //        tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
        //        tempWork.PmTabSearchRowNum = i + 1;

        //        pmtJoinPartsTmpList.Add(tempWork);
        //    }

        //    if (pmtJoinPartsTmpList.Count > 0)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        //    return status;
        //}
        // --- DEL 2013/08/01 三戸 Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion 2013/08/01 三戸 削除

        /// <summary>
        /// 部品関連型式検索結果情報新規操作
        /// </summary>
        /// <param name="modelPartsDetail">部品関連型式検索結果情報</param>
        /// <param name="pmtMdlPtDtlTmpList">SCM DB用部品関連型式検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteModelPartsDetail(PartsInfoDataSet.ModelPartsDetailDataTable modelPartsDetail,
            ref List<PmtMdlPtDtlTmpWork> pmtMdlPtDtlTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteModelPartsDetail";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < modelPartsDetail.Count; i++)
            {
                PartsInfoDataSet.ModelPartsDetailRow tempModelPartsDetail = modelPartsDetail[i] as PartsInfoDataSet.ModelPartsDetailRow;

                PmtMdlPtDtlTmpWork tempWork = new PmtMdlPtDtlTmpWork();

                tempWork.FullModelFixedNo = (int)tempModelPartsDetail[modelPartsDetail.FullModelFixedNoColumn.ColumnName];
                if (!(tempModelPartsDetail[modelPartsDetail.WheelDriveMethodNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WheelDriveMethodNm = (string)tempModelPartsDetail[modelPartsDetail.WheelDriveMethodNmColumn.ColumnName];
                }

                if ((Boolean)tempModelPartsDetail[modelPartsDetail.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1; 
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                if (!(tempModelPartsDetail[modelPartsDetail.PartsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsNo = (string)tempModelPartsDetail[modelPartsDetail.PartsNoColumn.ColumnName];
                }
                tempWork.PartsMakerCd = (int)tempModelPartsDetail[modelPartsDetail.PartsMakerCdColumn.ColumnName];
                tempWork.PartsUniqueNo = (long)tempModelPartsDetail[modelPartsDetail.PartsUniqueNoColumn.ColumnName];

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle6Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle6 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle6Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle5Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle5 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle5Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle4Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle4 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle4Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle3Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle3 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle3Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle2Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle2 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle2Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle1Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle1 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle1Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec6Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec6 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec6Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec5Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec5 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec5Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec4Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec4 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec4Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec3Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec3 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec3Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec2Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec2 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec2Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec1Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec1 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec1Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.ShiftNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ShiftNm = (string)tempModelPartsDetail[modelPartsDetail.ShiftNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.TransmissionNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.TransmissionNm = (string)tempModelPartsDetail[modelPartsDetail.TransmissionNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.EDivNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EDivNm = (string)tempModelPartsDetail[modelPartsDetail.EDivNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.EngineDisplaceNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EngineDisplaceNm = (string)tempModelPartsDetail[modelPartsDetail.EngineDisplaceNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.EngineModelNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EngineModelNmRD = (string)tempModelPartsDetail[modelPartsDetail.EngineModelNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.ModelGradeNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ModelGradeNm = (string)tempModelPartsDetail[modelPartsDetail.ModelGradeNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.BodyNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.BodyName = (string)tempModelPartsDetail[modelPartsDetail.BodyNameColumn.ColumnName];
                }

                tempWork.DoorCount = (int)tempModelPartsDetail[modelPartsDetail.DoorCountColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtMdlPtDtlTmpList.Add(tempWork);
            }

            if (pmtMdlPtDtlTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// 提供カラー検索結果情報新規操作
        /// </summary>
        /// <param name="ofrColorInfo">提供カラー検索結果情報</param>
        /// <param name="pmtOfrColInfTmpList">SCM DB用提供カラー検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteOfrColorInfo(PartsInfoDataSet.OfrColorInfoDataTable ofrColorInfo,
            ref List<PmtOfrColInfTmpWork> pmtOfrColInfTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteOfrColorInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < ofrColorInfo.Count; i++)
            {
                PartsInfoDataSet.OfrColorInfoRow tempOfrColorInfo = ofrColorInfo[i] as PartsInfoDataSet.OfrColorInfoRow;

                PmtOfrColInfTmpWork tempWork = new PmtOfrColInfTmpWork();

                tempWork.PartsProperNo = (long)tempOfrColorInfo[ofrColorInfo.PartsProperNoColumn.ColumnName];

                if (!(tempOfrColorInfo[ofrColorInfo.ColorNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ColorName = (string)tempOfrColorInfo[ofrColorInfo.ColorNameColumn.ColumnName];
                }

                if ((Boolean)tempOfrColorInfo[ofrColorInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                if (!(tempOfrColorInfo[ofrColorInfo.ColorCdInfoNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ColorCdInfoNo = (string)tempOfrColorInfo[ofrColorInfo.ColorCdInfoNoColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtOfrColInfTmpList.Add(tempWork);
            }

            if (pmtOfrColInfTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// 提供装備検索結果情報新規操作
        /// </summary>
        /// <param name="ofrEquipInfo">提供装備検索結果情報</param>
        /// <param name="pmtOfrEqpInfTmpList">SCM DB用提供装備検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteOfrEquipInfo(PartsInfoDataSet.OfrEquipInfoDataTable ofrEquipInfo,
            ref List<PmtOfrEqpInfTmpWork> pmtOfrEqpInfTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteOfrEquipInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < ofrEquipInfo.Count; i++)
            {
                PartsInfoDataSet.OfrEquipInfoRow tempOfrEquipInfo = ofrEquipInfo[i] as PartsInfoDataSet.OfrEquipInfoRow;

                PmtOfrEqpInfTmpWork tempWork = new PmtOfrEqpInfTmpWork();

                tempWork.PartsProperNo = (long)tempOfrEquipInfo[ofrEquipInfo.PartsProperNoColumn.ColumnName];

                if (!(tempOfrEquipInfo[ofrEquipInfo.EquipmentShortNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EquipmentShortName = (string)tempOfrEquipInfo[ofrEquipInfo.EquipmentShortNameColumn.ColumnName];
                }
                tempWork.EquipmentDispOrder = (int)tempOfrEquipInfo[ofrEquipInfo.EquipmentDispOrderColumn.ColumnName];
                tempWork.EquipmentIconCode = (int)tempOfrEquipInfo[ofrEquipInfo.EquipmentIconCodeColumn.ColumnName];

                if (!(tempOfrEquipInfo[ofrEquipInfo.EquipmentNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EquipmentName = (string)tempOfrEquipInfo[ofrEquipInfo.EquipmentNameColumn.ColumnName];
                }

                if (!(tempOfrEquipInfo[ofrEquipInfo.EquipmentGenreNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EquipmentGenreNm = (string)tempOfrEquipInfo[ofrEquipInfo.EquipmentGenreNmColumn.ColumnName];
                }

                if ((Boolean)tempOfrEquipInfo[ofrEquipInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }
                tempWork.EquipmentCode = (int)tempOfrEquipInfo[ofrEquipInfo.EquipmentCodeColumn.ColumnName];
                tempWork.EquipmentGenreCd = (int)tempOfrEquipInfo[ofrEquipInfo.EquipmentGenreCdColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtOfrEqpInfTmpList.Add(tempWork);
            }

            if (pmtOfrEqpInfTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        #region 2013/08/01 三戸 削除
        // --- DEL 2013/08/01 三戸 Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 提供優良部品検索結果情報新規操作
        ///// </summary>
        ///// <param name="ofrPrimeParts">提供優良部品検索結果情報</param>
        ///// <param name="pmtOfrPrmPtsTmpList">SCM DB用提供優良部品検索結果リスト</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="businessSessionId">業務セッションID</param>
        ///// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        ///// <returns>ステータス</returns>
        //private int WriteOfrPrimeParts(PartsInfoDataSet.OfrPrimePartsDataTable ofrPrimeParts,
        //    ref List<PmtOfrPrmPtsTmpWork> pmtOfrPrmPtsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    const string methodName = "WriteOfrPrimeParts";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    for (int i = 0; i < ofrPrimeParts.Count; i++)
        //    {
        //        PmtOfrPrmPtsTmpWork tempWork = new PmtOfrPrmPtsTmpWork();

        //        PartsInfoDataSet.OfrPrimePartsRow tempOfrPrimeParts = ofrPrimeParts[i] as PartsInfoDataSet.OfrPrimePartsRow;

        //        tempWork.GoodsMGroup = (int)tempOfrPrimeParts[ofrPrimeParts.GoodsMGroupColumn.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimePartsKanaNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsKanaName = (string)tempOfrPrimeParts[ofrPrimeParts.PrimePartsKanaNameColumn.ColumnName];
        //        }
        //        tempWork.PrmPartsProperNo = (long)tempOfrPrimeParts[ofrPrimeParts.PrmPartsProperNoColumn.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.OfferDateColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.OfferDate = (DateTime)tempOfrPrimeParts[ofrPrimeParts.OfferDateColumn.ColumnName];
        //        }
        //        tempWork.PrimeSearchDispOrder = (int)tempOfrPrimeParts[ofrPrimeParts.PrimeSearchDispOrderColumn.ColumnName];
        //        tempWork.PrimeDispOrder = (int)tempOfrPrimeParts[ofrPrimeParts.PrimeDispOrderColumn.ColumnName];
        //        tempWork.MakerDispOrder = (int)tempOfrPrimeParts[ofrPrimeParts.MakerDispOrderColumn.ColumnName];

        //        if ((Boolean)tempOfrPrimeParts[ofrPrimeParts.SelectionStateColumn.ColumnName])
        //        {
        //            tempWork.SelectionState = 1; 
        //        }
        //        else
        //        {
        //            tempWork.SelectionState = 0; 
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PartsMakerNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsMakerName = (string)tempOfrPrimeParts[ofrPrimeParts.PartsMakerNameColumn.ColumnName];
        //        }
        //        tempWork.EdProduceFrameNo = (int)tempOfrPrimeParts[ofrPrimeParts.EdProduceFrameNoColumn.ColumnName];
        //        tempWork.StProduceFrameNo = (int)tempOfrPrimeParts[ofrPrimeParts.StProduceFrameNoColumn.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.EdProduceTypeOfYearColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.EdProduceTypeOfYear = (DateTime)tempOfrPrimeParts[ofrPrimeParts.EdProduceTypeOfYearColumn.ColumnName];
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.StProduceTypeOfYearColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.StProduceTypeOfYear = (DateTime)tempOfrPrimeParts[ofrPrimeParts.StProduceTypeOfYearColumn.ColumnName];
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimeSpecialNoteColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimeSpecialNote = (string)tempOfrPrimeParts[ofrPrimeParts.PrimeSpecialNoteColumn.ColumnName];
        //        }
        //        tempWork.PrimeQty = (double)tempOfrPrimeParts[ofrPrimeParts.PrimeQtyColumn.ColumnName];
        //        tempWork.SetPartsFlg = (int)tempOfrPrimeParts[ofrPrimeParts.SetPartsFlgColumn.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimeOldPartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimeOldPartsNo = (string)tempOfrPrimeParts[ofrPrimeParts.PrimeOldPartsNoColumn.ColumnName];
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimePartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsNo = (string)tempOfrPrimeParts[ofrPrimeParts.PrimePartsNoColumn.ColumnName];
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimePartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.PrimePartsName = (string)tempOfrPrimeParts[ofrPrimeParts.PrimePartsNameColumn.ColumnName];       // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
        //            tempWork.PrimePartsName = GetSubString((string)tempOfrPrimeParts[ofrPrimeParts.PrimePartsNameColumn.ColumnName], 40);     // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
        //        }

        //        tempWork.PrmSetDtlNo2 = (int)tempOfrPrimeParts[ofrPrimeParts.PrmSetDtlNo2Column.ColumnName];
        //        tempWork.PrmSetDtlNo1 = (int)tempOfrPrimeParts[ofrPrimeParts.PrmSetDtlNo1Column.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PartsMakerCdColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsMakerCd = (string)tempOfrPrimeParts[ofrPrimeParts.PartsMakerCdColumn.ColumnName];
        //        }

        //        tempWork.TbsPartsCdDerivedNo = (int)tempOfrPrimeParts[ofrPrimeParts.TbsPartsCdDerivedNoColumn.ColumnName];
        //        tempWork.TbsPartsCode = (int)tempOfrPrimeParts[ofrPrimeParts.TbsPartsCodeColumn.ColumnName];
        //        tempWork.BusinessSessionId = businessSessionId;
        //        tempWork.EnterpriseCode = enterpriseCode;
        //        tempWork.SearchSectionCode = sectionCode;
        //        tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
        //        //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
        //        tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
        //        tempWork.PmTabSearchRowNum = i + 1;

        //        pmtOfrPrmPtsTmpList.Add(tempWork);
        //    }

        //    if (pmtOfrPrmPtsTmpList.Count > 0)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        //    return status;
        //}
        // --- DEL 2013/08/01 三戸 Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion 2013/08/01 三戸 削除

        /// <summary>
        /// 提供トリム検索結果情報新規操作
        /// </summary>
        /// <param name="ofrTrimInfo">提供トリム検索結果情報</param>
        /// <param name="pmtOfrTrmInfTmpList">SCM DB用提供トリム検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteOfrTrimInfo(PartsInfoDataSet.OfrTrimInfoDataTable ofrTrimInfo,
            ref List<PmtOfrTrmInfTmpWork> pmtOfrTrmInfTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteOfrTrimInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < ofrTrimInfo.Count; i++)
            {
                PmtOfrTrmInfTmpWork tempWork = new PmtOfrTrmInfTmpWork();

                PartsInfoDataSet.OfrTrimInfoRow tempOfrTrimInfo = ofrTrimInfo[i] as PartsInfoDataSet.OfrTrimInfoRow;

                tempWork.PartsProperNo = (long)tempOfrTrimInfo[ofrTrimInfo.PartsProperNoColumn.ColumnName];

                if (!(tempOfrTrimInfo[ofrTrimInfo.TrimNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.TrimName = (string)tempOfrTrimInfo[ofrTrimInfo.TrimNameColumn.ColumnName];
                }

                if ((Boolean)tempOfrTrimInfo[ofrTrimInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;  
                }
                else
                {
                    tempWork.SelectionState = 0; 
                }

                if (!(tempOfrTrimInfo[ofrTrimInfo.TrimCodeColumn.ColumnName] is System.DBNull))
                {
                    tempWork.TrimCode = (string)tempOfrTrimInfo[ofrTrimInfo.TrimCodeColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtOfrTrmInfTmpList.Add(tempWork);
            }

            if (pmtOfrTrmInfTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// 純正部品検索結果情報新規操作
        /// </summary>
        /// <param name="partsInfo">純正部品検索結果情報</param>
        /// <param name="pmtPartsInfoTmpList">SCM DB 純正部品検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WritePartsInfo(PartsInfoDataSet.PartsInfoDataTable partsInfo,
            ref List<PmtPartsInfoTmpWork> pmtPartsInfoTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WritePartsInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < partsInfo.Count; i++)
            {
                PmtPartsInfoTmpWork tempWork = new PmtPartsInfoTmpWork();

                PartsInfoDataSet.PartsInfoRow tempPartsInfo = partsInfo[i] as PartsInfoDataSet.PartsInfoRow;

                tempWork.PartsSearchCode = (int)tempPartsInfo[partsInfo.PartsSearchCodeColumn.ColumnName];
                if (!(tempPartsInfo[partsInfo.TbsPartsCdDerivedNmColumn.ColumnName] is System.DBNull)) 
                {
                    tempWork.AutoEstimatePartsCd = (string)tempPartsInfo[partsInfo.AutoEstimatePartsCdColumn.ColumnName];
                }
                tempWork.TbsPartsCodeFS = (int)tempPartsInfo[partsInfo.TbsPartsCodeFSColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.FreSrchPrtPropNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.FreSrchPrtPropNo = (string)tempPartsInfo[partsInfo.FreSrchPrtPropNoColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.ExhaustGasSignColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ExhaustGasSign = (string)tempPartsInfo[partsInfo.ExhaustGasSignColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.CategorySignModelColumn.ColumnName] is System.DBNull))
                {
                    tempWork.CategorySignModel = (string)tempPartsInfo[partsInfo.CategorySignModelColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.SeriesModelColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SeriesModel = (string)tempPartsInfo[partsInfo.SeriesModelColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.PartsNameKanaColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsNameKana = (string)tempPartsInfo[partsInfo.PartsNameKanaColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.OfferDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OfferDate = (DateTime)tempPartsInfo[partsInfo.OfferDateColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.NewPrtsNoNoneHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewPrtsNoNoneHyphen = (string)tempPartsInfo[partsInfo.NewPrtsNoNoneHyphenColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.NewPrtsNoWithHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewPrtsNoWithHyphen = (string)tempPartsInfo[partsInfo.NewPrtsNoWithHyphenColumn.ColumnName];
                }

                if ((Boolean)tempPartsInfo[partsInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                tempWork.PartsUniqueNo = (long)tempPartsInfo[partsInfo.PartsUniqueNoColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.PartsLayerCdColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsLayerCd = (string)tempPartsInfo[partsInfo.PartsLayerCdColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.MakerOfferPartsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.MakerOfferPartsName = (string)tempPartsInfo[partsInfo.MakerOfferPartsNameColumn.ColumnName];
                }

                tempWork.EquipNarrowingFlag = (int)tempPartsInfo[partsInfo.EquipNarrowingFlagColumn.ColumnName];
                tempWork.TrimNarrowingFlag = (int)tempPartsInfo[partsInfo.TrimNarrowingFlagColumn.ColumnName];
                tempWork.ColorNarrowingFlag = (int)tempPartsInfo[partsInfo.ColorNarrowingFlagColumn.ColumnName];
                tempWork.ColdDistrictsFlag = (int)tempPartsInfo[partsInfo.ColdDistrictsFlagColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ClgPrtsNoWithHyphen = (string)tempPartsInfo[partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.CatalogPartsMakerNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.CatalogPartsMakerNm = (string)tempPartsInfo[partsInfo.CatalogPartsMakerNmColumn.ColumnName];
                }

                tempWork.CatalogPartsMakerCd = (int)tempPartsInfo[partsInfo.CatalogPartsMakerCdColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.StandardNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.StandardName = (string)tempPartsInfo[partsInfo.StandardNameColumn.ColumnName];
                }


                if (!(tempPartsInfo[partsInfo.PartsOpNmColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.PartsOpNm = (string)tempPartsInfo[partsInfo.PartsOpNmColumn.ColumnName];    // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                    tempWork.PartsOpNm = GetSubString((string)tempPartsInfo[partsInfo.PartsOpNmColumn.ColumnName], 60);    // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                }
                tempWork.PartsQty = (double)tempPartsInfo[partsInfo.PartsQtyColumn.ColumnName];
                tempWork.ModelPrtsAblsFrameNo = (int)tempPartsInfo[partsInfo.ModelPrtsAblsFrameNoColumn.ColumnName];
                tempWork.ModelPrtsAdptFrameNo = (int)tempPartsInfo[partsInfo.ModelPrtsAdptFrameNoColumn.ColumnName];

                //-----DEL songg 2013/06/25 障害報告 #37010の対応 年月は999999の場合、DateTime.MaxValueを設定する---->>>>>
                //if (0 != (int)tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName])
                //{
                //    string modelPrtsAblsYm = tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName].ToString();
                //    string year = modelPrtsAblsYm.Substring(0, 4);
                //    string month = modelPrtsAblsYm.Substring(4, 2);
                //    DateTime tempModelPrtsAblsYm = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
                //    tempWork.ModelPrtsAblsYm = tempModelPrtsAblsYm;
                //}
                //-----DEL songg 2013/06/25 障害報告 #37010の対応 年月は999999の場合、DateTime.MaxValueを設定する----<<<<<
                //-----ADD songg 2013/06/25 障害報告 #37010の対応 年月は999999の場合、DateTime.MaxValueを設定する---->>>>>
                if (999999 == (int)tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName])
                {
                    tempWork.ModelPrtsAblsYm = DateTime.MaxValue;
                }
                else if (0 != (int)tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName])
                {
                    string modelPrtsAblsYm = tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName].ToString();
                    string year = modelPrtsAblsYm.Substring(0, 4);
                    string month = modelPrtsAblsYm.Substring(4, 2);
                    DateTime tempModelPrtsAblsYm = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
                    tempWork.ModelPrtsAblsYm = tempModelPrtsAblsYm;
                }
                //-----ADD songg 2013/06/25 障害報告 #37010の対応 年月は999999の場合、DateTime.MaxValueを設定する----<<<<<

                //-----DEL songg 2013/06/25 障害報告 #37010の対応 年月は999999の場合、DateTime.MaxValueを設定する---->>>>>
                //if (0 != (int)tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName])
                //{
                //    string modelPrtsAdptYm = tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName].ToString();
                //    string year = modelPrtsAdptYm.Substring(0, 4);
                //    string month = modelPrtsAdptYm.Substring(4, 2);
                //    DateTime tempModelPrtsAdptYm = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
                //    tempWork.ModelPrtsAdptYm = tempModelPrtsAdptYm;
                //}
                //-----DEL songg 2013/06/25 障害報告 #37010の対応 年月は999999の場合、DateTime.MaxValueを設定する----<<<<<
                //-----ADD songg 2013/06/25 障害報告 #37010の対応 年月は999999の場合、DateTime.MaxValueを設定する---->>>>>
                if (999999 == (int)tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName])
                {
                    tempWork.ModelPrtsAdptYm = DateTime.MaxValue;
                }
                else if (0 != (int)tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName])
                {
                    string modelPrtsAdptYm = tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName].ToString();
                    string year = modelPrtsAdptYm.Substring(0, 4);
                    string month = modelPrtsAdptYm.Substring(4, 2);
                    DateTime tempModelPrtsAdptYm = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
                    tempWork.ModelPrtsAdptYm = tempModelPrtsAdptYm;
                }
                //-----ADD songg 2013/06/25 障害報告 #37010の対応 年月は999999の場合、DateTime.MaxValueを設定する----<<<<<

                if (!(tempPartsInfo[partsInfo.FigshapeNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.FigshapeNo = (string)tempPartsInfo[partsInfo.FigshapeNoColumn.ColumnName];
                }
                tempWork.TbsPartsCdDerivedNo = (int)tempPartsInfo[partsInfo.TbsPartsCdDerivedNoColumn.ColumnName];
                tempWork.TbsPartsCode = (int)tempPartsInfo[partsInfo.TbsPartsCodeColumn.ColumnName];
                tempWork.FullModelFixedNo = (int)tempPartsInfo[partsInfo.FullModelFixedNoColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.WorkOrPartsDivNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WorkOrPartsDivNm = (string)tempPartsInfo[partsInfo.WorkOrPartsDivNmColumn.ColumnName];
                }
                tempWork.PartsCode = (int)tempPartsInfo[partsInfo.PartsCodeColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.PartsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsName = (string)tempPartsInfo[partsInfo.PartsNameColumn.ColumnName];
                }

                tempWork.PartsNarrowingCode = (int)tempPartsInfo[partsInfo.PartsNarrowingCodeColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtPartsInfoTmpList.Add(tempWork);
            }

            if (pmtPartsInfoTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// 在庫検索結果情報新規操作
        /// </summary>
        /// <param name="stock">在庫検索結果情報</param>
        /// <param name="pmtStockTmpList">SCM DB用在庫検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteStock(PartsInfoDataSet.StockDataTable stock,
            ref List<PmtStockTmpWork> pmtStockTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteStock";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < stock.Count; i++)
            {
                PmtStockTmpWork tempWork = new PmtStockTmpWork();

                PartsInfoDataSet.StockRow tempPartsInfo = stock[i] as PartsInfoDataSet.StockRow;

                tempWork.AcpOdrCount = (double)tempPartsInfo[stock.AcpOdrCountColumn.ColumnName];
                tempWork.ArrivalCnt = (double)tempPartsInfo[stock.ArrivalCntColumn.ColumnName];
                if (!(tempPartsInfo[stock.DuplicationShelfNo1Column.ColumnName] is System.DBNull))
                {
                    tempWork.DuplicationShelfNo1 = (string)tempPartsInfo[stock.DuplicationShelfNo1Column.ColumnName];
                }
                if (!(tempPartsInfo[stock.DuplicationShelfNo2Column.ColumnName] is System.DBNull))
                {
                    tempWork.DuplicationShelfNo2 = (string)tempPartsInfo[stock.DuplicationShelfNo2Column.ColumnName];
                }
                if (!(tempPartsInfo[stock.EnterpriseCodeColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EnterpriseCode = (string)tempPartsInfo[stock.EnterpriseCodeColumn.ColumnName];
                }
                tempWork.GoodsMakerCd = (int)tempPartsInfo[stock.GoodsMakerCdColumn.ColumnName];
                if (!(tempPartsInfo[stock.GoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNo = (string)tempPartsInfo[stock.GoodsNoColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.GoodsNoNoneHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNoNoneHyphen = (string)tempPartsInfo[stock.GoodsNoNoneHyphenColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.LastInventoryUpdateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.LastInventoryUpdate = (DateTime)tempPartsInfo[stock.LastInventoryUpdateColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.LastSalesDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.LastSalesDate = (DateTime)tempPartsInfo[stock.LastSalesDateColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.LastStockDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.LastStockDate = (DateTime)tempPartsInfo[stock.LastStockDateColumn.ColumnName];
                }
                tempWork.MaximumStockCnt = (double)tempPartsInfo[stock.MaximumStockCntColumn.ColumnName];
                tempWork.MinimumStockCnt = (double)tempPartsInfo[stock.MinimumStockCntColumn.ColumnName];
                tempWork.MonthOrderCount = (double)tempPartsInfo[stock.MonthOrderCountColumn.ColumnName];
                tempWork.MovingSupliStock = (double)tempPartsInfo[stock.MovingSupliStockColumn.ColumnName];
                tempWork.NmlSalOdrCount = (double)tempPartsInfo[stock.NmlSalOdrCountColumn.ColumnName];
                if (!(tempPartsInfo[stock.PartsManagementDivide1Column.ColumnName] is System.DBNull))
                {
                    tempWork.PartsManagementDivide1 = (string)tempPartsInfo[stock.PartsManagementDivide1Column.ColumnName];
                }
                if (!(tempPartsInfo[stock.PartsManagementDivide2Column.ColumnName] is System.DBNull))
                {
                    tempWork.PartsManagementDivide2 = (string)tempPartsInfo[stock.PartsManagementDivide2Column.ColumnName];
                }
                tempWork.SalesOrderCount = (double)tempPartsInfo[stock.SalesOrderCountColumn.ColumnName];
                tempWork.SalesOrderUnit = (int)tempPartsInfo[stock.SalesOrderUnitColumn.ColumnName];
                if (!(tempPartsInfo[stock.SectionGuideNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SectionGuideNm = (string)tempPartsInfo[stock.SectionGuideNmColumn.ColumnName];
                }

                if ((Boolean)tempPartsInfo[stock.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                tempWork.ShipmentCnt = (double)tempPartsInfo[stock.ShipmentCntColumn.ColumnName];
                tempWork.ShipmentPosCnt = (double)tempPartsInfo[stock.ShipmentPosCntColumn.ColumnName];
                if (!(tempPartsInfo[stock.StockCreateDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.StockCreateDate = (DateTime)tempPartsInfo[stock.StockCreateDateColumn.ColumnName];
                }
                tempWork.StockDiv = (int)tempPartsInfo[stock.StockDivColumn.ColumnName];
                if (!(tempPartsInfo[stock.StockNote1Column.ColumnName] is System.DBNull))
                {
                    tempWork.StockNote1 = (string)tempPartsInfo[stock.StockNote1Column.ColumnName];
                }
                if (!(tempPartsInfo[stock.StockNote2Column.ColumnName] is System.DBNull))
                {
                    tempWork.StockNote2 = (string)tempPartsInfo[stock.StockNote2Column.ColumnName];
                }
                tempWork.StockSupplierCode = (int)tempPartsInfo[stock.StockSupplierCodeColumn.ColumnName];
                tempWork.StockTotalPrice = (long)tempPartsInfo[stock.StockTotalPriceColumn.ColumnName];
                tempWork.StockUnitPriceFl = (double)tempPartsInfo[stock.StockUnitPriceFlColumn.ColumnName];
                tempWork.SupplierStock = (double)tempPartsInfo[stock.SupplierStockColumn.ColumnName];
                if (!(tempPartsInfo[stock.UpdateDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.UpdateDate = (DateTime)tempPartsInfo[stock.UpdateDateColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.WarehouseCodeColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WarehouseCode = (string)tempPartsInfo[stock.WarehouseCodeColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.WarehouseNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WarehouseName = (string)tempPartsInfo[stock.WarehouseNameColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.WarehouseShelfNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WarehouseShelfNo = (string)tempPartsInfo[stock.WarehouseShelfNoColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtStockTmpList.Add(tempWork);
            }

            if (pmtStockTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        #region 2013/08/01 三戸 削除
        // --- DEL 2013/08/01 三戸 Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 代替部品検索結果情報新規操作
        ///// </summary>
        ///// <param name="substPartsInfo">代替部品検索結果情報</param>
        ///// <param name="pmtSbPtsInfoTmpList">SCM DB用代替部品検索結果リスト</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="businessSessionId">業務セッションID</param>
        ///// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        ///// <returns>ステータス</returns>
        //private int WriteSubstPartsInfo(PartsInfoDataSet.SubstPartsInfoDataTable substPartsInfo,
        //    ref List<PmtSbPtsInfoTmpWork> pmtSbPtsInfoTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    const string methodName = "WriteSubstPartsInfo";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    for (int i = 0; i < substPartsInfo.Count; i++)
        //    {
        //        PmtSbPtsInfoTmpWork tempWork = new PmtSbPtsInfoTmpWork();

        //        PartsInfoDataSet.SubstPartsInfoRow tempSubstPartsInfo = substPartsInfo[i] as PartsInfoDataSet.SubstPartsInfoRow;

        //        tempWork.CatalogPartsMakerCd = (int)tempSubstPartsInfo[substPartsInfo.CatalogPartsMakerCdColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.PartsNameKanaColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsNameKana = (string)tempSubstPartsInfo[substPartsInfo.PartsNameKanaColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.NewPrtsNoNoneHyphenColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.NewPrtsNoNoneHyphen = (string)tempSubstPartsInfo[substPartsInfo.NewPrtsNoNoneHyphenColumn.ColumnName];
        //        }

        //        if ((Boolean)tempSubstPartsInfo[substPartsInfo.SelectionStateColumn.ColumnName])
        //        {
        //            tempWork.SelectionState = 1; 
        //        }
        //        else
        //        {
        //            tempWork.SelectionState = 0;
        //        }

        //        tempWork.PartsSearchCode = (int)tempSubstPartsInfo[substPartsInfo.PartsSearchCodeColumn.ColumnName];
        //        tempWork.PartsCode = (int)tempSubstPartsInfo[substPartsInfo.PartsCodeColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.PartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsName = (string)tempSubstPartsInfo[substPartsInfo.PartsNameColumn.ColumnName];
        //        }
        //        tempWork.PartsInfoCtrlFlg = (int)tempSubstPartsInfo[substPartsInfo.PartsInfoCtrlFlgColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.PartsLayerCdColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsLayerCd = (string)tempSubstPartsInfo[substPartsInfo.PartsLayerCdColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.MakerOfferPartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.MakerOfferPartsName = (string)tempSubstPartsInfo[substPartsInfo.MakerOfferPartsNameColumn.ColumnName];
        //        }
        //        tempWork.TbsPartsCdDerivedNo = (int)tempSubstPartsInfo[substPartsInfo.TbsPartsCdDerivedNoColumn.ColumnName];
        //        tempWork.TbsPartsCode = (int)tempSubstPartsInfo[substPartsInfo.TbsPartsCodeColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.PlrlSubNewPrtNoHypnColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PlrlSubNewPrtNoHypn = (string)tempSubstPartsInfo[substPartsInfo.PlrlSubNewPrtNoHypnColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.PartsPluralSubstCmntColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsPluralSubstCmnt = (string)tempSubstPartsInfo[substPartsInfo.PartsPluralSubstCmntColumn.ColumnName];
        //        }
        //        tempWork.PartsQty = (double)tempSubstPartsInfo[substPartsInfo.PartsQtyColumn.ColumnName];
        //        tempWork.MainOrSubPartsDivCd = (int)tempSubstPartsInfo[substPartsInfo.MainOrSubPartsDivCdColumn.ColumnName];
        //        tempWork.PartsPluralSubstFlg = (int)tempSubstPartsInfo[substPartsInfo.PartsPluralSubstFlgColumn.ColumnName];
        //        tempWork.NPrtNoWithHypnDspOdr = (int)tempSubstPartsInfo[substPartsInfo.NPrtNoWithHypnDspOdrColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.NewPartsNoWithHyphenColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.NewPartsNoWithHyphen = (string)tempSubstPartsInfo[substPartsInfo.NewPartsNoWithHyphenColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.OldPartsNoWithHyphenColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.OldPartsNoWithHyphen = (string)tempSubstPartsInfo[substPartsInfo.OldPartsNoWithHyphenColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.CatalogPartsMakerNmColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.CatalogPartsMakerNm = (string)tempSubstPartsInfo[substPartsInfo.CatalogPartsMakerNmColumn.ColumnName];
        //        }
        //        tempWork.BusinessSessionId = businessSessionId;
        //        tempWork.EnterpriseCode = enterpriseCode;
        //        tempWork.SearchSectionCode = sectionCode;
        //        tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
        //        //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
        //        tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
        //        tempWork.PmTabSearchRowNum = i + 1;

        //        pmtSbPtsInfoTmpList.Add(tempWork);
        //    }

        //    if (pmtSbPtsInfoTmpList.Count > 0)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        //    return status;
        //}
        // --- DEL 2013/08/01 三戸 Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion 2013/08/01 三戸 削除

        /// <summary>
        /// TBO情報検索結果情報新規操作
        /// </summary>
        /// <param name="tboInfo">TBO情報検索結果情報</param>
        /// <param name="pmtTBOInfoTmpList">SCM DB用TBO情報検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteTBOInfo(PartsInfoDataSet.TBOInfoDataTable tboInfo,
            ref List<PmtTBOInfoTmpWork> pmtTBOInfoTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteTBOInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < tboInfo.Count; i++)
            {
                PmtTBOInfoTmpWork tempWork = new PmtTBOInfoTmpWork();

                PartsInfoDataSet.TBOInfoRow tempTBOInfo = tboInfo[i] as PartsInfoDataSet.TBOInfoRow;

                tempWork.GoodsMGroup = (int)tempTBOInfo[tboInfo.GoodsMGroupColumn.ColumnName];
                tempWork.OfferKubun = (int)tempTBOInfo[tboInfo.OfferKubunColumn.ColumnName];
                if (!(tempTBOInfo[tboInfo.PrimePartsKanaNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PrimePartsKanaName = (string)tempTBOInfo[tboInfo.PrimePartsKanaNameColumn.ColumnName];
                }
                if (!(tempTBOInfo[tboInfo.OfferDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OfferDate = (DateTime)tempTBOInfo[tboInfo.OfferDateColumn.ColumnName];
                }
                if (!(tempTBOInfo[tboInfo.JoinDestMakerNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinDestMakerNm = (string)tempTBOInfo[tboInfo.JoinDestMakerNmColumn.ColumnName];
                }

                if ((Boolean)tempTBOInfo[tboInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1; 
                }
                else
                {
                    tempWork.SelectionState = 0;  
                }

                tempWork.CatalogDeleteFlag = (int)tempTBOInfo[tboInfo.CatalogDeleteFlagColumn.ColumnName];
                tempWork.PartsAttribute = (int)tempTBOInfo[tboInfo.PartsAttributeColumn.ColumnName];
                if (!(tempTBOInfo[tboInfo.PrimePartsSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.PrimePartsSpecialNote = (string)tempTBOInfo[tboInfo.PrimePartsSpecialNoteColumn.ColumnName];     // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                    tempWork.PrimePartsSpecialNote = GetSubString((string)tempTBOInfo[tboInfo.PrimePartsSpecialNoteColumn.ColumnName], 40);    // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                }
                if (!(tempTBOInfo[tboInfo.PartsLayerCdColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsLayerCd = (string)tempTBOInfo[tboInfo.PartsLayerCdColumn.ColumnName];
                }
                if (!(tempTBOInfo[tboInfo.PrimePartsNameColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.PrimePartsName = (string)tempTBOInfo[tboInfo.PrimePartsNameColumn.ColumnName];    // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                    tempWork.PrimePartsName = GetSubString((string)tempTBOInfo[tboInfo.PrimePartsNameColumn.ColumnName], 40);     // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                }
                if (!(tempTBOInfo[tboInfo.EquipSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EquipSpecialNote = (string)tempTBOInfo[tboInfo.EquipSpecialNoteColumn.ColumnName];
                }
                tempWork.JoinQty = (double)tempTBOInfo[tboInfo.JoinQtyColumn.ColumnName];
                if (!(tempTBOInfo[tboInfo.JoinDestPartsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinDestPartsNo = (string)tempTBOInfo[tboInfo.JoinDestPartsNoColumn.ColumnName];
                }
                tempWork.JoinDestMakerCd = (int)tempTBOInfo[tboInfo.JoinDestMakerCdColumn.ColumnName];
                tempWork.CarInfoJoinDispOrder = (int)tempTBOInfo[tboInfo.CarInfoJoinDispOrderColumn.ColumnName];
                if (!(tempTBOInfo[tboInfo.CarInfoJoinDispOrderColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.EquipName = (string)tempTBOInfo[tboInfo.EquipNameColumn.ColumnName];    // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                    tempWork.EquipName = GetSubString((string)tempTBOInfo[tboInfo.EquipNameColumn.ColumnName], 30);     // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                }
                tempWork.EquipGenreCode = (int)tempTBOInfo[tboInfo.EquipGenreCodeColumn.ColumnName];
                tempWork.TbsPartsCdDerivedNo = (int)tempTBOInfo[tboInfo.TbsPartsCdDerivedNoColumn.ColumnName];
                tempWork.TbsPartsCode = (int)tempTBOInfo[tboInfo.TbsPartsCodeColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtTBOInfoTmpList.Add(tempWork);
            }

            if (pmtTBOInfoTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// ユーザー商品検索結果情報新規操作
        /// </summary>
        /// <param name="usrGoodsInfo">ユーザー商品検索結果情報</param>
        /// <param name="pmtUrGdsInfTmpList">SCM DB用ユーザー商品検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteUsrGoodsInfo(PartsInfoDataSet.UsrGoodsInfoDataTable usrGoodsInfo,
            ref List<PmtUrGdsInfTmpWork> pmtUrGdsInfTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteUsrGoodsInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrGoodsInfo.Count; i++)
            {
                PmtUrGdsInfTmpWork tempWork = new PmtUrGdsInfTmpWork();

                PartsInfoDataSet.UsrGoodsInfoRow tempUsrGoodsInfo = usrGoodsInfo[i] as PartsInfoDataSet.UsrGoodsInfoRow;
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteOfferColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.GoodsSpecialNoteOffer = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteOfferColumn.ColumnName];    // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                    tempWork.GoodsSpecialNoteOffer = GetSubString((string)tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteOfferColumn.ColumnName], 40);    // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.FreSrchPrtPropNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.FreSrchPrtPropNo = (string)tempUsrGoodsInfo[usrGoodsInfo.FreSrchPrtPropNoColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.RateDivUnCstColumn.ColumnName] is System.DBNull))
                {
                    tempWork.RateDivUnCst = (string)tempUsrGoodsInfo[usrGoodsInfo.RateDivUnCstColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.RateDivSalUnPrcColumn.ColumnName] is System.DBNull))
                {
                    tempWork.RateDivSalUnPrc = (string)tempUsrGoodsInfo[usrGoodsInfo.RateDivSalUnPrcColumn.ColumnName];
                }

                if (!(tempUsrGoodsInfo[usrGoodsInfo.PartsPriceStDateColumn.ColumnName] is System.DBNull))
                {
                    DateTime dt = (DateTime)tempUsrGoodsInfo[usrGoodsInfo.PartsPriceStDateColumn.ColumnName];

                    if (!dt.Equals(DateTime.MinValue))
                    {
                        //tempWork.PartsPriceStDate = Convert.ToInt32(dt.ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                        tempWork.PartsPriceStDate = Convert.ToInt32(dt.ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                    }
                    else
                    {
                        tempWork.PartsPriceStDate = 0;
                    }
                }
                tempWork.SelectedGoodsNoDiv = (int)tempUsrGoodsInfo[usrGoodsInfo.SelectedGoodsNoDivColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.PrtMakerNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PrtMakerName = (string)tempUsrGoodsInfo[usrGoodsInfo.PrtMakerNameColumn.ColumnName];
                }
                tempWork.PrtMakerCode = (int)tempUsrGoodsInfo[usrGoodsInfo.PrtMakerCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.PrtGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PrtGoodsNo = (string)tempUsrGoodsInfo[usrGoodsInfo.PrtGoodsNoColumn.ColumnName];
                }
                tempWork.SelectedListPriceDiv = (int)tempUsrGoodsInfo[usrGoodsInfo.SelectedListPriceDivColumn.ColumnName];
                tempWork.PriceSelectDiv = (int)tempUsrGoodsInfo[usrGoodsInfo.PriceSelectDivColumn.ColumnName];
                tempWork.CustRateGrpCode = (int)tempUsrGoodsInfo[usrGoodsInfo.CustRateGrpCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.RateDivLPriceColumn.ColumnName] is System.DBNull))
                {
                    tempWork.RateDivLPrice = (string)tempUsrGoodsInfo[usrGoodsInfo.RateDivLPriceColumn.ColumnName];
                }
                tempWork.SelectedListPrice = (double)tempUsrGoodsInfo[usrGoodsInfo.SelectedListPriceColumn.ColumnName];
                tempWork.PrimeDispOrder = (int)tempUsrGoodsInfo[usrGoodsInfo.PrimeDispOrderColumn.ColumnName];

                if ((Boolean)tempUsrGoodsInfo[usrGoodsInfo.CalcPriceColumn.ColumnName])
                {
                    tempWork.CalcPrice = 1;  
                }
                else
                {
                    tempWork.CalcPrice = 0;  
                }


                if (!(tempUsrGoodsInfo[usrGoodsInfo.JoinSrcPrtsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinSrcPrtsNo = (string)tempUsrGoodsInfo[usrGoodsInfo.JoinSrcPrtsNoColumn.ColumnName];
                }
                tempWork.SrchPNmAcqrCarMkrCd = (int)tempUsrGoodsInfo[usrGoodsInfo.SrchPNmAcqrCarMkrCdColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.SearchPartsHalfNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SearchPartsHalfName = (string)tempUsrGoodsInfo[usrGoodsInfo.SearchPartsHalfNameColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.SearchPartsFullNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SearchPartsFullName = (string)tempUsrGoodsInfo[usrGoodsInfo.SearchPartsFullNameColumn.ColumnName];
                }
                //UPD 2013/08/05 TAKAGAWA Redmine#39564対応 ---------->>>>>>>>>>
                //tempWork.SalesUnitPriceTaxInc = Convert.ToInt64(tempUsrGoodsInfo[usrGoodsInfo.SalesUnitPriceTaxIncColumn.ColumnName]);
                tempWork.SalesUnPrcTaxIncFl = (double)tempUsrGoodsInfo[usrGoodsInfo.SalesUnitPriceTaxIncColumn.ColumnName];
                //UPD 2013/08/05 TAKAGAWA Redmine#39564対応 ----------<<<<<<<<<<
                tempWork.UnitCostTaxInc = (double)tempUsrGoodsInfo[usrGoodsInfo.UnitCostTaxIncColumn.ColumnName];
                tempWork.PriceTaxInc = (double)tempUsrGoodsInfo[usrGoodsInfo.PriceTaxIncColumn.ColumnName];
                tempWork.PrimeDisplayCode = (int)tempUsrGoodsInfo[usrGoodsInfo.PrimeDisplayCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.PrmSetDtlName2Column.ColumnName] is System.DBNull))
                {
                    tempWork.PrmSetDtlName2 = (string)tempUsrGoodsInfo[usrGoodsInfo.PrmSetDtlName2Column.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsOfrNameKanaColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsOfrNameKana = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsOfrNameKanaColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsOfrNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsOfrName = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsOfrNameColumn.ColumnName];
                }
                tempWork.GoodsKindResolved = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsKindResolvedColumn.ColumnName];
                tempWork.QTY = (double)tempUsrGoodsInfo[usrGoodsInfo.QTYColumn.ColumnName];
                //UPD 2013/08/05 TAKAGAWA Redmine#39564対応 ---------->>>>>>>>>>
                //tempWork.SalesUnitPriceTaxExc = Convert.ToInt64(tempUsrGoodsInfo[usrGoodsInfo.SalesUnitPriceTaxExcColumn.ColumnName]);
                tempWork.SalesUnPrcTaxExcFl = (double)tempUsrGoodsInfo[usrGoodsInfo.SalesUnitPriceTaxExcColumn.ColumnName];
                //UPD 2013/08/05 TAKAGAWA Redmine#39564対応 ----------<<<<<<<<<<
                tempWork.UnitCostTaxExc = (double)tempUsrGoodsInfo[usrGoodsInfo.UnitCostTaxExcColumn.ColumnName];
                tempWork.PriceTaxExc = (double)tempUsrGoodsInfo[usrGoodsInfo.PriceTaxExcColumn.ColumnName];
                tempWork.GoodsKindCode = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsKindCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.NewGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewGoodsNo = (string)tempUsrGoodsInfo[usrGoodsInfo.NewGoodsNoColumn.ColumnName];
                }

                if ((Boolean)tempUsrGoodsInfo[usrGoodsInfo.SelectionCompleteColumn.ColumnName])
                {
                    tempWork.SelectionComplete = 1; 
                }
                else
                {
                    tempWork.SelectionComplete = 0; 
                }

                tempWork.OfferKubun = (int)tempUsrGoodsInfo[usrGoodsInfo.OfferKubunColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsMakerNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsMakerNm = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsMakerNmColumn.ColumnName];
                }

                if ((Boolean)tempUsrGoodsInfo[usrGoodsInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;   
                }
                else
                {
                    tempWork.SelectionState = 0;  
                }

                tempWork.GoodsMGroup = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsMGroupColumn.ColumnName];
                tempWork.OfferDataDiv = (int)tempUsrGoodsInfo[usrGoodsInfo.OfferDataDivColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.UpdateDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.UpdateDate = (DateTime)tempUsrGoodsInfo[usrGoodsInfo.UpdateDateColumn.ColumnName];
                }
                tempWork.EnterpriseGanreCode = (int)tempUsrGoodsInfo[usrGoodsInfo.EnterpriseGanreCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.GoodsSpecialNote = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteColumn.ColumnName];    // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                    tempWork.GoodsSpecialNote = GetSubString((string)tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteColumn.ColumnName], 40);    // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNote2Column.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNote2 = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNote2Column.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNote1Column.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNote1 = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNote1Column.ColumnName];
                }
                tempWork.GoodsKind = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsKindColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.OfferDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OfferDate = (DateTime)tempUsrGoodsInfo[usrGoodsInfo.OfferDateColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNoNoneHyphen = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName];
                }
                tempWork.TaxationDivCd = (int)tempUsrGoodsInfo[usrGoodsInfo.TaxationDivCdColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsRateRankColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsRateRank = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsRateRankColumn.ColumnName];
                }
                tempWork.DisplayOrder = (int)tempUsrGoodsInfo[usrGoodsInfo.DisplayOrderColumn.ColumnName];
                tempWork.BlGoodsCode = (int)tempUsrGoodsInfo[usrGoodsInfo.BlGoodsCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.JanColumn.ColumnName] is System.DBNull))
                {
                    tempWork.Jan = (string)tempUsrGoodsInfo[usrGoodsInfo.JanColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNameKanaColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNameKana = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNameKanaColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsName = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNameColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNo = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNoColumn.ColumnName];
                }
                tempWork.GoodsMakerCd = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsMakerCdColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrGdsInfTmpList.Add(tempWork);
            }

            if (pmtUrGdsInfTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// ユーザー価格検索結果情報新規操作
        /// </summary>
        /// <param name="usrGoodsPrice">ユーザー価格検索結果情報</param>
        /// <param name="pmtUrGdsPriTmpList">SCM DB用ユーザー価格検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteUsrGoodsPrice(PartsInfoDataSet.UsrGoodsPriceDataTable usrGoodsPrice,
            ref List<PmtUrGdsPriTmpWork> pmtUrGdsPriTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteUsrGoodsPrice";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrGoodsPrice.Count; i++)
            {
                PmtUrGdsPriTmpWork tempWork = new PmtUrGdsPriTmpWork();

                PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPrice = usrGoodsPrice[i] as PartsInfoDataSet.UsrGoodsPriceRow;

                tempWork.GoodsMakerCd = (int)tempUsrGoodsPrice[usrGoodsPrice.GoodsMakerCdColumn.ColumnName];
                if (!(tempUsrGoodsPrice[usrGoodsPrice.UpdateDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.UpdateDate = (DateTime)tempUsrGoodsPrice[usrGoodsPrice.UpdateDateColumn.ColumnName];
                }
                if (!(tempUsrGoodsPrice[usrGoodsPrice.EnterpriseCodeColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EnterpriseCode = (string)tempUsrGoodsPrice[usrGoodsPrice.EnterpriseCodeColumn.ColumnName];
                }
                if (!(tempUsrGoodsPrice[usrGoodsPrice.OfferDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OfferDate = (DateTime)tempUsrGoodsPrice[usrGoodsPrice.OfferDateColumn.ColumnName];
                }
                tempWork.OpenPriceDiv = (int)tempUsrGoodsPrice[usrGoodsPrice.OpenPriceDivColumn.ColumnName];
                tempWork.StockRate = (double)tempUsrGoodsPrice[usrGoodsPrice.StockRateColumn.ColumnName];
                tempWork.SalesUnitCost = (double)tempUsrGoodsPrice[usrGoodsPrice.SalesUnitCostColumn.ColumnName];
                tempWork.ListPrice = Convert.ToInt64(tempUsrGoodsPrice[usrGoodsPrice.ListPriceColumn.ColumnName]); 
                if (!(tempUsrGoodsPrice[usrGoodsPrice.PriceStartDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PriceStartDate = (DateTime)tempUsrGoodsPrice[usrGoodsPrice.PriceStartDateColumn.ColumnName];
                }
                if (!(tempUsrGoodsPrice[usrGoodsPrice.GoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNo = (string)tempUsrGoodsPrice[usrGoodsPrice.GoodsNoColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrGdsPriTmpList.Add(tempWork);
            }

            if (pmtUrGdsPriTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// ユーザー結合検索結果情報新規操作
        /// </summary>
        /// <param name="usrJoinParts">ユーザー結合検索結果情報</param>
        /// <param name="pmtUrJinPtsTmpList">SCM DB用ユーザー結合検索結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteUsrJoinParts(PartsInfoDataSet.UsrJoinPartsDataTable usrJoinParts,
            ref List<PmtUrJinPtsTmpWork> pmtUrJinPtsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteUsrJoinParts";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrJoinParts.Count; i++)
            {
                PmtUrJinPtsTmpWork tempWork = new PmtUrJinPtsTmpWork();

                PartsInfoDataSet.UsrJoinPartsRow tempUsrJoinParts = usrJoinParts[i] as PartsInfoDataSet.UsrJoinPartsRow;

                tempWork.JoinDispOrder = (int)tempUsrJoinParts[usrJoinParts.JoinDispOrderColumn.ColumnName];
                tempWork.PrimeDispOrder = (int)tempUsrJoinParts[usrJoinParts.PrimeDispOrderColumn.ColumnName];

                if ((Boolean)tempUsrJoinParts[usrJoinParts.PrmSettingFlgColumn.ColumnName])
                {
                    tempWork.PrmSettingFlg = 1;  
                }
                else
                {
                    tempWork.PrmSettingFlg = 0;    
                }

                if (!(tempUsrJoinParts[usrJoinParts.JoinOfferDateColumn.ColumnName] is System.DBNull))
                {
                    DateTime tempDate = (DateTime)tempUsrJoinParts[usrJoinParts.JoinOfferDateColumn.ColumnName];

                    if (!tempDate.Equals(DateTime.MinValue))
                    {
                        //tempWork.JoinOfferDate = Convert.ToInt32(tempDate.ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                        tempWork.JoinOfferDate = Convert.ToInt32(tempDate.ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                    }
                    else
                    {
                        tempWork.JoinOfferDate = 0;
                    }
                }

                if ((Boolean)tempUsrJoinParts[usrJoinParts.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;  
                }
                else
                {
                    tempWork.SelectionState = 0; 
                }

                if (!(tempUsrJoinParts[usrJoinParts.JoinSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinSpecialNote = (string)tempUsrJoinParts[usrJoinParts.JoinSpecialNoteColumn.ColumnName];    // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                    tempWork.JoinSpecialNote = GetSubString((string)tempUsrJoinParts[usrJoinParts.JoinSpecialNoteColumn.ColumnName], 40);    // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                }
                tempWork.JoinQty = (double)tempUsrJoinParts[usrJoinParts.JoinQtyColumn.ColumnName];
                if (!(tempUsrJoinParts[usrJoinParts.JoinDestPartsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinDestPartsNo = (string)tempUsrJoinParts[usrJoinParts.JoinDestPartsNoColumn.ColumnName];
                }
                tempWork.JoinDestMakerCd = (int)tempUsrJoinParts[usrJoinParts.JoinDestMakerCdColumn.ColumnName];
                if (!(tempUsrJoinParts[usrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinSrcPartsNoWithH = (string)tempUsrJoinParts[usrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName];
                }
                if (!(tempUsrJoinParts[usrJoinParts.JoinSrcPartsNoNoneHColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinSrcPartsNoNoneH = (string)tempUsrJoinParts[usrJoinParts.JoinSrcPartsNoNoneHColumn.ColumnName];
                }
                tempWork.JoinSourceMakerCode = (int)tempUsrJoinParts[usrJoinParts.JoinSourceMakerCodeColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrJinPtsTmpList.Add(tempWork);
            }


            if (pmtUrJinPtsTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        /// <summary>
        /// UsrSetParts情報新規操作
        /// </summary>
        /// <param name="usrSetParts">UsrSetParts情報</param>
        /// <param name="pmtUrSetPtsTmpList">pmtUrSetPtsTmpList</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <returns>ステータス</returns>
        private int WriteUsrSetParts(PartsInfoDataSet.UsrSetPartsDataTable usrSetParts,
            ref List<PmtUrSetPtsTmpWork> pmtUrSetPtsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WriteUsrSetParts";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrSetParts.Count; i++)
            {
                PmtUrSetPtsTmpWork tempWork = new PmtUrSetPtsTmpWork();

                PartsInfoDataSet.UsrSetPartsRow tempUsrSetParts = usrSetParts[i] as PartsInfoDataSet.UsrSetPartsRow;

                tempWork.ParentGoodsMakerCd = (int)tempUsrSetParts[usrSetParts.ParentGoodsMakerCdColumn.ColumnName];

                if ((Boolean)tempUsrSetParts[usrSetParts.PrmSettingFlgColumn.ColumnName])
                {
                    tempWork.PrmSettingFlg = 1;     
                }
                else
                {
                    tempWork.PrmSettingFlg = 0;     
                }

                if ((Boolean)tempUsrSetParts[usrSetParts.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;    
                }
                else
                {
                    tempWork.SelectionState = 0;   
                }

                if (!(tempUsrSetParts[usrSetParts.CatalogShapeNoColumn.ColumnName] is System.DBNull))
                {
                 tempWork.CatalogShapeNo = (string)tempUsrSetParts[usrSetParts.CatalogShapeNoColumn.ColumnName];   
                }
                if (!(tempUsrSetParts[usrSetParts.SetSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.SetSpecialNote = (string)tempUsrSetParts[usrSetParts.SetSpecialNoteColumn.ColumnName];    // DEL huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                    tempWork.SetSpecialNote = GetSubString((string)tempUsrSetParts[usrSetParts.SetSpecialNoteColumn.ColumnName], 40);    // ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される 
                }
                tempWork.DisplayOrder = (int)tempUsrSetParts[usrSetParts.DisplayOrderColumn.ColumnName];
                tempWork.CntFl = (double)tempUsrSetParts[usrSetParts.CntFlColumn.ColumnName];
                if (!(tempUsrSetParts[usrSetParts.SubGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SubGoodsNo = (string)tempUsrSetParts[usrSetParts.SubGoodsNoColumn.ColumnName];
                }
                tempWork.SubGoodsMakerCd = (int)tempUsrSetParts[usrSetParts.SubGoodsMakerCdColumn.ColumnName];
                if (!(tempUsrSetParts[usrSetParts.ParentGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ParentGoodsNo = (string)tempUsrSetParts[usrSetParts.ParentGoodsNoColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrSetPtsTmpList.Add(tempWork);
            }


            if (pmtUrSetPtsTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }
        #endregion ◎ 部品検索した17個テーブル保存処理

        #region ◎ 受注マスタ（車両）登録
        /// <summary>
        /// 受注マスタ（車両）登録
        /// </summary>
        /// <param name="searchedCarInfo">車両データ</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabDtlDiscGuid">PMTAB明細識別GUID</param>
        /// <param name="searchSectionCode">検索拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 ------------------->>>>>>>>>>>>>>>
        #region 旧ソース
        //// UPD 2013/12/12 SCM仕掛一覧№10609対応 ------------------------------>>>>>
        ////private int WritePmTabAcpOdrCar(PMKEN01010E searchedCarInfo, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid)
        //private int WritePmTabAcpOdrCar(PMKEN01010E searchedCarInfo, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid, PmTabSalesDtCarWork pmTabSalesDtCarWork)
        //// UPD 2013/12/12 SCM仕掛一覧№10609対応 ------------------------------<<<<<
        #endregion
        private int WritePmTabAcpOdrCar(PMKEN01010E searchedCarInfo, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid)
        // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 -------------------<<<<<<<<<<<<<<<
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WritePmTabAcpOdrCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            IPmTabAcpOdrCarDB iPmTabAcpOdrCarDB = MediationPmTabAcpOdrCarDB.GetPmTabAcpOdrCarDB();
            ArrayList acceptOdrCarList = new ArrayList();

            // 型式情報
            //PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchedCarInfo.CarModelInfo;            // DEL huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応
            PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchedCarInfo.CarModelInfoSummarized;    // ADD huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応
            // 画面用型式情報
            PMKEN01010E.CarModelUIDataTable carModelUIDataTable = searchedCarInfo.CarModelUIData;
            // カラー情報
            PMKEN01010E.ColorCdInfoDataTable colorCdInfoDataTable = searchedCarInfo.ColorCdInfo;
            // トリム情報
            PMKEN01010E.TrimCdInfoDataTable trimCdInfoDataTable = searchedCarInfo.TrimCdInfo;


            // 受注マスタ（車両） データをクラスへ格納する
            PmTabAcpOdrCarWork pmTabAcpOdrCarWork = new PmTabAcpOdrCarWork();


            if (carModelInfoDataTable.Rows.Count > 0)
            {
                PMKEN01010E.CarModelInfoRow carModelInfoRow = carModelInfoDataTable[0] as PMKEN01010E.CarModelInfoRow;

                pmTabAcpOdrCarWork.MakerCode = carModelInfoRow.MakerCode;              // メーカーコード
                pmTabAcpOdrCarWork.MakerFullName = carModelInfoRow.MakerFullName;      // メーカー全角名称
                pmTabAcpOdrCarWork.MakerHalfName = carModelInfoRow.MakerHalfName;      // メーカー半角名称
                pmTabAcpOdrCarWork.ModelCode = carModelInfoRow.ModelCode;              // 車種コード
                pmTabAcpOdrCarWork.ModelSubCode = carModelInfoRow.ModelSubCode;        // 車種サブコード

                // 車種全角名称
                if (carModelInfoRow.ModelFullName.Length > 15)
                {
                    pmTabAcpOdrCarWork.ModelFullName = carModelInfoRow.ModelFullName.Substring(0, 15);
                }
                else
                {
                    pmTabAcpOdrCarWork.ModelFullName = carModelInfoRow.ModelFullName;
                }

                // 車種半角名称
                if (carModelInfoRow.ModelHalfName.Length > 15)
                {
                    pmTabAcpOdrCarWork.ModelHalfName = carModelInfoRow.ModelHalfName.Substring(0, 15);
                }
                else
                {
                    pmTabAcpOdrCarWork.ModelHalfName = carModelInfoRow.ModelHalfName;
                }

                pmTabAcpOdrCarWork.ExhaustGasSign = carModelInfoRow.ExhaustGasSign;              // 排ガス記号
                pmTabAcpOdrCarWork.SeriesModel = carModelInfoRow.SeriesModel;                    // シリーズ型式
                pmTabAcpOdrCarWork.CategorySignModel = carModelInfoRow.CategorySignModel;        // 型式（類別記号）
                pmTabAcpOdrCarWork.FullModel = carModelInfoRow.FullModel;                        // 型式（フル型）

                pmTabAcpOdrCarWork.FrameModel = carModelInfoRow.FrameModel;                      // 車台型式
                //pmTabAcpOdrCarWork.EngineModelNm = carModelInfoRow.EngineDisplaceNm;             // エンジン型式名称// DEL songg 2013/07/08 障害報告 #37983の対応
                pmTabAcpOdrCarWork.EngineModelNm = carModelInfoRow.EngineModelNm;             // エンジン型式名称  // ADD songg 2013/07/08 障害報告 #37983の対応
                pmTabAcpOdrCarWork.RelevanceModel = carModelInfoRow.RelevanceModel;              // 関連型式
                pmTabAcpOdrCarWork.SubCarNmCd = carModelInfoRow.SubCarNmCd;                      // サブ車名コード
                pmTabAcpOdrCarWork.ModelGradeSname = carModelInfoRow.ModelGradeSname;            // 型式グレード略称
                pmTabAcpOdrCarWork.DomesticForeignCode = carModelInfoRow.DomesticForeignCode;           // 国産／外車区分
            }


            if (carModelUIDataTable.Rows.Count > 0)
            {
                PMKEN01010E.CarModelUIRow carModelUIRow = carModelUIDataTable[0] as PMKEN01010E.CarModelUIRow;

                pmTabAcpOdrCarWork.ModelDesignationNo = carModelUIRow.ModelDesignationNo;        // 型式指定番号
                pmTabAcpOdrCarWork.CategoryNo = carModelUIRow.CategoryNo;                        // 類別番号

                // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 ------------------->>>>>>>>>>>>>>>
                #region 旧ソース
                //// UPD 2013/12/12 SCM仕掛一覧№10609対応 ----------------------->>>>>
                ////pmTabAcpOdrCarWork.FrameNo = carModelUIRow.FrameNo;                              // 車台番号
                //pmTabAcpOdrCarWork.FrameNo = pmTabSalesDtCarWork.FrameNo;                          // 車台番号
                //// UPD 2013/12/12 SCM仕掛一覧№10609対応 -----------------------<<<<<
                #endregion
                pmTabAcpOdrCarWork.FrameNo = carModelUIRow.FrameNo;                              // 車台番号
                // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 -------------------<<<<<<<<<<<<<<<

                pmTabAcpOdrCarWork.SearchFrameNo = carModelUIRow.SearchFrameNo;                  // 車台番号（検索用）
            }

            //-----DEL huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応 ---->>>>> 
            //if (colorCdInfoDataTable.Rows.Count > 0)
            //{
            //    PMKEN01010E.ColorCdInfoRow colorCdInfoRow = colorCdInfoDataTable[0] as PMKEN01010E.ColorCdInfoRow;

            //    pmTabAcpOdrCarWork.ColorCode = colorCdInfoRow.ColorCode;                         // カラーコード
            //    pmTabAcpOdrCarWork.ColorName1 = colorCdInfoRow.ColorName1;                       // カラー名称1
            //}

            //if (trimCdInfoDataTable.Rows.Count > 0)
            //{
            //    PMKEN01010E.TrimCdInfoRow trimCdInfoRow = trimCdInfoDataTable[0] as PMKEN01010E.TrimCdInfoRow;

            //    pmTabAcpOdrCarWork.TrimCode = trimCdInfoRow.TrimCode;                            // トリムコード
            //    pmTabAcpOdrCarWork.TrimName = trimCdInfoRow.TrimName;                            // トリム名称
            //}
            //-----DEL huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応 ----<<<<<

            //-----ADD huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応 ---->>>>>
            if (colorCdInfoDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < colorCdInfoDataTable.Rows.Count; i++)
                {
                    PMKEN01010E.ColorCdInfoRow colorCdInfoRow = colorCdInfoDataTable[i] as PMKEN01010E.ColorCdInfoRow;
                    if (colorCdInfoRow.SelectionState == true)
                    {
                        pmTabAcpOdrCarWork.ColorCode = colorCdInfoRow.ColorCode;                         // カラーコード
                        pmTabAcpOdrCarWork.ColorName1 = colorCdInfoRow.ColorName1;                       // カラー名称1
                        break;
                    }

                }
            }

            if (trimCdInfoDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < trimCdInfoDataTable.Rows.Count; i++)
                {
                    PMKEN01010E.TrimCdInfoRow trimCdInfoRow = trimCdInfoDataTable[i] as PMKEN01010E.TrimCdInfoRow;

                    if (trimCdInfoRow.SelectionState == true)
                    {
                        pmTabAcpOdrCarWork.TrimCode = trimCdInfoRow.TrimCode;                            // トリムコード
                        pmTabAcpOdrCarWork.TrimName = trimCdInfoRow.TrimName;                            // トリム名称
                        break;
                    }
                }
            }
            //-----ADD huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応 ----<<<<<

            pmTabAcpOdrCarWork.EnterpriseCode = enterpriseCode;
            pmTabAcpOdrCarWork.DataInputSystem = 10;                               // データ入力システム
            pmTabAcpOdrCarWork.LogicalDeleteCode = 0;                              // 論理削除区分
            pmTabAcpOdrCarWork.BusinessSessionId = businessSessionId;              // 業務セッションID
            pmTabAcpOdrCarWork.SearchSectionCode = searchSectionCode;              // 検索拠点コード
            pmTabAcpOdrCarWork.PmTabDtlDiscGuid = pmTabDtlDiscGuid;                // PMTAB明細識別GUID
            //pmTabAcpOdrCarWork.DataDeleteDate = Convert.ToInt32(
            //    DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));     // データ削除予定日 //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
            pmTabAcpOdrCarWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));     // データ削除予定日 //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更



            int[] fullModelFixedNoAry = new int[0];
            string[] freeSrchMdlFxdNoAry = new string[0];

            CarSearchController carSearcher = new CarSearchController();
            {
                carSearcher.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(searchedCarInfo.CarModelInfo, out fullModelFixedNoAry, out freeSrchMdlFxdNoAry);
            }
            pmTabAcpOdrCarWork.FullModelFixedNoAry = fullModelFixedNoAry;                    // フル型式固定番号配列

            // 自由検索型式固定番号配列
            // DEL songg 2013/07/18 Redmine#38573 装備オブジェクト配列／自由検索型式固定番号配列 ---->>>>>
            //if (null == freeSrchMdlFxdNoAry || freeSrchMdlFxdNoAry.Length == 0)
            //{
            //    pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = new byte[0];
            //}
            //else
            //{
            //    string[] temp = freeSrchMdlFxdNoAry;
            //    byte[] freeAry = new byte[temp.Length];
            //    for (int i = 0; i < temp.Length; i++)
            //    {
            //        freeAry[i] = Convert.ToByte(temp[i]);
            //    }
            //    pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = freeAry;
            //}
            // DEL songg 2013/07/18 Redmine#38573 装備オブジェクト配列／自由検索型式固定番号配列 ----<<<<<
            // ADD songg 2013/07/18 Redmine#38573 装備オブジェクト配列／自由検索型式固定番号配列 ---->>>>>
            // 自動回答処理(PMSCM01010U) SCMSalesDataMaker.cs CreateCarManagementWork メソッドを参考する
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            try
            {
                formatter.Serialize(ms, freeSrchMdlFxdNoAry);
                byte[] verbinary = ms.GetBuffer();
                pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = verbinary; // 自由検索型式固定番号配列
            }
            finally
            {
                ms.Close();
            }
            // ADD songg 2013/07/18 Redmine#38573 装備オブジェクト配列／自由検索型式固定番号配列 ----<<<<<


            //pmTabAcpOdrCarWork.CategoryObjAry = new byte[0];                                        // 装備オブジェクト配列 // DEL songg 2013/07/18 Redmine#38573 装備オブジェクト配列／自由検索型式固定番号配列
            pmTabAcpOdrCarWork.CategoryObjAry = this.GetCategoryObjAry(searchedCarInfo);              // 装備オブジェクト配列 // ADD songg 2013/07/18 Redmine#38573 装備オブジェクト配列／自由検索型式固定番号配列
            

            acceptOdrCarList.Add(pmTabAcpOdrCarWork);

            if (acceptOdrCarList != null)
            {
                object paraList = acceptOdrCarList as object;

                // 車両情報をUSER DBに書込む
                status = iPmTabAcpOdrCarDB.Write(ref paraList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                    return status;
                }
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }

        // ADD 2013/08/01 yugami Redmine#39487 ------------------------------------------->>>>>
        /// <summary>
        /// 受注マスタ（車両）登録
        /// </summary>
        /// <param name="pmTabSalesDtCarWork">車両データ</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabDtlDiscGuid">PMTAB明細識別GUID</param>
        /// <param name="searchSectionCode">検索拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        private int WritePmTabAcpOdrCar(PmTabSalesDtCarWork pmTabSalesDtCarWork, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WritePmTabAcpOdrCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            IPmTabAcpOdrCarDB iPmTabAcpOdrCarDB = MediationPmTabAcpOdrCarDB.GetPmTabAcpOdrCarDB();
            ArrayList acceptOdrCarList = new ArrayList();

            // 受注マスタ（車両） データをクラスへ格納する
            PmTabAcpOdrCarWork pmTabAcpOdrCarWork = new PmTabAcpOdrCarWork();

            pmTabAcpOdrCarWork.MakerCode = pmTabSalesDtCarWork.MakerCode;              // メーカーコード
            pmTabAcpOdrCarWork.MakerFullName = pmTabSalesDtCarWork.MakerName;      // メーカー全角名称
            pmTabAcpOdrCarWork.MakerHalfName = string.Empty;      // メーカー半角名称
            pmTabAcpOdrCarWork.ModelCode = pmTabSalesDtCarWork.ModelCode;              // 車種コード
            pmTabAcpOdrCarWork.ModelSubCode = pmTabSalesDtCarWork.ModelSubCode;        // 車種サブコード

            // 車種全角名称
            if (pmTabSalesDtCarWork.ModelName.Length > 15)
            {
                pmTabAcpOdrCarWork.ModelFullName = pmTabSalesDtCarWork.ModelName.Substring(0, 15);
            }
            else
            {
                pmTabAcpOdrCarWork.ModelFullName = pmTabSalesDtCarWork.ModelName;
            }


            pmTabAcpOdrCarWork.ModelHalfName = string.Empty;                                // 車種半角名称
            pmTabAcpOdrCarWork.ExhaustGasSign = string.Empty;              // 排ガス記号
            pmTabAcpOdrCarWork.SeriesModel = string.Empty;                    // シリーズ型式
            pmTabAcpOdrCarWork.CategorySignModel = string.Empty;        // 型式（類別記号）
            pmTabAcpOdrCarWork.FullModel = pmTabSalesDtCarWork.FullModel;                        // 型式（フル型）

            pmTabAcpOdrCarWork.FrameModel = pmTabSalesDtCarWork.FrameModel;                      // 車台型式
            pmTabAcpOdrCarWork.EngineModelNm = pmTabSalesDtCarWork.EngineModelNm;             // エンジン型式名称  // ADD songg 2013/07/08 障害報告 #37983の対応
            pmTabAcpOdrCarWork.RelevanceModel = string.Empty;              // 関連型式
            pmTabAcpOdrCarWork.SubCarNmCd = 0;                      // サブ車名コード
            pmTabAcpOdrCarWork.ModelGradeSname = string.Empty;            // 型式グレード略称
            pmTabAcpOdrCarWork.DomesticForeignCode = 0;           // 国産／外車区分

            pmTabAcpOdrCarWork.ModelDesignationNo = pmTabSalesDtCarWork.ModelDesignationNo;        // 型式指定番号
            pmTabAcpOdrCarWork.CategoryNo = pmTabSalesDtCarWork.CategoryNo;                        // 類別番号

            pmTabAcpOdrCarWork.FrameNo = pmTabSalesDtCarWork.FrameNo;                              // 車台番号
            //pmTabAcpOdrCarWork.SearchFrameNo = pmTabSalesDtCarWork.FrameNo;                  // 車台番号（検索用）

            pmTabAcpOdrCarWork.ColorCode = pmTabSalesDtCarWork.RpColorCode;                         // カラーコード
            pmTabAcpOdrCarWork.ColorName1 = pmTabSalesDtCarWork.ColorName1;                       // カラー名称1

            pmTabAcpOdrCarWork.TrimCode = pmTabSalesDtCarWork.TrimCode;                            // トリムコード
            pmTabAcpOdrCarWork.TrimName = pmTabSalesDtCarWork.TrimName;                            // トリム名称

            pmTabAcpOdrCarWork.EnterpriseCode = enterpriseCode;
            pmTabAcpOdrCarWork.DataInputSystem = 10;                               // データ入力システム
            pmTabAcpOdrCarWork.LogicalDeleteCode = 0;                              // 論理削除区分
            pmTabAcpOdrCarWork.BusinessSessionId = businessSessionId;              // 業務セッションID
            pmTabAcpOdrCarWork.SearchSectionCode = searchSectionCode;              // 検索拠点コード
            pmTabAcpOdrCarWork.PmTabDtlDiscGuid = pmTabDtlDiscGuid;                // PMTAB明細識別GUID
            pmTabAcpOdrCarWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));     // データ削除予定日 

            if (null == pmTabAcpOdrCarWork.FullModelFixedNoAry)
                pmTabAcpOdrCarWork.FullModelFixedNoAry = new int[0];
            if (null == pmTabAcpOdrCarWork.CategoryObjAry)
                pmTabAcpOdrCarWork.CategoryObjAry = new byte[0];
            if (null == pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry)
                pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = new byte[0];

            acceptOdrCarList.Add(pmTabAcpOdrCarWork);

            if (acceptOdrCarList != null)
            {
                object paraList = acceptOdrCarList as object;

                // 車両情報をUSER DBに書込む
                status = iPmTabAcpOdrCarDB.Write(ref paraList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                    return status;
                }
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }
        // ADD 2013/08/01 yugami Redmine#39487 -------------------------------------------<<<<<

        #endregion ◎ 受注マスタ（車両）登録

        // ADD songg 2013/07/18 Redmine#38573 装備オブジェクト配列／自由検索型式固定番号配列 ---->>>>>
        #region ◎ 装備オブジェクト配列取得
        /// <summary>
        /// 装備情配列を取得します。
        /// 売上伝票入力(MAHNB01001U) MAHNB01012AC.cs GetEquipInfoRows メソッドを参考する
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>装備情報配列</returns>
        private byte[] GetCategoryObjAry(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CEqpDefDspInfo == null) return new byte[0];

            // --- ADD 2013/08/28 三戸 2013/09/99配信分 Redmine#40185対応 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //return seachedCarInfo.CEqpDefDspInfo.GetByteArray(false);
            return seachedCarInfo.CEqpDefDspInfo.GetByteArray(true);
            // --- ADD 2013/08/28 三戸 2013/09/99配信分 Redmine#40185対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        #endregion ◎ 装備オブジェクト配列取得
        // ADD songg 2013/07/18 Redmine#38573 装備オブジェクト配列／自由検索型式固定番号配列 ----<<<<<

        //-----ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.43の対応 ---->>>>>
        #region ◎ 車両情報をSCM DBに更新する
        /// <summary>
        /// 車両情報をSCM DBに更新する
        /// </summary>
        /// <param name="searchedCarInfo">車両データ</param>
        /// <param name="pmTabSalesDtCar">PMTAB売上(車両情報)セッション管理トランザクションデータ情報</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabDtlDiscGuid">PMTAB明細識別GUID</param>
        /// <param name="searchSectionCode">検索拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        private int WritePmTabSalDCar(PMKEN01010E searchedCarInfo, PmTabSalesDtCarWork pmTabSalesDtCar, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "WritePmTabSalDCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            IPmTabSalDCarTmpDB iPmTabSalDCarTmpDB = MediationPmTabSalDCarTmpDB.GetPmTabSalDCarTmpDB();
            ArrayList pmTabSalDCarList = new ArrayList();

            // 型式情報
            PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchedCarInfo.CarModelInfoSummarized;
            // 画面用型式情報
            PMKEN01010E.CarModelUIDataTable carModelUIDataTable = searchedCarInfo.CarModelUIData;
            // カラー情報
            PMKEN01010E.ColorCdInfoDataTable colorCdInfoDataTable = searchedCarInfo.ColorCdInfo;
            // トリム情報
            PMKEN01010E.TrimCdInfoDataTable trimCdInfoDataTable = searchedCarInfo.TrimCdInfo;

            // PMTAB売上(車両情報)セッション管理トランザクションデータ情報
            PmTabSalesDtCarWork pmTabSalesDtCarWork = new PmTabSalesDtCarWork();

            if (carModelInfoDataTable.Rows.Count > 0)
            {
                PMKEN01010E.CarModelInfoRow carModelInfoRow = carModelInfoDataTable[0] as PMKEN01010E.CarModelInfoRow;

                pmTabSalesDtCarWork.MakerCode = carModelInfoRow.MakerCode;                        // メーカーコード
                pmTabSalesDtCarWork.ModelCode = carModelInfoRow.ModelCode;                        // 車種コード
                pmTabSalesDtCarWork.ModelSubCode = carModelInfoRow.ModelSubCode;                  // 車種サブコード
                pmTabSalesDtCarWork.FullModel = carModelInfoRow.FullModel;                        // 型式（フル型）
                pmTabSalesDtCarWork.FrameModel = carModelInfoRow.FrameModel;                      // 車台型式
                pmTabSalesDtCarWork.ModelName = carModelInfoRow.ModelFullName;                    // 車種名
                // pmTabSalesDtCarWork.EngineModelNm = carModelInfoRow.EngineDisplaceNm;             // エンジン型式名称// DEL songg 2013/07/08 障害報告 #37983の対応
                pmTabSalesDtCarWork.EngineModelNm = carModelInfoRow.EngineModelNm;             // エンジン型式名称// ADD songg 2013/07/08 障害報告 #37983の対応
                pmTabSalesDtCarWork.MakerName = carModelInfoRow.MakerFullName;                    // メーカー名称
                pmTabSalesDtCarWork.GradeName = carModelInfoRow.ModelGradeNm;                     // グレード名称
                pmTabSalesDtCarWork.BodyName = carModelInfoRow.BodyName;                          // ボディー名称
                pmTabSalesDtCarWork.DoorCount = carModelInfoRow.DoorCount;                        // ドア数
                pmTabSalesDtCarWork.EDivNm = carModelInfoRow.EDivNm;                              // E区分名称
                pmTabSalesDtCarWork.TransmissionNm = carModelInfoRow.TransmissionNm;              // ミッション名称
                pmTabSalesDtCarWork.ShiftNm = carModelInfoRow.ShiftNm;                            // シフト名称
                pmTabSalesDtCarWork.FrameNoSt = carModelInfoRow.StProduceFrameNo.ToString();      // 車台番号開始
                pmTabSalesDtCarWork.FrameNoEd = carModelInfoRow.EdProduceFrameNo.ToString();      // 車台番号終了
                pmTabSalesDtCarWork.ProdTypeOfYearNumSt = carModelInfoRow.StProduceTypeOfYear;    // 生産年式開始
                pmTabSalesDtCarWork.ProdTypeOfYearNumEd = carModelInfoRow.EdProduceTypeOfYear;    // 生産年式終了
                // ADD songg 2013/07/19 Redmine38628 レイアウト変更対応依頼 ---->>>>>
                pmTabSalesDtCarWork.SystematicCode = carModelInfoRow.SystematicCode; // 系統コード
                pmTabSalesDtCarWork.ProduceTypeOfYearCd = carModelInfoRow.ProduceTypeOfYearCd; // 生産年式コード
                // ADD songg 2013/07/19 Redmine38628 レイアウト変更対応依頼 ----<<<<<
            }

            if (carModelUIDataTable.Rows.Count > 0)
            {
                PMKEN01010E.CarModelUIRow carModelUIRow = carModelUIDataTable[0] as PMKEN01010E.CarModelUIRow;

                pmTabSalesDtCarWork.ModelDesignationNo = carModelUIRow.ModelDesignationNo;        // 型式指定番号
                pmTabSalesDtCarWork.CategoryNo = carModelUIRow.CategoryNo;                        // 類別番号


                // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 ------------------->>>>>>>>>>>>>>>
                #region 旧ソース
                //// UPD 2013/12/12 SCM仕掛一覧№10609対応 ------------------------------------->>>>>
                ////pmTabSalesDtCarWork.FrameNo = carModelUIRow.FrameNo;                              // 車台番号
                //pmTabSalesDtCarWork.FrameNo = pmTabSalesDtCar.FrameNo;                              // 車台番号
                //// UPD 2013/12/12 SCM仕掛一覧№10609対応 -------------------------------------<<<<<
                pmTabSalesDtCarWork.FrameNo = carModelUIRow.FrameNo;                              // 車台番号
                #endregion
                // UPD 2013/12/19 VSS[020_10] ｼｽﾃﾑﾃｽﾄ障害№4 吉岡 -------------------<<<<<<<<<<<<<<<

            }

            //-----DEL huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応 ---->>>>> 
            //if (colorCdInfoDataTable.Rows.Count > 0)
            //{
            //    PMKEN01010E.ColorCdInfoRow colorCdInfoRow = colorCdInfoDataTable[0] as PMKEN01010E.ColorCdInfoRow;

            //    pmTabSalesDtCarWork.ColorName1 = colorCdInfoRow.ColorName1;                       // カラー名称1
            //}

            //if (trimCdInfoDataTable.Rows.Count > 0)
            //{
            //    PMKEN01010E.TrimCdInfoRow trimCdInfoRow = trimCdInfoDataTable[0] as PMKEN01010E.TrimCdInfoRow;

            //    pmTabSalesDtCarWork.TrimCode = trimCdInfoRow.TrimCode;                            // トリムコード
            //    pmTabSalesDtCarWork.TrimName = trimCdInfoRow.TrimName;                            // トリム名称
            //}
            //-----DEL huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応 ----<<<<<

            //-----ADD huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応 ---->>>>>
            if (colorCdInfoDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < colorCdInfoDataTable.Rows.Count; i++)
                {
                    PMKEN01010E.ColorCdInfoRow colorCdInfoRow = colorCdInfoDataTable[i] as PMKEN01010E.ColorCdInfoRow;
                    if (colorCdInfoRow.SelectionState == true)
                    {
                        pmTabSalesDtCarWork.ColorName1 = colorCdInfoRow.ColorName1;                       // カラー名称1
                        //-----ADD 2013/07/02 licb #Redmine37738対応 -------------->>>>>
                        pmTabSalesDtCarWork.RpColorCode = colorCdInfoRow.ColorCode; // リペアカラーコード
                        //-----ADD 2013/07/02 licb #Redmine37738対応 --------------<<<<<
                        break;
                    }

                }
            }

            if (trimCdInfoDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < trimCdInfoDataTable.Rows.Count; i++)
                {
                    PMKEN01010E.TrimCdInfoRow trimCdInfoRow = trimCdInfoDataTable[i] as PMKEN01010E.TrimCdInfoRow;

                    if (trimCdInfoRow.SelectionState == true)
                    {
                        pmTabSalesDtCarWork.TrimCode = trimCdInfoRow.TrimCode;                            // トリムコード
                        pmTabSalesDtCarWork.TrimName = trimCdInfoRow.TrimName;                            // トリム名称
                        break;
                    }
                }
            }
            //-----ADD huangt 2013/06/21 ソースチェック確認事項一覧にNo.48の対応 ----<<<<<

            pmTabSalesDtCarWork.CreateDateTime = pmTabSalesDtCar.CreateDateTime;    // 作成日時
            pmTabSalesDtCarWork.FileHeaderGuid = pmTabSalesDtCar.FileHeaderGuid;    // GUID
            pmTabSalesDtCarWork.UpdateDateTime = pmTabSalesDtCar.UpdateDateTime;
            pmTabSalesDtCarWork.EnterpriseCode = enterpriseCode;                    // 企業コード
            pmTabSalesDtCarWork.LogicalDeleteCode = 0;                              // 論理削除区分
            pmTabSalesDtCarWork.BusinessSessionId = businessSessionId;              // 業務セッションID
            pmTabSalesDtCarWork.SearchSectionCode = searchSectionCode;              // 検索拠点コード
            pmTabSalesDtCarWork.PmTabDtlDiscGuid = pmTabDtlDiscGuid;                // PMTAB明細識別GUID
            //pmTabSalesDtCarWork.DataDeleteDate = Convert.ToInt32(
            //    DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));      // データ削除予定日  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
            pmTabSalesDtCarWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));      // データ削除予定日  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更

            pmTabSalDCarList.Add(pmTabSalesDtCarWork);

            if (pmTabSalDCarList != null)
            {
                object paraList = pmTabSalDCarList as object;

                // 車両情報をSCM DBに書込む
                status = iPmTabSalDCarTmpDB.Write(ref paraList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

                    return status;
                }
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            return status;
        }
        #endregion
        //-----ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.43の対応 ----<<<<<

        #region ◎ 売上データ(車両情報) 検索
        /// <summary>
        /// 売上データ(車両情報) 検索
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSalesDtCarList">売上データ(車両情報)</param>
        /// <returns>ステータス</returns>
        public int ReadPmTabSalesDtCar(string enterpriseCode, string businessSessionId, ref ArrayList pmTabSalesDtCarList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "ReadPmTabSalesDtCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // PMTAB売上データ(車両情報)インターフェースを取得
            IPmTabSalDCarTmpDB _iPmTabSalDCarTmpDB = MediationPmTabSalDCarTmpDB.GetPmTabSalDCarTmpDB();

            // 検索条件を設定
            PmTabSalesDtCarWork pmTabSalesDtCarWork = new PmTabSalesDtCarWork();

            pmTabSalesDtCarWork.EnterpriseCode = enterpriseCode;
            pmTabSalesDtCarWork.BusinessSessionId = businessSessionId;

            object parapmTabSalesDtCarObj = pmTabSalesDtCarWork as object;
            object pmTabSalesDtCarObj = pmTabSalesDtCarList as object;

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "車両情報検索　検索条件　"
                + "　企業コード：" + enterpriseCode
                + "　業務セッションID：" + businessSessionId
                );
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            // 売上データ(車両情報) 検索処理
            status = _iPmTabSalDCarTmpDB.Search(out pmTabSalesDtCarObj, parapmTabSalesDtCarObj, 0, 0);
            pmTabSalesDtCarList = pmTabSalesDtCarObj as ArrayList;

            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            return status;
        }
        #endregion ◎ 売上データ(車両情報) 検索

        #region ◎ 掛率マスタをSCM DBに書込む処理
        /// <summary>
        /// 掛率マスタをSCM DBに書込む処理
        /// </summary>
        /// <param name="rateList">掛率データリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="pmtPartsSearchWorkList">全て保存用リスト</param>
        /// <returns>ステータス</returns>
        private void GetRateToScmDBDataList(List<Rate> rateList,
            string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid,
            ref CustomSerializeArrayList pmtPartsSearchWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GetRateToScmDBDataList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            List<PmtRateRsltTmpWork> pmtRateRsltTmpList = new List<PmtRateRsltTmpWork>();

            if (null == rateList)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return;
            }

            for (int i = 0; i < rateList.Count; i++)
            {
                Rate rate = rateList[i] as Rate;
                PmtRateRsltTmpWork tempWork = new PmtRateRsltTmpWork();
                tempWork.BLGoodsCode = rate.BLGoodsCode;
                tempWork.BLGroupCode = rate.BLGroupCode;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = rate.CreateDateTime;
                tempWork.CustomerCode = rate.CustomerCode;
                tempWork.CustRateGrpCode = rate.CustRateGrpCode;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.FileHeaderGuid = rate.FileHeaderGuid;
                tempWork.GoodsMakerCd = rate.GoodsMakerCd;
                tempWork.GoodsNo = rate.GoodsNo;
                tempWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;
                tempWork.GoodsRateRank = rate.GoodsRateRank;
                tempWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;
                tempWork.LogicalDeleteCode = rate.LogicalDeleteCode;
                tempWork.LotCount = rate.LotCount;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.PriceFl = rate.PriceFl;
                tempWork.RateMngCustCd = rate.RateMngCustCd;
                tempWork.RateMngCustNm = rate.RateMngCustNm;
                tempWork.RateMngGoodsCd = rate.RateMngGoodsCd;
                tempWork.RateMngGoodsNm = rate.RateMngGoodsNm;
                tempWork.RateSettingDivide = rate.RateSettingDivide;
                tempWork.RateVal = rate.RateVal;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.SectionCode = rate.SectionCode;
                tempWork.SupplierCd = rate.SupplierCd;
                tempWork.UnitPriceKind = rate.UnitPriceKind;
                tempWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;
                tempWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;
                tempWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;
                tempWork.UpdAssemblyId1 = rate.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = rate.UpdAssemblyId2;
                tempWork.UpdateDateTime = rate.UpdateDateTime;
                tempWork.UpdEmployeeCode = rate.UpdEmployeeCode;
                tempWork.UpRate = rate.UpRate;

                pmtRateRsltTmpList.Add(tempWork);
            }

            if (pmtRateRsltTmpList.Count > 0)
            {
                pmtPartsSearchWorkList.Add(pmtRateRsltTmpList);
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        }
        #endregion ◎ 掛率マスタをSCM DBに書込む処理

        //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ---->>>>>
        #region ◎ 得意先掛率グループマスタをSCM DBに書込む処理
        /// <summary>
        /// 得意先掛率グループマスタをSCM DBに書込む処理
        /// </summary>
        /// <param name="custRateGroupList">得意先掛率グループデータリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="businessSessionId">業務セッションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="pmtPartsSearchWorkList">全て保存用リスト</param>
        /// <returns>ステータス</returns>
        private void GetCustRateGroupToScmDBDataList(List<CustRateGroup> custRateGroupList,
            string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid,
            ref CustomSerializeArrayList pmtPartsSearchWorkList)
        {
            if (null == custRateGroupList)
            {
                return;
            }

            List<PmtCustRtGrpTmpWork> tmpList = new List<PmtCustRtGrpTmpWork>();

            for (int i = 0; i < custRateGroupList.Count; i++)
            {
                CustRateGroup rate = custRateGroupList[i] as CustRateGroup;
                PmtCustRtGrpTmpWork tempWork = new PmtCustRtGrpTmpWork();

                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = rate.CreateDateTime;
                tempWork.CustomerCode = rate.CustomerCode;
                tempWork.CustRateGrpCode = rate.CustRateGrpCode;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));// データ削除予定日  //DEL  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));//データ削除予定日//ADD  鄭慕鈞 2013/07/23 Redmine#38992 データ削除予定日のフォーマット変更
                tempWork.EnterpriseCode = rate.EnterpriseCode;
                tempWork.FileHeaderGuid = rate.FileHeaderGuid;
                tempWork.GoodsMakerCd = rate.GoodsMakerCd;
                tempWork.LogicalDeleteCode = rate.LogicalDeleteCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.PureCode = rate.PureCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.UpdAssemblyId1 = rate.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = rate.UpdAssemblyId2;
                tempWork.UpdateDateTime = rate.UpdateDateTime;
                tempWork.UpdEmployeeCode = rate.UpdEmployeeCode;

                tmpList.Add(tempWork);
            }

            if (tmpList.Count > 0)
            {
                pmtPartsSearchWorkList.Add(tmpList);
            }
        }
        #endregion ◎ 得意先掛率グループマスタをSCM DBに書込む処理
        //-----ADD songg 2013/06/20 ソースチェック確認事項一覧にNo.46の対応 ----<<<<<
        

        #region ◎ 商品連結データ不足情報設定用メソッド
        /// <summary>
        /// 商品連結データ不足情報設定
        /// MAHNB01012AB.cs SettingGoodsUnitDataListFromVariousMstを参照する
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結情報リスト</param>
        /// <param name="isSettingSupplier">仕入先設定フラグ</param>
        /// <param name="sectionCode">拠点情報</param>
        private  void SettingGoodsUnitDataListFromVariousMst(ref List<GoodsUnitData> goodsUnitDataList, bool isSettingSupplier, string sectionCode)
        {
            // ----- DEL huangt 2013/07/11 Redmine#38220 不必要なログ出力の削除 ----- >>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //const string methodName = "SettingGoodsUnitDataListFromVariousMst";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            // ----- DEL huangt 2013/07/11 Redmine#38220 不必要なログ出力の削除 ----- <<<<<
            // ADD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            const string methodName = "SettingGoodsUnitDataListFromVariousMst";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ADD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //this._goodsAcs = new GoodsAcs(); // ADD huangt 2013/07/03 Redmine#37755 速度改善対応//DEL songg 2013/07/10 Redmine#38106 優良品番点付検索 ----- >>>>>
            //DEL songg 2013/07/10 Redmine#38106 優良品番点付検索 ----- >>>>>
            if (null == this._goodsAcs)
            {
                this._goodsAcs = new GoodsAcs();
            }
            //DEL songg 2013/07/10 Redmine#38106 優良品番点付検索 ----- <<<<<

            // ADD 2013/07/31 yugami Redmine#39451対応 ----------------------------------->>>>>
            // 商品管理情報リスト
            this._goodsMngList = new List<GoodsMngWork>();
            // ADD 2013/07/31 yugami Redmine#39451対応 -----------------------------------<<<<<

            List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData retGoodsUnitData = goodsUnitData.Clone();
                // UPD 2013/08/01 吉岡 Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // retGoodsUnitData.SectionCode = sectionCode;
                retGoodsUnitData.SectionCode = this.CustomerInfo().MngSectionCode;
                // UPD 2013/08/01 吉岡 Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                this.SettingGoodsUnitDataListFromVariousMst(ref retGoodsUnitData, isSettingSupplier);
                retGoodsUnitDataList.Add(retGoodsUnitData);
            }
            goodsUnitDataList = retGoodsUnitDataList;
            // ----- DEL huangt 2013/07/11 Redmine#38220 不必要なログ出力の削除 ----- >>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            // ----- DEL huangt 2013/07/11 Redmine#38220 不必要なログ出力の削除 ----- <<<<<
            // ADD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            // ADD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// 商品連結データ不足情報設定
        /// </summary>
        /// <param name="goodsUnitData">商品連結データオブジェクト</param>
        /// <param name="isSettingSupplier">仕入先設定フラグ</param>
        private void SettingGoodsUnitDataListFromVariousMst(ref GoodsUnitData goodsUnitData, bool isSettingSupplier)
        {
            // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //const string methodName = "SettingGoodsUnitDataListFromVariousMst";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            // ----- ADD huangt 2013/07/03 Redmine#37755 速度改善対応 ----->>>>>
            //GoodsAcs goodsAcs = new GoodsAcs();
            //goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, (isSettingSupplier) ? 0 : 1);
            this._goodsAcs.SettingGoodsUnitDataFromVariousMstForTablet(ref goodsUnitData, (isSettingSupplier) ? 0 : 1);
            // ----- ADD huangt 2013/07/03 Redmine#37755 速度改善対応 -----<<<<<

            // ADD 2013/07/31 yugami Redmine#39451対応 ----------------------------------->>>>>
            // 商品管理情報リスト追加
            if (this._goodsAcs.GoodsMngWorkForTablet != null)
            {
                if (!this._goodsMngList.Contains(this._goodsAcs.GoodsMngWorkForTablet))
                {
                    this._goodsMngList.Add(this._goodsAcs.GoodsMngWorkForTablet);
                }
            }
            // ADD 2013/07/31 yugami Redmine#39451対応 -----------------------------------<<<<<

            // DEL 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            // DEL 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        #endregion ◎ 商品連結データ不足情報設定用メソッド
        

        #region 日付フォーマット処理
        /// <summary>
        /// 日付フォーマット処理
        /// </summary>
        /// <param name="baseDate">yyyyMMddの日付</param>
        /// <returns>yyyyMMddの時間を戻る</returns>
        /// <remarks>
        /// </remarks>
        private DateTime GetDate(int baseDate)
        {
            // DEL 2013/07/31 吉岡 速度改善 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //const string methodName = "GetDate";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            #endregion
            // DEL 2013/07/31 吉岡 速度改善 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            if (baseDate == 0)
            {
                return DateTime.MinValue;

            }

            string datetime = Convert.ToString(baseDate);

            if(datetime.Length != 8)
            {
                return DateTime.MinValue;
            }

            int year, month, day = 0;
            //年月日に分解
            year = int.Parse(datetime.Substring(0, 4));
            month = int.Parse(datetime.Substring(4, 2));
            day = int.Parse(datetime.Substring(6, 2));

            DateTime date = new DateTime(year, month, day);

            // DEL 2013/07/31 吉岡 速度改善 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            #endregion
            // DEL 2013/07/31 吉岡 速度改善 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return date;
        }
        #endregion

        // ----- ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される ----- >>>>>
        #region 文字列フォーマット処理
        /// <summary>
        /// 文字列フォーマット処理
        /// </summary>
        /// <param name="baseString">入力文字列</param>
        /// <param name="count">桁数</param>
        /// <returns>処理後文字列</returns>
        private string GetSubString(string baseString, int count)
        {
            string retString = baseString;
            if (!string.IsNullOrEmpty(retString) && retString.Length > count)
            {
                retString = retString.Substring(0, count);
            }

            return retString;
        }
        #endregion
        // ----- ADD huangt 2013/06/24 障害報告 #36972の対応 部品検索時に空白メッセージが表示される ----- <<<<<

        //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ---->>>>>
        /// <summary>
        /// 売上全体設定取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns></returns>
        private SalesTtlSt GetSalesTtlStInfo(string enterpriseCode, string sectionCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "GetSalesTtlStInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            // UPD 2013/08/02 #Redmine39451 速度改善3 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();          // 売上全体設定マスタ
            //SalesTtlSt tempSalesTtlSt = null;

            //int status = salesTtlStAcs.Read(out tempSalesTtlSt, enterpriseCode, sectionCode);

            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    && (tempSalesTtlSt.LogicalDeleteCode == 0))
            //{
            //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //    EasyLogger.Write(CLASS_NAME, methodName, "拠点より、売上全体設定情報取得　status：" + status.ToString());
            //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            //    // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            //    return tempSalesTtlSt;
            //}
            //else
            //{
            //    // 全社拠点より、売上全体設定情報取得
            //    status = salesTtlStAcs.Read(out tempSalesTtlSt, enterpriseCode, "00");

            //    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //        && (tempSalesTtlSt.LogicalDeleteCode == 0))
            //    {
            //        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //        EasyLogger.Write(CLASS_NAME, methodName, "全社拠点より、売上全体設定情報取得　status：" + status.ToString());
            //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            //        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            //        return tempSalesTtlSt;
            //    }
            //    else
            //    {
            //        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //        EasyLogger.Write(CLASS_NAME, methodName, "全社拠点より、売上全体設定情報取得　status：" + status.ToString());
            //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            //        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            //        return null;
            //    }
            //}
            #endregion

            // 一度読込済みであれば、再読み込みしない
            if (this._salesTtlSt != null)
            {
                if (this._salesTtlSt.EnterpriseCode.Equals(enterpriseCode)
                && sectionCode.Trim().Equals(_saveSectionCode))
                {
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　売上全体設定マスタ読込済み（企業：" + enterpriseCode + "　拠点： " + _saveSectionCode + "）");
                    return this._salesTtlSt;
                }
            }
            // 検索時に使用された拠点コードを保管
            _saveSectionCode = sectionCode.Trim();

            int status = _salesTtlStAcs.Read(out _salesTtlSt, enterpriseCode, sectionCode);


            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (_salesTtlSt.LogicalDeleteCode == 0))
            {

                // UPD 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //EasyLogger.Write(CLASS_NAME, methodName, "拠点より、売上全体設定情報取得　status：" + status.ToString());
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　拠点より、売上全体設定情報取得　status：" + status.ToString());
                // UPD 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                return _salesTtlSt;
            }
            else
            {
                // 全社拠点より、売上全体設定情報取得
                status = _salesTtlStAcs.Read(out _salesTtlSt, enterpriseCode, "00");

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    && (_salesTtlSt.LogicalDeleteCode == 0))
                {
                    // UPD 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    #region 旧ソース
                    //EasyLogger.Write(CLASS_NAME, methodName, "全社拠点より、売上全体設定情報取得　status：" + status.ToString());
                    //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                    #endregion
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　全社拠点より、売上全体設定情報取得　status：" + status.ToString());
                    // UPD 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                    return _salesTtlSt;
                }
                else
                {
                    // UPD 2013/08/02 #Redmine39451 速度改善6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    #region 旧ソース
                    //EasyLogger.Write(CLASS_NAME, methodName, "全社拠点より、売上全体設定情報取得　status：" + status.ToString());
                    //EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                    #endregion
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了　全社拠点より、売上全体設定情報取得　status：" + status.ToString());
                    // UPD 2013/08/02 #Redmine39451 速度改善6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    return null;
                }
            }
            // UPD 2013/08/02 #Redmine39451 速度改善3 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        //-----ADD songg 2013/06/25 障害報告 #37187の対応 売上全体設定マスタ取得 ----<<<<<

        // UPD 2013/08/01 吉岡 Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region 旧ソース
        //// ADD 2013/07/31 吉岡 得意先管理拠点対応 ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 得意先情報の取得
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="customerCode">得意先コード</param>
        ///// <returns>得意先情報</returns>
        //private CustomerInfo CustomerInfo(string enterpriseCode, int customerCode)
        //{
        //    if (_customerDB == null)
        //    {
        //        _customerDB = new CustomerInfoAcs();
        //    }

        //    if (_customerInfo == null || !_customerInfo.CustomerCode.Equals(customerCode))
        //    {
        //        _customerDB.ReadDBData(enterpriseCode, customerCode, out _customerInfo);
        //    }

        //    return _customerInfo;
        //}
        //// ADD 2013/07/31 吉岡 得意先管理拠点対応 -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion
        /// <summary>
        /// 得意先情報の取得
        /// </summary>
        /// <returns>得意先情報</returns>
        private CustomerInfo CustomerInfo()
        {
            if (_customerDB == null)
            {
                _customerDB = new CustomerInfoAcs();
            }

            if (_customerInfo == null || !_customerInfo.CustomerCode.Equals(this._customerCode))
            {
                _customerDB.ReadDBData(this._enterpriseCode, this._customerCode, out _customerInfo);
            }

            return _customerInfo;
        }
        // UPD 2013/08/01 吉岡 Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<


        #endregion ★共通メソッド

        // ADD 2013/08/01 吉岡 Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 検索時に必要な各値のセット
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        public void SetDataInit(string enterpriseCode, int customerCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._customerCode = customerCode;
        }
        // ADD 2013/08/01 吉岡 Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        
    }
}
