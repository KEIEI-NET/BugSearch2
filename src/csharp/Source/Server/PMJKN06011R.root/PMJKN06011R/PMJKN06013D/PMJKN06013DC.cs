using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FreeSearchPartsSRetWork
    /// <summary>
    ///                      自由検索部品抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由検索部品抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/04/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FreeSearchPartsSRetWork
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
        /// <remarks>車名コード(BL提供) 1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _modelCode;

        /// <summary>車種サブコード</summary>
        /// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
        private Int32 _modelSubCode;

        /// <summary>型式（フル型）</summary>
        /// <remarks>フル型式(44桁用)</remarks>
        private string _fullModel = "";

        /// <summary>ＢＬ商品コード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>ＢＬ商品コード枝番</summary>
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
        private DateTime _createDate;

        /// <summary>更新年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _updateDate;

        /// <summary>商品番号[商品マスタ]</summary>
        /// <remarks>※商品マスタ取得確認用</remarks>
        private string _goodsNoFromGoods = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>商品番号[価格マスタ]</summary>
        /// <remarks>※価格マスタ取得確認用</remarks>
        private string _goodsNoFromPrice = "";

        /// <summary>価格開始日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _priceStartDate;

        /// <summary>定価</summary>
        /// <remarks>0:オープン価格</remarks>
        private Double _listPrice;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0:通常／1:オープン価格</remarks>
        private Int32 _openPriceDiv;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>排ガス記号</summary>
        /// <remarks>※型式0</remarks>
        private string _exhaustGasSign = "";

        /// <summary>シリーズ型式</summary>
        /// <remarks>※型式1</remarks>
        private string _seriesModel = "";

        /// <summary>型式（類別記号）</summary>
        /// <remarks>※型式2</remarks>
        private string _categorySignModel = "";

        /// <summary>商品マスタＢＬコード</summary>
        /// <remarks>商品マスタから取得したＢＬコード</remarks>
        private Int32 _bLGoodsCodeFromGoods;


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
        /// <value>車名コード(BL提供) 1～899:提供分, 900～ユーザー登録</value>
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
        /// <summary>ＢＬ商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬ商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>ＢＬ商品コード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬ商品コード枝番プロパティ</br>
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
        public DateTime CreateDate
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
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  GoodsNoFromGoods
        /// <summary>商品番号[商品マスタ]プロパティ</summary>
        /// <value>※商品マスタ取得確認用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号[商品マスタ]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoFromGoods
        {
            get { return _goodsNoFromGoods; }
            set { _goodsNoFromGoods = value; }
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

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率ランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  GoodsNoFromPrice
        /// <summary>商品番号[価格マスタ]プロパティ</summary>
        /// <value>※価格マスタ取得確認用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号[価格マスタ]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoFromPrice
        {
            get { return _goodsNoFromPrice; }
            set { _goodsNoFromPrice = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>価格開始日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>定価プロパティ</summary>
        /// <value>0:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0:通常／1:オープン価格</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
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

        /// public propaty name  :  ExhaustGasSign
        /// <summary>排ガス記号プロパティ</summary>
        /// <value>※型式0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   排ガス記号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ExhaustGasSign
        {
            get { return _exhaustGasSign; }
            set { _exhaustGasSign = value; }
        }

        /// public propaty name  :  SeriesModel
        /// <summary>シリーズ型式プロパティ</summary>
        /// <value>※型式1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   シリーズ型式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SeriesModel
        {
            get { return _seriesModel; }
            set { _seriesModel = value; }
        }

        /// public propaty name  :  CategorySignModel
        /// <summary>型式（類別記号）プロパティ</summary>
        /// <value>※型式2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式（類別記号）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CategorySignModel
        {
            get { return _categorySignModel; }
            set { _categorySignModel = value; }
        }

        /// public propaty name  :  BLGoodsCodeFromGoods
        /// <summary>商品マスタＢＬコードプロパティ</summary>
        /// <value>※商品マスタから取得したＢＬコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品マスタＢＬコード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeFromGoods
        {
            get { return _bLGoodsCodeFromGoods; }
            set { _bLGoodsCodeFromGoods = value; }
        }

        /// <summary>
        /// 自由検索部品抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>FreeSearchPartsSRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public FreeSearchPartsSRetWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>FreeSearchPartsSRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   FreeSearchPartsSRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class FreeSearchPartsSRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  FreeSearchPartsSRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is FreeSearchPartsSRetWork || graph is ArrayList || graph is FreeSearchPartsSRetWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( FreeSearchPartsSRetWork ).FullName ) );

            if ( graph != null && graph is FreeSearchPartsSRetWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsSRetWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is FreeSearchPartsSRetWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((FreeSearchPartsSRetWork[])graph).Length;
            }
            else if ( graph is FreeSearchPartsSRetWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add( typeof( string ) ); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add( typeof( byte[] ) );  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add( typeof( string ) ); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add( typeof( string ) ); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add( typeof( string ) ); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //LogicalDeleteCode
            //自由検索部品固有番号
            serInfo.MemberInfo.Add( typeof( string ) ); //FreSrchPrtPropNo
            //メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
            //車種コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelCode
            //車種サブコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelSubCode
            //型式（フル型）
            serInfo.MemberInfo.Add( typeof( string ) ); //FullModel
            //ＢＬ商品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TbsPartsCode
            //ＢＬ商品コード枝番
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TbsPartsCdDerivedNo
            //商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            //ハイフン無商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNoNoneHyphen
            //商品メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //部品QTY
            serInfo.MemberInfo.Add( typeof( Double ) ); //PartsQty
            //部品オプション名称
            serInfo.MemberInfo.Add( typeof( string ) ); //PartsOpNm
            //型式別部品採用年月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelPrtsAdptYm
            //型式別部品廃止年月
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelPrtsAblsYm
            //型式別部品採用車台番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelPrtsAdptFrameNo
            //型式別部品廃止車台番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ModelPrtsAblsFrameNo
            //型式グレード名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ModelGradeNm
            //ボディー名称
            serInfo.MemberInfo.Add( typeof( string ) ); //BodyName
            //ドア数
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //DoorCount
            //エンジン型式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineModelNm
            //排気量名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EngineDisplaceNm
            //E区分名称
            serInfo.MemberInfo.Add( typeof( string ) ); //EDivNm
            //ミッション名称
            serInfo.MemberInfo.Add( typeof( string ) ); //TransmissionNm
            //駆動方式名称
            serInfo.MemberInfo.Add( typeof( string ) ); //WheelDriveMethodNm
            //シフト名称
            serInfo.MemberInfo.Add( typeof( string ) ); //ShiftNm
            //作成日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CreateDate
            //更新年月日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //UpdateDate
            //商品番号[商品マスタ]
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNoFromGoods
            //商品名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //商品名称カナ
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNameKana
            //商品掛率ランク
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsRateRank
            //商品番号[価格マスタ]
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNoFromPrice
            //価格開始日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //PriceStartDate
            //定価
            serInfo.MemberInfo.Add( typeof( double ) ); //ListPrice
            //オープン価格区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //OpenPriceDiv
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add( typeof( string ) ); //BLGoodsFullName
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add( typeof( string ) ); //BLGoodsHalfName
            //排ガス記号
            serInfo.MemberInfo.Add( typeof( string ) ); //ExhaustGasSign
            //シリーズ型式
            serInfo.MemberInfo.Add( typeof( string ) ); //SeriesModel
            //型式（類別記号）
            serInfo.MemberInfo.Add( typeof( string ) ); //CategorySignModel
            //商品マスタＢＬコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCodeFromGoods

            serInfo.Serialize( writer, serInfo );
            if ( graph is FreeSearchPartsSRetWork )
            {
                FreeSearchPartsSRetWork temp = (FreeSearchPartsSRetWork)graph;

                SetFreeSearchPartsSRetWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is FreeSearchPartsSRetWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (FreeSearchPartsSRetWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( FreeSearchPartsSRetWork temp in lst )
                {
                    SetFreeSearchPartsSRetWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// FreeSearchPartsSRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 49;

        /// <summary>
        ///  FreeSearchPartsSRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetFreeSearchPartsSRetWork( System.IO.BinaryWriter writer, FreeSearchPartsSRetWork temp )
        {
            //作成日時
            writer.Write( (Int64)temp.CreateDateTime.Ticks );
            //更新日時
            writer.Write( (Int64)temp.UpdateDateTime.Ticks );
            //企業コード
            writer.Write( temp.EnterpriseCode );
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write( fileHeaderGuidArray.Length );
            writer.Write( temp.FileHeaderGuid.ToByteArray() );
            //更新従業員コード
            writer.Write( temp.UpdEmployeeCode );
            //更新アセンブリID1
            writer.Write( temp.UpdAssemblyId1 );
            //更新アセンブリID2
            writer.Write( temp.UpdAssemblyId2 );
            //論理削除区分
            writer.Write( temp.LogicalDeleteCode );
            //自由検索部品固有番号
            writer.Write( temp.FreSrchPrtPropNo );
            //メーカーコード
            writer.Write( temp.MakerCode );
            //車種コード
            writer.Write( temp.ModelCode );
            //車種サブコード
            writer.Write( temp.ModelSubCode );
            //型式（フル型）
            writer.Write( temp.FullModel );
            //ＢＬ商品コード
            writer.Write( temp.TbsPartsCode );
            //ＢＬ商品コード枝番
            writer.Write( temp.TbsPartsCdDerivedNo );
            //商品番号
            writer.Write( temp.GoodsNo );
            //ハイフン無商品番号
            writer.Write( temp.GoodsNoNoneHyphen );
            //商品メーカーコード
            writer.Write( temp.GoodsMakerCd );
            //部品QTY
            writer.Write( temp.PartsQty );
            //部品オプション名称
            writer.Write( temp.PartsOpNm );
            //型式別部品採用年月
            writer.Write( (Int64)temp.ModelPrtsAdptYm.Ticks );
            //型式別部品廃止年月
            writer.Write( (Int64)temp.ModelPrtsAblsYm.Ticks );
            //型式別部品採用車台番号
            writer.Write( temp.ModelPrtsAdptFrameNo );
            //型式別部品廃止車台番号
            writer.Write( temp.ModelPrtsAblsFrameNo );
            //型式グレード名称
            writer.Write( temp.ModelGradeNm );
            //ボディー名称
            writer.Write( temp.BodyName );
            //ドア数
            writer.Write( temp.DoorCount );
            //エンジン型式名称
            writer.Write( temp.EngineModelNm );
            //排気量名称
            writer.Write( temp.EngineDisplaceNm );
            //E区分名称
            writer.Write( temp.EDivNm );
            //ミッション名称
            writer.Write( temp.TransmissionNm );
            //駆動方式名称
            writer.Write( temp.WheelDriveMethodNm );
            //シフト名称
            writer.Write( temp.ShiftNm );
            //作成日付
            writer.Write( (Int64)temp.CreateDate.Ticks );
            //更新年月日
            writer.Write( (Int64)temp.UpdateDate.Ticks );
            //商品番号[商品マスタ]
            writer.Write( temp.GoodsNoFromGoods );
            //商品名称
            writer.Write( temp.GoodsName );
            //商品名称カナ
            writer.Write( temp.GoodsNameKana );
            //商品掛率ランク
            writer.Write( temp.GoodsRateRank );
            //商品番号[価格マスタ]
            writer.Write( temp.GoodsNoFromPrice );
            //価格開始日
            writer.Write( (Int64)temp.PriceStartDate.Ticks );
            //定価
            writer.Write( temp.ListPrice );
            //オープン価格区分
            writer.Write( temp.OpenPriceDiv );
            //BL商品コード名称（全角）
            writer.Write( temp.BLGoodsFullName );
            //BL商品コード名称（半角）
            writer.Write( temp.BLGoodsHalfName );
            //排ガス記号
            writer.Write( temp.ExhaustGasSign );
            //シリーズ型式
            writer.Write( temp.SeriesModel );
            //型式（類別記号）
            writer.Write( temp.CategorySignModel );
            //商品マスタＢＬコード
            writer.Write( temp.BLGoodsCodeFromGoods );
        }

        /// <summary>
        ///  FreeSearchPartsSRetWorkインスタンス取得
        /// </summary>
        /// <returns>FreeSearchPartsSRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private FreeSearchPartsSRetWork GetFreeSearchPartsSRetWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            FreeSearchPartsSRetWork temp = new FreeSearchPartsSRetWork();

            //作成日時
            temp.CreateDateTime = new DateTime( reader.ReadInt64() );
            //更新日時
            temp.UpdateDateTime = new DateTime( reader.ReadInt64() );
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes( lenOfFileHeaderGuidArray );
            temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //自由検索部品固有番号
            temp.FreSrchPrtPropNo = reader.ReadString();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //車種コード
            temp.ModelCode = reader.ReadInt32();
            //車種サブコード
            temp.ModelSubCode = reader.ReadInt32();
            //型式（フル型）
            temp.FullModel = reader.ReadString();
            //ＢＬ商品コード
            temp.TbsPartsCode = reader.ReadInt32();
            //ＢＬ商品コード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //ハイフン無商品番号
            temp.GoodsNoNoneHyphen = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //部品QTY
            temp.PartsQty = reader.ReadDouble();
            //部品オプション名称
            temp.PartsOpNm = reader.ReadString();
            //型式別部品採用年月
            temp.ModelPrtsAdptYm = new DateTime( reader.ReadInt64() );
            //型式別部品廃止年月
            temp.ModelPrtsAblsYm = new DateTime( reader.ReadInt64() );
            //型式別部品採用車台番号
            temp.ModelPrtsAdptFrameNo = reader.ReadInt32();
            //型式別部品廃止車台番号
            temp.ModelPrtsAblsFrameNo = reader.ReadInt32();
            //型式グレード名称
            temp.ModelGradeNm = reader.ReadString();
            //ボディー名称
            temp.BodyName = reader.ReadString();
            //ドア数
            temp.DoorCount = reader.ReadInt32();
            //エンジン型式名称
            temp.EngineModelNm = reader.ReadString();
            //排気量名称
            temp.EngineDisplaceNm = reader.ReadString();
            //E区分名称
            temp.EDivNm = reader.ReadString();
            //ミッション名称
            temp.TransmissionNm = reader.ReadString();
            //駆動方式名称
            temp.WheelDriveMethodNm = reader.ReadString();
            //シフト名称
            temp.ShiftNm = reader.ReadString();
            //作成日付
            temp.CreateDate = new DateTime( reader.ReadInt64() );
            //更新年月日
            temp.UpdateDate = new DateTime( reader.ReadInt64() );
            //商品番号[商品マスタ]
            temp.GoodsNoFromGoods = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //商品番号[価格マスタ]
            temp.GoodsNoFromPrice = reader.ReadString();
            //価格開始日
            temp.PriceStartDate = new DateTime( reader.ReadInt64() );
            //定価
            temp.ListPrice = reader.ReadDouble();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();
            //排ガス記号
            temp.ExhaustGasSign = reader.ReadString();
            //シリーズ型式
            temp.SeriesModel = reader.ReadString();
            //型式（類別記号）
            temp.CategorySignModel = reader.ReadString();
            //商品マスタＢＬコード
            temp.BLGoodsCodeFromGoods = reader.ReadInt32();

            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>FreeSearchPartsSRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   FreeSearchPartsSRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                FreeSearchPartsSRetWork temp = GetFreeSearchPartsSRetWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (FreeSearchPartsSRetWork[])lst.ToArray( typeof( FreeSearchPartsSRetWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
