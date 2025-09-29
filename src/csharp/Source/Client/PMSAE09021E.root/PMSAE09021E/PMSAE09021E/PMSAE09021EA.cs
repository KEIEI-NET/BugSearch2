//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス商品コード変換マスタメンテナンス
// プログラム概要   : 商品コード変換の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SAndEGoodsCdChg
    /// <summary>
    ///                      オートバックス商品コード変換マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   オートバックス商品コード変換マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/6/26</br>
    /// <br>Genarated Date   :   2009/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/08/04  張凱</br>
    /// </remarks>
    public class SAndEGoodsCdChg
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

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>AB商品コード</summary>
        private string _aBGoodsCode = "";

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

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

        /// public propaty name  :  ABGoodsCode
        /// <summary>AB商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   AB商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ABGoodsCode
        {
            get { return _aBGoodsCode; }
            set { _aBGoodsCode = value; }
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
        /// オートバックス商品コード変換マスタコンストラクタ
        /// </summary>
        /// <returns>SAndEGoodsCdChgクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndEGoodsCdChgクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SAndEGoodsCdChg()
        {
        }

        /// <summary>
        /// オートバックス商品コード変換マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="aBGoodsCode">AB商品コード</param>
        /// <param name="bLGoodsHalfName">BL商品コード名称（半角）</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <returns>SAndEGoodsCdChgクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndEGoodsCdChgクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SAndEGoodsCdChg(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 bLGoodsCode, string aBGoodsCode, string bLGoodsHalfName, string enterpriseName, string updEmployeeName, string bLGoodsName)
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
            this._aBGoodsCode = aBGoodsCode;
            this._bLGoodsHalfName = bLGoodsHalfName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// オートバックス商品コード変換マスタ複製処理
        /// </summary>
        /// <returns>SAndEGoodsCdChgクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSAndEGoodsCdChgクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SAndEGoodsCdChg Clone()
        {
            return new SAndEGoodsCdChg(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._bLGoodsCode, this._aBGoodsCode, this._bLGoodsHalfName, this._enterpriseName, this._updEmployeeName, this._bLGoodsName);
        }

        /// <summary>
        /// オートバックス商品コード変換マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSAndEGoodsCdChgクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndEGoodsCdChgクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SAndEGoodsCdChg target)
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
                 && (this.ABGoodsCode == target.ABGoodsCode)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName));
        }

        /// <summary>
        /// オートバックス商品コード変換マスタ比較処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg1">
        ///                    比較するSAndEGoodsCdChgクラスのインスタンス
        /// </param>
        /// <param name="sAndEGoodsCdChg2">比較するSAndEGoodsCdChgクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndEGoodsCdChgクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SAndEGoodsCdChg sAndEGoodsCdChg1, SAndEGoodsCdChg sAndEGoodsCdChg2)
        {
            return ((sAndEGoodsCdChg1.CreateDateTime == sAndEGoodsCdChg2.CreateDateTime)
                 && (sAndEGoodsCdChg1.UpdateDateTime == sAndEGoodsCdChg2.UpdateDateTime)
                 && (sAndEGoodsCdChg1.EnterpriseCode == sAndEGoodsCdChg2.EnterpriseCode)
                 && (sAndEGoodsCdChg1.FileHeaderGuid == sAndEGoodsCdChg2.FileHeaderGuid)
                 && (sAndEGoodsCdChg1.UpdEmployeeCode == sAndEGoodsCdChg2.UpdEmployeeCode)
                 && (sAndEGoodsCdChg1.UpdAssemblyId1 == sAndEGoodsCdChg2.UpdAssemblyId1)
                 && (sAndEGoodsCdChg1.UpdAssemblyId2 == sAndEGoodsCdChg2.UpdAssemblyId2)
                 && (sAndEGoodsCdChg1.LogicalDeleteCode == sAndEGoodsCdChg2.LogicalDeleteCode)
                 && (sAndEGoodsCdChg1.BLGoodsCode == sAndEGoodsCdChg2.BLGoodsCode)
                 && (sAndEGoodsCdChg1.ABGoodsCode == sAndEGoodsCdChg2.ABGoodsCode)
                 && (sAndEGoodsCdChg1.BLGoodsHalfName == sAndEGoodsCdChg2.BLGoodsHalfName)
                 && (sAndEGoodsCdChg1.EnterpriseName == sAndEGoodsCdChg2.EnterpriseName)
                 && (sAndEGoodsCdChg1.UpdEmployeeName == sAndEGoodsCdChg2.UpdEmployeeName)
                 && (sAndEGoodsCdChg1.BLGoodsName == sAndEGoodsCdChg2.BLGoodsName));
        }
        /// <summary>
        /// オートバックス商品コード変換マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSAndEGoodsCdChgクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndEGoodsCdChgクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SAndEGoodsCdChg target)
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
            if (this.ABGoodsCode != target.ABGoodsCode) resList.Add("ABGoodsCode");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// オートバックス商品コード変換マスタ比較処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg1">比較するSAndEGoodsCdChgクラスのインスタンス</param>
        /// <param name="sAndEGoodsCdChg2">比較するSAndEGoodsCdChgクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SAndEGoodsCdChgクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SAndEGoodsCdChg sAndEGoodsCdChg1, SAndEGoodsCdChg sAndEGoodsCdChg2)
        {
            ArrayList resList = new ArrayList();
            if (sAndEGoodsCdChg1.CreateDateTime != sAndEGoodsCdChg2.CreateDateTime) resList.Add("CreateDateTime");
            if (sAndEGoodsCdChg1.UpdateDateTime != sAndEGoodsCdChg2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sAndEGoodsCdChg1.EnterpriseCode != sAndEGoodsCdChg2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sAndEGoodsCdChg1.FileHeaderGuid != sAndEGoodsCdChg2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sAndEGoodsCdChg1.UpdEmployeeCode != sAndEGoodsCdChg2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sAndEGoodsCdChg1.UpdAssemblyId1 != sAndEGoodsCdChg2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sAndEGoodsCdChg1.UpdAssemblyId2 != sAndEGoodsCdChg2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sAndEGoodsCdChg1.LogicalDeleteCode != sAndEGoodsCdChg2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sAndEGoodsCdChg1.BLGoodsCode != sAndEGoodsCdChg2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (sAndEGoodsCdChg1.ABGoodsCode != sAndEGoodsCdChg2.ABGoodsCode) resList.Add("ABGoodsCode");
            if (sAndEGoodsCdChg1.BLGoodsHalfName != sAndEGoodsCdChg2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (sAndEGoodsCdChg1.EnterpriseName != sAndEGoodsCdChg2.EnterpriseName) resList.Add("EnterpriseName");
            if (sAndEGoodsCdChg1.UpdEmployeeName != sAndEGoodsCdChg2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (sAndEGoodsCdChg1.BLGoodsName != sAndEGoodsCdChg2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
}
