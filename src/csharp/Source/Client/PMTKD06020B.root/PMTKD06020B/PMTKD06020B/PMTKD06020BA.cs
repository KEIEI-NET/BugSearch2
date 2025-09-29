//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品検索コントローラー
// プログラム概要   : 部品情報の検索/取得を行うコントローラー
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 :              作成担当 : 30290
// 作 成 日 : 2008/05/15   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11470007-00  作成担当 : 30757 佐々木　貴英
// 作 成 日 : 2018/04/05   修正内容 : NS3Ai対応（BL統一部品コード対応）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Runtime.Remoting;
using System.Threading;
using System.Reflection;
using System.IO;  // ADD 2010/07/07
using WinForms = System.Windows.Forms; // ADD 2010/07/07

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources; // 2010/03/29
// --- ADD m.suzuki 2010/04/28 ---------->>>>>
using Broadleaf.Library.Globarization; // SFCMN00002C TDateTimeを使用。
// --- ADD m.suzuki 2010/04/28 ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 部品検索コントローラー
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品検索コントローラーです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br> ############################## 注意 ############################## </br>
    /// <br>１．コンパイルシンボルPrimeSetを外すと優良設定処理が無効になります。</br>
    /// <br> ################################################################### </br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note: 車台番号⇒車台番号、車台番号（検索用）に修正</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.01.28</br>    
    /// <br></br>
    /// <br>Update Note: 優良設定のパラメータ変更対応</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.02.12</br>    
    /// <br></br>
    /// <br>Update Note: 優良設定の絞り込みを修正</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.02.17</br>    
    /// <br></br>
    /// <br>Update Note: 結合、セットが提供とユーザーで重複する場合にユーザー</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2009.02.19</br>    
    /// <br></br>
    /// <br>Update Note: 離島価格反映処理追加</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2009.02.24</br>    
    /// <br></br>
    /// <br>Update Note: 離島価格反映処理修正(代替された場合も適用)</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2009.03.04</br>    
    /// <br></br>
    /// <br>Update Note: ①優良部品の層別をセットするよう修正(処理が漏れていた)</br>
    /// <br>             ②優良部品でセレクトコード別がある場合の価格取得を修正</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2009.03.18</br>    
    /// <br></br>
    /// <br>Update Note: ①商品一括登録検索が優良部品検索に未対応だったので修正</br>
    /// <br>           : ②優良設定リストがnullの場合の処理を修正</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2009.04.01</br>    
    /// <br></br>
    /// <br>Update Note: 価格情報取得メソッド追加</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2009.04.14</br>    
    /// <br></br>
    /// <br>Update Note: ①ユーザーDBと提供DBの価格情報が検索時にマージされてしまうので、</br>
    /// <br>           : 　ユーザーDBに価格情報があれば提供DBの価格情報をヒットさせないよう修正。(Mantis ID=13491)</br>
    /// <br>           : ②InitializeSearchスレッドでの初期化が完了する前に、検索処理が呼ばれると</br>
    /// <br>           :   オブジェクト参照エラーが発生するので修正。(Mantis ID=13491 (4.))</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2009.06.16</br>    
    /// <br></br>
    /// <br>Update Note: 部品選択のソート順を変更する為、項目を追加。</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2009.07.23</br>
    /// <br></br>
    /// <br>Update Note: MANTIS[0012224] 検索時、論理削除分も検索対象とする。</br>
    /// <br>             MANTIS[0014250] TBO検索時に検索条件をパラメータとしてセットする(検索見積でTBO検索するとエラーとなる対応)</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2009/09/07</br>
    /// <br></br>
    /// <br>Update Note: MANTIS[0014373] ユーザー登録分の結合のBLコード等が取得できない不具合の対応</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/10/06</br>
    /// <br></br>
    /// <br>Update Note: 優良検索対応</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/10/19</br>
    /// <br></br>
    /// <br>Update Note: 品名表示対応</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/10/27</br>
    /// <br></br>
    /// <br>Update Note: 表示区分対応：結合元検索時、提供価格を取得するメソッド追加</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2009/11/04</br>
    /// <br></br>
    /// <br>Update Note: MANTIS[0014574] 純正代替品の価格改正情報が取得できていない不具合の修正</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/11/09</br>
    /// <br></br>
    /// <br>Update Note: 優良セット部品に関して、優良部品のBLコードが検索結果となるように修正(MANTIS[0013603])</br>
    /// <br>             純正部品検索結果で、検索品名取得メーカーコードをセットするように修正(MANTIS[0014671])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/11/24</br>
    /// <br></br>
    /// <br>Update Note: 提供純正部品について、日付に従って層別、BLコード、品名を取得するように修正(MANTIS[0014767])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/12/09</br>
    /// <br></br>
    /// <br>Update Note: エントリ等での検索時、ユーザー商品で論理削除の情報を検索しないように修正(MANTIS[0014767])</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2009/12/17</br>
    /// <br></br>
    /// <br>Update Note: ＳＣＭ分の組込み</br>
    /// <br>             ①BLコード枝番号対応</br>
    /// <br>             ②提供区分のセット方法修正(何故修正したかは不明)</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/02/25</br>    
    /// <br></br>
    /// <br>Update Note: 大型検索のオプションフラグが設定されていない場合、大型車輌に該当する検索は該当データ無しとする(MANTIS[0015168])</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2010/03/29</br>
    /// <br></br>
    /// <br>Update Note: 品名取得メソッドを修正</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/04/06</br>
    /// <br></br>
    /// <br>Update Note: LoadAsm削除(delphiフォームよりc#フォームを起動したときにretKeyControl,arrowKeyControlが有効にならない為)</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2010/04/24</br>
    /// <br></br>
    /// <br>Update Note: 自由検索オプション対応</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/04/28</br>
    /// <br></br>
    /// <br>Update Note: オフライン対応</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/05/25</br>
    /// <br></br>
    /// <br>Update Note: 成果物統合</br>
    /// <br>               自由検索 2010/04/28 組み込み</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/06/04</br>
    /// <br></br>
    /// <br>Update Note: 成果物統合</br>
    /// <br>               ２輪オプション対応</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/06/12</br>
    /// <br></br>
    /// <br>Update Note: 成果物統合</br>
    /// <br>               オフライン対応 2010/05/25 組み込み</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/06/16</br>
    /// <br></br>
    /// <br>Update Note: 成果物統合</br>
    /// <br>               売上伝票入力起動高速化対応 2010/04/24 組み込み</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/06/21</br>
    /// <br></br>
    /// <br>Update Note: MANTIS対応 15716</br>
    /// <br>           :   オフライン処理に関して、SCMを考慮した判定とするように修正</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2010/07/07</br>
    /// <br></br>
    /// <br>Update Note: 成果物統合２</br>
    /// <br>               セット子品番に対して提供データのセット品名を設定するよう修正</br>
    /// <br>               (※現時点ではＤＢ上は全角名しかないので、ＰＧにより半角変換してセットする)</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/07/14</br>
    /// <br></br>
    /// <br>Update Note: SCM改良</br>
    /// <br>               BLコード枝番対応（枝番による絞り込みと枝番名称の適用(…右,…左など)）</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/24  連番980 梁森東</br>
    /// <br>            : REDMINE#23417の対応</br>
    /// <br>Update Note: 2011/08/31  連番980 梁森東</br>
    /// <br>            : REDMINE#23417の対応</br>
    /// <br>Update Note: SCM改良</br>
    /// <br>             自動見積部品コード取得処理の追加</br>
    /// <br>Programmer : 20073 西 毅</br>
    /// <br>Date       : 2012/05/30</br>
    /// <br>Update Note: 障害№1004</br>
    /// <br>             品番大文字小文字変換処理の追加</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2012/06/18</br>
    /// <br>Update Note: SPK外車TBO検索対応</br>
    /// <br>             TBO検索後、該当がなかった場合は、通常の純正BLコード検索を処理するように修正</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2012/11/15</br>
    /// <br>Update Note: BLコード検索対応</br>
    /// <br>             提供データで登録されている結合部品に対して、ユーザー登録したセット商品が紐付くように修正</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2012/12/10</br>
    /// <br>Update Note: BLコード検索対応</br>
    /// <br>             提供データで登録されている結合部品に対して、ユーザー登録したセット商品が紐付くように修正</br>
    /// <br>             （品番検索対応漏れ）</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2012/12/20</br>
    /// <br>Update Note: SCM障害№169対応</br>
    /// <br>             2013/03/06配信 提供 特記事項 追加。それに伴う処理追加</br>
    /// <br>Programmer : 30745 吉岡孝憲</br>
    /// <br>Date       : 2013/02/12</br>
    /// <br>Update Note: BLコード検索対応</br>
    /// <br>             年式・車台番号入力時に絞込みの検索条件に追加する修正</br>
    /// <br>             SCM障害№10354対応 2013/03/06配信</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2013/02/14</br>
    /// <br>Update Note: 2013/03/13配信システムテスト障害№121対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2013/02/22</br>
    /// <br>Update Note: ダミー品番対応</br>
    /// <br>             SCM障害№10355対応 2013/04/10配信</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2013/02/17</br>
    /// <br></br>
    /// <br>UpdateNote : 2013/03/15　dpp</br>
    /// <br>          　 10901273-00 5月15日配信分（障害以外） Redmine#34377 品番検索結果不具合の修正</br>
    /// <br></br>
    /// <br>Update Note: 10900269-00 SPK車台番号文字列対応</br>
    /// <br>Programmer : FSI斎藤 和宏</br>
    /// <br>Date       : 2013/03/27</br>
    /// <br></br>
    /// <br>Update Note: SCM仕掛一覧№10632対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/02/06</br>
    /// <br></br>
    /// <br>Update Note: SCM自動回答速度改善 ｼｽﾃﾑﾃｽﾄ障害№77対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/04/17</br>
    /// <br></br>
    /// <br>Update Note: 速度改善フェーズ２№11,№12 絞込タイミング変更</br>
    /// <br>Programmer : 30745 吉岡</br>
    /// <br>Date       : 2014/05/09</br>
    /// <br></br>
    /// <br>Update Note: 管理番号  11070076-00  PM-SCM速度改良 フェーズ２対応</br>
    /// <br>                                    13.フル型式固定番号からのＢＬコード検索回数改良対応</br>
    /// <br>                                    14.明細取込区分の更新方法を改良対応</br>
    /// <br>                                    15.SCM受発注データ（車両情報）取得方法改良対応</br>
    /// <br>                                    16.純正品検索改良対応</br>
    /// <br>                                    17.優良品検索改良対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/05/13</br>
    /// <br></br>
    /// <br>Update Note: 管理番号  11070076-00  PM-SCM速度改良 フェーズ２対応</br>
    /// <br>                                    障害対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/06/12</br>
    /// <br></br>
    /// <br>Update Note: SCM仕掛一覧№10659対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/06/04</br>
    /// <br>Update Note: 11070147-00 システムテスト障害№5対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/08/13</br>
    /// <br>Update Note: 11070147-00 システムテスト障害№20対応</br>
    /// <br>Programmer : 30744 湯上 千加子</br>
    /// <br>Date       : 2014/08/13</br>    
    /// <br></br>
    /// <br>Update Note: 管理番号  11070076-00  PM-SCM速度改良 フェーズ２対応</br>
    /// <br>             優良部品情報取得リモートの変更(パブリック変数→プライベート変数)に伴う修正</br>
    /// <br>Programmer : 宮本 利明</br>
    /// <br>Date       : 2014/08/14</br>
    /// <br>Update Note: №10679 №10681</br>
    /// <br>Programmer : 30745 吉岡</br>
    /// <br>Date       : 2014/09/09</br>
    /// <br>Update Note: SCM社内障害一覧№53対応</br>
    /// <br>           : PM-SCM速度改良 フェーズ２ ｼｽﾃﾑﾃｽﾄ障害対応</br>
    /// <br>           : 自動回答の問合せで優良品も回答されるBLコードで問合せすると純正品しか回答されない障害対応</br>
    /// <br>Programmer : 30744 湯上</br>
    /// <br>Date       : 2014/10/16</br>
    /// <br></br>
    /// <br>Update Note: SCM高速化 C向け種別対応</br>
    /// <br>Programmer : 31065 豊沢</br>
    /// <br>Date       : 2015/02/20</br>
    /// <br></br>
    /// <br>Update Note: SCM高速化Redmine#317対応</br>
    /// <br>Programmer : 30744 湯上</br>
    /// <br>Date       : 2015/03/04</br>
    /// <br></br>
    /// <br>Update Note: SCM仕掛一覧№10715対応</br>
    /// <br>           : 問合せ(BL検索)の回答時に異なるBLコード枝番の部品が新品番に設定されている場合にエラーになる障害の対応</br>
    /// <br>Programmer : 宮本 利明</br>
    /// <br>Date       : 2015/04/03</br>
    /// <br></br>
    /// <br>Update Note: SCM仕掛一覧№10716対応</br>
    /// <br>Programmer : 30744 湯上</br>
    /// <br>Date       : 2015/04/03</br>
    /// <br></br>
    /// <br>Update Note: SCM高速化メーカー希望小売価格対応</br>
    /// <br>Programmer : 30744 湯上</br>
    /// <br>Date       : 2015/03/18</br>
    /// <br></br>
    /// <br>Update Note: 全体配信システムテスト障害№60対応</br>
    /// <br>Programmer : 30744 湯上</br>
    /// <br>Date       : 2015/03/30</br>
    /// <br></br>
    /// <br>Update Note: ソースチェック指摘対応</br>
    /// <br>           : ①自由検索部品で提供優良情報取得時の価格情報追加処理対応</br>
    /// <br>           : ②提供価格情報初期化不要のため修正</br>
    /// <br>Programmer : 30744 湯上</br>
    /// <br>Date       : 2015/03/31</br>
    /// <br></br>
    /// <br>Update Note: NS3Ai対応（BL統一部品コード対応）</br>
    /// <br>           : 検索条件へのBL統一部品コードの追加</br>
    /// <br>Programmer : 30757 佐々木　貴英</br>
    /// <br>Date       : 2018/04/05</br>
    /// <br>管理番号   : 11470007-00</br>
    /// <br></br>
    /// </remarks>
    public class PartsSearchController
    {
        # region Private Members
        /// <summary>トヨタメーカーコード</summary>
        private const int ct_ToyotaCd = 1;
        /// <summary>タクティーメーカーコード</summary>
        private const int ct_TactiCd = 1396;
        /// <summary>部品メーカーリスト</summary>
        private Dictionary<int, MakerUMnt> _PartsMakerList;
        /// <summary>BLコードリスト</summary>
        private Dictionary<int, BLGoodsCdUMnt> blList;
        // 2010/02/25 Add >>>
        /// <summary>提供BLコードリスト</summary>
        private List<TbsPartsCodeWork> _ofrBLList;
        // 2010/02/25 Add <<<
        /// <summary>純正部品キーリスト</summary>
        private List<string> lstClgParts; // 優良部品検索時重複しないリスト作成のため、

        // 車両型式情報データセット
        private PMKEN01010E carInfoDataSet;
        private PMKEN01010E.CarModelInfoDataTable customerCarInfo;

        private BLInfoDataTable ofrBLInfo;
        private BLInfoDataTable bLInfo;

        /// <summary>優良設定情報格納バッファ(VALUE:優良設定情報オブジェクト)</summary>
        // 2009.02.12 >>>
        //private Dictionary<PrmSettingKey, PrmSettingUWork> _drPrmSettingWork;
        private List<PrmSettingUWork> _drPrmSettingWork;
        // 2009.02.12 <<<

        /// <summary>拠点コード</summary>
        private string _sectionCode;

        private SearchPrtCtlAcs searchPrtCtlAcs;

        /// <summary>2輪部品メーカーリスト（2輪契約による品番検索制御用）</summary>
        private List<int> bikePMakerList = new List<int>(new int[] { 21, 22, 23, 24 });

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>0:自由検索なし 1:自由検索あり</summary>
        private int _freeSearchDiv;

        /// <summary>通常のBLコード検索の処理結果STATUS（自由検索抽出結果と区別する）</summary>
        private int _normalSearchStatus;

        /// <summary>自由検索部品 抽出結果バッファ</summary>
        private Dictionary<string, List<FreeSearchPartsSRetWork>> _freeSearchPartsSRetDic;
        /// <summary>自由検索部品 抽出結果（先頭）</summary>
        private FreeSearchPartsSRetWork _freeSearchPartsSRetWork;

        /// <summary>自由検索 提供純正 抽出結果ディクショナリ</summary>
        private Dictionary<string, RetPartsInf> _retPartsInfDic;
        /// <summary>自由検索 提供優良 抽出結果ディクショナリ</summary>
        private Dictionary<string, OfferJoinPartsRetWork> _primPartsRetDic;
        /// <summary>自由検索 提供優良価格 抽出結果ディクショナリ</summary>
        private Dictionary<string, List<OfferJoinPriceRetWork>> _primPriceRetDic;
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        /// <summary>BLコードリスト</summary>
        public Dictionary<int, BLGoodsCdUMnt> BLGoodsCdUMntList
        {
            get { return blList; }
            set { blList = value; }
        }

        // 2010/02/25 Add >>>
        /// <summary>提供BLコードリスト</summary>
        public List<TbsPartsCodeWork> OfrBLList
        {
            get { return _ofrBLList; }
            set { _ofrBLList = value; }
        }
        // 2010/02/25 Add <<<

        /// <summary>部品メーカーリスト</summary>
        public Dictionary<int, MakerUMnt> PartsMakerList
        {
            get { return _PartsMakerList; }
            set { _PartsMakerList = value; }
        }

        /// <summary>
        /// 車両情報設定
        /// </summary>
        public PMKEN01010E CarInfo
        {
            set
            {
                carInfoDataSet = value;
                // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                //GetCarBlInf();
                GetCarBlInf( 0 );
                // --- UPD m.suzuki 2010/04/28 ----------<<<<<
            }
        }
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// 車輌情報設定処理（車輌ＢＬコード検索のＢＬコードを限定）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blCode"></param>
        public void SetCarInfo( PMKEN01010E value, int blCode )
        {
            carInfoDataSet = value;
            GetCarBlInf( blCode );
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 車輌情報設定処理（車輌ＢＬコード検索のＢＬコードを限定）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blCodeList"></param>
        public void SetCarInfo(PMKEN01010E value, List<int> blCodeList)
        {
            carInfoDataSet = value;
            GetCarBlInf(blCodeList);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> 自動回答品目設定リスト（自動回答専用） </summary>
        private List<AutoAnsItemSt> _foundAutoAnsItemStList = new List<AutoAnsItemSt>();
        /// <summary> 自動回答品目設定リスト（自動回答専用） </summary>
        public List<AutoAnsItemSt> FoundAutoAnsItemStList
        {
            get { return _foundAutoAnsItemStList; }
            set { _foundAutoAnsItemStList = value; }
        }

        /// <summary> 拠点コード（自動回答専用） </summary>
        private string _sectionCodeAutoAnswer = string.Empty;
        /// <summary> 拠点コード(自動回答専用) </summary>
        public string SectionCode
        {
            get { return _sectionCodeAutoAnswer; }
            set { _sectionCodeAutoAnswer = value; }
        }

        /// <summary> 得意先コード（自動回答専用） </summary>
        private int _customerCode = 0;
        /// <summary> 得意先コード（自動回答専用） </summary>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        // ADD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 車両BL情報取得
        /// </summary>
        public BLInfoDataTable BLInfo
        {
            get { return bLInfo; }
        }

        # region リモートコントローラー
        //private IPrimeSettingDB iPrimeSettingSearchDB;
        private static IPrimePartsInfo iPrimePartsInfoDB;
        private static ITBOSearchInfDB iTBOSearchInfDB;
        private static ITBOSearchUDB iTBOSearchUDB;
        private static IUsrJoinPartsSearchDB iUsrJoinPartsSearchDB;
        //private IClgPrmPartsInfoSearchDB iClgPrmPartsInfoSearchDB = null;
        private static IOfferPartsInfo iOfferPartsInfo;
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        private static IAutoEstmPtNoChgDB iAutoEstmPtNoChgDB;
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<

        /// <summary>優良ＢＬ検索情報取得リモート＜提供＞</summary>
        private static IOfferPrimeBlSearchDB iOfferPrimeBlSearchDB;

        private static ITbsPartsCodeDB iBlGoodsCdDB;

        ///// <summary>商品在庫検索DBリモート</summary>
        //private IGoodsStockSearchDB iGoodsStockSearchDB;
        # endregion

        //>>>2010/03/29
        // 大型検索オプション用大型メーカーリスト
        private List<int> bigMakerList = new List<int>(new int[] { 10, 12, 13, 16 });
        //<<<2010/03/29

        // --- ADD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------>>>>>
        private struct NewKey
        {
            private int MakerCd;
            private string PrtsNo;

            public NewKey(int CatalogPartsMakerCd, string NewPrtsNoWithHyphen)
            {
                MakerCd = CatalogPartsMakerCd;
                PrtsNo = NewPrtsNoWithHyphen;
            }
        }
        // --- ADD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------<<<<<
        # endregion

        #region [ Delegate ]
        // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 離島価格反映デリゲート
        /// </summary>
        /// <param name="taxationCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="offerKubun"></param>
        /// <param name="price"></param>
        public delegate void ReflectIsolIslandCallback(int taxationCode, int goodsMakerCd, int offerKubun, ref double price);
        // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #region [ Events ]
        // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 価格計算用イベント
        /// </summary>
        public ReflectIsolIslandCallback ReflectIsolIsland;
        // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        # region データテーブル
        private PartsInfoDataSet partsInfo;
        /// <summary> 全ての部品・商品情報テーブル[PartsInfoDataSetのUsrGoodsInfoDataTable] </summary>
        private PartsInfoDataSet.UsrGoodsInfoDataTable goodsTable;

        /// <summary> 全ての部品・商品の価格テーブル[PartsInfoDataSetのUsrGoodsPriceDataTable] </summary>
        private PartsInfoDataSet.UsrGoodsPriceDataTable priceTable;

        private PartsInfoDataSet.StockDataTable stockTable;

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        private Dictionary<int, PartsInfoDataSet> partsInfoDic;
        /// <summary> 全ての部品・商品情報テーブル[PartsInfoDataSetのUsrGoodsInfoDataTable] </summary>
        private Dictionary<int, PartsInfoDataSet.UsrGoodsInfoDataTable> goodsTableDic;

        /// <summary> 全ての部品・商品の価格テーブル[PartsInfoDataSetのUsrGoodsPriceDataTable] </summary>
        private Dictionary<int, PartsInfoDataSet.UsrGoodsPriceDataTable> priceTableDic;

        private Dictionary<int, PartsInfoDataSet.StockDataTable> stockTableDic;
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
        /// <summary> 全ての部品・商品の提供データ価格テーブル[PartsInfoDataSetのUsrGoodsPriceDataTable] </summary>
        private PartsInfoDataSet.UsrGoodsPriceDataTable ofrPriceTable;
        /// <summary> 全ての部品・商品の提供データ価格テーブル[PartsInfoDataSetのUsrGoodsPriceDataTable] </summary>
        private Dictionary<int, PartsInfoDataSet.UsrGoodsPriceDataTable> ofrPriceTableDic;
        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

        # endregion

        # region コンストラクター
        /// <summary>
        ///	部品検索コントローラー コンストラクター
        /// </summary>
        public PartsSearchController()
        {
            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 DEL
                ////RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
                //Thread threadInit = new Thread( InitializeSearch );
                //Thread threadLoad = new Thread( LoadAsm );
                //threadInit.Start();
                //threadLoad.Start();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 ADD InitializeSearchから一部移動

                //>>>2010/04/24
                //// アセンブリロードスレッド開始
                //Thread threadLoad = new Thread( LoadAsm );
                //threadLoad.Start();
                //<<<2010/04/24

                
                // 初期化
                iOfferPartsInfo = null;
                iPrimePartsInfoDB = null;
                iTBOSearchInfDB = null;
                iUsrJoinPartsSearchDB = null;
                iOfferPrimeBlSearchDB = null;
                iBlGoodsCdDB = null;

                _PartsMakerList = null;

                partsInfo = new PartsInfoDataSet();
                goodsTable = partsInfo.UsrGoodsInfo;
                priceTable = partsInfo.UsrGoodsPrice;
                stockTable = partsInfo.Stock;
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                // DEL 2015/03/31 SCM高速化 メーカー希望小売価格対応②提供価格情報初期化不要のため修正-------------->>>>>
                //ofrPriceTable = new PartsInfoDataSet.UsrGoodsPriceDataTable();
                // DEL 2015/03/31 SCM高速化 メーカー希望小売価格対応②提供価格情報初期化不要のため修正--------------<<<<<
                ofrPriceTable = partsInfo.OfrPriceDataTable;
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

                ofrBLInfo = new BLInfoDataTable();
                bLInfo = new BLInfoDataTable();

                searchPrtCtlAcs = new SearchPrtCtlAcs();


                // 2010/02/25 >>>
                // 初期検索スレッド開始
                //Thread threadInit = new Thread( InitializeSearch );
                //threadInit.Start();

                InitializeSearch();
                // 2010/02/25 <<<

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 ADD

                // --- ADD m.suzuki 2010/04/28 ---------->>>>>
                // 自由検索オプションチェック
                PurchaseStatus psFreeSearch = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch );
                if ( psFreeSearch == PurchaseStatus.Contract || psFreeSearch == PurchaseStatus.Trial_Contract )
                {
                    // 自由検索あり
                    _freeSearchDiv = 1;
                }
                else
                {
                    // 自由検索なし
                    _freeSearchDiv = 0;
                }
                // --- ADD m.suzuki 2010/04/28 ----------<<<<<

            }
            catch (Exception)
            {
                // オフライン時はnullをセット
            }
        }

        private void InitializeSearch()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 DEL 一部をコンストラクタへ移動
            ////リモート処理の設定
            //iOfferPartsInfo = null;
            //iPrimePartsInfoDB = null;
            //iTBOSearchInfDB = null;
            //iUsrJoinPartsSearchDB = null;
            //iOfferPrimeBlSearchDB = null;
            //iBlGoodsCdDB = null;

            //_PartsMakerList = null;

            //partsInfo = new PartsInfoDataSet();
            //goodsTable = partsInfo.UsrGoodsInfo;
            //priceTable = partsInfo.UsrGoodsPrice;
            //stockTable = partsInfo.Stock;

            //ofrBLInfo = new BLInfoDataTable();
            //bLInfo = new BLInfoDataTable();

            //ISearchPrtCtlDB iSearchPrtCtlDb = MediationSearchPrtCtlDB.GetSearchPrtCtlDB();
            //object lstClgParts;
            //int status = iSearchPrtCtlDb.Search( out lstClgParts, null );
            //ArrayList lst = lstClgParts as ArrayList;
            //searchPrtCtlAcs = new SearchPrtCtlAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 ADD
            ISearchPrtCtlDB iSearchPrtCtlDb = MediationSearchPrtCtlDB.GetSearchPrtCtlDB();
            object lstClgParts;
            int status = iSearchPrtCtlDb.Search( out lstClgParts, null );
            ArrayList lst = lstClgParts as ArrayList;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 ADD

            if (lst != null)
            {
                searchPrtCtlAcs.AddList(lst);
            }

            // 全BLコード取得
            GetOfrBlInf();
        }

        private void LoadAsm()
        {
            string path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            path = path.Remove(path.LastIndexOf('\\') + 1);
            Assembly asm1 = Assembly.LoadFile(path + "PMKEN01010E.dll");
            Assembly asm2 = Assembly.LoadFile(path + "PMKEN01020E.dll");
            Assembly asm3 = Assembly.LoadFile(path + "PMKEN08010U.dll");
            Assembly asm4 = Assembly.LoadFile(path + "PMKEN08020U.dll");
            Assembly asm5 = Assembly.LoadFile(path + "PMKEN08060U.dll");
            Assembly asm6 = Assembly.LoadFile(path + "PMKEN08070U.dll");
            Assembly asm7 = Assembly.LoadFile(path + "PMKEN08140U.dll");
            Assembly asm8 = Assembly.LoadFile(path + "PMKEN08080U.dll");
            Assembly asm9 = Assembly.LoadFile(path + "PMKEN08090U.dll");
            Assembly asm10 = Assembly.LoadFile(path + "PMKEN08100U.dll");
            try
            {
                object obj = asm5.CreateInstance("Broadleaf.Library.Windows.Forms.SelectionParts", false, BindingFlags.Default, null,
                    new object[0], null, null);
                obj = asm6.CreateInstance("Broadleaf.Library.Windows.Forms.SelectionSamePartsNoParts", false, BindingFlags.Default, null,
                    new object[0], null, null);
                obj = asm6.CreateInstance("Broadleaf.Library.Windows.Forms.SelectionSamePartsNoParts", false, BindingFlags.Default, null,
                    new object[0], null, null);
            }
            catch
            {
            }
        }
        # endregion

        /// <summary>
        /// 品名取得(全角)
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <returns></returns>
        public static int GetPartsName(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name, 0);
        }

        /// <summary>
        /// 品名取得(半角)
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <returns></returns>
        public static int GetPartsNameKana(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name , 1);
        }

        /// <summary>
        /// 品名取得
        /// </summary>
        /// <param name="makerCd">メーカコード</param>
        /// <param name="partsNo">ハイフン付品番</param>
        /// <param name="name">品名</param>
        /// <param name="mode">0:全角,1:半角</param>
        /// <returns></returns>
        private static int GetPartsNameProc(int makerCd, string partsNo, out string name, int mode)
        {
            int status = 0;
            string offerName = string.Empty;
            string userName = string.Empty;
            name = string.Empty;

            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<
            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
                if (mode == 0)
                {
                    //全角名称
                    status = iOfferPartsInfo.GetPartsName(makerCd, partsNo, out offerName);
                }
                else
                {
                    //半角名称
                    status = iOfferPartsInfo.GetPartsNameKana(makerCd, partsNo, out offerName);
                }

                if (status != 0)
                {
                    if (iPrimePartsInfoDB == null)
                        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
                    if (mode == 0)
                    {
                        //全角名称
                        status = iPrimePartsInfoDB.GetPartsName(makerCd, partsNo, out offerName);
                    }
                    else
                    {
                        //半角名称
                        status = iPrimePartsInfoDB.GetPartsNameKana(makerCd, partsNo, out offerName);
                    }
                }

                // -- DEL 2010/04/06 --------------------------->>>
                //if (iUsrJoinPartsSearchDB == null)
                //    iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                //if (mode == 0)
                //{
                //    //全角名称
                //    status = iUsrJoinPartsSearchDB.GetPartsName(makerCd, partsNo, out userName);
                //}
                //else
                //{
                //    //半角名称
                //    status = iUsrJoinPartsSearchDB.GetPartsNameKana(makerCd, partsNo, out userName);
                //}
                //if (userName != string.Empty)
                //{
                //    name = userName;
                //}
                //else
                //{
                //    if (offerName != string.Empty)
                //    {
                //        name = offerName;
                //        status = 0; // 提供のみデータがある場合ユーザーDB検索でstatusが0以外になるため、0に設定する。
                //    }
                //    else
                //    {
                //        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    }
                //}
                // -- DEL 2010/04/06 ---------------------------<<<
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        # region 検索メイン（ＢＬコード検索・品番検索・結合元検索）
        /// <summary>
        /// 検索メイン（ＢＬコード検索・品番検索）
        /// </summary>
        /// <param name="dsCarModelInfo">車両型式データセット（型式未定のときはnullを設定すること）</param>
        /// <param name="PartsSearchUIData">部品検索抽出条件</param>
        /// <param name="retPartsInfo">部品検索結果</param>
        /// <returns></returns>
        public int GetPartsInfoMain(PMKEN01010E dsCarModelInfo, PartsSearchUIData PartsSearchUIData, out PartsInfoDataSet retPartsInfo)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            partsInfo.Clear();
            partsInfo.SearchCondition = PartsSearchUIData;
            _sectionCode = PartsSearchUIData.SectionCode;
            _drPrmSettingWork = PartsSearchUIData.PrmSettingWork;

            if (dsCarModelInfo != null)
            {
                carInfoDataSet = dsCarModelInfo;
                customerCarInfo = dsCarModelInfo.CarModelInfoSummarized;

                // 車両BLコード取得
                //GetCarBlInf();
            }
            else
            {
                carInfoDataSet = null;
                customerCarInfo = null;
            }

            // --- ADD m.suzuki 2010/04/28 ---------->>>>>
            if ( _freeSearchDiv != 0 )
            {
                // 初期化
                _freeSearchPartsSRetDic = null;
                _freeSearchPartsSRetWork = null;
            }
            // --- ADD m.suzuki 2010/04/28 ----------<<<<<

            //ＢＬコード検索
            if (PartsSearchUIData.TbsPartsCode != 0)
            {
                partsInfo.SearchMethod = 0; // 検索方法：BL検索[品名表示時判断のため使用]
                //純正ＢＬコード検索
                switch (Blkind(PartsSearchUIData.TbsPartsCode, (int)PartsSearchUIData.SearchFlg))
                {
                    // 純正ＢＬコード検索
                    case 0:
                        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                        //status = BlSearchMain( PartsSearchUIData );
                        if ( _freeSearchDiv != 0 )
                        {
                            // 自由検索部品検索
                            FreeSearchPartsSearchMain( dsCarModelInfo, PartsSearchUIData );
                        }
                        status = BlSearchMain( PartsSearchUIData, false );
                        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                        break;

                    // 優良ＢＬコード検索
                    case 1:
                        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                        //status = PrimeBlSearchMain( PartsSearchUIData );
                        //if ( status == 4 || partsInfo.UsrGoodsInfo.Count == 0 ) // 検索正常だが、ヒットなしか
                        //    status = BlSearchMain( PartsSearchUIData );

                        if ( _freeSearchDiv != 0 )
                        {
                            // 自由検索部品検索
                            FreeSearchPartsSearchMain( dsCarModelInfo, PartsSearchUIData );

                            // 優良ＢＬコード検索
                            status = PrimeBlSearchMain( PartsSearchUIData );
                            if ( status == 4 || partsInfo.UsrGoodsInfo.Count == 0 )
                            {
                                // 検索正常だが、ヒットなしか⇒純正ＢＬコード検索
                                status = BlSearchMain( PartsSearchUIData, false );
                            }
                            else
                            {
                                // 自由検索部品展開（メソッド内部で通常の純正ＢＬコード検索は実行しない）
                                status = BlSearchMain( PartsSearchUIData, true );
                            }
                        }
                        else
                        {
                            // 優良ＢＬコード検索
                            status = PrimeBlSearchMain( PartsSearchUIData );
                            if ( status == 4 || partsInfo.UsrGoodsInfo.Count == 0 )
                            {
                                // 検索正常だが、ヒットなしか
                                status = BlSearchMain( PartsSearchUIData, false );
                            }
                        }
                        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                        break;
                    // TBO検索
                    case 2:
                        status = TBOSearchMain(PartsSearchUIData);

                        // -- ADD 2012/11/15 ---------------------------->>>
                        //TBO検索後、ヒット無しなら、純正BLコード検索
                        if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // 純正部品検索失敗又は検索正常でヒットなしか
                        {
                            status = BlSearchMain(PartsSearchUIData, false);
                        }
                        // -- ADD 2012/11/15 ----------------------------<<<
                        break;

                    // 純正検索後ヒットなしなら優良検索
                    case 3:
                        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                        //status = BlSearchMain(PartsSearchUIData);
                        //if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // 純正部品検索失敗又は検索正常でヒットなしか
                        //    status = PrimeBlSearchMain(PartsSearchUIData);

                        if ( _freeSearchDiv != 0 )
                        {
                            // 自由検索部品検索
                            FreeSearchPartsSearchMain( dsCarModelInfo, PartsSearchUIData );

                            status = BlSearchMain( PartsSearchUIData, false );
                            if ( _normalSearchStatus == 4 || partsInfo.UsrGoodsInfo.Count == 0 )  // 純正部品検索失敗又は検索正常でヒットなしか
                                status = PrimeBlSearchMain( PartsSearchUIData );
                        }
                        else
                        {
                            status = BlSearchMain( PartsSearchUIData, false );
                            if ( status == 4 || partsInfo.UsrGoodsInfo.Count == 0 )  // 純正部品検索失敗又は検索正常でヒットなしか
                                status = PrimeBlSearchMain( PartsSearchUIData );
                        }

                        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                        break;

                    default:
                        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
                        // BLKindが該当なしの場合は、自由検索抽出のみ行う。
                        if ( _freeSearchDiv != 0 )
                        {
                            // 自由検索部品検索
                            FreeSearchPartsSearchMain( dsCarModelInfo, PartsSearchUIData );

                            // 自由検索部品展開
                            status = BlSearchMain( PartsSearchUIData, true );
                        }
                        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
                        break;
                }
            }
            //品番検索
            else
            {
                partsInfo.SearchMethod = 1; // 検索方法：品番検索[品名表示時判断のため使用]
                status = PartsNoSearchMain(PartsSearchUIData);
            }
            SetUsrGoodsKind();
            partsInfo.AcceptChanges();
            retPartsInfo = partsInfo;
            retPartsInfo.SearchCondition = PartsSearchUIData;
            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 検索メイン（ＢＬコード検索・品番検索）
        /// </summary>
        /// <param name="dsCarModelInfo">車両型式データセット（型式未定のときはnullを設定すること）</param>
        /// <param name="partsSearchUIDataList">部品検索抽出条件</param>
        /// <param name="retPartsInfoList">部品検索結果</param>
        /// <returns></returns>
        public int GetPartsInfoMain(PMKEN01010E dsCarModelInfo, List<PartsSearchUIData> partsSearchUIDataList, out List<PartsInfoDataSet> retPartsInfoList)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // PartsInfoDataSetのクリア、検索条件の設定
            partsInfoDic = new Dictionary<int, PartsInfoDataSet>();
            goodsTableDic = new Dictionary<int, PartsInfoDataSet.UsrGoodsInfoDataTable>();
            priceTableDic = new Dictionary<int, PartsInfoDataSet.UsrGoodsPriceDataTable>();
            stockTableDic = new Dictionary<int, PartsInfoDataSet.StockDataTable>();
            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
            ofrPriceTableDic = new Dictionary<int, PartsInfoDataSet.UsrGoodsPriceDataTable>();
            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

            for (int i = 0; i < partsSearchUIDataList.Count; i++)
            {
                PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                partsInfoDataSet.SearchCondition = partsSearchUIDataList[i].Clone();
                partsInfoDic.Add(i, partsInfoDataSet);

                PartsInfoDataSet.UsrGoodsInfoDataTable goodsTableTemp = new PartsInfoDataSet.UsrGoodsInfoDataTable();
                goodsTableTemp = partsInfoDic[i].UsrGoodsInfo;
                goodsTableDic.Add(i, goodsTableTemp);

                PartsInfoDataSet.UsrGoodsPriceDataTable priceTableTemp = new PartsInfoDataSet.UsrGoodsPriceDataTable();
                priceTableTemp = partsInfoDic[i].UsrGoodsPrice;
                priceTableDic.Add(i, priceTableTemp);

                PartsInfoDataSet.StockDataTable stockTableTemp = new PartsInfoDataSet.StockDataTable();
                stockTableTemp = partsInfoDic[i].Stock;
                stockTableDic.Add(i, stockTableTemp);

                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                // UPD 2015/03/31 SCM高速化 メーカー希望小売価格対応②提供価格情報初期化不要のため修正-------------->>>>>
                //PartsInfoDataSet.UsrGoodsPriceDataTable ofrPriceTableTemp = new PartsInfoDataSet.UsrGoodsPriceDataTable();
                //ofrPriceTableTemp = partsInfoDic[i].OfrPriceDataTable;
                //ofrPriceTableDic.Add(i, ofrPriceTableTemp);
                ofrPriceTableDic.Add(i, partsInfoDic[i].OfrPriceDataTable);
                // UPD 2015/03/31 SCM高速化 メーカー希望小売価格対応②提供価格情報初期化不要のため修正--------------<<<<<
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            }
            _sectionCode = partsSearchUIDataList[0].SectionCode;
            _drPrmSettingWork = partsSearchUIDataList[0].PrmSettingWork;

            if (dsCarModelInfo != null)
            {
                carInfoDataSet = dsCarModelInfo;
                customerCarInfo = dsCarModelInfo.CarModelInfoSummarized;
            }
            else
            {
                carInfoDataSet = null;
                customerCarInfo = null;
            }

            if (_freeSearchDiv != 0)
            {
                // 初期化
                _freeSearchPartsSRetDic = null;
                _freeSearchPartsSRetWork = null;
            }

            // 検索種類毎にリスト生成
            // 純正BLコード検索用
            Dictionary<int, PartsSearchUIData> searchBLCodeList = new Dictionary<int, PartsSearchUIData>();
            // 優良BLコード検索用
            Dictionary<int, PartsSearchUIData> searchPrimeBLCodeList = new Dictionary<int, PartsSearchUIData>();
            // TBO検索用
            Dictionary<int, PartsSearchUIData> searchTBOList = new Dictionary<int, PartsSearchUIData>();
            // 提供BLコードなし検索用
            Dictionary<int, PartsSearchUIData> searchNoBLCodeList = new Dictionary<int, PartsSearchUIData>();
            // 自由検索部品検索用
            Dictionary<int, PartsSearchUIData> searchFreeSerachList = new Dictionary<int, PartsSearchUIData>();
            // 品番検索用
            Dictionary<int, PartsSearchUIData> searchGoodsNoList = new Dictionary<int, PartsSearchUIData>();

            for (int i = 0; i < partsSearchUIDataList.Count; i++)
            {
                // BLコード検索
                if (partsSearchUIDataList[i].TbsPartsCode != 0)
                {
                    partsInfoDic[i].SearchMethod = 0; // 検索方法：品番検索[品名表示時判断のため使用]
                    // BLコード検索種類判定
                    switch (Blkind(partsSearchUIDataList[i].TbsPartsCode, (int)partsSearchUIDataList[i].SearchFlg))
                    {
                        // 純正BLコード検索
                        case 0:
                            searchBLCodeList.Add(i, partsSearchUIDataList[i]);
                            break;
                        // 優良BLコード検索
                        case 1:
                            searchPrimeBLCodeList.Add(i, partsSearchUIDataList[i]);
                            break;
                        // TBO検索
                        case 2:
                            searchTBOList.Add(i, partsSearchUIDataList[i]);
                            break;
                        // 提供BLコードなし検索用
                        case 3:
                            searchNoBLCodeList.Add(i, partsSearchUIDataList[i]);
                            break;
                        // 自由検索部品検索用
                        default:
                            searchFreeSerachList.Add(i, partsSearchUIDataList[i]);
                            break;
                    }
                }
                // 品番検索
                else
                {
                    partsInfoDic[i].SearchMethod = 1; // 検索方法：品番検索[品名表示時判断のため使用]
                    searchGoodsNoList.Add(i, partsSearchUIDataList[i]);
                }
            }

            // 純正BLコード検索
            if (searchBLCodeList != null && searchBLCodeList.Count != 0)
            {
                if (_freeSearchDiv != 0)
                {
                    // 自由検索部品検索
                    FreeSearchPartsSearchMain(dsCarModelInfo, searchBLCodeList);
                }
                status = BlSearchMain(searchBLCodeList, false);
            }

            // 優良BLコード検索
            if (searchPrimeBLCodeList != null && searchPrimeBLCodeList.Count != 0)
            {

                if (_freeSearchDiv != 0)
                {
                    // 自由検索部品検索
                    FreeSearchPartsSearchMain(dsCarModelInfo, searchPrimeBLCodeList);

                    // 優良ＢＬコード検索
                    status = PrimeBlSearchMain(searchPrimeBLCodeList);
                    if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)
                    {
                        // 検索正常だが、ヒットなしか⇒純正ＢＬコード検索
                        status = BlSearchMain(searchPrimeBLCodeList, false);
                    }
                    else
                    {
                        // 自由検索部品展開（メソッド内部で通常の純正ＢＬコード検索は実行しない）
                        status = BlSearchMain(searchPrimeBLCodeList, true);
                    }
                }
                else
                {
                    // 優良ＢＬコード検索
                    status = PrimeBlSearchMain(searchPrimeBLCodeList);
                    if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)
                    {
                        // 検索正常だが、ヒットなしか
                        status = BlSearchMain(searchPrimeBLCodeList, false);
                    }
                }
            }

            // TBO検索
            if (searchTBOList != null && searchTBOList.Count != 0)
            {
                status = TBOSearchMain(searchTBOList);

                //TBO検索後、ヒット無しなら、純正BLコード検索
                if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // 純正部品検索失敗又は検索正常でヒットなしか
                {
                    status = BlSearchMain(searchTBOList, false);
                }
            }

            // 純正BLコードなしの時
            if (searchNoBLCodeList != null && searchNoBLCodeList.Count != 0)
            {
                // UPD №10681 2014/09/09 吉岡 -------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //status = TBOSearchMain(searchNoBLCodeList);

                ////TBO検索後、ヒット無しなら、純正BLコード検索
                //if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // 純正部品検索失敗又は検索正常でヒットなしか
                //{
                //    status = BlSearchMain(searchNoBLCodeList, false);
                //}
                #endregion

                if (_freeSearchDiv != 0)
                {
                    // 自由検索部品検索
                    FreeSearchPartsSearchMain(dsCarModelInfo, searchNoBLCodeList);

                    status = BlSearchMain(searchNoBLCodeList, false);
                    if (_normalSearchStatus == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // 純正部品検索失敗又は検索正常でヒットなしか
                        status = PrimeBlSearchMain(searchNoBLCodeList);
                }
                else
                {
                    status = BlSearchMain(searchNoBLCodeList, false);
                    if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // 純正部品検索失敗又は検索正常でヒットなしか
                        status = PrimeBlSearchMain(searchNoBLCodeList);
                }
                // UPD №10681 2014/09/09 吉岡 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            // 自由検索部品検索のみ
            if (searchFreeSerachList != null && searchFreeSerachList.Count != 0)
            {
                // BLKindが該当なしの場合は、自由検索抽出のみ行う。
                if (_freeSearchDiv != 0)
                {
                    // 自由検索部品検索
                    FreeSearchPartsSearchMain(dsCarModelInfo, searchFreeSerachList);

                    // 自由検索部品展開
                    status = BlSearchMain(searchFreeSerachList, true);
                }
            }

            // 品番検索
            if (searchGoodsNoList != null && searchGoodsNoList.Count != 0)
            {
                status = PartsNoSearchMain(searchGoodsNoList);
            }

            retPartsInfoList = new List<PartsInfoDataSet>();
            for (int key = 0; key < partsSearchUIDataList.Count; key++)
            {
                if (partsInfoDic.ContainsKey(key))
                {
                    SetUsrGoodsKind(key);
                    partsInfoDic[key].AcceptChanges();
                    partsInfoDic[key].SearchCondition = partsSearchUIDataList[key];
                    retPartsInfoList.Add(partsInfoDic[key]);
                }
            }
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// 自由検索部品マスタ抽出処理
        /// </summary>
        /// <param name="dsCarModelInfo"></param>
        /// <param name="PartsSearchUIData"></param>
        private void FreeSearchPartsSearchMain( PMKEN01010E dsCarModelInfo, PartsSearchUIData PartsSearchUIData )
        {
            // 抽出結果格納ディクショナリ（価格情報不足分を後で補う為、退避しておく）
            _freeSearchPartsSRetDic = new Dictionary<string, List<FreeSearchPartsSRetWork>>();

            // リモートオブジェクト取得
            IFreeSearchPartsSearchDB iFreeSearchPartsSearchDB = MediationFreeSearchPartsSearchDB.GetRemoteObject();

            # region [抽出条件]
            FreeSearchPartsSParaWork paraWork = new FreeSearchPartsSParaWork();

            paraWork.EnterpriseCode = PartsSearchUIData.EnterpriseCode; // 企業コード
            paraWork.PriceStartDate = PartsSearchUIData.PriceDate; // 価格開始日 
            paraWork.TbsPartsCode = PartsSearchUIData.TbsPartsCode; // ＢＬコード
            paraWork.TbsPartsCdDerivedNo = 0; // ＢＬコード枝番

            List<FreeSearchPartsSMdlParaWork> mdlList = new List<FreeSearchPartsSMdlParaWork>();
            foreach ( PMKEN01010E.CarModelInfoRow carRow in dsCarModelInfo.CarModelInfo.Rows )
            {
                // 選択フラグチェック
                if ( carRow.SelectionState != true )
                {
                    continue;
                }

                // 部品検索の条件として、型式情報をセットする
                FreeSearchPartsSMdlParaWork mdlParaWork = new FreeSearchPartsSMdlParaWork();

                //--------------------------------------------------
                // 型式情報
                //--------------------------------------------------
                mdlParaWork.MakerCode = carRow.MakerCode; // メーカーコード
                mdlParaWork.ModelCode = carRow.ModelCode; // 車種コード
                mdlParaWork.ModelSubCode = carRow.ModelSubCode; // 車種サブコード

                mdlParaWork.ExhaustGasSign = carRow.ExhaustGasSign; // 排ガス記号（型式０）
                mdlParaWork.SeriesModel = carRow.SeriesModel; // シリーズ型式（型式１）
                mdlParaWork.CategorySignModel = carRow.CategorySignModel; // 型式（類別記号）（型式２）

                mdlParaWork.FullModel = carRow.FullModel; // 型式（フル型）

                if ( carInfoDataSet.CarModelUIData.Count > 0 )
                {
                    // 年式
                    if ( carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput > 0 )
                    {
                        mdlParaWork.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                    }
                    // 車台番号
                    if ( carInfoDataSet.CarModelUIData[0].SearchFrameNo > 0 )
                    {
                        try
                        {
                            mdlParaWork.ProduceFrameNo = Convert.ToInt32( carInfoDataSet.CarModelUIData[0].FrameNo );
                        }
                        catch
                        {
                            mdlParaWork.ProduceFrameNo = 0;
                        }
                    }
                }

                //--------------------------------------------------
                // 諸元情報
                //--------------------------------------------------
                mdlParaWork.ModelGradeNm = carRow.ModelGradeNm; // 型式グレード名称
                mdlParaWork.BodyName = carRow.BodyName; // ボディー名称
                mdlParaWork.DoorCount = carRow.DoorCount; // ドア数
                mdlParaWork.EngineModelNm = carRow.EngineModelNm; // エンジン型式名称
                mdlParaWork.EngineDisplaceNm = carRow.EngineDisplaceNm; // 排気量名称
                mdlParaWork.EDivNm = carRow.EDivNm; // E区分名称
                mdlParaWork.TransmissionNm = carRow.TransmissionNm; // ミッション名称
                mdlParaWork.WheelDriveMethodNm = carRow.WheelDriveMethodNm; // 駆動方式名称
                mdlParaWork.ShiftNm = carRow.ShiftNm; // シフト名称

                mdlList.Add( mdlParaWork );
            }

            paraWork.FSPartsSModels = mdlList.ToArray();
            # endregion

            object retObj = null;
            Int64 retCount;

            // 自由検索部品マスタ取得リモート呼び出し
            iFreeSearchPartsSearchDB.Search( paraWork, ref retObj, out retCount );

            // データ格納処理（この時点ではディクショナリへの退避のみ）
            if ( retCount > 0 )
            {
                ArrayList retArray = (retObj as ArrayList);

                foreach ( FreeSearchPartsSRetWork obj in retArray )
                {
                    string key = CreateFreeSearchRetDicKey( obj.GoodsMakerCd, obj.GoodsNo );
                    if ( !_freeSearchPartsSRetDic.ContainsKey( key ) )
                    {
                        _freeSearchPartsSRetDic.Add( key, new List<FreeSearchPartsSRetWork>() );
                    }
                    _freeSearchPartsSRetDic[key].Add( obj );
                }

                // 最初の１件を退避しておく
                _freeSearchPartsSRetWork = (FreeSearchPartsSRetWork)retArray[0];
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 自由検索部品マスタ抽出処理
        /// </summary>
        /// <param name="dsCarModelInfo"></param>
        /// <param name="partsSearchUIDataDic"></param>
        private void FreeSearchPartsSearchMain(PMKEN01010E dsCarModelInfo, Dictionary<int,PartsSearchUIData> partsSearchUIDataDic)
        {
            // 抽出結果格納ディクショナリ（価格情報不足分を後で補う為、退避しておく）
            _freeSearchPartsSRetDic = new Dictionary<string, List<FreeSearchPartsSRetWork>>();

            // リモートオブジェクト取得
            IFreeSearchPartsSearchDB iFreeSearchPartsSearchDB = MediationFreeSearchPartsSearchDB.GetRemoteObject();

            # region [抽出条件]
            ArrayList paraWorkList = new ArrayList();

            foreach (PartsSearchUIData partsSearchUIData in partsSearchUIDataDic.Values)
            {
                FreeSearchPartsSParaWork paraWork = new FreeSearchPartsSParaWork();

                paraWork.EnterpriseCode = partsSearchUIData.EnterpriseCode; // 企業コード
                paraWork.PriceStartDate = partsSearchUIData.PriceDate; // 価格開始日 
                paraWork.TbsPartsCode = partsSearchUIData.TbsPartsCode; // ＢＬコード
                paraWork.TbsPartsCdDerivedNo = 0; // ＢＬコード枝番

                List<FreeSearchPartsSMdlParaWork> mdlList = new List<FreeSearchPartsSMdlParaWork>();
                foreach (PMKEN01010E.CarModelInfoRow carRow in dsCarModelInfo.CarModelInfo.Rows)
                {
                    // 選択フラグチェック
                    if (carRow.SelectionState != true)
                    {
                        continue;
                    }

                    // 部品検索の条件として、型式情報をセットする
                    FreeSearchPartsSMdlParaWork mdlParaWork = new FreeSearchPartsSMdlParaWork();

                    //--------------------------------------------------
                    // 型式情報
                    //--------------------------------------------------
                    mdlParaWork.MakerCode = carRow.MakerCode; // メーカーコード
                    mdlParaWork.ModelCode = carRow.ModelCode; // 車種コード
                    mdlParaWork.ModelSubCode = carRow.ModelSubCode; // 車種サブコード

                    mdlParaWork.ExhaustGasSign = carRow.ExhaustGasSign; // 排ガス記号（型式０）
                    mdlParaWork.SeriesModel = carRow.SeriesModel; // シリーズ型式（型式１）
                    mdlParaWork.CategorySignModel = carRow.CategorySignModel; // 型式（類別記号）（型式２）

                    mdlParaWork.FullModel = carRow.FullModel; // 型式（フル型）

                    if (carInfoDataSet.CarModelUIData.Count > 0)
                    {
                        // 年式
                        if (carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput > 0)
                        {
                            mdlParaWork.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                        }
                        // 車台番号
                        if (carInfoDataSet.CarModelUIData[0].SearchFrameNo > 0)
                        {
                            try
                            {
                                mdlParaWork.ProduceFrameNo = Convert.ToInt32(carInfoDataSet.CarModelUIData[0].FrameNo);
                            }
                            catch
                            {
                                mdlParaWork.ProduceFrameNo = 0;
                            }
                        }
                    }

                    //--------------------------------------------------
                    // 諸元情報
                    //--------------------------------------------------
                    mdlParaWork.ModelGradeNm = carRow.ModelGradeNm; // 型式グレード名称
                    mdlParaWork.BodyName = carRow.BodyName; // ボディー名称
                    mdlParaWork.DoorCount = carRow.DoorCount; // ドア数
                    mdlParaWork.EngineModelNm = carRow.EngineModelNm; // エンジン型式名称
                    mdlParaWork.EngineDisplaceNm = carRow.EngineDisplaceNm; // 排気量名称
                    mdlParaWork.EDivNm = carRow.EDivNm; // E区分名称
                    mdlParaWork.TransmissionNm = carRow.TransmissionNm; // ミッション名称
                    mdlParaWork.WheelDriveMethodNm = carRow.WheelDriveMethodNm; // 駆動方式名称
                    mdlParaWork.ShiftNm = carRow.ShiftNm; // シフト名称

                    mdlList.Add(mdlParaWork);
                }

                paraWork.FSPartsSModels = mdlList.ToArray();

                paraWorkList.Add(paraWork);

            }
            # endregion

            ArrayList para = paraWorkList;
            object retObj = null;
            Int64 retCount;

            // 自由検索部品マスタ取得リモート呼び出し
            iFreeSearchPartsSearchDB.Search(para, ref retObj, out retCount);

            // データ格納処理（この時点ではディクショナリへの退避のみ）
            if (retCount > 0)
            {
                List<int> partsSearchKeyList = new List<int>(partsSearchUIDataDic.Keys);
                 
                ArrayList retArray = retObj as ArrayList;
                bool firstRec = false;

                for (int i = 0; i < retArray.Count; i++)
                {
                    ArrayList retArray2 = retArray[i] as ArrayList;
                    if (retArray2.Count > 0)
                    {
                        FreeSearchPartsSRetWork[] FreeSearchPartsSRetWorkList = (FreeSearchPartsSRetWork[])retArray2.ToArray(typeof(FreeSearchPartsSRetWork));

                        // 最初の１件を退避しておく
                        if (!firstRec)
                        {
                            _freeSearchPartsSRetWork = FreeSearchPartsSRetWorkList[0];
                            firstRec = true;
                        }

                        foreach (FreeSearchPartsSRetWork obj in FreeSearchPartsSRetWorkList)
                        {
                            string key = CreateFreeSearchRetDicKey(partsSearchKeyList[i], obj.GoodsMakerCd, obj.GoodsNo);
                            if (!_freeSearchPartsSRetDic.ContainsKey(key))
                            {
                                _freeSearchPartsSRetDic.Add(key, new List<FreeSearchPartsSRetWork>());
                            }
                            _freeSearchPartsSRetDic[key].Add(obj);
                        }
                    }
                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 自由検索部品情報のDataTableへの格納処理
        /// </summary>
        /// <param name="retPartsInfListDic"></param>
        private void FillFreeSearchPartsInfo( Dictionary<string, List<FreeSearchPartsSRetWork>> retPartsInfListDic )
        {
            foreach ( string key in retPartsInfListDic.Keys )
            {
                List<FreeSearchPartsSRetWork> retPartsInfList = retPartsInfListDic[key];
                foreach ( FreeSearchPartsSRetWork retWork in retPartsInfList )
                {
                    // BLコード・BLコード枝番
                    int tbsPartsCode = retWork.BLGoodsCodeFromGoods;
                    int tbsPartsCdDerivedNo = 0;

                    // 提供純正
                    RetPartsInf retPartsInf = null;
                    if ( _retPartsInfDic.ContainsKey( key ) )
                    {
                        retPartsInf = _retPartsInfDic[key];
                    }

                    // 提供優良
                    OfferJoinPartsRetWork retPrimParts = null;
                    if ( _primPartsRetDic.ContainsKey( key ) )
                    {
                        retPrimParts = _primPartsRetDic[key];
                    }

                    // 提供優良価格
                    OfferJoinPriceRetWork retPrimPrice = null;
                    if ( _primPriceRetDic.ContainsKey( key ) )
                    {
                        retPrimPrice = GetPrimePrice( _primPriceRetDic[key] );
                    }

                    //--------------------------------------------------
                    // 部品情報テーブルへの格納
                    //--------------------------------------------------

                    // 商品マスタの該当が無かった場合はＢＬコードマスタの品名をセットする。
                    if ( string.IsNullOrEmpty( retWork.GoodsName.Trim() ) && string.IsNullOrEmpty( retWork.GoodsNoFromGoods.Trim() ) )
                    {
                        retWork.GoodsName = retWork.BLGoodsFullName;
                        retWork.GoodsNameKana = retWork.BLGoodsHalfName;
                        tbsPartsCode = retWork.TbsPartsCode;
                        tbsPartsCdDerivedNo = retWork.TbsPartsCdDerivedNo;
                    }

                    # region [自由検索部品情報]

                    PartsInfoDataSet.PartsInfoRow partsInfoRow = partsInfo.PartsInfo.NewPartsInfoRow();

                    # region [提供純正or提供優良からセット]
                    if ( !string.IsNullOrEmpty( retWork.GoodsNoFromGoods ) )
                    {
                        // ユーザー商品

                    }
                    else if ( retPartsInf != null )
                    {
                        //----------------------------------------
                        // 提供純正からセット
                        //----------------------------------------
                        // Rowにセット
                        partsInfoRow.OfferDate = retPartsInf.OfferDate;
                        partsInfoRow.FigshapeNo = retPartsInf.FigShapeNo;
                        partsInfoRow.StandardName = retPartsInf.StandardName;
                        partsInfoRow.ColdDistrictsFlag = retPartsInf.ColdDistrictsFlag;
                        partsInfoRow.ColorNarrowingFlag = retPartsInf.ColorNarrowingFlag;
                        partsInfoRow.TrimNarrowingFlag = retPartsInf.TrimNarrowingFlag;
                        partsInfoRow.EquipNarrowingFlag = retPartsInf.EquipNarrowingFlag;
                        partsInfoRow.NewPrtsNoNoneHyphen = retPartsInf.NewPrtsNoWithHyphen;
                        partsInfoRow.MakerOfferPartsName = retPartsInf.MakerOfferPartsName;
                        partsInfoRow.PartsSearchCode = retPartsInf.PartsSearchCode;
                        partsInfoRow.PartsCode = retPartsInf.PartsCode;

                        // この後の処理でも使用するので、retWorkも書き換える
                        retWork.GoodsName = retPartsInf.PartsName;
                        retWork.GoodsNameKana = retPartsInf.PartsNameKana;
                        retWork.ListPrice = retPartsInf.PartsPrice;
                        retWork.OpenPriceDiv = retPartsInf.OpenPriceDiv;
                        retWork.PriceStartDate = retPartsInf.PartsPriceStDate;
                        retWork.GoodsRateRank = retPartsInf.PartsLayerCd;
                    }
                    else if ( retPrimParts != null )
                    {
                        //----------------------------------------
                        // 提供優良からセット
                        //----------------------------------------
                        // Rowにセット
                        partsInfoRow.OfferDate = retPrimParts.OfferDate;

                        // この後の処理でも使用するので、retWorkも書き換える
                        retWork.GoodsName = retPrimParts.PrimePartsName;
                        retWork.GoodsNameKana = retPrimParts.PrimePartsKanaName;
                        retWork.GoodsRateRank = retPrimParts.PartsLayerCd;

                        if ( retPrimPrice != null )
                        {
                            retWork.ListPrice = retPrimPrice.NewPrice;
                            retWork.OpenPriceDiv = retPrimPrice.OpenPriceDiv;
                            retWork.PriceStartDate = retPrimPrice.PriceStartDate;
                        }
                    }
                    # endregion

                    partsInfoRow.PartsName = retWork.GoodsName;
                    partsInfoRow.PartsNameKana = retWork.GoodsNameKana;
                    partsInfoRow.TbsPartsCode = tbsPartsCode;
                    partsInfoRow.TbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
                    partsInfoRow.TbsPartsCodeFS = retWork.TbsPartsCode;
                    partsInfoRow.ModelPrtsAdptYm = GetLongDateYM( retWork.ModelPrtsAdptYm );
                    partsInfoRow.ModelPrtsAblsYm = GetLongDateYM( retWork.ModelPrtsAblsYm );
                    partsInfoRow.ModelPrtsAdptFrameNo = retWork.ModelPrtsAdptFrameNo;
                    partsInfoRow.ModelPrtsAblsFrameNo = retWork.ModelPrtsAblsFrameNo;
                    partsInfoRow.PartsQty = retWork.PartsQty;
                    partsInfoRow.PartsOpNm = string.Format( "自由検索：{0}", retWork.PartsOpNm );
                    partsInfoRow.CatalogPartsMakerCd = retWork.GoodsMakerCd;
                    partsInfoRow.CatalogPartsMakerNm = GetPartsMakerName( retWork.GoodsMakerCd );
                    partsInfoRow.ClgPrtsNoWithHyphen = retWork.GoodsNo.Trim();
                    partsInfoRow.MakerOfferPartsName = retWork.GoodsName;
                    partsInfoRow.PartsLayerCd = retWork.GoodsRateRank;
                    partsInfoRow.SeriesModel = retWork.SeriesModel;
                    partsInfoRow.CategorySignModel = retWork.CategorySignModel;
                    partsInfoRow.ExhaustGasSign = retWork.ExhaustGasSign;

                    partsInfoRow.NewPrtsNoWithHyphen = retWork.GoodsNo;
                    partsInfoRow.NewPrtsNoNoneHyphen = retWork.GoodsNoNoneHyphen;

                    partsInfoRow.FreSrchPrtPropNo = retWork.FreSrchPrtPropNo; // 自由検索部品固有番号

                    partsInfo.PartsInfo.AddPartsInfoRow( partsInfoRow );
                    # endregion

                    //--------------------------------------------------
                    // 商品マスタテーブルへ格納
                    //--------------------------------------------------

                    #region 商品マスタテーブルに設定
                    string partsNo = retWork.GoodsNo;
                    PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                        goodsTable.FindByGoodsMakerCdGoodsNo( retWork.GoodsMakerCd, partsNo );
                    if ( usrGoodsRow == null )
                    {
                        usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();

                        usrGoodsRow.BlGoodsCode = tbsPartsCode;
                        usrGoodsRow.GoodsKindCode = 0; // 0 : 純正
                        usrGoodsRow.GoodsKind = (int)GoodsKind.Parent; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                        usrGoodsRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrGoodsRow.GoodsMakerNm = partsInfoRow.CatalogPartsMakerNm;
                        //usrGoodsRow.GoodsMGroup = 0;
                        usrGoodsRow.GoodsRateRank = retWork.GoodsRateRank;
                        usrGoodsRow.GoodsNoNoneHyphen = partsInfoRow.ClgPrtsNoWithHyphen.Replace( "-", "" );
                        usrGoodsRow.QTY = retWork.PartsQty;
                        usrGoodsRow.GoodsNote1 = string.Empty;//retWork.StandardName; //規格
                        //usrGoodsRow.GoodsNote2 = "";
                        usrGoodsRow.GoodsSpecialNote = retWork.PartsOpNm;
                        usrGoodsRow.OfferDate = DateTime.MinValue; //retWork.OfferDate;

                        usrGoodsRow.OfferKubun = 0; // (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）

                        //usrGoodsRow.TaxationDivCd = 0;
                        usrGoodsRow.GoodsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                        usrGoodsRow.OfferDataDiv = 0; //1;

                        usrGoodsRow.GoodsName = retWork.GoodsName;
                        usrGoodsRow.GoodsNameKana = retWork.GoodsNameKana;
                        usrGoodsRow.GoodsOfrName = retWork.GoodsName; // 部品名
                        usrGoodsRow.GoodsOfrNameKana = retWork.GoodsNameKana;
                        usrGoodsRow.SearchPartsFullName = retWork.GoodsName;
                        usrGoodsRow.SearchPartsHalfName = retWork.GoodsNameKana;
                        usrGoodsRow.SrchPNmAcqrCarMkrCd = 0; //retWork.SrchPNmAcqrCarMkrCd;   // 検索品名取得メーカーコード
                        usrGoodsRow.PartsPriceStDate = retWork.PriceStartDate;


                        # region [提供純正/提供優良からセット]
                        if ( !string.IsNullOrEmpty( retWork.GoodsNoFromGoods ) )
                        {
                            // ユーザー商品

                            if ( retPartsInf != null )
                            {
                                // 検索品名を更新
                                usrGoodsRow.SearchPartsFullName = retPartsInf.PartsName;
                                usrGoodsRow.SearchPartsHalfName = retPartsInf.PartsNameKana;
                                usrGoodsRow.SrchPNmAcqrCarMkrCd = retPartsInf.SrchPNmAcqrCarMkrCd;
                            }
                            else if ( retPrimParts != null )
                            {
                                usrGoodsRow.SearchPartsFullName = retPrimParts.SearchPartsFullName;
                                usrGoodsRow.SearchPartsHalfName = retPrimParts.SearchPartsHalfName;
                                usrGoodsRow.SrchPNmAcqrCarMkrCd = retPrimParts.JoinDestMakerCd;   // 検索品名取得メーカーコード
                            }
                        }
                        else if ( retPartsInf != null )
                        {
                            // 純正
                            usrGoodsRow.GoodsNote1 = retPartsInf.StandardName; //規格
                            usrGoodsRow.OfferDate = retPartsInf.OfferDate; // 提供日
                            usrGoodsRow.SearchPartsFullName = retPartsInf.PartsName;
                            usrGoodsRow.SearchPartsHalfName = retPartsInf.PartsNameKana;
                            usrGoodsRow.SrchPNmAcqrCarMkrCd = retPartsInf.SrchPNmAcqrCarMkrCd;   // 検索品名取得メーカーコード
                            usrGoodsRow.OfferKubun = 3; // (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                        }
                        else if ( retPrimParts != null )
                        {
                            // 優良
                            usrGoodsRow.OfferDate = retPrimParts.OfferDate; // 提供日
                            usrGoodsRow.SearchPartsFullName = retPrimParts.SearchPartsFullName;
                            usrGoodsRow.SearchPartsHalfName = retPrimParts.SearchPartsHalfName;
                            usrGoodsRow.SrchPNmAcqrCarMkrCd = retPrimParts.JoinDestMakerCd;   // 検索品名取得メーカーコード
                            usrGoodsRow.OfferKubun = 4; // (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                        }
                        # endregion

                        usrGoodsRow.FreSrchPrtPropNo = retWork.FreSrchPrtPropNo; // 自由検索部品固有番号

                        partsInfoRow.UsrGoodsInfoRowParentByUsrGoodsInfo_PartsInfo = usrGoodsRow;
                        goodsTable.AddUsrGoodsInfoRow( usrGoodsRow );
                    }
                    # endregion

                    //--------------------------------------------------
                    // 価格テーブルへ格納
                    //--------------------------------------------------

                    # region [価格テーブルに設定]
                    if ( priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo( retWork.GoodsMakerCd,
                        retWork.PriceStartDate, retWork.GoodsNo ) == null )
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();

                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        double listPrice = retWork.ListPrice;
                        this.ReflectIsolIslandCall( 0, retWork.GoodsMakerCd, 3, ref listPrice );
                        usrPriceRow.ListPrice = listPrice;
                        usrPriceRow.OpenPriceDiv = retWork.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retWork.PriceStartDate;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        # region [提供純正からセット]
                        if ( retPartsInf != null )
                        {
                            usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        }
                        # endregion

                        priceTable.AddUsrGoodsPriceRow( usrPriceRow );
                    }
                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                    // UPD 2015/03/30 全体配信システムテスト障害№60対応 ------------------------------------>>>>>
                    //if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,
                    //    retWork.PriceStartDate, retWork.GoodsNo) == null)
                    // 提供データが取得できた時、且つ提供データ価格情報データテーブルに対象の価格レコードが存在しない時追加
                    // UPD 2015/03/31 SCM高速化 メーカー希望小売価格対応①自由検索部品価格情報対応------------>>>>>
                    //if ((retPartsInf != null) && 
                    //    (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,retWork.PriceStartDate, retWork.GoodsNo) == null))
                    if ((retPartsInf != null) && 
                        (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,retPartsInf.PartsPriceStDate, retWork.GoodsNo) == null))
                    // UPD 2015/03/31 SCM高速化 メーカー希望小売価格対応①自由検索部品価格情報対応------------<<<<<
                    // UPD 2015/03/30 全体配信システムテスト障害№60対応 ------------------------------------<<<<<
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();

                        // UPD 2015/03/30 全体配信システムテスト障害№60対応 ------------------------------------>>>>>
                        #region 削除
                        //usrPriceRow.GoodsNo = retWork.GoodsNo;
                        //usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        //double listPrice = retWork.ListPrice;
                        //this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        //usrPriceRow.ListPrice = listPrice;
                        //usrPriceRow.OpenPriceDiv = retWork.OpenPriceDiv;
                        //usrPriceRow.PriceStartDate = retWork.PriceStartDate;
                        //usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        //# region [提供純正からセット]
                        //if (retPartsInf != null)
                        //{
                        //    usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        //}
                        //# endregion
                        #endregion
                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        // 提供純正からセット
                        usrPriceRow.OpenPriceDiv = retPartsInf.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retPartsInf.PartsPriceStDate;
                        double listPrice = retPartsInf.PartsPrice;
                        this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        usrPriceRow.ListPrice = listPrice;
                        usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        // UPD 2015/03/30 全体配信システムテスト障害№60対応 ------------------------------------<<<<<

                        ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                    // ADD 2015/03/31 SCM高速化 メーカー希望小売価格対応①自由検索部品価格情報対応------------->>>>>
                    // 提供優良データ、提供優良価格情報が取得できる時、且つ提供データ価格情報テーブルに該当する価格情報データが存在しない時追加
                    if ((retPrimParts != null && retPrimPrice != null) &&
                        (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd, retPrimPrice.PriceStartDate, retWork.GoodsNo) == null))
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();

                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        // 提供優良からセット
                        usrPriceRow.OpenPriceDiv = retPrimPrice.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retPrimPrice.PriceStartDate;
                        usrPriceRow.ListPrice = retPrimPrice.NewPrice;
                        usrPriceRow.OfferDate = retPrimPrice.OfferDate;

                        ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/31 SCM高速化 メーカー希望小売価格対応①自由検索部品価格情報対応-------------<<<<<
                    # endregion

                    //--------------------------------------------------
                    // 部品関連型式情報テーブルへ格納
                    //--------------------------------------------------

                    #region 部品関連型式情報設定
                    PartsInfoDataSet.ModelPartsDetailDataTable modelInfo = partsInfo.ModelPartsDetail;

                    string select = string.Format( "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}' ",
                                                   carInfoDataSet.CarModelInfo.MakerCodeColumn.ColumnName, retWork.MakerCode,
                                                   carInfoDataSet.CarModelInfo.ModelCodeColumn.ColumnName, retWork.ModelCode,
                                                   carInfoDataSet.CarModelInfo.ModelSubCodeColumn.ColumnName, retWork.ModelSubCode,
                                                   carInfoDataSet.CarModelInfo.FullModelColumn.ColumnName, retWork.FullModel );

                    PMKEN01010E.CarModelInfoRow[] carModelInfoRows = (PMKEN01010E.CarModelInfoRow[])carInfoDataSet.CarModelInfo.Select( select );

                    //車輌情報→部品詳細（型式情報）設定
                    for ( int ix = 0; ix < carModelInfoRows.Length; ix++ )
                    {
                        PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = modelInfo.NewModelPartsDetailRow();

                        modelPartsDetailRow.PartsUniqueNo = 0;
                        modelPartsDetailRow.PartsMakerCd = retWork.GoodsMakerCd;
                        modelPartsDetailRow.PartsNo = retWork.GoodsNo;

                        modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                        modelPartsDetailRow.DoorCount = carModelInfoRows[ix].DoorCount;
                        modelPartsDetailRow.BodyName = carModelInfoRows[ix].BodyName;
                        modelPartsDetailRow.ModelGradeNm = carModelInfoRows[ix].ModelGradeNm;
                        modelPartsDetailRow.EngineModelNm = carModelInfoRows[ix].EngineModelNm;
                        modelPartsDetailRow.EngineDisplaceNm = carModelInfoRows[ix].EngineDisplaceNm;
                        modelPartsDetailRow.EDivNm = carModelInfoRows[ix].EDivNm;
                        modelPartsDetailRow.TransmissionNm = carModelInfoRows[ix].TransmissionNm;
                        modelPartsDetailRow.ShiftNm = carModelInfoRows[ix].ShiftNm;
                        modelPartsDetailRow.WheelDriveMethodNm = carModelInfoRows[ix].WheelDriveMethodNm;
                        modelPartsDetailRow.AddiCarSpec1 = carModelInfoRows[ix].AddiCarSpec1;
                        modelPartsDetailRow.AddiCarSpec2 = carModelInfoRows[ix].AddiCarSpec2;
                        modelPartsDetailRow.AddiCarSpec3 = carModelInfoRows[ix].AddiCarSpec3;
                        modelPartsDetailRow.AddiCarSpec4 = carModelInfoRows[ix].AddiCarSpec4;
                        modelPartsDetailRow.AddiCarSpec5 = carModelInfoRows[ix].AddiCarSpec5;
                        modelPartsDetailRow.AddiCarSpec6 = carModelInfoRows[ix].AddiCarSpec6;

                        modelInfo.AddModelPartsDetailRow( modelPartsDetailRow );
                    }
                    if ( carModelInfoRows.Length > 0 )
                    {
                        modelInfo.Columns[modelInfo.AddiCarSpec1Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle1;
                        modelInfo.Columns[modelInfo.AddiCarSpec2Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle2;
                        modelInfo.Columns[modelInfo.AddiCarSpec3Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle3;
                        modelInfo.Columns[modelInfo.AddiCarSpec4Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle4;
                        modelInfo.Columns[modelInfo.AddiCarSpec5Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle5;
                        modelInfo.Columns[modelInfo.AddiCarSpec6Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle6;
                    }
                    #endregion
                }
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 自由検索部品情報のDataTableへの格納処理
        /// </summary>
        /// <param name="retPartsInfListDic"></param>
        /// <param name="dicKey"></param>
        private void FillFreeSearchPartsInfo(Dictionary<string, List<FreeSearchPartsSRetWork>> retPartsInfListDic, int dicKey)
        {
            foreach (string key in retPartsInfListDic.Keys)
            {
                // 明細行番号と違う時は次の自由検索部品情報へ
                if (key.Substring(0, 2) != dicKey.ToString("00")) continue;

                List<FreeSearchPartsSRetWork> retPartsInfList = retPartsInfListDic[key];
                foreach (FreeSearchPartsSRetWork retWork in retPartsInfList)
                {
                    // BLコード・BLコード枝番
                    int tbsPartsCode = retWork.BLGoodsCodeFromGoods;
                    int tbsPartsCdDerivedNo = 0;

                    // 提供純正
                    RetPartsInf retPartsInf = null;
                    if (_retPartsInfDic.ContainsKey(key))
                    {
                        retPartsInf = _retPartsInfDic[key];
                    }

                    // 提供優良
                    OfferJoinPartsRetWork retPrimParts = null;
                    if (_primPartsRetDic.ContainsKey(key))
                    {
                        retPrimParts = _primPartsRetDic[key];
                    }

                    // 提供優良価格
                    OfferJoinPriceRetWork retPrimPrice = null;
                    if (_primPriceRetDic.ContainsKey(key))
                    {
                        retPrimPrice = GetPrimePrice(_primPriceRetDic[key]);
                    }

                    //--------------------------------------------------
                    // 部品情報テーブルへの格納
                    //--------------------------------------------------

                    // 商品マスタの該当が無かった場合はＢＬコードマスタの品名をセットする。
                    if (string.IsNullOrEmpty(retWork.GoodsName.Trim()) && string.IsNullOrEmpty(retWork.GoodsNoFromGoods.Trim()))
                    {
                        retWork.GoodsName = retWork.BLGoodsFullName;
                        retWork.GoodsNameKana = retWork.BLGoodsHalfName;
                        tbsPartsCode = retWork.TbsPartsCode;
                        tbsPartsCdDerivedNo = retWork.TbsPartsCdDerivedNo;
                    }

                    # region [自由検索部品情報]

                    PartsInfoDataSet.PartsInfoRow partsInfoRow = partsInfoDic[dicKey].PartsInfo.NewPartsInfoRow();

                    # region [提供純正or提供優良からセット]
                    if (!string.IsNullOrEmpty(retWork.GoodsNoFromGoods))
                    {
                        // ユーザー商品

                    }
                    else if (retPartsInf != null)
                    {
                        //----------------------------------------
                        // 提供純正からセット
                        //----------------------------------------
                        // Rowにセット
                        partsInfoRow.OfferDate = retPartsInf.OfferDate;
                        partsInfoRow.FigshapeNo = retPartsInf.FigShapeNo;
                        partsInfoRow.StandardName = retPartsInf.StandardName;
                        partsInfoRow.ColdDistrictsFlag = retPartsInf.ColdDistrictsFlag;
                        partsInfoRow.ColorNarrowingFlag = retPartsInf.ColorNarrowingFlag;
                        partsInfoRow.TrimNarrowingFlag = retPartsInf.TrimNarrowingFlag;
                        partsInfoRow.EquipNarrowingFlag = retPartsInf.EquipNarrowingFlag;
                        partsInfoRow.NewPrtsNoNoneHyphen = retPartsInf.NewPrtsNoWithHyphen;
                        partsInfoRow.MakerOfferPartsName = retPartsInf.MakerOfferPartsName;
                        partsInfoRow.PartsSearchCode = retPartsInf.PartsSearchCode;
                        partsInfoRow.PartsCode = retPartsInf.PartsCode;

                        // この後の処理でも使用するので、retWorkも書き換える
                        retWork.GoodsName = retPartsInf.PartsName;
                        retWork.GoodsNameKana = retPartsInf.PartsNameKana;
                        retWork.ListPrice = retPartsInf.PartsPrice;
                        retWork.OpenPriceDiv = retPartsInf.OpenPriceDiv;
                        retWork.PriceStartDate = retPartsInf.PartsPriceStDate;
                        retWork.GoodsRateRank = retPartsInf.PartsLayerCd;
                    }
                    else if (retPrimParts != null)
                    {
                        //----------------------------------------
                        // 提供優良からセット
                        //----------------------------------------
                        // Rowにセット
                        partsInfoRow.OfferDate = retPrimParts.OfferDate;

                        // この後の処理でも使用するので、retWorkも書き換える
                        retWork.GoodsName = retPrimParts.PrimePartsName;
                        retWork.GoodsNameKana = retPrimParts.PrimePartsKanaName;
                        retWork.GoodsRateRank = retPrimParts.PartsLayerCd;

                        if (retPrimPrice != null)
                        {
                            retWork.ListPrice = retPrimPrice.NewPrice;
                            retWork.OpenPriceDiv = retPrimPrice.OpenPriceDiv;
                            retWork.PriceStartDate = retPrimPrice.PriceStartDate;
                        }
                    }
                    # endregion

                    partsInfoRow.PartsName = retWork.GoodsName;
                    partsInfoRow.PartsNameKana = retWork.GoodsNameKana;
                    partsInfoRow.TbsPartsCode = tbsPartsCode;
                    partsInfoRow.TbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
                    partsInfoRow.TbsPartsCodeFS = retWork.TbsPartsCode;
                    partsInfoRow.ModelPrtsAdptYm = GetLongDateYM(retWork.ModelPrtsAdptYm);
                    partsInfoRow.ModelPrtsAblsYm = GetLongDateYM(retWork.ModelPrtsAblsYm);
                    partsInfoRow.ModelPrtsAdptFrameNo = retWork.ModelPrtsAdptFrameNo;
                    partsInfoRow.ModelPrtsAblsFrameNo = retWork.ModelPrtsAblsFrameNo;
                    partsInfoRow.PartsQty = retWork.PartsQty;
                    partsInfoRow.PartsOpNm = string.Format("自由検索：{0}", retWork.PartsOpNm);
                    partsInfoRow.CatalogPartsMakerCd = retWork.GoodsMakerCd;
                    partsInfoRow.CatalogPartsMakerNm = GetPartsMakerName(retWork.GoodsMakerCd);
                    partsInfoRow.ClgPrtsNoWithHyphen = retWork.GoodsNo.Trim();
                    partsInfoRow.MakerOfferPartsName = retWork.GoodsName;
                    partsInfoRow.PartsLayerCd = retWork.GoodsRateRank;
                    partsInfoRow.SeriesModel = retWork.SeriesModel;
                    partsInfoRow.CategorySignModel = retWork.CategorySignModel;
                    partsInfoRow.ExhaustGasSign = retWork.ExhaustGasSign;

                    partsInfoRow.NewPrtsNoWithHyphen = retWork.GoodsNo;
                    partsInfoRow.NewPrtsNoNoneHyphen = retWork.GoodsNoNoneHyphen;

                    partsInfoRow.FreSrchPrtPropNo = retWork.FreSrchPrtPropNo; // 自由検索部品固有番号

                    partsInfoDic[dicKey].PartsInfo.AddPartsInfoRow(partsInfoRow);
                    # endregion

                    //--------------------------------------------------
                    // 商品マスタテーブルへ格納
                    //--------------------------------------------------

                    #region 商品マスタテーブルに設定
                    string partsNo = retWork.GoodsNo;
                    PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                        goodsTableDic[dicKey].FindByGoodsMakerCdGoodsNo(retWork.GoodsMakerCd, partsNo);
                    if (usrGoodsRow == null)
                    {
                        usrGoodsRow = goodsTableDic[dicKey].NewUsrGoodsInfoRow();

                        usrGoodsRow.BlGoodsCode = tbsPartsCode;
                        usrGoodsRow.GoodsKindCode = 0; // 0 : 純正
                        usrGoodsRow.GoodsKind = (int)GoodsKind.Parent; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                        usrGoodsRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrGoodsRow.GoodsMakerNm = partsInfoRow.CatalogPartsMakerNm;
                        //usrGoodsRow.GoodsMGroup = 0;
                        usrGoodsRow.GoodsRateRank = retWork.GoodsRateRank;
                        usrGoodsRow.GoodsNoNoneHyphen = partsInfoRow.ClgPrtsNoWithHyphen.Replace("-", "");
                        usrGoodsRow.QTY = retWork.PartsQty;
                        usrGoodsRow.GoodsNote1 = string.Empty;//retWork.StandardName; //規格
                        //usrGoodsRow.GoodsNote2 = "";
                        usrGoodsRow.GoodsSpecialNote = retWork.PartsOpNm;
                        usrGoodsRow.OfferDate = DateTime.MinValue; //retWork.OfferDate;

                        usrGoodsRow.OfferKubun = 0; // (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）

                        //usrGoodsRow.TaxationDivCd = 0;
                        usrGoodsRow.GoodsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                        usrGoodsRow.OfferDataDiv = 0; //1;

                        usrGoodsRow.GoodsName = retWork.GoodsName;
                        usrGoodsRow.GoodsNameKana = retWork.GoodsNameKana;
                        usrGoodsRow.GoodsOfrName = retWork.GoodsName; // 部品名
                        usrGoodsRow.GoodsOfrNameKana = retWork.GoodsNameKana;
                        usrGoodsRow.SearchPartsFullName = retWork.GoodsName;
                        usrGoodsRow.SearchPartsHalfName = retWork.GoodsNameKana;
                        usrGoodsRow.SrchPNmAcqrCarMkrCd = 0; //retWork.SrchPNmAcqrCarMkrCd;   // 検索品名取得メーカーコード
                        usrGoodsRow.PartsPriceStDate = retWork.PriceStartDate;


                        # region [提供純正/提供優良からセット]
                        if (!string.IsNullOrEmpty(retWork.GoodsNoFromGoods))
                        {
                            // ユーザー商品

                            if (retPartsInf != null)
                            {
                                // 検索品名を更新
                                usrGoodsRow.SearchPartsFullName = retPartsInf.PartsName;
                                usrGoodsRow.SearchPartsHalfName = retPartsInf.PartsNameKana;
                                usrGoodsRow.SrchPNmAcqrCarMkrCd = retPartsInf.SrchPNmAcqrCarMkrCd;
                            }
                            else if (retPrimParts != null)
                            {
                                usrGoodsRow.SearchPartsFullName = retPrimParts.SearchPartsFullName;
                                usrGoodsRow.SearchPartsHalfName = retPrimParts.SearchPartsHalfName;
                                usrGoodsRow.SrchPNmAcqrCarMkrCd = retPrimParts.JoinDestMakerCd;   // 検索品名取得メーカーコード
                            }
                        }
                        else if (retPartsInf != null)
                        {
                            // 純正
                            usrGoodsRow.GoodsNote1 = retPartsInf.StandardName; //規格
                            usrGoodsRow.OfferDate = retPartsInf.OfferDate; // 提供日
                            usrGoodsRow.SearchPartsFullName = retPartsInf.PartsName;
                            usrGoodsRow.SearchPartsHalfName = retPartsInf.PartsNameKana;
                            usrGoodsRow.SrchPNmAcqrCarMkrCd = retPartsInf.SrchPNmAcqrCarMkrCd;   // 検索品名取得メーカーコード
                            usrGoodsRow.OfferKubun = 3; // (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                        }
                        else if (retPrimParts != null)
                        {
                            // 優良
                            usrGoodsRow.OfferDate = retPrimParts.OfferDate; // 提供日
                            usrGoodsRow.SearchPartsFullName = retPrimParts.SearchPartsFullName;
                            usrGoodsRow.SearchPartsHalfName = retPrimParts.SearchPartsHalfName;
                            usrGoodsRow.SrchPNmAcqrCarMkrCd = retPrimParts.JoinDestMakerCd;   // 検索品名取得メーカーコード
                            usrGoodsRow.OfferKubun = 4; // (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                        }
                        # endregion

                        usrGoodsRow.FreSrchPrtPropNo = retWork.FreSrchPrtPropNo; // 自由検索部品固有番号

                        partsInfoRow.UsrGoodsInfoRowParentByUsrGoodsInfo_PartsInfo = usrGoodsRow;
                        goodsTableDic[dicKey].AddUsrGoodsInfoRow(usrGoodsRow);
                    }
                    # endregion

                    //--------------------------------------------------
                    // 価格テーブルへ格納
                    //--------------------------------------------------

                    # region [価格テーブルに設定]
                    if (priceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,
                        retWork.PriceStartDate, retWork.GoodsNo) == null)
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[dicKey].NewUsrGoodsPriceRow();

                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        double listPrice = retWork.ListPrice;
                        this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        usrPriceRow.ListPrice = listPrice;
                        usrPriceRow.OpenPriceDiv = retWork.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retWork.PriceStartDate;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        # region [提供純正からセット]
                        if (retPartsInf != null)
                        {
                            usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        }
                        # endregion

                        priceTableDic[dicKey].AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                    // UPD 2015/03/30 全体配信システムテスト障害№60対応 ----------------------------->>>>>
                    //if (ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,
                    //    retWork.PriceStartDate, retWork.GoodsNo) == null)
                    // 提供データが取得できる時、且つ提供データ価格情報テーブルに該当する価格情報データが存在しない時追加
                    // UPD 2015/03/31 SCM高速化 メーカー希望小売価格対応①自由検索部品価格情報対応------------->>>>>
                    //if ((retPartsInf != null) && 
                    //    (ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd, retWork.PriceStartDate, retWork.GoodsNo) == null))
                    if ((retPartsInf != null) &&
                        (ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd, retPartsInf.PartsPriceStDate, retWork.GoodsNo) == null))
                    // UPD 2015/03/31 SCM高速化 メーカー希望小売価格対応①自由検索部品価格情報対応-------------<<<<<
                    // UPD 2015/03/30 全体配信システムテスト障害№60対応 -----------------------------<<<<<
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[dicKey].NewUsrGoodsPriceRow();

                        // UPD 2015/03/30 全体配信システムテスト障害№60対応 ----------------------------->>>>>
                        #region 削除
                        //usrPriceRow.GoodsNo = retWork.GoodsNo;
                        //usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        //double listPrice = retWork.ListPrice;
                        //this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        //usrPriceRow.ListPrice = listPrice;
                        //usrPriceRow.OpenPriceDiv = retWork.OpenPriceDiv;
                        //usrPriceRow.PriceStartDate = retWork.PriceStartDate;
                        //usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        //# region [提供純正からセット]
                        //if (retPartsInf != null)
                        //{
                        //    usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        //}
                        //# endregion
                        #endregion

                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        // 提供純正からセット
                        usrPriceRow.OpenPriceDiv = retPartsInf.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retPartsInf.PartsPriceStDate;
                        double listPrice = retPartsInf.PartsPrice;
                        this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        usrPriceRow.ListPrice = listPrice;
                        usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;

                        ofrPriceTableDic[dicKey].AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                    // ADD 2015/03/31 SCM高速化 メーカー希望小売価格対応①自由検索部品価格情報対応------------->>>>>
                    // 提供優良データ、提供優良価格情報が取得できる時、且つ提供データ価格情報テーブルに該当する価格情報データが存在しない時追加
                    if ((retPrimParts != null && retPrimPrice != null) &&
                        (ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd, retPrimPrice.PriceStartDate, retWork.GoodsNo) == null))
                    {

                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[dicKey].NewUsrGoodsPriceRow();
                        
                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        // 提供優良からセット
                        usrPriceRow.OpenPriceDiv = retPrimPrice.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retPrimPrice.PriceStartDate;
                        usrPriceRow.ListPrice = retPrimPrice.NewPrice;
                        usrPriceRow.OfferDate = retPrimPrice.OfferDate;

                        ofrPriceTableDic[dicKey].AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/31 SCM高速化 メーカー希望小売価格対応①自由検索部品価格情報対応-------------<<<<<
                    # endregion

                    //--------------------------------------------------
                    // 部品関連型式情報テーブルへ格納
                    //--------------------------------------------------

                    #region 部品関連型式情報設定
                    PartsInfoDataSet.ModelPartsDetailDataTable modelInfo = partsInfoDic[dicKey].ModelPartsDetail;

                    string select = string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}' ",
                                                   carInfoDataSet.CarModelInfo.MakerCodeColumn.ColumnName, retWork.MakerCode,
                                                   carInfoDataSet.CarModelInfo.ModelCodeColumn.ColumnName, retWork.ModelCode,
                                                   carInfoDataSet.CarModelInfo.ModelSubCodeColumn.ColumnName, retWork.ModelSubCode,
                                                   carInfoDataSet.CarModelInfo.FullModelColumn.ColumnName, retWork.FullModel);

                    PMKEN01010E.CarModelInfoRow[] carModelInfoRows = (PMKEN01010E.CarModelInfoRow[])carInfoDataSet.CarModelInfo.Select(select);

                    //車輌情報→部品詳細（型式情報）設定
                    for (int ix = 0; ix < carModelInfoRows.Length; ix++)
                    {
                        PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = modelInfo.NewModelPartsDetailRow();

                        modelPartsDetailRow.PartsUniqueNo = 0;
                        modelPartsDetailRow.PartsMakerCd = retWork.GoodsMakerCd;
                        modelPartsDetailRow.PartsNo = retWork.GoodsNo;

                        modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                        modelPartsDetailRow.DoorCount = carModelInfoRows[ix].DoorCount;
                        modelPartsDetailRow.BodyName = carModelInfoRows[ix].BodyName;
                        modelPartsDetailRow.ModelGradeNm = carModelInfoRows[ix].ModelGradeNm;
                        modelPartsDetailRow.EngineModelNm = carModelInfoRows[ix].EngineModelNm;
                        modelPartsDetailRow.EngineDisplaceNm = carModelInfoRows[ix].EngineDisplaceNm;
                        modelPartsDetailRow.EDivNm = carModelInfoRows[ix].EDivNm;
                        modelPartsDetailRow.TransmissionNm = carModelInfoRows[ix].TransmissionNm;
                        modelPartsDetailRow.ShiftNm = carModelInfoRows[ix].ShiftNm;
                        modelPartsDetailRow.WheelDriveMethodNm = carModelInfoRows[ix].WheelDriveMethodNm;
                        modelPartsDetailRow.AddiCarSpec1 = carModelInfoRows[ix].AddiCarSpec1;
                        modelPartsDetailRow.AddiCarSpec2 = carModelInfoRows[ix].AddiCarSpec2;
                        modelPartsDetailRow.AddiCarSpec3 = carModelInfoRows[ix].AddiCarSpec3;
                        modelPartsDetailRow.AddiCarSpec4 = carModelInfoRows[ix].AddiCarSpec4;
                        modelPartsDetailRow.AddiCarSpec5 = carModelInfoRows[ix].AddiCarSpec5;
                        modelPartsDetailRow.AddiCarSpec6 = carModelInfoRows[ix].AddiCarSpec6;

                        modelInfo.AddModelPartsDetailRow(modelPartsDetailRow);
                    }
                    if (carModelInfoRows.Length > 0)
                    {
                        modelInfo.Columns[modelInfo.AddiCarSpec1Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle1;
                        modelInfo.Columns[modelInfo.AddiCarSpec2Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle2;
                        modelInfo.Columns[modelInfo.AddiCarSpec3Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle3;
                        modelInfo.Columns[modelInfo.AddiCarSpec4Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle4;
                        modelInfo.Columns[modelInfo.AddiCarSpec5Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle5;
                        modelInfo.Columns[modelInfo.AddiCarSpec6Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle6;
                    }
                    #endregion
                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 代替情報によるデータテーブル更新処理
        /// </summary>
        /// <param name="list"></param>
        private void ReflectTableByPartsSubst( ArrayList list )
        {
            foreach ( PartsSubstWork wkInf in list )
            {
                // 代替元レコード（更新対象）
                PartsInfoDataSet.PartsInfoRow row = partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen );

                if ( row != null )
                {
                    // 代替先品番を書き換える
                    row.NewPrtsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                    row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                }
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 代替情報によるデータテーブル更新処理
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void ReflectTableByPartsSubst(ArrayList list, int key)
        {
            foreach (PartsSubstWork wkInf in list)
            {
                // 代替元レコード（更新対象）
                PartsInfoDataSet.PartsInfoRow row = partsInfoDic[key].PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen);

                if (row != null)
                {
                    // 代替先品番を書き換える
                    row.NewPrtsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                    row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 自由検索部品検索結果ディクショナリ用キー生成処理
        /// </summary>
        /// <param name="makerCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        private string CreateFreeSearchRetDicKey( int makerCode, string goodsNo )
        {
            // ※構造体等を使うと低速なので、文字列でキーとする。
            //   自由検索部品から提供部品or商品マスタへの結び付けは品番・ﾒｰｶｰｺｰﾄﾞのみ。
            return makerCode.ToString( "0000" ) + "," + goodsNo.TrimEnd();
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 自由検索部品検索結果ディクショナリ用キー生成処理
        /// </summary>
        /// <param name="key"></param>
        /// <param name="makerCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        private string CreateFreeSearchRetDicKey(int key, int makerCode, string goodsNo)
        {
            // ※構造体等を使うと低速なので、文字列でキーとする。
            //   自由検索部品から提供部品or商品マスタへの結び付けは検索key・品番・ﾒｰｶｰｺｰﾄﾞのみ。
            return key.ToString("00") + makerCode.ToString("0000") + "," + goodsNo.TrimEnd();
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="retObj"></param>
        /// <returns></returns>
        private ArrayList GetRetList( object retObj )
        {
            ArrayList result = null;

            try
            {
                if ( retObj != null )
                {
                    CustomSerializeArrayList retCustList = (retObj as CustomSerializeArrayList);

                    if ( retCustList.Count != 0 )
                    {
                        result = (ArrayList)retCustList[0];
                    }
                }
            }
            catch
            {
            }

            return result;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  配列取得
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="listIndex"></param>
        /// <returns></returns>
        private ArrayList GetRetList(object retObj, int listIndex)
        {
            ArrayList result = null;

            try
            {
                if (retObj != null)
                {
                    CustomSerializeArrayList retCustList = (retObj as CustomSerializeArrayList);

                    if (retCustList.Count != 0)
                    {
                        result = (ArrayList)retCustList[listIndex];
                    }
                }
            }
            catch
            {
            }

            return result;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 価格取得処理
        /// </summary>
        /// <param name="priceList"></param>
        /// <returns></returns>
        /// <remarks>価格リストから該当１件を抽出する</remarks>
        private OfferJoinPriceRetWork GetPrimePrice( List<OfferJoinPriceRetWork> priceList )
        {
            // 日付降順でソート
            priceList.Sort( new OfferJoinPriceRetWorkDescComparer() );

            if ( priceList.Count > 0 )
            {
                // 先頭１件を返す
                return priceList[0];
            }

            return null;
        }

        /// <summary>
        /// 提供結合価格　比較クラス（降順ソート用）
        /// </summary>
        private class OfferJoinPriceRetWorkDescComparer : Comparer<OfferJoinPriceRetWork>
        {
            /// <summary>
            /// 提供結合価格　比較処理
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare( OfferJoinPriceRetWork x, OfferJoinPriceRetWork y )
            {
                return y.PriceStartDate.CompareTo( x.PriceStartDate );
            }
        }

        /// <summary>
        /// 日付からyyyymm取得
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int GetLongDateYM( DateTime dateTime )
        {
            if ( dateTime != DateTime.MinValue )
            {
                // YYYYMM
                return (dateTime.Year * 100) + (dateTime.Month);
            }
            else
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        
        // 2009/11/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 結合元検索
        ///// </summary>
        ///// <param name="enterpriseCd">企業コード</param>
        ///// <param name="makerCd">優良部品メーカーコード</param>
        ///// <param name="partsNo">優良部品品番</param>
        ///// <param name="retPartsInfo">部品検索結果</param>
        ///// <returns></returns>
        //public int GetJoinSrcParts(string enterpriseCd, int makerCd, string partsNo, out PartsInfoDataSet retPartsInfo)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    partsInfo.Clear();
        //    carInfoDataSet = null;
        //    customerCarInfo = null;

        //    status = GetJoinSrcPartsProc(enterpriseCd, makerCd, partsNo);

        //    SetUsrGoodsKind();
        //    partsInfo.AcceptChanges();
        //    retPartsInfo = partsInfo;
        //    return status;
        //}

        /// <summary>
        /// 結合元検索
        /// </summary>
        /// <param name="enterpriseCd">企業コード</param>
        /// <param name="makerCd">優良部品メーカーコード</param>
        /// <param name="partsNo">優良部品品番</param>
        /// <param name="retPartsInfo">部品検索結果</param>
        /// <returns></returns>
        public int GetJoinSrcParts(string enterpriseCd, int makerCd, string partsNo, out PartsInfoDataSet retPartsInfo)
        {
            return GetJoinSrcParts(0, enterpriseCd, makerCd, partsNo, out retPartsInfo);
        }

        /// <summary>
        /// 結合元検索
        /// </summary>
        /// <param name="mode">モード(0:提供価格取得無し 1:提供価格取得有り)</param>
        /// <param name="enterpriseCd">企業コード</param>
        /// <param name="makerCd">優良部品メーカーコード</param>
        /// <param name="partsNo">優良部品品番</param>
        /// <param name="retPartsInfo">部品検索結果</param>
        /// <returns></returns>
        public int GetJoinSrcParts(int mode, string enterpriseCd, int makerCd, string partsNo, out PartsInfoDataSet retPartsInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            partsInfo.Clear();
            carInfoDataSet = null;
            customerCarInfo = null;

            status = GetJoinSrcPartsProc(mode, enterpriseCd, makerCd, partsNo);

            SetUsrGoodsKind();
            partsInfo.AcceptChanges();
            retPartsInfo = partsInfo;
            return status;
        }
        // 2009/11/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 商品一括登録検索
        /// </summary>
        /// <param name="makerCd">メーカーコード（必須）</param>
        /// <param name="partsNo">品番(BLか品番か何れか必須)</param>
        /// <param name="bl">BLコード(BLか品番か何れか必須)</param>
        /// <param name="maxCnt">取得件数</param>
        /// <param name="sectionCode">拠点コード(優良設定用)</param>
        /// <param name="prmSettingUWorkList">優良設定リスト</param>
        /// <param name="retPartsInfo"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
        //public int SearchOfrParts(int makerCd, string partsNo, int bl, int maxCnt, out PartsInfoDataSet retPartsInfo)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
        public int SearchOfrParts( int makerCd, string partsNo, int bl, int maxCnt, string sectionCode, List<PrmSettingUWork> prmSettingUWorkList, out PartsInfoDataSet retPartsInfo )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            partsInfo.Clear();
            carInfoDataSet = null;
            customerCarInfo = null;

            PrtsSrchCndWork InPara = new PrtsSrchCndWork();
            InPara.MakerCode = makerCd;
            InPara.BLCode = bl;
            InPara.PrtsNo = partsNo;
            InPara.MaxCnt = maxCnt;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
            //status = SearchOfrPartsProc(InPara);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            status = SearchOfrPartsProc( InPara, sectionCode, prmSettingUWorkList );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            partsInfo.AcceptChanges();
            retPartsInfo = partsInfo;
            return status;
        }
        # endregion

        # region [ 1. ＢＬ検索メイン ]
        /// <summary>
        /// ＢＬ検索メイン
        /// </summary>
        /// <param name="partsSearchUIData">検索条件</param>
        /// <param name="normalSearchExclude"></param>
        /// <returns></returns>
        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
        //private int BlSearchMain(PartsSearchUIData partsSearchUIData)
        private int BlSearchMain( PartsSearchUIData partsSearchUIData, bool normalSearchExclude )
        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
        {
            //>>>2010/03/29
            #region 大型検索判定
            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            //// 大型契約なしで指定のメーカーが大型の場合は検索せず、0件とする。
            //if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            //{
            //    if (customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(customerCarInfo[0].MakerCode))
            //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}

            bool blSearchFlag = true;

            // 大型契約なしで指定のメーカーが大型の場合は検索せず、0件とする。
            if ( (customerCarInfo != null) && (customerCarInfo.Count != 0) )
            {
                if ( customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains( customerCarInfo[0].MakerCode ) )
                {
                    if ( _freeSearchPartsSRetDic == null || _freeSearchPartsSRetDic.Count == 0 )
                    {
                        // 自由検索も該当無ければ、ここで終了
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else
                    {
                        // 自由検索は該当があり純正ＢＬは該当無扱いする
                        blSearchFlag = false;
                    }
                }
            }
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<            
            #endregion
            //<<<2010/03/29

            # region 変数の初期化
            int status = 0;

            GetPartsInfPara para = new GetPartsInfPara();
            # endregion

            // --- ADD m.suzuki 2010/04/28 ---------->>>>>
            if ( !blSearchFlag || normalSearchExclude )
            {
                para.NormalSearchExclude = true; // 通常のＢＬ検索を行わない
            }
            // --- ADD m.suzuki 2010/04/28 ----------<<<<<


            # region [ 純正・代替 ] ＢＬコード検索
            //ＢＬコード設定
            para.TbsPartsCode = partsSearchUIData.TbsPartsCode;

            //フル型式固定番号
            // UPD 2013/02/14 SCM障害№10354対応 2013/03/06配信--------------------------------------------------->>>>>
            //para.FullModelFixedNo = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true);
            // UPD 2013/02/22 2013/03/13配信 システムテスト障害№121対応 ----------------------------->>>>>
            //para.FullModelFixedNo = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, carInfoDataSet.CarModelUIData[0].FrameNo, carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput);

            string frameNo = "";
            int produceTypeOfYearInput = 0;

            if (carInfoDataSet != null && carInfoDataSet.CarModelUIData.Count != 0)
            {
                frameNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                produceTypeOfYearInput = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
            }
            para.FullModelFixedNo = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, frameNo, produceTypeOfYearInput);
            // UPD 2013/02/22 2013/03/13配信 システムテスト障害№121対応 -----------------------------<<<<<
            // UPD 2013/02/14 SCM障害№10354対応 ---------------------------------------------------<<<<<

            //類別番号
            para.CategoryNo = carInfoDataSet.CarModelUIData[0].CategoryNo;
            //型式指定番号
            para.ModelDesignationNo = carInfoDataSet.CarModelUIData[0].ModelDesignationNo;
            //メーカーコード
            para.MakerCode = customerCarInfo[0].MakerCode;
            //車種コード
            para.ModelCode = customerCarInfo[0].ModelCode;
            //車種サブコード
            para.ModelSubCode = customerCarInfo[0].ModelSubCode;

            if (carInfoDataSet.CarModelUIData.Count > 0)
            {
                // 2009.01.28 >>>
                //if (carInfoDataSet.CarModelUIData[0].ProduceFrameNoInput > 0)
                //    para.ChassisNo = carInfoDataSet.CarModelUIData[0].ProduceFrameNoInput.ToString();
                if (carInfoDataSet.CarModelUIData[0].SearchFrameNo > 0)
                    para.ChassisNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                // 2009.01.28 <<<
                if (carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput > 0)
                    para.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
            }

            para.SearchType = (int)partsSearchUIData.SearchType;
            if (partsSearchUIData.SearchCntSetWork.SubstCondDivCd == 0) // 代替なし
                para.NoSubst = 1;
            else                                                        // 代替する（在庫あり・在庫無視）
                para.NoSubst = 0;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 ADD
            para.PriceDate = partsSearchUIData.PriceDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 ADD
            // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            para.TbsPartsCdDerivedNo = partsSearchUIData.TbsPartsCdDerivedNo; // BLコード枝番
            // --- ADD m.suzuki 2011/05/18 ----------<<<<<

            // --- ADD 2013/03/27 ---------->>>>>
            // 画面のVIN文字列とメーカコードに応じて部品絞込条件を追加
            AddPartsNarrowingInfoFromVinCode(ref para);
            // --- ADD 2013/03/27 ----------<<<<<

            //純正検索 [ ＢＬコード検索リモート処理 ]
            status = GetCatalogPartsInf(para);

            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            //if ( status != 0 )
            //{
            //    return (status);
            //}

            _normalSearchStatus = status;

            // 自由検索部品検索も純正ＢＬも該当が無ければここで終了
            if ( _freeSearchPartsSRetDic == null || _freeSearchPartsSRetDic.Count == 0 )
            {
                if ( status != 0 )
                {
                    return (status);
                }
            }
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<
            # endregion

            # region [ 結合・セット ] 優良部品検索処理＜純正品番をＫＥＹにして優良品番を検索＞
            bool primeSubstFlg = true;
            //if (partsSearchUIData.SearchCntSetWork.PrmSubstCondDivCd != 0) // 優良代替なしは最新品番にするため、代替取得必要
            //    primeSubstFlg = true;
            // --- UPD m.suzuki 2011/05/18 ---------->>>>>
            //status = GetPrimePartsInf( primeSubstFlg );
            status = GetPrimePartsInf( primeSubstFlg, para );
            // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            if (status != 0)
            {
                return (status);
            }
            # endregion

            #region [ ユーザー結合 ]
            //ユーザー結合検索
            // --- UPD m.suzuki 2011/05/18 ---------->>>>>
            //status = GetUsrGoodsJoinInf(partsSearchUIData);
            status = GetUsrGoodsJoinInf( partsSearchUIData, para );
            // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            #endregion

            #region [ ユーザーOEM対応 ]
            if (partsSearchUIData.SearchCntSetWork.SubstApplyDivCd == 2) // 代替適用全て：ユーザー登録品に関して更に提供検索
            {
                status = UserOEMSearch(partsSearchUIData);
            }
            #endregion

            // --- ADD 2012/12/10 Y.Wakita ---------->>>>>
            #region [ ユーザー結合 ]
            // 提供データも含め、もう一度作成
            status = GetUsrGoodsJoinInf(partsSearchUIData, para);
            #endregion
            // --- ADD 2012/12/10 Y.Wakita ----------<<<<<

            if (partsInfo.UsrGoodsInfo.Count == 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            return (status);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ＢＬ検索メイン
        /// </summary>
        /// <param name="partsSearchUIDataDic">検索条件</param>
        /// <param name="normalSearchExclude"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2018/04/05  30757 佐々木　貴英</br>
        /// <br>管理番号    : 11470007-00</br>
        /// <br>            : NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>              検索条件へのBL統一部品コードの追加</br>
        /// </remarks>
        private int BlSearchMain( Dictionary<int, PartsSearchUIData> partsSearchUIDataDic, bool normalSearchExclude )
        {
            #region 大型検索判定

            bool blSearchFlag = true;

            // 大型契約なしで指定のメーカーが大型の場合は検索せず、0件とする。
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(customerCarInfo[0].MakerCode))
                {
                    if (_freeSearchPartsSRetDic == null || _freeSearchPartsSRetDic.Count == 0)
                    {
                        // 自由検索も該当無ければ、ここで終了
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else
                    {
                        // 自由検索は該当があり純正ＢＬは該当無扱いする
                        blSearchFlag = false;
                    }
                }
            }
            #endregion

            # region 変数の初期化
            int status = 0;
            Dictionary<int, GetPartsInfPara> paraDic = new Dictionary<int, GetPartsInfPara>();
            # endregion


            foreach (int key in partsSearchUIDataDic.Keys)
            {
                GetPartsInfPara para = new GetPartsInfPara();
                if (!blSearchFlag || normalSearchExclude)
                {
                    para.NormalSearchExclude = true; // 通常のＢＬ検索を行わない
                }

            # region [ 純正・代替 ] ＢＬコード検索

                //フル型式固定番号
                string frameNo = "";
                int produceTypeOfYearInput = 0;

                if (carInfoDataSet != null && carInfoDataSet.CarModelUIData.Count != 0)
                {
                    frameNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                    produceTypeOfYearInput = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                    //類別番号
                    para.CategoryNo = carInfoDataSet.CarModelUIData[0].CategoryNo;
                    //型式指定番号
                    para.ModelDesignationNo = carInfoDataSet.CarModelUIData[0].ModelDesignationNo;
                }
                para.FullModelFixedNo = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, frameNo, produceTypeOfYearInput);

                if (customerCarInfo != null && customerCarInfo.Count != 0)
                {
                    //メーカーコード
                    para.MakerCode = customerCarInfo[0].MakerCode;
                    //車種コード
                    para.ModelCode = customerCarInfo[0].ModelCode;
                    //車種サブコード
                    para.ModelSubCode = customerCarInfo[0].ModelSubCode;
                }

                if (carInfoDataSet.CarModelUIData.Count > 0)
                {
                    if (carInfoDataSet.CarModelUIData[0].SearchFrameNo > 0)
                        para.ChassisNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                    if (carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput > 0)
                        para.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                }

                //ＢＬコード設定
                para.TbsPartsCode = partsSearchUIDataDic[key].TbsPartsCode;

                para.SearchType = (int)partsSearchUIDataDic[key].SearchType;
                if (partsSearchUIDataDic[key].SearchCntSetWork.SubstCondDivCd == 0) // 代替なし
                    para.NoSubst = 1;
                else                                                        // 代替する（在庫あり・在庫無視）
                    para.NoSubst = 0;

                para.PriceDate = partsSearchUIDataDic[key].PriceDate;
                para.TbsPartsCdDerivedNo = partsSearchUIDataDic[key].TbsPartsCdDerivedNo; // BLコード枝番

                // 画面のVIN文字列とメーカコードに応じて部品絞込条件を追加
                AddPartsNarrowingInfoFromVinCode(ref para);

                // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
                // BL統一部品コード(スリーコード版)の設定
                para.BlUtyPtThCd = partsSearchUIDataDic[key].BlUtyPtThCd;
                // BL統一部品サブコードの設定
                para.BlUtyPtSbCd = partsSearchUIDataDic[key].BlUtyPtSbCd;
                // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

                paraDic.Add(key, para);
            }

            //純正検索 [ ＢＬコード検索リモート処理 ]
            status = GetCatalogPartsInf(paraDic);

            _normalSearchStatus = status;

            // 自由検索部品検索も純正ＢＬも該当が無ければここで終了
            if (_freeSearchPartsSRetDic == null || _freeSearchPartsSRetDic.Count == 0)
            {
                if (status != 0)
                {
                    return (status);
                }
            }

            # endregion

            # region [ 結合・セット ] 優良部品検索処理＜純正品番をＫＥＹにして優良品番を検索＞

            bool primeSubstFlg = true;

            status = GetPrimePartsInf(primeSubstFlg, paraDic);
            if (status != 0)
            {
                return (status);
            }
            # endregion

            #region [ ユーザー結合 ]
            //ユーザー結合検索
            status = GetUsrGoodsJoinInf(partsSearchUIDataDic, paraDic);
            #endregion

            #region [ ユーザーOEM対応 ]
            status = UserOEMSearch(partsSearchUIDataDic);
            #endregion

            #region [ ユーザー結合 ]
            // 提供データも含め、もう一度作成
            status = GetUsrGoodsJoinInf(partsSearchUIDataDic, paraDic);
            #endregion

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            foreach (PartsInfoDataSet partsInfo in partsInfoDic.Values)
            {
                if (partsInfo.UsrGoodsInfo.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            return (status);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region [ 2. 優良ＢＬ検索メイン ]
        /// <summary>
        /// 優良ＢＬ検索メイン
        /// </summary>
        /// <param name="partsSearchUIData">検索条件</param>
        /// <returns></returns>
        private int PrimeBlSearchMain(PartsSearchUIData partsSearchUIData)
        {
            //>>>2010/03/29
            // 大型契約なしで指定のメーカーが大型の場合は検索せず、0件とする。
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(customerCarInfo[0].MakerCode))
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            //<<<2010/03/29

            int status = 0;
            ArrayList RetParts;
            ArrayList retPartsPrice;
            ArrayList RetSetParts;
            ArrayList RetSetPartsPrice;

            OfferPrimeBlSearchCondWork para = new OfferPrimeBlSearchCondWork();

            //ＢＬコード設定
            para.TbsPartsCode = partsSearchUIData.TbsPartsCode;
            // オリジナル部品検索にはフル型式固定番号での検索が出来ないため、
            // 持っている車の情報を出来るかぎり使って検索する。
            if (customerCarInfo != null && customerCarInfo.Count > 0)
            {
                para.MakerCode = customerCarInfo[0].MakerCode;
                para.ModelCode = customerCarInfo[0].ModelCode;
                para.ModelSubCode = customerCarInfo[0].ModelSubCode;
                para.SeriesModel = customerCarInfo[0].SeriesModel;
                if (carInfoDataSet.CarModelUIData.Count > 0)
                {
                    // 2009.01.28 >>>
                    //para.ProduceFrameNo = carInfoDataSet.CarModelUIData[0].ProduceFrameNoInput;
                    para.ProduceFrameNo = carInfoDataSet.CarModelUIData[0].SearchFrameNo;
                    // 2009.01.28 <<<
                    para.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                }
                // [絞込用] 型式年式圧縮処理
                for (int i = 0; i < carInfoDataSet.CarModelInfo.Count; i++)
                {
                    if (para.CategorySignModel.Contains(carInfoDataSet.CarModelInfo[i].CategorySignModel) == false)
                        para.CategorySignModel.Add(carInfoDataSet.CarModelInfo[i].CategorySignModel);

                    //if (carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear != 0
                    //    && carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear != 999999)
                    //{
                    //    bool flg = false;
                    //    for (int j = 0; j < para.StProduceTypeOfYear.Count; j++)
                    //    {
                    //        if (carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear > para.EdProduceTypeOfYear[j]
                    //             || carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear < para.StProduceTypeOfYear[j])
                    //            continue; // 既存範囲外
                    //        if (carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear >= para.StProduceTypeOfYear[j]) 
                    //        { // 年式範囲が重なる部分があって、
                    //            if (carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear > para.EdProduceTypeOfYear[j])
                    //            { // 終了部分が出っ張る場合既存範囲を伸ばす。
                    //                para.EdProduceTypeOfYear[j] = carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear;
                    //            }
                    //            flg = true;
                    //            break;
                    //        }
                    //        if (carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear <= para.EdProduceTypeOfYear[j])
                    //        {
                    //            if (carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear < para.StProduceTypeOfYear[j])
                    //            {
                    //                para.StProduceTypeOfYear[j] = carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear;
                    //            }
                    //            flg = true;
                    //            break;
                    //        }
                    //    }
                    //    if (flg == false) // 既存範囲で圧縮できない年式範囲は新たに追加する
                    //    {
                    //        para.StProduceTypeOfYear.Add(carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear);
                    //        para.EdProduceTypeOfYear.Add(carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear);
                    //    }
                    //}

                    //if (carInfoDataSet.CarModelInfo[i].StProduceFrameNo != 0
                    //    && carInfoDataSet.CarModelInfo[i].EdProduceFrameNo != 99999999)
                    //{
                    //    bool flg = false;
                    //    for (int j = 0; j < para.StProduceFrameNo.Count; j++)
                    //    {
                    //        if (carInfoDataSet.CarModelInfo[i].StProduceFrameNo > para.EdProduceFrameNo[j]
                    //             || carInfoDataSet.CarModelInfo[i].EdProduceFrameNo < para.StProduceFrameNo[j])
                    //            continue; // 既存範囲外
                    //        if (carInfoDataSet.CarModelInfo[i].StProduceFrameNo >= para.StProduceFrameNo[j])
                    //        { // 車台番号範囲が重なる部分があって、
                    //            if (carInfoDataSet.CarModelInfo[i].EdProduceFrameNo > para.EdProduceFrameNo[j])
                    //            { // 終了部分が出っ張る場合既存範囲を伸ばす。
                    //                para.EdProduceFrameNo[j] = carInfoDataSet.CarModelInfo[i].EdProduceFrameNo;
                    //            }
                    //            flg = true;
                    //            break;
                    //        }
                    //        if (carInfoDataSet.CarModelInfo[i].EdProduceFrameNo <= para.EdProduceFrameNo[j])
                    //        {
                    //            if (carInfoDataSet.CarModelInfo[i].StProduceFrameNo < para.StProduceFrameNo[j])
                    //            {
                    //                para.StProduceFrameNo[j] = carInfoDataSet.CarModelInfo[i].StProduceFrameNo;
                    //            }
                    //            flg = true;
                    //            break;
                    //        }
                    //    }
                    //    if (flg == false) // 既存範囲で圧縮できない車台番号範囲は新たに追加する
                    //    {
                    //        para.StProduceFrameNo.Add(carInfoDataSet.CarModelInfo[i].StProduceFrameNo);
                    //        para.EdProduceFrameNo.Add(carInfoDataSet.CarModelInfo[i].EdProduceFrameNo);
                    //    }
                    //}

                    if (para.ModelGradeNm.Contains(carInfoDataSet.CarModelInfo[i].ModelGradeNm) == false)
                        para.ModelGradeNm.Add(carInfoDataSet.CarModelInfo[i].ModelGradeNm);

                    if (para.BodyName.Contains(carInfoDataSet.CarModelInfo[i].BodyName) == false)
                        para.BodyName.Add(carInfoDataSet.CarModelInfo[i].BodyName);

                    if (para.DoorCount.Contains(carInfoDataSet.CarModelInfo[i].DoorCount) == false)
                        para.DoorCount.Add(carInfoDataSet.CarModelInfo[i].DoorCount);

                    if (para.EDivNm.Contains(carInfoDataSet.CarModelInfo[i].EDivNm) == false)
                        para.EDivNm.Add(carInfoDataSet.CarModelInfo[i].EDivNm);

                    if (para.EngineDisplaceNm.Contains(carInfoDataSet.CarModelInfo[i].EngineDisplaceNm) == false)
                        para.EngineDisplaceNm.Add(carInfoDataSet.CarModelInfo[i].EngineDisplaceNm);

                    if (para.EngineModelNm.Contains(carInfoDataSet.CarModelInfo[i].EngineModelNm) == false)
                        para.EngineModelNm.Add(carInfoDataSet.CarModelInfo[i].EngineModelNm);

                    if (para.ShiftNm.Contains(carInfoDataSet.CarModelInfo[i].ShiftNm) == false)
                        para.ShiftNm.Add(carInfoDataSet.CarModelInfo[i].ShiftNm);

                    if (para.TransmissionNm.Contains(carInfoDataSet.CarModelInfo[i].TransmissionNm) == false)
                        para.TransmissionNm.Add(carInfoDataSet.CarModelInfo[i].TransmissionNm);

                    if (para.WheelDriveMethodNm.Contains(carInfoDataSet.CarModelInfo[i].WheelDriveMethodNm) == false)
                        para.WheelDriveMethodNm.Add(carInfoDataSet.CarModelInfo[i].WheelDriveMethodNm);
                }
            }

            //優良ＢＬコード検索リモート処理
            iOfferPrimeBlSearchDB = MediationOfferPrimeBlSearchDB.GetOfferPrimeBlSearchDB();
            // オリジナル部品（特殊車両部品、特殊優良部品）検索
            status = iOfferPrimeBlSearchDB.Search(para, out RetParts, out retPartsPrice, out RetSetParts, out RetSetPartsPrice);

            if (status != 0)
            {
                return (status);
            }

            //部品情報設定
            FillOfrPrimePartsTable(RetParts, retPartsPrice);
            // 2009/10/19 Add >>>
            // データが存在しても優良設定によって該当なしになるパターンがある為、データセットにセット後にステータス変更
            if (partsInfo.UsrGoodsInfo.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // 2009/10/19 Add <<<
            FillOfrSetInfo(RetSetParts, RetSetPartsPrice);

            //ユーザー結合検索
            // --- UPD m.suzuki 2011/05/18 ---------->>>>>
            //status = GetUsrGoodsJoinInf(partsSearchUIData);
            status = GetUsrGoodsJoinInf( partsSearchUIData, null );
            // --- UPD m.suzuki 2011/05/18 ----------<<<<<

            if (status != 0)
            {
                return (status);
            }

            //UI用：部品詳細（型式情報）設定
            ListPrimePartsDetail_Tables(RetParts);

            return (status);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 優良ＢＬ検索メイン
        /// </summary>
        /// <param name="partsSearchUIDataDic">検索条件</param>
        /// <returns></returns>
        private int PrimeBlSearchMain(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            // 大型契約なしで指定のメーカーが大型の場合は検索せず、0件とする。
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(customerCarInfo[0].MakerCode))
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            int status = 0;
            ArrayList RetParts;
            ArrayList retPartsPrice;
            ArrayList RetSetParts;
            ArrayList RetSetPartsPrice;

            foreach (int key in partsSearchUIDataDic.Keys)
            {

                OfferPrimeBlSearchCondWork para = new OfferPrimeBlSearchCondWork();

                //ＢＬコード設定
                para.TbsPartsCode = partsSearchUIDataDic[key].TbsPartsCode;
                // オリジナル部品検索にはフル型式固定番号での検索が出来ないため、
                // 持っている車の情報を出来るかぎり使って検索する。
                if (customerCarInfo != null && customerCarInfo.Count > 0)
                {
                    para.MakerCode = customerCarInfo[0].MakerCode;
                    para.ModelCode = customerCarInfo[0].ModelCode;
                    para.ModelSubCode = customerCarInfo[0].ModelSubCode;
                    para.SeriesModel = customerCarInfo[0].SeriesModel;
                    if (carInfoDataSet.CarModelUIData.Count > 0)
                    {
                        para.ProduceFrameNo = carInfoDataSet.CarModelUIData[0].SearchFrameNo;
                        para.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                    }
                    // [絞込用] 型式年式圧縮処理
                    for (int i = 0; i < carInfoDataSet.CarModelInfo.Count; i++)
                    {
                        if (para.CategorySignModel.Contains(carInfoDataSet.CarModelInfo[i].CategorySignModel) == false)
                            para.CategorySignModel.Add(carInfoDataSet.CarModelInfo[i].CategorySignModel);

                        if (para.ModelGradeNm.Contains(carInfoDataSet.CarModelInfo[i].ModelGradeNm) == false)
                            para.ModelGradeNm.Add(carInfoDataSet.CarModelInfo[i].ModelGradeNm);

                        if (para.BodyName.Contains(carInfoDataSet.CarModelInfo[i].BodyName) == false)
                            para.BodyName.Add(carInfoDataSet.CarModelInfo[i].BodyName);

                        if (para.DoorCount.Contains(carInfoDataSet.CarModelInfo[i].DoorCount) == false)
                            para.DoorCount.Add(carInfoDataSet.CarModelInfo[i].DoorCount);

                        if (para.EDivNm.Contains(carInfoDataSet.CarModelInfo[i].EDivNm) == false)
                            para.EDivNm.Add(carInfoDataSet.CarModelInfo[i].EDivNm);

                        if (para.EngineDisplaceNm.Contains(carInfoDataSet.CarModelInfo[i].EngineDisplaceNm) == false)
                            para.EngineDisplaceNm.Add(carInfoDataSet.CarModelInfo[i].EngineDisplaceNm);

                        if (para.EngineModelNm.Contains(carInfoDataSet.CarModelInfo[i].EngineModelNm) == false)
                            para.EngineModelNm.Add(carInfoDataSet.CarModelInfo[i].EngineModelNm);

                        if (para.ShiftNm.Contains(carInfoDataSet.CarModelInfo[i].ShiftNm) == false)
                            para.ShiftNm.Add(carInfoDataSet.CarModelInfo[i].ShiftNm);

                        if (para.TransmissionNm.Contains(carInfoDataSet.CarModelInfo[i].TransmissionNm) == false)
                            para.TransmissionNm.Add(carInfoDataSet.CarModelInfo[i].TransmissionNm);

                        if (para.WheelDriveMethodNm.Contains(carInfoDataSet.CarModelInfo[i].WheelDriveMethodNm) == false)
                            para.WheelDriveMethodNm.Add(carInfoDataSet.CarModelInfo[i].WheelDriveMethodNm);
                    }
                }

                //優良ＢＬコード検索リモート処理
                iOfferPrimeBlSearchDB = MediationOfferPrimeBlSearchDB.GetOfferPrimeBlSearchDB();
                // オリジナル部品（特殊車両部品、特殊優良部品）検索
                status = iOfferPrimeBlSearchDB.Search(para, out RetParts, out retPartsPrice, out RetSetParts, out RetSetPartsPrice);

                if (status != 0)
                {
                    continue;
                }

                //部品情報設定
                FillOfrPrimePartsTable(RetParts, retPartsPrice, key);
                // データが存在しても優良設定によって該当なしになるパターンがある為、データセットにセット後にステータス変更
                if (partsInfoDic[key].UsrGoodsInfo.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                FillOfrSetInfo(RetSetParts, RetSetPartsPrice, key);

            }

            //ユーザー結合検索
            status = GetUsrGoodsJoinInf(partsSearchUIDataDic, null);

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            foreach (PartsInfoDataSet partsInfo in partsInfoDic.Values)
            {
                if (partsInfo.UsrGoodsInfo.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return (status);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        #region [ 3. TBO検索 ]
        /// <summary>
        /// ＴＢＯ検索メイン
        /// </summary>
        /// <param name="partsSearchUIData">検索条件</param>
        /// <returns></returns>
        private int TBOSearchMain(PartsSearchUIData partsSearchUIData)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 DEL
            //int status = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 ADD
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 ADD

            #region [ TBO検索 ]　提供車輌情報結合検索リモート処理
            //　[ TBO検索 ]　提供車輌情報結合検索リモート処理
            string filter = string.Format("{0} = {1}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, partsSearchUIData.TbsPartsCode);
            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);

            if (rows.Length > 0)
            {
                int equipGenreCode = rows[0].EquipGenreCode;

                filter = String.Format("{0} = {1}", carInfoDataSet.CategoryEquipmentInfo.TbsPartsCodeColumn.ColumnName,
                        partsSearchUIData.TbsPartsCode);
                PMKEN01010E.CategoryEquipmentInfoRow[] cEIrows =
                    (PMKEN01010E.CategoryEquipmentInfoRow[])carInfoDataSet.CategoryEquipmentInfo.Select(filter);

                int tbl_idx = cEIrows.Length;
                if (tbl_idx > 0)
                {
                    List<string> list = new List<string>();

                    for (int i = 0; i < tbl_idx; i++)
                    {
                        if (list.Contains(cEIrows[i].EquipmentName) == false)
                            list.Add(cEIrows[i].EquipmentName);
                    }

                    status = GetOfrTBOInfo(partsSearchUIData, equipGenreCode, list.ToArray());
                    //status = GetUsrGoodsJoinInf(partsSearchUIData);

                }
            }
            return status;
            #endregion
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ＴＢＯ検索メイン
        /// </summary>
        /// <param name="partsSearchUIDataDic">検索条件</param>
        /// <returns></returns>
        private int TBOSearchMain(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<string[]> ofrTBOList = new List<string[]>();
            List<string> list = new List<string>();
            List<int> equipGenreCodeList = new List<int>();
            
            #region [ TBO検索 ]　提供車輌情報結合検索リモート処理

            foreach (PartsSearchUIData partsSearchUIData in partsSearchUIDataDic.Values)
            {
                string filter = string.Format("{0} = {1}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, partsSearchUIData.TbsPartsCode);
                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);

                if (rows.Length > 0)
                {
                    equipGenreCodeList.Add(rows[0].EquipGenreCode);
                                        
                    filter = String.Format("{0} = {1}", carInfoDataSet.CategoryEquipmentInfo.TbsPartsCodeColumn.ColumnName,
                            partsSearchUIData.TbsPartsCode);
                    PMKEN01010E.CategoryEquipmentInfoRow[] cEIrows =
                        (PMKEN01010E.CategoryEquipmentInfoRow[])carInfoDataSet.CategoryEquipmentInfo.Select(filter);

                    int tbl_idx = cEIrows.Length;
                    if (tbl_idx > 0)
                    {
                        list.Clear();
                        for (int i = 0; i < tbl_idx; i++)
                        {
                            if (list.Contains(cEIrows[i].EquipmentName) == false)
                                list.Add(cEIrows[i].EquipmentName);
                        }
                        ofrTBOList.Add(list.ToArray());
                    }
                    else
                    {
                        ofrTBOList.Add(new List<string>().ToArray());
                    }
                }
                else
                {
                    ofrTBOList.Add(new List<string>().ToArray());
                    equipGenreCodeList.Add(0);
                }
            }

            //　[ TBO検索 ]　提供車輌情報結合検索リモート処理
            status = GetOfrTBOInfo(partsSearchUIDataDic, equipGenreCodeList, ofrTBOList);

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            foreach (PartsInfoDataSet partsInfo in partsInfoDic.Values)
            {
                if (partsInfo.UsrGoodsInfo.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;
            #endregion
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// TBO情報取得[不要：優良設定なしバージョン]
        /// </summary>
        /// <param name="retPartsInfo">TBO検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        public int GetTBOInfo(out PartsInfoDataSet retPartsInfo, string enterpriseCode)
        {
            // 2009.02.12 >>>
            //return GetTBOInfo(out retPartsInfo, enterpriseCode, string.Empty, new Dictionary<PrmSettingKey, PrmSettingUWork>());
            return GetTBOInfo(out retPartsInfo, enterpriseCode, string.Empty, new List<PrmSettingUWork>());
            // 2009.02.12 <<<
        }

        /// <summary>
        /// TBO情報取得２[エントリのTBOボタン処理用]
        /// </summary>
        /// <param name="retPartsInfo">TBO検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secCd">ログイン拠点コード（優良設定リストの設定取得用）</param>
        /// <param name="drPrmSettingWork">優良設定リスト</param>
        /// <returns></returns>
        public int GetTBOInfo(out PartsInfoDataSet retPartsInfo, string enterpriseCode, string secCd,
                // 2009.02.12 >>>
                //Dictionary<PrmSettingKey, PrmSettingUWork> drPrmSettingWork)
                List<PrmSettingUWork> drPrmSettingWork)
                // 2009.02.12 <<<
        {
            //>>>2010/03/29
            partsInfo.Clear();

            int makerCode = 0;
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    makerCode = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    makerCode = carInfoDataSet.CarModelInfo[0].MakerCode;
            }

            // 大型契約なしで指定のメーカーが大型の場合は検索せず、0件とする。
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (makerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(makerCode))
                {
                    retPartsInfo = partsInfo;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            //<<<2010/03/29

            List<string> list = new List<string>();
            ArrayList lstCond = new ArrayList();
            for (int i = 0; i < carInfoDataSet.CategoryEquipmentInfo.Count; i++)
            {
                if (list.Contains(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName) == false)
                {
                    list.Add(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName);

                    TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
                    tBOSearchUWork.EnterpriseCode = enterpriseCode;
                    tBOSearchUWork.EquipGenreCode = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentGenreCd;
                    tBOSearchUWork.EquipName = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName;
                    lstCond.Add(tBOSearchUWork);
                }
            }
            ArrayList tboSearchRet = null;
            ArrayList tboSearchPriceRet = null;
            _sectionCode = secCd;
            _drPrmSettingWork = drPrmSettingWork;

            //partsInfo.Clear(); // 2010/03/29
            partsInfo.SearchMethod = 0; // 検索方法：BL検索[品名表示時判断のため使用]

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            tBOSearchCondWork.TbsPartsCode = 0;
            tBOSearchCondWork.EquipName = list.ToArray();
            tBOSearchCondWork.EquipGenreCode = 0;

            // -- UPD 2010/05/25 --------------------------------->>>
            //if (iTBOSearchInfDB == null)
            //    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

            //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
            //if ((status == 0) && (tboSearchRet.Count > 0))
            //{
            //    FillTBOInfoTable(tboSearchRet, tboSearchPriceRet);
            //}

            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
                if ( iTBOSearchInfDB == null )
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    FillTBOInfoTable( tboSearchRet, tboSearchPriceRet );
                }
            }
            // -- UPD 2010/05/25 ---------------------------------<<<

            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();
            ArrayList tboSearchURet = new ArrayList();
            object objTBOSearchUList = tboSearchURet;
            //status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData0); // 2009/09/07 DEL
            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData01); // 2009/09/07 ADD

            tboSearchURet = objTBOSearchUList as ArrayList;

            PartsSearchUIData partsSearchUIDate = new PartsSearchUIData();
            partsSearchUIDate.EnterpriseCode = enterpriseCode;
            status = GetUsrGoodsInfForTBO(enterpriseCode, tboSearchURet);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet);
            }

            retPartsInfo = partsInfo;

            return 0;
        }

        // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// TBO情報取得[エントリのTBOボタン処理用]
        /// </summary>
        /// <param name="retPartsInfo">TBO検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secCd">拠点コード(優良設定リストの設定取得用)</param>
        /// <param name="drPrmSettingWork">優良設定リスト</param>
        /// <param name="inputPartsSearchUIData">検索条件データクラス</param>
        /// <returns></returns>
        public int GetTBOInfo(out PartsInfoDataSet retPartsInfo, string enterpriseCode, string secCd, List<PrmSettingUWork> drPrmSettingWork, PartsSearchUIData inputPartsSearchUIData)
        {
            //>>>2010/03/29
            partsInfo.Clear();

            int makerCode = 0;
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    makerCode = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    makerCode = carInfoDataSet.CarModelInfo[0].MakerCode;
            }

            // 大型契約なしで指定のメーカーが大型の場合は検索せず、0件とする。
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (makerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(makerCode))
                {
                    retPartsInfo = partsInfo;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            //<<<2010/03/29

            List<string> list = new List<string>();
            ArrayList lstCond = new ArrayList();
            for (int i = 0; i < carInfoDataSet.CategoryEquipmentInfo.Count; i++)
            {
                if (list.Contains(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName) == false)
                {
                    list.Add(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName);

                    TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
                    tBOSearchUWork.EnterpriseCode = enterpriseCode;
                    tBOSearchUWork.EquipGenreCode = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentGenreCd;
                    tBOSearchUWork.EquipName = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName;
                    lstCond.Add(tBOSearchUWork);
                }
            }
            ArrayList tboSearchRet = null;
            ArrayList tboSearchPriceRet = null;
            _sectionCode = secCd;
            _drPrmSettingWork = drPrmSettingWork;

            //partsInfo.Clear(); // 2010/03/29
            partsInfo.SearchCondition = inputPartsSearchUIData;
            partsInfo.SearchMethod = 0; // 検索方法：BL検索[品名表示時判断のため使用]

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            tBOSearchCondWork.TbsPartsCode = 0;
            tBOSearchCondWork.EquipName = list.ToArray();
            tBOSearchCondWork.EquipGenreCode = 0;

            // -- UPD 2010/05/25 ---------------------------------->>>
            //if (iTBOSearchInfDB == null)
            //    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

            //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
            //if ((status == 0) && (tboSearchRet.Count > 0))
            //{
            //    FillTBOInfoTable(tboSearchRet, tboSearchPriceRet);
            //}

            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
                if ( iTBOSearchInfDB == null )
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    FillTBOInfoTable( tboSearchRet, tboSearchPriceRet );
                }
            }
            // -- UPD 2010/05/25 ----------------------------------<<<

            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();
            ArrayList tboSearchURet = new ArrayList();
            object objTBOSearchUList = tboSearchURet;
            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData01);

            tboSearchURet = objTBOSearchUList as ArrayList;

            PartsSearchUIData partsSearchUIDate = new PartsSearchUIData();
            partsSearchUIDate.EnterpriseCode = enterpriseCode;
            status = GetUsrGoodsInfForTBO(enterpriseCode, tboSearchURet);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet);
            }

            retPartsInfo = partsInfo;

            return 0;
        }
        // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// TBO情報取得３[TBOマスタ用]
        /// </summary>
        /// <param name="retPartsInfo">TBO検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="equipGenreCd">装備分類（検索するTBOの装備分類）</param>
        /// <param name="equipNm">装備名称（検索するTBOの装備名称・あいまい検索は不可）</param>
        /// <param name="secCd">ログイン拠点コード（優良設定リストの設定取得用）</param>
        /// <param name="drPrmSettingWork">優良設定リスト</param>
        /// <returns></returns>
        public int GetTBOInfo(out PartsInfoDataSet retPartsInfo, string enterpriseCode,
                int equipGenreCd, string equipNm,
                // 2009.02.12 >>>
                //string secCd, Dictionary<PrmSettingKey, PrmSettingUWork> drPrmSettingWork)
                string secCd, List<PrmSettingUWork> drPrmSettingWork)  
                // 2009.02.12 <<<
        {
            ArrayList tboSearchRet = null;
            ArrayList tboSearchURet = new ArrayList();
            ArrayList tboSearchPriceRet = null;
            _sectionCode = secCd;
            _drPrmSettingWork = drPrmSettingWork;

            partsInfo.Clear();
            partsInfo.SearchMethod = 0; // 検索方法：BL検索[品名表示時判断のため使用]

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            tBOSearchCondWork.TbsPartsCode = 0;
            tBOSearchCondWork.EquipName = new string[] { equipNm };
            tBOSearchCondWork.EquipGenreCode = equipGenreCd;

            // -- UPD 2010/05/25 ---------------------------->>>
            //if (iTBOSearchInfDB == null)
            //    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

            //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
            //if ((status == 0) && (tboSearchRet.Count > 0))
            //{
            //    FillTBOInfoTable(tboSearchRet, tboSearchPriceRet);
            //}

            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
                if ( iTBOSearchInfDB == null )
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    FillTBOInfoTable( tboSearchRet, tboSearchPriceRet );
                }
            }
            // -- UPD 2010/05/25 ----------------------------<<<
            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();
            object objTBOSearchUList = tboSearchURet;
            TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
            tBOSearchUWork.EnterpriseCode = enterpriseCode;
            tBOSearchUWork.EquipGenreCode = equipGenreCd;
            tBOSearchUWork.EquipName = equipNm;

            ArrayList lstCond = new ArrayList();
            lstCond.Add(tBOSearchUWork);
            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData0);

            tboSearchURet = objTBOSearchUList as ArrayList;

            PartsSearchUIData partsSearchUIDate = new PartsSearchUIData();
            partsSearchUIDate.EnterpriseCode = enterpriseCode;
            status = GetUsrGoodsInfForTBO(enterpriseCode, tboSearchURet);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet);
            }

            retPartsInfo = partsInfo;

            return 0;
        }


        /// <summary>
        /// 装備名称曖昧検索
        /// </summary>
        /// <param name="lstEquipNm">装備名称曖昧結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="equipGenreCd">装備分類（検索するTBOの装備分類）</param>
        /// <param name="equipNm">装備名称（検索するTBOの装備名称・あいまい検索のみ）</param>
        /// <param name="secCd">ログイン拠点コード（優良設定リストの設定取得用）</param>
        /// <param name="drPrmSettingWork">優良設定リスト</param>
        /// <returns></returns>
        public int SearchEquipName(out List<string> lstEquipNm, string enterpriseCode,
                int equipGenreCd, string equipNm,
                // 2009.02.12 >>>
                //string secCd, Dictionary<PrmSettingKey, PrmSettingUWork> drPrmSettingWork)
                string secCd, List<PrmSettingUWork> drPrmSettingWork)
                // 2009.02.12 <<<
        {
            int nmSearchFlg = 0; // 0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索
            ArrayList tboSearchRet = null;
            ArrayList tboSearchURet = new ArrayList();
            ArrayList tboSearchPriceRet = null;
            _sectionCode = secCd;
            _drPrmSettingWork = drPrmSettingWork;

            lstEquipNm = new List<string>();

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            tBOSearchCondWork.TbsPartsCode = 0;
            tBOSearchCondWork.EquipName = new string[] { equipNm };
            tBOSearchCondWork.EquipGenreCode = equipGenreCd;

            // -- ADD 2010/05/25 ------------------>>>
            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
            // -- ADD 2010/05/25 ------------------<<<

                if ( iTBOSearchInfDB == null )
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                // -- UPD 2010/05/25 --------------------------->>>
                //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                // -- UPD 2010/05/25 ---------------------------<<<
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    foreach ( TBOSearchRetWork wkInf in tboSearchRet )
                    {
                        if ( searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                             && wkInf.JoinDestMakerCd == ct_TactiCd // 部品メーカーがタクティー
                             && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd ) // 車のメーカーがトヨタでない
                        {
                            continue;
                        }
                        //　優良設定絞込処理
                        bool tboExcludeFlg = false;
                        // 2009.02.12 >>>
                        //PrmSettingUWork prmSetting = null;
                        //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                        //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                        //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                        //{
                        //    tboExcludeFlg = true;
                        //}
                        //else
                        //{
                        //    prmSetting = _drPrmSettingWork[prmKey];
                        //    if (prmSetting.PrimeDisplayCode == 0) // 優良表示区分が[なし]以外を表示する。
                        //        tboExcludeFlg = true;
                        //}

                        PrmSettingUWork prmSetting = SearchPrmSettingUWork( _sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork );
                        if ( prmSetting == null )
                        {
                            tboExcludeFlg = true;
                        }
                        else
                        {
                            if ( prmSetting.PrimeDisplayCode == 0 ) // 優良表示区分が[なし]以外を表示する。
                                tboExcludeFlg = true;
                        }

                        // 2009.02.12 <<<
#if !PrimeSet
                    tboExcludeFlg = false;
#endif
                        if ( tboExcludeFlg == false && lstEquipNm.Contains( wkInf.EquipName ) == false )
                        {
                            lstEquipNm.Add( wkInf.EquipName );
                        }
                    }
                }
            }  // ADD 2010/05/25


            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();
            object objTBOSearchUList = tboSearchURet;
            TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
            tBOSearchUWork.EnterpriseCode = enterpriseCode;
            tBOSearchUWork.EquipGenreCode = equipGenreCd;
            tBOSearchUWork.EquipName = equipNm;
            if (equipNm.EndsWith("*"))
            {
                tBOSearchUWork.EquipName = tBOSearchUWork.EquipName.Substring(0, equipNm.Length - 1);
                if (tBOSearchUWork.EquipName.StartsWith("*"))
                {
                    tBOSearchUWork.EquipName = tBOSearchUWork.EquipName.Remove(0, 1);
                    nmSearchFlg = 3;
                }
                else if (equipNm == "*")
                    nmSearchFlg = 3;
                else
                    nmSearchFlg = 1;
            }
            else if (equipNm.StartsWith("*"))
            {
                tBOSearchUWork.EquipName = tBOSearchUWork.EquipName.Remove(0, 1);
                nmSearchFlg = 2;
            }
            if (nmSearchFlg > 0) // 装備名称曖昧検索か
            {
                status = iTBOSearchUDB.SearchEquipNameGuide(ref objTBOSearchUList, tBOSearchUWork, nmSearchFlg);
            }

            tboSearchURet = objTBOSearchUList as ArrayList;
            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                foreach (TBOSearchUWork wkInf in tboSearchURet)
                {
                    if (searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                         && wkInf.JoinDestMakerCd == ct_TactiCd // 部品メーカーがタクティー
                         && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // 車のメーカーがトヨタでない
                    {
                        continue;
                    }
                    if (lstEquipNm.Contains(wkInf.EquipName) == false)
                    {
                        lstEquipNm.Add(wkInf.EquipName);
                    }
                }
            }

            return 0;
        }

        #endregion

        # region [ 4. 品番検索メイン ]
        /// <summary>
        /// 品番検索メイン
        /// </summary>
        /// <param name="partsSearchUIData">検索条件</param>
        /// 
        /// <br>Update Note: 2011/08/24  連番980 梁森東</br>
        /// <br>            : REDMINE#23417の対応</br>
        /// <br>Update Note: 2011/08/31  連番980 梁森東</br>
        /// <br>            : REDMINE#23417の対応</br>
        /// <br>Update Note: 2012/06/18  障害No.1004 高峰</br>
        /// <returns></returns>
        private int PartsNoSearchMain(PartsSearchUIData partsSearchUIData)
        {
            # region 変数の初期化
            int status = 0;

            GetPartsInfPara para = new GetPartsInfPara();
            # endregion

            # region 検索条件の設定
            string srcPrtsNo = partsSearchUIData.PartsNo;

            //ハイフン有無判定
            if (srcPrtsNo.IndexOf("-") != -1)
            {
                para.PrtsNoWithHyphen = srcPrtsNo;
            }
            else
            {
                para.PrtsNoNoneHyphen = srcPrtsNo;
            }
            para.MakerCode = partsSearchUIData.PartsMakerCode;
            para.SearchType = (int)partsSearchUIData.SearchType;
            if (partsSearchUIData.SearchFlg == SearchFlag.GoodsInfoOnly || partsSearchUIData.SearchFlg == SearchFlag.GoodsAndSetInfo)
                para.NoSubst = 1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 ADD
            para.PriceDate = partsSearchUIData.PriceDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 ADD
            // --- ADD m.suzuki 2010/06/12 ---------->>>>>
            // 0:２輪オプションなし
            if ( searchPrtCtlAcs.BikeSearch == 0 )
            {
                // 2輪提供データは除外
                SetParamForBikeSearch( ref para, false );
            }
            // --- ADD m.suzuki 2010/06/12 ----------<<<<<
            # endregion

            //ADD by Liangsd   2011/08/24----------------->>>>>>>>>>
            //DEL by Liangsd   2011/08/31----------------->>>>>>>>>>>
            //if (!srcPrtsNo.ToUpper().Equals(srcPrtsNo))
            //{
            //    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            //}
            //DEL by Liangsd   2011/08/31-----------------<<<<<<<<<<<
            //ADD by Liangsd   2011/08/24-----------------<<<<<<<<<<<
            # region 純正品番検索
            //純正品番検索
            //status = GetCatalogPartsInf(para);//DEL by Liangsd   2011/08/31
            //ADD by Liangsd   2011/08/31----------------->>>>>>>>>>
            if (!srcPrtsNo.ToUpper().Equals(srcPrtsNo))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                status = GetCatalogPartsInf(para);            
            }
            //ADD by Liangsd   2011/08/31-----------------<<<<<<<<<<<
            if (status != 0 && status != 4)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            # endregion

            ArrayList searchCondList = new ArrayList();

            // 優良部品に対し品番検索を行う。
            //status = GetPrimePartsInfFromPrimePartsNo(partsSearchUIData); // DEL 2012/06/18 高峰 障害№1004
            // ----- ADD 2012/06/18 高峰 障害№1004 ----->>>>>
            if (!srcPrtsNo.ToUpper().Equals(srcPrtsNo))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = GetPrimePartsInfFromPrimePartsNo(partsSearchUIData);
            }
            // ----- ADD 2012/06/18 高峰 障害№1004 -----<<<<<
            if (status != 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            if (partsInfo.UsrGoodsInfo.Count > 0)
            {
                if (partsSearchUIData.SearchFlg == SearchFlag.PartsNoJoinSearch)
                {// 品番結合検索の場合、取得した純正品番に対する結合検索を行う。  
                    bool primeSubstFlg = false; // 品番検索は優良検索時代替しない。
                    //if (partsSearchUIData.SearchCntSetWork.PrmSubstCondDivCd != 0)
                    //    primeSubstFlg = true;
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //status = GetPrimePartsInf( primeSubstFlg );
                    status = GetPrimePartsInf( primeSubstFlg, para );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                }
            }
            #region [ Comment Out ]
            /* 旧ソース　　品番検索改良のためコメントアウトする
            if (partsInfo.PartsInfo.Count > 0)
            {
                if (partsSearchUIData.SearchFlg == SearchFlag.PartsNoJoinSearch)
                {// 品番結合検索の場合、取得した純正品番に対する結合検索を行う。  
                    bool primeSubstFlg = false;
                    if (partsSearchUIData.SearchCntSetWork.PrmSubstCondDivCd != 0)
                        primeSubstFlg = true;
                    status = GetPrimePartsInf(primeSubstFlg);
                }
                if (partsSearchUIData.SearchFlg != SearchFlag.GoodsInfoOnly)
                {
                    GetUsrCondList(searchCondList, partsSearchUIData);
                }
            }
            else // 品番検索で純正部品に該当品番がなかった場合優良部品を検索する。
            {
                status = GetPrimePartsInfFromPrimePartsNo(partsSearchUIData);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                if (partsSearchUIData.SearchFlg != SearchFlag.GoodsInfoOnly)
                {
                    GetUsrCondList(searchCondList, partsSearchUIData);
                    //GetUsrCondListFromJoinParts(searchCondList);
                    //GetUsrCondListFromSet(searchCondList);
                    //GetUsrCondListFromSubst(searchCondList); 
                    //GetUsrCondListFromDSubst(searchCondList);
                }
            }*/
            #endregion

            // 上記検索結果に関係なくユーザーDBを検索する。[提供データ修正分がユーザーDBにある可能性がある]
            if (partsSearchUIData.SearchFlg == SearchFlag.GoodsInfoOnly)
            {
                status = GetUsrPartsInfFromPartsNo(partsSearchUIData);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            else
            {
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //status = GetUsrGoodsJoinInf(partsSearchUIData);
                status = GetUsrGoodsJoinInf( partsSearchUIData, para );
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            }

            #region [ ユーザーOEM対応 ]
            if (partsSearchUIData.SearchCntSetWork.SubstApplyDivCd == 2) // 代替適用全て：ユーザー登録品に関して更に提供検索
            {
                status = UserOEMSearch(partsSearchUIData);
            }
            #endregion

            // --- ADD 2012/12/20 Y.Wakita ---------->>>>>
            // もう一度作成
            // 上記検索結果に関係なくユーザーDBを検索する。[提供データ修正分がユーザーDBにある可能性がある]
            if (partsSearchUIData.SearchFlg == SearchFlag.GoodsInfoOnly)
            {
                status = GetUsrPartsInfFromPartsNo(partsSearchUIData);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            else
            {
                status = GetUsrGoodsJoinInf(partsSearchUIData, para);
            }
            // --- ADD 2012/12/20 Y.Wakita ----------<<<<<

            if (partsInfo.UsrGoodsInfo.Count == 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 品番検索メイン
        /// </summary>
        /// <param name="inParaDic">検索条件</param>
        /// <returns></returns>
        private int PartsNoSearchMain(Dictionary<int, PartsSearchUIData> inParaDic)
        {
            # region 変数の初期化
            int status = 0;

            GetPartsInfPara para;
            Dictionary<int, GetPartsInfPara> partsParaDic = new Dictionary<int, GetPartsInfPara>();             // 純正品番検索用
            Dictionary<int, PartsSearchUIData> primeInParaDic = new Dictionary<int, PartsSearchUIData>();       // 優良品番検索用
            Dictionary<int, GetPartsInfPara> joinPartsParaDic = new Dictionary<int, GetPartsInfPara>();         // 品番結合検索用
            Dictionary<int, PartsSearchUIData> goodsInfInParaDic = new Dictionary<int, PartsSearchUIData>();    // 商品情報のみ検索用
            Dictionary<int, GetPartsInfPara> goodsPartsParaDic = new Dictionary<int, GetPartsInfPara>();        // 部品情報検索用
            Dictionary<int, PartsSearchUIData> goodsPartsInParaDic = new Dictionary<int, PartsSearchUIData>();  // 部品情報検索用
            # endregion

            # region 検索条件の設定

            foreach (int key in inParaDic.Keys)
            {
                para = new GetPartsInfPara();

                string srcPrtsNo = inParaDic[key].PartsNo;

                //ハイフン有無判定
                if (srcPrtsNo.IndexOf("-") != -1)
                {
                    para.PrtsNoWithHyphen = srcPrtsNo;
                }
                else
                {
                    para.PrtsNoNoneHyphen = srcPrtsNo;
                }
                para.MakerCode = inParaDic[key].PartsMakerCode;
                para.SearchType = (int)inParaDic[key].SearchType;
                if (inParaDic[key].SearchFlg == SearchFlag.GoodsInfoOnly || inParaDic[key].SearchFlg == SearchFlag.GoodsAndSetInfo)
                    para.NoSubst = 1;
                para.PriceDate = inParaDic[key].PriceDate;
                // 0:２輪オプションなし
                if (searchPrtCtlAcs.BikeSearch == 0)
                {
                    // 2輪提供データは除外
                    SetParamForBikeSearch(ref para, false);
                }

                // 純正品番・優良品番検索用リスト生成
                if (srcPrtsNo.ToUpper().Equals(srcPrtsNo))
                {
                    partsParaDic.Add(key, para);
                    primeInParaDic.Add(key, inParaDic[key]);
                }
                // 検索条件別リストの生成
                if (inParaDic[key].SearchFlg == SearchFlag.PartsNoJoinSearch)
                {
                    joinPartsParaDic.Add(key, para);
                }
                if (inParaDic[key].SearchFlg == SearchFlag.GoodsInfoOnly)
                {
                    goodsInfInParaDic.Add(key, inParaDic[key]);
                }
                else
                {
                    goodsPartsParaDic.Add(key, para);
                    goodsPartsInParaDic.Add(key, inParaDic[key]);
                }

            }

            # endregion

            # region 純正品番検索
            //純正品番検索
            status = GetCatalogPartsInf(partsParaDic);

            if (status != 0 && status != 4)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            # endregion

            // 優良部品に対し品番検索を行う。
            status = GetPrimePartsInfFromPrimePartsNo(primeInParaDic);

            if (status != 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            if (joinPartsParaDic != null && joinPartsParaDic.Count != 0)
            {
                // 品番結合検索の場合、取得した純正品番に対する結合検索を行う。  
                bool primeSubstFlg = false; // 品番検索は優良検索時代替しない。
                status = GetPrimePartsInf(primeSubstFlg, joinPartsParaDic);
            }

            // 上記検索結果に関係なくユーザーDBを検索する。[提供データ修正分がユーザーDBにある可能性がある]
            if (goodsInfInParaDic != null && goodsInfInParaDic.Count != 0)
            {
                status = GetUsrPartsInfFromPartsNo(goodsInfInParaDic);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            if (goodsPartsInParaDic != null && goodsPartsInParaDic.Count != 0)
            {
                status = GetUsrGoodsJoinInf(goodsPartsInParaDic, goodsPartsParaDic);
            }

            #region [ ユーザーOEM対応 ]
            status = UserOEMSearch(inParaDic);
            #endregion

            // もう一度作成
            // 上記検索結果に関係なくユーザーDBを検索する。[提供データ修正分がユーザーDBにある可能性がある]
            if (goodsInfInParaDic != null && goodsInfInParaDic.Count != 0)
            {
                status = GetUsrPartsInfFromPartsNo(goodsInfInParaDic);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            if (goodsPartsInParaDic != null && goodsPartsInParaDic.Count != 0)
            {
                status = GetUsrGoodsJoinInf(goodsPartsInParaDic, goodsPartsParaDic);
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            foreach (PartsInfoDataSet partsInfo in partsInfoDic.Values)
            {
                if (partsInfo.UsrGoodsInfo.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;

        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
        /// <summary>
        /// ２輪検索用パラメータ設定
        /// </summary>
        /// <param name="para">設定対象のパラメータ</param>
        /// <param name="bikeSearchEnable">true:２輪あり／false:２輪なし</param>
        private void SetParamForBikeSearch( ref GetPartsInfPara para, bool bikeSearchEnable )
        {
            if ( bikeSearchEnable )
            {
                // ２輪除外フラグ＝false
                para.TwoWheelerMakerExclude = false;
                // ２輪メーカーコードをセットしない
                para.TwoWheelerMakerCdSt = 0;
                para.TwoWheelerMakerCdEd = 0;
            }
            else
            {
                // ２輪除外フラグ＝true
                para.TwoWheelerMakerExclude = true;
                // ２輪メーカーコード(21～24)
                para.TwoWheelerMakerCdSt = 21;
                para.TwoWheelerMakerCdEd = 24;
            }
        }
        // --- ADD m.suzuki 2010/06/12 ----------<<<<<

        private int GetUsrPartsInfFromPartsNo(PartsSearchUIData partsSearchUIData)
        {
            int status = 0;

            ArrayList usrGoodsRet = new ArrayList();
            ArrayList usrGoodsPriceRet = new ArrayList();
            ArrayList usrGoodsStockRet = new ArrayList();

            UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
            usrJoinPartsCondWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
            usrJoinPartsCondWork.MakerCode = partsSearchUIData.PartsMakerCode;
            usrJoinPartsCondWork.PrtsNo = partsSearchUIData.PartsNo;

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

            // 2009/12/17 >>>
            //// 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ////status = iUsrJoinPartsSearchDB.UserGoodsSearch(usrJoinPartsCondWork,
            ////                                        (int)partsSearchUIData.SearchType,
            ////                                        out usrGoodsRet,
            ////                                        out usrGoodsPriceRet,
            ////                                        out usrGoodsStockRet);
            //status = iUsrJoinPartsSearchDB.UserGoodsSearch(usrJoinPartsCondWork,
            //                                        (int)partsSearchUIData.SearchType,
            //                                        ConstantManagement.LogicalMode.GetData01,
            //                                        out usrGoodsRet,
            //                                        out usrGoodsPriceRet,
            //                                        out usrGoodsStockRet);
            //// 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            status = iUsrJoinPartsSearchDB.UserGoodsSearch(usrJoinPartsCondWork,
                                                    (int)partsSearchUIData.SearchType,
                                                    partsSearchUIData.LogicalMode,
                                                    out usrGoodsRet,
                                                    out usrGoodsPriceRet,
                                                    out usrGoodsStockRet);
            // 2009/12/17 <<<

            // --- UPD m.suzuki 2011/05/18 ---------->>>>>
            //FillUsrGoodsInfoTable(usrGoodsRet);
            FillUsrGoodsInfoTable( usrGoodsRet, null );
            // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            FillUsrGoodsPriceTable(usrGoodsPriceRet);
            FillUsrGoodsStockTable(usrGoodsStockRet);
            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  品番結合検索
        /// </summary>
        /// <param name="partsSearchUIDataDic"></param>
        /// <returns></returns>
        private int GetUsrPartsInfFromPartsNo(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            int status = 0;

            ArrayList usrGoodsRet = new ArrayList();
            ArrayList usrGoodsPriceRet = new ArrayList();
            ArrayList usrGoodsStockRet = new ArrayList();

            ArrayList usrJoinPartsCond = new ArrayList();
            ArrayList searchType = new ArrayList();

            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;

            foreach (int key in partsSearchUIDataDic.Keys)
            {
                UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                usrJoinPartsCondWork.MakerCode = partsSearchUIDataDic[key].PartsMakerCode;
                usrJoinPartsCondWork.PrtsNo = partsSearchUIDataDic[key].PartsNo;
                usrJoinPartsCond.Add(usrJoinPartsCondWork as object);

                searchType.Add(partsSearchUIDataDic[key].SearchType as object);

                logicalMode = partsSearchUIDataDic[key].LogicalMode;
            }

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();


            status = iUsrJoinPartsSearchDB.UserGoodsSearch(usrJoinPartsCond,
                                                    searchType,
                                                    logicalMode,
                                                    out usrGoodsRet,
                                                    out usrGoodsPriceRet,
                                                    out usrGoodsStockRet);

            foreach (int key in partsSearchUIDataDic.Keys)
            {
                // ユーザー結合検索：商品情報設定
                FillUsrGoodsInfoTable(usrGoodsRet, null, key);
                // 価格情報設定
                FillUsrGoodsPriceTable(usrGoodsPriceRet);
                // 在庫情報設定
                FillUsrGoodsStockTable(usrGoodsStockRet);
            }
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 品番・メーカー複数検索[完全一致検索のみ]
        /// </summary>
        /// <param name="PartsSearchUIData">検索条件</param>
        /// <param name="lstSrchCond">検索条件リスト</param>
        /// <param name="retPartsInfo">結果データセット</param>
        /// <returns></returns>
        public int PrtNoListSearch(PartsSearchUIData PartsSearchUIData, ArrayList lstSrchCond, out PartsInfoDataSet retPartsInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            partsInfo.Clear();
            partsInfo.SearchCondition = PartsSearchUIData;
            _sectionCode = PartsSearchUIData.SectionCode;
            _drPrmSettingWork = PartsSearchUIData.PrmSettingWork;

            ArrayList lstCond = new ArrayList();
            ArrayList searchCondList = new ArrayList();
            ArrayList lstRst;
            ArrayList lstRstPrm;
            ArrayList lstPrmPrice;
            try
            {
                // 提供部品情報取得
                int cnt = lstSrchCond.Count;
                for (int i = 0; i < cnt; i++)
                {
                    SrchCond con = lstSrchCond[i] as SrchCond;
                    OfrPrtsSrchCndWork work = new OfrPrtsSrchCndWork();
                    work.MakerCode = con.makerCd;
                    work.PrtsNo = con.partsNo;
                    lstCond.Add(work);

                    UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = PartsSearchUIData.EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = con.makerCd;
                    usrJoinPartsCondWork.PrtsNo = con.partsNo;
                    searchCondList.Add(usrJoinPartsCondWork);
                }

                // -- UPD 2010/05/25 -------------------------->>>
                //if (iOfferPartsInfo == null)
                //    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                //status = iOfferPartsInfo.GetOfrPartsInf(lstCond, out lstRst, out lstRstPrm, out lstPrmPrice);
                //if (status == 0)
                //{
                //    // 純正部品情報設定
                //    FillPartsInfo(lstRst, null);
                //    // 優良部品情報設定
                //    FillJoinSetParts(true, lstRstPrm, lstPrmPrice, null, null);
                //}

                //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
                if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
                {
                    if ( iOfferPartsInfo == null )
                        iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                    status = iOfferPartsInfo.GetOfrPartsInf( lstCond, out lstRst, out lstRstPrm, out lstPrmPrice );
                    if ( status == 0 )
                    {
                        // 純正部品情報設定
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillPartsInfo( lstRst, null );
                        FillPartsInfo( lstRst, null, null );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                        // 優良部品情報設定
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillJoinSetParts( true, lstRstPrm, lstPrmPrice, null, null );
                        FillJoinSetParts( true, lstRstPrm, lstPrmPrice, null, null, null );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                    }
                }
                // -- UPD 2010/05/25 --------------------------<<<

                // ユーザー商品情報取得
                object retobj;
                if (iUsrJoinPartsSearchDB == null)
                    iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, UsrSearchFlg.UsrPartsOnly, (int)SearchType.WholeWord, searchCondList);
                if (status == 0)
                {
                    CustomSerializeArrayList arrList = retobj as CustomSerializeArrayList;

                    for (int i = 0; i < arrList.Count; i++)
                    {
                        ArrayList usrRet = arrList[i] as ArrayList;
                        switch (usrRet[0].GetType().Name)
                        {
                            case "UsrGoodsRetWork":
                                //ユーザー結合検索:商品情報
                                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                                //FillUsrGoodsInfoTable(usrRet);
                                FillUsrGoodsInfoTable( usrRet, null );
                                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                                break;
                            case "GoodsPriceUWork":
                                FillUsrGoodsPriceTable(usrRet);
                                break;
                            case "StockWork":
                                FillUsrGoodsStockTable(usrRet);
                                break;
                        }
                    }
                }
            }
            catch
            {

            }

            retPartsInfo = partsInfo;
            return status;
        }
        # endregion

        #region [ 5. 結合元検索 ]
        // 2009/11/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //private int GetJoinSrcPartsProc(string enterpriseCd, int makerCd, string partsNo)
        private int GetJoinSrcPartsProc(int mode, string enterpriseCd, int makerCd, string partsNo)
        // 2009/11/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            int status = 0;
            object obRetparts = null;
            ArrayList RetPartsInf = null;
            ArrayList searchCondList = new ArrayList();

            // -- ADD 2010/05/25 ----------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
            // -- ADD 2010/05/25 -----------------------<<<

                if ( iOfferPartsInfo == null )
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
                status = iOfferPartsInfo.GetGenuineParts( makerCd, partsNo, out obRetparts );
                if ( status == 0 )
                {
                    partsInfo.Clear();
                    partsInfo.SearchMethod = 1; // 結合元検索は品番検索扱いとする。
                    RetPartsInf = obRetparts as ArrayList;
                    //部品情報設定
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //FillPartsInfo( RetPartsInf, null );
                    FillPartsInfo( RetPartsInf, null, null );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                    for ( int i = 0; i < partsInfo.UsrGoodsInfo.Count; i++ )
                    {
                        UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                        usrJoinPartsCondWork.EnterpriseCode = enterpriseCd;
                        usrJoinPartsCondWork.MakerCode = partsInfo.UsrGoodsInfo[i].GoodsMakerCd;
                        usrJoinPartsCondWork.PrtsNo = partsInfo.UsrGoodsInfo[i].GoodsNo;
                        searchCondList.Add( usrJoinPartsCondWork );
                    }

                    object retobj;
                    CustomSerializeArrayList arrList;
                    ArrayList usrRet = null;
                    if ( iUsrJoinPartsSearchDB == null )
                        iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                    status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch( out retobj, UsrSearchFlg.UsrPartsOnly, (int)SearchType.WholeWord, searchCondList );
                    if ( status != 0 )
                    {
                        return (status);
                    }
                    arrList = retobj as CustomSerializeArrayList;
                    for ( int i = 0; i < arrList.Count; i++ )
                    {
                        usrRet = arrList[i] as ArrayList;
                        switch ( usrRet[0].GetType().Name )
                        {
                            case "UsrGoodsRetWork":
                                //ユーザー結合検索:商品情報
                                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                                //FillUsrGoodsInfoTable( usrRet );
                                FillUsrGoodsInfoTable( usrRet, null );
                                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                                break;
                            case "GoodsPriceUWork":
                                FillUsrGoodsPriceTable( usrRet );
                                break;
                            case "StockWork":
                                FillUsrGoodsStockTable( usrRet );
                                break;
                        }
                    }
                }
            }  // ADD 2010/05/25

            ArrayList retGoods;
            ArrayList retPrice;
            ArrayList retStock;
            UsrPartsNoSearchCondWork cond = new UsrPartsNoSearchCondWork();
            cond.EnterpriseCode = enterpriseCd;
            cond.MakerCode = makerCd;
            cond.PrtsNo = partsNo;
            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
            status = iUsrJoinPartsSearchDB.UserGoodsSearch(cond, 5, out retGoods, out retPrice, out retStock);
            if (status == 0)
            {
                //ユーザー結合検索:商品情報
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //FillUsrGoodsInfoTable(retGoods);
                FillUsrGoodsInfoTable( retGoods, null );
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<

                // 2009/11/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (mode == 1)
                {
                    foreach (UsrGoodsRetWork wkInf in retGoods)
                    {
                        # region 変数の初期化
                        GetPartsInfPara para = new GetPartsInfPara();
                        # endregion

                        # region 検索条件の設定
                        string srcPrtsNo = wkInf.GoodsNo;

                        //ハイフン有無判定
                        if (srcPrtsNo.IndexOf("-") != -1)
                        {
                            para.PrtsNoWithHyphen = srcPrtsNo;
                            para.SearchType = (int)SearchType.WholeWord;
                        }
                        else
                        {
                            para.PrtsNoNoneHyphen = srcPrtsNo;
                            para.SearchType = (int)SearchType.WholeWordWithNoHyphen;
                        }
                        para.MakerCode = wkInf.GoodsMakerCd;
                        para.NoSubst = 1;
                        para.PriceDate = DateTime.Today;
                        # endregion

                        # region 純正品番検索
                        //純正品番検索
                        status = GetCatalogPartsInf2(para);
                        if (status != 0 && status != 4)
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                        # endregion
                    }
                }
                // 2009/11/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                FillUsrGoodsPriceTable(retPrice);
                FillUsrGoodsStockTable(retStock);
            }

            return status;
        }
        #endregion

        #region [ 6. 商品一括登録検索 ]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
        //private int SearchOfrPartsProc(PrtsSrchCndWork InPara)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
        private int SearchOfrPartsProc( PrtsSrchCndWork InPara, string sectionCode, List<PrmSettingUWork> prmSettingUWorkList )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            int status = 0;
            object obRetparts = null;
            ArrayList searchCondList = new ArrayList();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            // 拠点コード（優良設定用）
            _sectionCode = sectionCode;
            // 優良設定リスト
            _drPrmSettingWork = prmSettingUWorkList;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            if ( iOfferPartsInfo == null )
                iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
            status = iOfferPartsInfo.SearchParts( InPara, ref obRetparts );
            if ( status == 0 )
            {
                partsInfo.Clear();
                partsInfo.SearchMethod = 1; // 結合元検索は品番検索扱いとする。
                CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;

                if ( RetPartsSerializeArrayList.Count == 1 )
                {
                    ArrayList lstRstPrm = RetPartsSerializeArrayList[0] as ArrayList;
                    //部品情報設定
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //FillPartsInfo( lstRstPrm, null );
                    FillPartsInfo( lstRstPrm, null, null );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                }
                else if ( RetPartsSerializeArrayList.Count == 2 )
                {
                    ArrayList lstRstPrm = RetPartsSerializeArrayList[0] as ArrayList;
                    ArrayList lstPrmPrice = RetPartsSerializeArrayList[1] as ArrayList;
                    // 優良部品情報設定
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //FillJoinSetParts( true, lstRstPrm, lstPrmPrice, null, null );
                    FillJoinSetParts( true, lstRstPrm, lstPrmPrice, null, null, null );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }

            return status;
        }
        #endregion

        #region [ 検索メソッド(private) ]
        /// <summary>
        /// ユーザーOEM検索対応
        /// </summary>
        /// <param name="partsSearchUIData">検索条件</param>
        /// <returns></returns>
        private int UserOEMSearch(PartsSearchUIData partsSearchUIData)
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            int status = 0;
            ArrayList PrimePartsInfoList = null;
            ArrayList SetPartsInfoList = null;
            ArrayList PrimePriceList = null;
            ArrayList SetPriceList = null;

            string query = string.Format("{0} = false", partsInfo.UsrSubstParts.OfferKubunColumn.ColumnName);
            PartsInfoDataSet.UsrSubstPartsRow[] rowUsrSubst =
                (PartsInfoDataSet.UsrSubstPartsRow[])partsInfo.UsrSubstParts.Select(query);

            ArrayList lst = new ArrayList();
            for (int i = 0; i < rowUsrSubst.Length; i++)
            {
                OfrPartsCondWork clsPrimeParts = new OfrPartsCondWork();
                clsPrimeParts.MakerCode = rowUsrSubst[i].ChgDestMakerCd;
                clsPrimeParts.PrtsNo = rowUsrSubst[i].ChgDestGoodsNo;
                lst.Add(clsPrimeParts);
            }
            if (lst.Count == 0) // 検索用条件リストが0なら終了
                return status;

            //リモート呼び出し
            bool substFlg = true;
            if (partsSearchUIData.PartsNo != string.Empty) // 品番検索の場合
                substFlg = false; // 優良検索時代替検索しない。

            if (iPrimePartsInfoDB == null)
                iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
            int carMakerCd = 0;
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo( substFlg, carMakerCd, lst, out PrimePartsInfoList, out PrimePriceList,
                        out SetPartsInfoList, out SetPriceList );
            if (status == 0 && PrimePartsInfoList != null)
            {
                //データテーブルへリモート取得情報設定
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList);
                FillJoinSetParts( false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList, null );
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            }
            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ユーザーOEM検索対応
        /// </summary>
        /// <param name="partsSearchUIDataDic">検索条件</param>
        /// <returns></returns>
        private int UserOEMSearch(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  
            {
                return 0;
            }

            int status = 0;
            ArrayList PrimePartsInfoList = null;
            ArrayList SetPartsInfoList = null;
            ArrayList PrimePriceList = null;
            ArrayList SetPriceList = null;

            foreach (int key in partsSearchUIDataDic.Keys)
            {
                if (partsSearchUIDataDic[key].SearchCntSetWork.SubstApplyDivCd == 2) // 代替適用全て：ユーザー登録品に関して更に提供検索
                {
                    string query = string.Format("{0} = false", partsInfoDic[key].UsrSubstParts.OfferKubunColumn.ColumnName);
                    PartsInfoDataSet.UsrSubstPartsRow[] rowUsrSubst =
                        (PartsInfoDataSet.UsrSubstPartsRow[])partsInfoDic[key].UsrSubstParts.Select(query);

                    ArrayList lst = new ArrayList();
                    for (int i = 0; i < rowUsrSubst.Length; i++)
                    {
                        OfrPartsCondWork clsPrimeParts = new OfrPartsCondWork();
                        clsPrimeParts.MakerCode = rowUsrSubst[i].ChgDestMakerCd;
                        clsPrimeParts.PrtsNo = rowUsrSubst[i].ChgDestGoodsNo;
                        lst.Add(clsPrimeParts);
                    }
                    if (lst.Count == 0) // 検索用条件リストが0なら終了
                        continue;

                    //リモート呼び出し
                    bool substFlg = true;
                    if (partsSearchUIDataDic[key].PartsNo != string.Empty) // 品番検索の場合
                        substFlg = false; // 優良検索時代替検索しない。

                    if (iPrimePartsInfoDB == null)
                        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
                    int carMakerCd = 0;
                    if (carInfoDataSet != null)
                    {
                        if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                            carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                        else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                            carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
                    }
                    status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo(substFlg, carMakerCd, lst, out PrimePartsInfoList, out PrimePriceList,
                                out SetPartsInfoList, out SetPriceList);
                    if (status == 0 && PrimePartsInfoList != null)
                    {
                        //データテーブルへリモート取得情報設定
                        FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList, null, key);
                    }
                }
            }
            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 商品種別設定
        /// </summary>
        private void SetUsrGoodsKind()
        {
            int cnt = partsInfo.UsrGoodsInfo.Count;
            string filter = string.Empty;
            for (int i = 0; i < cnt; i++)
            {
                //if (partsInfo.UsrGoodsInfo[i].OfferKubun != 0)
                //    continue;
                int makerCd = partsInfo.UsrGoodsInfo[i].GoodsMakerCd;
                string goodsNo = partsInfo.UsrGoodsInfo[i].GoodsNo;

                //partsInfo.UsrGoodsInfo[i].GoodsKind = 0;
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, makerCd,
                    partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, goodsNo);
                if (partsInfo.UsrJoinParts.Select(filter).Length > 0 && (partsInfo.UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Join) != (int)GoodsKind.Join)
                {
                    partsInfo.UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Join;
                }
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, makerCd,
                    partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, goodsNo);
                if (partsInfo.UsrSetParts.Select(filter).Length > 0 && (partsInfo.UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                {
                    partsInfo.UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Set;
                }
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrSubstParts.ChgDestMakerCdColumn.ColumnName, makerCd,
                    partsInfo.UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, goodsNo);
                if (partsInfo.UsrSubstParts.Select(filter).Length > 0 && (partsInfo.UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst
                    && (partsInfo.UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.SubstPlrl) != (int)GoodsKind.SubstPlrl)
                {
                    partsInfo.UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Subst;
                }
                if (partsInfo.UsrGoodsInfo[i].GoodsKind == 0)
                {
                    partsInfo.UsrGoodsInfo[i].GoodsKind = (int)GoodsKind.Parent;
                }
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  商品種別設定
        /// </summary>
        /// <param name="key"></param>
        private void SetUsrGoodsKind(int key)
        {
            int cnt = partsInfoDic[key].UsrGoodsInfo.Count;
            string filter = string.Empty;
            for (int i = 0; i < cnt; i++)
            {
                int makerCd = partsInfoDic[key].UsrGoodsInfo[i].GoodsMakerCd;
                string goodsNo = partsInfoDic[key].UsrGoodsInfo[i].GoodsNo;

                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, makerCd,
                    partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, goodsNo);
                if (partsInfoDic[key].UsrJoinParts.Select(filter).Length > 0 && (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Join) != (int)GoodsKind.Join)
                {
                    partsInfoDic[key].UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Join;
                }
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, makerCd,
                    partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, goodsNo);
                if (partsInfoDic[key].UsrSetParts.Select(filter).Length > 0 && (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                {
                    partsInfoDic[key].UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Set;
                }
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfoDic[key].UsrSubstParts.ChgDestMakerCdColumn.ColumnName, makerCd,
                    partsInfoDic[key].UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, goodsNo);
                if (partsInfoDic[key].UsrSubstParts.Select(filter).Length > 0 && (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst
                    && (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.SubstPlrl) != (int)GoodsKind.SubstPlrl)
                {
                    partsInfoDic[key].UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Subst;
                }
                if (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind == 0)
                {
                    partsInfoDic[key].UsrGoodsInfo[i].GoodsKind = (int)GoodsKind.Parent;
                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # region 部品メーカー名取得
        /// <summary>
        /// 部品メーカー名取得
        /// </summary>
        /// <param name="makerCode">部品メーカコード</param>
        /// <returns>部品メーカー名称</returns>
        private string GetPartsMakerName(int makerCode)
        {
            string makerName = string.Empty;
            if (_PartsMakerList != null && _PartsMakerList.ContainsKey(makerCode))
            {
                makerName = _PartsMakerList[makerCode].MakerName;// PartsMakerFullName;
            }
            return (makerName);
        }
        # endregion

        # region 部品メーカーリスト取得
        private void GetPrimePartsSet(ArrayList lstRet, int makerCd, string partsNo)
        {
            string primePartsListKey = makerCd.ToString("d4") + partsNo;

            if ((makerCd == 0) || (partsNo == string.Empty) || lstClgParts.Contains(primePartsListKey))
            {
                return;
            }

            OfrPartsCondWork clsPrimeParts = new OfrPartsCondWork();
            clsPrimeParts.MakerCode = makerCd;
            clsPrimeParts.PrtsNo = partsNo;

            lstClgParts.Add(primePartsListKey);
            lstRet.Add(clsPrimeParts);
        }
        # endregion

        # region ＢＬコード種別の判別
        /// <summary>
        /// ＢＬコード種別の判別
        /// </summary>
        /// <param name="BlCd"></param>
        /// <param name="primeSearchFlg">0:純正優先　1:優良優先</param>
        /// <returns>0:純正検索 1:優良検索後ヒットなしなら純正検索 2:TBO検索 
        /// 3:純正検索後ヒットなしなら優良検索 -1:BLｺｰﾄﾞ該当なし</returns>
        private int Blkind(int BlCd, int primeSearchFlg)
        {
            int retVal = -1; // 0:純正検索 1:優良検索後ヒットなしなら純正検索 2:TBO検索 3:後ヒットなしなら優良検索 -1:BLｺｰﾄﾞ該当なし

            string filter = string.Empty;
            //if (primeSearchFlg == -1)
            //{
            filter = string.Format("{0} = {1}", bLInfo.TbsPartsCodeColumn.ColumnName, BlCd);
            //}
            //else
            //{
            //    filter = string.Format("{0} = {1} AND {2} = {3}",
            //        bLInfo.TbsPartsCodeColumn.ColumnName, BlCd,
            //        bLInfo.PrimeSearchFlgColumn.ColumnName, primeSearchFlg);
            //}
            BLInfoRow[] blInfoRow = (BLInfoRow[])bLInfo.Select(filter);

            //BLｺｰﾄﾞ該当なし
            if (blInfoRow.Length == 0)
            {
                BLInfoRow[] blRows = (BLInfoRow[])ofrBLInfo.Select(filter); // 全提供ＢＬ検索
                if (blRows.Length > 0 && blRows[0].EquipGenreCode != 0)
                {
                    retVal = 2;
                }
                else if (blRows.Length > 0 && blRows[0].PrimeSearchFlg != 0)
                {
                    if (primeSearchFlg == 0)
                        retVal = 3;
                    else
                        retVal = 1;
                }
                else
                {
                    retVal = -1;
                }
            }
            //優良BL
            else if (blInfoRow[0].PrimeSearchFlg != 0)
            {
                if (primeSearchFlg == 0)
                    retVal = 3;
                else
                    retVal = 1;
            }
            else if (blInfoRow[0].EquipGenreCode != 0)
            {
                retVal = 2;
            }
            //BLｺｰﾄﾞ該当なし
            else
            {
                retVal = 0;
            }

            return (retVal);
        }
        # endregion

        # region 純正部品情報取得
        /// <summary>
        /// 純正部品情報取得
        /// 指定された部品コード、品番に対して部品情報を取得します。
        /// </summary>
        /// <param name="InPara">部品取得パラメータ</param>        
        /// <returns>STATUS</returns>
        private int GetCatalogPartsInf(GetPartsInfPara InPara)
        {
            // -- ADD 2010/05/25 -------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 --------------------------<<<

            int status = 0;

            List<PartsModelLnkWork> partsModelLnkWork = null;
            ArrayList RetPartsInf = null;
            ArrayList Retcolor = null;
            ArrayList Rettrim = null;
            ArrayList Retequip = null;
            ArrayList RetPrtSubst = null;
            // --- ADD m.suzuki 2010/04/28 ---------->>>>>
            ArrayList RetPartsInfFS = null;
            ArrayList RetPrtSubstFS = null;
            ArrayList RetPrimPartsFS = null;
            ArrayList RetPrimPriceFS = null;
            ArrayList RetPrimSetFS = null;
            ArrayList RetPrimSetPriceFS = null;
            // --- ADD m.suzuki 2010/04/28 ----------<<<<<

            object obRetparts = null;
            object obcolor = null;
            object obtrim = null;
            object obequip = null;
            object obpartsSubst = null;
            // --- ADD m.suzuki 2010/04/28 ---------->>>>>
            object obRetpartsFS = null;
            object obpartsSubstFS = null;
            object obRetPrimPartsFS = null;
            object obRetPrimPriceFS = null;
            object obRetPrimSetFS = null;
            object obRetPrimSetPriceFS = null;
            // --- ADD m.suzuki 2010/04/28 ----------<<<<<
            long cnt = 0;
            
            #region サーバー算定
            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                //status = iOfferPartsInfo.GetPartsInf(InPara, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork, out cnt);//20070327 iwa add

                # region [自由検索用 追加条件]
                // 自由検索部品の抽出結果が有る場合のみ、追加条件をセットする。
                // （※追加条件をセットしなかった場合の動作は変更前と同様）
                if ( _freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0 )
                {
                    ArrayList fsParaList = new ArrayList();
                    foreach ( List<FreeSearchPartsSRetWork> retWorkList in _freeSearchPartsSRetDic.Values )
                    {
                        if ( retWorkList != null && retWorkList.Count > 0 )
                        {
                            // 品番・メーカー条件セット(１つ単位)
                            // 　⇒List内は同一品番・メーカーで格納しているので[0]番目の
                            //     品番・メーカーだけセットして次のリストに進む。
                            OfrPrtsSrchCndWork ofrCndWork = new OfrPrtsSrchCndWork();
                            ofrCndWork.PrtsNo = retWorkList[0].GoodsNo;
                            ofrCndWork.MakerCode = retWorkList[0].GoodsMakerCd;
                            fsParaList.Add( ofrCndWork );
                        }
                    }
                    InPara.SearchKeyList = fsParaList;
                }
                # endregion

                status = iOfferPartsInfo.GetPartsInf( InPara, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork,
                                                      ref obRetpartsFS, ref obpartsSubstFS,
                                                      ref obRetPrimPartsFS, ref obRetPrimPriceFS, ref obRetPrimSetFS, ref obRetPrimSetPriceFS,
                                                      out cnt );
                // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                if (status == 0)
                {
                    CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;
                    CustomSerializeArrayList colorSerializeArrayList = obcolor as CustomSerializeArrayList;
                    CustomSerializeArrayList trimSerializeArrayList = obtrim as CustomSerializeArrayList;
                    CustomSerializeArrayList equipSerializeArrayList = obequip as CustomSerializeArrayList;
                    CustomSerializeArrayList substSerializeArrayList = obpartsSubst as CustomSerializeArrayList;

                    if (RetPartsSerializeArrayList.Count != 0)
                        RetPartsInf = (ArrayList)RetPartsSerializeArrayList[0];
                    if (colorSerializeArrayList.Count != 0)
                        Retcolor = (ArrayList)colorSerializeArrayList[0];
                    if (trimSerializeArrayList.Count != 0)
                        Rettrim = (ArrayList)trimSerializeArrayList[0];
                    if (equipSerializeArrayList.Count != 0)
                        Retequip = (ArrayList)equipSerializeArrayList[0];
                    if (substSerializeArrayList.Count != 0)
                        RetPrtSubst = (ArrayList)substSerializeArrayList[0];

                    //部品情報設定
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //FillPartsInfo(RetPartsInf, partsModelLnkWork);
                    FillPartsInfo( RetPartsInf, partsModelLnkWork, InPara );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<

                    //カラー情報設定
                    FillOfrColorTable(Retcolor);

                    //トリム情報設定
                    FillOfrTrimTable(Rettrim);

                    //装備情報設定
                    FillOfrEquipTable(Retequip);

                    if (RetPrtSubst != null)
                    {
                        string partsName = partsInfo.PartsInfo[0].PartsName;
                        string partsNameKana = partsInfo.PartsInfo[0].PartsNameKana;
                        int tbsPartsCdDerivedNo = partsInfo.PartsInfo[0].TbsPartsCdDerivedNo; // 2010/02/25 Add
                        //代替情報設定
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillOfrSubstTable(RetPrtSubst, partsName, partsNameKana);
                        FillOfrSubstTable( RetPrtSubst, partsName, partsNameKana, InPara );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                    }
                }

                // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                # region [自由検索抽出結果の展開]
                // ディクショナリのnull・件数チェックでオプションチェックも兼ねる
                if ( _freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0 )
                {
                    //--------------------------------------------------
                    // 自由検索部品＋提供純正
                    //--------------------------------------------------
                    # region [提供純正]
                    _retPartsInfDic = new Dictionary<string, RetPartsInf>();

                    // 提供純正の抽出結果をディクショナリに格納する。
                    RetPartsInfFS = GetRetList( obRetpartsFS );
                    if ( RetPartsInfFS != null )
                    {
                        foreach ( RetPartsInf partsInf in RetPartsInfFS )
                        {
                            string key = CreateFreeSearchRetDicKey( partsInf.CatalogPartsMakerCd, partsInf.ClgPrtsNoWithHyphen );
                            if ( !_retPartsInfDic.ContainsKey( key ) )
                            {
                                _retPartsInfDic.Add( key, partsInf );
                            }
                        }
                    }
                    # endregion

                    //--------------------------------------------------
                    // 自由検索部品＋提供優良
                    //--------------------------------------------------
                    # region [提供優良]
                    _primPartsRetDic = new Dictionary<string, OfferJoinPartsRetWork>();

                    // 提供優良の抽出結果をディクショナリに格納する。
                    RetPrimPartsFS = GetRetList( obRetPrimPartsFS );
                    if ( RetPrimPartsFS != null )
                    {
                        foreach ( OfferJoinPartsRetWork partsInf in RetPrimPartsFS )
                        {
                            string key = CreateFreeSearchRetDicKey( partsInf.JoinDestMakerCd, partsInf.JoinDestPartsNo );
                            if ( !_primPartsRetDic.ContainsKey( key ) )
                            {
                                _primPartsRetDic.Add( key, partsInf );
                            }
                        }
                    }
                    # endregion

                    # region [提供優良価格]
                    _primPriceRetDic = new Dictionary<string, List<OfferJoinPriceRetWork>>();

                    // 提供優良の抽出結果をディクショナリに格納する。
                    RetPrimPriceFS = GetRetList( obRetPrimPriceFS );
                    if ( RetPrimPriceFS != null )
                    {
                        foreach ( OfferJoinPriceRetWork partsInf in RetPrimPriceFS )
                        {
                            // このタイミングで価格開始日をチェックする（未来の日付の価格は除外する為）
                            if ( partsInf.PriceStartDate > InPara.PriceDate )
                            {
                                continue;
                            }

                            string key = CreateFreeSearchRetDicKey( partsInf.PartsMakerCd, partsInf.PrimePartsNoWithH );
                            if ( !_primPriceRetDic.ContainsKey( key ) )
                            {
                                _primPriceRetDic.Add( key, new List<OfferJoinPriceRetWork>() );
                            }
                            _primPriceRetDic[key].Add( partsInf );
                        }
                    }
                    # endregion

                    //--------------------------------------------------
                    // 自由検索部品抽出結果の展開
                    //--------------------------------------------------
                    FillFreeSearchPartsInfo( _freeSearchPartsSRetDic );

                    //--------------------------------------------------
                    // 自由検索＋純正代替の展開
                    //--------------------------------------------------
                    # region [自由検索＋純正代替]
                    RetPrtSubstFS = GetRetList( obpartsSubstFS );
                    if ( RetPrtSubstFS != null )
                    {
                        // 代替情報設定
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillOfrSubstTable( RetPrtSubstFS, _freeSearchPartsSRetWork.BLGoodsFullName, _freeSearchPartsSRetWork.BLGoodsFullName );
                        FillOfrSubstTable( RetPrtSubstFS, _freeSearchPartsSRetWork.BLGoodsFullName, _freeSearchPartsSRetWork.BLGoodsFullName, InPara );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<

                        // 代替情報を元に保持しているデータテーブルを更新する
                        ReflectTableByPartsSubst( RetPrtSubstFS );
                    }
                    # endregion

                    //--------------------------------------------------
                    // 自由検索＋セットの展開
                    //--------------------------------------------------
                    # region [自由検索＋セット]
                    RetPrimSetFS = GetRetList( obRetPrimSetFS );
                    RetPrimSetPriceFS = GetRetList( obRetPrimSetPriceFS );

                    if ( RetPrimSetFS != null && RetPrimSetPriceFS != null )
                    {
                        // セット・セット価格展開
                        FillOfrSetInfo( RetPrimSetFS, RetPrimSetPriceFS );
                    }
                    # endregion

                }
                # endregion
                // --- UPD m.suzuki 2010/04/28 ----------<<<<<

            }
            catch
            {

            }
            #endregion

            return status;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 純正部品情報取得
        /// 指定された部品コード、品番に対して部品情報を取得します。
        /// </summary>
        /// <param name="InParaDic">部品取得パラメータ</param>        
        /// <returns>STATUS</returns>
        private int GetCatalogPartsInf(Dictionary<int, GetPartsInfPara> InParaDic)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }

            int status = 0;
            // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№16.純正品検索改良対応 ---------------------------------->>>>>
            //GetPartsInfPara InPara;
            ArrayList inParaList = new ArrayList();
            // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№16.純正品検索改良対応 ----------------------------------<<<<<

            List<PartsModelLnkWork> partsModelLnkWork = null;
            ArrayList RetPartsInf = null;
            ArrayList Retcolor = null;
            ArrayList Rettrim = null;
            ArrayList Retequip = null;
            ArrayList RetPrtSubst = null;
            ArrayList RetPartsInfFS = null;
            ArrayList RetPrtSubstFS = null;
            ArrayList RetPrimPartsFS = null;
            ArrayList RetPrimPriceFS = null;
            ArrayList RetPrimSetFS = null;
            ArrayList RetPrimSetPriceFS = null;

            object obRetparts = null;
            object obcolor = null;
            object obtrim = null;
            object obequip = null;
            object obpartsSubst = null;
            object obRetpartsFS = null;
            object obpartsSubstFS = null;
            object obRetPrimPartsFS = null;
            object obRetPrimPriceFS = null;
            object obRetPrimSetFS = null;
            object obRetPrimSetPriceFS = null;
            long cnt = 0;

            #region サーバー算定
            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№16.純正品検索改良対応 ---------------------------------->>>>>
                #region 速度改善のため削除
                //foreach (int dickey in InParaDic.Keys)
                //{
                //    InPara = InParaDic[dickey];

                //    # region [自由検索用 追加条件]
                //    // 自由検索部品の抽出結果が有る場合のみ、追加条件をセットする。
                //    // （※追加条件をセットしなかった場合の動作は変更前と同様）
                //    if (_freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0)
                //    {
                //        ArrayList fsParaList = new ArrayList();
                //        foreach (KeyValuePair<string, List<FreeSearchPartsSRetWork>> retWorkList in _freeSearchPartsSRetDic)
                //        {
                //            if (retWorkList.Key.Substring(0,2) == dickey.ToString("00") &&
                //                retWorkList.Value != null && retWorkList.Value.Count > 0)
                //            {
                //                // 品番・メーカー条件セット(１つ単位)
                //                // 　⇒List内は同一品番・メーカーで格納しているので[0]番目の
                //                //     品番・メーカーだけセットして次のリストに進む。
                //                OfrPrtsSrchCndWork ofrCndWork = new OfrPrtsSrchCndWork();
                //                List<FreeSearchPartsSRetWork> List = retWorkList.Value;
                //                ofrCndWork.PrtsNo = List[0].GoodsNo;
                //                ofrCndWork.MakerCode = List[0].GoodsMakerCd;
                //                fsParaList.Add(ofrCndWork);
                //            }
                //        }
                //        InPara.SearchKeyList = fsParaList;
                //    }
                //    # endregion

                //    status = iOfferPartsInfo.GetPartsInf(InPara, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork,
                //                                          ref obRetpartsFS, ref obpartsSubstFS,
                //                                          ref obRetPrimPartsFS, ref obRetPrimPriceFS, ref obRetPrimSetFS, ref obRetPrimSetPriceFS,
                //                                          out cnt);
                //    if (status == 0)
                //    {
                //        CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;
                //        CustomSerializeArrayList colorSerializeArrayList = obcolor as CustomSerializeArrayList;
                //        CustomSerializeArrayList trimSerializeArrayList = obtrim as CustomSerializeArrayList;
                //        CustomSerializeArrayList equipSerializeArrayList = obequip as CustomSerializeArrayList;
                //        CustomSerializeArrayList substSerializeArrayList = obpartsSubst as CustomSerializeArrayList;

                //        if (RetPartsSerializeArrayList.Count != 0)
                //            RetPartsInf = (ArrayList)RetPartsSerializeArrayList[0];
                //        if (colorSerializeArrayList.Count != 0)
                //            Retcolor = (ArrayList)colorSerializeArrayList[0];
                //        if (trimSerializeArrayList.Count != 0)
                //            Rettrim = (ArrayList)trimSerializeArrayList[0];
                //        if (equipSerializeArrayList.Count != 0)
                //            Retequip = (ArrayList)equipSerializeArrayList[0];
                //        if (substSerializeArrayList.Count != 0)
                //            RetPrtSubst = (ArrayList)substSerializeArrayList[0];

                //        // ADD 2014/04/17 SCM自動回答処理速度改善 ｼｽﾃﾑﾃｽﾄ障害№77対応 -------------------------------->>>>>
                //        try
                //        {
                //        // ADD 2014/04/17 SCM自動回答処理速度改善 ｼｽﾃﾑﾃｽﾄ障害№77対応 --------------------------------<<<<<
                //            //部品情報設定
                //            FillPartsInfo(RetPartsInf, partsModelLnkWork, InPara, dickey);

                //            //カラー情報設定
                //            FillOfrColorTable(Retcolor, dickey);

                //            //トリム情報設定
                //            FillOfrTrimTable(Rettrim, dickey);

                //            //装備情報設定
                //            FillOfrEquipTable(Retequip, dickey);

                //            if (RetPrtSubst != null)
                //            {
                //                string partsName = partsInfoDic[dickey].PartsInfo[0].PartsName;
                //                string partsNameKana = partsInfoDic[dickey].PartsInfo[0].PartsNameKana;
                //                int tbsPartsCdDerivedNo = partsInfoDic[dickey].PartsInfo[0].TbsPartsCdDerivedNo;
                //                //代替情報設定
                //                FillOfrSubstTable(RetPrtSubst, partsName, partsNameKana, InPara, dickey);
                //            }
                //        // ADD 2014/04/17 SCM自動回答処理速度改善 ｼｽﾃﾑﾃｽﾄ障害№77対応 -------------------------------->>>>>
                //        }
                //        catch
                //        {
                //            continue;
                //        }
                //        // ADD 2014/04/17 SCM自動回答処理速度改善 ｼｽﾃﾑﾃｽﾄ障害№77対応 --------------------------------<<<<<
                //    }

                //    # region [自由検索抽出結果の展開]
                //    // ディクショナリのnull・件数チェックでオプションチェックも兼ねる
                //    if (_freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0 &&
                //        InPara.SearchKeyList != null && InPara.SearchKeyList.Count != 0)
                //    {
                //        //--------------------------------------------------
                //        // 自由検索部品＋提供純正
                //        //--------------------------------------------------
                //        # region [提供純正]
                //        _retPartsInfDic = new Dictionary<string, RetPartsInf>();

                //        // 提供純正の抽出結果をディクショナリに格納する。
                //        RetPartsInfFS = GetRetList(obRetpartsFS);
                //        if (RetPartsInfFS != null)
                //        {
                //            foreach (RetPartsInf partsInf in RetPartsInfFS)
                //            {
                //                string key = CreateFreeSearchRetDicKey(dickey, partsInf.CatalogPartsMakerCd, partsInf.ClgPrtsNoWithHyphen);
                //                if (!_retPartsInfDic.ContainsKey(key))
                //                {
                //                    _retPartsInfDic.Add(key, partsInf);
                //                }
                //            }
                //        }
                //        # endregion

                //        //--------------------------------------------------
                //        // 自由検索部品＋提供優良
                //        //--------------------------------------------------
                //        # region [提供優良]
                //        _primPartsRetDic = new Dictionary<string, OfferJoinPartsRetWork>();

                //        // 提供優良の抽出結果をディクショナリに格納する。
                //        RetPrimPartsFS = GetRetList(obRetPrimPartsFS);
                //        if (RetPrimPartsFS != null)
                //        {
                //            foreach (OfferJoinPartsRetWork partsInf in RetPrimPartsFS)
                //            {
                //                string key = CreateFreeSearchRetDicKey(dickey, partsInf.JoinDestMakerCd, partsInf.JoinDestPartsNo);
                //                if (!_primPartsRetDic.ContainsKey(key))
                //                {
                //                    _primPartsRetDic.Add(key, partsInf);
                //                }
                //            }
                //        }
                //        # endregion

                //        # region [提供優良価格]
                //        _primPriceRetDic = new Dictionary<string, List<OfferJoinPriceRetWork>>();

                //        // 提供優良の抽出結果をディクショナリに格納する。
                //        RetPrimPriceFS = GetRetList(obRetPrimPriceFS);
                //        if (RetPrimPriceFS != null)
                //        {
                //            foreach (OfferJoinPriceRetWork partsInf in RetPrimPriceFS)
                //            {
                //                // このタイミングで価格開始日をチェックする（未来の日付の価格は除外する為）
                //                if (partsInf.PriceStartDate > InPara.PriceDate)
                //                {
                //                    continue;
                //                }

                //                string key = CreateFreeSearchRetDicKey(dickey, partsInf.PartsMakerCd, partsInf.PrimePartsNoWithH);
                //                if (!_primPriceRetDic.ContainsKey(key))
                //                {
                //                    _primPriceRetDic.Add(key, new List<OfferJoinPriceRetWork>());
                //                }
                //                _primPriceRetDic[key].Add(partsInf);
                //            }
                //        }
                //        # endregion

                //        //--------------------------------------------------
                //        // 自由検索部品抽出結果の展開
                //        //--------------------------------------------------
                //        FillFreeSearchPartsInfo(_freeSearchPartsSRetDic, dickey);

                //        //--------------------------------------------------
                //        // 自由検索＋純正代替の展開
                //        //--------------------------------------------------
                //        # region [自由検索＋純正代替]
                //        RetPrtSubstFS = GetRetList(obpartsSubstFS);
                //        if (RetPrtSubstFS != null)
                //        {
                //            // 代替情報設定
                //            FillOfrSubstTable(RetPrtSubstFS, _freeSearchPartsSRetWork.BLGoodsFullName, _freeSearchPartsSRetWork.BLGoodsFullName, InPara, dickey);

                //            // 代替情報を元に保持しているデータテーブルを更新する
                //            ReflectTableByPartsSubst(RetPrtSubstFS, dickey);
                //        }
                //        # endregion

                //        //--------------------------------------------------
                //        // 自由検索＋セットの展開
                //        //--------------------------------------------------
                //        # region [自由検索＋セット]
                //        RetPrimSetFS = GetRetList(obRetPrimSetFS);
                //        RetPrimSetPriceFS = GetRetList(obRetPrimSetPriceFS);

                //        if (RetPrimSetFS != null && RetPrimSetPriceFS != null)
                //        {
                //            // セット・セット価格展開
                //            FillOfrSetInfo(RetPrimSetFS, RetPrimSetPriceFS, dickey);
                //        }
                //        # endregion
                //    }
                //    # endregion
                //}
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                #endregion //速度改善のため削除

                foreach (int dickey in InParaDic.Keys)
                {
                    GetPartsInfPara InPara = InParaDic[dickey];

                    # region [自由検索用 追加条件]
                    // 自由検索部品の抽出結果が有る場合のみ、追加条件をセットする。
                    // （※追加条件をセットしなかった場合の動作は変更前と同様）
                    if (_freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0)
                    {
                        ArrayList fsParaList = new ArrayList();
                        foreach (KeyValuePair<string, List<FreeSearchPartsSRetWork>> retWorkList in _freeSearchPartsSRetDic)
                        {
                            if (retWorkList.Key.Substring(0, 2) == dickey.ToString("00") &&
                                retWorkList.Value != null && retWorkList.Value.Count > 0)
                            {
                                // 品番・メーカー条件セット(１つ単位)
                                // 　⇒List内は同一品番・メーカーで格納しているので[0]番目の
                                //     品番・メーカーだけセットして次のリストに進む。
                                OfrPrtsSrchCndWork ofrCndWork = new OfrPrtsSrchCndWork();
                                List<FreeSearchPartsSRetWork> List = retWorkList.Value;
                                ofrCndWork.PrtsNo = List[0].GoodsNo;
                                ofrCndWork.MakerCode = List[0].GoodsMakerCd;
                                fsParaList.Add(ofrCndWork);
                            }
                        }
                        InPara.SearchKeyList = fsParaList;
                    }
                    # endregion
                    inParaList.Add(InPara);
                }

                status = iOfferPartsInfo.GetPartsInf(inParaList, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork,
                                                      ref obRetpartsFS, ref obpartsSubstFS,
                                                      ref obRetPrimPartsFS, ref obRetPrimPriceFS, ref obRetPrimSetFS, ref obRetPrimSetPriceFS,
                                                      out cnt);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;
                    CustomSerializeArrayList colorSerializeArrayList = obcolor as CustomSerializeArrayList;
                    CustomSerializeArrayList trimSerializeArrayList = obtrim as CustomSerializeArrayList;
                    CustomSerializeArrayList equipSerializeArrayList = obequip as CustomSerializeArrayList;
                    CustomSerializeArrayList substSerializeArrayList = obpartsSubst as CustomSerializeArrayList;

                    List<int> dicKeyList = new List<int>(InParaDic.Keys);

                    if (RetPartsSerializeArrayList != null && RetPartsSerializeArrayList.Count != 0)
                    {
                        for (int i = 0; i < RetPartsSerializeArrayList.Count; i++)
                        {
                            if (RetPartsSerializeArrayList.Count != 0)
                            {
                                RetPartsInf = (ArrayList)RetPartsSerializeArrayList[i];
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<RetPartsInf> retPartsInfwkList = new List<RetPartsInf>((RetPartsInf[])RetPartsInf.ToArray(typeof(RetPartsInf)));
                                if (retPartsInfwkList.Count == 1 && retPartsInfwkList[0].ClgPrtsNoWithHyphen.Trim().Length == 0)
                                {
                                    RetPartsInf = null;
                                }
                            }
                            if (colorSerializeArrayList.Count != 0)
                            {
                                Retcolor = (ArrayList)colorSerializeArrayList[i];
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<PartsColorWork> retcolorwkList = new List<PartsColorWork>((PartsColorWork[])Retcolor.ToArray(typeof(PartsColorWork)));
                                if (retcolorwkList.Count == 1 && retcolorwkList[0].PartsProperNo == 0)
                                {
                                    Retcolor = null;
                                }
                            }
                            if (trimSerializeArrayList.Count != 0)
                            {
                                Rettrim = (ArrayList)trimSerializeArrayList[i];
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<PartsTrimWork> rettrimwkList = new List<PartsTrimWork>((PartsTrimWork[])Rettrim.ToArray(typeof(PartsTrimWork)));
                                if (rettrimwkList.Count == 1 && rettrimwkList[0].PartsProperNo == 0)
                                {
                                    Rettrim = null;
                                }
                            }
                            if (equipSerializeArrayList.Count != 0)
                            {
                                Retequip = (ArrayList)equipSerializeArrayList[i];
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<PartsEquipWork> retequipwkList = new List<PartsEquipWork>((PartsEquipWork[])Retequip.ToArray(typeof(PartsEquipWork)));
                                if (retequipwkList.Count == 1 && retequipwkList[0].PartsProperNo == 0)
                                {
                                    Retequip = null;
                                }
                            }
                            if (substSerializeArrayList.Count != 0)
                            {
                                RetPrtSubst = (ArrayList)substSerializeArrayList[i];
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<PartsSubstWork> retPrtSubstwkList = new List<PartsSubstWork>((PartsSubstWork[])RetPrtSubst.ToArray(typeof(PartsSubstWork)));
                                if (retPrtSubstwkList.Count == 1 && retPrtSubstwkList[0].NewPartsNoWithHyphen.Trim().Length == 0)
                                {
                                    RetPrtSubst = null;
                                }
                            }

                            GetPartsInfPara retInPara = (GetPartsInfPara)inParaList[i];

                            int retdicKey = dicKeyList[i];

                            try
                            {
                                //部品情報設定
                                FillPartsInfo(RetPartsInf, partsModelLnkWork, retInPara, retdicKey);

                                //カラー情報設定
                                FillOfrColorTable(Retcolor, retdicKey);

                                //トリム情報設定
                                FillOfrTrimTable(Rettrim, retdicKey);

                                //装備情報設定
                                FillOfrEquipTable(Retequip, retdicKey);

                                if (RetPrtSubst != null)
                                {
                                    string partsName = partsInfoDic[retdicKey].PartsInfo[0].PartsName;
                                    string partsNameKana = partsInfoDic[retdicKey].PartsInfo[0].PartsNameKana;
                                    int tbsPartsCdDerivedNo = partsInfoDic[retdicKey].PartsInfo[0].TbsPartsCdDerivedNo;
                                    //代替情報設定
                                    FillOfrSubstTable(RetPrtSubst, partsName, partsNameKana, retInPara, retdicKey);
                                }
                            }
                            catch
                            {
                                continue;
                            }

                            # region [自由検索抽出結果の展開]
                            // ディクショナリのnull・件数チェックでオプションチェックも兼ねる
                            if (_freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0 &&
                                retInPara.SearchKeyList != null && retInPara.SearchKeyList.Count != 0)
                            {
                                //--------------------------------------------------
                                // 自由検索部品＋提供純正
                                //--------------------------------------------------
                                # region [提供純正]
                                _retPartsInfDic = new Dictionary<string, RetPartsInf>();

                                // 提供純正の抽出結果をディクショナリに格納する。
                                RetPartsInfFS = GetRetList(obRetpartsFS);
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<RetPartsInf> retPartsInfFSwkList = new List<RetPartsInf>((RetPartsInf[])RetPartsInfFS.ToArray(typeof(RetPartsInf)));
                                if (retPartsInfFSwkList.Count == 1 && retPartsInfFSwkList[0].NewPrtsNoWithHyphen.Trim().Length == 0)
                                {
                                    RetPartsInfFS = null;
                                }
                                if (RetPartsInfFS != null)
                                {
                                    foreach (RetPartsInf partsInf in RetPartsInfFS)
                                    {
                                        string key = CreateFreeSearchRetDicKey(retdicKey, partsInf.CatalogPartsMakerCd, partsInf.ClgPrtsNoWithHyphen);
                                        if (!_retPartsInfDic.ContainsKey(key))
                                        {
                                            _retPartsInfDic.Add(key, partsInf);
                                        }
                                    }
                                }
                                # endregion

                                //--------------------------------------------------
                                // 自由検索部品＋提供優良
                                //--------------------------------------------------
                                # region [提供優良]
                                _primPartsRetDic = new Dictionary<string, OfferJoinPartsRetWork>();

                                // 提供優良の抽出結果をディクショナリに格納する。
                                RetPrimPartsFS = GetRetList(obRetPrimPartsFS);
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<OfferJoinPartsRetWork> retPrimPartsFSwkList = new List<OfferJoinPartsRetWork>((OfferJoinPartsRetWork[])RetPrimPartsFS.ToArray(typeof(OfferJoinPartsRetWork)));
                                if (retPrimPartsFSwkList.Count == 1 && retPrimPartsFSwkList[0].JoinSourPartsNoWithH.Trim().Length == 0)
                                {
                                    RetPrimPartsFS = null;
                                }
                                if (RetPrimPartsFS != null)
                                {
                                    foreach (OfferJoinPartsRetWork partsInf in RetPrimPartsFS)
                                    {
                                        string key = CreateFreeSearchRetDicKey(retdicKey, partsInf.JoinDestMakerCd, partsInf.JoinDestPartsNo);
                                        if (!_primPartsRetDic.ContainsKey(key))
                                        {
                                            _primPartsRetDic.Add(key, partsInf);
                                        }
                                    }
                                }
                                # endregion

                                # region [提供優良価格]
                                _primPriceRetDic = new Dictionary<string, List<OfferJoinPriceRetWork>>();

                                // 提供優良の抽出結果をディクショナリに格納する。
                                RetPrimPriceFS = GetRetList(obRetPrimPriceFS);
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<OfferJoinPriceRetWork> retPrimPriceFSwkList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])RetPrimPriceFS.ToArray(typeof(OfferJoinPriceRetWork)));
                                if (retPrimPriceFSwkList.Count == 1 && retPrimPriceFSwkList[0].PrimePartsNoWithH.Trim().Length == 0)
                                {
                                    RetPrimPriceFS = null;
                                }
                                if (RetPrimPriceFS != null)
                                {
                                    foreach (OfferJoinPriceRetWork partsInf in RetPrimPriceFS)
                                    {
                                        // このタイミングで価格開始日をチェックする（未来の日付の価格は除外する為）
                                        if (partsInf.PriceStartDate > retInPara.PriceDate)
                                        {
                                            continue;
                                        }

                                        string key = CreateFreeSearchRetDicKey(retdicKey, partsInf.PartsMakerCd, partsInf.PrimePartsNoWithH);
                                        if (!_primPriceRetDic.ContainsKey(key))
                                        {
                                            _primPriceRetDic.Add(key, new List<OfferJoinPriceRetWork>());
                                        }
                                        _primPriceRetDic[key].Add(partsInf);
                                    }
                                }
                                # endregion

                                //--------------------------------------------------
                                // 自由検索部品抽出結果の展開
                                //--------------------------------------------------
                                FillFreeSearchPartsInfo(_freeSearchPartsSRetDic, retdicKey);

                                //--------------------------------------------------
                                // 自由検索＋純正代替の展開
                                //--------------------------------------------------
                                # region [自由検索＋純正代替]
                                RetPrtSubstFS = GetRetList(obpartsSubstFS);
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<PartsSubstWork> retPrtSubstFSwkList = new List<PartsSubstWork>((PartsSubstWork[])RetPrtSubstFS.ToArray(typeof(PartsSubstWork)));
                                if (retPrtSubstFSwkList.Count == 1 && retPrtSubstFSwkList[0].NewPartsNoWithHyphen.Trim().Length == 0)
                                {
                                    RetPrtSubstFS = null;
                                }
                                if (RetPrtSubstFS != null)
                                {
                                    // 代替情報設定
                                    FillOfrSubstTable(RetPrtSubstFS, _freeSearchPartsSRetWork.BLGoodsFullName, _freeSearchPartsSRetWork.BLGoodsFullName, retInPara, retdicKey);

                                    // 代替情報を元に保持しているデータテーブルを更新する
                                    ReflectTableByPartsSubst(RetPrtSubstFS, retdicKey);
                                }
                                # endregion

                                //--------------------------------------------------
                                // 自由検索＋セットの展開
                                //--------------------------------------------------
                                # region [自由検索＋セット]
                                RetPrimSetFS = GetRetList(obRetPrimSetFS);
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<OfferSetPartsRetWork> retPrimSetFSwkList = new List<OfferSetPartsRetWork>((OfferSetPartsRetWork[])RetPrimSetFS.ToArray(typeof(OfferSetPartsRetWork)));
                                if (retPrimSetFSwkList.Count == 1 && retPrimSetFSwkList[0].SetMainPartsNo.Trim().Length == 0)
                                {
                                    RetPrimSetFS = null;
                                }
                                RetPrimSetPriceFS = GetRetList(obRetPrimSetPriceFS);
                                // リスト内のデータが１件でコードなしの時null値とする
                                List<OfferJoinPriceRetWork> retPrimSetPriceFSwkList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])RetPrimSetPriceFS.ToArray(typeof(OfferJoinPriceRetWork)));
                                if (retPrimSetPriceFSwkList.Count == 1 && retPrimSetPriceFSwkList[0].PrimePartsNoWithH.Trim().Length == 0)
                                {
                                    RetPrimSetPriceFS = null;
                                }

                                if (RetPrimSetFS != null && RetPrimSetPriceFS != null)
                                {
                                    // セット・セット価格展開
                                    FillOfrSetInfo(RetPrimSetFS, RetPrimSetPriceFS, retdicKey);
                                }
                                # endregion
                            }
                            # endregion

                        }

                    }

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№16.純正品検索改良対応 ----------------------------------<<<<<
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            #endregion

            return status;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        // 2009/11/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 純正部品情報取得
        /// 指定された部品コード、品番に対して部品情報を取得します。
        /// </summary>
        /// <param name="InPara">部品取得パラメータ</param>        
        /// <returns>STATUS</returns>
        private int GetCatalogPartsInf2(GetPartsInfPara InPara)
        {
            // -- ADD 2010/05/25 ------------------------>>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ------------------------<<<

            int status = 0;

            List<PartsModelLnkWork> partsModelLnkWork = null;
            ArrayList RetPartsInf = null;
            ArrayList Retcolor = null;
            ArrayList Rettrim = null;
            ArrayList Retequip = null;
            ArrayList RetPrtSubst = null;

            object obRetparts = null;
            object obcolor = null;
            object obtrim = null;
            object obequip = null;
            object obpartsSubst = null;
            long cnt = 0;

            #region サーバー算定
            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                status = iOfferPartsInfo.GetPartsInf(InPara, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork, out cnt);//20070327 iwa add
                if (status == 0)
                {
                    CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;
                    CustomSerializeArrayList colorSerializeArrayList = obcolor as CustomSerializeArrayList;
                    CustomSerializeArrayList trimSerializeArrayList = obtrim as CustomSerializeArrayList;
                    CustomSerializeArrayList equipSerializeArrayList = obequip as CustomSerializeArrayList;
                    CustomSerializeArrayList substSerializeArrayList = obpartsSubst as CustomSerializeArrayList;

                    if (RetPartsSerializeArrayList.Count != 0)
                        RetPartsInf = (ArrayList)RetPartsSerializeArrayList[0];
                    if (colorSerializeArrayList.Count != 0)
                        Retcolor = (ArrayList)colorSerializeArrayList[0];
                    if (trimSerializeArrayList.Count != 0)
                        Rettrim = (ArrayList)trimSerializeArrayList[0];
                    if (equipSerializeArrayList.Count != 0)
                        Retequip = (ArrayList)equipSerializeArrayList[0];
                    if (substSerializeArrayList.Count != 0)
                        RetPrtSubst = (ArrayList)substSerializeArrayList[0];

                    if ((RetPartsInf != null) && (RetPartsInf.Count != 0))
                    {
                        foreach (RetPartsInf wkPartsInf in RetPartsInf)
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.ClgPrtsNoWithHyphen);

                            #region USR Price
                            if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                                priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                                wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                            {
                                PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                                usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                                // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                //usrPriceRow.ListPrice = wkPartsInf.PartsPrice;
                                double listPrice = wkPartsInf.PartsPrice;
                                this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                                usrPriceRow.ListPrice = listPrice;
                                // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                                usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                                usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                                //usrPriceRow.SalesUnitCost = 0;
                                //usrPriceRow.StockRate = 0;
                                usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                            }
                            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                            if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                                ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                                wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                            {
                                PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                                usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                                double listPrice = wkPartsInf.PartsPrice;
                                this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                                usrPriceRow.ListPrice = listPrice;
                                usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                                usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                                usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                                usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                            }
                            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                            #endregion
                        }
                    }
                }
            }
            catch
            {

            }
            #endregion

            return status;
        }
        // 2009/11/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        # endregion

        # region 提供車輌情報結合検索[TBO(Tire/Battery/Oil)情報]
        /// <summary>
        /// 提供車輌情報結合検索
        /// </summary>
        /// <returns></returns>
        private int GetOfrTBOInfo(PartsSearchUIData partsSearchUIData, int equipGenreCode, string[] equipName)
        {
            ArrayList tboSearchRet = null;
            ArrayList tboSearchURet = new ArrayList();
            ArrayList tboSearchPriceRet = null;

            List<string> list = new List<string>();
            ArrayList lstCond = new ArrayList();
            for (int i = 0; i < carInfoDataSet.CategoryEquipmentInfo.Count; i++)
            {
                if (list.Contains(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName) == false)
                {
                    list.Add(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName);

                    TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
                    tBOSearchUWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
                    tBOSearchUWork.EquipGenreCode = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentGenreCd;
                    tBOSearchUWork.EquipName = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName;
                    lstCond.Add(tBOSearchUWork);
                }
            }

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            tBOSearchCondWork.TbsPartsCode = partsSearchUIData.TbsPartsCode;
            tBOSearchCondWork.EquipName = equipName;
            tBOSearchCondWork.EquipGenreCode = equipGenreCode;


            // -- UPD 2010/05/25 -------------------------------->>>
            //iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

            //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
            //if ((status == 0) && (tboSearchRet.Count > 0))
            //{
            //    FillTBOInfoTable(tboSearchRet, tboSearchPriceRet);
            //}

            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
                iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    FillTBOInfoTable( tboSearchRet, tboSearchPriceRet );
                }
            }
            // -- UPD 2010/05/25 --------------------------------<<<

            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();

            object objTBOSearchUList = tboSearchURet;

            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData0);

            tboSearchURet = objTBOSearchUList as ArrayList;

            PartsSearchUIData partsSearchUIDate = new PartsSearchUIData();
            partsSearchUIDate.EnterpriseCode = partsSearchUIData.EnterpriseCode;
            status = GetUsrGoodsInfForTBO(partsSearchUIData.EnterpriseCode, tboSearchURet);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet);
            }
            return (status);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  提供車輌情報結合検索
        /// </summary>
        /// <param name="partsSearchUIDataDic"></param>
        /// <param name="equipGenreCodeList"></param>
        /// <param name="equipNameList"></param>
        /// <returns></returns>
        private int GetOfrTBOInfo(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic, List<int> equipGenreCodeList, List<string[]> equipNameList)
        {
            ArrayList tboSearchRet = null;
            ArrayList tboSearchURet = new ArrayList();
            ArrayList tboSearchPriceRet = null;

            List<string> list = new List<string>();
            ArrayList lstCond = new ArrayList();
            ArrayList lstCondTemp = new ArrayList();
            List<int> dicKey = new List<int>(partsSearchUIDataDic.Keys);

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            for (int index = 0; index < partsSearchUIDataDic.Count; index++)
            {
                int key = dicKey[index];
                TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
                if (carInfoDataSet != null)
                {
                    if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                        tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                    else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                        tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
                }
                tBOSearchCondWork.TbsPartsCode = partsSearchUIDataDic[key].TbsPartsCode;
                tBOSearchCondWork.EquipName = equipNameList[index];
                tBOSearchCondWork.EquipGenreCode = equipGenreCodeList[index];

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U"))
                {
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                    status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
                    if ((status == 0) && (tboSearchRet.Count > 0))
                    {
                        FillTBOInfoTable(tboSearchRet, tboSearchPriceRet, key);
                    }
                }

                lstCondTemp.Clear();
                for (int i = 0; i < carInfoDataSet.CategoryEquipmentInfo.Count; i++)
                {
                    if (list.Contains(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName) == false)
                    {
                        list.Add(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName);

                        TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
                        tBOSearchUWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                        tBOSearchUWork.EquipGenreCode = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentGenreCd;
                        tBOSearchUWork.EquipName = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName;
                        lstCondTemp.Add(tBOSearchUWork);
                    }
                }
                lstCond.Add(lstCondTemp);
            }

            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();

            object objTBOSearchUList = tboSearchURet;

            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData0);

            tboSearchURet = objTBOSearchUList as ArrayList;

            string enterpriseCode = partsSearchUIDataDic[dicKey[0]].EnterpriseCode;
            status = GetUsrGoodsInfForTBO(enterpriseCode, tboSearchURet, partsSearchUIDataDic);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet, partsSearchUIDataDic);
            }
            return (status);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region 優良部品検索処理＜純正品番をＫＥＹにして優良品番を検索＞
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// 優良部品検索処理＜純正品番をＫＥＹにして優良品番を検索＞
        ///// </summary>
        ///// <param name="primeSubstFlg">優良代替検索フラグ[true:代替検索する／false:代替検索しない]</param>
        //private int GetPrimePartsInf( bool primeSubstFlg )
        private int GetPrimePartsInf( bool primeSubstFlg, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            //変数の初期化
            int status = 0;
            ArrayList PrimePartsInfoList = null;
            ArrayList SetPartsInfoList = null;
            ArrayList PrimePriceList = null;
            ArrayList SetPriceList = null;

            ArrayList RetParts = new ArrayList();
            ArrayList RetSetParts = new ArrayList();
            PrimePartsInfoList = RetParts;
            SetPartsInfoList = RetSetParts;

            ArrayList conList = GetCatalogPartsList();
            if (conList == null || conList.Count == 0)
            {
                return (status);
            }

            //リモート呼び出し
            if (iPrimePartsInfoDB == null)
                iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
            int carMakerCd = 0;
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo( primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
                        out SetPartsInfoList, out SetPriceList );
            if (status == 0 && PrimePartsInfoList != null)
            {
                //データテーブルへリモート取得情報設定
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList);
                FillJoinSetParts( false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList, inPara );
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            }

            return (status);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 優良部品検索処理＜純正品番をＫＥＹにして優良品番を検索＞
        /// </summary>
        /// <param name="primeSubstFlg">優良代替検索フラグ[true:代替検索する／false:代替検索しない]</param>
        /// <param name="inParaDic">検索条件</param>
        private int GetPrimePartsInf(bool primeSubstFlg, Dictionary<int, GetPartsInfPara> inParaDic)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  
            {
                return 0;
            }

            //変数の初期化
            int status = 0;
            // UPD 2014/06/12 PM-SCM速度改良 フェーズ２障害対応 -------------------------------------->>>>>
            //ArrayList PrimePartsInfoList = null;
            //ArrayList SetPartsInfoList = null;
            //ArrayList PrimePriceList = null;
            //ArrayList SetPriceList = null;

            //ArrayList RetParts = new ArrayList();
            //ArrayList RetSetParts = new ArrayList();
            //PrimePartsInfoList = RetParts;
            //SetPartsInfoList = RetSetParts;
            object objPrimePartsInfo = null;
            object objSetPartsInfo = null;
            object objPrimePrice = null;
            object objSetPrice = null;
            // UPD 2014/06/12 PM-SCM速度改良 フェーズ２障害対応 --------------------------------------<<<<<

            // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№17.優良品検索改良対応 ---------------------------------->>>>>
            ArrayList retPrimePartsInfoList = new ArrayList();
            ArrayList retPrimePriceList = new ArrayList();
            ArrayList retSetPartsInfoList = new ArrayList();
            ArrayList retSetPriceList = new ArrayList();
            // ADD 2014/05/13 PM-SCM速度改良 フェーズ２№17.優良品検索改良対応 ----------------------------------<<<<<

            // UPD 2014/05/09 速度改善フェーズ２№11,№12 吉岡 UPD 2014/05/13 PM-SCM速度改良 フェーズ２№17.優良品検索改良対応  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //foreach (int key in inParaDic.Keys)
            //{
            //    ArrayList conList = GetCatalogPartsList(key);
            //    if (conList == null || conList.Count == 0)
            //    {
            //        continue;
            //    }

            //    //リモート呼び出し
            //    if (iPrimePartsInfoDB == null)
            //        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
            //    int carMakerCd = 0;
            //    if (carInfoDataSet != null)
            //    {
            //        if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
            //            carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
            //        else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
            //            carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            //    }
            //    status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo(primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
            //                out SetPartsInfoList, out SetPriceList);
            //    if (status == 0 && PrimePartsInfoList != null)
            //    {
            //        //データテーブルへリモート取得情報設定
            //        FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList, inParaDic[key], key);
            //    }
            //}
            #endregion
            // オファー用自動回答品目設定の生成
            List<object> autoAnsItemStListObj = new List<object>();
            // ADD 2015/04/03 SCM仕掛一覧№10716対応 ------------------------------>>>>>
            // プロパティの自動回答品目設定マスタに値が設定されている時、オファー用自動回答品目設定を生成する
            if (this._foundAutoAnsItemStList != null && this._foundAutoAnsItemStList.Count != 0)
            {
            // ADD 2015/04/03 SCM仕掛一覧№10716対応 ------------------------------<<<<<
                foreach (AutoAnsItemSt tgt in _foundAutoAnsItemStList)
                {
                    if (tgt.LogicalDeleteCode.Equals(1)) continue;
                    List<object> autoAnsItemSt = new List<object>();
                    autoAnsItemSt.Add((object)tgt.SectionCode);     // 拠点コード
                    autoAnsItemSt.Add((object)tgt.CustomerCode);    // 得意先コード
                    autoAnsItemSt.Add((object)tgt.GoodsMGroup);     // 商品中分類コード
                    autoAnsItemSt.Add((object)tgt.BLGoodsCode);     // BL商品コード
                    autoAnsItemSt.Add((object)tgt.GoodsMakerCd);    // 商品メーカーコード
                    autoAnsItemSt.Add((object)tgt.PrmSetDtlNo2);    // 優良設定詳細コード２
                    autoAnsItemSt.Add((object)tgt.AutoAnswerDiv);   // 自動回答区分
                    autoAnsItemSt.Add((object)tgt.PriorityOrder);   // 優先順位
                    autoAnsItemStListObj.Add(autoAnsItemSt);
                }
            } // ADD 2015/04/03 SCM仕掛一覧№10716対応

            // オファー用優先設定の生成
            List<object> prmSettingObj = new List<object>();
            // ADD 2015/04/03 SCM仕掛一覧№10716対応 ------------------------------>>>>>
            // _drPrmSettingWorkはnull値で設定されることはありませんがコーディング上、nullチェック・Countチェックを追加しました
            if (this._drPrmSettingWork != null && this._drPrmSettingWork.Count != 0)
            {
            // ADD 2015/04/03 SCM仕掛一覧№10716対応 ------------------------------<<<<<
                foreach (PrmSettingUWork tgt in _drPrmSettingWork)
                {
                    if (tgt.LogicalDeleteCode.Equals(1)) continue;
                    if (!tgt.SectionCode.Trim().Equals(_sectionCode)) continue;

                    List<object> prmSetting = new List<object>();
                    prmSetting.Add((object)tgt.GoodsMGroup);        // 商品中分類コード
                    prmSetting.Add((object)tgt.TbsPartsCode);       // BLコード
                    prmSetting.Add((object)tgt.PartsMakerCd);       // 部品メーカーコード
                    prmSetting.Add((object)tgt.PrmSetDtlNo1);       // 優良設定詳細コード１
                    prmSetting.Add((object)tgt.PrmSetDtlNo2);       // 優良設定詳細コード２
                    prmSetting.Add((object)tgt.PrimeDisplayCode);   // 優良表示区分プロパティ
                    prmSettingObj.Add(prmSetting);
                }
            } // ADD 2015/04/03 SCM仕掛一覧№10716対応

            try
            {
                //リモート呼び出し
                if (iPrimePartsInfoDB == null)
                    iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();

                //--- DEL 2014/08/14 T.Miyamoto PM-SCM速度改良 フェーズ２-------------------->>>>>
                //// キャッシュ処理
                //iPrimePartsInfoDB.CacheAutoAnswer(this._sectionCodeAutoAnswer, this._customerCode, autoAnsItemStListObj, prmSettingObj);
                //--- DEL 2014/08/14 T.Miyamoto PM-SCM速度改良 フェーズ２--------------------<<<<<

                ArrayList conList = new ArrayList();

                foreach (int key in inParaDic.Keys)
                {
                    ArrayList conListWork = GetCatalogPartsList(key);
                    if (conListWork == null || conListWork.Count == 0)
                    {
                        if (conListWork == null) conListWork = new ArrayList();
                        OfrPartsCondWork work = new OfrPartsCondWork();
                        work.MakerCode = 0;
                        work.PrtsNo = string.Empty;
                        work.PrtsNoOrg = string.Empty;
                        conListWork.Add(work);
                    }

                    conList.Add(conListWork);
                }

                int carMakerCd = 0;
                if (carInfoDataSet != null)
                {
                    if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                        carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                    else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                        carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
                }

                // UPD 2014/06/12 PM-SCM速度改良 フェーズ２障害対応 -------------------------------------->>>>>
                #region 障害対応のため削除
                //status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNoAutoAnswer(primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
                //            out SetPartsInfoList, out SetPriceList);

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && PrimePartsInfoList != null)
                //{
                //    List<int> dicKeyList = new List<int>(inParaDic.Keys);

                //    for (int i = 0; i < dicKeyList.Count; i++)
                //    {
                //        if (PrimePartsInfoList.Count != 0)
                //        {
                //            retPrimePartsInfoList = (ArrayList)PrimePartsInfoList[i];
                //            // リスト内のデータが１件でコードなしの時null値とする
                //            List<OfferJoinPartsRetWork> wkPrimePartsInfoList = new List<OfferJoinPartsRetWork>((OfferJoinPartsRetWork[])retPrimePartsInfoList.ToArray(typeof(OfferJoinPartsRetWork)));
                //            if (wkPrimePartsInfoList.Count == 1 && wkPrimePartsInfoList[0].JoinSourPartsNoWithH.Trim().Length == 0)
                //            {
                //                retPrimePartsInfoList = null;
                //            }
                //            retPrimePriceList = (ArrayList)PrimePriceList[i];
                //            // リスト内のデータが１件でコードなしの時null値とする
                //            List<OfferJoinPriceRetWork> wkPrimePriceList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])retPrimePriceList.ToArray(typeof(OfferJoinPriceRetWork)));
                //            if (wkPrimePriceList.Count == 1 && wkPrimePriceList[0].PrimePartsNoWithH.Trim().Length == 0)
                //            {
                //                retPrimePriceList = null;
                //            }
                //            retSetPartsInfoList = (ArrayList)SetPartsInfoList[i];
                //            // リスト内のデータが１件でコードなしの時null値とする
                //            List<OfferSetPartsRetWork> wkSetPartsInfoList = new List<OfferSetPartsRetWork>((OfferSetPartsRetWork[])retSetPartsInfoList.ToArray(typeof(OfferSetPartsRetWork)));
                //            if (wkSetPartsInfoList.Count == 1 && wkSetPartsInfoList[0].SetMainPartsNo.Trim().Length == 0)
                //            {
                //                retSetPartsInfoList = null;
                //            }
                //            retSetPriceList = (ArrayList)SetPriceList[i];
                //            // リスト内のデータが１件でコードなしの時null値とする
                //            List<OfferJoinPriceRetWork> wkSetPriceList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])retSetPriceList.ToArray(typeof(OfferJoinPriceRetWork)));
                //            if (wkSetPriceList.Count == 1 && wkSetPriceList[0].PrimePartsNoWithH.Trim().Length == 0)
                //            {
                //                retSetPriceList = null;
                //            }
                //        }
                //        //データテーブルへリモート取得情報設定
                //        FillJoinSetParts(false, retPrimePartsInfoList, retPrimePriceList, retSetPartsInfoList, retSetPriceList, inParaDic[i], i);
                //    }
                #endregion // 障害対応のため削除

                //--- UPD 2014/08/14 T.Miyamoto PM-SCM速度改良 フェーズ２-------------------->>>>>
                //status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNoAutoAnswer(primeSubstFlg, carMakerCd, conList, out objPrimePartsInfo, out objPrimePrice,
                //            out objSetPartsInfo, out objSetPrice);
                status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNoAutoAnswer(this._sectionCodeAutoAnswer, this._customerCode, autoAnsItemStListObj, prmSettingObj
                                                                          , primeSubstFlg, carMakerCd, conList
                                                                          , out objPrimePartsInfo, out objPrimePrice, out objSetPartsInfo, out objSetPrice);
                //--- UPD 2014/08/14 T.Miyamoto PM-SCM速度改良 フェーズ２--------------------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && objPrimePartsInfo != null)
                {
                    List<int> dicKeyList = new List<int>(inParaDic.Keys);

                    CustomSerializeArrayList PrimePartsInfoCustomSerializeArrayList = objPrimePartsInfo as CustomSerializeArrayList;
                    CustomSerializeArrayList PrimePriceCustomSerializeArrayList = objPrimePrice as CustomSerializeArrayList;
                    CustomSerializeArrayList SetPartsInfoCustomSerializeArrayList = objSetPartsInfo as CustomSerializeArrayList;
                    CustomSerializeArrayList SetPriceCustomSerializeArrayList = objSetPrice as CustomSerializeArrayList;

                    for (int i = 0; i < dicKeyList.Count; i++)
                    {
                        if (PrimePartsInfoCustomSerializeArrayList != null && PrimePartsInfoCustomSerializeArrayList.Count != 0)
                        {
                            retPrimePartsInfoList = (ArrayList)PrimePartsInfoCustomSerializeArrayList[i];
                            // リスト内のデータが１件でコードなしの時null値とする
                            List<OfferJoinPartsRetWork> wkPrimePartsInfoList = new List<OfferJoinPartsRetWork>((OfferJoinPartsRetWork[])retPrimePartsInfoList.ToArray(typeof(OfferJoinPartsRetWork)));
                            if (wkPrimePartsInfoList.Count == 1 && wkPrimePartsInfoList[0].JoinSourPartsNoWithH.Trim().Length == 0)
                            {
                                retPrimePartsInfoList = null;
                            }
                            retPrimePriceList = (ArrayList)PrimePriceCustomSerializeArrayList[i];
                            // リスト内のデータが１件でコードなしの時null値とする
                            List<OfferJoinPriceRetWork> wkPrimePriceList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])retPrimePriceList.ToArray(typeof(OfferJoinPriceRetWork)));
                            if (wkPrimePriceList.Count == 1 && wkPrimePriceList[0].PrimePartsNoWithH.Trim().Length == 0)
                            {
                                retPrimePriceList = null;
                            }
                            retSetPartsInfoList = (ArrayList)SetPartsInfoCustomSerializeArrayList[i];
                            // リスト内のデータが１件でコードなしの時null値とする
                            List<OfferSetPartsRetWork> wkSetPartsInfoList = new List<OfferSetPartsRetWork>((OfferSetPartsRetWork[])retSetPartsInfoList.ToArray(typeof(OfferSetPartsRetWork)));
                            if (wkSetPartsInfoList.Count == 1 && wkSetPartsInfoList[0].SetMainPartsNo.Trim().Length == 0)
                            {
                                retSetPartsInfoList = null;
                            }
                            retSetPriceList = (ArrayList)SetPriceCustomSerializeArrayList[i];
                            // リスト内のデータが１件でコードなしの時null値とする
                            List<OfferJoinPriceRetWork> wkSetPriceList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])retSetPriceList.ToArray(typeof(OfferJoinPriceRetWork)));
                            if (wkSetPriceList.Count == 1 && wkSetPriceList[0].PrimePartsNoWithH.Trim().Length == 0)
                            {
                                retSetPriceList = null;
                            }
                        }
                        //データテーブルへリモート取得情報設定
                        // UPD 2014/10/16 SCM社内障害一覧№53対応 -------------------------------->>>>>
                        //FillJoinSetParts(false, retPrimePartsInfoList, retPrimePriceList, retSetPartsInfoList, retSetPriceList, inParaDic[i], i);
                        FillJoinSetParts(false, retPrimePartsInfoList, retPrimePriceList, retSetPartsInfoList, retSetPriceList, inParaDic[dicKeyList[i]], dicKeyList[i]);
                        // UPD 2014/10/16 SCM社内障害一覧№53対応 --------------------------------<<<<<
                    }
                }
                // UPD 2014/06/12 PM-SCM速度改良 フェーズ２障害対応 --------------------------------------<<<<<
            }
            catch
            {
            }
            finally
            {
                if (iPrimePartsInfoDB != null)
                {
                    //--- DEL 2014/08/14 T.Miyamoto PM-SCM速度改良 フェーズ２-------------------->>>>>
                    //// キャッシュクリア処理
                    //iPrimePartsInfoDB.CacheClearAutoAnswer();
                    //--- DEL 2014/08/14 T.Miyamoto PM-SCM速度改良 フェーズ２--------------------<<<<<
                }
            }
            // UPD 2014/05/09 速度改善フェーズ２№11,№12 吉岡 UPD 2014/05/13 PM-SCM速度改良 フェーズ２№17.優良品検索改良対応  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return (status);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 優良部品検索リスト取得＜純正品番をＫＥＹにして優良品番を検索＞
        /// </summary>
        private ArrayList GetCatalogPartsList()
        {
            int partsInfoCnt, substPartsCnt, dSubstPartsCnt;
            int cntMax = 0;

            partsInfoCnt = partsInfo.PartsInfo.Count;
            substPartsCnt = partsInfo.SubstPartsInfo.Count;
            dSubstPartsCnt = partsInfo.DSubstPartsInfo.Count;
            cntMax = partsInfoCnt + substPartsCnt + dSubstPartsCnt;
            if (cntMax == 0)
            {
                return null;
            }

            lstClgParts = new List<string>();
            ArrayList lstRet = new ArrayList();

            //部品情報
            for (int ix = 0; ix < partsInfoCnt; ix++)
            {
                //最新品番
                GetPrimePartsSet(lstRet, partsInfo.PartsInfo[ix].CatalogPartsMakerCd, partsInfo.PartsInfo[ix].NewPrtsNoWithHyphen);

                //カタログ品番
                if (partsInfo.PartsInfo[ix].NewPrtsNoWithHyphen != partsInfo.PartsInfo[ix].ClgPrtsNoWithHyphen)
                    GetPrimePartsSet(lstRet, partsInfo.PartsInfo[ix].CatalogPartsMakerCd, partsInfo.PartsInfo[ix].ClgPrtsNoWithHyphen);
            }

            //代替情報
            for (int ix = 0; ix < substPartsCnt; ix++)
            {
                GetPrimePartsSet(lstRet, partsInfo.SubstPartsInfo[ix].CatalogPartsMakerCd, partsInfo.SubstPartsInfo[ix].NewPartsNoWithHyphen);
            }

            //複数代替情報
            for (int ix = 0; ix < dSubstPartsCnt; ix++)
            {
                GetPrimePartsSet(lstRet, partsInfo.DSubstPartsInfo[ix].CatalogPartsMakerCd, partsInfo.DSubstPartsInfo[ix].NewPartsNoWithHyphen);
            }
            return lstRet;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  優良部品検索リスト取得＜純正品番をＫＥＹにして優良品番を検索＞
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private ArrayList GetCatalogPartsList(int key)
        {
            int partsInfoCnt, substPartsCnt, dSubstPartsCnt;
            int cntMax = 0;

            lstClgParts = new List<string>();
            ArrayList lstRet = new ArrayList();

            partsInfoCnt = partsInfoDic[key].PartsInfo.Count;
            substPartsCnt = partsInfoDic[key].SubstPartsInfo.Count;
            dSubstPartsCnt = partsInfoDic[key].DSubstPartsInfo.Count;
            cntMax = partsInfoCnt + substPartsCnt + dSubstPartsCnt;
            // 部品情報・代替情報・複数代替情報のない場合は終了
            if (cntMax == 0)
            {
                return null;
            }

            //部品情報
            for (int ix = 0; ix < partsInfoCnt; ix++)
            {
                //最新品番
                GetPrimePartsSet(lstRet, partsInfoDic[key].PartsInfo[ix].CatalogPartsMakerCd, partsInfoDic[key].PartsInfo[ix].NewPrtsNoWithHyphen);

                //カタログ品番
                if (partsInfoDic[key].PartsInfo[ix].NewPrtsNoWithHyphen != partsInfoDic[key].PartsInfo[ix].ClgPrtsNoWithHyphen)
                    GetPrimePartsSet(lstRet, partsInfoDic[key].PartsInfo[ix].CatalogPartsMakerCd, partsInfoDic[key].PartsInfo[ix].ClgPrtsNoWithHyphen);
            }

            //代替情報
            for (int ix = 0; ix < substPartsCnt; ix++)
            {
                GetPrimePartsSet(lstRet, partsInfoDic[key].SubstPartsInfo[ix].CatalogPartsMakerCd, partsInfoDic[key].SubstPartsInfo[ix].NewPartsNoWithHyphen);
            }

            //複数代替情報
            for (int ix = 0; ix < dSubstPartsCnt; ix++)
            {
                GetPrimePartsSet(lstRet, partsInfoDic[key].DSubstPartsInfo[ix].CatalogPartsMakerCd, partsInfoDic[key].DSubstPartsInfo[ix].NewPartsNoWithHyphen);
            }

            return lstRet;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL ※未使用のようなので削除
        //# region 優良部品点付き検索処理＜純正品番をＫＥＹにして優良品番を検索＞
        ///// <summary>
        ///// 優良部品点付き検索処理＜純正品番をＫＥＹにして優良品番を検索＞
        ///// </summary>
        ///// <param name="priceDate"></param>
        ///// <param name="primeSubstFlg">優良代替検索フラグ</param>
        ///// <param name="MakerCode"></param>
        ///// <param name="PrtsNoWithHyphen"></param>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
        ////private int GetPrimePartsInf(bool primeSubstFlg, int MakerCode, string PrtsNoWithHyphen)
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        //private int GetPrimePartsInf( DateTime priceDate, bool primeSubstFlg, int MakerCode, string PrtsNoWithHyphen )
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        //{
        //    int status = 0;
        //    ArrayList PrimePartsInfoList = null;
        //    ArrayList SetPartsInfoList = null;
        //    ArrayList PrimePriceList = null;
        //    ArrayList SetPriceList = null;

        //    //GetPrimePartsInfPara getPartsInfPara = new GetPrimePartsInfPara();
        //    ArrayList conList = new ArrayList();

        //    OfrPartsCondWork cond = new OfrPartsCondWork();
        //    //品番
        //    cond.PrtsNo = PrtsNoWithHyphen;

        //    //メーカーコード
        //    cond.MakerCode = MakerCode;

        //    conList.Add(cond);

        //    //リモート呼び出し
        //    if (iPrimePartsInfoDB == null)
        //        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
        //    int carMakerCd = 0;
        //    if (carInfoDataSet != null)
        //    {
        //        if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
        //            carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
        //        else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
        //            carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
        //    }
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
        //    //status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo(primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
        //    //    out SetPartsInfoList, out SetPriceList);
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        //    status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo( priceDate, primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
        //        out SetPartsInfoList, out SetPriceList );
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        //    if (status == 0 && PrimePartsInfoList != null)
        //    {
        //        FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList);
        //    }

        //    return (status);
        //}
        //# endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL

        # region 優良品番検索＜優良品番をＫＥＹにして優良品番を検索＞
        /// <summary>
        /// 優良品番検索＜優良品番をＫＥＹにして優良品番を検索＞
        /// </summary>
        /// <returns></returns>
        private int GetPrimePartsInfFromPrimePartsNo(PartsSearchUIData partsNoSearchCond)
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            ArrayList inRetInf;
            ArrayList inPrimePrice;
            ArrayList inRetSetParts;
            ArrayList SetPrice;
            GetPrimePartsInfPara getPartsInfPara = new GetPrimePartsInfPara();

            if (iPrimePartsInfoDB == null)
                iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();

            //メーカーコード
            getPartsInfPara.PartsMakerCode = partsNoSearchCond.PartsMakerCode;

            //優良品番
            getPartsInfPara.PrtsNoNoneHyphen = partsNoSearchCond.PartsNo;

            if (partsNoSearchCond.SearchFlg == SearchFlag.GoodsAndSetInfo || partsNoSearchCond.SearchFlg == SearchFlag.PartsNoJoinSearch)
            {
                getPartsInfPara.SetSearchFlg = 1;
            }
            else
            {
                getPartsInfPara.SetSearchFlg = 0;
            }
            getPartsInfPara.SearchType = (int)partsNoSearchCond.SearchType;

            int status = iPrimePartsInfoDB.GetPartsInf(getPartsInfPara, out inRetInf, out inPrimePrice, out inRetSetParts, out SetPrice);
            if (status == 0 && inRetInf != null)
            {
                // セットフラグが０の場合はセット部品情報のリストは０のため、下記のメソッドで処理してもセット部品は設定されない。
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //FillJoinSetParts(true, inRetInf, inPrimePrice, inRetSetParts, SetPrice);
                FillJoinSetParts(true, inRetInf, inPrimePrice, inRetSetParts, SetPrice, null);
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            }
            return (status);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  優良品番検索＜優良品番をＫＥＹにして優良品番を検索＞
        /// </summary>
        /// <param name="partsNoSearchCondDic"></param>
        /// <returns></returns>
        private int GetPrimePartsInfFromPrimePartsNo(Dictionary<int, PartsSearchUIData> partsNoSearchCondDic)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }

            ArrayList inRetInf;
            ArrayList inPrimePrice;
            ArrayList inRetSetParts;
            ArrayList SetPrice;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                foreach (int key in partsNoSearchCondDic.Keys)
                {
                    GetPrimePartsInfPara getPartsInfPara = new GetPrimePartsInfPara();

                    if (iPrimePartsInfoDB == null)
                        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();

                    //メーカーコード
                    getPartsInfPara.PartsMakerCode = partsNoSearchCondDic[key].PartsMakerCode;

                    //優良品番
                    getPartsInfPara.PrtsNoNoneHyphen = partsNoSearchCondDic[key].PartsNo;

                    if (partsNoSearchCondDic[key].SearchFlg == SearchFlag.GoodsAndSetInfo || partsNoSearchCondDic[key].SearchFlg == SearchFlag.PartsNoJoinSearch)
                    {
                        getPartsInfPara.SetSearchFlg = 1;
                    }
                    else
                    {
                        getPartsInfPara.SetSearchFlg = 0;
                    }
                    getPartsInfPara.SearchType = (int)partsNoSearchCondDic[key].SearchType;

                    status = iPrimePartsInfoDB.GetPartsInf(getPartsInfPara, out inRetInf, out inPrimePrice, out inRetSetParts, out SetPrice);
                    if (status == 0 && inRetInf != null)
                    {
                        // セットフラグが０の場合はセット部品情報のリストは０のため、下記のメソッドで処理してもセット部品は設定されない。
                        FillJoinSetParts(true, inRetInf, inPrimePrice, inRetSetParts, SetPrice, null, key);
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return (status);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region ユーザー検索
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// ユーザー結合検索
        ///// </summary>
        ///// <param name="partsSearchUIData"></param>
        ///// <returns></returns>
        //private int GetUsrGoodsJoinInf(PartsSearchUIData partsSearchUIData)
        /// <summary>
        /// ユーザー結合検索
        /// </summary>
        /// <param name="partsSearchUIData"></param>
        /// <param name="inPara"></param>
        /// <returns></returns>
        private int GetUsrGoodsJoinInf( PartsSearchUIData partsSearchUIData, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            int status = 0;

            object retobj;
            CustomSerializeArrayList arrList;
            ArrayList usrRet = null;

            ArrayList searchCondList = new ArrayList();
            UsrSearchFlg usrSearchFlg;
            if (partsSearchUIData.PartsNo != string.Empty) // 品番検索の場合のユーザー検索条件設定
            {
                switch (partsSearchUIData.SearchFlg)
                {
                    case SearchFlag.GoodsInfoOnly:
                        usrSearchFlg = UsrSearchFlg.UsrPartsOnly;
                        break;
                    case SearchFlag.GoodsAndSetInfo:
                        usrSearchFlg = UsrSearchFlg.UsrPartsAndSet;
                        break;
                    case SearchFlag.PartsNoJoinSearch:
                        if (partsSearchUIData.SearchCntSetWork.SubstApplyDivCd == 0)
                            usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                        else
                            usrSearchFlg = UsrSearchFlg.UsrPartsAndAll;
                        break;
                    default:
                        usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                        break;
                }
            }
            else    // 品番検索以外の場合のユーザー検索条件設定
            {
                if (partsSearchUIData.SearchCntSetWork.SubstApplyDivCd == 0)
                {
                    usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                }
                else
                {
                    usrSearchFlg = UsrSearchFlg.UsrPartsAndAll;
                }
            }
            GetUsrCondList(searchCondList, partsSearchUIData);

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
            // 2009/12/17 >>>
            ////status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)partsSearchUIData.SearchType, searchCondList); // 2009/09/07 DEL
            //status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)partsSearchUIData.SearchType, ConstantManagement.LogicalMode.GetData01, searchCondList); // 2009/09/07 ADD
            status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)partsSearchUIData.SearchType, partsSearchUIData.LogicalMode, searchCondList);
            // 2009/12/17 <<<
            if (status != 0)
            {
                return (status);
            }
            arrList = retobj as CustomSerializeArrayList;

            for (int i = 0; i < arrList.Count; i++)
            {
                usrRet = arrList[i] as ArrayList;
                switch (usrRet[0].GetType().Name)
                {
                    case "UsrPartsSubstRetWork":
                        //ユーザー結合検索:代替情報
                        FillUsrSubstPartsTable(usrRet);
                        break;
                    case "UsrJoinPartsRetWork":
                        //ユーザー結合検索:結合情報
                        FillUsrJoinPartsTable(usrRet);
                        break;
                    case "UsrSetPartsRetWork":
                        //ユーザー結合検索:セット情報
                        FillUsrSetPartsTable(usrRet);
                        break;
                    case "UsrGoodsRetWork":
                        //ユーザー結合検索:商品情報
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillUsrGoodsInfoTable(usrRet);
                        FillUsrGoodsInfoTable( usrRet, inPara );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                        break;
                    case "GoodsPriceUWork":
                        FillUsrGoodsPriceTable(usrRet);
                        break;
                    case "StockWork":
                        FillUsrGoodsStockTable(usrRet);
                        break;
                }
            }
            return (status);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  ユーザー結合検索
        /// </summary>
        /// <param name="partsSearchUIDataDic"></param>
        /// <param name="inParaDic"></param>
        /// <returns></returns>
        private int GetUsrGoodsJoinInf(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic, Dictionary<int, GetPartsInfPara> inParaDic)
        {
            int status = 0;

            ArrayList retobj;
            ArrayList usrRet = null;
            ArrayList usrRetTemp = null;

            ArrayList searchCondList;
            ArrayList usrSearchFlgList;
            ArrayList searchTypeList;
            List<int> dicKeyList = new List<int>(partsSearchUIDataDic.Keys);
            ConstantManagement.LogicalMode logicalMode = partsSearchUIDataDic[dicKeyList[0]].LogicalMode;


            GetUsrCondList(partsSearchUIDataDic, out searchCondList, out usrSearchFlgList, out searchTypeList, out logicalMode);

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

            status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlgList, searchTypeList, logicalMode, searchCondList);
            
            if (status != 0)
            {
                return (status);
            }

            for (int index = 0; index < searchCondList.Count; index++)
            {
                usrRetTemp = retobj[index] as CustomSerializeArrayList;
                int key = dicKeyList[index];

                for (int i = 0; i < usrRetTemp.Count; i++)
                {
                    usrRet = usrRetTemp[i] as ArrayList;

                    if (usrRet.Count != 0)
                    {
                        switch (usrRet[0].GetType().Name)
                        {
                            case "UsrPartsSubstRetWork":
                                //ユーザー結合検索:代替情報
                                FillUsrSubstPartsTable(usrRet, key);
                                break;
                            case "UsrJoinPartsRetWork":
                                //ユーザー結合検索:結合情報
                                FillUsrJoinPartsTable(usrRet, key);
                                break;
                            case "UsrSetPartsRetWork":
                                //ユーザー結合検索:セット情報
                                FillUsrSetPartsTable(usrRet, key);
                                break;
                            case "UsrGoodsRetWork":
                                //ユーザー結合検索:商品情報
                                if (inParaDic == null)
                                    FillUsrGoodsInfoTable(usrRet, null, key);
                                else
                                    FillUsrGoodsInfoTable(usrRet, inParaDic[key], key);
                                break;
                            case "GoodsPriceUWork":
                                FillUsrGoodsPriceTable(usrRet, key);
                                break;
                            case "StockWork":
                                FillUsrGoodsStockTable(usrRet, key);
                                break;
                        }
                    }
                }

            }

            return (status);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// ユーザー結合検索[TBO用]
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tboSearchURet">ユーザーTBOマスタリスト</param>
        /// <returns></returns>
        private int GetUsrGoodsInfForTBO(string enterpriseCode, ArrayList tboSearchURet)
        {
            int status = 0;

            object retobj;
            CustomSerializeArrayList arrList;
            ArrayList usrRet = null;
            UsrPartsNoSearchCondWork usrJoinPartsCondWork;
            ArrayList searchCondList = new ArrayList();
            UsrSearchFlg usrSearchFlg;
            usrSearchFlg = UsrSearchFlg.UsrPartsOnly;

            for (int i = 0; i < partsInfo.UsrGoodsInfo.Count; i++)
            {
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = enterpriseCode;
                usrJoinPartsCondWork.MakerCode = partsInfo.UsrGoodsInfo[i].GoodsMakerCd;
                usrJoinPartsCondWork.PrtsNo = partsInfo.UsrGoodsInfo[i].GoodsNo;
                searchCondList.Add(usrJoinPartsCondWork);
            }
            for (int i = 0; i < tboSearchURet.Count; i++)
            {
                TBOSearchUWork work = tboSearchURet[i] as TBOSearchUWork;
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = enterpriseCode;
                usrJoinPartsCondWork.MakerCode = work.JoinDestMakerCd;
                usrJoinPartsCondWork.PrtsNo = work.JoinDestPartsNo;
                searchCondList.Add(usrJoinPartsCondWork);
            }

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
            status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)SearchType.WholeWord, searchCondList);
            if (status != 0)
            {
                return (status);
            }
            arrList = retobj as CustomSerializeArrayList;

            for (int i = 0; i < arrList.Count; i++)
            {
                usrRet = arrList[i] as ArrayList;
                switch (usrRet[0].GetType().Name)
                {
                    case "UsrGoodsRetWork":
                        //ユーザー結合検索:商品情報
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillUsrGoodsInfoTable(usrRet);
                        FillUsrGoodsInfoTable( usrRet, null );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                        break;
                    case "GoodsPriceUWork":
                        FillUsrGoodsPriceTable(usrRet);
                        break;
                    case "StockWork":
                        FillUsrGoodsStockTable(usrRet);
                        break;
                    case "UsrPartsSubstRetWork":
                        //ユーザー結合検索:代替情報
                        FillUsrSubstPartsTable(usrRet);
                        break;
                }
            }

            return (status);
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  ユーザー結合検索[TBO用]
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="tboSearchURet"></param>
        /// <param name="partsSearchUIDataDic"></param>
        /// <returns></returns>
        private int GetUsrGoodsInfForTBO(string enterpriseCode, ArrayList tboSearchURet, Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            int status = 0;

            object retobj;
            CustomSerializeArrayList arrList;
            ArrayList usrRet = null;
            UsrPartsNoSearchCondWork usrJoinPartsCondWork;
            ArrayList searchCondList = new ArrayList();
            ArrayList searchCondListTemp = new ArrayList();
            UsrSearchFlg usrSearchFlg;
            usrSearchFlg = UsrSearchFlg.UsrPartsOnly;
            List<int> dicKey = new List<int>(partsSearchUIDataDic.Keys);

            for (int index = 0; index < partsSearchUIDataDic.Count; index++)
            {
                int key = dicKey[index];
                for (int i = 0; i < partsInfoDic[key].UsrGoodsInfo.Count; i++)
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = enterpriseCode;
                    usrJoinPartsCondWork.MakerCode = partsInfoDic[key].UsrGoodsInfo[i].GoodsMakerCd;
                    usrJoinPartsCondWork.PrtsNo = partsInfoDic[key].UsrGoodsInfo[i].GoodsNo;
                    searchCondListTemp.Add(usrJoinPartsCondWork);
                }
                ArrayList tboSearchURetTemp = tboSearchURet[index] as ArrayList;
                for (int i = 0; i < tboSearchURetTemp.Count; i++)
                {
                    TBOSearchUWork work = tboSearchURet[i] as TBOSearchUWork;
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = enterpriseCode;
                    usrJoinPartsCondWork.MakerCode = work.JoinDestMakerCd;
                    usrJoinPartsCondWork.PrtsNo = work.JoinDestPartsNo;
                    searchCondListTemp.Add(usrJoinPartsCondWork);
                }
                searchCondList.Add(searchCondListTemp);
            }

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
            status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)SearchType.WholeWord, searchCondList);
            if (status != 0)
            {
                return (status);
            }

            ArrayList retobjList = retobj as ArrayList;

            for (int index = 0; index < partsSearchUIDataDic.Count; index++)
            {
                arrList = retobjList[index] as CustomSerializeArrayList;
                int key = dicKey[index];

                for (int i = 0; i < arrList.Count; i++)
                {
                    usrRet = arrList[i] as ArrayList;
                    switch (usrRet[0].GetType().Name)
                    {
                        case "UsrGoodsRetWork":
                            //ユーザー結合検索:商品情報
                            FillUsrGoodsInfoTable(usrRet, null, key);
                            break;
                        case "GoodsPriceUWork":
                            FillUsrGoodsPriceTable(usrRet, key);
                            break;
                        case "StockWork":
                            FillUsrGoodsStockTable(usrRet, key);
                            break;
                        case "UsrPartsSubstRetWork":
                            //ユーザー結合検索:代替情報
                            FillUsrSubstPartsTable(usrRet, key);
                            break;
                    }
                }
            }

            return (status);
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// ユーザーDB検索条件リスト作成
        /// </summary>
        /// <param name="list"></param>
        /// <param name="partsSearchUIData"></param>
        private void GetUsrCondList(ArrayList list, PartsSearchUIData partsSearchUIData)
        {
            UsrPartsNoSearchCondWork usrJoinPartsCondWork = null;
            if (partsSearchUIData != null && partsSearchUIData.TbsPartsCode == 0) // 品番検索の場合
            {                                                                     // その品番のみの品番検索をユーザーDBでも行うため、
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
                if (partsSearchUIData.PartsMakerCode != 0) // 検索時メーカコード指定がないとき
                {
                    usrJoinPartsCondWork.MakerCode = partsSearchUIData.PartsMakerCode;
                }
                usrJoinPartsCondWork.PrtsNo = partsSearchUIData.PartsNo;
                if (partsSearchUIData.PartsNo != string.Empty
                    && partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(partsSearchUIData.PartsMakerCode, partsSearchUIData.PartsNo) == null)
                    list.Add(usrJoinPartsCondWork);
            }
            if (list.Count == 0) // BL検索又はメーカー指定品番検索の場合、ユーザーDBでの品番検索用にダミー検索値を設定する
            {
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
                usrJoinPartsCondWork.MakerCode = -1;
                usrJoinPartsCondWork.PrtsNo = string.Empty;
                list.Add(usrJoinPartsCondWork);
            }

            for (int i = 0; i < partsInfo.UsrGoodsInfo.Count; i++)
            {
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
                usrJoinPartsCondWork.MakerCode = partsInfo.UsrGoodsInfo[i].GoodsMakerCd;
                usrJoinPartsCondWork.PrtsNo = partsInfo.UsrGoodsInfo[i].GoodsNo;
                list.Add(usrJoinPartsCondWork);
            }
            if (partsSearchUIData.TbsPartsCode != 0) // BL検索の場合
            {
                for (int i = 0; i < partsInfo.JoinParts.Count; i++)
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = partsInfo.JoinParts[i].JoinDestMakerCd;
                    usrJoinPartsCondWork.PrtsNo = partsInfo.JoinParts[i].JoinDestPartsNo;
                    if (list.Contains(usrJoinPartsCondWork) == false)
                        list.Add(usrJoinPartsCondWork);
                }
                for (int i = 0; i < partsInfo.GoodsSet.Count; i++)
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = partsInfo.GoodsSet[i].SetSubMakerCd;
                    usrJoinPartsCondWork.PrtsNo = partsInfo.GoodsSet[i].SetSubPartsNo;
                    if (list.Contains(usrJoinPartsCondWork) == false)
                        list.Add(usrJoinPartsCondWork);
                }
            }
        }
        //ユーザーDBにある商品に関しては提供DBを見ないように仕様が変更され、下記ソースは不要になる。
        ///////////////////////////////////////////////////////////////////////////////////////////

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  ユーザーDB検索条件リスト作成
        /// </summary>
        /// <param name="partsSearchUIDataDic"></param>
        /// <param name="condList"></param>
        /// <param name="flgList"></param>
        /// <param name="typeList"></param>
        /// <param name="logicalMode"></param>
        private void GetUsrCondList(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic, out ArrayList condList, out ArrayList flgList, out ArrayList typeList, out ConstantManagement.LogicalMode logicalMode)
        {
            condList = new ArrayList();
            flgList = new ArrayList();
            typeList = new ArrayList();
            UsrSearchFlg usrSearchFlg;
            logicalMode = ConstantManagement.LogicalMode.GetData0;

            foreach (int key in partsSearchUIDataDic.Keys)
            {
                logicalMode = partsSearchUIDataDic[key].LogicalMode;

                #region ユーザー検索条件設定

                if (partsSearchUIDataDic[key].PartsNo != string.Empty) // 品番検索の場合のユーザー検索条件設定
                {
                    switch (partsSearchUIDataDic[key].SearchFlg)
                    {
                        case SearchFlag.GoodsInfoOnly:
                            usrSearchFlg = UsrSearchFlg.UsrPartsOnly;
                            break;
                        case SearchFlag.GoodsAndSetInfo:
                            usrSearchFlg = UsrSearchFlg.UsrPartsAndSet;
                            break;
                        case SearchFlag.PartsNoJoinSearch:
                            if (partsSearchUIDataDic[key].SearchCntSetWork.SubstApplyDivCd == 0)
                                usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                            else
                                usrSearchFlg = UsrSearchFlg.UsrPartsAndAll;
                            break;
                        default:
                            usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                            break;
                    }
                }
                else    // 品番検索以外の場合のユーザー検索条件設定
                {
                    if (partsSearchUIDataDic[key].SearchCntSetWork.SubstApplyDivCd == 0)
                    {
                        usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                    }
                    else
                    {
                        usrSearchFlg = UsrSearchFlg.UsrPartsAndAll;
                    }
                }
                flgList.Add(usrSearchFlg);

                #endregion

                // 検索タイプ設定
                typeList.Add((object)partsSearchUIDataDic[key].SearchType);

                #region 検索品番設定

                ArrayList condTempList = new ArrayList();

                UsrPartsNoSearchCondWork usrJoinPartsCondWork = null;
                if (partsSearchUIDataDic[key] != null && partsSearchUIDataDic[key].TbsPartsCode == 0) // 品番検索の場合
                {                                                                     // その品番のみの品番検索をユーザーDBでも行うため、
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                    if (partsSearchUIDataDic[key].PartsMakerCode != 0) // 検索時メーカコード指定がないとき
                    {
                        usrJoinPartsCondWork.MakerCode = partsSearchUIDataDic[key].PartsMakerCode;
                    }
                    usrJoinPartsCondWork.PrtsNo = partsSearchUIDataDic[key].PartsNo;
                    if (partsSearchUIDataDic[key].PartsNo != string.Empty
                        && partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(partsSearchUIDataDic[key].PartsMakerCode, partsSearchUIDataDic[key].PartsNo) == null)
                        condTempList.Add(usrJoinPartsCondWork);
                }
                if (condTempList.Count == 0) // BL検索又はメーカー指定品番検索の場合、ユーザーDBでの品番検索用にダミー検索値を設定する
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = -1;
                    usrJoinPartsCondWork.PrtsNo = string.Empty;
                    condTempList.Add(usrJoinPartsCondWork);
                }

                for (int i = 0; i < partsInfoDic[key].UsrGoodsInfo.Count; i++)
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = partsInfoDic[key].UsrGoodsInfo[i].GoodsMakerCd;
                    usrJoinPartsCondWork.PrtsNo = partsInfoDic[key].UsrGoodsInfo[i].GoodsNo;
                    condTempList.Add(usrJoinPartsCondWork);
                }
                if (partsSearchUIDataDic[key].TbsPartsCode != 0) // BL検索の場合
                {
                    for (int i = 0; i < partsInfoDic[key].JoinParts.Count; i++)
                    {
                        usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                        usrJoinPartsCondWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        usrJoinPartsCondWork.MakerCode = partsInfoDic[key].JoinParts[i].JoinDestMakerCd;
                        usrJoinPartsCondWork.PrtsNo = partsInfoDic[key].JoinParts[i].JoinDestPartsNo;
                        if (condTempList.Contains(usrJoinPartsCondWork) == false)
                            condTempList.Add(usrJoinPartsCondWork);
                    }
                    for (int i = 0; i < partsInfoDic[key].GoodsSet.Count; i++)
                    {
                        usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                        usrJoinPartsCondWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        usrJoinPartsCondWork.MakerCode = partsInfoDic[key].GoodsSet[i].SetSubMakerCd;
                        usrJoinPartsCondWork.PrtsNo = partsInfoDic[key].GoodsSet[i].SetSubPartsNo;
                        if (condTempList.Contains(usrJoinPartsCondWork) == false)
                            condTempList.Add(usrJoinPartsCondWork);
                    }
                }
                condList.Add(condTempList);
                #endregion 
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region Datatable情報設定メイン
        # region 車両情報結合情報設定[TBO]
        /// <summary>
        /// 車両情報結合情報設定
        /// </summary>
        /// <param name="tboSearchRet"></param>
        /// <param name="tboSearchPriceRet"></param>
        private void FillTBOInfoTable(ArrayList tboSearchRet, ArrayList tboSearchPriceRet)
        {
            if (partsInfo.TBOInfo.Count > 0)
                partsInfo.TBOInfo.Clear();
            if (tboSearchRet == null)
            {
                return;
            }

            foreach (TBOSearchRetWork wkInf in tboSearchRet)
            {
                if (searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                     && wkInf.JoinDestMakerCd == ct_TactiCd // 部品メーカーがタクティー
                     && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // 車のメーカーがトヨタでない
                {
                    continue;
                }
                //　優良設定絞込処理
                bool tboExcludeFlg = false;
                // 2009.02.12 >>>
                //PrmSettingUWork prmSetting = null;
                //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                //{
                //    tboExcludeFlg = true;
                //}
                //else
                //{
                //    prmSetting = _drPrmSettingWork[prmKey];
                //    if (prmSetting.PrimeDisplayCode == 0) // 優良表示区分が[なし]以外を表示する。
                //        tboExcludeFlg = true;
                //}
                PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);
                if (prmSetting == null)
                {
                    tboExcludeFlg = true;
                }
                else
                {
                    if (prmSetting.PrimeDisplayCode == 0) // 優良表示区分が[なし]以外を表示する。
                        tboExcludeFlg = true;
                }

                // 2009.02.12 <<<
#if !PrimeSet
                tboExcludeFlg = false;
#endif
                if (tboExcludeFlg == false)
                {
                    PartsInfoDataSet.TBOInfoRow row = partsInfo.TBOInfo.NewTBOInfoRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMGroup = wkInf.GoodsMGroup;
                    row.TbsPartsCode = wkInf.TbsPartsCode;
                    row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                    row.EquipGenreCode = wkInf.EquipGenreCode;
                    row.EquipName = wkInf.EquipName;
                    row.EquipSpecialNote = wkInf.EquipSpecialNote;
                    row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                    row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                    row.JoinQty = wkInf.JoinQty;
                    row.PrimePartsName = wkInf.PrimePartsName;
                    row.PrimePartsKanaName = wkInf.PrimePartsKanaName;
                    row.PartsLayerCd = wkInf.PartsLayerCd;
                    row.PartsAttribute = wkInf.PartsAttribute;
                    row.PrimePartsSpecialNote = wkInf.PrimePartsSpecialNote;
                    row.CatalogDeleteFlag = wkInf.CatalogDelteFlag;
                    row.CarInfoJoinDispOrder = wkInf.CarInfoJoinDispOrder;
                    row.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    row.OfferKubun = 1; // 0:ユーザデータ,1:提供データ

                    partsInfo.TBOInfo.AddTBOInfoRow(row);

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                    if (usrRow == null)
                    {
                        usrRow = partsInfo.UsrGoodsInfo.NewUsrGoodsInfoRow();

                        usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                        usrRow.GoodsKind = (int)GoodsKind.Parent;   // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                        usrRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                        usrRow.GoodsMakerNm = row.JoinDestMakerNm;
                        usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                        usrRow.GoodsNo = wkInf.JoinDestPartsNo;
                        usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                        usrRow.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                        // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        usrRow.GoodsSpecialNoteOffer = wkInf.PrimePartsSpecialNote;   // 商品規格・特記事項（提供）
                        // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        usrRow.LogicalDeleteCode = 0;
                        usrRow.OfferKubun = 5;
                        usrRow.DisplayOrder = wkInf.CarInfoJoinDispOrder;
                        usrRow.OfferDate = wkInf.OfferDate;
                        usrRow.OfferDataDiv = 1;
                        usrRow.GoodsName = wkInf.PrimePartsName; // 商品名：デフォルトは部品名
                        usrRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                        usrRow.GoodsOfrName = wkInf.PrimePartsName; // 部品名
                        usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                        usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                        usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                        // 2010/02/25 Add >>>
                        if (wkInf.TbsPartsCdDerivedNo != 0)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                            if ((rows != null) && (rows.Length != 0))
                            {
                                usrRow.GoodsName = usrRow.GoodsName + rows[0].TbsPartsFullName;
                                usrRow.GoodsNameKana = usrRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                usrRow.GoodsOfrName = usrRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                                usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                                usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                            }
                        }
                        // 2010/02/25 Add <<<

                        partsInfo.UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                    }
                }
            }
            if (tboSearchPriceRet == null)
            {
                return;
            }
            foreach (TBOSearchPriceRetWork wkInf in tboSearchPriceRet)
            {
                //PartsInfoDataSet.PriceInfoRow row = partsInfo.PriceInfo.NewPriceInfoRow();
                PartsInfoDataSet.UsrGoodsPriceRow row = priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.PartsMakerCd,
                    wkInf.PriceStartDate, wkInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMakerCd = wkInf.PartsMakerCd;
                    row.GoodsNo = wkInf.PrimePartsNoWithH;
                    row.ListPrice = wkInf.NewPrice;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                row = null;
                row = ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.PartsMakerCd,
                    wkInf.PriceStartDate, wkInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTable.NewUsrGoodsPriceRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMakerCd = wkInf.PartsMakerCd;
                    row.GoodsNo = wkInf.PrimePartsNoWithH;
                    row.ListPrice = wkInf.NewPrice;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        ofrPriceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  車両情報結合情報設定
        /// </summary>
        /// <param name="tboSearchRet"></param>
        /// <param name="tboSearchPriceRet"></param>
        /// <param name="key"></param>
        private void FillTBOInfoTable(ArrayList tboSearchRet, ArrayList tboSearchPriceRet, int key)
        {
            if (partsInfoDic[key].TBOInfo.Count > 0)
                partsInfoDic[key].TBOInfo.Clear();
            if (tboSearchRet == null)
            {
                return;
            }

            foreach (TBOSearchRetWork wkInf in tboSearchRet)
            {
                if (searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                     && wkInf.JoinDestMakerCd == ct_TactiCd // 部品メーカーがタクティー
                     && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // 車のメーカーがトヨタでない
                {
                    continue;
                }
                //　優良設定絞込処理
                bool tboExcludeFlg = false;
                // 2009.02.12 >>>
                //PrmSettingUWork prmSetting = null;
                //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                //{
                //    tboExcludeFlg = true;
                //}
                //else
                //{
                //    prmSetting = _drPrmSettingWork[prmKey];
                //    if (prmSetting.PrimeDisplayCode == 0) // 優良表示区分が[なし]以外を表示する。
                //        tboExcludeFlg = true;
                //}
                PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);
                if (prmSetting == null)
                {
                    tboExcludeFlg = true;
                }
                else
                {
                    if (prmSetting.PrimeDisplayCode == 0) // 優良表示区分が[なし]以外を表示する。
                        tboExcludeFlg = true;
                }

                // 2009.02.12 <<<
#if !PrimeSet
                tboExcludeFlg = false;
#endif
                if (tboExcludeFlg == false)
                {
                    PartsInfoDataSet.TBOInfoRow row = partsInfoDic[key].TBOInfo.NewTBOInfoRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMGroup = wkInf.GoodsMGroup;
                    row.TbsPartsCode = wkInf.TbsPartsCode;
                    row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                    row.EquipGenreCode = wkInf.EquipGenreCode;
                    row.EquipName = wkInf.EquipName;
                    row.EquipSpecialNote = wkInf.EquipSpecialNote;
                    row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                    row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                    row.JoinQty = wkInf.JoinQty;
                    row.PrimePartsName = wkInf.PrimePartsName;
                    row.PrimePartsKanaName = wkInf.PrimePartsKanaName;
                    row.PartsLayerCd = wkInf.PartsLayerCd;
                    row.PartsAttribute = wkInf.PartsAttribute;
                    row.PrimePartsSpecialNote = wkInf.PrimePartsSpecialNote;
                    row.CatalogDeleteFlag = wkInf.CatalogDelteFlag;
                    row.CarInfoJoinDispOrder = wkInf.CarInfoJoinDispOrder;
                    row.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    row.OfferKubun = 1; // 0:ユーザデータ,1:提供データ

                    partsInfoDic[key].TBOInfo.AddTBOInfoRow(row);

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow = partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                    if (usrRow == null)
                    {
                        usrRow = partsInfoDic[key].UsrGoodsInfo.NewUsrGoodsInfoRow();

                        usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                        usrRow.GoodsKind = (int)GoodsKind.Parent;   // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                        usrRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                        usrRow.GoodsMakerNm = row.JoinDestMakerNm;
                        usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                        usrRow.GoodsNo = wkInf.JoinDestPartsNo;
                        usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                        usrRow.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                        // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        usrRow.GoodsSpecialNoteOffer = wkInf.PrimePartsSpecialNote;   // 商品規格・特記事項（提供）
                        // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        usrRow.LogicalDeleteCode = 0;
                        usrRow.OfferKubun = 5;
                        usrRow.DisplayOrder = wkInf.CarInfoJoinDispOrder;
                        usrRow.OfferDate = wkInf.OfferDate;
                        usrRow.OfferDataDiv = 1;
                        usrRow.GoodsName = wkInf.PrimePartsName; // 商品名：デフォルトは部品名
                        usrRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                        usrRow.GoodsOfrName = wkInf.PrimePartsName; // 部品名
                        usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                        usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                        usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                        // 2010/02/25 Add >>>
                        if (wkInf.TbsPartsCdDerivedNo != 0)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                            if ((rows != null) && (rows.Length != 0))
                            {
                                usrRow.GoodsName = usrRow.GoodsName + rows[0].TbsPartsFullName;
                                usrRow.GoodsNameKana = usrRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                usrRow.GoodsOfrName = usrRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                                usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                                usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                            }
                        }
                        // 2010/02/25 Add <<<

                        partsInfoDic[key].UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                    }
                }
            }
            if (tboSearchPriceRet == null)
            {
                return;
            }
            foreach (TBOSearchPriceRetWork wkInf in tboSearchPriceRet)
            {
                //PartsInfoDataSet.PriceInfoRow row = partsInfo.PriceInfo.NewPriceInfoRow();
                PartsInfoDataSet.UsrGoodsPriceRow row = priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.PartsMakerCd,
                    wkInf.PriceStartDate, wkInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = priceTableDic[key].NewUsrGoodsPriceRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMakerCd = wkInf.PartsMakerCd;
                    row.GoodsNo = wkInf.PrimePartsNoWithH;
                    row.ListPrice = wkInf.NewPrice;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        priceTableDic[key].AddUsrGoodsPriceRow(row);
                    }
                }

                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                row = null;
                row = ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.PartsMakerCd,
                    wkInf.PriceStartDate, wkInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTableDic[key].NewUsrGoodsPriceRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMakerCd = wkInf.PartsMakerCd;
                    row.GoodsNo = wkInf.PrimePartsNoWithH;
                    row.ListPrice = wkInf.NewPrice;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// 車両情報結合情報設定(ユーザー)
        /// ユーザーTBO情報の不足情報は商品マスタから取得する
        /// </summary>
        /// <param name="tboSearchRet"></param>
        /// <br>UpdateNote : 2013/03/15　dpp</br>
        /// <br>          　 10901273-00 5月15日配信分（障害以外） Redmine#34377 品番検索結果不具合の修正</br>
        private void FillTBOUInfoTable(ArrayList tboSearchRet)
        {
            if (tboSearchRet == null)
            {
                return;
            }

            foreach (TBOSearchUWork wkInf in tboSearchRet)
            {
                if (searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                     && wkInf.JoinDestMakerCd == ct_TactiCd // 部品メーカーがタクティー
                     && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // 車のメーカーがトヨタでない
                {
                    continue;
                }
                PartsInfoDataSet.UsrGoodsInfoRow rowUsrGoods = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                    wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DEL
                //if (rowUsrGoods == null) // TODO : TBOマスタに登録されているものが商品登録されていない場合はなにもしない。
                //    continue;            //        将来仕様変更の可能性があるため、監視対象とする。
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DEL
                //　優良設定絞込処理
                // 2009.02.12 >>>
                //PrmSettingUWork prmSetting = null;
                //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, rowUsrGoods.GoodsMGroup,
                //        wkInf.BLGoodsCode, wkInf.JoinDestMakerCd);
                //if (_drPrmSettingWork.ContainsKey(prmKey))
                //{
                //    prmSetting = _drPrmSettingWork[prmKey];
                //}
                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DELADD
                //PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, rowUsrGoods.GoodsMGroup, wkInf.BLGoodsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);
                PrmSettingUWork prmSetting; 
                if (rowUsrGoods != null)  prmSetting = SearchPrmSettingUWork(_sectionCode, rowUsrGoods.GoodsMGroup, wkInf.BLGoodsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DELADD
                // 2009.02.12 <<<

                PartsInfoDataSet.TBOInfoRow row = partsInfo.TBOInfo.NewTBOInfoRow();

                //row.GoodsMGroup = rowUsrGoods.GoodsMGroup; // 2009/09/07 DEL
                if (rowUsrGoods != null) row.GoodsMGroup = rowUsrGoods.GoodsMGroup; // 2009/09/07 ADD
                row.TbsPartsCode = wkInf.BLGoodsCode;
                row.EquipGenreCode = wkInf.EquipGenreCode;
                row.EquipName = wkInf.EquipName;
                row.EquipSpecialNote = wkInf.EquipSpecialNote;
                row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                row.JoinQty = wkInf.JoinQty;
                //row.PrimePartsName = rowUsrGoods.GoodsName; // 2009/09/07 DEL
                if (rowUsrGoods != null) row.PrimePartsName = rowUsrGoods.GoodsName; // 2009/09/07 ADD
                //row.PartsLayerCd = rowUsrGoods.GoodsRateRank;
                //row.PartsAttribute = wkInf.PartsAttribute;
                row.PrimePartsSpecialNote = wkInf.EquipSpecialNote;
                //row.CatalogDeleteFlag = wkInf.CatalogDeleteFlag;
                row.CarInfoJoinDispOrder = wkInf.CarInfoJoinDispOrder;
                row.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);

                partsInfo.TBOInfo.AddTBOInfoRow(row);

                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ADD
                if (rowUsrGoods != null) // 既に登録されている場合（提供からの設定がある場合）
                {
                }
                else
                {
                    rowUsrGoods = goodsTable.NewUsrGoodsInfoRow();
                    //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    rowUsrGoods.GoodsMakerCd = wkInf.JoinDestMakerCd;
                    rowUsrGoods.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    rowUsrGoods.GoodsNo = wkInf.JoinDestPartsNo;
                    //rowUsrGoods.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo;// DEL dpp 2013/03/15 Redmine#34377
                    rowUsrGoods.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-","");// ADD dpp 2013/03/15 Redmine#34377
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    rowUsrGoods.DisplayOrder = wkInf.CarInfoJoinDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    //usrRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    rowUsrGoods.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (rowUsrGoods.OfferDate != DateTime.MinValue || rowUsrGoods.OfferDataDiv == 1)
                        rowUsrGoods.OfferKubun = 1; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                    else
                        rowUsrGoods.OfferKubun = 0; // ユーザー登録
                    goodsTable.AddUsrGoodsInfoRow(rowUsrGoods);

                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                        partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                    partsInfo.UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrJoinParts.DefaultView[i][partsInfo.UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                    partsInfo.UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrSetParts.DefaultView[i][partsInfo.UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                }
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ADD
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 車両情報結合情報設定(ユーザー)
        /// ユーザーTBO情報の不足情報は商品マスタから取得する
        /// </summary>
        /// <param name="tboSearchRet"></param>
        /// <param name="partsSearchUIDataDic"></param>
        private void FillTBOUInfoTable(ArrayList tboSearchRet, Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            if (tboSearchRet == null)
            {
                return;
            }

            List<int> dicKey = new List<int>(partsSearchUIDataDic.Keys);

            for (int index = 0; index < partsSearchUIDataDic.Count; index++)
            {
                // １明細分データ取得
                ArrayList tboSearchRetTemp = tboSearchRet[index] as ArrayList;
                int key = dicKey[index];

                foreach (TBOSearchUWork wkInf in tboSearchRet)
                {
                    if (searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                         && wkInf.JoinDestMakerCd == ct_TactiCd // 部品メーカーがタクティー
                         && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // 車のメーカーがトヨタでない
                    {
                        continue;
                    }
                    PartsInfoDataSet.UsrGoodsInfoRow rowUsrGoods = partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                    PrmSettingUWork prmSetting;
                    if (rowUsrGoods != null) prmSetting = SearchPrmSettingUWork(_sectionCode, rowUsrGoods.GoodsMGroup, wkInf.BLGoodsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);

                    PartsInfoDataSet.TBOInfoRow row = partsInfoDic[key].TBOInfo.NewTBOInfoRow();

                    if (rowUsrGoods != null) row.GoodsMGroup = rowUsrGoods.GoodsMGroup;
                    row.TbsPartsCode = wkInf.BLGoodsCode;
                    row.EquipGenreCode = wkInf.EquipGenreCode;
                    row.EquipName = wkInf.EquipName;
                    row.EquipSpecialNote = wkInf.EquipSpecialNote;
                    row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                    row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                    row.JoinQty = wkInf.JoinQty;
                    if (rowUsrGoods != null) row.PrimePartsName = rowUsrGoods.GoodsName;
                    //row.PartsLayerCd = rowUsrGoods.GoodsRateRank;
                    //row.PartsAttribute = wkInf.PartsAttribute;
                    row.PrimePartsSpecialNote = wkInf.EquipSpecialNote;
                    //row.CatalogDeleteFlag = wkInf.CatalogDeleteFlag;
                    row.CarInfoJoinDispOrder = wkInf.CarInfoJoinDispOrder;
                    row.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);

                    partsInfoDic[key].TBOInfo.AddTBOInfoRow(row);

                    if (rowUsrGoods != null) // 既に登録されている場合（提供からの設定がある場合）
                    {
                    }
                    else
                    {
                        rowUsrGoods = goodsTableDic[key].NewUsrGoodsInfoRow();
                        //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                        //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                        //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                        //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                        //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                        //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                        //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                        //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                        rowUsrGoods.GoodsMakerCd = wkInf.JoinDestMakerCd;
                        rowUsrGoods.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                        rowUsrGoods.GoodsNo = wkInf.JoinDestPartsNo;
                        rowUsrGoods.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                        //usrRow.GoodsName = "*";
                        //usrRow.GoodsNameKana = "*";
                        //usrRow.GoodsOfrName = wkInf.GoodsName;
                        //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                        //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                        //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                        rowUsrGoods.DisplayOrder = wkInf.CarInfoJoinDispOrder;
                        //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                        //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                        //usrRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                        //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                        //usrRow.OfferDate = DateTime.Today;
                        rowUsrGoods.GoodsKindCode = 0;
                        //usrRow.Jan = wkInf.Jan;
                        //usrRow.UpdateDate = wkInf.UpdateDate;
                        //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                        //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                        //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                        if (rowUsrGoods.OfferDate != DateTime.MinValue || rowUsrGoods.OfferDataDiv == 1)
                            rowUsrGoods.OfferKubun = 1; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                        else
                            rowUsrGoods.OfferKubun = 0; // ユーザー登録
                        goodsTableDic[key].AddUsrGoodsInfoRow(rowUsrGoods);

                        string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                            partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                            partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                        partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = rowFilter;
                        for (int i = 0; i < partsInfoDic[key].UsrJoinParts.DefaultView.Count; i++)
                        {
                            partsInfoDic[key].UsrJoinParts.DefaultView[i][partsInfoDic[key].UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                        }
                        rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                            partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                            partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                        partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = rowFilter;
                        for (int i = 0; i < partsInfoDic[key].UsrSetParts.DefaultView.Count; i++)
                        {
                            partsInfoDic[key].UsrSetParts.DefaultView[i][partsInfoDic[key].UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                        }
                    }
                }
            }

        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region UI用：優良部品詳細（型式情報）設定
        /// <summary>
        /// UI用：優良部品詳細（型式情報）設定
        /// </summary>
        /// <param name="list"></param>
        private void ListPrimePartsDetail_Tables(ArrayList list)
        {
            // TODO : 優良型式仕様確定後
            //車輌情報→部品詳細（型式情報）設定
            if (list != null)
            {
                //DataView CustomView = new DataView(); //_CarSearchController.CarModelDataTable);
                //DataView PartsDetail_View = new DataView(PartsDetail_Table);
                //string stinf = "";

                foreach (OfferPrimeSearchRetWork wkInf in list)
                {
                    //CustomView.RowFilter = "";
                    // String.Format("{0} = " + wkInf.FullModelFixedNo, PartsDetailInfo.COL_PRTDTL_FULLMODELFIXEDNO);
                    //if (CustomView.Count == 0)
                    //{
                    //    continue;
                    //}
                    //stinf = string.Format("{0} = {1} AND {2} = {3} AND {4} = {5} AND {6} = {7} AND {8} = {9} AND {10} = {11} ", 
                    //    partsInfo.ModelPartsDetail.ModelGradeNmColumn.ColumnName, wkInf.model
                    PartsInfoDataSet.ModelPartsDetailRow[] modelDetailRow =
                        (PartsInfoDataSet.ModelPartsDetailRow[])partsInfo.ModelPartsDetail.Select();

                    ////車輌情報→部品詳細（型式情報）設定
                    //stinf = "{0} = '" + CustomView[0]["COL_MODELGRADENM"] + "'"
                    //    + "  AND {1} = '" + CustomView[0]["COL_BODYNAME"] + "'"
                    //    + "  AND {2} = " + CustomView[0]["COL_DOORCOUNT"]
                    //    + "  AND {3} = '" + CustomView[0]["COL_ENGINEMODELNM"] + "'"
                    //    + "  AND {4} = '" + CustomView[0]["COL_ENGINEDISPLACENM"] + "'"
                    //    + "  AND {5} = '" + CustomView[0]["COL_EDIVNM"] + "'"
                    //    + "  AND {6} = '" + CustomView[0]["COL_TRANSMISSIONNM"] + "'"
                    //    + "  AND {7} = '" + CustomView[0]["COL_SHIFTNM"] + "'"
                    //    + "  AND {8} = " + wkInf.PartsMakerCd
                    //    + "  AND {9} = '" + wkInf.PrimePartsNoWithH + "'"
                    //;

                    //PartsDetail_View.RowFilter = String.Format(stinf
                    //    , PartsDetailInfo.COL_PRTDTL_MODELGRADENM
                    //    , PartsDetailInfo.COL_PRTDTL_BODYNAME
                    //    , PartsDetailInfo.COL_PRTDTL_DOORCOUNT
                    //    , PartsDetailInfo.COL_PRTDTL_ENGINEMODELNM
                    //    , PartsDetailInfo.COL_PRTDTL_ENGINEDISPLACENM
                    //    , PartsDetailInfo.COL_PRTDTL_EDIVNM
                    //    , PartsDetailInfo.COL_PRTDTL_TRANSMISSIONNM
                    //    , PartsDetailInfo.COL_PRTDTL_SHIFTNM
                    //    , PartsDetailInfo.COL_PRTDTL_PARTSMAKERCD
                    //    , PartsDetailInfo.COL_PRTDTL_PARTSNO
                    //);
                    //if (PartsDetail_View.Count != 0)
                    //{
                    //    continue;
                    //}

                    //PartsDetail_View.RowFilter = "";

                    //DataRow srcRow = CustomView[0].Row;
                    //DataRow wkRow = PartsDetail_Table.NewRow();

                    //wkRow[PartsDetailInfo.COL_PRTDTL_PARTS_PARTSUNIQUENO] = 0;

                    //wkRow[PartsDetailInfo.COL_PRTDTL_FULLMODELFIXEDNO] = CustomView[0]["COL_FULLMODELFIXEDNO"]; // TODO
                    //wkRow[PartsDetailInfo.COL_PRTDTL_PARTSMAKERCD] = wkInf.PartsMakerCd;
                    //wkRow[PartsDetailInfo.COL_PRTDTL_PARTSNO] = wkInf.PrimePartsNoWithH;

                    //wkRow[PartsDetailInfo.COL_PRTDTL_DOORCOUNT] = CustomView[0]["COL_DOORCOUNT"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_BODYNAME] = CustomView[0]["COL_BODYNAME"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_MODELGRADENM] = CustomView[0]["COL_MODELGRADENM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ENGINEMODELNM] = CustomView[0]["COL_ENGINEMODELNM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ENGINEDISPLACENM] = CustomView[0]["COL_ENGINEDISPLACENM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_EDIVNM] = CustomView[0]["COL_EDIVNM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_TRANSMISSIONNM] = CustomView[0]["COL_TRANSMISSIONNM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_SHIFTNM] = CustomView[0]["COL_SHIFTNM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC1] = CustomView[0]["COL_ADDICARSPEC1"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC2] = CustomView[0]["COL_ADDICARSPEC2"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC3] = CustomView[0]["COL_ADDICARSPEC3"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC4] = CustomView[0]["COL_ADDICARSPEC4"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC5] = CustomView[0]["COL_ADDICARSPEC5"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC6] = CustomView[0]["COL_ADDICARSPEC6"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE1] = CustomView[0]["COL_ADDICARSPECTITLE1"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE2] = CustomView[0]["COL_ADDICARSPECTITLE2"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE3] = CustomView[0]["COL_ADDICARSPECTITLE3"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE4] = CustomView[0]["COL_ADDICARSPECTITLE4"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE5] = CustomView[0]["COL_ADDICARSPECTITLE5"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE6] = CustomView[0]["COL_ADDICARSPECTITLE6"];

                    //PartsDetail_Table.Rows.Add(wkRow);
                }
            }
        }
        # endregion

        # region 部品情報設定
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        //private void FillPartsInfo(ArrayList retPartsInf, List<PartsModelLnkWork> partsModelLnkWork)
        private void FillPartsInfo( ArrayList retPartsInf, List<PartsModelLnkWork> partsModelLnkWork, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            if (retPartsInf == null)
            {
                return;
            }
            // --- ADD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------>>>>>
            Dictionary<NewKey, RetPartsInf> newPartsInfoDic;
            newPartsInfoDic = new Dictionary<NewKey, RetPartsInf>();
            bool setFlg;
            RetPartsInf newPartsInf;

            // 該当部品の新品番情報（条件のBLコード枝番と異なる）を抽出
            if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0) // BLコード枝番が条件に含まれている場合
            {
                foreach (RetPartsInf wkPartsInf in retPartsInf)
                {
                    NewKey _newKey = new NewKey(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.NewPrtsNoWithHyphen.Trim());
                    if ((inPara.TbsPartsCdDerivedNo == wkPartsInf.TbsPartsCdDerivedNo)                    // 検索条件で指定されたBLコード枝番と同じ
                     && (wkPartsInf.NewPrtsNoWithHyphen.Trim() != wkPartsInf.ClgPrtsNoWithHyphen.Trim())  // 新品番が設定されている
                     && (!newPartsInfoDic.ContainsKey(_newKey)))                                          // 新品番情報未検索
                    {
                        setFlg = false;
                        newPartsInf = null;
                        // 新品番を検索
                        foreach (RetPartsInf chkPartsInf in retPartsInf)
                        {
                            if ((wkPartsInf.CatalogPartsMakerCd == chkPartsInf.CatalogPartsMakerCd) &&
                                (wkPartsInf.NewPrtsNoWithHyphen.Trim() == chkPartsInf.ClgPrtsNoWithHyphen.Trim()))
                            {
                                if (inPara.TbsPartsCdDerivedNo == chkPartsInf.TbsPartsCdDerivedNo)
                                {
                                    // BLコード枝番が条件の枝番と同一の場合検索終了（該当品として抽出されるため不要）
                                    setFlg = false;
                                    break;
                                }
                                else
                                {
                                    // BLコード枝番が条件の枝番と異なる場合、抽出対象として保持
                                    setFlg = true;
                                    newPartsInf = chkPartsInf;
                                }
                            }
                        }
                        if (setFlg)
                        {
                            // 新品番情報を要抽出データとして格納
                            if (!newPartsInfoDic.ContainsKey(_newKey))
                            {
                                newPartsInfoDic.Add(_newKey, newPartsInf);
                            }
                        }
                    }
                }
            }
            // --- ADD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------<<<<<

            foreach (RetPartsInf wkPartsInf in retPartsInf)
            {
                // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                bool derivedNmSetFlag = false;

                // BLコード枝番対応（※BLコード検索時のみ）
                if ( inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0 )
                {
                    // 検索条件で指定された枝番と異なる場合は迂回
                    if ( inPara.TbsPartsCdDerivedNo != wkPartsInf.TbsPartsCdDerivedNo )
                    {
                        // --- UPD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------>>>>>
                        //continue;
                        // 該当部品の新品番として設定されていなければ以降の処理を行わない
                        NewKey _chkKey = new NewKey(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.ClgPrtsNoWithHyphen.Trim());
                        if (!newPartsInfoDic.ContainsKey(_chkKey))
                        {
                            continue;
                        }
                        // --- UPD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------<<<<<
                    }

                    // 抽出条件にBLコード枝番が設定されている場合は、枝番用部品名称を付与する。
                    if ( !string.IsNullOrEmpty( wkPartsInf.PartsName ) ) wkPartsInf.PartsName = wkPartsInf.PartsName + wkPartsInf.TbsPartsCdDerivedNm;
                    if ( !string.IsNullOrEmpty( wkPartsInf.PartsNameKana ) ) wkPartsInf.PartsNameKana = wkPartsInf.PartsNameKana + wkPartsInf.TbsPartsCdDerivedNm;
                    if ( !string.IsNullOrEmpty( wkPartsInf.MakerOfferPartsName ) ) wkPartsInf.MakerOfferPartsName = wkPartsInf.MakerOfferPartsName + wkPartsInf.TbsPartsCdDerivedNm;
                    if ( !string.IsNullOrEmpty( wkPartsInf.MakerOfferPartsKana ) ) wkPartsInf.MakerOfferPartsKana = wkPartsInf.MakerOfferPartsKana + wkPartsInf.TbsPartsCdDerivedNm;
                    derivedNmSetFlag = true;
                }
                // --- ADD m.suzuki 2011/05/18 ----------<<<<<

                #region 部品情報設定
                PartsInfoDataSet.PartsInfoRow partsInfoRow = partsInfo.PartsInfo.NewPartsInfoRow();

                partsInfoRow.OfferDate = wkPartsInf.OfferDate;
                partsInfoRow.PartsSearchCode = wkPartsInf.PartsSearchCode;
                partsInfoRow.PartsNarrowingCode = wkPartsInf.PartsNarrowingCode;
                partsInfoRow.PartsName = wkPartsInf.PartsName;
                partsInfoRow.PartsNameKana = wkPartsInf.PartsNameKana;
                partsInfoRow.PartsCode = wkPartsInf.PartsCode;
                partsInfoRow.WorkOrPartsDivNm = wkPartsInf.WorkOrPartsDivNm;
                partsInfoRow.FullModelFixedNo = wkPartsInf.FullModelFixedNo;
                partsInfoRow.TbsPartsCode = wkPartsInf.TbsPartsCode;
                partsInfoRow.TbsPartsCdDerivedNo = wkPartsInf.TbsPartsCdDerivedNo;
                partsInfoRow.FigshapeNo = wkPartsInf.FigShapeNo;
                partsInfoRow.ModelPrtsAdptYm = wkPartsInf.ModelPrtsAdptYm;
                partsInfoRow.ModelPrtsAblsYm = wkPartsInf.ModelPrtsAblsYm;
                partsInfoRow.ModelPrtsAdptFrameNo = wkPartsInf.ModelPrtsAdptFrameNo;
                partsInfoRow.ModelPrtsAblsFrameNo = wkPartsInf.ModelPrtsAblsFrameNo;
                partsInfoRow.PartsQty = wkPartsInf.PartsQty;
                partsInfoRow.PartsOpNm = wkPartsInf.PartsOpNm;
                partsInfoRow.StandardName = wkPartsInf.StandardName;
                partsInfoRow.CatalogPartsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                partsInfoRow.CatalogPartsMakerNm = GetPartsMakerName(wkPartsInf.CatalogPartsMakerCd);

                partsInfoRow.ClgPrtsNoWithHyphen = wkPartsInf.ClgPrtsNoWithHyphen.Trim();
                if (partsInfoRow.ClgPrtsNoWithHyphen == string.Empty)                   // 本来はあってはいけないケースだが、データの整合性の問題で
                    partsInfoRow.ClgPrtsNoWithHyphen = wkPartsInf.NewPrtsNoWithHyphen;  // 障害を防ぐ目的でこの処理を追加
                partsInfoRow.ColdDistrictsFlag = wkPartsInf.ColdDistrictsFlag;
                partsInfoRow.ColorNarrowingFlag = wkPartsInf.ColorNarrowingFlag;
                partsInfoRow.TrimNarrowingFlag = wkPartsInf.TrimNarrowingFlag;
                partsInfoRow.EquipNarrowingFlag = wkPartsInf.EquipNarrowingFlag;
                partsInfoRow.MakerOfferPartsName = wkPartsInf.MakerOfferPartsName;
                partsInfoRow.PartsLayerCd = wkPartsInf.PartsLayerCd;
                partsInfoRow.PartsUniqueNo = wkPartsInf.PartsUniqueNo;

                partsInfoRow.NewPrtsNoWithHyphen = wkPartsInf.NewPrtsNoWithHyphen;
                partsInfoRow.NewPrtsNoNoneHyphen = wkPartsInf.NewPrtsNoNoneHyphen;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                partsInfoRow.SeriesModel = wkPartsInf.SeriesModel;
                partsInfoRow.CategorySignModel = wkPartsInf.CategorySignModel;
                partsInfoRow.ExhaustGasSign = wkPartsInf.ExhaustGasSign;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD

                // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                // 自動見積部品コード
                partsInfoRow.AutoEstimatePartsCd = wkPartsInf.AutoEstimatePartsCd;
                // BLコード枝番用部品名称
                if ( derivedNmSetFlag )
                {
                    partsInfoRow.TbsPartsCdDerivedNm = wkPartsInf.TbsPartsCdDerivedNm;
                }
                // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                	
                // ADD 2013/02/17 2013/04/10配信 SCM障害№10355対応 ------------------------------->>>>>
                partsInfoRow.PrimeJoinLnkFlg = wkPartsInf.PrimeJoinLnkFlg;
                // ADD 2013/02/17 2013/04/10配信 SCM障害№10355対応 -------------------------------<<<<<

                // --- ADD 2013/03/27 ---------->>>>>
                // VIN生産No.(始期)とVIN生産No.(終期)を格納する
                partsInfoRow.VinProduceStartNo = wkPartsInf.VinProduceStartNo.ToString("000000");
                partsInfoRow.VinProduceEndNo = wkPartsInf.VinProduceEndNo.ToString("000000");
                // --- ADD 2013/03/27 ----------<<<<<

                partsInfo.PartsInfo.AddPartsInfoRow(partsInfoRow);
                #endregion

                #region 商品マスタテーブルに設定
                string partsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                    goodsTable.FindByGoodsMakerCdGoodsNo(wkPartsInf.CatalogPartsMakerCd, partsNo);
                if (usrGoodsRow == null)
                {
                    usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                    usrGoodsRow.BlGoodsCode = wkPartsInf.TbsPartsCode;
                    usrGoodsRow.GoodsKindCode = 0; // 0 : 純正
                    usrGoodsRow.GoodsKind = (int)GoodsKind.Parent; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                    usrGoodsRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    usrGoodsRow.GoodsMakerNm = partsInfoRow.CatalogPartsMakerNm;
                    //usrGoodsRow.GoodsMGroup = 0;
                    usrGoodsRow.GoodsRateRank = wkPartsInf.PartsLayerCd;
                    usrGoodsRow.GoodsNoNoneHyphen = partsInfoRow.ClgPrtsNoWithHyphen.Replace("-", "");
                    usrGoodsRow.QTY = wkPartsInf.PartsQty;
                    usrGoodsRow.GoodsNote1 = wkPartsInf.StandardName; //規格
                    //usrGoodsRow.GoodsNote2 = "";
                    usrGoodsRow.GoodsSpecialNote = wkPartsInf.PartsOpNm;
                    // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    usrGoodsRow.GoodsSpecialNoteOffer = wkPartsInf.PartsOpNm;   // 商品規格・特記事項（提供）
                    // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    usrGoodsRow.OfferDate = wkPartsInf.OfferDate;
                    usrGoodsRow.OfferKubun = 3; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                    //usrGoodsRow.TaxationDivCd = 0;
                    usrGoodsRow.GoodsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                    usrGoodsRow.OfferDataDiv = 1;

                    if (wkPartsInf.MakerOfferPartsName != string.Empty)
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.MakerOfferPartsName; // 商品名：デフォルトは部品名
                        usrGoodsRow.GoodsNameKana = wkPartsInf.MakerOfferPartsKana;
                    }
                    else // 古い部品は名称が取れないので
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.PartsName; // 検索品名
                        usrGoodsRow.GoodsNameKana = wkPartsInf.PartsNameKana;
                    }
                    usrGoodsRow.GoodsOfrName = wkPartsInf.MakerOfferPartsName; // 部品名
                    usrGoodsRow.GoodsOfrNameKana = wkPartsInf.MakerOfferPartsKana;
                    usrGoodsRow.SearchPartsFullName = wkPartsInf.PartsName; // 検索品名
                    usrGoodsRow.SearchPartsHalfName = wkPartsInf.PartsNameKana;
                    usrGoodsRow.SrchPNmAcqrCarMkrCd = wkPartsInf.SrchPNmAcqrCarMkrCd;   // 検索品名取得メーカーコード   // 2009/11/24 Add   
                    // 2009/12/09 Add >>>
                    usrGoodsRow.PartsPriceStDate = wkPartsInf.PartsPriceStDate;
                    // 2009/12/09 Add <<<
                    
                    // 2010/02/25 Add >>>
                    if (wkPartsInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkPartsInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkPartsInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                            usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                            usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }
                    // 2010/02/25 Add <<<
                    partsInfoRow.UsrGoodsInfoRowParentByUsrGoodsInfo_PartsInfo = usrGoodsRow;
                    goodsTable.AddUsrGoodsInfoRow(usrGoodsRow);
                }


                // 2009/12/09 Add >>>
                // BLコード、品名、層別は常に最新のデータを使用する
                if (usrGoodsRow.PartsPriceStDate < wkPartsInf.PartsPriceStDate)
                {
                    // 品名の更新
                    if (!string.IsNullOrEmpty(wkPartsInf.MakerOfferPartsName))
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.MakerOfferPartsName;     // 部品名
                        usrGoodsRow.GoodsNameKana = wkPartsInf.MakerOfferPartsKana;

                        usrGoodsRow.GoodsOfrName = wkPartsInf.MakerOfferPartsName;  // 部品名
                        usrGoodsRow.GoodsOfrNameKana = wkPartsInf.MakerOfferPartsKana;
                    }

                    // BLコードの更新
                    if (wkPartsInf.TbsPartsCode != 0)
                    {
                        usrGoodsRow.BlGoodsCode = wkPartsInf.TbsPartsCode;
                    }

                    usrGoodsRow.GoodsRateRank = wkPartsInf.PartsLayerCd;            // 層別

                    usrGoodsRow.PartsPriceStDate = wkPartsInf.PartsPriceStDate;     // 提供の価格取得日を更新
                }
                // 2009/12/09 Add <<<

                #region USR Price
                if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                    wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //usrPriceRow.ListPrice = wkPartsInf.PartsPrice;
                    double listPrice = wkPartsInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                    //usrPriceRow.SalesUnitCost = 0;
                    //usrPriceRow.StockRate = 0;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                    ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                    wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    double listPrice = wkPartsInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                #endregion
                #endregion

                #region 部品関連型式情報設定
                if (carInfoDataSet != null && partsModelLnkWork != null)
                {
                    PartsInfoDataSet.ModelPartsDetailDataTable modelInfo = partsInfo.ModelPartsDetail;
                    foreach (PartsModelLnkWork wkModelInf in partsModelLnkWork)
                    {
                        if (wkModelInf.PartsProperNo != wkPartsInf.PartsUniqueNo)
                            continue;

                        string select = "FullModelFixedNo in (";
                        for (int i = 0; i < wkModelInf.FullModelFixedNos.Count; i++)
                        {
                            select += wkModelInf.FullModelFixedNos[i].ToString() + ", ";
                        }
                        select.Remove(select.Length - 2);
                        select += ")";

                        PMKEN01010E.CarModelInfoRow[] carModelInfoRows = (PMKEN01010E.CarModelInfoRow[])carInfoDataSet.CarModelInfo.Select(select);

                        //車輌情報→部品詳細（型式情報）設定
                        for (int ix = 0; ix < carModelInfoRows.Length; ix++)
                        {
                            string filter = string.Format("{0} = {1} AND {2} = {3}",
                                modelInfo.PartsUniqueNoColumn.ColumnName, wkModelInf.PartsProperNo,
                                modelInfo.FullModelFixedNoColumn.ColumnName, carModelInfoRows[ix].FullModelFixedNo);
                            PartsInfoDataSet.ModelPartsDetailRow[] row = (PartsInfoDataSet.ModelPartsDetailRow[])modelInfo.Select(filter);
                            if (row.Length > 0)
                                continue;
                            PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = modelInfo.NewModelPartsDetailRow();

                            modelPartsDetailRow.PartsUniqueNo = wkModelInf.PartsProperNo;
                            modelPartsDetailRow.PartsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                            modelPartsDetailRow.PartsNo = wkPartsInf.ClgPrtsNoWithHyphen;

                            modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                            modelPartsDetailRow.DoorCount = carModelInfoRows[ix].DoorCount;
                            modelPartsDetailRow.BodyName = carModelInfoRows[ix].BodyName;
                            modelPartsDetailRow.ModelGradeNm = carModelInfoRows[ix].ModelGradeNm;
                            modelPartsDetailRow.EngineModelNm = carModelInfoRows[ix].EngineModelNm;
                            modelPartsDetailRow.EngineDisplaceNm = carModelInfoRows[ix].EngineDisplaceNm;
                            modelPartsDetailRow.EDivNm = carModelInfoRows[ix].EDivNm;
                            modelPartsDetailRow.TransmissionNm = carModelInfoRows[ix].TransmissionNm;
                            modelPartsDetailRow.ShiftNm = carModelInfoRows[ix].ShiftNm;
                            modelPartsDetailRow.WheelDriveMethodNm = carModelInfoRows[ix].WheelDriveMethodNm;
                            modelPartsDetailRow.AddiCarSpec1 = carModelInfoRows[ix].AddiCarSpec1;
                            modelPartsDetailRow.AddiCarSpec2 = carModelInfoRows[ix].AddiCarSpec2;
                            modelPartsDetailRow.AddiCarSpec3 = carModelInfoRows[ix].AddiCarSpec3;
                            modelPartsDetailRow.AddiCarSpec4 = carModelInfoRows[ix].AddiCarSpec4;
                            modelPartsDetailRow.AddiCarSpec5 = carModelInfoRows[ix].AddiCarSpec5;
                            modelPartsDetailRow.AddiCarSpec6 = carModelInfoRows[ix].AddiCarSpec6;
                            //modelPartsDetailRow.AddiCarSpecTitle1 = carModelInfoRows[ix].AddiCarSpecTitle1;
                            //modelPartsDetailRow.AddiCarSpecTitle2 = carModelInfoRows[ix].AddiCarSpecTitle2;
                            //modelPartsDetailRow.AddiCarSpecTitle3 = carModelInfoRows[ix].AddiCarSpecTitle3;
                            //modelPartsDetailRow.AddiCarSpecTitle4 = carModelInfoRows[ix].AddiCarSpecTitle4;
                            //modelPartsDetailRow.AddiCarSpecTitle5 = carModelInfoRows[ix].AddiCarSpecTitle5;
                            //modelPartsDetailRow.AddiCarSpecTitle6 = carModelInfoRows[ix].AddiCarSpecTitle6;

                            modelInfo.AddModelPartsDetailRow(modelPartsDetailRow);
                        }
                        if (carModelInfoRows.Length > 0)
                        {
                            modelInfo.Columns[modelInfo.AddiCarSpec1Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle1;
                            modelInfo.Columns[modelInfo.AddiCarSpec2Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle2;
                            modelInfo.Columns[modelInfo.AddiCarSpec3Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle3;
                            modelInfo.Columns[modelInfo.AddiCarSpec4Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle4;
                            modelInfo.Columns[modelInfo.AddiCarSpec5Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle5;
                            modelInfo.Columns[modelInfo.AddiCarSpec6Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle6;
                        }
                    }
                }
                #endregion
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  部品情報設定
        /// </summary>
        /// <param name="retPartsInf"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="inPara"></param>
        /// <param name="key"></param>
        private void FillPartsInfo(ArrayList retPartsInf, List<PartsModelLnkWork> partsModelLnkWork, GetPartsInfPara inPara, int key)
        {
            if (retPartsInf == null)
            {
                return;
            }

            // --- ADD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------>>>>>
            Dictionary<NewKey, RetPartsInf> newPartsInfoDic;
            newPartsInfoDic = new Dictionary<NewKey, RetPartsInf>();
            bool setFlg;
            RetPartsInf newPartsInf;

            // 該当部品の新品番情報（条件のBLコード枝番と異なる）を抽出
            if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0) // BLコード枝番が条件に含まれている場合
            {
                foreach (RetPartsInf wkPartsInf in retPartsInf)
                {
                    NewKey _newKey = new NewKey(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.NewPrtsNoWithHyphen.Trim());
                    if ((inPara.TbsPartsCdDerivedNo == wkPartsInf.TbsPartsCdDerivedNo)                    // 検索条件で指定されたBLコード枝番と同じ
                     && (wkPartsInf.NewPrtsNoWithHyphen.Trim() != wkPartsInf.ClgPrtsNoWithHyphen.Trim())  // 新品番が設定されている
                     && (!newPartsInfoDic.ContainsKey(_newKey)))                                          // 新品番情報未検索
                    {
                        setFlg = false;
                        newPartsInf = null;
                        // 新品番を検索
                        foreach (RetPartsInf chkPartsInf in retPartsInf)
                        {
                            if ((wkPartsInf.CatalogPartsMakerCd == chkPartsInf.CatalogPartsMakerCd) &&
                                (wkPartsInf.NewPrtsNoWithHyphen.Trim() == chkPartsInf.ClgPrtsNoWithHyphen.Trim()))
                            {
                                if (inPara.TbsPartsCdDerivedNo == chkPartsInf.TbsPartsCdDerivedNo)
                                {
                                    // BLコード枝番が条件の枝番と同一の場合検索終了（該当品として抽出されるため不要）
                                    setFlg = false;
                                    break;
                                }
                                else
                                {
                                    // BLコード枝番が条件の枝番と異なる場合、抽出対象として保持
                                    setFlg = true;
                                    newPartsInf = chkPartsInf;
                                }
                            }
                        }
                        if (setFlg)
                        {
                            // 新品番情報を要抽出データとして格納
                            if (!newPartsInfoDic.ContainsKey(_newKey))
                            {
                                newPartsInfoDic.Add(_newKey, newPartsInf);
                            }
                        }
                    }
                }
            }
            // --- ADD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------<<<<<

            foreach (RetPartsInf wkPartsInf in retPartsInf)
            {
                bool derivedNmSetFlag = false;

                // BLコード枝番対応（※BLコード検索時のみ）
                if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0)
                {
                    // 検索条件で指定された枝番と異なる場合は迂回
                    if (inPara.TbsPartsCdDerivedNo != wkPartsInf.TbsPartsCdDerivedNo)
                    {
                        // --- UPD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------>>>>>
                        //continue;
                        // 該当部品の新品番として設定されていなければ以降の処理を行わない
                        NewKey _chkKey = new NewKey(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.ClgPrtsNoWithHyphen.Trim());
                        if (!newPartsInfoDic.ContainsKey(_chkKey))
                        {
                            continue;
                        }
                        // --- UPD 2015/04/03 T.Miyamoto SCM仕掛一覧№10715 ------------------------------<<<<<
                    }

                    // 抽出条件にBLコード枝番が設定されている場合は、枝番用部品名称を付与する。
                    if (!string.IsNullOrEmpty(wkPartsInf.PartsName)) wkPartsInf.PartsName = wkPartsInf.PartsName + wkPartsInf.TbsPartsCdDerivedNm;
                    if (!string.IsNullOrEmpty(wkPartsInf.PartsNameKana)) wkPartsInf.PartsNameKana = wkPartsInf.PartsNameKana + wkPartsInf.TbsPartsCdDerivedNm;
                    if (!string.IsNullOrEmpty(wkPartsInf.MakerOfferPartsName)) wkPartsInf.MakerOfferPartsName = wkPartsInf.MakerOfferPartsName + wkPartsInf.TbsPartsCdDerivedNm;
                    if (!string.IsNullOrEmpty(wkPartsInf.MakerOfferPartsKana)) wkPartsInf.MakerOfferPartsKana = wkPartsInf.MakerOfferPartsKana + wkPartsInf.TbsPartsCdDerivedNm;
                    derivedNmSetFlag = true;
                }

                #region 部品情報設定
                PartsInfoDataSet.PartsInfoRow partsInfoRow = partsInfoDic[key].PartsInfo.NewPartsInfoRow();

                partsInfoRow.OfferDate = wkPartsInf.OfferDate;
                partsInfoRow.PartsSearchCode = wkPartsInf.PartsSearchCode;
                partsInfoRow.PartsNarrowingCode = wkPartsInf.PartsNarrowingCode;
                partsInfoRow.PartsName = wkPartsInf.PartsName;
                partsInfoRow.PartsNameKana = wkPartsInf.PartsNameKana;
                partsInfoRow.PartsCode = wkPartsInf.PartsCode;
                partsInfoRow.WorkOrPartsDivNm = wkPartsInf.WorkOrPartsDivNm;
                partsInfoRow.FullModelFixedNo = wkPartsInf.FullModelFixedNo;
                partsInfoRow.TbsPartsCode = wkPartsInf.TbsPartsCode;
                partsInfoRow.TbsPartsCdDerivedNo = wkPartsInf.TbsPartsCdDerivedNo;
                partsInfoRow.FigshapeNo = wkPartsInf.FigShapeNo;
                partsInfoRow.ModelPrtsAdptYm = wkPartsInf.ModelPrtsAdptYm;
                partsInfoRow.ModelPrtsAblsYm = wkPartsInf.ModelPrtsAblsYm;
                partsInfoRow.ModelPrtsAdptFrameNo = wkPartsInf.ModelPrtsAdptFrameNo;
                partsInfoRow.ModelPrtsAblsFrameNo = wkPartsInf.ModelPrtsAblsFrameNo;
                partsInfoRow.PartsQty = wkPartsInf.PartsQty;
                partsInfoRow.PartsOpNm = wkPartsInf.PartsOpNm;
                partsInfoRow.StandardName = wkPartsInf.StandardName;
                partsInfoRow.CatalogPartsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                partsInfoRow.CatalogPartsMakerNm = GetPartsMakerName(wkPartsInf.CatalogPartsMakerCd);

                partsInfoRow.ClgPrtsNoWithHyphen = wkPartsInf.ClgPrtsNoWithHyphen.Trim();
                if (partsInfoRow.ClgPrtsNoWithHyphen == string.Empty)                   // 本来はあってはいけないケースだが、データの整合性の問題で
                    partsInfoRow.ClgPrtsNoWithHyphen = wkPartsInf.NewPrtsNoWithHyphen;  // 障害を防ぐ目的でこの処理を追加
                partsInfoRow.ColdDistrictsFlag = wkPartsInf.ColdDistrictsFlag;
                partsInfoRow.ColorNarrowingFlag = wkPartsInf.ColorNarrowingFlag;
                partsInfoRow.TrimNarrowingFlag = wkPartsInf.TrimNarrowingFlag;
                partsInfoRow.EquipNarrowingFlag = wkPartsInf.EquipNarrowingFlag;
                partsInfoRow.MakerOfferPartsName = wkPartsInf.MakerOfferPartsName;
                partsInfoRow.PartsLayerCd = wkPartsInf.PartsLayerCd;
                partsInfoRow.PartsUniqueNo = wkPartsInf.PartsUniqueNo;

                partsInfoRow.NewPrtsNoWithHyphen = wkPartsInf.NewPrtsNoWithHyphen;
                partsInfoRow.NewPrtsNoNoneHyphen = wkPartsInf.NewPrtsNoNoneHyphen;
                partsInfoRow.SeriesModel = wkPartsInf.SeriesModel;
                partsInfoRow.CategorySignModel = wkPartsInf.CategorySignModel;
                partsInfoRow.ExhaustGasSign = wkPartsInf.ExhaustGasSign;

                // 自動見積部品コード
                partsInfoRow.AutoEstimatePartsCd = wkPartsInf.AutoEstimatePartsCd;
                // BLコード枝番用部品名称
                if (derivedNmSetFlag)
                {
                    partsInfoRow.TbsPartsCdDerivedNm = wkPartsInf.TbsPartsCdDerivedNm;
                }

                partsInfoRow.PrimeJoinLnkFlg = wkPartsInf.PrimeJoinLnkFlg;

                // VIN生産No.(始期)とVIN生産No.(終期)を格納する
                partsInfoRow.VinProduceStartNo = wkPartsInf.VinProduceStartNo.ToString("000000");
                partsInfoRow.VinProduceEndNo = wkPartsInf.VinProduceEndNo.ToString("000000");

                partsInfoDic[key].PartsInfo.AddPartsInfoRow(partsInfoRow);
                #endregion

                #region 商品マスタテーブルに設定
                string partsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                    goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkPartsInf.CatalogPartsMakerCd, partsNo);
                if (usrGoodsRow == null)
                {
                    usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                    usrGoodsRow.BlGoodsCode = wkPartsInf.TbsPartsCode;
                    usrGoodsRow.GoodsKindCode = 0; // 0 : 純正
                    usrGoodsRow.GoodsKind = (int)GoodsKind.Parent; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                    usrGoodsRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    usrGoodsRow.GoodsMakerNm = partsInfoRow.CatalogPartsMakerNm;
                    //usrGoodsRow.GoodsMGroup = 0;
                    usrGoodsRow.GoodsRateRank = wkPartsInf.PartsLayerCd;
                    usrGoodsRow.GoodsNoNoneHyphen = partsInfoRow.ClgPrtsNoWithHyphen.Replace("-", "");
                    usrGoodsRow.QTY = wkPartsInf.PartsQty;
                    usrGoodsRow.GoodsNote1 = wkPartsInf.StandardName; //規格
                    //usrGoodsRow.GoodsNote2 = "";
                    usrGoodsRow.GoodsSpecialNote = wkPartsInf.PartsOpNm;
                    usrGoodsRow.GoodsSpecialNoteOffer = wkPartsInf.PartsOpNm;   // 商品規格・特記事項（提供）
                    usrGoodsRow.OfferDate = wkPartsInf.OfferDate;
                    usrGoodsRow.OfferKubun = 3; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                    //usrGoodsRow.TaxationDivCd = 0;
                    usrGoodsRow.GoodsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                    usrGoodsRow.OfferDataDiv = 1;

                    if (wkPartsInf.MakerOfferPartsName != string.Empty)
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.MakerOfferPartsName; // 商品名：デフォルトは部品名
                        usrGoodsRow.GoodsNameKana = wkPartsInf.MakerOfferPartsKana;
                    }
                    else // 古い部品は名称が取れないので
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.PartsName; // 検索品名
                        usrGoodsRow.GoodsNameKana = wkPartsInf.PartsNameKana;
                    }
                    usrGoodsRow.GoodsOfrName = wkPartsInf.MakerOfferPartsName; // 部品名
                    usrGoodsRow.GoodsOfrNameKana = wkPartsInf.MakerOfferPartsKana;
                    usrGoodsRow.SearchPartsFullName = wkPartsInf.PartsName; // 検索品名
                    usrGoodsRow.SearchPartsHalfName = wkPartsInf.PartsNameKana;
                    usrGoodsRow.SrchPNmAcqrCarMkrCd = wkPartsInf.SrchPNmAcqrCarMkrCd;   // 検索品名取得メーカーコード    
                    usrGoodsRow.PartsPriceStDate = wkPartsInf.PartsPriceStDate;

                    if (wkPartsInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkPartsInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkPartsInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                            usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                            usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }

                    partsInfoRow.UsrGoodsInfoRowParentByUsrGoodsInfo_PartsInfo = usrGoodsRow;
                    goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);
                }

                // BLコード、品名、層別は常に最新のデータを使用する
                if (usrGoodsRow.PartsPriceStDate < wkPartsInf.PartsPriceStDate)
                {
                    // 品名の更新
                    if (!string.IsNullOrEmpty(wkPartsInf.MakerOfferPartsName))
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.MakerOfferPartsName;     // 部品名
                        usrGoodsRow.GoodsNameKana = wkPartsInf.MakerOfferPartsKana;

                        usrGoodsRow.GoodsOfrName = wkPartsInf.MakerOfferPartsName;  // 部品名
                        usrGoodsRow.GoodsOfrNameKana = wkPartsInf.MakerOfferPartsKana;
                    }

                    // BLコードの更新
                    if (wkPartsInf.TbsPartsCode != 0)
                    {
                        usrGoodsRow.BlGoodsCode = wkPartsInf.TbsPartsCode;
                    }

                    usrGoodsRow.GoodsRateRank = wkPartsInf.PartsLayerCd;            // 層別

                    usrGoodsRow.PartsPriceStDate = wkPartsInf.PartsPriceStDate;     // 提供の価格取得日を更新
                }

                #region USR Price
                if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                    priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                    wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    double listPrice = wkPartsInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                    //usrPriceRow.SalesUnitCost = 0;
                    //usrPriceRow.StockRate = 0;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                    priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                    ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                    wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    double listPrice = wkPartsInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                    ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                #endregion
                #endregion

                #region 部品関連型式情報設定
                if (carInfoDataSet != null && partsModelLnkWork != null)
                {
                    PartsInfoDataSet.ModelPartsDetailDataTable modelInfo = partsInfoDic[key].ModelPartsDetail;
                    foreach (PartsModelLnkWork wkModelInf in partsModelLnkWork)
                    {
                        if (wkModelInf.PartsProperNo != wkPartsInf.PartsUniqueNo)
                            continue;

                        string select = "FullModelFixedNo in (";
                        for (int i = 0; i < wkModelInf.FullModelFixedNos.Count; i++)
                        {
                            select += wkModelInf.FullModelFixedNos[i].ToString() + ", ";
                        }
                        select.Remove(select.Length - 2);
                        select += ")";

                        PMKEN01010E.CarModelInfoRow[] carModelInfoRows = (PMKEN01010E.CarModelInfoRow[])carInfoDataSet.CarModelInfo.Select(select);

                        //車輌情報→部品詳細（型式情報）設定
                        for (int ix = 0; ix < carModelInfoRows.Length; ix++)
                        {
                            string filter = string.Format("{0} = {1} AND {2} = {3}",
                                modelInfo.PartsUniqueNoColumn.ColumnName, wkModelInf.PartsProperNo,
                                modelInfo.FullModelFixedNoColumn.ColumnName, carModelInfoRows[ix].FullModelFixedNo);
                            PartsInfoDataSet.ModelPartsDetailRow[] row = (PartsInfoDataSet.ModelPartsDetailRow[])modelInfo.Select(filter);
                            if (row.Length > 0)
                                continue;
                            PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = modelInfo.NewModelPartsDetailRow();

                            modelPartsDetailRow.PartsUniqueNo = wkModelInf.PartsProperNo;
                            modelPartsDetailRow.PartsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                            modelPartsDetailRow.PartsNo = wkPartsInf.ClgPrtsNoWithHyphen;

                            modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                            modelPartsDetailRow.DoorCount = carModelInfoRows[ix].DoorCount;
                            modelPartsDetailRow.BodyName = carModelInfoRows[ix].BodyName;
                            modelPartsDetailRow.ModelGradeNm = carModelInfoRows[ix].ModelGradeNm;
                            modelPartsDetailRow.EngineModelNm = carModelInfoRows[ix].EngineModelNm;
                            modelPartsDetailRow.EngineDisplaceNm = carModelInfoRows[ix].EngineDisplaceNm;
                            modelPartsDetailRow.EDivNm = carModelInfoRows[ix].EDivNm;
                            modelPartsDetailRow.TransmissionNm = carModelInfoRows[ix].TransmissionNm;
                            modelPartsDetailRow.ShiftNm = carModelInfoRows[ix].ShiftNm;
                            modelPartsDetailRow.WheelDriveMethodNm = carModelInfoRows[ix].WheelDriveMethodNm;
                            modelPartsDetailRow.AddiCarSpec1 = carModelInfoRows[ix].AddiCarSpec1;
                            modelPartsDetailRow.AddiCarSpec2 = carModelInfoRows[ix].AddiCarSpec2;
                            modelPartsDetailRow.AddiCarSpec3 = carModelInfoRows[ix].AddiCarSpec3;
                            modelPartsDetailRow.AddiCarSpec4 = carModelInfoRows[ix].AddiCarSpec4;
                            modelPartsDetailRow.AddiCarSpec5 = carModelInfoRows[ix].AddiCarSpec5;
                            modelPartsDetailRow.AddiCarSpec6 = carModelInfoRows[ix].AddiCarSpec6;
                            //modelPartsDetailRow.AddiCarSpecTitle1 = carModelInfoRows[ix].AddiCarSpecTitle1;
                            //modelPartsDetailRow.AddiCarSpecTitle2 = carModelInfoRows[ix].AddiCarSpecTitle2;
                            //modelPartsDetailRow.AddiCarSpecTitle3 = carModelInfoRows[ix].AddiCarSpecTitle3;
                            //modelPartsDetailRow.AddiCarSpecTitle4 = carModelInfoRows[ix].AddiCarSpecTitle4;
                            //modelPartsDetailRow.AddiCarSpecTitle5 = carModelInfoRows[ix].AddiCarSpecTitle5;
                            //modelPartsDetailRow.AddiCarSpecTitle6 = carModelInfoRows[ix].AddiCarSpecTitle6;

                            modelInfo.AddModelPartsDetailRow(modelPartsDetailRow);
                        }
                        if (carModelInfoRows.Length > 0)
                        {
                            modelInfo.Columns[modelInfo.AddiCarSpec1Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle1;
                            modelInfo.Columns[modelInfo.AddiCarSpec2Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle2;
                            modelInfo.Columns[modelInfo.AddiCarSpec3Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle3;
                            modelInfo.Columns[modelInfo.AddiCarSpec4Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle4;
                            modelInfo.Columns[modelInfo.AddiCarSpec5Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle5;
                            modelInfo.Columns[modelInfo.AddiCarSpec6Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle6;
                        }
                    }
                }
                #endregion
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<
        # endregion

        # region カラー情報設定
        /// <summary>
        /// カラー情報設定
        /// </summary>
        /// <param name="list"></param>
        private void FillOfrColorTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsColorWork wkInf in list)
            {
                PartsInfoDataSet.OfrColorInfoRow row = partsInfo.OfrColorInfo.NewOfrColorInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.ColorCdInfoNo = wkInf.ColorCdInfoNo;

                string filter = string.Format("{0} = '{1}'", carInfoDataSet.ColorCdInfo.ColorCodeColumn.ColumnName, wkInf.ColorCdInfoNo);
                PMKEN01010E.ColorCdInfoRow[] carColorInfoRows = (PMKEN01010E.ColorCdInfoRow[])carInfoDataSet.ColorCdInfo.Select(filter);
                if (carColorInfoRows.Length > 0)
                {
                    row.ColorName = carColorInfoRows[0].ColorName1;
                }

                partsInfo.OfrColorInfo.AddOfrColorInfoRow(row);
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  カラー情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillOfrColorTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsColorWork wkInf in list)
            {
                PartsInfoDataSet.OfrColorInfoRow row = partsInfoDic[key].OfrColorInfo.NewOfrColorInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.ColorCdInfoNo = wkInf.ColorCdInfoNo;

                string filter = string.Format("{0} = '{1}'", carInfoDataSet.ColorCdInfo.ColorCodeColumn.ColumnName, wkInf.ColorCdInfoNo);
                PMKEN01010E.ColorCdInfoRow[] carColorInfoRows = (PMKEN01010E.ColorCdInfoRow[])carInfoDataSet.ColorCdInfo.Select(filter);
                if (carColorInfoRows.Length > 0)
                {
                    row.ColorName = carColorInfoRows[0].ColorName1;
                }

                partsInfoDic[key].OfrColorInfo.AddOfrColorInfoRow(row);
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region トリム情報設定
        /// <summary>
        /// トリム情報設定
        /// </summary>
        /// <param name="list"></param>
        private void FillOfrTrimTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsTrimWork wkInf in list)
            {
                PartsInfoDataSet.OfrTrimInfoRow row = partsInfo.OfrTrimInfo.NewOfrTrimInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.TrimCode = wkInf.TrimCode;

                string filter = string.Format("{0} = '{1}'", carInfoDataSet.TrimCdInfo.TrimCodeColumn.ColumnName, wkInf.TrimCode);
                PMKEN01010E.TrimCdInfoRow[] carTrimInfoRows = (PMKEN01010E.TrimCdInfoRow[])carInfoDataSet.TrimCdInfo.Select(filter);
                if (carTrimInfoRows.Length > 0)
                {
                    row.TrimName = carTrimInfoRows[0].TrimName;
                }

                partsInfo.OfrTrimInfo.AddOfrTrimInfoRow(row);
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  トリム情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillOfrTrimTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsTrimWork wkInf in list)
            {
                PartsInfoDataSet.OfrTrimInfoRow row = partsInfoDic[key].OfrTrimInfo.NewOfrTrimInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.TrimCode = wkInf.TrimCode;

                string filter = string.Format("{0} = '{1}'", carInfoDataSet.TrimCdInfo.TrimCodeColumn.ColumnName, wkInf.TrimCode);
                PMKEN01010E.TrimCdInfoRow[] carTrimInfoRows = (PMKEN01010E.TrimCdInfoRow[])carInfoDataSet.TrimCdInfo.Select(filter);
                if (carTrimInfoRows.Length > 0)
                {
                    row.TrimName = carTrimInfoRows[0].TrimName;
                }

                partsInfoDic[key].OfrTrimInfo.AddOfrTrimInfoRow(row);
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region 装備情報設定
        /// <summary>
        /// 装備情報設定
        /// </summary>
        /// <param name="list"></param>
        private void FillOfrEquipTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsEquipWork wkInf in list)
            {
                PartsInfoDataSet.OfrEquipInfoRow row = partsInfo.OfrEquipInfo.NewOfrEquipInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.EquipmentGenreCd = wkInf.EquipmentGenreCd;
                row.EquipmentCode = wkInf.EquipmentCode;

                string filter = string.Format("{0} = {1} AND {2} = {3}",
                    carInfoDataSet.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName,
                    wkInf.EquipmentGenreCd,
                    carInfoDataSet.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName,
                    wkInf.EquipmentCode);
                PMKEN01010E.CEqpDefDspInfoRow[] carEqpInfoRows = (PMKEN01010E.CEqpDefDspInfoRow[])carInfoDataSet.CEqpDefDspInfo.Select(filter);
                if (carEqpInfoRows.Length > 0)
                {
                    row.EquipmentDispOrder = carEqpInfoRows[0].EquipmentDispOrder;
                    row.EquipmentGenreNm = carEqpInfoRows[0].EquipmentGenreNm;
                    row.EquipmentName = carEqpInfoRows[0].EquipmentName;
                    row.EquipmentIconCode = carEqpInfoRows[0].EquipmentIconCode;
                    row.EquipmentShortName = carEqpInfoRows[0].EquipmentShortName;
                }

                partsInfo.OfrEquipInfo.AddOfrEquipInfoRow(row);
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 装備情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillOfrEquipTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsEquipWork wkInf in list)
            {
                PartsInfoDataSet.OfrEquipInfoRow row = partsInfoDic[key].OfrEquipInfo.NewOfrEquipInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.EquipmentGenreCd = wkInf.EquipmentGenreCd;
                row.EquipmentCode = wkInf.EquipmentCode;

                string filter = string.Format("{0} = {1} AND {2} = {3}",
                    carInfoDataSet.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName,
                    wkInf.EquipmentGenreCd,
                    carInfoDataSet.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName,
                    wkInf.EquipmentCode);
                PMKEN01010E.CEqpDefDspInfoRow[] carEqpInfoRows = (PMKEN01010E.CEqpDefDspInfoRow[])carInfoDataSet.CEqpDefDspInfo.Select(filter);
                if (carEqpInfoRows.Length > 0)
                {
                    row.EquipmentDispOrder = carEqpInfoRows[0].EquipmentDispOrder;
                    row.EquipmentGenreNm = carEqpInfoRows[0].EquipmentGenreNm;
                    row.EquipmentName = carEqpInfoRows[0].EquipmentName;
                    row.EquipmentIconCode = carEqpInfoRows[0].EquipmentIconCode;
                    row.EquipmentShortName = carEqpInfoRows[0].EquipmentShortName;
                }

                partsInfoDic[key].OfrEquipInfo.AddOfrEquipInfoRow(row);
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region 代替情報設定
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// 代替情報設定
        ///// </summary>
        ///// <param name="list"></param>
        ///// <param name="partsName"></param>
        ///// <param name="partsNameKana"></param>
        //private void FillOfrSubstTable(ArrayList list, string partsName, string partsNameKana)
        /// <summary>
        /// 代替情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="partsName"></param>
        /// <param name="partsNameKana"></param>
        /// <param name="inPara"></param>
        private void FillOfrSubstTable( ArrayList list, string partsName, string partsNameKana, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            foreach (PartsSubstWork wkInf in list)
            {
                string partsMakerNm = string.Empty;
                //代替情報
                if (wkInf.MainOrSubPartsDivCd == 0)
                {
                    if (partsInfo.SubstPartsInfo.FindByNewPartsNoWithHyphenCatalogPartsMakerCdOldPartsNoWithHyphen(
                        wkInf.NewPartsNoWithHyphen, wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen) == null)
                    {
                        PartsInfoDataSet.SubstPartsInfoRow row = partsInfo.SubstPartsInfo.NewSubstPartsInfoRow();

                        row.CatalogPartsMakerCd = wkInf.CatalogPartsMakerCd;
                        row.CatalogPartsMakerNm = GetPartsMakerName(wkInf.CatalogPartsMakerCd);
                        partsMakerNm = row.CatalogPartsMakerNm;

                        row.OldPartsNoWithHyphen = wkInf.OldPartsNoWithHyphen;
                        row.NewPartsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                        row.NPrtNoWithHypnDspOdr = wkInf.NPrtNoWithHypnDspOdr;
                        row.PartsPluralSubstFlg = wkInf.PartsPluralSubstFlg;
                        row.MainOrSubPartsDivCd = wkInf.MainOrSubPartsDivCd;
                        row.PartsQty = wkInf.PartsQty;
                        row.PartsPluralSubstCmnt = wkInf.PartsPluralSubstCmnt;
                        row.PlrlSubNewPrtNoHypn = wkInf.PlrlSubNewPrtNoHypn;
                        row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.MakerOfferPartsName = wkInf.MakerOfferPartsName;
                        row.PartsLayerCd = wkInf.PartsLayerCd;
                        row.PartsInfoCtrlFlg = wkInf.PartsInfoCtrlFlg;
                        row.PartsName = partsName;
                        row.PartsNameKana = partsNameKana;
                        row.PartsCode = wkInf.PartsCode;
                        row.PartsSearchCode = wkInf.PartsSearchCode;

                        partsInfo.SubstPartsInfo.AddSubstPartsInfoRow(row);
                    }
                }
                //複数代替情報
                else
                {
                    if (partsInfo.DSubstPartsInfo.FindByCatalogPartsMakerCdOldPartsNoWithHyphenNewPartsNoWithHyphenPlrlSubNewPrtNoHypn(
                        wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen, wkInf.NewPartsNoWithHyphen, wkInf.PlrlSubNewPrtNoHypn) == null)
                    {
                        PartsInfoDataSet.DSubstPartsInfoRow row = partsInfo.DSubstPartsInfo.NewDSubstPartsInfoRow();

                        row.CatalogPartsMakerCd = wkInf.CatalogPartsMakerCd;
                        row.CatalogPartsMakerNm = GetPartsMakerName(wkInf.CatalogPartsMakerCd);
                        partsMakerNm = row.CatalogPartsMakerNm;

                        row.OldPartsNoWithHyphen = wkInf.OldPartsNoWithHyphen;
                        row.NewPartsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                        row.NPrtNoWithHypnDspOdr = wkInf.NPrtNoWithHypnDspOdr;
                        row.PartsPluralSubstFlg = wkInf.PartsPluralSubstFlg;
                        row.MainOrSubPartsDivCd = wkInf.MainOrSubPartsDivCd;
                        row.PartsQty = wkInf.PartsQty;
                        row.PartsPluralSubstCmnt = wkInf.PartsPluralSubstCmnt;
                        row.PlrlSubNewPrtNoHypn = wkInf.PlrlSubNewPrtNoHypn;
                        row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.MakerOfferPartsName = wkInf.MakerOfferPartsName;
                        row.PartsLayerCd = wkInf.PartsLayerCd;
                        row.PartsInfoCtrlFlg = wkInf.PartsInfoCtrlFlg;
                        row.PartsName = wkInf.MakerOfferPartsName; //partsName;
                        row.PartsNameKana = wkInf.MakerOfferPartsKana; //partsNameKana;
                        row.PartsCode = wkInf.PartsCode;
                        row.PartsSearchCode = wkInf.PartsSearchCode;

                        partsInfo.DSubstPartsInfo.AddDSubstPartsInfoRow(row);
                    }
                }

                PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                        goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.NewPartsNoWithHyphen);
                if (usrGoodsRow == null)
                {
                    usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                    usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrGoodsRow.GoodsKindCode = 0; // 0 : 純正
                    usrGoodsRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrGoodsRow.GoodsMakerNm = partsMakerNm;
                    //usrGoodsRow.GoodsMGroup = 0;
                    usrGoodsRow.GoodsRateRank = wkInf.PartsLayerCd;
                    usrGoodsRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrGoodsRow.GoodsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                    //usrGoodsRow.GoodsNote1 = "";
                    //usrGoodsRow.GoodsNote2 = "";
                    usrGoodsRow.GoodsSpecialNote = wkInf.PartsPluralSubstCmnt;
                    usrGoodsRow.QTY = wkInf.PartsQty;
                    usrGoodsRow.OfferDate = wkInf.OfferDate;
                    usrGoodsRow.OfferKubun = 3; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                    //usrGoodsRow.TaxationDivCd = 0;
                    usrGoodsRow.OfferDataDiv = 1;
                    if (wkInf.MakerOfferPartsName != string.Empty)
                    {
                        usrGoodsRow.GoodsName = wkInf.MakerOfferPartsName; // 商品名：デフォルトは部品名
                        usrGoodsRow.GoodsNameKana = wkInf.MakerOfferPartsKana;
                    }
                    else
                    {
                        usrGoodsRow.GoodsName = partsName; // 検索品名（古い代替品の場合品名が取れない場合があるので）
                        usrGoodsRow.GoodsNameKana = partsNameKana; // （代替画面で品名表示のためこの処理を入れておく）
                    }
                    usrGoodsRow.GoodsOfrName = wkInf.MakerOfferPartsName; // 部品名
                    usrGoodsRow.GoodsOfrNameKana = wkInf.MakerOfferPartsKana;
                    // 2009/10/27 >>>
                    //usrGoodsRow.SearchPartsFullName = partsName; // 検索品名
                    //usrGoodsRow.SearchPartsHalfName = partsNameKana;

                    // 複数互換のサブ部品は検索品名をセットしない
                    if (wkInf.MainOrSubPartsDivCd == 0)
                    {
                        usrGoodsRow.SearchPartsFullName = partsName; // 検索品名
                        usrGoodsRow.SearchPartsHalfName = partsNameKana;
                    }
                    // 2009/10/27 <<<
                    
                    // 2010/02/25 Add >>>
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                            usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                            usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }
                    // 2010/02/25 Add <<<

                    goodsTable.AddUsrGoodsInfoRow(usrGoodsRow);

                    // 2009/11/09 Del >>>
                    //if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen)
                    //    == null)
                    //{
                    //    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                    //    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    //    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    //    // 2009.03.04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    //    double listPrice = wkInf.PartsPrice;
                    //    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    //    usrPriceRow.ListPrice = listPrice;
                    //    // 2009.03.04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    //    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    //    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    //    //usrPriceRow.SalesUnitCost = 0;
                    //    //usrPriceRow.StockRate = 0;
                    //    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    //    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                    //}
                    // 2009/11/09 Del <<<
                }
                // 2009/11/09 Add >>>
                // 既に登録された部品に関しても価格情報の更新を行う。
                if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    double listPrice = wkInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                }
                // 2009/11/09 Add <<<
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                // 既に登録された部品に関しても提供データ用価格情報の更新を行う。
                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    double listPrice = wkInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

                //既に登録された部品に関しても部品区分の更新を行う。
                if (wkInf.MainOrSubPartsDivCd == 0)// || wkInf.MainOrSubPartsDivCd == 1)
                {
                    if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                        usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                }
                else
                {
                    if ((usrGoodsRow.GoodsKind & (int)GoodsKind.SubstPlrl) != (int)GoodsKind.SubstPlrl)
                        usrGoodsRow.GoodsKind += (int)GoodsKind.SubstPlrl; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                }

                if (partsInfo.UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                        wkInf.NewPartsNoWithHyphen, wkInf.OldPartsNoWithHyphen, wkInf.CatalogPartsMakerCd)
                    == null)
                {
                    PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();
                    usrSubstRow.ChgDestGoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrSubstRow.ChgDestMakerCd = wkInf.CatalogPartsMakerCd;
                    usrSubstRow.ChgSrcGoodsNo = wkInf.OldPartsNoWithHyphen;
                    usrSubstRow.ChgSrcMakerCd = wkInf.CatalogPartsMakerCd;
                    partsInfo.UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                }

            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 代替情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="partsName"></param>
        /// <param name="partsNameKana"></param>
        /// <param name="inPara"></param>
        /// <param name="key"></param>
        private void FillOfrSubstTable(ArrayList list, string partsName, string partsNameKana, GetPartsInfPara inPara, int key)
        {
            foreach (PartsSubstWork wkInf in list)
            {
                string partsMakerNm = string.Empty;
                //代替情報
                if (wkInf.MainOrSubPartsDivCd == 0)
                {
                    if (partsInfoDic[key].SubstPartsInfo.FindByNewPartsNoWithHyphenCatalogPartsMakerCdOldPartsNoWithHyphen(
                        wkInf.NewPartsNoWithHyphen, wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen) == null)
                    {
                        PartsInfoDataSet.SubstPartsInfoRow row = partsInfoDic[key].SubstPartsInfo.NewSubstPartsInfoRow();

                        row.CatalogPartsMakerCd = wkInf.CatalogPartsMakerCd;
                        row.CatalogPartsMakerNm = GetPartsMakerName(wkInf.CatalogPartsMakerCd);
                        partsMakerNm = row.CatalogPartsMakerNm;

                        row.OldPartsNoWithHyphen = wkInf.OldPartsNoWithHyphen;
                        row.NewPartsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                        row.NPrtNoWithHypnDspOdr = wkInf.NPrtNoWithHypnDspOdr;
                        row.PartsPluralSubstFlg = wkInf.PartsPluralSubstFlg;
                        row.MainOrSubPartsDivCd = wkInf.MainOrSubPartsDivCd;
                        row.PartsQty = wkInf.PartsQty;
                        row.PartsPluralSubstCmnt = wkInf.PartsPluralSubstCmnt;
                        row.PlrlSubNewPrtNoHypn = wkInf.PlrlSubNewPrtNoHypn;
                        row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.MakerOfferPartsName = wkInf.MakerOfferPartsName;
                        row.PartsLayerCd = wkInf.PartsLayerCd;
                        row.PartsInfoCtrlFlg = wkInf.PartsInfoCtrlFlg;
                        row.PartsName = partsName;
                        row.PartsNameKana = partsNameKana;
                        row.PartsCode = wkInf.PartsCode;
                        row.PartsSearchCode = wkInf.PartsSearchCode;

                        partsInfoDic[key].SubstPartsInfo.AddSubstPartsInfoRow(row);
                    }
                }
                //複数代替情報
                else
                {
                    if (partsInfoDic[key].DSubstPartsInfo.FindByCatalogPartsMakerCdOldPartsNoWithHyphenNewPartsNoWithHyphenPlrlSubNewPrtNoHypn(
                        wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen, wkInf.NewPartsNoWithHyphen, wkInf.PlrlSubNewPrtNoHypn) == null)
                    {
                        PartsInfoDataSet.DSubstPartsInfoRow row = partsInfoDic[key].DSubstPartsInfo.NewDSubstPartsInfoRow();

                        row.CatalogPartsMakerCd = wkInf.CatalogPartsMakerCd;
                        row.CatalogPartsMakerNm = GetPartsMakerName(wkInf.CatalogPartsMakerCd);
                        partsMakerNm = row.CatalogPartsMakerNm;

                        row.OldPartsNoWithHyphen = wkInf.OldPartsNoWithHyphen;
                        row.NewPartsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                        row.NPrtNoWithHypnDspOdr = wkInf.NPrtNoWithHypnDspOdr;
                        row.PartsPluralSubstFlg = wkInf.PartsPluralSubstFlg;
                        row.MainOrSubPartsDivCd = wkInf.MainOrSubPartsDivCd;
                        row.PartsQty = wkInf.PartsQty;
                        row.PartsPluralSubstCmnt = wkInf.PartsPluralSubstCmnt;
                        row.PlrlSubNewPrtNoHypn = wkInf.PlrlSubNewPrtNoHypn;
                        row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.MakerOfferPartsName = wkInf.MakerOfferPartsName;
                        row.PartsLayerCd = wkInf.PartsLayerCd;
                        row.PartsInfoCtrlFlg = wkInf.PartsInfoCtrlFlg;
                        row.PartsName = wkInf.MakerOfferPartsName; //partsName;
                        row.PartsNameKana = wkInf.MakerOfferPartsKana; //partsNameKana;
                        row.PartsCode = wkInf.PartsCode;
                        row.PartsSearchCode = wkInf.PartsSearchCode;

                        partsInfoDic[key].DSubstPartsInfo.AddDSubstPartsInfoRow(row);
                    }
                }

                PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                        goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.NewPartsNoWithHyphen);
                if (usrGoodsRow == null)
                {
                    usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                    usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrGoodsRow.GoodsKindCode = 0; // 0 : 純正
                    usrGoodsRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrGoodsRow.GoodsMakerNm = partsMakerNm;
                    //usrGoodsRow.GoodsMGroup = 0;
                    usrGoodsRow.GoodsRateRank = wkInf.PartsLayerCd;
                    usrGoodsRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrGoodsRow.GoodsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                    //usrGoodsRow.GoodsNote1 = "";
                    //usrGoodsRow.GoodsNote2 = "";
                    usrGoodsRow.GoodsSpecialNote = wkInf.PartsPluralSubstCmnt;
                    usrGoodsRow.QTY = wkInf.PartsQty;
                    usrGoodsRow.OfferDate = wkInf.OfferDate;
                    usrGoodsRow.OfferKubun = 3; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                    //usrGoodsRow.TaxationDivCd = 0;
                    usrGoodsRow.OfferDataDiv = 1;
                    if (wkInf.MakerOfferPartsName != string.Empty)
                    {
                        usrGoodsRow.GoodsName = wkInf.MakerOfferPartsName; // 商品名：デフォルトは部品名
                        usrGoodsRow.GoodsNameKana = wkInf.MakerOfferPartsKana;
                    }
                    else
                    {
                        usrGoodsRow.GoodsName = partsName; // 検索品名（古い代替品の場合品名が取れない場合があるので）
                        usrGoodsRow.GoodsNameKana = partsNameKana; // （代替画面で品名表示のためこの処理を入れておく）
                    }
                    usrGoodsRow.GoodsOfrName = wkInf.MakerOfferPartsName; // 部品名
                    usrGoodsRow.GoodsOfrNameKana = wkInf.MakerOfferPartsKana;

                    // 複数互換のサブ部品は検索品名をセットしない
                    if (wkInf.MainOrSubPartsDivCd == 0)
                    {
                        usrGoodsRow.SearchPartsFullName = partsName; // 検索品名
                        usrGoodsRow.SearchPartsHalfName = partsNameKana;
                    }
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                            usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                            usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }

                    goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);

                }
                // 既に登録された部品に関しても価格情報の更新を行う。
                if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    double listPrice = wkInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                // 既に登録された部品に関しても提供データ用価格情報の更新を行う。
                if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    double listPrice = wkInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

                //既に登録された部品に関しても部品区分の更新を行う。
                if (wkInf.MainOrSubPartsDivCd == 0)
                {
                    if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                        usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                }
                else
                {
                    if ((usrGoodsRow.GoodsKind & (int)GoodsKind.SubstPlrl) != (int)GoodsKind.SubstPlrl)
                        usrGoodsRow.GoodsKind += (int)GoodsKind.SubstPlrl; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                }

                if (partsInfoDic[key].UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                        wkInf.NewPartsNoWithHyphen, wkInf.OldPartsNoWithHyphen, wkInf.CatalogPartsMakerCd)
                    == null)
                {
                    PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();
                    usrSubstRow.ChgDestGoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrSubstRow.ChgDestMakerCd = wkInf.CatalogPartsMakerCd;
                    usrSubstRow.ChgSrcGoodsNo = wkInf.OldPartsNoWithHyphen;
                    usrSubstRow.ChgSrcMakerCd = wkInf.CatalogPartsMakerCd;
                    partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                }

            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region 優良部品情報設定
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// 優良部品情報設定
        ///// </summary>
        ///// <param name="flg">true:優良品番検索によるケース／false:結合検索によるケース</param>
        ///// <param name="JoinPartsList"></param>
        ///// <param name="PrimePriceList"></param>
        ///// <param name="SetPartsInfoList"></param>
        ///// <param name="SetPriceList"></param>
        //private void FillJoinSetParts(bool flg, ArrayList JoinPartsList, ArrayList PrimePriceList,
        //                ArrayList SetPartsInfoList, ArrayList SetPriceList)
        /// <summary>
        /// 優良部品情報設定
        /// </summary>
        /// <param name="flg">true:優良品番検索によるケース／false:結合検索によるケース</param>
        /// <param name="JoinPartsList"></param>
        /// <param name="PrimePriceList"></param>
        /// <param name="SetPartsInfoList"></param>
        /// <param name="SetPriceList"></param>
        /// <param name="inPara"></param>
        private void FillJoinSetParts( bool flg, ArrayList JoinPartsList, ArrayList PrimePriceList,
                        ArrayList SetPartsInfoList, ArrayList SetPriceList, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            foreach (OfferJoinPartsRetWork wkInf in JoinPartsList)
            {
                if (flg && searchPrtCtlAcs.BikeSearch == 0 && bikePMakerList.Contains(wkInf.JoinDestMakerCd))
                { // 優良品番検索　＆　2輪検索契約なし　＆　2輪部品メーカーの場合
                    continue;
                }
                if (searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                     && wkInf.JoinDestMakerCd == ct_TactiCd // 部品メーカーがタクティー
                     && (carInfoDataSet != null && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd)) // 車のメーカーがトヨタでない
                {
                    continue;
                }
                #region 結合部品設定
                if (wkInf.SubstKubun == 0)
                {
                    // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                    // BLコード枝番対応(※BLコード検索時のみ)
                    if ( inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0 )
                    {
                        // 結合元レコードを探す
                        PartsInfoDataSet.PartsInfoRow joinSourceRow =
                            partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( wkInf.JoinSourceMakerCode, wkInf.JoinSourPartsNoWithH );
                        if ( joinSourceRow != null )
                        {
                            // 結合元レコードのBLコード枝番名称を付与する。
                            if ( !string.IsNullOrEmpty( wkInf.PrimePartsName ) ) wkInf.PrimePartsName = wkInf.PrimePartsName + joinSourceRow.TbsPartsCdDerivedNm;
                            if ( !string.IsNullOrEmpty( wkInf.PrimePartsKanaName ) ) wkInf.PrimePartsKanaName = wkInf.PrimePartsKanaName + joinSourceRow.TbsPartsCdDerivedNm;
                            if ( !string.IsNullOrEmpty( wkInf.SearchPartsFullName  ) ) wkInf.SearchPartsFullName = wkInf.SearchPartsFullName + joinSourceRow.TbsPartsCdDerivedNm;
                            if ( !string.IsNullOrEmpty( wkInf.SearchPartsHalfName ) ) wkInf.SearchPartsHalfName = wkInf.SearchPartsHalfName + joinSourceRow.TbsPartsCdDerivedNm;
                        }
                    }
                    // --- ADD m.suzuki 2011/05/18 ----------<<<<<

                    PartsInfoDataSet.JoinPartsRow joinPartRow = partsInfo.JoinParts.NewJoinPartsRow();

                    joinPartRow.OfferDate = wkInf.OfferDate;
                    joinPartRow.GoodsMGroup = wkInf.GoodsMGroup;
                    joinPartRow.TbsPartsCode = wkInf.TbsPartsCode;
                    joinPartRow.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                    joinPartRow.PrmSetDtlNo1 = wkInf.PrmSetDtlNo1;
                    joinPartRow.PrmSetDtlNo2 = wkInf.PrmSetDtlNo2;
                    joinPartRow.JoinDispOrder = wkInf.JoinDispOrder;
                    joinPartRow.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                    joinPartRow.JoinSourPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                    joinPartRow.JoinSourPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                    joinPartRow.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                    joinPartRow.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    joinPartRow.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                    joinPartRow.PrimePartsName = wkInf.PrimePartsName;
                    joinPartRow.PrimePartsKanaName = wkInf.PrimePartsKanaName;
                    joinPartRow.JoinQty = wkInf.JoinQty;
                    joinPartRow.SetPartsFlg = wkInf.SetPartsFlg;
                    joinPartRow.JoinSpecialNote = wkInf.JoinSpecialNote;

                    partsInfo.JoinParts.AddJoinPartsRow(joinPartRow);

                    #region USR
                    //　優良設定絞込処理
                    bool joinExcludeFlg = false;
                    // 2009.02.12 >>>
                    //PrmSettingUWork prmSetting = null;
                    //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                    //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                    //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                    //{
                    //    joinExcludeFlg = true;
                    //}
                    //else
                    //{
                    //    prmSetting = _drPrmSettingWork[prmKey];
                    //    if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                    //        || (flg && prmSetting.PrimeDisplayCode == 0)) // 優良表示区分が[優良表示区分]以外は表示しない。
                    //        joinExcludeFlg = true;
                    //}

                    // 2009.02.17 >>>
                    //PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                    PrmSettingUWork prmSetting = null;

                    // 結合元と結合先が一致する場合は品番検索での結果の為、セレクトまでで当てる
                    if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                    {
                        prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);
                    }
                    else
                    {
                        prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                    }
                    
                    // 2009.02.17 <<<
                    if (prmSetting == null)
                    {
                        joinExcludeFlg = true;
                    }
                    else
                    {
                        if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                        {
                            // セット品は、優良表示区分が「表示しない」以外は表示する
                            if (prmSetting.PrimeDisplayCode == 0) 
                                joinExcludeFlg = true;
                        }
                        else
                        {
                            if (( flg == false && prmSetting.PrimeDisplayCode != 1 )
                                || ( flg && prmSetting.PrimeDisplayCode == 0 )) // 優良表示区分が[優良表示区分]以外は表示しない。
                                joinExcludeFlg = true;
                        }
                    }

                    // 2009.02.12 <<<
#if !PrimeSet
                    joinExcludeFlg = false;
#endif
                    if (joinExcludeFlg == false)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                            goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                        if (usrGoodsRow == null)
                        {
                            usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                            usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                            usrGoodsRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                            usrGoodsRow.GoodsMakerNm = joinPartRow.JoinDestMakerNm;
                            usrGoodsRow.GoodsMGroup = wkInf.GoodsMGroup;
                            usrGoodsRow.GoodsNo = wkInf.JoinDestPartsNo;
                            usrGoodsRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                            //usrGoodsRow.GoodsNote1 = "";
                            //usrGoodsRow.GoodsNote2 = "";
                            usrGoodsRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                            // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            usrGoodsRow.GoodsSpecialNoteOffer = wkInf.JoinSpecialNote;   // 商品規格・特記事項（提供）
                            // ADD 2013/02/12 T.Yoshioka 2013/03/06配信予定 SCM障害№169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            usrGoodsRow.QTY = wkInf.JoinQty;
                            usrGoodsRow.OfferDate = wkInf.OfferDate;
                            usrGoodsRow.OfferKubun = 4; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                            //usrGoodsRow.TaxationDivCd = 0;
                            usrGoodsRow.OfferDataDiv = 1;

                            usrGoodsRow.GoodsName = wkInf.PrimePartsName; // 商品名：デフォルトは部品名
                            usrGoodsRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                            usrGoodsRow.GoodsOfrName = wkInf.PrimePartsName; // 部品名
                            usrGoodsRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                            usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                            usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                            usrGoodsRow.GoodsRateRank = wkInf.PartsLayerCd;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD

                            // 優良設定の設定値
#if PrimeSet
                            usrGoodsRow.PrmSetDtlName2 = prmSetting.PrmSetDtlName2;
                            usrGoodsRow.DisplayOrder = prmSetting.MakerDispOrder;
                            usrGoodsRow.PrimeDispOrder = prmSetting.PrimeDispOrder;     // 2009.02.17 Add
                            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------->>>>>
                            usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------<<<<<
                            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ---------->>>>>
                            usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // 優良設定詳細名称２(工場向け)
                            usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // 優良設定詳細名称２(カーオーナー向け)
                            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ----------<<<<<
#endif
                            // 2010/02/25 Add >>>
                            if (wkInf.TbsPartsCdDerivedNo != 0)
                            {
                                string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                                   ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                if ((rows != null) && (rows.Length != 0))
                                {
                                    usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                    usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                                    usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                                    usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                }
                            }
                            // 2010/02/25 Add <<<

                            goodsTable.AddUsrGoodsInfoRow(usrGoodsRow);
                        }

                        foreach (OfferJoinPriceRetWork wkJoinPriceInf in PrimePriceList)
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                            //if (wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                            //       && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                            if ( wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                                   && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo 
                                   && wkJoinPriceInf.PrmSetDtlNo1 == wkInf.PrmSetDtlNo1 )
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                            {
                                #region USR Price
                                if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                                wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                    //usrPriceRow.SalesUnitCost = 0;
                                    //usrPriceRow.StockRate = 0;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                                wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                                #endregion
                            }
                        }
                        /////////////////
                        joinPartRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        if (flg) // 品番検索による場合
                        {
                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Parent) != (int)GoodsKind.Parent)
                                usrGoodsRow.GoodsKind += (int)GoodsKind.Parent;
                        }
                        else     // 結合検索による場合
                        {
                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Join) != (int)GoodsKind.Join)
                                usrGoodsRow.GoodsKind += (int)GoodsKind.Join; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                        }
                    }
                    // 2009.02.17 >>>
                    //if (flg == false) // 結合情報があるとき、結合テーブル設定
                    if (flg == false && joinExcludeFlg == false) // 結合情報があるとき、結合テーブル設定
                    // 2009.02.17 <<<
                    {
                        string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                            partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                            partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd,
                            partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, wkInf.JoinSourPartsNoWithH,
                            partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, wkInf.JoinSourceMakerCode);
                        if (partsInfo.UsrJoinParts.Select(rowFilter).Length == 0)
                        {
                            PartsInfoDataSet.UsrJoinPartsRow usrJoinRow = partsInfo.UsrJoinParts.NewUsrJoinPartsRow();
                            usrJoinRow.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                            usrJoinRow.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                            usrJoinRow.JoinDispOrder = wkInf.JoinDispOrder;
                            usrJoinRow.JoinOfferDate = wkInf.OfferDate;
                            usrJoinRow.JoinQty = wkInf.JoinQty;
                            usrJoinRow.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                            usrJoinRow.JoinSpecialNote = wkInf.JoinSpecialNote;
                            usrJoinRow.JoinSrcPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                            usrJoinRow.JoinSrcPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                            usrJoinRow.PrmSettingFlg = !joinExcludeFlg;
                            // 2009.02.17 Add >>>
                            // 優良設定有りの場合は結合順位、優良表示順を再設定
                            if (prmSetting != null)
                            {
                                usrJoinRow.JoinDispOrder += ( prmSetting.MakerDispOrder * 1000000 + prmSetting.PrimeDispOrder * 100 );
                                //usrJoinRow.PrimeDispOrder = prmSetting.PrimeDispOrder;
                            }
                            // 2009.02.17 Add <<<
                            partsInfo.UsrJoinParts.AddUsrJoinPartsRow(usrJoinRow);
                        }
                    }

                    #endregion

                    #region セット部品設定
                    if (SetPartsInfoList != null)
                    {
                        foreach (OfferSetPartsRetWork wkSetPartsInf in SetPartsInfoList)
                        {
                            if (wkSetPartsInf.SubstKubun == 0)
                            {
                                PartsInfoDataSet.GoodsSetRow goodSetRow = null;
                                if (wkSetPartsInf.SetMainMakerCd == wkInf.JoinDestMakerCd
                                    && wkSetPartsInf.SetMainPartsNo == wkInf.JoinDestPartsNo)
                                {
                                    goodSetRow = partsInfo.GoodsSet.NewGoodsSetRow();
                                    goodSetRow.OfferDate = wkSetPartsInf.OfferDate;
                                    goodSetRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                    goodSetRow.TbsPartsCode = wkSetPartsInf.TbsPartsCode;
                                    goodSetRow.TbsPartsCdDerivedNo = wkSetPartsInf.TbsPartsCdDerivedNo;
                                    goodSetRow.SetMainMakerCd = wkSetPartsInf.SetMainMakerCd;
                                    goodSetRow.SetMainPartsNo = wkSetPartsInf.SetMainPartsNo;
                                    goodSetRow.SetSubMakerCd = wkSetPartsInf.SetSubMakerCd;
                                    goodSetRow.SetSubPartsNo = wkSetPartsInf.SetSubPartsNo;
                                    goodSetRow.SetName = wkSetPartsInf.SetName;
                                    goodSetRow.SetQty = wkSetPartsInf.SetQty;
                                    goodSetRow.SetSpecialNote = wkSetPartsInf.SetSpecialNote;
                                    goodSetRow.SubGoodsName = wkSetPartsInf.PrimePartsName;
                                    goodSetRow.PrimePartsKanaName = wkSetPartsInf.PrimePartsKanaName;
                                    goodSetRow.SetSubMakerName = GetPartsMakerName(wkSetPartsInf.SetSubMakerCd);
                                    goodSetRow.SetDisplayOrder = wkSetPartsInf.SetDispOrder;
                                    goodSetRow.CatalogShapeNo = wkSetPartsInf.CatalogShapeNo;
                                    goodSetRow.JoinPartsRowParent = joinPartRow;
                                    partsInfo.GoodsSet.AddGoodsSetRow(goodSetRow);

                                    #region USR
                                    //　優良設定絞込処理
                                    bool setExcludeFlg = false;
                                    // 2009.02.12 >>>
                                    //PrmSettingUWork prmSetting2 = null;
                                    //PrmSettingKey prmKey2 = new PrmSettingKey(_sectionCode, wkSetPartsInf.GoodsMGroup,
                                    //        wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd);
                                    //if (_drPrmSettingWork.ContainsKey(prmKey2) == false)
                                    //{
                                    //    setExcludeFlg = true;
                                    //}
                                    //else
                                    //{
                                    //    prmSetting2 = _drPrmSettingWork[prmKey2];
                                    //    if ((flg == false && prmSetting2.PrimeDisplayCode != 1)
                                    //        || (flg && prmSetting2.PrimeDisplayCode == 0)) // 優良表示区分が[優良表示区分]以外は表示しない。                                        
                                    //        setExcludeFlg = true;
                                    //}

                                    PrmSettingUWork prmSetting2 = SearchPrmSettingUWork(_sectionCode, wkSetPartsInf.GoodsMGroup, wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);
                                    if (prmSetting2 == null)
                                    {
                                        setExcludeFlg = true;
                                    }
                                    else
                                    {
                                        if (prmSetting2.PrimeDisplayCode == 0 ) // 優良表示区分が[優良表示区分]以外は表示しない。                                        
                                            setExcludeFlg = true;
                                    }

                                    // 2009.02.12 <<<
#if !PrimeSet
                                    setExcludeFlg = false;
#endif
                                    if (setExcludeFlg == false)
                                    {
                                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                            goodsTable.FindByGoodsMakerCdGoodsNo(wkSetPartsInf.SetSubMakerCd, wkSetPartsInf.SetSubPartsNo);
                                        if ( usrGoodsRow == null )
                                        {
                                            usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                                            // 2009/11/24 >>>
                                            //usrGoodsRow.BlGoodsCode = wkSetPartsInf.TbsPartsCode;
                                            usrGoodsRow.BlGoodsCode = wkSetPartsInf.PrmPrtTbsPrtCd;
                                            // 2009/11/24 <<<
                                            usrGoodsRow.GoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                            usrGoodsRow.GoodsMakerNm = GetPartsMakerName( wkSetPartsInf.SetSubMakerCd );
                                            usrGoodsRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                            usrGoodsRow.GoodsNo = wkSetPartsInf.SetSubPartsNo;
                                            usrGoodsRow.GoodsNoNoneHyphen = wkSetPartsInf.SetSubPartsNo.Replace( "-", "" );
                                            //usrGoodsRow.GoodsNote1 = "";
                                            //usrGoodsRow.GoodsNote2 = "";
                                            //usrGoodsRow.GoodsSpecialNote = "";
                                            usrGoodsRow.QTY = wkSetPartsInf.SetQty;
                                            usrGoodsRow.OfferDate = wkSetPartsInf.OfferDate;
                                            usrGoodsRow.OfferKubun = 4; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                                            //usrGoodsRow.TaxationDivCd = 0;
                                            usrGoodsRow.OfferDataDiv = 1;

                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 DEL
                                            //usrGoodsRow.GoodsName = wkSetPartsInf.PrimePartsName; // 商品名：デフォルトは部品名
                                            //usrGoodsRow.GoodsNameKana = wkSetPartsInf.PrimePartsKanaName;
                                            //usrGoodsRow.GoodsOfrName = wkSetPartsInf.PrimePartsName; // 部品名
                                            //usrGoodsRow.GoodsOfrNameKana = wkSetPartsInf.PrimePartsKanaName;
                                            //usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                                            //usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 DEL
#if PrimeSet
                                            // 優良設定の設定値
                                            usrGoodsRow.PrmSetDtlName2 = prmSetting2.PrmSetDtlName2;
                                            usrGoodsRow.DisplayOrder = prmSetting2.MakerDispOrder;
                                            // UPD 2015/03/04 SCM高速化Remine#317対応 -------------------------->>>>>
                                            //// ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ---------->>>>>
                                            //usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // 優良設定詳細名称２(工場向け)
                                            //usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // 優良設定詳細名称２(カーオーナー向け)
                                            //// ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ----------<<<<<
                                            usrGoodsRow.PrmSetDtlName2ForFac = prmSetting2.PrmSetDtlName2ForFac; // 優良設定詳細名称２(工場向け)
                                            usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting2.PrmSetDtlName2ForCOw; // 優良設定詳細名称２(カーオーナー向け)
                                            // UPD 2015/03/04 SCM高速化Remine#317対応 --------------------------<<<<<

#endif
                                            goodsTable.AddUsrGoodsInfoRow( usrGoodsRow );
                                        }
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                                        // セット名称を設定
                                        usrGoodsRow.GoodsName = wkSetPartsInf.SetName; // セット名称
                                        // --- ADD m.suzuki 2010/07/14 ---------->>>>>
                                        //usrGoodsRow.GoodsNameKana = wkSetPartsInf.PrimePartsKanaName;
                                        usrGoodsRow.GoodsNameKana = GetKanaString( wkSetPartsInf.SetName ); // セット名称(半角変換してセット)
                                        // --- ADD m.suzuki 2010/07/14 ----------<<<<<
                                        usrGoodsRow.GoodsOfrName = wkSetPartsInf.SetName; // セット名称
                                        // --- ADD m.suzuki 2010/07/14 ---------->>>>>
                                        //usrGoodsRow.GoodsOfrNameKana = wkSetPartsInf.PrimePartsKanaName;
                                        usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsNameKana;
                                        // --- ADD m.suzuki 2010/07/14 ----------<<<<<
                                        usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                                        usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

                                        // 2010/02/25 Add >>>
                                        if (wkSetPartsInf.TbsPartsCdDerivedNo != 0)
                                        {
                                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkSetPartsInf.TbsPartsCode,
                                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkSetPartsInf.TbsPartsCdDerivedNo);
                                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                            if ((rows != null) && (rows.Length != 0))
                                            {
                                                usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                                usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                                usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // セット名称
                                                usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                                usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                                                usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                            }
                                        }
                                        // 2010/02/25 Add <<<

                                        foreach (OfferJoinPriceRetWork wkSetPriceInf in SetPriceList)
                                        {
                                            if ( wkSetPartsInf.SetSubMakerCd == wkSetPriceInf.PartsMakerCd
                                                   && wkSetPartsInf.SetSubPartsNo == wkSetPriceInf.PrimePartsNoWithH )
                                            {
                                                #region USR Price
                                                if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                                    wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                                {
                                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                                    usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                                    usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                                    usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                                    usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                                    usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                                    usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                                    //usrPriceRow.SalesUnitCost = 0;
                                                    //usrPriceRow.StockRate = 0;
                                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                                }
                                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                                                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                                    wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                                {
                                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                                    usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                                    usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                                    usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                                    usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                                    usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                                    usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                                }
                                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                                                #endregion
                                            }
                                        }
                                        ///////////////
                                        goodSetRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                                            usrGoodsRow.GoodsKind += (int)GoodsKind.Set; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                                    }
                                    string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, wkSetPartsInf.SetMainPartsNo,
                                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, wkSetPartsInf.SetMainMakerCd,
                                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkSetPartsInf.SetSubPartsNo,
                                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkSetPartsInf.SetSubMakerCd);
                                    if (partsInfo.UsrSetParts.Select(rowFilter).Length == 0)
                                    {
                                        // セット情報があるとき、セットテーブル設定
                                        PartsInfoDataSet.UsrSetPartsRow usrSetRow = partsInfo.UsrSetParts.NewUsrSetPartsRow();
                                        usrSetRow.CatalogShapeNo = wkSetPartsInf.CatalogShapeNo;
                                        usrSetRow.CntFl = (double)wkSetPartsInf.SetQty;
                                        usrSetRow.DisplayOrder = wkSetPartsInf.SetDispOrder;
                                        usrSetRow.ParentGoodsMakerCd = wkSetPartsInf.SetMainMakerCd;
                                        usrSetRow.ParentGoodsNo = wkSetPartsInf.SetMainPartsNo;
                                        usrSetRow.SubGoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                        usrSetRow.SubGoodsNo = wkSetPartsInf.SetSubPartsNo;
                                        usrSetRow.SetSpecialNote = wkSetPartsInf.SetSpecialNote;
                                        usrSetRow.PrmSettingFlg = !setExcludeFlg;
                                        partsInfo.UsrSetParts.AddUsrSetPartsRow(usrSetRow);
                                    }
                                    #endregion
                                }
                            }
                        }
                    }
                    #endregion
                }
                else // 結合代替の場合  [ 結合代替のセットはない ]
                {
                    #region USR
                    bool excludeFlg = false;
                    // 2009.02.12 >>>
                    //PrmSettingUWork prmSetting = null;
                    //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                    //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                    //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                    //{
                    //    excludeFlg = true;
                    //}
                    //else
                    //{
                    //    prmSetting = _drPrmSettingWork[prmKey];
                    //    if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                    //            || (flg && prmSetting.PrimeDisplayCode == 0)) // 優良表示区分が[優良表示区分]以外は表示しない。
                    //        excludeFlg = true;
                    //}

                    PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                    if (prmSetting == null)
                    {
                        excludeFlg = true;
                    }
                    else
                    {
                        if (( flg == false && prmSetting.PrimeDisplayCode != 1 )
                                || ( flg && prmSetting.PrimeDisplayCode == 0 )) // 優良表示区分が[優良表示区分]以外は表示しない。
                            excludeFlg = true;
                    }

                    // 2009.02.12 <<<
#if !PrimeSet
                    excludeFlg = false;
#endif
                    if (excludeFlg == false)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                            goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                        if (usrGoodsRow == null)
                        {
                            usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                            usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                            usrGoodsRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                            usrGoodsRow.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                            usrGoodsRow.GoodsMGroup = wkInf.GoodsMGroup;
                            usrGoodsRow.GoodsNo = wkInf.JoinDestPartsNo;
                            usrGoodsRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                            //usrGoodsRow.GoodsNote1 = "";
                            //usrGoodsRow.GoodsNote2 = "";
                            usrGoodsRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                            usrGoodsRow.QTY = wkInf.JoinQty;
                            usrGoodsRow.OfferDate = wkInf.OfferDate;
                            usrGoodsRow.OfferKubun = 4; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                            //usrGoodsRow.TaxationDivCd = 0;
                            usrGoodsRow.OfferDataDiv = 1;

                            usrGoodsRow.GoodsName = wkInf.PrimePartsName; // 商品名：デフォルトは部品名
                            usrGoodsRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                            usrGoodsRow.GoodsOfrName = wkInf.PrimePartsName; // 部品名
                            usrGoodsRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                            usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                            usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
#if PrimeSet
                            // 優良設定の設定値
                            usrGoodsRow.PrmSetDtlName2 = prmSetting.PrmSetDtlName2;
                            usrGoodsRow.DisplayOrder = prmSetting.MakerDispOrder;
                            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------>>>>>
                            usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------<<<<<
                            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ---------->>>>>
                            usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // 優良設定詳細名称２(工場向け)
                            usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // 優良設定詳細名称２(カーオーナー向け)
                            // ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ----------<<<<<
#endif
                            goodsTable.AddUsrGoodsInfoRow(usrGoodsRow);

                            PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();
                            usrSubstRow.ChgDestGoodsNo = wkInf.JoinDestPartsNo;
                            usrSubstRow.ChgDestMakerCd = wkInf.JoinDestMakerCd;
                            usrSubstRow.ChgSrcGoodsNo = wkInf.JoinSourPartsNoWithH;
                            usrSubstRow.ChgSrcMakerCd = wkInf.JoinDestMakerCd;
                            partsInfo.UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                        }

                        // 2010/02/25 Add >>>
                        if (wkInf.TbsPartsCdDerivedNo != 0)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                            if ((rows != null) && (rows.Length != 0))
                            {
                                usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                                usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                                usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                            }
                        }
                        // 2010/02/25 Add <<<

                        foreach (OfferJoinPriceRetWork wkJoinPriceInf in PrimePriceList)
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                            //if (wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                            //       && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                            if ( wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                                   && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo 
                                   && wkJoinPriceInf.PrmSetDtlNo1 == wkInf.PrmSetDtlNo1)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                            {
                                #region USR Price
                                if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                    wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                    //usrPriceRow.SalesUnitCost = 0;
                                    //usrPriceRow.StockRate = 0;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                    wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                                #endregion
                            }
                        }
                        if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                            usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                    }
                    #endregion
                }
                #endregion
            }
            if (SetPartsInfoList != null)
            {
                foreach (OfferSetPartsRetWork wkSetPartsInf in SetPartsInfoList)
                {
                    if (flg && searchPrtCtlAcs.BikeSearch == 0 && bikePMakerList.Contains(wkSetPartsInf.SetSubMakerCd))
                    { // 優良品番検索　＆　2輪検索契約なし　＆　2輪部品メーカーの場合
                        continue;
                    }
                    if (searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                         && wkSetPartsInf.SetSubMakerCd == ct_TactiCd // 部品メーカーがタクティー
                         && (carInfoDataSet != null && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd)) // 車のメーカーがトヨタでない
                    {
                        continue;
                    }

                    bool excludeFlg = false;
                    // 2009.02.12 >>>
                    //PrmSettingUWork prmSetting = null;
                    //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkSetPartsInf.GoodsMGroup,
                    //        wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd);
                    //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                    //{
                    //    excludeFlg = true;
                    //}
                    //else
                    //{
                    //    prmSetting = _drPrmSettingWork[prmKey];
                    //    if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                    //            || (flg && prmSetting.PrimeDisplayCode == 0)) // 優良表示区分が[優良表示区分]以外は表示しない。
                    //        excludeFlg = true;
                    //}

                    PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkSetPartsInf.GoodsMGroup, wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd, _drPrmSettingWork);
                    if (prmSetting == null)
                    {
                        excludeFlg = true;
                    }
                    else
                    {
                        if (prmSetting.PrimeDisplayCode == 0 ) // 優良表示区分が[優良表示区分]以外は表示しない。
                            excludeFlg = true;
                    }

                    // 2009.02.12 <<<
#if !PrimeSet
                    excludeFlg = false;
#endif
                    //if (excludeFlg == false)
                    if ( excludeFlg == false && wkSetPartsInf.SubstKubun == 1 ) // セット代替の場合
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                            goodsTable.FindByGoodsMakerCdGoodsNo( wkSetPartsInf.SetSubMakerCd, wkSetPartsInf.SetSubPartsNo );
                        if ( usrGoodsRow == null )
                        {
                            usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                            usrGoodsRow.BlGoodsCode = wkSetPartsInf.TbsPartsCode;
                            usrGoodsRow.GoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                            usrGoodsRow.GoodsMakerNm = GetPartsMakerName( wkSetPartsInf.SetSubMakerCd );
                            usrGoodsRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                            usrGoodsRow.GoodsNo = wkSetPartsInf.SetSubPartsNo;
                            usrGoodsRow.GoodsNoNoneHyphen = wkSetPartsInf.SetSubPartsNo.Replace( "-", "" );
                            //usrGoodsRow.GoodsNote1 = "";
                            //usrGoodsRow.GoodsNote2 = "";
                            //usrGoodsRow.GoodsSpecialNote = "";
                            usrGoodsRow.QTY = wkSetPartsInf.SetQty;
                            usrGoodsRow.OfferDate = wkSetPartsInf.OfferDate;
                            usrGoodsRow.OfferKubun = 4; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                            //usrGoodsRow.TaxationDivCd = 0;
                            usrGoodsRow.OfferDataDiv = 1;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 DEL
                            //usrGoodsRow.GoodsName = wkSetPartsInf.PrimePartsName; // 商品名：デフォルトは部品名
                            //usrGoodsRow.GoodsNameKana = wkSetPartsInf.PrimePartsKanaName;
                            //usrGoodsRow.GoodsOfrName = wkSetPartsInf.PrimePartsName; // 部品名
                            //usrGoodsRow.GoodsOfrNameKana = wkSetPartsInf.PrimePartsKanaName;
                            //usrGoodsRow.SearchPartsFullName = wkSetPartsInf.SearchPartsFullName; // 検索品名
                            //usrGoodsRow.SearchPartsHalfName = wkSetPartsInf.SearchPartsHalfName;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 DEL
                            goodsTable.AddUsrGoodsInfoRow( usrGoodsRow );

                            PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();
                            usrSubstRow.ChgDestGoodsNo = wkSetPartsInf.SetSubPartsNo;
                            usrSubstRow.ChgDestMakerCd = wkSetPartsInf.SetSubMakerCd;
                            usrSubstRow.ChgSrcGoodsNo = wkSetPartsInf.SetMainPartsNo;
                            usrSubstRow.ChgSrcMakerCd = wkSetPartsInf.SetMainMakerCd;
                            partsInfo.UsrSubstParts.AddUsrSubstPartsRow( usrSubstRow );
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                        // セット名称を設定
                        usrGoodsRow.GoodsName = wkSetPartsInf.SetName; // セット名称
                        // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                        //usrGoodsRow.GoodsNameKana = wkSetPartsInf.PrimePartsKanaName;
                        usrGoodsRow.GoodsNameKana = GetKanaString( wkSetPartsInf.SetName ); // セット名称(半角変換後にセット)
                        // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                        usrGoodsRow.GoodsOfrName = wkSetPartsInf.SetName; // セット名称
                        // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                        //usrGoodsRow.GoodsOfrNameKana = wkSetPartsInf.PrimePartsKanaName;
                        usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsNameKana;
                        // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                        usrGoodsRow.SearchPartsFullName = wkSetPartsInf.SearchPartsFullName; // 検索品名
                        usrGoodsRow.SearchPartsHalfName = wkSetPartsInf.SearchPartsHalfName;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

                        // 2010/02/25 Add >>>
                        if (wkSetPartsInf.TbsPartsCdDerivedNo != 0)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkSetPartsInf.TbsPartsCode,
                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkSetPartsInf.TbsPartsCdDerivedNo);
                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                            if ((rows != null) && (rows.Length != 0))
                            {
                                usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // セット名称
                                usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; ; // 検索品名
                                usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                            }
                        }
                        // 2010/02/25 Add <<<

                        foreach (OfferJoinPriceRetWork wkSetPriceInf in SetPriceList)
                        {
                            if ( wkSetPartsInf.SetSubMakerCd == wkSetPriceInf.PartsMakerCd
                                   && wkSetPartsInf.SetSubPartsNo == wkSetPriceInf.PrimePartsNoWithH )
                            {
                                #region USR Price
                                if ( priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo( wkSetPriceInf.PartsMakerCd,
                                    wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH ) == null )
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                    //usrPriceRow.SalesUnitCost = 0;
                                    //usrPriceRow.StockRate = 0;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                    priceTable.AddUsrGoodsPriceRow( usrPriceRow );
                                }
                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                    wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                                #endregion
                            }
                        }
                        if ( (usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst )
                            usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                    }
                }
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 優良部品情報設定
        /// </summary>
        /// <param name="flg">true:優良品番検索によるケース／false:結合検索によるケース</param>
        /// <param name="JoinPartsList"></param>
        /// <param name="PrimePriceList"></param>
        /// <param name="SetPartsInfoList"></param>
        /// <param name="SetPriceList"></param>
        /// <param name="inPara"></param>
        /// <param name="key"></param>
        private void FillJoinSetParts(bool flg, ArrayList JoinPartsList, ArrayList PrimePriceList,
                        ArrayList SetPartsInfoList, ArrayList SetPriceList, GetPartsInfPara inPara, int key)
        {
            // 部品情報が存在する時
            if (JoinPartsList != null && JoinPartsList.Count != 0)
            {
                foreach (OfferJoinPartsRetWork wkInf in JoinPartsList)
                {
                    if (flg && searchPrtCtlAcs.BikeSearch == 0 && bikePMakerList.Contains(wkInf.JoinDestMakerCd))
                    { // 優良品番検索　＆　2輪検索契約なし　＆　2輪部品メーカーの場合
                        continue;
                    }
                    if (searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                         && wkInf.JoinDestMakerCd == ct_TactiCd // 部品メーカーがタクティー
                         && (carInfoDataSet != null && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd)) // 車のメーカーがトヨタでない
                    {
                        continue;
                    }
                    #region 結合部品設定
                    if (wkInf.SubstKubun == 0)
                    {
                        // BLコード枝番対応(※BLコード検索時のみ)
                        if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0)
                        {
                            // 結合元レコードを探す
                            PartsInfoDataSet.PartsInfoRow joinSourceRow =
                                partsInfoDic[key].PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(wkInf.JoinSourceMakerCode, wkInf.JoinSourPartsNoWithH);
                            if (joinSourceRow != null)
                            {
                                // 結合元レコードのBLコード枝番名称を付与する。
                                if (!string.IsNullOrEmpty(wkInf.PrimePartsName)) wkInf.PrimePartsName = wkInf.PrimePartsName + joinSourceRow.TbsPartsCdDerivedNm;
                                if (!string.IsNullOrEmpty(wkInf.PrimePartsKanaName)) wkInf.PrimePartsKanaName = wkInf.PrimePartsKanaName + joinSourceRow.TbsPartsCdDerivedNm;
                                if (!string.IsNullOrEmpty(wkInf.SearchPartsFullName)) wkInf.SearchPartsFullName = wkInf.SearchPartsFullName + joinSourceRow.TbsPartsCdDerivedNm;
                                if (!string.IsNullOrEmpty(wkInf.SearchPartsHalfName)) wkInf.SearchPartsHalfName = wkInf.SearchPartsHalfName + joinSourceRow.TbsPartsCdDerivedNm;
                            }
                        }

                        PartsInfoDataSet.JoinPartsRow joinPartRow = partsInfoDic[key].JoinParts.NewJoinPartsRow();

                        joinPartRow.OfferDate = wkInf.OfferDate;
                        joinPartRow.GoodsMGroup = wkInf.GoodsMGroup;
                        joinPartRow.TbsPartsCode = wkInf.TbsPartsCode;
                        joinPartRow.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        joinPartRow.PrmSetDtlNo1 = wkInf.PrmSetDtlNo1;
                        joinPartRow.PrmSetDtlNo2 = wkInf.PrmSetDtlNo2;
                        joinPartRow.JoinDispOrder = wkInf.JoinDispOrder;
                        joinPartRow.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                        joinPartRow.JoinSourPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                        joinPartRow.JoinSourPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                        joinPartRow.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                        joinPartRow.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                        joinPartRow.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                        joinPartRow.PrimePartsName = wkInf.PrimePartsName;
                        joinPartRow.PrimePartsKanaName = wkInf.PrimePartsKanaName;
                        joinPartRow.JoinQty = wkInf.JoinQty;
                        joinPartRow.SetPartsFlg = wkInf.SetPartsFlg;
                        joinPartRow.JoinSpecialNote = wkInf.JoinSpecialNote;

                        partsInfoDic[key].JoinParts.AddJoinPartsRow(joinPartRow);

                        #region USR
                        //　優良設定絞込処理
                        bool joinExcludeFlg = false;
                        PrmSettingUWork prmSetting = null;

                        // UPD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// 結合元と結合先が一致する場合は品番検索での結果の為、セレクトまでで当てる
                        //if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                        //{
                        //    prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);
                        //}
                        //else
                        //{
                        //    prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                        //}

                        //if (prmSetting == null)
                        //{
                        //    joinExcludeFlg = true;
                        //}
                        //else
                        //{
                        //    if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                        //    {
                        //        // セット品は、優良表示区分が「表示しない」以外は表示する
                        //        if (prmSetting.PrimeDisplayCode == 0)
                        //            joinExcludeFlg = true;
                        //    }
                        //    else
                        //    {
                        //        if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                        //            || (flg && prmSetting.PrimeDisplayCode == 0)) // 優良表示区分が[優良表示区分]以外は表示しない。
                        //            joinExcludeFlg = true;
                        //    }
                        //}
                        #endregion

                        if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                        {
                            // 品番検索の場合・・・結合元と結合先が一致する場合は品番検索での結果の為、セレクトまでで当てる
                            prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);

                            if (prmSetting == null)
                            {
                                joinExcludeFlg = true;
                            }
                            else
                            {
                                if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                                {
                                    // セット品は、優良表示区分が「表示しない」以外は表示する
                                    if (prmSetting.PrimeDisplayCode == 0)
                                        joinExcludeFlg = true;
                                }
                                else
                                {
                                    if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                                        || (flg && prmSetting.PrimeDisplayCode == 0)) // 優良表示区分が[優良表示区分]以外は表示しない。
                                        joinExcludeFlg = true;
                                }
                            }
                        }
                        else
                        {
                            // BLコード検索の場合・・・OFFER_AP の優良部品検索で優良設定絞込を実施済みなので、ここでは優良設定の読込みのみ実施
                            prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                            if (prmSetting == null)
                            {
                                joinExcludeFlg = true;
                            }
                        }
                        // UPD 2014/05/09 速度改善フェーズ２№11,№12 吉岡  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

#if !PrimeSet
                joinExcludeFlg = false;
#endif
                        if (joinExcludeFlg == false)
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                            if (usrGoodsRow == null)
                            {
                                usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                                usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                                usrGoodsRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                                usrGoodsRow.GoodsMakerNm = joinPartRow.JoinDestMakerNm;
                                usrGoodsRow.GoodsMGroup = wkInf.GoodsMGroup;
                                usrGoodsRow.GoodsNo = wkInf.JoinDestPartsNo;
                                usrGoodsRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                                //usrGoodsRow.GoodsNote1 = "";
                                //usrGoodsRow.GoodsNote2 = "";
                                usrGoodsRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                                usrGoodsRow.GoodsSpecialNoteOffer = wkInf.JoinSpecialNote;   // 商品規格・特記事項（提供）
                                usrGoodsRow.QTY = wkInf.JoinQty;
                                usrGoodsRow.OfferDate = wkInf.OfferDate;
                                usrGoodsRow.OfferKubun = 4; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                                //usrGoodsRow.TaxationDivCd = 0;
                                usrGoodsRow.OfferDataDiv = 1;

                                usrGoodsRow.GoodsName = wkInf.PrimePartsName; // 商品名：デフォルトは部品名
                                usrGoodsRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                                usrGoodsRow.GoodsOfrName = wkInf.PrimePartsName; // 部品名
                                usrGoodsRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                                usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                                usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;

                                usrGoodsRow.GoodsRateRank = wkInf.PartsLayerCd;

                                // 優良設定の設定値
#if PrimeSet
                                usrGoodsRow.PrmSetDtlName2 = prmSetting.PrmSetDtlName2;
                                usrGoodsRow.DisplayOrder = prmSetting.MakerDispOrder;
                                usrGoodsRow.PrimeDispOrder = prmSetting.PrimeDispOrder;
                                // ADD 2014/08/13 11070147-00 システムテスト障害№5対応 ------------------------------------------->>>>>
                                usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                                // ADD 2014/08/13 11070147-00 システムテスト障害№5対応 -------------------------------------------<<<<<
                                // ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ---------->>>>>
                                usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // 優良設定詳細名称２(工場向け)
                                usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // 優良設定詳細名称２(カーオーナー向け)
                                // ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ----------<<<<<
#endif
                                if (wkInf.TbsPartsCdDerivedNo != 0)
                                {
                                    string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                                       ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                                    BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                    if ((rows != null) && (rows.Length != 0))
                                    {
                                        usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                        usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                        usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                                        usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                        usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                                        usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                    }
                                }

                                goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);
                            }

                            foreach (OfferJoinPriceRetWork wkJoinPriceInf in PrimePriceList)
                            {
                                if (wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                                       && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo
                                       && wkJoinPriceInf.PrmSetDtlNo1 == wkInf.PrmSetDtlNo1)
                                {
                                    #region USR Price
                                    if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                                    wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                        //usrPriceRow.SalesUnitCost = 0;
                                        //usrPriceRow.StockRate = 0;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                                        priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                                    if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                                    wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                                    #endregion
                                }
                            }
                            joinPartRow.UsrGoodsInfoRowParent = usrGoodsRow;
                            if (flg) // 品番検索による場合
                            {
                                if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Parent) != (int)GoodsKind.Parent)
                                    usrGoodsRow.GoodsKind += (int)GoodsKind.Parent;
                            }
                            else     // 結合検索による場合
                            {
                                if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Join) != (int)GoodsKind.Join)
                                    usrGoodsRow.GoodsKind += (int)GoodsKind.Join; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                            }
                        }
                        if (flg == false && joinExcludeFlg == false) // 結合情報があるとき、結合テーブル設定
                        {
                            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                                partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                                partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd,
                                partsInfoDic[key].UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, wkInf.JoinSourPartsNoWithH,
                                partsInfoDic[key].UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, wkInf.JoinSourceMakerCode);
                            if (partsInfoDic[key].UsrJoinParts.Select(rowFilter).Length == 0)
                            {
                                PartsInfoDataSet.UsrJoinPartsRow usrJoinRow = partsInfoDic[key].UsrJoinParts.NewUsrJoinPartsRow();
                                usrJoinRow.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                                usrJoinRow.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                                usrJoinRow.JoinDispOrder = wkInf.JoinDispOrder;
                                usrJoinRow.JoinOfferDate = wkInf.OfferDate;
                                usrJoinRow.JoinQty = wkInf.JoinQty;
                                usrJoinRow.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                                usrJoinRow.JoinSpecialNote = wkInf.JoinSpecialNote;
                                usrJoinRow.JoinSrcPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                                usrJoinRow.JoinSrcPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                                usrJoinRow.PrmSettingFlg = !joinExcludeFlg;
                                // 優良設定有りの場合は結合順位、優良表示順を再設定
                                if (prmSetting != null)
                                {
                                    usrJoinRow.JoinDispOrder += (prmSetting.MakerDispOrder * 1000000 + prmSetting.PrimeDispOrder * 100);
                                }
                                partsInfoDic[key].UsrJoinParts.AddUsrJoinPartsRow(usrJoinRow);
                            }
                        }

                        #endregion

                        #region セット部品設定
                        if (SetPartsInfoList != null)
                        {
                            foreach (OfferSetPartsRetWork wkSetPartsInf in SetPartsInfoList)
                            {
                                if (wkSetPartsInf.SubstKubun == 0)
                                {
                                    PartsInfoDataSet.GoodsSetRow goodSetRow = null;
                                    if (wkSetPartsInf.SetMainMakerCd == wkInf.JoinDestMakerCd
                                        && wkSetPartsInf.SetMainPartsNo == wkInf.JoinDestPartsNo)
                                    {
                                        goodSetRow = partsInfoDic[key].GoodsSet.NewGoodsSetRow();
                                        goodSetRow.OfferDate = wkSetPartsInf.OfferDate;
                                        goodSetRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                        goodSetRow.TbsPartsCode = wkSetPartsInf.TbsPartsCode;
                                        goodSetRow.TbsPartsCdDerivedNo = wkSetPartsInf.TbsPartsCdDerivedNo;
                                        goodSetRow.SetMainMakerCd = wkSetPartsInf.SetMainMakerCd;
                                        goodSetRow.SetMainPartsNo = wkSetPartsInf.SetMainPartsNo;
                                        goodSetRow.SetSubMakerCd = wkSetPartsInf.SetSubMakerCd;
                                        goodSetRow.SetSubPartsNo = wkSetPartsInf.SetSubPartsNo;
                                        goodSetRow.SetName = wkSetPartsInf.SetName;
                                        goodSetRow.SetQty = wkSetPartsInf.SetQty;
                                        goodSetRow.SetSpecialNote = wkSetPartsInf.SetSpecialNote;
                                        goodSetRow.SubGoodsName = wkSetPartsInf.PrimePartsName;
                                        goodSetRow.PrimePartsKanaName = wkSetPartsInf.PrimePartsKanaName;
                                        goodSetRow.SetSubMakerName = GetPartsMakerName(wkSetPartsInf.SetSubMakerCd);
                                        goodSetRow.SetDisplayOrder = wkSetPartsInf.SetDispOrder;
                                        goodSetRow.CatalogShapeNo = wkSetPartsInf.CatalogShapeNo;
                                        goodSetRow.JoinPartsRowParent = joinPartRow;
                                        partsInfoDic[key].GoodsSet.AddGoodsSetRow(goodSetRow);

                                        #region USR
                                        //　優良設定絞込処理
                                        bool setExcludeFlg = false;

                                        PrmSettingUWork prmSetting2 = SearchPrmSettingUWork(_sectionCode, wkSetPartsInf.GoodsMGroup, wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);
                                        if (prmSetting2 == null)
                                        {
                                            setExcludeFlg = true;
                                        }
                                        else
                                        {
                                            if (prmSetting2.PrimeDisplayCode == 0) // 優良表示区分が[優良表示区分]以外は表示しない。                                        
                                                setExcludeFlg = true;
                                        }

#if !PrimeSet
                                setExcludeFlg = false;
#endif
                                        if (setExcludeFlg == false)
                                        {
                                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                                goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkSetPartsInf.SetSubMakerCd, wkSetPartsInf.SetSubPartsNo);
                                            if (usrGoodsRow == null)
                                            {
                                                usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                                                usrGoodsRow.BlGoodsCode = wkSetPartsInf.PrmPrtTbsPrtCd;
                                                usrGoodsRow.GoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                                usrGoodsRow.GoodsMakerNm = GetPartsMakerName(wkSetPartsInf.SetSubMakerCd);
                                                usrGoodsRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                                usrGoodsRow.GoodsNo = wkSetPartsInf.SetSubPartsNo;
                                                usrGoodsRow.GoodsNoNoneHyphen = wkSetPartsInf.SetSubPartsNo.Replace("-", "");
                                                //usrGoodsRow.GoodsNote1 = "";
                                                //usrGoodsRow.GoodsNote2 = "";
                                                //usrGoodsRow.GoodsSpecialNote = "";
                                                usrGoodsRow.QTY = wkSetPartsInf.SetQty;
                                                usrGoodsRow.OfferDate = wkSetPartsInf.OfferDate;
                                                usrGoodsRow.OfferKubun = 4; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                                                //usrGoodsRow.TaxationDivCd = 0;
                                                usrGoodsRow.OfferDataDiv = 1;

#if PrimeSet
                                                // 優良設定の設定値
                                                usrGoodsRow.PrmSetDtlName2 = prmSetting2.PrmSetDtlName2;
                                                usrGoodsRow.DisplayOrder = prmSetting2.MakerDispOrder;
                                                // ADD 2014/08/13 11070147-00 システムテスト障害№5対応 ------------------------------------------->>>>>
                                                usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                                                // ADD 2014/08/13 11070147-00 システムテスト障害№5対応 -------------------------------------------<<<<<
                                                // UPD 2015/03/04 SCM高速化Redmine#317対応 ---------------------------->>>>>
                                                //// ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ---------->>>>>
                                                //usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // 優良設定詳細名称２(工場向け)
                                                //usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // 優良設定詳細名称２(カーオーナー向け)
                                                //// ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ----------<<<<<
                                                usrGoodsRow.PrmSetDtlName2ForFac = prmSetting2.PrmSetDtlName2ForFac; // 優良設定詳細名称２(工場向け)
                                                usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting2.PrmSetDtlName2ForCOw; // 優良設定詳細名称２(カーオーナー向け)
                                                // UPD 2015/03/04 SCM高速化Redmine#317対応 ----------------------------<<<<<
#endif
                                                goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);
                                            }
                                            // セット名称を設定
                                            usrGoodsRow.GoodsName = wkSetPartsInf.SetName; // セット名称
                                            usrGoodsRow.GoodsNameKana = GetKanaString(wkSetPartsInf.SetName); // セット名称(半角変換してセット)
                                            usrGoodsRow.GoodsOfrName = wkSetPartsInf.SetName; // セット名称
                                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsNameKana;
                                            usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                                            usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;

                                            if (wkSetPartsInf.TbsPartsCdDerivedNo != 0)
                                            {
                                                string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkSetPartsInf.TbsPartsCode,
                                                                                                   ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkSetPartsInf.TbsPartsCdDerivedNo);
                                                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                                if ((rows != null) && (rows.Length != 0))
                                                {
                                                    usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                                    usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                                    usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // セット名称
                                                    usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                                    usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                                                    usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                                }
                                            }

                                            foreach (OfferJoinPriceRetWork wkSetPriceInf in SetPriceList)
                                            {
                                                if (wkSetPartsInf.SetSubMakerCd == wkSetPriceInf.PartsMakerCd
                                                       && wkSetPartsInf.SetSubPartsNo == wkSetPriceInf.PrimePartsNoWithH)
                                                {
                                                    #region USR Price
                                                    if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                                        wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                                    {
                                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                                                        usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                                        usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                                        usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                                        usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                                        usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                                        usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                                        //usrPriceRow.SalesUnitCost = 0;
                                                        //usrPriceRow.StockRate = 0;
                                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                                        priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                                    }
                                                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                                                    if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                                        wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                                    {
                                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                                                        usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                                        usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                                        usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                                        usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                                        usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                                        usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                                    }
                                                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                                                    #endregion
                                                }
                                            }
                                            goodSetRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                                                usrGoodsRow.GoodsKind += (int)GoodsKind.Set; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                                        }
                                        string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                                            partsInfoDic[key].UsrSetParts.ParentGoodsNoColumn.ColumnName, wkSetPartsInf.SetMainPartsNo,
                                            partsInfoDic[key].UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, wkSetPartsInf.SetMainMakerCd,
                                            partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkSetPartsInf.SetSubPartsNo,
                                            partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkSetPartsInf.SetSubMakerCd);
                                        if (partsInfoDic[key].UsrSetParts.Select(rowFilter).Length == 0)
                                        {
                                            // セット情報があるとき、セットテーブル設定
                                            PartsInfoDataSet.UsrSetPartsRow usrSetRow = partsInfoDic[key].UsrSetParts.NewUsrSetPartsRow();
                                            usrSetRow.CatalogShapeNo = wkSetPartsInf.CatalogShapeNo;
                                            usrSetRow.CntFl = (double)wkSetPartsInf.SetQty;
                                            usrSetRow.DisplayOrder = wkSetPartsInf.SetDispOrder;
                                            usrSetRow.ParentGoodsMakerCd = wkSetPartsInf.SetMainMakerCd;
                                            usrSetRow.ParentGoodsNo = wkSetPartsInf.SetMainPartsNo;
                                            usrSetRow.SubGoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                            usrSetRow.SubGoodsNo = wkSetPartsInf.SetSubPartsNo;
                                            usrSetRow.SetSpecialNote = wkSetPartsInf.SetSpecialNote;
                                            usrSetRow.PrmSettingFlg = !setExcludeFlg;
                                            partsInfoDic[key].UsrSetParts.AddUsrSetPartsRow(usrSetRow);
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else // 結合代替の場合  [ 結合代替のセットはない ]
                    {
                        #region USR
                        bool excludeFlg = false;

                        PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                        if (prmSetting == null)
                        {
                            excludeFlg = true;
                        }
                        else
                        {
                            if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                                    || (flg && prmSetting.PrimeDisplayCode == 0)) // 優良表示区分が[優良表示区分]以外は表示しない。
                                excludeFlg = true;
                        }

#if !PrimeSet
                excludeFlg = false;
#endif
                        if (excludeFlg == false)
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                            if (usrGoodsRow == null)
                            {
                                usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                                usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                                usrGoodsRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                                usrGoodsRow.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                                usrGoodsRow.GoodsMGroup = wkInf.GoodsMGroup;
                                usrGoodsRow.GoodsNo = wkInf.JoinDestPartsNo;
                                usrGoodsRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                                //usrGoodsRow.GoodsNote1 = "";
                                //usrGoodsRow.GoodsNote2 = "";
                                usrGoodsRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                                usrGoodsRow.QTY = wkInf.JoinQty;
                                usrGoodsRow.OfferDate = wkInf.OfferDate;
                                usrGoodsRow.OfferKubun = 4; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                                //usrGoodsRow.TaxationDivCd = 0;
                                usrGoodsRow.OfferDataDiv = 1;

                                usrGoodsRow.GoodsName = wkInf.PrimePartsName; // 商品名：デフォルトは部品名
                                usrGoodsRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                                usrGoodsRow.GoodsOfrName = wkInf.PrimePartsName; // 部品名
                                usrGoodsRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                                usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                                usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
#if PrimeSet
                                // 優良設定の設定値
                                usrGoodsRow.PrmSetDtlName2 = prmSetting.PrmSetDtlName2;
                                usrGoodsRow.DisplayOrder = prmSetting.MakerDispOrder;
                                // ADD 2014/08/13 11070147-00 システムテスト障害№5対応 ------------------------------------------->>>>>
                                usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                                // ADD 2014/08/13 11070147-00 システムテスト障害№5対応 -------------------------------------------<<<<<
                                // ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ---------->>>>>
                                usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // 優良設定詳細名称２(工場向け)
                                usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // 優良設定詳細名称２(カーオーナー向け)
                                // ADD 2015/02/23 豊沢 SCM高速化 C向け種別対応 ----------<<<<<
#endif
                                goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);

                                PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();
                                usrSubstRow.ChgDestGoodsNo = wkInf.JoinDestPartsNo;
                                usrSubstRow.ChgDestMakerCd = wkInf.JoinDestMakerCd;
                                usrSubstRow.ChgSrcGoodsNo = wkInf.JoinSourPartsNoWithH;
                                usrSubstRow.ChgSrcMakerCd = wkInf.JoinDestMakerCd;
                                partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                            }

                            if (wkInf.TbsPartsCdDerivedNo != 0)
                            {
                                string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                                   ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                if ((rows != null) && (rows.Length != 0))
                                {
                                    usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                    usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                                    usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                                    usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                }
                            }

                            foreach (OfferJoinPriceRetWork wkJoinPriceInf in PrimePriceList)
                            {
                                if (wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                                       && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo
                                       && wkJoinPriceInf.PrmSetDtlNo1 == wkInf.PrmSetDtlNo1)
                                {
                                    #region USR Price
                                    if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                        wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                        //usrPriceRow.SalesUnitCost = 0;
                                        //usrPriceRow.StockRate = 0;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                                    if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                        wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                                    #endregion
                                }
                            }
                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                                usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                        }
                        #endregion
                    }
                    #endregion
                }
                if (SetPartsInfoList != null)
                {
                    foreach (OfferSetPartsRetWork wkSetPartsInf in SetPartsInfoList)
                    {
                        if (flg && searchPrtCtlAcs.BikeSearch == 0 && bikePMakerList.Contains(wkSetPartsInf.SetSubMakerCd))
                        { // 優良品番検索　＆　2輪検索契約なし　＆　2輪部品メーカーの場合
                            continue;
                        }
                        if (searchPrtCtlAcs.TactiSearch == 0  // タクティ検索契約なし
                             && wkSetPartsInf.SetSubMakerCd == ct_TactiCd // 部品メーカーがタクティー
                             && (carInfoDataSet != null && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd)) // 車のメーカーがトヨタでない
                        {
                            continue;
                        }

                        bool excludeFlg = false;

                        PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkSetPartsInf.GoodsMGroup, wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd, _drPrmSettingWork);
                        if (prmSetting == null)
                        {
                            excludeFlg = true;
                        }
                        else
                        {
                            if (prmSetting.PrimeDisplayCode == 0) // 優良表示区分が[優良表示区分]以外は表示しない。
                                excludeFlg = true;
                        }

#if !PrimeSet
                excludeFlg = false;
#endif
                        if (excludeFlg == false && wkSetPartsInf.SubstKubun == 1) // セット代替の場合
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkSetPartsInf.SetSubMakerCd, wkSetPartsInf.SetSubPartsNo);
                            if (usrGoodsRow == null)
                            {
                                usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                                usrGoodsRow.BlGoodsCode = wkSetPartsInf.TbsPartsCode;
                                usrGoodsRow.GoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                usrGoodsRow.GoodsMakerNm = GetPartsMakerName(wkSetPartsInf.SetSubMakerCd);
                                usrGoodsRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                usrGoodsRow.GoodsNo = wkSetPartsInf.SetSubPartsNo;
                                usrGoodsRow.GoodsNoNoneHyphen = wkSetPartsInf.SetSubPartsNo.Replace("-", "");
                                //usrGoodsRow.GoodsNote1 = "";
                                //usrGoodsRow.GoodsNote2 = "";
                                //usrGoodsRow.GoodsSpecialNote = "";
                                usrGoodsRow.QTY = wkSetPartsInf.SetQty;
                                usrGoodsRow.OfferDate = wkSetPartsInf.OfferDate;
                                usrGoodsRow.OfferKubun = 4; // 提供純正 (0:ユーザー登録／1:提供純正編集／2:提供優良編集／3:提供純正／4:提供優良）
                                //usrGoodsRow.TaxationDivCd = 0;
                                usrGoodsRow.OfferDataDiv = 1;

                                goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);

                                PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();
                                usrSubstRow.ChgDestGoodsNo = wkSetPartsInf.SetSubPartsNo;
                                usrSubstRow.ChgDestMakerCd = wkSetPartsInf.SetSubMakerCd;
                                usrSubstRow.ChgSrcGoodsNo = wkSetPartsInf.SetMainPartsNo;
                                usrSubstRow.ChgSrcMakerCd = wkSetPartsInf.SetMainMakerCd;
                                partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                            }
                            // セット名称を設定
                            usrGoodsRow.GoodsName = wkSetPartsInf.SetName; // セット名称
                            usrGoodsRow.GoodsNameKana = GetKanaString(wkSetPartsInf.SetName); // セット名称(半角変換後にセット)
                            usrGoodsRow.GoodsOfrName = wkSetPartsInf.SetName; // セット名称
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsNameKana;
                            usrGoodsRow.SearchPartsFullName = wkSetPartsInf.SearchPartsFullName; // 検索品名
                            usrGoodsRow.SearchPartsHalfName = wkSetPartsInf.SearchPartsHalfName;

                            if (wkSetPartsInf.TbsPartsCdDerivedNo != 0)
                            {
                                string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkSetPartsInf.TbsPartsCode,
                                                                                   ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkSetPartsInf.TbsPartsCdDerivedNo);
                                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                if ((rows != null) && (rows.Length != 0))
                                {
                                    usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                    usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // セット名称
                                    usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; ; // 検索品名
                                    usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                }
                            }

                            foreach (OfferJoinPriceRetWork wkSetPriceInf in SetPriceList)
                            {
                                if (wkSetPartsInf.SetSubMakerCd == wkSetPriceInf.PartsMakerCd
                                       && wkSetPartsInf.SetSubPartsNo == wkSetPriceInf.PrimePartsNoWithH)
                                {
                                    #region USR Price
                                    if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                        wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                        //usrPriceRow.SalesUnitCost = 0;
                                        //usrPriceRow.StockRate = 0;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                                    if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                        wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
                                    #endregion
                                }
                            }
                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                                usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                        }
                    }
                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region 優良ＢＬ検索結果の設定
        /// <summary>
        /// 優良ＢＬ検索結果の設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="lstPrice"></param>
        private void FillOfrPrimePartsTable(ArrayList list, ArrayList lstPrice)
        {
            long prmPartsProperNo = 0;
            if (list == null)
            {
                return;
            }
            foreach (OfferPrimeSearchRetWork wkInf in list)
            {
                // 2009/10/19 Add >>>
                //　優良設定絞込処理
                bool excludeFlg = false;
                PrmSettingUWork prmSetting = null;

                // 結合元と結合先が一致する場合は品番検索での結果の為、セレクトまでで当てる
                prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.PartsMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                
                if (prmSetting == null)
                {
                    excludeFlg = true;
                }
                else
                {
                    // 優良表示区分が「表示しない」以外は表示する
                    if (prmSetting.PrimeDisplayCode == 0) excludeFlg = true;
                }
#if !PrimeSet
                    excludeFlg = false;
#endif
                if (excludeFlg) continue;
                // 2009/10/19 Add <<<

                bool compressFlg = false;
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.OfrPrimeParts.PartsMakerCdColumn.ColumnName, wkInf.PartsMakerCd,
                    partsInfo.OfrPrimeParts.PrimeOldPartsNoColumn.ColumnName, wkInf.PrimePartsNoWithH);
                PartsInfoDataSet.OfrPrimePartsRow[] rows = (PartsInfoDataSet.OfrPrimePartsRow[])partsInfo.OfrPrimeParts.Select(query);
                if (rows.Length > 0) // 型式違いの重複を防ぐため。（リモートの圧縮は型式まで見る）
                {
                    if (rows[0].StProduceTypeOfYear <= wkInf.StProduceTypeOfYear && rows[0].EdProduceTypeOfYear >= wkInf.StProduceTypeOfYear)
                    {
                        if (rows[0].EdProduceTypeOfYear < wkInf.EdProduceTypeOfYear)
                        {
                            rows[0].EdProduceTypeOfYear = wkInf.EdProduceTypeOfYear;
                        }
                        compressFlg = true;
                    }
                    if (rows[0].StProduceTypeOfYear <= wkInf.EdProduceTypeOfYear && rows[0].EdProduceTypeOfYear >= wkInf.EdProduceTypeOfYear)
                    {
                        if (rows[0].StProduceTypeOfYear > wkInf.StProduceTypeOfYear)
                        {
                            rows[0].StProduceTypeOfYear = wkInf.StProduceTypeOfYear;
                        }
                        compressFlg = true;
                    }
                }
                if (rows.Length == 0 || compressFlg == false)
                {
                    // 2009/10/19 >>>
                    //if (wkInf.PrimePartsNo != string.Empty) // 代替登録
                    if (( wkInf.PrimePartsNo != string.Empty ) && ( wkInf.PrimePartsNo != wkInf.PrimePartsNoWithH )) // 代替登録
                    // 2009/10/19 <<<
                    {
                        if (partsInfo.UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                                wkInf.PrimePartsNo, wkInf.PrimePartsNoWithH, wkInf.PartsMakerCd) == null)
                        {
                            PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();
                            // 2009/10/19 >>>
                            //substRow.ChgSrcGoodsNo = wkInf.PrimePartsNoWithH;
                            //substRow.ChgSrcMakerCd = wkInf.PartsMakerCd;
                            //substRow.ChgDestGoodsNo = wkInf.PrimePartsNo;
                            //substRow.ChgDestMakerCd = wkInf.PartsMakerCd;

                            substRow.ChgSrcGoodsNo = wkInf.PrimePartsNo;
                            substRow.ChgSrcMakerCd = wkInf.PartsMakerCd;
                            substRow.ChgDestGoodsNo = wkInf.PrimePartsNoWithH;
                            substRow.ChgDestMakerCd = wkInf.PartsMakerCd;
                            // 2009/10/19 <<<
                            partsInfo.UsrSubstParts.AddUsrSubstPartsRow(substRow);
                        }
                    }
                    if (wkInf.SubstFlag == 0) // 代替品はここには登録しない。
                    {
                        PartsInfoDataSet.OfrPrimePartsRow row = partsInfo.OfrPrimeParts.NewOfrPrimePartsRow();

                        row.OfferDate = wkInf.OfferDate;
                        prmPartsProperNo = wkInf.PrmPartsProperNo; ;
                        row.PrmPartsProperNo = prmPartsProperNo;
                        row.GoodsMGroup = wkInf.GoodsMGroup;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.PartsMakerCd = wkInf.PartsMakerCd;
                        row.PartsMakerName = GetPartsMakerName(wkInf.PartsMakerCd);
                        row.PrmSetDtlNo1 = wkInf.PrmSetDtlNo1;      // SelectCode
                        row.PrmSetDtlNo2 = wkInf.PrmSetDtlNo2;      // PrimeKindCode
                        row.PrimeSearchDispOrder = wkInf.PartsDispOrder; // PrimeSearchDispOrder
                        // 2009/10/19 >>>
                        //row.PrimePartsNo = wkInf.PrimePartsNo;
                        row.PrimePartsNo = wkInf.PrimePartsNoWithH;
                        // 2009/10/19 <<<
                        row.PrimePartsName = wkInf.PrimePartsName;
                        row.PrimePartsKanaName = wkInf.PrimePartsKanaNm;
                        // 2009/10/19 >>>
                        //row.PrimeOldPartsNo = wkInf.PrimePartsNoWithH;
                        row.PrimeOldPartsNo = wkInf.PrimePartsNo;
                        // 2009/10/19 <<<
                        row.SetPartsFlg = wkInf.SetPartsFlg;
                        row.PrimeQty = wkInf.PrimeQty;
                        row.PrimeSpecialNote = wkInf.PrimeSpecialNote;
                        //row.MakerDispOrder = 0; // 優良設定情報からUI側で設定する。
                        //row.PrimeDispOrder = 0; // 優良設定情報からUI側で設定する。
                        row.StProduceTypeOfYear = wkInf.StProduceTypeOfYear;
                        row.EdProduceTypeOfYear = wkInf.EdProduceTypeOfYear;
                        row.StProduceFrameNo = wkInf.StProduceFrameNo;
                        row.EdProduceFrameNo = wkInf.EdProduceFrameNo;

                        partsInfo.OfrPrimeParts.AddOfrPrimePartsRow(row);
                    }
                }

                // 2009/10/19 >>>
                if (wkInf.DoorCount != 0 || wkInf.BodyName != string.Empty || wkInf.ModelGradeNm != string.Empty ||
                    wkInf.EngineModelNm != string.Empty || wkInf.EngineDisplaceNm != string.Empty || wkInf.EDivNm != string.Empty ||
                    wkInf.TransmissionNm != string.Empty || wkInf.ShiftNm != string.Empty ||
                    wkInf.WheelDriveMethodNm != string.Empty)
                {
                // 2009/10/19 <<<
                    PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = partsInfo.ModelPartsDetail.NewModelPartsDetailRow();

                    modelPartsDetailRow.PartsUniqueNo = prmPartsProperNo;
                    modelPartsDetailRow.PartsMakerCd = wkInf.PartsMakerCd;
                    modelPartsDetailRow.PartsNo = wkInf.PrimePartsNoWithH;

                    //modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                    modelPartsDetailRow.DoorCount = wkInf.DoorCount;
                    modelPartsDetailRow.BodyName = wkInf.BodyName;
                    modelPartsDetailRow.ModelGradeNm = wkInf.ModelGradeNm;
                    modelPartsDetailRow.EngineModelNm = wkInf.EngineModelNm;
                    modelPartsDetailRow.EngineDisplaceNm = wkInf.EngineDisplaceNm;
                    modelPartsDetailRow.EDivNm = wkInf.EDivNm;
                    modelPartsDetailRow.TransmissionNm = wkInf.TransmissionNm;
                    modelPartsDetailRow.ShiftNm = wkInf.ShiftNm;
                    modelPartsDetailRow.WheelDriveMethodNm = wkInf.WheelDriveMethodNm;

                    partsInfo.ModelPartsDetail.AddModelPartsDetailRow(modelPartsDetailRow);
                }     // 2009/10/19 Del
                    
                if (partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH) == null)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow = partsInfo.UsrGoodsInfo.NewUsrGoodsInfoRow();
                    usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrRow.DisplayOrder = wkInf.PartsDispOrder;
                    usrRow.GoodsKind = (int)GoodsKind.Parent;   // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                    usrRow.OfferKubun = 7; // オリジナル部品
                    usrRow.GoodsMakerCd = wkInf.PartsMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.PartsMakerCd);
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.GoodsNo = wkInf.PrimePartsNoWithH;
                    usrRow.GoodsNoNoneHyphen = wkInf.PrimePartsNoNoneH;
                    usrRow.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                    usrRow.QTY = wkInf.PrimeQty;
                    usrRow.GoodsSpecialNote = wkInf.PrimeSpecialNote;
                    usrRow.GoodsRateRank = wkInf.PartsLayerCd;
                    usrRow.OfferDataDiv = 1;
                    usrRow.OfferDate = wkInf.OfferDate;

                    usrRow.GoodsName = wkInf.PrimePartsName; // 商品名：デフォルトは部品名
                    usrRow.GoodsNameKana = wkInf.PrimePartsKanaNm;
                    usrRow.GoodsOfrName = wkInf.PrimePartsName; // 部品名
                    usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaNm;
                    usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                    usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                    // 2010/02/25 Add >>>
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] blrows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrRow.GoodsName = usrRow.GoodsName + blrows[0].TbsPartsFullName;
                            usrRow.GoodsNameKana = usrRow.GoodsNameKana + blrows[0].TbsPartsHalfName;
                            usrRow.GoodsOfrName = usrRow.GoodsOfrName + blrows[0].TbsPartsFullName; // 部品名
                            usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + blrows[0].TbsPartsHalfName;
                            usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + blrows[0].TbsPartsFullName; // 検索品名
                            usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + blrows[0].TbsPartsHalfName;
                        }
                    }
                    // 2010/02/25 Add <<<

                    partsInfo.UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                }
            }
            foreach (OfferJoinPriceRetWork priceWork in lstPrice)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(priceWork.PartsMakerCd, priceWork.PriceStartDate, priceWork.PrimePartsNoWithH);

                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();
                    row.OfferDate = priceWork.OfferDate;
                    row.GoodsMakerCd = priceWork.PartsMakerCd;
                    row.GoodsNo = priceWork.PrimePartsNoWithH;
                    row.ListPrice = priceWork.NewPrice;
                    row.PriceStartDate = priceWork.PriceStartDate;
                    row.OpenPriceDiv = priceWork.OpenPriceDiv;
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(priceWork.PartsMakerCd, priceWork.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                row = null;
                row = ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(priceWork.PartsMakerCd, priceWork.PriceStartDate, priceWork.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTable.NewUsrGoodsPriceRow();
                    row.OfferDate = priceWork.OfferDate;
                    row.GoodsMakerCd = priceWork.PartsMakerCd;
                    row.GoodsNo = priceWork.PrimePartsNoWithH;
                    row.ListPrice = priceWork.NewPrice;
                    row.PriceStartDate = priceWork.PriceStartDate;
                    row.OpenPriceDiv = priceWork.OpenPriceDiv;
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(priceWork.PartsMakerCd, priceWork.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        ofrPriceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// 優良ＢＬ検索結果の設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="lstPrice"></param>
        /// <param name="key"></param>
        private void FillOfrPrimePartsTable(ArrayList list, ArrayList lstPrice, int key)
        {
            long prmPartsProperNo = 0;
            if (list == null)
            {
                return;
            }
            foreach (OfferPrimeSearchRetWork wkInf in list)
            {
                //　優良設定絞込処理
                bool excludeFlg = false;
                PrmSettingUWork prmSetting = null;

                // 結合元と結合先が一致する場合は品番検索での結果の為、セレクトまでで当てる
                prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.PartsMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);

                if (prmSetting == null)
                {
                    excludeFlg = true;
                }
                else
                {
                    // 優良表示区分が「表示しない」以外は表示する
                    if (prmSetting.PrimeDisplayCode == 0) excludeFlg = true;
                }
#if !PrimeSet
                    excludeFlg = false;
#endif
                if (excludeFlg) continue;
                // 2009/10/19 Add <<<

                bool compressFlg = false;
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfoDic[key].OfrPrimeParts.PartsMakerCdColumn.ColumnName, wkInf.PartsMakerCd,
                    partsInfoDic[key].OfrPrimeParts.PrimeOldPartsNoColumn.ColumnName, wkInf.PrimePartsNoWithH);
                PartsInfoDataSet.OfrPrimePartsRow[] rows = (PartsInfoDataSet.OfrPrimePartsRow[])partsInfoDic[key].OfrPrimeParts.Select(query);
                if (rows.Length > 0) // 型式違いの重複を防ぐため。（リモートの圧縮は型式まで見る）
                {
                    if (rows[0].StProduceTypeOfYear <= wkInf.StProduceTypeOfYear && rows[0].EdProduceTypeOfYear >= wkInf.StProduceTypeOfYear)
                    {
                        if (rows[0].EdProduceTypeOfYear < wkInf.EdProduceTypeOfYear)
                        {
                            rows[0].EdProduceTypeOfYear = wkInf.EdProduceTypeOfYear;
                        }
                        compressFlg = true;
                    }
                    if (rows[0].StProduceTypeOfYear <= wkInf.EdProduceTypeOfYear && rows[0].EdProduceTypeOfYear >= wkInf.EdProduceTypeOfYear)
                    {
                        if (rows[0].StProduceTypeOfYear > wkInf.StProduceTypeOfYear)
                        {
                            rows[0].StProduceTypeOfYear = wkInf.StProduceTypeOfYear;
                        }
                        compressFlg = true;
                    }
                }
                if (rows.Length == 0 || compressFlg == false)
                {
                    if ((wkInf.PrimePartsNo != string.Empty) && (wkInf.PrimePartsNo != wkInf.PrimePartsNoWithH)) // 代替登録
                    {
                        if (partsInfoDic[key].UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                                wkInf.PrimePartsNo, wkInf.PrimePartsNoWithH, wkInf.PartsMakerCd) == null)
                        {
                            PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();
                            substRow.ChgSrcGoodsNo = wkInf.PrimePartsNo;
                            substRow.ChgSrcMakerCd = wkInf.PartsMakerCd;
                            substRow.ChgDestGoodsNo = wkInf.PrimePartsNoWithH;
                            substRow.ChgDestMakerCd = wkInf.PartsMakerCd;
                            partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(substRow);
                        }
                    }
                    if (wkInf.SubstFlag == 0) // 代替品はここには登録しない。
                    {
                        PartsInfoDataSet.OfrPrimePartsRow row = partsInfoDic[key].OfrPrimeParts.NewOfrPrimePartsRow();

                        row.OfferDate = wkInf.OfferDate;
                        prmPartsProperNo = wkInf.PrmPartsProperNo; ;
                        row.PrmPartsProperNo = prmPartsProperNo;
                        row.GoodsMGroup = wkInf.GoodsMGroup;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.PartsMakerCd = wkInf.PartsMakerCd;
                        row.PartsMakerName = GetPartsMakerName(wkInf.PartsMakerCd);
                        row.PrmSetDtlNo1 = wkInf.PrmSetDtlNo1;      // SelectCode
                        row.PrmSetDtlNo2 = wkInf.PrmSetDtlNo2;      // PrimeKindCode
                        row.PrimeSearchDispOrder = wkInf.PartsDispOrder; // PrimeSearchDispOrder
                        row.PrimePartsNo = wkInf.PrimePartsNoWithH;
                        row.PrimePartsName = wkInf.PrimePartsName;
                        row.PrimePartsKanaName = wkInf.PrimePartsKanaNm;
                        row.PrimeOldPartsNo = wkInf.PrimePartsNo;
                        row.SetPartsFlg = wkInf.SetPartsFlg;
                        row.PrimeQty = wkInf.PrimeQty;
                        row.PrimeSpecialNote = wkInf.PrimeSpecialNote;
                        //row.MakerDispOrder = 0; // 優良設定情報からUI側で設定する。
                        //row.PrimeDispOrder = 0; // 優良設定情報からUI側で設定する。
                        row.StProduceTypeOfYear = wkInf.StProduceTypeOfYear;
                        row.EdProduceTypeOfYear = wkInf.EdProduceTypeOfYear;
                        row.StProduceFrameNo = wkInf.StProduceFrameNo;
                        row.EdProduceFrameNo = wkInf.EdProduceFrameNo;

                        partsInfoDic[key].OfrPrimeParts.AddOfrPrimePartsRow(row);
                    }
                }

                if (wkInf.DoorCount != 0 || wkInf.BodyName != string.Empty || wkInf.ModelGradeNm != string.Empty ||
                    wkInf.EngineModelNm != string.Empty || wkInf.EngineDisplaceNm != string.Empty || wkInf.EDivNm != string.Empty ||
                    wkInf.TransmissionNm != string.Empty || wkInf.ShiftNm != string.Empty ||
                    wkInf.WheelDriveMethodNm != string.Empty)
                {
                    PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = partsInfoDic[key].ModelPartsDetail.NewModelPartsDetailRow();

                    modelPartsDetailRow.PartsUniqueNo = prmPartsProperNo;
                    modelPartsDetailRow.PartsMakerCd = wkInf.PartsMakerCd;
                    modelPartsDetailRow.PartsNo = wkInf.PrimePartsNoWithH;

                    //modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                    modelPartsDetailRow.DoorCount = wkInf.DoorCount;
                    modelPartsDetailRow.BodyName = wkInf.BodyName;
                    modelPartsDetailRow.ModelGradeNm = wkInf.ModelGradeNm;
                    modelPartsDetailRow.EngineModelNm = wkInf.EngineModelNm;
                    modelPartsDetailRow.EngineDisplaceNm = wkInf.EngineDisplaceNm;
                    modelPartsDetailRow.EDivNm = wkInf.EDivNm;
                    modelPartsDetailRow.TransmissionNm = wkInf.TransmissionNm;
                    modelPartsDetailRow.ShiftNm = wkInf.ShiftNm;
                    modelPartsDetailRow.WheelDriveMethodNm = wkInf.WheelDriveMethodNm;

                    partsInfoDic[key].ModelPartsDetail.AddModelPartsDetailRow(modelPartsDetailRow);
                }

                if (partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH) == null)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow = partsInfoDic[key].UsrGoodsInfo.NewUsrGoodsInfoRow();
                    usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrRow.DisplayOrder = wkInf.PartsDispOrder;
                    usrRow.GoodsKind = (int)GoodsKind.Parent;   // 1:親／2:結合／4:セット子／8:代替／16:代替互換
                    usrRow.OfferKubun = 7; // オリジナル部品
                    usrRow.GoodsMakerCd = wkInf.PartsMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.PartsMakerCd);
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.GoodsNo = wkInf.PrimePartsNoWithH;
                    usrRow.GoodsNoNoneHyphen = wkInf.PrimePartsNoNoneH;
                    usrRow.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                    usrRow.QTY = wkInf.PrimeQty;
                    usrRow.GoodsSpecialNote = wkInf.PrimeSpecialNote;
                    usrRow.GoodsRateRank = wkInf.PartsLayerCd;
                    usrRow.OfferDataDiv = 1;
                    usrRow.OfferDate = wkInf.OfferDate;

                    usrRow.GoodsName = wkInf.PrimePartsName; // 商品名：デフォルトは部品名
                    usrRow.GoodsNameKana = wkInf.PrimePartsKanaNm;
                    usrRow.GoodsOfrName = wkInf.PrimePartsName; // 部品名
                    usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaNm;
                    usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                    usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] blrows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrRow.GoodsName = usrRow.GoodsName + blrows[0].TbsPartsFullName;
                            usrRow.GoodsNameKana = usrRow.GoodsNameKana + blrows[0].TbsPartsHalfName;
                            usrRow.GoodsOfrName = usrRow.GoodsOfrName + blrows[0].TbsPartsFullName; // 部品名
                            usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + blrows[0].TbsPartsHalfName;
                            usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + blrows[0].TbsPartsFullName; // 検索品名
                            usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + blrows[0].TbsPartsHalfName;
                        }
                    }

                    partsInfoDic[key].UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                }
            }
            foreach (OfferJoinPriceRetWork priceWork in lstPrice)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(priceWork.PartsMakerCd, priceWork.PriceStartDate, priceWork.PrimePartsNoWithH);

                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();
                    row.OfferDate = priceWork.OfferDate;
                    row.GoodsMakerCd = priceWork.PartsMakerCd;
                    row.GoodsNo = priceWork.PrimePartsNoWithH;
                    row.ListPrice = priceWork.NewPrice;
                    row.PriceStartDate = priceWork.PriceStartDate;
                    row.OpenPriceDiv = priceWork.OpenPriceDiv;
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(priceWork.PartsMakerCd, priceWork.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                row = null;
                row = ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(priceWork.PartsMakerCd, priceWork.PriceStartDate, priceWork.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTable.NewUsrGoodsPriceRow();
                    row.OfferDate = priceWork.OfferDate;
                    row.GoodsMakerCd = priceWork.PartsMakerCd;
                    row.GoodsNo = priceWork.PrimePartsNoWithH;
                    row.ListPrice = priceWork.NewPrice;
                    row.PriceStartDate = priceWork.PriceStartDate;
                    row.OpenPriceDiv = priceWork.OpenPriceDiv;
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(priceWork.PartsMakerCd, priceWork.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        ofrPriceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region セット情報設定＜優良ＢＬ＞
        /// <summary>
        /// セット情報設定＜優良ＢＬ＞
        /// </summary>
        /// <param name="list"></param>
        /// <param name="priceList"></param>
        private void FillOfrSetInfo(ArrayList list, ArrayList priceList)
        {
            if (list == null)
            {
                return;
            }
            foreach (OfferSetPartsRetWork wkInf in list)
            {
                PartsInfoDataSet.GoodsSetRow goodSetRow = partsInfo.GoodsSet.NewGoodsSetRow();

                goodSetRow.GoodsMGroup = wkInf.GoodsMGroup;
                goodSetRow.TbsPartsCode = wkInf.TbsPartsCode;
                goodSetRow.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                goodSetRow.SetMainMakerCd = wkInf.SetMainMakerCd;
                goodSetRow.SetMainPartsNo = wkInf.SetMainPartsNo;
                goodSetRow.SetSubMakerCd = wkInf.SetSubMakerCd;
                goodSetRow.SetSubPartsNo = wkInf.SetSubPartsNo;
                goodSetRow.SetName = wkInf.SetName;
                goodSetRow.SetQty = wkInf.SetQty;
                goodSetRow.SetSpecialNote = wkInf.SetSpecialNote;

                partsInfo.GoodsSet.AddGoodsSetRow(goodSetRow);

                PartsInfoDataSet.UsrSetPartsRow usrSetRow = partsInfo.UsrSetParts.NewUsrSetPartsRow();

                usrSetRow.ParentGoodsMakerCd = wkInf.SetMainMakerCd;
                usrSetRow.ParentGoodsNo = wkInf.SetMainPartsNo;
                usrSetRow.SubGoodsMakerCd = wkInf.SetSubMakerCd;
                usrSetRow.SubGoodsNo = wkInf.SetSubPartsNo;
                usrSetRow.CntFl = wkInf.SetQty;
                usrSetRow.SetSpecialNote = wkInf.SetSpecialNote;

                partsInfo.UsrSetParts.AddUsrSetPartsRow(usrSetRow);

                PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                    partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.SetSubMakerCd, wkInf.SetSubPartsNo);
                if (usrRow == null)
                {
                    usrRow = partsInfo.UsrGoodsInfo.NewUsrGoodsInfoRow();
                    usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrRow.DisplayOrder = wkInf.SetDispOrder;
                    usrRow.OfferKubun = 4;
                    usrRow.GoodsMakerCd = wkInf.SetSubMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.SetSubMakerCd);
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.GoodsNo = wkInf.SetSubPartsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo.Replace("-", "");
                    usrRow.GoodsSpecialNote = wkInf.SetSpecialNote;
                    usrRow.OfferDate = wkInf.OfferDate;
                    // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                    //usrRow.GoodsName = wkInf.PrimePartsName; // 商品名：デフォルトは部品名
                    //usrRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                    //usrRow.GoodsOfrName = wkInf.PrimePartsName; // 部品名
                    //usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                    usrRow.GoodsName = wkInf.SetName; // セット名称
                    usrRow.GoodsNameKana = GetKanaString( wkInf.SetName ); // セット名称(半角変換後にセット)
                    usrRow.GoodsOfrName = usrRow.GoodsName; // セット名称
                    usrRow.GoodsOfrNameKana = usrRow.GoodsNameKana; // セット名称
                    // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                    usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                    usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                    // 2010/02/25 Add >>>
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrRow.GoodsName = usrRow.GoodsName + rows[0].TbsPartsFullName;
                            usrRow.GoodsNameKana = usrRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrRow.GoodsOfrName = usrRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                            usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                            usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }
                    // 2010/02/25 Add <<<
                    partsInfo.UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                }
                if ((usrRow.GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                    usrRow.GoodsKind += (int)GoodsKind.Set; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
            }
            foreach (OfferJoinPriceRetWork wkSetPriceInf in priceList)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH);
                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();
                    row.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                    row.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                    row.PriceStartDate = wkSetPriceInf.PriceStartDate;
                    row.ListPrice = wkSetPriceInf.NewPrice;
                    row.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                row = null;
                row = ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTable.NewUsrGoodsPriceRow();
                    row.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                    row.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                    row.PriceStartDate = wkSetPriceInf.PriceStartDate;
                    row.ListPrice = wkSetPriceInf.NewPrice;
                    row.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        ofrPriceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// セット情報設定＜優良ＢＬ＞
        /// </summary>
        /// <param name="list"></param>
        /// <param name="priceList"></param>
        /// <param name="dicKey"></param>
        private void FillOfrSetInfo(ArrayList list, ArrayList priceList, int dicKey)
        {
            if (list == null)
            {
                return;
            }
            foreach (OfferSetPartsRetWork wkInf in list)
            {
                PartsInfoDataSet.GoodsSetRow goodSetRow = partsInfoDic[dicKey].GoodsSet.NewGoodsSetRow();

                goodSetRow.GoodsMGroup = wkInf.GoodsMGroup;
                goodSetRow.TbsPartsCode = wkInf.TbsPartsCode;
                goodSetRow.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                goodSetRow.SetMainMakerCd = wkInf.SetMainMakerCd;
                goodSetRow.SetMainPartsNo = wkInf.SetMainPartsNo;
                goodSetRow.SetSubMakerCd = wkInf.SetSubMakerCd;
                goodSetRow.SetSubPartsNo = wkInf.SetSubPartsNo;
                goodSetRow.SetName = wkInf.SetName;
                goodSetRow.SetQty = wkInf.SetQty;
                goodSetRow.SetSpecialNote = wkInf.SetSpecialNote;

                partsInfoDic[dicKey].GoodsSet.AddGoodsSetRow(goodSetRow);

                PartsInfoDataSet.UsrSetPartsRow usrSetRow = partsInfoDic[dicKey].UsrSetParts.NewUsrSetPartsRow();

                usrSetRow.ParentGoodsMakerCd = wkInf.SetMainMakerCd;
                usrSetRow.ParentGoodsNo = wkInf.SetMainPartsNo;
                usrSetRow.SubGoodsMakerCd = wkInf.SetSubMakerCd;
                usrSetRow.SubGoodsNo = wkInf.SetSubPartsNo;
                usrSetRow.CntFl = wkInf.SetQty;
                usrSetRow.SetSpecialNote = wkInf.SetSpecialNote;

                partsInfoDic[dicKey].UsrSetParts.AddUsrSetPartsRow(usrSetRow);

                PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                    partsInfoDic[dicKey].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.SetSubMakerCd, wkInf.SetSubPartsNo);
                if (usrRow == null)
                {
                    usrRow = partsInfoDic[dicKey].UsrGoodsInfo.NewUsrGoodsInfoRow();
                    usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrRow.DisplayOrder = wkInf.SetDispOrder;
                    usrRow.OfferKubun = 4;
                    usrRow.GoodsMakerCd = wkInf.SetSubMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.SetSubMakerCd);
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.GoodsNo = wkInf.SetSubPartsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo.Replace("-", "");
                    usrRow.GoodsSpecialNote = wkInf.SetSpecialNote;
                    usrRow.OfferDate = wkInf.OfferDate;
                    usrRow.GoodsName = wkInf.SetName; // セット名称
                    usrRow.GoodsNameKana = GetKanaString(wkInf.SetName); // セット名称(半角変換後にセット)
                    usrRow.GoodsOfrName = usrRow.GoodsName; // セット名称
                    usrRow.GoodsOfrNameKana = usrRow.GoodsNameKana; // セット名称
                    usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // 検索品名
                    usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrRow.GoodsName = usrRow.GoodsName + rows[0].TbsPartsFullName;
                            usrRow.GoodsNameKana = usrRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrRow.GoodsOfrName = usrRow.GoodsOfrName + rows[0].TbsPartsFullName; // 部品名
                            usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + rows[0].TbsPartsFullName; // 検索品名
                            usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }
                    partsInfoDic[dicKey].UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                }
                if ((usrRow.GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                    usrRow.GoodsKind += (int)GoodsKind.Set; // 1:親／2:結合／4:セット子／8:代替／16:代替互換
            }
            foreach (OfferJoinPriceRetWork wkSetPriceInf in priceList)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH);
                if (row == null)
                {
                    row = priceTableDic[dicKey].NewUsrGoodsPriceRow();
                    row.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                    row.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                    row.PriceStartDate = wkSetPriceInf.PriceStartDate;
                    row.ListPrice = wkSetPriceInf.NewPrice;
                    row.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfoDic[dicKey].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        priceTableDic[dicKey].AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                row = null;
                row = ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH);
                if (row == null)
                {
                    row = ofrPriceTableDic[dicKey].NewUsrGoodsPriceRow();
                    row.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                    row.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                    row.PriceStartDate = wkSetPriceInf.PriceStartDate;
                    row.ListPrice = wkSetPriceInf.NewPrice;
                    row.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfoDic[dicKey].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        ofrPriceTableDic[dicKey].AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region ユーザー結合検索:代替情報設定
        /// <summary>
        /// ユーザー結合検索:代替情報設定
        /// </summary>
        /// <param name="list"></param>
        private void FillUsrSubstPartsTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrPartsSubstRetWork wkInf in list)
            {
                PartsInfoDataSet.UsrSubstPartsRow row =
                    partsInfo.UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(wkInf.SubstDestPartsNo,
                        wkInf.SubstSorPartsNo, wkInf.SubstSorMakerCd);
                if (row == null)
                {
                    row = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();

                    row.ChgSrcMakerCd = wkInf.SubstSorMakerCd;
                    row.ChgSrcGoodsNo = wkInf.SubstSorPartsNo;
                    row.ChgDestMakerCd = wkInf.SubstDestMakerCd;
                    row.ChgDestGoodsNo = wkInf.SubstDestPartsNo;
                    row.ApplyStDate = wkInf.ApplyStDate;
                    row.ApplyEdDate = wkInf.ApplyEdDate;
                    row.OfferKubun = false; // false:ユーザー代替 true:提供代替[デフォルト]

                    partsInfo.UsrSubstParts.AddUsrSubstPartsRow(row);
                }
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ユーザー結合検索:代替情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrSubstPartsTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrPartsSubstRetWork wkInf in list)
            {
                PartsInfoDataSet.UsrSubstPartsRow row =
                    partsInfoDic[key].UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(wkInf.SubstDestPartsNo,
                        wkInf.SubstSorPartsNo, wkInf.SubstSorMakerCd);
                if (row == null)
                {
                    row = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();

                    row.ChgSrcMakerCd = wkInf.SubstSorMakerCd;
                    row.ChgSrcGoodsNo = wkInf.SubstSorPartsNo;
                    row.ChgDestMakerCd = wkInf.SubstDestMakerCd;
                    row.ChgDestGoodsNo = wkInf.SubstDestPartsNo;
                    row.ApplyStDate = wkInf.ApplyStDate;
                    row.ApplyEdDate = wkInf.ApplyEdDate;
                    row.OfferKubun = false; // false:ユーザー代替 true:提供代替[デフォルト]

                    partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(row);
                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region ユーザー結合検索:結合情報設定
        /// <summary>
        /// ユーザー結合検索:結合情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <br>UpdateNote : 2013/03/15　dpp</br>
        /// <br>          　 10901273-00 5月15日配信分（障害以外） Redmine#34377 品番検索結果不具合の修正</br>
        private void FillUsrJoinPartsTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrJoinPartsRetWork wkInf in list)
            {
                // 2009.02.19 >>>
                //PartsInfoDataSet.UsrJoinPartsRow row = partsInfo.UsrJoinParts.NewUsrJoinPartsRow();
                string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} ='{5}' AND {6}={7}", 
                                partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName,
                                wkInf.JoinSourPartsNoWithH,
                                partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName,
                                wkInf.JoinSourceMakerCode,
                                partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName,
                                wkInf.JoinDestPartsNo,
                                partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName,
                                wkInf.JoinDestMakerCd);
                PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(filter);
                PartsInfoDataSet.UsrJoinPartsRow row;

                if (rows != null && rows.Length > 0)
                {
                    row = rows[0];
                    
                }
                else
                {
                    row = partsInfo.UsrJoinParts.NewUsrJoinPartsRow();
                    partsInfo.UsrJoinParts.AddUsrJoinPartsRow(row);
                }
                // 2009.02.19 <<<

                row.JoinDispOrder = wkInf.JoinDispOrder;
                row.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                row.JoinSrcPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                row.JoinSrcPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                row.JoinQty = wkInf.JoinQty;
                row.JoinSpecialNote = wkInf.JoinSpecialNote;
                //row.JoinOfferDate = sourcedr.JoinOfferDate;  // 提供結合は修正不可のため、提供日は不要になった。

                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                if (usrRow != null) // 既に登録されている場合（提供からの設定がある場合）
                {
                }
                else
                {
                    usrRow = goodsTable.NewUsrGoodsInfoRow();
                    //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    usrRow.GoodsNo = wkInf.JoinDestPartsNo;
                    //usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo;// DEL dpp 2013/03/15 Redmine#34377
                    usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-","");// ADD dpp 2013/03/15 Redmine#34377
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.JoinDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    usrRow.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                        usrRow.OfferKubun = 1; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                    else
                        usrRow.OfferKubun = 0; // ユーザー登録
                    goodsTable.AddUsrGoodsInfoRow(usrRow);
                } // ADD 2012/12/10 Y.Wakita
                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                        partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                    partsInfo.UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrJoinParts.DefaultView[i][partsInfo.UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                    partsInfo.UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrSetParts.DefaultView[i][partsInfo.UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    //} // DEL 2012/12/10 Y.Wakita
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //partsInfo.UsrJoinParts.AddUsrJoinPartsRow(row);       // 2009.02.19 Del
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ユーザー結合検索:結合情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrJoinPartsTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrJoinPartsRetWork wkInf in list)
            {
                string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} ='{5}' AND {6}={7}",
                                partsInfoDic[key].UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName,
                                wkInf.JoinSourPartsNoWithH,
                                partsInfoDic[key].UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName,
                                wkInf.JoinSourceMakerCode,
                                partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName,
                                wkInf.JoinDestPartsNo,
                                partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName,
                                wkInf.JoinDestMakerCd);
                PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])partsInfoDic[key].UsrJoinParts.Select(filter);
                PartsInfoDataSet.UsrJoinPartsRow row;

                if (rows != null && rows.Length > 0)
                {
                    row = rows[0];

                }
                else
                {
                    row = partsInfoDic[key].UsrJoinParts.NewUsrJoinPartsRow();
                    partsInfoDic[key].UsrJoinParts.AddUsrJoinPartsRow(row);
                }
                // 2009.02.19 <<<

                row.JoinDispOrder = wkInf.JoinDispOrder;
                row.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                row.JoinSrcPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                row.JoinSrcPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                row.JoinQty = wkInf.JoinQty;
                row.JoinSpecialNote = wkInf.JoinSpecialNote;

                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                if (usrRow != null) // 既に登録されている場合（提供からの設定がある場合）
                {
                }
                else
                {
                    usrRow = goodsTableDic[key].NewUsrGoodsInfoRow();

                    usrRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    usrRow.GoodsNo = wkInf.JoinDestPartsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.JoinDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    usrRow.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                        usrRow.OfferKubun = 1; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                    else
                        usrRow.OfferKubun = 0; // ユーザー登録
                    goodsTableDic[key].AddUsrGoodsInfoRow(usrRow);
                } // ADD 2012/12/10 Y.Wakita
                string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                    partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                    partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = rowFilter;
                for (int i = 0; i < partsInfoDic[key].UsrJoinParts.DefaultView.Count; i++)
                {
                    partsInfoDic[key].UsrJoinParts.DefaultView[i][partsInfoDic[key].UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                }
                rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                    partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                    partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = rowFilter;
                for (int i = 0; i < partsInfoDic[key].UsrSetParts.DefaultView.Count; i++)
                {
                    partsInfoDic[key].UsrSetParts.DefaultView[i][partsInfoDic[key].UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        internal DateTime GetDateTimeFromInt(int time)
        {
            if (time == 0)
                return DateTime.MinValue;
            int year = time / 10000;
            int month = (time / 100) - (year * 100);
            int day = time % 100;
            if (day == 0) // データが可笑しく、年月日の日が0の場合があるので、エラーを防ぐため
                day = 1;
            return new DateTime(year, month, day);
        }

        # region ユーザー結合検索:商品情報設定
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// ユーザー結合検索:商品情報設定
        ///// </summary>
        ///// <param name="list"></param>
        //private void FillUsrGoodsInfoTable(ArrayList list)
        /// <summary>
        /// ユーザー結合検索:商品情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="inPara"></param>
        private void FillUsrGoodsInfoTable( ArrayList list, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrGoodsRetWork wkInf in list)
            {
                // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                // BLコード枝番対応(※BLコード検索時のみ)
                if ( inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0 )
                {
                    try
                    {
                        // 枝番名称適用済みフラグ
                        bool reflectDerivedNmFlag = false;

                        # region [結合元のBLコード枝番名称を適用]
                        // ユーザー結合マスタレコードを探す
                        DataRow[] joinRows = partsInfo.UsrJoinParts.Select(
                                string.Format( "{0}='{1}' AND {2}='{3}'",
                                    partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.GoodsNo,
                                    partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd ) );

                        if ( joinRows != null && joinRows.Length > 0 )
                        {
                            # region [結合元の部品レコードを探す]
                            // 結合元部品レコードを探す
                            int joinSourceMakerCode = (int)joinRows[0][partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName];
                            string joinSrcPartsNoWithH = (string)joinRows[0][partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName];
                            PartsInfoDataSet.PartsInfoRow joinSourceRow = partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( joinSourceMakerCode, joinSrcPartsNoWithH );

                            // 最新品番で再度結合元を探す
                            if ( joinSourceRow == null )
                            {
                                DataRow[] newJoinSourceRows =
                                    partsInfo.PartsInfo.Select(
                                        string.Format( "{0}='{1}' AND {2}='{3}'",
                                            partsInfo.PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName, joinSrcPartsNoWithH,
                                            partsInfo.PartsInfo.CatalogPartsMakerCdColumn.ColumnName, joinSourceMakerCode ) );

                                if ( newJoinSourceRows != null && newJoinSourceRows.Length > 0 )
                                {
                                    joinSourceRow = (PartsInfoDataSet.PartsInfoRow)newJoinSourceRows[0];
                                }
                            }
                            # endregion

                            if ( joinSourceRow != null )
                            {
                                // 結合元レコードのBLコード枝番名称を付与する。
                                if ( !string.IsNullOrEmpty( wkInf.GoodsName ) ) wkInf.GoodsName = wkInf.GoodsName + joinSourceRow.TbsPartsCdDerivedNm;
                                if ( !string.IsNullOrEmpty( wkInf.GoodsNameKana ) ) wkInf.GoodsNameKana = wkInf.GoodsNameKana + joinSourceRow.TbsPartsCdDerivedNm;
                                reflectDerivedNmFlag = true;
                            }
                        }
                        # endregion

                        # region [代替元のBLコード枝番名称を適用]
                        if ( !reflectDerivedNmFlag )
                        {
                            // ユーザー代替マスタレコードを探す
                            DataRow[] substRows = partsInfo.UsrSubstParts.Select(
                                    string.Format( "{0}='{1}' AND {2}='{3}'",
                                        partsInfo.UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, wkInf.GoodsNo,
                                        partsInfo.UsrSubstParts.ChgDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd ) );

                            if ( substRows != null && substRows.Length > 0 )
                            {
                                # region [代替元の部品レコードを探す]
                                // 代替元部品レコードを探す
                                int chgSrcMakerCd = (int)substRows[0][partsInfo.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName];
                                string chgSrcGoodsNo = (string)substRows[0][partsInfo.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName];
                                PartsInfoDataSet.PartsInfoRow substSourceRow = partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( chgSrcMakerCd, chgSrcGoodsNo );

                                // 最新品番で再度代替元を探す
                                if ( substSourceRow == null )
                                {
                                    DataRow[] newSubstSourceRows =
                                        partsInfo.PartsInfo.Select(
                                            string.Format( "{0}='{1}' AND {2}='{3}'",
                                                partsInfo.PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName, chgSrcGoodsNo,
                                                partsInfo.PartsInfo.CatalogPartsMakerCdColumn.ColumnName, chgSrcMakerCd ) );

                                    if ( newSubstSourceRows != null && newSubstSourceRows.Length > 0 )
                                    {
                                        substSourceRow = (PartsInfoDataSet.PartsInfoRow)newSubstSourceRows[0];
                                    }
                                }
                                # endregion

                                if ( substSourceRow != null )
                                {
                                    // 結合元レコードのBLコード枝番名称を付与する。
                                    if ( !string.IsNullOrEmpty( wkInf.GoodsName ) ) wkInf.GoodsName = wkInf.GoodsName + substSourceRow.TbsPartsCdDerivedNm;
                                    if ( !string.IsNullOrEmpty( wkInf.GoodsNameKana ) ) wkInf.GoodsNameKana = wkInf.GoodsNameKana + substSourceRow.TbsPartsCdDerivedNm;
                                    reflectDerivedNmFlag = true;
                                }
                            }
                        }
                        # endregion
                    }
                    catch
                    {
                    }
                }
                // --- ADD m.suzuki 2011/05/18 ----------<<<<<

                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.GoodsMakerCd, wkInf.GoodsNo);
                if (usrRow != null) // 既に登録されている場合（提供からの設定がある場合）
                {
                    //usrRow.GoodsKind += (int)GoodsKind.Parent;
                    usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                    //usrRow.GoodsName = wkInf.GoodsName;
                    //usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    if ( usrRow.GoodsKind == (int)GoodsKind.Set )
                    {
                        // セット子品番ならば、書き換えない (既にセット品名を設定している為)
                    }
                    else
                    {
                        usrRow.GoodsName = wkInf.GoodsName;
                        usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    }
                    // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                    usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.DisplayOrder = wkInf.DisplayOrder;
                    usrRow.GoodsSpecialNote = wkInf.GoodsSpecialNote;
                    if (usrRow.OfferKubun == 3)
                    {
                        usrRow.OfferKubun = 1; // 提供純正編集
                    }
                    else if (usrRow.OfferKubun == 4)
                    {
                        usrRow.OfferKubun = 2; // 提供優良編集
                    }
                    // 2009/10/06 Add >>>
                    // ユーザーが書き換え可能な情報はセットする
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;         
                    usrRow.BlGoodsCode = wkInf.BLGoodsCode;         
                    usrRow.GoodsKindCode = wkInf.GoodsKindCode;
                    usrRow.Jan = wkInf.Jan;
                    usrRow.UpdateDate = wkInf.UpdateDate;
                    usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    // 2009/10/06 Add <<<
                    usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    usrRow.OfferDataDiv = wkInf.OfferDataDiv; // TODO : ここで固定値1を設定すると万が一のデータ不正を防ぐことも可能。
                }
                else
                {
                    usrRow = goodsTable.NewUsrGoodsInfoRow();
                    usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.GoodsMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.GoodsMakerCd);
                    usrRow.GoodsNo = wkInf.GoodsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.GoodsNoNoneHyphen;
                    usrRow.GoodsName = wkInf.GoodsName;
                    usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.BlGoodsCode = wkInf.BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.DisplayOrder;
                    usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.GoodsSpecialNote;
                    usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    usrRow.OfferDate = GetDateTimeFromInt(wkInf.OfferDate);
                    usrRow.GoodsKindCode = wkInf.GoodsKindCode;
                    usrRow.Jan = wkInf.Jan;
                    usrRow.UpdateDate = wkInf.UpdateDate;
                    usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    // 2010/02/25 >>>
                    //if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                    //    usrRow.OfferKubun = 1; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                    //else
                    //    usrRow.OfferKubun = 0; // ユーザー登録

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                    {
                        if (wkInf.GoodsKindCode == 0)
                        {
                            usrRow.OfferKubun = 1; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                        }
                        else
                        {
                            usrRow.OfferKubun = 2; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                        }
                    }
                    else
                    {
                        usrRow.OfferKubun = 0; // ユーザー登録
                    }
                    // 2010/02/25 <<<

                    //row.GoodsKind = (int)GoodsKind.Parent;
                    goodsTable.AddUsrGoodsInfoRow(usrRow);

                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.GoodsNo,
                        partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd);
                    partsInfo.UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrJoinParts.DefaultView[i][partsInfo.UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    //PartsInfoDataSet.UsrJoinPartsRow[] rowJoins =
                    //    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(rowFilter);
                    //for (int i = 0; i < rowJoins.Length; i++)
                    //{
                    //    rowJoins[i].PrmSettingFlg = true;
                    //}
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.GoodsNo,
                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.GoodsMakerCd);
                    partsInfo.UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrSetParts.DefaultView[i][partsInfo.UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    //PartsInfoDataSet.UsrSetPartsRow[] rowSets =
                    //    (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetPartsRow.Select(rowFilter);
                    //for (int i = 0; i < rowSets.Length; i++)
                    //{
                    //    rowSets[i].PrmSettingFlg = true;
                    //}
                }
            }
            partsInfo.UsrJoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrSetParts.DefaultView.RowFilter = string.Empty;
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ユーザー結合検索:商品情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="inPara"></param>
        /// <param name="key"></param>
        private void FillUsrGoodsInfoTable(ArrayList list, GetPartsInfPara inPara, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrGoodsRetWork wkInf in list)
            {
                // BLコード枝番対応(※BLコード検索時のみ)
                if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0)
                {
                    try
                    {
                        // 枝番名称適用済みフラグ
                        bool reflectDerivedNmFlag = false;

                        # region [結合元のBLコード枝番名称を適用]
                        // ユーザー結合マスタレコードを探す
                        DataRow[] joinRows = partsInfoDic[key].UsrJoinParts.Select(
                                string.Format("{0}='{1}' AND {2}='{3}'",
                                    partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.GoodsNo,
                                    partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd));

                        if (joinRows != null && joinRows.Length > 0)
                        {
                            # region [結合元の部品レコードを探す]
                            // 結合元部品レコードを探す
                            int joinSourceMakerCode = (int)joinRows[0][partsInfoDic[key].UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName];
                            string joinSrcPartsNoWithH = (string)joinRows[0][partsInfoDic[key].UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName];
                            PartsInfoDataSet.PartsInfoRow joinSourceRow = partsInfoDic[key].PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(joinSourceMakerCode, joinSrcPartsNoWithH);

                            // 最新品番で再度結合元を探す
                            if (joinSourceRow == null)
                            {
                                DataRow[] newJoinSourceRows =
                                    partsInfoDic[key].PartsInfo.Select(
                                        string.Format("{0}='{1}' AND {2}='{3}'",
                                            partsInfoDic[key].PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName, joinSrcPartsNoWithH,
                                            partsInfoDic[key].PartsInfo.CatalogPartsMakerCdColumn.ColumnName, joinSourceMakerCode));

                                if (newJoinSourceRows != null && newJoinSourceRows.Length > 0)
                                {
                                    joinSourceRow = (PartsInfoDataSet.PartsInfoRow)newJoinSourceRows[0];
                                }
                            }
                            # endregion

                            if (joinSourceRow != null)
                            {
                                // 結合元レコードのBLコード枝番名称を付与する。
                                if (!string.IsNullOrEmpty(wkInf.GoodsName)) wkInf.GoodsName = wkInf.GoodsName + joinSourceRow.TbsPartsCdDerivedNm;
                                if (!string.IsNullOrEmpty(wkInf.GoodsNameKana)) wkInf.GoodsNameKana = wkInf.GoodsNameKana + joinSourceRow.TbsPartsCdDerivedNm;
                                reflectDerivedNmFlag = true;
                            }
                        }
                        # endregion

                        # region [代替元のBLコード枝番名称を適用]
                        if (!reflectDerivedNmFlag)
                        {
                            // ユーザー代替マスタレコードを探す
                            DataRow[] substRows = partsInfoDic[key].UsrSubstParts.Select(
                                    string.Format("{0}='{1}' AND {2}='{3}'",
                                        partsInfoDic[key].UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, wkInf.GoodsNo,
                                        partsInfoDic[key].UsrSubstParts.ChgDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd));

                            if (substRows != null && substRows.Length > 0)
                            {
                                # region [代替元の部品レコードを探す]
                                // 代替元部品レコードを探す
                                int chgSrcMakerCd = (int)substRows[0][partsInfoDic[key].UsrSubstParts.ChgSrcMakerCdColumn.ColumnName];
                                string chgSrcGoodsNo = (string)substRows[0][partsInfoDic[key].UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName];
                                PartsInfoDataSet.PartsInfoRow substSourceRow = partsInfoDic[key].PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(chgSrcMakerCd, chgSrcGoodsNo);

                                // 最新品番で再度代替元を探す
                                if (substSourceRow == null)
                                {
                                    DataRow[] newSubstSourceRows =
                                        partsInfoDic[key].PartsInfo.Select(
                                            string.Format("{0}='{1}' AND {2}='{3}'",
                                                partsInfoDic[key].PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName, chgSrcGoodsNo,
                                                partsInfoDic[key].PartsInfo.CatalogPartsMakerCdColumn.ColumnName, chgSrcMakerCd));

                                    if (newSubstSourceRows != null && newSubstSourceRows.Length > 0)
                                    {
                                        substSourceRow = (PartsInfoDataSet.PartsInfoRow)newSubstSourceRows[0];
                                    }
                                }
                                # endregion

                                if (substSourceRow != null)
                                {
                                    // 結合元レコードのBLコード枝番名称を付与する。
                                    if (!string.IsNullOrEmpty(wkInf.GoodsName)) wkInf.GoodsName = wkInf.GoodsName + substSourceRow.TbsPartsCdDerivedNm;
                                    if (!string.IsNullOrEmpty(wkInf.GoodsNameKana)) wkInf.GoodsNameKana = wkInf.GoodsNameKana + substSourceRow.TbsPartsCdDerivedNm;
                                    reflectDerivedNmFlag = true;
                                }
                            }
                        }
                        # endregion
                    }
                    catch
                    {
                    }
                }

                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.GoodsMakerCd, wkInf.GoodsNo);
                if (usrRow != null) // 既に登録されている場合（提供からの設定がある場合）
                {
                    //usrRow.GoodsKind += (int)GoodsKind.Parent;
                    usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    if (usrRow.GoodsKind == (int)GoodsKind.Set)
                    {
                        // セット子品番ならば、書き換えない (既にセット品名を設定している為)
                    }
                    else
                    {
                        usrRow.GoodsName = wkInf.GoodsName;
                        usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    }
                    usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.DisplayOrder = wkInf.DisplayOrder;
                    usrRow.GoodsSpecialNote = wkInf.GoodsSpecialNote;
                    if (usrRow.OfferKubun == 3)
                    {
                        usrRow.OfferKubun = 1; // 提供純正編集
                    }
                    else if (usrRow.OfferKubun == 4)
                    {
                        usrRow.OfferKubun = 2; // 提供優良編集
                    }
                    // ユーザーが書き換え可能な情報はセットする
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.BlGoodsCode = wkInf.BLGoodsCode;
                    usrRow.GoodsKindCode = wkInf.GoodsKindCode;
                    usrRow.Jan = wkInf.Jan;
                    usrRow.UpdateDate = wkInf.UpdateDate;
                    usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    usrRow.OfferDataDiv = wkInf.OfferDataDiv; // TODO : ここで固定値1を設定すると万が一のデータ不正を防ぐことも可能。
                }
                else
                {
                    usrRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                    usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.GoodsMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.GoodsMakerCd);
                    usrRow.GoodsNo = wkInf.GoodsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.GoodsNoNoneHyphen;
                    usrRow.GoodsName = wkInf.GoodsName;
                    usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.BlGoodsCode = wkInf.BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.DisplayOrder;
                    usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.GoodsSpecialNote;
                    usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    usrRow.OfferDate = GetDateTimeFromInt(wkInf.OfferDate);
                    usrRow.GoodsKindCode = wkInf.GoodsKindCode;
                    usrRow.Jan = wkInf.Jan;
                    usrRow.UpdateDate = wkInf.UpdateDate;
                    usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                    {
                        if (wkInf.GoodsKindCode == 0)
                        {
                            usrRow.OfferKubun = 1; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                        }
                        else
                        {
                            usrRow.OfferKubun = 2; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                        }
                    }
                    else
                    {
                        usrRow.OfferKubun = 0; // ユーザー登録
                    }
                    goodsTableDic[key].AddUsrGoodsInfoRow(usrRow);

                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.GoodsNo,
                        partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd);
                    partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfoDic[key].UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfoDic[key].UsrJoinParts.DefaultView[i][partsInfoDic[key].UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.GoodsNo,
                        partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.GoodsMakerCd);
                    partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfoDic[key].UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfoDic[key].UsrSetParts.DefaultView[i][partsInfoDic[key].UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                }
            }
            partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = string.Empty;
            partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = string.Empty;
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        private void FillUsrGoodsPriceTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (GoodsPriceUWork wkInf in list)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 ADD
                // 提供データ検索結果があれば削除する。（企業コード=空, メーカー・品番が一致）
                DataRow[] deleteRows = priceTable.Select(string.Format("EnterpriseCode = '{0}' AND GoodsMakerCd = '{1}' AND GoodsNo = '{2}'",
                                                                  string.Empty,
                                                                  wkInf.GoodsMakerCd,
                                                                  wkInf.GoodsNo));
                foreach (DataRow deleteRow in deleteRows)
                {
                    priceTable.Rows.Remove(deleteRow);
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 ADD

                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.GoodsMakerCd, wkInf.PriceStartDate, wkInf.GoodsNo);
                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();

                    row.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    row.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    row.EnterpriseCode = wkInf.EnterpriseCode;
                    row.FileHeaderGuid = wkInf.FileHeaderGuid;
                    row.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    row.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    row.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    row.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    row.GoodsMakerCd = wkInf.GoodsMakerCd;
                    row.GoodsNo = wkInf.GoodsNo;
                    row.ListPrice = wkInf.ListPrice;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.SalesUnitCost = wkInf.SalesUnitCost;
                    row.StockRate = wkInf.StockRate;
                    row.OfferDate = wkInf.OfferDate;
                    row.UpdateDate = wkInf.UpdateDate;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow =
                        goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.GoodsMakerCd, wkInf.GoodsNo);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                else
                {
                    row.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    row.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    row.EnterpriseCode = wkInf.EnterpriseCode;
                    row.FileHeaderGuid = wkInf.FileHeaderGuid;
                    row.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    row.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    row.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    row.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    row.ListPrice = wkInf.ListPrice;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;
                    row.SalesUnitCost = wkInf.SalesUnitCost;
                    row.StockRate = wkInf.StockRate;
                }
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  ユーザー商品価格設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrGoodsPriceTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (GoodsPriceUWork wkInf in list)
            {
                // 提供データ検索結果があれば削除する。（企業コード=空, メーカー・品番が一致）
                DataRow[] deleteRows = priceTableDic[key].Select(string.Format("EnterpriseCode = '{0}' AND GoodsMakerCd = '{1}' AND GoodsNo = '{2}'",
                                                                  string.Empty,
                                                                  wkInf.GoodsMakerCd,
                                                                  wkInf.GoodsNo));
                foreach (DataRow deleteRow in deleteRows)
                {
                    priceTableDic[key].Rows.Remove(deleteRow);
                }

                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.GoodsMakerCd, wkInf.PriceStartDate, wkInf.GoodsNo);
                if (row == null)
                {
                    row = priceTableDic[key].NewUsrGoodsPriceRow();

                    row.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    row.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    row.EnterpriseCode = wkInf.EnterpriseCode;
                    row.FileHeaderGuid = wkInf.FileHeaderGuid;
                    row.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    row.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    row.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    row.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    row.GoodsMakerCd = wkInf.GoodsMakerCd;
                    row.GoodsNo = wkInf.GoodsNo;
                    row.ListPrice = wkInf.ListPrice;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.SalesUnitCost = wkInf.SalesUnitCost;
                    row.StockRate = wkInf.StockRate;
                    row.OfferDate = wkInf.OfferDate;
                    row.UpdateDate = wkInf.UpdateDate;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow =
                        goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.GoodsMakerCd, wkInf.GoodsNo);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        priceTableDic[key].AddUsrGoodsPriceRow(row);
                    }
                }
                else
                {
                    row.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    row.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    row.EnterpriseCode = wkInf.EnterpriseCode;
                    row.FileHeaderGuid = wkInf.FileHeaderGuid;
                    row.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    row.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    row.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    row.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    row.ListPrice = wkInf.ListPrice;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;
                    row.SalesUnitCost = wkInf.SalesUnitCost;
                    row.StockRate = wkInf.StockRate;
                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<


        private void FillUsrGoodsStockTable(ArrayList list)
        {
            if (list == null)
                return;
            foreach (StockWork stock in list)
            {
                PartsInfoDataSet.StockRow row =
                    stockTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(stock.WarehouseCode, stock.GoodsNo, stock.GoodsMakerCd);
                if (row == null)
                {
                    row = stockTable.NewStockRow();

                    row.EnterpriseCode = stock.EnterpriseCode;
                    row.AcpOdrCount = stock.AcpOdrCount;
                    row.ArrivalCnt = stock.ArrivalCnt;
                    row.CreateDateTime = stock.CreateDateTime;
                    row.DuplicationShelfNo1 = stock.DuplicationShelfNo1;
                    row.DuplicationShelfNo2 = stock.DuplicationShelfNo2;
                    row.FileHeaderGuid = stock.FileHeaderGuid;
                    row.GoodsMakerCd = stock.GoodsMakerCd;
                    row.GoodsNo = stock.GoodsNo;
                    row.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen;
                    row.LastInventoryUpdate = stock.LastInventoryUpdate;
                    row.LastSalesDate = stock.LastSalesDate;
                    row.LastStockDate = stock.LastStockDate;
                    row.LogicalDeleteCode = stock.LogicalDeleteCode;
                    row.MaximumStockCnt = stock.MaximumStockCnt;
                    row.MinimumStockCnt = stock.MinimumStockCnt;
                    row.MonthOrderCount = stock.MonthOrderCount;
                    row.MovingSupliStock = stock.MovingSupliStock;
                    row.NmlSalOdrCount = stock.NmlSalOdrCount;
                    row.PartsManagementDivide1 = stock.PartsManagementDivide1;
                    row.PartsManagementDivide2 = stock.PartsManagementDivide2;
                    row.SalesOrderCount = stock.SalesOrderCount;
                    row.SalesOrderUnit = stock.SalesOrderUnit;
                    row.SectionCode = stock.SectionCode;
                    row.SectionGuideNm = stock.SectionGuideNm;
                    row.ShipmentCnt = stock.ShipmentCnt;
                    row.ShipmentPosCnt = stock.ShipmentPosCnt;
                    row.StockCreateDate = stock.StockCreateDate;
                    row.StockDiv = stock.StockDiv;
                    row.StockNote1 = stock.StockNote1;
                    row.StockNote2 = stock.StockNote2;
                    row.StockSupplierCode = stock.StockSupplierCode;
                    row.StockTotalPrice = stock.StockTotalPrice;
                    row.StockUnitPriceFl = stock.StockUnitPriceFl;
                    row.SupplierStock = stock.SupplierStock;
                    row.UpdAssemblyId1 = stock.UpdAssemblyId1;
                    row.UpdAssemblyId2 = stock.UpdAssemblyId2;
                    row.UpdateDate = stock.UpdateDate;
                    row.UpdateDateTime = stock.UpdateDateTime;
                    row.UpdEmployeeCode = stock.UpdEmployeeCode;
                    row.WarehouseCode = stock.WarehouseCode.Trim();
                    row.WarehouseName = stock.WarehouseName;
                    row.WarehouseShelfNo = stock.WarehouseShelfNo;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow =
                        goodsTable.FindByGoodsMakerCdGoodsNo(stock.GoodsMakerCd, stock.GoodsNo);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;

                        stockTable.AddStockRow(row);
                    }

                }
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        ///  ユーザー商品在庫設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrGoodsStockTable(ArrayList list, int key)
        {
            if (list == null)
                return;
            foreach (StockWork stock in list)
            {
                PartsInfoDataSet.StockRow row =
                    stockTableDic[key].FindByWarehouseCodeGoodsNoGoodsMakerCd(stock.WarehouseCode, stock.GoodsNo, stock.GoodsMakerCd);
                if (row == null)
                {
                    row = stockTableDic[key].NewStockRow();

                    row.EnterpriseCode = stock.EnterpriseCode;
                    row.AcpOdrCount = stock.AcpOdrCount;
                    row.ArrivalCnt = stock.ArrivalCnt;
                    row.CreateDateTime = stock.CreateDateTime;
                    row.DuplicationShelfNo1 = stock.DuplicationShelfNo1;
                    row.DuplicationShelfNo2 = stock.DuplicationShelfNo2;
                    row.FileHeaderGuid = stock.FileHeaderGuid;
                    row.GoodsMakerCd = stock.GoodsMakerCd;
                    row.GoodsNo = stock.GoodsNo;
                    row.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen;
                    row.LastInventoryUpdate = stock.LastInventoryUpdate;
                    row.LastSalesDate = stock.LastSalesDate;
                    row.LastStockDate = stock.LastStockDate;
                    row.LogicalDeleteCode = stock.LogicalDeleteCode;
                    row.MaximumStockCnt = stock.MaximumStockCnt;
                    row.MinimumStockCnt = stock.MinimumStockCnt;
                    row.MonthOrderCount = stock.MonthOrderCount;
                    row.MovingSupliStock = stock.MovingSupliStock;
                    row.NmlSalOdrCount = stock.NmlSalOdrCount;
                    row.PartsManagementDivide1 = stock.PartsManagementDivide1;
                    row.PartsManagementDivide2 = stock.PartsManagementDivide2;
                    row.SalesOrderCount = stock.SalesOrderCount;
                    row.SalesOrderUnit = stock.SalesOrderUnit;
                    row.SectionCode = stock.SectionCode;
                    row.SectionGuideNm = stock.SectionGuideNm;
                    row.ShipmentCnt = stock.ShipmentCnt;
                    row.ShipmentPosCnt = stock.ShipmentPosCnt;
                    row.StockCreateDate = stock.StockCreateDate;
                    row.StockDiv = stock.StockDiv;
                    row.StockNote1 = stock.StockNote1;
                    row.StockNote2 = stock.StockNote2;
                    row.StockSupplierCode = stock.StockSupplierCode;
                    row.StockTotalPrice = stock.StockTotalPrice;
                    row.StockUnitPriceFl = stock.StockUnitPriceFl;
                    row.SupplierStock = stock.SupplierStock;
                    row.UpdAssemblyId1 = stock.UpdAssemblyId1;
                    row.UpdAssemblyId2 = stock.UpdAssemblyId2;
                    row.UpdateDate = stock.UpdateDate;
                    row.UpdateDateTime = stock.UpdateDateTime;
                    row.UpdEmployeeCode = stock.UpdEmployeeCode;
                    row.WarehouseCode = stock.WarehouseCode.Trim();
                    row.WarehouseName = stock.WarehouseName;
                    row.WarehouseShelfNo = stock.WarehouseShelfNo;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow =
                        goodsTableDic[key].FindByGoodsMakerCdGoodsNo(stock.GoodsMakerCd, stock.GoodsNo);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;

                        stockTableDic[key].AddStockRow(row);
                    }

                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region ユーザー結合検索:セット情報設定
        /// <summary>
        /// ユーザー結合検索:セット情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <br>UpdateNote : 2013/03/15　dpp</br>
        /// <br>          　 10901273-00 5月15日配信分（障害以外） Redmine#34377 品番検索結果不具合の修正</br>
        private void FillUsrSetPartsTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrSetPartsRetWork wkInf in list)
            {
                // 2009.02.19 >>>
                //PartsInfoDataSet.UsrSetPartsRow row = partsInfo.UsrSetParts.NewUsrSetPartsRow();
                string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} ='{5}' AND {6}={7}",
                                partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName,
                                wkInf.SetMainPartsNo,
                                partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName,
                                wkInf.SetMainMakerCd,
                                partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName,
                                wkInf.SetSubPartsNo,
                                partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName,
                                wkInf.SetSubMakerCd);
                PartsInfoDataSet.UsrSetPartsRow[] rows = (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(filter);
                PartsInfoDataSet.UsrSetPartsRow row;

                if (rows != null && rows.Length > 0)
                {
                    row = rows[0];

                }
                else
                {
                    row = partsInfo.UsrSetParts.NewUsrSetPartsRow();
                    partsInfo.UsrSetParts.AddUsrSetPartsRow(row);
                }
                // 2009.02.19 <<<

                row.ParentGoodsMakerCd = wkInf.SetMainMakerCd;
                row.ParentGoodsNo = wkInf.SetMainPartsNo;
                row.SubGoodsMakerCd = wkInf.SetSubMakerCd;
                row.SubGoodsNo = wkInf.SetSubPartsNo;
                row.SetSpecialNote = wkInf.SetSpecialNote;
                row.DisplayOrder = wkInf.SetDispOrder;
                row.CatalogShapeNo = wkInf.CatalogShapeNo;
                row.CntFl = wkInf.SetQty;
                row.SetSpecialNote = wkInf.SetSpecialNote;

                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.SetSubMakerCd, wkInf.SetSubPartsNo);
                if (usrRow != null) // 既に登録されている場合（提供からの設定がある場合）
                {
                }
                else
                {
                    usrRow = goodsTable.NewUsrGoodsInfoRow();
                    //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.SetSubMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.SetSubMakerCd);
                    usrRow.GoodsNo = wkInf.SetSubPartsNo;
                    //usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo; // DEL dpp 2013/03/15 Redmine#34377
                    usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo.Replace("-",""); // ADD dpp 2013/03/15 Redmine#34377
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.SetDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.SetSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    usrRow.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                        usrRow.OfferKubun = 1; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                    else
                        usrRow.OfferKubun = 0; // ユーザー登録
                    goodsTable.AddUsrGoodsInfoRow(usrRow);
                } // ADD 2012/12/10 Y.Wakita
                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.SetSubPartsNo,
                        partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.SetSubMakerCd);
                    partsInfo.UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrJoinParts.DefaultView[i][partsInfo.UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.SetSubPartsNo,
                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.SetSubMakerCd);
                    partsInfo.UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrSetParts.DefaultView[i][partsInfo.UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    //} // DEL 2012/12/10 Y.Wakita
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //partsInfo.UsrSetParts.AddUsrSetPartsRow(row); // 2009.02.19 Del
            }
        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// ユーザー結合検索:セット情報設定
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrSetPartsTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrSetPartsRetWork wkInf in list)
            {
                string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} ='{5}' AND {6}={7}",
                                partsInfoDic[key].UsrSetParts.ParentGoodsNoColumn.ColumnName,
                                wkInf.SetMainPartsNo,
                                partsInfoDic[key].UsrSetParts.ParentGoodsMakerCdColumn.ColumnName,
                                wkInf.SetMainMakerCd,
                                partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName,
                                wkInf.SetSubPartsNo,
                                partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName,
                                wkInf.SetSubMakerCd);
                PartsInfoDataSet.UsrSetPartsRow[] rows = (PartsInfoDataSet.UsrSetPartsRow[])partsInfoDic[key].UsrSetParts.Select(filter);
                PartsInfoDataSet.UsrSetPartsRow row;

                if (rows != null && rows.Length > 0)
                {
                    row = rows[0];

                }
                else
                {
                    row = partsInfoDic[key].UsrSetParts.NewUsrSetPartsRow();
                    partsInfoDic[key].UsrSetParts.AddUsrSetPartsRow(row);
                }
                // 2009.02.19 <<<

                row.ParentGoodsMakerCd = wkInf.SetMainMakerCd;
                row.ParentGoodsNo = wkInf.SetMainPartsNo;
                row.SubGoodsMakerCd = wkInf.SetSubMakerCd;
                row.SubGoodsNo = wkInf.SetSubPartsNo;
                row.SetSpecialNote = wkInf.SetSpecialNote;
                row.DisplayOrder = wkInf.SetDispOrder;
                row.CatalogShapeNo = wkInf.CatalogShapeNo;
                row.CntFl = wkInf.SetQty;
                row.SetSpecialNote = wkInf.SetSpecialNote;

                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.SetSubMakerCd, wkInf.SetSubPartsNo);
                if (usrRow != null) // 既に登録されている場合（提供からの設定がある場合）
                {
                }
                else
                {
                    usrRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                    //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.SetSubMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.SetSubMakerCd);
                    usrRow.GoodsNo = wkInf.SetSubPartsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo.Replace("-", ""); 
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.SetDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.SetSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    usrRow.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                        usrRow.OfferKubun = 1; // ユーザー登録の代替・セット・結合部品の場合提供純正か優良か不明！
                    else
                        usrRow.OfferKubun = 0; // ユーザー登録
                    goodsTableDic[key].AddUsrGoodsInfoRow(usrRow);
                } 
                string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                    partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.SetSubPartsNo,
                    partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.SetSubMakerCd);
                partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = rowFilter;
                for (int i = 0; i < partsInfoDic[key].UsrJoinParts.DefaultView.Count; i++)
                {
                    partsInfoDic[key].UsrJoinParts.DefaultView[i][partsInfoDic[key].UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                }
                rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                    partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.SetSubPartsNo,
                    partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.SetSubMakerCd);
                partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = rowFilter;
                for (int i = 0; i < partsInfoDic[key].UsrSetParts.DefaultView.Count; i++)
                {
                    partsInfoDic[key].UsrSetParts.DefaultView[i][partsInfoDic[key].UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                }
            }
        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        # endregion

        # region ユーザー品番検索：ＵＩテーブル情報＜カタログ・優良＞設定
#if old
        /// <summary>
        /// ユーザー品番検索：ＵＩテーブル情報＜カタログ・優良＞設定
        /// 現在　使っていない
        /// </summary>
        /// <param name="list"></param>
        private void SetUsrGoodsInfoTableFromOfferData(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (OfrPartsRetWork wkInf in list)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = goodsTable.NewUsrGoodsInfoRow();
                row.GoodsMakerCd = wkInf.MakerCode;
                row.GoodsNo = wkInf.PartsNoWithHyphen;
                row.GoodsNoNoneHyphen = wkInf.PartsNoNoneHyphen;
                row.GoodsName = wkInf.PartsName;
                row.GoodsMGroup = wkInf.GoodsMGroup;
                row.BlGoodsCode = wkInf.TbsPartsCode;
                row.GoodsNote1 = string.Empty; // 該当項目なし // wkInf.GoodsNote1;
                row.GoodsNote2 = string.Empty; // 該当項目なし // wkInf.GoodsNote2;
                row.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                row.TaxationDivCd = 0; // 該当項目なし // wkInf.TaxationCode;
                row.OfferDate = GetDateTimeFromInt(wkInf.OfferDate);

                goodsTable.AddUsrGoodsInfoRow(row);
            }
        }

        private void SetUsrGoodsPriceTableFromOfferData(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (OfrPartsPriceRetWork wkInf in list)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row = priceTable.NewUsrGoodsPriceRow();

                row.GoodsMakerCd = wkInf.PartsMakerCd;
                row.GoodsNo = wkInf.PrimePartsNoWithH;
                row.ListPrice = wkInf.NewPrice;
                row.OpenPriceDiv = wkInf.OpenPriceDiv;
                row.PriceStartDate = GetDateTimeFromInt(wkInf.PriceStartDate);
                row.SalesUnitCost = 0; // 該当項目なし
                row.StockRate = 0; // 該当項目なし
                row.OfferDate = GetDateTimeFromInt(wkInf.OfferDate);

                PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                if (parentRow != null)
                {
                    row.UsrGoodsInfoRowParent = parentRow;
                    priceTable.AddUsrGoodsPriceRow(row);
                }
            }
        }
#endif
        # endregion
        # endregion

        #region BLコード取得
        /// <summary>
        /// ＢＬ情報の取得＜提供＞
        /// </summary>
        private void GetOfrBlInf()
        {
            //検索テーブルのクリア
            ofrBLInfo.Clear();
            _ofrBLList = new List<TbsPartsCodeWork>(); // 2010/02/25 Add

            TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
            tbsPartsCodeWork.TbsPartsCode = 0; // BLコード全件取得

            object objret = null;
            try
            {
                iBlGoodsCdDB = MediationTbsPartsCodeDB.GetTbsPartsCodeDB();

                // 2010/02/25 >>>
                //int status = iBlGoodsCdDB.Search(out objret, tbsPartsCodeWork);
                int status = iBlGoodsCdDB.SearchDerived(out objret, tbsPartsCodeWork);
                // 2010/02/25 <<<
                ArrayList list = objret as ArrayList;

                foreach (TbsPartsCodeWork wktbsPartsCodeWork in list)
                //BL部品コード結果クラス
                {
                    BLInfoRow row = ofrBLInfo.NewBLInfoRow();

                    row.SelectionState = false;
                    row.TbsPartsCode = wktbsPartsCodeWork.TbsPartsCode;
                    row.TbsPartsFullName = wktbsPartsCodeWork.TbsPartsFullName;
                    row.TbsPartsHalfName = wktbsPartsCodeWork.TbsPartsHalfName;
                    row.EquipGenreCode = wktbsPartsCodeWork.EquipGenre;
                    row.BLGroupCode = wktbsPartsCodeWork.BLGroupCode;
                    row.GoodsMGroup = wktbsPartsCodeWork.GoodsMGroup;
                    row.TbsPartsCdDerivedNo = wktbsPartsCodeWork.TbsPartsCdDerivedNo;
                    row.PrimeSearchFlg = wktbsPartsCodeWork.PrimeSearchFlg;
                    ofrBLInfo.AddBLInfoRow(row);

                    _ofrBLList.Add(wktbsPartsCodeWork); // 2010/02/25 Add

                }
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// フール型式固定番号からBLコード取得します。
        /// </summary>
        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
        //private void GetCarBlInf()
        private void GetCarBlInf( int blCode )
        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
        {
            // -- ADD 2010/05/25 ------------------------>>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return;
            }
            // -- ADD 2010/05/25 ------------------------<<<

            int[] fullModelFixedNos;
            object retob = new object();
            ArrayList retInt;

            //検索テーブルのクリア
            bLInfo.Clear();

            // UPD 2013/02/14 SCM障害№10354対応 2013/03/06配信 --------------------------------------------------->>>>>
            //fullModelFixedNos = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true);
            // UPD 2013/02/15 2013/03/06配信 システムテスト障害№xxx対応 ----------------------------->>>>>
            //fullModelFixedNos = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, carInfoDataSet.CarModelUIData[0].FrameNo, carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput);

            string frameNo = "";
            int produceTypeOfYearInput = 0;

            if (carInfoDataSet != null && carInfoDataSet.CarModelUIData.Count != 0)
            {
                frameNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                produceTypeOfYearInput = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
            }
            fullModelFixedNos = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, frameNo, produceTypeOfYearInput);
            // UPD 2013/02/15 2013/03/06配信 システムテスト障害№xxx対応 -----------------------------<<<<<
            // UPD 2013/02/14 SCM障害№10354対応 ---------------------------------------------------<<<<<

            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                //int status = iOfferPartsInfo.SearchTbsCodeInfo(fullModelFixedNos, ref retob);
                int status = iOfferPartsInfo.SearchTbsCodeInfo( fullModelFixedNos, blCode, ref retob );
                // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                
                retInt = (ArrayList)((CustomSerializeArrayList)retob)[0];

                if (status == 0 && retInt != null && retInt.Count > 0)
                {
                    FillBLInfoTable(retInt);
                }

            }
            catch
            {
                //throw;
            }

        }

        // ADD 2014/02/06 SCM仕掛一覧№10632対応 ------------------------------------------------->>>>>
        /// <summary>
        /// フル型式固定番号からBLコード取得します。
        /// </summary>
        private void GetCarBlInf(List<int> blCodeList)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return;
            }

            int[] fullModelFixedNos;
            object retob = new object();
            ArrayList retInt;

            //検索テーブルのクリア
            bLInfo.Clear();

            string frameNo = "";
            int produceTypeOfYearInput = 0;

            if (carInfoDataSet != null && carInfoDataSet.CarModelUIData.Count != 0)
            {
                frameNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                produceTypeOfYearInput = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
            }
            fullModelFixedNos = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, frameNo, produceTypeOfYearInput);

            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                // BLコード情報提供データ取得
                if (blCodeList != null && blCodeList.Count != 0)
                {
                    // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№13.フル型式固定番号からのＢＬコード検索回数改良対応 ---------------------------------->>>>>
                    //foreach (int blCode in blCodeList)
                    //{
                    //    int status = iOfferPartsInfo.SearchTbsCodeInfo(fullModelFixedNos, blCode, ref retob);

                    //    retInt = (ArrayList)((CustomSerializeArrayList)retob)[0];

                    //    if (status == 0 && retInt != null && retInt.Count > 0)
                    //    {
                    //        FillBLInfoTable(retInt);
                    //    }
                    //}
                    ArrayList paraList = new ArrayList();
                    paraList.AddRange(blCodeList);

                    int status = iOfferPartsInfo.SearchTbsCodeInfo(fullModelFixedNos, paraList, ref retob);

                    // UPD 2014/08/13 11070147-00 システムテスト障害№20対応 -------------------------->>>>>
                    retInt = (ArrayList)((CustomSerializeArrayList)retob)[0];
                    CustomSerializeArrayList tempInt = (CustomSerializeArrayList)retob;
                    if (tempInt != null && tempInt.Count != 0)
                    {
                        retInt = (ArrayList)((CustomSerializeArrayList)retob)[0];
                    }
                    else
                    {
                        retInt = null;
                    }
                    // UPD 2014/08/13 11070147-00 システムテスト障害№20対応 --------------------------<<<<<

                    if (status == 0 && retInt != null && retInt.Count > 0)
                    {
                        FillBLInfoTable(retInt);
                    }
                    // UPD 2014/05/13 PM-SCM速度改良 フェーズ２№13.フル型式固定番号からのＢＬコード検索回数改良対応 ----------------------------------<<<<<
                }
            }
            catch
            {
                //throw;
            }

        }
        // ADD 2014/02/06 SCM仕掛一覧№10632対応 -------------------------------------------------<<<<<

        /// <summary>
        /// ＢＬ情報設定＜車輌＞
        /// </summary>
        /// <param name="list"></param>
        private void FillBLInfoTable(ArrayList list)
        {
            foreach (RetTbsPartsCodeWork wkInf in list)
            {
                if (searchPrtCtlAcs.IsBLEnabled(wkInf.TbsPartsCode))
                {
                    BLInfoRow row = bLInfo.NewBLInfoRow();

                    row.SelectionState = false;
                    row.TbsPartsCode = wkInf.TbsPartsCode;
                    row.TbsPartsFullName = wkInf.TbsPartsFullName;
                    row.TbsPartsHalfName = wkInf.TbsPartsHalfName;
                    row.PrimeSearchFlg = wkInf.PrimeSearchFlg;
                    row.EquipGenreCode = wkInf.EquipGenre;
                    row.BLGroupCode = 0;////////////////////////////////
                    row.GoodsMGroup = 0;////////////////////////////////
                    row.TbsPartsCdDerivedNo = 0;

                    bLInfo.AddBLInfoRow(row);
                }
            }

        }
        #endregion

        // 2009.02.12 Add >>>
        #region 優良設定の検索
        /// <summary>
        /// 優良設定リストから、対象の優良設定を取得します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <param name="partsMakerCd">部品メーカーコード</param>
        /// <param name="prmSetDtlNo1">優良設定詳細コード１（セレクトコード）</param>
        /// <param name="prmSetDtlNo2">優良設定詳細コード２（種別コード）</param>
        /// <param name="prmSettingUWorkList">優良設定リスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.02.12</br>
        /// </remarks>
        private static PrmSettingUWork SearchPrmSettingUWork(string sectionCode, int goodsMGroup, int tbsPartsCode, int partsMakerCd, int prmSetDtlNo1, int prmSetDtlNo2, List<PrmSettingUWork> prmSettingUWorkList)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( prmSettingUWorkList == null )
            {
                return null;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            return prmSettingUWorkList.Find(
                        delegate(PrmSettingUWork prmSettingUWork)
                        {
                            if (( prmSettingUWork.PrmSetDtlNo2 == prmSetDtlNo2 ) &&
                                ( prmSettingUWork.PrmSetDtlNo1 == prmSetDtlNo1 ) &&
                                ( prmSettingUWork.PartsMakerCd == partsMakerCd ) &&
                                ( prmSettingUWork.TbsPartsCode == tbsPartsCode ) &&
                                ( prmSettingUWork.GoodsMGroup == goodsMGroup ) &&
                                ( prmSettingUWork.SectionCode.Trim() == sectionCode.Trim() ))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        });
        }

        /// <summary>
        /// 優良設定リストから、対象の優良設定を取得します。（セット専用）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <param name="partsMakerCd">部品メーカーコード</param>
        /// <param name="prmSetDtlNo1">優良設定詳細コード１（セレクトコード）</param>
        /// <param name="prmSettingUWorkList">優良設定リスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.02.17</br>
        /// </remarks>
        private static PrmSettingUWork SearchPrmSettingUWork(string sectionCode, int goodsMGroup, int tbsPartsCode, int partsMakerCd, int prmSetDtlNo1, List<PrmSettingUWork> prmSettingUWorkList)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( prmSettingUWorkList == null )
            {
                return null;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            PrmSettingUWork retPrmSettingUWork = null;
            List<PrmSettingUWork> list = prmSettingUWorkList.FindAll(
                                            delegate(PrmSettingUWork prmSettingUWork)
                                            {
                                                if (( prmSettingUWork.PrmSetDtlNo1 == prmSetDtlNo1 ) &&
                                                    ( prmSettingUWork.PartsMakerCd == partsMakerCd ) &&
                                                    ( prmSettingUWork.TbsPartsCode == tbsPartsCode ) &&
                                                    ( prmSettingUWork.GoodsMGroup == goodsMGroup ) &&
                                                    ( prmSettingUWork.SectionCode.Trim() == sectionCode.Trim() ))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            });
            if (list != null && list.Count > 0)
            {
                foreach (PrmSettingUWork prmSettingUWork in list)
                {
                    if (retPrmSettingUWork == null) retPrmSettingUWork = prmSettingUWork;

                    // 部品になっている場合は終了
                    if (retPrmSettingUWork.PrimeDisplayCode != 0) break;

                    // 戻り値が「表示無し」の場合は置換
                    if (retPrmSettingUWork.PrimeDisplayCode == 0)
                    {
                        retPrmSettingUWork = prmSettingUWork;
                    }
                }
            }
            return retPrmSettingUWork;
        }

        /// <summary>
        /// 優良設定リストから、対象の優良設定を取得します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <param name="partsMakerCd">部品メーカーコード</param>
        /// <param name="prmSettingUWorkList">優良設定リスト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.02.12</br>
        /// </remarks>
        private static PrmSettingUWork SearchPrmSettingUWork(string sectionCode, int goodsMGroup, int tbsPartsCode, int partsMakerCd, List<PrmSettingUWork> prmSettingUWorkList)
        {
            return SearchPrmSettingUWork(sectionCode, goodsMGroup, tbsPartsCode, partsMakerCd, 0, 0, prmSettingUWorkList);
        }
        #endregion
        // 2009.02.12 Add <<<

        // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region 離島価格反映
        /// <summary>
        /// 離島価格反映イベントコール
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="offerKubun">提供区分</param>
        /// <param name="listPrice">標準価格</param>
        private void ReflectIsolIslandCall(int taxationCode, int goodsMakerCd, int offerKubun, ref double listPrice)
        {
            if (this.ReflectIsolIsland != null) this.ReflectIsolIsland(taxationCode, goodsMakerCd, offerKubun, ref listPrice);
        }
        #endregion
        // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

        #region 価格情報取得処理
        // 2009.04.14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 価格情報取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMGroup">中分類コード</param>
        /// <param name="blCode">ＢＬコード</param>
        /// <param name="goodsPriceUWorkList">価格情報リスト</param>
        /// <returns></returns>
        public int GetGoodsPrice(string sectionCode, int goodsMakerCd, string goodsNo, int goodsMGroup, int blCode, out ArrayList goodsPriceUWorkList)
        {
            // -- ADD 2010/05/25 ------------------------>>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                goodsPriceUWorkList = null;
                return 0;
            }
            // -- ADD 2010/05/25 ------------------------<<<

            goodsPriceUWorkList = null;
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
            ArrayList lstCond = new ArrayList();
            ArrayList lstRst;
            ArrayList lstRstPrm;
            ArrayList lstPrmPrice;

            OfrPrtsSrchCndWork work = new OfrPrtsSrchCndWork();
            work.MakerCode = goodsMakerCd;
            work.PrtsNo = goodsNo;
            lstCond.Add(work);

            if (iOfferPartsInfo == null) iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
            int status = iOfferPartsInfo.GetOfrPartsInf(lstCond, out lstRst, out lstRstPrm, out lstPrmPrice);
            if (status == 0)
            {
                PrmSettingUWork prmSetting = SearchPrmSettingUWork(sectionCode, goodsMGroup, blCode, goodsMakerCd, _drPrmSettingWork);
                if (prmSetting != null)
                {
                    if ((lstPrmPrice != null) && (lstPrmPrice.Count != 0))
                    {
                        // 優良価格
                        foreach (OfferJoinPriceRetWork retWork in lstPrmPrice)
                        {
                            goodsPriceUWork = new GoodsPriceUWork();
                            goodsPriceUWork.GoodsMakerCd = retWork.PartsMakerCd;
                            goodsPriceUWork.GoodsNo = retWork.PrimePartsNoWithH;
                            goodsPriceUWork.ListPrice = retWork.NewPrice;
                            goodsPriceUWork.OfferDate = retWork.OfferDate;
                            goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
                            goodsPriceUWork.PriceStartDate = retWork.PriceStartDate;

                            goodsPriceUWorkList.Add(goodsPriceUWork);
                        }
                    }
                }
                else
                {
                    if ((lstRst != null) && (lstRst.Count != 0))
                    {
                        // 純正価格
                        foreach (RetPartsInf retWork in lstRst)
                        {
                            goodsPriceUWork = new GoodsPriceUWork();
                            goodsPriceUWork.GoodsMakerCd = retWork.CatalogPartsMakerCd;
                            goodsPriceUWork.GoodsNo = retWork.ClgPrtsNoWithHyphen;
                            goodsPriceUWork.ListPrice = retWork.PartsPrice;
                            goodsPriceUWork.OfferDate = retWork.OfferDate;
                            goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
                            goodsPriceUWork.PriceStartDate = retWork.PartsPriceStDate;

                            goodsPriceUWorkList.Add(goodsPriceUWork);
                        }
                    }
                }

            }

            return status;

        }

        /// <summary>
        /// 層別情報取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMGroup">中分類コード</param>
        /// <param name="blCode">ＢＬコード</param>
        /// <param name="goodsRateRank">層別</param>
        /// <returns></returns>
        public int GetGoodsRateRank(string sectionCode, int goodsMakerCd, string goodsNo, int goodsMGroup, int blCode, out string goodsRateRank)
        {
            // -- ADD 2010/05/25 -------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                goodsRateRank = string.Empty;
                return 0;
            }
            // -- ADD 2010/05/25 --------------------<<<

            goodsRateRank = string.Empty;
            ArrayList lstCond = new ArrayList();
            ArrayList lstRst;
            ArrayList lstRstPrm;
            ArrayList lstPrmPrice;

            OfrPrtsSrchCndWork work = new OfrPrtsSrchCndWork();
            work.MakerCode = goodsMakerCd;
            work.PrtsNo = goodsNo;
            lstCond.Add(work);

            if (iOfferPartsInfo == null) iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
            int status = iOfferPartsInfo.GetOfrPartsInf(lstCond, out lstRst, out lstRstPrm, out lstPrmPrice);
            if (status == 0)
            {
                PrmSettingUWork prmSetting = SearchPrmSettingUWork(sectionCode, goodsMGroup, blCode, goodsMakerCd, _drPrmSettingWork);
                if (prmSetting != null)
                {
                    // 優良情報
                    if ((lstRstPrm != null) && (lstRstPrm.Count != 0))
                    {
                        goodsRateRank = ((OfferJoinPartsRetWork)lstRstPrm[0]).PartsLayerCd;
                    }
                }
                else
                {
                    // 純正情報
                    if ((lstRst != null) && (lstRst.Count != 0))
                    {
                        goodsRateRank = ((RetPartsInf)lstRst[0]).PartsLayerCd;
                    }
                }

            }

            return status;

        }
        // 2009.04.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        // --- ADD m.suzuki 2010/07/14 ---------->>>>>
        /// <summary>
        /// 全角⇒半角変換
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private static string GetKanaString( string orgString )
        {
            // 全角⇒半角変換（途中に含まれる変換できない文字はそのまま）
            return Microsoft.VisualBasic.Strings.StrConv( orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0 );
        }
        // --- ADD m.suzuki 2010/07/14 ----------<<<<<
        #region 自動見積部品番号変換マスタ取得処理
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// <summary>
        /// 自動見積部品コード取得
        /// </summary>
        /// <param name="AutoEstimatePartsCd">自動見積部品コード</param>
        /// <param name="TbsPartsCode">BLコード</param>
        /// <param name="CompoMainFlag">構成メインフラグ</param>
        /// <param name="PartsPosMainFlag">部位メインフラグ</param>
        /// <returns></returns>
        public int GetAutoEstimatePartsCd(out string AutoEstimatePartsCd, int TbsPartsCode, int CompoMainFlag, int PartsPosMainFlag)
        {

            AutoEstimatePartsCd = string.Empty;
            if (iAutoEstmPtNoChgDB == null) iAutoEstmPtNoChgDB = MediationAutoEstmPtNoChgDB.GetAutoEstmPtNoChgDB();
            AutoEstmPtNoChgWork paraAutoEstmPtNoChgWork = new AutoEstmPtNoChgWork();
            paraAutoEstmPtNoChgWork.TbsPartsCode = TbsPartsCode;
            paraAutoEstmPtNoChgWork.CompoMainFlag = CompoMainFlag;
            paraAutoEstmPtNoChgWork.PartsPosMainFlag = PartsPosMainFlag;

            object autoEstmPtNoChgDB;
            int status = iAutoEstmPtNoChgDB.Search(out autoEstmPtNoChgDB, paraAutoEstmPtNoChgWork);
            ArrayList lst = autoEstmPtNoChgDB as ArrayList;

            if (status == 0) // 正常の場合
            {
                lst.Add(autoEstmPtNoChgDB);
                AutoEstimatePartsCd = ((AutoEstmPtNoChgWork)lst[0]).AutoEstimatePartsCd;
            }
            return status;

        }
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<
        #endregion

        // --- ADD 2013/03/27 ---------->>>>>
        /// <summary>
        /// 画面のVIN文字列とメーカコードに応じて部品絞込条件を追加
        /// </summary>
        /// <param name="para">部品取得パラメータ</param>
        /// <remarks>
        /// <br>Note: 2013/03/27　FSI斎藤 和宏</br>
        /// <br>    : 10900269-00 SPK車台番号文字列対応</br>
        /// <br>    :   検索条件に格納されているVINコードとメーカ情報より</br>
        /// <br>    :   ハンドル位置情報・生産工場コードを追加</br>
        /// </remarks>
        private void AddPartsNarrowingInfoFromVinCode(ref GetPartsInfPara para)
        {
            // パラメータチェック
            if (para == null)
                return;

            para.VinCode = 0;   // VINコード絞込有無はこの値が0か非0かで行う。

            if (carInfoDataSet == null || carInfoDataSet.CarModelUIData.Count == 0)
                return;

            try
            {
                // VINコードを抽出条件とするかどうかチェック
                // 以下のどれかを満たす場合はVINコード絞込を行わない
                // ・国産/外車区分が「外車」ではない
                // ・画面から取得した車台番号文字列が空
                // ・車台番号(検索用)に値が格納されている(あり得ない)
                if (carInfoDataSet.CarModelUIData[0].DomesticForeignCode != 2 ||
                     string.IsNullOrEmpty(carInfoDataSet.CarModelUIData[0].FrameNo) ||
                     carInfoDataSet.CarModelUIData[0].SearchFrameNo != 0)
                {
                    return;
                }

                // VINコードの文字列取得
                string orgVinCode = carInfoDataSet.CarModelUIData[0].FrameNo.Trim();
                string productNostr = string.Empty;         // 製造番号(文字列)
                int productNonum = -1;                      // 製造番号(数値)
                int vinHandleInfoCd = -1;                   // VINコードから取得したハンドル位置情報
                string productionFactoryCd = string.Empty;  // 生産工場コード

                // 文字数/全角半角チェック
                System.Text.Encoding Sjis_enc = System.Text.Encoding.GetEncoding("Shift_JIS");
                if (orgVinCode.Length != 17 || Sjis_enc.GetByteCount(orgVinCode) != 17)
                    return;     // 文字数が17Byteでない。

                // 12Byte目～17Byte目が数値かチェックの上、製造番号として保持
                productNostr = orgVinCode.Substring(11, 6);
                if (!int.TryParse(productNostr, out productNonum))
                    return;

                // メーカコード毎のパラメータセット処理
                if (para.MakerCode == 80)
                {
                    // 「80(BENZ)」の場合 ハンドル位置情報を取得
                    if (int.TryParse(orgVinCode.Substring(9, 1), out vinHandleInfoCd))
                    {
                        // ハンドル情報取得を数値として取得できる場合に絞込条件追加
                        para.VinCode = productNonum;
                        para.HandleInfoCd = vinHandleInfoCd;
                        para.ProductionFactoryCd = string.Empty;

                        // VINコードと車両型式マスタのハンドル位置情報値は
                        // 齟齬があるので補正する。
                        // ・VINコード
                        //  左ハンドル→1
                        //  右ハンドル→2
                        // ・車両型式マスタ
                        //  左ハンドル→2
                        //  右ハンドル→1
                        if (vinHandleInfoCd == 1 || vinHandleInfoCd == 2)
                        {
                            // VINコードのハンドル位置を設定(VINコードとマスタの値が異なるため)
                            HandleInfoCdRet posVin = vinHandleInfoCd == 1 ? HandleInfoCdRet.PositionLeft : HandleInfoCdRet.PositionRight;
                            para.HandleInfoCd = (int)posVin;

                            // 型式検索で選択されているすべての行を比較する
                            int pos = carInfoDataSet.CarModelInfo.HandleInfoCdColumn.Ordinal;
                            int state = carInfoDataSet.CarModelInfo.SelectionStateColumn.Ordinal;
                            HandleInfoCdRet posModel = HandleInfoCdRet.PositionError;
                            foreach (DataRow row in carInfoDataSet.CarModelInfo.Rows)
                            {
                                // 選択されていない行はスキップする
                                if ((bool)row[state] != true)
                                    continue;

                                // ハンドル位置情報をチェックする
                                HandleInfoCdRet posKind = (HandleInfoCdRet)row[pos];
                                if (posKind != HandleInfoCdRet.PositionRight && posKind != HandleInfoCdRet.PositionLeft)
                                    continue;

                                // ハンドル位置を比較する
                                if (posModel == HandleInfoCdRet.PositionError)
                                {
                                    // ハンドル位置情報をセット
                                    posModel = posKind;
                                }
                                else if ((posModel == HandleInfoCdRet.PositionRight && posKind == HandleInfoCdRet.PositionLeft) ||
                                    (posModel == HandleInfoCdRet.PositionLeft && posKind == HandleInfoCdRet.PositionRight))
                                {
                                    // 選択した車両情報に右/左ハンドルが混在していた場合
                                    // 初期値としてハンドル情報絞込を行わない意味の-1をセット
                                    // リモート側で-1の場合はWHERE句に反映しないようになる
                                    para.HandleInfoCd = -1;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (para.MakerCode == 81)
                {
                    // 「81(VW)」の場合 11Byte目を生産工場コードとして絞込条件に追加
                    para.VinCode = productNonum;
                    para.HandleInfoCd = 0;
                    para.ProductionFactoryCd = orgVinCode.Substring(10, 1);
                }
                else
                {
                    // 「80(BENZ)」・「81(VW)」以外はVINコード絞込を行わない
                    // 「83(BMW)」を含めた上記以外の外車はこのルート
                    return;
                }
            }
            catch
            {
                // 例外発生時はVINコード絞込行わない
                para.VinCode = 0;
            }
            return;
        }
        // --- ADD 2013/03/27 ----------<<<<<
    }
}
