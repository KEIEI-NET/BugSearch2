//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 日産回答データ取込処理
// プログラム概要   : UOE発注データと発注回答データのつけ合わせを行い、
//                    売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 李占川
// 作 成 日  2010/03/08  修正内容 : 新規作成
//                                 【要件No.6】UOE発注データと発注回答データのつけ合わせを行い、売上・仕入データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : liyp
// 修 正 日  2011/03/01  修正内容 : 日産UOE自動化B対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOEOrderDtlInfo
    /// <summary>
    ///                      回答データ取込処理テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   回答データ取込処理テーブルスキーマ定義クラスヘッダファイル</br>
    /// <br>Programmer       :   李占川</br>
    /// <br>Date             :   2010/03/08</br>
    /// <br>UpdateNote       : 2011/03/01 liyp</br>
    /// <br>                  日産UOE自動化B対応 </br>
    /// <br> </br>
    /// </remarks>
    public class UOEOrderDtlInfo
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

        // --------ADD 2011/03/01 ----------->>>>>
        ///<summary>連携番号</summary>
        private string _renkeNo = "";
        // --------ADD 2011/03/01 -----------<<<<<

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

        // ------ADD 2011/03/01 ---------------------->>>>>
        // <summary>連携番号</summary>
        public string RenkeNo
        {
            get { return _renkeNo; }
            set { _renkeNo = value; }
        }
        // ------ADD 2011/03/01 ----------------------<<<<<

        /// <summary>
        /// UOE発注データワークコンストラクタ
        /// </summary>
        /// <returns>UOEOrderDtlNissanInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEOrderDtlNissanInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEOrderDtlInfo()
        {
        }
    }
}
