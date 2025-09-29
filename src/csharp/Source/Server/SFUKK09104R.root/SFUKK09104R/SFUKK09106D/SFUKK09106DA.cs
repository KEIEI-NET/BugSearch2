//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   請求全体設定マスタデータパラメータ
//                  :   SFUKK09106D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   BillAllStWork
    /// <summary>
    /// 
    ///                      請求全体設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   請求全体設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2008/06/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class BillAllStWork : IFileHeader
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
        /// <remarks>拠点コード（番号採番用）０は全社共通</remarks>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>引当処理区分</summary>
        /// <remarks>0:両方,1:必須,2:不可</remarks>
        private Int32 _allowanceProcCd;

        /// <summary>入金伝票修正区分</summary>
        /// <remarks>0:修正可,1:修正不可</remarks>
        private Int32 _depositSlipMntCd;

        /// <summary>回収予定区分</summary>
        /// <remarks>0:区分 1:日付</remarks>
        private Int32 _collectPlnDiv;

        /// <summary>得意先締日１</summary>
        private Int32 _customerTotalDay1;

        /// <summary>得意先締日２</summary>
        private Int32 _customerTotalDay2;

        /// <summary>得意先締日３</summary>
        private Int32 _customerTotalDay3;

        /// <summary>得意先締日４</summary>
        private Int32 _customerTotalDay4;

        /// <summary>得意先締日５</summary>
        private Int32 _customerTotalDay5;

        /// <summary>得意先締日６</summary>
        private Int32 _customerTotalDay6;

        /// <summary>得意先締日７</summary>
        private Int32 _customerTotalDay7;

        /// <summary>得意先締日８</summary>
        private Int32 _customerTotalDay8;

        /// <summary>得意先締日９</summary>
        private Int32 _customerTotalDay9;

        /// <summary>得意先締日１０</summary>
        private Int32 _customerTotalDay10;

        /// <summary>得意先締日１１</summary>
        private Int32 _customerTotalDay11;

        /// <summary>得意先締日１２</summary>
        private Int32 _customerTotalDay12;

        /// <summary>仕入先締日１</summary>
        private Int32 _supplierTotalDay1;

        /// <summary>仕入先締日２</summary>
        private Int32 _supplierTotalDay2;

        /// <summary>仕入先締日３</summary>
        private Int32 _supplierTotalDay3;

        /// <summary>仕入先締日４</summary>
        private Int32 _supplierTotalDay4;

        /// <summary>仕入先締日５</summary>
        private Int32 _supplierTotalDay5;

        /// <summary>仕入先締日６</summary>
        private Int32 _supplierTotalDay6;

        /// <summary>仕入先締日７</summary>
        private Int32 _supplierTotalDay7;

        /// <summary>仕入先締日８</summary>
        private Int32 _supplierTotalDay8;

        /// <summary>仕入先締日９</summary>
        private Int32 _supplierTotalDay9;

        /// <summary>仕入先締日１０</summary>
        private Int32 _supplierTotalDay10;

        /// <summary>仕入先締日１１</summary>
        private Int32 _supplierTotalDay11;

        /// <summary>仕入先締日１２</summary>
        private Int32 _supplierTotalDay12;


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
        /// <value>拠点コード（番号採番用）０は全社共通</value>
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  AllowanceProcCd
        /// <summary>引当処理区分プロパティ</summary>
        /// <value>0:両方,1:必須,2:不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引当処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AllowanceProcCd
        {
            get { return _allowanceProcCd; }
            set { _allowanceProcCd = value; }
        }

        /// public propaty name  :  DepositSlipMntCd
        /// <summary>入金伝票修正区分プロパティ</summary>
        /// <value>0:修正可,1:修正不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金伝票修正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositSlipMntCd
        {
            get { return _depositSlipMntCd; }
            set { _depositSlipMntCd = value; }
        }

        /// public propaty name  :  CollectPlnDiv
        /// <summary>回収予定区分プロパティ</summary>
        /// <value>0:区分 1:日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収予定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectPlnDiv
        {
            get { return _collectPlnDiv; }
            set { _collectPlnDiv = value; }
        }

        /// public propaty name  :  CustomerTotalDay1
        /// <summary>得意先締日１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay1
        {
            get { return _customerTotalDay1; }
            set { _customerTotalDay1 = value; }
        }

        /// public propaty name  :  CustomerTotalDay2
        /// <summary>得意先締日２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay2
        {
            get { return _customerTotalDay2; }
            set { _customerTotalDay2 = value; }
        }

        /// public propaty name  :  CustomerTotalDay3
        /// <summary>得意先締日３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay3
        {
            get { return _customerTotalDay3; }
            set { _customerTotalDay3 = value; }
        }

        /// public propaty name  :  CustomerTotalDay4
        /// <summary>得意先締日４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay4
        {
            get { return _customerTotalDay4; }
            set { _customerTotalDay4 = value; }
        }

        /// public propaty name  :  CustomerTotalDay5
        /// <summary>得意先締日５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay5
        {
            get { return _customerTotalDay5; }
            set { _customerTotalDay5 = value; }
        }

        /// public propaty name  :  CustomerTotalDay6
        /// <summary>得意先締日６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay6
        {
            get { return _customerTotalDay6; }
            set { _customerTotalDay6 = value; }
        }

        /// public propaty name  :  CustomerTotalDay7
        /// <summary>得意先締日７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay7
        {
            get { return _customerTotalDay7; }
            set { _customerTotalDay7 = value; }
        }

        /// public propaty name  :  CustomerTotalDay8
        /// <summary>得意先締日８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay8
        {
            get { return _customerTotalDay8; }
            set { _customerTotalDay8 = value; }
        }

        /// public propaty name  :  CustomerTotalDay9
        /// <summary>得意先締日９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay9
        {
            get { return _customerTotalDay9; }
            set { _customerTotalDay9 = value; }
        }

        /// public propaty name  :  CustomerTotalDay10
        /// <summary>得意先締日１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay10
        {
            get { return _customerTotalDay10; }
            set { _customerTotalDay10 = value; }
        }

        /// public propaty name  :  CustomerTotalDay11
        /// <summary>得意先締日１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay11
        {
            get { return _customerTotalDay11; }
            set { _customerTotalDay11 = value; }
        }

        /// public propaty name  :  CustomerTotalDay12
        /// <summary>得意先締日１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先締日１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTotalDay12
        {
            get { return _customerTotalDay12; }
            set { _customerTotalDay12 = value; }
        }

        /// public propaty name  :  SupplierTotalDay1
        /// <summary>仕入先締日１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay1
        {
            get { return _supplierTotalDay1; }
            set { _supplierTotalDay1 = value; }
        }

        /// public propaty name  :  SupplierTotalDay2
        /// <summary>仕入先締日２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay2
        {
            get { return _supplierTotalDay2; }
            set { _supplierTotalDay2 = value; }
        }

        /// public propaty name  :  SupplierTotalDay3
        /// <summary>仕入先締日３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay3
        {
            get { return _supplierTotalDay3; }
            set { _supplierTotalDay3 = value; }
        }

        /// public propaty name  :  SupplierTotalDay4
        /// <summary>仕入先締日４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay4
        {
            get { return _supplierTotalDay4; }
            set { _supplierTotalDay4 = value; }
        }

        /// public propaty name  :  SupplierTotalDay5
        /// <summary>仕入先締日５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay5
        {
            get { return _supplierTotalDay5; }
            set { _supplierTotalDay5 = value; }
        }

        /// public propaty name  :  SupplierTotalDay6
        /// <summary>仕入先締日６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay6
        {
            get { return _supplierTotalDay6; }
            set { _supplierTotalDay6 = value; }
        }

        /// public propaty name  :  SupplierTotalDay7
        /// <summary>仕入先締日７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay7
        {
            get { return _supplierTotalDay7; }
            set { _supplierTotalDay7 = value; }
        }

        /// public propaty name  :  SupplierTotalDay8
        /// <summary>仕入先締日８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay8
        {
            get { return _supplierTotalDay8; }
            set { _supplierTotalDay8 = value; }
        }

        /// public propaty name  :  SupplierTotalDay9
        /// <summary>仕入先締日９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay9
        {
            get { return _supplierTotalDay9; }
            set { _supplierTotalDay9 = value; }
        }

        /// public propaty name  :  SupplierTotalDay10
        /// <summary>仕入先締日１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay10
        {
            get { return _supplierTotalDay10; }
            set { _supplierTotalDay10 = value; }
        }

        /// public propaty name  :  SupplierTotalDay11
        /// <summary>仕入先締日１１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日１１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay11
        {
            get { return _supplierTotalDay11; }
            set { _supplierTotalDay11 = value; }
        }

        /// public propaty name  :  SupplierTotalDay12
        /// <summary>仕入先締日１２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先締日１２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierTotalDay12
        {
            get { return _supplierTotalDay12; }
            set { _supplierTotalDay12 = value; }
        }


        /// <summary>
        /// 請求全体設定ワークコンストラクタ
        /// </summary>
        /// <returns>BillAllStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillAllStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BillAllStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>BillAllStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   BillAllStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class BillAllStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillAllStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  BillAllStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is BillAllStWork || graph is ArrayList || graph is BillAllStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(BillAllStWork).FullName));

            if (graph != null && graph is BillAllStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.BillAllStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is BillAllStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((BillAllStWork[])graph).Length;
            }
            else if (graph is BillAllStWork)
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
            serInfo.MemberInfo.Add(typeof(byte[])); //FileHeaderGuid
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
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //引当処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AllowanceProcCd
            //入金伝票修正区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositSlipMntCd
            //回収予定区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectPlnDiv
            //得意先締日１
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay1
            //得意先締日２
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay2
            //得意先締日３
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay3
            //得意先締日４
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay4
            //得意先締日５
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay5
            //得意先締日６
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay6
            //得意先締日７
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay7
            //得意先締日８
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay8
            //得意先締日９
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay9
            //得意先締日１０
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay10
            //得意先締日１１
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay11
            //得意先締日１２
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay12
            //仕入先締日１
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay1
            //仕入先締日２
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay2
            //仕入先締日３
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay3
            //仕入先締日４
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay4
            //仕入先締日５
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay5
            //仕入先締日６
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay6
            //仕入先締日７
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay7
            //仕入先締日８
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay8
            //仕入先締日９
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay9
            //仕入先締日１０
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay10
            //仕入先締日１１
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay11
            //仕入先締日１２
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay12


            serInfo.Serialize(writer, serInfo);
            if (graph is BillAllStWork)
            {
                BillAllStWork temp = (BillAllStWork)graph;

                SetBillAllStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is BillAllStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((BillAllStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (BillAllStWork temp in lst)
                {
                    SetBillAllStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// BillAllStWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 37;

        /// <summary>
        ///  BillAllStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillAllStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetBillAllStWork(System.IO.BinaryWriter writer, BillAllStWork temp)
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
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //引当処理区分
            writer.Write(temp.AllowanceProcCd);
            //入金伝票修正区分
            writer.Write(temp.DepositSlipMntCd);
            //回収予定区分
            writer.Write(temp.CollectPlnDiv);
            //得意先締日１
            writer.Write(temp.CustomerTotalDay1);
            //得意先締日２
            writer.Write(temp.CustomerTotalDay2);
            //得意先締日３
            writer.Write(temp.CustomerTotalDay3);
            //得意先締日４
            writer.Write(temp.CustomerTotalDay4);
            //得意先締日５
            writer.Write(temp.CustomerTotalDay5);
            //得意先締日６
            writer.Write(temp.CustomerTotalDay6);
            //得意先締日７
            writer.Write(temp.CustomerTotalDay7);
            //得意先締日８
            writer.Write(temp.CustomerTotalDay8);
            //得意先締日９
            writer.Write(temp.CustomerTotalDay9);
            //得意先締日１０
            writer.Write(temp.CustomerTotalDay10);
            //得意先締日１１
            writer.Write(temp.CustomerTotalDay11);
            //得意先締日１２
            writer.Write(temp.CustomerTotalDay12);
            //仕入先締日１
            writer.Write(temp.SupplierTotalDay1);
            //仕入先締日２
            writer.Write(temp.SupplierTotalDay2);
            //仕入先締日３
            writer.Write(temp.SupplierTotalDay3);
            //仕入先締日４
            writer.Write(temp.SupplierTotalDay4);
            //仕入先締日５
            writer.Write(temp.SupplierTotalDay5);
            //仕入先締日６
            writer.Write(temp.SupplierTotalDay6);
            //仕入先締日７
            writer.Write(temp.SupplierTotalDay7);
            //仕入先締日８
            writer.Write(temp.SupplierTotalDay8);
            //仕入先締日９
            writer.Write(temp.SupplierTotalDay9);
            //仕入先締日１０
            writer.Write(temp.SupplierTotalDay10);
            //仕入先締日１１
            writer.Write(temp.SupplierTotalDay11);
            //仕入先締日１２
            writer.Write(temp.SupplierTotalDay12);

        }

        /// <summary>
        ///  BillAllStWorkインスタンス取得
        /// </summary>
        /// <returns>BillAllStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillAllStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private BillAllStWork GetBillAllStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            BillAllStWork temp = new BillAllStWork();

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
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //引当処理区分
            temp.AllowanceProcCd = reader.ReadInt32();
            //入金伝票修正区分
            temp.DepositSlipMntCd = reader.ReadInt32();
            //回収予定区分
            temp.CollectPlnDiv = reader.ReadInt32();
            //得意先締日１
            temp.CustomerTotalDay1 = reader.ReadInt32();
            //得意先締日２
            temp.CustomerTotalDay2 = reader.ReadInt32();
            //得意先締日３
            temp.CustomerTotalDay3 = reader.ReadInt32();
            //得意先締日４
            temp.CustomerTotalDay4 = reader.ReadInt32();
            //得意先締日５
            temp.CustomerTotalDay5 = reader.ReadInt32();
            //得意先締日６
            temp.CustomerTotalDay6 = reader.ReadInt32();
            //得意先締日７
            temp.CustomerTotalDay7 = reader.ReadInt32();
            //得意先締日８
            temp.CustomerTotalDay8 = reader.ReadInt32();
            //得意先締日９
            temp.CustomerTotalDay9 = reader.ReadInt32();
            //得意先締日１０
            temp.CustomerTotalDay10 = reader.ReadInt32();
            //得意先締日１１
            temp.CustomerTotalDay11 = reader.ReadInt32();
            //得意先締日１２
            temp.CustomerTotalDay12 = reader.ReadInt32();
            //仕入先締日１
            temp.SupplierTotalDay1 = reader.ReadInt32();
            //仕入先締日２
            temp.SupplierTotalDay2 = reader.ReadInt32();
            //仕入先締日３
            temp.SupplierTotalDay3 = reader.ReadInt32();
            //仕入先締日４
            temp.SupplierTotalDay4 = reader.ReadInt32();
            //仕入先締日５
            temp.SupplierTotalDay5 = reader.ReadInt32();
            //仕入先締日６
            temp.SupplierTotalDay6 = reader.ReadInt32();
            //仕入先締日７
            temp.SupplierTotalDay7 = reader.ReadInt32();
            //仕入先締日８
            temp.SupplierTotalDay8 = reader.ReadInt32();
            //仕入先締日９
            temp.SupplierTotalDay9 = reader.ReadInt32();
            //仕入先締日１０
            temp.SupplierTotalDay10 = reader.ReadInt32();
            //仕入先締日１１
            temp.SupplierTotalDay11 = reader.ReadInt32();
            //仕入先締日１２
            temp.SupplierTotalDay12 = reader.ReadInt32();


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
        /// <returns>BillAllStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   BillAllStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                BillAllStWork temp = GetBillAllStWork(reader, serInfo);
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
                    retValue = (BillAllStWork[])lst.ToArray(typeof(BillAllStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
