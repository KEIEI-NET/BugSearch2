using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
//using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller; // 2010/04/15 Add
using Broadleaf.Application.Common; // 2010/04/15 Add
using Broadleaf.Application.Resources;  // 2010/04/15 Add
using System.Runtime.Serialization.Formatters.Binary;  // 2010/04/27 Add
using System.IO;  // 2010/04/15 Add  // 2010/04/27 Add



namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先電子元帳データ取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先電子元帳のアクセスクラスです。</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.09.09</br>
    /// <br>Update Note: 2009/09/07 張莉莉</br>
    /// <br>             PM.NS-2-A 車輛管理</br>
    /// <br>             赤伝発行時の車輌情報登録内容に項目を追加</br>
    /// <br>Update Note: 2009/11/25 呉元嘯</br>
    /// <br>             PM.NS保守依頼③ 不具合対応</br>
    /// <br>Update Note: 2009/12/15 呉元嘯</br>
    /// <br>             Redmine#1919不具合対応</br>
    /// <br>Update Note: 2009/12/28 呉元嘯</br>
    /// <br>             PM.NS保守依頼④ 不具合対応</br>
    /// <br>Update Note: 2010/01/12 呉元嘯</br>
    /// <br>             PM.NS保守依頼④ 不具合対応</br>
    /// <br>Update Note: 2010/01/29 楊明俊</br>
    /// <br>             4次改良 不具合対応</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/15 30517 夏野 駿希</br>
    /// <br>             Mantis.15309　テキスト出力対応</br>
    /// <br>             Mantis.15323　不具合対応</br>
    /// <br>                           請求で出力時に、画面の前回残が、「前々々回残＋前々回残＋前回残」の合計になっていない</br>
    /// <br>UpdateNote : 2010/04/27 gaoyh</br>
    /// <br>             受注マスタ（車両）に自由検索型式固定番号配列の追加</br>    
    /// <br>UpdateNote : 2010/06/08 呉元嘯</br>
    /// <br>             障害・改良対応７月リリース分　売上履歴データから伝票再発行を可能へ変更</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/08 30517 夏野 駿希</br>
    /// <br>             Mantis.15724　合計表示タブの消費税算出不正の修正</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/21 22018 鈴木 正臣</br>
    /// <br>　　　　　　　成果物統合２</br>
    /// <br>　　　　　　　　①残高合計の抽出でタイムアウトエラー等発生した場合にＰＧ強制終了せずメッセージ表示するよう修正。</br>
    /// <br>　　　　　　　　②得意先請求金額マスタにレコードが無い場合、画面上の売上日(開始)以降を抽出するよう変更。</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/08/05 呉元嘯</br>
    /// <br>　　　　　　 障害・改良対応8月リリース分対応</br>
    /// <br></br>
    /// <br>Update Note : 2010/08/31 呉元嘯</br>
    /// <br>              Redmine#14006対応</br>
    /// <br>Update Note : 2010/09/01 caowj</br>
    /// <br>              Redmine#14073対応</br>
    /// <br>Update Note: 2010/09/16 楊明俊</br>
    /// <br>            ・障害ID:14483 PM1012PM.NS障害改良対応（８月分）</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/12/20 22018 鈴木 正臣</br>
    /// <br>             障害改良対応１２月</br>
    /// <br>             　・2010/04/15対応分を修正。</br>
    /// <br>                　 請求一覧表アクセスクラスを使用すると(請求初期値設定＝nullなので)得意先の集金日が28以降の場合、予期しない動作になる。</br>
    /// <br>                 　請求一覧表アクセスクラスを使用すると処理が冗長。(ループ内で何度もリモート処理が実行される)
    /// <br>　　　　　　　　　⇒得意先電子元帳リモートで「残高＝前々々回＋前々回＋前回」の対応をする。</br>
    /// <br></br>
    /// <br>UpdateNote : 2011/07/13 王飛３</br>
    /// <br>             連番795</br>
    /// <br>             標準価格で並び替えるとおかしい（ｶﾝﾏを含めた文字列として処理されているよう</br>
    /// <br>             ⇒画面コピー</br>
    /// <br>             ⇒列フィルタのサンプルの表示順も同じ</br>
    /// <br>Update Note : 2011/07/18 朱宝軍 回答区分の追加</br>
    /// <br>UpdateNote : 2011/07/28 王飛３</br>
    /// <br>             連番909</br>
    /// <br>             自社マスタにて年式を「和歴」表示に変えているのにも関わらず、電子元帳の画面表示が西暦表示されて見にくい</br>
    /// <br>UpdateNote : 2011/08/18 許雁波</br>
    /// <br>             10704766-00 連番729</br>
    /// <br>             明細複写処理を新規する。</br>
    /// <br>Update Note: 2011/09/21 田建委 </br>
    /// <br>             Redmine#25430対応</br>
    /// <br>             得意先電子元帳の検索不具合についての修正</br>
    /// <br>Update Note: 2011/11/23 陳建明</br>
    /// <br>             Redmine#8079対応</br>
    /// <br>             得意先電子元帳/年式の表示についての修正</br>
    /// <br>Update Note: 2011/11/23 李小路 </br>
    /// <br>             Redmine#7861対応</br>
    /// <br>             得意先電子元帳／粗利率の追加他</br>
    /// <br>Update Note: 2011/11/28 楊洋 </br>
    /// <br>             redmine#8172</br>
    /// <br>             得意先電子元帳/(BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑ)問合せ番号の追加</br>
    /// <br>Update Note: 2012/04/01 gezh</br>
    /// <br>管理番号   : 2012/05/24配信分</br>
    /// <br>             Redmine#29250 得意先電子元帳　得意先電子元帳　データ更新日時の追加についての対応</br>
    /// <br>Update Note: 2012/06/01 30744 湯上 千加子</br>
    /// <br>             得意先電子元帳　残高一覧表示の抽出拠点追加についての対応</br>
    /// <br>Update Note : 2012/06/19 lanl</br>
    /// <br>管理番号    : 10801804-00 2012/07/25配信分</br>
    /// <br>              Redmine#30529</br>
    /// <br>UpdateNote : 2012/06/26 脇田 靖之</br>
    /// <br>管理番号   : 10801804-00 障害対応 №880</br>
    /// <br>             年式を入力した伝票の見出し貼り付けを行うと、年式が貼りつかない件の対応</br>
    /// <br>             （「全体初期表示設定」の「元号表示区分（年式）」が”和暦”に設定されている場合に発生）</br>
    /// <br>Update Note : 2012/07/10 tianjw</br>
    /// <br>管理番号    : 10801804-00 2012/07/25配信分</br>
    /// <br>              Redmine#30529</br>
    /// <br>Update Note : 2012/11/15 yangmj</br>
    /// <br>管理番号    : 10801804-00 20130116配信分</br>
    /// <br>              Redmine#33269　請求先情報の印刷の対応</br>
    /// <br>UpdateNote : 2012/12/14 脇田 靖之</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             入金伝票入力にて値引きもしくは手数料を入力し、</br>
    /// <br>             その伝票を赤伝発行した場合、明細表示に黒しか表示されない件の修正</br>
	/// <br>Update Note : 2013/01/30 wangf </br>
	/// <br>            : 10801804-00、速度改善関連、Redmine#34513 サーバー負荷軽減の為、得意先電子元帳の改良の対応</br>
	/// <br>            : 残高集計のタイミングをずらす</br>
    /// <br>Update Note : 2013/04/12 zhujw </br>
    /// <br>            : 10800003-00、2013/05/15配信分、Redmine#35205　得意先電子元帳の対応</br>
    /// <br>            : 与信残高出力内容不正の修正。</br>
    /// <br>Update Note : 2013/05/06 zhujw </br>
    /// <br>            : 10900691-00、2013/05/15配信分、Redmine#34718　得意先電子元帳の対応</br>
    /// <br>            : 年のみ入力されていた場合は、年のみの印字するように修正。</br>
    /// <br>Update Note: 2013/05/15 huangt </br>
    /// <br>管理番号   : 10902175-00 6月18日配信分（障害以外）</br>
    /// <br>           : Redmine#35640　得意先電子元帳 テキスト出力 消費税が出力されないの修正</br>
    /// <br>UpdateNote : 2013/10/02 宮本 利明</br>
    /// <br>管理番号   : 10902175-00 仕掛一覧 №2147</br>
    /// <br>             粗利(明細)を金額－原価で算出するように修正</br>
    /// <br>UpdateNote : K2014/05/08 林超凡</br>
    /// <br>           : 得意先電子元帳のCSV出力項目に車種メーカーコードを追加する、東亜商会個別対応</br>
    /// <br>Update Note: K2014/05/28 林超凡 </br>
    /// <br>           : 得意先電子元帳  Redmine#42764 受入テスト障害対応。東亜商会個別対応</br>
    /// <br>Update Note: 2014/12/28 陳永康</br>
    /// <br>管理番号   : 11070263-00</br>
    /// <br>           : 変換後品番の追加対応</br>
    /// <br>Update Note: K2015/06/16 鮑晶</br>
    /// <br>管理番号   : 11101427-00</br>
    /// <br>           : メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
    /// <br>UpdateNote : 2015/02/05 王亜楠 </br>
    /// <br>           : テキスト出力件数制限なしモードの追加</br>
    /// <br>UpdateNote : 2015/05/11 呉軍 </br>
    /// <br>           : テキスト出力にて「抽出件数制限なし」の場合に変換後品番が出力されないの対応</br>
    /// <br>Update Note: K2015/04/27 陳亮 </br>
    /// <br>管理番号   : 11100842-00 モモセ部品㈱の個別開発依頼 </br>
    /// <br>           : 得意先電子元帳第二売価を追加する。モモセ部品㈱オプションが有効の場合のみ。</br>
    /// <br>Update Note: K2015/12/10 脇田 靖之 </br>
    /// <br>管理番号   : 11170188-00 メイゴ㈱得意先電子元帳 </br>
    /// <br>           : メイゴ㈱テキスト出力にて「抽出件数制限なし」の場合に「地区」と「分析コード」が出力されない障害対応</br>
    /// <br>Update Note: 2016/01/21 脇田 靖之</br>
    /// <br>管理番号   : 11270007-00</br>
    /// <br>           : 仕掛一覧№2808 貸出受注対応</br>
    /// <br>           : ①検索条件に「出荷状況」項目を追加</br>
    /// <br>           : ②明細表示に計上数、未計上数項目を追加</br>
    /// <br>Update Note: K2016/02/23 時シン</br>
    /// <br>管理番号   : 11200090-00 イケモ 得意先電子元帳</br>
    /// <br>             ㈱イケモト 抽出条件にて受注作成区分を追加する対応</br>
    /// <br>Update Note: 2020/03/11 時シン</br>
    /// <br>管理番号   : 11570208-00</br>
    /// <br>           : PMKOBETSU-2912 軽減税率対応</br>
    /// <br>           : 伝票タブ、明細タブに「消費税率」項目を追加</br>
    /// <br>Update Note: 2022/05/05 仰亮亮</br>
    /// <br>管理番号   : 11870080-00</br>
    /// <br>           : 納品書電子帳簿連携対応</br>
    /// <br></br>
    /// </remarks>
    public partial class CustPrtSlipSearchAcs
    {

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <br>Update Note : K2015/06/16 鮑晶</br>
        /// <br>管理番号    : 11101427-00</br>
        /// <br>            : メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        public CustPrtSlipSearchAcs()
        {
            // リモートインスタンス取得
            this._iCustPrtPprWorkDB = MediationCustPrtPprWorkDB.GetCustPrtPprWorkDB();

            // データセットを作成
            this._dataSet = new CustPtrSalesDetailDataSet();

            // アクセスクラスを作成
            this._customerAcs = new CustomerSearchAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
            // 得意先アクセスクラス
            _customerInfoAcs = new CustomerInfoAcs();

            // 得意先実績修正リモート
            _iCustRsltUpdDB = MediationCustRsltUpdDB.GetCustRsltUpdDB();

            // 請求締更新リモート
            _iCustDmdPrcDB = MediationCustDmdPrcDB.GetCustDmdPrcDB();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

            //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 BEGIN--------->>>>>
            #region 東亜商会オプション
            // 東亜商会個別オプションコードの追加
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus touaCustom;
            touaCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ToaCustom);
            if (touaCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Toua = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Toua = Convert.ToInt32(Option.OFF);
            }
            #endregion
            //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 END---------<<<<<

           // ---- ADD K2015/04/29 陳亮 テキスト出力項目に第二売価を追加する ---->>>>>
            // モモセ部品㈱の個別オプションコードの追加
            #region モモセ部品オプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus momoseCustom;
            momoseCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MomoseCustom);
            if (momoseCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Momose = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Momose = Convert.ToInt32(Option.OFF);
            }
            #endregion
            // ---- ADD K2015/04/29 陳亮 テキスト出力項目に第二売価を追加する ----<<<<<

            //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
            #region ●PCCオプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus pccCustom;
            pccCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (pccCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Pcc = (int)Option.ON;
            }
            else
            {
                this._opt_Pcc = (int)Option.OFF;
            }
            #endregion

            #region 登戸個別オプション
            // 登戸個別オプションコードの追加
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus nobutoCustom;
            nobutoCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_NobutoCustom);
            if (nobutoCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Nobuto = (int)Option.ON;
            }
            else
            {
                this._opt_Nobuto = (int)Option.OFF;
            }
            #endregion
            // テキスト出力用テーブル
            this._salesListTbl4Text = new CustPtrSalesDetailDataSet.SalesListDataTable();
            this._salesDetailTbl4Text = new CustPtrSalesDetailDataSet.SalesDetailDataTable();
            //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            #region メイゴ㈱オプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus meigoCustom;
            meigoCustom = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MeigoLedgerCustom);
            if (meigoCustom == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Meigo = Convert.ToInt32(Option.ON);
            }
            else
            {
                this._opt_Meigo = Convert.ToInt32(Option.OFF);
            }
            #endregion
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

        }

        #endregion // コンストラクタ

        // ADD 2012/06/01 ----------------------->>>>>
        #region 列挙体
        /// <summary>
        /// 抽出拠点種別
        /// </summary>
        public enum RemainSectionType : int
        {
            /// <summary>管理拠点</summary>
            Mng = 0,
            /// <summary>請求拠点</summary>
            Claim = 1
        }
        #endregion
        // ADD 2012/06/01 -----------------------<<<<<

        #region プライベート変数

        // リモートDB検索クラス インタフェースオブジェクト
        private ICustPrtPprWorkDB _iCustPrtPprWorkDB;

        // データセットクラス
        private CustPtrSalesDetailDataSet _dataSet;

        // 得意先取得用アクセスクラス
        private CustomerSearchAcs _customerAcs;

        // --- DEL 2020/12/21 警告対応 ---------->>>>>
        //// 得意先締め日
        //private int _customerCalcDate= 0;
        // --- DEL 2020/12/21 警告対応 ----------<<<<<

        // 得意先指定フラグ（指定されていない場合は残高情報を表示しない）
        private bool _customerPointed = true;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
        // 売上全体設定
        private SalesTtlSt _salesTtlSt;

        // 得意先アクセス
        private CustomerInfoAcs _customerInfoAcs;

        // 得意先実績修正リモート
        private ICustRsltUpdDB _iCustRsltUpdDB;

        // 請求締更新リモート
        private ICustDmdPrcDB _iCustDmdPrcDB;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
        // 抽出中断フラグ
        private bool _extractCancelFlag;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

        //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 BEGIN--------->>>>>
        /// <summary>東亜オプション情報</summary>
        private int _opt_Toua;
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
        //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 END---------<<<<<

       // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加 ---->>>>>
        /// <summary>モモセ部品</summary>
        private int _opt_Momose;
        /// <summary>キャラクターのドット</summary>
        private const char CHAR_DOT = '.';
        /// <summary>スペース</summary>
        private const char CHAR_SPACE = ' ';
        /// <summary>ストリングのドット</summary>
        private const string STR_DOT = ".";
        /// <summary>プラス</summary>
        private const string STR_PURASU = "+";
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        internal const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        private SalesProcMoneyAcs _salesProcMoneyAcs;
        private List<SalesProcMoney> _salesProcMoneyList;
        // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加 ----<<<<<

        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
        /// <summary>メイゴ㈱オプション情報<</summary>
        int _opt_Meigo;
        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

        #endregion // プライベート変数

        #region 0詰め桁定数

        /// <summary>得意先コード 桁数:初期値 9</summary>
        private const int CT_DEPTH_CUSTOMERCODE = 9;

        /// <summary>仕入先コード 桁数:初期値 6</summary>
        private const int CT_DEPTH_SUPPLIERCODE = 6;

        /// <summary>BLコード 桁数:初期値 5</summary>
        private const int CT_DEPTH_BLGOODSCODE = 5;

        /// <summary>BLグループコード 桁数:初期値 5</summary>
        private const int CT_DEPTH_BLGROUPCODE = 5;

        /// <summary>発注先コード 桁数:初期値 6</summary>
        private const int CT_DEPTH_UOESUPPLIERCODE = 6;

        /// <summary>メーカーコード 桁数:初期値 4</summary>
        private const int CT_DEPTH_GOODSMAKERCODE = 4;

        //---ADD START 2011/11/28 楊洋 ------------->>>>>
        /// <summary>問合せ番号 桁数:初期値 10</summary>
        private const int CT_DEPTH_INQUIRYNUMBER = 10;
        //---ADD END   2011/11/28 楊洋 -------------<<<<<

        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
        /// <summary>PCCオプション情報</summary>
        private int _opt_Pcc;

        /// <summary>登戸オプション情報</summary>
        private int _opt_Nobuto;

        /// <summary>分割の日数：初期値 11</summary>
        private const int CT_LOOPDAYS = 11;
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿連携対応　------->>>>>
        /// <summary> PDFファイル出力 0:出力しない 1:出力する </summary>
        public static int PDFPrinterStatus;
        public int PDFPrinterStatus_EXT
        {
            get { return PDFPrinterStatus; }
        }
        // --------ADD 2022/05/05 仰亮亮 納品書電子帳簿連携対応　-------<<<<<

        /// <summary>テキスト出力用売上データテーブル</summary>
        private CustPtrSalesDetailDataSet.SalesListDataTable _salesListTbl4Text;
        /// <summary>テキスト出力用売上明細データテーブル</summary>
        private CustPtrSalesDetailDataSet.SalesDetailDataTable _salesDetailTbl4Text;

        /// <summary>
        /// テキスト出力用売上データテーブル
        /// </summary>
        public CustPtrSalesDetailDataSet.SalesListDataTable SalesListTbl4Text
        {
            get { return _salesListTbl4Text; }
        }

        /// <summary>
        /// テキスト出力用売上明細データテーブル
        /// </summary>
        public CustPtrSalesDetailDataSet.SalesDetailDataTable SalesDetailTbl4Text
        {
            get { return _salesDetailTbl4Text; }
        }
        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

        #endregion

        #region プロパティ

        /// <summary>
        /// データセットオブジェクト 
        /// </summary>
        public CustPtrSalesDetailDataSet DataSet
        {
            get { return this._dataSet; }
            //set { this._dataSet = value; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/15 ADD
        /// <summary>
        /// 売上全体設定
        /// </summary>
        public SalesTtlSt SalesTtlSt
        {
            get { return _salesTtlSt; }
            set { _salesTtlSt = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/15 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
        /// <summary>
        /// 抽出中断フラグ
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
        #endregion // プロパティ

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        public delegate void UpdateSectionEventHandler( object sender, string sectionCode, string sectionName );
        public event UpdateSectionEventHandler UpdateSection;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
        /// <summary>
        /// テキスト出力用テーブルタイトルの設定
        /// </summary>
        /// <param name="mode">モード（0:伝票 1:明細）</param>
        /// <remarks>
        /// <br>Note       : テキスト出力用テーブルタイトルの設定</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// <br>UpdateNote : 2015/05/11 呉軍 </br>
        /// <br>           : テキスト出力にて「抽出件数制限なし」の場合に変換後品番が出力されないの対応</br>
        /// <br>UpdateNote : 2015/06/11 陳亮 </br>
        /// <br>           : テキスト出力にて「抽出件数制限なし」の場合に第二売価が出力されないの対応</br>
        /// <br>UpdateNote : 2016/01/21 脇田 靖之</br>
        /// <br>管理番号   : 11270007-00</br>
        /// <br>           : 仕掛一覧№2808 貸出受注対応</br>
        /// <br>           : ①検索条件に「出荷状況」項目を追加</br>
        /// <br>           : ②明細表示に計上数、未計上数項目を追加</br>
        /// <br>Update Note: 2020/03/11 時シン</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 軽減税率対応</br>
        /// <br>           : 伝票タブ、明細タブに「消費税率」項目を追加</br>
        /// </remarks>
        private void SetTableCaption(int mode)
        {
            if (mode == 0)
            {
                #region 伝票
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesDateColumn.ColumnName].Caption = "伝票日付";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesSlipNumColumn.ColumnName].Caption = "伝票番号";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesSlipCdNameColumn.ColumnName].Caption = "区分";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesEmployeeNmColumn.ColumnName].Caption = "担当者名";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesTotalTaxExcColumn.ColumnName].Caption = "金額";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ConsumeTaxColumn.ColumnName].Caption = "消費税";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.GrossProfitColumn.ColumnName].Caption = "粗利";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CategoryNoColumn.ColumnName].Caption = "類別型式";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ModelFullNameColumn.ColumnName].Caption = "車種";
                if (this._opt_Toua == Convert.ToInt32(Option.ON))
                {
                    this._salesListTbl4Text.Columns[this._salesListTbl4Text.MakerCodeColumn.ColumnName].Caption = "車種メーカーコード";
                }
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.FirstEntryDateColumn.ColumnName].Caption = "年式";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.FrameNoColumn.ColumnName].Caption = "車台No";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.FullModelColumn.ColumnName].Caption = "型式";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SlipNoteColumn.ColumnName].Caption = "備考１";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SlipNote2Column.ColumnName].Caption = "備考２";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SlipNote3Column.ColumnName].Caption = "備考３";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.FrontEmployeeNmColumn.ColumnName].Caption = "受注者";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SalesInputNameColumn.ColumnName].Caption = "発行者";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CustomerCodeColumn.ColumnName].Caption = "得意先コード";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CustomerSnmColumn.ColumnName].Caption = "得意先名";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.PartySaleSlipNumColumn.ColumnName].Caption = "指示書(仮伝)番号";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CarMngCodeColumn.ColumnName].Caption = "管理No";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AcceptAnOrderNoColumn.ColumnName].Caption = "計上元受注No";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ShipmSalesSlipNumColumn.ColumnName].Caption = "計上元貸出No";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.UoeRemark1Column.ColumnName].Caption = "UOEリマーク1";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.UoeRemark2Column.ColumnName].Caption = "UOEリマーク2";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SectionCdColumn.ColumnName].Caption = "拠点コード";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SectionGuideNmColumn.ColumnName].Caption = "拠点名";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ColorName1Column.ColumnName].Caption = "カラー名称";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.TrimNameColumn.ColumnName].Caption = "トリム名称";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.CustSlipNoColumn.ColumnName].Caption = "得意先伝票番号";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AddUpADateColumn.ColumnName].Caption = "計上日";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.EnterpriseGanreCodeColumn.ColumnName].Caption = "商品区分";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AccRecDivCdNameColumn.ColumnName].Caption = "売掛区分";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.DebitNoteDivColumn.ColumnName].Caption = "赤伝区分";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AddresseeCodeColumn.ColumnName].Caption = "納入先コード";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.AddresseeNameColumn.ColumnName].Caption = "納入先名";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.InputDayColumn.ColumnName].Caption = "入力日";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.HistoryDivNameColumn.ColumnName].Caption = "履歴";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.SlipPrintTimeColumn.ColumnName].Caption = "伝票発行時刻";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.UpdateDateTimeColumn.ColumnName].Caption = "更新日時";
                this._salesListTbl4Text.Columns[this._salesListTbl4Text.ConsTaxRateColumn.ColumnName].Caption = "消費税率"; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                #endregion
            }
            else
            {
                #region 明細
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesDateColumn.ColumnName].Caption = "伝票日付";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesSlipNumColumn.ColumnName].Caption = "伝票番号";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesRowNoColumn.ColumnName].Caption = "行No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesSlipCdNameColumn.ColumnName].Caption = "区分";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesSlipCdDtlNameColumn.ColumnName].Caption = "明細区分";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesEmployeeNmColumn.ColumnName].Caption = "担当者名";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsNameColumn.ColumnName].Caption = "品名";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsNoColumn.ColumnName].Caption = "品番";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.BLGoodsCodeColumn.ColumnName].Caption = "BLｺｰﾄﾞ";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.BLGroupCodeColumn.ColumnName].Caption = "BLｸﾞﾙｰﾌﾟ";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsMGroupColumn.ColumnName].Caption = "中分類コード";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsMGroupNameColumn.ColumnName].Caption = "中分類名";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsLGroupColumn.ColumnName].Caption = "大分類コード";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsLGroupNameColumn.ColumnName].Caption = "大分類名";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ShipmentCntColumn.ColumnName].Caption = "数量";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ListPriceTaxExcFlColumn.ColumnName].Caption = "標準価格";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesUnPrcTaxExcFlColumn.ColumnName].Caption = "単価";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesUnitCostColumn.ColumnName].Caption = "原価";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesMoneyTaxExcColumn.ColumnName].Caption = "金額";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesPriceConsTaxColumn.ColumnName].Caption = "消費税";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GrossProfitDetailColumn.ColumnName].Caption = "粗利";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GrossProfitMarginColumn.ColumnName].Caption = "粗利率";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CategoryNoColumn.ColumnName].Caption = "類別型式";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ModelFullNameColumn.ColumnName].Caption = "車種";
                if (this._opt_Toua == Convert.ToInt32(Option.ON))
                {
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.MakerCodeColumn.ColumnName].Caption = "車種メーカーコード";
                }
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.FirstEntryDateColumn.ColumnName].Caption = "年式";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.FrameNoColumn.ColumnName].Caption = "車台No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.FullModelColumn.ColumnName].Caption = "型式";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SlipNoteColumn.ColumnName].Caption = "備考１";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SlipNote2Column.ColumnName].Caption = "備考２";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SlipNote3Column.ColumnName].Caption = "備考３";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.FrontEmployeeNmColumn.ColumnName].Caption = "受注者";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesInputNameColumn.ColumnName].Caption = "発行者";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CustomerCodeColumn.ColumnName].Caption = "得意先コード";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CustomerSnmColumn.ColumnName].Caption = "得意先";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SupplierCdColumn.ColumnName].Caption = "仕入先コード";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SupplierSnmColumn.ColumnName].Caption = "仕入先";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.PartySaleSlipNumColumn.ColumnName].Caption = "指示書(仮伝)番号";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CarMngCodeColumn.ColumnName].Caption = "管理No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AcceptAnOrderNoColumn.ColumnName].Caption = "計上元受注No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ShipSalesSlipNumColumn.ColumnName].Caption = "計上元貸出No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SrcSalesSlipNumColumn.ColumnName].Caption = "元黒No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.EnterpriseGanreCodeColumn.ColumnName].Caption = "商品区分";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsKindCodeNameColumn.ColumnName].Caption = "商品属性";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesOrderDivCdNameColumn.ColumnName].Caption = "在庫取寄区分";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.WarehouseNameColumn.ColumnName].Caption = "倉庫";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.WarehouseShelfNoColumn.ColumnName].Caption = "棚番";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.StockPartySaleSlipNumColumn.ColumnName].Caption = "同時仕入No";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.UOESupplierCdColumn.ColumnName].Caption = "発注先コード";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.UOESupplierSnmColumn.ColumnName].Caption = "発注先";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.UOERemark1Column.ColumnName].Caption = "UOEリマーク1";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.UOERemark2Column.ColumnName].Caption = "UOEリマーク2";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GuideNameColumn.ColumnName].Caption = "販売区分";
                if (this._opt_Nobuto == (int)Option.ON)
                {
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GuideNameColumn.ColumnName].Caption = "特販区分";
                }
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SectionCdColumn.ColumnName].Caption = "拠点コード";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SectionGuideNameColumn.ColumnName].Caption = "拠点名";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.DtlNoteColumn.ColumnName].Caption = "明細備考";

                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ColorName1Column.ColumnName].Caption = "カラー名";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.TrimNameColumn.ColumnName].Caption = "トリム名";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.StdUnPrcLPriceColumn.ColumnName].Caption = "算出価格";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.StdUnPrcSalUnPrcColumn.ColumnName].Caption = "算出売価";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.StdUnPrcUnCstColumn.ColumnName].Caption = "算出原価";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.GoodsMakerCdColumn.ColumnName].Caption = "メーカーコード";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.MakerNameColumn.ColumnName].Caption = "メーカー名";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.CustSlipNoColumn.ColumnName].Caption = "得意先伝票番号";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AddUpADateColumn.ColumnName].Caption = "計上日";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AccRecDivCdNameColumn.ColumnName].Caption = "売掛区分";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.DebitNoteDivColumn.ColumnName].Caption = "赤伝区分";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AddresseeCodeColumn.ColumnName].Caption = "納入先コード";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AddresseeNameColumn.ColumnName].Caption = "納入先名";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.InputDayColumn.ColumnName].Caption = "入力日";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.HistoryDivNameColumn.ColumnName].Caption = "履歴";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SlipPrintTimeColumn.ColumnName].Caption = "伝票発行時刻";
                if (this._opt_Pcc == (int)Option.ON)
                {
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.AutoAnswerDivSCMColumn.ColumnName].Caption = "自動回答";
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.InquiryNumberColumn.ColumnName].Caption = "問合せ番号";
                }
                this._salesDetailTbl4Text.Columns[this._salesListTbl4Text.UpdateDateTimeColumn.ColumnName].Caption = "更新日時";

                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ChangeGoodsNoColumn.ColumnName].Caption = "変換後品番"; // ADD 呉軍 2015/05/11 テキスト出力にて「抽出件数制限なし」の場合に変換後品番が出力されないの対応

                // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesRecognitionCntColumn.ColumnName].Caption = "計上数";
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SalesNotRecognitionCntColumn.ColumnName].Caption = "未計上数";
                // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

                // ---- ADD K2015/06/09 陳亮 テキスト出力項目に第二売価追加を追加する---->>>>>
                // テキスト出力にて「抽出件数制限なし」の場合に第二売価が出力されないの対応
                if (this._opt_Momose == Convert.ToInt32(Option.ON))
                {
                    this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.SecondSalePriceColumn.ColumnName].Caption = "第二売価";
                }
                // ---- ADD K2015/06/09 陳亮 テキスト出力項目に第二売価追加を追加する---->>>>>
                this._salesDetailTbl4Text.Columns[this._salesDetailTbl4Text.ConsTaxRateColumn.ColumnName].Caption = "消費税率";　// ADD 時シン 2020/03/11 PMKOBETSU-2912
                #endregion
            }
        }

        /// <summary>
        /// 売上日が指定されない場合、DBから開始・終了売上日を検索する
        /// </summary>
        /// <param name="custPrtPpr">検索条件</param>
        /// <param name="logicalDelDiv">論理削除区分</param>
        /// <param name="salesDateSt">開始売上日</param>
        /// <param name="salesDateEd">終了売上日</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 売上日が指定されない場合、DBから開始・終了売上日を検索する。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// </remarks>
        public int GetSalesDate4TextFile(CustPrtPpr custPrtPpr, int logicalDelDiv, out DateTime salesDateSt, out DateTime salesDateEd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            salesDateSt = DateTime.MinValue;
            salesDateEd = DateTime.MinValue;
            CustPrtPprWork custPrtPprWork = null;

            try
            {
                // パラメータクラスを作成
                custPrtPprWork = new CustPrtPprWork();
                CustPrtPpr2CustPrtPprWork(ref custPrtPpr, ref custPrtPprWork);

                if (_extractCancelFlag == true) return 0;

                if (logicalDelDiv == 0)
                {
                    // 削除分を含まない場合はGetData0を指定(削除フラグ=0のデータを返す)
                    status = this._iCustPrtPprWorkDB.GetSalesDate(out salesDateSt, out salesDateEd, (object)custPrtPprWork, ConstantManagement.LogicalMode.GetData0);
                }
                else
                {
                    // 削除済みの場合はGetData1を指定(削除フラグ=1のデータを返す)
                    status = this._iCustPrtPprWorkDB.GetSalesDate(out salesDateSt, out salesDateEd, (object)custPrtPprWork, ConstantManagement.LogicalMode.GetData1);
                }

                if (_extractCancelFlag == true) return 0;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                custPrtPprWork = null;
            }

            return status;
        }

        /// <summary>
        /// テキスト出力用データの検索
        /// </summary>
        /// <param name="custPrtPpr">検索条件</param>
        /// <param name="logicalDelDiv">論理削除区分</param>
        /// <param name="mode">検索モード（0:伝票 1:明細）</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : テキスト出力用データの検索。</br>
        /// <br>Programmer : 王亜楠</br>
        /// <br>Date       : 2015/02/05</br>
        /// <br>UpdateNote : K2015/05/11 呉軍 </br>
        /// <br>           : テキスト出力にて「抽出件数制限なし」の場合に変換後品番が出力されないの対応</br>
        /// <br>UpdateNote : K2015/06/09 陳亮 </br>
        /// <br>           : テキスト出力にて「抽出件数制限なし」の場合に第二売価が出力されないの対応</br>
        /// <br>UpdateNote : K2015/12/10 脇田 靖之 </br>
        /// <br>           : メイゴ㈱テキスト出力にて「抽出件数制限なし」の場合に「地区」と「分析コード」が出力されない障害対応</br>
        /// <br>UpdateNote : 2016/01/21 脇田 靖之</br>
        /// <br>管理番号   : 11270007-00</br>
        /// <br>           : 仕掛一覧№2808 貸出受注対応</br>
        /// <br>           : ①検索条件に「出荷状況」項目を追加</br>
        /// <br>           : ②明細表示に計上数、未計上数項目を追加</br>
        /// <br>Update Note: 2020/03/11 時シン</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 軽減税率対応</br>
        /// <br>           : 伝票タブ、明細タブに「消費税率」項目を追加</br>
        /// </remarks>
        public int SearchAllData4TextFile(CustPrtPpr custPrtPpr, int logicalDelDiv, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList resultList = new ArrayList();
            try
            {
                // パラメータクラスを作成
                CustPrtPprWork custPrtPprWork = new CustPrtPprWork();
                CustPrtPpr2CustPrtPprWork(ref custPrtPpr, ref custPrtPprWork);
                custPrtPprWork.SearchCountCtrl = 1; // 抽出件数制限なしの場合

                CustPrtPprBlDspRsltWork custPrtPprBlDspRsltWork = null;
                CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork = null;
                object custPrtPprBlDspRsltWorkObj = null;
                object custPrtPprSalTblRsltWorkObj = null;

                try
                {
                    //---------------------------------
                    // 返り値で使用するクラスを作成
                    //---------------------------------

                    // 残高照会に表示するので１件のみ
                    custPrtPprBlDspRsltWork = new CustPrtPprBlDspRsltWork();
                    custPrtPprBlDspRsltWorkObj = (object)custPrtPprBlDspRsltWork;

                    // 明細なのでrecordCount件数配列で帰ってくる
                    custPrtPprSalTblRsltWork = new CustPrtPprSalTblRsltWork();
                    custPrtPprSalTblRsltWorkObj = (object)custPrtPprSalTblRsltWork;
                    long subCounter = 0;

                    if (_extractCancelFlag == true) return 0;

                    if (logicalDelDiv == 0)
                    {
                        // 削除分を含まない場合はGetData0を指定(削除フラグ=0のデータを返す)
                        status = this._iCustPrtPprWorkDB.SearchRef(ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out subCounter, 0, ConstantManagement.LogicalMode.GetData0);
                    }
                    else
                    {
                        // 削除済みの場合はGetData1を指定(削除フラグ=1のデータを返す)
                        status = this._iCustPrtPprWorkDB.SearchRef(ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out subCounter, 0, ConstantManagement.LogicalMode.GetData1);
                    }

                    if (_extractCancelFlag == true) return 0;

                    resultList.AddRange(custPrtPprSalTblRsltWorkObj as ArrayList);
                }
                finally
                {
                    // メモリの解放
                    custPrtPprBlDspRsltWork = null;
                    custPrtPprSalTblRsltWork = null;
                    custPrtPprBlDspRsltWorkObj = null;
                    custPrtPprSalTblRsltWorkObj = null;
                }

                if (_extractCancelFlag == true) return 0;

                if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                {
                    DataRow row;

                    // テキスト出力用テーブルタイトルの設定
                    SetTableCaption(mode);

                    // 伝票単位は、「伝票番号」及び「受注ステータス」が同一のものをひとつのくくりとして判定する
                    string exSlipNum = string.Empty;    // ひとつ前の伝票番号
                    string exSlipNum2 = string.Empty;    // ひとつ前の伝票番号
                    int exAcptAnOdrStatus = 0;          // ひとつ前の受注ステータス

                    long salAmntConsTaxInclu = 0; // 伝票別内税金額集計値

                    int rowNo = 1;
                    int rowDetailNo = 0;

                    // 一件以上の戻りがあった場合のみ
                    if (resultList.Count > 0)
                    {
                        int lastIndex = 0;

                        int maxCount = resultList.Count;

                        int beAcptAnOdrStatusSrc = 0;
                        string beHisDtlSlipNum = string.Empty;

                        AllDefSetAcs alldefsetacs = new AllDefSetAcs();
                        ArrayList outList = new ArrayList();
                        int yeardiv = 0;

                        int stat = alldefsetacs.Search(out outList, LoginInfoAcquisition.EnterpriseCode);

                        if (stat == 0)
                        {
                            foreach (AllDefSet alldefset in outList)
                            {
                                string sectionCodeE = alldefset.SectionCode.Trim();

                                if (sectionCodeE.Equals(LoginInfoAcquisition.Employee.BelongSectionCode.Trim()))
                                {
                                    yeardiv = alldefset.EraNameDispCd1;
                                }
                                else if (sectionCodeE.Equals("00"))
                                {
                                    yeardiv = alldefset.EraNameDispCd1;
                                }
                            }
                        }

                        for (int index = 0; index < maxCount; index++)
                        {
                            lastIndex = index;

                            CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)(resultList[index]);

                            // 伝票番号フォーマット対応
                            data.SalesSlipNum = GetSlipNum(data);
                            // データセットに返り値をセットする
                            try
                            {
                                #region 明細データテーブル

                                row = _salesDetailTbl4Text.NewRow();

                                if (data.DataDiv == 0) // 売上データの場合
                                {
                                    #region 明細・売上データ
                                    // 返品・値引制御のための数量・金額の符号(1or-1)
                                    // （返品の値引きは-1*-1で1）
                                    // ※返品・値引きはデータ上数量マイナスなので、detailSignをかけてプラスにする
                                    // 　単純にAbsをとるわけではないので注意。
                                    int detailSign = 1;

                                    // 返品判定
                                    if (data.SalesSlipCd == 1) detailSign *= -1;

                                    // 商品値引判定(行値引は除外)
                                    if (data.SalesSlipCdDtl == 2 && !string.IsNullOrEmpty(data.GoodsNo)) detailSign *= -1;
                                    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = false;
                                    row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                    row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowNo;
                                    row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                    row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                    row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = data.SalesRowNo;
                                    row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                    row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                    row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                    row[this._dataSet.SalesDetail.RetuppercntColumn.ColumnName] = data.Retuppercnt;
                                    row[this._dataSet.SalesDetail.RetuppercntDivColumn.ColumnName] = data.RetuppercntDiv;

                                    if (data.HistoryDiv == 0)
                                    {
                                        // 履歴以外
                                        row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.AcptAnOdrRemainCnt;
                                    }
                                    else
                                    {
                                        // 履歴
                                        // （内部的には出荷数と同数を入れる事で赤伝発行可能にする＋出荷数までは赤伝可能にする）
                                        row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.ShipmentCnt;
                                    }
                                    // 伝票区分名判定
                                    if (data.SalesSlipCd == 0)
                                    {
                                        if (data.AcptAnOdrStatus == 20)
                                        {
                                            row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "受注";
                                        }
                                        else if (data.AcptAnOdrStatus == 30)
                                        {
                                            row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "売上";
                                        }
                                        else if (data.AcptAnOdrStatus == 40)
                                        {
                                            row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "貸出";
                                        }
                                        else
                                        {
                                        }
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "返品";
                                    }
                                    row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                    row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                    row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                    if (data.BLGoodsCode == 0)
                                    {
                                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                    }
                                    row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                    row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = detailSign * data.ShipmentCnt;
                                    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl;
                                    row[_dataSet.SalesDetail.CostRateColumn.ColumnName] = data.CostRate;     //原価率
                                    row[_dataSet.SalesDetail.SalesRateColumn.ColumnName] = data.SalesRate;   //売価率
                                    row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                    row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = data.SalesUnPrcTaxExcFl;
                                    row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = data.SalesUnitCost;
                                    row[_dataSet.SalesDetail.BfSalesUnitPriceColumn.ColumnName] = data.BfSalesUnitPrice;//変更前単価
                                    row[_dataSet.SalesDetail.BfUnitCostColumn.ColumnName] = data.BfUnitCost;//変更前原価
                                    row[_dataSet.SalesDetail.BfListPriceColumn.ColumnName] = data.BfListPrice;//変更前定価
                                    // 0:通常(PCC連携なし)、1:手動回答、2:自動回答
                                    if (data.AutoAnswerDivSCM == 0)
                                    {
                                        row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "通常";
                                    }
                                    else if (data.AutoAnswerDivSCM == 1)
                                    {
                                        row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "手動回答";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "自動回答";
                                    }
                                    if (data.InquiryNumber == 0)
                                    {
                                        row[_dataSet.SalesDetail.InquiryNumberColumn.ColumnName] = string.Empty; //問合せ番号
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.InquiryNumberColumn.ColumnName] = data.InquiryNumber.ToString().PadLeft(CT_DEPTH_INQUIRYNUMBER, '0'); //問合せ番号
                                    }
                                    row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = data.ConsTaxLayMethod;
                                    # region [消費税関連]
                                    bool printTax = true;
                                    Int64 salesTotalTaxInc;
                                    Int64 salesTotalTaxExc = data.SalesMoneyTaxExc;
                                    Int64 salesPriceConsTax;

                                    // 印刷する消費税額の取得
                                    if (data.ConsTaxLayMethod == 0) // 伝票単位
                                    {
                                        if (data.SalesRowNo == 1)  // 伝票毎の明細先頭行に消費税が印字される
                                        {
                                            salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                        }
                                        else
                                        {
                                            salesPriceConsTax = 0;
                                            printTax = false;
                                        }
                                    }
                                    else if (data.ConsTaxLayMethod == 1) // 明細単位
                                    {
                                        salesPriceConsTax = data.SalesPriceConsTax;
                                    }
                                    else
                                    {
                                        salesPriceConsTax = 0;
                                    }

                                    // 税込金額の取得
                                    salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                                    if (printTax)
                                    {
                                        // 消費税印字有無判定と金額制御
                                        int totalAmountDispWayCd = data.TotalAmountDispWayCd;
                                        int taxationDivCd = data.TaxationDivCd;

                                        // 消費税印字有無判定
                                        printTax = ReflectMoneyForTaxPrint(ref salesTotalTaxExc, ref salesPriceConsTax, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod, taxationDivCd);
                                        if (printTax)
                                        {
                                            if (salesPriceConsTax != 0)
                                            {
                                                row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = detailSign * salesPriceConsTax;
                                                row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = data.ConsTaxRate; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                            }
                                            else
                                            {
                                                // 印字しない
                                                row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                                row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                            }
                                        }
                                        else
                                        {
                                            // 印字しない
                                            row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                            row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                        }
                                    }
                                    else
                                    {
                                        // 印字しない
                                        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                        row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                    }
                                    // 税抜金額セット
                                    row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = detailSign * salesTotalTaxExc;
                                    // 税込金額セット
                                    row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = detailSign * salesTotalTaxInc;
                                    # endregion
                                    row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = detailSign * data.TotalCost;
                                    // 類別型式
                                    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = GetModelDesignationNoAndCategoryNo(data);
                                    // 型式指定番号(数値)
                                    row[_dataSet.SalesDetail.ModelDesignationNoOrgColumn.ColumnName] = data.ModelDesignationNo;
                                    // 類別番号(数値)
                                    row[_dataSet.SalesDetail.CategoryNoOrgColumn.ColumnName] = data.CategoryNo;
                                    row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                    // 車種名カナ
                                    row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = data.ModelHalfName;
                                    // 年式[NULLのときは空白]
                                    if (data.FirstEntryDate == 0)
                                    {
                                        row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        string firstEntryDate = "";

                                        if (data.FirstEntryDate.ToString().Length < 6)
                                        {
                                            firstEntryDate = "0000" + "/" + data.FirstEntryDate.ToString("D2");
                                        }
                                        else
                                        {
                                            firstEntryDate = data.FirstEntryDate.ToString().Substring(0, 4) + "/" + data.FirstEntryDate.ToString().Substring(4, 2);
                                        }
                                        firstEntryDate = firstEntryDate.Replace(@"/00", "");

                                        if (yeardiv == 1)
                                        {
                                            string date, stTarget;
                                            int StartTotalUnitYm;
                                            if (data.FirstEntryDate.ToString().Substring(4, 2) == "00")
                                            {
                                                date = data.FirstEntryDate.ToString().Substring(0, 4) + "0101";
                                                StartTotalUnitYm = Convert.ToInt32(date);
                                                stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm);
                                            }
                                            else
                                            {
                                                date = data.FirstEntryDate.ToString() + "01";
                                                StartTotalUnitYm = Convert.ToInt32(date);
                                                stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                                            }

                                            row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = stTarget;
                                        }
                                        else
                                        {
                                            row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = firstEntryDate;
                                        }
                                    }
                                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = data.FrameNo;

                                    row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = data.FullModel;
                                    row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                    row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                    row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                    row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                    row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                    row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                    row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;
                                    row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                    row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                    row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                    // 計上元受注No[NULLのときは空白]
                                    if (data.AcptAnOdrStatusSrc == 20)
                                    {
                                        if (!string.IsNullOrEmpty(data.HisDtlSlipNum.ToString()))
                                        {
                                            row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.HisDtlSlipNum;
                                        }
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                    }

                                    if (data.AcptAnOdrStatusSrc == 40)
                                    {
                                        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.HisDtlSlipNum;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = string.Empty;
                                    }

                                    // 元黒No[NULLのときは空白]
                                    if (data.SrcSalesSlipNum == "0")
                                    {
                                        row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = string.Empty;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = data.SrcSalesSlipNum;
                                    }
                                    row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = data.SalesOrderDivCd;
                                    if (data.SalesOrderDivCd == 0)
                                    {
                                        row[_dataSet.SalesDetail.SalesOrderDivCdNameColumn.ColumnName] = "取寄";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.SalesOrderDivCdNameColumn.ColumnName] = "在庫";
                                    }
                                    row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = data.WarehouseCode;
                                    row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = data.WarehouseName;
                                    // 同時仕入No[NULLのときは空白]
                                    if (data.SupplierSlipNo == 0)
                                    {
                                        row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                    }
                                    row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = data.StockPartySaleSlipNum;
                                    // 発注先コード[NULLのときは空白]
                                    if (data.UOESupplierCd == 0)
                                    {
                                        row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = string.Empty;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = data.UOESupplierCd.ToString().PadLeft(CT_DEPTH_UOESUPPLIERCODE, '0');
                                    }
                                    row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = data.UOESupplierSnm;
                                    row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = data.UoeRemark1;
                                    row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = data.UoeRemark2;
                                    row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                    row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                    row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                    row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = data.DtlNote;
                                    row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = data.ColorName1;
                                    row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = data.TrimName;
                                    row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = data.BfListPrice; // 変更前定価
                                    row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = data.BfSalesUnitPrice;// 変更前売価
                                    row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = data.BfUnitCost;// 変更前原価
                                    // メーカーコード
                                    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd;
                                    row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = data.MakerName;
                                    row[_dataSet.SalesDetail.CostColumn.ColumnName] = data.Cost;
                                    // 得意先伝票番号[NULLのときは空白]
                                    if (data.CustSlipNo == 0)
                                    {
                                        row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                    }
                                    if (data.AddUpADate != DateTime.MinValue)
                                    {
                                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                    }
                                    row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                    if (data.AccRecDivCd == 1)
                                    {
                                        row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "売掛";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "現金";
                                    }
                                    if (data.DebitNoteDiv == 0)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "黒伝";
                                    }
                                    else if (data.DebitNoteDiv == 1)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤伝";
                                    }
                                    else if (data.DebitNoteDiv == 2)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "元黒";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                    }
                                    if (((long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] < 0 ||
                                         (double)row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] < 0)
                                        && data.SalesSlipCdDtl != 2)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤伝";
                                    }
                                    // 粗利(明細)
                                    row[_dataSet.SalesDetail.GrossProfitDetailColumn.ColumnName] = detailSign * this.GetGrossProfitDetail(data);

                                    //粗利率
                                    row[_dataSet.SalesDetail.GrossProfitMarginColumn.ColumnName] = detailSign * this.GetGrossProfitMargin(data);  //#7861 2011/11/23 ADD

                                    // 納入先コード
                                    row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                                    // 納入先名1+2
                                    row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = data.AddresseeName + data.AddresseeName2;
                                    // 納入先名1のみ
                                    row[_dataSet.SalesDetail.AddresseeName1Column.ColumnName] = data.AddresseeName;
                                    // 納入先名2のみ
                                    row[_dataSet.SalesDetail.AddresseeName2Column.ColumnName] = data.AddresseeName2;
                                    // 入力日
                                    if (data.InputDay != DateTime.MinValue)
                                    {
                                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                                    }
                                    // 明細区分
                                    row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = data.SalesSlipCdDtl;
                                    switch (data.SalesSlipCdDtl)
                                    {
                                        default:
                                        case 0:
                                        case 1:
                                            {
                                                row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "通常";
                                            }
                                            break;
                                        case 2:
                                            {
                                                if (string.IsNullOrEmpty(data.GoodsNo))
                                                {
                                                    row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "行値引";
                                                }
                                                else
                                                {
                                                    row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "商品値引";
                                                }
                                            }
                                            break;
                                    }

                                    // 商品大分類
                                    row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = data.GoodsLGroup;
                                    row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = data.GoodsLGroupName;
                                    // 商品中分類
                                    row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = data.GoodsMGroup;
                                    row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = data.GoodsMGroupName;
                                    // 商品属性
                                    row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = data.GoodsKindCode;
                                    switch (data.GoodsKindCode)
                                    {
                                        case 0:
                                            {
                                                row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = "純正";
                                            }
                                            break;
                                        case 1:
                                        default:
                                            {
                                                row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = "その他";
                                            }
                                            break;
                                    }
                                    // 棚番
                                    row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = data.WarehouseShelfNo;

                                    // 商品区分
                                    row[_dataSet.SalesDetail.EnterpriseGanreCodeColumn.ColumnName] = data.EnterpriseGanreCode;
                                    row[_dataSet.SalesDetail.CarMngNoColumn.ColumnName] = data.CarMngNo; // 車両管理SEQ
                                    row[_dataSet.SalesDetail.MakerCodeColumn.ColumnName] = data.MakerCode; // 車種メーカーコード
                                    row[_dataSet.SalesDetail.ModelCodeColumn.ColumnName] = data.ModelCode; // 車種コード
                                    row[_dataSet.SalesDetail.ModelSubCodeColumn.ColumnName] = data.ModelSubCode; // 車種サブコード
                                    row[_dataSet.SalesDetail.EngineModelNmColumn.ColumnName] = data.EngineModelNm; // エンジン型式名称
                                    row[_dataSet.SalesDetail.ColorCodeColumn.ColumnName] = data.ColorCode; // カラーコード
                                    row[_dataSet.SalesDetail.TrimCodeColumn.ColumnName] = data.TrimCode; // トリムコード
                                    row[_dataSet.SalesDetail.DeliveredGoodsDivColumn.ColumnName] = data.DeliveredGoodsDiv; // 納品区分

                                    int[] wkFullModelFixedNoAry = new int[data.FullModelFixedNoAry.Length];
                                    for (int i = 0; i < data.FullModelFixedNoAry.Length; i++)
                                    {
                                        wkFullModelFixedNoAry[i] = data.FullModelFixedNoAry[i];
                                    }
                                    row[_dataSet.SalesDetail.FullModelFixedNoAryColumn.ColumnName] = wkFullModelFixedNoAry; // フル型式固定番号配列

                                    string[] wkFreeSrchMdlFxdNoAry = new string[0];
                                    if (null != data.FreeSrchMdlFxdNoAry && 0 < data.FreeSrchMdlFxdNoAry.Length)
                                    {
                                        BinaryFormatter formatter = new BinaryFormatter();
                                        MemoryStream ms = new MemoryStream(data.FreeSrchMdlFxdNoAry);
                                        wkFreeSrchMdlFxdNoAry = (string[])formatter.Deserialize(ms);
                                        ms.Close();
                                    }
                                    row[_dataSet.SalesDetail.FreeSrchMdlFxdNoAryColumn.ColumnName] = wkFreeSrchMdlFxdNoAry;

                                    byte[] wkCategoryObjAry = new byte[data.CategoryObjAry.Length];
                                    for (int i = 0; i < data.CategoryObjAry.Length; i++)
                                    {
                                        wkCategoryObjAry[i] = data.CategoryObjAry[i];
                                    }
                                    row[_dataSet.SalesDetail.CategoryObjAryColumn.ColumnName] = wkCategoryObjAry; // 装備オブジェクト配列
                                    row[_dataSet.SalesDetail.SalesInputCodeColumn.ColumnName] = data.SalesInputCode; // 発行者
                                    row[_dataSet.SalesDetail.FrontEmployeeCdColumn.ColumnName] = data.FrontEmployeeCd; // 受注者
                                    row[_dataSet.SalesDetail.HistoryDivNameColumn.ColumnName] = this.GetHistoryDivName(data.HistoryDiv);
                                    row[_dataSet.SalesDetail.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText(data.UpdateDateTime); // 伝票発行時刻
                                    if (data.UpdateDateTimeDetail != 0)
                                    {
                                        DateTime dt = new DateTime(data.UpdateDateTimeDetail);
                                        row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // 更新日時
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = string.Empty;
                                    }
                                    row[_dataSet.SalesDetail.MileageColumn.ColumnName] = data.Mileage;
                                    row[_dataSet.SalesDetail.CarNoteColumn.ColumnName] = data.CarNote;

                                    row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; // 変換後品番　// ADD 呉軍 2015/05/11 テキスト出力にて「抽出件数制限なし」の場合に変換後品番が出力されないの対応

                                    // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
                                    row[_dataSet.SalesDetail.SalesNotRecognitionCntColumn.ColumnName] = DBNull.Value;   // 未計上数
                                    row[_dataSet.SalesDetail.SalesRecognitionCntColumn.ColumnName] = DBNull.Value;      // 計上数

                                    // 受注ステータスが"貸出"または"受注" 且つ 売上伝票区分(明細)が"売上"の場合
                                    if ((data.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment ||
                                         data.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) &&
                                         data.SalesSlipCd == 0)
                                    {
                                        row[_dataSet.SalesDetail.SalesNotRecognitionCntColumn.ColumnName] = data.AcptAnOdrRemainCnt;                    // 未計上数
                                        row[_dataSet.SalesDetail.SalesRecognitionCntColumn.ColumnName] = (data.ShipmentCnt - data.AcptAnOdrRemainCnt);  // 計上数
                                    }
                                    // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

                                    // ---- ADD K2015/06/09 陳亮 テキスト出力項目に第二売価追加を追加する---->>>>>
                                    // テキスト出力にて「抽出件数制限なし」の場合に第二売価が出力されないの対応
                                    if (this._opt_Momose == Convert.ToInt32(Option.ON))
                                    {
                                        row[_dataSet.SalesDetail.SecondSalePriceColumn.ColumnName] = this.GetSecondPrice(data);
                                    }
                                    // ---- ADD K2015/06/09 陳亮 テキスト出力項目に第二売価追加を追加する----<<<<<

                                    // ---------- ADD K2015/12/10 Y.Wakita ---------->>>>>
                                    // テキスト出力にて「抽出件数制限なし」の場合に「地区」と「分析コード」が出力されない障害対応
                                    if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                                    {
                                        row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                                        if (data.CustAnalysCode1 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                                        }
                                        if (data.CustAnalysCode2 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                                        }
                                        if (data.CustAnalysCode3 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                                        }
                                        if (data.CustAnalysCode4 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                                        }
                                        if (data.CustAnalysCode5 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                                        }
                                        if (data.CustAnalysCode6 != 0)
                                        {
                                            row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                                        }
                                    }
                                    // ---------- ADD K2015/12/10 Y.Wakita ----------<<<<<

                                    #endregion // 明細・売上データ
                                }
                                else
                                {
                                    #region 明細・入金データ
                                    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowNo;
                                    row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                    // ※入金データ上はADDUPADATEが伝票日付なのでSalesDateColumnにはADDUPADATEをセットする(計上日と同じ内容になる)
                                    row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.AddUpADate;
                                    row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                    row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = data.SalesRowNo;
                                    row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                    row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                    row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                    row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "入金";
                                    row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                    row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                    row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                    if (data.BLGoodsCode == 0)
                                    {
                                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                    }
                                    row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                    row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.SalesMoneyTaxExc;
                                    row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                    row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                    row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                    row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                    row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                    row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                    row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                    row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                    row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                    row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                    row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm(data.DtlNote); // 明細備考←有効期限をセット
                                    row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                    if (data.AddUpADate != DateTime.MinValue)
                                    {
                                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                    }
                                    row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                                    if (data.DebitNoteDiv == 0)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "黒";
                                    }
                                    else if (data.DebitNoteDiv == 1)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤";
                                    }
                                    else if (data.DebitNoteDiv == 2)
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "相殺済み黒";
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                    }
                                    row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                                    // 入力日
                                    if (data.InputDay != DateTime.MinValue)
                                    {
                                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                                    }
                                    row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.HistoryDivNameColumn.ColumnName] = string.Empty; // 履歴区分
                                    row[_dataSet.SalesDetail.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText(data.UpdateDateTime); // 伝票発行時刻
                                    if (data.UpdateDateTimeDetail != 0)
                                    {
                                        DateTime dt = new DateTime(data.UpdateDateTimeDetail);
                                        row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // 更新日時
                                    }
                                    else
                                    {
                                        row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = string.Empty;
                                    }
                                    #endregion // 明細・入金データ
                                }

                                // 検索モードが「1：明細」の場合、行追加
                                if (mode == 1)
                                {
                                    if (data.DataDiv == 0)
                                    {
                                        this._salesDetailTbl4Text.Rows.Add(row);
                                    }
                                    else
                                    {
                                        // 手数料、値引きの明細データはこの時点では作成しない
                                        if ((data.SalesRowNo != 0) && (string.IsNullOrEmpty(data.GoodsName.TrimEnd())) == false)
                                        {
                                            this._salesDetailTbl4Text.Rows.Add(row);
                                        }
                                    }
                                }

                                #endregion // 明細データテーブル

                                #region 金額データを集計

                                //-------------------------
                                // 金額データを集計
                                //-------------------------
                                if (data.DataDiv == 0)  // 売上データの場合
                                {
                                    // 伝票別内税金額集計
                                    if (data.TaxationDivCd == 2)
                                    {
                                        long consTaxInclu = (long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName]
                                                            - (long)row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName];
                                        salAmntConsTaxInclu += consTaxInclu;
                                    }

                                    // 保存されている伝票番号を更新
                                    if (!data.SalesSlipNum.Equals(exSlipNum2))
                                    {
                                        exSlipNum2 = data.SalesSlipNum;
                                    }
                                }

                                #endregion // 金額データを集計

                                #region 伝票表示データテーブル

                                // これは絞り込みを行う
                                // 絞込の条件項目は伝票番号、受注ステータス
                                if (index > 0 && (!data.SalesSlipNum.Equals(exSlipNum) || data.AcptAnOdrStatus != exAcptAnOdrStatus))
                                {
                                    // 伝票表示グリッドへのセット
                                    CustPrtPprSalTblRsltWork prevData = (CustPrtPprSalTblRsltWork)(resultList[index - 1]);
                                    CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._salesDetailTbl4Text;
                                    rowDetailNo = rowNo;
                                    // 検索モードが「1：明細」の場合、行追加
                                    if (mode == 1)
                                    {
                                        AddFeeAndDiscountRow(ref table, ref rowDetailNo, prevData);
                                    }
                                    rowNo = rowDetailNo;
                                    prevData.AcptAnOdrStatusSrc = beAcptAnOdrStatusSrc;
                                    prevData.HisDtlSlipNum = beHisDtlSlipNum;
                                    // 検索モードが「0：伝票」の場合、伝票グリッドへのセット（伝票単位）
                                    if (mode == 0)
                                    {
                                        RecordSetToSlipList(prevData, rowNo, salAmntConsTaxInclu, yeardiv, 1);
                                    }
                                    beAcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
                                    beHisDtlSlipNum = data.HisDtlSlipNum;
                                    rowNo = rowDetailNo;

                                    salAmntConsTaxInclu = 0; // 伝票別内税金額集計値を初期化
                                    if (_extractCancelFlag == true)
                                    {
                                        exAcptAnOdrStatus = data.AcptAnOdrStatus;
                                        exSlipNum = data.SalesSlipNum;
                                        rowNo++;

                                        break;
                                    }
                                }
                                if (index == 0)
                                {
                                    beAcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
                                    beHisDtlSlipNum = data.HisDtlSlipNum;

                                }
                                // 伝票番号および受注ステータスを保存
                                exAcptAnOdrStatus = data.AcptAnOdrStatus;
                                exSlipNum = data.SalesSlipNum;
                                #endregion // 伝票表示データテーブル

                                rowNo++;
                            }
                            // --- UPD 2020/12/21 警告対応 ---------->>>>>
                            ///catch (ConstraintException ex)
                            catch (ConstraintException)
                            // --- UPD 2020/12/21 警告対応 ----------<<<<<
                            {
                            }
                        }

                        // 最後の伝票情報をセット
                        if (resultList != null && resultList.Count > 0)
                        {
                            ArrayList retList = resultList;
                            CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)retList[lastIndex];

                            CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._salesDetailTbl4Text;
                            rowDetailNo = rowNo;
                            // 検索モードが「1：明細」の場合、行追加
                            if (mode == 1)
                            {
                                AddFeeAndDiscountRow(ref table, ref rowDetailNo, data);
                            }
                            rowNo = rowDetailNo;
                            data.AcptAnOdrStatusSrc = beAcptAnOdrStatusSrc;
                            data.HisDtlSlipNum = beHisDtlSlipNum;
                            // 検索モードが「0：伝票」の場合、伝票グリッドへのセット（伝票単位）
                            if (mode == 0)
                            {
                                RecordSetToSlipList(data, rowNo, salAmntConsTaxInclu, yeardiv, 1);
                            }
                        }

                        // 検索モードが「1：明細」の場合
                        if (mode == 1)
                        {
                            // 入金のみ行番号採番しなおす
                            DateTime exSalesDate = DateTime.MinValue;
                            rowDetailNo = 1;
                            exSlipNum = string.Empty;

                            string filter = string.Format("{0} <> {1}", this._dataSet.SalesDetail.DataDivColumn.ColumnName, 0);
                            string sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                            this._dataSet.SalesDetail.SalesDateColumn.ColumnName,
                                            this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName,
                                            this._dataSet.SalesDetail.DataDivColumn.ColumnName,
                                            this._dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName,
                                            this._dataSet.SalesDetail.SalesSlipCdColumn.ColumnName,
                                            this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName);

                            DataRow[] dataRows = this._salesDetailTbl4Text.Select(filter, sort);
                            DataRow dataRow = null;
                            for (int i = 0; i <= dataRows.Length - 1; i++)
                            {
                                dataRow = dataRows[i];

                                if ((exSalesDate.Equals(dataRow[this._dataSet.SalesDetail.SalesDateColumn.ColumnName]) == false) ||
                                    (exSlipNum.Equals(dataRow[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName]) == false))
                                {
                                    rowDetailNo = 1;
                                }

                                dataRow[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = rowDetailNo++;

                                exSalesDate = (DateTime)dataRow[this._dataSet.SalesDetail.SalesDateColumn.ColumnName];
                                exSlipNum = (string)dataRow[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName];
                            }
                        }
                        // 得意先未入力のときstatus=EOFで返却されるので明細該当データがあればnormalで返す
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // 件数ゼロならばリモートstatus＝0:正常でも該当なしで返す
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // データセットをクリア
                this._salesListTbl4Text.Clear();
                this._salesDetailTbl4Text.Clear();

                resultList = null;
            }

            return status;
        }
        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

        /// <summary>
        /// 検索
        /// </summary>
        /// <param name="custPtrPpr">検索条件クラス</param>
        /// <param name="logicalDelDiv">削除指定区分：0=標準,1=削除分のみ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2009/11/25 呉元嘯</br>
        /// <br>              PM.NS保守依頼③ 不具合対応</br>
        /// <br>              ①明細タブでチェックボックスを表示する。（入金データ、過去分の履歴データ以外）</br>
        /// <br>              ②返品時在庫登録時の不具合対応</br>
        /// <br>Update Note : 2009/12/15 呉元嘯</br>
        /// <br>              Redmine#1919対応</br>
        /// <br>Update Note : 2009/12/28 呉元嘯 PM.NS保守依頼④</br>
        /// <br>              変更前単価、変更前原価の追加</br>
        /// <br>Update Note : 2010/01/29 楊明俊 4次改良</br>
        /// <br>              返品不可設定機能の追加</br>
        /// <br>Update Note : 2010/08/05 呉元嘯</br>
        /// <br>              売上伝票入力時金額変更した場合明細の色を変えて表示しているが、得意先電子元帳でも同様に色を変えて表示する。</br>
        /// <br>Update Note : 2010/08/31 呉元嘯</br>
        /// <br>              Redmine#14006対応</br>
        /// <br>Update Note : 2010/09/01 caowj</br>
        /// <br>              Redmine#14073対応</br>
        /// <br>Update Note: 2010/09/16 楊明俊</br>
        /// <br>            ・障害ID:14483 PM1012PM.NS障害改良対応（８月分）</br>
        /// <br>Update Note: 2010/12/20 yangmj </br>
        /// <br>             標準価格表示の変更</br>
        /// <br>             年式に月のみ設定されている場合のエラー修正</br>
        /// <br>             計上元受注№・計上元貸出№の表示内容修正</br>
        /// <br>             合計表示数量に商品値引き分を加えないよう修正</br>
        /// <br>            ・障害ID:14483 PM1012PM.NS障害改良対応（８月分）</br>
        /// <br>Update Note: 2011/09/21 田建委 </br>
        /// <br>             Redmine#25430対応</br>
        /// <br>             得意先電子元帳の検索不具合についての修正</br>
        /// <br>Update Note: 2011/11/23 陳建明</br>
        /// <br>             Redmine#8079対応</br>
        /// <br>             得意先電子元帳/年式の表示についての修正</br>
        /// <br>Update Note: 2011/11/28 楊洋</br>
        /// <br>             Redmine#8172の対応</br>
        /// <br>             得意先電子元帳/(BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑ)問合せ番号の追加</br>
		/// <br>Update Note : 2013/01/30 wangf </br>
		/// <br>            : 10801804-00、速度改善関連、Redmine#34513 サーバー負荷軽減の為、得意先電子元帳の改良の対応</br>
		/// <br>            : 残高集計のタイミングをずらす</br>
        /// <br>UpdateNote  : K2014/05/08 林超凡</br>
        /// <br>            : 得意先電子元帳のCSV出力項目に車種メーカーコードを追加する、東亜商会個別対応</br>
        /// <br>Update Note : K2015/4/27 陳亮</br>
        /// <br>            : 11100842-00 モモセ部品㈱の個別開発依頼
        /// <br>            : 得意先電子元帳第二売価を追加する。モモセ部品㈱オプションが有効の場合のみ。</br>
        /// <br>Update Note : K2015/06/16 鮑晶 </br>
        /// <br>            : メイゴ㈱の個別開発依頼 </br>
        /// <br>            : 得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// <br>Update Note : 2016/01/21 脇田 靖之</br>
        /// <br>管理番号    : 11270007-00</br>
        /// <br>            : 仕掛一覧№2808 貸出受注対応</br>
        /// <br>            : ①検索条件に「出荷状況」項目を追加</br>
        /// <br>            : ②明細表示に計上数、未計上数項目を追加</br>
        /// <br>Update Note : 2020/03/11 時シン</br>
        /// <br>管理番号    : 11570208-00</br>
        /// <br>            : PMKOBETSU-2912 軽減税率対応</br>
        /// <br>            : 伝票タブ、明細タブに「消費税率」項目を追加</br>
        /// </remarks>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
        //public int Search(CustPrtPpr custPrtPpr, int logicalDelDiv)
        public int Search( CustPrtPpr custPrtPpr, int logicalDelDiv, out long counter )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD
        {
            int status;

            // 得意先コードが指定されていれば残高を表示
            if ( custPrtPpr.CustomerCode == 0 )
            {
                // 得意先コードがない場合は残高を表示しない
                _customerPointed = false;
            }
            else
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
                //// 得意先情報を取得し、締め日を取得しておく
                //CustomerSearchRet[] customerInfo;
                //CustomerSearchPara customerPara = new CustomerSearchPara();
                //customerPara.CustomerCode = custPrtPpr.CustomerCode;
                //status = this._customerAcs.Serch(out customerInfo, customerPara);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    CustomerSearchRet data = (CustomerSearchRet)customerInfo[0];
                //    this._customerCalcDate = data.TotalDay;
                //    //foreach (CustomerSearchRet data in (ArrayList)customerInfo)
                //    //{
                //    // 締め日を取得
                //    //this._customerCalcDate = data.TotalDay;
                //    //}
                //}
                //else
                //{
                //    // 得意先情報がない
                //    // *** 情報のない得意先はパラメータとして渡ってこない ***
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
            }

            // パラメータクラスを作成
            CustPrtPprWork custPrtPprWork = new CustPrtPprWork();
            CustPrtPpr2CustPrtPprWork( ref custPrtPpr, ref custPrtPprWork );

            //---------------------------------
            // 返り値で使用するクラスを作成
            //---------------------------------

            // 残高照会に表示するので１件のみ
            CustPrtPprBlDspRsltWork custPrtPprBlDspRsltWork = new CustPrtPprBlDspRsltWork();
            object custPrtPprBlDspRsltWorkObj = (object)custPrtPprBlDspRsltWork;

            // 明細なのでrecordCount件数配列で帰ってくる
            CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork = new CustPrtPprSalTblRsltWork();
            object custPrtPprSalTblRsltWorkObj = (object)custPrtPprSalTblRsltWork;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
            //long counter = 0;
            counter = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
            if ( _extractCancelFlag == true ) return 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
            if ( logicalDelDiv == 0 )
            {
                // 削除分を含まない場合はGetData0を指定(削除フラグ=0のデータを返す)
                status = this._iCustPrtPprWorkDB.SearchRef( ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData0 );
            }
            else
            {
                // 削除済みの場合はGetData1を指定(削除フラグ=1のデータを返す)
                status = this._iCustPrtPprWorkDB.SearchRef( ref custPrtPprBlDspRsltWorkObj, ref custPrtPprSalTblRsltWorkObj, (object)custPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData1 );
            }
            custPrtPprBlDspRsltWorkObj = null; // ADD 2015/02/05 王亜楠 // メモリの解放
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
            if ( _extractCancelFlag == true ) return 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
            // ※引数のreadModeは現在使用していないのでどんな値を入れても問題なし

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 DEL
            //// Statusが正常値だった場合のみデータセットに戻りデータをセット
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
            if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //// 一件以上の戻りがあった場合のみ
                //if ( counter > 0 )
                //{
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                DataRow row;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                //DataRow row2;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                DataRow row3;
                // 伝票単位は、「伝票番号」及び「受注ステータス」が同一のものをひとつのくくりとして判定する
                string exSlipNum = string.Empty;    // ひとつ前の伝票番号
                // 2010/07/08 Add >>>
                string exSlipNum2 = string.Empty;    // ひとつ前の伝票番号
                // 2010/07/08 Add <<<
                int exAcptAnOdrStatus = 0;          // ひとつ前の受注ステータス

                // 残高表示で使用する集計値
                int slipCount = 0;              // 伝票枚数
                double detailSlipCount = 0;       // 明細数
                double totalAmount = 0;           // 数量
                double totalConsumeTaxAmount = 0; // 消費税

                // 請求範囲内で集計する値
                long totalThisSalesPrice = 0;   // 今回売上
                long totalOfsThisSalesTax = 0;  // 消費税（売）
                long totalThisTimeDmdNrml = 0;  // 今回入金

                double StandardPrice_Total = 0;   // 標準価格合計
                //double StandardPrice_Avg = 0;     // 標準価格平均
                double SoldAmount_Total = 0;      // 売上金額合計
                //double SoldAmount_Avg = 0;        // 売上金額平均
                double Cost_Total = 0;            // 原価合計
                //double Cost_Avg = 0;              // 原価平均
                double GrossProfitAmount_Total = 0;   // 粗利額合計
                //double GrossProfitAmount_Avg = 0;     // 粗利額平均

                // --- DEL 2020/12/21 警告対応 ---------->>>>>
                //long AfCalDemandPrice = 0;            // 前回残高
                //// --- DEL 2020/12/21 警告対応 ----------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                long salAmntConsTaxInclu = 0; // 伝票別内税金額集計値
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                int rowNo = 1;
                int rowDetailNo = 0;        //ADD 2009/02/14 不具合対応[11391]

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                # region // DEL
                ////-------------------
                //// 残高表示
                ////-------------------

                //// 残高表示が一件で特定できなかった場合は表示しない
                //// 得意先が存在しない場合も表示しない
                //ArrayList al = (ArrayList)custPrtPprBlDspRsltWorkObj;
                //if ( al.Count == 1 || !_customerPointed )
                //{
                //    foreach ( CustPrtPprBlDspRsltWork remainData in (ArrayList)custPrtPprBlDspRsltWorkObj )
                //    {
                //        row3 = this._dataSet.BalanceTotal.NewRow();
                //        row3[_dataSet.BalanceTotal.AcpOdrTtl2TmBfBlDmdColumn.ColumnName] = remainData.AcpOdrTtl2TmBfBlDmd;  // 前々々回残高
                //        row3[_dataSet.BalanceTotal.LastTimeDemandColumn.ColumnName] = remainData.LastTimeDemand;            // 前々回残高
                //        row3[_dataSet.BalanceTotal.AfCalDemandPriceColumn.ColumnName] = remainData.AfCalDemandPrice;        // 前回残高
                //        AfCalDemandPrice = remainData.AfCalDemandPrice;
                //        row3[_dataSet.BalanceTotal.AddUpYearMonthColumn.ColumnName] = remainData.AddUpYearMonth;            // 請求年月
                //        row3[_dataSet.BalanceTotal.ConsTaxLayMethodColumn.ColumnName] = remainData.ConsTaxLayMethod;        // 消費税転嫁方式
                //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
                //        // 請求金額
                //        row3[_dataSet.BalanceTotal.AfCalBlcColumn.ColumnName] = remainDataExtra.AfCalBlc;
                //        // 今回売上
                //        row3[_dataSet.BalanceTotal.ThisSalesPriceTotalColumn.ColumnName] = remainDataExtra.OfsThisTimeSales;
                //        // 消費税
                //        row3[_dataSet.BalanceTotal.OfsThisSalesTaxColumn.ColumnName] = remainDataExtra.OfsThisSalesTax;
                //        // 今回入金
                //        row3[_dataSet.BalanceTotal.ThisTimeDmdNrmlColumn.ColumnName] = remainDataExtra.ThisTimeDmdNrml;
                //        // 締開始日
                //        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = remainDataExtra.DmdStDay;
                //        // 締処理日
                //        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = remainDataExtra.TotalDay;
                //        // 親フラグ
                //        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = remainDataExtra.IsParent;
                //        // データ存在フラグ
                //        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = true;
                //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

                //        this._dataSet.BalanceTotal.Rows.Add( row3 );
                //    }
                //}
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                // 伝票番号
                //string salesSlipNumExt = string.Empty;  // DEL huangt 2013/05/15 Redmine#35640 

                // --- DEL 2020/12/21 警告対応 ---------->>>>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
                //bool cancelFlag = false;
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD
                // --- DEL 2020/12/21 警告対応 ----------<<<<<

				// ------------DEL wangf 2013/01/30 FOR Redmine#34513--------->>>>
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
				//// ※売上締次集計リモートを使用
				////   (得意先電子元帳リモートが返すcustPrtPprBlDspRsltWorkObjは使用しない)
				//RemainDataExtra remainDataExtra = new RemainDataExtra();
                
				//// --- UPD m.suzuki 2010/07/21 ---------->>>>>
				////SearchBlDspRslt( ref custPrtPprBlDspRsltWorkObj, ref remainDataExtra, custPrtPpr );
				//int blDspRsltStatus = SearchBlDspRslt( ref custPrtPprBlDspRsltWorkObj, ref remainDataExtra, custPrtPpr );
				//if ( blDspRsltStatus == (int)ConstantManagement.DB_Status.ctDB_ERROR )
				//{
				//    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
				//}
				//// --- UPD m.suzuki 2010/07/21 ----------<<<<<
				////-------------------
				//// 残高表示
				////-------------------
				//# region [残高表示]
				//// 残高表示が一件で特定できなかった場合は表示しない
				//// 得意先が存在しない場合も表示しない
				//ArrayList al = (ArrayList)custPrtPprBlDspRsltWorkObj;
				//if ( al.Count == 1 || !_customerPointed )
				//{
				//    foreach ( CustPrtPprBlDspRsltWork remainData in (ArrayList)custPrtPprBlDspRsltWorkObj )
				//    {
				//        row3 = this._dataSet.BalanceTotal.NewRow();
				//        row3[_dataSet.BalanceTotal.AcpOdrTtl2TmBfBlDmdColumn.ColumnName] = remainData.AcpOdrTtl2TmBfBlDmd;  // 前々々回残高
				//        row3[_dataSet.BalanceTotal.LastTimeDemandColumn.ColumnName] = remainData.LastTimeDemand;            // 前々回残高
				//        row3[_dataSet.BalanceTotal.AfCalDemandPriceColumn.ColumnName] = remainData.AfCalDemandPrice;        // 前回残高
				//        AfCalDemandPrice = remainData.AfCalDemandPrice;
				//        row3[_dataSet.BalanceTotal.AddUpYearMonthColumn.ColumnName] = remainData.AddUpYearMonth;            // 請求年月
				//        row3[_dataSet.BalanceTotal.ConsTaxLayMethodColumn.ColumnName] = remainData.ConsTaxLayMethod;        // 消費税転嫁方式
				//        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
				//        // 請求金額
				//        row3[_dataSet.BalanceTotal.AfCalBlcColumn.ColumnName] = remainDataExtra.AfCalBlc;
				//        // 今回売上
				//        row3[_dataSet.BalanceTotal.ThisSalesPriceTotalColumn.ColumnName] = remainDataExtra.OfsThisTimeSales;
				//        // 消費税
				//        row3[_dataSet.BalanceTotal.OfsThisSalesTaxColumn.ColumnName] = remainDataExtra.OfsThisSalesTax;
				//        // 今回入金
				//        row3[_dataSet.BalanceTotal.ThisTimeDmdNrmlColumn.ColumnName] = remainDataExtra.ThisTimeDmdNrml;
				//        // 締開始日
				//        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = remainDataExtra.DmdStDay;
				//        // 締処理日
				//        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = remainDataExtra.TotalDay;
				//        // 親フラグ
				//        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = remainDataExtra.IsParent;
				//        // データ存在フラグ
				//        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = true;
				//        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

				//        this._dataSet.BalanceTotal.Rows.Add( row3 );
				//    }
				//}
				//# endregion

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD
				// ------------DEL wangf 2013/01/30 FOR Redmine#34513---------<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                // 一件以上の戻りがあった場合のみ
                if ( counter > 0 )
                {
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                    ////foreach (CustPrtPprSalTblRsltWork data in (ArrayList)custPrtPprSalTblRsltWorkObj)
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                    //for ( int index = 0; index < (custPrtPprSalTblRsltWorkObj as ArrayList).Count; index++ )
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                    //for ( int index = 0; index < (custPrtPprSalTblRsltWorkObj as ArrayList).Count; index++ )

                    int lastIndex = 0;

                    int maxCount = (custPrtPprSalTblRsltWorkObj as ArrayList).Count;
                    if ( maxCount > custPrtPpr.SearchCnt - 1 )
                    {
                        // リモートからは最大で20,001件返ってくるので、20,000件までにする
                        maxCount = (int)custPrtPpr.SearchCnt - 1;
                    }
                    //-----ADD 2010/12/20 ----->>>>>
                    int beAcptAnOdrStatusSrc = 0;
                    string beHisDtlSlipNum = string.Empty;
                    //-----ADD 2010/12/20 -----<<<<<
                    //-----ADD 2011/07/28 ------>>>>>
                    AllDefSetAcs alldefsetacs = new AllDefSetAcs();
                    ArrayList outList = new ArrayList();
                    int yeardiv=0;
                    // ----- UPD 2011/09/21 -------------------------------------------------------->>>>>
                    //int stat = alldefsetacs.SearchAll(out outList, LoginInfoAcquisition.EnterpriseCode);
                    int stat = alldefsetacs.Search(out outList, LoginInfoAcquisition.EnterpriseCode);
                    // ----- UPD 2011/09/21 --------------------------------------------------------<<<<<
                    if (stat == 0)
                    {
                        foreach (AllDefSet alldefset in outList)
                        {
                            string sectionCodeE = alldefset.SectionCode.Trim();
                            // ----- UPD 2011/09/21 -------------------------------->>>>>
                            //if (sectionCodeE.Equals(custPrtPpr.SectionCode[0]))
                            //{
                            //    yeardiv = alldefset.EraNameDispCd1;
                            //}
                            if (sectionCodeE.Equals(LoginInfoAcquisition.Employee.BelongSectionCode.Trim()))
                            {
                                yeardiv = alldefset.EraNameDispCd1;
                            }
                            else if (sectionCodeE.Equals("00"))
                            {
                                yeardiv = alldefset.EraNameDispCd1;
                            }
                            // ----- UPD 2011/09/21 --------------------------------<<<<<
                        }
                    }
                    // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加 ---->>>>>
                    // 売上金額処理設定
                    if (_salesProcMoneyAcs == null)
                    {
                        this.InitSalesProcMoney();
                    }
                    // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加 ----<<<<<

                    //-----ADD 2011/07/28 ------<<<<<
                    for ( int index = 0; index < maxCount; index++ )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
                        lastIndex = index;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)((custPrtPprSalTblRsltWorkObj as ArrayList)[index]);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                        // 伝票番号フォーマット対応
                        data.SalesSlipNum = GetSlipNum( data );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                        // データセットに返り値をセットする
                        try
                        {
                            #region 明細データテーブル

                            row = this._dataSet.SalesDetail.NewRow();

                            if ( data.DataDiv == 0 ) // 売上データの場合
                            {
                                #region 明細・売上データ
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                // 返品・値引制御のための数量・金額の符号(1or-1)
                                // （返品の値引きは-1*-1で1）
                                // ※返品・値引きはデータ上数量マイナスなので、detailSignをかけてプラスにする
                                // 　単純にAbsをとるわけではないので注意。
                                int detailSign = 1;

                                // 返品判定
                                if ( data.SalesSlipCd == 1 ) detailSign *= -1;

                                // 商品値引判定(行値引は除外)
                                if ( data.SalesSlipCdDtl == 2 && !string.IsNullOrEmpty( data.GoodsNo ) ) detailSign *= -1;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD

                                // --- UPD 2009/11/25 ---------->>>>>
                                // 赤伝・元黒はチェックできない
                                // 過去分(売上履歴からの取得分)はチェック不可
                                //if ( data.DebitNoteDiv == 1 || data.DebitNoteDiv == 2 )
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
                                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                                //else if ( data.HistoryDiv != 0 )
                                //{
                                //    // 過去分(売上履歴からの取得分)はチェック不可
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                                // ----------DEL 2009/12/15------------>>>>>
                                //// 過去分(売上履歴からの取得分)はチェック不可
                                //if (data.HistoryDiv != 0)
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                // ----------DEL 2009/12/15------------<<<<<
                                //else if (data.HistoryDiv == 0 && data.AcptAnOdrRemainCnt <= 0)
                                //{
                                //    // 通常：受注残数が残っていない明細は赤伝不可
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
                                // ----------UPD 2009/12/15------------>>>>>
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = false;
                                //}
                                row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = false;
                                // ----------UPD 2009/12/15------------<<<<<
                                // --- UPD 2009/11/25 ----------<<<<<
                                row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowNo;
                                //row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.SalesDate);
                                row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;//.PadLeft(8, '0');
                                row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = data.SalesRowNo;
                                row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
                                //// sakurai Add 2009/02/03 >>>>>>>>>>>>>>>>>>>>>>>>>
                                //row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.AcptAnOdrRemainCnt;
                                //// sakurai Add 2009/02/03 <<<<<<<<<<<<<<<<<<<<<<<<<

                                // --- ADD 2010/01/29 ---------->>>>>
                                row[this._dataSet.SalesDetail.RetuppercntColumn.ColumnName] = data.Retuppercnt;
                                row[this._dataSet.SalesDetail.RetuppercntDivColumn.ColumnName] = data.RetuppercntDiv;
                                // --- ADD 2010/01/29 ----------<<<<<

                                if ( data.HistoryDiv == 0 )
                                {
                                    // 履歴以外
                                    row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.AcptAnOdrRemainCnt;
                                }
                                else
                                {
                                    // 履歴
                                    // （内部的には出荷数と同数を入れる事で赤伝発行可能にする＋出荷数までは赤伝可能にする）
                                    row[_dataSet.SalesDetail.AcptAnOdrRemainCntColumn.ColumnName] = data.ShipmentCnt;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
                                // 伝票区分名判定
                                if ( data.SalesSlipCd == 0 )
                                {
                                    if ( data.AcptAnOdrStatus == 20 )
                                    {
                                        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "受注";
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                        // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value; // DEL 2009/11/25
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                    }
                                    else if ( data.AcptAnOdrStatus == 30 )
                                    {
                                        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "売上";
                                    }
                                    else if ( data.AcptAnOdrStatus == 40 )
                                    {
                                        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "貸出";
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                        // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;// DEL 2009/11/25
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                    }
                                    else
                                    {
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                        // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value; // DEL 2009/11/25
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                    }
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "返品";
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                    // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;// DEL 2009/11/25
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 UPD
                                //if (data.AcptAnOdrRemainCnt == 0 || data.AcptAnOdrRemainCnt == null)
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                //----------- DEL 2009/11/25 --------->>>>>
                                //if ( (data.AcptAnOdrRemainCnt == 0 || data.AcptAnOdrRemainCnt == null) && data.HistoryDiv == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //}
                                //----------- DEL 2009/11/25 ---------<<<<<
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 UPD
                                row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; //ADD 陳永康 2014/12/28 変換後品番の追加対応
                                if ( data.BLGoodsCode == 0 )
                                {
                                    row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft( CT_DEPTH_BLGOODSCODE, '0' );
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode.ToString().PadLeft(CT_DEPTH_BLGROUPCODE, '0');
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = data.ShipmentCnt;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = detailSign * data.ShipmentCnt;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD

                                //-----UPD 2010/12/20 ----->>>>>
                                //if ( data.OpenPriceDiv == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl.ToString( "#,###" );
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = "ｵｰﾌﾟﾝ価格";
                                //}
                                //row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl.ToString("#,###");
                                //-----UPD 2011/07/13 ----->>>>>
                                row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl;
                                row[_dataSet.SalesDetail.CostRateColumn.ColumnName] = data.CostRate;     //原価率 ADD 連番729 2011/08/18
                                row[_dataSet.SalesDetail.SalesRateColumn.ColumnName] = data.SalesRate;   //売価率 ADD 連番729 2011/08/18
                                //-----UPD 2011/07/13 ----->>>>>
                                //-----UPD 2010/12/20 -----<<<<<

                                row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = data.SalesUnPrcTaxExcFl;
                                row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = data.SalesUnitCost;
                                // -------------ADD 2009/12/28-------------->>>>>
                                row[_dataSet.SalesDetail.BfSalesUnitPriceColumn.ColumnName] = data.BfSalesUnitPrice;//変更前単価
                                row[_dataSet.SalesDetail.BfUnitCostColumn.ColumnName] = data.BfUnitCost;//変更前原価
                                // -------------ADD 2009/12/28--------------<<<<<
                                row[_dataSet.SalesDetail.BfListPriceColumn.ColumnName] = data.BfListPrice;//変更前定価// ADD 2010/08/05
                                // -------------ADD 2011/07/18 朱宝軍-------------->>>>>
                                // 0:通常(PCC連携なし)、1:手動回答、2:自動回答
                                if (data.AutoAnswerDivSCM == 0)
                                {
                                    row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "通常";
                                }
                                else if (data.AutoAnswerDivSCM == 1)
                                {
                                    row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "手動回答";
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.AutoAnswerDivSCMColumn.ColumnName] = "自動回答";
                                }
                                // -------------ADD 2011/07/18 朱宝軍--------------<<<<<

                                //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
                                if (data.InquiryNumber == 0)
                                {
                                    row[_dataSet.SalesDetail.InquiryNumberColumn.ColumnName] = string.Empty; //問合せ番号
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.InquiryNumberColumn.ColumnName] = data.InquiryNumber.ToString().PadLeft(CT_DEPTH_INQUIRYNUMBER, '0'); //問合せ番号
                                }
                                //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 DEL
                                //row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.SalesMoneyTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 DEL
                                row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = data.ConsTaxLayMethod;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 DEL
                                //row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = data.SalesTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 DEL
                                //if (data.ConsTaxLayMethod == 0) // 伝票単位
                                //{
                                //    if (!data.SalesSlipNum.Equals(salesSlipNumExt)) // 一行目のみ表示
                                //    {
                                //        // 売上伝票合計(税込)(SalesTotalTaxInc) - 売上伝票合計(税抜き)()
                                //        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                //    }
                                //}
                                //else if (data.ConsTaxLayMethod == 1) // 明細単位
                                //{
                                //    // 売上金額消費税額
                                //    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = data.SalesPriceConsTax;
                                //}
                                //else // 請求親(2)・請求子(3)・非課税(9)は空白
                                //{
                                //    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/11 ADD

                                # region [消費税関連]
                                bool printTax = true;
                                Int64 salesTotalTaxInc;
                                Int64 salesTotalTaxExc = data.SalesMoneyTaxExc;
                                Int64 salesPriceConsTax;

                                // 印刷する消費税額の取得
                                if ( data.ConsTaxLayMethod == 0 ) // 伝票単位
                                {
                                    //if ( !data.SalesSlipNum.Equals( salesSlipNumExt ) ) // 一行目のみ表示     // DEL huangt 2013/05/15 Redmine#35640
                                    if (data.SalesRowNo == 1)  // 伝票毎の明細先頭行に消費税が印字される    　　// ADD huangt 2013/05/15 Redmine#35640 
                                    {
                                        salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                    }
                                    else
                                    {
                                        salesPriceConsTax = 0;
                                        printTax = false;
                                    }
                                }
                                else if ( data.ConsTaxLayMethod == 1 ) // 明細単位
                                {
                                    salesPriceConsTax = data.SalesPriceConsTax;
                                }
                                else
                                {
                                    salesPriceConsTax = 0;
                                }

                                // 税込金額の取得
                                salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                                if ( printTax )
                                {
                                    // 消費税印字有無判定と金額制御
                                    int totalAmountDispWayCd = data.TotalAmountDispWayCd;
                                    int taxationDivCd = data.TaxationDivCd;

                                    // 消費税印字有無判定
                                    printTax = ReflectMoneyForTaxPrint( ref salesTotalTaxExc, ref salesPriceConsTax, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod, taxationDivCd );
                                    if ( printTax )
                                    {
                                        if ( salesPriceConsTax != 0 )
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                            //row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = salesPriceConsTax;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                            row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = detailSign * salesPriceConsTax;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                            row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = data.ConsTaxRate; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                        }
                                        else
                                        {
                                            // 印字しない
                                            row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                            row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                        }
                                    }
                                    else
                                    {
                                        // 印字しない
                                        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                        row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                    }
                                }
                                else
                                {
                                    // 印字しない
                                    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //// 税抜金額セット
                                //row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = salesTotalTaxExc;
                                //// 税込金額セット
                                //row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = salesTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                // 税抜金額セット
                                row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = detailSign * salesTotalTaxExc;
                                // 税込金額セット
                                row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = detailSign * salesTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                # endregion

                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/11 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = data.TotalCost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = detailSign * data.TotalCost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //// 類別番号[0のときは空白]
                                //if (data.CategoryNo == 0)
                                //{
                                //    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = data.CategoryNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                // 類別型式
                                row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = GetModelDesignationNoAndCategoryNo( data );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
                                // 型式指定番号(数値)
                                row[_dataSet.SalesDetail.ModelDesignationNoOrgColumn.ColumnName] = data.ModelDesignationNo;
                                // 類別番号(数値)
                                row[_dataSet.SalesDetail.CategoryNoOrgColumn.ColumnName] = data.CategoryNo;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
                                row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                                // 車種名カナ
                                row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = data.ModelHalfName;
                                // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                                //row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.FirstEntryDate);
                                // -----------UPD 2010/01/12----------->>>>>
                                // 年式[NULLのときは空白]
                                //if (data.FirstEntryDate == DateTime.MinValue)//DBNull.Value)// 
                                if ( data.FirstEntryDate == 0 )
                                {
                                    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    //row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                                    //----UPD 2010/12/20----->>>>>
                                    string firstEntryDate = "";

                                    if (data.FirstEntryDate.ToString().Length < 6)
                                    {
                                        firstEntryDate = "0000" + "/" + data.FirstEntryDate.ToString("D2");
                                    }
                                    else
                                    {
                                        firstEntryDate = data.FirstEntryDate.ToString().Substring( 0, 4 ) + "/" + data.FirstEntryDate.ToString().Substring( 4, 2 );
                                    }
                                    firstEntryDate = firstEntryDate.Replace(@"/00", "");// ADD 2013/05/06 zhujw #34718
                                    //string firstEntryDate = data.FirstEntryDate.ToString().Substring( 0, 4 ) + "/" + data.FirstEntryDate.ToString().Substring( 4, 2 );
                                    //----UPD 2010/12/20-----<<<<<

                                    //row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = firstEntryDate;// DEL 2011/07/28
                                    //-----ADD 2011/07/28 ------>>>>>

                                    if (yeardiv ==1)
                                    {
                                        // --- UPD 2012/06/26 №880 ---------->>>>>
                                        //string date = data.FirstEntryDate.ToString() + "01";
                                        //int StartTotalUnitYm = Convert.ToInt32(date);
                                        //string stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                                        string date, stTarget;
                                        int StartTotalUnitYm;
                                        if (data.FirstEntryDate.ToString().Substring(4, 2) == "00")
                                        {
                                            date = data.FirstEntryDate.ToString().Substring(0, 4) + "0101";
                                            StartTotalUnitYm = Convert.ToInt32(date);
                                            //stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm) + "00月"; // DEL 2013/05/06 zhujw #Redmine34718
                                            stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm);// ADD 2013/05/06 zhujw #Redmine34718
                                        }
                                        else
                                        {
                                            date = data.FirstEntryDate.ToString() + "01";
                                            StartTotalUnitYm = Convert.ToInt32(date);
                                            stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                                        }
                                        // --- UPD 2012/06/26 №880 ----------<<<<<

                                        row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = stTarget;
                                        }
                                        else 
                                        {
                                          row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = firstEntryDate;
                                        }
                                    
                                    //-----ADD 2011/07/28 ------<<<<<

                                    }
                                    // -----------UPD 2010/01/12-----------<<<<<
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 DEL
                                    //// 車台No[NULLのときは空白]
                                    //if ( data.SearchFrameNo == 0 )
                                    //{
                                    //    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                    //}
                                    //else
                                    //{
                                    //    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = data.SearchFrameNo;
                                    //}
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = data.FrameNo;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                                row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = data.FullModel;
                                row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //// 仕入先コード[NULLのときは空白]
                                //if (data.SupplierCd == 0)
                                //{
                                //    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                // 計上元受注No[NULLのときは空白]

                                // ----- UPD 2010/12/20 ----->>>>>
                                //if (data.AcceptAnOrderNo == 0)
                                //{
                                //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                //}
                                if (data.AcptAnOdrStatusSrc == 20)
                                {
                                    if (!string.IsNullOrEmpty(data.HisDtlSlipNum.ToString()))
                                    {
                                        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.HisDtlSlipNum;
                                    }
                                }
                                else
                                {
                                    //if (data.AcceptAnOrderNo == 0)
                                    //{
                                        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                    //}
                                    //else
                                    //{
                                    //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                    //}
                                }
                                
                                // 計上元出荷No[NULLのときは空白]
                                //if (data.ShipmSalesSlipNum == "0")
                                //{
                                //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = string.Empty;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                //}
                                if (data.AcptAnOdrStatusSrc == 40)
                                {
                                    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.HisDtlSlipNum;
                                }
                                else
                                {
                                    //if (data.ShipmSalesSlipNum == "0")
                                    //{
                                        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = string.Empty;
                                    //}
                                    //else
                                    //{
                                    //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                    //}
                                }
                                // ----- UPD 2010/12/20 -----<<<<<

                                // 元黒No[NULLのときは空白]
                                if ( data.SrcSalesSlipNum == "0" )
                                {
                                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = string.Empty; //DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = data.SrcSalesSlipNum;
                                }
                                row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = data.SalesOrderDivCd;
                                if ( data.SalesOrderDivCd == 0 )
                                {
                                    row[_dataSet.SalesDetail.SalesOrderDivCdNameColumn.ColumnName] = "取寄";
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.SalesOrderDivCdNameColumn.ColumnName] = "在庫";
                                }
                                row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = data.WarehouseCode;
                                row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = data.WarehouseName;
                                // 同時仕入No[NULLのときは空白]
                                if ( data.SupplierSlipNo == 0 )
                                {
                                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = data.StockPartySaleSlipNum;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // 発注先コード[NULLのときは空白]
                                if ( data.UOESupplierCd == 0 )
                                {
                                    row[_dataSet.SalesDetail.UOESupplierCdColumn] = string.Empty; //DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.UOESupplierCdColumn] = data.UOESupplierCd.ToString().PadLeft( CT_DEPTH_UOESUPPLIERCODE, '0' );
                                }
                                row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = data.UOESupplierSnm;
                                row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = data.UoeRemark1;
                                row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = data.UoeRemark2;
                                row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = data.DtlNote;
                                row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = data.ColorName1;
                                row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = data.TrimName;
                                //----- UPD 2010/09/16---------->>>>>
                                //row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = data.StdUnPrcLPrice;
                                //row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = data.StdUnPrcSalUnPrc;
                                //row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = data.StdUnPrcUnCst;
                                row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = data.BfListPrice; // 変更前定価
                                row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = data.BfSalesUnitPrice;// 変更前売価
                                row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = data.BfUnitCost;// 変更前原価
                                //----- UPD 2010/09/16----------<<<<<
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //// メーカーコード[NULLのときは空白]
                                //if (data.GoodsMakerCd == 0)
                                //{
                                //    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd.ToString().PadLeft(CT_DEPTH_GOODSMAKERCODE, '0');
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                // メーカーコード
                                row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = data.MakerName;
                                row[_dataSet.SalesDetail.CostColumn.ColumnName] = data.Cost;
                                // 得意先伝票番号[NULLのときは空白]
                                if ( data.CustSlipNo == 0 )
                                {
                                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                }
                                //row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.AddUpADate);
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                if ( data.AddUpADate != DateTime.MinValue )
                                {
                                    row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                if ( data.AccRecDivCd == 1 )
                                {
                                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "売掛";
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                else
                                {
                                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "現金";
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = data.DebitNoteDiv;
                                if ( data.DebitNoteDiv == 0 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "黒伝";
                                }
                                else if ( data.DebitNoteDiv == 1 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤伝";
                                }
                                else if ( data.DebitNoteDiv == 2 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "元黒";
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //if ( (long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] < 0 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                if ( ((long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] < 0 ||
                                     (double)row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] < 0)
                                    && data.SalesSlipCdDtl != 2 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤伝";
                                    // row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value; // DEL 2009/11/25
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/03 ADD
                                //// 粗利(明細)
                                //row[_dataSet.SalesDetail.GrossProfitDetailColumn.ColumnName] = this.GetGrossProfitDetail( data );
                                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/03 ADD
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                // 粗利(明細)
                                row[_dataSet.SalesDetail.GrossProfitDetailColumn.ColumnName] = detailSign * this.GetGrossProfitDetail( data );
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD

                                //粗利率
                                row[_dataSet.SalesDetail.GrossProfitMarginColumn.ColumnName] = detailSign * this.GetGrossProfitMargin(data);  //#7861 2011/11/23 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                                // 納入先コード
                                row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                                // 納入先名1+2
                                row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = data.AddresseeName + data.AddresseeName2;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
                                // 納入先名1のみ
                                row[_dataSet.SalesDetail.AddresseeName1Column.ColumnName] = data.AddresseeName;
                                // 納入先名2のみ
                                row[_dataSet.SalesDetail.AddresseeName2Column.ColumnName] = data.AddresseeName2;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                                // 入力日
                                if ( data.InputDay != DateTime.MinValue )
                                {
                                    row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                // 明細区分
                                row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = data.SalesSlipCdDtl;
                                switch ( data.SalesSlipCdDtl )
                                {
                                    default:
                                    case 0:
                                    case 1:
                                        {
                                            row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "通常";
                                        }
                                        break;
                                    case 2:
                                        {
                                            if ( string.IsNullOrEmpty( data.GoodsNo ) )
                                            {
                                                row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "行値引";
                                            }
                                            else
                                            {
                                                row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = "商品値引";
                                            }
                                        }
                                        break;
                                }

                                // 商品大分類
                                row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = data.GoodsLGroup;
                                row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = data.GoodsLGroupName;
                                // 商品中分類
                                row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = data.GoodsMGroup;
                                row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = data.GoodsMGroupName;
                                // 商品属性
                                row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = data.GoodsKindCode;
                                switch ( data.GoodsKindCode )
                                {
                                    case 0:
                                        {
                                            row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = "純正";
                                        }
                                        break;
                                    case 1:
                                    default:
                                        {
                                            row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = "その他";
                                        }
                                        break;
                                }
                                // 棚番
                                row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = data.WarehouseShelfNo;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD

                                // 商品区分
                                row[_dataSet.SalesDetail.EnterpriseGanreCodeColumn.ColumnName] = data.EnterpriseGanreCode;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.10 ADD
                                row[_dataSet.SalesDetail.CarMngNoColumn.ColumnName] = data.CarMngNo; // 車両管理SEQ
                                row[_dataSet.SalesDetail.MakerCodeColumn.ColumnName] = data.MakerCode; // 車種メーカーコード
                                row[_dataSet.SalesDetail.ModelCodeColumn.ColumnName] = data.ModelCode; // 車種コード
                                row[_dataSet.SalesDetail.ModelSubCodeColumn.ColumnName] = data.ModelSubCode; // 車種サブコード
                                row[_dataSet.SalesDetail.EngineModelNmColumn.ColumnName] = data.EngineModelNm; // エンジン型式名称
                                row[_dataSet.SalesDetail.ColorCodeColumn.ColumnName] = data.ColorCode; // カラーコード
                                row[_dataSet.SalesDetail.TrimCodeColumn.ColumnName] = data.TrimCode; // トリムコード
                                row[_dataSet.SalesDetail.DeliveredGoodsDivColumn.ColumnName] = data.DeliveredGoodsDiv; // 納品区分

                                int[] wkFullModelFixedNoAry = new int[data.FullModelFixedNoAry.Length];
                                for ( int i = 0; i < data.FullModelFixedNoAry.Length; i++ )
                                {
                                    wkFullModelFixedNoAry[i] = data.FullModelFixedNoAry[i];
                                }
                                row[_dataSet.SalesDetail.FullModelFixedNoAryColumn.ColumnName] = wkFullModelFixedNoAry; // フル型式固定番号配列

                                // --- ADD 2010/04/27 --------------->>>>>
                                string[] wkFreeSrchMdlFxdNoAry = new string[0];
                                if ( null != data.FreeSrchMdlFxdNoAry && 0 < data.FreeSrchMdlFxdNoAry.Length )
                                {
                                    BinaryFormatter formatter = new BinaryFormatter();
                                    MemoryStream ms = new MemoryStream( data.FreeSrchMdlFxdNoAry );
                                    wkFreeSrchMdlFxdNoAry = (string[])formatter.Deserialize( ms );
                                    ms.Close();
                                }
                                row[_dataSet.SalesDetail.FreeSrchMdlFxdNoAryColumn.ColumnName] = wkFreeSrchMdlFxdNoAry;
                                // --- ADD 2010/04/27 ---------------<<<<<

                                byte[] wkCategoryObjAry = new byte[data.CategoryObjAry.Length];
                                for ( int i = 0; i < data.CategoryObjAry.Length; i++ )
                                {
                                    wkCategoryObjAry[i] = data.CategoryObjAry[i];
                                }
                                row[_dataSet.SalesDetail.CategoryObjAryColumn.ColumnName] = wkCategoryObjAry; // 装備オブジェクト配列
                                row[_dataSet.SalesDetail.SalesInputCodeColumn.ColumnName] = data.SalesInputCode; // 発行者
                                row[_dataSet.SalesDetail.FrontEmployeeCdColumn.ColumnName] = data.FrontEmployeeCd; // 受注者
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.10 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                                row[_dataSet.SalesDetail.HistoryDivNameColumn.ColumnName] = this.GetHistoryDivName( data.HistoryDiv ); // 履歴区分
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                                row[_dataSet.SalesDetail.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText( data.UpdateDateTime ); // 伝票発行時刻
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                                // ADD 2012/04/01 gezh Redmine#29250 ------------------------------------------------------------->>>>>
                                if (data.UpdateDateTimeDetail != 0)
                                {
                                    DateTime dt = new DateTime(data.UpdateDateTimeDetail);
                                    row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // 更新日時
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = string.Empty;
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 -------------------------------------------------------------<<<<<
                                // --- ADD 2009/09/07 ---------->>>>>
                                row[_dataSet.SalesDetail.MileageColumn.ColumnName] = data.Mileage;
                                row[_dataSet.SalesDetail.CarNoteColumn.ColumnName] = data.CarNote;
                                // --- ADD 2009/09/07 ----------<<<<<


                                // ----- DEL huangt 2013/05/15 Redmine#35640 ---------- >>>>> 
                                //// 保存されている伝票番号を更新
                                //if ( !data.SalesSlipNum.Equals( salesSlipNumExt ) )
                                //{
                                //    salesSlipNumExt = data.SalesSlipNum;
                                //}
                                // ----- DEL huangt 2013/05/15 Redmine#35640 ---------- <<<<< 

                                // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
                                row[_dataSet.SalesDetail.SalesNotRecognitionCntColumn.ColumnName] = DBNull.Value;   // 未計上数
                                row[_dataSet.SalesDetail.SalesRecognitionCntColumn.ColumnName] = DBNull.Value;      // 計上数

                                // 受注ステータスが"貸出"または"受注" 且つ 売上伝票区分(明細)が"売上"の場合
                                if ((data.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Shipment ||
                                     data.AcptAnOdrStatus == (int)SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) && 
                                     data.SalesSlipCd == 0)
                                {
                                    row[_dataSet.SalesDetail.SalesNotRecognitionCntColumn] = data.AcptAnOdrRemainCnt;                       // 未計上数
                                    row[_dataSet.SalesDetail.SalesRecognitionCntColumn] = (data.ShipmentCnt - data.AcptAnOdrRemainCnt);     // 計上数
                                }
                                // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

                                // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加---->>>>>
                                // モモセ部品の第二売価
                                if (this._opt_Momose == Convert.ToInt32(Option.ON))
                                {
                                    row[this._dataSet.SalesDetail.SecondSalePriceColumn.ColumnName] = this.GetSecondPrice(data);
                                }
                                // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加----<<<<<

                                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                                if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                                {
                                    row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                                    if (data.CustAnalysCode1 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                                    }
                                    if (data.CustAnalysCode2 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                                    }
                                    if (data.CustAnalysCode3 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                                    }
                                    if (data.CustAnalysCode4 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                                    }
                                    if (data.CustAnalysCode5 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                                    }
                                    if (data.CustAnalysCode6 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                                    }
                                }
                                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

                                #endregion // 明細・売上データ
                            }
                            else
                            {
                                #region 明細・入金データ
                                row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = false;
                                //row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.SalesDate);
                                row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowNo;
                                row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                //row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                // ※入金データ上はADDUPADATEが伝票日付なのでSalesDateColumnにはADDUPADATEをセットする(計上日と同じ内容になる)
                                row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.AddUpADate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                                row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = data.SalesRowNo;
                                row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "入金";
                                row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; //ADD 陳永康 2014/12/28 変換後品番の追加対応
                                if ( data.BLGoodsCode == 0 )
                                {
                                    row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft( CT_DEPTH_BLGOODSCODE, '0' );
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode.ToString().PadLeft(CT_DEPTH_BLGROUPCODE, '0');
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = data.ShipmentCnt;
                                //row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl;
                                //row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                //row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = data.SalesUnPrcTaxExcFl;
                                //row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = data.SalesUnitCost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.SalesMoneyTaxExc;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = data.ConsTaxLayMethod;
                                //row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = data.SalesTotalTaxInc;
                                //row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = data.SalesPriceConsTax;
                                //row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = data.TotalCost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //// 類別番号[0のときは空白]
                                //if (data.CategoryNo == 0)
                                //{
                                //    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = data.CategoryNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                ////row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.FirstEntryDate);
                                //// 年式[NULLのときは空白]
                                //if ( data.FirstEntryDate == DateTime.MinValue )//DBNull.Value)// 
                                //{
                                //    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                //----- ADD K2014/05/08 By 林超凡 テキスト出力項目に車種メーカーコードを追加する BEGIN--------->>>>>
                                row[_dataSet.SalesDetail.MakerCodeColumn.ColumnName] = DBNull.Value;
                                //----- ADD K2014/05/08 By 林超凡 テキスト出力項目に車種メーカーコードを追加する END---------<<<<<

                                // ---- ADD K2015/04/29 陳亮 テキスト出力項目に第二売価追加を追加する ----->>>>>
                                if (this._opt_Momose == Convert.ToInt32(Option.ON))
                                {
                                    row[_dataSet.SalesDetail.SecondSalePriceColumn.ColumnName] = DBNull.Value;
                                }
                                // ---- ADD K2015/04/29 陳亮 テキスト出力項目に第二売価追加を追加する ----<<<<<

                                row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                                row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = DBNull.Value;
                                // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                                // 車台No[NULLのときは空白]
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 DEL
                                //if ( data.SearchFrameNo == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = data.SearchFrameNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                                row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = data.FullModel;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL 
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //// 仕入先コード[NULLのときは空白]
                                //if (data.SupplierCd == 0)
                                //{
                                //    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                                //}
                                //row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                //row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                //row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //// 計上元受注No[NULLのときは空白]
                                //if ( data.AcceptAnOrderNo == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                //}
                                //// 計上元出荷No[NULLのときは空白]
                                //if ( data.ShipmSalesSlipNum == "0" )
                                //{
                                //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = string.Empty;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                //}
                                //// 元黒No[NULLのときは空白]
                                //if ( data.SrcSalesSlipNum == "0" )
                                //{
                                //    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = data.SrcSalesSlipNum;
                                //}
                                //row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = data.SalesOrderDivCd;
                                //row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = data.WarehouseCode;
                                //row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = data.WarehouseName;
                                //// 同時仕入No[NULLのときは空白]
                                //if ( data.SupplierSlipNo == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //// 発注先コード[NULLのときは空白]
                                //if ( data.UOESupplierCd == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.UOESupplierCdColumn] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.UOESupplierCdColumn] = data.UOESupplierCd.ToString().PadLeft( CT_DEPTH_UOESUPPLIERCODE, '0' );
                                //}
                                //row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = data.UOESupplierSnm;
                                //row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = data.UoeRemark1;
                                //row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = data.UoeRemark2;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value;
                                row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = data.DtlNote;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm( data.DtlNote ); // 明細備考←有効期限をセット
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = data.ColorName1;
                                //row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = data.TrimName;
                                //row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = data.StdUnPrcLPrice;
                                //row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = data.StdUnPrcSalUnPrc;
                                //row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = data.StdUnPrcUnCst;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //// メーカーコード[NULLのときは空白]
                                //if (data.GoodsMakerCd == 0)
                                //{
                                //    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd.ToString().PadLeft(CT_DEPTH_GOODSMAKERCODE, '0');
                                //}
                                //row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = data.MakerName;
                                //row[_dataSet.SalesDetail.CostColumn.ColumnName] = data.Cost;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //// 得意先伝票番号[NULLのときは空白]
                                //if ( data.CustSlipNo == 0 )
                                //{
                                //    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //}
                                //else
                                //{
                                //    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                //row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.AddUpADate);
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                if ( data.AddUpADate != DateTime.MinValue )
                                {
                                    row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                                //row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                //if ( data.AccRecDivCd == 1 )
                                //{
                                //    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = "売掛";
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                                row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                                //row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = data.DebitNoteDiv;
                                if ( data.DebitNoteDiv == 0 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "黒";
                                }
                                else if ( data.DebitNoteDiv == 1 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤";
                                }
                                else if ( data.DebitNoteDiv == 2 )
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "相殺済み黒";
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                                row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                                // 入力日
                                if ( data.InputDay != DateTime.MinValue )
                                {
                                    row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                                row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = DBNull.Value;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                                row[_dataSet.SalesDetail.HistoryDivNameColumn.ColumnName] = string.Empty; // 履歴区分
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                                row[_dataSet.SalesDetail.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText( data.UpdateDateTime ); // 伝票発行時刻
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                                // ADD 2012/04/01 gezh Redmine#29250 ----------------------------------------------->>>>>
                                if (data.UpdateDateTimeDetail != 0)
                                {
                                    DateTime dt = new DateTime(data.UpdateDateTimeDetail);
                                    row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // 更新日時
                                }
                                else
                                {
                                    row[_dataSet.SalesDetail.UpdateDateTimeColumn.ColumnName] = string.Empty;
                                }
                                // ADD 2012/04/01 gezh Redmine#29250 -----------------------------------------------<<<<<

                                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                                if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                                {
                                    row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                                    if (data.CustAnalysCode1 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                                    }
                                    if (data.CustAnalysCode2 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                                    }
                                    if (data.CustAnalysCode3 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                                    }
                                    if (data.CustAnalysCode4 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                                    }
                                    if (data.CustAnalysCode5 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                                    }
                                    if (data.CustAnalysCode6 != 0)
                                    {
                                        row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                                    }
                                }
                                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

                                #endregion // 明細・入金データ
                            }

                            // 行追加
                            //this._dataSet.SalesDetail.Rows.Add( row );        //DEL 2009/02/14 不具合対応[11391]
                            // ---ADD 2009/02/14 不具合対応[11391] -------------------------------------------->>>>>
                            if ( data.DataDiv == 0 )
                            {
                                this._dataSet.SalesDetail.Rows.Add( row );
                            }
                            else
                            {
                                // 手数料、値引きの明細データはこの時点では作成しない
                                if ( (data.SalesRowNo != 0) && (string.IsNullOrEmpty( data.GoodsName.TrimEnd() )) == false )
                                {
                                    this._dataSet.SalesDetail.Rows.Add( row );
                                }
                            }
                            // ---ADD 2009/02/14 不具合対応[11391] --------------------------------------------<<<<<

                            #endregion // 明細データテーブル

                            #region 金額データを集計

                            //-------------------------
                            // 金額データを集計
                            //-------------------------
                            //if (data.SalesSlipCd == 0) // 売上
                            //{
                            if ( data.DataDiv == 0 )  // 売上データの場合
                            {
                                // 標準価格合計(標準価格 * 出荷数)
                                StandardPrice_Total += (data.ListPriceTaxExcFl * data.ShipmentCnt);
                                // 売上金額合計
                                // ---------UPD 2010/08/05--------->>>>>
                                // ---------UPD 2010/09/01--------->>>>>
                                SoldAmount_Total += data.SalesMoneyTaxExc;
                                //SoldAmount_Total += (data.SalesUnPrcTaxExcFl * data.ShipmentCnt);
                                // ---------UPD 2010/09/01---------<<<<<
                                // ---------UPD 2010/08/05---------<<<<<
                                // 原価合計
                                //Cost_Total += data.Cost;// DEL 2010/08/31
                                Cost_Total += data.ShipmentCnt * data.SalesUnitCost;// ADD 2010/08/31
                                // 粗利額合計(明細金額 - 原価)
                                GrossProfitAmount_Total += (data.SalesMoneyTaxExc - Double.Parse( data.Cost.ToString() ));
                                //GrossProfitAmount_Total += (data.SalesMoneyTaxExc - data.ShipmentCnt * data.SalesUnitCost);
                                // 消費税（売）
                                totalOfsThisSalesTax += data.SalesPriceConsTax;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 DEL
                                //// 消費税
                                //totalConsumeTaxAmount += data.SalesPriceConsTax;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/20 ADD
                                // 消費税
                                switch ( data.ConsTaxLayMethod )
                                {
                                    // 2010/07/08 Del >>>
                                    //// 明細転嫁
                                    //case 0:
                                    // 2010/07/08 Del <<<
                                    // 2010/07/08 >>>
                                    //// 伝票転嫁
                                    // 明細転嫁
                                    // 2010/07/08 <<<
                                    case 1:
                                        // 加算する
                                        totalConsumeTaxAmount += data.SalesPriceConsTax;
                                        break;
                                    // 2010/07/08 Add >>>
                                    // 伝票転嫁
                                    case 0:
                                        if ( !data.SalesSlipNum.Equals( exSlipNum2 ) ) // 一行目のみ加算
                                        {
                                            totalConsumeTaxAmount += data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                        }
                                        break;
                                    // 2010/07/08 Add <<<
                                    // 請求親
                                    case 2:
                                    // 請求子
                                    case 3:
                                    // 非課税
                                    case 9:
                                    default:
                                        // 加算しない
                                        break;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/20 ADD
                                // 数量計
                                //-----UPD 2010/12/20----- >>>>>
                                if ((data.AcptAnOdrStatus == 30) && (data.SalesSlipCdDtl != 2))
　                              {
                                    totalAmount += data.ShipmentCnt;
                                }
                                //totalAmount += data.ShipmentCnt;
                                //-----UPD 2010/12/20----- <<<<<
                                // 今回売上
                                totalThisSalesPrice += data.SalesMoneyTaxExc;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                // 伝票別内税金額集計
                                if ( data.TaxationDivCd == 2 )
                                {
                                    long consTaxInclu = (long)row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName]
                                                        - (long)row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName];
                                    salAmntConsTaxInclu += consTaxInclu;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                                // 2010/07/08 Add >>>
                                // 保存されている伝票番号を更新
                                if ( !data.SalesSlipNum.Equals( exSlipNum2 ) )
                                {
                                    exSlipNum2 = data.SalesSlipNum;
                                }
                                // 2010/07/08 Add <<<
                            }
                            else // 入金データの場合
                            {
                                //今回入金
                                totalThisTimeDmdNrml += data.SalesMoneyTaxExc;
                            }
                            //}
                            //else // 返品
                            //{
                            //    // 標準価格合計(標準価格 * 出荷数)
                            //    StandardPrice_Total -= (data.ListPriceTaxExcFl * data.ShipmentCnt);
                            //    // 売上金額合計
                            //    SoldAmount_Total -= data.SalesMoneyTaxExc;
                            //    // 原価合計
                            //    Cost_Total -= data.Cost;
                            //    // 粗利額合計(明細金額 - 原価)
                            //    GrossProfitAmount_Total -= (data.ListPriceTaxExcFl - Double.Parse(data.Cost.ToString()));
                            //    // 今回売上/今回入金
                            //    if (data.DataDiv == 0)  // 売上データの場合
                            //    {
                            //        totalThisSalesPrice -= data.SalesMoneyTaxExc;
                            //    }
                            //    else // 入金データの場合
                            //    {
                            //        totalThisTimeDmdNrml -= data.SalesMoneyTaxExc;
                            //    }
                            //    // 消費税（売）
                            //    totalOfsThisSalesTax -= data.SalesPriceConsTax;
                            //    // 消費税
                            //    totalConsumeTaxAmount -= data.SalesPriceConsTax;
                            //    // 数量計
                            //    totalAmount -= data.ShipmentCnt;
                            //}

                            // 明細数
                            detailSlipCount++;

                            #endregion // 金額データを集計

                            #region 伝票表示データテーブル

                            // これは絞り込みを行う
                            // 絞込の条件項目は伝票番号、受注ステータス
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                            //if (!data.SalesSlipNum.Equals(exSlipNum) || data.AcptAnOdrStatus != exAcptAnOdrStatus)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                            if ( index > 0 && (!data.SalesSlipNum.Equals( exSlipNum ) || data.AcptAnOdrStatus != exAcptAnOdrStatus) )
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                                # region // DEL
                                //// 伝票番号および受注スタータスが異なれば別伝票として取得
                                //row2 = _dataSet.SalesList.NewRow();

                                //// 売上伝票なのか入金伝票なのかでデータの構造が異なる
                                //if (data.DataDiv == 0)
                                //{
                                //    #region 売上伝票
                                //    // 売上伝票
                                //    row2[_dataSet.SalesList.SelectionColumn.ColumnName] = false;
                                //    row2[_dataSet.SalesList.RowNoColumn.ColumnName] = rowNo;
                                //    row2[_dataSet.SalesList.DataDivColumn.ColumnName] = data.DataDiv;
                                //    row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = data.SalesDate;
                                //    //row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.SalesDate);
                                //    row2[_dataSet.SalesList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                //    row2[_dataSet.SalesList.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                //    row2[_dataSet.SalesList.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                //    // 伝票区分名判定
                                //    if (data.SalesSlipCd == 0)
                                //    {
                                //        if (data.AcptAnOdrStatus == 20)
                                //        {
                                //            row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "受注";
                                //        }
                                //        else if (data.AcptAnOdrStatus == 30)
                                //        {
                                //            row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "売上";
                                //        }
                                //        else if (data.AcptAnOdrStatus == 40)
                                //        {
                                //            row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "貸出";
                                //        }
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "返品";
                                //    }
                                //    row2[_dataSet.SalesList.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                                //    //row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                //    //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                //    //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = data.SalesTotalTaxExc - data.TotalCost;
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //    //if (data.CategoryNo == 0)
                                //    //{
                                //    //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //    //}
                                //    //else
                                //    //{
                                //    //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = data.CategoryNo;
                                //    //}
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = GetModelDesignationNoAndCategoryNo( data );
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //    row2[_dataSet.SalesList.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                //    if (data.FirstEntryDate == DateTime.MinValue)
                                //    {
                                //        row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                                //    }

                                //    //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.FirstEntryDate);
                                //    row2[_dataSet.SalesList.FullModelColumn.ColumnName] = data.FullModel;
                                //    if (data.SearchFrameNo == 0)
                                //    {
                                //        row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = data.SearchFrameNo;
                                //    }
                                //    row2[_dataSet.SalesList.SlipNoteColumn.ColumnName] = data.SlipNote;
                                //    row2[_dataSet.SalesList.SlipNote2Column.ColumnName] = data.SlipNote2;
                                //    row2[_dataSet.SalesList.SlipNote3Column.ColumnName] = data.SlipNote3;
                                //    row2[_dataSet.SalesList.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                //    row2[_dataSet.SalesList.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //    //row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                //    row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                //    row2[_dataSet.SalesList.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                //    row2[_dataSet.SalesList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                //    row2[_dataSet.SalesList.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                //    if (data.AcceptAnOrderNo == 0)
                                //    {
                                //        row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                //    }
                                //    if (data.ShipmSalesSlipNum == "0")
                                //    {
                                //        row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                //    }
                                //    row2[_dataSet.SalesList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                                //    row2[_dataSet.SalesList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                                //    row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode;
                                //    row2[_dataSet.SalesList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                                //    row2[_dataSet.SalesList.ColorName1Column.ColumnName] = data.ColorName1;
                                //    row2[_dataSet.SalesList.TrimNameColumn.ColumnName] = data.TrimName;
                                //    if (data.CustSlipNo == 0)
                                //    {
                                //        row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                //    }
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //    //row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                //    if ( data.AddUpADate != DateTime.MinValue )
                                //    {
                                //        row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //    //row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.AddUpADate);
                                //    row2[_dataSet.SalesList.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                //    if (data.AccRecDivCd == 1)
                                //    {
                                //        row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "売掛";
                                //    }
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "現金";
                                //    }
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //    //row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = data.DebitNoteDiv;
                                //    if (data.DebitNoteDiv == 0)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "黒伝";
                                //    }
                                //    else if (data.DebitNoteDiv == 1)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "赤伝";
                                //    }
                                //    else if (data.DebitNoteDiv == 2)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "元黒";
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = string.Empty;
                                //    }
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                                //    if ( (long)row[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] < 0 )
                                //    {
                                //        row[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "赤伝";
                                //    }
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                //    # region [消費税関連]
                                //    bool printTax = true;
                                //    Int64 salesTotalTaxInc;
                                //    Int64 salesTotalTaxExc = data.SalesTotalTaxExc;
                                //    Int64 salesPriceConsTax;

                                //    // 印刷する消費税額の取得
                                //    if ( data.ConsTaxLayMethod == 0 ) // 伝票単位
                                //    {
                                //        salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                //    }
                                //    else if ( data.ConsTaxLayMethod == 1 ) // 明細単位
                                //    {
                                //        salesPriceConsTax = data.SalesPriceConsTax;
                                //    }
                                //    else
                                //    {
                                //        salesPriceConsTax = 0;
                                //    }

                                //    // 税込金額の取得
                                //    salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                                //    if ( printTax )
                                //    {
                                //        // 消費税印字有無判定と金額制御
                                //        int totalAmountDispWayCd = data.TotalAmountDispWayCd;

                                //        // 消費税印字有無判定
                                //        printTax = ReflectMoneyForTaxPrintOfSlip( ref salesTotalTaxExc, ref salesPriceConsTax, ref salAmntConsTaxInclu, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod );
                                //        if ( printTax )
                                //        {
                                //            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = salesPriceConsTax;
                                //        }
                                //        else
                                //        {
                                //            // 印字しない
                                //            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        // 印字しない
                                //        row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    // 税抜金額セット
                                //    row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = salesTotalTaxExc;
                                //    // 粗利セット
                                //    row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = salesTotalTaxExc - data.TotalCost;
                                //    # endregion
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                                //    #endregion // 売上伝票
                                //}
                                //else
                                //{
                                //    #region 入金伝票
                                //    // 入金伝票
                                //    // 選択チェックボックスなし
                                //    row2[_dataSet.SalesList.SelectionColumn.ColumnName] = DBNull.Value;
                                //    row2[_dataSet.SalesList.RowNoColumn.ColumnName] = rowNo;
                                //    row2[_dataSet.SalesList.DataDivColumn.ColumnName] = data.DataDiv;
                                //    row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = data.SalesDate;
                                //    row2[_dataSet.SalesList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                //    row2[_dataSet.SalesList.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                //    row2[_dataSet.SalesList.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                //    row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "入金";
                                //    row2[_dataSet.SalesList.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                //    row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                //    //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                                //    //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = data.SalesTotalTaxExc - data.TotalCost;
                                //    //row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = data.CategoryNo;
                                //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //    //row2[_dataSet.SalesList.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                                //    //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                                //    //row2[_dataSet.SalesList.FullModelColumn.ColumnName] = data.FullModel;
                                //    //row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = data.SearchFrameNo;
                                //    row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = DBNull.Value;
                                //    row2[_dataSet.SalesList.SlipNoteColumn.ColumnName] = data.SlipNote;
                                //    //row2[_dataSet.SalesList.SlipNote2Column.ColumnName] = data.SlipNote2;
                                //    //row2[_dataSet.SalesList.SlipNote3Column.ColumnName] = data.SlipNote3;
                                //    //row2[_dataSet.SalesList.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                //    row2[_dataSet.SalesList.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                                //    //row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                                //    row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                                //    row2[_dataSet.SalesList.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                //    //row2[_dataSet.SalesList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                //    //row2[_dataSet.SalesList.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                                //    //row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                //    row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //    //row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                                //    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                                //    //row2[_dataSet.SalesList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                                //    //row2[_dataSet.SalesList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                                //    row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode;
                                //    row2[_dataSet.SalesList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                                //    //row2[_dataSet.SalesList.ColorName1Column.ColumnName] = data.ColorName1;
                                //    //row2[_dataSet.SalesList.TrimNameColumn.ColumnName] = data.TrimName;
                                //    //row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                                //    row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                                //    if ( data.AddUpADate != DateTime.MinValue )
                                //    {
                                //        row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                                //    //if (data.AccRecDivCd == 1)
                                //    //{
                                //    //    row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "売掛";
                                //    //}
                                //    //row2[_dataSet.SalesList.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                                //    if (data.DebitNoteDiv == 0)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "黒";
                                //    }
                                //    else if (data.DebitNoteDiv == 1)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "赤";
                                //    }
                                //    else if (data.DebitNoteDiv == 2)
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "相殺済黒";
                                //    }
                                //    else
                                //    {
                                //        row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = string.Empty;
                                //    }
                                //    #endregion // 入金伝票
                                //}

                                //// 行追加
                                //this._dataSet.SalesList.Rows.Add(row2);
                                # endregion
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                # region // DEL
                                //// ---ADD 2009/02/14 不具合対応[11391] ----------------------------------------------------->>>>>
                                //rowDetailNo = rowNo;
                                //if (data.DataDiv != 0)
                                //{
                                //    // 手数料明細追加
                                //    if (data.FeeDeposit > 0)
                                //    {
                                //        rowDetailNo++;
                                //        row = this._dataSet.SalesDetail.NewRow();
                                //        #region 手数料用明細作成
                                //        row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowDetailNo;
                                //        row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                //        row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                //        row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                //        row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = 98;
                                //        row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                //        row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                //        row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                //        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "入金";
                                //        row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                //        row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = "手数料";
                                //        row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                //        if (data.BLGoodsCode == 0)
                                //        {
                                //            row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                //        }
                                //        row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                //        row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.FeeDeposit;
                                //        row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                //        row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                //        row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                //        row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                //        row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                //        row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                //        row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                //        row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                //        row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                //        row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                //        row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm(data.DtlNote); // 明細備考←有効期限をセット
                                //        row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //        if (data.AddUpADate != DateTime.MinValue)
                                //        {
                                //            row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                //        }
                                //        row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                                //        if (data.DebitNoteDiv == 0)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "黒";
                                //        }
                                //        else if (data.DebitNoteDiv == 1)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤";
                                //        }
                                //        else if (data.DebitNoteDiv == 2)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "相殺済み黒";
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                //        }
                                //        row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                                //        #endregion
                                //        this._dataSet.SalesDetail.Rows.Add(row);
                                //    }

                                //    if (data.DiscountDeposit > 0)
                                //    {
                                //        rowDetailNo++;
                                //        row = this._dataSet.SalesDetail.NewRow();
                                //        #region 手数料用明細作成
                                //        row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowDetailNo;
                                //        row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                //        row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                //        row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                //        row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = 98;
                                //        row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                                //        row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                                //        row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                                //        row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "入金";
                                //        row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                                //        row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = "値引";
                                //        row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                //        if (data.BLGoodsCode == 0)
                                //        {
                                //            row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                //        }
                                //        row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                                //        row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.DiscountDeposit;
                                //        row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                                //        row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                                //        row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                                //        row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                                //        row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                                //        row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                //        row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                                //        row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                                //        row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                //        row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                                //        row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm(data.DtlNote); // 明細備考←有効期限をセット
                                //        row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                                //        if (data.AddUpADate != DateTime.MinValue)
                                //        {
                                //            row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                                //        }
                                //        row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                                //        if (data.DebitNoteDiv == 0)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "黒";
                                //        }
                                //        else if (data.DebitNoteDiv == 1)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤";
                                //        }
                                //        else if (data.DebitNoteDiv == 2)
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "相殺済み黒";
                                //        }
                                //        else
                                //        {
                                //            row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                //        }
                                //        row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                                //        row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                                //        #endregion
                                //        this._dataSet.SalesDetail.Rows.Add(row);
                                //    }
                                //}
                                //// ---ADD 2009/02/14 不具合対応[11391] -----------------------------------------------------<<<<<
                                # endregion
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                // 伝票表示グリッドへのセット
                                CustPrtPprSalTblRsltWork prevData = (CustPrtPprSalTblRsltWork)((custPrtPprSalTblRsltWorkObj as ArrayList)[index - 1]);
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._dataSet.SalesDetail;
                                rowDetailNo = rowNo;
                                AddFeeAndDiscountRow( ref table, ref rowDetailNo, prevData );
                                rowNo = rowDetailNo;
                                //-----ADD 2010/12/20 ----->>>>>
                                prevData.AcptAnOdrStatusSrc = beAcptAnOdrStatusSrc;
                                prevData.HisDtlSlipNum = beHisDtlSlipNum;
                                //-----ADD 2010/12/20 -----<<<<<
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                //RecordSetToSlipList(prevData, rowNo, salAmntConsTaxInclu, yeardiv);// 陳建明 2011/11/23 ADD // DEL 2015/02/05 王亜楠
                                //RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu );// 陳建明 2011/11/23 DEL
                                RecordSetToSlipList(prevData, rowNo, salAmntConsTaxInclu, yeardiv, 0);// ADD 2015/02/05 王亜楠
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                                //-----ADD 2010/12/20 ----->>>>>
                                beAcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
                                beHisDtlSlipNum = data.HisDtlSlipNum;
                                //-----ADD 2010/12/20 -----<<<<<

                                rowNo = rowDetailNo;        //ADD 2009/02/14 不具合対応[11391]

                                // 伝票枚数+1
                                slipCount++;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                                //// 伝票番号および受注ステータスを保存
                                //exAcptAnOdrStatus = data.AcptAnOdrStatus;
                                //exSlipNum = data.SalesSlipNum;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                salAmntConsTaxInclu = 0; // 伝票別内税金額集計値を初期化
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 ADD
                                if ( _extractCancelFlag == true )
                                {
                                    // --- DEL 2020/12/21 警告対応 ---------->>>>>
                                    //cancelFlag = true;
                                    // --- DEL 2020/12/21 警告対応 ----------<<<<<

                                    exAcptAnOdrStatus = data.AcptAnOdrStatus;
                                    exSlipNum = data.SalesSlipNum;
                                    rowNo++;

                                    break;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 ADD

                            }
                            //-----ADD 2010/12/20 ----->>>>>
                            if (index == 0)
                            {                                 
                                beAcptAnOdrStatusSrc = data.AcptAnOdrStatusSrc;
                                beHisDtlSlipNum = data.HisDtlSlipNum;
                                
                            }
                            //-----ADD 2010/12/20 -----<<<<<
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                            // 伝票番号および受注ステータスを保存
                            exAcptAnOdrStatus = data.AcptAnOdrStatus;
                            exSlipNum = data.SalesSlipNum;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                            #endregion // 伝票表示データテーブル

                            rowNo++;
                        }
                        // --- UPD 2020/12/21 警告対応 ---------->>>>>
                        //catch ( ConstraintException ex )
                        catch (ConstraintException)
                        // --- UPD 2020/12/21 警告対応 ----------<<<<<
                        {
                            //MessageBox.Show(ex.Message);
                        }
                    }
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/07 UPD
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                    //// 最後の伝票情報をセット
                    //if ( custPrtPprSalTblRsltWorkObj != null && (custPrtPprSalTblRsltWorkObj as ArrayList).Count > 0 )
                    //{
                    //    ArrayList retList = (ArrayList)custPrtPprSalTblRsltWorkObj;
                    //    CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)retList[retList.Count - 1];

                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    //    CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._dataSet.SalesDetail;
                    //    rowDetailNo = rowNo;
                    //    AddFeeAndDiscountRow( ref table, ref rowDetailNo, data );
                    //    rowNo = rowDetailNo;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                    //    // 伝票表示グリッドへのセット
                    //    RecordSetToSlipList( data, rowNo, salAmntConsTaxInclu );
                    //    // 伝票枚数+1
                    //    slipCount++;
                    //}
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                    // 最後の伝票情報をセット
                    if ( custPrtPprSalTblRsltWorkObj != null && (custPrtPprSalTblRsltWorkObj as ArrayList).Count > 0 )
                    {
                        ArrayList retList = (ArrayList)custPrtPprSalTblRsltWorkObj;
                        CustPrtPprSalTblRsltWork data = (CustPrtPprSalTblRsltWork)retList[lastIndex];

                        CustPtrSalesDetailDataSet.SalesDetailDataTable table = this._dataSet.SalesDetail;
                        rowDetailNo = rowNo;
                        AddFeeAndDiscountRow( ref table, ref rowDetailNo, data );
                        rowNo = rowDetailNo;
                        //-----ADD 2010/12/20 ----->>>>>
                        data.AcptAnOdrStatusSrc = beAcptAnOdrStatusSrc;
                        data.HisDtlSlipNum = beHisDtlSlipNum;
                        //-----ADD 2010/12/20 -----<<<<<
                        // 伝票表示グリッドへのセット
                        //RecordSetToSlipList(data, rowNo, salAmntConsTaxInclu, yeardiv);// 陳建明 2011/11/23 ADD // DEL 2015/02/05 王亜楠
                        //RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu );// 陳建明 2011/11/23 DEL
                        RecordSetToSlipList(data, rowNo, salAmntConsTaxInclu, yeardiv, 0);// ADD 2015/02/05 王亜楠
                        // 伝票枚数+1
                        slipCount++;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/07 UPD


                    // ---ADD 2009/02/14 不具合対応[11381] ------------------------------------------------>>>>>
                    // 入金のみ行番号採番しなおす
                    DateTime exSalesDate = DateTime.MinValue;
                    rowDetailNo = 1;
                    exSlipNum = string.Empty;

                    string filter = string.Format( "{0} <> {1}", this._dataSet.SalesDetail.DataDivColumn.ColumnName, 0 );
                    string sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                        //this._dataSet.SalesDetail.SalesDateColumn.ColumnName,
                        //this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName,
                        //this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName,
                        //this._dataSet.SalesDetail.DataDivColumn.ColumnName,
                        //this._dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName,
                        //this._dataSet.SalesDetail.SalesSlipCdColumn.ColumnName);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                    this._dataSet.SalesDetail.SalesDateColumn.ColumnName,
                                    this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName,
                                    this._dataSet.SalesDetail.DataDivColumn.ColumnName,
                                    this._dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName,
                                    this._dataSet.SalesDetail.SalesSlipCdColumn.ColumnName,
                                    this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

                    DataRow[] dataRows = this._dataSet.SalesDetail.Select( filter, sort );
                    DataRow dataRow = null;
                    for ( int i = 0; i <= dataRows.Length - 1; i++ )
                    {
                        dataRow = dataRows[i];

                        if ( (exSalesDate.Equals( dataRow[this._dataSet.SalesDetail.SalesDateColumn.ColumnName] ) == false) ||
                            (exSlipNum.Equals( dataRow[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] ) == false) )
                        {
                            rowDetailNo = 1;
                        }

                        dataRow[this._dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = rowDetailNo++;

                        exSalesDate = (DateTime)dataRow[this._dataSet.SalesDetail.SalesDateColumn.ColumnName];
                        exSlipNum = (string)dataRow[this._dataSet.SalesDetail.SalesSlipNumColumn.ColumnName];
                    }
                    // ---ADD 2009/02/14 不具合対応[11381] ------------------------------------------------<<<<<

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    # region // DEL
                    //// 残高表示をデータセットへ
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 DEL
                    ////if ( this._dataSet.BalanceTotal.Rows.Count > 0 )
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 DEL
                    //{
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 DEL
                    //    //row3 = this._dataSet.BalanceTotal.Rows[0];
                    //    //row3[_dataSet.BalanceTotal.AfCalBlcColumn.ColumnName] = AfCalDemandPrice + totalThisSalesPrice + totalOfsThisSalesTax - totalThisTimeDmdNrml;
                    //    //row3[_dataSet.BalanceTotal.ThisSalesPriceTotalColumn.ColumnName] = totalThisSalesPrice;                     // 今回売上
                    //    //row3[_dataSet.BalanceTotal.OfsThisSalesTaxColumn.ColumnName] = totalOfsThisSalesTax;                        // 消費税
                    //    //row3[_dataSet.BalanceTotal.ThisTimeDmdNrmlColumn.ColumnName] = totalThisTimeDmdNrml;                        // 今回入金
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 DEL
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
                    //    if ( this._dataSet.BalanceTotal.Rows.Count > 0 )
                    //    {
                    //        row3 = this._dataSet.BalanceTotal.Rows[0];
                    //    }
                    //    else
                    //    {
                    //        // 無ければ行追加する（参照型なので行追加後に編集しても反映される）
                    //        row3 = this._dataSet.BalanceTotal.NewRow();
                    //        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = false;
                    //        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = DateTime.MinValue;
                    //        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = DateTime.MinValue;
                    //        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = false;
                    //        this._dataSet.BalanceTotal.Rows.Add( row3 );
                    //    }
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

                    //    row3[_dataSet.BalanceTotal.StandardPrice_TotalColumn.ColumnName] = StandardPrice_Total;                     // 標準価格合計
                    //    row3[_dataSet.BalanceTotal.SoldAmount_TotalColumn.ColumnName] = SoldAmount_Total;                           // 売上金額合計
                    //    row3[_dataSet.BalanceTotal.Cost_TotalColumn.ColumnName] = Cost_Total;                                       // 原価合計
                    //    row3[_dataSet.BalanceTotal.GrossProfitAmount_TotalColumn.ColumnName] = GrossProfitAmount_Total;             // 粗利額合計

                    //    if ( totalAmount > 0 )
                    //    {
                    //        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = StandardPrice_Total / totalAmount;         // 標準価格平均
                    //        row3[_dataSet.BalanceTotal.SoldAmount_AvgColumn.ColumnName] = SoldAmount_Total / totalAmount;               // 売上金額平均
                    //        row3[_dataSet.BalanceTotal.Cost_AvgColumn.ColumnName] = Cost_Total / totalAmount;                           // 原価平均
                    //        row3[_dataSet.BalanceTotal.GrossProfitAmount_AvgColumn.ColumnName] = GrossProfitAmount_Total / totalAmount; // 粗利額平均
                    //    }
                    //    else
                    //    {
                    //        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = 0;
                    //        row3[_dataSet.BalanceTotal.SoldAmount_AvgColumn.ColumnName] = 0;
                    //        row3[_dataSet.BalanceTotal.Cost_AvgColumn.ColumnName] = 0;
                    //        row3[_dataSet.BalanceTotal.GrossProfitAmount_AvgColumn.ColumnName] = 0;
                    //    }

                    //    if ( SoldAmount_Total > 0 )
                    //    {
                    //        row3[_dataSet.BalanceTotal.GrossProfitPercentageColumn.ColumnName] = GrossProfitAmount_Total / SoldAmount_Total * 100; // 粗利率
                    //    }
                    //    else
                    //    {
                    //        row3[_dataSet.BalanceTotal.GrossProfitPercentageColumn.ColumnName] = 0;
                    //    }
                    //    row3[_dataSet.BalanceTotal.SlipCountColumn.ColumnName] = slipCount;                                         // 伝票枚数
                    //    row3[_dataSet.BalanceTotal.DetailCountColumn.ColumnName] = detailSlipCount;                                 // 明細数
                    //    row3[_dataSet.BalanceTotal.AmountColumn.ColumnName] = totalAmount;                                          // 数量計
                    //    row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount;                      // 消費税計
                    //    //row3[_dataSet.BalanceList.SectionCodeColumn.ColumnName] = 
                    //}
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                    // 得意先未入力のときstatus=EOFで返却されるので明細該当データがあればnormalで返す
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                else
                {
                    // 件数ゼロならばリモートstatus＝0:正常でも該当なしで返す
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                # region [残高表示]
                // 残高表示をデータセットへ
                {
                    if ( this._dataSet.BalanceTotal.Rows.Count > 0 )
                    {
                        row3 = this._dataSet.BalanceTotal.Rows[0];
                    }
                    else
                    {
                        // 無ければ行追加する（参照型なので行追加後に編集しても反映される）
                        row3 = this._dataSet.BalanceTotal.NewRow();
                        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = false;
                        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = DateTime.MinValue;
                        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = DateTime.MinValue;
                        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = false;
                        this._dataSet.BalanceTotal.Rows.Add( row3 );
                    }

                    row3[_dataSet.BalanceTotal.StandardPrice_TotalColumn.ColumnName] = StandardPrice_Total;                     // 標準価格合計
                    row3[_dataSet.BalanceTotal.SoldAmount_TotalColumn.ColumnName] = SoldAmount_Total;                           // 売上金額合計
                    row3[_dataSet.BalanceTotal.Cost_TotalColumn.ColumnName] = Cost_Total;                                       // 原価合計
                    row3[_dataSet.BalanceTotal.GrossProfitAmount_TotalColumn.ColumnName] = GrossProfitAmount_Total;             // 粗利額合計

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //if ( totalAmount > 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    if ( totalAmount != 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    {
                        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = StandardPrice_Total / totalAmount;         // 標準価格平均
                        row3[_dataSet.BalanceTotal.SoldAmount_AvgColumn.ColumnName] = SoldAmount_Total / totalAmount;               // 売上金額平均
                        row3[_dataSet.BalanceTotal.Cost_AvgColumn.ColumnName] = Cost_Total / totalAmount;                           // 原価平均
                        row3[_dataSet.BalanceTotal.GrossProfitAmount_AvgColumn.ColumnName] = GrossProfitAmount_Total / totalAmount; // 粗利額平均
                    }
                    else
                    {
                        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = 0;
                        row3[_dataSet.BalanceTotal.SoldAmount_AvgColumn.ColumnName] = 0;
                        row3[_dataSet.BalanceTotal.Cost_AvgColumn.ColumnName] = 0;
                        row3[_dataSet.BalanceTotal.GrossProfitAmount_AvgColumn.ColumnName] = 0;
                    }

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //if ( SoldAmount_Total > 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    if ( SoldAmount_Total != 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    {
                        row3[_dataSet.BalanceTotal.GrossProfitPercentageColumn.ColumnName] = GrossProfitAmount_Total / SoldAmount_Total * 100; // 粗利率
                    }
                    else
                    {
                        row3[_dataSet.BalanceTotal.GrossProfitPercentageColumn.ColumnName] = 0;
                    }
                    row3[_dataSet.BalanceTotal.SlipCountColumn.ColumnName] = slipCount;                                         // 伝票枚数
                    row3[_dataSet.BalanceTotal.DetailCountColumn.ColumnName] = detailSlipCount;                                 // 明細数
                    row3[_dataSet.BalanceTotal.AmountColumn.ColumnName] = totalAmount;                                          // 数量計
                    row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount;                      // 消費税計
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
            }

            return status;
        }

        // ---- ADD K2015/06/09 陳亮 テキスト出力項目に第二売価追加を追加する---->>>>>
        /// <summary>
        /// 第二売価取得
        /// </summary>
        /// <param name="data">明細データ</param>
        /// <returns>第二売価</returns>
        private double GetSecondPrice(CustPrtPprSalTblRsltWork data)
        {
            double secondPrice = 0;
            // 「.」場合のフラグ
            bool isRate = false;
            double resultPrice = 0;

            bool isValid = CustPrtSlipSearchAcs.CheckSecondPrice(data.ListPriceTaxExcFl.ToString(), data.DtlNote, ref secondPrice, ref isRate);

            if (isValid)
            {
                if (isRate)
                {
                    // 端数処理コード(0:売上金額, 1:消費税, 2:売上単価)
                    int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(LoginInfoAcquisition.EnterpriseCode, data.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);

                    // 消費税端数処理単位、区分取得
                    int taxFracProcCd = 0;
                    double taxFracProcUnit = 0;

                    // 端数処理単位、端数処理区分取得処理
                    this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_SalesUnitPrice, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

                    // 端数処理
                    FractionCalculate.FracCalcMoney(secondPrice, taxFracProcUnit, taxFracProcCd, out resultPrice);

                    // 桁数＞7の場合、無効
                    if (resultPrice > 9999999)
                    {
                        secondPrice = data.ListPriceTaxExcFl;
                    }
                    else
                    {
                        secondPrice = resultPrice;
                    }
                }
            }
            else
            {
                secondPrice = data.ListPriceTaxExcFl;
            }

            return secondPrice;
        }
        // ---- ADD K2015/06/09 陳亮 テキスト出力項目に第二売価追加を追加する----<<<<<

        // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加 ---->>>>>
        /// <summary>
        /// 売上金額処理設定
        /// </summary>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        private void InitSalesProcMoney()
        {
            _salesProcMoneyAcs = new SalesProcMoneyAcs();
            CacheSalesProcMoney();
        }

        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
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
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // ソート（上限金額（昇順））
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // 戻り値設定
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// 仕入金額処理区分マスタ比較クラス(上限金額(昇順))
        /// </summary>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        private class StockProcMoneyComparer : Comparer<StockProcMoney>
        {
            public override int Compare(StockProcMoney x, StockProcMoney y)
            {
                int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// 売上金額処理区分設定マスタキャッシュ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        /// </remarks>
        private void CacheSalesProcMoney()
        {
            _salesProcMoneyList = null;
            ArrayList al = null;
            int status = this._salesProcMoneyAcs.Search(out al, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (al != null)
                {
                    _salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])al.ToArray(typeof(SalesProcMoney)));
                }
            }
        }
        // ---- ADD K2015/04/27 陳亮 モモセ部品の第二売価追加 ----<<<<<

        #region チェック明細備考
        /// <summary>
        /// モモセ部品の第二売価追加
        /// チェック明細備考の方法
        /// </summary>
        /// <param name="standardPrice">標準価格</param>
        /// <param name="strNote">明細備考</param>
        /// <param name="number">第二売価値</param>
        /// <param name="isRate">「.」場合のチェック true:「.」場合 false:「.」場合なし</param>
        /// <returns>有効数字のチェック true:有効 false:無効</returns>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/04/29</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        /// </remarks>
        public static bool CheckSecondPrice(string standardPrice, string strNote, ref double number,ref bool isRate)
        {
            //第一Unicode文字
            string firstChar = string.Empty;
            bool isNumber = false;
            int stdPrice;

            number = 0;
            if (!int.TryParse(standardPrice, out stdPrice))
            {
                return isNumber;
            }

            if (!string.IsNullOrEmpty(strNote))
            {
                // 第一Unicode文字を取得する
                firstChar = strNote.Substring(0, 1);

                switch (firstChar)
                {
                    case "\\":
                    case "/":
                        {
                            // 浮動小数点型と整数のチェック
                            isNumber = CheckRateAndNumber(standardPrice, strNote, ref number,ref isRate);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            return isNumber;
        }

        /// <summary>
        /// 浮動小数点型と整数のチェック
        /// </summary>
        /// <param name="standardPrice">標準価格</param>
        /// <param name="strNote">明細備考</param>
        /// <param name="number">第二売価値</param>
        /// <param name="isRate">「.」場合のチェック true:「.」場合 false:「.」場合なし</param>
        /// <returns>有効判断 true:有効 false:無効</returns>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        /// </remarks>
        static bool CheckRateAndNumber(string standardPrice, string strNote, ref double number,ref bool isRate)
        {
            // 第二Unicode文字
            string secondChar = string.Empty;
            // 有効数字のチェック true:有効 false:無効
            bool isNumber = false;
            string tempNote = string.Empty;
            string tempPrice = string.Empty;

            number = 0;

            //// 半角のスペースの前に、文字を取得する
            //// 例え、
            //// ①\14250 在庫  => \14250
            //// ②\14250 在庫  => /14250
            tempNote = strNote.Split(CHAR_SPACE)[0].ToString();

            //// 「\」と「/」は切り捨てる
            //// 例え、
            //// ①\14250  => 14250
            //// ②/14250  => 14250
            //// ③\1.20　 => 1.20
            //// ④/1.20   => 1.20
            //// ⑤/-14250 => -14250
            tempPrice = tempNote.Remove(0, 1);

            // 「.」の場合
            if (tempNote.Contains(STR_DOT))
            {
                isRate = true;
                isNumber = CheckDot(tempPrice, standardPrice, ref number);
            }
            else// 整数の場合
            {
                isRate = false;

                // 金額(\)、桁数以内、カンマ位置不正
                // ,123456,7 = 1234567
                tempPrice = tempPrice.Replace(",", "");
                isNumber = CheckIntNumber(tempPrice, standardPrice, ref number);
            }

            return isNumber;
        }

        /// <summary>
        /// チェゥク「.」の場合
        /// </summary>
        /// <param name="stdPrice">数字</param>
        /// <param name="standardPrice">標準価格</param>
        /// <param name="number">第二売価値</param>
        /// <returns>有効判断 true:有効 false:無効</returns>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        /// </remarks>
        static bool CheckDot(string scdPrice, string standardPrice, ref double number)
        {
            bool isNumber = false;
            //浮動小数点型
            double dblNumber = 0.0;
            bool isPersent = false;

            number = 0;

            //「\.」の場合、無効
            if (scdPrice.Length == 1)
            {
                return isNumber;
            }

            //二つ「.」以上の場合、無効
            if (scdPrice.Split(CHAR_DOT).Length == 2)
            {
                // 数字フォーマットを処理するとチェック
                isPersent = IsValidRateNumber(ref scdPrice,ref dblNumber);

                if (isPersent)
                {
                    // 数字のチェック
                    isNumber = CheckNumber(standardPrice, dblNumber, isPersent, ref number);
                }
                else
                {
                    // 無効
                    return isNumber;
                }
            }
            else
            {
                // 無効
                return isNumber;
            }
            return isNumber;
        }

        /// <summary>
        /// 整数場合の処理
        /// </summary>
        /// <param name="stdPrice">数字</param>
        /// <param name="standardPrice">標準価格</param>
        /// <param name="number">第二売価値</param>
        /// <returns>有効判断 true:有効 false:無効</returns>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        /// </remarks>
        static bool CheckIntNumber(string scdPrice, string standardPrice, ref double number)
        {
            bool isNumber = false;
            double dblNumber = 0;
            bool isPersent = false;

            // ①売価の前に「+」入力、②第二売価は0埋めの場合
            // ①\+123 => +
            // ②\0123 => 0 
            string secondChar = string.Empty;

            number = 0;

            if (double.TryParse(scdPrice, out dblNumber))
            {
                secondChar = scdPrice.Substring(0, 1);

                // 第二売価は0埋めの場合
                // 例え、
                // \0123 =>無効
                if (dblNumber > 0)
                {
                    if (secondChar.Equals("0"))
                    {
                        return isNumber;
                    }
                }

                // 売価の前に「+」入力
                // 例え、
                // \+123 => + (無効)
                if (secondChar.Equals(STR_PURASU))
                {
                    isNumber = false;
                }
                else
                {
                    // 数字<0の場合、無効
                    if (dblNumber < 0)
                    {
                        return isNumber;
                    }

                    // 数字のチェック
                    isNumber = CheckNumber(standardPrice, dblNumber, isPersent, ref number);
                }
            }

            return isNumber;
        }

        /// <summary>
        /// ドット数字のチェック
        /// </summary>
        /// <param name="secondPrice">最初の文字</param>
        /// <returns>有効判断 true:有効 false:無効</returns>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        /// </remarks>
        static bool IsValidRateNumber(ref string secondPrice, ref double dblNumber)
        {
            string secondChar = string.Empty;
            char lastChar = secondPrice[secondPrice.Length - 1];
            bool isValit = false;
            secondChar = secondPrice.Substring(0, 1);
            // 最後Unicode文字は.の場合
            // 例え、
            // ①1. => 無効
            // ②+1.0 => 無効
            if (lastChar.ToString().Equals(STR_DOT) || secondChar.Equals(STR_PURASU))
            {
                return isValit;
            }
            else// 有効の場合
            {
                // 第二Unicode文字は.の場合、フォーマットを修正する
                // 例え、
                // ①.250 => 0.250
                if (secondChar.Equals(STR_DOT))
                {
                    secondPrice = "0" + secondPrice;
                }

                if (double.TryParse(secondPrice, out dblNumber))
                {
                    isValit = true;
                }
                else
                {
                    isValit = false;
                }
            }

            return isValit;
        }

        /// <summary>
        /// 数字のチェック
        /// </summary>
        /// <param name="standardPrice">標準価格</param>
        /// <param name="dblNumber">数字</param>
        /// <param name="isPersent">浮動小数点型の判断</param>
        /// <param name="number">第二売価値</param>
        /// <returns>有効判断 true:有効 false:無効</returns>
        /// <remarks>
        /// <br>Note		: 得意先電子元帳第二売価を追加する。</br>
        /// <br>Programmer	: 陳亮</br>
        /// <br>Date		: K2015/05/07</br>
        /// <br>管理番号    : 11100842-00 モモセ部品㈱の個別開発依頼</br>
        /// </remarks>
        static bool CheckNumber(string standardPrice, double dblNumber, bool isPersent, ref double number)
        {
            // 第二売価
            double secondPrice = 0;
            // 最小の売価率
            // 第二売価率は0の場合、0%　として印字しています
            double minPercent = 0.00;
            // 最大の売価率
            double maxPercent = 9.99;
            // 標準価格
            double stdPrice;
            // 有効数字のチェック true:有効 false:無効
            bool isNumber = false;

            number = 0;
            //　点「.」の場合
            if (isPersent)
            {
                // 最小の売価率から最大の売価率まで、有効
                if (dblNumber >= minPercent && dblNumber <= maxPercent)
                {
                    double.TryParse(standardPrice, out stdPrice);
                    // 浮動小数点型の小数部分は切り捨てる
                    // 0.996 => 0.99
                    dblNumber = Math.Truncate(dblNumber * 100) / 100;

                    secondPrice = stdPrice * dblNumber;
                    if (double.TryParse(secondPrice.ToString(), out number))
                    {
                        isNumber = true;
                    }
                    else
                    {
                        number = 0;
                        isNumber = false;
                    }
                }
            }
            else//整数の場合
            {
                // 桁数＞7の場合、無効
                if (dblNumber <= 9999999)
                {
                    secondPrice = int.Parse(dblNumber.ToString());
                    number = secondPrice;
                    isNumber = true;
                }
            }

            return isNumber;
        }
        #endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
        /// <summary>
        /// 履歴区分名称取得
        /// </summary>
        /// <param name="historyDiv"></param>
        /// <returns></returns>
        private string GetHistoryDivName( int historyDiv )
        {
            switch ( historyDiv )
            {
                default:
                case 0:
                    return string.Empty;
                case 1:
                    return "履歴";
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
        /// <summary>
        /// 伝票発行時刻取得
        /// </summary>
        /// <param name="updateDateTime"></param>
        /// <returns></returns>
        private string GetSlipPrintTimeText( long updateDateTime )
        {
            if ( updateDateTime != 0 )
            {
                DateTime dt = new DateTime( updateDateTime );
                return dt.ToString( "HH:mm:ss" );
            }
            else
            {
                return string.Empty;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rowDetailNo"></param>
        /// <param name="data"></param>
        /// <br>Update Note : K2015/06/16 鮑晶</br>
        /// <br>管理番号    : 11101427-00</br>
        /// <br>            : メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        private void AddFeeAndDiscountRow( ref CustPtrSalesDetailDataSet.SalesDetailDataTable table, ref int rowDetailNo, CustPrtPprSalTblRsltWork data )
        {
            DataRow row;

            // ---ADD 2009/02/14 不具合対応[11391] ----------------------------------------------------->>>>>
            //rowDetailNo = rowNo;
            if ( data.DataDiv != 0 )
            {
                // 手数料明細追加
                // ---------- UPD 2012/12/14 Y.Wakita ---------->>>>>
                //if (data.FeeDeposit > 0)
                if (data.FeeDeposit != 0)
                // ---------- UPD 2012/12/14 Y.Wakita ----------<<<<<
                {
                    rowDetailNo++;
                    //row = this._dataSet.SalesDetail.NewRow();
                    row = table.NewRow();
                    #region 手数料用明細作成
                    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowDetailNo;
                    row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                    row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                    row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                    row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = 98;
                    row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                    row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                    row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                    row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "入金";
                    row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                    row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = "手数料";
                    row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                    row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; //ADD 陳永康 2014/12/28 変換後品番の追加対応
                    if ( data.BLGoodsCode == 0 )
                    {
                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft( CT_DEPTH_BLGOODSCODE, '0' );
                    }
                    row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                    row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.FeeDeposit;
                    row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                    row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                    // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                    row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = DBNull.Value;
                    // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                    row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                    row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                    row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                    row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                    row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                    row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                    //row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value; // DEL 2015/02/05 王亜楠
                    row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = DBNull.Value; // ADD 2015/02/05 王亜楠 // .ColumnNameの追加
                    row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                    row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                    row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                    row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm( data.DtlNote ); // 明細備考←有効期限をセット
                    row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                    if ( data.AddUpADate != DateTime.MinValue )
                    {
                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                    }
                    row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                    if ( data.DebitNoteDiv == 0 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "黒";
                    }
                    else if ( data.DebitNoteDiv == 1 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤";
                    }
                    else if ( data.DebitNoteDiv == 2 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "相殺済み黒";
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                    }
                    row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/18 ADD
                    // 入力日
                    if ( data.InputDay != DateTime.MinValue )
                    {
                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/18 ADD

                    //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                    if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                    {
                        row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                        if (data.CustAnalysCode1 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                        }
                        if (data.CustAnalysCode2 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                        }
                        if (data.CustAnalysCode3 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                        }
                        if (data.CustAnalysCode4 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                        }
                        if (data.CustAnalysCode5 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                        }
                        if (data.CustAnalysCode6 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                        }
                    }
                    //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

                    #endregion
                    //this._dataSet.SalesDetail.Rows.Add( row );
                    table.Rows.Add( row );
                }

                // ---------- UPD 2012/12/14 Y.Wakita ---------->>>>>
                //if ( data.DiscountDeposit > 0 )
                if (data.DiscountDeposit != 0)
                // ---------- UPD 2012/12/14 Y.Wakita ----------<<<<<
                {
                    rowDetailNo++;
                    //row = this._dataSet.SalesDetail.NewRow();
                    row = table.NewRow();
                    #region 値引用明細作成
                    row[_dataSet.SalesDetail.SelectionCheckColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.RowNoColumn.ColumnName] = rowDetailNo;
                    row[_dataSet.SalesDetail.DataDivColumn.ColumnName] = data.DataDiv;
                    row[_dataSet.SalesDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                    row[_dataSet.SalesDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                    row[_dataSet.SalesDetail.SalesRowNoColumn.ColumnName] = 98;
                    row[_dataSet.SalesDetail.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                    row[_dataSet.SalesDetail.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                    row[_dataSet.SalesDetail.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                    row[_dataSet.SalesDetail.SalesSlipCdNameColumn.ColumnName] = "入金";
                    row[_dataSet.SalesDetail.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                    row[_dataSet.SalesDetail.GoodsNameColumn.ColumnName] = "値引";
                    row[_dataSet.SalesDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                    row[_dataSet.SalesDetail.ChangeGoodsNoColumn.ColumnName] = data.ChangeGoodsNo; //ADD 陳永康 2014/12/28 変換後品番の追加対応
                    if ( data.BLGoodsCode == 0 )
                    {
                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = DBNull.Value;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft( CT_DEPTH_BLGOODSCODE, '0' );
                    }
                    row[_dataSet.SalesDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode;
                    row[_dataSet.SalesDetail.ShipmentCntColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesUnPrcTaxExcFlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesUnitCostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesMoneyTaxExcColumn.ColumnName] = data.DiscountDeposit;
                    row[_dataSet.SalesDetail.ConsTaxLayMethodColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesTotalTaxIncColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesPriceConsTaxColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                    row[_dataSet.SalesDetail.TotalCostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CategoryNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ModelFullNameColumn.ColumnName] = DBNull.Value;
                    // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                    row[_dataSet.SalesDetail.ModelHalfNameColumn.ColumnName] = DBNull.Value;
                    // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                    row[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.FrameNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.FullModelColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SlipNoteColumn.ColumnName] = data.SlipNote;
                    row[_dataSet.SalesDetail.SlipNote2Column.ColumnName] = data.SlipNote2;
                    row[_dataSet.SalesDetail.SlipNote3Column.ColumnName] = data.SlipNote3;
                    row[_dataSet.SalesDetail.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                    row[_dataSet.SalesDetail.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                    row[_dataSet.SalesDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                    row[_dataSet.SalesDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                    row[_dataSet.SalesDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SupplierSnmColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.PartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CarMngCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.ShipSalesSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SrcSalesSlipNumColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesOrderDivCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StockPartySaleSlipNumColumn.ColumnName] = DBNull.Value;
                    //row[_dataSet.SalesDetail.UOESupplierCdColumn] = DBNull.Value; // DEL 2015/02/05 王亜楠
                    row[_dataSet.SalesDetail.UOESupplierCdColumn.ColumnName] = DBNull.Value; // ADD 2015/02/05 王亜楠 // .ColumnNameの追加
                    row[_dataSet.SalesDetail.UOESupplierSnmColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.UOERemark1Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.UOERemark2Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GuideNameColumn.ColumnName] = data.GuideName;
                    row[_dataSet.SalesDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                    row[_dataSet.SalesDetail.SectionGuideNameColumn.ColumnName] = data.SectionGuideNm;
                    row[_dataSet.SalesDetail.DtlNoteColumn.ColumnName] = this.GetValidityTerm( data.DtlNote ); // 明細備考←有効期限をセット
                    row[_dataSet.SalesDetail.ColorName1Column.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.TrimNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcLPriceColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcSalUnPrcColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.StdUnPrcUnCstColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsMakerCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.MakerNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CostColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.CustSlipNoColumn.ColumnName] = DBNull.Value;
                    if ( data.AddUpADate != DateTime.MinValue )
                    {
                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = data.AddUpADate;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.AddUpADateColumn.ColumnName] = DBNull.Value;
                    }
                    row[_dataSet.SalesDetail.AccRecDivCdColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AccRecDivCdNameColumn.ColumnName] = DBNull.Value;
                    if ( data.DebitNoteDiv == 0 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "黒";
                    }
                    else if ( data.DebitNoteDiv == 1 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "赤";
                    }
                    else if ( data.DebitNoteDiv == 2 )
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = "相殺済み黒";
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                    }
                    row[_dataSet.SalesDetail.AddresseeCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.AddresseeNameColumn.ColumnName] = DBNull.Value;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                    row[_dataSet.SalesDetail.SalesSlipCdDtlColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.SalesSlipCdDtlNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsLGroupColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsLGroupNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsMGroupColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsMGroupNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsKindCodeColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.GoodsKindCodeNameColumn.ColumnName] = DBNull.Value;
                    row[_dataSet.SalesDetail.WarehouseShelfNoColumn.ColumnName] = DBNull.Value;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/18 ADD
                    // 入力日
                    if ( data.InputDay != DateTime.MinValue )
                    {
                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = data.InputDay;
                    }
                    else
                    {
                        row[_dataSet.SalesDetail.InputDayColumn.ColumnName] = DBNull.Value;
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/18 ADD

                    //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                    if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                    {
                        row[_dataSet.SalesDetail.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                        if (data.CustAnalysCode1 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                        }
                        if (data.CustAnalysCode2 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                        }
                        if (data.CustAnalysCode3 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                        }
                        if (data.CustAnalysCode4 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                        }
                        if (data.CustAnalysCode5 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                        }
                        if (data.CustAnalysCode6 != 0)
                        {
                            row[_dataSet.SalesDetail.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                        }
                    }
                    //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

                    #endregion
                    //this._dataSet.SalesDetail.Rows.Add( row );
                    table.Rows.Add( row );
                }
            }
            // ---ADD 2009/02/14 不具合対応[11391] -----------------------------------------------------<<<<<
        }

        /// <summary>
        /// 伝票番号フォーマット対応
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>※売上伝票番号(string)と入金伝票番号(int)が混在しているので形式を設定する</remarks>
        private string GetSlipNum( CustPrtPprSalTblRsltWork data )
        {
            string slipNum = data.SalesSlipNum;
            try
            {
                int slipNumInt = Int32.Parse( slipNum );
                slipNum = slipNumInt.ToString( new string( '0', 9 ) );
            }
            catch
            {
                // intに変換できなかった場合はそのままのstringで返す
            }
            return slipNum;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

		// ------------ADD wangf 2013/01/30 FOR Redmine#34513--------->>>>
		/// <summary>
		/// 残高照会抽出（外部用）
		/// </summary>
		/// <param name="suppPrtPprBlDspRsltWorkObj">残高照会リスト</param>
		/// <param name="remainDataEx">検索出来情報</param>
		/// <param name="custPrtPpr">検索条件</param>
		/// <returns>フラグ</returns>
		/// <remarks>
		/// <br>Note		: 残高集計検索を行う。</br>
		/// <br>Programmer	: wangf</br>
		/// <br>Date		: 2012/01/30</br>
		/// </remarks>
		public int SearchBalanceResult(CustPrtPpr custPrtPpr)
		{
			DataRow row3;
			long AfCalDemandPrice = 0;            // 前回残高
			// 残高照会に表示するので１件のみ
			CustPrtPprBlDspRsltWork custPrtPprBlDspRsltWork = new CustPrtPprBlDspRsltWork();
			object custPrtPprBlDspRsltWorkObj = (object)custPrtPprBlDspRsltWork;
			RemainDataExtra remainDataExtra = new RemainDataExtra();

			// 検索実行
			int blDspRsltStatus = SearchBlDspRslt(ref custPrtPprBlDspRsltWorkObj, ref remainDataExtra, custPrtPpr);
			if (blDspRsltStatus == (int)ConstantManagement.DB_Status.ctDB_ERROR)
			{
				return (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			//-------------------
			// 残高表示
			//-------------------
			# region [残高表示]
			// 残高表示が一件で特定できなかった場合は表示しない
			// 得意先が存在しない場合も表示しない
			ArrayList al = (ArrayList)custPrtPprBlDspRsltWorkObj;
			if (al.Count == 1 || !_customerPointed)
			{
				foreach (CustPrtPprBlDspRsltWork remainData in (ArrayList)custPrtPprBlDspRsltWorkObj)
				{
                    if (this._dataSet.BalanceTotal.Count == 1)
                    {
                        row3 = this._dataSet.BalanceTotal.Rows[0];
                    }
                    else
                    {
                        row3 = this._dataSet.BalanceTotal.NewRow();
                        this._dataSet.BalanceTotal.Rows.Add(row3);
                    }
					row3[_dataSet.BalanceTotal.AcpOdrTtl2TmBfBlDmdColumn.ColumnName] = remainData.AcpOdrTtl2TmBfBlDmd;  // 前々々回残高
					row3[_dataSet.BalanceTotal.LastTimeDemandColumn.ColumnName] = remainData.LastTimeDemand;            // 前々回残高
					row3[_dataSet.BalanceTotal.AfCalDemandPriceColumn.ColumnName] = remainData.AfCalDemandPrice;        // 前回残高
					AfCalDemandPrice = remainData.AfCalDemandPrice;
					row3[_dataSet.BalanceTotal.AddUpYearMonthColumn.ColumnName] = remainData.AddUpYearMonth;            // 請求年月
					row3[_dataSet.BalanceTotal.ConsTaxLayMethodColumn.ColumnName] = remainData.ConsTaxLayMethod;        // 消費税転嫁方式
					// 請求金額
					row3[_dataSet.BalanceTotal.AfCalBlcColumn.ColumnName] = remainDataExtra.AfCalBlc;
					// 今回売上
					row3[_dataSet.BalanceTotal.ThisSalesPriceTotalColumn.ColumnName] = remainDataExtra.OfsThisTimeSales;
					// 消費税
					row3[_dataSet.BalanceTotal.OfsThisSalesTaxColumn.ColumnName] = remainDataExtra.OfsThisSalesTax;
					// 今回入金
					row3[_dataSet.BalanceTotal.ThisTimeDmdNrmlColumn.ColumnName] = remainDataExtra.ThisTimeDmdNrml;
					// 締開始日
					row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = remainDataExtra.DmdStDay;
					// 締処理日
					row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = remainDataExtra.TotalDay;
					// 親フラグ
					row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = remainDataExtra.IsParent;
					// データ存在フラグ
					row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = true;
				}
			}
			# endregion
			// 残高表示が一件で特定できなかった場合は表示しない
			// 得意先が存在しない場合も表示しない
			if (this._dataSet.BalanceTotal.Rows.Count == 1)
			{
				blDspRsltStatus = 0;
			}
			else
			{
				blDspRsltStatus = 1;
			}
			return blDspRsltStatus;
		}
		// ------------ADD wangf 2013/01/30 FOR Redmine#34513---------<<<<
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
        /// <summary>
        /// 残高照会抽出
        /// </summary>
        /// <param name="suppPrtPprBlDspRsltWorkObj"></param>
        /// <param name="remainData"></param>
        /// <param name="suppPrtPpr"></param>
        /// <remarks>請求締次更新リモートを使用します</remarks>
        /// <br>Update Note: 2012/11/15 yangmj</br>
        /// <br>管理番号   : 10801804-00 20130116配信分</br>
        /// <br>             Redmine#33269　請求先情報の印刷の対応</br>
        private int SearchBlDspRslt( ref object suppPrtPprBlDspRsltWorkObj, ref RemainDataExtra remainDataEx, CustPrtPpr custPrtPpr )
        {
            suppPrtPprBlDspRsltWorkObj = new ArrayList();
            CustDmdPrcWork paraWork = new CustDmdPrcWork();

            string resultSectCd = string.Empty;
            string addUpSecCode = string.Empty;
            int customerCode = 0;
            int claimCode = 0;

            // ADD 2012/06/19 lanl for Redmine#30529 --->>>>>
            CustomerInfo customer = null;
            CustomerInputAcs customerInputAcs = new CustomerInputAcs();
            // ADD 2012/06/19 lanl for Remine#30529  ---<<<<<
            # region [条件セット]

            paraWork.EnterpriseCode = custPrtPpr.EnterpriseCode; // 企業コード

            //----- DEL YANGMJ 2012/11/15 for redmine#33269 ----->>>>>
            ////-----------------------------------------------------------
            //// 拠点入力判定
            ////-----------------------------------------------------------
            //if ( custPrtPpr.SectionCode == null || custPrtPpr.SectionCode.Length == 0 )
            //{
            //    // 00:全社ならば表示しない
            //    return (int)ConstantManagement.DB_Status.ctDB_EOF;
            //}
            //string sectionCode = custPrtPpr.SectionCode[0].Trim();
            //----- DEL YANGMJ 2012/11/15 for redmine#33269 -----<<<<<
            //----- ADD YANGMJ 2012/11/15 for redmine#33269 ----->>>>>
            // 入力拠点設定
            string sectionCode = string.Empty;
            if (custPrtPpr.SectionCode != null)
            {
                sectionCode = custPrtPpr.SectionCode[0].Trim();
            }
            //----- ADD YANGMJ 2012/11/15 for redmine#33269 -----<<<<<

            // --- UPD m.suzuki 2010/07/21 ---------->>>>>
            //paraWork.AddUpSecCode = sectionCode; // 拠点コード
            paraWork.ResultsSectCd = sectionCode; // 拠点コード
            // --- UPD m.suzuki 2010/07/21 ----------<<<<<

            //----- DEL YANGMJ 2012/11/15 for redmine#33269 ----->>>>>
            //if ( sectionCode == "00" ||
            //    string.IsNullOrEmpty( sectionCode ) )
            //{
            //    // 00:全社ならば表示しない
            //    return (int)ConstantManagement.DB_Status.ctDB_EOF;
            //}
            //----- DEL YANGMJ 2012/11/15 for redmine#33269 -----<<<<<

            //-----------------------------------------------------------
            // 得意先・請求先入力判定
            //-----------------------------------------------------------

            if ( custPrtPpr.CustomerCode != 0 )
            {
                // 得意先読み込み
                //CustomerInfo customer;//DEL 2012/06/19 lanl for Redmine#30529
                int readStatus = _customerInfoAcs.ReadDBData( ConstantManagement.LogicalMode.GetData0, custPrtPpr.EnterpriseCode, custPrtPpr.CustomerCode, true, false, out customer );
                if ( readStatus != 0 || customer == null || customer.LogicalDeleteCode != 0 )
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                //----- ADD YANGMJ 2012/11/15 for redmine#33269 ----->>>>>
                // 子得意先の場合、検索しない
                if (customer.ClaimCode != custPrtPpr.CustomerCode)
                {
                    // 子得意先ならば表示しない
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                // 親得意先の場合、検索拠点 != 請求拠点時、検索しない
                if (customer.ClaimCode == custPrtPpr.CustomerCode && (!string.IsNullOrEmpty(sectionCode)) && (!sectionCode.Equals(customer.ClaimSectionCode.Trim())))
                {
                    // 表示しない
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                if (string.IsNullOrEmpty(sectionCode))
                {
                    //拠点が全社の場合は、得意先マスタの請求拠点を使用する
                    sectionCode = customer.ClaimSectionCode.Trim();
                    paraWork.ResultsSectCd = sectionCode; // 拠点コード
                }
                //----- ADD YANGMJ 2012/11/15 for redmine#33269 -----<<<<<
                if ( custPrtPpr.ClaimCode != 0 )
                {
                    //----------------------------------------------
                    // 得意先＋請求先
                    //----------------------------------------------

                    // 親子関係判定
                    if ( customer.ClaimCode == custPrtPpr.ClaimCode && customer.ClaimSectionCode.Trim() == sectionCode )
                    {
                        paraWork.CustomerCode = custPrtPpr.ClaimCode; // 得意先コード←請求先コード
                        paraWork.ClaimCode = customer.ClaimCode;
                        paraWork.ResultsSectCd = "00";
                        paraWork.AddUpSecCode = sectionCode;

                        customerCode = 0;
                        claimCode = customer.ClaimCode;
                        resultSectCd = "00";
                        addUpSecCode = sectionCode;
                    }
                    else
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
                else
                {
                    //----------------------------------------------
                    // 得意先のみ
                    //----------------------------------------------
                    paraWork.CustomerCode = customer.CustomerCode; // 得意先コード←得意先コード
                    paraWork.ClaimCode = customer.ClaimCode;
                    // --- UPD m.suzuki 2010/07/21 ---------->>>>>
                    //paraWork.ResultsSectCd = customer.ClaimSectionCode;
                    //paraWork.AddUpSecCode = sectionCode;
                    paraWork.ResultsSectCd = sectionCode;
                    paraWork.AddUpSecCode = customer.ClaimSectionCode; 
                    // --- UPD m.suzuki 2010/07/21 ----------<<<<<

                    customerCode = customer.CustomerCode;
                    claimCode = customer.ClaimCode;
                    // --- UPD m.suzuki 2010/07/21 ---------->>>>>
                    //resultSectCd = customer.ClaimSectionCode;
                    //addUpSecCode = sectionCode;
                    resultSectCd = sectionCode;
                    addUpSecCode = customer.ClaimSectionCode; 
                    // --- UPD m.suzuki 2010/07/21 ----------<<<<<
                }
            }
            else
            {
                if ( custPrtPpr.ClaimCode != 0 )
                {
                    //----------------------------------------------
                    // 請求先のみ
                    //----------------------------------------------

                    // 請求先読み込み
                    CustomerInfo claim;
                    int readStatus = _customerInfoAcs.ReadDBData( ConstantManagement.LogicalMode.GetData0, custPrtPpr.EnterpriseCode, custPrtPpr.ClaimCode, true, false, out claim );
                    if ( readStatus != 0 || claim == null || claim.LogicalDeleteCode != 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                    // 親子判定
                    if ( claim.ClaimCode == claim.CustomerCode && claim.ClaimSectionCode.Trim() == sectionCode )
                    {
                        paraWork.CustomerCode = custPrtPpr.ClaimCode; // 得意先コード←請求先コード
                        paraWork.ClaimCode = claim.CustomerCode;
                        paraWork.ResultsSectCd = "00";
                        paraWork.AddUpSecCode = sectionCode;

                        customerCode = 0;
                        claimCode = claim.CustomerCode;
                        resultSectCd = "00";
                        addUpSecCode = sectionCode;
                    }
                    else
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
                else
                {
                    //----------------------------------------------
                    // (両方とも入力なし)
                    //----------------------------------------------
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }

            // 画面終了日
            paraWork.AddUpDate = custPrtPpr.Ed_SalesDate;

            # endregion

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            suppPrtPprBlDspRsltWorkObj = null;

            # region [締済み：得意先請求金額マスタ]
            //-----------------------------------------------
            // 締済み：得意先請求金額マスタ
            //-----------------------------------------------
            object retObj;

            addUpSecCode = addUpSecCode.Trim();
            resultSectCd = resultSectCd.Trim();

            if ( claimCode == customerCode && addUpSecCode == resultSectCd )
            {
                customerCode = 0;
                resultSectCd = "00";
            }

            status = _iCustRsltUpdDB.SearchDmdPrc( paraWork.EnterpriseCode, addUpSecCode, claimCode, resultSectCd, customerCode, 0, out retObj );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retObj != null )
            {
                CustomSerializeArrayList retObjList = (CustomSerializeArrayList)retObj;
                if ( retObjList.Count > 0 )
                {
                    int TaxLayMethod = customerInputAcs.GetConsTaxLayMethod(paraWork.EnterpriseCode, 0);// ADD 2012/06/19 lanl for Redmine#30529
                    for ( int index = 0; index < retObjList.Count; index++ )
                    {
                        ArrayList list = (ArrayList)(retObjList[index] as ArrayList)[0];

                        foreach ( CustDmdPrcWork retWork in list as ArrayList )
                        {
                            if ( retWork.AddUpDate < custPrtPpr.Ed_SalesDate ) continue;
                            if ( retWork.StartCAddUpUpdDate > custPrtPpr.Ed_SalesDate ) continue;

                            CustPrtPprBlDspRsltWork rsltWork = new CustPrtPprBlDspRsltWork();
                            remainDataEx = new RemainDataExtra();

                            # region [結果セット]

                            rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;// 請求年月
                            rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// 転嫁方式

                            // --- ADD 2012/06/19 lanl for Redmine#30529 ----------------------->>>>>
                            if (customer.CustCTaXLayRefCd == 0)//CustCTaXLayRefCdRF
                            {
                                rsltWork.ConsTaxLayMethod = TaxLayMethod;
                            }
                            else
                            {
                                
                                rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// 転嫁方式
                            }
                            // --- ADD 2012/06/19 lanl for Redmine#30529 ----------------------<<<<< 
                            //rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// 転嫁方式 // DEL  2012/06/19 lanl for Redmine#30529
                            rsltWork.AcpOdrTtl2TmBfBlDmd = retWork.AcpOdrTtl3TmBfBlDmd; // 前々々回残
                            rsltWork.LastTimeDemand = retWork.AcpOdrTtl2TmBfBlDmd; // 前々回残
                            rsltWork.AfCalDemandPrice = retWork.LastTimeDemand; ; // 前回残

                            remainDataEx.OfsThisTimeSales = retWork.OfsThisTimeSales; // 今回売上
                            remainDataEx.OfsThisSalesTax = retWork.OfsThisSalesTax; // 消費税
                            remainDataEx.ThisTimeDmdNrml = retWork.ThisTimeDmdNrml; // 今回入金
                            remainDataEx.AfCalBlc = retWork.AfCalDemandPrice; // 請求金額

                            remainDataEx.DmdStDay = retWork.StartCAddUpUpdDate; // 締開始日
                            remainDataEx.TotalDay = retWork.AddUpDate; // 締処理日

                            remainDataEx.IsParent = (retWork.CustomerCode == retWork.ClaimCode || retWork.CustomerCode == 0); // 親フラグ

                            # endregion

                            // 返却データ
                            ArrayList retList = new ArrayList();
                            retList.Add( rsltWork );
                            suppPrtPprBlDspRsltWorkObj = retList;

                            break;
                        }
                    }
                }
            }
            # endregion

            if ( suppPrtPprBlDspRsltWorkObj == null )
            {
                # region [未締：売上締次集計リモート呼び出し]
                //-----------------------------------------------
                // 未締：売上締次集計リモート呼び出し
                //-----------------------------------------------
                bool isParent;
                if ( (paraWork.CustomerCode == paraWork.ClaimCode && paraWork.ResultsSectCd.Trim() == paraWork.AddUpSecCode.Trim()) ||
                     (customerCode == 0 && resultSectCd.Trim() == "00") )
                {
                    isParent = true;
                    paraWork.CustomerCode = paraWork.ClaimCode;
                    paraWork.ResultsSectCd = paraWork.AddUpSecCode;
                }
                else
                {
                    isParent = false;
                    paraWork.CustomerCode = paraWork.ClaimCode;
                    paraWork.ResultsSectCd = paraWork.AddUpSecCode;
                }
                // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                // 画面開始日（前回締履歴(得意先請求金額マスタレコード)が無い場合に日付の開始限界として使用する）
                paraWork.ExtractStartDate = custPrtPpr.St_SalesDate;
                // --- ADD m.suzuki 2010/07/21 ----------<<<<<

                object paraObj = paraWork;
                object childObj = null;
                string message;
                status = _iCustDmdPrcDB.ReadCustDmdPrc( ref paraObj, ref childObj, out message );

                // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                bool errorFlag = false;
                if ( paraObj == null && childObj == null)
                {
                    errorFlag = true;
                }
                else
                // --- ADD m.suzuki 2010/07/21 ----------<<<<<
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    CustPrtPprBlDspRsltWork rsltWork = new CustPrtPprBlDspRsltWork();
                    remainDataEx = new RemainDataExtra();

                    CustDmdPrcWork retWork = null;
                    // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                    try
                    {
                    // --- ADD m.suzuki 2010/07/21 ----------<<<<<
                        if ( isParent )
                        {
                            retWork = (CustDmdPrcWork)paraObj;
                        }
                        else
                        {
                            foreach ( CustDmdPrcWork childWork in (childObj as ArrayList) )
                            {
                                if ( childWork.CustomerCode == customerCode && childWork.ResultsSectCd.Trim() == resultSectCd.Trim() )
                                {
                                    retWork = childWork;
                                    break;
                                }
                            }
                        }
                    // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                    }
                    catch
                    {
                        errorFlag = true;
                    }
                    // --- ADD m.suzuki 2010/07/21 ----------<<<<<

                    if ( retWork != null )
                    {
                        # region [結果セット]

                        rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;// 請求年月
                        // --- ADD 2012/06/19 lanl for Redmine#30529 ----------------------->>>>>
                        retWork.EnterpriseCode = custPrtPpr.EnterpriseCode; // 企業コード // ADD 2012/07/10 tianjw for Redmine#30529 
                        if (customer.CustCTaXLayRefCd == 0)
                        {
                            rsltWork.ConsTaxLayMethod = customerInputAcs.GetConsTaxLayMethod(retWork.EnterpriseCode, 0);
                        }
                        else
                        {

                            rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// 転嫁方式
                        }
                        // --- ADD lanl 2012/06/19 Redmine#30529 ----------------------<<<<< 
                        //rsltWork.ConsTaxLayMethod = retWork.ConsTaxLayMethod;// 転嫁方式 // DEL  2012/06/19 lanl for Redmine#30529
                        rsltWork.AcpOdrTtl2TmBfBlDmd = retWork.AcpOdrTtl3TmBfBlDmd; // 前々々回残
                        rsltWork.LastTimeDemand = retWork.AcpOdrTtl2TmBfBlDmd; // 前々回残
                        rsltWork.AfCalDemandPrice = retWork.LastTimeDemand; ; // 前回残

                        remainDataEx.OfsThisTimeSales = retWork.OfsThisTimeSales; // 今回売上
                        remainDataEx.OfsThisSalesTax = retWork.OfsThisSalesTax; // 消費税
                        remainDataEx.ThisTimeDmdNrml = retWork.ThisTimeDmdNrml; // 今回入金
                        remainDataEx.AfCalBlc = retWork.AfCalDemandPrice; // 請求金額

                        remainDataEx.DmdStDay = retWork.StartCAddUpUpdDate; // 締開始日
                        remainDataEx.TotalDay = custPrtPpr.Ed_SalesDate; // 締処理日

                        remainDataEx.IsParent = isParent; // 親フラグ

                        # endregion

                        // 返却データ
                        ArrayList retList = new ArrayList();
                        retList.Add( rsltWork );
                        suppPrtPprBlDspRsltWorkObj = retList;
                    }
                }
                // --- ADD m.suzuki 2010/07/21 ---------->>>>>
                if ( errorFlag )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                // --- ADD m.suzuki 2010/07/21 ----------<<<<<
                # endregion
            }

            // 該当データなし
            if ( suppPrtPprBlDspRsltWorkObj == null )
            {
                suppPrtPprBlDspRsltWorkObj = new ArrayList();
            }

            return status;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
        /// <summary>
        /// 有効期限取得処理
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private object GetValidityTerm( string originText )
        {
            int validityTerm = 0;
            DateTime date;
            try
            {
                validityTerm = Int32.Parse( originText );
                date = GetDateTimeFromLongDate( validityTerm );
            }
            catch
            {
                date = DateTime.MinValue;
            }

            if ( date == DateTime.MinValue )
            {
                // 空白にする
                return DBNull.Value;
            }
            else
            {
                // yyyy/mm/ddでセット
                return date.ToString( "yyyy/MM/dd" );
            }
        }
        /// <summary>
        /// 日付取得処理（int→DateTime変換）
        /// </summary>
        /// <param name="longDate"></param>
        /// <returns></returns>
        private DateTime GetDateTimeFromLongDate( int longDate )
        {
            try
            {
                return new DateTime( (longDate / 10000), ((longDate / 100) % 100), (longDate % 100) );
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
        /// <summary>
        /// 伝票グリッドへのセット（伝票単位）
        /// </summary>
        /// <param name="data"></param>
        /// <param name="salAmntConsTaxInclu"></param>
        /// <param name="yeardiv"></param>
        /// <param name="mode">検索モード（0:正常検索用 1:テキスト出力検索用）</param> // ADD 2015/02/05 王亜楠
        /// <br>Update Note: 2010/06/08 呉元嘯 売上履歴データから伝票再発行を可能へ変更</br>
        /// <br>Update Note: 2010/12/20 yangmj </br>
        /// <br>             年式に月のみ設定されている場合のエラー修正</br>
        /// <br>             計上元受注№・計上元貸出№の表示内容修正</br>
        /// <br>Update Note: 2011/11/23 陳建明</br>
        /// <br>             Redmine#8079対応</br>
        /// <br>             得意先電子元帳/年式の表示についての修正</br>
        /// <br>UpdateNote : 2015/02/05 王亜楠 </br>
        /// <br>           : テキスト出力件数制限なしモードの追加</br>
        /// <br>UpdateNote : K2014/05/08 林超凡</br>
        /// <br>           : 得意先電子元帳のCSV出力項目に車種メーカーコードを追加する、東亜商会個別対応</br>
        /// <br>Update Note: 2020/03/11 時シン</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 軽減税率対応</br>
        /// <br>           : 伝票タブ、明細タブに「消費税率」項目を追加</br>
        //private void RecordSetToSlipList(CustPrtPprSalTblRsltWork data, int rowNo, long salAmntConsTaxInclu)//陳建明 2011/11/23 DEL
        private void RecordSetToSlipList(CustPrtPprSalTblRsltWork data, int rowNo, long salAmntConsTaxInclu, int yeardiv, int mode) // ADD 2015/02/05 王亜楠
        {
            // 伝票番号および受注スタータスが異なれば別伝票として取得
            //DataRow row2 = _dataSet.SalesList.NewRow();// DEL 2015/02/05 王亜楠

            //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
            DataRow row2;
            if (mode == 0)
            {
                row2 = _dataSet.SalesList.NewRow();
            }
            else
            {
                row2 = this._salesListTbl4Text.NewRow();
            }
            //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

            // 売上伝票なのか入金伝票なのかでデータの構造が異なる
            if ( data.DataDiv == 0 )
            {
                #region 売上伝票

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                // 返品制御用 金額符号
                int slipSign = 1;

                // 返品判定
                if ( data.SalesSlipCd == 1 ) slipSign *= -1;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                // 売上伝票
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 DEL
                //row2[_dataSet.SalesList.SelectionColumn.ColumnName] = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                if ( data.HistoryDiv != 0 )
                {
                    // ----------UPD 2010/06/08----------->>>>>
                    //// 過去分(売上履歴から取得分)はチェック不可
                    //row2[_dataSet.SalesList.SelectionColumn.ColumnName] = DBNull.Value;
                    //売上履歴データからの再発行できる
                    row2[_dataSet.SalesList.SelectionColumn.ColumnName] = false;
                    // ----------UPD 2010/06/08-----------<<<<<
                }
                else
                {
                    // 通常
                    row2[_dataSet.SalesList.SelectionColumn.ColumnName] = false;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                row2[_dataSet.SalesList.RowNoColumn.ColumnName] = rowNo;
                row2[_dataSet.SalesList.DataDivColumn.ColumnName] = data.DataDiv;
                row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = data.SalesDate;
                //row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.SalesDate);
                row2[_dataSet.SalesList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                row2[_dataSet.SalesList.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                row2[_dataSet.SalesList.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                row2[_dataSet.SalesList.EnterpriseGanreCodeColumn.ColumnName] = data.EnterpriseGanreCode;
                // 伝票区分名判定
                if ( data.SalesSlipCd == 0 )
                {
                    if ( data.AcptAnOdrStatus == 20 )
                    {
                        row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "受注";
                    }
                    else if ( data.AcptAnOdrStatus == 30 )
                    {
                        row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "売上";
                    }
                    else if ( data.AcptAnOdrStatus == 40 )
                    {
                        row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "貸出";
                    }
                }
                else
                {
                    row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "返品";
                }
                row2[_dataSet.SalesList.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 DEL
                //row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = data.SalesTotalTaxExc - data.TotalCost;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                //if (data.CategoryNo == 0)
                //{
                //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = DBNull.Value;
                //}
                //else
                //{
                //    row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = data.CategoryNo;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = GetModelDesignationNoAndCategoryNo( data );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 BEGIN--------->>>>>
                //----- ADD K2014/05/08 By 林超凡 テキスト出力項目に車種メーカーコードを追加する BEGIN--------->>>>>
                if (this._opt_Toua == Convert.ToInt32(Option.ON))
                {
                    row2[_dataSet.SalesList.MakerCodeColumn.ColumnName] = data.MakerCode;
                }
                //----- ADD K2014/05/08 By 林超凡 テキスト出力項目に車種メーカーコードを追加する END---------<<<<<
                //----- ADD K2014/05/28 By 林超凡 Redmine#42764 受入テスト障害対応 END---------<<<<<
                row2[_dataSet.SalesList.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                // --- ADD m.suzuki 2010/04/02 ---------->>>>>
                row2[_dataSet.SalesList.ModelHalfNameColumn.ColumnName] = data.ModelHalfName;
                // --- ADD m.suzuki 2010/04/02 ----------<<<<<
                // -------------UPD 2010/01/12------------->>>>>
                //if ( data.FirstEntryDate == DateTime.MinValue )
                if (data.FirstEntryDate == 0)
                {
                    row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                    //----UPD 2010/12/20----->>>>>
                    string firstEntryDate = "";

                    if (data.FirstEntryDate.ToString().Length < 6)
                    {
                        firstEntryDate = "0000" + "/" + data.FirstEntryDate.ToString("D2");
                    }   
                    else
                    {
                        firstEntryDate = data.FirstEntryDate.ToString().Substring(0, 4) + "/" + data.FirstEntryDate.ToString().Substring(4, 2);
                    }
                    firstEntryDate = firstEntryDate.Replace(@"/00", ""); // ADD 2013/05/06 zhujw #34718
                    //string firstEntryDate = data.FirstEntryDate.ToString().Substring(0, 4) + "/" + data.FirstEntryDate.ToString().Substring(4, 2);
                    //----UPD 2010/12/20-----<<<<<
                    //陳建明 2011/11/23 ADD----->>>>>
                    if (yeardiv == 1)
                    {
                        // --- UPD 2012/06/26 №880 ---------->>>>>
                        //string date = data.FirstEntryDate.ToString() + "01";
                        //int StartTotalUnitYm = Convert.ToInt32(date);
                        //string stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                        string date, stTarget;
                        int StartTotalUnitYm;
                        if (data.FirstEntryDate.ToString().Substring(4, 2) == "00")
                        {
                            date = data.FirstEntryDate.ToString().Substring(0, 4) + "0101";
                            StartTotalUnitYm = Convert.ToInt32(date);
                            //stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm) + "00月";// DEL 2013/05/06 zhujw #Redmine34718
                            stTarget = TDateTime.LongDateToString("GGyy", StartTotalUnitYm);// ADD 2013/05/06 zhujw #Redmine34718
                        }
                        else
                        {
                            date = data.FirstEntryDate.ToString() + "01";
                            StartTotalUnitYm = Convert.ToInt32(date);
                            stTarget = TDateTime.LongDateToString("GGyymm", StartTotalUnitYm);
                        }
                        // --- UPD 2012/06/26 №880 ----------<<<<<

                        row2[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = stTarget;
                    }
                    else
                    {
                        row2[_dataSet.SalesDetail.FirstEntryDateColumn.ColumnName] = firstEntryDate;
                    }
                    //陳建明 2011/11/23 ADD-----<<<<<
                    //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = firstEntryDate; //陳建明 2011/11/23 DEL
                }
                // -------------UPD 2010/01/12-------------<<<<<
                //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.FirstEntryDate);
                row2[_dataSet.SalesList.FullModelColumn.ColumnName] = data.FullModel;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 DEL
                //if ( data.SearchFrameNo == 0 )
                //{
                //    row2[_dataSet.SalesList.FrameNoColumn.ColumnName] = DBNull.Value;
                //}
                //else
                //{
                //    row2[_dataSet.SalesList.FrameNoColumn.ColumnName] = data.SearchFrameNo;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                row2[_dataSet.SalesList.FrameNoColumn.ColumnName] = data.FrameNo;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                row2[_dataSet.SalesList.SlipNoteColumn.ColumnName] = data.SlipNote;
                row2[_dataSet.SalesList.SlipNote2Column.ColumnName] = data.SlipNote2;
                row2[_dataSet.SalesList.SlipNote3Column.ColumnName] = data.SlipNote3;
                row2[_dataSet.SalesList.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                row2[_dataSet.SalesList.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                //row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                row2[_dataSet.SalesList.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                row2[_dataSet.SalesList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                row2[_dataSet.SalesList.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                // ----- UPD 2010/12/20 ----->>>>>
                //if (data.AcceptAnOrderNo == 0)
                //{
                //    row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                //}
                //else
                //{
                //    row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                //}
                if (data.AcptAnOdrStatusSrc == 20)
                {
                    if (!string.IsNullOrEmpty(data.HisDtlSlipNum.ToString()))
                    {
                        row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.HisDtlSlipNum;
                    }
                }
                else
                {
                    //if (data.AcceptAnOrderNo == 0)
                    //{
                        row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                    //}
                    //else
                    //{
                    //    row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                    //}
                }

                // 計上元出荷No[NULLのときは空白]

                //if (data.ShipmSalesSlipNum == "0")
                //{
                //    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                //}
                //else
                //{
                //    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                //}
                if (data.AcptAnOdrStatusSrc == 40)
                {
                    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.HisDtlSlipNum;
                }
                else
                {
                    //if (data.ShipmSalesSlipNum == "0")
                    //{
                        row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                    //}
                    //else
                    //{
                    //    row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                    //}
                }
                // ----- UPD 2010/12/20 -----<<<<<

                row2[_dataSet.SalesList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                row2[_dataSet.SalesList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                //row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                row2[_dataSet.SalesList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                row2[_dataSet.SalesList.ColorName1Column.ColumnName] = data.ColorName1;
                row2[_dataSet.SalesList.TrimNameColumn.ColumnName] = data.TrimName;
                if ( data.CustSlipNo == 0 )
                {
                    row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                //row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                if ( data.AddUpADate != DateTime.MinValue )
                {
                    row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                }
                else
                {
                    row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                //row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = TDateTime.DateTimeToLongDate(data.AddUpADate);
                row2[_dataSet.SalesList.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                if ( data.AccRecDivCd == 1 )
                {
                    row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "売掛";
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                else
                {
                    row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "現金";
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                //row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = data.DebitNoteDiv;
                if ( data.DebitNoteDiv == 0 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "黒伝";
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "赤伝";
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "元黒";
                }
                else
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                # region [消費税関連]
                bool printTax = true;
                Int64 salesTotalTaxInc;
                Int64 salesTotalTaxExc = data.SalesTotalTaxExc;
                Int64 salesPriceConsTax;

                // 印刷する消費税額の取得
                if ( data.ConsTaxLayMethod == 0 || data.ConsTaxLayMethod == 1 ) // 伝票単位or明細単位
                {
                    salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                }
                else
                {
                    salesPriceConsTax = 0;
                }

                // 税込金額の取得
                salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                if ( printTax )
                {
                    // 消費税印字有無判定と金額制御
                    int totalAmountDispWayCd = data.TotalAmountDispWayCd;

                    // 消費税印字有無判定
                    printTax = ReflectMoneyForTaxPrintOfSlip( ref salesTotalTaxExc, ref salesPriceConsTax, ref salAmntConsTaxInclu, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod );
                    if ( printTax )
                    {
                        if ( salesPriceConsTax != 0 )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                            //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = salesPriceConsTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = slipSign * salesPriceConsTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                            // 消費税率
                            row2[_dataSet.SalesList.ConsTaxRateColumn.ColumnName] = data.ConsTaxRate; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                        }
                        else
                        {
                            // 印字しない
                            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            row2[_dataSet.SalesList.ConsTaxRateColumn.ColumnName] = DBNull.Value;　// ADD 時シン 2020/03/11 PMKOBETSU-2912
                        }
                    }
                    else
                    {
                        // 印字しない
                        row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                        row2[_dataSet.SalesList.ConsTaxRateColumn.ColumnName] = DBNull.Value;　// ADD 時シン 2020/03/11 PMKOBETSU-2912
                    }
                }
                else
                {
                    // 印字しない
                    row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                    row2[_dataSet.SalesList.ConsTaxRateColumn.ColumnName] = DBNull.Value;　// ADD 時シン 2020/03/11 PMKOBETSU-2912
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                //// 税抜金額セット
                //row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = salesTotalTaxExc;
                //// 粗利セット
                //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = salesTotalTaxExc - data.TotalCost;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                // 税抜金額セット
                row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] =  slipSign * salesTotalTaxExc;
                // 粗利セット
                row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = slipSign * (salesTotalTaxExc - data.TotalCost);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 DEL
                //if ( (long)row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] < 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
                if ( data.ShipmentCnt < 0 && data.SalesSlipCdDtl != 2 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "赤伝";
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                row2[_dataSet.SalesList.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                row2[_dataSet.SalesList.AddresseeNameColumn.ColumnName] = data.AddresseeName + data.AddresseeName2;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                // 入力日
                if ( data.InputDay != DateTime.MinValue )
                {
                    row2[_dataSet.SalesList.InputDayColumn.ColumnName] = data.InputDay;
                }
                else
                {
                    row2[_dataSet.SalesList.InputDayColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                row2[_dataSet.SalesList.HistoryDivNameColumn.ColumnName] = this.GetHistoryDivName( data.HistoryDiv ); // 履歴区分
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                row2[_dataSet.SalesList.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText( data.UpdateDateTime ); // 伝票発行時刻
                // ADD 2012/04/01 gezh Redmine#29250 ------------------------------------------------------------->>>>>
                if (data.UpdateDateTime != 0)
                {
                    DateTime dt = new DateTime(data.UpdateDateTime);
                    row2[_dataSet.SalesList.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // 更新日時
                }
                else
                {
                    row2[_dataSet.SalesList.UpdateDateTimeColumn.ColumnName] = string.Empty;
                }
                // ADD 2012/04/01 gezh Redmine#29250 -------------------------------------------------------------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD

                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                {
                    row2[_dataSet.SalesList.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                    if (data.CustAnalysCode1 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                    }
                    if (data.CustAnalysCode2 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                    }
                    if (data.CustAnalysCode3 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                    }
                    if (data.CustAnalysCode4 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                    }
                    if (data.CustAnalysCode5 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                    }
                    if (data.CustAnalysCode6 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                    }
                }
                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

                #endregion // 売上伝票
            }
            else
            {
                #region 入金伝票
                // 入金伝票
                // 選択チェックボックスなし
                row2[_dataSet.SalesList.SelectionColumn.ColumnName] = DBNull.Value;
                row2[_dataSet.SalesList.RowNoColumn.ColumnName] = rowNo;
                row2[_dataSet.SalesList.DataDivColumn.ColumnName] = data.DataDiv;
                row2[_dataSet.SalesList.SalesDateColumn.ColumnName] = data.SalesDate;
                row2[_dataSet.SalesList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                row2[_dataSet.SalesList.AcptAnOdrStatusColumn.ColumnName] = data.AcptAnOdrStatus;
                row2[_dataSet.SalesList.SalesSlipCdColumn.ColumnName] = data.SalesSlipCd;
                row2[_dataSet.SalesList.SalesSlipCdNameColumn.ColumnName] = "入金";
                row2[_dataSet.SalesList.SalesEmployeeNmColumn.ColumnName] = data.SalesEmployeeNm;
                row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = data.SalesTotalTaxExc;
                //row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                //row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = data.SalesTotalTaxExc - data.TotalCost;
                //row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = data.CategoryNo;
                row2[_dataSet.SalesList.CategoryNoColumn.ColumnName] = DBNull.Value;
                //row2[_dataSet.SalesList.ModelFullNameColumn.ColumnName] = data.ModelFullName;
                //row2[_dataSet.SalesList.FirstEntryDateColumn.ColumnName] = data.FirstEntryDate;
                //row2[_dataSet.SalesList.FullModelColumn.ColumnName] = data.FullModel;
                //row2[_dataSet.SalesList.SearchFrameNoColumn.ColumnName] = data.SearchFrameNo;
                row2[_dataSet.SalesList.FrameNoColumn.ColumnName] = DBNull.Value;
                row2[_dataSet.SalesList.SlipNoteColumn.ColumnName] = data.SlipNote;
                //row2[_dataSet.SalesList.SlipNote2Column.ColumnName] = data.SlipNote2;
                //row2[_dataSet.SalesList.SlipNote3Column.ColumnName] = data.SlipNote3;
                //row2[_dataSet.SalesList.FrontEmployeeNmColumn.ColumnName] = data.FrontEmployeeNm;
                row2[_dataSet.SalesList.SalesInputNameColumn.ColumnName] = data.SalesInputName;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 DEL
                //row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/19 ADD
                row2[_dataSet.SalesList.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/19 ADD
                row2[_dataSet.SalesList.CustomerSnmColumn.ColumnName] = data.CustomerSnm;
                //row2[_dataSet.SalesList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                //row2[_dataSet.SalesList.CarMngCodeColumn.ColumnName] = data.CarMngCode;
                //row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                row2[_dataSet.SalesList.AcceptAnOrderNoColumn.ColumnName] = DBNull.Value;
                //row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = data.ShipmSalesSlipNum;
                row2[_dataSet.SalesList.ShipmSalesSlipNumColumn.ColumnName] = string.Empty;
                //row2[_dataSet.SalesList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                //row2[_dataSet.SalesList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 DEL
                //row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/14 ADD
                row2[_dataSet.SalesList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/14 ADD
                row2[_dataSet.SalesList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                //row2[_dataSet.SalesList.ColorName1Column.ColumnName] = data.ColorName1;
                //row2[_dataSet.SalesList.TrimNameColumn.ColumnName] = data.TrimName;
                //row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = data.CustSlipNo;
                row2[_dataSet.SalesList.CustSlipNoColumn.ColumnName] = DBNull.Value;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                if ( data.AddUpADate != DateTime.MinValue )
                {
                    row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = data.AddUpADate;
                }
                else
                {
                    row2[_dataSet.SalesList.AddUpADateColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                //if (data.AccRecDivCd == 1)
                //{
                //    row2[_dataSet.SalesList.AccRecDivCdNameColumn.ColumnName] = "売掛";
                //}
                //row2[_dataSet.SalesList.AccRecDivCdColumn.ColumnName] = data.AccRecDivCd;
                if ( data.DebitNoteDiv == 0 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "黒";
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "赤";
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = "相殺済黒";
                }
                else
                {
                    row2[_dataSet.SalesList.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
                row2[_dataSet.SalesList.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                row2[_dataSet.SalesList.AddresseeNameColumn.ColumnName] = data.AddresseeName + data.AddresseeName2;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/09 ADD
                // 入力日
                if ( data.InputDay != DateTime.MinValue )
                {
                    row2[_dataSet.SalesList.InputDayColumn.ColumnName] = data.InputDay;
                }
                else
                {
                    row2[_dataSet.SalesList.InputDayColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/09 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.08.24 ADD
                row2[_dataSet.SalesList.HistoryDivNameColumn.ColumnName] = string.Empty; // 履歴区分
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.08.24 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/10/19 ADD
                row2[_dataSet.SalesList.SlipPrintTimeColumn.ColumnName] = this.GetSlipPrintTimeText( data.UpdateDateTime ); // 伝票発行時刻
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/10/19 ADD
                // ADD 2012/04/01 gezh Redmine#29250 --------------------------------------------------------------------->>>>>
                if (data.UpdateDateTime != 0)
                {
                    DateTime dt = new DateTime(data.UpdateDateTime);
                    row2[_dataSet.SalesList.UpdateDateTimeColumn.ColumnName] = dt.ToString("yyyy/MM/dd HH:mm:ss"); // 更新日時  
                }
                else
                {
                    row2[_dataSet.SalesList.UpdateDateTimeColumn.ColumnName] = string.Empty;
                }
                // ADD 2012/04/01 gezh Redmine#29250 ---------------------------------------------------------------------<<<<<
            

                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
                if (this._opt_Meigo == Convert.ToInt32(Option.ON))
                {
                    row2[_dataSet.SalesList.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                    if (data.CustAnalysCode1 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode1Column.ColumnName] = data.CustAnalysCode1;
                    }
                    if (data.CustAnalysCode2 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode2Column.ColumnName] = data.CustAnalysCode2;
                    }
                    if (data.CustAnalysCode3 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode3Column.ColumnName] = data.CustAnalysCode3;
                    }
                    if (data.CustAnalysCode4 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode4Column.ColumnName] = data.CustAnalysCode4;
                    }
                    if (data.CustAnalysCode5 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode5Column.ColumnName] = data.CustAnalysCode5;
                    }
                    if (data.CustAnalysCode6 != 0)
                    {
                        row2[_dataSet.SalesList.CustAnalysCode6Column.ColumnName] = data.CustAnalysCode6;
                    }
                }
                //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

                #endregion // 入金伝票
            }

             // 行追加
            //this._dataSet.SalesList.Rows.Add( row2 ); // DEL 2015/02/05 王亜楠

            //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
            if (mode == 0)
            {
            this._dataSet.SalesList.Rows.Add( row2 );
        }
            else
            {
                this._salesListTbl4Text.Rows.Add(row2);
            }
            //----- ADD 2015/02/05 王亜楠 --------------------<<<<<
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/30 ADD
        /// <summary>
        /// 類別型式取得処理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private object GetModelDesignationNoAndCategoryNo( CustPrtPprSalTblRsltWork data )
        {
            int categoryNo = data.CategoryNo;
            int modelDesignationNo = data.ModelDesignationNo;

            if ( modelDesignationNo == 0 && categoryNo == 0 )
            {
                return string.Empty;
            }
            else
            {
                string result = string.Empty;

                // 型式指定番号
                if ( modelDesignationNo == 0 )
                {
                    result += new string( ' ', 5 );
                }
                else
                {
                    result += modelDesignationNo.ToString( "00000" );
                }

                // ハイフン
                result += "-";

                // 類別番号
                if ( categoryNo == 0 )
                {
                    result += new string( ' ', 4 );
                }
                else
                {
                    result += categoryNo.ToString( "0000" );
                }

                return result;
            }
        }
        /// <summary>
        /// 金額取得処理（消費税印刷対応）
        /// </summary>
        /// <param name="moneyTaxExc"></param>
        /// <param name="priceConsTax"></param>
        /// <param name="moneyTaxInc"></param>
        /// <param name="totalAmountDispWayCd"></param>
        /// <param name="consTaxLayMethod"></param>
        /// <param name="taxationDivCd"></param>
        private static bool ReflectMoneyForTaxPrint( ref long moneyTaxExc, ref long priceConsTax, ref long moneyTaxInc, int totalAmountDispWayCd, int consTaxLayMethod, int taxationDivCd )
        {
            bool printTax;

            # region [printTax]
            switch ( GetTaxPrintType( totalAmountDispWayCd, consTaxLayMethod ) )
            {
                case 0:
                    // ----- ADD huangt 2013/05/15 Redmine#35640 ---------- >>>>> 
                    {
                        // 伝票単位（伝票毎の明細先頭行に消費税が印字される）
                        printTax = true;
                    }
                    break;
                    // ----- ADD huangt 2013/05/15 Redmine#35640 ---------- <<<<<
                default:
                    {
                        // 伝票単位（明細毎の消費税は表示しない）
                        printTax = false;
                    }
                    break;
                case 1:
                    {
                        // 明細単位/総額表示
                        printTax = true;
                    }
                    break;
                case 2:
                    {
                        // 請求親子・非課税（課税区分＝内税のみ表示）
                        // 課税区分（0:課税,1:非課税,2:課税（内税））
                        switch ( taxationDivCd )
                        {
                            case 0:
                            case 1:
                            default:
                                {
                                    printTax = false;
                                }
                                break;
                            case 2:
                                {
                                    printTax = true;
                                }
                                break;
                        }
                    }
                    break;
            }
            # endregion

            // 税印字しない場合
            if ( !printTax )
            {
                priceConsTax = 0;
                moneyTaxInc = moneyTaxExc;
            }

            return printTax;
        }
        /// <summary>
        /// 金額取得処理（消費税印刷対応）
        /// </summary>
        /// <param name="moneyTaxExc"></param>
        /// <param name="priceConsTax"></param>
        /// <param name="moneyTaxInc"></param>
        /// <param name="totalAmountDispWayCd"></param>
        /// <param name="consTaxLayMethod"></param>
        private static bool ReflectMoneyForTaxPrintOfSlip( ref long moneyTaxExc, ref long priceConsTax, ref long priceConsTaxInclu, ref long moneyTaxInc, int totalAmountDispWayCd, int consTaxLayMethod )
        {
            bool printTax;

            # region [printTax]
            switch ( GetTaxPrintType( totalAmountDispWayCd, consTaxLayMethod ) )
            {
                case 0:
                default:
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                        //// 伝票単位（明細毎の消費税は表示しない）
                        //printTax = false;
                        //priceConsTax = 0;
                        //moneyTaxInc = moneyTaxExc;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                        // 伝票単位（伝票単位の消費税を印字する）
                        printTax = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                    }
                    break;
                case 1:
                    {
                        // 明細単位/総額表示
                        printTax = true;
                    }
                    break;
                case 2:
                    {
                        //// 請求親子・非課税（課税区分＝内税のみ表示）
                        //// 課税区分（0:課税,1:非課税,2:課税（内税））
                        //switch ( taxationDivCd )
                        //{
                        //    case 0:
                        //    case 1:
                        //    default:
                        //        {
                        //            printTax = false;
                        //        }
                        //        break;
                        //    case 2:
                        //        {
                        //            printTax = true;
                        //        }
                        //        break;
                        //}
                        printTax = (priceConsTaxInclu != 0);
                        priceConsTax = priceConsTaxInclu;
                        moneyTaxInc = moneyTaxExc + priceConsTaxInclu;
                    }
                    break;
            }
            # endregion

            //// 税印字しない場合
            //if ( !printTax )
            //{
            //    priceConsTax = 0;
            //    moneyTaxInc = moneyTaxExc;
            //}

            return printTax;
        }
        /// <summary>
        /// 消費税表示タイプ取得
        /// </summary>
        /// <param name="slipWork"></param>
        /// <returns>TaxPrintType（0:伝票単位, 1:明細単位/総額表示あり, 2:請求親/請求子/非課税）</returns>
        private static int GetTaxPrintType( int totalAmountDispWayCd, int consTaxLayMethod )
        {
            // 総額表示方法
            switch ( totalAmountDispWayCd )
            {
                case 1:
                    // 総額表示する
                    return 1;
                case 0:
                default:
                    {
                        // 総額表示しない

                        switch ( consTaxLayMethod )
                        {
                            // 0:伝票単位
                            case 0:
                                return 0;
                            // 1:明細単位
                            case 1:
                                return 1;
                            // 2:請求親
                            case 2:
                            // 3:請求子
                            case 3:
                            // 9:非課税
                            case 9:
                            default:
                                return 2;
                        }
                    }
            }
        }
        /// <summary>
        /// 粗利(明細)算出
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Int64 GetGrossProfitDetail( CustPrtPprSalTblRsltWork data )
        {
            // --- UPD 2013/10/02 T.Miyamoto ------------------------------>>>>>
            //decimal grossProfit = (decimal)data.SalesMoneyTaxExc - (decimal)data.ShipmentCnt * (decimal)data.SalesUnitCost;
            //// 切り捨て
            //return (Int64)grossProfit;
            return data.SalesMoneyTaxExc - data.Cost;
            // --- UPD 2013/10/02 T.Miyamoto ------------------------------<<<<<
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/30 ADD

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  #7861 2011/11/23 ADD
        /// <summary>
        /// 粗利率(明細)算出
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private decimal GetGrossProfitMargin(CustPrtPprSalTblRsltWork data)
        {
            if (data.SalesMoneyTaxExc != 0)
            {
                decimal gpm = Convert.ToDecimal((data.SalesMoneyTaxExc - data.Cost) / (decimal)data.SalesMoneyTaxExc);

                return gpm;
            }
            else
                return 0;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  #7861 2011/11/23 ADD

        /// <summary>
        /// 残高一覧取得
        /// </summary>
        /// <param name="custPrtPprBlnce"></param>
        /// <param name="remainType">0: 請求 1: 売掛</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 DEL
        //public int SearchBalance(CustPrtPprBlnce custPrtPprBlnce, int remainType)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
        public int SearchBalance( ref CustPrtPprBlnce custPrtPprBlnce, int remainType )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
            CustPrtPprBlnce custPrtPprBlnceBackup = custPrtPprBlnce.Clone();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD

            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                // クリア
                this._dataSet.BalanceList.Rows.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/23 ADD
                //---------------------------------
                // 入力チェック
                //---------------------------------
                # region [入力チェック]
                // 拠点コード
                if ( custPrtPprBlnce.SectionCode == null || custPrtPprBlnce.SectionCode.Length == 0 )
                {
                    custPrtPprBlnce.SectionCode = new string[] { "00" };
                }
                string sectionCode = custPrtPprBlnce.SectionCode[0].Trim();

                //-----------------------------------------------------------
                // 得意先・請求先入力判定
                //-----------------------------------------------------------
                if ( custPrtPprBlnce.CustomerCode != 0 )
                {
                    // 得意先読み込み
                    CustomerInfo customer;
                    int readStatus = _customerInfoAcs.ReadDBData( ConstantManagement.LogicalMode.GetData0, custPrtPprBlnce.EnterpriseCode, custPrtPprBlnce.CustomerCode, true, true, out customer );
                    if ( readStatus != 0 || customer == null || customer.LogicalDeleteCode != 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    // UPD 2012/06/01 ----------------------->>>>>
                    //sectionCode = customer.MngSectionCode.Trim();
                    // 抽出拠点によりパラメータの拠点コードを選択する
                    if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                    {
                        sectionCode = customer.MngSectionCode.Trim();
                    }
                    else
                    {
                        sectionCode = customer.ClaimSectionCode.Trim();
                    }
                    // UPD 2012/06/01 -----------------------<<<<<

                    if (custPrtPprBlnce.ClaimCode != 0)
                    {
                        //----------------------------------------------
                        // 得意先＋請求先
                        //----------------------------------------------

                        // 親子関係判定
                        if ( customer.ClaimCode == custPrtPprBlnce.ClaimCode && customer.ClaimSectionCode.Trim() == sectionCode )
                        {
                            custPrtPprBlnce.CustomerCode = 0;
                            custPrtPprBlnce.ClaimCode = customer.ClaimCode;
                            custPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    else
                    {
                        //----------------------------------------------
                        // 得意先のみ
                        //----------------------------------------------
                        if ( customer.CustomerCode == customer.ClaimCode )
                        {
                            custPrtPprBlnce.CustomerCode = 0;
                            custPrtPprBlnce.ClaimCode = customer.ClaimCode;
                            custPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    // 拠点更新
                    if ( UpdateSection != null )
                    {
                        // UPD 2012/06/01 ----------------------->>>>>
                        //UpdateSection( this, customer.MngSectionCode, customer.MngSectionName );
                        // 抽出拠点によりパラメータの拠点コードを選択する
                        if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                        {
                            UpdateSection(this, customer.MngSectionCode, customer.MngSectionName);
                        }
                        else
                        {
                            UpdateSection(this, customer.ClaimSectionCode, customer.ClaimSectionName);
                        }
                        // UPD 2012/06/01 -----------------------<<<<<
                    }
                }
                else
                {
                    if ( custPrtPprBlnce.ClaimCode != 0 )
                    {
                        //----------------------------------------------
                        // 請求先のみ
                        //----------------------------------------------

                        // 請求先読み込み
                        CustomerInfo claim;
                        int readStatus = _customerInfoAcs.ReadDBData( ConstantManagement.LogicalMode.GetData0, custPrtPprBlnce.EnterpriseCode, custPrtPprBlnce.ClaimCode, true, true, out claim );
                        if ( readStatus != 0 || claim == null || claim.LogicalDeleteCode != 0 )
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        // UPD 2012/06/01 ----------------------->>>>>
                        //sectionCode = claim.MngSectionCode.Trim();
                        // 抽出拠点によりパラメータの拠点コードを選択する
                        if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                        {
                            sectionCode = claim.MngSectionCode.Trim();
                        }
                        else
                        {
                            sectionCode = claim.ClaimSectionCode.Trim();
                        }
                        // UPD 2012/06/01 -----------------------<<<<<

                        // 親子判定
                        if ( claim.ClaimCode == claim.CustomerCode && claim.ClaimSectionCode.Trim() == sectionCode )
                        {
                            custPrtPprBlnce.CustomerCode = 0;
                            custPrtPprBlnce.ClaimCode = claim.CustomerCode;
                            custPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        // 拠点更新
                        if ( UpdateSection != null )
                        {
                            // UPD 2012/06/01 ----------------------->>>>>
                            //UpdateSection(this, claim.MngSectionCode, claim.MngSectionName);
                            // 抽出拠点によりパラメータの拠点コードを選択する
                            if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                            {
                                UpdateSection(this, claim.MngSectionCode, claim.MngSectionName);
                            }
                            else
                            {
                                UpdateSection(this, claim.ClaimSectionCode, claim.ClaimSectionName);
                            }
                            // UPD 2012/06/01 -----------------------<<<<<
                        }
                    }
                    else
                    {
                        //----------------------------------------------
                        // (両方とも入力なし)
                        //----------------------------------------------
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/23 ADD

                //---------------------------------
                // パラメータクラスを作成
                //---------------------------------
                CustPrtPprBlnceWork custPrtPprBlnceWork = new CustPrtPprBlnceWork();
                CustPrtPprBlnce2CustPrtPprBlnceWork( ref custPrtPprBlnce, ref custPrtPprBlnceWork );

                //---------------------------------
                // 返り値で使用するクラスを作成
                //---------------------------------
                CustPrtPprBlTblRsltWork custPrtPprBlTblRsltWork = new CustPrtPprBlTblRsltWork();
                object custPrtPprBlTblRsltWorkObj = (object)custPrtPprBlTblRsltWork;
                // --- DEL 2020/12/21 警告対応 ---------->>>>>
                //long counter = 0;
                // --- DEL 2020/12/21 警告対応 ----------<<<<<
                int status;

                // readMode, logicalModeは現状未使用
                status = this._iCustPrtPprWorkDB.SearchBlTbl( ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0 );
                int rowNo = 0;
                // --- DEL m.suzuki 2010/12/20 ---------->>>>>
                # region // DEL
                //// 2010/04/15 Add 請求一覧表リモートから残高取得 >>>
                //DemandPrintAcs demandPrintAcs = new DemandPrintAcs();
                //ExtrInfo_DemandTotal extrInfoDemandTotal = new ExtrInfo_DemandTotal();
                //bool isOptSection = false;
                //bool isMainOfficeFunc = false;
                //string demandSectionCode;
                //Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
                //// 拠点オプションチェック
                //if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
                //{
                //    isOptSection = true;
                //}
                //else
                //{
                //    isOptSection = false;
                //#if CHG20060421
                //this._demandSectionCode = DemandPrintAcs.CT_AllSectionCode;
                //#else
                //#if CHG20060418
                //this._demandSectionCode = this._loginEmployee.BelongSectionCode;
                //#else
                //    demandSectionCode = loginEmployee.BelongSectionCode.TrimEnd();
                //#endif
                //#endif
                //    isMainOfficeFunc = demandPrintAcs.CheckMainOfficeFunc(loginEmployee.BelongSectionCode);
                //}
                //extrInfoDemandTotal.EnterpriseCode = custPrtPprBlnce.EnterpriseCode;
                //extrInfoDemandTotal.ResultsAddUpSecList = new string[1];
                //extrInfoDemandTotal.ResultsAddUpSecList[0] = sectionCode;
                //extrInfoDemandTotal.IsSelectAllSection = false;
                //extrInfoDemandTotal.IsOutputAllSecRec = false;
                //extrInfoDemandTotal.CustomerCodeSt = custPrtPprBlnce.ClaimCode;
                //extrInfoDemandTotal.CustomerCodeEd = custPrtPprBlnce.ClaimCode;
                //extrInfoDemandTotal.AccRecDivCd = 1;
                //extrInfoDemandTotal.DmdDtl = 1;
                //extrInfoDemandTotal.BalanceDepositDtl = 1;
                //extrInfoDemandTotal.IsMainOfficeFunc = isMainOfficeFunc;
                //extrInfoDemandTotal.IsOptSection = isOptSection;
                //string message;
                //string errDspMsg = null;
                //// 2010/04/15 Add <<<
                # endregion
                // --- DEL m.suzuki 2010/12/20 ----------<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 取得した結果をデータセットにセット
                    foreach (CustPrtPprBlTblRsltWork data in (ArrayList)custPrtPprBlTblRsltWorkObj)
                    {
                        // --- DEL m.suzuki 2010/12/20 ---------->>>>>
                        # region // DEL
                        //// 2010/04/15 Add 請求一覧表リモートから残高取得 >>>
                        //if (remainType == 0)
                        //{
                        //    extrInfoDemandTotal.AddUpDate = data.AddUpDate;
                        //    status = demandPrintAcs.SearchDemandList(extrInfoDemandTotal, out message, out errDspMsg);
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    {
                        //        RsltInfo_DemandTotalWork rsltInfoDemandTotalWork = new RsltInfo_DemandTotalWork();
                        //        if (demandPrintAcs.CustDmdPrcDataTable.Rows.Count != 0)
                        //        {
                        //            DataRow dr = demandPrintAcs.CustDmdPrcDataTable.Rows[0];

                        //            data.LastTimeBlc = Convert.ToInt64(dr["DemandBalance"]);
                        //        }
                        //    }
                        //}
                        //// 2010/04/15 Add <<<
                        # endregion
                        // --- DEL m.suzuki 2010/12/20 ----------<<<<<
                        try
                        {
                            DataRow row = this._dataSet.BalanceList.NewRow();

                            #region 残高一覧データ

                            row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo;
                            row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate;
                            row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc;

                            row[this._dataSet.BalanceList.ThisTimeDmdNrmlColumn.ColumnName] = data.ThisTimeDmdNrml;
                            row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc;
                            row[this._dataSet.BalanceList.ThisTimeSalesColumn.ColumnName] = data.ThisTimeSales;
                            row[this._dataSet.BalanceList.SalesPriceRgdsDisColumn.ColumnName] = data.SalesPricRgdsDis;
                            row[this._dataSet.BalanceList.OfsThisTimeSalesColumn.ColumnName] = data.OfsThisTimeSales;
                            row[this._dataSet.BalanceList.OfsThisSalesTaxColumn.ColumnName] = data.OfsThisSalesTax;
                            row[this._dataSet.BalanceList.AfCalBlcColumn.ColumnName] = data.AfCalBlc;
                            row[this._dataSet.BalanceList.SalesSlipCountColumn.ColumnName] = data.SalesSlipCount;
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/07 ADD
                            row[this._dataSet.BalanceList.ThisSalesPricTotalColumn.ColumnName] = data.OfsThisTimeSales + data.OfsThisSalesTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/07 ADD

                            this._dataSet.BalanceList.Rows.Add(row);

                            #endregion // 残高一覧データ

                            rowNo++;

                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 DEL
                        //catch (ConstraintException)
                        //{
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/25 ADD
                        catch (Exception exception)
                        {
                            string msg = exception.Message;
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/25 ADD
                    }   // 2010/04/15 Add 請求一覧表リモートから残高取得
                }


                return status;
            }
            finally
            {
                custPrtPprBlnce = custPrtPprBlnceBackup;
            }
        }

        // 2010/04/15 Add >>>
        /// <summary>
        /// 指定された得意先の範囲で残高リストを作成します。
        /// </summary>
        /// <param name="custPrtPprBlnce">検索条件</param>
        /// <param name="remainType">残高種別</param>
        /// <param name="customerList">得意先リスト</param>
        /// <returns>status</returns>
        /// <br>Update Note : 2010/09/28 tianjw</br>
        /// <br>              Redmine #15080 テキスト出力対応</br>
        // --- UPD 2010/09/26 ---------->>>>>
        // public int SearchBalanceAll(ref CustPrtPprBlnce custPrtPprBlnce, int remainType, List<int> customerList)
        public int SearchBalanceAll(ref CustPrtPprBlnce custPrtPprBlnce, int remainType, List<CustomerInfo> customerList)
        // --- UPD 2010/09/26 ----------<<<<<
        {
            CustPrtPprBlnce custPrtPprBlnceBackup = custPrtPprBlnce.Clone();

            try
            {
                // クリア
                this._dataSet.BalanceList.Rows.Clear();

                string sectionCodeSt;
                string sectionCodeEd;

                //---------------------------------
                // 入力チェック
                //---------------------------------
                // 拠点コード
                if (custPrtPprBlnce.SectionCode == null || custPrtPprBlnce.SectionCode.Length == 0)
                {
                    custPrtPprBlnce.SectionCode = new string[] { "00" };
                    sectionCodeSt = "00";
                    sectionCodeEd = "00";
                }
                else
                {
                    sectionCodeSt = custPrtPprBlnce.SectionCode[0].Trim();
                    sectionCodeEd = custPrtPprBlnce.SectionCode[custPrtPprBlnce.SectionCode.Length - 1].Trim();
                }
                string sectionCode = custPrtPprBlnce.SectionCode[0].Trim();

                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                int rowNo = 0;

                // --- UPD 2010/09/26 ---------->>>>>
                //foreach (int customerCode in customerList)
                foreach (CustomerInfo customer in customerList)
                // --- UPD 2010/09/26 ----------<<<<<
                {
                    int customerCode = customer.CustomerCode;
                    if (customerCode != 0)
                    {
                        // --- DEL 2010/09/26 ---------->>>>>
                        // 得意先読み込み
                        //CustomerInfo customer;
                        //int readStatus = _customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, custPrtPprBlnce.EnterpriseCode, customerCode, true, true, out customer);
                        //if (readStatus != 0 || customer == null || customer.LogicalDeleteCode != 0)
                        //{
                        //    continue;
                        //}
                        // --- DEL 2010/09/26 ----------<<<<<
                        // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
                        //sectionCode = customer.MngSectionCode.Trim();
                        // 抽出拠点の種別によって拠点コードを選択する
                        if (custPrtPprBlnce.RemainSectionType.Equals((int)RemainSectionType.Mng))
                        {
                            sectionCode = customer.MngSectionCode.Trim();
                        }
                        else
                        {
                            sectionCode = customer.ClaimSectionCode.Trim();
                        }
                        // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
                        //----------------------------------------------
                        // 得意先のみ
                        //----------------------------------------------
                        if (customer.CustomerCode == customer.ClaimCode)
                        {
                            // ------------ UPD 2010/09/28 ------------------------------------>>>>>
                            //if (sectionCodeSt == "00" && sectionCodeEd == "00" ||
                            //    Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode) &&
                            //    Convert.ToInt32(sectionCodeEd) >= Convert.ToInt32(sectionCode))
                            if (sectionCodeSt == "00" && sectionCodeEd == "00" ||
                                Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode) &&
                                Convert.ToInt32(sectionCodeEd) >= Convert.ToInt32(sectionCode) ||
                                sectionCodeEd == "00" && Convert.ToInt32(sectionCodeSt) <= Convert.ToInt32(sectionCode))
                            // ------------ UPD 2010/09/28 ------------------------------------<<<<<
                            {
                                custPrtPprBlnce.CustomerCode = 0;
                                custPrtPprBlnce.ClaimCode = customer.ClaimCode;
                                custPrtPprBlnce.SectionCode[0] = sectionCode;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                        //---------------------------------
                        // パラメータクラスを作成
                        //---------------------------------
                        CustPrtPprBlnceWork custPrtPprBlnceWork = new CustPrtPprBlnceWork();
                        CustPrtPprBlnce2CustPrtPprBlnceWork(ref custPrtPprBlnce, ref custPrtPprBlnceWork);

                        //---------------------------------
                        // 返り値で使用するクラスを作成
                        //---------------------------------
                        CustPrtPprBlTblRsltWork custPrtPprBlTblRsltWork = new CustPrtPprBlTblRsltWork();
                        object custPrtPprBlTblRsltWorkObj = (object)custPrtPprBlTblRsltWork;

                        // readMode, logicalModeは現状未使用
                        // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
                        //status = this._iCustPrtPprWorkDB.SearchBlTbl(ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0);
                        if (custPrtPprBlnce.CreditMoneyOutputDiv)
                        {
                            // 残高一覧表示検索（与信残高出力用）
                            status = this._iCustPrtPprWorkDB.SearchBlTblOutput(ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0, custPrtPprBlnce.CreditMoneyOutputDiv);
                        }
                        else
                        {
                            // 残高一覧表示検索
                            status = this._iCustPrtPprWorkDB.SearchBlTbl(ref custPrtPprBlTblRsltWorkObj, custPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0);
                        }
                        // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            DemandPrintAcs demandPrintAcs = new DemandPrintAcs();
                            ExtrInfo_DemandTotal extrInfoDemandTotal = new ExtrInfo_DemandTotal();
                            bool isOptSection = false;
                            bool isMainOfficeFunc = false;
                            string demandSectionCode;
                            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
                            // 拠点オプションチェック
                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
                            {
                                isOptSection = true;
                            }
                            else
                            {
                                isOptSection = false;
#if CHG20060421
                this._demandSectionCode = DemandPrintAcs.CT_AllSectionCode;
#else
#if CHG20060418
				this._demandSectionCode = this._loginEmployee.BelongSectionCode;
#else
                                demandSectionCode = loginEmployee.BelongSectionCode.TrimEnd();
#endif
#endif
                                isMainOfficeFunc = demandPrintAcs.CheckMainOfficeFunc(loginEmployee.BelongSectionCode);
                            }
                            extrInfoDemandTotal.EnterpriseCode = customer.EnterpriseCode;
                            extrInfoDemandTotal.ResultsAddUpSecList = new string[1];
                            extrInfoDemandTotal.ResultsAddUpSecList[0] = sectionCode;
                            extrInfoDemandTotal.IsSelectAllSection = false;
                            extrInfoDemandTotal.IsOutputAllSecRec = false;
                            extrInfoDemandTotal.CustomerCodeSt = customerCode;
                            extrInfoDemandTotal.CustomerCodeEd = customerCode;
                            extrInfoDemandTotal.AccRecDivCd = 1;
                            extrInfoDemandTotal.DmdDtl = 1;
                            extrInfoDemandTotal.BalanceDepositDtl = 1;
                            extrInfoDemandTotal.IsMainOfficeFunc = isMainOfficeFunc;
                            extrInfoDemandTotal.IsOptSection = isOptSection;
                            string message;
                            string errDspMsg = null;
                            // 取得した結果をデータセットにセット
                            // UPD 2013/03/13 神姫産業-与信調査 対応----------------------------------------->>>>>
                            #region  DEL
                            //foreach (CustPrtPprBlTblRsltWork data in (ArrayList)custPrtPprBlTblRsltWorkObj)
                            //{
                            //    if (remainType == 0)
                            //    {
                            //        extrInfoDemandTotal.AddUpDate = data.AddUpDate;
                            //        status = demandPrintAcs.SearchDemandList(extrInfoDemandTotal, out message, out errDspMsg);
                            //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            //        {
                            //            RsltInfo_DemandTotalWork rsltInfoDemandTotalWork = new RsltInfo_DemandTotalWork();
                            //            if (demandPrintAcs.CustDmdPrcDataTable.Rows.Count != 0)
                            //            {
                            //                DataRow dr = demandPrintAcs.CustDmdPrcDataTable.Rows[0];

                            //                data.LastTimeBlc = Convert.ToInt64(dr["DemandBalance"]);
                            //            }
                            //        }
                            //    }
                            //    try
                            //    {
                            //        DataRow row = this._dataSet.BalanceList.NewRow();

                            //        #region 残高一覧データ

                            //        row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo;
                            //        row[this._dataSet.BalanceList.CustomerNameColumn.ColumnName] = customer.CustomerSnm;
                            //        row[this._dataSet.BalanceList.CustomerCodeColumn.ColumnName] = customer.CustomerCode;
                            //        row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = sectionCode;
                            //        row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate;
                            //        row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc;
                            //        row[this._dataSet.BalanceList.ThisTimeDmdNrmlColumn.ColumnName] = data.ThisTimeDmdNrml;
                            //        row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc;
                            //        row[this._dataSet.BalanceList.ThisTimeSalesColumn.ColumnName] = data.ThisTimeSales;
                            //        row[this._dataSet.BalanceList.SalesPriceRgdsDisColumn.ColumnName] = data.SalesPricRgdsDis;
                            //        row[this._dataSet.BalanceList.OfsThisTimeSalesColumn.ColumnName] = data.OfsThisTimeSales;
                            //        row[this._dataSet.BalanceList.OfsThisSalesTaxColumn.ColumnName] = data.OfsThisSalesTax;
                            //        row[this._dataSet.BalanceList.AfCalBlcColumn.ColumnName] = data.AfCalBlc;
                            //        row[this._dataSet.BalanceList.SalesSlipCountColumn.ColumnName] = data.SalesSlipCount;
                            //        row[this._dataSet.BalanceList.ThisSalesPricTotalColumn.ColumnName] = data.OfsThisTimeSales + data.OfsThisSalesTax;
                            //        this._dataSet.BalanceList.Rows.Add(row);

                            //        #endregion // 残高一覧データ

                            //        rowNo++;

                            //    }
                            //    catch (Exception exception)
                            //    {
                            //        string msg = exception.Message;
                            //        break;
                            //    }
                            //}
                            #endregion
                            // 与信残高出力の時
                            if (custPrtPprBlnce.CreditMoneyOutputDiv)
                            {
                                foreach (CustPrtPprBlTblRsltWork data in (ArrayList)custPrtPprBlTblRsltWorkObj)
                                {
                                    // 開始年月の前月のデータは出力対象外とする
                                    if (data.AddUpYearMonth < custPrtPprBlnce.Input_St_AddUpYearMonth)
                                    {
                                        continue;
                                    }
                                    if (remainType == 0)
                                    {
                                        extrInfoDemandTotal.AddUpDate = data.AddUpDate;
                                        status = demandPrintAcs.SearchDemandList(extrInfoDemandTotal, out message, out errDspMsg);
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            RsltInfo_DemandTotalWork rsltInfoDemandTotalWork = new RsltInfo_DemandTotalWork();
                                            if (demandPrintAcs.CustDmdPrcDataTable.Rows.Count != 0)
                                            {
                                                DataRow dr = demandPrintAcs.CustDmdPrcDataTable.Rows[0];

                                                data.LastTimeBlc = Convert.ToInt64(dr["DemandBalance"]);
                                            }
                                        }
                                    }
                                    try
                                    {
                                        DataRow row = this._dataSet.BalanceList.NewRow();

                                        #region 残高一覧データ

                                        row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo;
                                        row[this._dataSet.BalanceList.CustomerNameColumn.ColumnName] = customer.CustomerSnm;
                                        row[this._dataSet.BalanceList.CustomerCodeColumn.ColumnName] = customer.CustomerCode;
                                        row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = sectionCode;
                                        row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate;
                                        row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc;
                                        row[this._dataSet.BalanceList.ThisTimeDmdNrmlColumn.ColumnName] = data.ThisTimeDmdNrml;
                                        row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc;
                                        row[this._dataSet.BalanceList.ThisTimeSalesColumn.ColumnName] = data.ThisTimeSales;
                                        row[this._dataSet.BalanceList.SalesPriceRgdsDisColumn.ColumnName] = data.SalesPricRgdsDis;
                                        row[this._dataSet.BalanceList.OfsThisTimeSalesColumn.ColumnName] = data.OfsThisTimeSales;
                                        row[this._dataSet.BalanceList.OfsThisSalesTaxColumn.ColumnName] = data.OfsThisSalesTax;
                                        row[this._dataSet.BalanceList.AfCalBlcColumn.ColumnName] = data.AfCalBlc;
                                        row[this._dataSet.BalanceList.SalesSlipCountColumn.ColumnName] = data.SalesSlipCount;
                                        row[this._dataSet.BalanceList.ThisSalesPricTotalColumn.ColumnName] = data.OfsThisTimeSales + data.OfsThisSalesTax;
                                        row[this._dataSet.BalanceList.ClaimSectionCodeColumn.ColumnName] = customer.ClaimSectionCode;
                                        // 与信区分
                                        string creditMngCodeName = string.Empty;
                                        if (data.CreditMngCode.Equals(0)) creditMngCodeName = "0:しない";
                                        else creditMngCodeName = "1:する";
                                        row[this._dataSet.BalanceList.CreditMngCodeColumn.ColumnName] = creditMngCodeName;
                                        row[this._dataSet.BalanceList.CreditMoneyColumn.ColumnName] = data.CreditMoney;
                                        row[this._dataSet.BalanceList.WarningCreditMoneyColumn.ColumnName] = data.WarningCreditMoney;
                                        row[this._dataSet.BalanceList.PrsntAccRecBalanceColumn.ColumnName] = data.PrsntAccRecBalance;
                                        row[this._dataSet.BalanceList.TotalDayColumn.ColumnName] = customer.TotalDay;
                                        row[this._dataSet.BalanceList.CompanyTotalDayColumn.ColumnName] = data.CompanyTotalDay;
                                        // 請求・月次差異額
                                        // 請求締日・自社締日が同じ時
                                        if (customer.TotalDay.Equals(data.CompanyTotalDay))
                                        {
                                            // 前月データ取得
                                            long difference = 0;
                                            foreach (CustPrtPprBlTblRsltWork data2 in (ArrayList)custPrtPprBlTblRsltWorkObj)
                                            {
                                                if (data2.AddUpYearMonth < data.AddUpYearMonth) difference = data2.AfCalDemandPrice - data2.AfCalBlc;
                                                if (data2.AddUpYearMonth >= data.AddUpYearMonth) break;
                                            }
                                            row[this._dataSet.BalanceList.DifferenceColumn.ColumnName] = difference.ToString("#,##0;-#,##0;");
                                            row[this._dataSet.BalanceList.CreditDifferenceColumn.ColumnName] = data.PrsntAccRecBalance - difference - data.AfCalBlc;
                                        }
                                        else
                                        {
                                            row[this._dataSet.BalanceList.DifferenceColumn.ColumnName] = "-";
                                            row[this._dataSet.BalanceList.CreditDifferenceColumn.ColumnName] = data.PrsntAccRecBalance - data.AfCalBlc;
                                        }
                                        // 売掛区分
                                        string accRecDivCdName = string.Empty;
                                        if (data.AccRecDivCd.Equals(0)) accRecDivCdName = "0:売掛なし";
                                        else accRecDivCdName = "1:売掛";
                                        row[this._dataSet.BalanceList.AccRecDivCdColumn.ColumnName] = accRecDivCdName;

                                        // ADD 2013/04/12 zhujw Redmine#35205 --------------------->>>>>
                                        //月次更新日より未来のレコードにおける≪与信区分,与信額,警告与信額,与信売掛残高,請求締日,月次締日,請求・月次差異額,与信額差異,売掛区分≫については全て空白で出力
                                        if (data.CreditMngCode.Equals(2))
                                        {
                                            row[this._dataSet.BalanceList.CreditMngCodeColumn.ColumnName] = string.Empty;
                                            row[this._dataSet.BalanceList.CreditMoneyColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.WarningCreditMoneyColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.PrsntAccRecBalanceColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.TotalDayColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.CompanyTotalDayColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.DifferenceColumn.ColumnName] = string.Empty;
                                            row[this._dataSet.BalanceList.CreditDifferenceColumn.ColumnName] = DBNull.Value;
                                            row[this._dataSet.BalanceList.AccRecDivCdColumn.ColumnName] = string.Empty;
                                        }
                                        // ADD 2013/04/12 zhujw Redmine#35205 ---------------------<<<<<

                                        this._dataSet.BalanceList.Rows.Add(row);

                                        #endregion // 残高一覧データ

                                        rowNo++;

                                    }
                                    catch (Exception exception)
                                    {
                                        string msg = exception.Message;
                                        break;
                                    }
                                }
                            }
                            // 与信残高出力なしの時
                            else
                            {
                                foreach (CustPrtPprBlTblRsltWork data in (ArrayList)custPrtPprBlTblRsltWorkObj)
                                {
                                    if (remainType == 0)
                                    {
                                        extrInfoDemandTotal.AddUpDate = data.AddUpDate;
                                        status = demandPrintAcs.SearchDemandList(extrInfoDemandTotal, out message, out errDspMsg);
                                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                        {
                                            RsltInfo_DemandTotalWork rsltInfoDemandTotalWork = new RsltInfo_DemandTotalWork();
                                            if (demandPrintAcs.CustDmdPrcDataTable.Rows.Count != 0)
                                            {
                                                DataRow dr = demandPrintAcs.CustDmdPrcDataTable.Rows[0];

                                                data.LastTimeBlc = Convert.ToInt64(dr["DemandBalance"]);
                                            }
                                        }
                                    }
                                    try
                                    {
                                        DataRow row = this._dataSet.BalanceList.NewRow();

                                        #region 残高一覧データ

                                        row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo;
                                        row[this._dataSet.BalanceList.CustomerNameColumn.ColumnName] = customer.CustomerSnm;
                                        row[this._dataSet.BalanceList.CustomerCodeColumn.ColumnName] = customer.CustomerCode;
                                        row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = sectionCode;
                                        row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate;
                                        row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc;
                                        row[this._dataSet.BalanceList.ThisTimeDmdNrmlColumn.ColumnName] = data.ThisTimeDmdNrml;
                                        row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc;
                                        row[this._dataSet.BalanceList.ThisTimeSalesColumn.ColumnName] = data.ThisTimeSales;
                                        row[this._dataSet.BalanceList.SalesPriceRgdsDisColumn.ColumnName] = data.SalesPricRgdsDis;
                                        row[this._dataSet.BalanceList.OfsThisTimeSalesColumn.ColumnName] = data.OfsThisTimeSales;
                                        row[this._dataSet.BalanceList.OfsThisSalesTaxColumn.ColumnName] = data.OfsThisSalesTax;
                                        row[this._dataSet.BalanceList.AfCalBlcColumn.ColumnName] = data.AfCalBlc;
                                        row[this._dataSet.BalanceList.SalesSlipCountColumn.ColumnName] = data.SalesSlipCount;
                                        row[this._dataSet.BalanceList.ThisSalesPricTotalColumn.ColumnName] = data.OfsThisTimeSales + data.OfsThisSalesTax;
                                        this._dataSet.BalanceList.Rows.Add(row);

                                        #endregion // 残高一覧データ

                                        rowNo++;

                                    }
                                    catch (Exception exception)
                                    {
                                        string msg = exception.Message;
                                        break;
                                    }
                                }
                            }
                            // UPD 2013/03/13 神姫産業-与信調査 対応-----------------------------------------<<<<<

                        }
                    }
                }

                return status;
            }
            // --- UPD 2020/12/21 警告対応 ---------->>>>>
            //catch(Exception ex)
            catch (Exception)
            // --- UPD 2020/12/21 警告対応 ----------<<<<<
            {
                throw;
            }
            finally
            {
                custPrtPprBlnce = custPrtPprBlnceBackup;
            }
        }
        // 2010/04/15 Add <<<
        // ------------DEL wangf 2013/01/30 FOR Redmine#34513--------->>>>
        //// ------------ADD wangf 2013/01/30 FOR Redmine#34513--------->>>>
        ///// <summary>
        ///// ログメッセージ記録
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="pgName">PG名</param>
        ///// <param name="message">メッセージ</param>
        ///// <param name="logDataObjAssemblyID">アセンブリ名</param>
        ///// <param name="logDataOperationCd">処理区分</param>
        ///// <param name="belongSectionCode">ログイン拠点</param>
        ///// <remarks>
        ///// <br>Note		: ログメッセージ記録を行う。</br>
        ///// <br>Programmer	: wangf</br>
        ///// <br>Date		: 2013/01/30</br>
        ///// </remarks>
        //public void WriteLogMessage(string enterpriseCode, string pgName, string message, string logDataObjAssemblyID, int logDataOperationCd, string belongSectionCode)
        //{
        //    ArrayList writeList = new ArrayList();
        //    OprtnHisLogWork oprtnhislogWork = new OprtnHisLogWork();
        //    # region [書き込み内容のセット]
        //    Broadleaf.Library.Diagnostics.LogTextData logTextData = new Broadleaf.Library.Diagnostics.LogTextData("", "", 0, new Exception());
        //    oprtnhislogWork.EnterpriseCode = enterpriseCode;
        //    oprtnhislogWork.LogDataObjAssemblyID = logDataObjAssemblyID;
        //    oprtnhislogWork.LogDataObjAssemblyNm = pgName;
        //    oprtnhislogWork.LogDataObjClassID = this.GetType().Name;
        //    oprtnhislogWork.LogDataOperationCd = logDataOperationCd;
        //    oprtnhislogWork.LogDataMassage = message;
        //    oprtnhislogWork.LogDataCreateDateTime = DateTime.Now;
        //    oprtnhislogWork.LogDataMachineName = logTextData.GenerationServerUserId;
        //    oprtnhislogWork.LoginSectionCd = belongSectionCode;
        //    # endregion
        //    writeList.Add(oprtnhislogWork);
        //    object writeObj = writeList;
        //    _iOprtnHisLogDB.Write(ref writeObj);
        //}
        //// ------------ADD wangf 2013/01/30 FOR Redmine#34513---------<<<<
        // ------------DEL wangf 2013/01/30 FOR Redmine#34513---------<<<<

        /// <summary>
        /// 検索結果からデータテーブルを作成
        /// </summary>
        /// <param name="custPrtPprSalTblRsltWork">検索結果クラス</param>
        /// <returns></returns>
        private bool AddRowDataFromSearchResult(CustPrtPprSalTblRsltWork custPrtPprSalTblRsltWork)
        {
            // 伝票・明細検索結果クラスよりデータセットを作成

            DataRow newDetailRow = this._dataSet.SalesDetail.NewRow();      // 明細
            DataRow newSlipRow = this._dataSet.SalesList.NewRow();          // 伝票
            

            //newDetailRow[

            return true;
        }

        /// <summary>
        /// パラメータクラス(PMKAU04002E.CustPrtPpr)からリモートパラメータクラス(PMKAU04016D.CustPrtPprWork)クラスへ変換
        /// </summary>
        /// <param name="custPrtPpr"></param>
        /// <param name="custPrtPprWork"></param>
        /// <br>Update Note : 2011/11/28 楊洋 得意先電子元帳/(BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑ)問合せ番号の追加</br>
        /// <br>Update Note : K2015/06/16 鮑晶</br>
        /// <br>管理番号    : 11101427-00</br>
        /// <br>            : メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
        /// <br>Update Note : 2016/01/21 脇田 靖之</br>
        /// <br>管理番号    : 11270007-00</br>
        /// <br>            : 仕掛一覧№2808 貸出受注対応</br>
        /// <br>            : ①検索条件に「出荷状況」項目を追加</br>
        /// <br>            : ②明細表示に計上数、未計上数項目を追加</br>
        /// <br>Update Note : K2016/02/23 時シン</br>
        /// <br>              ㈱イケモト 抽出条件にて受注作成区分を追加する対応</br>
        private void CustPrtPpr2CustPrtPprWork(ref CustPrtPpr custPrtPpr, ref CustPrtPprWork custPrtPprWork)
        {
            custPrtPprWork.AcptAnOdrStatus = custPrtPpr.AcptAnOdrStatus;
            custPrtPprWork.BLGoodsCode = custPrtPpr.BLGoodsCode;
            custPrtPprWork.BLGroupCode = custPrtPpr.BLGroupCode;
            custPrtPprWork.CarMngCode = custPrtPpr.CarMngCode;
            custPrtPprWork.ClaimCode = custPrtPpr.ClaimCode;
            custPrtPprWork.ColorName1 = custPrtPpr.ColorName1;
            custPrtPprWork.CustomerCode = custPrtPpr.CustomerCode;
            custPrtPprWork.DataSendCode = custPrtPpr.DataSendCode;
            custPrtPprWork.DtlNote = custPrtPpr.DtlNote;
            custPrtPprWork.Ed_AddUpADate = custPrtPpr.Ed_AddUpADate;
            custPrtPprWork.Ed_SalesDate = custPrtPpr.Ed_SalesDate;
            custPrtPprWork.EnterpriseCode = custPrtPpr.EnterpriseCode;
            custPrtPprWork.EnterpriseGanreCode = custPrtPpr.EnterpriseGanreCode;
            custPrtPprWork.FrontEmployeeCd = custPrtPpr.FrontEmployeeCd;
            custPrtPprWork.FullModel = custPrtPpr.FullModel;
            custPrtPprWork.GoodsMakerCd = custPrtPpr.GoodsMakerCd;
            custPrtPprWork.GoodsName = custPrtPpr.GoodsName;
            custPrtPprWork.GoodsNo = custPrtPpr.GoodsNo;
            custPrtPprWork.ModelFullName = custPrtPpr.ModelFullName;
            custPrtPprWork.PartySaleSlipNum = custPrtPpr.PartySaleSlipNum;
            custPrtPprWork.SalesCode = custPrtPpr.SalesCode;
            custPrtPprWork.SalesEmployeeCd = custPrtPpr.SalesEmployeeCd;
            custPrtPprWork.SalesInputCode = custPrtPpr.SalesInputCode;
            custPrtPprWork.SalesOrderDivCd = custPrtPpr.SalesOrderDivCd;
            custPrtPprWork.SalesSlipCd = custPrtPpr.SalesSlipCd;
            custPrtPprWork.SalesSlipNum = custPrtPpr.SalesSlipNum;
            custPrtPprWork.SearchCnt = custPrtPpr.SearchCnt;
            custPrtPprWork.SearchFrameNo = custPrtPpr.SearchFrameNo;
            custPrtPprWork.FrameNo = custPrtPpr.FrameNo;// ADD 2010/08/05
            custPrtPprWork.SearchType = custPrtPpr.SearchType;
            custPrtPprWork.SectionCode = custPrtPpr.SectionCode;
            custPrtPprWork.SlipNote = custPrtPpr.SlipNote;
            custPrtPprWork.SlipNote2 = custPrtPpr.SlipNote2;
            custPrtPprWork.SlipNote3 = custPrtPpr.SlipNote3;
            custPrtPprWork.St_AddUpADate = custPrtPpr.St_AddUpADate;
            custPrtPprWork.St_SalesDate = custPrtPpr.St_SalesDate;
            custPrtPprWork.SupplierCd = custPrtPpr.SupplierCd;
            custPrtPprWork.SupplierSlipNo = custPrtPpr.SupplierSlipNo;
            custPrtPprWork.TrimName = custPrtPpr.TrimName;
            custPrtPprWork.UoeRemark1 = custPrtPpr.UoeRemark1;
            custPrtPprWork.UoeRemark2 = custPrtPpr.UoeRemark2;
            custPrtPprWork.UOESupplierCd = custPrtPpr.UOESupplierCd;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/06 ADD
            custPrtPprWork.AddresseeCode = custPrtPpr.AddresseeCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/06 ADD
            custPrtPprWork.WarehouseCode = custPrtPpr.WarehouseCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/17 ADD
            custPrtPprWork.GoodsKindCode = custPrtPpr.GoodsKindCode; // 商品属性
            custPrtPprWork.GoodsLGroup = custPrtPpr.GoodsLGroup; // 商品大分類コード
            custPrtPprWork.GoodsMGroup = custPrtPpr.GoodsMGroup; // 商品中分類コード
            custPrtPprWork.WarehouseShelfNo = custPrtPpr.WarehouseShelfNo; // 棚番
            custPrtPprWork.SalesSlipCdDtl = custPrtPpr.SalesSlipCdDtl; // 売上伝票区分(明細)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/17 ADD
            custPrtPprWork.AutoAnswerDivSCM = custPrtPpr.AutoAnswerDivSCM; // 自動回答// add 2011/07/18 朱宝軍
            //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
            custPrtPprWork.InquiryNumber = custPrtPpr.InquiryNumber; //問合せ番号
            //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<
            // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
            custPrtPprWork.AddUpRemDiv = custPrtPpr.AddUpRemDiv;    // 出荷状況
            // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
            custPrtPprWork.SalesAreaCode = custPrtPpr.SalesAreaCode;
            custPrtPprWork.CustAnalysCode1 = custPrtPpr.CustAnalysCode1;
            custPrtPprWork.CustAnalysCode2 = custPrtPpr.CustAnalysCode2;
            custPrtPprWork.CustAnalysCode3 = custPrtPpr.CustAnalysCode3;
            custPrtPprWork.CustAnalysCode4 = custPrtPpr.CustAnalysCode4;
            custPrtPprWork.CustAnalysCode5 = custPrtPpr.CustAnalysCode5;
            custPrtPprWork.CustAnalysCode6 = custPrtPpr.CustAnalysCode6;
            //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<
            custPrtPprWork.AcptAnOdrMakeDiv = custPrtPpr.AcptAnOdrMakeDiv; // ADD K2016/02/23 時シン ㈱イケモト 抽出条件にて受注作成区分を追加する対応
        }

        /// <summary>
        /// パラメータクラス(PMKAU04002E.CustPrtPprBlnce)からリモートパラメータクラス(PMKAU04016D.CustPrtPprBlnceWork)クラスへ変換
        /// </summary>
        /// <param name="custPrtPpr"></param>
        /// <param name="custPrtPprWork"></param>
        private void CustPrtPprBlnce2CustPrtPprBlnceWork(ref CustPrtPprBlnce custPrtPprBlnce, ref CustPrtPprBlnceWork custPrtPprBlnceWork)
        {
            custPrtPprBlnceWork.EnterpriseCode = custPrtPprBlnce.EnterpriseCode;
            custPrtPprBlnceWork.SectionCode = custPrtPprBlnce.SectionCode;
            custPrtPprBlnceWork.CustomerCode = custPrtPprBlnce.CustomerCode;
            custPrtPprBlnceWork.ClaimCode = custPrtPprBlnce.ClaimCode;
            custPrtPprBlnceWork.St_AddUpYearMonth = custPrtPprBlnce.St_AddUpYearMonth;
            custPrtPprBlnceWork.Ed_AddUpYearMonth = custPrtPprBlnce.Ed_AddUpYearMonth;
        }

        # region [残高表示情報]
        /// <summary>
        /// 残高表示情報
        /// </summary>
        public struct RemainDataExtra
        {
            /// <summary>今回売上</summary>
            private Int64 _ofsThisTimeSales;
            /// <summary>消費税</summary>
            private Int64 _ofsThisSalesTax;
            /// <summary>今回入金</summary>
            private Int64 _thisTimeDmdNrml;
            /// <summary>請求金額</summary>
            private Int64 _afCalBlc;
            /// <summary>締開始日</summary>
            private DateTime _dmdStDay;
            /// <summary>締処理日</summary>
            private DateTime _totalDay;
            /// <summary>親フラグ</summary>
            private bool _isParent;
            /// <summary>
            /// 今回売上
            /// </summary>
            public Int64 OfsThisTimeSales
            {
                get { return _ofsThisTimeSales; }
                set { _ofsThisTimeSales = value; }
            }
            /// <summary>
            /// 消費税
            /// </summary>
            public Int64 OfsThisSalesTax
            {
                get { return _ofsThisSalesTax; }
                set { _ofsThisSalesTax = value; }
            }
            /// <summary>
            /// 今回入金
            /// </summary>
            public Int64 ThisTimeDmdNrml
            {
                get { return _thisTimeDmdNrml; }
                set { _thisTimeDmdNrml = value; }
            }
            /// <summary>
            /// 請求金額
            /// </summary>
            public Int64 AfCalBlc
            {
                get { return _afCalBlc; }
                set { _afCalBlc = value; }
            }
            /// <summary>
            /// 締開始日
            /// </summary>
            public DateTime DmdStDay
            {
                get { return _dmdStDay; }
                set { _dmdStDay = value; }
            }
            /// <summary>
            /// 締処理日
            /// </summary>
            public DateTime TotalDay
            {
                get { return _totalDay; }
                set { _totalDay = value; }
            }
            /// <summary>
            /// 親フラグ
            /// </summary>
            public bool IsParent
            {
                get { return _isParent; }
                set { _isParent = value; }
            }
        }
        # endregion
    }
}
