using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   DeleteCondition
    /// <summary>
    ///                      削除データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   削除データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2011/07/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2015/06/08 高騁</br>
    /// <br>管理番号　　　　 :   11100068-00</br>
    /// <br>                     REDMINE#45792掛率マスタ削除・削除しないの制御修正</br>  
    /// </remarks>
    public class DeleteCondition
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

        /// <summary>削除区分</summary>
        private Int32 _deleteCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点名称</summary>
        private string _sectionName = "";

        /// <summary>コード1</summary>
        private Int32 _code1;

        /// <summary>コード2</summary>
        private Int32 _code2;

        /// <summary>コード3</summary>
        private Int32 _code3;

        /// <summary>コード4</summary>
        private Int32 _code4;

        /// <summary>商品削除区分</summary>
        private Int32 _goodsDeleteCode;

        /// <summary>結合削除区分</summary>
        private Int32 _joinDeleteCode;

        /// <summary>掛率削除区分</summary>
        private Int32 _rateDeleteCode; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 

        /// <summary>商品削除件数</summary>
        private Int32 _goodsDeleteCnt;

        /// <summary>結合削除件数</summary>
        private Int32 _joinDeleteCnt;

        /// <summary>在庫削除件数</summary>
        private Int32 _stockDeleteCnt;

        /// <summary>掛率削除件数</summary>
        private Int32 _rateDeleteCnt; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 

        /// <summary>商品未削除件数</summary>
        private Int32 _goodsNotDeleteCnt;

        /// <summary>結合未削除件数</summary>
        private Int32 _joinNotDeleteCnt; 

        /// <summary>在庫未削除件数</summary>
        private Int32 _stockNotDeleteCnt;

        /// <summary>掛率削除件数</summary>
        private Int32 _rateNotDeleteCnt; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正

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

        /// public propaty name  :  DeleteCode
        /// <summary>削除区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteCode
        {
            get { return _deleteCode; }
            set { _deleteCode = value; }
        }

        /// public propaty name  :  GoodsMakerCode
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCode
        {
            get { return _goodsMakerCode; }
            set { _goodsMakerCode = value; }
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

        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  Code1
        /// <summary>コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Code1
        {
            get { return _code1; }
            set { _code1 = value; }
        }

        /// public propaty name  :  Code2
        /// <summary>コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Code2
        {
            get { return _code2; }
            set { _code2 = value; }
        }

        /// public propaty name  :  Code3
        /// <summary>コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Code3
        {
            get { return _code3; }
            set { _code3 = value; }
        }

        /// public propaty name  :  Code4
        /// <summary>コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Code4
        {
            get { return _code4; }
            set { _code4 = value; }
        }

        /// public propaty name  :  GoodsDeleteCode
        /// <summary>商品削除区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsDeleteCode
        {
            get { return _goodsDeleteCode; }
            set { _goodsDeleteCode = value; }
        }

        /// public propaty name  :  JoinDeleteCode
        /// <summary>結合削除区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDeleteCode
        {
            get { return _joinDeleteCode; }
            set { _joinDeleteCode = value; }
        }

        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
        /// public propaty name  :  RateDeleteCode
        /// <value>掛率削除区分プロパティ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateDeleteCode
        {
            get { return _rateDeleteCode; }
            set { _rateDeleteCode = value; }
        }
        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<

        /// public propaty name  :  GoodsDeleteCnt
        /// <summary>商品削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsDeleteCnt
        {
            get { return _goodsDeleteCnt; }
            set { _goodsDeleteCnt = value; }
        }

        /// public propaty name  :  JoinDeleteCnt
        /// <summary>結合削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDeleteCnt
        {
            get { return _joinDeleteCnt; }
            set { _joinDeleteCnt = value; }
        }

        /// public propaty name  :  StockDeleteCnt
        /// <summary>在庫削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDeleteCnt
        {
            get { return _stockDeleteCnt; }
            set { _stockDeleteCnt = value; }
        }

        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
        /// public propaty name  :  RateDeleteCnt
        /// <summary>掛率削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateDeleteCnt
        {
            get { return _rateDeleteCnt; }
            set { _rateDeleteCnt = value; }
        }
        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<

        /// public propaty name  :  GoodsNotDeleteCnt
        /// <summary>商品未削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品未削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNotDeleteCnt
        {
            get { return _goodsNotDeleteCnt; }
            set { _goodsNotDeleteCnt = value; }
        }

        /// public propaty name  :  JoinNotDeleteCnt
        /// <summary>結合未削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合未削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinNotDeleteCnt
        {
            get { return _joinNotDeleteCnt; }
            set { _joinNotDeleteCnt = value; }
        }

        /// public propaty name  :  StockNotDeleteCnt
        /// <summary>在庫未削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫未削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockNotDeleteCnt
        {
            get { return _stockNotDeleteCnt; }
            set { _stockNotDeleteCnt = value; }
        }

        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
        /// public propaty name  :  RateNotDeleteCnt
        /// <summary>掛率未削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率未削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateNotDeleteCnt
        {
            get { return _rateNotDeleteCnt; }
            set { _rateNotDeleteCnt = value; }
        }
        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<

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
        /// 削除データコンストラクタ
        /// </summary>
        /// <returns>DeleteConditionクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DeleteCondition()
        {
        }

        /// <summary>
        /// 削除データコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="deleteCode">削除区分</param>
        /// <param name="goodsMakerCode">商品メーカーコード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionName">拠点名称</param>
        /// <param name="code1">コード1</param>
        /// <param name="code2">コード2</param>
        /// <param name="code3">コード3</param>
        /// <param name="code4">コード4</param>
        /// <param name="goodsDeleteCode">商品削除区分</param>
        /// <param name="joinDeleteCode">結合削除区分</param>
        /// <param name="rateDeleteCode">掛率削除区分</param>
        /// <param name="goodsDeleteCnt">商品削除件数</param>
        /// <param name="joinDeleteCnt">結合削除件数</param>
        /// <param name="stockDeleteCnt">在庫削除件数</param>
        /// <param name="rateDeleteCnt">掛率削除件数</param> 
        /// <param name="goodsNotDeleteCnt">商品未削除件数</param>
        /// <param name="joinNotDeleteCnt">結合未削除件数</param>
        /// <param name="stockNotDeleteCnt">在庫未削除件数</param>
        /// <param name="rateNotDeleteCnt">掛率未削除件数</param>  
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>DeleteConditionクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public DeleteCondition(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 deleteCode, Int32 goodsMakerCode, string sectionCode, string sectionName, Int32 code1, Int32 code2, Int32 code3, Int32 code4, Int32 goodsDeleteCode, Int32 joinDeleteCode, Int32 goodsDeleteCnt, Int32 joinDeleteCnt, Int32 stockDeleteCnt, Int32 goodsNotDeleteCnt, Int32 joinNotDeleteCnt, Int32 stockNotDeleteCnt, string enterpriseName, string updEmployeeName) // DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
        public DeleteCondition(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 deleteCode, Int32 goodsMakerCode, string sectionCode, string sectionName, Int32 code1, Int32 code2, Int32 code3, Int32 code4, Int32 goodsDeleteCode, Int32 joinDeleteCode, Int32 rateDeleteCode, Int32 goodsDeleteCnt, Int32 joinDeleteCnt, Int32 stockDeleteCnt, Int32 rateDeleteCnt, Int32 goodsNotDeleteCnt, Int32 joinNotDeleteCnt, Int32 stockNotDeleteCnt, Int32 rateNotDeleteCnt, string enterpriseName, string updEmployeeName) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._deleteCode = deleteCode;
            this._goodsMakerCode = goodsMakerCode;
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._code1 = code1;
            this._code2 = code2;
            this._code3 = code3;
            this._code4 = code4;
            this._goodsDeleteCode = goodsDeleteCode;
            this._joinDeleteCode = joinDeleteCode;
            this._rateDeleteCode = rateDeleteCode;// ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            this._goodsDeleteCnt = goodsDeleteCnt;
            this._joinDeleteCnt = joinDeleteCnt;
            this._stockDeleteCnt = stockDeleteCnt;
            this._rateDeleteCnt = rateDeleteCnt;// ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            this._goodsNotDeleteCnt = goodsNotDeleteCnt;
            this._joinNotDeleteCnt = joinNotDeleteCnt;
            this._stockNotDeleteCnt = stockNotDeleteCnt;
            this._rateNotDeleteCnt = rateNotDeleteCnt;// ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 削除データ複製処理
        /// </summary>
        /// <returns>DeleteConditionクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいDeleteConditionクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DeleteCondition Clone()
        {
            //return new DeleteCondition(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._deleteCode, this._goodsMakerCode, this._sectionCode, this._sectionName, this._code1, this._code2, this._code3, this._code4, this._goodsDeleteCode, this._joinDeleteCode, this._goodsDeleteCnt, this._joinDeleteCnt, this._stockDeleteCnt, this._goodsNotDeleteCnt, this._joinNotDeleteCnt, this._stockNotDeleteCnt, this._enterpriseName, this._updEmployeeName); // DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            return new DeleteCondition(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._deleteCode, this._goodsMakerCode, this._sectionCode, this._sectionName, this._code1, this._code2, this._code3, this._code4, this._goodsDeleteCode, this._joinDeleteCode, this._rateDeleteCode, this._goodsDeleteCnt, this._joinDeleteCnt, this._stockDeleteCnt, this._rateDeleteCnt, this._goodsNotDeleteCnt, this._joinNotDeleteCnt, this._stockNotDeleteCnt, this._rateNotDeleteCnt, this._enterpriseName, this._updEmployeeName); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
        }

        /// <summary>
        /// 削除データ比較処理
        /// </summary>
        /// <param name="target">比較対象のDeleteConditionクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(DeleteCondition target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.DeleteCode == target.DeleteCode)
                 && (this.GoodsMakerCode == target.GoodsMakerCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionName == target.SectionName)
                 && (this.Code1 == target.Code1)
                 && (this.Code2 == target.Code2)
                 && (this.Code3 == target.Code3)
                 && (this.Code4 == target.Code4)
                 && (this.GoodsDeleteCode == target.GoodsDeleteCode)
                 && (this.JoinDeleteCode == target.JoinDeleteCode)
                 && (this.RateDeleteCode == target.RateDeleteCode) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                 && (this.GoodsDeleteCnt == target.GoodsDeleteCnt)
                 && (this.JoinDeleteCnt == target.JoinDeleteCnt)
                 && (this.StockDeleteCnt == target.StockDeleteCnt)
                 && (this.RateDeleteCnt == target.RateDeleteCnt) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                 && (this.GoodsNotDeleteCnt == target.GoodsNotDeleteCnt)
                 && (this.JoinNotDeleteCnt == target.JoinNotDeleteCnt)
                 && (this.StockNotDeleteCnt == target.StockNotDeleteCnt)
                 && (this.RateNotDeleteCnt == target.RateNotDeleteCnt) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 削除データ比較処理
        /// </summary>
        /// <param name="deleteCondition1">
        ///                    比較するDeleteConditionクラスのインスタンス
        /// </param>
        /// <param name="deleteCondition2">比較するDeleteConditionクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(DeleteCondition deleteCondition1, DeleteCondition deleteCondition2)
        {
            return ((deleteCondition1.CreateDateTime == deleteCondition2.CreateDateTime)
                 && (deleteCondition1.UpdateDateTime == deleteCondition2.UpdateDateTime)
                 && (deleteCondition1.EnterpriseCode == deleteCondition2.EnterpriseCode)
                 && (deleteCondition1.FileHeaderGuid == deleteCondition2.FileHeaderGuid)
                 && (deleteCondition1.UpdEmployeeCode == deleteCondition2.UpdEmployeeCode)
                 && (deleteCondition1.UpdAssemblyId1 == deleteCondition2.UpdAssemblyId1)
                 && (deleteCondition1.UpdAssemblyId2 == deleteCondition2.UpdAssemblyId2)
                 && (deleteCondition1.LogicalDeleteCode == deleteCondition2.LogicalDeleteCode)
                 && (deleteCondition1.DeleteCode == deleteCondition2.DeleteCode)
                 && (deleteCondition1.GoodsMakerCode == deleteCondition2.GoodsMakerCode)
                 && (deleteCondition1.SectionCode == deleteCondition2.SectionCode)
                 && (deleteCondition1.SectionName == deleteCondition2.SectionName)
                 && (deleteCondition1.Code1 == deleteCondition2.Code1)
                 && (deleteCondition1.Code2 == deleteCondition2.Code2)
                 && (deleteCondition1.Code3 == deleteCondition2.Code3)
                 && (deleteCondition1.Code4 == deleteCondition2.Code4)
                 && (deleteCondition1.GoodsDeleteCode == deleteCondition2.GoodsDeleteCode)
                 && (deleteCondition1.JoinDeleteCode == deleteCondition2.JoinDeleteCode)
                 && (deleteCondition1.RateDeleteCode == deleteCondition2.RateDeleteCode) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                 && (deleteCondition1.GoodsDeleteCnt == deleteCondition2.GoodsDeleteCnt)
                 && (deleteCondition1.JoinDeleteCnt == deleteCondition2.JoinDeleteCnt)
                 && (deleteCondition1.StockDeleteCnt == deleteCondition2.StockDeleteCnt)
                 && (deleteCondition1.RateDeleteCnt == deleteCondition2.RateDeleteCnt) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                 && (deleteCondition1.GoodsNotDeleteCnt == deleteCondition2.GoodsNotDeleteCnt)
                 && (deleteCondition1.JoinNotDeleteCnt == deleteCondition2.JoinNotDeleteCnt)
                 && (deleteCondition1.StockNotDeleteCnt == deleteCondition2.StockNotDeleteCnt)
                 && (deleteCondition1.RateNotDeleteCnt == deleteCondition2.RateNotDeleteCnt) // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
                 && (deleteCondition1.EnterpriseName == deleteCondition2.EnterpriseName)
                 && (deleteCondition1.UpdEmployeeName == deleteCondition2.UpdEmployeeName));
        }
        /// <summary>
        /// 削除データ比較処理
        /// </summary>
        /// <param name="target">比較対象のDeleteConditionクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(DeleteCondition target)
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
            if (this.DeleteCode != target.DeleteCode) resList.Add("DeleteCode");
            if (this.GoodsMakerCode != target.GoodsMakerCode) resList.Add("GoodsMakerCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.Code1 != target.Code1) resList.Add("Code1");
            if (this.Code2 != target.Code2) resList.Add("Code2");
            if (this.Code3 != target.Code3) resList.Add("Code3");
            if (this.Code4 != target.Code4) resList.Add("Code4");
            if (this.GoodsDeleteCode != target.GoodsDeleteCode) resList.Add("GoodsDeleteCode");
            if (this.JoinDeleteCode != target.JoinDeleteCode) resList.Add("JoinDeleteCode");
            if (this.RateDeleteCode != target.RateDeleteCode) resList.Add("RateDeleteCode"); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            if (this.GoodsDeleteCnt != target.GoodsDeleteCnt) resList.Add("GoodsDeleteCnt");
            if (this.JoinDeleteCnt != target.JoinDeleteCnt) resList.Add("JoinDeleteCnt");
            if (this.StockDeleteCnt != target.StockDeleteCnt) resList.Add("StockDeleteCnt");
            if (this.RateDeleteCnt != target.RateDeleteCnt) resList.Add("RateDeleteCnt"); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            if (this.GoodsNotDeleteCnt != target.GoodsNotDeleteCnt) resList.Add("GoodsNotDeleteCnt");
            if (this.JoinNotDeleteCnt != target.JoinNotDeleteCnt) resList.Add("JoinNotDeleteCnt");
            if (this.StockNotDeleteCnt != target.StockNotDeleteCnt) resList.Add("StockNotDeleteCnt");
            if (this.RateNotDeleteCnt != target.RateNotDeleteCnt) resList.Add("RateNotDeleteCnt"); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 削除データ比較処理
        /// </summary>
        /// <param name="deleteCondition1">比較するDeleteConditionクラスのインスタンス</param>
        /// <param name="deleteCondition2">比較するDeleteConditionクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(DeleteCondition deleteCondition1, DeleteCondition deleteCondition2)
        {
            ArrayList resList = new ArrayList();
            if (deleteCondition1.CreateDateTime != deleteCondition2.CreateDateTime) resList.Add("CreateDateTime");
            if (deleteCondition1.UpdateDateTime != deleteCondition2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (deleteCondition1.EnterpriseCode != deleteCondition2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (deleteCondition1.FileHeaderGuid != deleteCondition2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (deleteCondition1.UpdEmployeeCode != deleteCondition2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (deleteCondition1.UpdAssemblyId1 != deleteCondition2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (deleteCondition1.UpdAssemblyId2 != deleteCondition2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (deleteCondition1.LogicalDeleteCode != deleteCondition2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (deleteCondition1.DeleteCode != deleteCondition2.DeleteCode) resList.Add("DeleteCode");
            if (deleteCondition1.GoodsMakerCode != deleteCondition2.GoodsMakerCode) resList.Add("GoodsMakerCode");
            if (deleteCondition1.SectionCode != deleteCondition2.SectionCode) resList.Add("SectionCode");
            if (deleteCondition1.SectionName != deleteCondition2.SectionName) resList.Add("SectionName");
            if (deleteCondition1.Code1 != deleteCondition2.Code1) resList.Add("Code1");
            if (deleteCondition1.Code2 != deleteCondition2.Code2) resList.Add("Code2");
            if (deleteCondition1.Code3 != deleteCondition2.Code3) resList.Add("Code3");
            if (deleteCondition1.Code4 != deleteCondition2.Code4) resList.Add("Code4");
            if (deleteCondition1.GoodsDeleteCode != deleteCondition2.GoodsDeleteCode) resList.Add("GoodsDeleteCode");
            if (deleteCondition1.JoinDeleteCode != deleteCondition2.JoinDeleteCode) resList.Add("JoinDeleteCode");
            if (deleteCondition1.RateDeleteCode != deleteCondition2.RateDeleteCode) resList.Add("RateDeleteCode"); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            if (deleteCondition1.GoodsDeleteCnt != deleteCondition2.GoodsDeleteCnt) resList.Add("GoodsDeleteCnt");
            if (deleteCondition1.JoinDeleteCnt != deleteCondition2.JoinDeleteCnt) resList.Add("JoinDeleteCnt");
            if (deleteCondition1.StockDeleteCnt != deleteCondition2.StockDeleteCnt) resList.Add("StockDeleteCnt");
            if (deleteCondition1.RateDeleteCnt != deleteCondition2.RateDeleteCode) resList.Add("RateDeleteCnt"); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            if (deleteCondition1.GoodsNotDeleteCnt != deleteCondition2.GoodsNotDeleteCnt) resList.Add("GoodsNotDeleteCnt");
            if (deleteCondition1.JoinNotDeleteCnt != deleteCondition2.JoinNotDeleteCnt) resList.Add("JoinNotDeleteCnt");
            if (deleteCondition1.StockNotDeleteCnt != deleteCondition2.StockNotDeleteCnt) resList.Add("StockNotDeleteCnt");
            if (deleteCondition1.RateNotDeleteCnt != deleteCondition2.RateDeleteCode) resList.Add("RateNotDeleteCnt"); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            if (deleteCondition1.EnterpriseName != deleteCondition2.EnterpriseName) resList.Add("EnterpriseName");
            if (deleteCondition1.UpdEmployeeName != deleteCondition2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
