using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockMove
    /// <summary>
    ///                      在庫移動データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫移動データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/07/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/23  長内</br>
    /// <br>                 :   項目追加</br>
    /// <br>                 :   商品名称カナ</br>
    /// </remarks>
    public class StockMove
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

        /// <summary>在庫移動形式</summary>
        /// <remarks>1:在庫移動、2：倉庫移動</remarks>
        private Int32 _stockMoveFormal;

        /// <summary>在庫移動伝票番号</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>在庫移動行番号</summary>
        private Int32 _stockMoveRowNo;

        /// <summary>更新拠点コード</summary>
        /// <remarks>文字型 データの登録更新拠点</remarks>
        private string _updateSecCd = "";

        /// <summary>移動元拠点コード</summary>
        private string _bfSectionCode = "";

        /// <summary>移動元拠点ガイド略称</summary>
        private string _bfSectionGuideSnm = "";

        /// <summary>移動元倉庫コード</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>移動元倉庫名称</summary>
        private string _bfEnterWarehName = "";

        /// <summary>移動先拠点コード</summary>
        private string _afSectionCode = "";

        /// <summary>移動先拠点ガイド略称</summary>
        private string _afSectionGuideSnm = "";

        /// <summary>移動先倉庫コード</summary>
        private string _afEnterWarehCode = "";

        /// <summary>移動先倉庫名称</summary>
        private string _afEnterWarehName = "";

        /// <summary>出荷予定日</summary>
        /// <remarks>在庫移動処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentScdlDay;

        /// <summary>出荷確定日</summary>
        /// <remarks>出荷確定処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentFixDay;

        /// <summary>入荷日</summary>
        /// <remarks>在庫移動処理（入荷側）を行った時にセット</remarks>
        private DateTime _arrivalGoodsDay;

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _inputDay;

        /// <summary>移動状態</summary>
        /// <remarks>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</remarks>
        private Int32 _moveStatus;

        /// <summary>在庫移動入力従業員コード</summary>
        /// <remarks>在庫移動伝票を入力する従業員コードをセット</remarks>
        private string _stockMvEmpCode = "";

        /// <summary>在庫移動入力従業員名称</summary>
        private string _stockMvEmpName = "";

        /// <summary>出荷担当従業員コード</summary>
        /// <remarks>出荷確定処理を行う従業員コードをセット</remarks>
        private string _shipAgentCd = "";

        /// <summary>出荷担当従業員名称</summary>
        private string _shipAgentNm = "";

        /// <summary>引取担当従業員コード</summary>
        /// <remarks>在庫の入荷側の従業員コードをセット</remarks>
        private string _receiveAgentCd = "";

        /// <summary>引取担当従業員名称</summary>
        private string _receiveAgentNm = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>在庫区分</summary>
        /// <remarks>0:自社、1:受託</remarks>
        private Int32 _stockDiv;

        /// <summary>仕入単価（税抜,浮動）</summary>
        /// <remarks>在庫移動する在庫の仕入価格情報をセット</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>移動数</summary>
        private Double _moveCount;

        /// <summary>移動元棚番</summary>
        private string _bfShelfNo = "";

        /// <summary>移動先棚番</summary>
        private string _afShelfNo = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>定価（浮動）</summary>
        private Double _listPriceFl;

        /// <summary>伝票摘要</summary>
        /// <remarks>車販の場合、摘要+注文書№+管理番号を格納</remarks>
        private string _outline = "";

        /// <summary>倉庫備考1</summary>
        /// <remarks>在庫移動時の移動伝票に出力する備考をセット</remarks>
        private string _warehouseNote1 = "";

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>倉庫備考2</summary>
        /// <remarks>　〃</remarks>
        private string _warehouseNote2 = "";

        /// <summary>倉庫備考3</summary>
        /// <remarks>　〃</remarks>
        private string _warehouseNote3 = "";

        /// <summary>倉庫備考4</summary>
        /// <remarks>　〃</remarks>
        private string _warehouseNote4 = "";

        /// <summary>倉庫備考5</summary>
        /// <remarks>　〃</remarks>
        private string _warehouseNote5 = "";
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        /// <summary>伝票発行済区分</summary>
        /// <remarks>0:未発行 1:発行済</remarks>
        private Int32 _slipPrintFinishCd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";


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

        /// public propaty name  :  StockMoveFormal
        /// <summary>在庫移動形式プロパティ</summary>
        /// <value>1:在庫移動、2：倉庫移動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveFormal
        {
            get { return _stockMoveFormal; }
            set { _stockMoveFormal = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>在庫移動伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMoveRowNo
        /// <summary>在庫移動行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveRowNo
        {
            get { return _stockMoveRowNo; }
            set { _stockMoveRowNo = value; }
        }

        /// public propaty name  :  UpdateSecCd
        /// <summary>更新拠点コードプロパティ</summary>
        /// <value>文字型 データの登録更新拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>移動元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionGuideSnm
        /// <summary>移動元拠点ガイド略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionGuideSnm
        {
            get { return _bfSectionGuideSnm; }
            set { _bfSectionGuideSnm = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>移動元倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>移動元倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>移動先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionGuideSnm
        /// <summary>移動先拠点ガイド略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionGuideSnm
        {
            get { return _afSectionGuideSnm; }
            set { _afSectionGuideSnm = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>移動先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>移動先倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  ShipmentScdlDay
        /// <summary>出荷予定日プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentScdlDay
        {
            get { return _shipmentScdlDay; }
            set { _shipmentScdlDay = value; }
        }

        /// public propaty name  :  ShipmentScdlDayJpFormal
        /// <summary>出荷予定日 和暦プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentScdlDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _shipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentScdlDayJpInFormal
        /// <summary>出荷予定日 和暦(略)プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentScdlDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _shipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentScdlDayAdFormal
        /// <summary>出荷予定日 西暦プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentScdlDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _shipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentScdlDayAdInFormal
        /// <summary>出荷予定日 西暦(略)プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentScdlDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _shipmentScdlDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDay
        /// <summary>出荷確定日プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷確定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentFixDay
        {
            get { return _shipmentFixDay; }
            set { _shipmentFixDay = value; }
        }

        /// public propaty name  :  ShipmentFixDayJpFormal
        /// <summary>出荷確定日 和暦プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷確定日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentFixDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _shipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDayJpInFormal
        /// <summary>出荷確定日 和暦(略)プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷確定日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentFixDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _shipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDayAdFormal
        /// <summary>出荷確定日 西暦プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷確定日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentFixDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _shipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ShipmentFixDayAdInFormal
        /// <summary>出荷確定日 西暦(略)プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷確定日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipmentFixDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _shipmentFixDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>入荷日プロパティ</summary>
        /// <value>在庫移動処理（入荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDayJpFormal
        /// <summary>入荷日 和暦プロパティ</summary>
        /// <value>在庫移動処理（入荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ArrivalGoodsDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayJpInFormal
        /// <summary>入荷日 和暦(略)プロパティ</summary>
        /// <value>在庫移動処理（入荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ArrivalGoodsDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdFormal
        /// <summary>入荷日 西暦プロパティ</summary>
        /// <value>在庫移動処理（入荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ArrivalGoodsDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _arrivalGoodsDay); }
            set { }
        }

        /// public propaty name  :  ArrivalGoodsDayAdInFormal
        /// <summary>入荷日 西暦(略)プロパティ</summary>
        /// <value>在庫移動処理（入荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ArrivalGoodsDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _arrivalGoodsDay); }
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

        /// public propaty name  :  MoveStatus
        /// <summary>移動状態プロパティ</summary>
        /// <value>0:移動対象外、1:未出荷状態、2:移動中、9:入荷済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動状態プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MoveStatus
        {
            get { return _moveStatus; }
            set { _moveStatus = value; }
        }

        /// public propaty name  :  StockMvEmpCode
        /// <summary>在庫移動入力従業員コードプロパティ</summary>
        /// <value>在庫移動伝票を入力する従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動入力従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockMvEmpCode
        {
            get { return _stockMvEmpCode; }
            set { _stockMvEmpCode = value; }
        }

        /// public propaty name  :  StockMvEmpName
        /// <summary>在庫移動入力従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動入力従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockMvEmpName
        {
            get { return _stockMvEmpName; }
            set { _stockMvEmpName = value; }
        }

        /// public propaty name  :  ShipAgentCd
        /// <summary>出荷担当従業員コードプロパティ</summary>
        /// <value>出荷確定処理を行う従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipAgentCd
        {
            get { return _shipAgentCd; }
            set { _shipAgentCd = value; }
        }

        /// public propaty name  :  ShipAgentNm
        /// <summary>出荷担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShipAgentNm
        {
            get { return _shipAgentNm; }
            set { _shipAgentNm = value; }
        }

        /// public propaty name  :  ReceiveAgentCd
        /// <summary>引取担当従業員コードプロパティ</summary>
        /// <value>在庫の入荷側の従業員コードをセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引取担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReceiveAgentCd
        {
            get { return _receiveAgentCd; }
            set { _receiveAgentCd = value; }
        }

        /// public propaty name  :  ReceiveAgentNm
        /// <summary>引取担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引取担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ReceiveAgentNm
        {
            get { return _receiveAgentNm; }
            set { _receiveAgentNm = value; }
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

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// <value>0:自社、1:受託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜,浮動）プロパティ</summary>
        /// <value>在庫移動する在庫の仕入価格情報をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜,浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  MoveCount
        /// <summary>移動数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MoveCount
        {
            get { return _moveCount; }
            set { _moveCount = value; }
        }

        /// public propaty name  :  BfShelfNo
        /// <summary>移動元棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfShelfNo
        {
            get { return _bfShelfNo; }
            set { _bfShelfNo = value; }
        }

        /// public propaty name  :  AfShelfNo
        /// <summary>移動先棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfShelfNo
        {
            get { return _afShelfNo; }
            set { _afShelfNo = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  ListPriceFl
        /// <summary>定価（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceFl
        {
            get { return _listPriceFl; }
            set { _listPriceFl = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>伝票摘要プロパティ</summary>
        /// <value>車販の場合、摘要+注文書№+管理番号を格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }

        /// public propaty name  :  WarehouseNote1
        /// <summary>倉庫備考1プロパティ</summary>
        /// <value>在庫移動時の移動伝票に出力する備考をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote1
        {
            get { return _warehouseNote1; }
            set { _warehouseNote1 = value; }
        }

        /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  WarehouseNote2
        /// <summary>倉庫備考2プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote2
        {
            get { return _warehouseNote2; }
            set { _warehouseNote2 = value; }
        }

        /// public propaty name  :  WarehouseNote3
        /// <summary>倉庫備考3プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote3
        {
            get { return _warehouseNote3; }
            set { _warehouseNote3 = value; }
        }

        /// public propaty name  :  WarehouseNote4
        /// <summary>倉庫備考4プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote4
        {
            get { return _warehouseNote4; }
            set { _warehouseNote4 = value; }
        }

        /// public propaty name  :  WarehouseNote5
        /// <summary>倉庫備考5プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote5
        {
            get { return _warehouseNote5; }
            set { _warehouseNote5 = value; }
        }
           --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  SlipPrintFinishCd
        /// <summary>伝票発行済区分プロパティ</summary>
        /// <value>0:未発行 1:発行済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行済区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipPrintFinishCd
        {
            get { return _slipPrintFinishCd; }
            set { _slipPrintFinishCd = value; }
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


        /// <summary>
        /// 在庫移動データコンストラクタ
        /// </summary>
        /// <returns>StockMoveクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMove()
        {
        }

        /// <summary>
        /// 在庫移動データコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="stockMoveFormal">在庫移動形式(1:在庫移動、2：倉庫移動)</param>
        /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
        /// <param name="stockMoveRowNo">在庫移動行番号</param>
        /// <param name="updateSecCd">更新拠点コード(文字型 データの登録更新拠点)</param>
        /// <param name="bfSectionCode">移動元拠点コード</param>
        /// <param name="bfSectionGuideSnm">移動元拠点ガイド略称</param>
        /// <param name="bfEnterWarehCode">移動元倉庫コード</param>
        /// <param name="bfEnterWarehName">移動元倉庫名称</param>
        /// <param name="afSectionCode">移動先拠点コード</param>
        /// <param name="afSectionGuideSnm">移動先拠点ガイド略称</param>
        /// <param name="afEnterWarehCode">移動先倉庫コード</param>
        /// <param name="afEnterWarehName">移動先倉庫名称</param>
        /// <param name="shipmentScdlDay">出荷予定日(在庫移動処理（出荷側）を行った時にセット)</param>
        /// <param name="shipmentFixDay">出荷確定日(出荷確定処理（出荷側）を行った時にセット)</param>
        /// <param name="arrivalGoodsDay">入荷日(在庫移動処理（入荷側）を行った時にセット)</param>
        /// <param name="inputDay">入力日(YYYYMMDD　（更新年月日）)</param>
        /// <param name="moveStatus">移動状態(0:移動対象外、1:未出荷状態、2:移動中、9:入荷済)</param>
        /// <param name="stockMvEmpCode">在庫移動入力従業員コード(在庫移動伝票を入力する従業員コードをセット)</param>
        /// <param name="stockMvEmpName">在庫移動入力従業員名称</param>
        /// <param name="shipAgentCd">出荷担当従業員コード(出荷確定処理を行う従業員コードをセット)</param>
        /// <param name="shipAgentNm">出荷担当従業員名称</param>
        /// <param name="receiveAgentCd">引取担当従業員コード(在庫の入荷側の従業員コードをセット)</param>
        /// <param name="receiveAgentNm">引取担当従業員名称</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsNameKana">商品名称カナ</param>
        /// <param name="stockDiv">在庫区分(0:自社、1:受託)</param>
        /// <param name="stockUnitPriceFl">仕入単価（税抜,浮動）(在庫移動する在庫の仕入価格情報をセット)</param>
        /// <param name="taxationDivCd">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
        /// <param name="moveCount">移動数</param>
        /// <param name="bfShelfNo">移動元棚番</param>
        /// <param name="afShelfNo">移動先棚番</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
        /// <param name="listPriceFl">定価（浮動）</param>
        /// <param name="outline">伝票摘要(車販の場合、摘要+注文書№+管理番号を格納)</param>
        /// <param name="warehouseNote1">倉庫備考1(在庫移動時の移動伝票に出力する備考をセット)</param>
        /// <param name="warehouseNote2">倉庫備考2(　〃)</param>
        /// <param name="warehouseNote3">倉庫備考3(　〃)</param>
        /// <param name="warehouseNote4">倉庫備考4(　〃)</param>
        /// <param name="warehouseNote5">倉庫備考5(　〃)</param>
        /// <param name="slipPrintFinishCd">伝票発行済区分(0:未発行 1:発行済)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <returns>StockMoveクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
        //public StockMove(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 stockMoveFormal, Int32 stockMoveSlipNo, Int32 stockMoveRowNo, string updateSecCd, string bfSectionCode, string bfSectionGuideSnm, string bfEnterWarehCode, string bfEnterWarehName, string afSectionCode, string afSectionGuideSnm, string afEnterWarehCode, string afEnterWarehName, DateTime shipmentScdlDay, DateTime shipmentFixDay, DateTime arrivalGoodsDay, DateTime inputDay, Int32 moveStatus, string stockMvEmpCode, string stockMvEmpName, string shipAgentCd, string shipAgentNm, string receiveAgentCd, string receiveAgentNm, Int32 supplierCd, string supplierSnm, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, string goodsNameKana, Int32 stockDiv, Double stockUnitPriceFl, Int32 taxationDivCd, Double moveCount, string bfShelfNo, string afShelfNo, Int32 bLGoodsCode, string bLGoodsFullName, Double listPriceFl, string outline, string warehouseNote1, string warehouseNote2, string warehouseNote3, string warehouseNote4, string warehouseNote5, Int32 slipPrintFinishCd, string enterpriseName, string updEmployeeName, string bLGoodsName)
        public StockMove(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 stockMoveFormal, Int32 stockMoveSlipNo, Int32 stockMoveRowNo, string updateSecCd, string bfSectionCode, string bfSectionGuideSnm, string bfEnterWarehCode, string bfEnterWarehName, string afSectionCode, string afSectionGuideSnm, string afEnterWarehCode, string afEnterWarehName, DateTime shipmentScdlDay, DateTime shipmentFixDay, DateTime arrivalGoodsDay, DateTime inputDay, Int32 moveStatus, string stockMvEmpCode, string stockMvEmpName, string shipAgentCd, string shipAgentNm, string receiveAgentCd, string receiveAgentNm, Int32 supplierCd, string supplierSnm, Int32 goodsMakerCd, string makerName, string goodsNo, string goodsName, string goodsNameKana, Int32 stockDiv, Double stockUnitPriceFl, Int32 taxationDivCd, Double moveCount, string bfShelfNo, string afShelfNo, Int32 bLGoodsCode, string bLGoodsFullName, Double listPriceFl, string outline, string warehouseNote1, Int32 slipPrintFinishCd, string enterpriseName, string updEmployeeName, string bLGoodsName)
        // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._stockMoveFormal = stockMoveFormal;
            this._stockMoveSlipNo = stockMoveSlipNo;
            this._stockMoveRowNo = stockMoveRowNo;
            this._updateSecCd = updateSecCd;
            this._bfSectionCode = bfSectionCode;
            this._bfSectionGuideSnm = bfSectionGuideSnm;
            this._bfEnterWarehCode = bfEnterWarehCode;
            this._bfEnterWarehName = bfEnterWarehName;
            this._afSectionCode = afSectionCode;
            this._afSectionGuideSnm = afSectionGuideSnm;
            this._afEnterWarehCode = afEnterWarehCode;
            this._afEnterWarehName = afEnterWarehName;
            this.ShipmentScdlDay = shipmentScdlDay;
            this.ShipmentFixDay = shipmentFixDay;
            this.ArrivalGoodsDay = arrivalGoodsDay;
            this.InputDay = inputDay;
            this._moveStatus = moveStatus;
            this._stockMvEmpCode = stockMvEmpCode;
            this._stockMvEmpName = stockMvEmpName;
            this._shipAgentCd = shipAgentCd;
            this._shipAgentNm = shipAgentNm;
            this._receiveAgentCd = receiveAgentCd;
            this._receiveAgentNm = receiveAgentNm;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._stockDiv = stockDiv;
            this._stockUnitPriceFl = stockUnitPriceFl;
            this._taxationDivCd = taxationDivCd;
            this._moveCount = moveCount;
            this._bfShelfNo = bfShelfNo;
            this._afShelfNo = afShelfNo;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._listPriceFl = listPriceFl;
            this._outline = outline;
            this._warehouseNote1 = warehouseNote1;
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            this._warehouseNote2 = warehouseNote2;
            this._warehouseNote3 = warehouseNote3;
            this._warehouseNote4 = warehouseNote4;
            this._warehouseNote5 = warehouseNote5;
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            this._slipPrintFinishCd = slipPrintFinishCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// 在庫移動データ複製処理
        /// </summary>
        /// <returns>StockMoveクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいStockMoveクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMove Clone()
        {
            // --- CHG 2008/07/14 --------------------------------------------------------------------->>>>>
            //return new StockMove(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._stockMoveFormal, this._stockMoveSlipNo, this._stockMoveRowNo, this._updateSecCd, this._bfSectionCode, this._bfSectionGuideSnm, this._bfEnterWarehCode, this._bfEnterWarehName, this._afSectionCode, this._afSectionGuideSnm, this._afEnterWarehCode, this._afEnterWarehName, this._shipmentScdlDay, this._shipmentFixDay, this._arrivalGoodsDay, this._inputDay, this._moveStatus, this._stockMvEmpCode, this._stockMvEmpName, this._shipAgentCd, this._shipAgentNm, this._receiveAgentCd, this._receiveAgentNm, this._supplierCd, this._supplierSnm, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._goodsNameKana, this._stockDiv, this._stockUnitPriceFl, this._taxationDivCd, this._moveCount, this._bfShelfNo, this._afShelfNo, this._bLGoodsCode, this._bLGoodsFullName, this._listPriceFl, this._outline, this._warehouseNote1, this._warehouseNote2, this._warehouseNote3, this._warehouseNote4, this._warehouseNote5, this._slipPrintFinishCd, this._enterpriseName, this._updEmployeeName, this._bLGoodsName);
            return new StockMove(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._stockMoveFormal, this._stockMoveSlipNo, this._stockMoveRowNo, this._updateSecCd, this._bfSectionCode, this._bfSectionGuideSnm, this._bfEnterWarehCode, this._bfEnterWarehName, this._afSectionCode, this._afSectionGuideSnm, this._afEnterWarehCode, this._afEnterWarehName, this._shipmentScdlDay, this._shipmentFixDay, this._arrivalGoodsDay, this._inputDay, this._moveStatus, this._stockMvEmpCode, this._stockMvEmpName, this._shipAgentCd, this._shipAgentNm, this._receiveAgentCd, this._receiveAgentNm, this._supplierCd, this._supplierSnm, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsName, this._goodsNameKana, this._stockDiv, this._stockUnitPriceFl, this._taxationDivCd, this._moveCount, this._bfShelfNo, this._afShelfNo, this._bLGoodsCode, this._bLGoodsFullName, this._listPriceFl, this._outline, this._warehouseNote1, this._slipPrintFinishCd, this._enterpriseName, this._updEmployeeName, this._bLGoodsName);
            // --- CHG 2008/07/14 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// 在庫移動データ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMoveクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(StockMove target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.StockMoveFormal == target.StockMoveFormal)
                 && (this.StockMoveSlipNo == target.StockMoveSlipNo)
                 && (this.StockMoveRowNo == target.StockMoveRowNo)
                 && (this.UpdateSecCd == target.UpdateSecCd)
                 && (this.BfSectionCode == target.BfSectionCode)
                 && (this.BfSectionGuideSnm == target.BfSectionGuideSnm)
                 && (this.BfEnterWarehCode == target.BfEnterWarehCode)
                 && (this.BfEnterWarehName == target.BfEnterWarehName)
                 && (this.AfSectionCode == target.AfSectionCode)
                 && (this.AfSectionGuideSnm == target.AfSectionGuideSnm)
                 && (this.AfEnterWarehCode == target.AfEnterWarehCode)
                 && (this.AfEnterWarehName == target.AfEnterWarehName)
                 && (this.ShipmentScdlDay == target.ShipmentScdlDay)
                 && (this.ShipmentFixDay == target.ShipmentFixDay)
                 && (this.ArrivalGoodsDay == target.ArrivalGoodsDay)
                 && (this.InputDay == target.InputDay)
                 && (this.MoveStatus == target.MoveStatus)
                 && (this.StockMvEmpCode == target.StockMvEmpCode)
                 && (this.StockMvEmpName == target.StockMvEmpName)
                 && (this.ShipAgentCd == target.ShipAgentCd)
                 && (this.ShipAgentNm == target.ShipAgentNm)
                 && (this.ReceiveAgentCd == target.ReceiveAgentCd)
                 && (this.ReceiveAgentNm == target.ReceiveAgentNm)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.StockDiv == target.StockDiv)
                 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
                 && (this.TaxationDivCd == target.TaxationDivCd)
                 && (this.MoveCount == target.MoveCount)
                 && (this.BfShelfNo == target.BfShelfNo)
                 && (this.AfShelfNo == target.AfShelfNo)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.ListPriceFl == target.ListPriceFl)
                 && (this.Outline == target.Outline)
                 && (this.WarehouseNote1 == target.WarehouseNote1)
                /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
                && (this.WarehouseNote2 == target.WarehouseNote2)
                && (this.WarehouseNote3 == target.WarehouseNote3)
                && (this.WarehouseNote4 == target.WarehouseNote4)
                && (this.WarehouseNote5 == target.WarehouseNote5)
                   --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
                 && (this.SlipPrintFinishCd == target.SlipPrintFinishCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName));
        }

        /// <summary>
        /// 在庫移動データ比較処理
        /// </summary>
        /// <param name="stockMove1">
        ///                    比較するStockMoveクラスのインスタンス
        /// </param>
        /// <param name="stockMove2">比較するStockMoveクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(StockMove stockMove1, StockMove stockMove2)
        {
            return ((stockMove1.CreateDateTime == stockMove2.CreateDateTime)
                 && (stockMove1.UpdateDateTime == stockMove2.UpdateDateTime)
                 && (stockMove1.EnterpriseCode == stockMove2.EnterpriseCode)
                 && (stockMove1.FileHeaderGuid == stockMove2.FileHeaderGuid)
                 && (stockMove1.UpdEmployeeCode == stockMove2.UpdEmployeeCode)
                 && (stockMove1.UpdAssemblyId1 == stockMove2.UpdAssemblyId1)
                 && (stockMove1.UpdAssemblyId2 == stockMove2.UpdAssemblyId2)
                 && (stockMove1.LogicalDeleteCode == stockMove2.LogicalDeleteCode)
                 && (stockMove1.StockMoveFormal == stockMove2.StockMoveFormal)
                 && (stockMove1.StockMoveSlipNo == stockMove2.StockMoveSlipNo)
                 && (stockMove1.StockMoveRowNo == stockMove2.StockMoveRowNo)
                 && (stockMove1.UpdateSecCd == stockMove2.UpdateSecCd)
                 && (stockMove1.BfSectionCode == stockMove2.BfSectionCode)
                 && (stockMove1.BfSectionGuideSnm == stockMove2.BfSectionGuideSnm)
                 && (stockMove1.BfEnterWarehCode == stockMove2.BfEnterWarehCode)
                 && (stockMove1.BfEnterWarehName == stockMove2.BfEnterWarehName)
                 && (stockMove1.AfSectionCode == stockMove2.AfSectionCode)
                 && (stockMove1.AfSectionGuideSnm == stockMove2.AfSectionGuideSnm)
                 && (stockMove1.AfEnterWarehCode == stockMove2.AfEnterWarehCode)
                 && (stockMove1.AfEnterWarehName == stockMove2.AfEnterWarehName)
                 && (stockMove1.ShipmentScdlDay == stockMove2.ShipmentScdlDay)
                 && (stockMove1.ShipmentFixDay == stockMove2.ShipmentFixDay)
                 && (stockMove1.ArrivalGoodsDay == stockMove2.ArrivalGoodsDay)
                 && (stockMove1.InputDay == stockMove2.InputDay)
                 && (stockMove1.MoveStatus == stockMove2.MoveStatus)
                 && (stockMove1.StockMvEmpCode == stockMove2.StockMvEmpCode)
                 && (stockMove1.StockMvEmpName == stockMove2.StockMvEmpName)
                 && (stockMove1.ShipAgentCd == stockMove2.ShipAgentCd)
                 && (stockMove1.ShipAgentNm == stockMove2.ShipAgentNm)
                 && (stockMove1.ReceiveAgentCd == stockMove2.ReceiveAgentCd)
                 && (stockMove1.ReceiveAgentNm == stockMove2.ReceiveAgentNm)
                 && (stockMove1.SupplierCd == stockMove2.SupplierCd)
                 && (stockMove1.SupplierSnm == stockMove2.SupplierSnm)
                 && (stockMove1.GoodsMakerCd == stockMove2.GoodsMakerCd)
                 && (stockMove1.MakerName == stockMove2.MakerName)
                 && (stockMove1.GoodsNo == stockMove2.GoodsNo)
                 && (stockMove1.GoodsName == stockMove2.GoodsName)
                 && (stockMove1.GoodsNameKana == stockMove2.GoodsNameKana)
                 && (stockMove1.StockDiv == stockMove2.StockDiv)
                 && (stockMove1.StockUnitPriceFl == stockMove2.StockUnitPriceFl)
                 && (stockMove1.TaxationDivCd == stockMove2.TaxationDivCd)
                 && (stockMove1.MoveCount == stockMove2.MoveCount)
                 && (stockMove1.BfShelfNo == stockMove2.BfShelfNo)
                 && (stockMove1.AfShelfNo == stockMove2.AfShelfNo)
                 && (stockMove1.BLGoodsCode == stockMove2.BLGoodsCode)
                 && (stockMove1.BLGoodsFullName == stockMove2.BLGoodsFullName)
                 && (stockMove1.ListPriceFl == stockMove2.ListPriceFl)
                 && (stockMove1.Outline == stockMove2.Outline)
                 && (stockMove1.WarehouseNote1 == stockMove2.WarehouseNote1)
                /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
                && (stockMove1.WarehouseNote2 == stockMove2.WarehouseNote2)
                && (stockMove1.WarehouseNote3 == stockMove2.WarehouseNote3)
                && (stockMove1.WarehouseNote4 == stockMove2.WarehouseNote4)
                && (stockMove1.WarehouseNote5 == stockMove2.WarehouseNote5)
                   --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
                 && (stockMove1.SlipPrintFinishCd == stockMove2.SlipPrintFinishCd)
                 && (stockMove1.EnterpriseName == stockMove2.EnterpriseName)
                 && (stockMove1.UpdEmployeeName == stockMove2.UpdEmployeeName)
                 && (stockMove1.BLGoodsName == stockMove2.BLGoodsName));
        }
        /// <summary>
        /// 在庫移動データ比較処理
        /// </summary>
        /// <param name="target">比較対象のStockMoveクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(StockMove target)
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
            if (this.StockMoveFormal != target.StockMoveFormal) resList.Add("StockMoveFormal");
            if (this.StockMoveSlipNo != target.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (this.StockMoveRowNo != target.StockMoveRowNo) resList.Add("StockMoveRowNo");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.BfSectionCode != target.BfSectionCode) resList.Add("BfSectionCode");
            if (this.BfSectionGuideSnm != target.BfSectionGuideSnm) resList.Add("BfSectionGuideSnm");
            if (this.BfEnterWarehCode != target.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (this.BfEnterWarehName != target.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfSectionGuideSnm != target.AfSectionGuideSnm) resList.Add("AfSectionGuideSnm");
            if (this.AfEnterWarehCode != target.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (this.AfEnterWarehName != target.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (this.ShipmentScdlDay != target.ShipmentScdlDay) resList.Add("ShipmentScdlDay");
            if (this.ShipmentFixDay != target.ShipmentFixDay) resList.Add("ShipmentFixDay");
            if (this.ArrivalGoodsDay != target.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (this.InputDay != target.InputDay) resList.Add("InputDay");
            if (this.MoveStatus != target.MoveStatus) resList.Add("MoveStatus");
            if (this.StockMvEmpCode != target.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (this.StockMvEmpName != target.StockMvEmpName) resList.Add("StockMvEmpName");
            if (this.ShipAgentCd != target.ShipAgentCd) resList.Add("ShipAgentCd");
            if (this.ShipAgentNm != target.ShipAgentNm) resList.Add("ShipAgentNm");
            if (this.ReceiveAgentCd != target.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (this.ReceiveAgentNm != target.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.StockDiv != target.StockDiv) resList.Add("StockDiv");
            if (this.StockUnitPriceFl != target.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.MoveCount != target.MoveCount) resList.Add("MoveCount");
            if (this.BfShelfNo != target.BfShelfNo) resList.Add("BfShelfNo");
            if (this.AfShelfNo != target.AfShelfNo) resList.Add("AfShelfNo");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.ListPriceFl != target.ListPriceFl) resList.Add("ListPriceFl");
            if (this.Outline != target.Outline) resList.Add("Outline");
            if (this.WarehouseNote1 != target.WarehouseNote1) resList.Add("WarehouseNote1");
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            if (this.WarehouseNote2 != target.WarehouseNote2) resList.Add("WarehouseNote2");
            if (this.WarehouseNote3 != target.WarehouseNote3) resList.Add("WarehouseNote3");
            if (this.WarehouseNote4 != target.WarehouseNote4) resList.Add("WarehouseNote4");
            if (this.WarehouseNote5 != target.WarehouseNote5) resList.Add("WarehouseNote5");
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            if (this.SlipPrintFinishCd != target.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// 在庫移動データ比較処理
        /// </summary>
        /// <param name="stockMove1">比較するStockMoveクラスのインスタンス</param>
        /// <param name="stockMove2">比較するStockMoveクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(StockMove stockMove1, StockMove stockMove2)
        {
            ArrayList resList = new ArrayList();
            if (stockMove1.CreateDateTime != stockMove2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockMove1.UpdateDateTime != stockMove2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockMove1.EnterpriseCode != stockMove2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMove1.FileHeaderGuid != stockMove2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockMove1.UpdEmployeeCode != stockMove2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockMove1.UpdAssemblyId1 != stockMove2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockMove1.UpdAssemblyId2 != stockMove2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockMove1.LogicalDeleteCode != stockMove2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockMove1.StockMoveFormal != stockMove2.StockMoveFormal) resList.Add("StockMoveFormal");
            if (stockMove1.StockMoveSlipNo != stockMove2.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (stockMove1.StockMoveRowNo != stockMove2.StockMoveRowNo) resList.Add("StockMoveRowNo");
            if (stockMove1.UpdateSecCd != stockMove2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (stockMove1.BfSectionCode != stockMove2.BfSectionCode) resList.Add("BfSectionCode");
            if (stockMove1.BfSectionGuideSnm != stockMove2.BfSectionGuideSnm) resList.Add("BfSectionGuideSnm");
            if (stockMove1.BfEnterWarehCode != stockMove2.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (stockMove1.BfEnterWarehName != stockMove2.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (stockMove1.AfSectionCode != stockMove2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockMove1.AfSectionGuideSnm != stockMove2.AfSectionGuideSnm) resList.Add("AfSectionGuideSnm");
            if (stockMove1.AfEnterWarehCode != stockMove2.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (stockMove1.AfEnterWarehName != stockMove2.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (stockMove1.ShipmentScdlDay != stockMove2.ShipmentScdlDay) resList.Add("ShipmentScdlDay");
            if (stockMove1.ShipmentFixDay != stockMove2.ShipmentFixDay) resList.Add("ShipmentFixDay");
            if (stockMove1.ArrivalGoodsDay != stockMove2.ArrivalGoodsDay) resList.Add("ArrivalGoodsDay");
            if (stockMove1.InputDay != stockMove2.InputDay) resList.Add("InputDay");
            if (stockMove1.MoveStatus != stockMove2.MoveStatus) resList.Add("MoveStatus");
            if (stockMove1.StockMvEmpCode != stockMove2.StockMvEmpCode) resList.Add("StockMvEmpCode");
            if (stockMove1.StockMvEmpName != stockMove2.StockMvEmpName) resList.Add("StockMvEmpName");
            if (stockMove1.ShipAgentCd != stockMove2.ShipAgentCd) resList.Add("ShipAgentCd");
            if (stockMove1.ShipAgentNm != stockMove2.ShipAgentNm) resList.Add("ShipAgentNm");
            if (stockMove1.ReceiveAgentCd != stockMove2.ReceiveAgentCd) resList.Add("ReceiveAgentCd");
            if (stockMove1.ReceiveAgentNm != stockMove2.ReceiveAgentNm) resList.Add("ReceiveAgentNm");
            if (stockMove1.SupplierCd != stockMove2.SupplierCd) resList.Add("SupplierCd");
            if (stockMove1.SupplierSnm != stockMove2.SupplierSnm) resList.Add("SupplierSnm");
            if (stockMove1.GoodsMakerCd != stockMove2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stockMove1.MakerName != stockMove2.MakerName) resList.Add("MakerName");
            if (stockMove1.GoodsNo != stockMove2.GoodsNo) resList.Add("GoodsNo");
            if (stockMove1.GoodsName != stockMove2.GoodsName) resList.Add("GoodsName");
            if (stockMove1.GoodsNameKana != stockMove2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (stockMove1.StockDiv != stockMove2.StockDiv) resList.Add("StockDiv");
            if (stockMove1.StockUnitPriceFl != stockMove2.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (stockMove1.TaxationDivCd != stockMove2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (stockMove1.MoveCount != stockMove2.MoveCount) resList.Add("MoveCount");
            if (stockMove1.BfShelfNo != stockMove2.BfShelfNo) resList.Add("BfShelfNo");
            if (stockMove1.AfShelfNo != stockMove2.AfShelfNo) resList.Add("AfShelfNo");
            if (stockMove1.BLGoodsCode != stockMove2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (stockMove1.BLGoodsFullName != stockMove2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (stockMove1.ListPriceFl != stockMove2.ListPriceFl) resList.Add("ListPriceFl");
            if (stockMove1.Outline != stockMove2.Outline) resList.Add("Outline");
            if (stockMove1.WarehouseNote1 != stockMove2.WarehouseNote1) resList.Add("WarehouseNote1");
            /* --- DEL 2008/07/14 --------------------------------------------------------------------->>>>>
            if (stockMove1.WarehouseNote2 != stockMove2.WarehouseNote2) resList.Add("WarehouseNote2");
            if (stockMove1.WarehouseNote3 != stockMove2.WarehouseNote3) resList.Add("WarehouseNote3");
            if (stockMove1.WarehouseNote4 != stockMove2.WarehouseNote4) resList.Add("WarehouseNote4");
            if (stockMove1.WarehouseNote5 != stockMove2.WarehouseNote5) resList.Add("WarehouseNote5");
               --- DEL 2008/07/14 ---------------------------------------------------------------------<<<<<*/
            if (stockMove1.SlipPrintFinishCd != stockMove2.SlipPrintFinishCd) resList.Add("SlipPrintFinishCd");
            if (stockMove1.EnterpriseName != stockMove2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockMove1.UpdEmployeeName != stockMove2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stockMove1.BLGoodsName != stockMove2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
}
