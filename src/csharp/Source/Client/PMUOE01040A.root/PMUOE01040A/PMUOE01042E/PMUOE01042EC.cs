//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : UOE送受信ジャーナル（発注）クラス
// プログラム概要   : UOE送受信ジャーナル（発注）の定義
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
    /// public class name:   OrderSndRcvJnl
    /// <summary>
    ///                      UOE送受信ジャーナル（発注）
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE送受信ジャーナル（発注）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class OrderSndRcvJnl
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

        /// <summary>UOE拠点出庫数</summary>
        private Int32 _uOESectOutGoodsCnt;

        /// <summary>BO出庫数1</summary>
        /// <remarks>サブ本部フォロー数</remarks>
        private Int32 _bOShipmentCnt1;

        /// <summary>BO出庫数2</summary>
        /// <remarks>本部フォロー数</remarks>
        private Int32 _bOShipmentCnt2;

        /// <summary>BO出庫数3</summary>
        /// <remarks>ルートフォロー数</remarks>
        private Int32 _bOShipmentCnt3;

        /// <summary>メーカーフォロー数</summary>
        private Int32 _makerFollowCnt;

        /// <summary>未出庫数</summary>
        private Int32 _nonShipmentCnt;

        /// <summary>UOE拠点在庫数</summary>
        private Int32 _uOESectStockCnt;

        /// <summary>BO在庫数1</summary>
        /// <remarks>サブ本部在庫</remarks>
        private Int32 _bOStockCount1;

        /// <summary>BO在庫数2</summary>
        /// <remarks>本部在庫</remarks>
        private Int32 _bOStockCount2;

        /// <summary>BO在庫数3</summary>
        /// <remarks>ルート在庫</remarks>
        private Int32 _bOStockCount3;

        /// <summary>UOE拠点伝票番号</summary>
        private string _uOESectionSlipNo = "";

        /// <summary>BO伝票番号１</summary>
        /// <remarks>サブ本部フォロー伝票№</remarks>
        private string _bOSlipNo1 = "";

        /// <summary>BO伝票番号２</summary>
        /// <remarks>本部フォロー伝票№</remarks>
        private string _bOSlipNo2 = "";

        /// <summary>BO伝票番号３</summary>
        /// <remarks>ルートフォロー伝票№</remarks>
        private string _bOSlipNo3 = "";

        /// <summary>EO引当数</summary>
        private Int32 _eOAlwcCount;

        /// <summary>BO管理番号</summary>
        private string _bOManagementNo = "";

        /// <summary>回答定価</summary>
        private Double _answerListPrice;

        /// <summary>回答原価単価</summary>
        private Double _answerSalesUnitCost;

        /// <summary>UOE代替マーク</summary>
        private string _uOESubstMark = "";

        /// <summary>UOE在庫マーク</summary>
        private string _uOEStockMark = "";

        /// <summary>層別コード</summary>
        private string _partsLayerCd = "";

        /// <summary>UOE出荷拠点コード１（マツダ）</summary>
        private string _mazdaUOEShipSectCd1 = "";

        /// <summary>UOE出荷拠点コード２（マツダ）</summary>
        private string _mazdaUOEShipSectCd2 = "";

        /// <summary>UOE出荷拠点コード３（マツダ）</summary>
        private string _mazdaUOEShipSectCd3 = "";

        /// <summary>UOE拠点コード１（マツダ）</summary>
        private string _mazdaUOESectCd1 = "";

        /// <summary>UOE拠点コード２（マツダ）</summary>
        private string _mazdaUOESectCd2 = "";

        /// <summary>UOE拠点コード３（マツダ）</summary>
        private string _mazdaUOESectCd3 = "";

        /// <summary>UOE拠点コード４（マツダ）</summary>
        private string _mazdaUOESectCd4 = "";

        /// <summary>UOE拠点コード５（マツダ）</summary>
        private string _mazdaUOESectCd5 = "";

        /// <summary>UOE拠点コード６（マツダ）</summary>
        private string _mazdaUOESectCd6 = "";

        /// <summary>UOE拠点コード７（マツダ）</summary>
        private string _mazdaUOESectCd7 = "";

        /// <summary>UOE在庫数１（マツダ）</summary>
        private Int32 _mazdaUOEStockCnt1;

        /// <summary>UOE在庫数２（マツダ）</summary>
        private Int32 _mazdaUOEStockCnt2;

        /// <summary>UOE在庫数３（マツダ）</summary>
        private Int32 _mazdaUOEStockCnt3;

        /// <summary>UOE在庫数４（マツダ）</summary>
        private Int32 _mazdaUOEStockCnt4;

        /// <summary>UOE在庫数５（マツダ）</summary>
        private Int32 _mazdaUOEStockCnt5;

        /// <summary>UOE在庫数６（マツダ）</summary>
        private Int32 _mazdaUOEStockCnt6;

        /// <summary>UOE在庫数７（マツダ）</summary>
        private Int32 _mazdaUOEStockCnt7;

        /// <summary>UOE卸コード</summary>
        private string _uOEDistributionCd = "";

        /// <summary>UOE他コード</summary>
        private string _uOEOtherCd = "";

        /// <summary>UOEＨＭコード</summary>
        private string _uOEHMCd = "";

        /// <summary>ＢＯ数</summary>
        private Int32 _bOCount;

        /// <summary>UOEマークコード</summary>
        private string _uOEMarkCode = "";

        /// <summary>出荷元</summary>
        private string _sourceShipment = "";

        /// <summary>アイテムコード</summary>
        private string _itemCode = "";

        /// <summary>UOEチェックコード</summary>
        private string _uOECheckCode = "";

        /// <summary>ヘッドエラーメッセージ</summary>
        private string _headErrorMassage = "";

        /// <summary>ラインエラーメッセージ</summary>
        private string _lineErrorMassage = "";

        /// <summary>データ送信区分</summary>
        /// <remarks>0:未処理,1:処理中,2:送信エラー,3:受信エラー,5:回答埋め込み,9:正常終了</remarks>
        private Int32 _dataSendCode;

        /// <summary>データ復旧区分</summary>
        /// <remarks>0:未処理,1:エラー,9:正常終了</remarks>
        private Int32 _dataRecoverDiv;

        /// <summary>入庫更新区分（拠点）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivSec;

        /// <summary>入庫更新区分（BO1）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivBO1;

        /// <summary>入庫更新区分（BO2）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivBO2;

        /// <summary>入庫更新区分（BO3）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivBO3;

        /// <summary>入庫更新区分（ﾒｰｶｰ）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivMaker;

        /// <summary>入庫更新区分（EO）</summary>
        /// <remarks>0:未入庫 1:入庫済</remarks>
        private Int32 _enterUpdDivEO;

        /// <summary>明細関連付けGUID</summary>
        private Guid _dtlRelationGuid;

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

        /// public propaty name  :  UOESectOutGoodsCnt
        /// <summary>UOE拠点出庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点出庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectOutGoodsCnt
        {
            get { return _uOESectOutGoodsCnt; }
            set { _uOESectOutGoodsCnt = value; }
        }

        /// public propaty name  :  BOShipmentCnt1
        /// <summary>BO出庫数1プロパティ</summary>
        /// <value>サブ本部フォロー数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO出庫数1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOShipmentCnt1
        {
            get { return _bOShipmentCnt1; }
            set { _bOShipmentCnt1 = value; }
        }

        /// public propaty name  :  BOShipmentCnt2
        /// <summary>BO出庫数2プロパティ</summary>
        /// <value>本部フォロー数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO出庫数2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOShipmentCnt2
        {
            get { return _bOShipmentCnt2; }
            set { _bOShipmentCnt2 = value; }
        }

        /// public propaty name  :  BOShipmentCnt3
        /// <summary>BO出庫数3プロパティ</summary>
        /// <value>ルートフォロー数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO出庫数3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOShipmentCnt3
        {
            get { return _bOShipmentCnt3; }
            set { _bOShipmentCnt3 = value; }
        }

        /// public propaty name  :  MakerFollowCnt
        /// <summary>メーカーフォロー数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーフォロー数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerFollowCnt
        {
            get { return _makerFollowCnt; }
            set { _makerFollowCnt = value; }
        }

        /// public propaty name  :  NonShipmentCnt
        /// <summary>未出庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   未出庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NonShipmentCnt
        {
            get { return _nonShipmentCnt; }
            set { _nonShipmentCnt = value; }
        }

        /// public propaty name  :  UOESectStockCnt
        /// <summary>UOE拠点在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectStockCnt
        {
            get { return _uOESectStockCnt; }
            set { _uOESectStockCnt = value; }
        }

        /// public propaty name  :  BOStockCount1
        /// <summary>BO在庫数1プロパティ</summary>
        /// <value>サブ本部在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO在庫数1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOStockCount1
        {
            get { return _bOStockCount1; }
            set { _bOStockCount1 = value; }
        }

        /// public propaty name  :  BOStockCount2
        /// <summary>BO在庫数2プロパティ</summary>
        /// <value>本部在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO在庫数2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOStockCount2
        {
            get { return _bOStockCount2; }
            set { _bOStockCount2 = value; }
        }

        /// public propaty name  :  BOStockCount3
        /// <summary>BO在庫数3プロパティ</summary>
        /// <value>ルート在庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO在庫数3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOStockCount3
        {
            get { return _bOStockCount3; }
            set { _bOStockCount3 = value; }
        }

        /// public propaty name  :  UOESectionSlipNo
        /// <summary>UOE拠点伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionSlipNo
        {
            get { return _uOESectionSlipNo; }
            set { _uOESectionSlipNo = value; }
        }

        /// public propaty name  :  BOSlipNo1
        /// <summary>BO伝票番号１プロパティ</summary>
        /// <value>サブ本部フォロー伝票№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO伝票番号１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOSlipNo1
        {
            get { return _bOSlipNo1; }
            set { _bOSlipNo1 = value; }
        }

        /// public propaty name  :  BOSlipNo2
        /// <summary>BO伝票番号２プロパティ</summary>
        /// <value>本部フォロー伝票№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO伝票番号２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOSlipNo2
        {
            get { return _bOSlipNo2; }
            set { _bOSlipNo2 = value; }
        }

        /// public propaty name  :  BOSlipNo3
        /// <summary>BO伝票番号３プロパティ</summary>
        /// <value>ルートフォロー伝票№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO伝票番号３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOSlipNo3
        {
            get { return _bOSlipNo3; }
            set { _bOSlipNo3 = value; }
        }

        /// public propaty name  :  EOAlwcCount
        /// <summary>EO引当数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   EO引当数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EOAlwcCount
        {
            get { return _eOAlwcCount; }
            set { _eOAlwcCount = value; }
        }

        /// public propaty name  :  BOManagementNo
        /// <summary>BO管理番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOManagementNo
        {
            get { return _bOManagementNo; }
            set { _bOManagementNo = value; }
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

        /// public propaty name  :  UOESubstMark
        /// <summary>UOE代替マークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE代替マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESubstMark
        {
            get { return _uOESubstMark; }
            set { _uOESubstMark = value; }
        }

        /// public propaty name  :  UOEStockMark
        /// <summary>UOE在庫マークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEStockMark
        {
            get { return _uOEStockMark; }
            set { _uOEStockMark = value; }
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

        /// public propaty name  :  MazdaUOEShipSectCd1
        /// <summary>UOE出荷拠点コード１（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE出荷拠点コード１（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOEShipSectCd1
        {
            get { return _mazdaUOEShipSectCd1; }
            set { _mazdaUOEShipSectCd1 = value; }
        }

        /// public propaty name  :  MazdaUOEShipSectCd2
        /// <summary>UOE出荷拠点コード２（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE出荷拠点コード２（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOEShipSectCd2
        {
            get { return _mazdaUOEShipSectCd2; }
            set { _mazdaUOEShipSectCd2 = value; }
        }

        /// public propaty name  :  MazdaUOEShipSectCd3
        /// <summary>UOE出荷拠点コード３（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE出荷拠点コード３（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOEShipSectCd3
        {
            get { return _mazdaUOEShipSectCd3; }
            set { _mazdaUOEShipSectCd3 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd1
        /// <summary>UOE拠点コード１（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード１（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOESectCd1
        {
            get { return _mazdaUOESectCd1; }
            set { _mazdaUOESectCd1 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd2
        /// <summary>UOE拠点コード２（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード２（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOESectCd2
        {
            get { return _mazdaUOESectCd2; }
            set { _mazdaUOESectCd2 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd3
        /// <summary>UOE拠点コード３（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード３（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOESectCd3
        {
            get { return _mazdaUOESectCd3; }
            set { _mazdaUOESectCd3 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd4
        /// <summary>UOE拠点コード４（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード４（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOESectCd4
        {
            get { return _mazdaUOESectCd4; }
            set { _mazdaUOESectCd4 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd5
        /// <summary>UOE拠点コード５（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード５（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOESectCd5
        {
            get { return _mazdaUOESectCd5; }
            set { _mazdaUOESectCd5 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd6
        /// <summary>UOE拠点コード６（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード６（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOESectCd6
        {
            get { return _mazdaUOESectCd6; }
            set { _mazdaUOESectCd6 = value; }
        }

        /// public propaty name  :  MazdaUOESectCd7
        /// <summary>UOE拠点コード７（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点コード７（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MazdaUOESectCd7
        {
            get { return _mazdaUOESectCd7; }
            set { _mazdaUOESectCd7 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt1
        /// <summary>UOE在庫数１（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫数１（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt1
        {
            get { return _mazdaUOEStockCnt1; }
            set { _mazdaUOEStockCnt1 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt2
        /// <summary>UOE在庫数２（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫数２（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt2
        {
            get { return _mazdaUOEStockCnt2; }
            set { _mazdaUOEStockCnt2 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt3
        /// <summary>UOE在庫数３（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫数３（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt3
        {
            get { return _mazdaUOEStockCnt3; }
            set { _mazdaUOEStockCnt3 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt4
        /// <summary>UOE在庫数４（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫数４（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt4
        {
            get { return _mazdaUOEStockCnt4; }
            set { _mazdaUOEStockCnt4 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt5
        /// <summary>UOE在庫数５（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫数５（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt5
        {
            get { return _mazdaUOEStockCnt5; }
            set { _mazdaUOEStockCnt5 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt6
        /// <summary>UOE在庫数６（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫数６（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt6
        {
            get { return _mazdaUOEStockCnt6; }
            set { _mazdaUOEStockCnt6 = value; }
        }

        /// public propaty name  :  MazdaUOEStockCnt7
        /// <summary>UOE在庫数７（マツダ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE在庫数７（マツダ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MazdaUOEStockCnt7
        {
            get { return _mazdaUOEStockCnt7; }
            set { _mazdaUOEStockCnt7 = value; }
        }

        /// public propaty name  :  UOEDistributionCd
        /// <summary>UOE卸コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE卸コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEDistributionCd
        {
            get { return _uOEDistributionCd; }
            set { _uOEDistributionCd = value; }
        }

        /// public propaty name  :  UOEOtherCd
        /// <summary>UOE他コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE他コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEOtherCd
        {
            get { return _uOEOtherCd; }
            set { _uOEOtherCd = value; }
        }

        /// public propaty name  :  UOEHMCd
        /// <summary>UOEＨＭコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEＨＭコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEHMCd
        {
            get { return _uOEHMCd; }
            set { _uOEHMCd = value; }
        }

        /// public propaty name  :  BOCount
        /// <summary>ＢＯ数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＯ数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOCount
        {
            get { return _bOCount; }
            set { _bOCount = value; }
        }

        /// public propaty name  :  UOEMarkCode
        /// <summary>UOEマークコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEマークコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOEMarkCode
        {
            get { return _uOEMarkCode; }
            set { _uOEMarkCode = value; }
        }

        /// public propaty name  :  SourceShipment
        /// <summary>出荷元プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷元プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SourceShipment
        {
            get { return _sourceShipment; }
            set { _sourceShipment = value; }
        }

        /// public propaty name  :  ItemCode
        /// <summary>アイテムコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   アイテムコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ItemCode
        {
            get { return _itemCode; }
            set { _itemCode = value; }
        }

        /// public propaty name  :  UOECheckCode
        /// <summary>UOEチェックコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOEチェックコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOECheckCode
        {
            get { return _uOECheckCode; }
            set { _uOECheckCode = value; }
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
        /// <value>0:未処理,1:処理中,2:送信エラー,3:受信エラー,5:回答埋め込み,9:正常終了</value>
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
        /// <value>0:未処理,1:エラー,9:正常終了</value>
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

        /// public propaty name  :  EnterUpdDivSec
        /// <summary>入庫更新区分（拠点）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（拠点）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivSec
        {
            get { return _enterUpdDivSec; }
            set { _enterUpdDivSec = value; }
        }

        /// public propaty name  :  EnterUpdDivBO1
        /// <summary>入庫更新区分（BO1）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（BO1）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivBO1
        {
            get { return _enterUpdDivBO1; }
            set { _enterUpdDivBO1 = value; }
        }

        /// public propaty name  :  EnterUpdDivBO2
        /// <summary>入庫更新区分（BO2）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（BO2）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivBO2
        {
            get { return _enterUpdDivBO2; }
            set { _enterUpdDivBO2 = value; }
        }

        /// public propaty name  :  EnterUpdDivBO3
        /// <summary>入庫更新区分（BO3）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（BO3）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivBO3
        {
            get { return _enterUpdDivBO3; }
            set { _enterUpdDivBO3 = value; }
        }

        /// public propaty name  :  EnterUpdDivMaker
        /// <summary>入庫更新区分（ﾒｰｶｰ）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（ﾒｰｶｰ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivMaker
        {
            get { return _enterUpdDivMaker; }
            set { _enterUpdDivMaker = value; }
        }

        /// public propaty name  :  EnterUpdDivEO
        /// <summary>入庫更新区分（EO）プロパティ</summary>
        /// <value>0:未入庫 1:入庫済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入庫更新区分（EO）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterUpdDivEO
        {
            get { return _enterUpdDivEO; }
            set { _enterUpdDivEO = value; }
        }

        /// public propaty name  :  DtlRelationGuid
        /// <summary>明細関連付けGUIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細関連付けGUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid DtlRelationGuid
        {
            get { return _dtlRelationGuid; }
            set { _dtlRelationGuid = value; }
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
        /// UOE発注データコンストラクタ
        /// </summary>
        /// <returns>UOEOrderDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEOrderDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderSndRcvJnl()
        {
        }

        /// <summary>
        /// UOE発注データコンストラクタ
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
        /// <param name="uOESectOutGoodsCnt">UOE拠点出庫数</param>
        /// <param name="bOShipmentCnt1">BO出庫数1(サブ本部フォロー数)</param>
        /// <param name="bOShipmentCnt2">BO出庫数2(本部フォロー数)</param>
        /// <param name="bOShipmentCnt3">BO出庫数3(ルートフォロー数)</param>
        /// <param name="makerFollowCnt">メーカーフォロー数</param>
        /// <param name="nonShipmentCnt">未出庫数</param>
        /// <param name="uOESectStockCnt">UOE拠点在庫数</param>
        /// <param name="bOStockCount1">BO在庫数1(サブ本部在庫)</param>
        /// <param name="bOStockCount2">BO在庫数2(本部在庫)</param>
        /// <param name="bOStockCount3">BO在庫数3(ルート在庫)</param>
        /// <param name="uOESectionSlipNo">UOE拠点伝票番号</param>
        /// <param name="bOSlipNo1">BO伝票番号１(サブ本部フォロー伝票№)</param>
        /// <param name="bOSlipNo2">BO伝票番号２(本部フォロー伝票№)</param>
        /// <param name="bOSlipNo3">BO伝票番号３(ルートフォロー伝票№)</param>
        /// <param name="eOAlwcCount">EO引当数</param>
        /// <param name="bOManagementNo">BO管理番号</param>
        /// <param name="answerListPrice">回答定価</param>
        /// <param name="answerSalesUnitCost">回答原価単価</param>
        /// <param name="uOESubstMark">UOE代替マーク</param>
        /// <param name="uOEStockMark">UOE在庫マーク</param>
        /// <param name="partsLayerCd">層別コード</param>
        /// <param name="mazdaUOEShipSectCd1">UOE出荷拠点コード１（マツダ）</param>
        /// <param name="mazdaUOEShipSectCd2">UOE出荷拠点コード２（マツダ）</param>
        /// <param name="mazdaUOEShipSectCd3">UOE出荷拠点コード３（マツダ）</param>
        /// <param name="mazdaUOESectCd1">UOE拠点コード１（マツダ）</param>
        /// <param name="mazdaUOESectCd2">UOE拠点コード２（マツダ）</param>
        /// <param name="mazdaUOESectCd3">UOE拠点コード３（マツダ）</param>
        /// <param name="mazdaUOESectCd4">UOE拠点コード４（マツダ）</param>
        /// <param name="mazdaUOESectCd5">UOE拠点コード５（マツダ）</param>
        /// <param name="mazdaUOESectCd6">UOE拠点コード６（マツダ）</param>
        /// <param name="mazdaUOESectCd7">UOE拠点コード７（マツダ）</param>
        /// <param name="mazdaUOEStockCnt1">UOE在庫数１（マツダ）</param>
        /// <param name="mazdaUOEStockCnt2">UOE在庫数２（マツダ）</param>
        /// <param name="mazdaUOEStockCnt3">UOE在庫数３（マツダ）</param>
        /// <param name="mazdaUOEStockCnt4">UOE在庫数４（マツダ）</param>
        /// <param name="mazdaUOEStockCnt5">UOE在庫数５（マツダ）</param>
        /// <param name="mazdaUOEStockCnt6">UOE在庫数６（マツダ）</param>
        /// <param name="mazdaUOEStockCnt7">UOE在庫数７（マツダ）</param>
        /// <param name="uOEDistributionCd">UOE卸コード</param>
        /// <param name="uOEOtherCd">UOE他コード</param>
        /// <param name="uOEHMCd">UOEＨＭコード</param>
        /// <param name="bOCount">ＢＯ数</param>
        /// <param name="uOEMarkCode">UOEマークコード</param>
        /// <param name="sourceShipment">出荷元</param>
        /// <param name="itemCode">アイテムコード</param>
        /// <param name="uOECheckCode">UOEチェックコード</param>
        /// <param name="headErrorMassage">ヘッドエラーメッセージ</param>
        /// <param name="lineErrorMassage">ラインエラーメッセージ</param>
        /// <param name="dataSendCode">データ送信区分(0:未処理,1:処理中,2:送信エラー,3:受信エラー,5:回答埋め込み,9:正常終了)</param>
        /// <param name="dataRecoverDiv">データ復旧区分(0:未処理,1:エラー,9:正常終了)</param>
        /// <param name="enterUpdDivSec">入庫更新区分（拠点）(0:未入庫 1:入庫済)</param>
        /// <param name="enterUpdDivBO1">入庫更新区分（BO1）(0:未入庫 1:入庫済)</param>
        /// <param name="enterUpdDivBO2">入庫更新区分（BO2）(0:未入庫 1:入庫済)</param>
        /// <param name="enterUpdDivBO3">入庫更新区分（BO3）(0:未入庫 1:入庫済)</param>
        /// <param name="enterUpdDivMaker">入庫更新区分（ﾒｰｶｰ）(0:未入庫 1:入庫済)</param>
        /// <param name="enterUpdDivEO">入庫更新区分（EO）(0:未入庫 1:入庫済)</param>
        /// <param name="dtlRelationGuid">明細関連付けGUID</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>UOEOrderDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEOrderDtlクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OrderSndRcvJnl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 systemDivCd, Int32 uOESalesOrderNo, Int32 uOESalesOrderRowNo, Int32 sendTerminalNo, Int32 uOESupplierCd, string uOESupplierName, string commAssemblyId, Int32 onlineNo, Int32 onlineRowNo, DateTime salesDate, DateTime inputDay, DateTime dataUpdateDateTime, Int32 uOEKind, string salesSlipNum, Int32 acptAnOdrStatus, Int64 salesSlipDtlNum, string sectionCode, Int32 subSectionCode, Int32 customerCode, string customerSnm, Int32 cashRegisterNo, Int64 commonSeqNo, Int32 supplierFormal, Int32 supplierSlipNo, Int64 stockSlipDtlNum, string boCode, string uOEDeliGoodsDiv, string deliveredGoodsDivNm, string followDeliGoodsDiv, string followDeliGoodsDivNm, string uOEResvdSection, string uOEResvdSectionNm, string employeeCode, string employeeName, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsNoNoneHyphen, string goodsName, string warehouseCode, string warehouseName, string warehouseShelfNo, Double acceptAnOrderCnt, Double listPrice, Double salesUnitCost, Int32 supplierCd, string supplierSnm, string uoeRemark1, string uoeRemark2, DateTime receiveDate, Int32 receiveTime, Int32 answerMakerCd, string answerPartsNo, string answerPartsName, string substPartsNo, Int32 uOESectOutGoodsCnt, Int32 bOShipmentCnt1, Int32 bOShipmentCnt2, Int32 bOShipmentCnt3, Int32 makerFollowCnt, Int32 nonShipmentCnt, Int32 uOESectStockCnt, Int32 bOStockCount1, Int32 bOStockCount2, Int32 bOStockCount3, string uOESectionSlipNo, string bOSlipNo1, string bOSlipNo2, string bOSlipNo3, Int32 eOAlwcCount, string bOManagementNo, Double answerListPrice, Double answerSalesUnitCost, string uOESubstMark, string uOEStockMark, string partsLayerCd, string mazdaUOEShipSectCd1, string mazdaUOEShipSectCd2, string mazdaUOEShipSectCd3, string mazdaUOESectCd1, string mazdaUOESectCd2, string mazdaUOESectCd3, string mazdaUOESectCd4, string mazdaUOESectCd5, string mazdaUOESectCd6, string mazdaUOESectCd7, Int32 mazdaUOEStockCnt1, Int32 mazdaUOEStockCnt2, Int32 mazdaUOEStockCnt3, Int32 mazdaUOEStockCnt4, Int32 mazdaUOEStockCnt5, Int32 mazdaUOEStockCnt6, Int32 mazdaUOEStockCnt7, string uOEDistributionCd, string uOEOtherCd, string uOEHMCd, Int32 bOCount, string uOEMarkCode, string sourceShipment, string itemCode, string uOECheckCode, string headErrorMassage, string lineErrorMassage, Int32 dataSendCode, Int32 dataRecoverDiv, Int32 enterUpdDivSec, Int32 enterUpdDivBO1, Int32 enterUpdDivBO2, Int32 enterUpdDivBO3, Int32 enterUpdDivMaker, Int32 enterUpdDivEO, Guid dtlRelationGuid, string enterpriseName, string updEmployeeName)
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
            this._uOESectOutGoodsCnt = uOESectOutGoodsCnt;
            this._bOShipmentCnt1 = bOShipmentCnt1;
            this._bOShipmentCnt2 = bOShipmentCnt2;
            this._bOShipmentCnt3 = bOShipmentCnt3;
            this._makerFollowCnt = makerFollowCnt;
            this._nonShipmentCnt = nonShipmentCnt;
            this._uOESectStockCnt = uOESectStockCnt;
            this._bOStockCount1 = bOStockCount1;
            this._bOStockCount2 = bOStockCount2;
            this._bOStockCount3 = bOStockCount3;
            this._uOESectionSlipNo = uOESectionSlipNo;
            this._bOSlipNo1 = bOSlipNo1;
            this._bOSlipNo2 = bOSlipNo2;
            this._bOSlipNo3 = bOSlipNo3;
            this._eOAlwcCount = eOAlwcCount;
            this._bOManagementNo = bOManagementNo;
            this._answerListPrice = answerListPrice;
            this._answerSalesUnitCost = answerSalesUnitCost;
            this._uOESubstMark = uOESubstMark;
            this._uOEStockMark = uOEStockMark;
            this._partsLayerCd = partsLayerCd;
            this._mazdaUOEShipSectCd1 = mazdaUOEShipSectCd1;
            this._mazdaUOEShipSectCd2 = mazdaUOEShipSectCd2;
            this._mazdaUOEShipSectCd3 = mazdaUOEShipSectCd3;
            this._mazdaUOESectCd1 = mazdaUOESectCd1;
            this._mazdaUOESectCd2 = mazdaUOESectCd2;
            this._mazdaUOESectCd3 = mazdaUOESectCd3;
            this._mazdaUOESectCd4 = mazdaUOESectCd4;
            this._mazdaUOESectCd5 = mazdaUOESectCd5;
            this._mazdaUOESectCd6 = mazdaUOESectCd6;
            this._mazdaUOESectCd7 = mazdaUOESectCd7;
            this._mazdaUOEStockCnt1 = mazdaUOEStockCnt1;
            this._mazdaUOEStockCnt2 = mazdaUOEStockCnt2;
            this._mazdaUOEStockCnt3 = mazdaUOEStockCnt3;
            this._mazdaUOEStockCnt4 = mazdaUOEStockCnt4;
            this._mazdaUOEStockCnt5 = mazdaUOEStockCnt5;
            this._mazdaUOEStockCnt6 = mazdaUOEStockCnt6;
            this._mazdaUOEStockCnt7 = mazdaUOEStockCnt7;
            this._uOEDistributionCd = uOEDistributionCd;
            this._uOEOtherCd = uOEOtherCd;
            this._uOEHMCd = uOEHMCd;
            this._bOCount = bOCount;
            this._uOEMarkCode = uOEMarkCode;
            this._sourceShipment = sourceShipment;
            this._itemCode = itemCode;
            this._uOECheckCode = uOECheckCode;
            this._headErrorMassage = headErrorMassage;
            this._lineErrorMassage = lineErrorMassage;
            this._dataSendCode = dataSendCode;
            this._dataRecoverDiv = dataRecoverDiv;
            this._enterUpdDivSec = enterUpdDivSec;
            this._enterUpdDivBO1 = enterUpdDivBO1;
            this._enterUpdDivBO2 = enterUpdDivBO2;
            this._enterUpdDivBO3 = enterUpdDivBO3;
            this._enterUpdDivMaker = enterUpdDivMaker;
            this._enterUpdDivEO = enterUpdDivEO;
            this._dtlRelationGuid = dtlRelationGuid;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// UOE発注データ複製処理
        /// </summary>
        /// <returns>UOEOrderDtlクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUOEOrderDtlクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEOrderDtl Clone()
        {
            return new UOEOrderDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._systemDivCd, this._uOESalesOrderNo, this._uOESalesOrderRowNo, this._sendTerminalNo, this._uOESupplierCd, this._uOESupplierName, this._commAssemblyId, this._onlineNo, this._onlineRowNo, this._salesDate, this._inputDay, this._dataUpdateDateTime, this._uOEKind, this._salesSlipNum, this._acptAnOdrStatus, this._salesSlipDtlNum, this._sectionCode, this._subSectionCode, this._customerCode, this._customerSnm, this._cashRegisterNo, this._commonSeqNo, this._supplierFormal, this._supplierSlipNo, this._stockSlipDtlNum, this._boCode, this._uOEDeliGoodsDiv, this._deliveredGoodsDivNm, this._followDeliGoodsDiv, this._followDeliGoodsDivNm, this._uOEResvdSection, this._uOEResvdSectionNm, this._employeeCode, this._employeeName, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoNoneHyphen, this._goodsName, this._warehouseCode, this._warehouseName, this._warehouseShelfNo, this._acceptAnOrderCnt, this._listPrice, this._salesUnitCost, this._supplierCd, this._supplierSnm, this._uoeRemark1, this._uoeRemark2, this._receiveDate, this._receiveTime, this._answerMakerCd, this._answerPartsNo, this._answerPartsName, this._substPartsNo, this._uOESectOutGoodsCnt, this._bOShipmentCnt1, this._bOShipmentCnt2, this._bOShipmentCnt3, this._makerFollowCnt, this._nonShipmentCnt, this._uOESectStockCnt, this._bOStockCount1, this._bOStockCount2, this._bOStockCount3, this._uOESectionSlipNo, this._bOSlipNo1, this._bOSlipNo2, this._bOSlipNo3, this._eOAlwcCount, this._bOManagementNo, this._answerListPrice, this._answerSalesUnitCost, this._uOESubstMark, this._uOEStockMark, this._partsLayerCd, this._mazdaUOEShipSectCd1, this._mazdaUOEShipSectCd2, this._mazdaUOEShipSectCd3, this._mazdaUOESectCd1, this._mazdaUOESectCd2, this._mazdaUOESectCd3, this._mazdaUOESectCd4, this._mazdaUOESectCd5, this._mazdaUOESectCd6, this._mazdaUOESectCd7, this._mazdaUOEStockCnt1, this._mazdaUOEStockCnt2, this._mazdaUOEStockCnt3, this._mazdaUOEStockCnt4, this._mazdaUOEStockCnt5, this._mazdaUOEStockCnt6, this._mazdaUOEStockCnt7, this._uOEDistributionCd, this._uOEOtherCd, this._uOEHMCd, this._bOCount, this._uOEMarkCode, this._sourceShipment, this._itemCode, this._uOECheckCode, this._headErrorMassage, this._lineErrorMassage, this._dataSendCode, this._dataRecoverDiv, this._enterUpdDivSec, this._enterUpdDivBO1, this._enterUpdDivBO2, this._enterUpdDivBO3, this._enterUpdDivMaker, this._enterUpdDivEO, this._dtlRelationGuid, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// UOE発注データ比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEOrderDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEOrderDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UOEOrderDtl target)
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
                 && (this.UOESectOutGoodsCnt == target.UOESectOutGoodsCnt)
                 && (this.BOShipmentCnt1 == target.BOShipmentCnt1)
                 && (this.BOShipmentCnt2 == target.BOShipmentCnt2)
                 && (this.BOShipmentCnt3 == target.BOShipmentCnt3)
                 && (this.MakerFollowCnt == target.MakerFollowCnt)
                 && (this.NonShipmentCnt == target.NonShipmentCnt)
                 && (this.UOESectStockCnt == target.UOESectStockCnt)
                 && (this.BOStockCount1 == target.BOStockCount1)
                 && (this.BOStockCount2 == target.BOStockCount2)
                 && (this.BOStockCount3 == target.BOStockCount3)
                 && (this.UOESectionSlipNo == target.UOESectionSlipNo)
                 && (this.BOSlipNo1 == target.BOSlipNo1)
                 && (this.BOSlipNo2 == target.BOSlipNo2)
                 && (this.BOSlipNo3 == target.BOSlipNo3)
                 && (this.EOAlwcCount == target.EOAlwcCount)
                 && (this.BOManagementNo == target.BOManagementNo)
                 && (this.AnswerListPrice == target.AnswerListPrice)
                 && (this.AnswerSalesUnitCost == target.AnswerSalesUnitCost)
                 && (this.UOESubstMark == target.UOESubstMark)
                 && (this.UOEStockMark == target.UOEStockMark)
                 && (this.PartsLayerCd == target.PartsLayerCd)
                 && (this.MazdaUOEShipSectCd1 == target.MazdaUOEShipSectCd1)
                 && (this.MazdaUOEShipSectCd2 == target.MazdaUOEShipSectCd2)
                 && (this.MazdaUOEShipSectCd3 == target.MazdaUOEShipSectCd3)
                 && (this.MazdaUOESectCd1 == target.MazdaUOESectCd1)
                 && (this.MazdaUOESectCd2 == target.MazdaUOESectCd2)
                 && (this.MazdaUOESectCd3 == target.MazdaUOESectCd3)
                 && (this.MazdaUOESectCd4 == target.MazdaUOESectCd4)
                 && (this.MazdaUOESectCd5 == target.MazdaUOESectCd5)
                 && (this.MazdaUOESectCd6 == target.MazdaUOESectCd6)
                 && (this.MazdaUOESectCd7 == target.MazdaUOESectCd7)
                 && (this.MazdaUOEStockCnt1 == target.MazdaUOEStockCnt1)
                 && (this.MazdaUOEStockCnt2 == target.MazdaUOEStockCnt2)
                 && (this.MazdaUOEStockCnt3 == target.MazdaUOEStockCnt3)
                 && (this.MazdaUOEStockCnt4 == target.MazdaUOEStockCnt4)
                 && (this.MazdaUOEStockCnt5 == target.MazdaUOEStockCnt5)
                 && (this.MazdaUOEStockCnt6 == target.MazdaUOEStockCnt6)
                 && (this.MazdaUOEStockCnt7 == target.MazdaUOEStockCnt7)
                 && (this.UOEDistributionCd == target.UOEDistributionCd)
                 && (this.UOEOtherCd == target.UOEOtherCd)
                 && (this.UOEHMCd == target.UOEHMCd)
                 && (this.BOCount == target.BOCount)
                 && (this.UOEMarkCode == target.UOEMarkCode)
                 && (this.SourceShipment == target.SourceShipment)
                 && (this.ItemCode == target.ItemCode)
                 && (this.UOECheckCode == target.UOECheckCode)
                 && (this.HeadErrorMassage == target.HeadErrorMassage)
                 && (this.LineErrorMassage == target.LineErrorMassage)
                 && (this.DataSendCode == target.DataSendCode)
                 && (this.DataRecoverDiv == target.DataRecoverDiv)
                 && (this.EnterUpdDivSec == target.EnterUpdDivSec)
                 && (this.EnterUpdDivBO1 == target.EnterUpdDivBO1)
                 && (this.EnterUpdDivBO2 == target.EnterUpdDivBO2)
                 && (this.EnterUpdDivBO3 == target.EnterUpdDivBO3)
                 && (this.EnterUpdDivMaker == target.EnterUpdDivMaker)
                 && (this.EnterUpdDivEO == target.EnterUpdDivEO)
                 && (this.DtlRelationGuid == target.DtlRelationGuid)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// UOE発注データ比較処理
        /// </summary>
        /// <param name="uOEOrderDtl1">
        ///                    比較するUOEOrderDtlクラスのインスタンス
        /// </param>
        /// <param name="uOEOrderDtl2">比較するUOEOrderDtlクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEOrderDtlクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UOEOrderDtl uOEOrderDtl1, UOEOrderDtl uOEOrderDtl2)
        {
            return ((uOEOrderDtl1.CreateDateTime == uOEOrderDtl2.CreateDateTime)
                 && (uOEOrderDtl1.UpdateDateTime == uOEOrderDtl2.UpdateDateTime)
                 && (uOEOrderDtl1.EnterpriseCode == uOEOrderDtl2.EnterpriseCode)
                 && (uOEOrderDtl1.FileHeaderGuid == uOEOrderDtl2.FileHeaderGuid)
                 && (uOEOrderDtl1.UpdEmployeeCode == uOEOrderDtl2.UpdEmployeeCode)
                 && (uOEOrderDtl1.UpdAssemblyId1 == uOEOrderDtl2.UpdAssemblyId1)
                 && (uOEOrderDtl1.UpdAssemblyId2 == uOEOrderDtl2.UpdAssemblyId2)
                 && (uOEOrderDtl1.LogicalDeleteCode == uOEOrderDtl2.LogicalDeleteCode)
                 && (uOEOrderDtl1.SystemDivCd == uOEOrderDtl2.SystemDivCd)
                 && (uOEOrderDtl1.UOESalesOrderNo == uOEOrderDtl2.UOESalesOrderNo)
                 && (uOEOrderDtl1.UOESalesOrderRowNo == uOEOrderDtl2.UOESalesOrderRowNo)
                 && (uOEOrderDtl1.SendTerminalNo == uOEOrderDtl2.SendTerminalNo)
                 && (uOEOrderDtl1.UOESupplierCd == uOEOrderDtl2.UOESupplierCd)
                 && (uOEOrderDtl1.UOESupplierName == uOEOrderDtl2.UOESupplierName)
                 && (uOEOrderDtl1.CommAssemblyId == uOEOrderDtl2.CommAssemblyId)
                 && (uOEOrderDtl1.OnlineNo == uOEOrderDtl2.OnlineNo)
                 && (uOEOrderDtl1.OnlineRowNo == uOEOrderDtl2.OnlineRowNo)
                 && (uOEOrderDtl1.SalesDate == uOEOrderDtl2.SalesDate)
                 && (uOEOrderDtl1.InputDay == uOEOrderDtl2.InputDay)
                 && (uOEOrderDtl1.DataUpdateDateTime == uOEOrderDtl2.DataUpdateDateTime)
                 && (uOEOrderDtl1.UOEKind == uOEOrderDtl2.UOEKind)
                 && (uOEOrderDtl1.SalesSlipNum == uOEOrderDtl2.SalesSlipNum)
                 && (uOEOrderDtl1.AcptAnOdrStatus == uOEOrderDtl2.AcptAnOdrStatus)
                 && (uOEOrderDtl1.SalesSlipDtlNum == uOEOrderDtl2.SalesSlipDtlNum)
                 && (uOEOrderDtl1.SectionCode == uOEOrderDtl2.SectionCode)
                 && (uOEOrderDtl1.SubSectionCode == uOEOrderDtl2.SubSectionCode)
                 && (uOEOrderDtl1.CustomerCode == uOEOrderDtl2.CustomerCode)
                 && (uOEOrderDtl1.CustomerSnm == uOEOrderDtl2.CustomerSnm)
                 && (uOEOrderDtl1.CashRegisterNo == uOEOrderDtl2.CashRegisterNo)
                 && (uOEOrderDtl1.CommonSeqNo == uOEOrderDtl2.CommonSeqNo)
                 && (uOEOrderDtl1.SupplierFormal == uOEOrderDtl2.SupplierFormal)
                 && (uOEOrderDtl1.SupplierSlipNo == uOEOrderDtl2.SupplierSlipNo)
                 && (uOEOrderDtl1.StockSlipDtlNum == uOEOrderDtl2.StockSlipDtlNum)
                 && (uOEOrderDtl1.BoCode == uOEOrderDtl2.BoCode)
                 && (uOEOrderDtl1.UOEDeliGoodsDiv == uOEOrderDtl2.UOEDeliGoodsDiv)
                 && (uOEOrderDtl1.DeliveredGoodsDivNm == uOEOrderDtl2.DeliveredGoodsDivNm)
                 && (uOEOrderDtl1.FollowDeliGoodsDiv == uOEOrderDtl2.FollowDeliGoodsDiv)
                 && (uOEOrderDtl1.FollowDeliGoodsDivNm == uOEOrderDtl2.FollowDeliGoodsDivNm)
                 && (uOEOrderDtl1.UOEResvdSection == uOEOrderDtl2.UOEResvdSection)
                 && (uOEOrderDtl1.UOEResvdSectionNm == uOEOrderDtl2.UOEResvdSectionNm)
                 && (uOEOrderDtl1.EmployeeCode == uOEOrderDtl2.EmployeeCode)
                 && (uOEOrderDtl1.EmployeeName == uOEOrderDtl2.EmployeeName)
                 && (uOEOrderDtl1.GoodsMakerCd == uOEOrderDtl2.GoodsMakerCd)
                 && (uOEOrderDtl1.MakerName == uOEOrderDtl2.MakerName)
                 && (uOEOrderDtl1.GoodsNo == uOEOrderDtl2.GoodsNo)
                 && (uOEOrderDtl1.GoodsNoNoneHyphen == uOEOrderDtl2.GoodsNoNoneHyphen)
                 && (uOEOrderDtl1.GoodsName == uOEOrderDtl2.GoodsName)
                 && (uOEOrderDtl1.WarehouseCode == uOEOrderDtl2.WarehouseCode)
                 && (uOEOrderDtl1.WarehouseName == uOEOrderDtl2.WarehouseName)
                 && (uOEOrderDtl1.WarehouseShelfNo == uOEOrderDtl2.WarehouseShelfNo)
                 && (uOEOrderDtl1.AcceptAnOrderCnt == uOEOrderDtl2.AcceptAnOrderCnt)
                 && (uOEOrderDtl1.ListPrice == uOEOrderDtl2.ListPrice)
                 && (uOEOrderDtl1.SalesUnitCost == uOEOrderDtl2.SalesUnitCost)
                 && (uOEOrderDtl1.SupplierCd == uOEOrderDtl2.SupplierCd)
                 && (uOEOrderDtl1.SupplierSnm == uOEOrderDtl2.SupplierSnm)
                 && (uOEOrderDtl1.UoeRemark1 == uOEOrderDtl2.UoeRemark1)
                 && (uOEOrderDtl1.UoeRemark2 == uOEOrderDtl2.UoeRemark2)
                 && (uOEOrderDtl1.ReceiveDate == uOEOrderDtl2.ReceiveDate)
                 && (uOEOrderDtl1.ReceiveTime == uOEOrderDtl2.ReceiveTime)
                 && (uOEOrderDtl1.AnswerMakerCd == uOEOrderDtl2.AnswerMakerCd)
                 && (uOEOrderDtl1.AnswerPartsNo == uOEOrderDtl2.AnswerPartsNo)
                 && (uOEOrderDtl1.AnswerPartsName == uOEOrderDtl2.AnswerPartsName)
                 && (uOEOrderDtl1.SubstPartsNo == uOEOrderDtl2.SubstPartsNo)
                 && (uOEOrderDtl1.UOESectOutGoodsCnt == uOEOrderDtl2.UOESectOutGoodsCnt)
                 && (uOEOrderDtl1.BOShipmentCnt1 == uOEOrderDtl2.BOShipmentCnt1)
                 && (uOEOrderDtl1.BOShipmentCnt2 == uOEOrderDtl2.BOShipmentCnt2)
                 && (uOEOrderDtl1.BOShipmentCnt3 == uOEOrderDtl2.BOShipmentCnt3)
                 && (uOEOrderDtl1.MakerFollowCnt == uOEOrderDtl2.MakerFollowCnt)
                 && (uOEOrderDtl1.NonShipmentCnt == uOEOrderDtl2.NonShipmentCnt)
                 && (uOEOrderDtl1.UOESectStockCnt == uOEOrderDtl2.UOESectStockCnt)
                 && (uOEOrderDtl1.BOStockCount1 == uOEOrderDtl2.BOStockCount1)
                 && (uOEOrderDtl1.BOStockCount2 == uOEOrderDtl2.BOStockCount2)
                 && (uOEOrderDtl1.BOStockCount3 == uOEOrderDtl2.BOStockCount3)
                 && (uOEOrderDtl1.UOESectionSlipNo == uOEOrderDtl2.UOESectionSlipNo)
                 && (uOEOrderDtl1.BOSlipNo1 == uOEOrderDtl2.BOSlipNo1)
                 && (uOEOrderDtl1.BOSlipNo2 == uOEOrderDtl2.BOSlipNo2)
                 && (uOEOrderDtl1.BOSlipNo3 == uOEOrderDtl2.BOSlipNo3)
                 && (uOEOrderDtl1.EOAlwcCount == uOEOrderDtl2.EOAlwcCount)
                 && (uOEOrderDtl1.BOManagementNo == uOEOrderDtl2.BOManagementNo)
                 && (uOEOrderDtl1.AnswerListPrice == uOEOrderDtl2.AnswerListPrice)
                 && (uOEOrderDtl1.AnswerSalesUnitCost == uOEOrderDtl2.AnswerSalesUnitCost)
                 && (uOEOrderDtl1.UOESubstMark == uOEOrderDtl2.UOESubstMark)
                 && (uOEOrderDtl1.UOEStockMark == uOEOrderDtl2.UOEStockMark)
                 && (uOEOrderDtl1.PartsLayerCd == uOEOrderDtl2.PartsLayerCd)
                 && (uOEOrderDtl1.MazdaUOEShipSectCd1 == uOEOrderDtl2.MazdaUOEShipSectCd1)
                 && (uOEOrderDtl1.MazdaUOEShipSectCd2 == uOEOrderDtl2.MazdaUOEShipSectCd2)
                 && (uOEOrderDtl1.MazdaUOEShipSectCd3 == uOEOrderDtl2.MazdaUOEShipSectCd3)
                 && (uOEOrderDtl1.MazdaUOESectCd1 == uOEOrderDtl2.MazdaUOESectCd1)
                 && (uOEOrderDtl1.MazdaUOESectCd2 == uOEOrderDtl2.MazdaUOESectCd2)
                 && (uOEOrderDtl1.MazdaUOESectCd3 == uOEOrderDtl2.MazdaUOESectCd3)
                 && (uOEOrderDtl1.MazdaUOESectCd4 == uOEOrderDtl2.MazdaUOESectCd4)
                 && (uOEOrderDtl1.MazdaUOESectCd5 == uOEOrderDtl2.MazdaUOESectCd5)
                 && (uOEOrderDtl1.MazdaUOESectCd6 == uOEOrderDtl2.MazdaUOESectCd6)
                 && (uOEOrderDtl1.MazdaUOESectCd7 == uOEOrderDtl2.MazdaUOESectCd7)
                 && (uOEOrderDtl1.MazdaUOEStockCnt1 == uOEOrderDtl2.MazdaUOEStockCnt1)
                 && (uOEOrderDtl1.MazdaUOEStockCnt2 == uOEOrderDtl2.MazdaUOEStockCnt2)
                 && (uOEOrderDtl1.MazdaUOEStockCnt3 == uOEOrderDtl2.MazdaUOEStockCnt3)
                 && (uOEOrderDtl1.MazdaUOEStockCnt4 == uOEOrderDtl2.MazdaUOEStockCnt4)
                 && (uOEOrderDtl1.MazdaUOEStockCnt5 == uOEOrderDtl2.MazdaUOEStockCnt5)
                 && (uOEOrderDtl1.MazdaUOEStockCnt6 == uOEOrderDtl2.MazdaUOEStockCnt6)
                 && (uOEOrderDtl1.MazdaUOEStockCnt7 == uOEOrderDtl2.MazdaUOEStockCnt7)
                 && (uOEOrderDtl1.UOEDistributionCd == uOEOrderDtl2.UOEDistributionCd)
                 && (uOEOrderDtl1.UOEOtherCd == uOEOrderDtl2.UOEOtherCd)
                 && (uOEOrderDtl1.UOEHMCd == uOEOrderDtl2.UOEHMCd)
                 && (uOEOrderDtl1.BOCount == uOEOrderDtl2.BOCount)
                 && (uOEOrderDtl1.UOEMarkCode == uOEOrderDtl2.UOEMarkCode)
                 && (uOEOrderDtl1.SourceShipment == uOEOrderDtl2.SourceShipment)
                 && (uOEOrderDtl1.ItemCode == uOEOrderDtl2.ItemCode)
                 && (uOEOrderDtl1.UOECheckCode == uOEOrderDtl2.UOECheckCode)
                 && (uOEOrderDtl1.HeadErrorMassage == uOEOrderDtl2.HeadErrorMassage)
                 && (uOEOrderDtl1.LineErrorMassage == uOEOrderDtl2.LineErrorMassage)
                 && (uOEOrderDtl1.DataSendCode == uOEOrderDtl2.DataSendCode)
                 && (uOEOrderDtl1.DataRecoverDiv == uOEOrderDtl2.DataRecoverDiv)
                 && (uOEOrderDtl1.EnterUpdDivSec == uOEOrderDtl2.EnterUpdDivSec)
                 && (uOEOrderDtl1.EnterUpdDivBO1 == uOEOrderDtl2.EnterUpdDivBO1)
                 && (uOEOrderDtl1.EnterUpdDivBO2 == uOEOrderDtl2.EnterUpdDivBO2)
                 && (uOEOrderDtl1.EnterUpdDivBO3 == uOEOrderDtl2.EnterUpdDivBO3)
                 && (uOEOrderDtl1.EnterUpdDivMaker == uOEOrderDtl2.EnterUpdDivMaker)
                 && (uOEOrderDtl1.EnterUpdDivEO == uOEOrderDtl2.EnterUpdDivEO)
                 && (uOEOrderDtl1.DtlRelationGuid == uOEOrderDtl2.DtlRelationGuid)
                 && (uOEOrderDtl1.EnterpriseName == uOEOrderDtl2.EnterpriseName)
                 && (uOEOrderDtl1.UpdEmployeeName == uOEOrderDtl2.UpdEmployeeName));
        }
        /// <summary>
        /// UOE発注データ比較処理
        /// </summary>
        /// <param name="target">比較対象のUOEOrderDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEOrderDtlクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UOEOrderDtl target)
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
            if (this.UOESectOutGoodsCnt != target.UOESectOutGoodsCnt) resList.Add("UOESectOutGoodsCnt");
            if (this.BOShipmentCnt1 != target.BOShipmentCnt1) resList.Add("BOShipmentCnt1");
            if (this.BOShipmentCnt2 != target.BOShipmentCnt2) resList.Add("BOShipmentCnt2");
            if (this.BOShipmentCnt3 != target.BOShipmentCnt3) resList.Add("BOShipmentCnt3");
            if (this.MakerFollowCnt != target.MakerFollowCnt) resList.Add("MakerFollowCnt");
            if (this.NonShipmentCnt != target.NonShipmentCnt) resList.Add("NonShipmentCnt");
            if (this.UOESectStockCnt != target.UOESectStockCnt) resList.Add("UOESectStockCnt");
            if (this.BOStockCount1 != target.BOStockCount1) resList.Add("BOStockCount1");
            if (this.BOStockCount2 != target.BOStockCount2) resList.Add("BOStockCount2");
            if (this.BOStockCount3 != target.BOStockCount3) resList.Add("BOStockCount3");
            if (this.UOESectionSlipNo != target.UOESectionSlipNo) resList.Add("UOESectionSlipNo");
            if (this.BOSlipNo1 != target.BOSlipNo1) resList.Add("BOSlipNo1");
            if (this.BOSlipNo2 != target.BOSlipNo2) resList.Add("BOSlipNo2");
            if (this.BOSlipNo3 != target.BOSlipNo3) resList.Add("BOSlipNo3");
            if (this.EOAlwcCount != target.EOAlwcCount) resList.Add("EOAlwcCount");
            if (this.BOManagementNo != target.BOManagementNo) resList.Add("BOManagementNo");
            if (this.AnswerListPrice != target.AnswerListPrice) resList.Add("AnswerListPrice");
            if (this.AnswerSalesUnitCost != target.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");
            if (this.UOESubstMark != target.UOESubstMark) resList.Add("UOESubstMark");
            if (this.UOEStockMark != target.UOEStockMark) resList.Add("UOEStockMark");
            if (this.PartsLayerCd != target.PartsLayerCd) resList.Add("PartsLayerCd");
            if (this.MazdaUOEShipSectCd1 != target.MazdaUOEShipSectCd1) resList.Add("MazdaUOEShipSectCd1");
            if (this.MazdaUOEShipSectCd2 != target.MazdaUOEShipSectCd2) resList.Add("MazdaUOEShipSectCd2");
            if (this.MazdaUOEShipSectCd3 != target.MazdaUOEShipSectCd3) resList.Add("MazdaUOEShipSectCd3");
            if (this.MazdaUOESectCd1 != target.MazdaUOESectCd1) resList.Add("MazdaUOESectCd1");
            if (this.MazdaUOESectCd2 != target.MazdaUOESectCd2) resList.Add("MazdaUOESectCd2");
            if (this.MazdaUOESectCd3 != target.MazdaUOESectCd3) resList.Add("MazdaUOESectCd3");
            if (this.MazdaUOESectCd4 != target.MazdaUOESectCd4) resList.Add("MazdaUOESectCd4");
            if (this.MazdaUOESectCd5 != target.MazdaUOESectCd5) resList.Add("MazdaUOESectCd5");
            if (this.MazdaUOESectCd6 != target.MazdaUOESectCd6) resList.Add("MazdaUOESectCd6");
            if (this.MazdaUOESectCd7 != target.MazdaUOESectCd7) resList.Add("MazdaUOESectCd7");
            if (this.MazdaUOEStockCnt1 != target.MazdaUOEStockCnt1) resList.Add("MazdaUOEStockCnt1");
            if (this.MazdaUOEStockCnt2 != target.MazdaUOEStockCnt2) resList.Add("MazdaUOEStockCnt2");
            if (this.MazdaUOEStockCnt3 != target.MazdaUOEStockCnt3) resList.Add("MazdaUOEStockCnt3");
            if (this.MazdaUOEStockCnt4 != target.MazdaUOEStockCnt4) resList.Add("MazdaUOEStockCnt4");
            if (this.MazdaUOEStockCnt5 != target.MazdaUOEStockCnt5) resList.Add("MazdaUOEStockCnt5");
            if (this.MazdaUOEStockCnt6 != target.MazdaUOEStockCnt6) resList.Add("MazdaUOEStockCnt6");
            if (this.MazdaUOEStockCnt7 != target.MazdaUOEStockCnt7) resList.Add("MazdaUOEStockCnt7");
            if (this.UOEDistributionCd != target.UOEDistributionCd) resList.Add("UOEDistributionCd");
            if (this.UOEOtherCd != target.UOEOtherCd) resList.Add("UOEOtherCd");
            if (this.UOEHMCd != target.UOEHMCd) resList.Add("UOEHMCd");
            if (this.BOCount != target.BOCount) resList.Add("BOCount");
            if (this.UOEMarkCode != target.UOEMarkCode) resList.Add("UOEMarkCode");
            if (this.SourceShipment != target.SourceShipment) resList.Add("SourceShipment");
            if (this.ItemCode != target.ItemCode) resList.Add("ItemCode");
            if (this.UOECheckCode != target.UOECheckCode) resList.Add("UOECheckCode");
            if (this.HeadErrorMassage != target.HeadErrorMassage) resList.Add("HeadErrorMassage");
            if (this.LineErrorMassage != target.LineErrorMassage) resList.Add("LineErrorMassage");
            if (this.DataSendCode != target.DataSendCode) resList.Add("DataSendCode");
            if (this.DataRecoverDiv != target.DataRecoverDiv) resList.Add("DataRecoverDiv");
            if (this.EnterUpdDivSec != target.EnterUpdDivSec) resList.Add("EnterUpdDivSec");
            if (this.EnterUpdDivBO1 != target.EnterUpdDivBO1) resList.Add("EnterUpdDivBO1");
            if (this.EnterUpdDivBO2 != target.EnterUpdDivBO2) resList.Add("EnterUpdDivBO2");
            if (this.EnterUpdDivBO3 != target.EnterUpdDivBO3) resList.Add("EnterUpdDivBO3");
            if (this.EnterUpdDivMaker != target.EnterUpdDivMaker) resList.Add("EnterUpdDivMaker");
            if (this.EnterUpdDivEO != target.EnterUpdDivEO) resList.Add("EnterUpdDivEO");
            if (this.DtlRelationGuid != target.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// UOE発注データ比較処理
        /// </summary>
        /// <param name="uOEOrderDtl1">比較するUOEOrderDtlクラスのインスタンス</param>
        /// <param name="uOEOrderDtl2">比較するUOEOrderDtlクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEOrderDtlクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UOEOrderDtl uOEOrderDtl1, UOEOrderDtl uOEOrderDtl2)
        {
            ArrayList resList = new ArrayList();
            if (uOEOrderDtl1.CreateDateTime != uOEOrderDtl2.CreateDateTime) resList.Add("CreateDateTime");
            if (uOEOrderDtl1.UpdateDateTime != uOEOrderDtl2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (uOEOrderDtl1.EnterpriseCode != uOEOrderDtl2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOEOrderDtl1.FileHeaderGuid != uOEOrderDtl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (uOEOrderDtl1.UpdEmployeeCode != uOEOrderDtl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (uOEOrderDtl1.UpdAssemblyId1 != uOEOrderDtl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (uOEOrderDtl1.UpdAssemblyId2 != uOEOrderDtl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (uOEOrderDtl1.LogicalDeleteCode != uOEOrderDtl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (uOEOrderDtl1.SystemDivCd != uOEOrderDtl2.SystemDivCd) resList.Add("SystemDivCd");
            if (uOEOrderDtl1.UOESalesOrderNo != uOEOrderDtl2.UOESalesOrderNo) resList.Add("UOESalesOrderNo");
            if (uOEOrderDtl1.UOESalesOrderRowNo != uOEOrderDtl2.UOESalesOrderRowNo) resList.Add("UOESalesOrderRowNo");
            if (uOEOrderDtl1.SendTerminalNo != uOEOrderDtl2.SendTerminalNo) resList.Add("SendTerminalNo");
            if (uOEOrderDtl1.UOESupplierCd != uOEOrderDtl2.UOESupplierCd) resList.Add("UOESupplierCd");
            if (uOEOrderDtl1.UOESupplierName != uOEOrderDtl2.UOESupplierName) resList.Add("UOESupplierName");
            if (uOEOrderDtl1.CommAssemblyId != uOEOrderDtl2.CommAssemblyId) resList.Add("CommAssemblyId");
            if (uOEOrderDtl1.OnlineNo != uOEOrderDtl2.OnlineNo) resList.Add("OnlineNo");
            if (uOEOrderDtl1.OnlineRowNo != uOEOrderDtl2.OnlineRowNo) resList.Add("OnlineRowNo");
            if (uOEOrderDtl1.SalesDate != uOEOrderDtl2.SalesDate) resList.Add("SalesDate");
            if (uOEOrderDtl1.InputDay != uOEOrderDtl2.InputDay) resList.Add("InputDay");
            if (uOEOrderDtl1.DataUpdateDateTime != uOEOrderDtl2.DataUpdateDateTime) resList.Add("DataUpdateDateTime");
            if (uOEOrderDtl1.UOEKind != uOEOrderDtl2.UOEKind) resList.Add("UOEKind");
            if (uOEOrderDtl1.SalesSlipNum != uOEOrderDtl2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (uOEOrderDtl1.AcptAnOdrStatus != uOEOrderDtl2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (uOEOrderDtl1.SalesSlipDtlNum != uOEOrderDtl2.SalesSlipDtlNum) resList.Add("SalesSlipDtlNum");
            if (uOEOrderDtl1.SectionCode != uOEOrderDtl2.SectionCode) resList.Add("SectionCode");
            if (uOEOrderDtl1.SubSectionCode != uOEOrderDtl2.SubSectionCode) resList.Add("SubSectionCode");
            if (uOEOrderDtl1.CustomerCode != uOEOrderDtl2.CustomerCode) resList.Add("CustomerCode");
            if (uOEOrderDtl1.CustomerSnm != uOEOrderDtl2.CustomerSnm) resList.Add("CustomerSnm");
            if (uOEOrderDtl1.CashRegisterNo != uOEOrderDtl2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (uOEOrderDtl1.CommonSeqNo != uOEOrderDtl2.CommonSeqNo) resList.Add("CommonSeqNo");
            if (uOEOrderDtl1.SupplierFormal != uOEOrderDtl2.SupplierFormal) resList.Add("SupplierFormal");
            if (uOEOrderDtl1.SupplierSlipNo != uOEOrderDtl2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (uOEOrderDtl1.StockSlipDtlNum != uOEOrderDtl2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (uOEOrderDtl1.BoCode != uOEOrderDtl2.BoCode) resList.Add("BoCode");
            if (uOEOrderDtl1.UOEDeliGoodsDiv != uOEOrderDtl2.UOEDeliGoodsDiv) resList.Add("UOEDeliGoodsDiv");
            if (uOEOrderDtl1.DeliveredGoodsDivNm != uOEOrderDtl2.DeliveredGoodsDivNm) resList.Add("DeliveredGoodsDivNm");
            if (uOEOrderDtl1.FollowDeliGoodsDiv != uOEOrderDtl2.FollowDeliGoodsDiv) resList.Add("FollowDeliGoodsDiv");
            if (uOEOrderDtl1.FollowDeliGoodsDivNm != uOEOrderDtl2.FollowDeliGoodsDivNm) resList.Add("FollowDeliGoodsDivNm");
            if (uOEOrderDtl1.UOEResvdSection != uOEOrderDtl2.UOEResvdSection) resList.Add("UOEResvdSection");
            if (uOEOrderDtl1.UOEResvdSectionNm != uOEOrderDtl2.UOEResvdSectionNm) resList.Add("UOEResvdSectionNm");
            if (uOEOrderDtl1.EmployeeCode != uOEOrderDtl2.EmployeeCode) resList.Add("EmployeeCode");
            if (uOEOrderDtl1.EmployeeName != uOEOrderDtl2.EmployeeName) resList.Add("EmployeeName");
            if (uOEOrderDtl1.GoodsMakerCd != uOEOrderDtl2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (uOEOrderDtl1.MakerName != uOEOrderDtl2.MakerName) resList.Add("MakerName");
            if (uOEOrderDtl1.GoodsNo != uOEOrderDtl2.GoodsNo) resList.Add("GoodsNo");
            if (uOEOrderDtl1.GoodsNoNoneHyphen != uOEOrderDtl2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (uOEOrderDtl1.GoodsName != uOEOrderDtl2.GoodsName) resList.Add("GoodsName");
            if (uOEOrderDtl1.WarehouseCode != uOEOrderDtl2.WarehouseCode) resList.Add("WarehouseCode");
            if (uOEOrderDtl1.WarehouseName != uOEOrderDtl2.WarehouseName) resList.Add("WarehouseName");
            if (uOEOrderDtl1.WarehouseShelfNo != uOEOrderDtl2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (uOEOrderDtl1.AcceptAnOrderCnt != uOEOrderDtl2.AcceptAnOrderCnt) resList.Add("AcceptAnOrderCnt");
            if (uOEOrderDtl1.ListPrice != uOEOrderDtl2.ListPrice) resList.Add("ListPrice");
            if (uOEOrderDtl1.SalesUnitCost != uOEOrderDtl2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (uOEOrderDtl1.SupplierCd != uOEOrderDtl2.SupplierCd) resList.Add("SupplierCd");
            if (uOEOrderDtl1.SupplierSnm != uOEOrderDtl2.SupplierSnm) resList.Add("SupplierSnm");
            if (uOEOrderDtl1.UoeRemark1 != uOEOrderDtl2.UoeRemark1) resList.Add("UoeRemark1");
            if (uOEOrderDtl1.UoeRemark2 != uOEOrderDtl2.UoeRemark2) resList.Add("UoeRemark2");
            if (uOEOrderDtl1.ReceiveDate != uOEOrderDtl2.ReceiveDate) resList.Add("ReceiveDate");
            if (uOEOrderDtl1.ReceiveTime != uOEOrderDtl2.ReceiveTime) resList.Add("ReceiveTime");
            if (uOEOrderDtl1.AnswerMakerCd != uOEOrderDtl2.AnswerMakerCd) resList.Add("AnswerMakerCd");
            if (uOEOrderDtl1.AnswerPartsNo != uOEOrderDtl2.AnswerPartsNo) resList.Add("AnswerPartsNo");
            if (uOEOrderDtl1.AnswerPartsName != uOEOrderDtl2.AnswerPartsName) resList.Add("AnswerPartsName");
            if (uOEOrderDtl1.SubstPartsNo != uOEOrderDtl2.SubstPartsNo) resList.Add("SubstPartsNo");
            if (uOEOrderDtl1.UOESectOutGoodsCnt != uOEOrderDtl2.UOESectOutGoodsCnt) resList.Add("UOESectOutGoodsCnt");
            if (uOEOrderDtl1.BOShipmentCnt1 != uOEOrderDtl2.BOShipmentCnt1) resList.Add("BOShipmentCnt1");
            if (uOEOrderDtl1.BOShipmentCnt2 != uOEOrderDtl2.BOShipmentCnt2) resList.Add("BOShipmentCnt2");
            if (uOEOrderDtl1.BOShipmentCnt3 != uOEOrderDtl2.BOShipmentCnt3) resList.Add("BOShipmentCnt3");
            if (uOEOrderDtl1.MakerFollowCnt != uOEOrderDtl2.MakerFollowCnt) resList.Add("MakerFollowCnt");
            if (uOEOrderDtl1.NonShipmentCnt != uOEOrderDtl2.NonShipmentCnt) resList.Add("NonShipmentCnt");
            if (uOEOrderDtl1.UOESectStockCnt != uOEOrderDtl2.UOESectStockCnt) resList.Add("UOESectStockCnt");
            if (uOEOrderDtl1.BOStockCount1 != uOEOrderDtl2.BOStockCount1) resList.Add("BOStockCount1");
            if (uOEOrderDtl1.BOStockCount2 != uOEOrderDtl2.BOStockCount2) resList.Add("BOStockCount2");
            if (uOEOrderDtl1.BOStockCount3 != uOEOrderDtl2.BOStockCount3) resList.Add("BOStockCount3");
            if (uOEOrderDtl1.UOESectionSlipNo != uOEOrderDtl2.UOESectionSlipNo) resList.Add("UOESectionSlipNo");
            if (uOEOrderDtl1.BOSlipNo1 != uOEOrderDtl2.BOSlipNo1) resList.Add("BOSlipNo1");
            if (uOEOrderDtl1.BOSlipNo2 != uOEOrderDtl2.BOSlipNo2) resList.Add("BOSlipNo2");
            if (uOEOrderDtl1.BOSlipNo3 != uOEOrderDtl2.BOSlipNo3) resList.Add("BOSlipNo3");
            if (uOEOrderDtl1.EOAlwcCount != uOEOrderDtl2.EOAlwcCount) resList.Add("EOAlwcCount");
            if (uOEOrderDtl1.BOManagementNo != uOEOrderDtl2.BOManagementNo) resList.Add("BOManagementNo");
            if (uOEOrderDtl1.AnswerListPrice != uOEOrderDtl2.AnswerListPrice) resList.Add("AnswerListPrice");
            if (uOEOrderDtl1.AnswerSalesUnitCost != uOEOrderDtl2.AnswerSalesUnitCost) resList.Add("AnswerSalesUnitCost");
            if (uOEOrderDtl1.UOESubstMark != uOEOrderDtl2.UOESubstMark) resList.Add("UOESubstMark");
            if (uOEOrderDtl1.UOEStockMark != uOEOrderDtl2.UOEStockMark) resList.Add("UOEStockMark");
            if (uOEOrderDtl1.PartsLayerCd != uOEOrderDtl2.PartsLayerCd) resList.Add("PartsLayerCd");
            if (uOEOrderDtl1.MazdaUOEShipSectCd1 != uOEOrderDtl2.MazdaUOEShipSectCd1) resList.Add("MazdaUOEShipSectCd1");
            if (uOEOrderDtl1.MazdaUOEShipSectCd2 != uOEOrderDtl2.MazdaUOEShipSectCd2) resList.Add("MazdaUOEShipSectCd2");
            if (uOEOrderDtl1.MazdaUOEShipSectCd3 != uOEOrderDtl2.MazdaUOEShipSectCd3) resList.Add("MazdaUOEShipSectCd3");
            if (uOEOrderDtl1.MazdaUOESectCd1 != uOEOrderDtl2.MazdaUOESectCd1) resList.Add("MazdaUOESectCd1");
            if (uOEOrderDtl1.MazdaUOESectCd2 != uOEOrderDtl2.MazdaUOESectCd2) resList.Add("MazdaUOESectCd2");
            if (uOEOrderDtl1.MazdaUOESectCd3 != uOEOrderDtl2.MazdaUOESectCd3) resList.Add("MazdaUOESectCd3");
            if (uOEOrderDtl1.MazdaUOESectCd4 != uOEOrderDtl2.MazdaUOESectCd4) resList.Add("MazdaUOESectCd4");
            if (uOEOrderDtl1.MazdaUOESectCd5 != uOEOrderDtl2.MazdaUOESectCd5) resList.Add("MazdaUOESectCd5");
            if (uOEOrderDtl1.MazdaUOESectCd6 != uOEOrderDtl2.MazdaUOESectCd6) resList.Add("MazdaUOESectCd6");
            if (uOEOrderDtl1.MazdaUOESectCd7 != uOEOrderDtl2.MazdaUOESectCd7) resList.Add("MazdaUOESectCd7");
            if (uOEOrderDtl1.MazdaUOEStockCnt1 != uOEOrderDtl2.MazdaUOEStockCnt1) resList.Add("MazdaUOEStockCnt1");
            if (uOEOrderDtl1.MazdaUOEStockCnt2 != uOEOrderDtl2.MazdaUOEStockCnt2) resList.Add("MazdaUOEStockCnt2");
            if (uOEOrderDtl1.MazdaUOEStockCnt3 != uOEOrderDtl2.MazdaUOEStockCnt3) resList.Add("MazdaUOEStockCnt3");
            if (uOEOrderDtl1.MazdaUOEStockCnt4 != uOEOrderDtl2.MazdaUOEStockCnt4) resList.Add("MazdaUOEStockCnt4");
            if (uOEOrderDtl1.MazdaUOEStockCnt5 != uOEOrderDtl2.MazdaUOEStockCnt5) resList.Add("MazdaUOEStockCnt5");
            if (uOEOrderDtl1.MazdaUOEStockCnt6 != uOEOrderDtl2.MazdaUOEStockCnt6) resList.Add("MazdaUOEStockCnt6");
            if (uOEOrderDtl1.MazdaUOEStockCnt7 != uOEOrderDtl2.MazdaUOEStockCnt7) resList.Add("MazdaUOEStockCnt7");
            if (uOEOrderDtl1.UOEDistributionCd != uOEOrderDtl2.UOEDistributionCd) resList.Add("UOEDistributionCd");
            if (uOEOrderDtl1.UOEOtherCd != uOEOrderDtl2.UOEOtherCd) resList.Add("UOEOtherCd");
            if (uOEOrderDtl1.UOEHMCd != uOEOrderDtl2.UOEHMCd) resList.Add("UOEHMCd");
            if (uOEOrderDtl1.BOCount != uOEOrderDtl2.BOCount) resList.Add("BOCount");
            if (uOEOrderDtl1.UOEMarkCode != uOEOrderDtl2.UOEMarkCode) resList.Add("UOEMarkCode");
            if (uOEOrderDtl1.SourceShipment != uOEOrderDtl2.SourceShipment) resList.Add("SourceShipment");
            if (uOEOrderDtl1.ItemCode != uOEOrderDtl2.ItemCode) resList.Add("ItemCode");
            if (uOEOrderDtl1.UOECheckCode != uOEOrderDtl2.UOECheckCode) resList.Add("UOECheckCode");
            if (uOEOrderDtl1.HeadErrorMassage != uOEOrderDtl2.HeadErrorMassage) resList.Add("HeadErrorMassage");
            if (uOEOrderDtl1.LineErrorMassage != uOEOrderDtl2.LineErrorMassage) resList.Add("LineErrorMassage");
            if (uOEOrderDtl1.DataSendCode != uOEOrderDtl2.DataSendCode) resList.Add("DataSendCode");
            if (uOEOrderDtl1.DataRecoverDiv != uOEOrderDtl2.DataRecoverDiv) resList.Add("DataRecoverDiv");
            if (uOEOrderDtl1.EnterUpdDivSec != uOEOrderDtl2.EnterUpdDivSec) resList.Add("EnterUpdDivSec");
            if (uOEOrderDtl1.EnterUpdDivBO1 != uOEOrderDtl2.EnterUpdDivBO1) resList.Add("EnterUpdDivBO1");
            if (uOEOrderDtl1.EnterUpdDivBO2 != uOEOrderDtl2.EnterUpdDivBO2) resList.Add("EnterUpdDivBO2");
            if (uOEOrderDtl1.EnterUpdDivBO3 != uOEOrderDtl2.EnterUpdDivBO3) resList.Add("EnterUpdDivBO3");
            if (uOEOrderDtl1.EnterUpdDivMaker != uOEOrderDtl2.EnterUpdDivMaker) resList.Add("EnterUpdDivMaker");
            if (uOEOrderDtl1.EnterUpdDivEO != uOEOrderDtl2.EnterUpdDivEO) resList.Add("EnterUpdDivEO");
            if (uOEOrderDtl1.DtlRelationGuid != uOEOrderDtl2.DtlRelationGuid) resList.Add("DtlRelationGuid");
            if (uOEOrderDtl1.EnterpriseName != uOEOrderDtl2.EnterpriseName) resList.Add("EnterpriseName");
            if (uOEOrderDtl1.UpdEmployeeName != uOEOrderDtl2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}