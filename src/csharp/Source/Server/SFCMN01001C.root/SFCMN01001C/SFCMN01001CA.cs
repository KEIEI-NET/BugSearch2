using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;

namespace Broadleaf.ServiceProcess
{
    /// <summary>
    /// ユーザーAPリモートプロキシサーバークラスリソース
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはリモートオブジェクトのプロキシクラス用リソースです。</br>
    /// <br>Programmer : 96137　久保田　信一</br>
    /// <br>Date       : 2005.07.20</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/16  22018 鈴木 正臣</br>
    /// <br>             SCMレガシー売上連携機能追加</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/17  22018 鈴木 正臣</br>
    /// <br>             SCM統合プロジェクト 改良要望対応分 追加</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/22  22018 鈴木 正臣</br>
    /// <br>             ＰＣＣＵＯＥ 追加</br>
    /// <br></br>
    /// <br>Update Note: 2011/09/03  22018 鈴木 正臣</br>
    /// <br>             SCM統合プロジェクト分のマージ</br>
    /// <br>             （2011/08/16、2011/08/17、2011/08/22）</br>
    /// <br></br>
    /// <br>Update Note: 2011/09/15  22018 鈴木 正臣</br>
    /// <br>             SCM統合プロジェクト 要望一覧対応の追加分を追加</br>
    /// <br></br>
    /// <br>Update Note: 2011/10/12  22018 鈴木 正臣</br>
    /// <br>             トヨタUOE自動化の追加</br>
    /// <br></br>
    /// <br>Update Note: 2012/06/29  980035 金沢 貞義</br>
    /// <br>             障害改良対応（2012年07月）</br>
    /// <br></br>
    /// <br>Update Note: 2012/08/01  980035 金沢 貞義</br>
    /// <br>             障害改良対応（2012年08月 SCM改良）</br>
    /// <br></br>
    /// <br>Update Note: 2012/09/05  980035 金沢 貞義</br>
    /// <br>             障害改良対応（2012年011月 SCM改良）</br>
    /// <br></br>
    /// <br>Update Note: 2012/10/25  980035 金沢 貞義</br>
    /// <br>             障害改良対応の取り消し（2012年08月 SCM改良分の取り消し）</br>
    /// <br></br>
    /// <br>Update Note: 2012/11/30 980035 金沢 貞義</br>
    /// <br>             辰巳屋興業対応追加</br>
    /// <br></br>
    /// <br>Update Note: 2013/02/16 980035 金沢 貞義</br>
    /// <br>             仕入返品予定機能追加</br>
    /// <br></br>
    /// <br>Update Note: 2013/02/18 980035 金沢 貞義</br>
    /// <br>             業務メニュー改良追加</br>
    /// <br></br>
    /// <br>Update Note: K2011/07/25 22018 鈴木 正臣</br>
    /// <br>             イスコジャパン個別対応</br>
    /// <br></br>
    /// <br>Update Note: K2011/08/01 22018 鈴木 正臣</br>
    /// <br>             イスコジャパン個別対応２次分</br>
    /// <br></br>
    /// <br>Update Note: K2011/08/12 22018 鈴木 正臣</br>
    /// <br>             イスコジャパン個別対応２次分 Rクラス名変更対応</br>
    /// <br></br>
    /// <br>Update Note: K2011/08/24 22018 鈴木 正臣</br>
    /// <br>             イスコジャパン個別対応３次分</br>
    /// <br></br>
    /// <br>Update Note: K2012/10/23 980035 金沢 貞義</br>
    /// <br>             上高地自動車対応</br>
    /// <br></br>
    /// <br>Update Note: K2012/11/21 980035 金沢 貞義</br>
    /// <br>             四国自動車部品追加</br>
    /// <br></br>
    /// <br>Update Note: K2012/04/19  980035 金沢 貞義</br>
    /// <br>             神姫産業個別対応</br>
    /// <br></br>
    /// <br>Update Note: K2012/08/03  980035 金沢 貞義</br>
    /// <br>             神姫産業個別対応　商品マスタ（インポート）を個別として追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/03/02 20073 西 毅</br>
    /// <br>             太陽オート個別機能追加</br>
    /// <br></br>
    /// <br>Update Note: 2012/10/17  980035 金沢 貞義</br>
    /// <br>             仕入総括対応（東海部品 個別）</br>
    /// <br></br>
    /// <br>Update Note: K2011/07/22 22018 鈴木 正臣</br>
    /// <br>             中村オートパーツ個別対応</br>
    /// <br></br>
    /// <br>Update Note: K2011/08/02 22018 鈴木 正臣</br>
    /// <br>             中村オートパーツ個別対応 不要Ｒ削除</br>
    /// <br></br>
    /// <br>Update Note: K2011/08/02 22018 鈴木 正臣</br>
    /// <br>             中村オートパーツ個別対応２次分</br>
    /// <br></br>
    /// <br>Update Note: K2011/11/04 22018 鈴木 正臣</br>
    /// <br>             中村オートパーツ個別対応２次分 クラス名・サービス名の修正</br>
    /// <br>               集金日別回収予定表が既存パッケージと重複する為、修正。</br>
    /// <br></br>
    /// <br>Update Note: K2012/06/01 980035 金沢 貞義</br>
    /// <br>             関東メカニック対応対応</br>
    /// <br></br>
    /// <br>Update Note: K2012/12/19 980035 金沢 貞義</br>
    /// <br>             ミヤマ対応</br>
    /// <br></br>
    /// <br>Update Note: K2012/06/28 980035 金沢 貞義</br>
    /// <br>             山形部品対応</br>
    /// <br></br>
    /// <br>Update Note: K2012/07/20 980035 金沢 貞義</br>
    /// <br>             山形部品対応追加</br>
    /// <br></br>
    /// <br>Update Note: 2013/03/21 980035 金沢 貞義</br>
    /// <br>             掛率マスタ（一括登録・修正Ⅱ）追加</br>
    /// <br></br>
    /// <br>Update Note: 2013/04/03 980035 金沢 貞義</br>
    /// <br>             辰巳屋興業対応追加（自動送信の追加）</br>
    /// <br></br>
    /// <br>Update Note: K2013/04/30 97427 花原</br>
    /// <br>             和歌山自動車個別対応</br>
    /// <br></br>
    /// <br>Update Note: K2013/05/22 980035 金沢 貞義</br>
    /// <br>             駒田産業対応追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/05/30 980035 金沢 貞義</br>
    /// <br>             山形部品対応追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/06/04 980035 金沢 貞義</br>
    /// <br>             前谷商会対応追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/06/12 980035 金沢 貞義</br>
    /// <br>             宮地小型部品商会追加（PGID変更対応）</br>
    /// <br></br>
    /// <br>Update Note: 2013/06/25 980035 金沢 貞義</br>
    /// <br>             PMタブレット対応追加</br>
    /// <br></br>
    /// <br>Update Note: 2013/07/05 980035 金沢 貞義</br>
    /// <br>             S&Eブレーキ改良追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/07/17 980035 金沢 貞義</br>
    /// <br>             ドーホク追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/08/12 980035 金沢 貞義</br>
    /// <br>             帝北自動車追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/08/13 980035 金沢 貞義</br>
    /// <br>             長尾部品追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/08/14 980035 金沢 貞義</br>
    /// <br>             平沢商会追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/09/26 980035 金沢 貞義</br>
    /// <br>             宮パーツ追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/09/30 980035 金沢 貞義</br>
    /// <br>             エスビー商会追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/10/08 980035 金沢 貞義</br>
    /// <br>             フタバ追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/10/29 980035 金沢 貞義</br>
    /// <br>             横浜商工追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/11/18 980035 金沢 貞義</br>
    /// <br>             カネマス追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/11/22 980035 金沢 貞義</br>
    /// <br>             宮田自動車商会</br>
    /// <br></br>
    /// <br>Update Note: K2013/11/26 980035 金沢 貞義</br>
    /// <br>             大黒商会追加（PGID変更対応）</br>
    /// <br></br>
    /// <br>Update Note: K2013/11/26 980035 金沢 貞義</br>
    /// <br>             エムエストーカイ追加（PGID変更対応）</br>
    /// <br></br>
    /// <br>Update Note: K2013/11/27 980035 金沢 貞義</br>
    /// <br>             フタバ追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/12/05 30940 河原林 一生</br>
    /// <br>             富士制動機製作所対応追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/12/17 980035 金沢 貞義</br>
    /// <br>             ムツミ商事追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/12/17 30940 河原林 一生</br>
    /// <br>             陸整自動車用品個別追加</br>
    /// <br></br>
    /// <br>Update Note: K2013/12/18 30940 河原林 一生</br>
    /// <br>             小林商会個別追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/01/06 30747 三戸 伸悟</br>
    /// <br>             竹川商店追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/01/20 30940 河原林　一生</br>
    /// <br>             川原自動車部品商会個別対応</br>
    /// <br></br>
    /// <br>Update Note: K2014/01/31 30747 三戸 伸悟</br>
    /// <br>             京浜追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/01/31 22008 長内 数馬</br>
    /// <br>             登戸追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/02/05 980035 金沢 貞義</br>
    /// <br>             フタバ追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/03/13 30940 河原林　一生</br>
    /// <br>             福田部品個別対応追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/03/20 30973 鹿庭　一郎</br>
    /// <br>             コンマン部品追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/04/07 30940 河原林 一生</br>
    /// <br>             神吉商会個別追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/4/22 30940 河原林 一生</br>
    /// <br>             杉村部品追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/05/09 30940 河原林 一生</br>
    /// <br>             共栄部品追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/06/27 980035 金沢 貞義</br>
    /// <br>             フタバ追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/07/15 30988 清水 光春</br>
    /// <br>             山中商会追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/09/04 30988 清水 光春</br>
    /// <br>             佐藤車輌部品追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/09/22 30940 河原林 一生</br>
    /// <br>             田宮パーツ追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/11/06 30988 清水 光春</br>
    /// <br>             登戸追加</br>
    /// <br></br>
    /// <br>Update Note: K2014/12/12 chenyk </br>
    /// <br>           : 11070149-00、個別配信、Redmine#30682 障害の対応</br>
    /// <br></br>
    /// <br>Update Note: 2014/12/26 980035 金沢 貞義</br>
    /// <br>             SCM高速化対応</br>
    /// <br></br>
    /// <br>Update Note: K2015/02/06 30940 河原林 一生</br>
    /// <br>             2013/12以降の個別対応分を削除</br>
    /// <br></br>
    /// <br>Update Note: 2015/02/10 30940 河原林 一生</br>
    /// <br>             明治産業 Seiken品番変換対応追加</br>
    /// <br></br>
    /// <br>Update Note: 2015/10/09 30350 櫻井 亮太</br>
    /// <br>             11170140-00 LSM改良</br>
    /// <br></br>
    /// <br>Update Note: 2016/02/04 30350 櫻井 亮太</br>
    /// <br>             11270001-00 部品MAX</br>
    /// <br></br>
    /// <br>Update Note: 2016/06/10 30350 櫻井 亮太</br>
    /// <br>             11270029-00 提案商品管理追加</br>
    /// <br></br>
    /// <br>Update Note: 2017/04/18 30350 櫻井 亮太</br>
    /// <br>             11370016-00 PMタブレットセッション管理対応</br>
    /// <br></br>
    /// <br>Update Note: 2017/05/16 97427 花原 幸代</br>
    /// <br>             掛率ツール追加</br>
    /// <br></br>
    /// <br>Update Note: 2017/07/31 30350 櫻井 亮太</br>
    /// <br>             11370006-00 ハンディターミナル対応</br>
    /// <br></br>
    /// <br>Update Note: 2017/10/13 31622 脇田 靖之</br>
    /// <br>             11370074-00 ハンディターミナル二次対応</br>
    /// <br></br>
    /// <br>Update Note: 2017/11/29 30350 櫻井 亮太</br>
    /// <br>             11370098-00 EDI連携（イエローハット）対応</br>
    /// <br></br>
    /// <br>Update Note: 2018/10/25 31622 脇田 靖之</br>
    /// <br>             11470153-00 伝票番号変換(PM.NS統合ツール)対応</br>
    /// <br></br>
    /// <br>Update Note: 2019/09/06 31739 岸 傑</br>
    /// <br>             11570163-00 テキスト出力ログ対応</br>
    /// <br></br>
    /// <br>Update Note: K2019/09/20 32042 橋本 忠</br>
    /// <br>             11500865-00 第一モーター㈱テキスト出力対応</br>
    /// <br></br>
    /// <br>Update Note: 2019/11/20 31739 岸 傑</br>
    /// <br>             11570136-00 ハンディ6次対応</br>
    /// <br></br>
    /// <br>Update Note: 2019/12/04 30809 佐々木 亘</br>
    /// <br>             11570219-00 売上データ連携</br>
    /// <br></br>
    /// <br>Update Note: 2020/2/19 32471    石崎　智幸</br>
    /// <br>             11670121-00 S&E改良対応</br>
    /// <br>Update Note: 2020/04/06 31739 岸 傑</br>
    /// <br>             11570249-00 ハンディ仕入れ時在庫登録対応</br>
    /// <br></br>
    /// <br>Update Note: 2020/06/15 30809 佐々木 亘</br>
    /// <br>             11670219-00 ＥＢＥ対策</br>
    /// <br></br>
    /// <br>Update Note: 2020/12/01 32470 小原 卓也</br>
    /// <br>             11670305-00 TSPインライン対応</br>
    /// <br></br>
    /// <br>Update Note: 2021/10/26 32427 田村顕成</br>
    /// <br>             一括コード変換対応</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note: 2022/03/18 32427 田村顕成</br>
    /// <br>             11570183-00 電子帳簿対応</br>
    /// <br></br>
    /// </remarks>
    public class Tbs001ServerServiceResource
    {
        /// <summary>
        /// リソース情報取得
        /// </summary>
        /// <returns>リソース情報</returns>
        public static List<RemoteAssemblyInfo> GetRemoteResource()
        {
            List<RemoteAssemblyInfo> retList = new List<RemoteAssemblyInfo>();

            #region 置換開始位置

            # region [PM.NS 1次分＋1.5次分]
            // PM.NS 1次分＋1.5次分
            //retList.Add( new RemoteAssemblyInfo( "", "PMHNB02277R.DLL", "Broadleaf.Application.Remoting.SumBillBalanceTableDB", "MyAppSumBillBalanceTable", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02261R.DLL", "Broadleaf.Application.Remoting.SumBillTableDB", "MyAppSumBillTable", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFDML09064R.DLL", "Broadleaf.Application.Remoting.MailSndMngDB", "MyAppMailSndMng", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "PMTKD00011R.DLL", "Broadleaf.Application.Remoting.VersionChkTkdWorkDB", "MyAppVersionChkTkdWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN00011R.DLL", "Broadleaf.Application.Remoting.VersionChkWorkDB", "MyAppVersionChkWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKOU01111R.DLL", "Broadleaf.Application.Remoting.MonthlyTtlStockUpdDB", "MyAppMonthlyTtlStockUpd", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09265R.DLL", "Broadleaf.Application.Remoting.CustCreditDB", "MyAppCustCredit", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02187R.DLL", "Broadleaf.Application.Remoting.CustSalesDistributionReportResultDB", "MyAppCustSalesDistributionReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKOU04124R.DLL", "Broadleaf.Application.Remoting.SuppYearResultDB", "MyAppSuppYearResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK02044R.DLL", "Broadleaf.Application.Remoting.SalStcCompReportResultWorkDB", "MyAppSalStcCompReportResultWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK02164R.DLL", "Broadleaf.Application.Remoting.SalesSlipYearContrastResultWorkDB", "MyAppSalesSlipYearContrastResultWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKEN09114R.DLL", "Broadleaf.Application.Remoting.TBOSearchUDB", "MyAppTBOSearchU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKOU02027R.DLL", "Broadleaf.Application.Remoting.SlipHistAnalyzeResultWorkDB", "MyAppSlipHistAnalyzeResultWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN08635R.DLL", "Broadleaf.Application.Remoting.SalTrgtPrintResultDB", "MyAppSalTrgtPrintResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN08615R.DLL", "Broadleaf.Application.Remoting.GoodsPrintDB", "MyAppGoodsPrint", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09355R.DLL", "Broadleaf.Application.Remoting.CustomerCustomerChangeDB", "MyAppCustomerCustomerChange", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02137R.DLL", "Broadleaf.Application.Remoting.CustFinancialListResultWorkDB", "MyAppCustFinancialListResultWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02147R.DLL", "Broadleaf.Application.Remoting.ShipGdsPrimeListResultWorkDB", "MyAppShipGdsPrimeListResultWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02167R.DLL", "Broadleaf.Application.Remoting.SalesHistAnalyzeResultWorkDB", "MyAppSalesHistAnalyzeResultWork", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "PMHNB04167R.DLL", "Broadleaf.Application.Remoting.SalesHistAnalyzeResultWorkDB", "MyAppSalesHistAnalyzeResultWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09212R.DLL", "Broadleaf.Application.Remoting.OfferMergeDB", "MyAppOfferMerge", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE01205R.DLL", "Broadleaf.Application.Remoting.UOEStockUpdateDB", "MyAppUOEStockUpdate", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB04155R.DLL", "Broadleaf.Application.Remoting.SalesReportOrderWorkDB", "MyAppSalesReportOrderWork", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "PMHNB04137R.DLL", "Broadleaf.Application.Remoting.CustFinancialListResultWorkDB", "MyAppCustFinancialListResultWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKEN02017R.DLL", "Broadleaf.Application.Remoting.PrmSettingPrintOrderWorkDB", "MyAppPrmSettingPrintOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI02065R.DLL", "Broadleaf.Application.Remoting.TrustStockOrderWorkDB", "MyAppTrustStockOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHAT02012R.DLL", "Broadleaf.Application.Remoting.OrderListRenewWorkDB", "MyAppOrderListRenewWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09245R.DLL", "Broadleaf.Application.Remoting.SumCustStDB", "MyAppSumCustSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI02055R.DLL", "Broadleaf.Application.Remoting.StockSignOrderWorkDB", "MyAppStockSignOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE01006R.DLL", "Broadleaf.Application.Remoting.IOWriteUOEOdrDtlDB", "MyAppIOWriteUOEOdrDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN02016R.DLL", "Broadleaf.Application.Remoting.RatePrtDB", "MyAppRatePrt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI04024R.DLL", "Broadleaf.Application.Remoting.StckAssemOvhulDB", "MyAppStckAssemOvhul", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB04125R.DLL", "Broadleaf.Application.Remoting.CustomInqOrderWorkDB", "MyAppCustomInqOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI04205R.DLL", "Broadleaf.Application.Remoting.InventoryDtDspDB", "MyAppInventoryDtDsp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB04105R.DLL", "Broadleaf.Application.Remoting.SPartsDspDB", "MyAppSPartsDsp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKOU01105R.DLL", "Broadleaf.Application.Remoting.SupplierCheckOrderWorkDB", "MyAppSupplierCheckOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI04105R.DLL", "Broadleaf.Application.Remoting.StockHisDspDB", "MyAppStockHisDsp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKEN09084R.DLL", "Broadleaf.Application.Remoting.PartsSubstDspDB", "MyAppPartsSubstDsp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09174R.DLL", "Broadleaf.Application.Remoting.CustRateGroupDB", "MyAppCustRateGroup", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI08004R.DLL", "Broadleaf.Application.Remoting.FrePStockMoveSlipDB", "MyAppFrePStockMoveSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN08003R.DLL", "Broadleaf.Application.Remoting.ConvertProcessDB", "MyAppConvertProcess", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09234R.DLL", "Broadleaf.Application.Remoting.BLCodeGuideDB", "MyAppBLCodeGuide", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE02096R.DLL", "Broadleaf.Application.Remoting.UOEAnswerLedgerOrderWorkDB", "MyAppUOEAnswerLedgerOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE02086R.DLL", "Broadleaf.Application.Remoting.SupplierSendErOrderWorkDB", "MyAppSupplierSendErOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09225R.DLL", "Broadleaf.Application.Remoting.PriceChgProcStDB", "MyAppPriceChgProcSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE02076R.DLL", "Broadleaf.Application.Remoting.SupplierUnmOrderWorkDB", "MyAppSupplierUnmOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE02056R.DLL", "Broadleaf.Application.Remoting.RecoveryDataOrderWorkDB", "MyAppRecoveryDataOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE02066R.DLL", "Broadleaf.Application.Remoting.EnterSchOrderWorkDB", "MyAppEnterSchOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE01051R.DLL", "Broadleaf.Application.Remoting.UOEOrderDtlDB", "MyAppUOEOrderDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE02046R.DLL", "Broadleaf.Application.Remoting.PublicationConfOrderWorkDB", "MyAppPublicationConfOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE02036R.DLL", "Broadleaf.Application.Remoting.SendBeforOrderWorkDB", "MyAppSendBeforOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI04014R.DLL", "Broadleaf.Application.Remoting.StockAdjRefSearchDB", "MyAppStockAdjRefSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKOU04014R.DLL", "Broadleaf.Application.Remoting.SuppPrtPprWorkDB", "MyAppSuppPrtPprWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI02024R.DLL", "Broadleaf.Application.Remoting.StockMasterTblDB", "MyAppStockMasterTbl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI02044R.DLL", "Broadleaf.Application.Remoting.SalesOrderRemainClearDB", "MyAppSalesOrderRemainClear", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKAU04104R.DLL", "Broadleaf.Application.Remoting.UpdHisDspDB", "MyAppUpdHisDsp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKAU04014R.DLL", "Broadleaf.Application.Remoting.CustPrtPprWorkDB", "MyAppCustPrtPprWork", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "PMCMN00104R.DLL", "Broadleaf.Application.Remoting.TtlDayCalcDB", "MyAppTtlDayCalc", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09134R.DLL", "Broadleaf.Application.Remoting.OperationStDB", "MyAppOperationSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI02018R.DLL", "Broadleaf.Application.Remoting.StockMonthYearReportDataWorkDB", "MyAppStockMonthYearReportDataWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKAU08004R.DLL", "Broadleaf.Application.Remoting.FrePBillDB", "MyAppFrePBill", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09104R.DLL", "Broadleaf.Application.Remoting.CustSlipNoSetDB", "MyAppCustSlipNoSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKEN06062R.DLL", "Broadleaf.Application.Remoting.UsrJoinPartsSearchDB", "MyAppUsrJoinPartsSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKEN09071R.DLL", "Broadleaf.Application.Remoting.JoinPartsUDB", "MyAppJoinPartsU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKEN09032R.DLL", "Broadleaf.Application.Remoting.PrmSettingUDB", "MyAppPrmSettingU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09054R.DLL", "Broadleaf.Application.Remoting.PartsPosCodeUDB", "MyAppPartsPosCodeU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09034R.DLL", "Broadleaf.Application.Remoting.ModelNameUDB", "MyAppModelNameU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKEN09094R.DLL", "Broadleaf.Application.Remoting.PartsSubstUDB", "MyAppPartsSubstU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09044R.DLL", "Broadleaf.Application.Remoting.IsolIslandPrcDB", "MyAppIsolIslandPrc", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09084R.DLL", "Broadleaf.Application.Remoting.CustDmdSetDB", "MyAppCustDmdSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE09024R.DLL", "Broadleaf.Application.Remoting.UOESupplierDB", "MyAppUOESupplier", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE09034R.DLL", "Broadleaf.Application.Remoting.UOEGuideNameDB", "MyAppUOEGuideName", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE09044R.DLL", "Broadleaf.Application.Remoting.UOESettingDB", "MyAppUOESetting", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09064R.DLL", "Broadleaf.Application.Remoting.BLGroupUDB", "MyAppBLGroupU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09074R.DLL", "Broadleaf.Application.Remoting.GoodsGroupUDB", "MyAppGoodsGroupU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB08004R.DLL", "Broadleaf.Application.Remoting.FrePSalesSlipDB", "MyAppFrePSalesSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB01101R.DLL", "Broadleaf.Application.Remoting.MonthlyTtlSalesUpdDB", "MyAppMonthlyTtlSalesUpd", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMJUT01811R.DLL", "Broadleaf.Application.Remoting.AcceptOdrCarDB", "MyAppAcceptOdrCar", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSYR09011R.DLL", "Broadleaf.Application.Remoting.CarManagementDB", "MyAppCarManagement", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFANL08124R.DLL", "Broadleaf.Application.Remoting.FrePrtPSetDB", "MyAppFrePrtPSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFANL08225R.DLL", "Broadleaf.Application.Remoting.FreePprGrpDB", "MyAppFreePprGrp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFANL08234R.DLL", "Broadleaf.Application.Remoting.FrePrtPSetDLDB", "MyAppFrePrtPSetDL", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN04014R.DLL", "Broadleaf.Application.Remoting.CustomerSearchDB", "MyAppCustomerSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09014R.DLL", "Broadleaf.Application.Remoting.CustomerDB", "MyAppCustomer", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09024R.DLL", "Broadleaf.Application.Remoting.SupplierDB", "MyAppSupplier", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHAT01215R.DLL", "Broadleaf.Application.Remoting.OrderPointOrderWorkDB", "MyAppOrderPointOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHAT02115R.DLL", "Broadleaf.Application.Remoting.OrderListWorkDB", "MyAppOrderListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHAT02135R.DLL", "Broadleaf.Application.Remoting.OrderFormListWorkDB", "MyAppOrderFormListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB01115R.DLL", "Broadleaf.Application.Remoting.SupplementOrderWorkDB", "MyAppSupplementOrderWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB01814R.DLL", "Broadleaf.Application.Remoting.IOWriteMAHNBDB", "MyAppIOWriteMAHNB", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB01824R.DLL", "Broadleaf.Application.Remoting.SalesSlipDB", "MyAppSalesSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB01844R.DLL", "Broadleaf.Application.Remoting.SalesSlipHistDB", "MyAppSalesSlipHist", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB01854R.DLL", "Broadleaf.Application.Remoting.SalesTempDB", "MyAppSalesTemp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB01864R.DLL", "Broadleaf.Application.Remoting.IOWriteControlDB", "MyAppIOWriteControl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB02024R.DLL", "Broadleaf.Application.Remoting.OrderConfDB", "MyAppOrderConf", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB02044R.DLL", "Broadleaf.Application.Remoting.SalesDayTotalReportDB", "MyAppSalesDayTotalReport", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB02064R.DLL", "Broadleaf.Application.Remoting.ShipmGoodsOdrReportResultDB", "MyAppShipmGoodsOdrReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB02084R.DLL", "Broadleaf.Application.Remoting.SalesMonthYearReportResultDB", "MyAppSalesMonthYearReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB04114R.DLL", "Broadleaf.Application.Remoting.SalHisRefDB", "MyAppSalHisRef", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB04144R.DLL", "Broadleaf.Application.Remoting.PreChargedDataSelectDB", "MyAppPreChargedDataSelect", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB04165R.DLL", "Broadleaf.Application.Remoting.ShipmentListDB", "MyAppShipmentList", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCHNB04194R.DLL", "Broadleaf.Application.Remoting.SalesAnnualDataSelectResultDB", "MyAppSalesAnnualDataSelectResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCJUT01804R.DLL", "Broadleaf.Application.Remoting.AcceptOdrDB", "MyAppAcceptOdr", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCJUT02024R.DLL", "Broadleaf.Application.Remoting.OrderPursuitListDB", "MyAppOrderPursuitList", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCJUT04114R.DLL", "Broadleaf.Application.Remoting.AcptAnOdrRemainRefDB", "MyAppAcptAnOdrRemainRef", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCJUT04144R.DLL", "Broadleaf.Application.Remoting.OrderPursuitInquiryDtlDB", "MyAppOrderPursuitInquiryDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAK02514R.DLL", "Broadleaf.Application.Remoting.PaymentTableDB", "MyAppPaymentTable", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAK02534R.DLL", "Broadleaf.Application.Remoting.PaymentListWorkDB", "MyAppPaymentListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAK02554R.DLL", "Broadleaf.Application.Remoting.PaymentProgramDB", "MyAppPaymentProgram", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAK02574R.DLL", "Broadleaf.Application.Remoting.PaymentBalanceLedgerDB", "MyAppPaymentBalanceLedger", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAK02594R.DLL", "Broadleaf.Application.Remoting.AccPayBalanceLedgerDB", "MyAppAccPayBalanceLedger", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAK02614R.DLL", "Broadleaf.Application.Remoting.AccPayConsTaxDiffDB", "MyAppAccPayConsTaxDiff", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAK02634R.DLL", "Broadleaf.Application.Remoting.AccPaymentListWorkDB", "MyAppAccPaymentListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAU02534R.DLL", "Broadleaf.Application.Remoting.CollectProgramDB", "MyAppCollectProgram", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAU02554R.DLL", "Broadleaf.Application.Remoting.BillBalanceTableDB", "MyAppBillBalanceTable", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAU02594R.DLL", "Broadleaf.Application.Remoting.DemandBalanceLedgerDB", "MyAppDemandBalanceLedger", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAU02614R.DLL", "Broadleaf.Application.Remoting.AccRecBalanceLedgerDB", "MyAppAccRecBalanceLedger", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAU02624R.DLL", "Broadleaf.Application.Remoting.AccRecConsTaxDiffDB", "MyAppAccRecConsTaxDiff", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKAU02654R.DLL", "Broadleaf.Application.Remoting.CreditMngListWorkDB", "MyAppCreditMngListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09014R.DLL", "Broadleaf.Application.Remoting.SubSectionDB", "MyAppSubSection", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09024R.DLL", "Broadleaf.Application.Remoting.MinSectionDB", "MyAppMinSection", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09044R.DLL", "Broadleaf.Application.Remoting.DGoodsGanreUDB", "MyAppDGoodsGanreU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09094R.DLL", "Broadleaf.Application.Remoting.BLGoodsCdUDB", "MyAppBLGoodsCdU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09104R.DLL", "Broadleaf.Application.Remoting.RateProtyMngDB", "MyAppRateProtyMng", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09134R.DLL", "Broadleaf.Application.Remoting.CustSlipMngDB", "MyAppCustSlipMng", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09144R.DLL", "Broadleaf.Application.Remoting.CustomerChangeDB", "MyAppCustomerChange", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09154R.DLL", "Broadleaf.Application.Remoting.GoodsChangeUDB", "MyAppGoodsChangeU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09164R.DLL", "Broadleaf.Application.Remoting.RateDB", "MyAppRate", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09204R.DLL", "Broadleaf.Application.Remoting.CustSalesTargetDB", "MyAppCustSalesTarget", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09224R.DLL", "Broadleaf.Application.Remoting.SalesTtlStDB", "MyAppSalesTtlSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09244R.DLL", "Broadleaf.Application.Remoting.AcptAnOdrTtlStDB", "MyAppAcptAnOdrTtlSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09264R.DLL", "Broadleaf.Application.Remoting.SlipOutputSetDB", "MyAppSlipOutputSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09284R.DLL", "Broadleaf.Application.Remoting.SystemDspNmDB", "MyAppSystemDspNm", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09294R.DLL", "Broadleaf.Application.Remoting.CompanyInfSyncDB", "MyAppCompanyInfSync", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKOU01064R.DLL", "Broadleaf.Application.Remoting.StockSlipHistDB", "MyAppStockSlipHist", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "DCKOU01074R.DLL", "Broadleaf.Application.Remoting.SlipMemoDB", "MyAppSlipMemo", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKOU02114R.DLL", "Broadleaf.Application.Remoting.StockDayMonthReportDB", "MyAppStockDayMonthReport", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKOU02134R.DLL", "Broadleaf.Application.Remoting.StcRetGdsSlipTtlDataDB", "MyAppStcRetGdsSlipTtlData", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKOU02154R.DLL", "Broadleaf.Application.Remoting.StockDayTotalDataDB", "MyAppStockDayTotalData", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKOU02164R.DLL", "Broadleaf.Application.Remoting.StcRetGdsSlipDtlDataDB", "MyAppStcRetGdsSlipDtlData", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKOU02184R.DLL", "Broadleaf.Application.Remoting.SalesStockDailyMonthlyReportResultDB", "MyAppSalesStockDailyMonthlyReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKOU02324R.DLL", "Broadleaf.Application.Remoting.StockSalesRsltReportDB", "MyAppStockSalesRsltReport", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKOU02344R.DLL", "Broadleaf.Application.Remoting.ArrivalListDB", "MyAppArrivalList", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKOU04114R.DLL", "Broadleaf.Application.Remoting.StcHisRefDataDB", "MyAppStcHisRefData", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCMIT02114R.DLL", "Broadleaf.Application.Remoting.EstimateListWorkDB", "MyAppEstimateListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCMIT02134R.DLL", "Broadleaf.Application.Remoting.StockMonthYearReportResultDB", "MyAppStockMonthYearReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCMIT09014R.DLL", "Broadleaf.Application.Remoting.EstimateDefSetDB", "MyAppEstimateDefSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK02024R.DLL", "Broadleaf.Application.Remoting.SalesDayMonthReportResultDB", "MyAppSalesDayMonthReportResult", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "DCTOK02044R.DLL", "Broadleaf.Application.Remoting.SalStcCompReportResultDB", "MyAppSalStcCompReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK02064R.DLL", "Broadleaf.Application.Remoting.ShipGoodsAnalyzeDB", "MyAppShipGoodsAnalyze", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK02084R.DLL", "Broadleaf.Application.Remoting.StockTransListResultDB", "MyAppStockTransListResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK02104R.DLL", "Broadleaf.Application.Remoting.PrevYearComparisonDB", "MyAppPrevYearComparison", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK02124R.DLL", "Broadleaf.Application.Remoting.SalesRsltListResultDB", "MyAppSalesRsltListResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK02144R.DLL", "Broadleaf.Application.Remoting.SalesTransListResultDB", "MyAppSalesTransListResult", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "DCTOK02164R.DLL", "Broadleaf.Application.Remoting.SalStcCompMonthYearReportDB", "MyAppSalStcCompMonthYearReport", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK02184R.DLL", "Broadleaf.Application.Remoting.PastYearStatisticsDB", "MyAppPastYearStatistics", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCTOK09034R.DLL", "Broadleaf.Application.Remoting.EmployeeDtlDB", "MyAppEmployeeDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCZAI02115R.DLL", "Broadleaf.Application.Remoting.StockManagementListWorkDB", "MyAppStockManagementListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCZAI02135R.DLL", "Broadleaf.Application.Remoting.StockShipArrivalListWorkDB", "MyAppStockShipArrivalListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCZAI02155R.DLL", "Broadleaf.Application.Remoting.StockAnalysisOrderListWorkDB", "MyAppStockAnalysisOrderListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCZAI02175R.DLL", "Broadleaf.Application.Remoting.StockNoShipmentListWorkDB", "MyAppStockNoShipmentListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCZAI02195R.DLL", "Broadleaf.Application.Remoting.StockOverListWorkDB", "MyAppStockOverListWork", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "MACMN00104R.DLL", "Broadleaf.Application.Remoting.GoodsURelationDataDB", "MyAppGoodsURelationData", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MACMN00114R.DLL", "Broadleaf.Application.Remoting.OprtnHisLogDB", "MyAppOprtnHisLog", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "MACMN00134R.DLL", "Broadleaf.Application.Remoting.GoodsRelationDataDB", "MyAppGoodsRelationData", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MACMN00154R.DLL", "Broadleaf.Application.Remoting.SyncServerServiceDB", "MyAppSyncServerService", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MACMN00164R.DLL", "Broadleaf.Application.Remoting.DataUpdMngDB", "MyAppDataUpdMng", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MACMN00174R.DLL", "Broadleaf.Application.Remoting.DataUpdMngOffDB", "MyAppDataUpdMngOff", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MACMN00184R.DLL", "Broadleaf.Application.Remoting.SyncServerServiceOffOffDB", "MyAppSyncServerServiceOffOff", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAGRP09114R.DLL", "Broadleaf.Application.Remoting.SumGrpDivDB", "MyAppSumGrpDiv", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAGRP09124R.DLL", "Broadleaf.Application.Remoting.SumGrpDB", "MyAppSumGrp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAGRP09134R.DLL", "Broadleaf.Application.Remoting.SumGrpMmbrDB", "MyAppSumGrpMmbr", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAGRP09144R.DLL", "Broadleaf.Application.Remoting.AlTtlBlGrStDB", "MyAppAlTtlBlGrSt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAGRP09154R.DLL", "Broadleaf.Application.Remoting.AlTtlGroupStDB", "MyAppAlTtlGroupSt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAGRP09164R.DLL", "Broadleaf.Application.Remoting.AlTtlBlockStDB", "MyAppAlTtlBlockSt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAGRP09174R.DLL", "Broadleaf.Application.Remoting.AllChildSecDB", "MyAppAllChildSec", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAHNB01214R.DLL", "Broadleaf.Application.Remoting.ClaimSalesReadDB", "MyAppClaimSalesRead", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB01514R.DLL", "Broadleaf.Application.Remoting.IOWriteMAHNBDB", "MyAppIOWriteMAHNB", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB01554R.DLL", "Broadleaf.Application.Remoting.SalesSlipDB", "MyAppSalesSlip", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB01574R.DLL", "Broadleaf.Application.Remoting.ContractOptDB", "MyAppContractOpt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB01714R.DLL", "Broadleaf.Application.Remoting.CustomerChangeDB", "MyAppCustomerChange", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB01724R.DLL", "Broadleaf.Application.Remoting.DailyAddUpControlDB", "MyAppDailyAddUpControl", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB01734R.DLL", "Broadleaf.Application.Remoting.DailyAddUpSummaryDB", "MyAppDailyAddUpSummary", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB01744R.DLL", "Broadleaf.Application.Remoting.SalesUpdateControllerDB", "MyAppSalesUpdateController", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAHNB01754R.DLL", "Broadleaf.Application.Remoting.ReceiptDB", "MyAppReceipt", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB01764R.DLL", "Broadleaf.Application.Remoting.SalesBulkUpdateDB", "MyAppSalesBulkUpdate", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAHNB02018R.DLL", "Broadleaf.Application.Remoting.DepsitListWorkDB", "MyAppDepsitListWork", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02028R.DLL", "Broadleaf.Application.Remoting.SalesListDB", "MyAppSalesList", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02244R.DLL", "Broadleaf.Application.Remoting.SalesTransitDtDB", "MyAppSalesTransitDt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02254R.DLL", "Broadleaf.Application.Remoting.MSalesTransitListDB", "MyAppMSalesTransitList", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02294R.DLL", "Broadleaf.Application.Remoting.SalesTotalDtDB", "MyAppSalesTotalDt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02304R.DLL", "Broadleaf.Application.Remoting.MTtlSalesSlipListDB", "MyAppMTtlSalesSlipList", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02324R.DLL", "Broadleaf.Application.Remoting.GrossProfitRstDB", "MyAppGrossProfitRst", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAHNB02354R.DLL", "Broadleaf.Application.Remoting.SalesConfDB", "MyAppSalesConf", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02374R.DLL", "Broadleaf.Application.Remoting.EachTimeSalesTransitDtDB", "MyAppEachTimeSalesTransitDt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02408R.DLL", "Broadleaf.Application.Remoting.ServiceDepositSummaryDB", "MyAppServiceDepositSummary", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02434R.DLL", "Broadleaf.Application.Remoting.CashBookDB", "MyAppCashBook", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02514R.DLL", "Broadleaf.Application.Remoting.SalesOrderDB", "MyAppSalesOrder", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02534R.DLL", "Broadleaf.Application.Remoting.SalesOrderMTDB", "MyAppSalesOrderMT", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02554R.DLL", "Broadleaf.Application.Remoting.ResultsListDB", "MyAppResultsList", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB02914R.DLL", "Broadleaf.Application.Remoting.BusinessDaysReportDB", "MyAppBusinessDaysReport", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB03024R.DLL", "Broadleaf.Application.Remoting.BusinessIndexDB", "MyAppBusinessIndex", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB03124R.DLL", "Broadleaf.Application.Remoting.SalesOdrTraMtDB", "MyAppSalesOdrTraMt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB03144R.DLL", "Broadleaf.Application.Remoting.SalesRstComMtDB", "MyAppSalesRstComMt", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAHNB04114R.DLL", "Broadleaf.Application.Remoting.SearchSalesSlipDB", "MyAppSearchSalesSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAHNB04224R.DLL", "Broadleaf.Application.Remoting.SalesSlipRefWorkDB", "MyAppSalesSlipRefWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAHNB09124R.DLL", "Broadleaf.Application.Remoting.SalesFormalStDB", "MyAppSalesFormalSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAHNB09134R.DLL", "Broadleaf.Application.Remoting.SalesProcMoneyDB", "MyAppSalesProcMoney", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB09264R.DLL", "Broadleaf.Application.Remoting.CariSaInitSetDB", "MyAppCariSaInitSet", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAHNB09814R.DLL", "Broadleaf.Application.Remoting.ShopDailySetDB", "MyAppShopDailySet", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU00123R.DLL", "Broadleaf.Application.Remoting.CustDmdPrcDB", "MyAppCustDmdPrc", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU00133R.DLL", "Broadleaf.Application.Remoting.MonthlyAddUpDB", "MyAppMonthlyAddUp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU00143R.DLL", "Broadleaf.Application.Remoting.SuplierPayDB", "MyAppSuplierPay", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU00172R.DLL", "Broadleaf.Application.Remoting.CustDmdPrcInfGetDB", "MyAppCustDmdPrcInfGet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU00182R.DLL", "Broadleaf.Application.Remoting.CustAccRecInfGetDB", "MyAppCustAccRecInfGet", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKAU00191R.DLL", "Broadleaf.Application.Remoting.ReadDmdCAddUpHisWorkDB", "MyAppReadDmdCAddUpHisWork", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU00201R.DLL", "Broadleaf.Application.Remoting.ReadMonthlyAddUpHisWorkDB", "MyAppReadMonthlyAddUpHisWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU02030R.DLL", "Broadleaf.Application.Remoting.BillTableDB", "MyAppBillTable", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU02040R.DLL", "Broadleaf.Application.Remoting.BillDetailTotalDB", "MyAppBillDetailTotal", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU02050R.DLL", "Broadleaf.Application.Remoting.BillDetailTableDB", "MyAppBillDetailTable", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU09114R.DLL", "Broadleaf.Application.Remoting.CustRsltUpdDB", "MyAppCustRsltUpd", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU09134R.DLL", "Broadleaf.Application.Remoting.SuppRsltUpdDB", "MyAppSuppRsltUpd", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU09154R.DLL", "Broadleaf.Application.Remoting.DmdPrtPtnDB", "MyAppDmdPrtPtn", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU09164R.DLL", "Broadleaf.Application.Remoting.DmdDtlPrtPtnDB", "MyAppDmdDtlPrtPtn", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKAU09174R.DLL", "Broadleaf.Application.Remoting.DmdPrtPtnSetDB", "MyAppDmdPrtPtnSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09114R.DLL", "Broadleaf.Application.Remoting.MakerUDB", "MyAppMakerU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09134R.DLL", "Broadleaf.Application.Remoting.LGoodsGanreUDB", "MyAppLGoodsGanreU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09144R.DLL", "Broadleaf.Application.Remoting.MGoodsGanreUDB", "MyAppMGoodsGanreU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09174R.DLL", "Broadleaf.Application.Remoting.GoodsPriceUDB", "MyAppGoodsPriceU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09224R.DLL", "Broadleaf.Application.Remoting.SalesFormDB", "MyAppSalesForm", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09284R.DLL", "Broadleaf.Application.Remoting.GoodsUDB", "MyAppGoodsU", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKHN09294R.DLL", "Broadleaf.Application.Remoting.CustOpSecDB", "MyAppCustOpSec", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKHN09304R.DLL", "Broadleaf.Application.Remoting.CarrierEpUDB", "MyAppCarrierEpU", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09314R.DLL", "Broadleaf.Application.Remoting.CustomerGroupDB", "MyAppCustomerGroup", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09324R.DLL", "Broadleaf.Application.Remoting.CustGroupDivDB", "MyAppCustGroupDiv", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09334R.DLL", "Broadleaf.Application.Remoting.WarehouseDB", "MyAppWarehouse", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKHN09344R.DLL", "Broadleaf.Application.Remoting.CarrierOdrDB", "MyAppCarrierOdr", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09524R.DLL", "Broadleaf.Application.Remoting.GoodsMngDB", "MyAppGoodsMng", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKHN09564R.DLL", "Broadleaf.Application.Remoting.GoodsKindDB", "MyAppGoodsKind", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09574R.DLL", "Broadleaf.Application.Remoting.SalesContCdmDB", "MyAppSalesContCdm", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09624R.DLL", "Broadleaf.Application.Remoting.GoodsSetDB", "MyAppGoodsSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09634R.DLL", "Broadleaf.Application.Remoting.ImageInfoDB", "MyAppImageInfo", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09644R.DLL", "Broadleaf.Application.Remoting.CustGroupStDB", "MyAppCustGroupSt", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKHN09654R.DLL", "Broadleaf.Application.Remoting.WeatherInfoDB", "MyAppWeatherInfo", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKHN09684R.DLL", "Broadleaf.Application.Remoting.GoodsLinkCodeDB", "MyAppGoodsLinkCode", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "MAKKR00114R.DLL", "Broadleaf.Application.Remoting.JournalizeDB", "MyAppJournalize", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR00134R.DLL", "Broadleaf.Application.Remoting.ProfitLossOutDB", "MyAppProfitLossOut", WellKnownObjectMode.Singleton));
            //retList.Add( new RemoteAssemblyInfo( "", "MAKKR00154R.DLL", "Broadleaf.Application.Remoting.AcctLnkAddUpHisDB", "MyAppAcctLnkAddUpHis", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR01814R.DLL", "Broadleaf.Application.Remoting.RealExpenseDB", "MyAppRealExpense", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR02038R.DLL", "Broadleaf.Application.Remoting.FinancStmntDB", "MyAppFinancStmnt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR09134R.DLL", "Broadleaf.Application.Remoting.JnlNmCrspndDB", "MyAppJnlNmCrspnd", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR09154R.DLL", "Broadleaf.Application.Remoting.JnlItemsSetDB", "MyAppJnlItemsSet", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR09174R.DLL", "Broadleaf.Application.Remoting.ItemsDB", "MyAppItems", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR09184R.DLL", "Broadleaf.Application.Remoting.AssistanceItemsDB", "MyAppAssistanceItems", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR09194R.DLL", "Broadleaf.Application.Remoting.OutItemsMixDB", "MyAppOutItemsMix", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR09214R.DLL", "Broadleaf.Application.Remoting.FinancStmntOutDB", "MyAppFinancStmntOut", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR09234R.DLL", "Broadleaf.Application.Remoting.FncStmtOutItemsDB", "MyAppFncStmtOutItems", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR09254R.DLL", "Broadleaf.Application.Remoting.JnlItemsCustSetDB", "MyAppJnlItemsCustSet", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKKR09274R.DLL", "Broadleaf.Application.Remoting.AcctLnkStDB", "MyAppAcctLnkSt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKNT09114R.DLL", "Broadleaf.Application.Remoting.WorkingStnDayDB", "MyAppWorkingStnDay", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKNT09124R.DLL", "Broadleaf.Application.Remoting.WorkingPtnDB", "MyAppWorkingPtn", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKNT09134R.DLL", "Broadleaf.Application.Remoting.WorkingEmployeeDB", "MyAppWorkingEmployee", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKNT09144R.DLL", "Broadleaf.Application.Remoting.HolidaySettingDB", "MyAppHolidaySetting", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKNT09154R.DLL", "Broadleaf.Application.Remoting.ShiftScheduleDB", "MyAppShiftSchedule", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKNT09164R.DLL", "Broadleaf.Application.Remoting.WorkingDataDB", "MyAppWorkingData", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKNT09174R.DLL", "Broadleaf.Application.Remoting.ServerTimeDB", "MyAppServerTime", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKON01814R.DLL", "Broadleaf.Application.Remoting.IOWriteMASIRDB", "MyAppIOWriteMASIR", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKON01824R.DLL", "Broadleaf.Application.Remoting.StockSlipDB", "MyAppStockSlip", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKON01844R.DLL", "Broadleaf.Application.Remoting.ExtraReadStockSlipDB", "MyAppExtraReadStockSlip", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKON01934R.DLL", "Broadleaf.Application.Remoting.SearchStockSlipDB", "MyAppSearchStockSlip", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKON02028R.DLL", "Broadleaf.Application.Remoting.StockSlipListDB", "MyAppStockSlipList", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKON02224R.DLL", "Broadleaf.Application.Remoting.StockTotalDtDB", "MyAppStockTotalDt", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKON02254R.DLL", "Broadleaf.Application.Remoting.StockConfDB", "MyAppStockConf", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKON02284R.DLL", "Broadleaf.Application.Remoting.StockTotalListWorkDB", "MyAppStockTotalListWork", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKON02324R.DLL", "Broadleaf.Application.Remoting.StcDataRefListWorkDB", "MyAppStcDataRefListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKON02512R.DLL", "Broadleaf.Application.Remoting.SuplierPayInfGetDB", "MyAppSuplierPayInfGet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAKON02612R.DLL", "Broadleaf.Application.Remoting.SuplAccInfGetDB", "MyAppSuplAccInfGet", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAKON02711R.DLL", "Broadleaf.Application.Remoting.ReadPaymentAddUpHisWorkDB", "MyAppReadPaymentAddUpHisWork", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKON02828R.DLL", "Broadleaf.Application.Remoting.CpmStockTotalDB", "MyAppCpmStockTotal", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKON02838R.DLL", "Broadleaf.Application.Remoting.CpmStockTotalMTDB", "MyAppCpmStockTotalMT", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAKON02858R.DLL", "Broadleaf.Application.Remoting.StockTotalMtDtDB", "MyAppStockTotalMtDt", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAKON09304R.DLL", "Broadleaf.Application.Remoting.StockProcMoneyDB", "MyAppStockProcMoney", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAMOK02144R.DLL", "Broadleaf.Application.Remoting.TrgtCompSalesRsltDB", "MyAppTrgtCompSalesRslt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAMOK02164R.DLL", "Broadleaf.Application.Remoting.SalesLandingConfDB", "MyAppSalesLandingConf", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAMOK09114R.DLL", "Broadleaf.Application.Remoting.EmpSalesTargetDB", "MyAppEmpSalesTarget", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAMOK09134R.DLL", "Broadleaf.Application.Remoting.GcdSalesTargetDB", "MyAppGcdSalesTarget", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAMOK09154R.DLL", "Broadleaf.Application.Remoting.SformSlTargetDB", "MyAppSformSlTarget", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAMOK09174R.DLL", "Broadleaf.Application.Remoting.SfcdSalesTargetDB", "MyAppSfcdSalesTarget", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAMOK09204R.DLL", "Broadleaf.Application.Remoting.LdgCalcRatioMngDB", "MyAppLdgCalcRatioMng", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAPOS02118R.DLL", "Broadleaf.Application.Remoting.SearchPosStockDB", "MyAppSearchPosStock", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAPOS02137R.DLL", "Broadleaf.Application.Remoting.StockListPosDB", "MyAppStockListPos", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAPOS02158R.DLL", "Broadleaf.Application.Remoting.SalesListPosDB", "MyAppSalesListPos", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAPOS02178R.DLL", "Broadleaf.Application.Remoting.JournalHisDataDB", "MyAppJournalHisData", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS03154R.DLL", "Broadleaf.Application.Remoting.PosInputDataSearchDB", "MyAppPosInputDataSearch", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS03624R.DLL", "Broadleaf.Application.Remoting.SearchJournalSummaryDB", "MyAppSearchJournalSummary", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAPOS03814R.DLL", "Broadleaf.Application.Remoting.PosInputDataDB", "MyAppPosInputData", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS04214R.DLL", "Broadleaf.Application.Remoting.CashRegisterAdjustmentDB", "MyAppCashRegisterAdjustment", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS09114R.DLL", "Broadleaf.Application.Remoting.PosMessageDB", "MyAppPosMessage", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS09134R.DLL", "Broadleaf.Application.Remoting.PosTtlStDB", "MyAppPosTtlSt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS09214R.DLL", "Broadleaf.Application.Remoting.ReceiptPrtSetDB", "MyAppReceiptPrtSet", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS09224R.DLL", "Broadleaf.Application.Remoting.PosNoMngSetDB", "MyAppPosNoMngSet", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS09234R.DLL", "Broadleaf.Application.Remoting.PosNoTypeMngDB", "MyAppPosNoTypeMng", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS09244R.DLL", "Broadleaf.Application.Remoting.PosMoneyKindDB", "MyAppPosMoneyKind", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAPOS09254R.DLL", "Broadleaf.Application.Remoting.PosGKidInitSetDB", "MyAppPosGKidInitSet", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAPOS09264R.DLL", "Broadleaf.Application.Remoting.BkPosTerminalMgDB", "MyAppBkPosTerminalMg", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAPOS09274R.DLL", "Broadleaf.Application.Remoting.BkPosNoMngSetDB", "MyAppBkPosNoMngSet", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08114R.DLL", "Broadleaf.Application.Remoting.GoodsDB", "MyAppGoods", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08124R.DLL", "Broadleaf.Application.Remoting.CellphoneDB", "MyAppCellphone", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08144R.DLL", "Broadleaf.Application.Remoting.CellphoneModelDB", "MyAppCellphoneModel", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08154R.DLL", "Broadleaf.Application.Remoting.CarrierDB", "MyAppCarrier", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MATKD08164R.DLL", "Broadleaf.Application.Remoting.CarrierEpDB", "MyAppCarrierEp", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08174R.DLL", "Broadleaf.Application.Remoting.LineupDB", "MyAppLineup", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08184R.DLL", "Broadleaf.Application.Remoting.MakerDB", "MyAppMaker", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08194R.DLL", "Broadleaf.Application.Remoting.FuncCategoryDB", "MyAppFuncCategory", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08204R.DLL", "Broadleaf.Application.Remoting.FuncSubCategoryDB", "MyAppFuncSubCategory", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08214R.DLL", "Broadleaf.Application.Remoting.FunctionDB", "MyAppFunction", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08224R.DLL", "Broadleaf.Application.Remoting.EachCpMdlFuncDB", "MyAppEachCpMdlFunc", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08234R.DLL", "Broadleaf.Application.Remoting.EachCpMdlAcsryDB", "MyAppEachCpMdlAcsry", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08244R.DLL", "Broadleaf.Application.Remoting.BLGoodsCdDB", "MyAppBLGoodsCd", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08254R.DLL", "Broadleaf.Application.Remoting.CellphoneSeriesDB", "MyAppCellphoneSeries", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08264R.DLL", "Broadleaf.Application.Remoting.FuncCategoryCDB", "MyAppFuncCategoryC", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08274R.DLL", "Broadleaf.Application.Remoting.FunctionCDB", "MyAppFunctionC", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08284R.DLL", "Broadleaf.Application.Remoting.EachCpMdlFuncCDB", "MyAppEachCpMdlFuncC", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08294R.DLL", "Broadleaf.Application.Remoting.PrcPlnCatgyLDB", "MyAppPrcPlnCatgyL", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08304R.DLL", "Broadleaf.Application.Remoting.PrcPlnCatgyMDB", "MyAppPrcPlnCatgyM", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08314R.DLL", "Broadleaf.Application.Remoting.PricePlanDB", "MyAppPricePlan", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08324R.DLL", "Broadleaf.Application.Remoting.EachLuPricePlanDB", "MyAppEachLuPricePlan", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08334R.DLL", "Broadleaf.Application.Remoting.PricePlanSetDB", "MyAppPricePlanSet", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08344R.DLL", "Broadleaf.Application.Remoting.EachLuPrcPlnSetDB", "MyAppEachLuPrcPlnSet", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08354R.DLL", "Broadleaf.Application.Remoting.PrcPlnSetItmDB", "MyAppPrcPlnSetItm", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08364R.DLL", "Broadleaf.Application.Remoting.FuncSubCatgyCDB", "MyAppFuncSubCatgyC", WellKnownObjectMode.Singleton));
            //retList.Add( new RemoteAssemblyInfo( "", "MATOK05104R.DLL", "Broadleaf.Application.Remoting.SalesAnalysisDB", "MyAppSalesAnalysis", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "MATOK07103R.DLL", "Broadleaf.Application.Remoting.SalesSlipSexCodeDB", "MyAppSalesSlipSexCode", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "MATOK07113R.DLL", "Broadleaf.Application.Remoting.SalesCorporateCodeDB", "MyAppSalesCorporateCode", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "MATOK07123R.DLL", "Broadleaf.Application.Remoting.SalesDetailCarrierDB", "MyAppSalesDetailCarrier", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "MATOK07133R.DLL", "Broadleaf.Application.Remoting.SalesDetailSalesFormDB", "MyAppSalesDetailSalesForm", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "MATOK07143R.DLL", "Broadleaf.Application.Remoting.SalesSlipClienteleCodeDB", "MyAppSalesSlipClienteleCode", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAYYK01814R.DLL", "Broadleaf.Application.Remoting.ResvdDtDB", "MyAppResvdDt", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAZAI02018R.DLL", "Broadleaf.Application.Remoting.RestListCommonWorkDB", "MyAppRestListCommonWork", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI02038R.DLL", "Broadleaf.Application.Remoting.StockMoveListWorkDB", "MyAppStockMoveListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI02058R.DLL", "Broadleaf.Application.Remoting.StockAdjustWorkDB", "MyAppStockAdjustWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI02078R.DLL", "Broadleaf.Application.Remoting.StockListWorkDB", "MyAppStockListWork", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAZAI02088R.DLL", "Broadleaf.Application.Remoting.WhStockListDB", "MyAppWhStockList", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAZAI02098R.DLL", "Broadleaf.Application.Remoting.ProductStockListWorkDB", "MyAppProductStockListWork", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MAZAI02158R.DLL", "Broadleaf.Application.Remoting.EntShipmentListDB", "MyAppEntShipmentList", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI04114R.DLL", "Broadleaf.Application.Remoting.GoodsStockSearchDB", "MyAppGoodsStockSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI04124R.DLL", "Broadleaf.Application.Remoting.StockMoveDB", "MyAppStockMove", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI04134R.DLL", "Broadleaf.Application.Remoting.StockDB", "MyAppStock", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI04218R.DLL", "Broadleaf.Application.Remoting.InventInputSearchDB", "MyAppInventInputSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI04314R.DLL", "Broadleaf.Application.Remoting.StockAcPayHisSearchDB", "MyAppStockAcPayHisSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI04334R.DLL", "Broadleaf.Application.Remoting.StockAcPayHistDB", "MyAppStockAcPayHist", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI04364R.DLL", "Broadleaf.Application.Remoting.StockAdjustDB", "MyAppStockAdjust", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MAZAI04514R.DLL", "Broadleaf.Application.Remoting.StockInquiryDB", "MyAppStockInquiry", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI05118R.DLL", "Broadleaf.Application.Remoting.InventoryExtDB", "MyAppInventoryExt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI05138R.DLL", "Broadleaf.Application.Remoting.InventoryDataUpdateDB", "MyAppInventoryDataUpdate", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MAZAI09114R.DLL", "Broadleaf.Application.Remoting.StockMngTtlStDB", "MyAppStockMngTtlSt", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "SFANL06504R.DLL", "Broadleaf.Application.Remoting.CompanyInfDefDB", "MyCompanyInfDef", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFANL09044R.DLL", "Broadleaf.Application.Remoting.PrtOutSetDB", "MyAppPrtOutSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN00014R.DLL", "Broadleaf.Application.Remoting.RemoteDB", "MyAppRemote", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN00322R.DLL", "Broadleaf.Application.Remoting.TransferSpeedCheckDB", "MyAppTransferSpeedCheck", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN00662R.DLL", "Broadleaf.Application.Remoting.EmployeeLoginDB", "MyEmployeeLogin", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN09064R.DLL", "Broadleaf.Application.Remoting.UserGdBdUDB", "MyAppUserGdBdU", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN09084R.DLL", "Broadleaf.Application.Remoting.AllDefSetDB", "MyAppAllDefSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN09104R.DLL", "Broadleaf.Application.Remoting.NoMngSetDB", "MyAppNoMngSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN09124R.DLL", "Broadleaf.Application.Remoting.OutputSetDB", "MyAppOutputSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN09144R.DLL", "Broadleaf.Application.Remoting.PrtPaperStDB", "MyAppPrtPaperSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN09164R.DLL", "Broadleaf.Application.Remoting.AlItmDspNmDB", "MyAppAlItmDspNm", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFKTN01212R.DLL", "Broadleaf.Application.Remoting.SectionInfo", "MyAppSectionInfo", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFKTN09004R.DLL", "Broadleaf.Application.Remoting.SecInfoSetDB", "MyAppSecInfoSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFKTN09024R.DLL", "Broadleaf.Application.Remoting.SecCtrlSetDB", "MyAppSecCtrlSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFMIT09035R.DLL", "Broadleaf.Application.Remoting.SlipIniSetDB", "MyAppSlipIniSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFMIT09184R.DLL", "Broadleaf.Application.Remoting.CreditCmpDB", "MyAppCreditCmp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFMIT09724R.DLL", "Broadleaf.Application.Remoting.CreditMngDB", "MyAppCreditMng", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFSIR02105R.DLL", "Broadleaf.Application.Remoting.PaymentReadDB", "MyAppPaymentRead", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFSIR02137R.DLL", "Broadleaf.Application.Remoting.PaymentSlpDB", "MyAppPaymentSlp", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "SFSIR02963R.DLL", "Broadleaf.Application.Remoting.CustSuppliDB", "MyAppCustSuppli", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "SFSIR06590R.DLL", "Broadleaf.Application.Remoting.PaymentChkListDB", "MyPaymentChkList", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFSIR09004R.DLL", "Broadleaf.Application.Remoting.StockTtlStDB", "MyAppStockTtlSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFSIR09024R.DLL", "Broadleaf.Application.Remoting.PaymentSetDB", "MyAppPaymentSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD00422R.DLL", "Broadleaf.Application.Remoting.OfferAddressInfoDB", "MyAppOfferAddressInfo", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD02012R.DLL", "Broadleaf.Application.Remoting.PostNumberDB", "MyAppPostNumber", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD08042R.DLL", "Broadleaf.Application.Remoting.UserGdBdDB", "MyAppUserGdBd", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "SFTOK01130R.DLL", "Broadleaf.Application.Remoting.CustomerDB", "MyAppCustomer", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "SFTOK01138R.DLL", "Broadleaf.Application.Remoting.CustomerSearchDB", "MyAppCustomerCarSearch", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "SFTOK01162R.DLL", "Broadleaf.Application.Remoting.CusCarNoteDB", "MyAppCusCarNote", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "SFTOK01172R.DLL", "Broadleaf.Application.Remoting.FamilyDB", "MyAppFamily", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTOK09004R.DLL", "Broadleaf.Application.Remoting.AreaGroupDB", "MyAppAreaGroup", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTOK09384R.DLL", "Broadleaf.Application.Remoting.EmployeeDB", "MyAppEmployee", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTOK09404R.DLL", "Broadleaf.Application.Remoting.NoteGuidBdDB", "MyAppNoteGuidBd", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK01312R.DLL", "Broadleaf.Application.Remoting.SeiKingetDB", "MySeiKinget", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK01341R.DLL", "Broadleaf.Application.Remoting.KingetDepsitMainDB", "MyAppKingetDepsitMain", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK01362R.DLL", "Broadleaf.Application.Remoting.DepsitMainDB", "MyAppDepsitMain", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK01410R.DLL", "Broadleaf.Application.Remoting.DepBillMonSecDB", "MyDepBillMonSec", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK01452R.DLL", "Broadleaf.Application.Remoting.DepositReadDB", "MyAppDepositRead", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK01481R.DLL", "Broadleaf.Application.Remoting.ControlDepsitAlwDB", "MyAppControlDepsitAlw", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK09004R.DLL", "Broadleaf.Application.Remoting.TaxRateSetDB", "MyAppTaxRateSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK09044R.DLL", "Broadleaf.Application.Remoting.MoneyKindDB", "MyAppMoneyKind", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "SFUKK09048R.DLL", "Broadleaf.Application.Remoting.MnyKindDivDB", "MyAppMnyKindDiv", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK09064R.DLL", "Broadleaf.Application.Remoting.DepositStDB", "MyAppDepositSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK09084R.DLL", "Broadleaf.Application.Remoting.BillPrtStDB", "MyAppBillPrtSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK09104R.DLL", "Broadleaf.Application.Remoting.BillAllStDB", "MyAppBillAllSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK09224R.DLL", "Broadleaf.Application.Remoting.RcptDefSetDB", "MyAppRcptDefSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKN09004R.DLL", "Broadleaf.Application.Remoting.CompanyInfDB", "MyCompanyInf", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKN09024R.DLL", "Broadleaf.Application.Remoting.CompanyNmDB", "MyAppCompanyNm", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFURI09024R.DLL", "Broadleaf.Application.Remoting.SlipPrtSetDB", "MyAppSlipPrtSet", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [拠点管理]
            // 拠点管理
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO06001R.DLL", "Broadleaf.Application.Remoting.APMSTControlDB", "MyAppAPMSTControl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO09204R.DLL", "Broadleaf.Application.Remoting.SecMngSndRcvDB", "MyAppSecMngSndRcv", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO09305R.DLL", "Broadleaf.Application.Remoting.ServiceFilesDB", "MyAppServiceFiles", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO09254R.DLL", "Broadleaf.Application.Remoting.SecMngConnectStDB", "MyAppSecMngConnectSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07001R.DLL", "Broadleaf.Application.Remoting.APSendMessageDB", "MyAppAPSendMessage", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO09104R.DLL", "Broadleaf.Application.Remoting.SecMngSetDB", "MyAppSecMngSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO09114R.DLL", "Broadleaf.Application.Remoting.EnterpriseSetDB", "MyAppEnterpriseSet", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [２次分]
            // ２次分
            retList.Add( new RemoteAssemblyInfo( "", "PMHAT02027R.DLL", "Broadleaf.Application.Remoting.OrderSetMasListDB", "MyAppOrderSetMasList", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHAT09005R.DLL", "Broadleaf.Application.Remoting.OrderPointStDB", "MyAppOrderPointSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHAT09111R.DLL", "Broadleaf.Application.Remoting.OrderPointStSimulationDB", "MyAppOrderPointStSimulation", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02207R.DLL", "Broadleaf.Application.Remoting.RateUnMatchDB", "MyAppRateUnMatch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02217R.DLL", "Broadleaf.Application.Remoting.RetGoodsReasonReportResultDB", "MyAppRetGoodsReasonReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02227R.DLL", "Broadleaf.Application.Remoting.SalesStockInfoTableDB", "MyAppSalesStockInfoTable", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB04165R.DLL", "Broadleaf.Application.Remoting.EmployeeResultsListWorkDB", "MyAppEmployeeResultsListWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN02311R.DLL", "Broadleaf.Application.Remoting.GoodsInfoWorkDB", "MyAppGoodsInfoWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN07005R.DLL", "Broadleaf.Application.Remoting.UseMastDB", "MyAppUseMast", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN07614R.DLL", "Broadleaf.Application.Remoting.JoinImportDB", "MyAppJoinImport", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN07624R.DLL", "Broadleaf.Application.Remoting.TBOSearchUImportDB", "MyAppTBOSearchUImport", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN07634R.DLL", "Broadleaf.Application.Remoting.GoodsUImportDB", "MyAppGoodsUImport", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN07644R.DLL", "Broadleaf.Application.Remoting.CustomerImportDB", "MyAppCustomerImport", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN07654R.DLL", "Broadleaf.Application.Remoting.GoodsSetImportDB", "MyAppGoodsSetImport", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09415R.DLL", "Broadleaf.Application.Remoting.RateQuoteDB", "MyAppRateQuote", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09425R.DLL", "Broadleaf.Application.Remoting.UserPriceDB", "MyAppUserPrice", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09435R.DLL", "Broadleaf.Application.Remoting.SaleRateDB", "MyAppSaleRate", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09455R.DLL", "Broadleaf.Application.Remoting.ObjAutoSetControlDB", "MyAppObjAutoSetControl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09505R.DLL", "Broadleaf.Application.Remoting.GoodsNotReturnProcDB", "MyAppGoodsNotReturnProc", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKOU02047R.DLL", "Broadleaf.Application.Remoting.StockSalesInfoTableDB", "MyAppStockSalesInfoTable", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKOU02057R.DLL", "Broadleaf.Application.Remoting.StockSlipResultDB", "MyAppStockSlipResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKOU02067R.DLL", "Broadleaf.Application.Remoting.StockSalesResultInfoTableDB", "MyAppStockSalesResultInfoTable", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [３次分]
            // ３次分
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN01004R.DLL", "Broadleaf.Application.Remoting.DataClearDB", "MyAppDataClear", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN01304R.DLL", "Broadleaf.Application.Remoting.SupplierChangeProcDB", "MyAppSupplierChangeProc", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [Ｓ＆Ｅ]
            // Ｓ＆Ｅ
            retList.Add( new RemoteAssemblyInfo( "", "PMSAE02018R.DLL", "Broadleaf.Application.Remoting.SalesHistoryJoinDB", "MyAppSalesHistoryJoin", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSAE09014R.DLL", "Broadleaf.Application.Remoting.SAndESettingDB", "MyAppSAndESetting", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSAE09024R.DLL", "Broadleaf.Application.Remoting.SAndEGoodsCdChgSetDB", "MyAppSAndEGoodsCdChgSet", WellKnownObjectMode.Singleton ) );
            // --- ADD s.kanazawa 2013/07/05 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMSAE04005R.DLL", "Broadleaf.Application.Remoting.SAndESalSndLogDB", "MyAppSAndESalSndLog", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMSAE09034R.DLL", "Broadleaf.Application.Remoting.SAndEConnectInfoPrcPrStDB", "MyAppSAndEConnectInfoPrcPrSt", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa 2013/07/05 ----------<<<<<
            // --- ADD t.ishizaki 2020/02/19 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMSAE09044R.DLL", "Broadleaf.Application.Remoting.SAndEMkrGdsCdChgSetDB", "MyAppSAndEMkrGdsCdChgSet", WellKnownObjectMode.Singleton));
            // --- ADD t.ishizaki 2020/02/19 ----------<<<<<
            # endregion

            # region [車輌管理]
            // 車輌管理
            retList.Add( new RemoteAssemblyInfo( "", "PMSYA02007R.DLL", "Broadleaf.Application.Remoting.CarShipResultDB", "MyAppCarShipResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSYA04005R.DLL", "Broadleaf.Application.Remoting.CarShipmentPartsDispDB", "MyAppCarShipmentPartsDisp", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [表示区分]
            // 表示区分
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB09005R.DLL", "Broadleaf.Application.Remoting.PriceSelectSetDB", "MyAppPriceSelectSet", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [３次改良]
            // ３次改良
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09274R.DLL", "Broadleaf.Application.Remoting.AllRealUpdToolDB", "MyAppAllRealUpdTool", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI09154R.DLL", "Broadleaf.Application.Remoting.StockHistoryUpdateDB", "MyAppStockHistoryUpdate", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09284R.DLL", "Broadleaf.Application.Remoting.DataBLGoodsRateRankConvertDB", "MyAppDataBLGoodsRateRankConvert", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [４次改良]
            // ４次改良
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02277R.DLL", "Broadleaf.Application.Remoting.SumBillBalanceTableDB", "MyAppSumBillBalanceTable", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [６次改良]
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN03502R.DLL", "Broadleaf.Application.Remoting.FeliCaMngDB", "MyAppFeliCaMng", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN03512R.DLL", "Broadleaf.Application.Remoting.EmployeeLogin2DB", "MyAppEmployeeLogin2", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN07164R.DLL", "Broadleaf.Application.Remoting.GoodsExportDB", "MyAppGoodsExport", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [自由検索]
            retList.Add( new RemoteAssemblyInfo( "", "PMJKN06001R.DLL", "Broadleaf.Application.Remoting.FreeSearchModelSearchDB", "MyAppFreeSearchModelSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMJKN06011R.DLL", "Broadleaf.Application.Remoting.FreeSearchPartsSearchDB", "MyAppFreeSearchPartsSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMJKN02007R.DLL", "Broadleaf.Application.Remoting.FreeSearchModelPrintDB", "MyAppFreeSearchModelPrint", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMJKN02017R.DLL", "Broadleaf.Application.Remoting.FreeSearchPartsPrintDB", "MyAppFreeSearchPartsPrint", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMJKN09005R.DLL", "Broadleaf.Application.Remoting.FreeSearchModelDB", "MyAppFreeSearchModel", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMJKN09015R.DLL", "Broadleaf.Application.Remoting.FreeSearchPartsDB", "MyAppFreeSearchParts", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [売上伝票入力 高速化]
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09804R.DLL", "Broadleaf.Application.Remoting.VariousMasterSearchDB", "MyAppVariousMasterSearch", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [車輌管理２次分]
            retList.Add( new RemoteAssemblyInfo( "", "PMSYA02107R.DLL", "Broadleaf.Application.Remoting.MonthCarInspectListResultDB", "MyAppMonthCarInspectListResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSYA02207R.DLL", "Broadleaf.Application.Remoting.ModelShipResultDB", "MyAppModelShipResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSYA05006R.DLL", "Broadleaf.Application.Remoting.InspectDateUpdDB", "MyAppInspectDateUpd", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [手形管理]
            retList.Add( new RemoteAssemblyInfo( "", "PMTEG02007R.DLL", "Broadleaf.Application.Remoting.TegataConfirmReportResultDB", "MyAppTegataConfirmReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTEG02107R.DLL", "Broadleaf.Application.Remoting.TegataMeisaiListReportResultDB", "MyAppTegataMeisaiListReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTEG02207R.DLL", "Broadleaf.Application.Remoting.TegataKessaiReportResultDB", "MyAppTegataKessaiReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTEG02307R.DLL", "Broadleaf.Application.Remoting.TegataKibiListReportResultDB", "MyAppTegataKibiListReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTEG02407R.DLL", "Broadleaf.Application.Remoting.TegataTsukibetsuYoteListReportResultDB", "MyAppTegataTsukibetsuYoteListReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTEG02507R.DLL", "Broadleaf.Application.Remoting.TegataTorihikisakiListReportResultDB", "MyAppTegataTorihikisakiListReportResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTEG05105R.DLL", "Broadleaf.Application.Remoting.SettlementBillDelDB", "MyAppSettlementBillDel", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTEG09105R.DLL", "Broadleaf.Application.Remoting.PayDraftDataDB", "MyAppPayDraftData", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTEG09105R.DLL", "Broadleaf.Application.Remoting.RcvDraftDataDB", "MyAppRcvDraftData", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [ＳＣＭ]
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM04005R.DLL", "Broadleaf.Application.Remoting.SCMInquiryDB", "MyAppSCMInquiry", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM04105R.DLL", "Broadleaf.Application.Remoting.SCMAnsHistDB", "MyAppSCMAnsHist", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM01021R.DLL", "Broadleaf.Application.Remoting.IOWriteScmDB", "MyAppIOWriteScm", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM09044R.DLL", "Broadleaf.Application.Remoting.SCMNewArrNtfyStDB", "MyAppSCMNewArrNtfySt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM09054R.DLL", "Broadleaf.Application.Remoting.SCMMrktPriStDB", "MyAppSCMMrktPriSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM09064R.DLL", "Broadleaf.Application.Remoting.SCMPriorStDB", "MyAppSCMPriorSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM09005R.DLL", "Broadleaf.Application.Remoting.SCMPrtSettingDB", "MyAppSCMPrtSetting", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM09024R.DLL", "Broadleaf.Application.Remoting.SCMTtlStDB", "MyAppSCMTtlSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM09034R.DLL", "Broadleaf.Application.Remoting.SCMDeliDateStDB", "MyAppSCMDeliDateSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09181R.DLL", "Broadleaf.Application.Remoting.PosTerminalMgDB", "MyAppPosTerminalMg", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09564R.DLL", "Broadleaf.Application.Remoting.CampaignStDB", "MyAppCampaignSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09574R.DLL", "Broadleaf.Application.Remoting.CampaignLinkDB", "MyAppCampaignLink", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09605R.DLL", "Broadleaf.Application.Remoting.CampaignMngDB", "MyAppCampaignMng", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09555R.DLL", "Broadleaf.Application.Remoting.ImportantPrtStDB", "MyAppImportantPrtSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM00205R.DLL", "Broadleaf.Application.Remoting.SimplInqCnectInfoDB", "MySimplInqCnectInfo", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM01055R.DLL", "Broadleaf.Application.Remoting.SCMDtRcveExecDB", "MySCMDtRcveExec", WellKnownObjectMode.Singleton ) ); // 2010/05/20 Add
            // --- ADD s.kanazawa 2014/12/26 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMSCM00210R.DLL", "Broadleaf.Application.Remoting.SynchExecuteMngDB", "MyAppSynchExecuteMng", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMSCM00234R.DLL", "Broadleaf.Application.Remoting.PMOptMngDB", "MyAppPMOptMng", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMSCM00294R.DLL", "Broadleaf.Application.Remoting.PmDbIdMngDB", "MyAppPmDbIdMng", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMSCM04112R.DLL", "Broadleaf.Application.Remoting.SynchConfirmDB", "MyAppSynchConfirm", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMSCM09112R.DLL", "Broadleaf.Application.Remoting.SyncStateDspTermStDB", "MyAppSyncStateDspTermSt", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa 2014/12/26 ----------<<<<<
            # endregion

            # region [携帯メール]
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09594R.DLL", "Broadleaf.Application.Remoting.MailInfoSettingDB", "MyAppMailInfoSetting", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [障害改良対応（８月分）]
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09495R.DLL", "Broadleaf.Application.Remoting.StockMstDB", "MyAppStockMst", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09482R.DLL", "Broadleaf.Application.Remoting.RateProtyMngPatternDB", "MyAppRateProtyMngPattern", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09465R.DLL", "Broadleaf.Application.Remoting.SingleGoodsRateDB", "MyAppSingleGoodsRate", WellKnownObjectMode.Singleton ) );
            # endregion

            // --- ADD m.suzuki 2011/10/12 ---------->>>>>
            # region [トヨタUOE自動化]
            retList.Add( new RemoteAssemblyInfo( "", "PMUOE09054R.DLL", "Broadleaf.Application.Remoting.UOEConnectInfoDB", "MyAppUOEConnectInfo", WellKnownObjectMode.Singleton ) );
            # endregion
            // --- ADD m.suzuki 2011/10/12 ----------<<<<<

            # region [障害改良対応（2011年04月）]
            retList.Add( new RemoteAssemblyInfo( "", "PMZAI04614R.DLL", "Broadleaf.Application.Remoting.StockMoveWorkDB", "MyAppStockMoveWork", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [障害改良対応（2011年07月）]
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09294R.DLL", "Broadleaf.Application.Remoting.BackUpExecutionDB", "MyAppBackUpExecution", WellKnownObjectMode.Singleton ) );
            # endregion

            // --- ADD kanazawa 2012/06/29 ---------->>>>>
            # region [障害改良対応（2012年07月）]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN07274R.DLL", "Broadleaf.Application.Remoting.GoodsMngExportDB", "MyAppGoodsMngExport", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN07604R.DLL", "Broadleaf.Application.Remoting.StockImportDB", "MyAppStockImport", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN07664R.DLL", "Broadleaf.Application.Remoting.GoodsMngImportDB", "MyAppGoodsMngImport", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN08725R.DLL", "Broadleaf.Application.Remoting.PriceSelectSetWorkDB", "MyAppPriceSelectSetWork", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD kanazawa 2012/06/29 ----------<<<<<

            # region [障害改良対応（2012年11月 SCM改良）]
            // --- DLL kanazawa 2012/10/25 // --- ADD kanazawa 2012/08/01 ---------->>>>>
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN09694R.DLL", "Broadleaf.Application.Remoting.BLGoodsCdChgUDB", "MyAppBLGoodsCdChgU", WellKnownObjectMode.Singleton));
            // --- DLL kanazawa 2012/10/25 // --- ADD kanazawa 2012/08/01 ----------<<<<<
            // --- ADD kanazawa 2012/09/05 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09705R.DLL", "Broadleaf.Application.Remoting.AutoAnsItemStDB", "MyAppAutoAnsItemSt", WellKnownObjectMode.Singleton));
            // --- ADD kanazawa 2012/09/05 ----------<<<<<
            # endregion

            # region [キャンペーン管理]
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN02057R.DLL", "Broadleaf.Application.Remoting.CampaignRsltListResultDB", "MyAppCampaignRsltListResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN08707R.DLL", "Broadleaf.Application.Remoting.CampaignMasterWorkDB", "MyAppCampaignMasterWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN08715R.DLL", "Broadleaf.Application.Remoting.CampTrgtPrintResultDB", "MyAppCampTrgtPrintResult", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "PMKHN09564R.DLL", "Broadleaf.Application.Remoting.CampaignStDB", "MyAppCampaignSt", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "PMKHN09574R.DLL", "Broadleaf.Application.Remoting.CampaignLinkDB", "MyAppCampaignLink", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09615R.DLL", "Broadleaf.Application.Remoting.CampaignPrcPrStDB", "MyAppCampaignPrcPrSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09625R.DLL", "Broadleaf.Application.Remoting.CampaignObjGoodsStDB", "MyAppCampaignObjGoodsSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09635R.DLL", "Broadleaf.Application.Remoting.CampaignLoginDB", "MyAppCampaignLogin", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09645R.DLL", "Broadleaf.Application.Remoting.CampaignGoodsStDB", "MyAppCampaignGoodsSt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09655R.DLL", "Broadleaf.Application.Remoting.CampaignTargetUDB", "MyAppCampaignTargetU", WellKnownObjectMode.Singleton ) );
            # endregion

            // --- ADD m.suzuki 2011/08/16 ---------->>>>>
            # region [売上連携]
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM01203R.DLL", "Broadleaf.Application.Remoting.SndAndRcvCSVDB", "MyAppSndAndRcvCSV", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMSCM09074R.DLL", "Broadleaf.Application.Remoting.PM7RkSettingDB", "MyAppPM7RkSetting", WellKnownObjectMode.Singleton ) );
            # endregion
            // --- ADD m.suzuki 2011/08/16 ----------<<<<<

            // --- ADD m.suzuki 2011/08/17 ---------->>>>>
            # region [改良要望対応]
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN01514R.DLL", "Broadleaf.Application.Remoting.YuuRyouDataDelDB", "MyAppYuuRyouDataDel", WellKnownObjectMode.Singleton ) );
            // --- ADD m.suzuki 2011/09/15 ---------->>>>>
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09674R.DLL", "Broadleaf.Application.Remoting.GoodsUpdateDB", "MyAppGoodsUpdate", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09684R.DLL", "Broadleaf.Application.Remoting.StockConvertDB", "MyAppStockConvert", WellKnownObjectMode.Singleton ) );
            // --- ADD m.suzuki 2011/09/15 ----------<<<<<
            # endregion
            // --- ADD m.suzuki 2011/08/17 ----------<<<<<

            // --- ADD m.suzuki 2011/08/22 ---------->>>>>
            # region [PCCUOE]
            retList.Add( new RemoteAssemblyInfo( "", "PMPCC09004R.DLL", "Broadleaf.Application.Remoting.PccTtlStDB", "MyAppPccTtlSt", WellKnownObjectMode.Singleton ) );
            # endregion
            // --- ADD m.suzuki 2011/08/22 ----------<<<<<

            // --- ADD s.kanazawa 2012/11/30 ---------->>>>>
            # region [辰巳屋興業対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN07705R.DLL", "Broadleaf.Application.Remoting.SalesSliptextResultDB", "MyAppSalesSliptextResult", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa 2013/04/03 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09715R.DLL", "Broadleaf.Application.Remoting.ConnectInfoPrcPrStDB", "MyAppConnectInfoPrcPrSt", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa 2013/04/03 ----------<<<<<
            # endregion
            // --- ADD s.kanazawa 2012/11/30 ----------<<<<<

            // --- ADD s.kanazawa 2013/02/16 ---------->>>>>
            # region [仕入返品予定機能対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKAK01102R.DLL", "Broadleaf.Application.Remoting.StockSlipRetPlnDB", "MyAppStockSlipRetPln", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK02037R.DLL", "Broadleaf.Application.Remoting.StockRetPlnTableDB", "MyAppStockRetPlnTable", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa 2013/02/16 ----------<<<<<

            // --- ADD s.kanazawa 2013/02/18 ---------->>>>>
            # region [業務メニュー改良対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09725R.DLL", "Broadleaf.Application.Remoting.RoleGroupNameStDB", "MyAppRoleGroupNameSt", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09734R.DLL", "Broadleaf.Application.Remoting.RoleGroupAuthDB", "MyAppRoleGroupAuth", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09745R.DLL", "Broadleaf.Application.Remoting.EmployeeRoleStDB", "MyAppEmployeeRoleSt", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02205R.DLL", "Broadleaf.Application.Remoting.MenueStDB", "MyAppMenueSt", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa 2013/02/18 ----------<<<<<

            // --- ADD s.kanazawa 2013/03/21 ---------->>>>>
            # region [掛率マスタ（一括登録・修正Ⅱ）]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09906R.DLL", "Broadleaf.Application.Remoting.Rate2DB", "MyAppRate2", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa 2013/03/21 ----------<<<<<

            // --- ADD s.kanazawa 2013/06/25 ---------->>>>>
            # region [PMタブレット対応]
            retList.Add(new RemoteAssemblyInfo("", "PMTAB00174R.DLL", "Broadleaf.Application.Remoting.PmTabAcpOdrCarDB", "MyAppPmTabAcpOdrCar", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTAB00184R.DLL", "Broadleaf.Application.Remoting.PmTabUpldExclsvDB", "MyAppPmTabUpldExclsv", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTAB09104R.DLL", "Broadleaf.Application.Remoting.PmTabTtlStSecDB", "MyAppPmTabTtlStSec", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTAB09114R.DLL", "Broadleaf.Application.Remoting.PmTabTtlStCustDB", "MyAppPmTabTtlStCust", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa 2013/06/25 ----------<<<<<

            // --- ADD s.kanazawa K2013/10/08 ---------->>>>>
            # region [UOE自動発注処理 フタバ個別対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09754R.DLL", "Broadleaf.Application.Remoting.ProtyWarehouseDB", "MyAppProtyWarehouse", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/10/08 ----------<<<<<

            // --- ADD m.kawarabayashi 2015/02/10 ---------->>>>>
            #region 明治産業 Seiken品番変換対応
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01703R.DLL", "Broadleaf.Application.Remoting.MeijiGoodsChgAllDB", "MyAppMeijiGoodsChgAll", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09765R.DLL", "Broadleaf.Application.Remoting.GoodsNoChangeDB", "MyAppGoodsNoChange", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD m.kawarabayashi 2015/02/10 ----------<<<<<

            // --- ADD r.sakruai 2015/10/09 ---------->>>>>
            #region LSM改良
            retList.Add(new RemoteAssemblyInfo("", "PMCMN00081R.DLL", "Broadleaf.Application.Remoting.LSMLogCheckDB", "MyAppLSMLogCheck", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD r.sakurai 2015/10/09 ----------<<<<<

            // --- ADD r.sakruai 2016/02/04 ---------->>>>>
            #region 部品MAX
            retList.Add(new RemoteAssemblyInfo("", "PMMAX02004R.DLL", "Broadleaf.Application.Remoting.PartsMaxStockArrivalDB", "MyAppPartsMaxStockArrival", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMMAX02014R.DLL", "Broadleaf.Application.Remoting.PartsMaxStockUpdDB", "MyAppPartsMaxStockUpd", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD r.sakurai 2016/02/04 ----------<<<<<

            // --- ADD r.sakruai 2016/06/10 ---------->>>>>
            #region 提案商品管理
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09516R.DLL", "Broadleaf.Application.Remoting.TBODataExportDB", "MyAppTBODataExport", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD r.sakurai 2016/06/10 ----------<<<<<

            // --- ADD r.sakruai 2017/04/18 ---------->>>>>
            #region PMタブレットセッション管理対応
            retList.Add(new RemoteAssemblyInfo("", "PMTAB00211R.DLL", "Broadleaf.Application.Remoting.PmTabSessionMngDB", "MyAppPmTabSessionMng", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD r.sakruai 2017/04/18 ----------<<<<<

            // --- ADD y.hanahara 2017/05/16 ---------->>>>>
            #region パッケージ正式対応前のツール(掛率マスタエクスポートインポート)
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09816R.DLL",  "Broadleaf.Application.Remoting.RateTextDB", "MyAppRateText", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD y.hanahara 2017/05/16 ----------<<<<<

            // --- ADD r.sakruai 2017/07/31 ---------->>>>>
            #region ハンディターミナル対応
            retList.Add(new RemoteAssemblyInfo("", "PMHND00012R.DLL", "Broadleaf.Application.Remoting.HandyLoginInfoDB", "MyAppHandyLoginInfo", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND00211R.DLL", "Broadleaf.Application.Remoting.InspectDataDB", "MyAppInspectData", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND04002R.DLL", "Broadleaf.Application.Remoting.HandyInspectDB", "MyAppHandyInspect", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND04102R.DLL", "Broadleaf.Application.Remoting.HandyStockDB", "MyAppHandyStock", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND04204R.DLL", "Broadleaf.Application.Remoting.HandyInspectRefDataDB", "MyAppHandyInspectRefData", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND09114R.DLL", "Broadleaf.Application.Remoting.InspectTtlStDB", "MyAppInspectTtlSt", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND09214R.DLL", "Broadleaf.Application.Remoting.GoodsBarCodeRevnDB", "MyAppGoodsBarCodeRevn", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND09306R.DLL", "Broadleaf.Application.Remoting.HandyGoodsBarCodeDB", "MyAppHandyGoodsBarCode", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD r.sakruai 2017/07/31 ----------<<<<<

            // --- ADD y.wakita 2017/10/13 ---------->>>>>
            #region ハンディターミナル二次対応
            retList.Add(new RemoteAssemblyInfo("", "PMHND01112R.DLL", "Broadleaf.Application.Remoting.HandyStockSupplierDB", "MyAppHandyStockSupplier", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND01212R.DLL", "Broadleaf.Application.Remoting.HandyStockMoveDB", "MyAppHandyStockMove", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND01302R.DLL", "Broadleaf.Application.Remoting.HandyConsStockRepDB", "MyAppHandyConsStockRep", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND04302R.DLL", "Broadleaf.Application.Remoting.HandySupplierGuideDB", "MyAppHandySupplierGuide", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND05502R.DLL", "Broadleaf.Application.Remoting.HandyInventoryDataDB", "MyAppHandyInventoryData", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHND09412R.DLL", "Broadleaf.Application.Remoting.PrmGoodsBarCodeRevnUpdateDB", "MyAppPrmGoodsBarCodeRevnUpdate", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD y.wakita 2017/10/13 ----------<<<<<

            // --- ADD r.sakurai 2017/11/29 ---------->>>>>
            #region EDI連携対応
            retList.Add(new RemoteAssemblyInfo("", "PMEDI09013R.DLL", "Broadleaf.Application.Remoting.EDICooperatStDB", "MyAppEDICooperatSt", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMEDI02014R.DLL", "Broadleaf.Application.Remoting.EDISalesResultDB", "MyAppEDISalesResult", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD r.sakurai 2017/11/29 ----------<<<<<

            // --- ADD y.wakita 2018/10/25 ---------->>>>>
            #region 伝票番号変換(PM.NS統合ツール)対応
            retList.Add(new RemoteAssemblyInfo("", "PMKHN05155R.DLL", "Broadleaf.Application.Remoting.SlpNoConvertDB", "MyAppSlipNoConvert", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD y.wakita 2018/10/25 ----------<<<<<

            // --- ADD m.suzuki K2011/07/25 ---------->>>>>
            # region [イスコジャパン個別対応]
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02704RC.DLL", "Broadleaf.Application.Remoting.SalesSlipResultDB", "MyAppSalesSlipResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN08704RC.DLL", "Broadleaf.Application.Remoting.CostExpandDB", "MyAppCostExpand", WellKnownObjectMode.Singleton ) );
            # endregion
            // --- ADD m.suzuki K2011/07/25 ----------<<<<<
            // --- ADD m.suzuki K2011/08/01 ---------->>>>>
            # region [イスコジャパン個別対応2次分]
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN02804RC.DLL", "Broadleaf.Application.Remoting.ReducedValueStOutDB", "MyAppReducedValueStOut", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN09704RC.DLL", "Broadleaf.Application.Remoting.ReducedValueStDB", "MyAppReducedValueSt", WellKnownObjectMode.Singleton ) );
            // --- UPD m.suzuki K2011/08/12 ---------->>>>>
            //retList.Add( new RemoteAssemblyInfo( "", "PMTOK02214RC.DLL", "Broadleaf.Application.Remoting.SalesRsltListResultDB", "MyAppSalesRsltListResult", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "PMTOK02244RC.DLL", "Broadleaf.Application.Remoting.SalesTransListResultDB", "MyAppSalesTransListResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTOK02214RC.DLL", "Broadleaf.Application.Remoting.SalesRsltListResult2DB", "MyAppSalesRsltListResult2", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTOK02244RC.DLL", "Broadleaf.Application.Remoting.SalesTransListResult2DB", "MyAppSalesTransListResult2", WellKnownObjectMode.Singleton ) );
            // --- UPD m.suzuki K2011/08/12 ----------<<<<<
            # endregion
            // --- ADD m.suzuki K2011/08/01 ----------<<<<<
            // --- ADD m.suzuki K2011/08/24 ---------->>>>>
            # region [イスコジャパン個別対応3次分]
            // --- UPD m.suzuki K2011/09/02 ---------->>>>>
            //// --- UPD m.suzuki K2011/08/29 ---------->>>>>
            ////retList.Add( new RemoteAssemblyInfo( "", "PMCMN07004RC.DLL", "Broadleaf.Application.Remoting.GetServerTime", "", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "PMCMN07004RC.DLL", "Broadleaf.Application.Remoting.GetServerTime", "MyAppGetServerTime", WellKnownObjectMode.Singleton ) );
            //// --- UPD m.suzuki K2011/08/29 ----------<<<<<
            retList.Add( new RemoteAssemblyInfo( "", "PMCMN07004RC.DLL", "Broadleaf.Application.Remoting.GetServerTimeDB", "MyAppGetServerTime", WellKnownObjectMode.Singleton ) );
            // --- UPD m.suzuki K2011/09/02 ----------<<<<<
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02314RC.DLL", "Broadleaf.Application.Remoting.TotalSlipDB", "MyAppTotalSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMHNB02344RC.DLL", "Broadleaf.Application.Remoting.SumDelvCheListDB", "MyAppSumDelvCheList", WellKnownObjectMode.Singleton ) );
            # endregion
            // --- ADD m.suzuki K2011/08/24 ----------<<<<<

            // --- ADD s.kanazawa K2012/10/23 ---------->>>>>
            # region [上高地自動車対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01958RC.DLL", "Broadleaf.Application.Remoting.SalesSlipDataTorikDB", "MyAppSalesSlipDataTorik", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2012/10/23 ----------<<<<<

            // --- ADD s.kanazawa K2012/11/21 ---------->>>>>
            # region [四国自動車部品]
            retList.Add(new RemoteAssemblyInfo("", "PMTOK02907RC.DLL", "Broadleaf.Application.Remoting.CustomerAndPuredivSupplyListDB", "MyAppCustomerAndPuredivSupplyList", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2012/11/21 ----------<<<<<

            // --- ADD s.Kanazawa K2012/04/19 ---------->>>>>
            # region [神姫産業個別]
            retList.Add(new RemoteAssemblyInfo("", "MAHNB02018RC.DLL", "Broadleaf.Application.Remoting.DepsitList2WorkDB", "MyAppDepsitList2Work", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02277RC.DLL", "Broadleaf.Application.Remoting.SumBillBalanceSecTableDB", "MyAppSumBillBalanceSecTable", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02907RC.DLL", "Broadleaf.Application.Remoting.DepsitListWorkTwoDB", "MyAppDepsitListTwoWork", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02917RC.DLL", "Broadleaf.Application.Remoting.CustomerNotDB", "MyAppCustomerNot", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02911RC.DLL", "Broadleaf.Application.Remoting.HandWritingTableDB", "MyAppHandWritingTable", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01911RC.DLL", "Broadleaf.Application.Remoting.SalesHistoryConversionDB", "MyAppSalesHistoryConversion", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "MAZAI04218RC.DLL", "Broadleaf.Application.Remoting.InventInputSearch2DB", "MyAppInventInputSearch2", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTEG02007RC.DLL", "Broadleaf.Application.Remoting.TegataConfirmReport2ResultDB", "MyAppTegataConfirmReport2Result", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2012/08/03 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMKHN07634RC.DLL", "Broadleaf.Application.Remoting.GoodsUImport2DB", "MyAppGoodsUImport2", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2012/08/03 ----------<<<<<
            # endregion
            // --- ADD s.Kanazawa K2012/04/19 ----------<<<<<

            // --- ADD T.Nishi K2013/03/02 ---------->>>>>
            # region [太陽オート個別対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02907RC.DLL", "Broadleaf.Application.Remoting.CollectProgram2DB", "MyAppCollectProgram2", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD T.Nishi K2013/03/02 ----------<<<<<

            // --- ADD s.kanazawa 2012/10/17 ---------->>>>>
            # region [仕入総括対応（東海部品 個別）]
            retList.Add(new RemoteAssemblyInfo("", "PMKAK02007R.DLL", "Broadleaf.Application.Remoting.SumPaymentTableDB", "MyAppSumPaymentTable", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK02027R.DLL", "Broadleaf.Application.Remoting.SumAccPaymentListWorkDB", "MyAppSumAccPaymentListWork", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK09004R.DLL", "Broadleaf.Application.Remoting.SumSuppStDB", "MyAppSumSuppSt", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK09017R.DLL", "Broadleaf.Application.Remoting.SumSuppStPrintResultDB", "MyAppSumSuppStPrintResult", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa 2012/10/17 ----------<<<<<

            // --- ADD m.suzuki K2011/07/22 ---------->>>>>
            # region [中村オートパーツ個別対応]
            // --- DEL m.suzuki K2011/08/02 ---------->>>>>
            //retList.Add( new RemoteAssemblyInfo( "", "PMHNB02914RC.DLL", "Broadleaf.Application.Remoting.SalesSlipResultDB", "MyAppSalesSlipResult", WellKnownObjectMode.Singleton ) );
            // --- DEL m.suzuki K2011/08/02 ----------<<<<<
            retList.Add( new RemoteAssemblyInfo( "", "PMTOK02914RC.DLL", "Broadleaf.Application.Remoting.CampRsltListDB", "MyAppCampRsltList", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTOK02994RC.DLL", "Broadleaf.Application.Remoting.SalesMonthYearResultDB", "MyAppSalesMonthYearResult", WellKnownObjectMode.Singleton ) );
            # endregion
            // --- ADD m.suzuki K2011/07/22 ----------<<<<<
            // --- ADD m.suzuki K2011/08/02 ---------->>>>>
            # region [中村オートパーツ個別対応２次分]
            // --- UPD m.suzuki K2011/11/04 ---------->>>>>
            //retList.Add( new RemoteAssemblyInfo( "", "PMKAU02914RC.DLL", "Broadleaf.Application.Remoting.CollectProgramDB", "MyAppCollectProgram", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKAU02914RC.DLL", "Broadleaf.Application.Remoting.CoCollectProgramDB", "MyAppCoCollectProgram", WellKnownObjectMode.Singleton ) );
            // --- UPD m.suzuki K2011/11/04 ----------<<<<<
            retList.Add( new RemoteAssemblyInfo( "", "PMKAU04914RC.DLL", "Broadleaf.Application.Remoting.CustDmdDB", "MyAppCustDmd", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTOK02934RC.DLL", "Broadleaf.Application.Remoting.CampTransListDB", "MyAppCampTransList", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTOK02954RC.DLL", "Broadleaf.Application.Remoting.SalSalesMonthYearResultDB", "MyAppSalSalesMonthYearResult", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTOK02974RC.DLL", "Broadleaf.Application.Remoting.SalesDivCompareDB", "MyAppSalesDivCompare", WellKnownObjectMode.Singleton ) );
            # endregion
            // --- ADD m.suzuki K2011/08/02 ----------<<<<<
            // --- ADD m.suzuki K2012/03/19 ---------->>>>>
            # region [関東メカニック対応]
            // --- ADD s.kanazawa K2012/06/01 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMKYO01915RC.DLL", "Broadleaf.Application.Remoting.DataReceiveInputTwoDB", "MyAppDataReceiveInputTwo", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2012/06/01 ----------<<<<<
            retList.Add(new RemoteAssemblyInfo("", "PMKYO09904RC.DLL", "Broadleaf.Application.Remoting.KmSecMngSetDB", "MyAppKmSecMngSet", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD m.suzuki K2012/03/19 ----------<<<<<

            // --- ADD s.kanazawa K2012/12/19 ---------->>>>>
            # region [ミヤマ対応]
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02904RC.DLL", "Broadleaf.Application.Remoting.FrePSalesSlipRePntDB", "MyAppFrePSalesSlipRePnt", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2012/12/19 ----------<<<<<

            // --- ADD s.kanazawa K2012/06/28 ---------->>>>>
            # region [山形部品対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01916RC.DLL", "Broadleaf.Application.Remoting.SalesSlipDtlDB", "MyAppSalesSlipDtl", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01926RC.DLL", "Broadleaf.Application.Remoting.DepositSlipDtlDB", "MyAppDepositSlipDtl", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01936RC.DLL", "Broadleaf.Application.Remoting.StockSlipDtlDB", "MyAppStockSlipDtl", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN01946RC.DLL", "Broadleaf.Application.Remoting.StockMoveDB", "MyAppStockMove", WellKnownObjectMode.Singleton));   // --- DEL s.kanazawa K2012/07/20
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01946RC.DLL", "Broadleaf.Application.Remoting.StockMove2DB", "MyAppStockMove2", WellKnownObjectMode.Singleton));   // --- ADD s.kanazawa K2012/07/20
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09906RC.DLL", "Broadleaf.Application.Remoting.CustomerMasDB", "MyAppCustomerMas", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09916RC.DLL", "Broadleaf.Application.Remoting.SupplierMasDB", "MyAppSupplierMas", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09926RC.DLL", "Broadleaf.Application.Remoting.GoodsUMasDB", "MyAppGoodsUMas", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09936RC.DLL", "Broadleaf.Application.Remoting.StockMasDB", "MyAppStockMas", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09946RC.DLL", "Broadleaf.Application.Remoting.InventoryMasDB", "MyAppInventoryMas", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09956RC.DLL", "Broadleaf.Application.Remoting.GoodsURfDB", "MyAppGoodsURf", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09966RC.DLL", "Broadleaf.Application.Remoting.TtlSalesSlipDB", "MyAppTtlSalesSlip", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2012/07/20 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02911RC.DLL", "Broadleaf.Application.Remoting.SalesConf2DB", "MyAppSalesConf2", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2012/07/20 ----------<<<<<
            // --- ADD s.kanazawa K2013/05/30 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01804RC.DLL", "Broadleaf.Application.Remoting.GoodsUImport3DB", "MyAppGoodsUImport3", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2013/05/30 ----------<<<<<
            # endregion
            // --- ADD s.kanazawa K2012/06/28 ----------<<<<<

            // --- ADD s.kanazawa K2013/04/30 ---------->>>>>
            # region [和歌山自動車個別対応]
            retList.Add(new RemoteAssemblyInfo("", "PMTOK02808RC.DLL", "Broadleaf.Application.Remoting.SalesResultListResultDB", "MyAppSalesResultListResult", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02988RC.DLL", "Broadleaf.Application.Remoting.CustDeopositSalesDB", "MyAppCustDeopositSales", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02928RC.DLL", "Broadleaf.Application.Remoting.DensoSlipDataDB", "MyAppDensoSlipData", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02968RC.DLL", "Broadleaf.Application.Remoting.DepositDataTorikDB", "MyAppDepositDataTorik", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/04/30 ----------<<<<<

            // --- ADD s.kanazawa K2013/05/22 ---------->>>>>
            # region [駒田対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKAK09904RC.DLL", "Broadleaf.Application.Remoting.JournalizeStDB", "MyAppJournalizeSt", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK09917RC.DLL", "Broadleaf.Application.Remoting.JournalizeSetDB", "MyAppJournalizeSet", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02807RC.DLL", "Broadleaf.Application.Remoting.SearchAcpOdrBlDmdDB", "MyAppSearchAcpOdrBlDmd", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02817RC.DLL", "Broadleaf.Application.Remoting.AccRecAndCreditTableDB", "MyAppAccRecAndCreditTable", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02987RC.DLL", "Broadleaf.Application.Remoting.KsalesRsltListResultDB", "MyAppKsalesRsltListResult", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMMOK09006RC.DLL", "Broadleaf.Application.Remoting.JourSalesTargetDB", "MyAppJourSalesTarget", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD s.kanazawa K2013/05/22 ----------<<<<<

            // --- ADD s.kanazawa K2013/06/04 ---------->>>>>
            # region [前谷商会対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02818RC.DLL", "Broadleaf.Application.Remoting.DMPrintDB", "MyAppDMPrint", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/06/04 ----------<<<<<

            // --- ADD s.kanazawa K2013/06/12 ---------->>>>>
            # region [宮地小型部品商会]
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02967RC.DLL", "Broadleaf.Application.Remoting.TempSlipNoCheckListDB", "MyAppTempSlipNoCheckList", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/06/12 ----------<<<<<

            // --- ADD s.kanazawa K2013/07/17 ---------->>>>>
            # region [ドーホク]
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02807RC.DLL", "Broadleaf.Application.Remoting.DohokuSalesConfDB", "MyAppDohokuSalesConf", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01969RC.DLL", "Broadleaf.Application.Remoting.DohokuSalseSlipDataDB", "MyAppDohokuSalseSlipData", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01989RC.DLL", "Broadleaf.Application.Remoting.DohokuSalesHistoryJoinDB", "MyAppDohokuSalesHistoryJoin", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/07/17 ----------<<<<<

            // --- ADD s.kanazawa K2013/08/12 ---------->>>>>
            # region [帝北自動車]
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02357RC.DLL", "Broadleaf.Application.Remoting.TotalSlipDataDB", "MyAppTotalSlipData", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTOK02797RC.DLL", "Broadleaf.Application.Remoting.PrevYearComparison2DB", "MyAppPrevYearComparison2", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/08/12 ----------<<<<<

            // --- ADD s.kanazawa K2013/08/13 ---------->>>>>
            # region [長尾部品]
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02405RC.DLL", "Broadleaf.Application.Remoting.SearchSalesSlipNaGaoDB", "MyAppSearchSalesSlipNaGao", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/08/13 ----------<<<<<

            // --- ADD s.kanazawa K2013/08/14 ---------->>>>>
            # region [平沢商会]
            retList.Add(new RemoteAssemblyInfo("", "PMKAK02107RC.DLL", "Broadleaf.Application.Remoting.PaymentTableCDB", "MyAppPaymentTableC", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02307RC.DLL", "Broadleaf.Application.Remoting.CustDmdPrcBalanceLedgerCDB", "MyAppCustDmdPrcBalanceLedgerC", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/08/14 ----------<<<<<

            // --- ADD s.kanazawa K2013/09/26 ---------->>>>>
            # region [宮パーツ]
            retList.Add(new RemoteAssemblyInfo("", "PMKAK02927RC.DLL", "Broadleaf.Application.Remoting.JournalizeMstSetDB", "MyAppJournalizeMstSet", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK02937RC.DLL", "Broadleaf.Application.Remoting.JourSalesDataDB", "MyAppJourSalesData", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK02947RC.DLL", "Broadleaf.Application.Remoting.SiwakeGrpCompReportResultWorkDB", "MyAppSiwakeGrpCompReportResultWork", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK09924RC.DLL", "Broadleaf.Application.Remoting.JournalizeStMstDB", "MyAppJournalizeStMst", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU01995RC.DLL", "Broadleaf.Application.Remoting.MiyaSalesHistoryJoinDB", "MyAppMiyaSalesHistoryJoin", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02107RC.DLL", "Broadleaf.Application.Remoting.BillTableMiYaDB", "MyAppBillTableMiYa", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02117RC.DLL", "Broadleaf.Application.Remoting.BillBalanceForIndvdlTableDB", "MyAppBillBalanceForIndvdlTable", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02997RC.DLL", "Broadleaf.Application.Remoting.ToyotaChangeDB", "MyAppToyotaChange", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU09994RC.DLL", "Broadleaf.Application.Remoting.ToyotaChangeMastDB", "MyAppToyotaChangeMast", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/09/26 ----------<<<<<

            // --- ADD s.kanazawa K2013/09/30 ---------->>>>>
            # region [エスビー商会]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01016RC.DLL", "Broadleaf.Application.Remoting.ESuBiSalesHistoryDB", "MyAppESuBiSalesHistory", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01026RC.DLL", "Broadleaf.Application.Remoting.ESuBiSupplierTextExpDB", "MyAppESuBiSupplierTextExp", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01036RC.DLL", "Broadleaf.Application.Remoting.ESuBiDepsitTextExpDB", "MyAppESuBiDepsitTextExp", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09006RC.DLL", "Broadleaf.Application.Remoting.ESuBiCustomerTextExpDB", "MyAppESuBiCustomerTextExp", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09016RC.DLL", "Broadleaf.Application.Remoting.ESuBiStockTextExpDB", "MyAppESuBiStockTextExp", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/09/30 ----------<<<<<

            // --- ADD s.kanazawa K2013/10/08 ---------->>>>>
            # region [フタバ]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01704RC.DLL", "Broadleaf.Application.Remoting.FuTaBaStockMoveJoinDB", "MyAppFuTaBaStockMoveJoin", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01714RC.DLL", "Broadleaf.Application.Remoting.FuTaBaSalesHistoryJoinDB", "MyAppFuTaBaSalesHistoryJoin", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02605RC.DLL", "Broadleaf.Application.Remoting.FutabaGoodsPrintDB", "MyAppFutabaGoodsPrint", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09114RC.DLL", "Broadleaf.Application.Remoting.FuTaBaInventoryDataJoinDB", "MyAppFuTaBaInventoryDataJoin", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09124RC.DLL", "Broadleaf.Application.Remoting.RateTextExpDB", "MyAppRateTextExp", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09134RC.DLL", "Broadleaf.Application.Remoting.StockTextExpDB", "MyAppStockTextExp", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09144RC.DLL", "Broadleaf.Application.Remoting.CustomerTextExpDB", "MyAppCustomerTextExp", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09154RC.DLL", "Broadleaf.Application.Remoting.GoodsTextImpDB", "MyAppGoodsTextImp", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09174RC.DLL", "Broadleaf.Application.Remoting.RateTextImpDB", "MyAppRateTextImp", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09194RC.DLL", "Broadleaf.Application.Remoting.GoodsTextExpDB", "MyAppGoodsTextExp", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMUOE01704RC.DLL", "Broadleaf.Application.Remoting.FuTaBaOrderDB", "MyAppFuTaBaOrder", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMUOE01758RC.DLL", "Broadleaf.Application.Remoting.EmcStockTorikDB", "MyAppEmcStockTorik", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMUOE04505RC.DLL", "Broadleaf.Application.Remoting.UOEOrderLogDB", "MyAppUOEOrderLog", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMUOE09105RC.DLL", "Broadleaf.Application.Remoting.UOEAutoOrderStDB", "MyAppUOEAutoOrderSt", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2013/11/27 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMUOE01809RC.DLL", "Broadleaf.Application.Remoting.SpkStockTorikDB", "MyAppSpkStockTorik", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2013/11/27 ----------<<<<<
            # endregion
            // --- ADD s.kanazawa K2013/10/08 ----------<<<<<

            // --- ADD y.Sugawara K2013/10/29 ---------->>>>>
            # region [横浜商工]
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02207RC.DLL", "Broadleaf.Application.Remoting.YokoHamaCollectPlanDB", "MyAppYokoHamaCollectPlan", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02506RC.DLL", "Broadleaf.Application.Remoting.YoKoHaMaSalesHistoryDB", "MyAppYoKoHaMaSalesHistory", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02106RC.DLL", "Broadleaf.Application.Remoting.FrePSalesSlipRePntCDB", "MyAppFrePSalesSlipRePntC", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD y.Sugawara K2013/10/29 ----------<<<<<

            // --- ADD y.Sugawara K2013/11/18 ---------->>>>>
            # region [カネマス]
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02117RC.DLL", "Broadleaf.Application.Remoting.DepsitDataDB", "MyAppDepsitData", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD y.Sugawara K2013/11/18 ----------<<<<<

            // --- ADD s.kanazawa K2013/11/22 ---------->>>>>
            # region [宮田自動車商会]
            retList.Add(new RemoteAssemblyInfo("", "PMKAK01009RC.DLL", "Broadleaf.Application.Remoting.McMiyataAccPaymentWorkDB", "MyAppMcMiyataAccPaymentWork", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK09804RC.DLL", "Broadleaf.Application.Remoting.McMiyataPaymentConditionsDB", "MyAppMcMiyataPaymentConditions", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAK09814RC.DLL", "Broadleaf.Application.Remoting.McMiyataOffsetAccountPriceBulkInputDB", "MyAppMcMiyataOffsetAccountPriceBulkInput", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01808RC.DLL", "Broadleaf.Application.Remoting.McMiyataPaymentDataDB", "MyAppMcMiyataPaymentData", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01925RC.DLL", "Broadleaf.Application.Remoting.McMiyataSalesHistoryDB", "MyAppMcMiyataSalesHistory", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01935RC.DLL", "Broadleaf.Application.Remoting.McMiyataNoRecBalanceDB", "MyAppMcMiyataNoRecBalance", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01945RC.DLL", "Broadleaf.Application.Remoting.McMiyataSumSetDB", "MyAppMcMiyataSumSet", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN01978RC.DLL", "Broadleaf.Application.Remoting.McMiyataDepositDataTorikDB", "MyAppMcMiyataDepositDataTorik", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/11/22 ----------<<<<<

            // --- ADD s.kanazawa K2013/11/26 ---------->>>>>
            # region [大黒商会]
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02997RC.DLL", "Broadleaf.Application.Remoting.SalesDayMonthReportHakoResultDB", "MyAppSalesDayMonthReportHakoResult", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02917RC.DLL", "Broadleaf.Application.Remoting.CustDmd2DB", "MyAppCustDmd2", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02927RC.DLL", "Broadleaf.Application.Remoting.CustAccRecDB", "MyAppCustAccRec", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02977RC.DLL", "Broadleaf.Application.Remoting.CollectResultProgramDB", "MyAppCollectResultProgram", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTOK02927RC.DLL", "Broadleaf.Application.Remoting.CustCampaignDB", "MyAppCustCampaign", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.kanazawa K2013/11/26 ----------<<<<<

            // --- ADD s.kanazawa K2013/11/26 ---------->>>>>
            # region [エムエムトーカイ]
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02927RC.DLL", "Broadleaf.Application.Remoting.GoodsSalesMonthReportDB", "MyAppGoodsSalesMonthReport", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02947RC.DLL", "Broadleaf.Application.Remoting.SalesMngListDB", "MyAppSalesMngList", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02957RC.DLL", "Broadleaf.Application.Remoting.SalesMonthYearReportResult2DB", "MyAppSalesMonthYearReportResult2", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02967RC.DLL", "Broadleaf.Application.Remoting.SalesDayMonthReport2ResultDB", "MyAppSalesDayMonthReport2Result", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02977RC.DLL", "Broadleaf.Application.Remoting.EchGoodsTtlListWorkDB", "MyAppEchGoodsTtlListWork", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02987RC.DLL", "Broadleaf.Application.Remoting.GoodsCustSaleOrderListWorkDB", "MyAppGoodsCustSaleOrderListWork", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02937RC.DLL", "Broadleaf.Application.Remoting.SectionEchDpDtlListDB", "MyAppSectionEchDpDtlList", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02947RC.DLL", "Broadleaf.Application.Remoting.EachCustomerBillTableDB", "MyAppEachCustomerBillTable", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU02957RC.DLL", "Broadleaf.Application.Remoting.CustAccRecBlnceDB", "MyAppCustAccRecBlnce", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02906RC.DLL", "Broadleaf.Application.Remoting.MsMiddleGenreResultDB", "MyAppMsMiddleGenreResult", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02917RC.DLL", "Broadleaf.Application.Remoting.MsCampaignRsltListResultDB", "MyAppMsCampaignRsltListResult", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09904RC.DLL", "Broadleaf.Application.Remoting.MstkMsLargeGenreDB", "MyAppMstkMsLargeGenre", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09914RC.DLL", "Broadleaf.Application.Remoting.MstkMsMiddleGenreDB", "MyAppMstkMsMiddleGenre", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09924RC.DLL", "Broadleaf.Application.Remoting.MstkMsSmallGenreDB", "MyAppMstkMsSmallGenre", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09976RC.DLL", "Broadleaf.Application.Remoting.MstkMsMdlGenreTargetDB", "MyAppMstkMsMdlGenreTarget", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTOK02917RC.DLL", "Broadleaf.Application.Remoting.MstkMsMiddleGenreSupplyListDB", "MyAppMstkMsMiddleGenreSupplyList", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTOK02937RC.DLL", "Broadleaf.Application.Remoting.MsMiddleGenrePrevYearComparisonDB", "MyAppMsMiddleGenrePrevYearComparison", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTOK02947RC.DLL", "Broadleaf.Application.Remoting.EmsPrevYearComparison2DB", "MyAppEmsPrevYearComparison2", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTOK09807RC.DLL", "Broadleaf.Application.Remoting.MsLargeRsltListResultDB", "MyAppMsLargeRsltListResult", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTOK09817RC.DLL", "Broadleaf.Application.Remoting.MsGenreRstComparisonAcsDB", "MyAppMsGenreRstComparisonAcs", WellKnownObjectMode.Singleton));
            # endregion

            // --- ADD s.kanazawa K2013/11/26 ----------<<<<<

            // --- ADD M.KISHI 2019/09/06 ---------->>>>>
            #region [テキスト出力ログ対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02322R.DLL", "Broadleaf.Application.Remoting.TextOutPutOprtnHisLogDB", "MyAppTextOutPutOprtnHisLog", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD M.KISHI 2019/09/06 ----------<<<<<

            // --- ADD M.KISHI 2019/11/20 ---------->>>>>
            #region [ハンディ6次対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKOU02356R.DLL", "Broadleaf.Application.Remoting.ArrGoodsDiffResultDB", "MyAppArrGoodsDiffResult", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD M.KISHI 2019/11/20 ----------<<<<<

            // --- ADD 2019/12/04 ---------->>>>>
            #region [売上データ連携]
            retList.Add(new RemoteAssemblyInfo("", "PMSDC02018R.DLL", "Broadleaf.Application.Remoting.SalesCprtDB", "MyAppISalesCprt", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMSDC09014R.DLL", "Broadleaf.Application.Remoting.SalCprtConnectInfoPrcPrStDB", "MyAppSalCprtConnectInfoPrcPrSt", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMSDC04005R.DLL", "Broadleaf.Application.Remoting.SalCprtSndLogDB", "MyAppSalCprtSndLog", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD 2019/12/04 ----------<<<<<
            // --- ADD 2020/04/06 ---------->>>>>
            #region [ハンディ仕入れ時在庫登録対応]
            retList.Add(new RemoteAssemblyInfo("", "PMHND01235R.DLL", "Broadleaf.Application.Remoting.HandyMakerGoodsPtrnDB", "MyAppHandyMakerGoodsPtrn", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD 2020/04/06 ----------<<<<<

            // --- ADD 2020/06/15 ---------->>>>>
            #region [ＥＢＥ対策]
            retList.Add(new RemoteAssemblyInfo("", "PMCMN00153R.DLL", "Broadleaf.Application.Remoting.EnvSurvObjDB", "MyAppEnvSurvObj", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMCMN00134R.DLL", "Broadleaf.Application.Remoting.ConvObjVerMngDB", "MyAppConvObjVerMng", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMCMN00143R.DLL", "Broadleaf.Application.Remoting.ConvObjDB", "MyAppConvObj", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMCMN00163R.DLL", "Broadleaf.Application.Remoting.ConvObjSingleBkDB", "MyAppConvObjSingleBk", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD 2020/06/15 ----------<<<<<

            // --- ADD 2020/12/01 ---------->>>>>
            #region [TSPインライン対応]
            retList.Add(new RemoteAssemblyInfo("", "PMTSP01204R.DLL", "Broadleaf.Application.Remoting.TspSdRvDataDB", "MyAppTspSdRvDataDB", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMTSP09004R.DLL", "Broadleaf.Application.Remoting.TspCprtStDB", "MyAppTspCprtStDB", WellKnownObjectMode.Singleton));            
            #endregion
            // --- ADD 2020/12/01 ----------<<<<<

            #endregion

            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ---------->>>>>
            //// --- ADD m.kawarabayashi K2013/12/05 ---------->>>>>
            //# region [富士制動機製作所]
            //retList.Add(new RemoteAssemblyInfo("", "PMKAU02507RC.DLL", "Broadleaf.Application.Remoting.FujiSalesRsltListResultDB", "MyAppFujiSalesRsltListResult", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKAU02517RC.DLL", "Broadleaf.Application.Remoting.FuJiCollectPlanDB", "MyAppFuJiCollectPlan", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02528RC.DLL", "Broadleaf.Application.Remoting.FujiSlipDataCastDB", "MyAppFujiSlipDataCast", WellKnownObjectMode.Singleton));
            //# endregion
            //// --- ADD m.kawarabayashi K2013/12/05 ----------<<<<<

            //// --- ADD s.kanazawa K2013/12/17 ---------->>>>>
            //# region [ムツミ商事]
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB02206RC.DLL", "Broadleaf.Application.Remoting.SearchSalesSlipMuCumiDB", "MyAppSearchSalesSlipMuCumi", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB02607RC.DLL", "Broadleaf.Application.Remoting.SumSecSalesTaxDB", "MyAppSumSecSalesTax", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB02617RC.DLL", "Broadleaf.Application.Remoting.PaymentIssueTableDB", "MyAppPaymentIssueTable", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02307RC.DLL", "Broadleaf.Application.Remoting.SectionDepositDB", "MyAppSectionDeposit", WellKnownObjectMode.Singleton));
            //# endregion
            //// --- ADD s.kanazawa K2013/12/17 ----------<<<<<
            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ----------<<<<<

            // --- ADD m.kawarabayashi K2013/12/17 ---------->>>>>
            # region [陸整自動車用品]
            retList.Add(new RemoteAssemblyInfo("", "PMKAK02117RC.DLL", "Broadleaf.Application.Remoting.RikuseiPaymentTableDB", "MyAppRikuseiPaymentTable", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02207RC.DLL", "Broadleaf.Application.Remoting.SupplierSumGroupPrintResultDB", "MyAppSupplierSumGroupPrintResult", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN02214RC.DLL", "Broadleaf.Application.Remoting.SupplierSumGroupDB", "MyAppSupplierSumGroup", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKOU02107RC.DLL", "Broadleaf.Application.Remoting.StockSlipCheckDB", "MyAppStockSlipCheck", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD m.kawarabayashi K2013/12/17 ----------<<<<<

            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ---------->>>>>
            //// --- ADD m.kawarabayashi K2013/12/18 ---------->>>>>
            //# region [小林商会]
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB02007RC.DLL", "Broadleaf.Application.Remoting.SalesHistDtlReportDB", "MyAppSalesHistDtlReport", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02007RC.DLL", "Broadleaf.Application.Remoting.DepsitListWorkLinDB", "MyAppDepsitListWorkLin", WellKnownObjectMode.Singleton));
            //# endregion
            //// --- ADD m.kawarabayashi K2013/12/18 ----------<<<<<

            //// --- ADD s.sannohe K2014/01/06 ---------->>>>>
            //# region [竹川商店]
            //retList.Add(new RemoteAssemblyInfo("", "PMMIT02007RC.DLL", "Broadleaf.Application.Remoting.TakekawaQuotaInventWorkDB", "MyAppTakekawaQuotaInventWork", WellKnownObjectMode.Singleton));
            //# endregion
            //// --- ADD s.sannohe K2014/01/06 ----------<<<<<

            //// --- ADD m.kawarabayashi K2014/1/20 ---------->>>>>
            //# region [川原自動車部品商会]
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB02127RC.DLL", "Broadleaf.Application.Remoting.SalesHistAnalyzeMthYearReportRltWorkDB", "MyAppSalesHistAnalyzeMthYearReportRltWork", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB02137RC.DLL", "Broadleaf.Application.Remoting.SalesDayMonthReportKawaResultDB", "MyAppSalesDayMonthReportKawaResult", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02144RC.DLL", "Broadleaf.Application.Remoting.BLCodeTireDB", "MyAppBLCodeTire", WellKnownObjectMode.Singleton));
            //# endregion
            //// --- ADD m.kawarabayashi K2014/1/20 ----------<<<<<

            //// --- ADD s.sannohe K2014/01/31 ---------->>>>>
            //# region [京浜]
            //retList.Add(new RemoteAssemblyInfo("", "PMKAU02007RC.DLL", "Broadleaf.Application.Remoting.CustSlipByFullModelNumTableDB", "MyAppCustSlipByFullModelNumTable", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKAU02017RC.DLL", "Broadleaf.Application.Remoting.DmdPrcSanKyuDB", "MyAppDmdPrcSanKyu", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKAU02027RC.DLL", "Broadleaf.Application.Remoting.DtlDeliReportDB", "MyAppDtlDeliReport", WellKnownObjectMode.Singleton));
            //# endregion
            //// --- ADD s.sannohe K2014/01/31 ----------<<<<<

            //// --- ADD s.kanazawa K2014/01/31 ---------->>>>>
            //# region [登戸]
            //retList.Add(new RemoteAssemblyInfo("", "PMTEG02307RC.DLL", "Broadleaf.Application.Remoting.NobutoDraftDataPrintDB", "MyAppNobutoDraftDataPrint", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB01314RC.DLL", "Broadleaf.Application.Remoting.NobutoSalesHistoryDB", "MyAppNobutoSalesHistory", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB03087RC.DLL", "Broadleaf.Application.Remoting.NobutoSpecSalesResultDataWorkDB", "MyAppNobutoSpecSalesResultDataWork", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB03067RC.DLL", "Broadleaf.Application.Remoting.NobutoSpecialSalesOneWorkDB", "MyAppNobutoSpecialSalesOneWork", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB03007RC.DLL", "Broadleaf.Application.Remoting.NobutoAreaCusWorkDB", "MyAppNobutoAreaCusWork", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB03027RC.DLL", "Broadleaf.Application.Remoting.NobutoAreaMonthlySalesReportDB", "MyAppNobutoAreaMonthlySalesReport", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB03047RC.DLL", "Broadleaf.Application.Remoting.NobutoAreaDailySalesReportDB", "MyAppNobutoAreaDailySalesReport", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMHNB09305RC.DLL", "Broadleaf.Application.Remoting.NobutoSpecSalesDB", "MyAppNoBuToSpecSales", WellKnownObjectMode.Singleton));
            //// ---- ADD m.shimizu K2014/11/6  -------->>>>>>>>
            //retList.Add(new RemoteAssemblyInfo("", "PMKAU03107RC.DLL", "Broadleaf.Application.Remoting.NobutoCollectProgramDB", "MyAppNobutoCollectProgram", WellKnownObjectMode.Singleton));
            //// ---- ADD m.shimizu K2014/11/6  --------<<<<<<<<
            //# endregion
            //// --- ADD s.kanazawa K2014/01/31 ----------<<<<<
            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ----------<<<<<

            // --- ADD s.kanazawa K2014/02/05 ---------->>>>>
            # region [フタバ]
            retList.Add(new RemoteAssemblyInfo("", "PMZAI01105RC.DLL", "Broadleaf.Application.Remoting.FuTaBaSecOrderDB", "MyAppFuTaBaSecOrder", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMZAI02207RC.DLL", "Broadleaf.Application.Remoting.FutabaSecOrderDtDB", "MyAppFutabaSecOrderDt", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMZAI02217RC.DLL", "Broadleaf.Application.Remoting.FutabaWarehouseOutputListResultDB", "MyAppFutabaWarehouseOutputListResult", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMZAI09004RC.DLL", "Broadleaf.Application.Remoting.FutabaSecOrderStDB", "MyAppFutabaSecOrderSt", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2014/06/27 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMUOE01824RC.DLL", "Broadleaf.Application.Remoting.FuTaBaOrderEdDB", "MyAppFuTaBaOrderEd", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMUOE09114RC.DLL", "Broadleaf.Application.Remoting.FutabaOrderMonitorSetDB", "MyAppFutabaOrderMonitorSet", WellKnownObjectMode.Singleton));
            // --- ADD s.kanazawa K2014/06/27 ----------<<<<<
            # endregion
            // --- ADD s.kanazawa K2014/02/05 ----------<<<<<

            // --- ADD m.kawarabayashi K2014/03/13 ---------->>>>>
            # region [福田部品]
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02317RC.DLL", "Broadleaf.Application.Remoting.FukudaSalesTransListResultDB", "MyAppFukudaSalesTransListResult", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMHNB02328RC.DLL", "Broadleaf.Application.Remoting.FukudaPrevYearComparisonDB", "MyAppFukudaPrevYearComparison", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD m.kawarabayashi K2014/03/13 ----------<<<<<

            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ---------->>>>>
            //// --- ADD kaniwa K2014/03/20 ---------->>>>>
            //# region [コンマン部品]
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02027RC.DLL", "Broadleaf.Application.Remoting.GoodsUaPrintTableDB", "MyAppGoodsUaPrintTable", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02054RC.DLL", "Broadleaf.Application.Remoting.KonManApolloSalesHistoryDB", "MyAppKonManApolloSalesHistory", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02064RC.DLL", "Broadleaf.Application.Remoting.AplAgencyDB", "MyAppAplAgency", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02074RC.DLL", "Broadleaf.Application.Remoting.AplDealershipDB", "MyAppAplDealership", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02087RC.DLL", "Broadleaf.Application.Remoting.AplDealershipPrintTableDB", "MyAppAplDealershipPrintTable", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02094RC.DLL", "Broadleaf.Application.Remoting.CsmAgencyDB", "MyAppCsmAgency", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02104RC.DLL", "Broadleaf.Application.Remoting.CsmDealershipDB", "MyAppCsmDealership", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02117RC.DLL", "Broadleaf.Application.Remoting.CsmDealershipPrintTableDB", "MyAppCsmDealershipPrintTable", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02124RC.DLL", "Broadleaf.Application.Remoting.CsmSalesDataTextExtrDB", "MyAppCsmSalesDataTextExtr", WellKnownObjectMode.Singleton));
            //# endregion
            //// --- ADD kaniwa K2014/03/20 ----------<<<<<
            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ----------<<<<<

            // --- ADD m.kawarabayashi K2014/04/07 ---------->>>>>
            # region [神吉商会]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN03005RC.DLL", "Broadleaf.Application.Remoting.KamiyoshiSalesHistoryDB", "MyAppKamiyoshiSalesHistory", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD m.kawarabayashi K2014/04/07 ----------<<<<<

            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ---------->>>>>
            //// --- ADD m.kawarabayashi K2014/4/22 ---------->>>>>
            //#region [杉村部品]
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN03108RC.DLL", "Broadleaf.Application.Remoting.KiKouSalseSlipDataDB", "MyAppKiKouSalseSlipData", WellKnownObjectMode.Singleton));
            //#endregion
            //// --- ADD m.kawarabayashi K2014/4/22 ----------<<<<<

            //// --- ADD m.kawarabayashi K2014/05/09 ---------->>>>>
            //#region [共栄部品]
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02155RC.DLL", "Broadleaf.Application.Remoting.KyoueiTKCSystemTextDB", "MyAppKyoueiTKCSystemText", WellKnownObjectMode.Singleton));
            //#endregion
            //// --- ADD m.kawarabayashi K2014/05/09 ----------<<<<<
            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ----------<<<<<

            // --- ADD m.shimizu K2014/07/15 ---------->>>>>
            # region [山中商会]
            retList.Add(new RemoteAssemblyInfo("", "PMHNB03107RC.DLL", "Broadleaf.Application.Remoting.YamanakaPrevYearComparisonDB", "MyAppYamanakaPrevYearComparison", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD m.shimizu K2014/07/15 ----------<<<<<

            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ---------->>>>>
            //// --- ADD m.shimizu K2014/09/04 ---------->>>>>
            //# region [佐藤車輌部品]
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN02165RC.DLL", "Broadleaf.Application.Remoting.SaTouSalesHistoryDB", "MyAppSaTouSalesHistory", WellKnownObjectMode.Singleton));
            //# endregion
            //// --- ADD m.shimizu K2014/09/04 ----------<<<<<

            //// --- ADD m.kawarabayashi K2014/09/22 ---------->>>>>
            //# region [田宮パーツ]
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN03214RC.DLL", "Broadleaf.Application.Remoting.TamiyaSalesHistoryDB", "MyAppTamiyaSalesHistory", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "PMKHN03224RC.DLL", "Broadleaf.Application.Remoting.TamiyaDepsitTextExpRetDB", "MyAppTamiyaDepsitTextExpRet", WellKnownObjectMode.Singleton));
            //# endregion
            //// --- ADD m.kawarabayashi K2014/09/22 ----------<<<<<
            // --- DEL m.kawarabayashi K2015/02/06 個別配信改良 ----------<<<<<

            // --- ADD m.hashimoto 2019/09/20 ---------->>>>>
            // 従業員別販売区分別売上目標設定マスタ
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09194R.DLL", "Broadleaf.Application.Remoting.EmpScSalesTargetDB", "MyAppEmpScSalesTarget", WellKnownObjectMode.Singleton));
            // --- ADD m.hashimot 2019/09/20 ----------<<<<<

            // --- ADD 2021/10/26 ---------->>>>>
            #region [一括コード変換対応]
            retList.Add(new RemoteAssemblyInfo("", "PMKHN05105R.dll", "Broadleaf.Application.Remoting.WarehouseConvertDB", "MyAppWarehouseConvert", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN05115R.dll", "Broadleaf.Application.Remoting.EmployeeConvertDB", "MyAppEmployeeConvert", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN05125R.dll", "Broadleaf.Application.Remoting.CustomerConvertDB", "MyAppCustomerConvert", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN05135R.dll", "Broadleaf.Application.Remoting.SectionConvertDB", "MyAppSectionConvert", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD 2021/10/26 ----------<<<<<
 
            // --- ADD 2022/03/18 ---------->>>>>
            #region [電子帳簿対応]
            retList.Add(new RemoteAssemblyInfo("", "MAKAU03010R.DLL", "Broadleaf.Application.Remoting.EBooksBillTableDB", "MyAppEBooksBillTable", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKAU01004R.DLL", "Broadleaf.Application.Remoting.EBooksFrePBillDB", "MyAppEBooksFrePBill", WellKnownObjectMode.Singleton));
            #endregion
            // --- ADD 2022/03/18 ----------<<<<<


            retList.AddRange(CustomServerServiceResource.GetRemoteResource()); // ADD chenyk 2014/12/12 FOR Redmine#30682

            return retList;
        }
    }
}
