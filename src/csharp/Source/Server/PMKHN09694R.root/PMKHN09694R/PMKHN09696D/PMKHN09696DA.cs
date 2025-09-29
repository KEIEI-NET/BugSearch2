//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : BLコード変換取得設定マスタメンテ印刷抽出結果ワーク
// プログラム概要   : BLコード変換取得設定マスタメンテ印刷抽出結果ワークデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2012/08/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   BLGoodsCdChgUWork
    /// <summary>
    ///                      BLコード変換（ユーザー登録）ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   BLコード変換（ユーザー登録）ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2012/7/25</br>
    /// <br>Genarated Date   :   2012/07/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class BLGoodsCdChgUWork : IFileHeader
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

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>PM側BL商品コード</summary>
        private Int32 _pMBLGoodsCode;

        /// <summary>PM側BL商品コード枝番</summary>
        private Int32 _pMBLGoodsCodeDerivNo;

        /// <summary>SF側BL商品コード</summary>
        private Int32 _sFBLGoodsCode;

        /// <summary>SF側BL商品コード枝番</summary>
        private Int32 _sFBLGoodsCodeDerivNo;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";


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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  PMBLGoodsCode
        /// <summary>PM側BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM側BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PMBLGoodsCode
        {
            get { return _pMBLGoodsCode; }
            set { _pMBLGoodsCode = value; }
        }

        /// public propaty name  :  PMBLGoodsCodeDerivNo
        /// <summary>PM側BL商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM側BL商品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PMBLGoodsCodeDerivNo
        {
            get { return _pMBLGoodsCodeDerivNo; }
            set { _pMBLGoodsCodeDerivNo = value; }
        }

        /// public propaty name  :  SFBLGoodsCode
        /// <summary>SF側BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF側BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SFBLGoodsCode
        {
            get { return _sFBLGoodsCode; }
            set { _sFBLGoodsCode = value; }
        }

        /// public propaty name  :  SFBLGoodsCodeDerivNo
        /// <summary>SF側BL商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF側BL商品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SFBLGoodsCodeDerivNo
        {
            get { return _sFBLGoodsCodeDerivNo; }
            set { _sFBLGoodsCodeDerivNo = value; }
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


        /// <summary>
        /// BLコード変換（ユーザー登録）ワークコンストラクタ
        /// </summary>
        /// <returns>BLGoodsCdChgUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGoodsCdChgUWork()
        {
        }

        /// <summary>
        /// BLコード変換（ユーザー登録）ワークコンストラクタ
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
        /// <param name="customerCode">得意先コード</param>
        /// <param name="pMBLGoodsCode">PM側BL商品コード</param>
        /// <param name="pMBLGoodsCodeDerivNo">PM側BL商品コード枝番</param>
        /// <param name="sFBLGoodsCode">SF側BL商品コード</param>
        /// <param name="sFBLGoodsCodeDerivNo">SF側BL商品コード枝番</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
        /// <param name="bLGoodsHalfName">BL商品コード名称（半角）</param>
        /// <returns>BLGoodsCdChgUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGoodsCdChgUWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 pMBLGoodsCode, Int32 pMBLGoodsCodeDerivNo, Int32 sFBLGoodsCode, Int32 sFBLGoodsCodeDerivNo, string bLGoodsFullName, string bLGoodsHalfName)
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
            this._customerCode = customerCode;
            this._pMBLGoodsCode = pMBLGoodsCode;
            this._pMBLGoodsCodeDerivNo = pMBLGoodsCodeDerivNo;
            this._sFBLGoodsCode = sFBLGoodsCode;
            this._sFBLGoodsCodeDerivNo = sFBLGoodsCodeDerivNo;
            this._bLGoodsFullName = bLGoodsFullName;
            this._bLGoodsHalfName = bLGoodsHalfName;

        }

        /// <summary>
        /// BLコード変換（ユーザー登録）ワーク複製処理
        /// </summary>
        /// <returns>BLGoodsCdChgUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいBLGoodsCdChgUWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGoodsCdChgUWork Clone()
        {
            return new BLGoodsCdChgUWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._pMBLGoodsCode, this._pMBLGoodsCodeDerivNo, this._sFBLGoodsCode, this._sFBLGoodsCodeDerivNo, this._bLGoodsFullName, this._bLGoodsHalfName);
        }

        /// <summary>
        /// BLコード変換（ユーザー登録）ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のBLGoodsCdChgUWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(BLGoodsCdChgUWork target)
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
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.PMBLGoodsCode == target.PMBLGoodsCode)
                 && (this.PMBLGoodsCodeDerivNo == target.PMBLGoodsCodeDerivNo)
                 && (this.SFBLGoodsCode == target.SFBLGoodsCode)
                 && (this.SFBLGoodsCodeDerivNo == target.SFBLGoodsCodeDerivNo)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName));
        }

        /// <summary>
        /// BLコード変換（ユーザー登録）ワーク比較処理
        /// </summary>
        /// <param name="bLGoodsCdChgU1">
        ///                    比較するBLGoodsCdChgUWorkクラスのインスタンス
        /// </param>
        /// <param name="bLGoodsCdChgU2">比較するBLGoodsCdChgUWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(BLGoodsCdChgUWork bLGoodsCdChgU1, BLGoodsCdChgUWork bLGoodsCdChgU2)
        {
            return ((bLGoodsCdChgU1.CreateDateTime == bLGoodsCdChgU2.CreateDateTime)
                 && (bLGoodsCdChgU1.UpdateDateTime == bLGoodsCdChgU2.UpdateDateTime)
                 && (bLGoodsCdChgU1.EnterpriseCode == bLGoodsCdChgU2.EnterpriseCode)
                 && (bLGoodsCdChgU1.FileHeaderGuid == bLGoodsCdChgU2.FileHeaderGuid)
                 && (bLGoodsCdChgU1.UpdEmployeeCode == bLGoodsCdChgU2.UpdEmployeeCode)
                 && (bLGoodsCdChgU1.UpdAssemblyId1 == bLGoodsCdChgU2.UpdAssemblyId1)
                 && (bLGoodsCdChgU1.UpdAssemblyId2 == bLGoodsCdChgU2.UpdAssemblyId2)
                 && (bLGoodsCdChgU1.LogicalDeleteCode == bLGoodsCdChgU2.LogicalDeleteCode)
                 && (bLGoodsCdChgU1.SectionCode == bLGoodsCdChgU2.SectionCode)
                 && (bLGoodsCdChgU1.CustomerCode == bLGoodsCdChgU2.CustomerCode)
                 && (bLGoodsCdChgU1.PMBLGoodsCode == bLGoodsCdChgU2.PMBLGoodsCode)
                 && (bLGoodsCdChgU1.PMBLGoodsCodeDerivNo == bLGoodsCdChgU2.PMBLGoodsCodeDerivNo)
                 && (bLGoodsCdChgU1.SFBLGoodsCode == bLGoodsCdChgU2.SFBLGoodsCode)
                 && (bLGoodsCdChgU1.SFBLGoodsCodeDerivNo == bLGoodsCdChgU2.SFBLGoodsCodeDerivNo)
                 && (bLGoodsCdChgU1.BLGoodsFullName == bLGoodsCdChgU2.BLGoodsFullName)
                 && (bLGoodsCdChgU1.BLGoodsHalfName == bLGoodsCdChgU2.BLGoodsHalfName));
        }
        /// <summary>
        /// BLコード変換（ユーザー登録）ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のBLGoodsCdChgUWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(BLGoodsCdChgUWork target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.PMBLGoodsCode != target.PMBLGoodsCode) resList.Add("PMBLGoodsCode");
            if (this.PMBLGoodsCodeDerivNo != target.PMBLGoodsCodeDerivNo) resList.Add("PMBLGoodsCodeDerivNo");
            if (this.SFBLGoodsCode != target.SFBLGoodsCode) resList.Add("SFBLGoodsCode");
            if (this.SFBLGoodsCodeDerivNo != target.SFBLGoodsCodeDerivNo) resList.Add("SFBLGoodsCodeDerivNo");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");

            return resList;
        }

        /// <summary>
        /// BLコード変換（ユーザー登録）ワーク比較処理
        /// </summary>
        /// <param name="bLGoodsCdChgU1">比較するBLGoodsCdChgUWorkクラスのインスタンス</param>
        /// <param name="bLGoodsCdChgU2">比較するBLGoodsCdChgUWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(BLGoodsCdChgUWork bLGoodsCdChgU1, BLGoodsCdChgUWork bLGoodsCdChgU2)
        {
            ArrayList resList = new ArrayList();
            if (bLGoodsCdChgU1.CreateDateTime != bLGoodsCdChgU2.CreateDateTime) resList.Add("CreateDateTime");
            if (bLGoodsCdChgU1.UpdateDateTime != bLGoodsCdChgU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (bLGoodsCdChgU1.EnterpriseCode != bLGoodsCdChgU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (bLGoodsCdChgU1.FileHeaderGuid != bLGoodsCdChgU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (bLGoodsCdChgU1.UpdEmployeeCode != bLGoodsCdChgU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (bLGoodsCdChgU1.UpdAssemblyId1 != bLGoodsCdChgU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (bLGoodsCdChgU1.UpdAssemblyId2 != bLGoodsCdChgU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (bLGoodsCdChgU1.LogicalDeleteCode != bLGoodsCdChgU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (bLGoodsCdChgU1.SectionCode != bLGoodsCdChgU2.SectionCode) resList.Add("SectionCode");
            if (bLGoodsCdChgU1.CustomerCode != bLGoodsCdChgU2.CustomerCode) resList.Add("CustomerCode");
            if (bLGoodsCdChgU1.PMBLGoodsCode != bLGoodsCdChgU2.PMBLGoodsCode) resList.Add("PMBLGoodsCode");
            if (bLGoodsCdChgU1.PMBLGoodsCodeDerivNo != bLGoodsCdChgU2.PMBLGoodsCodeDerivNo) resList.Add("PMBLGoodsCodeDerivNo");
            if (bLGoodsCdChgU1.SFBLGoodsCode != bLGoodsCdChgU2.SFBLGoodsCode) resList.Add("SFBLGoodsCode");
            if (bLGoodsCdChgU1.SFBLGoodsCodeDerivNo != bLGoodsCdChgU2.SFBLGoodsCodeDerivNo) resList.Add("SFBLGoodsCodeDerivNo");
            if (bLGoodsCdChgU1.BLGoodsFullName != bLGoodsCdChgU2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (bLGoodsCdChgU1.BLGoodsHalfName != bLGoodsCdChgU2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");

            return resList;
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>BLGoodsCdChgUWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class BLGoodsCdChgUWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  BLGoodsCdChgUWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is BLGoodsCdChgUWork || graph is ArrayList || graph is BLGoodsCdChgUWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(BLGoodsCdChgUWork).FullName));

            if (graph != null && graph is BLGoodsCdChgUWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is BLGoodsCdChgUWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((BLGoodsCdChgUWork[])graph).Length;
            }
            else if (graph is BLGoodsCdChgUWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //PM側BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PMBLGoodsCode
            //PM側BL商品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //PMBLGoodsCodeDerivNo
            //SF側BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SFBLGoodsCode
            //SF側BL商品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //SFBLGoodsCodeDerivNo
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //BL商品コード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName


            serInfo.Serialize(writer, serInfo);
            if (graph is BLGoodsCdChgUWork)
            {
                BLGoodsCdChgUWork temp = (BLGoodsCdChgUWork)graph;

                SetBLGoodsCdChgUWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is BLGoodsCdChgUWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((BLGoodsCdChgUWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (BLGoodsCdChgUWork temp in lst)
                {
                    SetBLGoodsCdChgUWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// BLGoodsCdChgUWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  BLGoodsCdChgUWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetBLGoodsCdChgUWork(System.IO.BinaryWriter writer, BLGoodsCdChgUWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //得意先コード
            writer.Write(temp.CustomerCode);
            //PM側BL商品コード
            writer.Write(temp.PMBLGoodsCode);
            //PM側BL商品コード枝番
            writer.Write(temp.PMBLGoodsCodeDerivNo);
            //SF側BL商品コード
            writer.Write(temp.SFBLGoodsCode);
            //SF側BL商品コード枝番
            writer.Write(temp.SFBLGoodsCodeDerivNo);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //BL商品コード名称（半角）
            writer.Write(temp.BLGoodsHalfName);

        }

        /// <summary>
        ///  BLGoodsCdChgUWorkインスタンス取得
        /// </summary>
        /// <returns>BLGoodsCdChgUWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private BLGoodsCdChgUWork GetBLGoodsCdChgUWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            BLGoodsCdChgUWork temp = new BLGoodsCdChgUWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //PM側BL商品コード
            temp.PMBLGoodsCode = reader.ReadInt32();
            //PM側BL商品コード枝番
            temp.PMBLGoodsCodeDerivNo = reader.ReadInt32();
            //SF側BL商品コード
            temp.SFBLGoodsCode = reader.ReadInt32();
            //SF側BL商品コード枝番
            temp.SFBLGoodsCodeDerivNo = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //BL商品コード名称（半角）
            temp.BLGoodsHalfName = reader.ReadString();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>BLGoodsCdChgUWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BLGoodsCdChgUWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                BLGoodsCdChgUWork temp = GetBLGoodsCdChgUWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (BLGoodsCdChgUWork[])lst.ToArray(typeof(BLGoodsCdChgUWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
