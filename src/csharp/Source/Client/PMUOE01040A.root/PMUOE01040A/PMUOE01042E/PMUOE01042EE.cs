//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : UOE送受信ジャーナル(在庫）クラス
// プログラム概要   : UOE送受信ジャーナル(在庫）の定義
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockSndRcvJnl
    /// <summary>
    ///                      UOE送受信ジャーナル（在庫）
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE送受信ジャーナル（在庫）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockSndRcvJnl
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>システム区分</summary>
        /// <remarks>0:手入力 1:伝発 2:検索 3：一括 4：補充</remarks>
        private Int32 _systemDivCd;

        /// <summary>UOE発注番号</summary>
        private Int32 _uOESalesOrderNo;

        /// <summary>UOE発注行番号</summary>
        private Int32 _uOESalesOrderRowNo;

        /// <summary>送信端末番号</summary>
        /// <remarks>送信処理実行端末番号</remarks>
        private Int32 _sendTerminalNo;

        /// <summary>UOE発注先コード</summary>
        private Int32 _uOESupplierCd;

        /// <summary>UOE発注先名称</summary>
        private string _uOESupplierName = "";

        /// <summary>通信アセンブリID</summary>
        private string _commAssemblyId = "";

        /// <summary>オンライン番号</summary>
        private Int32 _onlineNo;

        /// <summary>オンライン行番号</summary>
        private Int32 _onlineRowNo;

        /// <summary>売上日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDate;

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _inputDay;

        /// <summary>データ更新日時</summary>
        /// <remarks>DateTime:精度は100ナノ秒</remarks>
        private DateTime _dataUpdateDateTime;

        /// <summary>UOE種別</summary>
        /// <remarks>0:UOE 1:卸商仕入受信</remarks>
        private Int32 _uOEKind;

        /// <summary>売上伝票番号</summary>
        /// <remarks>受注伝票番号</remarks>
        private string _salesSlipNum = "";

        /// <summary>受注ステータス</summary>
        /// <remarks>20:受注</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>売上明細通番</summary>
        private Int64 _salesSlipDtlNum;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>レジ番号</summary>
        /// <remarks>端末番号</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>共通通番</summary>
        private Int64 _commonSeqNo;

        /// <summary>仕入形式</summary>
        /// <remarks>0:仕入,1:入荷,2:発注　（受注ステータス）</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        private Int32 _supplierSlipNo;

        /// <summary>仕入明細通番</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>BO区分</summary>
        private string _boCode = "";

        /// <summary>UOE納品区分</summary>
        private string _uOEDeliGoodsDiv = "";

        /// <summary>納品区分名称</summary>
        private string _deliveredGoodsDivNm = "";

        /// <summary>フォロー納品区分</summary>
        private string _followDeliGoodsDiv = "";

        /// <summary>フォロー納品区分名称</summary>
        private string _followDeliGoodsDivNm = "";

        /// <summary>UOE指定拠点</summary>
        private string _uOEResvdSection = "";

        /// <summary>UOE指定拠点名称</summary>
        private string _uOEResvdSectionNm = "";

        /// <summary>従業員コード</summary>
        /// <remarks>依頼者コード</remarks>
        private string _employeeCode = "";

        /// <summary>従業員名称</summary>
        /// <remarks>依頼者名称</remarks>
        private string _employeeName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>ハイフン無商品番号</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>受注数量</summary>
        private Double _acceptAnOrderCnt;

        /// <summary>定価（浮動）</summary>
        /// <remarks>適用（定価）</remarks>
        private Double _listPrice;

        /// <summary>原価単価</summary>
        /// <remarks>仕切り価格</remarks>
        private Double _salesUnitCost;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>ＵＯＥリマーク１</summary>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _uoeRemark2 = "";

        /// <summary>受信日付</summary>
        private DateTime _receiveDate;

        /// <summary>受信時刻</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _receiveTime;

        /// <summary>回答メーカーコード</summary>
        private Int32 _answerMakerCd;

        /// <summary>回答品番</summary>
        private string _answerPartsNo = "";

        /// <summary>回答品名</summary>
        private string _answerPartsName = "";

        /// <summary>代替品番</summary>
        private string _substPartsNo = "";

        /// <summary>代替品番（センター）</summary>
        private string _centerSubstPartsNo = "";

        /// <summary>回答定価</summary>
        private Double _answerListPrice;

        /// <summary>回答原価単価</summary>
        private Double _answerSalesUnitCost;

        /// <summary>商品Ａ価格</summary>
        private Double _goodsAPrice;

        /// <summary>UOE中止コード</summary>
        private string _uOEStopCd = "";

        /// <summary>UOE代替コード</summary>
        private string _uOESubstCode = "";

        /// <summary>UOE納期コード</summary>
        private string _uOEDelivDateCd = "";

        /// <summary>層別コード</summary>
        private string _partsLayerCd = "";

        /// <summary>販売店仕入単価</summary>
        private Double _shopStUnitPrice;

        /// <summary>UOE拠点コード１</summary>
        /// <remarks>マツダ設定項目（拠点コード1～8)</remarks>
        private string _uOESectionCode1 = "";

        /// <summary>UOE拠点コード２</summary>
        private string _uOESectionCode2 = "";

        /// <summary>UOE拠点コード３</summary>
        private string _uOESectionCode3 = "";

        /// <summary>UOE拠点コード４</summary>
        private string _uOESectionCode4 = "";

        /// <summary>UOE拠点コード５</summary>
        private string _uOESectionCode5 = "";

        /// <summary>UOE拠点コード６</summary>
        private string _uOESectionCode6 = "";

        /// <summary>UOE拠点コード７</summary>
        private string _uOESectionCode7 = "";

        /// <summary>UOE拠点コード８</summary>
        private string _uOESectionCode8 = "";

        /// <summary>本部在庫</summary>
        private string _headQtrsStock = "";

        /// <summary>UOE拠点在庫数１</summary>
        private Int32 _uOESectionStock1;

        /// <summary>UOE拠点在庫数２</summary>
        private Int32 _uOESectionStock2;

        /// <summary>UOE拠点在庫数３</summary>
        private Int32 _uOESectionStock3;

        /// <summary>UOE拠点在庫数４</summary>
        private Int32 _uOESectionStock4;

        /// <summary>UOE拠点在庫数５</summary>
        private Int32 _uOESectionStock5;

        /// <summary>UOE拠点在庫数６</summary>
        private Int32 _uOESectionStock6;

        /// <summary>UOE拠点在庫数７</summary>
        private Int32 _uOESectionStock7;

        /// <summary>UOE拠点在庫数８</summary>
        private Int32 _uOESectionStock8;

        /// <summary>UOE拠点在庫数９</summary>
        private Int32 _uOESectionStock9;

        /// <summary>UOE拠点在庫数１０</summary>
        private Int32 _uOESectionStock10;

        /// <summary>UOE拠点在庫数１１</summary>
        private Int32 _uOESectionStock11;

        /// <summary>UOE拠点在庫数１２</summary>
        private Int32 _uOESectionStock12;

        /// <summary>UOE拠点在庫数１３</summary>
        private Int32 _uOESectionStock13;

        /// <summary>UOE拠点在庫数１４</summary>
        private Int32 _uOESectionStock14;

        /// <summary>UOE拠点在庫数１５</summary>
        private Int32 _uOESectionStock15;

        /// <summary>UOE拠点在庫数１６</summary>
        private Int32 _uOESectionStock16;

        /// <summary>UOE拠点在庫数１７</summary>
        private Int32 _uOESectionStock17;

        /// <summary>UOE拠点在庫数１８</summary>
        private Int32 _uOESectionStock18;

        /// <summary>UOE拠点在庫数１９</summary>
        private Int32 _uOESectionStock19;

        /// <summary>UOE拠点在庫数２０</summary>
        private Int32 _uOESectionStock20;

        /// <summary>UOE拠点在庫数２１</summary>
        private Int32 _uOESectionStock21;

        /// <summary>UOE拠点在庫数２２</summary>
        private Int32 _uOESectionStock22;

        /// <summary>UOE拠点在庫数２３</summary>
        private Int32 _uOESectionStock23;

        /// <summary>UOE拠点在庫数２４</summary>
        private Int32 _uOESectionStock24;

        /// <summary>UOE拠点在庫数２５</summary>
        private Int32 _uOESectionStock25;

        /// <summary>UOE拠点在庫数２６</summary>
        private Int32 _uOESectionStock26;

        /// <summary>UOE拠点在庫数２７</summary>
        private Int32 _uOESectionStock27;

        /// <summary>UOE拠点在庫数２８</summary>
        private Int32 _uOESectionStock28;

        /// <summary>UOE拠点在庫数２９</summary>
        private Int32 _uOESectionStock29;

        /// <summary>UOE拠点在庫数３０</summary>
        private Int32 _uOESectionStock30;

        /// <summary>UOE拠点在庫数３１</summary>
        private Int32 _uOESectionStock31;

        /// <summary>UOE拠点在庫数３２</summary>
        private Int32 _uOESectionStock32;

        /// <summary>UOE拠点在庫数３３</summary>
        private Int32 _uOESectionStock33;

        /// <summary>UOE拠点在庫数３４</summary>
        private Int32 _uOESectionStock34;

        /// <summary>UOE拠点在庫数３５</summary>
        private Int32 _uOESectionStock35;

        /// <summary>ヘッドエラーメッセージ</summary>
        private string _headErrorMassage = "";

        /// <summary>ラインエラーメッセージ</summary>
        private string _lineErrorMassage = "";

        /// <summary>データ送信区分</summary>
        /// <remarks>送信フラグ</remarks>
        private Int32 _dataSendCode;

        /// <summary>データ復旧区分</summary>
        /// <remarks>復旧処理フラグ</remarks>
        private Int32 _dataRecoverDiv;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SystemDivCd
        /// <summary>システム区分プロパティ</summary>
        /// <value>0:手入力 1:伝発 2:検索 3：一括 4：補充</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   システム区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }

        /// public propaty name  :  UOESalesOrderNo
        /// <summary>UOE発注番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; }
        }

        /// public propaty name  :  UOESalesOrderRowNo
        /// <summary>UOE発注行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESalesOrderRowNo
        {
            get { return _uOESalesOrderRowNo; }
            set { _uOESalesOrderRowNo = value; }
        }

        /// public propaty name  :  SendTerminalNo
        /// <summary>送信端末番号プロパティ</summary>
        /// <value>送信処理実行端末番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   送信端末番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SendTerminalNo
        {
            get { return _sendTerminalNo; }
            set { _sendTerminalNo = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
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

        /// public propaty name  :  UOESupplierName
        /// <summary>UOE発注先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESupplierName
        {
            get { return _uOESupplierName; }
            set { _uOESupplierName = value; }
        }

        /// public propaty name  :  CommAssemblyId
        /// <summary>通信アセンブリIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信アセンブリIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CommAssemblyId
        {
            get { return _commAssemblyId; }
            set { _commAssemblyId = value; }
        }

        /// public propaty name  :  OnlineNo
        /// <summary>オンライン番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OnlineNo
        {
            get { return _onlineNo; }
            set { _onlineNo = value; }
        }

        /// public propaty name  :  OnlineRowNo
        /// <summary>オンライン行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OnlineRowNo
        {
            get { return _onlineRowNo; }
            set { _onlineRowNo = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>売上日付 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateJpInFormal
        /// <summary>売上日付 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdFormal
        /// <summary>売上日付 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdInFormal
        /// <summary>売上日付 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  InputDayJpFormal
        /// <summary>入力日 和暦プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayJpInFormal
        /// <summary>入力日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdFormal
        /// <summary>入力日 西暦プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdInFormal
        /// <summary>入力日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InputDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  DataUpdateDateTime
        /// <summary>データ更新日時プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime DataUpdateDateTime
        {
            get { return _dataUpdateDateTime; }
            set { _dataUpdateDateTime = value; }
        }

        /// public propaty name  :  DataUpdateDateTimeJpFormal
        /// <summary>データ更新日時 和暦プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DataUpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _dataUpdateDateTime); }
            set { }
        }

        /// public propaty name  :  DataUpdateDateTimeJpInFormal
        /// <summary>データ更新日時 和暦(略)プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DataUpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _dataUpdateDateTime); }
            set { }
        }

        /// public propaty name  :  DataUpdateDateTimeAdFormal
        /// <summary>データ更新日時 西暦プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DataUpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _dataUpdateDateTime); }
            set { }
        }

        /// public propaty name  :  DataUpdateDateTimeAdInFormal
        /// <summary>データ更新日時 西暦(略)プロパティ</summary>
        /// <value>DateTime:精度は100ナノ秒</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DataUpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _dataUpdateDateTime); }
            set { }
        }

        /// public propaty name  :  UOEKind
        /// <summary>UOE種別プロパティ</summary>
        /// <value>0:UOE 1:卸商仕入受信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOEKind
        {
            get { return _uOEKind; }
            set { _uOEKind = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// <value>受注伝票番号</value>
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

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>受注ステータスプロパティ</summary>
        /// <value>20:受注</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  SalesSlipDtlNum
        /// <summary>売上明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 SalesSlipDtlNum
        {
            get { return _salesSlipDtlNum; }
            set { _salesSlipDtlNum = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
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

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>レジ番号プロパティ</summary>
        /// <value>端末番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  CommonSeqNo
        /// <summary>共通通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   共通通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CommonSeqNo
        {
            get { return _commonSeqNo; }
            set { _commonSeqNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:仕入,1:入荷,2:発注　（受注ステータス）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>仕入明細通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入明細通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  BoCode
        /// <summary>BO区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BoCode
        {
            get { return _boCode; }
            set { _boCode = value; }
        }

        /// public propaty name  :  UOEDeliGoodsDiv
        /// <summary>UOE納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEDeliGoodsDiv
        {
            get { return _uOEDeliGoodsDiv; }
            set { _uOEDeliGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsDivNm
        /// <summary>納品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliveredGoodsDivNm
        {
            get { return _deliveredGoodsDivNm; }
            set { _deliveredGoodsDivNm = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDiv
        /// <summary>フォロー納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フォロー納品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FollowDeliGoodsDiv
        {
            get { return _followDeliGoodsDiv; }
            set { _followDeliGoodsDiv = value; }
        }

        /// public propaty name  :  FollowDeliGoodsDivNm
        /// <summary>フォロー納品区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フォロー納品区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FollowDeliGoodsDivNm
        {
            get { return _followDeliGoodsDivNm; }
            set { _followDeliGoodsDivNm = value; }
        }

        /// public propaty name  :  UOEResvdSection
        /// <summary>UOE指定拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE指定拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEResvdSection
        {
            get { return _uOEResvdSection; }
            set { _uOEResvdSection = value; }
        }

        /// public propaty name  :  UOEResvdSectionNm
        /// <summary>UOE指定拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE指定拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEResvdSectionNm
        {
            get { return _uOEResvdSectionNm; }
            set { _uOEResvdSectionNm = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// <value>依頼者コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>従業員名称プロパティ</summary>
        /// <value>依頼者名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
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

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
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

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>ハイフン無商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
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

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
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

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>受注数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価（浮動）プロパティ</summary>
        /// <value>適用（定価）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>原価単価プロパティ</summary>
        /// <value>仕切り価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
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

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
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

        /// public propaty name  :  ReceiveDate
        /// <summary>受信日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ReceiveDate
        {
            get { return _receiveDate; }
            set { _receiveDate = value; }
        }

        /// public propaty name  :  ReceiveDateJpFormal
        /// <summary>受信日付 和暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信日付 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReceiveDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _receiveDate); }
            set { }
        }

        /// public propaty name  :  ReceiveDateJpInFormal
        /// <summary>受信日付 和暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信日付 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReceiveDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _receiveDate); }
            set { }
        }

        /// public propaty name  :  ReceiveDateAdFormal
        /// <summary>受信日付 西暦プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信日付 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReceiveDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _receiveDate); }
            set { }
        }

        /// public propaty name  :  ReceiveDateAdInFormal
        /// <summary>受信日付 西暦(略)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信日付 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReceiveDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _receiveDate); }
            set { }
        }

        /// public propaty name  :  ReceiveTime
        /// <summary>受信時刻プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信時刻プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReceiveTime
        {
            get { return _receiveTime; }
            set { _receiveTime = value; }
        }

        /// public propaty name  :  AnswerMakerCd
        /// <summary>回答メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnswerMakerCd
        {
            get { return _answerMakerCd; }
            set { _answerMakerCd = value; }
        }

        /// public propaty name  :  AnswerPartsNo
        /// <summary>回答品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerPartsNo
        {
            get { return _answerPartsNo; }
            set { _answerPartsNo = value; }
        }

        /// public propaty name  :  AnswerPartsName
        /// <summary>回答品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AnswerPartsName
        {
            get { return _answerPartsName; }
            set { _answerPartsName = value; }
        }

        /// public propaty name  :  SubstPartsNo
        /// <summary>代替品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubstPartsNo
        {
            get { return _substPartsNo; }
            set { _substPartsNo = value; }
        }

        /// public propaty name  :  CenterSubstPartsNo
        /// <summary>代替品番（センター）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替品番（センター）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CenterSubstPartsNo
        {
            get { return _centerSubstPartsNo; }
            set { _centerSubstPartsNo = value; }
        }

        /// public propaty name  :  AnswerListPrice
        /// <summary>回答定価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AnswerListPrice
        {
            get { return _answerListPrice; }
            set { _answerListPrice = value; }
        }

        /// public propaty name  :  AnswerSalesUnitCost
        /// <summary>回答原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AnswerSalesUnitCost
        {
            get { return _answerSalesUnitCost; }
            set { _answerSalesUnitCost = value; }
        }

        /// public propaty name  :  GoodsAPrice
        /// <summary>商品Ａ価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品Ａ価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double GoodsAPrice
        {
            get { return _goodsAPrice; }
            set { _goodsAPrice = value; }
        }

        /// public propaty name  :  UOEStopCd
        /// <summary>UOE中止コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE中止コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEStopCd
        {
            get { return _uOEStopCd; }
            set { _uOEStopCd = value; }
        }

        /// public propaty name  :  UOESubstCode
        /// <summary>UOE代替コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE代替コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESubstCode
        {
            get { return _uOESubstCode; }
            set { _uOESubstCode = value; }
        }

        /// public propaty name  :  UOEDelivDateCd
        /// <summary>UOE納期コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE納期コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEDelivDateCd
        {
            get { return _uOEDelivDateCd; }
            set { _uOEDelivDateCd = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>層別コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  ShopStUnitPrice
        /// <summary>販売店仕入単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売店仕入単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShopStUnitPrice
        {
            get { return _shopStUnitPrice; }
            set { _shopStUnitPrice = value; }
        }

        /// public propaty name  :  UOESectionCode1
        /// <summary>UOE拠点コード１プロパティ</summary>
        /// <value>マツダ設定項目（拠点コード1～8)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionCode1
        {
            get { return _uOESectionCode1; }
            set { _uOESectionCode1 = value; }
        }

        /// public propaty name  :  UOESectionCode2
        /// <summary>UOE拠点コード２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionCode2
        {
            get { return _uOESectionCode2; }
            set { _uOESectionCode2 = value; }
        }

        /// public propaty name  :  UOESectionCode3
        /// <summary>UOE拠点コード３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionCode3
        {
            get { return _uOESectionCode3; }
            set { _uOESectionCode3 = value; }
        }

        /// public propaty name  :  UOESectionCode4
        /// <summary>UOE拠点コード４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionCode4
        {
            get { return _uOESectionCode4; }
            set { _uOESectionCode4 = value; }
        }

        /// public propaty name  :  UOESectionCode5
        /// <summary>UOE拠点コード５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionCode5
        {
            get { return _uOESectionCode5; }
            set { _uOESectionCode5 = value; }
        }

        /// public propaty name  :  UOESectionCode6
        /// <summary>UOE拠点コード６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionCode6
        {
            get { return _uOESectionCode6; }
            set { _uOESectionCode6 = value; }
        }

        /// public propaty name  :  UOESectionCode7
        /// <summary>UOE拠点コード７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionCode7
        {
            get { return _uOESectionCode7; }
            set { _uOESectionCode7 = value; }
        }

        /// public propaty name  :  UOESectionCode8
        /// <summary>UOE拠点コード８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionCode8
        {
            get { return _uOESectionCode8; }
            set { _uOESectionCode8 = value; }
        }

        /// public propaty name  :  HeadQtrsStock
        /// <summary>本部在庫プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   本部在庫プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HeadQtrsStock
        {
            get { return _headQtrsStock; }
            set { _headQtrsStock = value; }
        }

        /// public propaty name  :  UOESectionStock1
        /// <summary>UOE拠点在庫数１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock1
        {
            get { return _uOESectionStock1; }
            set { _uOESectionStock1 = value; }
        }

        /// public propaty name  :  UOESectionStock2
        /// <summary>UOE拠点在庫数２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock2
        {
            get { return _uOESectionStock2; }
            set { _uOESectionStock2 = value; }
        }

        /// public propaty name  :  UOESectionStock3
        /// <summary>UOE拠点在庫数３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock3
        {
            get { return _uOESectionStock3; }
            set { _uOESectionStock3 = value; }
        }

        /// public propaty name  :  UOESectionStock4
        /// <summary>UOE拠点在庫数４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock4
        {
            get { return _uOESectionStock4; }
            set { _uOESectionStock4 = value; }
        }

        /// public propaty name  :  UOESectionStock5
        /// <summary>UOE拠点在庫数５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock5
        {
            get { return _uOESectionStock5; }
            set { _uOESectionStock5 = value; }
        }

        /// public propaty name  :  UOESectionStock6
        /// <summary>UOE拠点在庫数６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock6
        {
            get { return _uOESectionStock6; }
            set { _uOESectionStock6 = value; }
        }

        /// public propaty name  :  UOESectionStock7
        /// <summary>UOE拠点在庫数７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock7
        {
            get { return _uOESectionStock7; }
            set { _uOESectionStock7 = value; }
        }

        /// public propaty name  :  UOESectionStock8
        /// <summary>UOE拠点在庫数８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock8
        {
            get { return _uOESectionStock8; }
            set { _uOESectionStock8 = value; }
        }

        /// public propaty name  :  UOESectionStock9
        /// <summary>UOE拠点在庫数９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock9
        {
            get { return _uOESectionStock9; }
            set { _uOESectionStock9 = value; }
        }

        /// public propaty name  :  UOESectionStock10
        /// <summary>UOE拠点在庫数１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock10
        {
            get { return _uOESectionStock10; }
            set { _uOESectionStock10 = value; }
        }

        /// public propaty name  :  UOESectionStock11
        /// <summary>UOE拠点在庫数１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock11
        {
            get { return _uOESectionStock11; }
            set { _uOESectionStock11 = value; }
        }

        /// public propaty name  :  UOESectionStock12
        /// <summary>UOE拠点在庫数１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock12
        {
            get { return _uOESectionStock12; }
            set { _uOESectionStock12 = value; }
        }

        /// public propaty name  :  UOESectionStock13
        /// <summary>UOE拠点在庫数１３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock13
        {
            get { return _uOESectionStock13; }
            set { _uOESectionStock13 = value; }
        }

        /// public propaty name  :  UOESectionStock14
        /// <summary>UOE拠点在庫数１４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock14
        {
            get { return _uOESectionStock14; }
            set { _uOESectionStock14 = value; }
        }

        /// public propaty name  :  UOESectionStock15
        /// <summary>UOE拠点在庫数１５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock15
        {
            get { return _uOESectionStock15; }
            set { _uOESectionStock15 = value; }
        }

        /// public propaty name  :  UOESectionStock16
        /// <summary>UOE拠点在庫数１６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock16
        {
            get { return _uOESectionStock16; }
            set { _uOESectionStock16 = value; }
        }

        /// public propaty name  :  UOESectionStock17
        /// <summary>UOE拠点在庫数１７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock17
        {
            get { return _uOESectionStock17; }
            set { _uOESectionStock17 = value; }
        }

        /// public propaty name  :  UOESectionStock18
        /// <summary>UOE拠点在庫数１８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock18
        {
            get { return _uOESectionStock18; }
            set { _uOESectionStock18 = value; }
        }

        /// public propaty name  :  UOESectionStock19
        /// <summary>UOE拠点在庫数１９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数１９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock19
        {
            get { return _uOESectionStock19; }
            set { _uOESectionStock19 = value; }
        }

        /// public propaty name  :  UOESectionStock20
        /// <summary>UOE拠点在庫数２０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock20
        {
            get { return _uOESectionStock20; }
            set { _uOESectionStock20 = value; }
        }

        /// public propaty name  :  UOESectionStock21
        /// <summary>UOE拠点在庫数２１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock21
        {
            get { return _uOESectionStock21; }
            set { _uOESectionStock21 = value; }
        }

        /// public propaty name  :  UOESectionStock22
        /// <summary>UOE拠点在庫数２２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock22
        {
            get { return _uOESectionStock22; }
            set { _uOESectionStock22 = value; }
        }

        /// public propaty name  :  UOESectionStock23
        /// <summary>UOE拠点在庫数２３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock23
        {
            get { return _uOESectionStock23; }
            set { _uOESectionStock23 = value; }
        }

        /// public propaty name  :  UOESectionStock24
        /// <summary>UOE拠点在庫数２４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock24
        {
            get { return _uOESectionStock24; }
            set { _uOESectionStock24 = value; }
        }

        /// public propaty name  :  UOESectionStock25
        /// <summary>UOE拠点在庫数２５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock25
        {
            get { return _uOESectionStock25; }
            set { _uOESectionStock25 = value; }
        }

        /// public propaty name  :  UOESectionStock26
        /// <summary>UOE拠点在庫数２６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock26
        {
            get { return _uOESectionStock26; }
            set { _uOESectionStock26 = value; }
        }

        /// public propaty name  :  UOESectionStock27
        /// <summary>UOE拠点在庫数２７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock27
        {
            get { return _uOESectionStock27; }
            set { _uOESectionStock27 = value; }
        }

        /// public propaty name  :  UOESectionStock28
        /// <summary>UOE拠点在庫数２８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock28
        {
            get { return _uOESectionStock28; }
            set { _uOESectionStock28 = value; }
        }

        /// public propaty name  :  UOESectionStock29
        /// <summary>UOE拠点在庫数２９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数２９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock29
        {
            get { return _uOESectionStock29; }
            set { _uOESectionStock29 = value; }
        }

        /// public propaty name  :  UOESectionStock30
        /// <summary>UOE拠点在庫数３０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数３０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock30
        {
            get { return _uOESectionStock30; }
            set { _uOESectionStock30 = value; }
        }

        /// public propaty name  :  UOESectionStock31
        /// <summary>UOE拠点在庫数３１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数３１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock31
        {
            get { return _uOESectionStock31; }
            set { _uOESectionStock31 = value; }
        }

        /// public propaty name  :  UOESectionStock32
        /// <summary>UOE拠点在庫数３２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数３２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock32
        {
            get { return _uOESectionStock32; }
            set { _uOESectionStock32 = value; }
        }

        /// public propaty name  :  UOESectionStock33
        /// <summary>UOE拠点在庫数３３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数３３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock33
        {
            get { return _uOESectionStock33; }
            set { _uOESectionStock33 = value; }
        }

        /// public propaty name  :  UOESectionStock34
        /// <summary>UOE拠点在庫数３４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数３４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock34
        {
            get { return _uOESectionStock34; }
            set { _uOESectionStock34 = value; }
        }

        /// public propaty name  :  UOESectionStock35
        /// <summary>UOE拠点在庫数３５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数３５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectionStock35
        {
            get { return _uOESectionStock35; }
            set { _uOESectionStock35 = value; }
        }

        /// public propaty name  :  HeadErrorMassage
        /// <summary>ヘッドエラーメッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ヘッドエラーメッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HeadErrorMassage
        {
            get { return _headErrorMassage; }
            set { _headErrorMassage = value; }
        }

        /// public propaty name  :  LineErrorMassage
        /// <summary>ラインエラーメッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ラインエラーメッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string LineErrorMassage
        {
            get { return _lineErrorMassage; }
            set { _lineErrorMassage = value; }
        }

        /// public propaty name  :  DataSendCode
        /// <summary>データ送信区分プロパティ</summary>
        /// <value>送信フラグ</value>
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

        /// public propaty name  :  DataRecoverDiv
        /// <summary>データ復旧区分プロパティ</summary>
        /// <value>復旧処理フラグ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ復旧区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataRecoverDiv
        {
            get { return _dataRecoverDiv; }
            set { _dataRecoverDiv = value; }
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

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


        /// <summary>
        /// UOE送受信ジャーナル（在庫）コンストラクタ
        /// </summary>
        /// <returns>StockSndRcvJnlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSndRcvJnlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockSndRcvJnl()
        {
        }

        /// <summary>
        /// UOE送受信ジャーナル（在庫）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="systemDivCd">システム区分(0:手入力 1:伝発 2:検索 3：一括 4：補充)</param>
        /// <param name="uOESalesOrderNo">UOE発注番号</param>
        /// <param name="uOESalesOrderRowNo">UOE発注行番号</param>
        /// <param name="sendTerminalNo">送信端末番号(送信処理実行端末番号)</param>
        /// <param name="uOESupplierCd">UOE発注先コード</param>
        /// <param name="uOESupplierName">UOE発注先名称</param>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <param name="onlineNo">オンライン番号</param>
        /// <param name="onlineRowNo">オンライン行番号</param>
        /// <param name="salesDate">売上日付(YYYYMMDD)</param>
        /// <param name="inputDay">入力日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="dataUpdateDateTime">データ更新日時(DateTime:精度は100ナノ秒)</param>
        /// <param name="uOEKind">UOE種別(0:UOE 1:卸商仕入受信)</param>
        /// <param name="salesSlipNum">売上伝票番号(受注伝票番号)</param>
        /// <param name="acptAnOdrStatus">受注ステータス(20:受注)</param>
        /// <param name="salesSlipDtlNum">売上明細通番</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="subSectionCode">部門コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="cashRegisterNo">レジ番号(端末番号)</param>
        /// <param name="commonSeqNo">共通通番</param>
        /// <param name="supplierFormal">仕入形式(0:仕入,1:入荷,2:発注　（受注ステータス）)</param>
        /// <param name="supplierSlipNo">仕入伝票番号</param>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <param name="boCode">BO区分</param>
        /// <param name="uOEDeliGoodsDiv">UOE納品区分</param>
        /// <param name="deliveredGoodsDivNm">納品区分名称</param>
        /// <param name="followDeliGoodsDiv">フォロー納品区分</param>
        /// <param name="followDeliGoodsDivNm">フォロー納品区分名称</param>
        /// <param name="uOEResvdSection">UOE指定拠点</param>
        /// <param name="uOEResvdSectionNm">UOE指定拠点名称</param>
        /// <param name="employeeCode">従業員コード(依頼者コード)</param>
        /// <param name="employeeName">従業員名称(依頼者名称)</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="warehouseName">倉庫名称</param>
        /// <param name="warehouseShelfNo">倉庫棚番</param>
        /// <param name="acceptAnOrderCnt">受注数量</param>
        /// <param name="listPrice">定価（浮動）(適用（定価）)</param>
        /// <param name="salesUnitCost">原価単価(仕切り価格)</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="uoeRemark1">ＵＯＥリマーク１</param>
        /// <param name="uoeRemark2">ＵＯＥリマーク２</param>
        /// <param name="receiveDate">受信日付</param>
        /// <param name="receiveTime">受信時刻(HHMMSS)</param>
        /// <param name="answerMakerCd">回答メーカーコード</param>
        /// <param name="answerPartsNo">回答品番</param>
        /// <param name="answerPartsName">回答品名</param>
        /// <param name="substPartsNo">代替品番</param>
        /// <param name="centerSubstPartsNo">代替品番（センター）</param>
        /// <param name="answerListPrice">回答定価</param>
        /// <param name="answerSalesUnitCost">回答原価単価</param>
        /// <param name="goodsAPrice">商品Ａ価格</param>
        /// <param name="uOEStopCd">UOE中止コード</param>
        /// <param name="uOESubstCode">UOE代替コード</param>
        /// <param name="uOEDelivDateCd">UOE納期コード</param>
        /// <param name="partsLayerCd">層別コード</param>
        /// <param name="shopStUnitPrice">販売店仕入単価</param>
        /// <param name="uOESectionCode1">UOE拠点コード１(マツダ設定項目（拠点コード1～8))</param>
        /// <param name="uOESectionCode2">UOE拠点コード２</param>
        /// <param name="uOESectionCode3">UOE拠点コード３</param>
        /// <param name="uOESectionCode4">UOE拠点コード４</param>
        /// <param name="uOESectionCode5">UOE拠点コード５</param>
        /// <param name="uOESectionCode6">UOE拠点コード６</param>
        /// <param name="uOESectionCode7">UOE拠点コード７</param>
        /// <param name="uOESectionCode8">UOE拠点コード８</param>
        /// <param name="headQtrsStock">本部在庫</param>
        /// <param name="uOESectionStock1">UOE拠点在庫数１</param>
        /// <param name="uOESectionStock2">UOE拠点在庫数２</param>
        /// <param name="uOESectionStock3">UOE拠点在庫数３</param>
        /// <param name="uOESectionStock4">UOE拠点在庫数４</param>
        /// <param name="uOESectionStock5">UOE拠点在庫数５</param>
        /// <param name="uOESectionStock6">UOE拠点在庫数６</param>
        /// <param name="uOESectionStock7">UOE拠点在庫数７</param>
        /// <param name="uOESectionStock8">UOE拠点在庫数８</param>
        /// <param name="uOESectionStock9">UOE拠点在庫数９</param>
        /// <param name="uOESectionStock10">UOE拠点在庫数１０</param>
        /// <param name="uOESectionStock11">UOE拠点在庫数１１</param>
        /// <param name="uOESectionStock12">UOE拠点在庫数１２</param>
        /// <param name="uOESectionStock13">UOE拠点在庫数１３</param>
        /// <param name="uOESectionStock14">UOE拠点在庫数１４</param>
        /// <param name="uOESectionStock15">UOE拠点在庫数１５</param>
        /// <param name="uOESectionStock16">UOE拠点在庫数１６</param>
        /// <param name="uOESectionStock17">UOE拠点在庫数１７</param>
        /// <param name="uOESectionStock18">UOE拠点在庫数１８</param>
        /// <param name="uOESectionStock19">UOE拠点在庫数１９</param>
        /// <param name="uOESectionStock20">UOE拠点在庫数２０</param>
        /// <param name="uOESectionStock21">UOE拠点在庫数２１</param>
        /// <param name="uOESectionStock22">UOE拠点在庫数２２</param>
        /// <param name="uOESectionStock23">UOE拠点在庫数２３</param>
        /// <param name="uOESectionStock24">UOE拠点在庫数２４</param>
        /// <param name="uOESectionStock25">UOE拠点在庫数２５</param>
        /// <param name="uOESectionStock26">UOE拠点在庫数２６</param>
        /// <param name="uOESectionStock27">UOE拠点在庫数２７</param>
        /// <param name="uOESectionStock28">UOE拠点在庫数２８</param>
        /// <param name="uOESectionStock29">UOE拠点在庫数２９</param>
        /// <param name="uOESectionStock30">UOE拠点在庫数３０</param>
        /// <param name="uOESectionStock31">UOE拠点在庫数３１</param>
        /// <param name="uOESectionStock32">UOE拠点在庫数３２</param>
        /// <param name="uOESectionStock33">UOE拠点在庫数３３</param>
        /// <param name="uOESectionStock34">UOE拠点在庫数３４</param>
        /// <param name="uOESectionStock35">UOE拠点在庫数３５</param>
        /// <param name="headErrorMassage">ヘッドエラーメッセージ</param>
        /// <param name="lineErrorMassage">ラインエラーメッセージ</param>
        /// <param name="dataSendCode">データ送信区分(送信フラグ)</param>
        /// <param name="dataRecoverDiv">データ復旧区分(復旧処理フラグ)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>StockSndRcvJnlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSndRcvJnlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockSndRcvJnl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 systemDivCd, Int32 uOESalesOrderNo, Int32 uOESalesOrderRowNo, Int32 sendTerminalNo, Int32 uOESupplierCd, string uOESupplierName, string commAssemblyId, Int32 onlineNo, Int32 onlineRowNo, DateTime salesDate, DateTime inputDay, DateTime dataUpdateDateTime, Int32 uOEKind, string salesSlipNum, Int32 acptAnOdrStatus, Int64 salesSlipDtlNum, string sectionCode, Int32 subSectionCode, Int32 customerCode, string customerSnm, Int32 cashRegisterNo, Int64 commonSeqNo, Int32 supplierFormal, Int32 supplierSlipNo, Int64 stockSlipDtlNum, string boCode, string uOEDeliGoodsDiv, string deliveredGoodsDivNm, string followDeliGoodsDiv, string followDeliGoodsDivNm, string uOEResvdSection, string uOEResvdSectionNm, string employeeCode, string employeeName, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsNoNoneHyphen, string goodsName, string warehouseCode, string warehouseName, string warehouseShelfNo, Double acceptAnOrderCnt, Double listPrice, Double salesUnitCost, Int32 supplierCd, string supplierSnm, string uoeRemark1, string uoeRemark2, DateTime receiveDate, Int32 receiveTime, Int32 answerMakerCd, string answerPartsNo, string answerPartsName, string substPartsNo, string centerSubstPartsNo, Double answerListPrice, Double answerSalesUnitCost, Double goodsAPrice, string uOEStopCd, string uOESubstCode, string uOEDelivDateCd, string partsLayerCd, Double shopStUnitPrice, string uOESectionCode1, string uOESectionCode2, string uOESectionCode3, string uOESectionCode4, string uOESectionCode5, string uOESectionCode6, string uOESectionCode7, string uOESectionCode8, string headQtrsStock, Int32 uOESectionStock1, Int32 uOESectionStock2, Int32 uOESectionStock3, Int32 uOESectionStock4, Int32 uOESectionStock5, Int32 uOESectionStock6, Int32 uOESectionStock7, Int32 uOESectionStock8, Int32 uOESectionStock9, Int32 uOESectionStock10, Int32 uOESectionStock11, Int32 uOESectionStock12, Int32 uOESectionStock13, Int32 uOESectionStock14, Int32 uOESectionStock15, Int32 uOESectionStock16, Int32 uOESectionStock17, Int32 uOESectionStock18, Int32 uOESectionStock19, Int32 uOESectionStock20, Int32 uOESectionStock21, Int32 uOESectionStock22, Int32 uOESectionStock23, Int32 uOESectionStock24, Int32 uOESectionStock25, Int32 uOESectionStock26, Int32 uOESectionStock27, Int32 uOESectionStock28, Int32 uOESectionStock29, Int32 uOESectionStock30, Int32 uOESectionStock31, Int32 uOESectionStock32, Int32 uOESectionStock33, Int32 uOESectionStock34, Int32 uOESectionStock35, string headErrorMassage, string lineErrorMassage, Int32 dataSendCode, Int32 dataRecoverDiv, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._systemDivCd = systemDivCd;
            this._uOESalesOrderNo = uOESalesOrderNo;
            this._uOESalesOrderRowNo = uOESalesOrderRowNo;
            this._sendTerminalNo = sendTerminalNo;
            this._uOESupplierCd = uOESupplierCd;
            this._uOESupplierName = uOESupplierName;
            this._commAssemblyId = commAssemblyId;
            this._onlineNo = onlineNo;
            this._onlineRowNo = onlineRowNo;
            this.SalesDate = salesDate;
            this.InputDay = inputDay;
            this.DataUpdateDateTime = dataUpdateDateTime;
            this._uOEKind = uOEKind;
            this._salesSlipNum = salesSlipNum;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipDtlNum = salesSlipDtlNum;
            this._sectionCode = sectionCode;
            this._subSectionCode = subSectionCode;
            this._customerCode = customerCode;
            this._customerSnm = customerSnm;
            this._cashRegisterNo = cashRegisterNo;
            this._commonSeqNo = commonSeqNo;
            this._supplierFormal = supplierFormal;
            this._supplierSlipNo = supplierSlipNo;
            this._stockSlipDtlNum = stockSlipDtlNum;
            this._boCode = boCode;
            this._uOEDeliGoodsDiv = uOEDeliGoodsDiv;
            this._deliveredGoodsDivNm = deliveredGoodsDivNm;
            this._followDeliGoodsDiv = followDeliGoodsDiv;
            this._followDeliGoodsDivNm = followDeliGoodsDivNm;
            this._uOEResvdSection = uOEResvdSection;
            this._uOEResvdSectionNm = uOEResvdSectionNm;
            this._employeeCode = employeeCode;
            this._employeeName = employeeName;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._goodsNo = goodsNo;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._goodsName = goodsName;
            this._warehouseCode = warehouseCode;
            this._warehouseName = warehouseName;
            this._warehouseShelfNo = warehouseShelfNo;
            this._acceptAnOrderCnt = acceptAnOrderCnt;
            this._listPrice = listPrice;
            this._salesUnitCost = salesUnitCost;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this.ReceiveDate = receiveDate;
            this._receiveTime = receiveTime;
            this._answerMakerCd = answerMakerCd;
            this._answerPartsNo = answerPartsNo;
            this._answerPartsName = answerPartsName;
            this._substPartsNo = substPartsNo;
            this._centerSubstPartsNo = centerSubstPartsNo;
            this._answerListPrice = answerListPrice;
            this._answerSalesUnitCost = answerSalesUnitCost;
            this._goodsAPrice = goodsAPrice;
            this._uOEStopCd = uOEStopCd;
            this._uOESubstCode = uOESubstCode;
            this._uOEDelivDateCd = uOEDelivDateCd;
            this._partsLayerCd = partsLayerCd;
            this._shopStUnitPrice = shopStUnitPrice;
            this._uOESectionCode1 = uOESectionCode1;
            this._uOESectionCode2 = uOESectionCode2;
            this._uOESectionCode3 = uOESectionCode3;
            this._uOESectionCode4 = uOESectionCode4;
            this._uOESectionCode5 = uOESectionCode5;
            this._uOESectionCode6 = uOESectionCode6;
            this._uOESectionCode7 = uOESectionCode7;
            this._uOESectionCode8 = uOESectionCode8;
            this._headQtrsStock = headQtrsStock;
            this._uOESectionStock1 = uOESectionStock1;
            this._uOESectionStock2 = uOESectionStock2;
            this._uOESectionStock3 = uOESectionStock3;
            this._uOESectionStock4 = uOESectionStock4;
            this._uOESectionStock5 = uOESectionStock5;
            this._uOESectionStock6 = uOESectionStock6;
            this._uOESectionStock7 = uOESectionStock7;
            this._uOESectionStock8 = uOESectionStock8;
            this._uOESectionStock9 = uOESectionStock9;
            this._uOESectionStock10 = uOESectionStock10;
            this._uOESectionStock11 = uOESectionStock11;
            this._uOESectionStock12 = uOESectionStock12;
            this._uOESectionStock13 = uOESectionStock13;
            this._uOESectionStock14 = uOESectionStock14;
            this._uOESectionStock15 = uOESectionStock15;
            this._uOESectionStock16 = uOESectionStock16;
            this._uOESectionStock17 = uOESectionStock17;
            this._uOESectionStock18 = uOESectionStock18;
            this._uOESectionStock19 = uOESectionStock19;
            this._uOESectionStock20 = uOESectionStock20;
            this._uOESectionStock21 = uOESectionStock21;
            this._uOESectionStock22 = uOESectionStock22;
            this._uOESectionStock23 = uOESectionStock23;
            this._uOESectionStock24 = uOESectionStock24;
            this._uOESectionStock25 = uOESectionStock25;
            this._uOESectionStock26 = uOESectionStock26;
            this._uOESectionStock27 = uOESectionStock27;
            this._uOESectionStock28 = uOESectionStock28;
            this._uOESectionStock29 = uOESectionStock29;
            this._uOESectionStock30 = uOESectionStock30;
            this._uOESectionStock31 = uOESectionStock31;
            this._uOESectionStock32 = uOESectionStock32;
            this._uOESectionStock33 = uOESectionStock33;
            this._uOESectionStock34 = uOESectionStock34;
            this._uOESectionStock35 = uOESectionStock35;
            this._headErrorMassage = headErrorMassage;
            this._lineErrorMassage = lineErrorMassage;
            this._dataSendCode = dataSendCode;
            this._dataRecoverDiv = dataRecoverDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// UOE送受信ジャーナル（在庫）複製処理
        /// </summary>
        /// <returns>StockSndRcvJnlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockSndRcvJnlクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockSndRcvJnl Clone()
        {
            return new StockSndRcvJnl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._systemDivCd, this._uOESalesOrderNo, this._uOESalesOrderRowNo, this._sendTerminalNo, this._uOESupplierCd, this._uOESupplierName, this._commAssemblyId, this._onlineNo, this._onlineRowNo, this._salesDate, this._inputDay, this._dataUpdateDateTime, this._uOEKind, this._salesSlipNum, this._acptAnOdrStatus, this._salesSlipDtlNum, this._sectionCode, this._subSectionCode, this._customerCode, this._customerSnm, this._cashRegisterNo, this._commonSeqNo, this._supplierFormal, this._supplierSlipNo, this._stockSlipDtlNum, this._boCode, this._uOEDeliGoodsDiv, this._deliveredGoodsDivNm, this._followDeliGoodsDiv, this._followDeliGoodsDivNm, this._uOEResvdSection, this._uOEResvdSectionNm, this._employeeCode, this._employeeName, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoNoneHyphen, this._goodsName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._acceptAnOrderCnt, this._listPrice, this._salesUnitCost, this._supplierCd, this._supplierSnm, this._uoeRemark1, this._uoeRemark2, this._receiveDate, this._receiveTime, this._answerMakerCd, this._answerPartsNo, this._answerPartsName, this._substPartsNo, this._centerSubstPartsNo, this._answerListPrice, this._answerSalesUnitCost, this._goodsAPrice, this._uOEStopCd, this._uOESubstCode, this._uOEDelivDateCd, this._partsLayerCd, this._shopStUnitPrice, this._uOESectionCode1, this._uOESectionCode2, this._uOESectionCode3, this._uOESectionCode4, this._uOESectionCode5, this._uOESectionCode6, this._uOESectionCode7, this._uOESectionCode8, this._headQtrsStock, this._uOESectionStock1, this._uOESectionStock2, this._uOESectionStock3, this._uOESectionStock4, this._uOESectionStock5, this._uOESectionStock6, this._uOESectionStock7, this._uOESectionStock8, this._uOESectionStock9, this._uOESectionStock10, this._uOESectionStock11, this._uOESectionStock12, this._uOESectionStock13, this._uOESectionStock14, this._uOESectionStock15, this._uOESectionStock16, this._uOESectionStock17, this._uOESectionStock18, this._uOESectionStock19, this._uOESectionStock20, this._uOESectionStock21, this._uOESectionStock22, this._uOESectionStock23, this._uOESectionStock24, this._uOESectionStock25, this._uOESectionStock26, this._uOESectionStock27, this._uOESectionStock28, this._uOESectionStock29, this._uOESectionStock30, this._uOESectionStock31, this._uOESectionStock32, this._uOESectionStock33, this._uOESectionStock34, this._uOESectionStock35, this._headErrorMassage, this._lineErrorMassage, this._dataSendCode, this._dataRecoverDiv, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// UOE送受信ジャーナル（在庫）比較処理
        /// </summary>
        /// <param name="target">比較対象のStockSndRcvJnlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSndRcvJnlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockSndRcvJnl target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SystemDivCd == target.SystemDivCd)
                 && (this.UOESalesOrderNo == target.UOESalesOrderNo)
                 && (this.UOESalesOrderRowNo == target.UOESalesOrderRowNo)
                 && (this.SendTerminalNo == target.SendTerminalNo)
                 && (this.UOESupplierCd == target.UOESupplierCd)
                 && (this.UOESupplierName == target.UOESupplierName)
                 && (this.CommAssemblyId == target.CommAssemblyId)
                 && (this.OnlineNo == target.OnlineNo)
                 && (this.OnlineRowNo == target.OnlineRowNo)
                 && (this.SalesDate == target.SalesDate)
                 && (this.InputDay == target.InputDay)
                 && (this.DataUpdateDateTime == target.DataUpdateDateTime)
                 && (this.UOEKind == target.UOEKind)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipDtlNum == target.SalesSlipDtlNum)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.CashRegisterNo == target.CashRegisterNo)
                 && (this.CommonSeqNo == target.CommonSeqNo)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
                 && (this.BoCode == target.BoCode)
                 && (this.UOEDeliGoodsDiv == target.UOEDeliGoodsDiv)
                 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
                 && (this.FollowDeliGoodsDiv == target.FollowDeliGoodsDiv)
                 && (this.FollowDeliGoodsDivNm == target.FollowDeliGoodsDivNm)
                 && (this.UOEResvdSection == target.UOEResvdSection)
                 && (this.UOEResvdSectionNm == target.UOEResvdSectionNm)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.EmployeeName == target.EmployeeName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.GoodsName == target.GoodsName)
                 && (this.WarehouseCode == target.WarehouseCode)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                 && (this.AcceptAnOrderCnt == target.AcceptAnOrderCnt)
                 && (this.ListPrice == target.ListPrice)
                 && (this.SalesUnitCost == target.SalesUnitCost)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.ReceiveDate == target.ReceiveDate)
                 && (this.ReceiveTime == target.ReceiveTime)
                 && (this.AnswerMakerCd == target.AnswerMakerCd)
                 && (this.AnswerPartsNo == target.AnswerPartsNo)
                 && (this.AnswerPartsName == target.AnswerPartsName)
                 && (this.SubstPartsNo == target.SubstPartsNo)
                 && (this.CenterSubstPartsNo == target.CenterSubstPartsNo)
                 && (this.AnswerListPrice == target.AnswerListPrice)
                 && (this.AnswerSalesUnitCost == target.AnswerSalesUnitCost)
                 && (this.GoodsAPrice == target.GoodsAPrice)
                 && (this.UOEStopCd == target.UOEStopCd)
                 && (this.UOESubstCode == target.UOESubstCode)
                 && (this.UOEDelivDateCd == target.UOEDelivDateCd)
                 && (this.PartsLayerCd == target.PartsLayerCd)
                 && (this.ShopStUnitPrice == target.ShopStUnitPrice)
                 && (this.UOESectionCode1 == target.UOESectionCode1)
                 && (this.UOESectionCode2 == target.UOESectionCode2)
                 && (this.UOESectionCode3 == target.UOESectionCode3)
                 && (this.UOESectionCode4 == target.UOESectionCode4)
                 && (this.UOESectionCode5 == target.UOESectionCode5)
                 && (this.UOESectionCode6 == target.UOESectionCode6)
                 && (this.UOESectionCode7 == target.UOESectionCode7)
                 && (this.UOESectionCode8 == target.UOESectionCode8)
                 && (this.HeadQtrsStock == target.HeadQtrsStock)
                 && (this.UOESectionStock1 == target.UOESectionStock1)
                 && (this.UOESectionStock2 == target.UOESectionStock2)
                 && (this.UOESectionStock3 == target.UOESectionStock3)
                 && (this.UOESectionStock4 == target.UOESectionStock4)
                 && (this.UOESectionStock5 == target.UOESectionStock5)
                 && (this.UOESectionStock6 == target.UOESectionStock6)
                 && (this.UOESectionStock7 == target.UOESectionStock7)
                 && (this.UOESectionStock8 == target.UOESectionStock8)
                 && (this.UOESectionStock9 == target.UOESectionStock9)
                 && (this.UOESectionStock10 == target.UOESectionStock10)
                 && (this.UOESectionStock11 == target.UOESectionStock11)
                 && (this.UOESectionStock12 == target.UOESectionStock12)
                 && (this.UOESectionStock13 == target.UOESectionStock13)
                 && (this.UOESectionStock14 == target.UOESectionStock14)
                 && (this.UOESectionStock15 == target.UOESectionStock15)
                 && (this.UOESectionStock16 == target.UOESectionStock16)
                 && (this.UOESectionStock17 == target.UOESectionStock17)
                 && (this.UOESectionStock18 == target.UOESectionStock18)
                 && (this.UOESectionStock19 == target.UOESectionStock19)
                 && (this.UOESectionStock20 == target.UOESectionStock20)
                 && (this.UOESectionStock21 == target.UOESectionStock21)
                 && (this.UOESectionStock22 == target.UOESectionStock22)
                 && (this.UOESectionStock23 == target.UOESectionStock23)
                 && (this.UOESectionStock24 == target.UOESectionStock24)
                 && (this.UOESectionStock25 == target.UOESectionStock25)
                 && (this.UOESectionStock26 == target.UOESectionStock26)
                 && (this.UOESectionStock27 == target.UOESectionStock27)
                 && (this.UOESectionStock28 == target.UOESectionStock28)
                 && (this.UOESectionStock29 == target.UOESectionStock29)
                 && (this.UOESectionStock30 == target.UOESectionStock30)
                 && (this.UOESectionStock31 == target.UOESectionStock31)
                 && (this.UOESectionStock32 == target.UOESectionStock32)
                 && (this.UOESectionStock33 == target.UOESectionStock33)
                 && (this.UOESectionStock34 == target.UOESectionStock34)
                 && (this.UOESectionStock35 == target.UOESectionStock35)
                 && (this.HeadErrorMassage == target.HeadErrorMassage)
                 && (this.LineErrorMassage == target.LineErrorMassage)
                 && (this.DataSendCode == target.DataSendCode)
                 && (this.DataRecoverDiv == target.DataRecoverDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// UOE送受信ジャーナル（在庫）比較処理
        /// </summary>
        /// <param name="stockSndRcvJnl1">
        ///                    比較するStockSndRcvJnlクラスのインスタンス
        /// </param>
        /// <param name="stockSndRcvJnl2">比較するStockSndRcvJnlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSndRcvJnlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockSndRcvJnl stockSndRcvJnl1, StockSndRcvJnl stockSndRcvJnl2)
        {
            return ((stockSndRcvJnl1.CreateDateTime == stockSndRcvJnl2.CreateDateTime)
                 && (stockSndRcvJnl1.UpdateDateTime == stockSndRcvJnl2.UpdateDateTime)
                 && (stockSndRcvJnl1.EnterpriseCode == stockSndRcvJnl2.EnterpriseCode)
                 && (stockSndRcvJnl1.FileHeaderGuid == stockSndRcvJnl2.FileHeaderGuid)
                 && (stockSndRcvJnl1.UpdEmployeeCode == stockSndRcvJnl2.UpdEmployeeCode)
                 && (stockSndRcvJnl1.UpdAssemblyId1 == stockSndRcvJnl2.UpdAssemblyId1)
                 && (stockSndRcvJnl1.UpdAssemblyId2 == stockSndRcvJnl2.UpdAssemblyId2)
                 && (stockSndRcvJnl1.LogicalDeleteCode == stockSndRcvJnl2.LogicalDeleteCode)
                 && (stockSndRcvJnl1.SystemDivCd == stockSndRcvJnl2.SystemDivCd)
                 && (stockSndRcvJnl1.UOESalesOrderNo == stockSndRcvJnl2.UOESalesOrderNo)
                 && (stockSndRcvJnl1.UOESalesOrderRowNo == stockSndRcvJnl2.UOESalesOrderRowNo)
                 && (stockSndRcvJnl1.SendTerminalNo == stockSndRcvJnl2.SendTerminalNo)
                 && (stockSndRcvJnl1.UOESupplierCd == stockSndRcvJnl2.UOESupplierCd)
                 && (stockSndRcvJnl1.UOESupplierName == stockSndRcvJnl2.UOESupplierName)
                 && (stockSndRcvJnl1.CommAssemblyId == stockSndRcvJnl2.CommAssemblyId)
                 && (stockSndRcvJnl1.OnlineNo == stockSndRcvJnl2.OnlineNo)
                 && (stockSndRcvJnl1.OnlineRowNo == stockSndRcvJnl2.OnlineRowNo)
                 && (stockSndRcvJnl1.SalesDate == stockSndRcvJnl2.SalesDate)
                 && (stockSndRcvJnl1.InputDay == stockSndRcvJnl2.InputDay)
                 && (stockSndRcvJnl1.DataUpdateDateTime == stockSndRcvJnl2.DataUpdateDateTime)
                 && (stockSndRcvJnl1.UOEKind == stockSndRcvJnl2.UOEKind)
                 && (stockSndRcvJnl1.SalesSlipNum == stockSndRcvJnl2.SalesSlipNum)
                 && (stockSndRcvJnl1.AcptAnOdrStatus == stockSndRcvJnl2.AcptAnOdrStatus)
                 && (stockSndRcvJnl1.SalesSlipDtlNum == stockSndRcvJnl2.SalesSlipDtlNum)
                 && (stockSndRcvJnl1.SectionCode == stockSndRcvJnl2.SectionCode)
                 && (stockSndRcvJnl1.SubSectionCode == stockSndRcvJnl2.SubSectionCode)
                 && (stockSndRcvJnl1.CustomerCode == stockSndRcvJnl2.CustomerCode)
                 && (stockSndRcvJnl1.CustomerSnm == stockSndRcvJnl2.CustomerSnm)
                 && (stockSndRcvJnl1.CashRegisterNo == stockSndRcvJnl2.CashRegisterNo)
                 && (stockSndRcvJnl1.CommonSeqNo == stockSndRcvJnl2.CommonSeqNo)
                 && (stockSndRcvJnl1.SupplierFormal == stockSndRcvJnl2.SupplierFormal)
                 && (stockSndRcvJnl1.SupplierSlipNo == stockSndRcvJnl2.SupplierSlipNo)
                 && (stockSndRcvJnl1.StockSlipDtlNum == stockSndRcvJnl2.StockSlipDtlNum)
                 && (stockSndRcvJnl1.BoCode == stockSndRcvJnl2.BoCode)
                 && (stockSndRcvJnl1.UOEDeliGoodsDiv == stockSndRcvJnl2.UOEDeliGoodsDiv)
                 && (stockSndRcvJnl1.DeliveredGoodsDivNm == stockSndRcvJnl2.DeliveredGoodsDivNm)
                 && (stockSndRcvJnl1.FollowDeliGoodsDiv == stockSndRcvJnl2.FollowDeliGoodsDiv)
                 && (stockSndRcvJnl1.FollowDeliGoodsDivNm == stockSndRcvJnl2.FollowDeliGoodsDivNm)
                 && (stockSndRcvJnl1.UOEResvdSection == stockSndRcvJnl2.UOEResvdSection)
                 && (stockSndRcvJnl1.UOEResvdSectionNm == stockSndRcvJnl2.UOEResvdSectionNm)
                 && (stockSndRcvJnl1.EmployeeCode == stockSndRcvJnl2.EmployeeCode)
                 && (stockSndRcvJnl1.EmployeeName == stockSndRcvJnl2.EmployeeName)
                 && (stockSndRcvJnl1.GoodsMakerCd == stockSndRcvJnl2.GoodsMakerCd)
                 && (stockSndRcvJnl1.MakerName == stockSndRcvJnl2.MakerName)
                 && (stockSndRcvJnl1.GoodsNo == stockSndRcvJnl2.GoodsNo)
                 && (stockSndRcvJnl1.GoodsNoNoneHyphen == stockSndRcvJnl2.GoodsNoNoneHyphen)
                 && (stockSndRcvJnl1.GoodsName == stockSndRcvJnl2.GoodsName)
                 && (stockSndRcvJnl1.WarehouseCode == stockSndRcvJnl2.WarehouseCode)
                 && (stockSndRcvJnl1.WarehouseName == stockSndRcvJnl2.WarehouseName)
                 && (stockSndRcvJnl1.WarehouseShelfNo == stockSndRcvJnl2.WarehouseShelfNo)
                 && (stockSndRcvJnl1.AcceptAnOrderCnt == stockSndRcvJnl2.AcceptAnOrderCnt)
                 && (stockSndRcvJnl1.ListPrice == stockSndRcvJnl2.ListPrice)
                 && (stockSndRcvJnl1.SalesUnitCost == stockSndRcvJnl2.SalesUnitCost)
                 && (stockSndRcvJnl1.SupplierCd == stockSndRcvJnl2.SupplierCd)
                 && (stockSndRcvJnl1.SupplierSnm == stockSndRcvJnl2.SupplierSnm)
                 && (stockSndRcvJnl1.UoeRemark1 == stockSndRcvJnl2.UoeRemark1)
                 && (stockSndRcvJnl1.UoeRemark2 == stockSndRcvJnl2.UoeRemark2)
                 && (stockSndRcvJnl1.ReceiveDate == stockSndRcvJnl2.ReceiveDate)
                 && (stockSndRcvJnl1.ReceiveTime == stockSndRcvJnl2.ReceiveTime)
                 && (stockSndRcvJnl1.AnswerMakerCd == stockSndRcvJnl2.AnswerMakerCd)
                 && (stockSndRcvJnl1.AnswerPartsNo == stockSndRcvJnl2.AnswerPartsNo)
                 && (stockSndRcvJnl1.AnswerPartsName == stockSndRcvJnl2.AnswerPartsName)
                 && (stockSndRcvJnl1.SubstPartsNo == stockSndRcvJnl2.SubstPartsNo)
                 && (stockSndRcvJnl1.CenterSubstPartsNo == stockSndRcvJnl2.CenterSubstPartsNo)
                 && (stockSndRcvJnl1.AnswerListPrice == stockSndRcvJnl2.AnswerListPrice)
                 && (stockSndRcvJnl1.AnswerSalesUnitCost == stockSndRcvJnl2.AnswerSalesUnitCost)
                 && (stockSndRcvJnl1.GoodsAPrice == stockSndRcvJnl2.GoodsAPrice)
                 && (stockSndRcvJnl1.UOEStopCd == stockSndRcvJnl2.UOEStopCd)
                 && (stockSndRcvJnl1.UOESubstCode == stockSndRcvJnl2.UOESubstCode)
                 && (stockSndRcvJnl1.UOEDelivDateCd == stockSndRcvJnl2.UOEDelivDateCd)
                 && (stockSndRcvJnl1.PartsLayerCd == stockSndRcvJnl2.PartsLayerCd)
                 && (stockSndRcvJnl1.ShopStUnitPrice == stockSndRcvJnl2.ShopStUnitPrice)
                 && (stockSndRcvJnl1.UOESectionCode1 == stockSndRcvJnl2.UOESectionCode1)
                 && (stockSndRcvJnl1.UOESectionCode2 == stockSndRcvJnl2.UOESectionCode2)
                 && (stockSndRcvJnl1.UOESectionCode3 == stockSndRcvJnl2.UOESectionCode3)
                 && (stockSndRcvJnl1.UOESectionCode4 == stockSndRcvJnl2.UOESectionCode4)
                 && (stockSndRcvJnl1.UOESectionCode5 == stockSndRcvJnl2.UOESectionCode5)
                 && (stockSndRcvJnl1.UOESectionCode6 == stockSndRcvJnl2.UOESectionCode6)
                 && (stockSndRcvJnl1.UOESectionCode7 == stockSndRcvJnl2.UOESectionCode7)
                 && (stockSndRcvJnl1.UOESectionCode8 == stockSndRcvJnl2.UOESectionCode8)
                 && (stockSndRcvJnl1.HeadQtrsStock == stockSndRcvJnl2.HeadQtrsStock)
                 && (stockSndRcvJnl1.UOESectionStock1 == stockSndRcvJnl2.UOESectionStock1)
                 && (stockSndRcvJnl1.UOESectionStock2 == stockSndRcvJnl2.UOESectionStock2)
                 && (stockSndRcvJnl1.UOESectionStock3 == stockSndRcvJnl2.UOESectionStock3)
                 && (stockSndRcvJnl1.UOESectionStock4 == stockSndRcvJnl2.UOESectionStock4)
                 && (stockSndRcvJnl1.UOESectionStock5 == stockSndRcvJnl2.UOESectionStock5)
                 && (stockSndRcvJnl1.UOESectionStock6 == stockSndRcvJnl2.UOESectionStock6)
                 && (stockSndRcvJnl1.UOESectionStock7 == stockSndRcvJnl2.UOESectionStock7)
                 && (stockSndRcvJnl1.UOESectionStock8 == stockSndRcvJnl2.UOESectionStock8)
                 && (stockSndRcvJnl1.UOESectionStock9 == stockSndRcvJnl2.UOESectionStock9)
                 && (stockSndRcvJnl1.UOESectionStock10 == stockSndRcvJnl2.UOESectionStock10)
                 && (stockSndRcvJnl1.UOESectionStock11 == stockSndRcvJnl2.UOESectionStock11)
                 && (stockSndRcvJnl1.UOESectionStock12 == stockSndRcvJnl2.UOESectionStock12)
                 && (stockSndRcvJnl1.UOESectionStock13 == stockSndRcvJnl2.UOESectionStock13)
                 && (stockSndRcvJnl1.UOESectionStock14 == stockSndRcvJnl2.UOESectionStock14)
                 && (stockSndRcvJnl1.UOESectionStock15 == stockSndRcvJnl2.UOESectionStock15)
                 && (stockSndRcvJnl1.UOESectionStock16 == stockSndRcvJnl2.UOESectionStock16)
                 && (stockSndRcvJnl1.UOESectionStock17 == stockSndRcvJnl2.UOESectionStock17)
                 && (stockSndRcvJnl1.UOESectionStock18 == stockSndRcvJnl2.UOESectionStock18)
                 && (stockSndRcvJnl1.UOESectionStock19 == stockSndRcvJnl2.UOESectionStock19)
                 && (stockSndRcvJnl1.UOESectionStock20 == stockSndRcvJnl2.UOESectionStock20)
                 && (stockSndRcvJnl1.UOESectionStock21 == stockSndRcvJnl2.UOESectionStock21)
                 && (stockSndRcvJnl1.UOESectionStock22 == stockSndRcvJnl2.UOESectionStock22)
                 && (stockSndRcvJnl1.UOESectionStock23 == stockSndRcvJnl2.UOESectionStock23)
                 && (stockSndRcvJnl1.UOESectionStock24 == stockSndRcvJnl2.UOESectionStock24)
                 && (stockSndRcvJnl1.UOESectionStock25 == stockSndRcvJnl2.UOESectionStock25)
                 && (stockSndRcvJnl1.UOESectionStock26 == stockSndRcvJnl2.UOESectionStock26)
                 && (stockSndRcvJnl1.UOESectionStock27 == stockSndRcvJnl2.UOESectionStock27)
                 && (stockSndRcvJnl1.UOESectionStock28 == stockSndRcvJnl2.UOESectionStock28)
                 && (stockSndRcvJnl1.UOESectionStock29 == stockSndRcvJnl2.UOESectionStock29)
                 && (stockSndRcvJnl1.UOESectionStock30 == stockSndRcvJnl2.UOESectionStock30)
                 && (stockSndRcvJnl1.UOESectionStock31 == stockSndRcvJnl2.UOESectionStock31)
                 && (stockSndRcvJnl1.UOESectionStock32 == stockSndRcvJnl2.UOESectionStock32)
                 && (stockSndRcvJnl1.UOESectionStock33 == stockSndRcvJnl2.UOESectionStock33)
                 && (stockSndRcvJnl1.UOESectionStock34 == stockSndRcvJnl2.UOESectionStock34)
                 && (stockSndRcvJnl1.UOESectionStock35 == stockSndRcvJnl2.UOESectionStock35)
                 && (stockSndRcvJnl1.HeadErrorMassage == stockSndRcvJnl2.HeadErrorMassage)
                 && (stockSndRcvJnl1.LineErrorMassage == stockSndRcvJnl2.LineErrorMassage)
                 && (stockSndRcvJnl1.DataSendCode == stockSndRcvJnl2.DataSendCode)
                 && (stockSndRcvJnl1.DataRecoverDiv == stockSndRcvJnl2.DataRecoverDiv)
                 && (stockSndRcvJnl1.EnterpriseName == stockSndRcvJnl2.EnterpriseName)
                 && (stockSndRcvJnl1.UpdEmployeeName == stockSndRcvJnl2.UpdEmployeeName));
        }
        /// <summary>
        /// UOE送受信ジャーナル（在庫）比較処理
        /// </summary>
        /// <param name="target">比較対象のStockSndRcvJnlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSndRcvJnlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockSndRcvJnl target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SystemDivCd != target.SystemDivCd) resList.Add("SystemDivCd");
            if (this.UOESalesOrderNo != target.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (this.UOESalesOrderRowNo != target.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");
            if (this.SendTerminalNo != target.SendTerminalNo) resList.Add("SendTerminalNo");
            if (this.UOESupplierCd != target.UOESupplierCd) resList.Add("UOESupplierCd");
            if (this.UOESupplierName != target.UOESupplierName) resList.Add("UOESupplierName");
            if (this.CommAssemblyId != target.CommAssemblyId) resList.Add("CommAssemblyId");
            if (this.OnlineNo != target.OnlineNo) resList.Add("OnlineNo");
            if (this.OnlineRowNo != target.OnlineRowNo) resList.Add("OnlineRowNo");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.InputDay != target.InputDay) resList.Add("InputDay");
            if (this.DataUpdateDateTime != target.DataUpdateDateTime) resList.Add("DataUpdateDateTime");
            if (this.UOEKind != target.UOEKind) resList.Add("UOEKind");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipDtlNum != target.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.CommonSeqNo != target.CommonSeqNo) resList.Add("CommonSeqNo");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.StockSlipDtlNum != target.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (this.BoCode != target.BoCode) resList.Add("BoCode");
            if (this.UOEDeliGoodsDiv != target.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (this.FollowDeliGoodsDiv != target.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (this.FollowDeliGoodsDivNm != target.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (this.UOEResvdSection != target.UOEResvdSection) resList.Add("UOEResvdSection");
            if (this.UOEResvdSectionNm != target.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.EmployeeName != target.EmployeeName) resList.Add("EmployeeName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.AcceptAnOrderCnt != target.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.ReceiveDate != target.ReceiveDate) resList.Add("ReceiveDate");
            if (this.ReceiveTime != target.ReceiveTime) resList.Add("ReceiveTime");
            if (this.AnswerMakerCd != target.AnswerMakerCd) resList.Add("AnswerMakerCd");
            if (this.AnswerPartsNo != target.AnswerPartsNo) resList.Add("AnswerPartsNo");
            if (this.AnswerPartsName != target.AnswerPartsName) resList.Add("AnswerPartsName");
            if (this.SubstPartsNo != target.SubstPartsNo) resList.Add("SubstPartsNo");
            if (this.CenterSubstPartsNo != target.CenterSubstPartsNo) resList.Add("CenterSubstPartsNo");
            if (this.AnswerListPrice != target.AnswerListPrice) resList.Add("AnswerListPrice");
            if (this.AnswerSalesUnitCost != target.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");
            if (this.GoodsAPrice != target.GoodsAPrice) resList.Add("GoodsAPrice");
            if (this.UOEStopCd != target.UOEStopCd) resList.Add("UOEStopCd");
            if (this.UOESubstCode != target.UOESubstCode) resList.Add("UOESubstCode");
            if (this.UOEDelivDateCd != target.UOEDelivDateCd) resList.Add("UOEDelivDateCd");
            if (this.PartsLayerCd != target.PartsLayerCd) resList.Add("PartsLayerCd");
            if (this.ShopStUnitPrice != target.ShopStUnitPrice) resList.Add("ShopStUnitPrice");
            if (this.UOESectionCode1 != target.UOESectionCode1) resList.Add("UOESectionCode1");
            if (this.UOESectionCode2 != target.UOESectionCode2) resList.Add("UOESectionCode2");
            if (this.UOESectionCode3 != target.UOESectionCode3) resList.Add("UOESectionCode3");
            if (this.UOESectionCode4 != target.UOESectionCode4) resList.Add("UOESectionCode4");
            if (this.UOESectionCode5 != target.UOESectionCode5) resList.Add("UOESectionCode5");
            if (this.UOESectionCode6 != target.UOESectionCode6) resList.Add("UOESectionCode6");
            if (this.UOESectionCode7 != target.UOESectionCode7) resList.Add("UOESectionCode7");
            if (this.UOESectionCode8 != target.UOESectionCode8) resList.Add("UOESectionCode8");
            if (this.HeadQtrsStock != target.HeadQtrsStock) resList.Add("HeadQtrsStock");
            if (this.UOESectionStock1 != target.UOESectionStock1) resList.Add("UOESectionStock1");
            if (this.UOESectionStock2 != target.UOESectionStock2) resList.Add("UOESectionStock2");
            if (this.UOESectionStock3 != target.UOESectionStock3) resList.Add("UOESectionStock3");
            if (this.UOESectionStock4 != target.UOESectionStock4) resList.Add("UOESectionStock4");
            if (this.UOESectionStock5 != target.UOESectionStock5) resList.Add("UOESectionStock5");
            if (this.UOESectionStock6 != target.UOESectionStock6) resList.Add("UOESectionStock6");
            if (this.UOESectionStock7 != target.UOESectionStock7) resList.Add("UOESectionStock7");
            if (this.UOESectionStock8 != target.UOESectionStock8) resList.Add("UOESectionStock8");
            if (this.UOESectionStock9 != target.UOESectionStock9) resList.Add("UOESectionStock9");
            if (this.UOESectionStock10 != target.UOESectionStock10) resList.Add("UOESectionStock10");
            if (this.UOESectionStock11 != target.UOESectionStock11) resList.Add("UOESectionStock11");
            if (this.UOESectionStock12 != target.UOESectionStock12) resList.Add("UOESectionStock12");
            if (this.UOESectionStock13 != target.UOESectionStock13) resList.Add("UOESectionStock13");
            if (this.UOESectionStock14 != target.UOESectionStock14) resList.Add("UOESectionStock14");
            if (this.UOESectionStock15 != target.UOESectionStock15) resList.Add("UOESectionStock15");
            if (this.UOESectionStock16 != target.UOESectionStock16) resList.Add("UOESectionStock16");
            if (this.UOESectionStock17 != target.UOESectionStock17) resList.Add("UOESectionStock17");
            if (this.UOESectionStock18 != target.UOESectionStock18) resList.Add("UOESectionStock18");
            if (this.UOESectionStock19 != target.UOESectionStock19) resList.Add("UOESectionStock19");
            if (this.UOESectionStock20 != target.UOESectionStock20) resList.Add("UOESectionStock20");
            if (this.UOESectionStock21 != target.UOESectionStock21) resList.Add("UOESectionStock21");
            if (this.UOESectionStock22 != target.UOESectionStock22) resList.Add("UOESectionStock22");
            if (this.UOESectionStock23 != target.UOESectionStock23) resList.Add("UOESectionStock23");
            if (this.UOESectionStock24 != target.UOESectionStock24) resList.Add("UOESectionStock24");
            if (this.UOESectionStock25 != target.UOESectionStock25) resList.Add("UOESectionStock25");
            if (this.UOESectionStock26 != target.UOESectionStock26) resList.Add("UOESectionStock26");
            if (this.UOESectionStock27 != target.UOESectionStock27) resList.Add("UOESectionStock27");
            if (this.UOESectionStock28 != target.UOESectionStock28) resList.Add("UOESectionStock28");
            if (this.UOESectionStock29 != target.UOESectionStock29) resList.Add("UOESectionStock29");
            if (this.UOESectionStock30 != target.UOESectionStock30) resList.Add("UOESectionStock30");
            if (this.UOESectionStock31 != target.UOESectionStock31) resList.Add("UOESectionStock31");
            if (this.UOESectionStock32 != target.UOESectionStock32) resList.Add("UOESectionStock32");
            if (this.UOESectionStock33 != target.UOESectionStock33) resList.Add("UOESectionStock33");
            if (this.UOESectionStock34 != target.UOESectionStock34) resList.Add("UOESectionStock34");
            if (this.UOESectionStock35 != target.UOESectionStock35) resList.Add("UOESectionStock35");
            if (this.HeadErrorMassage != target.HeadErrorMassage) resList.Add("HeadErrorMassage");
            if (this.LineErrorMassage != target.LineErrorMassage) resList.Add("LineErrorMassage");
            if (this.DataSendCode != target.DataSendCode) resList.Add("DataSendCode");
            if (this.DataRecoverDiv != target.DataRecoverDiv) resList.Add("DataRecoverDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// UOE送受信ジャーナル（在庫）比較処理
        /// </summary>
        /// <param name="stockSndRcvJnl1">比較するStockSndRcvJnlクラスのインスタンス</param>
        /// <param name="stockSndRcvJnl2">比較するStockSndRcvJnlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockSndRcvJnlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockSndRcvJnl stockSndRcvJnl1, StockSndRcvJnl stockSndRcvJnl2)
        {
            ArrayList resList = new ArrayList();
            if (stockSndRcvJnl1.CreateDateTime != stockSndRcvJnl2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockSndRcvJnl1.UpdateDateTime != stockSndRcvJnl2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockSndRcvJnl1.EnterpriseCode != stockSndRcvJnl2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockSndRcvJnl1.FileHeaderGuid != stockSndRcvJnl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockSndRcvJnl1.UpdEmployeeCode != stockSndRcvJnl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockSndRcvJnl1.UpdAssemblyId1 != stockSndRcvJnl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockSndRcvJnl1.UpdAssemblyId2 != stockSndRcvJnl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockSndRcvJnl1.LogicalDeleteCode != stockSndRcvJnl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockSndRcvJnl1.SystemDivCd != stockSndRcvJnl2.SystemDivCd) resList.Add("SystemDivCd");
            if (stockSndRcvJnl1.UOESalesOrderNo != stockSndRcvJnl2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (stockSndRcvJnl1.UOESalesOrderRowNo != stockSndRcvJnl2.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");
            if (stockSndRcvJnl1.SendTerminalNo != stockSndRcvJnl2.SendTerminalNo) resList.Add("SendTerminalNo");
            if (stockSndRcvJnl1.UOESupplierCd != stockSndRcvJnl2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (stockSndRcvJnl1.UOESupplierName != stockSndRcvJnl2.UOESupplierName) resList.Add("UOESupplierName");
            if (stockSndRcvJnl1.CommAssemblyId != stockSndRcvJnl2.CommAssemblyId) resList.Add("CommAssemblyId");
            if (stockSndRcvJnl1.OnlineNo != stockSndRcvJnl2.OnlineNo) resList.Add("OnlineNo");
            if (stockSndRcvJnl1.OnlineRowNo != stockSndRcvJnl2.OnlineRowNo) resList.Add("OnlineRowNo");
            if (stockSndRcvJnl1.SalesDate != stockSndRcvJnl2.SalesDate) resList.Add("SalesDate");
            if (stockSndRcvJnl1.InputDay != stockSndRcvJnl2.InputDay) resList.Add("InputDay");
            if (stockSndRcvJnl1.DataUpdateDateTime != stockSndRcvJnl2.DataUpdateDateTime) resList.Add("DataUpdateDateTime");
            if (stockSndRcvJnl1.UOEKind != stockSndRcvJnl2.UOEKind) resList.Add("UOEKind");
            if (stockSndRcvJnl1.SalesSlipNum != stockSndRcvJnl2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (stockSndRcvJnl1.AcptAnOdrStatus != stockSndRcvJnl2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (stockSndRcvJnl1.SalesSlipDtlNum != stockSndRcvJnl2.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (stockSndRcvJnl1.SectionCode != stockSndRcvJnl2.SectionCode) resList.Add("SectionCode");
            if (stockSndRcvJnl1.SubSectionCode != stockSndRcvJnl2.SubSectionCode) resList.Add("SubSectionCode");
            if (stockSndRcvJnl1.CustomerCode != stockSndRcvJnl2.CustomerCode) resList.Add("CustomerCode");
            if (stockSndRcvJnl1.CustomerSnm != stockSndRcvJnl2.CustomerSnm) resList.Add("CustomerSnm");
            if (stockSndRcvJnl1.CashRegisterNo != stockSndRcvJnl2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (stockSndRcvJnl1.CommonSeqNo != stockSndRcvJnl2.CommonSeqNo) resList.Add("CommonSeqNo");
            if (stockSndRcvJnl1.SupplierFormal != stockSndRcvJnl2.SupplierFormal) resList.Add("SupplierFormal");
            if (stockSndRcvJnl1.SupplierSlipNo != stockSndRcvJnl2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (stockSndRcvJnl1.StockSlipDtlNum != stockSndRcvJnl2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (stockSndRcvJnl1.BoCode != stockSndRcvJnl2.BoCode) resList.Add("BoCode");
            if (stockSndRcvJnl1.UOEDeliGoodsDiv != stockSndRcvJnl2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (stockSndRcvJnl1.DeliveredGoodsDivNm != stockSndRcvJnl2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (stockSndRcvJnl1.FollowDeliGoodsDiv != stockSndRcvJnl2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (stockSndRcvJnl1.FollowDeliGoodsDivNm != stockSndRcvJnl2.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (stockSndRcvJnl1.UOEResvdSection != stockSndRcvJnl2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (stockSndRcvJnl1.UOEResvdSectionNm != stockSndRcvJnl2.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (stockSndRcvJnl1.EmployeeCode != stockSndRcvJnl2.EmployeeCode) resList.Add("EmployeeCode");
            if (stockSndRcvJnl1.EmployeeName != stockSndRcvJnl2.EmployeeName) resList.Add("EmployeeName");
            if (stockSndRcvJnl1.GoodsMakerCd != stockSndRcvJnl2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stockSndRcvJnl1.MakerName != stockSndRcvJnl2.MakerName) resList.Add("MakerName");
            if (stockSndRcvJnl1.GoodsNo != stockSndRcvJnl2.GoodsNo) resList.Add("GoodsNo");
            if (stockSndRcvJnl1.GoodsNoNoneHyphen != stockSndRcvJnl2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (stockSndRcvJnl1.GoodsName != stockSndRcvJnl2.GoodsName) resList.Add("GoodsName");
            if (stockSndRcvJnl1.WarehouseCode != stockSndRcvJnl2.WarehouseCode) resList.Add("WarehouseCode");
            if (stockSndRcvJnl1.WarehouseName != stockSndRcvJnl2.WarehouseName) resList.Add("WarehouseName");
            if (stockSndRcvJnl1.WarehouseShelfNo != stockSndRcvJnl2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stockSndRcvJnl1.AcceptAnOrderCnt != stockSndRcvJnl2.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (stockSndRcvJnl1.ListPrice != stockSndRcvJnl2.ListPrice) resList.Add("ListPrice");
            if (stockSndRcvJnl1.SalesUnitCost != stockSndRcvJnl2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (stockSndRcvJnl1.SupplierCd != stockSndRcvJnl2.SupplierCd) resList.Add("SupplierCd");
            if (stockSndRcvJnl1.SupplierSnm != stockSndRcvJnl2.SupplierSnm) resList.Add("SupplierSnm");
            if (stockSndRcvJnl1.UoeRemark1 != stockSndRcvJnl2.UoeRemark1) resList.Add("UoeRemark1");
            if (stockSndRcvJnl1.UoeRemark2 != stockSndRcvJnl2.UoeRemark2) resList.Add("UoeRemark2");
            if (stockSndRcvJnl1.ReceiveDate != stockSndRcvJnl2.ReceiveDate) resList.Add("ReceiveDate");
            if (stockSndRcvJnl1.ReceiveTime != stockSndRcvJnl2.ReceiveTime) resList.Add("ReceiveTime");
            if (stockSndRcvJnl1.AnswerMakerCd != stockSndRcvJnl2.AnswerMakerCd) resList.Add("AnswerMakerCd");
            if (stockSndRcvJnl1.AnswerPartsNo != stockSndRcvJnl2.AnswerPartsNo) resList.Add("AnswerPartsNo");
            if (stockSndRcvJnl1.AnswerPartsName != stockSndRcvJnl2.AnswerPartsName) resList.Add("AnswerPartsName");
            if (stockSndRcvJnl1.SubstPartsNo != stockSndRcvJnl2.SubstPartsNo) resList.Add("SubstPartsNo");
            if (stockSndRcvJnl1.CenterSubstPartsNo != stockSndRcvJnl2.CenterSubstPartsNo) resList.Add("CenterSubstPartsNo");
            if (stockSndRcvJnl1.AnswerListPrice != stockSndRcvJnl2.AnswerListPrice) resList.Add("AnswerListPrice");
            if (stockSndRcvJnl1.AnswerSalesUnitCost != stockSndRcvJnl2.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");
            if (stockSndRcvJnl1.GoodsAPrice != stockSndRcvJnl2.GoodsAPrice) resList.Add("GoodsAPrice");
            if (stockSndRcvJnl1.UOEStopCd != stockSndRcvJnl2.UOEStopCd) resList.Add("UOEStopCd");
            if (stockSndRcvJnl1.UOESubstCode != stockSndRcvJnl2.UOESubstCode) resList.Add("UOESubstCode");
            if (stockSndRcvJnl1.UOEDelivDateCd != stockSndRcvJnl2.UOEDelivDateCd) resList.Add("UOEDelivDateCd");
            if (stockSndRcvJnl1.PartsLayerCd != stockSndRcvJnl2.PartsLayerCd) resList.Add("PartsLayerCd");
            if (stockSndRcvJnl1.ShopStUnitPrice != stockSndRcvJnl2.ShopStUnitPrice) resList.Add("ShopStUnitPrice");
            if (stockSndRcvJnl1.UOESectionCode1 != stockSndRcvJnl2.UOESectionCode1) resList.Add("UOESectionCode1");
            if (stockSndRcvJnl1.UOESectionCode2 != stockSndRcvJnl2.UOESectionCode2) resList.Add("UOESectionCode2");
            if (stockSndRcvJnl1.UOESectionCode3 != stockSndRcvJnl2.UOESectionCode3) resList.Add("UOESectionCode3");
            if (stockSndRcvJnl1.UOESectionCode4 != stockSndRcvJnl2.UOESectionCode4) resList.Add("UOESectionCode4");
            if (stockSndRcvJnl1.UOESectionCode5 != stockSndRcvJnl2.UOESectionCode5) resList.Add("UOESectionCode5");
            if (stockSndRcvJnl1.UOESectionCode6 != stockSndRcvJnl2.UOESectionCode6) resList.Add("UOESectionCode6");
            if (stockSndRcvJnl1.UOESectionCode7 != stockSndRcvJnl2.UOESectionCode7) resList.Add("UOESectionCode7");
            if (stockSndRcvJnl1.UOESectionCode8 != stockSndRcvJnl2.UOESectionCode8) resList.Add("UOESectionCode8");
            if (stockSndRcvJnl1.HeadQtrsStock != stockSndRcvJnl2.HeadQtrsStock) resList.Add("HeadQtrsStock");
            if (stockSndRcvJnl1.UOESectionStock1 != stockSndRcvJnl2.UOESectionStock1) resList.Add("UOESectionStock1");
            if (stockSndRcvJnl1.UOESectionStock2 != stockSndRcvJnl2.UOESectionStock2) resList.Add("UOESectionStock2");
            if (stockSndRcvJnl1.UOESectionStock3 != stockSndRcvJnl2.UOESectionStock3) resList.Add("UOESectionStock3");
            if (stockSndRcvJnl1.UOESectionStock4 != stockSndRcvJnl2.UOESectionStock4) resList.Add("UOESectionStock4");
            if (stockSndRcvJnl1.UOESectionStock5 != stockSndRcvJnl2.UOESectionStock5) resList.Add("UOESectionStock5");
            if (stockSndRcvJnl1.UOESectionStock6 != stockSndRcvJnl2.UOESectionStock6) resList.Add("UOESectionStock6");
            if (stockSndRcvJnl1.UOESectionStock7 != stockSndRcvJnl2.UOESectionStock7) resList.Add("UOESectionStock7");
            if (stockSndRcvJnl1.UOESectionStock8 != stockSndRcvJnl2.UOESectionStock8) resList.Add("UOESectionStock8");
            if (stockSndRcvJnl1.UOESectionStock9 != stockSndRcvJnl2.UOESectionStock9) resList.Add("UOESectionStock9");
            if (stockSndRcvJnl1.UOESectionStock10 != stockSndRcvJnl2.UOESectionStock10) resList.Add("UOESectionStock10");
            if (stockSndRcvJnl1.UOESectionStock11 != stockSndRcvJnl2.UOESectionStock11) resList.Add("UOESectionStock11");
            if (stockSndRcvJnl1.UOESectionStock12 != stockSndRcvJnl2.UOESectionStock12) resList.Add("UOESectionStock12");
            if (stockSndRcvJnl1.UOESectionStock13 != stockSndRcvJnl2.UOESectionStock13) resList.Add("UOESectionStock13");
            if (stockSndRcvJnl1.UOESectionStock14 != stockSndRcvJnl2.UOESectionStock14) resList.Add("UOESectionStock14");
            if (stockSndRcvJnl1.UOESectionStock15 != stockSndRcvJnl2.UOESectionStock15) resList.Add("UOESectionStock15");
            if (stockSndRcvJnl1.UOESectionStock16 != stockSndRcvJnl2.UOESectionStock16) resList.Add("UOESectionStock16");
            if (stockSndRcvJnl1.UOESectionStock17 != stockSndRcvJnl2.UOESectionStock17) resList.Add("UOESectionStock17");
            if (stockSndRcvJnl1.UOESectionStock18 != stockSndRcvJnl2.UOESectionStock18) resList.Add("UOESectionStock18");
            if (stockSndRcvJnl1.UOESectionStock19 != stockSndRcvJnl2.UOESectionStock19) resList.Add("UOESectionStock19");
            if (stockSndRcvJnl1.UOESectionStock20 != stockSndRcvJnl2.UOESectionStock20) resList.Add("UOESectionStock20");
            if (stockSndRcvJnl1.UOESectionStock21 != stockSndRcvJnl2.UOESectionStock21) resList.Add("UOESectionStock21");
            if (stockSndRcvJnl1.UOESectionStock22 != stockSndRcvJnl2.UOESectionStock22) resList.Add("UOESectionStock22");
            if (stockSndRcvJnl1.UOESectionStock23 != stockSndRcvJnl2.UOESectionStock23) resList.Add("UOESectionStock23");
            if (stockSndRcvJnl1.UOESectionStock24 != stockSndRcvJnl2.UOESectionStock24) resList.Add("UOESectionStock24");
            if (stockSndRcvJnl1.UOESectionStock25 != stockSndRcvJnl2.UOESectionStock25) resList.Add("UOESectionStock25");
            if (stockSndRcvJnl1.UOESectionStock26 != stockSndRcvJnl2.UOESectionStock26) resList.Add("UOESectionStock26");
            if (stockSndRcvJnl1.UOESectionStock27 != stockSndRcvJnl2.UOESectionStock27) resList.Add("UOESectionStock27");
            if (stockSndRcvJnl1.UOESectionStock28 != stockSndRcvJnl2.UOESectionStock28) resList.Add("UOESectionStock28");
            if (stockSndRcvJnl1.UOESectionStock29 != stockSndRcvJnl2.UOESectionStock29) resList.Add("UOESectionStock29");
            if (stockSndRcvJnl1.UOESectionStock30 != stockSndRcvJnl2.UOESectionStock30) resList.Add("UOESectionStock30");
            if (stockSndRcvJnl1.UOESectionStock31 != stockSndRcvJnl2.UOESectionStock31) resList.Add("UOESectionStock31");
            if (stockSndRcvJnl1.UOESectionStock32 != stockSndRcvJnl2.UOESectionStock32) resList.Add("UOESectionStock32");
            if (stockSndRcvJnl1.UOESectionStock33 != stockSndRcvJnl2.UOESectionStock33) resList.Add("UOESectionStock33");
            if (stockSndRcvJnl1.UOESectionStock34 != stockSndRcvJnl2.UOESectionStock34) resList.Add("UOESectionStock34");
            if (stockSndRcvJnl1.UOESectionStock35 != stockSndRcvJnl2.UOESectionStock35) resList.Add("UOESectionStock35");
            if (stockSndRcvJnl1.HeadErrorMassage != stockSndRcvJnl2.HeadErrorMassage) resList.Add("HeadErrorMassage");
            if (stockSndRcvJnl1.LineErrorMassage != stockSndRcvJnl2.LineErrorMassage) resList.Add("LineErrorMassage");
            if (stockSndRcvJnl1.DataSendCode != stockSndRcvJnl2.DataSendCode) resList.Add("DataSendCode");
            if (stockSndRcvJnl1.DataRecoverDiv != stockSndRcvJnl2.DataRecoverDiv) resList.Add("DataRecoverDiv");
            if (stockSndRcvJnl1.EnterpriseName != stockSndRcvJnl2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockSndRcvJnl1.UpdEmployeeName != stockSndRcvJnl2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
