using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOESetting
    /// <summary>
    ///                      UOE自社設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE自社設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/06/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOESetting
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

        /// <summary>伝票出力区分</summary>
        /// <remarks>伝票出力発行区分</remarks>
        private Int32 _slipOutputDivCd;

        /// <summary>フォロー伝票出力区分</summary>
        /// <remarks>フォロー伝票出力形態</remarks>
        private Int32 _followSlipOutputDiv;

        /// <summary>計上日付区分</summary>
        /// <remarks>伝発Ⅱ売上日付</remarks>
        private Int32 _addUpADateDiv;

        /// <summary>在庫一括品番区分</summary>
        /// <remarks>在庫一括代替品番区分</remarks>
        private Int32 _stockBlnktPrtNoDiv;

        /// <summary>メーカーフォロー計上区分</summary>
        /// <remarks>メーカーフォロー計上区分</remarks>
        private Int32 _makerFollowAddUpDiv;

        /// <summary>卸商入庫更新区分</summary>
        /// <remarks>卸商入庫更新区分</remarks>
        private Int32 _distEnterDiv;

        /// <summary>卸商拠点設定区分</summary>
        /// <remarks>卸商営業所設定区分</remarks>
        private Int32 _distSectionSetDiv;

        /// <summary>手入力検索リマーク</summary>
        /// <remarks>手入力検索リマーク</remarks>
        private string _inpSearchRemark = "";

        /// <summary>在庫一括補充リマーク</summary>
        /// <remarks>在庫一括補充リマーク</remarks>
        private string _stockBlnktRemark = "";

        /// <summary>伝発リマーク</summary>
        /// <remarks>伝発Ⅱリマーク</remarks>
        private string _slipOutputRemark = "";

        /// <summary>伝発リマーク区分</summary>
        /// <remarks>伝発Ⅱリマーク区分 ※予備の1:ﾘﾏｰｸ(個別)を統合させる</remarks>
        private Int32 _slipOutputRemarkDiv;

        /// <summary>UOE伝票発行区分</summary>
        /// <remarks>UOE伝票発行区分(0:する 1:しない)</remarks>
        private Int32 _uOESlipPrtDiv;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";


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

        /// public propaty name  :  SlipOutputDivCd
        /// <summary>伝票出力区分プロパティ</summary>
        /// <value>伝票出力発行区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipOutputDivCd
        {
            get { return _slipOutputDivCd; }
            set { _slipOutputDivCd = value; }
        }

        /// public propaty name  :  FollowSlipOutputDiv
        /// <summary>フォロー伝票出力区分プロパティ</summary>
        /// <value>フォロー伝票出力形態</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   フォロー伝票出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FollowSlipOutputDiv
        {
            get { return _followSlipOutputDiv; }
            set { _followSlipOutputDiv = value; }
        }

        /// public propaty name  :  AddUpADateDiv
        /// <summary>計上日付区分プロパティ</summary>
        /// <value>伝発Ⅱ売上日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日付区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddUpADateDiv
        {
            get { return _addUpADateDiv; }
            set { _addUpADateDiv = value; }
        }

        /// public propaty name  :  StockBlnktPrtNoDiv
        /// <summary>在庫一括品番区分プロパティ</summary>
        /// <value>在庫一括代替品番区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫一括品番区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockBlnktPrtNoDiv
        {
            get { return _stockBlnktPrtNoDiv; }
            set { _stockBlnktPrtNoDiv = value; }
        }

        /// public propaty name  :  MakerFollowAddUpDiv
        /// <summary>メーカーフォロー計上区分プロパティ</summary>
        /// <value>メーカーフォロー計上区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーフォロー計上区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerFollowAddUpDiv
        {
            get { return _makerFollowAddUpDiv; }
            set { _makerFollowAddUpDiv = value; }
        }

        /// public propaty name  :  DistEnterDiv
        /// <summary>卸商入庫更新区分プロパティ</summary>
        /// <value>卸商入庫更新区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   卸商入庫更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DistEnterDiv
        {
            get { return _distEnterDiv; }
            set { _distEnterDiv = value; }
        }

        /// public propaty name  :  DistSectionSetDiv
        /// <summary>卸商拠点設定区分プロパティ</summary>
        /// <value>卸商営業所設定区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   卸商拠点設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DistSectionSetDiv
        {
            get { return _distSectionSetDiv; }
            set { _distSectionSetDiv = value; }
        }

        /// public propaty name  :  InpSearchRemark
        /// <summary>手入力検索リマークプロパティ</summary>
        /// <value>手入力検索リマーク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   手入力検索リマークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InpSearchRemark
        {
            get { return _inpSearchRemark; }
            set { _inpSearchRemark = value; }
        }

        /// public propaty name  :  StockBlnktRemark
        /// <summary>在庫一括補充リマークプロパティ</summary>
        /// <value>在庫一括補充リマーク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫一括補充リマークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockBlnktRemark
        {
            get { return _stockBlnktRemark; }
            set { _stockBlnktRemark = value; }
        }

        /// public propaty name  :  SlipOutputRemark
        /// <summary>伝発リマークプロパティ</summary>
        /// <value>伝発Ⅱリマーク</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝発リマークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipOutputRemark
        {
            get { return _slipOutputRemark; }
            set { _slipOutputRemark = value; }
        }

        /// public propaty name  :  SlipOutputRemarkDiv
        /// <summary>伝発リマーク区分プロパティ</summary>
        /// <value>伝発Ⅱリマーク区分 ※予備の1:ﾘﾏｰｸ(個別)を統合させる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝発リマーク区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipOutputRemarkDiv
        {
            get { return _slipOutputRemarkDiv; }
            set { _slipOutputRemarkDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE伝票発行区分プロパティ</summary>
        /// <value>UOE伝票発行区分(0:する 1:しない)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝発リマーク区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESlipPrtDiv
        {
            get { return _uOESlipPrtDiv; }
            set { _uOESlipPrtDiv = value; }
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

        /// <summary>
        /// UOE自社設定マスタコンストラクタ
        /// </summary>
        /// <returns>UOESettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOESetting()
        {
        }

        /// <summary>
        /// UOE自社設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="slipOutputDivCd">伝票出力区分(伝票出力発行区分)</param>
        /// <param name="followSlipOutputDiv">フォロー伝票出力区分(フォロー伝票出力形態)</param>
        /// <param name="addUpADateDiv">計上日付区分(伝発Ⅱ売上日付)</param>
        /// <param name="stockBlnktPrtNoDiv">在庫一括品番区分(在庫一括代替品番区分)</param>
        /// <param name="makerFollowAddUpDiv">メーカーフォロー計上区分(メーカーフォロー計上区分)</param>
        /// <param name="distEnterDiv">卸商入庫更新区分(卸商入庫更新区分)</param>
        /// <param name="distSectionSetDiv">卸商拠点設定区分(卸商営業所設定区分)</param>
        /// <param name="inpSearchRemark">手入力検索リマーク(手入力検索リマーク)</param>
        /// <param name="stockBlnktRemark">在庫一括補充リマーク(在庫一括補充リマーク)</param>
        /// <param name="slipOutputRemark">伝発リマーク(伝発Ⅱリマーク)</param>
        /// <param name="slipOutputRemarkDiv">伝発リマーク区分(伝発Ⅱリマーク区分 ※予備の1:ﾘﾏｰｸ(個別)を統合させる)</param>
        /// <param name="uOESlipPrtDiv">UOE伝票発行区分</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>UOESettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOESetting(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 slipOutputDivCd, Int32 followSlipOutputDiv, Int32 addUpADateDiv, Int32 stockBlnktPrtNoDiv, Int32 makerFollowAddUpDiv, Int32 distEnterDiv, Int32 distSectionSetDiv, string inpSearchRemark, string stockBlnktRemark, string slipOutputRemark, Int32 slipOutputRemarkDiv, Int32 uOESlipPrtDiv, string enterpriseName, string updEmployeeName, string sectionCode)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._slipOutputDivCd = slipOutputDivCd;
            this._followSlipOutputDiv = followSlipOutputDiv;
            this._addUpADateDiv = addUpADateDiv;
            this._stockBlnktPrtNoDiv = stockBlnktPrtNoDiv;
            this._makerFollowAddUpDiv = makerFollowAddUpDiv;
            this._distEnterDiv = distEnterDiv;
            this._distSectionSetDiv = distSectionSetDiv;
            this._inpSearchRemark = inpSearchRemark;
            this._stockBlnktRemark = stockBlnktRemark;
            this._slipOutputRemark = slipOutputRemark;
            this._slipOutputRemarkDiv = slipOutputRemarkDiv;
            this._uOESlipPrtDiv = uOESlipPrtDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._sectionCode = sectionCode;

        }

        /// <summary>
        /// UOE自社設定マスタ複製処理
        /// </summary>
        /// <returns>UOESettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUOESettingクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOESetting Clone()
        {
            return new UOESetting(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._slipOutputDivCd, this._followSlipOutputDiv, this._addUpADateDiv, this._stockBlnktPrtNoDiv, this._makerFollowAddUpDiv, this._distEnterDiv, this._distSectionSetDiv, this._inpSearchRemark, this._stockBlnktRemark, this._slipOutputRemark, this._slipOutputRemarkDiv, this._uOESlipPrtDiv, this._enterpriseName, this._updEmployeeName, this._sectionCode);
        }

        /// <summary>
        /// UOE自社設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のUOESettingクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UOESetting target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SlipOutputDivCd == target.SlipOutputDivCd)
                 && (this.FollowSlipOutputDiv == target.FollowSlipOutputDiv)
                 && (this.AddUpADateDiv == target.AddUpADateDiv)
                 && (this.StockBlnktPrtNoDiv == target.StockBlnktPrtNoDiv)
                 && (this.MakerFollowAddUpDiv == target.MakerFollowAddUpDiv)
                 && (this.DistEnterDiv == target.DistEnterDiv)
                 && (this.DistSectionSetDiv == target.DistSectionSetDiv)
                 && (this.InpSearchRemark == target.InpSearchRemark)
                 && (this.StockBlnktRemark == target.StockBlnktRemark)
                 && (this.SlipOutputRemark == target.SlipOutputRemark)
                 && (this.SlipOutputRemarkDiv == target.SlipOutputRemarkDiv)
                 && (this.UOESlipPrtDiv == target.UOESlipPrtDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.SectionCode == target.SectionCode));
        }

        /// <summary>
        /// UOE自社設定マスタ比較処理
        /// </summary>
        /// <param name="uOESetting1">
        ///                    比較するUOESettingクラスのインスタンス
        /// </param>
        /// <param name="uOESetting2">比較するUOESettingクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UOESetting uOESetting1, UOESetting uOESetting2)
        {
            return ((uOESetting1.CreateDateTime == uOESetting2.CreateDateTime)
                 && (uOESetting1.UpdateDateTime == uOESetting2.UpdateDateTime)
                 && (uOESetting1.EnterpriseCode == uOESetting2.EnterpriseCode)
                 && (uOESetting1.FileHeaderGuid == uOESetting2.FileHeaderGuid)
                 && (uOESetting1.UpdEmployeeCode == uOESetting2.UpdEmployeeCode)
                 && (uOESetting1.UpdAssemblyId1 == uOESetting2.UpdAssemblyId1)
                 && (uOESetting1.UpdAssemblyId2 == uOESetting2.UpdAssemblyId2)
                 && (uOESetting1.LogicalDeleteCode == uOESetting2.LogicalDeleteCode)
                 && (uOESetting1.SlipOutputDivCd == uOESetting2.SlipOutputDivCd)
                 && (uOESetting1.FollowSlipOutputDiv == uOESetting2.FollowSlipOutputDiv)
                 && (uOESetting1.AddUpADateDiv == uOESetting2.AddUpADateDiv)
                 && (uOESetting1.StockBlnktPrtNoDiv == uOESetting2.StockBlnktPrtNoDiv)
                 && (uOESetting1.MakerFollowAddUpDiv == uOESetting2.MakerFollowAddUpDiv)
                 && (uOESetting1.DistEnterDiv == uOESetting2.DistEnterDiv)
                 && (uOESetting1.DistSectionSetDiv == uOESetting2.DistSectionSetDiv)
                 && (uOESetting1.InpSearchRemark == uOESetting2.InpSearchRemark)
                 && (uOESetting1.StockBlnktRemark == uOESetting2.StockBlnktRemark)
                 && (uOESetting1.SlipOutputRemark == uOESetting2.SlipOutputRemark)
                 && (uOESetting1.SlipOutputRemarkDiv == uOESetting2.SlipOutputRemarkDiv)
                 && (uOESetting1.UOESlipPrtDiv == uOESetting2.UOESlipPrtDiv)
                 && (uOESetting1.EnterpriseName == uOESetting2.EnterpriseName)
                 && (uOESetting1.UpdEmployeeName == uOESetting2.UpdEmployeeName)
                 && (uOESetting1.SectionCode == uOESetting2.SectionCode));
        }
        /// <summary>
        /// UOE自社設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のUOESettingクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UOESetting target)
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
            if (this.SlipOutputDivCd != target.SlipOutputDivCd) resList.Add("SlipOutputDivCd");
            if (this.FollowSlipOutputDiv != target.FollowSlipOutputDiv) resList.Add("FollowSlipOutputDiv");
            if (this.AddUpADateDiv != target.AddUpADateDiv) resList.Add("AddUpADateDiv");
            if (this.StockBlnktPrtNoDiv != target.StockBlnktPrtNoDiv) resList.Add("StockBlnktPrtNoDiv");
            if (this.MakerFollowAddUpDiv != target.MakerFollowAddUpDiv) resList.Add("MakerFollowAddUpDiv");
            if (this.DistEnterDiv != target.DistEnterDiv) resList.Add("DistEnterDiv");
            if (this.DistSectionSetDiv != target.DistSectionSetDiv) resList.Add("DistSectionSetDiv");
            if (this.InpSearchRemark != target.InpSearchRemark) resList.Add("InpSearchRemark");
            if (this.StockBlnktRemark != target.StockBlnktRemark) resList.Add("StockBlnktRemark");
            if (this.SlipOutputRemark != target.SlipOutputRemark) resList.Add("SlipOutputRemark");
            if (this.SlipOutputRemarkDiv != target.SlipOutputRemarkDiv) resList.Add("SlipOutputRemarkDiv");
            if (this.UOESlipPrtDiv != target.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");

            return resList;
        }

        /// <summary>
        /// UOE自社設定マスタ比較処理
        /// </summary>
        /// <param name="uOESetting1">比較するUOESettingクラスのインスタンス</param>
        /// <param name="uOESetting2">比較するUOESettingクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOESettingクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UOESetting uOESetting1, UOESetting uOESetting2)
        {
            ArrayList resList = new ArrayList();
            if (uOESetting1.CreateDateTime != uOESetting2.CreateDateTime) resList.Add("CreateDateTime");
            if (uOESetting1.UpdateDateTime != uOESetting2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (uOESetting1.EnterpriseCode != uOESetting2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOESetting1.FileHeaderGuid != uOESetting2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (uOESetting1.UpdEmployeeCode != uOESetting2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (uOESetting1.UpdAssemblyId1 != uOESetting2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (uOESetting1.UpdAssemblyId2 != uOESetting2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (uOESetting1.LogicalDeleteCode != uOESetting2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (uOESetting1.SlipOutputDivCd != uOESetting2.SlipOutputDivCd) resList.Add("SlipOutputDivCd");
            if (uOESetting1.FollowSlipOutputDiv != uOESetting2.FollowSlipOutputDiv) resList.Add("FollowSlipOutputDiv");
            if (uOESetting1.AddUpADateDiv != uOESetting2.AddUpADateDiv) resList.Add("AddUpADateDiv");
            if (uOESetting1.StockBlnktPrtNoDiv != uOESetting2.StockBlnktPrtNoDiv) resList.Add("StockBlnktPrtNoDiv");
            if (uOESetting1.MakerFollowAddUpDiv != uOESetting2.MakerFollowAddUpDiv) resList.Add("MakerFollowAddUpDiv");
            if (uOESetting1.DistEnterDiv != uOESetting2.DistEnterDiv) resList.Add("DistEnterDiv");
            if (uOESetting1.DistSectionSetDiv != uOESetting2.DistSectionSetDiv) resList.Add("DistSectionSetDiv");
            if (uOESetting1.InpSearchRemark != uOESetting2.InpSearchRemark) resList.Add("InpSearchRemark");
            if (uOESetting1.StockBlnktRemark != uOESetting2.StockBlnktRemark) resList.Add("StockBlnktRemark");
            if (uOESetting1.SlipOutputRemark != uOESetting2.SlipOutputRemark) resList.Add("SlipOutputRemark");
            if (uOESetting1.SlipOutputRemarkDiv != uOESetting2.SlipOutputRemarkDiv) resList.Add("SlipOutputRemarkDiv");
            if (uOESetting1.UOESlipPrtDiv != uOESetting2.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");
            if (uOESetting1.EnterpriseName != uOESetting2.EnterpriseName) resList.Add("EnterpriseName");
            if (uOESetting1.UpdEmployeeName != uOESetting2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (uOESetting1.SectionCode != uOESetting2.SectionCode) resList.Add("SectionCode");

            return resList;
        }
    }
}
