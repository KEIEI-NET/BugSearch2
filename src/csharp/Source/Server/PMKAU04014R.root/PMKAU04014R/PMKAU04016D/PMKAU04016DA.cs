using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/16 DEL
    # region // DEL
    ///// public class name:   CustPrtPprWork
    ///// <summary>
    /////                      得意先電子元帳検索条件(残高・伝票・明細)ワーク
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   得意先電子元帳検索条件(残高・伝票・明細)ワークヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   </br>
    ///// <br>Genarated Date   :   2009/01/06  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class CustPrtPprWork
    //{
    //    /// <summary>検索上限</summary>
    //    /// <remarks>検索上限数+1をセット</remarks>
    //    private Int64 _searchCnt;

    //    /// <summary>企業コード</summary>
    //    /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
    //    private string _enterpriseCode = "";

    //    /// <summary>拠点コード</summary>
    //    /// <remarks>(配列)　全社指定は{""}</remarks>
    //    private string[] _sectionCode;

    //    /// <summary>得意先コード</summary>
    //    private Int32 _customerCode;

    //    /// <summary>請求先コード</summary>
    //    private Int32 _claimCode;

    //    /// <summary>開始売上日付</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _st_SalesDate;

    //    /// <summary>終了売上日付</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _ed_SalesDate;

    //    /// <summary>開始入力日付</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _st_AddUpADate;

    //    /// <summary>終了入力日付</summary>
    //    /// <remarks>YYYYMMDD</remarks>
    //    private DateTime _ed_AddUpADate;

    //    /// <summary>計上年月</summary>
    //    /// <remarks>得意先請求金額マスタ 計上年月 YYYYMM</remarks>
    //    private DateTime _addUpYearMonth;

    //    /// <summary>受注ステータス</summary>
    //    /// <remarks>(配列)　全指定の場合は{""}</remarks>
    //    private Int32[] _acptAnOdrStatus;

    //    /// <summary>売上伝票区分</summary>
    //    /// <remarks>(配列)　全指定の場合は{""}</remarks>
    //    private Int32[] _salesSlipCd;

    //    /// <summary>伝票番号</summary>
    //    /// <remarks>売上伝票番号</remarks>
    //    private string _salesSlipNum = "";

    //    /// <summary>担当者</summary>
    //    /// <remarks>販売従業員コード</remarks>
    //    private string _salesEmployeeCd = "";

    //    /// <summary>受注者</summary>
    //    /// <remarks>受付従業員コード</remarks>
    //    private string _frontEmployeeCd = "";

    //    /// <summary>発行者</summary>
    //    /// <remarks>売上入力者コード</remarks>
    //    private string _salesInputCode = "";

    //    /// <summary>管理番号</summary>
    //    /// <remarks>車輌管理コード</remarks>
    //    private string _carMngCode = "";

    //    /// <summary>車種名称</summary>
    //    /// <remarks>車種全角名称</remarks>
    //    private string _modelFullName = "";

    //    /// <summary>型式</summary>
    //    /// <remarks>型式（フル型）</remarks>
    //    private string _fullModel = "";

    //    /// <summary>車台№</summary>
    //    /// <remarks>車台番号（検索用）</remarks>
    //    private Int32 _searchFrameNo;

    //    /// <summary>得意先注番</summary>
    //    /// <remarks>相手先伝票番号</remarks>
    //    private string _partySaleSlipNum = "";

    //    /// <summary>カラー名称</summary>
    //    /// <remarks>カラー名称1</remarks>
    //    private string _colorName1 = "";

    //    /// <summary>トリム名称</summary>
    //    /// <remarks>トリム名称</remarks>
    //    private string _trimName = "";

    //    /// <summary>ＵＯＥ送信</summary>
    //    /// <remarks>UOE発注データのデータ送信区分</remarks>
    //    private Int32 _dataSendCode;

    //    /// <summary>備考１</summary>
    //    /// <remarks>伝票備考</remarks>
    //    private string _slipNote = "";

    //    /// <summary>備考２</summary>
    //    /// <remarks>伝票備考２</remarks>
    //    private string _slipNote2 = "";

    //    /// <summary>備考３</summary>
    //    /// <remarks>伝票備考３</remarks>
    //    private string _slipNote3 = "";

    //    /// <summary>ＵＯＥリマーク１</summary>
    //    /// <remarks>ＵＯＥリマーク１</remarks>
    //    private string _uoeRemark1 = "";

    //    /// <summary>ＵＯＥリマーク２</summary>
    //    /// <remarks>ＵＯＥリマーク２</remarks>
    //    private string _uoeRemark2 = "";

    //    /// <summary>ＢＬグループ</summary>
    //    /// <remarks>BLグループコード</remarks>
    //    private Int32 _bLGroupCode;

    //    /// <summary>ＢＬコード</summary>
    //    /// <remarks>BL商品コード</remarks>
    //    private Int32 _bLGoodsCode;

    //    /// <summary>品名</summary>
    //    /// <remarks>商品名称</remarks>
    //    private string _goodsName = "";

    //    /// <summary>品番</summary>
    //    /// <remarks>商品番号</remarks>
    //    private string _goodsNo = "";

    //    /// <summary>メーカーコード</summary>
    //    /// <remarks>商品メーカーコード</remarks>
    //    private Int32 _goodsMakerCd;

    //    /// <summary>販売区分コード</summary>
    //    /// <remarks>販売区分コード</remarks>
    //    private Int32 _salesCode;

    //    /// <summary>自社分類コード</summary>
    //    /// <remarks>自社分類コード</remarks>
    //    private Int32 _enterpriseGanreCode;

    //    /// <summary>在庫取寄区分</summary>
    //    /// <remarks>売上在庫取寄せ区分(-1:全て 0:取寄せ 1:在庫)</remarks>
    //    private Int32 _salesOrderDivCd;

    //    /// <summary>倉庫コード</summary>
    //    /// <remarks>倉庫コード</remarks>
    //    private string _warehouseCode = "";

    //    /// <summary>仕入伝票番号</summary>
    //    /// <remarks>仕入データの相手先伝票番号</remarks>
    //    private string _supplierSlipNo = "";

    //    /// <summary>仕入先</summary>
    //    /// <remarks>仕入先コード</remarks>
    //    private Int32 _supplierCd;

    //    /// <summary>発注先</summary>
    //    /// <remarks>UOE発注データの仕入先コード</remarks>
    //    private Int32 _uOESupplierCd;

    //    /// <summary>明細備考</summary>
    //    /// <remarks>明細備考</remarks>
    //    private string _dtlNote = "";

    //    /// <summary>伝票検索区分</summary>
    //    /// <remarks>0:全て 1:売上のみ 2:入金のみ</remarks>
    //    private Int32 _searchType;

    //    /// <summary>納品先コード</summary>
    //    private Int32 _addresseeCode;


    //    /// public propaty name  :  SearchCnt
    //    /// <summary>検索上限プロパティ</summary>
    //    /// <value>検索上限数+1をセット</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   検索上限プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int64 SearchCnt
    //    {
    //        get{return _searchCnt;}
    //        set{_searchCnt = value;}
    //    }

    //    /// public propaty name  :  EnterpriseCode
    //    /// <summary>企業コードプロパティ</summary>
    //    /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   企業コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EnterpriseCode
    //    {
    //        get{return _enterpriseCode;}
    //        set{_enterpriseCode = value;}
    //    }

    //    /// public propaty name  :  SectionCode
    //    /// <summary>拠点コードプロパティ</summary>
    //    /// <value>(配列)　全社指定は{""}</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string[] SectionCode
    //    {
    //        get{return _sectionCode;}
    //        set{_sectionCode = value;}
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>得意先コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get{return _customerCode;}
    //        set{_customerCode = value;}
    //    }

    //    /// public propaty name  :  ClaimCode
    //    /// <summary>請求先コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   請求先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ClaimCode
    //    {
    //        get{return _claimCode;}
    //        set{_claimCode = value;}
    //    }

    //    /// public propaty name  :  St_SalesDate
    //    /// <summary>開始売上日付プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   開始売上日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime St_SalesDate
    //    {
    //        get{return _st_SalesDate;}
    //        set{_st_SalesDate = value;}
    //    }

    //    /// public propaty name  :  Ed_SalesDate
    //    /// <summary>終了売上日付プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   終了売上日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime Ed_SalesDate
    //    {
    //        get{return _ed_SalesDate;}
    //        set{_ed_SalesDate = value;}
    //    }

    //    /// public propaty name  :  St_AddUpADate
    //    /// <summary>開始入力日付プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   開始入力日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime St_AddUpADate
    //    {
    //        get{return _st_AddUpADate;}
    //        set{_st_AddUpADate = value;}
    //    }

    //    /// public propaty name  :  Ed_AddUpADate
    //    /// <summary>終了入力日付プロパティ</summary>
    //    /// <value>YYYYMMDD</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   終了入力日付プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime Ed_AddUpADate
    //    {
    //        get{return _ed_AddUpADate;}
    //        set{_ed_AddUpADate = value;}
    //    }

    //    /// public propaty name  :  AddUpYearMonth
    //    /// <summary>計上年月プロパティ</summary>
    //    /// <value>得意先請求金額マスタ 計上年月 YYYYMM</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   計上年月プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public DateTime AddUpYearMonth
    //    {
    //        get{return _addUpYearMonth;}
    //        set{_addUpYearMonth = value;}
    //    }

    //    /// public propaty name  :  AcptAnOdrStatus
    //    /// <summary>受注ステータスプロパティ</summary>
    //    /// <value>(配列)　全指定の場合は{""}</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受注ステータスプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32[] AcptAnOdrStatus
    //    {
    //        get{return _acptAnOdrStatus;}
    //        set{_acptAnOdrStatus = value;}
    //    }

    //    /// public propaty name  :  SalesSlipCd
    //    /// <summary>売上伝票区分プロパティ</summary>
    //    /// <value>(配列)　全指定の場合は{""}</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   売上伝票区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32[] SalesSlipCd
    //    {
    //        get{return _salesSlipCd;}
    //        set{_salesSlipCd = value;}
    //    }

    //    /// public propaty name  :  SalesSlipNum
    //    /// <summary>伝票番号プロパティ</summary>
    //    /// <value>売上伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesSlipNum
    //    {
    //        get{return _salesSlipNum;}
    //        set{_salesSlipNum = value;}
    //    }

    //    /// public propaty name  :  SalesEmployeeCd
    //    /// <summary>担当者プロパティ</summary>
    //    /// <value>販売従業員コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   担当者プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesEmployeeCd
    //    {
    //        get{return _salesEmployeeCd;}
    //        set{_salesEmployeeCd = value;}
    //    }

    //    /// public propaty name  :  FrontEmployeeCd
    //    /// <summary>受注者プロパティ</summary>
    //    /// <value>受付従業員コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   受注者プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string FrontEmployeeCd
    //    {
    //        get{return _frontEmployeeCd;}
    //        set{_frontEmployeeCd = value;}
    //    }

    //    /// public propaty name  :  SalesInputCode
    //    /// <summary>発行者プロパティ</summary>
    //    /// <value>売上入力者コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   発行者プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SalesInputCode
    //    {
    //        get{return _salesInputCode;}
    //        set{_salesInputCode = value;}
    //    }

    //    /// public propaty name  :  CarMngCode
    //    /// <summary>管理番号プロパティ</summary>
    //    /// <value>車輌管理コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   管理番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string CarMngCode
    //    {
    //        get{return _carMngCode;}
    //        set{_carMngCode = value;}
    //    }

    //    /// public propaty name  :  ModelFullName
    //    /// <summary>車種名称プロパティ</summary>
    //    /// <value>車種全角名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車種名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ModelFullName
    //    {
    //        get{return _modelFullName;}
    //        set{_modelFullName = value;}
    //    }

    //    /// public propaty name  :  FullModel
    //    /// <summary>型式プロパティ</summary>
    //    /// <value>型式（フル型）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   型式プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string FullModel
    //    {
    //        get{return _fullModel;}
    //        set{_fullModel = value;}
    //    }

    //    /// public propaty name  :  SearchFrameNo
    //    /// <summary>車台№プロパティ</summary>
    //    /// <value>車台番号（検索用）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   車台№プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SearchFrameNo
    //    {
    //        get{return _searchFrameNo;}
    //        set{_searchFrameNo = value;}
    //    }

    //    /// public propaty name  :  PartySaleSlipNum
    //    /// <summary>得意先注番プロパティ</summary>
    //    /// <value>相手先伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先注番プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string PartySaleSlipNum
    //    {
    //        get{return _partySaleSlipNum;}
    //        set{_partySaleSlipNum = value;}
    //    }

    //    /// public propaty name  :  ColorName1
    //    /// <summary>カラー名称プロパティ</summary>
    //    /// <value>カラー名称1</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   カラー名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string ColorName1
    //    {
    //        get{return _colorName1;}
    //        set{_colorName1 = value;}
    //    }

    //    /// public propaty name  :  TrimName
    //    /// <summary>トリム名称プロパティ</summary>
    //    /// <value>トリム名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   トリム名称プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string TrimName
    //    {
    //        get{return _trimName;}
    //        set{_trimName = value;}
    //    }

    //    /// public propaty name  :  DataSendCode
    //    /// <summary>ＵＯＥ送信プロパティ</summary>
    //    /// <value>UOE発注データのデータ送信区分</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥ送信プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 DataSendCode
    //    {
    //        get{return _dataSendCode;}
    //        set{_dataSendCode = value;}
    //    }

    //    /// public propaty name  :  SlipNote
    //    /// <summary>備考１プロパティ</summary>
    //    /// <value>伝票備考</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   備考１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipNote
    //    {
    //        get{return _slipNote;}
    //        set{_slipNote = value;}
    //    }

    //    /// public propaty name  :  SlipNote2
    //    /// <summary>備考２プロパティ</summary>
    //    /// <value>伝票備考２</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   備考２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipNote2
    //    {
    //        get{return _slipNote2;}
    //        set{_slipNote2 = value;}
    //    }

    //    /// public propaty name  :  SlipNote3
    //    /// <summary>備考３プロパティ</summary>
    //    /// <value>伝票備考３</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   備考３プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SlipNote3
    //    {
    //        get{return _slipNote3;}
    //        set{_slipNote3 = value;}
    //    }

    //    /// public propaty name  :  UoeRemark1
    //    /// <summary>ＵＯＥリマーク１プロパティ</summary>
    //    /// <value>ＵＯＥリマーク１</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark1
    //    {
    //        get{return _uoeRemark1;}
    //        set{_uoeRemark1 = value;}
    //    }

    //    /// public propaty name  :  UoeRemark2
    //    /// <summary>ＵＯＥリマーク２プロパティ</summary>
    //    /// <value>ＵＯＥリマーク２</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string UoeRemark2
    //    {
    //        get{return _uoeRemark2;}
    //        set{_uoeRemark2 = value;}
    //    }

    //    /// public propaty name  :  BLGroupCode
    //    /// <summary>ＢＬグループプロパティ</summary>
    //    /// <value>BLグループコード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＢＬグループプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BLGroupCode
    //    {
    //        get{return _bLGroupCode;}
    //        set{_bLGroupCode = value;}
    //    }

    //    /// public propaty name  :  BLGoodsCode
    //    /// <summary>ＢＬコードプロパティ</summary>
    //    /// <value>BL商品コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   ＢＬコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 BLGoodsCode
    //    {
    //        get{return _bLGoodsCode;}
    //        set{_bLGoodsCode = value;}
    //    }

    //    /// public propaty name  :  GoodsName
    //    /// <summary>品名プロパティ</summary>
    //    /// <value>商品名称</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   品名プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsName
    //    {
    //        get{return _goodsName;}
    //        set{_goodsName = value;}
    //    }

    //    /// public propaty name  :  GoodsNo
    //    /// <summary>品番プロパティ</summary>
    //    /// <value>商品番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   品番プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string GoodsNo
    //    {
    //        get{return _goodsNo;}
    //        set{_goodsNo = value;}
    //    }

    //    /// public propaty name  :  GoodsMakerCd
    //    /// <summary>メーカーコードプロパティ</summary>
    //    /// <value>商品メーカーコード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   メーカーコードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 GoodsMakerCd
    //    {
    //        get{return _goodsMakerCd;}
    //        set{_goodsMakerCd = value;}
    //    }

    //    /// public propaty name  :  SalesCode
    //    /// <summary>販売区分コードプロパティ</summary>
    //    /// <value>販売区分コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   販売区分コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesCode
    //    {
    //        get{return _salesCode;}
    //        set{_salesCode = value;}
    //    }

    //    /// public propaty name  :  EnterpriseGanreCode
    //    /// <summary>自社分類コードプロパティ</summary>
    //    /// <value>自社分類コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   自社分類コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 EnterpriseGanreCode
    //    {
    //        get{return _enterpriseGanreCode;}
    //        set{_enterpriseGanreCode = value;}
    //    }

    //    /// public propaty name  :  SalesOrderDivCd
    //    /// <summary>在庫取寄区分プロパティ</summary>
    //    /// <value>売上在庫取寄せ区分(-1:全て 0:取寄せ 1:在庫)</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   在庫取寄区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SalesOrderDivCd
    //    {
    //        get{return _salesOrderDivCd;}
    //        set{_salesOrderDivCd = value;}
    //    }

    //    /// public propaty name  :  WarehouseCode
    //    /// <summary>倉庫コードプロパティ</summary>
    //    /// <value>倉庫コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   倉庫コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string WarehouseCode
    //    {
    //        get{return _warehouseCode;}
    //        set{_warehouseCode = value;}
    //    }

    //    /// public propaty name  :  SupplierSlipNo
    //    /// <summary>仕入伝票番号プロパティ</summary>
    //    /// <value>仕入データの相手先伝票番号</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入伝票番号プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SupplierSlipNo
    //    {
    //        get{return _supplierSlipNo;}
    //        set{_supplierSlipNo = value;}
    //    }

    //    /// public propaty name  :  SupplierCd
    //    /// <summary>仕入先プロパティ</summary>
    //    /// <value>仕入先コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierCd
    //    {
    //        get{return _supplierCd;}
    //        set{_supplierCd = value;}
    //    }

    //    /// public propaty name  :  UOESupplierCd
    //    /// <summary>発注先プロパティ</summary>
    //    /// <value>UOE発注データの仕入先コード</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   発注先プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 UOESupplierCd
    //    {
    //        get{return _uOESupplierCd;}
    //        set{_uOESupplierCd = value;}
    //    }

    //    /// public propaty name  :  DtlNote
    //    /// <summary>明細備考プロパティ</summary>
    //    /// <value>明細備考</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   明細備考プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string DtlNote
    //    {
    //        get{return _dtlNote;}
    //        set{_dtlNote = value;}
    //    }

    //    /// public propaty name  :  SearchType
    //    /// <summary>伝票検索区分プロパティ</summary>
    //    /// <value>0:全て 1:売上のみ 2:入金のみ</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   伝票検索区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SearchType
    //    {
    //        get{return _searchType;}
    //        set{_searchType = value;}
    //    }

    //    /// public propaty name  :  AddresseeCode
    //    /// <summary>納品先コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   納品先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 AddresseeCode
    //    {
    //        get{return _addresseeCode;}
    //        set{_addresseeCode = value;}
    //    }


    //    /// <summary>
    //    /// 得意先電子元帳検索条件(残高・伝票・明細)ワークコンストラクタ
    //    /// </summary>
    //    /// <returns>CustPrtPprWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   CustPrtPprWorkクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public CustPrtPprWork()
    //    {
    //    }

    //}
    # endregion
    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/16 DEL

    /// public class name:   CustPrtPprWork
    /// <summary>
    ///                      得意先電子元帳検索条件(残高・伝票・明細)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先電子元帳検索条件(残高・伝票・明細)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/08/05 呉元嘯 車台番号の追加</br>
    /// <br>Update Note      :   2011/07/18 zhubj 回答区分の追加</br>
    /// <br>Update Note      :   2011/11/28 楊洋 redmine#8172の追加</br>
    /// <br>Update Note      :   K2015/06/16 鮑晶</br>
    /// <br>管理番号         :   11101427-00</br>
    /// <br>                 :   メイゴ㈱得意先電子元帳「地区」と「分析コード」を追加する。</br>
    /// <br>Update Note      :   2015/02/05 王亜楠 テキスト出力件数制限なしモードの追加</br>
    /// <br>Update Note      :   2016/01/21 脇田 靖之</br>
    /// <br>管理番号         :   11270007-00 仕掛一覧№2808 貸出受注対応</br>
    /// <br>                 :   ①検索条件に「出荷状況」項目を追加</br>
    /// <br>                 :   ②明細表示に計上数、未計上数項目を追加</br>
    /// <br>Update Note      :   K2016/02/23 時シン</br>
    /// <br>管理番号         :   11200090-00 イケモ 得意先電子元帳</br>
    /// <br>                     ㈱イケモト 抽出条件にて受注作成区分を追加する対応</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustPrtPprWork
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

        /// <summary>売上伝票番号</summary>
        /// <remarks>売上伝票番号</remarks>
        private string _salesSlipNum = "";

        /// <summary>販売従業員コード</summary>
        /// <remarks>販売従業員コード</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>受付従業員コード</summary>
        /// <remarks>受付従業員コード</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>売上入力者コード</summary>
        /// <remarks>売上入力者コード</remarks>
        private string _salesInputCode = "";

        /// <summary>車両管理コード</summary>
        /// <remarks>車輌管理コード</remarks>
        private string _carMngCode = "";

        /// <summary>車種全角名称</summary>
        /// <remarks>車種全角名称</remarks>
        private string _modelFullName = "";

        /// <summary>型式（フル型）</summary>
        /// <remarks>型式（フル型）</remarks>
        private string _fullModel = "";

        /// <summary>車台№</summary>
        /// <remarks>車台番号（検索用）</remarks>
        private Int32 _searchFrameNo;

        // -----------ADD 2010/08/05----------->>>>>
        /// <summary>車台№</summary>
        /// <remarks>車台番号</remarks>
        private string _frameNo;
        // -----------ADD 2010/08/05-----------<<<<<

        /// <summary>相手先伝票番号</summary>
        /// <remarks>相手先伝票番号</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>カラー名称1</summary>
        /// <remarks>カラー名称1</remarks>
        private string _colorName1 = "";

        /// <summary>トリム名称</summary>
        /// <remarks>トリム名称</remarks>
        private string _trimName = "";

        /// <summary>データ送信区分</summary>
        /// <remarks>UOE発注データのデータ送信区分</remarks>
        private Int32 _dataSendCode;

        /// <summary>伝票備考</summary>
        /// <remarks>伝票備考</remarks>
        private string _slipNote = "";

        /// <summary>伝票備考２</summary>
        /// <remarks>伝票備考２</remarks>
        private string _slipNote2 = "";

        /// <summary>伝票備考３</summary>
        /// <remarks>伝票備考３</remarks>
        private string _slipNote3 = "";

        /// <summary>ＵＯＥリマーク１</summary>
        /// <remarks>ＵＯＥリマーク１</remarks>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        /// <remarks>ＵＯＥリマーク２</remarks>
        private string _uoeRemark2 = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>BLグループコード</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL商品コード</summary>
        /// <remarks>BL商品コード</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>商品名称</summary>
        /// <remarks>商品名称</remarks>
        private string _goodsName = "";

        /// <summary>商品番号</summary>
        /// <remarks>商品番号</remarks>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>商品メーカーコード</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>販売区分コード</summary>
        /// <remarks>販売区分コード</remarks>
        private Int32 _salesCode;

        /// <summary>自社分類コード</summary>
        /// <remarks>自社分類コード</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>売上在庫取寄せ区分</summary>
        /// <remarks>売上在庫取寄せ区分(-1:全て 0:取寄せ 1:在庫)</remarks>
        private Int32 _salesOrderDivCd;

        /// <summary>倉庫コード</summary>
        /// <remarks>倉庫コード</remarks>
        private string _warehouseCode = "";

        /// <summary>仕入伝票番号</summary>
        /// <remarks>仕入データの相手先伝票番号</remarks>
        private string _supplierSlipNo;

        /// <summary>仕入先コード</summary>
        /// <remarks>仕入先コード</remarks>
        private Int32 _supplierCd;

        /// <summary>UOE発注先コード</summary>
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

        /// <summary>商品属性</summary>
        /// <remarks>0:純正 1:優良</remarks>
        private Int32 _goodsKindCode;

        /// <summary>商品大分類コード</summary>
        /// <remarks>旧大分類（ユーザーガイド）</remarks>
        private Int32 _goodsLGroup;

        /// <summary>商品中分類コード</summary>
        /// <remarks>旧中分類コード</remarks>
        private Int32 _goodsMGroup;

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>売上伝票区分（明細）</summary>
        /// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
        private Int32 _salesSlipCdDtl;

        // ---------------------- ADD START 2011/07/18 zhubj ----------------->>>>>
        /// <summary>自動回答区分(SCM)</summary>
        /// <remarks>0:通常(PCC連携なし)、1:手動回答、2:自動回答</remarks>
        private Int32 _autoAnswerDivSCM;

        //---ADD START 2011/11/28 楊洋 ----------------------------------->>>>>
        /// <summary>問合せ番号</summary>
        private Int64 _inquiryNumber;
       
        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
        /// <summary>抽出件数制限</summary>
        /// <remarks>0:抽出件数制限あり、1:抽出件数制限なし</remarks>
        private Int32 _searchCountCtrl;

        /// <summary>開始日付/終了日付</summary>
        /// <remarks>0:開始日付、1:終了日付</remarks>
        private Int32 _searchSalDateStEd;
        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

        //----- ADD 2015/03/03 王亜楠 Redmine#44701 ---------->>>>>
        /// <summary>日付検索タイプ</summary>
        /// <remarks>0:売上データから、1:入金データから</remarks>
        private Int32 _searchSalDateType;
        //----- ADD 2015/03/03 王亜楠 Redmine#44701 ----------<<<<<

        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する----->>>>>
        /// <summary>販売エリアコード</summary>
        private Int32 _salesAreaCode;

        /// <summary>得意先分析コード1</summary>
        private Int32 _custAnalysCode1;

        /// <summary>得意先分析コード2</summary>
        private Int32 _custAnalysCode2;

        /// <summary>得意先分析コード3</summary>
        private Int32 _custAnalysCode3;

        /// <summary>得意先分析コード4</summary>
        private Int32 _custAnalysCode4;

        /// <summary>得意先分析コード5</summary>
        private Int32 _custAnalysCode5;

        /// <summary>得意先分析コード6</summary>
        private Int32 _custAnalysCode6;

    
        /// public propaty name  :  SalesAreaCode
        /// <summary>地区番号</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコード</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード1</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード2</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード3</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード4</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード5</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>得意先分析コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード6</br>
        /// <br>Programer        :   鮑晶</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }
        //----- ADD K2015/06/16 鮑晶 メイゴ㈱の個別開発依頼:得意先電子元帳「地区」と「分析コード」を追加する-----<<<<<

        // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
        /// <summary>出荷状況</summary>
        /// <remarks>0:全て、1:未計上分、2:計上済み分</remarks>
        private Int32 _addUpRemDiv;
        // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<
        
        /// public propaty name  :  InquiryNumber
        /// <summary>問合せ番号プロパティプロパティ</summary>
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
        //---ADD END 2011/11/28 楊洋 -----------------------------------<<<<<

        //----- ADD K2016/02/23 時シン ㈱イケモト 抽出条件にて受注作成区分を追加する対応 ----->>>>>
        /// <summary>受注作成区分</summary>
        /// <remarks>0:全て、1:通常受注伝票、2:伝発UOE受注伝票</remarks>
        private Int32 _acptAnOdrMakeDiv;

        /// public propaty name  :  AcptAnOdrMakeDiv
        /// <summary>受注作成区分プロパティ</summary>
        /// <value>0:全て、1:通常受注伝票、2:伝発UOE受注伝票</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注作成区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrMakeDiv
        {
            get { return _acptAnOdrMakeDiv; }
            set { _acptAnOdrMakeDiv = value; }
        }
        //----- ADD K2016/02/23 時シン ㈱イケモト 抽出条件にて受注作成区分を追加する対応 -----<<<<<


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
        // ---------------------- ADD END   2011/07/18 zhubj -----------------<<<<<

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
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>売上伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>販売従業員コードプロパティ</summary>
        /// <value>販売従業員コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>受付従業員コードプロパティ</summary>
        /// <value>受付従業員コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受付従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>売上入力者コードプロパティ</summary>
        /// <value>売上入力者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上入力者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }

        /// public propaty name  :  CarMngCode
        /// <summary>車両管理コードプロパティ</summary>
        /// <value>車輌管理コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>車種全角名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種全角名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelFullName
        {
            get { return _modelFullName; }
            set { _modelFullName = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>型式（フル型）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（フル型）プロパティ</br>
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

        // ----------ADD 2010/08/05----------->>>>>
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
        // ----------ADD 2010/08/05-----------<<<<<
        /// public propaty name  :  PartySaleSlipNum
        /// <summary>相手先伝票番号プロパティ</summary>
        /// <value>相手先伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手先伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  ColorName1
        /// <summary>カラー名称1プロパティ</summary>
        /// <value>カラー名称1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カラー名称1プロパティ</br>
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
        /// <summary>データ送信区分プロパティ</summary>
        /// <value>UOE発注データのデータ送信区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ送信区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataSendCode
        {
            get { return _dataSendCode; }
            set { _dataSendCode = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考プロパティ</summary>
        /// <value>伝票備考</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  SlipNote2
        /// <summary>伝票備考２プロパティ</summary>
        /// <value>伝票備考２</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote2
        {
            get { return _slipNote2; }
            set { _slipNote2 = value; }
        }

        /// public propaty name  :  SlipNote3
        /// <summary>伝票備考３プロパティ</summary>
        /// <value>伝票備考３</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３プロパティ</br>
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
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>BLグループコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// <value>BL商品コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// <value>商品名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// <value>商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>商品メーカーコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
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
        /// <summary>売上在庫取寄せ区分プロパティ</summary>
        /// <value>売上在庫取寄せ区分(-1:全て 0:取寄せ 1:在庫)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上在庫取寄せ区分プロパティ</br>
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
        /// <summary>仕入先コードプロパティ</summary>
        /// <value>仕入先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// <value>UOE発注データの仕入先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
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
        /// <summary>商品属性プロパティ</summary>
        /// <value>0:純正 1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// <value>旧大分類（ユーザーガイド）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>旧中分類コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  SalesSlipCdDtl
        /// <summary>売上伝票区分（明細）プロパティ</summary>
        /// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票区分（明細）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipCdDtl
        {
            get { return _salesSlipCdDtl; }
            set { _salesSlipCdDtl = value; }
        }

        //----- ADD 2015/02/05 王亜楠 -------------------->>>>>
        /// public propaty name  :  SearchCountCtrl
        /// <summary>抽出件数制限プロパティプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出件数制限プロパティ</br>
        /// <br>Programer        :   王亜楠</br>
        /// </remarks>
        public Int32 SearchCountCtrl
        {
            get { return _searchCountCtrl; }
            set { _searchCountCtrl = value; }
        }

        /// public propaty name  :  SearchSalDateStEd
        /// <summary>開始日付/終了日付プロパティプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始日付/終了日付プロパティ</br>
        /// <br>Programer        :   王亜楠</br>
        /// </remarks>
        public Int32 SearchSalDateStEd
        {
            get { return _searchSalDateStEd; }
            set { _searchSalDateStEd = value; }
        }
        //----- ADD 2015/02/05 王亜楠 --------------------<<<<<

        //----- ADD 2015/03/03 王亜楠 Redmine#44701 ---------->>>>>
        /// public propaty name  :  SearchSalDateType
        /// <summary>日付検索タイププロパティプロパティ</summary>
        /// <value>0:売上データから、1:入金データから</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日付検索タイププロパティ</br>
        /// <br>Programer        :   王亜楠</br>
        /// </remarks>
        public Int32 SearchSalDateType
        {
            get { return _searchSalDateType; }
            set { _searchSalDateType = value; }
        }
        //----- ADD 2015/03/03 王亜楠 Redmine#44701 ----------<<<<<

        // ---------- ADD 2016/01/21 Y.Wakita ---------->>>>>
        /// public propaty name  :  AddUpRemDiv
        /// <summary>出荷状況プロパティ</summary>
        /// <value>0:全て、1:未計上分、2:計上済み分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷状況プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpRemDiv
        {
            get { return _addUpRemDiv; }
            set { _addUpRemDiv = value; }
        }
        // ---------- ADD 2016/01/21 Y.Wakita ----------<<<<<

        /// <summary>
        /// 得意先電子元帳検索条件(残高・伝票・明細)ワークコンストラクタ
        /// </summary>
        /// <returns>CustPrtPprWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustPrtPprWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustPrtPprWork()
        {
        }

    }

}