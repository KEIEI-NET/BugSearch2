using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UOEAnswerLedgerResultWork
    /// <summary>
    ///                      UOE回答表示(元帳タイプ)抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE回答表示(元帳タイプ)抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/09/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOEAnswerLedgerResultWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

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

        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>レジ番号</summary>
        /// <remarks>端末番号</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>BO区分</summary>
        private string _boCode = "";

        /// <summary>納品区分</summary>
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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

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
        /// <summary>納品区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品区分プロパティ</br>
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


        /// <summary>
        /// UOE回答表示(元帳タイプ)抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>UOEAnswerLedgerResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEAnswerLedgerResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>UOEAnswerLedgerResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   UOEAnswerLedgerResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class UOEAnswerLedgerResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  UOEAnswerLedgerResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is UOEAnswerLedgerResultWork || graph is ArrayList || graph is UOEAnswerLedgerResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(UOEAnswerLedgerResultWork).FullName));

            if (graph != null && graph is UOEAnswerLedgerResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UOEAnswerLedgerResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is UOEAnswerLedgerResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((UOEAnswerLedgerResultWork[])graph).Length;
            }
            else if (graph is UOEAnswerLedgerResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //システム区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SystemDivCd
            //UOE発注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESalesOrderNo
            //UOE発注行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESalesOrderRowNo
            //送信端末番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SendTerminalNo
            //UOE発注先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //UOE発注先名称
            serInfo.MemberInfo.Add(typeof(string)); //UOESupplierName
            //通信アセンブリID
            serInfo.MemberInfo.Add(typeof(string)); //CommAssemblyId
            //オンライン番号
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineNo
            //オンライン行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineRowNo
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //データ更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //DataUpdateDateTime
            //UOE種別
            serInfo.MemberInfo.Add(typeof(Int32)); //UOEKind
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //レジ番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CashRegisterNo
            //BO区分
            serInfo.MemberInfo.Add(typeof(string)); //BoCode
            //納品区分
            serInfo.MemberInfo.Add(typeof(string)); //UOEDeliGoodsDiv
            //納品区分名称
            serInfo.MemberInfo.Add(typeof(string)); //DeliveredGoodsDivNm
            //フォロー納品区分
            serInfo.MemberInfo.Add(typeof(string)); //FollowDeliGoodsDiv
            //フォロー納品区分名称
            serInfo.MemberInfo.Add(typeof(string)); //FollowDeliGoodsDivNm
            //UOE指定拠点
            serInfo.MemberInfo.Add(typeof(string)); //UOEResvdSection
            //UOE指定拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //UOEResvdSectionNm
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //ハイフン無商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //受注数量
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //定価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //受信日付
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiveDate
            //受信時刻
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiveTime
            //回答メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerMakerCd
            //回答品番
            serInfo.MemberInfo.Add(typeof(string)); //AnswerPartsNo
            //回答品名
            serInfo.MemberInfo.Add(typeof(string)); //AnswerPartsName
            //代替品番
            serInfo.MemberInfo.Add(typeof(string)); //SubstPartsNo
            //UOE拠点出庫数
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESectOutGoodsCnt
            //BO出庫数1
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt1
            //BO出庫数2
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt2
            //BO出庫数3
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt3
            //メーカーフォロー数
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerFollowCnt
            //未出庫数
            serInfo.MemberInfo.Add(typeof(Int32)); //NonShipmentCnt
            //UOE拠点在庫数
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESectStockCnt
            //BO在庫数1
            serInfo.MemberInfo.Add(typeof(Int32)); //BOStockCount1
            //BO在庫数2
            serInfo.MemberInfo.Add(typeof(Int32)); //BOStockCount2
            //BO在庫数3
            serInfo.MemberInfo.Add(typeof(Int32)); //BOStockCount3
            //UOE拠点伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //UOESectionSlipNo
            //BO伝票番号１
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo1
            //BO伝票番号２
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo2
            //BO伝票番号３
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo3
            //EO引当数
            serInfo.MemberInfo.Add(typeof(Int32)); //EOAlwcCount
            //BO管理番号
            serInfo.MemberInfo.Add(typeof(string)); //BOManagementNo
            //回答定価
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerListPrice
            //回答原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerSalesUnitCost
            //UOE代替マーク
            serInfo.MemberInfo.Add(typeof(string)); //UOESubstMark
            //UOE在庫マーク
            serInfo.MemberInfo.Add(typeof(string)); //UOEStockMark
            //層別コード
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //UOE出荷拠点コード１（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOEShipSectCd1
            //UOE出荷拠点コード２（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOEShipSectCd2
            //UOE出荷拠点コード３（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOEShipSectCd3
            //UOE拠点コード１（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd1
            //UOE拠点コード２（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd2
            //UOE拠点コード３（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd3
            //UOE拠点コード４（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd4
            //UOE拠点コード５（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd5
            //UOE拠点コード６（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd6
            //UOE拠点コード７（マツダ）
            serInfo.MemberInfo.Add(typeof(string)); //MazdaUOESectCd7
            //UOE在庫数１（マツダ）
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt1
            //UOE在庫数２（マツダ）
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt2
            //UOE在庫数３（マツダ）
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt3
            //UOE在庫数４（マツダ）
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt4
            //UOE在庫数５（マツダ）
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt5
            //UOE在庫数６（マツダ）
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt6
            //UOE在庫数７（マツダ）
            serInfo.MemberInfo.Add(typeof(Int32)); //MazdaUOEStockCnt7
            //UOE卸コード
            serInfo.MemberInfo.Add(typeof(string)); //UOEDistributionCd
            //UOE他コード
            serInfo.MemberInfo.Add(typeof(string)); //UOEOtherCd
            //UOEＨＭコード
            serInfo.MemberInfo.Add(typeof(string)); //UOEHMCd
            //ＢＯ数
            serInfo.MemberInfo.Add(typeof(Int32)); //BOCount
            //UOEマークコード
            serInfo.MemberInfo.Add(typeof(string)); //UOEMarkCode
            //出荷元
            serInfo.MemberInfo.Add(typeof(string)); //SourceShipment
            //アイテムコード
            serInfo.MemberInfo.Add(typeof(string)); //ItemCode
            //UOEチェックコード
            serInfo.MemberInfo.Add(typeof(string)); //UOECheckCode
            //ヘッドエラーメッセージ
            serInfo.MemberInfo.Add(typeof(string)); //HeadErrorMassage
            //ラインエラーメッセージ
            serInfo.MemberInfo.Add(typeof(string)); //LineErrorMassage


            serInfo.Serialize(writer, serInfo);
            if (graph is UOEAnswerLedgerResultWork)
            {
                UOEAnswerLedgerResultWork temp = (UOEAnswerLedgerResultWork)graph;

                SetUOEAnswerLedgerResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is UOEAnswerLedgerResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((UOEAnswerLedgerResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (UOEAnswerLedgerResultWork temp in lst)
                {
                    SetUOEAnswerLedgerResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// UOEAnswerLedgerResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 105;

        /// <summary>
        ///  UOEAnswerLedgerResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetUOEAnswerLedgerResultWork(System.IO.BinaryWriter writer, UOEAnswerLedgerResultWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //システム区分
            writer.Write(temp.SystemDivCd);
            //UOE発注番号
            writer.Write(temp.UOESalesOrderNo);
            //UOE発注行番号
            writer.Write(temp.UOESalesOrderRowNo);
            //送信端末番号
            writer.Write(temp.SendTerminalNo);
            //UOE発注先コード
            writer.Write(temp.UOESupplierCd);
            //UOE発注先名称
            writer.Write(temp.UOESupplierName);
            //通信アセンブリID
            writer.Write(temp.CommAssemblyId);
            //オンライン番号
            writer.Write(temp.OnlineNo);
            //オンライン行番号
            writer.Write(temp.OnlineRowNo);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //入力日
            writer.Write((Int64)temp.InputDay.Ticks);
            //データ更新日時
            writer.Write((Int64)temp.DataUpdateDateTime.Ticks);
            //UOE種別
            writer.Write(temp.UOEKind);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //レジ番号
            writer.Write(temp.CashRegisterNo);
            //BO区分
            writer.Write(temp.BoCode);
            //納品区分
            writer.Write(temp.UOEDeliGoodsDiv);
            //納品区分名称
            writer.Write(temp.DeliveredGoodsDivNm);
            //フォロー納品区分
            writer.Write(temp.FollowDeliGoodsDiv);
            //フォロー納品区分名称
            writer.Write(temp.FollowDeliGoodsDivNm);
            //UOE指定拠点
            writer.Write(temp.UOEResvdSection);
            //UOE指定拠点名称
            writer.Write(temp.UOEResvdSectionNm);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //従業員名称
            writer.Write(temp.EmployeeName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //ハイフン無商品番号
            writer.Write(temp.GoodsNoNoneHyphen);
            //商品名称
            writer.Write(temp.GoodsName);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //受注数量
            writer.Write(temp.AcceptAnOrderCnt);
            //定価（浮動）
            writer.Write(temp.ListPrice);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //ＵＯＥリマーク２
            writer.Write(temp.UoeRemark2);
            //受信日付
            writer.Write((Int64)temp.ReceiveDate.Ticks);
            //受信時刻
            writer.Write(temp.ReceiveTime);
            //回答メーカーコード
            writer.Write(temp.AnswerMakerCd);
            //回答品番
            writer.Write(temp.AnswerPartsNo);
            //回答品名
            writer.Write(temp.AnswerPartsName);
            //代替品番
            writer.Write(temp.SubstPartsNo);
            //UOE拠点出庫数
            writer.Write(temp.UOESectOutGoodsCnt);
            //BO出庫数1
            writer.Write(temp.BOShipmentCnt1);
            //BO出庫数2
            writer.Write(temp.BOShipmentCnt2);
            //BO出庫数3
            writer.Write(temp.BOShipmentCnt3);
            //メーカーフォロー数
            writer.Write(temp.MakerFollowCnt);
            //未出庫数
            writer.Write(temp.NonShipmentCnt);
            //UOE拠点在庫数
            writer.Write(temp.UOESectStockCnt);
            //BO在庫数1
            writer.Write(temp.BOStockCount1);
            //BO在庫数2
            writer.Write(temp.BOStockCount2);
            //BO在庫数3
            writer.Write(temp.BOStockCount3);
            //UOE拠点伝票番号
            writer.Write(temp.UOESectionSlipNo);
            //BO伝票番号１
            writer.Write(temp.BOSlipNo1);
            //BO伝票番号２
            writer.Write(temp.BOSlipNo2);
            //BO伝票番号３
            writer.Write(temp.BOSlipNo3);
            //EO引当数
            writer.Write(temp.EOAlwcCount);
            //BO管理番号
            writer.Write(temp.BOManagementNo);
            //回答定価
            writer.Write(temp.AnswerListPrice);
            //回答原価単価
            writer.Write(temp.AnswerSalesUnitCost);
            //UOE代替マーク
            writer.Write(temp.UOESubstMark);
            //UOE在庫マーク
            writer.Write(temp.UOEStockMark);
            //層別コード
            writer.Write(temp.PartsLayerCd);
            //UOE出荷拠点コード１（マツダ）
            writer.Write(temp.MazdaUOEShipSectCd1);
            //UOE出荷拠点コード２（マツダ）
            writer.Write(temp.MazdaUOEShipSectCd2);
            //UOE出荷拠点コード３（マツダ）
            writer.Write(temp.MazdaUOEShipSectCd3);
            //UOE拠点コード１（マツダ）
            writer.Write(temp.MazdaUOESectCd1);
            //UOE拠点コード２（マツダ）
            writer.Write(temp.MazdaUOESectCd2);
            //UOE拠点コード３（マツダ）
            writer.Write(temp.MazdaUOESectCd3);
            //UOE拠点コード４（マツダ）
            writer.Write(temp.MazdaUOESectCd4);
            //UOE拠点コード５（マツダ）
            writer.Write(temp.MazdaUOESectCd5);
            //UOE拠点コード６（マツダ）
            writer.Write(temp.MazdaUOESectCd6);
            //UOE拠点コード７（マツダ）
            writer.Write(temp.MazdaUOESectCd7);
            //UOE在庫数１（マツダ）
            writer.Write(temp.MazdaUOEStockCnt1);
            //UOE在庫数２（マツダ）
            writer.Write(temp.MazdaUOEStockCnt2);
            //UOE在庫数３（マツダ）
            writer.Write(temp.MazdaUOEStockCnt3);
            //UOE在庫数４（マツダ）
            writer.Write(temp.MazdaUOEStockCnt4);
            //UOE在庫数５（マツダ）
            writer.Write(temp.MazdaUOEStockCnt5);
            //UOE在庫数６（マツダ）
            writer.Write(temp.MazdaUOEStockCnt6);
            //UOE在庫数７（マツダ）
            writer.Write(temp.MazdaUOEStockCnt7);
            //UOE卸コード
            writer.Write(temp.UOEDistributionCd);
            //UOE他コード
            writer.Write(temp.UOEOtherCd);
            //UOEＨＭコード
            writer.Write(temp.UOEHMCd);
            //ＢＯ数
            writer.Write(temp.BOCount);
            //UOEマークコード
            writer.Write(temp.UOEMarkCode);
            //出荷元
            writer.Write(temp.SourceShipment);
            //アイテムコード
            writer.Write(temp.ItemCode);
            //UOEチェックコード
            writer.Write(temp.UOECheckCode);
            //ヘッドエラーメッセージ
            writer.Write(temp.HeadErrorMassage);
            //ラインエラーメッセージ
            writer.Write(temp.LineErrorMassage);

        }

        /// <summary>
        ///  UOEAnswerLedgerResultWorkインスタンス取得
        /// </summary>
        /// <returns>UOEAnswerLedgerResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private UOEAnswerLedgerResultWork GetUOEAnswerLedgerResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            UOEAnswerLedgerResultWork temp = new UOEAnswerLedgerResultWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //システム区分
            temp.SystemDivCd = reader.ReadInt32();
            //UOE発注番号
            temp.UOESalesOrderNo = reader.ReadInt32();
            //UOE発注行番号
            temp.UOESalesOrderRowNo = reader.ReadInt32();
            //送信端末番号
            temp.SendTerminalNo = reader.ReadInt32();
            //UOE発注先コード
            temp.UOESupplierCd = reader.ReadInt32();
            //UOE発注先名称
            temp.UOESupplierName = reader.ReadString();
            //通信アセンブリID
            temp.CommAssemblyId = reader.ReadString();
            //オンライン番号
            temp.OnlineNo = reader.ReadInt32();
            //オンライン行番号
            temp.OnlineRowNo = reader.ReadInt32();
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //入力日
            temp.InputDay = new DateTime(reader.ReadInt64());
            //データ更新日時
            temp.DataUpdateDateTime = new DateTime(reader.ReadInt64());
            //UOE種別
            temp.UOEKind = reader.ReadInt32();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //レジ番号
            temp.CashRegisterNo = reader.ReadInt32();
            //BO区分
            temp.BoCode = reader.ReadString();
            //納品区分
            temp.UOEDeliGoodsDiv = reader.ReadString();
            //納品区分名称
            temp.DeliveredGoodsDivNm = reader.ReadString();
            //フォロー納品区分
            temp.FollowDeliGoodsDiv = reader.ReadString();
            //フォロー納品区分名称
            temp.FollowDeliGoodsDivNm = reader.ReadString();
            //UOE指定拠点
            temp.UOEResvdSection = reader.ReadString();
            //UOE指定拠点名称
            temp.UOEResvdSectionNm = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //従業員名称
            temp.EmployeeName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //ハイフン無商品番号
            temp.GoodsNoNoneHyphen = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //受注数量
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //定価（浮動）
            temp.ListPrice = reader.ReadDouble();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２
            temp.UoeRemark2 = reader.ReadString();
            //受信日付
            temp.ReceiveDate = new DateTime(reader.ReadInt64());
            //受信時刻
            temp.ReceiveTime = reader.ReadInt32();
            //回答メーカーコード
            temp.AnswerMakerCd = reader.ReadInt32();
            //回答品番
            temp.AnswerPartsNo = reader.ReadString();
            //回答品名
            temp.AnswerPartsName = reader.ReadString();
            //代替品番
            temp.SubstPartsNo = reader.ReadString();
            //UOE拠点出庫数
            temp.UOESectOutGoodsCnt = reader.ReadInt32();
            //BO出庫数1
            temp.BOShipmentCnt1 = reader.ReadInt32();
            //BO出庫数2
            temp.BOShipmentCnt2 = reader.ReadInt32();
            //BO出庫数3
            temp.BOShipmentCnt3 = reader.ReadInt32();
            //メーカーフォロー数
            temp.MakerFollowCnt = reader.ReadInt32();
            //未出庫数
            temp.NonShipmentCnt = reader.ReadInt32();
            //UOE拠点在庫数
            temp.UOESectStockCnt = reader.ReadInt32();
            //BO在庫数1
            temp.BOStockCount1 = reader.ReadInt32();
            //BO在庫数2
            temp.BOStockCount2 = reader.ReadInt32();
            //BO在庫数3
            temp.BOStockCount3 = reader.ReadInt32();
            //UOE拠点伝票番号
            temp.UOESectionSlipNo = reader.ReadString();
            //BO伝票番号１
            temp.BOSlipNo1 = reader.ReadString();
            //BO伝票番号２
            temp.BOSlipNo2 = reader.ReadString();
            //BO伝票番号３
            temp.BOSlipNo3 = reader.ReadString();
            //EO引当数
            temp.EOAlwcCount = reader.ReadInt32();
            //BO管理番号
            temp.BOManagementNo = reader.ReadString();
            //回答定価
            temp.AnswerListPrice = reader.ReadDouble();
            //回答原価単価
            temp.AnswerSalesUnitCost = reader.ReadDouble();
            //UOE代替マーク
            temp.UOESubstMark = reader.ReadString();
            //UOE在庫マーク
            temp.UOEStockMark = reader.ReadString();
            //層別コード
            temp.PartsLayerCd = reader.ReadString();
            //UOE出荷拠点コード１（マツダ）
            temp.MazdaUOEShipSectCd1 = reader.ReadString();
            //UOE出荷拠点コード２（マツダ）
            temp.MazdaUOEShipSectCd2 = reader.ReadString();
            //UOE出荷拠点コード３（マツダ）
            temp.MazdaUOEShipSectCd3 = reader.ReadString();
            //UOE拠点コード１（マツダ）
            temp.MazdaUOESectCd1 = reader.ReadString();
            //UOE拠点コード２（マツダ）
            temp.MazdaUOESectCd2 = reader.ReadString();
            //UOE拠点コード３（マツダ）
            temp.MazdaUOESectCd3 = reader.ReadString();
            //UOE拠点コード４（マツダ）
            temp.MazdaUOESectCd4 = reader.ReadString();
            //UOE拠点コード５（マツダ）
            temp.MazdaUOESectCd5 = reader.ReadString();
            //UOE拠点コード６（マツダ）
            temp.MazdaUOESectCd6 = reader.ReadString();
            //UOE拠点コード７（マツダ）
            temp.MazdaUOESectCd7 = reader.ReadString();
            //UOE在庫数１（マツダ）
            temp.MazdaUOEStockCnt1 = reader.ReadInt32();
            //UOE在庫数２（マツダ）
            temp.MazdaUOEStockCnt2 = reader.ReadInt32();
            //UOE在庫数３（マツダ）
            temp.MazdaUOEStockCnt3 = reader.ReadInt32();
            //UOE在庫数４（マツダ）
            temp.MazdaUOEStockCnt4 = reader.ReadInt32();
            //UOE在庫数５（マツダ）
            temp.MazdaUOEStockCnt5 = reader.ReadInt32();
            //UOE在庫数６（マツダ）
            temp.MazdaUOEStockCnt6 = reader.ReadInt32();
            //UOE在庫数７（マツダ）
            temp.MazdaUOEStockCnt7 = reader.ReadInt32();
            //UOE卸コード
            temp.UOEDistributionCd = reader.ReadString();
            //UOE他コード
            temp.UOEOtherCd = reader.ReadString();
            //UOEＨＭコード
            temp.UOEHMCd = reader.ReadString();
            //ＢＯ数
            temp.BOCount = reader.ReadInt32();
            //UOEマークコード
            temp.UOEMarkCode = reader.ReadString();
            //出荷元
            temp.SourceShipment = reader.ReadString();
            //アイテムコード
            temp.ItemCode = reader.ReadString();
            //UOEチェックコード
            temp.UOECheckCode = reader.ReadString();
            //ヘッドエラーメッセージ
            temp.HeadErrorMassage = reader.ReadString();
            //ラインエラーメッセージ
            temp.LineErrorMassage = reader.ReadString();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>UOEAnswerLedgerResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEAnswerLedgerResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                UOEAnswerLedgerResultWork temp = GetUOEAnswerLedgerResultWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (UOEAnswerLedgerResultWork[])lst.ToArray(typeof(UOEAnswerLedgerResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
