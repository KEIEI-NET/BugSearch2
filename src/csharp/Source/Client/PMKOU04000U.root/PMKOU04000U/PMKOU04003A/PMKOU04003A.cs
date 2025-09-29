using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
//using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
// --- ADD 2012/09/13 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/09/13 ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入先電子元帳データ取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先電子元帳のアクセスクラスです。</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.09.09</br>
    /// <br></br>
    /// <br>UpdateNote : 2009.02.14 22018 鈴木正臣</br>
    /// <br>             ①全体的に修正。</br>
    /// <br></br>
    /// <br>Update Note: 2009/09/08 黄偉兵</br>
    /// <br>             PM.NS-2-B・ＰＭ．ＮＳ保守依頼①</br>
    /// <br>                       過去分表示対応</br>
    /// <br>Update Note: 2010/01/26 工藤恵優</br>
    /// <br>             MANTIS[14325]対応：インストール直後に仕入伝票×1と支払伝票×1を登録した状態で検索すると、仕入伝票が表示されない</br>
    /// <br>UpdateNote : 2010/01/27 30434 工藤 恵優</br>
    /// <br>           　障害ID:14545対応 得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み</br>
    /// <br>UpdateNote : 2010/07/20 chenyd</br>
    /// <br>           　テキスト出力対応</br>
    /// <br>UpdateNote : 2011/11/24 葛中華</br>
    /// <br>             redmine#8078　仕入先電子元帳/標準価格の並び順はおかしい</br>
    /// <br>UpdateNote : 2011/12/09 凌小青</br>
    /// <br>             支払データ検索エラーの対応</br>
    /// <br>Update Note: 2012/04/05 李小路</br>						
    /// <br>             2012/05/24配信分 Redmine#29310　合計欄の不具合についての修正</br>
    /// <br>Update Note: 2012/06/19 tianjw</br>
    /// <br>管理番号   : 10801804-00 2012/07/25配信分</br>
    /// <br>             Redmine#30529 税率参照の不具合の対応</br>
    /// <br>Update Note: 2012/06/26 伊藤 豊</br>
    /// <br>             電話対応No.1027 件数オーバー時にメッセージを表示</br>
    /// <br>Update Note: 2012/09/13 FSI上北田 秀樹</br>
    /// <br>             仕入先総括対応の追加</br> 
    /// <br>Update Note: 2012/10/15 田建委</br>
    /// <br>管理番号   : 10801804-00、2012/11/14配信分</br>
    /// <br>             Redmine#32862 価格変更した明細、色を変えるように修正</br>
    /// <br>Update Note: 2012/10/30 田建委</br>
    /// <br>管理番号   : 10801804-00、2012/11/14配信分</br>
    /// <br>             Redmine#32862#20 仕入データに入力区分「合計」で作成して、それを検索対象にした場合、システムエラーとなる修正</br>
    /// <br>Update Note: 2013/01/21 FSI冨樫 紗由里</br>
    /// <br>管理番号   : 10806793-00</br>
    /// <br>             [仕入返品計上] 1.選択チェックボックス設定追加,返品計上に必要なデータ処理追加</br>
    /// <br>                            2.返品予定データ検索機能追加</br>
    /// <br>Update Note: 2013/02/16 鄭慕鈞</br>　 
    /// <br>管理番号   : 10900691-00  2013/03/13配信分</br>
    /// <br>           : Redmine#34618 仕入先電子元帳の合計画面で消費税が合わない障害の修正</br>
    /// <br>Update Note: 2013/04/18 王君</br>
    /// <br>管理番号 　: 10801804-00 2013/05/15配信分</br>
    /// <br>           : Redmine#35363 仕入先電子元帳の伝票表示に背景色不具合の対応</br>
    /// <br>Update Note: 2013/05/15 huangt </br>
    /// <br>管理番号   : 10902175-00 6月18日配信分（障害以外）</br>
    /// <br>           : Redmine#35640 仕入先電子元帳 テキスト出力 消費税が出力されないの修正</br>
    /// <br>Update Note: 2013/11/25 huangt </br>
    /// <br>管理番号   : 10902175-00 6月18日配信分（障害以外）</br>
    /// <br>           : Redmine#35640 発注の場合は消費税を出力しないように修正</br>
    /// <br></br>
    /// </remarks>
    public partial class SuppPrtSlipSearchAcs
    {

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SuppPrtSlipSearchAcs()
        {
            // リモートインスタンス取得
            this._iSuppPrtPprWorkDB = MediationSuppPrtPprWorkDB.GetSuppPrtPprWorkDB();

            // データセットを作成
            this._dataSet = new SuppPtrStcDetailDataSet();

            // アクセスクラスを作成
            this._supplierAcs = new SupplierAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
            // 仕入集計リモート
            _iSuplierPayDB = MediationSuplierPayDB.GetSuplierPayDB();

            // 仕入先実績修正リモート
            _ISuppRsltUpdDB = MediationSuppRsltUpdDB.GetSuppRsltUpdDB();

            // 締日算出モジュール
            _ttlDayCalc = TotalDayCalculator.GetInstance();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

            // --- ADD 2012/09/13 ---------->>>>>
            this.CacheOptionInfo();
            // --- ADD 2012/09/13 ----------<<<<<
        }

        #endregion // コンストラクタ

        #region プライベート変数

        // リモートDB検索クラス インタフェースオブジェクト
        private ISuppPrtPprWorkDB _iSuppPrtPprWorkDB;

        // データセットクラス
        private SuppPtrStcDetailDataSet _dataSet;

        // 仕入先取得用アクセスクラス
        private SupplierAcs _supplierAcs;

        // 仕入先締め日
        private int _supplierCalcDate = 0;

        // 得意先指定フラグ（指定されていない場合は残高情報を表示しない）
        private bool _supplierPointed = true;
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
        // 仕入示集計リモート
        private ISuplierPayDB _iSuplierPayDB;

        // 仕入先実績修正リモート
        private ISuppRsltUpdDB _ISuppRsltUpdDB;

        // 締日算出モジュール
        private TotalDayCalculator _ttlDayCalc;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD
        // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ---------->>>>>
        // 抽出中断フラグ
        private bool _extractCancelFlag;
        // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ----------<<<<<

        // --- ADD 2012/09/13 ---------->>>>>
        // 仕入総括オプションフラグ
        private bool _opt_SupplierSummary;
        // --- ADD 2012/09/13 ----------<<<<<

        #endregion // プライベート変数

        // --- ADD 2012/09/13 ---------->>>>>
        #region 列挙体
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
        // --- ADD 2012/09/13 ----------<<<<<

        #region 定数

        #region 0詰め桁

        /// <summary>得意先コード 桁数:初期値 8</summary>
        private const int CT_DEPTH_CUSTOMERCODE = 8;

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

        #endregion

        #region 文字列定数

        /// <summary>黒伝時表示文字列 初期値 [空白]</summary>
        private const string CT_ACCPAYDIV_NAME_KURODEN = "";

        /// <summary>赤伝時表示文字列 初期値 [赤伝]</summary>
        private const string CT_ACCPAYDIV_NAME_AKADEN = "赤伝";

        /// <summary>元黒時表示文字列 初期値 [元黒]</summary>
        private const string CT_ACCPAYDIV_NAME_MOTOKURO = "元黒";

        /// <summary>仕入区分名表示文字列 初期値 [仕入]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_01 = "仕入";

        /// <summary>仕入区分名表示文字列 初期値 [返品]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_02 = "返品";

        /// <summary>仕入区分名表示文字列 初期値 [発注]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_03 = "発注";

        /// <summary>仕入区分名表示文字列 初期値 [入荷]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_04 = "入荷";

        /// <summary>仕入区分名表示文字列 初期値 [支払]</summary>
        private const string CT_SUPPLIERSLIPCD_NAME_05 = "支払";

        /// <summary>オープン価格表示文字列 初期値 [オープン価格]</summary>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
        //private const string CT_OPENPRICEDIV_NAME = "オープン価格";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
        private const string CT_OPENPRICEDIV_NAME = "ｵｰﾌﾟﾝ価格";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

        /// <summary>在庫取寄区分表示文字列 初期値 [取寄]</summary>
        private const string CT_STOCKORDERDIV_NAME_01 = "取寄";

        /// <summary>在庫取寄区分表示文字列 初期値 [在庫]</summary>
        private const string CT_STOCKORDERDIV_NAME_02 = "在庫";

        /// <summary>買掛区分表示文字列 初期値 [買掛]</summary>
        private const string CT_ACCPAYDIV_NAME_01 = "買掛";

        /// <summary>備考２有効期限表示文字列 初期値 [有効期限：]</summary>
        private const string CT_SUPPLIERNOTE2_PRE = "有効期限：";

        #endregion // 文字列定数

        #endregion

        #region プロパティ

        /// <summary>
        /// データセットオブジェクト 
        /// </summary>
        public SuppPtrStcDetailDataSet DataSet
        {
            get { return this._dataSet; }
            //set { this._dataSet = value; }
        }

        // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ---------->>>>>
        /// <summary>
        /// 抽出中断フラグ
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }
        // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ----------<<<<<

        // 2012/06/26 Y.Ito ADD START 画面で件数を確認するためのサーバから戻ってきた件数
        private long _searchCount;
        public long SearchCount
        {
            get { return _searchCount; }
            set { _searchCount = value; }
        }
        // 2012/06/26 Y.Ito ADD END 画面で件数を確認するためのサーバから戻ってきた件数

        #endregion // プロパティ

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
        public delegate void UpdateSectionEventHandler( object sender, string sectionCode, string sectionName );
        public event UpdateSectionEventHandler UpdateSection;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

        // ----- ADD 2012/06/19 tianjw Redmine#30529 ----->>>>>
        /// <summary>
        /// 税率設定取得処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public TaxRateSet GetTaxRateSet(string enterpriseCode, int taxRateCode)
        {
            TaxRateSet taxRateSet;
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs(); // 税率設定マスタ
            int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, taxRateCode);
            if (status != 0)
            {
                taxRateSet = new TaxRateSet();
            }

            return taxRateSet;
        }

        /// <summary>
        /// 税率設定の転嫁方式取得処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public int GetConsTaxLayMethod(string enterpriseCode, int taxRateCode)
        {
            TaxRateSet taxRateSet = GetTaxRateSet(enterpriseCode, taxRateCode);
            return taxRateSet.ConsTaxLayMethod;
        }
        // ----- ADD 2012/06/19 tianjw Redmine#30529 -----<<<<<

        /// <summary>
        /// TODO:検索
        /// </summary>
        /// <param name="suppPrtPpr">検索条件クラス</param>
        /// <param name="logicalDelDiv">削除指定区分：0=標準,1=削除分のみ</param>
        /// <param name="procDiv">処理区分：0=仕入情報,1=仕入返品予定情報</param>   // ADD 2013/01/21
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2009/09/08 黄偉兵 過去分表示対応</br>
        /// <br>Update Note: 2012/04/05 李小路</br>						
        /// <br>             2012/05/24配信分 Redmine#29310　合計欄の不具合についての修正</br>
        /// <br>Update Note: 2012/06/19 tianjw</br>
        /// <br>管理番号   : 10801804-00 2012/07/25配信分</br>
        /// <br>             Redmine#30529 税率参照の不具合の対応</br>
        /// <br>Update Note: 2012/06/26 伊藤 豊</br>
        ///                  電話対応No.1027 件数オーバー時にメッセージを表示
        /// <br>Update Note: 2012/10/15 田建委</br>
        /// <br>管理番号   : 10801804-00、2012/11/14配信分</br>
        /// <br>             Redmine#32862 価格変更した明細、色を変えるように修正</br>
        /// <br>Update Note: 2012/10/30 田建委</br>
        /// <br>管理番号   : 10801804-00、2012/11/14配信分</br>
        /// <br>             Redmine#32862#20 仕入データに入力区分「合計」で作成して、それを検索対象にした場合、システムエラーとなる修正</br>
        /// <br>Update Note : 2013/01/21 FSI冨樫 紗由里</br>
        /// <br>              [仕入返品計上] 選択チェックボックス設定追加</br>
        /// <br>Update Note: 2013/02/16 鄭慕鈞</br>　 
        /// <br>管理番号   : 10900691-00   2013/03/13配信分</br>
        /// <br>           : Redmine#34618 仕入先電子元帳の合計画面で消費税が合わない障害の修正</br>
        /// <br>Update Note: 2020/03/11 時シン</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 軽減税率対応</br>
        /// <br>           : 伝票タブ、明細タブに「消費税率」項目を追加</br>
        /// <br></br>
        /// </remarks>
        // ----------ADD 2013/01/21----------->>>>>
        //public int Search(SuppPrtPpr suppPrtPpr, int logicalDelDiv)
        public int Search(SuppPrtPpr suppPrtPpr, int logicalDelDiv, int procDiv)
        // ----------ADD 2013/01/21-----------<<<<<
        {
            int status;

            // 2012/06/26 Y.Ito ADD START サーバからの検索結果をリセット
            SearchCount = 0;
            // 2012/06/26 Y.Ito ADD END サーバからの検索結果をリセット

            int suppCTaxLayRefCd = -1; // ADD 2012/06/19 tianjw Redmine#30529

            // 仕入先コードが指定されていれば残高を表示
            if (suppPrtPpr.SupplierCd == 0)
            {
                // 仕入先コードがない場合は残高を表示しない
                _supplierPointed = false;
            }
            else
            {
                // 仕入先情報を取得し、締め日を取得しておく
                Supplier supplierInfo;
                status = this._supplierAcs.Read(out supplierInfo, suppPrtPpr.EnterpriseCode, suppPrtPpr.SupplierCd);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 仕入締め日を取得
                    this._supplierCalcDate = supplierInfo.PaymentTotalDay;
                    suppCTaxLayRefCd = supplierInfo.SuppCTaxLayRefCd; // ADD 2012/06/19 tianjw Redmine#30529
                }
                else
                {
                    // 仕入先情報がない
                    // *** 情報のない仕入先はパラメータとして渡ってこない ***
                }
            }


            // パラメータクラスを作成
            SuppPrtPprWork suppPrtPprWork = new SuppPrtPprWork();
            SuppPrtPpr2SuppPrtPprWork(ref suppPrtPpr, ref suppPrtPprWork);
            
            //---------------------------------
            // 返り値で使用するクラスを作成
            //---------------------------------

            // 残高照会に表示するので１件のみ
            SuppPrtPprBlDspRsltWork suppPrtPprBlDspRsltWork = new SuppPrtPprBlDspRsltWork();
            object suppPrtPprBlDspRsltWorkObj = (object)suppPrtPprBlDspRsltWork;

            // 明細なのでrecordCount件数配列で帰ってくる
            SuppPrtPprStcTblRsltWork suppPrtPprStcTblRsltWork = new SuppPrtPprStcTblRsltWork();
            object suppPrtPprStcTblRsltWorkObj = (object)suppPrtPprStcTblRsltWork;
            long counter = 0;

            // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ---------->>>>>
            if (ExtractCancelFlag == true) return 0;
            // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ----------<<<<<

            // ----------ADD 2013/01/21----------->>>>>
            // 処理区分=0(仕入情報表示(返品予定は対象外))の場合
            if (procDiv == 0)
            {
                //仕入情報を取得
                if (logicalDelDiv == 0)
                {
                    // 削除分を含まない場合はGetData0を指定(削除フラグ=0のデータを返す)
                    status = this._iSuppPrtPprWorkDB.SearchRef(ref suppPrtPprBlDspRsltWorkObj, ref suppPrtPprStcTblRsltWorkObj, (object)suppPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData0);
                }
                else
                {
                    // 削除済みの場合はGetData1を指定(削除フラグ=1のデータを返す)
                    status = this._iSuppPrtPprWorkDB.SearchRef(ref suppPrtPprBlDspRsltWorkObj, ref suppPrtPprStcTblRsltWorkObj, (object)suppPrtPprWork, out counter, 0, ConstantManagement.LogicalMode.GetData1);
                }
            }
            // 処理区分=1(仕入返品予定情報のみ表示)の場合
            else
            {

                //仕入返品予定情報を取得
                status = this._iSuppPrtPprWorkDB.SearchRefPurchaseReturnSchedule(ref suppPrtPprStcTblRsltWorkObj, (object)suppPrtPprWork, out counter, logicalDelDiv);

            }
            // ----------ADD 2013/01/21-----------<<<<<

            // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ---------->>>>>
            if (ExtractCancelFlag == true) return 0;
            // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ----------<<<<<
            // ※引数のreadModeは現在使用していないのでどんな値を入れても問題なし

            // 2012/06/26 Y.Ito ADD START サーバからの検索結果を保持
            SearchCount = counter;
            // 2012/06/26 Y.Ito ADD END サーバからの検索結果を保持

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
            //// Statusが正常値だった場合のみデータセットに戻りデータをセット
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
            if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
                // ※仕入年間実績照会ベースの取得仕様に変更
                //   (仕入先電子元帳リモートが返すsuppPrtPprBlDspRsltWorkObjは使用しない)
                RemainDataExtra remainDataExtra = new RemainDataExtra();
                SearchBlDspRslt( ref suppPrtPprBlDspRsltWorkObj, ref remainDataExtra, suppPrtPpr );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //// 一件以上の戻りがあった場合のみ
                //if (counter > 0)
                //{
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                #region 変数定義

                DataRow row = null;
                DataRow row2 = null;
                DataRow row3 = null;
                DataRow retRow = null; // ADD 2013/01/21 [仕入返品計上]

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                //// 伝票単位は、「伝票番号」及び「仕入型式」が同一のものをひとつのくくりとして判定する
                //string exSlipNum = string.Empty;    // ひとつ前の伝票番号
                //int exSupplierFormal = 0;           // ひとつ前の仕入型式
                // 伝票番号
                //int supplierSlipNoExt = 0;// string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                int supplierSlipNoExt = -1; // ひとつ前の伝票番号
                int exSupplierFormal = -1;  // ひとつ前の受注ステータス
                // ADD 2010/01/26 MANTIS対応[14325]：インストール直後に仕入伝票×1と支払伝票×1を登録した状態で検索すると、仕入伝票が表示されない ---------->>>>>
                string exSupplierSlipCdName = string.Empty; // ひとつ前の仕入伝票区分名
                // ADD 2010/01/26 MANTIS対応[14325]：インストール直後に仕入伝票×1と支払伝票×1を登録した状態で検索すると、仕入伝票が表示されない ----------<<<<<
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                long consumeTaxTotal = 0;           // 伝票単位の消費税額累計
                bool stckPrcConsTaxIncluAdjust = false; // 消費税を表示するかどうかのフラグ
                int rowCount = 0;
                int allRowCount = 0;

                // 残高表示で使用する集計値
                int slipCount = 0;                  // 伝票枚数
                double detailSlipCount = 0;         // 明細数
                double totalAmount = 0;             // 数量
                double totalConsumeTaxAmount = 0;   // 消費税
                double totalConsumeTaxAmount2 = 0;   // 消費税(明細データを集計) //ADD 李小路　2012/04/05 Redmine#29310

                // 請求範囲内で集計する値
                long totalThisStockPrice = 0;       // 今回仕入
                long totalOfsThisSalesTax = 0;      // 消費税（売）
                long totalThisTimePayNrml = 0;      // 今回支払

                double StandardPrice_Total = 0;     // 標準価格合計
                double StockAmount_Total = 0;       // 仕入金額合計
                double StockAmount_Total2 = 0;       // 仕入金額合計(明細データを集計) //ADD 李小路　2012/04/05 Redmine#29310

                long StockTotalPayBalance = 0;      // 前回残高

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                //double wkStockAmount = 0;
                //double wkTotalConsumeTaxAmount = 0;
                long salAmntConsTaxInclu = 0; // 伝票別内税金額集計値
                string salesSlipNum = string.Empty; // 伝票内同時売上伝票番号(伝票内に1行でもあれば退避) 
                string prevSalesSlipNum = string.Empty;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

                int rowNo = 1;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                int rowDetailNo = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ---------->>>>>
                int lastIndex = 0;
                // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ----------<<<<<

                #endregion // 変数定義

                #region 残高表示

                //-------------------
                // 残高表示
                //-------------------

                // 残高表示が一件で特定できなかった場合は表示しない
                // 仕入先が存在しない場合も表示しない
                ArrayList al = (ArrayList)suppPrtPprBlDspRsltWorkObj;
                if ( al.Count == 1 || !_supplierPointed )
                {
                    int suppCTaxLayCd = GetConsTaxLayMethod(suppPrtPpr.EnterpriseCode, 0); // ADD 2012/06/19 tianjw Redmine#30529
                    foreach ( SuppPrtPprBlDspRsltWork remainData in (ArrayList)suppPrtPprBlDspRsltWorkObj )
                    {
                        row3 = this._dataSet.BalanceTotal.NewRow();
                        row3[_dataSet.BalanceTotal.StockTtl2TmBfBlPayColumn.ColumnName] = remainData.StockTtl2TmBfBlPay;    // 前々々回残高
                        row3[_dataSet.BalanceTotal.LastTimePaymentColumn.ColumnName] = remainData.LastTimePayment;          // 前々回残高
                        row3[_dataSet.BalanceTotal.StockTotalPayBalanceColumn.ColumnName] = remainData.StockTotalPayBalance;// 前回残高
                        StockTotalPayBalance = remainData.StockTotalPayBalance;
                        row3[_dataSet.BalanceTotal.AddUpYearMonthColumn.ColumnName] = remainData.AddUpYearMonth;            // 請求年月
                        //row3[_dataSet.BalanceTotal.SuppCTaxationCdColumn.ColumnName] = remainData.SuppCTaxationCd;          // 消費税転嫁方式 // DEL 2012/06/19 tianjw Redmine#30529
                        // ----- ADD 2012/06/19 tianjw Redmine#30529 ---------->>>>>
                        // 消費税転嫁方式
                        if (suppCTaxLayRefCd == 0)
                        {
                            // 税率参照の場合
                            row3[_dataSet.BalanceTotal.SuppCTaxationCdColumn.ColumnName] = suppCTaxLayCd;
                        }
                        else
                        {
                            // 仕入先参照の場合
                            row3[_dataSet.BalanceTotal.SuppCTaxationCdColumn.ColumnName] = remainData.SuppCTaxationCd;
                        }
                        // ----- ADD 2012/06/19 tianjw Redmine#30529 ----------<<<<<
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
                        // 支払残高
                        row3[_dataSet.BalanceTotal.PaymentRemainColumn.ColumnName] = remainDataExtra.PaymentRemain;
                        // 今回仕入
                        row3[_dataSet.BalanceTotal.ThisStockPriceTotalColumn.ColumnName] = remainDataExtra.ThisStockPriceTotal;
                        // 消費税
                        row3[_dataSet.BalanceTotal.OfsThisStockTaxColumn.ColumnName] = remainDataExtra.OfsThisStockTax;
                        // 今回支払
                        row3[_dataSet.BalanceTotal.ThisTimePayNrmlColumn.ColumnName] = remainDataExtra.ThisTimePayNrml;
                        // 締開始日
                        row3[_dataSet.BalanceTotal.DmdStDayColumn.ColumnName] = remainDataExtra.DmdStDay;
                        // 締処理日
                        row3[_dataSet.BalanceTotal.TotalDayColumn.ColumnName] = remainDataExtra.TotalDay;
                        // 親フラグ
                        row3[_dataSet.BalanceTotal.IsParentColumn.ColumnName] = remainDataExtra.IsParent;
                        // データ存在フラグ
                        row3[_dataSet.BalanceTotal.ExistsTotalColumn.ColumnName] = true;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD
                        this._dataSet.BalanceTotal.Rows.Add( row3 );
                    }
                }

                #endregion // 残高表示

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                // 一件以上の戻りがあった場合のみ
                if (counter > 0)
                {
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD


                    // 全件数を取得しておく
                    allRowCount = ((ArrayList)suppPrtPprStcTblRsltWorkObj).Count;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //foreach (SuppPrtPprStcTblRsltWork data in (ArrayList)suppPrtPprStcTblRsltWorkObj)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    for ( int index = 0; index < (suppPrtPprStcTblRsltWorkObj as ArrayList).Count; index++ )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    {
                        // 2012/06/26 Y.Ito ADD START 20000件を超えるデータは格納しない。
                        if (this._dataSet.StcDetail.Rows.Count >= suppPrtPpr.SearchCnt - 1)
                        {
                            break;
                        }
                        // 2012/06/26 Y.Ito ADD END 20000件を超えるデータは表示しない。

                        // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ---------->>>>>
                        lastIndex = index;
                        // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ----------<<<<<

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        SuppPrtPprStcTblRsltWork data = (SuppPrtPprStcTblRsltWork)((suppPrtPprStcTblRsltWorkObj as ArrayList)[index]);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                        // データセットに返り値をセットする
                        try
                        {
                            #region 明細データテーブル

                            row = this._dataSet.StcDetail.NewRow();
                            retRow = this._dataSet.RetGdsStcDetail.NewRow(); // ADD 2013/01/21 [仕入返品計上]

                            if (data.DataDiv == 0) // 仕入データの場合
                            {
                                #region 明細・仕入データ

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                                // 返品・値引制御のための数量・金額の符号(1or-1)
                                // （返品の値引きは-1*-1で1）
                                // ※返品・値引きはデータ上数量マイナスなので、detailSignをかけてプラスにする
                                // 　単純にAbsをとるわけではないので注意。
                                int detailSign = 1;

                                // 返品判定
                                if ( data.SupplierSlipCd == 20 ) detailSign *= -1;

                                // 商品値引判定(行値引は除外)
                                if ( data.StockSlipCdDtl == 2 && !string.IsNullOrEmpty( data.GoodsNo ) ) detailSign *= -1;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                                // 選択チェックボックス
                                row[_dataSet.StcDetail.SelectionCheckColumn.ColumnName] = false; // ADD 2013/01/21 [仕入返品計上]
                                // 伝票区分
                                row[_dataSet.StcDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                // 行番号([キー列]抽出データ累計)
                                row[_dataSet.StcDetail.RowNoColumn.ColumnName] = rowNo;
                                // 伝票日付
                                row[_dataSet.StcDetail.StockDateColumn.ColumnName] = data.StockDate;
                                // 伝票番号
                                row[_dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                                // 行No
                                row[_dataSet.StcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;
                                // 仕入形式
                                row[_dataSet.StcDetail.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                                // 仕入伝票区分
                                row[_dataSet.StcDetail.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                                // 仕入伝票区分名判定
                                if (data.SupplierFormal == 0)   // 仕入
                                {
                                    if (data.SupplierSlipCd == 10)
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01;
                                    }
                                    else if (data.SupplierSlipCd == 20)
                                    {
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                        //row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01 + CT_SUPPLIERSLIPCD_NAME_02; // 仕入返品
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                                    }
                                }
                                else if (data.SupplierFormal == 1)   // 受注
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                    //row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                    if ( data.SupplierSlipCd == 10 )
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04; // 入荷
                                    }
                                    else if ( data.SupplierSlipCd == 20 )
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04 + CT_SUPPLIERSLIPCD_NAME_02; // 入荷返品
                                    }
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                                }
                                else if (data.SupplierFormal == 2)   // 出荷
                                {
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                    //row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                                    row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03; // 発注
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                                }
                                // ----------ADD 2013/01/21 [仕入返品計上]----------->>>>>
                                else if (data.SupplierFormal == 3)   // 返品予定
                                {
                                    if (data.SupplierSlipCd == 10)
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01; // 仕入
                                    }
                                    else if (data.SupplierSlipCd == 20)
                                    {
                                        row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02; // 返品
                                    }
                                }
                                // ----------ADD 2013/01/21 [仕入返品計上]-----------<<<<<
                                else // 支払
                                {
                                    // [※支払伝票はここにこない]
                                    //row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                                }
                                // 担当者名
                                row[_dataSet.StcDetail.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// 金額
                                //row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // 品名
                                row[_dataSet.StcDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                // 品番
                                row[_dataSet.StcDetail.GoodsNoColumn.ColumnName] = data.GoodsNo;
                                // メーカーコード[0のときは空白]
                                if (data.GoodsMakerCd == 0)
                                {
                                    row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = string.Empty;//DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = data.GoodsMakerCd.ToString().PadLeft(CT_DEPTH_GOODSMAKERCODE, '0');
                                }
                                // メーカー名
                                row[_dataSet.StcDetail.MakerNameColumn.ColumnName] = data.MakerName;
                                // BLコード[0のときは空白]
                                if (data.BLGoodsCode == 0)
                                {
                                    row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = string.Empty;//DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = data.BLGoodsCode.ToString().PadLeft(CT_DEPTH_BLGOODSCODE, '0');
                                }
                                // BLグループ
                                if (data.BLGroupCode == 0)
                                {
                                    row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = string.Empty;//DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = data.BLGroupCode.ToString().PadLeft(CT_DEPTH_BLGROUPCODE, '0');
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// 数量
                                //row[_dataSet.StcDetail.StockCountColumn.ColumnName] = data.StockCount;

                                //// オープン価格区分
                                //row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                //// 標準価格(オープン価格区分により表示変更)
                                //if (data.OpenPriceDiv == 0)
                                //{
                                //    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl.ToString("#,###");
                                //}
                                //else
                                //{
                                //    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = CT_OPENPRICEDIV_NAME;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
                                if ( data.StockGoodsCd == 0 )
                                {
                                    // 原単価
                                    row[_dataSet.StcDetail.StockUnitPriceFlColumn.ColumnName] = data.StockUnitPriceFl;

                                    // 数量
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                                    //row[_dataSet.StcDetail.StockCountColumn.ColumnName] = data.StockCount;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                                    row[_dataSet.StcDetail.StockCountColumn.ColumnName] = detailSign * data.StockCount;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                                    // オープン価格区分
                                    row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                    
                                    // 標準価格(オープン価格区分により表示変更)
                                    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl;    // ADD by gezh 2011/11/24 redmine#8078
                                    // DEL by gezh 2011/11/24 redmine#8078 begin---------------------->>>>>
                                    //if (data.OpenPriceDiv == 0)
                                    //{
                                    //    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = data.ListPriceTaxExcFl.ToString("#,###");
                                    //}
                                    //else
                                    //{
                                    //    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = CT_OPENPRICEDIV_NAME;
                                    //}
                                    // DEL by gezh 2011/11/24 redmine#8078 end-----------------------<<<<<

                                    // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------>>>>>
                                    // 原単価
                                    row[_dataSet.StcDetail.BfStockUnitPriceFlColumn.ColumnName] = data.BfStockUnitPriceFl;
                                    // 標準価格
                                    row[_dataSet.StcDetail.BfListPriceColumn.ColumnName] = data.BfListPrice;
                                    // ----------- ADD 2012/10/15 田建委 Redmine#32862 ------------<<<<<
                                }
                                else
                                {
                                    // ※合計入力の場合は非表示

                                    // 原単価
                                    row[_dataSet.StcDetail.StockUnitPriceFlColumn.ColumnName] = DBNull.Value;
                                    // 数量
                                    row[_dataSet.StcDetail.StockCountColumn.ColumnName] = DBNull.Value;
                                    // オープン価格区分
                                    row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = DBNull.Value;
                                    // 標準価格(オープン価格区分により表示変更)
                                    row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value;

                                    // ----------- ADD 2012/10/30 田建委 Redmine#32862 ------------>>>>>
                                    // 変更前原単価
                                    row[_dataSet.StcDetail.BfStockUnitPriceFlColumn.ColumnName] = DBNull.Value;
                                    // 変更前標準価格
                                    row[_dataSet.StcDetail.BfListPriceColumn.ColumnName] = DBNull.Value;
                                    // ----------- ADD 2012/10/30 田建委 Redmine#32862 ------------<<<<<
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// 消費税(仕入先消費税転嫁方式コードにより変化)
                                //// *** 総額表示する ***
                                //if (data.SuppTtlAmntDspWayCd == 1) 
                                //{
                                //    // [総額表示する]の場合は明細単位以外は設定されない。明細以外を考慮する必要なし
                                //    // テスト時にも、明細以外を設定しているデータがある場合は、データが間違い

                                //    // 仕入金額消費税額
                                //    row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StockPriceConsTax;
                                //    //row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StckPrcConsTaxInclu + data.StckDisTtlTaxInclu;
                                //}
                                //else // *** 総額表示しない ***
                                //{
                                //    if (data.SuppCTaxLayCd == 0) // 伝票単位(0)
                                //    {
                                //        // 表示しない
                                //        row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //    }
                                //    else if (data.SuppCTaxLayCd == 2 || // 請求親(2)
                                //        data.SuppCTaxLayCd == 3 || // 請求子(3)
                                //        data.SuppCTaxLayCd == 9)   // 非課税(9)
                                //    {
                                //        if (data.TaxationCode == 2) // *** 内税 ***
                                //        {
                                //            row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StockPriceConsTax;
                                //            //row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StckPrcConsTaxInclu + data.StckDisTtlTaxInclu;
                                //        }
                                //        else
                                //        {
                                //            // 表示しない
                                //            row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                //        }
                                //    }
                                //    else // 明細単位(1)
                                //    {
                                //        // 表示する
                                //        row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = data.StockPriceConsTax;
                                //    }
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                # region [消費税関連]
                                bool printTax = true;
                                Int64 stockTotalTaxInc;
                                Int64 stockTotalTaxExc = data.StockPriceTaxExc;
                                Int64 stockPriceConsTax;

                                // 印刷する消費税額の取得
                                if ( data.SuppCTaxLayCd == 0 ) // 伝票単位
                                {
                                    // ----- DEL huangt 2013/05/15 Redmine#35640 ---------- >>>>>
                                    //if ( !data.SupplierSlipNo.Equals( supplierSlipNoExt ) ) // 一行目のみ表示
                                    //{
                                    //    stockPriceConsTax = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                                    //}
                                    //else
                                    //{
                                    //    stockPriceConsTax = 0;
                                    //    printTax = false;
                                    //}
                                    // ----- DEL huangt 2013/05/15 Redmine#35640 ---------- <<<<<

                                    // ----- ADD huangt 2013/05/15 Redmine#35640 ---------- >>>>>
                                    // 明細先頭行に消費税が印字される
                                    //if (data.StockRowNo == 1)    // DEL huangt 2013/11/25 Redmine#35640 発注の場合は消費税を出力しないように修正
                                    if (data.StockRowNo == 1 && data.SupplierFormal != 2)   // ADD huangt 2013/11/25 Redmine#35640 発注の場合は消費税を出力しないように修正
                                    {
                                        stockPriceConsTax = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                                    }
                                    else
                                    {
                                        stockPriceConsTax = 0;
                                        printTax = false;
                                    }
                                    // ----- ADD huangt 2013/05/15 Redmine#35640 ---------- <<<<<
                                }
                                //else if ( data.SuppCTaxLayCd == 1 ) // 明細単位
                                //{
                                //    stockPriceConsTax = data.StockPriceConsTaxDtl;
                                //}
                                //else
                                //{
                                //    stockPriceConsTax = 0;
                                //}
                                else
                                {
                                    //stockPriceConsTax = data.StockPriceConsTaxDtl;  // DEL　鄭慕鈞　2013/02/16 Redmine#34618
                                    // -----ADD　鄭慕鈞　2013/02/16 Redmine#34618----->>>>>
                                    if (data.StockPriceConsTaxDtl == 0)//コンバートデータ分の仕入明細データに消費税がゼロの場合、消費税が再取得する
                                    {
                                        stockPriceConsTax = data.StockPriceTaxInc - data.StockPriceTaxExc;
                                    }
                                    else
                                    {
                                        stockPriceConsTax = data.StockPriceConsTaxDtl;
                                    }
                                    // -----ADD　鄭慕鈞　2013/02/16 Redmine#34618-----<<<<<
                                }

                                // 税込金額の取得
                                stockTotalTaxInc = stockTotalTaxExc + stockPriceConsTax;

                                if ( printTax )
                                {
                                    // 消費税印字有無判定と金額制御
                                    int totalAmountDispWayCd = data.SuppTtlAmntDspWayCd;
                                    int taxationDivCd = data.TaxationCode;

                                    // 消費税印字有無判定
                                    printTax = ReflectMoneyForTaxPrint( ref stockTotalTaxExc, ref stockPriceConsTax, ref stockTotalTaxInc, totalAmountDispWayCd, data.SuppCTaxLayCd, taxationDivCd );
                                    if ( printTax )
                                    {
                                        if ( stockPriceConsTax != 0 )
                                        {
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                                            //row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = stockPriceConsTax;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                                            row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = detailSign * stockPriceConsTax;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                                            row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = data.SupplierConsTaxRate; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                        }
                                        else
                                        {
                                            // 印字しない
                                            row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                            row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                        }
                                    }
                                    else
                                    {
                                        // 印字しない
                                        row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                        row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                    }
                                }
                                else
                                {
                                    // 印字しない
                                    row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                    row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                                }
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                                //// 税抜金額セット
                                //row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = stockTotalTaxExc;
                                //// 税込金額セット
                                //row[_dataSet.StcDetail.StockTtlPricTaxIncColumn.ColumnName] = stockTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                                // 税抜金額セット
                                row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = detailSign * stockTotalTaxExc;
                                // 税込金額セット
                                row[_dataSet.StcDetail.StockTtlPricTaxIncColumn.ColumnName] = detailSign * stockTotalTaxInc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD
                                # endregion
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                // 備考１
                                row[_dataSet.StcDetail.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                                // 備考２
                                row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = data.SupplierSlipNote2;
                                // 拠点コード
                                row[_dataSet.StcDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                // 拠点名
                                row[_dataSet.StcDetail.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                                // 発行者
                                // row[_dataSet.StcDetail.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                                // 仕入先コード[NULLのときは空白]
                                if (data.SupplierCd == 0)
                                {
                                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                                }
                                // 仕入先名
                                row[_dataSet.StcDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                // 在取
                                row[_dataSet.StcDetail.StockOrderDivCdColumn.ColumnName] = data.StockOrderDivCd;
                                // 在取名
                                if (data.StockOrderDivCd == 0)
                                {
                                    row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = CT_STOCKORDERDIV_NAME_01;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = CT_STOCKORDERDIV_NAME_02;
                                }
                                // 倉庫コード
                                row[_dataSet.StcDetail.WarehouseCdColumn.ColumnName] = data.WarehouseCode;
                                // 倉庫名
                                row[_dataSet.StcDetail.WarehouseNameColumn.ColumnName] = data.WarehouseName;
                                // 棚番
                                row[_dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName] = data.WarehouseShelfNo;
                                // UOEリマーク1
                                row[_dataSet.StcDetail.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                                // UOEリマーク2
                                row[_dataSet.StcDetail.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                                // 仕入SEQ/支払№[0のときは空白]
                                if (data.SupplierSlipNo == 0)
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                }
                                // 計上日
                                if (data.StockAddUpADate == DateTime.MinValue)
                                {
                                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                                }
                                // 買掛区分
                                row[_dataSet.StcDetail.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                                // 買掛区分名
                                if (data.AccPayDivCd == 1)
                                {
                                    row[_dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName] = CT_ACCPAYDIV_NAME_01;
                                }
                                // 赤伝区分
                                if (data.DebitNoteDiv == 0)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                                }
                                else if (data.DebitNoteDiv == 1)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                                }
                                else if (data.DebitNoteDiv == 2)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                }
                                // 同時売上伝票番号
                                row[_dataSet.StcDetail.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum;
                                // 同時売上日付
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                                //row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                                if ( data.SalesDate != DateTime.MinValue )
                                {
                                    row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = data.SalesDate;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = DBNull.Value;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// 得意先コード[0のときは空白]
                                //if (data.CustomerCode > 0)
                                //{
                                //    row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode.ToString().PadLeft(CT_DEPTH_CUSTOMERCODE, '0');
                                //}
                                //else
                                //{
                                //    row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = string.Empty;
                                //}
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                // 得意先コード
                                row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = data.CustomerCode;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                // 得意先名
                                row[_dataSet.StcDetail.CustomerSnmColumn.ColumnName] = data.CustomerSnm;

                                //// 保存されている伝票番号を更新 (仕入SEQ/支払Noで比較する)
                                //if (data.SupplierSlipNo != supplierSlipNoExt)
                                //{
                                //    // 異なっていた場合は保存
                                //    supplierSlipNoExt = data.SupplierSlipNo;
                                //}

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
                                if (data.SupplierFormal != 2)
                                {
                                    //if (data.StockSlipCdDtl 
                                    switch ( data.StockSlipCdDtl )
                                    {
                                        default:
                                        case 0:
                                        case 1:
                                            {
                                                row[_dataSet.StcDetail.StockSlipCdDtlColumn.ColumnName] = "通常";
                                            }
                                            break;
                                        case 2:
                                            {
                                                if ( string.IsNullOrEmpty( data.GoodsNo ) )
                                                {
                                                    row[_dataSet.StcDetail.StockSlipCdDtlColumn.ColumnName] = "行値引";
                                                }
                                                else
                                                {
                                                    row[_dataSet.StcDetail.StockSlipCdDtlColumn.ColumnName] = "商品値引";
                                                }
                                            }
                                            break;
                                    }
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD

                                // ----------ADD 2013/01/21----------->>>>>
                                // 行番号([キー列]抽出データ累計)
                                retRow[_dataSet.RetGdsStcDetail.RowNoColumn.ColumnName] = rowNo;
                                // 仕入SEQ/支払№[0のときは空白]
                                retRow[_dataSet.RetGdsStcDetail.SupplierSlipNoColumn.ColumnName] = row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName];
                                // 行No
                                retRow[_dataSet.RetGdsStcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;

                                //仕入入力者コード
                                retRow[_dataSet.RetGdsStcDetail.StockInputCodeColumn.ColumnName] = data.StockInputCode;
                                //仕入担当者コード
                                retRow[_dataSet.RetGdsStcDetail.StockAgentCodeColumn.ColumnName] = data.StockAgentCode;
                                //商品属性
                                retRow[_dataSet.RetGdsStcDetail.GoodsKindCodeColumn.ColumnName] = data.GoodsKindCode;
                                //メーカーカナ名称
                                retRow[_dataSet.RetGdsStcDetail.MakerKanaNameColumn.ColumnName] = data.MakerKanaName;
                                //メーカーカナ名称（一式）
                                retRow[_dataSet.RetGdsStcDetail.CmpltMakerKanaNameColumn.ColumnName] = data.CmpltMakerKanaName;
                                //商品名称カナ
                                retRow[_dataSet.RetGdsStcDetail.GoodsNameKanaColumn.ColumnName] = data.GoodsNameKana;
                                //商品大分類コード
                                retRow[_dataSet.RetGdsStcDetail.GoodsLGroupColumn.ColumnName] = data.GoodsLGroup;
                                //商品大分類名称
                                retRow[_dataSet.RetGdsStcDetail.GoodsLGroupNameColumn.ColumnName] = data.GoodsLGroupName;
                                //商品中分類コード
                                retRow[_dataSet.RetGdsStcDetail.GoodsMGroupColumn.ColumnName] = data.GoodsMGroup;
                                //商品中分類名称
                                retRow[_dataSet.RetGdsStcDetail.GoodsMGroupNameColumn.ColumnName] = data.GoodsMGroupName;
                                //BLグループコード名称
                                retRow[_dataSet.RetGdsStcDetail.BLGroupNameColumn.ColumnName] = data.BLGroupName;
                                //BL商品コード名称（全角）
                                retRow[_dataSet.RetGdsStcDetail.BLGoodsFullNameColumn.ColumnName] = data.BLGoodsFullName;
                                //自社分類コード
                                retRow[_dataSet.RetGdsStcDetail.EnterpriseGanreCodeColumn.ColumnName] = data.EnterpriseGanreCode;
                                //掛率設定拠点（仕入単価）
                                retRow[_dataSet.RetGdsStcDetail.RateSectStckUnPrcColumn.ColumnName] = data.RateSectStckUnPrc;
                                //掛率設定区分（仕入単価）
                                retRow[_dataSet.RetGdsStcDetail.RateDivStckUnPrcColumn.ColumnName] = data.RateDivStckUnPrc;
                                //単価算出区分（仕入単価）
                                retRow[_dataSet.RetGdsStcDetail.UnPrcCalcCdStckUnPrcColumn.ColumnName] = data.UnPrcCalcCdStckUnPrc;
                                //価格区分（仕入単価）
                                retRow[_dataSet.RetGdsStcDetail.PriceCdStckUnPrcColumn.ColumnName] = data.PriceCdStckUnPrc;
                                //基準単価（仕入単価）
                                retRow[_dataSet.RetGdsStcDetail.StdUnPrcStckUnPrcColumn.ColumnName] = data.StdUnPrcStckUnPrc;
                                //端数処理単位（仕入単価）
                                retRow[_dataSet.RetGdsStcDetail.FracProcUnitStcUnPrcColumn.ColumnName] = data.FracProcUnitStcUnPrc;
                                //端数処理（仕入単価）
                                retRow[_dataSet.RetGdsStcDetail.FracProcStckUnPrcColumn.ColumnName] = data.FracProcStckUnPrc;
                                //仕入単価（税込，浮動）
                                retRow[_dataSet.RetGdsStcDetail.StockUnitTaxPriceFlColumn.ColumnName] = data.StockUnitTaxPriceFl;
                                //仕入単価変更区分
                                retRow[_dataSet.RetGdsStcDetail.StockUnitChngDivColumn.ColumnName] = data.StockUnitChngDiv;
                                //BL商品コード（掛率）
                                retRow[_dataSet.RetGdsStcDetail.RateBLGoodsCodeColumn.ColumnName] = data.RateBLGoodsCode;
                                //BL商品コード名称（掛率）
                                retRow[_dataSet.RetGdsStcDetail.RateBLGoodsNameColumn.ColumnName] = data.RateBLGoodsName;
                                //商品掛率グループコード（掛率）
                                retRow[_dataSet.RetGdsStcDetail.RateGoodsRateGrpCdColumn.ColumnName] = data.RateGoodsRateGrpCd;
                                //商品掛率グループ名称（掛率）
                                retRow[_dataSet.RetGdsStcDetail.RateGoodsRateGrpNmColumn.ColumnName] = data.RateGoodsRateGrpNm;
                                //BLグループコード（掛率）
                                retRow[_dataSet.RetGdsStcDetail.RateBLGroupCodeColumn.ColumnName] = data.RateBLGroupCode;
                                //BLグループ名称（掛率）
                                retRow[_dataSet.RetGdsStcDetail.RateBLGroupNameColumn.ColumnName] = data.RateBLGroupName;
                                //発注数量
                                retRow[_dataSet.RetGdsStcDetail.OrderCntColumn.ColumnName] = data.OrderCnt;
                                //発注調整数
                                retRow[_dataSet.RetGdsStcDetail.OrderAdjustCntColumn.ColumnName] = data.OrderAdjustCnt;
                                //発注残数
                                retRow[_dataSet.RetGdsStcDetail.OrderRemainCntColumn.ColumnName] = data.OrderRemainCnt;
                                //残数更新日
                                retRow[_dataSet.RetGdsStcDetail.RemainCntUpdDateColumn.ColumnName] = data.RemainCntUpdDate;
                                //仕入伝票明細備考1
                                retRow[_dataSet.RetGdsStcDetail.StockDtiSlipNote1Column.ColumnName] = data.StockDtiSlipNote1;
                                //販売先コード
                                retRow[_dataSet.RetGdsStcDetail.SalesCustomerCodeColumn.ColumnName] = data.SalesCustomerCode;
                                //販売先略称
                                retRow[_dataSet.RetGdsStcDetail.SalesCustomerSnmColumn.ColumnName] = data.SalesCustomerSnm;
                                //伝票メモ１
                                retRow[_dataSet.RetGdsStcDetail.SlipMemo1Column.ColumnName] = data.SlipMemo1;
                                //伝票メモ２
                                retRow[_dataSet.RetGdsStcDetail.SlipMemo2Column.ColumnName] = data.SlipMemo2;
                                //伝票メモ３
                                retRow[_dataSet.RetGdsStcDetail.SlipMemo3Column.ColumnName] = data.SlipMemo3;
                                //社内メモ１
                                retRow[_dataSet.RetGdsStcDetail.InsideMemo1Column.ColumnName] = data.InsideMemo1;
                                //社内メモ２
                                retRow[_dataSet.RetGdsStcDetail.InsideMemo2Column.ColumnName] = data.InsideMemo2;
                                //社内メモ３
                                retRow[_dataSet.RetGdsStcDetail.InsideMemo3Column.ColumnName] = data.InsideMemo3;
                                //納品先コード
                                retRow[_dataSet.RetGdsStcDetail.AddresseeCodeColumn.ColumnName] = data.AddresseeCode;
                                //納品先名称
                                retRow[_dataSet.RetGdsStcDetail.AddresseeNameColumn.ColumnName] = data.AddresseeName;
                                //直送区分
                                retRow[_dataSet.RetGdsStcDetail.DirectSendingCdColumn.ColumnName] = data.DirectSendingCd;
                                //発注番号
                                retRow[_dataSet.RetGdsStcDetail.OrderNumberColumn.ColumnName] = data.OrderNumber;
                                //注文方法
                                retRow[_dataSet.RetGdsStcDetail.WayToOrderColumn.ColumnName] = data.WayToOrder;
                                //納品完了予定日
                                retRow[_dataSet.RetGdsStcDetail.DeliGdsCmpltDueDateColumn.ColumnName] = data.DeliGdsCmpltDueDate;
                                //希望納期
                                retRow[_dataSet.RetGdsStcDetail.ExpectDeliveryDateColumn.ColumnName] = data.ExpectDeliveryDate;
                                //発注データ作成区分
                                retRow[_dataSet.RetGdsStcDetail.OrderDataCreateDivColumn.ColumnName] = data.OrderDataCreateDiv;
                                //発注データ作成日
                                retRow[_dataSet.RetGdsStcDetail.OrderDataCreateDateColumn.ColumnName] = data.OrderDataCreateDate;
                                //発注書発行済区分
                                retRow[_dataSet.RetGdsStcDetail.OrderFormIssuedDivColumn.ColumnName] = data.OrderFormIssuedDiv;
                                // 受注番号
                                retRow[_dataSet.RetGdsStcDetail.AcceptAnOrderNoColumn.ColumnName] = data.AcceptAnOrderNo;
                                // 共通通番
                                retRow[_dataSet.RetGdsStcDetail.CommonSeqNoColumn.ColumnName] = data.CommonSeqNo;
                                // 仕入明細通番
                                retRow[_dataSet.RetGdsStcDetail.StockSlipDtlNumColumn.ColumnName] = data.StockSlipDtlNum;
                                //仕入明細通番（元）
                                retRow[_dataSet.RetGdsStcDetail.StockSlipDtlNumSrcColumn.ColumnName] = data.StockSlipDtlNumSrc;
                                //売上明細通番（同時）
                                retRow[_dataSet.RetGdsStcDetail.SalesSlipDtlNumSyncColumn.ColumnName] = data.SalesSlipDtlNumSync;
                                // 仕入形式（元）
                                retRow[_dataSet.RetGdsStcDetail.SupplierFormalSrcColumn.ColumnName] = data.SupplierFormalSrc;
                                //部門コード（明細）
                                retRow[_dataSet.RetGdsStcDetail.SubSectionCodeColumn.ColumnName] = data.DtlSubSectionCode;
                                //自社分類名称（明細）
                                retRow[_dataSet.RetGdsStcDetail.EnterpriseGanreNameColumn.ColumnName] = data.EnterpriseGanreName;
                                //商品掛率ランク（明細）
                                retRow[_dataSet.RetGdsStcDetail.GoodsRateRankColumn.ColumnName] = data.GoodsRateRank;
                                //得意先掛率グループコード（明細）
                                retRow[_dataSet.RetGdsStcDetail.CustRateGrpCodeColumn.ColumnName] = data.CustRateGrpCode;
                                //仕入先掛率グループコード（明細）
                                retRow[_dataSet.RetGdsStcDetail.SuppRateGrpCodeColumn.ColumnName] = data.SuppRateGrpCode;
                                //定価（税込，浮動）（明細）
                                retRow[_dataSet.RetGdsStcDetail.ListPriceTaxIncFlColumn.ColumnName] = data.ListPriceTaxIncFl;
                                //仕入率（明細）
                                retRow[_dataSet.RetGdsStcDetail.StockRateColumn.ColumnName] = data.StockRate;
                                //課税区分（明細）
                                retRow[_dataSet.RetGdsStcDetail.TaxationCodeColumn.ColumnName] = data.TaxationCode;

                                //仕入伝票区分（明細）
                                row[_dataSet.StcDetail.StockSlipCdDtlIntColumn.ColumnName] = data.StockSlipCdDtl;
                                // 論理削除区分(明細)
                                row[_dataSet.StcDetail.LogicalDeleteCodeColumn.ColumnName] = data.DtlLogicalDeleteCode;
                                // ----------ADD 2013/01/21-----------<<<<<

                                #endregion // 明細・仕入データ
                            }
                            else
                            {
                                #region 明細・支払データ

                                // 選択チェックボックス
                                row[_dataSet.StcDetail.SelectionCheckColumn.ColumnName] = DBNull.Value; // ADD 2013/01/21 [仕入返品予定]
                                // 伝票区分
                                row[_dataSet.StcDetail.DataDivColumn.ColumnName] = data.DataDiv;
                                // 行番号(抽出データ累計)
                                row[_dataSet.StcDetail.RowNoColumn.ColumnName] = rowNo;
                                // 伝票日付
                                row[_dataSet.StcDetail.StockDateColumn.ColumnName] = data.StockDate;
                                // 伝票番号
                                row[_dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                                // 行No
                                row[_dataSet.StcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;
                                // 仕入形式
                                row[_dataSet.StcDetail.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                                // 仕入伝票区分
                                row[_dataSet.StcDetail.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                                // 仕入伝票区分名
                                row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                                // 担当者名
                                row[_dataSet.StcDetail.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //// 金額
                                //row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                // 金額(明細)
                                row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.StockPriceTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                // 品名
                                row[_dataSet.StcDetail.GoodsNameColumn.ColumnName] = data.GoodsName;
                                // 品番
                                row[_dataSet.StcDetail.GoodsNoColumn.ColumnName] = string.Empty; //DBNull.Value;
                                // メーカーコード
                                row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                                // メーカー名
                                row[_dataSet.StcDetail.MakerNameColumn.ColumnName] = string.Empty;
                                // BLコード
                                row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                                // BLグループ
                                row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                                // 数量
                                row[_dataSet.StcDetail.StockCountColumn.ColumnName] = DBNull.Value;
                                // オープン価格区分
                                row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                                // 標準価格
                                //row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = string.Empty; //DEL 2011/12/09
                                row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value; //ADD 2011/12/09
                                // 消費税
                                row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                                // 消費税率
                                row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912 
                                // 備考１
                                row[_dataSet.StcDetail.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                                // 備考２
                                if (data.SupplierSlipNote2.Equals("0"))
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = string.Empty;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = CT_SUPPLIERNOTE2_PRE + data.SupplierSlipNote2;
                                }
                                // 拠点コード
                                row[_dataSet.StcDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                                // 拠点名
                                row[_dataSet.StcDetail.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                                // 発行者
                                // row[_dataSet.StcDetail.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                                // 仕入先コード[NULLのときは空白]
                                if (data.SupplierCd == 0)
                                {
                                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                                }
                                // 仕入先名
                                row[_dataSet.StcDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                                // 在取
                                row[_dataSet.StcDetail.StockOrderDivCdColumn.ColumnName] = DBNull.Value;
                                row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = string.Empty;
                                // 倉庫コード
                                row[_dataSet.StcDetail.WarehouseCdColumn.ColumnName] = string.Empty;
                                // 倉庫名
                                row[_dataSet.StcDetail.WarehouseNameColumn.ColumnName] = string.Empty;
                                // 棚番
                                row[_dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName] = string.Empty;
                                // UOEリマーク1
                                row[_dataSet.StcDetail.UoeRemark1Column.ColumnName] = string.Empty;
                                // UOEリマーク2
                                row[_dataSet.StcDetail.UoeRemark2Column.ColumnName] = string.Empty;
                                // 仕入SEQ/支払№[NULLのときは空白]
                                if (data.SupplierSlipNo == 0)
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                                }
                                // 計上日
                                if (data.StockAddUpADate == DateTime.MinValue)
                                {
                                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                                }
                                // 買掛区分
                                row[_dataSet.StcDetail.AccPayDivCdColumn.ColumnName] = DBNull.Value;
                                // 買掛区分名
                                row[_dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                                // 赤伝区分
                                if (data.DebitNoteDiv == 0)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                                }
                                else if (data.DebitNoteDiv == 1)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                                }
                                else if (data.DebitNoteDiv == 2)
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                                }
                                else
                                {
                                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                                }
                                // 同時売上伝票番号
                                row[_dataSet.StcDetail.SalesSlipNumColumn.ColumnName] = string.Empty;
                                // 同時売上日付
                                row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = DBNull.Value;
                                // 得意先コード
                                row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = DBNull.Value;
                                // 得意先名
                                row[_dataSet.StcDetail.CustomerSnmColumn.ColumnName] = string.Empty;

                                // ----------ADD 2013/01/21----------->>>>>
                                // 行番号([キー列]抽出データ累計)
                                retRow[_dataSet.RetGdsStcDetail.RowNoColumn.ColumnName] = rowNo;
                                // ----------ADD 2013/01/21-----------<<<<<

                                #endregion // 明細・支払データ
                            }

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                            //// 行追加
                            //this._dataSet.StcDetail.Rows.Add(row);
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                            if ( data.DataDiv == 0 )
                            {
                                this._dataSet.StcDetail.Rows.Add( row );
                                this._dataSet.RetGdsStcDetail.Rows.Add(retRow);  //ADD 2013/01/21 [仕入返品計上]
                            }
                            else
                            {
                                // 手数料、値引きの明細データはこの時点では作成しない
                                if ( (data.StockRowNo != 0) && (string.IsNullOrEmpty( data.GoodsName.TrimEnd() )) == false )
                                {
                                    this._dataSet.StcDetail.Rows.Add( row );
                                    this._dataSet.RetGdsStcDetail.Rows.Add(retRow);  //ADD 2013/01/21 [仕入返品計上]
                                }
                            }
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                            #endregion // 明細データテーブル

                            #region 金額データを集計

                            //-------------------------
                            // 金額データを集計
                            //-------------------------
                            if (data.DataDiv == 0)  // 仕入データの場合
                            {
                                // 標準価格合計(標準価格 * 数量)
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                //StandardPrice_Total += (data.ListPriceTaxExcFl * data.StockCount);
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                if ( data.OpenPriceDiv == 0 )
                                {
                                    // オープン価格は除く
                                    StandardPrice_Total += (data.ListPriceTaxExcFl * data.StockCount);
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                                //// 仕入金額合計
                                //StockAmount_Total += data.StockTtlPricTaxExc;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                                //仕入金額合計(明細)
                                StockAmount_Total2 += data.StockPriceTaxExc;   //ADD 李小路　2012/04/05 Redmine#29310
                                // 原価合計
                                //Cost_Total += data.Cost;
                                // 粗利額合計(明細金額 - 原価)
                                //GrossProfitAmount_Total += (data.ListPriceTaxExcFl - Double.Parse(data.Cost.ToString()));
                                // 消費税（仕）
                                totalOfsThisSalesTax += data.StockPriceConsTax;
                                //消費税（明細）
                                //totalConsumeTaxAmount2 += data.StockPriceConsTaxDtl;    //ADD 李小路　2012/04/05 Redmine#29310  // DEL　鄭慕鈞　2013/02/16 Redmine#34618
                                // -----ADD　鄭慕鈞　2013/02/16 Redmine#34618----->>>>>
                                // 消費税
                                switch (data.SuppCTaxLayCd)
                                {
                                    // 明細転嫁
                                    case 1:
                                        // 加算する
                                        if (data.StockPriceConsTaxDtl == 0)//コンバートデータ分の仕入明細データに消費税がゼロの場合、消費税が再取得する
                                        {
                                            totalConsumeTaxAmount2 += data.StockPriceTaxInc - data.StockPriceTaxExc;
                                        }
                                        else
                                        {
                                            totalConsumeTaxAmount2 += data.StockPriceConsTaxDtl;
                                        }

                                        break;
                                    // 伝票転嫁
                                    case 0:
                                        if (!data.SupplierSlipNo.Equals(supplierSlipNoExt)) // 一行目のみ加算
                                        {
                                            totalConsumeTaxAmount2 += data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                                        }
                                        break;
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
                                // -----ADD　鄭慕鈞　2013/02/16 Redmine#34618-----<<<<<
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                                //// 消費税
                                //totalConsumeTaxAmount += data.StockPriceConsTax;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                                // 数量計
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                                // 数量計は合計入力と商品値引きを除いて集計する(StockSlipCdDtl=2で行値引が含まれるがどちらでも結果同じ)
                                if ( data.StockGoodsCd == 0 && data.StockSlipCdDtl != 2 )
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                                {
                                    totalAmount += data.StockCount;
                                }

                                // 今回仕入
                                totalThisStockPrice += data.StockTtlPricTaxExc;

                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                                // 伝票別内税金額集計
                                if ( data.TaxationCode == 2 )
                                {
                                    long consTaxInclu = (long)row[_dataSet.StcDetail.StockTtlPricTaxIncColumn.ColumnName]
                                                        - (long)row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName];
                                    salAmntConsTaxInclu += consTaxInclu;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                                if (!string.IsNullOrEmpty(data.SalesSlipNum))
                                {
                                    salesSlipNum = data.SalesSlipNum;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                            }
                            else // 支払データの場合
                            {
                                //今回支払
                                totalThisTimePayNrml += data.StockTtlPricTaxExc;
                            }

                            // 明細数
                            detailSlipCount++;

                            #endregion // 金額データを集計

                            #region 伝票表示データテーブル
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                            # region // DEL
                            //// これは絞り込みを行う
                            //// 絞込の条件項目は伝票番号、仕入形式
                            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                            ////if (data.SupplierSlipNo != supplierSlipNoExt)//(!data.PartySaleSlipNum.Equals(exSlipNum) || data.SupplierFormal != exSupplierFormal)
                            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //if ( index > 0 && (data.SupplierSlipNo != supplierSlipNoExt || data.SupplierFormal != exSupplierFormal))
                            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                            //{
                            //    // 新規行を作成する前に、消費税をセット
                            //    if (row2 != null)
                            //    {
                            //        // 消費税表示 = 表示かつ消費税額>0の場合は表示
                            //        if (stckPrcConsTaxIncluAdjust && consumeTaxTotal > 0)
                            //        {
                            //            // 列にセット
                            //            row2[_dataSet.StcList.StockPriceConsTaxColumn.ColumnName] = consumeTaxTotal;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                            //        }

                            //        this._dataSet.StcList.Rows.Add(row2);

                            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                            //        // 仕入金額合計
                            //        StockAmount_Total += wkStockAmount;
                            //        // 消費税
                            //        totalConsumeTaxAmount += wkTotalConsumeTaxAmount;
                            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

                            //        // 伝票枚数+1
                            //        slipCount++;
                            //    }
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //    wkStockAmount = data.StockTtlPricTaxExc;
                            //    wkTotalConsumeTaxAmount = data.StockPriceConsTax;
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

                            //    // 伝票番号および仕入形式が異なれば別伝票として取得
                            //    row2 = _dataSet.StcList.NewRow();

                            //    // 消費税額の初期値をリセット
                            //    consumeTaxTotal = 0;

                            //    // 仕入伝票なのか支払伝票なのかでデータの構造が異なる
                            //    if (data.DataDiv == 0)
                            //    {
                            //        #region 仕入伝票
                            //        //-----------
                            //        // 仕入伝票
                            //        //-----------

                            //        //row2[_dataSet.StcList.SelectionColumn.ColumnName] = false;
                            //        // 行No
                            //        row2[_dataSet.StcList.RowNoColumn.ColumnName] = rowNo;
                            //        // データ区分
                            //        row2[_dataSet.StcList.DataDivColumn.ColumnName] = data.DataDiv;
                            //        // 伝票日付
                            //        row2[_dataSet.StcList.StockDateColumn.ColumnName] = data.StockDate;
                            //        // 伝票番号
                            //        row2[_dataSet.StcList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                            //        // 仕入形式
                            //        row2[_dataSet.StcList.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                            //        // 仕入伝票区分
                            //        row2[_dataSet.StcList.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                            //        // 仕入伝票区分名判定
                            //        if (data.SupplierFormal == 0)   // 仕入
                            //        {
                            //            if (data.SupplierSlipCd == 10)
                            //            {
                            //                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01;
                            //            }
                            //            else if (data.SupplierSlipCd == 20)
                            //            {
                            //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                            //                //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02;
                            //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                            //                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01 + CT_SUPPLIERSLIPCD_NAME_02; // 仕入返品
                            //                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                            //            }
                            //        }
                            //        else if (data.SupplierFormal == 1)   // 受注
                            //        {
                            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                            //            //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03;
                            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //            if ( data.SupplierSlipCd == 10 )
                            //            {
                            //                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04; // 入荷
                            //            }
                            //            else if ( data.SupplierSlipCd == 20 )
                            //            {
                            //                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04 + CT_SUPPLIERSLIPCD_NAME_02; // 入荷返品
                            //            }
                            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                            //        }
                            //        else if (data.SupplierFormal == 2)   // 出荷
                            //        {
                            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                            //            //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04;
                            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                            //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //            row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03; // 発注
                            //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                            //        }
                            //        else // 支払
                            //        {
                            //            // [※支払伝票はここにこない]
                            //            //row[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                            //        }
                            //        // 担当者
                            //        row2[_dataSet.StcList.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                            //        // 金額
                            //        row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;

                            //        // 消費税の累計を取得
                            //        consumeTaxTotal = data.StockPriceConsTax;
                                    
                            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                            //        //// 消費税転嫁区分により表示するかしないか

                            //        //// [総額表示する]の場合は全て表示(明細単位と同じなので)
                            //        //if (data.SuppTtlAmntDspWayCd == 1) // *** 総額表示する ***
                            //        //{
                            //        //    // [総額表示する]の場合は明細単位以外は設定されない。明細以外を考慮する必要なし
                            //        //    // テスト時にも、明細以外を設定しているデータがある場合は、データが間違い
                            //        //    stckPrcConsTaxIncluAdjust = true;
                            //        //}
                            //        //else // *** 総額表示しない ***
                            //        //{
                            //        //    if (data.SuppCTaxLayCd == 0 || // 伝票単位(0)
                            //        //        data.SuppCTaxLayCd == 1)   // 明細単位(1)
                            //        //    {
                            //        //        // 表示する
                            //        //        stckPrcConsTaxIncluAdjust = true;
                            //        //    }
                            //        //    else // 請求親(2)・請求子(3)・非課税(9)
                            //        //    {
                            //        //        // 内税金額があれば内税金額を表示する
                            //        //        if (data.StckPrcConsTaxInclu > 0)
                            //        //        {
                            //        //            stckPrcConsTaxIncluAdjust = true;
                            //        //        }
                            //        //        else
                            //        //        {
                            //        //            // 内税金額がなければ非表示
                            //        //            stckPrcConsTaxIncluAdjust = false;
                            //        //        }
                            //        //    }
                            //        //}
                            //        //// 消費税
                            //        //row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                            //        # region [消費税関連]
                            //        bool printTax = true;
                            //        Int64 salesTotalTaxInc;
                            //        Int64 salesTotalTaxExc = data.SalesTotalTaxExc;
                            //        Int64 salesPriceConsTax;

                            //        // 印刷する消費税額の取得
                            //        if ( data.ConsTaxLayMethod == 0 || data.ConsTaxLayMethod == 1 ) // 伝票単位or明細単位
                            //        {
                            //            salesPriceConsTax = data.SalesTotalTaxInc - data.SalesTotalTaxExc;
                            //        }
                            //        else
                            //        {
                            //            salesPriceConsTax = 0;
                            //        }

                            //        // 税込金額の取得
                            //        salesTotalTaxInc = salesTotalTaxExc + salesPriceConsTax;

                            //        if ( printTax )
                            //        {
                            //            // 消費税印字有無判定と金額制御
                            //            int totalAmountDispWayCd = data.TotalAmountDispWayCd;

                            //            // 消費税印字有無判定
                            //            printTax = ReflectMoneyForTaxPrintOfSlip( ref salesTotalTaxExc, ref salesPriceConsTax, ref salAmntConsTaxInclu, ref salesTotalTaxInc, totalAmountDispWayCd, data.ConsTaxLayMethod );
                            //            if ( printTax )
                            //            {
                            //                if ( salesPriceConsTax != 0 )
                            //                {
                            //                    row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = salesPriceConsTax;
                            //                }
                            //                else
                            //                {
                            //                    // 印字しない
                            //                    row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            //                }
                            //            }
                            //            else
                            //            {
                            //                // 印字しない
                            //                row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            //            }
                            //        }
                            //        else
                            //        {
                            //            // 印字しない
                            //            row2[_dataSet.SalesList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            //        }
                            //        // 税抜金額セット
                            //        row2[_dataSet.SalesList.SalesTotalTaxExcColumn.ColumnName] = salesTotalTaxExc;
                            //        // 粗利セット
                            //        row2[_dataSet.SalesList.GrossProfitColumn.ColumnName] = salesTotalTaxExc - data.TotalCost;
                            //        # endregion
                            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                            //        // 備考１
                            //        row2[_dataSet.StcList.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                            //        // 備考２
                            //        row2[_dataSet.StcList.SupplierSlipNote2Column.ColumnName] = data.SupplierSlipNote2;
                            //        // 拠点コード
                            //        row2[_dataSet.StcList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                            //        // 拠点名
                            //        row2[_dataSet.StcList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                            //        // 発行者
                            //        row2[_dataSet.StcList.StockInputNameColumn.ColumnName] = data.StockInputName;
                            //        // 仕入先コード[NULLのときは空白]
                            //        if (data.SupplierCd == 0)
                            //        {
                            //            row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = data.SupplierCd;//.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                            //        }
                            //        // 仕入先名
                            //        row2[_dataSet.StcList.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                            //        // UOEリマーク1
                            //        row2[_dataSet.StcList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                            //        // UOEリマーク2
                            //        row2[_dataSet.StcList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                            //        // 仕入SEQ/支払№[NULLのときは空白]
                            //        if (data.SupplierSlipNo == 0)
                            //        {
                            //            row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                            //        }
                            //        // 計上日
                            //        row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                            //        // 買掛区分
                            //        row2[_dataSet.StcList.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                            //        // 買掛区分名
                            //        if (data.AccPayDivCd == 1)
                            //        {
                            //            row2[_dataSet.StcList.AccPayDivCdNameColumn.ColumnName] = CT_ACCPAYDIV_NAME_01;
                            //        }
                            //        // 赤伝区分
                            //        if (data.DebitNoteDiv == 0)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                            //        }
                            //        else if (data.DebitNoteDiv == 1)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                            //        }
                            //        else if (data.DebitNoteDiv == 2)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = string.Empty;
                            //        }

                            //        #endregion // 仕入伝票
                            //    }
                            //    else
                            //    {
                            //        #region 支払伝票
                            //        //----------
                            //        // 支払伝票
                            //        //----------

                            //        //row2[_dataSet.StcList.SelectionColumn.ColumnName] = false;
                            //        // 行No
                            //        row2[_dataSet.StcList.RowNoColumn.ColumnName] = rowNo;
                            //        // データ区分
                            //        row2[_dataSet.StcList.DataDivColumn.ColumnName] = data.DataDiv;
                            //        // 伝票日付
                            //        row2[_dataSet.StcList.StockDateColumn.ColumnName] = data.StockDate;
                            //        // 伝票番号
                            //        row2[_dataSet.StcList.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                            //        // 仕入形式
                            //        row2[_dataSet.StcList.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                            //        // 仕入伝票区分
                            //        row2[_dataSet.StcList.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                            //        // 仕入伝票区分名判定
                            //        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                            //        // 担当者
                            //        row2[_dataSet.StcList.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                            //        // 金額
                            //        row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                            //        // 消費税
                            //        row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            //        // 備考１
                            //        row2[_dataSet.StcList.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                            //        // 備考２
                            //        row2[_dataSet.StcList.SupplierSlipNote2Column.ColumnName] = string.Empty;
                            //        // 拠点
                            //        // 拠点コード
                            //        row2[_dataSet.StcList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                            //        // 拠点名
                            //        row2[_dataSet.StcList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                            //        // 発行者
                            //        row2[_dataSet.StcList.StockInputNameColumn.ColumnName] = data.StockInputName;
                            //        // 仕入先コード[NULLのときは空白]
                            //        if (data.SupplierCd == 0)
                            //        {
                            //            row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = data.SupplierCd.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                            //        }
                            //        // 仕入先名
                            //        row2[_dataSet.StcList.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                            //        // UOEリマーク1
                            //        row2[_dataSet.StcList.UoeRemark1Column.ColumnName] = string.Empty;
                            //        // UOEリマーク2
                            //        row2[_dataSet.StcList.UoeRemark2Column.ColumnName] = string.Empty;
                            //        // 仕入SEQ/支払№[NULLのときは空白]
                            //        if (data.SupplierSlipNo == 0)
                            //        {
                            //            row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                            //        }
                            //        // 計上日
                            //        row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                            //        // 買掛区分
                            //        row2[_dataSet.StcList.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                            //        // 買掛区分名
                            //        row2[_dataSet.StcList.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                            //        // 赤伝区分
                            //        if (data.DebitNoteDiv == 0)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                            //        }
                            //        else if (data.DebitNoteDiv == 1)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                            //        }
                            //        else if (data.DebitNoteDiv == 2)
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                            //        }
                            //        else
                            //        {
                            //            row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = string.Empty;
                            //        }

                            //        #endregion // 支払伝票
                            //    }

                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 DEL
                            //    //// 最後の行のみ、伝票番号の比較を行わずに行を追加する
                            //    //if (rowNo == allRowCount)
                            //    //{
                            //    //    // 行追加
                            //    //    this._dataSet.StcList.Rows.Add(row2);

                            //    //    // 伝票枚数+1
                            //    //    slipCount++;
                            //    //}
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 DEL

                            //    // 伝票番号を保存
                            //    supplierSlipNoExt = data.SupplierSlipNo;
                            //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                            //    exSupplierFormal = data.SupplierFormal;
                            //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD

                            //    // 伝票番号および受注ステータスを保存
                            //    //exSupplierFormal = data.SupplierFormal;
                            //    //exSlipNum = data.PartySaleSlipNum;
                            //}
                            //else
                            //{
                            //    // [総額表示する]の場合は全て表示(明細単位と同じなので)
                            //    if (data.SuppTtlAmntDspWayCd == 1) // *** 総額表示する ***
                            //    {
                            //        // 消費税額を累計する
                            //        consumeTaxTotal += data.StockPriceConsTax;
                            //        stckPrcConsTaxIncluAdjust = true;
                            //    }
                            //    else // *** 総額表示しない ***
                            //    {
                            //        if (data.SuppCTaxLayCd == 0 || // 伝票単位(0)
                            //            data.SuppCTaxLayCd == 1)   // 明細単位(1)
                            //        {
                            //            // 消費税額を累計する
                            //            consumeTaxTotal += data.StockPriceConsTax;
                            //            stckPrcConsTaxIncluAdjust = true;
                            //        }
                            //        else // 請求親(2)・請求子(3)・非課税(9)
                            //        {
                            //            // 内税金額があれば内税金額を累計する
                            //            if (data.StckPrcConsTaxInclu + data.StckDisTtlTaxInclu > 0)
                            //            {
                            //                consumeTaxTotal += data.StckPrcConsTaxInclu + data.StckDisTtlTaxInclu;
                            //                stckPrcConsTaxIncluAdjust = true;
                            //            }
                            //            // 内税金額がなければ累計しない
                            //        }
                            //    }

                            //    // 消費税額を累計する
                            //    //consumeTaxTotal += data.StckPrcConsTaxInclu;
                            //}
                            # endregion
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                            // DEL 2010/01/26 MANTIS対応[14325]：インストール直後に仕入伝票×1と支払伝票×1を登録した状態で検索すると、仕入伝票が表示されない ---------->>>>>
                            // FIXME:伝票番号または受注ステータスが変化したら伝票表示データテーブルを構築
                            //if ( index > 0 && (data.SupplierSlipNo != supplierSlipNoExt || data.SupplierFormal != exSupplierFormal) )
                            // DEL 2010/01/26 MANTIS対応[14325]：インストール直後に仕入伝票×1と支払伝票×1を登録した状態で検索すると、仕入伝票が表示されない ----------<<<<<
                            // ADD 2010/01/26 MANTIS対応[14325]：インストール直後に仕入伝票×1と支払伝票×1を登録した状態で検索すると、仕入伝票が表示されない ---------->>>>>
                            if (
                                index > 0
                                    &&
                                (data.SupplierSlipNo != supplierSlipNoExt || data.SupplierFormal != exSupplierFormal || !exSupplierSlipCdName.Equals(GetSupplierSlipCdName(data))))
                            {
                                // ADD 2010/01/26 MANTIS対応[14325]：インストール直後に仕入伝票×1と支払伝票×1を登録した状態で検索すると、仕入伝票が表示されない ----------<<<<<
                                SuppPrtPprStcTblRsltWork prevData = (SuppPrtPprStcTblRsltWork)((suppPrtPprStcTblRsltWorkObj as ArrayList)[index - 1]);

                                rowDetailNo = rowNo;
                                if ( prevData.DataDiv != 0 )
                                {
                                    // 支払手数料・支払値引 行追加
                                    SuppPtrStcDetailDataSet.StcDetailDataTable table = this._dataSet.StcDetail;
                                    AddFeeAndDepositRow( ref table, ref rowDetailNo, prevData );
                                }
                                rowNo = rowDetailNo;

                                // 伝票表示グリッドへのセット
                                RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu, prevSalesSlipNum );

                                // 合計表示に加算
                                StockAmount_Total += prevData.StockTtlPricTaxExc;
                                if (prevData.SuppCTaxLayCd == 0 || prevData.SuppCTaxLayCd == 1)
                                {
                                    totalConsumeTaxAmount += prevData.StockPriceConsTax;
                                }
                                // 伝票枚数+1
                                slipCount++;

                                salAmntConsTaxInclu = 0; // 伝票別内税金額集計値を初期化
                                prevSalesSlipNum = salesSlipNum;
                                salesSlipNum = string.Empty;

                                // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ---------->>>>>
                                if (ExtractCancelFlag == true)
                                {
                                    supplierSlipNoExt = data.SupplierSlipNo;
                                    exSupplierFormal = data.SupplierFormal;
                                    exSupplierSlipCdName = GetSupplierSlipCdName(data);
                                    rowNo++;

                                    break;
                                }
                                // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ----------<<<<<
                            }
                            // 伝票番号を保存
                            supplierSlipNoExt = data.SupplierSlipNo;
                            exSupplierFormal = data.SupplierFormal;
                            exSupplierSlipCdName = GetSupplierSlipCdName(data); // 仕入伝票区分名を保存

                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                            #endregion // 伝票表示データテーブル

                            rowNo++;

                        }
                        catch (ConstraintException ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/16 ADD
                        //// 最後の行のみ、伝票番号の比較を行わずに行を追加する
                        //if ( rowNo - 1 == allRowCount )
                        //{
                        //    // 行追加
                        //    this._dataSet.StcList.Rows.Add( row2 );

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                        //    // 仕入金額合計
                        //    StockAmount_Total += wkStockAmount;
                        //    // 消費税
                        //    totalConsumeTaxAmount += wkTotalConsumeTaxAmount;
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

                        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                        //    // 伝票表示グリッドへのセット
                        //    CustPrtPprSalTblRsltWork prevData = (CustPrtPprSalTblRsltWork)((custPrtPprSalTblRsltWorkObj as ArrayList)[index - 1]);
                        //    RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu );
                        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                        //    // 伝票枚数+1
                        //    slipCount++;
                        //}
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/16 ADD
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    } // for ( int index = 0; index < (suppPrtPprStcTblRsltWorkObj as ArrayList).Count; index++ )

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    // 最後の行のみ、伝票番号の比較を行わずに行を追加する
                    if ( suppPrtPprStcTblRsltWorkObj != null && (suppPrtPprStcTblRsltWorkObj as ArrayList).Count > 0 )
                    {
                        ArrayList retList = (ArrayList)suppPrtPprStcTblRsltWorkObj;
                        // DEL 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ---------->>>>>
                        // FIXME:SuppPrtPprStcTblRsltWork prevData = (SuppPrtPprStcTblRsltWork)(retList[retList.Count - 1]);
                        // DEL 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ----------<<<<<
                        // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ---------->>>>>
                        SuppPrtPprStcTblRsltWork prevData = (SuppPrtPprStcTblRsltWork)(retList[lastIndex]);
                        // ADD 2010/01/27 MANTIS対応[14545]：得意先電子元帳と同様の速度アップ対応（2009/10/07実施）の組み込み ----------<<<<<

                        rowDetailNo = rowNo;
                        if ( prevData.DataDiv != 0 )
                        {
                            // 支払手数料・支払値引 行追加
                            SuppPtrStcDetailDataSet.StcDetailDataTable table = this._dataSet.StcDetail;
                            AddFeeAndDepositRow( ref table, ref rowDetailNo, prevData );
                        }
                        rowNo = rowDetailNo;

                        // 伝票表示グリッドへのセット
                        RecordSetToSlipList( prevData, rowNo, salAmntConsTaxInclu, salesSlipNum );

                        // 合計表示に加算
                        StockAmount_Total += prevData.StockTtlPricTaxExc;
                        if ( prevData.SuppCTaxLayCd == 0 || prevData.SuppCTaxLayCd == 1 )
                        {
                            totalConsumeTaxAmount += prevData.StockPriceConsTax;
                        }

                        // 伝票枚数+1
                        slipCount++;
                    }

                    # region [支払伝票の行№採番]
                    // 支払のみ行番号採番しなおす
                    DateTime exStockDate = DateTime.MinValue;
                    rowDetailNo = 1;
                    int exStockNum = -1;
                    //exSlipNum = string.Empty;

                    string filter = string.Format( "{0} <> {1}", this._dataSet.StcDetail.DataDivColumn.ColumnName, 0 );
                    string sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                    this._dataSet.StcDetail.StockDateColumn.ColumnName,
                                    this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName,
                                    this._dataSet.StcDetail.DataDivColumn.ColumnName,
                                    this._dataSet.StcDetail.SupplierFormalColumn.ColumnName,
                                    this._dataSet.StcDetail.SupplierSlipCdColumn.ColumnName,
                                    this._dataSet.StcDetail.StockRowNoColumn.ColumnName );

                    DataRow[] dataRows = this._dataSet.StcDetail.Select( filter, sort );
                    DataRow dataRow = null;
                    for ( int i = 0; i <= dataRows.Length - 1; i++ )
                    {
                        dataRow = dataRows[i];

                        if ( (exStockDate.Equals( dataRow[this._dataSet.StcDetail.StockDateColumn.ColumnName] ) == false) ||
                            (exStockNum.Equals( dataRow[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] ) == false) )
                        {
                            rowDetailNo = 1;
                        }

                        dataRow[this._dataSet.StcDetail.StockRowNoColumn.ColumnName] = rowDetailNo++;

                        exStockDate = (DateTime)dataRow[this._dataSet.StcDetail.StockDateColumn.ColumnName];
                        exStockNum = (int)dataRow[this._dataSet.StcDetail.SupplierSlipNoColumn.ColumnName];
                    }
                    # endregion

                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    # region // DEL
                    //#region 残高照会データテーブル

                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 DEL
                    ////if (this._dataSet.BalanceTotal.Rows.Count > 0)
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 DEL
                    //{
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 DEL
                    //    //// 残高表示をデータセットへ
                    //    //row3 = this._dataSet.BalanceTotal.Rows[0];
                    //    //// 支払残高
                    //    //row3[_dataSet.BalanceTotal.PaymentRemainColumn.ColumnName] = StockTotalPayBalance + totalThisStockPrice + totalOfsThisSalesTax - totalThisTimePayNrml;
                    //    //// 今回仕入
                    //    //row3[_dataSet.BalanceTotal.ThisStockPriceTotalColumn.ColumnName] = totalThisStockPrice;
                    //    //// 消費税
                    //    //row3[_dataSet.BalanceTotal.OfsThisStockTaxColumn.ColumnName] = totalOfsThisSalesTax;
                    //    //// 今回支払
                    //    //row3[_dataSet.BalanceTotal.ThisTimePayNrmlColumn.ColumnName] = totalThisTimePayNrml;
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 DEL
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
                    //    if (this._dataSet.BalanceTotal.Rows.Count > 0)
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
                    //        this._dataSet.BalanceTotal.Rows.Add(row3);
                    //    }
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

                    //    // 標準価格合計
                    //    row3[_dataSet.BalanceTotal.StandardPrice_TotalColumn.ColumnName] = StandardPrice_Total;
                    //    // 売上金額合計
                    //    row3[_dataSet.BalanceTotal.StockAmount_TotalColumn.ColumnName] = StockAmount_Total;

                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //    //if (totalAmount > 0)
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    //    if ( totalAmount != 0 )
                    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    //    {
                    //        // 標準価格平均
                    //        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = StandardPrice_Total / totalAmount;
                    //        // 売上金額平均
                    //        row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = StockAmount_Total / totalAmount;
                    //    }
                    //    else
                    //    {
                    //        // 標準価格平均
                    //        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = 0;
                    //        // 売上金額平均
                    //        row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = 0;
                    //    }

                    //    // 伝票枚数
                    //    row3[_dataSet.BalanceTotal.SlipCountColumn.ColumnName] = slipCount;
                    //    // 明細数
                    //    row3[_dataSet.BalanceTotal.DetailCountColumn.ColumnName] = detailSlipCount;
                    //    // 数量計
                    //    row3[_dataSet.BalanceTotal.AmountColumn.ColumnName] = totalAmount;
                    //    // 消費税計
                    //    row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount;
                    //}
                    //#endregion // 残高照会データテーブル
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/17 ADD
                else
                {
                    // 件数ゼロならばリモートstatus＝0:正常でも該当なしで返す
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/17 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                #region 残高照会データテーブル

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 DEL
                //if (this._dataSet.BalanceTotal.Rows.Count > 0)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 DEL
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 DEL
                    //// 残高表示をデータセットへ
                    //row3 = this._dataSet.BalanceTotal.Rows[0];
                    //// 支払残高
                    //row3[_dataSet.BalanceTotal.PaymentRemainColumn.ColumnName] = StockTotalPayBalance + totalThisStockPrice + totalOfsThisSalesTax - totalThisTimePayNrml;
                    //// 今回仕入
                    //row3[_dataSet.BalanceTotal.ThisStockPriceTotalColumn.ColumnName] = totalThisStockPrice;
                    //// 消費税
                    //row3[_dataSet.BalanceTotal.OfsThisStockTaxColumn.ColumnName] = totalOfsThisSalesTax;
                    //// 今回支払
                    //row3[_dataSet.BalanceTotal.ThisTimePayNrmlColumn.ColumnName] = totalThisTimePayNrml;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
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
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

                    // 標準価格合計
                    row3[_dataSet.BalanceTotal.StandardPrice_TotalColumn.ColumnName] = StandardPrice_Total;
                    // 売上金額合計
                    //row3[_dataSet.BalanceTotal.StockAmount_TotalColumn.ColumnName] = StockAmount_Total;     //DEL 李小路　2012/04/05 Redmine#29310
                    row3[_dataSet.BalanceTotal.StockAmount_TotalColumn.ColumnName] = StockAmount_Total2;    //ADD 李小路　2012/04/05 Redmine#29310

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                    //if (totalAmount > 0)
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                    if ( totalAmount != 0 )
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                    {
                        // 標準価格平均
                        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = StandardPrice_Total / totalAmount;
                        // 売上金額平均
                        //row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = StockAmount_Total / totalAmount;   //DEL 李小路　2012/04/05 Redmine#29310
                        row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = StockAmount_Total2 / totalAmount;    //ADD 李小路　2012/04/05 Redmine#29310 
                    }
                    else
                    {
                        // 標準価格平均
                        row3[_dataSet.BalanceTotal.StandardPrice_AvgColumn.ColumnName] = 0;
                        // 売上金額平均
                        row3[_dataSet.BalanceTotal.StockAmount_AvgColumn.ColumnName] = 0;
                    }

                    // 伝票枚数
                    row3[_dataSet.BalanceTotal.SlipCountColumn.ColumnName] = slipCount;
                    // 明細数
                    row3[_dataSet.BalanceTotal.DetailCountColumn.ColumnName] = detailSlipCount;
                    // 数量計
                    row3[_dataSet.BalanceTotal.AmountColumn.ColumnName] = totalAmount;
                    // 消費税計
                    //row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount;    //DEL 李小路　2012/04/05 Redmine#29310
                    row3[_dataSet.BalanceTotal.ConsumeTaxAmountColumn.ColumnName] = totalConsumeTaxAmount2;   //ADD 李小路　2012/04/05 Redmine#29310
                }

                #endregion // 残高照会データテーブル
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
            }

            return status;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
        /// <summary>
        /// 支払手数料・支払値引行の追加(明細)
        /// </summary>
        /// <param name="stcDetailDataTable"></param>
        /// <param name="rowDetailNo"></param>
        /// <param name="data"></param>
        /// <remarks>
        /// <br>Update Note: 2009/09/08 黄偉兵 過去分表示対応</br>
        /// </remarks>
        private void AddFeeAndDepositRow( ref SuppPtrStcDetailDataSet.StcDetailDataTable table, ref int rowDetailNo, SuppPrtPprStcTblRsltWork data )
        {
            DataRow row;

            // 手数料明細追加
            if ( data.FeePayment > 0 )
            {
                rowDetailNo++;
                row = table.NewRow();

                # region [支払手数料]
                row[_dataSet.StcDetail.DataDivColumn.ColumnName] = data.DataDiv;
                row[_dataSet.StcDetail.RowNoColumn.ColumnName] = rowDetailNo; // ←行番号
                row[_dataSet.StcDetail.StockDateColumn.ColumnName] = data.StockDate;
                row[_dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;
                row[_dataSet.StcDetail.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                row[_dataSet.StcDetail.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                row[_dataSet.StcDetail.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                row[_dataSet.StcDetail.GoodsNameColumn.ColumnName] = "手数料"; // ←品名
                row[_dataSet.StcDetail.GoodsNoColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.MakerNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.StockCountColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                //row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = string.Empty; //DEL 2011/12/09
                row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value; //ADD 2011/12/09
                row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                // 消費税率
                row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912 
                row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.FeePayment; // ←金額(明細)
                row[_dataSet.StcDetail.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                if ( data.SupplierSlipNote2.Equals( "0" ) )
                {
                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = string.Empty;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = CT_SUPPLIERNOTE2_PRE + data.SupplierSlipNote2;
                }
                row[_dataSet.StcDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                row[_dataSet.StcDetail.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                // row[_dataSet.StcDetail.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                if ( data.SupplierCd == 0 )
                {
                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft( CT_DEPTH_SUPPLIERCODE, '0' );
                }
                row[_dataSet.StcDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                row[_dataSet.StcDetail.StockOrderDivCdColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseCdColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.UoeRemark1Column.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.UoeRemark2Column.ColumnName] = string.Empty;
                if ( data.SupplierSlipNo == 0 )
                {
                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                }
                if ( data.StockAddUpADate == DateTime.MinValue )
                {
                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                }
                row[_dataSet.StcDetail.AccPayDivCdColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                if ( data.DebitNoteDiv == 0 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                }
                else
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                row[_dataSet.StcDetail.SalesSlipNumColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.CustomerSnmColumn.ColumnName] = string.Empty;
                # endregion

                table.Rows.Add( row );
            }

            if ( data.DiscountPayment > 0 )
            {
                rowDetailNo++;
                row = table.NewRow();

                # region [支払値引]
                row[_dataSet.StcDetail.DataDivColumn.ColumnName] = data.DataDiv;
                row[_dataSet.StcDetail.RowNoColumn.ColumnName] = rowDetailNo; // ←行番号
                row[_dataSet.StcDetail.StockDateColumn.ColumnName] = data.StockDate;
                row[_dataSet.StcDetail.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.StockRowNoColumn.ColumnName] = data.StockRowNo;
                row[_dataSet.StcDetail.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                row[_dataSet.StcDetail.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                row[_dataSet.StcDetail.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                row[_dataSet.StcDetail.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                row[_dataSet.StcDetail.GoodsNameColumn.ColumnName] = "値引"; // ←品名
                row[_dataSet.StcDetail.GoodsNoColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.GoodsMakerCdColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.MakerNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.BLGoodsCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.BLGroupCodeColumn.ColumnName] = string.Empty; //DBNull.Value;
                row[_dataSet.StcDetail.StockCountColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.OpenPriceDivColumn.ColumnName] = data.OpenPriceDiv;
                //row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = string.Empty; //DEL 2011/12/09
                row[_dataSet.StcDetail.ListPriceTaxExcFlColumn.ColumnName] = DBNull.Value; //ADD 2011/12/09
                row[_dataSet.StcDetail.StockPriceConsTaxColumn.ColumnName] = DBNull.Value;
                // 消費税率
                row[_dataSet.StcDetail.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912 
                row[_dataSet.StcDetail.StockTtlPricTaxExcColumn.ColumnName] = data.DiscountPayment; // ←金額(明細)
                row[_dataSet.StcDetail.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                if ( data.SupplierSlipNote2.Equals( "0" ) )
                {
                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = string.Empty;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierSlipNote2Column.ColumnName] = CT_SUPPLIERNOTE2_PRE + data.SupplierSlipNote2;
                }
                row[_dataSet.StcDetail.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                row[_dataSet.StcDetail.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                // row[_dataSet.StcDetail.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                if ( data.SupplierCd == 0 )
                {
                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft( CT_DEPTH_SUPPLIERCODE, '0' );
                }
                row[_dataSet.StcDetail.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                row[_dataSet.StcDetail.StockOrderDivCdColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.StockOrderDivCdNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseCdColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseNameColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.WarehouseShelfNoColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.UoeRemark1Column.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.UoeRemark2Column.ColumnName] = string.Empty;
                if ( data.SupplierSlipNo == 0 )
                {
                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                }
                if ( data.StockAddUpADate == DateTime.MinValue )
                {
                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row[_dataSet.StcDetail.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                }
                row[_dataSet.StcDetail.AccPayDivCdColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                if ( data.DebitNoteDiv == 0 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                }
                else
                {
                    row[_dataSet.StcDetail.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                row[_dataSet.StcDetail.SalesSlipNumColumn.ColumnName] = string.Empty;
                row[_dataSet.StcDetail.SalesDateColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.CustomerCodeColumn.ColumnName] = DBNull.Value;
                row[_dataSet.StcDetail.CustomerSnmColumn.ColumnName] = string.Empty;
                # endregion

                table.Rows.Add( row );
            }
        }
        /// <summary>
        /// 伝票グリッドへのセット(伝票単位)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rowNo"></param>
        /// <param name="salAmntConsTaxInclu"></param>
        /// <param name="salesSlipNum"></param>
        /// <remarks>
        /// <br>Update Note : 2013/01/21 FSI冨樫 紗由里</br>
        /// <br>              [仕入返品計上] 選択チェックボックス設定追加,伝票区分名に返品予定追加</br>
        /// <br>Update Note : 2013/04/18 王君</br>
        /// <br>管理番号　　: 10801804-00 2013/05/15配信分</br>
        /// <br>            : Redmine#35363 仕入先電子元帳の伝票表示に背景色不具合の対応</br>
        /// <br>Update Note: 2020/03/11 時シン</br>
        /// <br>管理番号   : 11570208-00</br>
        /// <br>           : PMKOBETSU-2912 軽減税率対応</br>
        /// <br>           : 伝票タブ、明細タブに「消費税率」項目を追加</br>
        /// </remarks>
        private void RecordSetToSlipList( SuppPrtPprStcTblRsltWork data, int rowNo, long salAmntConsTaxInclu, string salesSlipNum )
        {
            // 伝票番号および受注スタータスが異なれば別伝票として取得
            DataRow row2 = _dataSet.StcList.NewRow();
            DataRow retRow = _dataSet.RetGdsStcList.NewRow(); //ADD 2013/01/21 [仕入返品計上]

            // 仕入伝票なのか支払伝票なのかでデータの構造が異なる
            if ( data.DataDiv == 0 )
            {
                #region 仕入伝票
                //-----------
                // 仕入伝票
                //-----------

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                // 返品制御用 金額符号
                int slipSign = 1;

                // 返品判定
                if ( data.SupplierSlipCd == 20 ) slipSign *= -1;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

                row2[_dataSet.StcList.SelectionColumn.ColumnName] = false; // ADD 2013/01/21 [仕入返品計上]
                // 行No
                row2[_dataSet.StcList.RowNoColumn.ColumnName] = rowNo;
                // データ区分
                row2[_dataSet.StcList.DataDivColumn.ColumnName] = data.DataDiv;
                // 伝票日付
                row2[_dataSet.StcList.StockDateColumn.ColumnName] = data.StockDate;
                // 伝票番号
                row2[_dataSet.StcList.PartySaleSlipNumColumn.ColumnName] = data.PartySaleSlipNum;
                // 仕入形式
                row2[_dataSet.StcList.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                // 仕入伝票区分
                row2[_dataSet.StcList.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;

                // 仕入伝票番号
                row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;

                // 仕入伝票区分名判定
                if ( data.SupplierFormal == 0 )   // 仕入
                {
                    if ( data.SupplierSlipCd == 10 )
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01;
                    }
                    else if ( data.SupplierSlipCd == 20 )
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                        //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01 + CT_SUPPLIERSLIPCD_NAME_02; // 仕入返品
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                    }
                }
                else if ( data.SupplierFormal == 1 )   // 受注
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                    //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                    if ( data.SupplierSlipCd == 10 )
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04; // 入荷
                    }
                    else if ( data.SupplierSlipCd == 20 )
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04 + CT_SUPPLIERSLIPCD_NAME_02; // 入荷返品
                    }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                }
                else if ( data.SupplierFormal == 2 )   // 出荷
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 DEL
                    //row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_04;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/24 ADD
                    row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_03; // 発注
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/24 ADD
                }
                // ----------ADD 2013/01/21 [仕入返品計上]----------->>>>>
                else if (data.SupplierFormal == 3)   // 返品予定
                {
                    if (data.SupplierSlipCd == 10)
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_01; // 仕入
                    }
                    else if (data.SupplierSlipCd == 20)
                    {
                        row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_02; // 返品
                    }
                }
                // ----------ADD 2013/01/21 [仕入返品計上]-----------<<<<<
                else // 支払
                {
                    // [※支払伝票はここにこない]
                    //row[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                }

                // 担当者
                row2[_dataSet.StcList.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                //// 金額
                //row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //// 消費税の累計を取得
                //consumeTaxTotal = data.StockPriceConsTax;

                //// 消費税転嫁区分により表示するかしないか

                //// [総額表示する]の場合は全て表示(明細単位と同じなので)
                //if (data.SuppTtlAmntDspWayCd == 1) // *** 総額表示する ***
                //{
                //    // [総額表示する]の場合は明細単位以外は設定されない。明細以外を考慮する必要なし
                //    // テスト時にも、明細以外を設定しているデータがある場合は、データが間違い
                //    stckPrcConsTaxIncluAdjust = true;
                //}
                //else // *** 総額表示しない ***
                //{
                //    if (data.SuppCTaxLayCd == 0 || // 伝票単位(0)
                //        data.SuppCTaxLayCd == 1)   // 明細単位(1)
                //    {
                //        // 表示する
                //        stckPrcConsTaxIncluAdjust = true;
                //    }
                //    else // 請求親(2)・請求子(3)・非課税(9)
                //    {
                //        // 内税金額があれば内税金額を表示する
                //        if (data.StckPrcConsTaxInclu > 0)
                //        {
                //            stckPrcConsTaxIncluAdjust = true;
                //        }
                //        else
                //        {
                //            // 内税金額がなければ非表示
                //            stckPrcConsTaxIncluAdjust = false;
                //        }
                //    }
                //}
                //// 消費税
                //row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/05 ADD
                # region [消費税関連]
                bool printTax = true;
                Int64 salesTotalTaxInc;
                Int64 salesTotalTaxExc = data.StockTtlPricTaxExc;
                Int64 salesPriceConsTax;

                //// 印刷する消費税額の取得
                if ( data.SuppCTaxLayCd == 0 || data.SuppCTaxLayCd == 1 ) // 伝票単位or明細単位
                {
                    salesPriceConsTax = data.StockTtlPricTaxInc - data.StockTtlPricTaxExc;
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
                    int totalAmountDispWayCd = data.SuppTtlAmntDspWayCd;

                    // 消費税印字有無判定
                    printTax = ReflectMoneyForTaxPrintOfSlip( ref salesTotalTaxExc, ref salesPriceConsTax, ref salAmntConsTaxInclu, ref salesTotalTaxInc, totalAmountDispWayCd, data.SuppCTaxLayCd);
                    if ( printTax )
                    {
                        if ( salesPriceConsTax != 0 )
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                            //row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = salesPriceConsTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                            row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = slipSign * salesPriceConsTax;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD
                            row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = data.SupplierConsTaxRate; // ADD 時シン 2020/03/11 PMKOBETSU-2912

                        }
                        else
                        {
                            // 印字しない
                            row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                            row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                        }
                    }
                    else
                    {
                        // 印字しない
                        row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                        row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                    }
                }
                else
                {
                    // 印字しない
                    row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                    row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
                //// 税抜金額セット
                //row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = salesTotalTaxExc;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
                // 税抜金額セット
                row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = slipSign * salesTotalTaxExc;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/05 ADD

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                // 備考１
                row2[_dataSet.StcList.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                // 備考２
                row2[_dataSet.StcList.SupplierSlipNote2Column.ColumnName] = data.SupplierSlipNote2;
                // 拠点コード
                row2[_dataSet.StcList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                // 拠点名
                row2[_dataSet.StcList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                // 発行者
                // row2[_dataSet.StcList.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                // 仕入先コード[NULLのときは空白]
                if ( data.SupplierCd == 0 )
                {
                    row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = data.SupplierCd;//.ToString().PadLeft(CT_DEPTH_SUPPLIERCODE, '0');
                }
                // 仕入先名
                row2[_dataSet.StcList.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                // UOEリマーク1
                row2[_dataSet.StcList.UoeRemark1Column.ColumnName] = data.UoeRemark1;
                // UOEリマーク2
                row2[_dataSet.StcList.UoeRemark2Column.ColumnName] = data.UoeRemark2;
                // 仕入SEQ/支払№[NULLのときは空白]
                if ( data.SupplierSlipNo == 0 )
                {
                    row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                }
                // 計上日
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                if ( data.StockAddUpADate != DateTime.MinValue )
                {
                    row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                }
                else
                {
                    row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                // 買掛区分
                row2[_dataSet.StcList.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                // 買掛区分名
                if ( data.AccPayDivCd == 1 )
                {
                    row2[_dataSet.StcList.AccPayDivCdNameColumn.ColumnName] = CT_ACCPAYDIV_NAME_01;
                }
                // 赤伝区分
                if ( data.DebitNoteDiv == 0 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                }
                else
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = string.Empty;
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                // 同時売上伝票番号(伝票内に１行でもあれば退避しておく(背景・文字色変更のため))
                //row2[_dataSet.StcList.SalesSlipNumColumn.ColumnName] = salesSlipNum; // DEL 王君 2013/04/18 Redmine#35363
                row2[_dataSet.StcList.SalesSlipNumColumn.ColumnName] = data.SalesSlipNum; // ADD 王君 2013/04/18 Redmine#35363
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD

                // ----------ADD 2013/01/21----------->>>>>
                // 行No
                retRow[_dataSet.RetGdsStcList.RowNoColumn.ColumnName] = rowNo;
                // 仕入伝票番号
                retRow[_dataSet.RetGdsStcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;

                retRow[_dataSet.RetGdsStcList.LogicalDeleteCdColumn.ColumnName] = data.SlpLogicalDeleteCode;    // 論理削除区分
                retRow[_dataSet.RetGdsStcList.SuppTtlAmntDspWayCdColumn.ColumnName] = data.SuppTtlAmntDspWayCd; // 仕入先総額表示方法区分
                retRow[_dataSet.RetGdsStcList.SuppCTaxLayCdColumn.ColumnName] = data.SuppCTaxLayCd;             // 仕入先消費税転嫁方式コード
                retRow[_dataSet.RetGdsStcList.SupplierConsTaxRateColumn.ColumnName] = data.SupplierConsTaxRate; // 仕入先消費税税率

                retRow[_dataSet.RetGdsStcList.StockSectionCdColumn.ColumnName] = data.StockSectionCd; // 仕入拠点コード
                retRow[_dataSet.RetGdsStcList.StockGoodsCdColumn.ColumnName] = data.StockGoodsCd; // 仕入商品区分
                retRow[_dataSet.RetGdsStcList.StockTtlPricTaxIncColumn.ColumnName] = data.StockPriceTaxInc; // 仕入金額計（税込み）
                retRow[_dataSet.RetGdsStcList.StockAddUpSectionCdColumn.ColumnName] = data.StockAddUpSectionCd; // 仕入計上拠点コード
                retRow[_dataSet.RetGdsStcList.SubSectionCodeColumn.ColumnName] = data.SlpSubSectionCode; // 部門コード
                // 業種コード
                retRow[_dataSet.RetGdsStcList.BusinessTypeCodeColumn.ColumnName] = data.BusinessTypeCode;
                // 業種名称
                retRow[_dataSet.RetGdsStcList.BusinessTypeNameColumn.ColumnName] = data.BusinessTypeName;
                // 販売エリアコード
                retRow[_dataSet.RetGdsStcList.SalesAreaCodeColumn.ColumnName] = data.SalesAreaCode;
                // 販売エリア名称
                retRow[_dataSet.RetGdsStcList.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                // 総額表示掛率適用区分
                retRow[_dataSet.RetGdsStcList.TtlAmntDispRateApyColumn.ColumnName] = data.TtlAmntDispRateApy;
                // 仕入端数処理区分
                retRow[_dataSet.RetGdsStcList.StockFractionProcCdColumn.ColumnName] = data.StockFractionProcCd;
                // 伝票住所区分
                retRow[_dataSet.RetGdsStcList.SlipAddressDivColumn.ColumnName] = data.SlipAddressDiv;
                // 納品先コード
                retRow[_dataSet.RetGdsStcList.AddresseeCodeColumn.ColumnName] = data.SlpAddresseeCode;
                // 納品先名称
                retRow[_dataSet.RetGdsStcList.AddresseeNameColumn.ColumnName] = data.SlpAddresseeName;
                // 納品先名称2
                retRow[_dataSet.RetGdsStcList.AddresseeName2Column.ColumnName] = data.AddresseeName2;
                // 納品先郵便番号
                retRow[_dataSet.RetGdsStcList.AddresseePostNoColumn.ColumnName] = data.AddresseePostNo;
                // 納品先住所1_都道府県市区郡・町村・字
                retRow[_dataSet.RetGdsStcList.AddresseeAddr1Column.ColumnName] = data.AddresseeAddr1;
                // 納品先住所3_番地
                retRow[_dataSet.RetGdsStcList.AddresseeAddr3Column.ColumnName] = data.AddresseeAddr3;
                // 納品先住所4_アパート名称
                retRow[_dataSet.RetGdsStcList.AddresseeAddr4Column.ColumnName] = data.AddresseeAddr4;
                // 納品先電話番号
                retRow[_dataSet.RetGdsStcList.AddresseeTelNoColumn.ColumnName] = data.AddresseeTelNo;
                // 納品先FAX番号
                retRow[_dataSet.RetGdsStcList.AddresseeFaxNoColumn.ColumnName] = data.AddresseeFaxNo;
                // 直送区分
                retRow[_dataSet.RetGdsStcList.DirectSendingCdColumn.ColumnName] = data.SlpDirectSendingCd;
                // ----------ADD 2013/01/21-----------<<<<<

                #endregion // 仕入伝票
            }
            else
            {
                #region 支払伝票
                //----------
                // 支払伝票
                //----------

                //row2[_dataSet.StcList.SelectionColumn.ColumnName] = false;
                row2[_dataSet.StcList.SelectionColumn.ColumnName] = DBNull.Value;    // ADD 2013/01/21 [仕入返品計上]
                // 行No
                row2[_dataSet.StcList.RowNoColumn.ColumnName] = rowNo;
                // データ区分
                row2[_dataSet.StcList.DataDivColumn.ColumnName] = data.DataDiv;
                // 伝票日付
                row2[_dataSet.StcList.StockDateColumn.ColumnName] = data.StockDate;
                // 伝票番号
                row2[_dataSet.StcList.PartySaleSlipNumColumn.ColumnName] = string.Empty;
                // 仕入形式
                row2[_dataSet.StcList.SupplierFormalColumn.ColumnName] = data.SupplierFormal;
                // 仕入伝票区分
                row2[_dataSet.StcList.SupplierSlipCdColumn.ColumnName] = data.SupplierSlipCd;
                // 仕入伝票区分名判定
                row2[_dataSet.StcList.SupplierSlipCdNameColumn.ColumnName] = CT_SUPPLIERSLIPCD_NAME_05;
                // 担当者
                row2[_dataSet.StcList.StockAgentNameColumn.ColumnName] = data.StockAgentName;
                // 金額
                row2[_dataSet.StcList.StockTtlPricTaxExcColumn.ColumnName] = data.StockTtlPricTaxExc;
                // 消費税
                row2[_dataSet.StcList.ConsumeTaxColumn.ColumnName] = DBNull.Value;
                // 消費税率
                row2[_dataSet.StcList.SupplierConsTaxRateColumn.ColumnName] = DBNull.Value; // ADD 時シン 2020/03/11 PMKOBETSU-2912
                // 備考１
                row2[_dataSet.StcList.SupplierSlipNote1Column.ColumnName] = data.SupplierSlipNote1;
                // 備考２
                row2[_dataSet.StcList.SupplierSlipNote2Column.ColumnName] = string.Empty;
                // 拠点
                // 拠点コード
                row2[_dataSet.StcList.SectionCdColumn.ColumnName] = data.SectionCode.Trim();
                // 拠点名
                row2[_dataSet.StcList.SectionGuideNmColumn.ColumnName] = data.SectionGuideNm;
                // 発行者
                // row2[_dataSet.StcList.StockInputNameColumn.ColumnName] = data.StockInputName; // DEL 2009/09/08
                // 仕入先コード[NULLのときは空白]
                if ( data.SupplierCd == 0 )
                {
                    row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.StcList.SupplierCdColumn.ColumnName] = data.SupplierCd;//data.SupplierCd.ToString().PadLeft( CT_DEPTH_SUPPLIERCODE, '0' );
                }
                // 仕入先名
                row2[_dataSet.StcList.SupplierSnmColumn.ColumnName] = data.SupplierSnm;
                // UOEリマーク1
                row2[_dataSet.StcList.UoeRemark1Column.ColumnName] = string.Empty;
                // UOEリマーク2
                row2[_dataSet.StcList.UoeRemark2Column.ColumnName] = string.Empty;
                // 仕入SEQ/支払№[NULLのときは空白]
                if ( data.SupplierSlipNo == 0 )
                {
                    row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = DBNull.Value;
                }
                else
                {
                    row2[_dataSet.StcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;
                }
                // 計上日
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 DEL
                //row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/26 ADD
                if ( data.StockAddUpADate != DateTime.MinValue )
                {
                    row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = data.StockAddUpADate;
                }
                else
                {
                    row2[_dataSet.StcList.StockAddUpADateColumn.ColumnName] = DBNull.Value;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
                // 買掛区分
                row2[_dataSet.StcList.AccPayDivCdColumn.ColumnName] = data.AccPayDivCd;
                // 買掛区分名
                row2[_dataSet.StcList.AccPayDivCdNameColumn.ColumnName] = string.Empty;
                // 赤伝区分
                if ( data.DebitNoteDiv == 0 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_KURODEN;
                }
                else if ( data.DebitNoteDiv == 1 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_AKADEN;
                }
                else if ( data.DebitNoteDiv == 2 )
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = CT_ACCPAYDIV_NAME_MOTOKURO;
                }
                else
                {
                    row2[_dataSet.StcList.DebitNoteDivColumn.ColumnName] = string.Empty;
                }

                // ----------ADD 2013/01/21----------->>>>>
                // 行No
                retRow[_dataSet.RetGdsStcList.RowNoColumn.ColumnName] = rowNo;
                // 仕入伝票番号
                retRow[_dataSet.RetGdsStcList.SupplierSlipNoColumn.ColumnName] = data.SupplierSlipNo;

                retRow[_dataSet.RetGdsStcList.LogicalDeleteCdColumn.ColumnName] = data.SlpLogicalDeleteCode;    // 論理削除区分
                retRow[_dataSet.RetGdsStcList.SuppTtlAmntDspWayCdColumn.ColumnName] = data.SuppTtlAmntDspWayCd; // 仕入先総額表示方法区分
                retRow[_dataSet.RetGdsStcList.SuppCTaxLayCdColumn.ColumnName] = data.SuppCTaxLayCd;             // 仕入先消費税転嫁方式コード
                retRow[_dataSet.RetGdsStcList.SupplierConsTaxRateColumn.ColumnName] = data.SupplierConsTaxRate; // 仕入先消費税税率

                retRow[_dataSet.RetGdsStcList.StockSectionCdColumn.ColumnName] = data.StockSectionCd; // 仕入拠点コード
                retRow[_dataSet.RetGdsStcList.StockGoodsCdColumn.ColumnName] = data.StockGoodsCd; // 仕入商品区分
                retRow[_dataSet.RetGdsStcList.StockTtlPricTaxIncColumn.ColumnName] = data.StockPriceTaxInc; // 仕入金額計（税込み）
                retRow[_dataSet.RetGdsStcList.StockAddUpSectionCdColumn.ColumnName] = data.StockAddUpSectionCd; // 仕入計上拠点コード
                retRow[_dataSet.RetGdsStcList.SubSectionCodeColumn.ColumnName] = data.SlpSubSectionCode; // 部門コード
                // 業種コード
                retRow[_dataSet.RetGdsStcList.BusinessTypeCodeColumn.ColumnName] = data.BusinessTypeCode;
                // 業種名称
                retRow[_dataSet.RetGdsStcList.BusinessTypeNameColumn.ColumnName] = data.BusinessTypeName;
                // 販売エリアコード
                retRow[_dataSet.RetGdsStcList.SalesAreaCodeColumn.ColumnName] = data.SalesAreaCode;
                // 販売エリア名称
                retRow[_dataSet.RetGdsStcList.SalesAreaNameColumn.ColumnName] = data.SalesAreaName;
                // 総額表示掛率適用区分
                retRow[_dataSet.RetGdsStcList.TtlAmntDispRateApyColumn.ColumnName] = data.TtlAmntDispRateApy;
                // 仕入端数処理区分
                retRow[_dataSet.RetGdsStcList.StockFractionProcCdColumn.ColumnName] = data.StockFractionProcCd;
                // 伝票住所区分
                retRow[_dataSet.RetGdsStcList.SlipAddressDivColumn.ColumnName] = data.SlipAddressDiv;
                // 納品先コード
                retRow[_dataSet.RetGdsStcList.AddresseeCodeColumn.ColumnName] = data.SlpAddresseeCode;
                // 納品先名称
                retRow[_dataSet.RetGdsStcList.AddresseeNameColumn.ColumnName] = data.SlpAddresseeName;
                // 納品先名称2
                retRow[_dataSet.RetGdsStcList.AddresseeName2Column.ColumnName] = data.AddresseeName2;
                // 納品先郵便番号
                retRow[_dataSet.RetGdsStcList.AddresseePostNoColumn.ColumnName] = data.AddresseePostNo;
                // 納品先住所1_都道府県市区郡・町村・字
                retRow[_dataSet.RetGdsStcList.AddresseeAddr1Column.ColumnName] = data.AddresseeAddr1;
                // 納品先住所3_番地
                retRow[_dataSet.RetGdsStcList.AddresseeAddr3Column.ColumnName] = data.AddresseeAddr3;
                // 納品先住所4_アパート名称
                retRow[_dataSet.RetGdsStcList.AddresseeAddr4Column.ColumnName] = data.AddresseeAddr4;
                // 納品先電話番号
                retRow[_dataSet.RetGdsStcList.AddresseeTelNoColumn.ColumnName] = data.AddresseeTelNo;
                // 納品先FAX番号
                retRow[_dataSet.RetGdsStcList.AddresseeFaxNoColumn.ColumnName] = data.AddresseeFaxNo;
                // 直送区分
                retRow[_dataSet.RetGdsStcList.DirectSendingCdColumn.ColumnName] = data.SlpDirectSendingCd;
                // ----------ADD 2013/01/21-----------<<<<<

                #endregion // 支払伝票
            }

            // 行追加
            this._dataSet.StcList.Rows.Add( row2 );
            this._dataSet.RetGdsStcList.Rows.Add(retRow); //ADD 2013/01/21 [仕入返品計上]
        }

        // ADD 2010/01/26 MANTIS対応[14325]：インストール直後に仕入伝票×1と支払伝票×1を登録した状態で検索すると、仕入伝票が表示されない ---------->>>>>
        /// <summary>
        /// 仕入伝票区分名を取得します。
        /// </summary>
        /// <remarks>
        /// RecordSetToSlipList()よりメソッドとして切り出し
        /// </remarks>
        /// <param name="data">伝票明細データ</param>
        /// <returns>仕入伝票区分名(仕入、支払、発注など)</returns>
        /// <exception cref="ArgumentNullException"><c>data</c>が<c>null</c>です。</exception>
        private static string GetSupplierSlipCdName(SuppPrtPprStcTblRsltWork data)
        {
            if (data == null) throw new ArgumentNullException("data");

            if (data.SupplierFormal == 0)   // 仕入
            {
                if (data.SupplierSlipCd == 10)
                {
                    return CT_SUPPLIERSLIPCD_NAME_01;   // 仕入
                }
                else if (data.SupplierSlipCd == 20)
                {
                    return CT_SUPPLIERSLIPCD_NAME_01 + CT_SUPPLIERSLIPCD_NAME_02; // 仕入返品
                }
            }
            else if (data.SupplierFormal == 1)   // 受注
            {
                if (data.SupplierSlipCd == 10)
                {
                    return CT_SUPPLIERSLIPCD_NAME_04; // 入荷
                }
                else if (data.SupplierSlipCd == 20)
                {
                    return CT_SUPPLIERSLIPCD_NAME_04 + CT_SUPPLIERSLIPCD_NAME_02; // 入荷返品
                }
            }
            else if (data.SupplierFormal == 2)   // 出荷
            {
                return CT_SUPPLIERSLIPCD_NAME_03; // 発注
            }

            // 支払
            return CT_SUPPLIERSLIPCD_NAME_05;
        }
        // ADD 2010/01/26 MANTIS対応[14325]：インストール直後に仕入伝票×1と支払伝票×1を登録した状態で検索すると、仕入伝票が表示されない ----------<<<<<

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
                        if ( consTaxLayMethod == 9 )
                        {
                            printTax = false;
                            priceConsTax = 0;
                            moneyTaxInc = moneyTaxExc;
                        }
                        else
                        {
                            printTax = (priceConsTaxInclu != 0);
                            priceConsTax = priceConsTaxInclu;
                            moneyTaxInc = moneyTaxExc + priceConsTaxInclu;
                        }
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/26 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/18 ADD
        /// <summary>
        /// 残高照会抽出
        /// </summary>
        /// <param name="suppPrtPprBlDspRsltWorkObj"></param>
        /// <param name="remainData"></param>
        /// <param name="suppPrtPpr"></param>
        /// <remarks>仕入年間実績照会のリモートを使用します</remarks>
        private int SearchBlDspRslt( ref object suppPrtPprBlDspRsltWorkObj,　ref RemainDataExtra remainDataEx, SuppPrtPpr suppPrtPpr )
        {
            suppPrtPprBlDspRsltWorkObj = new ArrayList();
            SuplierPayWork paraWork = new SuplierPayWork();

            string resultSectCd = string.Empty;
            string addUpSecCode = string.Empty;
            int supplierCd = 0;
            int payeeCd = 0;

            # region [条件セット]

            paraWork.EnterpriseCode = suppPrtPpr.EnterpriseCode; // 企業コード

            //-----------------------------------------------------------
            // 拠点入力判定
            //-----------------------------------------------------------
            if ( suppPrtPpr.SectionCode == null || suppPrtPpr.SectionCode.Length == 0 )
            {
                // 00:全社ならば表示しない
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            string sectionCode = suppPrtPpr.SectionCode[0].Trim();
            paraWork.AddUpSecCode = sectionCode; // 拠点コード

            if ( sectionCode == "00" ||
                string.IsNullOrEmpty( sectionCode ) )
            {
                // 00:全社ならば表示しない
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }


            //-----------------------------------------------------------
            // 仕入先・支払先入力判定
            //-----------------------------------------------------------
            // --- ADD 2012/09/13 ---------->>>>>
            if (_opt_SupplierSummary == true)
            {
                if (suppPrtPpr.SupplierCd != 0)
                {
                    paraWork.SupplierCd = suppPrtPpr.SupplierCd; // 仕入先コード←仕入先コード
                }
                else
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }
            else
            {
            // --- ADD 2012/09/13 ----------<<<<<
            if ( suppPrtPpr.SupplierCd != 0 )
            {
                // 仕入先読み込み
                Supplier supplier;
                int readStatus = _supplierAcs.Read( out supplier, suppPrtPpr.EnterpriseCode, suppPrtPpr.SupplierCd );
                if ( readStatus != 0 || supplier == null || supplier.LogicalDeleteCode != 0 )
                {
                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                }

                if ( suppPrtPpr.PayeeCode != 0 )
                {
                    //----------------------------------------------
                    // 仕入先＋支払先
                    //----------------------------------------------

                    // 親子関係判定
                    if ( supplier.PayeeCode == suppPrtPpr.PayeeCode && supplier.PaymentSectionCode.Trim() == sectionCode )
                    {
                        paraWork.SupplierCd = suppPrtPpr.PayeeCode; // 仕入先コード←支払先コード
                        paraWork.PayeeCode = supplier.PayeeCode;
                        paraWork.ResultsSectCd = "00";
                        paraWork.AddUpSecCode = sectionCode;

                        supplierCd = 0;
                        payeeCd = supplier.PayeeCode;
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
                    // 仕入先のみ
                    //----------------------------------------------
                    paraWork.SupplierCd = supplier.SupplierCd; // 仕入先コード←仕入先コード
                    paraWork.PayeeCode = supplier.PayeeCode;
                    paraWork.ResultsSectCd = supplier.PaymentSectionCode;
                    paraWork.AddUpSecCode = sectionCode;

                    supplierCd = supplier.SupplierCd;
                    payeeCd = supplier.PayeeCode;
                    resultSectCd = supplier.PaymentSectionCode;
                    addUpSecCode = sectionCode;
                }
            }
            else
            {
                if ( suppPrtPpr.PayeeCode != 0 )
                {
                    //----------------------------------------------
                    // 支払先のみ
                    //----------------------------------------------

                    // 支払先読み込み
                    Supplier supplier;
                    int readStatus = _supplierAcs.Read( out supplier, suppPrtPpr.EnterpriseCode, suppPrtPpr.PayeeCode );
                    if ( readStatus != 0 || supplier == null || supplier.LogicalDeleteCode != 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                    // 親子判定
                    if ( supplier.PayeeCode == supplier.SupplierCd && supplier.PaymentSectionCode.Trim() == sectionCode )
                    {
                        paraWork.SupplierCd = suppPrtPpr.PayeeCode; // 仕入先コード←支払先コード
                        paraWork.PayeeCode = supplier.SupplierCd;
                        paraWork.ResultsSectCd = "00";
                        paraWork.AddUpSecCode = sectionCode;

                        supplierCd = 0;
                        payeeCd = supplier.SupplierCd;
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
            }


            // 画面終了日
            paraWork.AddUpDate = suppPrtPpr.Ed_StockDate;

            # endregion

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            suppPrtPprBlDspRsltWorkObj = null;

            // --- ADD 2012/09/13 ---------->>>>>
            if (_opt_SupplierSummary != true)
            {
            # region [締済み：仕入先支払金額マスタ]
            //-----------------------------------------------
            // 締済み：仕入先支払金額マスタ
            //-----------------------------------------------
            object retObj;

            addUpSecCode = addUpSecCode.Trim();
            resultSectCd = resultSectCd.Trim();

            if ( payeeCd == supplierCd && addUpSecCode == resultSectCd )
            {
                supplierCd = 0;
                resultSectCd = "00";
            }

            status = _ISuppRsltUpdDB.SearchSuplierPay( paraWork.EnterpriseCode, addUpSecCode, payeeCd, resultSectCd, supplierCd, 0, out retObj );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retObj != null)
            {
                CustomSerializeArrayList retObjList = (CustomSerializeArrayList)retObj;
                if ( retObjList.Count > 0 )
                {
                    for ( int index = 0; index < retObjList.Count; index++ )
                    {
                        ArrayList list = (ArrayList)(retObjList[index] as ArrayList)[0];

                        foreach ( SuplierPayWork retWork in list as ArrayList )
                        {
                            if ( retWork.AddUpDate < suppPrtPpr.Ed_StockDate ) continue;
                            if ( retWork.StartCAddUpUpdDate > suppPrtPpr.Ed_StockDate ) continue;

                            SuppPrtPprBlDspRsltWork rsltWork = new SuppPrtPprBlDspRsltWork();
                            remainDataEx = new RemainDataExtra();

                            # region [結果セット]

                            rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;// 請求年月
                            rsltWork.SuppCTaxationCd = retWork.SuppCTaxLayCd;// 転嫁方式

                            rsltWork.StockTtl2TmBfBlPay = retWork.StockTtl3TmBfBlPay; // 前々々回残
                            rsltWork.LastTimePayment = retWork.StockTtl2TmBfBlPay; // 前々回残
                            rsltWork.StockTotalPayBalance = retWork.LastTimePayment; // 前回残

                            remainDataEx.ThisStockPriceTotal = retWork.OfsThisTimeStock; // 今回仕入
                            remainDataEx.OfsThisStockTax = retWork.OfsThisStockTax; // 消費税
                            remainDataEx.ThisTimePayNrml = retWork.ThisTimePayNrml; // 今回支払

                            remainDataEx.PaymentRemain = retWork.StockTotalPayBalance; // 支払残高

                            remainDataEx.DmdStDay = retWork.StartCAddUpUpdDate; // 締開始日
                            remainDataEx.TotalDay = retWork.AddUpDate; // 締処理日

                            remainDataEx.IsParent = (retWork.SupplierCd == retWork.PayeeCode || retWork.SupplierCd == 0); // 親フラグ

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
            }
            // --- ADD 2012/09/13 ----------<<<<<

            if ( suppPrtPprBlDspRsltWorkObj == null )
            {
                # region [未締：仕入締次集計リモート呼び出し]
                //-----------------------------------------------
                // 未締：仕入締次集計リモート呼び出し
                //-----------------------------------------------
                bool isParent;
                // --- ADD 2012/09/13 ---------->>>>>
                if (_opt_SupplierSummary == true)
                {
                    isParent = true;
                }
                else
                // --- ADD 2012/09/13 ----------<<<<<
                {
                if ( (paraWork.SupplierCd == paraWork.PayeeCode && paraWork.ResultsSectCd.Trim() == paraWork.AddUpSecCode.Trim())||
                     (supplierCd == 0 && resultSectCd.Trim() == "00") )
                {
                    isParent = true;
                    paraWork.SupplierCd = paraWork.PayeeCode;
                    paraWork.ResultsSectCd = paraWork.AddUpSecCode;
                }
                else
                {
                    isParent = false;
                    paraWork.SupplierCd = paraWork.PayeeCode;
                    paraWork.ResultsSectCd = paraWork.AddUpSecCode;
                }

                }
                

                object paraObj = paraWork;
                object childObj = null;
                string message;
                // --- DEL 2012/09/13 ---------->>>>>
                //status = _iSuplierPayDB.ReadSuplierPay( ref paraObj, ref childObj, out message );
                // --- DEL 2012/09/13 ----------<<<<< 
                // --- ADD 2012/09/13 ---------->>>>>
                if (_opt_SupplierSummary == true)
                {
                    status = _iSuplierPayDB.ReadSuplierPayByAddUpSecCode(ref paraObj, out message);
                }
                else
                {
                status = _iSuplierPayDB.ReadSuplierPay( ref paraObj, ref childObj, out message );
                }
                // --- ADD 2012/09/13 ----------<<<<<

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    SuppPrtPprBlDspRsltWork rsltWork = new SuppPrtPprBlDspRsltWork();
                    remainDataEx = new RemainDataExtra();

                    SuplierPayWork retWork = null;
                    if ( isParent )
                    {
                        retWork = (SuplierPayWork)paraObj;
                    }
                    else
                    {
                        foreach ( SuplierPayWork childWork in (childObj as ArrayList) )
                        {
                            if ( childWork.SupplierCd == supplierCd && childWork.ResultsSectCd.Trim() == resultSectCd.Trim() )
                            {
                                retWork = childWork;
                                break;
                            }
                        }
                    }

                    if ( retWork != null )
                    {
                        # region [結果セット]

                        rsltWork.AddUpYearMonth = retWork.AddUpYearMonth;// 請求年月
                        rsltWork.SuppCTaxationCd = retWork.SuppCTaxLayCd;// 転嫁方式

                        //rsltWork.StockTotalPayBalance = retWork.ThisTimeTtlBlcPay; // 前回残高
                        rsltWork.StockTtl2TmBfBlPay = retWork.StockTtl3TmBfBlPay; // 前々々回残
                        rsltWork.LastTimePayment = retWork.StockTtl2TmBfBlPay; // 前々回残
                        rsltWork.StockTotalPayBalance = retWork.LastTimePayment; // 前回残

                        remainDataEx.ThisStockPriceTotal = retWork.OfsThisTimeStock; // 今回仕入
                        remainDataEx.OfsThisStockTax = retWork.OfsThisStockTax; // 消費税
                        remainDataEx.ThisTimePayNrml = retWork.ThisTimePayNrml; // 今回支払

                        remainDataEx.PaymentRemain = retWork.StockTotalPayBalance; // 支払残高

                        remainDataEx.DmdStDay = retWork.StartCAddUpUpdDate; // 締開始日
                        remainDataEx.TotalDay = suppPrtPpr.Ed_StockDate; // 締処理日

                        remainDataEx.IsParent = isParent; // 親フラグ

                        # endregion

                        // 返却データ
                        ArrayList retList = new ArrayList();
                        retList.Add( rsltWork );
                        suppPrtPprBlDspRsltWorkObj = retList;
                    }
                }
                # endregion
            }

            // 該当データなし
            if ( suppPrtPprBlDspRsltWorkObj == null )
            {
                suppPrtPprBlDspRsltWorkObj = new ArrayList();
            }

            return status;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/18 ADD

        /// <summary>
        /// 残高一覧取得
        /// </summary>
        /// <param name="suppPrtPprBlnce"></param>
        /// <param name="remainType">0: 請求 1: 売掛</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 DEL
        //public int SearchBalance(SuppPrtPprBlnce suppPrtPprBlnce, int remainType)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
        public int SearchBalance( ref SuppPrtPprBlnce suppPrtPprBlnce, int remainType )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/11 ADD
            SuppPrtPprBlnce suppPrtPprBlnceBackup = suppPrtPprBlnce.Clone();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/11 ADD

            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/04 ADD
                // 残高一覧をクリア
                this._dataSet.BalanceList.Clear();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/04 ADD

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                //---------------------------------
                // 入力チェック
                //---------------------------------
                # region [入力チェック]
                //////-----------------------------------------------------------
                ////// 拠点入力判定
                //////-----------------------------------------------------------
                ////if ( suppPrtPprBlnce.SectionCode == null || suppPrtPprBlnce.SectionCode.Length == 0 )
                ////{
                ////    // 00:全社ならば表示しない
                ////    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                ////}

                ////string sectionCode = suppPrtPprBlnce.SectionCode[0].Trim();

                ////if ( sectionCode == "00" || string.IsNullOrEmpty( sectionCode ) )
                ////{
                ////    // 00:全社ならば表示しない
                ////    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                ////}

                if ( suppPrtPprBlnce.SectionCode == null || suppPrtPprBlnce.SectionCode.Length == 0 )
                {
                    suppPrtPprBlnce.SectionCode = new string[] { "00" };
                }
                string sectionCode = suppPrtPprBlnce.SectionCode[0].Trim();

                //-----------------------------------------------------------
                // 仕入先・支払先入力判定
                //-----------------------------------------------------------
                // --- ADD 2012/09/13 ---------->>>>>
                if (_opt_SupplierSummary == true)
                {
                    if (suppPrtPprBlnce.SupplierCd == 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                    suppPrtPprBlnce.PayeeCode = suppPrtPprBlnce.SupplierCd;
                    suppPrtPprBlnce.SupplierCd = 0;
                }
                else
                // --- ADD 2012/09/13 ----------<<<<<
                {
                if ( suppPrtPprBlnce.SupplierCd != 0 )
                {
                    // 仕入先読み込み
                    Supplier supplier;
                    int readStatus = _supplierAcs.Read( out supplier, suppPrtPprBlnce.EnterpriseCode, suppPrtPprBlnce.SupplierCd );
                    if ( readStatus != 0 || supplier == null || supplier.LogicalDeleteCode != 0 )
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    sectionCode = supplier.MngSectionCode.Trim();

                    if ( suppPrtPprBlnce.PayeeCode != 0 )
                    {
                        //----------------------------------------------
                        // 仕入先＋支払先
                        //----------------------------------------------

                        // 親子関係判定
                        if ( supplier.PayeeCode == suppPrtPprBlnce.PayeeCode && supplier.PaymentSectionCode.Trim() == sectionCode )
                        {
                            suppPrtPprBlnce.SupplierCd = 0;
                            suppPrtPprBlnce.PayeeCode = supplier.PayeeCode;
                            suppPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    else
                    {
                        //----------------------------------------------
                        // 仕入先のみ
                        //----------------------------------------------
                        if ( supplier.SupplierCd == supplier.PayeeCode )
                        {
                            suppPrtPprBlnce.SupplierCd = 0;
                            suppPrtPprBlnce.PayeeCode = supplier.PayeeCode;
                            suppPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                    }
                    // 拠点更新
                    if ( UpdateSection != null )
                    {
                        UpdateSection( this, supplier.MngSectionCode, supplier.MngSectionName );
                    }
                }
                else
                {
                    if ( suppPrtPprBlnce.PayeeCode != 0 )
                    {
                        //----------------------------------------------
                        // 支払先のみ
                        //----------------------------------------------

                        // 支払先読み込み
                        Supplier supplier;
                        int readStatus = _supplierAcs.Read( out supplier, suppPrtPprBlnce.EnterpriseCode, suppPrtPprBlnce.PayeeCode );
                        if ( readStatus != 0 || supplier == null || supplier.LogicalDeleteCode != 0 )
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        sectionCode = supplier.MngSectionCode.Trim();

                        // 親子判定
                        if ( supplier.PayeeCode == supplier.SupplierCd && supplier.PaymentSectionCode.Trim() == sectionCode )
                        {
                            suppPrtPprBlnce.SupplierCd = 0;
                            suppPrtPprBlnce.PayeeCode = supplier.SupplierCd;
                            suppPrtPprBlnce.SectionCode[0] = sectionCode;
                        }
                        else
                        {
                            return (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        // 拠点更新
                        if ( UpdateSection != null )
                        {
                            UpdateSection( this, supplier.MngSectionCode, supplier.MngSectionName );
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
                }
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD

                //---------------------------------
                // パラメータクラスを作成
                //---------------------------------
                SuppPrtPprBlnceWork suppPrtPprBlnceWork = new SuppPrtPprBlnceWork();
                SuppPrtPprBlnce2SuppPrtPprBlnceWork( ref suppPrtPprBlnce, ref suppPrtPprBlnceWork );
                // --- ADD 2012/09/13 ---------->>>>>
                suppPrtPprBlnceWork.OptSupplierSummary = this._opt_SupplierSummary;
                // --- ADD 2012/09/13 ----------<<<<<
                //---------------------------------
                // 返り値で使用するクラスを作成
                //---------------------------------
                SuppPrtPprBlTblRsltWork suppPrtPprBlTblRsltWork = new SuppPrtPprBlTblRsltWork();
                object suppPrtPprBlTblRsltWorkObj = (object)suppPrtPprBlTblRsltWork;
                long counter = 0;
                int status;

                // readMode, logicalModeは現状未使用
                status = this._iSuppPrtPprWorkDB.SearchBlTbl( ref suppPrtPprBlTblRsltWorkObj, suppPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0 );
                int rowNo = 0;
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 取得した結果をデータセットにセット
                    foreach ( SuppPrtPprBlTblRsltWork data in (ArrayList)suppPrtPprBlTblRsltWorkObj )
                    {
                        try
                        {
                            DataRow row = this._dataSet.BalanceList.NewRow();

                            #region 残高一覧データ

                            row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo; // 行№
                            row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate; // 計上日
                            row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc; // 前回残高
                            row[this._dataSet.BalanceList.ThisTimePayNrmlColumn.ColumnName] = data.ThisTimePayNrml; // 今回支払額
                            row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc; // 繰越残高
                            row[this._dataSet.BalanceList.ThisTimeStockPriceColumn.ColumnName] = data.ThisTimeStockPrice; // 今回仕入
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 DEL
                            //row[this._dataSet.BalanceList.ThisStckPricRgdsDisColumn.ColumnName] = data.ThisStckPricRgdsDis; // 返品値引
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                            row[this._dataSet.BalanceList.ThisStckPricRgdsDisColumn.ColumnName] = -1 * data.ThisStckPricRgdsDis; // 返品値引(ﾏｲﾅｽ→ﾌﾟﾗｽ表記)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                            row[this._dataSet.BalanceList.OfsThisTimeStockColumn.ColumnName] = data.OfsThisTimeStock; // 純仕入額
                            row[this._dataSet.BalanceList.OfsThisStockTaxColumn.ColumnName] = data.OfsThisStockTax; // 消費税
                            row[this._dataSet.BalanceList.ThisStckPricTotalColumn.ColumnName] = data.ThisStckPricTotal; // 今回合計
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/20 ADD
                            row[this._dataSet.BalanceList.StckTtlPayBlcColumn.ColumnName] = data.StckTtlPayBlc; // 今回残高
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/20 ADD
                            row[this._dataSet.BalanceList.StockSlipCountColumn.ColumnName] = data.StockSlipCount; // 伝票枚数

                            this._dataSet.BalanceList.Rows.Add( row );

                            #endregion // 残高一覧データ

                            rowNo++;

                        }
                        catch ( ConstraintException )
                        {

                        }
                    }
                }

                return status;
            }
            finally
            {
                suppPrtPprBlnce= suppPrtPprBlnceBackup;
            }
        }
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// <summary>
        /// 残高一覧取得
        /// </summary>
        /// <param name="suppPrtPprBlnce">検索条件</param>
        /// <param name="remainType">0: 支払 1: 買掛</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: 出力残高一覧取得します。</br>
        /// <br>Programmer	: chenyd</br>
        /// <br>Date		: 2010/07/20</br>
        /// <br>Update Note: 2010/09/14 tianjw</br>
        /// <br>           　テキスト出力対応</br>
        /// </remarks>
        public int SearchBalanceAll(ref SuppPrtPprBlnce suppPrtPprBlnce, int remainType)
        {
            SuppPrtPprBlnce suppPrtPprBlnceBackup = suppPrtPprBlnce.Clone();

            try
            {
                // 残高一覧をクリア
                this._dataSet.BalanceList.Clear();

                //---------------------------------
                // パラメータクラスを作成
                //---------------------------------
                SuppPrtPprBlnceWork suppPrtPprBlnceWork = new SuppPrtPprBlnceWork();
                SuppPrtPprBlnce2SuppPrtPprBlnceWork(ref suppPrtPprBlnce, ref suppPrtPprBlnceWork);
                // --- ADD 2012/09/13 ---------->>>>>
                suppPrtPprBlnceWork.OptSupplierSummary = this._opt_SupplierSummary;
                // --- ADD 2012/09/13 ----------<<<<<

                //---------------------------------
                // 返り値で使用するクラスを作成
                //---------------------------------
                SuppPrtPprBlTblRsltWork suppPrtPprBlTblRsltWork = new SuppPrtPprBlTblRsltWork();

                object suppPrtPprBlTblRsltWorkObj = (object)suppPrtPprBlTblRsltWork;
                int status;

                // readMode, logicalModeは現状未使用
                status = this._iSuppPrtPprWorkDB.SearchBlTbl(ref suppPrtPprBlTblRsltWorkObj, suppPrtPprBlnceWork, remainType, 0, ConstantManagement.LogicalMode.GetData0);
                int rowNo = 0;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 取得した結果をデータセットにセット
                    foreach (SuppPrtPprBlTblRsltWork data in (ArrayList)suppPrtPprBlTblRsltWorkObj)
                    {
                        try
                        {
                            DataRow row = this._dataSet.BalanceList.NewRow();

                            #region 残高一覧データ

                            row[this._dataSet.BalanceList.RowNoColumn.ColumnName] = rowNo; // 行№
                            row[this._dataSet.BalanceList.SupplierNameColumn.ColumnName] = data.SupplierNm1; // 仕入先名
                            row[this._dataSet.BalanceList.SupplierCodeColumn.ColumnName] = data.SupplierCd;  // 仕入先コード
                            //row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = data.AddUpSecCode; // 拠点コード // DEL 2010/09/14
                            row[this._dataSet.BalanceList.SectionCodeColumn.ColumnName] = data.AddUpSecCode.Trim(); // 拠点コード // ADD 2010/09/14
                            row[this._dataSet.BalanceList.AddUpDateColumn.ColumnName] = data.AddUpDate; // 計上日
                            row[this._dataSet.BalanceList.LastTimeBlcColumn.ColumnName] = data.LastTimeBlc; // 前回残高
                            row[this._dataSet.BalanceList.ThisTimePayNrmlColumn.ColumnName] = data.ThisTimePayNrml; // 今回支払額
                            row[this._dataSet.BalanceList.ThisTimeTtlBlcColumn.ColumnName] = data.ThisTimeTtlBlc; // 繰越残高
                            row[this._dataSet.BalanceList.ThisTimeStockPriceColumn.ColumnName] = data.ThisTimeStockPrice; // 今回仕入
                            row[this._dataSet.BalanceList.ThisStckPricRgdsDisColumn.ColumnName] = -1 * data.ThisStckPricRgdsDis; // 返品値引(ﾏｲﾅｽ→ﾌﾟﾗｽ表記)
                            row[this._dataSet.BalanceList.OfsThisTimeStockColumn.ColumnName] = data.OfsThisTimeStock; // 純仕入額
                            row[this._dataSet.BalanceList.OfsThisStockTaxColumn.ColumnName] = data.OfsThisStockTax; // 消費税
                            row[this._dataSet.BalanceList.ThisStckPricTotalColumn.ColumnName] = data.ThisStckPricTotal; // 今回合計
                            row[this._dataSet.BalanceList.StckTtlPayBlcColumn.ColumnName] = data.StckTtlPayBlc; // 今回残高
                            row[this._dataSet.BalanceList.StockSlipCountColumn.ColumnName] = data.StockSlipCount; // 伝票枚数

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

                return status;
            }
            finally
            {
                suppPrtPprBlnce = suppPrtPprBlnceBackup;
            }
        }
        // ---------------------- ADD 2010/07/20---------------------------------<<<<<

        /// <summary>
        /// 検索結果からデータテーブルを作成
        /// </summary>
        /// <param name="suppPrtPprStcTblRsltWork">検索結果クラス</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2009/09/08 黄偉兵 過去分表示対応</br>
        /// </remarks>
        private bool AddRowDataFromSearchResult(SuppPrtPprStcTblRsltWork suppPrtPprSalTblRsltWork)
        {
            // 伝票・明細検索結果クラスよりデータセットを作成

            DataRow newDetailRow = this._dataSet.StcDetail.NewRow();      // 明細
            DataRow newSlipRow = this._dataSet.StcList.NewRow();          // 伝票
            

            //newDetailRow[

            return true;
        }

        /// <summary>
        /// パラメータクラス(PMKOU04002E.SuppPrtPpr)からリモートパラメータクラス(PMKOU04016D.SuppPrtPprWork)クラスへ変換
        /// </summary>
        /// <param name="suppPrtPpr"></param>
        /// <param name="suppPrtPprWork"></param>
        private void SuppPrtPpr2SuppPrtPprWork(ref SuppPrtPpr suppPrtPpr, ref SuppPrtPprWork suppPrtPprWork)
        {
            suppPrtPprWork.BLGoodsCode = suppPrtPpr.BLGoodsCode;
            suppPrtPprWork.BLGroupCode = suppPrtPpr.BLGroupCode;
            suppPrtPprWork.Ed_InputDay = suppPrtPpr.Ed_InputDay;
            suppPrtPprWork.Ed_StockDate = suppPrtPpr.Ed_StockDate;
            suppPrtPprWork.EnterpriseCode = suppPrtPpr.EnterpriseCode;
            suppPrtPprWork.GoodsMakerCd = suppPrtPpr.GoodsMakerCd;
            suppPrtPprWork.GoodsName = suppPrtPpr.GoodsName;
            suppPrtPprWork.GoodsNo = suppPrtPpr.GoodsNo;
            suppPrtPprWork.PartySaleSlipNum = suppPrtPpr.PartySaleSlipNum;
            suppPrtPprWork.PayeeCode = suppPrtPpr.PayeeCode;
            suppPrtPprWork.PaymentSlipNo = suppPrtPpr.PaymentSlipNo;
            suppPrtPprWork.SearchCnt = suppPrtPpr.SearchCnt;
            suppPrtPprWork.SearchType = suppPrtPpr.SearchType;
            suppPrtPprWork.SectionCode = suppPrtPpr.SectionCode;
            suppPrtPprWork.St_InputDay = suppPrtPpr.St_InputDay;
            suppPrtPprWork.St_StockDate = suppPrtPpr.St_StockDate;
            suppPrtPprWork.StockAgentCode = suppPrtPpr.StockAgentCode;
            // suppPrtPprWork.StockInputCode = suppPrtPpr.StockInputCode; // DEL 2009/09/08
            suppPrtPprWork.StockOrderDivCd = suppPrtPpr.StockOrderDivCd;
            suppPrtPprWork.SupplierCd = suppPrtPpr.SupplierCd;
            suppPrtPprWork.SupplierFormal = suppPrtPpr.SupplierFormal;
            suppPrtPprWork.SupplierSlipCd = suppPrtPpr.SupplierSlipCd;
            suppPrtPprWork.SupplierSlipNote1 = suppPrtPpr.SupplierSlipNote1;
            suppPrtPprWork.SupplierSlipNote2 = suppPrtPpr.SupplierSlipNote2;
            suppPrtPprWork.UoeRemark1 = suppPrtPpr.UoeRemark1;
            suppPrtPprWork.UoeRemark2 = suppPrtPpr.UoeRemark2;
            suppPrtPprWork.WarehouseCode = suppPrtPpr.WarehouseCode;
            suppPrtPprWork.WayToOrder = suppPrtPpr.WayToOrder;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/12 ADD
            suppPrtPprWork.StockSlipCdDtl = suppPrtPpr.StockSlipCdDtl;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/12 ADD
        }

        /// <summary>
        /// パラメータクラス(PMKOU04002E.SuppPrtPprBlnce)からリモートパラメータクラス(PMKOU04016D.CustPrtPprBlnceWork)クラスへ変換
        /// </summary>
        /// <param name="suppPrtPpr"></param>
        /// <param name="suppPrtPprWork"></param>
        /// <br>Update Note : 2010/07/20 chenyd</br>
        /// <br>           　テキスト出力対応</br>
        private void SuppPrtPprBlnce2SuppPrtPprBlnceWork(ref SuppPrtPprBlnce suppPrtPprBlnce, ref SuppPrtPprBlnceWork suppPrtPprBlnceWork)
        {
            suppPrtPprBlnceWork.EnterpriseCode = suppPrtPprBlnce.EnterpriseCode;
            suppPrtPprBlnceWork.SectionCode = suppPrtPprBlnce.SectionCode;
            suppPrtPprBlnceWork.SupplierCd = suppPrtPprBlnce.SupplierCd;
            suppPrtPprBlnceWork.PayeeCode = suppPrtPprBlnce.PayeeCode;
            suppPrtPprBlnceWork.St_AddUpYearMonth = suppPrtPprBlnce.St_AddUpYearMonth;
            suppPrtPprBlnceWork.Ed_AddUpYearMonth = suppPrtPprBlnce.Ed_AddUpYearMonth;
            // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
            suppPrtPprBlnceWork.St_SupplierCd = suppPrtPprBlnce.St_SupplierCd;
            suppPrtPprBlnceWork.Ed_SupplierCd = suppPrtPprBlnce.Ed_SupplierCd;
            suppPrtPprBlnceWork.SearchDiv = suppPrtPprBlnce.SearchDiv;
            // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
        }

        // --- ADD 2012/09/13 ---------->>>>>
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション情報制御処理。</br>
        /// <br>Programmer : FSI上北田 秀樹</br>
        /// <br>Date       : 2010/09/13</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            #region ●仕入先総括オプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_SupplierSummary = true;
            }
            else
            {
                this._opt_SupplierSummary = false;
            }
            #endregion
        }
        // --- ADD 2012/09/13 ----------<<<<<

        # region [残高表示情報]
        /// <summary>
        /// 残高表示情報
        /// </summary>
        public struct RemainDataExtra
        {
            /// <summary>今回仕入</summary>
            private Int64 _thisStockPriceTotal;
            /// <summary>消費税</summary>
            private Int64 _ofsThisStockTax;
            /// <summary>今回支払</summary>
            private Int64 _thisTimePayNrml;
            /// <summary>支払残高</summary>
            private Int64 _paymentRemain;
            /// <summary>締開始日</summary>
            private DateTime _dmdStDay;
            /// <summary>締処理日</summary>
            private DateTime _totalDay;
            /// <summary>親フラグ</summary>
            private bool _isParent;
            /// <summary>
            /// 今回仕入
            /// </summary>
            public Int64 ThisStockPriceTotal
            {
                get { return _thisStockPriceTotal; }
                set { _thisStockPriceTotal = value; }
            }
            /// <summary>
            /// 消費税
            /// </summary>
            public Int64 OfsThisStockTax
            {
                get { return _ofsThisStockTax; }
                set { _ofsThisStockTax = value; }
            }
            /// <summary>
            /// 今回支払
            /// </summary>
            public Int64 ThisTimePayNrml
            {
                get { return _thisTimePayNrml; }
                set { _thisTimePayNrml = value; }
            }
            /// <summary>
            /// 支払残高
            /// </summary>
            public Int64 PaymentRemain
            {
                get { return _paymentRemain; }
                set { _paymentRemain = value; }
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
