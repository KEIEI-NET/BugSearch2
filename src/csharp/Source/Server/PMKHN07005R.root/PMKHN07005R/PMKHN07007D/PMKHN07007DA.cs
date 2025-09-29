using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PostcardEnvelopeDMWork
    /// <summary>
    ///                      出力デフォルト設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   出力デフォルト設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/04/01</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PostcardEnvelopeDMWork
    {
        #region ■ Private Member
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>拠点オプション導入区分</summary>
        private bool _isOptSection;

        /// <summary>本社機能プロパティ</summary>
        private bool _isMainOfficeFunc;

        /// <summary>拠点コード開始</summary>
        private string _st_SectionCode;

        /// <summary>拠点コード終了</summary>
        private string _ed_SectionCode;

        /// <summary>使用マスタ</summary>
        private int _useMast;

        /// <summary>出力区分</summary>
        private int _outShipDiv;

        /// <summary>締日</summary>
        private DateTime _totalDay;

        /// <summary>対象日付開始日</summary>
        private DateTime _st_AddUpDay;

        /// <summary>対象日付終了日</summary>
        private DateTime _ed_AddUpDay;

        /// <summary>得意先コード開始</summary>
        private Int32 _st_CustomerCode;

        /// <summary>得意先コード終了</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>仕入先コード開始</summary>
        private Int32 _st_SupplierCode;

        /// <summary>仕入先コード終了</summary>
        private Int32 _ed_SupplierCode;

        #endregion ■ Private Member

        #region ■ Public Property
        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   企業コードプロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

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

        /// public propaty name  :  IsOptSection
        /// <summary>拠点オプション導入区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   拠点オプション導入区分プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>本社機能プロパティプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   本社機能プロパティプロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
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

        /// public propaty name  :  St_SectionCode
        /// <summary>拠点コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   拠点コード開始プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_SectionCode
        {
            get { return _st_SectionCode; }
            set { _st_SectionCode = value; }
        }


        /// public propaty name  :  Ed_SectionCode
        /// <summary>拠点コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   拠点コード終了プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_SectionCode
        {
            get { return _ed_SectionCode; }
            set { _ed_SectionCode = value; }
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

        /// public propaty name  :  UseMast
        /// <summary>使用マスタ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   使用マスタプロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int UseMast
        {
            get { return _useMast; }
            set { _useMast = value; }
        }

        /// public propaty name  :  OutShipDiv
        /// <summary>出力区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   出力区分プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int OutShipDiv
        {
            get { return _outShipDiv; }
            set { _outShipDiv = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   締日プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  St_AddUpDay
        /// <summary>対象日付開始日</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   対象日付開始日プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_AddUpDay
        {
            get { return _st_AddUpDay; }
            set { _st_AddUpDay = value; }
        }

        /// public propaty name  :  Ed_AddUpDay
        /// <summary>対象日付終了日</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   対象日付終了日プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_AddUpDay
        {
            get { return _ed_AddUpDay; }
            set { _ed_AddUpDay = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>得意先コード開始</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   得意先コード開始プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  : Ed_CustomerCode
        /// <summary>得意先コード終了</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   得意先コード終了プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  : St_SupplierCode
        /// <summary>仕入先コード開始</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   仕入先コード開始プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SupplierCode
        {
            get { return _st_SupplierCode; }
            set { _st_SupplierCode = value; }
        }

        /// public propaty name  : Ed_SupplierCode
        /// <summary>仕入先コード終了</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   仕入先コード終了プロパティを行います。</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SupplierCode
        {
            get { return _ed_SupplierCode; }
            set { _ed_SupplierCode = value; }
        }
        #endregion ■ Private Property

        #region ■ Public Enum
        #region ◆ 出力区分列挙体
        /// <summary> 出力区分列挙体 </summary>
        public enum OutShipDivState
        {
            /// <summary>全て</summary>
            All = 0,
            /// <summary>請求有り</summary>
            Claim = 1,
            /// <summary>伝票有り</summary>
            Slip = 2,
        }
        #endregion ◆

        #region ◆ 使用マスタ列挙体
        /// <summary> 使用マスタ列挙体 </summary>
        public enum UseMastDivState
        {
            /// <summary>得意先マスタ</summary>
            Customer = 0,
            /// <summary>仕入先マスタ</summary>
            Supplier = 1,
            /// <summary>自社マスタ</summary>
            Company = 2,
            /// <summary>拠点マスタ</summary>
            SecInfo = 3,
        }
        #endregion ◆
        #endregion ■ Public Enum

        /// <summary>
        /// マスタデータワークコンストラクタ
        /// </summary>
        /// <returns>PostcardEnvelopeDMWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PostcardEnvelopeDMWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Date             :   2009/04/01</br>
        /// </remarks>
        public PostcardEnvelopeDMWork()
        {

        }
    }
}

