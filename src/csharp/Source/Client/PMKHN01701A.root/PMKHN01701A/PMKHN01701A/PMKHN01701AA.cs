//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業品番変換一括処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 陳永康
// 作 成 日  2015/01/26   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 田建委
// 作 成 日  2015/02/25   修正内容 : Redmine#44209 ファイル名等の対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/02/26   修正内容 : Redmine#44209 ファイルの先頭にヘッダとして項目名を出力する対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 陳永康
// 作 成 日  2015/02/27   修正内容 : Redmine#44209 優良設定マスタ変換処理の機能追加
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/03/02   修正内容 : Redmine#44209 三つ「仕様変更」の対応
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/03/16   修正内容 : Redmine#44209 優良設定マスタ変換の仕様変更の対応
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;  // DEL 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using System.Text.RegularExpressions;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 明治産業品番変換一括処理 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 明治産業品番変換一括処理で使用するデータを取得する。</br>
    /// <br>Programmer	: 陳永康</br>
    /// <br>Date		: 2015/01/26</br>
    /// <br>UpdateNote  : 2015/02/25 田建委 </br>
    /// <br>            : Redmine#44209 ファイル名等の対応</br>
    /// </remarks>
    public class MeijiGoodsChgAllAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 品番変換一括処理アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 品番変換一括処理アクセスクラスの初期化を行う。</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsChgAllAcs()
        {
            this._iMeijiGoodsChgAllDB = (IMeijiGoodsChgAllDB)MediationMeijiGoodsChgAllDB.GetMeijiGoodsChgAllDB();
            this._iofferPrimeSettingSearchDB = (IPrimeSettingDB)MediationPrimeSettingDB.GetPrimeSettingDB(); // ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
        }
        #endregion ■ Constructor

        #region ■ Private Member
        // メーカーコードリスト     
        private IMeijiGoodsChgAllDB _iMeijiGoodsChgAllDB;

        private IPrimeSettingDB _iofferPrimeSettingSearchDB; // ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
        #endregion ■ Private Member

        #region ■ Const Memebers
        private const int GOODSNOCHGSUCMODE = 0;
        private const int GOODSNOCHGERRMODE = 1;
        private const int GOODSMSTMODE = 2;
        private const int PRICEMSTMODE = 3;
        private const int STOCKMSTMODE = 4;
        private const int GOODSMNGMSTMODE = 5;
        private const int RATEMSTMODE = 6;
        private const int JOINMSTMODE = 7;
        private const int PARTSMSTMODE = 8;
        private const int GOODSSETMSTMODE = 9;
        private const int SHIPMENTERRMODE = 10;
        private const int SHIPMENTSUCMODE = 11;
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        private const int PRMUPDATEERRMODE = 12;
        private const int PRMSUCMODE = 13;
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

        private const int LOGKINGSUC = 0;
        private const int LOGKINGERR = 1;

        //----- DEL 2015/02/26 時シン Redmine#44209 ファイル名の定義を共通化対応----->>>>>
        ////----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
        //private const string ct_GOODS_ERROR = "(エラー)商品マスタログ.csv";
        //private const string ct_GOODS_LOG = "(変換済み)商品マスタログ.csv";
        //private const string ct_GOODSPRICE_ERROR = "(エラー)価格マスタログ.csv";
        //private const string ct_GOODSPRICE_LOG = "(変換済み)価格マスタログ.csv";
        //private const string ct_STOCK_ERROR = "(エラー)在庫マスタログ.csv";
        //private const string ct_STOCK_LOG = "(変換済み)在庫マスタログ.csv";
        //private const string ct_GOODSMNG_ERROR = "(エラー)商品管理情報マスタログ.csv";
        //private const string ct_GOODSMNG_LOG = "(変換済み)商品管理情報マスタログ.csv";
        //private const string ct_RATE_ERROR = "(エラー)掛率マスタログ.csv";
        //private const string ct_RATE_LOG = "(変換済み)掛率マスタログ.csv";
        //private const string ct_JOINPARTS_ERROR = "(エラー)結合マスタログ.csv";
        //private const string ct_JOINPARTS_LOG = "(変換済み)結合マスタログ.csv";
        //private const string ct_SUBST_ERROR = "(エラー)代替マスタログ.csv";
        //private const string ct_SUBST_LOG = "(変換済み)代替マスタログ.csv";
        //private const string ct_GOODSSET_ERROR = "(エラー)セットマスタログ.csv";
        //private const string ct_GOODSSET_LOG = "(変換済み)セットマスタログ.csv";
        //private const string ct_RENTDATA_ERROR = "(エラー)未計上貸出データログ.csv";
        //private const string ct_RENTDATA_LOG = "(変換済み)未計上貸出データログ.csv";
        //private const string ct_CROSS_INDEX_GOODSCHG_ERROR = "(エラー)品番変換マスタログ.csv";
        //private const string ct_CROSS_INDEX_GOODSCHG_LOG = "(変換済み)品番変換マスタログ.csv";
        ////----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<
        //----- DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイル名の定義を共通化対応-----<<<<<

        //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイル名の定義を共通化対応----->>>>>
        #region ファイル名
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        ///// <summary>
        ///// 商品マスタエラーログ
        ///// </summary>
        //public string ct_GOODS_ERROR = "(エラー)商品マスタログ.csv";
        ///// <summary>
        ///// 価格マスタエラーログ
        ///// </summary>
        //public string ct_GOODSPRICE_ERROR = "(エラー)価格マスタログ.csv";
        ///// <summary>
        ///// 在庫マスタエラーログ
        ///// </summary>
        //public string ct_STOCK_ERROR = "(エラー)在庫マスタログ.csv";
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        /// <summary>
        /// 商品在庫マスタエラーログ
        /// </summary>
        public string ct_GOODSSTOCK_ERROR = "(エラー)商品在庫マスタログ.csv";
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        /// <summary>
        /// 商品管理情報マスタエラーログ
        /// </summary>
        public string ct_GOODSMNG_ERROR = "(エラー)商品管理情報マスタログ.csv";
        /// <summary>
        /// 掛率マスタエラーログ
        /// </summary>
        public string ct_RATE_ERROR = "(エラー)掛率マスタログ.csv";
        /// <summary>
        /// 結合マスタエラーログ
        /// </summary>
        public string ct_JOINPARTS_ERROR = "(エラー)結合マスタログ.csv";
        /// <summary>
        /// 代替マスタエラーログ
        /// </summary>
        public string ct_SUBST_ERROR = "(エラー)代替マスタログ.csv";
        /// <summary>
        /// セットマスタエラーログ
        /// </summary>
        public string ct_GOODSSET_ERROR = "(エラー)セットマスタログ.csv";
        /// <summary>
        /// 未計上貸出データエラーログ
        /// </summary>
        public string ct_RENTDATA_ERROR = "(エラー)未計上貸出データログ.csv";
        /// <summary>
        /// 品番変換マスタエラーログ
        /// </summary>
        public string ct_CROSS_INDEX_GOODSCHG_ERROR = "(エラー)品番変換マスタログ.csv";
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        /// <summary>
        /// 優良設定マスタエラーログ
        /// </summary>
        public string ct_PRMSETTING_ERROR = "(エラー)優良設定マスタログ.csv";
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
        //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
        /// <summary>
        /// 優良設定提供分取得例外の場合
        /// </summary>
        public string ct_PRMOFFER_ERROR = "提供情報の取得に失敗しました。";
        //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<

        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        //private const string ct_GOODS_LOG = "(変換済み)商品マスタログ.csv";
        //private const string ct_GOODSPRICE_LOG = "(変換済み)価格マスタログ.csv";
        //private const string ct_STOCK_LOG = "(変換済み)在庫マスタログ.csv";
        //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        private const string ct_GOODSSTOCK_LOG = "(変換済み)商品在庫マスタログ.csv";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
        private const string ct_GOODSMNG_LOG = "(変換済み)商品管理情報マスタログ.csv";
        private const string ct_RATE_LOG = "(変換済み)掛率マスタログ.csv";
        private const string ct_JOINPARTS_LOG = "(変換済み)結合マスタログ.csv";
        private const string ct_SUBST_LOG = "(変換済み)代替マスタログ.csv";
        private const string ct_GOODSSET_LOG = "(変換済み)セットマスタログ.csv";
        private const string ct_RENTDATA_LOG = "(変換済み)未計上貸出データログ.csv";
        private const string ct_CROSS_INDEX_GOODSCHG_LOG = "(変換済み)品番変換マスタログ.csv";
        private const string ct_PRMSETTING_LOG = "(変換済み)優良設定マスタログ.csv"; // ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加
        #endregion
        //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイル名の定義を共通化対応-----<<<<<

        //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応----->>>>>
        #region 項目名
        private const int SUCLOGMODE = 0; // 成功モード
        private const int ERRLOGMODE = 1; // 失敗モード
        // ﾏｽﾀ種別
        private const string MSTDIV_COLUMN_NAME = "ﾏｽﾀ種別";
        // 価格開始日
        private const string PRICESTRDATE_COLUMN_NAME = "価格開始日";
        // 倉庫コード
        //private const string WARECODE_COLUMN_NAME = "倉庫コード"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string WARECODE_COLUMN_NAME = "倉庫"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 拠点コード
        //private const string SECTIONCODE_COLUMN_NAME = "拠点コード"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string SECTIONCODE_COLUMN_NAME = "拠点"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 単価掛率設定区分
        //private const string UNITRATESETDIVCD_COLUMN_NAME = "単価掛率設定区分";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string UNITRATESETDIVCD_COLUMN_NAME = "掛率設定区分";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 単価種類
        private const string UNITPRICEKIND_COLUMN_NAME = "単価種類";
        // 得意先コード
        //private const string CUSTOMERCODE_COLUMN_NAME = "得意先コード"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string CUSTOMERCODE_COLUMN_NAME = "得意先"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 得意先掛率グループコード
        //private const string CUSTRATEGRPCODE_COLUMN_NAME = "得意先掛率グループコード";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string CUSTRATEGRPCODE_COLUMN_NAME = "得意先掛率";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 仕入先コード
        //private const string SUPPLIERCD_COLUMN_NAME = "仕入先コード"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string SUPPLIERCD_COLUMN_NAME = "仕入先"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // ロット数
        //private const string LOTCOUNT_COLUMN_NAME = "ロット数"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string LOTCOUNT_COLUMN_NAME = "ﾛｯﾄ"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 結合元メーカーコード		
        //private const string JOINSOURCEMAKERCODE_COLUMN_NAME = "結合元メーカーコード"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string JOINSOURCEMAKERCODE_COLUMN_NAME = "結合元ﾒｰｶｰ"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 結合元品番(－付き品番)	
        //private const string JOINSOURPARTSNOWITHH_COLUMN_NAME = "結合元品番(－付き品番)";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string JOINSOURPARTSNOWITHH_COLUMN_NAME = "結合元品番";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 結合先メーカーコード
        //private const string JOINDESTMAKERCD_COLUMN_NAME = "結合先メーカーコード";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string JOINDESTMAKERCD_COLUMN_NAME = "結合先ﾒｰｶｰ";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 結合先品番(－付き品番)
        //private const string JOINDESTPARTSNORF_COLUMN_NAME = "結合先品番(－付き品番)"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string JOINDESTPARTSNORF_COLUMN_NAME = "結合先品番"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 変換後結合元品番(－付き品番)			
        //private const string NEWJOINSOURPARTSNOWITHH_COLUMN_NAME = "変換後結合元品番(－付き品番)";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string NEWJOINSOURPARTSNOWITHH_COLUMN_NAME = "変換後結合元品番";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 変換後結合先品番(－付き品番)
        //private const string NEWJOINDESTPARTSNORF_COLUMN_NAME = "変換後結合先品番(－付き品番)";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string NEWJOINDESTPARTSNORF_COLUMN_NAME = "変換後結合先品番";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 代替元メーカーコード
        //private const string CHGSRCMAKERCD_COLUMN_NAME = "代替元メーカーコード";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string CHGSRCMAKERCD_COLUMN_NAME = "代替元ﾒｰｶｰ";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 代替元品番
        private const string CHGSRCGOODSNO_COLUMN_NAME = "代替元品番";
        // 代替先メーカーコード
        //private const string CHGDESTMAKERCD_COLUMN_NAME = "代替先メーカーコード"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string CHGDESTMAKERCD_COLUMN_NAME = "代替先ﾒｰｶｰ"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 代替先品番
        private const string CHGDESTGOODSNO_COLUMN_NAME = "代替先品番";
        // 変換後代替元品番
        private const string CHGSRCCHGGOODSNO_COLUMN_NAME = "変換後代替元品番";
        // 変換後代替先品番
        private const string CHGDESTCHGGOODSNO_COLUMN_NAME = "変換後代替先品番";
        // 親メーカーコード
        //private const string PARENTGOODSMAKERCD_COLUMN_NAME = "親メーカーコード"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string PARENTGOODSMAKERCD_COLUMN_NAME = "親ﾒｰｶｰ"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 親商品番号
        //private const string PARENTGOODSNO_COLUMN_NAME = "親商品番号"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string PARENTGOODSNO_COLUMN_NAME = "親品番"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 子商品メーカーコード
        //private const string SUBGOODSMAKERCD_COLUMN_NAME = "子商品メーカーコード"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string SUBGOODSMAKERCD_COLUMN_NAME = "子ﾒｰｶｰ"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 子商品番号
        //private const string SUBGOODSNO_COLUMN_NAME = "子商品番号";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string SUBGOODSNO_COLUMN_NAME = "子品番";// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 変換後親品番
        private const string AFCHGPARENTGOODSNO_COLUMN_NAME = "変換後親品番";
        // 変換後子品番
        private const string AFCHGSUBGOODSNO_COLUMN_NAME = "変換後子品番";
        // 売上伝票番号
        //private const string SALESSLIPNO_COLUMN_NAME = "売上伝票番号"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string SALESSLIPNO_COLUMN_NAME = "売上伝票"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 売上行番号
        private const string ROWNO_COLUMN_NAME = "売上行番号";
        // 受注ステータス
        //private const string ACPTANORDRSTATUS_COLUMN_NAME = "受注ステータス";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string ACPTANORDRSTATUS_COLUMN_NAME = "受注ｽﾃｰﾀｽ";// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 旧商品番号
        //private const string OLDGOODSNO_COLUMN_NAME = "商品番号"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string OLDGOODSNO_COLUMN_NAME = "品番"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 新商品番号
        //private const string NEWGOODSNO_COLUMN_NAME = "変換後商品番号"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string NEWGOODSNO_COLUMN_NAME = "変換後品番"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 商品メーカーコード
        //private const string GOODSMAKERCD_COLUMN_NAME = "商品メーカーコード"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string GOODSMAKERCD_COLUMN_NAME = "ﾒｰｶｰ"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        // 部品メーカーコード
        //private const string PARTSMAKERCD_COLUMN_NAME = "ﾒｰｶｰ"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // 商品中分類コード
        private const string GOODSMGROUPCD_COLUMN_NAME = "中分類"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        // BLコード
        private const string BLCODE_COLUMN_NAME = "BLｺｰﾄﾞ";
        // 優良設定詳細コード1
        private const string PRMSETDTLNO1_COLUMN_NAME = "ｾﾚｸﾄ";
        // 旧品番-優良設定詳細コード2
        private const string OLDPRMSETDTLNO2_COLUMN_NAME = "旧品番種別";
        // 新品番-優良設定詳細コード2
        private const string NEWPRMSETDTLNO2_COLUMN_NAME = "新品番種別";
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
        // 処理ログメッセージ
        private const string GOODSCHG_SUC_NAME = "備考";
        //エラーメッセージ
        //private const string GOODSCHG_ERR_NAME = "エラー内容"; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        private const string GOODSCHG_ERR_NAME = "ｴﾗｰ内容"; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ内容の変更の対応
        #endregion
        //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応-----<<<<<
        #endregion

        #region ■ Public Method
        /// <summary>
        /// データ抽出処理
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : テキスト出力データを取得する。</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        //public int GoodsChange(GoodsChangeAllCndWorkWork cndtn, string path, out GoodsChangeResultWork goodsChangeResultWork) // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応
        public int GoodsChange(GoodsChangeAllCndWorkWork cndtn, string path, out GoodsChangeResultWork goodsChangeResultWork, out string newPath) // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応    
        {
            //return this.GoodsChangeProc(cndtn, path, out goodsChangeResultWork);// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応
            return this.GoodsChangeProc(cndtn, path, out goodsChangeResultWork, out newPath);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応
        }
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◎ データ取得
        /// <summary>
        /// データ取得
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : テキスト出力データを取得する。</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote  : 2015/03/02 時シン </br>
        /// <br>            : Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応</br>
        /// </remarks>
        //private int GoodsChangeProc(GoodsChangeAllCndWorkWork cndtn, string path, out GoodsChangeResultWork goodsChangeResultWork)// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応
        private int GoodsChangeProc(GoodsChangeAllCndWorkWork cndtn, string orignalPath, out GoodsChangeResultWork goodsChangeResultWork, out string path)// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            goodsChangeResultWork = new GoodsChangeResultWork();
            path = "";

            try
            {
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応----->>>>>
                path = Path.Combine(@orignalPath, DateTime.Now.ToString("yyyyMMddHHmmss"));
                Directory.CreateDirectory(path);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログ出力時にTrans_Logフォルダ配下に日付フォルダを作成する対応-----<<<<<
                #region 品番変換マスタ
                if (cndtn.GoodsChangeMstDiv == 1)
                {
                    status = ChgGoodsNoMst(ref goodsChangeResultWork, cndtn, path);
                }
                #endregion

                if (cndtn.GoodsChangeMstDiv == 1 && goodsChangeResultWork.ErrCntGoodsChgMst > 0)
                {
                    return status;
                }
                else
                {
                    #region 商品在庫マスタ
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.GoodsMstDiv == 1)
                    {
                        status = ChgGoodsStockPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region 管理情報マスタ
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.GoodsMngMstDiv == 1)
                    {
                        status = ChgGoodsMngPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region 掛率マスタ
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.RateMstDiv == 1)
                    {
                        status = ChgRatePrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region 結合マスタ
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.JoinMstDiv == 1)
                    {
                        status = ChgJoinPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region 代替マスタ
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.PartsMstDiv == 1)
                    {
                        status = ChgPartsPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region セットマスタ
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.SetMstDiv == 1)
                    {
                        status = ChgGoodsSetPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region 貸出変換処理
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.ShipmentDiv == 1)
                    {
                        status = ChgShipmentPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
                    #region 優良設定マスタ
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.PrmMstDiv == 1)
                    {
                        status = ChgPrmSettingPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion
                    //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
                }
            }
            catch (Exception ex)
            {
                string exMsg = ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region CSV出力処理
        #region CSV出力情報設定
        /// <summary>
        /// CSV出力情報処理
        /// </summary>
        /// <param name="mode">各マスタ区分</param>
        /// <param name="dsOutData">DataSet</param>
        /// <param name="fileName">ファイル名</param>
        /// <remarks>
        /// <br>Note       : バインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応</br>
        /// </remarks>
        public FormattedTextWriter GetCSVInfo(int mode, DataSet dsOutData, string fileName)
        {
            List<string> schemeList = new List<string>();
            // 品番変換マスタ成功
            if (mode == GOODSNOCHGSUCMODE)
            {
                schemeList.Add(OLDGOODSNO_COLUMN);
                schemeList.Add(NEWGOODSNO_COLUMN);
                schemeList.Add(GOODSMAKERCD_COLUMN);
            }
            // 品番変換マスタ失敗
            else if (mode == GOODSNOCHGERRMODE)
            {
                schemeList.Add(OLDGOODSNO_COLUMN);
                schemeList.Add(NEWGOODSNO_COLUMN);
                schemeList.Add(GOODSMAKERCD_COLUMN);
                schemeList.Add(GOODS_ERROR);
            }
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //// 商品マスタ
            //else if (mode == GOODSMSTMODE)
            //{
            //    schemeList.Add(ct_Col_GoodsMakerCd1);
            //    schemeList.Add(ct_Col_GoodsOldGoodsNo);
            //    schemeList.Add(ct_Col_GoodsNewGoodsNo);
            //    schemeList.Add(ct_Col_OutNote);
            //}
            //// 価格マスタ
            //else if (mode == PRICEMSTMODE)
            //{
            //    schemeList.Add(ct_Col_GoodsMakerCd1);
            //    schemeList.Add(ct_Col_GoodsOldGoodsNo);
            //    schemeList.Add(ct_Col_PriceStartDate);
            //    schemeList.Add(ct_Col_GoodsNewGoodsNo);
            //    schemeList.Add(ct_Col_OutNote);
            //}
            //// 在庫マスタ
            //else if (mode == STOCKMSTMODE)
            //{
            //    schemeList.Add(ct_Col_WareCode);
            //    schemeList.Add(ct_Col_GoodsMakerCd1);
            //    schemeList.Add(ct_Col_GoodsOldGoodsNo);
            //    schemeList.Add(ct_Col_GoodsNewGoodsNo);
            //    schemeList.Add(ct_Col_OutNote);
            //}
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            // 商品在庫マスタ
            else if (mode == GOODSMSTMODE)
            {
                schemeList.Add(ct_Col_MstDiv);
                schemeList.Add(ct_Col_GoodsMakerCd1);
                schemeList.Add(ct_Col_GoodsOldGoodsNo);
                schemeList.Add(ct_Col_GoodsNewGoodsNo);
                schemeList.Add(ct_Col_WareCode);
                schemeList.Add(ct_Col_PriceStartDate);
                schemeList.Add(ct_Col_OutNote);
            }
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            // 商品管理情報マスタ
            else if (mode == GOODSMNGMSTMODE)
            {
                schemeList.Add(ct_Col_SectionCode);
                schemeList.Add(ct_Col_GoodsMakerCd1);
                schemeList.Add(ct_Col_GoodsOldGoodsNo);
                schemeList.Add(ct_Col_GoodsNewGoodsNo);
                schemeList.Add(ct_Col_OutNote);
            }
            // 掛率マスタ
            else if (mode == RATEMSTMODE)
            {
                schemeList.Add(ct_Col_SectionCode);
                schemeList.Add(ct_Col_UnitRateSetDivCd);
                schemeList.Add(ct_Col_UnitPriceKind);
                schemeList.Add(ct_Col_GoodsMakerCd1);
                schemeList.Add(ct_Col_GoodsOldGoodsNo);
                schemeList.Add(ct_Col_CustomerCode);
                schemeList.Add(ct_Col_CustRateGrpCode);
                schemeList.Add(ct_Col_SupplierCd);
                schemeList.Add(ct_Col_LotCount);
                schemeList.Add(ct_Col_GoodsNewGoodsNo);
                schemeList.Add(ct_Col_OutNote);
            }
            // 結合マスタ
            else if (mode == JOINMSTMODE)
            {
                schemeList.Add(ct_Col_JoinSourceMakerCode);
                schemeList.Add(ct_Col_JoinSourPartsNoWithH);
                schemeList.Add(ct_Col_JoinDestMakerCd);
                schemeList.Add(ct_Col_JoinDestPartsNoRF);
                schemeList.Add(ct_Col_NewJoinSourPartsNoWithH);
                schemeList.Add(ct_Col_NewJoinDestPartsNoRF);
                schemeList.Add(ct_Col_OutNote);
            }
            // 代替マスタ
            else if (mode == PARTSMSTMODE)
            {
                schemeList.Add(CHGSRCMAKERCD_COLUMN);
                schemeList.Add(CHGSRCGOODSNO_COLUMN);
                schemeList.Add(CHGDESTMAKERCD_COLUMN);
                schemeList.Add(CHGDESTGOODSNO_COLUMN);
                schemeList.Add(CHGSRCCHGGOODSNO_COLUMN);
                schemeList.Add(CHGDESTCHGGOODSNO_COLUMN);
                schemeList.Add(OUTNOTE_COLUMN);
            }
            // セットマスタ
            else if (mode == GOODSSETMSTMODE)
            {
                schemeList.Add(PARENTGOODSMAKERCD_COLUMN);
                schemeList.Add(PARENTGOODSNO_COLUMN);
                schemeList.Add(SUBGOODSMAKERCD_COLUMN);
                schemeList.Add(SUBGOODSNO_COLUMN);
                schemeList.Add(AFCHGPARENTGOODSNO_COLUMN);
                schemeList.Add(AFCHGSUBGOODSNO_COLUMN);
                schemeList.Add(AFCONTENTEXPLAIN_COLUMN);
            }
            //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
            // 優良設定マスタ
            else if (mode == PRMSUCMODE)
            {
                schemeList.Add(SECTIONCODE_COLUMN);
                schemeList.Add(PARTSMAKERCD_COLUMN);
                schemeList.Add(GOODSMGROUPCD_COLUMN);
                schemeList.Add(BLCODE_COLUMN);
                schemeList.Add(PRMSETDTLNO1_COLUMN);
                schemeList.Add(OLDPRMSETDTLNO2_COLUMN);
                schemeList.Add(NEWPRMSETDTLNO2_COLUMN);
            }
            else if (mode == PRMUPDATEERRMODE)
            {
                schemeList.Add(SECTIONCODE_COLUMN);
                schemeList.Add(PARTSMAKERCD_COLUMN);
                schemeList.Add(GOODSMGROUPCD_COLUMN);
                schemeList.Add(BLCODE_COLUMN);
                schemeList.Add(PRMSETDTLNO1_COLUMN);
                schemeList.Add(OLDPRMSETDTLNO2_COLUMN);
                schemeList.Add(NEWPRMSETDTLNO2_COLUMN);
                schemeList.Add(OUTNOTE_COLUMN);
            }
            //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<
            // 貸出変換処理
            else if (mode == SHIPMENTERRMODE)
            {
                schemeList.Add(SALESSLIPNO_COLUMN);
                schemeList.Add(ROWNO_COLUMN);
                schemeList.Add(ACPTANORDRSTATUS_COLUMN);
                schemeList.Add(GOODSMAKERCD_COLUMN);
                schemeList.Add(OLDGOODSNO_COLUMN);
                schemeList.Add(NEWGOODSNO_COLUMN);
                schemeList.Add(ERROR_COLUMN);
            }
            else if (mode == SHIPMENTSUCMODE)
            {
                schemeList.Add(SALESSLIPNO_COLUMN);
                schemeList.Add(ROWNO_COLUMN);
                schemeList.Add(ACPTANORDRSTATUS_COLUMN);
                schemeList.Add(GOODSMAKERCD_COLUMN);
                schemeList.Add(OLDGOODSNO_COLUMN);
                schemeList.Add(NEWGOODSNO_COLUMN);
            }

            object dataSrc = null;
            string outFileName = "";
            dataSrc = dsOutData.Tables[0];
            outFileName = fileName;

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());

            FormattedTextWriter formattedTextWriter = new FormattedTextWriter();
            formattedTextWriter.DataSource = dataSrc;
            formattedTextWriter.DataMember = String.Empty;
            formattedTextWriter.OutputFileName = outFileName;
            //テキスト出力する項目名のリスト
            formattedTextWriter.SchemeList = schemeList;
            formattedTextWriter.Splitter = ",";
            formattedTextWriter.Encloser = "\"";
            formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            formattedTextWriter.FormatList = null;
            //formattedTextWriter.CaptionOutput = false; // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
            formattedTextWriter.CaptionOutput = true; // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
            formattedTextWriter.FixedLength = false;
            formattedTextWriter.ReplaceList = null;
            formattedTextWriter.OutputMode = false;

            return formattedTextWriter;
        }
        #endregion

        #region CSV出力処理
        /// <summary>
        /// CSV出力情報処理
        /// </summary>
        /// <param name="mstMode">各マスタ区分</param>
        /// <param name="logKindDiv">ログ種類0:成功　1:失敗</param>
        /// <param name="logDataTable">DataTable</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="goodsChangeResultWork">戻る結果ワーク</param>
        /// <remarks>
        /// <br>Note       : バインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int DoCSVOutPrc(int mstMode, int logKindDiv, DataTable logDataTable, string fileName, ref GoodsChangeResultWork goodsChangeResultWork)
        {
            int outCSVStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            DataView dv = logDataTable.DefaultView;
            DataSet dsOutData = new DataSet();
            dsOutData.Tables.Add(dv.ToTable());

            // CSV出力情報処理
            FormattedTextWriter printInfo = new FormattedTextWriter();
            printInfo = GetCSVInfo(mstMode, dsOutData, fileName);
            Object parameter = (object)printInfo;

            // CSV出力処理
            outCSVStatus = DoOutPut(parameter);

            // ステータスのセット
            if (outCSVStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL && logKindDiv == 1)
            {
                goodsChangeResultWork.ErrLogCSVOpen = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else if (outCSVStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL && logKindDiv == 0)
            {
                goodsChangeResultWork.LogCSVOpen = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else
            { 
                // なし
            }
            return outCSVStatus;
        }
        #endregion

        #region 品番変換マスタ
        // 旧商品番号
        private const string OLDGOODSNO_COLUMN = "OldGoodsNoRF";
        // 新商品番号
        private const string NEWGOODSNO_COLUMN = "NewGoodsNoRF";
        // 商品メーカーコード
        private const string GOODSMAKERCD_COLUMN = "GoodsMakerCdRF";
        //エラーメッセージ
        private const string GOODS_ERROR = "GoodsErrorRF";

        //----- DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応----->>>>>
        ////----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
        //// 旧商品番号
        //private const string OLDGOODSNO_COLUMN_NAME = "商品メーカーコード";
        //// 新商品番号
        //private const string NEWGOODSNO_COLUMN_NAME = "商品番号";
        //// 商品メーカーコード
        //private const string GOODSMAKERCD_COLUMN_NAME = "変換後商品番号";
        ////エラーメッセージ
        //private const string GOODS_ERROR_NAME = "備考";
        ////----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<
        //----- DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応-----<<<<<

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void TableGoodsChgMst(ref DataTable dataTable)
        {
            dataTable.Columns.Add(OLDGOODSNO_COLUMN, typeof(string));                   //  商品番号
            dataTable.Columns.Add(NEWGOODSNO_COLUMN, typeof(string));                   //  商品番号
            dataTable.Columns.Add(GOODSMAKERCD_COLUMN, typeof(string));                 //  商品メーカーコード
            dataTable.Columns.Add(GOODS_ERROR, typeof(string));                         //  エラーメッセージ

            //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            //dataTable.Columns[OLDGOODSNO_COLUMN].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[NEWGOODSNO_COLUMN].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            dataTable.Columns[GOODSMAKERCD_COLUMN].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            dataTable.Columns[OLDGOODSNO_COLUMN].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[NEWGOODSNO_COLUMN].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            //dataTable.Columns[GOODS_ERROR].Caption = GOODS_ERROR_NAME; // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
            dataTable.Columns[GOODS_ERROR].Caption = GOODSCHG_ERR_NAME; // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
            //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応</br>
        /// </remarks>
        private void ConverToDataSetGoodsChgMst(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (GoodsNoChangeWork goodsNoChange in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                //// 旧品番
                //dataRow[OLDGOODSNO_COLUMN] = goodsNoChange.OldGoodsNo.Trim().Replace("\"", "\"\"");
                //// 新品番
                //dataRow[NEWGOODSNO_COLUMN] = goodsNoChange.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                // 旧品番
                dataRow[OLDGOODSNO_COLUMN] = SubStringOfByte(SubStringOfByte(goodsNoChange.OldGoodsNo.Trim(), 20), 20);
                // 新品番
                dataRow[NEWGOODSNO_COLUMN] = SubStringOfByte(SubStringOfByte(goodsNoChange.NewGoodsNo.Trim(), 20), 20);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                // 商品メーカーコード
                int a = 0;
                if (int.TryParse(goodsNoChange.MakerCdCheck.Trim(),out a))
                {
                    //dataRow[GOODSMAKERCD_COLUMN] = a.ToString().PadLeft(4, '0');// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                    dataRow[GOODSMAKERCD_COLUMN] = SubStringOfByte(a.ToString().PadLeft(4, '0'), 4);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                }
                else
                {
                    //dataRow[GOODSMAKERCD_COLUMN] = goodsNoChange.MakerCdCheck.Trim();// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                    dataRow[GOODSMAKERCD_COLUMN] = SubStringOfByte(SubStringOfByte(goodsNoChange.MakerCdCheck.Trim(), 4), 4);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                }
                // エラーメッセージ
                dataRow[GOODS_ERROR] = goodsNoChange.ErroLogMessage;

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region 商品在庫マスタ
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
        /// <summary> ﾏｽﾀ種別 </summary>			
        private const string ct_Col_MstDiv = "MstDiv";
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
        /// <summary> 価格開始日 </summary>			
        private const string ct_Col_PriceStartDate = "PriceStartDate";
        /// <summary> 倉庫コード </summary>			
        private const string ct_Col_WareCode = "WareCode";

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <param name="mode">ログモード</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/02/26</br>
        /// </remarks>
        //private void TableGoodsStock(ref DataTable dataTable) // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        private void TableGoodsStock(ref DataTable dataTable, int mode) // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        {
            dataTable.Columns.Add(ct_Col_MstDiv, typeof(string));                          //  ﾏｽﾀ種別  // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
            dataTable.Columns.Add(ct_Col_GoodsMakerCd1, typeof(string));                   //  メーカーコード
            dataTable.Columns.Add(ct_Col_GoodsOldGoodsNo, typeof(string));                 //  旧品番
            dataTable.Columns.Add(ct_Col_GoodsNewGoodsNo, typeof(string));                 //  新品番
            dataTable.Columns.Add(ct_Col_PriceStartDate, typeof(string));                  //  価格開始日
            dataTable.Columns.Add(ct_Col_WareCode, typeof(string));                     　 //  倉庫コード
            dataTable.Columns.Add(ct_Col_OutNote, typeof(string));                         //  備考

            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応----->>>>>
            dataTable.Columns[ct_Col_MstDiv].Caption = MSTDIV_COLUMN_NAME; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
            dataTable.Columns[ct_Col_GoodsMakerCd1].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            //dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            dataTable.Columns[ct_Col_PriceStartDate].Caption = PRICESTRDATE_COLUMN_NAME;
            dataTable.Columns[ct_Col_WareCode].Caption = WARECODE_COLUMN_NAME;
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応-----<<<<<
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応</br>
        /// </remarks>
        //private void ConverToDataSetGoodsStock(ArrayList dataList, ref DataTable dataTable, int mode)// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
        private void ConverToDataSetGoodsStock(ArrayList dataList, ref DataTable dataTable)// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応    
        {
            string priceStrDate = ""; // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
            foreach (MeijiGoodsStockWork meijiGoodsStockWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                //dataRow[ct_Col_GoodsOldGoodsNo] = meijiGoodsStockWork.OldGoodsNo.Trim().Replace("\"", "\"\"");
                //dataRow[ct_Col_GoodsNewGoodsNo] = meijiGoodsStockWork.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                dataRow[ct_Col_GoodsOldGoodsNo] = SubStringOfByte(meijiGoodsStockWork.OldGoodsNo.Trim(), 20);
                dataRow[ct_Col_GoodsNewGoodsNo] = SubStringOfByte(meijiGoodsStockWork.NewGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                dataRow[ct_Col_GoodsMakerCd1] = meijiGoodsStockWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                dataRow[ct_Col_OutNote] = meijiGoodsStockWork.OutNote.Trim();
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                //// 価格マスタ
                //if (mode == 2)
                //{
                //    dataRow[ct_Col_PriceStartDate] = meijiGoodsStockWork.PriceStartDate.Year.ToString() + meijiGoodsStockWork.PriceStartDate.Month.ToString().PadLeft(2, '0') + meijiGoodsStockWork.PriceStartDate.Day.ToString().PadLeft(2, '0');
                //}
                //// 在庫マスタ
                //else if (mode == 3)
                //{
                //    //dataRow[ct_Col_WareCode] = meijiGoodsStockWork.WareCode.Trim();
                //}
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                priceStrDate = string.Empty;
                // 商品マスタ
                if (meijiGoodsStockWork.MstDiv == 0)
                {
                    dataRow[ct_Col_MstDiv] = "商品ﾏｽﾀ";
                }
                // 価格マスタ
                else if (meijiGoodsStockWork.MstDiv == 1)
                {
                    dataRow[ct_Col_MstDiv] = "価格ﾏｽﾀ";
                    priceStrDate = meijiGoodsStockWork.PriceStartDate.Year.ToString() + meijiGoodsStockWork.PriceStartDate.Month.ToString().PadLeft(2, '0') + meijiGoodsStockWork.PriceStartDate.Day.ToString().PadLeft(2, '0');
                }
                // 在庫マスタ
                else
                {
                    dataRow[ct_Col_MstDiv] = "在庫ﾏｽﾀ";
                }
                dataRow[ct_Col_PriceStartDate] = priceStrDate.PadRight(10, ' ');
                dataRow[ct_Col_WareCode] = meijiGoodsStockWork.WareCode.Trim().PadRight(4, ' ');
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region 商品情報管理マスタ
        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <param name="mode">ログのモード</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        //private void TableMng(ref DataTable dataTable) // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        private void TableMng(ref DataTable dataTable, int mode) // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        {
            dataTable.Columns.Add(ct_Col_GoodsMakerCd1, typeof(string));                   //  メーカーコード
            dataTable.Columns.Add(ct_Col_GoodsOldGoodsNo, typeof(string));                 //  旧品番
            dataTable.Columns.Add(ct_Col_GoodsNewGoodsNo, typeof(string));                 //  新品番
            dataTable.Columns.Add(ct_Col_SectionCode, typeof(string));                     //  拠点コード
            dataTable.Columns.Add(ct_Col_OutNote, typeof(string));                         //  備考

            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応----->>>>>
            dataTable.Columns[ct_Col_GoodsMakerCd1].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            //dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            dataTable.Columns[ct_Col_SectionCode].Caption = SECTIONCODE_COLUMN_NAME;
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応-----<<<<<
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応</br>
        /// </remarks>
        private void ConverToDataSetMng(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (MeiJiGoodsMngWork meiJiGoodsMngWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                //dataRow[ct_Col_GoodsOldGoodsNo] = meiJiGoodsMngWork.GoodsNo.Trim().Replace("\"", "\"\"");
                //dataRow[ct_Col_GoodsNewGoodsNo] = meiJiGoodsMngWork.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                dataRow[ct_Col_GoodsOldGoodsNo] = SubStringOfByte(meiJiGoodsMngWork.GoodsNo.Trim(), 20);
                dataRow[ct_Col_GoodsNewGoodsNo] = SubStringOfByte(meiJiGoodsMngWork.NewGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                dataRow[ct_Col_GoodsMakerCd1] = meiJiGoodsMngWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                //dataRow[ct_Col_SectionCode] = meiJiGoodsMngWork.SectionCode.Trim();// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[ct_Col_SectionCode] = SubStringOfByte(meiJiGoodsMngWork.SectionCode.Trim().PadLeft(2, '0'), 4);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[ct_Col_OutNote] = meiJiGoodsMngWork.OutNote.Trim();

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region 掛率マスタ
        /// <summary> ロット数 </summary>			
        private const string ct_Col_LotCount = "LotCount";
        /// <summary> メーカーコード </summary>			
        private const string ct_Col_GoodsMakerCd1 = "GoodsMakerCd";
        /// <summary> 旧品番 </summary>			
        private const string ct_Col_GoodsOldGoodsNo = "OldGoodsNo";
        /// <summary> 新品番 </summary>			
        private const string ct_Col_GoodsNewGoodsNo = "NewGoodsNo";
        /// <summary> 拠点コード </summary>			
        private const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 単価掛率設定区分 </summary>			
        private const string ct_Col_UnitRateSetDivCd = "UnitRateSetDivCd";
        /// <summary> 単価種類 </summary>			
        private const string ct_Col_UnitPriceKind = "UnitPriceKind";
        /// <summary> 得意先コード </summary>			
        private const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先掛率グループコード </summary>			
        private const string ct_Col_CustRateGrpCode = "CustRateGrpCode";
        /// <summary> 仕入先コード </summary>			
        private const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 備考 </summary>			
        private const string ct_Col_OutNote = "OutNote";

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <param name="mode">ログのモード</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        //private void TableRate(ref DataTable dataTable) // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        private void TableRate(ref DataTable dataTable, int mode) // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        {
            dataTable.Columns.Add(ct_Col_LotCount, typeof(string));                        //  ロット数
            dataTable.Columns.Add(ct_Col_GoodsMakerCd1, typeof(string));                   //  メーカーコード
            dataTable.Columns.Add(ct_Col_GoodsOldGoodsNo, typeof(string));                 //  旧品番
            dataTable.Columns.Add(ct_Col_GoodsNewGoodsNo, typeof(string));                 //  新品番
            dataTable.Columns.Add(ct_Col_SectionCode, typeof(string));                     //  拠点コード
            dataTable.Columns.Add(ct_Col_UnitRateSetDivCd, typeof(string));                //  単価掛率設定区分
            dataTable.Columns.Add(ct_Col_UnitPriceKind, typeof(string));                   //  単価種類
            dataTable.Columns.Add(ct_Col_CustomerCode, typeof(string));                    //  得意先コード
            dataTable.Columns.Add(ct_Col_CustRateGrpCode, typeof(string));                 //  得意先掛率グループコード
            dataTable.Columns.Add(ct_Col_SupplierCd, typeof(string));                      //  仕入先コード
            dataTable.Columns.Add(ct_Col_OutNote, typeof(string));                         //  備考

            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応----->>>>>
            dataTable.Columns[ct_Col_GoodsMakerCd1].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            //dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            dataTable.Columns[ct_Col_SectionCode].Caption = SECTIONCODE_COLUMN_NAME;
            //dataTable.Columns[ct_Col_LotCount].Caption = LOTCOUNT_COLUMN_NAME;// DEL 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[ct_Col_LotCount].Caption = SubStringOfByte(LOTCOUNT_COLUMN_NAME, 10);// ADD 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[ct_Col_UnitRateSetDivCd].Caption = UNITRATESETDIVCD_COLUMN_NAME;
            dataTable.Columns[ct_Col_UnitPriceKind].Caption = UNITPRICEKIND_COLUMN_NAME;
            //dataTable.Columns[ct_Col_CustomerCode].Caption = CUSTOMERCODE_COLUMN_NAME; // DEL 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[ct_Col_CustomerCode].Caption = SubStringOfByte(CUSTOMERCODE_COLUMN_NAME, 8); // ADD 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[ct_Col_CustRateGrpCode].Caption = CUSTRATEGRPCODE_COLUMN_NAME;
            dataTable.Columns[ct_Col_SupplierCd].Caption = SUPPLIERCD_COLUMN_NAME;
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応-----<<<<<
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応</br>
        /// </remarks>
        private void ConverToDataSetRate(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (MeijiRateWork meijiRateWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                //dataRow[ct_Col_GoodsOldGoodsNo] = meijiRateWork.GoodsNo.Trim().Replace("\"", "\"\"");
                //dataRow[ct_Col_GoodsNewGoodsNo] = meijiRateWork.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                dataRow[ct_Col_GoodsOldGoodsNo] = SubStringOfByte(meijiRateWork.GoodsNo.Trim(), 20);
                dataRow[ct_Col_GoodsNewGoodsNo] = SubStringOfByte(meijiRateWork.NewGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                dataRow[ct_Col_GoodsMakerCd1] = meijiRateWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                //dataRow[ct_Col_LotCount] = meijiRateWork.LotCount.ToString();
                //dataRow[ct_Col_SectionCode] = meijiRateWork.SectionCode.Trim();
                //dataRow[ct_Col_UnitRateSetDivCd] = meijiRateWork.UnitRateSetDivCd.Trim();
                //dataRow[ct_Col_UnitPriceKind] = meijiRateWork.UnitPriceKind.Trim();
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                dataRow[ct_Col_LotCount] = SubStringOfByte(meijiRateWork.LotCount.ToString(), 10);
                dataRow[ct_Col_SectionCode] = SubStringOfByte(meijiRateWork.SectionCode.Trim().PadLeft(2, '0'), 4);
                dataRow[ct_Col_UnitRateSetDivCd] = SubStringOfByte(meijiRateWork.UnitRateSetDivCd.Trim(), 12);
                dataRow[ct_Col_UnitPriceKind] = SubStringOfByte(meijiRateWork.UnitPriceKind.Trim(), 8);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                dataRow[ct_Col_CustomerCode] = meijiRateWork.CustomerCode.ToString().PadLeft(8, '0');
                //dataRow[ct_Col_CustRateGrpCode] = meijiRateWork.CustRateGrpCode.ToString().PadLeft(4, '0'); //DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[ct_Col_CustRateGrpCode] = SubStringOfByte(meijiRateWork.CustRateGrpCode.ToString().PadLeft(4, '0'), 10); //ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[ct_Col_SupplierCd] = meijiRateWork.SupplierCd.ToString().PadLeft(6, '0');
                dataRow[ct_Col_OutNote] = meijiRateWork.OutNote.Trim();

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region 結合マスタ
        /// <summary> 結合元メーカーコード </summary>			
        private const string ct_Col_JoinSourceMakerCode = "JoinSourceMakerCode";
        /// <summary> 結合元品番(－付き品番) </summary>			
        private const string ct_Col_JoinSourPartsNoWithH = "JoinSourPartsNoWithH";
        /// <summary> 結合先メーカーコード </summary>			
        private const string ct_Col_JoinDestMakerCd = "JoinDestMakerCd";
        /// <summary> 結合先品番(－付き品番) </summary>			
        private const string ct_Col_JoinDestPartsNoRF = "JoinDestPartsNoRF";
        /// <summary> New結合元品番(－付き品番) </summary>			
        private const string ct_Col_NewJoinSourPartsNoWithH = "NewJoinSourPartsNoWithH";
        /// <summary> New結合先品番(－付き品番) </summary>			
        private const string ct_Col_NewJoinDestPartsNoRF = "NewJoinDestPartsNoRF";

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <param name="mode">ログのモード</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        //private void TableJoin(ref DataTable dataTable) // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        private void TableJoin(ref DataTable dataTable, int mode) // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        {
            // 結合元メーカーコード 
            dataTable.Columns.Add(ct_Col_JoinSourceMakerCode, typeof(string));
            // 結合元品番(－付き品番)
            dataTable.Columns.Add(ct_Col_JoinSourPartsNoWithH, typeof(string));
            // 結合先メーカーコード
            dataTable.Columns.Add(ct_Col_JoinDestMakerCd, typeof(string));
            // 結合先品番(－付き品番)
            dataTable.Columns.Add(ct_Col_JoinDestPartsNoRF, typeof(string));
            // New結合元品番(－付き品番)
            dataTable.Columns.Add(ct_Col_NewJoinSourPartsNoWithH, typeof(string));
            // New結合先品番(－付き品番)
            dataTable.Columns.Add(ct_Col_NewJoinDestPartsNoRF, typeof(string));
            // 備考
            dataTable.Columns.Add(ct_Col_OutNote, typeof(string));

            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応----->>>>>
            dataTable.Columns[ct_Col_JoinSourceMakerCode].Caption = JOINSOURCEMAKERCODE_COLUMN_NAME;
            //dataTable.Columns[ct_Col_JoinSourPartsNoWithH].Caption = JOINSOURPARTSNOWITHH_COLUMN_NAME; // DEL 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[ct_Col_JoinSourPartsNoWithH].Caption = SubStringOfByte(JOINSOURPARTSNOWITHH_COLUMN_NAME, 20); // ADD 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[ct_Col_JoinDestMakerCd].Caption = JOINDESTMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            //dataTable.Columns[ct_Col_JoinDestPartsNoRF].Caption = JOINDESTPARTSNORF_COLUMN_NAME;
            //dataTable.Columns[ct_Col_NewJoinSourPartsNoWithH].Caption = NEWJOINSOURPARTSNOWITHH_COLUMN_NAME;
            //dataTable.Columns[ct_Col_NewJoinDestPartsNoRF].Caption = NEWJOINDESTPARTSNORF_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            dataTable.Columns[ct_Col_JoinDestPartsNoRF].Caption = SubStringOfByte(JOINDESTPARTSNORF_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_NewJoinSourPartsNoWithH].Caption = SubStringOfByte(NEWJOINSOURPARTSNOWITHH_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_NewJoinDestPartsNoRF].Caption = SubStringOfByte(NEWJOINDESTPARTSNORF_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応-----<<<<<
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応</br>
        /// </remarks>
        private void ConverToDataSetTableJoin(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (NewJoinPartsWork partsSubst in dataList)
                {
                    DataRow dataRow = dataTable.NewRow();

                    //  結合元メーカーコード
                    //dataRow[ct_Col_JoinSourceMakerCode] = partsSubst.JoinSourceMakerCode.ToString("d4");// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                    dataRow[ct_Col_JoinSourceMakerCode] = SubStringOfByte(partsSubst.JoinSourceMakerCode.ToString("d4"), 10);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                    //  結合元品番(－付き品番) 
                    //dataRow[ct_Col_JoinSourPartsNoWithH] = partsSubst.JoinSourPartsNoWithH.Trim().Replace("\"", "\"\""); ;// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                    dataRow[ct_Col_JoinSourPartsNoWithH] = SubStringOfByte(partsSubst.JoinSourPartsNoWithH.Trim(), 20); // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                    //  結合先メーカーコード
                    //dataRow[ct_Col_JoinDestMakerCd] = partsSubst.JoinDestMakerCd.ToString("d4");// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                    dataRow[ct_Col_JoinDestMakerCd] = SubStringOfByte(partsSubst.JoinDestMakerCd.ToString("d4"), 10);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                    ////  結合先品番(－付き品番)
                    //dataRow[ct_Col_JoinDestPartsNoRF] = partsSubst.JoinDestPartsNo.Trim().Replace("\"", "\"\""); ;
                    ////  New結合元品番(－付き品番)
                    //dataRow[ct_Col_NewJoinSourPartsNoWithH] = partsSubst.NewJoinSourPartsNoWithH.Trim().Replace("\"", "\"\""); ;
                    ////  New結合先品番(－付き品番)
                    //dataRow[ct_Col_NewJoinDestPartsNoRF] = partsSubst.NewJoinDestPartsNo.Trim().Replace("\"", "\"\""); ;
                    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                    //  結合先品番(－付き品番)
                    dataRow[ct_Col_JoinDestPartsNoRF] = SubStringOfByte(partsSubst.JoinDestPartsNo.Trim(), 20);
                    //  New結合元品番(－付き品番)
                    dataRow[ct_Col_NewJoinSourPartsNoWithH] = SubStringOfByte(partsSubst.NewJoinSourPartsNoWithH.Trim(), 20);
                    //  New結合先品番(－付き品番)
                    dataRow[ct_Col_NewJoinDestPartsNoRF] = SubStringOfByte(partsSubst.NewJoinDestPartsNo.Trim(), 20);
                    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                    //  備考
                    dataRow[ct_Col_OutNote] = partsSubst.OutNote;

                    dataTable.Rows.Add(dataRow);
                }
        }
        #endregion

        #region 代替マスタ
        // 代替元メーカーコード
        private const string CHGSRCMAKERCD_COLUMN = "chgSrcMakerCdRF";
        // 代替元商品番号
        private const string CHGSRCGOODSNO_COLUMN = "chgSrcGoodsNoRF";
        // 代替先メーカーコード
        private const string CHGDESTMAKERCD_COLUMN = "chgDestMakerCdRF";
        // 代替先商品番号
        private const string CHGDESTGOODSNO_COLUMN = "chgDestGoodsNoRF";
        // 変換後代替元商品番号
        private const string CHGSRCCHGGOODSNO_COLUMN = "chgSrcChgGoodsNoRF";
        // 変換後代替先商品番号
        private const string CHGDESTCHGGOODSNO_COLUMN = "chgDestChgGoodsNoRF";
        // 備考
        private const string OUTNOTE_COLUMN = "outNoteRF";

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <param name="mode">ログのモード</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        //private void TableGoodsPartsChgMst(ref DataTable dataTable) // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        private void TableGoodsPartsChgMst(ref DataTable dataTable, int mode) // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        {
            dataTable.Columns.Add(CHGSRCMAKERCD_COLUMN, typeof(string));                    //  代替元メーカーコード
            dataTable.Columns.Add(CHGSRCGOODSNO_COLUMN, typeof(string));                    //  代替元商品番号
            dataTable.Columns.Add(CHGDESTMAKERCD_COLUMN, typeof(string));                   //  代替先メーカーコード
            dataTable.Columns.Add(CHGDESTGOODSNO_COLUMN, typeof(string));                   //  代替先商品番号
            dataTable.Columns.Add(CHGSRCCHGGOODSNO_COLUMN, typeof(string));                 //  変換後代替元商品番号
            dataTable.Columns.Add(CHGDESTCHGGOODSNO_COLUMN, typeof(string));                //  変換後代替先商品番号
            dataTable.Columns.Add(OUTNOTE_COLUMN, typeof(string));                          //  備考

            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応----->>>>>
            dataTable.Columns[CHGSRCMAKERCD_COLUMN].Caption = CHGSRCMAKERCD_COLUMN_NAME;
            //dataTable.Columns[CHGSRCGOODSNO_COLUMN].Caption = CHGSRCGOODSNO_COLUMN_NAME;// DEL 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[CHGSRCGOODSNO_COLUMN].Caption = SubStringOfByte(CHGSRCGOODSNO_COLUMN_NAME, 20);// ADD 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[CHGDESTMAKERCD_COLUMN].Caption = CHGDESTMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            //dataTable.Columns[CHGDESTGOODSNO_COLUMN].Caption = CHGDESTGOODSNO_COLUMN_NAME;
            //dataTable.Columns[CHGSRCCHGGOODSNO_COLUMN].Caption = CHGSRCCHGGOODSNO_COLUMN_NAME;
            //dataTable.Columns[CHGDESTCHGGOODSNO_COLUMN].Caption = CHGDESTCHGGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            dataTable.Columns[CHGDESTGOODSNO_COLUMN].Caption = SubStringOfByte(CHGDESTGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[CHGSRCCHGGOODSNO_COLUMN].Caption = SubStringOfByte(CHGSRCCHGGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[CHGDESTCHGGOODSNO_COLUMN].Caption = SubStringOfByte(CHGDESTCHGGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[OUTNOTE_COLUMN].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[OUTNOTE_COLUMN].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応-----<<<<<
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応</br>
        /// </remarks>
        private void ConverToDataSetGoodsPartsChgMst(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (MeijiPartsSubstWork meijiPartsSubstWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                // 代替元メーカーコード
                //dataRow[CHGSRCMAKERCD_COLUMN] = meijiPartsSubstWork.ChgSrcMakerCd.ToString().PadLeft(4, '0'); // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[CHGSRCMAKERCD_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgSrcMakerCd.ToString().PadLeft(4, '0'), 10); // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                // 代替元商品番号
                //dataRow[CHGSRCGOODSNO_COLUMN] = meijiPartsSubstWork.ChgSrcGoodsNo.Trim().Replace("\"", "\"\"");// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[CHGSRCGOODSNO_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgSrcGoodsNo.Trim(), 20);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                // 代替先メーカーコード
                //dataRow[CHGDESTMAKERCD_COLUMN] = meijiPartsSubstWork.ChgDestMakerCd.ToString().PadLeft(4, '0');// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[CHGDESTMAKERCD_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgDestMakerCd.ToString().PadLeft(4, '0'), 10);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                //// 代替先商品番号
                //dataRow[CHGDESTGOODSNO_COLUMN] = meijiPartsSubstWork.ChgDestGoodsNo.Trim().Replace("\"", "\"\"");
                //// 変換後代替元商品番号
                //dataRow[CHGSRCCHGGOODSNO_COLUMN] = meijiPartsSubstWork.ChgSrcChgGoodsNo.Trim().Replace("\"", "\"\"");
                //// 変換後代替先商品番号
                //dataRow[CHGDESTCHGGOODSNO_COLUMN] = meijiPartsSubstWork.ChgDestChgGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                // 代替先商品番号
                dataRow[CHGDESTGOODSNO_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgDestGoodsNo.Trim(), 20);
                // 変換後代替元商品番号
                dataRow[CHGSRCCHGGOODSNO_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgSrcChgGoodsNo.Trim(), 20);
                // 変換後代替先商品番号
                dataRow[CHGDESTCHGGOODSNO_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgDestChgGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                // 備考
                dataRow[OUTNOTE_COLUMN] = meijiPartsSubstWork.OutNote.Trim();

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region セットマスタ
        // 親メーカーコード
        private const string PARENTGOODSMAKERCD_COLUMN = "ParentGoodsMakerCdRF";
        // 親商品番号
        private const string PARENTGOODSNO_COLUMN = "ParentGoodsNoRF";
        // 子商品メーカーコード
        private const string SUBGOODSMAKERCD_COLUMN = "SubGoodsMakerCdRF";
        // 子商品番号
        private const string SUBGOODSNO_COLUMN = "SubGoodsNoRF";
        // 変換後親商品番号
        private const string AFCHGPARENTGOODSNO_COLUMN = "AfChgParentGoodsNoRF";
        // 変換後子商品番号
        private const string AFCHGSUBGOODSNO_COLUMN = "AfChgSubGoodsNoRF";
        // 備考
        private const string AFCONTENTEXPLAIN_COLUMN = "AfContentExplainRF";

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <param name="mode">ログのモード</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        //private void TableGoodsSetChgMst(ref DataTable dataTable) // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        private void TableGoodsSetChgMst(ref DataTable dataTable, int mode) // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        {
            dataTable.Columns.Add(PARENTGOODSMAKERCD_COLUMN, typeof(string));                       //  親メーカーコード
            dataTable.Columns.Add(PARENTGOODSNO_COLUMN, typeof(string));                            //  親商品番号
            dataTable.Columns.Add(SUBGOODSMAKERCD_COLUMN, typeof(string));                          //  子商品メーカーコード
            dataTable.Columns.Add(SUBGOODSNO_COLUMN, typeof(string));                               //  子商品番号
            dataTable.Columns.Add(AFCHGPARENTGOODSNO_COLUMN, typeof(string));                       //  変換後親商品番号
            dataTable.Columns.Add(AFCHGSUBGOODSNO_COLUMN, typeof(string));                          //  変換後子商品番号
            dataTable.Columns.Add(AFCONTENTEXPLAIN_COLUMN, typeof(string));                         //  備考

            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応----->>>>>
            dataTable.Columns[PARENTGOODSMAKERCD_COLUMN].Caption = PARENTGOODSMAKERCD_COLUMN_NAME;
            //dataTable.Columns[PARENTGOODSNO_COLUMN].Caption = PARENTGOODSNO_COLUMN_NAME;// DEL 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[PARENTGOODSNO_COLUMN].Caption = SubStringOfByte(PARENTGOODSNO_COLUMN_NAME, 20);// ADD 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[SUBGOODSMAKERCD_COLUMN].Caption = SUBGOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            //dataTable.Columns[SUBGOODSNO_COLUMN].Caption = SUBGOODSNO_COLUMN_NAME;
            //dataTable.Columns[AFCHGPARENTGOODSNO_COLUMN].Caption = AFCHGPARENTGOODSNO_COLUMN_NAME;
            //dataTable.Columns[AFCHGSUBGOODSNO_COLUMN].Caption = AFCHGSUBGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            dataTable.Columns[SUBGOODSNO_COLUMN].Caption = SubStringOfByte(SUBGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[AFCHGPARENTGOODSNO_COLUMN].Caption = SubStringOfByte(AFCHGPARENTGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[AFCHGSUBGOODSNO_COLUMN].Caption = SubStringOfByte(AFCHGSUBGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[AFCONTENTEXPLAIN_COLUMN].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[AFCONTENTEXPLAIN_COLUMN].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応-----<<<<<
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応</br>
        /// </remarks>
        private void ConverToDataSetGoodsSetChgMst(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (GoodsSetChgWork goodsSetChgWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                // 親メーカーコード
                //dataRow[PARENTGOODSMAKERCD_COLUMN] = goodsSetChgWork.ParentGoodsMakerCd.ToString().PadLeft(4, '0'); // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[PARENTGOODSMAKERCD_COLUMN] = SubStringOfByte(goodsSetChgWork.ParentGoodsMakerCd.ToString().PadLeft(4, '0'), 6); // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                // 親商品番号
                //dataRow[PARENTGOODSNO_COLUMN] = goodsSetChgWork.ParentGoodsNo.Trim().Replace("\"", "\"\"");// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[PARENTGOODSNO_COLUMN] = SubStringOfByte(goodsSetChgWork.ParentGoodsNo.Trim(), 20);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                // 子商品メーカーコード
                //dataRow[SUBGOODSMAKERCD_COLUMN] = goodsSetChgWork.SubGoodsMakerCd.ToString().PadLeft(4, '0'); // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[SUBGOODSMAKERCD_COLUMN] = SubStringOfByte(goodsSetChgWork.SubGoodsMakerCd.ToString().PadLeft(4, '0'), 6); // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                //// 子商品番号
                //dataRow[SUBGOODSNO_COLUMN] = goodsSetChgWork.SubGoodsNo.Trim().Replace("\"", "\"\"");
                //// 変換後親商品番号
                //dataRow[AFCHGPARENTGOODSNO_COLUMN] = goodsSetChgWork.AfChgParentGoodsNo.Trim().Replace("\"", "\"\"");
                //// 変換後子商品番号
                //dataRow[AFCHGSUBGOODSNO_COLUMN] = goodsSetChgWork.AfChgSubGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                // 子商品番号
                dataRow[SUBGOODSNO_COLUMN] = SubStringOfByte(goodsSetChgWork.SubGoodsNo.Trim(), 20);
                // 変換後親商品番号
                dataRow[AFCHGPARENTGOODSNO_COLUMN] = SubStringOfByte(goodsSetChgWork.AfChgParentGoodsNo.Trim(), 20);
                // 変換後子商品番号
                dataRow[AFCHGSUBGOODSNO_COLUMN] = SubStringOfByte(goodsSetChgWork.AfChgSubGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                // 備考
                dataRow[AFCONTENTEXPLAIN_COLUMN] = goodsSetChgWork.AfContentExplain.Trim();

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        #region 優良設定マスタ
        // 拠点コード
        private const string SECTIONCODE_COLUMN = "SectionCodeRF";
        // 部品メーカーコード
        private const string PARTSMAKERCD_COLUMN = "PartsMakerCdRF";
        // 商品中分類コード
        private const string GOODSMGROUPCD_COLUMN = "GoodsMGroupRF";
        // BLコード
        private const string BLCODE_COLUMN = "TbsPartsCodeRF";
        // 優良設定詳細コード1
        private const string PRMSETDTLNO1_COLUMN = "PrmSetDtlName1RF";
        // 旧品番-優良設定詳細コード2
        private const string OLDPRMSETDTLNO2_COLUMN = "PrmSetDtlNoAfterOldRF";
        // 新品番-優良設定詳細コード2
        private const string NEWPRMSETDTLNO2_COLUMN = "PrmSetDtlNoAfterNewRF";

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <param name="mode">ログのモード</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private void CreatTablePrmSetting(ref DataTable dataTable, int mode)
        {
            dataTable.Columns.Add(SECTIONCODE_COLUMN, typeof(string));                     //  拠点コード
            dataTable.Columns.Add(PARTSMAKERCD_COLUMN, typeof(string));                    //  部品メーカーコード
            dataTable.Columns.Add(GOODSMGROUPCD_COLUMN, typeof(string));                   //  商品中分類コード
            dataTable.Columns.Add(BLCODE_COLUMN, typeof(string));                          //  BLコード
            dataTable.Columns.Add(PRMSETDTLNO1_COLUMN, typeof(string));                    //  優良設定詳細コード1
            dataTable.Columns.Add(OLDPRMSETDTLNO2_COLUMN, typeof(string));                 //  旧品番-優良設定詳細コード2
            dataTable.Columns.Add(NEWPRMSETDTLNO2_COLUMN, typeof(string));                 //  新品番-優良設定詳細コード2
            dataTable.Columns.Add(OUTNOTE_COLUMN, typeof(string));                         //  エラー内容

            dataTable.Columns[SECTIONCODE_COLUMN].Caption = SECTIONCODE_COLUMN_NAME;
            dataTable.Columns[PARTSMAKERCD_COLUMN].Caption = GOODSMAKERCD_COLUMN_NAME;
            dataTable.Columns[GOODSMGROUPCD_COLUMN].Caption = GOODSMGROUPCD_COLUMN_NAME;
            dataTable.Columns[BLCODE_COLUMN].Caption = BLCODE_COLUMN_NAME;
            dataTable.Columns[PRMSETDTLNO1_COLUMN].Caption = PRMSETDTLNO1_COLUMN_NAME;
            dataTable.Columns[OLDPRMSETDTLNO2_COLUMN].Caption = OLDPRMSETDTLNO2_COLUMN_NAME;
            dataTable.Columns[NEWPRMSETDTLNO2_COLUMN].Caption = NEWPRMSETDTLNO2_COLUMN_NAME;
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[OUTNOTE_COLUMN].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[OUTNOTE_COLUMN].Caption = GOODSCHG_ERR_NAME;
            }
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <param name="flg">フラフ</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private void ConverToDataSetPrm(ArrayList dataList, ref DataTable dataTable, bool flg)
        {
            foreach (NewPrmSettingUWork newPrmSettingUWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                if (flg)
                {
                    // 拠点コード
                    dataRow[SECTIONCODE_COLUMN] = newPrmSettingUWork.SectionCode.Trim().PadRight(4, ' ');
                    // 部品メーカーコード
                    dataRow[PARTSMAKERCD_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.PartsMakerCd.ToString(), 4), 4);
                    // 商品中分類コード
                    dataRow[GOODSMGROUPCD_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.GoodsMGroup.ToString(), 6), 6);
                    // BLコード
                    dataRow[BLCODE_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.TbsPartsCode.ToString(), 6), 6);
                    // 優良設定詳細コード1
                    dataRow[PRMSETDTLNO1_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.PrmSetDtlNo1.Trim(), 4), 4);
                    // 旧品番-優良設定詳細コード2
                    dataRow[OLDPRMSETDTLNO2_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.PrmSetDtlNoAfterOld.ToString(), 10), 10);
                    // 新品番-優良設定詳細コード2
                    dataRow[NEWPRMSETDTLNO2_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.PrmSetDtlNoAfterNew.ToString(), 10), 10);
                    // エラー内容
                    dataRow[OUTNOTE_COLUMN] = newPrmSettingUWork.OutNote;
                }
                else
                {
                    // 拠点コード
                    dataRow[SECTIONCODE_COLUMN] = SubStringOfByte(newPrmSettingUWork.SectionCode.Trim().PadLeft(2, '0'), 4);
                    // 部品メーカーコード
                    dataRow[PARTSMAKERCD_COLUMN] = newPrmSettingUWork.PartsMakerCd.ToString().PadLeft(4, '0');
                    // 商品中分類コード
                    dataRow[GOODSMGROUPCD_COLUMN] = SubStringOfByte(newPrmSettingUWork.GoodsMGroup.ToString().PadLeft(4, '0'), 6);
                    // BLコード
                    dataRow[BLCODE_COLUMN] = SubStringOfByte(newPrmSettingUWork.TbsPartsCode.ToString().PadLeft(4, '0'), 6);
                    // 優良設定詳細コード1
                    dataRow[PRMSETDTLNO1_COLUMN] = newPrmSettingUWork.PrmSetDtlNo1.ToString().PadLeft(4, '0');
                    // 旧品番-優良設定詳細コード2
                    dataRow[OLDPRMSETDTLNO2_COLUMN] = SubStringOfByte(newPrmSettingUWork.PrmSetDtlNoAfterOld.ToString().PadLeft(4, '0'), 10);
                    // 新品番-優良設定詳細コード2
                    dataRow[NEWPRMSETDTLNO2_COLUMN] = SubStringOfByte(newPrmSettingUWork.PrmSetDtlNoAfterNew.ToString().PadLeft(4, '0'), 10);
                    // エラー内容
                    dataRow[OUTNOTE_COLUMN] = newPrmSettingUWork.OutNote;
                }

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

        #region 貸出変換処理
        // 売上伝票番号
        private const string SALESSLIPNO_COLUMN = "SalesSlipNoRF";
        // 売上行番号
        private const string ROWNO_COLUMN = "RowNoRF";
        // 受注ステータス
        private const string ACPTANORDRSTATUS_COLUMN = "AcptAnOrdrStatusRF";
        // エラー内容
        private const string ERROR_COLUMN = "ErrorRF";

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <param name="mode">ログのモード</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        //private void CreatTableShipment(ref DataTable dataTable) // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        private void CreatTableShipment(ref DataTable dataTable, int mode) // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
        {
            dataTable.Columns.Add(SALESSLIPNO_COLUMN, typeof(string));                   //  売上伝票番号
            dataTable.Columns.Add(ROWNO_COLUMN, typeof(string));                         //  売上行番号
            dataTable.Columns.Add(ACPTANORDRSTATUS_COLUMN, typeof(string));              //  受注ステータス
            dataTable.Columns.Add(GOODSMAKERCD_COLUMN, typeof(string));                  //  商品メーカーコード
            dataTable.Columns.Add(OLDGOODSNO_COLUMN, typeof(string));                    //  変換前商品番号
            dataTable.Columns.Add(NEWGOODSNO_COLUMN, typeof(string));                    //  変換後商品番号
            dataTable.Columns.Add(ERROR_COLUMN, typeof(string));                         //  エラー内容

            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応----->>>>>
            //dataTable.Columns[SALESSLIPNO_COLUMN].Caption = SALESSLIPNO_COLUMN_NAME;// DEL 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[SALESSLIPNO_COLUMN].Caption = SubStringOfByte(SALESSLIPNO_COLUMN_NAME, 9);// ADD 2015/03/02 時シン Redmine#44209 ログの項目名の対応
            dataTable.Columns[ROWNO_COLUMN].Caption = ROWNO_COLUMN_NAME;
            dataTable.Columns[ACPTANORDRSTATUS_COLUMN].Caption = ACPTANORDRSTATUS_COLUMN_NAME;
            dataTable.Columns[GOODSMAKERCD_COLUMN].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            //dataTable.Columns[OLDGOODSNO_COLUMN].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[NEWGOODSNO_COLUMN].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------>>>>>
            dataTable.Columns[OLDGOODSNO_COLUMN].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[NEWGOODSNO_COLUMN].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログの項目名の対応------<<<<<
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ERROR_COLUMN].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ERROR_COLUMN].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応-----<<<<<
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="dataList">商品管理データリスト</param>
        /// <param name="dataTable">テープル結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 時シン </br>
        /// <br>           : Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応</br>
        /// </remarks>
        private void ConverToDataSetShipment(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (ShipmentChangeWork shipmentChangeWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                // 売上伝票番号
                dataRow[SALESSLIPNO_COLUMN] = shipmentChangeWork.SalesSlipNum.PadLeft(9, '0');
                // 売上行番号
                //dataRow[ROWNO_COLUMN] = shipmentChangeWork.SalesRowNo; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[ROWNO_COLUMN] = SubStringOfByte(shipmentChangeWork.SalesRowNo.ToString(), 10); // ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                // 受注ステータス
                //dataRow[ACPTANORDRSTATUS_COLUMN] = shipmentChangeWork.AcptAnOdrStatus;// DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                dataRow[ACPTANORDRSTATUS_COLUMN] = SubStringOfByte(shipmentChangeWork.AcptAnOdrStatus.ToString().Trim(), 9);// ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応
                // 商品メーカーコード
                dataRow[GOODSMAKERCD_COLUMN] = shipmentChangeWork.MakerCode.ToString().PadLeft(4, '0');
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                //// 変換前商品番号
                //dataRow[OLDGOODSNO_COLUMN] = shipmentChangeWork.OldGoodsNo.Trim().Replace("\"", "\"\"");
                //// 変換後商品番号
                //dataRow[NEWGOODSNO_COLUMN] = shipmentChangeWork.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
                // 変換前商品番号
                dataRow[OLDGOODSNO_COLUMN] = SubStringOfByte(shipmentChangeWork.OldGoodsNo.Trim(), 20);
                // 変換後商品番号
                dataRow[NEWGOODSNO_COLUMN] = SubStringOfByte(shipmentChangeWork.NewGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<
                // エラー内容
                dataRow[ERROR_COLUMN] = shipmentChangeWork.Message;

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region CSV出力
        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="parameter">出力Info</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV出力処理を行う。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int DoOutPut(object parameter)
        {
            int status = 0;
            FormattedTextWriter formattedTextWriter = parameter as FormattedTextWriter;

            try
            {
                int totalCount;
                status = formattedTextWriter.TextOut(out totalCount);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    return status;
                }
            }
            catch
            {
                status = -1;
            }
            return status;
        }
        #endregion

        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応----->>>>>
        #region バイト数指定切り抜き
        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        /// <remarks>
        /// <br>Note       : 文字列　バイト数指定切り抜き。</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/03/02</br>
        /// </remarks>
        private string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

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
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount) break;
            }
            // 終端の空白は削除
            return resultString;
        }
        #endregion
        //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」ログのフォーマットを「固定長、カンマ区切り」に変更する対応-----<<<<<

        #endregion

        #region 各マスタ品番変換処理

        #region 品番変換マスタ
        /// <summary>
        /// 品番変換マスタ品番変換処理
        /// </summary>
        /// <param name="goodsChangeResultWork">結果ワーク</param>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="path">パース</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 品番変換処理処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 田建委 </br>
        /// <br>           : Redmine#44209 ファイル名等の対応</br>
        /// </remarks>
        private int ChgGoodsNoMst(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            // カウント
            int readCntGoodsChgMst = 0;
            int loadCntGoodsChgMst = 0;
            int errCntGoodsChgMst = 0;
            // ファイルの書きステータス
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int mstStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // エラーメッセージ
            string errMsg = string.Empty;
            // ログ出力用
            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();
            // 出力ファイルパース
            //----- DEL 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "Cross_Index_Goodschg_error.csv");
            //string successLogFileName = Path.Combine(@path, "Cross_Index_Goodschg_Log.csv");
            //----- DEL 2015/02/25 田建委 Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_CROSS_INDEX_GOODSCHG_ERROR);
            string successLogFileName = Path.Combine(@path, ct_CROSS_INDEX_GOODSCHG_LOG);
            //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<

            object addUpdWorkObj = null;
            object dataObjectList = null;

            status = this._iMeijiGoodsChgAllDB.GoodsChangeMst(cndtn, out addUpdWorkObj, out dataObjectList, out readCntGoodsChgMst, out loadCntGoodsChgMst, out errCntGoodsChgMst, out errMsg);
            //エラーファイル
            errDataList = dataObjectList as ArrayList;
            if (errDataList != null && errDataList.Count > 0)
            {
                TableGoodsChgMst(ref errDataTable);
                ConverToDataSetGoodsChgMst(errDataList, ref errDataTable);
            }
            if (errDataTable.Rows.Count > 0)
            {
                mstStatusErrCSV = this.DoCSVOutPrc(GOODSNOCHGERRMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
            }
            //ログファイル
            sucDataList = addUpdWorkObj as ArrayList;
            if (sucDataList != null && sucDataList.Count > 0)
            {
                TableGoodsChgMst(ref sucDataTable);
                ConverToDataSetGoodsChgMst(sucDataList, ref sucDataTable);
            }
            if (sucDataTable.Rows.Count > 0)
            {
                statusSucCSV = this.DoCSVOutPrc(GOODSNOCHGSUCMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
            }
            goodsChangeResultWork.ReadCntGoodsChgMst = readCntGoodsChgMst;
            goodsChangeResultWork.LoadCntGoodsChgMst = loadCntGoodsChgMst;
            goodsChangeResultWork.ErrCntGoodsChgMst = errCntGoodsChgMst;
            goodsChangeResultWork.ErrMsg = errMsg;
            goodsChangeResultWork.MstStatusErrCSV = mstStatusErrCSV;
                
            return status;
        }
        #endregion

        #region 商品在庫マスタ
        /// <summary>
        /// 商品在庫マスタ品番変換処理
        /// </summary>
        /// <param name="goodsChangeResultWork">結果ワーク</param>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="path">パース</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 品番変換処理処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 田建委 </br>
        /// <br>           : Redmine#44209 ファイル名等の対応</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        private int ChgGoodsStockPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntGoodsAll = 0;
            int loadCntGoodsAll = 0;
            int errCntGoodsAll = 0;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //int errorCntGoods = 0;
            //int errorCntPrice = 0;
            //int errorCntStock = 0;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            #region 戻るパラメータ
            object goodsUpdateSucObj;
            object goodsUpdateErrObj;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //object priceUpdateSucObj;
            //object priceUpdateErrObj;
            //object stockUpdateSucObj;
            //object stockUpdateErrObj;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            int readCntGoods = 0;
            //int loadCntGoods = 0; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
            int readCntPrice = 0;
            //int loadCntPrice = 0; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
            int readCntStock = 0;
            //int loadCntStock = 0; // DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応
            #endregion
            #region ＣＳＶ出力関係
            DataTable goodsDataTableSuc = new DataTable();
            DataTable goodsDataTableErr = new DataTable();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //DataTable priceDataTableSuc = new DataTable();
            //DataTable priceDataTableErr = new DataTable();
            //DataTable stockDataTableSuc = new DataTable();
            //DataTable stockDataTableErr = new DataTable();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            ArrayList goodsSucDataList = new ArrayList();
            ArrayList goodsErrDataList = new ArrayList();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //ArrayList priceSucDataList = new ArrayList();
            //ArrayList priceErrDataList = new ArrayList();
            //ArrayList stockSucDataList = new ArrayList();
            //ArrayList stockErrDataList = new ArrayList();
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            int goodsStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int goodsStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //int priceStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //int priceStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //int stockStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //int stockStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //string goodsErrorLogFileName = Path.Combine(@path, "Goods_error.csv");
            //string goodsSuccessLogFileName = Path.Combine(@path, "Goods_Log.csv");
            //string priceErrorLogFileName = Path.Combine(@path, "GoodsPrice_error.csv");
            //string priceSuccessLogFileName = Path.Combine(@path, "GoodsPrice_Log.csv");
            //string stockErrorLogFileName = Path.Combine(@path, "Stock_error.csv");
            //string stockSuccessLogFileName = Path.Combine(@path, "Stock_Log.csv");
            //----- DEL 2015/02/25 田建委 Redmine#44209 -----<<<<<
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //string goodsErrorLogFileName = Path.Combine(@path, ct_GOODS_ERROR);
            //string goodsSuccessLogFileName = Path.Combine(@path, ct_GOODS_LOG);
            //string priceErrorLogFileName = Path.Combine(@path, ct_GOODSPRICE_ERROR);
            //string priceSuccessLogFileName = Path.Combine(@path, ct_GOODSPRICE_LOG);
            //string stockErrorLogFileName = Path.Combine(@path, ct_STOCK_ERROR);
            //string stockSuccessLogFileName = Path.Combine(@path, ct_STOCK_LOG);
            //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            string goodsErrorLogFileName = Path.Combine(@path, ct_GOODSSTOCK_ERROR);
            string goodsSuccessLogFileName = Path.Combine(@path, ct_GOODSSTOCK_LOG);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            #endregion

            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //status = this._iMeijiGoodsChgAllDB.GoodsChangeGoodsStock(cndtn, out goodsUpdateSucObj, out goodsUpdateErrObj, out priceUpdateSucObj, out priceUpdateErrObj,
            //    out stockUpdateSucObj, out stockUpdateErrObj, out readCntGoods, out readCntPrice, out readCntStock);
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            status = this._iMeijiGoodsChgAllDB.GoodsChangeGoodsStock(cndtn, out goodsUpdateSucObj, out goodsUpdateErrObj, out readCntGoods, out readCntPrice, out readCntStock);
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                #region DELETE
                //// コンパレータ
                //PricePrcCompare pricePrcCompare = new PricePrcCompare();
                //StockPrcCompare stockPrcCompare = new StockPrcCompare();

                //// ログ
                //#region 商品マスタ
                //goodsSucDataList = goodsUpdateSucObj as ArrayList;
                //if (goodsSucDataList != null && goodsSucDataList.Count > 0)
                //{
                //    loadCntGoods = goodsSucDataList.Count;
                //    //TableGoodsStock(ref goodsDataTableSuc); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    TableGoodsStock(ref goodsDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    ConverToDataSetGoodsStock(goodsSucDataList, ref goodsDataTableSuc, 1);
                //}
                //if (goodsDataTableSuc.Rows.Count > 0)
                //{
                //    goodsStatusSucCSV = this.DoCSVOutPrc(GOODSMSTMODE, LOGKINGSUC, goodsDataTableSuc, goodsSuccessLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion
                //#region 価格マスタ
                //priceSucDataList = priceUpdateSucObj as ArrayList;
                //priceSucDataList.Sort(pricePrcCompare);
                //if (priceSucDataList != null && priceSucDataList.Count > 0)
                //{
                //    loadCntPrice = priceSucDataList.Count;
                //    //TableGoodsStock(ref priceDataTableSuc); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    TableGoodsStock(ref priceDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    ConverToDataSetGoodsStock(priceSucDataList, ref priceDataTableSuc, 2);
                //}
                //if (priceDataTableSuc.Rows.Count > 0)
                //{
                //    priceStatusSucCSV = this.DoCSVOutPrc(PRICEMSTMODE, LOGKINGSUC, priceDataTableSuc, priceSuccessLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion
                //#region 在庫マスタ
                //stockSucDataList = stockUpdateSucObj as ArrayList;
                //stockSucDataList.Sort(stockPrcCompare);
                //if (stockSucDataList != null && stockSucDataList.Count > 0)
                //{
                //    loadCntStock = stockSucDataList.Count;
                //    //TableGoodsStock(ref stockDataTableSuc); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    TableGoodsStock(ref stockDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    ConverToDataSetGoodsStock(stockSucDataList, ref stockDataTableSuc, 3);
                //}
                //if (stockDataTableSuc.Rows.Count > 0)
                //{
                //    stockStatusSucCSV = this.DoCSVOutPrc(STOCKMSTMODE, LOGKINGSUC, stockDataTableSuc, stockSuccessLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion

                //// エラーログ
                //#region 商品マスタ
                //goodsErrDataList = goodsUpdateErrObj as ArrayList;
                //if (goodsErrDataList != null && goodsErrDataList.Count > 0)
                //{
                //    errorCntGoods = goodsErrDataList.Count;
                //    //TableGoodsStock(ref goodsDataTableErr); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    TableGoodsStock(ref goodsDataTableErr, ERRLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    ConverToDataSetGoodsStock(goodsErrDataList, ref goodsDataTableErr, 1);
                //}
                //if (goodsDataTableErr.Rows.Count > 0)
                //{
                //    goodsStatusErrCSV = this.DoCSVOutPrc(GOODSMSTMODE, LOGKINGERR, goodsDataTableErr, goodsErrorLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion
                //#region 価格マスタ
                //priceErrDataList = priceUpdateErrObj as ArrayList;
                //priceErrDataList.Sort(pricePrcCompare);
                //if (priceErrDataList != null && priceErrDataList.Count > 0)
                //{
                //    errorCntPrice = priceErrDataList.Count;
                //    //TableGoodsStock(ref priceDataTableErr); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    TableGoodsStock(ref priceDataTableErr, ERRLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    ConverToDataSetGoodsStock(priceErrDataList, ref priceDataTableErr, 2);
                //}
                //if (priceDataTableErr.Rows.Count > 0)
                //{
                //    priceStatusErrCSV = this.DoCSVOutPrc(PRICEMSTMODE, LOGKINGERR, priceDataTableErr, priceErrorLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion
                //#region 在庫マスタ
                //stockErrDataList = stockUpdateErrObj as ArrayList;
                //stockErrDataList.Sort(stockPrcCompare);
                //if (stockErrDataList != null && stockErrDataList.Count > 0)
                //{
                //    errorCntStock = stockErrDataList.Count;
                //    //TableGoodsStock(ref stockDataTableErr); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    TableGoodsStock(ref stockDataTableErr, ERRLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                //    ConverToDataSetGoodsStock(stockErrDataList, ref stockDataTableErr, 3);
                //}
                //if (stockDataTableErr.Rows.Count > 0)
                //{
                //    stockStatusErrCSV = this.DoCSVOutPrc(STOCKMSTMODE, LOGKINGERR, stockDataTableErr, stockErrorLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion

                //readCntGoodsAll = readCntGoods + readCntPrice + readCntStock;
                //loadCntGoodsAll = loadCntGoods + loadCntPrice + loadCntStock;
                //errCntGoodsAll = errorCntGoods + errorCntPrice + errorCntStock;
                #endregion
                //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
                GoodsStockPrcCompare goodsStockPrcCompare = new GoodsStockPrcCompare();

                // ログ
                #region 商品マスタ
                goodsSucDataList = goodsUpdateSucObj as ArrayList;
                if (goodsSucDataList != null && goodsSucDataList.Count > 0)
                {
                    loadCntGoodsAll = goodsSucDataList.Count;
                    TableGoodsStock(ref goodsDataTableSuc, SUCLOGMODE);
                    ConverToDataSetGoodsStock(goodsSucDataList, ref goodsDataTableSuc);
                }
                if (goodsDataTableSuc.Rows.Count > 0)
                {
                    goodsStatusSucCSV = this.DoCSVOutPrc(GOODSMSTMODE, LOGKINGSUC, goodsDataTableSuc, goodsSuccessLogFileName, ref goodsChangeResultWork);
                }
                #endregion

                // エラーログ
                #region 商品マスタ
                goodsErrDataList = goodsUpdateErrObj as ArrayList;
                if (goodsErrDataList != null && goodsErrDataList.Count > 0)
                {
                    errCntGoodsAll = goodsErrDataList.Count;
                    TableGoodsStock(ref goodsDataTableErr, ERRLOGMODE);
                    ConverToDataSetGoodsStock(goodsErrDataList, ref goodsDataTableErr);
                }
                if (goodsDataTableErr.Rows.Count > 0)
                {
                    goodsStatusErrCSV = this.DoCSVOutPrc(GOODSMSTMODE, LOGKINGERR, goodsDataTableErr, goodsErrorLogFileName, ref goodsChangeResultWork);
                }
                #endregion

                readCntGoodsAll = readCntGoods + readCntPrice + readCntStock;
                //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            }
            goodsChangeResultWork.ReadCntGoodsAll = readCntGoodsAll;
            goodsChangeResultWork.LoadCntGoodsAll = loadCntGoodsAll;
            goodsChangeResultWork.ErrCntGoodsAll = errCntGoodsAll;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            //goodsChangeResultWork.ErrorCntGoods = errorCntGoods;
            //goodsChangeResultWork.ErrorCntPrice = errorCntPrice;
            //goodsChangeResultWork.ErrorCntStock =errorCntStock;
            //goodsChangeResultWork.GoodsStatusErrCSV =goodsStatusErrCSV;
            //goodsChangeResultWork.PriceStatusErrCSV = priceStatusErrCSV;
            //goodsChangeResultWork.StockStatusErrCSV = stockStatusErrCSV;
            //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
            goodsChangeResultWork.ErrorCntGoods = errCntGoodsAll;
            goodsChangeResultWork.GoodsStatusErrCSV =goodsStatusErrCSV;
            //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

            return status;
        }
        #endregion

        #region 商品管理情報マスタ
        /// <summary>
        /// 商品管理情報マスタ品番変換処理
        /// </summary>
        /// <param name="goodsChangeResultWork">結果ワーク</param>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="path">パース</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 品番変換処理処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 田建委 </br>
        /// <br>           : Redmine#44209 ファイル名等の対応</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        private int ChgGoodsMngPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntMng = 0;
            int loadCntMng = 0;
            int errorCntMng = 0;

            // 戻るパラメータ
            object mngUpdateSucObj;
            object mngUpdateErrObj;

            // ＣＳＶ出力関係
            DataTable mngDataTableErr = new DataTable();
            ArrayList errDataList = new ArrayList();
            DataTable mngDataTableSuc = new DataTable();
            ArrayList sucDataList = new ArrayList();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int mngStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "GoodsMng_error.csv");
            //string successLogFileName = Path.Combine(@path, "GoodsMng_Log.csv");
            //----- DEL 2015/02/25 田建委 Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_GOODSMNG_ERROR);
            string successLogFileName = Path.Combine(@path, ct_GOODSMNG_LOG);
            //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<

            status = this._iMeijiGoodsChgAllDB.GoodsChangeGoodsMng(cndtn, out mngUpdateSucObj, out mngUpdateErrObj, out readCntMng);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                #region ログ
                sucDataList = mngUpdateSucObj as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntMng = sucDataList.Count;
                    //TableMng(ref mngDataTableSuc); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableMng(ref mngDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetMng(sucDataList, ref mngDataTableSuc);
                }
                if (mngDataTableSuc.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(GOODSMNGMSTMODE, LOGKINGSUC, mngDataTableSuc, successLogFileName, ref goodsChangeResultWork);
                }
                #endregion

                #region エラーログ
                errDataList = mngUpdateErrObj as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errorCntMng = errDataList.Count;
                    //TableMng(ref mngDataTableErr); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableMng(ref mngDataTableErr, ERRLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetMng(errDataList, ref mngDataTableErr);
                }
                if (mngDataTableErr.Rows.Count > 0)
                {
                    mngStatusErrCSV = this.DoCSVOutPrc(GOODSMNGMSTMODE, LOGKINGERR, mngDataTableErr, errorLogFileName, ref goodsChangeResultWork);
                }
                #endregion
            }

            goodsChangeResultWork.ReadCntMng = readCntMng;
            goodsChangeResultWork.LoadCntMng = loadCntMng;
            goodsChangeResultWork.ErrorCntMng = errorCntMng;
            goodsChangeResultWork.MngStatusErrCSV = mngStatusErrCSV;

            return status;
        }
        #endregion

        #region 掛率マスタ
        /// <summary>
        /// 掛率マスタ品番変換処理
        /// </summary>
        /// <param name="goodsChangeResultWork">結果ワーク</param>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="path">パース</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 品番変換処理処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 田建委 </br>
        /// <br>           : Redmine#44209 ファイル名等の対応</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        private int ChgRatePrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntRate = 0;
            int loadCntRate = 0;
            int errorCntRate = 0;
            // 戻るパラメータ
            object rateUpdateSucObj;
            object rateUpdateErrObj;

            // ＣＳＶ出力関係
            DataTable rateDataTableErr = new DataTable();
            ArrayList errDataList = new ArrayList();
            DataTable rateDataTableSuc = new DataTable();
            ArrayList sucDataList = new ArrayList();
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int rateStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "Rate_error.csv");
            //string successLogFileName = Path.Combine(@path, "Rate_Log.csv");
            //----- DEL 2015/02/25 田建委 Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_RATE_ERROR);
            string successLogFileName = Path.Combine(@path, ct_RATE_LOG);
            //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<

            status = this._iMeijiGoodsChgAllDB.GoodsChangeRate(cndtn, out rateUpdateSucObj, out rateUpdateErrObj, out readCntRate);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                #region ログ
                sucDataList = rateUpdateSucObj as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntRate = sucDataList.Count;
                    //TableRate(ref rateDataTableSuc); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableRate(ref rateDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetRate(sucDataList, ref rateDataTableSuc);
                }
                if (rateDataTableSuc.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(RATEMSTMODE, LOGKINGSUC, rateDataTableSuc, successLogFileName, ref goodsChangeResultWork);
                }
                #endregion

                #region エラーログ
                errDataList = rateUpdateErrObj as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errorCntRate = errDataList.Count;
                    //TableRate(ref rateDataTableErr); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableRate(ref rateDataTableErr, ERRLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetRate(errDataList, ref rateDataTableErr);
                }
                if (rateDataTableErr.Rows.Count > 0)
                {
                    rateStatusErrCSV = this.DoCSVOutPrc(RATEMSTMODE, LOGKINGERR, rateDataTableErr, errorLogFileName, ref goodsChangeResultWork);
                }
                #endregion
            }
            goodsChangeResultWork.ReadCntRate = readCntRate;
            goodsChangeResultWork.LoadCntRate = loadCntRate;
            goodsChangeResultWork.ErrorCntRate = errorCntRate;
            goodsChangeResultWork.RateStatusErrCSV = rateStatusErrCSV;

            return status;
        }
        #endregion

        #region 結合マスタ
        /// <summary>
        /// 結合マスタ品番変換処理
        /// </summary>
        /// <param name="goodsChangeResultWork">結果ワーク</param>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="path">パース</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 品番変換処理処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 田建委 </br>
        /// <br>           : Redmine#44209 ファイル名等の対応</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        private int ChgJoinPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntJoin = 0;
            int loadCntJoin = 0;
            int errorCntJoin = 0;
            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int joinStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "JoinParts_error.csv");
            //string successLogFileName = Path.Combine(@path, "JoinParts_Log.csv");
            //----- DEL 2015/02/25 田建委 Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_JOINPARTS_ERROR);
            string successLogFileName = Path.Combine(@path, ct_JOINPARTS_LOG);
            //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<

            object addUpdWorkObj = null;
            object dataObjectList = null;

            status = this._iMeijiGoodsChgAllDB.GoodsChangeJoin(cndtn, out addUpdWorkObj, out dataObjectList, out readCntJoin);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                errDataList = dataObjectList as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errorCntJoin = errDataList.Count;
                    //TableJoin(ref errDataTable); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableJoin(ref errDataTable, ERRLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetTableJoin(errDataList, ref errDataTable);
                }
                if (errDataTable.Rows.Count > 0)
                {
                    joinStatusErrCSV = this.DoCSVOutPrc(JOINMSTMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
                }

                sucDataList = addUpdWorkObj as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntJoin = sucDataList.Count;
                    //TableJoin(ref sucDataTable); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableJoin(ref sucDataTable, SUCLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetTableJoin(sucDataList, ref sucDataTable);
                }
                if (sucDataTable.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(JOINMSTMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
                }
            }
            goodsChangeResultWork.ReadCntJoin = readCntJoin;
            goodsChangeResultWork.LoadCntJoin = loadCntJoin;
            goodsChangeResultWork.ErrorCntJoin = errorCntJoin;
            goodsChangeResultWork.JoinStatusErrCSV = joinStatusErrCSV;

            return status;
        }
        #endregion

        #region 代替マスタ
        /// <summary>
        /// 代替マスタ品番変換処理
        /// </summary>
        /// <param name="goodsChangeResultWork">結果ワーク</param>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="path">パース</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 品番変換処理処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 田建委 </br>
        /// <br>           : Redmine#44209 ファイル名等の対応</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        private int ChgPartsPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntParts = 0;
            int loadCntParts = 0;
            int errCntParts = 0;

            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int partsStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "Subst_error.csv");
            //string successLogFileName = Path.Combine(@path, "Subst_Log.csv");
            //----- DEL 2015/02/25 田建委 Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_SUBST_ERROR);
            string successLogFileName = Path.Combine(@path, ct_SUBST_LOG);
            //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<

            object addUpdWorkObj = null;
            object dataObjectList = null;
            status = this._iMeijiGoodsChgAllDB.GoodsChangeParts(cndtn, out addUpdWorkObj, out dataObjectList, out readCntParts);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                errDataList = dataObjectList as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errCntParts = errDataList.Count;
                    //TableGoodsPartsChgMst(ref errDataTable); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableGoodsPartsChgMst(ref errDataTable, ERRLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetGoodsPartsChgMst(errDataList, ref errDataTable);
                }
                if (errDataTable.Rows.Count > 0)
                {
                    partsStatusErrCSV = this.DoCSVOutPrc(PARTSMSTMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
                }

                sucDataList = addUpdWorkObj as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntParts = sucDataList.Count;
                    //TableGoodsPartsChgMst(ref sucDataTable); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableGoodsPartsChgMst(ref sucDataTable, SUCLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetGoodsPartsChgMst(sucDataList, ref sucDataTable);
                }
                if (sucDataTable.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(PARTSMSTMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
                }
            }
            goodsChangeResultWork.ReadCntParts = readCntParts;
            goodsChangeResultWork.LoadCntParts = loadCntParts;
            goodsChangeResultWork.ErrCntParts = errCntParts;
            goodsChangeResultWork.PartsStatusErrCSV = partsStatusErrCSV;

            return status;
        }
        #endregion

        #region セットマスタ
        /// <summary>
        /// セットマスタ品番変換処理
        /// </summary>
        /// <param name="goodsChangeResultWork">結果ワーク</param>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="path">パース</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 品番変換処理処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 田建委 </br>
        /// <br>           : Redmine#44209 ファイル名等の対応</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        private int ChgGoodsSetPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            object addUpdWorkObjSet;
            object dataObjectListSet;

            int readCntSet = 0;
            int loadCntSet = 0;
            int errCntSet = 0;

            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int setStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "GoodsSet_error.csv");
            //string successLogFileName = Path.Combine(@path, "GoodsSet_Log.csv");
            //----- DEL 2015/02/25 田建委 Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_GOODSSET_ERROR);
            string successLogFileName = Path.Combine(@path, ct_GOODSSET_LOG);
            //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<

            status = this._iMeijiGoodsChgAllDB.GoodsChangeSet(cndtn, out addUpdWorkObjSet, out dataObjectListSet, out readCntSet);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                errDataList = dataObjectListSet as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errCntSet = errDataList.Count;
                    //TableGoodsSetChgMst(ref errDataTable); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableGoodsSetChgMst(ref errDataTable, ERRLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetGoodsSetChgMst(errDataList, ref errDataTable);
                }
                if (errDataTable.Rows.Count > 0)
                {
                    setStatusErrCSV = this.DoCSVOutPrc(GOODSSETMSTMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
                }

                sucDataList = addUpdWorkObjSet as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntSet = sucDataList.Count;
                    //TableGoodsSetChgMst(ref sucDataTable); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    TableGoodsSetChgMst(ref sucDataTable, SUCLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                    ConverToDataSetGoodsSetChgMst(sucDataList, ref sucDataTable);
                }
                if (sucDataTable.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(GOODSSETMSTMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
                }
            }
            goodsChangeResultWork.ReadCntSet = readCntSet;
            goodsChangeResultWork.LoadCntSet = loadCntSet;
            goodsChangeResultWork.ErrCntSet = errCntSet;
            goodsChangeResultWork.SetStatusErrCSV = setStatusErrCSV;

            return status;
        }
        #endregion

        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加----->>>>>
        #region 優良設定マスタ
        /// <summary>
        /// 優良設定マスタ処理
        /// </summary>
        /// <param name="goodsChangeResultWork">結果ワーク</param>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="path">パース</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 優良設定マスタ変換処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private int ChgPrmSettingPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            //----- DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
            //object sucObjectList;
            //object errObjectList;
            //----- DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<
            //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
            object sucObjectList = null;
            object errObjectList = null;
            //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<
            int loadCntPrm = 0;
            int errCntPrm = 0;

            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int prmStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int prmStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            string errorLogFileName = Path.Combine(@path, ct_PRMSETTING_ERROR);
            string successLogFileName = Path.Combine(@path, ct_PRMSETTING_LOG);

            int readCount = 0;
            int loginCount = 0;
            string errMsg = "";
            bool flag = false;

            //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
            #region 優良設定マスタ提供分データを取得する
            Dictionary<string, PrmSettingWork> offerPrmDic;
            status = GetOfferPrm(out offerPrmDic);
            #endregion
            //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<

            //優良設定マスタ変換処理
            //status = this._iMeijiGoodsChgAllDB.PrmSettingChange(cndtn, out sucObjectList, out errObjectList, out readCount, out loginCount, out errMsg, out flag);// DEL 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応
            //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = this._iMeijiGoodsChgAllDB.PrmSettingChange(cndtn, offerPrmDic, out sucObjectList, out errObjectList, out readCount, out loginCount, out errMsg, out flag);
            }
            else
            {
                errMsg = this.ct_PRMOFFER_ERROR;
            }
            //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<

            // エラーログlist
            errDataList = errObjectList as ArrayList;
            // 更新ログlist
            sucDataList = sucObjectList as ArrayList;

            // エラーログ
            if (errDataList != null && errDataList.Count > 0)
            {
                errCntPrm = errDataList.Count;
                CreatTablePrmSetting(ref errDataTable, ERRLOGMODE);
                ConverToDataSetPrm(errDataList, ref errDataTable, flag);
            }
            if (errDataTable.Rows.Count > 0)
            {
                prmStatusErrCSV = this.DoCSVOutPrc(PRMUPDATEERRMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
            }

            // 更新処理ログ
            if (sucDataList != null && sucDataList.Count > 0)
            {
                loadCntPrm = loginCount;
                CreatTablePrmSetting(ref sucDataTable, SUCLOGMODE);
                ConverToDataSetPrm(sucDataList, ref sucDataTable, false);
            }
            if (sucDataTable.Rows.Count > 0)
            {
                prmStatusSucCSV = this.DoCSVOutPrc(PRMSUCMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
            }

            goodsChangeResultWork.ReadCntPrm = readCount;
            goodsChangeResultWork.LoadCntPrm = loadCntPrm;
            goodsChangeResultWork.ErrCntPrm = errCntPrm;
            goodsChangeResultWork.PrmStatusErrCSV = prmStatusErrCSV;
            goodsChangeResultWork.ErrMsg = errMsg;

            return status;
        }
        #endregion
        //----- ADD 2015/02/27 陳永康 Redmine#44209 優良設定マスタ変換処理の機能追加-----<<<<<

        //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------>>>>>
        /// <summary>
        /// 優良設定マスタ提供分データを取得する
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 優良設定マスタ提供分データを取得する</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2015/03/16</br>
        /// </remarks>
        private int GetOfferPrm(out Dictionary<string, PrmSettingWork> offerPrmDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            offerPrmDic = new Dictionary<string, PrmSettingWork>();
            object retObj;
            try
            {
                // 提供データの検索
                status = this._iofferPrimeSettingSearchDB.Search(out retObj);
                string offerPrmKey = "";

                if (retObj != null)
                {
                    foreach (PrmSettingWork wkPrimeSettingWork in (ArrayList)retObj)
                    {
                        offerPrmKey = wkPrimeSettingWork.PartsMakerCd.ToString() + wkPrimeSettingWork.GoodsMGroup.ToString() +
                            wkPrimeSettingWork.TbsPartsCode.ToString() + wkPrimeSettingWork.PrmSetDtlNo1.ToString() + wkPrimeSettingWork.PrmSetDtlNo2.ToString();

                        if (!offerPrmDic.ContainsKey(offerPrmKey))
                        {
                            offerPrmDic.Add(offerPrmKey, wkPrimeSettingWork);
                        }
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        //----- ADD 2015/03/16 時シン Redmine#44209 優良設定マスタ変換の仕様変更の対応------<<<<<

        #region 貸出変換処理
        /// <summary>
        /// 貸出変換処理
        /// </summary>
        /// <param name="goodsChangeResultWork">結果ワーク</param>
        /// <param name="cndtn">条件ワーク</param>
        /// <param name="path">パース</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : 貸出変換処理を行う</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 田建委 </br>
        /// <br>           : Redmine#44209 ファイル名等の対応</br>
        /// <br>UpdateNote : 2015/02/26 時シン </br>
        /// <br>           : Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応</br>
        /// </remarks>
        private int ChgShipmentPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            object sucObjectList;
            object errObjectList;
            int loadCntShipment = 0;
            int errCntShipment = 0;

            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int shipmentStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int shipmentStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 田建委 Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "RentData_error.csv");
            //string successLogFileName = Path.Combine(@path, "RentData_Log.csv");
            //----- DEL 2015/02/25 田建委 Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 田建委 Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_RENTDATA_ERROR);
            string successLogFileName = Path.Combine(@path, ct_RENTDATA_LOG);
            //----- ADD 2015/02/25 田建委 Redmine#44209 -----<<<<<

            int readCount = 0;

            //貸出データ変換処理
            status = this._iMeijiGoodsChgAllDB.ShipmentChange(cndtn, out sucObjectList, out errObjectList, out readCount);

            ShipmentPrcCompare shipmentPrcCompare = new ShipmentPrcCompare(); // ADD 2015/03/02 時シン ログ出力順のソット処理の対応
            // エラーログlist
            errDataList = errObjectList as ArrayList;
            // 更新ログlist
            sucDataList = sucObjectList as ArrayList;

            // エラーログ
            if (errDataList != null && errDataList.Count > 0)
            {
                errDataList.Sort(shipmentPrcCompare); // ADD 2015/03/02 時シン ログ出力順のソット処理の対応
                errCntShipment = errDataList.Count;
                //CreatTableShipment(ref errDataTable); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                CreatTableShipment(ref errDataTable, ERRLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                ConverToDataSetShipment(errDataList, ref errDataTable);
            }
            if (errDataTable.Rows.Count > 0)
            {
                shipmentStatusErrCSV = this.DoCSVOutPrc(SHIPMENTERRMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
            }

            // 更新処理ログ
            if (sucDataList != null && sucDataList.Count > 0)
            {
                loadCntShipment = sucDataList.Count;
                sucDataList.Sort(shipmentPrcCompare); // ADD 2015/03/02 時シン ログ出力順のソット処理の対応
                //CreatTableShipment(ref sucDataTable); // DEL 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                CreatTableShipment(ref sucDataTable, SUCLOGMODE); // ADD 2015/02/26 時シン Redmine#44209 NO.33 ファイルの先頭にヘッダとして項目名を出力する対応
                ConverToDataSetShipment(sucDataList, ref sucDataTable);
            }
            if (sucDataTable.Rows.Count > 0)
            {
                shipmentStatusSucCSV = this.DoCSVOutPrc(SHIPMENTSUCMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
            }

            goodsChangeResultWork.ReadCntShipment = readCount;
            goodsChangeResultWork.LoadCntShipment = loadCntShipment;
            goodsChangeResultWork.ErrCntShipment = errCntShipment;
            goodsChangeResultWork.SetStatusErrCSV = shipmentStatusErrCSV;

            return status;
        }
        #endregion

        #endregion

        #endregion ■ Private Method
    }

    #region ◆　IComparer　クラス
    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
    ///// <summary>価格マスタログ出力順比較クラス</summary>
    ///// <remarks>
    ///// <br>Note       : 価格マスタログ出力順の比較を行います。</br>
    ///// <br>Programmer : 陳永康</br>
    ///// <br>Date       : 2015/01/26</br>
    ///// </remarks>
    //public class PricePrcCompare : IComparer
    //{
    //    #region IComparer メンバ

    //    /// <summary>比較用メソッド</summary>
    //    /// <param name="a">比較対象オブジェクト</param>
    //    /// <param name="b">比較対象オブジェクト</param>
    //    /// <returns>比較結果(a ＞ b : 0より大きい整数, a ＜ b : 0より小さい整数, a ＝ b : 0)</returns>
    //    /// <remarks>
    //    /// <br>Note       : 価格マスタログ出力順の比較を行います。</br>
    //    /// <br>Programmer : 陳永康</br>
    //    /// <br>Date       : 2015/01/26</br>
    //    /// </remarks>
    //    public int Compare(object a, object b)
    //    {
    //        MeijiGoodsStockWork x = a as MeijiGoodsStockWork;
    //        MeijiGoodsStockWork y = b as MeijiGoodsStockWork;

    //        if (x.GoodsMakerCd > y.GoodsMakerCd)
    //        {
    //            return 1;
    //        }
    //        else if (x.GoodsMakerCd == y.GoodsMakerCd)
    //        {
    //            if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) > 0)
    //            {
    //                return 1;
    //            }
    //            else if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) == 0)
    //            {
    //                if (DateTime.Compare(x.PriceStartDate, y.PriceStartDate) > 0)
    //                {
    //                    return 1;
    //                }
    //                else if (DateTime.Compare(x.PriceStartDate, y.PriceStartDate) == 0)
    //                {
    //                    return 0;
    //                }
    //                else
    //                {
    //                    return -1;
    //                }
    //            }
    //            else
    //            {
    //                return -1;
    //            }
    //        }
    //        else
    //        {
    //            return -1;
    //        }
    //    }

    //    #endregion
    //}

    ///// <summary>在庫マスタログ出力順比較クラス</summary>
    ///// <remarks>
    ///// <br>Note       : 在庫マスタログ出力順の比較を行います。</br>
    ///// <br>Programmer : 陳永康</br>
    ///// <br>Date       : 2015/01/26</br>
    ///// </remarks>
    //public class StockPrcCompare : IComparer
    //{
    //    #region IComparer メンバ

    //    /// <summary>比較用メソッド</summary>
    //    /// <param name="a">比較対象オブジェクト</param>
    //    /// <param name="b">比較対象オブジェクト</param>
    //    /// <returns>比較結果(a ＞ b : 0より大きい整数, a ＜ b : 0より小さい整数, a ＝ b : 0)</returns>
    //    /// <remarks>
    //    /// <br>Note       : 在庫マスタログ出力順の比較を行います。</br>
    //    /// <br>Programmer : 陳永康</br>
    //    /// <br>Date       : 2015/01/26</br>
    //    /// </remarks>
    //    public int Compare(object a, object b)
    //    {
    //        MeijiGoodsStockWork x = a as MeijiGoodsStockWork;
    //        MeijiGoodsStockWork y = b as MeijiGoodsStockWork;

    //        int c = 0;
    //        int d = 0;
    //        int wareHouseCodex = 0;
    //        int wareHouseCodey = 0;

    //        if (Int32.TryParse(x.WareCode, out c) && Int32.TryParse(y.WareCode, out d))
    //        {
    //            wareHouseCodex = Convert.ToInt32(x.WareCode);
    //            wareHouseCodey = Convert.ToInt32(y.WareCode);
    //        }

    //        if (x.GoodsMakerCd > y.GoodsMakerCd)
    //        {
    //            return 1;
    //        }
    //        else if (x.GoodsMakerCd == y.GoodsMakerCd)
    //        {
    //            if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) > 0)
    //            {
    //                return 1;
    //            }
    //            else if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) == 0)
    //            {
    //                if (wareHouseCodex > wareHouseCodey)
    //                {
    //                    return 1;
    //                }
    //                else if (wareHouseCodex == wareHouseCodey)
    //                {
    //                    return 0;
    //                }
    //                else
    //                {
    //                    return -1;
    //                }
    //            }
    //            else
    //            {
    //                return -1;
    //            }
    //        }
    //        else
    //        {
    //            return -1;
    //        }
    //    }

    //    #endregion
    //}
    //----- DEL 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------>>>>>
    /// <summary>商品在庫マスタログ出力順比較クラス</summary>
    /// <remarks>
    /// <br>Note       : 商品在庫マスタログ出力順の比較を行います。</br>
    /// <br>Programmer : 時シン</br>
    /// <br>Date       : 2015/03/02</br>
    /// </remarks>
    public class GoodsStockPrcCompare : IComparer
    {
        #region IComparer メンバ

        /// <summary>比較用メソッド</summary>
        /// <param name="a">比較対象オブジェクト</param>
        /// <param name="b">比較対象オブジェクト</param>
        /// <returns>比較結果(a ＞ b : 0より大きい整数, a ＜ b : 0より小さい整数, a ＝ b : 0)</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタログ出力順の比較を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int Compare(object a, object b)
        {
            MeijiGoodsStockWork x = a as MeijiGoodsStockWork;
            MeijiGoodsStockWork y = b as MeijiGoodsStockWork;

            if (x.GoodsMakerCd > y.GoodsMakerCd)
            {
                return 1;
            }
            else if (x.GoodsMakerCd == y.GoodsMakerCd)
            {
                if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) > 0)
                {
                    return 1;
                }
                else if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) == 0)
                {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }

        #endregion
    }
    //----- ADD 2015/03/02 時シン Redmine#44209 「仕様変更」商品マスタ、在庫マスタ、価格マスタのログを１つに集約して出力する対応------<<<<<

    // --- ADD 2015/03/02 時シン ログ出力順のソット処理の対応 ----->>>>>
    /// <summary>貸出データ変換処理ログ出力順比較クラス</summary>
    /// <remarks>
    /// <br>Note       : 貸出データ変換処理ログ出力順の比較を行います。</br>
    /// <br>Programmer : 陳永康</br>
    /// <br>Date       : 2015/03/02</br>
    /// </remarks>
    public class ShipmentPrcCompare : IComparer
    {
        #region IComparer メンバ

        /// <summary>比較用メソッド</summary>
        /// <param name="a">比較対象オブジェクト</param>
        /// <param name="b">比較対象オブジェクト</param>
        /// <returns>比較結果(a ＞ b : 0より大きい整数, a ＜ b : 0より小さい整数, a ＝ b : 0)</returns>
        /// <remarks>
        /// <br>Note       : 貸出データ変換処理ログ出力順の比較を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int Compare(object a, object b)
        {
            ShipmentChangeWork x = a as ShipmentChangeWork;
            ShipmentChangeWork y = b as ShipmentChangeWork;

            int c = 0;
            int d = 0;
            int salesSlipNox = 0;
            int salesSlipNoy = 0;

            if (Int32.TryParse(x.SalesSlipNum, out c) && Int32.TryParse(y.SalesSlipNum, out d))
            {
                salesSlipNox = c;
                salesSlipNoy = d;
            }

            if (salesSlipNox > salesSlipNoy)
            {
                return 1;
            }
            else if (salesSlipNox == salesSlipNoy)
            {
                if (x.SalesRowNo > y.SalesRowNo)
                {
                    return 1;
                }
                else if (x.SalesRowNo == y.SalesRowNo)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
    // --- ADD 2015/03/02 時シン ログ出力順のソット処理の対応 -----<<<<<
    #endregion
}
