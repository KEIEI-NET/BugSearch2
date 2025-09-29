//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由検索部品マスタ（印刷） データクラス
// プログラム概要   : 自由検索部品マスタ（印刷） データクラスヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/27  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   FreeSearchPartsSet
    /// <summary>
    ///                      自由検索部品マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由検索部品マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/04/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class FreeSearchPartsSet
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

        /// <summary>BLコード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
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
        private Int32 _modelPrtsAdptYm;

        /// <summary>型式別部品廃止年月</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _modelPrtsAblsYm;

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

        /// <summary>車種全角名称</summary>
        /// <remarks>正式名称（カナ漢字混在で全角管理）</remarks>
        private string _modelFullName = "";

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>定価（浮動）</summary>
        private Double _listPrice;


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
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BLコード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード枝番プロパティ</br>
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
        public Int32 ModelPrtsAdptYm
        {
            get { return _modelPrtsAdptYm; }
            set { _modelPrtsAdptYm = value; }
        }

        /// public propaty name  :  ModelPrtsAblsYm
        /// <summary>型式別部品廃止年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAblsYm
        {
            get { return _modelPrtsAblsYm; }
            set { _modelPrtsAblsYm = value; }
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

        /// public propaty name  :  ModelFullName
        /// <summary>車種全角名称プロパティ</summary>
        /// <value>正式名称（カナ漢字混在で全角管理）</value>
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

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価（浮動）プロパティ</summary>
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


        /// <summary>
        /// 自由検索部品マスタコンストラクタ
        /// </summary>
        /// <returns>FreeSearchPartsSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchPartsSet()
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
        /// <param name="tbsPartsCode">BLコード</param>
        /// <param name="tbsPartsCdDerivedNo">BLコード枝番(※未使用項目（レイアウトには入れておく）)</param>
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
        /// <param name="engineModelNm">エンジン型式名称</param>
        /// <param name="engineDisplaceNm">排気量名称(型式により変動)</param>
        /// <param name="eDivNm">E区分名称(型式により変動)</param>
        /// <param name="transmissionNm">ミッション名称</param>
        /// <param name="wheelDriveMethodNm">駆動方式名称(新規追加)</param>
        /// <param name="shiftNm">シフト名称</param>
        /// <param name="createDate">作成日付(YYYYMMDD)</param>
        /// <param name="updateDate">更新年月日(YYYYMMDD)</param>
        /// <param name="modelFullName">車種全角名称(正式名称（カナ漢字混在で全角管理）)</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="bLGoodsHalfName">BL商品コード名称（半角）</param>
        /// <param name="listPrice">定価（浮動）</param>
        /// <returns>FreeSearchPartsSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchPartsSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string freSrchPrtPropNo, Int32 makerCode, Int32 modelCode, Int32 modelSubCode, string fullModel, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo, string goodsNo, string goodsNoNoneHyphen, Int32 goodsMakerCd, Double partsQty, string partsOpNm, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo, Int32 modelPrtsAblsFrameNo, string modelGradeNm, string bodyName, Int32 doorCount, string engineModelNm, string engineDisplaceNm, string eDivNm, string transmissionNm, string wheelDriveMethodNm, string shiftNm, Int32 createDate, Int32 updateDate, string modelFullName, string makerName, string bLGoodsHalfName, Double listPrice)
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
            this._modelPrtsAdptYm = modelPrtsAdptYm;
            this._modelPrtsAblsYm = modelPrtsAblsYm;
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
            this._modelFullName = modelFullName;
            this._makerName = makerName;
            this._bLGoodsHalfName = bLGoodsHalfName;
            this._listPrice = listPrice;

        }

        /// <summary>
        /// 自由検索部品マスタ複製処理
        /// </summary>
        /// <returns>FreeSearchPartsSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいFreeSearchPartsSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchPartsSet Clone()
        {
            return new FreeSearchPartsSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._freSrchPrtPropNo, this._makerCode, this._modelCode, this._modelSubCode, this._fullModel, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._goodsNo, this._goodsNoNoneHyphen, this._goodsMakerCd, this._partsQty, this._partsOpNm, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo, this._modelGradeNm, this._bodyName, this._doorCount, this._engineModelNm, this._engineDisplaceNm, this._eDivNm, this._transmissionNm, this._wheelDriveMethodNm, this._shiftNm, this._createDate, this._updateDate, this._modelFullName, this._makerName, this._bLGoodsHalfName, this._listPrice);
        }

        /// <summary>
        /// 自由検索部品マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のFreeSearchPartsSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(FreeSearchPartsSet target)
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
                 && (this.ModelFullName == target.ModelFullName)
                 && (this.MakerName == target.MakerName)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName)
                 && (this.ListPrice == target.ListPrice));
        }

        /// <summary>
        /// 自由検索部品マスタ比較処理
        /// </summary>
        /// <param name="freeSearchPartsSet1">
        ///                    比較するFreeSearchPartsSetクラスのインスタンス
        /// </param>
        /// <param name="freeSearchPartsSet2">比較するFreeSearchPartsSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(FreeSearchPartsSet freeSearchPartsSet1, FreeSearchPartsSet freeSearchPartsSet2)
        {
            return ((freeSearchPartsSet1.CreateDateTime == freeSearchPartsSet2.CreateDateTime)
                 && (freeSearchPartsSet1.UpdateDateTime == freeSearchPartsSet2.UpdateDateTime)
                 && (freeSearchPartsSet1.EnterpriseCode == freeSearchPartsSet2.EnterpriseCode)
                 && (freeSearchPartsSet1.FileHeaderGuid == freeSearchPartsSet2.FileHeaderGuid)
                 && (freeSearchPartsSet1.UpdEmployeeCode == freeSearchPartsSet2.UpdEmployeeCode)
                 && (freeSearchPartsSet1.UpdAssemblyId1 == freeSearchPartsSet2.UpdAssemblyId1)
                 && (freeSearchPartsSet1.UpdAssemblyId2 == freeSearchPartsSet2.UpdAssemblyId2)
                 && (freeSearchPartsSet1.LogicalDeleteCode == freeSearchPartsSet2.LogicalDeleteCode)
                 && (freeSearchPartsSet1.FreSrchPrtPropNo == freeSearchPartsSet2.FreSrchPrtPropNo)
                 && (freeSearchPartsSet1.MakerCode == freeSearchPartsSet2.MakerCode)
                 && (freeSearchPartsSet1.ModelCode == freeSearchPartsSet2.ModelCode)
                 && (freeSearchPartsSet1.ModelSubCode == freeSearchPartsSet2.ModelSubCode)
                 && (freeSearchPartsSet1.FullModel == freeSearchPartsSet2.FullModel)
                 && (freeSearchPartsSet1.TbsPartsCode == freeSearchPartsSet2.TbsPartsCode)
                 && (freeSearchPartsSet1.TbsPartsCdDerivedNo == freeSearchPartsSet2.TbsPartsCdDerivedNo)
                 && (freeSearchPartsSet1.GoodsNo == freeSearchPartsSet2.GoodsNo)
                 && (freeSearchPartsSet1.GoodsNoNoneHyphen == freeSearchPartsSet2.GoodsNoNoneHyphen)
                 && (freeSearchPartsSet1.GoodsMakerCd == freeSearchPartsSet2.GoodsMakerCd)
                 && (freeSearchPartsSet1.PartsQty == freeSearchPartsSet2.PartsQty)
                 && (freeSearchPartsSet1.PartsOpNm == freeSearchPartsSet2.PartsOpNm)
                 && (freeSearchPartsSet1.ModelPrtsAdptYm == freeSearchPartsSet2.ModelPrtsAdptYm)
                 && (freeSearchPartsSet1.ModelPrtsAblsYm == freeSearchPartsSet2.ModelPrtsAblsYm)
                 && (freeSearchPartsSet1.ModelPrtsAdptFrameNo == freeSearchPartsSet2.ModelPrtsAdptFrameNo)
                 && (freeSearchPartsSet1.ModelPrtsAblsFrameNo == freeSearchPartsSet2.ModelPrtsAblsFrameNo)
                 && (freeSearchPartsSet1.ModelGradeNm == freeSearchPartsSet2.ModelGradeNm)
                 && (freeSearchPartsSet1.BodyName == freeSearchPartsSet2.BodyName)
                 && (freeSearchPartsSet1.DoorCount == freeSearchPartsSet2.DoorCount)
                 && (freeSearchPartsSet1.EngineModelNm == freeSearchPartsSet2.EngineModelNm)
                 && (freeSearchPartsSet1.EngineDisplaceNm == freeSearchPartsSet2.EngineDisplaceNm)
                 && (freeSearchPartsSet1.EDivNm == freeSearchPartsSet2.EDivNm)
                 && (freeSearchPartsSet1.TransmissionNm == freeSearchPartsSet2.TransmissionNm)
                 && (freeSearchPartsSet1.WheelDriveMethodNm == freeSearchPartsSet2.WheelDriveMethodNm)
                 && (freeSearchPartsSet1.ShiftNm == freeSearchPartsSet2.ShiftNm)
                 && (freeSearchPartsSet1.CreateDate == freeSearchPartsSet2.CreateDate)
                 && (freeSearchPartsSet1.UpdateDate == freeSearchPartsSet2.UpdateDate)
                 && (freeSearchPartsSet1.ModelFullName == freeSearchPartsSet2.ModelFullName)
                 && (freeSearchPartsSet1.MakerName == freeSearchPartsSet2.MakerName)
                 && (freeSearchPartsSet1.BLGoodsHalfName == freeSearchPartsSet2.BLGoodsHalfName)
                 && (freeSearchPartsSet1.ListPrice == freeSearchPartsSet2.ListPrice));
        }
        /// <summary>
        /// 自由検索部品マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のFreeSearchPartsSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(FreeSearchPartsSet target)
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
            if (this.ModelFullName != target.ModelFullName) resList.Add("ModelFullName");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");

            return resList;
        }

        /// <summary>
        /// 自由検索部品マスタ比較処理
        /// </summary>
        /// <param name="freeSearchPartsSet1">比較するFreeSearchPartsSetクラスのインスタンス</param>
        /// <param name="freeSearchPartsSet2">比較するFreeSearchPartsSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(FreeSearchPartsSet freeSearchPartsSet1, FreeSearchPartsSet freeSearchPartsSet2)
        {
            ArrayList resList = new ArrayList();
            if (freeSearchPartsSet1.CreateDateTime != freeSearchPartsSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (freeSearchPartsSet1.UpdateDateTime != freeSearchPartsSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (freeSearchPartsSet1.EnterpriseCode != freeSearchPartsSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (freeSearchPartsSet1.FileHeaderGuid != freeSearchPartsSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (freeSearchPartsSet1.UpdEmployeeCode != freeSearchPartsSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (freeSearchPartsSet1.UpdAssemblyId1 != freeSearchPartsSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (freeSearchPartsSet1.UpdAssemblyId2 != freeSearchPartsSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (freeSearchPartsSet1.LogicalDeleteCode != freeSearchPartsSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (freeSearchPartsSet1.FreSrchPrtPropNo != freeSearchPartsSet2.FreSrchPrtPropNo) resList.Add("FreSrchPrtPropNo");
            if (freeSearchPartsSet1.MakerCode != freeSearchPartsSet2.MakerCode) resList.Add("MakerCode");
            if (freeSearchPartsSet1.ModelCode != freeSearchPartsSet2.ModelCode) resList.Add("ModelCode");
            if (freeSearchPartsSet1.ModelSubCode != freeSearchPartsSet2.ModelSubCode) resList.Add("ModelSubCode");
            if (freeSearchPartsSet1.FullModel != freeSearchPartsSet2.FullModel) resList.Add("FullModel");
            if (freeSearchPartsSet1.TbsPartsCode != freeSearchPartsSet2.TbsPartsCode) resList.Add("TbsPartsCode");
            if (freeSearchPartsSet1.TbsPartsCdDerivedNo != freeSearchPartsSet2.TbsPartsCdDerivedNo) resList.Add("TbsPartsCdDerivedNo");
            if (freeSearchPartsSet1.GoodsNo != freeSearchPartsSet2.GoodsNo) resList.Add("GoodsNo");
            if (freeSearchPartsSet1.GoodsNoNoneHyphen != freeSearchPartsSet2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (freeSearchPartsSet1.GoodsMakerCd != freeSearchPartsSet2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (freeSearchPartsSet1.PartsQty != freeSearchPartsSet2.PartsQty) resList.Add("PartsQty");
            if (freeSearchPartsSet1.PartsOpNm != freeSearchPartsSet2.PartsOpNm) resList.Add("PartsOpNm");
            if (freeSearchPartsSet1.ModelPrtsAdptYm != freeSearchPartsSet2.ModelPrtsAdptYm) resList.Add("ModelPrtsAdptYm");
            if (freeSearchPartsSet1.ModelPrtsAblsYm != freeSearchPartsSet2.ModelPrtsAblsYm) resList.Add("ModelPrtsAblsYm");
            if (freeSearchPartsSet1.ModelPrtsAdptFrameNo != freeSearchPartsSet2.ModelPrtsAdptFrameNo) resList.Add("ModelPrtsAdptFrameNo");
            if (freeSearchPartsSet1.ModelPrtsAblsFrameNo != freeSearchPartsSet2.ModelPrtsAblsFrameNo) resList.Add("ModelPrtsAblsFrameNo");
            if (freeSearchPartsSet1.ModelGradeNm != freeSearchPartsSet2.ModelGradeNm) resList.Add("ModelGradeNm");
            if (freeSearchPartsSet1.BodyName != freeSearchPartsSet2.BodyName) resList.Add("BodyName");
            if (freeSearchPartsSet1.DoorCount != freeSearchPartsSet2.DoorCount) resList.Add("DoorCount");
            if (freeSearchPartsSet1.EngineModelNm != freeSearchPartsSet2.EngineModelNm) resList.Add("EngineModelNm");
            if (freeSearchPartsSet1.EngineDisplaceNm != freeSearchPartsSet2.EngineDisplaceNm) resList.Add("EngineDisplaceNm");
            if (freeSearchPartsSet1.EDivNm != freeSearchPartsSet2.EDivNm) resList.Add("EDivNm");
            if (freeSearchPartsSet1.TransmissionNm != freeSearchPartsSet2.TransmissionNm) resList.Add("TransmissionNm");
            if (freeSearchPartsSet1.WheelDriveMethodNm != freeSearchPartsSet2.WheelDriveMethodNm) resList.Add("WheelDriveMethodNm");
            if (freeSearchPartsSet1.ShiftNm != freeSearchPartsSet2.ShiftNm) resList.Add("ShiftNm");
            if (freeSearchPartsSet1.CreateDate != freeSearchPartsSet2.CreateDate) resList.Add("CreateDate");
            if (freeSearchPartsSet1.UpdateDate != freeSearchPartsSet2.UpdateDate) resList.Add("UpdateDate");
            if (freeSearchPartsSet1.ModelFullName != freeSearchPartsSet2.ModelFullName) resList.Add("ModelFullName");
            if (freeSearchPartsSet1.MakerName != freeSearchPartsSet2.MakerName) resList.Add("MakerName");
            if (freeSearchPartsSet1.BLGoodsHalfName != freeSearchPartsSet2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (freeSearchPartsSet1.ListPrice != freeSearchPartsSet2.ListPrice) resList.Add("ListPrice");

            return resList;
        }
    }
}
