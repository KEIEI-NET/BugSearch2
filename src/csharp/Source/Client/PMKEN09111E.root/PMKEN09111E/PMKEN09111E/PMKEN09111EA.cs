using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   TBOSearchU
    /// <summary>
    ///                      TBO検索マスタ（ユーザー登録）
    /// </summary>
    /// <remarks>
    /// <br>note             :   TBO検索マスタ（ユーザー登録）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/12/6</br>
    /// <br>Genarated Date   :   2008/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  杉村</br>
    /// <br>                 :   β版→PM.NS対応</br>
    /// <br>Update Note      :   2008/10/17  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   BL商品コード</br>
    /// </remarks>
    public class TBOSearchU
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

        /// <summary>No.</summary>
        /// <remarks>ガイド用</remarks>
        private int _no;

        /// <summary>BL商品コード</summary>
        /// <remarks>提供:1～9999 ユーザー:10000～</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>装備分類</summary>
        /// <remarks>例）1001：バッテリ</remarks>
        private Int32 _equipGenreCode;

        /// <summary>装備名称</summary>
        /// <remarks>例）100D26L（バッテリ規格）</remarks>
        private string _equipName = "";

        /// <summary>車両結合表示順位</summary>
        /// <remarks>4,5,6,7,8が同一の結合が複数存在する場合の連番</remarks>
        private Int32 _carInfoJoinDispOrder;

        /// <summary>結合先メーカーコード</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>結合先品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>結合ＱＴＹ</summary>
        private Double _joinQty;

        /// <summary>装備規格・特記事項</summary>
        private string _equipSpecialNote = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>BL商品コード名称</summary>
        private string _bLGoodsName = "";

        /// <summary>結合先メーカー名称</summary>
        private string _joinDestMakerName = "";

        /// <summary>結合先品名</summary>
        private string _joinDestGoodsName = "";
 

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

        /// public propaty name  :  No
        /// <summary>Noプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Noプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int No
        {
            get { return _no; }
            set { _no = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// <value>提供:1～9999 ユーザー:10000～</value>
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

        /// public propaty name  :  EquipGenreCode
        /// <summary>装備分類プロパティ</summary>
        /// <value>例）1001：バッテリ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EquipGenreCode
        {
            get { return _equipGenreCode; }
            set { _equipGenreCode = value; }
        }

        /// public propaty name  :  EquipName
        /// <summary>装備名称プロパティ</summary>
        /// <value>例）100D26L（バッテリ規格）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EquipName
        {
            get { return _equipName; }
            set { _equipName = value; }
        }

        /// public propaty name  :  CarInfoJoinDispOrder
        /// <summary>車両結合表示順位プロパティ</summary>
        /// <value>4,5,6,7,8が同一の結合が複数存在する場合の連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車両結合表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarInfoJoinDispOrder
        {
            get { return _carInfoJoinDispOrder; }
            set { _carInfoJoinDispOrder = value; }
        }

        /// public propaty name  :  JoinDestMakerCd
        /// <summary>結合先メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDestMakerCd
        {
            get { return _joinDestMakerCd; }
            set { _joinDestMakerCd = value; }
        }

        /// public propaty name  :  JoinDestPartsNo
        /// <summary>結合先品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDestPartsNo
        {
            get { return _joinDestPartsNo; }
            set { _joinDestPartsNo = value; }
        }

        /// public propaty name  :  JoinQty
        /// <summary>結合ＱＴＹプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合ＱＴＹプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  EquipSpecialNote
        /// <summary>装備規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EquipSpecialNote
        {
            get { return _equipSpecialNote; }
            set { _equipSpecialNote = value; }
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

        /// public propaty name  :  JoinDestMakerName
        /// <summary>結合先メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDestMakerName
        {
            get { return _joinDestMakerName; }
            set { _joinDestMakerName = value; }
        }

        /// public propaty name  :  JoinDestGoodsName
        /// <summary>結合先品名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDestGoodsName
        {
            get { return _joinDestGoodsName; }
            set { _joinDestGoodsName = value; }
        }

        /// <summary>
        /// TBO検索マスタ（ユーザー登録）コンストラクタ
        /// </summary>
        /// <returns>TBOSearchUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBOSearchU()
        {
        }

        /// <summary>
        /// TBO検索マスタ（ユーザー登録）コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="bLGoodsCode">BL商品コード(提供:1～9999 ユーザー:10000～)</param>
        /// <param name="equipGenreCode">装備分類(例）1001：バッテリ)</param>
        /// <param name="equipName">装備名称(例）100D26L（バッテリ規格）)</param>
        /// <param name="carInfoJoinDispOrder">車両結合表示順位(4,5,6,7,8が同一の結合が複数存在する場合の連番)</param>
        /// <param name="joinDestMakerCd">結合先メーカーコード</param>
        /// <param name="joinDestPartsNo">結合先品番(－付き品番)(ハイフン付き)</param>
        /// <param name="joinQty">結合ＱＴＹ</param>
        /// <param name="equipSpecialNote">装備規格・特記事項</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="no">No</param>
        /// <param name="makerName">メーカー名</param>
        /// <param name="goodsName">品名</param>
        /// <returns>TBOSearchUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBOSearchU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 bLGoodsCode, Int32 equipGenreCode, string equipName, Int32 carInfoJoinDispOrder, Int32 joinDestMakerCd, string joinDestPartsNo, Double joinQty, string equipSpecialNote, string enterpriseName, string updEmployeeName, string bLGoodsName, int no, string makerName, string goodsName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._bLGoodsCode = bLGoodsCode;
            this._equipGenreCode = equipGenreCode;
            this._equipName = equipName;
            this._carInfoJoinDispOrder = carInfoJoinDispOrder;
            this._joinDestMakerCd = joinDestMakerCd;
            this._joinDestPartsNo = joinDestPartsNo;
            this._joinQty = joinQty;
            this._equipSpecialNote = equipSpecialNote;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;
            this._no = no;
            this._joinDestMakerName = makerName;
            this._joinDestGoodsName = goodsName;
        }

        /// <summary>
        /// TBO検索マスタ（ユーザー登録）複製処理
        /// </summary>
        /// <returns>TBOSearchUクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいTBOSearchUクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBOSearchU Clone()
        {
            return new TBOSearchU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._bLGoodsCode, this._equipGenreCode, this._equipName, this._carInfoJoinDispOrder, this._joinDestMakerCd, this._joinDestPartsNo, this._joinQty, this._equipSpecialNote, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._no, this._joinDestMakerName, this._joinDestGoodsName);
        }

        /// <summary>
        /// TBO検索マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のTBOSearchUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(TBOSearchU target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.EquipGenreCode == target.EquipGenreCode)
                 && (this.EquipName == target.EquipName)
                 && (this.CarInfoJoinDispOrder == target.CarInfoJoinDispOrder)
                 && (this.JoinDestMakerCd == target.JoinDestMakerCd)
                 && (this.JoinDestPartsNo == target.JoinDestPartsNo)
                 && (this.JoinQty == target.JoinQty)
                 && (this.EquipSpecialNote == target.EquipSpecialNote)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.JoinDestMakerName == target.JoinDestMakerName)
                 && (this.JoinDestGoodsName == target.JoinDestGoodsName)
                 );
        }

        /// <summary>
        /// TBO検索マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="tBOSearchU1">
        ///                    比較するTBOSearchUクラスのインスタンス
        /// </param>
        /// <param name="tBOSearchU2">比較するTBOSearchUクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(TBOSearchU tBOSearchU1, TBOSearchU tBOSearchU2)
        {
            return ((tBOSearchU1.CreateDateTime == tBOSearchU2.CreateDateTime)
                 && (tBOSearchU1.UpdateDateTime == tBOSearchU2.UpdateDateTime)
                 && (tBOSearchU1.EnterpriseCode == tBOSearchU2.EnterpriseCode)
                 && (tBOSearchU1.FileHeaderGuid == tBOSearchU2.FileHeaderGuid)
                 && (tBOSearchU1.UpdEmployeeCode == tBOSearchU2.UpdEmployeeCode)
                 && (tBOSearchU1.UpdAssemblyId1 == tBOSearchU2.UpdAssemblyId1)
                 && (tBOSearchU1.UpdAssemblyId2 == tBOSearchU2.UpdAssemblyId2)
                 && (tBOSearchU1.LogicalDeleteCode == tBOSearchU2.LogicalDeleteCode)
                 && (tBOSearchU1.BLGoodsCode == tBOSearchU2.BLGoodsCode)
                 && (tBOSearchU1.EquipGenreCode == tBOSearchU2.EquipGenreCode)
                 && (tBOSearchU1.EquipName == tBOSearchU2.EquipName)
                 && (tBOSearchU1.CarInfoJoinDispOrder == tBOSearchU2.CarInfoJoinDispOrder)
                 && (tBOSearchU1.JoinDestMakerCd == tBOSearchU2.JoinDestMakerCd)
                 && (tBOSearchU1.JoinDestPartsNo == tBOSearchU2.JoinDestPartsNo)
                 && (tBOSearchU1.JoinQty == tBOSearchU2.JoinQty)
                 && (tBOSearchU1.EquipSpecialNote == tBOSearchU2.EquipSpecialNote)
                 && (tBOSearchU1.EnterpriseName == tBOSearchU2.EnterpriseName)
                 && (tBOSearchU1.UpdEmployeeName == tBOSearchU2.UpdEmployeeName)
                 && (tBOSearchU1.BLGoodsName == tBOSearchU2.BLGoodsName)
                 && (tBOSearchU1.JoinDestMakerName == tBOSearchU2.JoinDestMakerName)
                 && (tBOSearchU1.JoinDestGoodsName == tBOSearchU2.JoinDestGoodsName)
                 );
        }
        /// <summary>
        /// TBO検索マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="target">比較対象のTBOSearchUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(TBOSearchU target)
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
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.EquipGenreCode != target.EquipGenreCode) resList.Add("EquipGenreCode");
            if (this.EquipName != target.EquipName) resList.Add("EquipName");
            if (this.CarInfoJoinDispOrder != target.CarInfoJoinDispOrder) resList.Add("CarInfoJoinDispOrder");
            if (this.JoinDestMakerCd != target.JoinDestMakerCd) resList.Add("JoinDestMakerCd");
            if (this.JoinDestPartsNo != target.JoinDestPartsNo) resList.Add("JoinDestPartsNo");
            if (this.JoinQty != target.JoinQty) resList.Add("JoinQty");
            if (this.EquipSpecialNote != target.EquipSpecialNote) resList.Add("EquipSpecialNote");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.JoinDestMakerName != target.JoinDestMakerName) resList.Add("JoinDestMakerName");
            if (this.JoinDestGoodsName != target.JoinDestGoodsName) resList.Add("JoinDestGoodsName");

            return resList;
        }

        /// <summary>
        /// TBO検索マスタ（ユーザー登録）比較処理
        /// </summary>
        /// <param name="tBOSearchU1">比較するTBOSearchUクラスのインスタンス</param>
        /// <param name="tBOSearchU2">比較するTBOSearchUクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchUクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(TBOSearchU tBOSearchU1, TBOSearchU tBOSearchU2)
        {
            ArrayList resList = new ArrayList();
            if (tBOSearchU1.CreateDateTime != tBOSearchU2.CreateDateTime) resList.Add("CreateDateTime");
            if (tBOSearchU1.UpdateDateTime != tBOSearchU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (tBOSearchU1.EnterpriseCode != tBOSearchU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (tBOSearchU1.FileHeaderGuid != tBOSearchU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (tBOSearchU1.UpdEmployeeCode != tBOSearchU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (tBOSearchU1.UpdAssemblyId1 != tBOSearchU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (tBOSearchU1.UpdAssemblyId2 != tBOSearchU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (tBOSearchU1.LogicalDeleteCode != tBOSearchU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (tBOSearchU1.BLGoodsCode != tBOSearchU2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (tBOSearchU1.EquipGenreCode != tBOSearchU2.EquipGenreCode) resList.Add("EquipGenreCode");
            if (tBOSearchU1.EquipName != tBOSearchU2.EquipName) resList.Add("EquipName");
            if (tBOSearchU1.CarInfoJoinDispOrder != tBOSearchU2.CarInfoJoinDispOrder) resList.Add("CarInfoJoinDispOrder");
            if (tBOSearchU1.JoinDestMakerCd != tBOSearchU2.JoinDestMakerCd) resList.Add("JoinDestMakerCd");
            if (tBOSearchU1.JoinDestPartsNo != tBOSearchU2.JoinDestPartsNo) resList.Add("JoinDestPartsNo");
            if (tBOSearchU1.JoinQty != tBOSearchU2.JoinQty) resList.Add("JoinQty");
            if (tBOSearchU1.EquipSpecialNote != tBOSearchU2.EquipSpecialNote) resList.Add("EquipSpecialNote");
            if (tBOSearchU1.EnterpriseName != tBOSearchU2.EnterpriseName) resList.Add("EnterpriseName");
            if (tBOSearchU1.UpdEmployeeName != tBOSearchU2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (tBOSearchU1.BLGoodsName != tBOSearchU2.BLGoodsName) resList.Add("BLGoodsName");
            if (tBOSearchU1.JoinDestMakerName != tBOSearchU2.JoinDestMakerName) resList.Add("JoinDestMakerName");
            if (tBOSearchU1.JoinDestGoodsName != tBOSearchU2.JoinDestGoodsName) resList.Add("JoinDestGoodsName");

            return resList;
        }
    }
}
