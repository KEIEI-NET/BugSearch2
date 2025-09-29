using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;



namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DepositStWork
    /// <summary>
    ///                      入金設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   入金設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DepositStWork : IFileHeader
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

        /// <summary>入金設定管理コード</summary>
        /// <remarks>常に０固定</remarks>
        private Int32 _depositStMngCd;

        /// <summary>入金初期表示画面番号</summary>
        /// <remarks>1:入金型,2:受注指定型</remarks>
        private Int32 _depositInitDspNo;

        /// <summary>初期選択金種コード</summary>
        /// <remarks>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</remarks>
        private Int32 _initSelMoneyKindCd;

        /// <summary>入金設定金種コード1</summary>
        private Int32 _depositStKindCd1;

        /// <summary>入金設定金種コード2</summary>
        private Int32 _depositStKindCd2;

        /// <summary>入金設定金種コード3</summary>
        private Int32 _depositStKindCd3;

        /// <summary>入金設定金種コード4</summary>
        private Int32 _depositStKindCd4;

        /// <summary>入金設定金種コード5</summary>
        private Int32 _depositStKindCd5;

        /// <summary>入金設定金種コード6</summary>
        private Int32 _depositStKindCd6;

        /// <summary>入金設定金種コード7</summary>
        private Int32 _depositStKindCd7;

        /// <summary>入金設定金種コード8</summary>
        private Int32 _depositStKindCd8;

        /// <summary>入金設定金種コード9</summary>
        private Int32 _depositStKindCd9;

        /// <summary>入金設定金種コード10</summary>
        private Int32 _depositStKindCd10;

        /// <summary>引当済入金伝票呼出区分</summary>
        /// <remarks>0:引当済みでも呼び出す、1:金額引当済みは呼び出さない</remarks>
        private Int32 _alwcDepoCallMonthsCd;


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

        /// public propaty name  :  DepositStMngCd
        /// <summary>入金設定管理コードプロパティ</summary>
        /// <value>常に０固定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定管理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStMngCd
        {
            get { return _depositStMngCd; }
            set { _depositStMngCd = value; }
        }

        /// public propaty name  :  DepositInitDspNo
        /// <summary>入金初期表示画面番号プロパティ</summary>
        /// <value>1:入金型,2:受注指定型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金初期表示画面番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositInitDspNo
        {
            get { return _depositInitDspNo; }
            set { _depositInitDspNo = value; }
        }

        /// public propaty name  :  InitSelMoneyKindCd
        /// <summary>初期選択金種コードプロパティ</summary>
        /// <value>1～899:提供分,900～ユーザー登録　※8:値引 9:預かり金</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期選択金種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InitSelMoneyKindCd
        {
            get { return _initSelMoneyKindCd; }
            set { _initSelMoneyKindCd = value; }
        }

        /// public propaty name  :  DepositStKindCd1
        /// <summary>入金設定金種コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd1
        {
            get { return _depositStKindCd1; }
            set { _depositStKindCd1 = value; }
        }

        /// public propaty name  :  DepositStKindCd2
        /// <summary>入金設定金種コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd2
        {
            get { return _depositStKindCd2; }
            set { _depositStKindCd2 = value; }
        }

        /// public propaty name  :  DepositStKindCd3
        /// <summary>入金設定金種コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd3
        {
            get { return _depositStKindCd3; }
            set { _depositStKindCd3 = value; }
        }

        /// public propaty name  :  DepositStKindCd4
        /// <summary>入金設定金種コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd4
        {
            get { return _depositStKindCd4; }
            set { _depositStKindCd4 = value; }
        }

        /// public propaty name  :  DepositStKindCd5
        /// <summary>入金設定金種コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd5
        {
            get { return _depositStKindCd5; }
            set { _depositStKindCd5 = value; }
        }

        /// public propaty name  :  DepositStKindCd6
        /// <summary>入金設定金種コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd6
        {
            get { return _depositStKindCd6; }
            set { _depositStKindCd6 = value; }
        }

        /// public propaty name  :  DepositStKindCd7
        /// <summary>入金設定金種コード7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd7
        {
            get { return _depositStKindCd7; }
            set { _depositStKindCd7 = value; }
        }

        /// public propaty name  :  DepositStKindCd8
        /// <summary>入金設定金種コード8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd8
        {
            get { return _depositStKindCd8; }
            set { _depositStKindCd8 = value; }
        }

        /// public propaty name  :  DepositStKindCd9
        /// <summary>入金設定金種コード9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd9
        {
            get { return _depositStKindCd9; }
            set { _depositStKindCd9 = value; }
        }

        /// public propaty name  :  DepositStKindCd10
        /// <summary>入金設定金種コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金設定金種コード10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepositStKindCd10
        {
            get { return _depositStKindCd10; }
            set { _depositStKindCd10 = value; }
        }

        /// public propaty name  :  AlwcDepoCallMonthsCd
        /// <summary>引当済入金伝票呼出区分プロパティ</summary>
        /// <value>0:引当済みでも呼び出す、1:金額引当済みは呼び出さない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   引当済入金伝票呼出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AlwcDepoCallMonthsCd
        {
            get { return _alwcDepoCallMonthsCd; }
            set { _alwcDepoCallMonthsCd = value; }
        }


        /// <summary>
        /// 入金設定ワークコンストラクタ
        /// </summary>
        /// <returns>DepositStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DepositStWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>DepositStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   DepositStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DepositStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DepositStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DepositStWork || graph is ArrayList || graph is DepositStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DepositStWork).FullName));

            if (graph != null && graph is DepositStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DepositStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DepositStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DepositStWork[])graph).Length;
            }
            else if (graph is DepositStWork)
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
            //入金設定管理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStMngCd
            //入金初期表示画面番号
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositInitDspNo
            //初期選択金種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //InitSelMoneyKindCd
            //入金設定金種コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd1
            //入金設定金種コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd2
            //入金設定金種コード3
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd3
            //入金設定金種コード4
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd4
            //入金設定金種コード5
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd5
            //入金設定金種コード6
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd6
            //入金設定金種コード7
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd7
            //入金設定金種コード8
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd8
            //入金設定金種コード9
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd9
            //入金設定金種コード10
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositStKindCd10
            //引当済入金伝票呼出区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AlwcDepoCallMonthsCd


            serInfo.Serialize(writer, serInfo);
            if (graph is DepositStWork)
            {
                DepositStWork temp = (DepositStWork)graph;

                SetDepositStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DepositStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DepositStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DepositStWork temp in lst)
                {
                    SetDepositStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DepositStWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 22;

        /// <summary>
        ///  DepositStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetDepositStWork(System.IO.BinaryWriter writer, DepositStWork temp)
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
            //入金設定管理コード
            writer.Write(temp.DepositStMngCd);
            //入金初期表示画面番号
            writer.Write(temp.DepositInitDspNo);
            //初期選択金種コード
            writer.Write(temp.InitSelMoneyKindCd);
            //入金設定金種コード1
            writer.Write(temp.DepositStKindCd1);
            //入金設定金種コード2
            writer.Write(temp.DepositStKindCd2);
            //入金設定金種コード3
            writer.Write(temp.DepositStKindCd3);
            //入金設定金種コード4
            writer.Write(temp.DepositStKindCd4);
            //入金設定金種コード5
            writer.Write(temp.DepositStKindCd5);
            //入金設定金種コード6
            writer.Write(temp.DepositStKindCd6);
            //入金設定金種コード7
            writer.Write(temp.DepositStKindCd7);
            //入金設定金種コード8
            writer.Write(temp.DepositStKindCd8);
            //入金設定金種コード9
            writer.Write(temp.DepositStKindCd9);
            //入金設定金種コード10
            writer.Write(temp.DepositStKindCd10);
            //引当済入金伝票呼出区分
            writer.Write(temp.AlwcDepoCallMonthsCd);

        }

        /// <summary>
        ///  DepositStWorkインスタンス取得
        /// </summary>
        /// <returns>DepositStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private DepositStWork GetDepositStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DepositStWork temp = new DepositStWork();

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
            //入金設定管理コード
            temp.DepositStMngCd = reader.ReadInt32();
            //入金初期表示画面番号
            temp.DepositInitDspNo = reader.ReadInt32();
            //初期選択金種コード
            temp.InitSelMoneyKindCd = reader.ReadInt32();
            //入金設定金種コード1
            temp.DepositStKindCd1 = reader.ReadInt32();
            //入金設定金種コード2
            temp.DepositStKindCd2 = reader.ReadInt32();
            //入金設定金種コード3
            temp.DepositStKindCd3 = reader.ReadInt32();
            //入金設定金種コード4
            temp.DepositStKindCd4 = reader.ReadInt32();
            //入金設定金種コード5
            temp.DepositStKindCd5 = reader.ReadInt32();
            //入金設定金種コード6
            temp.DepositStKindCd6 = reader.ReadInt32();
            //入金設定金種コード7
            temp.DepositStKindCd7 = reader.ReadInt32();
            //入金設定金種コード8
            temp.DepositStKindCd8 = reader.ReadInt32();
            //入金設定金種コード9
            temp.DepositStKindCd9 = reader.ReadInt32();
            //入金設定金種コード10
            temp.DepositStKindCd10 = reader.ReadInt32();
            //引当済入金伝票呼出区分
            temp.AlwcDepoCallMonthsCd = reader.ReadInt32();


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
        /// <returns>DepositStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DepositStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DepositStWork temp = GetDepositStWork(reader, serInfo);
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
                    retValue = (DepositStWork[])lst.ToArray(typeof(DepositStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
