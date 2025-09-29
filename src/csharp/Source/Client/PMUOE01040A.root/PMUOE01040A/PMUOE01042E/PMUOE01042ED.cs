//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : UOE送受信ジャーナル(見積）クラス
// プログラム概要   : UOE送受信ジャーナル(見積）の定義
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
    /// public class name:   EstmtSndRcvJnl
    /// <summary>
    ///                      UOE送受信ジャーナル(見積）
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE送受信ジャーナル(見積）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class EstmtSndRcvJnl
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

        /// <summary>見積レート</summary>
        private string _estimateRate = "";

        /// <summary>選択コード</summary>
        private string _selectCode = "";

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

        /// <summary>回答定価</summary>
        private Double _answerListPrice;

        /// <summary>売上単価（税抜，浮動）</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>本部在庫</summary>
        private string _headQtrsStock = "";

        /// <summary>拠点在庫</summary>
        private string _branchStock = "";

        /// <summary>支店在庫</summary>
        private string _sectionStock = "";

        /// <summary>UOE拠点コード１</summary>
        private string _uOESectionCode1 = "";

        /// <summary>UOE拠点コード２</summary>
        private string _uOESectionCode2 = "";

        /// <summary>UOE拠点コード３</summary>
        private string _uOESectionCode3 = "";

        /// <summary>UOE拠点在庫数１</summary>
        private Int32 _uOESectionStock1;

        /// <summary>UOE拠点在庫数２</summary>
        private Int32 _uOESectionStock2;

        /// <summary>UOE拠点在庫数３</summary>
        private Int32 _uOESectionStock3;

        /// <summary>UOE納期コード</summary>
        private string _uOEDelivDateCd = "";

        /// <summary>UOE代替コード</summary>
        private string _uOESubstCode = "";

        /// <summary>UOE価格コード</summary>
        private string _uOEPriceCode = "";

        /// <summary>回答原価単価</summary>
        /// <remarks>仕切り価格</remarks>
        private Double _answerSalesUnitCost;

        /// <summary>層別コード</summary>
        private string _partsLayerCd = "";

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

        /// public propaty name  :  EstimateRate
        /// <summary>見積レートプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積レートプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstimateRate
        {
            get { return _estimateRate; }
            set { _estimateRate = value; }
        }

        /// public propaty name  :  SelectCode
        /// <summary>選択コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelectCode
        {
            get { return _selectCode; }
            set { _selectCode = value; }
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

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>売上単価（税抜，浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
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

        /// public propaty name  :  BranchStock
        /// <summary>拠点在庫プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点在庫プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BranchStock
        {
            get { return _branchStock; }
            set { _branchStock = value; }
        }

        /// public propaty name  :  SectionStock
        /// <summary>支店在庫プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   支店在庫プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionStock
        {
            get { return _sectionStock; }
            set { _sectionStock = value; }
        }

        /// public propaty name  :  UOESectionCode1
        /// <summary>UOE拠点コード１プロパティ</summary>
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

        /// public propaty name  :  UOEPriceCode
        /// <summary>UOE価格コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE価格コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEPriceCode
        {
            get { return _uOEPriceCode; }
            set { _uOEPriceCode = value; }
        }

        /// public propaty name  :  AnswerSalesUnitCost
        /// <summary>回答原価単価プロパティ</summary>
        /// <value>仕切り価格</value>
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
        /// UOE送受信ジャーナル(見積）コンストラクタ
        /// </summary>
        /// <returns>EstmtSndRcvJnlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstmtSndRcvJnlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EstmtSndRcvJnl()
        {
        }

        /// <summary>
        /// UOE送受信ジャーナル(見積）コンストラクタ
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
        /// <param name="estimateRate">見積レート</param>
        /// <param name="selectCode">選択コード</param>
        /// <param name="receiveDate">受信日付</param>
        /// <param name="receiveTime">受信時刻(HHMMSS)</param>
        /// <param name="answerMakerCd">回答メーカーコード</param>
        /// <param name="answerPartsNo">回答品番</param>
        /// <param name="answerPartsName">回答品名</param>
        /// <param name="substPartsNo">代替品番</param>
        /// <param name="answerListPrice">回答定価</param>
        /// <param name="salesUnPrcTaxExcFl">売上単価（税抜，浮動）</param>
        /// <param name="headQtrsStock">本部在庫</param>
        /// <param name="branchStock">拠点在庫</param>
        /// <param name="sectionStock">支店在庫</param>
        /// <param name="uOESectionCode1">UOE拠点コード１</param>
        /// <param name="uOESectionCode2">UOE拠点コード２</param>
        /// <param name="uOESectionCode3">UOE拠点コード３</param>
        /// <param name="uOESectionStock1">UOE拠点在庫数１</param>
        /// <param name="uOESectionStock2">UOE拠点在庫数２</param>
        /// <param name="uOESectionStock3">UOE拠点在庫数３</param>
        /// <param name="uOEDelivDateCd">UOE納期コード</param>
        /// <param name="uOESubstCode">UOE代替コード</param>
        /// <param name="uOEPriceCode">UOE価格コード</param>
        /// <param name="answerSalesUnitCost">回答原価単価(仕切り価格)</param>
        /// <param name="partsLayerCd">層別コード</param>
        /// <param name="headErrorMassage">ヘッドエラーメッセージ</param>
        /// <param name="lineErrorMassage">ラインエラーメッセージ</param>
        /// <param name="dataSendCode">データ送信区分(送信フラグ)</param>
        /// <param name="dataRecoverDiv">データ復旧区分(復旧処理フラグ)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>EstmtSndRcvJnlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstmtSndRcvJnlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EstmtSndRcvJnl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 systemDivCd, Int32 uOESalesOrderNo, Int32 uOESalesOrderRowNo, Int32 sendTerminalNo, Int32 uOESupplierCd, string uOESupplierName, string commAssemblyId, Int32 onlineNo, Int32 onlineRowNo, DateTime salesDate, DateTime inputDay, DateTime dataUpdateDateTime, Int32 uOEKind, string salesSlipNum, Int32 acptAnOdrStatus, Int64 salesSlipDtlNum, string sectionCode, Int32 subSectionCode, Int32 customerCode, string customerSnm, Int32 cashRegisterNo, Int64 commonSeqNo, Int32 supplierFormal, Int32 supplierSlipNo, Int64 stockSlipDtlNum, string boCode, string uOEDeliGoodsDiv, string deliveredGoodsDivNm, string followDeliGoodsDiv, string followDeliGoodsDivNm, string uOEResvdSection, string uOEResvdSectionNm, string employeeCode, string employeeName, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsNoNoneHyphen, string goodsName, string warehouseCode, string warehouseName, string warehouseShelfNo, Double acceptAnOrderCnt, Double listPrice, Double salesUnitCost, Int32 supplierCd, string supplierSnm, string uoeRemark1, string uoeRemark2, string estimateRate, string selectCode, DateTime receiveDate, Int32 receiveTime, Int32 answerMakerCd, string answerPartsNo, string answerPartsName, string substPartsNo, Double answerListPrice, Double salesUnPrcTaxExcFl, string headQtrsStock, string branchStock, string sectionStock, string uOESectionCode1, string uOESectionCode2, string uOESectionCode3, Int32 uOESectionStock1, Int32 uOESectionStock2, Int32 uOESectionStock3, string uOEDelivDateCd, string uOESubstCode, string uOEPriceCode, Double answerSalesUnitCost, string partsLayerCd, string headErrorMassage, string lineErrorMassage, Int32 dataSendCode, Int32 dataRecoverDiv, string enterpriseName, string updEmployeeName)
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
            this._estimateRate = estimateRate;
            this._selectCode = selectCode;
            this.ReceiveDate = receiveDate;
            this._receiveTime = receiveTime;
            this._answerMakerCd = answerMakerCd;
            this._answerPartsNo = answerPartsNo;
            this._answerPartsName = answerPartsName;
            this._substPartsNo = substPartsNo;
            this._answerListPrice = answerListPrice;
            this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            this._headQtrsStock = headQtrsStock;
            this._branchStock = branchStock;
            this._sectionStock = sectionStock;
            this._uOESectionCode1 = uOESectionCode1;
            this._uOESectionCode2 = uOESectionCode2;
            this._uOESectionCode3 = uOESectionCode3;
            this._uOESectionStock1 = uOESectionStock1;
            this._uOESectionStock2 = uOESectionStock2;
            this._uOESectionStock3 = uOESectionStock3;
            this._uOEDelivDateCd = uOEDelivDateCd;
            this._uOESubstCode = uOESubstCode;
            this._uOEPriceCode = uOEPriceCode;
            this._answerSalesUnitCost = answerSalesUnitCost;
            this._partsLayerCd = partsLayerCd;
            this._headErrorMassage = headErrorMassage;
            this._lineErrorMassage = lineErrorMassage;
            this._dataSendCode = dataSendCode;
            this._dataRecoverDiv = dataRecoverDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// UOE送受信ジャーナル(見積）複製処理
        /// </summary>
        /// <returns>EstmtSndRcvJnlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいEstmtSndRcvJnlクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EstmtSndRcvJnl Clone()
        {
            return new EstmtSndRcvJnl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._systemDivCd, this._uOESalesOrderNo, this._uOESalesOrderRowNo, this._sendTerminalNo, this._uOESupplierCd, this._uOESupplierName, this._commAssemblyId, this._onlineNo, this._onlineRowNo, this._salesDate, this._inputDay, this._dataUpdateDateTime, this._uOEKind, this._salesSlipNum, this._acptAnOdrStatus, this._salesSlipDtlNum, this._sectionCode, this._subSectionCode, this._customerCode, this._customerSnm, this._cashRegisterNo, this._commonSeqNo, this._supplierFormal, this._supplierSlipNo, this._stockSlipDtlNum, this._boCode, this._uOEDeliGoodsDiv, this._deliveredGoodsDivNm, this._followDeliGoodsDiv, this._followDeliGoodsDivNm, this._uOEResvdSection, this._uOEResvdSectionNm, this._employeeCode, this._employeeName, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoNoneHyphen, this._goodsName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._acceptAnOrderCnt, this._listPrice, this._salesUnitCost, this._supplierCd, this._supplierSnm, this._uoeRemark1, this._uoeRemark2, this._estimateRate, this._selectCode, this._receiveDate, this._receiveTime, this._answerMakerCd, this._answerPartsNo, this._answerPartsName, this._substPartsNo, this._answerListPrice, this._salesUnPrcTaxExcFl, this._headQtrsStock, this._branchStock, this._sectionStock, this._uOESectionCode1, this._uOESectionCode2, this._uOESectionCode3, this._uOESectionStock1, this._uOESectionStock2, this._uOESectionStock3, this._uOEDelivDateCd, this._uOESubstCode, this._uOEPriceCode, this._answerSalesUnitCost, this._partsLayerCd, this._headErrorMassage, this._lineErrorMassage, this._dataSendCode, this._dataRecoverDiv, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// UOE送受信ジャーナル(見積）比較処理
        /// </summary>
        /// <param name="target">比較対象のEstmtSndRcvJnlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstmtSndRcvJnlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(EstmtSndRcvJnl target)
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
                 && (this.EstimateRate == target.EstimateRate)
                 && (this.SelectCode == target.SelectCode)
                 && (this.ReceiveDate == target.ReceiveDate)
                 && (this.ReceiveTime == target.ReceiveTime)
                 && (this.AnswerMakerCd == target.AnswerMakerCd)
                 && (this.AnswerPartsNo == target.AnswerPartsNo)
                 && (this.AnswerPartsName == target.AnswerPartsName)
                 && (this.SubstPartsNo == target.SubstPartsNo)
                 && (this.AnswerListPrice == target.AnswerListPrice)
                 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
                 && (this.HeadQtrsStock == target.HeadQtrsStock)
                 && (this.BranchStock == target.BranchStock)
                 && (this.SectionStock == target.SectionStock)
                 && (this.UOESectionCode1 == target.UOESectionCode1)
                 && (this.UOESectionCode2 == target.UOESectionCode2)
                 && (this.UOESectionCode3 == target.UOESectionCode3)
                 && (this.UOESectionStock1 == target.UOESectionStock1)
                 && (this.UOESectionStock2 == target.UOESectionStock2)
                 && (this.UOESectionStock3 == target.UOESectionStock3)
                 && (this.UOEDelivDateCd == target.UOEDelivDateCd)
                 && (this.UOESubstCode == target.UOESubstCode)
                 && (this.UOEPriceCode == target.UOEPriceCode)
                 && (this.AnswerSalesUnitCost == target.AnswerSalesUnitCost)
                 && (this.PartsLayerCd == target.PartsLayerCd)
                 && (this.HeadErrorMassage == target.HeadErrorMassage)
                 && (this.LineErrorMassage == target.LineErrorMassage)
                 && (this.DataSendCode == target.DataSendCode)
                 && (this.DataRecoverDiv == target.DataRecoverDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// UOE送受信ジャーナル(見積）比較処理
        /// </summary>
        /// <param name="estmtSndRcvJnl1">
        ///                    比較するEstmtSndRcvJnlクラスのインスタンス
        /// </param>
        /// <param name="estmtSndRcvJnl2">比較するEstmtSndRcvJnlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstmtSndRcvJnlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(EstmtSndRcvJnl estmtSndRcvJnl1, EstmtSndRcvJnl estmtSndRcvJnl2)
        {
            return ((estmtSndRcvJnl1.CreateDateTime == estmtSndRcvJnl2.CreateDateTime)
                 && (estmtSndRcvJnl1.UpdateDateTime == estmtSndRcvJnl2.UpdateDateTime)
                 && (estmtSndRcvJnl1.EnterpriseCode == estmtSndRcvJnl2.EnterpriseCode)
                 && (estmtSndRcvJnl1.FileHeaderGuid == estmtSndRcvJnl2.FileHeaderGuid)
                 && (estmtSndRcvJnl1.UpdEmployeeCode == estmtSndRcvJnl2.UpdEmployeeCode)
                 && (estmtSndRcvJnl1.UpdAssemblyId1 == estmtSndRcvJnl2.UpdAssemblyId1)
                 && (estmtSndRcvJnl1.UpdAssemblyId2 == estmtSndRcvJnl2.UpdAssemblyId2)
                 && (estmtSndRcvJnl1.LogicalDeleteCode == estmtSndRcvJnl2.LogicalDeleteCode)
                 && (estmtSndRcvJnl1.SystemDivCd == estmtSndRcvJnl2.SystemDivCd)
                 && (estmtSndRcvJnl1.UOESalesOrderNo == estmtSndRcvJnl2.UOESalesOrderNo)
                 && (estmtSndRcvJnl1.UOESalesOrderRowNo == estmtSndRcvJnl2.UOESalesOrderRowNo)
                 && (estmtSndRcvJnl1.SendTerminalNo == estmtSndRcvJnl2.SendTerminalNo)
                 && (estmtSndRcvJnl1.UOESupplierCd == estmtSndRcvJnl2.UOESupplierCd)
                 && (estmtSndRcvJnl1.UOESupplierName == estmtSndRcvJnl2.UOESupplierName)
                 && (estmtSndRcvJnl1.CommAssemblyId == estmtSndRcvJnl2.CommAssemblyId)
                 && (estmtSndRcvJnl1.OnlineNo == estmtSndRcvJnl2.OnlineNo)
                 && (estmtSndRcvJnl1.OnlineRowNo == estmtSndRcvJnl2.OnlineRowNo)
                 && (estmtSndRcvJnl1.SalesDate == estmtSndRcvJnl2.SalesDate)
                 && (estmtSndRcvJnl1.InputDay == estmtSndRcvJnl2.InputDay)
                 && (estmtSndRcvJnl1.DataUpdateDateTime == estmtSndRcvJnl2.DataUpdateDateTime)
                 && (estmtSndRcvJnl1.UOEKind == estmtSndRcvJnl2.UOEKind)
                 && (estmtSndRcvJnl1.SalesSlipNum == estmtSndRcvJnl2.SalesSlipNum)
                 && (estmtSndRcvJnl1.AcptAnOdrStatus == estmtSndRcvJnl2.AcptAnOdrStatus)
                 && (estmtSndRcvJnl1.SalesSlipDtlNum == estmtSndRcvJnl2.SalesSlipDtlNum)
                 && (estmtSndRcvJnl1.SectionCode == estmtSndRcvJnl2.SectionCode)
                 && (estmtSndRcvJnl1.SubSectionCode == estmtSndRcvJnl2.SubSectionCode)
                 && (estmtSndRcvJnl1.CustomerCode == estmtSndRcvJnl2.CustomerCode)
                 && (estmtSndRcvJnl1.CustomerSnm == estmtSndRcvJnl2.CustomerSnm)
                 && (estmtSndRcvJnl1.CashRegisterNo == estmtSndRcvJnl2.CashRegisterNo)
                 && (estmtSndRcvJnl1.CommonSeqNo == estmtSndRcvJnl2.CommonSeqNo)
                 && (estmtSndRcvJnl1.SupplierFormal == estmtSndRcvJnl2.SupplierFormal)
                 && (estmtSndRcvJnl1.SupplierSlipNo == estmtSndRcvJnl2.SupplierSlipNo)
                 && (estmtSndRcvJnl1.StockSlipDtlNum == estmtSndRcvJnl2.StockSlipDtlNum)
                 && (estmtSndRcvJnl1.BoCode == estmtSndRcvJnl2.BoCode)
                 && (estmtSndRcvJnl1.UOEDeliGoodsDiv == estmtSndRcvJnl2.UOEDeliGoodsDiv)
                 && (estmtSndRcvJnl1.DeliveredGoodsDivNm == estmtSndRcvJnl2.DeliveredGoodsDivNm)
                 && (estmtSndRcvJnl1.FollowDeliGoodsDiv == estmtSndRcvJnl2.FollowDeliGoodsDiv)
                 && (estmtSndRcvJnl1.FollowDeliGoodsDivNm == estmtSndRcvJnl2.FollowDeliGoodsDivNm)
                 && (estmtSndRcvJnl1.UOEResvdSection == estmtSndRcvJnl2.UOEResvdSection)
                 && (estmtSndRcvJnl1.UOEResvdSectionNm == estmtSndRcvJnl2.UOEResvdSectionNm)
                 && (estmtSndRcvJnl1.EmployeeCode == estmtSndRcvJnl2.EmployeeCode)
                 && (estmtSndRcvJnl1.EmployeeName == estmtSndRcvJnl2.EmployeeName)
                 && (estmtSndRcvJnl1.GoodsMakerCd == estmtSndRcvJnl2.GoodsMakerCd)
                 && (estmtSndRcvJnl1.MakerName == estmtSndRcvJnl2.MakerName)
                 && (estmtSndRcvJnl1.GoodsNo == estmtSndRcvJnl2.GoodsNo)
                 && (estmtSndRcvJnl1.GoodsNoNoneHyphen == estmtSndRcvJnl2.GoodsNoNoneHyphen)
                 && (estmtSndRcvJnl1.GoodsName == estmtSndRcvJnl2.GoodsName)
                 && (estmtSndRcvJnl1.WarehouseCode == estmtSndRcvJnl2.WarehouseCode)
                 && (estmtSndRcvJnl1.WarehouseName == estmtSndRcvJnl2.WarehouseName)
                 && (estmtSndRcvJnl1.WarehouseShelfNo == estmtSndRcvJnl2.WarehouseShelfNo)
                 && (estmtSndRcvJnl1.AcceptAnOrderCnt == estmtSndRcvJnl2.AcceptAnOrderCnt)
                 && (estmtSndRcvJnl1.ListPrice == estmtSndRcvJnl2.ListPrice)
                 && (estmtSndRcvJnl1.SalesUnitCost == estmtSndRcvJnl2.SalesUnitCost)
                 && (estmtSndRcvJnl1.SupplierCd == estmtSndRcvJnl2.SupplierCd)
                 && (estmtSndRcvJnl1.SupplierSnm == estmtSndRcvJnl2.SupplierSnm)
                 && (estmtSndRcvJnl1.UoeRemark1 == estmtSndRcvJnl2.UoeRemark1)
                 && (estmtSndRcvJnl1.UoeRemark2 == estmtSndRcvJnl2.UoeRemark2)
                 && (estmtSndRcvJnl1.EstimateRate == estmtSndRcvJnl2.EstimateRate)
                 && (estmtSndRcvJnl1.SelectCode == estmtSndRcvJnl2.SelectCode)
                 && (estmtSndRcvJnl1.ReceiveDate == estmtSndRcvJnl2.ReceiveDate)
                 && (estmtSndRcvJnl1.ReceiveTime == estmtSndRcvJnl2.ReceiveTime)
                 && (estmtSndRcvJnl1.AnswerMakerCd == estmtSndRcvJnl2.AnswerMakerCd)
                 && (estmtSndRcvJnl1.AnswerPartsNo == estmtSndRcvJnl2.AnswerPartsNo)
                 && (estmtSndRcvJnl1.AnswerPartsName == estmtSndRcvJnl2.AnswerPartsName)
                 && (estmtSndRcvJnl1.SubstPartsNo == estmtSndRcvJnl2.SubstPartsNo)
                 && (estmtSndRcvJnl1.AnswerListPrice == estmtSndRcvJnl2.AnswerListPrice)
                 && (estmtSndRcvJnl1.SalesUnPrcTaxExcFl == estmtSndRcvJnl2.SalesUnPrcTaxExcFl)
                 && (estmtSndRcvJnl1.HeadQtrsStock == estmtSndRcvJnl2.HeadQtrsStock)
                 && (estmtSndRcvJnl1.BranchStock == estmtSndRcvJnl2.BranchStock)
                 && (estmtSndRcvJnl1.SectionStock == estmtSndRcvJnl2.SectionStock)
                 && (estmtSndRcvJnl1.UOESectionCode1 == estmtSndRcvJnl2.UOESectionCode1)
                 && (estmtSndRcvJnl1.UOESectionCode2 == estmtSndRcvJnl2.UOESectionCode2)
                 && (estmtSndRcvJnl1.UOESectionCode3 == estmtSndRcvJnl2.UOESectionCode3)
                 && (estmtSndRcvJnl1.UOESectionStock1 == estmtSndRcvJnl2.UOESectionStock1)
                 && (estmtSndRcvJnl1.UOESectionStock2 == estmtSndRcvJnl2.UOESectionStock2)
                 && (estmtSndRcvJnl1.UOESectionStock3 == estmtSndRcvJnl2.UOESectionStock3)
                 && (estmtSndRcvJnl1.UOEDelivDateCd == estmtSndRcvJnl2.UOEDelivDateCd)
                 && (estmtSndRcvJnl1.UOESubstCode == estmtSndRcvJnl2.UOESubstCode)
                 && (estmtSndRcvJnl1.UOEPriceCode == estmtSndRcvJnl2.UOEPriceCode)
                 && (estmtSndRcvJnl1.AnswerSalesUnitCost == estmtSndRcvJnl2.AnswerSalesUnitCost)
                 && (estmtSndRcvJnl1.PartsLayerCd == estmtSndRcvJnl2.PartsLayerCd)
                 && (estmtSndRcvJnl1.HeadErrorMassage == estmtSndRcvJnl2.HeadErrorMassage)
                 && (estmtSndRcvJnl1.LineErrorMassage == estmtSndRcvJnl2.LineErrorMassage)
                 && (estmtSndRcvJnl1.DataSendCode == estmtSndRcvJnl2.DataSendCode)
                 && (estmtSndRcvJnl1.DataRecoverDiv == estmtSndRcvJnl2.DataRecoverDiv)
                 && (estmtSndRcvJnl1.EnterpriseName == estmtSndRcvJnl2.EnterpriseName)
                 && (estmtSndRcvJnl1.UpdEmployeeName == estmtSndRcvJnl2.UpdEmployeeName));
        }
        /// <summary>
        /// UOE送受信ジャーナル(見積）比較処理
        /// </summary>
        /// <param name="target">比較対象のEstmtSndRcvJnlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstmtSndRcvJnlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(EstmtSndRcvJnl target)
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
            if (this.EstimateRate != target.EstimateRate) resList.Add("EstimateRate");
            if (this.SelectCode != target.SelectCode) resList.Add("SelectCode");
            if (this.ReceiveDate != target.ReceiveDate) resList.Add("ReceiveDate");
            if (this.ReceiveTime != target.ReceiveTime) resList.Add("ReceiveTime");
            if (this.AnswerMakerCd != target.AnswerMakerCd) resList.Add("AnswerMakerCd");
            if (this.AnswerPartsNo != target.AnswerPartsNo) resList.Add("AnswerPartsNo");
            if (this.AnswerPartsName != target.AnswerPartsName) resList.Add("AnswerPartsName");
            if (this.SubstPartsNo != target.SubstPartsNo) resList.Add("SubstPartsNo");
            if (this.AnswerListPrice != target.AnswerListPrice) resList.Add("AnswerListPrice");
            if (this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (this.HeadQtrsStock != target.HeadQtrsStock) resList.Add("HeadQtrsStock");
            if (this.BranchStock != target.BranchStock) resList.Add("BranchStock");
            if (this.SectionStock != target.SectionStock) resList.Add("SectionStock");
            if (this.UOESectionCode1 != target.UOESectionCode1) resList.Add("UOESectionCode1");
            if (this.UOESectionCode2 != target.UOESectionCode2) resList.Add("UOESectionCode2");
            if (this.UOESectionCode3 != target.UOESectionCode3) resList.Add("UOESectionCode3");
            if (this.UOESectionStock1 != target.UOESectionStock1) resList.Add("UOESectionStock1");
            if (this.UOESectionStock2 != target.UOESectionStock2) resList.Add("UOESectionStock2");
            if (this.UOESectionStock3 != target.UOESectionStock3) resList.Add("UOESectionStock3");
            if (this.UOEDelivDateCd != target.UOEDelivDateCd) resList.Add("UOEDelivDateCd");
            if (this.UOESubstCode != target.UOESubstCode) resList.Add("UOESubstCode");
            if (this.UOEPriceCode != target.UOEPriceCode) resList.Add("UOEPriceCode");
            if (this.AnswerSalesUnitCost != target.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");
            if (this.PartsLayerCd != target.PartsLayerCd) resList.Add("PartsLayerCd");
            if (this.HeadErrorMassage != target.HeadErrorMassage) resList.Add("HeadErrorMassage");
            if (this.LineErrorMassage != target.LineErrorMassage) resList.Add("LineErrorMassage");
            if (this.DataSendCode != target.DataSendCode) resList.Add("DataSendCode");
            if (this.DataRecoverDiv != target.DataRecoverDiv) resList.Add("DataRecoverDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// UOE送受信ジャーナル(見積）比較処理
        /// </summary>
        /// <param name="estmtSndRcvJnl1">比較するEstmtSndRcvJnlクラスのインスタンス</param>
        /// <param name="estmtSndRcvJnl2">比較するEstmtSndRcvJnlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EstmtSndRcvJnlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(EstmtSndRcvJnl estmtSndRcvJnl1, EstmtSndRcvJnl estmtSndRcvJnl2)
        {
            ArrayList resList = new ArrayList();
            if (estmtSndRcvJnl1.CreateDateTime != estmtSndRcvJnl2.CreateDateTime) resList.Add("CreateDateTime");
            if (estmtSndRcvJnl1.UpdateDateTime != estmtSndRcvJnl2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (estmtSndRcvJnl1.EnterpriseCode != estmtSndRcvJnl2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (estmtSndRcvJnl1.FileHeaderGuid != estmtSndRcvJnl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (estmtSndRcvJnl1.UpdEmployeeCode != estmtSndRcvJnl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (estmtSndRcvJnl1.UpdAssemblyId1 != estmtSndRcvJnl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (estmtSndRcvJnl1.UpdAssemblyId2 != estmtSndRcvJnl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (estmtSndRcvJnl1.LogicalDeleteCode != estmtSndRcvJnl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (estmtSndRcvJnl1.SystemDivCd != estmtSndRcvJnl2.SystemDivCd) resList.Add("SystemDivCd");
            if (estmtSndRcvJnl1.UOESalesOrderNo != estmtSndRcvJnl2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (estmtSndRcvJnl1.UOESalesOrderRowNo != estmtSndRcvJnl2.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");
            if (estmtSndRcvJnl1.SendTerminalNo != estmtSndRcvJnl2.SendTerminalNo) resList.Add("SendTerminalNo");
            if (estmtSndRcvJnl1.UOESupplierCd != estmtSndRcvJnl2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (estmtSndRcvJnl1.UOESupplierName != estmtSndRcvJnl2.UOESupplierName) resList.Add("UOESupplierName");
            if (estmtSndRcvJnl1.CommAssemblyId != estmtSndRcvJnl2.CommAssemblyId) resList.Add("CommAssemblyId");
            if (estmtSndRcvJnl1.OnlineNo != estmtSndRcvJnl2.OnlineNo) resList.Add("OnlineNo");
            if (estmtSndRcvJnl1.OnlineRowNo != estmtSndRcvJnl2.OnlineRowNo) resList.Add("OnlineRowNo");
            if (estmtSndRcvJnl1.SalesDate != estmtSndRcvJnl2.SalesDate) resList.Add("SalesDate");
            if (estmtSndRcvJnl1.InputDay != estmtSndRcvJnl2.InputDay) resList.Add("InputDay");
            if (estmtSndRcvJnl1.DataUpdateDateTime != estmtSndRcvJnl2.DataUpdateDateTime) resList.Add("DataUpdateDateTime");
            if (estmtSndRcvJnl1.UOEKind != estmtSndRcvJnl2.UOEKind) resList.Add("UOEKind");
            if (estmtSndRcvJnl1.SalesSlipNum != estmtSndRcvJnl2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (estmtSndRcvJnl1.AcptAnOdrStatus != estmtSndRcvJnl2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (estmtSndRcvJnl1.SalesSlipDtlNum != estmtSndRcvJnl2.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (estmtSndRcvJnl1.SectionCode != estmtSndRcvJnl2.SectionCode) resList.Add("SectionCode");
            if (estmtSndRcvJnl1.SubSectionCode != estmtSndRcvJnl2.SubSectionCode) resList.Add("SubSectionCode");
            if (estmtSndRcvJnl1.CustomerCode != estmtSndRcvJnl2.CustomerCode) resList.Add("CustomerCode");
            if (estmtSndRcvJnl1.CustomerSnm != estmtSndRcvJnl2.CustomerSnm) resList.Add("CustomerSnm");
            if (estmtSndRcvJnl1.CashRegisterNo != estmtSndRcvJnl2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (estmtSndRcvJnl1.CommonSeqNo != estmtSndRcvJnl2.CommonSeqNo) resList.Add("CommonSeqNo");
            if (estmtSndRcvJnl1.SupplierFormal != estmtSndRcvJnl2.SupplierFormal) resList.Add("SupplierFormal");
            if (estmtSndRcvJnl1.SupplierSlipNo != estmtSndRcvJnl2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (estmtSndRcvJnl1.StockSlipDtlNum != estmtSndRcvJnl2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (estmtSndRcvJnl1.BoCode != estmtSndRcvJnl2.BoCode) resList.Add("BoCode");
            if (estmtSndRcvJnl1.UOEDeliGoodsDiv != estmtSndRcvJnl2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (estmtSndRcvJnl1.DeliveredGoodsDivNm != estmtSndRcvJnl2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (estmtSndRcvJnl1.FollowDeliGoodsDiv != estmtSndRcvJnl2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (estmtSndRcvJnl1.FollowDeliGoodsDivNm != estmtSndRcvJnl2.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (estmtSndRcvJnl1.UOEResvdSection != estmtSndRcvJnl2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (estmtSndRcvJnl1.UOEResvdSectionNm != estmtSndRcvJnl2.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (estmtSndRcvJnl1.EmployeeCode != estmtSndRcvJnl2.EmployeeCode) resList.Add("EmployeeCode");
            if (estmtSndRcvJnl1.EmployeeName != estmtSndRcvJnl2.EmployeeName) resList.Add("EmployeeName");
            if (estmtSndRcvJnl1.GoodsMakerCd != estmtSndRcvJnl2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (estmtSndRcvJnl1.MakerName != estmtSndRcvJnl2.MakerName) resList.Add("MakerName");
            if (estmtSndRcvJnl1.GoodsNo != estmtSndRcvJnl2.GoodsNo) resList.Add("GoodsNo");
            if (estmtSndRcvJnl1.GoodsNoNoneHyphen != estmtSndRcvJnl2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (estmtSndRcvJnl1.GoodsName != estmtSndRcvJnl2.GoodsName) resList.Add("GoodsName");
            if (estmtSndRcvJnl1.WarehouseCode != estmtSndRcvJnl2.WarehouseCode) resList.Add("WarehouseCode");
            if (estmtSndRcvJnl1.WarehouseName != estmtSndRcvJnl2.WarehouseName) resList.Add("WarehouseName");
            if (estmtSndRcvJnl1.WarehouseShelfNo != estmtSndRcvJnl2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (estmtSndRcvJnl1.AcceptAnOrderCnt != estmtSndRcvJnl2.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (estmtSndRcvJnl1.ListPrice != estmtSndRcvJnl2.ListPrice) resList.Add("ListPrice");
            if (estmtSndRcvJnl1.SalesUnitCost != estmtSndRcvJnl2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (estmtSndRcvJnl1.SupplierCd != estmtSndRcvJnl2.SupplierCd) resList.Add("SupplierCd");
            if (estmtSndRcvJnl1.SupplierSnm != estmtSndRcvJnl2.SupplierSnm) resList.Add("SupplierSnm");
            if (estmtSndRcvJnl1.UoeRemark1 != estmtSndRcvJnl2.UoeRemark1) resList.Add("UoeRemark1");
            if (estmtSndRcvJnl1.UoeRemark2 != estmtSndRcvJnl2.UoeRemark2) resList.Add("UoeRemark2");
            if (estmtSndRcvJnl1.EstimateRate != estmtSndRcvJnl2.EstimateRate) resList.Add("EstimateRate");
            if (estmtSndRcvJnl1.SelectCode != estmtSndRcvJnl2.SelectCode) resList.Add("SelectCode");
            if (estmtSndRcvJnl1.ReceiveDate != estmtSndRcvJnl2.ReceiveDate) resList.Add("ReceiveDate");
            if (estmtSndRcvJnl1.ReceiveTime != estmtSndRcvJnl2.ReceiveTime) resList.Add("ReceiveTime");
            if (estmtSndRcvJnl1.AnswerMakerCd != estmtSndRcvJnl2.AnswerMakerCd) resList.Add("AnswerMakerCd");
            if (estmtSndRcvJnl1.AnswerPartsNo != estmtSndRcvJnl2.AnswerPartsNo) resList.Add("AnswerPartsNo");
            if (estmtSndRcvJnl1.AnswerPartsName != estmtSndRcvJnl2.AnswerPartsName) resList.Add("AnswerPartsName");
            if (estmtSndRcvJnl1.SubstPartsNo != estmtSndRcvJnl2.SubstPartsNo) resList.Add("SubstPartsNo");
            if (estmtSndRcvJnl1.AnswerListPrice != estmtSndRcvJnl2.AnswerListPrice) resList.Add("AnswerListPrice");
            if (estmtSndRcvJnl1.SalesUnPrcTaxExcFl != estmtSndRcvJnl2.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (estmtSndRcvJnl1.HeadQtrsStock != estmtSndRcvJnl2.HeadQtrsStock) resList.Add("HeadQtrsStock");
            if (estmtSndRcvJnl1.BranchStock != estmtSndRcvJnl2.BranchStock) resList.Add("BranchStock");
            if (estmtSndRcvJnl1.SectionStock != estmtSndRcvJnl2.SectionStock) resList.Add("SectionStock");
            if (estmtSndRcvJnl1.UOESectionCode1 != estmtSndRcvJnl2.UOESectionCode1) resList.Add("UOESectionCode1");
            if (estmtSndRcvJnl1.UOESectionCode2 != estmtSndRcvJnl2.UOESectionCode2) resList.Add("UOESectionCode2");
            if (estmtSndRcvJnl1.UOESectionCode3 != estmtSndRcvJnl2.UOESectionCode3) resList.Add("UOESectionCode3");
            if (estmtSndRcvJnl1.UOESectionStock1 != estmtSndRcvJnl2.UOESectionStock1) resList.Add("UOESectionStock1");
            if (estmtSndRcvJnl1.UOESectionStock2 != estmtSndRcvJnl2.UOESectionStock2) resList.Add("UOESectionStock2");
            if (estmtSndRcvJnl1.UOESectionStock3 != estmtSndRcvJnl2.UOESectionStock3) resList.Add("UOESectionStock3");
            if (estmtSndRcvJnl1.UOEDelivDateCd != estmtSndRcvJnl2.UOEDelivDateCd) resList.Add("UOEDelivDateCd");
            if (estmtSndRcvJnl1.UOESubstCode != estmtSndRcvJnl2.UOESubstCode) resList.Add("UOESubstCode");
            if (estmtSndRcvJnl1.UOEPriceCode != estmtSndRcvJnl2.UOEPriceCode) resList.Add("UOEPriceCode");
            if (estmtSndRcvJnl1.AnswerSalesUnitCost != estmtSndRcvJnl2.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");
            if (estmtSndRcvJnl1.PartsLayerCd != estmtSndRcvJnl2.PartsLayerCd) resList.Add("PartsLayerCd");
            if (estmtSndRcvJnl1.HeadErrorMassage != estmtSndRcvJnl2.HeadErrorMassage) resList.Add("HeadErrorMassage");
            if (estmtSndRcvJnl1.LineErrorMassage != estmtSndRcvJnl2.LineErrorMassage) resList.Add("LineErrorMassage");
            if (estmtSndRcvJnl1.DataSendCode != estmtSndRcvJnl2.DataSendCode) resList.Add("DataSendCode");
            if (estmtSndRcvJnl1.DataRecoverDiv != estmtSndRcvJnl2.DataRecoverDiv) resList.Add("DataRecoverDiv");
            if (estmtSndRcvJnl1.EnterpriseName != estmtSndRcvJnl2.EnterpriseName) resList.Add("EnterpriseName");
            if (estmtSndRcvJnl1.UpdEmployeeName != estmtSndRcvJnl2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
