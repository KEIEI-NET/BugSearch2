//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信抽出・更新DB仲介クラス              //
//                  :   PMKYO06431D.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.ParamData        //
// Programmer       :   呉元嘯                                          //
// Date             :   2009.04.29                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DCEmployeeDtlWork
    /// <summary>
    ///                      従業員詳細ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   従業員詳細ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2009/04/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/7/4  長内</br>
    /// <br>                 :   追加項目</br>
    /// <br>                 :   UOE略称区分</br>
    /// <br>Update Note      :   2/3  杉村</br>
    /// <br>                 :   追加項目</br>
    /// <br>                 :   メールアドレス種別コード1</br>
    /// <br>                 :   メールアドレス種別名称1</br>
    /// <br>                 :   メールアドレス1</br>
    /// <br>                 :   メール送信区分コード1</br>
    /// <br>                 :   メールアドレス種別コード2</br>
    /// <br>                 :   メールアドレス種別名称2</br>
    /// <br>                 :   メールアドレス2</br>
    /// <br>                 :   メール送信区分コード2</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DCEmployeeDtlWork : IFileHeader
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

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>所属部門コード</summary>
        /// <remarks>※部門管理しない場合は、使用しない</remarks>
        private Int32 _belongSubSectionCode;

        /// <summary>従業員分析コード１</summary>
        /// <remarks>年齢,グループ等分析用任意コードを設定</remarks>
        private Int32 _employAnalysCode1;

        /// <summary>従業員分析コード２</summary>
        /// <remarks>※マスタ管理しないため、コードはユーザー管理となる</remarks>
        private Int32 _employAnalysCode2;

        /// <summary>従業員分析コード３</summary>
        private Int32 _employAnalysCode3;

        /// <summary>従業員分析コード４</summary>
        private Int32 _employAnalysCode4;

        /// <summary>従業員分析コード５</summary>
        private Int32 _employAnalysCode5;

        /// <summary>従業員分析コード６</summary>
        private Int32 _employAnalysCode6;

        /// <summary>UOE略称区分</summary>
        private string _uOESnmDiv = "";

        /// <summary>メールアドレス種別コード1</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode1;

        /// <summary>メールアドレス種別名称1</summary>
        private string _mailAddrKindName1 = "";

        /// <summary>メールアドレス1</summary>
        private string _mailAddress1 = "";

        /// <summary>メール送信区分コード1</summary>
        /// <remarks>0:非送信,1:送信</remarks>
        private Int32 _mailSendCode1;

        /// <summary>メールアドレス種別コード2</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode2;

        /// <summary>メールアドレス種別名称2</summary>
        private string _mailAddrKindName2 = "";

        /// <summary>メールアドレス2</summary>
        private string _mailAddress2 = "";

        /// <summary>メール送信区分コード2</summary>
        /// <remarks>0:非送信,1:送信</remarks>
        private Int32 _mailSendCode2;


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

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  BelongSubSectionCode
        /// <summary>所属部門コードプロパティ</summary>
        /// <value>※部門管理しない場合は、使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   所属部門コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BelongSubSectionCode
        {
            get { return _belongSubSectionCode; }
            set { _belongSubSectionCode = value; }
        }

        /// public propaty name  :  EmployAnalysCode1
        /// <summary>従業員分析コード１プロパティ</summary>
        /// <value>年齢,グループ等分析用任意コードを設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode1
        {
            get { return _employAnalysCode1; }
            set { _employAnalysCode1 = value; }
        }

        /// public propaty name  :  EmployAnalysCode2
        /// <summary>従業員分析コード２プロパティ</summary>
        /// <value>※マスタ管理しないため、コードはユーザー管理となる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode2
        {
            get { return _employAnalysCode2; }
            set { _employAnalysCode2 = value; }
        }

        /// public propaty name  :  EmployAnalysCode3
        /// <summary>従業員分析コード３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode3
        {
            get { return _employAnalysCode3; }
            set { _employAnalysCode3 = value; }
        }

        /// public propaty name  :  EmployAnalysCode4
        /// <summary>従業員分析コード４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode4
        {
            get { return _employAnalysCode4; }
            set { _employAnalysCode4 = value; }
        }

        /// public propaty name  :  EmployAnalysCode5
        /// <summary>従業員分析コード５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode5
        {
            get { return _employAnalysCode5; }
            set { _employAnalysCode5 = value; }
        }

        /// public propaty name  :  EmployAnalysCode6
        /// <summary>従業員分析コード６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員分析コード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EmployAnalysCode6
        {
            get { return _employAnalysCode6; }
            set { _employAnalysCode6 = value; }
        }

        /// public propaty name  :  UOESnmDiv
        /// <summary>UOE略称区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE略称区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESnmDiv
        {
            get { return _uOESnmDiv; }
            set { _uOESnmDiv = value; }
        }

        /// public propaty name  :  MailAddrKindCode1
        /// <summary>メールアドレス種別コード1プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode1
        {
            get { return _mailAddrKindCode1; }
            set { _mailAddrKindCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindName1
        /// <summary>メールアドレス種別名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddrKindName1
        {
            get { return _mailAddrKindName1; }
            set { _mailAddrKindName1 = value; }
        }

        /// public propaty name  :  MailAddress1
        /// <summary>メールアドレス1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress1
        {
            get { return _mailAddress1; }
            set { _mailAddress1 = value; }
        }

        /// public propaty name  :  MailSendCode1
        /// <summary>メール送信区分コード1プロパティ</summary>
        /// <value>0:非送信,1:送信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailSendCode1
        {
            get { return _mailSendCode1; }
            set { _mailSendCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindCode2
        /// <summary>メールアドレス種別コード2プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode2
        {
            get { return _mailAddrKindCode2; }
            set { _mailAddrKindCode2 = value; }
        }

        /// public propaty name  :  MailAddrKindName2
        /// <summary>メールアドレス種別名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddrKindName2
        {
            get { return _mailAddrKindName2; }
            set { _mailAddrKindName2 = value; }
        }

        /// public propaty name  :  MailAddress2
        /// <summary>メールアドレス2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress2
        {
            get { return _mailAddress2; }
            set { _mailAddress2 = value; }
        }

        /// public propaty name  :  MailSendCode2
        /// <summary>メール送信区分コード2プロパティ</summary>
        /// <value>0:非送信,1:送信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailSendCode2
        {
            get { return _mailSendCode2; }
            set { _mailSendCode2 = value; }
        }


        /// <summary>
        /// 従業員詳細ワークコンストラクタ
        /// </summary>
        /// <returns>EmployeeDtlWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DCEmployeeDtlWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>EmployeeDtlWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   EmployeeDtlWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DCEmployeeDtlWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EmployeeDtlWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DCEmployeeDtlWork || graph is ArrayList || graph is DCEmployeeDtlWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DCEmployeeDtlWork).FullName));

            if (graph != null && graph is DCEmployeeDtlWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EmployeeDtlWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DCEmployeeDtlWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DCEmployeeDtlWork[])graph).Length;
            }
            else if (graph is DCEmployeeDtlWork)
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
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //所属部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BelongSubSectionCode
            //従業員分析コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployAnalysCode1
            //従業員分析コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployAnalysCode2
            //従業員分析コード３
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployAnalysCode3
            //従業員分析コード４
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployAnalysCode4
            //従業員分析コード５
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployAnalysCode5
            //従業員分析コード６
            serInfo.MemberInfo.Add(typeof(Int32)); //EmployAnalysCode6
            //UOE略称区分
            serInfo.MemberInfo.Add(typeof(string)); //UOESnmDiv
            //メールアドレス種別コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //MailAddrKindCode1
            //メールアドレス種別名称1
            serInfo.MemberInfo.Add(typeof(string)); //MailAddrKindName1
            //メールアドレス1
            serInfo.MemberInfo.Add(typeof(string)); //MailAddress1
            //メール送信区分コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //MailSendCode1
            //メールアドレス種別コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //MailAddrKindCode2
            //メールアドレス種別名称2
            serInfo.MemberInfo.Add(typeof(string)); //MailAddrKindName2
            //メールアドレス2
            serInfo.MemberInfo.Add(typeof(string)); //MailAddress2
            //メール送信区分コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //MailSendCode2


            serInfo.Serialize(writer, serInfo);
            if (graph is DCEmployeeDtlWork)
            {
                DCEmployeeDtlWork temp = (DCEmployeeDtlWork)graph;

                SetEmployeeDtlWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DCEmployeeDtlWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DCEmployeeDtlWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DCEmployeeDtlWork temp in lst)
                {
                    SetEmployeeDtlWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EmployeeDtlWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  EmployeeDtlWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetEmployeeDtlWork(System.IO.BinaryWriter writer, DCEmployeeDtlWork temp)
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
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //所属部門コード
            writer.Write(temp.BelongSubSectionCode);
            //従業員分析コード１
            writer.Write(temp.EmployAnalysCode1);
            //従業員分析コード２
            writer.Write(temp.EmployAnalysCode2);
            //従業員分析コード３
            writer.Write(temp.EmployAnalysCode3);
            //従業員分析コード４
            writer.Write(temp.EmployAnalysCode4);
            //従業員分析コード５
            writer.Write(temp.EmployAnalysCode5);
            //従業員分析コード６
            writer.Write(temp.EmployAnalysCode6);
            //UOE略称区分
            writer.Write(temp.UOESnmDiv);
            //メールアドレス種別コード1
            writer.Write(temp.MailAddrKindCode1);
            //メールアドレス種別名称1
            writer.Write(temp.MailAddrKindName1);
            //メールアドレス1
            writer.Write(temp.MailAddress1);
            //メール送信区分コード1
            writer.Write(temp.MailSendCode1);
            //メールアドレス種別コード2
            writer.Write(temp.MailAddrKindCode2);
            //メールアドレス種別名称2
            writer.Write(temp.MailAddrKindName2);
            //メールアドレス2
            writer.Write(temp.MailAddress2);
            //メール送信区分コード2
            writer.Write(temp.MailSendCode2);

        }

        /// <summary>
        ///  EmployeeDtlWorkインスタンス取得
        /// </summary>
        /// <returns>EmployeeDtlWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private DCEmployeeDtlWork GetEmployeeDtlWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DCEmployeeDtlWork temp = new DCEmployeeDtlWork();

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
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //所属部門コード
            temp.BelongSubSectionCode = reader.ReadInt32();
            //従業員分析コード１
            temp.EmployAnalysCode1 = reader.ReadInt32();
            //従業員分析コード２
            temp.EmployAnalysCode2 = reader.ReadInt32();
            //従業員分析コード３
            temp.EmployAnalysCode3 = reader.ReadInt32();
            //従業員分析コード４
            temp.EmployAnalysCode4 = reader.ReadInt32();
            //従業員分析コード５
            temp.EmployAnalysCode5 = reader.ReadInt32();
            //従業員分析コード６
            temp.EmployAnalysCode6 = reader.ReadInt32();
            //UOE略称区分
            temp.UOESnmDiv = reader.ReadString();
            //メールアドレス種別コード1
            temp.MailAddrKindCode1 = reader.ReadInt32();
            //メールアドレス種別名称1
            temp.MailAddrKindName1 = reader.ReadString();
            //メールアドレス1
            temp.MailAddress1 = reader.ReadString();
            //メール送信区分コード1
            temp.MailSendCode1 = reader.ReadInt32();
            //メールアドレス種別コード2
            temp.MailAddrKindCode2 = reader.ReadInt32();
            //メールアドレス種別名称2
            temp.MailAddrKindName2 = reader.ReadString();
            //メールアドレス2
            temp.MailAddress2 = reader.ReadString();
            //メール送信区分コード2
            temp.MailSendCode2 = reader.ReadInt32();


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
        /// <returns>EmployeeDtlWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeDtlWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DCEmployeeDtlWork temp = GetEmployeeDtlWork(reader, serInfo);
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
                    retValue = (DCEmployeeDtlWork[])lst.ToArray(typeof(DCEmployeeDtlWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
