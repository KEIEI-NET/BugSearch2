using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePStockMoveSlipWork
    /// <summary>
    ///                      自由帳票在庫移動伝票データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票在庫移動伝票データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/01/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePStockMoveSlipWork
    {
        /// <summary>在庫移動形式</summary>
        /// <remarks>1:在庫移動、2：倉庫移動</remarks>
        private Int32 _mOVH_STOCKMOVEFORMALRF;

        /// <summary>在庫移動伝票番号</summary>
        private Int32 _mOVH_STOCKMOVESLIPNORF;

        /// <summary>移動元拠点コード</summary>
        private string _mOVH_BFSECTIONCODERF = "";

        /// <summary>移動元拠点ガイド略称</summary>
        private string _mOVH_BFSECTIONGUIDESNMRF = "";

        /// <summary>移動元倉庫コード</summary>
        private string _mOVH_BFENTERWAREHCODERF = "";

        /// <summary>移動元倉庫名称</summary>
        private string _mOVH_BFENTERWAREHNAMERF = "";

        /// <summary>移動先拠点コード</summary>
        private string _mOVH_AFSECTIONCODERF = "";

        /// <summary>移動先拠点ガイド略称</summary>
        private string _mOVH_AFSECTIONGUIDESNMRF = "";

        /// <summary>移動先倉庫コード</summary>
        private string _mOVH_AFENTERWAREHCODERF = "";

        /// <summary>移動先倉庫名称</summary>
        private string _mOVH_AFENTERWAREHNAMERF = "";

        /// <summary>出荷予定日</summary>
        /// <remarks>在庫移動処理（出荷側）を行った時にセット</remarks>
        private Int32 _mOVH_SHIPMENTSCDLDAYRF;

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private Int32 _mOVH_INPUTDAYRF;

        /// <summary>在庫移動入力従業員コード</summary>
        /// <remarks>在庫移動伝票を入力する従業員コードをセット</remarks>
        private string _mOVH_STOCKMVEMPCODERF = "";

        /// <summary>在庫移動入力従業員名称</summary>
        private string _mOVH_STOCKMVEMPNAMERF = "";

        /// <summary>出荷担当従業員コード</summary>
        /// <remarks>出荷確定処理を行う従業員コードをセット</remarks>
        private string _mOVH_SHIPAGENTCDRF = "";

        /// <summary>出荷担当従業員名称</summary>
        private string _mOVH_SHIPAGENTNMRF = "";

        /// <summary>引取担当従業員コード</summary>
        /// <remarks>在庫の入荷側の従業員コードをセット</remarks>
        private string _mOVH_RECEIVEAGENTCDRF = "";

        /// <summary>引取担当従業員名称</summary>
        private string _mOVH_RECEIVEAGENTNMRF = "";

        /// <summary>伝票摘要</summary>
        private string _mOVH_OUTLINERF = "";

        /// <summary>倉庫備考1</summary>
        /// <remarks>在庫移動時の移動伝票に出力する備考をセット</remarks>
        private string _mOVH_WAREHOUSENOTE1RF = "";

        /// <summary>伝票発行済区分</summary>
        /// <remarks>0:未発行 1:発行済</remarks>
        private Int32 _mOVH_SLIPPRINTFINISHCDRF;

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sEC1_SECTIONGUIDENMRF = "";

        /// <summary>自社名称コード1</summary>
        private Int32 _sEC1_COMPANYNAMECD1RF;

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sEC2_SECTIONGUIDENMRF = "";

        /// <summary>自社名称コード1</summary>
        private Int32 _sEC2_COMPANYNAMECD1RF;

        /// <summary>自社名称1</summary>
        private string _cOMPANYINFRF_COMPANYNAME1RF = "";

        /// <summary>自社名称2</summary>
        private string _cOMPANYINFRF_COMPANYNAME2RF = "";

        /// <summary>郵便番号</summary>
        private string _cOMPANYINFRF_POSTNORF = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        private string _cOMPANYINFRF_ADDRESS1RF = "";

        /// <summary>住所3（番地）</summary>
        private string _cOMPANYINFRF_ADDRESS3RF = "";

        /// <summary>住所4（アパート名称）</summary>
        private string _cOMPANYINFRF_ADDRESS4RF = "";

        /// <summary>自社電話番号1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYINFRF_COMPANYTELNO1RF = "";

        /// <summary>自社電話番号2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYINFRF_COMPANYTELNO2RF = "";

        /// <summary>自社電話番号3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYINFRF_COMPANYTELNO3RF = "";

        /// <summary>自社電話番号タイトル1</summary>
        /// <remarks>TEL</remarks>
        private string _cOMPANYINFRF_COMPANYTELTITLE1RF = "";

        /// <summary>自社電話番号タイトル2</summary>
        /// <remarks>TEL2</remarks>
        private string _cOMPANYINFRF_COMPANYTELTITLE2RF = "";

        /// <summary>自社電話番号タイトル3</summary>
        /// <remarks>FAX</remarks>
        private string _cOMPANYINFRF_COMPANYTELTITLE3RF = "";

        /// <summary>自社PR文</summary>
        private string _cMP1_COMPANYPRRF = "";

        /// <summary>自社名称1</summary>
        private string _cMP1_COMPANYNAME1RF = "";

        /// <summary>自社名称2</summary>
        private string _cMP1_COMPANYNAME2RF = "";

        /// <summary>郵便番号</summary>
        private string _cMP1_POSTNORF = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        private string _cMP1_ADDRESS1RF = "";

        /// <summary>住所3（番地）</summary>
        private string _cMP1_ADDRESS3RF = "";

        /// <summary>住所4（アパート名称）</summary>
        private string _cMP1_ADDRESS4RF = "";

        /// <summary>自社電話番号1</summary>
        /// <remarks>TEL</remarks>
        private string _cMP1_COMPANYTELNO1RF = "";

        /// <summary>自社電話番号2</summary>
        /// <remarks>TEL2</remarks>
        private string _cMP1_COMPANYTELNO2RF = "";

        /// <summary>自社電話番号3</summary>
        /// <remarks>FAX</remarks>
        private string _cMP1_COMPANYTELNO3RF = "";

        /// <summary>自社電話番号タイトル1</summary>
        /// <remarks>TEL</remarks>
        private string _cMP1_COMPANYTELTITLE1RF = "";

        /// <summary>自社電話番号タイトル2</summary>
        /// <remarks>TEL2</remarks>
        private string _cMP1_COMPANYTELTITLE2RF = "";

        /// <summary>自社電話番号タイトル3</summary>
        /// <remarks>FAX</remarks>
        private string _cMP1_COMPANYTELTITLE3RF = "";

        /// <summary>銀行振込案内文</summary>
        private string _cMP1_TRANSFERGUIDANCERF = "";

        /// <summary>銀行口座1</summary>
        private string _cMP1_ACCOUNTNOINFO1RF = "";

        /// <summary>銀行口座2</summary>
        private string _cMP1_ACCOUNTNOINFO2RF = "";

        /// <summary>銀行口座3</summary>
        private string _cMP1_ACCOUNTNOINFO3RF = "";

        /// <summary>自社設定摘要1</summary>
        private string _cMP1_COMPANYSETNOTE1RF = "";

        /// <summary>自社設定摘要2</summary>
        private string _cMP1_COMPANYSETNOTE2RF = "";

        /// <summary>画像情報区分</summary>
        /// <remarks>10:自社画像,20:POSで使用する画像</remarks>
        private Int32 _cMP1_IMAGEINFODIVRF;

        /// <summary>画像情報コード</summary>
        private Int32 _cMP1_IMAGEINFOCODERF;

        /// <summary>自社URL</summary>
        private string _cMP1_COMPANYURLRF = "";

        /// <summary>自社PR文2</summary>
        /// <remarks>代表取締役等の情報を入力</remarks>
        private string _cMP1_COMPANYPRSENTENCE2RF = "";

        /// <summary>画像印字用コメント1</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _cMP1_IMAGECOMMENTFORPRT1RF = "";

        /// <summary>画像印字用コメント2</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _cMP1_IMAGECOMMENTFORPRT2RF = "";

        /// <summary>自社PR文</summary>
        private string _cMP2_COMPANYPRRF = "";

        /// <summary>自社名称1</summary>
        private string _cMP2_COMPANYNAME1RF = "";

        /// <summary>自社名称2</summary>
        private string _cMP2_COMPANYNAME2RF = "";

        /// <summary>郵便番号</summary>
        private string _cMP2_POSTNORF = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        private string _cMP2_ADDRESS1RF = "";

        /// <summary>住所3（番地）</summary>
        private string _cMP2_ADDRESS3RF = "";

        /// <summary>住所4（アパート名称）</summary>
        private string _cMP2_ADDRESS4RF = "";

        /// <summary>自社電話番号1</summary>
        /// <remarks>TEL</remarks>
        private string _cMP2_COMPANYTELNO1RF = "";

        /// <summary>自社電話番号2</summary>
        /// <remarks>TEL2</remarks>
        private string _cMP2_COMPANYTELNO2RF = "";

        /// <summary>自社電話番号3</summary>
        /// <remarks>FAX</remarks>
        private string _cMP2_COMPANYTELNO3RF = "";

        /// <summary>自社電話番号タイトル1</summary>
        /// <remarks>TEL</remarks>
        private string _cMP2_COMPANYTELTITLE1RF = "";

        /// <summary>自社電話番号タイトル2</summary>
        /// <remarks>TEL2</remarks>
        private string _cMP2_COMPANYTELTITLE2RF = "";

        /// <summary>自社電話番号タイトル3</summary>
        /// <remarks>FAX</remarks>
        private string _cMP2_COMPANYTELTITLE3RF = "";

        /// <summary>銀行振込案内文</summary>
        private string _cMP2_TRANSFERGUIDANCERF = "";

        /// <summary>銀行口座1</summary>
        private string _cMP2_ACCOUNTNOINFO1RF = "";

        /// <summary>銀行口座2</summary>
        private string _cMP2_ACCOUNTNOINFO2RF = "";

        /// <summary>銀行口座3</summary>
        private string _cMP2_ACCOUNTNOINFO3RF = "";

        /// <summary>自社設定摘要1</summary>
        private string _cMP2_COMPANYSETNOTE1RF = "";

        /// <summary>自社設定摘要2</summary>
        private string _cMP2_COMPANYSETNOTE2RF = "";

        /// <summary>自社URL</summary>
        private string _cMP2_COMPANYURLRF = "";

        /// <summary>自社PR文2</summary>
        /// <remarks>代表取締役等の情報を入力</remarks>
        private string _cMP2_COMPANYPRSENTENCE2RF = "";

        /// <summary>画像印字用コメント1</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _cMP2_IMAGECOMMENTFORPRT1RF = "";

        /// <summary>画像印字用コメント2</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _cMP2_IMAGECOMMENTFORPRT2RF = "";

        /// <summary>カナ</summary>
        private string _eMP1_KANARF = "";

        /// <summary>短縮名称</summary>
        private string _eMP1_SHORTNAMERF = "";

        /// <summary>カナ</summary>
        private string _eMP2_KANARF = "";

        /// <summary>短縮名称</summary>
        private string _eMP2_SHORTNAMERF = "";

        /// <summary>カナ</summary>
        private string _eMP3_KANARF = "";

        /// <summary>短縮名称</summary>
        private string _eMP3_SHORTNAMERF = "";

        /// <summary>画像情報データ</summary>
        private Byte[] _iMAGEINFORF_IMAGEINFODATARF;

        /// <summary>在庫移動形式名称</summary>
        /// <remarks>1:在庫移動、2：倉庫移動</remarks>
        private string _hADD_STOCKMOVEFORMALNMRF = "";

        /// <summary>出荷予定日西暦年</summary>
        private Int32 _hADD_SHIPMENTSCDLDFYRF;

        /// <summary>出荷予定日西暦年略</summary>
        private Int32 _hADD_SHIPMENTSCDLDFSRF;

        /// <summary>出荷予定日和暦年</summary>
        private Int32 _hADD_SHIPMENTSCDLDFWRF;

        /// <summary>出荷予定日月</summary>
        private Int32 _hADD_SHIPMENTSCDLDFMRF;

        /// <summary>出荷予定日日</summary>
        private Int32 _hADD_SHIPMENTSCDLDFDRF;

        /// <summary>出荷予定日元号</summary>
        private string _hADD_SHIPMENTSCDLDFGRF = "";

        /// <summary>出荷予定日略号</summary>
        private string _hADD_SHIPMENTSCDLDFRRF = "";

        /// <summary>出荷予定日リテラル(/)</summary>
        private string _hADD_SHIPMENTSCDLDFLSRF = "";

        /// <summary>出荷予定日リテラル(.)</summary>
        private string _hADD_SHIPMENTSCDLDFLPRF = "";

        /// <summary>出荷予定日リテラル(年)</summary>
        private string _hADD_SHIPMENTSCDLDFLYRF = "";

        /// <summary>出荷予定日リテラル(月)</summary>
        private string _hADD_SHIPMENTSCDLDFLMRF = "";

        /// <summary>出荷予定日リテラル(日)</summary>
        private string _hADD_SHIPMENTSCDLDFLDRF = "";

        /// <summary>入力日西暦年</summary>
        private Int32 _hADD_INPUTDFYRF;

        /// <summary>入力日西暦年略</summary>
        private Int32 _hADD_INPUTDFSRF;

        /// <summary>入力日和暦年</summary>
        private Int32 _hADD_INPUTDFWRF;

        /// <summary>入力日月</summary>
        private Int32 _hADD_INPUTDFMRF;

        /// <summary>入力日日</summary>
        private Int32 _hADD_INPUTDFDRF;

        /// <summary>入力日元号</summary>
        private string _hADD_INPUTDFGRF = "";

        /// <summary>入力日略号</summary>
        private string _hADD_INPUTDFRRF = "";

        /// <summary>入力日リテラル(/)</summary>
        private string _hADD_INPUTDFLSRF = "";

        /// <summary>入力日リテラル(.)</summary>
        private string _hADD_INPUTDFLPRF = "";

        /// <summary>入力日リテラル(年)</summary>
        private string _hADD_INPUTDFLYRF = "";

        /// <summary>入力日リテラル(月)</summary>
        private string _hADD_INPUTDFLMRF = "";

        /// <summary>入力日リテラル(日)</summary>
        private string _hADD_INPUTDFLDRF = "";

        /// <summary>自社備考１</summary>
        private string _hADD_NOTE1RF = "";

        /// <summary>自社備考２</summary>
        private string _hADD_NOTE2RF = "";

        /// <summary>自社備考３</summary>
        private string _hADD_NOTE3RF = "";

        /// <summary>再発行マーク</summary>
        private string _hADD_REISSUEMARKRF = "";

        /// <summary>プリンタ管理No</summary>
        /// <remarks>※このレコードの伝票を印刷するプリンタの決定結果(default)</remarks>
        private Int32 _hADD_PRINTERMNGNORF;

        /// <summary>伝票印刷設定用帳票ID</summary>
        /// <remarks>※このレコードの伝票を印刷する伝票タイプの決定結果(default)</remarks>
        private string _hADD_SLIPPRTSETPAPERIDRF = "";

        /// <summary>印刷時刻 時</summary>
        /// <remarks>HH</remarks>
        private Int32 _hADD_PRINTTIMEHOURRF;

        /// <summary>印刷時刻 分</summary>
        /// <remarks>MM</remarks>
        private Int32 _hADD_PRINTTIMEMINUTERF;

        /// <summary>印刷時刻 秒</summary>
        /// <remarks>DD</remarks>
        private Int32 _hADD_PRINTTIMESECONDRF;

        /// <summary>伝票合計金額</summary>
        /// <remarks>【仕入単価×移動数】</remarks>
        private Int64 _hADD_TTLSTOCKMOVEPRICERF;

        /// <summary>伝票合計金額(標準価格)</summary>
        /// <remarks>【定価×移動数】</remarks>
        private Int64 _hADD_TTLSTOCKMOVELISTPRICERF;

        /// <summary>入力拠点コード</summary>
        private string _mOVH_UPDATESECCDRF = "";

        /// <summary>入力拠点ガイド略称</summary>
        private string _sEC0_SECTIONGUIDESNMRF = "";

        /// <summary>入力拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sEC0_SECTIONGUIDENMRF = "";


        /// public propaty name  :  MOVH_STOCKMOVEFORMALRF
        /// <summary>在庫移動形式プロパティ</summary>
        /// <value>1:在庫移動、2：倉庫移動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVH_STOCKMOVEFORMALRF
        {
            get { return _mOVH_STOCKMOVEFORMALRF; }
            set { _mOVH_STOCKMOVEFORMALRF = value; }
        }

        /// public propaty name  :  MOVH_STOCKMOVESLIPNORF
        /// <summary>在庫移動伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVH_STOCKMOVESLIPNORF
        {
            get { return _mOVH_STOCKMOVESLIPNORF; }
            set { _mOVH_STOCKMOVESLIPNORF = value; }
        }

        /// public propaty name  :  MOVH_BFSECTIONCODERF
        /// <summary>移動元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_BFSECTIONCODERF
        {
            get { return _mOVH_BFSECTIONCODERF; }
            set { _mOVH_BFSECTIONCODERF = value; }
        }

        /// public propaty name  :  MOVH_BFSECTIONGUIDESNMRF
        /// <summary>移動元拠点ガイド略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_BFSECTIONGUIDESNMRF
        {
            get { return _mOVH_BFSECTIONGUIDESNMRF; }
            set { _mOVH_BFSECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  MOVH_BFENTERWAREHCODERF
        /// <summary>移動元倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_BFENTERWAREHCODERF
        {
            get { return _mOVH_BFENTERWAREHCODERF; }
            set { _mOVH_BFENTERWAREHCODERF = value; }
        }

        /// public propaty name  :  MOVH_BFENTERWAREHNAMERF
        /// <summary>移動元倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_BFENTERWAREHNAMERF
        {
            get { return _mOVH_BFENTERWAREHNAMERF; }
            set { _mOVH_BFENTERWAREHNAMERF = value; }
        }

        /// public propaty name  :  MOVH_AFSECTIONCODERF
        /// <summary>移動先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_AFSECTIONCODERF
        {
            get { return _mOVH_AFSECTIONCODERF; }
            set { _mOVH_AFSECTIONCODERF = value; }
        }

        /// public propaty name  :  MOVH_AFSECTIONGUIDESNMRF
        /// <summary>移動先拠点ガイド略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_AFSECTIONGUIDESNMRF
        {
            get { return _mOVH_AFSECTIONGUIDESNMRF; }
            set { _mOVH_AFSECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  MOVH_AFENTERWAREHCODERF
        /// <summary>移動先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_AFENTERWAREHCODERF
        {
            get { return _mOVH_AFENTERWAREHCODERF; }
            set { _mOVH_AFENTERWAREHCODERF = value; }
        }

        /// public propaty name  :  MOVH_AFENTERWAREHNAMERF
        /// <summary>移動先倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_AFENTERWAREHNAMERF
        {
            get { return _mOVH_AFENTERWAREHNAMERF; }
            set { _mOVH_AFENTERWAREHNAMERF = value; }
        }

        /// public propaty name  :  MOVH_SHIPMENTSCDLDAYRF
        /// <summary>出荷予定日プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVH_SHIPMENTSCDLDAYRF
        {
            get { return _mOVH_SHIPMENTSCDLDAYRF; }
            set { _mOVH_SHIPMENTSCDLDAYRF = value; }
        }

        /// public propaty name  :  MOVH_INPUTDAYRF
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVH_INPUTDAYRF
        {
            get { return _mOVH_INPUTDAYRF; }
            set { _mOVH_INPUTDAYRF = value; }
        }

        /// public propaty name  :  MOVH_STOCKMVEMPCODERF
        /// <summary>在庫移動入力従業員コードプロパティ</summary>
        /// <value>在庫移動伝票を入力する従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動入力従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_STOCKMVEMPCODERF
        {
            get { return _mOVH_STOCKMVEMPCODERF; }
            set { _mOVH_STOCKMVEMPCODERF = value; }
        }

        /// public propaty name  :  MOVH_STOCKMVEMPNAMERF
        /// <summary>在庫移動入力従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動入力従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_STOCKMVEMPNAMERF
        {
            get { return _mOVH_STOCKMVEMPNAMERF; }
            set { _mOVH_STOCKMVEMPNAMERF = value; }
        }

        /// public propaty name  :  MOVH_SHIPAGENTCDRF
        /// <summary>出荷担当従業員コードプロパティ</summary>
        /// <value>出荷確定処理を行う従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_SHIPAGENTCDRF
        {
            get { return _mOVH_SHIPAGENTCDRF; }
            set { _mOVH_SHIPAGENTCDRF = value; }
        }

        /// public propaty name  :  MOVH_SHIPAGENTNMRF
        /// <summary>出荷担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_SHIPAGENTNMRF
        {
            get { return _mOVH_SHIPAGENTNMRF; }
            set { _mOVH_SHIPAGENTNMRF = value; }
        }

        /// public propaty name  :  MOVH_RECEIVEAGENTCDRF
        /// <summary>引取担当従業員コードプロパティ</summary>
        /// <value>在庫の入荷側の従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引取担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_RECEIVEAGENTCDRF
        {
            get { return _mOVH_RECEIVEAGENTCDRF; }
            set { _mOVH_RECEIVEAGENTCDRF = value; }
        }

        /// public propaty name  :  MOVH_RECEIVEAGENTNMRF
        /// <summary>引取担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引取担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_RECEIVEAGENTNMRF
        {
            get { return _mOVH_RECEIVEAGENTNMRF; }
            set { _mOVH_RECEIVEAGENTNMRF = value; }
        }

        /// public propaty name  :  MOVH_OUTLINERF
        /// <summary>伝票摘要プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_OUTLINERF
        {
            get { return _mOVH_OUTLINERF; }
            set { _mOVH_OUTLINERF = value; }
        }

        /// public propaty name  :  MOVH_WAREHOUSENOTE1RF
        /// <summary>倉庫備考1プロパティ</summary>
        /// <value>在庫移動時の移動伝票に出力する備考をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_WAREHOUSENOTE1RF
        {
            get { return _mOVH_WAREHOUSENOTE1RF; }
            set { _mOVH_WAREHOUSENOTE1RF = value; }
        }

        /// public propaty name  :  MOVH_SLIPPRINTFINISHCDRF
        /// <summary>伝票発行済区分プロパティ</summary>
        /// <value>0:未発行 1:発行済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行済区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MOVH_SLIPPRINTFINISHCDRF
        {
            get { return _mOVH_SLIPPRINTFINISHCDRF; }
            set { _mOVH_SLIPPRINTFINISHCDRF = value; }
        }

        /// public propaty name  :  SEC1_SECTIONGUIDENMRF
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SEC1_SECTIONGUIDENMRF
        {
            get { return _sEC1_SECTIONGUIDENMRF; }
            set { _sEC1_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SEC1_COMPANYNAMECD1RF
        /// <summary>自社名称コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SEC1_COMPANYNAMECD1RF
        {
            get { return _sEC1_COMPANYNAMECD1RF; }
            set { _sEC1_COMPANYNAMECD1RF = value; }
        }

        /// public propaty name  :  SEC2_SECTIONGUIDENMRF
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SEC2_SECTIONGUIDENMRF
        {
            get { return _sEC2_SECTIONGUIDENMRF; }
            set { _sEC2_SECTIONGUIDENMRF = value; }
        }

        /// public propaty name  :  SEC2_COMPANYNAMECD1RF
        /// <summary>自社名称コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SEC2_COMPANYNAMECD1RF
        {
            get { return _sEC2_COMPANYNAMECD1RF; }
            set { _sEC2_COMPANYNAMECD1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYNAME1RF
        /// <summary>自社名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYNAME1RF
        {
            get { return _cOMPANYINFRF_COMPANYNAME1RF; }
            set { _cOMPANYINFRF_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYNAME2RF
        /// <summary>自社名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYNAME2RF
        {
            get { return _cOMPANYINFRF_COMPANYNAME2RF; }
            set { _cOMPANYINFRF_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_POSTNORF
        /// <summary>郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_POSTNORF
        {
            get { return _cOMPANYINFRF_POSTNORF; }
            set { _cOMPANYINFRF_POSTNORF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_ADDRESS1RF
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_ADDRESS1RF
        {
            get { return _cOMPANYINFRF_ADDRESS1RF; }
            set { _cOMPANYINFRF_ADDRESS1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_ADDRESS3RF
        /// <summary>住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_ADDRESS3RF
        {
            get { return _cOMPANYINFRF_ADDRESS3RF; }
            set { _cOMPANYINFRF_ADDRESS3RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_ADDRESS4RF
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_ADDRESS4RF
        {
            get { return _cOMPANYINFRF_ADDRESS4RF; }
            set { _cOMPANYINFRF_ADDRESS4RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELNO1RF
        /// <summary>自社電話番号1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELNO1RF
        {
            get { return _cOMPANYINFRF_COMPANYTELNO1RF; }
            set { _cOMPANYINFRF_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELNO2RF
        /// <summary>自社電話番号2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELNO2RF
        {
            get { return _cOMPANYINFRF_COMPANYTELNO2RF; }
            set { _cOMPANYINFRF_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELNO3RF
        /// <summary>自社電話番号3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELNO3RF
        {
            get { return _cOMPANYINFRF_COMPANYTELNO3RF; }
            set { _cOMPANYINFRF_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELTITLE1RF
        /// <summary>自社電話番号タイトル1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELTITLE1RF
        {
            get { return _cOMPANYINFRF_COMPANYTELTITLE1RF; }
            set { _cOMPANYINFRF_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELTITLE2RF
        /// <summary>自社電話番号タイトル2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELTITLE2RF
        {
            get { return _cOMPANYINFRF_COMPANYTELTITLE2RF; }
            set { _cOMPANYINFRF_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  COMPANYINFRF_COMPANYTELTITLE3RF
        /// <summary>自社電話番号タイトル3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string COMPANYINFRF_COMPANYTELTITLE3RF
        {
            get { return _cOMPANYINFRF_COMPANYTELTITLE3RF; }
            set { _cOMPANYINFRF_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYPRRF
        /// <summary>自社PR文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社PR文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYPRRF
        {
            get { return _cMP1_COMPANYPRRF; }
            set { _cMP1_COMPANYPRRF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYNAME1RF
        /// <summary>自社名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYNAME1RF
        {
            get { return _cMP1_COMPANYNAME1RF; }
            set { _cMP1_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYNAME2RF
        /// <summary>自社名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYNAME2RF
        {
            get { return _cMP1_COMPANYNAME2RF; }
            set { _cMP1_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  CMP1_POSTNORF
        /// <summary>郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_POSTNORF
        {
            get { return _cMP1_POSTNORF; }
            set { _cMP1_POSTNORF = value; }
        }

        /// public propaty name  :  CMP1_ADDRESS1RF
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_ADDRESS1RF
        {
            get { return _cMP1_ADDRESS1RF; }
            set { _cMP1_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CMP1_ADDRESS3RF
        /// <summary>住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_ADDRESS3RF
        {
            get { return _cMP1_ADDRESS3RF; }
            set { _cMP1_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CMP1_ADDRESS4RF
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_ADDRESS4RF
        {
            get { return _cMP1_ADDRESS4RF; }
            set { _cMP1_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELNO1RF
        /// <summary>自社電話番号1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYTELNO1RF
        {
            get { return _cMP1_COMPANYTELNO1RF; }
            set { _cMP1_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELNO2RF
        /// <summary>自社電話番号2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYTELNO2RF
        {
            get { return _cMP1_COMPANYTELNO2RF; }
            set { _cMP1_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELNO3RF
        /// <summary>自社電話番号3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYTELNO3RF
        {
            get { return _cMP1_COMPANYTELNO3RF; }
            set { _cMP1_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELTITLE1RF
        /// <summary>自社電話番号タイトル1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYTELTITLE1RF
        {
            get { return _cMP1_COMPANYTELTITLE1RF; }
            set { _cMP1_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELTITLE2RF
        /// <summary>自社電話番号タイトル2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYTELTITLE2RF
        {
            get { return _cMP1_COMPANYTELTITLE2RF; }
            set { _cMP1_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYTELTITLE3RF
        /// <summary>自社電話番号タイトル3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYTELTITLE3RF
        {
            get { return _cMP1_COMPANYTELTITLE3RF; }
            set { _cMP1_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  CMP1_TRANSFERGUIDANCERF
        /// <summary>銀行振込案内文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行振込案内文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_TRANSFERGUIDANCERF
        {
            get { return _cMP1_TRANSFERGUIDANCERF; }
            set { _cMP1_TRANSFERGUIDANCERF = value; }
        }

        /// public propaty name  :  CMP1_ACCOUNTNOINFO1RF
        /// <summary>銀行口座1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_ACCOUNTNOINFO1RF
        {
            get { return _cMP1_ACCOUNTNOINFO1RF; }
            set { _cMP1_ACCOUNTNOINFO1RF = value; }
        }

        /// public propaty name  :  CMP1_ACCOUNTNOINFO2RF
        /// <summary>銀行口座2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_ACCOUNTNOINFO2RF
        {
            get { return _cMP1_ACCOUNTNOINFO2RF; }
            set { _cMP1_ACCOUNTNOINFO2RF = value; }
        }

        /// public propaty name  :  CMP1_ACCOUNTNOINFO3RF
        /// <summary>銀行口座3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_ACCOUNTNOINFO3RF
        {
            get { return _cMP1_ACCOUNTNOINFO3RF; }
            set { _cMP1_ACCOUNTNOINFO3RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYSETNOTE1RF
        /// <summary>自社設定摘要1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYSETNOTE1RF
        {
            get { return _cMP1_COMPANYSETNOTE1RF; }
            set { _cMP1_COMPANYSETNOTE1RF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYSETNOTE2RF
        /// <summary>自社設定摘要2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYSETNOTE2RF
        {
            get { return _cMP1_COMPANYSETNOTE2RF; }
            set { _cMP1_COMPANYSETNOTE2RF = value; }
        }

        /// public propaty name  :  CMP1_IMAGEINFODIVRF
        /// <summary>画像情報区分プロパティ</summary>
        /// <value>10:自社画像,20:POSで使用する画像</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CMP1_IMAGEINFODIVRF
        {
            get { return _cMP1_IMAGEINFODIVRF; }
            set { _cMP1_IMAGEINFODIVRF = value; }
        }

        /// public propaty name  :  CMP1_IMAGEINFOCODERF
        /// <summary>画像情報コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CMP1_IMAGEINFOCODERF
        {
            get { return _cMP1_IMAGEINFOCODERF; }
            set { _cMP1_IMAGEINFOCODERF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYURLRF
        /// <summary>自社URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYURLRF
        {
            get { return _cMP1_COMPANYURLRF; }
            set { _cMP1_COMPANYURLRF = value; }
        }

        /// public propaty name  :  CMP1_COMPANYPRSENTENCE2RF
        /// <summary>自社PR文2プロパティ</summary>
        /// <value>代表取締役等の情報を入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社PR文2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_COMPANYPRSENTENCE2RF
        {
            get { return _cMP1_COMPANYPRSENTENCE2RF; }
            set { _cMP1_COMPANYPRSENTENCE2RF = value; }
        }

        /// public propaty name  :  CMP1_IMAGECOMMENTFORPRT1RF
        /// <summary>画像印字用コメント1プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像印字用コメント1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_IMAGECOMMENTFORPRT1RF
        {
            get { return _cMP1_IMAGECOMMENTFORPRT1RF; }
            set { _cMP1_IMAGECOMMENTFORPRT1RF = value; }
        }

        /// public propaty name  :  CMP1_IMAGECOMMENTFORPRT2RF
        /// <summary>画像印字用コメント2プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像印字用コメント2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP1_IMAGECOMMENTFORPRT2RF
        {
            get { return _cMP1_IMAGECOMMENTFORPRT2RF; }
            set { _cMP1_IMAGECOMMENTFORPRT2RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYPRRF
        /// <summary>自社PR文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社PR文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYPRRF
        {
            get { return _cMP2_COMPANYPRRF; }
            set { _cMP2_COMPANYPRRF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYNAME1RF
        /// <summary>自社名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYNAME1RF
        {
            get { return _cMP2_COMPANYNAME1RF; }
            set { _cMP2_COMPANYNAME1RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYNAME2RF
        /// <summary>自社名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYNAME2RF
        {
            get { return _cMP2_COMPANYNAME2RF; }
            set { _cMP2_COMPANYNAME2RF = value; }
        }

        /// public propaty name  :  CMP2_POSTNORF
        /// <summary>郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_POSTNORF
        {
            get { return _cMP2_POSTNORF; }
            set { _cMP2_POSTNORF = value; }
        }

        /// public propaty name  :  CMP2_ADDRESS1RF
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_ADDRESS1RF
        {
            get { return _cMP2_ADDRESS1RF; }
            set { _cMP2_ADDRESS1RF = value; }
        }

        /// public propaty name  :  CMP2_ADDRESS3RF
        /// <summary>住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_ADDRESS3RF
        {
            get { return _cMP2_ADDRESS3RF; }
            set { _cMP2_ADDRESS3RF = value; }
        }

        /// public propaty name  :  CMP2_ADDRESS4RF
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_ADDRESS4RF
        {
            get { return _cMP2_ADDRESS4RF; }
            set { _cMP2_ADDRESS4RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELNO1RF
        /// <summary>自社電話番号1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYTELNO1RF
        {
            get { return _cMP2_COMPANYTELNO1RF; }
            set { _cMP2_COMPANYTELNO1RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELNO2RF
        /// <summary>自社電話番号2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYTELNO2RF
        {
            get { return _cMP2_COMPANYTELNO2RF; }
            set { _cMP2_COMPANYTELNO2RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELNO3RF
        /// <summary>自社電話番号3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYTELNO3RF
        {
            get { return _cMP2_COMPANYTELNO3RF; }
            set { _cMP2_COMPANYTELNO3RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELTITLE1RF
        /// <summary>自社電話番号タイトル1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYTELTITLE1RF
        {
            get { return _cMP2_COMPANYTELTITLE1RF; }
            set { _cMP2_COMPANYTELTITLE1RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELTITLE2RF
        /// <summary>自社電話番号タイトル2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYTELTITLE2RF
        {
            get { return _cMP2_COMPANYTELTITLE2RF; }
            set { _cMP2_COMPANYTELTITLE2RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYTELTITLE3RF
        /// <summary>自社電話番号タイトル3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYTELTITLE3RF
        {
            get { return _cMP2_COMPANYTELTITLE3RF; }
            set { _cMP2_COMPANYTELTITLE3RF = value; }
        }

        /// public propaty name  :  CMP2_TRANSFERGUIDANCERF
        /// <summary>銀行振込案内文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行振込案内文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_TRANSFERGUIDANCERF
        {
            get { return _cMP2_TRANSFERGUIDANCERF; }
            set { _cMP2_TRANSFERGUIDANCERF = value; }
        }

        /// public propaty name  :  CMP2_ACCOUNTNOINFO1RF
        /// <summary>銀行口座1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_ACCOUNTNOINFO1RF
        {
            get { return _cMP2_ACCOUNTNOINFO1RF; }
            set { _cMP2_ACCOUNTNOINFO1RF = value; }
        }

        /// public propaty name  :  CMP2_ACCOUNTNOINFO2RF
        /// <summary>銀行口座2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_ACCOUNTNOINFO2RF
        {
            get { return _cMP2_ACCOUNTNOINFO2RF; }
            set { _cMP2_ACCOUNTNOINFO2RF = value; }
        }

        /// public propaty name  :  CMP2_ACCOUNTNOINFO3RF
        /// <summary>銀行口座3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_ACCOUNTNOINFO3RF
        {
            get { return _cMP2_ACCOUNTNOINFO3RF; }
            set { _cMP2_ACCOUNTNOINFO3RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYSETNOTE1RF
        /// <summary>自社設定摘要1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYSETNOTE1RF
        {
            get { return _cMP2_COMPANYSETNOTE1RF; }
            set { _cMP2_COMPANYSETNOTE1RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYSETNOTE2RF
        /// <summary>自社設定摘要2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYSETNOTE2RF
        {
            get { return _cMP2_COMPANYSETNOTE2RF; }
            set { _cMP2_COMPANYSETNOTE2RF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYURLRF
        /// <summary>自社URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYURLRF
        {
            get { return _cMP2_COMPANYURLRF; }
            set { _cMP2_COMPANYURLRF = value; }
        }

        /// public propaty name  :  CMP2_COMPANYPRSENTENCE2RF
        /// <summary>自社PR文2プロパティ</summary>
        /// <value>代表取締役等の情報を入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社PR文2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_COMPANYPRSENTENCE2RF
        {
            get { return _cMP2_COMPANYPRSENTENCE2RF; }
            set { _cMP2_COMPANYPRSENTENCE2RF = value; }
        }

        /// public propaty name  :  CMP2_IMAGECOMMENTFORPRT1RF
        /// <summary>画像印字用コメント1プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像印字用コメント1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_IMAGECOMMENTFORPRT1RF
        {
            get { return _cMP2_IMAGECOMMENTFORPRT1RF; }
            set { _cMP2_IMAGECOMMENTFORPRT1RF = value; }
        }

        /// public propaty name  :  CMP2_IMAGECOMMENTFORPRT2RF
        /// <summary>画像印字用コメント2プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像印字用コメント2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CMP2_IMAGECOMMENTFORPRT2RF
        {
            get { return _cMP2_IMAGECOMMENTFORPRT2RF; }
            set { _cMP2_IMAGECOMMENTFORPRT2RF = value; }
        }

        /// public propaty name  :  EMP1_KANARF
        /// <summary>カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMP1_KANARF
        {
            get { return _eMP1_KANARF; }
            set { _eMP1_KANARF = value; }
        }

        /// public propaty name  :  EMP1_SHORTNAMERF
        /// <summary>短縮名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   短縮名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMP1_SHORTNAMERF
        {
            get { return _eMP1_SHORTNAMERF; }
            set { _eMP1_SHORTNAMERF = value; }
        }

        /// public propaty name  :  EMP2_KANARF
        /// <summary>カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMP2_KANARF
        {
            get { return _eMP2_KANARF; }
            set { _eMP2_KANARF = value; }
        }

        /// public propaty name  :  EMP2_SHORTNAMERF
        /// <summary>短縮名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   短縮名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMP2_SHORTNAMERF
        {
            get { return _eMP2_SHORTNAMERF; }
            set { _eMP2_SHORTNAMERF = value; }
        }

        /// public propaty name  :  EMP3_KANARF
        /// <summary>カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMP3_KANARF
        {
            get { return _eMP3_KANARF; }
            set { _eMP3_KANARF = value; }
        }

        /// public propaty name  :  EMP3_SHORTNAMERF
        /// <summary>短縮名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   短縮名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EMP3_SHORTNAMERF
        {
            get { return _eMP3_SHORTNAMERF; }
            set { _eMP3_SHORTNAMERF = value; }
        }

        /// public propaty name  :  IMAGEINFORF_IMAGEINFODATARF
        /// <summary>画像情報データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報データプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Byte[] IMAGEINFORF_IMAGEINFODATARF
        {
            get { return _iMAGEINFORF_IMAGEINFODATARF; }
            set { _iMAGEINFORF_IMAGEINFODATARF = value; }
        }

        /// public propaty field.NameJp  :  IMAGEINFORF_IMAGEINFODATARFImageObject
        /// <summary>画像情報データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報データプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Image IMAGEINFORF_IMAGEINFODATARFImageObject
        {
            get
            {
                if ( _iMAGEINFORF_IMAGEINFODATARF != null )
                {
                    MemoryStream mem = new MemoryStream( _iMAGEINFORF_IMAGEINFODATARF );
                    mem.Position = 0;
                    return Image.FromStream( mem );
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _iMAGEINFORF_IMAGEINFODATARF = null;
                MemoryStream mem = new MemoryStream();
                Image img = value;
                img.Save( mem, System.Drawing.Imaging.ImageFormat.Bmp );
                _iMAGEINFORF_IMAGEINFODATARF = mem.ToArray();
            }
        }

        /// public propaty name  :  HADD_STOCKMOVEFORMALNMRF
        /// <summary>在庫移動形式名称プロパティ</summary>
        /// <value>1:在庫移動、2：倉庫移動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動形式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_STOCKMOVEFORMALNMRF
        {
            get { return _hADD_STOCKMOVEFORMALNMRF; }
            set { _hADD_STOCKMOVEFORMALNMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFYRF
        /// <summary>出荷予定日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFYRF
        {
            get { return _hADD_SHIPMENTSCDLDFYRF; }
            set { _hADD_SHIPMENTSCDLDFYRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFSRF
        /// <summary>出荷予定日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFSRF
        {
            get { return _hADD_SHIPMENTSCDLDFSRF; }
            set { _hADD_SHIPMENTSCDLDFSRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFWRF
        /// <summary>出荷予定日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFWRF
        {
            get { return _hADD_SHIPMENTSCDLDFWRF; }
            set { _hADD_SHIPMENTSCDLDFWRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFMRF
        /// <summary>出荷予定日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFMRF
        {
            get { return _hADD_SHIPMENTSCDLDFMRF; }
            set { _hADD_SHIPMENTSCDLDFMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFDRF
        /// <summary>出荷予定日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_SHIPMENTSCDLDFDRF
        {
            get { return _hADD_SHIPMENTSCDLDFDRF; }
            set { _hADD_SHIPMENTSCDLDFDRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFGRF
        /// <summary>出荷予定日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFGRF
        {
            get { return _hADD_SHIPMENTSCDLDFGRF; }
            set { _hADD_SHIPMENTSCDLDFGRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFRRF
        /// <summary>出荷予定日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFRRF
        {
            get { return _hADD_SHIPMENTSCDLDFRRF; }
            set { _hADD_SHIPMENTSCDLDFRRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLSRF
        /// <summary>出荷予定日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLSRF
        {
            get { return _hADD_SHIPMENTSCDLDFLSRF; }
            set { _hADD_SHIPMENTSCDLDFLSRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLPRF
        /// <summary>出荷予定日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLPRF
        {
            get { return _hADD_SHIPMENTSCDLDFLPRF; }
            set { _hADD_SHIPMENTSCDLDFLPRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLYRF
        /// <summary>出荷予定日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLYRF
        {
            get { return _hADD_SHIPMENTSCDLDFLYRF; }
            set { _hADD_SHIPMENTSCDLDFLYRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLMRF
        /// <summary>出荷予定日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLMRF
        {
            get { return _hADD_SHIPMENTSCDLDFLMRF; }
            set { _hADD_SHIPMENTSCDLDFLMRF = value; }
        }

        /// public propaty name  :  HADD_SHIPMENTSCDLDFLDRF
        /// <summary>出荷予定日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SHIPMENTSCDLDFLDRF
        {
            get { return _hADD_SHIPMENTSCDLDFLDRF; }
            set { _hADD_SHIPMENTSCDLDFLDRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFYRF
        /// <summary>入力日西暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日西暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_INPUTDFYRF
        {
            get { return _hADD_INPUTDFYRF; }
            set { _hADD_INPUTDFYRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFSRF
        /// <summary>入力日西暦年略プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日西暦年略プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_INPUTDFSRF
        {
            get { return _hADD_INPUTDFSRF; }
            set { _hADD_INPUTDFSRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFWRF
        /// <summary>入力日和暦年プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日和暦年プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_INPUTDFWRF
        {
            get { return _hADD_INPUTDFWRF; }
            set { _hADD_INPUTDFWRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFMRF
        /// <summary>入力日月プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_INPUTDFMRF
        {
            get { return _hADD_INPUTDFMRF; }
            set { _hADD_INPUTDFMRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFDRF
        /// <summary>入力日日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_INPUTDFDRF
        {
            get { return _hADD_INPUTDFDRF; }
            set { _hADD_INPUTDFDRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFGRF
        /// <summary>入力日元号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日元号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_INPUTDFGRF
        {
            get { return _hADD_INPUTDFGRF; }
            set { _hADD_INPUTDFGRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFRRF
        /// <summary>入力日略号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日略号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_INPUTDFRRF
        {
            get { return _hADD_INPUTDFRRF; }
            set { _hADD_INPUTDFRRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLSRF
        /// <summary>入力日リテラル(/)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日リテラル(/)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_INPUTDFLSRF
        {
            get { return _hADD_INPUTDFLSRF; }
            set { _hADD_INPUTDFLSRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLPRF
        /// <summary>入力日リテラル(.)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日リテラル(.)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_INPUTDFLPRF
        {
            get { return _hADD_INPUTDFLPRF; }
            set { _hADD_INPUTDFLPRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLYRF
        /// <summary>入力日リテラル(年)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日リテラル(年)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_INPUTDFLYRF
        {
            get { return _hADD_INPUTDFLYRF; }
            set { _hADD_INPUTDFLYRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLMRF
        /// <summary>入力日リテラル(月)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日リテラル(月)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_INPUTDFLMRF
        {
            get { return _hADD_INPUTDFLMRF; }
            set { _hADD_INPUTDFLMRF = value; }
        }

        /// public propaty name  :  HADD_INPUTDFLDRF
        /// <summary>入力日リテラル(日)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日リテラル(日)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_INPUTDFLDRF
        {
            get { return _hADD_INPUTDFLDRF; }
            set { _hADD_INPUTDFLDRF = value; }
        }

        /// public propaty name  :  HADD_NOTE1RF
        /// <summary>自社備考１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NOTE1RF
        {
            get { return _hADD_NOTE1RF; }
            set { _hADD_NOTE1RF = value; }
        }

        /// public propaty name  :  HADD_NOTE2RF
        /// <summary>自社備考２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NOTE2RF
        {
            get { return _hADD_NOTE2RF; }
            set { _hADD_NOTE2RF = value; }
        }

        /// public propaty name  :  HADD_NOTE3RF
        /// <summary>自社備考３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_NOTE3RF
        {
            get { return _hADD_NOTE3RF; }
            set { _hADD_NOTE3RF = value; }
        }

        /// public propaty name  :  HADD_REISSUEMARKRF
        /// <summary>再発行マークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   再発行マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_REISSUEMARKRF
        {
            get { return _hADD_REISSUEMARKRF; }
            set { _hADD_REISSUEMARKRF = value; }
        }

        /// public propaty name  :  HADD_PRINTERMNGNORF
        /// <summary>プリンタ管理Noプロパティ</summary>
        /// <value>※このレコードの伝票を印刷するプリンタの決定結果(default)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   プリンタ管理Noプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_PRINTERMNGNORF
        {
            get { return _hADD_PRINTERMNGNORF; }
            set { _hADD_PRINTERMNGNORF = value; }
        }

        /// public propaty name  :  HADD_SLIPPRTSETPAPERIDRF
        /// <summary>伝票印刷設定用帳票IDプロパティ</summary>
        /// <value>※このレコードの伝票を印刷する伝票タイプの決定結果(default)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HADD_SLIPPRTSETPAPERIDRF
        {
            get { return _hADD_SLIPPRTSETPAPERIDRF; }
            set { _hADD_SLIPPRTSETPAPERIDRF = value; }
        }

        /// public propaty name  :  HADD_PRINTTIMEHOURRF
        /// <summary>印刷時刻 時プロパティ</summary>
        /// <value>HH</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷時刻 時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_PRINTTIMEHOURRF
        {
            get { return _hADD_PRINTTIMEHOURRF; }
            set { _hADD_PRINTTIMEHOURRF = value; }
        }

        /// public propaty name  :  HADD_PRINTTIMEMINUTERF
        /// <summary>印刷時刻 分プロパティ</summary>
        /// <value>MM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷時刻 分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_PRINTTIMEMINUTERF
        {
            get { return _hADD_PRINTTIMEMINUTERF; }
            set { _hADD_PRINTTIMEMINUTERF = value; }
        }

        /// public propaty name  :  HADD_PRINTTIMESECONDRF
        /// <summary>印刷時刻 秒プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印刷時刻 秒プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HADD_PRINTTIMESECONDRF
        {
            get { return _hADD_PRINTTIMESECONDRF; }
            set { _hADD_PRINTTIMESECONDRF = value; }
        }

        /// public propaty name  :  HADD_TTLSTOCKMOVEPRICERF
        /// <summary>伝票合計金額プロパティ</summary>
        /// <value>【仕入単価×移動数】</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票合計金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HADD_TTLSTOCKMOVEPRICERF
        {
            get { return _hADD_TTLSTOCKMOVEPRICERF; }
            set { _hADD_TTLSTOCKMOVEPRICERF = value; }
        }

        /// public propaty name  :  HADD_TTLSTOCKMOVELISTPRICERF
        /// <summary>伝票合計金額(標準価格)プロパティ</summary>
        /// <value>【定価×移動数】</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票合計金額(標準価格)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 HADD_TTLSTOCKMOVELISTPRICERF
        {
            get { return _hADD_TTLSTOCKMOVELISTPRICERF; }
            set { _hADD_TTLSTOCKMOVELISTPRICERF = value; }
        }

        /// public propaty name  :  MOVH_UPDATESECCDRF
        /// <summary>入力拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MOVH_UPDATESECCDRF
        {
            get { return _mOVH_UPDATESECCDRF; }
            set { _mOVH_UPDATESECCDRF = value; }
        }

        /// public propaty name  :  SEC0_SECTIONGUIDESNMRF
        /// <summary>入力拠点ガイド略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SEC0_SECTIONGUIDESNMRF
        {
            get { return _sEC0_SECTIONGUIDESNMRF; }
            set { _sEC0_SECTIONGUIDESNMRF = value; }
        }

        /// public propaty name  :  SEC0_SECTIONGUIDENMRF
        /// <summary>入力拠点ガイド名称プロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SEC0_SECTIONGUIDENMRF
        {
            get { return _sEC0_SECTIONGUIDENMRF; }
            set { _sEC0_SECTIONGUIDENMRF = value; }
        }


        /// <summary>
        /// 自由帳票在庫移動伝票データワークコンストラクタ
        /// </summary>
        /// <returns>FrePStockMoveSlipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveSlipWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FrePStockMoveSlipWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>FrePStockMoveSlipWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   FrePStockMoveSlipWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class FrePStockMoveSlipWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveSlipWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FrePStockMoveSlipWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FrePStockMoveSlipWork || graph is ArrayList || graph is FrePStockMoveSlipWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( FrePStockMoveSlipWork ).FullName ) );

            if ( graph != null && graph is FrePStockMoveSlipWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePStockMoveSlipWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FrePStockMoveSlipWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FrePStockMoveSlipWork[])graph).Length;
            }
            else if ( graph is FrePStockMoveSlipWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //在庫移動形式
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_STOCKMOVEFORMALRF
            //在庫移動伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_STOCKMOVESLIPNORF
            //移動元拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_BFSECTIONCODERF
            //移動元拠点ガイド略称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_BFSECTIONGUIDESNMRF
            //移動元倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_BFENTERWAREHCODERF
            //移動元倉庫名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_BFENTERWAREHNAMERF
            //移動先拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_AFSECTIONCODERF
            //移動先拠点ガイド略称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_AFSECTIONGUIDESNMRF
            //移動先倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_AFENTERWAREHCODERF
            //移動先倉庫名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_AFENTERWAREHNAMERF
            //出荷予定日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_SHIPMENTSCDLDAYRF
            //入力日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_INPUTDAYRF
            //在庫移動入力従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_STOCKMVEMPCODERF
            //在庫移動入力従業員名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_STOCKMVEMPNAMERF
            //出荷担当従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_SHIPAGENTCDRF
            //出荷担当従業員名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_SHIPAGENTNMRF
            //引取担当従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_RECEIVEAGENTCDRF
            //引取担当従業員名称
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_RECEIVEAGENTNMRF
            //伝票摘要
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_OUTLINERF
            //倉庫備考1
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_WAREHOUSENOTE1RF
            //伝票発行済区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MOVH_SLIPPRINTFINISHCDRF
            //拠点ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SEC1_SECTIONGUIDENMRF
            //自社名称コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SEC1_COMPANYNAMECD1RF
            //拠点ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SEC2_SECTIONGUIDENMRF
            //自社名称コード1
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SEC2_COMPANYNAMECD1RF
            //自社名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYNAME1RF
            //自社名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYNAME2RF
            //郵便番号
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_POSTNORF
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_ADDRESS1RF
            //住所3（番地）
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_ADDRESS3RF
            //住所4（アパート名称）
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_ADDRESS4RF
            //自社電話番号1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELNO1RF
            //自社電話番号2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELNO2RF
            //自社電話番号3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELNO3RF
            //自社電話番号タイトル1
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELTITLE1RF
            //自社電話番号タイトル2
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELTITLE2RF
            //自社電話番号タイトル3
            serInfo.MemberInfo.Add( typeof( string ) ); //COMPANYINFRF_COMPANYTELTITLE3RF
            //自社PR文
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYPRRF
            //自社名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYNAME1RF
            //自社名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYNAME2RF
            //郵便番号
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_POSTNORF
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ADDRESS1RF
            //住所3（番地）
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ADDRESS3RF
            //住所4（アパート名称）
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ADDRESS4RF
            //自社電話番号1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELNO1RF
            //自社電話番号2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELNO2RF
            //自社電話番号3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELNO3RF
            //自社電話番号タイトル1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELTITLE1RF
            //自社電話番号タイトル2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELTITLE2RF
            //自社電話番号タイトル3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYTELTITLE3RF
            //銀行振込案内文
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_TRANSFERGUIDANCERF
            //銀行口座1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ACCOUNTNOINFO1RF
            //銀行口座2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ACCOUNTNOINFO2RF
            //銀行口座3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_ACCOUNTNOINFO3RF
            //自社設定摘要1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYSETNOTE1RF
            //自社設定摘要2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYSETNOTE2RF
            //画像情報区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CMP1_IMAGEINFODIVRF
            //画像情報コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CMP1_IMAGEINFOCODERF
            //自社URL
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYURLRF
            //自社PR文2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_COMPANYPRSENTENCE2RF
            //画像印字用コメント1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_IMAGECOMMENTFORPRT1RF
            //画像印字用コメント2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP1_IMAGECOMMENTFORPRT2RF
            //自社PR文
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYPRRF
            //自社名称1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYNAME1RF
            //自社名称2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYNAME2RF
            //郵便番号
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_POSTNORF
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ADDRESS1RF
            //住所3（番地）
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ADDRESS3RF
            //住所4（アパート名称）
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ADDRESS4RF
            //自社電話番号1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELNO1RF
            //自社電話番号2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELNO2RF
            //自社電話番号3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELNO3RF
            //自社電話番号タイトル1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELTITLE1RF
            //自社電話番号タイトル2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELTITLE2RF
            //自社電話番号タイトル3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYTELTITLE3RF
            //銀行振込案内文
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_TRANSFERGUIDANCERF
            //銀行口座1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ACCOUNTNOINFO1RF
            //銀行口座2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ACCOUNTNOINFO2RF
            //銀行口座3
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_ACCOUNTNOINFO3RF
            //自社設定摘要1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYSETNOTE1RF
            //自社設定摘要2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYSETNOTE2RF
            //自社URL
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYURLRF
            //自社PR文2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_COMPANYPRSENTENCE2RF
            //画像印字用コメント1
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_IMAGECOMMENTFORPRT1RF
            //画像印字用コメント2
            serInfo.MemberInfo.Add( typeof( string ) ); //CMP2_IMAGECOMMENTFORPRT2RF
            //カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP1_KANARF
            //短縮名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP1_SHORTNAMERF
            //カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP2_KANARF
            //短縮名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP2_SHORTNAMERF
            //カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP3_KANARF
            //短縮名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EMP3_SHORTNAMERF
            //画像情報データ
            serInfo.MemberInfo.Add( typeof( Byte[] ) ); //IMAGEINFORF_IMAGEINFODATARF
            //在庫移動形式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_STOCKMOVEFORMALNMRF
            //出荷予定日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFYRF
            //出荷予定日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFSRF
            //出荷予定日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFWRF
            //出荷予定日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFMRF
            //出荷予定日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_SHIPMENTSCDLDFDRF
            //出荷予定日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFGRF
            //出荷予定日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFRRF
            //出荷予定日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLSRF
            //出荷予定日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLPRF
            //出荷予定日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLYRF
            //出荷予定日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLMRF
            //出荷予定日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SHIPMENTSCDLDFLDRF
            //入力日西暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFYRF
            //入力日西暦年略
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFSRF
            //入力日和暦年
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFWRF
            //入力日月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFMRF
            //入力日日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_INPUTDFDRF
            //入力日元号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFGRF
            //入力日略号
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFRRF
            //入力日リテラル(/)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLSRF
            //入力日リテラル(.)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLPRF
            //入力日リテラル(年)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLYRF
            //入力日リテラル(月)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLMRF
            //入力日リテラル(日)
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_INPUTDFLDRF
            //自社備考１
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE1RF
            //自社備考２
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE2RF
            //自社備考３
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_NOTE3RF
            //再発行マーク
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_REISSUEMARKRF
            //プリンタ管理No
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTERMNGNORF
            //伝票印刷設定用帳票ID
            serInfo.MemberInfo.Add( typeof( string ) ); //HADD_SLIPPRTSETPAPERIDRF
            //印刷時刻 時
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMEHOURRF
            //印刷時刻 分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMEMINUTERF
            //印刷時刻 秒
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //HADD_PRINTTIMESECONDRF
            //伝票合計金額
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_TTLSTOCKMOVEPRICERF
            //伝票合計金額(標準価格)
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //HADD_TTLSTOCKMOVELISTPRICERF
            //入力拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //MOVH_UPDATESECCDRF
            //入力拠点ガイド略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SEC0_SECTIONGUIDESNMRF
            //入力拠点ガイド名称
            serInfo.MemberInfo.Add( typeof( string ) ); //SEC0_SECTIONGUIDENMRF


            serInfo.Serialize( writer, serInfo );
            if ( graph is FrePStockMoveSlipWork )
            {
                FrePStockMoveSlipWork temp = (FrePStockMoveSlipWork)graph;

                SetFrePStockMoveSlipWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FrePStockMoveSlipWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FrePStockMoveSlipWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FrePStockMoveSlipWork temp in lst )
                {
                    SetFrePStockMoveSlipWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FrePStockMoveSlipWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 131;

        /// <summary>
        ///  FrePStockMoveSlipWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveSlipWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetFrePStockMoveSlipWork( System.IO.BinaryWriter writer, FrePStockMoveSlipWork temp )
        {
            //在庫移動形式
            writer.Write( temp.MOVH_STOCKMOVEFORMALRF );
            //在庫移動伝票番号
            writer.Write( temp.MOVH_STOCKMOVESLIPNORF );
            //移動元拠点コード
            writer.Write( temp.MOVH_BFSECTIONCODERF );
            //移動元拠点ガイド略称
            writer.Write( temp.MOVH_BFSECTIONGUIDESNMRF );
            //移動元倉庫コード
            writer.Write( temp.MOVH_BFENTERWAREHCODERF );
            //移動元倉庫名称
            writer.Write( temp.MOVH_BFENTERWAREHNAMERF );
            //移動先拠点コード
            writer.Write( temp.MOVH_AFSECTIONCODERF );
            //移動先拠点ガイド略称
            writer.Write( temp.MOVH_AFSECTIONGUIDESNMRF );
            //移動先倉庫コード
            writer.Write( temp.MOVH_AFENTERWAREHCODERF );
            //移動先倉庫名称
            writer.Write( temp.MOVH_AFENTERWAREHNAMERF );
            //出荷予定日
            writer.Write( temp.MOVH_SHIPMENTSCDLDAYRF );
            //入力日
            writer.Write( temp.MOVH_INPUTDAYRF );
            //在庫移動入力従業員コード
            writer.Write( temp.MOVH_STOCKMVEMPCODERF );
            //在庫移動入力従業員名称
            writer.Write( temp.MOVH_STOCKMVEMPNAMERF );
            //出荷担当従業員コード
            writer.Write( temp.MOVH_SHIPAGENTCDRF );
            //出荷担当従業員名称
            writer.Write( temp.MOVH_SHIPAGENTNMRF );
            //引取担当従業員コード
            writer.Write( temp.MOVH_RECEIVEAGENTCDRF );
            //引取担当従業員名称
            writer.Write( temp.MOVH_RECEIVEAGENTNMRF );
            //伝票摘要
            writer.Write( temp.MOVH_OUTLINERF );
            //倉庫備考1
            writer.Write( temp.MOVH_WAREHOUSENOTE1RF );
            //伝票発行済区分
            writer.Write( temp.MOVH_SLIPPRINTFINISHCDRF );
            //拠点ガイド名称
            writer.Write( temp.SEC1_SECTIONGUIDENMRF );
            //自社名称コード1
            writer.Write( temp.SEC1_COMPANYNAMECD1RF );
            //拠点ガイド名称
            writer.Write( temp.SEC2_SECTIONGUIDENMRF );
            //自社名称コード1
            writer.Write( temp.SEC2_COMPANYNAMECD1RF );
            //自社名称1
            writer.Write( temp.COMPANYINFRF_COMPANYNAME1RF );
            //自社名称2
            writer.Write( temp.COMPANYINFRF_COMPANYNAME2RF );
            //郵便番号
            writer.Write( temp.COMPANYINFRF_POSTNORF );
            //住所1（都道府県市区郡・町村・字）
            writer.Write( temp.COMPANYINFRF_ADDRESS1RF );
            //住所3（番地）
            writer.Write( temp.COMPANYINFRF_ADDRESS3RF );
            //住所4（アパート名称）
            writer.Write( temp.COMPANYINFRF_ADDRESS4RF );
            //自社電話番号1
            writer.Write( temp.COMPANYINFRF_COMPANYTELNO1RF );
            //自社電話番号2
            writer.Write( temp.COMPANYINFRF_COMPANYTELNO2RF );
            //自社電話番号3
            writer.Write( temp.COMPANYINFRF_COMPANYTELNO3RF );
            //自社電話番号タイトル1
            writer.Write( temp.COMPANYINFRF_COMPANYTELTITLE1RF );
            //自社電話番号タイトル2
            writer.Write( temp.COMPANYINFRF_COMPANYTELTITLE2RF );
            //自社電話番号タイトル3
            writer.Write( temp.COMPANYINFRF_COMPANYTELTITLE3RF );
            //自社PR文
            writer.Write( temp.CMP1_COMPANYPRRF );
            //自社名称1
            writer.Write( temp.CMP1_COMPANYNAME1RF );
            //自社名称2
            writer.Write( temp.CMP1_COMPANYNAME2RF );
            //郵便番号
            writer.Write( temp.CMP1_POSTNORF );
            //住所1（都道府県市区郡・町村・字）
            writer.Write( temp.CMP1_ADDRESS1RF );
            //住所3（番地）
            writer.Write( temp.CMP1_ADDRESS3RF );
            //住所4（アパート名称）
            writer.Write( temp.CMP1_ADDRESS4RF );
            //自社電話番号1
            writer.Write( temp.CMP1_COMPANYTELNO1RF );
            //自社電話番号2
            writer.Write( temp.CMP1_COMPANYTELNO2RF );
            //自社電話番号3
            writer.Write( temp.CMP1_COMPANYTELNO3RF );
            //自社電話番号タイトル1
            writer.Write( temp.CMP1_COMPANYTELTITLE1RF );
            //自社電話番号タイトル2
            writer.Write( temp.CMP1_COMPANYTELTITLE2RF );
            //自社電話番号タイトル3
            writer.Write( temp.CMP1_COMPANYTELTITLE3RF );
            //銀行振込案内文
            writer.Write( temp.CMP1_TRANSFERGUIDANCERF );
            //銀行口座1
            writer.Write( temp.CMP1_ACCOUNTNOINFO1RF );
            //銀行口座2
            writer.Write( temp.CMP1_ACCOUNTNOINFO2RF );
            //銀行口座3
            writer.Write( temp.CMP1_ACCOUNTNOINFO3RF );
            //自社設定摘要1
            writer.Write( temp.CMP1_COMPANYSETNOTE1RF );
            //自社設定摘要2
            writer.Write( temp.CMP1_COMPANYSETNOTE2RF );
            //画像情報区分
            writer.Write( temp.CMP1_IMAGEINFODIVRF );
            //画像情報コード
            writer.Write( temp.CMP1_IMAGEINFOCODERF );
            //自社URL
            writer.Write( temp.CMP1_COMPANYURLRF );
            //自社PR文2
            writer.Write( temp.CMP1_COMPANYPRSENTENCE2RF );
            //画像印字用コメント1
            writer.Write( temp.CMP1_IMAGECOMMENTFORPRT1RF );
            //画像印字用コメント2
            writer.Write( temp.CMP1_IMAGECOMMENTFORPRT2RF );
            //自社PR文
            writer.Write( temp.CMP2_COMPANYPRRF );
            //自社名称1
            writer.Write( temp.CMP2_COMPANYNAME1RF );
            //自社名称2
            writer.Write( temp.CMP2_COMPANYNAME2RF );
            //郵便番号
            writer.Write( temp.CMP2_POSTNORF );
            //住所1（都道府県市区郡・町村・字）
            writer.Write( temp.CMP2_ADDRESS1RF );
            //住所3（番地）
            writer.Write( temp.CMP2_ADDRESS3RF );
            //住所4（アパート名称）
            writer.Write( temp.CMP2_ADDRESS4RF );
            //自社電話番号1
            writer.Write( temp.CMP2_COMPANYTELNO1RF );
            //自社電話番号2
            writer.Write( temp.CMP2_COMPANYTELNO2RF );
            //自社電話番号3
            writer.Write( temp.CMP2_COMPANYTELNO3RF );
            //自社電話番号タイトル1
            writer.Write( temp.CMP2_COMPANYTELTITLE1RF );
            //自社電話番号タイトル2
            writer.Write( temp.CMP2_COMPANYTELTITLE2RF );
            //自社電話番号タイトル3
            writer.Write( temp.CMP2_COMPANYTELTITLE3RF );
            //銀行振込案内文
            writer.Write( temp.CMP2_TRANSFERGUIDANCERF );
            //銀行口座1
            writer.Write( temp.CMP2_ACCOUNTNOINFO1RF );
            //銀行口座2
            writer.Write( temp.CMP2_ACCOUNTNOINFO2RF );
            //銀行口座3
            writer.Write( temp.CMP2_ACCOUNTNOINFO3RF );
            //自社設定摘要1
            writer.Write( temp.CMP2_COMPANYSETNOTE1RF );
            //自社設定摘要2
            writer.Write( temp.CMP2_COMPANYSETNOTE2RF );
            //自社URL
            writer.Write( temp.CMP2_COMPANYURLRF );
            //自社PR文2
            writer.Write( temp.CMP2_COMPANYPRSENTENCE2RF );
            //画像印字用コメント1
            writer.Write( temp.CMP2_IMAGECOMMENTFORPRT1RF );
            //画像印字用コメント2
            writer.Write( temp.CMP2_IMAGECOMMENTFORPRT2RF );
            //カナ
            writer.Write( temp.EMP1_KANARF );
            //短縮名称
            writer.Write( temp.EMP1_SHORTNAMERF );
            //カナ
            writer.Write( temp.EMP2_KANARF );
            //短縮名称
            writer.Write( temp.EMP2_SHORTNAMERF );
            //カナ
            writer.Write( temp.EMP3_KANARF );
            //短縮名称
            writer.Write( temp.EMP3_SHORTNAMERF );
            //画像情報データ
            writer.Write( temp.IMAGEINFORF_IMAGEINFODATARF );
            //在庫移動形式名称
            writer.Write( temp.HADD_STOCKMOVEFORMALNMRF );
            //出荷予定日西暦年
            writer.Write( temp.HADD_SHIPMENTSCDLDFYRF );
            //出荷予定日西暦年略
            writer.Write( temp.HADD_SHIPMENTSCDLDFSRF );
            //出荷予定日和暦年
            writer.Write( temp.HADD_SHIPMENTSCDLDFWRF );
            //出荷予定日月
            writer.Write( temp.HADD_SHIPMENTSCDLDFMRF );
            //出荷予定日日
            writer.Write( temp.HADD_SHIPMENTSCDLDFDRF );
            //出荷予定日元号
            writer.Write( temp.HADD_SHIPMENTSCDLDFGRF );
            //出荷予定日略号
            writer.Write( temp.HADD_SHIPMENTSCDLDFRRF );
            //出荷予定日リテラル(/)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLSRF );
            //出荷予定日リテラル(.)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLPRF );
            //出荷予定日リテラル(年)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLYRF );
            //出荷予定日リテラル(月)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLMRF );
            //出荷予定日リテラル(日)
            writer.Write( temp.HADD_SHIPMENTSCDLDFLDRF );
            //入力日西暦年
            writer.Write( temp.HADD_INPUTDFYRF );
            //入力日西暦年略
            writer.Write( temp.HADD_INPUTDFSRF );
            //入力日和暦年
            writer.Write( temp.HADD_INPUTDFWRF );
            //入力日月
            writer.Write( temp.HADD_INPUTDFMRF );
            //入力日日
            writer.Write( temp.HADD_INPUTDFDRF );
            //入力日元号
            writer.Write( temp.HADD_INPUTDFGRF );
            //入力日略号
            writer.Write( temp.HADD_INPUTDFRRF );
            //入力日リテラル(/)
            writer.Write( temp.HADD_INPUTDFLSRF );
            //入力日リテラル(.)
            writer.Write( temp.HADD_INPUTDFLPRF );
            //入力日リテラル(年)
            writer.Write( temp.HADD_INPUTDFLYRF );
            //入力日リテラル(月)
            writer.Write( temp.HADD_INPUTDFLMRF );
            //入力日リテラル(日)
            writer.Write( temp.HADD_INPUTDFLDRF );
            //自社備考１
            writer.Write( temp.HADD_NOTE1RF );
            //自社備考２
            writer.Write( temp.HADD_NOTE2RF );
            //自社備考３
            writer.Write( temp.HADD_NOTE3RF );
            //再発行マーク
            writer.Write( temp.HADD_REISSUEMARKRF );
            //プリンタ管理No
            writer.Write( temp.HADD_PRINTERMNGNORF );
            //伝票印刷設定用帳票ID
            writer.Write( temp.HADD_SLIPPRTSETPAPERIDRF );
            //印刷時刻 時
            writer.Write( temp.HADD_PRINTTIMEHOURRF );
            //印刷時刻 分
            writer.Write( temp.HADD_PRINTTIMEMINUTERF );
            //印刷時刻 秒
            writer.Write( temp.HADD_PRINTTIMESECONDRF );
            //伝票合計金額
            writer.Write( temp.HADD_TTLSTOCKMOVEPRICERF );
            //伝票合計金額(標準価格)
            writer.Write( temp.HADD_TTLSTOCKMOVELISTPRICERF );
            //入力拠点コード
            writer.Write( temp.MOVH_UPDATESECCDRF );
            //入力拠点ガイド略称
            writer.Write( temp.SEC0_SECTIONGUIDESNMRF );
            //入力拠点ガイド名称
            writer.Write( temp.SEC0_SECTIONGUIDENMRF );

        }

        /// <summary>
        ///  FrePStockMoveSlipWorkインスタンス取得
        /// </summary>
        /// <returns>FrePStockMoveSlipWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveSlipWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private FrePStockMoveSlipWork GetFrePStockMoveSlipWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            FrePStockMoveSlipWork temp = new FrePStockMoveSlipWork();

            //在庫移動形式
            temp.MOVH_STOCKMOVEFORMALRF = reader.ReadInt32();
            //在庫移動伝票番号
            temp.MOVH_STOCKMOVESLIPNORF = reader.ReadInt32();
            //移動元拠点コード
            temp.MOVH_BFSECTIONCODERF = reader.ReadString();
            //移動元拠点ガイド略称
            temp.MOVH_BFSECTIONGUIDESNMRF = reader.ReadString();
            //移動元倉庫コード
            temp.MOVH_BFENTERWAREHCODERF = reader.ReadString();
            //移動元倉庫名称
            temp.MOVH_BFENTERWAREHNAMERF = reader.ReadString();
            //移動先拠点コード
            temp.MOVH_AFSECTIONCODERF = reader.ReadString();
            //移動先拠点ガイド略称
            temp.MOVH_AFSECTIONGUIDESNMRF = reader.ReadString();
            //移動先倉庫コード
            temp.MOVH_AFENTERWAREHCODERF = reader.ReadString();
            //移動先倉庫名称
            temp.MOVH_AFENTERWAREHNAMERF = reader.ReadString();
            //出荷予定日
            temp.MOVH_SHIPMENTSCDLDAYRF = reader.ReadInt32();
            //入力日
            temp.MOVH_INPUTDAYRF = reader.ReadInt32();
            //在庫移動入力従業員コード
            temp.MOVH_STOCKMVEMPCODERF = reader.ReadString();
            //在庫移動入力従業員名称
            temp.MOVH_STOCKMVEMPNAMERF = reader.ReadString();
            //出荷担当従業員コード
            temp.MOVH_SHIPAGENTCDRF = reader.ReadString();
            //出荷担当従業員名称
            temp.MOVH_SHIPAGENTNMRF = reader.ReadString();
            //引取担当従業員コード
            temp.MOVH_RECEIVEAGENTCDRF = reader.ReadString();
            //引取担当従業員名称
            temp.MOVH_RECEIVEAGENTNMRF = reader.ReadString();
            //伝票摘要
            temp.MOVH_OUTLINERF = reader.ReadString();
            //倉庫備考1
            temp.MOVH_WAREHOUSENOTE1RF = reader.ReadString();
            //伝票発行済区分
            temp.MOVH_SLIPPRINTFINISHCDRF = reader.ReadInt32();
            //拠点ガイド名称
            temp.SEC1_SECTIONGUIDENMRF = reader.ReadString();
            //自社名称コード1
            temp.SEC1_COMPANYNAMECD1RF = reader.ReadInt32();
            //拠点ガイド名称
            temp.SEC2_SECTIONGUIDENMRF = reader.ReadString();
            //自社名称コード1
            temp.SEC2_COMPANYNAMECD1RF = reader.ReadInt32();
            //自社名称1
            temp.COMPANYINFRF_COMPANYNAME1RF = reader.ReadString();
            //自社名称2
            temp.COMPANYINFRF_COMPANYNAME2RF = reader.ReadString();
            //郵便番号
            temp.COMPANYINFRF_POSTNORF = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.COMPANYINFRF_ADDRESS1RF = reader.ReadString();
            //住所3（番地）
            temp.COMPANYINFRF_ADDRESS3RF = reader.ReadString();
            //住所4（アパート名称）
            temp.COMPANYINFRF_ADDRESS4RF = reader.ReadString();
            //自社電話番号1
            temp.COMPANYINFRF_COMPANYTELNO1RF = reader.ReadString();
            //自社電話番号2
            temp.COMPANYINFRF_COMPANYTELNO2RF = reader.ReadString();
            //自社電話番号3
            temp.COMPANYINFRF_COMPANYTELNO3RF = reader.ReadString();
            //自社電話番号タイトル1
            temp.COMPANYINFRF_COMPANYTELTITLE1RF = reader.ReadString();
            //自社電話番号タイトル2
            temp.COMPANYINFRF_COMPANYTELTITLE2RF = reader.ReadString();
            //自社電話番号タイトル3
            temp.COMPANYINFRF_COMPANYTELTITLE3RF = reader.ReadString();
            //自社PR文
            temp.CMP1_COMPANYPRRF = reader.ReadString();
            //自社名称1
            temp.CMP1_COMPANYNAME1RF = reader.ReadString();
            //自社名称2
            temp.CMP1_COMPANYNAME2RF = reader.ReadString();
            //郵便番号
            temp.CMP1_POSTNORF = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.CMP1_ADDRESS1RF = reader.ReadString();
            //住所3（番地）
            temp.CMP1_ADDRESS3RF = reader.ReadString();
            //住所4（アパート名称）
            temp.CMP1_ADDRESS4RF = reader.ReadString();
            //自社電話番号1
            temp.CMP1_COMPANYTELNO1RF = reader.ReadString();
            //自社電話番号2
            temp.CMP1_COMPANYTELNO2RF = reader.ReadString();
            //自社電話番号3
            temp.CMP1_COMPANYTELNO3RF = reader.ReadString();
            //自社電話番号タイトル1
            temp.CMP1_COMPANYTELTITLE1RF = reader.ReadString();
            //自社電話番号タイトル2
            temp.CMP1_COMPANYTELTITLE2RF = reader.ReadString();
            //自社電話番号タイトル3
            temp.CMP1_COMPANYTELTITLE3RF = reader.ReadString();
            //銀行振込案内文
            temp.CMP1_TRANSFERGUIDANCERF = reader.ReadString();
            //銀行口座1
            temp.CMP1_ACCOUNTNOINFO1RF = reader.ReadString();
            //銀行口座2
            temp.CMP1_ACCOUNTNOINFO2RF = reader.ReadString();
            //銀行口座3
            temp.CMP1_ACCOUNTNOINFO3RF = reader.ReadString();
            //自社設定摘要1
            temp.CMP1_COMPANYSETNOTE1RF = reader.ReadString();
            //自社設定摘要2
            temp.CMP1_COMPANYSETNOTE2RF = reader.ReadString();
            //画像情報区分
            temp.CMP1_IMAGEINFODIVRF = reader.ReadInt32();
            //画像情報コード
            temp.CMP1_IMAGEINFOCODERF = reader.ReadInt32();
            //自社URL
            temp.CMP1_COMPANYURLRF = reader.ReadString();
            //自社PR文2
            temp.CMP1_COMPANYPRSENTENCE2RF = reader.ReadString();
            //画像印字用コメント1
            temp.CMP1_IMAGECOMMENTFORPRT1RF = reader.ReadString();
            //画像印字用コメント2
            temp.CMP1_IMAGECOMMENTFORPRT2RF = reader.ReadString();
            //自社PR文
            temp.CMP2_COMPANYPRRF = reader.ReadString();
            //自社名称1
            temp.CMP2_COMPANYNAME1RF = reader.ReadString();
            //自社名称2
            temp.CMP2_COMPANYNAME2RF = reader.ReadString();
            //郵便番号
            temp.CMP2_POSTNORF = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.CMP2_ADDRESS1RF = reader.ReadString();
            //住所3（番地）
            temp.CMP2_ADDRESS3RF = reader.ReadString();
            //住所4（アパート名称）
            temp.CMP2_ADDRESS4RF = reader.ReadString();
            //自社電話番号1
            temp.CMP2_COMPANYTELNO1RF = reader.ReadString();
            //自社電話番号2
            temp.CMP2_COMPANYTELNO2RF = reader.ReadString();
            //自社電話番号3
            temp.CMP2_COMPANYTELNO3RF = reader.ReadString();
            //自社電話番号タイトル1
            temp.CMP2_COMPANYTELTITLE1RF = reader.ReadString();
            //自社電話番号タイトル2
            temp.CMP2_COMPANYTELTITLE2RF = reader.ReadString();
            //自社電話番号タイトル3
            temp.CMP2_COMPANYTELTITLE3RF = reader.ReadString();
            //銀行振込案内文
            temp.CMP2_TRANSFERGUIDANCERF = reader.ReadString();
            //銀行口座1
            temp.CMP2_ACCOUNTNOINFO1RF = reader.ReadString();
            //銀行口座2
            temp.CMP2_ACCOUNTNOINFO2RF = reader.ReadString();
            //銀行口座3
            temp.CMP2_ACCOUNTNOINFO3RF = reader.ReadString();
            //自社設定摘要1
            temp.CMP2_COMPANYSETNOTE1RF = reader.ReadString();
            //自社設定摘要2
            temp.CMP2_COMPANYSETNOTE2RF = reader.ReadString();
            //自社URL
            temp.CMP2_COMPANYURLRF = reader.ReadString();
            //自社PR文2
            temp.CMP2_COMPANYPRSENTENCE2RF = reader.ReadString();
            //画像印字用コメント1
            temp.CMP2_IMAGECOMMENTFORPRT1RF = reader.ReadString();
            //画像印字用コメント2
            temp.CMP2_IMAGECOMMENTFORPRT2RF = reader.ReadString();
            //カナ
            temp.EMP1_KANARF = reader.ReadString();
            //短縮名称
            temp.EMP1_SHORTNAMERF = reader.ReadString();
            //カナ
            temp.EMP2_KANARF = reader.ReadString();
            //短縮名称
            temp.EMP2_SHORTNAMERF = reader.ReadString();
            //カナ
            temp.EMP3_KANARF = reader.ReadString();
            //短縮名称
            temp.EMP3_SHORTNAMERF = reader.ReadString();
            //画像情報データ
            //在庫移動形式名称
            temp.HADD_STOCKMOVEFORMALNMRF = reader.ReadString();
            //出荷予定日西暦年
            temp.HADD_SHIPMENTSCDLDFYRF = reader.ReadInt32();
            //出荷予定日西暦年略
            temp.HADD_SHIPMENTSCDLDFSRF = reader.ReadInt32();
            //出荷予定日和暦年
            temp.HADD_SHIPMENTSCDLDFWRF = reader.ReadInt32();
            //出荷予定日月
            temp.HADD_SHIPMENTSCDLDFMRF = reader.ReadInt32();
            //出荷予定日日
            temp.HADD_SHIPMENTSCDLDFDRF = reader.ReadInt32();
            //出荷予定日元号
            temp.HADD_SHIPMENTSCDLDFGRF = reader.ReadString();
            //出荷予定日略号
            temp.HADD_SHIPMENTSCDLDFRRF = reader.ReadString();
            //出荷予定日リテラル(/)
            temp.HADD_SHIPMENTSCDLDFLSRF = reader.ReadString();
            //出荷予定日リテラル(.)
            temp.HADD_SHIPMENTSCDLDFLPRF = reader.ReadString();
            //出荷予定日リテラル(年)
            temp.HADD_SHIPMENTSCDLDFLYRF = reader.ReadString();
            //出荷予定日リテラル(月)
            temp.HADD_SHIPMENTSCDLDFLMRF = reader.ReadString();
            //出荷予定日リテラル(日)
            temp.HADD_SHIPMENTSCDLDFLDRF = reader.ReadString();
            //入力日西暦年
            temp.HADD_INPUTDFYRF = reader.ReadInt32();
            //入力日西暦年略
            temp.HADD_INPUTDFSRF = reader.ReadInt32();
            //入力日和暦年
            temp.HADD_INPUTDFWRF = reader.ReadInt32();
            //入力日月
            temp.HADD_INPUTDFMRF = reader.ReadInt32();
            //入力日日
            temp.HADD_INPUTDFDRF = reader.ReadInt32();
            //入力日元号
            temp.HADD_INPUTDFGRF = reader.ReadString();
            //入力日略号
            temp.HADD_INPUTDFRRF = reader.ReadString();
            //入力日リテラル(/)
            temp.HADD_INPUTDFLSRF = reader.ReadString();
            //入力日リテラル(.)
            temp.HADD_INPUTDFLPRF = reader.ReadString();
            //入力日リテラル(年)
            temp.HADD_INPUTDFLYRF = reader.ReadString();
            //入力日リテラル(月)
            temp.HADD_INPUTDFLMRF = reader.ReadString();
            //入力日リテラル(日)
            temp.HADD_INPUTDFLDRF = reader.ReadString();
            //自社備考１
            temp.HADD_NOTE1RF = reader.ReadString();
            //自社備考２
            temp.HADD_NOTE2RF = reader.ReadString();
            //自社備考３
            temp.HADD_NOTE3RF = reader.ReadString();
            //再発行マーク
            temp.HADD_REISSUEMARKRF = reader.ReadString();
            //プリンタ管理No
            temp.HADD_PRINTERMNGNORF = reader.ReadInt32();
            //伝票印刷設定用帳票ID
            temp.HADD_SLIPPRTSETPAPERIDRF = reader.ReadString();
            //印刷時刻 時
            temp.HADD_PRINTTIMEHOURRF = reader.ReadInt32();
            //印刷時刻 分
            temp.HADD_PRINTTIMEMINUTERF = reader.ReadInt32();
            //印刷時刻 秒
            temp.HADD_PRINTTIMESECONDRF = reader.ReadInt32();
            //伝票合計金額
            temp.HADD_TTLSTOCKMOVEPRICERF = reader.ReadInt64();
            //伝票合計金額(標準価格)
            temp.HADD_TTLSTOCKMOVELISTPRICERF = reader.ReadInt64();
            //入力拠点コード
            temp.MOVH_UPDATESECCDRF = reader.ReadString();
            //入力拠点ガイド略称
            temp.SEC0_SECTIONGUIDESNMRF = reader.ReadString();
            //入力拠点ガイド名称
            temp.SEC0_SECTIONGUIDENMRF = reader.ReadString();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>FrePStockMoveSlipWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FrePStockMoveSlipWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FrePStockMoveSlipWork temp = GetFrePStockMoveSlipWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (FrePStockMoveSlipWork[])lst.ToArray( typeof( FrePStockMoveSlipWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
