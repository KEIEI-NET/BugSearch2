using System;
using System.Collections;

namespace Broadleaf.Application.Controller
{       
    /// <summary>
    /// 請求残・売掛残テキスト出力　結果クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   請求残・売掛残テキスト出力　結果クラス</br>
    /// <br>Programmer       :   30521 本山　貴将</br>
    /// <br>Date             :   2014/08/25</br>
    /// </remarks>
    public class DmdARecOutPutBlnceRslt
    {
        /// <summary>検索上限</summary>
        /// <remarks>検索上限数+1をセット</remarks>
        private Int64 _searchCnt;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>(配列)　全社指定は{""}</remarks>
        private string[] _sectionCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>請求先コード</summary>
        private Int32 _claimCode;

        /// <summary>開始売上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_SalesDate;

        /// <summary>終了売上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_SalesDate;

        /// <summary>開始入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_AddUpADate;

        /// <summary>終了入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_AddUpADate;

        /// <summary>計上年月</summary>
        /// <remarks>得意先請求金額マスタ 計上年月 YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>受注ステータス</summary>
        /// <remarks>(配列)　全指定の場合は{""}</remarks>
        private Int32[] _acptAnOdrStatus;

        /// <summary>売上伝票区分</summary>
        /// <remarks>(配列)　全指定の場合は{""}</remarks>
        private Int32[] _salesSlipCd;

        /// <summary>伝票番号</summary>
        /// <remarks>売上伝票番号</remarks>
        private string _salesSlipNum = "";

        /// <summary>担当者</summary>
        /// <remarks>販売従業員コード</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>受注者</summary>
        /// <remarks>受付従業員コード</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>発行者</summary>
        /// <remarks>売上入力者コード</remarks>
        private string _salesInputCode = "";

        /// <summary>管理番号</summary>
        /// <remarks>車輌管理コード</remarks>
        private string _carMngCode = "";

        /// <summary>車種名称</summary>
        /// <remarks>車種全角名称</remarks>
        private string _modelFullName = "";

        /// <summary>型式</summary>
        /// <remarks>型式（フル型）</remarks>
        private string _fullModel = "";

        /// <summary>車台№</summary>
        /// <remarks>車台番号（検索用）</remarks>
        private Int32 _searchFrameNo;

        // -------ADD 2010/08/05-------->>>>>
        /// <summary>車台№</summary>
        /// <remarks>車台番号</remarks>
        private string _frameNo;
        // -------ADD 2010/08/05--------<<<<<

        /// <summary>得意先注番</summary>
        /// <remarks>相手先伝票番号</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>カラー名称</summary>
        /// <remarks>カラー名称1</remarks>
        private string _colorName1 = "";

        /// <summary>トリム名称</summary>
        /// <remarks>トリム名称</remarks>
        private string _trimName = "";

        /// <summary>ＵＯＥ送信</summary>
        /// <remarks>UOE発注データのデータ送信区分</remarks>
        private Int32 _dataSendCode;

        /// <summary>備考１</summary>
        /// <remarks>伝票備考</remarks>
        private string _slipNote = "";

        /// <summary>備考２</summary>
        /// <remarks>伝票備考２</remarks>
        private string _slipNote2 = "";

        /// <summary>備考３</summary>
        /// <remarks>伝票備考３</remarks>
        private string _slipNote3 = "";

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>ＵＯＥリマーク１</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        /// <remarks>ＵＯＥリマーク２</remarks>
        private string _uoeRemark2 = "";

        /// <summary>ＢＬグループ</summary>
        /// <remarks>BLグループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>ＢＬコード</summary>
        /// <remarks>BL商品コード</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>品名</summary>
        /// <remarks>商品名称</remarks>
        private string _goodsName = "";

        /// <summary>品番</summary>
        /// <remarks>商品番号</remarks>
        private string _goodsNo = "";

        /// <summary>メーカーコード</summary>
        /// <remarks>商品メーカーコード</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>販売区分コード</summary>
        /// <remarks>販売区分コード</remarks>
        private Int32 _salesCode;

        /// <summary>自社分類コード</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>在庫取寄区分</summary>
        /// <remarks>売上在庫取寄せ区分(-1:全て 0:取寄せ 1:在庫)</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>倉庫コード</summary>
        /// <remarks>倉庫コード</remarks>
        private string _warehouseCode = "";

        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入データの相手先伝票番号</remarks>
        private string _supplierSlipNo = "";

        /// <summary>仕入先</summary>
        /// <remarks>仕入先コード</remarks>
        private Int32 _supplierCd;

        /// <summary>発注先</summary>
        /// <remarks>UOE発注データの仕入先コード</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>明細備考</summary>
        /// <remarks>明細備考</remarks>
        private string _dtlNote = "";

        /// <summary>伝票検索区分</summary>
        /// <remarks>0:全て 1:売上のみ 2:入金のみ</remarks>
        private Int32 _searchType;

        /// <summary>納品先コード</summary>
        private Int32 _addresseeCode;

        /// <summary>商品属性[明細]</summary>
        /// <remarks>0:純正 1:優良</remarks>
        private Int32 _goodsKindCode;

        /// <summary>商品大分類コード[明細]</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品中分類コード[明細]</summary>
        /// <remarks>旧中分類コード</remarks>
        private Int32 _goodsMGroup;

        /// <summary>倉庫棚番[明細]</summary>
        private string _warehouseShelfNo = "";

        /// <summary>売上伝票区分（明細）[明細]</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
        private Int32 _salesSlipCdDtl;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>販売従業員名称</summary>
        private string _salesEmployeeNm = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        // --- ADD 2010/12/20 ---------->>>>>
        /// <summary>売上伝票番号</summary>
        private string _hisDtlSlipNum = "";

        /// <remarks>受注ステータス（元）</remarks>
        private Int32 _acptAnOdrStatusSrc;
        // --- ADD 2010/12/20 ----------<<<<<
        // ---------------------- ADD START 2011/07/18 朱宝軍 ----------------->>>>>
        /// <summary>自動回答区分(SCM)</summary>
        /// <remarks>0:通常(PCC連携なし)、1:手動回答、2:自動回答</remarks>
        private Int32 _autoAnswerDivSCM;

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>自動回答区分(SCM)プロパティ</summary>
        /// <value>1:通常(PCC連携なし)、2:手動回答、3:自動回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分(SCM)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }

        /// <summary>
        /// 問合せ番号
        /// </summary>
        private Int64 _inquiryNumber;

        /// <summary>
        /// 問合せ番号
        /// </summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ番号プロパティ</br>
        /// <br>Programer        :   楊洋</br>
        /// </remarks>
        public Int64 InquiryNumber
        {
            get { return _inquiryNumber; }
            set { _inquiryNumber = value; }
        }

        /// public propaty name  :  SearchCnt
        /// <summary>検索上限プロパティ</summary>
        /// <value>検索上限数+1をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索上限プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SearchCnt
        {
            get { return _searchCnt; }
            set { _searchCnt = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>(配列)　全社指定は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  St_SalesDate
        /// <summary>開始売上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>終了売上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  St_AddUpADate
        /// <summary>開始入力日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_AddUpADate
        {
            get { return _st_AddUpADate; }
            set { _st_AddUpADate = value; }
        }

        /// public propaty name  :  Ed_AddUpADate
        /// <summary>終了入力日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_AddUpADate
        {
            get { return _ed_AddUpADate; }
            set { _ed_AddUpADate = value; }
        }

        /// public propaty name  :  AddUpYearMonth
        /// <summary>計上年月プロパティ</summary>
        /// <value>得意先請求金額マスタ 計上年月 YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }
               

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>(配列)　全指定の場合は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipCd
        /// <summary>売上伝票区分プロパティ</summary>
        /// <value>(配列)　全指定の場合は{""}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32[] SalesSlipCd
        {
            get { return _salesSlipCd; }
            set { _salesSlipCd = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>伝票番号プロパティ</summary>
        /// <value>売上伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>担当者プロパティ</summary>
        /// <value>販売従業員コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   担当者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受注者プロパティ</summary>
        /// <value>受付従業員コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>発行者プロパティ</summary>
        /// <value>売上入力者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>管理番号プロパティ</summary>
        /// <value>車輌管理コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種名称プロパティ</summary>
        /// <value>車種全角名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式プロパティ</summary>
        /// <value>型式（フル型）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModel
        {
            get { return _fullModel; }
            set { _fullModel = value; }
        }

        /// public propaty name  :  SearchFrameNo
        /// <summary>車台№プロパティ</summary>
        /// <value>車台番号（検索用）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台№プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchFrameNo
        {
            get { return _searchFrameNo; }
            set { _searchFrameNo = value; }
        }

        /// public propaty name  :  FrameNo
        /// <summary>車台№プロパティ</summary>
        /// <value>車台番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車台№プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrameNo
        {
            get { return _frameNo; }
            set { _frameNo = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>得意先注番プロパティ</summary>
        /// <value>相手先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先注番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  ColorName1
        /// <summary>カラー名称プロパティ</summary>
        /// <value>カラー名称1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ColorName1
        {
            get { return _colorName1; }
            set { _colorName1 = value; }
        }

        /// public propaty name  :  TrimName
        /// <summary>トリム名称プロパティ</summary>
        /// <value>トリム名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   トリム名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TrimName
        {
            get { return _trimName; }
            set { _trimName = value; }
        }

        /// public propaty name  :  DataSendCode
        /// <summary>ＵＯＥ送信プロパティ</summary>
        /// <value>UOE発注データのデータ送信区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥ送信プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataSendCode
        {
            get { return _dataSendCode; }
            set { _dataSendCode = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>備考１プロパティ</summary>
        /// <value>伝票備考</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>備考２プロパティ</summary>
        /// <value>伝票備考２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>備考３プロパティ</summary>
        /// <value>伝票備考３</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote3
        {
            get { return _slipNote3; }
            set { _slipNote3 = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// <value>ＵＯＥリマーク１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// <value>ＵＯＥリマーク２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>ＢＬグループプロパティ</summary>
        /// <value>BLグループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬグループプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>ＢＬコードプロパティ</summary>
        /// <value>BL商品コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>品名プロパティ</summary>
        /// <value>商品名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// <value>商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>商品メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// <value>販売区分コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// <value>自社分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  SalesOrderDivCd
        /// <summary>在庫取寄区分プロパティ</summary>
        /// <value>売上在庫取寄せ区分(-1:全て 0:取寄せ 1:在庫)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫取寄区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesOrderDivCd
        {
            get { return _salesOrderDivCd; }
            set { _salesOrderDivCd = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>倉庫コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>仕入データの相手先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先プロパティ</summary>
        /// <value>仕入先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>発注先プロパティ</summary>
        /// <value>UOE発注データの仕入先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>明細備考プロパティ</summary>
        /// <value>明細備考</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  SearchType
        /// <summary>伝票検索区分プロパティ</summary>
        /// <value>0:全て 1:売上のみ 2:入金のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        /// public propaty name  :  AddresseeCode
        /// <summary>納品先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddresseeCode
        {
            get { return _addresseeCode; }
            set { _addresseeCode = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>商品属性[明細]プロパティ</summary>
        /// <value>0:純正 1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コード[明細]プロパティ</summary>
        /// <value>旧大分類（ユーザーガイド）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コード[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コード[明細]プロパティ</summary>
        /// <value>旧中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コード[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番[明細]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分（明細）[明細]プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分（明細）[明細]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>販売従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品コード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        // --- ADD 2010/12/20 ---------->>>>>
        /// public propaty name  :  HisDtlSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HisDtlSlipNum
        {
            get { return _hisDtlSlipNum; }
            set { _hisDtlSlipNum = value; }
        }

        /// public propaty name  :  AcptAnOdrStatusSrc
        /// <summary>受注ステータス（元）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータス（元）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatusSrc
        {
            get { return _acptAnOdrStatusSrc; }
            set { _acptAnOdrStatusSrc = value; }
        }

        /// <summary>
        /// 得意先電子元帳検索条件(残高・伝票・明細)コンストラクタ
        /// </summary>
        /// <returns>CustPrtPprクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DmdARecOutPutBlnceRslt()
        {
            // 在庫取寄区分(-1:全て)
            SalesOrderDivCd = -1;
            // 商品属性(-1:全て)
            GoodsKindCode = -1;
        }

        /// <summary>
        /// 得意先電子元帳検索条件(残高・伝票・明細)コンストラクタ
        /// </summary>
        /// <param name="searchCnt">検索上限(検索上限数+1をセット)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード((配列)　全社指定は{""})</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="claimCode">請求先コード</param>
        /// <param name="st_SalesDate">開始売上日付(YYYYMMDD)</param>
        /// <param name="ed_SalesDate">終了売上日付(YYYYMMDD)</param>
        /// <param name="st_AddUpADate">開始入力日付(YYYYMMDD)</param>
        /// <param name="ed_AddUpADate">終了入力日付(YYYYMMDD)</param>
        /// <param name="addUpYearMonth">計上年月(得意先請求金額マスタ 計上年月 YYYYMM)</param>
        /// <param name="acptAnOdrStatus">受注ステータス((配列)　全指定の場合は{""})</param>
        /// <param name="salesSlipCd">売上伝票区分((配列)　全指定の場合は{""})</param>
        /// <param name="salesSlipNum">伝票番号(売上伝票番号)</param>
        /// <param name="salesEmployeeCd">担当者(販売従業員コード)</param>
        /// <param name="frontEmployeeCd">受注者(受付従業員コード)</param>
        /// <param name="salesInputCode">発行者(売上入力者コード)</param>
        /// <param name="carMngCode">管理番号(車輌管理コード)</param>
        /// <param name="modelFullName">車種名称(車種全角名称)</param>
        /// <param name="fullModel">型式(型式（フル型）)</param>
        /// <param name="searchFrameNo">車台№(車台番号（検索用）)</param>
        /// <param name="frameNo">車台№(車台番号)</param>
        /// <param name="partySaleSlipNum">得意先注番(相手先伝票番号)</param>
        /// <param name="colorName1">カラー名称(カラー名称1)</param>
        /// <param name="trimName">トリム名称(トリム名称)</param>
        /// <param name="dataSendCode">ＵＯＥ送信(UOE発注データのデータ送信区分)</param>
        /// <param name="slipNote">備考１(伝票備考)</param>
        /// <param name="slipNote2">備考２(伝票備考２)</param>
        /// <param name="slipNote3">備考３(伝票備考３)</param>
        /// <param name="uoeRemark1">ＵＯＥリマーク１(ＵＯＥリマーク１)</param>
        /// <param name="uoeRemark2">ＵＯＥリマーク２(ＵＯＥリマーク２)</param>
        /// <param name="bLGroupCode">ＢＬグループ(BLグループコード)</param>
        /// <param name="bLGoodsCode">ＢＬコード(BL商品コード)</param>
        /// <param name="goodsName">品名(商品名称)</param>
        /// <param name="goodsNo">品番(商品番号)</param>
        /// <param name="goodsMakerCd">メーカーコード(商品メーカーコード)</param>
        /// <param name="salesCode">販売区分コード(販売区分コード)</param>
        /// <param name="enterpriseGanreCode">自社分類コード(自社分類コード)</param>
        /// <param name="salesOrderDivCd">在庫取寄区分(売上在庫取寄せ区分(-1:全て 0:取寄せ 1:在庫))</param>
        /// <param name="warehouseCode">倉庫コード(倉庫コード)</param>
        /// <param name="supplierSlipNo">仕入伝票番号(仕入データの相手先伝票番号)</param>
        /// <param name="supplierCd">仕入先(仕入先コード)</param>
        /// <param name="uOESupplierCd">発注先(UOE発注データの仕入先コード)</param>
        /// <param name="dtlNote">明細備考(明細備考)</param>
        /// <param name="searchType">伝票検索区分(0:全て 1:売上のみ 2:入金のみ)</param>
        /// <param name="addresseeCode">納品先コード</param>
        /// <param name="goodsKindCode">商品属性[明細](0:純正 1:優良)</param>
        /// <param name="goodsLGroup">商品大分類コード[明細](旧大分類（ユーザーガイド）)</param>
        /// <param name="goodsMGroup">商品中分類コード[明細](旧中分類コード)</param>
        /// <param name="warehouseShelfNo">倉庫棚番[明細]</param>
        /// <param name="salesSlipCdDtl">売上伝票区分（明細）[明細](0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="salesEmployeeNm">販売従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="warehouseName">倉庫名称</param>
        /// <param name="autoAnswerDivSCM">自動回答区分(SCM)</param>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <returns>CustPrtPprクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public DmdARecOutPutBlnceRslt(Int64 searchCnt, string enterpriseCode, string[] sectionCode, Int32 customerCode, Int32 claimCode, DateTime st_SalesDate, DateTime ed_SalesDate, DateTime st_AddUpADate, DateTime ed_AddUpADate, DateTime addUpYearMonth, Int32[] acptAnOdrStatus, Int32[] salesSlipCd, string salesSlipNum, string salesEmployeeCd, string frontEmployeeCd, string salesInputCode, string carMngCode, string modelFullName, string fullModel, Int32 searchFrameNo, string frameNo, string partySaleSlipNum, string colorName1, string trimName, Int32 dataSendCode, string slipNote, string slipNote2, string slipNote3, string uoeRemark1, string uoeRemark2, Int32 bLGroupCode, Int32 bLGoodsCode, string goodsName, string goodsNo, Int32 goodsMakerCd, Int32 salesCode, Int32 enterpriseGanreCode, Int32 salesOrderDivCd, string warehouseCode, string supplierSlipNo, Int32 supplierCd, Int32 uOESupplierCd, string dtlNote, Int32 searchType, Int32 addresseeCode, Int32 goodsKindCode, Int32 goodsLGroup, Int32 goodsMGroup, string warehouseShelfNo, Int32 salesSlipCdDtl, string enterpriseName, string salesEmployeeNm, string bLGoodsName, string warehouseName, string hisDtlSlipNum, Int32 acptAnOdrStatusSrc, Int32 autoAnswerDivSCM, Int64 inquiryNumber)	// ADD 2011/11/28 楊洋
        {
            this._searchCnt = searchCnt;
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._claimCode = claimCode;
            this._st_SalesDate = st_SalesDate;
            this._ed_SalesDate = ed_SalesDate;
            this._st_AddUpADate = st_AddUpADate;
            this._ed_AddUpADate = ed_AddUpADate;
            this.AddUpYearMonth = addUpYearMonth;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipCd = salesSlipCd;
            this._salesSlipNum = salesSlipNum;
            this._salesEmployeeCd = salesEmployeeCd;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesInputCode = salesInputCode;
            this._carMngCode = carMngCode;
            this._modelFullName = modelFullName;
            this._fullModel = fullModel;
            this._searchFrameNo = searchFrameNo;
            this._frameNo = frameNo;// ADD 2010/08/05
            this._partySaleSlipNum = partySaleSlipNum;
            this._colorName1 = colorName1;
            this._trimName = trimName;
            this._dataSendCode = dataSendCode;
            this._slipNote = slipNote;
            this._slipNote2 = slipNote2;
            this._slipNote3 = slipNote3;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsName = goodsName;
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._salesCode = salesCode;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._salesOrderDivCd = salesOrderDivCd;
            this._warehouseCode = warehouseCode;
            this._supplierSlipNo = supplierSlipNo;
            this._supplierCd = supplierCd;
            this._uOESupplierCd = uOESupplierCd;
            this._dtlNote = dtlNote;
            this._searchType = searchType;
            this._addresseeCode = addresseeCode;
            this._goodsKindCode = goodsKindCode;
            this._goodsLGroup = goodsLGroup;
            this._goodsMGroup = goodsMGroup;
            this._warehouseShelfNo = warehouseShelfNo;
            this._salesSlipCdDtl = salesSlipCdDtl;
            this._enterpriseName = enterpriseName;
            this._salesEmployeeNm = salesEmployeeNm;
            this._bLGoodsName = bLGoodsName;
            this._warehouseName = warehouseName;
            this._hisDtlSlipNum = hisDtlSlipNum;
            this.AcptAnOdrStatusSrc = AcptAnOdrStatusSrc;
            this._autoAnswerDivSCM = autoAnswerDivSCM;
            this._inquiryNumber = inquiryNumber;

        }

        /// <summary>
        /// 得意先電子元帳検索条件(残高・伝票・明細)複製処理
        /// </summary>
        /// <returns>CustPrtPprクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCustPrtPprクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public DmdARecOutPutBlnceRslt Clone()
        {
            return new DmdARecOutPutBlnceRslt(this._searchCnt, this._enterpriseCode, this._sectionCode, this._customerCode, this._claimCode, this._st_SalesDate, this._ed_SalesDate, this._st_AddUpADate, this._ed_AddUpADate, this._addUpYearMonth, this._acptAnOdrStatus, this._salesSlipCd, this._salesSlipNum, this._salesEmployeeCd, this._frontEmployeeCd, this._salesInputCode, this._carMngCode, this._modelFullName, this._fullModel, this._searchFrameNo, this._frameNo, this._partySaleSlipNum, this._colorName1, this._trimName, this._dataSendCode, this._slipNote, this._slipNote2, this._slipNote3, this._uoeRemark1, this._uoeRemark2, this._bLGroupCode, this._bLGoodsCode, this._goodsName, this._goodsNo, this._goodsMakerCd, this._salesCode, this._enterpriseGanreCode, this._salesOrderDivCd, this._warehouseCode, this._supplierSlipNo, this._supplierCd, this._uOESupplierCd, this._dtlNote, this._searchType, this._addresseeCode, this._goodsKindCode, this._goodsLGroup, this._goodsMGroup, this._warehouseShelfNo, this._salesSlipCdDtl, this._enterpriseName, this._salesEmployeeNm, this._bLGoodsName, this._warehouseName, this._hisDtlSlipNum, this._acptAnOdrStatusSrc, this._autoAnswerDivSCM, this._inquiryNumber);// ADD 2011/11/28 楊洋
        }

        /// <summary>
        /// 得意先電子元帳検索条件(残高・伝票・明細)比較処理
        /// </summary>
        /// <param name="target">比較対象のCustPrtPprクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/11/28 楊洋 問合せ番号の追加</br>
        /// </remarks>
        public bool Equals(DmdARecOutPutBlnceRslt target)
        {
            return ((this.SearchCnt == target.SearchCnt)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.St_SalesDate == target.St_SalesDate)
                 && (this.Ed_SalesDate == target.Ed_SalesDate)
                 && (this.St_AddUpADate == target.St_AddUpADate)
                 && (this.Ed_AddUpADate == target.Ed_AddUpADate)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipCd == target.SalesSlipCd)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.CarMngCode == target.CarMngCode)
                 && (this.ModelFullName == target.ModelFullName)
                 && (this.FullModel == target.FullModel)
                 && (this.SearchFrameNo == target.SearchFrameNo)
                 && (this.FrameNo == target.FrameNo)// ADD 2010/08/05
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.ColorName1 == target.ColorName1)
                 && (this.TrimName == target.TrimName)
                 && (this.DataSendCode == target.DataSendCode)
                 && (this.SlipNote == target.SlipNote)
                 && (this.SlipNote2 == target.SlipNote2)
                 && (this.SlipNote3 == target.SlipNote3)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.SalesCode == target.SalesCode)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.DtlNote == target.DtlNote)
                 && (this.SearchType == target.SearchType)
                 && (this.AddresseeCode == target.AddresseeCode)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsLGroup == target.GoodsLGroup)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.SalesSlipCdDtl == target.SalesSlipCdDtl)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.HisDtlSlipNum == target.HisDtlSlipNum)
                 && (this.AcptAnOdrStatusSrc == target.AcptAnOdrStatusSrc)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.AutoAnswerDivSCM == target.AutoAnswerDivSCM)
                 && (this.InquiryNumber == target.InquiryNumber));
        }

        /// <summary>
        /// 得意先電子元帳検索条件(残高・伝票・明細)比較処理
        /// </summary>
        /// <param name="custPrtPpr1">
        ///                    比較するCustPrtPprクラスのインスタンス
        /// </param>
        /// <param name="custPrtPpr2">比較するCustPrtPprクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/11/28 楊洋 問合せ番号の追加</br>
        /// </remarks>
        public static bool Equals(DmdARecOutPutBlnceRslt custPrtPpr1, DmdARecOutPutBlnceRslt custPrtPpr2)
        {
            return ((custPrtPpr1.SearchCnt == custPrtPpr2.SearchCnt)
                 && (custPrtPpr1.EnterpriseCode == custPrtPpr2.EnterpriseCode)
                 && (custPrtPpr1.SectionCode == custPrtPpr2.SectionCode)
                 && (custPrtPpr1.CustomerCode == custPrtPpr2.CustomerCode)
                 && (custPrtPpr1.ClaimCode == custPrtPpr2.ClaimCode)
                 && (custPrtPpr1.St_SalesDate == custPrtPpr2.St_SalesDate)
                 && (custPrtPpr1.Ed_SalesDate == custPrtPpr2.Ed_SalesDate)
                 && (custPrtPpr1.St_AddUpADate == custPrtPpr2.St_AddUpADate)
                 && (custPrtPpr1.Ed_AddUpADate == custPrtPpr2.Ed_AddUpADate)
                 && (custPrtPpr1.AddUpYearMonth == custPrtPpr2.AddUpYearMonth)
                 && (custPrtPpr1.AcptAnOdrStatus == custPrtPpr2.AcptAnOdrStatus)
                 && (custPrtPpr1.SalesSlipCd == custPrtPpr2.SalesSlipCd)
                 && (custPrtPpr1.SalesSlipNum == custPrtPpr2.SalesSlipNum)
                 && (custPrtPpr1.SalesEmployeeCd == custPrtPpr2.SalesEmployeeCd)
                 && (custPrtPpr1.FrontEmployeeCd == custPrtPpr2.FrontEmployeeCd)
                 && (custPrtPpr1.SalesInputCode == custPrtPpr2.SalesInputCode)
                 && (custPrtPpr1.CarMngCode == custPrtPpr2.CarMngCode)
                 && (custPrtPpr1.ModelFullName == custPrtPpr2.ModelFullName)
                 && (custPrtPpr1.FullModel == custPrtPpr2.FullModel)
                 && (custPrtPpr1.SearchFrameNo == custPrtPpr2.SearchFrameNo)
                 && (custPrtPpr1.FrameNo == custPrtPpr2.FrameNo)// ADD 2010/08/05
                 && (custPrtPpr1.PartySaleSlipNum == custPrtPpr2.PartySaleSlipNum)
                 && (custPrtPpr1.ColorName1 == custPrtPpr2.ColorName1)
                 && (custPrtPpr1.TrimName == custPrtPpr2.TrimName)
                 && (custPrtPpr1.DataSendCode == custPrtPpr2.DataSendCode)
                 && (custPrtPpr1.SlipNote == custPrtPpr2.SlipNote)
                 && (custPrtPpr1.SlipNote2 == custPrtPpr2.SlipNote2)
                 && (custPrtPpr1.SlipNote3 == custPrtPpr2.SlipNote3)
                 && (custPrtPpr1.UoeRemark1 == custPrtPpr2.UoeRemark1)
                 && (custPrtPpr1.UoeRemark2 == custPrtPpr2.UoeRemark2)
                 && (custPrtPpr1.BLGroupCode == custPrtPpr2.BLGroupCode)
                 && (custPrtPpr1.BLGoodsCode == custPrtPpr2.BLGoodsCode)
                 && (custPrtPpr1.GoodsName == custPrtPpr2.GoodsName)
                 && (custPrtPpr1.GoodsNo == custPrtPpr2.GoodsNo)
                 && (custPrtPpr1.GoodsMakerCd == custPrtPpr2.GoodsMakerCd)
                 && (custPrtPpr1.SalesCode == custPrtPpr2.SalesCode)
                 && (custPrtPpr1.EnterpriseGanreCode == custPrtPpr2.EnterpriseGanreCode)
                 && (custPrtPpr1.SalesOrderDivCd == custPrtPpr2.SalesOrderDivCd)
                 && (custPrtPpr1.WarehouseCode == custPrtPpr2.WarehouseCode)
                 && (custPrtPpr1.SupplierSlipNo == custPrtPpr2.SupplierSlipNo)
                 && (custPrtPpr1.SupplierCd == custPrtPpr2.SupplierCd)
                 && (custPrtPpr1.UOESupplierCd == custPrtPpr2.UOESupplierCd)
                 && (custPrtPpr1.DtlNote == custPrtPpr2.DtlNote)
                 && (custPrtPpr1.SearchType == custPrtPpr2.SearchType)
                 && (custPrtPpr1.AddresseeCode == custPrtPpr2.AddresseeCode)
                 && (custPrtPpr1.GoodsKindCode == custPrtPpr2.GoodsKindCode)
                 && (custPrtPpr1.GoodsLGroup == custPrtPpr2.GoodsLGroup)
                 && (custPrtPpr1.GoodsMGroup == custPrtPpr2.GoodsMGroup)
                 && (custPrtPpr1.WarehouseShelfNo == custPrtPpr2.WarehouseShelfNo)
                 && (custPrtPpr1.SalesSlipCdDtl == custPrtPpr2.SalesSlipCdDtl)
                 && (custPrtPpr1.EnterpriseName == custPrtPpr2.EnterpriseName)
                 && (custPrtPpr1.SalesEmployeeNm == custPrtPpr2.SalesEmployeeNm)
                 && (custPrtPpr1.BLGoodsName == custPrtPpr2.BLGoodsName)
                 && (custPrtPpr1.HisDtlSlipNum == custPrtPpr2.HisDtlSlipNum)
                 && (custPrtPpr1.AcptAnOdrStatusSrc == custPrtPpr2.AcptAnOdrStatusSrc)
                 && (custPrtPpr1.WarehouseName == custPrtPpr2.WarehouseName)
                 && (custPrtPpr1.AutoAnswerDivSCM == custPrtPpr2.AutoAnswerDivSCM)
                 && (custPrtPpr1.InquiryNumber == custPrtPpr2.InquiryNumber));

        }
        /// <summary>
        /// 得意先電子元帳検索条件(残高・伝票・明細)比較処理
        /// </summary>
        /// <param name="target">比較対象のCustPrtPprクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public ArrayList Compare(DmdARecOutPutBlnceRslt target)
        {
            ArrayList resList = new ArrayList();
            if (this.SearchCnt != target.SearchCnt) resList.Add("SearchCnt");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.St_SalesDate != target.St_SalesDate) resList.Add("St_SalesDate");
            if (this.Ed_SalesDate != target.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (this.St_AddUpADate != target.St_AddUpADate) resList.Add("St_AddUpADate");
            if (this.Ed_AddUpADate != target.Ed_AddUpADate) resList.Add("Ed_AddUpADate");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipCd != target.SalesSlipCd) resList.Add("SalesSlipCd");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.CarMngCode != target.CarMngCode) resList.Add("CarMngCode");
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.SearchFrameNo != target.SearchFrameNo) resList.Add("SearchFrameNo");
            if (this.FrameNo != target.FrameNo) resList.Add("FrameNo");// ADD 2010/08/05
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.ColorName1 != target.ColorName1) resList.Add("ColorName1");
            if (this.TrimName != target.TrimName) resList.Add("TrimName");
            if (this.DataSendCode != target.DataSendCode) resList.Add("DataSendCode");
            if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
            if (this.SlipNote2 != target.SlipNote2) resList.Add("SlipNote2");
            if (this.SlipNote3 != target.SlipNote3) resList.Add("SlipNote3");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.SalesOrderDivCd != target.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.DtlNote != target.DtlNote) resList.Add("DtlNote");
            if (this.SearchType != target.SearchType) resList.Add("SearchType");
            if (this.AddresseeCode != target.AddresseeCode) resList.Add("AddresseeCode");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsLGroup != target.GoodsLGroup) resList.Add("GoodsLGroup");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.SalesSlipCdDtl != target.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.HisDtlSlipNum != target.HisDtlSlipNum) resList.Add("HisDtlSlipNum");
            if (this.AcptAnOdrStatusSrc != target.AcptAnOdrStatusSrc) resList.Add("AcptAnOdrStatusSrc");
            if (this.AutoAnswerDivSCM != target.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");

            return resList;
        }

        /// <summary>
        /// 得意先電子元帳検索条件(残高・伝票・明細)比較処理
        /// </summary>
        /// <param name="custPrtPpr1">比較するCustPrtPprクラスのインスタンス</param>
        /// <param name="custPrtPpr2">比較するCustPrtPprクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   </br>
        /// </remarks>
        public static ArrayList Compare(DmdARecOutPutBlnceRslt custPrtPpr1, DmdARecOutPutBlnceRslt custPrtPpr2)
        {
            ArrayList resList = new ArrayList();
            if (custPrtPpr1.SearchCnt != custPrtPpr2.SearchCnt) resList.Add("SearchCnt");
            if (custPrtPpr1.EnterpriseCode != custPrtPpr2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (custPrtPpr1.SectionCode != custPrtPpr2.SectionCode) resList.Add("SectionCode");
            if (custPrtPpr1.CustomerCode != custPrtPpr2.CustomerCode) resList.Add("CustomerCode");
            if (custPrtPpr1.ClaimCode != custPrtPpr2.ClaimCode) resList.Add("ClaimCode");
            if (custPrtPpr1.St_SalesDate != custPrtPpr2.St_SalesDate) resList.Add("St_SalesDate");
            if (custPrtPpr1.Ed_SalesDate != custPrtPpr2.Ed_SalesDate) resList.Add("Ed_SalesDate");
            if (custPrtPpr1.St_AddUpADate != custPrtPpr2.St_AddUpADate) resList.Add("St_AddUpADate");
            if (custPrtPpr1.Ed_AddUpADate != custPrtPpr2.Ed_AddUpADate) resList.Add("Ed_AddUpADate");
            if (custPrtPpr1.AddUpYearMonth != custPrtPpr2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (custPrtPpr1.AcptAnOdrStatus != custPrtPpr2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (custPrtPpr1.SalesSlipCd != custPrtPpr2.SalesSlipCd) resList.Add("SalesSlipCd");
            if (custPrtPpr1.SalesSlipNum != custPrtPpr2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (custPrtPpr1.SalesEmployeeCd != custPrtPpr2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (custPrtPpr1.FrontEmployeeCd != custPrtPpr2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (custPrtPpr1.SalesInputCode != custPrtPpr2.SalesInputCode) resList.Add("SalesInputCode");
            if (custPrtPpr1.CarMngCode != custPrtPpr2.CarMngCode) resList.Add("CarMngCode");
            if (custPrtPpr1.ModelFullName != custPrtPpr2.ModelFullName) resList.Add("ModelFullName");
            if (custPrtPpr1.FullModel != custPrtPpr2.FullModel) resList.Add("FullModel");
            if (custPrtPpr1.SearchFrameNo != custPrtPpr2.SearchFrameNo) resList.Add("SearchFrameNo");
            if (custPrtPpr1.FrameNo != custPrtPpr2.FrameNo) resList.Add("FrameNo");// ADD 2010/08/05
            if (custPrtPpr1.PartySaleSlipNum != custPrtPpr2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (custPrtPpr1.ColorName1 != custPrtPpr2.ColorName1) resList.Add("ColorName1");
            if (custPrtPpr1.TrimName != custPrtPpr2.TrimName) resList.Add("TrimName");
            if (custPrtPpr1.DataSendCode != custPrtPpr2.DataSendCode) resList.Add("DataSendCode");
            if (custPrtPpr1.SlipNote != custPrtPpr2.SlipNote) resList.Add("SlipNote");
            if (custPrtPpr1.SlipNote2 != custPrtPpr2.SlipNote2) resList.Add("SlipNote2");
            if (custPrtPpr1.SlipNote3 != custPrtPpr2.SlipNote3) resList.Add("SlipNote3");
            if (custPrtPpr1.UoeRemark1 != custPrtPpr2.UoeRemark1) resList.Add("UoeRemark1");
            if (custPrtPpr1.UoeRemark2 != custPrtPpr2.UoeRemark2) resList.Add("UoeRemark2");
            if (custPrtPpr1.BLGroupCode != custPrtPpr2.BLGroupCode) resList.Add("BLGroupCode");
            if (custPrtPpr1.BLGoodsCode != custPrtPpr2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (custPrtPpr1.GoodsName != custPrtPpr2.GoodsName) resList.Add("GoodsName");
            if (custPrtPpr1.GoodsNo != custPrtPpr2.GoodsNo) resList.Add("GoodsNo");
            if (custPrtPpr1.GoodsMakerCd != custPrtPpr2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (custPrtPpr1.SalesCode != custPrtPpr2.SalesCode) resList.Add("SalesCode");
            if (custPrtPpr1.EnterpriseGanreCode != custPrtPpr2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (custPrtPpr1.SalesOrderDivCd != custPrtPpr2.SalesOrderDivCd) resList.Add("SalesOrderDivCd");
            if (custPrtPpr1.WarehouseCode != custPrtPpr2.WarehouseCode) resList.Add("WarehouseCode");
            if (custPrtPpr1.SupplierSlipNo != custPrtPpr2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (custPrtPpr1.SupplierCd != custPrtPpr2.SupplierCd) resList.Add("SupplierCd");
            if (custPrtPpr1.UOESupplierCd != custPrtPpr2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (custPrtPpr1.DtlNote != custPrtPpr2.DtlNote) resList.Add("DtlNote");
            if (custPrtPpr1.SearchType != custPrtPpr2.SearchType) resList.Add("SearchType");
            if (custPrtPpr1.AddresseeCode != custPrtPpr2.AddresseeCode) resList.Add("AddresseeCode");
            if (custPrtPpr1.GoodsKindCode != custPrtPpr2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (custPrtPpr1.GoodsLGroup != custPrtPpr2.GoodsLGroup) resList.Add("GoodsLGroup");
            if (custPrtPpr1.GoodsMGroup != custPrtPpr2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (custPrtPpr1.WarehouseShelfNo != custPrtPpr2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (custPrtPpr1.SalesSlipCdDtl != custPrtPpr2.SalesSlipCdDtl) resList.Add("SalesSlipCdDtl");
            if (custPrtPpr1.EnterpriseName != custPrtPpr2.EnterpriseName) resList.Add("EnterpriseName");
            if (custPrtPpr1.SalesEmployeeNm != custPrtPpr2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (custPrtPpr1.BLGoodsName != custPrtPpr2.BLGoodsName) resList.Add("BLGoodsName");
            if (custPrtPpr1.WarehouseName != custPrtPpr2.WarehouseName) resList.Add("WarehouseName");
            if (custPrtPpr1.HisDtlSlipNum != custPrtPpr2.HisDtlSlipNum) resList.Add("HisDtlSlipNum");
            if (custPrtPpr1.AcptAnOdrStatusSrc != custPrtPpr2.AcptAnOdrStatusSrc) resList.Add("AcptAnOdrStatusSrc");
            if (custPrtPpr1.AutoAnswerDivSCM != custPrtPpr2.AutoAnswerDivSCM) resList.Add("AutoAnswerDivSCM");
            if (custPrtPpr1.InquiryNumber != custPrtPpr2.InquiryNumber) resList.Add("InquiryNumber");
            return resList;
        }
    }
}
