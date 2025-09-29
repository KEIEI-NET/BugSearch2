//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 請求書印刷パターン設定
// プログラム概要   : 請求書印刷パターン設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 中村　仁
// 作 成 日  2007/07/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 古賀　小百合
// 修 正 日  2007/07/12  修正内容 : 鑑設定項目区分に選択肢を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 疋田　勇人
// 修 正 日  2007/09/18  修正内容 : DC.NS用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 柴田 倫幸
// 修 正 日  2008/06/18  修正内容 : データ項目の追加/削除による修正
//----------------------------------------------------------------------------//
// 管理番号  12689       作成担当 : 工藤 恵優
// 修 正 日  2009/03/24  修正内容 : 「削除済データの表示」は最上位項目で制御
//----------------------------------------------------------------------------//
// 管理番号  　　        作成担当 : 大矢 睦美
// 修 正 日  2009/11/11  修正内容 : 印字位置を10分の１ミリまで設定可能にする
//----------------------------------------------------------------------------//
// 管理番号  　　        作成担当 : 大矢 睦美
// 修 正 日  2010/02/18  修正内容 : 注釈印字区分を追加
//----------------------------------------------------------------------------//
// 管理番号  　　        作成担当 : 施ヘイ中
// 修 正 日  2011/02/16  修正内容 : 自社名印字区分を追加
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;   // ADD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 請求書印刷パターン設定UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求書印刷パターンマスタへのUI画面クラスです</br>
    /// <br>Programmer : 23010  中村　仁</br>
    /// <br>Date       : 2007/07/03</br>
    /// <br>Update Note: 2007/07/12  20031 古賀　小百合</br>
    /// <br>           : 鑑設定項目区分に選択肢を追加</br>
    /// <br>Update Note: 2007.09.18  20081 疋田　勇人</br>
    /// <br>           : DC.NS用に変更</br>
    /// <br>UpdateNote : 2008/06/18 30415 柴田 倫幸</br>
    /// <br>        	 ・データ項目の追加/削除による修正</br>
    /// <br>UpdateNote : 2009/03/24 30434 工藤 恵優</br>
    /// <br>        	 ・「削除済データの表示」は最上位項目で制御</br>
    /// <br>UpdateNote : 2010/02/18 30531 大矢 睦美</br>
    /// <br>        	 : 注釈印字区分追加</br>
    /// <br>UpdateNote : 2010/06/15 30531 大矢 睦美</br>
    /// <br>        	 : 印字順位　選択内容追加</br>
    /// <br>UpdateNote :  2011/02/16 施ヘイ中</br>
    /// <br>           :  自社名印字区分を追加</br>
    /// </remarks>  
    public partial class MAKAU09150UA : Form, IMasterMaintenanceArrayType
    {
        #region Constructor
        /// <summary>
        /// 請求書印刷パターン設定UIクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note		:  請求書印刷パターン設定UIクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer	: 23010  中村　仁</br>
        /// <br>Date		: 2007/07/03</br>
        /// </remarks>
        public MAKAU09150UA()
        {
            InitializeComponent();

            this.Bind_DataSet = new DataSet();

            // DataSet列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = true;
            this._canNew = true;
            this._canDelete = true;
            this._canLogicalDeleteDataExtraction = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            // --- ADD 2008/06/18 -------------------------------->>>>>
            this._mainDataIndex = -1;
            this._detailsDataIndex = -1;
            this._targetTableName = "";
            this._defaultGridDisplayLayout = MGridDisplayLayout.Vertical;
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            //コード参照用フラグ
            //this._changeFlag = false;  // DEL 2008/06/18          
            //画面最小化対応
            this._indexBuf = -2;
            //取得件数
            this._totalCount = 0;

            //企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //変数インスタンス化
            this._controlScreenSkin = new ControlScreenSkin();
            this._dmdPrtPtnAcs      = new DmdPrtPtnAcs();
            this._dmdPrtPtn         = new DmdPrtPtn();
            this._mGoodsGanre       = new MGoodsGanre();
            this._mGoodsGanreAcs    = new MGoodsGanreAcs();
            //this._dmdPrtPtnTable    = new Hashtable();      // DEL 2008/06/18
            this._dmdPrtPtnClone    = new DmdPrtPtn();

            // --- ADD 2008/06/18 -------------------------------->>>>>
            this._dmdPrtPtnLeftTable = new Hashtable();
            this._dmdPrtPtnRightTable = new Hashtable();
            // --- ADD 2008/06/18 --------------------------------<<<<< 
        }

        #endregion

        #region PrivateMember
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin;
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>請求書印刷パターン設定データクラス</summary>
        private DmdPrtPtn _dmdPrtPtn;
        /// <summary>請求書印刷パターン設定アクセスクラス</summary>
        private DmdPrtPtnAcs _dmdPrtPtnAcs;
        /// <summary>商品区分データクラス</summary>
        private MGoodsGanre _mGoodsGanre;
        /// <summary>商品区分アクセスクラス</summary>
        private MGoodsGanreAcs _mGoodsGanreAcs;

        /// <summary>HashTable</summary>
        private Hashtable _dmdPrtPtnLeftTable;
        private Hashtable _dmdPrtPtnRightTable;

        /// <summary>比較用Clone</summary>
        private DmdPrtPtn _dmdPrtPtnClone;
        ///// <summary>コード参照用フラグ</summary>
        //private bool _changeFlag;  // DEL 2008/06/18
        /// <summary>最小化対応バッファ</summary>
        private int _indexBuf;
        /// <summary>取得件数</summary>
        private int _totalCount;
        /// <summary>イベントフラグ</summary>
        private bool _eventFlag = false;
       
        private DataSet Bind_DataSet;

        #endregion

        #region PrivateConst
        //カラム名称
        private const string VIEW_DELETE_DATE = "削除日";

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        private const string VIEW_DEMANDPTNNO = "請求書パターン番号";
        private const string VIEW_DEMANDPTNNM = "請求書パターン名称";
           --- DEL 2008/06/18 --------------------------------<<<<< */

        private const string VIEW_DMDFORMTITLE = "請求書タイトル";

        //private const string VIEW_PAYMENTFORMTITLE = "支払通知書タイトル";  // DEL 2008/06/18

        private const string VIEW_DMDTTLSETITEMDIV1     = "鑑設定項目区分コード１";
        private const string VIEW_DMDTTLSETITEMDIV1NM   = "鑑設定項目区分１";
        private const string VIEW_DMDTTLSETITEMDIV2     = "鑑設定項目区分コード２";
        private const string VIEW_DMDTTLSETITEMDIV2NM   = "鑑設定項目区分２";
        private const string VIEW_DMDTTLSETITEMDIV3     = "鑑設定項目区分コード３";
        private const string VIEW_DMDTTLSETITEMDIV3NM   = "鑑設定項目区分３";
        private const string VIEW_DMDTTLSETITEMDIV4     = "鑑設定項目区分コード４";
        private const string VIEW_DMDTTLSETITEMDIV4NM   = "鑑設定項目区分４";
        private const string VIEW_DMDTTLSETITEMDIV5     = "鑑設定項目区分コード５";
        private const string VIEW_DMDTTLSETITEMDIV5NM   = "鑑設定項目区分５";
        private const string VIEW_DMDTTLSETITEMDIV6     = "鑑設定項目区分コード６";
        private const string VIEW_DMDTTLSETITEMDIV6NM   = "鑑設定項目区分６";
        private const string VIEW_DMDTTLSETITEMDIV7     = "鑑設定項目区分コード７";
        private const string VIEW_DMDTTLSETITEMDIV7NM   = "鑑設定項目区分７";
        private const string VIEW_DMDTTLSETITEMDIV8     = "鑑設定項目区分コード８";
        private const string VIEW_DMDTTLSETITEMDIV8NM   = "鑑設定項目区分８";
        private const string VIEW_DMDTTLFORMTITLE1 = "請求:鑑タイトル１";
        private const string VIEW_DMDTTLFORMTITLE2 = "請求:鑑タイトル２";
        private const string VIEW_DMDTTLFORMTITLE3 = "請求:鑑タイトル３";
        private const string VIEW_DMDTTLFORMTITLE4 = "請求:鑑タイトル４";
        private const string VIEW_DMDTTLFORMTITLE5 = "請求:鑑タイトル５";
        private const string VIEW_DMDTTLFORMTITLE6 = "請求:鑑タイトル６";
        private const string VIEW_DMDTTLFORMTITLE7 = "請求:鑑タイトル７";
        private const string VIEW_DMDTTLFORMTITLE8 = "請求:鑑タイトル８";

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        private const string VIEW_PAYTTLFORMTITLE1 = "支払:鑑タイトル１";
        private const string VIEW_PAYTTLFORMTITLE2 = "支払:鑑タイトル２";
        private const string VIEW_PAYTTLFORMTITLE3 = "支払:鑑タイトル３";
        private const string VIEW_PAYTTLFORMTITLE4 = "支払:鑑タイトル４";
        private const string VIEW_PAYTTLFORMTITLE5 = "支払:鑑タイトル５";
        private const string VIEW_PAYTTLFORMTITLE6 = "支払:鑑タイトル６";
        private const string VIEW_PAYTTLFORMTITLE7 = "支払:鑑タイトル７";
        private const string VIEW_PAYTTLFORMTITLE8 = "支払:鑑タイトル８"; 
          --- DEL 2008/06/18 --------------------------------<<<<< */

        private const string VIEW_DMDFORMCOMENT1 = "請求書コメント１";
        private const string VIEW_DMDFORMCOMENT2 = "請求書コメント２";
        private const string VIEW_DMDFORMCOMENT3 = "請求書コメント３";

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        private const string VIEW_DMDFMDMDTTLGENCD1 = "請求集計分類コード１";
        private const string VIEW_DMDFMDMDTTLGENCD1NM = "請求集計分類１";
        private const string VIEW_DMDFMDMDTTLGENCD2 = "請求集計分類コード２";
        private const string VIEW_DMDFMDMDTTLGENCD2NM = "請求集計分類２";
        private const string VIEW_DMDFMDMDTTLGENCD3 = "請求集計分類コード３";
        private const string VIEW_DMDFMDMDTTLGENCD3NM = "請求集計分類３";
        private const string VIEW_DMDFMPAYTTLGENCD1 = "支払集計分類コード１";
        private const string VIEW_DMDFMPAYTTLGENCD1NM = "支払集計分類１";
        private const string VIEW_DMDFMPAYTTLGENCD2 = "支払集計分類コード２";
        private const string VIEW_DMDFMPAYTTLGENCD2NM = "支払集計分類２";
        private const string VIEW_DMDFMPAYTTLGENCD3 = "支払集計分類コード３";
        private const string VIEW_DMDFMPAYTTLGENCD3NM = "支払集計分類３";
        private const string VIEW_DMDFMDMDTTLGENNM2 = "請求集計分類名称２";
        private const string VIEW_DMDFMDMDTTLGENNM3 = "求集計分類名称３";
        private const string VIEW_DMDTTLGENDEFLTNM = "請求集計分類初期表示名称";
        private const string VIEW_PAYTTLGENDEFLTNM = "支払集計分類初期表示名称";

        private const string VIEW_DMDDTLUNITPRTDIV = "請求明細単価別出力区分コード";
        private const string VIEW_DMDDTLUNITPRTDIVNM = "請求明細単価別出力区分";
        private const string VIEW_PAYDTLUNITPRTDIV = "支払明細単価別出力区分コード";
        private const string VIEW_PAYDTLUNITPRTDIVNM = "支払明細単価別出力区分";
        private const string VIEW_DMDDTLPRCZEROPRTDIV = "請求明細金額０印字区分コード";
        private const string VIEW_DMDDTLPRCZEROPRTDIVNM = "請求明細金額０印字区分";
        private const string VIEW_PAYDTLPRCZEROPRTDIV = "支払明細金額０印字区分コード";
        private const string VIEW_PAYDTLPRCZEROPRTDIVNM = "支払明細金額０印字区分";
        private const string VIEW_THTMDMDZEROPRTDIV = "今回請求額０印字区分コード";
        private const string VIEW_THTMDMDZEROPRTDIVNM = "今回請求額０印字区分";  
        private const string VIEW_MINUSDMDPRTDIV = "マイナス請求時印刷区分コード";
        private const string VIEW_MINUSDMDPRTDIVNM = "マイナス請求時印刷区分";
        private const string VIEW_DMDFMDEPOTTLPRTDIV = "入金集計明細印字区分コード";
        private const string VIEW_DMDFMDEPOTTLPRTDIVNM = "入金集計明細印字区分";
        private const string VIEW_CELLPHONEINCOUTDIV = "機種別インセンティブ出力区分コード";
        private const string VIEW_CELLPHONEINCOUTDIVNM = "機種別インセンティブ出力区分";
        private const string VIEW_CMPLDMDMDGOODSCD1 = "強制請求出力商品区分コード１";
        private const string VIEW_CMPLDMDMDGOODSCD2 = "強制請求出力商品区分コード２";
        private const string VIEW_CMPLDMDMDGOODSCD3 = "強制請求出力商品区分コード３";
        private const string VIEW_CMPLDMDMDGOODSCD4 = "強制請求出力商品区分コード４";
        private const string VIEW_CMPLDMDMDGOODSCD5 = "強制請求出力商品区分コード５";
        private const string VIEW_CMPLDMDMDGOODSCD6 = "強制請求出力商品区分コード６";
        private const string VIEW_CMPLDMDMDGOODSCD7 = "強制請求出力商品区分コード７";
        private const string VIEW_CMPLDMDMDGOODSCD8 = "強制請求出力商品区分コード８";
        private const string VIEW_CMPLDMDMDGOODSCD9 = "強制請求出力商品区分コード９";
        private const string VIEW_CMPLDMDMDGOODSCD10 = "強制請求出力商品区分コード１０";
        private const string VIEW_CMPLDMDMDGOODSCD1NM = "強制請求出力商品区分１";
        private const string VIEW_CMPLDMDMDGOODSCD2NM = "強制請求出力商品区分２";
        private const string VIEW_CMPLDMDMDGOODSCD3NM = "強制請求出力商品区分３";
        private const string VIEW_CMPLDMDMDGOODSCD4NM = "強制請求出力商品区分４";
        private const string VIEW_CMPLDMDMDGOODSCD5NM = "強制請求出力商品区分５";
        private const string VIEW_CMPLDMDMDGOODSCD6NM = "強制請求出力商品区分６";
        private const string VIEW_CMPLDMDMDGOODSCD7NM = "強制請求出力商品区分７";
        private const string VIEW_CMPLDMDMDGOODSCD8NM = "強制請求出力商品区分８";
        private const string VIEW_CMPLDMDMDGOODSCD9NM = "強制請求出力商品区分９";
        private const string VIEW_CMPLDMDMDGOODSCD10NM = "強制請求出力商品区分１０";
        private const string VIEW_CMPLPAYMDGOODSCD1 = "強制支払出力商品区分コード１";
        private const string VIEW_CMPLPAYMDGOODSCD2 = "強制支払出力商品区分コード２";
        private const string VIEW_CMPLPAYMDGOODSCD3 = "強制支払出力商品区分コード３";
        private const string VIEW_CMPLPAYMDGOODSCD4 = "強制支払出力商品区分コード４";
        private const string VIEW_CMPLPAYMDGOODSCD5 = "強制支払出力商品区分コード５";
        private const string VIEW_CMPLPAYMDGOODSCD6 = "強制支払出力商品区分コード６";
        private const string VIEW_CMPLPAYMDGOODSCD7 = "強制支払出力商品区分コード７";
        private const string VIEW_CMPLPAYMDGOODSCD8 = "強制支払出力商品区分コード８";
        private const string VIEW_CMPLPAYMDGOODSCD9 = "強制支払出力商品区分コード９";
        private const string VIEW_CMPLPAYMDGOODSCD10 = "強制支払出力商品区分コード１０";
        private const string VIEW_CMPLPAYMDGOODSCD1NM = "強制支払出力商品区分１";
        private const string VIEW_CMPLPAYMDGOODSCD2NM = "強制支払出力商品区分２";
        private const string VIEW_CMPLPAYMDGOODSCD3NM = "強制支払出力商品区分３";
        private const string VIEW_CMPLPAYMDGOODSCD4NM = "強制支払出力商品区分４";
        private const string VIEW_CMPLPAYMDGOODSCD5NM = "強制支払出力商品区分５";
        private const string VIEW_CMPLPAYMDGOODSCD6NM = "強制支払出力商品区分６";
        private const string VIEW_CMPLPAYMDGOODSCD7NM = "強制支払出力商品区分７";
        private const string VIEW_CMPLPAYMDGOODSCD8NM = "強制支払出力商品区分８";
        private const string VIEW_CMPLPAYMDGOODSCD9NM = "強制支払出力商品区分９";
        private const string VIEW_CMPLPAYMDGOODSCD10NM = "強制支払出力商品区分１０";
           --- DEL 2008/06/18 --------------------------------<<<<< */

        // --- ADD 2008/06/18 -------------------------------->>>>>
        private const string GRIDTITLE_PRINTKIND = "印刷種別";
        private const string GRIDTITLE_PRINTPATTERN = "印刷パターン";

        private const string VIEW_SLIPPRTKIND = "印刷種別";
        private const string VIEW_SLIPPRTKINDID = "印刷種別ID";

        // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
        private const string VIEW_DATAINPUTSYSTEM = "データ入力システム";
        private const string VIEW_OUTPUTFILENAME = "出力ファイル名";
        private const string VIEW_SLIPPRTSETPAPERID = "印刷帳票ID";
        // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
        // DEL 2008/10/09 不具合対応[6478] ↓
        //private const string VIEW_SLIPCOMMENT = "パターン名称";
        private const string VIEW_SLIPCOMMENT = "パターン名";   // ADD 2008/10/09 不具合対応[6478]
        private const string VIEW_BILLHONORIFICTTL = "得意先敬称";
        private const string VIEW_COPYCOOUNT = "複写枚数";
        private const string VIEW_TOPMARGIN = "上余白";
        private const string VIEW_BOTTOMMARGIN = "下余白";
        private const string VIEW_LEFTMARGIN = "左余白";
        private const string VIEW_RIGHTMARGIN = "右余白";
        private const string VIEW_DMDFORMTITLE2 = "請求書(控)タイトル";
        private const string VIEW_DMDDTLPTNODRDIV = "印字順位";
        private const string VIEW_DMDDTLOUTLINECODE = "請求明細摘要区分";
        private const string VIEW_DTLPRCZEROPRTDIV = "明細金額ゼロ時";
        private const string VIEW_DEPODTLPRCPRTDIV = "入金明細";
        private const string VIEW_SLIPTTLPRTDIV = "伝票計";
        private const string VIEW_ADDDAYTTLPRTDIV = "計上日計";
        private const string VIEW_CUSTOMERTTLPRTDIV = "得意先計";
        // --- ADD 2008/06/18 --------------------------------<<<<< 

        // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
        private const string VIEW_LISTPRICEPRTCD = "標準価格印字区分";
        private const string VIEW_PARTSNOPRTCD = "品番印字区分";
        // 2009.04.03 30413 犬飼 項目追加 <<<<<<END

        // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
        private const string VIEW_ANNOTATIONPRTCD = "注釈印字区分";
        // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

        // --- ADD  2011/02/16 ---------->>>>>
        private const string VIEW_CONMPRINTOUTCD = "自社名印字区分";
        // --- ADD  2011/02/16 ----------<<<<<

        private const string VIEW_FILEHEADERGUID = "GUID";

        //請求書鑑設定項目区分
        private const string DMDTTLSETITEM_DIV0 = "未使用";
        private const string DMDTTLSETITEM_DIV1 = "前回請求額";
        private const string DMDTTLSETITEM_DIV2 = "今回入金額";
        private const string DMDTTLSETITEM_DIV3 = "繰越請求額";
        // 2007.07.12  S.Koga  AMEND ------------------------------------------
        // 表示インデックスで扱っているため、項目並び順に数値を再設定
        // *注　修正する際は、請求書（帳票印刷）と合わせる必要があります。
        // --------------------------------------------------------------------
        //private const string DMDTTLSETITEM_DIV4 = "今回税抜相殺請求額";
        //private const string DMDTTLSETITEM_DIV5 = "今回相殺消費税額";
        //private const string DMDTTLSETITEM_DIV6 = "今回税込請求額";
        //private const string DMDTTLSETITEM_DIV7 = "今回税込支払額";
        //private const string DMDTTLSETITEM_DIV8 = "今回税込相殺請求額";
        //private const string DMDTTLSETITEM_DIV9 = "御請求額";
        private const string DMDTTLSETITEM_DIV4 = "今回税抜請求額";
        private const string DMDTTLSETITEM_DIV5 = "今回税抜支払額";
        private const string DMDTTLSETITEM_DIV6 = "今回税抜相殺請求額";
        private const string DMDTTLSETITEM_DIV7 = "今回請求消費税額";
        private const string DMDTTLSETITEM_DIV8 = "今回支払消費税額";
        private const string DMDTTLSETITEM_DIV9 = "今回相殺消費税額";
        private const string DMDTTLSETITEM_DIV10 = "今回税込請求額";
        private const string DMDTTLSETITEM_DIV11 = "今回税込支払額";
        private const string DMDTTLSETITEM_DIV12 = "今回税込相殺請求額";
        private const string DMDTTLSETITEM_DIV13 = "御請求額";
        // --------------------------------------------------------------------
        //明細単価別出力有無
        private const string DMDTLUNITPRT_DIV0  = "単価印字する";
        private const string DMDTLUNITPRT_DIV1  = "単価印字しない";
        //請求明細金額０印字区分
        private const string DMDDTLPRCZEROPRT_DIV0  = "印字する";
        private const string DMDDTLPRCZEROPRT_DIV1  = "全て０のみ印字しない";
        private const string DMDDTLPRCZEROPRT_DIV2  = "相殺額が０の時印字しない";
        //通常印字区分
        private const string PRINT_DIV0  = "印字する";
        private const string PRINT_DIV1  = "印字しない";
        //マイナス請求時印刷区分
        private const string MINUSDMDPRT_DIV0 = "支払通知書とする";
        private const string MINUSDMDPRT_DIV1 = "マイナス請求書とする";
        //機種別インセンティブ出力区分
        private const string CELLPHONEINCOUT_DIV0 = "集計印字";
        private const string CELLPHONEINCOUT_DIV1 = "機種別印字";
        //集計分類項目
        private const string DMDFMGENCD_DIV0 = "無し";
        private const string DMDFMGENCD_DIV1 = "商品区分グループ";
        private const string DMDFMGENCD_DIV2 = "商品区分";
        // 2007.09.18 hikita upd start ------------------------------>>
        //private const string DMDFMGENCD_DIV3 = "商品";
        //private const string DMDFMGENCD_DIV4 = "得意先";
        //private const string DMDFMGENCD_DIV5 = "契約区分";
        //private const string DMDFMGENCD_DIV6 = "キャリア";
        private const string DMDFMGENCD_DIV3 = "商品区分詳細";
        private const string DMDFMGENCD_DIV4 = "商品";
        private const string DMDFMGENCD_DIV5 = "得意先";
        // 2007.09.18 hikita upd end --------------------------------<<

        // --- ADD 2008/06/18 -------------------------------->>>>>
        // データ入力システム
        // ※未使用
        
        // 伝票印刷種別
        private const string SLIPPRTKIND_TOTAL   = "合計請求書";
        private const string SLIPPRTKIND_DETAIL  = "明細請求書";
        private const string SLIPPRTKIND_SLIP    = "伝票合計請求書";
        private const string SLIPPRTKIND_RECEIPT = "領収書";
        // 伝票印刷種別ID
        private const int SLIPPRTKINDID_TOTAL   = 50;
        private const int SLIPPRTKINDID_DETAIL  = 60;
        private const int SLIPPRTKINDID_SLIP    = 70;
        private const int SLIPPRTKINDID_RECEIPT = 80;

        // 請求明細摘要区分
        private const string DMDDTLOOUTLINECODE_DIV0 = "印字しない";
        private const string DMDDTLOOUTLINECODE_DIV1 = "品番";
        // DEL 2008/10/09 不具合対応[6478] ↓
        //private const string DMDDTLOOUTLINECODE_DIV2 = "定価";
        private const string DMDDTLOOUTLINECODE_DIV2 = "価格";  // ADD 2008/10/09 不具合対応[6478]

        // 請求明細書印字順位区分
        private const string DMDDTLPTNODR_DIV0 = "計上日＋伝票番号";
        private const string DMDDTLPTNODR_DIV1 = "得意先＋計上日＋伝票番号";
        // --- ADD  大矢睦美  2010/06/15 ---------->>>>>
        private const string DMDDTLPTNODR_DIV2 = "売上/入金＋計上日＋伝票番号";
        private const string DMDDTLPTNODR_DIV3 = "売上/入金＋得意先＋計上日＋伝票番号";
        // --- ADD  大矢睦美  2010/06/15 ----------<<<<<

        // 入金明細印字有無区分
        private const string DEPODTLPRCPRT_DIV0 = "印字しない";
        private const string DEPODTLPRCPRT_DIV1 = "印字する（合計）";
        private const string DEPODTLPRCPRT_DIV2 = "印字する（明細）";

        private const string DMDFORMTITLE2_DEFAULT = "請求書";
        // --- ADD 2008/06/18 --------------------------------<<<<< 

        // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
        // 標準価格印字区分
        private const string LISTPRICEPRTCD_DIV0 = "印字しない";
        private const string LISTPRICEPRTCD_DIV1 = "印字する";
        private const string LISTPRICEPRTCD_DIV2 = "掛率＜１";

        // 品番印字区分
        private const string PARTSNOPRTCD_DIV0 = "印字しない";
        private const string PARTSNOPRTCD_DIV1 = "印字する";
        // 2009.04.03 30413 犬飼 項目追加 <<<<<<END
        
        // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
        //注釈印字区分
        private const string ANNOTATIONPRTCD_DIV0 = "印字する";
        private const string ANNOTATIONPRTCD_DIV1 = "印字しない";
        // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

        private const string NOTTARGETRECORD = "未登録";
        private const string ALREADYDELETE   = "削除済";
        private const string NOTTARGETRECORDMES = "該当レコードが存在しません。" + "\r\n" + "マスタから削除されている可能性があります。"+"\r\n"+ "商品区分設定を確認して下さい。";
        private const string ALREADYDELETEMES   = "マスタから削除されています。";

        // --- ADD  2011/02/16 ---------->>>>>
        // 自社名印字区分
        private const string CONMPRINTOUTCD_DIV0 = "標準";
        private const string CONMPRINTOUTCD_DIV1 = "自社名";
        private const string CONMPRINTOUTCD_DIV2 = "拠点名";
        private const string CONMPRINTOUTCD_DIV3 = "ビットマップ";
        private const string CONMPRINTOUTCD_DIV4 = "印字しない";
        // --- ADD  2011/02/16 ---------->>>>>

        #endregion

        #region private enum

        /// <summary>
		/// 鑑設定項目区分
		/// </summary>
        private enum DmdTtlSetItemDiv
        {
            ///<summary>未使用</summary>
            None                                = 0,
            ///<summary>前回請求額</summary>
            LastTimeDemandPrice                 = 1,
            ///<summary>今回入金額</summary>
            ThisTimeDepositPrice                = 2,     
            ///<summary>繰越請求額</summary>
            OverDemandPrice                     = 3,
            // 2007.07.12  S.Koga  AMEND --------------------------------------
            // 表示インデックスで扱っているため、項目並び順に数値を再設定
            // *注　修正する際は、請求書（帳票印刷）と合わせる必要があります。
            // ----------------------------------------------------------------
            /////<summary>今回税抜相殺請求額</summary>
            //ThisTimeExTaxAfterDemandPrice       = 4,
            /////<summary>今回相殺消費税額</summary>
            //ThisTimeAfterTaxPrice               = 5,
            /////<summary>今回税込請求額</summary>
            //ThisTimeIncTaxDemandPrice           = 6,
            /////<summary>今回税込支払額</summary>
            //ThisTimeIncTaxPayPrice              = 7,
            /////<summary>今回税込相殺請求額</summary>
            //ThisTimeIncTaxAfterDemandPrice      = 8,
            /////<summary>御請求額</summary>
            //DemandPrice                         = 9   
            ///<summary>今回税抜請求額</summary>
            ThisTimeExTaxDemandPrice = 4,
            ///<summary>今回税抜支払額</summary>
            ThisTimeExTaxPayPrice = 5,
            ///<summary>今回税抜相殺請求額</summary>
            ThisTimeExTaxAfterDemandPrice = 6,
            ///<summary>今回請求消費税額</summary>
            ThisTimeDemandTaxPrice = 7,
            ///<summary>今回支払消費税額</summary>
            ThisTimePayTaxPrice = 8,
            ///<summary>今回相殺消費税額</summary>
            ThisTimeAfterTaxPrice = 9,
            ///<summary>今回税込請求額</summary>
            ThisTimeIncTaxDemandPrice = 10,
            ///<summary>今回税込支払額</summary>
            ThisTimeIncTaxPayPrice = 11,
            ///<summary>今回税込相殺請求額</summary>
            ThisTimeIncTaxAfterDemandPrice = 12,
            ///<summary>御請求額</summary>
            DemandPrice = 13   
            // ----------------------------------------------------------------

        }

        /// <summary>
		/// 集計分類項目コード
		/// </summary>
        private enum DmdFmTtlGenCd
        {       
            ///<summary>無し</summary>
            None                                = 0,       
            ///<summary>商品区分グループ</summary>
            LargeGoods                          = 1,     
            ///<summary>商品区分</summary>
            MediumGoods                         = 2,
            ///<summary>商品</summary>
            Goods                               = 3,
            ///<summary>得意先</summary>
            Customer                            = 4,
            ///<summary>契約区分</summary>
            PromissDiv                          = 5,
            ///<summary>キャリア</summary>
            Carrier                             = 6          
        }

        /// <summary>
		/// 明細単価別印字区分
		/// </summary>
        private enum UnitPricePrintDiv
        {       
            ///<summary>単価印字する</summary>
            On                                  = 0,       
            ///<summary>単価印字しない</summary>
            Off                                 = 1                     
        }

        /// <summary>
		/// 請求明細金額０印字区分
		/// </summary>
        private enum DemandPriceZeroPrintDiv
        {       
            ///<summary>印字する</summary>
            On                                  = 0,       
            ///<summary>全て０のみ印字しない</summary>
            AllZeroTimeOff                      = 1,
            ///<summary>相殺額が０の時印字しない</summary>
            AfterPriceZeroTimeOff               = 2,
                     
        }

        /// <summary>
		/// 印字区分
		/// </summary>
        private enum PrintDiv
        {       
            ///<summary>印字する</summary>
            On                                  = 0,       
            ///<summary>印字しない</summary>
            Off                                 = 1                     
        }

        /// <summary>
		/// マイナス請求時印刷区分
		/// </summary>
        private enum MinusDemandPrintDiv
        {       
            ///<summary>支払通知書とする</summary>
            PayNoticeList                        = 0,       
            ///<summary>マイナス請求書とする</summary>
            MinusDemandList                      = 1                     
        }

        /// <summary>
		/// 機種別インセンティブ出力区分
		/// </summary>
        private enum CellphoneIncOutputDiv
        {       
            ///<summary>集計印字</summary>
            TotalPrint                              = 0,       
            ///<summary>機種別印字請求書とする</summary>
            Cellphone                               = 1                     
        }

        // --- ADD 2008/06/18 -------------------------------->>>>>
        /// <summary>
        /// 請求明細摘要区分
        /// </summary>
        private enum DmdDtlOutlineCode
        {
            Off = 0,
            GoosNo = 1,
            FixedPrice = 2
        }

        /// <summary>
        /// 請求明細書印字順位区分
        /// </summary>
        private enum DmdDtlPtnOdrDiv
        {
            Pattern1 = 0,
            // --- ADD  大矢睦美  2010/06/15 ---------->>>>>
            //Pattern2 = 1
            Pattern2 = 1,
            Pattern3 = 2,
            Pattern4 = 3
            // --- ADD  大矢睦美  2010/06/15 ----------<<<<<
        }

        /// <summary>
        /// 入金明細印字有無区分
        /// </summary>
        private enum DepoDtlPrcPrtDiv
        {
            Off = 0,
            Total = 1,
            Detail = 2
        }
        // --- ADD 2008/06/18 --------------------------------<<<<< 
        #endregion

        #region IMasterMaintenanceMultiType実装部

        #region PrivateMember

        // プロパティ用
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private bool _canSpecificationSearch;
        //private int _dataIndex;
        private bool _defaultAutoFillToColumn;

        // --- ADD 2008/06/18 -------------------------------->>>>>
        private int _mainDataIndex;
        private int _detailsDataIndex;
        private string _targetTableName;
        private MGridDisplayLayout _defaultGridDisplayLayout;
        // --- ADD 2008/06/18 --------------------------------<<<<< 

        #endregion

        #region PrivateConst

        // View用Gridに表示させるテーブル名
        private const string VIEWLEFT_TABLE = "VIEWLEFT_TABLE";
        private const string VIEWRIGHT_TABLE = "VIEWRIGHT_TABLE";
        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        #endregion

        #region Events
        /*----------------------------------------------------------------------------------*/
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region Properties
        /*----------------------------------------------------------------------------------*/
        /// <summary>印刷可能設定プロパティ</summary>
        /// <value>印刷可能かどうかの設定を取得します。</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>論理削除データ抽出可能設定プロパティ</summary>
        /// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>画面終了設定プロパティ</summary>
        /// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
        /// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>新規登録可能設定プロパティ</summary>
        /// <value>新規登録が可能かどうかの設定を取得します。</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>削除可能設定プロパティ</summary>
        /// <value>削除が可能かどうかの設定を取得します。</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /*----------------------------------------------------------------------------------*/
        ///// <summary>データセットの選択データインデックスプロパティ</summary>
        ///// <value>データセットの選択データインデックスを取得または設定します。</value>
        //public int DataIndex
        //{
        //    get
        //    {
        //        return this._dataIndex;
        //    }
        //    set
        //    {
        //        this._dataIndex = value;
        //    }
        //}

        /*----------------------------------------------------------------------------------*/
        /// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
        /// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>件数指定抽出可能設定プロパティ</summary>
        /// <value>件数指定抽出を可能とするかどうかの設定を取得します。</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }

        /// <summary>グリッドのデフォルト表示位置プロパティ</summary>
        /// <value>グリッドのデフォルト表示位置を取得します。</value>
        public MGridDisplayLayout DefaultGridDisplayLayout
        {
            get { return this._defaultGridDisplayLayout; }
        }

        /// <summary>操作対象データテーブル名称プロパティ</summary>
        /// <value>捜査対象データのテーブル名称を取得または設定します。</value>
        public string TargetTableName
        {
            get { return this._targetTableName; }
            set { this._targetTableName = value; }
        }
        #endregion

        #region Public Method

        /// <summary>
        /// 論理削除データ抽出可能設定リスト取得処理
        /// </summary>
        /// <returns>論理削除データ抽出可能設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public bool[] GetCanLogicalDeleteDataExtractionList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;    // MOD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御 false→true
            blRet[1] = false;   // MOD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御 true→false
            return blRet;
        }

        /// <summary>
        /// グリッドタイトルリスト取得処理
        /// </summary>
        /// <returns>グリッドタイトルリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public string[] GetGridTitleList()
        {
            string[] strRet = new string[2];
            strRet[0] = GRIDTITLE_PRINTKIND;     // 印刷種別 
            strRet[1] = GRIDTITLE_PRINTPATTERN;  // 印刷パターン
            return strRet;
        }

        /// <summary>
        /// グリッドアイコンリスト取得処理
        /// </summary>
        /// <returns>グリッドアイコンリスト</returns>
        /// <remarks>
        /// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public Image[] GetGridIconList()
        {
            Image[] objRet = new Image[2];
            objRet[0] = null;
            objRet[1] = null;
            return objRet;
        }

        /// <summary>
        /// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
        /// </summary>
        /// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
        /// <remarks>
        /// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public bool[] GetDefaultAutoFillToGridColumnList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = true;
            blRet[1] = false;
            return blRet;
        }

        /// <summary>
        /// データテーブルの選択データインデックスリスト設定処理
        /// </summary>
        /// <param name="indexList">データテーブルの選択データインデックスリスト</param>
        /// <remarks>
        /// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public void SetDataIndexList(int[] indexList)
        {
            int[] intVal = indexList;
            this._mainDataIndex = intVal[0];
            this._detailsDataIndex = intVal[1];
        }

        /// <summary>
        /// 新規ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>新規ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public bool[] GetNewButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = false;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// 修正ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>修正ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public bool[] GetModifyButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = false;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// 削除ボタンの有効設定リスト取得処理
        /// </summary>
        /// <returns>削除ボタンの有効設定リスト</returns>
        /// <remarks>
        /// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public bool[] GetDeleteButtonEnabledList()
        {
            bool[] blRet = new bool[2];
            blRet[0] = false;
            blRet[1] = true;
            return blRet;
        }

        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッド表示用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        /// 
        public void GetBindDataSet(ref DataSet bindDataSet, ref string[] tableName)
        {
            // グリッド表示用データセットを設定
            bindDataSet = this.Bind_DataSet;

            // ２つのテーブル名称の設定
            string[] strRet = new string[2];
            strRet[0] = VIEWLEFT_TABLE;
            strRet[1] = VIEWRIGHT_TABLE;
            tableName = strRet;
        }

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        /// <summary>
        /// バインドデータセット取得処理
        /// </summary>
        /// <param name="bindDataSet">グリッドリッド用データセット</param>
        /// <param name="tableName">テーブル名称</param>
        /// <remarks>
        /// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }
           --- DEL 2008/06/18 --------------------------------<<<<< */

        /// <summary>
        /// 明細データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int DetailsDataSearch(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList arrRightList = new ArrayList();

            // 現在保持しているデータをクリアする
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows.Clear();
            this._dmdPrtPtnRightTable.Clear();

            // ADD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
            // readCountが負の場合、強制終了
            if (readCount < 0) return 0;
            // ADD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

            // 選択されているデータを取得する
            int intPrintKind = (int)this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[this._mainDataIndex][VIEW_SLIPPRTKINDID];

            // 検索処理（論理削除含む）
            status = this._dmdPrtPtnAcs.SearchAllPrintKindGroup(out arrRightList, this._enterpriseCode, intPrintKind);

            // 検索結果をキャッシュ
            CacheDmdPrtPtnList(intPrintKind, arrRightList); // ADD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御

            this._totalCount = arrRightList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 削除日を設定
                        SetViewLeftDelateDate();    // ADD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御

                        // 取得したクラスをデータセットへ展開する
                        int index = 0;
                        foreach (DmdPrtPtn dmdPrtPtn in arrRightList)
                        {
                            // クラスデータセット展開処理
                            DmdPrtPtnToDataSet(dmdPrtPtn.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                default:
                    {
                        // 明細データ検索処理
                        TMsgDisp.Show(
                            this, 								        // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		        // エラーレベル
                            "MAKAU09150U", 						        // アセンブリＩＤまたはクラスＩＤ
                            "請求書印刷パターン設定",        			// プログラム名称
                            "DetailsDataSearch", 				        // 処理名称
                            TMsgDisp.OPE_GET, 					        // オペレーション
                            "読み込みに失敗しました。",	                // 表示するメッセージ
                            status, 							        // ステータス値
                            this._dmdPrtPtnAcs, 				        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				        // 表示するボタン
                            MessageBoxDefaultButton.Button1);	        // 初期表示ボタン

                        break;
                    }
            }

            totalCount = this._totalCount;

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ検索処理
        /// </summary>
        /// <param name="totalCount">全該当件数</param>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            #region 削除コード
            /* --- DEL 2008/06/18 -------------------------------->>>>>
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            ArrayList dmdPrtPtnList = null;

            if (readCount == 0)
            {
                //排他処理の為、協定料金主作業、区分、明細のレコードも同時に取得します。
                // 抽出対象件数が0の場合は全件抽出を実行する
                status = this._dmdPrtPtnAcs.SearchAll(out dmdPrtPtnList,this._enterpriseCode);
                this._totalCount = dmdPrtPtnList.Count;
            }          
            else
            {
               //件数指定がある場合実装
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {                           
                        int index = 0;                                                                   
                        // 読み込んだインスタンスのそれぞれをデータセットに展開
                        foreach (DmdPrtPtn dmdPrtPtn in dmdPrtPtnList)
                        {                                   						    
                            DmdPrtPtnToDataSet(dmdPrtPtn.Clone(), index);
                            ++index;                   						                                      
                        }                                         
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 全件読み込み完了の場合は、何もしない
                        break;
                    }
                default:
                    {
                      
                        // サーチ
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                            "請求書印刷パターン設定", 			// プログラム名称
                            "Search", 							// 処理名称
                            TMsgDisp.OPE_GET, 					// オペレーション
                            "読み込みに失敗しました。", 		// 表示するメッセージ
                            status, 							// ステータス値
                            this._dmdPrtPtnAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
  
                        break;
                    }
            }

            totalCount = this._totalCount;

            return status;
               --- DEL 2008/06/18 --------------------------------<<<<< */
            #endregion  // 削除コード

            // --- ADD 2008/06/18 -------------------------------->>>>>
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // 削除日を設定
            DataRow dataRow = this.Bind_DataSet.Tables[VIEWLEFT_TABLE].NewRow();
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows.Add(dataRow);
            // ADD 2009/03/24 不具合対応[12689]↓：「削除済データの表示」は最上位項目で制御
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[0][VIEW_DELETE_DATE] = GetDeleteDate(SLIPPRTKINDID_TOTAL);
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[0][VIEW_SLIPPRTKIND] = SLIPPRTKIND_TOTAL;
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[0][VIEW_SLIPPRTKINDID] = SLIPPRTKINDID_TOTAL;

            dataRow = this.Bind_DataSet.Tables[VIEWLEFT_TABLE].NewRow();
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows.Add(dataRow);
            // ADD 2009/03/24 不具合対応[12689]↓：「削除済データの表示」は最上位項目で制御
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[1][VIEW_DELETE_DATE] = GetDeleteDate(SLIPPRTKINDID_DETAIL);  
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[1][VIEW_SLIPPRTKIND] = SLIPPRTKIND_DETAIL;
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[1][VIEW_SLIPPRTKINDID] = SLIPPRTKINDID_DETAIL;

            dataRow = this.Bind_DataSet.Tables[VIEWLEFT_TABLE].NewRow();
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows.Add(dataRow);
            // ADD 2009/03/24 不具合対応[12689]↓：「削除済データの表示」は最上位項目で制御
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[2][VIEW_DELETE_DATE] = GetDeleteDate(SLIPPRTKINDID_SLIP);
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[2][VIEW_SLIPPRTKIND] = SLIPPRTKIND_SLIP;
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[2][VIEW_SLIPPRTKINDID] = SLIPPRTKINDID_SLIP;

            dataRow = this.Bind_DataSet.Tables[VIEWLEFT_TABLE].NewRow();
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows.Add(dataRow);
            // ADD 2009/03/24 不具合対応[12689]↓：「削除済データの表示」は最上位項目で制御
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[3][VIEW_DELETE_DATE] = GetDeleteDate(SLIPPRTKINDID_RECEIPT);
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[3][VIEW_SLIPPRTKIND] = SLIPPRTKIND_RECEIPT;
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[3][VIEW_SLIPPRTKINDID] = SLIPPRTKINDID_RECEIPT;

            totalCount = 4;

            return status;
            // --- ADD 2008/06/18 --------------------------------<<<<< 
        }

        // ADD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御 ---------->>>>>
        #region <印刷パターンのキャッシュ/>

        /// <summary>印刷パターンのキャッシュ</summary>
        /// <remarks>キー：印刷種別ID</remarks>
        private readonly IDictionary<int, ArrayList> _dmdPrtPtnListCacheMap = new Dictionary<int, ArrayList>();
        /// <summary>
        /// 印刷パターンのキャッシュを取得します。
        /// </summary>
        private IDictionary<int, ArrayList> DmdPrtPtnListCacheMap
        {
            get { return _dmdPrtPtnListCacheMap; }
        }

        /// <summary>
        /// 印刷パターンのレコードリストを保持します。
        /// </summary>
        /// <param name="slipPrtKindId">印刷種別ID</param>
        /// <param name="dmdPrtPtnList">印刷パターンのレコードリスト</param>
        private void CacheDmdPrtPtnList(
            int slipPrtKindId,
            ArrayList dmdPrtPtnList
        )
        {
            if (DmdPrtPtnListCacheMap.ContainsKey(slipPrtKindId))
            {
                DmdPrtPtnListCacheMap.Remove(slipPrtKindId);
            }
            DmdPrtPtnListCacheMap.Add(slipPrtKindId, (dmdPrtPtnList != null ? dmdPrtPtnList : new ArrayList()));
        }

        #endregion  // <印刷パターンのキャッシュ/>

        /// <summary>
        /// メインテーブルの削除日を取得します。
        /// </summary>
        /// <param name="slipPrtKindId">印刷種別ID</param>
        /// <returns>削除日（削除されたレコードが無い場合、<c>string.Empty</c>を返します。）</returns>
        private string GetDeleteDate(int slipPrtKindId)
        {
            // 対応するサブレコードを全件取得
            ArrayList dmdPrtPtnList = null;
            if (DmdPrtPtnListCacheMap.ContainsKey(slipPrtKindId))
            {
                dmdPrtPtnList = DmdPrtPtnListCacheMap[slipPrtKindId];
            }
            else
            {
                int status = this._dmdPrtPtnAcs.SearchAllPrintKindGroup(
                    out dmdPrtPtnList,
                    this._enterpriseCode,
                    slipPrtKindId
                );
                CacheDmdPrtPtnList(slipPrtKindId, dmdPrtPtnList);
            }
            if (dmdPrtPtnList == null || dmdPrtPtnList.Count.Equals(0)) return string.Empty;

            // 削除日を降順で抽出
            int deletedRecordCount = 0;
            SortedList<DateTime, DmdPrtPtn> deletedRecordList = new SortedList<DateTime, DmdPrtPtn>(
                new DateTimeUtil.ReverseComparer()
            );
            foreach (DmdPrtPtn dmdPrtPtn in dmdPrtPtnList)
            {
                if (dmdPrtPtn.LogicalDeleteCode.Equals(0)) continue;

                deletedRecordCount++;
                if (!deletedRecordList.ContainsKey(dmdPrtPtn.UpdateDateTime))
                {
                    deletedRecordList.Add(dmdPrtPtn.UpdateDateTime, dmdPrtPtn);
                }
            }

            // サブレコードが全件削除されている場合
            string deleteDate = string.Empty;
            if (deletedRecordCount > 0 && deletedRecordCount.Equals(dmdPrtPtnList.Count))
            {
                deleteDate = deletedRecordList.Values[0].UpdateDateTimeJpInFormal;
            }
            return deleteDate;
        }

        /// <summary>
        /// メインテーブルの削除日を設定します。
        /// </summary>
        private void SetViewLeftDelateDate()
        {
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[0][VIEW_DELETE_DATE] = GetDeleteDate(SLIPPRTKINDID_TOTAL);
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[1][VIEW_DELETE_DATE] = GetDeleteDate(SLIPPRTKINDID_DETAIL);
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[2][VIEW_DELETE_DATE] = GetDeleteDate(SLIPPRTKINDID_SLIP);
            this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[3][VIEW_DELETE_DATE] = GetDeleteDate(SLIPPRTKINDID_RECEIPT);
        }
        // ADD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御 ----------<<<<<

        /// <summary>
        /// 明細ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        public int DetailsDataSearchNext(int readCount)
        {
            int status = 0;
            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        public int SearchNext(int readCount)
        {      
            int status = 0;
            return status;
        }

         /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        public int Delete()
        {
            /* --- DEL 2008/06/18 -------------------------------->>>>>
            // ①選択中のデータの取得
            // DataSetからGUIDを取得
            int demantPatrnNo = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_DEMANDPTNNO];
            // GUIDでインスタンステーブルから該当インスタンスを取得
            DmdPrtPtn dmdPrtPtn = (DmdPrtPtn)this._dmdPrtPtnTable[demantPatrnNo];
         
            // ②論理削除フラグを立てる
            int status = this._dmdPrtPtnAcs.LogicalDelete(ref dmdPrtPtn);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {                        
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                            "請求書印刷パターン設定", 			// プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._dmdPrtPtnAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                   
                        return status;
                    }
            }
            // ④読み込んだインスタンスをDataSetにセット(することで、グリッドに反映させる)
            DmdPrtPtnToDataSet(dmdPrtPtn, this._dataIndex);

            return status;
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // --- ADD 2008/06/18 -------------------------------->>>>>
            int status = 0;

            if ((this._detailsDataIndex < 0) ||
                (this._detailsDataIndex >= this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows.Count))
            {
                return -1;
            }

            // 情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[this._detailsDataIndex][VIEW_FILEHEADERGUID];
            DmdPrtPtn dmdPrtPtn = ((DmdPrtPtn)this._dmdPrtPtnRightTable[guid]).Clone();

            // 請求書印刷パターン設定が存在していない
            if (dmdPrtPtn == null)
            {
                return -1;
            }

            status = this._dmdPrtPtnAcs.LogicalDelete(ref dmdPrtPtn);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        DmdPrtPtnToDataSet(dmdPrtPtn.Clone(), this._detailsDataIndex);
                        break;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                            "請求書印刷パターン設定", 			// プログラム名称
                            "LogicalDelete", 					// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._dmdPrtPtnAcs,			        // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return status;
                    }
            }

            return status;
            // --- ADD 2008/06/18 --------------------------------<<<<< 
        }
      
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// グリッド列外観情報取得処理
        /// </summary>
        /// <returns>グリッド列外観情報格納Hashtable</returns>
        /// <remarks>
        /// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// <br>Update Note: 2011/02/16 施ヘイ中</br>
        /// <br>Date       : 自社名印字区分を追加</br>
        /// </remarks>
        //public Hashtable GetAppearanceTable()
        public void GetAppearanceTable(out Hashtable[] appearanceTable)
        {
            //Hashtable appearanceTable = new Hashtable();       // DEL 2008/06/18
            Hashtable mainAppearanceTable = new Hashtable();     // メイングリッド
            Hashtable detailsAppearanceTable = new Hashtable();  // サブグリッド

            //_/_/_/_/_/_/ メイングリッド項目設定 _/_/_/_/_/_/
            mainAppearanceTable.Add(VIEW_DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));    // ADD 2009/03/24 不具合対応[12689]：「削除済データの表示」は最上位項目で制御
            mainAppearanceTable.Add(VIEW_SLIPPRTKIND, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            mainAppearanceTable.Add(VIEW_SLIPPRTKINDID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //_/_/_/_/_/_/ サブグリッド項目設定 _/_/_/_/_/_/
            //削除日
            detailsAppearanceTable.Add(VIEW_DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            //請求書パターン番号
            appearanceTable.Add(VIEW_DEMANDPTNNO, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //請求書パターン名称
            appearanceTable.Add(VIEW_DEMANDPTNNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));      
               --- DEL 2008/06/18 --------------------------------<<<<< */

            //請求書タイトル  
            detailsAppearanceTable.Add(VIEW_DMDFORMTITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            //支払通知書タイトル
            //appearanceTable.Add(VIEW_PAYMENTFORMTITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));  // DEL 2008/06/18
            
            //請求 鑑設定項目区分１
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求 鑑設定項目区分１(名称)
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV1NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑設定項目区分２
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求 鑑設定項目区分２(名称)
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV2NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑設定項目区分３
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV3, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求 鑑設定項目区分３(名称)
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV3NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑設定項目区分４
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV4, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求 鑑設定項目区分４(名称)
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV4NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑設定項目区分５
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV5, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求 鑑設定項目区分５(名称)
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV5NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑設定項目区分６
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV6, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求 鑑設定項目区分６(名称)
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV6NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑設定項目区分７
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV7, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求 鑑設定項目区分７(名称)
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV7NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑設定項目区分８
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV8, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求 鑑設定項目区分８(名称)
            detailsAppearanceTable.Add(VIEW_DMDTTLSETITEMDIV8NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //請求 鑑タイトル１
            detailsAppearanceTable.Add(VIEW_DMDTTLFORMTITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑タイトル２
            detailsAppearanceTable.Add(VIEW_DMDTTLFORMTITLE2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑タイトル３
            detailsAppearanceTable.Add(VIEW_DMDTTLFORMTITLE3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑タイトル４
            detailsAppearanceTable.Add(VIEW_DMDTTLFORMTITLE4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑タイトル５
            detailsAppearanceTable.Add(VIEW_DMDTTLFORMTITLE5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑タイトル６
            detailsAppearanceTable.Add(VIEW_DMDTTLFORMTITLE6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑タイトル７
            detailsAppearanceTable.Add(VIEW_DMDTTLFORMTITLE7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求 鑑タイトル８
            detailsAppearanceTable.Add(VIEW_DMDTTLFORMTITLE8, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            //支払 鑑タイトル１  
            appearanceTable.Add(VIEW_PAYTTLFORMTITLE1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払 鑑タイトル２  
            appearanceTable.Add(VIEW_PAYTTLFORMTITLE2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払 鑑タイトル３  
            appearanceTable.Add(VIEW_PAYTTLFORMTITLE3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払 鑑タイトル４  
            appearanceTable.Add(VIEW_PAYTTLFORMTITLE4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払 鑑タイトル５  
            appearanceTable.Add(VIEW_PAYTTLFORMTITLE5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払 鑑タイトル６  
            appearanceTable.Add(VIEW_PAYTTLFORMTITLE6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払 鑑タイトル７  
            appearanceTable.Add(VIEW_PAYTTLFORMTITLE7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払 鑑タイトル８  
            appearanceTable.Add(VIEW_PAYTTLFORMTITLE8, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
               --- DEL 2008/06/18 --------------------------------<<<<< */

            //請求書コメント１ 
            detailsAppearanceTable.Add(VIEW_DMDFORMCOMENT1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求書コメント２ 
            detailsAppearanceTable.Add(VIEW_DMDFORMCOMENT2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求書コメント３ 
            detailsAppearanceTable.Add(VIEW_DMDFORMCOMENT3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            //請求書請求集計分類１ 
            appearanceTable.Add(VIEW_DMDFMDMDTTLGENCD1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求書請求集計分類２     
            appearanceTable.Add(VIEW_DMDFMDMDTTLGENCD2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求書請求集計分類３   
            appearanceTable.Add(VIEW_DMDFMDMDTTLGENCD3, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求書支払集計分類１ 
            appearanceTable.Add(VIEW_DMDFMPAYTTLGENCD1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求書支払集計分類２     
            appearanceTable.Add(VIEW_DMDFMPAYTTLGENCD2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求書支払集計分類３   
            appearanceTable.Add(VIEW_DMDFMPAYTTLGENCD3, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            //請求書請求集計分類１(名称) 
            appearanceTable.Add(VIEW_DMDFMDMDTTLGENCD1NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求書請求集計分類２(名称)     
            appearanceTable.Add(VIEW_DMDFMDMDTTLGENCD2NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求書請求集計分類３(名称)   
            appearanceTable.Add(VIEW_DMDFMDMDTTLGENCD3NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求書支払集計分類１(名称) 
            appearanceTable.Add(VIEW_DMDFMPAYTTLGENCD1NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求書支払集計分類２(名称)     
            appearanceTable.Add(VIEW_DMDFMPAYTTLGENCD2NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求書支払集計分類３(名称)   
            appearanceTable.Add(VIEW_DMDFMPAYTTLGENCD3NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //請求書請求集計分類名称２ 
            appearanceTable.Add(VIEW_DMDFMDMDTTLGENNM2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求書請求集計分類名称３
            appearanceTable.Add(VIEW_DMDFMDMDTTLGENNM3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求集計分類デフォルト名称
            appearanceTable.Add(VIEW_DMDTTLGENDEFLTNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払集計分類デフォルト名称
            appearanceTable.Add(VIEW_PAYTTLGENDEFLTNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));   

            //請求明細単価別出力有無
            appearanceTable.Add(VIEW_DMDDTLUNITPRTDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //支払明細単価別出力有無
            appearanceTable.Add(VIEW_PAYDTLUNITPRTDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求明細金額ゼロ時印字有無
            appearanceTable.Add(VIEW_DMDDTLPRCZEROPRTDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //支払明細金額ゼロ時印字有無
            appearanceTable.Add(VIEW_PAYDTLPRCZEROPRTDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //今回請求額ゼロ時印字有無
            appearanceTable.Add(VIEW_THTMDMDZEROPRTDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //マイナス請求時印刷区分
            appearanceTable.Add(VIEW_MINUSDMDPRTDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //請求書入金集計明細印字区分
            appearanceTable.Add(VIEW_DMDFMDEPOTTLPRTDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            //機種別インセンティブ出力区分
            appearanceTable.Add(VIEW_CELLPHONEINCOUTDIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

             //請求明細単価別出力有無(名称)
            appearanceTable.Add(VIEW_DMDDTLUNITPRTDIVNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払明細単価別出力有無(名称)
            appearanceTable.Add(VIEW_PAYDTLUNITPRTDIVNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求明細金額ゼロ時印字有無(名称)
            appearanceTable.Add(VIEW_DMDDTLPRCZEROPRTDIVNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //支払明細金額ゼロ時印字有無(名称)
            appearanceTable.Add(VIEW_PAYDTLPRCZEROPRTDIVNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //今回請求額ゼロ時印字有無(名称)
            appearanceTable.Add(VIEW_THTMDMDZEROPRTDIVNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //マイナス請求時印刷区分(名称)
            appearanceTable.Add(VIEW_MINUSDMDPRTDIVNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //請求書入金集計明細印字区分(名称)
            appearanceTable.Add(VIEW_DMDFMDEPOTTLPRTDIVNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //機種別インセンティブ出力区分(名称)
            appearanceTable.Add(VIEW_CELLPHONEINCOUTDIVNM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //強制請求出力商品区分１
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分２
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分３
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD3, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分４
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD4, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分５
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD5, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分６
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD6, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分７
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD7, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分８
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD8, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分９
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD9, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分１０
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD10, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            //強制請求出力商品区分１
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD1NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分２
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD2NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分３
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD3NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分４
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD4NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分５
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD5NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分６
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD6NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分７
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD7NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分８
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD8NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分９
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD9NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制請求出力商品区分１０
            appearanceTable.Add(VIEW_CMPLDMDMDGOODSCD10NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            //強制支払出力商品区分１
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD1, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分２
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD2, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分３
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD3, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分４
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD4, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分５
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD5, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分６
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD6, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分７
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD7, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分８
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD8, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分９
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD9, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分１０
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD10, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));   

            //強制支払出力商品区分１
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD1NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分２
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD2NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分３
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD3NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分４
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD4NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分５
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD5NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分６
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD6NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分７
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD7NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分８
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD8NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分９
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD9NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //強制支払出力商品区分１０
            appearanceTable.Add(VIEW_CMPLPAYMDGOODSCD10NM, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));   
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
            // データ入力システム
            detailsAppearanceTable.Add(VIEW_DATAINPUTSYSTEM, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // 出力ファイル名
            detailsAppearanceTable.Add(VIEW_OUTPUTFILENAME, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            // 印刷帳票ID
            detailsAppearanceTable.Add(VIEW_SLIPPRTSETPAPERID, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
        
            // --- ADD 2008/06/18 -------------------------------->>>>>
            // パターン名称
            detailsAppearanceTable.Add(VIEW_SLIPCOMMENT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 得意先敬称
            detailsAppearanceTable.Add(VIEW_BILLHONORIFICTTL, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 複写枚数
            detailsAppearanceTable.Add(VIEW_COPYCOOUNT, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 上余白
            detailsAppearanceTable.Add(VIEW_TOPMARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 下余白
            detailsAppearanceTable.Add(VIEW_BOTTOMMARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 左余白
            detailsAppearanceTable.Add(VIEW_LEFTMARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 右余白
            detailsAppearanceTable.Add(VIEW_RIGHTMARGIN, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 請求書(控)タイトル
            detailsAppearanceTable.Add(VIEW_DMDFORMTITLE2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 印字順位
            detailsAppearanceTable.Add(VIEW_DMDDTLPTNODRDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            // 標準価格印字区分
            detailsAppearanceTable.Add(VIEW_LISTPRICEPRTCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 品番印字区分
            detailsAppearanceTable.Add(VIEW_PARTSNOPRTCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END
        
            // 請求明細摘要区分
            detailsAppearanceTable.Add(VIEW_DMDDTLOUTLINECODE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 明細金額ゼロ時
            detailsAppearanceTable.Add(VIEW_DTLPRCZEROPRTDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            //注釈印字区分
            detailsAppearanceTable.Add(VIEW_ANNOTATIONPRTCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            detailsAppearanceTable.Add(VIEW_CONMPRINTOUTCD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD  2011/02/16 ----------<<<<<
            
            // 入金明細
            detailsAppearanceTable.Add(VIEW_DEPODTLPRCPRTDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 伝票計
            detailsAppearanceTable.Add(VIEW_SLIPTTLPRTDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 計上日計
            detailsAppearanceTable.Add(VIEW_ADDDAYTTLPRTDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 得意先計
            detailsAppearanceTable.Add(VIEW_CUSTOMERTTLPRTDIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2008/06/18 --------------------------------<<<<<             

            //GUID
            detailsAppearanceTable.Add(VIEW_FILEHEADERGUID, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable = new Hashtable[2];
            appearanceTable[0] = mainAppearanceTable;
            appearanceTable[1] = detailsAppearanceTable;
        }

        #endregion

        #endregion
       
        #region PrivateMethod

        #region データセット列情報構築処理
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。
        ///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07.03</br>
        /// <br>Update Note: 2011/02/16 施ヘイ中</br>
        /// <br>Date       : 自社名印字区分を追加</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable leftDataTable = new DataTable(VIEWLEFT_TABLE);
            DataTable rightDataTable = new DataTable(VIEWRIGHT_TABLE);

            //_/_/_/_/_/_/ 左側グリッド _/_/_/_/_/_/
            // ADD 2009/03/24 不具合対応[12689]↓：「削除済データの表示」は最上位項目で制御
            leftDataTable.Columns.Add(VIEW_DELETE_DATE, typeof(string));     // 削除日
            leftDataTable.Columns.Add(VIEW_SLIPPRTKIND, typeof(string));   // 印刷種別
            leftDataTable.Columns.Add(VIEW_SLIPPRTKINDID, typeof(Int32));  // 印刷種別ID

            this.Bind_DataSet.Tables.Add(leftDataTable);

            //_/_/_/_/_/_/ 右側グリッド _/_/_/_/_/_/
            rightDataTable.Columns.Add(VIEW_DELETE_DATE, typeof(string));  //削除日

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            dmdPrtPtnDataTable.Columns.Add(VIEW_DEMANDPTNNO, typeof(Int32));  //請求書パターン番号
            dmdPrtPtnDataTable.Columns.Add(VIEW_DEMANDPTNNM, typeof(string));  //請求書パターン名称
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
            rightDataTable.Columns.Add(VIEW_DATAINPUTSYSTEM, typeof(string));   // データ入力システム
            rightDataTable.Columns.Add(VIEW_OUTPUTFILENAME, typeof(string));    // 出力ファイル名
            rightDataTable.Columns.Add(VIEW_SLIPPRTSETPAPERID, typeof(string)); // 印刷帳票ID
            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
            // --- ADD 2008/06/18 -------------------------------->>>>>
            rightDataTable.Columns.Add(VIEW_SLIPCOMMENT, typeof(string));       // パターン名称
            rightDataTable.Columns.Add(VIEW_BILLHONORIFICTTL, typeof(string));  // 得意先敬称
            rightDataTable.Columns.Add(VIEW_COPYCOOUNT, typeof(string));        // 複写枚数
            rightDataTable.Columns.Add(VIEW_TOPMARGIN, typeof(string));         // 上余白
            rightDataTable.Columns.Add(VIEW_BOTTOMMARGIN, typeof(string));      // 下余白
            rightDataTable.Columns.Add(VIEW_LEFTMARGIN, typeof(string));        // 左余白
            rightDataTable.Columns.Add(VIEW_RIGHTMARGIN, typeof(string));       // 右余白

            // --- ADD  2011/02/16 ---------->>>>>
            rightDataTable.Columns.Add(VIEW_CONMPRINTOUTCD, typeof(string));
            // --- ADD  2011/02/16 ----------<<<<<

            rightDataTable.Columns.Add(VIEW_DMDFORMTITLE, typeof(string));      // 請求書タイトル   
            rightDataTable.Columns.Add(VIEW_DMDFORMTITLE2, typeof(string));     // 請求書(控)タイトル
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            //dmdPrtPtnDataTable.Columns.Add(VIEW_PAYMENTFORMTITLE, typeof(string));  //支払通知書タイトル  // DEL 2008/06/18

            // DEL 2008/11/14 不具合対応[7858] ---------->>>>>
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV1, typeof(Int32));  //請求 鑑設定項目区分１
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV1NM, typeof(string));  //請求 鑑設定項目区分１(名称)
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV2, typeof(Int32));  //請求 鑑設定項目区分２
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV2NM, typeof(string));  //請求 鑑設定項目区分２(名称)
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV3, typeof(Int32));  //請求 鑑設定項目区分３
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV3NM, typeof(string));  //請求 鑑設定項目区分３(名称)
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV4, typeof(Int32));  //請求 鑑設定項目区分４
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV4NM, typeof(string));  //請求 鑑設定項目区分４(名称)
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV5, typeof(Int32));  //請求 鑑設定項目区分５
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV5NM, typeof(string));  //請求 鑑設定項目区分５(名称)
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV6, typeof(Int32));  //請求 鑑設定項目区分６
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV6NM, typeof(string));  //請求 鑑設定項目区分６(名称)
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV7, typeof(Int32));  //請求 鑑設定項目区分７
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV7NM, typeof(string));  //請求 鑑設定項目区分７(名称)
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV8, typeof(Int32));  //請求 鑑設定項目区分８
            //rightDataTable.Columns.Add(VIEW_DMDTTLSETITEMDIV8NM, typeof(string));  //請求 鑑設定項目区分８(名称)
            //rightDataTable.Columns.Add(VIEW_DMDTTLFORMTITLE1, typeof(string));  //請求 鑑タイトル１    
            //rightDataTable.Columns.Add(VIEW_DMDTTLFORMTITLE2, typeof(string));  //請求 鑑タイトル２    
            //rightDataTable.Columns.Add(VIEW_DMDTTLFORMTITLE3, typeof(string));  //請求 鑑タイトル３    
            //rightDataTable.Columns.Add(VIEW_DMDTTLFORMTITLE4, typeof(string));  //請求 鑑タイトル４    
            //rightDataTable.Columns.Add(VIEW_DMDTTLFORMTITLE5, typeof(string));  //請求 鑑タイトル５    
            //rightDataTable.Columns.Add(VIEW_DMDTTLFORMTITLE6, typeof(string));  //請求 鑑タイトル６    
            //rightDataTable.Columns.Add(VIEW_DMDTTLFORMTITLE7, typeof(string));  //請求 鑑タイトル７    
            //rightDataTable.Columns.Add(VIEW_DMDTTLFORMTITLE8, typeof(string));  //請求 鑑タイトル８ 
            // DEL 2008/11/14 不具合対応[7858] ----------<<<<<

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYTTLFORMTITLE1, typeof(string));  //支払 鑑タイトル１    
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYTTLFORMTITLE2, typeof(string));  //支払 鑑タイトル２    
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYTTLFORMTITLE3, typeof(string));  //支払 鑑タイトル３    
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYTTLFORMTITLE4, typeof(string));  //支払 鑑タイトル４    
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYTTLFORMTITLE5, typeof(string));  //支払 鑑タイトル５    
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYTTLFORMTITLE6, typeof(string));  //支払 鑑タイトル６    
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYTTLFORMTITLE7, typeof(string));  //支払 鑑タイトル７    
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYTTLFORMTITLE8, typeof(string));  //支払 鑑タイトル８  
               --- DEL 2008/06/18 --------------------------------<<<<< */

            rightDataTable.Columns.Add(VIEW_DMDFORMCOMENT1, typeof(string));  //請求書コメント１    
            rightDataTable.Columns.Add(VIEW_DMDFORMCOMENT2, typeof(string));  //請求書コメント２    
            rightDataTable.Columns.Add(VIEW_DMDFORMCOMENT3, typeof(string));  //請求書コメント３    

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDMDTTLGENCD1, typeof(Int32));  //請求書請求集計分類１
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDMDTTLGENCD1NM, typeof(string));  //請求書請求集計分類１(名称) 
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDMDTTLGENCD2, typeof(Int32));  //請求書請求集計分類２
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDMDTTLGENCD2NM, typeof(string));  //請求書請求集計分類２(名称) 
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDMDTTLGENCD3, typeof(Int32));  //請求書請求集計分類３
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDMDTTLGENCD3NM, typeof(string));  //請求書請求集計分類３(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMPAYTTLGENCD1, typeof(Int32));  //請求書支払集計分類１
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMPAYTTLGENCD1NM, typeof(string));  //請求書支払集計分類１(名称) 
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMPAYTTLGENCD2, typeof(Int32));  //請求書支払集計分類２
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMPAYTTLGENCD2NM, typeof(string));  //請求書支払集計分類２(名称) 
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMPAYTTLGENCD3, typeof(Int32));  //請求書支払集計分類３
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMPAYTTLGENCD3NM, typeof(string));  //請求書支払集計分類３(名称) 
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDMDTTLGENNM2, typeof(string));  //請求書請求集計分類名称２    
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDMDTTLGENNM3, typeof(string));  //請求書請求集計分類名称３    
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDTTLGENDEFLTNM, typeof(string));  //請求集計分類デフォルト名称    
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYTTLGENDEFLTNM, typeof(string));  //支払集計分類デフォルト名称    
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDDTLUNITPRTDIV, typeof(Int32));  //請求明細単価別出力有無
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDDTLUNITPRTDIVNM, typeof(string));  //請求明細単価別出力有無(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYDTLUNITPRTDIV, typeof(Int32));  //支払明細単価別出力有無
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYDTLUNITPRTDIVNM, typeof(string));  //支払明細単価別出力有無(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDDTLPRCZEROPRTDIV, typeof(Int32));  //請求明細金額ゼロ時印字有無
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDDTLPRCZEROPRTDIVNM, typeof(string));  //請求明細金額ゼロ時印字有無(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYDTLPRCZEROPRTDIV, typeof(Int32));  //支払明細金額ゼロ時印字有無
            dmdPrtPtnDataTable.Columns.Add(VIEW_PAYDTLPRCZEROPRTDIVNM, typeof(string));  //支払明細金額ゼロ時印字有無(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_THTMDMDZEROPRTDIV, typeof(Int32));  //今回請求額ゼロ時印字有無
            dmdPrtPtnDataTable.Columns.Add(VIEW_THTMDMDZEROPRTDIVNM, typeof(string));  //今回請求額ゼロ時印字有無(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_MINUSDMDPRTDIV, typeof(Int32));  //マイナス請求時印刷区分
            dmdPrtPtnDataTable.Columns.Add(VIEW_MINUSDMDPRTDIVNM, typeof(string));  //マイナス請求時印刷区分(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDEPOTTLPRTDIV, typeof(Int32));  //請求書入金集計明細印字区分
            dmdPrtPtnDataTable.Columns.Add(VIEW_DMDFMDEPOTTLPRTDIVNM, typeof(string));  //請求書入金集計明細印字区分(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CELLPHONEINCOUTDIV, typeof(Int32));  //機種別インセンティブ出力区分
            dmdPrtPtnDataTable.Columns.Add(VIEW_CELLPHONEINCOUTDIVNM, typeof(string));  //機種別インセンティブ出力区分(名称)

            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD1, typeof(string));  //強制請求出力商品区分１
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD1NM, typeof(string));  //強制請求出力商品区分１(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD2, typeof(string));  //強制請求出力商品区分２
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD2NM, typeof(string));  //強制請求出力商品区分２(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD3, typeof(string));  //強制請求出力商品区分３
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD3NM, typeof(string));  //強制請求出力商品区分３(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD4, typeof(string));  //強制請求出力商品区分４
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD4NM, typeof(string));  //強制請求出力商品区分４(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD5, typeof(string));  //強制請求出力商品区分５
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD5NM, typeof(string));  //強制請求出力商品区分５(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD6, typeof(string));  //強制請求出力商品区分６
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD6NM, typeof(string));  //強制請求出力商品区分６(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD7, typeof(string));  //強制請求出力商品区分７
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD7NM, typeof(string));  //強制請求出力商品区分７(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD8, typeof(string));  //強制請求出力商品区分８
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD8NM, typeof(string));  //強制請求出力商品区分８(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD9, typeof(string));  //強制請求出力商品区分９
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD9NM, typeof(string));  //強制請求出力商品区分９(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD10, typeof(string));  //強制請求出力商品区分１０
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLDMDMDGOODSCD10NM, typeof(string));  //強制請求出力商品区分１０(名称)

            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD1, typeof(string));  //強制支払出力商品区分１
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD1NM, typeof(string));  //強制支払出力商品区分１(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD2, typeof(string));  //強制支払出力商品区分２
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD2NM, typeof(string));  //強制支払出力商品区分２(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD3, typeof(string));  //強制支払出力商品区分３
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD3NM, typeof(string));  //強制支払出力商品区分３(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD4, typeof(string));  //強制支払出力商品区分４
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD4NM, typeof(string));  //強制支払出力商品区分４(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD5, typeof(string));  //強制支払出力商品区分５
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD5NM, typeof(string));  //強制支払出力商品区分５(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD6, typeof(string));  //強制支払出力商品区分６
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD6NM, typeof(string));  //強制支払出力商品区分６(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD7, typeof(string));  //強制支払出力商品区分７
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD7NM, typeof(string));  //強制支払出力商品区分７(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD8, typeof(string));  //強制支払出力商品区分８
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD8NM, typeof(string));  //強制支払出力商品区分８(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD9, typeof(string));  //強制支払出力商品区分９
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD9NM, typeof(string));  //強制支払出力商品区分９(名称)
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD10, typeof(string));  //強制支払出力商品区分１０
            dmdPrtPtnDataTable.Columns.Add(VIEW_CMPLPAYMDGOODSCD10NM, typeof(string));  //強制支払出力商品区分１０(名称)
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // --- ADD 2008/06/18 -------------------------------->>>>>
            rightDataTable.Columns.Add(VIEW_DMDDTLPTNODRDIV, typeof(string));    // 請求明細書印字順位区分

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            rightDataTable.Columns.Add(VIEW_LISTPRICEPRTCD, typeof(string));    // 標準価格印字区分
            rightDataTable.Columns.Add(VIEW_PARTSNOPRTCD, typeof(string));      // 品番印字区分
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END        

            rightDataTable.Columns.Add(VIEW_DMDDTLOUTLINECODE, typeof(string));  // 請求明細摘要区分
            rightDataTable.Columns.Add(VIEW_SLIPTTLPRTDIV, typeof(string));      // 伝票計印字有無
            rightDataTable.Columns.Add(VIEW_ADDDAYTTLPRTDIV, typeof(string));    // 計上日計印字有無
            rightDataTable.Columns.Add(VIEW_CUSTOMERTTLPRTDIV, typeof(string));  // 得意先計印字有無
            rightDataTable.Columns.Add(VIEW_DTLPRCZEROPRTDIV, typeof(string));   // 明細金額ゼロ時印字有無
            
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            rightDataTable.Columns.Add(VIEW_ANNOTATIONPRTCD, typeof(string));    //注釈印字区分
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<< 

            rightDataTable.Columns.Add(VIEW_DEPODTLPRCPRTDIV, typeof(string));   // 入金明細印字有無区分
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            rightDataTable.Columns.Add(VIEW_FILEHEADERGUID, typeof(Guid));   //GUID

            this.Bind_DataSet.Tables.Add(rightDataTable);
        }

        #endregion

        #region 画面クリア処理
        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private void ScreenClear()
        {
            //初期選択設定(Tcomb)
            SetItemDefaultSelectSetting();

            //初期化
            DmFormTitle_tEdit.Clear();

            //PaymentFormTitle_tEdit.Clear();  // DEL 2008/06/18

            // DEL 2008/11/14 不具合対応[7858] ---------->>>>>
            //DmdTtlFormTitle1_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv1_tComb.Value);
            //DmdTtlFormTitle2_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv2_tComb.Value);
            //DmdTtlFormTitle3_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv3_tComb.Value);
            //DmdTtlFormTitle4_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv4_tComb.Value);
            //DmdTtlFormTitle5_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv5_tComb.Value);
            //DmdTtlFormTitle6_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv6_tComb.Value);
            //DmdTtlFormTitle7_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv7_tComb.Value);
            //DmdTtlFormTitle8_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv8_tComb.Value);
            // DEL 2008/11/14 不具合対応[7858] ----------<<<<<

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            PayTtlFormTitle1_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv1_tComb.Value);
            PayTtlFormTitle2_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv2_tComb.Value);
            PayTtlFormTitle3_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv3_tComb.Value);
            PayTtlFormTitle4_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv4_tComb.Value);
            PayTtlFormTitle5_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv5_tComb.Value);
            PayTtlFormTitle6_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv6_tComb.Value);
            PayTtlFormTitle7_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv7_tComb.Value);
            PayTtlFormTitle8_tEdit.DataText = GetSetItemDivNm((int)DmdTtlSetItemDiv8_tComb.Value);    
               --- DEL 2008/06/18 --------------------------------<<<<< */

            DmdFormComents1_tEdit.Clear();
            DmdFormComents2_tEdit.Clear();
            DmdFormComents3_tEdit.Clear();

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            DmdFmDmdTtlGenNm2_tEdit.DataText = GetDmdFmGenCdNm((int)DmdFmTtlGenCd2_tComb.Value);
            DmdFmDmdTtlGenNm3_tEdit.DataText = GetDmdFmGenCdNm((int)DmdFmTtlGenCd3_tComb.Value);        
            DmdTtlGenDefNm_tEdit.Clear();
            PayTtlGenDefNm_tEdit.Clear();
            CmplDmdMdGoodsCd1_tEdit.Clear();
            CmplDmdMdGoodsCd2_tEdit.Clear();
            CmplDmdMdGoodsCd3_tEdit.Clear();
            CmplDmdMdGoodsCd4_tEdit.Clear();
            CmplDmdMdGoodsCd5_tEdit.Clear();
            CmplDmdMdGoodsCd6_tEdit.Clear();
            CmplDmdMdGoodsCd7_tEdit.Clear();
            CmplDmdMdGoodsCd8_tEdit.Clear();
            CmplDmdMdGoodsCd9_tEdit.Clear();
            CmplDmdMdGoodsCd10_tEdit.Clear();
            CmplPayMdGoodsCd1_tEdit.Clear();
            CmplPayMdGoodsCd2_tEdit.Clear();
            CmplPayMdGoodsCd3_tEdit.Clear();
            CmplPayMdGoodsCd4_tEdit.Clear();
            CmplPayMdGoodsCd5_tEdit.Clear();
            CmplPayMdGoodsCd6_tEdit.Clear();
            CmplPayMdGoodsCd7_tEdit.Clear();
            CmplPayMdGoodsCd8_tEdit.Clear();
            CmplPayMdGoodsCd9_tEdit.Clear();
            CmplPayMdGoodsCd10_tEdit.Clear();
            CmplDmdMdGoodsNm1_tEdit.Clear();
            CmplDmdMdGoodsNm2_tEdit.Clear();
            CmplDmdMdGoodsNm3_tEdit.Clear();
            CmplDmdMdGoodsNm4_tEdit.Clear();
            CmplDmdMdGoodsNm5_tEdit.Clear();
            CmplDmdMdGoodsNm6_tEdit.Clear();
            CmplDmdMdGoodsNm7_tEdit.Clear();
            CmplDmdMdGoodsNm8_tEdit.Clear();
            CmplDmdMdGoodsNm9_tEdit.Clear();
            CmplDmdMdGoodsNm10_tEdit.Clear();
            CmplPayMdGoodsNm1_tEdit.Clear();
            CmplPayMdGoodsNm2_tEdit.Clear();
            CmplPayMdGoodsNm3_tEdit.Clear();
            CmplPayMdGoodsNm4_tEdit.Clear();
            CmplPayMdGoodsNm5_tEdit.Clear();
            CmplPayMdGoodsNm6_tEdit.Clear();
            CmplPayMdGoodsNm7_tEdit.Clear();
            CmplPayMdGoodsNm8_tEdit.Clear();
            CmplPayMdGoodsNm9_tEdit.Clear();
            CmplPayMdGoodsNm10_tEdit.Clear();
                 
            DemandPtnNo_tNedit.SetInt(0);
               --- DEL 2008/06/18 --------------------------------<<<<< */

            SlipComment_tEdit.Clear();

            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
            // 画面入力許可制御
            ScreenInputPermissionControl(true);
            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
        }

        #endregion

        #region 画面初期設定処理
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            int i;

            #region アイコン設定
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            //請求強制出力商品区分
            this.CmplDmdMdGoodsCd1_GuideButton.ImageList = imageList16;
            this.CmplDmdMdGoodsCd2_GuideButton.ImageList = imageList16;
            this.CmplDmdMdGoodsCd3_GuideButton.ImageList = imageList16;
            this.CmplDmdMdGoodsCd4_GuideButton.ImageList = imageList16;
            this.CmplDmdMdGoodsCd5_GuideButton.ImageList = imageList16;
            this.CmplDmdMdGoodsCd6_GuideButton.ImageList = imageList16;
            this.CmplDmdMdGoodsCd7_GuideButton.ImageList = imageList16;
            this.CmplDmdMdGoodsCd8_GuideButton.ImageList = imageList16;
            this.CmplDmdMdGoodsCd9_GuideButton.ImageList = imageList16;
            this.CmplDmdMdGoodsCd10_GuideButton.ImageList = imageList16;
            //支払強制出力商品区分
            this.CmplPayMdGoodsCd1_GuideButton.ImageList = imageList16;
            this.CmplPayMdGoodsCd2_GuideButton.ImageList = imageList16;
            this.CmplPayMdGoodsCd3_GuideButton.ImageList = imageList16;
            this.CmplPayMdGoodsCd4_GuideButton.ImageList = imageList16;
            this.CmplPayMdGoodsCd5_GuideButton.ImageList = imageList16;
            this.CmplPayMdGoodsCd6_GuideButton.ImageList = imageList16;
            this.CmplPayMdGoodsCd7_GuideButton.ImageList = imageList16;
            this.CmplPayMdGoodsCd8_GuideButton.ImageList = imageList16;
            this.CmplPayMdGoodsCd9_GuideButton.ImageList = imageList16;
            this.CmplPayMdGoodsCd10_GuideButton.ImageList = imageList16;
               --- DEL 2008/06/18 --------------------------------<<<<< */

            //イメージ設定
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            this.CmplDmdMdGoodsCd1_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplDmdMdGoodsCd2_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplDmdMdGoodsCd3_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplDmdMdGoodsCd4_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplDmdMdGoodsCd5_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplDmdMdGoodsCd6_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplDmdMdGoodsCd7_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplDmdMdGoodsCd8_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplDmdMdGoodsCd9_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplDmdMdGoodsCd10_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd1_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd2_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd3_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd4_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd5_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd6_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd7_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd8_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd9_GuideButton.Appearance.Image = Size16_Index.STAR1;
            this.CmplPayMdGoodsCd10_GuideButton.Appearance.Image = Size16_Index.STAR1;
               --- DEL 2008/06/18 --------------------------------<<<<< */

            #endregion

            #region TCombEidtor設定
            // --- ADD 2008/06/18 -------------------------------->>>>>
            // 印刷種別
            this.SlipPrtKind_tComboEditor.Items.Clear();
            this.SlipPrtKind_tComboEditor.Items.Add(SLIPPRTKINDID_TOTAL, SLIPPRTKIND_TOTAL);
            this.SlipPrtKind_tComboEditor.Items.Add(SLIPPRTKINDID_DETAIL, SLIPPRTKIND_DETAIL);
            this.SlipPrtKind_tComboEditor.Items.Add(SLIPPRTKINDID_SLIP, SLIPPRTKIND_SLIP);
            this.SlipPrtKind_tComboEditor.Items.Add(SLIPPRTKINDID_RECEIPT, SLIPPRTKIND_RECEIPT);
            this.SlipPrtKind_tComboEditor.MaxDropDownItems = this.SlipPrtKind_tComboEditor.Items.Count;

            // 複写枚数
            this.CopyCount_tComboEditor.Items.Clear();
            for (i=0;i < 10;i++ )
            {
                this.CopyCount_tComboEditor.Items.Add(i, i.ToString());
            }
            this.CopyCount_tComboEditor.MaxDropDownItems = this.CopyCount_tComboEditor.Items.Count;

            // 請求明細摘要区分
            this.DmdDtlOutlineCode_tComboEditor.Items.Clear();
            this.DmdDtlOutlineCode_tComboEditor.Items.Add(0, DMDDTLOOUTLINECODE_DIV0);
            this.DmdDtlOutlineCode_tComboEditor.Items.Add(1, DMDDTLOOUTLINECODE_DIV1);
            this.DmdDtlOutlineCode_tComboEditor.Items.Add(2, DMDDTLOOUTLINECODE_DIV2);
            this.DmdDtlOutlineCode_tComboEditor.MaxDropDownItems = this.DmdDtlOutlineCode_tComboEditor.Items.Count;

            // 請求明細書印字順位区分
            this.DmdDtlPtnOdrDiv_tComboEditor.Items.Clear();
            this.DmdDtlPtnOdrDiv_tComboEditor.Items.Add(0, DMDDTLPTNODR_DIV0);
            this.DmdDtlPtnOdrDiv_tComboEditor.Items.Add(1, DMDDTLPTNODR_DIV1);
            // --- ADD  大矢睦美  2010/06/15 ---------->>>>>
            this.DmdDtlPtnOdrDiv_tComboEditor.Items.Add(2, DMDDTLPTNODR_DIV2);
            this.DmdDtlPtnOdrDiv_tComboEditor.Items.Add(3, DMDDTLPTNODR_DIV3);
            // --- ADD  大矢睦美  2010/06/15----------<<<<<
            this.DmdDtlPtnOdrDiv_tComboEditor.MaxDropDownItems = this.DmdDtlPtnOdrDiv_tComboEditor.Items.Count;

            // 伝票計印字有無
            this.SlipTtlPrtDiv_tComboEditor.Items.Clear();
            this.SlipTtlPrtDiv_tComboEditor.Items.Add(0, PRINT_DIV0);
            this.SlipTtlPrtDiv_tComboEditor.Items.Add(1, PRINT_DIV1);
            this.SlipTtlPrtDiv_tComboEditor.MaxDropDownItems = this.SlipTtlPrtDiv_tComboEditor.Items.Count;

            // 計上日計印字有無
            this.AddDayTtlPrtDiv_tComboEditor.Items.Clear();
            this.AddDayTtlPrtDiv_tComboEditor.Items.Add(0, PRINT_DIV0);
            this.AddDayTtlPrtDiv_tComboEditor.Items.Add(1, PRINT_DIV1);
            this.AddDayTtlPrtDiv_tComboEditor.MaxDropDownItems = this.AddDayTtlPrtDiv_tComboEditor.Items.Count;

            // 得意先計印字有無
            this.CustomerTtlPrtDiv_tComboEditor.Items.Clear();
            this.CustomerTtlPrtDiv_tComboEditor.Items.Add(0, PRINT_DIV0);
            this.CustomerTtlPrtDiv_tComboEditor.Items.Add(1, PRINT_DIV1);
            this.CustomerTtlPrtDiv_tComboEditor.MaxDropDownItems = this.CustomerTtlPrtDiv_tComboEditor.Items.Count;

            // 明細金額ゼロ時印字有無
            this.DtlPrcZeroPrtDiv_tComboEditor.Items.Clear();
            this.DtlPrcZeroPrtDiv_tComboEditor.Items.Add(0, PRINT_DIV0);
            this.DtlPrcZeroPrtDiv_tComboEditor.Items.Add(1, PRINT_DIV1);
            this.DtlPrcZeroPrtDiv_tComboEditor.MaxDropDownItems = this.DtlPrcZeroPrtDiv_tComboEditor.Items.Count;

            // 入金明細印字有無区分
            this.DepoDtlPrcPrtDiv_tComboEditor.Items.Clear();
            this.DepoDtlPrcPrtDiv_tComboEditor.Items.Add(0, DEPODTLPRCPRT_DIV0);
            this.DepoDtlPrcPrtDiv_tComboEditor.Items.Add(1, DEPODTLPRCPRT_DIV1);
            this.DepoDtlPrcPrtDiv_tComboEditor.Items.Add(2, DEPODTLPRCPRT_DIV2);
            this.DepoDtlPrcPrtDiv_tComboEditor.MaxDropDownItems = this.DepoDtlPrcPrtDiv_tComboEditor.Items.Count;
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            // 標準価格印字区分
            this.ListPricePrtCd_tComboEditor.Items.Clear();
            this.ListPricePrtCd_tComboEditor.Items.Add(0, LISTPRICEPRTCD_DIV0);
            this.ListPricePrtCd_tComboEditor.Items.Add(1, LISTPRICEPRTCD_DIV1);
            this.ListPricePrtCd_tComboEditor.Items.Add(2, LISTPRICEPRTCD_DIV2);
            this.ListPricePrtCd_tComboEditor.MaxDropDownItems = this.ListPricePrtCd_tComboEditor.Items.Count;

            // 品番印字区分
            this.PartsNoPrtCd_tComboEditor.Items.Clear();
            this.PartsNoPrtCd_tComboEditor.Items.Add(0, PARTSNOPRTCD_DIV0);
            this.PartsNoPrtCd_tComboEditor.Items.Add(1, PARTSNOPRTCD_DIV1);
            this.PartsNoPrtCd_tComboEditor.MaxDropDownItems = this.PartsNoPrtCd_tComboEditor.Items.Count;
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END

            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            //注釈印字区分
            this.AnnotationPrtCd_tComboEditor.Items.Clear();
            this.AnnotationPrtCd_tComboEditor.Items.Add(0, ANNOTATIONPRTCD_DIV0);
            this.AnnotationPrtCd_tComboEditor.Items.Add(1, ANNOTATIONPRTCD_DIV1);
            this.AnnotationPrtCd_tComboEditor.MaxDropDownItems = this.PartsNoPrtCd_tComboEditor.Items.Count;
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            // 自社名印字区分
            this.CoNmPrintOutCd_tComboEditor.Items.Clear();
            this.CoNmPrintOutCd_tComboEditor.Items.Add(0, CONMPRINTOUTCD_DIV0);
            this.CoNmPrintOutCd_tComboEditor.Items.Add(1, CONMPRINTOUTCD_DIV1);
            this.CoNmPrintOutCd_tComboEditor.Items.Add(2, CONMPRINTOUTCD_DIV2);
            this.CoNmPrintOutCd_tComboEditor.Items.Add(3, CONMPRINTOUTCD_DIV3);
            this.CoNmPrintOutCd_tComboEditor.Items.Add(4, CONMPRINTOUTCD_DIV4);
            this.CoNmPrintOutCd_tComboEditor.MaxDropDownItems = this.CoNmPrintOutCd_tComboEditor.Items.Count;
            // --- ADD  2011/02/16 ----------<<<<<<

            // DEL 2008/11/14 不具合対応[7858] ---------->>>>>
            ////鑑設定項目区分
            //this.DmdTtlSetItemDiv1_tComb.Items.Clear();
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(0,DMDTTLSETITEM_DIV0);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(1,DMDTTLSETITEM_DIV1);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(2,DMDTTLSETITEM_DIV2);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(3,DMDTTLSETITEM_DIV3);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(4,DMDTTLSETITEM_DIV4);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(5,DMDTTLSETITEM_DIV5);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(6,DMDTTLSETITEM_DIV6);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(7,DMDTTLSETITEM_DIV7);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(8,DMDTTLSETITEM_DIV8);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(9,DMDTTLSETITEM_DIV9);
            //// 2007.07.12  S.Koga  ADD ----------------------------------------
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(10, DMDTTLSETITEM_DIV10);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(11, DMDTTLSETITEM_DIV11);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(12, DMDTTLSETITEM_DIV12);
            //this.DmdTtlSetItemDiv1_tComb.Items.Add(13, DMDTTLSETITEM_DIV13);
            //// ----------------------------------------------------------------
            //this.DmdTtlSetItemDiv1_tComb.MaxDropDownItems = this.DmdTtlSetItemDiv1_tComb.Items.Count;

            //this.DmdTtlSetItemDiv2_tComb.Items.Clear();
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(0,DMDTTLSETITEM_DIV0);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(1,DMDTTLSETITEM_DIV1);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(2,DMDTTLSETITEM_DIV2);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(3,DMDTTLSETITEM_DIV3);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(4,DMDTTLSETITEM_DIV4);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(5,DMDTTLSETITEM_DIV5);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(6,DMDTTLSETITEM_DIV6);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(7,DMDTTLSETITEM_DIV7);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(8,DMDTTLSETITEM_DIV8);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(9,DMDTTLSETITEM_DIV9);
            //// 2007.07.12  S.Koga  ADD ----------------------------------------
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(10, DMDTTLSETITEM_DIV10);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(11, DMDTTLSETITEM_DIV11);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(12, DMDTTLSETITEM_DIV12);
            //this.DmdTtlSetItemDiv2_tComb.Items.Add(13, DMDTTLSETITEM_DIV13);
            //// ----------------------------------------------------------------
            //this.DmdTtlSetItemDiv2_tComb.MaxDropDownItems = this.DmdTtlSetItemDiv2_tComb.Items.Count;

            //this.DmdTtlSetItemDiv3_tComb.Items.Clear();
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(0,DMDTTLSETITEM_DIV0);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(1,DMDTTLSETITEM_DIV1);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(2,DMDTTLSETITEM_DIV2);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(3,DMDTTLSETITEM_DIV3);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(4,DMDTTLSETITEM_DIV4);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(5,DMDTTLSETITEM_DIV5);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(6,DMDTTLSETITEM_DIV6);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(7,DMDTTLSETITEM_DIV7);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(8,DMDTTLSETITEM_DIV8);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(9,DMDTTLSETITEM_DIV9);
            //// 2007.07.12  S.Koga  ADD ----------------------------------------
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(10, DMDTTLSETITEM_DIV10);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(11, DMDTTLSETITEM_DIV11);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(12, DMDTTLSETITEM_DIV12);
            //this.DmdTtlSetItemDiv3_tComb.Items.Add(13, DMDTTLSETITEM_DIV13);
            //// ----------------------------------------------------------------
            //this.DmdTtlSetItemDiv3_tComb.MaxDropDownItems = this.DmdTtlSetItemDiv3_tComb.Items.Count;

            //this.DmdTtlSetItemDiv4_tComb.Items.Clear();
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(0,DMDTTLSETITEM_DIV0);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(1,DMDTTLSETITEM_DIV1);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(2,DMDTTLSETITEM_DIV2);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(3,DMDTTLSETITEM_DIV3);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(4,DMDTTLSETITEM_DIV4);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(5,DMDTTLSETITEM_DIV5);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(6,DMDTTLSETITEM_DIV6);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(7,DMDTTLSETITEM_DIV7);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(8,DMDTTLSETITEM_DIV8);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(9,DMDTTLSETITEM_DIV9);
            //// 2007.07.12  S.Koga  ADD ----------------------------------------
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(10, DMDTTLSETITEM_DIV10);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(11, DMDTTLSETITEM_DIV11);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(12, DMDTTLSETITEM_DIV12);
            //this.DmdTtlSetItemDiv4_tComb.Items.Add(13, DMDTTLSETITEM_DIV13);
            //// ----------------------------------------------------------------
            //this.DmdTtlSetItemDiv4_tComb.MaxDropDownItems = this.DmdTtlSetItemDiv4_tComb.Items.Count;

            //this.DmdTtlSetItemDiv5_tComb.Items.Clear();
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(0,DMDTTLSETITEM_DIV0);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(1,DMDTTLSETITEM_DIV1);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(2,DMDTTLSETITEM_DIV2);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(3,DMDTTLSETITEM_DIV3);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(4,DMDTTLSETITEM_DIV4);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(5,DMDTTLSETITEM_DIV5);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(6,DMDTTLSETITEM_DIV6);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(7,DMDTTLSETITEM_DIV7);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(8,DMDTTLSETITEM_DIV8);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(9,DMDTTLSETITEM_DIV9);
            //// 2007.07.12  S.Koga  ADD ----------------------------------------
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(10, DMDTTLSETITEM_DIV10);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(11, DMDTTLSETITEM_DIV11);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(12, DMDTTLSETITEM_DIV12);
            //this.DmdTtlSetItemDiv5_tComb.Items.Add(13, DMDTTLSETITEM_DIV13);
            //// ----------------------------------------------------------------
            //this.DmdTtlSetItemDiv5_tComb.MaxDropDownItems = this.DmdTtlSetItemDiv5_tComb.Items.Count;

            //this.DmdTtlSetItemDiv6_tComb.Items.Clear();
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(0,DMDTTLSETITEM_DIV0);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(1,DMDTTLSETITEM_DIV1);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(2,DMDTTLSETITEM_DIV2);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(3,DMDTTLSETITEM_DIV3);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(4,DMDTTLSETITEM_DIV4);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(5,DMDTTLSETITEM_DIV5);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(6,DMDTTLSETITEM_DIV6);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(7,DMDTTLSETITEM_DIV7);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(8,DMDTTLSETITEM_DIV8);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(9,DMDTTLSETITEM_DIV9);
            //// 2007.07.12  S.Koga  ADD ----------------------------------------
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(10, DMDTTLSETITEM_DIV10);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(11, DMDTTLSETITEM_DIV11);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(12, DMDTTLSETITEM_DIV12);
            //this.DmdTtlSetItemDiv6_tComb.Items.Add(13, DMDTTLSETITEM_DIV13);
            //// ----------------------------------------------------------------
            //this.DmdTtlSetItemDiv6_tComb.MaxDropDownItems = this.DmdTtlSetItemDiv6_tComb.Items.Count;

            //this.DmdTtlSetItemDiv7_tComb.Items.Clear();
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(0,DMDTTLSETITEM_DIV0);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(1,DMDTTLSETITEM_DIV1);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(2,DMDTTLSETITEM_DIV2);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(3,DMDTTLSETITEM_DIV3);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(4,DMDTTLSETITEM_DIV4);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(5,DMDTTLSETITEM_DIV5);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(6,DMDTTLSETITEM_DIV6);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(7,DMDTTLSETITEM_DIV7);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(8,DMDTTLSETITEM_DIV8);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(9,DMDTTLSETITEM_DIV9);
            //// 2007.07.12  S.Koga  ADD ----------------------------------------
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(10, DMDTTLSETITEM_DIV10);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(11, DMDTTLSETITEM_DIV11);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(12, DMDTTLSETITEM_DIV12);
            //this.DmdTtlSetItemDiv7_tComb.Items.Add(13, DMDTTLSETITEM_DIV13);
            //// ----------------------------------------------------------------
            //this.DmdTtlSetItemDiv7_tComb.MaxDropDownItems = this.DmdTtlSetItemDiv7_tComb.Items.Count;

            //this.DmdTtlSetItemDiv8_tComb.Items.Clear();
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(0,DMDTTLSETITEM_DIV0);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(1,DMDTTLSETITEM_DIV1);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(2,DMDTTLSETITEM_DIV2);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(3,DMDTTLSETITEM_DIV3);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(4,DMDTTLSETITEM_DIV4);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(5,DMDTTLSETITEM_DIV5);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(6,DMDTTLSETITEM_DIV6);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(7,DMDTTLSETITEM_DIV7);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(8,DMDTTLSETITEM_DIV8);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(9,DMDTTLSETITEM_DIV9);
            //// 2007.07.12  S.Koga  ADD ----------------------------------------
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(10, DMDTTLSETITEM_DIV10);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(11, DMDTTLSETITEM_DIV11);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(12, DMDTTLSETITEM_DIV12);
            //this.DmdTtlSetItemDiv8_tComb.Items.Add(13, DMDTTLSETITEM_DIV13);
            //// ----------------------------------------------------------------
            //this.DmdTtlSetItemDiv8_tComb.MaxDropDownItems = this.DmdTtlSetItemDiv8_tComb.Items.Count;
            // DEL 2008/11/14 不具合対応[7858] ----------<<<<<

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            //請求明細単価別出力区分
            this.DmdDtUnitPrtDiv_tCombo.Clear();
            this.DmdDtUnitPrtDiv_tCombo.Items.Add(0,DMDTLUNITPRT_DIV0);
            this.DmdDtUnitPrtDiv_tCombo.Items.Add(1,DMDTLUNITPRT_DIV1);
            this.DmdDtUnitPrtDiv_tCombo.MaxDropDownItems = this.DmdDtUnitPrtDiv_tCombo.Items.Count;
            //支払明細単価別出力区分
            this.PayDtUnitPrtDiv_tComb.Clear();
            this.PayDtUnitPrtDiv_tComb.Items.Add(0,DMDTLUNITPRT_DIV0);
            this.PayDtUnitPrtDiv_tComb.Items.Add(1,DMDTLUNITPRT_DIV1);
            this.PayDtUnitPrtDiv_tComb.MaxDropDownItems = this.DmdDtUnitPrtDiv_tCombo.Items.Count;
            //請求明細金額０印字区分
            this.DmdDtPrcZeroPrDiv_tComb.Clear();
            this.DmdDtPrcZeroPrDiv_tComb.Items.Add(0,DMDDTLPRCZEROPRT_DIV0);
            this.DmdDtPrcZeroPrDiv_tComb.Items.Add(1,DMDDTLPRCZEROPRT_DIV1);
            this.DmdDtPrcZeroPrDiv_tComb.Items.Add(2,DMDDTLPRCZEROPRT_DIV2);
            this.DmdDtPrcZeroPrDiv_tComb.MaxDropDownItems = this.DmdDtPrcZeroPrDiv_tComb.Items.Count;
            //支払明細金額０印字区分
            this.PayDtPrcZeroPrDiv_tComb.Clear();
            this.PayDtPrcZeroPrDiv_tComb.Items.Add(0,PRINT_DIV0);
            this.PayDtPrcZeroPrDiv_tComb.Items.Add(1,PRINT_DIV1);
            this.PayDtPrcZeroPrDiv_tComb.MaxDropDownItems = this.PayDtPrcZeroPrDiv_tComb.Items.Count;
            //今回請求額０印字区分
            this.ThisTimeDmZeroPrDiv_tComb.Clear();
            this.ThisTimeDmZeroPrDiv_tComb.Items.Add(0,PRINT_DIV0);
            this.ThisTimeDmZeroPrDiv_tComb.Items.Add(1,PRINT_DIV1);
            this.ThisTimeDmZeroPrDiv_tComb.MaxDropDownItems = this.ThisTimeDmZeroPrDiv_tComb.Items.Count;
            //マイナス請求時印刷区分
            this.MinusDmdPrtDiv_tComb.Clear();
            this.MinusDmdPrtDiv_tComb.Items.Add(0,MINUSDMDPRT_DIV0);
            this.MinusDmdPrtDiv_tComb.Items.Add(1,MINUSDMDPRT_DIV1);
            this.MinusDmdPrtDiv_tComb.MaxDropDownItems = this.MinusDmdPrtDiv_tComb.Items.Count;
            //入金集計明細印字区分
            this.DmdFmDepoTtlPrDiv_tComb.Clear();
            this.DmdFmDepoTtlPrDiv_tComb.Items.Add(0,PRINT_DIV0);
            this.DmdFmDepoTtlPrDiv_tComb.Items.Add(1,PRINT_DIV1);
            this.DmdFmDepoTtlPrDiv_tComb.MaxDropDownItems = this.DmdFmDepoTtlPrDiv_tComb.Items.Count;
            //機種別インセンティブ出力区分
            // 2007.09.18 hikita del start ----------------------------------------->>
            // this.CellphoneIncOutputDiv_tComb.Clear();
            // this.CellphoneIncOutputDiv_tComb.Items.Add(0,CELLPHONEINCOUT_DIV0);
            // this.CellphoneIncOutputDiv_tComb.Items.Add(1,CELLPHONEINCOUT_DIV1);
            // this.CellphoneIncOutputDiv_tComb.MaxDropDownItems = this.CellphoneIncOutputDiv_tComb.Items.Count;
            // 2007.09.18 hikita del end -------------------------------------------<<  

            //請求集計分類
            this.DmdFmTtlGenCd1_tComb.Items.Clear();
            this.DmdFmTtlGenCd1_tComb.Items.Add(0,DMDFMGENCD_DIV0);
            this.DmdFmTtlGenCd1_tComb.Items.Add(1,DMDFMGENCD_DIV1);
            this.DmdFmTtlGenCd1_tComb.Items.Add(2,DMDFMGENCD_DIV2);
            this.DmdFmTtlGenCd1_tComb.Items.Add(3,DMDFMGENCD_DIV3);
            this.DmdFmTtlGenCd1_tComb.Items.Add(4,DMDFMGENCD_DIV4);
            this.DmdFmTtlGenCd1_tComb.Items.Add(5,DMDFMGENCD_DIV5);
            //this.DmdFmTtlGenCd1_tComb.Items.Add(6,DMDFMGENCD_DIV6);  // 2007.09.18 hikita del
            this.DmdFmTtlGenCd1_tComb.MaxDropDownItems = this.DmdFmTtlGenCd1_tComb.Items.Count;
            this.DmdFmTtlGenCd2_tComb.Items.Clear();
            this.DmdFmTtlGenCd2_tComb.Items.Add(0,DMDFMGENCD_DIV0);
            this.DmdFmTtlGenCd2_tComb.Items.Add(1,DMDFMGENCD_DIV1);
            this.DmdFmTtlGenCd2_tComb.Items.Add(2,DMDFMGENCD_DIV2);
            this.DmdFmTtlGenCd2_tComb.Items.Add(3,DMDFMGENCD_DIV3);
            this.DmdFmTtlGenCd2_tComb.Items.Add(4,DMDFMGENCD_DIV4);
            this.DmdFmTtlGenCd2_tComb.Items.Add(5,DMDFMGENCD_DIV5);
            //this.DmdFmTtlGenCd2_tComb.Items.Add(6,DMDFMGENCD_DIV6);  // 2007.09.18 hikita del
            this.DmdFmTtlGenCd2_tComb.MaxDropDownItems = this.DmdFmTtlGenCd2_tComb.Items.Count;
            this.DmdFmTtlGenCd3_tComb.Items.Clear();
            this.DmdFmTtlGenCd3_tComb.Items.Add(0,DMDFMGENCD_DIV0);
            this.DmdFmTtlGenCd3_tComb.Items.Add(1,DMDFMGENCD_DIV1);
            this.DmdFmTtlGenCd3_tComb.Items.Add(2,DMDFMGENCD_DIV2);
            this.DmdFmTtlGenCd3_tComb.Items.Add(3,DMDFMGENCD_DIV3);
            this.DmdFmTtlGenCd3_tComb.Items.Add(4,DMDFMGENCD_DIV4);
            this.DmdFmTtlGenCd3_tComb.Items.Add(5,DMDFMGENCD_DIV5);
            //this.DmdFmTtlGenCd3_tComb.Items.Add(6,DMDFMGENCD_DIV6);  // 2007.09.18 hikita del
            this.DmdFmTtlGenCd3_tComb.MaxDropDownItems = this.DmdFmTtlGenCd3_tComb.Items.Count;
              
            //支払集計分類
            this.DmdFmPayTtlGenCd1_tComb.Items.Clear();
            this.DmdFmPayTtlGenCd1_tComb.Items.Add(0,DMDFMGENCD_DIV0);
            this.DmdFmPayTtlGenCd1_tComb.Items.Add(1,DMDFMGENCD_DIV1);
            this.DmdFmPayTtlGenCd1_tComb.Items.Add(2,DMDFMGENCD_DIV2);
            this.DmdFmPayTtlGenCd1_tComb.Items.Add(3,DMDFMGENCD_DIV3);
            this.DmdFmPayTtlGenCd1_tComb.Items.Add(4,DMDFMGENCD_DIV4);
            this.DmdFmPayTtlGenCd1_tComb.Items.Add(5,DMDFMGENCD_DIV5);
            //this.DmdFmPayTtlGenCd1_tComb.Items.Add(6,DMDFMGENCD_DIV6); // 2007.09.18 hikita del
            this.DmdFmPayTtlGenCd1_tComb.MaxDropDownItems = this.DmdFmPayTtlGenCd1_tComb.Items.Count;
            this.DmdFmPayTtlGenCd2_tComb.Items.Clear();
            this.DmdFmPayTtlGenCd2_tComb.Items.Add(0,DMDFMGENCD_DIV0);
            this.DmdFmPayTtlGenCd2_tComb.Items.Add(1,DMDFMGENCD_DIV1);
            this.DmdFmPayTtlGenCd2_tComb.Items.Add(2,DMDFMGENCD_DIV2);
            this.DmdFmPayTtlGenCd2_tComb.Items.Add(3,DMDFMGENCD_DIV3);
            this.DmdFmPayTtlGenCd2_tComb.Items.Add(4,DMDFMGENCD_DIV4);
            this.DmdFmPayTtlGenCd2_tComb.Items.Add(5,DMDFMGENCD_DIV5);
            //this.DmdFmPayTtlGenCd2_tComb.Items.Add(6,DMDFMGENCD_DIV6);// 2007.09.18 hikita del
            this.DmdFmPayTtlGenCd2_tComb.MaxDropDownItems = this.DmdFmPayTtlGenCd2_tComb.Items.Count;
            this.DmdFmPayTtlGenCd3_tComb.Items.Clear();
            this.DmdFmPayTtlGenCd3_tComb.Items.Add(0,DMDFMGENCD_DIV0);
            this.DmdFmPayTtlGenCd3_tComb.Items.Add(1,DMDFMGENCD_DIV1);
            this.DmdFmPayTtlGenCd3_tComb.Items.Add(2,DMDFMGENCD_DIV2);
            this.DmdFmPayTtlGenCd3_tComb.Items.Add(3,DMDFMGENCD_DIV3);
            this.DmdFmPayTtlGenCd3_tComb.Items.Add(4,DMDFMGENCD_DIV4);
            this.DmdFmPayTtlGenCd3_tComb.Items.Add(5,DMDFMGENCD_DIV5);
            //this.DmdFmPayTtlGenCd3_tComb.Items.Add(6,DMDFMGENCD_DIV6);// 2007.09.18 hikita del
            this.DmdFmPayTtlGenCd3_tComb.MaxDropDownItems = this.DmdFmPayTtlGenCd3_tComb.Items.Count;
               --- DEL 2008/06/18 --------------------------------<<<<< */

            //初期選択設定
            SetItemDefaultSelectSetting();

            #endregion
        }

        #region 鑑設定項目区分コンボ初期選択設定 
        /// <summary>
        /// 鑑設定項目区分コンボ初期選択設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 鑑設定項目区分コンボの初期選択設定を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// <br>UpdateNote : 2011/02/16 施ヘイ中</br>
        /// <br>           : 自社名印字区分を追加</br>
        /// </remarks>
        private void SetItemDefaultSelectSetting()
        {
            // DEL 2008/11/14 不具合対応[7858] ---------->>>>>
            ////デフォルト選択は携帯７にあわせておく
            //this.DmdTtlSetItemDiv1_tComb.SelectedIndex = 1;
            //this.DmdTtlSetItemDiv2_tComb.SelectedIndex = 2;
            //this.DmdTtlSetItemDiv3_tComb.SelectedIndex = 3;
            //// 2007.07.12  S.Koga  AMEND --------------------------------------
            ////this.DmdTtlSetItemDiv4_tComb.SelectedIndex = 4;
            ////this.DmdTtlSetItemDiv5_tComb.SelectedIndex = 5;
            ////this.DmdTtlSetItemDiv6_tComb.SelectedIndex = 8;
            ////this.DmdTtlSetItemDiv7_tComb.SelectedIndex = 9;
            //this.DmdTtlSetItemDiv4_tComb.SelectedIndex = 6;
            //this.DmdTtlSetItemDiv5_tComb.SelectedIndex = 9;
            //this.DmdTtlSetItemDiv6_tComb.SelectedIndex = 12;
            //this.DmdTtlSetItemDiv7_tComb.SelectedIndex = 13;
            //// ----------------------------------------------------------------
            //this.DmdTtlSetItemDiv8_tComb.SelectedIndex = 0;
            // DEL 2008/11/14 不具合対応[7858] ----------<<<<<

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            //請求明細単価別出力区分
            this.DmdDtUnitPrtDiv_tCombo.SelectedIndex = 0;        
            //支払明細単価別出力区分
            this.PayDtUnitPrtDiv_tComb.SelectedIndex = 0; 
            //請求明細金額０印字区分
            this.DmdDtPrcZeroPrDiv_tComb.SelectedIndex = 0;       
            //支払明細金額０印字区分
            this.PayDtPrcZeroPrDiv_tComb.SelectedIndex = 0;         
            //今回請求額０印字区分
            this.ThisTimeDmZeroPrDiv_tComb.SelectedIndex = 0;         
            //マイナス請求時印刷区分
            this.MinusDmdPrtDiv_tComb.SelectedIndex = 0;      
            //入金集計明細印字区分
            this.DmdFmDepoTtlPrDiv_tComb.SelectedIndex = 0;
            //機種別インセンティブ出力区分
            // this.CellphoneIncOutputDiv_tComb.SelectedIndex = 0; // 2007.09.18 hikita del
         
            //TODO(とりあえず,１:契約区分2:商品区分グループ3:商品区分)にしておく
            //請求集計分類
            this.DmdFmTtlGenCd1_tComb.SelectedIndex = 0;
            this.DmdFmTtlGenCd2_tComb.SelectedIndex = 2;
            this.DmdFmTtlGenCd3_tComb.SelectedIndex = 3;             
            //支払集計分類
            this.DmdFmPayTtlGenCd1_tComb.SelectedIndex = 0;
            this.DmdFmPayTtlGenCd2_tComb.SelectedIndex = 2;
            this.DmdFmPayTtlGenCd3_tComb.SelectedIndex = 3;   
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
            DataInputSystem_tNedit.Clear();                                 // データ入力システム
            OutputFormFileName_tEdit.Clear();                               // 出力ファイル名
            SlipPrtSetPaperId_tEdit.Clear();                                // 印刷帳票ID
            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
            // --- ADD 2008/06/18 -------------------------------->>>>>
            SlipPrtKind_tComboEditor.SelectedIndex = this._mainDataIndex;  // 伝票印刷種別
            SlipComment_tEdit.Clear();                                     // 伝票コメント
            TopMargin_tNedit.DataText = "0.0";                             // 上余白
            LeftMargin_tNedit.DataText = "0.0";                            // 左余白
            RightMargin_tNedit.DataText = "0.0";                           // 右余白
            BottomMargin_tNedit.DataText = "0.0";                          // 下余白 
            CopyCount_tComboEditor.SelectedIndex = 0;                      // 複写枚数
            DmdFormTitle2_tEdit.DataText = DMDFORMTITLE2_DEFAULT;          // 請求書タイトル２
            DmdDtlOutlineCode_tComboEditor.SelectedIndex = 0;              // 請求明細摘要区分
            DmdDtlPtnOdrDiv_tComboEditor.SelectedIndex = 0;                // 請求明細書印字順位区分
            SlipTtlPrtDiv_tComboEditor.SelectedIndex = 0;                  // 伝票計印字有無
            AddDayTtlPrtDiv_tComboEditor.SelectedIndex = 0;                // 計上日計印字有無
            CustomerTtlPrtDiv_tComboEditor.SelectedIndex = 0;              // 得意先計印字有無
            DtlPrcZeroPrtDiv_tComboEditor.SelectedIndex = 0;               // 明細金額ゼロ時印字有無
            DepoDtlPrcPrtDiv_tComboEditor.SelectedIndex = 0;               // 入金明細印字有無区分
            BillHonorificTtl_tEdit.Clear();                                // 請求書敬称
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            ListPricePrtCd_tComboEditor.SelectedIndex = 1;                  // 標準価格印字区分
            PartsNoPrtCd_tComboEditor.SelectedIndex = 1;                    // 品番印字区分
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END

            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            AnnotationPrtCd_tComboEditor.SelectedIndex = 0;                 // 注釈印字区分
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            CoNmPrintOutCd_tComboEditor.SelectedIndex = 0;
            // --- ADD  2011/02/16 ----------<<<<<
        
        }

        #endregion

        #endregion

        #region 排他処理

        /// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.07.03</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 他端末更新
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 他端末削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"MAKAU09150U", 								// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より削除されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
					break;
				}
			}
		}

        #endregion

        #region データセット展開処理処理
        /// <summary>
        /// 請求書印刷パターン設定オブジェクトデータセット展開処理
        /// </summary>
        /// <param name="dmdPrtPtn">請求書印刷パターン設定データオブジェクト</param>
        /// <param name="index">データセットへ展開するインデックス</param>
        /// <remarks>
        /// <br>Note       : 請求書印刷パターン設定オブジェクトをデータセットに格納します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/05</br>
        /// <br>UpdateNote : 2011/02/16 施ヘイ中</br>
        /// <br>           : 自社名印字区分を追加</br>
        /// </remarks>
        private void DmdPrtPtnToDataSet(DmdPrtPtn dmdPrtPtn, int index)
        {
            // 印刷種別ID取得
            int slipPrtKindID = (int)this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[this._mainDataIndex][VIEW_SLIPPRTKINDID];

            if (slipPrtKindID != dmdPrtPtn.SlipPrtKind)
            {
                return;
            }

            // indexの値がDataSetの既存行をさしていなかったら
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows.Count <= index))
            {
                // 新規と判断して、行を追加する
                DataRow dataRow = this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows.Add(dataRow);

                // indexに行の最終行番号をセットする
                index = this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows.Count - 1;
            }

            // 論理削除データか？
            if (dmdPrtPtn.LogicalDeleteCode == 0)
            {
                // 論理削除でない→削除日は空にする
                this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DELETE_DATE] = "";
            }
            else
            {
                // 論理削除である→削除日に更新日をセットする
                this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DELETE_DATE] = dmdPrtPtn.UpdateDateTimeJpInFormal;
            }

            // 各項目のセット       
            /* --- DEL 2008/06/18 -------------------------------->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEMANDPTNNO] = dmdPrtPtn.DemandPtnNo; //請求書パターン番号
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DEMANDPTNNM] = dmdPrtPtn.DemandPtnNoNm; //請求書パターン番号名称
               --- DEL 2008/06/18 --------------------------------<<<<< */
            // DEL 2008/11/14 不具合対応[7858] ---------->>>>>
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLFORMTITLE1] = dmdPrtPtn.DmdTtlFormTitle1; //請求 鑑タイトル１
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLFORMTITLE2] = dmdPrtPtn.DmdTtlFormTitle2; //請求 鑑タイトル２
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLFORMTITLE3] = dmdPrtPtn.DmdTtlFormTitle3; //請求 鑑タイトル３
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLFORMTITLE4] = dmdPrtPtn.DmdTtlFormTitle4; //請求 鑑タイトル４
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLFORMTITLE5] = dmdPrtPtn.DmdTtlFormTitle5; //請求 鑑タイトル５
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLFORMTITLE6] = dmdPrtPtn.DmdTtlFormTitle6; //請求 鑑タイトル６
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLFORMTITLE7] = dmdPrtPtn.DmdTtlFormTitle7; //請求 鑑タイトル７
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLFORMTITLE8] = dmdPrtPtn.DmdTtlFormTitle8; //請求 鑑タイトル８
            
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV1] = dmdPrtPtn.DmdTtlSetItemDiv1; //請求 鑑設定項目区分１
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV2] = dmdPrtPtn.DmdTtlSetItemDiv2; //請求 鑑設定項目区分２
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV3] = dmdPrtPtn.DmdTtlSetItemDiv3; //請求 鑑設定項目区分３
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV4] = dmdPrtPtn.DmdTtlSetItemDiv4; //請求 鑑設定項目区分４
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV5] = dmdPrtPtn.DmdTtlSetItemDiv5; //請求 鑑設定項目区分５
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV6] = dmdPrtPtn.DmdTtlSetItemDiv6; //請求 鑑設定項目区分６
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV7] = dmdPrtPtn.DmdTtlSetItemDiv7; //請求 鑑設定項目区分７
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV8] = dmdPrtPtn.DmdTtlSetItemDiv8; //請求 鑑設定項目区分８
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV1NM] = GetSetItemDivNm(dmdPrtPtn.DmdTtlSetItemDiv1); //請求 鑑設定項目区分１(名称)
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV2NM] = GetSetItemDivNm(dmdPrtPtn.DmdTtlSetItemDiv2); //請求 鑑設定項目区分２(名称)
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV3NM] = GetSetItemDivNm(dmdPrtPtn.DmdTtlSetItemDiv3); //請求 鑑設定項目区分３(名称)
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV4NM] = GetSetItemDivNm(dmdPrtPtn.DmdTtlSetItemDiv4); //請求 鑑設定項目区分４(名称)
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV5NM] = GetSetItemDivNm(dmdPrtPtn.DmdTtlSetItemDiv5); //請求 鑑設定項目区分５(名称)
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV6NM] = GetSetItemDivNm(dmdPrtPtn.DmdTtlSetItemDiv6); //請求 鑑設定項目区分６(名称)
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV7NM] = GetSetItemDivNm(dmdPrtPtn.DmdTtlSetItemDiv7); //請求 鑑設定項目区分７(名称)
            //this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDTTLSETITEMDIV8NM] = GetSetItemDivNm(dmdPrtPtn.DmdTtlSetItemDiv8); //請求 鑑設定項目区分８(名称)
            // DEL 2008/11/14 不具合対応[7858] ----------<<<<<

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYTTLFORMTITLE1] = dmdPrtPtn.PayTtlFormTitle1; //支払 鑑タイトル１
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYTTLFORMTITLE2] = dmdPrtPtn.PayTtlFormTitle2; //支払 鑑タイトル２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYTTLFORMTITLE3] = dmdPrtPtn.PayTtlFormTitle3; //支払 鑑タイトル３
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYTTLFORMTITLE4] = dmdPrtPtn.PayTtlFormTitle4; //支払 鑑タイトル４
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYTTLFORMTITLE5] = dmdPrtPtn.PayTtlFormTitle5; //支払 鑑タイトル５
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYTTLFORMTITLE6] = dmdPrtPtn.PayTtlFormTitle6; //支払 鑑タイトル６
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYTTLFORMTITLE7] = dmdPrtPtn.PayTtlFormTitle7; //支払 鑑タイトル７
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYTTLFORMTITLE8] = dmdPrtPtn.PayTtlFormTitle8; //支払 鑑タイトル８
               --- DEL 2008/06/18 --------------------------------<<<<< */

            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDFORMTITLE] = dmdPrtPtn.DmdFormTitle; //請求書タイトル
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYMENTFORMTITLE] = dmdPrtPtn.PaymentFormTitle; //支払通知書タイトル  // DEL 2008/06/18

            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDFORMCOMENT1] = dmdPrtPtn.DmdFormComent1; //請求書コメント１
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDFORMCOMENT2] = dmdPrtPtn.DmdFormComent2; //請求書コメント２
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDFORMCOMENT3] = dmdPrtPtn.DmdFormComent3; //請求書コメント３

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDMDTTLGENCD1] = dmdPrtPtn.DmdFmDmdTtlGenCd1; //請求書請求集計分類１
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDMDTTLGENCD2] = dmdPrtPtn.DmdFmDmdTtlGenCd2; //請求書請求集計分類２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDMDTTLGENCD3] = dmdPrtPtn.DmdFmDmdTtlGenCd3; //請求書請求集計分類３
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMPAYTTLGENCD1] = dmdPrtPtn.DmdFmPayTtlGenCd1; //請求書支払集計分類１
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMPAYTTLGENCD2] = dmdPrtPtn.DmdFmPayTtlGenCd2; //請求書支払集計分類２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMPAYTTLGENCD3] = dmdPrtPtn.DmdFmPayTtlGenCd3; //請求書支払集計分類３

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDMDTTLGENCD1NM] = GetDmdFmGenCdNm(dmdPrtPtn.DmdFmDmdTtlGenCd1); //請求書請求集計分類１(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDMDTTLGENCD2NM] = GetDmdFmGenCdNm(dmdPrtPtn.DmdFmDmdTtlGenCd2); //請求書請求集計分類２(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDMDTTLGENCD3NM] = GetDmdFmGenCdNm(dmdPrtPtn.DmdFmDmdTtlGenCd3); //請求書請求集計分類３(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMPAYTTLGENCD1NM] = GetDmdFmGenCdNm(dmdPrtPtn.DmdFmPayTtlGenCd1); //請求書支払集計分類１(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMPAYTTLGENCD2NM] = GetDmdFmGenCdNm(dmdPrtPtn.DmdFmPayTtlGenCd2); //請求書支払集計分類２(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMPAYTTLGENCD3NM] = GetDmdFmGenCdNm(dmdPrtPtn.DmdFmPayTtlGenCd3); //請求書支払集計分類３(名称)

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDMDTTLGENNM2] = dmdPrtPtn.DmdFmDmdTtlGenNm2; //請求書請求集計分類名称２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDMDTTLGENNM3] = dmdPrtPtn.DmdFmDmdTtlGenNm3; //請求書請求集計分類名称３
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDTTLGENDEFLTNM] = dmdPrtPtn.DmdTtlGenDefltNm; //請求集計分類デフォルト名称
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYTTLGENDEFLTNM] = dmdPrtPtn.PayTtlGenDefltNm; //支払集計分類デフォルト名称

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDDTLUNITPRTDIV] = dmdPrtPtn.DmdDtlUnitPrtDiv; //請求明細単価別出力有無
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYDTLUNITPRTDIV] = dmdPrtPtn.PayDtlUnitPrtDiv; //支払明細単価別出力有無
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_THTMDMDZEROPRTDIV] = dmdPrtPtn.ThTmDmdZeroPrtDiv; //今回請求額ゼロ時印字有無
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDDTLPRCZEROPRTDIV] = dmdPrtPtn.DmdDtlPrcZeroPrtDiv; //請求明細金額ゼロ時印字有無
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYDTLPRCZEROPRTDIV] = dmdPrtPtn.PayDtlPrcZeroPrtDiv; //支払明細金額ゼロ時印字有無
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MINUSDMDPRTDIV] = dmdPrtPtn.MinusDmdPrtDiv; //マイナス請求時印刷区分
               --- DEL 2008/06/18 --------------------------------<<<<< */
            
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDEPOTTLPRTDIV] = dmdPrtPtn.DmdFmDepoTtlPrtDiv; //請求書入金集計明細印字区分  // DEL 2008/06/18
            // this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CELLPHONEINCOUTDIV] = dmdPrtPtn.CellphoneIncOutDiv; //機種別インセンティブ出力区分 // 2007.09.18 hikita del

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDDTLUNITPRTDIVNM]       = GetDmdDtlUnitPrtDivNm(dmdPrtPtn.DmdDtlUnitPrtDiv); //請求明細単価別出力有無(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYDTLUNITPRTDIVNM]       = GetDmdDtlUnitPrtDivNm(dmdPrtPtn.PayDtlUnitPrtDiv);  //支払明細単価別出力有無(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_THTMDMDZEROPRTDIVNM]      = GetPrintDivNm(dmdPrtPtn.ThTmDmdZeroPrtDiv); //今回請求額ゼロ時印字有無(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDDTLPRCZEROPRTDIVNM]    = GetDmdDtlPrcZeroPrtDivNm(dmdPrtPtn.DmdDtlPrcZeroPrtDiv); //請求明細金額ゼロ時印字有無(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PAYDTLPRCZEROPRTDIVNM]    = GetPrintDivNm(dmdPrtPtn.PayDtlPrcZeroPrtDiv); //支払明細金額ゼロ時印字有無(名称)
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MINUSDMDPRTDIVNM]         = GetMinusDmdPrtDivNm(dmdPrtPtn.MinusDmdPrtDiv); //マイナス請求時印刷区分(名称)
               --- DEL 2008/06/18 --------------------------------<<<<< */

            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DMDFMDEPOTTLPRTDIVNM]     = GetPrintDivNm(dmdPrtPtn.DmdFmDepoTtlPrtDiv); //請求書入金集計明細印字区分(名称)  // DEL 2008/06/18
            // this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CELLPHONEINCOUTDIVNM]     = GetCellphoneIncOutDivNm(dmdPrtPtn.CellphoneIncOutDiv); //機種別インセンティブ出力区分(名称) // 2007.09.18 hikita del

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD1] = dmdPrtPtn.CmplDmdMdGoodsCd1; //強制請求出力商品区分１
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD2] = dmdPrtPtn.CmplDmdMdGoodsCd2; //強制請求出力商品区分２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD3] = dmdPrtPtn.CmplDmdMdGoodsCd3; //強制請求出力商品区分３
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD4] = dmdPrtPtn.CmplDmdMdGoodsCd4; //強制請求出力商品区分４
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD5] = dmdPrtPtn.CmplDmdMdGoodsCd5; //強制請求出力商品区分５
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD6] = dmdPrtPtn.CmplDmdMdGoodsCd6; //強制請求出力商品区分６
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD7] = dmdPrtPtn.CmplDmdMdGoodsCd7; //強制請求出力商品区分７
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD8] = dmdPrtPtn.CmplDmdMdGoodsCd8; //強制請求出力商品区分８
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD9] = dmdPrtPtn.CmplDmdMdGoodsCd9; //強制請求出力商品区分９
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD10] = dmdPrtPtn.CmplDmdMdGoodsCd10; //強制請求出力商品区分１０
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD1] = dmdPrtPtn.CmplPayMdGoodsCd1; //強制支払出力商品区分１
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD2] = dmdPrtPtn.CmplPayMdGoodsCd2; //強制支払出力商品区分２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD3] = dmdPrtPtn.CmplPayMdGoodsCd3; //強制支払出力商品区分３
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD4] = dmdPrtPtn.CmplPayMdGoodsCd4; //強制支払出力商品区分４
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD5] = dmdPrtPtn.CmplPayMdGoodsCd5; //強制支払出力商品区分５
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD6] = dmdPrtPtn.CmplPayMdGoodsCd6; //強制支払出力商品区分６
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD7] = dmdPrtPtn.CmplPayMdGoodsCd7; //強制支払出力商品区分７
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD8] = dmdPrtPtn.CmplPayMdGoodsCd8; //強制支払出力商品区分８
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD9] = dmdPrtPtn.CmplPayMdGoodsCd9; //強制支払出力商品区分９
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD10] = dmdPrtPtn.CmplPayMdGoodsCd10; //強制支払出力商品区分１０

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD1NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd1); //強制請求出力商品区分１
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD2NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd2); //強制請求出力商品区分２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD3NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd3); //強制請求出力商品区分３
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD4NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd4); //強制請求出力商品区分４
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD5NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd5); //強制請求出力商品区分５
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD6NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd6); //強制請求出力商品区分６
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD7NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd7); //強制請求出力商品区分７
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD8NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd8); //強制請求出力商品区分８
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD9NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd9); //強制請求出力商品区分９
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLDMDMDGOODSCD10NM] = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd10); //強制請求出力商品区分１０
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD1NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd1); //強制支払出力商品区分１
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD2NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd2); //強制支払出力商品区分２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD3NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd3); //強制支払出力商品区分３
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD4NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd4); //強制支払出力商品区分４
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD5NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd5); //強制支払出力商品区分５
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD6NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd6); //強制支払出力商品区分６
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD7NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd7); //強制支払出力商品区分７
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD8NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd8); //強制支払出力商品区分８
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD9NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd9); //強制支払出力商品区分９
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CMPLPAYMDGOODSCD10NM] = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd10); //強制支払出力商品区分１０
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
            // データ入力システム
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DATAINPUTSYSTEM] = dmdPrtPtn.DataInputSystem;
            // 出力ファイル名
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_OUTPUTFILENAME] = dmdPrtPtn.OutputFormFileName;
            // 印刷帳票ID
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_SLIPPRTSETPAPERID] = dmdPrtPtn.SlipPrtSetPaperId;
            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
            // --- ADD 2008/06/18 -------------------------------->>>>>
            // パターン名称
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_SLIPCOMMENT] = dmdPrtPtn.SlipComment;
            // 得意先敬称
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_BILLHONORIFICTTL] = dmdPrtPtn.BillHonorificTtl;
            // 複写枚数
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_COPYCOOUNT] = dmdPrtPtn.CopyCount;
            // 上余白
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_TOPMARGIN] = dmdPrtPtn.TopMargin;
            // 下余白
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_BOTTOMMARGIN] = dmdPrtPtn.BottomMargin;
            // 左余白
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_LEFTMARGIN] = dmdPrtPtn.LeftMargin;
            // 右余白
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_RIGHTMARGIN] = dmdPrtPtn.RightMargin;
            // 請求書(控)タイトル
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDFORMTITLE2] = dmdPrtPtn.DmdFormTitle2;
            // 印字順位
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDDTLPTNODRDIV] = GetDmdDtlPtnOdrDivNm(dmdPrtPtn.DmdDtlPtnOdrDiv);
            // 請求明細摘要区分
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DMDDTLOUTLINECODE] = GetDmdDtlOutlineCodeNm(dmdPrtPtn.DmdDtlOutlineCode);
            // 明細金額ゼロ時
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DTLPRCZEROPRTDIV] = GetPrintDivNm(dmdPrtPtn.DtlPrcZeroPrtDiv);
            // 入金明細
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_DEPODTLPRCPRTDIV] = GetDepoDtlPrcPrtDivNm(dmdPrtPtn.DepoDtlPrcPrtDiv);
            // 伝票計
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_SLIPTTLPRTDIV] = GetPrintDivNm(dmdPrtPtn.SlipTtlPrtDiv);
            // 計上日計
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_ADDDAYTTLPRTDIV] = GetPrintDivNm(dmdPrtPtn.AddDayTtlPrtDiv);
            // 得意先計
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_CUSTOMERTTLPRTDIV] = GetPrintDivNm(dmdPrtPtn.CustomerTtlPrtDiv);
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            // 標準価格印字区分
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_LISTPRICEPRTCD] = GetListPricePrtCdNm(dmdPrtPtn.ListPricePrtCd);
            // 品番印字区分
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_PARTSNOPRTCD] = GetPartsNoPrtCdNm(dmdPrtPtn.PartsNoPrtCd);            
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END
        
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            // 注釈印字区分
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_ANNOTATIONPRTCD] = GetAnnotationPrtCd(dmdPrtPtn.AnnotationPrtCd);
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_CONMPRINTOUTCD] = GetCoNmPrintOutCdRF(dmdPrtPtn.CoNmPrintOutCd);
            // --- ADD  2011/02/16 ----------<<<<<<

            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[index][VIEW_FILEHEADERGUID] = dmdPrtPtn.FileHeaderGuid; //GUID

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            // インスタンステーブルにもセットする
            if (this._dmdPrtPtnTable.ContainsKey(dmdPrtPtn.DemandPtnNo) == true)
            {
                this._dmdPrtPtnTable.Remove(dmdPrtPtn.DemandPtnNo);
            }
            this._dmdPrtPtnTable.Add(dmdPrtPtn.DemandPtnNo, dmdPrtPtn);
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // --- ADD 2008/06/18 -------------------------------->>>>>
            // インスタンステーブルにもセットする
            if (this._dmdPrtPtnRightTable.ContainsKey(dmdPrtPtn.FileHeaderGuid) == true)
            {
                this._dmdPrtPtnRightTable.Remove(dmdPrtPtn.FileHeaderGuid);
            }
            this._dmdPrtPtnRightTable.Add(dmdPrtPtn.FileHeaderGuid, dmdPrtPtn);
            // --- ADD 2008/06/18 --------------------------------<<<<< 
        }

        #endregion

        #region 名称取得処理

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        #region 機種別インセンティブ出力区分名称取得処理
        /// <summary>
        /// 機種別インセンティブ出力区分名称取得処理
        /// </summary>
        /// <param name="cellphoneIncOutDiv">出力区分</param>
        /// <returns>区分名称</returns>
        /// <remarks>
        /// <br>Note       : 機種別インセンティブ出力区分から名称を取得します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private string GetCellphoneIncOutDivNm(int cellphoneIncOutDiv)
        {
            string retstring = string.Empty;
            switch(cellphoneIncOutDiv)
            {
                case (int)CellphoneIncOutputDiv.TotalPrint:
                    {
                        //集計印字
                        retstring = CELLPHONEINCOUT_DIV0;
                        break;
                    }
                case (int)CellphoneIncOutputDiv.Cellphone:
                    {
                        //機種別印字
                        retstring = CELLPHONEINCOUT_DIV1;
                        break;
                    } 
            }
            return retstring;
        }
        #endregion

        #region マイナス請求時印刷区分名称取得処理
        /// <summary>
        /// マイナス請求時印刷区分名称取得処理
        /// </summary>
        /// <param name="minusDmdPrtDiv">マイナス請求時印刷区分</param>
        /// <returns>マイナス請求時印刷区分名称</returns>
        /// <remarks>
        /// <br>Note       : マイナス請求時印刷区分から名称を取得します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private string GetMinusDmdPrtDivNm(int minusDmdPrtDiv)
        {
            string retstring = string.Empty;
            switch(minusDmdPrtDiv)
            {
                case (int)MinusDemandPrintDiv.PayNoticeList:
                    {
                        //支払通知書とする
                        retstring = MINUSDMDPRT_DIV0;
                        break;
                    }
                case (int)MinusDemandPrintDiv.MinusDemandList:
                    {
                        //マイナス請求書とする
                        retstring = MINUSDMDPRT_DIV1;
                        break;
                    } 
            }
            return retstring;
        }
        #endregion

        #region 請求明細金額０印字区分名称処理

        /// <summary>
        /// 請求明細金額０印字区分名称処理
        /// </summary>
        /// <param name="dmdDtlPrcZeroPrtDiv">請求明細金額０印字区分</param>
        /// <returns>請求明細金額０印字区分名称</returns>
        /// <remarks>
        /// <br>Note       : 請求明細金額０印字区分から名称を取得します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private string GetDmdDtlPrcZeroPrtDivNm(int dmdDtlPrcZeroPrtDiv)
        {
            string retstring = string.Empty;
            switch(dmdDtlPrcZeroPrtDiv)
            {
                case (int)DemandPriceZeroPrintDiv.On:
                    {
                        //印字する
                        retstring = DMDDTLPRCZEROPRT_DIV0;
                        break;
                    }
                case (int)DemandPriceZeroPrintDiv.AllZeroTimeOff:
                    {
                        //全て０のみ印字しない
                        retstring = DMDDTLPRCZEROPRT_DIV1;
                        break;
                    }
                case (int)DemandPriceZeroPrintDiv.AfterPriceZeroTimeOff:
                    {
                        //相殺額が０の時印字しない
                        retstring = DMDDTLPRCZEROPRT_DIV2;
                        break;
                    } 
            }
            return retstring;
        }
        #endregion
             
           --- DEL 2008/06/18 --------------------------------<<<<< */

        #region 印字区分名称取得処理
        /// <summary>
        /// 印字区分名称取得処理
        /// </summary>
        /// <param name="printDiv">印字区分</param>
        /// <returns>印字区分名称</returns>
        /// <remarks>
        /// <br>Note       : 印字区分から名称を取得します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private string GetPrintDivNm(int printDiv)
        {
            string retstring = string.Empty;
            switch(printDiv)
            {
                case (int)PrintDiv.On:
                    {
                        //印字する
                        retstring = PRINT_DIV0;
                        break;
                    }
                case (int)PrintDiv.Off:
                    {
                        //印字しない
                        retstring = PRINT_DIV1;
                        break;
                    } 
            }
            return retstring;
        }

        #endregion

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        #region 明細単価別出力区分名称取得処理
        /// <summary>
        /// 明細単価別出力区分名称取得処理
        /// </summary>
        /// <param name="dmdDtlUnitPrtDiv">明細単価別出力区分</param>
        /// <returns>明細単価別出力区分名称</returns>
        /// <remarks>
        /// <br>Note       : 明細単価別出力区分から名称を取得します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private string GetDmdDtlUnitPrtDivNm(int dmdDtlUnitPrtDiv)
        {
            string retstring = string.Empty;
            switch(dmdDtlUnitPrtDiv)
            {
                case (int)UnitPricePrintDiv.On:
                    {
                        //印字する
                        retstring = DMDTLUNITPRT_DIV0;
                        break;
                    }
                case (int)UnitPricePrintDiv.Off:
                    {
                        //印字しない
                        retstring = DMDTLUNITPRT_DIV1;
                        break;
                    } 
            }
            return retstring;
        }

        #endregion
           --- DEL 2008/06/18 --------------------------------<<<<< */

        #region  鑑設定項目区分名称取得処理

        /// <summary>
        /// 鑑設定項目区分名称取得処理
        /// </summary>
        /// <param name="setItemDiv">鑑設定項目区分</param>
        /// <returns>鑑設定項目区分名称</returns>
        /// <remarks>
        /// <br>Note       : 鑑設定項目区分コードから名称を取得します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private string GetSetItemDivNm(int setItemDiv)
        {
            string retstring = string.Empty;
            switch(setItemDiv)
            {
                case (int)DmdTtlSetItemDiv.None:
                    {
                        //TODO:
                        //未使用
                        retstring = string.Empty;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.LastTimeDemandPrice:
                    {
                        //前回請求額
                        retstring = DMDTTLSETITEM_DIV1;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.ThisTimeDepositPrice:
                    {
                        //今回入金額
                        retstring = DMDTTLSETITEM_DIV2;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.OverDemandPrice:
                    {
                        //繰越請求額
                        retstring = DMDTTLSETITEM_DIV3;
                        break;
                    }
                // 2007.07.12  S.Koga  AMEND ----------------------------------
                // 表示インデックスで扱っているため、項目並び順に数値を再設定
                // *注　修正する際は、請求書（帳票印刷）と合わせる必要があります。
                // ------------------------------------------------------------
                // case (int)DmdTtlSetItemDiv.ThisTimeExTaxAfterDemandPrice:
                //    {
                //        //今回税抜相殺請求額
                //        retstring = DMDTTLSETITEM_DIV4;
                //        break;
                //    }
                //case (int)DmdTtlSetItemDiv.ThisTimeAfterTaxPrice:
                //    {
                //        //今回相殺消費税額
                //        retstring = DMDTTLSETITEM_DIV5;
                //        break;
                //    }
                //case (int)DmdTtlSetItemDiv.ThisTimeIncTaxDemandPrice:
                //    {
                //        //今回税込請求額
                //        retstring = DMDTTLSETITEM_DIV6;
                //        break;
                //    }
                //case (int)DmdTtlSetItemDiv.ThisTimeIncTaxPayPrice:
                //    {
                //        //今回税込支払額
                //        retstring = DMDTTLSETITEM_DIV7;
                //        break;
                //    }
                // case (int)DmdTtlSetItemDiv.ThisTimeIncTaxAfterDemandPrice:
                //    {
                //        //今回税込相殺請求額
                //        retstring = DMDTTLSETITEM_DIV8;
                //        break;
                //    }
                //case (int)DmdTtlSetItemDiv.DemandPrice:
                //    {
                //        //御請求額
                //        retstring = DMDTTLSETITEM_DIV9;
                //        break;
                //    }
                case (int)DmdTtlSetItemDiv.ThisTimeExTaxDemandPrice:
                    {
                        // 今回税抜請求額
                        retstring = DMDTTLSETITEM_DIV4;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.ThisTimeExTaxPayPrice:
                    {
                        // 今回税抜支払額
                        retstring = DMDTTLSETITEM_DIV5;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.ThisTimeExTaxAfterDemandPrice:
                    {
                        // 今回税抜相殺請求額
                        retstring = DMDTTLSETITEM_DIV6;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.ThisTimeDemandTaxPrice:
                    {
                        // 今回請求消費税額
                        retstring = DMDTTLSETITEM_DIV7;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.ThisTimePayTaxPrice:
                    {
                        // 今回支払消費税額
                        retstring = DMDTTLSETITEM_DIV8;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.ThisTimeAfterTaxPrice:
                    {
                        // 今回相殺消費税額
                        retstring = DMDTTLSETITEM_DIV9;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.ThisTimeIncTaxDemandPrice:
                    {
                        // 今回税込請求額
                        retstring = DMDTTLSETITEM_DIV10;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.ThisTimeIncTaxPayPrice:
                    {
                        // 今回税込支払額
                        retstring = DMDTTLSETITEM_DIV11;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.ThisTimeIncTaxAfterDemandPrice:
                    {
                        // 今回税込相殺請求額
                        retstring = DMDTTLSETITEM_DIV12;
                        break;
                    }
                case (int)DmdTtlSetItemDiv.DemandPrice:
                    {
                        // 御請求額
                        retstring = DMDTTLSETITEM_DIV13;
                        break;
                    }
                // ------------------------------------------------------------
            }
            return retstring;
        }

        #endregion

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        #region  集計分類項目名称取得処理
        /// <summary>
        /// 集計分類項目名称取得処理
        /// </summary>
        /// <param name="genCd">集計分類項目コード</param>
        /// <returns>集計分類項目名称</returns>
        /// <remarks>
        /// <br>Note       : 集計分類項目コードから名称を取得します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private string GetDmdFmGenCdNm(int genCd)
        {
            string retstring = string.Empty;
            switch(genCd)
            {
                case (int)DmdFmTtlGenCd.None:
                    {
                        //無し
                        retstring = DMDFMGENCD_DIV0;
                        break;
                    }
                case (int)DmdFmTtlGenCd.LargeGoods:
                    {
                        //商品区分グループ
                        retstring = DMDFMGENCD_DIV1;
                        break;
                    }
                case (int)DmdFmTtlGenCd.MediumGoods:
                    {
                        //商品区分
                        retstring = DMDFMGENCD_DIV2;
                        break;
                    }
                case (int)DmdFmTtlGenCd.Goods:
                    {
                        //商品
                        retstring = DMDFMGENCD_DIV3;
                        break;
                    }
                 case (int)DmdFmTtlGenCd.Customer:
                    {
                        //得意先
                        retstring = DMDFMGENCD_DIV4;
                        break;
                    }
                case (int)DmdFmTtlGenCd.PromissDiv:
                    {
                        //契約区分
                        retstring = DMDFMGENCD_DIV5;
                        break;
                    }
                // 2007.09.18 hikita del start --->>
                //case (int)DmdFmTtlGenCd.Carrier:
                //    {
                //        //キャリア
                //        retstring = DMDFMGENCD_DIV6;
                //        break;
                //    }
                // 2007.09.18 hikita del end -----<<
              
            }
            return retstring;
        }

        #endregion

        #region 商品区分名称取得処理1
        /// <summary>
        /// 商品区分名称取得処理1
        /// </summary>
        /// <param name="mGoodsCode">商品区分コード</param>
        /// <returns>商品区分名称</returns>
        /// <remarks>
        /// <br>Note       : 商品区分コードから名称を取得します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private string GetMdGoodsName(string mGoodsCode)
        {
            string mGoodsNm = string.Empty;
            if(mGoodsCode == string.Empty)
            {
                //商品区分コードが空→登録されていない
                return mGoodsNm;
            }
            else
            {
                //商品区分マスタRead
                MGoodsGanre mGoodsGanre = null;
               
                //TODO:ReadStaticMemory使うとエラーになるandModelSubCodeをどうするか？
                //ローカルDBをReadするように変更.
                //ReadStaticMemoryが修正されないのでしょうがない
                //int st = this._mGoodsGanreAcs.ReadStaticMemory(out mGoodsGanre,this._enterpriseCode,string.Empty,mGoodsCode);
                this._mGoodsGanreAcs.IsLocalDBRead = true;
                // int st = this._mGoodsGanreAcs.Read(out mGoodsGanre,this._enterpriseCode,string.Empty,mGoodsCode,0); // 2007.09.18 hikita del
                int st = this._mGoodsGanreAcs.Read(out mGoodsGanre,this._enterpriseCode,string.Empty,mGoodsCode);      // 2007.09.18 hikita add

                switch(st)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            //正常取得
                            if(mGoodsGanre != null)
                            {
                                if(mGoodsGanre.LogicalDeleteCode == 0)
                                {
                                    mGoodsNm = mGoodsGanre.MediumGoodsGanreName;
                                }
                                else
                                {
                                    mGoodsNm = ALREADYDELETE;
                                }                                
                            }                           
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {                       
                            //コードはEnptyではないが該当データ無し
                            //mGoodsNm = "";
                            mGoodsNm = NOTTARGETRECORD;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {                        
                            //マスタから削除されてる
                            //mGoodsNm = "";
                            mGoodsNm = ALREADYDELETE;
                            break;
                        }
                    default:
                        {
                            //空文字を返す
                            break;
                        }
                }
                return mGoodsNm;           
            }
        }

        #endregion
           --- DEL 2008/06/18 --------------------------------<<<<< */

        // --- ADD 2008/06/18 -------------------------------->>>>>
        #region 請求明細摘要区分名称取得処理
        /// <summary>
        /// 請求明細摘要区分名称取得処理
        /// </summary>
        /// <param name="dmdDtlOutlineCode">請求明細摘要区分</param>
        /// <returns>請求明細摘要区分名称</returns>
        /// <remarks>
        /// <br>Note       : 請求明細摘要区分から名称を取得します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private string GetDmdDtlOutlineCodeNm(int dmdDtlOutlineCode)
        {
            string retstring = string.Empty;

            switch (dmdDtlOutlineCode)
            {
                case (int)DmdDtlOutlineCode.Off:
                    {
                        // 印字しない
                        retstring = DMDDTLOOUTLINECODE_DIV0;
                        break;
                    }
                case (int)DmdDtlOutlineCode.GoosNo:
                    {
                        // 品番
                        retstring = DMDDTLOOUTLINECODE_DIV1;
                        break;
                    }
                case (int)DmdDtlOutlineCode.FixedPrice:
                    {
                        // 定価
                        retstring = DMDDTLOOUTLINECODE_DIV2;
                        break;
                    }
            }
            return retstring;
        }
        #endregion

        #region 請求明細書印字順位区分名称取得処理
        /// <summary>
        /// 請求明細書印字順位区分名称取得処理
        /// </summary>
        /// <param name="dmdDtlPtnOdrDiv">請求明細書印字順位区分</param>
        /// <returns>請求明細書印字順位区分名称</returns>
        /// <remarks>
        /// <br>Note       : 請求明細書印字順位区分から名称を取得します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private string GetDmdDtlPtnOdrDivNm(int dmdDtlPtnOdrDiv)
        {
            string retstring = string.Empty;

            switch (dmdDtlPtnOdrDiv)
            {
                case (int)DmdDtlPtnOdrDiv.Pattern1:
                    {
                        // 計上日＋伝票番号
                        retstring = DMDDTLPTNODR_DIV0;
                        break;
                    }
                case (int)DmdDtlPtnOdrDiv.Pattern2:
                    {
                        // 得意先＋計上日＋伝票番号
                        retstring = DMDDTLPTNODR_DIV1;
                        break;
                    }
                    // --- ADD  大矢睦美  2010/06/15 ---------->>>>>
                case (int)DmdDtlPtnOdrDiv.Pattern3:
                    {
                        //売上/入金＋計上日＋伝票番号
                        retstring = DMDDTLPTNODR_DIV2;
                        break;
                    }
                case (int)DmdDtlPtnOdrDiv.Pattern4:
                    {
                        //売上/入金＋得意先＋計上日＋伝票番号
                        retstring = DMDDTLPTNODR_DIV3;
                        break;
                    }
                    // --- ADD  大矢睦美  2010/06/15 ----------<<<<<
            }
            return retstring;
        }
        #endregion

        #region 入金明細印字有無区分名称取得処理
        /// <summary>
        /// 入金明細印字有無区分名称取得処理
        /// </summary>
        /// <param name="depoDtlPrcPrtDiv">入金明細印字有無区分</param>
        /// <returns>入金明細印字有無区分名称</returns>
        /// <remarks>
        /// <br>Note       : 入金明細印字有無区分から名称を取得します</br>
        /// <br>Programmer : 30415 柴田 倫幸</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private string GetDepoDtlPrcPrtDivNm(int depoDtlPrcPrtDiv)
        {
            string retstring = string.Empty;

            switch (depoDtlPrcPrtDiv)
            {
                case (int)DepoDtlPrcPrtDiv.Off:
                    {
                        // 印字しない
                        retstring = DEPODTLPRCPRT_DIV0;
                        break;
                    }
                case (int)DepoDtlPrcPrtDiv.Total:
                    {
                        // 印字する（合計）
                        retstring = DEPODTLPRCPRT_DIV1;
                        break;
                    }
                case (int)DepoDtlPrcPrtDiv.Detail:
                    {
                        // 印字する（明細）
                        retstring = DEPODTLPRCPRT_DIV2;
                        break;
                    }
            }
            return retstring;
        }
        #endregion
        // --- ADD 2008/06/18 --------------------------------<<<<< 

        // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
        #region 標準価格印字区分名称取得処理
        /// <summary>
        /// 標準価格印字区分名称取得処理
        /// </summary>
        /// <param name="listPricePrtCd">標準価格印字区分</param>
        /// <returns>標準価格印字区分名称</returns>
        /// <remarks>
        /// <br>Note       : 標準価格印字区分から名称を取得します</br>
        /// </remarks>
        private string GetListPricePrtCdNm(int listPricePrtCd)
        {
            string retstring = string.Empty;

            switch (listPricePrtCd)
            {
                case 0:
                    {
                        // 印字しない
                        retstring = LISTPRICEPRTCD_DIV0;
                        break;
                    }
                case 1:
                    {
                        // 印字する
                        retstring = LISTPRICEPRTCD_DIV1;
                        break;
                    }
                case 2:
                    {
                        // 掛率＜１
                        retstring = LISTPRICEPRTCD_DIV2;
                        break;
                    }
            }
            return retstring;
        }
        #endregion

        #region 品番印字区分名称取得処理
        /// <summary>
        /// 品番印字区分名称取得処理
        /// </summary>
        /// <param name="partsNoPrtCd">品番印字区分</param>
        /// <returns>品番印字区分名称</returns>
        /// <remarks>
        /// <br>Note       : 品番印字区分から名称を取得します</br>
        /// </remarks>
        private string GetPartsNoPrtCdNm(int partsNoPrtCd)
        {
            string retstring = string.Empty;

            switch (partsNoPrtCd)
            {
                case 0:
                    {
                        // 印字しない
                        retstring = PARTSNOPRTCD_DIV0;
                        break;
                    }
                case 1:
                    {
                        // 印字する
                        retstring = PARTSNOPRTCD_DIV1;
                        break;
                    }
            }
            return retstring;
        }
        #endregion
        // 2009.04.03 30413 犬飼 項目追加 >>>>>>START

        // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
        #region 注釈印字区分名称取得処理
        /// <summary>
        /// 注釈印字区分名称取得処理
        /// </summary>
        /// <param name="AnnotationPrtCd">注釈印字区分</param>
        /// <returns>注釈印字区分名称</returns>
        /// <remarks>
        /// <br>Note       : 注釈印字区分から名称を取得します</br>
        /// </remarks>
        private string GetAnnotationPrtCd(int AnnotationPrtCd)
        {
            string retstring = string.Empty;

            switch (AnnotationPrtCd)
            {
                case 0:
                    {
                        //印字する
                        retstring = ANNOTATIONPRTCD_DIV0;
                        break;
                    }
                case 1:
                    {
                        //印字しない
                        retstring = ANNOTATIONPRTCD_DIV1;
                        break;
                    }
            }
            return retstring;
        }
        #endregion
        // --- ADD  大矢睦美  2010/02/18 ----------<<<<<
        
        #endregion


        // --- ADD  2011/02/16 ---------->>>>>
        #region 自社名印字区分名称取得処理
        /// <summary>
        /// 自社名印字区分名称取得処理
        /// </summary>
        /// <param name="CoNmPrintOutCdRF">自社名印字区分</param>
        /// <returns>自社名印字区分名称</returns>
        /// <remarks>
        /// <br>Note       : 自社名印字区分から名称を取得します</br>
        /// <br>Programmer : 施ヘイ中</br>
        /// <br>Date       : 2011/02/16</br>
        /// </remarks>
        private string GetCoNmPrintOutCdRF(int CoNmPrintOutCdRF)
        {
            string retstring = string.Empty;

            switch (CoNmPrintOutCdRF)
            {
                case 0:
                    {
                        //標準
                        retstring = CONMPRINTOUTCD_DIV0;
                        break;
                    }
                case 1:
                    {
                        //自社名
                        retstring = CONMPRINTOUTCD_DIV1;
                        break;
                    }
               case 2:
                    {
                        //拠点名
                        retstring = CONMPRINTOUTCD_DIV2;
                        break;
                    }
               case 3:
                    {
                        //ビットマップ
                        retstring = CONMPRINTOUTCD_DIV3;
                        break;
                    }
               case 4:
                    {
                        //印字しない
                        retstring = CONMPRINTOUTCD_DIV4;
                        break;
                    }
                  
            }
            return retstring;
        }
        #endregion
        // --- ADD  2011/02/16 ----------<<<<<<
        
        #endregion

        #region UI画面再構築処理
        /// <summary>
        /// UI画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>           : 画面の内容を内部変数に保持します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private void ScreenReconstruction()
        {                        
            //if (this.DataIndex < 0)        // DEL 2008/06/18
            if (this._detailsDataIndex < 0)  // ADD 2008/06/18
            {
                // --- ADD 2008/06/18 -------------------------------->>>>>
                // 印刷種別ID取得
                int slipPrtKindID = (int)this.Bind_DataSet.Tables[VIEWLEFT_TABLE].Rows[this._mainDataIndex][VIEW_SLIPPRTKINDID];

                // 印刷種別選択
                this.SlipPrtKind_tComboEditor.Value = slipPrtKindID;
                // --- ADD 2008/06/18 --------------------------------<<<<< 

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                this.Ok_Button.Visible = true;
                this.Cancel_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;

                // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
                DmdPrtPtn dmdPrtPtn = new DmdPrtPtn();
                ////クローン作成
                //this._dmdPrtPtnClone = dmdPrtPtn.Clone();
                //DispToDmdPrtPtn(ref this._dmdPrtPtnClone);

                int status = this._dmdPrtPtnAcs.ExecuteGuid(this._enterpriseCode, (int)SlipPrtKind_tComboEditor.Value, out dmdPrtPtn);

                // キー項目が設定されていない場合画面を閉じる
                if ((dmdPrtPtn.SlipPrtSetPaperId == null) || (dmdPrtPtn.SlipPrtSetPaperId == ""))
                {
                    if (UnDisplaying != null)
                    {
                        MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                        UnDisplaying(this, me);
                    }

                    this.DialogResult = DialogResult.Cancel;
                    this._indexBuf = -2;

                    if (CanClose == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                    }
                    return;
                }

                //----------------------------
                // キーを基に検索データを取得
                //----------------------------
                string searchStr = string.Format("{0}='{1}' and {2}='{3}'"
                    , VIEW_DATAINPUTSYSTEM, dmdPrtPtn.DataInputSystem
                    , VIEW_SLIPPRTSETPAPERID, dmdPrtPtn.SlipPrtSetPaperId);

                DataRow[] foundRateRow = this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Select(searchStr);

                if (foundRateRow.Length == 0)
                {
                    // 該当データ無し
                    if (UnDisplaying != null)
                    {
                        MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                        UnDisplaying(this, me);
                    }

                    this.DialogResult = DialogResult.Cancel;
                    this._indexBuf = -2;

                    if (CanClose == true)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.Hide();
                    }
                    return;
                }

                // データテーブルのGUIDを基に請求印刷パターン定オブジェクト取得
                Guid guid = (Guid)foundRateRow[0][VIEW_FILEHEADERGUID];	// 取得データは必ず1件なので0固定

                dmdPrtPtn = (DmdPrtPtn)this._dmdPrtPtnRightTable[guid];

                // クローンを作成
                this._dmdPrtPtnClone = dmdPrtPtn.Clone();
                // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
                // 画面展開処理
                DmdPrtPtnToScreen(dmdPrtPtn, 0);

                //this._indexBuf = this._dataIndex;       // DEL 2008/06/18
                this._indexBuf = this._detailsDataIndex;  // ADD 2008/06/18

                ScreenInputPermissionControl(true);

                // 印刷種別を選択不可にする
                this.SlipPrtKind_tComboEditor.Enabled = false;

                // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
                // 印刷帳票IDは変更可にする
                this.SlipPrtSetPaperId_tEdit.Enabled = true;
                // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
                Main_TabControl.Tabs[0].Selected = true;

                /* --- DEL 2008/06/18 -------------------------------->>>>>
                //パターン番号を入力可に
                this.DemandPtnNo_tNedit.Focus();
                this.DemandPtnNo_tNedit.SelectAll();
                   --- DEL 2008/06/18 --------------------------------<<<<< */

                this.SlipComment_tEdit.Focus();  // ADD 2008/06/18
            }
            else
            {
                // DataSetからGUIDを取得
                //int demantPatrnNo = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_DEMANDPTNNO];  // DEL 2008/06/18
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[this._detailsDataIndex][VIEW_FILEHEADERGUID];  // ADD 2008/06/18
                
                // GUIDでインスタンステーブルから該当インスタンスを取得
                DmdPrtPtn dmdPrtPtn = (DmdPrtPtn)this._dmdPrtPtnRightTable[guid];
             
                //画面展開処理
                DmdPrtPtnToScreen(dmdPrtPtn,0);

                if (dmdPrtPtn.LogicalDeleteCode == 0)
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    this.Ok_Button.Visible = true;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;

                    ScreenInputPermissionControl(true);

                    // 印刷種別を選択不可にする
                    this.SlipPrtKind_tComboEditor.Enabled = false;

                    // クローン作成
                    this._dmdPrtPtnClone = dmdPrtPtn.Clone();
                    DispToDmdPrtPtn(ref this._dmdPrtPtnClone);
                    //_dataIndexバッファ保持
                    //this._indexBuf = this._dataIndex;       // DEL 2008/06/18
                    this._indexBuf = this._detailsDataIndex;  // ADD 2008/06/18

                    Main_TabControl.SelectedTab = Main_TabControl.Tabs[0];
                    //Main_TabControl.Tabs[0].Selected = true;

                    this.SlipComment_tEdit.Focus();
                    //this.SlipComment_tEdit.SelectAll();
               
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    ScreenInputPermissionControl(false);

                    this.Delete_Button.Focus();

                    Main_TabControl.Tabs[0].Selected = true;

                    //this._indexBuf = this._dataIndex;       // DEL 2008/06/18
                    this._indexBuf = this._detailsDataIndex;  // ADD 2008/06/18
                }

                // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
                // 印刷帳票IDは変更不可にする
                this.SlipPrtSetPaperId_tEdit.Enabled = false;
                // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            }
        }

        #endregion

        #region 画面情報請求書印刷パターンクラス格納処理
        /// <summary>
        /// 画面情報請求書印刷パターンクラス格納処理
        /// </summary>
        /// <param name="dmdPrtPtn">請求書印刷パターンオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報から請求書印刷パターンオブジェクトにデータを格納します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// <br>UpdateNote : 2011/02/16 施ヘイ中</br>
        /// <br>           : 自社名印字区分を追加</br>
        /// </remarks>
        private void DispToDmdPrtPtn(ref DmdPrtPtn dmdPrtPtn)
        {
            if (dmdPrtPtn == null)
            {
                // 新規の場合
                dmdPrtPtn = new DmdPrtPtn();
            }
    
            // 各項目のセット
            dmdPrtPtn.EnterpriseCode = this._enterpriseCode;    //企業コード	

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            dmdPrtPtn.DemandPtnNo = DemandPtnNo_tNedit.GetInt(); //請求書パターン番号
            dmdPrtPtn.DemandPtnNoNm = SlipComment_tEdit.DataText; //請求書パターン番号名称
               --- DEL 2008/06/18 --------------------------------<<<<< */
            // DEL 2008/11/14 不具合対応[7858] ---------->>>>>
            //dmdPrtPtn.DmdTtlFormTitle1 = DmdTtlFormTitle1_tEdit.DataText; //請求 鑑タイトル１
            //dmdPrtPtn.DmdTtlFormTitle2 = DmdTtlFormTitle2_tEdit.DataText; //請求 鑑タイトル２
            //dmdPrtPtn.DmdTtlFormTitle3 = DmdTtlFormTitle3_tEdit.DataText; //請求 鑑タイトル３
            //dmdPrtPtn.DmdTtlFormTitle4 = DmdTtlFormTitle4_tEdit.DataText; //請求 鑑タイトル４
            //dmdPrtPtn.DmdTtlFormTitle5 = DmdTtlFormTitle5_tEdit.DataText; //請求 鑑タイトル５
            //dmdPrtPtn.DmdTtlFormTitle6 = DmdTtlFormTitle6_tEdit.DataText; //請求 鑑タイトル６
            //dmdPrtPtn.DmdTtlFormTitle7 = DmdTtlFormTitle7_tEdit.DataText; //請求 鑑タイトル７
            //dmdPrtPtn.DmdTtlFormTitle8 = DmdTtlFormTitle8_tEdit.DataText; //請求 鑑タイトル８

            //dmdPrtPtn.DmdTtlSetItemDiv1 = (int)DmdTtlSetItemDiv1_tComb.Value; //請求 鑑設定項目区分１
            //dmdPrtPtn.DmdTtlSetItemDiv2 = (int)DmdTtlSetItemDiv2_tComb.Value; //請求 鑑設定項目区分２
            //dmdPrtPtn.DmdTtlSetItemDiv3 = (int)DmdTtlSetItemDiv3_tComb.Value; //請求 鑑設定項目区分３
            //dmdPrtPtn.DmdTtlSetItemDiv4 = (int)DmdTtlSetItemDiv4_tComb.Value; //請求 鑑設定項目区分４
            //dmdPrtPtn.DmdTtlSetItemDiv5 = (int)DmdTtlSetItemDiv5_tComb.Value; //請求 鑑設定項目区分５
            //dmdPrtPtn.DmdTtlSetItemDiv6 = (int)DmdTtlSetItemDiv6_tComb.Value; //請求 鑑設定項目区分６
            //dmdPrtPtn.DmdTtlSetItemDiv7 = (int)DmdTtlSetItemDiv7_tComb.Value; //請求 鑑設定項目区分７
            //dmdPrtPtn.DmdTtlSetItemDiv8 = (int)DmdTtlSetItemDiv8_tComb.Value; //請求 鑑設定項目区分８
            // DEL 2008/11/14 不具合対応[7858] ----------<<<<<
            // ADD 2008/11/14 不具合対応[7858] ---------->>>>>
            // 項目削除に伴い初期値を設定
            dmdPrtPtn.DmdTtlFormTitle1 = ""; //請求 鑑タイトル１
            dmdPrtPtn.DmdTtlFormTitle2 = ""; //請求 鑑タイトル２
            dmdPrtPtn.DmdTtlFormTitle3 = ""; //請求 鑑タイトル３
            dmdPrtPtn.DmdTtlFormTitle4 = ""; //請求 鑑タイトル４
            dmdPrtPtn.DmdTtlFormTitle5 = ""; //請求 鑑タイトル５
            dmdPrtPtn.DmdTtlFormTitle6 = ""; //請求 鑑タイトル６
            dmdPrtPtn.DmdTtlFormTitle7 = ""; //請求 鑑タイトル７
            dmdPrtPtn.DmdTtlFormTitle8 = ""; //請求 鑑タイトル８

            dmdPrtPtn.DmdTtlSetItemDiv1 = 0; //請求 鑑設定項目区分１
            dmdPrtPtn.DmdTtlSetItemDiv2 = 0; //請求 鑑設定項目区分２
            dmdPrtPtn.DmdTtlSetItemDiv3 = 0; //請求 鑑設定項目区分３
            dmdPrtPtn.DmdTtlSetItemDiv4 = 0; //請求 鑑設定項目区分４
            dmdPrtPtn.DmdTtlSetItemDiv5 = 0; //請求 鑑設定項目区分５
            dmdPrtPtn.DmdTtlSetItemDiv6 = 0; //請求 鑑設定項目区分６
            dmdPrtPtn.DmdTtlSetItemDiv7 = 0; //請求 鑑設定項目区分７
            dmdPrtPtn.DmdTtlSetItemDiv8 = 0; //請求 鑑設定項目区分８
            // ADD 2008/11/14 不具合対応[7858] ----------<<<<<

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            dmdPrtPtn.PayTtlFormTitle1 = PayTtlFormTitle1_tEdit.DataText; //支払 鑑タイトル１
            dmdPrtPtn.PayTtlFormTitle2 = PayTtlFormTitle2_tEdit.DataText; //支払 鑑タイトル２
            dmdPrtPtn.PayTtlFormTitle3 = PayTtlFormTitle3_tEdit.DataText; //支払 鑑タイトル３
            dmdPrtPtn.PayTtlFormTitle4 = PayTtlFormTitle4_tEdit.DataText; //支払 鑑タイトル４
            dmdPrtPtn.PayTtlFormTitle5 = PayTtlFormTitle5_tEdit.DataText; //支払 鑑タイトル５
            dmdPrtPtn.PayTtlFormTitle6 = PayTtlFormTitle6_tEdit.DataText; //支払 鑑タイトル６
            dmdPrtPtn.PayTtlFormTitle7 = PayTtlFormTitle7_tEdit.DataText; //支払 鑑タイトル７
            dmdPrtPtn.PayTtlFormTitle8 = PayTtlFormTitle8_tEdit.DataText; //支払 鑑タイトル８
               --- DEL 2008/06/18 --------------------------------<<<<< */

            dmdPrtPtn.DmdFormTitle      = DmFormTitle_tEdit.DataText; //請求書タイトル

            //dmdPrtPtn.PaymentFormTitle  = PaymentFormTitle_tEdit.DataText; //支払通知書タイトル  // DEL 2008/06/18

            dmdPrtPtn.DmdFormComent1    = DmdFormComents1_tEdit.DataText; //請求書コメント１
            dmdPrtPtn.DmdFormComent2    = DmdFormComents2_tEdit.DataText; //請求書コメント２
            dmdPrtPtn.DmdFormComent3    = DmdFormComents3_tEdit.DataText; //請求書コメント３

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            dmdPrtPtn.DmdFmDmdTtlGenCd1 = (int)DmdFmTtlGenCd1_tComb.Value; //請求書請求集計分類１
            dmdPrtPtn.DmdFmDmdTtlGenCd2 = (int)DmdFmTtlGenCd2_tComb.Value; //請求書請求集計分類２
            dmdPrtPtn.DmdFmDmdTtlGenCd3 = (int)DmdFmTtlGenCd3_tComb.Value; //請求書請求集計分類３
            dmdPrtPtn.DmdFmPayTtlGenCd1 = (int)DmdFmPayTtlGenCd1_tComb.Value; //請求書支払集計分類１
            dmdPrtPtn.DmdFmPayTtlGenCd2 = (int)DmdFmPayTtlGenCd2_tComb.Value; //請求書支払集計分類２
            dmdPrtPtn.DmdFmPayTtlGenCd3 = (int)DmdFmPayTtlGenCd3_tComb.Value; //請求書支払集計分類３
            dmdPrtPtn.DmdFmDmdTtlGenNm2 = DmdFmDmdTtlGenNm2_tEdit.DataText; //請求書請求集計分類名称２
            dmdPrtPtn.DmdFmDmdTtlGenNm3 = DmdFmDmdTtlGenNm3_tEdit.DataText; //請求書請求集計分類名称３
            dmdPrtPtn.DmdTtlGenDefltNm  = DmdTtlGenDefNm_tEdit.DataText; //請求集計分類デフォルト名称
            dmdPrtPtn.PayTtlGenDefltNm  = PayTtlGenDefNm_tEdit.DataText; //支払集計分類デフォルト名称
            dmdPrtPtn.DmdDtlUnitPrtDiv = (int)DmdDtUnitPrtDiv_tCombo.Value; //請求明細単価別出力有無
            dmdPrtPtn.PayDtlUnitPrtDiv = (int)PayDtUnitPrtDiv_tComb.Value; //支払明細単価別出力有無
            dmdPrtPtn.ThTmDmdZeroPrtDiv = (int)ThisTimeDmZeroPrDiv_tComb.Value; //今回請求額ゼロ時印字有無
            dmdPrtPtn.DmdDtlPrcZeroPrtDiv = (int)DmdDtPrcZeroPrDiv_tComb.Value; //請求明細金額ゼロ時印字有無
            dmdPrtPtn.PayDtlPrcZeroPrtDiv = (int)PayDtPrcZeroPrDiv_tComb.Value; //支払明細金額ゼロ時印字有無
            dmdPrtPtn.MinusDmdPrtDiv = (int)MinusDmdPrtDiv_tComb.Value; //マイナス請求時印刷区分
            dmdPrtPtn.DmdFmDepoTtlPrtDiv = (int)DmdFmDepoTtlPrDiv_tComb.Value; //請求書入金集計明細印字区分
            // dmdPrtPtn.CellphoneIncOutDiv = (int)CellphoneIncOutputDiv_tComb.Value; //機種別インセンティブ出力区分 // 2007.09.18 hikita del
            dmdPrtPtn.CmplDmdMdGoodsCd1 = CmplDmdMdGoodsCd1_tEdit.DataText; //強制請求出力商品区分１
            dmdPrtPtn.CmplDmdMdGoodsCd2 = CmplDmdMdGoodsCd2_tEdit.DataText; //強制請求出力商品区分２
            dmdPrtPtn.CmplDmdMdGoodsCd3 = CmplDmdMdGoodsCd3_tEdit.DataText; //強制請求出力商品区分３
            dmdPrtPtn.CmplDmdMdGoodsCd4 = CmplDmdMdGoodsCd4_tEdit.DataText; //強制請求出力商品区分４
            dmdPrtPtn.CmplDmdMdGoodsCd5 = CmplDmdMdGoodsCd5_tEdit.DataText; //強制請求出力商品区分５
            dmdPrtPtn.CmplDmdMdGoodsCd6 = CmplDmdMdGoodsCd6_tEdit.DataText; //強制請求出力商品区分６
            dmdPrtPtn.CmplDmdMdGoodsCd7 = CmplDmdMdGoodsCd7_tEdit.DataText; //強制請求出力商品区分７
            dmdPrtPtn.CmplDmdMdGoodsCd8 = CmplDmdMdGoodsCd8_tEdit.DataText; //強制請求出力商品区分８
            dmdPrtPtn.CmplDmdMdGoodsCd9 = CmplDmdMdGoodsCd9_tEdit.DataText; //強制請求出力商品区分９
            dmdPrtPtn.CmplDmdMdGoodsCd10 = CmplDmdMdGoodsCd10_tEdit.DataText; //強制請求出力商品区分１０
            dmdPrtPtn.CmplPayMdGoodsCd1 = CmplPayMdGoodsCd1_tEdit.DataText; //強制支払出力商品区分１
            dmdPrtPtn.CmplPayMdGoodsCd2 = CmplPayMdGoodsCd2_tEdit.DataText; //強制支払出力商品区分２
            dmdPrtPtn.CmplPayMdGoodsCd3 = CmplPayMdGoodsCd3_tEdit.DataText; //強制支払出力商品区分３
            dmdPrtPtn.CmplPayMdGoodsCd4 = CmplPayMdGoodsCd4_tEdit.DataText; //強制支払出力商品区分４
            dmdPrtPtn.CmplPayMdGoodsCd5 = CmplPayMdGoodsCd5_tEdit.DataText; //強制支払出力商品区分５
            dmdPrtPtn.CmplPayMdGoodsCd6 = CmplPayMdGoodsCd6_tEdit.DataText; //強制支払出力商品区分６
            dmdPrtPtn.CmplPayMdGoodsCd7 = CmplPayMdGoodsCd7_tEdit.DataText; //強制支払出力商品区分７
            dmdPrtPtn.CmplPayMdGoodsCd8 = CmplPayMdGoodsCd8_tEdit.DataText; //強制支払出力商品区分８
            dmdPrtPtn.CmplPayMdGoodsCd9 = CmplPayMdGoodsCd9_tEdit.DataText; //強制支払出力商品区分９
            dmdPrtPtn.CmplPayMdGoodsCd10 = CmplPayMdGoodsCd10_tEdit.DataText; //強制支払出力商品区分１０
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
            dmdPrtPtn.DataInputSystem = DataInputSystem_tNedit.GetInt();            // データ入力システム
            dmdPrtPtn.OutputFormFileName = OutputFormFileName_tEdit.Text.Trim();    // 出力ファイル名
            dmdPrtPtn.SlipPrtSetPaperId = SlipPrtSetPaperId_tEdit.Text.Trim();      // 印刷帳票ID
            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
            // --- ADD 2008/06/18 -------------------------------->>>>>
            dmdPrtPtn.SlipPrtKind = (int)SlipPrtKind_tComboEditor.Value;             // 伝票印刷種別
            dmdPrtPtn.SlipComment = SlipComment_tEdit.DataText;                      // 伝票コメント

            // DEL 2009/01/22 不具合対応[10250] ---------->>>>>
            //dmdPrtPtn.TopMargin = double.Parse(TopMargin_tNedit.DataText);           // 上余白
            //dmdPrtPtn.LeftMargin = double.Parse(LeftMargin_tNedit.DataText);         // 左余白
            //dmdPrtPtn.RightMargin = double.Parse(RightMargin_tNedit.DataText);       // 右余白
            //dmdPrtPtn.BottomMargin = double.Parse(BottomMargin_tNedit.DataText);     // 下余白 
            // DEL 2009/01/22 不具合対応[10250] ----------<<<<<
            // ADD 2009/01/22 不具合対応[10250] ---------->>>>>
            dmdPrtPtn.TopMargin     = ConvertDoubleNumber(TopMargin_tNedit.DataText);       // 上余白
            dmdPrtPtn.LeftMargin    = ConvertDoubleNumber(LeftMargin_tNedit.DataText);      // 左余白
            dmdPrtPtn.RightMargin   = ConvertDoubleNumber(RightMargin_tNedit.DataText);     // 右余白
            dmdPrtPtn.BottomMargin  = ConvertDoubleNumber(BottomMargin_tNedit.DataText);    // 下余白 
            // ADD 2009/01/22 不具合対応[10250] ----------<<<<<

            dmdPrtPtn.CopyCount = (int)CopyCount_tComboEditor.Value;                 // 複写枚数
            dmdPrtPtn.DmdFormTitle2 = DmdFormTitle2_tEdit.DataText;                  // 請求書タイトル２
            dmdPrtPtn.DmdDtlOutlineCode = (int)DmdDtlOutlineCode_tComboEditor.Value; // 請求明細摘要区分
            dmdPrtPtn.DmdDtlPtnOdrDiv = (int)DmdDtlPtnOdrDiv_tComboEditor.Value;     // 請求明細書印字順位区分
            dmdPrtPtn.SlipTtlPrtDiv = (int)SlipTtlPrtDiv_tComboEditor.Value;         // 伝票計印字有無
            dmdPrtPtn.AddDayTtlPrtDiv = (int)AddDayTtlPrtDiv_tComboEditor.Value;     // 計上日計印字有無
            dmdPrtPtn.CustomerTtlPrtDiv = (int)CustomerTtlPrtDiv_tComboEditor.Value; // 得意先計印字有無
            dmdPrtPtn.DtlPrcZeroPrtDiv = (int)DtlPrcZeroPrtDiv_tComboEditor.Value;   // 明細金額ゼロ時印字有無
            dmdPrtPtn.DepoDtlPrcPrtDiv = (int)DepoDtlPrcPrtDiv_tComboEditor.Value;   // 入金明細印字有無区分
            dmdPrtPtn.BillHonorificTtl = BillHonorificTtl_tEdit.DataText;            // 請求書敬称
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            dmdPrtPtn.ListPricePrtCd = (int)ListPricePrtCd_tComboEditor.Value;      // 標準価格印字区分
            dmdPrtPtn.PartsNoPrtCd = (int)PartsNoPrtCd_tComboEditor.Value;          // 品番印字区分
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END

            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            dmdPrtPtn.AnnotationPrtCd = (int)AnnotationPrtCd_tComboEditor.Value;    // 注釈印字区分
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            dmdPrtPtn.CoNmPrintOutCd = (int)CoNmPrintOutCd_tComboEditor.Value;
            // --- ADD  2011/02/16 ----------<<<<<

        }

        // ADD 2009/01/22 不具合対応[10250] ---------->>>>>
        /// <summary>
        /// double型の数値に変換します。
        /// </summary>
        /// <param name="dataText">データのテキスト</param>
        /// <returns><c>string.Empty</c>の場合、0.0を返します。</returns>
        private static double ConvertDoubleNumber(string dataText)
        {
            return string.IsNullOrEmpty(dataText) ? 0.0 : double.Parse(dataText);
        }
        // ADD 2009/01/22 不具合対応[10250] ----------<<<<<

        #endregion

        #region 画面入力許可制御処理

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="enabled">入力許可設定値</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// <br>UpdateNote : 2011/02/16 施ヘイ中</br>
        /// <br>           : 自社名印字区分を追加</br>
        /// </remarks>
        private void ScreenInputPermissionControl(bool enabled)
        {           
            //DemandPtnNo_tNedit.Enabled = enabled; //請求書パターン番号  // DEL 2008/06/18

            SlipComment_tEdit.Enabled = enabled; //請求書パターン番号名称

            // DEL 2008/11/14 不具合対応[7858] ---------->>>>>
            //DmdTtlFormTitle1_tEdit.Enabled = enabled; //請求 鑑タイトル１          
            //DmdTtlFormTitle2_tEdit.Enabled = enabled; //請求 鑑タイトル２
            //DmdTtlFormTitle3_tEdit.Enabled = enabled; //請求 鑑タイトル３
            //DmdTtlFormTitle4_tEdit.Enabled = enabled; //請求 鑑タイトル４
            //DmdTtlFormTitle5_tEdit.Enabled = enabled; //請求 鑑タイトル５
            //DmdTtlFormTitle6_tEdit.Enabled = enabled; //請求 鑑タイトル６
            //DmdTtlFormTitle7_tEdit.Enabled = enabled; //請求 鑑タイトル７
            //DmdTtlFormTitle8_tEdit.Enabled = enabled; //請求 鑑タイトル８
            //DmdTtlSetItemDiv1_tComb.Enabled = enabled; //請求 鑑設定項目区分１
            //DmdTtlSetItemDiv2_tComb.Enabled = enabled; //請求 鑑設定項目区分２
            //DmdTtlSetItemDiv3_tComb.Enabled = enabled; //請求 鑑設定項目区分３
            //DmdTtlSetItemDiv4_tComb.Enabled = enabled; //請求 鑑設定項目区分４
            //DmdTtlSetItemDiv5_tComb.Enabled = enabled; //請求 鑑設定項目区分５
            //DmdTtlSetItemDiv6_tComb.Enabled = enabled; //請求 鑑設定項目区分６
            //DmdTtlSetItemDiv7_tComb.Enabled = enabled; //請求 鑑設定項目区分７
            //DmdTtlSetItemDiv8_tComb.Enabled = enabled; //請求 鑑設定項目区分８
            // DEL 2008/11/14 不具合対応[7858] ----------<<<<<

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            PayTtlFormTitle1_tEdit.Enabled = enabled; //支払 鑑タイトル１
            PayTtlFormTitle2_tEdit.Enabled = enabled; //支払 鑑タイトル２
            PayTtlFormTitle3_tEdit.Enabled = enabled; //支払 鑑タイトル３
            PayTtlFormTitle4_tEdit.Enabled = enabled; //支払 鑑タイトル４
            PayTtlFormTitle5_tEdit.Enabled = enabled; //支払 鑑タイトル５
            PayTtlFormTitle6_tEdit.Enabled = enabled; //支払 鑑タイトル６
            PayTtlFormTitle7_tEdit.Enabled = enabled; //支払 鑑タイトル７
            PayTtlFormTitle8_tEdit.Enabled = enabled; //支払 鑑タイトル８
               --- DEL 2008/06/18 --------------------------------<<<<< */

            DmFormTitle_tEdit.Enabled = enabled; //請求書タイトル

            //PaymentFormTitle_tEdit.Enabled = enabled; //支払通知書タイトル  // DEL 2008/06/18

            DmdFormComents1_tEdit.Enabled = enabled; //請求書コメント１
            DmdFormComents2_tEdit.Enabled = enabled; //請求書コメント２
            DmdFormComents3_tEdit.Enabled = enabled; //請求書コメント３

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            DmdFmTtlGenCd1_tComb.Enabled = enabled; //請求書請求集計分類１
            DmdFmTtlGenCd2_tComb.Enabled = enabled; //請求書請求集計分類２
            DmdFmTtlGenCd3_tComb.Enabled = enabled; //請求書請求集計分類３
            DmdFmPayTtlGenCd1_tComb.Enabled = enabled; //請求書支払集計分類１
            DmdFmPayTtlGenCd2_tComb.Enabled = enabled; //請求書支払集計分類２
            DmdFmPayTtlGenCd3_tComb.Enabled = enabled; //請求書支払集計分類３
            DmdFmDmdTtlGenNm2_tEdit.Enabled = enabled; //請求書請求集計分類名称２
            DmdFmDmdTtlGenNm3_tEdit.Enabled = enabled; //請求書請求集計分類名称３
            DmdTtlGenDefNm_tEdit.Enabled = enabled; //請求集計分類デフォルト名称
            PayTtlGenDefNm_tEdit.Enabled = enabled; //支払集計分類デフォルト名称
            DmdDtUnitPrtDiv_tCombo.Enabled = enabled; //請求明細単価別出力有無
            PayDtUnitPrtDiv_tComb.Enabled = enabled; //支払明細単価別出力有無
            ThisTimeDmZeroPrDiv_tComb.Enabled = enabled; //今回請求額ゼロ時印字有無
            DmdDtPrcZeroPrDiv_tComb.Enabled = enabled; //請求明細金額ゼロ時印字有無
            PayDtPrcZeroPrDiv_tComb.Enabled = enabled; //支払明細金額ゼロ時印字有無
            MinusDmdPrtDiv_tComb.Enabled = enabled; //マイナス請求時印刷区分
            DmdFmDepoTtlPrDiv_tComb.Enabled = enabled; //請求書入金集計明細印字区分
            DmdTtlSetItemDiv1_tComb.Enabled = enabled; //請求 鑑設定項目区分１
            // CellphoneIncOutputDiv_tComb.Enabled = enabled; //機種別インセンティブ出力区分 // 2007.09.18 hikita del
            CmplDmdMdGoodsCd1_tEdit.Enabled = enabled; //強制請求出力商品区分１
            CmplDmdMdGoodsCd2_tEdit.Enabled = enabled; //強制請求出力商品区分２
            CmplDmdMdGoodsCd3_tEdit.Enabled = enabled; //強制請求出力商品区分３
            CmplDmdMdGoodsCd4_tEdit.Enabled = enabled; //強制請求出力商品区分４
            CmplDmdMdGoodsCd5_tEdit.Enabled = enabled; //強制請求出力商品区分５
            CmplDmdMdGoodsCd6_tEdit.Enabled = enabled; //強制請求出力商品区分６
            CmplDmdMdGoodsCd7_tEdit.Enabled = enabled; //強制請求出力商品区分７
            CmplDmdMdGoodsCd8_tEdit.Enabled = enabled; //強制請求出力商品区分８
            CmplDmdMdGoodsCd9_tEdit.Enabled = enabled; //強制請求出力商品区分９
            CmplDmdMdGoodsCd10_tEdit.Enabled = enabled; //強制請求出力商品区分１０
            CmplPayMdGoodsCd1_tEdit.Enabled = enabled; //強制支払出力商品区分１
            CmplPayMdGoodsCd2_tEdit.Enabled = enabled; //強制支払出力商品区分２
            CmplPayMdGoodsCd3_tEdit.Enabled = enabled; //強制支払出力商品区分３
            CmplPayMdGoodsCd4_tEdit.Enabled = enabled; //強制支払出力商品区分４
            CmplPayMdGoodsCd5_tEdit.Enabled = enabled; //強制支払出力商品区分５
            CmplPayMdGoodsCd6_tEdit.Enabled = enabled; //強制支払出力商品区分６
            CmplPayMdGoodsCd7_tEdit.Enabled = enabled; //強制支払出力商品区分７
            CmplPayMdGoodsCd8_tEdit.Enabled = enabled; //強制支払出力商品区分８
            CmplPayMdGoodsCd9_tEdit.Enabled = enabled; //強制支払出力商品区分９
            CmplPayMdGoodsCd10_tEdit.Enabled = enabled; //強制支払出力商品区分１０

            CmplDmdMdGoodsCd1_GuideButton.Enabled = enabled; //商品区分ガイド
            CmplDmdMdGoodsCd2_GuideButton.Enabled = enabled;
            CmplDmdMdGoodsCd3_GuideButton.Enabled = enabled;
            CmplDmdMdGoodsCd4_GuideButton.Enabled = enabled;
            CmplDmdMdGoodsCd5_GuideButton.Enabled = enabled;
            CmplDmdMdGoodsCd6_GuideButton.Enabled = enabled;
            CmplDmdMdGoodsCd7_GuideButton.Enabled = enabled;
            CmplDmdMdGoodsCd8_GuideButton.Enabled = enabled;
            CmplDmdMdGoodsCd9_GuideButton.Enabled = enabled;
            CmplDmdMdGoodsCd10_GuideButton.Enabled = enabled;

            CmplPayMdGoodsCd1_GuideButton.Enabled = enabled; //商品区分ガイド
            CmplPayMdGoodsCd2_GuideButton.Enabled = enabled;
            CmplPayMdGoodsCd3_GuideButton.Enabled = enabled;
            CmplPayMdGoodsCd4_GuideButton.Enabled = enabled;
            CmplPayMdGoodsCd5_GuideButton.Enabled = enabled;
            CmplPayMdGoodsCd6_GuideButton.Enabled = enabled;
            CmplPayMdGoodsCd7_GuideButton.Enabled = enabled;
            CmplPayMdGoodsCd8_GuideButton.Enabled = enabled;
            CmplPayMdGoodsCd9_GuideButton.Enabled = enabled;
            CmplPayMdGoodsCd10_GuideButton.Enabled = enabled;
               --- DEL 2008/06/18 --------------------------------<<<<< */

            //Copy_Button.Enabled = enabled;                   //コピーボタン

            // --- ADD 2008/06/18 -------------------------------->>>>>
            SlipPrtKind_tComboEditor.Enabled = enabled;        // 伝票印刷種別
            SlipComment_tEdit.Enabled = enabled;               // 伝票コメント
            TopMargin_tNedit.Enabled = enabled;                // 上余白
            LeftMargin_tNedit.Enabled = enabled;               // 左余白
            RightMargin_tNedit.Enabled = enabled;              // 右余白
            BottomMargin_tNedit.Enabled = enabled;             // 下余白 
            CopyCount_tComboEditor.Enabled = enabled;          // 複写枚数
            DmdFormTitle2_tEdit.Enabled = enabled;             // 請求書タイトル２
            DmdDtlOutlineCode_tComboEditor.Enabled = enabled;  // 請求明細摘要区分
            DmdDtlPtnOdrDiv_tComboEditor.Enabled = enabled;    // 請求明細書印字順位区分
            SlipTtlPrtDiv_tComboEditor.Enabled = enabled;      // 伝票計印字有無
            AddDayTtlPrtDiv_tComboEditor.Enabled = enabled;    // 計上日計印字有無
            CustomerTtlPrtDiv_tComboEditor.Enabled = enabled;  // 得意先計印字有無
            DtlPrcZeroPrtDiv_tComboEditor.Enabled = enabled;   // 明細金額ゼロ時印字有無
            DepoDtlPrcPrtDiv_tComboEditor.Enabled = enabled;   // 入金明細印字有無区分
            BillHonorificTtl_tEdit.Enabled = enabled;          // 請求書敬称
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            ListPricePrtCd_tComboEditor.Enabled = enabled;      // 標準価格印字区分
            PartsNoPrtCd_tComboEditor.Enabled = enabled;        // 品番印字区分
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END
            
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            AnnotationPrtCd_tComboEditor.Enabled = enabled;     // 注釈印字区分
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            CoNmPrintOutCd_tComboEditor.Enabled = enabled;
            // --- ADD  2011/02/16 ----------<<<<<
        }

        #endregion

        #region  請求印刷パターン設定オブジェクト画面展開処理
        /// <summary>
        /// 請求印刷パターン設定オブジェクト画面展開処理
        /// </summary>
        /// <param name="dmdPrtPtn">請求印刷パターン設定オブジェクト</param>
        /// <param name="mode">起動モード</param>
        /// <remarks>
        /// <br>Note       : 請求印刷パターン設定オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/04</br>
        /// <br>UpdateNote : 2011/02/16 施ヘイ中</br>
        /// <br>           : 自社名印字区分を追加</br>
        /// </remarks>
        private void DmdPrtPtnToScreen(DmdPrtPtn dmdPrtPtn, int mode)
        {
            /* --- DEL 2008/06/18 -------------------------------->>>>>
            // 各項目のセット
			if(mode == 0)
            {
                DemandPtnNo_tNedit.SetInt(dmdPrtPtn.DemandPtnNo); //請求書パターン番号
                SlipComment_tEdit.DataText = dmdPrtPtn.DemandPtnNoNm; //請求書パターン番号名称
            }           
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // DEL 2008/11/14 不具合対応[7858] ---------->>>>>
            //DmdTtlFormTitle1_tEdit.DataText = dmdPrtPtn.DmdTtlFormTitle1; //請求 鑑タイトル１
            //DmdTtlFormTitle2_tEdit.DataText = dmdPrtPtn.DmdTtlFormTitle2; //請求 鑑タイトル２
            //DmdTtlFormTitle3_tEdit.DataText = dmdPrtPtn.DmdTtlFormTitle3; //請求 鑑タイトル３
            //DmdTtlFormTitle4_tEdit.DataText = dmdPrtPtn.DmdTtlFormTitle4; //請求 鑑タイトル４
            //DmdTtlFormTitle5_tEdit.DataText = dmdPrtPtn.DmdTtlFormTitle5; //請求 鑑タイトル５
            //DmdTtlFormTitle6_tEdit.DataText = dmdPrtPtn.DmdTtlFormTitle6; //請求 鑑タイトル６
            //DmdTtlFormTitle7_tEdit.DataText = dmdPrtPtn.DmdTtlFormTitle7; //請求 鑑タイトル７
            //DmdTtlFormTitle8_tEdit.DataText = dmdPrtPtn.DmdTtlFormTitle8; //請求 鑑タイトル８

            //DmdTtlSetItemDiv1_tComb.Value = dmdPrtPtn.DmdTtlSetItemDiv1; //請求 鑑設定項目区分１
            //DmdTtlSetItemDiv2_tComb.Value = dmdPrtPtn.DmdTtlSetItemDiv2; //請求 鑑設定項目区分２
            //DmdTtlSetItemDiv3_tComb.Value = dmdPrtPtn.DmdTtlSetItemDiv3; //請求 鑑設定項目区分３
            //DmdTtlSetItemDiv4_tComb.Value = dmdPrtPtn.DmdTtlSetItemDiv4; //請求 鑑設定項目区分４
            //DmdTtlSetItemDiv5_tComb.Value = dmdPrtPtn.DmdTtlSetItemDiv5; //請求 鑑設定項目区分５
            //DmdTtlSetItemDiv6_tComb.Value = dmdPrtPtn.DmdTtlSetItemDiv6; //請求 鑑設定項目区分６
            //DmdTtlSetItemDiv7_tComb.Value = dmdPrtPtn.DmdTtlSetItemDiv7; //請求 鑑設定項目区分７
            //DmdTtlSetItemDiv8_tComb.Value = dmdPrtPtn.DmdTtlSetItemDiv8; //請求 鑑設定項目区分８
            // DEL 2008/11/14 不具合対応[7858] ----------<<<<<

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            PayTtlFormTitle1_tEdit.DataText = dmdPrtPtn.PayTtlFormTitle1; //支払 鑑タイトル１
            PayTtlFormTitle2_tEdit.DataText = dmdPrtPtn.PayTtlFormTitle2; //支払 鑑タイトル２
            PayTtlFormTitle3_tEdit.DataText = dmdPrtPtn.PayTtlFormTitle3; //支払 鑑タイトル３
            PayTtlFormTitle4_tEdit.DataText = dmdPrtPtn.PayTtlFormTitle4; //支払 鑑タイトル４
            PayTtlFormTitle5_tEdit.DataText = dmdPrtPtn.PayTtlFormTitle5; //支払 鑑タイトル５
            PayTtlFormTitle6_tEdit.DataText = dmdPrtPtn.PayTtlFormTitle6; //支払 鑑タイトル６
            PayTtlFormTitle7_tEdit.DataText = dmdPrtPtn.PayTtlFormTitle7; //支払 鑑タイトル７
            PayTtlFormTitle8_tEdit.DataText = dmdPrtPtn.PayTtlFormTitle8; //支払 鑑タイトル８
               --- DEL 2008/06/18 --------------------------------<<<<< */

            DmFormTitle_tEdit.DataText = dmdPrtPtn.DmdFormTitle; //請求書タイトル

            //PaymentFormTitle_tEdit.DataText = dmdPrtPtn.PaymentFormTitle; //支払通知書タイトル  // DEL 2008/06/18

            DmdFormComents1_tEdit.DataText = dmdPrtPtn.DmdFormComent1; //請求書コメント１
            DmdFormComents2_tEdit.DataText = dmdPrtPtn.DmdFormComent2; //請求書コメント２
            DmdFormComents3_tEdit.DataText = dmdPrtPtn.DmdFormComent3; //請求書コメント３

            /* --- DEL 2008/06/18 -------------------------------->>>>>
            DmdFmTtlGenCd1_tComb.Value = dmdPrtPtn.DmdFmDmdTtlGenCd1; //請求書請求集計分類１
            DmdFmTtlGenCd2_tComb.Value = dmdPrtPtn.DmdFmDmdTtlGenCd2; //請求書請求集計分類２
            DmdFmTtlGenCd3_tComb.Value = dmdPrtPtn.DmdFmDmdTtlGenCd3; //請求書請求集計分類３
            DmdFmPayTtlGenCd1_tComb.Value = dmdPrtPtn.DmdFmPayTtlGenCd1; //請求書支払集計分類１
            DmdFmPayTtlGenCd2_tComb.Value = dmdPrtPtn.DmdFmPayTtlGenCd2; //請求書支払集計分類２
            DmdFmPayTtlGenCd3_tComb.Value = dmdPrtPtn.DmdFmPayTtlGenCd3; //請求書支払集計分類３
            DmdFmDmdTtlGenNm2_tEdit.DataText = dmdPrtPtn.DmdFmDmdTtlGenNm2; //請求書請求集計分類名称２
            DmdFmDmdTtlGenNm3_tEdit.DataText = dmdPrtPtn.DmdFmDmdTtlGenNm3; //請求書請求集計分類名称３
            DmdTtlGenDefNm_tEdit.DataText = dmdPrtPtn.DmdTtlGenDefltNm; //請求集計分類デフォルト名称
            PayTtlGenDefNm_tEdit.DataText = dmdPrtPtn.PayTtlGenDefltNm; //支払集計分類デフォルト名称
            DmdDtUnitPrtDiv_tCombo.Value = dmdPrtPtn.DmdDtlUnitPrtDiv; //請求明細単価別出力有無
            PayDtUnitPrtDiv_tComb.Value = dmdPrtPtn.PayDtlUnitPrtDiv; //支払明細単価別出力有無
            ThisTimeDmZeroPrDiv_tComb.Value = dmdPrtPtn.ThTmDmdZeroPrtDiv; //今回請求額ゼロ時印字有無
            DmdDtPrcZeroPrDiv_tComb.Value = dmdPrtPtn.DmdDtlPrcZeroPrtDiv; //請求明細金額ゼロ時印字有無
            PayDtPrcZeroPrDiv_tComb.Value = dmdPrtPtn.PayDtlPrcZeroPrtDiv; //支払明細金額ゼロ時印字有無
            MinusDmdPrtDiv_tComb.Value = dmdPrtPtn.MinusDmdPrtDiv; //マイナス請求時印刷区分
            DmdFmDepoTtlPrDiv_tComb.Value = dmdPrtPtn.DmdFmDepoTtlPrtDiv; //請求書入金集計明細印字区分
            // CellphoneIncOutputDiv_tComb.Value = dmdPrtPtn.CellphoneIncOutDiv; //機種別インセンティブ出力区分 // 2007.09.18 hikita del
            CmplDmdMdGoodsCd1_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd1; //強制請求出力商品区分１
            CmplDmdMdGoodsCd2_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd2; //強制請求出力商品区分２
            CmplDmdMdGoodsCd3_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd3; //強制請求出力商品区分３
            CmplDmdMdGoodsCd4_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd4; //強制請求出力商品区分４
            CmplDmdMdGoodsCd5_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd5; //強制請求出力商品区分５
            CmplDmdMdGoodsCd6_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd6; //強制請求出力商品区分６
            CmplDmdMdGoodsCd7_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd7; //強制請求出力商品区分７
            CmplDmdMdGoodsCd8_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd8; //強制請求出力商品区分８
            CmplDmdMdGoodsCd9_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd9; //強制請求出力商品区分９
            CmplDmdMdGoodsCd10_tEdit.DataText = dmdPrtPtn.CmplDmdMdGoodsCd10; //強制請求出力商品区分１０
            CmplPayMdGoodsCd1_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd1; //強制支払出力商品区分１
            CmplPayMdGoodsCd2_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd2; //強制支払出力商品区分２
            CmplPayMdGoodsCd3_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd3; //強制支払出力商品区分３
            CmplPayMdGoodsCd4_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd4; //強制支払出力商品区分４
            CmplPayMdGoodsCd5_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd5; //強制支払出力商品区分５
            CmplPayMdGoodsCd6_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd6; //強制支払出力商品区分６
            CmplPayMdGoodsCd7_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd7; //強制支払出力商品区分７
            CmplPayMdGoodsCd8_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd8; //強制支払出力商品区分８
            CmplPayMdGoodsCd9_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd9; //強制支払出力商品区分９
            CmplPayMdGoodsCd10_tEdit.DataText = dmdPrtPtn.CmplPayMdGoodsCd10; //強制支払出力商品区分１０

            //TODO:
            //TODO:Eクラスに名称を持たせたほうが良いかも(StaticMemoryが使用できるなら問題ないと思うが)
            CmplDmdMdGoodsNm1_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd1); //強制請求出力商品区分１(名称)
            CmplDmdMdGoodsNm2_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd2); //強制請求出力商品区分２(名称)
            CmplDmdMdGoodsNm3_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd3); //強制請求出力商品区分３(名称)
            CmplDmdMdGoodsNm4_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd4); //強制請求出力商品区分４(名称)
            CmplDmdMdGoodsNm5_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd5); //強制請求出力商品区分５(名称)
            CmplDmdMdGoodsNm6_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd6); //強制請求出力商品区分６(名称)
            CmplDmdMdGoodsNm7_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd7); //強制請求出力商品区分７(名称)
            CmplDmdMdGoodsNm8_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd8); //強制請求出力商品区分８(名称)
            CmplDmdMdGoodsNm9_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd9); //強制請求出力商品区分９(名称)
            CmplDmdMdGoodsNm10_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplDmdMdGoodsCd10); //強制請求出力商品区分１０(名称)
           
            CmplPayMdGoodsNm1_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd1); //強制支払出力商品区分１
            CmplPayMdGoodsNm2_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd2); //強制支払出力商品区分２
            CmplPayMdGoodsNm3_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd3); //強制支払出力商品区分３
            CmplPayMdGoodsNm4_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd4); //強制支払出力商品区分４
            CmplPayMdGoodsNm5_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd5); //強制支払出力商品区分５
            CmplPayMdGoodsNm6_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd6); //強制支払出力商品区分６
            CmplPayMdGoodsNm7_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd7); //強制支払出力商品区分７
            CmplPayMdGoodsNm8_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd8); //強制支払出力商品区分８
            CmplPayMdGoodsNm9_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd9); //強制支払出力商品区分９
            CmplPayMdGoodsNm10_tEdit.DataText = GetMdGoodsName(dmdPrtPtn.CmplPayMdGoodsCd10); //強制支払出力商品区分１０
               --- DEL 2008/06/18 --------------------------------<<<<< */

            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
            DataInputSystem_tNedit.SetInt(dmdPrtPtn.DataInputSystem);           // データ入力システム
            OutputFormFileName_tEdit.Text = dmdPrtPtn.OutputFormFileName;       // 出力ファイル名
            SlipPrtSetPaperId_tEdit.Text = dmdPrtPtn.SlipPrtSetPaperId;         // 印刷帳票ID
            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
            // --- ADD 2008/06/18 -------------------------------->>>>>
            SlipPrtKind_tComboEditor.Value = dmdPrtPtn.SlipPrtKind;             // 伝票印刷種別
            SlipComment_tEdit.DataText = dmdPrtPtn.SlipComment;                 // 伝票コメント
            TopMargin_tNedit.DataText = dmdPrtPtn.TopMargin.ToString();         // 上余白
            LeftMargin_tNedit.DataText = dmdPrtPtn.LeftMargin.ToString();       // 左余白
            RightMargin_tNedit.DataText = dmdPrtPtn.RightMargin.ToString();     // 右余白
            BottomMargin_tNedit.DataText = dmdPrtPtn.BottomMargin.ToString();   // 下余白 
            CopyCount_tComboEditor.Value = dmdPrtPtn.CopyCount;                 // 複写枚数
            DmdFormTitle2_tEdit.DataText = dmdPrtPtn.DmdFormTitle2;             // 請求書タイトル２
            DmdDtlOutlineCode_tComboEditor.Value = dmdPrtPtn.DmdDtlOutlineCode; // 請求明細摘要区分
            DmdDtlPtnOdrDiv_tComboEditor.Value = dmdPrtPtn.DmdDtlPtnOdrDiv;     // 請求明細書印字順位区分
            SlipTtlPrtDiv_tComboEditor.Value = dmdPrtPtn.SlipTtlPrtDiv;         // 伝票計印字有無
            AddDayTtlPrtDiv_tComboEditor.Value = dmdPrtPtn.AddDayTtlPrtDiv;     // 計上日計印字有無
            CustomerTtlPrtDiv_tComboEditor.Value = dmdPrtPtn.CustomerTtlPrtDiv; // 得意先計印字有無
            DtlPrcZeroPrtDiv_tComboEditor.Value = dmdPrtPtn.DtlPrcZeroPrtDiv;   // 明細金額ゼロ時印字有無
            DepoDtlPrcPrtDiv_tComboEditor.Value = dmdPrtPtn.DepoDtlPrcPrtDiv;   // 入金明細印字有無区分
            BillHonorificTtl_tEdit.DataText = dmdPrtPtn.BillHonorificTtl;       // 請求書敬称
            // --- ADD 2008/06/18 --------------------------------<<<<< 

            // 2009.04.03 30413 犬飼 項目追加 >>>>>>START
            ListPricePrtCd_tComboEditor.Value = dmdPrtPtn.ListPricePrtCd;       // 標準価格印字区分
            PartsNoPrtCd_tComboEditor.Value = dmdPrtPtn.PartsNoPrtCd;           // 品番印字区分
            // 2009.04.03 30413 犬飼 項目追加 <<<<<<END
            
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            AnnotationPrtCd_tComboEditor.Value = dmdPrtPtn.AnnotationPrtCd;     // 注釈印字区分
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            CoNmPrintOutCd_tComboEditor.Value = dmdPrtPtn.CoNmPrintOutCd;
            // --- ADD  2011/02/16 ---------<<<<<

        }

        #endregion

        #region 登録処理(SaveProc)
        /// <summary>
        /// 請求印刷パターン設定オブジェクト登録処理(SaveProc())
        /// </summary>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 請求印刷パターン設定オブジェクトの登録を行います。</br>
        /// <br>Programmer : 2301 中村  仁</br>
        /// <br>Date       : 2007/07/04</br>
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string message = null;
            int tab = 0;
         
            if (!ScreenDataCheck(ref control, ref message, ref tab))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
              
                if(tab == 0)
                {
                    this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[0];
                }
                else
                {
                    this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[1];
                }
                control.Focus();
                return false;
            }

            DmdPrtPtn dmdPrtPtn = null;

            //if (this.DataIndex >= 0)  // DEL 2008/06/18
            if (this._detailsDataIndex >= 0)
            {
                // DataSetからGUIDを取得
                //int demantPatrnNo = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_DEMANDPTNNO];  // DEL 2008/06/18
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[this._detailsDataIndex][VIEW_FILEHEADERGUID];  // ADD 2008/06/18

                dmdPrtPtn = ((DmdPrtPtn)this._dmdPrtPtnRightTable[guid]).Clone();     
            }

            DispToDmdPrtPtn(ref dmdPrtPtn);

            int status = this._dmdPrtPtnAcs.Write(ref dmdPrtPtn);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
                            "MAKAU09150U", 							// アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。", 	// 表示するメッセージ
                            0, 										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン                    

                        //DemandPtnNo_tNedit.Focus();  // DEL 2008/06/18
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return false;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                            "請求書印刷パターン設定", 			// プログラム名称
                            "SaveProc", 						// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._dmdPrtPtnAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                     
                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return false;
                    }
            }

            DmdPrtPtnToDataSet(dmdPrtPtn, this._detailsDataIndex);

            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
            // 連続登録不可に変更
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
            return true;
        }

        #endregion

        #region 画面入力情報不正チェック処理
        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <param name="tab">コントロールがあるTab</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.06.05</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message,ref int tab)
        {
            bool result = true;

            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 >>>>>>START
            // 印刷帳票ID
            if (SlipPrtSetPaperId_tEdit.Text.Trim() == "")
            {
                control = this.SlipPrtSetPaperId_tEdit;
                message = this.SlipComment_Label.Text + "を入力して下さい。";
                result = false;
                tab = 0;
                return result;
            }

            // パターン名称
            if (SlipComment_tEdit.Text.Trim() == "")
            {
                control = this.SlipComment_tEdit;
                // DEL 2008/10/09 不具合対応[6479] ↓
                //message = this.SlipComment_Label.Text + "名称を入力して下さい。";
                //message = this.SlipComment_Label.Text + "を入力して下さい。";   // ADD 2008/10/09 不具合対応[6479]
                message = "パターン名称を入力して下さい。";   // ADD 2008/10/09 不具合対応[6479]
                result = false;
                tab = 0;
                return result;
            }
            // 2009.01.26 30413 犬飼 新規作成時の仕様変更 <<<<<<END
            
            /* --- DEL 2008/06/18 -------------------------------->>>>>
            //請求書パターン番号
            if (this.DemandPtnNo_tNedit.GetInt() == 0)
            {
                control = this.DemandPtnNo_tNedit;
                message = this.DemandPtnNo_Label.Text + "番号を入力して下さい。";
                result = false;
                tab = 0;
                return result;
            }
            //請求書パターン名称
            if (this.SlipComment_tEdit.Text.Trim() == "")
            {
                control = this.SlipComment_tEdit;
                message = this.DemandPtnNo_Label.Text + "名称を入力して下さい。";
                result = false;
                tab = 0;
                return result;
            }

            //商品区分
            #region 請求
            if (this.CmplDmdMdGoodsNm1_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd1_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplDmdMdGoodsNm1_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd1_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplDmdMdGoodsNm2_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd2_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplDmdMdGoodsNm2_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd2_tEdit;
                message = ALREADYDELETEMES;
                tab = 1;
                result = false;
                return result;
            }

            if(this.CmplDmdMdGoodsNm3_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd3_tEdit;
                message = NOTTARGETRECORDMES;
                tab = 1;
                result = false;
                return result;
            }
            if(this.CmplDmdMdGoodsNm3_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd3_tEdit;
                message = ALREADYDELETEMES;
                tab = 1;
                result = false;
                return result;
            }

            if(this.CmplDmdMdGoodsNm4_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd4_tEdit;
                message = NOTTARGETRECORDMES;
                tab = 1;
                result = false;
                return result;
            }
            if(this.CmplDmdMdGoodsNm4_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd4_tEdit;
                message = ALREADYDELETEMES;
                tab = 1;
                result = false;
                return result;
            }

            if(this.CmplDmdMdGoodsNm5_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd5_tEdit;
                message = NOTTARGETRECORDMES;
                tab = 1;
                result = false;
                return result;
            }
            if(this.CmplDmdMdGoodsNm5_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd5_tEdit;
                message = ALREADYDELETEMES;
                tab = 1;
                result = false;
                return result;
            }

            if(this.CmplDmdMdGoodsNm6_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd6_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplDmdMdGoodsNm6_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd6_tEdit;
                message = ALREADYDELETEMES;
                tab = 1;
                result = false;
                return result;
            }

            if(this.CmplDmdMdGoodsNm7_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd7_tEdit;
                message = NOTTARGETRECORDMES;
                tab = 1;
                result = false;
                return result;
            }
            if(this.CmplDmdMdGoodsNm7_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd7_tEdit;
                message = ALREADYDELETEMES;
                tab = 1;
                result = false;
                return result;
            }

            if(this.CmplDmdMdGoodsNm8_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd8_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplDmdMdGoodsNm8_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd8_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplDmdMdGoodsNm9_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd9_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplDmdMdGoodsNm9_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd9_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplDmdMdGoodsNm10_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplDmdMdGoodsCd10_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
             if(this.CmplDmdMdGoodsNm10_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplDmdMdGoodsCd10_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                 tab = 1;
                return result;
            }

            #endregion

            #region 支払
            if (this.CmplPayMdGoodsNm1_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd1_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplPayMdGoodsNm1_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd1_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplPayMdGoodsNm2_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd2_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplPayMdGoodsNm2_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd2_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplPayMdGoodsNm3_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd3_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplPayMdGoodsNm3_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd3_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplPayMdGoodsNm4_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd4_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplPayMdGoodsNm4_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd4_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplPayMdGoodsNm5_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd5_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplPayMdGoodsNm5_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd5_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplPayMdGoodsNm6_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd6_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplPayMdGoodsNm6_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd6_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplPayMdGoodsNm7_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd7_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplPayMdGoodsNm7_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd7_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplPayMdGoodsNm8_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd8_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplPayMdGoodsNm8_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd8_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                tab = 1;
                return result;
            }

            if(this.CmplPayMdGoodsNm9_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd9_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
            if(this.CmplPayMdGoodsNm9_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd9_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                return result;
            }

            if(this.CmplPayMdGoodsNm10_tEdit.DataText.TrimEnd() == NOTTARGETRECORD)
            {
                control = this.CmplPayMdGoodsCd10_tEdit;
                message = NOTTARGETRECORDMES;
                result = false;
                tab = 1;
                return result;
            }
             if(this.CmplPayMdGoodsNm10_tEdit.DataText.TrimEnd() == ALREADYDELETE)
            {
                control = this.CmplPayMdGoodsCd10_tEdit;
                message = ALREADYDELETEMES;
                result = false;
                 tab = 1;
                return result;
            }
           
            #endregion
               --- DEL 2008/06/18 --------------------------------<<<<< */

            return result;
        }
        #endregion


        #region Event

        #region  Form.Load
        /// <summary>
        /// Form.Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private void MAKAU09150UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();
            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // 画面初期設定処理
            ScreenInitialSetting();
        }

        #endregion

        #region Timer.Tick
 
        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007.07.03</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this._eventFlag = false;
            Initial_Timer.Enabled = false;
            ScreenReconstruction();
            this._eventFlag = true;
        }

        #endregion

        #region Form.Closing
        /// <summary>
        /// Form.Closing イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer  : 中村　仁</br>
        /// <br>Date        : 2007.07.03</br>
        /// </remarks>
        private void MAKAU09150UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //最小化フラグを初期化
            this._indexBuf = -2;
            // フォームの「×」をクリックされた場合の対応です。
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
                return;
            }
        }

        #endregion

        #region Control.VisibleChanged
        /// <summary>
        /// Control.VisibleChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private void MAKAU09150UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }
            // 自分自身が非表示になった場合、
            // またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
            if (this._indexBuf == this._detailsDataIndex)
            {
                return;
            }

            Initial_Timer.Enabled = true;
            ScreenClear();
        }

        #endregion

        #region Control.Click

        #region Save_Button
        /// <summary>
        /// Control.Click イベント(Save_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 23010 中村  仁</br>
        /// <br>Date       : 2007/07/04</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            this.Ok_Button.Focus();
            if (SaveProc() == false)
            {
                return;
            }

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            // 新規モードの場合は画面を終了せずに連続入力を可能とする
            if (this.Mode_Label.Text == INSERT_MODE)
            {
                // データインデックスを初期化する
                //this.DataIndex = -1;  // DEL 2008/06/18
                this._detailsDataIndex = -1;

                ScreenClear();

                // クローンを再度取得する
                DmdPrtPtn dmdPrtPtn = new DmdPrtPtn();

                //クローン作成
                this._dmdPrtPtnClone = dmdPrtPtn.Clone();
                DispToDmdPrtPtn(ref this._dmdPrtPtnClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                this.Ok_Button.Visible = true;
                this.Cancel_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;

                this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[0];

                /* --- DEL 2008/06/18 -------------------------------->>>>>
                //パターン番号を入力可に
                this.DemandPtnNo_tNedit.Enabled = true;
                this.DemandPtnNo_tNedit.Focus();
                this.DemandPtnNo_tNedit.SelectAll();  
                   --- DEL 2008/06/18 --------------------------------<<<<< */

                this.SlipPrtKind_tComboEditor.Focus();  // ADD 2008/06/18
            }
            else
            {              
                this.DialogResult = DialogResult.OK;

                if (CanClose == true)
                {
                    this.Close();
                }
                else
                {
                    this.Hide();
                }

                this._indexBuf = -2;                
            }
        }

        #endregion

        #region Close_Button
        /// <summary>
        /// Control.Click イベント(Close_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 23010 中村  仁</br>
        /// <br>Date       : 2007/07/04</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                //保存確認
                DmdPrtPtn compareDmdPrtPtn = new DmdPrtPtn();
                compareDmdPrtPtn = this._dmdPrtPtnClone.Clone();
                //現在の画面情報を取得する
                DispToDmdPrtPtn(ref compareDmdPrtPtn);
                //最初に取得した画面情報と比較
                if (!(this._dmdPrtPtnClone.Equals(compareDmdPrtPtn)))
                {
                    DialogResult res = 
                    TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                    "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                    null, 								// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.YesNoCancel);	// 表示するボタン
                   

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (SaveProc() == false)
                                {
                                    return;
                                }

                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        case DialogResult.No:
                            {
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }

                                break;
                            }
                        default:
                            {
                                this.Cancel_Button.Focus();
                                return;
                            }
                    }
                }
            }

            this._indexBuf = -2;

            this.DialogResult = DialogResult.Cancel;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #endregion

        #region Delete_Button
        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 23010 中村  仁</br>
        /// <br>Date       : 2006.06.05</br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);		// 表示するボタン
     
            if (result == DialogResult.OK)
            {
                //削除するインスタンスの取得
                //int demantPatrnNo = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_DEMANDPTNNO];  // DEL 2008/06/18
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[this._detailsDataIndex][VIEW_FILEHEADERGUID];  // ADD 2008/06/18

                DmdPrtPtn dmdPrtPtn = (DmdPrtPtn)this._dmdPrtPtnRightTable[guid];
             
                //DBサーバーから削除
                int status = this._dmdPrtPtnAcs.Delete(dmdPrtPtn);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            //DataSetとインスタンステーブルから削除
                            this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[this._detailsDataIndex].Delete();
                            this._dmdPrtPtnRightTable.Remove(dmdPrtPtn.FileHeaderGuid);
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status);

                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }

                    default:
                        {
                            // 物理削除
                            TMsgDisp.Show(
                                this, 								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                                "SFMIT09480U", 						// アセンブリＩＤまたはクラスＩＤ
                                "請求書印刷パターン設定", 			// プログラム名称
                                "Delete_Button_Click", 				// 処理名称
                                TMsgDisp.OPE_DELETE, 				// オペレーション
                                "削除に失敗しました。", 			// 表示するメッセージ
                                status, 							// ステータス値
                                this._dmdPrtPtnAcs, 				// エラーが発生したオブジェクト
                                MessageBoxButtons.OK, 				// 表示するボタン
                                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                          
                            if (UnDisplaying != null)
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                                UnDisplaying(this, me);
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if (CanClose == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }
                            return;
                        }
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            //画面非表示イベントを発生させる
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this._indexBuf = -2;

            this.DialogResult = DialogResult.OK;

            //画面を閉じるか、非表示にする
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #endregion

        #region Revive_Button
        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　   : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 23010 中村  仁</br>
        /// <br>Date       : 2007/07/03 </br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            //int demantPatrnNo = (int)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_DEMANDPTNNO];  // DEL 2008/06/18
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEWRIGHT_TABLE].Rows[this._detailsDataIndex][VIEW_FILEHEADERGUID];  // ADD 2008/06/18

            DmdPrtPtn dmdPrtPtn = (DmdPrtPtn)this._dmdPrtPtnRightTable[guid];

            int status = this._dmdPrtPtnAcs.Revival(ref dmdPrtPtn);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return;
                    }
                default:
                    {
                        // 復活失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                            "請求書印刷パターン設定", 			    // プログラム名称
                            "Revive_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "復活に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._dmdPrtPtnAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                       
                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return;
                    }
            }

            DmdPrtPtnToDataSet(dmdPrtPtn.Clone(), this._detailsDataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this._indexBuf = -2;

            this.DialogResult = DialogResult.OK;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #endregion

        #region Copy_Button
        /// <summary>
        /// Control.Click イベント(Copy_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　   : コピーボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 23010 中村  仁</br>
        /// <br>Date       : 2007/07/03 </br>
        /// </remarks>
        private void Copy_Button_Click(object sender, EventArgs e)
        {
            //フラグを初期化
            _eventFlag = false;

            DmdPrtPtn dmdPrtPtnd = null;
            if(this._dmdPrtPtnAcs == null)
            {
                this._dmdPrtPtnAcs = new DmdPrtPtnAcs();
            }

            int status = this._dmdPrtPtnAcs.ExecuteGuid(this._enterpriseCode, (int)SlipPrtKind_tComboEditor.Value, out dmdPrtPtnd);

            switch(status)
            {
                //取得
                case 0:
                {                  
                    if(dmdPrtPtnd != null)
                    {
                        //コピー処理
                        DmdPrtPtn _dmdPrtPtn = null;

                        //int st = this._dmdPrtPtnAcs.ReadStaticMemory(out _dmdPrtPtn,this._enterpriseCode,dmdPrtPtnd.DemandPtnNo);  // DEL 2008/06/18
                        int st = this._dmdPrtPtnAcs.ReadStaticMemory(out _dmdPrtPtn, this._enterpriseCode, (int)SlipPrtKind_tComboEditor.Value, dmdPrtPtnd.SlipPrtSetPaperId);  // ADD 2008/06/18

                        if(st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if(_dmdPrtPtn != null)
                            {
                                DmdPrtPtnToScreen(_dmdPrtPtn,1);
                            }                           
                        }                      
                    }
                    break;
                }
                //キャンセル
                case 1:
                {                  
                    break;
                }
            }

            //フラグを有効にする
            _eventFlag = true;
        }

        #endregion

        private void DepoDtlPrcPrtDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {

        }

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        #region MdGoods_GuideButton
        /// <summary>
        /// 商品区分ガイドボタンクリックイベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品区分ガイドボタンがクリックされると発生します。</br>
        /// <br>Programmer : 23001 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>    
        private void CmplDmdMdGoodsCd1_GuideButton_Click(object sender, EventArgs e)
        {
            MGoodsGanre mGoodsGanre = null;
            if(this._mGoodsGanreAcs == null)
            {
                this._mGoodsGanreAcs = new MGoodsGanreAcs();               
            }

            //TODO:引数として商品区分グループが残っている。とりあえず空文字を固定でセットしておく
            //商品区分ガイド起動
            // int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode,string.Empty,out mGoodsGanre);  // 2007.09.18 hikita del
            int status = this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode,string.Empty,out mGoodsGanre, 1);  // 2007.09.18 hikita add

            switch(status)
            {
                //取得
                case 0:
                {                  
                    if(mGoodsGanre != null)
                    {
                        //仕入商品区分
                        if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd1_GuideButton)
                        {
                            //ガイド１
                            this.CmplDmdMdGoodsCd1_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm1_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd2_GuideButton)
                        {
                            //ガイド２
                            this.CmplDmdMdGoodsCd2_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm2_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd3_GuideButton)
                        {
                            //ガイド３
                            this.CmplDmdMdGoodsCd3_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm3_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd4_GuideButton)
                        {
                            //ガイド４
                            this.CmplDmdMdGoodsCd4_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm4_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd5_GuideButton)
                        {
                            //ガイド５
                            this.CmplDmdMdGoodsCd5_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm5_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd6_GuideButton)
                        {
                            //ガイド６
                            this.CmplDmdMdGoodsCd6_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm6_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd7_GuideButton)
                        {
                            //ガイド７
                            this.CmplDmdMdGoodsCd7_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm7_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd8_GuideButton)
                        {
                            //ガイド８
                            this.CmplDmdMdGoodsCd8_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm8_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd9_GuideButton)
                        {
                            //ガイド９
                            this.CmplDmdMdGoodsCd9_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm9_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplDmdMdGoodsCd10_GuideButton)
                        {
                            //ガイド１０
                            this.CmplDmdMdGoodsCd10_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplDmdMdGoodsNm10_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        //支払商品区分
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd1_GuideButton)
                        {
                            //ガイド１
                            this.CmplPayMdGoodsCd1_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm1_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd2_GuideButton)
                        {
                            //ガイド２
                            this.CmplPayMdGoodsCd2_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm2_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd3_GuideButton)
                        {
                            //ガイド３
                            this.CmplPayMdGoodsCd3_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm3_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd4_GuideButton)
                        {
                            //ガイド４
                            this.CmplPayMdGoodsCd4_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm4_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd5_GuideButton)
                        {
                            //ガイド５
                            this.CmplPayMdGoodsCd5_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm5_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                       else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd6_GuideButton)
                        {
                            //ガイド６
                            this.CmplPayMdGoodsCd6_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm6_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd7_GuideButton)
                        {
                            //ガイド７
                            this.CmplPayMdGoodsCd7_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm7_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd8_GuideButton)
                        {
                            //ガイド８
                            this.CmplPayMdGoodsCd8_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm8_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd9_GuideButton)
                        {
                            //ガイド２
                            this.CmplPayMdGoodsCd9_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm9_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                        else if((Infragistics.Win.Misc.UltraButton)sender == this.CmplPayMdGoodsCd10_GuideButton)
                        {
                            //ガイド１０
                            this.CmplPayMdGoodsCd10_tEdit.DataText = mGoodsGanre.MediumGoodsGanreCode.TrimEnd();
                            this.CmplPayMdGoodsNm10_tEdit.DataText = mGoodsGanre.MediumGoodsGanreName;
                        }
                    }
                    break;
                }
                //キャンセル
                case 1:
                {                  
                    break;
                }
            }
        }
        #endregion
           --- DEL 2008/06/18 --------------------------------<<<<< */

        #endregion

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        #region CmplDmdMdGoodsCd.ValueChanged
        /// <summary>
        /// CmplDmdMdGoodsCd.ValueChanged イベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールのテキストが変更されたときに発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2007/07/03</br>
        /// </remarks>
        private void CmplDmdMdGoodsCd1_tEdit_VisibleChanged(object sender, EventArgs e)
        {
            if (this.CmplDmdMdGoodsCd1_tEdit.Modified == true)
            {
                this._changeFlag = true;
            }
        }
        #endregion
           --- DEL 2008/06/18 --------------------------------<<<<< */

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        #region Control.Enter(CmplDmdMdGoodsCd_tEdit)
        /// <summary>
        /// Control.Enter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 受託会社エディットにフォーカスが移ったときに発生します。</br>
        /// <br>Programmer  : 23010 中村　仁</br>
        /// <br>Date        : 2007/07/03</br>
        /// </remarks>
        private void CmplDmdMdGoodsCd1_tEdit_Enter(object sender, EventArgs e)
        {
             //コード参照用フラグ
            this._changeFlag = false;
        }

        #endregion
           --- DEL 2008/06/18 --------------------------------<<<<< */

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        #region Control.Leave(MdGoods_tEdit)
        /// <summary>
		/// Control.Leave イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 商品区分コードエディットを離れるときに発生します。</br>
		/// <br>Programmer  : 中村　仁</br>
		/// <br>Date        : 2007/07/04</br>
		/// </remarks>
        private void CmplDmdMdGoodsCd1_tEdit_Leave(object sender, EventArgs e)
        {
            if (this._changeFlag)
               {
                    this._changeFlag = false;

                    TEdit cdEdit = (TEdit)sender;
                    TEdit nmEdit = new TEdit();
                    Infragistics.Win.Misc.UltraButton guideButton = new Infragistics.Win.Misc.UltraButton();

                    if(cdEdit == CmplDmdMdGoodsCd1_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm1_tEdit;
                        guideButton = CmplDmdMdGoodsCd1_GuideButton;
                    }
                    else if(cdEdit == CmplDmdMdGoodsCd2_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm2_tEdit;
                        guideButton = CmplDmdMdGoodsCd2_GuideButton;
                    }
                    else if(cdEdit == CmplDmdMdGoodsCd3_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm3_tEdit;
                        guideButton = CmplDmdMdGoodsCd3_GuideButton;
                    }
                    else if(cdEdit == CmplDmdMdGoodsCd4_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm4_tEdit;
                        guideButton = CmplDmdMdGoodsCd4_GuideButton;
                    }
                    else if(cdEdit == CmplDmdMdGoodsCd5_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm5_tEdit;
                        guideButton = CmplDmdMdGoodsCd5_GuideButton;
                    }
                    else if(cdEdit == CmplDmdMdGoodsCd6_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm6_tEdit;
                        guideButton = CmplDmdMdGoodsCd6_GuideButton;
                    }
                      else if(cdEdit == CmplDmdMdGoodsCd7_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm7_tEdit;
                        guideButton = CmplDmdMdGoodsCd7_GuideButton;
                    }
                    else if(cdEdit == CmplDmdMdGoodsCd8_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm8_tEdit;
                        guideButton = CmplDmdMdGoodsCd8_GuideButton;
                    }
                    else if(cdEdit == CmplDmdMdGoodsCd9_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm9_tEdit;
                        guideButton = CmplDmdMdGoodsCd9_GuideButton;
                    }
                    else if(cdEdit == CmplDmdMdGoodsCd10_tEdit)
                    {
                        nmEdit = CmplDmdMdGoodsNm10_tEdit;
                        guideButton = CmplDmdMdGoodsCd10_GuideButton;
                    }
                    else if(cdEdit == CmplPayMdGoodsCd1_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm1_tEdit;
                        guideButton = CmplPayMdGoodsCd1_GuideButton;
                    }
                    else if(cdEdit == CmplPayMdGoodsCd2_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm2_tEdit;
                        guideButton = CmplPayMdGoodsCd2_GuideButton;
                    }
                    else if(cdEdit == CmplPayMdGoodsCd3_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm3_tEdit;
                        guideButton = CmplPayMdGoodsCd3_GuideButton;
                    }
                     else if(cdEdit == CmplPayMdGoodsCd4_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm4_tEdit;
                        guideButton = CmplPayMdGoodsCd4_GuideButton;
                    }
                    else if(cdEdit == CmplPayMdGoodsCd5_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm5_tEdit;
                        guideButton = CmplPayMdGoodsCd5_GuideButton;
                    }
                    else if(cdEdit == CmplPayMdGoodsCd6_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm6_tEdit;
                        guideButton = CmplPayMdGoodsCd6_GuideButton;
                    }
                    else if(cdEdit == CmplPayMdGoodsCd7_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm7_tEdit;
                        guideButton = CmplPayMdGoodsCd7_GuideButton;
                    }
                    else if(cdEdit == CmplPayMdGoodsCd8_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm8_tEdit;
                        guideButton = CmplPayMdGoodsCd8_GuideButton;
                    }
                    else if(cdEdit == CmplPayMdGoodsCd9_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm9_tEdit;
                        guideButton = CmplPayMdGoodsCd9_GuideButton;
                    }
                    else if(cdEdit == CmplPayMdGoodsCd10_tEdit)
                    {
                        nmEdit = CmplPayMdGoodsNm10_tEdit;
                        guideButton = CmplPayMdGoodsCd10_GuideButton;
                    }

                    if(cdEdit.DataText != string.Empty)
                    {
                        int st = 0;
                        MGoodsGanre mGoodsGanre = null;
                        //TODO:ReadStaticで判定する
                        this._mGoodsGanreAcs.IsLocalDBRead = true;
                        // st = this._mGoodsGanreAcs.Read(out mGoodsGanre,this._enterpriseCode,String.Empty,cdEdit.DataText.TrimEnd(),0);  // 2007.09.18 hikita del
                        st = this._mGoodsGanreAcs.Read(out mGoodsGanre,this._enterpriseCode,String.Empty,cdEdit.DataText.TrimEnd());       // 2007.09.18 hikita add

                        if(st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if(mGoodsGanre.LogicalDeleteCode == 1)
                            {
                                //マスタから論理
                                //該当レコードが存在しない
                                TMsgDisp.Show(
                                emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                                "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                                ALREADYDELETEMES, 	// 表示内容
                                0,                                  // ステータス
                                MessageBoxButtons.OK, 				// 表示するボタン
                                MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                                cdEdit.Clear();
                                nmEdit.Clear();
                            }
                            else
                            {
                                nmEdit.DataText = GetMdGoodsName(cdEdit.DataText.TrimEnd());
                            }
                        }
                        else if(st == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || st == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            //マスタに存在しない
                            //該当レコードが存在しない
                            TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                            "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                            "該当レコードが存在しません。", 	// 表示内容
                            0,                                  // ステータス
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                            cdEdit.Clear();
                            nmEdit.Clear();
                        }
                        else if(st == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                        {
                            //マスタに存在しない
                            //該当レコードが存在しない
                            TMsgDisp.Show(
                            emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                            "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                            ALREADYDELETEMES, 	// 表示内容
                            0,                                  // ステータス
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                            cdEdit.Clear();
                            nmEdit.Clear();
                        }


                        //if(GetMdGoodsName(cdEdit.DataText.TrimEnd()) == string.Empty)
                        //{
                        //    //マスタに存在しない
                        //    //該当レコードが存在しない
                        //    TMsgDisp.Show(
                        //    emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
                        //    "MAKAU09150U", 						// アセンブリＩＤまたはクラスＩＤ
                        //    "該当レコードが存在しません。", 	// 表示内容
                        //    0,                                  // ステータス
                        //    MessageBoxButtons.OK, 				// 表示するボタン
                        //    MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        //    cdEdit.Clear();
                        //    nmEdit.Clear();
                        //}
                        //else
                        //{                          
                        //    nmEdit.DataText = GetMdGoodsName(cdEdit.DataText.TrimEnd());
                        //}                       
                    }
                    else
                    {
                        cdEdit.Clear();
                        nmEdit.Clear();
                    }
                    guideButton.Focus();
                }
            }

        #endregion
           --- DEL 2008/06/18 --------------------------------<<<<< */

        #region Control.ValueChanged

        /* --- DEL 2008/06/18 -------------------------------->>>>>
        #region MdGoods_tEdit
        /// <summary>
		/// Control.ValueChanged イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 商品区分コードの値がユーザーによって変更された時に発生します</br>
		/// <br>Programmer  : 中村　仁</br>
		/// <br>Date        : 2007/07/04</br>
		/// </remarks>
        private void CmplDmdMdGoodsCd1_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit edit = new TEdit();
            edit = (TEdit)sender;

            if(edit.Modified == true)
            {
                this._changeFlag = true;
            }
        }

        #endregion
           --- DEL 2008/06/18 --------------------------------<<<<< */

        #region DmdTtlSetItemDiv_tComb
        // DEL 2008/11/14 不具合対応[7858] ---------->>>>>
        ///// <summary>
        ///// Control.ValueChanged イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note　　　  : 商品区分コードの値がユーザーによって変更された時に発生します</br>
        ///// <br>Programmer  : 中村　仁</br>
        ///// <br>Date        : 2007/07/04</br>
        ///// </remarks>
        //private void DmdTtlSetItemDiv1_tComb_ValueChanged(object sender, EventArgs e)
        //{       
        //    if(_eventFlag)
        //    {
        //        TComboEditor tComb = (TComboEditor)sender;
        //        TEdit edit1 = new TEdit();
        //        //TEdit edit2 = new TEdit();  // DEL 2008/06/18

        //        if(tComb == DmdTtlSetItemDiv1_tComb)
        //        {
        //            edit1 = DmdTtlFormTitle1_tEdit;
        //            //edit2 = PayTtlFormTitle1_tEdit;  // DEL 2008/06/18
        //        }
        //        else if(tComb == DmdTtlSetItemDiv2_tComb)
        //        {
        //            edit1 = DmdTtlFormTitle2_tEdit;
        //            //edit2 = PayTtlFormTitle2_tEdit;  // DEL 2008/06/18
        //        }
        //        else if(tComb == DmdTtlSetItemDiv3_tComb)
        //        {
        //            edit1 = DmdTtlFormTitle3_tEdit;
        //            //edit2 = PayTtlFormTitle3_tEdit;  // DEL 2008/06/18
        //        }
        //        else if(tComb == DmdTtlSetItemDiv4_tComb)
        //        {
        //            edit1 = DmdTtlFormTitle4_tEdit;
        //            //edit2 = PayTtlFormTitle4_tEdit;  // DEL 2008/06/18
        //        }
        //        else if(tComb == DmdTtlSetItemDiv5_tComb)
        //        {
        //            edit1 = DmdTtlFormTitle5_tEdit;
        //            //edit2 = PayTtlFormTitle5_tEdit;  // DEL 2008/06/18
        //        }
        //        else if(tComb == DmdTtlSetItemDiv6_tComb)
        //        {
        //            edit1 = DmdTtlFormTitle6_tEdit;
        //            //edit2 = PayTtlFormTitle6_tEdit;  // DEL 2008/06/18
        //        }
        //        else if(tComb == DmdTtlSetItemDiv7_tComb)
        //        {
        //            edit1 = DmdTtlFormTitle7_tEdit;
        //            //edit2 = PayTtlFormTitle7_tEdit;  // DEL 2008/06/18
        //        }
        //        else if(tComb == DmdTtlSetItemDiv8_tComb)
        //        {
        //            edit1 = DmdTtlFormTitle8_tEdit;
        //            //edit2 = PayTtlFormTitle8_tEdit;  // DEL 2008/06/18
        //        }

        //        if((int)tComb.Value == (int)DmdTtlSetItemDiv.None)
        //        {
        //            //未使用の場合は名称をクリア
        //            edit1.Clear();
        //            //edit2.Clear();  // DEL 2008/06/18
        //        }
        //        else
        //        {
        //            edit1.DataText = GetSetItemDivNm((int)tComb.Value);
        //            //edit2.DataText = GetSetItemDivNm((int)tComb.Value);  // DEL 2008/06/18
        //        }
        //    }
        //}
        // DEL 2008/11/14 不具合対応[7858] ----------<<<<<
        #endregion


        /* --- DEL 2008/06/18 -------------------------------->>>>>
        #region DmdFmTtlGenCd2_tComb
        /// <summary>
		/// Control.ValueChanged イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 商品区分コードの値がユーザーによって変更された時に発生します</br>
		/// <br>Programmer  : 中村　仁</br>
		/// <br>Date        : 2007/07/09</br>
		/// </remarks>
        private void DmdFmTtlGenCd2_tComb_ValueChanged(object sender, EventArgs e)
        {
            if(_eventFlag)
            {
                TComboEditor tComb = (TComboEditor)sender;
                TEdit edit1 = new TEdit();              

                if(tComb == DmdFmTtlGenCd2_tComb)
                {
                    edit1 = DmdFmDmdTtlGenNm2_tEdit;                   
                }
                else if(tComb == DmdFmTtlGenCd3_tComb)
                {
                    edit1 = DmdFmDmdTtlGenNm3_tEdit;                 
                }             

                if((int)tComb.Value == (int)DmdFmTtlGenCd.None)
                {
                    //未使用の場合は名称をクリア
                    edit1.Clear();
                }
                else
                {
                    edit1.DataText = GetDmdFmGenCdNm((int)tComb.Value);
                }
            }
        }
        #endregion
           --- DEL 2008/06/18 --------------------------------<<<<< */

        #endregion

        #endregion
    }
}
