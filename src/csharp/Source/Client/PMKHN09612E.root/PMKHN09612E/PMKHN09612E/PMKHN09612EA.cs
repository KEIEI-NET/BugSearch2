using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignPrcPrSt
    /// <summary>
    ///                      キャンペーン売価優先設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   キャンペーン売価優先設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignPrcPrSt
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

        /// <summary>拠点コード</summary>
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>優先設定コード１</summary>
        /// <remarks>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</remarks>
        private Int32 _prioritySettingCd1;

        /// <summary>優先設定コード２</summary>
        /// <remarks>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</remarks>
        private Int32 _prioritySettingCd2;

        /// <summary>優先設定コード３</summary>
        /// <remarks>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</remarks>
        private Int32 _prioritySettingCd3;

        /// <summary>優先設定コード４</summary>
        /// <remarks>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</remarks>
        private Int32 _prioritySettingCd4;

        /// <summary>優先設定コード５</summary>
        /// <remarks>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</remarks>
        private Int32 _prioritySettingCd5;

        /// <summary>優先設定コード６</summary>
        /// <remarks>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</remarks>
        private Int32 _prioritySettingCd6;

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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>00は全社</value>
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

        /// public propaty name  :  PrioritySettingCd1
        /// <summary>優先設定コード１プロパティ</summary>
        /// <value>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd1
        {
            get { return _prioritySettingCd1; }
            set { _prioritySettingCd1 = value; }
        }

        /// public propaty name  :  PrioritySettingCd2
        /// <summary>優先設定コード２プロパティ</summary>
        /// <value>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd2
        {
            get { return _prioritySettingCd2; }
            set { _prioritySettingCd2 = value; }
        }

        /// public propaty name  :  PrioritySettingCd3
        /// <summary>優先設定コード３プロパティ</summary>
        /// <value>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd3
        {
            get { return _prioritySettingCd3; }
            set { _prioritySettingCd3 = value; }
        }

        /// public propaty name  :  PrioritySettingCd4
        /// <summary>優先設定コード４プロパティ</summary>
        /// <value>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd4
        {
            get { return _prioritySettingCd4; }
            set { _prioritySettingCd4 = value; }
        }

        /// public propaty name  :  PrioritySettingCd5
        /// <summary>優先設定コード５プロパティ</summary>
        /// <value>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd5
        {
            get { return _prioritySettingCd5; }
            set { _prioritySettingCd5 = value; }
        }

        /// public propaty name  :  PrioritySettingCd6
        /// <summary>優先設定コード６プロパティ</summary>
        /// <value>0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優先設定コード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrioritySettingCd6
        {
            get { return _prioritySettingCd6; }
            set { _prioritySettingCd6 = value; }
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
        /// キャンペーン売価優先設定マスタコンストラクタ
        /// </summary>
        /// <returns>CampaignPrcPrStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignPrcPrStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignPrcPrSt()
        {
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="prioritySettingCd1">優先設定コード１(0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分)</param>
        /// <param name="prioritySettingCd2">優先設定コード２(0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分)</param>
        /// <param name="prioritySettingCd3">優先設定コード３(0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分)</param>
        /// <param name="prioritySettingCd4">優先設定コード４(0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分)</param>
        /// <param name="prioritySettingCd5">優先設定コード５(0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分)</param>
        /// <param name="prioritySettingCd6">優先設定コード６(0：なし,1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄﾞ,6:販売区分)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>CampaignPrcPrStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignPrcPrStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignPrcPrSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 prioritySettingCd1, Int32 prioritySettingCd2, Int32 prioritySettingCd3, Int32 prioritySettingCd4, Int32 prioritySettingCd5, Int32 prioritySettingCd6, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._prioritySettingCd1 = prioritySettingCd1;
            this._prioritySettingCd2 = prioritySettingCd2;
            this._prioritySettingCd3 = prioritySettingCd3;
            this._prioritySettingCd4 = prioritySettingCd4;
            this._prioritySettingCd5 = prioritySettingCd5;
            this._prioritySettingCd6 = prioritySettingCd6;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ複製処理
        /// </summary>
        /// <returns>CampaignPrcPrStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCampaignPrcPrStクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CampaignPrcPrSt Clone()
        {
            return new CampaignPrcPrSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._prioritySettingCd1, this._prioritySettingCd2, this._prioritySettingCd3, this._prioritySettingCd4, this._prioritySettingCd5, this._prioritySettingCd6, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignPrcPrStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignPrcPrStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CampaignPrcPrSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.PrioritySettingCd1 == target.PrioritySettingCd1)
                 && (this.PrioritySettingCd2 == target.PrioritySettingCd2)
                 && (this.PrioritySettingCd3 == target.PrioritySettingCd3)
                 && (this.PrioritySettingCd4 == target.PrioritySettingCd4)
                 && (this.PrioritySettingCd5 == target.PrioritySettingCd5)
                 && (this.PrioritySettingCd6 == target.PrioritySettingCd6)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ比較処理
        /// </summary>
        /// <param name="campaignPrcPrSt1">
        ///                    比較するCampaignPrcPrStクラスのインスタンス
        /// </param>
        /// <param name="campaignPrcPrSt2">比較するCampaignPrcPrStクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignPrcPrStクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CampaignPrcPrSt campaignPrcPrSt1, CampaignPrcPrSt campaignPrcPrSt2)
        {
            return ((campaignPrcPrSt1.CreateDateTime == campaignPrcPrSt2.CreateDateTime)
                 && (campaignPrcPrSt1.UpdateDateTime == campaignPrcPrSt2.UpdateDateTime)
                 && (campaignPrcPrSt1.EnterpriseCode == campaignPrcPrSt2.EnterpriseCode)
                 && (campaignPrcPrSt1.FileHeaderGuid == campaignPrcPrSt2.FileHeaderGuid)
                 && (campaignPrcPrSt1.UpdEmployeeCode == campaignPrcPrSt2.UpdEmployeeCode)
                 && (campaignPrcPrSt1.UpdAssemblyId1 == campaignPrcPrSt2.UpdAssemblyId1)
                 && (campaignPrcPrSt1.UpdAssemblyId2 == campaignPrcPrSt2.UpdAssemblyId2)
                 && (campaignPrcPrSt1.LogicalDeleteCode == campaignPrcPrSt2.LogicalDeleteCode)
                 && (campaignPrcPrSt1.SectionCode == campaignPrcPrSt2.SectionCode)
                 && (campaignPrcPrSt1.PrioritySettingCd1 == campaignPrcPrSt2.PrioritySettingCd1)
                 && (campaignPrcPrSt1.PrioritySettingCd2 == campaignPrcPrSt2.PrioritySettingCd2)
                 && (campaignPrcPrSt1.PrioritySettingCd3 == campaignPrcPrSt2.PrioritySettingCd3)
                 && (campaignPrcPrSt1.PrioritySettingCd4 == campaignPrcPrSt2.PrioritySettingCd4)
                 && (campaignPrcPrSt1.PrioritySettingCd5 == campaignPrcPrSt2.PrioritySettingCd5)
                 && (campaignPrcPrSt1.PrioritySettingCd6 == campaignPrcPrSt2.PrioritySettingCd6)
                 && (campaignPrcPrSt1.EnterpriseName == campaignPrcPrSt2.EnterpriseName)
                 && (campaignPrcPrSt1.UpdEmployeeName == campaignPrcPrSt2.UpdEmployeeName));
        }
        /// <summary>
        /// キャンペーン売価優先設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のCampaignPrcPrStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignPrcPrStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CampaignPrcPrSt target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.PrioritySettingCd1 != target.PrioritySettingCd1) resList.Add("PrioritySettingCd1");
            if (this.PrioritySettingCd2 != target.PrioritySettingCd2) resList.Add("PrioritySettingCd2");
            if (this.PrioritySettingCd3 != target.PrioritySettingCd3) resList.Add("PrioritySettingCd3");
            if (this.PrioritySettingCd4 != target.PrioritySettingCd4) resList.Add("PrioritySettingCd4");
            if (this.PrioritySettingCd5 != target.PrioritySettingCd5) resList.Add("PrioritySettingCd5");
            if (this.PrioritySettingCd6 != target.PrioritySettingCd6) resList.Add("PrioritySettingCd6");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// キャンペーン売価優先設定マスタ比較処理
        /// </summary>
        /// <param name="campaignPrcPrSt1">比較するCampaignPrcPrStクラスのインスタンス</param>
        /// <param name="campaignPrcPrSt2">比較するCampaignPrcPrStクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CampaignPrcPrStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CampaignPrcPrSt campaignPrcPrSt1, CampaignPrcPrSt campaignPrcPrSt2)
        {
            ArrayList resList = new ArrayList();
            if (campaignPrcPrSt1.CreateDateTime != campaignPrcPrSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (campaignPrcPrSt1.UpdateDateTime != campaignPrcPrSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (campaignPrcPrSt1.EnterpriseCode != campaignPrcPrSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignPrcPrSt1.FileHeaderGuid != campaignPrcPrSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (campaignPrcPrSt1.UpdEmployeeCode != campaignPrcPrSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (campaignPrcPrSt1.UpdAssemblyId1 != campaignPrcPrSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (campaignPrcPrSt1.UpdAssemblyId2 != campaignPrcPrSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (campaignPrcPrSt1.LogicalDeleteCode != campaignPrcPrSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignPrcPrSt1.SectionCode != campaignPrcPrSt2.SectionCode) resList.Add("SectionCode");
            if (campaignPrcPrSt1.PrioritySettingCd1 != campaignPrcPrSt2.PrioritySettingCd1) resList.Add("PrioritySettingCd1");
            if (campaignPrcPrSt1.PrioritySettingCd2 != campaignPrcPrSt2.PrioritySettingCd2) resList.Add("PrioritySettingCd2");
            if (campaignPrcPrSt1.PrioritySettingCd3 != campaignPrcPrSt2.PrioritySettingCd3) resList.Add("PrioritySettingCd3");
            if (campaignPrcPrSt1.PrioritySettingCd4 != campaignPrcPrSt2.PrioritySettingCd4) resList.Add("PrioritySettingCd4");
            if (campaignPrcPrSt1.PrioritySettingCd5 != campaignPrcPrSt2.PrioritySettingCd5) resList.Add("PrioritySettingCd5");
            if (campaignPrcPrSt1.PrioritySettingCd6 != campaignPrcPrSt2.PrioritySettingCd6) resList.Add("PrioritySettingCd6");
            if (campaignPrcPrSt1.EnterpriseName != campaignPrcPrSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (campaignPrcPrSt1.UpdEmployeeName != campaignPrcPrSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
