using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccItemGrid
    /// <summary>
    ///                      品目グリッドマスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   品目グリッドマスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/5/1  杉村</br>
    /// <br>                 :   仕入先掛率グループコードを削除</br>
    /// <br>Update Note      :   2008/9/12  杉村</br>
    /// <br>                 :   ○桁数修正</br>
    /// <br>                 :   仕入先電話番号1の桁数を１６に変更</br>
    /// <br>                 :   仕入先電話番号2の桁数を１６に変更</br>
    /// <br>Update Note      :   2009/1/28  杉村</br>
    /// <br>                 :   ○桁数変更</br>
    /// <br>                 :   支払月区分名称</br>
    /// <br>                 :   nvarchar 3文字→4文字</br>
    /// <br>Update Note      :   2009/2/6  杉村</br>
    /// <br>                 :   ○補足修正</br>
    /// <br>                 :   支払条件</br>
    /// <br>                 :   10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   51:現金,52:振込,53:小切手,54:手形56:相殺,58:その他</br>
    /// <br>Update Note      :   2013/05/30 30747 三戸 伸悟</br>
    /// <br>                 :   2013/99/99配信 SCM障害№10541対応</br>
    /// <br>                 :   品目グループ画像コード追加</br>
    /// </remarks>
    public class PccItemGrid
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

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>問合せ条件</summary>
        private string _inqCondition = "";

        /// <summary>PCC自社コード</summary>
        /// <remarks>PMの得意先コード</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>PCC自社名称</summary>
        private string _pccCompanyName = "";

        /// <summary>品目グループコード1</summary>
        /// <remarks>1～5の使用を想定</remarks>
        private Int32 _itemGroupCode1;

        /// <summary>品目グループ名称1</summary>
        private string _itemGroupName1 = "";

        /// <summary>品目グループ表示順位1</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int32 _itemGrpDspOdr1;

        /// <summary>品目グループコード2</summary>
        /// <remarks>1～5の使用を想定</remarks>
        private Int32 _itemGroupCode2;

        /// <summary>品目グループ名称2</summary>
        private string _itemGroupName2 = "";

        /// <summary>品目グループ表示順位2</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int32 _itemGrpDspOdr2;

        /// <summary>品目グループコード3</summary>
        /// <remarks>1～5の使用を想定</remarks>
        private Int32 _itemGroupCode3;

        /// <summary>品目グループ名称3</summary>
        private string _itemGroupName3 = "";

        /// <summary>品目グループ表示順位3</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int32 _itemGrpDspOdr3;

        /// <summary>品目グループコード4</summary>
        /// <remarks>1～5の使用を想定</remarks>
        private Int32 _itemGroupCode4;

        /// <summary>品目グループ名称4</summary>
        private string _itemGroupName4 = "";

        /// <summary>品目グループ表示順位4</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int32 _itemGrpDspOdr4;

        /// <summary>品目グループコード5</summary>
        /// <remarks>1～5の使用を想定</remarks>
        private Int32 _itemGroupCode5;

        /// <summary>品目グループ名称5</summary>
        private string _itemGroupName5 = "";

        /// <summary>品目グループ表示順位5</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int32 _itemGrpDspOdr5;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>品目グループ画像コード1</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int16 _itemGrpImgCode1;

        /// <summary>品目グループ画像コード2</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int16 _itemGrpImgCode2;

        /// <summary>品目グループ画像コード3</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int16 _itemGrpImgCode3;

        /// <summary>品目グループ画像コード4</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int16 _itemGrpImgCode4;

        /// <summary>品目グループ画像コード5</summary>
        /// <remarks>左から順に1～5</remarks>
        private Int16 _itemGrpImgCode5;
        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  InqCondition
        /// <summary>問合せ条件プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqCondition
        {
            get { return _inqCondition; }
            set { _inqCondition = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC自社コードプロパティ</summary>
        /// <value>PMの得意先コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC自社コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  PccCompanyName
        /// <summary>PCC自社名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC自社名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PccCompanyName
        {
            get { return _pccCompanyName; }
            set { _pccCompanyName = value; }
        }

        /// public propaty name  :  ItemGroupCode1
        /// <summary>品目グループコード1プロパティ</summary>
        /// <value>1～5の使用を想定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループコード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGroupCode1
        {
            get { return _itemGroupCode1; }
            set { _itemGroupCode1 = value; }
        }

        /// public propaty name  :  ItemGroupName1
        /// <summary>品目グループ名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ItemGroupName1
        {
            get { return _itemGroupName1; }
            set { _itemGroupName1 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr1
        /// <summary>品目グループ表示順位1プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ表示順位1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr1
        {
            get { return _itemGrpDspOdr1; }
            set { _itemGrpDspOdr1 = value; }
        }

        /// public propaty name  :  ItemGroupCode2
        /// <summary>品目グループコード2プロパティ</summary>
        /// <value>1～5の使用を想定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループコード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGroupCode2
        {
            get { return _itemGroupCode2; }
            set { _itemGroupCode2 = value; }
        }

        /// public propaty name  :  ItemGroupName2
        /// <summary>品目グループ名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ItemGroupName2
        {
            get { return _itemGroupName2; }
            set { _itemGroupName2 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr2
        /// <summary>品目グループ表示順位2プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ表示順位2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr2
        {
            get { return _itemGrpDspOdr2; }
            set { _itemGrpDspOdr2 = value; }
        }

        /// public propaty name  :  ItemGroupCode3
        /// <summary>品目グループコード3プロパティ</summary>
        /// <value>1～5の使用を想定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループコード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGroupCode3
        {
            get { return _itemGroupCode3; }
            set { _itemGroupCode3 = value; }
        }

        /// public propaty name  :  ItemGroupName3
        /// <summary>品目グループ名称3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ名称3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ItemGroupName3
        {
            get { return _itemGroupName3; }
            set { _itemGroupName3 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr3
        /// <summary>品目グループ表示順位3プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ表示順位3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr3
        {
            get { return _itemGrpDspOdr3; }
            set { _itemGrpDspOdr3 = value; }
        }

        /// public propaty name  :  ItemGroupCode4
        /// <summary>品目グループコード4プロパティ</summary>
        /// <value>1～5の使用を想定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループコード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGroupCode4
        {
            get { return _itemGroupCode4; }
            set { _itemGroupCode4 = value; }
        }

        /// public propaty name  :  ItemGroupName4
        /// <summary>品目グループ名称4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ名称4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ItemGroupName4
        {
            get { return _itemGroupName4; }
            set { _itemGroupName4 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr4
        /// <summary>品目グループ表示順位4プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ表示順位4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr4
        {
            get { return _itemGrpDspOdr4; }
            set { _itemGrpDspOdr4 = value; }
        }

        /// public propaty name  :  ItemGroupCode5
        /// <summary>品目グループコード5プロパティ</summary>
        /// <value>1～5の使用を想定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループコード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGroupCode5
        {
            get { return _itemGroupCode5; }
            set { _itemGroupCode5 = value; }
        }

        /// public propaty name  :  ItemGroupName5
        /// <summary>品目グループ名称5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ名称5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ItemGroupName5
        {
            get { return _itemGroupName5; }
            set { _itemGroupName5 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr5
        /// <summary>品目グループ表示順位5プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ表示順位5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr5
        {
            get { return _itemGrpDspOdr5; }
            set { _itemGrpDspOdr5 = value; }
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

        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>品目グループ画像コード1プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ画像コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ItemGrpImgCode1
        {
            get { return _itemGrpImgCode1; }
            set { _itemGrpImgCode1 = value; }
        }

        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>品目グループ画像コード2プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ画像コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ItemGrpImgCode2
        {
            get { return _itemGrpImgCode2; }
            set { _itemGrpImgCode2 = value; }
        }

        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>品目グループ画像コード3プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ画像コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ItemGrpImgCode3
        {
            get { return _itemGrpImgCode3; }
            set { _itemGrpImgCode3 = value; }
        }

        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>品目グループ画像コード4プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ画像コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ItemGrpImgCode4
        {
            get { return _itemGrpImgCode4; }
            set { _itemGrpImgCode4 = value; }
        }

        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>品目グループ画像コード5プロパティ</summary>
        /// <value>左から順に1～5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品目グループ画像コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 ItemGrpImgCode5
        {
            get { return _itemGrpImgCode5; }
            set { _itemGrpImgCode5 = value; }
        }
        // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 品目グリッドマスタコンストラクタ
        /// </summary>
        /// <returns>PccItemGridクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGridクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccItemGrid()
        {
        }

        /// <summary>
        /// 品目グリッドマスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="inqCondition">問合せ条件</param>
        /// <param name="pccCompanyCode">PCC自社コード(PMの得意先コード)</param>
        /// <param name="pccCompanyName">PCC自社名称</param>
        /// <param name="itemGroupCode1">品目グループコード1(1～5の使用を想定)</param>
        /// <param name="itemGroupName1">品目グループ名称1</param>
        /// <param name="itemGrpDspOdr1">品目グループ表示順位1(左から順に1～5)</param>
        /// <param name="itemGroupCode2">品目グループコード2(1～5の使用を想定)</param>
        /// <param name="itemGroupName2">品目グループ名称2</param>
        /// <param name="itemGrpDspOdr2">品目グループ表示順位2(左から順に1～5)</param>
        /// <param name="itemGroupCode3">品目グループコード3(1～5の使用を想定)</param>
        /// <param name="itemGroupName3">品目グループ名称3</param>
        /// <param name="itemGrpDspOdr3">品目グループ表示順位3(左から順に1～5)</param>
        /// <param name="itemGroupCode4">品目グループコード4(1～5の使用を想定)</param>
        /// <param name="itemGroupName4">品目グループ名称4</param>
        /// <param name="itemGrpDspOdr4">品目グループ表示順位4(左から順に1～5)</param>
        /// <param name="itemGroupCode5">品目グループコード5(1～5の使用を想定)</param>
        /// <param name="itemGroupName5">品目グループ名称5</param>
        /// <param name="itemGrpDspOdr5">品目グループ表示順位5(左から順に1～5)</param>
        /// <param name="itemGrpImgCode1">品目グループ画像コード1</param>
        /// <param name="itemGrpImgCode2">品目グループ画像コード2</param>
        /// <param name="itemGrpImgCode3">品目グループ画像コード3</param>
        /// <param name="itemGrpImgCode4">品目グループ画像コード4</param>
        /// <param name="itemGrpImgCode5">品目グループ画像コード5</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>PccItemGridクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGridクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //public PccItemGrid(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, string pccCompanyName, Int32 itemGroupCode1, string itemGroupName1, Int32 itemGrpDspOdr1, Int32 itemGroupCode2, string itemGroupName2, Int32 itemGrpDspOdr2, Int32 itemGroupCode3, string itemGroupName3, Int32 itemGrpDspOdr3, Int32 itemGroupCode4, string itemGroupName4, Int32 itemGrpDspOdr4, Int32 itemGroupCode5, string itemGroupName5, Int32 itemGrpDspOdr5, string enterpriseName, string updEmployeeName)
        public PccItemGrid(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, string pccCompanyName, Int32 itemGroupCode1, string itemGroupName1, Int32 itemGrpDspOdr1, Int32 itemGroupCode2, string itemGroupName2, Int32 itemGrpDspOdr2, Int32 itemGroupCode3, string itemGroupName3, Int32 itemGrpDspOdr3, Int32 itemGroupCode4, string itemGroupName4, Int32 itemGrpDspOdr4, Int32 itemGroupCode5, string itemGroupName5, Int32 itemGrpDspOdr5, string enterpriseName, string updEmployeeName, Int16 itemGrpImgCode1, Int16 itemGrpImgCode2, Int16 itemGrpImgCode3, Int16 itemGrpImgCode4, Int16 itemGrpImgCode5)
        // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._inqCondition = inqCondition;
            this._pccCompanyCode = pccCompanyCode;
            this._pccCompanyName = pccCompanyName;
            this._itemGroupCode1 = itemGroupCode1;
            this._itemGroupName1 = itemGroupName1;
            this._itemGrpDspOdr1 = itemGrpDspOdr1;
            this._itemGroupCode2 = itemGroupCode2;
            this._itemGroupName2 = itemGroupName2;
            this._itemGrpDspOdr2 = itemGrpDspOdr2;
            this._itemGroupCode3 = itemGroupCode3;
            this._itemGroupName3 = itemGroupName3;
            this._itemGrpDspOdr3 = itemGrpDspOdr3;
            this._itemGroupCode4 = itemGroupCode4;
            this._itemGroupName4 = itemGroupName4;
            this._itemGrpDspOdr4 = itemGrpDspOdr4;
            this._itemGroupCode5 = itemGroupCode5;
            this._itemGroupName5 = itemGroupName5;
            this._itemGrpDspOdr5 = itemGrpDspOdr5;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this._itemGrpImgCode1 = itemGrpImgCode1;
            this._itemGrpImgCode2 = itemGrpImgCode2;
            this._itemGrpImgCode3 = itemGrpImgCode3;
            this._itemGrpImgCode4 = itemGrpImgCode4;
            this._itemGrpImgCode5 = itemGrpImgCode5;
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// 品目グリッドマスタ複製処理
        /// </summary>
        /// <returns>PccItemGridクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPccItemGridクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PccItemGrid Clone()
        {
            // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //return new PccItemGrid(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._pccCompanyName, this._itemGroupCode1, this._itemGroupName1, this._itemGrpDspOdr1, this._itemGroupCode2, this._itemGroupName2, this._itemGrpDspOdr2, this._itemGroupCode3, this._itemGroupName3, this._itemGrpDspOdr3, this._itemGroupCode4, this._itemGroupName4, this._itemGrpDspOdr4, this._itemGroupCode5, this._itemGroupName5, this._itemGrpDspOdr5, this._enterpriseName, this._updEmployeeName);
            return new PccItemGrid(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._pccCompanyName, this._itemGroupCode1, this._itemGroupName1, this._itemGrpDspOdr1, this._itemGroupCode2, this._itemGroupName2, this._itemGrpDspOdr2, this._itemGroupCode3, this._itemGroupName3, this._itemGrpDspOdr3, this._itemGroupCode4, this._itemGroupName4, this._itemGrpDspOdr4, this._itemGroupCode5, this._itemGroupName5, this._itemGrpDspOdr5, this._enterpriseName, this._updEmployeeName, this._itemGrpImgCode1, this._itemGrpImgCode2, this._itemGrpImgCode3, this._itemGrpImgCode4, this._itemGrpImgCode5);//@@@@20230303
            // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// 品目グリッドマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccItemGridクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGridクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PccItemGrid target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.InqCondition == target.InqCondition)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.PccCompanyName == target.PccCompanyName)
                 && (this.ItemGroupCode1 == target.ItemGroupCode1)
                 && (this.ItemGroupName1 == target.ItemGroupName1)
                 && (this.ItemGrpDspOdr1 == target.ItemGrpDspOdr1)
                 && (this.ItemGroupCode2 == target.ItemGroupCode2)
                 && (this.ItemGroupName2 == target.ItemGroupName2)
                 && (this.ItemGrpDspOdr2 == target.ItemGrpDspOdr2)
                 && (this.ItemGroupCode3 == target.ItemGroupCode3)
                 && (this.ItemGroupName3 == target.ItemGroupName3)
                 && (this.ItemGrpDspOdr3 == target.ItemGrpDspOdr3)
                 && (this.ItemGroupCode4 == target.ItemGroupCode4)
                 && (this.ItemGroupName4 == target.ItemGroupName4)
                 && (this.ItemGrpDspOdr4 == target.ItemGrpDspOdr4)
                 && (this.ItemGroupCode5 == target.ItemGroupCode5)
                 && (this.ItemGroupName5 == target.ItemGroupName5)
                 && (this.ItemGrpDspOdr5 == target.ItemGrpDspOdr5)
                 && (this.EnterpriseName == target.EnterpriseName)
                // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                 //&& (this.UpdEmployeeName == target.UpdEmployeeName));
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.ItemGrpImgCode1 == target.ItemGrpImgCode1)
                 && (this.ItemGrpImgCode2 == target.ItemGrpImgCode2)
                 && (this.ItemGrpImgCode3 == target.ItemGrpImgCode3)
                 && (this.ItemGrpImgCode4 == target.ItemGrpImgCode4)
                 && (this.ItemGrpImgCode5 == target.ItemGrpImgCode5)
                 );
                // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// 品目グリッドマスタ比較処理
        /// </summary>
        /// <param name="pccItemGrid1">
        ///                    比較するPccItemGridクラスのインスタンス
        /// </param>
        /// <param name="pccItemGrid2">比較するPccItemGridクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGridクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PccItemGrid pccItemGrid1, PccItemGrid pccItemGrid2)
        {
            return ((pccItemGrid1.CreateDateTime == pccItemGrid2.CreateDateTime)
                 && (pccItemGrid1.UpdateDateTime == pccItemGrid2.UpdateDateTime)
                 && (pccItemGrid1.EnterpriseCode == pccItemGrid2.EnterpriseCode)
                 && (pccItemGrid1.FileHeaderGuid == pccItemGrid2.FileHeaderGuid)
                 && (pccItemGrid1.UpdEmployeeCode == pccItemGrid2.UpdEmployeeCode)
                 && (pccItemGrid1.UpdAssemblyId1 == pccItemGrid2.UpdAssemblyId1)
                 && (pccItemGrid1.UpdAssemblyId2 == pccItemGrid2.UpdAssemblyId2)
                 && (pccItemGrid1.LogicalDeleteCode == pccItemGrid2.LogicalDeleteCode)
                 && (pccItemGrid1.InqOriginalEpCd.Trim() == pccItemGrid2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccItemGrid1.InqOriginalSecCd == pccItemGrid2.InqOriginalSecCd)
                 && (pccItemGrid1.InqOtherEpCd == pccItemGrid2.InqOtherEpCd)
                 && (pccItemGrid1.InqOtherSecCd == pccItemGrid2.InqOtherSecCd)
                 && (pccItemGrid1.InqCondition == pccItemGrid2.InqCondition)
                 && (pccItemGrid1.PccCompanyCode == pccItemGrid2.PccCompanyCode)
                 && (pccItemGrid1.PccCompanyName == pccItemGrid2.PccCompanyName)
                 && (pccItemGrid1.ItemGroupCode1 == pccItemGrid2.ItemGroupCode1)
                 && (pccItemGrid1.ItemGroupName1 == pccItemGrid2.ItemGroupName1)
                 && (pccItemGrid1.ItemGrpDspOdr1 == pccItemGrid2.ItemGrpDspOdr1)
                 && (pccItemGrid1.ItemGroupCode2 == pccItemGrid2.ItemGroupCode2)
                 && (pccItemGrid1.ItemGroupName2 == pccItemGrid2.ItemGroupName2)
                 && (pccItemGrid1.ItemGrpDspOdr2 == pccItemGrid2.ItemGrpDspOdr2)
                 && (pccItemGrid1.ItemGroupCode3 == pccItemGrid2.ItemGroupCode3)
                 && (pccItemGrid1.ItemGroupName3 == pccItemGrid2.ItemGroupName3)
                 && (pccItemGrid1.ItemGrpDspOdr3 == pccItemGrid2.ItemGrpDspOdr3)
                 && (pccItemGrid1.ItemGroupCode4 == pccItemGrid2.ItemGroupCode4)
                 && (pccItemGrid1.ItemGroupName4 == pccItemGrid2.ItemGroupName4)
                 && (pccItemGrid1.ItemGrpDspOdr4 == pccItemGrid2.ItemGrpDspOdr4)
                 && (pccItemGrid1.ItemGroupCode5 == pccItemGrid2.ItemGroupCode5)
                 && (pccItemGrid1.ItemGroupName5 == pccItemGrid2.ItemGroupName5)
                 && (pccItemGrid1.ItemGrpDspOdr5 == pccItemGrid2.ItemGrpDspOdr5)
                 && (pccItemGrid1.EnterpriseName == pccItemGrid2.EnterpriseName)
                // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                 //&& (pccItemGrid1.UpdEmployeeName == pccItemGrid2.UpdEmployeeName));
                 && (pccItemGrid1.UpdEmployeeName == pccItemGrid2.UpdEmployeeName)
                 && (pccItemGrid1.ItemGrpImgCode1 == pccItemGrid2.ItemGrpImgCode1)
                 && (pccItemGrid1.ItemGrpImgCode2 == pccItemGrid2.ItemGrpImgCode2)
                 && (pccItemGrid1.ItemGrpImgCode3 == pccItemGrid2.ItemGrpImgCode3)
                 && (pccItemGrid1.ItemGrpImgCode4 == pccItemGrid2.ItemGrpImgCode4)
                 && (pccItemGrid1.ItemGrpImgCode5 == pccItemGrid2.ItemGrpImgCode5)
                 );
                // --- UPD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        /// <summary>
        /// 品目グリッドマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPccItemGridクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGridクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PccItemGrid target)
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
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.InqCondition != target.InqCondition) resList.Add("InqCondition");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.PccCompanyName != target.PccCompanyName) resList.Add("PccCompanyName");
            if (this.ItemGroupCode1 != target.ItemGroupCode1) resList.Add("ItemGroupCode1");
            if (this.ItemGroupName1 != target.ItemGroupName1) resList.Add("ItemGroupName1");
            if (this.ItemGrpDspOdr1 != target.ItemGrpDspOdr1) resList.Add("ItemGrpDspOdr1");
            if (this.ItemGroupCode2 != target.ItemGroupCode2) resList.Add("ItemGroupCode2");
            if (this.ItemGroupName2 != target.ItemGroupName2) resList.Add("ItemGroupName2");
            if (this.ItemGrpDspOdr2 != target.ItemGrpDspOdr2) resList.Add("ItemGrpDspOdr2");
            if (this.ItemGroupCode3 != target.ItemGroupCode3) resList.Add("ItemGroupCode3");
            if (this.ItemGroupName3 != target.ItemGroupName3) resList.Add("ItemGroupName3");
            if (this.ItemGrpDspOdr3 != target.ItemGrpDspOdr3) resList.Add("ItemGrpDspOdr3");
            if (this.ItemGroupCode4 != target.ItemGroupCode4) resList.Add("ItemGroupCode4");
            if (this.ItemGroupName4 != target.ItemGroupName4) resList.Add("ItemGroupName4");
            if (this.ItemGrpDspOdr4 != target.ItemGrpDspOdr4) resList.Add("ItemGrpDspOdr4");
            if (this.ItemGroupCode5 != target.ItemGroupCode5) resList.Add("ItemGroupCode5");
            if (this.ItemGroupName5 != target.ItemGroupName5) resList.Add("ItemGroupName5");
            if (this.ItemGrpDspOdr5 != target.ItemGrpDspOdr5) resList.Add("ItemGrpDspOdr5");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this.ItemGrpImgCode1 != target.ItemGrpImgCode1) resList.Add("ItemGrpImgCode1");
            if (this.ItemGrpImgCode2 != target.ItemGrpImgCode2) resList.Add("ItemGrpImgCode2");
            if (this.ItemGrpImgCode3 != target.ItemGrpImgCode3) resList.Add("ItemGrpImgCode3");
            if (this.ItemGrpImgCode4 != target.ItemGrpImgCode4) resList.Add("ItemGrpImgCode4");
            if (this.ItemGrpImgCode5 != target.ItemGrpImgCode5) resList.Add("ItemGrpImgCode5");
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }

        /// <summary>
        /// 品目グリッドマスタ比較処理
        /// </summary>
        /// <param name="pccItemGrid1">比較するPccItemGridクラスのインスタンス</param>
        /// <param name="pccItemGrid2">比較するPccItemGridクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PccItemGridクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PccItemGrid pccItemGrid1, PccItemGrid pccItemGrid2)
        {
            ArrayList resList = new ArrayList();
            if (pccItemGrid1.CreateDateTime != pccItemGrid2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccItemGrid1.UpdateDateTime != pccItemGrid2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccItemGrid1.EnterpriseCode != pccItemGrid2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (pccItemGrid1.FileHeaderGuid != pccItemGrid2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (pccItemGrid1.UpdEmployeeCode != pccItemGrid2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (pccItemGrid1.UpdAssemblyId1 != pccItemGrid2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (pccItemGrid1.UpdAssemblyId2 != pccItemGrid2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (pccItemGrid1.LogicalDeleteCode != pccItemGrid2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccItemGrid1.InqOriginalEpCd.Trim() != pccItemGrid2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccItemGrid1.InqOriginalSecCd != pccItemGrid2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccItemGrid1.InqOtherEpCd != pccItemGrid2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccItemGrid1.InqOtherSecCd != pccItemGrid2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccItemGrid1.InqCondition != pccItemGrid2.InqCondition) resList.Add("InqCondition");
            if (pccItemGrid1.PccCompanyCode != pccItemGrid2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccItemGrid1.PccCompanyName != pccItemGrid2.PccCompanyName) resList.Add("PccCompanyName");
            if (pccItemGrid1.ItemGroupCode1 != pccItemGrid2.ItemGroupCode1) resList.Add("ItemGroupCode1");
            if (pccItemGrid1.ItemGroupName1 != pccItemGrid2.ItemGroupName1) resList.Add("ItemGroupName1");
            if (pccItemGrid1.ItemGrpDspOdr1 != pccItemGrid2.ItemGrpDspOdr1) resList.Add("ItemGrpDspOdr1");
            if (pccItemGrid1.ItemGroupCode2 != pccItemGrid2.ItemGroupCode2) resList.Add("ItemGroupCode2");
            if (pccItemGrid1.ItemGroupName2 != pccItemGrid2.ItemGroupName2) resList.Add("ItemGroupName2");
            if (pccItemGrid1.ItemGrpDspOdr2 != pccItemGrid2.ItemGrpDspOdr2) resList.Add("ItemGrpDspOdr2");
            if (pccItemGrid1.ItemGroupCode3 != pccItemGrid2.ItemGroupCode3) resList.Add("ItemGroupCode3");
            if (pccItemGrid1.ItemGroupName3 != pccItemGrid2.ItemGroupName3) resList.Add("ItemGroupName3");
            if (pccItemGrid1.ItemGrpDspOdr3 != pccItemGrid2.ItemGrpDspOdr3) resList.Add("ItemGrpDspOdr3");
            if (pccItemGrid1.ItemGroupCode4 != pccItemGrid2.ItemGroupCode4) resList.Add("ItemGroupCode4");
            if (pccItemGrid1.ItemGroupName4 != pccItemGrid2.ItemGroupName4) resList.Add("ItemGroupName4");
            if (pccItemGrid1.ItemGrpDspOdr4 != pccItemGrid2.ItemGrpDspOdr4) resList.Add("ItemGrpDspOdr4");
            if (pccItemGrid1.ItemGroupCode5 != pccItemGrid2.ItemGroupCode5) resList.Add("ItemGroupCode5");
            if (pccItemGrid1.ItemGroupName5 != pccItemGrid2.ItemGroupName5) resList.Add("ItemGroupName5");
            if (pccItemGrid1.ItemGrpDspOdr5 != pccItemGrid2.ItemGrpDspOdr5) resList.Add("ItemGrpDspOdr5");
            if (pccItemGrid1.EnterpriseName != pccItemGrid2.EnterpriseName) resList.Add("EnterpriseName");
            if (pccItemGrid1.UpdEmployeeName != pccItemGrid2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (pccItemGrid1.ItemGrpImgCode1 != pccItemGrid2.ItemGrpImgCode1) resList.Add("ItemGrpImgCode1");
            if (pccItemGrid1.ItemGrpImgCode2 != pccItemGrid2.ItemGrpImgCode2) resList.Add("ItemGrpImgCode2");
            if (pccItemGrid1.ItemGrpImgCode3 != pccItemGrid2.ItemGrpImgCode3) resList.Add("ItemGrpImgCode3");
            if (pccItemGrid1.ItemGrpImgCode4 != pccItemGrid2.ItemGrpImgCode4) resList.Add("ItemGrpImgCode4");
            if (pccItemGrid1.ItemGrpImgCode5 != pccItemGrid2.ItemGrpImgCode5) resList.Add("ItemGrpImgCode5");
            // --- ADD 2013/05/30 三戸 2013/99/99配信分 SCM障害№10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }
    }
}
