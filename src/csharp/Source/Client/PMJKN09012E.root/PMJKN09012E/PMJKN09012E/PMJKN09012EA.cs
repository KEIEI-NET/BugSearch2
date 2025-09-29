using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   FreeSearchParts
    /// <summary>
    ///                      自由検索部品マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由検索部品マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/04/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class FreeSearchParts
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

        /// <summary>自由検索部品固有番号</summary>
        private string _freSrchPrtPropNo = "";

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>車種コード</summary>
        /// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>翼部品コード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>翼部品コード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>ハイフン無商品番号</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>部品QTY</summary>
        private Double _partsQty;

        /// <summary>部品オプション名称</summary>
        private string _partsOpNm = "";

        /// <summary>型式別部品採用年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _modelPrtsAdptYm;

        /// <summary>型式別部品廃止年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _modelPrtsAblsYm;

        /// <summary>型式別部品採用車台番号</summary>
        private Int32 _modelPrtsAdptFrameNo;

        /// <summary>型式別部品廃止車台番号</summary>
        private Int32 _modelPrtsAblsFrameNo;

        /// <summary>型式グレード名称</summary>
        private string _modelGradeNm = "";

        /// <summary>ボディー名称</summary>
        private string _bodyName = "";

        /// <summary>ドア数</summary>
        private Int32 _doorCount;

        /// <summary>エンジン型式名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _engineModelNm = "";

        /// <summary>排気量名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _engineDisplaceNm = "";

        /// <summary>E区分名称</summary>
        /// <remarks>型式により変動</remarks>
        private string _eDivNm = "";

        /// <summary>ミッション名称</summary>
        private string _transmissionNm = "";

        /// <summary>駆動方式名称</summary>
        /// <remarks>新規追加</remarks>
        private string _wheelDriveMethodNm = "";

        /// <summary>シフト名称</summary>
        private string _shiftNm = "";

        /// <summary>作成日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _createDate;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _updateDate;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>品番条件</summary>
        private Int32 _goodsNoFuzzy;

        /// <summary>データステータス(画面用)</summary>
        private Int32 _dataStatus;

        /// <summary>型式グループ区分(画面用)</summary>
        private string _fullModelGroup = "";

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

        /// public propaty name  :  FreSrchPrtPropNo
        /// <summary>自由検索部品固有番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由検索部品固有番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FreSrchPrtPropNo
        {
            get { return _freSrchPrtPropNo; }
            set { _freSrchPrtPropNo = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  ModelCode
        /// <summary>車種コードプロパティ</summary>
        /// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelCode
        {
            get { return _modelCode; }
            set { _modelCode = value; }
        }

        /// public propaty name  :  ModelSubCode
        /// <summary>車種サブコードプロパティ</summary>
        /// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車種サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelSubCode
        {
            get { return _modelSubCode; }
            set { _modelSubCode = value; }
        }

        /// public propaty name  :  FullModel
        /// <summary>型式（フル型）プロパティ</summary>
        /// <value>フル型式(44桁用)</value>
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

        /// public propaty name  :  TbsPartsCode
        /// <summary>翼部品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼部品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>翼部品コード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼部品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
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

        /// public propaty name  :  PartsQty
        /// <summary>部品QTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PartsQty
        {
            get { return _partsQty; }
            set { _partsQty = value; }
        }

        /// public propaty name  :  PartsOpNm
        /// <summary>部品オプション名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品オプション名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsOpNm
        {
            get { return _partsOpNm; }
            set { _partsOpNm = value; }
        }

        /// public propaty name  :  ModelPrtsAdptYm
        /// <summary>型式別部品採用年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ModelPrtsAdptYm
        {
            get { return _modelPrtsAdptYm; }
            set { _modelPrtsAdptYm = value; }
        }

        /// public propaty name  :  ModelPrtsAdptYmJpFormal
        /// <summary>型式別部品採用年月 和暦プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用年月 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelPrtsAdptYmJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMM", _modelPrtsAdptYm); }
            set { }
        }

        /// public propaty name  :  ModelPrtsAdptYmJpInFormal
        /// <summary>型式別部品採用年月 和暦(略)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用年月 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelPrtsAdptYmJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM", _modelPrtsAdptYm); }
            set { }
        }

        /// public propaty name  :  ModelPrtsAdptYmAdFormal
        /// <summary>型式別部品採用年月 西暦プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用年月 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelPrtsAdptYmAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM", _modelPrtsAdptYm); }
            set { }
        }

        /// public propaty name  :  ModelPrtsAdptYmAdInFormal
        /// <summary>型式別部品採用年月 西暦(略)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用年月 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelPrtsAdptYmAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM", _modelPrtsAdptYm); }
            set { }
        }

        /// public propaty name  :  ModelPrtsAblsYm
        /// <summary>型式別部品廃止年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ModelPrtsAblsYm
        {
            get { return _modelPrtsAblsYm; }
            set { _modelPrtsAblsYm = value; }
        }

        /// public propaty name  :  ModelPrtsAblsYmJpFormal
        /// <summary>型式別部品廃止年月 和暦プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止年月 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelPrtsAblsYmJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMM", _modelPrtsAblsYm); }
            set { }
        }

        /// public propaty name  :  ModelPrtsAblsYmJpInFormal
        /// <summary>型式別部品廃止年月 和暦(略)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止年月 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelPrtsAblsYmJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM", _modelPrtsAblsYm); }
            set { }
        }

        /// public propaty name  :  ModelPrtsAblsYmAdFormal
        /// <summary>型式別部品廃止年月 西暦プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止年月 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelPrtsAblsYmAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM", _modelPrtsAblsYm); }
            set { }
        }

        /// public propaty name  :  ModelPrtsAblsYmAdInFormal
        /// <summary>型式別部品廃止年月 西暦(略)プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止年月 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelPrtsAblsYmAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM", _modelPrtsAblsYm); }
            set { }
        }

        /// public propaty name  :  ModelPrtsAdptFrameNo
        /// <summary>型式別部品採用車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAdptFrameNo
        {
            get { return _modelPrtsAdptFrameNo; }
            set { _modelPrtsAdptFrameNo = value; }
        }

        /// public propaty name  :  ModelPrtsAblsFrameNo
        /// <summary>型式別部品廃止車台番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAblsFrameNo
        {
            get { return _modelPrtsAblsFrameNo; }
            set { _modelPrtsAblsFrameNo = value; }
        }

        /// public propaty name  :  ModelGradeNm
        /// <summary>型式グレード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式グレード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ModelGradeNm
        {
            get { return _modelGradeNm; }
            set { _modelGradeNm = value; }
        }

        /// public propaty name  :  BodyName
        /// <summary>ボディー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ボディー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BodyName
        {
            get { return _bodyName; }
            set { _bodyName = value; }
        }

        /// public propaty name  :  DoorCount
        /// <summary>ドア数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ドア数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DoorCount
        {
            get { return _doorCount; }
            set { _doorCount = value; }
        }

        /// public propaty name  :  EngineModelNm
        /// <summary>エンジン型式名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エンジン型式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EngineModelNm
        {
            get { return _engineModelNm; }
            set { _engineModelNm = value; }
        }

        /// public propaty name  :  EngineDisplaceNm
        /// <summary>排気量名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排気量名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EngineDisplaceNm
        {
            get { return _engineDisplaceNm; }
            set { _engineDisplaceNm = value; }
        }

        /// public propaty name  :  EDivNm
        /// <summary>E区分名称プロパティ</summary>
        /// <value>型式により変動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   E区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EDivNm
        {
            get { return _eDivNm; }
            set { _eDivNm = value; }
        }

        /// public propaty name  :  TransmissionNm
        /// <summary>ミッション名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ミッション名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransmissionNm
        {
            get { return _transmissionNm; }
            set { _transmissionNm = value; }
        }

        /// public propaty name  :  WheelDriveMethodNm
        /// <summary>駆動方式名称プロパティ</summary>
        /// <value>新規追加</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   駆動方式名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WheelDriveMethodNm
        {
            get { return _wheelDriveMethodNm; }
            set { _wheelDriveMethodNm = value; }
        }

        /// public propaty name  :  ShiftNm
        /// <summary>シフト名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シフト名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShiftNm
        {
            get { return _shiftNm; }
            set { _shiftNm = value; }
        }

        /// public propaty name  :  CreateDate
        /// <summary>作成日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
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

        /// public propaty name  :  GoodsNoFuzzy
        /// <summary>品番条件プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoFuzzy
        {
            get { return _goodsNoFuzzy; }
            set { _goodsNoFuzzy = value; }
        }

        /// <summary>データステータス(画面用)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データステータス(画面用)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataStatus
        {
            get { return _dataStatus; }
            set { _dataStatus = value; }
        }

        /// <summary>型式グループ区分(画面用)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式グループ区分(画面用)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FullModelGroup
        {
            get { return _fullModelGroup; }
            set { _fullModelGroup = value; }
        }

        /// <summary>
        /// 自由検索部品マスタコンストラクタ
        /// </summary>
        /// <returns>FreeSearchPartsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchParts()
        {
        }

        /// <summary>
        /// 自由検索部品マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="freSrchPrtPropNo">自由検索部品固有番号</param>
        /// <param name="makerCode">メーカーコード(1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="modelCode">車種コード(車名コード(翼) 1～899:提供分, 900～ユーザー登録)</param>
        /// <param name="modelSubCode">車種サブコード(0～899:提供分,900～ﾕｰｻﾞｰ登録)</param>
        /// <param name="fullModel">型式（フル型）(フル型式(44桁用))</param>
        /// <param name="tbsPartsCode">翼部品コード</param>
        /// <param name="tbsPartsCdDerivedNo">翼部品コード枝番(※未使用項目（レイアウトには入れておく）)</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsNoNoneHyphen">ハイフン無商品番号</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="partsQty">部品QTY</param>
        /// <param name="partsOpNm">部品オプション名称</param>
        /// <param name="modelPrtsAdptYm">型式別部品採用年月(YYYYMM)</param>
        /// <param name="modelPrtsAblsYm">型式別部品廃止年月(YYYYMM)</param>
        /// <param name="modelPrtsAdptFrameNo">型式別部品採用車台番号</param>
        /// <param name="modelPrtsAblsFrameNo">型式別部品廃止車台番号</param>
        /// <param name="modelGradeNm">型式グレード名称</param>
        /// <param name="bodyName">ボディー名称</param>
        /// <param name="doorCount">ドア数</param>
        /// <param name="engineModelNm">エンジン型式名称(型式により変動)</param>
        /// <param name="engineDisplaceNm">排気量名称(型式により変動)</param>
        /// <param name="eDivNm">E区分名称(型式により変動)</param>
        /// <param name="transmissionNm">ミッション名称</param>
        /// <param name="wheelDriveMethodNm">駆動方式名称(新規追加)</param>
        /// <param name="shiftNm">シフト名称</param>
        /// <param name="createDate">作成日付(YYYYMMDD)</param>
        /// <param name="updateDate">更新年月日(YYYYMMDD)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="goodsNoFuzzy">品番条件</param>
        /// <param name="dataStatus">データステータス(画面用)</param>
        /// <param name="fullModelGroup">型式グループ区分(画面用)</param>
        /// <returns>FreeSearchPartsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchParts(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string freSrchPrtPropNo, Int32 makerCode, Int32 modelCode, Int32 modelSubCode, string fullModel, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo, string goodsNo, string goodsNoNoneHyphen, Int32 goodsMakerCd, Double partsQty, string partsOpNm, DateTime modelPrtsAdptYm, DateTime modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo, Int32 modelPrtsAblsFrameNo, string modelGradeNm, string bodyName, Int32 doorCount, string engineModelNm, string engineDisplaceNm, string eDivNm, string transmissionNm, string wheelDriveMethodNm, string shiftNm, Int32 createDate, Int32 updateDate, string enterpriseName, string updEmployeeName, Int32 goodsNoFuzzy, Int32 dataStatus, string fullModelGroup)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._freSrchPrtPropNo = freSrchPrtPropNo;
            this._makerCode = makerCode;
            this._modelCode = modelCode;
            this._modelSubCode = modelSubCode;
            this._fullModel = fullModel;
            this._tbsPartsCode = tbsPartsCode;
            this._tbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
            this._goodsNo = goodsNo;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._goodsMakerCd = goodsMakerCd;
            this._partsQty = partsQty;
            this._partsOpNm = partsOpNm;
            this.ModelPrtsAdptYm = modelPrtsAdptYm;
            this.ModelPrtsAblsYm = modelPrtsAblsYm;
            this._modelPrtsAdptFrameNo = modelPrtsAdptFrameNo;
            this._modelPrtsAblsFrameNo = modelPrtsAblsFrameNo;
            this._modelGradeNm = modelGradeNm;
            this._bodyName = bodyName;
            this._doorCount = doorCount;
            this._engineModelNm = engineModelNm;
            this._engineDisplaceNm = engineDisplaceNm;
            this._eDivNm = eDivNm;
            this._transmissionNm = transmissionNm;
            this._wheelDriveMethodNm = wheelDriveMethodNm;
            this._shiftNm = shiftNm;
            this._createDate = createDate;
            this._updateDate = updateDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._goodsNoFuzzy = goodsNoFuzzy;
            this._dataStatus = dataStatus;
            this._fullModelGroup = fullModelGroup;
        }

        /// <summary>
        /// 自由検索部品マスタ複製処理
        /// </summary>
        /// <returns>FreeSearchPartsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいFreeSearchPartsクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchParts Clone()
        {
            return new FreeSearchParts(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._freSrchPrtPropNo, this._makerCode, this._modelCode, this._modelSubCode, this._fullModel, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._goodsNo, this._goodsNoNoneHyphen, this._goodsMakerCd, this._partsQty, this._partsOpNm, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._modelGradeNm, this._bodyName, this._doorCount, this._engineModelNm, this._engineDisplaceNm, this._eDivNm, this._transmissionNm, this._wheelDriveMethodNm, this._shiftNm, this._createDate, this._updateDate, this._enterpriseName, this._updEmployeeName, this._goodsNoFuzzy, this._dataStatus, this._fullModelGroup);
        }

        /// <summary>
        /// 自由検索部品マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のFreeSearchPartsクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(FreeSearchParts target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.FreSrchPrtPropNo == target.FreSrchPrtPropNo)
                 && (this.MakerCode == target.MakerCode)
                 && (this.ModelCode == target.ModelCode)
                 && (this.ModelSubCode == target.ModelSubCode)
                 && (this.FullModel == target.FullModel)
                 && (this.TbsPartsCode == target.TbsPartsCode)
                 && (this.TbsPartsCdDerivedNo == target.TbsPartsCdDerivedNo)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.PartsQty == target.PartsQty)
                 && (this.PartsOpNm == target.PartsOpNm)
                 && (this.ModelPrtsAdptYm == target.ModelPrtsAdptYm)
                 && (this.ModelPrtsAblsYm == target.ModelPrtsAblsYm)
                 && (this.ModelPrtsAdptFrameNo == target.ModelPrtsAdptFrameNo)
                 && (this.ModelPrtsAblsFrameNo == target.ModelPrtsAblsFrameNo)
                 && (this.ModelGradeNm == target.ModelGradeNm)
                 && (this.BodyName == target.BodyName)
                 && (this.DoorCount == target.DoorCount)
                 && (this.EngineModelNm == target.EngineModelNm)
                 && (this.EngineDisplaceNm == target.EngineDisplaceNm)
                 && (this.EDivNm == target.EDivNm)
                 && (this.TransmissionNm == target.TransmissionNm)
                 && (this.WheelDriveMethodNm == target.WheelDriveMethodNm)
                 && (this.ShiftNm == target.ShiftNm)
                 && (this.CreateDate == target.CreateDate)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.GoodsNoFuzzy == target.GoodsNoFuzzy)
                 && (this.DataStatus == target.DataStatus)
                 && (this.FullModelGroup == target.FullModelGroup));
        }

        /// <summary>
        /// 自由検索部品マスタ比較処理
        /// </summary>
        /// <param name="freeSearchParts1">
        ///                    比較するFreeSearchPartsクラスのインスタンス
        /// </param>
        /// <param name="freeSearchParts2">比較するFreeSearchPartsクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(FreeSearchParts freeSearchParts1, FreeSearchParts freeSearchParts2)
        {
            return ((freeSearchParts1.CreateDateTime == freeSearchParts2.CreateDateTime)
                 && (freeSearchParts1.UpdateDateTime == freeSearchParts2.UpdateDateTime)
                 && (freeSearchParts1.EnterpriseCode == freeSearchParts2.EnterpriseCode)
                 && (freeSearchParts1.FileHeaderGuid == freeSearchParts2.FileHeaderGuid)
                 && (freeSearchParts1.UpdEmployeeCode == freeSearchParts2.UpdEmployeeCode)
                 && (freeSearchParts1.UpdAssemblyId1 == freeSearchParts2.UpdAssemblyId1)
                 && (freeSearchParts1.UpdAssemblyId2 == freeSearchParts2.UpdAssemblyId2)
                 && (freeSearchParts1.LogicalDeleteCode == freeSearchParts2.LogicalDeleteCode)
                 && (freeSearchParts1.FreSrchPrtPropNo == freeSearchParts2.FreSrchPrtPropNo)
                 && (freeSearchParts1.MakerCode == freeSearchParts2.MakerCode)
                 && (freeSearchParts1.ModelCode == freeSearchParts2.ModelCode)
                 && (freeSearchParts1.ModelSubCode == freeSearchParts2.ModelSubCode)
                 && (freeSearchParts1.FullModel == freeSearchParts2.FullModel)
                 && (freeSearchParts1.TbsPartsCode == freeSearchParts2.TbsPartsCode)
                 && (freeSearchParts1.TbsPartsCdDerivedNo == freeSearchParts2.TbsPartsCdDerivedNo)
                 && (freeSearchParts1.GoodsNo == freeSearchParts2.GoodsNo)
                 && (freeSearchParts1.GoodsNoNoneHyphen == freeSearchParts2.GoodsNoNoneHyphen)
                 && (freeSearchParts1.GoodsMakerCd == freeSearchParts2.GoodsMakerCd)
                 && (freeSearchParts1.PartsQty == freeSearchParts2.PartsQty)
                 && (freeSearchParts1.PartsOpNm == freeSearchParts2.PartsOpNm)
                 && (freeSearchParts1.ModelPrtsAdptYm == freeSearchParts2.ModelPrtsAdptYm)
                 && (freeSearchParts1.ModelPrtsAblsYm == freeSearchParts2.ModelPrtsAblsYm)
                 && (freeSearchParts1.ModelPrtsAdptFrameNo == freeSearchParts2.ModelPrtsAdptFrameNo)
                 && (freeSearchParts1.ModelPrtsAblsFrameNo == freeSearchParts2.ModelPrtsAblsFrameNo)
                 && (freeSearchParts1.ModelGradeNm == freeSearchParts2.ModelGradeNm)
                 && (freeSearchParts1.BodyName == freeSearchParts2.BodyName)
                 && (freeSearchParts1.DoorCount == freeSearchParts2.DoorCount)
                 && (freeSearchParts1.EngineModelNm == freeSearchParts2.EngineModelNm)
                 && (freeSearchParts1.EngineDisplaceNm == freeSearchParts2.EngineDisplaceNm)
                 && (freeSearchParts1.EDivNm == freeSearchParts2.EDivNm)
                 && (freeSearchParts1.TransmissionNm == freeSearchParts2.TransmissionNm)
                 && (freeSearchParts1.WheelDriveMethodNm == freeSearchParts2.WheelDriveMethodNm)
                 && (freeSearchParts1.ShiftNm == freeSearchParts2.ShiftNm)
                 && (freeSearchParts1.CreateDate == freeSearchParts2.CreateDate)
                 && (freeSearchParts1.UpdateDate == freeSearchParts2.UpdateDate)
                 && (freeSearchParts1.EnterpriseName == freeSearchParts2.EnterpriseName)
                 && (freeSearchParts1.UpdEmployeeName == freeSearchParts2.UpdEmployeeName)
                 && (freeSearchParts1.GoodsNoFuzzy == freeSearchParts2.GoodsNoFuzzy)
                 && (freeSearchParts1.DataStatus == freeSearchParts2.DataStatus)
                 && (freeSearchParts1.FullModelGroup == freeSearchParts2.FullModelGroup));
        }
        /// <summary>
        /// 自由検索部品マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のFreeSearchPartsクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(FreeSearchParts target)
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
            if (this.FreSrchPrtPropNo != target.FreSrchPrtPropNo) resList.Add("FreSrchPrtPropNo");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.ModelCode != target.ModelCode) resList.Add("ModelCode");
            if (this.ModelSubCode != target.ModelSubCode) resList.Add("ModelSubCode");
            if (this.FullModel != target.FullModel) resList.Add("FullModel");
            if (this.TbsPartsCode != target.TbsPartsCode) resList.Add("TbsPartsCode");
            if (this.TbsPartsCdDerivedNo != target.TbsPartsCdDerivedNo) resList.Add("TbsPartsCdDerivedNo");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.PartsQty != target.PartsQty) resList.Add("PartsQty");
            if (this.PartsOpNm != target.PartsOpNm) resList.Add("PartsOpNm");
            if (this.ModelPrtsAdptYm != target.ModelPrtsAdptYm) resList.Add("ModelPrtsAdptYm");
            if (this.ModelPrtsAblsYm != target.ModelPrtsAblsYm) resList.Add("ModelPrtsAblsYm");
            if (this.ModelPrtsAdptFrameNo != target.ModelPrtsAdptFrameNo) resList.Add("ModelPrtsAdptFrameNo");
            if (this.ModelPrtsAblsFrameNo != target.ModelPrtsAblsFrameNo) resList.Add("ModelPrtsAblsFrameNo");
            if (this.ModelGradeNm != target.ModelGradeNm) resList.Add("ModelGradeNm");
            if (this.BodyName != target.BodyName) resList.Add("BodyName");
            if (this.DoorCount != target.DoorCount) resList.Add("DoorCount");
            if (this.EngineModelNm != target.EngineModelNm) resList.Add("EngineModelNm");
            if (this.EngineDisplaceNm != target.EngineDisplaceNm) resList.Add("EngineDisplaceNm");
            if (this.EDivNm != target.EDivNm) resList.Add("EDivNm");
            if (this.TransmissionNm != target.TransmissionNm) resList.Add("TransmissionNm");
            if (this.WheelDriveMethodNm != target.WheelDriveMethodNm) resList.Add("WheelDriveMethodNm");
            if (this.ShiftNm != target.ShiftNm) resList.Add("ShiftNm");
            if (this.CreateDate != target.CreateDate) resList.Add("CreateDate");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.GoodsNoFuzzy != target.GoodsNoFuzzy) resList.Add("GoodsNoFuzzy");
            if (this.DataStatus != target.DataStatus) resList.Add("DataStatus");
            if (this.FullModelGroup != target.FullModelGroup) resList.Add("FullModelGroup");

            return resList;
        }

        /// <summary>
        /// 自由検索部品マスタ比較処理
        /// </summary>
        /// <param name="freeSearchParts1">比較するFreeSearchPartsクラスのインスタンス</param>
        /// <param name="freeSearchParts2">比較するFreeSearchPartsクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(FreeSearchParts freeSearchParts1, FreeSearchParts freeSearchParts2)
        {
            ArrayList resList = new ArrayList();
            if (freeSearchParts1.CreateDateTime != freeSearchParts2.CreateDateTime) resList.Add("CreateDateTime");
            if (freeSearchParts1.UpdateDateTime != freeSearchParts2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (freeSearchParts1.EnterpriseCode != freeSearchParts2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (freeSearchParts1.FileHeaderGuid != freeSearchParts2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (freeSearchParts1.UpdEmployeeCode != freeSearchParts2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (freeSearchParts1.UpdAssemblyId1 != freeSearchParts2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (freeSearchParts1.UpdAssemblyId2 != freeSearchParts2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (freeSearchParts1.LogicalDeleteCode != freeSearchParts2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (freeSearchParts1.FreSrchPrtPropNo != freeSearchParts2.FreSrchPrtPropNo) resList.Add("FreSrchPrtPropNo");
            if (freeSearchParts1.MakerCode != freeSearchParts2.MakerCode) resList.Add("MakerCode");
            if (freeSearchParts1.ModelCode != freeSearchParts2.ModelCode) resList.Add("ModelCode");
            if (freeSearchParts1.ModelSubCode != freeSearchParts2.ModelSubCode) resList.Add("ModelSubCode");
            if (freeSearchParts1.FullModel != freeSearchParts2.FullModel) resList.Add("FullModel");
            if (freeSearchParts1.TbsPartsCode != freeSearchParts2.TbsPartsCode) resList.Add("TbsPartsCode");
            if (freeSearchParts1.TbsPartsCdDerivedNo != freeSearchParts2.TbsPartsCdDerivedNo) resList.Add("TbsPartsCdDerivedNo");
            if (freeSearchParts1.GoodsNo != freeSearchParts2.GoodsNo) resList.Add("GoodsNo");
            if (freeSearchParts1.GoodsNoNoneHyphen != freeSearchParts2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (freeSearchParts1.GoodsMakerCd != freeSearchParts2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (freeSearchParts1.PartsQty != freeSearchParts2.PartsQty) resList.Add("PartsQty");
            if (freeSearchParts1.PartsOpNm != freeSearchParts2.PartsOpNm) resList.Add("PartsOpNm");
            if (freeSearchParts1.ModelPrtsAdptYm != freeSearchParts2.ModelPrtsAdptYm) resList.Add("ModelPrtsAdptYm");
            if (freeSearchParts1.ModelPrtsAblsYm != freeSearchParts2.ModelPrtsAblsYm) resList.Add("ModelPrtsAblsYm");
            if (freeSearchParts1.ModelPrtsAdptFrameNo != freeSearchParts2.ModelPrtsAdptFrameNo) resList.Add("ModelPrtsAdptFrameNo");
            if (freeSearchParts1.ModelPrtsAblsFrameNo != freeSearchParts2.ModelPrtsAblsFrameNo) resList.Add("ModelPrtsAblsFrameNo");
            if (freeSearchParts1.ModelGradeNm != freeSearchParts2.ModelGradeNm) resList.Add("ModelGradeNm");
            if (freeSearchParts1.BodyName != freeSearchParts2.BodyName) resList.Add("BodyName");
            if (freeSearchParts1.DoorCount != freeSearchParts2.DoorCount) resList.Add("DoorCount");
            if (freeSearchParts1.EngineModelNm != freeSearchParts2.EngineModelNm) resList.Add("EngineModelNm");
            if (freeSearchParts1.EngineDisplaceNm != freeSearchParts2.EngineDisplaceNm) resList.Add("EngineDisplaceNm");
            if (freeSearchParts1.EDivNm != freeSearchParts2.EDivNm) resList.Add("EDivNm");
            if (freeSearchParts1.TransmissionNm != freeSearchParts2.TransmissionNm) resList.Add("TransmissionNm");
            if (freeSearchParts1.WheelDriveMethodNm != freeSearchParts2.WheelDriveMethodNm) resList.Add("WheelDriveMethodNm");
            if (freeSearchParts1.ShiftNm != freeSearchParts2.ShiftNm) resList.Add("ShiftNm");
            if (freeSearchParts1.CreateDate != freeSearchParts2.CreateDate) resList.Add("CreateDate");
            if (freeSearchParts1.UpdateDate != freeSearchParts2.UpdateDate) resList.Add("UpdateDate");
            if (freeSearchParts1.EnterpriseName != freeSearchParts2.EnterpriseName) resList.Add("EnterpriseName");
            if (freeSearchParts1.UpdEmployeeName != freeSearchParts2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (freeSearchParts1.GoodsNoFuzzy != freeSearchParts2.GoodsNoFuzzy) resList.Add("GoodsNoFuzzy");
            if (freeSearchParts1.DataStatus != freeSearchParts2.DataStatus) resList.Add("DataStatus");
            if (freeSearchParts1.FullModelGroup != freeSearchParts2.FullModelGroup) resList.Add("FullModelGroup");

            return resList;
        }
    }
}
