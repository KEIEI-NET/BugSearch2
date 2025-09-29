using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CompanyNmWork
    /// <summary>
    ///                      自社名称ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自社名称ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/11</br>
    /// <br>Genarated Date   :   2008/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CompanyNmWork : IFileHeader
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

        /// <summary>自社名称コード</summary>
        private Int32 _companyNameCd;

        /// <summary>自社PR文</summary>
        private string _companyPr = "";

        /// <summary>自社名称1</summary>
        private string _companyName1 = "";

        /// <summary>自社名称2</summary>
        private string _companyName2 = "";

        /// <summary>郵便番号</summary>
        private string _postNo = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        private string _address1 = "";

        /// <summary>住所3（番地）</summary>
        private string _address3 = "";

        /// <summary>住所4（アパート名称）</summary>
        private string _address4 = "";

        /// <summary>自社電話番号1</summary>
        /// <remarks>TEL</remarks>
        private string _companyTelNo1 = "";

        /// <summary>自社電話番号2</summary>
        /// <remarks>TEL2</remarks>
        private string _companyTelNo2 = "";

        /// <summary>自社電話番号3</summary>
        /// <remarks>FAX</remarks>
        private string _companyTelNo3 = "";

        /// <summary>自社電話番号タイトル1</summary>
        /// <remarks>TEL</remarks>
        private string _companyTelTitle1 = "";

        /// <summary>自社電話番号タイトル2</summary>
        /// <remarks>TEL2</remarks>
        private string _companyTelTitle2 = "";

        /// <summary>自社電話番号タイトル3</summary>
        /// <remarks>FAX</remarks>
        private string _companyTelTitle3 = "";

        /// <summary>銀行振込案内文</summary>
        private string _transferGuidance = "";

        /// <summary>銀行口座1</summary>
        private string _accountNoInfo1 = "";

        /// <summary>銀行口座2</summary>
        private string _accountNoInfo2 = "";

        /// <summary>銀行口座3</summary>
        private string _accountNoInfo3 = "";

        /// <summary>自社設定摘要1</summary>
        private string _companySetNote1 = "";

        /// <summary>自社設定摘要2</summary>
        private string _companySetNote2 = "";

        /// <summary>画像情報区分</summary>
        /// <remarks>10:自社画像,20:POSで使用する画像</remarks>
        private Int32 _imageInfoDiv;

        /// <summary>画像情報コード</summary>
        private Int32 _imageInfoCode;

        /// <summary>自社URL</summary>
        private string _companyUrl = "";

        /// <summary>自社PR文2</summary>
        /// <remarks>代表取締役等の情報を入力</remarks>
        private string _companyPrSentence2 = "";

        /// <summary>画像印字用コメント1</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _imageCommentForPrt1 = "";

        /// <summary>画像印字用コメント2</summary>
        /// <remarks>画像印字する場合、画像の下に印字する（拠点名等）</remarks>
        private string _imageCommentForPrt2 = "";


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

        /// public propaty name  :  CompanyNameCd
        /// <summary>自社名称コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CompanyNameCd
        {
            get { return _companyNameCd; }
            set { _companyNameCd = value; }
        }

        /// public propaty name  :  CompanyPr
        /// <summary>自社PR文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社PR文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyPr
        {
            get { return _companyPr; }
            set { _companyPr = value; }
        }

        /// public propaty name  :  CompanyName1
        /// <summary>自社名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  CompanyName2
        /// <summary>自社名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyName2
        {
            get { return _companyName2; }
            set { _companyName2 = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>郵便番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>住所3（番地）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  CompanyTelNo1
        /// <summary>自社電話番号1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelNo1
        {
            get { return _companyTelNo1; }
            set { _companyTelNo1 = value; }
        }

        /// public propaty name  :  CompanyTelNo2
        /// <summary>自社電話番号2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelNo2
        {
            get { return _companyTelNo2; }
            set { _companyTelNo2 = value; }
        }

        /// public propaty name  :  CompanyTelNo3
        /// <summary>自社電話番号3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelNo3
        {
            get { return _companyTelNo3; }
            set { _companyTelNo3 = value; }
        }

        /// public propaty name  :  CompanyTelTitle1
        /// <summary>自社電話番号タイトル1プロパティ</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelTitle1
        {
            get { return _companyTelTitle1; }
            set { _companyTelTitle1 = value; }
        }

        /// public propaty name  :  CompanyTelTitle2
        /// <summary>自社電話番号タイトル2プロパティ</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelTitle2
        {
            get { return _companyTelTitle2; }
            set { _companyTelTitle2 = value; }
        }

        /// public propaty name  :  CompanyTelTitle3
        /// <summary>自社電話番号タイトル3プロパティ</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社電話番号タイトル3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyTelTitle3
        {
            get { return _companyTelTitle3; }
            set { _companyTelTitle3 = value; }
        }

        /// public propaty name  :  TransferGuidance
        /// <summary>銀行振込案内文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行振込案内文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransferGuidance
        {
            get { return _transferGuidance; }
            set { _transferGuidance = value; }
        }

        /// public propaty name  :  AccountNoInfo1
        /// <summary>銀行口座1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AccountNoInfo1
        {
            get { return _accountNoInfo1; }
            set { _accountNoInfo1 = value; }
        }

        /// public propaty name  :  AccountNoInfo2
        /// <summary>銀行口座2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AccountNoInfo2
        {
            get { return _accountNoInfo2; }
            set { _accountNoInfo2 = value; }
        }

        /// public propaty name  :  AccountNoInfo3
        /// <summary>銀行口座3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AccountNoInfo3
        {
            get { return _accountNoInfo3; }
            set { _accountNoInfo3 = value; }
        }

        /// public propaty name  :  CompanySetNote1
        /// <summary>自社設定摘要1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanySetNote1
        {
            get { return _companySetNote1; }
            set { _companySetNote1 = value; }
        }

        /// public propaty name  :  CompanySetNote2
        /// <summary>自社設定摘要2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社設定摘要2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanySetNote2
        {
            get { return _companySetNote2; }
            set { _companySetNote2 = value; }
        }

        /// public propaty name  :  ImageInfoDiv
        /// <summary>画像情報区分プロパティ</summary>
        /// <value>10:自社画像,20:POSで使用する画像</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ImageInfoDiv
        {
            get { return _imageInfoDiv; }
            set { _imageInfoDiv = value; }
        }

        /// public propaty name  :  ImageInfoCode
        /// <summary>画像情報コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像情報コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ImageInfoCode
        {
            get { return _imageInfoCode; }
            set { _imageInfoCode = value; }
        }

        /// public propaty name  :  CompanyUrl
        /// <summary>自社URLプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社URLプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyUrl
        {
            get { return _companyUrl; }
            set { _companyUrl = value; }
        }

        /// public propaty name  :  CompanyPrSentence2
        /// <summary>自社PR文2プロパティ</summary>
        /// <value>代表取締役等の情報を入力</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社PR文2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CompanyPrSentence2
        {
            get { return _companyPrSentence2; }
            set { _companyPrSentence2 = value; }
        }

        /// public propaty name  :  ImageCommentForPrt1
        /// <summary>画像印字用コメント1プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像印字用コメント1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ImageCommentForPrt1
        {
            get { return _imageCommentForPrt1; }
            set { _imageCommentForPrt1 = value; }
        }

        /// public propaty name  :  ImageCommentForPrt2
        /// <summary>画像印字用コメント2プロパティ</summary>
        /// <value>画像印字する場合、画像の下に印字する（拠点名等）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   画像印字用コメント2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ImageCommentForPrt2
        {
            get { return _imageCommentForPrt2; }
            set { _imageCommentForPrt2 = value; }
        }


        /// <summary>
        /// 自社名称ワークコンストラクタ
        /// </summary>
        /// <returns>CompanyNmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyNmWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CompanyNmWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CompanyNmWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CompanyNmWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CompanyNmWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyNmWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CompanyNmWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CompanyNmWork || graph is ArrayList || graph is CompanyNmWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CompanyNmWork).FullName));

            if (graph != null && graph is CompanyNmWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CompanyNmWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CompanyNmWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CompanyNmWork[])graph).Length;
            }
            else if (graph is CompanyNmWork)
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
            //自社名称コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyNameCd
            //自社PR文
            serInfo.MemberInfo.Add(typeof(string)); //CompanyPr
            //自社名称1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //自社名称2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName2
            //郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //住所3（番地）
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //住所4（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //自社電話番号1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo1
            //自社電話番号2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo2
            //自社電話番号3
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo3
            //自社電話番号タイトル1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle1
            //自社電話番号タイトル2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle2
            //自社電話番号タイトル3
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle3
            //銀行振込案内文
            serInfo.MemberInfo.Add(typeof(string)); //TransferGuidance
            //銀行口座1
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo1
            //銀行口座2
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo2
            //銀行口座3
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo3
            //自社設定摘要1
            serInfo.MemberInfo.Add(typeof(string)); //CompanySetNote1
            //自社設定摘要2
            serInfo.MemberInfo.Add(typeof(string)); //CompanySetNote2
            //画像情報区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ImageInfoDiv
            //画像情報コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ImageInfoCode
            //自社URL
            serInfo.MemberInfo.Add(typeof(string)); //CompanyUrl
            //自社PR文2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyPrSentence2
            //画像印字用コメント1
            serInfo.MemberInfo.Add(typeof(string)); //ImageCommentForPrt1
            //画像印字用コメント2
            serInfo.MemberInfo.Add(typeof(string)); //ImageCommentForPrt2


            serInfo.Serialize(writer, serInfo);
            if (graph is CompanyNmWork)
            {
                CompanyNmWork temp = (CompanyNmWork)graph;

                SetCompanyNmWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CompanyNmWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CompanyNmWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CompanyNmWork temp in lst)
                {
                    SetCompanyNmWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CompanyNmWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 35;

        /// <summary>
        ///  CompanyNmWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyNmWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCompanyNmWork(System.IO.BinaryWriter writer, CompanyNmWork temp)
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
            //自社名称コード
            writer.Write(temp.CompanyNameCd);
            //自社PR文
            writer.Write(temp.CompanyPr);
            //自社名称1
            writer.Write(temp.CompanyName1);
            //自社名称2
            writer.Write(temp.CompanyName2);
            //郵便番号
            writer.Write(temp.PostNo);
            //住所1（都道府県市区郡・町村・字）
            writer.Write(temp.Address1);
            //住所3（番地）
            writer.Write(temp.Address3);
            //住所4（アパート名称）
            writer.Write(temp.Address4);
            //自社電話番号1
            writer.Write(temp.CompanyTelNo1);
            //自社電話番号2
            writer.Write(temp.CompanyTelNo2);
            //自社電話番号3
            writer.Write(temp.CompanyTelNo3);
            //自社電話番号タイトル1
            writer.Write(temp.CompanyTelTitle1);
            //自社電話番号タイトル2
            writer.Write(temp.CompanyTelTitle2);
            //自社電話番号タイトル3
            writer.Write(temp.CompanyTelTitle3);
            //銀行振込案内文
            writer.Write(temp.TransferGuidance);
            //銀行口座1
            writer.Write(temp.AccountNoInfo1);
            //銀行口座2
            writer.Write(temp.AccountNoInfo2);
            //銀行口座3
            writer.Write(temp.AccountNoInfo3);
            //自社設定摘要1
            writer.Write(temp.CompanySetNote1);
            //自社設定摘要2
            writer.Write(temp.CompanySetNote2);
            //画像情報区分
            writer.Write(temp.ImageInfoDiv);
            //画像情報コード
            writer.Write(temp.ImageInfoCode);
            //自社URL
            writer.Write(temp.CompanyUrl);
            //自社PR文2
            writer.Write(temp.CompanyPrSentence2);
            //画像印字用コメント1
            writer.Write(temp.ImageCommentForPrt1);
            //画像印字用コメント2
            writer.Write(temp.ImageCommentForPrt2);

        }

        /// <summary>
        ///  CompanyNmWorkインスタンス取得
        /// </summary>
        /// <returns>CompanyNmWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyNmWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CompanyNmWork GetCompanyNmWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CompanyNmWork temp = new CompanyNmWork();

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
            //自社名称コード
            temp.CompanyNameCd = reader.ReadInt32();
            //自社PR文
            temp.CompanyPr = reader.ReadString();
            //自社名称1
            temp.CompanyName1 = reader.ReadString();
            //自社名称2
            temp.CompanyName2 = reader.ReadString();
            //郵便番号
            temp.PostNo = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.Address1 = reader.ReadString();
            //住所3（番地）
            temp.Address3 = reader.ReadString();
            //住所4（アパート名称）
            temp.Address4 = reader.ReadString();
            //自社電話番号1
            temp.CompanyTelNo1 = reader.ReadString();
            //自社電話番号2
            temp.CompanyTelNo2 = reader.ReadString();
            //自社電話番号3
            temp.CompanyTelNo3 = reader.ReadString();
            //自社電話番号タイトル1
            temp.CompanyTelTitle1 = reader.ReadString();
            //自社電話番号タイトル2
            temp.CompanyTelTitle2 = reader.ReadString();
            //自社電話番号タイトル3
            temp.CompanyTelTitle3 = reader.ReadString();
            //銀行振込案内文
            temp.TransferGuidance = reader.ReadString();
            //銀行口座1
            temp.AccountNoInfo1 = reader.ReadString();
            //銀行口座2
            temp.AccountNoInfo2 = reader.ReadString();
            //銀行口座3
            temp.AccountNoInfo3 = reader.ReadString();
            //自社設定摘要1
            temp.CompanySetNote1 = reader.ReadString();
            //自社設定摘要2
            temp.CompanySetNote2 = reader.ReadString();
            //画像情報区分
            temp.ImageInfoDiv = reader.ReadInt32();
            //画像情報コード
            temp.ImageInfoCode = reader.ReadInt32();
            //自社URL
            temp.CompanyUrl = reader.ReadString();
            //自社PR文2
            temp.CompanyPrSentence2 = reader.ReadString();
            //画像印字用コメント1
            temp.ImageCommentForPrt1 = reader.ReadString();
            //画像印字用コメント2
            temp.ImageCommentForPrt2 = reader.ReadString();


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
        /// <returns>CompanyNmWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CompanyNmWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CompanyNmWork temp = GetCompanyNmWork(reader, serInfo);
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
                    retValue = (CompanyNmWork[])lst.ToArray(typeof(CompanyNmWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
